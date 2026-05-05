using System;

namespace Unity.Services.Core.Internal
{
	// Token: 0x02000043 RID: 67
	internal class HashException : Exception
	{
		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600012C RID: 300 RVA: 0x0000377E File Offset: 0x0000197E
		public int Hash { get; }

		// Token: 0x0600012D RID: 301 RVA: 0x00003786 File Offset: 0x00001986
		public HashException(int hash)
		{
			this.Hash = hash;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00003795 File Offset: 0x00001995
		public HashException(int hash, string message)
		{
			this.Hash = hash;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x000037A4 File Offset: 0x000019A4
		public HashException(int hash, string message, Exception inner) : base(message, inner)
		{
			this.Hash = hash;
		}
	}
}
