using System;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x02000113 RID: 275
	public sealed class ReflectionPropertyAccessor : IOptimizedAccessor
	{
		// Token: 0x06000736 RID: 1846 RVA: 0x000212C8 File Offset: 0x0001F4C8
		public ReflectionPropertyAccessor(PropertyInfo propertyInfo)
		{
			if (OptimizedReflection.safeMode)
			{
				Ensure.That("propertyInfo").IsNotNull<PropertyInfo>(propertyInfo);
			}
			this.propertyInfo = propertyInfo;
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x000212EE File Offset: 0x0001F4EE
		public void Compile()
		{
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x000212F0 File Offset: 0x0001F4F0
		public object GetValue(object target)
		{
			return this.propertyInfo.GetValue(target, null);
		}

		// Token: 0x06000739 RID: 1849 RVA: 0x000212FF File Offset: 0x0001F4FF
		public void SetValue(object target, object value)
		{
			this.propertyInfo.SetValue(target, value, null);
		}

		// Token: 0x040001B4 RID: 436
		private readonly PropertyInfo propertyInfo;
	}
}
