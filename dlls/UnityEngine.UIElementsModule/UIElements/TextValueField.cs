using System;
using System.Collections.Generic;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.UIElements
{
	// Token: 0x02000132 RID: 306
	[MovedFrom(true, "UnityEditor.UIElements", "UnityEditor.UIElementsModule", null)]
	public abstract class TextValueField<TValueType> : TextInputBaseField<TValueType>, IValueField<!0>
	{
		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x06000A17 RID: 2583 RVA: 0x000286BB File Offset: 0x000268BB
		private TextValueField<TValueType>.TextValueInput textValueInput
		{
			get
			{
				return (TextValueField<TValueType>.TextValueInput)base.textInputBase;
			}
		}

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x06000A18 RID: 2584 RVA: 0x000286C8 File Offset: 0x000268C8
		// (set) Token: 0x06000A19 RID: 2585 RVA: 0x000286D8 File Offset: 0x000268D8
		public string formatString
		{
			get
			{
				return this.textValueInput.formatString;
			}
			set
			{
				bool flag = this.textValueInput.formatString != value;
				if (flag)
				{
					this.textValueInput.formatString = value;
					base.textEdition.UpdateText(this.ValueToString(base.rawValue));
				}
			}
		}

		// Token: 0x06000A1A RID: 2586 RVA: 0x00028722 File Offset: 0x00026922
		protected TextValueField(int maxLength, TextValueField<TValueType>.TextValueInput textValueInput) : this(null, maxLength, textValueInput)
		{
		}

		// Token: 0x06000A1B RID: 2587 RVA: 0x0002872F File Offset: 0x0002692F
		protected TextValueField(string label, int maxLength, TextValueField<TValueType>.TextValueInput textValueInput) : base(label, maxLength, '\0', textValueInput)
		{
			this.m_UpdateTextFromValue = true;
			base.textEdition.UpdateText(this.ValueToString(base.rawValue));
			base.onIsReadOnlyChanged += this.OnIsReadOnlyChanged;
		}

		// Token: 0x06000A1C RID: 2588
		public abstract void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, TValueType startValue);

		// Token: 0x06000A1D RID: 2589 RVA: 0x00028770 File Offset: 0x00026970
		public void StartDragging()
		{
			bool showMixedValue = base.showMixedValue;
			if (showMixedValue)
			{
				this.value = default(TValueType);
			}
			this.textValueInput.StartDragging();
		}

		// Token: 0x06000A1E RID: 2590 RVA: 0x000287A6 File Offset: 0x000269A6
		public void StopDragging()
		{
			this.textValueInput.StopDragging();
		}

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x06000A1F RID: 2591 RVA: 0x000287B5 File Offset: 0x000269B5
		// (set) Token: 0x06000A20 RID: 2592 RVA: 0x000287BD File Offset: 0x000269BD
		public override TValueType value
		{
			get
			{
				return base.value;
			}
			set
			{
				base.value = value;
			}
		}

		// Token: 0x06000A21 RID: 2593 RVA: 0x000287C8 File Offset: 0x000269C8
		internal override void UpdateValueFromText()
		{
			this.m_UpdateTextFromValue = false;
			try
			{
				this.value = this.StringToValue(base.text);
			}
			finally
			{
				this.m_UpdateTextFromValue = true;
			}
		}

		// Token: 0x06000A22 RID: 2594 RVA: 0x00028810 File Offset: 0x00026A10
		internal override void UpdateTextFromValue()
		{
			base.text = this.ValueToString(base.rawValue);
		}

		// Token: 0x06000A23 RID: 2595 RVA: 0x00028826 File Offset: 0x00026A26
		private void OnIsReadOnlyChanged(bool newValue)
		{
			this.EnableLabelDragger(!newValue);
		}

		// Token: 0x06000A24 RID: 2596 RVA: 0x0000960A File Offset: 0x0000780A
		internal virtual bool CanTryParse(string textString)
		{
			return false;
		}

		// Token: 0x06000A25 RID: 2597 RVA: 0x00028834 File Offset: 0x00026A34
		protected void AddLabelDragger<TDraggerType>()
		{
			this.m_Dragger = new FieldMouseDragger<TDraggerType>((IValueField<TDraggerType>)this);
			this.EnableLabelDragger(!base.isReadOnly);
		}

		// Token: 0x06000A26 RID: 2598 RVA: 0x00028858 File Offset: 0x00026A58
		private void EnableLabelDragger(bool enable)
		{
			bool flag = this.m_Dragger != null;
			if (flag)
			{
				this.m_Dragger.SetDragZone(enable ? base.labelElement : null);
				base.labelElement.EnableInClassList(BaseField<TValueType>.labelDraggerVariantUssClassName, enable);
			}
		}

		// Token: 0x06000A27 RID: 2599 RVA: 0x000288A0 File Offset: 0x00026AA0
		public override void SetValueWithoutNotify(TValueType newValue)
		{
			bool flag = this.m_ForceUpdateDisplay || (this.m_UpdateTextFromValue && !EqualityComparer<TValueType>.Default.Equals(base.rawValue, newValue));
			base.SetValueWithoutNotify(newValue);
			bool flag2 = flag;
			if (flag2)
			{
				base.textEdition.UpdateText(this.ValueToString(base.rawValue));
			}
			this.m_ForceUpdateDisplay = false;
		}

		// Token: 0x06000A28 RID: 2600 RVA: 0x00028908 File Offset: 0x00026B08
		[EventInterest(new Type[]
		{
			typeof(BlurEvent),
			typeof(FocusEvent)
		})]
		protected override void ExecuteDefaultAction(EventBase evt)
		{
			base.ExecuteDefaultAction(evt);
			bool flag = evt == null;
			if (!flag)
			{
				bool flag2 = evt.eventTypeId == EventBase<BlurEvent>.TypeId();
				if (flag2)
				{
					bool showMixedValue = base.showMixedValue;
					if (showMixedValue)
					{
						this.UpdateMixedValueContent();
					}
					else
					{
						bool flag3 = string.IsNullOrEmpty(base.text);
						if (flag3)
						{
							base.textInputBase.UpdateTextFromValue();
						}
						else
						{
							base.textInputBase.UpdateValueFromText();
							base.textInputBase.UpdateTextFromValue();
						}
					}
				}
				else
				{
					bool flag4 = evt.eventTypeId == EventBase<FocusEvent>.TypeId();
					if (flag4)
					{
						bool showMixedValue2 = base.showMixedValue;
						if (showMixedValue2)
						{
							base.textInputBase.text = "";
						}
					}
				}
			}
		}

		// Token: 0x06000A29 RID: 2601 RVA: 0x000289C3 File Offset: 0x00026BC3
		internal override void OnViewDataReady()
		{
			this.m_ForceUpdateDisplay = true;
			base.OnViewDataReady();
		}

		// Token: 0x06000A2A RID: 2602 RVA: 0x000289D4 File Offset: 0x00026BD4
		internal override void RegisterEditingCallbacks()
		{
			base.RegisterEditingCallbacks();
			base.labelElement.RegisterCallback<PointerDownEvent>(new EventCallback<PointerDownEvent>(base.StartEditing), TrickleDown.TrickleDown);
			base.labelElement.RegisterCallback<PointerUpEvent>(new EventCallback<PointerUpEvent>(base.EndEditing), TrickleDown.NoTrickleDown);
		}

		// Token: 0x06000A2B RID: 2603 RVA: 0x00028A10 File Offset: 0x00026C10
		internal override void UnregisterEditingCallbacks()
		{
			base.UnregisterEditingCallbacks();
			base.labelElement.UnregisterCallback<PointerDownEvent>(new EventCallback<PointerDownEvent>(base.StartEditing), TrickleDown.TrickleDown);
			base.labelElement.UnregisterCallback<PointerUpEvent>(new EventCallback<PointerUpEvent>(base.EndEditing), TrickleDown.NoTrickleDown);
		}

		// Token: 0x040004D9 RID: 1241
		private BaseFieldMouseDragger m_Dragger;

		// Token: 0x040004DA RID: 1242
		internal bool m_UpdateTextFromValue;

		// Token: 0x040004DB RID: 1243
		private bool m_ForceUpdateDisplay;

		// Token: 0x040004DC RID: 1244
		internal const int kMaxValueFieldLength = 1000;

		// Token: 0x02000133 RID: 307
		protected abstract class TextValueInput : TextInputBaseField<TValueType>.TextInputBase
		{
			// Token: 0x170001E9 RID: 489
			// (get) Token: 0x06000A2C RID: 2604 RVA: 0x00028A4C File Offset: 0x00026C4C
			private TextValueField<TValueType> textValueFieldParent
			{
				get
				{
					return (TextValueField<TValueType>)base.parent;
				}
			}

			// Token: 0x06000A2D RID: 2605 RVA: 0x00028A59 File Offset: 0x00026C59
			protected TextValueInput()
			{
				base.textEdition.AcceptCharacter = new Func<char, bool>(this.AcceptCharacter);
			}

			// Token: 0x06000A2E RID: 2606 RVA: 0x00028A7C File Offset: 0x00026C7C
			internal override bool AcceptCharacter(char c)
			{
				return base.AcceptCharacter(c) && c != '\0' && this.allowedCharacters.IndexOf(c) != -1;
			}

			// Token: 0x170001EA RID: 490
			// (get) Token: 0x06000A2F RID: 2607
			protected abstract string allowedCharacters { get; }

			// Token: 0x170001EB RID: 491
			// (get) Token: 0x06000A30 RID: 2608 RVA: 0x00028AAF File Offset: 0x00026CAF
			// (set) Token: 0x06000A31 RID: 2609 RVA: 0x00028AB7 File Offset: 0x00026CB7
			public string formatString { get; set; }

			// Token: 0x06000A32 RID: 2610
			public abstract void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, TValueType startValue);

			// Token: 0x06000A33 RID: 2611 RVA: 0x00028AC0 File Offset: 0x00026CC0
			public void StartDragging()
			{
				base.isDragging = true;
				base.SelectNone();
				base.MarkDirtyRepaint();
			}

			// Token: 0x06000A34 RID: 2612 RVA: 0x00028ADC File Offset: 0x00026CDC
			public void StopDragging()
			{
				bool isDelayed = this.textValueFieldParent.isDelayed;
				if (isDelayed)
				{
					base.UpdateValueFromText();
				}
				base.isDragging = false;
				base.SelectAll();
				base.MarkDirtyRepaint();
			}

			// Token: 0x06000A35 RID: 2613
			protected abstract string ValueToString(TValueType value);

			// Token: 0x06000A36 RID: 2614 RVA: 0x00028B18 File Offset: 0x00026D18
			protected override TValueType StringToValue(string str)
			{
				return base.StringToValue(str);
			}
		}
	}
}
