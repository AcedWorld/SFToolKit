using System;
using System.Collections;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

// Token: 0x0200009B RID: 155
[DisallowMultipleComponent]
[DefaultExecutionOrder(2000)]
public class NetworkClothingSync : NetworkBehaviour
{
	// Token: 0x06000278 RID: 632 RVA: 0x00014634 File Offset: 0x00012834
	private void Awake()
	{
		this.netObj = base.GetComponent<NetworkObject>();
		if (this.clothing != null && !this.IsUnderThisAvatar(this.clothing.transform))
		{
			this.LogErr("Inspector 'clothing' isn’t under THIS avatar. Clearing to prevent cross-avatar writes.");
			this.clothing = null;
		}
		if (this.clothing == null)
		{
			Transform transform = this.clothingRoot ? this.clothingRoot : base.transform;
			this.clothing = transform.GetComponentInChildren<ClothingCheatCodeHandler>(true);
		}
		this.Log(string.Format("Awake | HasClothing={0} HasNO={1} Path={2}", this.clothing != null, this.netObj != null, this.clothing ? NetworkClothingSync.GetPath(this.clothing.transform) : "<null>"));
	}

	// Token: 0x06000279 RID: 633 RVA: 0x00014710 File Offset: 0x00012910
	public override void OnNetworkSpawn()
	{
		this.Log(string.Format("OnNetworkSpawn | IsServer={0} IsClient={1} IsHost={2} IsOwner={3} ObjId={4}", new object[]
		{
			base.IsServer,
			base.IsClient,
			base.IsHost,
			base.IsOwner,
			this.netObj ? this.netObj.NetworkObjectId : 0UL
		}));
		NetworkVariable<NetworkClothingSync.ClothingConfig> networkVariable = this.netConfig;
		networkVariable.OnValueChanged = (NetworkVariable<NetworkClothingSync.ClothingConfig>.OnValueChangedDelegate)Delegate.Combine(networkVariable.OnValueChanged, new NetworkVariable<NetworkClothingSync.ClothingConfig>.OnValueChangedDelegate(this.OnConfigChanged));
		if (base.IsOwner)
		{
			base.StartCoroutine(this.OwnerPushOnReady());
		}
		base.StartCoroutine(this.ApplyWhenReady(this.netConfig.Value, "spawn"));
	}

	// Token: 0x0600027A RID: 634 RVA: 0x000147E8 File Offset: 0x000129E8
	public override void OnNetworkDespawn()
	{
		NetworkVariable<NetworkClothingSync.ClothingConfig> networkVariable = this.netConfig;
		networkVariable.OnValueChanged = (NetworkVariable<NetworkClothingSync.ClothingConfig>.OnValueChangedDelegate)Delegate.Remove(networkVariable.OnValueChanged, new NetworkVariable<NetworkClothingSync.ClothingConfig>.OnValueChangedDelegate(this.OnConfigChanged));
	}

	// Token: 0x0600027B RID: 635 RVA: 0x00014814 File Offset: 0x00012A14
	public void OwnerPushCurrentClothes()
	{
		if (!base.IsOwner)
		{
			this.LogWarn("OwnerPushCurrentClothes called by non-owner. Ignored.");
			return;
		}
		NetworkClothingSync.ClothingConfig cfg = this.BuildConfigFromLocal();
		this.Log("Owner ? submit clothing config to server");
		this.SubmitConfigServerRpc(cfg, default(ServerRpcParams));
	}

	// Token: 0x0600027C RID: 636 RVA: 0x00014857 File Offset: 0x00012A57
	private IEnumerator OwnerPushOnReady()
	{
		yield return new WaitUntil(() => this.EnsureClothing() != null && this.clothing.categories != null && this.clothing.categories.Count > 0);
		yield return null;
		NetworkClothingSync.ClothingConfig cfg = this.BuildConfigFromLocal();
		this.SubmitConfigServerRpc(cfg, default(ServerRpcParams));
		this.Log("Owner push on spawn (after ClothingCheatCodeHandler ready).");
		yield break;
	}

