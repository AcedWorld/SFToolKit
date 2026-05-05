using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000C5 RID: 197
	public interface IPoolable
	{
		// Token: 0x060004CA RID: 1226
		void New();

		// Token: 0x060004CB RID: 1227
		void Free();
	}
}
