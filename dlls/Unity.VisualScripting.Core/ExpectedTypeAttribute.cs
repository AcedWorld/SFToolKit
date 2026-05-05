using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000035 RID: 53
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public sealed class ExpectedTypeAttribute : Attribute
	{
		// Token: 0x060001B7 RID: 439 RVA: 0x00004D5C File Offset: 0x00002F5C
		public ExpectedTypeAttribute(Type type)
		{
			Ensure.That("type").IsNotNull<Type>(type);
			this.type = type;
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060001B8 RID: 440 RVA: 0x00004D7B File Offset: 0x00002F7B
		public Type type { get; }
	}
}
