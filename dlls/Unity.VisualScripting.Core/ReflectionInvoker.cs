using System;
using System.Linq;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x02000112 RID: 274
	public class ReflectionInvoker : IOptimizedInvoker
	{
		// Token: 0x0600072B RID: 1835 RVA: 0x00021195 File Offset: 0x0001F395
		public ReflectionInvoker(MethodInfo methodInfo)
		{
			if (OptimizedReflection.safeMode)
			{
				Ensure.That("methodInfo").IsNotNull<MethodInfo>(methodInfo);
			}
			this.methodInfo = methodInfo;
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x000211BB File Offset: 0x0001F3BB
		public void Compile()
		{
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x000211BD File Offset: 0x0001F3BD
		public object Invoke(object target, params object[] args)
		{
			return this.methodInfo.Invoke(target, args);
		}

		// Token: 0x0600072E RID: 1838 RVA: 0x000211CC File Offset: 0x0001F3CC
		public object Invoke(object target)
		{
			return this.methodInfo.Invoke(target, ReflectionInvoker.EmptyObjects);
		}

		// Token: 0x0600072F RID: 1839 RVA: 0x000211DF File Offset: 0x0001F3DF
		public object Invoke(object target, object arg0)
		{
			return this.methodInfo.Invoke(target, new object[]
			{
				arg0
			});
		}

		// Token: 0x06000730 RID: 1840 RVA: 0x000211F7 File Offset: 0x0001F3F7
		public object Invoke(object target, object arg0, object arg1)
		{
			return this.methodInfo.Invoke(target, new object[]
			{
				arg0,
				arg1
			});
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x00021213 File Offset: 0x0001F413
		public object Invoke(object target, object arg0, object arg1, object arg2)
		{
			return this.methodInfo.Invoke(target, new object[]
			{
				arg0,
				arg1,
				arg2
			});
		}

		// Token: 0x06000732 RID: 1842 RVA: 0x00021234 File Offset: 0x0001F434
		public object Invoke(object target, object arg0, object arg1, object arg2, object arg3)
		{
			return this.methodInfo.Invoke(target, new object[]
			{
				arg0,
				arg1,
				arg2,
				arg3
			});
		}

		// Token: 0x06000733 RID: 1843 RVA: 0x0002125A File Offset: 0x0001F45A
		public object Invoke(object target, object arg0, object arg1, object arg2, object arg3, object arg4)
		{
			return this.methodInfo.Invoke(target, new object[]
			{
				arg0,
				arg1,
				arg2,
				arg3,
				arg4
			});
		}

		// Token: 0x06000734 RID: 1844 RVA: 0x00021285 File Offset: 0x0001F485
		public Type[] GetParameterTypes()
		{
			return (from pi in this.methodInfo.GetParameters()
			select pi.ParameterType).ToArray<Type>();
		}

		// Token: 0x040001B2 RID: 434
		private readonly MethodInfo methodInfo;

		// Token: 0x040001B3 RID: 435
		private static readonly object[] EmptyObjects = new object[0];
	}
}
