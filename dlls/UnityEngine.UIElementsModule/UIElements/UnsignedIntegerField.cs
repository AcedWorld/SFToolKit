using System;
using System.Globalization;

namespace UnityEngine.UIElements
{
	// Token: 0x02000148 RID: 328
	public class UnsignedIntegerField : TextValueField<uint>
	{
		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06000AC3 RID: 2755 RVA: 0x0002B98E File Offset: 0x00029B8E
		private UnsignedIntegerField.UnsignedIntegerInput integerInput
		{
			get
			{
				return (UnsignedIntegerField.UnsignedIntegerInput)base.textInputBase;
			}
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x0002B99C File Offset: 0x00029B9C
		protected override string ValueToString(uint v)
		{
			return v.ToString(base.formatString, CultureInfo.InvariantCulture.NumberFormat);
		}

		// Token: 0x06000AC5 RID: 2757 RVA: 0x0002B9C8 File Offset: 0x00029BC8
		protected override uint StringToValue(string str)
		{
			uint num;
			return UINumericFieldsUtils.TryConvertStringToUInt(str, base.textInputBase.originalText, out num) ? num : base.rawValue;
		}

		// Token: 0x06000AC6 RID: 2758 RVA: 0x0002B9FA File Offset: 0x00029BFA
		public UnsignedIntegerField() : this(null, 1000)
		{
		}

		// Token: 0x06000AC7 RID: 2759 RVA: 0x0002BA0A File Offset: 0x00029C0A
		public UnsignedIntegerField(int maxLength) : this(null, maxLength)
		{
		}

		// Token: 0x06000AC8 RID: 2760 RVA: 0x0002BA18 File Offset: 0x00029C18
		public UnsignedIntegerField(string label, int maxLength = 1000) : base(label, maxLength, new UnsignedIntegerField.UnsignedIntegerInput())
		{
			base.AddToClassList(UnsignedIntegerField.ussClassName);
			base.labelElement.AddToClassList(UnsignedIntegerField.labelUssClassName);
			base.visualInput.AddToClassList(UnsignedIntegerField.inputUssClassName);
			base.AddLabelDragger<uint>();
		}

		// Token: 0x06000AC9 RID: 2761 RVA: 0x0002BA6C File Offset: 0x00029C6C
		internal override bool CanTryParse(string textString)
		{
			uint num;
			return uint.TryParse(textString, out num);
		}

		// Token: 0x06000ACA RID: 2762 RVA: 0x0002BA81 File Offset: 0x00029C81
		public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, uint startValue)
		{
			this.integerInput.ApplyInputDeviceDelta(delta, speed, startValue);
		}

		// Token: 0x0400052C RID: 1324
		public new static readonly string ussClassName = "unity-unsigned-integer-field";

		// Token: 0x0400052D RID: 1325
		public new static readonly string labelUssClassName = UnsignedIntegerField.ussClassName + "__label";

		// Token: 0x0400052E RID: 1326
		public new static readonly string inputUssClassName = UnsignedIntegerField.ussClassName + "__input";

		// Token: 0x02000149 RID: 329
		public new class UxmlFactory : UxmlFactory<UnsignedIntegerField, UnsignedIntegerField.UxmlTraits>
		{
		}

		// Token: 0x0200014A RID: 330
		public new class UxmlTraits : TextValueFieldTraits<uint, UxmlUnsignedIntAttributeDescription>
		{
		}

		// Token: 0x0200014B RID: 331
		private class UnsignedIntegerInput : TextValueField<uint>.TextValueInput
		{
			// Token: 0x17000213 RID: 531
			// (get) Token: 0x06000ACE RID: 2766 RVA: 0x0002BAD9 File Offset: 0x00029CD9
			private UnsignedIntegerField parentUnsignedIntegerField
			{
				get
				{
					return (UnsignedIntegerField)base.parent;
				}
			}

			// Token: 0x06000ACF RID: 2767 RVA: 0x0002BAE6 File Offset: 0x00029CE6
			internal UnsignedIntegerInput()
			{
				base.formatString = UINumericFieldsUtils.k_IntFieldFormatString;
			}

			// Token: 0x17000214 RID: 532
			// (get) Token: 0x06000AD0 RID: 2768 RVA: 0x0001D51C File Offset: 0x0001B71C
			protected override string allowedCharacters
			{
				get
				{
					return UINumericFieldsUtils.k_AllowedCharactersForInt;
				}
			}

			// Token: 0x06000AD1 RID: 2769 RVA: 0x0002BAFC File Offset: 0x00029CFC
			public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, uint startValue)
			{
				double num = (double)NumericFieldDraggerUtility.CalculateIntDragSensitivity((long)((ulong)startValue));
				float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
				long num2 = (long)((ulong)this.StringToValue(base.text));
				num2 += (long)Math.Round((double)NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * num);
				bool isDelayed = this.parentUnsignedIntegerField.isDelayed;
				if (isDelayed)
				{
					base.text = this.ValueToString(Mathf.ClampToUInt(num2));
				}
				else
				{
					this.parentUnsignedIntegerField.value = Mathf.ClampToUInt(num2);
				}
			}

			// Token: 0x06000AD2 RID: 2770 RVA: 0x0002BB84 File Offset: 0x00029D84
			protected override string ValueToString(uint v)
			{
				return v.ToString(base.formatString);
			}

			// Token: 0x06000AD3 RID: 2771 RVA: 0x0002BBA4 File Offset: 0x00029DA4
			protected override uint StringToValue(string str)
			{
				uint result;
				UINumericFieldsUtils.TryConvertStringToUInt(str, base.originalText, out result);
				return result;
			}
		}
	}
}
