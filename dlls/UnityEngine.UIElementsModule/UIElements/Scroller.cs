using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace UnityEngine.UIElements
{
	// Token: 0x0200011D RID: 285
	public class Scroller : VisualElement
	{
		// Token: 0x14000034 RID: 52
		// (add) Token: 0x06000978 RID: 2424 RVA: 0x000248E0 File Offset: 0x00022AE0
		// (remove) Token: 0x06000979 RID: 2425 RVA: 0x00024918 File Offset: 0x00022B18
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event Action<float> valueChanged;

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x0600097A RID: 2426 RVA: 0x0002494D File Offset: 0x00022B4D
		// (set) Token: 0x0600097B RID: 2427 RVA: 0x00024955 File Offset: 0x00022B55
		public Slider slider { get; private set; }

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x0600097C RID: 2428 RVA: 0x0002495E File Offset: 0x00022B5E
		// (set) Token: 0x0600097D RID: 2429 RVA: 0x00024966 File Offset: 0x00022B66
		public RepeatButton lowButton { get; private set; }

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x0600097E RID: 2430 RVA: 0x0002496F File Offset: 0x00022B6F
		// (set) Token: 0x0600097F RID: 2431 RVA: 0x00024977 File Offset: 0x00022B77
		public RepeatButton highButton { get; private set; }

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x06000980 RID: 2432 RVA: 0x00024980 File Offset: 0x00022B80
		// (set) Token: 0x06000981 RID: 2433 RVA: 0x0002499D File Offset: 0x00022B9D
		public float value
		{
			get
			{
				return this.slider.value;
			}
			set
			{
				this.slider.value = value;
			}
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x06000982 RID: 2434 RVA: 0x000249B0 File Offset: 0x00022BB0
		// (set) Token: 0x06000983 RID: 2435 RVA: 0x000249CD File Offset: 0x00022BCD
		public float lowValue
		{
			get
			{
				return this.slider.lowValue;
			}
			set
			{
				this.slider.lowValue = value;
			}
		}

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x06000984 RID: 2436 RVA: 0x000249E0 File Offset: 0x00022BE0
		// (set) Token: 0x06000985 RID: 2437 RVA: 0x000249FD File Offset: 0x00022BFD
		public float highValue
		{
			get
			{
				return this.slider.highValue;
			}
			set
			{
				this.slider.highValue = value;
			}
		}

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x06000986 RID: 2438 RVA: 0x00024A10 File Offset: 0x00022C10
		// (set) Token: 0x06000987 RID: 2439 RVA: 0x00024A34 File Offset: 0x00022C34
		public SliderDirection direction
		{
			get
			{
				return (base.resolvedStyle.flexDirection == FlexDirection.Row) ? SliderDirection.Horizontal : SliderDirection.Vertical;
			}
			set
			{
				this.slider.direction = value;
				this.slider.inverted = (value == SliderDirection.Vertical);
				bool flag = value == SliderDirection.Horizontal;
				if (flag)
				{
					base.style.flexDirection = FlexDirection.Row;
					base.AddToClassList(Scroller.horizontalVariantUssClassName);
					base.RemoveFromClassList(Scroller.verticalVariantUssClassName);
				}
				else
				{
					base.style.flexDirection = FlexDirection.Column;
					base.AddToClassList(Scroller.verticalVariantUssClassName);
					base.RemoveFromClassList(Scroller.horizontalVariantUssClassName);
				}
			}
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x00024AC1 File Offset: 0x00022CC1
		public Scroller() : this(0f, 0f, null, SliderDirection.Vertical)
		{
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x00024AD8 File Offset: 0x00022CD8
		public Scroller(float lowValue, float highValue, Action<float> valueChanged, SliderDirection direction = SliderDirection.Vertical)
		{
			base.AddToClassList(Scroller.ussClassName);
			this.slider = new Scroller.ScrollerSlider(lowValue, highValue, direction, 20f)
			{
				name = "unity-slider",
				viewDataKey = "Slider"
			};
			this.slider.AddToClassList(Scroller.sliderUssClassName);
			this.slider.RegisterValueChangedCallback(new EventCallback<ChangeEvent<float>>(this.OnSliderValueChange));
			this.lowButton = new RepeatButton(new Action(this.ScrollPageUp), 250L, 30L)
			{
				name = "unity-low-button"
			};
			this.lowButton.AddToClassList(Scroller.lowButtonUssClassName);
			base.Add(this.lowButton);
			this.highButton = new RepeatButton(new Action(this.ScrollPageDown), 250L, 30L)
			{
				name = "unity-high-button"
			};
			this.highButton.AddToClassList(Scroller.highButtonUssClassName);
			base.Add(this.highButton);
			base.Add(this.slider);
			this.direction = direction;
			this.valueChanged = valueChanged;
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x00024C02 File Offset: 0x00022E02
		public void Adjust(float factor)
		{
			base.SetEnabled(factor < 1f);
			this.slider.AdjustDragElement(factor);
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x00024C21 File Offset: 0x00022E21
		private void OnSliderValueChange(ChangeEvent<float> evt)
		{
			this.value = evt.newValue;
			Action<float> action = this.valueChanged;
			if (action != null)
			{
				action(this.slider.value);
			}
			base.IncrementVersion(VersionChangeType.Repaint);
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x00024C5A File Offset: 0x00022E5A
		public void ScrollPageUp()
		{
			this.ScrollPageUp(1f);
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x00024C69 File Offset: 0x00022E69
		public void ScrollPageDown()
		{
			this.ScrollPageDown(1f);
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x00024C78 File Offset: 0x00022E78
		public void ScrollPageUp(float factor)
		{
			this.value -= factor * (this.slider.pageSize * ((this.slider.lowValue < this.slider.highValue) ? 1f : -1f));
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x00024CC8 File Offset: 0x00022EC8
		public void ScrollPageDown(float factor)
		{
			this.value += factor * (this.slider.pageSize * ((this.slider.lowValue < this.slider.highValue) ? 1f : -1f));
		}

		// Token: 0x0400044C RID: 1100
		internal const float kDefaultPageSize = 20f;

		// Token: 0x0400044D RID: 1101
		public static readonly string ussClassName = "unity-scroller";

		// Token: 0x0400044E RID: 1102
		public static readonly string horizontalVariantUssClassName = Scroller.ussClassName + "--horizontal";

		// Token: 0x0400044F RID: 1103
		public static readonly string verticalVariantUssClassName = Scroller.ussClassName + "--vertical";

		// Token: 0x04000450 RID: 1104
		public static readonly string sliderUssClassName = Scroller.ussClassName + "__slider";

		// Token: 0x04000451 RID: 1105
		public static readonly string lowButtonUssClassName = Scroller.ussClassName + "__low-button";

		// Token: 0x04000452 RID: 1106
		public static readonly string highButtonUssClassName = Scroller.ussClassName + "__high-button";

		// Token: 0x0200011E RID: 286
		private class ScrollerSlider : Slider
		{
			// Token: 0x06000991 RID: 2449 RVA: 0x00024D93 File Offset: 0x00022F93
			public ScrollerSlider(float start, float end, SliderDirection direction, float pageSize) : base(start, end, direction, pageSize)
			{
			}

			// Token: 0x06000992 RID: 2450 RVA: 0x00024DA4 File Offset: 0x00022FA4
			internal override float SliderNormalizeValue(float currentValue, float lowerValue, float higherValue)
			{
				return Mathf.Clamp(base.SliderNormalizeValue(currentValue, lowerValue, higherValue), 0f, 1f);
			}
		}

		// Token: 0x0200011F RID: 287
		public new class UxmlFactory : UxmlFactory<Scroller, Scroller.UxmlTraits>
		{
		}

		// Token: 0x02000120 RID: 288
		public new class UxmlTraits : VisualElement.UxmlTraits
		{
			// Token: 0x170001C8 RID: 456
			// (get) Token: 0x06000994 RID: 2452 RVA: 0x00024DD8 File Offset: 0x00022FD8
			public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
			{
				get
				{
					yield break;
				}
			}

			// Token: 0x06000995 RID: 2453 RVA: 0x00024DF8 File Offset: 0x00022FF8
			public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
			{
				base.Init(ve, bag, cc);
				Scroller scroller = (Scroller)ve;
				scroller.slider.lowValue = this.m_LowValue.GetValueFromBag(bag, cc);
				scroller.slider.highValue = this.m_HighValue.GetValueFromBag(bag, cc);
				scroller.direction = this.m_Direction.GetValueFromBag(bag, cc);
				scroller.value = this.m_Value.GetValueFromBag(bag, cc);
			}

			// Token: 0x04000453 RID: 1107
			private UxmlFloatAttributeDescription m_LowValue = new UxmlFloatAttributeDescription
			{
				name = "low-value",
				obsoleteNames = new string[]
				{
					"lowValue"
				}
			};

			// Token: 0x04000454 RID: 1108
			private UxmlFloatAttributeDescription m_HighValue = new UxmlFloatAttributeDescription
			{
				name = "high-value",
				obsoleteNames = new string[]
				{
					"highValue"
				}
			};

			// Token: 0x04000455 RID: 1109
			private UxmlEnumAttributeDescription<SliderDirection> m_Direction = new UxmlEnumAttributeDescription<SliderDirection>
			{
				name = "direction",
				defaultValue = SliderDirection.Vertical
			};

			// Token: 0x04000456 RID: 1110
			private UxmlFloatAttributeDescription m_Value = new UxmlFloatAttributeDescription
			{
				name = "value"
			};
		}
	}
}
