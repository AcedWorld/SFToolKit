using System;

namespace Unity.Networking.Transport
{
	// Token: 0x0200002B RID: 43
	public struct NetworkConnection : IEquatable<NetworkConnection>
	{
		// Token: 0x060000DE RID: 222 RVA: 0x00005199 File Offset: 0x00003399
		public int Disconnect(NetworkDriver driver)
		{
			return driver.Disconnect(this);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x000051A8 File Offset: 0x000033A8
		public NetworkEvent.Type PopEvent(NetworkDriver driver, out DataStreamReader stream)
		{
			return driver.PopEventForConnection(this, out stream);
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x000051B8 File Offset: 0x000033B8
		public NetworkEvent.Type PopEvent(NetworkDriver driver, out DataStreamReader stream, out NetworkPipeline pipeline)
		{
			return driver.PopEventForConnection(this, out stream, out pipeline);
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x000051C9 File Offset: 0x000033C9
		public int Close(NetworkDriver driver)
		{
			if (this.m_NetworkId >= 0)
			{
				return driver.Disconnect(this);
			}
			return -1;
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x000051E3 File Offset: 0x000033E3
		public bool IsCreated
		{
			get
			{
				return this.m_NetworkVersion != 0;
			}
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x000051EE File Offset: 0x000033EE
		public NetworkConnection.State GetState(NetworkDriver driver)
		{
			return driver.GetConnectionState(this);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x000051FD File Offset: 0x000033FD
		public static bool operator ==(NetworkConnection lhs, NetworkConnection rhs)
		{
			return lhs.m_NetworkId == rhs.m_NetworkId && lhs.m_NetworkVersion == rhs.m_NetworkVersion;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000521D File Offset: 0x0000341D
		public static bool operator !=(NetworkConnection lhs, NetworkConnection rhs)
		{
			return lhs.m_NetworkId != rhs.m_NetworkId || lhs.m_NetworkVersion != rhs.m_NetworkVersion;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00005240 File Offset: 0x00003440
		public override bool Equals(object o)
		{
			return this == (NetworkConnection)o;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00005253 File Offset: 0x00003453
		public bool Equals(NetworkConnection o)
		{
			return this == o;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00005261 File Offset: 0x00003461
		public override int GetHashCode()
		{
			return this.m_NetworkId << 8 ^ this.m_NetworkVersion;
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x00005272 File Offset: 0x00003472
		public int InternalId
		{
			get
			{
				return this.m_NetworkId;
			}
		}

		// Token: 0x04000074 RID: 116
		internal int m_NetworkId;

		// Token: 0x04000075 RID: 117
		internal int m_NetworkVersion;

		// Token: 0x0200002C RID: 44
		public enum State
		{
			// Token: 0x04000077 RID: 119
			Disconnected,
			// Token: 0x04000078 RID: 120
			Connecting,
			// Token: 0x04000079 RID: 121
			Connected
		}
	}
}
