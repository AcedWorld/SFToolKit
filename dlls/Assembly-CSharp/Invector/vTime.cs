using System;
using UnityEngine;

namespace Invector
{
	// Token: 0x02000380 RID: 896
	public static class vTime
	{
		// Token: 0x1700035F RID: 863
		// (get) Token: 0x06001236 RID: 4662 RVA: 0x00060E5B File Offset: 0x0005F05B
		private static bool unscaledTime
		{
			get
			{
				return Time.timeScale <= 0f && vTime.useUnscaledTime;
			}
		}

		// Token: 0x17000360 RID: 864
		// (get) Token: 0x06001237 RID: 4663 RVA: 0x00060E70 File Offset: 0x0005F070
		public static float deltaTime
		{
			get
			{
				if (vTime.unscaledTime)
				{
					return Time.unscaledDeltaTime;
				}
				return Time.deltaTime;
			}
		}

		// Token: 0x17000361 RID: 865
		// (get) Token: 0x06001238 RID: 4664 RVA: 0x00060E84 File Offset: 0x0005F084
		public static float fixedDeltaTime
		{
			get
			{
				if (vTime.unscaledTime)
				{
					return Time.fixedUnscaledDeltaTime;
				}
				return Time.fixedDeltaTime;
			}
		}

		// Token: 0x17000362 RID: 866
		// (get) Token: 0x06001239 RID: 4665 RVA: 0x00060E98 File Offset: 0x0005F098
		public static float time
		{
			get
			{
				if (vTime.unscaledTime)
				{
					return Time.unscaledTime;
				}
				return Time.time;
			}
		}

		// Token: 0x0600123A RID: 4666 RVA: 0x00060EAC File Offset: 0x0005F0AC
		public static float GetNormalizedTime(this Animator animator, int layer, int round = 2)
		{
			return (float)Math.Round((double)((animator.IsInTransition(layer) ? animator.GetNextAnimatorStateInfo(layer).normalizedTime : animator.GetCurrentAnimatorStateInfo(layer).normalizedTime) % 1f), round);
		}

		// Token: 0x04001806 RID: 6150
		public static bool useUnscaledTime;
	}
}
