using System;
using Rewired;
using UnityEngine;
using UnityEngine.Events;

namespace ScooterFlow.Tutorial
{
	// Token: 0x0200025D RID: 605
	public class Grind : MonoBehaviour
	{
		// Token: 0x0600099B RID: 2459 RVA: 0x00042FDA File Offset: 0x000411DA
		private void Start()
		{
			this.player = ReInput.players.GetPlayer(this.playerId);
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x00042FF2 File Offset: 0x000411F2
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

		// Token: 0x0600099D RID: 2461 RVA: 0x00043034 File Offset: 0x00041234
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

		// Token: 0x0600099E RID: 2462 RVA: 0x0004309A File Offset: 0x0004129A
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

		// Token: 0x0600099F RID: 2463 RVA: 0x000430D1 File Offset: 0x000412D1
		private void ResetTrigger()
		{
			this.colliderCount = 0;
			this.tutorialLogic.ClosePanel();
		}

		// Token: 0x060009A0 RID: 2464 RVA: 0x000430E5 File Offset: 0x000412E5
		public void StartStage()
		{
			this.ResetTrigger();
			this.OnStartStage.Invoke();
		}

		// Token: 0x060009A1 RID: 2465 RVA: 0x000430F8 File Offset: 0x000412F8
		public void FailStage()
		{
			this.OnFailStage.Invoke();
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x00043105 File Offset: 0x00041305
		public void CompleteStage()
		{
			this.OnCompleteStage.Invoke();
		}

		// Token: 0x04001018 RID: 4120
		private int playerId;

		// Token: 0x04001019 RID: 4121
		private Player player;

		// Token: 0x0400101A RID: 4122
		private int colliderCount;

		// Token: 0x0400101B RID: 4123
		private bool startTrigger;

		// Token: 0x0400101C RID: 4124
		public TutorialLogic tutorialLogic;

		// Token: 0x0400101D RID: 4125
		public TutorialStage tutorialStage;

		// Token: 0x0400101E RID: 4126
		[TextArea(3, 10)]
		public string description;

		// Token: 0x0400101F RID: 4127
		public UnityEvent OnStartStage;

		// Token: 0x04001020 RID: 4128
		public UnityEvent OnFailStage;

		// Token: 0x04001021 RID: 4129
		public UnityEvent OnCompleteStage;
	}
}
