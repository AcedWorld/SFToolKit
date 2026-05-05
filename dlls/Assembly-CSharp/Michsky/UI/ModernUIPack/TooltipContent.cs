using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x02000323 RID: 803
	public class TooltipContent : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		// Token: 0x060010C6 RID: 4294 RVA: 0x00059EAC File Offset: 0x000580AC
		private void Start()
		{
			if (this.tooltipRect == null || this.descriptionText == null)
			{
				try
				{
					this.tooltipRect = GameObject.Find("Tooltip Rect");
					this.descriptionText = this.tooltipRect.transform.GetComponentInChildren<TextMeshProUGUI>();
				}
				catch
				{
					Debug.LogError("No Tooltip object assigned.", this);
				}
			}
			if (this.tooltipRect != null)
			{
				this.tpManager = this.tooltipRect.GetComponentInParent<TooltipManager>();
				this.tooltipAnimator = this.tooltipRect.GetComponentInParent<Animator>();
			}
		}

		// Token: 0x060010C7 RID: 4295 RVA: 0x00059F4C File Offset: 0x0005814C
		public void OnPointerEnter(PointerEventData eventData)
		{
			if (this.tooltipRect != null)
			{
				this.descriptionText.text = this.description;
				this.tpManager.allowUpdating = true;
				this.tooltipAnimator.gameObject.SetActive(false);
				this.tooltipAnimator.gameObject.SetActive(true);
				this.tooltipAnimator.Play("In");
			}
		}

		// Token: 0x060010C8 RID: 4296 RVA: 0x00059FB6 File Offset: 0x000581B6
		public void OnPointerExit(PointerEventData eventData)
		{
			if (this.tooltipRect != null)
			{
				this.tooltipAnimator.Play("Out");
				this.tpManager.allowUpdating = false;
			}
		}

		// Token: 0x0400160E RID: 5646
		[Header("CONTENT")]
		[TextArea]
		public string description;

		// Token: 0x0400160F RID: 5647
		[Header("RESOURCES")]
		public GameObject tooltipRect;

		// Token: 0x04001610 RID: 5648
		public TextMeshProUGUI descriptionText;

		// Token: 0x04001611 RID: 5649
		private TooltipManager tpManager;

		// Token: 0x04001612 RID: 5650
		[HideInInspector]
		public Animator tooltipAnimator;
	}
}
