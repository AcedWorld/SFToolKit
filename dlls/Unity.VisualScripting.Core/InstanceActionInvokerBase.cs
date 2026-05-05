using System;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x020000FC RID: 252
	public abstract class InstanceActionInvokerBase<TTarget> : InstanceInvokerBase<TTarget>
	{
		// Token: 0x06000685 RID: 1669 RVA: 0x0001EDFE File Offset: 0x0001CFFE
		protected InstanceActionInvokerBase(MethodInfo methodInfo) : base(methodInfo)
		{
		}
	}
}
