using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x0200007D RID: 125
	public class PuppetMasterProp : MonoBehaviour
	{
		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060003F8 RID: 1016 RVA: 0x00017B16 File Offset: 0x00015D16
		// (set) Token: 0x060003F9 RID: 1017 RVA: 0x00017B1E File Offset: 0x00015D1E
		public bool isPickedUp { get; private set; }

		// Token: 0x060003FA RID: 1018 RVA: 0x00017B27 File Offset: 0x00015D27
		public Rigidbody GetRigidbody()
		{
			if (this.r != null)
			{
				return this.r;
			}
			if (this.isPickedUp)
			{
				return this.propMuscle.rigidbody;
			}
			return null;
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060003FB RID: 1019 RVA: 0x00017B53 File Offset: 0x00015D53
		// (set) Token: 0x060003FC RID: 1020 RVA: 0x00017B5B File Offset: 0x00015D5B
		public Vector3 inertiaTensor { get; private set; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060003FD RID: 1021 RVA: 0x00017B64 File Offset: 0x00015D64
		// (set) Token: 0x060003FE RID: 1022 RVA: 0x00017B6C File Offset: 0x00015D6C
		public Vector3 localCenterOfMass { get; private set; }

		// Token: 0x060003FF RID: 1023 RVA: 0x0000223E File Offset: 0x0000043E
		protected virtual void OnPickUp(PuppetMaster puppetMaster, int propMuscleIndex)
		{
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x0000223E File Offset: 0x0000043E
		protected virtual void OnDrop(PuppetMaster puppetMaster, int propMuscleIndex)
		{
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000401 RID: 1025 RVA: 0x00017B75 File Offset: 0x00015D75
		// (set) Token: 0x06000402 RID: 1026 RVA: 0x00017B7D File Offset: 0x00015D7D
		private protected Muscle propMuscle { protected get; private set; }

		// Token: 0x06000403 RID: 1027 RVA: 0x00017B88 File Offset: 0x00015D88
		public void PickUp(PuppetMaster puppetMaster, int propMuscleIndex)
		{
			this.RemoveRigidbody();
			base.transform.parent = puppetMaster.muscles[propMuscleIndex].transform;
			base.transform.position = puppetMaster.muscles[propMuscleIndex].transform.position;
			base.transform.rotation = puppetMaster.muscles[propMuscleIndex].transform.rotation;
			this.meshRoot.parent = puppetMaster.muscles[propMuscleIndex].target;
			this.meshRoot.localPosition = Vector3.zero;
			this.meshRoot.localRotation = Quaternion.identity;
			puppetMaster.muscles[propMuscleIndex].props = this.muscleProps;
			if (this.pickedUpMaterial != null)
			{
				Collider[] array = this.colliders;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].sharedMaterial = this.pickedUpMaterial;
				}
			}
			if (this.forceLayers)
			{
				foreach (Collider collider in this.colliders)
				{
					if (!collider.isTrigger)
					{
						collider.gameObject.layer = puppetMaster.muscles[propMuscleIndex].joint.gameObject.layer;
					}
				}
			}
			puppetMaster.muscles[propMuscleIndex].colliders = this.colliders;
			puppetMaster.UpdateInternalCollisions(puppetMaster.muscles[propMuscleIndex]);
			this.isPickedUp = true;
			this.propMuscle = puppetMaster.muscles[propMuscleIndex];
			this.OnPickUp(puppetMaster, propMuscleIndex);
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x00017CF4 File Offset: 0x00015EF4
		public void Drop(PuppetMaster puppetMaster, int propMuscleIndex)
		{
			if (!puppetMaster.muscles[propMuscleIndex].joint.gameObject.activeInHierarchy)
			{
				base.transform.position = puppetMaster.muscles[propMuscleIndex].target.position;
				base.transform.rotation = puppetMaster.muscles[propMuscleIndex].target.rotation;
			}
			this.ReattachRigidbody();
			if (!puppetMaster.muscles[propMuscleIndex].joint.gameObject.activeInHierarchy || puppetMaster.muscles[propMuscleIndex].rigidbody.isKinematic)
			{
				this.r.velocity = puppetMaster.muscles[propMuscleIndex].mappedVelocity;
				this.r.angularVelocity = puppetMaster.muscles[propMuscleIndex].mappedAngularVelocity;
			}
			base.transform.parent = this.defaultParent;
			this.meshRoot.parent = base.transform;
			this.meshRoot.localPosition = Vector3.zero;
			this.meshRoot.localRotation = Quaternion.identity;
			for (int i = 0; i < this.colliders.Length; i++)
			{
				this.colliders[i].sharedMaterial = this.droppedMaterials[i];
			}
			puppetMaster.ResetInternalCollisions(puppetMaster.muscles[propMuscleIndex], false);
			puppetMaster.muscles[propMuscleIndex].colliders = this.emptyColliders;
			if (this.forceLayers)
			{
				foreach (Collider collider in this.colliders)
				{
					if (!collider.isTrigger)
					{
						collider.gameObject.layer = this.defaultLayer;
					}
				}
			}
			this.isPickedUp = false;
			this.propMuscle = null;
			this.OnDrop(puppetMaster, propMuscleIndex);
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x00017E94 File Offset: 0x00016094
		protected virtual void Awake()
		{
			this.r = base.GetComponent<Rigidbody>();
			this.defaultParent = base.transform.parent;
			this.colliders = base.GetComponentsInChildren<Collider>();
			this.droppedMaterials = new PhysicMaterial[this.colliders.Length];
			for (int i = 0; i < this.colliders.Length; i++)
			{
				this.droppedMaterials[i] = this.colliders[i].sharedMaterial;
			}
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x00017F08 File Offset: 0x00016108
		protected virtual void Start()
		{
			this.muscleProps.group = Muscle.Group.Prop;
			if (this.meshRoot == null)
			{
				Debug.LogError("PuppetMasterProp does not have a 'Mesh Root' Transform assigned.", base.transform);
				base.enabled = false;
				return;
			}
			if (this.meshRoot == base.transform)
			{
				Debug.LogError("PuppetMasterProp's 'Mesh Root' can not be the PuppetMasterProp's own Transform.", base.transform);
				base.enabled = false;
				return;
			}
			this.defaultLayer = base.gameObject.layer;
			foreach (Collider collider in this.colliders)
			{
				if (!collider.isTrigger)
				{
					this.defaultLayer = collider.gameObject.layer;
					return;
				}
			}
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x00017FB6 File Offset: 0x000161B6
		protected virtual void Update()
		{
			if (this.isPickedUp)
			{
				base.transform.localPosition = Vector3.zero;
				base.transform.localRotation = Quaternion.identity;
			}
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x00017FE0 File Offset: 0x000161E0
		private void RemoveRigidbody()
		{
			if (this.r == null)
			{
				return;
			}
			this.inertiaTensor = this.r.inertiaTensor;
			this.localCenterOfMass = this.r.centerOfMass;
			this._mass = this.r.mass;
			this._drag = this.r.drag;
			this._angularDrag = this.r.angularDrag;
			this._useGravity = this.r.useGravity;
			this._isKinematic = this.r.isKinematic;
			this._interpolation = this.r.interpolation;
			this._collisionDetectionMode = this.r.collisionDetectionMode;
			this._constraints = this.r.constraints;
			Object.Destroy(this.r);
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x000180B4 File Offset: 0x000162B4
		private void ReattachRigidbody()
		{
			if (this.r != null)
			{
				return;
			}
			this.r = base.gameObject.AddComponent<Rigidbody>();
			this.r.mass = this._mass;
			this.r.drag = this._drag;
			this.r.angularDrag = this._angularDrag;
			this.r.useGravity = this._useGravity;
			this.r.isKinematic = this._isKinematic;
			this.r.interpolation = this._interpolation;
			this.r.collisionDetectionMode = this._collisionDetectionMode;
			this.r.constraints = this._constraints;
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x0001816C File Offset: 0x0001636C
		private void OnDrawGizmosSelected()
		{
			if (Application.isPlaying)
			{
				return;
			}
			if (this.muscleProps != null)
			{
				this.muscleProps.group = Muscle.Group.Prop;
			}
			if (this.meshRoot != null && this.meshRoot != base.transform)
			{
				this.meshRoot.parent = base.transform;
				this.meshRoot.position = base.transform.position;
				this.meshRoot.rotation = base.transform.rotation;
			}
		}

		// Token: 0x04000386 RID: 902
		[Tooltip("Mesh Root will be parented to Prop Muscle's target when this prop is picked up. To make sure the mesh and the colliders match up, Mesh Root's localPosition/Rotation must be zero.")]
		public Transform meshRoot;

		// Token: 0x04000387 RID: 903
		[Tooltip("The muscle properties that will be applied to the Prop Muscle when this prop is picked up.")]
		public Muscle.Props muscleProps;

		// Token: 0x04000388 RID: 904
		[Tooltip("If true, this prop's layer will be forced to PuppetMaster layer and target's layer forced to PuppetMaster's Target Root's layer when the prop is picked up.")]
		public bool forceLayers = true;

		// Token: 0x04000389 RID: 905
		[Tooltip("Mass of the prop while picked up. When dropped, mass of the original Rigidbody will be used.")]
		public float mass = 1f;

		// Token: 0x0400038A RID: 906
		[Tooltip("This has no other purpose but helping you distinguish props by PropMuscle.currentProp.propType.")]
		public int propType;

		// Token: 0x0400038B RID: 907
		[LargeHeader("Materials")]
		[Tooltip("If assigned, sets prop colliders to this PhysicMaterial when picked up. If no material assigned, will maintain the original PhysicMaterial (unless otherwise controlled by BehaviourPuppet's Group Overrides).")]
		public PhysicMaterial pickedUpMaterial;

		// Token: 0x0400038C RID: 908
		[LargeHeader("Additional Pin")]
		[Tooltip("Adds this to Prop Muscle's 'Additional Pin Offset' when this prop is picked up.")]
		public Vector3 additionalPinOffsetAdd;

		// Token: 0x0400038D RID: 909
		[Tooltip("The pin weight multiplier of the additional pin. Increasing this weight will make the prop follow animation better, but will increase jitter when colliding with objects.")]
		[Range(0f, 1f)]
		public float additionalPinWeight = 1f;

		// Token: 0x0400038E RID: 910
		[Tooltip("Multiplies the mass of the additional pin by this value when this prop is picked up. The Rigidbody on this prop will be destroyed on pick-up and reattached on drop, so its mass is not used while picked up.")]
		public float additionalPinMass = 1f;

		// Token: 0x04000393 RID: 915
		private int defaultLayer;

		// Token: 0x04000394 RID: 916
		private Transform defaultParent;

		// Token: 0x04000395 RID: 917
		private Collider[] colliders = new Collider[0];

		// Token: 0x04000396 RID: 918
		private PhysicMaterial[] droppedMaterials = new PhysicMaterial[0];

		// Token: 0x04000397 RID: 919
		private Rigidbody r;

		// Token: 0x04000398 RID: 920
		private float _mass;

		// Token: 0x04000399 RID: 921
		private float _drag;

		// Token: 0x0400039A RID: 922
		private float _angularDrag;

		// Token: 0x0400039B RID: 923
		private bool _useGravity;

		// Token: 0x0400039C RID: 924
		private bool _isKinematic;

		// Token: 0x0400039D RID: 925
		private RigidbodyInterpolation _interpolation;

		// Token: 0x0400039E RID: 926
		private CollisionDetectionMode _collisionDetectionMode;

		// Token: 0x0400039F RID: 927
		private RigidbodyConstraints _constraints;

		// Token: 0x040003A0 RID: 928
		private Collider[] emptyColliders = new Collider[0];
	}
}
