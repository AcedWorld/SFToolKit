using System;
using System.Collections;
using Rewired;
using ScooterFlow.Tutorial;
using UnityEngine;

// Token: 0x02000211 RID: 529
public class TestTut : MonoBehaviour
{
	// Token: 0x06000854 RID: 2132 RVA: 0x0003B2B7 File Offset: 0x000394B7
	private void Start()
	{
		this.player = ReInput.players.GetPlayer(this.playerId);
		this.StartMovement();
	}

	// Token: 0x06000855 RID: 2133 RVA: 0x0003B2D8 File Offset: 0x000394D8
	private void Update()
	{
		if (this.Stage == TutorialStage.PushAndTurn)
		{
			if (this.player.GetButton("Cross") && !this.playerHasPushed)
			{
				Debug.Log("Player Has Pushed.");
				this.playerHasPushed = true;
			}
			if (this.playerHasPushed && this.movementTarget.targetReached)
			{
				this.CompletedMovement();
			}
		}
	}

	// Token: 0x06000856 RID: 2134 RVA: 0x0003B334 File Offset: 0x00039534
	public void OpenPanel(string title, string description)
	{
		this.panel.OpenPanel(title, description);
	}

	// Token: 0x06000857 RID: 2135 RVA: 0x0003B343 File Offset: 0x00039543
	public void StartMovement()
	{
		this.Stage = TutorialStage.PushAndTurn;
		this.OpenPanel("Movement", "Press button to push and move joystick to steer");
	}

	// Token: 0x06000858 RID: 2136 RVA: 0x0003B35C File Offset: 0x0003955C
	public void FailedMovement()
	{
		this.OpenPanel("Movement", "Failed to reach the target.");
	}

	// Token: 0x06000859 RID: 2137 RVA: 0x0003B36E File Offset: 0x0003956E
	public void CompletedMovement()
	{
		this.OpenPanel("Movement", "Movement Complete.");
		base.StartCoroutine(this.DelayBeforeStartStage(TutorialStage.Hop));
	}

	// Token: 0x0600085A RID: 2138 RVA: 0x0003B38E File Offset: 0x0003958E
	private void ResetBools()
	{
		this.playerHasPushed = false;
	}

	// Token: 0x0600085B RID: 2139 RVA: 0x0003B397 File Offset: 0x00039597
	private IEnumerator DelayBeforeStartStage(TutorialStage stage)
	{
		yield return new WaitForSeconds(3f);
		this.StartNextStage(stage);
		yield break;
	}

	// Token: 0x0600085C RID: 2140 RVA: 0x0003B3AD File Offset: 0x000395AD
	public void StartNextStage(TutorialStage stage)
	{
		this.teleportPlayer.TeleportToSpawnpoint();
		this.Stage = stage;
		this.OpenPanel("Hop", "Perform a hop.");
		this.ResetBools();
	}

	// Token: 0x04000E97 RID: 3735
	public TutorialStage Stage;

	// Token: 0x04000E98 RID: 3736
	public TutorialPanel panel;

	// Token: 0x04000E99 RID: 3737
	private int playerId;

	// Token: 0x04000E9A RID: 3738
	private Player player;

	// Token: 0x04000E9B RID: 3739
	public bool playerHasPushed;

	// Token: 0x04000E9C RID: 3740
	public TutTarget movementTarget;

	// Token: 0x04000E9D RID: 3741
	public TeleportPlayer teleportPlayer;
}
