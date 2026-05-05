using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Invector
{
	// Token: 0x020003A6 RID: 934
	[vClassHeader("OBJECT DAMAGE", true, "icon_v2", false, "", iconName = "DamageIcon")]
	public class vObjectDamage : vMonoBehaviour
	{
		// Token: 0x060012BB RID: 4795 RVA: 0x000631C4 File Offset: 0x000613C4
		protected virtual void Start()
		{
			this.targets = new List<Collider>();
			this.disabledTarget = new List<Collider>();
			if (this.collisionMethod == vObjectDamage.CollisionMethod.OnParticleCollision)
			{
				this.part = base.GetComponent<ParticleSystem>();
				this.collisionEvents = new List<ParticleCollisionEvent>();
			}
		}

		// Token: 0x060012BC RID: 4796 RVA: 0x000631FC File Offset: 0x000613FC
		protected virtual void Update()
		{
			if (!base.enabled)
			{
				return;
			}
			if (this.continuousDamage && this.targets != null && this.targets.Count > 0)
			{
				if (this.currentTime > 0f)
				{
					this.currentTime -= Time.deltaTime;
					return;
				}
				this.currentTime = this.damageFrequency;
				foreach (Collider collider in this.targets)
				{
					if (collider != null)
					{
						if (collider.enabled)
						{
							this.ApplyDamage(collider, base.transform.position);
						}
						else
						{
							this.disabledTarget.Add(collider);
						}
					}
				}
				if (this.disabledTarget.Count > 0)
				{
					int num = this.disabledTarget.Count;
					while (num >= 0 && this.disabledTarget.Count != 0)
					{
						try
						{
							if (this.targets.Contains(this.disabledTarget[num]))
							{
								this.targets.Remove(this.disabledTarget[num]);
							}
						}
						catch
						{
							break;
						}
						num--;
					}
				}
				if (this.disabledTarget.Count > 0)
				{
					this.disabledTarget.Clear();
				}
			}
		}

		// Token: 0x060012BD RID: 4797 RVA: 0x00063364 File Offset: 0x00061564
		protected virtual void OnCollisionEnter(Collision hit)
		{
			if (!base.enabled)
			{
				return;
			}
			if (this.collisionMethod != vObjectDamage.CollisionMethod.OnColliderEnter || this.continuousDamage)
			{
				return;
			}
			if (this.CanApplyDamage(hit.gameObject))
			{
				this.ApplyDamage(hit.collider, hit.contacts[0].point);
			}
		}

		// Token: 0x060012BE RID: 4798 RVA: 0x000633B8 File Offset: 0x000615B8
		protected virtual void OnTriggerEnter(Collider hit)
		{
			if (!base.enabled)
			{
				return;
			}
			if (this.collisionMethod != vObjectDamage.CollisionMethod.OnTriggerEnter)
			{
				return;
			}
			if (this.continuousDamage && this.CanApplyDamage(hit.gameObject) && !this.targets.Contains(hit))
			{
				this.targets.Add(hit);
				return;
			}
			if (this.CanApplyDamage(hit.gameObject))
			{
				this.ApplyDamage(hit, base.transform.position);
			}
		}

		// Token: 0x060012BF RID: 4799 RVA: 0x00063428 File Offset: 0x00061628
		private bool CanApplyDamage(GameObject hitObject)
		{
			return ((this.tags.Count == 0 || this.tags.Contains(hitObject.tag)) && this.layerToCollide == 0) || this.layerToCollide.ContainsLayer(hitObject.layer);
		}

		// Token: 0x060012C0 RID: 4800 RVA: 0x00063478 File Offset: 0x00061678
		protected virtual void OnTriggerExit(Collider hit)
		{
			if (!base.enabled)
			{
				return;
			}
			if (this.collisionMethod == vObjectDamage.CollisionMethod.OnColliderEnter && !this.continuousDamage)
			{
				return;
			}
			if (this.CanApplyDamage(hit.gameObject) && this.targets.Contains(hit))
			{
				this.targets.Remove(hit);
			}
		}

		// Token: 0x060012C1 RID: 4801 RVA: 0x000634CC File Offset: 0x000616CC
		protected virtual void OnParticleCollision(GameObject hit)
		{
			if (!base.enabled)
			{
				return;
			}
			if (this.CanApplyDamage(hit))
			{
				if (this.collisionMethod != vObjectDamage.CollisionMethod.OnParticleCollision)
				{
					return;
				}
				int num = this.part.GetCollisionEvents(hit, this.collisionEvents);
				Collider component = hit.GetComponent<Collider>();
				int num2 = 0;
				while ((!this.limitParticleCollisionEvent && num2 < num) || (!this.limitParticleCollisionEvent && num2 < this.maxParticleCollisionEvent))
				{
					if (component)
					{
						if (this.continuousDamage && !this.targets.Contains(component))
						{
							this.targets.Add(component);
						}
						else
						{
							this.ApplyDamage(component, base.transform.position);
						}
					}
					num2++;
				}
			}
		}

		// Token: 0x060012C2 RID: 4802 RVA: 0x00063575 File Offset: 0x00061775
		public virtual void ClearTargets()
		{
			this.targets.Clear();
		}

		// Token: 0x060012C3 RID: 4803 RVA: 0x00063584 File Offset: 0x00061784
		protected virtual void ApplyDamage(Collider target, Vector3 hitPoint)
		{
			this.damage.hitReaction = true;
			this.damage.sender = (this.overrideDamageSender ? this.overrideDamageSender : base.transform);
			this.damage.hitPosition = hitPoint;
			this.damage.receiver = target.transform;
			target.gameObject.ApplyDamage(new vDamage(this.damage));
			this.onHit.Invoke(target);
		}

		// Token: 0x0400188D RID: 6285
		public vDamage damage;

		// Token: 0x0400188E RID: 6286
		[Tooltip("Assign this to set other damage sender")]
		public Transform overrideDamageSender;

		// Token: 0x0400188F RID: 6287
		[Tooltip("List of layers that can be hit, nothing will apply to all layers")]
		public LayerMask layerToCollide;

		// Token: 0x04001890 RID: 6288
		[Tooltip("List of tags that can be hit, nothing will apply to all tags")]
		public vTagMask tags;

		// Token: 0x04001891 RID: 6289
		[Tooltip("Check to use the damage Frequence")]
		public bool continuousDamage;

		// Token: 0x04001892 RID: 6290
		[Tooltip("Apply damage to each end of the frequency in seconds ")]
		public float damageFrequency = 0.5f;

		// Token: 0x04001893 RID: 6291
		private List<Collider> targets;

		// Token: 0x04001894 RID: 6292
		private List<Collider> disabledTarget;

		// Token: 0x04001895 RID: 6293
		private float currentTime;

		// Token: 0x04001896 RID: 6294
		public vObjectDamage.OnHitEvent onHit;

		// Token: 0x04001897 RID: 6295
		public vObjectDamage.CollisionMethod collisionMethod;

		// Token: 0x04001898 RID: 6296
		public ParticleSystem part;

		// Token: 0x04001899 RID: 6297
		public bool limitParticleCollisionEvent;

		// Token: 0x0400189A RID: 6298
		public int maxParticleCollisionEvent = 1;

		// Token: 0x0400189B RID: 6299
		public List<ParticleCollisionEvent> collisionEvents;

		// Token: 0x020003A7 RID: 935
		[Serializable]
		public class OnHitEvent : UnityEvent<Collider>
		{
		}

		// Token: 0x020003A8 RID: 936
		public enum CollisionMethod
		{
			// Token: 0x0400189D RID: 6301
			OnTriggerEnter,
			// Token: 0x0400189E RID: 6302
			OnColliderEnter,
			// Token: 0x0400189F RID: 6303
			OnParticleCollision
		}
	}
}
