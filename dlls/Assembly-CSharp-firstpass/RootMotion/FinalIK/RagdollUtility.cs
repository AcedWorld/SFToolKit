using System;
using System.Collections;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x02000109 RID: 265
	public class RagdollUtility : MonoBehaviour
	{
		// Token: 0x060008E5 RID: 2277 RVA: 0x0003924B File Offset: 0x0003744B
		public void EnableRagdoll()
		{
			if (this.isRagdoll)
			{
				return;
			}
			base.StopAllCoroutines();
			this.enableRagdollFlag = true;
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x00039263 File Offset: 0x00037463
		public void DisableRagdoll()
		{
			if (!this.isRagdoll)
			{
				return;
			}
			this.StoreLocalState();
			base.StopAllCoroutines();
			base.StartCoroutine(this.DisableRagdollSmooth());
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x00039288 File Offset: 0x00037488
		public void Start()
		{
			this.animator = base.GetComponent<Animator>();
			this.allIKComponents = base.GetComponentsInChildren<IK>();
			this.disabledIKComponents = new bool[this.allIKComponents.Length];
			this.fixTransforms = new bool[this.allIKComponents.Length];
			if (this.ik != null)
			{
				IKSolver iksolver = this.ik.GetIKSolver();
				iksolver.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(iksolver.OnPostUpdate, new IKSolver.UpdateDelegate(this.AfterLastIK));
			}
			Rigidbody[] componentsInChildren = base.GetComponentsInChildren<Rigidbody>();
			int num = (componentsInChildren[0].gameObject == base.gameObject) ? 1 : 0;
			this.rigidbones = new RagdollUtility.Rigidbone[(num == 0) ? componentsInChildren.Length : (componentsInChildren.Length - 1)];
			for (int i = 0; i < this.rigidbones.Length; i++)
			{
				this.rigidbones[i] = new RagdollUtility.Rigidbone(componentsInChildren[i + num]);
			}
			Transform[] componentsInChildren2 = base.GetComponentsInChildren<Transform>();
			this.children = new RagdollUtility.Child[componentsInChildren2.Length - 1];
			for (int j = 0; j < this.children.Length; j++)
			{
				this.children[j] = new RagdollUtility.Child(componentsInChildren2[j + 1]);
			}
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x000393AD File Offset: 0x000375AD
		private IEnumerator DisableRagdollSmooth()
		{
			for (int i = 0; i < this.rigidbones.Length; i++)
			{
				this.rigidbones[i].r.isKinematic = true;
			}
			for (int j = 0; j < this.allIKComponents.Length; j++)
			{
				this.allIKComponents[j].fixTransforms = this.fixTransforms[j];
				if (this.disabledIKComponents[j])
				{
					this.allIKComponents[j].enabled = true;
				}
			}
			this.animator.updateMode = this.animatorUpdateMode;
			if (this.animatorDisabled)
			{
				this.animator.enabled = true;
				this.animatorDisabled = false;
			}
			while (this.ragdollWeight > 0f)
			{
				this.ragdollWeight = Mathf.SmoothDamp(this.ragdollWeight, 0f, ref this.ragdollWeightV, this.ragdollToAnimationTime);
				if (this.ragdollWeight < 0.001f)
				{
					this.ragdollWeight = 0f;
				}
				yield return null;
			}
			yield return null;
			yield break;
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x000393BC File Offset: 0x000375BC
		public void Update()
		{
			if (!this.isRagdoll)
			{
				return;
			}
			if (!this.applyIkOnRagdoll)
			{
				bool flag = false;
				for (int i = 0; i < this.allIKComponents.Length; i++)
				{
					if (this.allIKComponents[i].enabled)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					for (int j = 0; j < this.allIKComponents.Length; j++)
					{
						this.disabledIKComponents[j] = false;
					}
				}
				for (int k = 0; k < this.allIKComponents.Length; k++)
				{
					if (this.allIKComponents[k].enabled)
					{
						this.allIKComponents[k].enabled = false;
						this.disabledIKComponents[k] = true;
					}
				}
				return;
			}
			bool flag2 = false;
			for (int l = 0; l < this.allIKComponents.Length; l++)
			{
				if (this.disabledIKComponents[l])
				{
					flag2 = true;
					break;
				}
			}
			if (flag2)
			{
				for (int m = 0; m < this.allIKComponents.Length; m++)
				{
					if (this.disabledIKComponents[m])
					{
						this.allIKComponents[m].enabled = true;
					}
				}
				for (int n = 0; n < this.allIKComponents.Length; n++)
				{
					this.disabledIKComponents[n] = false;
				}
			}
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x000394DE File Offset: 0x000376DE
		public void FixedUpdate()
		{
			if (this.isRagdoll && this.applyIkOnRagdoll)
			{
				this.FixTransforms(1f);
			}
			this.fixedFrame = true;
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x00039504 File Offset: 0x00037704
		public void LateUpdate()
		{
			if (this.animator.updateMode != AnimatorUpdateMode.AnimatePhysics || (this.animator.updateMode == AnimatorUpdateMode.AnimatePhysics && this.fixedFrame))
			{
				this.AfterAnimation();
			}
			this.fixedFrame = false;
			if (!this.ikUsed)
			{
				this.OnFinalPose();
			}
		}

		// Token: 0x060008EC RID: 2284 RVA: 0x00039550 File Offset: 0x00037750
		private void AfterLastIK()
		{
			if (this.ikUsed)
			{
				this.OnFinalPose();
			}
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x00039560 File Offset: 0x00037760
		private void AfterAnimation()
		{
			if (this.isRagdoll)
			{
				this.StoreLocalState();
				return;
			}
			this.FixTransforms(this.ragdollWeight);
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x0003957D File Offset: 0x0003777D
		private void OnFinalPose()
		{
			if (!this.isRagdoll)
			{
				this.RecordVelocities();
			}
			if (this.enableRagdollFlag)
			{
				this.RagdollEnabler();
			}
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x0003959C File Offset: 0x0003779C
		private void RagdollEnabler()
		{
			this.StoreLocalState();
			for (int i = 0; i < this.allIKComponents.Length; i++)
			{
				this.disabledIKComponents[i] = false;
			}
			if (!this.applyIkOnRagdoll)
			{
				for (int j = 0; j < this.allIKComponents.Length; j++)
				{
					if (this.allIKComponents[j].enabled)
					{
						this.allIKComponents[j].enabled = false;
						this.disabledIKComponents[j] = true;
					}
				}
			}
			this.animatorUpdateMode = this.animator.updateMode;
			this.animator.updateMode = AnimatorUpdateMode.AnimatePhysics;
			if (this.animator.enabled)
			{
				this.animator.enabled = false;
				this.animatorDisabled = true;
			}
			for (int k = 0; k < this.rigidbones.Length; k++)
			{
				this.rigidbones[k].WakeUp(this.applyVelocity, this.applyAngularVelocity);
			}
			for (int l = 0; l < this.fixTransforms.Length; l++)
			{
				this.fixTransforms[l] = this.allIKComponents[l].fixTransforms;
				this.allIKComponents[l].fixTransforms = false;
			}
			this.ragdollWeight = 1f;
			this.ragdollWeightV = 0f;
			this.enableRagdollFlag = false;
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x060008F0 RID: 2288 RVA: 0x000396C8 File Offset: 0x000378C8
		private bool isRagdoll
		{
			get
			{
				return !this.rigidbones[0].r.isKinematic && !this.animator.enabled;
			}
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x000396F0 File Offset: 0x000378F0
		private void RecordVelocities()
		{
			RagdollUtility.Rigidbone[] array = this.rigidbones;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RecordVelocity();
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x060008F2 RID: 2290 RVA: 0x0003971C File Offset: 0x0003791C
		private bool ikUsed
		{
			get
			{
				if (this.ik == null)
				{
					return false;
				}
				if (this.ik.enabled && this.ik.GetIKSolver().IKPositionWeight > 0f)
				{
					return true;
				}
				foreach (IK ik in this.allIKComponents)
				{
					if (ik.enabled && ik.GetIKSolver().IKPositionWeight > 0f)
					{
						return true;
					}
				}
				return false;
			}
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x00039798 File Offset: 0x00037998
		private void StoreLocalState()
		{
			RagdollUtility.Child[] array = this.children;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].StoreLocalState();
			}
		}

		// Token: 0x060008F4 RID: 2292 RVA: 0x000397C4 File Offset: 0x000379C4
		private void FixTransforms(float weight)
		{
			RagdollUtility.Child[] array = this.children;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].FixTransform(weight);
			}
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x000397EF File Offset: 0x000379EF
		private void OnDestroy()
		{
			if (this.ik != null)
			{
				IKSolver iksolver = this.ik.GetIKSolver();
				iksolver.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(iksolver.OnPostUpdate, new IKSolver.UpdateDelegate(this.AfterLastIK));
			}
		}

		// Token: 0x04000827 RID: 2087
		[Tooltip("If you have multiple IK components, then this should be the one that solves last each frame.")]
		public IK ik;

		// Token: 0x04000828 RID: 2088
		[Tooltip("How long does it take to blend from ragdoll to animation?")]
		public float ragdollToAnimationTime = 0.2f;

		// Token: 0x04000829 RID: 2089
		[Tooltip("If true, IK can be used on top of physical ragdoll simulation.")]
		public bool applyIkOnRagdoll;

		// Token: 0x0400082A RID: 2090
		[Tooltip("How much velocity transfer from animation to ragdoll?")]
		public float applyVelocity = 1f;

		// Token: 0x0400082B RID: 2091
		[Tooltip("How much angular velocity to transfer from animation to ragdoll?")]
		public float applyAngularVelocity = 1f;

		// Token: 0x0400082C RID: 2092
		private Animator animator;

		// Token: 0x0400082D RID: 2093
		private RagdollUtility.Rigidbone[] rigidbones = new RagdollUtility.Rigidbone[0];

		// Token: 0x0400082E RID: 2094
		private RagdollUtility.Child[] children = new RagdollUtility.Child[0];

		// Token: 0x0400082F RID: 2095
		private bool enableRagdollFlag;

		// Token: 0x04000830 RID: 2096
		private AnimatorUpdateMode animatorUpdateMode;

		// Token: 0x04000831 RID: 2097
		private IK[] allIKComponents = new IK[0];

		// Token: 0x04000832 RID: 2098
		private bool[] fixTransforms = new bool[0];

		// Token: 0x04000833 RID: 2099
		private float ragdollWeight;

		// Token: 0x04000834 RID: 2100
		private float ragdollWeightV;

		// Token: 0x04000835 RID: 2101
		private bool fixedFrame;

		// Token: 0x04000836 RID: 2102
		private bool[] disabledIKComponents = new bool[0];

		// Token: 0x04000837 RID: 2103
		private bool animatorDisabled;

		// Token: 0x0200010A RID: 266
		public class Rigidbone
		{
			// Token: 0x060008F7 RID: 2295 RVA: 0x0003989C File Offset: 0x00037A9C
			public Rigidbone(Rigidbody r)
			{
				this.r = r;
				this.t = r.transform;
				this.joint = this.t.GetComponent<Joint>();
				this.collider = this.t.GetComponent<Collider>();
				if (this.joint != null)
				{
					this.c = this.joint.connectedBody;
					this.updateAnchor = (this.c != null);
				}
				this.lastPosition = this.t.position;
				this.lastRotation = this.t.rotation;
			}

			// Token: 0x060008F8 RID: 2296 RVA: 0x00039938 File Offset: 0x00037B38
			public void RecordVelocity()
			{
				this.deltaPosition = this.t.position - this.lastPosition;
				this.lastPosition = this.t.position;
				this.deltaRotation = QuaTools.FromToRotation(this.lastRotation, this.t.rotation);
				this.lastRotation = this.t.rotation;
				this.deltaTime = Time.deltaTime;
			}

			// Token: 0x060008F9 RID: 2297 RVA: 0x000399AC File Offset: 0x00037BAC
			public void WakeUp(float velocityWeight, float angularVelocityWeight)
			{
				if (this.updateAnchor)
				{
					this.joint.connectedAnchor = this.t.InverseTransformPoint(this.c.position);
				}
				this.r.isKinematic = false;
				if (velocityWeight != 0f)
				{
					this.r.velocity = this.deltaPosition / this.deltaTime * velocityWeight;
				}
				if (angularVelocityWeight != 0f)
				{
					float num = 0f;
					Vector3 vector = Vector3.zero;
					this.deltaRotation.ToAngleAxis(out num, out vector);
					num *= 0.017453292f;
					num /= this.deltaTime;
					vector *= num * angularVelocityWeight;
					this.r.angularVelocity = Vector3.ClampMagnitude(vector, this.r.maxAngularVelocity);
				}
				this.r.WakeUp();
			}

			// Token: 0x04000838 RID: 2104
			public Rigidbody r;

			// Token: 0x04000839 RID: 2105
			public Transform t;

			// Token: 0x0400083A RID: 2106
			public Collider collider;

			// Token: 0x0400083B RID: 2107
			public Joint joint;

			// Token: 0x0400083C RID: 2108
			public Rigidbody c;

			// Token: 0x0400083D RID: 2109
			public bool updateAnchor;

			// Token: 0x0400083E RID: 2110
			public Vector3 deltaPosition;

			// Token: 0x0400083F RID: 2111
			public Quaternion deltaRotation;

			// Token: 0x04000840 RID: 2112
			public float deltaTime;

			// Token: 0x04000841 RID: 2113
			public Vector3 lastPosition;

			// Token: 0x04000842 RID: 2114
			public Quaternion lastRotation;
		}

		// Token: 0x0200010B RID: 267
		public class Child
		{
			// Token: 0x060008FA RID: 2298 RVA: 0x00039A7D File Offset: 0x00037C7D
			public Child(Transform transform)
			{
				this.t = transform;
				this.localPosition = this.t.localPosition;
				this.localRotation = this.t.localRotation;
			}

			// Token: 0x060008FB RID: 2299 RVA: 0x00039AB0 File Offset: 0x00037CB0
			public void FixTransform(float weight)
			{
				if (weight <= 0f)
				{
					return;
				}
				if (weight >= 1f)
				{
					this.t.localPosition = this.localPosition;
					this.t.localRotation = this.localRotation;
					return;
				}
				this.t.localPosition = Vector3.Lerp(this.t.localPosition, this.localPosition, weight);
				this.t.localRotation = Quaternion.Lerp(this.t.localRotation, this.localRotation, weight);
			}

			// Token: 0x060008FC RID: 2300 RVA: 0x00039B35 File Offset: 0x00037D35
			public void StoreLocalState()
			{
				this.localPosition = this.t.localPosition;
				this.localRotation = this.t.localRotation;
			}

			// Token: 0x04000843 RID: 2115
			public Transform t;

			// Token: 0x04000844 RID: 2116
			public Vector3 localPosition;

			// Token: 0x04000845 RID: 2117
			public Quaternion localRotation;
		}
	}
}
