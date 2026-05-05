using System;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x02000114 RID: 276
	public abstract class StaticActionInvokerBase : StaticInvokerBase
	{
		// Token: 0x0600073A RID: 1850 RVA: 0x0002130F File Offset: 0x0001F50F
		protected StaticActionInvokerBase(MethodInfo methodInfo) : base(methodInfo)
		{
		}
	}
}
