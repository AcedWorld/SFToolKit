using System;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x02000007 RID: 7
	public class BufferedLinearInterpolatorQuaternion : BufferedLinearInterpolator<Quaternion>
	{
		// Token: 0x06000012 RID: 18 RVA: 0x00002472 File Offset: 0x00000672
		protected override Quaternion InterpolateUnclamped(Quaternion start, Quaternion end, float time)
		{
			if (this.IsSlerp)
			{
				return Quaternion.Slerp(start, end, time);
			}
			return Quaternion.Lerp(start, end, time);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002472 File Offset: 0x00000672
		protected override Quaternion Interpolate(Quaternion start, Quaternion end, float time)
		{
			if (this.IsSlerp)
			{
				return Quaternion.Slerp(start, end, time);
			}
			return Quaternion.Lerp(start, end, time);
		}

		// Token: 0x04000015 RID: 21
		public bool IsSlerp;
	}
}
