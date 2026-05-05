using System;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

// Token: 0x02000052 RID: 82
[RequireComponent(typeof(NetworkObject))]
public class NetworkOutfitSyncAll : NetworkBehaviour
{
	// Token: 0x06000138 RID: 312 RVA: 0x0000A7FE File Offset: 0x000089FE
	private void Awake()
	{
		if (!this.apply)
		{
			this.apply = base.GetComponent<ApplyCustomOutfit>();
		}
	}

	// Token: 0x06000139 RID: 313 RVA: 0x0000A81C File Offset: 0x00008A1C
	public override void OnNetworkSpawn()
	{
		if (this.apply && this.apply.anchors != null)
		{
			this.topAnchor = this.apply.anchors.top;
			this.hatAnchor = this.apply.anchors.hat;
			this.pantsAnchor = this.apply.anchors.pants;
			this.shoesAnchor = this.apply.anchors.shoes;
			if (!this.partsLibrary)
			{
				this.partsLibrary = this.apply.partsLibrary;
			}
		}
		NetworkVariable<NetworkOutfitSyncAll.OutfitConfig> config = this._config;
		config.OnValueChanged = (NetworkVariable<NetworkOutfitSyncAll.OutfitConfig>.OnValueChangedDelegate)Delegate.Combine(config.OnValueChanged, new NetworkVariable<NetworkOutfitSyncAll.OutfitConfig>.OnValueChangedDelegate(delegate(NetworkOutfitSyncAll.OutfitConfig _, NetworkOutfitSyncAll.OutfitConfig __)
		{
			this.ApplyAll(this._config.Value);
		}));
		this.ApplyAll(this._config.Value);
		if (base.IsOwner && base.IsClient && this.apply && this.apply.customOutfitAsset && this.apply.customOutfitAsset.outfit != null)
		{
			this.PushFromLocal();
		}
	}

	// Token: 0x0600013A RID: 314 RVA: 0x0000A93B File Offset: 0x00008B3B
	public override void OnNetworkDespawn()
	{
		NetworkVariable<NetworkOutfitSyncAll.OutfitConfig> config = this._config;
		config.OnValueChanged = (NetworkVariable<NetworkOutfitSyncAll.OutfitConfig>.OnValueChangedDelegate)Delegate.Remove(config.OnValueChanged, new NetworkVariable<NetworkOutfitSyncAll.OutfitConfig>.OnValueChangedDelegate(delegate(NetworkOutfitSyncAll.OutfitConfig _, NetworkOutfitSyncAll.OutfitConfig __)
		{
			this.ApplyAll(this._config.Value);
		}));
	}

	// Token: 0x0600013B RID: 315 RVA: 0x0000A964 File Offset: 0x00008B64
	public void PushFromLocal()
	{
		if (!base.IsOwner || this.apply == null || this.apply.customOutfitAsset == null || this.apply.customOutfitAsset.outfit == null)
		{
			return;
		}
		CustomOutfitData outfit = this.apply.customOutfitAsset.outfit;
		NetworkOutfitSyncAll.OutfitConfig cfg = new NetworkOutfitSyncAll.OutfitConfig
		{
			top = NetworkOutfitSyncAll.ToFS(outfit.top),
			hat = NetworkOutfitSyncAll.ToFS(outfit.hat),
			pants = NetworkOutfitSyncAll.ToFS(outfit.pants),
			shoes = NetworkOutfitSyncAll.ToFS(outfit.shoes)
		};
		this.SubmitFullServerRpc(cfg, default(ServerRpcParams));
	}

	// Token: 0x0600013C RID: 316 RVA: 0x0000AA20 File Offset: 0x00008C20
	public void SetFromNames(string top, string hat, string pants, string shoes)
	{
		if (!base.IsOwner)
		{
			return;
		}
		NetworkOutfitSyncAll.OutfitConfig cfg = new NetworkOutfitSyncAll.OutfitConfig
		{
			top = NetworkOutfitSyncAll.ToFS(top),
			hat = NetworkOutfitSyncAll.ToFS(hat),
			pants = NetworkOutfitSyncAll.ToFS(pants),
			shoes = NetworkOutfitSyncAll.ToFS(shoes)
		};
		this.SubmitFullServerRpc(cfg, default(ServerRpcParams));
	}

