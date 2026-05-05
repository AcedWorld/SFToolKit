using System;
using Rewired.Utils.Attributes;

namespace Rewired.Data.Mapping
{
	// Token: 0x020002A6 RID: 678
	[Preserve]
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	[Serializable]
	internal class ControllerTemplateHatMapping : ControllerTemplateSpecialElementMapping
	{
		// Token: 0x04001129 RID: 4393
		public int eid_up = -1;

		// Token: 0x0400112A RID: 4394
		public int eid_upRight = -1;

		// Token: 0x0400112B RID: 4395
		public int eid_right = -1;

		// Token: 0x0400112C RID: 4396
		public int eid_downRight = -1;

		// Token: 0x0400112D RID: 4397
		public int eid_down = -1;

		// Token: 0x0400112E RID: 4398
		public int eid_downLeft = -1;

		// Token: 0x0400112F RID: 4399
		public int eid_left = -1;

		// Token: 0x04001130 RID: 4400
		public int eid_upLeft = -1;
	}
}
