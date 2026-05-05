using System;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

// Token: 0x02000057 RID: 87
[RequireComponent(typeof(NetworkObject))]
public class NetworkScooterSyncAll : NetworkBehaviour
{
	// Token: 0x06000156 RID: 342 RVA: 0x0000B49E File Offset: 0x0000969E
	private void Awake()
	{
		if (!this.apply)
		{
			this.apply = base.GetComponent<ApplyCustomScooter>();
		}
	}

	// Token: 0x06000157 RID: 343 RVA: 0x0000B4BC File Offset: 0x000096BC
	public override void OnNetworkSpawn()
	{
		this.parts = (this.apply ? this.apply.myScooterParts : null);
		this.grind = (this.apply ? this.apply.grindSystem : null);
		this.details = Object.FindObjectOfType<ScooterDetails>();
		NetworkVariable<NetworkScooterSyncAll.ScooterConfig> config = this._config;
		config.OnValueChanged = (NetworkVariable<NetworkScooterSyncAll.ScooterConfig>.OnValueChangedDelegate)Delegate.Combine(config.OnValueChanged, new NetworkVariable<NetworkScooterSyncAll.ScooterConfig>.OnValueChangedDelegate(delegate(NetworkScooterSyncAll.ScooterConfig _, NetworkScooterSyncAll.ScooterConfig __)
		{
			this.ApplyAll(this._config.Value);
		}));
		this.ApplyAll(this._config.Value);
		if (base.IsOwner && base.IsClient && this.apply && this.apply.customScootersAsset)
		{
			this.PushFromLocalActiveSlot();
		}
	}

	// Token: 0x06000158 RID: 344 RVA: 0x0000B584 File Offset: 0x00009784
	public void PushFromLocalActiveSlot()
	{
		if (!base.IsOwner || !this.apply || !this.apply.customScootersAsset)
		{
			return;
		}
		int num = Mathf.Clamp(this.apply.customScootersAsset.activeSlot, 1, 3);
		CustomScooterData customScooterData = (num == 1) ? this.apply.customScootersAsset.scooter1 : ((num == 2) ? this.apply.customScootersAsset.scooter2 : this.apply.customScootersAsset.scooter3);
		if (customScooterData == null)
		{
			return;
		}
		NetworkScooterSyncAll.ScooterConfig cfg = new NetworkScooterSyncAll.ScooterConfig
		{
			deck = NetworkScooterSyncAll.ToFS(customScooterData.deck),
			bars = NetworkScooterSyncAll.ToFS(customScooterData.bars),
			fork = NetworkScooterSyncAll.ToFS(customScooterData.fork),
			clamp = NetworkScooterSyncAll.ToFS(customScooterData.clamp),
			frontWheel = NetworkScooterSyncAll.ToFS(customScooterData.frontWheel),
			rearWheel = NetworkScooterSyncAll.ToFS(customScooterData.rearWheel),
			grips = NetworkScooterSyncAll.ToFS(customScooterData.grips),
			barEnds = NetworkScooterSyncAll.ToFS(customScooterData.barEnds),
			headset = NetworkScooterSyncAll.ToFS(customScooterData.headset),
			gripTape = NetworkScooterSyncAll.ToFS(customScooterData.gripTape),
			pegs = NetworkScooterSyncAll.ToFS(customScooterData.pegs),
			pegOption = customScooterData.pegOption,
			hasDeckPegs = customScooterData.hasDeckPegs
		};
		this.SubmitFullServerRpc(cfg, default(ServerRpcParams));
	}

