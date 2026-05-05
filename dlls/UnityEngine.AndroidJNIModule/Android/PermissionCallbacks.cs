using System;
using System.Diagnostics;

namespace UnityEngine.Android
{
	// Token: 0x0200001E RID: 30
	public class PermissionCallbacks : AndroidJavaProxy
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000250 RID: 592 RVA: 0x00009D58 File Offset: 0x00007F58
		// (remove) Token: 0x06000251 RID: 593 RVA: 0x00009D90 File Offset: 0x00007F90
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event Action<string> PermissionGranted;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000252 RID: 594 RVA: 0x00009DC8 File Offset: 0x00007FC8
		// (remove) Token: 0x06000253 RID: 595 RVA: 0x00009E00 File Offset: 0x00008000
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event Action<string> PermissionDenied;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000254 RID: 596 RVA: 0x00009E38 File Offset: 0x00008038
		// (remove) Token: 0x06000255 RID: 597 RVA: 0x00009E70 File Offset: 0x00008070
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event Action<string> PermissionDeniedAndDontAskAgain;

		// Token: 0x06000256 RID: 598 RVA: 0x00009EA5 File Offset: 0x000080A5
		public PermissionCallbacks() : base("com.unity3d.player.IPermissionRequestCallbacks")
		{
		}

		// Token: 0x06000257 RID: 599 RVA: 0x00009EB4 File Offset: 0x000080B4
		private void onPermissionGranted(string permissionName)
		{
			Action<string> permissionGranted = this.PermissionGranted;
			if (permissionGranted != null)
			{
				permissionGranted(permissionName);
			}
		}

		// Token: 0x06000258 RID: 600 RVA: 0x00009ECA File Offset: 0x000080CA
		private void onPermissionDenied(string permissionName)
		{
			Action<string> permissionDenied = this.PermissionDenied;
			if (permissionDenied != null)
			{
				permissionDenied(permissionName);
			}
		}

		// Token: 0x06000259 RID: 601 RVA: 0x00009EE0 File Offset: 0x000080E0
		private void onPermissionDeniedAndDontAskAgain(string permissionName)
		{
			bool flag = this.PermissionDeniedAndDontAskAgain != null;
			if (flag)
			{
				this.PermissionDeniedAndDontAskAgain(permissionName);
			}
			else
			{
				Action<string> permissionDenied = this.PermissionDenied;
				if (permissionDenied != null)
				{
					permissionDenied(permissionName);
				}
			}
		}
	}
}
