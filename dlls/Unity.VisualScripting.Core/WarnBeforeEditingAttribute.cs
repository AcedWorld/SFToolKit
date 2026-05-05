using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200004A RID: 74
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public sealed class WarnBeforeEditingAttribute : Attribute
	{
		// Token: 0x060001EF RID: 495 RVA: 0x00004FC8 File Offset: 0x000031C8
		public WarnBeforeEditingAttribute(string warningTitle, string warningMessage)
		{
			this.warningTitle = warningTitle;
			this.warningMessage = warningMessage;
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x00004FDE File Offset: 0x000031DE
		public WarnBeforeEditingAttribute(string warningTitle, string warningMessage, params object[] emptyValues) : this(warningTitle, warningMessage)
		{
			this.emptyValues = emptyValues;
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060001F1 RID: 497 RVA: 0x00004FEF File Offset: 0x000031EF
		public string warningTitle { get; }

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060001F2 RID: 498 RVA: 0x00004FF7 File Offset: 0x000031F7
		public string warningMessage { get; }

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060001F3 RID: 499 RVA: 0x00004FFF File Offset: 0x000031FF
		public object[] emptyValues { get; }
	}
}
