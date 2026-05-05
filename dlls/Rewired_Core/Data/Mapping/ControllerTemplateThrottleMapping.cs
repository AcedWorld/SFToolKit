using System;
using Rewired.Utils.Attributes;

namespace Rewired.Data.Mapping
{
	// Token: 0x020002A5 RID: 677
	[Preserve]
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	[Serializable]
	internal class ControllerTemplateThrottleMapping : ControllerTemplateSpecialElementMapping
	{
		// Token: 0x04001127 RID: 4391
		public int eid_axis = -1;

		// Token: 0x04001128 RID: 4392
		public int eid_minDetent = -1;
	}
}
