using System;
using System.Globalization;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.UIElements
{
	// Token: 0x020000DA RID: 218
	[MovedFrom(true, "UnityEditor.UIElements", "UnityEditor.UIElementsModule", null)]
	public class IntegerField : TextValueField<int>
	{
		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06000797 RID: 1943 RVA: 0x0001D3AF File Offset: 0x0001B5AF
		private IntegerField.IntegerInput integerInput
		{
			get
			{
				return (IntegerField.IntegerInput)base.textInputBase;
			}
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x0001D3BC File Offset: 0x0001B5BC
		protected override string ValueToString(int v)
		{
			return v.ToString(base.formatString, CultureInfo.InvariantCulture.NumberFormat);
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x0001D3E8 File Offset: 0x0001B5E8
		protected override int StringToValue(string str)
		{
			int num;
			return UINumericFieldsUtils.TryConvertStringToInt(str, base.textInputBase.originalText, out num) ? num : base.rawValue;
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x0001D41A File Offset: 0x0001B61A
		public IntegerField() : this(null, 1000)
		{
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x0001D42A File Offset: 0x0001B62A
		public IntegerField(int maxLength) : this(null, maxLength)
		{
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x0001D438 File Offset: 0x0001B638
		public IntegerField(string label, int maxLength = 1000) : base(label, maxLength, new IntegerField.IntegerInput())
		{
			base.AddToClassList(IntegerField.ussClassName);
			base.labelElement.AddToClassList(IntegerField.labelUssClassName);
			base.visualInput.AddToClassList(IntegerField.inputUssClassName);
			base.AddLabelDragger<int>();
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x0001D48C File Offset: 0x0001B68C
		internal override bool CanTryParse(string textString)
		{
			int num;
			return int.TryParse(textString, out num);
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x0001D4A1 File Offset: 0x0001B6A1
		public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, int startValue)
		{
			this.integerInput.ApplyInputDeviceDelta(delta, speed, startValue);
		}

		// Token: 0x0400034B RID: 843
		public new static readonly string ussClassName = "unity-integer-field";

		// Token: 0x0400034C RID: 844
		public new static readonly string labelUssClassName = IntegerField.ussClassName + "__label";

		// Token: 0x0400034D RID: 845
		public new static readonly string inputUssClassName = IntegerField.ussClassName + "__input";

		// Token: 0x020000DB RID: 219
		public new class UxmlFactory : UxmlFactory<IntegerField, IntegerField.UxmlTraits>
		{
		}

		// Token: 0x020000DC RID: 220
		public new class UxmlTraits : TextValueFieldTraits<int, UxmlIntAttributeDescription>
		{
		}

		// Token: 0x020000DD RID: 221
		private class IntegerInput : TextValueField<int>.TextValueInput
		{
			// Token: 0x1700015F RID: 351
			// (get) Token: 0x060007A2 RID: 1954 RVA: 0x0001D4F9 File Offset: 0x0001B6F9
			private IntegerField parentIntegerField
			{
				get
				{
					return (IntegerField)base.parent;
				}
			}

			// Token: 0x060007A3 RID: 1955 RVA: 0x0001D506 File Offset: 0x0001B706
			internal IntegerInput()
			{
				base.formatString = UINumericFieldsUtils.k_IntFieldFormatString;
			}

			// Token: 0x17000160 RID: 352
			// (get) Token: 0x060007A4 RID: 1956 RVA: 0x0001D51C File Offset: 0x0001B71C
			protected override string allowedCharacters
			{
				get
				{
					return UINumericFieldsUtils.k_AllowedCharactersForInt;
				}
			}

			// Token: 0x060007A5 RID: 1957 RVA: 0x0001D524 File Offset: 0x0001B724
			public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, int startValue)
			{
				double num = (double)NumericFieldDraggerUtility.CalculateIntDragSensitivity((long)startValue);
				float acceleration = NumericFieldDraggerUtility.Acceleration(speed == DeltaSpeed.Fast, speed == DeltaSpeed.Slow);
				long num2 = (long)this.StringToValue(base.text);
				num2 += (long)Math.Round((double)NumericFieldDraggerUtility.NiceDelta(delta, acceleration) * num);
				bool isDelayed = this.parentIntegerField.isDelayed;
				if (isDelayed)
				{
					base.text = this.ValueToString(Mathf.ClampToInt(num2));
				}
				else
				{
					this.parentIntegerField.value = Mathf.ClampToInt(num2);
				}
			}

			// Token: 0x060007A6 RID: 1958 RVA: 0x0001D5AC File Offset: 0x0001B7AC
			protected override string ValueToString(int v)
			{
				return v.ToString(base.formatString);
			}

			// Token: 0x060007A7 RID: 1959 RVA: 0x0001D5CC File Offset: 0x0001B7CC
			protected override int StringToValue(string str)
			{
				int result;
				UINumericFieldsUtils.TryConvertStringToInt(str, base.originalText, out result);
				return result;
			}
		}
	}
}
