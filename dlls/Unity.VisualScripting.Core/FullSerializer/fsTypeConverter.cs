using System;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x02000185 RID: 389
	public class fsTypeConverter : fsConverter
	{
		// Token: 0x06000A5C RID: 2652 RVA: 0x0002B52E File Offset: 0x0002972E
		public override bool CanProcess(Type type)
		{
			return typeof(Type).IsAssignableFrom(type);
		}

		// Token: 0x06000A5D RID: 2653 RVA: 0x0002B540 File Offset: 0x00029740
		public override bool RequestCycleSupport(Type type)
		{
			return false;
		}

		// Token: 0x06000A5E RID: 2654 RVA: 0x0002B543 File Offset: 0x00029743
		public override bool RequestInheritanceSupport(Type type)
		{
			return false;
		}

		// Token: 0x06000A5F RID: 2655 RVA: 0x0002B548 File Offset: 0x00029748
		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			Type type = (Type)instance;
			serialized = new fsData(RuntimeCodebase.SerializeType(type));
			return fsResult.Success;
		}

		// Token: 0x06000A60 RID: 2656 RVA: 0x0002B570 File Offset: 0x00029770
		public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			if (!data.IsString)
			{
				return fsResult.Fail("Type converter requires a string");
			}
			Type type;
			if (RuntimeCodebase.TryDeserializeType(data.AsString, out type))
			{
				instance = type;
				return fsResult.Success;
			}
			return fsResult.Fail("Unable to find type: '" + (data.AsString ?? "(null)") + "'.");
		}

		// Token: 0x06000A61 RID: 2657 RVA: 0x0002B5CD File Offset: 0x000297CD
		public override object CreateInstance(fsData data, Type storageType)
		{
			return storageType;
		}
	}
}
