using System;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000146 RID: 326
	public class FKOffset : MonoBehaviour
	{
		// Token: 0x06000A21 RID: 2593 RVA: 0x0004036B File Offset: 0x0003E56B
		private void Start()
		{
			this.animator = base.GetComponent<Animator>();
		}

		// Token: 0x06000A22 RID: 2594 RVA: 0x0004037C File Offset: 0x0003E57C
		private void LateUpdate()
		{
			FKOffset.Offset[] array = this.offsets;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Apply(this.animator);
			}
		}

		// Token: 0x06000A23 RID: 2595 RVA: 0x000403AC File Offset: 0x0003E5AC
		private void OnDrawGizmosSelected()
		{
			foreach (FKOffset.Offset offset in this.offsets)
			{
				offset.name = offset.bone.ToString();
			}
		}

		// Token: 0x0400097B RID: 2427
		public FKOffset.Offset[] offsets;

		// Token: 0x0400097C RID: 2428
		private Animator animator;

		// Token: 0x02000147 RID: 327
		[Serializable]
		public class Offset
		{
			// Token: 0x06000A25 RID: 2597 RVA: 0x000403E8 File Offset: 0x0003E5E8
			public void Apply(Animator animator)
			{
				if (this.t == null)
				{
					this.t = animator.GetBoneTransform(this.bone);
				}
				if (this.t == null)
				{
					return;
				}
				this.t.localRotation *= Quaternion.Euler(this.rotationOffset);
			}

			// Token: 0x0400097D RID: 2429
			[HideInInspector]
			public string name;

			// Token: 0x0400097E RID: 2430
			public HumanBodyBones bone;

			// Token: 0x0400097F RID: 2431
			public Vector3 rotationOffset;

			// Token: 0x04000980 RID: 2432
			private Transform t;
		}
	}
}
