using System;
using Unity.VisualScripting.FullSerializer.Internal;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x0200017E RID: 382
	public class fsForwardConverter : fsConverter
	{
		// Token: 0x06000A2A RID: 2602 RVA: 0x0002A785 File Offset: 0x00028985
		public fsForwardConverter(fsForwardAttribute attribute)
		{
			this._memberName = attribute.MemberName;
		}

		// Token: 0x06000A2B RID: 2603 RVA: 0x0002A799 File Offset: 0x00028999
		public override bool CanProcess(Type type)
		{
			throw new NotSupportedException("Please use the [fsForward(...)] attribute.");
		}

		// Token: 0x06000A2C RID: 2604 RVA: 0x0002A7A8 File Offset: 0x000289A8
		private fsResult GetProperty(object instance, out fsMetaProperty property)
		{
			fsMetaProperty[] properties = fsMetaType.Get(this.Serializer.Config, instance.GetType()).Properties;
			for (int i = 0; i < properties.Length; i++)
			{
				if (properties[i].MemberName == this._memberName)
				{
					property = properties[i];
					return fsResult.Success;
				}
			}
			property = null;
			return fsResult.Fail("No property named \"" + this._memberName + "\" on " + instance.GetType().CSharpName());
		}

		// Token: 0x06000A2D RID: 2605 RVA: 0x0002A828 File Offset: 0x00028A28
		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			serialized = fsData.Null;
			fsResult fsResult = fsResult.Success;
			fsMetaProperty fsMetaProperty;
			fsResult fsResult2;
			fsResult = (fsResult2 = fsResult + this.GetProperty(instance, out fsMetaProperty));
			if (fsResult2.Failed)
			{
				return fsResult;
			}
			object instance2 = fsMetaProperty.Read(instance);
			return this.Serializer.TrySerialize(fsMetaProperty.StorageType, instance2, out serialized);
		}

		// Token: 0x06000A2E RID: 2606 RVA: 0x0002A87C File Offset: 0x00028A7C
		public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			fsResult fsResult = fsResult.Success;
			fsMetaProperty fsMetaProperty;
			fsResult fsResult2;
			fsResult = (fsResult2 = fsResult + this.GetProperty(instance, out fsMetaProperty));
			if (fsResult2.Failed)
			{
				return fsResult;
			}
			object value = null;
			fsResult = (fsResult2 = fsResult + this.Serializer.TryDeserialize(data, fsMetaProperty.StorageType, ref value));
			if (fsResult2.Failed)
			{
				return fsResult;
			}
			fsMetaProperty.Write(instance, value);
			return fsResult;
		}

		// Token: 0x06000A2F RID: 2607 RVA: 0x0002A8E1 File Offset: 0x00028AE1
		public override object CreateInstance(fsData data, Type storageType)
		{
			return fsMetaType.Get(this.Serializer.Config, storageType).CreateInstance();
		}

		// Token: 0x0400025F RID: 607
		private string _memberName;
	}
}