	// Token: 0x06000159 RID: 345 RVA: 0x0000B710 File Offset: 0x00009910
	public void SetFromNames(string deck, string bars, string fork, string clamp, string frontWheel, string rearWheel, string grips, string barEnds, string headset, string gripTape, string pegs, int pegOption, bool hasDeckPegs)
	{
		if (!base.IsOwner)
		{
			return;
		}
		NetworkScooterSyncAll.ScooterConfig cfg = new NetworkScooterSyncAll.ScooterConfig
		{
			deck = NetworkScooterSyncAll.ToFS(deck),
			bars = NetworkScooterSyncAll.ToFS(bars),
			fork = NetworkScooterSyncAll.ToFS(fork),
			clamp = NetworkScooterSyncAll.ToFS(clamp),
			frontWheel = NetworkScooterSyncAll.ToFS(frontWheel),
			rearWheel = NetworkScooterSyncAll.ToFS(rearWheel),
			grips = NetworkScooterSyncAll.ToFS(grips),
			barEnds = NetworkScooterSyncAll.ToFS(barEnds),
			headset = NetworkScooterSyncAll.ToFS(headset),
			gripTape = NetworkScooterSyncAll.ToFS(gripTape),
			pegs = NetworkScooterSyncAll.ToFS(pegs),
			pegOption = pegOption,
			hasDeckPegs = hasDeckPegs
		};
		this.SubmitFullServerRpc(cfg, default(ServerRpcParams));
	}

