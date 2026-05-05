using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x02000101 RID: 257
	public sealed class InstanceActionInvoker<TTarget, TParam0, TParam1, TParam2, TParam3> : InstanceActionInvokerBase<TTarget>
	{
		// Token: 0x060006A2 RID: 1698 RVA: 0x0001F204 File Offset: 0x0001D404
		public InstanceActionInvoker(MethodInfo methodInfo) : base(methodInfo)
		{
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x0001F20D File Offset: 0x0001D40D
		public override object Invoke(object target, params object[] args)
		{
			if (args.Length != 4)
			{
				throw new TargetParameterCountException();
			}
			return this.Invoke(target, args[0], args[1], args[2], args[3]);
		}

		// Token: 0x060006A4 RID: 1700 RVA: 0x0001F230 File Offset: 0x0001D430
		public override object Invoke(object target, object arg0, object arg1, object arg2, object arg3)
		{
			if (OptimizedReflection.safeMode)
			{
				this.VerifyTarget(target);
				base.VerifyArgument<TParam0>(this.methodInfo, 0, arg0);
				base.VerifyArgument<TParam1>(this.methodInfo, 1, arg1);
				base.VerifyArgument<TParam2>(this.methodInfo, 2, arg2);
				base.VerifyArgument<TParam3>(this.methodInfo, 3, arg3);
				try
				{
					return this.InvokeUnsafe(target, arg0, arg1, arg2, arg3);
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
			return this.InvokeUnsafe(target, arg0, arg1, arg2, arg3);
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x0001F2CC File Offset: 0x0001D4CC
		public object InvokeUnsafe(object target, object arg0, object arg1, object arg2, object arg3)
		{
			this.invoke((TTarget)((object)target), (TParam0)((object)arg0), (TParam1)((object)arg1), (TParam2)((object)arg2), (TParam3)((object)arg3));
			return null;
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x0001F2FA File Offset: 0x0001D4FA
		protected override Type[] GetParameterTypes()
		{
			return new Type[]
			{
				typeof(TParam0),
				typeof(TParam1),
				typeof(TParam2),
				typeof(TParam3)
			};
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x0001F336 File Offset: 0x0001D536
		protected override void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions)
		{
			this.invoke = Expression.Lambda<Action<TTarget, TParam0, TParam1, TParam2, TParam3>>(callExpression, parameterExpressions).Compile();
		}

		// Token: 0x060006A8 RID: 1704 RVA: 0x0001F34A File Offset: 0x0001D54A
		protected override void CreateDelegate()
		{
			this.invoke = (Action<TTarget, TParam0, TParam1, TParam2, TParam3>)this.methodInfo.CreateDelegate(typeof(Action<TTarget, TParam0, TParam1, TParam2, TParam3>));
		}

		// Token: 0x0400019B RID: 411
		private Action<TTarget, TParam0, TParam1, TParam2, TParam3> invoke;
	}
}
