using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity.Netcode
{
	// Token: 0x02000020 RID: 32
	[AddComponentMenu("Netcode/Network Manager", -100)]
	public class NetworkManager : MonoBehaviour, INetworkUpdateSystem
	{
		// Token: 0x14000005 RID: 5
		// (add) Token: 0x060000EC RID: 236 RVA: 0x00006B5C File Offset: 0x00004D5C
		// (remove) Token: 0x060000ED RID: 237 RVA: 0x00006B90 File Offset: 0x00004D90
		public static event Action<NetworkManager> OnInstantiated;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x060000EE RID: 238 RVA: 0x00006BC4 File Offset: 0x00004DC4
		// (remove) Token: 0x060000EF RID: 239 RVA: 0x00006BF8 File Offset: 0x00004DF8
		public static event Action<NetworkManager> OnDestroying;

		// Token: 0x060000F0 RID: 240 RVA: 0x00006C2C File Offset: 0x00004E2C
		public void NetworkUpdate(NetworkUpdateStage updateStage)
		{
			switch (updateStage)
			{
			case NetworkUpdateStage.EarlyUpdate:
				this.ConnectionManager.ProcessPendingApprovals();
				this.ConnectionManager.PollAndHandleNetworkEvents();
				this.DeferredMessageManager.ProcessTriggers(IDeferredNetworkMessageManager.TriggerType.OnNextFrame, 0UL);
				this.AnticipationSystem.SetupForUpdate();
				this.MessageManager.ProcessIncomingMessageQueue();
				this.MessageManager.CleanupDisconnectedClients();
				this.AnticipationSystem.ProcessReanticipation();
				return;
			case NetworkUpdateStage.FixedUpdate:
			case NetworkUpdateStage.Update:
			case NetworkUpdateStage.PreLateUpdate:
				break;
			case NetworkUpdateStage.PreUpdate:
				this.NetworkTimeSystem.UpdateTime();
				this.AnticipationSystem.Update();
				return;
			case NetworkUpdateStage.PostLateUpdate:
				this.SceneManager.CheckForAndSendNetworkObjectSceneChanged();
				this.MessageManager.ProcessSendQueues();
				this.MetricsManager.UpdateMetrics();
				NetworkObject.VerifyParentingStatus();
				this.DeferredMessageManager.CleanupStaleTriggers();
				if (this.m_ShuttingDown)
				{
					if (this.IsServer)
					{
						this.ProcessServerShutdown();
						return;
					}
					this.ShutdownInternal();
				}
				break;
			case NetworkUpdateStage.PostScriptLateUpdate:
				this.AnticipationSystem.Sync();
				this.AnticipationSystem.SetupForRender();
				return;
			default:
				return;
			}
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00006D2C File Offset: 0x00004F2C
		internal void ProcessServerShutdown()
		{
			int num = this.IsHost ? 2 : 1;
			switch (this.ServerShutdownState)
			{
			case NetworkManager.ServerShutdownStates.None:
				if (this.ConnectedClients.Count >= num)
				{
					string str = this.IsHost ? "host" : "server";
					string reason = "Disconnected due to " + str + " shutting down.";
					for (int i = this.ConnectedClientsIds.Count - 1; i >= 0; i--)
					{
						ulong num2 = this.ConnectedClientsIds[i];
						if (num2 != 0UL)
						{
							this.ConnectionManager.DisconnectClient(num2, reason);
						}
					}
					this.ServerShutdownState = NetworkManager.ServerShutdownStates.WaitForClientDisconnects;
					this.m_ShutdownTimeout = Time.realtimeSinceStartup + 5f;
					return;
				}
				this.ServerShutdownState = NetworkManager.ServerShutdownStates.InternalShutdown;
				this.ProcessServerShutdown();
				return;
			case NetworkManager.ServerShutdownStates.WaitForClientDisconnects:
				if (this.ConnectedClients.Count < num || this.m_ShutdownTimeout < Time.realtimeSinceStartup)
				{
					this.ServerShutdownState = NetworkManager.ServerShutdownStates.InternalShutdown;
					this.ProcessServerShutdown();
					return;
				}
				break;
			case NetworkManager.ServerShutdownStates.InternalShutdown:
				this.ServerShutdownState = NetworkManager.ServerShutdownStates.ShuttingDown;
				this.ShutdownInternal();
				break;
			default:
				return;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x00006E2E File Offset: 0x0000502E
		// (set) Token: 0x060000F3 RID: 243 RVA: 0x00006E40 File Offset: 0x00005040
		public ulong LocalClientId
		{
			get
			{
				return this.ConnectionManager.LocalClient.ClientId;
			}
			internal set
			{
				this.ConnectionManager.LocalClient.ClientId = value;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000F4 RID: 244 RVA: 0x00006E53 File Offset: 0x00005053
		public IReadOnlyDictionary<ulong, NetworkClient> ConnectedClients
		{
			get
			{
				if (!this.IsServer)
				{
					throw new NotServerException("ConnectedClients should only be accessed on server.");
				}
				return this.ConnectionManager.ConnectedClients;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000F5 RID: 245 RVA: 0x00006E73 File Offset: 0x00005073
		public IReadOnlyList<NetworkClient> ConnectedClientsList
		{
			get
			{
				if (!this.IsServer)
				{
					throw new NotServerException("ConnectedClientsList should only be accessed on server.");
				}
				return this.ConnectionManager.ConnectedClientsList;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000F6 RID: 246 RVA: 0x00006E93 File Offset: 0x00005093
		public IReadOnlyList<ulong> ConnectedClientsIds
		{
			get
			{
				return this.ConnectionManager.ConnectedClientIds;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000F7 RID: 247 RVA: 0x00006EA0 File Offset: 0x000050A0
		public NetworkClient LocalClient
		{
			get
			{
				return this.ConnectionManager.LocalClient;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000F8 RID: 248 RVA: 0x00006EAD File Offset: 0x000050AD
		public bool IsServer
		{
			get
			{
				return this.ConnectionManager.LocalClient.IsServer;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000F9 RID: 249 RVA: 0x00006EBF File Offset: 0x000050BF
		public bool ServerIsHost
		{
			get
			{
				return this.ConnectionManager.ConnectedClientIds.Contains(0UL);
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000FA RID: 250 RVA: 0x00006ED3 File Offset: 0x000050D3
		public bool IsClient
		{
			get
			{
				return this.ConnectionManager.LocalClient.IsClient;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000FB RID: 251 RVA: 0x00006EE5 File Offset: 0x000050E5
		public bool IsHost
		{
			get
			{
				return this.ConnectionManager.LocalClient.IsHost;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000FC RID: 252 RVA: 0x00006EF7 File Offset: 0x000050F7
		public string DisconnectReason
		{
			get
			{
				return this.ConnectionManager.DisconnectReason;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000FD RID: 253 RVA: 0x00006F04 File Offset: 0x00005104
		// (set) Token: 0x060000FE RID: 254 RVA: 0x00006F11 File Offset: 0x00005111
		public bool IsListening
		{
			get
			{
				return this.ConnectionManager.IsListening;
			}
			internal set
			{
				this.ConnectionManager.IsListening = value;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000FF RID: 255 RVA: 0x00006F1F File Offset: 0x0000511F
		// (set) Token: 0x06000100 RID: 256 RVA: 0x00006F31 File Offset: 0x00005131
		public bool IsConnectedClient
		{
			get
			{
				return this.ConnectionManager.LocalClient.IsConnected;
			}
			internal set
			{
				this.ConnectionManager.LocalClient.IsConnected = value;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000101 RID: 257 RVA: 0x00006F44 File Offset: 0x00005144
		// (set) Token: 0x06000102 RID: 258 RVA: 0x00006F56 File Offset: 0x00005156
		public bool IsApproved
		{
			get
			{
				return this.ConnectionManager.LocalClient.IsApproved;
			}
			internal set
			{
				this.ConnectionManager.LocalClient.IsApproved = value;
			}
		}

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000103 RID: 259 RVA: 0x00006F69 File Offset: 0x00005169
		// (remove) Token: 0x06000104 RID: 260 RVA: 0x00006F77 File Offset: 0x00005177
		public event Action OnTransportFailure
		{
			add
			{
				this.ConnectionManager.OnTransportFailure += value;
			}
			remove
			{
				this.ConnectionManager.OnTransportFailure -= value;
			}
		}

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06000105 RID: 261 RVA: 0x00006F85 File Offset: 0x00005185
		// (remove) Token: 0x06000106 RID: 262 RVA: 0x00006F93 File Offset: 0x00005193
		public event NetworkManager.ReanticipateDelegate OnReanticipate
		{
			add
			{
				this.AnticipationSystem.OnReanticipate += value;
			}
			remove
			{
				this.AnticipationSystem.OnReanticipate -= value;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000107 RID: 263 RVA: 0x00006FA1 File Offset: 0x000051A1
		// (set) Token: 0x06000108 RID: 264 RVA: 0x00006FAE File Offset: 0x000051AE
		public Action<NetworkManager.ConnectionApprovalRequest, NetworkManager.ConnectionApprovalResponse> ConnectionApprovalCallback
		{
			get
			{
				return this.ConnectionManager.ConnectionApprovalCallback;
			}
			set
			{
				if (value != null && value.GetInvocationList().Length > 1)
				{
					throw new InvalidOperationException("Only one ConnectionApprovalCallback can be registered at a time.");
				}
				this.ConnectionManager.ConnectionApprovalCallback = value;
			}
		}

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06000109 RID: 265 RVA: 0x00006FD5 File Offset: 0x000051D5
		// (remove) Token: 0x0600010A RID: 266 RVA: 0x00006FE3 File Offset: 0x000051E3
		public event Action<ulong> OnClientConnectedCallback
		{
			add
			{
				this.ConnectionManager.OnClientConnectedCallback += value;
			}
			remove
			{
				this.ConnectionManager.OnClientConnectedCallback -= value;
			}
		}

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x0600010B RID: 267 RVA: 0x00006FF1 File Offset: 0x000051F1
		// (remove) Token: 0x0600010C RID: 268 RVA: 0x00006FFF File Offset: 0x000051FF
		public event Action<ulong> OnClientDisconnectCallback
		{
			add
			{
				this.ConnectionManager.OnClientDisconnectCallback += value;
			}
			remove
			{
				this.ConnectionManager.OnClientDisconnectCallback -= value;
			}
		}

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x0600010D RID: 269 RVA: 0x0000700D File Offset: 0x0000520D
		// (remove) Token: 0x0600010E RID: 270 RVA: 0x0000701B File Offset: 0x0000521B
		public event Action<NetworkManager, ConnectionEventData> OnConnectionEvent
		{
			add
			{
				this.ConnectionManager.OnConnectionEvent += value;
			}
			remove
			{
				this.ConnectionManager.OnConnectionEvent -= value;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600010F RID: 271 RVA: 0x00007029 File Offset: 0x00005229
		public string ConnectedHostname
		{
			get
			{
				return string.Empty;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000110 RID: 272 RVA: 0x00007030 File Offset: 0x00005230
		public bool ShutdownInProgress
		{
			get
			{
				return this.m_ShuttingDown;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000111 RID: 273 RVA: 0x00007038 File Offset: 0x00005238
		public NetworkTime LocalTime
		{
			get
			{
				NetworkTickSystem networkTickSystem = this.NetworkTickSystem;
				if (networkTickSystem == null)
				{
					return default(NetworkTime);
				}
				return networkTickSystem.LocalTime;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000112 RID: 274 RVA: 0x00007060 File Offset: 0x00005260
		public NetworkTime ServerTime
		{
			get
			{
				NetworkTickSystem networkTickSystem = this.NetworkTickSystem;
				if (networkTickSystem == null)
				{
					return default(NetworkTime);
				}
				return networkTickSystem.ServerTime;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000113 RID: 275 RVA: 0x00007086 File Offset: 0x00005286
		// (set) Token: 0x06000114 RID: 276 RVA: 0x0000708D File Offset: 0x0000528D
		public static NetworkManager Singleton { get; private set; }

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x06000115 RID: 277 RVA: 0x00007098 File Offset: 0x00005298
		// (remove) Token: 0x06000116 RID: 278 RVA: 0x000070CC File Offset: 0x000052CC
		internal static event Action OnSingletonReady;

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x06000117 RID: 279 RVA: 0x00007100 File Offset: 0x00005300
		// (remove) Token: 0x06000118 RID: 280 RVA: 0x00007138 File Offset: 0x00005338
		public event Action OnServerStarted;

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x06000119 RID: 281 RVA: 0x00007170 File Offset: 0x00005370
		// (remove) Token: 0x0600011A RID: 282 RVA: 0x000071A8 File Offset: 0x000053A8
		public event Action OnClientStarted;

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x0600011B RID: 283 RVA: 0x000071E0 File Offset: 0x000053E0
		// (remove) Token: 0x0600011C RID: 284 RVA: 0x00007218 File Offset: 0x00005418
		public event Action<bool> OnServerStopped;

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x0600011D RID: 285 RVA: 0x00007250 File Offset: 0x00005450
		// (remove) Token: 0x0600011E RID: 286 RVA: 0x00007288 File Offset: 0x00005488
		public event Action<bool> OnClientStopped;

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600011F RID: 287 RVA: 0x000072BD File Offset: 0x000054BD
		public NetworkPrefabHandler PrefabHandler
		{
			get
			{
				if (this.m_PrefabHandler == null)
				{
					this.m_PrefabHandler = new NetworkPrefabHandler();
					this.m_PrefabHandler.Initialize(this);
				}
				return this.m_PrefabHandler;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000120 RID: 288 RVA: 0x000072E4 File Offset: 0x000054E4
		// (set) Token: 0x06000121 RID: 289 RVA: 0x000072EC File Offset: 0x000054EC
		public NetworkSpawnManager SpawnManager { get; private set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000122 RID: 290 RVA: 0x000072F5 File Offset: 0x000054F5
		// (set) Token: 0x06000123 RID: 291 RVA: 0x000072FD File Offset: 0x000054FD
		internal IDeferredNetworkMessageManager DeferredMessageManager { get; private set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000124 RID: 292 RVA: 0x00007306 File Offset: 0x00005506
		// (set) Token: 0x06000125 RID: 293 RVA: 0x0000730E File Offset: 0x0000550E
		public CustomMessagingManager CustomMessagingManager { get; private set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000126 RID: 294 RVA: 0x00007317 File Offset: 0x00005517
		// (set) Token: 0x06000127 RID: 295 RVA: 0x0000731F File Offset: 0x0000551F
		public NetworkSceneManager SceneManager { get; private set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000128 RID: 296 RVA: 0x00007328 File Offset: 0x00005528
		// (set) Token: 0x06000129 RID: 297 RVA: 0x00007330 File Offset: 0x00005530
		internal NetworkBehaviourUpdater BehaviourUpdater { get; set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600012A RID: 298 RVA: 0x00007339 File Offset: 0x00005539
		// (set) Token: 0x0600012B RID: 299 RVA: 0x00007341 File Offset: 0x00005541
		public NetworkTimeSystem NetworkTimeSystem { get; private set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600012C RID: 300 RVA: 0x0000734A File Offset: 0x0000554A
		// (set) Token: 0x0600012D RID: 301 RVA: 0x00007352 File Offset: 0x00005552
		public NetworkTickSystem NetworkTickSystem { get; private set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600012E RID: 302 RVA: 0x0000735B File Offset: 0x0000555B
		// (set) Token: 0x0600012F RID: 303 RVA: 0x00007363 File Offset: 0x00005563
		internal AnticipationSystem AnticipationSystem { get; private set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000130 RID: 304 RVA: 0x0000736C File Offset: 0x0000556C
		// (set) Token: 0x06000131 RID: 305 RVA: 0x00007374 File Offset: 0x00005574
		internal IRealTimeProvider RealTimeProvider { get; private set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000132 RID: 306 RVA: 0x0000737D File Offset: 0x0000557D
		internal INetworkMetrics NetworkMetrics
		{
			get
			{
				return this.MetricsManager.NetworkMetrics;
			}
		}

		// Token: 0x06000133 RID: 307 RVA: 0x0000738A File Offset: 0x0000558A
		internal bool NetworkManagerCheckForParent(bool ignoreNetworkManagerCache = false)
		{
			bool flag = base.transform.root != base.transform;
			if (flag)
			{
				throw new Exception(NetworkManager.GenerateNestedNetworkManagerMessage(base.transform));
			}
			return flag;
		}

		// Token: 0x06000134 RID: 308 RVA: 0x000073B6 File Offset: 0x000055B6
		internal static string GenerateNestedNetworkManagerMessage(Transform transform)
		{
			return transform.name + " is nested under " + transform.root.name + ". NetworkManager cannot be nested.\n";
		}

		// Token: 0x06000135 RID: 309 RVA: 0x000073D8 File Offset: 0x000055D8
		private void OnTransformParentChanged()
		{
			this.NetworkManagerCheckForParent(false);
		}

		// Token: 0x06000136 RID: 310 RVA: 0x000073E2 File Offset: 0x000055E2
		public void SetSingleton()
		{
			NetworkManager.Singleton = this;
			Action onSingletonReady = NetworkManager.OnSingletonReady;
			if (onSingletonReady == null)
			{
				return;
			}
			onSingletonReady();
		}

		// Token: 0x06000137 RID: 311 RVA: 0x000073F9 File Offset: 0x000055F9
		private void Awake()
		{
			NetworkConfig networkConfig = this.NetworkConfig;
			if (networkConfig != null)
			{
				networkConfig.InitializePrefabs();
			}
			UnityEngine.SceneManagement.SceneManager.sceneUnloaded += this.OnSceneUnloaded;
			Action<NetworkManager> onInstantiated = NetworkManager.OnInstantiated;
			if (onInstantiated == null)
			{
				return;
			}
			onInstantiated(this);
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0000742D File Offset: 0x0000562D
		private void OnEnable()
		{
			if (this.RunInBackground)
			{
				Application.runInBackground = true;
			}
			if (NetworkManager.Singleton == null)
			{
				this.SetSingleton();
			}
			this.NetworkManagerCheckForParent(false);
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00007458 File Offset: 0x00005658
		public GameObject GetNetworkPrefabOverride(GameObject gameObject)
		{
			return this.PrefabHandler.GetNetworkPrefabOverride(gameObject);
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00007466 File Offset: 0x00005666
		public void AddNetworkPrefab(GameObject prefab)
		{
			this.PrefabHandler.AddNetworkPrefab(prefab);
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00007474 File Offset: 0x00005674
		public void RemoveNetworkPrefab(GameObject prefab)
		{
			this.PrefabHandler.RemoveNetworkPrefab(prefab);
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x0600013D RID: 317 RVA: 0x00007493 File Offset: 0x00005693
		// (set) Token: 0x0600013C RID: 316 RVA: 0x00007482 File Offset: 0x00005682
		public int MaximumTransmissionUnitSize
		{
			get
			{
				return this.MessageManager.NonFragmentedMessageMaxSize;
			}
			set
			{
				this.MessageManager.NonFragmentedMessageMaxSize = (value & -8);
			}
		}

		// Token: 0x0600013E RID: 318 RVA: 0x000074A0 File Offset: 0x000056A0
		public void SetPeerMTU(ulong clientId, int size)
		{
			this.MessageManager.PeerMTUSizes[clientId] = size;
		}

		// Token: 0x0600013F RID: 319 RVA: 0x000074B4 File Offset: 0x000056B4
		public int GetPeerMTU(ulong clientId)
		{
			int result;
			if (this.MessageManager.PeerMTUSizes.TryGetValue(clientId, out result))
			{
				return result;
			}
			return this.MessageManager.NonFragmentedMessageMaxSize;
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000141 RID: 321 RVA: 0x000074F1 File Offset: 0x000056F1
		// (set) Token: 0x06000140 RID: 320 RVA: 0x000074E3 File Offset: 0x000056E3
		public int MaximumFragmentedMessageSize
		{
			get
			{
				return this.MessageManager.FragmentedMessageMaxSize;
			}
			set
			{
				this.MessageManager.FragmentedMessageMaxSize = value;
			}
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00007500 File Offset: 0x00005700
		internal void Initialize(bool server)
		{
			if (server)
			{
				this.ServerShutdownState = NetworkManager.ServerShutdownStates.None;
			}
			if (this.NetworkManagerCheckForParent(true))
			{
				return;
			}
			this.ParseCommandLineOptions();
			if (this.NetworkConfig.NetworkTransport == null)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
				{
					NetworkLog.LogError("No transport has been selected!");
				}
				return;
			}
			if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
			{
				NetworkLog.LogInfo("Initialize");
			}
			this.RegisterNetworkUpdate(NetworkUpdateStage.EarlyUpdate);
			this.RegisterNetworkUpdate(NetworkUpdateStage.PreUpdate);
			this.RegisterNetworkUpdate(NetworkUpdateStage.PostScriptLateUpdate);
			this.RegisterNetworkUpdate(NetworkUpdateStage.PostLateUpdate);
			ComponentFactory.SetDefaults();
			this.RealTimeProvider = ComponentFactory.Create<IRealTimeProvider>(this);
			this.MetricsManager.Initialize(this);
			this.MessageManager = new NetworkMessageManager(new DefaultMessageSender(this), this, null);
			this.MessageManager.Hook(new NetworkManagerHooks(this));
			this.MessageManager.Hook(new MetricHooks(this));
			this.MessageManager.ClientConnected(0UL);
			this.ConnectionManager.Initialize(this);
			this.NetworkTimeSystem = (server ? NetworkTimeSystem.ServerTimeSystem() : new NetworkTimeSystem(1.0 / this.NetworkConfig.TickRate, 0.05000000074505806, 0.2, 0.01));
			this.NetworkTickSystem = this.NetworkTimeSystem.Initialize(this);
			this.AnticipationSystem = new AnticipationSystem(this);
			this.SpawnManager = new NetworkSpawnManager(this);
			this.DeferredMessageManager = ComponentFactory.Create<IDeferredNetworkMessageManager>(this);
			this.RpcTarget = new RpcTarget(this);
			this.CustomMessagingManager = new CustomMessagingManager(this);
			this.SceneManager = new NetworkSceneManager(this);
			this.BehaviourUpdater = new NetworkBehaviourUpdater();
			this.BehaviourUpdater.Initialize(this);
			this.NetworkConfig.InitializePrefabs();
			this.PrefabHandler.RegisterPlayerPrefab();
		}

		// Token: 0x06000143 RID: 323 RVA: 0x000076B4 File Offset: 0x000058B4
		private bool CanStart(NetworkManager.StartType type)
		{
			if (this.IsListening)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("Cannot start " + type.ToString() + " while an instance is already running");
				}
				return false;
			}
			if (this.NetworkConfig.ConnectionApproval && type != NetworkManager.StartType.Client && this.ConnectionApprovalCallback == null && NetworkLog.CurrentLogLevel <= LogLevel.Normal)
			{
				NetworkLog.LogWarning("No ConnectionApproval callback defined. Connection approval will timeout");
			}
			if (this.ConnectionApprovalCallback != null && !this.NetworkConfig.ConnectionApproval && NetworkLog.CurrentLogLevel <= LogLevel.Normal)
			{
				NetworkLog.LogWarning("A ConnectionApproval callback is defined but ConnectionApproval is disabled. In order to use ConnectionApproval it has to be explicitly enabled ");
			}
			return true;
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00007748 File Offset: 0x00005948
		public bool StartServer()
		{
			if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
			{
				NetworkLog.LogInfo("StartServer");
			}
			if (!this.CanStart(NetworkManager.StartType.Server))
			{
				return false;
			}
			this.ConnectionManager.LocalClient.SetRole(true, false, this);
			this.ConnectionManager.LocalClient.ClientId = 0UL;
			this.Initialize(true);
			try
			{
				this.IsListening = this.NetworkConfig.NetworkTransport.StartServer();
				if (this.IsListening)
				{
					this.SpawnManager.ServerSpawnSceneObjectsOnStartSweep();
					Action onServerStarted = this.OnServerStarted;
					if (onServerStarted != null)
					{
						onServerStarted();
					}
					this.ConnectionManager.LocalClient.IsApproved = true;
					return true;
				}
				this.ConnectionManager.TransportFailureEventHandler(true);
			}
			catch (Exception)
			{
				this.ConnectionManager.LocalClient.SetRole(false, false, null);
				this.IsListening = false;
				throw;
			}
			return this.IsListening;
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00007830 File Offset: 0x00005A30
		public bool StartClient()
		{
			if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
			{
				NetworkLog.LogInfo("StartClient");
			}
			if (!this.CanStart(NetworkManager.StartType.Client))
			{
				return false;
			}
			this.ConnectionManager.LocalClient.SetRole(false, true, this);
			this.Initialize(false);
			try
			{
				this.IsListening = this.NetworkConfig.NetworkTransport.StartClient();
				if (!this.IsListening)
				{
					this.ConnectionManager.TransportFailureEventHandler(true);
				}
				else
				{
					Action onClientStarted = this.OnClientStarted;
					if (onClientStarted != null)
					{
						onClientStarted();
					}
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				this.ConnectionManager.LocalClient.SetRole(false, false, null);
				this.IsListening = false;
			}
			return this.IsListening;
		}

		// Token: 0x06000146 RID: 326 RVA: 0x000078EC File Offset: 0x00005AEC
		public bool StartHost()
		{
			if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
			{
				NetworkLog.LogInfo("StartHost");
			}
			if (!this.CanStart(NetworkManager.StartType.Host))
			{
				return false;
			}
			this.ConnectionManager.LocalClient.SetRole(true, true, this);
			this.Initialize(true);
			try
			{
				this.IsListening = this.NetworkConfig.NetworkTransport.StartServer();
				if (!this.IsListening)
				{
					this.ConnectionManager.TransportFailureEventHandler(true);
				}
				else
				{
					this.HostServerInitialize();
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				this.ConnectionManager.LocalClient.SetRole(false, false, null);
				this.IsListening = false;
			}
			return this.IsListening;
		}

		// Token: 0x06000147 RID: 327 RVA: 0x0000799C File Offset: 0x00005B9C
		private void HostServerInitialize()
		{
			this.LocalClientId = 0UL;
			this.NetworkMetrics.SetConnectionId(this.LocalClientId);
			this.MessageManager.SetLocalClientId(this.LocalClientId);
			if (this.NetworkConfig.ConnectionApproval && this.ConnectionApprovalCallback != null)
			{
				NetworkManager.ConnectionApprovalResponse connectionApprovalResponse = new NetworkManager.ConnectionApprovalResponse();
				this.ConnectionApprovalCallback(new NetworkManager.ConnectionApprovalRequest
				{
					Payload = this.NetworkConfig.ConnectionData,
					ClientNetworkId = 0UL
				}, connectionApprovalResponse);
				if (!connectionApprovalResponse.Approved && NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("You cannot decline the host connection. The connection was automatically approved.");
				}
				connectionApprovalResponse.Approved = true;
				this.ConnectionManager.HandleConnectionApproval(0UL, connectionApprovalResponse);
			}
			else
			{
				NetworkManager.ConnectionApprovalResponse response = new NetworkManager.ConnectionApprovalResponse
				{
					Approved = true,
					CreatePlayerObject = (this.NetworkConfig.PlayerPrefab != null)
				};
				this.ConnectionManager.HandleConnectionApproval(0UL, response);
			}
			this.SpawnManager.ServerSpawnSceneObjectsOnStartSweep();
			Action onServerStarted = this.OnServerStarted;
			if (onServerStarted != null)
			{
				onServerStarted();
			}
			Action onClientStarted = this.OnClientStarted;
			if (onClientStarted != null)
			{
				onClientStarted();
			}
			this.ConnectionManager.InvokeOnClientConnectedCallback(this.LocalClientId);
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00007ABF File Offset: 0x00005CBF
		public void DisconnectClient(ulong clientId)
		{
			this.ConnectionManager.DisconnectClient(clientId, null);
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00007ACE File Offset: 0x00005CCE
		public void DisconnectClient(ulong clientId, string reason = null)
		{
			this.ConnectionManager.DisconnectClient(clientId, reason);
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00007ADD File Offset: 0x00005CDD
		public void Shutdown(bool discardMessageQueue = false)
		{
			if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
			{
				NetworkLog.LogInfo("Shutdown");
			}
			if (this.IsServer || this.IsClient)
			{
				this.m_ShuttingDown = true;
				if (this.MessageManager != null)
				{
					this.MessageManager.StopProcessing = discardMessageQueue;
				}
			}
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00007B1C File Offset: 0x00005D1C
		private void OnSceneUnloaded(Scene scene)
		{
			if (base.gameObject != null && scene == base.gameObject.scene)
			{
				this.OnDestroy();
			}
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00007B48 File Offset: 0x00005D48
		internal void ShutdownInternal()
		{
			if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
			{
				NetworkLog.LogInfo("ShutdownInternal");
			}
			this.UnregisterAllNetworkUpdates();
			IDeferredNetworkMessageManager deferredMessageManager = this.DeferredMessageManager;
			if (deferredMessageManager != null)
			{
				deferredMessageManager.CleanupAllTriggers();
			}
			RpcTarget rpcTarget = this.RpcTarget;
			if (rpcTarget != null)
			{
				rpcTarget.Dispose();
			}
			this.RpcTarget = null;
			NetworkBehaviourUpdater behaviourUpdater = this.BehaviourUpdater;
			if (behaviourUpdater != null)
			{
				behaviourUpdater.Shutdown();
			}
			this.BehaviourUpdater = null;
			this.ConnectionManager.Shutdown();
			this.CustomMessagingManager = null;
			if (this.MessageManager != null)
			{
				this.MessageManager.Dispose();
				this.MessageManager = null;
			}
			NetworkSpawnManager spawnManager = this.SpawnManager;
			if (spawnManager != null)
			{
				spawnManager.DespawnAndDestroyNetworkObjects();
			}
			NetworkSpawnManager spawnManager2 = this.SpawnManager;
			if (spawnManager2 != null)
			{
				spawnManager2.ServerResetShudownStateForSceneObjects();
			}
			this.SpawnManager = null;
			NetworkSceneManager sceneManager = this.SceneManager;
			if (sceneManager != null)
			{
				sceneManager.Dispose();
			}
			this.SceneManager = null;
			this.IsListening = false;
			this.m_ShuttingDown = false;
			if (this.IsHost)
			{
				this.ConnectionManager.InvokeOnClientDisconnectCallback(this.LocalClientId);
			}
			if (this.ConnectionManager.LocalClient.IsClient)
			{
				Action<bool> onClientStopped = this.OnClientStopped;
				if (onClientStopped != null)
				{
					onClientStopped(this.ConnectionManager.LocalClient.IsServer);
				}
			}
			if (this.ConnectionManager.LocalClient.IsServer)
			{
				Action<bool> onServerStopped = this.OnServerStopped;
				if (onServerStopped != null)
				{
					onServerStopped(this.ConnectionManager.LocalClient.IsClient);
				}
			}
			this.m_ShuttingDown = false;
			this.ConnectionManager.LocalClient.SetRole(false, false, null);
			NetworkConfig networkConfig = this.NetworkConfig;
			if (networkConfig != null)
			{
				NetworkPrefabs prefabs = networkConfig.Prefabs;
				if (prefabs != null)
				{
					prefabs.Shutdown();
				}
			}
			NetworkConfig networkConfig2 = this.NetworkConfig;
			if (networkConfig2 != null)
			{
				networkConfig2.ClearConfigHash();
			}
			NetworkTimeSystem networkTimeSystem = this.NetworkTimeSystem;
			if (networkTimeSystem != null)
			{
				networkTimeSystem.Shutdown();
			}
			this.NetworkTickSystem = null;
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00007D07 File Offset: 0x00005F07
		private void OnApplicationQuit()
		{
			this.m_ShuttingDown = true;
			this.OnDestroy();
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00007D16 File Offset: 0x00005F16
		private void OnDestroy()
		{
			this.ShutdownInternal();
			UnityEngine.SceneManagement.SceneManager.sceneUnloaded -= this.OnSceneUnloaded;
			Action<NetworkManager> onDestroying = NetworkManager.OnDestroying;
			if (onDestroying != null)
			{
				onDestroying(this);
			}
			if (NetworkManager.Singleton == this)
			{
				NetworkManager.Singleton = null;
			}
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00007D54 File Offset: 0x00005F54
		private string GetArg(string[] commandLineArgs, string arg)
		{
			int num = Array.IndexOf<string>(commandLineArgs, arg);
			if (num >= 0 && num < commandLineArgs.Length - 1)
			{
				return commandLineArgs[num + 1];
			}
			return null;
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00007D7C File Offset: 0x00005F7C
		private void ParseArg<T>(string arg, ref NetworkManager.Override<T> value)
		{
			string arg2 = this.GetArg(Environment.GetCommandLineArgs(), arg);
			if (arg2 != null)
			{
				value.Value = (T)((object)Convert.ChangeType(arg2, typeof(T)));
			}
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00007DB4 File Offset: 0x00005FB4
		private void ParseCommandLineOptions()
		{
			this.ParseArg<ushort>("-port", ref this.PortOverride);
		}

		// Token: 0x0400008E RID: 142
		public static readonly Dictionary<uint, NetworkManager.RpcReceiveHandler> __rpc_func_table = new Dictionary<uint, NetworkManager.RpcReceiveHandler>();

		// Token: 0x0400008F RID: 143
		internal NetworkManager.ServerShutdownStates ServerShutdownState;

		// Token: 0x04000090 RID: 144
		private float m_ShutdownTimeout;

		// Token: 0x04000091 RID: 145
		public const ulong ServerClientId = 0UL;

		// Token: 0x04000092 RID: 146
		public readonly Dictionary<ulong, PendingClient> PendingClients = new Dictionary<ulong, PendingClient>();

		// Token: 0x04000093 RID: 147
		private bool m_ShuttingDown;

		// Token: 0x04000094 RID: 148
		[HideInInspector]
		public NetworkConfig NetworkConfig;

		// Token: 0x04000095 RID: 149
		[HideInInspector]
		public bool RunInBackground = true;

		// Token: 0x04000096 RID: 150
		[HideInInspector]
		public LogLevel LogLevel = LogLevel.Normal;

		// Token: 0x0400009D RID: 157
		private NetworkPrefabHandler m_PrefabHandler;

		// Token: 0x040000A0 RID: 160
		public RpcTarget RpcTarget;

		// Token: 0x040000A8 RID: 168
		internal NetworkMetricsManager MetricsManager = new NetworkMetricsManager();

		// Token: 0x040000A9 RID: 169
		internal NetworkConnectionManager ConnectionManager = new NetworkConnectionManager();

		// Token: 0x040000AA RID: 170
		internal NetworkMessageManager MessageManager;

		// Token: 0x040000AB RID: 171
		internal NetworkManager.Override<ushort> PortOverride;

		// Token: 0x040000AC RID: 172
		private const string k_OverridePortArg = "-port";

		// Token: 0x02000021 RID: 33
		// (Invoke) Token: 0x06000155 RID: 341
		public delegate void RpcReceiveHandler(NetworkBehaviour behaviour, FastBufferReader reader, __RpcParams parameters);

		// Token: 0x02000022 RID: 34
		internal enum ServerShutdownStates
		{
			// Token: 0x040000AE RID: 174
			None,
			// Token: 0x040000AF RID: 175
			WaitForClientDisconnects,
			// Token: 0x040000B0 RID: 176
			InternalShutdown,
			// Token: 0x040000B1 RID: 177
			ShuttingDown
		}

		// Token: 0x02000023 RID: 35
		// (Invoke) Token: 0x06000159 RID: 345
		public delegate void ReanticipateDelegate(double lastRoundTripTime);

		// Token: 0x02000024 RID: 36
		public class ConnectionApprovalResponse
		{
			// Token: 0x040000B2 RID: 178
			public bool Approved;

			// Token: 0x040000B3 RID: 179
			public bool CreatePlayerObject;

			// Token: 0x040000B4 RID: 180
			public uint? PlayerPrefabHash;

			// Token: 0x040000B5 RID: 181
			public Vector3? Position;

			// Token: 0x040000B6 RID: 182
			public Quaternion? Rotation;

			// Token: 0x040000B7 RID: 183
			public bool Pending;

			// Token: 0x040000B8 RID: 184
			public string Reason;
		}

		// Token: 0x02000025 RID: 37
		public struct ConnectionApprovalRequest
		{
			// Token: 0x040000B9 RID: 185
			public byte[] Payload;

			// Token: 0x040000BA RID: 186
			public ulong ClientNetworkId;
		}

		// Token: 0x02000026 RID: 38
		internal struct Override<T>
		{
			// Token: 0x17000044 RID: 68
			// (get) Token: 0x0600015D RID: 349 RVA: 0x00007E0A File Offset: 0x0000600A
			// (set) Token: 0x0600015E RID: 350 RVA: 0x00007E12 File Offset: 0x00006012
			public bool Overidden { readonly get; private set; }

			// Token: 0x17000045 RID: 69
			// (get) Token: 0x0600015F RID: 351 RVA: 0x00007E1C File Offset: 0x0000601C
			// (set) Token: 0x06000160 RID: 352 RVA: 0x00007E41 File Offset: 0x00006041
			internal T Value
			{
				get
				{
					if (!this.Overidden)
					{
						return default(T);
					}
					return this.m_Value;
				}
				set
				{
					this.Overidden = true;
					this.m_Value = value;
				}
			}

			// Token: 0x040000BB RID: 187
			private T m_Value;
		}

		// Token: 0x02000027 RID: 39
		private enum StartType
		{
			// Token: 0x040000BE RID: 190
			Server,
			// Token: 0x040000BF RID: 191
			Host,
			// Token: 0x040000C0 RID: 192
			Client
		}
	}
}
