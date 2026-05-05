using System;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x0200017F RID: 383
	public class fsGuidConverter : fsConverter
	{
		// Token: 0x06000A30 RID: 2608 RVA: 0x0002A8F9 File Offset: 0x00028AF9
		public override bool CanProcess(Type type)
		{
			return type == typeof(Guid);
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x0002A90B File Offset: 0x00028B0B
		public override bool RequestCycleSupport(Type storageType)
		{
			return false;
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x0002A90E File Offset: 0x00028B0E
		public override bool RequestInheritanceSupport(Type storageType)
		{
			return false;
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x0002A914 File Offset: 0x00028B14
		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			serialized = new fsData(((Guid)instance).ToString());
			return fsResult.Success;
		}

		// Token: 0x06000A34 RID: 2612 RVA: 0x0002A941 File Offset: 0x00028B41
		public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			if (data.IsString)
			{
				instance = new Guid(data.AsString);
				return fsResult.Success;
			}
			return fsResult.Fail("fsGuidConverter encountered an unknown JSON data type");
		}

		// Token: 0x06000A35 RID: 2613 RVA: 0x0002A970 File Offset: 0x00028B70
		public override object CreateInstance(fsData data, Type storageType)
		{
			return default(Guid);
		}
	}
}
