using System;
using System.Globalization;

namespace UnityEngine.UIElements
{
	// Token: 0x0200014C RID: 332
	public class UnsignedLongField : TextValueField<ulong>
	{
		// Token: 0x17000215 RID: 533
		// (get) Token: 0x06000AD4 RID: 2772 RVA: 0x0002BBC6 File Offset: 0x00029DC6
		private UnsignedLongField.UnsignedLongInput unsignedLongInput
		{
			get
			{
				return (UnsignedLongField.UnsignedLongInput)base.textInputBase;
			}
		}

		// Token: 0x06000AD5 RID: 2773 RVA: 0x0002BBD4 File Offset: 0x00029DD4
		protected override string ValueToString(ulong v)
		{
			return v.ToString(base.formatString, CultureInfo.InvariantCulture.NumberFormat);
		}

		// Token: 0x06000AD6 RID: 2774 RVA: 0x0002BC00 File Offset: 0x00029E00
		protected override ulong StringToValue(string str)
		{
			ulong num;
			return UINumericFieldsUtils.TryConvertStringToULong(str, base.textInputBase.originalText, out num) ? num : base.rawValue;
		}

		// Token: 0x06000AD7 RID: 2775 RVA: 0x0002BC32 File Offset: 0x00029E32
		public UnsignedLongField() : this(null, 1000)
		{
		}

		// Token: 0x06000AD8 RID: 2776 RVA: 0x0002BC42 File Offset: 0x00029E42
		public UnsignedLongField(int maxLength) : this(null, maxLength)
		{
		}

		// Token: 0x06000AD9 RID: 2777 RVA: 0x0002BC50 File Offset: 0x00029E50
		public UnsignedLongField(string label, int maxLength = 1000) : base(label, maxLength, new UnsignedLongField.UnsignedLongInput())
		{
			base.AddToClassList(UnsignedLongField.ussClassName);
			base.labelElement.AddToClassList(UnsignedLongField.labelUssClassName);
			base.visualInput.AddToClassList(UnsignedLongField.inputUssClassName);
			base.AddLabelDragger<ulong>();
		}

		// Token: 0x06000ADA RID: 2778 RVA: 0x0002BCA4 File Offset: 0x00029EA4
		internal override bool CanTryParse(string textString)
		{
			ulong num;
			return ulong.TryParse(textString, out num);
		}

		// Token: 0x06000ADB RID: 2779 RVA: 0x0002BCB9 File Offset: 0x00029EB9
		public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, ulong startValue)
		{
			this.unsignedLongInput.ApplyInputDeviceDelta(delta, speed, startValue);
		}

		// Token: 0x0400052F RID: 1327
		public new static readonly string ussClassName = "unity-unsigned-long-field";

		// Token: 0x04000530 RID: 1328
		public new static readonly string labelUssClassName = UnsignedLongField.ussClassName + "__label";

		// Token: 0x04000531 RID: 1329
		public new static readonly string inputUssClassName = UnsignedLongField.ussClassName + "__input";

		// Token: 0x0200014D RID: 333
		public new class UxmlFactory : UxmlFactory<UnsignedLongField, UnsignedLongField.UxmlTraits>
		{
		}

		// Token: 0x0200014E RID: 334
		public new class UxmlTraits : TextValueFieldTraits<ulong, UxmlUnsignedLongAttributeDescription>
		{
		}

		// Token: 0x0200014F RID: 335
		private class UnsignedLongInput : TextValueField<ulong>.TextValueInput
		{
			// Token: 0x17000216 RID: 534
			// (get) Token: 0x06000ADF RID: 2783 RVA: 0x0002BD11 File Offset: 0x00029F11
			private UnsignedLongField parentUnsignedLongField
			{
				get
				{
					return (UnsignedLongField)base.parent;
				}
			}

			// Token: 0x06000AE0 RID: 2784 RVA: 0x0002BD1E File Offset: 0x00029F1E
			internal UnsignedLongInput()
			{
				base.formatString = UINumericFieldsUtils.k_IntFieldFormatString;
			}

			// Token: 0x17000217 RID: 535
			// (get) Token: 0x06000AE1 RID: 2785 RVA: 0x0001D51C File Offset: 0x0001B71C
			protected override string allowedCharacters
			{
				get
				{
					return UINumericFieldsUtils.k_AllowedCharactersForInt;
				}
			}

			// Token: 0x06000AE2 RID: 2786 RVA: 0x0002BD34 File Offset: 0x00029F34
			public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, ulong startValue)
			{
				double num = NumericFieldDraggerUtility.CalculateIntDragSensitivity(startValue);
				float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
				ulong value = this.StringToValue(base.text);
				long niceDelta = (long)Math.Round((double)NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * num);
				value = this.ClampToMinMaxULongValue(niceDelta, value);
				bool isDelayed = this.parentUnsignedLongField.isDelayed;
				if (isDelayed)
				{
					base.text = this.ValueToString(value);
				}
				else
				{
					this.parentUnsignedLongField.value = value;
				}
			}

			// Token: 0x06000AE3 RID: 2787 RVA: 0x0002BDB8 File Offset: 0x00029FB8
			private ulong ClampToMinMaxULongValue(long niceDelta, ulong value)
			{
				ulong num = (ulong)Math.Abs(niceDelta);
				bool flag = niceDelta > 0L;
				ulong result;
				if (flag)
				{
					bool flag2 = num > ulong.MaxValue - value;
					if (flag2)
					{
						result = ulong.MaxValue;
					}
					else
					{
						result = value + num;
					}
				}
				else
				{
					bool flag3 = num > value;
					if (flag3)
					{
						result = 0UL;
					}
					else
					{
						result = value - num;
					}
				}
				return result;
			}

			// Token: 0x06000AE4 RID: 2788 RVA: 0x0002BE08 File Offset: 0x0002A008
			protected override string ValueToString(ulong v)
			{
				return v.ToString(base.formatString);
			}

			// Token: 0x06000AE5 RID: 2789 RVA: 0x0002BE28 File Offset: 0x0002A028
			protected override ulong StringToValue(string str)
			{
				ulong result;
				UINumericFieldsUtils.TryConvertStringToULong(str, base.originalText, out result);
				return result;
			}
		}
	}
}