	// Token: 0x0600027D RID: 637 RVA: 0x00014868 File Offset: 0x00012A68
	[ServerRpc(RequireOwnership = false)]
	private void SubmitConfigServerRpc(NetworkClothingSync.ClothingConfig cfg, ServerRpcParams rpc = default(ServerRpcParams))
	{
		NetworkManager networkManager = base.NetworkManager;
		if (networkManager == null || !networkManager.IsListening)
		{
			return;
		}
		if (this.__rpc_exec_stage != NetworkBehaviour.__RpcExecStage.Execute && (networkManager.IsClient || networkManager.IsHost))
		{
			FastBufferWriter fastBufferWriter = base.__beginSendServerRpc(3015891878U, rpc, RpcDelivery.Reliable);
			fastBufferWriter.WriteValueSafe<NetworkClothingSync.ClothingConfig>(cfg, default(FastBufferWriter.ForNetworkSerializable));
			base.__endSendServerRpc(ref fastBufferWriter, 3015891878U, rpc, RpcDelivery.Reliable);
		}
		if (this.__rpc_exec_stage != NetworkBehaviour.__RpcExecStage.Execute || (!networkManager.IsServer && !networkManager.IsHost))
		{
			return;
		}
		this.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
		if (rpc.Receive.SenderClientId != base.OwnerClientId)
		{
			this.LogSrv(string.Format("IGNORED SubmitConfig from {0} (owner is {1})", rpc.Receive.SenderClientId, base.OwnerClientId));
			return;
		}
		this.netConfig.Value = cfg;
		this.LogSrv("Accepted clothing config from owner.");
	}

	// Token: 0x0600027E RID: 638 RVA: 0x000149AC File Offset: 0x00012BAC
	private void OnConfigChanged(NetworkClothingSync.ClothingConfig oldVal, NetworkClothingSync.ClothingConfig newVal)
	{
		this.Log("Config changed ? apply outfit to THIS avatar");
		base.StartCoroutine(this.ApplyWhenReady(newVal, "NV changed"));
	}

	// Token: 0x0600027F RID: 639 RVA: 0x000149CC File Offset: 0x00012BCC
	private NetworkClothingSync.ClothingConfig BuildConfigFromLocal()
	{
		NetworkClothingSync.ClothingConfig result = new NetworkClothingSync.ClothingConfig
		{
			count = 0,
			itemIdx = default(FixedList128Bytes<int>),
			matIdx = default(FixedList128Bytes<int>)
		};
		ClothingCheatCodeHandler clothingCheatCodeHandler = this.EnsureClothing();
		if (clothingCheatCodeHandler == null || clothingCheatCodeHandler.categories == null || clothingCheatCodeHandler.categories.Count == 0)
		{
			return result;
		}
		int num = Mathf.Clamp(clothingCheatCodeHandler.categories.Count, 0, 32);
		for (int i = 0; i < num; i++)
		{
			int num2 = 0;
			int num3 = 0;
			ClothingCheatCodeHandler.ClothingCategory clothingCategory = clothingCheatCodeHandler.categories[i];
			int num4 = -1;
			int j = 0;
			while (j < clothingCategory.items.Count)
			{
				ClothingCheatCodeHandler.ClothingItem clothingItem = clothingCategory.items[j];
				if (clothingItem.gameObject && clothingItem.gameObject.activeInHierarchy)
				{
					num4 = j;
					if (clothingItem.materials == null || clothingItem.materials.Count <= 0)
					{
						break;
					}
					Renderer r = clothingItem.gameObject.GetComponent<Renderer>() ?? clothingItem.gameObject.GetComponentInChildren<Renderer>(true);
					if (!r || !r.sharedMaterial)
					{
						break;
					}
					int num5 = clothingItem.materials.FindIndex((Material m) => m == r.sharedMaterial);
					if (num5 >= 0)
					{
						num3 = num5;
						break;
					}
					break;
				}
				else
				{
					j++;
				}
			}
			if (num4 >= 0)
			{
				num2 = num4;
			}
			else if (clothingCategory.items.Count == 0)
			{
				num2 = -1;
				num3 = 0;
			}
			else
			{
				num2 = 0;
				num3 = 0;
			}
			result.itemIdx.Add(num2);
			result.matIdx.Add(num3);
		}
		result.count = Mathf.Min(result.itemIdx.Length, result.matIdx.Length);
		return result;
	}

	// Token: 0x06000280 RID: 640 RVA: 0x00014BBD File Offset: 0x00012DBD
	private IEnumerator ApplyWhenReady(NetworkClothingSync.ClothingConfig cfg, string reason)
	{
		if (cfg.count <= 0)
		{
			yield break;
		}
		yield return new WaitUntil(() => this.EnsureClothing() != null && this.clothing.categories != null && this.clothing.categories.Count >= cfg.count);
		yield return null;
		this.ApplyConfigLocal(cfg, this.clothing);
		this.Log("Applied clothing config (reason: " + reason + ").");
		yield break;
	}

