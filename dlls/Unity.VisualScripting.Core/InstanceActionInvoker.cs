using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x020000FD RID: 253
	public sealed class InstanceActionInvoker<TTarget> : InstanceActionInvokerBase<TTarget>
	{
		// Token: 0x06000686 RID: 1670 RVA: 0x0001EE07 File Offset: 0x0001D007
		public InstanceActionInvoker(MethodInfo methodInfo) : base(methodInfo)
		{
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x0001EE10 File Offset: 0x0001D010
		public override object Invoke(object target, params object[] args)
		{
			if (args.Length != 0)
			{
				throw new TargetParameterCountException();
			}
			return this.Invoke(target);
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x0001EE24 File Offset: 0x0001D024
		public override object Invoke(object target)
		{
			if (OptimizedReflection.safeMode)
			{
				this.VerifyTarget(target);
				try
				{
					return this.InvokeUnsafe(target);
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
			return this.InvokeUnsafe(target);
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x0001EE78 File Offset: 0x0001D078
		private object InvokeUnsafe(object target)
		{
			this.invoke((TTarget)((object)target));
			return null;
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x0001EE8C File Offset: 0x0001D08C
		protected override Type[] GetParameterTypes()
		{
			return Type.EmptyTypes;
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x0001EE93 File Offset: 0x0001D093
		protected override void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions)
		{
			this.invoke = Expression.Lambda<Action<TTarget>>(callExpression, parameterExpressions).Compile();
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x0001EEA7 File Offset: 0x0001D0A7
		protected override void CreateDelegate()
		{
			this.invoke = (Action<TTarget>)this.methodInfo.CreateDelegate(typeof(Action<TTarget>));
		}

		// Token: 0x04000197 RID: 407
		private Action<TTarget> invoke;
	}
}
