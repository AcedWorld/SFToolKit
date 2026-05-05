using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000055 RID: 85
public class NetworkReference : MonoBehaviour
{
	// Token: 0x06000151 RID: 337 RVA: 0x0000B238 File Offset: 0x00009438
	private void Start()
	{
		if (this.networkLobbyManager == null)
		{
			this.networkLobbyManager = Object.FindObjectOfType<NetworkLobbyManager>();
			if (this.networkLobbyManager == null)
			{
				return;
			}
			Debug.Log("[AssignWorldBounds] Found WorldBounds: " + this.networkLobbyManager.name);
		}
	}

	// Token: 0x06000152 RID: 338 RVA: 0x0000B288 File Offset: 0x00009488
	public void DisableExitHandler()
	{
		NetworkReference.<DisableExitHandler>d__3 <DisableExitHandler>d__;
		<DisableExitHandler>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
		<DisableExitHandler>d__.<>4__this = this;
		<DisableExitHandler>d__.<>1__state = -1;
		<DisableExitHandler>d__.<>t__builder.Start<NetworkReference.<DisableExitHandler>d__3>(ref <DisableExitHandler>d__);
	}

	// Token: 0x04000188 RID: 392
	[HideInInspector]
	public NetworkLobbyManager networkLobbyManager;

	// Token: 0x04000189 RID: 393
	public GameObject HomeCarrier;
}
