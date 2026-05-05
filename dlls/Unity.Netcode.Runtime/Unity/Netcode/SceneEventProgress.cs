using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity.Netcode
{
	// Token: 0x020000F3 RID: 243
	internal class SceneEventProgress
	{
		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060005FC RID: 1532 RVA: 0x0001B6E7 File Offset: 0x000198E7
		internal Dictionary<ulong, bool> ClientsProcessingSceneEvent { get; } = new Dictionary<ulong, bool>();

		// Token: 0x060005FD RID: 1533 RVA: 0x0001B6EF File Offset: 0x000198EF
		internal bool HasTimedOut()
		{
			return this.WhenSceneEventHasTimedOut <= this.m_NetworkManager.RealTimeProvider.RealTimeSinceStartup;
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060005FE RID: 1534 RVA: 0x0001B70C File Offset: 0x0001990C
		// (set) Token: 0x060005FF RID: 1535 RVA: 0x0001B714 File Offset: 0x00019914
		internal uint SceneHash { get; set; }

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000600 RID: 1536 RVA: 0x0001B71D File Offset: 0x0001991D
		internal Guid Guid { get; } = Guid.NewGuid();

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000601 RID: 1537 RVA: 0x0001B725 File Offset: 0x00019925
		private NetworkManager m_NetworkManager { get; }

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000602 RID: 1538 RVA: 0x0001B72D File Offset: 0x0001992D
		// (set) Token: 0x06000603 RID: 1539 RVA: 0x0001B735 File Offset: 0x00019935
		internal SceneEventProgressStatus Status { get; set; }

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000604 RID: 1540 RVA: 0x0001B73E File Offset: 0x0001993E
		// (set) Token: 0x06000605 RID: 1541 RVA: 0x0001B746 File Offset: 0x00019946
		internal SceneEventType SceneEventType { get; set; }

		// Token: 0x06000606 RID: 1542 RVA: 0x0001B750 File Offset: 0x00019950
		internal List<ulong> GetClientsWithStatus(bool completedSceneEvent)
		{
			List<ulong> list = new List<ulong>();
			if (completedSceneEvent)
			{
				if (this.m_NetworkManager.IsHost && this.m_AsyncOperation.isDone)
				{
					list.Add(this.m_NetworkManager.LocalClientId);
				}
				using (Dictionary<ulong, bool>.Enumerator enumerator = this.ClientsProcessingSceneEvent.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<ulong, bool> keyValuePair = enumerator.Current;
						if (keyValuePair.Value == completedSceneEvent)
						{
							list.Add(keyValuePair.Key);
						}
					}
					return list;
				}
			}
			if (this.m_NetworkManager.IsHost && !this.m_AsyncOperation.isDone)
			{
				list.Add(this.m_NetworkManager.LocalClientId);
			}
			list.AddRange(this.ClientsThatDisconnected);
			return list;
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x0001B820 File Offset: 0x00019A20
		internal SceneEventProgress(NetworkManager networkManager, SceneEventProgressStatus status = SceneEventProgressStatus.Started)
		{
			if (status == SceneEventProgressStatus.Started)
			{
				this.m_NetworkManager = networkManager;
				if (networkManager.IsServer)
				{
					this.m_NetworkManager.OnClientDisconnectCallback += this.OnClientDisconnectCallback;
					foreach (ulong num in networkManager.ConnectedClientsIds)
					{
						if (num != 0UL)
						{
							this.ClientsProcessingSceneEvent.Add(num, false);
						}
					}
					this.WhenSceneEventHasTimedOut = networkManager.RealTimeProvider.RealTimeSinceStartup + (float)networkManager.NetworkConfig.LoadSceneTimeOut;
					this.m_TimeOutCoroutine = this.m_NetworkManager.StartCoroutine(this.TimeOutSceneEventProgress());
				}
			}
			this.Status = status;
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x0001B90C File Offset: 0x00019B0C
		private void OnClientDisconnectCallback(ulong clientId)
		{
			if (this.ClientsProcessingSceneEvent.ContainsKey(clientId))
			{
				this.ClientsThatDisconnected.Add(clientId);
				this.ClientsProcessingSceneEvent.Remove(clientId);
			}
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x0001B935 File Offset: 0x00019B35
		internal IEnumerator TimeOutSceneEventProgress()
		{
			WaitForSeconds waitForNetworkTick = new WaitForSeconds(1f / this.m_NetworkManager.NetworkConfig.TickRate);
			while (!this.HasTimedOut())
			{
				yield return waitForNetworkTick;
				this.TryFinishingSceneEventProgress();
			}
			yield break;
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x0001B944 File Offset: 0x00019B44
		internal void ClientFinishedSceneEvent(ulong clientId)
		{
			if (this.ClientsProcessingSceneEvent.ContainsKey(clientId))
			{
				this.ClientsProcessingSceneEvent[clientId] = true;
				this.TryFinishingSceneEventProgress();
			}
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x0001B968 File Offset: 0x00019B68
		private bool HasFinished()
		{
			if (!this.IsNetworkSessionActive())
			{
				return true;
			}
			foreach (KeyValuePair<ulong, bool> keyValuePair in this.ClientsProcessingSceneEvent)
			{
				if (!keyValuePair.Value)
				{
					return false;
				}
			}
			return this.m_AsyncOperation != null && this.m_AsyncOperation.isDone;
		}

		// Token: 0x0600060C RID: 1548 RVA: 0x0001B9E4 File Offset: 0x00019BE4
		internal void SetAsyncOperation(AsyncOperation asyncOperation)
		{
			this.m_AsyncOperation = asyncOperation;
			this.m_AsyncOperation.completed += delegate(AsyncOperation asyncOp2)
			{
				if (this.IsNetworkSessionActive())
				{
					Action<uint> onSceneEventCompleted = this.OnSceneEventCompleted;
					if (onSceneEventCompleted != null)
					{
						onSceneEventCompleted(this.SceneEventId);
					}
				}
				this.TryFinishingSceneEventProgress();
			};
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x0001BA04 File Offset: 0x00019C04
		internal bool IsNetworkSessionActive()
		{
			return this.m_NetworkManager != null && this.m_NetworkManager.IsListening && !this.m_NetworkManager.ShutdownInProgress;
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x0001BA34 File Offset: 0x00019C34
		internal void TryFinishingSceneEventProgress()
		{
			if (this.HasFinished() || this.HasTimedOut())
			{
				if (this.IsNetworkSessionActive())
				{
					SceneEventProgress.OnCompletedDelegate onComplete = this.OnComplete;
					if (onComplete != null)
					{
						onComplete(this);
					}
					this.m_NetworkManager.SceneManager.SceneEventProgressTracking.Remove(this.Guid);
					this.m_NetworkManager.OnClientDisconnectCallback -= this.OnClientDisconnectCallback;
				}
				if (this.m_TimeOutCoroutine != null)
				{
					this.m_NetworkManager.StopCoroutine(this.m_TimeOutCoroutine);
				}
			}
		}

		// Token: 0x040002E8 RID: 744
		internal List<ulong> ClientsThatDisconnected = new List<ulong>();

		// Token: 0x040002E9 RID: 745
		internal float WhenSceneEventHasTimedOut;

		// Token: 0x040002EA RID: 746
		internal SceneEventProgress.OnCompletedDelegate OnComplete;

		// Token: 0x040002EB RID: 747
		internal Action<uint> OnSceneEventCompleted;

		// Token: 0x040002EE RID: 750
		internal uint SceneEventId;

		// Token: 0x040002EF RID: 751
		private Coroutine m_TimeOutCoroutine;

		// Token: 0x040002F0 RID: 752
		private AsyncOperation m_AsyncOperation;

		// Token: 0x040002F4 RID: 756
		internal LoadSceneMode LoadSceneMode;

		// Token: 0x020000F4 RID: 244
		// (Invoke) Token: 0x06000611 RID: 1553
		internal delegate bool OnCompletedDelegate(SceneEventProgress sceneEventProgress);
	}
}
