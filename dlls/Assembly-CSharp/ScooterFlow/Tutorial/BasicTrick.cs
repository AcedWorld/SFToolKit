using System;
using Rewired;
using UnityEngine;
using UnityEngine.Events;

namespace ScooterFlow.Tutorial
{
	// Token: 0x0200025B RID: 603
	public class BasicTrick : MonoBehaviour
	{
		// Token: 0x06000989 RID: 2441 RVA: 0x00042D6A File Offset: 0x00040F6A
		private void Start()
		{
			this.player = ReInput.players.GetPlayer(this.playerId);
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x00042D82 File Offset: 0x00040F82
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

		// Token: 0x0600098B RID: 2443 RVA: 0x00042DC4 File Offset: 0x00040FC4
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

		// Token: 0x0600098C RID: 2444 RVA: 0x00042E2A File Offset: 0x0004102A
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

		// Token: 0x0600098D RID: 2445 RVA: 0x00042E61 File Offset: 0x00041061
		private void ResetTrigger()
		{
			this.colliderCount = 0;
			this.tutorialLogic.ClosePanel();
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x00042E75 File Offset: 0x00041075
		public void StartStage()
		{
			this.ResetTrigger();
			this.OnStartStage.Invoke();
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x00042E88 File Offset: 0x00041088
		public void FailStage()
		{
			this.OnFailStage.Invoke();
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x00042E95 File Offset: 0x00041095
		public void CompleteStage()
		{
			this.OnCompleteStage.Invoke();
		}

		// Token: 0x04001004 RID: 4100
		private int playerId;

		// Token: 0x04001005 RID: 4101
		private Player player;

		// Token: 0x04001006 RID: 4102
		private int colliderCount;

		// Token: 0x04001007 RID: 4103
		private bool startTrigger;

		// Token: 0x04001008 RID: 4104
		public TutorialLogic tutorialLogic;

		// Token: 0x04001009 RID: 4105
		public TutorialStage tutorialStage;

		// Token: 0x0400100A RID: 4106
		[TextArea(3, 10)]
		public string description;

		// Token: 0x0400100B RID: 4107
		public UnityEvent OnStartStage;

		// Token: 0x0400100C RID: 4108
		public UnityEvent OnFailStage;

		// Token: 0x0400100D RID: 4109
		public UnityEvent OnCompleteStage;
	}
}
