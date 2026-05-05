using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Unity.Services.Wire.Protocol.Internal;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x0200001A RID: 26
	internal class Subscription : IChannel, IDisposable
	{
		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000073 RID: 115 RVA: 0x000032F8 File Offset: 0x000014F8
		// (remove) Token: 0x06000074 RID: 116 RVA: 0x00003330 File Offset: 0x00001530
		public event Action<string> MessageReceived;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000075 RID: 117 RVA: 0x00003368 File Offset: 0x00001568
		// (remove) Token: 0x06000076 RID: 118 RVA: 0x000033A0 File Offset: 0x000015A0
		public event Action<byte[]> BinaryMessageReceived;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000077 RID: 119 RVA: 0x000033D8 File Offset: 0x000015D8
		// (remove) Token: 0x06000078 RID: 120 RVA: 0x00003410 File Offset: 0x00001610
		public event Action KickReceived;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000079 RID: 121 RVA: 0x00003448 File Offset: 0x00001648
		// (remove) Token: 0x0600007A RID: 122 RVA: 0x00003480 File Offset: 0x00001680
		public event Action<SubscriptionState> NewStateReceived;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x0600007B RID: 123 RVA: 0x000034B8 File Offset: 0x000016B8
		// (remove) Token: 0x0600007C RID: 124 RVA: 0x000034F0 File Offset: 0x000016F0
		public event Action<TaskCompletionSource<bool>> UnsubscribeReceived;

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x0600007D RID: 125 RVA: 0x00003528 File Offset: 0x00001728
		// (remove) Token: 0x0600007E RID: 126 RVA: 0x00003560 File Offset: 0x00001760
		public event Action<TaskCompletionSource<bool>> SubscribeReceived;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x0600007F RID: 127 RVA: 0x00003598 File Offset: 0x00001798
		// (remove) Token: 0x06000080 RID: 128 RVA: 0x000035D0 File Offset: 0x000017D0
		public event Action<string> ErrorReceived;

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x06000081 RID: 129 RVA: 0x00003608 File Offset: 0x00001808
		// (remove) Token: 0x06000082 RID: 130 RVA: 0x00003640 File Offset: 0x00001840
		public event Action DisposeReceived;

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000083 RID: 131 RVA: 0x00003675 File Offset: 0x00001875
		public bool IsConnected
		{
			get
			{
				return this.SubscriptionState == SubscriptionState.Synced;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000084 RID: 132 RVA: 0x00003680 File Offset: 0x00001880
		// (set) Token: 0x06000085 RID: 133 RVA: 0x00003688 File Offset: 0x00001888
		public SubscriptionState SubscriptionState
		{
			get
			{
				return this.m_State;
			}
			private set
			{
				this.SetState(value);
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000086 RID: 134 RVA: 0x00003691 File Offset: 0x00001891
		private string ChannelDisplay
		{
			get
			{
				if (!string.IsNullOrEmpty(this.Channel))
				{
					return this.Channel;
				}
				return "unknown";
			}
		}

		// Token: 0x06000087 RID: 135 RVA: 0x000036AC File Offset: 0x000018AC
		public Subscription(IChannelTokenProvider tokenProvider)
		{
			this.m_TokenProvider = tokenProvider;
			this.Offset = 0UL;
			this.m_Disposed = false;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x000036D4 File Offset: 0x000018D4
		public Task<string> RetrieveTokenAsync()
		{
			Subscription.<RetrieveTokenAsync>d__38 <RetrieveTokenAsync>d__;
			<RetrieveTokenAsync>d__.<>t__builder = AsyncTaskMethodBuilder<string>.Create();
			<RetrieveTokenAsync>d__.<>4__this = this;
			<RetrieveTokenAsync>d__.<>1__state = -1;
			<RetrieveTokenAsync>d__.<>t__builder.Start<Subscription.<RetrieveTokenAsync>d__38>(ref <RetrieveTokenAsync>d__);
			return <RetrieveTokenAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00003717 File Offset: 0x00001917
		internal void SetState(SubscriptionState state)
		{
			if (this.m_State != state)
			{
				this.m_State = state;
				Action<SubscriptionState> newStateReceived = this.NewStateReceived;
				if (newStateReceived == null)
				{
					return;
				}
				newStateReceived(this.m_State);
			}
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00003740 File Offset: 0x00001940
		private void ValidateTokenData(string channel, string token)
		{
			if (string.IsNullOrEmpty(channel))
			{
				throw new EmptyChannelException();
			}
			if (string.IsNullOrEmpty(token))
			{
				throw new EmptyTokenException();
			}
			if (!string.IsNullOrEmpty(this.Channel) && this.Channel != channel)
			{
				throw new ChannelChangedException(channel, this.Channel);
			}
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00003794 File Offset: 0x00001994
		internal void ProcessPublication(Publication publication)
		{
			try
			{
				Action<string> messageReceived = this.MessageReceived;
				if (messageReceived != null)
				{
					messageReceived(publication.data.payload);
				}
				Action<byte[]> binaryMessageReceived = this.BinaryMessageReceived;
				if (binaryMessageReceived != null)
				{
					binaryMessageReceived(Encoding.UTF8.GetBytes(publication.data.payload));
				}
			}
			finally
			{
				this.Offset = publication.offset;
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00003804 File Offset: 0x00001A04
		internal void OnUnsubscriptionComplete()
		{
			this.SubscriptionState = SubscriptionState.Unsubscribed;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000380D File Offset: 0x00001A0D
		public void OnKickReceived()
		{
			this.SubscriptionState = SubscriptionState.Unsubscribed;
			Action kickReceived = this.KickReceived;
			if (kickReceived == null)
			{
				return;
			}
			kickReceived();
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00003826 File Offset: 0x00001A26
		public void OnConnectivityChangeReceived(bool connected)
		{
			this.SubscriptionState = (connected ? SubscriptionState.Synced : SubscriptionState.Unsynced);
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00003838 File Offset: 0x00001A38
		~Subscription()
		{
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00003860 File Offset: 0x00001A60
		public void Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x0000386C File Offset: 0x00001A6C
		internal void Dispose(bool disposing)
		{
			if (this.m_Disposed)
			{
				return;
			}
			this.m_Disposed = true;
			try
			{
				if (disposing)
				{
					Action<TaskCompletionSource<bool>> unsubscribeReceived = this.UnsubscribeReceived;
					if (unsubscribeReceived != null)
					{
						unsubscribeReceived(new TaskCompletionSource<bool>());
					}
				}
				else
				{
					Action disposeReceived = this.DisposeReceived;
					if (disposeReceived != null)
					{
						disposeReceived();
					}
				}
			}
			catch (Exception arg)
			{
				Action<string> errorReceived = this.ErrorReceived;
				if (errorReceived != null)
				{
					errorReceived(string.Format("Exception raised during disposal of the Channel: ${0}", arg));
				}
			}
			this.m_TokenProvider = null;
			this.DisposeReceived = null;
			this.UnsubscribeReceived = null;
			this.MessageReceived = null;
			this.BinaryMessageReceived = null;
			this.NewStateReceived = null;
			this.KickReceived = null;
			this.SubscribeReceived = null;
			this.ErrorReceived = null;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00003928 File Offset: 0x00001B28
		public Task SubscribeAsync()
		{
			if (this.m_Disposed)
			{
				throw new ObjectDisposedException(this.ChannelDisplay);
			}
			this.SubscriptionState = SubscriptionState.Subscribing;
			TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
			Action<TaskCompletionSource<bool>> subscribeReceived = this.SubscribeReceived;
			if (subscribeReceived != null)
			{
				subscribeReceived(taskCompletionSource);
			}
			return taskCompletionSource.Task;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00003970 File Offset: 0x00001B70
		public Task UnsubscribeAsync()
		{
			if (this.m_Disposed)
			{
				throw new ObjectDisposedException(this.ChannelDisplay);
			}
			TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
			Action<TaskCompletionSource<bool>> unsubscribeReceived = this.UnsubscribeReceived;
			if (unsubscribeReceived != null)
			{
				unsubscribeReceived(taskCompletionSource);
			}
			return taskCompletionSource.Task;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x000039AF File Offset: 0x00001BAF
		internal void OnError(string reason)
		{
			this.SubscriptionState = SubscriptionState.Error;
			Action<string> errorReceived = this.ErrorReceived;
			if (errorReceived == null)
			{
				return;
			}
			errorReceived(reason);
		}

		// Token: 0x04000083 RID: 131
		public string Channel;

		// Token: 0x04000084 RID: 132
		public ulong Offset;

		// Token: 0x04000085 RID: 133
		public string Epoch;

		// Token: 0x04000086 RID: 134
		private SubscriptionState m_State = SubscriptionState.Unsynced;

		// Token: 0x04000087 RID: 135
		private IChannelTokenProvider m_TokenProvider;

		// Token: 0x04000088 RID: 136
		private bool m_Disposed;
	}
}
