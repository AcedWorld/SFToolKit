using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x0200005E RID: 94
	public abstract class Prop : MonoBehaviour
	{
		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060002B9 RID: 697 RVA: 0x0000F3AD File Offset: 0x0000D5AD
		public bool isPickedUp
		{
			get
			{
				return this.propRoot != null;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060002BA RID: 698 RVA: 0x0000F3BB File Offset: 0x0000D5BB
		// (set) Token: 0x060002BB RID: 699 RVA: 0x0000F3C3 File Offset: 0x0000D5C3
		public PropRoot propRoot { get; private set; }

		// Token: 0x060002BC RID: 700 RVA: 0x0000F3CC File Offset: 0x0000D5CC
		public void PickUp(PropRoot propRoot)
		{
			this.muscle.xMotion = this.xMotion;
			this.muscle.yMotion = this.yMotion;
			this.muscle.zMotion = this.zMotion;
			this.muscle.angularXMotion = this.angularXMotion;
			this.muscle.angularYMotion = this.angularYMotion;
			this.muscle.angularZMotion = this.angularZMotion;
			this.propRoot = propRoot;
			this.muscle.gameObject.layer = propRoot.puppetMaster.gameObject.layer;
			foreach (Collider collider in this.colliders)
			{
				if (!collider.isTrigger)
				{
					collider.gameObject.layer = this.muscle.gameObject.layer;
				}
			}
			this.SetMaterial(this.pickedUpMaterial);
			this.OnPickUp(propRoot);
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0000F4B5 File Offset: 0x0000D6B5
		public void Drop()
		{
			this.propRoot = null;
			this.SetMaterial(this.droppedMaterial);
			this.OnDrop();
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0000F4D0 File Offset: 0x0000D6D0
		public void StartPickedUp(PropRoot propRoot)
		{
			this.propRoot = propRoot;
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060002BF RID: 703 RVA: 0x0000F4D9 File Offset: 0x0000D6D9
		// (set) Token: 0x060002C0 RID: 704 RVA: 0x0000F4E1 File Offset: 0x0000D6E1
		public bool initiated { get; private set; }

		// Token: 0x060002C1 RID: 705 RVA: 0x0000223E File Offset: 0x0000043E
		protected virtual void OnPickUp(PropRoot propRoot)
		{
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x0000223E File Offset: 0x0000043E
		protected virtual void OnDrop()
		{
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x0000223E File Offset: 0x0000043E
		protected virtual void OnStart()
		{
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x0000F4EC File Offset: 0x0000D6EC
		private void Start()
		{
			Debug.LogWarning("PropRoot and Prop system is deprecated. Please see the 'Prop' demo to learn about the new easier and much more performance-efficient PropMuscle and PuppetMasterProp system.", base.transform);
			if (base.transform.position != this.muscle.transform.position)
			{
				Debug.LogError("Prop target position must match exactly with its muscle's position!", base.transform);
			}
			this.xMotion = this.muscle.xMotion;
			this.yMotion = this.muscle.yMotion;
			this.zMotion = this.muscle.zMotion;
			this.angularXMotion = this.muscle.angularXMotion;
			this.angularYMotion = this.muscle.angularYMotion;
			this.angularZMotion = this.muscle.angularZMotion;
			this.colliders = this.muscle.GetComponentsInChildren<Collider>();
			if (!this.isPickedUp)
			{
				this.ReleaseJoint();
			}
			this.OnStart();
			this.initiated = true;
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x0000F5D0 File Offset: 0x0000D7D0
		private void ReleaseJoint()
		{
			this.muscle.connectedBody = null;
			this.muscle.targetRotation = Quaternion.identity;
			JointDrive slerpDrive = default(JointDrive);
			slerpDrive.positionSpring = 0f;
			this.muscle.slerpDrive = slerpDrive;
			this.muscle.xMotion = ConfigurableJointMotion.Free;
			this.muscle.yMotion = ConfigurableJointMotion.Free;
			this.muscle.zMotion = ConfigurableJointMotion.Free;
			this.muscle.angularXMotion = ConfigurableJointMotion.Free;
			this.muscle.angularYMotion = ConfigurableJointMotion.Free;
			this.muscle.angularZMotion = ConfigurableJointMotion.Free;
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x0000F664 File Offset: 0x0000D864
		private void SetMaterial(PhysicMaterial material)
		{
			if (material == null)
			{
				return;
			}
			Collider[] array = this.colliders;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].sharedMaterial = material;
			}
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x0000F69C File Offset: 0x0000D89C
		private void OnDrawGizmos()
		{
			if (this.muscle == null)
			{
				return;
			}
			if (Application.isPlaying)
			{
				return;
			}
			base.transform.position = this.muscle.transform.position;
			base.transform.rotation = this.muscle.transform.rotation;
			if (this.additionalPinTarget != null && this.additionalPin != null)
			{
				this.additionalPinTarget.position = this.additionalPin.transform.position;
			}
			this.muscleProps.group = Muscle.Group.Prop;
		}

		// Token: 0x04000282 RID: 642
		[Tooltip("This has no other purpose but helping you distinguish props by PropRoot.currentProp.propType.")]
		public int propType;

		// Token: 0x04000283 RID: 643
		[LargeHeader("Muscle")]
		[Tooltip("The Muscle of this prop.")]
		public ConfigurableJoint muscle;

		// Token: 0x04000284 RID: 644
		[Tooltip("The muscle properties that will be applied to the Muscle on pickup.")]
		public Muscle.Props muscleProps = new Muscle.Props();

		// Token: 0x04000285 RID: 645
		[Tooltip("If true, this prop's layer will be forced to PuppetMaster layer and target's layer forced to PuppetMaster's Target Root's layer when the prop is picked up.")]
		public bool forceLayers = true;

		// Token: 0x04000286 RID: 646
		[LargeHeader("Additional Pin")]
		[Tooltip("Optinal additional pin, useful for long melee weapons that would otherwise require a lot of muscle force and solver iterations to be swinged quickly. Should normally be without any colliders attached. The position of the pin, its mass and the pin weight will effect how the prop will handle.")]
		public ConfigurableJoint additionalPin;

		// Token: 0x04000287 RID: 647
		[Tooltip("Target Transform for the additional pin.")]
		public Transform additionalPinTarget;

		// Token: 0x04000288 RID: 648
		[Tooltip("The pin weight of the additional pin. Increasing this weight will make the prop follow animation better, but will increase jitter when colliding with objects.")]
		[Range(0f, 1f)]
		public float additionalPinWeight = 1f;

		// Token: 0x04000289 RID: 649
		[LargeHeader("Materials")]
		[Tooltip("If assigned, sets prop colliders to this PhysicMaterial when picked up.")]
		public PhysicMaterial pickedUpMaterial;

		// Token: 0x0400028A RID: 650
		[Tooltip("If assigned, sets prop colliders to this PhysicMaterial when dropped.")]
		public PhysicMaterial droppedMaterial;

		// Token: 0x0400028D RID: 653
		private ConfigurableJointMotion xMotion;

		// Token: 0x0400028E RID: 654
		private ConfigurableJointMotion yMotion;

		// Token: 0x0400028F RID: 655
		private ConfigurableJointMotion zMotion;

		// Token: 0x04000290 RID: 656
		private ConfigurableJointMotion angularXMotion;

		// Token: 0x04000291 RID: 657
		private ConfigurableJointMotion angularYMotion;

		// Token: 0x04000292 RID: 658
		private ConfigurableJointMotion angularZMotion;

		// Token: 0x04000293 RID: 659
		private Collider[] colliders = new Collider[0];
	}
}
