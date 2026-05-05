using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001C5 RID: 453
	internal struct NativeBool
	{
		// Token: 0x06000A93 RID: 2707 RVA: 0x0000FFA8 File Offset: 0x0000E1A8
		internal NativeBool(bool value)
		{
			this.value = (value ? 1 : 0);
		}

		// Token: 0x17000302 RID: 770
		// (get) Token: 0x06000A94 RID: 2708 RVA: 0x0000FFB8 File Offset: 0x0000E1B8
		internal bool Value
		{
			get
			{
				return this.value > 0;
			}
		}

		// Token: 0x040005EC RID: 1516
		private byte value;
	}
}
