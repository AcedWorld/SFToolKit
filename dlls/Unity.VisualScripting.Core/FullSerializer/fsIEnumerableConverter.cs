using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting.FullSerializer.Internal;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x02000180 RID: 384
	public class fsIEnumerableConverter : fsConverter
	{
		// Token: 0x06000A37 RID: 2615 RVA: 0x0002A993 File Offset: 0x00028B93
		public override bool CanProcess(Type type)
		{
			return typeof(IEnumerable).IsAssignableFrom(type) && fsIEnumerableConverter.GetAddMethod(type) != null;
		}

		// Token: 0x06000A38 RID: 2616 RVA: 0x0002A9B5 File Offset: 0x00028BB5
		public override object CreateInstance(fsData data, Type storageType)
		{
			return fsMetaType.Get(this.Serializer.Config, storageType).CreateInstance();
		}

		// Token: 0x06000A39 RID: 2617 RVA: 0x0002A9D0 File Offset: 0x00028BD0
		public override fsResult TrySerialize(object instance_, out fsData serialized, Type storageType)
		{
			IEnumerable enumerable = (IEnumerable)instance_;
			fsResult success = fsResult.Success;
			Type elementType = fsIEnumerableConverter.GetElementType(storageType);
			serialized = fsData.CreateList(fsIEnumerableConverter.HintSize(enumerable));
			List<fsData> asList = serialized.AsList;
			foreach (object instance in enumerable)
			{
				fsData item;
				fsResult result = this.Serializer.TrySerialize(elementType, instance, out item);
				success.AddMessages(result);
				if (!result.Failed)
				{
					asList.Add(item);
				}
			}
			if (this.IsStack(enumerable.GetType()))
			{
				asList.Reverse();
			}
			return success;
		}

		// Token: 0x06000A3A RID: 2618 RVA: 0x0002AA8C File Offset: 0x00028C8C
		private bool IsStack(Type type)
		{
			return type.Resolve().IsGenericType && type.Resolve().GetGenericTypeDefinition() == typeof(Stack<>);
		}

		// Token: 0x06000A3B RID: 2619 RVA: 0x0002AAB8 File Offset: 0x00028CB8
		public override fsResult TryDeserialize(fsData data, ref object instance_, Type storageType)
		{
			IEnumerable enumerable = (IEnumerable)instance_;
			fsResult fsResult = fsResult.Success;
			fsResult fsResult2;
			fsResult = (fsResult2 = fsResult + base.CheckType(data, fsDataType.Array));
			if (fsResult2.Failed)
			{
				return fsResult;
			}
			Type elementType = fsIEnumerableConverter.GetElementType(storageType);
			MethodInfo addMethod = fsIEnumerableConverter.GetAddMethod(storageType);
			fsIEnumerableConverter.TryClear(storageType, enumerable);
			List<fsData> asList = data.AsList;
			for (int i = 0; i < asList.Count; i++)
			{
				fsData data2 = asList[i];
				object obj = null;
				fsResult result = this.Serializer.TryDeserialize(data2, elementType, ref obj);
				fsResult.AddMessages(result);
				if (result.Succeeded)
				{
					addMethod.Invoke(enumerable, new object[]
					{
						obj
					});
				}
			}
			return fsResult;
		}

		// Token: 0x06000A3C RID: 2620 RVA: 0x0002AB69 File Offset: 0x00028D69
		private static int HintSize(IEnumerable collection)
		{
			if (collection is ICollection)
			{
				return ((ICollection)collection).Count;
			}
			return 0;
		}

		// Token: 0x06000A3D RID: 2621 RVA: 0x0002AB80 File Offset: 0x00028D80
		private static Type GetElementType(Type objectType)
		{
			if (objectType.HasElementType)
			{
				return objectType.GetElementType();
			}
			Type @interface = fsReflectionUtility.GetInterface(objectType, typeof(IEnumerable<>));
			if (@interface != null)
			{
				return @interface.GetGenericArguments()[0];
			}
			return typeof(object);
		}

		// Token: 0x06000A3E RID: 2622 RVA: 0x0002ABCC File Offset: 0x00028DCC
		private static void TryClear(Type type, object instance)
		{
			MethodInfo flattenedMethod = type.GetFlattenedMethod("Clear");
			if (flattenedMethod != null)
			{
				flattenedMethod.Invoke(instance, null);
			}
		}

		// Token: 0x06000A3F RID: 2623 RVA: 0x0002ABF8 File Offset: 0x00028DF8
		private static int TryGetExistingSize(Type type, object instance)
		{
			PropertyInfo flattenedProperty = type.GetFlattenedProperty("Count");
			if (flattenedProperty != null)
			{
				return (int)flattenedProperty.GetGetMethod().Invoke(instance, null);
			}
			return 0;
		}

		// Token: 0x06000A40 RID: 2624 RVA: 0x0002AC30 File Offset: 0x00028E30
		private static MethodInfo GetAddMethod(Type type)
		{
			Type @interface = fsReflectionUtility.GetInterface(type, typeof(ICollection<>));
			if (@interface != null)
			{
				MethodInfo declaredMethod = @interface.GetDeclaredMethod("Add");
				if (declaredMethod != null)
				{
					return declaredMethod;
				}
			}
			MethodInfo result;
			if ((result = type.GetFlattenedMethod("Add")) == null)
			{
				result = (type.GetFlattenedMethod("Push") ?? type.GetFlattenedMethod("Enqueue"));
			}
			return result;
		}
	}
}
