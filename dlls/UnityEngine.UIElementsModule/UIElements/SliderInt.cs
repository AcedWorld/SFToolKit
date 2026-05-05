using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200012D RID: 301
	public class SliderInt : BaseSlider<int>
	{
		// Token: 0x06000A02 RID: 2562 RVA: 0x0002816A File Offset: 0x0002636A
		public SliderInt() : this(null, 0, 10, SliderDirection.Horizontal, 0f)
		{
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x0002817E File Offset: 0x0002637E
		public SliderInt(int start, int end, SliderDirection direction = SliderDirection.Horizontal, float pageSize = 0f) : this(null, start, end, direction, pageSize)
		{
		}

		// Token: 0x06000A04 RID: 2564 RVA: 0x0002818E File Offset: 0x0002638E
		public SliderInt(string label, int start = 0, int end = 10, SliderDirection direction = SliderDirection.Horizontal, float pageSize = 0f) : base(label, start, end, direction, pageSize)
		{
			base.AddToClassList(SliderInt.ussClassName);
			base.labelElement.AddToClassList(SliderInt.labelUssClassName);
			base.visualInput.AddToClassList(SliderInt.inputUssClassName);
		}

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x06000A05 RID: 2565 RVA: 0x000281D0 File Offset: 0x000263D0
		// (set) Token: 0x06000A06 RID: 2566 RVA: 0x000281E8 File Offset: 0x000263E8
		public override float pageSize
		{
			get
			{
				return base.pageSize;
			}
			set
			{
				base.pageSize = (float)Mathf.RoundToInt(value);
			}
		}

		// Token: 0x06000A07 RID: 2567 RVA: 0x000281FC File Offset: 0x000263FC
		public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, int startValue)
		{
			double num = (double)NumericFieldDraggerUtility.CalculateIntDragSensitivity((long)startValue, (long)base.lowValue, (long)base.highValue);
			float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
			long num2 = (long)this.value;
			num2 += (long)Math.Round((double)NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * num);
			this.value = (int)num2;
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x00028258 File Offset: 0x00026458
		internal override int SliderLerpUnclamped(int a, int b, float interpolant)
		{
			return Mathf.RoundToInt(Mathf.LerpUnclamped((float)a, (float)b, interpolant));
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x0002827C File Offset: 0x0002647C
		internal override float SliderNormalizeValue(int currentValue, int lowerValue, int higherValue)
		{
			return ((float)currentValue - (float)lowerValue) / ((float)higherValue - (float)lowerValue);
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x0002829C File Offset: 0x0002649C
		internal override int SliderRange()
		{
			return Math.Abs(base.highValue - base.lowValue);
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x000282C0 File Offset: 0x000264C0
		internal override int ParseStringToValue(string previousValue, string newValue)
		{
			int num;
			bool flag = UINumericFieldsUtils.TryConvertStringToInt(newValue, previousValue, out num);
			int result;
			if (flag)
			{
				result = num;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x000282E4 File Offset: 0x000264E4
		internal override void ComputeValueAndDirectionFromClick(float sliderLength, float dragElementLength, float dragElementPos, float dragElementLastPos)
		{
			bool flag = Mathf.Approximately(this.pageSize, 0f);
			if (flag)
			{
				base.ComputeValueAndDirectionFromClick(sliderLength, dragElementLength, dragElementPos, dragElementLastPos);
			}
			else
			{
				float f = sliderLength - dragElementLength;
				bool flag2 = Mathf.Abs(f) < 1E-30f;
				if (!flag2)
				{
					int num = (int)this.pageSize;
					bool flag3 = (base.lowValue > base.highValue && !base.inverted) || (base.lowValue < base.highValue && base.inverted) || (base.direction == SliderDirection.Vertical && !base.inverted);
					if (flag3)
					{
						num = -num;
					}
					bool flag4 = dragElementLastPos < dragElementPos;
					bool flag5 = dragElementLastPos > dragElementPos + dragElementLength;
					bool flag6 = base.inverted ? flag5 : flag4;
					bool flag7 = base.inverted ? flag4 : flag5;
					bool flag8 = flag6 && base.clampedDragger.dragDirection != ClampedDragger<int>.DragDirection.LowToHigh;
					if (flag8)
					{
						base.clampedDragger.dragDirection = ClampedDragger<int>.DragDirection.HighToLow;
						this.value -= num;
					}
					else
					{
						bool flag9 = flag7 && base.clampedDragger.dragDirection != ClampedDragger<int>.DragDirection.HighToLow;
						if (flag9)
						{
							base.clampedDragger.dragDirection = ClampedDragger<int>.DragDirection.LowToHigh;
							this.value += num;
						}
					}
				}
			}
		}

		// Token: 0x06000A0D RID: 2573 RVA: 0x00028438 File Offset: 0x00026638
		internal override void ComputeValueFromKey(BaseSlider<int>.SliderKey sliderKey, bool isShift)
		{
			if (sliderKey != BaseSlider<int>.SliderKey.None)
			{
				if (sliderKey != BaseSlider<int>.SliderKey.Lowest)
				{
					if (sliderKey != BaseSlider<int>.SliderKey.Highest)
					{
						bool flag = sliderKey == BaseSlider<int>.SliderKey.LowerPage || sliderKey == BaseSlider<int>.SliderKey.HigherPage;
						float num = BaseSlider<int>.GetClosestPowerOfTen(Mathf.Abs((float)(base.highValue - base.lowValue) * 0.01f));
						bool flag2 = num < 1f;
						if (flag2)
						{
							num = 1f;
						}
						bool flag3 = flag;
						if (flag3)
						{
							num *= this.pageSize;
						}
						else if (isShift)
						{
							num *= 10f;
						}
						bool flag4 = sliderKey == BaseSlider<int>.SliderKey.Lower || sliderKey == BaseSlider<int>.SliderKey.LowerPage;
						if (flag4)
						{
							num = -num;
						}
						this.value = Mathf.RoundToInt(BaseSlider<int>.RoundToMultipleOf((float)this.value + num * 0.5001f, Mathf.Abs(num)));
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

		// Token: 0x040004CB RID: 1227
		internal const int kDefaultHighValue = 10;

		// Token: 0x040004CC RID: 1228
		public new static readonly string ussClassName = "unity-slider-int";

		// Token: 0x040004CD RID: 1229
		public new static readonly string labelUssClassName = SliderInt.ussClassName + "__label";

		// Token: 0x040004CE RID: 1230
		public new static readonly string inputUssClassName = SliderInt.ussClassName + "__input";

		// Token: 0x0200012E RID: 302
		public new class UxmlFactory : UxmlFactory<SliderInt, SliderInt.UxmlTraits>
		{
		}

		// Token: 0x0200012F RID: 303
		public new class UxmlTraits : BaseSlider<int>.UxmlTraits
		{
			// Token: 0x06000A10 RID: 2576 RVA: 0x0002855C File Offset: 0x0002675C
			public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
			{
				SliderInt sliderInt = (SliderInt)ve;
				sliderInt.lowValue = this.m_LowValue.GetValueFromBag(bag, cc);
				sliderInt.highValue = this.m_HighValue.GetValueFromBag(bag, cc);
				sliderInt.direction = this.m_Direction.GetValueFromBag(bag, cc);
				sliderInt.pageSize = (float)this.m_PageSize.GetValueFromBag(bag, cc);
				sliderInt.showInputField = this.m_ShowInputField.GetValueFromBag(bag, cc);
				sliderInt.inverted = this.m_Inverted.GetValueFromBag(bag, cc);
				base.Init(ve, bag, cc);
			}

			// Token: 0x040004CF RID: 1231
			private UxmlIntAttributeDescription m_LowValue = new UxmlIntAttributeDescription
			{
				name = "low-value"
			};

			// Token: 0x040004D0 RID: 1232
			private UxmlIntAttributeDescription m_HighValue = new UxmlIntAttributeDescription
			{
				name = "high-value",
				defaultValue = 10
			};

			// Token: 0x040004D1 RID: 1233
			private UxmlIntAttributeDescription m_PageSize = new UxmlIntAttributeDescription
			{
				name = "page-size",
				defaultValue = 0
			};

			// Token: 0x040004D2 RID: 1234
			private UxmlBoolAttributeDescription m_ShowInputField = new UxmlBoolAttributeDescription
			{
				name = "show-input-field",
				defaultValue = false
			};

			// Token: 0x040004D3 RID: 1235
			private UxmlEnumAttributeDescription<SliderDirection> m_Direction = new UxmlEnumAttributeDescription<SliderDirection>
			{
				name = "direction",
				defaultValue = SliderDirection.Horizontal
			};

			// Token: 0x040004D4 RID: 1236
			private UxmlBoolAttributeDescription m_Inverted = new UxmlBoolAttributeDescription
			{
				name = "inverted",
				defaultValue = false
			};
		}
	}
}
