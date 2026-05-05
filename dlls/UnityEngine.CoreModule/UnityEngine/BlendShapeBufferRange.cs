using System;

namespace UnityEngine
{
	// Token: 0x020001CA RID: 458
	[Serializable]
	public struct BlendShapeBufferRange
	{
		// Token: 0x17000394 RID: 916
		// (get) Token: 0x060011EC RID: 4588 RVA: 0x00018E38 File Offset: 0x00017038
		// (set) Token: 0x060011ED RID: 4589 RVA: 0x00018E50 File Offset: 0x00017050
		public uint startIndex
		{
			get
			{
				return this.m_StartIndex;
			}
			internal set
			{
				this.m_StartIndex = value;
			}
		}

		// Token: 0x17000395 RID: 917
		// (get) Token: 0x060011EE RID: 4590 RVA: 0x00018E5C File Offset: 0x0001705C
		// (set) Token: 0x060011EF RID: 4591 RVA: 0x00018E74 File Offset: 0x00017074
		public uint endIndex
		{
			get
			{
				return this.m_EndIndex;
			}
			internal set
			{
				this.m_EndIndex = value;
			}
		}

		// Token: 0x04000643 RID: 1603
		[SerializeField]
		private uint m_StartIndex;

		// Token: 0x04000644 RID: 1604
		[SerializeField]
		private uint m_EndIndex;
	}
}
