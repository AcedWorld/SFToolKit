using System;
using UnityEngine;

namespace Kamgam.UGUIBlurredBackground
{
	// Token: 0x02000004 RID: 4
	public class LimitFps : MonoBehaviour
	{
		// Token: 0x06000006 RID: 6 RVA: 0x00002192 File Offset: 0x00000392
		private void Awake()
		{
			Application.targetFrameRate = this.FrameRate;
		}

		// Token: 0x04000006 RID: 6
		public int FrameRate = 60;
	}
}
