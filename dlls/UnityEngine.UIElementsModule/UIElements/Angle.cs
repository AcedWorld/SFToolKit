using System;
using System.Globalization;

namespace UnityEngine.UIElements
{
	// Token: 0x020002C3 RID: 707
	public struct Angle : IEquatable<Angle>
	{
		// Token: 0x06001468 RID: 5224 RVA: 0x00048B44 File Offset: 0x00046D44
		public static Angle Degrees(float value)
		{
			return new Angle(value, AngleUnit.Degree);
		}

		// Token: 0x06001469 RID: 5225 RVA: 0x00048B60 File Offset: 0x00046D60
		public static Angle Gradians(float value)
		{
			return new Angle(value, AngleUnit.Gradian);
		}

		// Token: 0x0600146A RID: 5226 RVA: 0x00048B7C File Offset: 0x00046D7C
		public static Angle Radians(float value)
		{
			return new Angle(value, AngleUnit.Radian);
		}

		// Token: 0x0600146B RID: 5227 RVA: 0x00048B98 File Offset: 0x00046D98
		public static Angle Turns(float value)
		{
			return new Angle(value, AngleUnit.Turn);
		}

		// Token: 0x0600146C RID: 5228 RVA: 0x00048BB4 File Offset: 0x00046DB4
		internal static Angle None()
		{
			return new Angle(0f, Angle.Unit.None);
		}

		// Token: 0x17000443 RID: 1091
		// (get) Token: 0x0600146D RID: 5229 RVA: 0x00048BD1 File Offset: 0x00046DD1
		// (set) Token: 0x0600146E RID: 5230 RVA: 0x00048BD9 File Offset: 0x00046DD9
		public float value
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

		// Token: 0x17000444 RID: 1092
		// (get) Token: 0x0600146F RID: 5231 RVA: 0x00048BE2 File Offset: 0x00046DE2
		// (set) Token: 0x06001470 RID: 5232 RVA: 0x00048BEA File Offset: 0x00046DEA
		public AngleUnit unit
		{
			get
			{
				return (AngleUnit)this.m_Unit;
			}
			set
			{
				this.m_Unit = (Angle.Unit)value;
			}
		}

		// Token: 0x06001471 RID: 5233 RVA: 0x00048BF3 File Offset: 0x00046DF3
		internal bool IsNone()
		{
			return this.m_Unit == Angle.Unit.None;
		}

		// Token: 0x06001472 RID: 5234 RVA: 0x00048BFE File Offset: 0x00046DFE
		public Angle(float value)
		{
			this = new Angle(value, Angle.Unit.Degree);
		}

		// Token: 0x06001473 RID: 5235 RVA: 0x00048C0A File Offset: 0x00046E0A
		public Angle(float value, AngleUnit unit)
		{
			this = new Angle(value, (Angle.Unit)unit);
		}

		// Token: 0x06001474 RID: 5236 RVA: 0x00048C16 File Offset: 0x00046E16
		private Angle(float value, Angle.Unit unit)
		{
			this.m_Value = value;
			this.m_Unit = unit;
		}

		// Token: 0x06001475 RID: 5237 RVA: 0x00048C28 File Offset: 0x00046E28
		public float ToDegrees()
		{
			float result;
			switch (this.m_Unit)
			{
			case Angle.Unit.Degree:
				result = this.m_Value;
				break;
			case Angle.Unit.Gradian:
				result = this.m_Value * 360f / 400f;
				break;
			case Angle.Unit.Radian:
				result = this.m_Value * 180f / 3.1415927f;
				break;
			case Angle.Unit.Turn:
				result = this.m_Value * 360f;
				break;
			case Angle.Unit.None:
				result = 0f;
				break;
			default:
				result = 0f;
				break;
			}
			return result;
		}

		// Token: 0x06001476 RID: 5238 RVA: 0x00048CB0 File Offset: 0x00046EB0
		public float ToGradians()
		{
			float result;
			switch (this.m_Unit)
			{
			case Angle.Unit.Degree:
				result = this.m_Value * 10f / 9f;
				break;
			case Angle.Unit.Gradian:
				result = this.m_Value;
				break;
			case Angle.Unit.Radian:
				result = this.m_Value * 200f / 3.1415927f;
				break;
			case Angle.Unit.Turn:
				result = this.m_Value * 400f;
				break;
			case Angle.Unit.None:
				result = 0f;
				break;
			default:
				result = 0f;
				break;
			}
			return result;
		}

