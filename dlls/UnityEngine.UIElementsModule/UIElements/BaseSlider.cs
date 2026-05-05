using System;
using System.Collections.Generic;
using System.Globalization;

namespace UnityEngine.UIElements
{
	// Token: 0x02000062 RID: 98
	public abstract class BaseSlider<TValueType> : BaseField<TValueType>, IValueField<TValueType> where TValueType : IComparable<TValueType>
	{
		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000404 RID: 1028 RVA: 0x0000F996 File Offset: 0x0000DB96
		// (set) Token: 0x06000405 RID: 1029 RVA: 0x0000F99E File Offset: 0x0000DB9E
		internal VisualElement dragContainer { get; private set; }

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000406 RID: 1030 RVA: 0x0000F9A7 File Offset: 0x0000DBA7
		// (set) Token: 0x06000407 RID: 1031 RVA: 0x0000F9AF File Offset: 0x0000DBAF
		internal VisualElement dragElement { get; private set; }

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x06000408 RID: 1032 RVA: 0x0000F9B8 File Offset: 0x0000DBB8
		// (set) Token: 0x06000409 RID: 1033 RVA: 0x0000F9C0 File Offset: 0x0000DBC0
		internal VisualElement trackElement { get; private set; }

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x0600040A RID: 1034 RVA: 0x0000F9C9 File Offset: 0x0000DBC9
		// (set) Token: 0x0600040B RID: 1035 RVA: 0x0000F9D1 File Offset: 0x0000DBD1
		internal VisualElement dragBorderElement { get; private set; }

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x0600040C RID: 1036 RVA: 0x0000F9DA File Offset: 0x0000DBDA
		// (set) Token: 0x0600040D RID: 1037 RVA: 0x0000F9E2 File Offset: 0x0000DBE2
		internal TextField inputTextField { get; private set; }

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x0600040E RID: 1038 RVA: 0x0000F9EC File Offset: 0x0000DBEC
		// (set) Token: 0x0600040F RID: 1039 RVA: 0x0000FA04 File Offset: 0x0000DC04
		public TValueType lowValue
		{
			get
			{
				return this.m_LowValue;
			}
			set
			{
				bool flag = !EqualityComparer<TValueType>.Default.Equals(this.m_LowValue, value);
				if (flag)
				{
					this.m_LowValue = value;
					this.ClampValue();
					this.UpdateDragElementPosition();
					base.SaveViewData();
				}
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000410 RID: 1040 RVA: 0x0000FA48 File Offset: 0x0000DC48
		// (set) Token: 0x06000411 RID: 1041 RVA: 0x0000FA60 File Offset: 0x0000DC60
		public TValueType highValue
		{
			get
			{
				return this.m_HighValue;
			}
			set
			{
				bool flag = !EqualityComparer<TValueType>.Default.Equals(this.m_HighValue, value);
				if (flag)
				{
					this.m_HighValue = value;
					this.ClampValue();
					this.UpdateDragElementPosition();
					base.SaveViewData();
				}
			}
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x0000FAA4 File Offset: 0x0000DCA4
		internal void SetHighValueWithoutNotify(TValueType newHighValue)
		{
			this.m_HighValue = newHighValue;
			TValueType valueWithoutNotify = this.clamped ? this.GetClampedValue(this.value) : this.value;
			this.SetValueWithoutNotify(valueWithoutNotify);
			this.UpdateDragElementPosition();
			base.SaveViewData();
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000413 RID: 1043 RVA: 0x0000FAEC File Offset: 0x0000DCEC
		public TValueType range
		{
			get
			{
				return this.SliderRange();
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000414 RID: 1044 RVA: 0x0000FB04 File Offset: 0x0000DD04
		// (set) Token: 0x06000415 RID: 1045 RVA: 0x0000FB1C File Offset: 0x0000DD1C
		public virtual float pageSize
		{
			get
			{
				return this.m_PageSize;
			}
			set
			{
				this.m_PageSize = value;
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000416 RID: 1046 RVA: 0x0000FB28 File Offset: 0x0000DD28
		// (set) Token: 0x06000417 RID: 1047 RVA: 0x0000FB40 File Offset: 0x0000DD40
		public virtual bool showInputField
		{
			get
			{
				return this.m_ShowInputField;
			}
			set
			{
				bool flag = this.m_ShowInputField != value;
				if (flag)
				{
					this.m_ShowInputField = value;
					this.UpdateTextFieldVisibility();
				}
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000418 RID: 1048 RVA: 0x0000FB6E File Offset: 0x0000DD6E
		// (set) Token: 0x06000419 RID: 1049 RVA: 0x0000FB76 File Offset: 0x0000DD76
		internal bool clamped { get; set; } = true;

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x0600041A RID: 1050 RVA: 0x0000FB7F File Offset: 0x0000DD7F
		// (set) Token: 0x0600041B RID: 1051 RVA: 0x0000FB87 File Offset: 0x0000DD87
		internal ClampedDragger<TValueType> clampedDragger { get; private set; }

		// Token: 0x0600041C RID: 1052 RVA: 0x0000FB90 File Offset: 0x0000DD90
		private TValueType Clamp(TValueType value, TValueType lowBound, TValueType highBound)
		{
			TValueType result = value;
			bool flag = lowBound.CompareTo(value) > 0;
			if (flag)
			{
				result = lowBound;
			}
			else
			{
				bool flag2 = highBound.CompareTo(value) < 0;
				if (flag2)
				{
					result = highBound;
				}
			}
			return result;
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x0000FBDC File Offset: 0x0000DDDC
		private TValueType GetClampedValue(TValueType newValue)
		{
			TValueType tvalueType = this.lowValue;
			TValueType tvalueType2 = this.highValue;
			bool flag = tvalueType.CompareTo(tvalueType2) > 0;
			if (flag)
			{
				TValueType tvalueType3 = tvalueType;
				tvalueType = tvalueType2;
				tvalueType2 = tvalueType3;
			}
			return this.Clamp(newValue, tvalueType, tvalueType2);
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x0600041E RID: 1054 RVA: 0x0000FC24 File Offset: 0x0000DE24
		// (set) Token: 0x0600041F RID: 1055 RVA: 0x0000FC3C File Offset: 0x0000DE3C
		public override TValueType value
		{
			get
			{
				return base.value;
			}
			set
			{
				TValueType value2 = this.clamped ? this.GetClampedValue(value) : value;
				base.value = value2;
			}
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x00003CD2 File Offset: 0x00001ED2
		public virtual void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, TValueType startValue)
		{
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x00003CD2 File Offset: 0x00001ED2
		void IValueField<!0>.StartDragging()
		{
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x00003CD2 File Offset: 0x00001ED2
		void IValueField<!0>.StopDragging()
		{
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x0000FC68 File Offset: 0x0000DE68
		public override void SetValueWithoutNotify(TValueType newValue)
		{
			TValueType valueWithoutNotify = this.clamped ? this.GetClampedValue(newValue) : newValue;
			base.SetValueWithoutNotify(valueWithoutNotify);
			this.UpdateDragElementPosition();
			this.UpdateTextFieldValue();
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000424 RID: 1060 RVA: 0x0000FCA0 File Offset: 0x0000DEA0
		// (set) Token: 0x06000425 RID: 1061 RVA: 0x0000FCB8 File Offset: 0x0000DEB8
		public SliderDirection direction
		{
			get
			{
				return this.m_Direction;
			}
			set
			{
				this.m_Direction = value;
				bool flag = this.m_Direction == SliderDirection.Horizontal;
				if (flag)
				{
					base.RemoveFromClassList(BaseSlider<TValueType>.verticalVariantUssClassName);
					base.AddToClassList(BaseSlider<TValueType>.horizontalVariantUssClassName);
				}
				else
				{
					base.RemoveFromClassList(BaseSlider<TValueType>.horizontalVariantUssClassName);
					base.AddToClassList(BaseSlider<TValueType>.verticalVariantUssClassName);
				}
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000426 RID: 1062 RVA: 0x0000FD10 File Offset: 0x0000DF10
		// (set) Token: 0x06000427 RID: 1063 RVA: 0x0000FD28 File Offset: 0x0000DF28
		public bool inverted
		{
			get
			{
				return this.m_Inverted;
			}
			set
			{
				bool flag = this.m_Inverted != value;
				if (flag)
				{
					this.m_Inverted = value;
					this.UpdateDragElementPosition();
				}
			}
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x0000FD58 File Offset: 0x0000DF58
		internal BaseSlider(string label, TValueType start, TValueType end, SliderDirection direction = SliderDirection.Horizontal, float pageSize = 0f) : base(label, null)
		{
			base.AddToClassList(BaseSlider<TValueType>.ussClassName);
			base.labelElement.AddToClassList(BaseSlider<TValueType>.labelUssClassName);
			base.visualInput.AddToClassList(BaseSlider<TValueType>.inputUssClassName);
			this.direction = direction;
			this.pageSize = pageSize;
			this.lowValue = start;
			this.highValue = end;
			base.pickingMode = PickingMode.Ignore;
			this.dragContainer = new VisualElement
			{
				name = "unity-drag-container"
			};
			this.dragContainer.AddToClassList(BaseSlider<TValueType>.dragContainerUssClassName);
			this.dragContainer.RegisterCallback<GeometryChangedEvent>(new EventCallback<GeometryChangedEvent>(this.UpdateDragElementPosition), TrickleDown.NoTrickleDown);
			base.visualInput.Add(this.dragContainer);
			this.trackElement = new VisualElement
			{
				name = "unity-tracker",
				usageHints = UsageHints.DynamicColor
			};
			this.trackElement.AddToClassList(BaseSlider<TValueType>.trackerUssClassName);
			this.dragContainer.Add(this.trackElement);
			this.dragBorderElement = new VisualElement
			{
				name = "unity-dragger-border"
			};
			this.dragBorderElement.AddToClassList(BaseSlider<TValueType>.draggerBorderUssClassName);
			this.dragContainer.Add(this.dragBorderElement);
			this.dragElement = new VisualElement
			{
				name = "unity-dragger",
				usageHints = UsageHints.DynamicTransform
			};
			this.dragElement.RegisterCallback<GeometryChangedEvent>(new EventCallback<GeometryChangedEvent>(this.UpdateDragElementPosition), TrickleDown.NoTrickleDown);
			this.dragElement.AddToClassList(BaseSlider<TValueType>.draggerUssClassName);
			this.dragContainer.Add(this.dragElement);
			this.clampedDragger = new ClampedDragger<TValueType>(this, new Action(this.SetSliderValueFromClick), new Action(this.SetSliderValueFromDrag));
			this.dragContainer.pickingMode = PickingMode.Position;
			this.dragContainer.AddManipulator(this.clampedDragger);
			base.RegisterCallback<KeyDownEvent>(new EventCallback<KeyDownEvent>(this.OnKeyDown), TrickleDown.NoTrickleDown);
			base.RegisterCallback<NavigationMoveEvent>(new EventCallback<NavigationMoveEvent>(this.OnNavigationMove), TrickleDown.NoTrickleDown);
			this.UpdateTextFieldVisibility();
			FieldMouseDragger<TValueType> fieldMouseDragger = new FieldMouseDragger<TValueType>(this);
			fieldMouseDragger.SetDragZone(base.labelElement);
			base.labelElement.AddToClassList(BaseField<TValueType>.labelDraggerVariantUssClassName);
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x0000FFA4 File Offset: 0x0000E1A4
		protected static float GetClosestPowerOfTen(float positiveNumber)
		{
			bool flag = positiveNumber <= 0f;
			float result;
			if (flag)
			{
				result = 1f;
			}
			else
			{
				result = Mathf.Pow(10f, (float)Mathf.RoundToInt(Mathf.Log10(positiveNumber)));
			}
			return result;
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x0000FFE4 File Offset: 0x0000E1E4
		protected static float RoundToMultipleOf(float value, float roundingValue)
		{
			bool flag = roundingValue == 0f;
			float result;
			if (flag)
			{
				result = value;
			}
			else
			{
				result = Mathf.Round(value / roundingValue) * roundingValue;
			}
			return result;
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x00010010 File Offset: 0x0000E210
		private void ClampValue()
		{
			this.value = base.rawValue;
		}

		// Token: 0x0600042C RID: 1068
		internal abstract TValueType SliderLerpUnclamped(TValueType a, TValueType b, float interpolant);

		// Token: 0x0600042D RID: 1069
		internal abstract float SliderNormalizeValue(TValueType currentValue, TValueType lowerValue, TValueType higherValue);

		// Token: 0x0600042E RID: 1070
		internal abstract TValueType SliderRange();

		// Token: 0x0600042F RID: 1071
		internal abstract TValueType ParseStringToValue(string previousValue, string newValue);

		// Token: 0x06000430 RID: 1072
		internal abstract void ComputeValueFromKey(BaseSlider<TValueType>.SliderKey sliderKey, bool isShift);

		// Token: 0x06000431 RID: 1073 RVA: 0x00010020 File Offset: 0x0000E220
		private TValueType SliderLerpDirectionalUnclamped(TValueType a, TValueType b, float positionInterpolant)
		{
			float interpolant = (this.direction == SliderDirection.Vertical) ? (1f - positionInterpolant) : positionInterpolant;
			bool inverted = this.inverted;
			TValueType result;
			if (inverted)
			{
				result = this.SliderLerpUnclamped(b, a, interpolant);
			}
			else
			{
				result = this.SliderLerpUnclamped(a, b, interpolant);
			}
			return result;
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x00010068 File Offset: 0x0000E268
		private void SetSliderValueFromDrag()
		{
			bool flag = this.clampedDragger.dragDirection != ClampedDragger<TValueType>.DragDirection.Free;
			if (!flag)
			{
				Vector2 delta = this.clampedDragger.delta;
				bool flag2 = this.direction == SliderDirection.Horizontal;
				if (flag2)
				{
					this.ComputeValueAndDirectionFromDrag(this.dragContainer.resolvedStyle.width, this.dragElement.resolvedStyle.width, this.m_DragElementStartPos.x + delta.x);
				}
				else
				{
					this.ComputeValueAndDirectionFromDrag(this.dragContainer.resolvedStyle.height, this.dragElement.resolvedStyle.height, this.m_DragElementStartPos.y + delta.y);
				}
			}
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x00010120 File Offset: 0x0000E320
		private void ComputeValueAndDirectionFromDrag(float sliderLength, float dragElementLength, float dragElementPos)
		{
			float num = sliderLength - dragElementLength;
			bool flag = Mathf.Abs(num) < 1E-30f;
			if (!flag)
			{
				bool clamped = this.clamped;
				float positionInterpolant;
				if (clamped)
				{
					positionInterpolant = Mathf.Max(0f, Mathf.Min(dragElementPos, num)) / num;
				}
				else
				{
					positionInterpolant = dragElementPos / num;
				}
				this.value = this.SliderLerpDirectionalUnclamped(this.lowValue, this.highValue, positionInterpolant);
			}
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x00010184 File Offset: 0x0000E384
		private void SetSliderValueFromClick()
		{
			bool flag = this.clampedDragger.dragDirection == ClampedDragger<TValueType>.DragDirection.Free;
			if (!flag)
			{
				bool flag2 = this.clampedDragger.dragDirection == ClampedDragger<TValueType>.DragDirection.None;
				if (flag2)
				{
					bool flag3 = Mathf.Approximately(this.pageSize, 0f);
					if (flag3)
					{
						bool flag4 = this.direction == SliderDirection.Horizontal;
						float num;
						float num2;
						float num3;
						float num4;
						float dragElementPos;
						if (flag4)
						{
							num = this.dragContainer.resolvedStyle.width;
							num2 = this.dragElement.resolvedStyle.width;
							float b = num - num2;
							float a = this.clampedDragger.startMousePosition.x - num2 / 2f;
							num3 = Mathf.Max(0f, Mathf.Min(a, b));
							num4 = this.dragElement.transform.position.y;
							dragElementPos = num3;
						}
						else
						{
							num = this.dragContainer.resolvedStyle.height;
							num2 = this.dragElement.resolvedStyle.height;
							float b2 = num - num2;
							float a2 = this.clampedDragger.startMousePosition.y - num2 / 2f;
							num3 = this.dragElement.transform.position.x;
							num4 = Mathf.Max(0f, Mathf.Min(a2, b2));
							dragElementPos = num4;
						}
						Vector3 position = new Vector3(num3, num4, 0f);
						this.dragElement.transform.position = position;
						this.dragBorderElement.transform.position = position;
						this.m_DragElementStartPos = new Rect(num3, num4, this.dragElement.resolvedStyle.width, this.dragElement.resolvedStyle.height);
						this.clampedDragger.dragDirection = ClampedDragger<TValueType>.DragDirection.Free;
						this.ComputeValueAndDirectionFromDrag(num, num2, dragElementPos);
						return;
					}
					this.m_DragElementStartPos = new Rect(this.dragElement.transform.position.x, this.dragElement.transform.position.y, this.dragElement.resolvedStyle.width, this.dragElement.resolvedStyle.height);
				}
				bool flag5 = this.direction == SliderDirection.Horizontal;
				if (flag5)
				{
					this.ComputeValueAndDirectionFromClick(this.dragContainer.resolvedStyle.width, this.dragElement.resolvedStyle.width, this.dragElement.transform.position.x, this.clampedDragger.lastMousePosition.x);
				}
				else
				{
					this.ComputeValueAndDirectionFromClick(this.dragContainer.resolvedStyle.height, this.dragElement.resolvedStyle.height, this.dragElement.transform.position.y, this.clampedDragger.lastMousePosition.y);
				}
			}
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x00010458 File Offset: 0x0000E658
		private void OnKeyDown(KeyDownEvent evt)
		{
			BaseSlider<TValueType>.SliderKey sliderKey = BaseSlider<TValueType>.SliderKey.None;
			bool flag = this.direction == SliderDirection.Horizontal;
			bool flag2 = (flag && evt.keyCode == KeyCode.Home) || (!flag && evt.keyCode == KeyCode.End);
			if (flag2)
			{
				sliderKey = (this.inverted ? BaseSlider<TValueType>.SliderKey.Highest : BaseSlider<TValueType>.SliderKey.Lowest);
			}
			else
			{
				bool flag3 = (flag && evt.keyCode == KeyCode.End) || (!flag && evt.keyCode == KeyCode.Home);
				if (flag3)
				{
					sliderKey = (this.inverted ? BaseSlider<TValueType>.SliderKey.Lowest : BaseSlider<TValueType>.SliderKey.Highest);
				}
				else
				{
					bool flag4 = (flag && evt.keyCode == KeyCode.PageUp) || (!flag && evt.keyCode == KeyCode.PageDown);
					if (flag4)
					{
						sliderKey = (this.inverted ? BaseSlider<TValueType>.SliderKey.HigherPage : BaseSlider<TValueType>.SliderKey.LowerPage);
					}
					else
					{
						bool flag5 = (flag && evt.keyCode == KeyCode.PageDown) || (!flag && evt.keyCode == KeyCode.PageUp);
						if (flag5)
						{
							sliderKey = (this.inverted ? BaseSlider<TValueType>.SliderKey.LowerPage : BaseSlider<TValueType>.SliderKey.HigherPage);
						}
					}
				}
			}
			bool flag6 = sliderKey == BaseSlider<TValueType>.SliderKey.None;
			if (!flag6)
			{
				this.ComputeValueFromKey(sliderKey, evt.shiftKey);
				evt.StopPropagation();
			}
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x0001057C File Offset: 0x0000E77C
		private void OnNavigationMove(NavigationMoveEvent evt)
		{
			BaseSlider<TValueType>.SliderKey sliderKey = BaseSlider<TValueType>.SliderKey.None;
			bool flag = this.direction == SliderDirection.Horizontal;
			bool flag2 = evt.direction == (flag ? NavigationMoveEvent.Direction.Left : NavigationMoveEvent.Direction.Down);
			if (flag2)
			{
				sliderKey = (this.inverted ? BaseSlider<TValueType>.SliderKey.Higher : BaseSlider<TValueType>.SliderKey.Lower);
			}
			else
			{
				bool flag3 = evt.direction == (flag ? NavigationMoveEvent.Direction.Right : NavigationMoveEvent.Direction.Up);
				if (flag3)
				{
					sliderKey = (this.inverted ? BaseSlider<TValueType>.SliderKey.Lower : BaseSlider<TValueType>.SliderKey.Higher);
				}
			}
			bool flag4 = sliderKey == BaseSlider<TValueType>.SliderKey.None;
			if (!flag4)
			{
				this.ComputeValueFromKey(sliderKey, evt.shiftKey);
				evt.StopPropagation();
				evt.PreventDefault();
			}
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x00010600 File Offset: 0x0000E800
		internal virtual void ComputeValueAndDirectionFromClick(float sliderLength, float dragElementLength, float dragElementPos, float dragElementLastPos)
		{
			float num = sliderLength - dragElementLength;
			bool flag = Mathf.Abs(num) < 1E-30f;
			if (!flag)
			{
				bool flag2 = dragElementLastPos < dragElementPos;
				bool flag3 = dragElementLastPos > dragElementPos + dragElementLength;
				bool flag4 = this.inverted ? flag3 : flag2;
				bool flag5 = this.inverted ? flag2 : flag3;
				float num2 = this.inverted ? (-this.pageSize) : this.pageSize;
				bool flag6 = flag4 && this.clampedDragger.dragDirection != ClampedDragger<TValueType>.DragDirection.LowToHigh;
				if (flag6)
				{
					this.clampedDragger.dragDirection = ClampedDragger<TValueType>.DragDirection.HighToLow;
					float positionInterpolant = Mathf.Max(0f, Mathf.Min(dragElementPos - num2, num)) / num;
					this.value = this.SliderLerpDirectionalUnclamped(this.lowValue, this.highValue, positionInterpolant);
				}
				else
				{
					bool flag7 = flag5 && this.clampedDragger.dragDirection != ClampedDragger<TValueType>.DragDirection.HighToLow;
					if (flag7)
					{
						this.clampedDragger.dragDirection = ClampedDragger<TValueType>.DragDirection.LowToHigh;
						float positionInterpolant2 = Mathf.Max(0f, Mathf.Min(dragElementPos + num2, num)) / num;
						this.value = this.SliderLerpDirectionalUnclamped(this.lowValue, this.highValue, positionInterpolant2);
					}
				}
			}
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x00010730 File Offset: 0x0000E930
		public void AdjustDragElement(float factor)
		{
			bool flag = factor < 1f;
			this.dragElement.visible = flag;
			bool flag2 = flag;
			if (flag2)
			{
				IStyle style = this.dragElement.style;
				this.dragElement.style.visibility = StyleKeyword.Null;
				bool flag3 = this.direction == SliderDirection.Horizontal;
				if (flag3)
				{
					float b = (base.resolvedStyle.minWidth == StyleKeyword.Auto) ? 0f : base.resolvedStyle.minWidth.value;
					style.width = Mathf.Round(Mathf.Max(this.dragContainer.layout.width * factor, b));
				}
				else
				{
					float b2 = (base.resolvedStyle.minHeight == StyleKeyword.Auto) ? 0f : base.resolvedStyle.minHeight.value;
					style.height = Mathf.Round(Mathf.Max(this.dragContainer.layout.height * factor, b2));
				}
			}
			this.dragBorderElement.visible = this.dragElement.visible;
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x00010874 File Offset: 0x0000EA74
		private void UpdateDragElementPosition(GeometryChangedEvent evt)
		{
			bool flag = evt.oldRect.size == evt.newRect.size;
			if (!flag)
			{
				this.UpdateDragElementPosition();
			}
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x000108B1 File Offset: 0x0000EAB1
		internal override void OnViewDataReady()
		{
			base.OnViewDataReady();
			this.UpdateDragElementPosition();
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x000108C4 File Offset: 0x0000EAC4
		private bool SameValues(float a, float b, float epsilon)
		{
			return Mathf.Abs(b - a) < epsilon;
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x000108E4 File Offset: 0x0000EAE4
		private void UpdateDragElementPosition()
		{
			bool flag = base.panel == null;
			if (!flag)
			{
				float num = this.SliderNormalizeValue(this.value, this.lowValue, this.highValue);
				float num2 = this.inverted ? (1f - num) : num;
				float epsilon = base.scaledPixelsPerPoint * 0.5f;
				bool flag2 = this.direction == SliderDirection.Horizontal;
				if (flag2)
				{
					float width = this.dragElement.resolvedStyle.width;
					float num3 = -this.dragElement.resolvedStyle.marginLeft - this.dragElement.resolvedStyle.marginRight;
					float num4 = this.dragContainer.layout.width - width + num3;
					float num5 = num2 * num4;
					bool flag3 = float.IsNaN(num5);
					if (!flag3)
					{
						float x = this.dragElement.transform.position.x;
						bool flag4 = !this.SameValues(x, num5, epsilon);
						if (flag4)
						{
							Vector3 position = new Vector3(num5, 0f, 0f);
							this.dragElement.transform.position = position;
							this.dragBorderElement.transform.position = position;
						}
					}
				}
				else
				{
					float height = this.dragElement.resolvedStyle.height;
					float num6 = this.dragContainer.resolvedStyle.height - height;
					float num7 = (1f - num2) * num6;
					bool flag5 = float.IsNaN(num7);
					if (!flag5)
					{
						float y = this.dragElement.transform.position.y;
						bool flag6 = !this.SameValues(y, num7, epsilon);
						if (flag6)
						{
							Vector3 position2 = new Vector3(0f, num7, 0f);
							this.dragElement.transform.position = position2;
							this.dragBorderElement.transform.position = position2;
						}
					}
				}
			}
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x00010AD0 File Offset: 0x0000ECD0
		[EventInterest(new Type[]
		{
			typeof(GeometryChangedEvent)
		})]
		protected override void ExecuteDefaultAction(EventBase evt)
		{
			base.ExecuteDefaultAction(evt);
			bool flag = evt == null;
			if (!flag)
			{
				bool flag2 = evt.eventTypeId == EventBase<GeometryChangedEvent>.TypeId();
				if (flag2)
				{
					this.UpdateDragElementPosition((GeometryChangedEvent)evt);
				}
			}
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x00010B14 File Offset: 0x0000ED14
		private void UpdateTextFieldVisibility()
		{
			bool showInputField = this.showInputField;
			if (showInputField)
			{
				bool flag = this.inputTextField == null;
				if (flag)
				{
					this.inputTextField = new TextField
					{
						name = "unity-text-field"
					};
					this.inputTextField.AddToClassList(BaseSlider<TValueType>.textFieldClassName);
					this.inputTextField.RegisterCallback<NavigationMoveEvent>(new EventCallback<NavigationMoveEvent>(this.OnInputNavigationMoveEvent), TrickleDown.TrickleDown);
					this.inputTextField.RegisterValueChangedCallback(new EventCallback<ChangeEvent<string>>(this.OnTextFieldValueChange));
					this.inputTextField.RegisterCallback<FocusInEvent>(new EventCallback<FocusInEvent>(this.OnTextFieldFocusIn), TrickleDown.NoTrickleDown);
					this.inputTextField.RegisterCallback<FocusOutEvent>(new EventCallback<FocusOutEvent>(this.OnTextFieldFocusOut), TrickleDown.NoTrickleDown);
					base.visualInput.Add(this.inputTextField);
					this.UpdateTextFieldValue();
				}
			}
			else
			{
				bool flag2 = this.inputTextField != null && this.inputTextField.panel != null;
				if (flag2)
				{
					bool flag3 = this.inputTextField.panel != null;
					if (flag3)
					{
						this.inputTextField.RemoveFromHierarchy();
					}
					this.inputTextField.UnregisterCallback<NavigationMoveEvent>(new EventCallback<NavigationMoveEvent>(this.OnInputNavigationMoveEvent), TrickleDown.NoTrickleDown);
					this.inputTextField.UnregisterValueChangedCallback(new EventCallback<ChangeEvent<string>>(this.OnTextFieldValueChange));
					this.inputTextField.UnregisterCallback<FocusInEvent>(new EventCallback<FocusInEvent>(this.OnTextFieldFocusIn), TrickleDown.NoTrickleDown);
					this.inputTextField.UnregisterCallback<FocusOutEvent>(new EventCallback<FocusOutEvent>(this.OnTextFieldFocusOut), TrickleDown.NoTrickleDown);
					this.inputTextField = null;
				}
			}
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x00010C98 File Offset: 0x0000EE98
		private void UpdateTextFieldValue()
		{
			bool flag = this.inputTextField == null || this.m_IsEditingTextField;
			if (!flag)
			{
				this.inputTextField.SetValueWithoutNotify(string.Format(CultureInfo.InvariantCulture, "{0:g7}", this.value));
			}
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x00010CE3 File Offset: 0x0000EEE3
		private void OnTextFieldFocusIn(FocusInEvent evt)
		{
			this.m_IsEditingTextField = true;
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x00010CED File Offset: 0x0000EEED
		private void OnTextFieldFocusOut(FocusOutEvent evt)
		{
			this.m_IsEditingTextField = false;
			this.UpdateTextFieldValue();
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x00010CFE File Offset: 0x0000EEFE
		private void OnInputNavigationMoveEvent(NavigationMoveEvent evt)
		{
			evt.StopPropagation();
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x00010D08 File Offset: 0x0000EF08
		private void OnTextFieldValueChange(ChangeEvent<string> evt)
		{
			TValueType clampedValue = this.GetClampedValue(this.ParseStringToValue(evt.previousValue, evt.newValue));
			bool flag = !EqualityComparer<TValueType>.Default.Equals(clampedValue, this.value);
			if (flag)
			{
				this.value = clampedValue;
				evt.StopPropagation();
				bool flag2 = base.elementPanel != null;
				if (flag2)
				{
					this.OnViewDataReady();
				}
			}
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x00010D6C File Offset: 0x0000EF6C
		protected override void UpdateMixedValueContent()
		{
			bool showMixedValue = base.showMixedValue;
			if (showMixedValue)
			{
				VisualElement dragElement = this.dragElement;
				if (dragElement != null)
				{
					dragElement.RemoveFromHierarchy();
				}
			}
			else
			{
				this.dragContainer.Add(this.dragElement);
			}
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00010DB0 File Offset: 0x0000EFB0
		internal override void RegisterEditingCallbacks()
		{
			base.labelElement.RegisterCallback<PointerDownEvent>(new EventCallback<PointerDownEvent>(base.StartEditing), TrickleDown.TrickleDown);
			this.dragContainer.RegisterCallback<PointerDownEvent>(new EventCallback<PointerDownEvent>(base.StartEditing), TrickleDown.TrickleDown);
			this.dragContainer.RegisterCallback<PointerUpEvent>(new EventCallback<PointerUpEvent>(base.EndEditing), TrickleDown.NoTrickleDown);
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x00010E0C File Offset: 0x0000F00C
		internal override void UnregisterEditingCallbacks()
		{
			base.labelElement.UnregisterCallback<PointerDownEvent>(new EventCallback<PointerDownEvent>(base.StartEditing), TrickleDown.TrickleDown);
			this.dragContainer.UnregisterCallback<PointerDownEvent>(new EventCallback<PointerDownEvent>(base.StartEditing), TrickleDown.TrickleDown);
			this.dragContainer.UnregisterCallback<PointerUpEvent>(new EventCallback<PointerUpEvent>(base.EndEditing), TrickleDown.NoTrickleDown);
		}

		// Token: 0x0400017A RID: 378
		private bool m_IsEditingTextField;

		// Token: 0x0400017B RID: 379
		[SerializeField]
		private TValueType m_LowValue;

		// Token: 0x0400017C RID: 380
		[SerializeField]
		private TValueType m_HighValue;

		// Token: 0x0400017D RID: 381
		private float m_PageSize;

		// Token: 0x0400017E RID: 382
		private bool m_ShowInputField = false;

		// Token: 0x04000181 RID: 385
		private Rect m_DragElementStartPos;

		// Token: 0x04000182 RID: 386
		private SliderDirection m_Direction;

		// Token: 0x04000183 RID: 387
		private bool m_Inverted = false;

		// Token: 0x04000184 RID: 388
		internal const float kDefaultPageSize = 0f;

		// Token: 0x04000185 RID: 389
		internal const bool kDefaultShowInputField = false;

		// Token: 0x04000186 RID: 390
		internal const bool kDefaultInverted = false;

		// Token: 0x04000187 RID: 391
		public new static readonly string ussClassName = "unity-base-slider";

		// Token: 0x04000188 RID: 392
		public new static readonly string labelUssClassName = BaseSlider<TValueType>.ussClassName + "__label";

		// Token: 0x04000189 RID: 393
		public new static readonly string inputUssClassName = BaseSlider<TValueType>.ussClassName + "__input";

		// Token: 0x0400018A RID: 394
		public static readonly string horizontalVariantUssClassName = BaseSlider<TValueType>.ussClassName + "--horizontal";

		// Token: 0x0400018B RID: 395
		public static readonly string verticalVariantUssClassName = BaseSlider<TValueType>.ussClassName + "--vertical";

		// Token: 0x0400018C RID: 396
		public static readonly string dragContainerUssClassName = BaseSlider<TValueType>.ussClassName + "__drag-container";

		// Token: 0x0400018D RID: 397
		public static readonly string trackerUssClassName = BaseSlider<TValueType>.ussClassName + "__tracker";

		// Token: 0x0400018E RID: 398
		public static readonly string draggerUssClassName = BaseSlider<TValueType>.ussClassName + "__dragger";

		// Token: 0x0400018F RID: 399
		public static readonly string draggerBorderUssClassName = BaseSlider<TValueType>.ussClassName + "__dragger-border";

		// Token: 0x04000190 RID: 400
		public static readonly string textFieldClassName = BaseSlider<TValueType>.ussClassName + "__text-field";

		// Token: 0x02000063 RID: 99
		public new class UxmlTraits : BaseField<TValueType>.UxmlTraits
		{
			// Token: 0x06000448 RID: 1096 RVA: 0x00010F33 File Offset: 0x0000F133
			public UxmlTraits()
			{
				this.m_PickingMode.defaultValue = PickingMode.Ignore;
			}
		}

		// Token: 0x02000064 RID: 100
		internal enum SliderKey
		{
			// Token: 0x04000192 RID: 402
			None,
			// Token: 0x04000193 RID: 403
			Lowest,
			// Token: 0x04000194 RID: 404
			LowerPage,
			// Token: 0x04000195 RID: 405
			Lower,
			// Token: 0x04000196 RID: 406
			Higher,
			// Token: 0x04000197 RID: 407
			HigherPage,
			// Token: 0x04000198 RID: 408
			Highest
		}
	}
}
