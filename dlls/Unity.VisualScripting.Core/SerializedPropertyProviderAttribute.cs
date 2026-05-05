using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000142 RID: 322
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public sealed class SerializedPropertyProviderAttribute : Attribute, IDecoratorAttribute
	{
		// Token: 0x060008AD RID: 2221 RVA: 0x00026438 File Offset: 0x00024638
		public SerializedPropertyProviderAttribute(Type type)
		{
			this.type = type;
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x060008AE RID: 2222 RVA: 0x00026447 File Offset: 0x00024647
		// (set) Token: 0x060008AF RID: 2223 RVA: 0x0002644F File Offset: 0x0002464F
		public Type type { get; private set; }
	}
}
