using System;
using System.Collections.Generic;

namespace Unity.Netcode.Components
{
	// Token: 0x02000010 RID: 16
	internal class NetworkAnimatorStateChangeHandler : INetworkUpdateSystem
	{
		// Token: 0x06000057 RID: 87 RVA: 0x000036A4 File Offset: 0x000018A4
		private void FlushMessages()
		{
			foreach (NetworkAnimatorStateChangeHandler.AnimationUpdate animationUpdate in this.m_SendAnimationUpdates)
			{
				this.m_NetworkAnimator.SendAnimStateClientRpc(animationUpdate.AnimationMessage, animationUpdate.ClientRpcParams);
			}
			this.m_SendAnimationUpdates.Clear();
			foreach (NetworkAnimatorStateChangeHandler.ParameterUpdate parameterUpdate in this.m_SendParameterUpdates)
			{
				this.m_NetworkAnimator.SendParametersUpdateClientRpc(parameterUpdate.ParametersUpdateMessage, parameterUpdate.ClientRpcParams);
			}
			this.m_SendParameterUpdates.Clear();
			foreach (NetworkAnimatorStateChangeHandler.TriggerUpdate triggerUpdate in this.m_SendTriggerUpdates)
			{
				if (!triggerUpdate.SendToServer)
				{
					this.m_NetworkAnimator.SendAnimTriggerClientRpc(triggerUpdate.AnimationTriggerMessage, triggerUpdate.ClientRpcParams);
				}
				else
				{
					this.m_NetworkAnimator.SendAnimTriggerServerRpc(triggerUpdate.AnimationTriggerMessage, default(ServerRpcParams));
				}
			}
			this.m_SendTriggerUpdates.Clear();
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000037F8 File Offset: 0x000019F8
		public void NetworkUpdate(NetworkUpdateStage updateStage)
		{
			if (updateStage == NetworkUpdateStage.PreUpdate)
			{
				if (this.m_NetworkAnimator.IsOwner || this.m_IsServer)
				{
					this.FlushMessages();
				}
				for (int i = 0; i < this.m_ProcessParameterUpdates.Count; i++)
				{
					NetworkAnimator.ParametersUpdateMessage parametersUpdateMessage = this.m_ProcessParameterUpdates[i];
					this.m_NetworkAnimator.UpdateParameters(ref parametersUpdateMessage);
				}
				this.m_ProcessParameterUpdates.Clear();
				bool flag = this.m_NetworkAnimator.IsServerAuthoritative();
				if ((!flag && this.m_NetworkAnimator.IsOwner) || (flag && this.m_NetworkAnimator.IsServer))
				{
					this.m_NetworkAnimator.CheckForAnimatorChanges();
				}
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0000389C File Offset: 0x00001A9C
		internal void SendAnimationUpdate(NetworkAnimator.AnimationMessage animationMessage, ClientRpcParams clientRpcParams = default(ClientRpcParams))
		{
			this.m_SendAnimationUpdates.Add(new NetworkAnimatorStateChangeHandler.AnimationUpdate
			{
				ClientRpcParams = clientRpcParams,
				AnimationMessage = animationMessage
			});
		}

		// Token: 0x0600005A RID: 90 RVA: 0x000038D0 File Offset: 0x00001AD0
		internal void SendParameterUpdate(NetworkAnimator.ParametersUpdateMessage parametersUpdateMessage, ClientRpcParams clientRpcParams = default(ClientRpcParams))
		{
			this.m_SendParameterUpdates.Add(new NetworkAnimatorStateChangeHandler.ParameterUpdate
			{
				ClientRpcParams = clientRpcParams,
				ParametersUpdateMessage = parametersUpdateMessage
			});
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00003901 File Offset: 0x00001B01
		internal void ProcessParameterUpdate(NetworkAnimator.ParametersUpdateMessage parametersUpdateMessage)
		{
			this.m_ProcessParameterUpdates.Add(parametersUpdateMessage);
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00003910 File Offset: 0x00001B10
		internal void QueueTriggerUpdateToClient(NetworkAnimator.AnimationTriggerMessage animationTriggerMessage, ClientRpcParams clientRpcParams = default(ClientRpcParams))
		{
			this.m_SendTriggerUpdates.Add(new NetworkAnimatorStateChangeHandler.TriggerUpdate
			{
				ClientRpcParams = clientRpcParams,
				AnimationTriggerMessage = animationTriggerMessage
			});
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00003944 File Offset: 0x00001B44
		internal void QueueTriggerUpdateToServer(NetworkAnimator.AnimationTriggerMessage animationTriggerMessage)
		{
			this.m_SendTriggerUpdates.Add(new NetworkAnimatorStateChangeHandler.TriggerUpdate
			{
				AnimationTriggerMessage = animationTriggerMessage,
				SendToServer = true
			});
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003975 File Offset: 0x00001B75
		internal void DeregisterUpdate()
		{
			this.UnregisterNetworkUpdate(NetworkUpdateStage.PreUpdate);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00003980 File Offset: 0x00001B80
		internal NetworkAnimatorStateChangeHandler(NetworkAnimator networkAnimator)
		{
			this.m_NetworkAnimator = networkAnimator;
			this.m_IsServer = networkAnimator.NetworkManager.IsServer;
			this.RegisterNetworkUpdate(NetworkUpdateStage.PreUpdate);
		}

		// Token: 0x0400003C RID: 60
		private NetworkAnimator m_NetworkAnimator;

		// Token: 0x0400003D RID: 61
		private bool m_IsServer;

		// Token: 0x0400003E RID: 62
		private List<NetworkAnimatorStateChangeHandler.AnimationUpdate> m_SendAnimationUpdates = new List<NetworkAnimatorStateChangeHandler.AnimationUpdate>();

		// Token: 0x0400003F RID: 63
		private List<NetworkAnimatorStateChangeHandler.ParameterUpdate> m_SendParameterUpdates = new List<NetworkAnimatorStateChangeHandler.ParameterUpdate>();

		// Token: 0x04000040 RID: 64
		private List<NetworkAnimator.ParametersUpdateMessage> m_ProcessParameterUpdates = new List<NetworkAnimator.ParametersUpdateMessage>();

		// Token: 0x04000041 RID: 65
		private List<NetworkAnimatorStateChangeHandler.TriggerUpdate> m_SendTriggerUpdates = new List<NetworkAnimatorStateChangeHandler.TriggerUpdate>();

		// Token: 0x02000011 RID: 17
		private struct AnimationUpdate
		{
			// Token: 0x04000042 RID: 66
			public ClientRpcParams ClientRpcParams;

			// Token: 0x04000043 RID: 67
			public NetworkAnimator.AnimationMessage AnimationMessage;
		}

		// Token: 0x02000012 RID: 18
		private struct ParameterUpdate
		{
			// Token: 0x04000044 RID: 68
			public ClientRpcParams ClientRpcParams;

			// Token: 0x04000045 RID: 69
			public NetworkAnimator.ParametersUpdateMessage ParametersUpdateMessage;
		}

		// Token: 0x02000013 RID: 19
		private struct TriggerUpdate
		{
			// Token: 0x04000046 RID: 70
			public bool SendToServer;

			// Token: 0x04000047 RID: 71
			public ClientRpcParams ClientRpcParams;

			// Token: 0x04000048 RID: 72
			public NetworkAnimator.AnimationTriggerMessage AnimationTriggerMessage;
		}
	}
}
