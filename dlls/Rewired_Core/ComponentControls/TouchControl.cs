using System;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ComponentControls
{
	// Token: 0x020003EE RID: 1006
	[RequireComponent(typeof(RectTransform))]
	[DisallowMultipleComponent]
	[Serializable]
	public abstract class TouchControl : CustomControllerControl
	{
		// Token: 0x17000983 RID: 2435
		// (get) Token: 0x06002875 RID: 10357 RVA: 0x0001E8D3 File Offset: 0x0001CAD3
		internal TouchController hkMTiCBrvqenueclmmzSAhNXvEwA
		{
			get
			{
				return base.rzibFgeNisiPtdkXZKqxOinxAYdp() as TouchController;
			}
		}

		// Token: 0x17000984 RID: 2436
		// (get) Token: 0x06002876 RID: 10358 RVA: 0x0001E8E0 File Offset: 0x0001CAE0
		internal Canvas hlsJgfPNbiEXjyoptqyskoeItXRG
		{
			get
			{
				return this._canvas;
			}
		}

		// Token: 0x17000985 RID: 2437
		// (get) Token: 0x06002877 RID: 10359 RVA: 0x000975F8 File Offset: 0x000957F8
		internal RectTransform evSkNeHIwOzqBDBovKqKbEzIdiKl
		{
			get
			{
				Canvas canvas = this.hlsJgfPNbiEXjyoptqyskoeItXRG;
				if (canvas == null)
				{
					return null;
				}
				return canvas.transform as RectTransform;
			}
		}

		// Token: 0x17000986 RID: 2438
		// (get) Token: 0x06002878 RID: 10360 RVA: 0x00097624 File Offset: 0x00095824
		internal RectTransform ZlJFgENigMndbNzNAXlaJMlysRs
		{
			get
			{
				RectTransform result;
				if ((result = this.__rectTransform) == null)
				{
					result = (this.__rectTransform = base.GetComponent<RectTransform>());
				}
				return result;
			}
		}

		// Token: 0x06002879 RID: 10361 RVA: 0x0001E8E8 File Offset: 0x0001CAE8
		[CustomObfuscation(rename = false)]
		internal TouchControl()
		{
		}

		// Token: 0x0600287A RID: 10362 RVA: 0x0001E8F0 File Offset: 0x0001CAF0
		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this.dLEbdOGzBfTMeeOmnveJvBJxUDlJ(true, false);
		}

		// Token: 0x0600287B RID: 10363 RVA: 0x0001E90A File Offset: 0x0001CB0A
		[CustomObfuscation(rename = false)]
		internal override void OnCanvasGroupChanged()
		{
			base.OnCanvasGroupChanged();
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this.dLEbdOGzBfTMeeOmnveJvBJxUDlJ(false, true);
		}

		// Token: 0x0600287C RID: 10364 RVA: 0x0001E924 File Offset: 0x0001CB24
		[CustomObfuscation(rename = false)]
		internal override void OnTransformParentChanged()
		{
			base.OnTransformParentChanged();
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this.dLEbdOGzBfTMeeOmnveJvBJxUDlJ(false, true);
		}

		// Token: 0x17000987 RID: 2439
		// (get) Token: 0x0600287D RID: 10365 RVA: 0x0001E93E File Offset: 0x0001CB3E
		internal override bool sDyfdeIGxyTDdSPFEMsLcAADnlbVB
		{
			get
			{
				return base.rzibFgeNisiPtdkXZKqxOinxAYdp() as TouchController != null;
			}
		}

		// Token: 0x0600287E RID: 10366 RVA: 0x0001E951 File Offset: 0x0001CB51
		internal virtual bool ljoRLbCAHFdMhoOyLpdVnVLwwTMd()
		{
			return base.ffHwuTrmnsLzfzVoVLncxktdhwuQ() && this.dLEbdOGzBfTMeeOmnveJvBJxUDlJ(true, true);
		}

		// Token: 0x0600287F RID: 10367 RVA: 0x0001E96A File Offset: 0x0001CB6A
		internal virtual void vkHJpqpomSVbcZPCwGcxJvuATlcw()
		{
			base.FfCSAENAWeppOruWNCWYRiwVBqGj();
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this.dLEbdOGzBfTMeeOmnveJvBJxUDlJ(true, true);
		}

		// Token: 0x06002880 RID: 10368 RVA: 0x0001DCE5 File Offset: 0x0001BEE5
		[CustomObfuscation(rename = false)]
		internal override IComponentController FindController()
		{
			return UnityTools.GetComponentInSelfOrParents<CustomController>(base.transform);
		}

		// Token: 0x06002881 RID: 10369 RVA: 0x0001E984 File Offset: 0x0001CB84
		[CustomObfuscation(rename = false)]
		internal override Type GetRequiredControllerType()
		{
			return typeof(TouchController);
		}

		// Token: 0x06002882 RID: 10370 RVA: 0x0009764C File Offset: 0x0009584C
		private bool dLEbdOGzBfTMeeOmnveJvBJxUDlJ(bool A_1, bool A_2)
		{
			this._canvas = UnityTools.GetComponentInSelfOrParents<Canvas>(base.gameObject);
			if (this._canvas == null)
			{
				if (A_1)
				{
					Logger.LogError("No Canvas was found. Touch controls must be a child of a Canvas.");
				}
				return false;
			}
			if (this._canvas.renderMode == RenderMode.WorldSpace)
			{
				if (A_2)
				{
					Logger.LogError("Touch controls cannot be used with a world space Canvas. Change the canvas render mode to screen space.");
				}
				return false;
			}
			return true;
		}

		// Token: 0x04001760 RID: 5984
		private Canvas _canvas;

		// Token: 0x04001761 RID: 5985
		private RectTransform __rectTransform;
	}
}
