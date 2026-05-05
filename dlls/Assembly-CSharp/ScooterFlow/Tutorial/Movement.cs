using System;
using Rewired;
using UnityEngine;
using UnityEngine.Events;

namespace ScooterFlow.Tutorial
{
	// Token: 0x02000260 RID: 608
	public class Movement : MonoBehaviour
	{
		// Token: 0x060009B7 RID: 2487 RVA: 0x000433AB File Offset: 0x000415AB
		private void Start()
		{
			this.player = ReInput.players.GetPlayer(this.playerId);
		}

		// Token: 0x060009B8 RID: 2488 RVA: 0x000433C3 File Offset: 0x000415C3
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

		// Token: 0x060009B9 RID: 2489 RVA: 0x00043404 File Offset: 0x00041604
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

		// Token: 0x060009BA RID: 2490 RVA: 0x0004346A File Offset: 0x0004166A
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

		// Token: 0x060009BB RID: 2491 RVA: 0x000434A1 File Offset: 0x000416A1
		private void ResetTrigger()
		{
			this.colliderCount = 0;
			this.tutorialLogic.ClosePanel();
		}

		// Token: 0x060009BC RID: 2492 RVA: 0x000434B5 File Offset: 0x000416B5
		public void StartStage()
		{
			this.ResetTrigger();
			this.OnStartStage.Invoke();
		}

		// Token: 0x060009BD RID: 2493 RVA: 0x000434C8 File Offset: 0x000416C8
		public void FailStage()
		{
			this.OnFailStage.Invoke();
		}

		// Token: 0x060009BE RID: 2494 RVA: 0x000434D5 File Offset: 0x000416D5
		public void CompleteStage()
		{
			this.OnCompleteStage.Invoke();
		}

		// Token: 0x0400103A RID: 4154
		private int playerId;

		// Token: 0x0400103B RID: 4155
		private Player player;

		// Token: 0x0400103C RID: 4156
		private int colliderCount;

		// Token: 0x0400103D RID: 4157
		private bool startTrigger;

		// Token: 0x0400103E RID: 4158
		public TutorialLogic tutorialLogic;

		// Token: 0x0400103F RID: 4159
		public TutorialStage tutorialStage;

		// Token: 0x04001040 RID: 4160
		[TextArea(3, 10)]
		public string description;

		// Token: 0x04001041 RID: 4161
		public UnityEvent OnStartStage;

		// Token: 0x04001042 RID: 4162
		public UnityEvent OnFailStage;

		// Token: 0x04001043 RID: 4163
		public UnityEvent OnCompleteStage;
	}
}
