using System;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.UIElements
{
	// Token: 0x020000BC RID: 188
	[MovedFrom(true, "UnityEditor.UIElements", "UnityEditor.UIElementsModule", null)]
	public class Hash128Field : TextInputBaseField<Hash128>
	{
		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000677 RID: 1655 RVA: 0x00018AF4 File Offset: 0x00016CF4
		private Hash128Field.Hash128Input integerInput
		{
			get
			{
				return (Hash128Field.Hash128Input)base.textInputBase;
			}
		}

		// Token: 0x06000678 RID: 1656 RVA: 0x00018B01 File Offset: 0x00016D01
		public Hash128Field() : this(null, -1)
		{
		}

		// Token: 0x06000679 RID: 1657 RVA: 0x00018B0D File Offset: 0x00016D0D
		public Hash128Field(int maxLength) : this(null, maxLength)
		{
		}

		// Token: 0x0600067A RID: 1658 RVA: 0x00018B1C File Offset: 0x00016D1C
		public Hash128Field(string label, int maxLength = -1) : base(label, maxLength, '\0', new Hash128Field.Hash128Input())
		{
			this.m_UpdateTextFromValue = true;
			this.SetValueWithoutNotify(default(Hash128));
			base.AddToClassList(Hash128Field.ussClassName);
			base.labelElement.AddToClassList(Hash128Field.labelUssClassName);
			base.visualInput.AddToClassList(Hash128Field.inputUssClassName);
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x0600067B RID: 1659 RVA: 0x00018B80 File Offset: 0x00016D80
		// (set) Token: 0x0600067C RID: 1660 RVA: 0x00018B98 File Offset: 0x00016D98
		public override Hash128 value
		{
			get
			{
				return base.value;
			}
			set
			{
				base.value = value;
				bool updateTextFromValue = this.m_UpdateTextFromValue;
				if (updateTextFromValue)
				{
					base.text = base.rawValue.ToString();
				}
			}
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x00018BD4 File Offset: 0x00016DD4
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

		// Token: 0x0600067E RID: 1662 RVA: 0x00018C1C File Offset: 0x00016E1C
		internal override void UpdateTextFromValue()
		{
			base.text = this.ValueToString(base.rawValue);
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x00018C34 File Offset: 0x00016E34
		public override void SetValueWithoutNotify(Hash128 newValue)
		{
			base.SetValueWithoutNotify(newValue);
			bool updateTextFromValue = this.m_UpdateTextFromValue;
			if (updateTextFromValue)
			{
				base.text = base.rawValue.ToString();
			}
		}

		// Token: 0x06000680 RID: 1664 RVA: 0x00018C74 File Offset: 0x00016E74
		protected override string ValueToString(Hash128 value)
		{
			return value.ToString();
		}

		// Token: 0x06000681 RID: 1665 RVA: 0x00018C94 File Offset: 0x00016E94
		protected override Hash128 StringToValue(string str)
		{
			return Hash128Field.Hash128Input.Parse(str);
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x00018CAC File Offset: 0x00016EAC
		[EventInterest(new Type[]
		{
			typeof(BlurEvent)
		})]
		protected override void ExecuteDefaultAction(EventBase evt)
		{
			base.ExecuteDefaultAction(evt);
			bool flag = evt == null || base.textEdition.isReadOnly;
			if (!flag)
			{
				bool flag2 = evt.eventTypeId == EventBase<BlurEvent>.TypeId();
				if (flag2)
				{
					bool flag3 = string.IsNullOrEmpty(base.text);
					if (flag3)
					{
						this.value = default(Hash128);
					}
					else
					{
						base.textInputBase.UpdateValueFromText();
						base.textInputBase.UpdateTextFromValue();
					}
				}
			}
		}

		// Token: 0x040002CE RID: 718
		internal bool m_UpdateTextFromValue;

		// Token: 0x040002CF RID: 719
		public new static readonly string ussClassName = "unity-hash128-field";

		// Token: 0x040002D0 RID: 720
		public new static readonly string labelUssClassName = Hash128Field.ussClassName + "__label";

		// Token: 0x040002D1 RID: 721
		public new static readonly string inputUssClassName = Hash128Field.ussClassName + "__input";

		// Token: 0x020000BD RID: 189
		public new class UxmlFactory : UxmlFactory<Hash128Field, Hash128Field.UxmlTraits>
		{
		}

		// Token: 0x020000BE RID: 190
		public new class UxmlTraits : TextValueFieldTraits<Hash128, UxmlHash128AttributeDescription>
		{
		}

		// Token: 0x020000BF RID: 191
		private class Hash128Input : TextInputBaseField<Hash128>.TextInputBase
		{
			// Token: 0x17000112 RID: 274
			// (get) Token: 0x06000686 RID: 1670 RVA: 0x00018D6F File Offset: 0x00016F6F
			private Hash128Field hash128Field
			{
				get
				{
					return (Hash128Field)base.parent;
				}
			}

			// Token: 0x06000687 RID: 1671 RVA: 0x00018D7C File Offset: 0x00016F7C
			internal Hash128Input()
			{
				base.textEdition.AcceptCharacter = new Func<char, bool>(this.AcceptCharacter);
			}

			// Token: 0x17000113 RID: 275
			// (get) Token: 0x06000688 RID: 1672 RVA: 0x00018D9F File Offset: 0x00016F9F
			protected string allowedCharacters
			{
				get
				{
					return "0123456789abcdefABCDEF";
				}
			}

			// Token: 0x06000689 RID: 1673 RVA: 0x00018DA8 File Offset: 0x00016FA8
			internal override bool AcceptCharacter(char c)
			{
				return base.AcceptCharacter(c) && c != '\0' && this.allowedCharacters.IndexOf(c) != -1;
			}

			// Token: 0x17000114 RID: 276
			// (get) Token: 0x0600068A RID: 1674 RVA: 0x00018DDB File Offset: 0x00016FDB
			public string formatString
			{
				get
				{
					return UINumericFieldsUtils.k_IntFieldFormatString;
				}
			}

			// Token: 0x0600068B RID: 1675 RVA: 0x00018DE4 File Offset: 0x00016FE4
			protected string ValueToString(Hash128 value)
			{
				return value.ToString();
			}

			// Token: 0x0600068C RID: 1676 RVA: 0x00018E04 File Offset: 0x00017004
			protected override Hash128 StringToValue(string str)
			{
				return Hash128Field.Hash128Input.Parse(str);
			}

			// Token: 0x0600068D RID: 1677 RVA: 0x00018E1C File Offset: 0x0001701C
			internal static Hash128 Parse(string str)
			{
				ulong u64_;
				bool flag = str.Length == 1 && ulong.TryParse(str, out u64_);
				Hash128 result;
				if (flag)
				{
					result = new Hash128(u64_, 0UL);
				}
				else
				{
					result = Hash128.Parse(str);
				}
				return result;
			}
		}
	}
}
