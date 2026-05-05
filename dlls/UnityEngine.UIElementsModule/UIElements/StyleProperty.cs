using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200034F RID: 847
	[Serializable]
	internal class StyleProperty
	{
		// Token: 0x170006A1 RID: 1697
		// (get) Token: 0x06001C6E RID: 7278 RVA: 0x0006E918 File Offset: 0x0006CB18
		// (set) Token: 0x06001C6F RID: 7279 RVA: 0x0006E930 File Offset: 0x0006CB30
		public string name
		{
			get
			{
				return this.m_Name;
			}
			internal set
			{
				this.m_Name = value;
			}
		}

		// Token: 0x170006A2 RID: 1698
		// (get) Token: 0x06001C70 RID: 7280 RVA: 0x0006E93C File Offset: 0x0006CB3C
		// (set) Token: 0x06001C71 RID: 7281 RVA: 0x0006E954 File Offset: 0x0006CB54
		public int line
		{
			get
			{
				return this.m_Line;
			}
			internal set
			{
				this.m_Line = value;
			}
		}

		// Token: 0x170006A3 RID: 1699
		// (get) Token: 0x06001C72 RID: 7282 RVA: 0x0006E960 File Offset: 0x0006CB60
		// (set) Token: 0x06001C73 RID: 7283 RVA: 0x0006E978 File Offset: 0x0006CB78
		public StyleValueHandle[] values
		{
			get
			{
				return this.m_Values;
			}
			internal set
			{
				this.m_Values = value;
			}
		}

		// Token: 0x04000BBE RID: 3006
		[SerializeField]
		private string m_Name;

		// Token: 0x04000BBF RID: 3007
		[SerializeField]
		private int m_Line;

		// Token: 0x04000BC0 RID: 3008
		[SerializeField]
		private StyleValueHandle[] m_Values;

		// Token: 0x04000BC1 RID: 3009
		[NonSerialized]
		internal bool isCustomProperty;

		// Token: 0x04000BC2 RID: 3010
		[NonSerialized]
		internal bool requireVariableResolve;
	}
}
