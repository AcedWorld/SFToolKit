using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	// Token: 0x020004C7 RID: 1223
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct Locker : IDisposable
	{
		// Token: 0x06003135 RID: 12597 RVA: 0x00025B8D File Offset: 0x00023D8D
		public Locker(object A_1)
		{
			this.onYrLQRmXSXWQuzbiHOvdTatxOFB = A_1;
			if (A_1 != null)
			{
				Monitor.Enter(A_1);
			}
		}

		// Token: 0x06003136 RID: 12598 RVA: 0x00025B9F File Offset: 0x00023D9F
		public void Dispose()
		{
			if (this.onYrLQRmXSXWQuzbiHOvdTatxOFB == null)
			{
				return;
			}
			Monitor.Exit(this.onYrLQRmXSXWQuzbiHOvdTatxOFB);
			this.onYrLQRmXSXWQuzbiHOvdTatxOFB = null;
		}

		// Token: 0x04001AF7 RID: 6903
		private object onYrLQRmXSXWQuzbiHOvdTatxOFB;
	}
}
