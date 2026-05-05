using System;
using Unity.VisualScripting.FullSerializer;

namespace Unity.VisualScripting
{
	// Token: 0x02000130 RID: 304
	public class NamespaceConverter : fsDirectConverter
	{
		// Token: 0x17000189 RID: 393
		// (get) Token: 0x06000846 RID: 2118 RVA: 0x0002555E File Offset: 0x0002375E
		public override Type ModelType
		{
			get
			{
				return typeof(Namespace);
			}
		}

		// Token: 0x06000847 RID: 2119 RVA: 0x0002556A File Offset: 0x0002376A
		public override object CreateInstance(fsData data, Type storageType)
		{
			return new object();
		}

		// Token: 0x06000848 RID: 2120 RVA: 0x00025571 File Offset: 0x00023771
		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			serialized = new fsData(((Namespace)instance).FullName);
			return fsResult.Success;
		}

		// Token: 0x06000849 RID: 2121 RVA: 0x0002558A File Offset: 0x0002378A
		public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			if (!data.IsString)
			{
				return fsResult.Fail("Expected string in " + ((data != null) ? data.ToString() : null));
			}
			instance = Namespace.FromFullName(data.AsString);
			return fsResult.Success;
		}
	}
}
