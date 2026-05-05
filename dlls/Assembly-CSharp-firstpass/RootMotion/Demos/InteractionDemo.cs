using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000166 RID: 358
	public class InteractionDemo : MonoBehaviour
	{
		// Token: 0x06000A9D RID: 2717 RVA: 0x00043BCC File Offset: 0x00041DCC
		private void OnGUI()
		{
			this.interrupt = GUILayout.Toggle(this.interrupt, "Interrupt", Array.Empty<GUILayoutOption>());
			if (this.isSitting)
			{
				if (!this.interactionSystem.inInteraction && GUILayout.Button("Stand Up", Array.Empty<GUILayoutOption>()))
				{
					this.interactionSystem.ResumeAll();
					this.isSitting = false;
				}
				return;
			}
			if (GUILayout.Button("Pick Up Ball", Array.Empty<GUILayoutOption>()))
			{
				this.interactionSystem.StartInteraction(FullBodyBipedEffector.RightHand, this.ball, this.interrupt);
			}
			if (GUILayout.Button("Button Left Hand", Array.Empty<GUILayoutOption>()))
			{
				this.interactionSystem.StartInteraction(FullBodyBipedEffector.LeftHand, this.button, this.interrupt);
			}
			if (GUILayout.Button("Button Right Hand", Array.Empty<GUILayoutOption>()))
			{
				this.interactionSystem.StartInteraction(FullBodyBipedEffector.RightHand, this.button, this.interrupt);
			}
			if (GUILayout.Button("Put Out Cigarette", Array.Empty<GUILayoutOption>()))
			{
				this.interactionSystem.StartInteraction(FullBodyBipedEffector.RightFoot, this.cigarette, this.interrupt);
			}
			if (GUILayout.Button("Open Door", Array.Empty<GUILayoutOption>()))
			{
				this.interactionSystem.StartInteraction(FullBodyBipedEffector.LeftHand, this.door, this.interrupt);
			}
			if (!this.interactionSystem.inInteraction && GUILayout.Button("Sit Down", Array.Empty<GUILayoutOption>()))
			{
				this.interactionSystem.StartInteraction(FullBodyBipedEffector.Body, this.benchMain, this.interrupt);
				this.interactionSystem.StartInteraction(FullBodyBipedEffector.LeftThigh, this.benchMain, this.interrupt);
				this.interactionSystem.StartInteraction(FullBodyBipedEffector.RightThigh, this.benchMain, this.interrupt);
				this.interactionSystem.StartInteraction(FullBodyBipedEffector.LeftFoot, this.benchMain, this.interrupt);
				this.interactionSystem.StartInteraction(FullBodyBipedEffector.LeftHand, this.benchHands, this.interrupt);
				this.interactionSystem.StartInteraction(FullBodyBipedEffector.RightHand, this.benchHands, this.interrupt);
				this.isSitting = true;
			}
		}

		// Token: 0x04000A59 RID: 2649
		public InteractionSystem interactionSystem;

		// Token: 0x04000A5A RID: 2650
		public bool interrupt;

		// Token: 0x04000A5B RID: 2651
		public InteractionObject ball;

		// Token: 0x04000A5C RID: 2652
		public InteractionObject benchMain;

		// Token: 0x04000A5D RID: 2653
		public InteractionObject benchHands;

		// Token: 0x04000A5E RID: 2654
		public InteractionObject button;

		// Token: 0x04000A5F RID: 2655
		public InteractionObject cigarette;

		// Token: 0x04000A60 RID: 2656
		public InteractionObject door;

		// Token: 0x04000A61 RID: 2657
		private bool isSitting;
	}
}
