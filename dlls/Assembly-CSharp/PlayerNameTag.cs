using System;
using System.Collections;
using System.Collections.Generic;
using Steamworks;
using TMPro;
using Unity.Netcode;
using UnityEngine;

// Token: 0x0200008A RID: 138
public class PlayerNameTag : NetworkBehaviour
{
	// Token: 0x0600023B RID: 571 RVA: 0x000130A9 File Offset: 0x000112A9
	private void OnEnable()
	{
		if (NetworkManager.Singleton != null)
		{
			NetworkManager.Singleton.OnClientDisconnectCallback += this.HandleClientDisconnected;
		}
	}

	// Token: 0x0600023C RID: 572 RVA: 0x000130CE File Offset: 0x000112CE
	private void OnDisable()
	{
		if (NetworkManager.Singleton != null)
		{
			NetworkManager.Singleton.OnClientDisconnectCallback -= this.HandleClientDisconnected;
		}
	}

	// Token: 0x0600023D RID: 573 RVA: 0x000130F4 File Offset: 0x000112F4
	public override void OnNetworkSpawn()
	{
		this._netObj = base.GetComponentInParent<NetworkObject>();
		if (base.IsServer && NetworkManager.Singleton != null)
		{
			if (this._broadcastCo == null)
			{
				this._broadcastCo = base.StartCoroutine(this.PeriodicNameBroadcast());
			}
			NetworkManager.Singleton.OnClientConnectedCallback += this.OnClientConnectedSendSnapshot;
		}
	}

	// Token: 0x0600023E RID: 574 RVA: 0x00013154 File Offset: 0x00011354
	public override void OnNetworkDespawn()
	{
		if (this._netObj != null)
		{
			PlayerNameTag.playerNames.Remove(this._netObj.NetworkObjectId);
		}
		if (base.IsServer && NetworkManager.Singleton != null)
		{
			if (this._broadcastCo != null)
			{
				base.StopCoroutine(this._broadcastCo);
				this._broadcastCo = null;
			}
			NetworkManager.Singleton.OnClientConnectedCallback -= this.OnClientConnectedSendSnapshot;
		}
	}

