using System;
using System.Collections;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000178 RID: 376
	public class SoccerDemo : MonoBehaviour
	{
		// Token: 0x06000AE2 RID: 2786 RVA: 0x0004558B File Offset: 0x0004378B
		private void Start()
		{
			this.animator = base.GetComponent<Animator>();
			this.defaultPosition = base.transform.position;
			this.defaultRotation = base.transform.rotation;
			base.StartCoroutine(this.ResetDelayed());
		}

		// Token: 0x06000AE3 RID: 2787 RVA: 0x000455C8 File Offset: 0x000437C8
		private IEnumerator ResetDelayed()
		{
			for (;;)
			{
				yield return new WaitForSeconds(3f);
				base.transform.position = this.defaultPosition;
				base.transform.rotation = this.defaultRotation;
				this.animator.CrossFade("SoccerKick", 0f, 0, 0f);
				yield return null;
			}
			yield break;
		}

		// Token: 0x04000ABB RID: 2747
		private Animator animator;

		// Token: 0x04000ABC RID: 2748
		private Vector3 defaultPosition;

		// Token: 0x04000ABD RID: 2749
		private Quaternion defaultRotation;
	}
}
