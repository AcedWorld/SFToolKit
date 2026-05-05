using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200012A RID: 298
	public class Slider : BaseSlider<float>
	{
		// Token: 0x060009F5 RID: 2549 RVA: 0x00027D2B File Offset: 0x00025F2B
		public Slider() : this(null, 0f, 10f, SliderDirection.Horizontal, 0f)
		{
		}

		// Token: 0x060009F6 RID: 2550 RVA: 0x00027D46 File Offset: 0x00025F46
		public Slider(float start, float end, SliderDirection direction = SliderDirection.Horizontal, float pageSize = 0f) : this(null, start, end, direction, pageSize)
		{
		}

		// Token: 0x060009F7 RID: 2551 RVA: 0x00027D56 File Offset: 0x00025F56
		public Slider(string label, float start = 0f, float end = 10f, SliderDirection direction = SliderDirection.Horizontal, float pageSize = 0f) : base(label, start, end, direction, pageSize)
		{
			base.AddToClassList(Slider.ussClassName);
			base.labelElement.AddToClassList(Slider.labelUssClassName);
			base.visualInput.AddToClassList(Slider.inputUssClassName);
		}

		// Token: 0x060009F8 RID: 2552 RVA: 0x00027D98 File Offset: 0x00025F98
		public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, float startValue)
		{
			double num = NumericFieldDraggerUtility.CalculateFloatDragSensitivity((double)startValue, (double)base.lowValue, (double)base.highValue);
			float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
			double num2 = (double)this.value;
			num2 += (double)NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * num;
			this.value = (float)num2;
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x00027DF0 File Offset: 0x00025FF0
		internal override float SliderLerpUnclamped(float a, float b, float interpolant)
		{
			float num = Mathf.LerpUnclamped(a, b, interpolant);
			float num2 = Mathf.Abs((base.highValue - base.lowValue) / (base.dragContainer.resolvedStyle.width - base.dragElement.resolvedStyle.width));
			int digits = (num2 == 0f) ? Mathf.Clamp((int)(5.0 - (double)Mathf.Log10(Mathf.Abs(num2))), 0, 15) : Mathf.Clamp(-Mathf.FloorToInt(Mathf.Log10(Mathf.Abs(num2))), 0, 15);
			return (float)Math.Round((double)num, digits, MidpointRounding.AwayFromZero);
		}

		// Token: 0x060009FA RID: 2554 RVA: 0x00027E94 File Offset: 0x00026094
		internal override float SliderNormalizeValue(float currentValue, float lowerValue, float higherValue)
		{
			return (currentValue - lowerValue) / (higherValue - lowerValue);
		}

		// Token: 0x060009FB RID: 2555 RVA: 0x00027EB0 File Offset: 0x000260B0
		internal override float SliderRange()
		{
			return Math.Abs(base.highValue - base.lowValue);
		}

		// Token: 0x060009FC RID: 2556 RVA: 0x00027ED4 File Offset: 0x000260D4
		internal override float ParseStringToValue(string previousValue, string newValue)
		{
			float num;
			bool flag = UINumericFieldsUtils.TryConvertStringToFloat(newValue, previousValue, out num);
			float result;
			if (flag)
			{
				result = num;
			}
			else
			{
				result = 0f;
			}
			return result;
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x00027EFC File Offset: 0x000260FC
		internal override void ComputeValueFromKey(BaseSlider<float>.SliderKey sliderKey, bool isShift)
		{
			if (sliderKey != BaseSlider<float>.SliderKey.None)
			{
				if (sliderKey != BaseSlider<float>.SliderKey.Lowest)
				{
					if (sliderKey != BaseSlider<float>.SliderKey.Highest)
					{
						bool flag = sliderKey == BaseSlider<float>.SliderKey.LowerPage || sliderKey == BaseSlider<float>.SliderKey.HigherPage;
						float num = BaseSlider<float>.GetClosestPowerOfTen(Mathf.Abs((base.highValue - base.lowValue) * 0.01f));
						bool flag2 = flag;
						if (flag2)
						{
							num *= this.pageSize;
						}
						else if (isShift)
						{
							num *= 10f;
						}
						bool flag3 = sliderKey == BaseSlider<float>.SliderKey.Lower || sliderKey == BaseSlider<float>.SliderKey.LowerPage;
						if (flag3)
						{
							num = -num;
						}
						this.value = BaseSlider<float>.RoundToMultipleOf(this.value + num * 0.5001f, Mathf.Abs(num));
					}
					else
					{
						this.value = base.highValue;
					}
				}
				else
				{
					this.value = base.lowValue;
				}
			}
		}

		// Token: 0x040004C1 RID: 1217
		internal const float kDefaultHighValue = 10f;

		// Token: 0x040004C2 RID: 1218
		public new static readonly string ussClassName = "unity-slider";

		// Token: 0x040004C3 RID: 1219
		public new static readonly string labelUssClassName = Slider.ussClassName + "__label";

		// Token: 0x040004C4 RID: 1220
		public new static readonly string inputUssClassName = Slider.ussClassName + "__input";

		// Token: 0x0200012B RID: 299
		public new class UxmlFactory : UxmlFactory<Slider, Slider.UxmlTraits>
		{
		}

		// Token: 0x0200012C RID: 300
		public new class UxmlTraits : BaseSlider<float>.UxmlTraits
		{
			// Token: 0x06000A00 RID: 2560 RVA: 0x00028004 File Offset: 0x00026204
			public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
			{
				Slider slider = (Slider)ve;
				slider.lowValue = this.m_LowValue.GetValueFromBag(bag, cc);
				slider.highValue = this.m_HighValue.GetValueFromBag(bag, cc);
				slider.direction = this.m_Direction.GetValueFromBag(bag, cc);
				slider.pageSize = this.m_PageSize.GetValueFromBag(bag, cc);
				slider.showInputField = this.m_ShowInputField.GetValueFromBag(bag, cc);
				slider.inverted = this.m_Inverted.GetValueFromBag(bag, cc);
				base.Init(ve, bag, cc);
			}

			// Token: 0x040004C5 RID: 1221
			private UxmlFloatAttributeDescription m_LowValue = new UxmlFloatAttributeDescription
			{
				name = "low-value"
			};

			// Token: 0x040004C6 RID: 1222
			private UxmlFloatAttributeDescription m_HighValue = new UxmlFloatAttributeDescription
			{
				name = "high-value",
				defaultValue = 10f
			};

			// Token: 0x040004C7 RID: 1223
			private UxmlFloatAttributeDescription m_PageSize = new UxmlFloatAttributeDescription
			{
				name = "page-size",
				defaultValue = 0f
			};

			// Token: 0x040004C8 RID: 1224
			private UxmlBoolAttributeDescription m_ShowInputField = new UxmlBoolAttributeDescription
			{
				name = "show-input-field",
				defaultValue = false
			};

			// Token: 0x040004C9 RID: 1225
			private UxmlEnumAttributeDescription<SliderDirection> m_Direction = new UxmlEnumAttributeDescription<SliderDirection>
			{
				name = "direction",
				defaultValue = SliderDirection.Horizontal
			};

			// Token: 0x040004CA RID: 1226
			private UxmlBoolAttributeDescription m_Inverted = new UxmlBoolAttributeDescription
			{
				name = "inverted",
				defaultValue = false
			};
		}
	}
}