		// Token: 0x06001477 RID: 5239 RVA: 0x00048D38 File Offset: 0x00046F38
		public float ToRadians()
		{
			float result;
			switch (this.m_Unit)
			{
			case Angle.Unit.Degree:
				result = this.m_Value * 3.1415927f / 180f;
				break;
			case Angle.Unit.Gradian:
				result = this.m_Value * 3.1415927f / 200f;
				break;
			case Angle.Unit.Radian:
				result = this.m_Value;
				break;
			case Angle.Unit.Turn:
				result = this.m_Value * 3.1415927f * 2f;
				break;
			case Angle.Unit.None:
				result = 0f;
				break;
			default:
				result = 0f;
				break;
			}
			return result;
		}

		// Token: 0x06001478 RID: 5240 RVA: 0x00048DC4 File Offset: 0x00046FC4
		public float ToTurns()
		{
			float result;
			switch (this.m_Unit)
			{
			case Angle.Unit.Degree:
				result = this.m_Value / 360f;
				break;
			case Angle.Unit.Gradian:
				result = this.m_Value / 400f;
				break;
			case Angle.Unit.Radian:
				result = this.m_Value / 6.2831855f;
				break;
			case Angle.Unit.Turn:
				result = this.m_Value;
				break;
			case Angle.Unit.None:
				result = 0f;
				break;
			default:
				result = 0f;
				break;
			}
			return result;
		}

		// Token: 0x06001479 RID: 5241 RVA: 0x00048E40 File Offset: 0x00047040
		internal void ConvertTo(AngleUnit newUnit)
		{
			if (!true)
			{
			}
			float value;
			switch (newUnit)
			{
			case AngleUnit.Degree:
				value = this.ToDegrees();
				break;
			case AngleUnit.Gradian:
				value = this.ToGradians();
				break;
			case AngleUnit.Radian:
				value = this.ToRadians();
				break;
			case AngleUnit.Turn:
				value = this.ToTurns();
				break;
			default:
				throw new NotImplementedException();
			}
			if (!true)
			{
			}
			this.m_Value = value;
			this.m_Unit = (Angle.Unit)newUnit;
		}

		// Token: 0x0600147A RID: 5242 RVA: 0x00048EA8 File Offset: 0x000470A8
		public static implicit operator Angle(float value)
		{
			return new Angle(value, AngleUnit.Degree);
		}

		// Token: 0x0600147B RID: 5243 RVA: 0x00048EC4 File Offset: 0x000470C4
		public static bool operator ==(Angle lhs, Angle rhs)
		{
			return lhs.m_Value == rhs.m_Value && lhs.m_Unit == rhs.m_Unit;
		}

		// Token: 0x0600147C RID: 5244 RVA: 0x00048EF8 File Offset: 0x000470F8
		public static bool operator !=(Angle lhs, Angle rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x0600147D RID: 5245 RVA: 0x00048F14 File Offset: 0x00047114
		public bool Equals(Angle other)
		{
			return other == this;
		}

		// Token: 0x0600147E RID: 5246 RVA: 0x00048F34 File Offset: 0x00047134
		public override bool Equals(object obj)
		{
			bool result;
			if (obj is Angle)
			{
				Angle other = (Angle)obj;
				result = this.Equals(other);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600147F RID: 5247 RVA: 0x00048F60 File Offset: 0x00047160
		public override int GetHashCode()
		{
			return this.m_Value.GetHashCode() * 397 ^ (int)this.m_Unit;
		}

		// Token: 0x06001480 RID: 5248 RVA: 0x00048F8C File Offset: 0x0004718C
		public override string ToString()
		{
			string str = this.value.ToString(CultureInfo.InvariantCulture.NumberFormat);
			string str2 = string.Empty;
			switch (this.m_Unit)
			{
			case Angle.Unit.Degree:
			{
				bool flag = !Mathf.Approximately(0f, this.value);
				if (flag)
				{
					str2 = "deg";
				}
				break;
			}
			case Angle.Unit.Gradian:
				str2 = "grad";
				break;
			case Angle.Unit.Radian:
				str2 = "rad";
				break;
			case Angle.Unit.Turn:
				str2 = "turn";
				break;
			case Angle.Unit.None:
				str = "";
				break;
			}
			return str + str2;
		}

		// Token: 0x04000981 RID: 2433
		private float m_Value;

		// Token: 0x04000982 RID: 2434
		private Angle.Unit m_Unit;

		// Token: 0x020002C4 RID: 708
		private enum Unit
		{
			// Token: 0x04000984 RID: 2436
			Degree,
			// Token: 0x04000985 RID: 2437
			Gradian,
			// Token: 0x04000986 RID: 2438
			Radian,
			// Token: 0x04000987 RID: 2439
			Turn,
			// Token: 0x04000988 RID: 2440
			None
		}
	}
}
