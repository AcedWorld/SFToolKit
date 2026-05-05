using System;
using System.Collections;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x02000078 RID: 120
	public class PuppetMasterLite : MonoBehaviour
	{
		// Token: 0x060003DA RID: 986 RVA: 0x00017521 File Offset: 0x00015721
		private void Start()
		{
			this.Initiate();
		}

		// Token: 0x060003DB RID: 987 RVA: 0x0001752C File Offset: 0x0001572C
		public void Activate()
		{
			if (base.gameObject.activeInHierarchy)
			{
				return;
			}
			this.mappingWeight = 0f;
			MuscleLite[] array = this.muscles;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Reset();
			}
			base.gameObject.SetActive(true);
			foreach (MuscleLite muscleLite in this.muscles)
			{
				muscleLite.rigidbody.WakeUp();
				muscleLite.MoveToTarget();
				muscleLite.ClearVelocities();
			}
			this.Read();
			base.StopAllCoroutines();
			base.StartCoroutine(this.Activation());
		}

		// Token: 0x060003DC RID: 988 RVA: 0x000175C2 File Offset: 0x000157C2
		private IEnumerator Activation()
		{
			if (this.blendTime <= 0f)
			{
				this.mappingWeight = 1f;
				yield break;
			}
			while (this.mappingWeight < 1f)
			{
				this.mappingWeight = Mathf.MoveTowards(this.mappingWeight, 1f, Time.deltaTime * (1f / this.blendTime));
				yield return null;
			}
			yield break;
		}

		// Token: 0x060003DD RID: 989 RVA: 0x000175D1 File Offset: 0x000157D1
		public void Deactivate()
		{
			if (!base.gameObject.activeInHierarchy)
			{
				return;
			}
			base.StopAllCoroutines();
			base.StartCoroutine(this.Deactivation());
		}

		// Token: 0x060003DE RID: 990 RVA: 0x000175F4 File Offset: 0x000157F4
		private IEnumerator Deactivation()
		{
			if (this.blendTime > 0f)
			{
				while (this.mappingWeight > 0f)
				{
					this.mappingWeight = Mathf.MoveTowards(this.mappingWeight, 0f, Time.deltaTime * (1f / this.blendTime));
					yield return null;
				}
			}
			if (this.animatorDisabled)
			{
				this.targetAnimator.enabled = true;
			}
			this.animatorDisabled = false;
			base.gameObject.SetActive(false);
			yield break;
		}

		// Token: 0x060003DF RID: 991 RVA: 0x00017604 File Offset: 0x00015804
		private void Initiate()
		{
			if (this.targetRoot.gameObject.layer == base.gameObject.layer)
			{
				Debug.LogError("Target Root is on the same layer as PuppetMasterLite! Please use different layers and make sure collisions between those layers are disabled in the Layer Collision Matrix.", base.transform);
			}
			this.targetAnimator = this.targetRoot.GetComponentInChildren<Animator>();
			if (this.targetAnimator != null && this.targetAnimator.updateMode == AnimatorUpdateMode.AnimatePhysics)
			{
				this.updateMode = PuppetMasterLite.UpdateMode.Fixed;
			}
			MuscleLite[] array = this.muscles;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Initiate(this.muscles);
			}
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x00017695 File Offset: 0x00015895
		private void Update()
		{
			this.updateMode = ((this.targetAnimator == null || this.targetAnimator.updateMode != AnimatorUpdateMode.AnimatePhysics) ? PuppetMasterLite.UpdateMode.Normal : PuppetMasterLite.UpdateMode.Fixed);
			if (this.updateMode == PuppetMasterLite.UpdateMode.Fixed)
			{
				return;
			}
			this.FixTargetTransforms();
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x000176D0 File Offset: 0x000158D0
		private void FixTargetTransforms()
		{
			if (!this.fixTargetTransforms)
			{
				return;
			}
			MuscleLite[] array = this.muscles;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].FixTargetTransforms();
			}
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x00017704 File Offset: 0x00015904
		private void FixedUpdate()
		{
			this.fixedFrame = true;
			if (this.updateMode == PuppetMasterLite.UpdateMode.Fixed)
			{
				this.FixTargetTransforms();
				if (this.targetAnimator.enabled || (!this.targetAnimator.enabled && this.animatorDisabled))
				{
					this.targetAnimator.enabled = false;
					this.animatorDisabled = true;
					this.targetAnimator.Update(Time.fixedDeltaTime);
				}
				else
				{
					this.animatorDisabled = false;
					this.targetAnimator.enabled = false;
				}
				this.Read();
			}
			MuscleLite[] array = this.muscles;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Update(this.pinWeight, this.muscleWeight, this.muscleSpring, this.muscleDamper, this.angularPinning);
			}
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x000177C4 File Offset: 0x000159C4
		private void LateUpdate()
		{
			if (this.animatorDisabled)
			{
				this.targetAnimator.enabled = true;
			}
			this.animatorDisabled = false;
			if (this.updateMode == PuppetMasterLite.UpdateMode.Fixed)
			{
				if (this.fixedFrame)
				{
					this.Write();
				}
			}
			else
			{
				this.Read();
				this.Write();
			}
			this.fixedFrame = false;
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x00017818 File Offset: 0x00015A18
		private void Read()
		{
			if (this.OnRead != null)
			{
				this.OnRead();
			}
			MuscleLite[] array = this.muscles;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Read();
			}
			if (this.updateJointAnchors)
			{
				array = this.muscles;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].UpdateAnchor(true);
				}
			}
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x0001787C File Offset: 0x00015A7C
		private void Write()
		{
			MuscleLite[] array = this.muscles;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Map(this.mappingWeight);
			}
			if (this.OnWrite != null)
			{
				this.OnWrite();
			}
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x000178C0 File Offset: 0x00015AC0
		private void OnDrawGizmosSelected()
		{
			if (Application.isPlaying)
			{
				return;
			}
			for (int i = 0; i < this.muscles.Length; i++)
			{
				this.muscles[i].name = i.ToString() + ": " + ((this.muscles[i].joint != null) ? this.muscles[i].joint.name : "Missing Joint reference!");
			}
		}

		// Token: 0x0400036C RID: 876
		public Transform targetRoot;

		// Token: 0x0400036D RID: 877
		public bool fixTargetTransforms = true;

		// Token: 0x0400036E RID: 878
		public float blendTime = 0.1f;

		// Token: 0x0400036F RID: 879
		[Range(0f, 1f)]
		public float mappingWeight = 1f;

		// Token: 0x04000370 RID: 880
		[Range(0f, 1f)]
		public float pinWeight = 1f;

		// Token: 0x04000371 RID: 881
		[Range(0f, 1f)]
		public float muscleWeight = 1f;

		// Token: 0x04000372 RID: 882
		public float muscleSpring = 1000f;

		// Token: 0x04000373 RID: 883
		public float muscleDamper = 100f;

		// Token: 0x04000374 RID: 884
		public bool updateJointAnchors = true;

		// Token: 0x04000375 RID: 885
		public bool angularPinning;

		// Token: 0x04000376 RID: 886
		[LargeHeader("Individual Muscle Settings")]
		public MuscleLite[] muscles = new MuscleLite[0];

		// Token: 0x04000377 RID: 887
		public PuppetMasterLite.PuppetMasterLiteDelegate OnRead;

		// Token: 0x04000378 RID: 888
		public PuppetMasterLite.PuppetMasterLiteDelegate OnWrite;

		// Token: 0x04000379 RID: 889
		private Animator targetAnimator;

		// Token: 0x0400037A RID: 890
		private bool animatorDisabled;

		// Token: 0x0400037B RID: 891
		private bool fixedFrame;

		// Token: 0x0400037C RID: 892
		private PuppetMasterLite.UpdateMode updateMode;

		// Token: 0x02000079 RID: 121
		// (Invoke) Token: 0x060003E9 RID: 1001
		public delegate void PuppetMasterLiteDelegate();

		// Token: 0x0200007A RID: 122
		public enum UpdateMode
		{
			// Token: 0x0400037E RID: 894
			Normal,
			// Token: 0x0400037F RID: 895
			Fixed
		}
	}
}
