using System;
using Rewired;
using UnityEngine;

// Token: 0x020001BC RID: 444
public class ScooterFlowAction : MonoBehaviour
{
	// Token: 0x060006E6 RID: 1766 RVA: 0x00033BE7 File Offset: 0x00031DE7
	private void Start()
	{
		this.player = ReInput.players.GetPlayer(this.playerId);
	}

	// Token: 0x060006E7 RID: 1767 RVA: 0x00033BFF File Offset: 0x00031DFF
	private void OnTriggerEnter(Collider other)
	{
		this.isActive = true;
	}

	// Token: 0x060006E8 RID: 1768 RVA: 0x00033C08 File Offset: 0x00031E08
	private void OnTriggerExit(Collider other)
	{
		this.isActive = false;
	}

	// Token: 0x060006E9 RID: 1769 RVA: 0x00033C11 File Offset: 0x00031E11
	private void Update()
	{
		if (this.isActive && this.player.GetButtonDown("Triangle"))
		{
			this.trigger = !this.trigger;
			this.DoAction();
		}
	}

	// Token: 0x060006EA RID: 1770 RVA: 0x00033C44 File Offset: 0x00031E44
	public void DoAction()
	{
		if (this.trigger)
		{
			this._gameObject.SetActive(false);
			Debug.Log("Turned Off");
		}
		if (!this.trigger)
		{
			this._gameObject.SetActive(true);
			Debug.Log("Turned On");
		}
		this.isActive = false;
	}

	// Token: 0x04000C45 RID: 3141
	public GameObject _gameObject;

	// Token: 0x04000C46 RID: 3142
	private int playerId;

	// Token: 0x04000C47 RID: 3143
	private Player player;

	// Token: 0x04000C48 RID: 3144
	public bool isActive;

	// Token: 0x04000C49 RID: 3145
	private bool trigger;
}
