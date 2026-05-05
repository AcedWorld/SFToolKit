using System;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x02000006 RID: 6
	public class BufferedLinearInterpolatorFloat : BufferedLinearInterpolator<float>
	{
		// Token: 0x0600000F RID: 15 RVA: 0x00002460 File Offset: 0x00000660
		protected override float InterpolateUnclamped(float start, float end, float time)
		{
			return Mathf.Lerp(start, end, time);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002460 File Offset: 0x00000660
		protected override float Interpolate(float start, float end, float time)
		{
			return Mathf.Lerp(start, end, time);
		}
	}
}
