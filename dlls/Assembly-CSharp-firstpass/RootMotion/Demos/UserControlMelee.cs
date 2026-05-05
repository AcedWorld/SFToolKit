using System;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001B8 RID: 440
	public class UserControlMelee : UserControlThirdPerson
	{
		// Token: 0x06000BD5 RID: 3029 RVA: 0x0004960B File Offset: 0x0004780B
		protected override void Update()
		{
			base.Update();
			this.state.actionIndex = (Input.GetKey(this.hitKey) ? 1 : 0);
		}

		// Token: 0x04000BF2 RID: 3058
		public KeyCode hitKey;
	}
}
