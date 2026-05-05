using System;
using UnityEngine;

namespace Invector
{
	// Token: 0x02000381 RID: 897
	[vClassHeader("Frame Limiter", false, "icon_v2", false, "")]
	public class vFrameLimiter : vMonoBehaviour
	{
		// Token: 0x0600123B RID: 4667 RVA: 0x00060EF0 File Offset: 0x0005F0F0
		private void Awake()
		{
			Application.targetFrameRate = this.desiredFPS;
			QualitySettings.vSyncCount = 0;
		}

		// Token: 0x04001807 RID: 6151
		public int desiredFPS = 60;
	}
}
