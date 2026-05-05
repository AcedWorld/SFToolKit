using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x02000330 RID: 816
	[RequireComponent(typeof(Animator))]
	public class WindowManagerButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		// Token: 0x060010DF RID: 4319 RVA: 0x0005B4FC File Offset: 0x000596FC
		private void OnEnable()
		{
			if (this.buttonAnimator == null)
			{
				this.buttonAnimator = base.gameObject.GetComponent<Animator>();
			}
		}

		// Token: 0x060010E0 RID: 4320 RVA: 0x0005B520 File Offset: 0x00059720
		public void OnPointerEnter(PointerEventData eventData)
		{
			if (!this.buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Hover to Pressed") && !this.buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Normal to Pressed"))
			{
				this.buttonAnimator.Play("Normal to Hover");
			}
		}

		// Token: 0x060010E1 RID: 4321 RVA: 0x0005B574 File Offset: 0x00059774
		public void OnPointerExit(PointerEventData eventData)
		{
			if (!this.buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Hover to Pressed") && !this.buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Normal to Pressed"))
			{
				this.buttonAnimator.Play("Hover to Normal");
			}
		}

		// Token: 0x040016AB RID: 5803
		[HideInInspector]
		public Animator buttonAnimator;
	}
}
