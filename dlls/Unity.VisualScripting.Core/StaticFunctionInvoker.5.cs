using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x02000121 RID: 289
	public sealed class StaticFunctionInvoker<TParam0, TParam1, TParam2, TParam3, TResult> : StaticFunctionInvokerBase<TResult>
	{
		// Token: 0x06000794 RID: 1940 RVA: 0x000221F4 File Offset: 0x000203F4
		public StaticFunctionInvoker(MethodInfo methodInfo) : base(methodInfo)
		{
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x000221FD File Offset: 0x000203FD
		public override object Invoke(object target, params object[] args)
		{
			if (args.Length != 4)
			{
				throw new TargetParameterCountException();
			}
			return this.Invoke(target, args[0], args[1], args[2], args[3]);
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x00022220 File Offset: 0x00020420
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

		// Token: 0x06000797 RID: 1943 RVA: 0x000222BC File Offset: 0x000204BC
		public object InvokeUnsafe(object target, object arg0, object arg1, object arg2, object arg3)
		{
			return this.invoke((TParam0)((object)arg0), (TParam1)((object)arg1), (TParam2)((object)arg2), (TParam3)((object)arg3));
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x000222E8 File Offset: 0x000204E8
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

		// Token: 0x06000799 RID: 1945 RVA: 0x00022324 File Offset: 0x00020524
		protected override void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions)
		{
			this.invoke = Expression.Lambda<Func<TParam0, TParam1, TParam2, TParam3, TResult>>(callExpression, parameterExpressions).Compile();
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x00022338 File Offset: 0x00020538
		protected override void CreateDelegate()
		{
			this.invoke = ((TParam0 param0, TParam1 param1, TParam2 param2, TParam3 param3) => ((Func<TParam0, TParam1, TParam2, TParam3, TResult>)this.methodInfo.CreateDelegate(typeof(Func<TParam0, TParam1, TParam2, TParam3, TResult>)))(param0, param1, param2, param3));
		}

		// Token: 0x040001C3 RID: 451
		private Func<TParam0, TParam1, TParam2, TParam3, TResult> invoke;
	}
}
