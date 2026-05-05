using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000D8 RID: 216
	[Serializable]
	public class IKSolverHeuristic : IKSolver
	{
		// Token: 0x060006FA RID: 1786 RVA: 0x0002AA0C File Offset: 0x00028C0C
		public bool SetChain(Transform[] hierarchy, Transform root)
		{
			if (this.bones == null || this.bones.Length != hierarchy.Length)
			{
				this.bones = new IKSolver.Bone[hierarchy.Length];
			}
			for (int i = 0; i < hierarchy.Length; i++)
			{
				if (this.bones[i] == null)
				{
					this.bones[i] = new IKSolver.Bone();
				}
				this.bones[i].transform = hierarchy[i];
			}
			base.Initiate(root);
			return base.initiated;
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x0002AA80 File Offset: 0x00028C80
		public void AddBone(Transform bone)
		{
			Transform[] array = new Transform[this.bones.Length + 1];
			for (int i = 0; i < this.bones.Length; i++)
			{
				array[i] = this.bones[i].transform;
			}
			array[array.Length - 1] = bone;
			this.SetChain(array, this.root);
		}

		// Token: 0x060006FC RID: 1788 RVA: 0x0002AAD8 File Offset: 0x00028CD8
		public override void StoreDefaultLocalState()
		{
			for (int i = 0; i < this.bones.Length; i++)
			{
				this.bones[i].StoreDefaultLocalState();
			}
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x0002AB08 File Offset: 0x00028D08
		public override void FixTransforms()
		{
			if (!base.initiated)
			{
				return;
			}
			if (this.IKPositionWeight <= 0f)
			{
				return;
			}
			for (int i = 0; i < this.bones.Length; i++)
			{
				this.bones[i].FixTransform();
			}
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x0002AB4C File Offset: 0x00028D4C
		public override bool IsValid(ref string message)
		{
			if (this.bones.Length == 0)
			{
				message = "IK chain has no Bones.";
				return false;
			}
			if (this.bones.Length < this.minBones)
			{
				message = "IK chain has less than " + this.minBones.ToString() + " Bones.";
				return false;
			}
			IKSolver.Bone[] array = this.bones;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].transform == null)
				{
					message = "One of the Bones is null.";
					return false;
				}
			}
			Transform transform = IKSolver.ContainsDuplicateBone(this.bones);
			if (transform != null)
			{
				message = transform.name + " is represented multiple times in the Bones.";
				return false;
			}
			if (!this.allowCommonParent && !IKSolver.HierarchyIsValid(this.bones))
			{
				message = "Invalid bone hierarchy detected. IK requires for its bones to be parented to each other in descending order.";
				return false;
			}
			if (!this.boneLengthCanBeZero)
			{
				for (int j = 0; j < this.bones.Length - 1; j++)
				{
					if ((this.bones[j].transform.position - this.bones[j + 1].transform.position).magnitude == 0f)
					{
						message = "Bone " + j.ToString() + " length is zero.";
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x0002AC84 File Offset: 0x00028E84
		public override IKSolver.Point[] GetPoints()
		{
			return this.bones;
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x0002AC9C File Offset: 0x00028E9C
		public override IKSolver.Point GetPoint(Transform transform)
		{
			for (int i = 0; i < this.bones.Length; i++)
			{
				if (this.bones[i].transform == transform)
				{
					return this.bones[i];
				}
			}
			return null;
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06000701 RID: 1793 RVA: 0x0002ACDB File Offset: 0x00028EDB
		protected virtual int minBones
		{
			get
			{
				return 2;
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000702 RID: 1794 RVA: 0x0000E2C5 File Offset: 0x0000C4C5
		protected virtual bool boneLengthCanBeZero
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000703 RID: 1795 RVA: 0x0000631C File Offset: 0x0000451C
		protected virtual bool allowCommonParent
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x0000223E File Offset: 0x0000043E
		protected override void OnInitiate()
		{
		}

		// Token: 0x06000705 RID: 1797 RVA: 0x0000223E File Offset: 0x0000043E
		protected override void OnUpdate()
		{
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x0002ACE0 File Offset: 0x00028EE0
		protected void InitiateBones()
		{
			this.chainLength = 0f;
			for (int i = 0; i < this.bones.Length; i++)
			{
				if (i < this.bones.Length - 1)
				{
					this.bones[i].length = (this.bones[i].transform.position - this.bones[i + 1].transform.position).magnitude;
					this.chainLength += this.bones[i].length;
					Vector3 position = this.bones[i + 1].transform.position;
					this.bones[i].axis = Quaternion.Inverse(this.bones[i].transform.rotation) * (position - this.bones[i].transform.position);
					if (this.bones[i].rotationLimit != null)
					{
						if (this.XY && !(this.bones[i].rotationLimit is RotationLimitHinge))
						{
							Warning.Log("Only Hinge Rotation Limits should be used on 2D IK solvers.", this.bones[i].transform, false);
						}
						this.bones[i].rotationLimit.Disable();
					}
				}
				else
				{
					this.bones[i].axis = Quaternion.Inverse(this.bones[i].transform.rotation) * (this.bones[this.bones.Length - 1].transform.position - this.bones[0].transform.position);
				}
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000707 RID: 1799 RVA: 0x0002AE8C File Offset: 0x0002908C
		protected virtual Vector3 localDirection
		{
			get
			{
				return this.bones[0].transform.InverseTransformDirection(this.bones[this.bones.Length - 1].transform.position - this.bones[0].transform.position);
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000708 RID: 1800 RVA: 0x0002AEDD File Offset: 0x000290DD
		protected float positionOffset
		{
			get
			{
				return Vector3.SqrMagnitude(this.localDirection - this.lastLocalDirection);
			}
		}

		// Token: 0x06000709 RID: 1801 RVA: 0x0002AEF8 File Offset: 0x000290F8
		protected Vector3 GetSingularityOffset()
		{
			if (!this.SingularityDetected())
			{
				return Vector3.zero;
			}
			Vector3 normalized = (this.IKPosition - this.bones[0].transform.position).normalized;
			Vector3 rhs = new Vector3(normalized.y, normalized.z, normalized.x);
			if (this.useRotationLimits && this.bones[this.bones.Length - 2].rotationLimit != null && this.bones[this.bones.Length - 2].rotationLimit is RotationLimitHinge)
			{
				rhs = this.bones[this.bones.Length - 2].transform.rotation * this.bones[this.bones.Length - 2].rotationLimit.axis;
			}
			return Vector3.Cross(normalized, rhs) * this.bones[this.bones.Length - 2].length * 0.5f;
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x0002B000 File Offset: 0x00029200
		private bool SingularityDetected()
		{
			if (!base.initiated)
			{
				return false;
			}
			Vector3 a = this.bones[this.bones.Length - 1].transform.position - this.bones[0].transform.position;
			Vector3 a2 = this.IKPosition - this.bones[0].transform.position;
			float magnitude = a.magnitude;
			float magnitude2 = a2.magnitude;
			return magnitude >= magnitude2 && magnitude >= this.chainLength - this.bones[this.bones.Length - 2].length * 0.1f && magnitude != 0f && magnitude2 != 0f && magnitude2 <= magnitude && Vector3.Dot(a / magnitude, a2 / magnitude2) >= 0.999f;
		}

		// Token: 0x0400060D RID: 1549
		public Transform target;

		// Token: 0x0400060E RID: 1550
		public float tolerance;

		// Token: 0x0400060F RID: 1551
		public int maxIterations = 4;

		// Token: 0x04000610 RID: 1552
		public bool useRotationLimits = true;

		// Token: 0x04000611 RID: 1553
		public bool XY;

		// Token: 0x04000612 RID: 1554
		public IKSolver.Bone[] bones = new IKSolver.Bone[0];

		// Token: 0x04000613 RID: 1555
		protected Vector3 lastLocalDirection;

		// Token: 0x04000614 RID: 1556
		protected float chainLength;
	}
}
