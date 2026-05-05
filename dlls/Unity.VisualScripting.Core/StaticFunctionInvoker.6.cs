using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x02000122 RID: 290
	public sealed class StaticFunctionInvoker<TParam0, TParam1, TParam2, TParam3, TParam4, TResult> : StaticFunctionInvokerBase<TResult>
	{
		// Token: 0x0600079C RID: 1948 RVA: 0x00022372 File Offset: 0x00020572
		public StaticFunctionInvoker(MethodInfo methodInfo) : base(methodInfo)
		{
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x0002237B File Offset: 0x0002057B
		public override object Invoke(object target, params object[] args)
		{
			if (args.Length != 5)
			{
				throw new TargetParameterCountException();
			}
			return this.Invoke(target, args[0], args[1], args[2], args[3], args[4]);
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x000223A0 File Offset: 0x000205A0
		public override object Invoke(object target, object arg0, object arg1, object arg2, object arg3, object arg4)
		{
			if (OptimizedReflection.safeMode)
			{
				this.VerifyTarget(target);
				base.VerifyArgument<TParam0>(this.methodInfo, 0, arg0);
				base.VerifyArgument<TParam1>(this.methodInfo, 1, arg1);
				base.VerifyArgument<TParam2>(this.methodInfo, 2, arg2);
				base.VerifyArgument<TParam3>(this.methodInfo, 3, arg3);
				base.VerifyArgument<TParam4>(this.methodInfo, 4, arg4);
				try
				{
					return this.InvokeUnsafe(target, arg0, arg1, arg2, arg3, arg4);
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
			return this.InvokeUnsafe(target, arg0, arg1, arg2, arg3, arg4);
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x0002244C File Offset: 0x0002064C
		public object InvokeUnsafe(object target, object arg0, object arg1, object arg2, object arg3, object arg4)
		{
			return this.invoke((TParam0)((object)arg0), (TParam1)((object)arg1), (TParam2)((object)arg2), (TParam3)((object)arg3), (TParam4)((object)arg4));
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x00022480 File Offset: 0x00020680
		protected override Type[] GetParameterTypes()
		{
			return new Type[]
			{
				typeof(TParam0),
				typeof(TParam1),
				typeof(TParam2),
				typeof(TParam3),
				typeof(TParam4)
			};
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x000224D4 File Offset: 0x000206D4
		protected override void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions)
		{
			this.invoke = Expression.Lambda<Func<TParam0, TParam1, TParam2, TParam3, TParam4, TResult>>(callExpression, parameterExpressions).Compile();
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x000224E8 File Offset: 0x000206E8
		protected override void CreateDelegate()
		{
			this.invoke = ((TParam0 param0, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4) => ((Func<TParam0, TParam1, TParam2, TParam3, TParam4, TResult>)this.methodInfo.CreateDelegate(typeof(Func<TParam0, TParam1, TParam2, TParam3, TParam4, TResult>)))(param0, param1, param2, param3, param4));
		}

		// Token: 0x040001C4 RID: 452
		private Func<TParam0, TParam1, TParam2, TParam3, TParam4, TResult> invoke;
	}
}
