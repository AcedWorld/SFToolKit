using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x02000108 RID: 264
	public sealed class InstanceFunctionInvoker<TTarget, TParam0, TParam1, TParam2, TResult> : InstanceFunctionInvokerBase<TTarget, TResult>
	{
		// Token: 0x060006CE RID: 1742 RVA: 0x0001FB5C File Offset: 0x0001DD5C
		public InstanceFunctionInvoker(MethodInfo methodInfo) : base(methodInfo)
		{
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x0001FB65 File Offset: 0x0001DD65
		public override object Invoke(object target, params object[] args)
		{
			if (args.Length != 3)
			{
				throw new TargetParameterCountException();
			}
			return this.Invoke(target, args[0], args[1], args[2]);
		}

		// Token: 0x060006D0 RID: 1744 RVA: 0x0001FB84 File Offset: 0x0001DD84
		public override object Invoke(object target, object arg0, object arg1, object arg2)
		{
			if (OptimizedReflection.safeMode)
			{
				this.VerifyTarget(target);
				base.VerifyArgument<TParam0>(this.methodInfo, 0, arg0);
				base.VerifyArgument<TParam1>(this.methodInfo, 1, arg1);
				base.VerifyArgument<TParam2>(this.methodInfo, 2, arg2);
				try
				{
					return this.InvokeUnsafe(target, arg0, arg1, arg2);
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
			return this.InvokeUnsafe(target, arg0, arg1, arg2);
		}

		// Token: 0x060006D1 RID: 1745 RVA: 0x0001FC0C File Offset: 0x0001DE0C
		public object InvokeUnsafe(object target, object arg0, object arg1, object arg2)
		{
			return this.invoke((TTarget)((object)target), (TParam0)((object)arg0), (TParam1)((object)arg1), (TParam2)((object)arg2));
		}

		// Token: 0x060006D2 RID: 1746 RVA: 0x0001FC37 File Offset: 0x0001DE37
		protected override Type[] GetParameterTypes()
		{
			return new Type[]
			{
				typeof(TParam0),
				typeof(TParam1),
				typeof(TParam2)
			};
		}

		// Token: 0x060006D3 RID: 1747 RVA: 0x0001FC66 File Offset: 0x0001DE66
		protected override void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions)
		{
			this.invoke = Expression.Lambda<Func<TTarget, TParam0, TParam1, TParam2, TResult>>(callExpression, parameterExpressions).Compile();
		}

		// Token: 0x060006D4 RID: 1748 RVA: 0x0001FC7A File Offset: 0x0001DE7A
		protected override void CreateDelegate()
		{
			this.invoke = (Func<TTarget, TParam0, TParam1, TParam2, TResult>)this.methodInfo.CreateDelegate(typeof(Func<TTarget, TParam0, TParam1, TParam2, TResult>));
		}

		// Token: 0x040001A3 RID: 419
		private Func<TTarget, TParam0, TParam1, TParam2, TResult> invoke;
	}
}
