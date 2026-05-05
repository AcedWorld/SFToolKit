using System;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.Demos.GamepadTemplateUI
{
	// Token: 0x020002CA RID: 714
	[RequireComponent(typeof(Image))]
	public class ControllerUIEffect : MonoBehaviour
	{
		// Token: 0x06000F1A RID: 3866 RVA: 0x00050F11 File Offset: 0x0004F111
		private void Awake()
		{
			this._image = base.GetComponent<Image>();
			this._origColor = this._image.color;
			this._color = this._origColor;
		}

		// Token: 0x06000F1B RID: 3867 RVA: 0x00050F3C File Offset: 0x0004F13C
		public void Activate(float amount)
		{
			amount = Mathf.Clamp01(amount);
			if (this._isActive && amount == this._highlightAmount)
			{
				return;
			}
			this._highlightAmount = amount;
			this._color = Color.Lerp(this._origColor, this._highlightColor, this._highlightAmount);
			this._isActive = true;
			this.RedrawImage();
		}

		// Token: 0x06000F1C RID: 3868 RVA: 0x00050F94 File Offset: 0x0004F194
		public void Deactivate()
		{
			if (!this._isActive)
			{
				return;
			}
			this._color = this._origColor;
			this._highlightAmount = 0f;
			this._isActive = false;
			this.RedrawImage();
		}

		// Token: 0x06000F1D RID: 3869 RVA: 0x00050FC3 File Offset: 0x0004F1C3
		private void RedrawImage()
		{
			this._image.color = this._color;
			this._image.enabled = this._isActive;
		}

		// Token: 0x040013B7 RID: 5047
		[SerializeField]
		private Color _highlightColor = Color.white;

		// Token: 0x040013B8 RID: 5048
		private Image _image;

		// Token: 0x040013B9 RID: 5049
		private Color _color;

		// Token: 0x040013BA RID: 5050
		private Color _origColor;

		// Token: 0x040013BB RID: 5051
		private bool _isActive;

		// Token: 0x040013BC RID: 5052
		private float _highlightAmount;
	}
}
