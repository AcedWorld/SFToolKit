using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x02000116 RID: 278
	public sealed class StaticActionInvoker<TParam0> : StaticActionInvokerBase
	{
		// Token: 0x06000743 RID: 1859 RVA: 0x000213E6 File Offset: 0x0001F5E6
		public StaticActionInvoker(MethodInfo methodInfo) : base(methodInfo)
		{
		}

		// Token: 0x06000744 RID: 1860 RVA: 0x000213EF File Offset: 0x0001F5EF
		public override object Invoke(object target, params object[] args)
		{
			if (args.Length != 1)
			{
				throw new TargetParameterCountException();
			}
			return this.Invoke(target, args[0]);
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x00021408 File Offset: 0x0001F608
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

		// Token: 0x06000746 RID: 1862 RVA: 0x0002146C File Offset: 0x0001F66C
		private object InvokeUnsafe(object target, object arg0)
		{
			this.invoke((TParam0)((object)arg0));
			return null;
		}

		// Token: 0x06000747 RID: 1863 RVA: 0x00021480 File Offset: 0x0001F680
		protected override Type[] GetParameterTypes()
		{
			return new Type[]
			{
				typeof(TParam0)
			};
		}

		// Token: 0x06000748 RID: 1864 RVA: 0x00021495 File Offset: 0x0001F695
		protected override void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions)
		{
			this.invoke = Expression.Lambda<Action<TParam0>>(callExpression, parameterExpressions).Compile();
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x000214A9 File Offset: 0x0001F6A9
		protected override void CreateDelegate()
		{
			this.invoke = delegate(TParam0 param0)
			{
				((Action<TParam0>)this.methodInfo.CreateDelegate(typeof(Action<TParam0>)))(param0);
			};
		}

		// Token: 0x040001B6 RID: 438
		private Action<TParam0> invoke;
	}
}
