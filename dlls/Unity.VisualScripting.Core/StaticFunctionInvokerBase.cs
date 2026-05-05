using System;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x0200011C RID: 284
	public abstract class StaticFunctionInvokerBase<TResult> : StaticInvokerBase
	{
		// Token: 0x06000773 RID: 1907 RVA: 0x00021D76 File Offset: 0x0001FF76
		protected StaticFunctionInvokerBase(MethodInfo methodInfo) : base(methodInfo)
		{
			if (OptimizedReflection.safeMode && methodInfo.ReturnType != typeof(TResult))
			{
				throw new ArgumentException("Return type of method info doesn't match generic type.", "methodInfo");
			}
		}
	}
}
