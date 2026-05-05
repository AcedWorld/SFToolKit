using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000150 RID: 336
	[MovedFrom("Unity.GameCore")]
	public class XNetworkingSecurityInformation
	{
		// Token: 0x17000237 RID: 567
		// (get) Token: 0x0600081A RID: 2074 RVA: 0x0000D88C File Offset: 0x0000BA8C
		// (set) Token: 0x0600081B RID: 2075 RVA: 0x0000D894 File Offset: 0x0000BA94
		public uint EnabledHttpSecurityProtocolFlags { get; set; }

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x0600081C RID: 2076 RVA: 0x0000D89D File Offset: 0x0000BA9D
		// (set) Token: 0x0600081D RID: 2077 RVA: 0x0000D8A5 File Offset: 0x0000BAA5
		public XNetworkingThumbprint[] Thumbprints { get; set; }
	}
}
