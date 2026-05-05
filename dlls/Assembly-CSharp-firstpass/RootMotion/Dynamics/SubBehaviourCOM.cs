using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x0200004E RID: 78
	[Serializable]
	public class SubBehaviourCOM : SubBehaviourBase
	{
		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000215 RID: 533 RVA: 0x0000BDB5 File Offset: 0x00009FB5
		// (set) Token: 0x06000216 RID: 534 RVA: 0x0000BDBD File Offset: 0x00009FBD
		public Vector3 position { get; private set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000217 RID: 535 RVA: 0x0000BDC6 File Offset: 0x00009FC6
		// (set) Token: 0x06000218 RID: 536 RVA: 0x0000BDCE File Offset: 0x00009FCE
		public Vector3 direction { get; private set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000219 RID: 537 RVA: 0x0000BDD7 File Offset: 0x00009FD7
		// (set) Token: 0x0600021A RID: 538 RVA: 0x0000BDDF File Offset: 0x00009FDF
		public float angle { get; private set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600021B RID: 539 RVA: 0x0000BDE8 File Offset: 0x00009FE8
		// (set) Token: 0x0600021C RID: 540 RVA: 0x0000BDF0 File Offset: 0x00009FF0
		public Vector3 velocity { get; private set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600021D RID: 541 RVA: 0x0000BDF9 File Offset: 0x00009FF9
		// (set) Token: 0x0600021E RID: 542 RVA: 0x0000BE01 File Offset: 0x0000A001
		public Vector3 centerOfPressure { get; private set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600021F RID: 543 RVA: 0x0000BE0A File Offset: 0x0000A00A
		// (set) Token: 0x06000220 RID: 544 RVA: 0x0000BE12 File Offset: 0x0000A012
		public Quaternion rotation { get; private set; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000221 RID: 545 RVA: 0x0000BE1B File Offset: 0x0000A01B
		// (set) Token: 0x06000222 RID: 546 RVA: 0x0000BE23 File Offset: 0x0000A023
		public Quaternion inverseRotation { get; private set; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000223 RID: 547 RVA: 0x0000BE2C File Offset: 0x0000A02C
		// (set) Token: 0x06000224 RID: 548 RVA: 0x0000BE34 File Offset: 0x0000A034
		public bool isGrounded { get; private set; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000225 RID: 549 RVA: 0x0000BE3D File Offset: 0x0000A03D
		// (set) Token: 0x06000226 RID: 550 RVA: 0x0000BE45 File Offset: 0x0000A045
		public float lastGroundedTime { get; private set; }

		// Token: 0x06000227 RID: 551 RVA: 0x0000BE50 File Offset: 0x0000A050
		public void Initiate(BehaviourBase behaviour, LayerMask groundLayers)
		{
			this.behaviour = behaviour;
			this.groundLayers = groundLayers;
			this.rotation = Quaternion.identity;
			this.groundContacts = new bool[behaviour.puppetMaster.muscles.Length];
			this.groundContactPoints = new Vector3[this.groundContacts.Length];
			behaviour.OnPreActivate = (BehaviourBase.BehaviourDelegate)Delegate.Combine(behaviour.OnPreActivate, new BehaviourBase.BehaviourDelegate(this.OnPreActivate));
			behaviour.OnPreLateUpdate = (BehaviourBase.BehaviourUpdateDelegate)Delegate.Combine(behaviour.OnPreLateUpdate, new BehaviourBase.BehaviourUpdateDelegate(this.OnPreLateUpdate));
			behaviour.OnPreDeactivate = (BehaviourBase.BehaviourDelegate)Delegate.Combine(behaviour.OnPreDeactivate, new BehaviourBase.BehaviourDelegate(this.OnPreDeactivate));
			behaviour.OnPreMuscleCollision = (BehaviourBase.CollisionDelegate)Delegate.Combine(behaviour.OnPreMuscleCollision, new BehaviourBase.CollisionDelegate(this.OnPreMuscleCollision));
			behaviour.OnPreMuscleCollisionExit = (BehaviourBase.CollisionDelegate)Delegate.Combine(behaviour.OnPreMuscleCollisionExit, new BehaviourBase.CollisionDelegate(this.OnPreMuscleCollisionExit));
			behaviour.OnHierarchyChanged = (BehaviourBase.BehaviourDelegate)Delegate.Combine(behaviour.OnHierarchyChanged, new BehaviourBase.BehaviourDelegate(this.OnHierarchyChanged));
		}

		// Token: 0x06000228 RID: 552 RVA: 0x0000BF6D File Offset: 0x0000A16D
		private void OnHierarchyChanged()
		{
			Array.Resize<bool>(ref this.groundContacts, this.behaviour.puppetMaster.muscles.Length);
			Array.Resize<Vector3>(ref this.groundContactPoints, this.behaviour.puppetMaster.muscles.Length);
		}

		// Token: 0x06000229 RID: 553 RVA: 0x0000BFAC File Offset: 0x0000A1AC
		private void OnPreMuscleCollision(MuscleCollision c)
		{
			if (!LayerMaskExtensions.Contains(this.groundLayers, c.collision.gameObject.layer))
			{
				return;
			}
			if (c.collision.contacts.Length == 0)
			{
				return;
			}
			this.lastGroundedTime = Time.time;
			this.groundContacts[c.muscleIndex] = true;
			if (this.mode == SubBehaviourCOM.Mode.CenterOfPressure)
			{
				this.groundContactPoints[c.muscleIndex] = this.GetCollisionCOP(c.collision);
			}
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0000C028 File Offset: 0x0000A228
		private void OnPreMuscleCollisionExit(MuscleCollision c)
		{
			if (!LayerMaskExtensions.Contains(this.groundLayers, c.collision.gameObject.layer))
			{
				return;
			}
			this.groundContacts[c.muscleIndex] = false;
			this.groundContactPoints[c.muscleIndex] = Vector3.zero;
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0000C078 File Offset: 0x0000A278
		private void OnPreActivate()
		{
			this.position = this.GetCenterOfMass();
			this.centerOfPressure = this.GetFeetCentroid();
			this.direction = this.position - this.centerOfPressure;
			this.angle = Vector3.Angle(this.direction, Vector3.up);
			this.velocity = Vector3.zero;
		}

		// Token: 0x0600022C RID: 556 RVA: 0x0000C0D8 File Offset: 0x0000A2D8
		private void OnPreLateUpdate(float deltaTime)
		{
			this.isGrounded = this.IsGrounded();
			if (this.mode == SubBehaviourCOM.Mode.FeetCentroid || !this.isGrounded)
			{
				this.centerOfPressure = this.GetFeetCentroid();
			}
			else
			{
				Vector3 vector = this.isGrounded ? this.GetCenterOfPressure() : this.GetFeetCentroid();
				this.centerOfPressure = ((this.centerOfPressureSpeed <= 2f) ? vector : Vector3.Lerp(this.centerOfPressure, vector, deltaTime * this.centerOfPressureSpeed));
			}
			this.position = this.GetCenterOfMass();
			Vector3 vector2 = this.GetCenterOfMassVelocity() - this.position;
			vector2.y = 0f;
			vector2 = Vector3.ClampMagnitude(vector2, this.velocityMax);
			this.velocity = ((this.velocityLerpSpeed <= 0f) ? vector2 : Vector3.Lerp(this.velocity, vector2, deltaTime * this.velocityLerpSpeed));
			this.position += this.velocity * this.velocityDamper;
			this.position += this.behaviour.puppetMaster.targetRoot.rotation * this.offset;
			this.direction = this.position - this.centerOfPressure;
			this.rotation = Quaternion.FromToRotation(Vector3.up, this.direction);
			this.inverseRotation = Quaternion.Inverse(this.rotation);
			this.angle = Quaternion.Angle(Quaternion.identity, this.rotation);
		}

		// Token: 0x0600022D RID: 557 RVA: 0x0000C258 File Offset: 0x0000A458
		private void OnPreDeactivate()
		{
			this.velocity = Vector3.zero;
		}

		// Token: 0x0600022E RID: 558 RVA: 0x0000C268 File Offset: 0x0000A468
		private Vector3 GetCollisionCOP(Collision collision)
		{
			Vector3 a = Vector3.zero;
			for (int i = 0; i < collision.contacts.Length; i++)
			{
				a += collision.contacts[i].point;
			}
			return a / (float)collision.contacts.Length;
		}

		// Token: 0x0600022F RID: 559 RVA: 0x0000C2B8 File Offset: 0x0000A4B8
		private bool IsGrounded()
		{
			for (int i = 0; i < this.groundContacts.Length; i++)
			{
				if (this.groundContacts[i])
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000230 RID: 560 RVA: 0x0000C2E8 File Offset: 0x0000A4E8
		private Vector3 GetCenterOfMass()
		{
			Vector3 a = Vector3.zero;
			float num = 0f;
			foreach (Muscle muscle in this.behaviour.puppetMaster.muscles)
			{
				a += muscle.rigidbody.worldCenterOfMass * muscle.rigidbody.mass;
				num += muscle.rigidbody.mass;
			}
			return a / num;
		}

		// Token: 0x06000231 RID: 561 RVA: 0x0000C364 File Offset: 0x0000A564
		private Vector3 GetCenterOfMassVelocity()
		{
			Vector3 a = Vector3.zero;
			float num = 0f;
			foreach (Muscle muscle in this.behaviour.puppetMaster.muscles)
			{
				a += muscle.rigidbody.worldCenterOfMass * muscle.rigidbody.mass;
				a += muscle.rigidbody.velocity * muscle.rigidbody.mass;
				num += muscle.rigidbody.mass;
			}
			return a / num;
		}

		// Token: 0x06000232 RID: 562 RVA: 0x0000C404 File Offset: 0x0000A604
		private Vector3 GetMomentum()
		{
			Vector3 vector = Vector3.zero;
			for (int i = 0; i < this.behaviour.puppetMaster.muscles.Length; i++)
			{
				vector += this.behaviour.puppetMaster.muscles[i].rigidbody.velocity * this.behaviour.puppetMaster.muscles[i].rigidbody.mass;
			}
			return vector;
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0000C47C File Offset: 0x0000A67C
		private Vector3 GetCenterOfPressure()
		{
			Vector3 vector = Vector3.zero;
			int num = 0;
			for (int i = 0; i < this.groundContacts.Length; i++)
			{
				if (this.groundContacts[i])
				{
					vector += this.groundContactPoints[i];
					num++;
				}
			}
			if (num != 0)
			{
				vector /= (float)num;
			}
			return vector;
		}

		// Token: 0x06000234 RID: 564 RVA: 0x0000C4D4 File Offset: 0x0000A6D4
		private Vector3 GetFeetCentroid()
		{
			Vector3 vector = Vector3.zero;
			int num = 0;
			for (int i = 0; i < this.behaviour.puppetMaster.muscles.Length; i++)
			{
				if (this.behaviour.puppetMaster.muscles[i].props.group == Muscle.Group.Foot)
				{
					vector += this.behaviour.puppetMaster.muscles[i].rigidbody.worldCenterOfMass;
					num++;
				}
			}
			if (num == 0)
			{
				Debug.LogError("Puppet has no muscles assigned to the Foot group. Please make sure you have a muscle group assigned for every muscle in PuppetMaster.");
			}
			else
			{
				vector /= (float)num;
			}
			return vector;
		}

		// Token: 0x040001D9 RID: 473
		public SubBehaviourCOM.Mode mode;

		// Token: 0x040001DA RID: 474
		public float velocityDamper = 1f;

		// Token: 0x040001DB RID: 475
		public float velocityLerpSpeed = 5f;

		// Token: 0x040001DC RID: 476
		public float velocityMax = 1f;

		// Token: 0x040001DD RID: 477
		public float centerOfPressureSpeed = 5f;

		// Token: 0x040001DE RID: 478
		public Vector3 offset;

		// Token: 0x040001E8 RID: 488
		[HideInInspector]
		public bool[] groundContacts;

		// Token: 0x040001E9 RID: 489
		[HideInInspector]
		public Vector3[] groundContactPoints;

		// Token: 0x040001EA RID: 490
		private LayerMask groundLayers;

		// Token: 0x0200004F RID: 79
		[Serializable]
		public enum Mode
		{
			// Token: 0x040001EC RID: 492
			FeetCentroid,
			// Token: 0x040001ED RID: 493
			CenterOfPressure
		}
	}
}
