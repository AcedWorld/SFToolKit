using System;
using Unity.VisualScripting.FullSerializer;

namespace Unity.VisualScripting
{
	// Token: 0x02000180 RID: 384
	public class UnitCategoryConverter : fsDirectConverter
	{
		// Token: 0x17000393 RID: 915
		// (get) Token: 0x06000A54 RID: 2644 RVA: 0x00012844 File Offset: 0x00010A44
		public override Type ModelType
		{
			get
			{
				return typeof(UnitCategory);
			}
		}

		// Token: 0x06000A55 RID: 2645 RVA: 0x00012850 File Offset: 0x00010A50
		public override object CreateInstance(fsData data, Type storageType)
		{
			return new object();
		}

		// Token: 0x06000A56 RID: 2646 RVA: 0x00012857 File Offset: 0x00010A57
		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			serialized = new fsData(((UnitCategory)instance).fullName);
			return fsResult.Success;
		}

		// Token: 0x06000A57 RID: 2647 RVA: 0x00012870 File Offset: 0x00010A70
		public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			if (!data.IsString)
			{
				return fsResult.Fail("Expected string in " + ((data != null) ? data.ToString() : null));
			}
			instance = new UnitCategory(data.AsString);
			return fsResult.Success;
		}
	}
}
