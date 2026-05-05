using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000135 RID: 309
	public class Toggle : BaseBoolField
	{
		// Token: 0x06000A39 RID: 2617 RVA: 0x00028BBC File Offset: 0x00026DBC
		public Toggle() : this(null)
		{
		}

		// Token: 0x06000A3A RID: 2618 RVA: 0x00028BC8 File Offset: 0x00026DC8
		public Toggle(string label) : base(label)
		{
			base.AddToClassList(Toggle.ussClassName);
			base.visualInput.AddToClassList(Toggle.inputUssClassName);
			base.labelElement.AddToClassList(Toggle.labelUssClassName);
			this.m_CheckMark.AddToClassList(Toggle.checkmarkUssClassName);
		}

		// Token: 0x06000A3B RID: 2619 RVA: 0x00028C1D File Offset: 0x00026E1D
		protected override void InitLabel()
		{
			base.InitLabel();
			this.m_Label.AddToClassList(Toggle.textUssClassName);
		}

		// Token: 0x06000A3C RID: 2620 RVA: 0x00028C38 File Offset: 0x00026E38
		protected override void UpdateMixedValueContent()
		{
			bool showMixedValue = base.showMixedValue;
			if (showMixedValue)
			{
				base.visualInput.pseudoStates &= ~PseudoStates.Checked;
				base.pseudoStates &= ~PseudoStates.Checked;
				this.m_CheckMark.AddToClassList(Toggle.mixedValuesUssClassName);
			}
			else
			{
				this.m_CheckMark.RemoveFromClassList(Toggle.mixedValuesUssClassName);
				bool value = this.value;
				if (value)
				{
					base.visualInput.pseudoStates |= PseudoStates.Checked;
					base.pseudoStates |= PseudoStates.Checked;
				}
				else
				{
					base.visualInput.pseudoStates &= ~PseudoStates.Checked;
					base.pseudoStates &= ~PseudoStates.Checked;
				}
			}
		}

		// Token: 0x040004E0 RID: 1248
		public new static readonly string ussClassName = "unity-toggle";

		// Token: 0x040004E1 RID: 1249
		public new static readonly string labelUssClassName = Toggle.ussClassName + "__label";

		// Token: 0x040004E2 RID: 1250
		public new static readonly string inputUssClassName = Toggle.ussClassName + "__input";

		// Token: 0x040004E3 RID: 1251
		[Obsolete]
		public static readonly string noTextVariantUssClassName = Toggle.ussClassName + "--no-text";

		// Token: 0x040004E4 RID: 1252
		public static readonly string checkmarkUssClassName = Toggle.ussClassName + "__checkmark";

		// Token: 0x040004E5 RID: 1253
		public static readonly string textUssClassName = Toggle.ussClassName + "__text";

		// Token: 0x040004E6 RID: 1254
		public static readonly string mixedValuesUssClassName = Toggle.ussClassName + "__mixed-values";

		// Token: 0x02000136 RID: 310
		public new class UxmlFactory : UxmlFactory<Toggle, Toggle.UxmlTraits>
		{
		}

		// Token: 0x02000137 RID: 311
		public new class UxmlTraits : BaseFieldTraits<bool, UxmlBoolAttributeDescription>
		{
			// Token: 0x06000A3F RID: 2623 RVA: 0x00028D90 File Offset: 0x00026F90
			public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
			{
				base.Init(ve, bag, cc);
				((Toggle)ve).text = this.m_Text.GetValueFromBag(bag, cc);
			}

			// Token: 0x040004E7 RID: 1255
			private UxmlStringAttributeDescription m_Text = new UxmlStringAttributeDescription
			{
				name = "text"
			};
		}
	}
}
