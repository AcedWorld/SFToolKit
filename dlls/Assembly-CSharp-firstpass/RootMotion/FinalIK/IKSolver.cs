using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000C9 RID: 201
	[Serializable]
	public abstract class IKSolver
	{
		// Token: 0x06000649 RID: 1609 RVA: 0x0002647C File Offset: 0x0002467C
		public bool IsValid()
		{
			string empty = string.Empty;
			return this.IsValid(ref empty);
		}

		// Token: 0x0600064A RID: 1610
		public abstract bool IsValid(ref string message);

		// Token: 0x0600064B RID: 1611 RVA: 0x00026498 File Offset: 0x00024698
		public void Initiate(Transform root)
		{
			if (this.executedInEditor)
			{
				return;
			}
			if (this.OnPreInitiate != null)
			{
				this.OnPreInitiate();
			}
			if (root == null)
			{
				Debug.LogError("Initiating IKSolver with null root Transform.");
			}
			this.root = root;
			this.initiated = false;
			string empty = string.Empty;
			if (!this.IsValid(ref empty))
			{
				Warning.Log(empty, root, false);
				return;
			}
			this.OnInitiate();
			this.StoreDefaultLocalState();
			this.initiated = true;
			this.firstInitiation = false;
			if (this.OnPostInitiate != null)
			{
				this.OnPostInitiate();
			}
		}

		// Token: 0x0600064C RID: 1612 RVA: 0x00026528 File Offset: 0x00024728
		public void Update()
		{
			if (this.OnPreUpdate != null)
			{
				this.OnPreUpdate();
			}
			if (this.firstInitiation)
			{
				this.Initiate(this.root);
			}
			if (!this.initiated)
			{
				return;
			}
			this.OnUpdate();
			if (this.OnPostUpdate != null)
			{
				this.OnPostUpdate();
			}
		}

		// Token: 0x0600064D RID: 1613 RVA: 0x0002657E File Offset: 0x0002477E
		public virtual Vector3 GetIKPosition()
		{
			return this.IKPosition;
		}

		// Token: 0x0600064E RID: 1614 RVA: 0x00026586 File Offset: 0x00024786
		public void SetIKPosition(Vector3 position)
		{
			this.IKPosition = position;
		}

		// Token: 0x0600064F RID: 1615 RVA: 0x0002658F File Offset: 0x0002478F
		public float GetIKPositionWeight()
		{
			return this.IKPositionWeight;
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x00026597 File Offset: 0x00024797
		public void SetIKPositionWeight(float weight)
		{
			this.IKPositionWeight = Mathf.Clamp(weight, 0f, 1f);
		}

		// Token: 0x06000651 RID: 1617 RVA: 0x000265AF File Offset: 0x000247AF
		public Transform GetRoot()
		{
			return this.root;
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000652 RID: 1618 RVA: 0x000265B7 File Offset: 0x000247B7
		// (set) Token: 0x06000653 RID: 1619 RVA: 0x000265BF File Offset: 0x000247BF
		public bool initiated { get; private set; }

		// Token: 0x06000654 RID: 1620
		public abstract IKSolver.Point[] GetPoints();

		// Token: 0x06000655 RID: 1621
		public abstract IKSolver.Point GetPoint(Transform transform);

		// Token: 0x06000656 RID: 1622
		public abstract void FixTransforms();

		// Token: 0x06000657 RID: 1623
		public abstract void StoreDefaultLocalState();

		// Token: 0x06000658 RID: 1624
		protected abstract void OnInitiate();

		// Token: 0x06000659 RID: 1625
		protected abstract void OnUpdate();

		// Token: 0x0600065A RID: 1626 RVA: 0x000265C8 File Offset: 0x000247C8
		protected void LogWarning(string message)
		{
			Warning.Log(message, this.root, true);
		}

		// Token: 0x0600065B RID: 1627 RVA: 0x000265D8 File Offset: 0x000247D8
		public static Transform ContainsDuplicateBone(IKSolver.Bone[] bones)
		{
			for (int i = 0; i < bones.Length; i++)
			{
				for (int j = 0; j < bones.Length; j++)
				{
					if (i != j && bones[i].transform == bones[j].transform)
					{
						return bones[i].transform;
					}
				}
			}
			return null;
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x00026628 File Offset: 0x00024828
		public static bool HierarchyIsValid(IKSolver.Bone[] bones)
		{
			for (int i = 1; i < bones.Length; i++)
			{
				if (!Hierarchy.IsAncestor(bones[i].transform, bones[i - 1].transform))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x00026660 File Offset: 0x00024860
		protected static float PreSolveBones(ref IKSolver.Bone[] bones)
		{
			float num = 0f;
			for (int i = 0; i < bones.Length; i++)
			{
				bones[i].solverPosition = bones[i].transform.position;
				bones[i].solverRotation = bones[i].transform.rotation;
			}
			for (int j = 0; j < bones.Length; j++)
			{
				if (j < bones.Length - 1)
				{
					bones[j].sqrMag = (bones[j + 1].solverPosition - bones[j].solverPosition).sqrMagnitude;
					bones[j].length = Mathf.Sqrt(bones[j].sqrMag);
					num += bones[j].length;
					bones[j].axis = Quaternion.Inverse(bones[j].solverRotation) * (bones[j + 1].solverPosition - bones[j].solverPosition);
				}
				else
				{
					bones[j].sqrMag = 0f;
					bones[j].length = 0f;
				}
			}
			return num;
		}

		// Token: 0x040005AE RID: 1454
		[HideInInspector]
		public bool executedInEditor;

		// Token: 0x040005AF RID: 1455
		[HideInInspector]
		public Vector3 IKPosition;

		// Token: 0x040005B0 RID: 1456
		[Tooltip("The positional or the master weight of the solver.")]
		[Range(0f, 1f)]
		public float IKPositionWeight = 1f;

		// Token: 0x040005B2 RID: 1458
		public IKSolver.UpdateDelegate OnPreInitiate;

		// Token: 0x040005B3 RID: 1459
		public IKSolver.UpdateDelegate OnPostInitiate;

		// Token: 0x040005B4 RID: 1460
		public IKSolver.UpdateDelegate OnPreUpdate;

		// Token: 0x040005B5 RID: 1461
		public IKSolver.UpdateDelegate OnPostUpdate;

		// Token: 0x040005B6 RID: 1462
		protected bool firstInitiation = true;

		// Token: 0x040005B7 RID: 1463
		[SerializeField]
		[HideInInspector]
		protected Transform root;

		// Token: 0x020000CA RID: 202
		[Serializable]
		public class Point
		{
			// Token: 0x0600065F RID: 1631 RVA: 0x0002678C File Offset: 0x0002498C
			public void StoreDefaultLocalState()
			{
				this.defaultLocalPosition = this.transform.localPosition;
				this.defaultLocalRotation = this.transform.localRotation;
			}

			// Token: 0x06000660 RID: 1632 RVA: 0x000267B0 File Offset: 0x000249B0
			public void FixTransform()
			{
				if (this.transform.localPosition != this.defaultLocalPosition)
				{
					this.transform.localPosition = this.defaultLocalPosition;
				}
				if (this.transform.localRotation != this.defaultLocalRotation)
				{
					this.transform.localRotation = this.defaultLocalRotation;
				}
			}

			// Token: 0x06000661 RID: 1633 RVA: 0x0002680F File Offset: 0x00024A0F
			public void UpdateSolverPosition()
			{
				this.solverPosition = this.transform.position;
			}

			// Token: 0x06000662 RID: 1634 RVA: 0x00026822 File Offset: 0x00024A22
			public void UpdateSolverLocalPosition()
			{
				this.solverPosition = this.transform.localPosition;
			}

			// Token: 0x06000663 RID: 1635 RVA: 0x00026835 File Offset: 0x00024A35
			public void UpdateSolverState()
			{
				this.solverPosition = this.transform.position;
				this.solverRotation = this.transform.rotation;
			}

			// Token: 0x06000664 RID: 1636 RVA: 0x00026859 File Offset: 0x00024A59
			public void UpdateSolverLocalState()
			{
				this.solverPosition = this.transform.localPosition;
				this.solverRotation = this.transform.localRotation;
			}

			// Token: 0x040005B8 RID: 1464
			public Transform transform;

			// Token: 0x040005B9 RID: 1465
			[Range(0f, 1f)]
			public float weight = 1f;

			// Token: 0x040005BA RID: 1466
			public Vector3 solverPosition;

			// Token: 0x040005BB RID: 1467
			public Quaternion solverRotation = Quaternion.identity;

			// Token: 0x040005BC RID: 1468
			public Vector3 defaultLocalPosition;

			// Token: 0x040005BD RID: 1469
			public Quaternion defaultLocalRotation;
		}

		// Token: 0x020000CB RID: 203
		[Serializable]
		public class Bone : IKSolver.Point
		{
			// Token: 0x170000A7 RID: 167
			// (get) Token: 0x06000666 RID: 1638 RVA: 0x0002689C File Offset: 0x00024A9C
			// (set) Token: 0x06000667 RID: 1639 RVA: 0x000268EA File Offset: 0x00024AEA
			public RotationLimit rotationLimit
			{
				get
				{
					if (!this.isLimited)
					{
						return null;
					}
					if (this._rotationLimit == null)
					{
						this._rotationLimit = this.transform.GetComponent<RotationLimit>();
					}
					this.isLimited = (this._rotationLimit != null);
					return this._rotationLimit;
				}
				set
				{
					this._rotationLimit = value;
					this.isLimited = (value != null);
				}
			}

			// Token: 0x06000668 RID: 1640 RVA: 0x00026900 File Offset: 0x00024B00
			public void Swing(Vector3 swingTarget, float weight = 1f)
			{
				if (weight <= 0f)
				{
					return;
				}
				Quaternion quaternion = Quaternion.FromToRotation(this.transform.rotation * this.axis, swingTarget - this.transform.position);
				if (weight >= 1f)
				{
					this.transform.rotation = quaternion * this.transform.rotation;
					return;
				}
				this.transform.rotation = Quaternion.Lerp(Quaternion.identity, quaternion, weight) * this.transform.rotation;
			}

			// Token: 0x06000669 RID: 1641 RVA: 0x00026990 File Offset: 0x00024B90
			public static void SolverSwing(IKSolver.Bone[] bones, int index, Vector3 swingTarget, float weight = 1f)
			{
				if (weight <= 0f)
				{
					return;
				}
				Quaternion quaternion = Quaternion.FromToRotation(bones[index].solverRotation * bones[index].axis, swingTarget - bones[index].solverPosition);
				if (weight >= 1f)
				{
					for (int i = index; i < bones.Length; i++)
					{
						bones[i].solverRotation = quaternion * bones[i].solverRotation;
					}
					return;
				}
				for (int j = index; j < bones.Length; j++)
				{
					bones[j].solverRotation = Quaternion.Lerp(Quaternion.identity, quaternion, weight) * bones[j].solverRotation;
				}
			}

			// Token: 0x0600066A RID: 1642 RVA: 0x00026A2C File Offset: 0x00024C2C
			public void Swing2D(Vector3 swingTarget, float weight = 1f)
			{
				if (weight <= 0f)
				{
					return;
				}
				Vector3 vector = this.transform.rotation * this.axis;
				Vector3 vector2 = swingTarget - this.transform.position;
				float current = Mathf.Atan2(vector.x, vector.y) * 57.29578f;
				float target = Mathf.Atan2(vector2.x, vector2.y) * 57.29578f;
				this.transform.rotation = Quaternion.AngleAxis(Mathf.DeltaAngle(current, target) * weight, Vector3.back) * this.transform.rotation;
			}

			// Token: 0x0600066B RID: 1643 RVA: 0x00026AC9 File Offset: 0x00024CC9
			public void SetToSolverPosition()
			{
				this.transform.position = this.solverPosition;
			}

			// Token: 0x0600066C RID: 1644 RVA: 0x00026ADC File Offset: 0x00024CDC
			public Bone()
			{
			}

			// Token: 0x0600066D RID: 1645 RVA: 0x00026AFB File Offset: 0x00024CFB
			public Bone(Transform transform)
			{
				this.transform = transform;
			}

			// Token: 0x0600066E RID: 1646 RVA: 0x00026B21 File Offset: 0x00024D21
			public Bone(Transform transform, float weight)
			{
				this.transform = transform;
				this.weight = weight;
			}

			// Token: 0x040005BE RID: 1470
			public float length;

			// Token: 0x040005BF RID: 1471
			public float sqrMag;

			// Token: 0x040005C0 RID: 1472
			public Vector3 axis = -Vector3.right;

			// Token: 0x040005C1 RID: 1473
			private RotationLimit _rotationLimit;

			// Token: 0x040005C2 RID: 1474
			private bool isLimited = true;
		}

		// Token: 0x020000CC RID: 204
		[Serializable]
		public class Node : IKSolver.Point
		{
			// Token: 0x0600066F RID: 1647 RVA: 0x00026B4E File Offset: 0x00024D4E
			public Node()
			{
			}

			// Token: 0x06000670 RID: 1648 RVA: 0x00026B56 File Offset: 0x00024D56
			public Node(Transform transform)
			{
				this.transform = transform;
			}

			// Token: 0x06000671 RID: 1649 RVA: 0x00026B65 File Offset: 0x00024D65
			public Node(Transform transform, float weight)
			{
				this.transform = transform;
				this.weight = weight;
			}

			// Token: 0x040005C3 RID: 1475
			public float length;

			// Token: 0x040005C4 RID: 1476
			public float effectorPositionWeight;

			// Token: 0x040005C5 RID: 1477
			public float effectorRotationWeight;

			// Token: 0x040005C6 RID: 1478
			public Vector3 offset;
		}

		// Token: 0x020000CD RID: 205
		// (Invoke) Token: 0x06000673 RID: 1651
		public delegate void UpdateDelegate();

		// Token: 0x020000CE RID: 206
		// (Invoke) Token: 0x06000677 RID: 1655
		public delegate void IterationDelegate(int i);
	}
}
