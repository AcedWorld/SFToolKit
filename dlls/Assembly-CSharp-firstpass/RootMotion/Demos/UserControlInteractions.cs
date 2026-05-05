using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x0200017E RID: 382
	public class UserControlInteractions : UserControlThirdPerson
	{
		// Token: 0x06000B00 RID: 2816 RVA: 0x00046050 File Offset: 0x00044250
		protected override void Update()
		{
			if (this.disableInputInInteraction && this.interactionSystem != null && (this.interactionSystem.inInteraction || this.interactionSystem.IsPaused()))
			{
				float minActiveProgress = this.interactionSystem.GetMinActiveProgress();
				if (minActiveProgress > 0f && minActiveProgress < this.enableInputAtProgress)
				{
					this.state.move = Vector3.zero;
					this.state.jump = false;
					return;
				}
			}
			base.Update();
		}

		// Token: 0x06000B01 RID: 2817 RVA: 0x000460D0 File Offset: 0x000442D0
		private void OnGUI()
		{
			if (!this.character.onGround)
			{
				return;
			}
			if (this.interactionSystem.IsPaused() && this.interactionSystem.IsInSync())
			{
				GUILayout.Label("Press E to resume interaction", Array.Empty<GUILayoutOption>());
				if (Input.GetKey(KeyCode.E))
				{
					this.interactionSystem.ResumeAll();
				}
				return;
			}
			int closestTriggerIndex = this.interactionSystem.GetClosestTriggerIndex();
			if (closestTriggerIndex == -1)
			{
				return;
			}
			if (!this.interactionSystem.TriggerEffectorsReady(closestTriggerIndex))
			{
				return;
			}
			GUILayout.Label("Press E to start interaction", Array.Empty<GUILayoutOption>());
			if (Input.GetKey(KeyCode.E))
			{
				this.interactionSystem.TriggerInteraction(closestTriggerIndex, false);
			}
		}

		// Token: 0x04000AE2 RID: 2786
		public CharacterThirdPerson character;

		// Token: 0x04000AE3 RID: 2787
		public InteractionSystem interactionSystem;

		// Token: 0x04000AE4 RID: 2788
		public bool disableInputInInteraction = true;

		// Token: 0x04000AE5 RID: 2789
		public float enableInputAtProgress = 0.8f;
	}
}