	// Token: 0x0600023F RID: 575 RVA: 0x000131CC File Offset: 0x000113CC
	private void Start()
	{
		if (this.nameTagText == null)
		{
			return;
		}
		if (this._netObj == null)
		{
			this._netObj = base.GetComponentInParent<NetworkObject>();
		}
		if (base.IsOwner)
		{
			ulong num = (this._netObj != null) ? this._netObj.NetworkObjectId : 0UL;
			this.playerName = (SteamManager.Initialized ? SteamFriends.GetPersonaName() : string.Format("Player {0}", num));
			this.RegisterPlayerNameServerRpc(this.playerName, default(ServerRpcParams));
			if (this.tagContainer != null)
			{
				this.tagContainer.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06000240 RID: 576 RVA: 0x00013280 File Offset: 0x00011480
	private void Update()
	{
		if (this.tagContainer != null && this.playerTransform != null)
		{
			Camera main = Camera.main;
			if (main != null)
			{
				this.tagContainer.position = this.playerTransform.position + this.offset;
				this.tagContainer.rotation = Quaternion.LookRotation(this.tagContainer.position - main.transform.position);
			}
		}
	}

	// Token: 0x06000241 RID: 577 RVA: 0x00013304 File Offset: 0x00011504
	[ServerRpc]
	private void RegisterPlayerNameServerRpc(string name, ServerRpcParams rpcParams = default(ServerRpcParams))
	{
		NetworkManager networkManager = base.NetworkManager;
		if (networkManager == null || !networkManager.IsListening)
		{
			return;
		}
		if (this.__rpc_exec_stage != NetworkBehaviour.__RpcExecStage.Execute && (networkManager.IsClient || networkManager.IsHost))
		{
			if (base.OwnerClientId != networkManager.LocalClientId)
			{
				if (networkManager.LogLevel <= LogLevel.Normal)
				{
					Debug.LogError("Only the owner can invoke a ServerRpc that requires ownership!");
				}
				return;
			}
			FastBufferWriter fastBufferWriter = base.__beginSendServerRpc(4289108234U, rpcParams, RpcDelivery.Reliable);
			bool flag = name != null;
			fastBufferWriter.WriteValueSafe<bool>(flag, default(FastBufferWriter.ForPrimitives));
			if (flag)
			{
				fastBufferWriter.WriteValueSafe(name, false);
			}
			base.__endSendServerRpc(ref fastBufferWriter, 4289108234U, rpcParams, RpcDelivery.Reliable);
		}
		if (this.__rpc_exec_stage != NetworkBehaviour.__RpcExecStage.Execute || (!networkManager.IsServer && !networkManager.IsHost))
		{
			return;
		}
		this.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
		NetworkObject componentInParent = base.GetComponentInParent<NetworkObject>();
		if (componentInParent == null)
		{
			return;
		}
		ulong networkObjectId = componentInParent.NetworkObjectId;
		string text = string.IsNullOrWhiteSpace(name) ? string.Format("Player {0}", networkObjectId) : name;
		PlayerNameTag.playerNames[networkObjectId] = text;
		this.UpdatePlayerNameClientRpc(networkObjectId, text, default(ClientRpcParams));
	}

	// Token: 0x06000242 RID: 578 RVA: 0x000134AC File Offset: 0x000116AC
	[ClientRpc]
	private void UpdatePlayerNameClientRpc(ulong networkID, string name, ClientRpcParams rpcParams = default(ClientRpcParams))
	{
		NetworkManager networkManager = base.NetworkManager;
		if (networkManager == null || !networkManager.IsListening)
		{
			return;
		}
		if (this.__rpc_exec_stage != NetworkBehaviour.__RpcExecStage.Execute && (networkManager.IsServer || networkManager.IsHost))
		{
			FastBufferWriter writer = base.__beginSendClientRpc(4003003930U, rpcParams, RpcDelivery.Reliable);
			BytePacker.WriteValueBitPacked(writer, networkID);
			bool flag = name != null;
			writer.WriteValueSafe<bool>(flag, default(FastBufferWriter.ForPrimitives));
			if (flag)
			{
				writer.WriteValueSafe(name, false);
			}
			base.__endSendClientRpc(ref writer, 4003003930U, rpcParams, RpcDelivery.Reliable);
		}
		if (this.__rpc_exec_stage != NetworkBehaviour.__RpcExecStage.Execute || (!networkManager.IsClient && !networkManager.IsHost))
		{
			return;
		}
		this.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
		PlayerNameTag.playerNames[networkID] = name;
		this.UpdateNameTagText(networkID);
	}

	// Token: 0x06000243 RID: 579 RVA: 0x000135E0 File Offset: 0x000117E0
	private void UpdateNameTagText(ulong networkID)
	{
		NetworkManager singleton = NetworkManager.Singleton;
		if (singleton == null || singleton.SpawnManager == null)
		{
			return;
		}
		NetworkObject networkObject;
		if (!singleton.SpawnManager.SpawnedObjects.TryGetValue(networkID, out networkObject) || networkObject == null)
		{
			return;
		}
		PlayerNameTag componentInChildren = networkObject.GetComponentInChildren<PlayerNameTag>();
		string text;
		if (componentInChildren != null && componentInChildren.nameTagText != null && PlayerNameTag.playerNames.TryGetValue(networkID, out text))
		{
			componentInChildren.nameTagText.text = text;
		}
	}

	// Token: 0x06000244 RID: 580 RVA: 0x00013660 File Offset: 0x00011860
	private void HandleClientDisconnected(ulong _clientId)
	{
		NetworkManager singleton = NetworkManager.Singleton;
		if (singleton == null || singleton.SpawnManager == null)
		{
			return;
		}
		List<ulong> list = null;
		foreach (KeyValuePair<ulong, string> keyValuePair in PlayerNameTag.playerNames)
		{
			if (!singleton.SpawnManager.SpawnedObjects.ContainsKey(keyValuePair.Key))
			{
				List<ulong> list2;
				if ((list2 = list) == null)
				{
					list2 = (list = new List<ulong>());
				}
				list2.Add(keyValuePair.Key);
			}
		}
		if (list != null)
		{
			foreach (ulong key in list)
			{
				PlayerNameTag.playerNames.Remove(key);
			}
		}
	}

	// Token: 0x06000245 RID: 581 RVA: 0x00013740 File Offset: 0x00011940
	private IEnumerator PeriodicNameBroadcast()
	{
		WaitForSeconds wait = new WaitForSeconds(5f);
		for (;;)
		{
			this.ServerBroadcastAllNames(null);
			yield return wait;
		}
		yield break;
	}

	// Token: 0x06000246 RID: 582 RVA: 0x0001374F File Offset: 0x0001194F
	private void OnClientConnectedSendSnapshot(ulong newClientId)
	{
		this.ServerBroadcastAllNames(new ulong?(newClientId));
	}

	// Token: 0x06000247 RID: 583 RVA: 0x00013760 File Offset: 0x00011960
	private void ServerBroadcastAllNames(ulong? targetClientId = null)
	{
		NetworkManager singleton = NetworkManager.Singleton;
		if (singleton == null || singleton.SpawnManager == null)
		{
			return;
		}
		foreach (KeyValuePair<ulong, NetworkObject> keyValuePair in singleton.SpawnManager.SpawnedObjects)
		{
			NetworkObject value = keyValuePair.Value;
			if (!(value == null) && !(value.GetComponentInChildren<PlayerNameTag>() == null))
			{
				ulong networkObjectId = value.NetworkObjectId;
				string text;
				if (!PlayerNameTag.playerNames.TryGetValue(networkObjectId, out text) || string.IsNullOrWhiteSpace(text))
				{
					text = string.Format("Player {0}", networkObjectId);
					PlayerNameTag.playerNames[networkObjectId] = text;
				}
				if (targetClientId != null)
				{
					ClientRpcParams rpcParams = new ClientRpcParams
					{
						Send = new ClientRpcSendParams
						{
							TargetClientIds = new ulong[]
							{
								targetClientId.Value
							}
						}
					};
					this.UpdatePlayerNameClientRpc(networkObjectId, text, rpcParams);
				}
				else
				{
					this.UpdatePlayerNameClientRpc(networkObjectId, text, default(ClientRpcParams));
				}
			}
		}
	}

	// Token: 0x0600024A RID: 586 RVA: 0x000138D4 File Offset: 0x00011AD4
	protected override void __initializeVariables()
	{
		base.__initializeVariables();
	}

	// Token: 0x0600024B RID: 587 RVA: 0x000138EC File Offset: 0x00011AEC
	protected override void __initializeRpcs()
	{
		base.__registerRpc(4289108234U, new NetworkBehaviour.RpcReceiveHandler(PlayerNameTag.__rpc_handler_4289108234), "RegisterPlayerNameServerRpc");
		base.__registerRpc(4003003930U, new NetworkBehaviour.RpcReceiveHandler(PlayerNameTag.__rpc_handler_4003003930), "UpdatePlayerNameClientRpc");
		base.__initializeRpcs();
	}

	// Token: 0x0600024C RID: 588 RVA: 0x0001393C File Offset: 0x00011B3C
	private static void __rpc_handler_4289108234(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
	{
		NetworkManager networkManager = target.NetworkManager;
		if (networkManager == null || !networkManager.IsListening)
		{
			return;
		}
		if (rpcParams.Server.Receive.SenderClientId != target.OwnerClientId)
		{
			if (networkManager.LogLevel <= LogLevel.Normal)
			{
				Debug.LogError("Only the owner can invoke a ServerRpc that requires ownership!");
			}
			return;
		}
		bool flag;
		reader.ReadValueSafe<bool>(out flag, default(FastBufferWriter.ForPrimitives));
		string name = null;
		if (flag)
		{
			reader.ReadValueSafe(out name, false);
		}
		ServerRpcParams server = rpcParams.Server;
		target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Execute;
		((PlayerNameTag)target).RegisterPlayerNameServerRpc(name, server);
		target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
	}

	// Token: 0x0600024D RID: 589 RVA: 0x00013A24 File Offset: 0x00011C24
	private static void __rpc_handler_4003003930(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
	{
		NetworkManager networkManager = target.NetworkManager;
		if (networkManager == null || !networkManager.IsListening)
		{
			return;
		}
		ulong networkID;
		ByteUnpacker.ReadValueBitPacked(reader, out networkID);
		bool flag;
		reader.ReadValueSafe<bool>(out flag, default(FastBufferWriter.ForPrimitives));
		string name = null;
		if (flag)
		{
			reader.ReadValueSafe(out name, false);
		}
		ClientRpcParams client = rpcParams.Client;
		target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Execute;
		((PlayerNameTag)target).UpdatePlayerNameClientRpc(networkID, name, client);
		target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
	}

	// Token: 0x0600024E RID: 590 RVA: 0x00013AD0 File Offset: 0x00011CD0
	protected internal override string __getTypeName()
	{
		return "PlayerNameTag";
	}

	// Token: 0x040002E3 RID: 739
	public TextMeshPro nameTagText;

	// Token: 0x040002E4 RID: 740
	private string playerName = "";

	// Token: 0x040002E5 RID: 741
	public Vector3 offset = new Vector3(0f, 0.25f, 0f);

	// Token: 0x040002E6 RID: 742
	public Transform tagContainer;

	// Token: 0x040002E7 RID: 743
	public Transform playerTransform;

	// Token: 0x040002E8 RID: 744
	private static readonly Dictionary<ulong, string> playerNames = new Dictionary<ulong, string>();

	// Token: 0x040002E9 RID: 745
	private NetworkObject _netObj;

	// Token: 0x040002EA RID: 746
	private Coroutine _broadcastCo;
}
