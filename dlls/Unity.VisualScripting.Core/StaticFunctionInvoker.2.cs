using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x0200011E RID: 286
	public sealed class StaticFunctionInvoker<TParam0, TResult> : StaticFunctionInvokerBase<TResult>
	{
		// Token: 0x0600077C RID: 1916 RVA: 0x00021E82 File Offset: 0x00020082
		public StaticFunctionInvoker(MethodInfo methodInfo) : base(methodInfo)
		{
		}

		// Token: 0x0600077D RID: 1917 RVA: 0x00021E8B File Offset: 0x0002008B
		public override object Invoke(object target, params object[] args)
		{
			if (args.Length != 1)
			{
				throw new TargetParameterCountException();
			}
			return this.Invoke(target, args[0]);
		}

		// Token: 0x0600077E RID: 1918 RVA: 0x00021EA4 File Offset: 0x000200A4
		public override object Invoke(object target, object arg0)
		{
			if (OptimizedReflection.safeMode)
			{
				this.VerifyTarget(target);
				base.VerifyArgument<TParam0>(this.methodInfo, 0, arg0);
				try
				{
					return this.InvokeUnsafe(target, arg0);
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
			return this.InvokeUnsafe(target, arg0);
		}

		// Token: 0x0600077F RID: 1919 RVA: 0x00021F08 File Offset: 0x00020108
		public object InvokeUnsafe(object target, object arg0)
		{
			return this.invoke((TParam0)((object)arg0));
		}

		// Token: 0x06000780 RID: 1920 RVA: 0x00021F20 File Offset: 0x00020120
		protected override Type[] GetParameterTypes()
		{
			return new Type[]
			{
				typeof(TParam0)
			};
		}

		// Token: 0x06000781 RID: 1921 RVA: 0x00021F35 File Offset: 0x00020135
		protected override void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions)
		{
			this.invoke = Expression.Lambda<Func<TParam0, TResult>>(callExpression, parameterExpressions).Compile();
		}

		// Token: 0x06000782 RID: 1922 RVA: 0x00021F49 File Offset: 0x00020149
		protected override void CreateDelegate()
		{
			this.invoke = ((TParam0 param0) => ((Func<TParam0, TResult>)this.methodInfo.CreateDelegate(typeof(Func<TParam0, TResult>)))(param0));
		}

		// Token: 0x040001C0 RID: 448
		private Func<TParam0, TResult> invoke;
	}
}
