using System;
using System.Globalization;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.UIElements
{
	// Token: 0x020000AD RID: 173
	[MovedFrom(true, "UnityEditor.UIElements", "UnityEditor.UIElementsModule", null)]
	public class FloatField : TextValueField<float>
	{
		// Token: 0x17000100 RID: 256
		// (get) Token: 0x0600061E RID: 1566 RVA: 0x0001717A File Offset: 0x0001537A
		private FloatField.FloatInput floatInput
		{
			get
			{
				return (FloatField.FloatInput)base.textInputBase;
			}
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x00017188 File Offset: 0x00015388
		protected override string ValueToString(float v)
		{
			return v.ToString(base.formatString, CultureInfo.InvariantCulture.NumberFormat);
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x000171B4 File Offset: 0x000153B4
		protected override float StringToValue(string str)
		{
			float num;
			return UINumericFieldsUtils.TryConvertStringToFloat(str, base.textInputBase.originalText, out num) ? num : base.rawValue;
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x000171E6 File Offset: 0x000153E6
		public FloatField() : this(null, 1000)
		{
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x000171F6 File Offset: 0x000153F6
		public FloatField(int maxLength) : this(null, maxLength)
		{
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x00017204 File Offset: 0x00015404
		public FloatField(string label, int maxLength = 1000) : base(label, maxLength, new FloatField.FloatInput())
		{
			base.AddToClassList(FloatField.ussClassName);
			base.labelElement.AddToClassList(FloatField.labelUssClassName);
			base.visualInput.AddToClassList(FloatField.inputUssClassName);
			base.AddLabelDragger<float>();
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x00017258 File Offset: 0x00015458
		internal override bool CanTryParse(string textString)
		{
			float num;
			return float.TryParse(textString, out num);
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x0001726D File Offset: 0x0001546D
		public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, float startValue)
		{
			this.floatInput.ApplyInputDeviceDelta(delta, speed, startValue);
		}

		// Token: 0x0400029F RID: 671
		public new static readonly string ussClassName = "unity-float-field";

		// Token: 0x040002A0 RID: 672
		public new static readonly string labelUssClassName = FloatField.ussClassName + "__label";

		// Token: 0x040002A1 RID: 673
		public new static readonly string inputUssClassName = FloatField.ussClassName + "__input";

		// Token: 0x020000AE RID: 174
		public new class UxmlFactory : UxmlFactory<FloatField, FloatField.UxmlTraits>
		{
		}

		// Token: 0x020000AF RID: 175
		public new class UxmlTraits : TextValueFieldTraits<float, UxmlFloatAttributeDescription>
		{
		}

		// Token: 0x020000B0 RID: 176
		private class FloatInput : TextValueField<float>.TextValueInput
		{
			// Token: 0x17000101 RID: 257
			// (get) Token: 0x06000629 RID: 1577 RVA: 0x000172C5 File Offset: 0x000154C5
			private FloatField parentFloatField
			{
				get
				{
					return (FloatField)base.parent;
				}
			}

			// Token: 0x0600062A RID: 1578 RVA: 0x000172D2 File Offset: 0x000154D2
			internal FloatInput()
			{
				base.formatString = UINumericFieldsUtils.k_FloatFieldFormatString;
			}

			// Token: 0x17000102 RID: 258
			// (get) Token: 0x0600062B RID: 1579 RVA: 0x0001682C File Offset: 0x00014A2C
			protected override string allowedCharacters
			{
				get
				{
					return UINumericFieldsUtils.k_AllowedCharactersForFloat;
				}
			}

			// Token: 0x0600062C RID: 1580 RVA: 0x000172E8 File Offset: 0x000154E8
			public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, float startValue)
			{
				double num = NumericFieldDraggerUtility.CalculateFloatDragSensitivity((double)startValue);
				float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
				double num2 = (double)this.StringToValue(base.text);
				num2 += (double)NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * num;
				num2 = Mathf.RoundBasedOnMinimumDifference(num2, num);
				bool isDelayed = this.parentFloatField.isDelayed;
				if (isDelayed)
				{
					base.text = this.ValueToString(Mathf.ClampToFloat(num2));
				}
				else
				{
					this.parentFloatField.value = Mathf.ClampToFloat(num2);
				}
			}

			// Token: 0x0600062D RID: 1581 RVA: 0x00017370 File Offset: 0x00015570
			protected override string ValueToString(float v)
			{
				return v.ToString(base.formatString);
			}

			// Token: 0x0600062E RID: 1582 RVA: 0x00017390 File Offset: 0x00015590
			protected override float StringToValue(string str)
			{
				float result;
				UINumericFieldsUtils.TryConvertStringToFloat(str, base.originalText, out result);
				return result;
			}
		}
	}
}
