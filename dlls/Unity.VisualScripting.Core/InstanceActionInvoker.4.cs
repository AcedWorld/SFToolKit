using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x02000100 RID: 256
	public sealed class InstanceActionInvoker<TTarget, TParam0, TParam1, TParam2> : InstanceActionInvokerBase<TTarget>
	{
		// Token: 0x0600069B RID: 1691 RVA: 0x0001F0C8 File Offset: 0x0001D2C8
		public InstanceActionInvoker(MethodInfo methodInfo) : base(methodInfo)
		{
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x0001F0D1 File Offset: 0x0001D2D1
		public override object Invoke(object target, params object[] args)
		{
			if (args.Length != 3)
			{
				throw new TargetParameterCountException();
			}
			return this.Invoke(target, args[0], args[1], args[2]);
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x0001F0F0 File Offset: 0x0001D2F0
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

		// Token: 0x0600069E RID: 1694 RVA: 0x0001F178 File Offset: 0x0001D378
		public object InvokeUnsafe(object target, object arg0, object arg1, object arg2)
		{
			this.invoke((TTarget)((object)target), (TParam0)((object)arg0), (TParam1)((object)arg1), (TParam2)((object)arg2));
			return null;
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x0001F19F File Offset: 0x0001D39F
		protected override Type[] GetParameterTypes()
		{
			return new Type[]
			{
				typeof(TParam0),
				typeof(TParam1),
				typeof(TParam2)
			};
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x0001F1CE File Offset: 0x0001D3CE
		protected override void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions)
		{
			this.invoke = Expression.Lambda<Action<TTarget, TParam0, TParam1, TParam2>>(callExpression, parameterExpressions).Compile();
		}

		// Token: 0x060006A1 RID: 1697 RVA: 0x0001F1E2 File Offset: 0x0001D3E2
		protected override void CreateDelegate()
		{
			this.invoke = (Action<TTarget, TParam0, TParam1, TParam2>)this.methodInfo.CreateDelegate(typeof(Action<TTarget, TParam0, TParam1, TParam2>));
		}

		// Token: 0x0400019A RID: 410
		private Action<TTarget, TParam0, TParam1, TParam2> invoke;
	}
}
