using System;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001C7 RID: 455
	public class SlowMo : MonoBehaviour
	{
		// Token: 0x06000C21 RID: 3105 RVA: 0x0004B7B4 File Offset: 0x000499B4
		private void Update()
		{
			Time.timeScale = (this.IsSlowMotion() ? this.slowMoTimeScale : 1f);
		}

		// Token: 0x06000C22 RID: 3106 RVA: 0x0004B7D0 File Offset: 0x000499D0
		private bool IsSlowMotion()
		{
			if (this.mouse0 && Input.GetMouseButton(0))
			{
				return true;
			}
			if (this.mouse1 && Input.GetMouseButton(1))
			{
				return true;
			}
			for (int i = 0; i < this.keyCodes.Length; i++)
			{
				if (Input.GetKey(this.keyCodes[i]))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x04000C80 RID: 3200
		public KeyCode[] keyCodes;

		// Token: 0x04000C81 RID: 3201
		public bool mouse0;

		// Token: 0x04000C82 RID: 3202
		public bool mouse1;

		// Token: 0x04000C83 RID: 3203
		public float slowMoTimeScale = 0.3f;
	}
}
