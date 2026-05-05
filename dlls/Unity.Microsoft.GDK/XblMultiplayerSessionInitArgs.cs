using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000095 RID: 149
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerSessionInitArgs
	{
		// Token: 0x170000DE RID: 222
		// (get) Token: 0x060004E1 RID: 1249 RVA: 0x0000A626 File Offset: 0x00008826
		// (set) Token: 0x060004E2 RID: 1250 RVA: 0x0000A62E File Offset: 0x0000882E
		public uint MaxMembersInSession { get; set; }

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x060004E3 RID: 1251 RVA: 0x0000A637 File Offset: 0x00008837
		// (set) Token: 0x060004E4 RID: 1252 RVA: 0x0000A63F File Offset: 0x0000883F
		public XblMultiplayerSessionVisibility Visibility { get; set; }

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x060004E5 RID: 1253 RVA: 0x0000A648 File Offset: 0x00008848
		// (set) Token: 0x060004E6 RID: 1254 RVA: 0x0000A650 File Offset: 0x00008850
		public ulong[] InitiatorXuids { get; set; }

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060004E7 RID: 1255 RVA: 0x0000A659 File Offset: 0x00008859
		// (set) Token: 0x060004E8 RID: 1256 RVA: 0x0000A661 File Offset: 0x00008861
		public string CustomJson { get; set; }
	}
}
