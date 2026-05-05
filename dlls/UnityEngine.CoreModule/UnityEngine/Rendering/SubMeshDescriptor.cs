using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000406 RID: 1030
	public struct SubMeshDescriptor
	{
		// Token: 0x060021A9 RID: 8617 RVA: 0x00037FE0 File Offset: 0x000361E0
		public SubMeshDescriptor(int indexStart, int indexCount, MeshTopology topology = MeshTopology.Triangles)
		{
			this.indexStart = indexStart;
			this.indexCount = indexCount;
			this.topology = topology;
			this.bounds = default(Bounds);
			this.baseVertex = 0;
			this.firstVertex = 0;
			this.vertexCount = 0;
		}

		// Token: 0x17000658 RID: 1624
		// (get) Token: 0x060021AA RID: 8618 RVA: 0x0003802E File Offset: 0x0003622E
		// (set) Token: 0x060021AB RID: 8619 RVA: 0x00038036 File Offset: 0x00036236
		public Bounds bounds { readonly get; set; }

		// Token: 0x17000659 RID: 1625
		// (get) Token: 0x060021AC RID: 8620 RVA: 0x0003803F File Offset: 0x0003623F
		// (set) Token: 0x060021AD RID: 8621 RVA: 0x00038047 File Offset: 0x00036247
		public MeshTopology topology { readonly get; set; }

		// Token: 0x1700065A RID: 1626
		// (get) Token: 0x060021AE RID: 8622 RVA: 0x00038050 File Offset: 0x00036250
		// (set) Token: 0x060021AF RID: 8623 RVA: 0x00038058 File Offset: 0x00036258
		public int indexStart { readonly get; set; }

		// Token: 0x1700065B RID: 1627
		// (get) Token: 0x060021B0 RID: 8624 RVA: 0x00038061 File Offset: 0x00036261
		// (set) Token: 0x060021B1 RID: 8625 RVA: 0x00038069 File Offset: 0x00036269
		public int indexCount { readonly get; set; }

		// Token: 0x1700065C RID: 1628
		// (get) Token: 0x060021B2 RID: 8626 RVA: 0x00038072 File Offset: 0x00036272
		// (set) Token: 0x060021B3 RID: 8627 RVA: 0x0003807A File Offset: 0x0003627A
		public int baseVertex { readonly get; set; }

		// Token: 0x1700065D RID: 1629
		// (get) Token: 0x060021B4 RID: 8628 RVA: 0x00038083 File Offset: 0x00036283
		// (set) Token: 0x060021B5 RID: 8629 RVA: 0x0003808B File Offset: 0x0003628B
		public int firstVertex { readonly get; set; }

		// Token: 0x1700065E RID: 1630
		// (get) Token: 0x060021B6 RID: 8630 RVA: 0x00038094 File Offset: 0x00036294
		// (set) Token: 0x060021B7 RID: 8631 RVA: 0x0003809C File Offset: 0x0003629C
		public int vertexCount { readonly get; set; }

		// Token: 0x060021B8 RID: 8632 RVA: 0x000380A8 File Offset: 0x000362A8
		public override string ToString()
		{
			return string.Format("(topo={0} indices={1},{2} vertices={3},{4} basevtx={5} bounds={6})", new object[]
			{
				this.topology,
				this.indexStart,
				this.indexCount,
				this.firstVertex,
				this.vertexCount,
				this.baseVertex,
				this.bounds
			});
		}
	}
}
