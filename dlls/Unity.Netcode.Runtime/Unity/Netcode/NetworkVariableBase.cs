using System;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x020000BA RID: 186
	public abstract class NetworkVariableBase : IDisposable
	{
		// Token: 0x0600043E RID: 1086 RVA: 0x00014323 File Offset: 0x00012523
		public NetworkBehaviour GetBehaviour()
		{
			return this.m_NetworkBehaviour;
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x0001432C File Offset: 0x0001252C
		internal string GetWritePermissionError()
		{
			return string.Format("|Client-{0}|{1}|{2}| Write permissions ({3}) for this client instance is not allowed!", new object[]
			{
				this.m_NetworkManager.LocalClientId,
				this.m_NetworkBehaviour.name,
				this.Name,
				this.WritePerm
			});
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x00014381 File Offset: 0x00012581
		internal void LogWritePermissionError()
		{
			Debug.LogError(this.GetWritePermissionError());
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x00014390 File Offset: 0x00012590
		private protected NetworkManager m_NetworkManager
		{
			get
			{
				if (this.m_InternalNetworkManager == null && this.m_NetworkBehaviour)
				{
					NetworkObject networkObject = this.m_NetworkBehaviour.NetworkObject;
					if ((networkObject != null) ? networkObject.NetworkManager : null)
					{
						NetworkObject networkObject2 = this.m_NetworkBehaviour.NetworkObject;
						this.m_InternalNetworkManager = ((networkObject2 != null) ? networkObject2.NetworkManager : null);
					}
				}
				return this.m_InternalNetworkManager;
			}
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x000143FC File Offset: 0x000125FC
		public void Initialize(NetworkBehaviour networkBehaviour)
		{
			this.m_InternalNetworkManager = null;
			this.m_NetworkBehaviour = networkBehaviour;
			if (this.m_NetworkBehaviour)
			{
				NetworkObject networkObject = this.m_NetworkBehaviour.NetworkObject;
				if ((networkObject != null) ? networkObject.NetworkManager : null)
				{
					NetworkObject networkObject2 = this.m_NetworkBehaviour.NetworkObject;
					this.m_InternalNetworkManager = ((networkObject2 != null) ? networkObject2.NetworkManager : null);
					if (this.m_NetworkBehaviour.NetworkManager.NetworkTimeSystem != null)
					{
						this.UpdateLastSentTime();
					}
				}
			}
			this.OnInitialize();
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x00004E3E File Offset: 0x0000303E
		public virtual void OnInitialize()
		{
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x0001447D File Offset: 0x0001267D
		public void SetUpdateTraits(NetworkVariableUpdateTraits traits)
		{
			this.UpdateTraits = traits;
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x0000C36D File Offset: 0x0000A56D
		public virtual bool ExceedsDirtinessThreshold()
		{
			return true;
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x00014486 File Offset: 0x00012686
		protected NetworkVariableBase(NetworkVariableReadPermission readPerm = NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission writePerm = NetworkVariableWritePermission.Server)
		{
			this.ReadPerm = readPerm;
			this.WritePerm = writePerm;
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000447 RID: 1095 RVA: 0x0001449C File Offset: 0x0001269C
		// (set) Token: 0x06000448 RID: 1096 RVA: 0x000144A4 File Offset: 0x000126A4
		public string Name { get; internal set; }

		// Token: 0x06000449 RID: 1097 RVA: 0x000144AD File Offset: 0x000126AD
		public virtual void SetDirty(bool isDirty)
		{
			this.m_IsDirty = isDirty;
			if (this.m_IsDirty)
			{
				this.MarkNetworkBehaviourDirty();
			}
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x000144C4 File Offset: 0x000126C4
		internal bool CanSend()
		{
			double num = this.m_NetworkBehaviour.NetworkManager.NetworkTimeSystem.LocalTime - this.LastUpdateSent;
			return (this.UpdateTraits.MaxSecondsBetweenUpdates > 0f && num >= (double)this.UpdateTraits.MaxSecondsBetweenUpdates) || (num >= (double)this.UpdateTraits.MinSecondsBetweenUpdates && this.ExceedsDirtinessThreshold());
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x00014528 File Offset: 0x00012728
		internal void UpdateLastSentTime()
		{
			this.LastUpdateSent = this.m_NetworkBehaviour.NetworkManager.NetworkTimeSystem.LocalTime;
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x00014548 File Offset: 0x00012748
		protected void MarkNetworkBehaviourDirty()
		{
			if (this.m_NetworkBehaviour == null)
			{
				Debug.LogWarning("NetworkVariable is written to, but doesn't know its NetworkBehaviour yet. Are you modifying a NetworkVariable before the NetworkObject is spawned?");
				return;
			}
			if (this.m_NetworkBehaviour.NetworkManager.ShutdownInProgress)
			{
				if (this.m_NetworkBehaviour.NetworkManager.LogLevel <= LogLevel.Developer)
				{
					Debug.LogWarning("NetworkVariable is written to during the NetworkManager shutdown! Are you modifying a NetworkVariable within a NetworkBehaviour.OnDestroy or NetworkBehaviour.OnDespawn method?");
				}
				return;
			}
			if (!this.m_NetworkBehaviour.NetworkManager.IsListening)
			{
				if (this.m_NetworkBehaviour.NetworkManager.LogLevel <= LogLevel.Developer)
				{
					Debug.LogWarning("NetworkVariable is written to after the NetworkManager has already shutdown! Are you modifying a NetworkVariable within a NetworkBehaviour.OnDestroy or NetworkBehaviour.OnDespawn method?");
				}
				return;
			}
			this.m_NetworkBehaviour.NetworkManager.BehaviourUpdater.AddForUpdate(this.m_NetworkBehaviour.NetworkObject);
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x000145EE File Offset: 0x000127EE
		public virtual void ResetDirty()
		{
			this.m_IsDirty = false;
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x000145F7 File Offset: 0x000127F7
		public virtual bool IsDirty()
		{
			return this.m_IsDirty;
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x00014600 File Offset: 0x00012800
		public bool CanClientRead(ulong clientId)
		{
			if (!this.m_NetworkBehaviour)
			{
				return false;
			}
			NetworkVariableReadPermission readPerm = this.ReadPerm;
			return readPerm == NetworkVariableReadPermission.Everyone || readPerm != NetworkVariableReadPermission.Owner || clientId == this.m_NetworkBehaviour.NetworkObject.OwnerClientId || clientId == 0UL;
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x00014648 File Offset: 0x00012848
		public bool CanClientWrite(ulong clientId)
		{
			if (!this.m_NetworkBehaviour)
			{
				return false;
			}
			NetworkVariableWritePermission writePerm = this.WritePerm;
			if (writePerm == NetworkVariableWritePermission.Server || writePerm != NetworkVariableWritePermission.Owner)
			{
				return clientId == 0UL;
			}
			return clientId == this.m_NetworkBehaviour.NetworkObject.OwnerClientId;
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x0001468B File Offset: 0x0001288B
		internal ulong OwnerClientId()
		{
			return this.m_NetworkBehaviour.NetworkObject.OwnerClientId;
		}

		// Token: 0x06000452 RID: 1106
		public abstract void WriteDelta(FastBufferWriter writer);

		// Token: 0x06000453 RID: 1107
		public abstract void WriteField(FastBufferWriter writer);

		// Token: 0x06000454 RID: 1108
		public abstract void ReadField(FastBufferReader reader);

		// Token: 0x06000455 RID: 1109
		public abstract void ReadDelta(FastBufferReader reader, bool keepDirtyDelta);

		// Token: 0x06000456 RID: 1110 RVA: 0x00004E3E File Offset: 0x0000303E
		internal virtual void PostDeltaRead()
		{
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x0001469D File Offset: 0x0001289D
		internal virtual void WriteFieldSynchronization(FastBufferWriter writer)
		{
			this.WriteField(writer);
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x00004E3E File Offset: 0x0000303E
		public virtual void Dispose()
		{
		}

		// Token: 0x04000253 RID: 595
		[SerializeField]
		internal NetworkVariableUpdateTraits UpdateTraits;

		// Token: 0x04000254 RID: 596
		[NonSerialized]
		internal double LastUpdateSent;

		// Token: 0x04000255 RID: 597
		internal const NetworkDelivery Delivery = NetworkDelivery.ReliableFragmentedSequenced;

		// Token: 0x04000256 RID: 598
		private protected NetworkBehaviour m_NetworkBehaviour;

		// Token: 0x04000257 RID: 599
		private NetworkManager m_InternalNetworkManager;

		// Token: 0x04000258 RID: 600
		public const NetworkVariableReadPermission DefaultReadPerm = NetworkVariableReadPermission.Everyone;

		// Token: 0x04000259 RID: 601
		public const NetworkVariableWritePermission DefaultWritePerm = NetworkVariableWritePermission.Server;

		// Token: 0x0400025A RID: 602
		private bool m_IsDirty;

		// Token: 0x0400025C RID: 604
		public readonly NetworkVariableReadPermission ReadPerm;

		// Token: 0x0400025D RID: 605
		public readonly NetworkVariableWritePermission WritePerm;

		// Token: 0x0400025E RID: 606
		internal bool NetworkUpdaterCheck;
	}
}
