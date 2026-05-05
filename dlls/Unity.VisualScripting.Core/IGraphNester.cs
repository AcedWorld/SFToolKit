using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000076 RID: 118
	public interface IGraphNester : IGraphParent
	{
		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060003A8 RID: 936
		IGraphNest nest { get; }

		// Token: 0x060003A9 RID: 937
		void InstantiateNest();

		// Token: 0x060003AA RID: 938
		void UninstantiateNest();
	}
}
