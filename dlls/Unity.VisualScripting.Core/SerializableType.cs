using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000138 RID: 312
	[SerializationVersion("A", new Type[]
	{

	})]
	[Serializable]
	public struct SerializableType : IEquatable<SerializableType>, IComparable<SerializableType>
	{
		// Token: 0x06000877 RID: 2167 RVA: 0x000259F8 File Offset: 0x00023BF8
		public SerializableType(string identification)
		{
			this.Identification = identification;
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x00025A01 File Offset: 0x00023C01
		public bool Equals(SerializableType other)
		{
			return string.Equals(this.Identification, other.Identification);
		}

		// Token: 0x06000879 RID: 2169 RVA: 0x00025A14 File Offset: 0x00023C14
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is SerializableType)
			{
				SerializableType other = (SerializableType)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0600087A RID: 2170 RVA: 0x00025A3E File Offset: 0x00023C3E
		public override int GetHashCode()
		{
			string identification = this.Identification;
			if (identification == null)
			{
				return 0;
			}
			return identification.GetHashCode();
		}

		// Token: 0x0600087B RID: 2171 RVA: 0x00025A51 File Offset: 0x00023C51
		public static bool operator ==(SerializableType left, SerializableType right)
		{
			return left.Equals(right);
		}

		// Token: 0x0600087C RID: 2172 RVA: 0x00025A5B File Offset: 0x00023C5B
		public static bool operator !=(SerializableType left, SerializableType right)
		{
			return !left.Equals(right);
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x00025A68 File Offset: 0x00023C68
		public int CompareTo(SerializableType other)
		{
			return string.Compare(this.Identification, other.Identification, StringComparison.Ordinal);
		}

		// Token: 0x04000205 RID: 517
		[Serialize]
		public string Identification;
	}
}
