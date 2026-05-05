using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x0200004B RID: 75
	[Serializable]
	public class SubBehaviourBalancer : SubBehaviourBase
	{
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000200 RID: 512 RVA: 0x0000BA1C File Offset: 0x00009C1C
		// (set) Token: 0x06000201 RID: 513 RVA: 0x0000BA24 File Offset: 0x00009C24
		public ConfigurableJoint joint { get; private set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000202 RID: 514 RVA: 0x0000BA2D File Offset: 0x00009C2D
		// (set) Token: 0x06000203 RID: 515 RVA: 0x0000BA35 File Offset: 0x00009C35
		public Vector3 dir { get; private set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000204 RID: 516 RVA: 0x0000BA3E File Offset: 0x00009C3E
		// (set) Token: 0x06000205 RID: 517 RVA: 0x0000BA46 File Offset: 0x00009C46
		public Vector3 dirVel { get; private set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000206 RID: 518 RVA: 0x0000BA4F File Offset: 0x00009C4F
		// (set) Token: 0x06000207 RID: 519 RVA: 0x0000BA57 File Offset: 0x00009C57
		public Vector3 cop { get; private set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000208 RID: 520 RVA: 0x0000BA60 File Offset: 0x00009C60
		// (set) Token: 0x06000209 RID: 521 RVA: 0x0000BA68 File Offset: 0x00009C68
		public Vector3 com { get; private set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600020A RID: 522 RVA: 0x0000BA71 File Offset: 0x00009C71
		// (set) Token: 0x0600020B RID: 523 RVA: 0x0000BA79 File Offset: 0x00009C79
		public Vector3 comV { get; private set; }

		// Token: 0x0600020C RID: 524 RVA: 0x0000BA84 File Offset: 0x00009C84
		public void Initiate(BehaviourBase behaviour, SubBehaviourBalancer.Settings settings, Rigidbody Ibody, Rigidbody[] rigidbodies, ConfigurableJoint joint, Transform[] copPoints, PressureSensor pressureSensor)
		{
			this.behaviour = behaviour;
			this.settings = settings;
			this.Ibody = Ibody;
			this.rigidbodies = rigidbodies;
			this.joint = joint;
			this.copPoints = copPoints;
			this.pressureSensor = pressureSensor;
			this.toJointSpace = PhysXTools.ToJointSpace(joint);
			behaviour.OnPreFixedUpdate = (BehaviourBase.BehaviourUpdateDelegate)Delegate.Combine(behaviour.OnPreFixedUpdate, new BehaviourBase.BehaviourUpdateDelegate(this.Solve));
		}

		// Token: 0x0600020D RID: 525 RVA: 0x0000BAF8 File Offset: 0x00009CF8
		private void Solve(float deltaTime)
		{
			if (this.copPoints.Length == 0)
			{
				this.cop = this.joint.transform.TransformPoint(this.joint.anchor);
			}
			else
			{
				this.cop = Vector3.zero;
				foreach (Transform transform in this.copPoints)
				{
					this.cop += transform.position;
				}
				this.cop /= (float)this.copPoints.Length;
			}
			this.cop += this.settings.copOffset;
			this.com = PhysXTools.GetCenterOfMass(this.rigidbodies);
			this.comV = PhysXTools.GetCenterOfMassVelocity(this.rigidbodies);
			this.dir = this.com - this.cop;
			this.dirVel = this.com + this.comV * this.settings.velocityF - this.cop;
			Vector3 vector = (PhysXTools.GetFromToAcceleration(this.dirVel, -Physics.gravity) - this.Ibody.angularVelocity) / deltaTime;
			PhysXTools.ScaleByInertia(ref vector, this.Ibody.rotation, this.Ibody.inertiaTensor * this.settings.IMlp);
			vector = Vector3.ClampMagnitude(vector, this.settings.maxTorqueMag);
			if (this.pressureSensor == null || !this.pressureSensor.enabled || this.pressureSensor.inContact)
			{
				this.Ibody.AddTorque(vector * this.settings.torqueMlp, ForceMode.Force);
				this.joint.targetAngularVelocity = Quaternion.Inverse(this.toJointSpace) * Quaternion.Inverse(this.joint.transform.rotation) * vector;
				return;
			}
			this.joint.targetAngularVelocity = Vector3.zero;
		}

		// Token: 0x040001CA RID: 458
		private SubBehaviourBalancer.Settings settings;

		// Token: 0x040001CB RID: 459
		private Rigidbody[] rigidbodies = new Rigidbody[0];

		// Token: 0x040001CC RID: 460
		private Transform[] copPoints = new Transform[0];

		// Token: 0x040001CD RID: 461
		private PressureSensor pressureSensor;

		// Token: 0x040001CE RID: 462
		private Rigidbody Ibody;

		// Token: 0x040001CF RID: 463
		private Vector3 I;

		// Token: 0x040001D0 RID: 464
		private Quaternion toJointSpace = Quaternion.identity;

		// Token: 0x0200004C RID: 76
		[Serializable]
		public class Settings
		{
			// Token: 0x040001D1 RID: 465
			[Tooltip("Ankle joint damper / spring. Increase to make the balancing effect softer.")]
			public float damperForSpring = 1f;

			// Token: 0x040001D2 RID: 466
			[Tooltip("Multiplier for joint max force.")]
			public float maxForceMlp = 0.05f;

			// Token: 0x040001D3 RID: 467
			[Tooltip("Multiplier for the inertia tensor. Increasing this will increase the balancing forces.")]
			public float IMlp = 1f;

			// Token: 0x040001D4 RID: 468
			[Tooltip("Velocity-based prediction.")]
			public float velocityF = 0.5f;

			// Token: 0x040001D5 RID: 469
			[Tooltip("World space offset for the center of pressure. Can be used to make the characer lean in a certain direction.")]
			public Vector3 copOffset;

			// Token: 0x040001D6 RID: 470
			[Tooltip("The amount of torque applied to the lower legs to help keep the puppet balanced. Note that this is an external force (not coming from the joints themselves) and might make the simulation seem unnatural.")]
			public float torqueMlp;

			// Token: 0x040001D7 RID: 471
			[Tooltip("Maximum magnitude of the torque applied to the lower legs if 'Torque Mlp' > 0.")]
			public float maxTorqueMag = 45f;
		}
	}
}
