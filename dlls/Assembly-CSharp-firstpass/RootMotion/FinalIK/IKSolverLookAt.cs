using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000DD RID: 221
	[Serializable]
	public class IKSolverLookAt : IKSolver
	{
		// Token: 0x06000724 RID: 1828 RVA: 0x00026597 File Offset: 0x00024797
		public void SetLookAtWeight(float weight)
		{
			this.IKPositionWeight = Mathf.Clamp(weight, 0f, 1f);
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x0002BECC File Offset: 0x0002A0CC
		public void SetLookAtWeight(float weight, float bodyWeight)
		{
			this.IKPositionWeight = Mathf.Clamp(weight, 0f, 1f);
			this.bodyWeight = Mathf.Clamp(bodyWeight, 0f, 1f);
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x0002BEFC File Offset: 0x0002A0FC
		public void SetLookAtWeight(float weight, float bodyWeight, float headWeight)
		{
			this.IKPositionWeight = Mathf.Clamp(weight, 0f, 1f);
			this.bodyWeight = Mathf.Clamp(bodyWeight, 0f, 1f);
			this.headWeight = Mathf.Clamp(headWeight, 0f, 1f);
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x0002BF4C File Offset: 0x0002A14C
		public void SetLookAtWeight(float weight, float bodyWeight, float headWeight, float eyesWeight)
		{
			this.IKPositionWeight = Mathf.Clamp(weight, 0f, 1f);
			this.bodyWeight = Mathf.Clamp(bodyWeight, 0f, 1f);
			this.headWeight = Mathf.Clamp(headWeight, 0f, 1f);
			this.eyesWeight = Mathf.Clamp(eyesWeight, 0f, 1f);
		}

		// Token: 0x06000728 RID: 1832 RVA: 0x0002BFB4 File Offset: 0x0002A1B4
		public void SetLookAtWeight(float weight, float bodyWeight, float headWeight, float eyesWeight, float clampWeight)
		{
			this.IKPositionWeight = Mathf.Clamp(weight, 0f, 1f);
			this.bodyWeight = Mathf.Clamp(bodyWeight, 0f, 1f);
			this.headWeight = Mathf.Clamp(headWeight, 0f, 1f);
			this.eyesWeight = Mathf.Clamp(eyesWeight, 0f, 1f);
			this.clampWeight = Mathf.Clamp(clampWeight, 0f, 1f);
			this.clampWeightHead = this.clampWeight;
			this.clampWeightEyes = this.clampWeight;
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x0002C04C File Offset: 0x0002A24C
		public void SetLookAtWeight(float weight, float bodyWeight = 0f, float headWeight = 1f, float eyesWeight = 0.5f, float clampWeight = 0.5f, float clampWeightHead = 0.5f, float clampWeightEyes = 0.3f)
		{
			this.IKPositionWeight = Mathf.Clamp(weight, 0f, 1f);
			this.bodyWeight = Mathf.Clamp(bodyWeight, 0f, 1f);
			this.headWeight = Mathf.Clamp(headWeight, 0f, 1f);
			this.eyesWeight = Mathf.Clamp(eyesWeight, 0f, 1f);
			this.clampWeight = Mathf.Clamp(clampWeight, 0f, 1f);
			this.clampWeightHead = Mathf.Clamp(clampWeightHead, 0f, 1f);
			this.clampWeightEyes = Mathf.Clamp(clampWeightEyes, 0f, 1f);
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x0002C0F8 File Offset: 0x0002A2F8
		public override void StoreDefaultLocalState()
		{
			for (int i = 0; i < this.spine.Length; i++)
			{
				this.spine[i].StoreDefaultLocalState();
			}
			for (int j = 0; j < this.eyes.Length; j++)
			{
				this.eyes[j].StoreDefaultLocalState();
			}
			if (this.head != null && this.head.transform != null)
			{
				this.head.StoreDefaultLocalState();
			}
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x0002C16B File Offset: 0x0002A36B
		public void SetDirty()
		{
			this.isDirty = true;
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x0002C174 File Offset: 0x0002A374
		public override void FixTransforms()
		{
			if (!base.initiated)
			{
				return;
			}
			if (this.IKPositionWeight <= 0f && !this.isDirty)
			{
				return;
			}
			for (int i = 0; i < this.spine.Length; i++)
			{
				this.spine[i].FixTransform();
			}
			for (int j = 0; j < this.eyes.Length; j++)
			{
				this.eyes[j].FixTransform();
			}
			if (this.head != null && this.head.transform != null)
			{
				this.head.FixTransform();
			}
			this.isDirty = false;
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x0002C210 File Offset: 0x0002A410
		public override bool IsValid(ref string message)
		{
			if (!this.spineIsValid)
			{
				message = "IKSolverLookAt spine setup is invalid. Can't initiate solver.";
				return false;
			}
			if (!this.headIsValid)
			{
				message = "IKSolverLookAt head transform is null. Can't initiate solver.";
				return false;
			}
			if (!this.eyesIsValid)
			{
				message = "IKSolverLookAt eyes setup is invalid. Can't initiate solver.";
				return false;
			}
			if (this.spineIsEmpty && this.headIsEmpty && this.eyesIsEmpty)
			{
				message = "IKSolverLookAt eyes setup is invalid. Can't initiate solver.";
				return false;
			}
			IKSolver.Bone[] bones = this.spine;
			Transform transform = IKSolver.ContainsDuplicateBone(bones);
			if (transform != null)
			{
				message = transform.name + " is represented multiple times in a single IK chain. Can't initiate solver.";
				return false;
			}
			bones = this.eyes;
			Transform transform2 = IKSolver.ContainsDuplicateBone(bones);
			if (transform2 != null)
			{
				message = transform2.name + " is represented multiple times in a single IK chain. Can't initiate solver.";
				return false;
			}
			return true;
		}

		// Token: 0x0600072E RID: 1838 RVA: 0x0002C2C8 File Offset: 0x0002A4C8
		public override IKSolver.Point[] GetPoints()
		{
			IKSolver.Point[] array = new IKSolver.Point[this.spine.Length + this.eyes.Length + ((this.head.transform != null) ? 1 : 0)];
			for (int i = 0; i < this.spine.Length; i++)
			{
				array[i] = this.spine[i];
			}
			int num = 0;
			for (int j = this.spine.Length; j < this.spine.Length + this.eyes.Length; j++)
			{
				array[j] = this.eyes[num];
				num++;
			}
			if (this.head.transform != null)
			{
				array[array.Length - 1] = this.head;
			}
			return array;
		}

		// Token: 0x0600072F RID: 1839 RVA: 0x0002C378 File Offset: 0x0002A578
		public override IKSolver.Point GetPoint(Transform transform)
		{
			foreach (IKSolverLookAt.LookAtBone lookAtBone in this.spine)
			{
				if (lookAtBone.transform == transform)
				{
					return lookAtBone;
				}
			}
			foreach (IKSolverLookAt.LookAtBone lookAtBone2 in this.eyes)
			{
				if (lookAtBone2.transform == transform)
				{
					return lookAtBone2;
				}
			}
			if (this.head.transform == transform)
			{
				return this.head;
			}
			return null;
		}

		// Token: 0x06000730 RID: 1840 RVA: 0x0002C3F2 File Offset: 0x0002A5F2
		public bool SetChain(Transform[] spine, Transform head, Transform[] eyes, Transform root)
		{
			this.SetBones(spine, ref this.spine);
			this.head = new IKSolverLookAt.LookAtBone(head);
			this.SetBones(eyes, ref this.eyes);
			base.Initiate(root);
			return base.initiated;
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x0002C428 File Offset: 0x0002A628
		protected override void OnInitiate()
		{
			if (this.firstInitiation || !Application.isPlaying)
			{
				if (this.spine.Length != 0)
				{
					this.IKPosition = this.spine[this.spine.Length - 1].transform.position + this.root.forward * 3f;
				}
				else if (this.head.transform != null)
				{
					this.IKPosition = this.head.transform.position + this.root.forward * 3f;
				}
				else if (this.eyes.Length != 0 && this.eyes[0].transform != null)
				{
					this.IKPosition = this.eyes[0].transform.position + this.root.forward * 3f;
				}
			}
			IKSolverLookAt.LookAtBone[] array = this.spine;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Initiate(this.root);
			}
			if (this.head != null)
			{
				this.head.Initiate(this.root);
			}
			array = this.eyes;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Initiate(this.root);
			}
			if (this.spineForwards == null || this.spineForwards.Length != this.spine.Length)
			{
				this.spineForwards = new Vector3[this.spine.Length];
			}
			if (this.headForwards == null)
			{
				this.headForwards = new Vector3[1];
			}
			if (this.eyeForward == null)
			{
				this.eyeForward = new Vector3[1];
			}
		}

		// Token: 0x06000732 RID: 1842 RVA: 0x0002C5DC File Offset: 0x0002A7DC
		protected override void OnUpdate()
		{
			if (this.IKPositionWeight <= 0f)
			{
				return;
			}
			this.IKPositionWeight = Mathf.Clamp(this.IKPositionWeight, 0f, 1f);
			if (this.target != null)
			{
				this.IKPosition = this.target.position;
			}
			this.SolveSpine();
			this.SolveHead();
			this.SolveEyes();
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000733 RID: 1843 RVA: 0x0002C644 File Offset: 0x0002A844
		protected bool spineIsValid
		{
			get
			{
				if (this.spine == null)
				{
					return false;
				}
				if (this.spine.Length == 0)
				{
					return true;
				}
				for (int i = 0; i < this.spine.Length; i++)
				{
					if (this.spine[i] == null || this.spine[i].transform == null)
					{
						return false;
					}
				}
				return true;
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000734 RID: 1844 RVA: 0x0002C69B File Offset: 0x0002A89B
		protected bool spineIsEmpty
		{
			get
			{
				return this.spine.Length == 0;
			}
		}

		// Token: 0x06000735 RID: 1845 RVA: 0x0002C6A8 File Offset: 0x0002A8A8
		protected void SolveSpine()
		{
			if (this.bodyWeight <= 0f)
			{
				return;
			}
			if (this.spineIsEmpty)
			{
				return;
			}
			Vector3 normalized = (this.IKPosition + this.spineTargetOffset - this.spine[this.spine.Length - 1].transform.position).normalized;
			this.GetForwards(ref this.spineForwards, this.spine[0].forward, normalized, this.spine.Length, this.clampWeight);
			for (int i = 0; i < this.spine.Length; i++)
			{
				this.spine[i].LookAt(this.spineForwards[i], this.bodyWeight * this.IKPositionWeight);
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000736 RID: 1846 RVA: 0x0002C768 File Offset: 0x0002A968
		protected bool headIsValid
		{
			get
			{
				return this.head != null;
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000737 RID: 1847 RVA: 0x0002C775 File Offset: 0x0002A975
		protected bool headIsEmpty
		{
			get
			{
				return this.head.transform == null;
			}
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x0002C788 File Offset: 0x0002A988
		protected void SolveHead()
		{
			if (this.headWeight <= 0f)
			{
				return;
			}
			if (this.headIsEmpty)
			{
				return;
			}
			Vector3 vector = (this.spine.Length != 0 && this.spine[this.spine.Length - 1].transform != null) ? this.spine[this.spine.Length - 1].forward : this.head.forward;
			Vector3 normalized = Vector3.Lerp(vector, (this.IKPosition - this.head.transform.position).normalized, this.headWeight * this.IKPositionWeight).normalized;
			this.GetForwards(ref this.headForwards, vector, normalized, 1, this.clampWeightHead);
			this.head.LookAt(this.headForwards[0], this.headWeight * this.IKPositionWeight);
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000739 RID: 1849 RVA: 0x0002C870 File Offset: 0x0002AA70
		protected bool eyesIsValid
		{
			get
			{
				if (this.eyes == null)
				{
					return false;
				}
				if (this.eyes.Length == 0)
				{
					return true;
				}
				for (int i = 0; i < this.eyes.Length; i++)
				{
					if (this.eyes[i] == null || this.eyes[i].transform == null)
					{
						return false;
					}
				}
				return true;
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x0600073A RID: 1850 RVA: 0x0002C8C7 File Offset: 0x0002AAC7
		protected bool eyesIsEmpty
		{
			get
			{
				return this.eyes.Length == 0;
			}
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x0002C8D4 File Offset: 0x0002AAD4
		protected void SolveEyes()
		{
			if (this.eyesWeight <= 0f)
			{
				return;
			}
			if (this.eyesIsEmpty)
			{
				return;
			}
			for (int i = 0; i < this.eyes.Length; i++)
			{
				Quaternion quaternion = (this.head.transform != null) ? this.head.transform.rotation : ((this.spine.Length != 0) ? this.spine[this.spine.Length - 1].transform.rotation : this.root.rotation);
				Vector3 point = (this.head.transform != null) ? this.head.axis : ((this.spine.Length != 0) ? this.spine[this.spine.Length - 1].axis : this.root.forward);
				if (this.eyes[i].baseForwardOffsetEuler != Vector3.zero)
				{
					quaternion *= Quaternion.Euler(this.eyes[i].baseForwardOffsetEuler);
				}
				Vector3 baseForward = quaternion * point;
				this.GetForwards(ref this.eyeForward, baseForward, (this.IKPosition - this.eyes[i].transform.position).normalized, 1, this.clampWeightEyes);
				this.eyes[i].LookAt(this.eyeForward[0], this.eyesWeight * this.IKPositionWeight);
			}
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x0002CA50 File Offset: 0x0002AC50
		protected Vector3[] GetForwards(ref Vector3[] forwards, Vector3 baseForward, Vector3 targetForward, int bones, float clamp)
		{
			if (clamp >= 1f || this.IKPositionWeight <= 0f)
			{
				for (int i = 0; i < forwards.Length; i++)
				{
					forwards[i] = baseForward;
				}
				return forwards;
			}
			float num = Vector3.Angle(baseForward, targetForward);
			float num2 = 1f - num / 180f;
			float num3 = (clamp > 0f) ? Mathf.Clamp(1f - (clamp - num2) / (1f - num2), 0f, 1f) : 1f;
			float num4 = (clamp > 0f) ? Mathf.Clamp(num2 / clamp, 0f, 1f) : 1f;
			for (int j = 0; j < this.clampSmoothing; j++)
			{
				num4 = Mathf.Sin(num4 * 3.1415927f * 0.5f);
			}
			if (forwards.Length == 1)
			{
				forwards[0] = Vector3.Slerp(baseForward, targetForward, num4 * num3);
			}
			else
			{
				float num5 = 1f / (float)(forwards.Length - 1);
				for (int k = 0; k < forwards.Length; k++)
				{
					forwards[k] = Vector3.Slerp(baseForward, targetForward, this.spineWeightCurve.Evaluate(num5 * (float)k) * num4 * num3);
				}
			}
			return forwards;
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x0002CB8C File Offset: 0x0002AD8C
		protected void SetBones(Transform[] array, ref IKSolverLookAt.LookAtBone[] bones)
		{
			if (array == null)
			{
				bones = new IKSolverLookAt.LookAtBone[0];
				return;
			}
			if (bones.Length != array.Length)
			{
				bones = new IKSolverLookAt.LookAtBone[array.Length];
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (bones[i] == null)
				{
					bones[i] = new IKSolverLookAt.LookAtBone(array[i]);
				}
				else
				{
					bones[i].transform = array[i];
				}
			}
		}

		// Token: 0x04000639 RID: 1593
		public Transform target;

		// Token: 0x0400063A RID: 1594
		public IKSolverLookAt.LookAtBone[] spine = new IKSolverLookAt.LookAtBone[0];

		// Token: 0x0400063B RID: 1595
		public IKSolverLookAt.LookAtBone head = new IKSolverLookAt.LookAtBone();

		// Token: 0x0400063C RID: 1596
		public IKSolverLookAt.LookAtBone[] eyes = new IKSolverLookAt.LookAtBone[0];

		// Token: 0x0400063D RID: 1597
		[Range(0f, 1f)]
		public float bodyWeight = 0.5f;

		// Token: 0x0400063E RID: 1598
		[Range(0f, 1f)]
		public float headWeight = 0.5f;

		// Token: 0x0400063F RID: 1599
		[Range(0f, 1f)]
		public float eyesWeight = 1f;

		// Token: 0x04000640 RID: 1600
		[Range(0f, 1f)]
		public float clampWeight = 0.5f;

		// Token: 0x04000641 RID: 1601
		[Range(0f, 1f)]
		public float clampWeightHead = 0.5f;

		// Token: 0x04000642 RID: 1602
		[Range(0f, 1f)]
		public float clampWeightEyes = 0.5f;

		// Token: 0x04000643 RID: 1603
		[Range(0f, 2f)]
		public int clampSmoothing = 2;

		// Token: 0x04000644 RID: 1604
		public AnimationCurve spineWeightCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0.3f),
			new Keyframe(1f, 1f)
		});

		// Token: 0x04000645 RID: 1605
		public Vector3 spineTargetOffset;

		// Token: 0x04000646 RID: 1606
		protected Vector3[] spineForwards = new Vector3[0];

		// Token: 0x04000647 RID: 1607
		protected Vector3[] headForwards = new Vector3[1];

		// Token: 0x04000648 RID: 1608
		protected Vector3[] eyeForward = new Vector3[1];

		// Token: 0x04000649 RID: 1609
		private bool isDirty;

		// Token: 0x020000DE RID: 222
		[Serializable]
		public class LookAtBone : IKSolver.Bone
		{
			// Token: 0x0600073F RID: 1855 RVA: 0x0002CCC8 File Offset: 0x0002AEC8
			public LookAtBone()
			{
			}

			// Token: 0x06000740 RID: 1856 RVA: 0x0002CCD0 File Offset: 0x0002AED0
			public LookAtBone(Transform transform)
			{
				this.transform = transform;
			}

			// Token: 0x06000741 RID: 1857 RVA: 0x0002CCDF File Offset: 0x0002AEDF
			public void Initiate(Transform root)
			{
				if (this.transform == null)
				{
					return;
				}
				this.axis = Quaternion.Inverse(this.transform.rotation) * root.forward;
			}

			// Token: 0x06000742 RID: 1858 RVA: 0x0002CD14 File Offset: 0x0002AF14
			public void LookAt(Vector3 direction, float weight)
			{
				Quaternion lhs = Quaternion.FromToRotation(this.forward, direction);
				Quaternion rotation = this.transform.rotation;
				this.transform.rotation = Quaternion.Lerp(rotation, lhs * rotation, weight);
			}

			// Token: 0x170000CC RID: 204
			// (get) Token: 0x06000743 RID: 1859 RVA: 0x0002CD53 File Offset: 0x0002AF53
			public Vector3 forward
			{
				get
				{
					return this.transform.rotation * this.axis;
				}
			}

			// Token: 0x0400064A RID: 1610
			public Vector3 baseForwardOffsetEuler;
		}
	}
}
