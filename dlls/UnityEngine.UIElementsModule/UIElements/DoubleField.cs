using System;
using System.Globalization;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.UIElements
{
	// Token: 0x020000A1 RID: 161
	[MovedFrom(true, "UnityEditor.UIElements", "UnityEditor.UIElementsModule", null)]
	public class DoubleField : TextValueField<double>
	{
		// Token: 0x170000FA RID: 250
		// (get) Token: 0x060005E6 RID: 1510 RVA: 0x000166BE File Offset: 0x000148BE
		private DoubleField.DoubleInput doubleInput
		{
			get
			{
				return (DoubleField.DoubleInput)base.textInputBase;
			}
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x000166CC File Offset: 0x000148CC
		protected override string ValueToString(double v)
		{
			return v.ToString(base.formatString, CultureInfo.InvariantCulture.NumberFormat);
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x000166F8 File Offset: 0x000148F8
		protected override double StringToValue(string str)
		{
			double num;
			return UINumericFieldsUtils.TryConvertStringToDouble(str, base.textInputBase.originalText, out num) ? num : base.rawValue;
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x0001672A File Offset: 0x0001492A
		public DoubleField() : this(null, 1000)
		{
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x0001673A File Offset: 0x0001493A
		public DoubleField(int maxLength) : this(null, maxLength)
		{
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x00016748 File Offset: 0x00014948
		public DoubleField(string label, int maxLength = 1000) : base(label, maxLength, new DoubleField.DoubleInput())
		{
			base.AddToClassList(DoubleField.ussClassName);
			base.labelElement.AddToClassList(DoubleField.labelUssClassName);
			base.visualInput.AddToClassList(DoubleField.inputUssClassName);
			base.AddLabelDragger<double>();
		}

		// Token: 0x060005EC RID: 1516 RVA: 0x0001679C File Offset: 0x0001499C
		internal override bool CanTryParse(string textString)
		{
			double num;
			return double.TryParse(textString, out num);
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x000167B1 File Offset: 0x000149B1
		public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, double startValue)
		{
			this.doubleInput.ApplyInputDeviceDelta(delta, speed, startValue);
		}

		// Token: 0x04000287 RID: 647
		public new static readonly string ussClassName = "unity-double-field";

		// Token: 0x04000288 RID: 648
		public new static readonly string labelUssClassName = DoubleField.ussClassName + "__label";

		// Token: 0x04000289 RID: 649
		public new static readonly string inputUssClassName = DoubleField.ussClassName + "__input";

		// Token: 0x020000A2 RID: 162
		public new class UxmlFactory : UxmlFactory<DoubleField, DoubleField.UxmlTraits>
		{
		}

		// Token: 0x020000A3 RID: 163
		public new class UxmlTraits : TextValueFieldTraits<double, UxmlDoubleAttributeDescription>
		{
		}

		// Token: 0x020000A4 RID: 164
		private class DoubleInput : TextValueField<double>.TextValueInput
		{
			// Token: 0x170000FB RID: 251
			// (get) Token: 0x060005F1 RID: 1521 RVA: 0x00016809 File Offset: 0x00014A09
			private DoubleField parentDoubleField
			{
				get
				{
					return (DoubleField)base.parent;
				}
			}

			// Token: 0x060005F2 RID: 1522 RVA: 0x00016816 File Offset: 0x00014A16
			internal DoubleInput()
			{
				base.formatString = UINumericFieldsUtils.k_DoubleFieldFormatString;
			}

			// Token: 0x170000FC RID: 252
			// (get) Token: 0x060005F3 RID: 1523 RVA: 0x0001682C File Offset: 0x00014A2C
			protected override string allowedCharacters
			{
				get
				{
					return UINumericFieldsUtils.k_AllowedCharactersForFloat;
				}
			}

			// Token: 0x060005F4 RID: 1524 RVA: 0x00016834 File Offset: 0x00014A34
			public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, double startValue)
			{
				double num = NumericFieldDraggerUtility.CalculateFloatDragSensitivity(startValue);
				float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
				double num2 = this.StringToValue(base.text);
				num2 += (double)NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * num;
				num2 = Mathf.RoundBasedOnMinimumDifference(num2, num);
				bool isDelayed = this.parentDoubleField.isDelayed;
				if (isDelayed)
				{
					base.text = this.ValueToString(num2);
				}
				else
				{
					this.parentDoubleField.value = num2;
				}
			}

			// Token: 0x060005F5 RID: 1525 RVA: 0x000168B0 File Offset: 0x00014AB0
			protected override string ValueToString(double v)
			{
				return v.ToString(base.formatString);
			}

			// Token: 0x060005F6 RID: 1526 RVA: 0x000168D0 File Offset: 0x00014AD0
			protected override double StringToValue(string str)
			{
				double result;
				UINumericFieldsUtils.TryConvertStringToDouble(str, base.originalText, out result);
				return result;
			}
		}
	}
}
