using System;
using Rewired;
using UnityEngine;
using UnityEngine.Events;

namespace ScooterFlow.Tutorial
{
	// Token: 0x0200025E RID: 606
	public class Hop : MonoBehaviour
	{
		// Token: 0x060009A4 RID: 2468 RVA: 0x00043112 File Offset: 0x00041312
		private void Start()
		{
			this.player = ReInput.players.GetPlayer(this.playerId);
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x0004312A File Offset: 0x0004132A
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

		// Token: 0x060009A6 RID: 2470 RVA: 0x0004316C File Offset: 0x0004136C
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

		// Token: 0x060009A7 RID: 2471 RVA: 0x000431D2 File Offset: 0x000413D2
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

		// Token: 0x060009A8 RID: 2472 RVA: 0x00043209 File Offset: 0x00041409
		private void ResetTrigger()
		{
			this.colliderCount = 0;
			this.tutorialLogic.ClosePanel();
		}

		// Token: 0x060009A9 RID: 2473 RVA: 0x0004321D File Offset: 0x0004141D
		public void StartStage()
		{
			this.ResetTrigger();
			this.OnStartStage.Invoke();
		}

		// Token: 0x060009AA RID: 2474 RVA: 0x00043230 File Offset: 0x00041430
		public void FailStage()
		{
			this.OnFailStage.Invoke();
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x0004323D File Offset: 0x0004143D
		public void CompleteStage()
		{
			this.OnCompleteStage.Invoke();
		}

		// Token: 0x04001022 RID: 4130
		private int playerId;

		// Token: 0x04001023 RID: 4131
		private Player player;

		// Token: 0x04001024 RID: 4132
		private int colliderCount;

		// Token: 0x04001025 RID: 4133
		private bool startTrigger;

		// Token: 0x04001026 RID: 4134
		public TutorialLogic tutorialLogic;

		// Token: 0x04001027 RID: 4135
		public TutorialStage tutorialStage;

		// Token: 0x04001028 RID: 4136
		[TextArea(3, 10)]
		public string description;

		// Token: 0x04001029 RID: 4137
		public UnityEvent OnStartStage;

		// Token: 0x0400102A RID: 4138
		public UnityEvent OnFailStage;

		// Token: 0x0400102B RID: 4139
		public UnityEvent OnCompleteStage;
	}
}
