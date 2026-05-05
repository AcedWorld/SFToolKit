using System;
using RootMotion.Dynamics;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001A1 RID: 417
	public class Grab : MonoBehaviour
	{
		// Token: 0x06000B85 RID: 2949 RVA: 0x00047E00 File Offset: 0x00046000
		private void Start()
		{
			this.r = base.GetComponent<Rigidbody>();
			this.c = base.GetComponent<Collider>();
		}

		// Token: 0x06000B86 RID: 2950 RVA: 0x00047E1C File Offset: 0x0004601C
		private void OnCollisionEnter(Collision collision)
		{
			if (this.grabbed)
			{
				return;
			}
			if (Time.time < this.nextGrabTime)
			{
				return;
			}
			if (collision.gameObject.layer != this.grabLayer)
			{
				return;
			}
			if (collision.rigidbody == null)
			{
				return;
			}
			MuscleCollisionBroadcaster component = collision.gameObject.GetComponent<MuscleCollisionBroadcaster>();
			if (component == null)
			{
				return;
			}
			if (component.puppetMaster == this.puppetMaster)
			{
				return;
			}
			foreach (BehaviourBase behaviourBase in component.puppetMaster.behaviours)
			{
				if (behaviourBase is BehaviourPuppet)
				{
					this.otherPuppet = (behaviourBase as BehaviourPuppet);
					this.otherPuppet.SetState(BehaviourPuppet.State.Unpinned);
					this.otherPuppet.canGetUp = false;
				}
			}
			if (this.otherPuppet == null)
			{
				return;
			}
			this.joint = base.gameObject.AddComponent<ConfigurableJoint>();
			this.joint.connectedBody = collision.rigidbody;
			this.joint.anchor = new Vector3(-0.35f, 0f, 0f);
			this.joint.xMotion = ConfigurableJointMotion.Locked;
			this.joint.yMotion = ConfigurableJointMotion.Locked;
			this.joint.zMotion = ConfigurableJointMotion.Locked;
			this.joint.angularXMotion = ConfigurableJointMotion.Locked;
			this.joint.angularYMotion = ConfigurableJointMotion.Locked;
			this.joint.angularZMotion = ConfigurableJointMotion.Locked;
			this.r.mass *= 5f;
			this.puppetMaster.solverIterationCount *= 10;
			this.otherCollider = collision.collider;
			Physics.IgnoreCollision(this.c, this.otherCollider, true);
			this.userControl.walkByDefault = true;
			this.grabbed = true;
		}

		// Token: 0x06000B87 RID: 2951 RVA: 0x00047FCC File Offset: 0x000461CC
		private void Update()
		{
			if (!this.grabbed)
			{
				return;
			}
			if (Input.GetKeyDown(KeyCode.X))
			{
				Object.Destroy(this.joint);
				this.r.mass /= 5f;
				this.puppetMaster.solverIterationCount /= 10;
				this.userControl.walkByDefault = false;
				Physics.IgnoreCollision(this.c, this.otherCollider, false);
				this.otherPuppet.canGetUp = true;
				this.otherPuppet = null;
				this.otherCollider = null;
				this.grabbed = false;
				this.nextGrabTime = Time.time + 1f;
			}
		}

		// Token: 0x04000B7A RID: 2938
		[Tooltip("The PuppetMaster this muscle belongs to.")]
		public PuppetMaster puppetMaster;

		// Token: 0x04000B7B RID: 2939
		[Tooltip("Used for switching walk/run by default.")]
		public UserControlMelee userControl;

		// Token: 0x04000B7C RID: 2940
		[Tooltip("The layers we wish to grab (optimization).")]
		public int grabLayer;

		// Token: 0x04000B7D RID: 2941
		private bool grabbed;

		// Token: 0x04000B7E RID: 2942
		private Rigidbody r;

		// Token: 0x04000B7F RID: 2943
		private Collider c;

		// Token: 0x04000B80 RID: 2944
		private BehaviourPuppet otherPuppet;

		// Token: 0x04000B81 RID: 2945
		private Collider otherCollider;

		// Token: 0x04000B82 RID: 2946
		private ConfigurableJoint joint;

		// Token: 0x04000B83 RID: 2947
		private float nextGrabTime;

		// Token: 0x04000B84 RID: 2948
		private const float massMlp = 5f;

		// Token: 0x04000B85 RID: 2949
		private const int solverIterationMlp = 10;
	}
}
