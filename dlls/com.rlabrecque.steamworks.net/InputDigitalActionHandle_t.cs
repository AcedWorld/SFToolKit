using System;

namespace Steamworks
{
	// Token: 0x0200019A RID: 410
	[Serializable]
	public struct InputDigitalActionHandle_t : IEquatable<InputDigitalActionHandle_t>, IComparable<InputDigitalActionHandle_t>
	{
		// Token: 0x060009CD RID: 2509 RVA: 0x0000EE7D File Offset: 0x0000D07D
		public InputDigitalActionHandle_t(ulong value)
		{
			this.m_InputDigitalActionHandle = value;
		}

		// Token: 0x060009CE RID: 2510 RVA: 0x0000EE86 File Offset: 0x0000D086
		public override string ToString()
		{
			return this.m_InputDigitalActionHandle.ToString();
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x0000EE93 File Offset: 0x0000D093
		public override bool Equals(object other)
		{
			return other is InputDigitalActionHandle_t && this == (InputDigitalActionHandle_t)other;
		}

		// Token: 0x060009D0 RID: 2512 RVA: 0x0000EEB0 File Offset: 0x0000D0B0
		public override int GetHashCode()
		{
			return this.m_InputDigitalActionHandle.GetHashCode();
		}

		// Token: 0x060009D1 RID: 2513 RVA: 0x0000EEBD File Offset: 0x0000D0BD
		public static bool operator ==(InputDigitalActionHandle_t x, InputDigitalActionHandle_t y)
		{
			return x.m_InputDigitalActionHandle == y.m_InputDigitalActionHandle;
		}

		// Token: 0x060009D2 RID: 2514 RVA: 0x0000EECD File Offset: 0x0000D0CD
		public static bool operator !=(InputDigitalActionHandle_t x, InputDigitalActionHandle_t y)
		{
			return !(x == y);
		}

		// Token: 0x060009D3 RID: 2515 RVA: 0x0000EED9 File Offset: 0x0000D0D9
		public static explicit operator InputDigitalActionHandle_t(ulong value)
		{
			return new InputDigitalActionHandle_t(value);
		}

		// Token: 0x060009D4 RID: 2516 RVA: 0x0000EEE1 File Offset: 0x0000D0E1
		public static explicit operator ulong(InputDigitalActionHandle_t that)
		{
			return that.m_InputDigitalActionHandle;
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x0000EEE9 File Offset: 0x0000D0E9
		public bool Equals(InputDigitalActionHandle_t other)
		{
			return this.m_InputDigitalActionHandle == other.m_InputDigitalActionHandle;
		}

		// Token: 0x060009D6 RID: 2518 RVA: 0x0000EEF9 File Offset: 0x0000D0F9
		public int CompareTo(InputDigitalActionHandle_t other)
		{
			return this.m_InputDigitalActionHandle.CompareTo(other.m_InputDigitalActionHandle);
		}

		// Token: 0x04000A66 RID: 2662
		public ulong m_InputDigitalActionHandle;
	}
}
