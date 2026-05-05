using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200014F RID: 335
	[MovedFrom("Unity.GameCore")]
	public class XNetworkingThumbprint
	{
		// Token: 0x17000235 RID: 565
		// (get) Token: 0x06000815 RID: 2069 RVA: 0x0000D862 File Offset: 0x0000BA62
		// (set) Token: 0x06000816 RID: 2070 RVA: 0x0000D86A File Offset: 0x0000BA6A
		public XNetworkingThumbprintType ThumbprintType { get; set; }

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x06000817 RID: 2071 RVA: 0x0000D873 File Offset: 0x0000BA73
		// (set) Token: 0x06000818 RID: 2072 RVA: 0x0000D87B File Offset: 0x0000BA7B
		public byte[] ThumbprintBuffer { get; set; }
	}
}
