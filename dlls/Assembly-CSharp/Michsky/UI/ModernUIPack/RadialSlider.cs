using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x0200031A RID: 794
	public class RadialSlider : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
	{
		// Token: 0x1700032F RID: 815
		// (get) Token: 0x06001092 RID: 4242 RVA: 0x00058E97 File Offset: 0x00057097
		// (set) Token: 0x06001093 RID: 4243 RVA: 0x00058E9F File Offset: 0x0005709F
		public float SliderAngle
		{
			get
			{
				return this.currentAngle;
			}
			set
			{
				this.currentAngle = Mathf.Clamp(value, 0f, 360f);
			}
		}

		// Token: 0x17000330 RID: 816
		// (get) Token: 0x06001094 RID: 4244 RVA: 0x00058EB7 File Offset: 0x000570B7
		// (set) Token: 0x06001095 RID: 4245 RVA: 0x00058ECF File Offset: 0x000570CF
		public float SliderValue
		{
			get
			{
				return (float)((long)(this.SliderValueRaw * this.valueDisplayPrecision)) / this.valueDisplayPrecision;
			}
			set
			{
				this.SliderValueRaw = value;
			}
		}

		// Token: 0x17000331 RID: 817
		// (get) Token: 0x06001096 RID: 4246 RVA: 0x00058ED8 File Offset: 0x000570D8
		// (set) Token: 0x06001097 RID: 4247 RVA: 0x00058EED File Offset: 0x000570ED
		public float SliderValueRaw
		{
			get
			{
				return this.SliderAngle / 360f * this.maxValue;
			}
			set
			{
				this.SliderAngle = value * 360f / this.maxValue;
			}
		}

		// Token: 0x06001098 RID: 4248 RVA: 0x00058F03 File Offset: 0x00057103
		private void Awake()
		{
			this.graphicRaycaster = base.GetComponentInParent<GraphicRaycaster>();
			if (this.graphicRaycaster == null)
			{
				Debug.LogWarning("Could not find GraphicRaycaster component in parent of this GameObject: " + base.name, this);
				Object.Destroy(base.gameObject);
			}
		}

		// Token: 0x06001099 RID: 4249 RVA: 0x00058F40 File Offset: 0x00057140
		private void Start()
		{
			this.valueDisplayPrecision = Mathf.Pow(10f, (float)this.decimals);
			this.LoadState();
			this.SliderAngle = this.currentValue * 3.6f;
			this.UpdateUI();
		}

		// Token: 0x0600109A RID: 4250 RVA: 0x00058F78 File Offset: 0x00057178
		public void OnPointerDown(PointerEventData eventData)
		{
			this.hitRectTransform = eventData.pointerCurrentRaycast.gameObject.GetComponent<RectTransform>();
			this.isPointerDown = true;
			this.currentAngleOnPointerDown = this.SliderAngle;
			this.HandleSliderMouseInput(eventData, true);
		}

		// Token: 0x0600109B RID: 4251 RVA: 0x00058FB9 File Offset: 0x000571B9
		public void OnPointerUp(PointerEventData eventData)
		{
			if (this.HasValueChanged())
			{
				this.SaveState();
			}
			this.hitRectTransform = null;
			this.isPointerDown = false;
		}

		// Token: 0x0600109C RID: 4252 RVA: 0x00058FD7 File Offset: 0x000571D7
		public void OnDrag(PointerEventData eventData)
		{
			if (this.currentValue >= this.minValue)
			{
				this.HandleSliderMouseInput(eventData, false);
				return;
			}
			if (this.currentValue <= this.minValue)
			{
				this.SliderValueRaw = this.minValue;
			}
		}

		// Token: 0x0600109D RID: 4253 RVA: 0x0005900A File Offset: 0x0005720A
		public void OnPointerEnter(PointerEventData eventData)
		{
			this.onPointerEnter.Invoke();
		}

		// Token: 0x0600109E RID: 4254 RVA: 0x00059017 File Offset: 0x00057217
		public void OnPointerExit(PointerEventData eventData)
		{
			this.onPointerExit.Invoke();
		}

		// Token: 0x0600109F RID: 4255 RVA: 0x00059024 File Offset: 0x00057224
		public void LoadState()
		{
			if (!this.rememberValue)
			{
				return;
			}
			this.currentAngle = PlayerPrefs.GetFloat(this.sliderTag + "Radial");
		}

		// Token: 0x060010A0 RID: 4256 RVA: 0x0005904A File Offset: 0x0005724A
		public void SaveState()
		{
			if (!this.rememberValue)
			{
				return;
			}
			PlayerPrefs.SetFloat(this.sliderTag + "Radial", this.currentAngle);
		}

		// Token: 0x060010A1 RID: 4257 RVA: 0x00059070 File Offset: 0x00057270
		public void UpdateUI()
		{
			if (this.SliderValueRaw >= this.minValue)
			{
				float fillAmount = this.SliderAngle / 360f;
				this.indicatorPivot.transform.localEulerAngles = new Vector3(180f, 0f, this.SliderAngle);
				this.sliderImage.fillAmount = fillAmount;
				this.valueText.text = string.Format("{0}{1}", this.SliderValue, this.isPercent ? "%" : "");
				this.currentValue = this.SliderValue;
			}
		}

		// Token: 0x060010A2 RID: 4258 RVA: 0x00059109 File Offset: 0x00057309
		private bool HasValueChanged()
		{
			return this.SliderAngle != this.currentAngleOnPointerDown;
		}

		// Token: 0x060010A3 RID: 4259 RVA: 0x0005911C File Offset: 0x0005731C
		private void HandleSliderMouseInput(PointerEventData eventData, bool allowValueWrap)
		{
			if (!this.isPointerDown)
			{
				return;
			}
			Vector2 vector;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(this.hitRectTransform, eventData.position, eventData.pressEventCamera, out vector);
			float num = Mathf.Atan2(-vector.y, vector.x) * 57.29578f + 180f;
			if (!allowValueWrap)
			{
				float sliderAngle = this.SliderAngle;
				if (Mathf.Abs(num - sliderAngle) >= 180f)
				{
					num = ((sliderAngle < num) ? 0f : 360f);
				}
			}
			this.SliderAngle = num;
			this.UpdateUI();
			if (this.HasValueChanged())
			{
				this.onValueChanged.Invoke(this.SliderValueRaw);
			}
		}

		// Token: 0x040015CC RID: 5580
		private const string PREFS_UI_SAVE_NAME = "Radial";

		// Token: 0x040015CD RID: 5581
		public float currentValue = 50f;

		// Token: 0x040015CE RID: 5582
		public Image sliderImage;

		// Token: 0x040015CF RID: 5583
		public Transform indicatorPivot;

		// Token: 0x040015D0 RID: 5584
		public TextMeshProUGUI valueText;

		// Token: 0x040015D1 RID: 5585
		public float minValue;

		// Token: 0x040015D2 RID: 5586
		public float maxValue = 100f;

		// Token: 0x040015D3 RID: 5587
		[Range(0f, 8f)]
		public int decimals;

		// Token: 0x040015D4 RID: 5588
		public bool isPercent;

		// Token: 0x040015D5 RID: 5589
		public bool rememberValue;

		// Token: 0x040015D6 RID: 5590
		public string sliderTag;

		// Token: 0x040015D7 RID: 5591
		[SerializeField]
		private RadialSlider.SliderEvent onValueChanged = new RadialSlider.SliderEvent();

		// Token: 0x040015D8 RID: 5592
		public UnityEvent onPointerEnter;

		// Token: 0x040015D9 RID: 5593
		public UnityEvent onPointerExit;

		// Token: 0x040015DA RID: 5594
		private GraphicRaycaster graphicRaycaster;

		// Token: 0x040015DB RID: 5595
		private RectTransform hitRectTransform;

		// Token: 0x040015DC RID: 5596
		private bool isPointerDown;

		// Token: 0x040015DD RID: 5597
		private float currentAngle;

		// Token: 0x040015DE RID: 5598
		private float currentAngleOnPointerDown;

		// Token: 0x040015DF RID: 5599
		private float valueDisplayPrecision;

		// Token: 0x0200031B RID: 795
		[Serializable]
		public class SliderEvent : UnityEvent<float>
		{
		}
	}
}
