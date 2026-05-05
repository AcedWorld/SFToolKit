using System;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x02000476 RID: 1142
	internal struct BMPAlloc
	{
		// Token: 0x0600234E RID: 9038 RVA: 0x00089338 File Offset: 0x00087538
		public bool Equals(BMPAlloc other)
		{
			return this.page == other.page && this.pageLine == other.pageLine && this.bitIndex == other.bitIndex;
		}

		// Token: 0x0600234F RID: 9039 RVA: 0x00089378 File Offset: 0x00087578
		public bool IsValid()
		{
			return this.page >= 0;
		}

		// Token: 0x06002350 RID: 9040 RVA: 0x00089398 File Offset: 0x00087598
		public override string ToString()
		{
			return string.Format("{0},{1},{2}", this.page, this.pageLine, this.bitIndex);
		}

		// Token: 0x04001075 RID: 4213
		public static readonly BMPAlloc Invalid = new BMPAlloc
		{
			page = -1
		};

		// Token: 0x04001076 RID: 4214
		public int page;

		// Token: 0x04001077 RID: 4215
		public ushort pageLine;

		// Token: 0x04001078 RID: 4216
		public byte bitIndex;

		// Token: 0x04001079 RID: 4217
		public OwnedState ownedState;
	}
}
