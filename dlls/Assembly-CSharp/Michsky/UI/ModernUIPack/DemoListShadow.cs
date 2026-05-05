using System;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x020002FC RID: 764
	public class DemoListShadow : MonoBehaviour
	{
		// Token: 0x06001013 RID: 4115 RVA: 0x00055568 File Offset: 0x00053768
		private void Start()
		{
			this.shadowAnimator = base.gameObject.GetComponent<Animator>();
			this.listScrollbar.value = 1f;
			if (!this.isTop)
			{
				this.shadowAnimator.Play("Out");
				return;
			}
			this.shadowAnimator.Play("In");
		}

		// Token: 0x06001014 RID: 4116 RVA: 0x000555C0 File Offset: 0x000537C0
		private void Update()
		{
			if (this.isTop)
			{
				if (this.listScrollbar.value != 1f && this.enableAnim)
				{
					this.shadowAnimator.Play("In");
					this.listScrollbar.value = Mathf.Lerp(this.listScrollbar.value, 1f, 0.25f);
				}
				if (this.listScrollbar.value == 1f || this.listScrollbar.value >= 0.99f)
				{
					this.listScrollbar.value = 1f;
					this.shadowAnimator.Play("Out");
					this.enableAnim = false;
					return;
				}
				if (this.listScrollbar.value != 1f)
				{
					this.shadowAnimator.Play("In");
					return;
				}
			}
			else
			{
				if (this.listScrollbar.value != 0f && this.enableAnim)
				{
					this.shadowAnimator.Play("In");
					this.listScrollbar.value = Mathf.Lerp(this.listScrollbar.value, 0f, 0.25f);
				}
				if (this.listScrollbar.value == 0f || this.listScrollbar.value <= 0.01f)
				{
					this.listScrollbar.value = 0f;
					this.shadowAnimator.Play("Out");
					this.enableAnim = false;
					return;
				}
				if (this.listScrollbar.value != 0f)
				{
					this.shadowAnimator.Play("In");
				}
			}
		}

		// Token: 0x06001015 RID: 4117 RVA: 0x00055756 File Offset: 0x00053956
		public void ScrollUp()
		{
			this.enableAnim = true;
		}

		// Token: 0x06001016 RID: 4118 RVA: 0x00055756 File Offset: 0x00053956
		public void ScrollDown()
		{
			this.enableAnim = true;
		}

		// Token: 0x0400150D RID: 5389
		public Scrollbar listScrollbar;

		// Token: 0x0400150E RID: 5390
		public bool isTop;

		// Token: 0x0400150F RID: 5391
		private bool enableAnim;

		// Token: 0x04001510 RID: 5392
		private Animator shadowAnimator;
	}
}
