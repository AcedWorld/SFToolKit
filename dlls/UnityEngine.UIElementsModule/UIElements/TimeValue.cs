using System;
using System.Globalization;

namespace UnityEngine.UIElements
{
	// Token: 0x02000311 RID: 785
	public struct TimeValue : IEquatable<TimeValue>
	{
		// Token: 0x17000682 RID: 1666
		// (get) Token: 0x06001B11 RID: 6929 RVA: 0x0006A744 File Offset: 0x00068944
		// (set) Token: 0x06001B12 RID: 6930 RVA: 0x0006A74C File Offset: 0x0006894C
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

		// Token: 0x17000683 RID: 1667
		// (get) Token: 0x06001B13 RID: 6931 RVA: 0x0006A755 File Offset: 0x00068955
		// (set) Token: 0x06001B14 RID: 6932 RVA: 0x0006A75D File Offset: 0x0006895D
		public TimeUnit unit
		{
			get
			{
				return this.m_Unit;
			}
			set
			{
				this.m_Unit = value;
			}
		}

		// Token: 0x06001B15 RID: 6933 RVA: 0x0006A766 File Offset: 0x00068966
		public TimeValue(float value)
		{
			this = new TimeValue(value, TimeUnit.Second);
		}

		// Token: 0x06001B16 RID: 6934 RVA: 0x0006A772 File Offset: 0x00068972
		public TimeValue(float value, TimeUnit unit)
		{
			this.m_Value = value;
			this.m_Unit = unit;
		}

		// Token: 0x06001B17 RID: 6935 RVA: 0x0006A784 File Offset: 0x00068984
		public static implicit operator TimeValue(float value)
		{
			return new TimeValue(value, TimeUnit.Second);
		}

		// Token: 0x06001B18 RID: 6936 RVA: 0x0006A7A0 File Offset: 0x000689A0
		public static bool operator ==(TimeValue lhs, TimeValue rhs)
		{
			return lhs.m_Value == rhs.m_Value && lhs.m_Unit == rhs.m_Unit;
		}

		// Token: 0x06001B19 RID: 6937 RVA: 0x0006A7D4 File Offset: 0x000689D4
		public static bool operator !=(TimeValue lhs, TimeValue rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06001B1A RID: 6938 RVA: 0x0006A7F0 File Offset: 0x000689F0
		public bool Equals(TimeValue other)
		{
			return other == this;
		}

		// Token: 0x06001B1B RID: 6939 RVA: 0x0006A810 File Offset: 0x00068A10
		public override bool Equals(object obj)
		{
			bool result;
			if (obj is TimeValue)
			{
				TimeValue other = (TimeValue)obj;
				result = this.Equals(other);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001B1C RID: 6940 RVA: 0x0006A83C File Offset: 0x00068A3C
		public override int GetHashCode()
		{
			return this.m_Value.GetHashCode() * 397 ^ (int)this.m_Unit;
		}

		// Token: 0x06001B1D RID: 6941 RVA: 0x0006A868 File Offset: 0x00068A68
		public override string ToString()
		{
			string str = this.value.ToString(CultureInfo.InvariantCulture.NumberFormat);
			string str2 = string.Empty;
			TimeUnit unit = this.unit;
			TimeUnit timeUnit = unit;
			if (timeUnit != TimeUnit.Second)
			{
				if (timeUnit == TimeUnit.Millisecond)
				{
					str2 = "ms";
				}
			}
			else
			{
				str2 = "s";
			}
			return str + str2;
		}

		// Token: 0x04000B05 RID: 2821
		private float m_Value;

		// Token: 0x04000B06 RID: 2822
		private TimeUnit m_Unit;
	}
}
