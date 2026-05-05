using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200004C RID: 76
	public static class Ensure
	{
		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x0000502D File Offset: 0x0000322D
		// (set) Token: 0x060001F8 RID: 504 RVA: 0x00005034 File Offset: 0x00003234
		public static bool IsActive { get; set; }

		// Token: 0x060001F9 RID: 505 RVA: 0x0000503C File Offset: 0x0000323C
		public static void Off()
		{
			Ensure.IsActive = false;
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00005044 File Offset: 0x00003244
		public static void On()
		{
			Ensure.IsActive = true;
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0000504C File Offset: 0x0000324C
		public static EnsureThat That(string paramName)
		{
			Ensure.instance.paramName = paramName;
			return Ensure.instance;
		}

		// Token: 0x060001FC RID: 508 RVA: 0x0000505E File Offset: 0x0000325E
		internal static void OnRuntimeMethodLoad()
		{
			Ensure.IsActive = (Application.isEditor || Debug.isDebugBuild);
		}

		// Token: 0x0400004B RID: 75
		private static readonly EnsureThat instance = new EnsureThat();
	}
}
