using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000DA RID: 218
	[Serializable]
	public class IKSolverLimb : IKSolverTrigonometric
	{
		// Token: 0x06000719 RID: 1817 RVA: 0x0002B72F File Offset: 0x0002992F
		public void MaintainRotation()
		{
			if (!base.initiated)
			{
				return;
			}
			this.maintainRotation = this.bone3.transform.rotation;
			this.maintainRotationFor1Frame = true;
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x0002B757 File Offset: 0x00029957
		public void MaintainBend()
		{
			if (!base.initiated)
			{
				return;
			}
			this.animationNormal = this.bone1.GetBendNormalFromCurrentRotation();
			this.maintainBendFor1Frame = true;
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x0002B77C File Offset: 0x0002997C
		protected override void OnInitiateVirtual()
		{
			this.defaultRootRotation = this.root.rotation;
			if (this.bone1.transform.parent != null)
			{
				this.parentDefaultRotation = Quaternion.Inverse(this.defaultRootRotation) * this.bone1.transform.parent.rotation;
			}
			if (this.bone3.rotationLimit != null)
			{
				this.bone3.rotationLimit.Disable();
			}
			this.bone3DefaultRotation = this.bone3.transform.rotation;
			Vector3 vector = Vector3.Cross(this.bone2.transform.position - this.bone1.transform.position, this.bone3.transform.position - this.bone2.transform.position);
			if (vector != Vector3.zero)
			{
				this.bendNormal = vector;
			}
			this.animationNormal = this.bendNormal;
			this.StoreAxisDirections(ref this.axisDirectionsLeft);
			this.StoreAxisDirections(ref this.axisDirectionsRight);
		}

		// Token: 0x0600071C RID: 1820 RVA: 0x0002B8A0 File Offset: 0x00029AA0
		protected override void OnUpdateVirtual()
		{
			if (this.IKPositionWeight > 0f)
			{
				this.bendModifierWeight = Mathf.Clamp(this.bendModifierWeight, 0f, 1f);
				this.maintainRotationWeight = Mathf.Clamp(this.maintainRotationWeight, 0f, 1f);
				this._bendNormal = this.bendNormal;
				this.bendNormal = this.GetModifiedBendNormal();
			}
			if (this.maintainRotationWeight * this.IKPositionWeight > 0f)
			{
				this.bone3RotationBeforeSolve = (this.maintainRotationFor1Frame ? this.maintainRotation : this.bone3.transform.rotation);
				this.maintainRotationFor1Frame = false;
			}
		}

		// Token: 0x0600071D RID: 1821 RVA: 0x0002B94C File Offset: 0x00029B4C
		protected override void OnPostSolveVirtual()
		{
			if (this.IKPositionWeight > 0f)
			{
				this.bendNormal = this._bendNormal;
			}
			if (this.maintainRotationWeight * this.IKPositionWeight > 0f)
			{
				this.bone3.transform.rotation = Quaternion.Slerp(this.bone3.transform.rotation, this.bone3RotationBeforeSolve, this.maintainRotationWeight * this.IKPositionWeight);
			}
		}

		// Token: 0x0600071E RID: 1822 RVA: 0x0002B9BE File Offset: 0x00029BBE
		public IKSolverLimb()
		{
		}

		// Token: 0x0600071F RID: 1823 RVA: 0x0002B9E9 File Offset: 0x00029BE9
		public IKSolverLimb(AvatarIKGoal goal)
		{
			this.goal = goal;
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000720 RID: 1824 RVA: 0x0002BA1B File Offset: 0x00029C1B
		private IKSolverLimb.AxisDirection[] axisDirections
		{
			get
			{
				if (this.goal == AvatarIKGoal.LeftHand)
				{
					return this.axisDirectionsLeft;
				}
				return this.axisDirectionsRight;
			}
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x0002BA34 File Offset: 0x00029C34
		private void StoreAxisDirections(ref IKSolverLimb.AxisDirection[] axisDirections)
		{
			axisDirections[0] = new IKSolverLimb.AxisDirection(Vector3.zero, new Vector3(-1f, 0f, 0f));
			axisDirections[1] = new IKSolverLimb.AxisDirection(new Vector3(0.5f, 0f, -0.2f), new Vector3(-0.5f, -1f, 1f));
			axisDirections[2] = new IKSolverLimb.AxisDirection(new Vector3(-0.5f, -1f, -0.2f), new Vector3(0f, 0.5f, -1f));
			axisDirections[3] = new IKSolverLimb.AxisDirection(new Vector3(-0.5f, -0.5f, 1f), new Vector3(-1f, -1f, -1f));
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x0002BB08 File Offset: 0x00029D08
		private Vector3 GetModifiedBendNormal()
		{
			float num = this.bendModifierWeight;
			if (num <= 0f)
			{
				return this.bendNormal;
			}
			switch (this.bendModifier)
			{
			case IKSolverLimb.BendModifier.Animation:
				if (!this.maintainBendFor1Frame)
				{
					this.MaintainBend();
				}
				this.maintainBendFor1Frame = false;
				return Vector3.Lerp(this.bendNormal, this.animationNormal, num);
			case IKSolverLimb.BendModifier.Target:
			{
				Quaternion b = this.IKRotation * Quaternion.Inverse(this.bone3DefaultRotation);
				return Quaternion.Slerp(Quaternion.identity, b, num) * this.bendNormal;
			}
			case IKSolverLimb.BendModifier.Parent:
			{
				if (this.bone1.transform.parent == null)
				{
					return this.bendNormal;
				}
				Quaternion lhs = this.bone1.transform.parent.rotation * Quaternion.Inverse(this.parentDefaultRotation);
				return Quaternion.Slerp(Quaternion.identity, lhs * Quaternion.Inverse(this.defaultRootRotation), num) * this.bendNormal;
			}
			case IKSolverLimb.BendModifier.Arm:
			{
				if (this.bone1.transform.parent == null)
				{
					return this.bendNormal;
				}
				if (this.goal == AvatarIKGoal.LeftFoot || this.goal == AvatarIKGoal.RightFoot)
				{
					if (!Warning.logged)
					{
						base.LogWarning("Trying to use the 'Arm' bend modifier on a leg.");
					}
					return this.bendNormal;
				}
				Vector3 vector = (this.IKPosition - this.bone1.transform.position).normalized;
				vector = Quaternion.Inverse(this.bone1.transform.parent.rotation * Quaternion.Inverse(this.parentDefaultRotation)) * vector;
				if (this.goal == AvatarIKGoal.LeftHand)
				{
					vector.x = -vector.x;
				}
				for (int i = 1; i < this.axisDirections.Length; i++)
				{
					this.axisDirections[i].dot = Mathf.Clamp(Vector3.Dot(this.axisDirections[i].direction, vector), 0f, 1f);
					this.axisDirections[i].dot = Interp.Float(this.axisDirections[i].dot, InterpolationMode.InOutQuintic);
				}
				Vector3 vector2 = this.axisDirections[0].axis;
				for (int j = 1; j < this.axisDirections.Length; j++)
				{
					vector2 = Vector3.Slerp(vector2, this.axisDirections[j].axis, this.axisDirections[j].dot);
				}
				if (this.goal == AvatarIKGoal.LeftHand)
				{
					vector2.x = -vector2.x;
					vector2 = -vector2;
				}
				Vector3 vector3 = this.bone1.transform.parent.rotation * Quaternion.Inverse(this.parentDefaultRotation) * vector2;
				if (num >= 1f)
				{
					return vector3;
				}
				return Vector3.Lerp(this.bendNormal, vector3, num);
			}
			case IKSolverLimb.BendModifier.Goal:
			{
				if (this.bendGoal == null)
				{
					if (!Warning.logged)
					{
						base.LogWarning("Trying to use the 'Goal' Bend Modifier, but the Bend Goal is unassigned.");
					}
					return this.bendNormal;
				}
				Vector3 vector4 = Vector3.Cross(this.bendGoal.position - this.bone1.transform.position, this.IKPosition - this.bone1.transform.position);
				if (vector4 == Vector3.zero)
				{
					return this.bendNormal;
				}
				if (num >= 1f)
				{
					return vector4;
				}
				return Vector3.Lerp(this.bendNormal, vector4, num);
			}
			default:
				return this.bendNormal;
			}
		}

		// Token: 0x04000620 RID: 1568
		public AvatarIKGoal goal;

		// Token: 0x04000621 RID: 1569
		public IKSolverLimb.BendModifier bendModifier;

		// Token: 0x04000622 RID: 1570
		[Range(0f, 1f)]
		public float maintainRotationWeight;

		// Token: 0x04000623 RID: 1571
		[Range(0f, 1f)]
		public float bendModifierWeight = 1f;

		// Token: 0x04000624 RID: 1572
		public Transform bendGoal;

		// Token: 0x04000625 RID: 1573
		private bool maintainBendFor1Frame;

		// Token: 0x04000626 RID: 1574
		private bool maintainRotationFor1Frame;

		// Token: 0x04000627 RID: 1575
		private Quaternion defaultRootRotation;

		// Token: 0x04000628 RID: 1576
		private Quaternion parentDefaultRotation;

		// Token: 0x04000629 RID: 1577
		private Quaternion bone3RotationBeforeSolve;

		// Token: 0x0400062A RID: 1578
		private Quaternion maintainRotation;

		// Token: 0x0400062B RID: 1579
		private Quaternion bone3DefaultRotation;

		// Token: 0x0400062C RID: 1580
		private Vector3 _bendNormal;

		// Token: 0x0400062D RID: 1581
		private Vector3 animationNormal;

		// Token: 0x0400062E RID: 1582
		private IKSolverLimb.AxisDirection[] axisDirectionsLeft = new IKSolverLimb.AxisDirection[4];

		// Token: 0x0400062F RID: 1583
		private IKSolverLimb.AxisDirection[] axisDirectionsRight = new IKSolverLimb.AxisDirection[4];

		// Token: 0x020000DB RID: 219
		[Serializable]
		public enum BendModifier
		{
			// Token: 0x04000631 RID: 1585
			Animation,
			// Token: 0x04000632 RID: 1586
			Target,
			// Token: 0x04000633 RID: 1587
			Parent,
			// Token: 0x04000634 RID: 1588
			Arm,
			// Token: 0x04000635 RID: 1589
			Goal
		}

		// Token: 0x020000DC RID: 220
		[Serializable]
		public struct AxisDirection
		{
			// Token: 0x06000723 RID: 1827 RVA: 0x0002BEA5 File Offset: 0x0002A0A5
			public AxisDirection(Vector3 direction, Vector3 axis)
			{
				this.direction = direction.normalized;
				this.axis = axis.normalized;
				this.dot = 0f;
			}

			// Token: 0x04000636 RID: 1590
			public Vector3 direction;

			// Token: 0x04000637 RID: 1591
			public Vector3 axis;

			// Token: 0x04000638 RID: 1592
			public float dot;
		}
	}
}
