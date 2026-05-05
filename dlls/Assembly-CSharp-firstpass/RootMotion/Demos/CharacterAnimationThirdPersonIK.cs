using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000158 RID: 344
	public class CharacterAnimationThirdPersonIK : CharacterAnimationThirdPerson
	{
		// Token: 0x06000A69 RID: 2665 RVA: 0x000423B1 File Offset: 0x000405B1
		protected override void Start()
		{
			base.Start();
			this.ik = base.GetComponent<FullBodyBipedIK>();
		}

		// Token: 0x06000A6A RID: 2666 RVA: 0x000423C8 File Offset: 0x000405C8
		protected override void LateUpdate()
		{
			base.LateUpdate();
			if (Vector3.Angle(base.transform.up, Vector3.up) <= 0.01f)
			{
				return;
			}
			Quaternion rotation = Quaternion.FromToRotation(base.transform.up, Vector3.up);
			this.RotateEffector(this.ik.solver.bodyEffector, rotation, 0.1f);
			this.RotateEffector(this.ik.solver.leftShoulderEffector, rotation, 0.2f);
			this.RotateEffector(this.ik.solver.rightShoulderEffector, rotation, 0.2f);
			this.RotateEffector(this.ik.solver.leftHandEffector, rotation, 0.1f);
			this.RotateEffector(this.ik.solver.rightHandEffector, rotation, 0.1f);
		}

		// Token: 0x06000A6B RID: 2667 RVA: 0x0004249C File Offset: 0x0004069C
		private void RotateEffector(IKEffector effector, Quaternion rotation, float mlp)
		{
			Vector3 vector = effector.bone.position - base.transform.position;
			Vector3 a = rotation * vector - vector;
			effector.positionOffset += a * mlp;
		}

		// Token: 0x04000A05 RID: 2565
		private FullBodyBipedIK ik;
	}
}
