using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x02000109 RID: 265
	public sealed class InstanceFunctionInvoker<TTarget, TParam0, TParam1, TParam2, TParam3, TResult> : InstanceFunctionInvokerBase<TTarget, TResult>
	{
		// Token: 0x060006D5 RID: 1749 RVA: 0x0001FC9C File Offset: 0x0001DE9C
		public InstanceFunctionInvoker(MethodInfo methodInfo) : base(methodInfo)
		{
		}

		// Token: 0x060006D6 RID: 1750 RVA: 0x0001FCA5 File Offset: 0x0001DEA5
		public override object Invoke(object target, params object[] args)
		{
			if (args.Length != 4)
			{
				throw new TargetParameterCountException();
			}
			return this.Invoke(target, args[0], args[1], args[2], args[3]);
		}

		// Token: 0x060006D7 RID: 1751 RVA: 0x0001FCC8 File Offset: 0x0001DEC8
		public override object Invoke(object target, object arg0, object arg1, object arg2, object arg3)
		{
			if (OptimizedReflection.safeMode)
			{
				this.VerifyTarget(target);
				base.VerifyArgument<TParam0>(this.methodInfo, 0, arg0);
				base.VerifyArgument<TParam1>(this.methodInfo, 1, arg1);
				base.VerifyArgument<TParam2>(this.methodInfo, 2, arg2);
				base.VerifyArgument<TParam3>(this.methodInfo, 3, arg3);
				try
				{
					return this.InvokeUnsafe(target, arg0, arg1, arg2, arg3);
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
			return this.InvokeUnsafe(target, arg0, arg1, arg2, arg3);
		}

		// Token: 0x060006D8 RID: 1752 RVA: 0x0001FD64 File Offset: 0x0001DF64
		public object InvokeUnsafe(object target, object arg0, object arg1, object arg2, object arg3)
		{
			return this.invoke((TTarget)((object)target), (TParam0)((object)arg0), (TParam1)((object)arg1), (TParam2)((object)arg2), (TParam3)((object)arg3));
		}

		// Token: 0x060006D9 RID: 1753 RVA: 0x0001FD96 File Offset: 0x0001DF96
		protected override Type[] GetParameterTypes()
		{
			return new Type[]
			{
				typeof(TParam0),
				typeof(TParam1),
				typeof(TParam2),
				typeof(TParam3)
			};
		}

		// Token: 0x060006DA RID: 1754 RVA: 0x0001FDD2 File Offset: 0x0001DFD2
		protected override void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions)
		{
			this.invoke = Expression.Lambda<Func<TTarget, TParam0, TParam1, TParam2, TParam3, TResult>>(callExpression, parameterExpressions).Compile();
		}

		// Token: 0x060006DB RID: 1755 RVA: 0x0001FDE6 File Offset: 0x0001DFE6
		protected override void CreateDelegate()
		{
			this.invoke = (Func<TTarget, TParam0, TParam1, TParam2, TParam3, TResult>)this.methodInfo.CreateDelegate(typeof(Func<TTarget, TParam0, TParam1, TParam2, TParam3, TResult>));
		}

		// Token: 0x040001A4 RID: 420
		private Func<TTarget, TParam0, TParam1, TParam2, TParam3, TResult> invoke;
	}
}
