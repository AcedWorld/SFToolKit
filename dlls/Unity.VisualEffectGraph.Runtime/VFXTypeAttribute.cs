using System;

namespace UnityEngine.VFX
{
	// Token: 0x0200000A RID: 10
	[AttributeUsage(AttributeTargets.Struct, AllowMultiple = false)]
	public class VFXTypeAttribute : Attribute
	{
		// Token: 0x06000021 RID: 33 RVA: 0x00002547 File Offset: 0x00000747
		public VFXTypeAttribute(VFXTypeAttribute.Usage usages = VFXTypeAttribute.Usage.Default, string name = null)
		{
			this.usages = usages;
			this.name = name;
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000022 RID: 34 RVA: 0x0000255D File Offset: 0x0000075D
		// (set) Token: 0x06000023 RID: 35 RVA: 0x00002565 File Offset: 0x00000765
		internal VFXTypeAttribute.Usage usages { get; private set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000024 RID: 36 RVA: 0x0000256E File Offset: 0x0000076E
		// (set) Token: 0x06000025 RID: 37 RVA: 0x00002576 File Offset: 0x00000776
		internal string name { get; private set; }

		// Token: 0x02000048 RID: 72
		[Flags]
		public enum Usage
		{
			// Token: 0x04000130 RID: 304
			Default = 1,
			// Token: 0x04000131 RID: 305
			GraphicsBuffer = 2,
			// Token: 0x04000132 RID: 306
			ExcludeFromProperty = 4
		}
	}
}
