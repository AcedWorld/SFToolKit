using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x020002E2 RID: 738
	public class AnimatedIconHandler : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		// Token: 0x06000F8A RID: 3978 RVA: 0x00052978 File Offset: 0x00050B78
		private void Start()
		{
			this.iconAnimator = base.gameObject.GetComponent<Animator>();
			if (this.playType == AnimatedIconHandler.PlayType.CLICK)
			{
				this.eventButton = base.gameObject.GetComponent<Button>();
				this.eventButton.onClick.AddListener(new UnityAction(this.ClickEvent));
			}
		}

		// Token: 0x06000F8B RID: 3979 RVA: 0x000529CB File Offset: 0x00050BCB
		public void ClickEvent()
		{
			if (this.isClicked)
			{
				this.iconAnimator.Play("Out");
				this.isClicked = false;
				return;
			}
			this.iconAnimator.Play("In");
			this.isClicked = true;
		}

		// Token: 0x06000F8C RID: 3980 RVA: 0x00052A04 File Offset: 0x00050C04
		public void OnPointerEnter(PointerEventData eventData)
		{
			if (this.playType == AnimatedIconHandler.PlayType.ON_POINTER_ENTER)
			{
				this.iconAnimator.Play("In");
			}
		}

		// Token: 0x06000F8D RID: 3981 RVA: 0x00052A1F File Offset: 0x00050C1F
		public void OnPointerExit(PointerEventData eventData)
		{
			if (this.playType == AnimatedIconHandler.PlayType.ON_POINTER_ENTER)
			{
				this.iconAnimator.Play("Out");
			}
		}

		// Token: 0x04001419 RID: 5145
		[Header("SETTINGS")]
		public AnimatedIconHandler.PlayType playType;

		// Token: 0x0400141A RID: 5146
		private Animator iconAnimator;

		// Token: 0x0400141B RID: 5147
		private Button eventButton;

		// Token: 0x0400141C RID: 5148
		private bool isClicked;

		// Token: 0x020002E3 RID: 739
		public enum PlayType
		{
			// Token: 0x0400141E RID: 5150
			CLICK,
			// Token: 0x0400141F RID: 5151
			ON_POINTER_ENTER
		}
	}
}
