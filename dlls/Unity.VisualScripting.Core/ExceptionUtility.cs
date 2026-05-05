using System;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x02000155 RID: 341
	public static class ExceptionUtility
	{
		// Token: 0x06000921 RID: 2337 RVA: 0x00027B9C File Offset: 0x00025D9C
		public static Exception Relevant(this Exception ex)
		{
			if (ex is TargetInvocationException)
			{
				return ex.InnerException;
			}
			return ex;
		}
	}
}
