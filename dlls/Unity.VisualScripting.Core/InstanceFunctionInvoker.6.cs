using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x0200010A RID: 266
	public sealed class InstanceFunctionInvoker<TTarget, TParam0, TParam1, TParam2, TParam3, TParam4, TResult> : InstanceFunctionInvokerBase<TTarget, TResult>
	{
		// Token: 0x060006DC RID: 1756 RVA: 0x0001FE08 File Offset: 0x0001E008
		public InstanceFunctionInvoker(MethodInfo methodInfo) : base(methodInfo)
		{
		}

		// Token: 0x060006DD RID: 1757 RVA: 0x0001FE11 File Offset: 0x0001E011
		public override object Invoke(object target, params object[] args)
		{
			if (args.Length != 5)
			{
				throw new TargetParameterCountException();
			}
			return this.Invoke(target, args[0], args[1], args[2], args[3], args[4]);
		}

		// Token: 0x060006DE RID: 1758 RVA: 0x0001FE38 File Offset: 0x0001E038
		public override object Invoke(object target, object arg0, object arg1, object arg2, object arg3, object arg4)
		{
			if (OptimizedReflection.safeMode)
			{
				this.VerifyTarget(target);
				base.VerifyArgument<TParam0>(this.methodInfo, 0, arg0);
				base.VerifyArgument<TParam1>(this.methodInfo, 1, arg1);
				base.VerifyArgument<TParam2>(this.methodInfo, 2, arg2);
				base.VerifyArgument<TParam3>(this.methodInfo, 3, arg3);
				base.VerifyArgument<TParam4>(this.methodInfo, 4, arg4);
				try
				{
					return this.InvokeUnsafe(target, arg0, arg1, arg2, arg3, arg4);
				}
				catch (TargetInvocationException)
				{
					throw;
				}
				catch (Exception inner)
				{
					throw new TargetInvocationException(inner);
				}
			}
			return this.InvokeUnsafe(target, arg0, arg1, arg2, arg3, arg4);
		}

		// Token: 0x060006DF RID: 1759 RVA: 0x0001FEE4 File Offset: 0x0001E0E4
		public object InvokeUnsafe(object target, object arg0, object arg1, object arg2, object arg3, object arg4)
		{
			return this.invoke((TTarget)((object)target), (TParam0)((object)arg0), (TParam1)((object)arg1), (TParam2)((object)arg2), (TParam3)((object)arg3), (TParam4)((object)arg4));
		}

		// Token: 0x060006E0 RID: 1760 RVA: 0x0001FF20 File Offset: 0x0001E120
		protected override Type[] GetParameterTypes()
		{
			return new Type[]
			{
				typeof(TParam0),
				typeof(TParam1),
				typeof(TParam2),
				typeof(TParam3),
				typeof(TParam4)
			};
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x0001FF74 File Offset: 0x0001E174
		protected override void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions)
		{
			this.invoke = Expression.Lambda<Func<TTarget, TParam0, TParam1, TParam2, TParam3, TParam4, TResult>>(callExpression, parameterExpressions).Compile();
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x0001FF88 File Offset: 0x0001E188
		protected override void CreateDelegate()
		{
			this.invoke = (Func<TTarget, TParam0, TParam1, TParam2, TParam3, TParam4, TResult>)this.methodInfo.CreateDelegate(typeof(Func<TTarget, TParam0, TParam1, TParam2, TParam3, TParam4, TResult>));
		}

		// Token: 0x040001A5 RID: 421
		private Func<TTarget, TParam0, TParam1, TParam2, TParam3, TParam4, TResult> invoke;
	}
}
