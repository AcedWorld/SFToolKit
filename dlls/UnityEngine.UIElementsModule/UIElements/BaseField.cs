using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace UnityEngine.UIElements
{
	// Token: 0x020000CD RID: 205
	public abstract class BaseField<TValueType> : BindableElement, INotifyValueChanged<TValueType>, IMixedValueSupport, IPrefixLabel, IEditableElement
	{
		// Token: 0x17000127 RID: 295
		// (get) Token: 0x060006CE RID: 1742 RVA: 0x00019CB8 File Offset: 0x00017EB8
		// (set) Token: 0x060006CF RID: 1743 RVA: 0x00019CD0 File Offset: 0x00017ED0
		internal VisualElement visualInput
		{
			get
			{
				return this.m_VisualInput;
			}
			set
			{
				bool flag = this.m_VisualInput != null;
				if (flag)
				{
					bool flag2 = this.m_VisualInput.parent == this;
					if (flag2)
					{
						this.m_VisualInput.RemoveFromHierarchy();
					}
					this.m_VisualInput = null;
				}
				bool flag3 = value != null;
				if (flag3)
				{
					this.m_VisualInput = value;
				}
				else
				{
					this.m_VisualInput = new VisualElement
					{
						pickingMode = PickingMode.Ignore
					};
				}
				this.m_VisualInput.focusable = true;
				this.m_VisualInput.AddToClassList(BaseField<TValueType>.inputUssClassName);
				base.Add(this.m_VisualInput);
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x060006D0 RID: 1744 RVA: 0x00019D68 File Offset: 0x00017F68
		// (set) Token: 0x060006D1 RID: 1745 RVA: 0x00019D80 File Offset: 0x00017F80
		protected TValueType rawValue
		{
			get
			{
				return this.m_Value;
			}
			set
			{
				this.m_Value = value;
			}
		}

		// Token: 0x14000021 RID: 33
		// (add) Token: 0x060006D2 RID: 1746 RVA: 0x00019D8C File Offset: 0x00017F8C
		// (remove) Token: 0x060006D3 RID: 1747 RVA: 0x00019DC4 File Offset: 0x00017FC4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal event Func<TValueType, TValueType> onValidateValue;

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x060006D4 RID: 1748 RVA: 0x00019DFC File Offset: 0x00017FFC
		// (set) Token: 0x060006D5 RID: 1749 RVA: 0x00019E14 File Offset: 0x00018014
		public virtual TValueType value
		{
			get
			{
				return this.m_Value;
			}
			set
			{
				bool flag = !this.EqualsCurrentValue(value) || this.showMixedValue;
				if (flag)
				{
					TValueType value2 = this.m_Value;
					this.SetValueWithoutNotify(value);
					this.showMixedValue = false;
					bool flag2 = base.panel != null;
					if (flag2)
					{
						using (ChangeEvent<TValueType> pooled = ChangeEvent<TValueType>.GetPooled(value2, this.m_Value))
						{
							pooled.target = this;
							this.SendEvent(pooled);
						}
					}
				}
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x060006D6 RID: 1750 RVA: 0x00019E9C File Offset: 0x0001809C
		// (set) Token: 0x060006D7 RID: 1751 RVA: 0x00019EA4 File Offset: 0x000180A4
		public Label labelElement { get; private set; }

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x060006D8 RID: 1752 RVA: 0x00019EB0 File Offset: 0x000180B0
		// (set) Token: 0x060006D9 RID: 1753 RVA: 0x00019ED0 File Offset: 0x000180D0
		public string label
		{
			get
			{
				return this.labelElement.text;
			}
			set
			{
				bool flag = this.labelElement.text != value;
				if (flag)
				{
					this.labelElement.text = value;
					bool flag2 = string.IsNullOrEmpty(this.labelElement.text);
					if (flag2)
					{
						base.AddToClassList(BaseField<TValueType>.noLabelVariantUssClassName);
						this.labelElement.RemoveFromHierarchy();
					}
					else
					{
						bool flag3 = !base.Contains(this.labelElement);
						if (flag3)
						{
							base.hierarchy.Insert(0, this.labelElement);
							base.RemoveFromClassList(BaseField<TValueType>.noLabelVariantUssClassName);
						}
					}
				}
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x060006DA RID: 1754 RVA: 0x00019F6B File Offset: 0x0001816B
		// (set) Token: 0x060006DB RID: 1755 RVA: 0x00019F74 File Offset: 0x00018174
		public bool showMixedValue
		{
			get
			{
				return this.m_ShowMixedValue;
			}
			set
			{
				bool flag = value == this.m_ShowMixedValue;
				if (!flag)
				{
					this.m_ShowMixedValue = value;
					this.UpdateMixedValueContent();
				}
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x060006DC RID: 1756 RVA: 0x00019FA0 File Offset: 0x000181A0
		protected Label mixedValueLabel
		{
			get
			{
				bool flag = this.m_MixedValueLabel == null;
				if (flag)
				{
					this.m_MixedValueLabel = new Label(BaseField<TValueType>.mixedValueString)
					{
						focusable = true,
						tabIndex = -1
					};
					this.m_MixedValueLabel.AddToClassList(BaseField<TValueType>.labelUssClassName);
					this.m_MixedValueLabel.AddToClassList(BaseField<TValueType>.mixedValueLabelUssClassName);
				}
				return this.m_MixedValueLabel;
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x060006DD RID: 1757 RVA: 0x0001A009 File Offset: 0x00018209
		// (set) Token: 0x060006DE RID: 1758 RVA: 0x0001A011 File Offset: 0x00018211
		Action IEditableElement.editingStarted { get; set; }

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x060006DF RID: 1759 RVA: 0x0001A01A File Offset: 0x0001821A
		// (set) Token: 0x060006E0 RID: 1760 RVA: 0x0001A022 File Offset: 0x00018222
		Action IEditableElement.editingEnded { get; set; }

		// Token: 0x060006E1 RID: 1761 RVA: 0x0001A02C File Offset: 0x0001822C
		internal BaseField(string label)
		{
			base.isCompositeRoot = true;
			base.focusable = true;
			base.tabIndex = 0;
			base.excludeFromFocusRing = true;
			base.delegatesFocus = true;
			base.AddToClassList(BaseField<TValueType>.ussClassName);
			this.labelElement = new Label
			{
				focusable = true,
				tabIndex = -1
			};
			this.labelElement.AddToClassList(BaseField<TValueType>.labelUssClassName);
			bool flag = label != null;
			if (flag)
			{
				this.label = label;
			}
			else
			{
				base.AddToClassList(BaseField<TValueType>.noLabelVariantUssClassName);
			}
			base.RegisterCallback<AttachToPanelEvent>(new EventCallback<AttachToPanelEvent>(this.OnAttachToPanel), TrickleDown.NoTrickleDown);
			base.RegisterCallback<DetachFromPanelEvent>(new EventCallback<DetachFromPanelEvent>(this.OnDetachFromPanel), TrickleDown.NoTrickleDown);
			this.m_VisualInput = null;
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x0001A0F3 File Offset: 0x000182F3
		protected BaseField(string label, VisualElement visualInput) : this(label)
		{
			this.visualInput = visualInput;
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x0001A106 File Offset: 0x00018306
		internal virtual bool EqualsCurrentValue(TValueType value)
		{
			return EqualityComparer<TValueType>.Default.Equals(this.m_Value, value);
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x0001A11C File Offset: 0x0001831C
		private void OnAttachToPanel(AttachToPanelEvent e)
		{
			this.RegisterEditingCallbacks();
			bool flag = e.destinationPanel == null;
			if (!flag)
			{
				bool flag2 = e.destinationPanel.contextType == ContextType.Player;
				if (!flag2)
				{
					for (VisualElement parent = base.parent; parent != null; parent = parent.parent)
					{
						bool flag3 = parent.ClassListContains("unity-inspector-element");
						if (flag3)
						{
							this.m_CachedInspectorElement = parent;
						}
						bool flag4 = parent.ClassListContains("unity-inspector-main-container");
						if (flag4)
						{
							this.m_CachedContextWidthElement = parent;
							break;
						}
					}
					bool flag5 = this.m_CachedInspectorElement == null;
					if (!flag5)
					{
						this.m_LabelWidthRatio = 0.45f;
						this.m_LabelExtraPadding = 37f;
						this.m_LabelBaseMinWidth = 123f;
						this.m_LabelExtraContextWidth = 1f;
						base.RegisterCallback<CustomStyleResolvedEvent>(new EventCallback<CustomStyleResolvedEvent>(this.OnCustomStyleResolved), TrickleDown.NoTrickleDown);
						base.AddToClassList(BaseField<TValueType>.inspectorFieldUssClassName);
						base.RegisterCallback<GeometryChangedEvent>(new EventCallback<GeometryChangedEvent>(this.OnInspectorFieldGeometryChanged), TrickleDown.NoTrickleDown);
					}
				}
			}
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x0001A21D File Offset: 0x0001841D
		private void OnDetachFromPanel(DetachFromPanelEvent e)
		{
			this.UnregisterEditingCallbacks();
			this.onValidateValue = null;
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x0001A22E File Offset: 0x0001842E
		internal virtual void RegisterEditingCallbacks()
		{
			base.RegisterCallback<FocusInEvent>(new EventCallback<FocusInEvent>(this.StartEditing), TrickleDown.NoTrickleDown);
			base.RegisterCallback<FocusOutEvent>(new EventCallback<FocusOutEvent>(this.EndEditing), TrickleDown.NoTrickleDown);
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x0001A259 File Offset: 0x00018459
		internal virtual void UnregisterEditingCallbacks()
		{
			base.UnregisterCallback<FocusInEvent>(new EventCallback<FocusInEvent>(this.StartEditing), TrickleDown.NoTrickleDown);
			base.UnregisterCallback<FocusOutEvent>(new EventCallback<FocusOutEvent>(this.EndEditing), TrickleDown.NoTrickleDown);
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x0001A284 File Offset: 0x00018484
		internal void StartEditing(EventBase e)
		{
			Action editingStarted = ((IEditableElement)this).editingStarted;
			if (editingStarted != null)
			{
				editingStarted();
			}
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x0001A299 File Offset: 0x00018499
		internal void EndEditing(EventBase e)
		{
			Action editingEnded = ((IEditableElement)this).editingEnded;
			if (editingEnded != null)
			{
				editingEnded();
			}
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x0001A2B0 File Offset: 0x000184B0
		private void OnCustomStyleResolved(CustomStyleResolvedEvent evt)
		{
			float labelWidthRatio;
			bool flag = evt.customStyle.TryGetValue(BaseField<TValueType>.s_LabelWidthRatioProperty, out labelWidthRatio);
			if (flag)
			{
				this.m_LabelWidthRatio = labelWidthRatio;
			}
			float labelExtraPadding;
			bool flag2 = evt.customStyle.TryGetValue(BaseField<TValueType>.s_LabelExtraPaddingProperty, out labelExtraPadding);
			if (flag2)
			{
				this.m_LabelExtraPadding = labelExtraPadding;
			}
			float labelBaseMinWidth;
			bool flag3 = evt.customStyle.TryGetValue(BaseField<TValueType>.s_LabelBaseMinWidthProperty, out labelBaseMinWidth);
			if (flag3)
			{
				this.m_LabelBaseMinWidth = labelBaseMinWidth;
			}
			float labelExtraContextWidth;
			bool flag4 = evt.customStyle.TryGetValue(BaseField<TValueType>.s_LabelExtraContextWidthProperty, out labelExtraContextWidth);
			if (flag4)
			{
				this.m_LabelExtraContextWidth = labelExtraContextWidth;
			}
			this.AlignLabel();
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x0001A349 File Offset: 0x00018549
		private void OnInspectorFieldGeometryChanged(GeometryChangedEvent e)
		{
			this.AlignLabel();
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x0001A354 File Offset: 0x00018554
		private void AlignLabel()
		{
			bool flag = !base.ClassListContains(BaseField<TValueType>.alignedFieldUssClassName);
			if (!flag)
			{
				float num = this.m_LabelExtraPadding;
				float num2 = base.worldBound.x - this.m_CachedInspectorElement.worldBound.x - this.m_CachedInspectorElement.resolvedStyle.paddingLeft;
				num += num2;
				num += base.resolvedStyle.paddingLeft;
				float a = this.m_LabelBaseMinWidth - num2 - base.resolvedStyle.paddingLeft;
				VisualElement visualElement = this.m_CachedContextWidthElement ?? this.m_CachedInspectorElement;
				this.labelElement.style.minWidth = Mathf.Max(a, 0f);
				float num3 = (visualElement.resolvedStyle.width + this.m_LabelExtraContextWidth) * this.m_LabelWidthRatio - num;
				bool flag2 = Mathf.Abs(this.labelElement.resolvedStyle.width - num3) > 1E-30f;
				if (flag2)
				{
					this.labelElement.style.width = Mathf.Max(0f, num3);
				}
			}
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x0001A478 File Offset: 0x00018678
		internal TValueType ValidatedValue(TValueType value)
		{
			bool flag = this.onValidateValue != null;
			TValueType result;
			if (flag)
			{
				result = this.onValidateValue(value);
			}
			else
			{
				result = value;
			}
			return result;
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x0001A4A8 File Offset: 0x000186A8
		protected virtual void UpdateMixedValueContent()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x0001A4B0 File Offset: 0x000186B0
		public virtual void SetValueWithoutNotify(TValueType newValue)
		{
			bool skipValidation = this.m_SkipValidation;
			if (skipValidation)
			{
				this.m_Value = newValue;
			}
			else
			{
				this.m_Value = this.ValidatedValue(newValue);
			}
			bool flag = !string.IsNullOrEmpty(base.viewDataKey);
			if (flag)
			{
				base.SaveViewData();
			}
			base.MarkDirtyRepaint();
			bool showMixedValue = this.showMixedValue;
			if (showMixedValue)
			{
				this.UpdateMixedValueContent();
			}
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x0001A513 File Offset: 0x00018713
		internal void SetValueWithoutValidation(TValueType newValue)
		{
			this.m_SkipValidation = true;
			this.value = newValue;
			this.m_SkipValidation = false;
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x0001A52C File Offset: 0x0001872C
		internal override void OnViewDataReady()
		{
			base.OnViewDataReady();
			bool flag = this.m_VisualInput != null;
			if (flag)
			{
				string fullHierarchicalViewDataKey = base.GetFullHierarchicalViewDataKey();
				TValueType value = this.m_Value;
				base.OverwriteFromViewData(this, fullHierarchicalViewDataKey);
				bool flag2 = !EqualityComparer<TValueType>.Default.Equals(value, this.m_Value);
				if (flag2)
				{
					using (ChangeEvent<TValueType> pooled = ChangeEvent<TValueType>.GetPooled(value, this.m_Value))
					{
						pooled.target = this;
						this.SetValueWithoutNotify(this.m_Value);
						this.SendEvent(pooled);
					}
				}
			}
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x0001A5D0 File Offset: 0x000187D0
		internal override Rect GetTooltipRect()
		{
			return (!string.IsNullOrEmpty(this.label)) ? this.labelElement.worldBound : base.worldBound;
		}

		// Token: 0x040002F6 RID: 758
		public static readonly string ussClassName = "unity-base-field";

		// Token: 0x040002F7 RID: 759
		public static readonly string labelUssClassName = BaseField<TValueType>.ussClassName + "__label";

		// Token: 0x040002F8 RID: 760
		public static readonly string inputUssClassName = BaseField<TValueType>.ussClassName + "__input";

		// Token: 0x040002F9 RID: 761
		public static readonly string noLabelVariantUssClassName = BaseField<TValueType>.ussClassName + "--no-label";

		// Token: 0x040002FA RID: 762
		public static readonly string labelDraggerVariantUssClassName = BaseField<TValueType>.labelUssClassName + "--with-dragger";

		// Token: 0x040002FB RID: 763
		public static readonly string mixedValueLabelUssClassName = BaseField<TValueType>.labelUssClassName + "--mixed-value";

		// Token: 0x040002FC RID: 764
		public static readonly string alignedFieldUssClassName = BaseField<TValueType>.ussClassName + "__aligned";

		// Token: 0x040002FD RID: 765
		private static readonly string inspectorFieldUssClassName = BaseField<TValueType>.ussClassName + "__inspector-field";

		// Token: 0x040002FE RID: 766
		protected internal static readonly string mixedValueString = "—";

		// Token: 0x040002FF RID: 767
		protected internal static readonly PropertyName serializedPropertyCopyName = "SerializedPropertyCopyName";

		// Token: 0x04000300 RID: 768
		private static CustomStyleProperty<float> s_LabelWidthRatioProperty = new CustomStyleProperty<float>("--unity-property-field-label-width-ratio");

		// Token: 0x04000301 RID: 769
		private static CustomStyleProperty<float> s_LabelExtraPaddingProperty = new CustomStyleProperty<float>("--unity-property-field-label-extra-padding");

		// Token: 0x04000302 RID: 770
		private static CustomStyleProperty<float> s_LabelBaseMinWidthProperty = new CustomStyleProperty<float>("--unity-property-field-label-base-min-width");

		// Token: 0x04000303 RID: 771
		private static CustomStyleProperty<float> s_LabelExtraContextWidthProperty = new CustomStyleProperty<float>("--unity-base-field-extra-context-width");

		// Token: 0x04000304 RID: 772
		private float m_LabelWidthRatio;

		// Token: 0x04000305 RID: 773
		private float m_LabelExtraPadding;

		// Token: 0x04000306 RID: 774
		private float m_LabelBaseMinWidth;

		// Token: 0x04000307 RID: 775
		private float m_LabelExtraContextWidth;

		// Token: 0x04000308 RID: 776
		private VisualElement m_VisualInput;

		// Token: 0x04000309 RID: 777
		[SerializeField]
		private TValueType m_Value;

		// Token: 0x0400030C RID: 780
		private bool m_ShowMixedValue;

		// Token: 0x0400030D RID: 781
		private Label m_MixedValueLabel;

		// Token: 0x0400030E RID: 782
		private bool m_SkipValidation;

		// Token: 0x0400030F RID: 783
		private VisualElement m_CachedContextWidthElement;

		// Token: 0x04000310 RID: 784
		private VisualElement m_CachedInspectorElement;

		// Token: 0x020000CE RID: 206
		public new class UxmlTraits : BindableElement.UxmlTraits
		{
			// Token: 0x060006F4 RID: 1780 RVA: 0x0001A6FC File Offset: 0x000188FC
			public UxmlTraits()
			{
				base.focusIndex.defaultValue = 0;
				base.focusable.defaultValue = true;
			}

			// Token: 0x060006F5 RID: 1781 RVA: 0x0001A737 File Offset: 0x00018937
			public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
			{
				base.Init(ve, bag, cc);
				((BaseField<TValueType>)ve).label = this.m_Label.GetValueFromBag(bag, cc);
			}

			// Token: 0x060006F6 RID: 1782 RVA: 0x0001A760 File Offset: 0x00018960
			internal static List<string> ParseChoiceList(string choicesFromBag)
			{
				bool flag = string.IsNullOrEmpty(choicesFromBag.Trim());
				List<string> result;
				if (flag)
				{
					result = null;
				}
				else
				{
					string[] array = choicesFromBag.Split(',', StringSplitOptions.None);
					bool flag2 = array.Length != 0;
					if (flag2)
					{
						List<string> list = new List<string>();
						foreach (string text in array)
						{
							list.Add(text.Trim());
						}
						result = list;
					}
					else
					{
						result = null;
					}
				}
				return result;
			}

			// Token: 0x04000313 RID: 787
			private UxmlStringAttributeDescription m_Label = new UxmlStringAttributeDescription
			{
				name = "label"
			};
		}
	}
}
