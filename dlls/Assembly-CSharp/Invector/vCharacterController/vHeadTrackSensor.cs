using System;
using UnityEngine;

namespace Invector.vCharacterController
{
	// Token: 0x02000404 RID: 1028
	[RequireComponent(typeof(SphereCollider))]
	[RequireComponent(typeof(Rigidbody))]
	public class vHeadTrackSensor : MonoBehaviour
	{
		// Token: 0x0600151A RID: 5402 RVA: 0x0006E994 File Offset: 0x0006CB94
		private void OnDrawGizmos()
		{
			if (Application.isPlaying && this.sphere && this.headTrack)
			{
				this.sphere.radius = this.headTrack.distanceToDetect;
			}
		}

		// Token: 0x0600151B RID: 5403 RVA: 0x0006E9D0 File Offset: 0x0006CBD0
		private void Start()
		{
			Rigidbody component = base.GetComponent<Rigidbody>();
			this.sphere = base.GetComponent<SphereCollider>();
			this.sphere.isTrigger = true;
			component.useGravity = false;
			component.isKinematic = true;
			component.constraints = RigidbodyConstraints.FreezeAll;
			if (this.headTrack)
			{
				this.sphere.radius = this.headTrack.distanceToDetect;
			}
		}

		// Token: 0x0600151C RID: 5404 RVA: 0x0006EA33 File Offset: 0x0006CC33
		private void OnTriggerEnter(Collider other)
		{
			if (this.headTrack != null)
			{
				this.headTrack.OnDetect(other);
			}
		}

		// Token: 0x0600151D RID: 5405 RVA: 0x0006EA4F File Offset: 0x0006CC4F
		private void OnTriggerExit(Collider other)
		{
			if (this.headTrack != null)
			{
				this.headTrack.OnLost(other);
			}
		}

		// Token: 0x04001AF3 RID: 6899
		[HideInInspector]
		public vHeadTrack headTrack;

		// Token: 0x04001AF4 RID: 6900
		public SphereCollider sphere;
	}
}