	// Token: 0x06000281 RID: 641 RVA: 0x00014BDC File Offset: 0x00012DDC
	private void ApplyConfigLocal(NetworkClothingSync.ClothingConfig cfg, ClothingCheatCodeHandler ch)
	{
		int num = Mathf.Min(cfg.count, ch.categories.Count);
		for (int i = 0; i < num; i++)
		{
			ClothingCheatCodeHandler.ClothingCategory clothingCategory = ch.categories[i];
			int num2 = cfg.itemIdx[i];
			for (int j = 0; j < clothingCategory.items.Count; j++)
			{
				GameObject gameObject = clothingCategory.items[j].gameObject;
				if (gameObject)
				{
					gameObject.SetActive(false);
				}
			}
			if (clothingCategory.items.Count > 0 && num2 >= 0)
			{
				num2 = Mathf.Clamp(num2, 0, clothingCategory.items.Count - 1);
				ClothingCheatCodeHandler.ClothingItem clothingItem = clothingCategory.items[num2];
				if (clothingItem.gameObject)
				{
					clothingItem.gameObject.SetActive(true);
				}
				if (clothingItem.materials != null && clothingItem.materials.Count > 0)
				{
					int index = Mathf.Clamp(cfg.matIdx[i], 0, clothingItem.materials.Count - 1);
					Renderer renderer = clothingItem.gameObject.GetComponent<Renderer>() ?? clothingItem.gameObject.GetComponentInChildren<Renderer>(true);
					if (renderer && clothingItem.materials[index])
					{
						renderer.material = clothingItem.materials[index];
					}
				}
			}
		}
	}

	// Token: 0x06000282 RID: 642 RVA: 0x00014D54 File Offset: 0x00012F54
	private ClothingCheatCodeHandler EnsureClothing()
	{
		if (this.clothing != null && this.IsUnderThisAvatar(this.clothing.transform))
		{
			return this.clothing;
		}
		Transform transform = this.clothingRoot ? this.clothingRoot : base.transform;
		this.clothing = transform.GetComponentInChildren<ClothingCheatCodeHandler>(true);
		return this.clothing;
	}

	// Token: 0x06000283 RID: 643 RVA: 0x00014DB8 File Offset: 0x00012FB8
	private bool IsUnderThisAvatar(Transform t)
	{
		if (!t)
		{
			return false;
		}
		Transform transform = this.clothingRoot ? this.clothingRoot : base.transform;
		return t == transform || t.IsChildOf(transform);
	}

	// Token: 0x06000284 RID: 644 RVA: 0x00014E00 File Offset: 0x00013000
	private static string GetPath(Transform tr)
	{
		if (!tr)
		{
			return "<null>";
		}
		string text = tr.name;
		Transform parent = tr.parent;
		while (parent)
		{
			text = parent.name + "/" + text;
			parent = parent.parent;
		}
		return text;
	}

	// Token: 0x06000285 RID: 645 RVA: 0x00014E4D File Offset: 0x0001304D
	private void Log(string msg)
	{
		if (this.debugLogs)
		{
			Debug.Log(this.Tag() + msg, this);
		}
	}

	// Token: 0x06000286 RID: 646 RVA: 0x00014E69 File Offset: 0x00013069
	private void LogWarn(string msg)
	{
		if (this.debugLogs)
		{
			Debug.LogWarning(this.Tag() + msg, this);
		}
	}

	// Token: 0x06000287 RID: 647 RVA: 0x00014E85 File Offset: 0x00013085
	private void LogErr(string msg)
	{
		Debug.LogError(this.Tag() + msg, this);
	}

	// Token: 0x06000288 RID: 648 RVA: 0x00014E99 File Offset: 0x00013099
	private void LogSrv(string msg)
	{
		if (this.debugLogs)
		{
			Debug.Log("[NetworkClothingSync:SERVER] " + msg);
		}
	}

	// Token: 0x06000289 RID: 649 RVA: 0x00014EB3 File Offset: 0x000130B3
	private string Tag()
	{
		return string.Format("[NetworkClothingSync:{0}#{1}] ", base.name, this.netObj ? this.netObj.NetworkObjectId : 0UL);
	}

	// Token: 0x0600028C RID: 652 RVA: 0x00014F4C File Offset: 0x0001314C
	protected override void __initializeVariables()
	{
		bool flag = this.netConfig == null;
		if (flag)
		{
			throw new Exception("NetworkClothingSync.netConfig cannot be null. All NetworkVariableBase instances must be initialized.");
		}
		this.netConfig.Initialize(this);
		base.__nameNetworkVariable(this.netConfig, "netConfig");
		this.NetworkVariableFields.Add(this.netConfig);
		base.__initializeVariables();
	}

