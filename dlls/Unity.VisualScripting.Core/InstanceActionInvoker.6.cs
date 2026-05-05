using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x02000102 RID: 258
	public sealed class InstanceActionInvoker<TTarget, TParam0, TParam1, TParam2, TParam3, TParam4> : InstanceActionInvokerBase<TTarget>
	{
		// Token: 0x060006A9 RID: 1705 RVA: 0x0001F36C File Offset: 0x0001D56C
		public InstanceActionInvoker(MethodInfo methodInfo) : base(methodInfo)
		{
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x0001F375 File Offset: 0x0001D575
		public override object Invoke(object target, params object[] args)
		{
			if (args.Length != 5)
			{
				throw new TargetParameterCountException();
			}
			return this.Invoke(target, args[0], args[1], args[2], args[3], args[4]);
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x0001F39C File Offset: 0x0001D59C
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

		// Token: 0x060006AC RID: 1708 RVA: 0x0001F448 File Offset: 0x0001D648
		public object InvokeUnsafe(object target, object arg0, object arg1, object arg2, object arg3, object arg4)
		{
			this.invoke((TTarget)((object)target), (TParam0)((object)arg0), (TParam1)((object)arg1), (TParam2)((object)arg2), (TParam3)((object)arg3), (TParam4)((object)arg4));
			return null;
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x0001F480 File Offset: 0x0001D680
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

		// Token: 0x060006AE RID: 1710 RVA: 0x0001F4D4 File Offset: 0x0001D6D4
		protected override void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions)
		{
			this.invoke = Expression.Lambda<Action<TTarget, TParam0, TParam1, TParam2, TParam3, TParam4>>(callExpression, parameterExpressions).Compile();
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x0001F4E8 File Offset: 0x0001D6E8
		protected override void CreateDelegate()
		{
			this.invoke = (Action<TTarget, TParam0, TParam1, TParam2, TParam3, TParam4>)this.methodInfo.CreateDelegate(typeof(Action<TTarget, TParam0, TParam1, TParam2, TParam3, TParam4>));
		}

		// Token: 0x0400019C RID: 412
		private Action<TTarget, TParam0, TParam1, TParam2, TParam3, TParam4> invoke;
	}
}
