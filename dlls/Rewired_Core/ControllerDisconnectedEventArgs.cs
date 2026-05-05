using System;

namespace Rewired
{
	// Token: 0x020000E7 RID: 231
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class ControllerDisconnectedEventArgs : EventArgs
	{
		// Token: 0x0600075C RID: 1884 RVA: 0x0000839C File Offset: 0x0000659C
		public ControllerDisconnectedEventArgs(int A_1)
		{
			this.rewiredId = A_1;
		}

		// Token: 0x0400061B RID: 1563
		public readonly int rewiredId;
	}
}
