using System;
using UnityEngine;

namespace RootMotion
{
	// Token: 0x02000005 RID: 5
	public abstract class AnimationModifier : MonoBehaviour
	{
		// Token: 0x06000008 RID: 8 RVA: 0x0000222E File Offset: 0x0000042E
		public virtual void OnInitiate(Baker baker, Animator animator)
		{
			this.baker = baker;
			this.animator = animator;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000223E File Offset: 0x0000043E
		public virtual void OnStartClip(AnimationClip clip)
		{
		}

		// Token: 0x0600000A RID: 10 RVA: 0x0000223E File Offset: 0x0000043E
		public virtual void OnBakerUpdate(float normalizedTime)
		{
		}

		// Token: 0x0400000C RID: 12
		protected Animator animator;

		// Token: 0x0400000D RID: 13
		protected Baker baker;
	}
}
