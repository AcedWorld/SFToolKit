using System;
using Rewired;
using UnityEngine;
using UnityEngine.Events;

namespace ScooterFlow.Tutorial
{
	// Token: 0x0200025A RID: 602
	public class Air : MonoBehaviour
	{
		// Token: 0x06000980 RID: 2432 RVA: 0x00042C33 File Offset: 0x00040E33
		private void Start()
		{
			this.player = ReInput.players.GetPlayer(this.playerId);
		}

		// Token: 0x06000981 RID: 2433 RVA: 0x00042C4B File Offset: 0x00040E4B
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

		// Token: 0x06000982 RID: 2434 RVA: 0x00042C8C File Offset: 0x00040E8C
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

		// Token: 0x06000983 RID: 2435 RVA: 0x00042CF2 File Offset: 0x00040EF2
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

		// Token: 0x06000984 RID: 2436 RVA: 0x00042D29 File Offset: 0x00040F29
		private void ResetTrigger()
		{
			this.colliderCount = 0;
			this.tutorialLogic.ClosePanel();
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x00042D3D File Offset: 0x00040F3D
		public void StartStage()
		{
			this.ResetTrigger();
			this.OnStartStage.Invoke();
		}

		// Token: 0x06000986 RID: 2438 RVA: 0x00042D50 File Offset: 0x00040F50
		public void FailStage()
		{
			this.OnFailStage.Invoke();
		}

		// Token: 0x06000987 RID: 2439 RVA: 0x00042D5D File Offset: 0x00040F5D
		public void CompleteStage()
		{
			this.OnCompleteStage.Invoke();
		}

		// Token: 0x04000FFA RID: 4090
		private int playerId;

		// Token: 0x04000FFB RID: 4091
		private Player player;

		// Token: 0x04000FFC RID: 4092
		private int colliderCount;

		// Token: 0x04000FFD RID: 4093
		private bool startTrigger;

		// Token: 0x04000FFE RID: 4094
		public TutorialLogic tutorialLogic;

		// Token: 0x04000FFF RID: 4095
		public TutorialStage tutorialStage;

		// Token: 0x04001000 RID: 4096
		[TextArea(3, 10)]
		public string description;

		// Token: 0x04001001 RID: 4097
		public UnityEvent OnStartStage;

		// Token: 0x04001002 RID: 4098
		public UnityEvent OnFailStage;

		// Token: 0x04001003 RID: 4099
		public UnityEvent OnCompleteStage;
	}
}
