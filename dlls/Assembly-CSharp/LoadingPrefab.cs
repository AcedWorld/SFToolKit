using System;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x0200004A RID: 74
public class LoadingPrefab : MonoBehaviour
{
	// Token: 0x0600010C RID: 268 RVA: 0x00009214 File Offset: 0x00007414
	private void Start()
	{
		if (this.networkLobbyManager == null)
		{
			this.networkLobbyManager = Object.FindObjectOfType<NetworkLobbyManager>();
			if (this.networkLobbyManager != null)
			{
				Debug.Log("[LoadingPrefab] Found NetworkLobbyManager in scene.");
			}
			else
			{
				Debug.LogWarning("[LoadingPrefab] No NetworkLobbyManager found in scene.");
			}
		}
		if (this.networkLobbyManager != null)
		{
			this.networkLobbyManager.OnLobbyHosted.AddListener(new UnityAction(this.OnLobbyReady));
			this.networkLobbyManager.OnLobbyJoined.AddListener(new UnityAction(this.OnLobbyReady));
		}
	}

	// Token: 0x0600010D RID: 269 RVA: 0x000092A4 File Offset: 0x000074A4
	private void OnLobbyReady()
	{
		Debug.Log("[LoadingPrefab] Lobby ready — destroying loading prefab.");
		Object.Destroy(base.gameObject);
	}

	// Token: 0x0600010E RID: 270 RVA: 0x000092BC File Offset: 0x000074BC
	private void OnDestroy()
	{
		if (this.networkLobbyManager != null)
		{
			this.networkLobbyManager.OnLobbyHosted.RemoveListener(new UnityAction(this.OnLobbyReady));
			this.networkLobbyManager.OnLobbyJoined.RemoveListener(new UnityAction(this.OnLobbyReady));
		}
	}

	// Token: 0x0400013E RID: 318
	private NetworkLobbyManager networkLobbyManager;
}
