using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x0200015F RID: 351
	public class FBIKBoxing : MonoBehaviour
	{
		// Token: 0x06000A81 RID: 2689 RVA: 0x00042CDE File Offset: 0x00040EDE
		private void Start()
		{
			this.animator = base.GetComponent<Animator>();
		}

		// Token: 0x06000A82 RID: 2690 RVA: 0x00042CEC File Offset: 0x00040EEC
		private void LateUpdate()
		{
			float @float = this.animator.GetFloat("HitWeight");
			this.ik.solver.GetEffector(this.effector).position = this.target.position;
			this.ik.solver.GetEffector(this.effector).positionWeight = @float * this.weight;
			if (this.aim != null)
			{
				this.aim.solver.transform.LookAt(this.pin.position);
				this.aim.solver.IKPosition = this.target.position;
				this.aim.solver.IKPositionWeight = this.aimWeight.Evaluate(@float) * this.weight;
			}
		}

		// Token: 0x04000A2B RID: 2603
		[Tooltip("The target we want to hit")]
		public Transform target;

		// Token: 0x04000A2C RID: 2604
		[Tooltip("The pin Transform is used to reference the exact hit point in the animation (used by AimIK to aim the upper body to follow the target).In Legacy and Generic modes you can just create and position a reference point in your animating software and include it in the FBX. Then in Unity if you added a GameObject with the exact same name under the character's root, it would be animated to the required position.In Humanoid mode however, Mecanim loses track of any Transform that does not belong to the avatar, so in this case the pin point has to be manually set inside the Unity Editor.")]
		public Transform pin;

		// Token: 0x04000A2D RID: 2605
		[Tooltip("The Full Body Biped IK component")]
		public FullBodyBipedIK ik;

		// Token: 0x04000A2E RID: 2606
		[Tooltip("The Aim IK component. Aim IK is ust used for following the target slightly with the body.")]
		public AimIK aim;

		// Token: 0x04000A2F RID: 2607
		[Tooltip("The master weight")]
		public float weight;

		// Token: 0x04000A30 RID: 2608
		[Tooltip("The effector type of the punching hand")]
		public FullBodyBipedEffector effector;

		// Token: 0x04000A31 RID: 2609
		[Tooltip("Weight of aiming the body to follow the target")]
		public AnimationCurve aimWeight;

		// Token: 0x04000A32 RID: 2610
		private Animator animator;
	}
}
