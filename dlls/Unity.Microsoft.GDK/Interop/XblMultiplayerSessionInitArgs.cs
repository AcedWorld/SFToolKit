using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001FE RID: 510
	internal struct XblMultiplayerSessionInitArgs
	{
		// Token: 0x06000DA6 RID: 3494 RVA: 0x0001077C File Offset: 0x0000E97C
		internal XblMultiplayerSessionInitArgs(XblMultiplayerSessionInitArgs publicObject, DisposableCollection disposableCollection)
		{
			this.MaxMembersInSession = publicObject.MaxMembersInSession;
			this.Visibility = publicObject.Visibility;
			this.InitiatorXuids = Converters.ClassArrayToPtr<ulong, ulong>(publicObject.InitiatorXuids, (ulong x, DisposableCollection dc) => x, disposableCollection, out this.InitiatorXuidsCount);
			this.CustomJson = new UTF8StringPtr(publicObject.CustomJson, disposableCollection);
		}

		// Token: 0x040006CA RID: 1738
		internal readonly uint MaxMembersInSession;

		// Token: 0x040006CB RID: 1739
		internal readonly XblMultiplayerSessionVisibility Visibility;

		// Token: 0x040006CC RID: 1740
		private readonly IntPtr InitiatorXuids;

		// Token: 0x040006CD RID: 1741
		internal readonly SizeT InitiatorXuidsCount;

		// Token: 0x040006CE RID: 1742
		internal readonly UTF8StringPtr CustomJson;
	}
}
