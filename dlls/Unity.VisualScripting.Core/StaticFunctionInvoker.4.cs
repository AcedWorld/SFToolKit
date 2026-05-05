using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x02000120 RID: 288
	public sealed class StaticFunctionInvoker<TParam0, TParam1, TParam2, TResult> : StaticFunctionInvokerBase<TResult>
	{
		// Token: 0x0600078C RID: 1932 RVA: 0x000220A3 File Offset: 0x000202A3
		public StaticFunctionInvoker(MethodInfo methodInfo) : base(methodInfo)
		{
		}

		// Token: 0x0600078D RID: 1933 RVA: 0x000220AC File Offset: 0x000202AC
		public override object Invoke(object target, params object[] args)
		{
			if (args.Length != 3)
			{
				throw new TargetParameterCountException();
			}
			return this.Invoke(target, args[0], args[1], args[2]);
		}

		// Token: 0x0600078E RID: 1934 RVA: 0x000220CC File Offset: 0x000202CC
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

		// Token: 0x0600078F RID: 1935 RVA: 0x00022154 File Offset: 0x00020354
		public object InvokeUnsafe(object target, object arg0, object arg1, object arg2)
		{
			return this.invoke((TParam0)((object)arg0), (TParam1)((object)arg1), (TParam2)((object)arg2));
		}

		// Token: 0x06000790 RID: 1936 RVA: 0x00022179 File Offset: 0x00020379
		protected override Type[] GetParameterTypes()
		{
			return new Type[]
			{
				typeof(TParam0),
				typeof(TParam1),
				typeof(TParam2)
			};
		}

		// Token: 0x06000791 RID: 1937 RVA: 0x000221A8 File Offset: 0x000203A8
		protected override void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions)
		{
			this.invoke = Expression.Lambda<Func<TParam0, TParam1, TParam2, TResult>>(callExpression, parameterExpressions).Compile();
		}

		// Token: 0x06000792 RID: 1938 RVA: 0x000221BC File Offset: 0x000203BC
		protected override void CreateDelegate()
		{
			this.invoke = ((TParam0 param0, TParam1 param1, TParam2 param2) => ((Func<TParam0, TParam1, TParam2, TResult>)this.methodInfo.CreateDelegate(typeof(Func<TParam0, TParam1, TParam2, TResult>)))(param0, param1, param2));
		}

		// Token: 0x040001C2 RID: 450
		private Func<TParam0, TParam1, TParam2, TResult> invoke;
	}
}
