using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x0200031F RID: 799
	[RequireComponent(typeof(Slider))]
	public class SliderManager : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		// Token: 0x060010B2 RID: 4274 RVA: 0x0005954C File Offset: 0x0005774C
		private void Start()
		{
			try
			{
				if (this.enableSaving)
				{
					if (!PlayerPrefs.HasKey(this.sliderTag + "MUIPSliderValue"))
					{
						this.saveValue = this.mainSlider.value;
					}
					else
					{
						this.saveValue = PlayerPrefs.GetFloat(this.sliderTag + "MUIPSliderValue");
					}
					this.mainSlider.value = this.saveValue;
					this.mainSlider.onValueChanged.AddListener(delegate(float <p0>)
					{
						this.saveValue = this.mainSlider.value;
						PlayerPrefs.SetFloat(this.sliderTag + "MUIPSliderValue", this.saveValue);
					});
				}
				this.mainSlider.onValueChanged.AddListener(delegate(float <p0>)
				{
					this.sliderEvent.Invoke(this.mainSlider.value);
					this.UpdateUI();
				});
				if (this.sliderAnimator == null)
				{
					this.sliderAnimator = base.gameObject.GetComponent<Animator>();
				}
			}
			catch
			{
			}
			this.UpdateUI();
		}

		// Token: 0x060010B3 RID: 4275 RVA: 0x0005962C File Offset: 0x0005782C
		public void UpdateUI()
		{
			if (this.useRoundValue)
			{
				if (this.usePercent)
				{
					if (this.valueText != null)
					{
						this.valueText.text = Mathf.Round(this.mainSlider.value * 1f).ToString() + "%";
					}
					if (this.popupValueText != null)
					{
						this.popupValueText.text = Mathf.Round(this.mainSlider.value * 1f).ToString() + "%";
						return;
					}
				}
				else
				{
					if (this.valueText != null)
					{
						this.valueText.text = Mathf.Round(this.mainSlider.value * 1f).ToString();
					}
					if (this.popupValueText != null)
					{
						this.popupValueText.text = Mathf.Round(this.mainSlider.value * 1f).ToString();
						return;
					}
				}
			}
			else if (this.usePercent)
			{
				if (this.valueText != null)
				{
					this.valueText.text = this.mainSlider.value.ToString("F1") + "%";
				}
				if (this.popupValueText != null)
				{
					this.popupValueText.text = this.mainSlider.value.ToString("F1") + "%";
					return;
				}
			}
			else
			{
				if (this.valueText != null)
				{
					this.valueText.text = this.mainSlider.value.ToString("F1");
				}
				if (this.popupValueText != null)
				{
					this.popupValueText.text = this.mainSlider.value.ToString("F1");
				}
			}
		}

		// Token: 0x060010B4 RID: 4276 RVA: 0x0005982B File Offset: 0x00057A2B
		public void OnPointerEnter(PointerEventData eventData)
		{
			if (this.showPopupValue)
			{
				this.sliderAnimator.Play("Value In");
			}
		}

		// Token: 0x060010B5 RID: 4277 RVA: 0x00059845 File Offset: 0x00057A45
		public void OnPointerExit(PointerEventData eventData)
		{
			if (this.showPopupValue)
			{
				this.sliderAnimator.Play("Value Out");
			}
		}

		// Token: 0x040015F1 RID: 5617
		public Slider mainSlider;

		// Token: 0x040015F2 RID: 5618
		public TextMeshProUGUI valueText;

		// Token: 0x040015F3 RID: 5619
		public TextMeshProUGUI popupValueText;

		// Token: 0x040015F4 RID: 5620
		public bool enableSaving;

		// Token: 0x040015F5 RID: 5621
		public string sliderTag = "My Slider";

		// Token: 0x040015F6 RID: 5622
		public bool usePercent;

		// Token: 0x040015F7 RID: 5623
		public bool showValue = true;

		// Token: 0x040015F8 RID: 5624
		public bool showPopupValue = true;

		// Token: 0x040015F9 RID: 5625
		public bool useRoundValue;

		// Token: 0x040015FA RID: 5626
		[SerializeField]
		public SliderManager.SliderEvent onValueChanged = new SliderManager.SliderEvent();

		// Token: 0x040015FB RID: 5627
		[Space(8f)]
		public SliderManager.SliderEvent sliderEvent;

		// Token: 0x040015FC RID: 5628
		[HideInInspector]
		public Animator sliderAnimator;

		// Token: 0x040015FD RID: 5629
		[HideInInspector]
		public float saveValue;

		// Token: 0x02000320 RID: 800
		[Serializable]
		public class SliderEvent : UnityEvent<float>
		{
		}
	}
}
