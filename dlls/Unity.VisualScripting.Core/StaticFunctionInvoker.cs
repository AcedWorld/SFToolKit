using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x0200011D RID: 285
	public sealed class StaticFunctionInvoker<TResult> : StaticFunctionInvokerBase<TResult>
	{
		// Token: 0x06000774 RID: 1908 RVA: 0x00021DAD File Offset: 0x0001FFAD
		public StaticFunctionInvoker(MethodInfo methodInfo) : base(methodInfo)
		{
		}

		// Token: 0x06000775 RID: 1909 RVA: 0x00021DB6 File Offset: 0x0001FFB6
		public override object Invoke(object target, params object[] args)
		{
			if (args.Length != 0)
			{
				throw new TargetParameterCountException();
			}
			return this.Invoke(target);
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x00021DCC File Offset: 0x0001FFCC
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

		// Token: 0x06000777 RID: 1911 RVA: 0x00021E20 File Offset: 0x00020020
		public object InvokeUnsafe(object target)
		{
			return this.invoke();
		}

		// Token: 0x06000778 RID: 1912 RVA: 0x00021E32 File Offset: 0x00020032
		protected override Type[] GetParameterTypes()
		{
			return Type.EmptyTypes;
		}

		// Token: 0x06000779 RID: 1913 RVA: 0x00021E39 File Offset: 0x00020039
		protected override void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions)
		{
			this.invoke = Expression.Lambda<Func<TResult>>(callExpression, parameterExpressions).Compile();
		}

		// Token: 0x0600077A RID: 1914 RVA: 0x00021E4D File Offset: 0x0002004D
		protected override void CreateDelegate()
		{
			this.invoke = (() => ((Func<TResult>)this.methodInfo.CreateDelegate(typeof(Func<TResult>)))());
		}

		// Token: 0x040001BF RID: 447
		private Func<TResult> invoke;
	}
}
