using System;
using UnityEngine;

namespace Cinemachine.Utility
{
	// Token: 0x02000064 RID: 100
	public class PositionPredictor
	{
		// Token: 0x060003D0 RID: 976 RVA: 0x00017510 File Offset: 0x00015710
		public bool IsEmpty()
		{
			return !this.m_HavePos;
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x0001751B File Offset: 0x0001571B
		public void ApplyTransformDelta(Vector3 positionDelta)
		{
			this.m_Pos += positionDelta;
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x0001752F File Offset: 0x0001572F
		public void Reset()
		{
			this.m_HavePos = false;
			this.m_SmoothDampVelocity = Vector3.zero;
			this.m_Velocity = Vector3.zero;
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x00017550 File Offset: 0x00015750
		public void AddPosition(Vector3 pos, float deltaTime, float lookaheadTime)
		{
			if (deltaTime < 0f)
			{
				this.Reset();
			}
			if (this.m_HavePos && deltaTime > 0.0001f)
			{
				Vector3 target = (pos - this.m_Pos) / deltaTime;
				bool flag = target.sqrMagnitude < this.m_Velocity.sqrMagnitude;
				this.m_Velocity = Vector3.SmoothDamp(this.m_Velocity, target, ref this.m_SmoothDampVelocity, this.Smoothing / (float)(flag ? 30 : 10), float.PositiveInfinity, deltaTime);
			}
			this.m_Pos = pos;
			this.m_HavePos = true;
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x000175E0 File Offset: 0x000157E0
		public Vector3 PredictPositionDelta(float lookaheadTime)
		{
			return this.m_Velocity * lookaheadTime;
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x000175EE File Offset: 0x000157EE
		public Vector3 PredictPosition(float lookaheadTime)
		{
			return this.m_Pos + this.PredictPositionDelta(lookaheadTime);
		}

		// Token: 0x04000293 RID: 659
		private Vector3 m_Velocity;

		// Token: 0x04000294 RID: 660
		private Vector3 m_SmoothDampVelocity;

		// Token: 0x04000295 RID: 661
		private Vector3 m_Pos;

		// Token: 0x04000296 RID: 662
		private bool m_HavePos;

		// Token: 0x04000297 RID: 663
		public float Smoothing;
	}
}
