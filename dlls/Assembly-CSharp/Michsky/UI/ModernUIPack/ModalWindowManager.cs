using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x0200030C RID: 780
	public class ModalWindowManager : MonoBehaviour
	{
		// Token: 0x0600104E RID: 4174 RVA: 0x00057564 File Offset: 0x00055764
		private void Start()
		{
			if (this.mwAnimator == null)
			{
				this.mwAnimator = base.gameObject.GetComponent<Animator>();
			}
			if (this.confirmButton != null)
			{
				this.confirmButton.onClick.AddListener(new UnityAction(this.onConfirm.Invoke));
			}
			if (this.cancelButton != null)
			{
				this.cancelButton.onClick.AddListener(new UnityAction(this.onCancel.Invoke));
			}
			if (!this.useCustomValues)
			{
				this.UpdateUI();
			}
		}

		// Token: 0x0600104F RID: 4175 RVA: 0x000575FC File Offset: 0x000557FC
		public void UpdateUI()
		{
			try
			{
				this.windowIcon.sprite = this.icon;
				this.windowTitle.text = this.titleText;
				this.windowDescription.text = this.descriptionText;
			}
			catch
			{
				Debug.LogWarning("Modal Window - Cannot update the content due to missing variables.", this);
			}
		}

		// Token: 0x06001050 RID: 4176 RVA: 0x0005765C File Offset: 0x0005585C
		public void OpenWindow()
		{
			if (!this.isOn)
			{
				if (!this.sharpAnimations)
				{
					this.mwAnimator.CrossFade("Fade-in", 0.1f);
				}
				else
				{
					this.mwAnimator.Play("Fade-in");
				}
				this.isOn = true;
			}
		}

		// Token: 0x06001051 RID: 4177 RVA: 0x0005769C File Offset: 0x0005589C
		public void CloseWindow()
		{
			if (this.isOn)
			{
				if (!this.sharpAnimations)
				{
					this.mwAnimator.CrossFade("Fade-out", 0.1f);
				}
				else
				{
					this.mwAnimator.Play("Fade-out");
				}
				this.isOn = false;
			}
		}

		// Token: 0x06001052 RID: 4178 RVA: 0x000576DC File Offset: 0x000558DC
		public void AnimateWindow()
		{
			if (!this.isOn)
			{
				if (!this.sharpAnimations)
				{
					this.mwAnimator.CrossFade("Fade-in", 0.1f);
				}
				else
				{
					this.mwAnimator.Play("Fade-in");
				}
				this.isOn = true;
				return;
			}
			if (!this.sharpAnimations)
			{
				this.mwAnimator.CrossFade("Fade-out", 0.1f);
			}
			else
			{
				this.mwAnimator.Play("Fade-out");
			}
			this.isOn = false;
		}

		// Token: 0x0400157A RID: 5498
		public Image windowIcon;

		// Token: 0x0400157B RID: 5499
		public TextMeshProUGUI windowTitle;

		// Token: 0x0400157C RID: 5500
		public TextMeshProUGUI windowDescription;

		// Token: 0x0400157D RID: 5501
		public Button confirmButton;

		// Token: 0x0400157E RID: 5502
		public Button cancelButton;

		// Token: 0x0400157F RID: 5503
		public Animator mwAnimator;

		// Token: 0x04001580 RID: 5504
		public Sprite icon;

		// Token: 0x04001581 RID: 5505
		public string titleText = "Title";

		// Token: 0x04001582 RID: 5506
		[TextArea]
		public string descriptionText = "Description here";

		// Token: 0x04001583 RID: 5507
		public UnityEvent onConfirm;

		// Token: 0x04001584 RID: 5508
		public UnityEvent onCancel;

		// Token: 0x04001585 RID: 5509
		public bool sharpAnimations;

		// Token: 0x04001586 RID: 5510
		public bool useCustomValues;

		// Token: 0x04001587 RID: 5511
		public bool isOn;
	}
}
