using System;

namespace Steamworks
{
	// Token: 0x0200019B RID: 411
	[Serializable]
	public struct InputHandle_t : IEquatable<InputHandle_t>, IComparable<InputHandle_t>
	{
		// Token: 0x060009D7 RID: 2519 RVA: 0x0000EF0C File Offset: 0x0000D10C
		public InputHandle_t(ulong value)
		{
			this.m_InputHandle = value;
		}

		// Token: 0x060009D8 RID: 2520 RVA: 0x0000EF15 File Offset: 0x0000D115
		public override string ToString()
		{
			return this.m_InputHandle.ToString();
		}

		// Token: 0x060009D9 RID: 2521 RVA: 0x0000EF22 File Offset: 0x0000D122
		public override bool Equals(object other)
		{
			return other is InputHandle_t && this == (InputHandle_t)other;
		}

		// Token: 0x060009DA RID: 2522 RVA: 0x0000EF3F File Offset: 0x0000D13F
		public override int GetHashCode()
		{
			return this.m_InputHandle.GetHashCode();
		}

		// Token: 0x060009DB RID: 2523 RVA: 0x0000EF4C File Offset: 0x0000D14C
		public static bool operator ==(InputHandle_t x, InputHandle_t y)
		{
			return x.m_InputHandle == y.m_InputHandle;
		}

		// Token: 0x060009DC RID: 2524 RVA: 0x0000EF5C File Offset: 0x0000D15C
		public static bool operator !=(InputHandle_t x, InputHandle_t y)
		{
			return !(x == y);
		}

		// Token: 0x060009DD RID: 2525 RVA: 0x0000EF68 File Offset: 0x0000D168
		public static explicit operator InputHandle_t(ulong value)
		{
			return new InputHandle_t(value);
		}

		// Token: 0x060009DE RID: 2526 RVA: 0x0000EF70 File Offset: 0x0000D170
		public static explicit operator ulong(InputHandle_t that)
		{
			return that.m_InputHandle;
		}

		// Token: 0x060009DF RID: 2527 RVA: 0x0000EF78 File Offset: 0x0000D178
		public bool Equals(InputHandle_t other)
		{
			return this.m_InputHandle == other.m_InputHandle;
		}

		// Token: 0x060009E0 RID: 2528 RVA: 0x0000EF88 File Offset: 0x0000D188
		public int CompareTo(InputHandle_t other)
		{
			return this.m_InputHandle.CompareTo(other.m_InputHandle);
		}

		// Token: 0x04000A67 RID: 2663
		public ulong m_InputHandle;
	}
}
