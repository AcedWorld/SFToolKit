using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000BE RID: 190
	public static class PlatformUtility
	{
		// Token: 0x060004B7 RID: 1207 RVA: 0x0000A5FA File Offset: 0x000087FA
		private static bool CheckJitSupport()
		{
			return false;
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x0000A5FD File Offset: 0x000087FD
		public static bool IsEditor(this RuntimePlatform platform)
		{
			return platform == RuntimePlatform.WindowsEditor || platform == RuntimePlatform.OSXEditor || platform == RuntimePlatform.LinuxEditor;
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x0000A60D File Offset: 0x0000880D
		public static bool IsStandalone(this RuntimePlatform platform)
		{
			return platform == RuntimePlatform.WindowsPlayer || platform == RuntimePlatform.OSXPlayer || platform == RuntimePlatform.LinuxPlayer;
		}

		// Token: 0x04000103 RID: 259
		public static readonly bool supportsJit = PlatformUtility.CheckJitSupport();
	}
}
