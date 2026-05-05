using System;
using RootMotion.Dynamics;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001B2 RID: 434
	public class RaycastShooter : MonoBehaviour
	{
		// Token: 0x06000BC3 RID: 3011 RVA: 0x00048E3C File Offset: 0x0004703C
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
						this.blood.transform.position = raycastHit.point;
						this.blood.transform.rotation = Quaternion.LookRotation(-ray.direction);
						this.blood.Emit(5);
					}
				}
			}
		}

		// Token: 0x04000BD3 RID: 3027
		public LayerMask layers;

		// Token: 0x04000BD4 RID: 3028
		public float unpin = 10f;

		// Token: 0x04000BD5 RID: 3029
		public float force = 10f;

		// Token: 0x04000BD6 RID: 3030
		public ParticleSystem blood;
	}
}
