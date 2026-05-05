using System;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x020001C9 RID: 457
	[UsedByNativeCode]
	[Serializable]
	internal struct BlendShape
	{
		// Token: 0x17000390 RID: 912
		// (get) Token: 0x060011E4 RID: 4580 RVA: 0x00018DA8 File Offset: 0x00016FA8
		// (set) Token: 0x060011E5 RID: 4581 RVA: 0x00018DC0 File Offset: 0x00016FC0
		public uint firstVertex
		{
			get
			{
				return this.m_FirstVertex;
			}
			set
			{
				this.m_FirstVertex = value;
			}
		}

		// Token: 0x17000391 RID: 913
		// (get) Token: 0x060011E6 RID: 4582 RVA: 0x00018DCC File Offset: 0x00016FCC
		// (set) Token: 0x060011E7 RID: 4583 RVA: 0x00018DE4 File Offset: 0x00016FE4
		public uint vertexCount
		{
			get
			{
				return this.m_VertexCount;
			}
			set
			{
				this.m_VertexCount = value;
			}
		}

		// Token: 0x17000392 RID: 914
		// (get) Token: 0x060011E8 RID: 4584 RVA: 0x00018DF0 File Offset: 0x00016FF0
		// (set) Token: 0x060011E9 RID: 4585 RVA: 0x00018E08 File Offset: 0x00017008
		public bool hasNormals
		{
			get
			{
				return this.m_HasNormals;
			}
			set
			{
				this.m_HasNormals = value;
			}
		}

		// Token: 0x17000393 RID: 915
		// (get) Token: 0x060011EA RID: 4586 RVA: 0x00018E14 File Offset: 0x00017014
		// (set) Token: 0x060011EB RID: 4587 RVA: 0x00018E2C File Offset: 0x0001702C
		public bool hasTangents
		{
			get
			{
				return this.m_HasTangents;
			}
			set
			{
				this.m_HasTangents = value;
			}
		}

		// Token: 0x0400063F RID: 1599
		[SerializeField]
		private uint m_FirstVertex;

		// Token: 0x04000640 RID: 1600
		[SerializeField]
		private uint m_VertexCount;

		// Token: 0x04000641 RID: 1601
		[SerializeField]
		private bool m_HasNormals;

		// Token: 0x04000642 RID: 1602
		[SerializeField]
		private bool m_HasTangents;
	}
}
