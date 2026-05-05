using System;
using RootMotion.Dynamics;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001A0 RID: 416
	[RequireComponent(typeof(ParticleSystem))]
	public class FXCollisionBlood : MonoBehaviour
	{
		// Token: 0x06000B81 RID: 2945 RVA: 0x00047C83 File Offset: 0x00045E83
		private void Start()
		{
			this.particles = base.GetComponent<ParticleSystem>();
			BehaviourPuppet behaviourPuppet = this.puppet;
			behaviourPuppet.OnCollisionImpulse = (BehaviourPuppet.CollisionImpulseDelegate)Delegate.Combine(behaviourPuppet.OnCollisionImpulse, new BehaviourPuppet.CollisionImpulseDelegate(this.OnCollisionImpulse));
		}

		// Token: 0x06000B82 RID: 2946 RVA: 0x00047CB8 File Offset: 0x00045EB8
		private void OnCollisionImpulse(MuscleCollision m, float impulse)
		{
			if (m.collision.contacts.Length == 0)
			{
				return;
			}
			if (impulse < this.minCollisionImpulse)
			{
				return;
			}
			if (this.puppet.puppetMaster.muscles[m.muscleIndex].props.group == Muscle.Group.Prop && (m.collision.collider.attachedRigidbody == null || m.collision.collider.attachedRigidbody.isKinematic))
			{
				return;
			}
			base.transform.position = m.collision.GetContact(0).point;
			base.transform.rotation = Quaternion.LookRotation(m.collision.contacts[0].normal);
			this.particles.Emit(Mathf.Min(this.emission + (int)(this.emissionImpulseAdd * impulse), this.maxEmission));
		}

		// Token: 0x06000B83 RID: 2947 RVA: 0x00047D9D File Offset: 0x00045F9D
		private void OnDestroy()
		{
			if (this.puppet != null)
			{
				BehaviourPuppet behaviourPuppet = this.puppet;
				behaviourPuppet.OnCollisionImpulse = (BehaviourPuppet.CollisionImpulseDelegate)Delegate.Remove(behaviourPuppet.OnCollisionImpulse, new BehaviourPuppet.CollisionImpulseDelegate(this.OnCollisionImpulse));
			}
		}

		// Token: 0x04000B74 RID: 2932
		public BehaviourPuppet puppet;

		// Token: 0x04000B75 RID: 2933
		public float minCollisionImpulse = 100f;

		// Token: 0x04000B76 RID: 2934
		public int emission = 2;

		// Token: 0x04000B77 RID: 2935
		public float emissionImpulseAdd = 0.01f;

		// Token: 0x04000B78 RID: 2936
		public int maxEmission = 7;

		// Token: 0x04000B79 RID: 2937
		private ParticleSystem particles;
	}
}
