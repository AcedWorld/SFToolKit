using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x020000FE RID: 254
	public sealed class InstanceActionInvoker<TTarget, TParam0> : InstanceActionInvokerBase<TTarget>
	{
		// Token: 0x0600068D RID: 1677 RVA: 0x0001EEC9 File Offset: 0x0001D0C9
		public InstanceActionInvoker(MethodInfo methodInfo) : base(methodInfo)
		{
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x0001EED2 File Offset: 0x0001D0D2
		public override object Invoke(object target, params object[] args)
		{
			if (args.Length != 1)
			{
				throw new TargetParameterCountException();
			}
			return this.Invoke(target, args[0]);
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x0001EEEC File Offset: 0x0001D0EC
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

		// Token: 0x06000690 RID: 1680 RVA: 0x0001EF50 File Offset: 0x0001D150
		private object InvokeUnsafe(object target, object arg0)
		{
			this.invoke((TTarget)((object)target), (TParam0)((object)arg0));
			return null;
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x0001EF6A File Offset: 0x0001D16A
		protected override Type[] GetParameterTypes()
		{
			return new Type[]
			{
				typeof(TParam0)
			};
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x0001EF7F File Offset: 0x0001D17F
		protected override void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions)
		{
			this.invoke = Expression.Lambda<Action<TTarget, TParam0>>(callExpression, parameterExpressions).Compile();
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x0001EF93 File Offset: 0x0001D193
		protected override void CreateDelegate()
		{
			this.invoke = (Action<TTarget, TParam0>)this.methodInfo.CreateDelegate(typeof(Action<TTarget, TParam0>));
		}

		// Token: 0x04000198 RID: 408
		private Action<TTarget, TParam0> invoke;
	}
}
