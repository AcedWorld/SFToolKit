using System;
using System.Runtime.CompilerServices;
using Unity.Collections;

namespace UnityEngine.UIElements
{
	// Token: 0x020002AB RID: 683
	public class MeshWriteData
	{
		// Token: 0x060013A0 RID: 5024 RVA: 0x00044C8F File Offset: 0x00042E8F
		internal MeshWriteData()
		{
		}

		// Token: 0x17000424 RID: 1060
		// (get) Token: 0x060013A1 RID: 5025 RVA: 0x00044C9C File Offset: 0x00042E9C
		public int vertexCount
		{
			get
			{
				return this.m_Vertices.Length;
			}
		}

		// Token: 0x17000425 RID: 1061
		// (get) Token: 0x060013A2 RID: 5026 RVA: 0x00044CBC File Offset: 0x00042EBC
		public int indexCount
		{
			get
			{
				return this.m_Indices.Length;
			}
		}

		// Token: 0x17000426 RID: 1062
		// (get) Token: 0x060013A3 RID: 5027 RVA: 0x00044CDC File Offset: 0x00042EDC
		public Rect uvRegion
		{
			get
			{
				return this.m_UVRegion;
			}
		}

		// Token: 0x060013A4 RID: 5028 RVA: 0x00044CF4 File Offset: 0x00042EF4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetNextVertex(Vertex vertex)
		{
			int num = this.currentVertex;
			this.currentVertex = num + 1;
			this.m_Vertices[num] = vertex;
		}

		// Token: 0x060013A5 RID: 5029 RVA: 0x00044D20 File Offset: 0x00042F20
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetNextIndex(ushort index)
		{
			int num = this.currentIndex;
			this.currentIndex = num + 1;
			this.m_Indices[num] = index;
		}

		// Token: 0x060013A6 RID: 5030 RVA: 0x00044D4C File Offset: 0x00042F4C
		public void SetAllVertices(Vertex[] vertices)
		{
			bool flag = this.currentVertex == 0;
			if (flag)
			{
				this.m_Vertices.CopyFrom(vertices);
				this.currentVertex = this.m_Vertices.Length;
				return;
			}
			throw new InvalidOperationException("SetAllVertices may not be called after using SetNextVertex");
		}

		// Token: 0x060013A7 RID: 5031 RVA: 0x00044D94 File Offset: 0x00042F94
		public void SetAllVertices(NativeSlice<Vertex> vertices)
		{
			bool flag = this.currentVertex == 0;
			if (flag)
			{
				this.m_Vertices.CopyFrom(vertices);
				this.currentVertex = this.m_Vertices.Length;
				return;
			}
			throw new InvalidOperationException("SetAllVertices may not be called after using SetNextVertex");
		}

		// Token: 0x060013A8 RID: 5032 RVA: 0x00044DDC File Offset: 0x00042FDC
		public void SetAllIndices(ushort[] indices)
		{
			bool flag = this.currentIndex == 0;
			if (flag)
			{
				this.m_Indices.CopyFrom(indices);
				this.currentIndex = this.m_Indices.Length;
				return;
			}
			throw new InvalidOperationException("SetAllIndices may not be called after using SetNextIndex");
		}

		// Token: 0x060013A9 RID: 5033 RVA: 0x00044E24 File Offset: 0x00043024
		public void SetAllIndices(NativeSlice<ushort> indices)
		{
			bool flag = this.currentIndex == 0;
			if (flag)
			{
				this.m_Indices.CopyFrom(indices);
				this.currentIndex = this.m_Indices.Length;
				return;
			}
			throw new InvalidOperationException("SetAllIndices may not be called after using SetNextIndex");
		}

		// Token: 0x060013AA RID: 5034 RVA: 0x00044E6C File Offset: 0x0004306C
		internal void Reset(NativeSlice<Vertex> vertices, NativeSlice<ushort> indices)
		{
			this.m_Vertices = vertices;
			this.m_Indices = indices;
			this.m_UVRegion = new Rect(0f, 0f, 1f, 1f);
			this.currentIndex = (this.currentVertex = 0);
		}

		// Token: 0x060013AB RID: 5035 RVA: 0x00044EB8 File Offset: 0x000430B8
		internal void Reset(NativeSlice<Vertex> vertices, NativeSlice<ushort> indices, Rect uvRegion)
		{
			this.m_Vertices = vertices;
			this.m_Indices = indices;
			this.m_UVRegion = uvRegion;
			this.currentIndex = (this.currentVertex = 0);
		}

		// Token: 0x040008FF RID: 2303
		internal NativeSlice<Vertex> m_Vertices;

		// Token: 0x04000900 RID: 2304
		internal NativeSlice<ushort> m_Indices;

		// Token: 0x04000901 RID: 2305
		internal Rect m_UVRegion;

		// Token: 0x04000902 RID: 2306
		internal int currentIndex;

		// Token: 0x04000903 RID: 2307
		internal int currentVertex;
	}
}
