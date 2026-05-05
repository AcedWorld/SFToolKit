using System;
using UnityEngine;

namespace RootMotion
{
	// Token: 0x02000035 RID: 53
	public static class Warning
	{
		// Token: 0x06000152 RID: 338 RVA: 0x00008698 File Offset: 0x00006898
		public static void Log(string message, Warning.Logger logger, bool logInEditMode = false)
		{
			if (!logInEditMode && !Application.isPlaying)
			{
				return;
			}
			if (Warning.logged)
			{
				return;
			}
			if (logger != null)
			{
				logger(message);
			}
			Warning.logged = true;
		}

		// Token: 0x06000153 RID: 339 RVA: 0x000086BD File Offset: 0x000068BD
		public static void Log(string message, Transform context, bool logInEditMode = false)
		{
			if (!logInEditMode && !Application.isPlaying)
			{
				return;
			}
			if (Warning.logged)
			{
				return;
			}
			Debug.LogWarning(message, context);
			Warning.logged = true;
		}

		// Token: 0x0400011E RID: 286
		public static bool logged;

		// Token: 0x02000036 RID: 54
		// (Invoke) Token: 0x06000155 RID: 341
		public delegate void Logger(string message);
	}
}
