using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000046 RID: 70
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
	public sealed class TypeIconAttribute : Attribute
	{
		// Token: 0x060001E8 RID: 488 RVA: 0x00004F64 File Offset: 0x00003164
		public TypeIconAttribute(Type type)
		{
			Ensure.That("type").IsNotNull<Type>(type);
			this.type = type;
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060001E9 RID: 489 RVA: 0x00004F83 File Offset: 0x00003183
		public Type type { get; }
	}
}
