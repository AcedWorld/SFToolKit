using System;
using Rewired;
using UnityEngine;
using UnityEngine.Events;

namespace ScooterFlow.Tutorial
{
	// Token: 0x02000262 RID: 610
	public class Pump : MonoBehaviour
	{
		// Token: 0x060009C9 RID: 2505 RVA: 0x0004361A File Offset: 0x0004181A
		private void Start()
		{
			this.player = ReInput.players.GetPlayer(this.playerId);
		}

		// Token: 0x060009CA RID: 2506 RVA: 0x00043632 File Offset: 0x00041832
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

		// Token: 0x060009CB RID: 2507 RVA: 0x00043674 File Offset: 0x00041874
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

		// Token: 0x060009CC RID: 2508 RVA: 0x000436DA File Offset: 0x000418DA
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

		// Token: 0x060009CD RID: 2509 RVA: 0x00043711 File Offset: 0x00041911
		private void ResetTrigger()
		{
			this.colliderCount = 0;
			this.tutorialLogic.ClosePanel();
		}

		// Token: 0x060009CE RID: 2510 RVA: 0x00043725 File Offset: 0x00041925
		public void StartStage()
		{
			this.ResetTrigger();
			this.OnStartStage.Invoke();
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x00043738 File Offset: 0x00041938
		public void FailStage()
		{
			this.OnFailStage.Invoke();
		}

		// Token: 0x060009D0 RID: 2512 RVA: 0x00043745 File Offset: 0x00041945
		public void CompleteStage()
		{
			this.OnCompleteStage.Invoke();
		}

		// Token: 0x0400104E RID: 4174
		private int playerId;

		// Token: 0x0400104F RID: 4175
		private Player player;

		// Token: 0x04001050 RID: 4176
		private int colliderCount;

		// Token: 0x04001051 RID: 4177
		private bool startTrigger;

		// Token: 0x04001052 RID: 4178
		public TutorialLogic tutorialLogic;

		// Token: 0x04001053 RID: 4179
		public TutorialStage tutorialStage;

		// Token: 0x04001054 RID: 4180
		[TextArea(3, 10)]
		public string description;

		// Token: 0x04001055 RID: 4181
		public UnityEvent OnStartStage;

		// Token: 0x04001056 RID: 4182
		public UnityEvent OnFailStage;

		// Token: 0x04001057 RID: 4183
		public UnityEvent OnCompleteStage;
	}
}
