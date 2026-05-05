using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x020001AA RID: 426
	public class fsMetaType
	{
		// Token: 0x06000B60 RID: 2912 RVA: 0x000303A8 File Offset: 0x0002E5A8
		private fsMetaType(fsConfig config, Type reflectedType)
		{
			this.ReflectedType = reflectedType;
			List<fsMetaProperty> list = new List<fsMetaProperty>();
			fsMetaType.CollectProperties(config, list, reflectedType);
			this.Properties = list.ToArray();
		}

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x06000B61 RID: 2913 RVA: 0x000303DC File Offset: 0x0002E5DC
		// (set) Token: 0x06000B62 RID: 2914 RVA: 0x000303E4 File Offset: 0x0002E5E4
		public fsMetaProperty[] Properties { get; private set; }

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06000B63 RID: 2915 RVA: 0x000303F0 File Offset: 0x0002E5F0
		public bool HasDefaultConstructor
		{
			get
			{
				if (this._hasDefaultConstructorCache == null)
				{
					if (this.ReflectedType.Resolve().IsArray)
					{
						this._hasDefaultConstructorCache = new bool?(true);
						this._isDefaultConstructorPublic = true;
					}
					else if (this.ReflectedType.Resolve().IsValueType)
					{
						this._hasDefaultConstructorCache = new bool?(true);
						this._isDefaultConstructorPublic = true;
					}
					else
					{
						ConstructorInfo declaredConstructor = this.ReflectedType.GetDeclaredConstructor(fsPortableReflection.EmptyTypes);
						this._hasDefaultConstructorCache = new bool?(declaredConstructor != null);
						if (declaredConstructor != null)
						{
							this._isDefaultConstructorPublic = declaredConstructor.IsPublic;
						}
					}
				}
				return this._hasDefaultConstructorCache.Value;
			}
		}

		// Token: 0x06000B64 RID: 2916 RVA: 0x000304A0 File Offset: 0x0002E6A0
		public bool EmitAotData()
		{
			if (this._hasEmittedAotData)
			{
				return false;
			}
			this._hasEmittedAotData = true;
			for (int i = 0; i < this.Properties.Length; i++)
			{
				if (!this.Properties[i].IsPublic)
				{
					return false;
				}
				if (this.Properties[i].IsReadOnly)
				{
					return false;
				}
			}
			if (!this.HasDefaultConstructor)
			{
				return false;
			}
			fsAotCompilationManager.AddAotCompilation(this.ReflectedType, this.Properties, this._isDefaultConstructorPublic);
			return true;
		}

		// Token: 0x06000B65 RID: 2917 RVA: 0x00030518 File Offset: 0x0002E718
		public object CreateInstance()
		{
			if (this.ReflectedType.Resolve().IsInterface || this.ReflectedType.Resolve().IsAbstract)
			{
				string str = "Cannot create an instance of an interface or abstract type for ";
				Type reflectedType = this.ReflectedType;
				throw new Exception(str + ((reflectedType != null) ? reflectedType.ToString() : null));
			}
			if (typeof(ScriptableObject).IsAssignableFrom(this.ReflectedType))
			{
				return ScriptableObject.CreateInstance(this.ReflectedType);
			}
			if (typeof(string) == this.ReflectedType)
			{
				return string.Empty;
			}
			if (!this.HasDefaultConstructor)
			{
				return FormatterServices.GetSafeUninitializedObject(this.ReflectedType);
			}
			if (this.ReflectedType.Resolve().IsArray)
			{
				return Array.CreateInstance(this.ReflectedType.GetElementType(), 0);
			}
			object result;
			try
			{
				result = Activator.CreateInstance(this.ReflectedType, true);
			}
			catch (MissingMethodException innerException)
			{
				string str2 = "Unable to create instance of ";
				Type reflectedType2 = this.ReflectedType;
				throw new InvalidOperationException(str2 + ((reflectedType2 != null) ? reflectedType2.ToString() : null) + "; there is no default constructor", innerException);
			}
			catch (TargetInvocationException innerException2)
			{
				string str3 = "Constructor of ";
				Type reflectedType3 = this.ReflectedType;
				throw new InvalidOperationException(str3 + ((reflectedType3 != null) ? reflectedType3.ToString() : null) + " threw an exception when creating an instance", innerException2);
			}
			catch (MemberAccessException innerException3)
			{
				string str4 = "Unable to access constructor of ";
				Type reflectedType4 = this.ReflectedType;
				throw new InvalidOperationException(str4 + ((reflectedType4 != null) ? reflectedType4.ToString() : null), innerException3);
			}
			return result;
		}

		// Token: 0x06000B66 RID: 2918 RVA: 0x00030694 File Offset: 0x0002E894
		public static fsMetaType Get(fsConfig config, Type type)
		{
			Type typeFromHandle = typeof(fsMetaType);
			Dictionary<Type, fsMetaType> dictionary;
			lock (typeFromHandle)
			{
				if (!fsMetaType._configMetaTypes.TryGetValue(config, out dictionary))
				{
					dictionary = (fsMetaType._configMetaTypes[config] = new Dictionary<Type, fsMetaType>());
				}
			}
			fsMetaType fsMetaType;
			if (!dictionary.TryGetValue(type, out fsMetaType))
			{
				fsMetaType = new fsMetaType(config, type);
				dictionary[type] = fsMetaType;
			}
			return fsMetaType;
		}

		// Token: 0x06000B67 RID: 2919 RVA: 0x00030714 File Offset: 0x0002E914
		public static void ClearCache()
		{
			Type typeFromHandle = typeof(fsMetaType);
			lock (typeFromHandle)
			{
				fsMetaType._configMetaTypes = new Dictionary<fsConfig, Dictionary<Type, fsMetaType>>();
			}
		}

		// Token: 0x06000B68 RID: 2920 RVA: 0x0003075C File Offset: 0x0002E95C
		private static void CollectProperties(fsConfig config, List<fsMetaProperty> properties, Type reflectedType)
		{
			bool flag = config.DefaultMemberSerialization == fsMemberSerialization.OptIn;
			bool flag2 = config.DefaultMemberSerialization == fsMemberSerialization.OptOut;
			fsObjectAttribute attribute = fsPortableReflection.GetAttribute<fsObjectAttribute>(reflectedType);
			if (attribute != null)
			{
				flag = (attribute.MemberSerialization == fsMemberSerialization.OptIn);
				flag2 = (attribute.MemberSerialization == fsMemberSerialization.OptOut);
			}
			MemberInfo[] declaredMembers = reflectedType.GetDeclaredMembers();
			MemberInfo[] array = declaredMembers;
			for (int i = 0; i < array.Length; i++)
			{
				MemberInfo member = array[i];
				if (!config.IgnoreSerializeAttributes.Any((Type t) => fsPortableReflection.HasAttribute(member, t)))
				{
					PropertyInfo propertyInfo = member as PropertyInfo;
					FieldInfo fieldInfo = member as FieldInfo;
					if ((!(propertyInfo == null) || !(fieldInfo == null)) && (!(propertyInfo != null) || config.EnablePropertySerialization) && (!flag || config.SerializeAttributes.Any((Type t) => fsPortableReflection.HasAttribute(member, t))) && (!flag2 || !config.IgnoreSerializeAttributes.Any((Type t) => fsPortableReflection.HasAttribute(member, t))))
					{
						if (propertyInfo != null)
						{
							if (fsMetaType.CanSerializeProperty(config, propertyInfo, declaredMembers, flag2))
							{
								properties.Add(new fsMetaProperty(config, propertyInfo));
							}
						}
						else if (fieldInfo != null && fsMetaType.CanSerializeField(config, fieldInfo, flag2))
						{
							properties.Add(new fsMetaProperty(config, fieldInfo));
						}
					}
				}
			}
			if (reflectedType.Resolve().BaseType != null)
			{
				fsMetaType.CollectProperties(config, properties, reflectedType.Resolve().BaseType);
			}
		}

		// Token: 0x06000B69 RID: 2921 RVA: 0x000308DE File Offset: 0x0002EADE
		private static bool IsAutoProperty(PropertyInfo property, MemberInfo[] members)
		{
			return property.CanWrite && property.CanRead && fsPortableReflection.HasAttribute(property.GetGetMethod(), typeof(CompilerGeneratedAttribute), false);
		}

		// Token: 0x06000B6A RID: 2922 RVA: 0x00030908 File Offset: 0x0002EB08
		private static bool CanSerializeProperty(fsConfig config, PropertyInfo property, MemberInfo[] members, bool annotationFreeValue)
		{
			if (typeof(Delegate).IsAssignableFrom(property.PropertyType))
			{
				return false;
			}
			MethodInfo getMethod = property.GetGetMethod(false);
			MethodInfo setMethod = property.GetSetMethod(false);
			return (!(getMethod != null) || !getMethod.IsStatic) && (!(setMethod != null) || !setMethod.IsStatic) && property.GetIndexParameters().Length == 0 && (config.SerializeAttributes.Any((Type t) => fsPortableReflection.HasAttribute(property, t)) || (property.CanRead && property.CanWrite && ((getMethod != null && (config.SerializeNonPublicSetProperties || setMethod != null) && (config.SerializeNonAutoProperties || fsMetaType.IsAutoProperty(property, members))) || annotationFreeValue)));
		}

		// Token: 0x06000B6B RID: 2923 RVA: 0x000309F8 File Offset: 0x0002EBF8
		private static bool CanSerializeField(fsConfig config, FieldInfo field, bool annotationFreeValue)
		{
			return !typeof(Delegate).IsAssignableFrom(field.FieldType) && !Attribute.IsDefined(field, typeof(CompilerGeneratedAttribute), false) && !field.IsStatic && (config.SerializeAttributes.Any((Type t) => fsPortableReflection.HasAttribute(field, t)) || annotationFreeValue || field.IsPublic);
		}

		// Token: 0x040002BC RID: 700
		public Type ReflectedType;

		// Token: 0x040002BD RID: 701
		private bool _hasEmittedAotData;

		// Token: 0x040002BE RID: 702
		private bool? _hasDefaultConstructorCache;

		// Token: 0x040002BF RID: 703
		private bool _isDefaultConstructorPublic;

		// Token: 0x040002C1 RID: 705
		private static Dictionary<fsConfig, Dictionary<Type, fsMetaType>> _configMetaTypes = new Dictionary<fsConfig, Dictionary<Type, fsMetaType>>();
	}
}
