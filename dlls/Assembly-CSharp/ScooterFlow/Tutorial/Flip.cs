using System;
using Rewired;
using UnityEngine;
using UnityEngine.Events;

namespace ScooterFlow.Tutorial
{
	// Token: 0x0200025C RID: 604
	public class Flip : MonoBehaviour
	{
		// Token: 0x06000992 RID: 2450 RVA: 0x00042EA2 File Offset: 0x000410A2
		private void Start()
		{
			this.player = ReInput.players.GetPlayer(this.playerId);
		}

		// Token: 0x06000993 RID: 2451 RVA: 0x00042EBA File Offset: 0x000410BA
		private void Update()
		{
			if (this.startTrigger != this.tutorialLogic.tutorialActive)
			{
				if (this.tutorialLogic.currentStage == this.tutorialStage)
				{
					this.StartStage();
				}
				this.startTrigger = this.tutorialLogic.tutorialActive;
			}
		}

		// Token: 0x06000994 RID: 2452 RVA: 0x00042EFC File Offset: 0x000410FC
		private void OnTriggerEnter(Collider other)
		{
			if (!this.tutorialLogic.tutorialActive)
			{
				this.colliderCount++;
				if (this.colliderCount == 1)
				{
					string title = this.tutorialStage.ToString();
					this.tutorialLogic.OpenPanel(title, this.description);
					this.tutorialLogic.currentStage = this.tutorialStage;
				}
			}
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x00042F62 File Offset: 0x00041162
		private void OnTriggerExit(Collider other)
		{
			if (!this.tutorialLogic.tutorialActive)
			{
				this.colliderCount--;
				if (this.colliderCount == 0)
				{
					this.tutorialLogic.currentStage = TutorialStage.None;
					this.ResetTrigger();
				}
			}
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x00042F99 File Offset: 0x00041199
		private void ResetTrigger()
		{
			this.colliderCount = 0;
			this.tutorialLogic.ClosePanel();
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x00042FAD File Offset: 0x000411AD
		public void StartStage()
		{
			this.ResetTrigger();
			this.OnStartStage.Invoke();
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x00042FC0 File Offset: 0x000411C0
		public void FailStage()
		{
			this.OnFailStage.Invoke();
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x00042FCD File Offset: 0x000411CD
		public void CompleteStage()
		{
			this.OnCompleteStage.Invoke();
		}

		// Token: 0x0400100E RID: 4110
		private int playerId;

		// Token: 0x0400100F RID: 4111
		private Player player;

		// Token: 0x04001010 RID: 4112
		private int colliderCount;

		// Token: 0x04001011 RID: 4113
		private bool startTrigger;

		// Token: 0x04001012 RID: 4114
		public TutorialLogic tutorialLogic;

		// Token: 0x04001013 RID: 4115
		public TutorialStage tutorialStage;

		// Token: 0x04001014 RID: 4116
		[TextArea(3, 10)]
		public string description;

		// Token: 0x04001015 RID: 4117
		public UnityEvent OnStartStage;

		// Token: 0x04001016 RID: 4118
		public UnityEvent OnFailStage;

		// Token: 0x04001017 RID: 4119
		public UnityEvent OnCompleteStage;
	}
}
