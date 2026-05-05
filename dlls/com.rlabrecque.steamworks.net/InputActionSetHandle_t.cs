using System;

namespace Steamworks
{
	// Token: 0x02000198 RID: 408
	[Serializable]
	public struct InputActionSetHandle_t : IEquatable<InputActionSetHandle_t>, IComparable<InputActionSetHandle_t>
	{
		// Token: 0x060009B9 RID: 2489 RVA: 0x0000ED5F File Offset: 0x0000CF5F
		public InputActionSetHandle_t(ulong value)
		{
			this.m_InputActionSetHandle = value;
		}

		// Token: 0x060009BA RID: 2490 RVA: 0x0000ED68 File Offset: 0x0000CF68
		public override string ToString()
		{
			return this.m_InputActionSetHandle.ToString();
		}

		// Token: 0x060009BB RID: 2491 RVA: 0x0000ED75 File Offset: 0x0000CF75
		public override bool Equals(object other)
		{
			return other is InputActionSetHandle_t && this == (InputActionSetHandle_t)other;
		}

		// Token: 0x060009BC RID: 2492 RVA: 0x0000ED92 File Offset: 0x0000CF92
		public override int GetHashCode()
		{
			return this.m_InputActionSetHandle.GetHashCode();
		}

		// Token: 0x060009BD RID: 2493 RVA: 0x0000ED9F File Offset: 0x0000CF9F
		public static bool operator ==(InputActionSetHandle_t x, InputActionSetHandle_t y)
		{
			return x.m_InputActionSetHandle == y.m_InputActionSetHandle;
		}

		// Token: 0x060009BE RID: 2494 RVA: 0x0000EDAF File Offset: 0x0000CFAF
		public static bool operator !=(InputActionSetHandle_t x, InputActionSetHandle_t y)
		{
			return !(x == y);
		}

		// Token: 0x060009BF RID: 2495 RVA: 0x0000EDBB File Offset: 0x0000CFBB
		public static explicit operator InputActionSetHandle_t(ulong value)
		{
			return new InputActionSetHandle_t(value);
		}

		// Token: 0x060009C0 RID: 2496 RVA: 0x0000EDC3 File Offset: 0x0000CFC3
		public static explicit operator ulong(InputActionSetHandle_t that)
		{
			return that.m_InputActionSetHandle;
		}

		// Token: 0x060009C1 RID: 2497 RVA: 0x0000EDCB File Offset: 0x0000CFCB
		public bool Equals(InputActionSetHandle_t other)
		{
			return this.m_InputActionSetHandle == other.m_InputActionSetHandle;
		}

		// Token: 0x060009C2 RID: 2498 RVA: 0x0000EDDB File Offset: 0x0000CFDB
		public int CompareTo(InputActionSetHandle_t other)
		{
			return this.m_InputActionSetHandle.CompareTo(other.m_InputActionSetHandle);
		}

		// Token: 0x04000A64 RID: 2660
		public ulong m_InputActionSetHandle;
	}
}
