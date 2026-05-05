using System;
using System.Collections.Generic;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x0200005B RID: 91
	public class ParticleCollisionHandler : MonoBehaviour
	{
		// Token: 0x0600028F RID: 655 RVA: 0x0000E808 File Offset: 0x0000CA08
		private void Start()
		{
			this.p = base.GetComponent<ParticleSystem>();
			if (!this.p.collision.sendCollisionMessages)
			{
				Debug.LogError("ParticleSystems with ParticleCollisionHandler need to have 'Send Collision Messages' enabled in the Collision module.");
			}
			if (this.p.collision.colliderForce <= 0f)
			{
				Debug.LogError("ParticleSystems with ParticleCollisionHandler need to have 'Collider Force' > 0f in the Collision module.");
			}
			if (this.p.collision.collidesWith == 0)
			{
				Debug.LogError("ParticleSystems with ParticleCollisionHandler need to have 'Collides With' LayerMask set in the Collision module.");
			}
		}

		// Token: 0x06000290 RID: 656 RVA: 0x0000E888 File Offset: 0x0000CA88
		private void OnParticleCollision(GameObject other)
		{
			if (!base.enabled)
			{
				return;
			}
			if (!LayerMaskExtensions.Contains(this.ragdollLayers, other.layer))
			{
				return;
			}
			Collider component = other.GetComponent<Collider>();
			if (component.attachedRigidbody == null)
			{
				return;
			}
			MuscleCollisionBroadcaster component2 = component.attachedRigidbody.GetComponent<MuscleCollisionBroadcaster>();
			if (component2 == null)
			{
				return;
			}
			int collisionEvents = this.p.GetCollisionEvents(other, this.particleCollisionEvents);
			for (int i = 0; i < collisionEvents; i++)
			{
				Vector3 intersection = this.particleCollisionEvents[i].intersection;
				float unPin = this.particleCollisionEvents[i].velocity.magnitude * this.p.collision.colliderForce * this.unpin;
				component2.Hit(unPin, Vector3.zero, intersection);
			}
		}

		// Token: 0x04000275 RID: 629
		[Tooltip("PuppetMaster ragdoll layers to hit.")]
		public LayerMask ragdollLayers;

		// Token: 0x04000276 RID: 630
		[Tooltip("Multiplier for unpinning the puppet on particle hit (velocity.magnitude * colliderForce * unpin).")]
		public float unpin = 0.02f;

		// Token: 0x04000277 RID: 631
		private ParticleSystem p;

		// Token: 0x04000278 RID: 632
		private List<ParticleCollisionEvent> particleCollisionEvents = new List<ParticleCollisionEvent>();
	}
}
