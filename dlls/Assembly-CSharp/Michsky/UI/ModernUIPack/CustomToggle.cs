using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x02000322 RID: 802
	[RequireComponent(typeof(Toggle))]
	[RequireComponent(typeof(Animator))]
	public class CustomToggle : MonoBehaviour
	{
		// Token: 0x060010C1 RID: 4289 RVA: 0x00059DF8 File Offset: 0x00057FF8
		private void Start()
		{
			if (this.toggleObject == null)
			{
				this.toggleObject = base.gameObject.GetComponent<Toggle>();
			}
			if (this.toggleAnimator == null)
			{
				this.toggleAnimator = this.toggleObject.GetComponent<Animator>();
			}
			this.toggleObject.onValueChanged.AddListener(new UnityAction<bool>(this.UpdateStateDynamic));
			this.UpdateState();
		}

		// Token: 0x060010C2 RID: 4290 RVA: 0x00059E65 File Offset: 0x00058065
		private void OnEnable()
		{
			if (this.toggleObject == null)
			{
				return;
			}
			this.UpdateState();
		}

		// Token: 0x060010C3 RID: 4291 RVA: 0x00059E7C File Offset: 0x0005807C
		public void UpdateState()
		{
			if (this.toggleObject.isOn)
			{
				this.toggleAnimator.Play("Toggle On");
				return;
			}
			this.toggleAnimator.Play("Toggle Off");
		}

		// Token: 0x060010C4 RID: 4292 RVA: 0x00059E7C File Offset: 0x0005807C
		private void UpdateStateDynamic(bool value)
		{
			if (this.toggleObject.isOn)
			{
				this.toggleAnimator.Play("Toggle On");
				return;
			}
			this.toggleAnimator.Play("Toggle Off");
		}

		// Token: 0x0400160C RID: 5644
		[HideInInspector]
		public Toggle toggleObject;

		// Token: 0x0400160D RID: 5645
		[HideInInspector]
		public Animator toggleAnimator;
	}
}
