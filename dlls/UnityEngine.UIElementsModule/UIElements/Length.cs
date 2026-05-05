using System;
using System.Globalization;

namespace UnityEngine.UIElements
{
	// Token: 0x020002F5 RID: 757
	[Serializable]
	public struct Length : IEquatable<Length>
	{
		// Token: 0x0600199D RID: 6557 RVA: 0x00067888 File Offset: 0x00065A88
		public static Length Percent(float value)
		{
			return new Length(value, LengthUnit.Percent);
		}

		// Token: 0x0600199E RID: 6558 RVA: 0x000678A4 File Offset: 0x00065AA4
		public static Length Auto()
		{
			return new Length(0f, Length.Unit.Auto);
		}

		// Token: 0x0600199F RID: 6559 RVA: 0x000678C4 File Offset: 0x00065AC4
		public static Length None()
		{
			return new Length(0f, Length.Unit.None);
		}

		// Token: 0x17000653 RID: 1619
		// (get) Token: 0x060019A0 RID: 6560 RVA: 0x000678E1 File Offset: 0x00065AE1
		// (set) Token: 0x060019A1 RID: 6561 RVA: 0x000678E9 File Offset: 0x00065AE9
		public float value
		{
			get
			{
				return this.m_Value;
			}
			set
			{
				this.m_Value = Mathf.Clamp(value, -8388608f, 8388608f);
			}
		}

		// Token: 0x17000654 RID: 1620
		// (get) Token: 0x060019A2 RID: 6562 RVA: 0x00067901 File Offset: 0x00065B01
		// (set) Token: 0x060019A3 RID: 6563 RVA: 0x00067909 File Offset: 0x00065B09
		public LengthUnit unit
		{
			get
			{
				return (LengthUnit)this.m_Unit;
			}
			set
			{
				this.m_Unit = (Length.Unit)value;
			}
		}

		// Token: 0x060019A4 RID: 6564 RVA: 0x00067912 File Offset: 0x00065B12
		public bool IsAuto()
		{
			return this.m_Unit == Length.Unit.Auto;
		}

		// Token: 0x060019A5 RID: 6565 RVA: 0x0006791D File Offset: 0x00065B1D
		public bool IsNone()
		{
			return this.m_Unit == Length.Unit.None;
		}

		// Token: 0x060019A6 RID: 6566 RVA: 0x00067928 File Offset: 0x00065B28
		public Length(float value)
		{
			this = new Length(value, Length.Unit.Pixel);
		}

		// Token: 0x060019A7 RID: 6567 RVA: 0x00067934 File Offset: 0x00065B34
		public Length(float value, LengthUnit unit)
		{
			this = new Length(value, (Length.Unit)unit);
		}

		// Token: 0x060019A8 RID: 6568 RVA: 0x00067940 File Offset: 0x00065B40
		private Length(float value, Length.Unit unit)
		{
			this = default(Length);
			this.value = value;
			this.m_Unit = unit;
		}

		// Token: 0x060019A9 RID: 6569 RVA: 0x0006795C File Offset: 0x00065B5C
		public static implicit operator Length(float value)
		{
			return new Length(value, LengthUnit.Pixel);
		}

		// Token: 0x060019AA RID: 6570 RVA: 0x00067978 File Offset: 0x00065B78
		public static bool operator ==(Length lhs, Length rhs)
		{
			return lhs.m_Value == rhs.m_Value && lhs.m_Unit == rhs.m_Unit;
		}

		// Token: 0x060019AB RID: 6571 RVA: 0x000679AC File Offset: 0x00065BAC
		public static bool operator !=(Length lhs, Length rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x060019AC RID: 6572 RVA: 0x000679C8 File Offset: 0x00065BC8
		public bool Equals(Length other)
		{
			return other == this;
		}

		// Token: 0x060019AD RID: 6573 RVA: 0x000679E8 File Offset: 0x00065BE8
		public override bool Equals(object obj)
		{
			bool result;
			if (obj is Length)
			{
				Length other = (Length)obj;
				result = this.Equals(other);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060019AE RID: 6574 RVA: 0x00067A14 File Offset: 0x00065C14
		public override int GetHashCode()
		{
			return this.m_Value.GetHashCode() * 397 ^ (int)this.m_Unit;
		}

		// Token: 0x060019AF RID: 6575 RVA: 0x00067A40 File Offset: 0x00065C40
		public override string ToString()
		{
			string str = this.value.ToString(CultureInfo.InvariantCulture.NumberFormat);
			string str2 = string.Empty;
			switch (this.m_Unit)
			{
			case Length.Unit.Pixel:
			{
				bool flag = !Mathf.Approximately(0f, this.value);
				if (flag)
				{
					str2 = "px";
				}
				break;
			}
			case Length.Unit.Percent:
				str2 = "%";
				break;
			case Length.Unit.Auto:
				str = "auto";
				break;
			case Length.Unit.None:
				str = "none";
				break;
			}
			return str + str2;
		}

		// Token: 0x04000AC6 RID: 2758
		internal const float k_MaxValue = 8388608f;

		// Token: 0x04000AC7 RID: 2759
		[SerializeField]
		private float m_Value;

		// Token: 0x04000AC8 RID: 2760
		[SerializeField]
		private Length.Unit m_Unit;

		// Token: 0x020002F6 RID: 758
		private enum Unit
		{
			// Token: 0x04000ACA RID: 2762
			Pixel,
			// Token: 0x04000ACB RID: 2763
			Percent,
			// Token: 0x04000ACC RID: 2764
			Auto,
			// Token: 0x04000ACD RID: 2765
			None
		}
	}
}
