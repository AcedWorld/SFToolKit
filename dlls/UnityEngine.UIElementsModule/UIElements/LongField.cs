using System;
using System.Globalization;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.UIElements
{
	// Token: 0x020000E4 RID: 228
	[MovedFrom(true, "UnityEditor.UIElements", "UnityEditor.UIElementsModule", null)]
	public class LongField : TextValueField<long>
	{
		// Token: 0x17000165 RID: 357
		// (get) Token: 0x060007BD RID: 1981 RVA: 0x0001D769 File Offset: 0x0001B969
		private LongField.LongInput longInput
		{
			get
			{
				return (LongField.LongInput)base.textInputBase;
			}
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x0001D778 File Offset: 0x0001B978
		protected override string ValueToString(long v)
		{
			return v.ToString(base.formatString, CultureInfo.InvariantCulture.NumberFormat);
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x0001D7A4 File Offset: 0x0001B9A4
		protected override long StringToValue(string str)
		{
			long num;
			return UINumericFieldsUtils.TryConvertStringToLong(str, base.textInputBase.originalText, out num) ? num : base.rawValue;
		}

		// Token: 0x060007C0 RID: 1984 RVA: 0x0001D7D6 File Offset: 0x0001B9D6
		public LongField() : this(null, 1000)
		{
		}

		// Token: 0x060007C1 RID: 1985 RVA: 0x0001D7E6 File Offset: 0x0001B9E6
		public LongField(int maxLength) : this(null, maxLength)
		{
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x0001D7F4 File Offset: 0x0001B9F4
		public LongField(string label, int maxLength = 1000) : base(label, maxLength, new LongField.LongInput())
		{
			base.AddToClassList(LongField.ussClassName);
			base.labelElement.AddToClassList(LongField.labelUssClassName);
			base.visualInput.AddToClassList(LongField.inputUssClassName);
			base.AddLabelDragger<long>();
		}

		// Token: 0x060007C3 RID: 1987 RVA: 0x0001D848 File Offset: 0x0001BA48
		internal override bool CanTryParse(string textString)
		{
			long num;
			return long.TryParse(textString, out num);
		}

		// Token: 0x060007C4 RID: 1988 RVA: 0x0001D85D File Offset: 0x0001BA5D
		public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, long startValue)
		{
			this.longInput.ApplyInputDeviceDelta(delta, speed, startValue);
		}

		// Token: 0x04000353 RID: 851
		public new static readonly string ussClassName = "unity-long-field";

		// Token: 0x04000354 RID: 852
		public new static readonly string labelUssClassName = LongField.ussClassName + "__label";

		// Token: 0x04000355 RID: 853
		public new static readonly string inputUssClassName = LongField.ussClassName + "__input";

		// Token: 0x020000E5 RID: 229
		public new class UxmlFactory : UxmlFactory<LongField, LongField.UxmlTraits>
		{
		}

		// Token: 0x020000E6 RID: 230
		public new class UxmlTraits : TextValueFieldTraits<long, UxmlLongAttributeDescription>
		{
		}

		// Token: 0x020000E7 RID: 231
		private class LongInput : TextValueField<long>.TextValueInput
		{
			// Token: 0x17000166 RID: 358
			// (get) Token: 0x060007C8 RID: 1992 RVA: 0x0001D8B5 File Offset: 0x0001BAB5
			private LongField parentLongField
			{
				get
				{
					return (LongField)base.parent;
				}
			}

			// Token: 0x060007C9 RID: 1993 RVA: 0x0001D8C2 File Offset: 0x0001BAC2
			internal LongInput()
			{
				base.formatString = UINumericFieldsUtils.k_IntFieldFormatString;
			}

			// Token: 0x17000167 RID: 359
			// (get) Token: 0x060007CA RID: 1994 RVA: 0x0001D8D8 File Offset: 0x0001BAD8
			protected override string allowedCharacters
			{
				get
				{
					return UINumericFieldsUtils.k_AllowedCharactersForInt;
				}
			}

			// Token: 0x060007CB RID: 1995 RVA: 0x0001D8F0 File Offset: 0x0001BAF0
			public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, long startValue)
			{
				double num = (double)NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
				float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
				long value = this.StringToValue(base.text);
				long niceDelta = (long)Math.Round((double)NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * num);
				value = this.ClampMinMaxLongValue(niceDelta, value);
				bool isDelayed = this.parentLongField.isDelayed;
				if (isDelayed)
				{
					base.text = this.ValueToString(value);
				}
				else
				{
					this.parentLongField.value = value;
				}
			}

			// Token: 0x060007CC RID: 1996 RVA: 0x0001D974 File Offset: 0x0001BB74
			private long ClampMinMaxLongValue(long niceDelta, long value)
			{
				long num = Math.Abs(niceDelta);
				bool flag = niceDelta > 0L;
				long result;
				if (flag)
				{
					bool flag2 = value > 0L && num > long.MaxValue - value;
					if (flag2)
					{
						result = long.MaxValue;
					}
					else
					{
						result = value + niceDelta;
					}
				}
				else
				{
					bool flag3 = value < 0L && value < long.MinValue + num;
					if (flag3)
					{
						result = long.MinValue;
					}
					else
					{
						result = value - num;
					}
				}
				return result;
			}

			// Token: 0x060007CD RID: 1997 RVA: 0x0001D9F0 File Offset: 0x0001BBF0
			protected override string ValueToString(long v)
			{
				return v.ToString(base.formatString);
			}

			// Token: 0x060007CE RID: 1998 RVA: 0x0001DA10 File Offset: 0x0001BC10
			protected override long StringToValue(string str)
			{
				long result;
				UINumericFieldsUtils.TryConvertStringToLong(str, base.originalText, out result);
				return result;
			}
		}
	}
}
