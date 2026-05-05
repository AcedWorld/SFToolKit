using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000167 RID: 359
	public class InteractionSystemTestGUI : MonoBehaviour
	{
		// Token: 0x06000A9F RID: 2719 RVA: 0x00043DC0 File Offset: 0x00041FC0
		private void Awake()
		{
			this.interactionSystem = base.GetComponent<InteractionSystem>();
		}

		// Token: 0x06000AA0 RID: 2720 RVA: 0x00043DD0 File Offset: 0x00041FD0
		private void OnGUI()
		{
			if (this.interactionSystem == null)
			{
				return;
			}
			if (GUILayout.Button("Start Interaction With " + this.interactionObject.name, Array.Empty<GUILayoutOption>()))
			{
				if (this.effectors.Length == 0)
				{
					Debug.Log("Please select the effectors to interact with.");
				}
				foreach (FullBodyBipedEffector effectorType in this.effectors)
				{
					this.interactionSystem.StartInteraction(effectorType, this.interactionObject, true);
				}
			}
			if (this.effectors.Length == 0)
			{
				return;
			}
			if (this.interactionSystem.IsPaused(this.effectors[0]) && GUILayout.Button("Resume Interaction With " + this.interactionObject.name, Array.Empty<GUILayoutOption>()))
			{
				this.interactionSystem.ResumeAll();
			}
		}

		// Token: 0x04000A62 RID: 2658
		[Tooltip("The object to interact to")]
		public InteractionObject interactionObject;

		// Token: 0x04000A63 RID: 2659
		[Tooltip("The effectors to interact with")]
		public FullBodyBipedEffector[] effectors;

		// Token: 0x04000A64 RID: 2660
		private InteractionSystem interactionSystem;
	}
}
