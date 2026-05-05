using System;
using Rewired.Utils.Attributes;

namespace Rewired.Data.Mapping
{
	// Token: 0x020002A2 RID: 674
	[Preserve]
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	[Serializable]
	internal class ControllerTemplateThumbStickMapping : ControllerTemplateSpecialElementMapping
	{
		// Token: 0x0400111C RID: 4380
		public int eid_axisX = -1;

		// Token: 0x0400111D RID: 4381
		public int eid_axisY = -1;

		// Token: 0x0400111E RID: 4382
		public int eid_button = -1;
	}
}
