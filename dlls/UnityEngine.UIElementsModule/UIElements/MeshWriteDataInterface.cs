using System;
using Unity.Collections.LowLevel.Unsafe;

namespace UnityEngine.UIElements
{
	// Token: 0x0200027A RID: 634
	internal struct MeshWriteDataInterface
	{
		// Token: 0x060011EB RID: 4587 RVA: 0x00040DBC File Offset: 0x0003EFBC
		public static MeshWriteDataInterface FromMeshWriteData(MeshWriteData data)
		{
			return new MeshWriteDataInterface
			{
				vertices = new IntPtr(data.m_Vertices.GetUnsafePtr<Vertex>()),
				indices = new IntPtr(data.m_Indices.GetUnsafePtr<ushort>()),
				vertexCount = data.m_Vertices.Length,
				indexCount = data.m_Indices.Length
			};
		}

		// Token: 0x040007ED RID: 2029
		public IntPtr vertices;

		// Token: 0x040007EE RID: 2030
		public IntPtr indices;

		// Token: 0x040007EF RID: 2031
		public int vertexCount;

		// Token: 0x040007F0 RID: 2032
		public int indexCount;
	}
}
