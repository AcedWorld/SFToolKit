using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Rewired.Demos
{
	// Token: 0x020002B2 RID: 690
	[AddComponentMenu("")]
	[RequireComponent(typeof(Image))]
	public class TouchJoystickExample : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
	{
		// Token: 0x170002FC RID: 764
		// (get) Token: 0x06000E8A RID: 3722 RVA: 0x0004E214 File Offset: 0x0004C414
		// (set) Token: 0x06000E8B RID: 3723 RVA: 0x0004E21C File Offset: 0x0004C41C
		public Vector2 position { get; private set; }

		// Token: 0x06000E8C RID: 3724 RVA: 0x0004E225 File Offset: 0x0004C425
		private void Start()
		{
			if (SystemInfo.deviceType == DeviceType.Handheld)
			{
				this.allowMouseControl = false;
			}
			this.StoreOrigValues();
		}

		// Token: 0x06000E8D RID: 3725 RVA: 0x0004E23C File Offset: 0x0004C43C
		private void Update()
		{
			if ((float)Screen.width != this.origScreenResolution.x || (float)Screen.height != this.origScreenResolution.y || Screen.orientation != this.origScreenOrientation)
			{
				this.Restart();
				this.StoreOrigValues();
			}
		}

		// Token: 0x06000E8E RID: 3726 RVA: 0x0004E288 File Offset: 0x0004C488
		private void Restart()
		{
			this.hasFinger = false;
			(base.transform as RectTransform).anchoredPosition = this.origAnchoredPosition;
			this.position = Vector2.zero;
		}

		// Token: 0x06000E8F RID: 3727 RVA: 0x0004E2B4 File Offset: 0x0004C4B4
		private void StoreOrigValues()
		{
			this.origAnchoredPosition = (base.transform as RectTransform).anchoredPosition;
			this.origWorldPosition = base.transform.position;
			this.origScreenResolution = new Vector2((float)Screen.width, (float)Screen.height);
			this.origScreenOrientation = Screen.orientation;
		}

		// Token: 0x06000E90 RID: 3728 RVA: 0x0004E30C File Offset: 0x0004C50C
		private void UpdateValue(Vector3 value)
		{
			Vector3 vector = this.origWorldPosition - value;
			vector.y = -vector.y;
			vector /= (float)this.radius;
			this.position = new Vector2(-vector.x, vector.y);
		}

		// Token: 0x06000E91 RID: 3729 RVA: 0x0004E35A File Offset: 0x0004C55A
		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
			if (this.hasFinger)
			{
				return;
			}
			if (!this.allowMouseControl && TouchJoystickExample.IsMousePointerId(eventData.pointerId))
			{
				return;
			}
			this.hasFinger = true;
			this.lastFingerId = eventData.pointerId;
		}

		// Token: 0x06000E92 RID: 3730 RVA: 0x0004E38E File Offset: 0x0004C58E
		void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
		{
			if (eventData.pointerId != this.lastFingerId)
			{
				return;
			}
			if (!this.allowMouseControl && TouchJoystickExample.IsMousePointerId(eventData.pointerId))
			{
				return;
			}
			this.Restart();
		}

		// Token: 0x06000E93 RID: 3731 RVA: 0x0004E3BC File Offset: 0x0004C5BC
		void IDragHandler.OnDrag(PointerEventData eventData)
		{
			if (!this.hasFinger || eventData.pointerId != this.lastFingerId)
			{
				return;
			}
			Vector3 vector = new Vector3(eventData.position.x - this.origWorldPosition.x, eventData.position.y - this.origWorldPosition.y);
			vector = Vector3.ClampMagnitude(vector, (float)this.radius);
			Vector3 vector2 = this.origWorldPosition + vector;
			base.transform.position = vector2;
			this.UpdateValue(vector2);
		}

		// Token: 0x06000E94 RID: 3732 RVA: 0x0004E1F3 File Offset: 0x0004C3F3
		private static bool IsMousePointerId(int id)
		{
			return id == -1 || id == -2 || id == -3;
		}

		// Token: 0x04001331 RID: 4913
		public bool allowMouseControl = true;

		// Token: 0x04001332 RID: 4914
		public int radius = 50;

		// Token: 0x04001333 RID: 4915
		private Vector2 origAnchoredPosition;

		// Token: 0x04001334 RID: 4916
		private Vector3 origWorldPosition;

		// Token: 0x04001335 RID: 4917
		private Vector2 origScreenResolution;

		// Token: 0x04001336 RID: 4918
		private ScreenOrientation origScreenOrientation;

		// Token: 0x04001337 RID: 4919
		[NonSerialized]
		private bool hasFinger;

		// Token: 0x04001338 RID: 4920
		[NonSerialized]
		private int lastFingerId;
	}
}
