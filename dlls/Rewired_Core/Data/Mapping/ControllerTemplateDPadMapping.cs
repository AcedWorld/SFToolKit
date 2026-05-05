using System;
using Rewired.Utils.Attributes;

namespace Rewired.Data.Mapping
{
	// Token: 0x020002A3 RID: 675
	[Preserve]
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	[Serializable]
	internal class ControllerTemplateDPadMapping : ControllerTemplateSpecialElementMapping
	{
		// Token: 0x0400111F RID: 4383
		public int eid_up = -1;

		// Token: 0x04001120 RID: 4384
		public int eid_right = -1;

		// Token: 0x04001121 RID: 4385
		public int eid_down = -1;

		// Token: 0x04001122 RID: 4386
		public int eid_left = -1;

		// Token: 0x04001123 RID: 4387
		public int eid_press = -1;
	}
}
