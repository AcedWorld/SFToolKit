using System;
using System.Diagnostics;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001C6 RID: 454
	[Conditional("DEBUG")]
	[AttributeUsage(AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = false, Inherited = true)]
	internal sealed class NativeTypeNameAttribute : Attribute
	{
		// Token: 0x06000A95 RID: 2709 RVA: 0x0000FFC3 File Offset: 0x0000E1C3
		public NativeTypeNameAttribute(string name)
		{
			this.Name = name;
		}

		// Token: 0x17000303 RID: 771
		// (get) Token: 0x06000A96 RID: 2710 RVA: 0x0000FFD2 File Offset: 0x0000E1D2
		// (set) Token: 0x06000A97 RID: 2711 RVA: 0x0000FFDA File Offset: 0x0000E1DA
		public string Name { get; private set; }
	}
}
