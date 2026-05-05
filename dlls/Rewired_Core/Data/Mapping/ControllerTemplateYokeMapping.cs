using System;
using Rewired.Utils.Attributes;

namespace Rewired.Data.Mapping
{
	// Token: 0x020002A7 RID: 679
	[Preserve]
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	[Serializable]
	internal class ControllerTemplateYokeMapping : ControllerTemplateSpecialElementMapping
	{
		// Token: 0x04001131 RID: 4401
		public int eid_axisX = -1;

		// Token: 0x04001132 RID: 4402
		public int eid_axisZ = -1;
	}
}
