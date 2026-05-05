using System;
using RootMotion.Dynamics;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001B6 RID: 438
	public class SkeletonShooter : MonoBehaviour
	{
		// Token: 0x06000BCF RID: 3023 RVA: 0x000492D0 File Offset: 0x000474D0
		private void Update()
		{
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
						component.puppetMaster.RemoveMuscleRecursive(component.puppetMaster.muscles[component.muscleIndex].joint, true, true, this.removeMuscleMode);
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
				this.puppetMaster.Rebuild();
				this.skeleton.OnRebuild();
			}
		}

		// Token: 0x04000BE6 RID: 3046
		public PuppetMaster puppetMaster;

		// Token: 0x04000BE7 RID: 3047
		public Skeleton skeleton;

		// Token: 0x04000BE8 RID: 3048
		public MuscleRemoveMode removeMuscleMode;

		// Token: 0x04000BE9 RID: 3049
		public LayerMask layers;

		// Token: 0x04000BEA RID: 3050
		public float unpin = 10f;

		// Token: 0x04000BEB RID: 3051
		public float force = 10f;

		// Token: 0x04000BEC RID: 3052
		public ParticleSystem particles;
	}
}
