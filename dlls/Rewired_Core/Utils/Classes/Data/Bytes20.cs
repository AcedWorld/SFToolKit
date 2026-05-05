using System;
using System.Text;

namespace Rewired.Utils.Classes.Data
{
	// Token: 0x0200051A RID: 1306
	[Serializable]
	public struct Bytes20 : IEquatable<Bytes20>
	{
		// Token: 0x060035CA RID: 13770 RVA: 0x000B5DE4 File Offset: 0x000B3FE4
		public Bytes20(byte[] A_1)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException();
			}
			if (A_1.Length < 20)
			{
				throw new ArgumentException("bytes must be at least 20 bytes");
			}
			this.value0 = BitConverter.ToInt64(A_1, 0);
			this.value1 = BitConverter.ToInt64(A_1, 8);
			this.value2 = BitConverter.ToInt32(A_1, 16);
		}

		// Token: 0x060035CB RID: 13771 RVA: 0x000B5E34 File Offset: 0x000B4034
		public byte[] GetBytes()
		{
			byte[] array = new byte[20];
			Array.Copy(BitConverter.GetBytes(this.value0), 0, array, 0, 8);
			Array.Copy(BitConverter.GetBytes(this.value1), 0, array, 8, 8);
			Array.Copy(BitConverter.GetBytes(this.value2), 0, array, 16, 4);
			return array;
		}

		// Token: 0x060035CC RID: 13772 RVA: 0x000B5E88 File Offset: 0x000B4088
		public override bool Equals(object obj)
		{
			if (!(obj is Bytes20))
			{
				return false;
			}
			Bytes20 bytes = (Bytes20)obj;
			return bytes.value0 == this.value0 && bytes.value1 == this.value1 && bytes.value2 == this.value2;
		}

		// Token: 0x060035CD RID: 13773 RVA: 0x0002A17F File Offset: 0x0002837F
		public override int GetHashCode()
		{
			return ((17 * 29 + this.value0.GetHashCode()) * 29 + this.value1.GetHashCode()) * 29 + this.value2.GetHashCode();
		}

		// Token: 0x060035CE RID: 13774 RVA: 0x0002A1B0 File Offset: 0x000283B0
		public bool Equals(Bytes20 other)
		{
			return this.value0 == other.value0 && this.value1 == other.value1 && this.value2 == other.value2;
		}

		// Token: 0x060035CF RID: 13775 RVA: 0x0002A1B0 File Offset: 0x000283B0
		public static bool operator ==(Bytes20 a, Bytes20 b)
		{
			return a.value0 == b.value0 && a.value1 == b.value1 && a.value2 == b.value2;
		}

		// Token: 0x060035D0 RID: 13776 RVA: 0x0002A1DE File Offset: 0x000283DE
		public static bool operator !=(Bytes20 a, Bytes20 b)
		{
			return !(a == b);
		}

		// Token: 0x060035D1 RID: 13777 RVA: 0x000B5ED4 File Offset: 0x000B40D4
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			byte[] bytes = this.GetBytes();
			for (int i = 0; i < bytes.Length; i++)
			{
				stringBuilder.Append(bytes[i].ToString("X2"));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x04001C6A RID: 7274
		public long value0;

		// Token: 0x04001C6B RID: 7275
		public long value1;

		// Token: 0x04001C6C RID: 7276
		public int value2;
	}
}
