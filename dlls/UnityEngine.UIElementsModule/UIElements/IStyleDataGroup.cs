using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020002EB RID: 747
	internal interface IStyleDataGroup<T>
	{
		// Token: 0x0600194E RID: 6478
		T Copy();

		// Token: 0x0600194F RID: 6479
		void CopyFrom(ref T other);
	}
}
