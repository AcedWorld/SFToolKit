using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x02000117 RID: 279
	public sealed class StaticActionInvoker<TParam0, TParam1> : StaticActionInvokerBase
	{
		// Token: 0x0600074B RID: 1867 RVA: 0x000214DF File Offset: 0x0001F6DF
		public StaticActionInvoker(MethodInfo methodInfo) : base(methodInfo)
		{
		}

		// Token: 0x0600074C RID: 1868 RVA: 0x000214E8 File Offset: 0x0001F6E8
		public override object Invoke(object target, params object[] args)
		{
			if (args.Length != 2)
			{
				throw new TargetParameterCountException();
			}
			return this.Invoke(target, args[0], args[1]);
		}

		// Token: 0x0600074D RID: 1869 RVA: 0x00021504 File Offset: 0x0001F704
		public override object Invoke(object target, object arg0, object arg1)
		{
			if (OptimizedReflection.safeMode)
			{
				this.VerifyTarget(target);
				base.VerifyArgument<TParam0>(this.methodInfo, 0, arg0);
				base.VerifyArgument<TParam1>(this.methodInfo, 0, arg1);
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

		// Token: 0x0600074E RID: 1870 RVA: 0x00021578 File Offset: 0x0001F778
		public object InvokeUnsafe(object target, object arg0, object arg1)
		{
			this.invoke((TParam0)((object)arg0), (TParam1)((object)arg1));
			return null;
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x00021592 File Offset: 0x0001F792
		protected override Type[] GetParameterTypes()
		{
			return new Type[]
			{
				typeof(TParam0),
				typeof(TParam1)
			};
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x000215B4 File Offset: 0x0001F7B4
		protected override void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions)
		{
			this.invoke = Expression.Lambda<Action<TParam0, TParam1>>(callExpression, parameterExpressions).Compile();
		}

		// Token: 0x06000751 RID: 1873 RVA: 0x000215C8 File Offset: 0x0001F7C8
		protected override void CreateDelegate()
		{
			this.invoke = delegate(TParam0 param0, TParam1 param1)
			{
				((Action<TParam0, TParam1>)this.methodInfo.CreateDelegate(typeof(Action<TParam0, TParam1>)))(param0, param1);
			};
		}

		// Token: 0x040001B7 RID: 439
		private Action<TParam0, TParam1> invoke;
	}
}
