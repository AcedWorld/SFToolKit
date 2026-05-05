using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x0200010B RID: 267
	public abstract class InstanceInvokerBase<TTarget> : InvokerBase
	{
		// Token: 0x060006E3 RID: 1763 RVA: 0x0001FFAC File Offset: 0x0001E1AC
		protected InstanceInvokerBase(MethodInfo methodInfo) : base(methodInfo)
		{
			if (OptimizedReflection.safeMode)
			{
				if (methodInfo.DeclaringType != typeof(TTarget))
				{
					throw new ArgumentException("Declaring type of method info doesn't match generic type.", "methodInfo");
				}
				if (methodInfo.IsStatic)
				{
					throw new ArgumentException("The method is static.", "methodInfo");
				}
			}
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x00020008 File Offset: 0x0001E208
		protected sealed override void CompileExpression()
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(TTarget), "target");
			ParameterExpression[] parameterExpressions = base.GetParameterExpressions();
			ParameterExpression[] array = new ParameterExpression[1 + parameterExpressions.Length];
			array[0] = parameterExpression;
			Array.Copy(parameterExpressions, 0, array, 1, parameterExpressions.Length);
			Expression instance = parameterExpression;
			MethodInfo methodInfo = this.methodInfo;
			Expression[] arguments = parameterExpressions;
			MethodCallExpression callExpression = Expression.Call(instance, methodInfo, arguments);
			this.CompileExpression(callExpression, array);
		}

		// Token: 0x060006E5 RID: 1765
		protected abstract void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions);

		// Token: 0x060006E6 RID: 1766 RVA: 0x00020066 File Offset: 0x0001E266
		protected override void VerifyTarget(object target)
		{
			OptimizedReflection.VerifyInstanceTarget<TTarget>(target);
		}
	}
}
