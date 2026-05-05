using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x0200011E RID: 286
	[ExecuteInEditMode]
	public class EditorIK : MonoBehaviour
	{
		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000965 RID: 2405 RVA: 0x0003BAC4 File Offset: 0x00039CC4
		// (set) Token: 0x06000966 RID: 2406 RVA: 0x0003BACC File Offset: 0x00039CCC
		public IK ik { get; private set; }

		// Token: 0x06000967 RID: 2407 RVA: 0x0003BAD8 File Offset: 0x00039CD8
		private void OnEnable()
		{
			if (Application.isPlaying)
			{
				return;
			}
			if (this.ik == null)
			{
				this.ik = base.GetComponent<IK>();
			}
			if (this.ik == null)
			{
				Debug.LogError("EditorIK needs to have an IK component on the same GameObject.", base.transform);
				return;
			}
			if (this.bones.Length == 0)
			{
				this.bones = this.ik.transform.GetComponentsInChildren<Transform>();
			}
		}

		// Token: 0x06000968 RID: 2408 RVA: 0x0003BB48 File Offset: 0x00039D48
		private void OnDisable()
		{
			if (Application.isPlaying)
			{
				return;
			}
			if (this.defaultPose != null && this.defaultPose.poseStored)
			{
				this.defaultPose.Restore(this.bones);
			}
			if (this.ik != null)
			{
				this.ik.GetIKSolver().executedInEditor = false;
			}
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x0003BBAC File Offset: 0x00039DAC
		private void OnDestroy()
		{
			if (Application.isPlaying)
			{
				return;
			}
			if (this.ik == null)
			{
				return;
			}
			if (this.bones.Length == 0)
			{
				this.bones = this.ik.transform.GetComponentsInChildren<Transform>();
			}
			if (this.defaultPose != null && this.defaultPose.poseStored && this.bones.Length != 0)
			{
				this.defaultPose.Restore(this.bones);
			}
			this.ik.GetIKSolver().executedInEditor = false;
		}

		// Token: 0x0600096A RID: 2410 RVA: 0x0003BC36 File Offset: 0x00039E36
		public void StoreDefaultPose()
		{
			this.bones = this.ik.transform.GetComponentsInChildren<Transform>();
			this.defaultPose.Store(this.bones);
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x0003BC60 File Offset: 0x00039E60
		public bool Initiate()
		{
			if (this.defaultPose == null)
			{
				return false;
			}
			if (!this.defaultPose.poseStored)
			{
				return false;
			}
			if (this.bones.Length == 0)
			{
				return false;
			}
			if (this.ik == null)
			{
				this.ik = base.GetComponent<IK>();
			}
			if (this.ik == null)
			{
				Debug.LogError("EditorIK can not find an IK component.", base.transform);
				return false;
			}
			this.defaultPose.Restore(this.bones);
			this.ik.GetIKSolver().executedInEditor = false;
			this.ik.GetIKSolver().Initiate(this.ik.transform);
			this.ik.GetIKSolver().executedInEditor = true;
			return true;
		}

		// Token: 0x0600096C RID: 2412 RVA: 0x0003BD24 File Offset: 0x00039F24
		public void Update()
		{
			if (Application.isPlaying)
			{
				return;
			}
			if (this.ik == null)
			{
				return;
			}
			if (!this.ik.enabled)
			{
				return;
			}
			if (!this.ik.GetIKSolver().executedInEditor)
			{
				return;
			}
			if (this.bones.Length == 0)
			{
				this.bones = this.ik.transform.GetComponentsInChildren<Transform>();
			}
			if (this.bones.Length == 0)
			{
				return;
			}
			if (!this.defaultPose.Restore(this.bones))
			{
				return;
			}
			this.ik.GetIKSolver().executedInEditor = false;
			if (!this.ik.GetIKSolver().initiated)
			{
				this.ik.GetIKSolver().Initiate(this.ik.transform);
			}
			if (!this.ik.GetIKSolver().initiated)
			{
				return;
			}
			this.ik.GetIKSolver().executedInEditor = true;
			if (this.animator != null && this.animator.runtimeAnimatorController != null)
			{
				this.animator.Update(Time.deltaTime);
			}
			this.ik.GetIKSolver().Update();
		}

		// Token: 0x040008A5 RID: 2213
		[Tooltip("If slot assigned, will update Animator before IK.")]
		public Animator animator;

		// Token: 0x040008A6 RID: 2214
		[Tooltip("Create/Final IK/Editor IK Pose")]
		public EditorIKPose defaultPose;

		// Token: 0x040008A7 RID: 2215
		[HideInInspector]
		public Transform[] bones = new Transform[0];
	}
}
