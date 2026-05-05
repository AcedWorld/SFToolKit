using System;
using RootMotion.Dynamics;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001B5 RID: 437
	public class SkeletonDisconnector : MonoBehaviour
	{
		// Token: 0x06000BCD RID: 3021 RVA: 0x000490FC File Offset: 0x000472FC
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.M))
			{
				if (this.disconnectMuscleMode == MuscleDisconnectMode.Sever)
				{
					this.disconnectMuscleMode = MuscleDisconnectMode.Explode;
				}
				else
				{
					this.disconnectMuscleMode = MuscleDisconnectMode.Sever;
				}
			}
			if (Input.GetKeyDown(KeyCode.P))
			{
				this.propMuscle.currentProp = this.prop;
				if (this.puppet.puppetMaster.muscles[0].state.isDisconnected)
				{
					this.skeleton.OnRebuild();
				}
			}
			if (Input.GetKeyDown(KeyCode.D))
			{
				this.propMuscle.currentProp = null;
			}
			if (Input.GetMouseButtonDown(0))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit raycastHit = default(RaycastHit);
				if (Physics.Raycast(ray, out raycastHit, 100f, this.layers))
				{
					MuscleCollisionBroadcaster component = raycastHit.collider.attachedRigidbody.GetComponent<MuscleCollisionBroadcaster>();
					if (component != null)
					{
						component.Hit(this.unpin, ray.direction * this.force, raycastHit.point);
						component.puppetMaster.DisconnectMuscleRecursive(component.muscleIndex, this.disconnectMuscleMode, false);
					}
					else
					{
						raycastHit.collider.attachedRigidbody.AddForceAtPosition(ray.direction * this.force, raycastHit.point);
					}
					this.particles.transform.position = raycastHit.point;
					this.particles.transform.rotation = Quaternion.LookRotation(-ray.direction);
					this.particles.Emit(5);
				}
			}
			if (Input.GetKeyDown(KeyCode.R))
			{
				this.puppet.puppetMaster.ReconnectMuscleRecursive(0);
				this.skeleton.OnRebuild();
			}
		}

		// Token: 0x04000BDD RID: 3037
		public BehaviourPuppet puppet;

		// Token: 0x04000BDE RID: 3038
		public Skeleton skeleton;

		// Token: 0x04000BDF RID: 3039
		public MuscleDisconnectMode disconnectMuscleMode;

		// Token: 0x04000BE0 RID: 3040
		public LayerMask layers;

		// Token: 0x04000BE1 RID: 3041
		public float unpin = 10f;

		// Token: 0x04000BE2 RID: 3042
		public float force = 10f;

		// Token: 0x04000BE3 RID: 3043
		public ParticleSystem particles;

		// Token: 0x04000BE4 RID: 3044
		public PropMuscle propMuscle;

		// Token: 0x04000BE5 RID: 3045
		public PuppetMasterProp prop;
	}
}
