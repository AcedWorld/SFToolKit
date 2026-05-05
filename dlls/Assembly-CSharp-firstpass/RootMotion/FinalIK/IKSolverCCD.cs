using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000D1 RID: 209
	[Serializable]
	public class IKSolverCCD : IKSolverHeuristic
	{
		// Token: 0x06000692 RID: 1682 RVA: 0x0002790C File Offset: 0x00025B0C
		public void FadeOutBoneWeights()
		{
			if (this.bones.Length < 2)
			{
				return;
			}
			this.bones[0].weight = 1f;
			float num = 1f / (float)(this.bones.Length - 1);
			for (int i = 1; i < this.bones.Length; i++)
			{
				this.bones[i].weight = num * (float)(this.bones.Length - 1 - i);
			}
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x00027978 File Offset: 0x00025B78
		protected override void OnInitiate()
		{
			if (this.firstInitiation || !Application.isPlaying)
			{
				this.IKPosition = this.bones[this.bones.Length - 1].transform.position;
			}
			base.InitiateBones();
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x000279B0 File Offset: 0x00025BB0
		protected override void OnUpdate()
		{
			if (this.IKPositionWeight <= 0f)
			{
				return;
			}
			this.IKPositionWeight = Mathf.Clamp(this.IKPositionWeight, 0f, 1f);
			if (this.target != null)
			{
				this.IKPosition = this.target.position;
			}
			if (this.XY)
			{
				this.IKPosition.z = this.bones[0].transform.position.z;
			}
			Vector3 vector = (this.maxIterations > 1) ? base.GetSingularityOffset() : Vector3.zero;
			int num = 0;
			while (num < this.maxIterations && (!(vector == Vector3.zero) || num < 1 || this.tolerance <= 0f || base.positionOffset >= this.tolerance * this.tolerance))
			{
				this.lastLocalDirection = this.localDirection;
				if (this.OnPreIteration != null)
				{
					this.OnPreIteration(num);
				}
				this.Solve(this.IKPosition + ((num == 0) ? vector : Vector3.zero));
				num++;
			}
			this.lastLocalDirection = this.localDirection;
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x00027AD4 File Offset: 0x00025CD4
		protected void Solve(Vector3 targetPosition)
		{
			if (this.XY)
			{
				for (int i = this.bones.Length - 2; i > -1; i--)
				{
					float num = this.bones[i].weight * this.IKPositionWeight;
					if (num > 0f)
					{
						Vector3 vector = this.bones[this.bones.Length - 1].transform.position - this.bones[i].transform.position;
						Vector3 vector2 = targetPosition - this.bones[i].transform.position;
						float current = Mathf.Atan2(vector.x, vector.y) * 57.29578f;
						float target = Mathf.Atan2(vector2.x, vector2.y) * 57.29578f;
						this.bones[i].transform.rotation = Quaternion.AngleAxis(Mathf.DeltaAngle(current, target) * num, Vector3.back) * this.bones[i].transform.rotation;
					}
					if (this.useRotationLimits && this.bones[i].rotationLimit != null)
					{
						this.bones[i].rotationLimit.Apply();
					}
				}
				return;
			}
			for (int j = this.bones.Length - 2; j > -1; j--)
			{
				float num2 = this.bones[j].weight * this.IKPositionWeight;
				if (num2 > 0f)
				{
					Vector3 fromDirection = this.bones[this.bones.Length - 1].transform.position - this.bones[j].transform.position;
					Vector3 toDirection = targetPosition - this.bones[j].transform.position;
					Quaternion quaternion = Quaternion.FromToRotation(fromDirection, toDirection) * this.bones[j].transform.rotation;
					if (num2 >= 1f)
					{
						this.bones[j].transform.rotation = quaternion;
					}
					else
					{
						this.bones[j].transform.rotation = Quaternion.Lerp(this.bones[j].transform.rotation, quaternion, num2);
					}
				}
				if (this.useRotationLimits && this.bones[j].rotationLimit != null)
				{
					this.bones[j].rotationLimit.Apply();
				}
			}
		}

		// Token: 0x040005DF RID: 1503
		public IKSolver.IterationDelegate OnPreIteration;
	}
}
