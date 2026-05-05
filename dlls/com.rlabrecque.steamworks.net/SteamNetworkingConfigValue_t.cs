using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020001AC RID: 428
	[Serializable]
	public struct SteamNetworkingConfigValue_t
	{
		// Token: 0x04000A7E RID: 2686
		public ESteamNetworkingConfigValue m_eValue;

		// Token: 0x04000A7F RID: 2687
		public ESteamNetworkingConfigDataType m_eDataType;

		// Token: 0x04000A80 RID: 2688
		public SteamNetworkingConfigValue_t.OptionValue m_val;

		// Token: 0x020001ED RID: 493
		[StructLayout(LayoutKind.Explicit)]
		public struct OptionValue
		{
			// Token: 0x04000AE7 RID: 2791
			[FieldOffset(0)]
			public int m_int32;

			// Token: 0x04000AE8 RID: 2792
			[FieldOffset(0)]
			public long m_int64;

			// Token: 0x04000AE9 RID: 2793
			[FieldOffset(0)]
			public float m_float;

			// Token: 0x04000AEA RID: 2794
			[FieldOffset(0)]
			public IntPtr m_string;

			// Token: 0x04000AEB RID: 2795
			[FieldOffset(0)]
			public IntPtr m_functionPtr;
		}
	}
}
