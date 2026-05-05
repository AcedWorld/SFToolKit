using System;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.Networking.PlayerConnection
{
	// Token: 0x020003CB RID: 971
	[MovedFrom("UnityEngine.Experimental.Networking.PlayerConnection")]
	public interface IConnectionState : IDisposable
	{
		// Token: 0x17000646 RID: 1606
		// (get) Token: 0x0600210F RID: 8463
		ConnectionTarget connectedToTarget { get; }

		// Token: 0x17000647 RID: 1607
		// (get) Token: 0x06002110 RID: 8464
		string connectionName { get; }
	}
}
