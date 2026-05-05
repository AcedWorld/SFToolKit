using System;
using Rewired;
using UnityEngine;
using UnityEngine.Events;

namespace ScooterFlow.Tutorial
{
	// Token: 0x02000261 RID: 609
	public class NoseManual : MonoBehaviour
	{
		// Token: 0x060009C0 RID: 2496 RVA: 0x000434E2 File Offset: 0x000416E2
		private void Start()
		{
			this.player = ReInput.players.GetPlayer(this.playerId);
		}

		// Token: 0x060009C1 RID: 2497 RVA: 0x000434FA File Offset: 0x000416FA
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

		// Token: 0x060009C2 RID: 2498 RVA: 0x0004353C File Offset: 0x0004173C
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

		// Token: 0x060009C3 RID: 2499 RVA: 0x000435A2 File Offset: 0x000417A2
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

		// Token: 0x060009C4 RID: 2500 RVA: 0x000435D9 File Offset: 0x000417D9
		private void ResetTrigger()
		{
			this.colliderCount = 0;
			this.tutorialLogic.ClosePanel();
		}

		// Token: 0x060009C5 RID: 2501 RVA: 0x000435ED File Offset: 0x000417ED
		public void StartStage()
		{
			this.ResetTrigger();
			this.OnStartStage.Invoke();
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x00043600 File Offset: 0x00041800
		public void FailStage()
		{
			this.OnFailStage.Invoke();
		}

		// Token: 0x060009C7 RID: 2503 RVA: 0x0004360D File Offset: 0x0004180D
		public void CompleteStage()
		{
			this.OnCompleteStage.Invoke();
		}

		// Token: 0x04001044 RID: 4164
		private int playerId;

		// Token: 0x04001045 RID: 4165
		private Player player;

		// Token: 0x04001046 RID: 4166
		private int colliderCount;

		// Token: 0x04001047 RID: 4167
		private bool startTrigger;

		// Token: 0x04001048 RID: 4168
		public TutorialLogic tutorialLogic;

		// Token: 0x04001049 RID: 4169
		public TutorialStage tutorialStage;

		// Token: 0x0400104A RID: 4170
		[TextArea(3, 10)]
		public string description;

		// Token: 0x0400104B RID: 4171
		public UnityEvent OnStartStage;

		// Token: 0x0400104C RID: 4172
		public UnityEvent OnFailStage;

		// Token: 0x0400104D RID: 4173
		public UnityEvent OnCompleteStage;
	}
}
