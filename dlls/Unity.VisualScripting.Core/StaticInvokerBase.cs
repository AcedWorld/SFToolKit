using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x02000123 RID: 291
	public abstract class StaticInvokerBase : InvokerBase
	{
		// Token: 0x060007A4 RID: 1956 RVA: 0x00022524 File Offset: 0x00020724
		protected StaticInvokerBase(MethodInfo methodInfo) : base(methodInfo)
		{
			if (OptimizedReflection.safeMode && !methodInfo.IsStatic)
			{
				throw new ArgumentException("The method isn't static.", "methodInfo");
			}
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x0002254C File Offset: 0x0002074C
		protected sealed override void CompileExpression()
		{
			ParameterExpression[] parameterExpressions = base.GetParameterExpressions();
			MethodInfo methodInfo = this.methodInfo;
			Expression[] arguments = parameterExpressions;
			MethodCallExpression callExpression = Expression.Call(methodInfo, arguments);
			this.CompileExpression(callExpression, parameterExpressions);
		}

		// Token: 0x060007A6 RID: 1958
		protected abstract void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions);

		// Token: 0x060007A7 RID: 1959 RVA: 0x00022577 File Offset: 0x00020777
		protected override void VerifyTarget(object target)
		{
			OptimizedReflection.VerifyStaticTarget(this.targetType, target);
		}
	}
}