	// Token: 0x0600015A RID: 346 RVA: 0x0000B7EC File Offset: 0x000099EC
	[ServerRpc]
	private void SubmitFullServerRpc(NetworkScooterSyncAll.ScooterConfig cfg, ServerRpcParams _ = default(ServerRpcParams))
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
			FastBufferWriter fastBufferWriter = base.__beginSendServerRpc(2494058560U, _, RpcDelivery.Reliable);
			fastBufferWriter.WriteValueSafe<NetworkScooterSyncAll.ScooterConfig>(cfg, default(FastBufferWriter.ForNetworkSerializable));
			base.__endSendServerRpc(ref fastBufferWriter, 2494058560U, _, RpcDelivery.Reliable);
		}
		if (this.__rpc_exec_stage != NetworkBehaviour.__RpcExecStage.Execute || (!networkManager.IsServer && !networkManager.IsHost))
		{
			return;
		}
		this.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
		this._config.Value = cfg;
	}

	// Token: 0x0600015B RID: 347 RVA: 0x0000B92C File Offset: 0x00009B2C
	private void ApplyAll(NetworkScooterSyncAll.ScooterConfig cfg)
	{
		if (this.partsLibrary == null || this.parts == null)
		{
			return;
		}
		DeckData deck = this.GetDeck(cfg.deck);
		BarsData bars = this.GetBars(cfg.bars);
		ForksData forks = this.GetForks(cfg.fork);
		ClampData clamp = this.GetClamp(cfg.clamp);
		FrontWheelData frontWheel = this.GetFrontWheel(cfg.frontWheel);
		RearWheelData rearWheel = this.GetRearWheel(cfg.rearWheel);
		GripsData grips = this.GetGrips(cfg.grips);
		BarEndsData barEnds = this.GetBarEnds(cfg.barEnds);
		HeadsetData headset = this.GetHeadset(cfg.headset);
		GripTapeData gripTape = this.GetGripTape(cfg.gripTape);
		PegsData pegs = this.GetPegs(cfg.pegs);
		if (deck != null)
		{
			if (this.parts.deck && deck.deckMesh)
			{
				NetworkScooterSyncAll.SafeSetMesh(this.parts.deck, deck.deckMesh);
			}
			if (this.parts.deck && deck.deckMaterial)
			{
				NetworkScooterSyncAll.SafeSetMaterial(this.parts.deck, deck.deckMaterial);
			}
			if (this.parts.brake && deck.brakeMesh)
			{
				NetworkScooterSyncAll.SafeSetMesh(this.parts.brake, deck.brakeMesh);
			}
			if (this.parts.gripTape && deck.gripTapeMesh)
			{
				NetworkScooterSyncAll.SafeSetMesh(this.parts.gripTape, deck.gripTapeMesh);
			}
		}
		if (this.parts.gripTape && gripTape != null && gripTape.gripTapeTexture)
		{
			MeshRenderer component = this.parts.gripTape.GetComponent<MeshRenderer>();
			if (component && component.sharedMaterial)
			{
				Material sharedMaterial = component.sharedMaterial;
				if (sharedMaterial.HasProperty("_BaseMap"))
				{
					sharedMaterial.SetTexture("_BaseMap", gripTape.gripTapeTexture);
				}
				else if (sharedMaterial.HasProperty("_MainTex"))
				{
					sharedMaterial.SetTexture("_MainTex", gripTape.gripTapeTexture);
				}
			}
		}
		if (bars != null)
		{
			if (this.parts.bars && bars.barsMesh)
			{
				NetworkScooterSyncAll.SafeSetMesh(this.parts.bars, bars.barsMesh);
			}
			if (this.parts.bars && bars.barsMaterial)
			{
				NetworkScooterSyncAll.SafeSetMaterial(this.parts.bars, bars.barsMaterial);
			}
		}
		if (forks != null)
		{
			if (this.parts.forks && forks.forksMesh)
			{
				NetworkScooterSyncAll.SafeSetMesh(this.parts.forks, forks.forksMesh);
			}
			if (this.parts.forks && forks.forksMaterial)
			{
				NetworkScooterSyncAll.SafeSetMaterial(this.parts.forks, forks.forksMaterial);
			}
		}
		if (clamp != null)
		{
			if (this.parts.clamp && clamp.clampMesh)
			{
				NetworkScooterSyncAll.SafeSetMesh(this.parts.clamp, clamp.clampMesh);
			}
			if (this.parts.clamp && clamp.clampMaterial)
			{
				NetworkScooterSyncAll.SafeSetMaterial(this.parts.clamp, clamp.clampMaterial);
			}
		}
		if (frontWheel != null)
		{
			if (this.parts.frontWheel && frontWheel.wheelMesh)
			{
				NetworkScooterSyncAll.SafeSetMesh(this.parts.frontWheel, frontWheel.wheelMesh);
			}
			if (this.parts.frontWheel && frontWheel.hubMaterial)
			{
				NetworkScooterSyncAll.SafeSetMaterial(this.parts.frontWheel, frontWheel.hubMaterial);
			}
			if (this.parts.frontTyre && frontWheel.tyreMaterial)
			{
				NetworkScooterSyncAll.SafeSetMaterial(this.parts.frontTyre, frontWheel.tyreMaterial);
			}
		}
		if (rearWheel != null)
		{
			if (this.parts.rearWheel && rearWheel.wheelMesh)
			{
				NetworkScooterSyncAll.SafeSetMesh(this.parts.rearWheel, rearWheel.wheelMesh);
			}
			if (this.parts.rearWheel && rearWheel.hubMaterial)
			{
				NetworkScooterSyncAll.SafeSetMaterial(this.parts.rearWheel, rearWheel.hubMaterial);
			}
			if (this.parts.rearTyre && rearWheel.tyreMaterial)
			{
				NetworkScooterSyncAll.SafeSetMaterial(this.parts.rearTyre, rearWheel.tyreMaterial);
			}
		}
		if (grips != null)
		{
			if (this.parts.leftGrip && grips.leftGripMesh)
			{
				NetworkScooterSyncAll.SafeSetMesh(this.parts.leftGrip, grips.leftGripMesh);
			}
			if (this.parts.rightGrip && grips.rightGripMesh)
			{
				NetworkScooterSyncAll.SafeSetMesh(this.parts.rightGrip, grips.rightGripMesh);
			}
			if (grips.gripsMaterial)
			{
				if (this.parts.leftGrip)
				{
					NetworkScooterSyncAll.SafeSetMaterial(this.parts.leftGrip, grips.gripsMaterial);
				}
				if (this.parts.rightGrip)
				{
					NetworkScooterSyncAll.SafeSetMaterial(this.parts.rightGrip, grips.gripsMaterial);
				}
			}
		}
		if (!cfg.barEnds.IsEmpty)
		{
			if (barEnds != null)
			{
				if (this.parts.leftBarEnd && barEnds.leftBarendMesh)
				{
					NetworkScooterSyncAll.SafeSetMesh(this.parts.leftBarEnd, barEnds.leftBarendMesh);
				}
				if (this.parts.rightBarEnd && barEnds.rightBarend)
				{
					NetworkScooterSyncAll.SafeSetMesh(this.parts.rightBarEnd, barEnds.rightBarend);
				}
				if (barEnds.barEndsMaterial)
				{
					if (this.parts.leftBarEnd)
					{
						NetworkScooterSyncAll.SafeSetMaterial(this.parts.leftBarEnd, barEnds.barEndsMaterial);
					}
					if (this.parts.rightBarEnd)
					{
						NetworkScooterSyncAll.SafeSetMaterial(this.parts.rightBarEnd, barEnds.barEndsMaterial);
					}
				}
				NetworkScooterSyncAll.SetActiveIfExists(this.parts.leftBarEnd, true);
				NetworkScooterSyncAll.SetActiveIfExists(this.parts.rightBarEnd, true);
			}
		}
		else
		{
			NetworkScooterSyncAll.SetActiveIfExists(this.parts.leftBarEnd, false);
			NetworkScooterSyncAll.SetActiveIfExists(this.parts.rightBarEnd, false);
		}
		if (headset != null)
		{
			if (this.parts.headset && headset.headsetMesh)
			{
				NetworkScooterSyncAll.SafeSetMesh(this.parts.headset, headset.headsetMesh);
			}
			if (this.parts.headset && headset.headsetMaterial)
			{
				NetworkScooterSyncAll.SafeSetMaterial(this.parts.headset, headset.headsetMaterial);
			}
		}
		if (this.parts.deckAddonParent)
		{
			for (int i = this.parts.deckAddonParent.childCount - 1; i >= 0; i--)
			{
				Object.Destroy(this.parts.deckAddonParent.GetChild(i).gameObject);
			}
		}
		if (deck != null && deck.hasAddOns && deck.deckAddOns != null && this.parts.deckAddonParent)
		{
			foreach (GameObject gameObject in deck.deckAddOns)
			{
				if (gameObject)
				{
					GameObject gameObject2 = Object.Instantiate<GameObject>(gameObject, this.parts.deckAddonParent);
					gameObject2.transform.localPosition = Vector3.zero;
					gameObject2.transform.localRotation = Quaternion.identity;
					gameObject2.transform.localScale = Vector3.one;
				}
			}
		}
		if (pegs != null)
		{
			if (this.parts.frontLeftPeg && pegs.frontLeftPegMesh)
			{
				NetworkScooterSyncAll.SafeSetMesh(this.parts.frontLeftPeg, pegs.frontLeftPegMesh);
			}
			if (this.parts.frontRightPeg && pegs.frontRightPegMesh)
			{
				NetworkScooterSyncAll.SafeSetMesh(this.parts.frontRightPeg, pegs.frontRightPegMesh);
			}
			if (this.parts.rearLeftPeg && pegs.rearLeftPegMesh)
			{
				NetworkScooterSyncAll.SafeSetMesh(this.parts.rearLeftPeg, pegs.rearLeftPegMesh);
			}
			if (this.parts.rearRightPeg && pegs.rearRightPegMesh)
			{
				NetworkScooterSyncAll.SafeSetMesh(this.parts.rearRightPeg, pegs.rearRightPegMesh);
			}
			if (pegs.pegsMaterial)
			{
				if (this.parts.frontLeftPeg)
				{
					NetworkScooterSyncAll.SafeSetMaterial(this.parts.frontLeftPeg, pegs.pegsMaterial);
				}
				if (this.parts.frontRightPeg)
				{
					NetworkScooterSyncAll.SafeSetMaterial(this.parts.frontRightPeg, pegs.pegsMaterial);
				}
				if (this.parts.rearLeftPeg)
				{
					NetworkScooterSyncAll.SafeSetMaterial(this.parts.rearLeftPeg, pegs.pegsMaterial);
				}
				if (this.parts.rearRightPeg)
				{
					NetworkScooterSyncAll.SafeSetMaterial(this.parts.rearRightPeg, pegs.pegsMaterial);
				}
			}
		}
		bool v = false;
		bool v2 = false;
		bool v3 = false;
		bool v4 = false;
		switch (cfg.pegOption)
		{
		case 0:
			v2 = (v = (v3 = (v4 = true)));
			break;
		case 1:
			v3 = (v = true);
			break;
		case 2:
			v4 = (v2 = true);
			break;
		case 3:
			v2 = (v = true);
			break;
		case 4:
			v4 = (v3 = true);
			break;
		case 5:
			break;
		default:
			v2 = (v = (v3 = (v4 = true)));
			break;
		}
		if (deck != null && deck.hasAddOns)
		{
			v4 = (v3 = false);
		}
		NetworkScooterSyncAll.SetActiveIfExists(this.parts.frontLeftPeg, v);
		NetworkScooterSyncAll.SetActiveIfExists(this.parts.frontRightPeg, v2);
		NetworkScooterSyncAll.SetActiveIfExists(this.parts.rearLeftPeg, v3);
		NetworkScooterSyncAll.SetActiveIfExists(this.parts.rearRightPeg, v4);
		if (this.details != null)
		{
			this.details.hasDeckPegs = cfg.hasDeckPegs;
		}
		if (this.grind != null)
		{
			this.grind.hasDeckPegs = cfg.hasDeckPegs;
			this.grind.SetPegs();
		}
	}

	// Token: 0x0600015C RID: 348 RVA: 0x0000C424 File Offset: 0x0000A624
	private DeckData GetDeck(FixedString64Bytes n)
	{
		if (!n.IsEmpty)
		{
			return this.partsLibrary.decks.Find((DeckData d) => d.deckName == n.ToString());
		}
		return null;
	}

	// Token: 0x0600015D RID: 349 RVA: 0x0000C46C File Offset: 0x0000A66C
	private BarsData GetBars(FixedString64Bytes n)
	{
		if (!n.IsEmpty)
		{
			return this.partsLibrary.bars.Find((BarsData d) => d.barsName == n.ToString());
		}
		return null;
	}

	// Token: 0x0600015E RID: 350 RVA: 0x0000C4B4 File Offset: 0x0000A6B4
	private ForksData GetForks(FixedString64Bytes n)
	{
		if (!n.IsEmpty)
		{
			return this.partsLibrary.forks.Find((ForksData d) => d.forksName == n.ToString());
		}
		return null;
	}

	// Token: 0x0600015F RID: 351 RVA: 0x0000C4FC File Offset: 0x0000A6FC
	private ClampData GetClamp(FixedString64Bytes n)
	{
		if (!n.IsEmpty)
		{
			return this.partsLibrary.clamps.Find((ClampData d) => d.clampName == n.ToString());
		}
		return null;
	}

	// Token: 0x06000160 RID: 352 RVA: 0x0000C544 File Offset: 0x0000A744
	private FrontWheelData GetFrontWheel(FixedString64Bytes n)
	{
		if (!n.IsEmpty)
		{
			return this.partsLibrary.frontWheels.Find((FrontWheelData d) => d.wheelName == n.ToString());
		}
		return null;
	}

	// Token: 0x06000161 RID: 353 RVA: 0x0000C58C File Offset: 0x0000A78C
	private RearWheelData GetRearWheel(FixedString64Bytes n)
	{
		if (!n.IsEmpty)
		{
			return this.partsLibrary.rearWheels.Find((RearWheelData d) => d.wheelName == n.ToString());
		}
		return null;
	}

	// Token: 0x06000162 RID: 354 RVA: 0x0000C5D4 File Offset: 0x0000A7D4
	private GripsData GetGrips(FixedString64Bytes n)
	{
		if (!n.IsEmpty)
		{
			return this.partsLibrary.grips.Find((GripsData d) => d.gripsName == n.ToString());
		}
		return null;
	}

	// Token: 0x06000163 RID: 355 RVA: 0x0000C61C File Offset: 0x0000A81C
	private BarEndsData GetBarEnds(FixedString64Bytes n)
	{
		if (!n.IsEmpty)
		{
			return this.partsLibrary.barEnds.Find((BarEndsData d) => d.barEndsName == n.ToString());
		}
		return null;
	}

	// Token: 0x06000164 RID: 356 RVA: 0x0000C664 File Offset: 0x0000A864
	private HeadsetData GetHeadset(FixedString64Bytes n)
	{
		if (!n.IsEmpty)
		{
			return this.partsLibrary.headsets.Find((HeadsetData d) => d.headsetName == n.ToString());
		}
		return null;
	}

	// Token: 0x06000165 RID: 357 RVA: 0x0000C6AC File Offset: 0x0000A8AC
	private GripTapeData GetGripTape(FixedString64Bytes n)
	{
		if (!n.IsEmpty)
		{
			return this.partsLibrary.gripTapes.Find((GripTapeData d) => d.gripTapeName == n.ToString());
		}
		return null;
	}

	// Token: 0x06000166 RID: 358 RVA: 0x0000C6F4 File Offset: 0x0000A8F4
	private PegsData GetPegs(FixedString64Bytes n)
	{
		if (!n.IsEmpty)
		{
			return this.partsLibrary.pegs.Find((PegsData d) => d.pegsName == n.ToString());
		}
		return null;
	}

	// Token: 0x06000167 RID: 359 RVA: 0x0000C73C File Offset: 0x0000A93C
	private static FixedString64Bytes ToFS(string s)
	{
		if (!string.IsNullOrEmpty(s))
		{
			return s;
		}
		return default(FixedString64Bytes);
	}

	// Token: 0x06000168 RID: 360 RVA: 0x0000C764 File Offset: 0x0000A964
	private static void SafeSetMesh(GameObject go, Mesh mesh)
	{
		MeshFilter meshFilter = go ? go.GetComponent<MeshFilter>() : null;
		if (meshFilter)
		{
			meshFilter.sharedMesh = mesh;
		}
	}

	// Token: 0x06000169 RID: 361 RVA: 0x0000C794 File Offset: 0x0000A994
	private static void SafeSetMaterial(GameObject go, Material mat)
	{
		MeshRenderer meshRenderer = go ? go.GetComponent<MeshRenderer>() : null;
		if (meshRenderer)
		{
			meshRenderer.sharedMaterial = mat;
		}
	}

	// Token: 0x0600016A RID: 362 RVA: 0x0000C7C2 File Offset: 0x0000A9C2
	private static void SetActiveIfExists(GameObject go, bool v)
	{
		if (go && go.activeSelf != v)
		{
			go.SetActive(v);
		}
	}

	// Token: 0x0600016D RID: 365 RVA: 0x0000C818 File Offset: 0x0000AA18
	protected override void __initializeVariables()
	{
		bool flag = this._config == null;
		if (flag)
		{
			throw new Exception("NetworkScooterSyncAll._config cannot be null. All NetworkVariableBase instances must be initialized.");
		}
		this._config.Initialize(this);
		base.__nameNetworkVariable(this._config, "_config");
		this.NetworkVariableFields.Add(this._config);
		base.__initializeVariables();
	}

	// Token: 0x0600016E RID: 366 RVA: 0x0000C87B File Offset: 0x0000AA7B
	protected override void __initializeRpcs()
	{
		base.__registerRpc(2494058560U, new NetworkBehaviour.RpcReceiveHandler(NetworkScooterSyncAll.__rpc_handler_2494058560), "SubmitFullServerRpc");
		base.__initializeRpcs();
	}

	// Token: 0x0600016F RID: 367 RVA: 0x0000C8A4 File Offset: 0x0000AAA4
	private static void __rpc_handler_2494058560(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
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
		NetworkScooterSyncAll.ScooterConfig cfg;
		reader.ReadValueSafe<NetworkScooterSyncAll.ScooterConfig>(out cfg, default(FastBufferWriter.ForNetworkSerializable));
		ServerRpcParams server = rpcParams.Server;
		target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Execute;
		((NetworkScooterSyncAll)target).SubmitFullServerRpc(cfg, server);
		target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
	}

	// Token: 0x06000170 RID: 368 RVA: 0x0000C96F File Offset: 0x0000AB6F
	protected internal override string __getTypeName()
	{
		return "NetworkScooterSyncAll";
	}

	// Token: 0x0400018F RID: 399
	[Header("References")]
	public ApplyCustomScooter apply;

	// Token: 0x04000190 RID: 400
	public ScooterPartsLibrary partsLibrary;

	// Token: 0x04000191 RID: 401
	private MyScooterParts parts;

	// Token: 0x04000192 RID: 402
	private GrindSystem grind;

	// Token: 0x04000193 RID: 403
	private ScooterDetails details;

	// Token: 0x04000194 RID: 404
	private NetworkVariable<NetworkScooterSyncAll.ScooterConfig> _config = new NetworkVariable<NetworkScooterSyncAll.ScooterConfig>(default(NetworkScooterSyncAll.ScooterConfig), NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);

	// Token: 0x02000058 RID: 88
	public struct ScooterConfig : INetworkSerializable, IEquatable<NetworkScooterSyncAll.ScooterConfig>
	{
		// Token: 0x06000171 RID: 369 RVA: 0x0000C978 File Offset: 0x0000AB78
		public void NetworkSerialize<T>(BufferSerializer<T> s) where T : IReaderWriter
		{
			s.SerializeValue<FixedString64Bytes>(ref this.deck, default(FastBufferWriter.ForFixedStrings));
			s.SerializeValue<FixedString64Bytes>(ref this.bars, default(FastBufferWriter.ForFixedStrings));
			s.SerializeValue<FixedString64Bytes>(ref this.fork, default(FastBufferWriter.ForFixedStrings));
			s.SerializeValue<FixedString64Bytes>(ref this.clamp, default(FastBufferWriter.ForFixedStrings));
			s.SerializeValue<FixedString64Bytes>(ref this.frontWheel, default(FastBufferWriter.ForFixedStrings));
			s.SerializeValue<FixedString64Bytes>(ref this.rearWheel, default(FastBufferWriter.ForFixedStrings));
			s.SerializeValue<FixedString64Bytes>(ref this.grips, default(FastBufferWriter.ForFixedStrings));
			s.SerializeValue<FixedString64Bytes>(ref this.barEnds, default(FastBufferWriter.ForFixedStrings));
			s.SerializeValue<FixedString64Bytes>(ref this.headset, default(FastBufferWriter.ForFixedStrings));
			s.SerializeValue<FixedString64Bytes>(ref this.gripTape, default(FastBufferWriter.ForFixedStrings));
			s.SerializeValue<FixedString64Bytes>(ref this.pegs, default(FastBufferWriter.ForFixedStrings));
			s.SerializeValue<int>(ref this.pegOption, default(FastBufferWriter.ForPrimitives));
			s.SerializeValue<bool>(ref this.hasDeckPegs, default(FastBufferWriter.ForPrimitives));
		}

		// Token: 0x06000172 RID: 370 RVA: 0x0000CAA4 File Offset: 0x0000ACA4
		public bool Equals(NetworkScooterSyncAll.ScooterConfig o)
		{
			return this.deck.Equals(o.deck) && this.bars.Equals(o.bars) && this.fork.Equals(o.fork) && this.clamp.Equals(o.clamp) && this.frontWheel.Equals(o.frontWheel) && this.rearWheel.Equals(o.rearWheel) && this.grips.Equals(o.grips) && this.barEnds.Equals(o.barEnds) && this.headset.Equals(o.headset) && this.gripTape.Equals(o.gripTape) && this.pegs.Equals(o.pegs) && this.pegOption == o.pegOption && this.hasDeckPegs == o.hasDeckPegs;
		}

		// Token: 0x04000195 RID: 405
		public FixedString64Bytes deck;

		// Token: 0x04000196 RID: 406
		public FixedString64Bytes bars;

		// Token: 0x04000197 RID: 407
		public FixedString64Bytes fork;

		// Token: 0x04000198 RID: 408
		public FixedString64Bytes clamp;

		// Token: 0x04000199 RID: 409
		public FixedString64Bytes frontWheel;

		// Token: 0x0400019A RID: 410
		public FixedString64Bytes rearWheel;

		// Token: 0x0400019B RID: 411
		public FixedString64Bytes grips;

		// Token: 0x0400019C RID: 412
		public FixedString64Bytes barEnds;

		// Token: 0x0400019D RID: 413
		public FixedString64Bytes headset;

		// Token: 0x0400019E RID: 414
		public FixedString64Bytes gripTape;

		// Token: 0x0400019F RID: 415
		public FixedString64Bytes pegs;

		// Token: 0x040001A0 RID: 416
		public int pegOption;

		// Token: 0x040001A1 RID: 417
		public bool hasDeckPegs;
	}
}
