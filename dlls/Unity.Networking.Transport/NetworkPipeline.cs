using System;

namespace Unity.Networking.Transport
{
	// Token: 0x02000052 RID: 82
	public struct NetworkPipeline
	{
		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000198 RID: 408 RVA: 0x00008C1C File Offset: 0x00006E1C
		public static NetworkPipeline Null
		{
			get
			{
				return default(NetworkPipeline);
			}
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00008C32 File Offset: 0x00006E32
		public static bool operator ==(NetworkPipeline lhs, NetworkPipeline rhs)
		{
			return lhs.Id == rhs.Id;
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00008C42 File Offset: 0x00006E42
		public static bool operator !=(NetworkPipeline lhs, NetworkPipeline rhs)
		{
			return lhs.Id != rhs.Id;
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00008C55 File Offset: 0x00006E55
		public override bool Equals(object compare)
		{
			return this == (NetworkPipeline)compare;
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00008C68 File Offset: 0x00006E68
		public override int GetHashCode()
		{
			return this.Id;
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00008C70 File Offset: 0x00006E70
		public bool Equals(NetworkPipeline connection)
		{
			return connection.Id == this.Id;
		}

		// Token: 0x04000115 RID: 277
		internal int Id;
	}
}
