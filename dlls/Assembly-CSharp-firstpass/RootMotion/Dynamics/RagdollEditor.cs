using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x02000090 RID: 144
	[HelpURL("https://www.youtube.com/watch?v=y-luLRVmL7E&index=1&list=PLVxSIA1OaTOuE2SB9NUbckQ9r2hTg4mvL")]
	[AddComponentMenu("Scripts/RootMotion.Dynamics/Ragdoll Manager/Ragdoll Editor")]
	public class RagdollEditor : MonoBehaviour
	{
		// Token: 0x0600046B RID: 1131 RVA: 0x0001BAD4 File Offset: 0x00019CD4
		[ContextMenu("User Manual")]
		private void OpenUserManual()
		{
			Application.OpenURL("http://root-motion.com/puppetmasterdox/html/page2.html");
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x0001BAE0 File Offset: 0x00019CE0
		[ContextMenu("Scrpt Reference")]
		private void OpenScriptReference()
		{
			Application.OpenURL("http://root-motion.com/puppetmasterdox/html/class_root_motion_1_1_dynamics_1_1_ragdoll_editor.html");
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x00018C73 File Offset: 0x00016E73
		[ContextMenu("TUTORIAL VIDEO")]
		private void OpenTutorial()
		{
			Application.OpenURL("https://www.youtube.com/watch?v=y-luLRVmL7E&index=1&list=PLVxSIA1OaTOuE2SB9NUbckQ9r2hTg4mvL");
		}

		// Token: 0x040003F6 RID: 1014
		[HideInInspector]
		public Rigidbody selectedRigidbody;

		// Token: 0x040003F7 RID: 1015
		[HideInInspector]
		public Collider selectedCollider;

		// Token: 0x040003F8 RID: 1016
		[HideInInspector]
		public bool symmetry = true;

		// Token: 0x040003F9 RID: 1017
		[HideInInspector]
		public RagdollEditor.Mode mode;

		// Token: 0x02000091 RID: 145
		[Serializable]
		public enum Mode
		{
			// Token: 0x040003FB RID: 1019
			Colliders,
			// Token: 0x040003FC RID: 1020
			Joints
		}
	}
}
