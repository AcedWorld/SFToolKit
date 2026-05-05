using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x0200011F RID: 287
	public sealed class StaticFunctionInvoker<TParam0, TParam1, TResult> : StaticFunctionInvokerBase<TResult>
	{
		// Token: 0x06000784 RID: 1924 RVA: 0x00021F7F File Offset: 0x0002017F
		public StaticFunctionInvoker(MethodInfo methodInfo) : base(methodInfo)
		{
		}

		// Token: 0x06000785 RID: 1925 RVA: 0x00021F88 File Offset: 0x00020188
		public override object Invoke(object target, params object[] args)
		{
			if (args.Length != 2)
			{
				throw new TargetParameterCountException();
			}
			return this.Invoke(target, args[0], args[1]);
		}

		// Token: 0x06000786 RID: 1926 RVA: 0x00021FA4 File Offset: 0x000201A4
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

		// Token: 0x06000787 RID: 1927 RVA: 0x00022018 File Offset: 0x00020218
		public object InvokeUnsafe(object target, object arg0, object arg1)
		{
			return this.invoke((TParam0)((object)arg0), (TParam1)((object)arg1));
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x00022036 File Offset: 0x00020236
		protected override Type[] GetParameterTypes()
		{
			return new Type[]
			{
				typeof(TParam0),
				typeof(TParam1)
			};
		}

		// Token: 0x06000789 RID: 1929 RVA: 0x00022058 File Offset: 0x00020258
		protected override void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions)
		{
			this.invoke = Expression.Lambda<Func<TParam0, TParam1, TResult>>(callExpression, parameterExpressions).Compile();
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x0002206C File Offset: 0x0002026C
		protected override void CreateDelegate()
		{
			this.invoke = ((TParam0 param0, TParam1 param1) => ((Func<TParam0, TParam1, TResult>)this.methodInfo.CreateDelegate(typeof(Func<TParam0, TParam1, TResult>)))(param0, param1));
		}

		// Token: 0x040001C1 RID: 449
		private Func<TParam0, TParam1, TResult> invoke;
	}
}
