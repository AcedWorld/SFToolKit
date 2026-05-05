using System;

namespace UnityEngine.Rendering
{
	// Token: 0x020000DE RID: 222
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class ReloadAttribute : Attribute
	{
		// Token: 0x06000778 RID: 1912 RVA: 0x00024753 File Offset: 0x00022953
		public ReloadAttribute(string[] paths, ReloadAttribute.Package package = ReloadAttribute.Package.Root)
		{
		}

		// Token: 0x06000779 RID: 1913 RVA: 0x0002475B File Offset: 0x0002295B
		public ReloadAttribute(string path, ReloadAttribute.Package package = ReloadAttribute.Package.Root) : this(new string[]
		{
			path
		}, package)
		{
		}

		// Token: 0x0600077A RID: 1914 RVA: 0x0002476E File Offset: 0x0002296E
		public ReloadAttribute(string pathFormat, int rangeMin, int rangeMax, ReloadAttribute.Package package = ReloadAttribute.Package.Root)
		{
		}

		// Token: 0x020001D5 RID: 469
		public enum Package
		{
			// Token: 0x040007A0 RID: 1952
			Builtin,
			// Token: 0x040007A1 RID: 1953
			Root,
			// Token: 0x040007A2 RID: 1954
			BuiltinExtra
		}
	}
}
