using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x0200005F RID: 95
	public class PropMuscle : MonoBehaviour
	{
		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060002C9 RID: 713 RVA: 0x0000F76A File Offset: 0x0000D96A
		public Muscle muscle
		{
			get
			{
				if (this._muscle == null)
				{
					this._muscle = this.puppetMaster.GetMuscle(base.GetComponent<ConfigurableJoint>());
				}
				return this._muscle;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060002CA RID: 714 RVA: 0x0000F791 File Offset: 0x0000D991
		// (set) Token: 0x060002CB RID: 715 RVA: 0x0000F799 File Offset: 0x0000D999
		public PuppetMasterProp activeProp { get; private set; }

		// Token: 0x060002CC RID: 716 RVA: 0x0000F7A4 File Offset: 0x0000D9A4
		public bool AddAdditionalPin()
		{
			if (!this.puppetMaster.initiated)
			{
				Debug.LogError("Can not call AddAdditionalPin on an uninitiated PuppetMaster.", base.transform);
				return false;
			}
			if (this.muscle.additionalPin != null)
			{
				return false;
			}
			GameObject gameObject = new GameObject("Additional Pin");
			gameObject.gameObject.layer = base.gameObject.layer;
			gameObject.transform.parent = base.transform;
			gameObject.transform.localPosition = this.additionalPinOffset;
			gameObject.transform.localRotation = Quaternion.identity;
			this.lastAdditionalPinOffset = this.additionalPinOffset;
			gameObject.AddComponent<Rigidbody>();
			ConfigurableJoint configurableJoint = gameObject.AddComponent<ConfigurableJoint>();
			configurableJoint.connectedBody = this.muscle.joint.GetComponent<Rigidbody>();
			configurableJoint.autoConfigureConnectedAnchor = false;
			configurableJoint.connectedAnchor = this.additionalPinOffset;
			configurableJoint.xMotion = ConfigurableJointMotion.Locked;
			configurableJoint.yMotion = ConfigurableJointMotion.Locked;
			configurableJoint.zMotion = ConfigurableJointMotion.Locked;
			configurableJoint.angularXMotion = ConfigurableJointMotion.Locked;
			configurableJoint.angularYMotion = ConfigurableJointMotion.Locked;
			configurableJoint.angularZMotion = ConfigurableJointMotion.Locked;
			GameObject gameObject2 = new GameObject("Additional Pin Target");
			gameObject2.layer = this.muscle.target.gameObject.layer;
			gameObject2.transform.parent = this.muscle.target;
			gameObject2.transform.position = gameObject.transform.position;
			gameObject2.transform.rotation = gameObject.transform.rotation;
			this.muscle.additionalPin = configurableJoint;
			this.muscle.additionalPinTarget = gameObject2.transform;
			this.muscle.InitiateAdditionalPin();
			return true;
		}

		// Token: 0x060002CD RID: 717 RVA: 0x0000F938 File Offset: 0x0000DB38
		public bool RemoveAdditionalPin()
		{
			if (!this.puppetMaster.initiated)
			{
				Debug.LogError("Can not call RemoveAdditionalPin on an uninitiated PuppetMaster.", base.transform);
				return false;
			}
			if (this.muscle.additionalPin == null)
			{
				return false;
			}
			Object.Destroy(this.muscle.additionalPin.gameObject);
			Object.Destroy(this.muscle.additionalPinTarget.gameObject);
			this.muscle.additionalPin = null;
			this.muscle.additionalPinTarget = null;
			return true;
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0000F9BC File Offset: 0x0000DBBC
		public void OnInitiate()
		{
			this.muscle.isPropMuscle = true;
			if (this.currentProp == null && this.activeProp == null)
			{
				this.puppetMaster.DisconnectMuscleRecursive(this.muscle.index, MuscleDisconnectMode.Sever, true);
			}
		}

		// Token: 0x060002CF RID: 719 RVA: 0x0000FA09 File Offset: 0x0000DC09
		public void TakeOver()
		{
			this.currentProp = null;
			this.lastProp = null;
			this.activeProp = null;
			this.puppetMaster.DisconnectMuscleRecursive(this.muscle.index, MuscleDisconnectMode.Sever, true);
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0000FA38 File Offset: 0x0000DC38
		public void OnUpdate()
		{
			if (this.currentProp != this.lastProp && !this.puppetMaster.IsDisconnecting(this.muscle.index) && !this.puppetMaster.IsReconnecting(this.muscle.index))
			{
				if (this.lastProp != null)
				{
					this.lastProp.Drop(this.puppetMaster, this.muscle.index);
					this.activeProp = null;
					if (this.OnDropProp != null)
					{
						this.OnDropProp(this.lastProp);
					}
				}
				if (this.currentProp != null)
				{
					foreach (PropMuscle propMuscle in this.puppetMaster.propMuscles)
					{
						if (propMuscle != this && propMuscle.currentProp == this.currentProp)
						{
							propMuscle.TakeOver();
						}
					}
					if (this.muscle.state.isDisconnected)
					{
						this.puppetMaster.ReconnectMuscleRecursive(this.muscle.index);
					}
					this.currentProp.PickUp(this.puppetMaster, this.muscle.index);
					this.muscle.rigidbody.centerOfMass = this.currentProp.localCenterOfMass;
					if (this.currentProp.inertiaTensor != Vector3.zero)
					{
						this.muscle.rigidbody.inertiaTensor = this.currentProp.inertiaTensor;
					}
					this.activeProp = this.currentProp;
					if (this.OnPickUpProp != null)
					{
						this.OnPickUpProp(this.currentProp);
					}
				}
				else
				{
					this.puppetMaster.DisconnectMuscleRecursive(this.muscle.index, MuscleDisconnectMode.Sever, true);
				}
				this.lastProp = this.currentProp;
			}
			if (this.currentProp != null)
			{
				this.muscle.rigidbody.mass = this.currentProp.mass;
				if (this.muscle.additionalPin != null)
				{
					this.muscle.additionalPinWeight = this.currentProp.additionalPinWeight;
					this.muscle.additionalRigidbody.mass = this.currentProp.additionalPinMass;
					this.muscle.additionalRigidbody.drag = this.muscle.rigidbody.drag;
					this.muscle.additionalRigidbody.angularDrag = this.muscle.rigidbody.angularDrag;
					this.muscle.additionalRigidbody.useGravity = this.muscle.rigidbody.useGravity;
					this.muscle.additionalRigidbody.inertiaTensor = Vector3.one * 1E-05f;
					Vector3 vector = this.additionalPinOffset + this.currentProp.additionalPinOffsetAdd;
					if (this.lastAdditionalPinOffset != vector)
					{
						this.muscle.additionalPinTarget.localPosition = vector;
						this.muscle.additionalPin.connectedAnchor = vector;
						this.lastAdditionalPinOffset = vector;
					}
				}
			}
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0000FD48 File Offset: 0x0000DF48
		private void OnDrawGizmosSelected()
		{
			if (Application.isPlaying)
			{
				return;
			}
			if (this.muscle.target == null)
			{
				return;
			}
			this.muscle.target.position = base.transform.position;
			this.muscle.target.rotation = base.transform.rotation;
			if (this.muscle.additionalPin != null && this.muscle.additionalPinTarget != null)
			{
				this.muscle.additionalPin.transform.localPosition = this.additionalPinOffset;
				this.muscle.additionalPin.transform.localRotation = Quaternion.identity;
				this.muscle.additionalPinTarget.position = this.muscle.additionalPin.transform.position;
				this.muscle.additionalPinTarget.rotation = this.muscle.additionalPin.transform.rotation;
			}
		}

		// Token: 0x04000294 RID: 660
		[HideInInspector]
		public PuppetMaster puppetMaster;

		// Token: 0x04000295 RID: 661
		[Tooltip("The PuppetMasterProp currently held by this Prop Muscle. To pick up a prop, just assign it as propMuscle.currentProp. To drop, set propMuscle.currentProp to null. Replacing this value with another prop drops any previously held props.")]
		public PuppetMasterProp currentProp;

		// Token: 0x04000296 RID: 662
		[LargeHeader("Additional Pin")]
		[Tooltip("Offset of the additional pin from this Prop Muscle in local space.")]
		public Vector3 additionalPinOffset = Vector3.forward;

		// Token: 0x04000298 RID: 664
		public PropMuscle.PropDelegate OnPickUpProp;

		// Token: 0x04000299 RID: 665
		public PropMuscle.PropDelegate OnDropProp;

		// Token: 0x0400029A RID: 666
		private Muscle _muscle;

		// Token: 0x0400029B RID: 667
		private PuppetMasterProp lastProp;

		// Token: 0x0400029C RID: 668
		private Vector3 lastAdditionalPinOffset;

		// Token: 0x02000060 RID: 96
		// (Invoke) Token: 0x060002D4 RID: 724
		public delegate void PropDelegate(PuppetMasterProp prop);
	}
}
