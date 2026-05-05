using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Unity.Services.Wire.Protocol.Internal;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x02000019 RID: 25
	internal class ConcurrentDictSubscriptionRepository : ISubscriptionRepository
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000064 RID: 100 RVA: 0x00002FD3 File Offset: 0x000011D3
		public bool IsEmpty
		{
			get
			{
				return this.Subscriptions.IsEmpty;
			}
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000065 RID: 101 RVA: 0x00002FE0 File Offset: 0x000011E0
		// (remove) Token: 0x06000066 RID: 102 RVA: 0x00003018 File Offset: 0x00001218
		public event Action<int> SubscriptionCountChanged;

		// Token: 0x06000067 RID: 103 RVA: 0x0000304D File Offset: 0x0000124D
		public ConcurrentDictSubscriptionRepository()
		{
			this.Subscriptions = new ConcurrentDictionary<string, Subscription>();
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00003060 File Offset: 0x00001260
		public void Clear()
		{
			this.Subscriptions.Clear();
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0000306D File Offset: 0x0000126D
		public bool IsAlreadySubscribed(string alias)
		{
			Subscription sub = this.GetSub(alias);
			return sub != null && sub.IsConnected;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00003081 File Offset: 0x00001281
		public bool IsAlreadySubscribed(Subscription sub)
		{
			return this.IsAlreadySubscribed(sub.Channel);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0000308F File Offset: 0x0000128F
		public bool IsRecovering(Subscription sub)
		{
			return !string.IsNullOrEmpty(sub.Channel) && this.Subscriptions.ContainsKey(sub.Channel) && !sub.IsConnected;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x000030C0 File Offset: 0x000012C0
		public void OnSubscriptionComplete(Subscription sub, SubscribeResult res)
		{
			if (res.offset != sub.Offset)
			{
				try
				{
					foreach (Publication publication in res.publications)
					{
						sub.ProcessPublication(publication);
					}
					sub.Offset = res.offset;
				}
				catch (Exception)
				{
				}
			}
			bool flag = this.IsRecovering(sub);
			sub.OnConnectivityChangeReceived(true);
			if (!flag)
			{
				this.Subscriptions.TryAdd(sub.Channel, sub);
				Action<int> subscriptionCountChanged = this.SubscriptionCountChanged;
				if (subscriptionCountChanged == null)
				{
					return;
				}
				subscriptionCountChanged(this.Subscriptions.Count);
			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x0000315C File Offset: 0x0000135C
		public Subscription GetSub(string channel)
		{
			if (string.IsNullOrEmpty(channel))
			{
				return null;
			}
			if (this.Subscriptions.ContainsKey(channel))
			{
				Subscription result;
				this.Subscriptions.TryGetValue(channel, out result);
				return result;
			}
			return null;
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00003193 File Offset: 0x00001393
		public Subscription GetSub(Subscription sub)
		{
			return this.GetSub(sub.Channel);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000031A4 File Offset: 0x000013A4
		public void RemoveSub(Subscription sub)
		{
			if (string.IsNullOrEmpty(sub.Channel))
			{
				return;
			}
			if (this.Subscriptions.ContainsKey(sub.Channel))
			{
				Subscription subscription;
				this.Subscriptions.TryRemove(sub.Channel, out subscription);
				sub.OnUnsubscriptionComplete();
				Action<int> subscriptionCountChanged = this.SubscriptionCountChanged;
				if (subscriptionCountChanged == null)
				{
					return;
				}
				subscriptionCountChanged(this.Subscriptions.Count);
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00003208 File Offset: 0x00001408
		public void OnSocketClosed()
		{
			foreach (KeyValuePair<string, Subscription> keyValuePair in this.Subscriptions)
			{
				keyValuePair.Value.OnConnectivityChangeReceived(false);
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x0000325C File Offset: 0x0000145C
		public void RecoverSubscriptions(Reply reply)
		{
			ConnectResult connect = reply.connect;
			Dictionary<string, SubscribeResult> subs = connect.subs;
			if (subs != null && subs.Count > 0)
			{
				foreach (KeyValuePair<string, SubscribeResult> keyValuePair in connect.subs)
				{
					Subscription sub = this.GetSub(keyValuePair.Key);
					if (sub != null)
					{
						this.OnSubscriptionComplete(sub, keyValuePair.Value);
					}
				}
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x000032E8 File Offset: 0x000014E8
		public IEnumerable<KeyValuePair<string, Subscription>> GetAll()
		{
			return this.Subscriptions.ToArray();
		}

		// Token: 0x04000079 RID: 121
		public ConcurrentDictionary<string, Subscription> Subscriptions;
	}
}
