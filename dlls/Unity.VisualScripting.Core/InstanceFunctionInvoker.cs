using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x02000105 RID: 261
	public sealed class InstanceFunctionInvoker<TTarget, TResult> : InstanceFunctionInvokerBase<TTarget, TResult>
	{
		// Token: 0x060006B9 RID: 1721 RVA: 0x0001F88D File Offset: 0x0001DA8D
		public InstanceFunctionInvoker(MethodInfo methodInfo) : base(methodInfo)
		{
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x0001F896 File Offset: 0x0001DA96
		public override object Invoke(object target, params object[] args)
		{
			if (args.Length != 0)
			{
				throw new TargetParameterCountException();
			}
			return this.Invoke(target);
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x0001F8AC File Offset: 0x0001DAAC
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

		// Token: 0x060006BC RID: 1724 RVA: 0x0001F900 File Offset: 0x0001DB00
		public object InvokeUnsafe(object target)
		{
			return this.invoke((TTarget)((object)target));
		}

		// Token: 0x060006BD RID: 1725 RVA: 0x0001F918 File Offset: 0x0001DB18
		protected override Type[] GetParameterTypes()
		{
			return Type.EmptyTypes;
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x0001F91F File Offset: 0x0001DB1F
		protected override void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions)
		{
			this.invoke = Expression.Lambda<Func<TTarget, TResult>>(callExpression, parameterExpressions).Compile();
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x0001F933 File Offset: 0x0001DB33
		protected override void CreateDelegate()
		{
			this.invoke = (Func<TTarget, TResult>)this.methodInfo.CreateDelegate(typeof(Func<TTarget, TResult>));
		}

		// Token: 0x040001A0 RID: 416
		private Func<TTarget, TResult> invoke;
	}
}
