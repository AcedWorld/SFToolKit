using System;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x02000008 RID: 8
	public class BufferedLinearInterpolatorVector3 : BufferedLinearInterpolator<Vector3>
	{
		// Token: 0x06000015 RID: 21 RVA: 0x00002495 File Offset: 0x00000695
		protected override Vector3 InterpolateUnclamped(Vector3 start, Vector3 end, float time)
		{
			if (this.IsSlerp)
			{
				return Vector3.Slerp(start, end, time);
			}
			return Vector3.Lerp(start, end, time);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002495 File Offset: 0x00000695
		protected override Vector3 Interpolate(Vector3 start, Vector3 end, float time)
		{
			if (this.IsSlerp)
			{
				return Vector3.Slerp(start, end, time);
			}
			return Vector3.Lerp(start, end, time);
		}

		// Token: 0x04000016 RID: 22
		public bool IsSlerp;
	}
}
