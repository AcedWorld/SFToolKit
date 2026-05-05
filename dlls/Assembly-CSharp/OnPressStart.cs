using System;
using Rewired;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x02000136 RID: 310
public class OnPressStart : MonoBehaviour
{
	// Token: 0x060004F9 RID: 1273 RVA: 0x00022664 File Offset: 0x00020864
	private void Awake()
	{
		this.player = ReInput.players.GetPlayer(this.playerId);
	}

	// Token: 0x060004FA RID: 1274 RVA: 0x0002267C File Offset: 0x0002087C
	private void Update()
	{
		if (this.player.GetAnyButton())
		{
			this.StartPressed();
		}
	}

	// Token: 0x060004FB RID: 1275 RVA: 0x00022691 File Offset: 0x00020891
	private void StartPressed()
	{
		this.OnStartPressed.Invoke();
		base.transform.parent.gameObject.SetActive(false);
	}

	// Token: 0x040007CC RID: 1996
	private int playerId;

	// Token: 0x040007CD RID: 1997
	private Player player;

	// Token: 0x040007CE RID: 1998
	public UnityEvent OnStartPressed;
}
