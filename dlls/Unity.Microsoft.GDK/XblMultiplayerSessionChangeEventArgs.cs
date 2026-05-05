using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000091 RID: 145
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerSessionChangeEventArgs
	{
		// Token: 0x060004D6 RID: 1238 RVA: 0x0000A560 File Offset: 0x00008760
		internal XblMultiplayerSessionChangeEventArgs(XblMultiplayerSessionChangeEventArgs interopStruct)
		{
			this.SessionReference = new XblMultiplayerSessionReference(interopStruct.SessionReference);
			this.Branch = interopStruct.GetBranch();
			this.ChangeNumber = interopStruct.ChangeNumber;
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x060004D7 RID: 1239 RVA: 0x0000A592 File Offset: 0x00008792
		public XblMultiplayerSessionReference SessionReference { get; }

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x060004D8 RID: 1240 RVA: 0x0000A59A File Offset: 0x0000879A
		public string Branch { get; }

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x060004D9 RID: 1241 RVA: 0x0000A5A2 File Offset: 0x000087A2
		public ulong ChangeNumber { get; }
	}
}
