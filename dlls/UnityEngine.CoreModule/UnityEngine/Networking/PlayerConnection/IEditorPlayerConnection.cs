using System;
using UnityEngine.Events;

namespace UnityEngine.Networking.PlayerConnection
{
	// Token: 0x020003CD RID: 973
	public interface IEditorPlayerConnection
	{
		// Token: 0x06002112 RID: 8466
		void Register(Guid messageId, UnityAction<MessageEventArgs> callback);

		// Token: 0x06002113 RID: 8467
		void Unregister(Guid messageId, UnityAction<MessageEventArgs> callback);

		// Token: 0x06002114 RID: 8468
		void DisconnectAll();

		// Token: 0x06002115 RID: 8469
		void RegisterConnection(UnityAction<int> callback);

		// Token: 0x06002116 RID: 8470
		void RegisterDisconnection(UnityAction<int> callback);

		// Token: 0x06002117 RID: 8471
		void UnregisterConnection(UnityAction<int> callback);

		// Token: 0x06002118 RID: 8472
		void UnregisterDisconnection(UnityAction<int> callback);

		// Token: 0x06002119 RID: 8473
		void Send(Guid messageId, byte[] data);

		// Token: 0x0600211A RID: 8474
		bool TrySend(Guid messageId, byte[] data);
	}
}
