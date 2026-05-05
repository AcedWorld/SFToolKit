using System;
using System.ComponentModel;
using UnityEngine.Networking.PlayerConnection;

namespace UnityEngine.Diagnostics
{
	// Token: 0x020004AE RID: 1198
	public static class PlayerConnection
	{
		// Token: 0x170007A6 RID: 1958
		// (get) Token: 0x060029D1 RID: 10705 RVA: 0x00046E88 File Offset: 0x00045088
		[Obsolete("Use UnityEngine.Networking.PlayerConnection.PlayerConnection.instance.isConnected instead.")]
		public static bool connected
		{
			get
			{
				return PlayerConnection.instance.isConnected;
			}
		}

		// Token: 0x060029D2 RID: 10706 RVA: 0x00002669 File Offset: 0x00000869
		[Obsolete("PlayerConnection.SendFile is no longer supported.", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void SendFile(string remoteFilePath, byte[] data)
		{
		}
	}
}
