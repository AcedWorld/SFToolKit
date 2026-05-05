using System;
using TMPro;
using UnityEngine;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x0200030B RID: 779
	[RequireComponent(typeof(TMP_InputField))]
	[RequireComponent(typeof(Animator))]
	public class CustomInputField : MonoBehaviour
	{
		// Token: 0x06001046 RID: 4166 RVA: 0x00057430 File Offset: 0x00055630
		private void Start()
		{
			if (this.inputText == null)
			{
				this.inputText = base.gameObject.GetComponent<TMP_InputField>();
			}
			if (this.inputFieldAnimator == null)
			{
				this.inputFieldAnimator = base.gameObject.GetComponent<Animator>();
			}
			this.inputText.onSelect.AddListener(delegate(string <p0>)
			{
				this.AnimateIn();
			});
			this.inputText.onEndEdit.AddListener(delegate(string <p0>)
			{
				this.AnimateOut();
			});
			this.UpdateState();
		}

		// Token: 0x06001047 RID: 4167 RVA: 0x000574B9 File Offset: 0x000556B9
		private void OnEnable()
		{
			if (this.inputText == null)
			{
				return;
			}
			this.inputText.ForceLabelUpdate();
			this.UpdateState();
		}

		// Token: 0x06001048 RID: 4168 RVA: 0x000574DB File Offset: 0x000556DB
		public void AnimateIn()
		{
			this.inputFieldAnimator.Play(this.inAnim);
		}

		// Token: 0x06001049 RID: 4169 RVA: 0x000574EE File Offset: 0x000556EE
		public void AnimateOut()
		{
			if (this.inputText.text.Length == 0)
			{
				this.inputFieldAnimator.Play(this.outAnim);
			}
		}

		// Token: 0x0600104A RID: 4170 RVA: 0x00057513 File Offset: 0x00055713
		public void UpdateState()
		{
			if (this.inputText.text.Length == 0)
			{
				this.AnimateOut();
				return;
			}
			this.AnimateIn();
		}

		// Token: 0x04001576 RID: 5494
		[HideInInspector]
		public TMP_InputField inputText;

		// Token: 0x04001577 RID: 5495
		[HideInInspector]
		public Animator inputFieldAnimator;

		// Token: 0x04001578 RID: 5496
		private string inAnim = "In";

		// Token: 0x04001579 RID: 5497
		private string outAnim = "Out";
	}
}
