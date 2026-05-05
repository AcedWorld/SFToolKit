using System;
using System.Globalization;

namespace UnityEngine.UIElements.StyleSheets
{
	// Token: 0x0200048A RID: 1162
	[Serializable]
	internal struct Dimension : IEquatable<Dimension>
	{
		// Token: 0x06002458 RID: 9304 RVA: 0x00097035 File Offset: 0x00095235
		public Dimension(float value, Dimension.Unit unit)
		{
			this.unit = unit;
			this.value = value;
		}

		// Token: 0x06002459 RID: 9305 RVA: 0x00097048 File Offset: 0x00095248
		public Length ToLength()
		{
			LengthUnit lengthUnit = (this.unit == Dimension.Unit.Percent) ? LengthUnit.Percent : LengthUnit.Pixel;
			return new Length(this.value, lengthUnit);
		}

		// Token: 0x0600245A RID: 9306 RVA: 0x00097074 File Offset: 0x00095274
		public TimeValue ToTime()
		{
			TimeUnit timeUnit = (this.unit == Dimension.Unit.Millisecond) ? TimeUnit.Millisecond : TimeUnit.Second;
			return new TimeValue(this.value, timeUnit);
		}

		// Token: 0x0600245B RID: 9307 RVA: 0x000970A0 File Offset: 0x000952A0
		public Angle ToAngle()
		{
			Angle result;
			switch (this.unit)
			{
			case Dimension.Unit.Degree:
				result = new Angle(this.value, AngleUnit.Degree);
				break;
			case Dimension.Unit.Gradian:
				result = new Angle(this.value, AngleUnit.Gradian);
				break;
			case Dimension.Unit.Radian:
				result = new Angle(this.value, AngleUnit.Radian);
				break;
			case Dimension.Unit.Turn:
				result = new Angle(this.value, AngleUnit.Turn);
				break;
			default:
				result = new Angle(this.value, AngleUnit.Degree);
				break;
			}
			return result;
		}

		// Token: 0x0600245C RID: 9308 RVA: 0x00097120 File Offset: 0x00095320
		public static bool operator ==(Dimension lhs, Dimension rhs)
		{
			return lhs.value == rhs.value && lhs.unit == rhs.unit;
		}

		// Token: 0x0600245D RID: 9309 RVA: 0x00097154 File Offset: 0x00095354
		public static bool operator !=(Dimension lhs, Dimension rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x0600245E RID: 9310 RVA: 0x00097170 File Offset: 0x00095370
		public bool Equals(Dimension other)
		{
			return other == this;
		}

		// Token: 0x0600245F RID: 9311 RVA: 0x00097190 File Offset: 0x00095390
		public override bool Equals(object obj)
		{
			bool flag = !(obj is Dimension);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				Dimension lhs = (Dimension)obj;
				result = (lhs == this);
			}
			return result;
		}

		// Token: 0x06002460 RID: 9312 RVA: 0x000971CC File Offset: 0x000953CC
		public override int GetHashCode()
		{
			int num = -799583767;
			num = num * -1521134295 + this.unit.GetHashCode();
			return num * -1521134295 + this.value.GetHashCode();
		}

		// Token: 0x06002461 RID: 9313 RVA: 0x00097214 File Offset: 0x00095414
		public override string ToString()
		{
			string str = string.Empty;
			switch (this.unit)
			{
			case Dimension.Unit.Unitless:
				str = string.Empty;
				break;
			case Dimension.Unit.Pixel:
				str = "px";
				break;
			case Dimension.Unit.Percent:
				str = "%";
				break;
			case Dimension.Unit.Second:
				str = "s";
				break;
			case Dimension.Unit.Millisecond:
				str = "ms";
				break;
			case Dimension.Unit.Degree:
				str = "deg";
				break;
			case Dimension.Unit.Gradian:
				str = "grad";
				break;
			case Dimension.Unit.Radian:
				str = "rad";
				break;
			case Dimension.Unit.Turn:
				str = "turn";
				break;
			}
			return this.value.ToString(CultureInfo.InvariantCulture.NumberFormat) + str;
		}

		// Token: 0x0400116D RID: 4461
		public Dimension.Unit unit;

		// Token: 0x0400116E RID: 4462
		public float value;

		// Token: 0x0200048B RID: 1163
		public enum Unit
		{
			// Token: 0x04001170 RID: 4464
			Unitless,
			// Token: 0x04001171 RID: 4465
			Pixel,
			// Token: 0x04001172 RID: 4466
			Percent,
			// Token: 0x04001173 RID: 4467
			Second,
			// Token: 0x04001174 RID: 4468
			Millisecond,
			// Token: 0x04001175 RID: 4469
			Degree,
			// Token: 0x04001176 RID: 4470
			Gradian,
			// Token: 0x04001177 RID: 4471
			Radian,
			// Token: 0x04001178 RID: 4472
			Turn
		}
	}
}
