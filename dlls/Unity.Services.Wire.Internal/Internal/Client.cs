using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Unity.Services.Core.Internal;
using Unity.Services.Core.Scheduler.Internal;
using Unity.Services.Core.Telemetry.Internal;
using Unity.Services.Core.Threading.Internal;
using Unity.Services.Wire.Protocol.Internal;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x02000016 RID: 22
	internal class Client : IWire, IServiceComponent
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000031 RID: 49 RVA: 0x00002468 File Offset: 0x00000668
		// (remove) Token: 0x06000032 RID: 50 RVA: 0x000024A0 File Offset: 0x000006A0
		private event Action m_OnConnected;

		// Token: 0x06000033 RID: 51 RVA: 0x000024D8 File Offset: 0x000006D8
		public Client(Configuration config, IActionScheduler actionScheduler, IMetrics metrics, IUnityThreadUtils threadUtils, IWebsocketFactory websocketFactory)
		{
			this.k_PongMessage = Encoding.UTF8.GetBytes("{}");
			this.m_ThreadUtils = threadUtils;
			this.m_Config = config;
			this.m_Metrics = metrics;
			this.m_ActionScheduler = actionScheduler;
			this.m_WebsocketFactory = websocketFactory;
			this.SubscriptionRepository = new ConcurrentDictSubscriptionRepository();
			this.SubscriptionRepository.SubscriptionCountChanged += delegate(int subscriptionCount)
			{
				this.m_Metrics.SendGaugeMetric("subscription_count", (double)subscriptionCount, null);
			};
			this.m_Backoff = new ExponentialBackoffStrategy();
			this.m_CommandManager = new CommandManager(config, actionScheduler);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002560 File Offset: 0x00000760
		private Task<Reply> SendCommandAsync(uint id, Command command)
		{
			Client.<SendCommandAsync>d__23 <SendCommandAsync>d__;
			<SendCommandAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Reply>.Create();
			<SendCommandAsync>d__.<>4__this = this;
			<SendCommandAsync>d__.id = id;
			<SendCommandAsync>d__.command = command;
			<SendCommandAsync>d__.<>1__state = -1;
			<SendCommandAsync>d__.<>t__builder.Start<Client.<SendCommandAsync>d__23>(ref <SendCommandAsync>d__);
			return <SendCommandAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000025B3 File Offset: 0x000007B3
		internal void OnIdentityChanged(string playerId)
		{
			if (this.m_Disabled)
			{
				return;
			}
			this.m_ThreadUtils.Send<Task>(delegate()
			{
				Client.<<OnIdentityChanged>b__24_0>d <<OnIdentityChanged>b__24_0>d;
				<<OnIdentityChanged>b__24_0>d.<>t__builder = AsyncTaskMethodBuilder.Create();
				<<OnIdentityChanged>b__24_0>d.<>4__this = this;
				<<OnIdentityChanged>b__24_0>d.<>1__state = -1;
				<<OnIdentityChanged>b__24_0>d.<>t__builder.Start<Client.<<OnIdentityChanged>b__24_0>d>(ref <<OnIdentityChanged>b__24_0>d);
				return <<OnIdentityChanged>b__24_0>d.<>t__builder.Task;
			});
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000025D8 File Offset: 0x000007D8
		internal Task DisconnectAsync()
		{
			Client.<DisconnectAsync>d__25 <DisconnectAsync>d__;
			<DisconnectAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<DisconnectAsync>d__.<>4__this = this;
			<DisconnectAsync>d__.<>1__state = -1;
			<DisconnectAsync>d__.<>t__builder.Start<Client.<DisconnectAsync>d__25>(ref <DisconnectAsync>d__);
			return <DisconnectAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0000261C File Offset: 0x0000081C
		internal Task ResetAsync(bool reconnect)
		{
			Client.<ResetAsync>d__26 <ResetAsync>d__;
			<ResetAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<ResetAsync>d__.<>4__this = this;
			<ResetAsync>d__.reconnect = reconnect;
			<ResetAsync>d__.<>1__state = -1;
			<ResetAsync>d__.<>t__builder.Start<Client.<ResetAsync>d__26>(ref <ResetAsync>d__);
			return <ResetAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002668 File Offset: 0x00000868
		public Task ConnectAsync()
		{
			Client.<ConnectAsync>d__27 <ConnectAsync>d__;
			<ConnectAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<ConnectAsync>d__.<>4__this = this;
			<ConnectAsync>d__.<>1__state = -1;
			<ConnectAsync>d__.<>t__builder.Start<Client.<ConnectAsync>d__27>(ref <ConnectAsync>d__);
			return <ConnectAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000026AC File Offset: 0x000008AC
		internal void OnWebsocketOpen()
		{
			Client.<OnWebsocketOpen>d__28 <OnWebsocketOpen>d__;
			<OnWebsocketOpen>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnWebsocketOpen>d__.<>4__this = this;
			<OnWebsocketOpen>d__.<>1__state = -1;
			<OnWebsocketOpen>d__.<>t__builder.Start<Client.<OnWebsocketOpen>d__28>(ref <OnWebsocketOpen>d__);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000026E3 File Offset: 0x000008E3
		private void SetupPingDeadline()
		{
			if (this.m_ServerPingIntervalS != 0U)
			{
				this.m_PingDeadlineScheduledId = this.m_ActionScheduler.ScheduleAction(new Action(this.PingDeadline), this.m_ServerPingIntervalS + (uint)this.m_Config.MaxServerPingDelay);
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x0000271F File Offset: 0x0000091F
		private void CancelPingDeadline()
		{
			if (this.m_PingDeadlineScheduledId != 0L)
			{
				this.m_ActionScheduler.CancelAction(this.m_PingDeadlineScheduledId);
				this.m_PingDeadlineScheduledId = 0L;
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002742 File Offset: 0x00000942
		private void PingDeadline()
		{
			this.m_PingDeadlineScheduledId = 0L;
			if (this.m_ConnectionState != Client.ConnectionState.Connected)
			{
				return;
			}
			this.m_WebsocketClient.Close(WebSocketCloseCode.Normal, null);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002768 File Offset: 0x00000968
		internal void OnWebsocketMessage(byte[] payload)
		{
			IEnumerable<string> enumerable = BatchMessagesUtil.SplitMessages(payload);
			this.m_Metrics.SendSumMetric("message_received", (double)enumerable.Count<string>(), null);
			foreach (string jsonData in enumerable)
			{
				Reply reply = Reply.FromJson(jsonData);
				if (reply.id > 0U)
				{
					this.HandleCommandReply(reply);
				}
				else
				{
					if (reply.push != null)
					{
						try
						{
							this.HandlePushMessage(reply.push);
							continue;
						}
						catch (NotImplementedException)
						{
							continue;
						}
						catch (Exception)
						{
							continue;
						}
					}
					this.HandleServerPing();
				}
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x0000281C File Offset: 0x00000A1C
		private void HandleServerPing()
		{
			this.CancelPingDeadline();
			if (this.m_Pong)
			{
				this.m_WebsocketClient.Send(this.k_PongMessage);
			}
			this.SetupPingDeadline();
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002843 File Offset: 0x00000A43
		private void OnWebsocketError(string msg)
		{
			this.m_Metrics.SendSumMetric("websocket_error", 1.0, null);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002860 File Offset: 0x00000A60
		internal void OnWebsocketClose(WebSocketCloseCode originalCode)
		{
			Client.<OnWebsocketClose>d__35 <OnWebsocketClose>d__;
			<OnWebsocketClose>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnWebsocketClose>d__.<>4__this = this;
			<OnWebsocketClose>d__.originalCode = originalCode;
			<OnWebsocketClose>d__.<>1__state = -1;
			<OnWebsocketClose>d__.<>t__builder.Start<Client.<OnWebsocketClose>d__35>(ref <OnWebsocketClose>d__);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000028A0 File Offset: 0x00000AA0
		private void InitWebsocket()
		{
			if (this.m_WebsocketClient != null)
			{
				this.m_WebsocketClient.OnOpen -= this.WebsocketOpenListener;
				this.m_WebsocketClient.OnMessage -= this.WebsocketMessageListener;
				this.m_WebsocketClient.OnError -= this.WebsocketErrorListener;
				this.m_WebsocketClient.OnClose -= this.WebsocketCloseListener;
			}
			this.m_WebsocketClient = this.m_WebsocketFactory.CreateInstance(this.m_Config.address);
			this.m_WebsocketClient.OnOpen += this.WebsocketOpenListener;
			this.m_WebsocketClient.OnMessage += this.WebsocketMessageListener;
			this.m_WebsocketClient.OnError += this.WebsocketErrorListener;
			this.m_WebsocketClient.OnClose += this.WebsocketCloseListener;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x0000298C File Offset: 0x00000B8C
		private bool ShouldReconnect(CentrifugeCloseCode code)
		{
			if (code != CentrifugeCloseCode.WebsocketNotSet)
			{
				switch (code)
				{
				case CentrifugeCloseCode.WebsocketNormal:
				case CentrifugeCloseCode.WebsocketAway:
				case CentrifugeCloseCode.WebsocketProtocolError:
				case CentrifugeCloseCode.WebsocketUndefined:
				case CentrifugeCloseCode.WebsocketNoStatus:
				case CentrifugeCloseCode.WebsocketAbnormal:
				case CentrifugeCloseCode.WebsocketInvalidData:
				case CentrifugeCloseCode.WebsocketPolicyViolation:
				case CentrifugeCloseCode.WebsocketTooBig:
				case CentrifugeCloseCode.WebsocketServerError:
				case (CentrifugeCloseCode)1012:
				case (CentrifugeCloseCode)1013:
				case (CentrifugeCloseCode)1014:
				case CentrifugeCloseCode.WebsocketTlsHandshakeFailure:
					return true;
				case CentrifugeCloseCode.WebsocketUnsupportedData:
				case CentrifugeCloseCode.WebsocketMandatoryExtension:
					break;
				default:
					switch (code)
					{
					case CentrifugeCloseCode.Normal:
					case CentrifugeCloseCode.Shutdown:
					case CentrifugeCloseCode.BadRequest:
					case CentrifugeCloseCode.InternalServerError:
					case CentrifugeCloseCode.Expired:
					case CentrifugeCloseCode.SubscriptionExpired:
					case CentrifugeCloseCode.Stale:
					case CentrifugeCloseCode.Slow:
					case CentrifugeCloseCode.WriteError:
					case CentrifugeCloseCode.InsufficientState:
					case CentrifugeCloseCode.ForceReconnect:
					case CentrifugeCloseCode.ConnectionLimit:
					case CentrifugeCloseCode.ChannelLimit:
						return true;
					case CentrifugeCloseCode.InvalidToken:
					case CentrifugeCloseCode.ForceNoReconnect:
						break;
					default:
						return true;
					}
					break;
				}
				return false;
			}
			return true;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002A38 File Offset: 0x00000C38
		private void ChangeConnectionState(Client.ConnectionState state)
		{
			Dictionary<string, string> tags = new Dictionary<string, string>
			{
				{
					"state",
					state.ToString()
				}
			};
			this.m_Metrics.SendSumMetric("connection_state_change", 1.0, tags);
			this.m_ConnectionState = state;
			switch (state)
			{
			case Client.ConnectionState.Disconnected:
				this.SubscriptionRepository.OnSocketClosed();
				return;
			case Client.ConnectionState.Connected:
			{
				this.m_ConnectionCompletionSource.SetResult(Client.ConnectionState.Connected);
				this.m_ConnectionCompletionSource = null;
				Action onConnected = this.m_OnConnected;
				if (onConnected != null)
				{
					onConnected();
				}
				this.m_OnConnected = null;
				return;
			}
			case Client.ConnectionState.Connecting:
				this.m_ConnectionCompletionSource = new TaskCompletionSource<Client.ConnectionState>();
				return;
			case Client.ConnectionState.Disconnecting:
				return;
			default:
				throw new NotImplementedException();
			}
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002AE8 File Offset: 0x00000CE8
		private void HandlePushMessage(Push push)
		{
			Dictionary<string, string> tags = new Dictionary<string, string>
			{
				{
					"push_type",
					push.GetPushType()
				}
			};
			this.m_Metrics.SendSumMetric("push_received", 1.0, tags);
			if (push.IsUnsub())
			{
				Subscription sub = this.SubscriptionRepository.GetSub(push.channel);
				if (sub != null)
				{
					sub.OnKickReceived();
					this.SubscriptionRepository.RemoveSub(sub);
				}
				return;
			}
			if (push.IsPub())
			{
				Subscription sub2 = this.SubscriptionRepository.GetSub(push.channel);
				if (sub2 != null)
				{
					sub2.ProcessPublication(push.pub);
				}
				return;
			}
			throw new NotImplementedException();
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002B85 File Offset: 0x00000D85
		private void HandleCommandReply(Reply reply)
		{
			this.m_CommandManager.OnCommandReplyReceived(reply);
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002B94 File Offset: 0x00000D94
		private Task SubscribeAsync(Subscription subscription)
		{
			Client.<SubscribeAsync>d__41 <SubscribeAsync>d__;
			<SubscribeAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<SubscribeAsync>d__.<>4__this = this;
			<SubscribeAsync>d__.subscription = subscription;
			<SubscribeAsync>d__.<>1__state = -1;
			<SubscribeAsync>d__.<>t__builder.Start<Client.<SubscribeAsync>d__41>(ref <SubscribeAsync>d__);
			return <SubscribeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002BE0 File Offset: 0x00000DE0
		public IChannel CreateChannel(IChannelTokenProvider tokenProvider)
		{
			Client.<>c__DisplayClass42_0 CS$<>8__locals1 = new Client.<>c__DisplayClass42_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.subscription = new Subscription(tokenProvider);
			CS$<>8__locals1.subscription.UnsubscribeReceived += delegate(TaskCompletionSource<bool> completionSource)
			{
				Client.<>c__DisplayClass42_0.<<CreateChannel>b__0>d <<CreateChannel>b__0>d;
				<<CreateChannel>b__0>d.<>t__builder = AsyncVoidMethodBuilder.Create();
				<<CreateChannel>b__0>d.<>4__this = CS$<>8__locals1;
				<<CreateChannel>b__0>d.completionSource = completionSource;
				<<CreateChannel>b__0>d.<>1__state = -1;
				<<CreateChannel>b__0>d.<>t__builder.Start<Client.<>c__DisplayClass42_0.<<CreateChannel>b__0>d>(ref <<CreateChannel>b__0>d);
			};
			CS$<>8__locals1.subscription.SubscribeReceived += delegate(TaskCompletionSource<bool> completionSource)
			{
				Client.<>c__DisplayClass42_0.<<CreateChannel>b__1>d <<CreateChannel>b__1>d;
				<<CreateChannel>b__1>d.<>t__builder = AsyncVoidMethodBuilder.Create();
				<<CreateChannel>b__1>d.<>4__this = CS$<>8__locals1;
				<<CreateChannel>b__1>d.completionSource = completionSource;
				<<CreateChannel>b__1>d.<>1__state = -1;
				<<CreateChannel>b__1>d.<>t__builder.Start<Client.<>c__DisplayClass42_0.<<CreateChannel>b__1>d>(ref <<CreateChannel>b__1>d);
			};
			CS$<>8__locals1.subscription.KickReceived += delegate()
			{
				CS$<>8__locals1.<>4__this.SubscriptionRepository.RemoveSub(CS$<>8__locals1.subscription);
			};
			CS$<>8__locals1.subscription.DisposeReceived += delegate()
			{
				CS$<>8__locals1.<>4__this.SubscriptionRepository.RemoveSub(CS$<>8__locals1.subscription);
			};
			return CS$<>8__locals1.subscription;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002C68 File Offset: 0x00000E68
		public void Disable()
		{
			this.m_Disabled = true;
			this.m_ThreadUtils.Send<Task>(new Func<Task>(this.DisconnectAsync));
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002C8C File Offset: 0x00000E8C
		private Task UnsubscribeAsync(Subscription subscription)
		{
			Client.<UnsubscribeAsync>d__44 <UnsubscribeAsync>d__;
			<UnsubscribeAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<UnsubscribeAsync>d__.<>4__this = this;
			<UnsubscribeAsync>d__.subscription = subscription;
			<UnsubscribeAsync>d__.<>1__state = -1;
			<UnsubscribeAsync>d__.<>t__builder.Start<Client.<UnsubscribeAsync>d__44>(ref <UnsubscribeAsync>d__);
			return <UnsubscribeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002CD8 File Offset: 0x00000ED8
		private void WebsocketOpenListener()
		{
			Client.<WebsocketOpenListener>d__45 <WebsocketOpenListener>d__;
			<WebsocketOpenListener>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<WebsocketOpenListener>d__.<>4__this = this;
			<WebsocketOpenListener>d__.<>1__state = -1;
			<WebsocketOpenListener>d__.<>t__builder.Start<Client.<WebsocketOpenListener>d__45>(ref <WebsocketOpenListener>d__);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002D10 File Offset: 0x00000F10
		private void WebsocketCloseListener(WebSocketCloseCode code)
		{
			Client.<WebsocketCloseListener>d__46 <WebsocketCloseListener>d__;
			<WebsocketCloseListener>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<WebsocketCloseListener>d__.<>4__this = this;
			<WebsocketCloseListener>d__.code = code;
			<WebsocketCloseListener>d__.<>1__state = -1;
			<WebsocketCloseListener>d__.<>t__builder.Start<Client.<WebsocketCloseListener>d__46>(ref <WebsocketCloseListener>d__);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002D50 File Offset: 0x00000F50
		private void WebsocketErrorListener(string msg)
		{
			Client.<WebsocketErrorListener>d__47 <WebsocketErrorListener>d__;
			<WebsocketErrorListener>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<WebsocketErrorListener>d__.<>4__this = this;
			<WebsocketErrorListener>d__.msg = msg;
			<WebsocketErrorListener>d__.<>1__state = -1;
			<WebsocketErrorListener>d__.<>t__builder.Start<Client.<WebsocketErrorListener>d__47>(ref <WebsocketErrorListener>d__);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002D90 File Offset: 0x00000F90
		private void WebsocketMessageListener(byte[] data)
		{
			Client.<WebsocketMessageListener>d__48 <WebsocketMessageListener>d__;
			<WebsocketMessageListener>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<WebsocketMessageListener>d__.<>4__this = this;
			<WebsocketMessageListener>d__.data = data;
			<WebsocketMessageListener>d__.<>1__state = -1;
			<WebsocketMessageListener>d__.<>t__builder.Start<Client.<WebsocketMessageListener>d__48>(ref <WebsocketMessageListener>d__);
		}

		// Token: 0x04000063 RID: 99
		public readonly ISubscriptionRepository SubscriptionRepository;

		// Token: 0x04000064 RID: 100
		private TaskCompletionSource<Client.ConnectionState> m_ConnectionCompletionSource;

		// Token: 0x04000065 RID: 101
		private TaskCompletionSource<Client.ConnectionState> m_DisconnectionCompletionSource;

		// Token: 0x04000066 RID: 102
		internal Client.ConnectionState m_ConnectionState;

		// Token: 0x04000067 RID: 103
		private IWebSocket m_WebsocketClient;

		// Token: 0x04000068 RID: 104
		internal IBackoffStrategy m_Backoff;

		// Token: 0x04000069 RID: 105
		private readonly CommandManager m_CommandManager;

		// Token: 0x0400006A RID: 106
		private readonly Configuration m_Config;

		// Token: 0x0400006B RID: 107
		private readonly IMetrics m_Metrics;

		// Token: 0x0400006C RID: 108
		private readonly IUnityThreadUtils m_ThreadUtils;

		// Token: 0x0400006D RID: 109
		private readonly IWebsocketFactory m_WebsocketFactory;

		// Token: 0x0400006F RID: 111
		internal bool m_WantConnected;

		// Token: 0x04000070 RID: 112
		internal byte[] k_PongMessage;

		// Token: 0x04000071 RID: 113
		private bool m_Disabled;

		// Token: 0x04000072 RID: 114
		private bool m_Pong;

		// Token: 0x04000073 RID: 115
		private uint m_ServerPingIntervalS;

		// Token: 0x04000074 RID: 116
		private IActionScheduler m_ActionScheduler;

		// Token: 0x04000075 RID: 117
		private long m_PingDeadlineScheduledId;

		// Token: 0x0200003F RID: 63
		internal enum ConnectionState
		{
			// Token: 0x040000CC RID: 204
			Disconnected,
			// Token: 0x040000CD RID: 205
			Connected,
			// Token: 0x040000CE RID: 206
			Connecting,
			// Token: 0x040000CF RID: 207
			Disconnecting
		}
	}
}
