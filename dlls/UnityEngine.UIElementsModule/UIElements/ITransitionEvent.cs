using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000235 RID: 565
	public interface ITransitionEvent
	{
		// Token: 0x1700036B RID: 875
		// (get) Token: 0x06001038 RID: 4152
		StylePropertyNameCollection stylePropertyNames { get; }

		// Token: 0x1700036C RID: 876
		// (get) Token: 0x06001039 RID: 4153
		double elapsedTime { get; }
	}
}
