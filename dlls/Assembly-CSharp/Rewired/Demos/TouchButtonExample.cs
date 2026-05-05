using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Rewired.Demos
{
	// Token: 0x020002B1 RID: 689
	[AddComponentMenu("")]
	[RequireComponent(typeof(Image))]
	public class TouchButtonExample : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x170002FB RID: 763
		// (get) Token: 0x06000E82 RID: 3714 RVA: 0x0004E18A File Offset: 0x0004C38A
		// (set) Token: 0x06000E83 RID: 3715 RVA: 0x0004E192 File Offset: 0x0004C392
		public bool isPressed { get; private set; }

		// Token: 0x06000E84 RID: 3716 RVA: 0x0004E19B File Offset: 0x0004C39B
		private void Awake()
		{
			if (SystemInfo.deviceType == DeviceType.Handheld)
			{
				this.allowMouseControl = false;
			}
		}

		// Token: 0x06000E85 RID: 3717 RVA: 0x0004E1AC File Offset: 0x0004C3AC
		private void Restart()
		{
			this.isPressed = false;
		}

		// Token: 0x06000E86 RID: 3718 RVA: 0x0004E1B5 File Offset: 0x0004C3B5
		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
			if (!this.allowMouseControl && TouchButtonExample.IsMousePointerId(eventData.pointerId))
			{
				return;
			}
			this.isPressed = true;
		}

		// Token: 0x06000E87 RID: 3719 RVA: 0x0004E1D4 File Offset: 0x0004C3D4
		void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
		{
			if (!this.allowMouseControl && TouchButtonExample.IsMousePointerId(eventData.pointerId))
			{
				return;
			}
			this.isPressed = false;
		}

		// Token: 0x06000E88 RID: 3720 RVA: 0x0004E1F3 File Offset: 0x0004C3F3
		private static bool IsMousePointerId(int id)
		{
			return id == -1 || id == -2 || id == -3;
		}

		// Token: 0x0400132F RID: 4911
		public bool allowMouseControl = true;
	}
}