	// Token: 0x0600013D RID: 317 RVA: 0x0000AA88 File Offset: 0x00008C88
	[ServerRpc]
	private void SubmitFullServerRpc(NetworkOutfitSyncAll.OutfitConfig cfg, ServerRpcParams _ = default(ServerRpcParams))
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
			FastBufferWriter fastBufferWriter = base.__beginSendServerRpc(3740288428U, _, RpcDelivery.Reliable);
			fastBufferWriter.WriteValueSafe<NetworkOutfitSyncAll.OutfitConfig>(cfg, default(FastBufferWriter.ForNetworkSerializable));
			base.__endSendServerRpc(ref fastBufferWriter, 3740288428U, _, RpcDelivery.Reliable);
		}
		if (this.__rpc_exec_stage != NetworkBehaviour.__RpcExecStage.Execute || (!networkManager.IsServer && !networkManager.IsHost))
		{
			return;
		}
		this.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
		this._config.Value = cfg;
	}

	// Token: 0x0600013E RID: 318 RVA: 0x0000ABC8 File Offset: 0x00008DC8
	private void ApplyAll(NetworkOutfitSyncAll.OutfitConfig cfg)
	{
		if (this.partsLibrary == null && this.apply && this.apply.partsLibrary)
		{
			this.partsLibrary = this.apply.partsLibrary;
		}
		if (this.partsLibrary == null)
		{
			return;
		}
		TopData topData = cfg.top.IsEmpty ? null : this.partsLibrary.tops.Find((TopData t) => t.name == cfg.top.ToString());
		HatData hatData = cfg.hat.IsEmpty ? null : this.partsLibrary.hats.Find((HatData h) => h.name == cfg.hat.ToString());
		PantsData pantsData = cfg.pants.IsEmpty ? null : this.partsLibrary.pants.Find((PantsData p) => p.name == cfg.pants.ToString());
		ShoesData shoesData = cfg.shoes.IsEmpty ? null : this.partsLibrary.shoes.Find((ShoesData s) => s.name == cfg.shoes.ToString());
		if (this.topAnchor && topData != null)
		{
			NetworkOutfitSyncAll.SafeSetMesh(this.topAnchor, topData.mesh);
			if (topData.material1)
			{
				NetworkOutfitSyncAll.SafeSetMaterial(this.topAnchor, topData.material1);
			}
			if (topData.material2)
			{
				NetworkOutfitSyncAll.SafeSetMaterialAtIndex(this.topAnchor, 1, topData.material2);
			}
		}
		if (this.hatAnchor && hatData != null)
		{
			NetworkOutfitSyncAll.SafeSetMesh(this.hatAnchor, hatData.mesh);
			if (hatData.material)
			{
				NetworkOutfitSyncAll.SafeSetMaterial(this.hatAnchor, hatData.material);
			}
		}
		if (this.pantsAnchor && pantsData != null)
		{
			NetworkOutfitSyncAll.SafeSetMesh(this.pantsAnchor, pantsData.mesh);
			if (pantsData.material)
			{
				NetworkOutfitSyncAll.SafeSetMaterial(this.pantsAnchor, pantsData.material);
			}
		}
		if (this.shoesAnchor && shoesData != null)
		{
			NetworkOutfitSyncAll.SafeSetMesh(this.shoesAnchor, shoesData.mesh);
			if (shoesData.material)
			{
				NetworkOutfitSyncAll.SafeSetMaterial(this.shoesAnchor, shoesData.material);
			}
		}
	}

	// Token: 0x0600013F RID: 319 RVA: 0x0000AE18 File Offset: 0x00009018
	private static FixedString64Bytes ToFS(string s)
	{
		if (!string.IsNullOrEmpty(s))
		{
			return s;
		}
		return default(FixedString64Bytes);
	}

	// Token: 0x06000140 RID: 320 RVA: 0x0000AE40 File Offset: 0x00009040
	private static void SafeSetMesh(GameObject go, Mesh mesh)
	{
		if (!go || !mesh)
		{
			return;
		}
		SkinnedMeshRenderer component = go.GetComponent<SkinnedMeshRenderer>();
		if (component)
		{
			component.sharedMesh = mesh;
			return;
		}
		MeshFilter component2 = go.GetComponent<MeshFilter>();
		if (component2)
		{
			component2.sharedMesh = mesh;
		}
	}

	// Token: 0x06000141 RID: 321 RVA: 0x0000AE8C File Offset: 0x0000908C
	private static void SafeSetMaterial(GameObject go, Material mat)
	{
		if (!go || !mat)
		{
			return;
		}
		Renderer component = go.GetComponent<SkinnedMeshRenderer>();
		if (!component)
		{
			component = go.GetComponent<MeshRenderer>();
		}
		if (!component)
		{
			return;
		}
		Material[] sharedMaterials = component.sharedMaterials;
		if (sharedMaterials == null || sharedMaterials.Length == 0)
		{
			component.sharedMaterial = mat;
			return;
		}
		sharedMaterials[0] = mat;
		component.sharedMaterials = sharedMaterials;
	}

	// Token: 0x06000142 RID: 322 RVA: 0x0000AEEC File Offset: 0x000090EC
	private static void SafeSetMaterialAtIndex(GameObject go, int index, Material mat)
	{
		if (!go || !mat)
		{
			return;
		}
		Renderer component = go.GetComponent<SkinnedMeshRenderer>();
		if (!component)
		{
			component = go.GetComponent<MeshRenderer>();
		}
		if (!component)
		{
			return;
		}
		Material[] sharedMaterials = component.sharedMaterials;
		if (sharedMaterials == null || index < 0 || index >= sharedMaterials.Length)
		{
			return;
		}
		sharedMaterials[index] = mat;
		component.sharedMaterials = sharedMaterials;
	}

	// Token: 0x06000146 RID: 326 RVA: 0x0000AF88 File Offset: 0x00009188
	protected override void __initializeVariables()
	{
		bool flag = this._config == null;
		if (flag)
		{
			throw new Exception("NetworkOutfitSyncAll._config cannot be null. All NetworkVariableBase instances must be initialized.");
		}
		this._config.Initialize(this);
		base.__nameNetworkVariable(this._config, "_config");
		this.NetworkVariableFields.Add(this._config);
		base.__initializeVariables();
	}

	// Token: 0x06000147 RID: 327 RVA: 0x0000AFEB File Offset: 0x000091EB
	protected override void __initializeRpcs()
	{
		base.__registerRpc(3740288428U, new NetworkBehaviour.RpcReceiveHandler(NetworkOutfitSyncAll.__rpc_handler_3740288428), "SubmitFullServerRpc");
		base.__initializeRpcs();
	}

	// Token: 0x06000148 RID: 328 RVA: 0x0000B014 File Offset: 0x00009214
	private static void __rpc_handler_3740288428(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
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
		NetworkOutfitSyncAll.OutfitConfig cfg;
		reader.ReadValueSafe<NetworkOutfitSyncAll.OutfitConfig>(out cfg, default(FastBufferWriter.ForNetworkSerializable));
		ServerRpcParams server = rpcParams.Server;
		target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Execute;
		((NetworkOutfitSyncAll)target).SubmitFullServerRpc(cfg, server);
		target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
	}

	// Token: 0x06000149 RID: 329 RVA: 0x0000B0DF File Offset: 0x000092DF
	protected internal override string __getTypeName()
	{
		return "NetworkOutfitSyncAll";
	}

	// Token: 0x0400017C RID: 380
	[Header("References")]
	public ApplyCustomOutfit apply;

	// Token: 0x0400017D RID: 381
	public CharacterPartsLibrary partsLibrary;

	// Token: 0x0400017E RID: 382
	private GameObject topAnchor;

	// Token: 0x0400017F RID: 383
	private GameObject hatAnchor;

	// Token: 0x04000180 RID: 384
	private GameObject pantsAnchor;

	// Token: 0x04000181 RID: 385
	private GameObject shoesAnchor;

	// Token: 0x04000182 RID: 386
	private NetworkVariable<NetworkOutfitSyncAll.OutfitConfig> _config = new NetworkVariable<NetworkOutfitSyncAll.OutfitConfig>(default(NetworkOutfitSyncAll.OutfitConfig), NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);

	// Token: 0x02000053 RID: 83
	public struct OutfitConfig : INetworkSerializable, IEquatable<NetworkOutfitSyncAll.OutfitConfig>
	{
		// Token: 0x0600014A RID: 330 RVA: 0x0000B0E8 File Offset: 0x000092E8
		public void NetworkSerialize<T>(BufferSerializer<T> s) where T : IReaderWriter
		{
			s.SerializeValue<FixedString64Bytes>(ref this.top, default(FastBufferWriter.ForFixedStrings));
			s.SerializeValue<FixedString64Bytes>(ref this.hat, default(FastBufferWriter.ForFixedStrings));
			s.SerializeValue<FixedString64Bytes>(ref this.pants, default(FastBufferWriter.ForFixedStrings));
			s.SerializeValue<FixedString64Bytes>(ref this.shoes, default(FastBufferWriter.ForFixedStrings));
		}

		// Token: 0x0600014B RID: 331 RVA: 0x0000B150 File Offset: 0x00009350
		public bool Equals(NetworkOutfitSyncAll.OutfitConfig o)
		{
			return this.top.Equals(o.top) && this.hat.Equals(o.hat) && this.pants.Equals(o.pants) && this.shoes.Equals(o.shoes);
		}

		// Token: 0x04000183 RID: 387
		public FixedString64Bytes top;

		// Token: 0x04000184 RID: 388
		public FixedString64Bytes hat;

		// Token: 0x04000185 RID: 389
		public FixedString64Bytes pants;

		// Token: 0x04000186 RID: 390
		public FixedString64Bytes shoes;
	}
}
