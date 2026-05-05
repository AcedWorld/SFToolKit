using System;
using RootMotion.Dynamics;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001A2 RID: 418
	public class Killing : MonoBehaviour
	{
		// Token: 0x06000B89 RID: 2953 RVA: 0x00048074 File Offset: 0x00046274
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.K))
			{
				this.puppetMaster.Kill(this.stateSettings);
			}
			if (Input.GetKeyDown(KeyCode.F))
			{
				this.puppetMaster.Freeze(this.stateSettings);
			}
			if (Input.GetKeyDown(KeyCode.R))
			{
				this.puppetMaster.Resurrect();
			}
		}

		// Token: 0x04000B86 RID: 2950
		[Tooltip("Reference to the PuppetMaster component.")]
		public PuppetMaster puppetMaster;

		// Token: 0x04000B87 RID: 2951
		[Tooltip("Settings for killing and freezing the puppet.")]
		public PuppetMaster.StateSettings stateSettings = PuppetMaster.StateSettings.Default;
	}
}
