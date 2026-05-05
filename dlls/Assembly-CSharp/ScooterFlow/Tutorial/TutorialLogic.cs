using System;
using UnityEngine;

namespace ScooterFlow.Tutorial
{
	// Token: 0x02000265 RID: 613
	public class TutorialLogic : MonoBehaviour
	{
		// Token: 0x060009DB RID: 2523 RVA: 0x0004388A File Offset: 0x00041A8A
		public void OpenPanel(string title, string description)
		{
			if (!this.tutorialActive)
			{
				this.panel.OpenPanel(title, description);
			}
		}

		// Token: 0x060009DC RID: 2524 RVA: 0x000438A1 File Offset: 0x00041AA1
		public void ClosePanel()
		{
			this.panel.ClosePanel();
		}

		// Token: 0x060009DD RID: 2525 RVA: 0x000438AE File Offset: 0x00041AAE
		public void StartTutorialStage()
		{
			Debug.Log("Starting Tutorial: " + this.currentStage.ToString());
			this.tutorialActive = true;
		}

		// Token: 0x04001071 RID: 4209
		public bool tutorialActive;

		// Token: 0x04001072 RID: 4210
		public TutorialPanel panel;

		// Token: 0x04001073 RID: 4211
		public TutorialStage currentStage;
	}
}
