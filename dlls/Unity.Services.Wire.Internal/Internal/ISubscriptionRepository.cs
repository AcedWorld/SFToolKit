using System;
using System.Collections.Generic;
using Unity.Services.Wire.Protocol.Internal;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x02000018 RID: 24
	internal interface ISubscriptionRepository
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000057 RID: 87
		// (remove) Token: 0x06000058 RID: 88
		event Action<int> SubscriptionCountChanged;

		// Token: 0x06000059 RID: 89
		bool IsAlreadySubscribed(Subscription sub);

		// Token: 0x0600005A RID: 90
		bool IsRecovering(Subscription sub);

		// Token: 0x0600005B RID: 91
		void OnSubscriptionComplete(Subscription sub, SubscribeResult result);

		// Token: 0x0600005C RID: 92
		Subscription GetSub(Subscription sub);

		// Token: 0x0600005D RID: 93
		Subscription GetSub(string channel);

		// Token: 0x0600005E RID: 94
		IEnumerable<KeyValuePair<string, Subscription>> GetAll();

		// Token: 0x0600005F RID: 95
		void RemoveSub(Subscription sub);

		// Token: 0x06000060 RID: 96
		void OnSocketClosed();

		// Token: 0x06000061 RID: 97
		void RecoverSubscriptions(Reply reply);

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000062 RID: 98
		bool IsEmpty { get; }

		// Token: 0x06000063 RID: 99
		void Clear();
	}
}
