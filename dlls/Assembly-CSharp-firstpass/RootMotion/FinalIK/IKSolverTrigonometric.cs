using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000DF RID: 223
	[Serializable]
	public class IKSolverTrigonometric : IKSolver
	{
		// Token: 0x06000744 RID: 1860 RVA: 0x0002CD6C File Offset: 0x0002AF6C
		public void SetBendGoalPosition(Vector3 goalPosition, float weight)
		{
			if (!base.initiated)
			{
				return;
			}
			if (weight <= 0f)
			{
				return;
			}
			Vector3 vector = Vector3.Cross(goalPosition - this.bone1.transform.position, this.IKPosition - this.bone1.transform.position);
			if (vector != Vector3.zero)
			{
				if (weight >= 1f)
				{
					this.bendNormal = vector;
					return;
				}
				this.bendNormal = Vector3.Lerp(this.bendNormal, vector, weight);
			}
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x0002CDF4 File Offset: 0x0002AFF4
		public void SetBendPlaneToCurrent()
		{
			if (!base.initiated)
			{
				return;
			}
			Vector3 lhs = Vector3.Cross(this.bone2.transform.position - this.bone1.transform.position, this.bone3.transform.position - this.bone2.transform.position);
			if (lhs != Vector3.zero)
			{
				this.bendNormal = lhs;
			}
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x0002CE6E File Offset: 0x0002B06E
		public void SetIKRotation(Quaternion rotation)
		{
			this.IKRotation = rotation;
		}

		// Token: 0x06000747 RID: 1863 RVA: 0x0002CE77 File Offset: 0x0002B077
		public void SetIKRotationWeight(float weight)
		{
			this.IKRotationWeight = Mathf.Clamp(weight, 0f, 1f);
		}

		// Token: 0x06000748 RID: 1864 RVA: 0x0002CE8F File Offset: 0x0002B08F
		public Quaternion GetIKRotation()
		{
			return this.IKRotation;
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x0002CE97 File Offset: 0x0002B097
		public float GetIKRotationWeight()
		{
			return this.IKRotationWeight;
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x0002CE9F File Offset: 0x0002B09F
		public override IKSolver.Point[] GetPoints()
		{
			return new IKSolver.Point[]
			{
				this.bone1,
				this.bone2,
				this.bone3
			};
		}

		// Token: 0x0600074B RID: 1867 RVA: 0x0002CEC4 File Offset: 0x0002B0C4
		public override IKSolver.Point GetPoint(Transform transform)
		{
			if (this.bone1.transform == transform)
			{
				return this.bone1;
			}
			if (this.bone2.transform == transform)
			{
				return this.bone2;
			}
			if (this.bone3.transform == transform)
			{
				return this.bone3;
			}
			return null;
		}

		// Token: 0x0600074C RID: 1868 RVA: 0x0002CF20 File Offset: 0x0002B120
		public override void StoreDefaultLocalState()
		{
			this.bone1.StoreDefaultLocalState();
			this.bone2.StoreDefaultLocalState();
			this.bone3.StoreDefaultLocalState();
		}

		// Token: 0x0600074D RID: 1869 RVA: 0x0002CF43 File Offset: 0x0002B143
		public override void FixTransforms()
		{
			if (!base.initiated)
			{
				return;
			}
			this.bone1.FixTransform();
			this.bone2.FixTransform();
			this.bone3.FixTransform();
		}

		// Token: 0x0600074E RID: 1870 RVA: 0x0002CF70 File Offset: 0x0002B170
		public override bool IsValid(ref string message)
		{
			if (this.bone1.transform == null || this.bone2.transform == null || this.bone3.transform == null)
			{
				message = "Please assign all Bones to the IK solver.";
				return false;
			}
			Object[] objects = new Transform[]
			{
				this.bone1.transform,
				this.bone2.transform,
				this.bone3.transform
			};
			Transform transform = (Transform)Hierarchy.ContainsDuplicate(objects);
			if (transform != null)
			{
				message = transform.name + " is represented multiple times in the Bones.";
				return false;
			}
			if (this.bone1.transform.position == this.bone2.transform.position)
			{
				message = "first bone position is the same as second bone position.";
				return false;
			}
			if (this.bone2.transform.position == this.bone3.transform.position)
			{
				message = "second bone position is the same as third bone position.";
				return false;
			}
			return true;
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x0002D07A File Offset: 0x0002B27A
		public bool SetChain(Transform bone1, Transform bone2, Transform bone3, Transform root)
		{
			this.bone1.transform = bone1;
			this.bone2.transform = bone2;
			this.bone3.transform = bone3;
			base.Initiate(root);
			return base.initiated;
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x0002D0B0 File Offset: 0x0002B2B0
		public static void Solve(Transform bone1, Transform bone2, Transform bone3, Vector3 targetPosition, Vector3 bendNormal, float weight)
		{
			if (weight <= 0f)
			{
				return;
			}
			targetPosition = Vector3.Lerp(bone3.position, targetPosition, weight);
			Vector3 vector = targetPosition - bone1.position;
			float magnitude = vector.magnitude;
			if (magnitude == 0f)
			{
				return;
			}
			float sqrMagnitude = (bone2.position - bone1.position).sqrMagnitude;
			float sqrMagnitude2 = (bone3.position - bone2.position).sqrMagnitude;
			Vector3 bendDirection = Vector3.Cross(vector, bendNormal);
			Vector3 directionToBendPoint = IKSolverTrigonometric.GetDirectionToBendPoint(vector, magnitude, bendDirection, sqrMagnitude, sqrMagnitude2);
			Quaternion quaternion = Quaternion.FromToRotation(bone2.position - bone1.position, directionToBendPoint);
			if (weight < 1f)
			{
				quaternion = Quaternion.Lerp(Quaternion.identity, quaternion, weight);
			}
			bone1.rotation = quaternion * bone1.rotation;
			Quaternion quaternion2 = Quaternion.FromToRotation(bone3.position - bone2.position, targetPosition - bone2.position);
			if (weight < 1f)
			{
				quaternion2 = Quaternion.Lerp(Quaternion.identity, quaternion2, weight);
			}
			bone2.rotation = quaternion2 * bone2.rotation;
		}

		// Token: 0x06000751 RID: 1873 RVA: 0x0002D1D8 File Offset: 0x0002B3D8
		private static Vector3 GetDirectionToBendPoint(Vector3 direction, float directionMag, Vector3 bendDirection, float sqrMag1, float sqrMag2)
		{
			float num = (directionMag * directionMag + (sqrMag1 - sqrMag2)) / 2f / directionMag;
			float y = (float)Math.Sqrt((double)Mathf.Clamp(sqrMag1 - num * num, 0f, float.PositiveInfinity));
			if (direction == Vector3.zero)
			{
				return Vector3.zero;
			}
			return Quaternion.LookRotation(direction, bendDirection) * new Vector3(0f, y, num);
		}

		// Token: 0x06000752 RID: 1874 RVA: 0x0002D240 File Offset: 0x0002B440
		protected override void OnInitiate()
		{
			if (this.bendNormal == Vector3.zero)
			{
				this.bendNormal = Vector3.right;
			}
			this.OnInitiateVirtual();
			this.IKPosition = this.bone3.transform.position;
			this.IKRotation = this.bone3.transform.rotation;
			this.InitiateBones();
			this.directHierarchy = this.IsDirectHierarchy();
		}

		// Token: 0x06000753 RID: 1875 RVA: 0x0002D2B0 File Offset: 0x0002B4B0
		private bool IsDirectHierarchy()
		{
			return !(this.bone3.transform.parent != this.bone2.transform) && !(this.bone2.transform.parent != this.bone1.transform);
		}

		// Token: 0x06000754 RID: 1876 RVA: 0x0002D308 File Offset: 0x0002B508
		public void InitiateBones()
		{
			this.bone1.Initiate(this.bone2.transform.position, this.bendNormal);
			this.bone2.Initiate(this.bone3.transform.position, this.bendNormal);
			this.SetBendPlaneToCurrent();
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x0002D360 File Offset: 0x0002B560
		protected override void OnUpdate()
		{
			this.IKPositionWeight = Mathf.Clamp(this.IKPositionWeight, 0f, 1f);
			this.IKRotationWeight = Mathf.Clamp(this.IKRotationWeight, 0f, 1f);
			if (this.target != null)
			{
				this.IKPosition = this.target.position;
				this.IKRotation = this.target.rotation;
			}
			this.OnUpdateVirtual();
			if (this.IKPositionWeight > 0f)
			{
				if (!this.directHierarchy)
				{
					this.bone1.Initiate(this.bone2.transform.position, this.bendNormal);
					this.bone2.Initiate(this.bone3.transform.position, this.bendNormal);
				}
				this.bone1.sqrMag = (this.bone2.transform.position - this.bone1.transform.position).sqrMagnitude;
				this.bone2.sqrMag = (this.bone3.transform.position - this.bone2.transform.position).sqrMagnitude;
				if (this.bendNormal == Vector3.zero && !Warning.logged)
				{
					base.LogWarning("IKSolverTrigonometric Bend Normal is Vector3.zero.");
				}
				this.weightIKPosition = Vector3.Lerp(this.bone3.transform.position, this.IKPosition, this.IKPositionWeight);
				Vector3 vector = Vector3.Lerp(this.bone1.GetBendNormalFromCurrentRotation(), this.bendNormal, this.IKPositionWeight);
				Vector3 vector2 = Vector3.Lerp(this.bone2.transform.position - this.bone1.transform.position, this.GetBendDirection(this.weightIKPosition, vector), this.IKPositionWeight);
				if (vector2 == Vector3.zero)
				{
					vector2 = this.bone2.transform.position - this.bone1.transform.position;
				}
				this.bone1.transform.rotation = this.bone1.GetRotation(vector2, vector);
				this.bone2.transform.rotation = this.bone2.GetRotation(this.weightIKPosition - this.bone2.transform.position, this.bone2.GetBendNormalFromCurrentRotation());
			}
			if (this.IKRotationWeight > 0f)
			{
				this.bone3.transform.rotation = Quaternion.Slerp(this.bone3.transform.rotation, this.IKRotation, this.IKRotationWeight);
			}
			this.OnPostSolveVirtual();
		}

		// Token: 0x06000756 RID: 1878 RVA: 0x0000223E File Offset: 0x0000043E
		protected virtual void OnInitiateVirtual()
		{
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x0000223E File Offset: 0x0000043E
		protected virtual void OnUpdateVirtual()
		{
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x0000223E File Offset: 0x0000043E
		protected virtual void OnPostSolveVirtual()
		{
		}

		// Token: 0x06000759 RID: 1881 RVA: 0x0002D620 File Offset: 0x0002B820
		protected Vector3 GetBendDirection(Vector3 IKPosition, Vector3 bendNormal)
		{
			Vector3 vector = IKPosition - this.bone1.transform.position;
			if (vector == Vector3.zero)
			{
				return Vector3.zero;
			}
			float sqrMagnitude = vector.sqrMagnitude;
			float num = (float)Math.Sqrt((double)sqrMagnitude);
			float num2 = (sqrMagnitude + this.bone1.sqrMag - this.bone2.sqrMag) / 2f / num;
			float y = (float)Math.Sqrt((double)Mathf.Clamp(this.bone1.sqrMag - num2 * num2, 0f, float.PositiveInfinity));
			Vector3 upwards = Vector3.Cross(vector / num, bendNormal);
			return Quaternion.LookRotation(vector, upwards) * new Vector3(0f, y, num2);
		}

		// Token: 0x0400064B RID: 1611
		public Transform target;

		// Token: 0x0400064C RID: 1612
		[Range(0f, 1f)]
		public float IKRotationWeight = 1f;

		// Token: 0x0400064D RID: 1613
		public Quaternion IKRotation = Quaternion.identity;

		// Token: 0x0400064E RID: 1614
		public Vector3 bendNormal = Vector3.right;

		// Token: 0x0400064F RID: 1615
		public IKSolverTrigonometric.TrigonometricBone bone1 = new IKSolverTrigonometric.TrigonometricBone();

		// Token: 0x04000650 RID: 1616
		public IKSolverTrigonometric.TrigonometricBone bone2 = new IKSolverTrigonometric.TrigonometricBone();

		// Token: 0x04000651 RID: 1617
		public IKSolverTrigonometric.TrigonometricBone bone3 = new IKSolverTrigonometric.TrigonometricBone();

		// Token: 0x04000652 RID: 1618
		protected Vector3 weightIKPosition;

		// Token: 0x04000653 RID: 1619
		protected bool directHierarchy = true;

		// Token: 0x020000E0 RID: 224
		[Serializable]
		public class TrigonometricBone : IKSolver.Bone
		{
			// Token: 0x0600075B RID: 1883 RVA: 0x0002D734 File Offset: 0x0002B934
			public void Initiate(Vector3 childPosition, Vector3 bendNormal)
			{
				Quaternion rotation = Quaternion.LookRotation(childPosition - this.transform.position, bendNormal);
				this.targetToLocalSpace = QuaTools.RotationToLocalSpace(this.transform.rotation, rotation);
				this.defaultLocalBendNormal = Quaternion.Inverse(this.transform.rotation) * bendNormal;
			}

			// Token: 0x0600075C RID: 1884 RVA: 0x0002D78C File Offset: 0x0002B98C
			public Quaternion GetRotation(Vector3 direction, Vector3 bendNormal)
			{
				return Quaternion.LookRotation(direction, bendNormal) * this.targetToLocalSpace;
			}

			// Token: 0x0600075D RID: 1885 RVA: 0x0002D7A0 File Offset: 0x0002B9A0
			public Vector3 GetBendNormalFromCurrentRotation()
			{
				return this.transform.rotation * this.defaultLocalBendNormal;
			}

			// Token: 0x04000654 RID: 1620
			private Quaternion targetToLocalSpace;

			// Token: 0x04000655 RID: 1621
			private Vector3 defaultLocalBendNormal;
		}
	}
}
