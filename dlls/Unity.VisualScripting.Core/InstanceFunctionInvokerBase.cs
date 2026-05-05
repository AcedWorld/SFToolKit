using System;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x02000104 RID: 260
	public abstract class InstanceFunctionInvokerBase<TTarget, TResult> : InstanceInvokerBase<TTarget>
	{
		// Token: 0x060006B8 RID: 1720 RVA: 0x0001F856 File Offset: 0x0001DA56
		protected InstanceFunctionInvokerBase(MethodInfo methodInfo) : base(methodInfo)
		{
			if (OptimizedReflection.safeMode && methodInfo.ReturnType != typeof(TResult))
			{
				throw new ArgumentException("Return type of method info doesn't match generic type.", "methodInfo");
			}
		}
	}
}
