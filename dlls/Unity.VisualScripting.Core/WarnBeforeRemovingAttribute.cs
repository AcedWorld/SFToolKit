using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200004B RID: 75
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public sealed class WarnBeforeRemovingAttribute : Attribute
	{
		// Token: 0x060001F4 RID: 500 RVA: 0x00005007 File Offset: 0x00003207
		public WarnBeforeRemovingAttribute(string warningTitle, string warningMessage)
		{
			this.warningTitle = warningTitle;
			this.warningMessage = warningMessage;
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060001F5 RID: 501 RVA: 0x0000501D File Offset: 0x0000321D
		public string warningTitle { get; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060001F6 RID: 502 RVA: 0x00005025 File Offset: 0x00003225
		public string warningMessage { get; }
	}
}
