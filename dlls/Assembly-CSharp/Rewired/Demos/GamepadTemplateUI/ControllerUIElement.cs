using System;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.Demos.GamepadTemplateUI
{
	// Token: 0x020002CB RID: 715
	[RequireComponent(typeof(Image))]
	public class ControllerUIElement : MonoBehaviour
	{
		// Token: 0x17000309 RID: 777
		// (get) Token: 0x06000F1F RID: 3871 RVA: 0x00050FFA File Offset: 0x0004F1FA
		private bool hasEffects
		{
			get
			{
				return this._positiveUIEffect != null || this._negativeUIEffect != null;
			}
		}

		// Token: 0x06000F20 RID: 3872 RVA: 0x00051018 File Offset: 0x0004F218
		private void Awake()
		{
			this._image = base.GetComponent<Image>();
			this._origColor = this._image.color;
			this._color = this._origColor;
			this.ClearLabels();
		}

		// Token: 0x06000F21 RID: 3873 RVA: 0x0005104C File Offset: 0x0004F24C
		public void Activate(float amount)
		{
			amount = Mathf.Clamp(amount, -1f, 1f);
			if (this.hasEffects)
			{
				if (amount < 0f && this._negativeUIEffect != null)
				{
					this._negativeUIEffect.Activate(Mathf.Abs(amount));
				}
				if (amount > 0f && this._positiveUIEffect != null)
				{
					this._positiveUIEffect.Activate(Mathf.Abs(amount));
				}
			}
			else
			{
				if (this._isActive && amount == this._highlightAmount)
				{
					return;
				}
				this._highlightAmount = amount;
				this._color = Color.Lerp(this._origColor, this._highlightColor, this._highlightAmount);
			}
			this._isActive = true;
			this.RedrawImage();
			if (this._childElements.Length != 0)
			{
				for (int i = 0; i < this._childElements.Length; i++)
				{
					if (!(this._childElements[i] == null))
					{
						this._childElements[i].Activate(amount);
					}
				}
			}
		}

		// Token: 0x06000F22 RID: 3874 RVA: 0x00051140 File Offset: 0x0004F340
		public void Deactivate()
		{
			if (!this._isActive)
			{
				return;
			}
			this._color = this._origColor;
			this._highlightAmount = 0f;
			if (this._positiveUIEffect != null)
			{
				this._positiveUIEffect.Deactivate();
			}
			if (this._negativeUIEffect != null)
			{
				this._negativeUIEffect.Deactivate();
			}
			this._isActive = false;
			this.RedrawImage();
			if (this._childElements.Length != 0)
			{
				for (int i = 0; i < this._childElements.Length; i++)
				{
					if (!(this._childElements[i] == null))
					{
						this._childElements[i].Deactivate();
					}
				}
			}
		}

		// Token: 0x06000F23 RID: 3875 RVA: 0x000511E8 File Offset: 0x0004F3E8
		public void SetLabel(string text, AxisRange labelType)
		{
			Text text2;
			switch (labelType)
			{
			case AxisRange.Full:
				text2 = this._label;
				break;
			case AxisRange.Positive:
				text2 = this._positiveLabel;
				break;
			case AxisRange.Negative:
				text2 = this._negativeLabel;
				break;
			default:
				text2 = null;
				break;
			}
			if (text2 != null)
			{
				text2.text = text;
			}
			if (this._childElements.Length != 0)
			{
				for (int i = 0; i < this._childElements.Length; i++)
				{
					if (!(this._childElements[i] == null))
					{
						this._childElements[i].SetLabel(text, labelType);
					}
				}
			}
		}

		// Token: 0x06000F24 RID: 3876 RVA: 0x00051274 File Offset: 0x0004F474
		public void ClearLabels()
		{
			if (this._label != null)
			{
				this._label.text = string.Empty;
			}
			if (this._positiveLabel != null)
			{
				this._positiveLabel.text = string.Empty;
			}
			if (this._negativeLabel != null)
			{
				this._negativeLabel.text = string.Empty;
			}
			if (this._childElements.Length != 0)
			{
				for (int i = 0; i < this._childElements.Length; i++)
				{
					if (!(this._childElements[i] == null))
					{
						this._childElements[i].ClearLabels();
					}
				}
			}
		}

		// Token: 0x06000F25 RID: 3877 RVA: 0x00051314 File Offset: 0x0004F514
		private void RedrawImage()
		{
			this._image.color = this._color;
		}

		// Token: 0x040013BD RID: 5053
		[SerializeField]
		private Color _highlightColor = Color.white;

		// Token: 0x040013BE RID: 5054
		[SerializeField]
		private ControllerUIEffect _positiveUIEffect;

		// Token: 0x040013BF RID: 5055
		[SerializeField]
		private ControllerUIEffect _negativeUIEffect;

		// Token: 0x040013C0 RID: 5056
		[SerializeField]
		private Text _label;

		// Token: 0x040013C1 RID: 5057
		[SerializeField]
		private Text _positiveLabel;

		// Token: 0x040013C2 RID: 5058
		[SerializeField]
		private Text _negativeLabel;

		// Token: 0x040013C3 RID: 5059
		[SerializeField]
		private ControllerUIElement[] _childElements = new ControllerUIElement[0];

		// Token: 0x040013C4 RID: 5060
		private Image _image;

		// Token: 0x040013C5 RID: 5061
		private Color _color;

		// Token: 0x040013C6 RID: 5062
		private Color _origColor;

		// Token: 0x040013C7 RID: 5063
		private bool _isActive;

		// Token: 0x040013C8 RID: 5064
		private float _highlightAmount;
	}
}
