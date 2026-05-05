using System;
using Unity.Multiplayer.Tools.MetricTypes;

namespace Unity.Multiplayer.Tools.NetworkProfiler.Runtime
{
	// Token: 0x0200000D RID: 13
	[Serializable]
	internal struct BytesSentAndReceived : IEquatable<BytesSentAndReceived>
	{
		// Token: 0x0600001D RID: 29 RVA: 0x00002615 File Offset: 0x00000815
		public BytesSentAndReceived(long sent = 0L, long received = 0L)
		{
			this.Sent = sent;
			this.Received = received;
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600001E RID: 30 RVA: 0x00002625 File Offset: 0x00000825
		public readonly long Sent { get; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600001F RID: 31 RVA: 0x0000262D File Offset: 0x0000082D
		public readonly long Received { get; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000020 RID: 32 RVA: 0x00002635 File Offset: 0x00000835
		public NetworkDirection Direction
		{
			get
			{
				return (((float)this.Sent > 0f) ? NetworkDirection.Sent : NetworkDirection.None) | (((float)this.Received > 0f) ? NetworkDirection.Received : NetworkDirection.None);
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000021 RID: 33 RVA: 0x0000265C File Offset: 0x0000085C
		public long Total
		{
			get
			{
				return this.Sent + this.Received;
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000266B File Offset: 0x0000086B
		public bool Equals(BytesSentAndReceived other)
		{
			return this.Sent == other.Sent && this.Received == other.Received;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002690 File Offset: 0x00000890
		public override bool Equals(object obj)
		{
			if (obj is BytesSentAndReceived)
			{
				BytesSentAndReceived other = (BytesSentAndReceived)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000026B5 File Offset: 0x000008B5
		public static BytesSentAndReceived operator +(BytesSentAndReceived a, BytesSentAndReceived b)
		{
			return new BytesSentAndReceived(a.Sent + b.Sent, a.Received + b.Received);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000026DC File Offset: 0x000008DC
		public override int GetHashCode()
		{
			return this.Sent.GetHashCode() * 397 ^ this.Received.GetHashCode();
		}

		// Token: 0x06000026 RID: 38 RVA: 0x0000270C File Offset: 0x0000090C
		public override string ToString()
		{
			return string.Format("{0}: {1}={2} {3}={4}", new object[]
			{
				"BytesSentAndReceived",
				"Sent",
				this.Sent,
				"Received",
				this.Received
			});
		}
	}
}
