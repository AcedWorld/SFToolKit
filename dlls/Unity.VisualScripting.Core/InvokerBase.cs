using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x0200010D RID: 269
	public abstract class InvokerBase : IOptimizedInvoker
	{
		// Token: 0x060006ED RID: 1773 RVA: 0x00020395 File Offset: 0x0001E595
		protected InvokerBase(MethodInfo methodInfo)
		{
			if (OptimizedReflection.safeMode && methodInfo == null)
			{
				throw new ArgumentNullException("methodInfo");
			}
			this.methodInfo = methodInfo;
			this.targetType = methodInfo.DeclaringType;
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x000203CC File Offset: 0x0001E5CC
		protected void VerifyArgument<TParam>(MethodInfo methodInfo, int argIndex, object arg)
		{
			if (!typeof(TParam).IsAssignableFrom(arg))
			{
				throw new ArgumentException(string.Format("The provided argument value for '{0}.{1}' does not match the parameter type.\nProvided: {2}\nExpected: {3}", new object[]
				{
					this.targetType,
					methodInfo.Name,
					((arg != null) ? arg.GetType().ToString() : null) ?? "null",
					typeof(TParam)
				}), methodInfo.GetParameters()[argIndex].Name);
			}
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x0002044A File Offset: 0x0001E64A
		public void Compile()
		{
			if (OptimizedReflection.useJit)
			{
				this.CompileExpression();
				return;
			}
			this.CreateDelegate();
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x00020460 File Offset: 0x0001E660
		protected ParameterExpression[] GetParameterExpressions()
		{
			ParameterInfo[] parameters = this.methodInfo.GetParameters();
			Type[] parameterTypes = this.GetParameterTypes();
			if (parameters.Length != parameterTypes.Length)
			{
				throw new ArgumentException("Parameter count of method info doesn't match generic argument count.", "methodInfo");
			}
			for (int i = 0; i < parameterTypes.Length; i++)
			{
				if (parameterTypes[i] != parameters[i].ParameterType)
				{
					throw new ArgumentException("Parameter type of method info doesn't match generic argument.", "methodInfo");
				}
			}
			ParameterExpression[] array = new ParameterExpression[parameterTypes.Length];
			for (int j = 0; j < parameterTypes.Length; j++)
			{
				array[j] = Expression.Parameter(parameterTypes[j], "parameter" + j.ToString());
			}
			return array;
		}

		// Token: 0x060006F1 RID: 1777
		protected abstract Type[] GetParameterTypes();

		// Token: 0x060006F2 RID: 1778
		public abstract object Invoke(object target, params object[] args);

		// Token: 0x060006F3 RID: 1779 RVA: 0x00020502 File Offset: 0x0001E702
		public virtual object Invoke(object target)
		{
			throw new TargetParameterCountException();
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x00020509 File Offset: 0x0001E709
		public virtual object Invoke(object target, object arg0)
		{
			throw new TargetParameterCountException();
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x00020510 File Offset: 0x0001E710
		public virtual object Invoke(object target, object arg0, object arg1)
		{
			throw new TargetParameterCountException();
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x00020517 File Offset: 0x0001E717
		public virtual object Invoke(object target, object arg0, object arg1, object arg2)
		{
			throw new TargetParameterCountException();
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x0002051E File Offset: 0x0001E71E
		public virtual object Invoke(object target, object arg0, object arg1, object arg2, object arg3)
		{
			throw new TargetParameterCountException();
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x00020525 File Offset: 0x0001E725
		public virtual object Invoke(object target, object arg0, object arg1, object arg2, object arg3, object arg4)
		{
			throw new TargetParameterCountException();
		}

		// Token: 0x060006F9 RID: 1785
		protected abstract void CompileExpression();

		// Token: 0x060006FA RID: 1786
		protected abstract void CreateDelegate();

		// Token: 0x060006FB RID: 1787
		protected abstract void VerifyTarget(object target);

		// Token: 0x040001A9 RID: 425
		protected readonly Type targetType;

		// Token: 0x040001AA RID: 426
		protected readonly MethodInfo methodInfo;
	}
}
