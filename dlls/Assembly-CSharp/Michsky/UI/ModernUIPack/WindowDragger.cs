using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x0200032D RID: 813
	public class WindowDragger : UIBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler
	{
		// Token: 0x060010CF RID: 4303 RVA: 0x0005AA90 File Offset: 0x00058C90
		public new void Start()
		{
			if (this.dragArea == null)
			{
				try
				{
					Canvas canvas = (Canvas)Object.FindObjectsOfType(typeof(Canvas))[0];
					this.dragArea = canvas.GetComponent<RectTransform>();
				}
				catch
				{
					Debug.LogError("Movable Window - Drag Area has not been assigned.");
				}
			}
		}

		// Token: 0x17000334 RID: 820
		// (get) Token: 0x060010D0 RID: 4304 RVA: 0x0005AAF0 File Offset: 0x00058CF0
		private RectTransform DragObjectInternal
		{
			get
			{
				if (this.dragObject == null)
				{
					return base.transform as RectTransform;
				}
				return this.dragObject;
			}
		}

		// Token: 0x17000335 RID: 821
		// (get) Token: 0x060010D1 RID: 4305 RVA: 0x0005AB14 File Offset: 0x00058D14
		private RectTransform DragAreaInternal
		{
			get
			{
				if (this.dragArea == null)
				{
					RectTransform rectTransform = base.transform as RectTransform;
					while (rectTransform.parent != null && rectTransform.parent is RectTransform)
					{
						rectTransform = (rectTransform.parent as RectTransform);
					}
					return rectTransform;
				}
				return this.dragArea;
			}
		}

		// Token: 0x060010D2 RID: 4306 RVA: 0x0005AB6C File Offset: 0x00058D6C
		public void OnBeginDrag(PointerEventData data)
		{
			this.originalPanelLocalPosition = this.DragObjectInternal.localPosition;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(this.DragAreaInternal, data.position, data.pressEventCamera, out this.originalLocalPointerPosition);
			base.gameObject.transform.SetAsLastSibling();
			if (this.topOnClick)
			{
				this.dragObject.transform.SetAsLastSibling();
			}
		}

		// Token: 0x060010D3 RID: 4307 RVA: 0x0005ABD0 File Offset: 0x00058DD0
		public void OnDrag(PointerEventData data)
		{
			Vector2 a;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(this.DragAreaInternal, data.position, data.pressEventCamera, out a))
			{
				Vector3 b = a - this.originalLocalPointerPosition;
				this.DragObjectInternal.localPosition = this.originalPanelLocalPosition + b;
			}
			this.ClampToArea();
		}

		// Token: 0x060010D4 RID: 4308 RVA: 0x0005AC28 File Offset: 0x00058E28
		private void ClampToArea()
		{
			Vector3 localPosition = this.DragObjectInternal.localPosition;
			Vector3 vector = this.DragAreaInternal.rect.min - this.DragObjectInternal.rect.min;
			Vector3 vector2 = this.DragAreaInternal.rect.max - this.DragObjectInternal.rect.max;
			localPosition.x = Mathf.Clamp(this.DragObjectInternal.localPosition.x, vector.x, vector2.x);
			localPosition.y = Mathf.Clamp(this.DragObjectInternal.localPosition.y, vector.y, vector2.y);
			this.DragObjectInternal.localPosition = localPosition;
		}

		// Token: 0x0400168F RID: 5775
		[Header("RESOURCES")]
		public RectTransform dragArea;

		// Token: 0x04001690 RID: 5776
		public RectTransform dragObject;

		// Token: 0x04001691 RID: 5777
		[Header("SETTINGS")]
		public bool topOnClick = true;

		// Token: 0x04001692 RID: 5778
		private Vector2 originalLocalPointerPosition;

		// Token: 0x04001693 RID: 5779
		private Vector3 originalPanelLocalPosition;
	}
}
