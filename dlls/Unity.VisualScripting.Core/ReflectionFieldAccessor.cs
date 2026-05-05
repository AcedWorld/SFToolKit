using System;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x02000111 RID: 273
	public sealed class ReflectionFieldAccessor : IOptimizedAccessor
	{
		// Token: 0x06000727 RID: 1831 RVA: 0x00021150 File Offset: 0x0001F350
		public ReflectionFieldAccessor(FieldInfo fieldInfo)
		{
			if (OptimizedReflection.safeMode)
			{
				Ensure.That("fieldInfo").IsNotNull<FieldInfo>(fieldInfo);
			}
			this.fieldInfo = fieldInfo;
		}

		// Token: 0x06000728 RID: 1832 RVA: 0x00021176 File Offset: 0x0001F376
		public void Compile()
		{
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x00021178 File Offset: 0x0001F378
		public object GetValue(object target)
		{
			return this.fieldInfo.GetValue(target);
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x00021186 File Offset: 0x0001F386
		public void SetValue(object target, object value)
		{
			this.fieldInfo.SetValue(target, value);
		}

		// Token: 0x040001B1 RID: 433
		private readonly FieldInfo fieldInfo;
	}
}
