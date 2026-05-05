using System;

namespace Unity.Multiplayer.Tools.MetricTypes
{
	// Token: 0x02000005 RID: 5
	[Serializable]
	internal struct ConnectionInfo
	{
		// Token: 0x06000007 RID: 7 RVA: 0x000020F8 File Offset: 0x000002F8
		public ConnectionInfo(ulong id)
		{
			this.Id = id;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000008 RID: 8 RVA: 0x00002101 File Offset: 0x00000301
		public readonly ulong Id { get; }

		// Token: 0x06000009 RID: 9 RVA: 0x00002109 File Offset: 0x00000309
		public static bool operator ==(ConnectionInfo a, ConnectionInfo b)
		{
			return a.Equals(b);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002113 File Offset: 0x00000313
		public static bool operator !=(ConnectionInfo a, ConnectionInfo b)
		{
			return !(a == b);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000211F File Offset: 0x0000031F
		public bool Equals(ConnectionInfo other)
		{
			return this.Id == other.Id;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002130 File Offset: 0x00000330
		public override bool Equals(object obj)
		{
			if (obj is ConnectionInfo)
			{
				ConnectionInfo other = (ConnectionInfo)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002158 File Offset: 0x00000358
		public override int GetHashCode()
		{
			return this.Id.GetHashCode();
		}
	}
}
