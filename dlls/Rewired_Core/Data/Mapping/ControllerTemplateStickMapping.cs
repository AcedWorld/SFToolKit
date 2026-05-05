using System;
using Rewired.Utils.Attributes;

namespace Rewired.Data.Mapping
{
	// Token: 0x020002A4 RID: 676
	[Preserve]
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	[Serializable]
	internal class ControllerTemplateStickMapping : ControllerTemplateSpecialElementMapping
	{
		// Token: 0x04001124 RID: 4388
		public int eid_axisX = -1;

		// Token: 0x04001125 RID: 4389
		public int eid_axisY = -1;

		// Token: 0x04001126 RID: 4390
		public int eid_axisZ = -1;
	}
}
