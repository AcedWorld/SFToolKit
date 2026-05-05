using System;
using UnityEngine;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x02000324 RID: 804
	public class TooltipManager : MonoBehaviour
	{
		// Token: 0x060010CA RID: 4298 RVA: 0x00059FE4 File Offset: 0x000581E4
		private void Start()
		{
			this.tooltipContent.GetComponent<RectTransform>().pivot = new Vector2(0f, this.tooltipContent.GetComponent<RectTransform>().pivot.y);
			this.tooltipContent.GetComponent<RectTransform>().pivot = new Vector2(this.tooltipContent.GetComponent<RectTransform>().pivot.x, 0f);
			if (this.mainCanvas == null)
			{
				this.mainCanvas = base.gameObject.GetComponentInParent<Canvas>();
			}
			this.tooltipZHelper = base.gameObject.GetComponentInParent<RectTransform>();
			this.tooltipRect = this.tooltipObject.GetComponent<RectTransform>();
			this.contentPos = new Vector3((float)this.vBorderTop, (float)this.hBorderLeft, 0f);
			base.gameObject.transform.SetAsLastSibling();
		}

		// Token: 0x060010CB RID: 4299 RVA: 0x0005A0C0 File Offset: 0x000582C0
		private void Update()
		{
			if (this.allowUpdating)
			{
				this.cursorPos = Input.mousePosition;
				this.cursorPos.z = this.tooltipZHelper.position.z;
				this.uiPos = this.tooltipRect.anchoredPosition;
				this.CheckForBounds();
				if (this.mainCanvas.renderMode == RenderMode.ScreenSpaceCamera || this.mainCanvas.renderMode == RenderMode.WorldSpace)
				{
					this.tooltipRect.position = Camera.main.ScreenToWorldPoint(this.cursorPos);
					this.tooltipContent.transform.localPosition = Vector3.SmoothDamp(this.tooltipContent.transform.localPosition, this.contentPos, ref this.tooltipVelocity, this.tooltipSmoothness);
					return;
				}
				if (this.mainCanvas.renderMode == RenderMode.ScreenSpaceOverlay)
				{
					this.tooltipRect.position = this.cursorPos;
					this.tooltipContent.transform.position = Vector3.SmoothDamp(this.tooltipContent.transform.position, this.cursorPos + this.contentPos, ref this.tooltipVelocity, this.tooltipSmoothness);
				}
			}
		}

		// Token: 0x060010CC RID: 4300 RVA: 0x0005A1E4 File Offset: 0x000583E4
		public void CheckForBounds()
		{
			if (this.uiPos.x <= -400f)
			{
				this.contentPos = new Vector3((float)this.hBorderLeft, this.contentPos.y, 0f);
				this.tooltipContent.GetComponent<RectTransform>().pivot = new Vector2(0f, this.tooltipContent.GetComponent<RectTransform>().pivot.y);
			}
			if (this.uiPos.x >= 400f)
			{
				this.contentPos = new Vector3((float)this.hBorderRight, this.contentPos.y, 0f);
				this.tooltipContent.GetComponent<RectTransform>().pivot = new Vector2(1f, this.tooltipContent.GetComponent<RectTransform>().pivot.y);
			}
			if (this.uiPos.y <= -325f)
			{
				this.contentPos = new Vector3(this.contentPos.x, (float)this.vBorderBottom, 0f);
				this.tooltipContent.GetComponent<RectTransform>().pivot = new Vector2(this.tooltipContent.GetComponent<RectTransform>().pivot.x, 0f);
			}
			if (this.uiPos.y >= 325f)
			{
				this.contentPos = new Vector3(this.contentPos.x, (float)this.vBorderTop, 0f);
				this.tooltipContent.GetComponent<RectTransform>().pivot = new Vector2(this.tooltipContent.GetComponent<RectTransform>().pivot.x, 1f);
			}
		}

		// Token: 0x04001613 RID: 5651
		public Canvas mainCanvas;

		// Token: 0x04001614 RID: 5652
		public GameObject tooltipObject;

		// Token: 0x04001615 RID: 5653
		public GameObject tooltipContent;

		// Token: 0x04001616 RID: 5654
		[Range(0.05f, 0.5f)]
		public float tooltipSmoothness = 0.1f;

		// Token: 0x04001617 RID: 5655
		public bool allowUpdating;

		// Token: 0x04001618 RID: 5656
		public int vBorderTop = -115;

		// Token: 0x04001619 RID: 5657
		public int vBorderBottom = 100;

		// Token: 0x0400161A RID: 5658
		public int hBorderLeft = 230;

		// Token: 0x0400161B RID: 5659
		public int hBorderRight = -210;

		// Token: 0x0400161C RID: 5660
		private Vector2 uiPos;

		// Token: 0x0400161D RID: 5661
		private Vector3 cursorPos;

		// Token: 0x0400161E RID: 5662
		private RectTransform tooltipRect;

		// Token: 0x0400161F RID: 5663
		private RectTransform tooltipZHelper;

		// Token: 0x04001620 RID: 5664
		private Vector3 contentPos = new Vector3(0f, 0f, 0f);

		// Token: 0x04001621 RID: 5665
		private Vector3 tooltipVelocity = Vector3.zero;
	}
}
