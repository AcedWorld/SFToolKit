using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000171 RID: 369
	public struct MatchMakingKeyValuePair_t
	{
		// Token: 0x0600087B RID: 2171 RVA: 0x0000C13B File Offset: 0x0000A33B
		private MatchMakingKeyValuePair_t(string strKey, string strValue)
		{
			this.m_szKey = strKey;
			this.m_szValue = strValue;
		}

		// Token: 0x040009BB RID: 2491
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string m_szKey;

		// Token: 0x040009BC RID: 2492
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string m_szValue;
	}
}
