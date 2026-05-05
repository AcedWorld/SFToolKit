using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000350 RID: 848
	[Serializable]
	internal class StyleRule
	{
		// Token: 0x170006A4 RID: 1700
		// (get) Token: 0x06001C75 RID: 7285 RVA: 0x0006E984 File Offset: 0x0006CB84
		// (set) Token: 0x06001C76 RID: 7286 RVA: 0x0006E99C File Offset: 0x0006CB9C
		public StyleProperty[] properties
		{
			get
			{
				return this.m_Properties;
			}
			internal set
			{
				this.m_Properties = value;
			}
		}

		// Token: 0x04000BC3 RID: 3011
		[SerializeField]
		private StyleProperty[] m_Properties;

		// Token: 0x04000BC4 RID: 3012
		[SerializeField]
		internal int line;

		// Token: 0x04000BC5 RID: 3013
		[NonSerialized]
		internal int customPropertiesCount;
	}
}
