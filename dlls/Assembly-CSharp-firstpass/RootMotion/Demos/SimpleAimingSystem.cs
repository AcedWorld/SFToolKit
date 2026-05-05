using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x0200014B RID: 331
	public class SimpleAimingSystem : MonoBehaviour
	{
		// Token: 0x06000A2E RID: 2606 RVA: 0x00040614 File Offset: 0x0003E814
		private void Start()
		{
			this.aim.enabled = false;
			this.lookAt.enabled = false;
		}

		// Token: 0x06000A2F RID: 2607 RVA: 0x0004062E File Offset: 0x0003E82E
		private void LateUpdate()
		{
			this.Pose();
			this.aim.solver.Update();
			if (this.lookAt != null)
			{
				this.lookAt.solver.Update();
			}
		}

		// Token: 0x06000A30 RID: 2608 RVA: 0x00040664 File Offset: 0x0003E864
		private void Pose()
		{
			this.LimitAimTarget();
			Vector3 direction = this.aim.solver.IKPosition - this.aim.solver.bones[0].transform.position;
			Vector3 localDirection = base.transform.InverseTransformDirection(direction);
			this.aimPose = this.aimPoser.GetPose(localDirection);
			if (this.aimPose != this.lastPose)
			{
				this.aimPoser.SetPoseActive(this.aimPose);
				this.lastPose = this.aimPose;
			}
			foreach (AimPoser.Pose pose in this.aimPoser.poses)
			{
				if (pose == this.aimPose)
				{
					this.DirectCrossFade(pose.name, 1f);
				}
				else
				{
					this.DirectCrossFade(pose.name, 0f);
				}
			}
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x00040744 File Offset: 0x0003E944
		private void LimitAimTarget()
		{
			Vector3 position = this.aim.solver.bones[0].transform.position;
			Vector3 b = this.aim.solver.IKPosition - position;
			b = b.normalized * Mathf.Max(b.magnitude, this.minAimDistance);
			this.aim.solver.IKPosition = position + b;
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x000407BC File Offset: 0x0003E9BC
		private void DirectCrossFade(string state, float target)
		{
			float value = Mathf.MoveTowards(this.animator.GetFloat(state), target, Time.deltaTime * (1f / this.crossfadeTime));
			this.animator.SetFloat(state, value);
		}

		// Token: 0x0400098E RID: 2446
		[Tooltip("AimPoser is a tool that returns an animation name based on direction.")]
		public AimPoser aimPoser;

		// Token: 0x0400098F RID: 2447
		[Tooltip("Reference to the AimIK component.")]
		public AimIK aim;

		// Token: 0x04000990 RID: 2448
		[Tooltip("Reference to the LookAt component (only used for the head in this instance).")]
		public LookAtIK lookAt;

		// Token: 0x04000991 RID: 2449
		[Tooltip("Reference to the Animator component.")]
		public Animator animator;

		// Token: 0x04000992 RID: 2450
		[Tooltip("Time of cross-fading from pose to pose.")]
		public float crossfadeTime = 0.2f;

		// Token: 0x04000993 RID: 2451
		[Tooltip("Will keep the aim target at a distance.")]
		public float minAimDistance = 0.5f;

		// Token: 0x04000994 RID: 2452
		private AimPoser.Pose aimPose;

		// Token: 0x04000995 RID: 2453
		private AimPoser.Pose lastPose;
	}
}
