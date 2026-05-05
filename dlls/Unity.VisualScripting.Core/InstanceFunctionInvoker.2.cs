using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x02000106 RID: 262
	public sealed class InstanceFunctionInvoker<TTarget, TParam0, TResult> : InstanceFunctionInvokerBase<TTarget, TResult>
	{
		// Token: 0x060006C0 RID: 1728 RVA: 0x0001F955 File Offset: 0x0001DB55
		public InstanceFunctionInvoker(MethodInfo methodInfo) : base(methodInfo)
		{
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x0001F95E File Offset: 0x0001DB5E
		public override object Invoke(object target, params object[] args)
		{
			if (args.Length != 1)
			{
				throw new TargetParameterCountException();
			}
			return this.Invoke(target, args[0]);
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x0001F978 File Offset: 0x0001DB78
		public override object Invoke(object target, object arg0)
		{
			if (OptimizedReflection.safeMode)
			{
				this.VerifyTarget(target);
				base.VerifyArgument<TParam0>(this.methodInfo, 0, arg0);
				try
				{
					return this.InvokeUnsafe(target, arg0);
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
			return this.InvokeUnsafe(target, arg0);
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x0001F9DC File Offset: 0x0001DBDC
		public object InvokeUnsafe(object target, object arg0)
		{
			return this.invoke((TTarget)((object)target), (TParam0)((object)arg0));
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x0001F9FA File Offset: 0x0001DBFA
		protected override Type[] GetParameterTypes()
		{
			return new Type[]
			{
				typeof(TParam0)
			};
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x0001FA0F File Offset: 0x0001DC0F
		protected override void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions)
		{
			this.invoke = Expression.Lambda<Func<TTarget, TParam0, TResult>>(callExpression, parameterExpressions).Compile();
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x0001FA23 File Offset: 0x0001DC23
		protected override void CreateDelegate()
		{
			this.invoke = (Func<TTarget, TParam0, TResult>)this.methodInfo.CreateDelegate(typeof(Func<TTarget, TParam0, TResult>));
		}

		// Token: 0x040001A1 RID: 417
		private Func<TTarget, TParam0, TResult> invoke;
	}
}
