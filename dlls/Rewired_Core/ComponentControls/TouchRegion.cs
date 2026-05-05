using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Rewired.ComponentControls
{
	// Token: 0x02000413 RID: 1043
	[DisallowMultipleComponent]
	[AddComponentMenu("Rewired/Touch Controls/Touch Region")]
	[Serializable]
	public sealed class TouchRegion : TouchInteractable
	{
		// Token: 0x170009E5 RID: 2533
		// (get) Token: 0x06002A09 RID: 10761 RVA: 0x00020382 File Offset: 0x0001E582
		// (set) Token: 0x06002A0A RID: 10762 RVA: 0x0009AA5C File Offset: 0x00098C5C
		public bool hideAtRuntime
		{
			get
			{
				return this._hideAtRuntime;
			}
			set
			{
				this._hideAtRuntime = value;
				if (value)
				{
					return;
				}
				this._hideAtRuntime = true;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x14000050 RID: 80
		// (add) Token: 0x06002A0B RID: 10763 RVA: 0x0002038A File Offset: 0x0001E58A
		// (remove) Token: 0x06002A0C RID: 10764 RVA: 0x00020398 File Offset: 0x0001E598
		public event UnityAction<PointerEventData> PointerDownEvent
		{
			add
			{
				this._onPointerDown.AddListener(value);
			}
			remove
			{
				this._onPointerDown.RemoveListener(value);
			}
		}

		// Token: 0x14000051 RID: 81
		// (add) Token: 0x06002A0D RID: 10765 RVA: 0x000203A6 File Offset: 0x0001E5A6
		// (remove) Token: 0x06002A0E RID: 10766 RVA: 0x000203B4 File Offset: 0x0001E5B4
		public event UnityAction<PointerEventData> PointerUpEvent
		{
			add
			{
				this._onPointerUp.AddListener(value);
			}
			remove
			{
				this._onPointerUp.RemoveListener(value);
			}
		}

		// Token: 0x14000052 RID: 82
		// (add) Token: 0x06002A0F RID: 10767 RVA: 0x000203C2 File Offset: 0x0001E5C2
		// (remove) Token: 0x06002A10 RID: 10768 RVA: 0x000203D0 File Offset: 0x0001E5D0
		public event UnityAction<PointerEventData> PointerEnterEvent
		{
			add
			{
				this._onPointerEnter.AddListener(value);
			}
			remove
			{
				this._onPointerEnter.RemoveListener(value);
			}
		}

		// Token: 0x14000053 RID: 83
		// (add) Token: 0x06002A11 RID: 10769 RVA: 0x000203DE File Offset: 0x0001E5DE
		// (remove) Token: 0x06002A12 RID: 10770 RVA: 0x000203EC File Offset: 0x0001E5EC
		public event UnityAction<PointerEventData> PointerExitEvent
		{
			add
			{
				this._onPointerExit.AddListener(value);
			}
			remove
			{
				this._onPointerExit.RemoveListener(value);
			}
		}

		// Token: 0x14000054 RID: 84
		// (add) Token: 0x06002A13 RID: 10771 RVA: 0x000203FA File Offset: 0x0001E5FA
		// (remove) Token: 0x06002A14 RID: 10772 RVA: 0x00020408 File Offset: 0x0001E608
		public event UnityAction<PointerEventData> BeginDragEvent
		{
			add
			{
				this._onBeginDrag.AddListener(value);
			}
			remove
			{
				this._onBeginDrag.RemoveListener(value);
			}
		}

		// Token: 0x14000055 RID: 85
		// (add) Token: 0x06002A15 RID: 10773 RVA: 0x00020416 File Offset: 0x0001E616
		// (remove) Token: 0x06002A16 RID: 10774 RVA: 0x00020424 File Offset: 0x0001E624
		public event UnityAction<PointerEventData> DragEvent
		{
			add
			{
				this._onDrag.AddListener(value);
			}
			remove
			{
				this._onDrag.RemoveListener(value);
			}
		}

		// Token: 0x14000056 RID: 86
		// (add) Token: 0x06002A17 RID: 10775 RVA: 0x00020432 File Offset: 0x0001E632
		// (remove) Token: 0x06002A18 RID: 10776 RVA: 0x00020440 File Offset: 0x0001E640
		public event UnityAction<PointerEventData> EndDragEvent
		{
			add
			{
				this._onEndDrag.AddListener(value);
			}
			remove
			{
				this._onEndDrag.RemoveListener(value);
			}
		}

		// Token: 0x06002A19 RID: 10777 RVA: 0x0009AA84 File Offset: 0x00098C84
		[CustomObfuscation(rename = false)]
		private TouchRegion()
		{
		}

		// Token: 0x06002A1A RID: 10778 RVA: 0x0002044E File Offset: 0x0001E64E
		[CustomObfuscation(rename = false)]
		internal override void Awake()
		{
			base.Awake();
			if (!Application.isPlaying)
			{
				return;
			}
			if (this._hideAtRuntime)
			{
				base.visible = false;
			}
		}

		// Token: 0x06002A1B RID: 10779 RVA: 0x00002FF9 File Offset: 0x000011F9
		public override void ClearValue()
		{
		}

		// Token: 0x06002A1C RID: 10780 RVA: 0x00002FF9 File Offset: 0x000011F9
		internal void NjXNjqRiKCtycKJXhGgxRMeOfctA()
		{
		}

		// Token: 0x06002A1D RID: 10781 RVA: 0x0009AAEC File Offset: 0x00098CEC
		internal void eNJCPlfvwLKZzmRxdnGzvbNkWHxPA(PointerEventData A_1)
		{
			base.OnPointerDown(A_1);
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!base.IUGIIGfBqvDUFgNIMGdfUHjibbKRA() || !base.IsInteractable())
			{
				return;
			}
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(A_1.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				return;
			}
			if (this._onPointerDown != null)
			{
				this._onPointerDown.Invoke(A_1);
			}
		}

		// Token: 0x06002A1E RID: 10782 RVA: 0x0009AB44 File Offset: 0x00098D44
		internal void ACqqwmOfqaapchpSIAkqwBXKBmzA(PointerEventData A_1)
		{
			base.OnPointerUp(A_1);
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!base.IUGIIGfBqvDUFgNIMGdfUHjibbKRA() || !base.IsInteractable())
			{
				return;
			}
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(A_1.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				return;
			}
			if (this._onPointerUp != null)
			{
				this._onPointerUp.Invoke(A_1);
			}
		}

		// Token: 0x06002A1F RID: 10783 RVA: 0x0009AB9C File Offset: 0x00098D9C
		internal void dUmTQKNeondEWNYZRsvpPGyRgzmC(PointerEventData A_1)
		{
			base.OnPointerEnter(A_1);
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!base.IUGIIGfBqvDUFgNIMGdfUHjibbKRA() || !base.IsInteractable())
			{
				return;
			}
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(A_1.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				return;
			}
			if (this._onPointerEnter != null)
			{
				this._onPointerEnter.Invoke(A_1);
			}
		}

		// Token: 0x06002A20 RID: 10784 RVA: 0x0009ABF4 File Offset: 0x00098DF4
		internal void NbCvtEOjSwgqKKSTiiPsWLAlwLXM(PointerEventData A_1)
		{
			base.OnPointerExit(A_1);
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!base.IUGIIGfBqvDUFgNIMGdfUHjibbKRA() || !base.IsInteractable())
			{
				return;
			}
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(A_1.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				return;
			}
			if (this._onPointerExit != null)
			{
				this._onPointerExit.Invoke(A_1);
			}
		}

		// Token: 0x06002A21 RID: 10785 RVA: 0x0009AC4C File Offset: 0x00098E4C
		internal void FigCjEAvxvnWpgjxbnIbKPeppmSBc(PointerEventData A_1)
		{
			base.OnBeginDrag(A_1);
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!base.IUGIIGfBqvDUFgNIMGdfUHjibbKRA() || !base.IsInteractable())
			{
				return;
			}
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(A_1.pointerId, base.allowedMouseButtons, EventTriggerType.BeginDrag))
			{
				return;
			}
			if (this._onBeginDrag != null)
			{
				this._onBeginDrag.Invoke(A_1);
			}
		}

		// Token: 0x06002A22 RID: 10786 RVA: 0x0009ACA4 File Offset: 0x00098EA4
		internal void rAtclvkGCHgWdNkHdKiJSvKHRktp(PointerEventData A_1)
		{
			base.OnDrag(A_1);
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!base.IUGIIGfBqvDUFgNIMGdfUHjibbKRA() || !base.IsInteractable())
			{
				return;
			}
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(A_1.pointerId, base.allowedMouseButtons, EventTriggerType.Drag))
			{
				return;
			}
			if (this._onDrag != null)
			{
				this._onDrag.Invoke(A_1);
			}
		}

		// Token: 0x06002A23 RID: 10787 RVA: 0x0009ACFC File Offset: 0x00098EFC
		internal void XjjEdKJWuTHuMlyPSTsDlkWKENmeb(PointerEventData A_1)
		{
			base.OnEndDrag(A_1);
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!base.IUGIIGfBqvDUFgNIMGdfUHjibbKRA() || !base.IsInteractable())
			{
				return;
			}
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(A_1.pointerId, base.allowedMouseButtons, EventTriggerType.EndDrag))
			{
				return;
			}
			if (this._onEndDrag != null)
			{
				this._onEndDrag.Invoke(A_1);
			}
		}

		// Token: 0x0400183F RID: 6207
		[Tooltip("If enabled, the Touch Region will be hidden when gameplay starts.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _hideAtRuntime = true;

		// Token: 0x04001840 RID: 6208
		private TouchRegion.MmNEJLqvEixLNOxHoehQYICcJkwo _onPointerDown = new TouchRegion.MmNEJLqvEixLNOxHoehQYICcJkwo();

		// Token: 0x04001841 RID: 6209
		private TouchRegion.TdScPfBRNCHOymgFmCUiFvLTUlMW _onPointerUp = new TouchRegion.TdScPfBRNCHOymgFmCUiFvLTUlMW();

		// Token: 0x04001842 RID: 6210
		private TouchRegion.akTgWoGfvfwZjglOZWDRSjtldEok _onPointerEnter = new TouchRegion.akTgWoGfvfwZjglOZWDRSjtldEok();

		// Token: 0x04001843 RID: 6211
		private TouchRegion.QipsDPdbaCvAffeaAFZOvCDjfnBo _onPointerExit = new TouchRegion.QipsDPdbaCvAffeaAFZOvCDjfnBo();

		// Token: 0x04001844 RID: 6212
		private TouchRegion.XDxHHDCbGPIevVnIeOjdrewecTbw _onBeginDrag = new TouchRegion.XDxHHDCbGPIevVnIeOjdrewecTbw();

		// Token: 0x04001845 RID: 6213
		private TouchRegion.prxdmBcQJthRvcVJHnNINoUobCEcA _onDrag = new TouchRegion.prxdmBcQJthRvcVJHnNINoUobCEcA();

		// Token: 0x04001846 RID: 6214
		private TouchRegion.ofTxAxUNkfjSViEeDoDPhxPWHxCMA _onEndDrag = new TouchRegion.ofTxAxUNkfjSViEeDoDPhxPWHxCMA();

		// Token: 0x02000414 RID: 1044
		[Serializable]
		private class MmNEJLqvEixLNOxHoehQYICcJkwo : UnityEvent<PointerEventData>
		{
		}

		// Token: 0x02000415 RID: 1045
		[Serializable]
		private class TdScPfBRNCHOymgFmCUiFvLTUlMW : UnityEvent<PointerEventData>
		{
		}

		// Token: 0x02000416 RID: 1046
		[Serializable]
		private class akTgWoGfvfwZjglOZWDRSjtldEok : UnityEvent<PointerEventData>
		{
		}

		// Token: 0x02000417 RID: 1047
		[Serializable]
		private class QipsDPdbaCvAffeaAFZOvCDjfnBo : UnityEvent<PointerEventData>
		{
		}

		// Token: 0x02000418 RID: 1048
		[Serializable]
		private class XDxHHDCbGPIevVnIeOjdrewecTbw : UnityEvent<PointerEventData>
		{
		}

		// Token: 0x02000419 RID: 1049
		[Serializable]
		private class prxdmBcQJthRvcVJHnNINoUobCEcA : UnityEvent<PointerEventData>
		{
		}

		// Token: 0x0200041A RID: 1050
		[Serializable]
		private class ofTxAxUNkfjSViEeDoDPhxPWHxCMA : UnityEvent<PointerEventData>
		{
		}
	}
}
