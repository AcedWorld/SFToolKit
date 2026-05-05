using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000079 RID: 121
	internal struct HDLightRenderEntity
	{
		// Token: 0x170000CA RID: 202
		// (get) Token: 0x060006D8 RID: 1752 RVA: 0x00045DC4 File Offset: 0x00043FC4
		public bool valid
		{
			get
			{
				return this.entityIndex != HDLightRenderDatabase.InvalidDataIndex;
			}
		}

		// Token: 0x040005BC RID: 1468
		public int entityIndex;

		// Token: 0x040005BD RID: 1469
		public static readonly HDLightRenderEntity Invalid = new HDLightRenderEntity
		{
			entityIndex = HDLightRenderDatabase.InvalidDataIndex
		};
	}
}
