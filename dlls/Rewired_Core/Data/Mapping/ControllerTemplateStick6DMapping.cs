using System;
using Rewired.Utils.Attributes;

namespace Rewired.Data.Mapping
{
	// Token: 0x020002A8 RID: 680
	[Preserve]
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	[Serializable]
	internal class ControllerTemplateStick6DMapping : ControllerTemplateSpecialElementMapping
	{
		// Token: 0x04001133 RID: 4403
		public int eid_positionX = -1;

		// Token: 0x04001134 RID: 4404
		public int eid_positionY = -1;

		// Token: 0x04001135 RID: 4405
		public int eid_positionZ = -1;

		// Token: 0x04001136 RID: 4406
		public int eid_rotationX = -1;

		// Token: 0x04001137 RID: 4407
		public int eid_rotationY = -1;

		// Token: 0x04001138 RID: 4408
		public int eid_rotationZ = -1;
	}
}
