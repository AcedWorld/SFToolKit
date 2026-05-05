using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Steamworks;
using Unity.Netcode;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using Unity.Services.Qos;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x02000074 RID: 116
public class NetworkLobbyManager : MonoBehaviour
{
	// Token: 0x060001CC RID: 460 RVA: 0x0000F49C File Offset: 0x0000D69C
	private void AssignSlotFor(ulong clientId)
	{
		if (this.clientSlot.ContainsKey(clientId))
		{
			return;
		}
		int num;
		if (this.freedSlots.Count > 0)
		{
			num = this.GetAndRemoveFirstFreeSlot();
		}
		else
		{
			num = this.clientSlot.Count;
		}
		this.clientSlot[clientId] = num;
		if (this.enableDebugLogs)
		{
			Debug.Log(string.Format("[Slots] Assigned slot {0} to client {1}", num, clientId));
		}
	}

	// Token: 0x060001CD RID: 461 RVA: 0x0000F50C File Offset: 0x0000D70C
	private int GetAndRemoveFirstFreeSlot()
	{
		int num = -1;
		using (SortedSet<int>.Enumerator enumerator = this.freedSlots.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				num = enumerator.Current;
			}
		}
		if (num >= 0)
		{
			this.freedSlots.Remove(num);
		}
		return num;
	}

	// Token: 0x060001CE RID: 462 RVA: 0x0000F570 File Offset: 0x0000D770
	private void OnClientDisconnected(ulong clientId)
	{
		NetworkLobbyManager.<OnClientDisconnected>d__28 <OnClientDisconnected>d__;
		<OnClientDisconnected>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
		<OnClientDisconnected>d__.<>4__this = this;
		<OnClientDisconnected>d__.clientId = clientId;
		<OnClientDisconnected>d__.<>1__state = -1;
		<OnClientDisconnected>d__.<>t__builder.Start<NetworkLobbyManager.<OnClientDisconnected>d__28>(ref <OnClientDisconnected>d__);
	}

	// Token: 0x060001CF RID: 463 RVA: 0x0000F5AF File Offset: 0x0000D7AF
	private void Awake()
	{
		if (NetworkLobbyManager.Instance == null)
		{
			NetworkLobbyManager.Instance = this;
			return;
		}
		Object.Destroy(base.gameObject);
	}

	// Token: 0x060001D0 RID: 464 RVA: 0x0000F5D0 File Offset: 0x0000D7D0
	private Task RefreshAndJoinFirstLobby()
	{
		NetworkLobbyManager.<RefreshAndJoinFirstLobby>d__30 <RefreshAndJoinFirstLobby>d__;
		<RefreshAndJoinFirstLobby>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
		<RefreshAndJoinFirstLobby>d__.<>4__this = this;
		<RefreshAndJoinFirstLobby>d__.<>1__state = -1;
		<RefreshAndJoinFirstLobby>d__.<>t__builder.Start<NetworkLobbyManager.<RefreshAndJoinFirstLobby>d__30>(ref <RefreshAndJoinFirstLobby>d__);
		return <RefreshAndJoinFirstLobby>d__.<>t__builder.Task;
	}

	// Token: 0x060001D1 RID: 465 RVA: 0x0000F614 File Offset: 0x0000D814
	private void Start()
	{
		NetworkLobbyManager.<Start>d__31 <Start>d__;
		<Start>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
		<Start>d__.<>4__this = this;
		<Start>d__.<>1__state = -1;
		<Start>d__.<>t__builder.Start<NetworkLobbyManager.<Start>d__31>(ref <Start>d__);
	}

	// Token: 0x060001D2 RID: 466 RVA: 0x0000F64B File Offset: 0x0000D84B
	private IEnumerator UpdateGameplayPing()
	{
		WaitForSeconds wait = new WaitForSeconds(1f);
		while (NetworkManager.Singleton.IsHost)
		{
			this.gameplayPingMs = (int)NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetCurrentRtt(NetworkManager.Singleton.NetworkConfig.NetworkTransport.ServerClientId);
			yield return wait;
		}
		yield break;
	}

	// Token: 0x060001D3 RID: 467 RVA: 0x0000F65C File Offset: 0x0000D85C
	private void BootToMainMenu(string reason = null)
	{
		NetworkLobbyManager.<BootToMainMenu>d__33 <BootToMainMenu>d__;
		<BootToMainMenu>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
		<BootToMainMenu>d__.<>4__this = this;
		<BootToMainMenu>d__.reason = reason;
		<BootToMainMenu>d__.<>1__state = -1;
		<BootToMainMenu>d__.<>t__builder.Start<NetworkLobbyManager.<BootToMainMenu>d__33>(ref <BootToMainMenu>d__);
	}

	// Token: 0x060001D4 RID: 468 RVA: 0x0000F69B File Offset: 0x0000D89B
	private IEnumerator WaitForSteamName()
	{
		float timeout = 15f;
		float elapsed = 0f;
		string steamName = "";
		while (string.IsNullOrEmpty(steamName) && elapsed < timeout)
		{
			if (SteamManager.Initialized)
			{
				steamName = SteamFriends.GetPersonaName();
				if (this.enableDebugLogs)
				{
					Debug.Log("[Steam] Persona name: '" + steamName + "'");
				}
			}
			elapsed += Time.deltaTime;
			yield return null;
		}
		if (!string.IsNullOrEmpty(steamName))
		{
			this.steamNameReady = true;
			this.lobbyPreset.steamName = steamName;
			if (this.enableDebugLogs)
			{
				Debug.Log("[Steam] Final name set: " + steamName);
			}
		}
		else if (this.enableDebugLogs)
		{
			Debug.LogWarning("[Steam] Persona name not retrieved before timeout.");
		}
		yield break;
	}

	// Token: 0x060001D5 RID: 469 RVA: 0x0000F6AC File Offset: 0x0000D8AC
	private void OnClientConnected(ulong clientId)
	{
		NetworkLobbyManager.<OnClientConnected>d__35 <OnClientConnected>d__;
		<OnClientConnected>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
		<OnClientConnected>d__.<>4__this = this;
		<OnClientConnected>d__.clientId = clientId;
		<OnClientConnected>d__.<>1__state = -1;
		<OnClientConnected>d__.<>t__builder.Start<NetworkLobbyManager.<OnClientConnected>d__35>(ref <OnClientConnected>d__);
	}

	// Token: 0x060001D6 RID: 470 RVA: 0x0000F6EB File Offset: 0x0000D8EB
	private IEnumerator SpawnPlayerAtJoin(ulong clientId)
	{
		yield return null;
		if (this.playerPrefab == null)
		{
			if (this.enableDebugLogs)
			{
				Debug.LogError("[Spawn] playerPrefab is NOT assigned!");
			}
			yield break;
		}
		if (this.spawnPoints == null || this.spawnPoints.Length == 0)
		{
			List<Transform> list = new List<Transform>();
			for (int i = 1; i <= 16; i++)
			{
				GameObject gameObject = GameObject.Find(string.Format("SpawnPoint{0}", i));
				if (gameObject != null)
				{
					list.Add(gameObject.transform);
				}
			}
			this.spawnPoints = list.ToArray();
		}
		int num;
		if (!this.clientSlot.TryGetValue(clientId, out num))
		{
			num = this.joinOrder.IndexOf(clientId);
		}
		if (num < 0 || num >= this.spawnPoints.Length)
		{
			if (this.enableDebugLogs)
			{
				Debug.LogWarning(string.Format("[Spawn] Invalid index {0} for client {1}", num, clientId));
			}
			yield break;
		}
		Transform transform = this.spawnPoints[num];
		if (!NetworkManager.Singleton.IsServer)
		{
			if (this.enableDebugLogs)
			{
				Debug.Log(string.Format("[Spawn] Ignored on client {0}, only server spawns players.", clientId));
			}
			yield break;
		}
		NetworkObject networkObject;
		if (!Object.Instantiate<GameObject>(this.playerPrefab, transform.position, transform.rotation).TryGetComponent<NetworkObject>(out networkObject))
		{
			Debug.LogError("[Spawn] Instantiated player missing NetworkObject!");
			yield break;
		}
		networkObject.SpawnAsPlayerObject(clientId, false);
		if (this.enableDebugLogs)
		{
			Debug.Log(string.Format("[Spawn] Player for client {0} spawned at {1} ({2})", clientId, transform.name, transform.position));
		}
		yield break;
	}

	// Token: 0x060001D7 RID: 471 RVA: 0x0000F704 File Offset: 0x0000D904
	private Task InitializeServices()
	{
		NetworkLobbyManager.<InitializeServices>d__37 <InitializeServices>d__;
		<InitializeServices>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
		<InitializeServices>d__.<>4__this = this;
		<InitializeServices>d__.<>1__state = -1;
		<InitializeServices>d__.<>t__builder.Start<NetworkLobbyManager.<InitializeServices>d__37>(ref <InitializeServices>d__);
		return <InitializeServices>d__.<>t__builder.Task;
	}

	// Token: 0x060001D8 RID: 472 RVA: 0x0000F748 File Offset: 0x0000D948
	public Task<string> HostPublicGame(string passwordOverride = "")
	{
		NetworkLobbyManager.<HostPublicGame>d__38 <HostPublicGame>d__;
		<HostPublicGame>d__.<>t__builder = AsyncTaskMethodBuilder<string>.Create();
		<HostPublicGame>d__.<>4__this = this;
		<HostPublicGame>d__.passwordOverride = passwordOverride;
		<HostPublicGame>d__.<>1__state = -1;
		<HostPublicGame>d__.<>t__builder.Start<NetworkLobbyManager.<HostPublicGame>d__38>(ref <HostPublicGame>d__);
		return <HostPublicGame>d__.<>t__builder.Task;
	}

	// Token: 0x060001D9 RID: 473 RVA: 0x0000F793 File Offset: 0x0000D993
	private IEnumerator LobbyHeartbeat()
	{
		WaitForSeconds wait = new WaitForSeconds(5f);
		while (this.currentLobby != null && NetworkManager.Singleton.IsHost)
		{
			yield return wait;
			int hostPing = (int)NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetCurrentRtt(NetworkManager.Singleton.LocalClientId);
			int hostRegionLatency = -1;
			DataObject dataObject;
			string region = this.currentLobby.Data.TryGetValue("region", out dataObject) ? dataObject.Value : null;
			Task<IList<IQosResult>> qosTask = null;
			if (!string.IsNullOrEmpty(region))
			{
				qosTask = QosService.Instance.GetSortedQosResultsAsync(region, null);
				while (!qosTask.IsCompleted)
				{
					yield return null;
				}
				if (qosTask.Exception == null)
				{
					IList<IQosResult> result = qosTask.Result;
					if (result != null && result.Count > 0)
					{
						hostRegionLatency = result[0].AverageLatencyMs;
					}
				}
				else if (this.enableDebugLogs)
				{
					Debug.LogWarning("[Heartbeat] QoS error for region " + region + ": " + qosTask.Exception.Message);
				}
			}
			int value = 0;
			try
			{
				if (NetworkManager.Singleton != null && NetworkManager.Singleton.IsListening)
				{
					value = NetworkManager.Singleton.ConnectedClientsIds.Count;
				}
			}
			catch
			{
			}
			int num = (this.currentLobby.MaxPlayers > 0) ? this.currentLobby.MaxPlayers : 8;
			string text = string.Format("{0}/{1}", Mathf.Clamp(value, 0, num), num);
			LobbyService.Instance.SendHeartbeatPingAsync(this.currentLobby.Id);
			LobbyService.Instance.UpdateLobbyAsync(this.currentLobby.Id, new UpdateLobbyOptions
			{
				Data = new Dictionary<string, DataObject>
				{
					{
						"players",
						new DataObject(DataObject.VisibilityOptions.Public, text, (DataObject.IndexOptions)0)
					},
					{
						"hostPing",
						new DataObject(DataObject.VisibilityOptions.Public, hostPing.ToString(), (DataObject.IndexOptions)0)
					},
					{
						"hostQoS",
						new DataObject(DataObject.VisibilityOptions.Public, hostRegionLatency.ToString(), (DataObject.IndexOptions)0)
					}
				}
			});
			for (int i = 0; i < this.discoveredLobbies.Count; i++)
			{
				if (this.discoveredLobbies[i].lobbyId == this.currentLobby.Id)
				{
					this.discoveredLobbies[i].playerCount = text;
					break;
				}
			}
			if (this.enableDebugLogs)
			{
				Debug.Log("[Lobby] Heartbeat sent");
			}
			region = null;
			qosTask = null;
		}
		yield break;
	}

	// Token: 0x060001DA RID: 474 RVA: 0x0000F7A4 File Offset: 0x0000D9A4
	public Task<bool> JoinLobbyById(string lobbyId, string enteredPassword)
	{
		NetworkLobbyManager.<JoinLobbyById>d__40 <JoinLobbyById>d__;
		<JoinLobbyById>d__.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
		<JoinLobbyById>d__.<>4__this = this;
		<JoinLobbyById>d__.lobbyId = lobbyId;
		<JoinLobbyById>d__.enteredPassword = enteredPassword;
		<JoinLobbyById>d__.<>1__state = -1;
		<JoinLobbyById>d__.<>t__builder.Start<NetworkLobbyManager.<JoinLobbyById>d__40>(ref <JoinLobbyById>d__);
		return <JoinLobbyById>d__.<>t__builder.Task;
	}

	// Token: 0x060001DB RID: 475 RVA: 0x0000F7F8 File Offset: 0x0000D9F8
	private Task<bool> WaitForLocalClientConnected(float timeoutSeconds)
	{
		NetworkLobbyManager.<WaitForLocalClientConnected>d__41 <WaitForLocalClientConnected>d__;
		<WaitForLocalClientConnected>d__.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
		<WaitForLocalClientConnected>d__.timeoutSeconds = timeoutSeconds;
		<WaitForLocalClientConnected>d__.<>1__state = -1;
		<WaitForLocalClientConnected>d__.<>t__builder.Start<NetworkLobbyManager.<WaitForLocalClientConnected>d__41>(ref <WaitForLocalClientConnected>d__);
		return <WaitForLocalClientConnected>d__.<>t__builder.Task;
	}

	// Token: 0x060001DC RID: 476 RVA: 0x0000F83C File Offset: 0x0000DA3C
	public Task UpdateDiscoveredLobbies()
	{
		NetworkLobbyManager.<UpdateDiscoveredLobbies>d__42 <UpdateDiscoveredLobbies>d__;
		<UpdateDiscoveredLobbies>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
		<UpdateDiscoveredLobbies>d__.<>4__this = this;
		<UpdateDiscoveredLobbies>d__.<>1__state = -1;
		<UpdateDiscoveredLobbies>d__.<>t__builder.Start<NetworkLobbyManager.<UpdateDiscoveredLobbies>d__42>(ref <UpdateDiscoveredLobbies>d__);
		return <UpdateDiscoveredLobbies>d__.<>t__builder.Task;
	}

	// Token: 0x060001DD RID: 477 RVA: 0x0000F880 File Offset: 0x0000DA80
	public Task<int> MeasureRelayPingAsync(string joinCode)
	{
		NetworkLobbyManager.<MeasureRelayPingAsync>d__43 <MeasureRelayPingAsync>d__;
		<MeasureRelayPingAsync>d__.<>t__builder = AsyncTaskMethodBuilder<int>.Create();
		<MeasureRelayPingAsync>d__.joinCode = joinCode;
		<MeasureRelayPingAsync>d__.<>1__state = -1;
		<MeasureRelayPingAsync>d__.<>t__builder.Start<NetworkLobbyManager.<MeasureRelayPingAsync>d__43>(ref <MeasureRelayPingAsync>d__);
		return <MeasureRelayPingAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060001DE RID: 478 RVA: 0x0000F8C3 File Offset: 0x0000DAC3
	public void FailedToCreateSession()
	{
		UnityEvent onHostFail = this.OnHostFail;
		if (onHostFail == null)
		{
			return;
		}
		onHostFail.Invoke();
	}

	// Token: 0x060001DF RID: 479 RVA: 0x0000F8D8 File Offset: 0x0000DAD8
	public void HostOnlineSessionButton()
	{
		NetworkLobbyManager.<HostOnlineSessionButton>d__45 <HostOnlineSessionButton>d__;
		<HostOnlineSessionButton>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
		<HostOnlineSessionButton>d__.<>4__this = this;
		<HostOnlineSessionButton>d__.<>1__state = -1;
		<HostOnlineSessionButton>d__.<>t__builder.Start<NetworkLobbyManager.<HostOnlineSessionButton>d__45>(ref <HostOnlineSessionButton>d__);
	}

	// Token: 0x060001E0 RID: 480 RVA: 0x0000F90F File Offset: 0x0000DB0F
	public void DespawnSelf()
	{
		NetworkManager.Singleton.Shutdown(false);
	}

	// Token: 0x060001E1 RID: 481 RVA: 0x0000F91C File Offset: 0x0000DB1C
	public Task RemoveSelfFromAnyLobby()
	{
		NetworkLobbyManager.<RemoveSelfFromAnyLobby>d__47 <RemoveSelfFromAnyLobby>d__;
		<RemoveSelfFromAnyLobby>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
		<RemoveSelfFromAnyLobby>d__.<>4__this = this;
		<RemoveSelfFromAnyLobby>d__.<>1__state = -1;
		<RemoveSelfFromAnyLobby>d__.<>t__builder.Start<NetworkLobbyManager.<RemoveSelfFromAnyLobby>d__47>(ref <RemoveSelfFromAnyLobby>d__);
		return <RemoveSelfFromAnyLobby>d__.<>t__builder.Task;
	}

	// Token: 0x060001E2 RID: 482 RVA: 0x0000F960 File Offset: 0x0000DB60
	public Transform GetSpawnPointForClient(ulong clientId)
	{
		int num = this.joinOrder.IndexOf(clientId);
		if (num >= 0 && num < this.spawnPoints.Length)
		{
			return this.spawnPoints[num];
		}
		return null;
	}

	// Token: 0x060001E3 RID: 483 RVA: 0x0000F993 File Offset: 0x0000DB93
	[ContextMenu("Host Lobby")]
	public void HostViaInspector()
	{
		this.HostPublicGame(this.password);
	}

	// Token: 0x060001E4 RID: 484 RVA: 0x0000F9A2 File Offset: 0x0000DBA2
	[ContextMenu("Join Selected Lobby")]
	public void JoinViaInspector()
	{
		if (this.selectedLobbyIndex >= 0 && this.selectedLobbyIndex < this.discoveredLobbies.Count)
		{
			this.JoinLobbyById(this.lobbyIdToJoin, this.password);
		}
	}

	// Token: 0x060001E5 RID: 485 RVA: 0x0000F9D3 File Offset: 0x0000DBD3
	[ContextMenu("Refresh Lobby List")]
	public void RefreshLobbiesInspector()
	{
		this.UpdateDiscoveredLobbies();
	}

	// Token: 0x060001E6 RID: 486 RVA: 0x0000F9DC File Offset: 0x0000DBDC
	public string GetMaskedSceneName(string realSceneName)
	{
		foreach (SceneNameMask sceneNameMask in this.sceneNameMasks)
		{
			if (sceneNameMask.realSceneName == realSceneName)
			{
				return sceneNameMask.maskedSceneName;
			}
		}
		return realSceneName;
	}

	// Token: 0x0400021C RID: 540
	public static NetworkLobbyManager Instance;

	// Token: 0x0400021D RID: 541
	[Header("Debugging")]
	public bool enableDebugLogs;

	// Token: 0x0400021E RID: 542
	[Header("Scene Name Masks")]
	public List<SceneNameMask> sceneNameMasks = new List<SceneNameMask>();

	// Token: 0x0400021F RID: 543
	[Header("Lobby Settings")]
	public string password = "";

	// Token: 0x04000220 RID: 544
	public string lobbyIdToJoin = "";

	// Token: 0x04000221 RID: 545
	public List<LobbyInfo> discoveredLobbies = new List<LobbyInfo>();

	// Token: 0x04000222 RID: 546
	[Header("Spawn Setup")]
	[SerializeField]
	private Transform[] spawnPoints;

	// Token: 0x04000223 RID: 547
	[SerializeField]
	private GameObject playerPrefab;

	// Token: 0x04000224 RID: 548
	private Lobby currentLobby;

	// Token: 0x04000225 RID: 549
	private bool initialized;

	// Token: 0x04000226 RID: 550
	private List<ulong> joinOrder = new List<ulong>();

	// Token: 0x04000227 RID: 551
	[HideInInspector]
	public LobbyPreset lobbyPreset = new LobbyPreset();

	// Token: 0x04000228 RID: 552
	[HideInInspector]
	public int selectedLobbyIndex = -1;

	// Token: 0x04000229 RID: 553
	private bool steamNameReady;

	// Token: 0x0400022A RID: 554
	private bool isBusy;

	// Token: 0x0400022B RID: 555
	[Header("Live Gameplay Ping")]
	public int gameplayPingMs = -1;

	// Token: 0x0400022C RID: 556
	[Header("Events")]
	public UnityEvent OnLobbyHosted;

	// Token: 0x0400022D RID: 557
	public UnityEvent OnLobbyJoined;

	// Token: 0x0400022E RID: 558
	public UnityEvent OnHostFail;

	// Token: 0x0400022F RID: 559
	[Header("UI & Menu")]
	[SerializeField]
	private string mainMenuScene = "MainMenu";

	// Token: 0x04000230 RID: 560
	[SerializeField]
	private GameObject loadingScreenPrefab;

	// Token: 0x04000231 RID: 561
	private bool _isBootingToMenu;

	// Token: 0x04000232 RID: 562
	private GameObject _spawnedLoadingScreen;

	// Token: 0x04000233 RID: 563
	private readonly Dictionary<ulong, int> clientSlot = new Dictionary<ulong, int>();

	// Token: 0x04000234 RID: 564
	private readonly SortedSet<int> freedSlots = new SortedSet<int>();

	// Token: 0x04000235 RID: 565
	public bool DisableExitHandler;
}
