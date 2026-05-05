using System;
using UnityEngine;

namespace Cinemachine.Utility
{
	// Token: 0x02000063 RID: 99
	internal class GaussianWindow1D_CameraRotation : GaussianWindow1d<Vector2>
	{
		// Token: 0x060003CE RID: 974 RVA: 0x00017453 File Offset: 0x00015653
		public GaussianWindow1D_CameraRotation(float sigma, int maxKernelRadius = 10) : base(sigma, maxKernelRadius)
		{
		}

		// Token: 0x060003CF RID: 975 RVA: 0x00017460 File Offset: 0x00015660
		protected override Vector2 Compute(int windowPos)
		{
			Vector2 vector = Vector2.zero;
			Vector2 vector2 = this.mData[this.mCurrentPos];
			for (int i = 0; i < base.KernelSize; i++)
			{
				Vector2 vector3 = this.mData[windowPos] - vector2;
				if (vector3.y > 180f)
				{
					vector3.y -= 360f;
				}
				if (vector3.y < -180f)
				{
					vector3.y += 360f;
				}
				vector += vector3 * this.mKernel[i];
				if (++windowPos == base.KernelSize)
				{
					windowPos = 0;
				}
			}
			return vector2 + vector;
		}
	}
}
