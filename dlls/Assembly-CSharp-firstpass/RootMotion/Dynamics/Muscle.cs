using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x02000052 RID: 82
	[Serializable]
	public class Muscle
	{
		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600023A RID: 570 RVA: 0x0000C6F5 File Offset: 0x0000A8F5
		// (set) Token: 0x0600023B RID: 571 RVA: 0x0000C6FD File Offset: 0x0000A8FD
		public Transform transform { get; private set; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600023C RID: 572 RVA: 0x0000C706 File Offset: 0x0000A906
		// (set) Token: 0x0600023D RID: 573 RVA: 0x0000C70E File Offset: 0x0000A90E
		public Rigidbody rigidbody { get; private set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600023E RID: 574 RVA: 0x0000C717 File Offset: 0x0000A917
		// (set) Token: 0x0600023F RID: 575 RVA: 0x0000C71F File Offset: 0x0000A91F
		public Transform connectedBodyTarget { get; private set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000240 RID: 576 RVA: 0x0000C728 File Offset: 0x0000A928
		// (set) Token: 0x06000241 RID: 577 RVA: 0x0000C730 File Offset: 0x0000A930
		public Vector3 targetAnimatedPosition { get; private set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000242 RID: 578 RVA: 0x0000C739 File Offset: 0x0000A939
		// (set) Token: 0x06000243 RID: 579 RVA: 0x0000C741 File Offset: 0x0000A941
		public Quaternion targetAnimatedWorldRotation { get; private set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000244 RID: 580 RVA: 0x0000C74A File Offset: 0x0000A94A
		// (set) Token: 0x06000245 RID: 581 RVA: 0x0000C752 File Offset: 0x0000A952
		public Collider[] colliders
		{
			get
			{
				return this._colliders;
			}
			set
			{
				this._colliders = value;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000246 RID: 582 RVA: 0x0000C75B File Offset: 0x0000A95B
		// (set) Token: 0x06000247 RID: 583 RVA: 0x0000C763 File Offset: 0x0000A963
		public Vector3 targetVelocity { get; private set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000248 RID: 584 RVA: 0x0000C76C File Offset: 0x0000A96C
		// (set) Token: 0x06000249 RID: 585 RVA: 0x0000C774 File Offset: 0x0000A974
		public Rigidbody additionalRigidbody { get; private set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600024A RID: 586 RVA: 0x0000C77D File Offset: 0x0000A97D
		// (set) Token: 0x0600024B RID: 587 RVA: 0x0000C785 File Offset: 0x0000A985
		public Quaternion targetRotationRelative { get; private set; }

		// Token: 0x0600024C RID: 588 RVA: 0x0000C790 File Offset: 0x0000A990
		public bool IsValid(bool log)
		{
			if (this.joint == null)
			{
				if (log)
				{
					Debug.LogError("Muscle joint is null");
				}
				return false;
			}
			if (this.target == null)
			{
				if (log)
				{
					Debug.LogError("Muscle " + this.joint.name + " target is null, please remove the muscle from PuppetMaster or disable PuppetMaster before destroying a muscle's target.");
				}
				return false;
			}
			if (this.props == null && log)
			{
				Debug.LogError("Muscle " + this.joint.name + " props is null");
			}
			return true;
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600024D RID: 589 RVA: 0x0000C817 File Offset: 0x0000AA17
		// (set) Token: 0x0600024E RID: 590 RVA: 0x0000C81F File Offset: 0x0000AA1F
		public Rigidbody rebuildConnectedBody { get; private set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600024F RID: 591 RVA: 0x0000C828 File Offset: 0x0000AA28
		// (set) Token: 0x06000250 RID: 592 RVA: 0x0000C830 File Offset: 0x0000AA30
		public Transform rebuildTargetParent { get; private set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000251 RID: 593 RVA: 0x0000C839 File Offset: 0x0000AA39
		// (set) Token: 0x06000252 RID: 594 RVA: 0x0000C841 File Offset: 0x0000AA41
		public Vector3 defaultTargetPosRelToMuscle { get; private set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000253 RID: 595 RVA: 0x0000C84A File Offset: 0x0000AA4A
		// (set) Token: 0x06000254 RID: 596 RVA: 0x0000C852 File Offset: 0x0000AA52
		public Quaternion defaultTargetRotRelToMuscle { get; private set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000255 RID: 597 RVA: 0x0000C85B File Offset: 0x0000AA5B
		// (set) Token: 0x06000256 RID: 598 RVA: 0x0000C863 File Offset: 0x0000AA63
		public Quaternion defaultMuscleRotRelToTarget { get; private set; }

		// Token: 0x06000257 RID: 599 RVA: 0x0000C86C File Offset: 0x0000AA6C
		public void Rebuild()
		{
			this.joint.transform.parent = this.rebuildParent;
			this.target.parent = this.rebuildTargetParent;
			this.joint.transform.position = this.rebuildPosition;
			this.joint.transform.rotation = this.rebuildRotation;
			this.target.position = this.rebuildTargetPosition;
			this.target.rotation = this.rebuildTargetRotation;
			this.joint.angularXMotion = this.rebuildAngularXMotion;
			this.joint.angularYMotion = this.rebuildAngularYMotion;
			this.joint.angularZMotion = this.rebuildAngularZMotion;
			this.state = Muscle.State.Default;
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0000C92C File Offset: 0x0000AB2C
		public void RebuildMT()
		{
			this.joint.transform.parent = this.rebuildParent;
			this.joint.transform.position = this.rebuildPosition;
			this.joint.transform.rotation = this.rebuildRotation;
			this.joint.angularXMotion = this.rebuildAngularXMotion;
			this.joint.angularYMotion = this.rebuildAngularYMotion;
			this.joint.angularZMotion = this.rebuildAngularZMotion;
			this.state = Muscle.State.Default;
		}

		// Token: 0x06000259 RID: 601 RVA: 0x0000C9BC File Offset: 0x0000ABBC
		public virtual void Initiate(Muscle[] colleagues)
		{
			this.initiated = false;
			if (!this.IsValid(true))
			{
				return;
			}
			this.name = this.joint.name;
			this.state = Muscle.State.Default;
			if (this.joint.connectedBody != null)
			{
				for (int i = 0; i < colleagues.Length; i++)
				{
					if (colleagues[i].joint.GetComponent<Rigidbody>() == this.joint.connectedBody)
					{
						this.connectedBodyTarget = colleagues[i].target;
					}
				}
			}
			this.transform = this.joint.transform;
			this.rigidbody = this.transform.GetComponent<Rigidbody>();
			this.InitiateAdditionalPin();
			this.SetKinematic(false);
			this.UpdateColliders();
			if (this._colliders.Length == 0)
			{
				Vector3 size = Vector3.one * 0.1f;
				Renderer component = this.transform.GetComponent<Renderer>();
				if (component != null)
				{
					size = component.bounds.size;
				}
				this.rigidbody.inertiaTensor = PhysXTools.CalculateInertiaTensorCuboid(size, this.rigidbody.mass);
			}
			this.targetParent = ((this.connectedBodyTarget != null) ? this.connectedBodyTarget : this.target.parent);
			this.rebuildConnectedBody = this.joint.connectedBody;
			this.rebuildTargetParent = this.target.parent;
			this.rebuildParent = this.joint.transform.parent;
			this.rebuildPosition = this.joint.transform.position;
			this.rebuildRotation = this.joint.transform.rotation;
			this.rebuildTargetPosition = this.target.position;
			this.rebuildTargetRotation = this.target.rotation;
			this.rebuildAngularXMotion = this.joint.angularXMotion;
			this.rebuildAngularYMotion = this.joint.angularYMotion;
			this.rebuildAngularZMotion = this.joint.angularZMotion;
			this.defaultLocalRotation = this.localRotation;
			Vector3 normalized = Vector3.Cross(this.joint.axis, this.joint.secondaryAxis).normalized;
			Vector3 normalized2 = Vector3.Cross(normalized, this.joint.axis).normalized;
			if (normalized == normalized2)
			{
				Debug.LogError("Joint " + this.joint.name + " secondaryAxis is in the exact same direction as its axis. Please make sure they are not aligned.");
				return;
			}
			this.rotationRelativeToTarget = Quaternion.Inverse(this.target.rotation) * this.transform.rotation;
			this.defaultTargetPosRelToMuscle = this.transform.InverseTransformPoint(this.target.position);
			this.defaultTargetRotRelToMuscle = Quaternion.Inverse(this.transform.rotation) * this.target.rotation;
			this.defaultTargetRotRelToMuscleInverse = Quaternion.Inverse(this.defaultTargetRotRelToMuscle);
			this.defaultMuscleRotRelToTarget = QuaTools.FromToRotation(this.target.rotation, this.transform.rotation);
			Quaternion quaternion = Quaternion.LookRotation(normalized, normalized2);
			this.toJointSpaceInverse = Quaternion.Inverse(quaternion);
			this.toJointSpaceDefault = this.defaultLocalRotation * quaternion;
			this.toParentSpace = Quaternion.Inverse(this.targetParentRotation) * this.parentRotation;
			this.localRotationConvert = Quaternion.Inverse(this.targetLocalRotation) * this.localRotation;
			if (this.joint.connectedBody != null)
			{
				this.joint.autoConfigureConnectedAnchor = false;
				this.connectedBodyTransform = this.joint.connectedBody.transform;
				this.directTargetParent = (this.target.parent == this.connectedBodyTarget);
				this.UpdateAnchor(true);
			}
			this.angularXMotionDefault = this.joint.angularXMotion;
			this.angularYMotionDefault = this.joint.angularYMotion;
			this.angularZMotionDefault = this.joint.angularZMotion;
			this.targetRotationRelative = Quaternion.Inverse(this.rigidbody.transform.rotation) * this.target.rotation;
			if (this.joint.connectedBody == null)
			{
				this.defaultPosition = this.transform.localPosition;
				this.defaultRotation = this.transform.localRotation;
			}
			else
			{
				this.defaultPosition = this.joint.connectedBody.transform.InverseTransformPoint(this.transform.position);
				this.defaultRotation = Quaternion.Inverse(this.joint.connectedBody.transform.rotation) * this.transform.rotation;
			}
			this.defaultTargetLocalPosition = this.target.localPosition;
			this.defaultTargetLocalRotation = this.target.localRotation;
			this.joint.rotationDriveMode = RotationDriveMode.Slerp;
			if (!this.joint.gameObject.activeInHierarchy)
			{
				Debug.LogError("Can not initiate a puppet that has deactivated muscles.", this.joint.transform);
				return;
			}
			this.joint.configuredInWorldSpace = false;
			this.joint.projectionMode = JointProjectionMode.None;
			if (this.joint.anchor != Vector3.zero)
			{
				Debug.LogError("PuppetMaster joint anchors need to be Vector3.zero. Joint axis on " + this.transform.name + " is " + this.joint.anchor.ToString(), this.transform);
				return;
			}
			this.targetAnimatedPosition = this.target.position;
			this.targetAnimatedCenterOfMass = this.rigidbody.worldCenterOfMass;
			this.targetAnimatedWorldRotation = this.target.rotation;
			this.targetAnimatedRotation = this.targetLocalRotation * this.localRotationConvert;
			this.Read();
			this.lastReadTime = Time.time;
			this.lastWriteTime = Time.time;
			this.lastMappedPosition = this.target.position;
			this.lastMappedRotation = this.target.rotation;
			this.targetChildren = new Muscle.TargetChild[this.props.animatedTargetChildren.Length];
			for (int j = 0; j < this.targetChildren.Length; j++)
			{
				this.targetChildren[j] = new Muscle.TargetChild(this.props.animatedTargetChildren[j]);
			}
			this.initiated = true;
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0000D008 File Offset: 0x0000B208
		public void InitiateAdditionalPin()
		{
			if (this.additionalPin != null)
			{
				this.additionalRigidbody = this.additionalPin.GetComponent<Rigidbody>();
				this.additionalPinTargetAnimatedCenterOfMass = this.additionalRigidbody.worldCenterOfMass;
				this.additionalRigidbody.inertiaTensor = PhysXTools.CalculateInertiaTensorCuboid(Vector3.one * 0.1f, this.additionalRigidbody.mass);
			}
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0000D070 File Offset: 0x0000B270
		public void UpdateColliders()
		{
			this._colliders = new Collider[0];
			this.AddColliders(this.joint.transform, ref this._colliders, true);
			int childCount = this.joint.transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				this.AddCompoundColliders(this.joint.transform.GetChild(i), ref this._colliders);
			}
			this.disabledColliders = new bool[this._colliders.Length];
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0000D0F0 File Offset: 0x0000B2F0
		public void DisableColliders()
		{
			for (int i = 0; i < this.colliders.Length; i++)
			{
				if (this.disabledColliders[i])
				{
					return;
				}
			}
			for (int j = 0; j < this._colliders.Length; j++)
			{
				this.disabledColliders[j] = this._colliders[j].enabled;
				this._colliders[j].enabled = false;
			}
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0000D154 File Offset: 0x0000B354
		public void EnableColliders()
		{
			for (int i = 0; i < this._colliders.Length; i++)
			{
				if (this.disabledColliders[i])
				{
					this._colliders[i].enabled = true;
				}
				this.disabledColliders[i] = false;
			}
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0000D198 File Offset: 0x0000B398
		private void AddColliders(Transform t, ref Collider[] C, bool includeMeshColliders)
		{
			Collider[] components = t.GetComponents<Collider>();
			int num = 0;
			foreach (Collider collider in components)
			{
				bool flag = collider is MeshCollider;
				if (!collider.isTrigger && (!includeMeshColliders || !flag))
				{
					num++;
				}
			}
			if (num == 0)
			{
				return;
			}
			int num2 = C.Length;
			Array.Resize<Collider>(ref C, num2 + num);
			int num3 = 0;
			for (int j = 0; j < components.Length; j++)
			{
				bool flag2 = components[j] is MeshCollider;
				if (!components[j].isTrigger && (!includeMeshColliders || !flag2))
				{
					C[num2 + num3] = components[j];
					num3++;
				}
			}
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0000D23C File Offset: 0x0000B43C
		private void AddCompoundColliders(Transform t, ref Collider[] colliders)
		{
			if (t.GetComponent<Rigidbody>() != null)
			{
				return;
			}
			this.AddColliders(t, ref colliders, false);
			int childCount = t.childCount;
			for (int i = 0; i < childCount; i++)
			{
				this.AddCompoundColliders(t.GetChild(i), ref colliders);
			}
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0000D284 File Offset: 0x0000B484
		public void IgnoreInternalCollisions(Muscle m)
		{
			if (m == this)
			{
				return;
			}
			if (this.state.isDisconnected || m.state.isDisconnected)
			{
				return;
			}
			foreach (Collider collider in this.colliders)
			{
				foreach (Collider collider2 in m.colliders)
				{
					if (collider != null && collider2 != null && collider.enabled && collider2.enabled && collider.gameObject.activeInHierarchy && collider2.gameObject.activeInHierarchy)
					{
						Physics.IgnoreCollision(collider, collider2);
					}
				}
			}
		}

		// Token: 0x06000261 RID: 609 RVA: 0x0000D330 File Offset: 0x0000B530
		public void ResetInternalCollisions(Muscle m, bool useInternalCollisionIgnores)
		{
			if (m == this)
			{
				return;
			}
			bool flag = useInternalCollisionIgnores && this.ForceIgnore(m);
			foreach (Collider collider in this.colliders)
			{
				foreach (Collider collider2 in m.colliders)
				{
					if (collider != null && collider2 != null && collider.enabled && collider2.enabled && collider.gameObject.activeInHierarchy && collider2.gameObject.activeInHierarchy)
					{
						if (!flag)
						{
							Physics.IgnoreCollision(collider, collider2, false);
						}
						else
						{
							Physics.IgnoreCollision(collider, collider2, true);
						}
					}
				}
			}
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0000D3E8 File Offset: 0x0000B5E8
		private bool ForceIgnore(Muscle otherMuscle)
		{
			if (this.state.isDisconnected)
			{
				return false;
			}
			if (otherMuscle.state.isDisconnected)
			{
				return false;
			}
			if (this.props.internalCollisionIgnores.ignoreAll || otherMuscle.props.internalCollisionIgnores.ignoreAll)
			{
				return true;
			}
			ConfigurableJoint[] muscles = this.props.internalCollisionIgnores.muscles;
			for (int i = 0; i < muscles.Length; i++)
			{
				if (muscles[i] == otherMuscle.joint)
				{
					return true;
				}
			}
			Muscle.Group[] groups = this.props.internalCollisionIgnores.groups;
			for (int i = 0; i < groups.Length; i++)
			{
				if (groups[i] == otherMuscle.props.group)
				{
					return true;
				}
			}
			muscles = otherMuscle.props.internalCollisionIgnores.muscles;
			for (int i = 0; i < muscles.Length; i++)
			{
				if (muscles[i] == this.joint)
				{
					return true;
				}
			}
			groups = otherMuscle.props.internalCollisionIgnores.groups;
			for (int i = 0; i < groups.Length; i++)
			{
				if (groups[i] == this.props.group)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0000D500 File Offset: 0x0000B700
		public void IgnoreAngularLimits(bool ignore)
		{
			if (!this.initiated)
			{
				return;
			}
			this.joint.angularXMotion = (ignore ? ConfigurableJointMotion.Free : this.angularXMotionDefault);
			this.joint.angularYMotion = (ignore ? ConfigurableJointMotion.Free : this.angularYMotionDefault);
			this.joint.angularZMotion = (ignore ? ConfigurableJointMotion.Free : this.angularZMotionDefault);
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0000D55B File Offset: 0x0000B75B
		public void ResetTargetLocalPosition()
		{
			this.target.localPosition = this.defaultTargetLocalPosition;
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0000D56E File Offset: 0x0000B76E
		public void FixTargetTransforms()
		{
			if (!this.initiated)
			{
				return;
			}
			this.target.localPosition = this.defaultTargetLocalPosition;
			this.target.localRotation = this.defaultTargetLocalRotation;
		}

		// Token: 0x06000266 RID: 614 RVA: 0x0000D59C File Offset: 0x0000B79C
		public void Reset()
		{
			if (!this.initiated)
			{
				return;
			}
			if (this.joint == null)
			{
				return;
			}
			if (this.state.isDisconnected)
			{
				return;
			}
			if (this.joint.connectedBody == null)
			{
				this.transform.localPosition = this.defaultPosition;
				this.transform.localRotation = this.defaultRotation;
			}
			else
			{
				this.transform.position = this.joint.connectedBody.transform.TransformPoint(this.defaultPosition);
				this.transform.rotation = this.joint.connectedBody.transform.rotation * this.defaultRotation;
			}
			this.lastRotationDamper = -1f;
		}

		// Token: 0x06000267 RID: 615 RVA: 0x0000D664 File Offset: 0x0000B864
		public void MoveToTarget()
		{
			if (!this.initiated)
			{
				return;
			}
			if (this.state.isDisconnected)
			{
				return;
			}
			Vector3 position = this.target.position;
			Quaternion quaternion = this.target.rotation * this.rotationRelativeToTarget;
			this.transform.SetPositionAndRotation(position, quaternion);
			this.rigidbody.MovePosition(position);
			this.rigidbody.MoveRotation(quaternion);
			this.positionOffset = Vector3.zero;
			if (this.additionalPin != null)
			{
				this.additionalPin.transform.position = this.additionalPinTarget.position;
			}
		}

		// Token: 0x06000268 RID: 616 RVA: 0x0000D704 File Offset: 0x0000B904
		public void SetKinematic(bool to)
		{
			if (to)
			{
				this.rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
			}
			this.rigidbody.isKinematic = to;
			if (this.additionalPin != null)
			{
				this.additionalRigidbody.isKinematic = to;
			}
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0000D73C File Offset: 0x0000B93C
		public void Read()
		{
			if (this.state.isDisconnected)
			{
				return;
			}
			float num = Time.time - this.lastReadTime;
			this.lastReadTime = Time.time;
			Vector3 a = V3Tools.TransformPointUnscaled(this.target, this.defaultTargetRotRelToMuscleInverse * this.rigidbody.centerOfMass);
			if (num > 0f && !this.ignoreTargetVelocity)
			{
				this.targetVelocity = (a - this.targetAnimatedCenterOfMass) / num;
			}
			this.targetAnimatedCenterOfMass = a;
			this.targetAnimatedPosition = this.target.position;
			this.targetAnimatedWorldRotation = this.target.rotation;
			if (this.additionalPin != null)
			{
				Vector3 a2 = V3Tools.TransformPointUnscaled(this.additionalPinTarget, this.additionalRigidbody.centerOfMass);
				if (num > 0f && !this.ignoreTargetVelocity)
				{
					this.additionalTargetVelocity = (a2 - this.additionalPinTargetAnimatedCenterOfMass) / num;
				}
				this.additionalPinTargetAnimatedCenterOfMass = a2;
			}
			if (this.joint.connectedBody != null)
			{
				this.targetAnimatedRotation = this.targetLocalRotation * this.localRotationConvert;
			}
		}

		// Token: 0x0600026A RID: 618 RVA: 0x0000D860 File Offset: 0x0000BA60
		public void ClearVelocities()
		{
			this.targetVelocity = Vector3.zero;
			this.mappedVelocity = Vector3.zero;
			this.mappedAngularVelocity = Vector3.zero;
			this.additionalTargetVelocity = Vector3.zero;
			this.targetAnimatedCenterOfMass = V3Tools.TransformPointUnscaled(this.target, this.rigidbody.centerOfMass);
			this.targetAnimatedPosition = this.target.position;
			this.targetAnimatedWorldRotation = this.target.rotation;
			this.lastMappedPosition = this.target.position;
			this.lastMappedRotation = this.target.rotation;
			if (this.additionalPin != null)
			{
				this.additionalPinTargetAnimatedCenterOfMass = V3Tools.TransformPointUnscaled(this.additionalPinTarget, this.additionalRigidbody.centerOfMass);
			}
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0000D924 File Offset: 0x0000BB24
		public void UpdateAnchor(bool supportTranslationAnimation)
		{
			if (this.joint.connectedBody == null || this.connectedBodyTarget == null)
			{
				return;
			}
			if (this.directTargetParent && !supportTranslationAnimation)
			{
				return;
			}
			if (this.state.isDisconnected)
			{
				return;
			}
			Vector3 a = this.joint.connectedAnchor = Muscle.InverseTransformPointUnscaled(this.connectedBodyTarget.position, this.connectedBodyTarget.rotation * this.toParentSpace, this.target.position);
			float d = 1f / this.connectedBodyTransform.lossyScale.x;
			this.joint.connectedAnchor = a * d;
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0000D9D8 File Offset: 0x0000BBD8
		public virtual void Update(float pinWeightMaster, float muscleWeightMaster, float muscleSpring, float muscleDamper, float pinPow, float pinDistanceFalloff, bool rotationTargetChanged, bool angularPinning, float deltaTime)
		{
			this.state.velocity = this.rigidbody.velocity;
			this.state.angularVelocity = this.rigidbody.angularVelocity;
			if (this.state.isDisconnected)
			{
				this.state.pinWeightMlp = 0f;
				this.state.muscleWeightMlp = 0f;
				this.state.muscleDamperAdd = 0f;
				this.state.muscleDamperMlp = 0f;
				this.state.mappingWeightMlp = 0f;
				this.state.maxForceMlp = 0f;
				this.state.immunity = 0f;
				this.state.impulseMlp = 1f;
			}
			this.props.Clamp();
			this.state.Clamp();
			this.Pin(pinWeightMaster, pinPow, pinDistanceFalloff, angularPinning, deltaTime);
			if (rotationTargetChanged)
			{
				this.MuscleRotation(muscleWeightMaster, muscleSpring, muscleDamper);
			}
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000DAD4 File Offset: 0x0000BCD4
		public void StoreTargetMappedPosition()
		{
			this.targetMappedPosition = this.target.position;
		}

		// Token: 0x0600026E RID: 622 RVA: 0x0000DAE7 File Offset: 0x0000BCE7
		public void StoreTargetMappedRotation()
		{
			this.targetMappedRotation = this.target.rotation;
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0000DAFC File Offset: 0x0000BCFC
		public void Map(float mappingWeightMaster)
		{
			float num = this.props.mappingWeight * mappingWeightMaster * this.state.mappingWeightMlp;
			if (num <= 0f)
			{
				return;
			}
			Vector3 position = this.transform.position;
			Quaternion rotation = this.transform.rotation;
			Quaternion rotation2;
			Vector3 position2;
			if (num >= 1f)
			{
				rotation2 = rotation * this.targetRotationRelative;
				position2 = position;
				if (this.connectedBodyTransform != null)
				{
					Vector3 point = Muscle.InverseTransformPointUnscaled(this.connectedBodyTransform.position, this.connectedBodyTransform.rotation, position);
					position2 = this.connectedBodyTarget.position + this.connectedBodyTarget.rotation * point;
				}
				this.target.SetPositionAndRotation(position2, rotation2);
				return;
			}
			rotation2 = Quaternion.Lerp(this.target.rotation, rotation * this.targetRotationRelative, num);
			if (this.connectedBodyTransform != null)
			{
				Vector3 point2 = Muscle.InverseTransformPointUnscaled(this.connectedBodyTransform.position, this.connectedBodyTransform.rotation, position);
				position2 = Vector3.Lerp(this.target.position, this.connectedBodyTarget.position + this.connectedBodyTarget.rotation * point2, num);
			}
			else
			{
				position2 = Vector3.Lerp(this.target.position, position, num);
			}
			this.target.SetPositionAndRotation(position2, rotation2);
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0000DC64 File Offset: 0x0000BE64
		public void CalculateMappedVelocity()
		{
			float num = Time.time - this.lastWriteTime;
			if (num > 0f)
			{
				this.mappedVelocity = (this.target.position - this.lastMappedPosition) / num;
				this.mappedAngularVelocity = PhysXTools.GetAngularVelocity(this.lastMappedRotation, this.target.rotation, num);
				this.lastWriteTime = Time.time;
			}
			this.lastMappedPosition = this.target.position;
			this.lastMappedRotation = this.target.rotation;
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0000DCF4 File Offset: 0x0000BEF4
		public void MapDisconnected()
		{
			if (!this.state.isDisconnected)
			{
				return;
			}
			if (this.isPropMuscle)
			{
				return;
			}
			this.target.position = this.transform.TransformPoint(this.defaultTargetPosRelToMuscle);
			this.target.rotation = this.transform.rotation * this.defaultTargetRotRelToMuscle;
			Muscle.TargetChild[] array = this.targetChildren;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Map();
			}
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0000DD74 File Offset: 0x0000BF74
		private void Pin(float pinWeightMaster, float pinPow, float pinDistanceFalloff, bool angularPinning, float deltaTime)
		{
			this.positionOffset = this.targetAnimatedCenterOfMass - this.rigidbody.worldCenterOfMass;
			if (float.IsNaN(this.positionOffset.x))
			{
				this.positionOffset = Vector3.zero;
			}
			float num = pinWeightMaster * this.props.pinWeight * this.state.pinWeightMlp;
			if (num <= 0f)
			{
				return;
			}
			num = Mathf.Pow(num, pinPow);
			this.Pin(this.rigidbody, this.positionOffset, this.targetVelocity, num, pinDistanceFalloff, deltaTime);
			if (angularPinning)
			{
				Vector3 vector = PhysXTools.GetAngularAcceleration(this.rigidbody.rotation, this.defaultMuscleRotRelToTarget * this.targetAnimatedWorldRotation);
				vector -= this.rigidbody.angularVelocity;
				vector *= num;
				this.rigidbody.AddTorque(vector, ForceMode.VelocityChange);
			}
			if (this.additionalPin != null)
			{
				Vector3 vector2 = Vector3.zero;
				vector2 = this.additionalPinTargetAnimatedCenterOfMass - this.additionalRigidbody.worldCenterOfMass;
				if (float.IsNaN(vector2.x))
				{
					vector2 = Vector3.zero;
				}
				this.Pin(this.additionalRigidbody, vector2, this.additionalTargetVelocity, num * this.additionalPinWeight, pinDistanceFalloff, deltaTime);
			}
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000DEAC File Offset: 0x0000C0AC
		private void Pin(Rigidbody r, Vector3 posOffset, Vector3 targetVel, float w, float pinDistanceFalloff, float deltaTime)
		{
			Vector3 vector = posOffset;
			if (deltaTime > 0f)
			{
				vector /= deltaTime;
			}
			if (this.ignoreTargetVelocity)
			{
				targetVel = Vector3.zero;
			}
			Vector3 vector2 = -r.velocity + targetVel + vector;
			if (r.useGravity)
			{
				vector2 -= Physics.gravity * deltaTime;
			}
			vector2 *= w;
			if (pinDistanceFalloff > 0f)
			{
				vector2 /= 1f + posOffset.sqrMagnitude * pinDistanceFalloff;
			}
			r.AddForce(vector2, ForceMode.VelocityChange);
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0000DF40 File Offset: 0x0000C140
		private void MuscleRotation(float muscleWeightMaster, float muscleSpring, float muscleDamper)
		{
			float num = muscleWeightMaster * this.props.muscleWeight * muscleSpring * this.state.muscleWeightMlp * 10f;
			if (this.joint.connectedBody == null)
			{
				num = 0f;
			}
			else if (num > 0f)
			{
				this.joint.targetRotation = this.LocalToJointSpace(this.targetAnimatedRotation);
			}
			float num2 = this.props.muscleDamper * muscleDamper * this.state.muscleDamperMlp + this.state.muscleDamperAdd;
			if (num == this.lastJointDriveRotationWeight && num2 == this.lastRotationDamper)
			{
				return;
			}
			this.lastJointDriveRotationWeight = num;
			this.lastRotationDamper = num2;
			this.slerpDrive.positionSpring = num;
			this.slerpDrive.maximumForce = Mathf.Max(num, num2) * this.state.maxForceMlp;
			this.slerpDrive.positionDamper = num2;
			this.joint.slerpDrive = this.slerpDrive;
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0000E038 File Offset: 0x0000C238
		public void SetMuscleRotation(float muscleWeightMaster, float muscleSpring, float muscleDamper)
		{
			float num = muscleWeightMaster * this.props.muscleWeight * muscleSpring * 10f;
			if (this.joint.connectedBody == null)
			{
				num = 0f;
			}
			else if (num > 0f)
			{
				this.joint.targetRotation = this.LocalToJointSpace(this.targetAnimatedRotation);
			}
			float num2 = this.props.muscleDamper * muscleDamper;
			this.slerpDrive.positionSpring = num;
			this.slerpDrive.maximumForce = Mathf.Max(num, num2);
			this.slerpDrive.positionDamper = num2;
			this.joint.slerpDrive = this.slerpDrive;
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000276 RID: 630 RVA: 0x0000E0DE File Offset: 0x0000C2DE
		private Quaternion localRotation
		{
			get
			{
				return Quaternion.Inverse(this.parentRotation) * this.transform.rotation;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000277 RID: 631 RVA: 0x0000E0FC File Offset: 0x0000C2FC
		private Quaternion parentRotation
		{
			get
			{
				if (this.joint.connectedBody != null)
				{
					return this.joint.connectedBody.rotation;
				}
				if (this.transform.parent == null)
				{
					return Quaternion.identity;
				}
				return this.transform.parent.rotation;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000278 RID: 632 RVA: 0x0000E156 File Offset: 0x0000C356
		private Quaternion targetParentRotation
		{
			get
			{
				if (this.targetParent == null)
				{
					return Quaternion.identity;
				}
				return this.targetParent.rotation;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000279 RID: 633 RVA: 0x0000E177 File Offset: 0x0000C377
		private Quaternion targetLocalRotation
		{
			get
			{
				return Quaternion.Inverse(this.targetParentRotation * this.toParentSpace) * this.target.rotation;
			}
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0000E19F File Offset: 0x0000C39F
		private Quaternion LocalToJointSpace(Quaternion localRotation)
		{
			return this.toJointSpaceInverse * Quaternion.Inverse(localRotation) * this.toJointSpaceDefault;
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0000E1BD File Offset: 0x0000C3BD
		private static Vector3 InverseTransformPointUnscaled(Vector3 position, Quaternion rotation, Vector3 point)
		{
			return Quaternion.Inverse(rotation) * (point - position);
		}

		// Token: 0x040001F8 RID: 504
		[HideInInspector]
		public string name;

		// Token: 0x040001F9 RID: 505
		public ConfigurableJoint joint;

		// Token: 0x040001FA RID: 506
		public Transform target;

		// Token: 0x040001FB RID: 507
		public Muscle.Props props = new Muscle.Props();

		// Token: 0x040001FC RID: 508
		public Muscle.State state = Muscle.State.Default;

		// Token: 0x040001FD RID: 509
		[HideInInspector]
		public int[] parentIndexes = new int[0];

		// Token: 0x040001FE RID: 510
		[HideInInspector]
		public int[] childIndexes = new int[0];

		// Token: 0x040001FF RID: 511
		[HideInInspector]
		public bool[] childFlags = new bool[0];

		// Token: 0x04000200 RID: 512
		[HideInInspector]
		public int[] kinshipDegrees = new int[0];

		// Token: 0x04000201 RID: 513
		[HideInInspector]
		public MuscleCollisionBroadcaster broadcaster;

		// Token: 0x04000202 RID: 514
		[HideInInspector]
		public JointBreakBroadcaster jointBreakBroadcaster;

		// Token: 0x04000203 RID: 515
		[HideInInspector]
		public Vector3 positionOffset;

		// Token: 0x0400020B RID: 523
		[HideInInspector]
		public ConfigurableJoint additionalPin;

		// Token: 0x0400020C RID: 524
		[HideInInspector]
		public Transform additionalPinTarget;

		// Token: 0x0400020D RID: 525
		[HideInInspector]
		public float additionalPinWeight;

		// Token: 0x0400020E RID: 526
		[HideInInspector]
		public Vector3 mappedVelocity;

		// Token: 0x0400020F RID: 527
		[HideInInspector]
		public Vector3 mappedAngularVelocity;

		// Token: 0x04000210 RID: 528
		[HideInInspector]
		public bool isPropMuscle;

		// Token: 0x04000211 RID: 529
		[HideInInspector]
		public int index = -1;

		// Token: 0x04000218 RID: 536
		private Transform rebuildParent;

		// Token: 0x04000219 RID: 537
		private Vector3 rebuildPosition;

		// Token: 0x0400021A RID: 538
		private Quaternion rebuildRotation = Quaternion.identity;

		// Token: 0x0400021B RID: 539
		private Vector3 rebuildTargetPosition;

		// Token: 0x0400021C RID: 540
		private Quaternion rebuildTargetRotation = Quaternion.identity;

		// Token: 0x0400021D RID: 541
		private ConfigurableJointMotion rebuildAngularXMotion;

		// Token: 0x0400021E RID: 542
		private ConfigurableJointMotion rebuildAngularYMotion;

		// Token: 0x0400021F RID: 543
		private ConfigurableJointMotion rebuildAngularZMotion;

		// Token: 0x04000220 RID: 544
		[HideInInspector]
		public bool ignoreTargetVelocity;

		// Token: 0x04000221 RID: 545
		[HideInInspector]
		public Vector3 targetMappedPosition;

		// Token: 0x04000222 RID: 546
		[HideInInspector]
		public Quaternion targetMappedRotation = Quaternion.identity;

		// Token: 0x04000223 RID: 547
		[HideInInspector]
		public Vector3 targetSampledPosition;

		// Token: 0x04000224 RID: 548
		[HideInInspector]
		public Quaternion targetSampledRotation = Quaternion.identity;

		// Token: 0x04000225 RID: 549
		private JointDrive slerpDrive;

		// Token: 0x04000226 RID: 550
		private float lastJointDriveRotationWeight = -1f;

		// Token: 0x04000227 RID: 551
		private float lastRotationDamper = -1f;

		// Token: 0x04000228 RID: 552
		private Vector3 defaultPosition;

		// Token: 0x04000229 RID: 553
		private Vector3 defaultTargetLocalPosition;

		// Token: 0x0400022A RID: 554
		private Vector3 lastMappedPosition;

		// Token: 0x0400022B RID: 555
		private Quaternion defaultLocalRotation;

		// Token: 0x0400022C RID: 556
		private Quaternion localRotationConvert;

		// Token: 0x0400022D RID: 557
		private Quaternion toParentSpace;

		// Token: 0x0400022E RID: 558
		private Quaternion toJointSpaceInverse;

		// Token: 0x0400022F RID: 559
		private Quaternion toJointSpaceDefault;

		// Token: 0x04000230 RID: 560
		private Quaternion targetAnimatedRotation;

		// Token: 0x04000231 RID: 561
		private Quaternion defaultRotation;

		// Token: 0x04000232 RID: 562
		private Quaternion rotationRelativeToTarget;

		// Token: 0x04000233 RID: 563
		private Quaternion defaultTargetLocalRotation;

		// Token: 0x04000234 RID: 564
		private Quaternion lastMappedRotation;

		// Token: 0x04000235 RID: 565
		private Transform targetParent;

		// Token: 0x04000236 RID: 566
		private Transform connectedBodyTransform;

		// Token: 0x04000237 RID: 567
		private ConfigurableJointMotion angularXMotionDefault;

		// Token: 0x04000238 RID: 568
		private ConfigurableJointMotion angularYMotionDefault;

		// Token: 0x04000239 RID: 569
		private ConfigurableJointMotion angularZMotionDefault;

		// Token: 0x0400023A RID: 570
		private bool directTargetParent;

		// Token: 0x0400023B RID: 571
		private bool initiated;

		// Token: 0x0400023C RID: 572
		private Collider[] _colliders = new Collider[0];

		// Token: 0x0400023D RID: 573
		private float lastReadTime;

		// Token: 0x0400023E RID: 574
		private float lastWriteTime;

		// Token: 0x0400023F RID: 575
		private bool[] disabledColliders = new bool[0];

		// Token: 0x04000240 RID: 576
		private Muscle.TargetChild[] targetChildren = new Muscle.TargetChild[0];

		// Token: 0x04000241 RID: 577
		private Vector3 additionalTargetVelocity;

		// Token: 0x04000242 RID: 578
		private Vector3 targetAnimatedCenterOfMass;

		// Token: 0x04000243 RID: 579
		private Vector3 additionalPinTargetAnimatedCenterOfMass;

		// Token: 0x04000244 RID: 580
		private Quaternion defaultTargetRotRelToMuscleInverse = Quaternion.identity;

		// Token: 0x02000053 RID: 83
		[Serializable]
		public enum Group
		{
			// Token: 0x04000246 RID: 582
			Hips,
			// Token: 0x04000247 RID: 583
			Spine,
			// Token: 0x04000248 RID: 584
			Head,
			// Token: 0x04000249 RID: 585
			Arm,
			// Token: 0x0400024A RID: 586
			Hand,
			// Token: 0x0400024B RID: 587
			Leg,
			// Token: 0x0400024C RID: 588
			Foot,
			// Token: 0x0400024D RID: 589
			Tail,
			// Token: 0x0400024E RID: 590
			Prop
		}

		// Token: 0x02000054 RID: 84
		[Serializable]
		public class InternalCollisionIgnoreSettings
		{
			// Token: 0x0400024F RID: 591
			[Tooltip("If true, internal collisions between this muscle and all other muscles will be ingored.")]
			public bool ignoreAll;

			// Token: 0x04000250 RID: 592
			[Tooltip("Ignore internal collisions with all muscles in this array.")]
			public ConfigurableJoint[] muscles = new ConfigurableJoint[0];

			// Token: 0x04000251 RID: 593
			[Tooltip("Ignore internal collisions with all these groups.")]
			public Muscle.Group[] groups = new Muscle.Group[0];
		}

		// Token: 0x02000055 RID: 85
		[Serializable]
		public class Props
		{
			// Token: 0x17000041 RID: 65
			// (get) Token: 0x0600027E RID: 638 RVA: 0x0000E2C5 File Offset: 0x0000C4C5
			// (set) Token: 0x0600027F RID: 639 RVA: 0x0000E2C8 File Offset: 0x0000C4C8
			public bool mapPosition
			{
				get
				{
					return true;
				}
				set
				{
					Debug.LogWarning("Setting Muscle.mapPosition is deprecated. MapPosition is forced to enabled since PuppetMaster v1.0");
				}
			}

			// Token: 0x06000280 RID: 640 RVA: 0x0000E2D4 File Offset: 0x0000C4D4
			public Props()
			{
				this.mappingWeight = 1f;
				this.pinWeight = 1f;
				this.muscleWeight = 1f;
				this.muscleDamper = 1f;
			}

			// Token: 0x06000281 RID: 641 RVA: 0x0000E358 File Offset: 0x0000C558
			public Props(float pinWeight, float muscleWeight, float mappingWeight, float muscleDamper, Muscle.Group group = Muscle.Group.Hips)
			{
				this.pinWeight = pinWeight;
				this.muscleWeight = muscleWeight;
				this.mappingWeight = mappingWeight;
				this.muscleDamper = muscleDamper;
				this.group = group;
			}

			// Token: 0x06000282 RID: 642 RVA: 0x0000E3D4 File Offset: 0x0000C5D4
			public void Clamp()
			{
				this.mappingWeight = Mathf.Clamp(this.mappingWeight, 0f, 1f);
				this.pinWeight = Mathf.Clamp(this.pinWeight, 0f, 1f);
				this.muscleWeight = Mathf.Clamp(this.muscleWeight, 0f, 1f);
				this.muscleDamper = Mathf.Clamp(this.muscleDamper, 0f, 1f);
			}

			// Token: 0x04000252 RID: 594
			[Tooltip("Which body part does this muscle belong to?")]
			public Muscle.Group group;

			// Token: 0x04000253 RID: 595
			[Tooltip("The weight (multiplier) of mapping this muscle's target to the muscle.")]
			[Range(0f, 1f)]
			public float mappingWeight = 1f;

			// Token: 0x04000254 RID: 596
			[Tooltip("The weight (multiplier) of pinning this muscle to its target's position using a simple AddForce command.")]
			[Range(0f, 1f)]
			public float pinWeight = 1f;

			// Token: 0x04000255 RID: 597
			[Tooltip("The muscle strength (multiplier).")]
			[Range(0f, 1f)]
			public float muscleWeight = 1f;

			// Token: 0x04000256 RID: 598
			[Tooltip("Multiplier of the positionDamper of the ConfigurableJoints' Slerp Drive.")]
			[Range(0f, 1f)]
			public float muscleDamper = 1f;

			// Token: 0x04000257 RID: 599
			[Tooltip("Defines which muscles or muscle groups internal collisions are always ignored with.")]
			public Muscle.InternalCollisionIgnoreSettings internalCollisionIgnores = new Muscle.InternalCollisionIgnoreSettings();

			// Token: 0x04000258 RID: 600
			[Tooltip("List of animated bones parented to this muscle's Target, except for the bones that are targets or target children of any child muscles. This is used for stopping animation on those bones when the muscle has been disconnected using PuppetMaster.DisconnectMuscleRecursive().For example if you disconnected the spine02 muscle, you would want to have spine03 and clavicles in this list to stop them from animating.")]
			public Transform[] animatedTargetChildren = new Transform[0];
		}

		// Token: 0x02000056 RID: 86
		public struct State
		{
			// Token: 0x17000042 RID: 66
			// (get) Token: 0x06000283 RID: 643 RVA: 0x0000E450 File Offset: 0x0000C650
			public static Muscle.State Default
			{
				get
				{
					return new Muscle.State
					{
						mappingWeightMlp = 1f,
						pinWeightMlp = 1f,
						muscleWeightMlp = 1f,
						muscleDamperMlp = 1f,
						muscleDamperAdd = 0f,
						maxForceMlp = 1f,
						immunity = 0f,
						impulseMlp = 1f,
						isDisconnected = false
					};
				}
			}

			// Token: 0x06000284 RID: 644 RVA: 0x0000E4D0 File Offset: 0x0000C6D0
			public void Clamp()
			{
				this.mappingWeightMlp = Mathf.Clamp(this.mappingWeightMlp, 0f, 1f);
				this.pinWeightMlp = Mathf.Clamp(this.pinWeightMlp, 0f, 1f);
				this.muscleWeightMlp = Mathf.Clamp(this.muscleWeightMlp, 0f, this.muscleWeightMlp);
				this.immunity = Mathf.Clamp(this.immunity, 0f, 1f);
				this.impulseMlp = Mathf.Max(this.impulseMlp, 0f);
			}

			// Token: 0x04000259 RID: 601
			public float mappingWeightMlp;

			// Token: 0x0400025A RID: 602
			public float pinWeightMlp;

			// Token: 0x0400025B RID: 603
			public float muscleWeightMlp;

			// Token: 0x0400025C RID: 604
			public float maxForceMlp;

			// Token: 0x0400025D RID: 605
			public float muscleDamperMlp;

			// Token: 0x0400025E RID: 606
			public float muscleDamperAdd;

			// Token: 0x0400025F RID: 607
			public float immunity;

			// Token: 0x04000260 RID: 608
			public float impulseMlp;

			// Token: 0x04000261 RID: 609
			public Vector3 velocity;

			// Token: 0x04000262 RID: 610
			public Vector3 angularVelocity;

			// Token: 0x04000263 RID: 611
			public bool isDisconnected;

			// Token: 0x04000264 RID: 612
			public bool resetFlag;
		}

		// Token: 0x02000057 RID: 87
		public class TargetChild
		{
			// Token: 0x06000285 RID: 645 RVA: 0x0000E560 File Offset: 0x0000C760
			public TargetChild(Transform t)
			{
				this.t = t;
				this.defaultLocalPosition = t.localPosition;
				this.defaultLocalRotation = t.localRotation;
			}

			// Token: 0x06000286 RID: 646 RVA: 0x0000E592 File Offset: 0x0000C792
			public void Map()
			{
				this.t.localPosition = this.defaultLocalPosition;
				this.t.localRotation = this.defaultLocalRotation;
			}

			// Token: 0x04000265 RID: 613
			public Transform t;

			// Token: 0x04000266 RID: 614
			public Vector3 defaultLocalPosition;

			// Token: 0x04000267 RID: 615
			public Quaternion defaultLocalRotation = Quaternion.identity;
		}
	}
}
