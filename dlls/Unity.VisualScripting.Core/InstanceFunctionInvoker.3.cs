using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x02000107 RID: 263
	public sealed class InstanceFunctionInvoker<TTarget, TParam0, TParam1, TResult> : InstanceFunctionInvokerBase<TTarget, TResult>
	{
		// Token: 0x060006C7 RID: 1735 RVA: 0x0001FA45 File Offset: 0x0001DC45
		public InstanceFunctionInvoker(MethodInfo methodInfo) : base(methodInfo)
		{
		}

		// Token: 0x060006C8 RID: 1736 RVA: 0x0001FA4E File Offset: 0x0001DC4E
		public override object Invoke(object target, params object[] args)
		{
			if (args.Length != 2)
			{
				throw new TargetParameterCountException();
			}
			return this.Invoke(target, args[0], args[1]);
		}

		// Token: 0x060006C9 RID: 1737 RVA: 0x0001FA6C File Offset: 0x0001DC6C
		public override object Invoke(object target, object arg0, object arg1)
		{
			if (OptimizedReflection.safeMode)
			{
				this.VerifyTarget(target);
				base.VerifyArgument<TParam0>(this.methodInfo, 0, arg0);
				base.VerifyArgument<TParam1>(this.methodInfo, 1, arg1);
				try
				{
					return this.InvokeUnsafe(target, arg0, arg1);
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
			return this.InvokeUnsafe(target, arg0, arg1);
		}

		// Token: 0x060006CA RID: 1738 RVA: 0x0001FAE0 File Offset: 0x0001DCE0
		public object InvokeUnsafe(object target, object arg0, object arg1)
		{
			return this.invoke((TTarget)((object)target), (TParam0)((object)arg0), (TParam1)((object)arg1));
		}

		// Token: 0x060006CB RID: 1739 RVA: 0x0001FB04 File Offset: 0x0001DD04
		protected override Type[] GetParameterTypes()
		{
			return new Type[]
			{
				typeof(TParam0),
				typeof(TParam1)
			};
		}

		// Token: 0x060006CC RID: 1740 RVA: 0x0001FB26 File Offset: 0x0001DD26
		protected override void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions)
		{
			this.invoke = Expression.Lambda<Func<TTarget, TParam0, TParam1, TResult>>(callExpression, parameterExpressions).Compile();
		}

		// Token: 0x060006CD RID: 1741 RVA: 0x0001FB3A File Offset: 0x0001DD3A
		protected override void CreateDelegate()
		{
			this.invoke = (Func<TTarget, TParam0, TParam1, TResult>)this.methodInfo.CreateDelegate(typeof(Func<TTarget, TParam0, TParam1, TResult>));
		}

		// Token: 0x040001A2 RID: 418
		private Func<TTarget, TParam0, TParam1, TResult> invoke;
	}
}