	// Token: 0x0600028D RID: 653 RVA: 0x00014FAF File Offset: 0x000131AF
	protected override void __initializeRpcs()
	{
		base.__registerRpc(3015891878U, new NetworkBehaviour.RpcReceiveHandler(NetworkClothingSync.__rpc_handler_3015891878), "SubmitConfigServerRpc");
		base.__initializeRpcs();
	}

	// Token: 0x0600028E RID: 654 RVA: 0x00014FD8 File Offset: 0x000131D8
	private static void __rpc_handler_3015891878(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
	{
		NetworkManager networkManager = target.NetworkManager;
		if (networkManager == null || !networkManager.IsListening)
		{
			return;
		}
		NetworkClothingSync.ClothingConfig cfg;
		reader.ReadValueSafe<NetworkClothingSync.ClothingConfig>(out cfg, default(FastBufferWriter.ForNetworkSerializable));
		ServerRpcParams server = rpcParams.Server;
		target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Execute;
		((NetworkClothingSync)target).SubmitConfigServerRpc(cfg, server);
		target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
	}

	// Token: 0x0600028F RID: 655 RVA: 0x00015056 File Offset: 0x00013256
	protected internal override string __getTypeName()
	{
		return "NetworkClothingSync";
	}

	// Token: 0x0400032E RID: 814
	[Header("Debug")]
	[SerializeField]
	private bool debugLogs = true;

	// Token: 0x0400032F RID: 815
	[Header("Scope")]
	[Tooltip("Optional: a sub-root under this avatar to look for ClothingCheatCodeHandler. If empty, uses this transform.")]
	[SerializeField]
	private Transform clothingRoot;

	// Token: 0x04000330 RID: 816
	[Header("Local (this avatar only)")]
	[SerializeField]
	public ClothingCheatCodeHandler clothing;

	// Token: 0x04000331 RID: 817
	private readonly NetworkVariable<NetworkClothingSync.ClothingConfig> netConfig = new NetworkVariable<NetworkClothingSync.ClothingConfig>(default(NetworkClothingSync.ClothingConfig), NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);

	// Token: 0x04000332 RID: 818
	private NetworkObject netObj;

	// Token: 0x0200009C RID: 156
	[Serializable]
	public struct ClothingConfig : INetworkSerializable, IEquatable<NetworkClothingSync.ClothingConfig>
	{
		// Token: 0x06000290 RID: 656 RVA: 0x00015060 File Offset: 0x00013260
		public void NetworkSerialize<T>(BufferSerializer<T> s) where T : IReaderWriter
		{
			if (s.IsReader)
			{
				int num = 0;
				s.SerializeValue<int>(ref num, default(FastBufferWriter.ForPrimitives));
				num = Mathf.Clamp(num, 0, 32);
				this.itemIdx = default(FixedList128Bytes<int>);
				this.matIdx = default(FixedList128Bytes<int>);
				for (int i = 0; i < num; i++)
				{
					int num2 = 0;
					s.SerializeValue<int>(ref num2, default(FastBufferWriter.ForPrimitives));
					int num3 = 0;
					s.SerializeValue<int>(ref num3, default(FastBufferWriter.ForPrimitives));
					this.itemIdx.Add(num2);
					this.matIdx.Add(num3);
				}
				this.count = num;
				return;
			}
			int num4 = Mathf.Min(this.itemIdx.Length, this.matIdx.Length);
			s.SerializeValue<int>(ref num4, default(FastBufferWriter.ForPrimitives));
			for (int j = 0; j < num4; j++)
			{
				int num5 = this.itemIdx[j];
				s.SerializeValue<int>(ref num5, default(FastBufferWriter.ForPrimitives));
				int num6 = this.matIdx[j];
				s.SerializeValue<int>(ref num6, default(FastBufferWriter.ForPrimitives));
			}
			this.count = num4;
		}

		// Token: 0x06000291 RID: 657 RVA: 0x00015190 File Offset: 0x00013390
		public bool Equals(NetworkClothingSync.ClothingConfig o)
		{
			if (this.count != o.count)
			{
				return false;
			}
			for (int i = 0; i < this.count; i++)
			{
				if (this.itemIdx[i] != o.itemIdx[i])
				{
					return false;
				}
				if (this.matIdx[i] != o.matIdx[i])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x04000333 RID: 819
		public int count;

		// Token: 0x04000334 RID: 820
		public FixedList128Bytes<int> itemIdx;

		// Token: 0x04000335 RID: 821
		public FixedList128Bytes<int> matIdx;
	}
}
