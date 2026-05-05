using System;

namespace Rewired.Utils.Classes.Data
{
	// Token: 0x02000519 RID: 1305
	[Serializable]
	public struct Id : IEquatable<Id>, IEquatable<uint>
	{
		// Token: 0x060035BE RID: 13758 RVA: 0x000B5DC4 File Offset: 0x000B3FC4
		public static bool IsValid(Id id)
		{
			uint num = id.id;
			return num != 0U && num != uint.MaxValue;
		}

		// Token: 0x060035BF RID: 13759 RVA: 0x0002A0CB File Offset: 0x000282CB
		public static bool IsValid(uint id)
		{
			return id != 0U && id != uint.MaxValue;
		}

		// Token: 0x060035C0 RID: 13760 RVA: 0x0002A0D7 File Offset: 0x000282D7
		public Id(uint A_1)
		{
			this.id = A_1;
		}

		// Token: 0x060035C1 RID: 13761 RVA: 0x0002A0E0 File Offset: 0x000282E0
		public bool Equals(Id other)
		{
			return this.id == other.id;
		}

		// Token: 0x060035C2 RID: 13762 RVA: 0x0002A0F0 File Offset: 0x000282F0
		public bool Equals(uint other)
		{
			return this.id == other;
		}

		// Token: 0x060035C3 RID: 13763 RVA: 0x0002A0FB File Offset: 0x000282FB
		public override bool Equals(object other)
		{
			if (other == null)
			{
				return false;
			}
			if (other is Id)
			{
				return this.id == ((Id)other).id;
			}
			return other is uint && this.id == (uint)other;
		}

		// Token: 0x060035C4 RID: 13764 RVA: 0x0002A136 File Offset: 0x00028336
		public override int GetHashCode()
		{
			return this.id.GetHashCode();
		}

		// Token: 0x060035C5 RID: 13765 RVA: 0x0002A0E0 File Offset: 0x000282E0
		public static bool operator ==(Id a, Id b)
		{
			return a.id == b.id;
		}

		// Token: 0x060035C6 RID: 13766 RVA: 0x0002A143 File Offset: 0x00028343
		public static bool operator !=(Id a, Id b)
		{
			return !(a == b);
		}

		// Token: 0x060035C7 RID: 13767 RVA: 0x0002A14F File Offset: 0x0002834F
		public static implicit operator uint(Id a)
		{
			return a.id;
		}

		// Token: 0x060035C8 RID: 13768 RVA: 0x0002A157 File Offset: 0x00028357
		public static implicit operator Id(uint a)
		{
			return new Id(a);
		}

		// Token: 0x060035C9 RID: 13769 RVA: 0x0002A15F File Offset: 0x0002835F
		public void Increment()
		{
			this.id += 1U;
			if (this.id == 4294967295U)
			{
				this.id = 1U;
			}
		}

		// Token: 0x04001C66 RID: 7270
		public const uint Default = 0U;

		// Token: 0x04001C67 RID: 7271
		public const uint First = 1U;

		// Token: 0x04001C68 RID: 7272
		public const uint Invalid = 4294967295U;

		// Token: 0x04001C69 RID: 7273
		public uint id;
	}
}
