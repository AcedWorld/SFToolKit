using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x02000115 RID: 277
	public sealed class StaticActionInvoker : StaticActionInvokerBase
	{
		// Token: 0x0600073B RID: 1851 RVA: 0x00021318 File Offset: 0x0001F518
		public StaticActionInvoker(MethodInfo methodInfo) : base(methodInfo)
		{
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x00021321 File Offset: 0x0001F521
		public override object Invoke(object target, params object[] args)
		{
			if (args.Length != 0)
			{
				throw new TargetParameterCountException();
			}
			return this.Invoke(target);
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x00021334 File Offset: 0x0001F534
		public override object Invoke(object target)
		{
			if (OptimizedReflection.safeMode)
			{
				this.VerifyTarget(target);
				try
				{
					return this.InvokeUnsafe(target);
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
			return this.InvokeUnsafe(target);
		}

		// Token: 0x0600073E RID: 1854 RVA: 0x00021388 File Offset: 0x0001F588
		private object InvokeUnsafe(object target)
		{
			this.invoke();
			return null;
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x00021396 File Offset: 0x0001F596
		protected override Type[] GetParameterTypes()
		{
			return Type.EmptyTypes;
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x0002139D File Offset: 0x0001F59D
		protected override void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions)
		{
			this.invoke = Expression.Lambda<Action>(callExpression, parameterExpressions).Compile();
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x000213B1 File Offset: 0x0001F5B1
		protected override void CreateDelegate()
		{
			this.invoke = delegate()
			{
				((Action)this.methodInfo.CreateDelegate(typeof(Action)))();
			};
		}

		// Token: 0x040001B5 RID: 437
		private Action invoke;
	}
}
