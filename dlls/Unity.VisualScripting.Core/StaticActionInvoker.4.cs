using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x02000118 RID: 280
	public sealed class StaticActionInvoker<TParam0, TParam1, TParam2> : StaticActionInvokerBase
	{
		// Token: 0x06000753 RID: 1875 RVA: 0x000215FF File Offset: 0x0001F7FF
		public StaticActionInvoker(MethodInfo methodInfo) : base(methodInfo)
		{
		}

		// Token: 0x06000754 RID: 1876 RVA: 0x00021608 File Offset: 0x0001F808
		public override object Invoke(object target, params object[] args)
		{
			if (args.Length != 3)
			{
				throw new TargetParameterCountException();
			}
			return this.Invoke(target, args[0], args[1], args[2]);
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x00021628 File Offset: 0x0001F828
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

		// Token: 0x06000756 RID: 1878 RVA: 0x000216B0 File Offset: 0x0001F8B0
		public object InvokeUnsafe(object target, object arg0, object arg1, object arg2)
		{
			this.invoke((TParam0)((object)arg0), (TParam1)((object)arg1), (TParam2)((object)arg2));
			return null;
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x000216D1 File Offset: 0x0001F8D1
		protected override Type[] GetParameterTypes()
		{
			return new Type[]
			{
				typeof(TParam0),
				typeof(TParam1),
				typeof(TParam2)
			};
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x00021700 File Offset: 0x0001F900
		protected override void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions)
		{
			this.invoke = Expression.Lambda<Action<TParam0, TParam1, TParam2>>(callExpression, parameterExpressions).Compile();
		}

		// Token: 0x06000759 RID: 1881 RVA: 0x00021714 File Offset: 0x0001F914
		protected override void CreateDelegate()
		{
			this.invoke = delegate(TParam0 param0, TParam1 param1, TParam2 param2)
			{
				((Action<TParam0, TParam1, TParam2>)this.methodInfo.CreateDelegate(typeof(Action<TParam0, TParam1, TParam2>)))(param0, param1, param2);
			};
		}

		// Token: 0x040001B8 RID: 440
		private Action<TParam0, TParam1, TParam2> invoke;
	}
}
