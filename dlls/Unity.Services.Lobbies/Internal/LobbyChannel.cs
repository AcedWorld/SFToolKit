using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Lobbies.Models;
using Unity.Services.Wire.Internal;

namespace Unity.Services.Lobbies.Internal
{
	// Token: 0x02000028 RID: 40
	internal class LobbyChannel : ILobbyEvents
	{
		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000119 RID: 281 RVA: 0x000051AB File Offset: 0x000033AB
		public LobbyEventCallbacks Callbacks { get; }

		// Token: 0x0600011A RID: 282 RVA: 0x000051B4 File Offset: 0x000033B4
		internal LobbyChannel(IChannel channel, LobbyEventCallbacks callbacks, string lobbyId, ILobbyService lobbyService)
		{
			LobbyChannel.<>c__DisplayClass10_0 CS$<>8__locals1 = new LobbyChannel.<>c__DisplayClass10_0();
			CS$<>8__locals1.callbacks = callbacks;
			base..ctor();
			CS$<>8__locals1.<>4__this = this;
			this.channelSubscription = channel;
			this.Callbacks = CS$<>8__locals1.callbacks;
			this.eventProcessQueue = new SortedList<int, ILobbyChanges>();
			this.lobbyId = lobbyId;
			this.lobbyService = lobbyService;
			this.channelSubscription.MessageReceived += delegate(string payload)
			{
				LobbyChannel.<>c__DisplayClass10_0.<<-ctor>b__0>d <<-ctor>b__0>d;
				<<-ctor>b__0>d.<>t__builder = AsyncVoidMethodBuilder.Create();
				<<-ctor>b__0>d.<>4__this = CS$<>8__locals1;
				<<-ctor>b__0>d.payload = payload;
				<<-ctor>b__0>d.<>1__state = -1;
				<<-ctor>b__0>d.<>t__builder.Start<LobbyChannel.<>c__DisplayClass10_0.<<-ctor>b__0>d>(ref <<-ctor>b__0>d);
			};
			this.channelSubscription.KickReceived += delegate()
			{
				CS$<>8__locals1.<>4__this.OnLobbySubscriptionKick(CS$<>8__locals1.callbacks);
			};
			this.channelSubscription.NewStateReceived += delegate(SubscriptionState state)
			{
				CS$<>8__locals1.<>4__this.OnLobbySubscriptionNewState(state, CS$<>8__locals1.callbacks);
			};
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00005264 File Offset: 0x00003464
		public Task SubscribeAsync()
		{
			LobbyChannel.<SubscribeAsync>d__11 <SubscribeAsync>d__;
			<SubscribeAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<SubscribeAsync>d__.<>4__this = this;
			<SubscribeAsync>d__.<>1__state = -1;
			<SubscribeAsync>d__.<>t__builder.Start<LobbyChannel.<SubscribeAsync>d__11>(ref <SubscribeAsync>d__);
			return <SubscribeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x000052A8 File Offset: 0x000034A8
		public Task UnsubscribeAsync()
		{
			LobbyChannel.<UnsubscribeAsync>d__12 <UnsubscribeAsync>d__;
			<UnsubscribeAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<UnsubscribeAsync>d__.<>4__this = this;
			<UnsubscribeAsync>d__.<>1__state = -1;
			<UnsubscribeAsync>d__.<>t__builder.Start<LobbyChannel.<UnsubscribeAsync>d__12>(ref <UnsubscribeAsync>d__);
			return <UnsubscribeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600011D RID: 285 RVA: 0x000052EC File Offset: 0x000034EC
		private Task OnLobbySubscriptionMessage(string payload, LobbyEventCallbacks callbacks)
		{
			LobbyChannel.<OnLobbySubscriptionMessage>d__13 <OnLobbySubscriptionMessage>d__;
			<OnLobbySubscriptionMessage>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<OnLobbySubscriptionMessage>d__.<>4__this = this;
			<OnLobbySubscriptionMessage>d__.payload = payload;
			<OnLobbySubscriptionMessage>d__.callbacks = callbacks;
			<OnLobbySubscriptionMessage>d__.<>1__state = -1;
			<OnLobbySubscriptionMessage>d__.<>t__builder.Start<LobbyChannel.<OnLobbySubscriptionMessage>d__13>(ref <OnLobbySubscriptionMessage>d__);
			return <OnLobbySubscriptionMessage>d__.<>t__builder.Task;
		}

		// Token: 0x0600011E RID: 286 RVA: 0x0000533F File Offset: 0x0000353F
		private void OnLobbySubscriptionKick(LobbyEventCallbacks callbacks)
		{
			callbacks.InvokeKickedFromLobby();
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00005348 File Offset: 0x00003548
		private void OnLobbySubscriptionNewState(SubscriptionState state, LobbyEventCallbacks callbacks)
		{
			switch (state)
			{
			case SubscriptionState.Unsubscribed:
				callbacks.InvokeLobbyEventConnectionStateChanged(LobbyEventConnectionState.Unsubscribed);
				return;
			case SubscriptionState.Synced:
				callbacks.InvokeLobbyEventConnectionStateChanged(LobbyEventConnectionState.Subscribed);
				return;
			case SubscriptionState.Unsynced:
				callbacks.InvokeLobbyEventConnectionStateChanged(LobbyEventConnectionState.Unsynced);
				return;
			case SubscriptionState.Error:
				callbacks.InvokeLobbyEventConnectionStateChanged(LobbyEventConnectionState.Error);
				return;
			case SubscriptionState.Subscribing:
				callbacks.InvokeLobbyEventConnectionStateChanged(LobbyEventConnectionState.Subscribing);
				return;
			default:
				callbacks.InvokeLobbyEventConnectionStateChanged(LobbyEventConnectionState.Unknown);
				return;
			}
		}

		// Token: 0x06000120 RID: 288 RVA: 0x000053A0 File Offset: 0x000035A0
		private Task HandleLobbyChanges(ILobbyChanges changes, LobbyEventCallbacks callbacks)
		{
			LobbyChannel.<HandleLobbyChanges>d__16 <HandleLobbyChanges>d__;
			<HandleLobbyChanges>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<HandleLobbyChanges>d__.<>4__this = this;
			<HandleLobbyChanges>d__.changes = changes;
			<HandleLobbyChanges>d__.callbacks = callbacks;
			<HandleLobbyChanges>d__.<>1__state = -1;
			<HandleLobbyChanges>d__.<>t__builder.Start<LobbyChannel.<HandleLobbyChanges>d__16>(ref <HandleLobbyChanges>d__);
			return <HandleLobbyChanges>d__.<>t__builder.Task;
		}

		// Token: 0x06000121 RID: 289 RVA: 0x000053F4 File Offset: 0x000035F4
		private Task ProcessEvent(ILobbyChanges nextToProcess, LobbyEventCallbacks callbacks)
		{
			LobbyChannel.<ProcessEvent>d__17 <ProcessEvent>d__;
			<ProcessEvent>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<ProcessEvent>d__.<>4__this = this;
			<ProcessEvent>d__.nextToProcess = nextToProcess;
			<ProcessEvent>d__.callbacks = callbacks;
			<ProcessEvent>d__.<>1__state = -1;
			<ProcessEvent>d__.<>t__builder.Start<LobbyChannel.<ProcessEvent>d__17>(ref <ProcessEvent>d__);
			return <ProcessEvent>d__.<>t__builder.Task;
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00005448 File Offset: 0x00003648
		private bool ResolveTrivialEvent(ILobbyChanges changes, LobbyEventCallbacks callbacks, Lobby cachedLobby)
		{
			if (cachedLobby == null)
			{
				return false;
			}
			int value = changes.Version.Value;
			if (value <= cachedLobby.Version)
			{
				return true;
			}
			if (value == cachedLobby.Version + 1)
			{
				if (!this.WasRemovedFromLobby(changes, cachedLobby))
				{
					changes.ApplyToLobby(cachedLobby);
				}
				callbacks.InvokeLobbyChanged(changes);
				return true;
			}
			return false;
		}

		// Token: 0x06000123 RID: 291 RVA: 0x0000549C File Offset: 0x0000369C
		private bool WasRemovedFromLobby(ILobbyChanges changes, Lobby cachedLobby)
		{
			Dictionary<string, Lobby> lobbyCache = (this.lobbyService as ILobbyServiceInternal).GetLobbyCache();
			if (cachedLobby == null || !changes.PlayerLeft.Changed)
			{
				return false;
			}
			foreach (int index in changes.PlayerLeft.Value)
			{
				if (cachedLobby.Players[index].Id.Equals(AuthenticationService.Instance.PlayerId))
				{
					lobbyCache.Remove(this.lobbyId);
					return true;
				}
			}
			return false;
		}

		// Token: 0x0400009D RID: 157
		private readonly IChannel channelSubscription;

		// Token: 0x0400009E RID: 158
		private int mostRecentEventVersion;

		// Token: 0x0400009F RID: 159
		private readonly string lobbyId;

		// Token: 0x040000A0 RID: 160
		private readonly ILobbyService lobbyService;

		// Token: 0x040000A1 RID: 161
		private readonly SortedList<int, ILobbyChanges> eventProcessQueue;

		// Token: 0x040000A2 RID: 162
		private readonly object eventLock = new object();

		// Token: 0x040000A3 RID: 163
		private readonly object mostRecentEventVersionLock = new object();
	}
}
