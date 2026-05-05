using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200010E RID: 270
	public interface IOptimizedAccessor
	{
		// Token: 0x060006FC RID: 1788
		void Compile();

		// Token: 0x060006FD RID: 1789
		object GetValue(object target);

		// Token: 0x060006FE RID: 1790
		void SetValue(object target, object value);
	}
}
