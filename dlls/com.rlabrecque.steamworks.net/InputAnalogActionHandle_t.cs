using System;

namespace Steamworks
{
	// Token: 0x02000199 RID: 409
	[Serializable]
	public struct InputAnalogActionHandle_t : IEquatable<InputAnalogActionHandle_t>, IComparable<InputAnalogActionHandle_t>
	{
		// Token: 0x060009C3 RID: 2499 RVA: 0x0000EDEE File Offset: 0x0000CFEE
		public InputAnalogActionHandle_t(ulong value)
		{
			this.m_InputAnalogActionHandle = value;
		}

		// Token: 0x060009C4 RID: 2500 RVA: 0x0000EDF7 File Offset: 0x0000CFF7
		public override string ToString()
		{
			return this.m_InputAnalogActionHandle.ToString();
		}

		// Token: 0x060009C5 RID: 2501 RVA: 0x0000EE04 File Offset: 0x0000D004
		public override bool Equals(object other)
		{
			return other is InputAnalogActionHandle_t && this == (InputAnalogActionHandle_t)other;
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x0000EE21 File Offset: 0x0000D021
		public override int GetHashCode()
		{
			return this.m_InputAnalogActionHandle.GetHashCode();
		}

		// Token: 0x060009C7 RID: 2503 RVA: 0x0000EE2E File Offset: 0x0000D02E
		public static bool operator ==(InputAnalogActionHandle_t x, InputAnalogActionHandle_t y)
		{
			return x.m_InputAnalogActionHandle == y.m_InputAnalogActionHandle;
		}

		// Token: 0x060009C8 RID: 2504 RVA: 0x0000EE3E File Offset: 0x0000D03E
		public static bool operator !=(InputAnalogActionHandle_t x, InputAnalogActionHandle_t y)
		{
			return !(x == y);
		}

		// Token: 0x060009C9 RID: 2505 RVA: 0x0000EE4A File Offset: 0x0000D04A
		public static explicit operator InputAnalogActionHandle_t(ulong value)
		{
			return new InputAnalogActionHandle_t(value);
		}

		// Token: 0x060009CA RID: 2506 RVA: 0x0000EE52 File Offset: 0x0000D052
		public static explicit operator ulong(InputAnalogActionHandle_t that)
		{
			return that.m_InputAnalogActionHandle;
		}

		// Token: 0x060009CB RID: 2507 RVA: 0x0000EE5A File Offset: 0x0000D05A
		public bool Equals(InputAnalogActionHandle_t other)
		{
			return this.m_InputAnalogActionHandle == other.m_InputAnalogActionHandle;
		}

		// Token: 0x060009CC RID: 2508 RVA: 0x0000EE6A File Offset: 0x0000D06A
		public int CompareTo(InputAnalogActionHandle_t other)
		{
			return this.m_InputAnalogActionHandle.CompareTo(other.m_InputAnalogActionHandle);
		}

		// Token: 0x04000A65 RID: 2661
		public ulong m_InputAnalogActionHandle;
	}
}
