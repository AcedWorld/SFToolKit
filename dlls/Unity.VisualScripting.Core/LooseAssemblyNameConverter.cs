using System;
using Unity.VisualScripting.FullSerializer;

namespace Unity.VisualScripting
{
	// Token: 0x0200012F RID: 303
	public class LooseAssemblyNameConverter : fsDirectConverter
	{
		// Token: 0x17000188 RID: 392
		// (get) Token: 0x06000841 RID: 2113 RVA: 0x000254EC File Offset: 0x000236EC
		public override Type ModelType
		{
			get
			{
				return typeof(LooseAssemblyName);
			}
		}

		// Token: 0x06000842 RID: 2114 RVA: 0x000254F8 File Offset: 0x000236F8
		public override object CreateInstance(fsData data, Type storageType)
		{
			return new object();
		}

		// Token: 0x06000843 RID: 2115 RVA: 0x000254FF File Offset: 0x000236FF
		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			serialized = new fsData(((LooseAssemblyName)instance).name);
			return fsResult.Success;
		}

		// Token: 0x06000844 RID: 2116 RVA: 0x00025518 File Offset: 0x00023718
		public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			if (!data.IsString)
			{
				return fsResult.Fail("Expected string in " + ((data != null) ? data.ToString() : null));
			}
			instance = new LooseAssemblyName(data.AsString);
			return fsResult.Success;
		}
	}
}
