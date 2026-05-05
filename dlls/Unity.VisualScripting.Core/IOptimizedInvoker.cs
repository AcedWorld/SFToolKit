using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200010F RID: 271
	public interface IOptimizedInvoker
	{
		// Token: 0x060006FF RID: 1791
		void Compile();

		// Token: 0x06000700 RID: 1792
		object Invoke(object target);

		// Token: 0x06000701 RID: 1793
		object Invoke(object target, object arg0);

		// Token: 0x06000702 RID: 1794
		object Invoke(object target, object arg0, object arg1);

		// Token: 0x06000703 RID: 1795
		object Invoke(object target, object arg0, object arg1, object arg2);

		// Token: 0x06000704 RID: 1796
		object Invoke(object target, object arg0, object arg1, object arg2, object arg3);

		// Token: 0x06000705 RID: 1797
		object Invoke(object target, object arg0, object arg1, object arg2, object arg3, object arg4);

		// Token: 0x06000706 RID: 1798
		object Invoke(object target, params object[] args);
	}
}
