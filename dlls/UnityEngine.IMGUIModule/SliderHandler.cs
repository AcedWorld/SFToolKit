using System;

namespace UnityEngine
{
	// Token: 0x0200003B RID: 59
	internal struct SliderHandler
	{
		// Token: 0x06000424 RID: 1060 RVA: 0x0000F734 File Offset: 0x0000D934
		public SliderHandler(Rect position, float currentValue, float size, float start, float end, GUIStyle slider, GUIStyle thumb, bool horiz, int id, GUIStyle thumbExtent = null)
		{
			this.position = position;
			this.currentValue = currentValue;
			this.size = size;
			this.start = start;
			this.end = end;
			this.slider = slider;
			this.thumb = thumb;
			this.thumbExtent = thumbExtent;
			this.horiz = horiz;
			this.id = id;
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x0000F790 File Offset: 0x0000D990
		public float Handle()
		{
			bool flag = this.slider == null || this.thumb == null;
			float result;
			if (flag)
			{
				result = this.currentValue;
			}
			else
			{
				EventType eventType = this.CurrentEventType();
				EventType eventType2 = eventType;
				switch (eventType2)
				{
				case EventType.MouseDown:
					return this.OnMouseDown();
				case EventType.MouseUp:
					return this.OnMouseUp();
				case EventType.MouseMove:
					break;
				case EventType.MouseDrag:
					return this.OnMouseDrag();
				default:
					if (eventType2 == EventType.Repaint)
					{
						return this.OnRepaint();
					}
					break;
				}
				result = this.currentValue;
			}
			return result;
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x0000F814 File Offset: 0x0000DA14
		private float OnMouseDown()
		{
			Rect rect = this.ThumbSelectionRect();
			bool flag = GUIUtility.HitTest(rect, this.CurrentEvent());
			Rect zero = Rect.zero;
			zero.xMin = Math.Min(this.position.xMin, rect.xMin);
			zero.xMax = Math.Max(this.position.xMax, rect.xMax);
			zero.yMin = Math.Min(this.position.yMin, rect.yMin);
			zero.yMax = Math.Max(this.position.yMax, rect.yMax);
			bool flag2 = this.IsEmptySlider() || (!GUIUtility.HitTest(zero, this.CurrentEvent()) && !flag);
			float result;
			if (flag2)
			{
				result = this.currentValue;
			}
			else
			{
				GUI.scrollTroughSide = 0;
				GUIUtility.hotControl = this.id;
				this.CurrentEvent().Use();
				bool flag3 = flag;
				if (flag3)
				{
					this.StartDraggingWithValue(this.ClampedCurrentValue());
					result = this.currentValue;
				}
				else
				{
					GUI.changed = true;
					bool flag4 = this.SupportsPageMovements();
					if (flag4)
					{
						this.SliderState().isDragging = false;
						GUI.nextScrollStepTime = SystemClock.now.AddMilliseconds(250.0);
						GUI.scrollTroughSide = this.CurrentScrollTroughSide();
						result = this.PageMovementValue();
					}
					else
					{
						float num = this.ValueForCurrentMousePosition();
						this.StartDraggingWithValue(num);
						result = this.Clamp(num);
					}
				}
			}
			return result;
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x0000F9A8 File Offset: 0x0000DBA8
		private float OnMouseDrag()
		{
			bool flag = GUIUtility.hotControl != this.id;
			float result;
			if (flag)
			{
				result = this.currentValue;
			}
			else
			{
				SliderState sliderState = this.SliderState();
				bool flag2 = !sliderState.isDragging;
				if (flag2)
				{
					result = this.currentValue;
				}
				else
				{
					GUI.changed = true;
					this.CurrentEvent().Use();
					float num = this.MousePosition() - sliderState.dragStartPos;
					float value = sliderState.dragStartValue + num / this.ValuesPerPixel();
					result = this.Clamp(value);
				}
			}
			return result;
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x0000FA34 File Offset: 0x0000DC34
		private float OnMouseUp()
		{
			bool flag = GUIUtility.hotControl == this.id;
			if (flag)
			{
				this.CurrentEvent().Use();
				GUIUtility.hotControl = 0;
			}
			return this.currentValue;
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x0000FA74 File Offset: 0x0000DC74
		private float OnRepaint()
		{
			bool flag = GUIUtility.HitTest(this.position, this.CurrentEvent());
			this.slider.Draw(this.position, GUIContent.none, this.id, false, flag);
			bool flag2 = this.currentValue >= Mathf.Min(this.start, this.end) && this.currentValue <= Mathf.Max(this.start, this.end);
			if (flag2)
			{
				bool flag3 = this.thumbExtent != null;
				if (flag3)
				{
					this.thumbExtent.Draw(this.ThumbExtRect(), GUIContent.none, this.id, false, flag);
				}
				this.thumb.Draw(this.ThumbRect(), GUIContent.none, this.id, false, flag);
			}
			bool flag4 = GUIUtility.hotControl != this.id || !flag || this.IsEmptySlider();
			float result;
			if (flag4)
			{
				result = this.currentValue;
			}
			else
			{
				Rect rect = this.ThumbRect();
				bool flag5 = this.horiz;
				if (flag5)
				{
					rect.y = this.position.y;
					rect.height = this.position.height;
				}
				else
				{
					rect.x = this.position.x;
					rect.width = this.position.width;
				}
				bool flag6 = GUIUtility.HitTest(rect, this.CurrentEvent());
				if (flag6)
				{
					bool flag7 = GUI.scrollTroughSide != 0;
					if (flag7)
					{
						GUIUtility.hotControl = 0;
					}
					result = this.currentValue;
				}
				else
				{
					GUI.InternalRepaintEditorWindow();
					bool flag8 = SystemClock.now < GUI.nextScrollStepTime;
					if (flag8)
					{
						result = this.currentValue;
					}
					else
					{
						bool flag9 = this.CurrentScrollTroughSide() != GUI.scrollTroughSide;
						if (flag9)
						{
							result = this.currentValue;
						}
						else
						{
							GUI.nextScrollStepTime = SystemClock.now.AddMilliseconds(30.0);
							bool flag10 = this.SupportsPageMovements();
							if (flag10)
							{
								this.SliderState().isDragging = false;
								GUI.changed = true;
								result = this.PageMovementValue();
							}
							else
							{
								result = this.ClampedCurrentValue();
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x0000FCAC File Offset: 0x0000DEAC
		private EventType CurrentEventType()
		{
			return this.CurrentEvent().GetTypeForControl(this.id);
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x0000FCD0 File Offset: 0x0000DED0
		private int CurrentScrollTroughSide()
		{
			float num = this.horiz ? this.CurrentEvent().mousePosition.x : this.CurrentEvent().mousePosition.y;
			float num2 = this.horiz ? this.ThumbRect().x : this.ThumbRect().y;
			return (num > num2) ? 1 : -1;
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x0000FD3C File Offset: 0x0000DF3C
		private bool IsEmptySlider()
		{
			return this.start == this.end;
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x0000FD5C File Offset: 0x0000DF5C
		private bool SupportsPageMovements()
		{
			return this.size != 0f && GUI.usePageScrollbars;
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x0000FD84 File Offset: 0x0000DF84
		private float PageMovementValue()
		{
			float num = this.currentValue;
			int num2 = (this.start > this.end) ? -1 : 1;
			bool flag = this.MousePosition() > this.PageUpMovementBound();
			if (flag)
			{
				num += this.size * (float)num2 * 0.9f;
			}
			else
			{
				num -= this.size * (float)num2 * 0.9f;
			}
			return this.Clamp(num);
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x0000FDF0 File Offset: 0x0000DFF0
		private float PageUpMovementBound()
		{
			bool flag = this.horiz;
			float result;
			if (flag)
			{
				result = this.ThumbRect().xMax - this.position.x;
			}
			else
			{
				result = this.ThumbRect().yMax - this.position.y;
			}
			return result;
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x0000FE4C File Offset: 0x0000E04C
		private Event CurrentEvent()
		{
			return Event.current;
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x0000FE64 File Offset: 0x0000E064
		private float ValueForCurrentMousePosition()
		{
			bool flag = this.horiz;
			float result;
			if (flag)
			{
				result = (this.MousePosition() - this.ThumbRect().width * 0.5f) / this.ValuesPerPixel() + this.start - this.size * 0.5f;
			}
			else
			{
				result = (this.MousePosition() - this.ThumbRect().height * 0.5f) / this.ValuesPerPixel() + this.start - this.size * 0.5f;
			}
			return result;
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x0000FEF0 File Offset: 0x0000E0F0
		private float Clamp(float value)
		{
			return Mathf.Clamp(value, this.MinValue(), this.MaxValue());
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x0000FF14 File Offset: 0x0000E114
		private Rect ThumbSelectionRect()
		{
			return this.ThumbRect();
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x0000FF30 File Offset: 0x0000E130
		private void StartDraggingWithValue(float dragStartValue)
		{
			SliderState sliderState = this.SliderState();
			sliderState.dragStartPos = this.MousePosition();
			sliderState.dragStartValue = dragStartValue;
			sliderState.isDragging = true;
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x0000FF60 File Offset: 0x0000E160
		private SliderState SliderState()
		{
			return (SliderState)GUIUtility.GetStateObject(typeof(SliderState), this.id);
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x0000FF8C File Offset: 0x0000E18C
		private Rect ThumbExtRect()
		{
			return new Rect(0f, 0f, this.thumbExtent.fixedWidth, this.thumbExtent.fixedHeight)
			{
				center = this.ThumbRect().center
			};
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x0000FFE0 File Offset: 0x0000E1E0
		private Rect ThumbRect()
		{
			return this.horiz ? this.HorizontalThumbRect() : this.VerticalThumbRect();
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x00010008 File Offset: 0x0000E208
		private Rect VerticalThumbRect()
		{
			Rect rect = this.thumb.margin.Remove(this.slider.padding.Remove(this.position));
			float width = (this.thumb.fixedWidth != 0f) ? this.thumb.fixedWidth : rect.width;
			float num = this.ThumbSize();
			float num2 = this.ValuesPerPixel();
			bool flag = this.start < this.end;
			Rect result;
			if (flag)
			{
				result = new Rect(rect.x, (this.ClampedCurrentValue() - this.start) * num2 + rect.y, width, this.size * num2 + num);
			}
			else
			{
				result = new Rect(rect.x, (this.ClampedCurrentValue() + this.size - this.start) * num2 + rect.y, width, this.size * -num2 + num);
			}
			return result;
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x000100F8 File Offset: 0x0000E2F8
		private Rect HorizontalThumbRect()
		{
			Rect rect = this.thumb.margin.Remove(this.slider.padding.Remove(this.position));
			float height = (this.thumb.fixedHeight != 0f) ? this.thumb.fixedHeight : rect.height;
			float num = this.ThumbSize();
			float num2 = this.ValuesPerPixel();
			bool flag = this.start < this.end;
			Rect result;
			if (flag)
			{
				result = new Rect((this.ClampedCurrentValue() - this.start) * num2 + rect.x, rect.y, this.size * num2 + num, height);
			}
			else
			{
				result = new Rect((this.ClampedCurrentValue() + this.size - this.start) * num2 + rect.x, rect.y, this.size * -num2 + num, height);
			}
			return result;
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x000101E4 File Offset: 0x0000E3E4
		private float ClampedCurrentValue()
		{
			return this.Clamp(this.currentValue);
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x00010204 File Offset: 0x0000E404
		private float MousePosition()
		{
			bool flag = this.horiz;
			float result;
			if (flag)
			{
				result = this.CurrentEvent().mousePosition.x - this.position.x;
			}
			else
			{
				result = this.CurrentEvent().mousePosition.y - this.position.y;
			}
			return result;
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x00010264 File Offset: 0x0000E464
		private float ValuesPerPixel()
		{
			float num = (this.end == this.start) ? 1f : (this.end - this.start);
			bool flag = this.horiz;
			float result;
			if (flag)
			{
				result = (this.position.width - (float)this.slider.padding.horizontal - this.ThumbSize()) / num;
			}
			else
			{
				result = (this.position.height - (float)this.slider.padding.vertical - this.ThumbSize()) / num;
			}
			return result;
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x000102F8 File Offset: 0x0000E4F8
		private float ThumbSize()
		{
			bool flag = this.horiz;
			float result;
			if (flag)
			{
				result = ((this.thumb.fixedWidth != 0f) ? this.thumb.fixedWidth : ((float)this.thumb.padding.horizontal));
			}
			else
			{
				result = ((this.thumb.fixedHeight != 0f) ? this.thumb.fixedHeight : ((float)this.thumb.padding.vertical));
			}
			return result;
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x00010378 File Offset: 0x0000E578
		private float MaxValue()
		{
			return Mathf.Max(this.start, this.end) - this.size;
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x000103A4 File Offset: 0x0000E5A4
		private float MinValue()
		{
			return Mathf.Min(this.start, this.end);
		}

		// Token: 0x04000136 RID: 310
		private readonly Rect position;

		// Token: 0x04000137 RID: 311
		private readonly float currentValue;

		// Token: 0x04000138 RID: 312
		private readonly float size;

		// Token: 0x04000139 RID: 313
		private readonly float start;

		// Token: 0x0400013A RID: 314
		private readonly float end;

		// Token: 0x0400013B RID: 315
		private readonly GUIStyle slider;

		// Token: 0x0400013C RID: 316
		private readonly GUIStyle thumb;

		// Token: 0x0400013D RID: 317
		private readonly GUIStyle thumbExtent;

		// Token: 0x0400013E RID: 318
		private readonly bool horiz;

		// Token: 0x0400013F RID: 319
		private readonly int id;
	}
}
