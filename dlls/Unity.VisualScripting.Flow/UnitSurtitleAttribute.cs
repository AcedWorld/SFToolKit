using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000015 RID: 21
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public sealed class UnitSurtitleAttribute : Attribute
	{
		// Token: 0x0600006B RID: 107 RVA: 0x00002915 File Offset: 0x00000B15
		public UnitSurtitleAttribute(string surtitle)
		{
			this.surtitle = surtitle;
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00002924 File Offset: 0x00000B24
		// (set) Token: 0x0600006D RID: 109 RVA: 0x0000292C File Offset: 0x00000B2C
		public string surtitle { get; private set; }
	}
}
