using System;
using Rewired;
using UnityEngine;
using UnityEngine.Events;

namespace ScooterFlow.Tutorial
{
	// Token: 0x0200025F RID: 607
	public class Manual : MonoBehaviour
	{
		// Token: 0x060009AD RID: 2477 RVA: 0x0004324A File Offset: 0x0004144A
		private void Start()
		{
			this.player = ReInput.players.GetPlayer(this.playerId);
		}

		// Token: 0x060009AE RID: 2478 RVA: 0x00043264 File Offset: 0x00041464
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
			if (this.stageActive)
			{
				this.StageLogic();
			}
		}

		// Token: 0x060009AF RID: 2479 RVA: 0x000432BC File Offset: 0x000414BC
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

		// Token: 0x060009B0 RID: 2480 RVA: 0x00043322 File Offset: 0x00041522
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

		// Token: 0x060009B1 RID: 2481 RVA: 0x00043359 File Offset: 0x00041559
		private void ResetTrigger()
		{
			this.colliderCount = 0;
			this.tutorialLogic.ClosePanel();
		}

		// Token: 0x060009B2 RID: 2482 RVA: 0x0004336D File Offset: 0x0004156D
		public void StartStage()
		{
			this.ResetTrigger();
			this.stageActive = true;
			this.OnStartStage.Invoke();
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x00043387 File Offset: 0x00041587
		public void FailStage()
		{
			this.OnFailStage.Invoke();
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x00043394 File Offset: 0x00041594
		public void CompleteStage()
		{
			Debug.Log("Stage completed");
			this.OnCompleteStage.Invoke();
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x000020BE File Offset: 0x000002BE
		private void StageLogic()
		{
		}

		// Token: 0x0400102C RID: 4140
		public bool stageActive;

		// Token: 0x0400102D RID: 4141
		private int playerId;

		// Token: 0x0400102E RID: 4142
		private Player player;

		// Token: 0x0400102F RID: 4143
		private int colliderCount;

		// Token: 0x04001030 RID: 4144
		private bool startTrigger;

		// Token: 0x04001031 RID: 4145
		public TutorialLogic tutorialLogic;

		// Token: 0x04001032 RID: 4146
		public TutorialStage tutorialStage;

		// Token: 0x04001033 RID: 4147
		[TextArea(3, 10)]
		public string description;

		// Token: 0x04001034 RID: 4148
		public bool hasJumped;

		// Token: 0x04001035 RID: 4149
		public bool startedManual;

		// Token: 0x04001036 RID: 4150
		public bool playerLanded;

		// Token: 0x04001037 RID: 4151
		public UnityEvent OnStartStage;

		// Token: 0x04001038 RID: 4152
		public UnityEvent OnFailStage;

		// Token: 0x04001039 RID: 4153
		public UnityEvent OnCompleteStage;
	}
}
