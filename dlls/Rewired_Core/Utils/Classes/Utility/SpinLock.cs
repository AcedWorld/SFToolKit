using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	// Token: 0x020004C9 RID: 1225
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class SpinLock : IDisposable
	{
		// Token: 0x0600313D RID: 12605 RVA: 0x00025C42 File Offset: 0x00023E42
		void IDisposable.Dispose()
		{
			this.LtLdkXTPBjTrvbvSVjhKpbimhFqO();
		}

		// Token: 0x0600313E RID: 12606 RVA: 0x00025C4A File Offset: 0x00023E4A
		private void xPEVlkLJZgIyqGradtKHOEJOUYmI()
		{
			while (Interlocked.Exchange(ref this.ndPvOadBSbnNkakCESbJcgjkYMtB, 1) != 0)
			{
				Thread.SpinWait(1);
			}
		}

		// Token: 0x0600313F RID: 12607 RVA: 0x00025C62 File Offset: 0x00023E62
		private void LtLdkXTPBjTrvbvSVjhKpbimhFqO()
		{
			Interlocked.Exchange(ref this.ndPvOadBSbnNkakCESbJcgjkYMtB, 0);
		}

		// Token: 0x06003140 RID: 12608 RVA: 0x00025C71 File Offset: 0x00023E71
		public SpinLock Lock()
		{
			this.xPEVlkLJZgIyqGradtKHOEJOUYmI();
			return this;
		}

		// Token: 0x04001AFB RID: 6907
		private const int lVbDLkhJmQdgwRywYoDwHqJSfJGf = 1;

		// Token: 0x04001AFC RID: 6908
		private const int NxyBkKnIrgJBNZDBJCilInLSwmfg = 0;

		// Token: 0x04001AFD RID: 6909
		private int ndPvOadBSbnNkakCESbJcgjkYMtB;
	}
}
