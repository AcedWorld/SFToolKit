using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UnityEngine.Rendering
{
	// Token: 0x020000DD RID: 221
	internal class MeshGizmo : IDisposable
	{
		// Token: 0x06000770 RID: 1904 RVA: 0x000243A8 File Offset: 0x000225A8
		public MeshGizmo(int capacity = 0)
		{
			this.vertices = new List<Vector3>(capacity);
			this.indices = new List<int>(capacity);
			this.colors = new List<Color>(capacity);
			this.mesh = new Mesh
			{
				indexFormat = IndexFormat.UInt32,
				hideFlags = HideFlags.HideAndDontSave
			};
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x000243F9 File Offset: 0x000225F9
		public void Clear()
		{
			this.vertices.Clear();
			this.indices.Clear();
			this.colors.Clear();
		}

		// Token: 0x06000772 RID: 1906 RVA: 0x0002441C File Offset: 0x0002261C
		public void AddWireCube(Vector3 center, Vector3 size, Color color)
		{
			MeshGizmo.<>c__DisplayClass10_0 CS$<>8__locals1;
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.color = color;
			Vector3 vector = size / 2f;
			Vector3 b = new Vector3(vector.x, vector.y, vector.z);
			Vector3 b2 = new Vector3(-vector.x, vector.y, vector.z);
			Vector3 b3 = new Vector3(-vector.x, -vector.y, vector.z);
			Vector3 b4 = new Vector3(vector.x, -vector.y, vector.z);
			Vector3 b5 = new Vector3(vector.x, vector.y, -vector.z);
			Vector3 b6 = new Vector3(-vector.x, vector.y, -vector.z);
			Vector3 b7 = new Vector3(-vector.x, -vector.y, -vector.z);
			Vector3 b8 = new Vector3(vector.x, -vector.y, -vector.z);
			this.<AddWireCube>g__AddEdge|10_0(center + b, center + b2, ref CS$<>8__locals1);
			this.<AddWireCube>g__AddEdge|10_0(center + b2, center + b3, ref CS$<>8__locals1);
			this.<AddWireCube>g__AddEdge|10_0(center + b3, center + b4, ref CS$<>8__locals1);
			this.<AddWireCube>g__AddEdge|10_0(center + b4, center + b, ref CS$<>8__locals1);
			this.<AddWireCube>g__AddEdge|10_0(center + b5, center + b6, ref CS$<>8__locals1);
			this.<AddWireCube>g__AddEdge|10_0(center + b6, center + b7, ref CS$<>8__locals1);
			this.<AddWireCube>g__AddEdge|10_0(center + b7, center + b8, ref CS$<>8__locals1);
			this.<AddWireCube>g__AddEdge|10_0(center + b8, center + b5, ref CS$<>8__locals1);
			this.<AddWireCube>g__AddEdge|10_0(center + b, center + b5, ref CS$<>8__locals1);
			this.<AddWireCube>g__AddEdge|10_0(center + b2, center + b6, ref CS$<>8__locals1);
			this.<AddWireCube>g__AddEdge|10_0(center + b3, center + b7, ref CS$<>8__locals1);
			this.<AddWireCube>g__AddEdge|10_0(center + b4, center + b8, ref CS$<>8__locals1);
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x00024634 File Offset: 0x00022834
		private void DrawMesh(Matrix4x4 trs, Material mat, MeshTopology topology, CompareFunction depthTest, string gizmoName)
		{
			this.mesh.Clear();
			this.mesh.SetVertices(this.vertices);
			this.mesh.SetColors(this.colors);
			this.mesh.SetIndices(this.indices, topology, 0, true, 0);
			mat.SetFloat("_HandleZTest", (float)depthTest);
			CommandBuffer commandBuffer = CommandBufferPool.Get(gizmoName ?? "Mesh Gizmo Rendering");
			commandBuffer.DrawMesh(this.mesh, trs, mat, 0, 0);
			Graphics.ExecuteCommandBuffer(commandBuffer);
		}

		// Token: 0x06000774 RID: 1908 RVA: 0x000246B6 File Offset: 0x000228B6
		public void RenderWireframe(Matrix4x4 trs, CompareFunction depthTest = CompareFunction.LessEqual, string gizmoName = null)
		{
			this.DrawMesh(trs, this.wireMaterial, MeshTopology.Lines, depthTest, gizmoName);
		}

		// Token: 0x06000775 RID: 1909 RVA: 0x000246C8 File Offset: 0x000228C8
		public void Dispose()
		{
			CoreUtils.Destroy(this.mesh);
		}

		// Token: 0x06000777 RID: 1911 RVA: 0x000246E0 File Offset: 0x000228E0
		[CompilerGenerated]
		private void <AddWireCube>g__AddEdge|10_0(Vector3 p1, Vector3 p2, ref MeshGizmo.<>c__DisplayClass10_0 A_3)
		{
			this.vertices.Add(p1);
			this.vertices.Add(p2);
			this.indices.Add(this.indices.Count);
			this.indices.Add(this.indices.Count);
			this.colors.Add(A_3.color);
			this.colors.Add(A_3.color);
		}

		// Token: 0x040004AC RID: 1196
		public static readonly int vertexCountPerCube = 24;

		// Token: 0x040004AD RID: 1197
		public Mesh mesh;

		// Token: 0x040004AE RID: 1198
		private List<Vector3> vertices;

		// Token: 0x040004AF RID: 1199
		private List<int> indices;

		// Token: 0x040004B0 RID: 1200
		private List<Color> colors;

		// Token: 0x040004B1 RID: 1201
		private Material wireMaterial;

		// Token: 0x040004B2 RID: 1202
		private Material dottedWireMaterial;

		// Token: 0x040004B3 RID: 1203
		private Material solidMaterial;
	}
}
