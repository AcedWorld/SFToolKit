using System;
using UnityEngine;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x020002FB RID: 763
	public class ContextMenuManager : MonoBehaviour
	{
		// Token: 0x0600100E RID: 4110 RVA: 0x000551AC File Offset: 0x000533AC
		private void Start()
		{
			if (this.mainCanvas == null)
			{
				this.mainCanvas = base.gameObject.GetComponentInParent<Canvas>();
			}
			if (this.contextAnimator == null)
			{
				this.contextAnimator = base.gameObject.GetComponent<Animator>();
			}
			this.contextRect = base.gameObject.GetComponent<RectTransform>();
			this.contentPos = new Vector3((float)this.vBorderTop, (float)this.hBorderLeft, 0f);
			base.gameObject.transform.SetAsLastSibling();
		}

		// Token: 0x0600100F RID: 4111 RVA: 0x00055238 File Offset: 0x00053438
		public void CheckForBounds()
		{
			if (this.uiPos.x <= -100f)
			{
				this.contentPos = new Vector3((float)this.hBorderLeft, this.contentPos.y, 0f);
				this.contextContent.GetComponent<RectTransform>().pivot = new Vector2(0f, this.contextContent.GetComponent<RectTransform>().pivot.y);
			}
			if (this.uiPos.x >= 100f)
			{
				this.contentPos = new Vector3((float)this.hBorderRight, this.contentPos.y, 0f);
				this.contextContent.GetComponent<RectTransform>().pivot = new Vector2(1f, this.contextContent.GetComponent<RectTransform>().pivot.y);
			}
			if (this.uiPos.y <= -75f)
			{
				this.contentPos = new Vector3(this.contentPos.x, (float)this.vBorderBottom, 0f);
				this.contextContent.GetComponent<RectTransform>().pivot = new Vector2(this.contextContent.GetComponent<RectTransform>().pivot.x, 0f);
			}
			if (this.uiPos.y >= 75f)
			{
				this.contentPos = new Vector3(this.contentPos.x, (float)this.vBorderTop, 0f);
				this.contextContent.GetComponent<RectTransform>().pivot = new Vector2(this.contextContent.GetComponent<RectTransform>().pivot.x, 1f);
			}
		}

		// Token: 0x06001010 RID: 4112 RVA: 0x000553D4 File Offset: 0x000535D4
		public void SetContextMenuPosition()
		{
			this.cursorPos = Input.mousePosition;
			this.uiPos = this.contextRect.anchoredPosition;
			this.CheckForBounds();
			if (this.mainCanvas.renderMode == RenderMode.ScreenSpaceCamera || this.mainCanvas.renderMode == RenderMode.WorldSpace)
			{
				this.cursorPos.z = base.gameObject.transform.position.z;
				this.contextRect.position = Camera.main.ScreenToWorldPoint(this.cursorPos);
				this.contextContent.transform.localPosition = Vector3.SmoothDamp(this.contextContent.transform.localPosition, this.contentPos, ref this.contextVelocity, 0f);
				return;
			}
			if (this.mainCanvas.renderMode == RenderMode.ScreenSpaceOverlay)
			{
				this.contextRect.position = this.cursorPos;
				this.contextContent.transform.position = new Vector3(this.cursorPos.x + this.contentPos.x, this.cursorPos.y + this.contentPos.y, 0f);
			}
		}

		// Token: 0x06001011 RID: 4113 RVA: 0x000554F7 File Offset: 0x000536F7
		public void CloseOnClick()
		{
			this.contextAnimator.Play("Menu Out");
			this.isContextMenuOn = false;
		}

		// Token: 0x040014FF RID: 5375
		[SerializeField]
		public Canvas mainCanvas;

		// Token: 0x04001500 RID: 5376
		public GameObject contextButton;

		// Token: 0x04001501 RID: 5377
		public GameObject contextContent;

		// Token: 0x04001502 RID: 5378
		public Animator contextAnimator;

		// Token: 0x04001503 RID: 5379
		[HideInInspector]
		public bool isContextMenuOn;

		// Token: 0x04001504 RID: 5380
		[Range(-50f, 50f)]
		public int vBorderTop = -10;

		// Token: 0x04001505 RID: 5381
		[Range(-50f, 50f)]
		public int vBorderBottom = 10;

		// Token: 0x04001506 RID: 5382
		[Range(-50f, 50f)]
		public int hBorderLeft = 15;

		// Token: 0x04001507 RID: 5383
		[Range(-50f, 50f)]
		public int hBorderRight = -15;

		// Token: 0x04001508 RID: 5384
		private Vector2 uiPos;

		// Token: 0x04001509 RID: 5385
		private Vector3 cursorPos;

		// Token: 0x0400150A RID: 5386
		private Vector3 contentPos = new Vector3(0f, 0f, 0f);

		// Token: 0x0400150B RID: 5387
		private Vector3 contextVelocity = Vector3.zero;

		// Token: 0x0400150C RID: 5388
		private RectTransform contextRect;
	}
}
