using System;
using System.Reflection;
using Unity.VisualScripting.FullSerializer.Internal;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x020001A9 RID: 425
	public class fsMetaProperty
	{
		// Token: 0x06000B4B RID: 2891 RVA: 0x00030108 File Offset: 0x0002E308
		internal fsMetaProperty(fsConfig config, FieldInfo field)
		{
			this._memberInfo = field;
			this.StorageType = field.FieldType;
			this.MemberName = field.Name;
			this.IsPublic = field.IsPublic;
			this.IsReadOnly = field.IsInitOnly;
			this.CanRead = true;
			this.CanWrite = true;
			this.CommonInitialize(config);
		}

		// Token: 0x06000B4C RID: 2892 RVA: 0x00030168 File Offset: 0x0002E368
		internal fsMetaProperty(fsConfig config, PropertyInfo property)
		{
			this._memberInfo = property;
			this.StorageType = property.PropertyType;
			this.MemberName = property.Name;
			this.IsPublic = (property.GetGetMethod() != null && property.GetGetMethod().IsPublic && property.GetSetMethod() != null && property.GetSetMethod().IsPublic);
			this.IsReadOnly = false;
			this.CanRead = property.CanRead;
			this.CanWrite = property.CanWrite;
			this.CommonInitialize(config);
		}

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x06000B4D RID: 2893 RVA: 0x000301FD File Offset: 0x0002E3FD
		// (set) Token: 0x06000B4E RID: 2894 RVA: 0x00030205 File Offset: 0x0002E405
		public Type StorageType { get; private set; }

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x06000B4F RID: 2895 RVA: 0x0003020E File Offset: 0x0002E40E
		// (set) Token: 0x06000B50 RID: 2896 RVA: 0x00030216 File Offset: 0x0002E416
		public Type OverrideConverterType { get; private set; }

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x06000B51 RID: 2897 RVA: 0x0003021F File Offset: 0x0002E41F
		// (set) Token: 0x06000B52 RID: 2898 RVA: 0x00030227 File Offset: 0x0002E427
		public bool CanRead { get; private set; }

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x06000B53 RID: 2899 RVA: 0x00030230 File Offset: 0x0002E430
		// (set) Token: 0x06000B54 RID: 2900 RVA: 0x00030238 File Offset: 0x0002E438
		public bool CanWrite { get; private set; }

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x06000B55 RID: 2901 RVA: 0x00030241 File Offset: 0x0002E441
		// (set) Token: 0x06000B56 RID: 2902 RVA: 0x00030249 File Offset: 0x0002E449
		public string JsonName { get; private set; }

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x06000B57 RID: 2903 RVA: 0x00030252 File Offset: 0x0002E452
		// (set) Token: 0x06000B58 RID: 2904 RVA: 0x0003025A File Offset: 0x0002E45A
		public string MemberName { get; private set; }

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x06000B59 RID: 2905 RVA: 0x00030263 File Offset: 0x0002E463
		// (set) Token: 0x06000B5A RID: 2906 RVA: 0x0003026B File Offset: 0x0002E46B
		public bool IsPublic { get; private set; }

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x06000B5B RID: 2907 RVA: 0x00030274 File Offset: 0x0002E474
		// (set) Token: 0x06000B5C RID: 2908 RVA: 0x0003027C File Offset: 0x0002E47C
		public bool IsReadOnly { get; private set; }

		// Token: 0x06000B5D RID: 2909 RVA: 0x00030288 File Offset: 0x0002E488
		private void CommonInitialize(fsConfig config)
		{
			fsPropertyAttribute attribute = fsPortableReflection.GetAttribute<fsPropertyAttribute>(this._memberInfo);
			if (attribute != null)
			{
				this.JsonName = attribute.Name;
				this.OverrideConverterType = attribute.Converter;
			}
			if (string.IsNullOrEmpty(this.JsonName))
			{
				this.JsonName = config.GetJsonNameFromMemberName(this.MemberName, this._memberInfo);
			}
		}

		// Token: 0x06000B5E RID: 2910 RVA: 0x000302E8 File Offset: 0x0002E4E8
		public void Write(object context, object value)
		{
			FieldInfo fieldInfo = this._memberInfo as FieldInfo;
			PropertyInfo propertyInfo = this._memberInfo as PropertyInfo;
			if (!(fieldInfo != null))
			{
				if (propertyInfo != null)
				{
					if (PlatformUtility.supportsJit)
					{
						if (propertyInfo.CanWrite)
						{
							propertyInfo.SetValueOptimized(context, value);
							return;
						}
					}
					else
					{
						MethodInfo setMethod = propertyInfo.GetSetMethod(true);
						if (setMethod != null)
						{
							setMethod.Invoke(context, new object[]
							{
								value
							});
						}
					}
				}
				return;
			}
			if (PlatformUtility.supportsJit)
			{
				fieldInfo.SetValueOptimized(context, value);
				return;
			}
			fieldInfo.SetValue(context, value);
		}

		// Token: 0x06000B5F RID: 2911 RVA: 0x00030373 File Offset: 0x0002E573
		public object Read(object context)
		{
			if (this._memberInfo is PropertyInfo)
			{
				return ((PropertyInfo)this._memberInfo).GetValue(context, null);
			}
			return ((FieldInfo)this._memberInfo).GetValue(context);
		}

		// Token: 0x040002B3 RID: 691
		internal MemberInfo _memberInfo;
	}
}
