using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x020000FF RID: 255
	public sealed class InstanceActionInvoker<TTarget, TParam0, TParam1> : InstanceActionInvokerBase<TTarget>
	{
		// Token: 0x06000694 RID: 1684 RVA: 0x0001EFB5 File Offset: 0x0001D1B5
		public InstanceActionInvoker(MethodInfo methodInfo) : base(methodInfo)
		{
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x0001EFBE File Offset: 0x0001D1BE
		public override object Invoke(object target, params object[] args)
		{
			if (args.Length != 2)
			{
				throw new TargetParameterCountException();
			}
			return this.Invoke(target, args[0], args[1]);
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x0001EFDC File Offset: 0x0001D1DC
		public override object Invoke(object target, object arg0, object arg1)
		{
			if (OptimizedReflection.safeMode)
			{
				this.VerifyTarget(target);
				base.VerifyArgument<TParam0>(this.methodInfo, 0, arg0);
				base.VerifyArgument<TParam1>(this.methodInfo, 0, arg1);
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

		// Token: 0x06000697 RID: 1687 RVA: 0x0001F050 File Offset: 0x0001D250
		public object InvokeUnsafe(object target, object arg0, object arg1)
		{
			this.invoke((TTarget)((object)target), (TParam0)((object)arg0), (TParam1)((object)arg1));
			return null;
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x0001F070 File Offset: 0x0001D270
		protected override Type[] GetParameterTypes()
		{
			return new Type[]
			{
				typeof(TParam0),
				typeof(TParam1)
			};
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x0001F092 File Offset: 0x0001D292
		protected override void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions)
		{
			this.invoke = Expression.Lambda<Action<TTarget, TParam0, TParam1>>(callExpression, parameterExpressions).Compile();
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x0001F0A6 File Offset: 0x0001D2A6
		protected override void CreateDelegate()
		{
			this.invoke = (Action<TTarget, TParam0, TParam1>)this.methodInfo.CreateDelegate(typeof(Action<TTarget, TParam0, TParam1>));
		}

		// Token: 0x04000199 RID: 409
		private Action<TTarget, TParam0, TParam1> invoke;
	}
}
