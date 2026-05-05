using System;
using Unity.Collections.LowLevel.Unsafe;

namespace UnityEngine.UIElements
{
	// Token: 0x02000301 RID: 769
	public struct StyleEnum<T> : IStyleValue<T>, IEquatable<StyleEnum<T>> where T : struct, IConvertible
	{
		// Token: 0x17000668 RID: 1640
		// (get) Token: 0x06001A46 RID: 6726 RVA: 0x00068CBC File Offset: 0x00066EBC
		// (set) Token: 0x06001A47 RID: 6727 RVA: 0x00068CE7 File Offset: 0x00066EE7
		public T value
		{
			get
			{
				return (this.m_Keyword == StyleKeyword.Undefined) ? this.m_Value : default(T);
			}
			set
			{
				this.m_Value = value;
				this.m_Keyword = StyleKeyword.Undefined;
			}
		}

		// Token: 0x17000669 RID: 1641
		// (get) Token: 0x06001A48 RID: 6728 RVA: 0x00068CF8 File Offset: 0x00066EF8
		// (set) Token: 0x06001A49 RID: 6729 RVA: 0x00068D10 File Offset: 0x00066F10
		public StyleKeyword keyword
		{
			get
			{
				return this.m_Keyword;
			}
			set
			{
				this.m_Keyword = value;
			}
		}

		// Token: 0x06001A4A RID: 6730 RVA: 0x00068D1A File Offset: 0x00066F1A
		public StyleEnum(T v)
		{
			this = new StyleEnum<T>(v, StyleKeyword.Undefined);
		}

		// Token: 0x06001A4B RID: 6731 RVA: 0x00068D28 File Offset: 0x00066F28
		public StyleEnum(StyleKeyword keyword)
		{
			this = new StyleEnum<T>(default(T), keyword);
		}

		// Token: 0x06001A4C RID: 6732 RVA: 0x00068D47 File Offset: 0x00066F47
		internal StyleEnum(T v, StyleKeyword keyword)
		{
			this.m_Keyword = keyword;
			this.m_Value = v;
		}

		// Token: 0x06001A4D RID: 6733 RVA: 0x00068D58 File Offset: 0x00066F58
		public static bool operator ==(StyleEnum<T> lhs, StyleEnum<T> rhs)
		{
			return lhs.m_Keyword == rhs.m_Keyword && UnsafeUtility.EnumEquals<T>(lhs.m_Value, rhs.m_Value);
		}

		// Token: 0x06001A4E RID: 6734 RVA: 0x00068D8C File Offset: 0x00066F8C
		public static bool operator !=(StyleEnum<T> lhs, StyleEnum<T> rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06001A4F RID: 6735 RVA: 0x00068DA8 File Offset: 0x00066FA8
		public static implicit operator StyleEnum<T>(StyleKeyword keyword)
		{
			return new StyleEnum<T>(keyword);
		}

		// Token: 0x06001A50 RID: 6736 RVA: 0x00068DC0 File Offset: 0x00066FC0
		public static implicit operator StyleEnum<T>(T v)
		{
			return new StyleEnum<T>(v);
		}

		// Token: 0x06001A51 RID: 6737 RVA: 0x00068DD8 File Offset: 0x00066FD8
		public bool Equals(StyleEnum<T> other)
		{
			return other == this;
		}

		// Token: 0x06001A52 RID: 6738 RVA: 0x00068DF8 File Offset: 0x00066FF8
		public override bool Equals(object obj)
		{
			bool result;
			if (obj is StyleEnum<T>)
			{
				StyleEnum<T> other = (StyleEnum<T>)obj;
				result = this.Equals(other);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001A53 RID: 6739 RVA: 0x00068E24 File Offset: 0x00067024
		public override int GetHashCode()
		{
			return UnsafeUtility.EnumToInt<T>(this.m_Value) * 397 ^ (int)this.m_Keyword;
		}

		// Token: 0x06001A54 RID: 6740 RVA: 0x00068E50 File Offset: 0x00067050
		public override string ToString()
		{
			return this.DebugString<T>();
		}

		// Token: 0x04000AE4 RID: 2788
		private T m_Value;

		// Token: 0x04000AE5 RID: 2789
		private StyleKeyword m_Keyword;
	}
}
