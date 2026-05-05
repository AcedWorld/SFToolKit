using System;
using System.Linq;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x020000D8 RID: 216
	internal class ExtensionMethodCache
	{
		// Token: 0x0600060E RID: 1550 RVA: 0x0000F9F4 File Offset: 0x0000DBF4
		internal ExtensionMethodCache()
		{
			this.Cache = (from method in (from type in RuntimeCodebase.types
			where type.IsStatic() && !type.IsGenericType && !type.IsNested
			select type).SelectMany((Type type) => type.GetMethods())
			where method.IsExtension()
			select method).ToArray<MethodInfo>();
		}

		// Token: 0x04000154 RID: 340
		internal readonly MethodInfo[] Cache;
	}
}
