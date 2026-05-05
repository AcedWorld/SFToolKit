using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x02000119 RID: 281
	public sealed class StaticActionInvoker<TParam0, TParam1, TParam2, TParam3> : StaticActionInvokerBase
	{
		// Token: 0x0600075B RID: 1883 RVA: 0x0002174C File Offset: 0x0001F94C
		public StaticActionInvoker(MethodInfo methodInfo) : base(methodInfo)
		{
		}

		// Token: 0x0600075C RID: 1884 RVA: 0x00021755 File Offset: 0x0001F955
		public override object Invoke(object target, params object[] args)
		{
			if (args.Length != 4)
			{
				throw new TargetParameterCountException();
			}
			return this.Invoke(target, args[0], args[1], args[2], args[3]);
		}

		// Token: 0x0600075D RID: 1885 RVA: 0x00021778 File Offset: 0x0001F978
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

		// Token: 0x0600075E RID: 1886 RVA: 0x00021814 File Offset: 0x0001FA14
		public object InvokeUnsafe(object target, object arg0, object arg1, object arg2, object arg3)
		{
			this.invoke((TParam0)((object)arg0), (TParam1)((object)arg1), (TParam2)((object)arg2), (TParam3)((object)arg3));
			return null;
		}

		// Token: 0x0600075F RID: 1887 RVA: 0x0002183C File Offset: 0x0001FA3C
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

		// Token: 0x06000760 RID: 1888 RVA: 0x00021878 File Offset: 0x0001FA78
		protected override void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions)
		{
			this.invoke = Expression.Lambda<Action<TParam0, TParam1, TParam2, TParam3>>(callExpression, parameterExpressions).Compile();
		}

		// Token: 0x06000761 RID: 1889 RVA: 0x0002188C File Offset: 0x0001FA8C
		protected override void CreateDelegate()
		{
			this.invoke = delegate(TParam0 param0, TParam1 param1, TParam2 param2, TParam3 param3)
			{
				((Action<TParam0, TParam1, TParam2, TParam3>)this.methodInfo.CreateDelegate(typeof(Action<TParam0, TParam1, TParam2, TParam3>)))(param0, param1, param2, param3);
			};
		}

		// Token: 0x040001B9 RID: 441
		private Action<TParam0, TParam1, TParam2, TParam3> invoke;
	}
}
