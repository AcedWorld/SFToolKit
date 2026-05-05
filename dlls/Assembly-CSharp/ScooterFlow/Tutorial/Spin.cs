using System;
using Rewired;
using UnityEngine;
using UnityEngine.Events;

namespace ScooterFlow.Tutorial
{
	// Token: 0x02000263 RID: 611
	public class Spin : MonoBehaviour
	{
		// Token: 0x060009D2 RID: 2514 RVA: 0x00043752 File Offset: 0x00041952
		private void Start()
		{
			this.player = ReInput.players.GetPlayer(this.playerId);
		}

		// Token: 0x060009D3 RID: 2515 RVA: 0x0004376A File Offset: 0x0004196A
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

		// Token: 0x060009D4 RID: 2516 RVA: 0x000437AC File Offset: 0x000419AC
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

		// Token: 0x060009D5 RID: 2517 RVA: 0x00043812 File Offset: 0x00041A12
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

		// Token: 0x060009D6 RID: 2518 RVA: 0x00043849 File Offset: 0x00041A49
		private void ResetTrigger()
		{
			this.colliderCount = 0;
			this.tutorialLogic.ClosePanel();
		}

		// Token: 0x060009D7 RID: 2519 RVA: 0x0004385D File Offset: 0x00041A5D
		public void StartStage()
		{
			this.ResetTrigger();
			this.OnStartStage.Invoke();
		}

		// Token: 0x060009D8 RID: 2520 RVA: 0x00043870 File Offset: 0x00041A70
		public void FailStage()
		{
			this.OnFailStage.Invoke();
		}

		// Token: 0x060009D9 RID: 2521 RVA: 0x0004387D File Offset: 0x00041A7D
		public void CompleteStage()
		{
			this.OnCompleteStage.Invoke();
		}

		// Token: 0x04001058 RID: 4184
		private int playerId;

		// Token: 0x04001059 RID: 4185
		private Player player;

		// Token: 0x0400105A RID: 4186
		private int colliderCount;

		// Token: 0x0400105B RID: 4187
		private bool startTrigger;

		// Token: 0x0400105C RID: 4188
		public TutorialLogic tutorialLogic;

		// Token: 0x0400105D RID: 4189
		public TutorialStage tutorialStage;

		// Token: 0x0400105E RID: 4190
		[TextArea(3, 10)]
		public string description;

		// Token: 0x0400105F RID: 4191
		public UnityEvent OnStartStage;

		// Token: 0x04001060 RID: 4192
		public UnityEvent OnFailStage;

		// Token: 0x04001061 RID: 4193
		public UnityEvent OnCompleteStage;
	}
}
