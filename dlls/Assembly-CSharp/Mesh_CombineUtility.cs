using System;
using UnityEngine;

// Token: 0x02000010 RID: 16
public class Mesh_CombineUtility
{
	// Token: 0x06000050 RID: 80 RVA: 0x00005BD8 File Offset: 0x00003DD8
	public static Mesh Combine(Mesh_CombineUtility.MeshInstance[] combines, bool generateStrips)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		foreach (Mesh_CombineUtility.MeshInstance meshInstance in combines)
		{
			if (meshInstance.mesh)
			{
				num += meshInstance.mesh.vertexCount;
				if (generateStrips)
				{
					int num4 = meshInstance.mesh.GetTriangles(meshInstance.subMeshIndex).Length;
					if (num4 != 0)
					{
						if (num3 != 0)
						{
							if ((num3 & 1) == 1)
							{
								num3 += 3;
							}
							else
							{
								num3 += 2;
							}
						}
						num3 += num4;
					}
					else
					{
						generateStrips = false;
					}
				}
			}
		}
		if (!generateStrips)
		{
			foreach (Mesh_CombineUtility.MeshInstance meshInstance2 in combines)
			{
				if (meshInstance2.mesh)
				{
					num2 += meshInstance2.mesh.GetTriangles(meshInstance2.subMeshIndex).Length;
				}
			}
		}
		Vector3[] array = new Vector3[num];
		Vector3[] array2 = new Vector3[num];
		Vector4[] array3 = new Vector4[num];
		Vector2[] array4 = new Vector2[num];
		Vector2[] array5 = new Vector2[num];
		Color[] array6 = new Color[num];
		int[] array7 = new int[num2];
		int[] array8 = new int[num3];
		int num5 = 0;
		foreach (Mesh_CombineUtility.MeshInstance meshInstance3 in combines)
		{
			if (meshInstance3.mesh)
			{
				Mesh_CombineUtility.Copy(meshInstance3.mesh.vertexCount, meshInstance3.mesh.vertices, array, ref num5, meshInstance3.transform);
			}
		}
		num5 = 0;
		foreach (Mesh_CombineUtility.MeshInstance meshInstance4 in combines)
		{
			if (meshInstance4.mesh)
			{
				Matrix4x4 transform = meshInstance4.transform;
				transform = transform.inverse.transpose;
				Mesh_CombineUtility.CopyNormal(meshInstance4.mesh.vertexCount, meshInstance4.mesh.normals, array2, ref num5, transform);
			}
		}
		num5 = 0;
		foreach (Mesh_CombineUtility.MeshInstance meshInstance5 in combines)
		{
			if (meshInstance5.mesh)
			{
				Matrix4x4 transform2 = meshInstance5.transform;
				transform2 = transform2.inverse.transpose;
				Mesh_CombineUtility.CopyTangents(meshInstance5.mesh.vertexCount, meshInstance5.mesh.tangents, array3, ref num5, transform2);
			}
		}
		num5 = 0;
		foreach (Mesh_CombineUtility.MeshInstance meshInstance6 in combines)
		{
			if (meshInstance6.mesh)
			{
				Mesh_CombineUtility.Copy(meshInstance6.mesh.vertexCount, meshInstance6.mesh.uv, array4, ref num5);
			}
		}
		num5 = 0;
		foreach (Mesh_CombineUtility.MeshInstance meshInstance7 in combines)
		{
			if (meshInstance7.mesh)
			{
				Mesh_CombineUtility.Copy(meshInstance7.mesh.vertexCount, meshInstance7.mesh.uv2, array5, ref num5);
			}
		}
		num5 = 0;
		foreach (Mesh_CombineUtility.MeshInstance meshInstance8 in combines)
		{
			if (meshInstance8.mesh)
			{
				Mesh_CombineUtility.CopyColors(meshInstance8.mesh.vertexCount, meshInstance8.mesh.colors, array6, ref num5);
			}
		}
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		foreach (Mesh_CombineUtility.MeshInstance meshInstance9 in combines)
		{
			if (meshInstance9.mesh)
			{
				if (generateStrips)
				{
					int[] triangles = meshInstance9.mesh.GetTriangles(meshInstance9.subMeshIndex);
					if (num7 != 0)
					{
						if ((num7 & 1) == 1)
						{
							array8[num7] = array8[num7 - 1];
							array8[num7 + 1] = triangles[0] + num8;
							array8[num7 + 2] = triangles[0] + num8;
							num7 += 3;
						}
						else
						{
							array8[num7] = array8[num7 - 1];
							array8[num7 + 1] = triangles[0] + num8;
							num7 += 2;
						}
					}
					for (int j = 0; j < triangles.Length; j++)
					{
						array8[j + num7] = triangles[j] + num8;
					}
					num7 += triangles.Length;
				}
				else
				{
					int[] triangles2 = meshInstance9.mesh.GetTriangles(meshInstance9.subMeshIndex);
					for (int k = 0; k < triangles2.Length; k++)
					{
						array7[k + num6] = triangles2[k] + num8;
					}
					num6 += triangles2.Length;
				}
				num8 += meshInstance9.mesh.vertexCount;
			}
		}
		if (array.Length > 65000)
		{
			return null;
		}
		Mesh mesh = new Mesh();
		mesh.name = "Combined Mesh";
		mesh.vertices = array;
		mesh.normals = array2;
		mesh.colors = array6;
		mesh.uv = array4;
		mesh.uv2 = array5;
		mesh.tangents = array3;
		if (generateStrips)
		{
			mesh.SetTriangles(array8, 0);
		}
		else
		{
			mesh.triangles = array7;
		}
		return mesh;
	}

	// Token: 0x06000051 RID: 81 RVA: 0x000060C4 File Offset: 0x000042C4
	private static void Copy(int vertexcount, Vector3[] src, Vector3[] dst, ref int offset, Matrix4x4 transform)
	{
		for (int i = 0; i < src.Length; i++)
		{
			dst[i + offset] = transform.MultiplyPoint(src[i]);
		}
		offset += vertexcount;
	}

	// Token: 0x06000052 RID: 82 RVA: 0x00006100 File Offset: 0x00004300
	private static void CopyNormal(int vertexcount, Vector3[] src, Vector3[] dst, ref int offset, Matrix4x4 transform)
	{
		for (int i = 0; i < src.Length; i++)
		{
			dst[i + offset] = transform.MultiplyVector(src[i]).normalized;
		}
		offset += vertexcount;
	}

	// Token: 0x06000053 RID: 83 RVA: 0x00006144 File Offset: 0x00004344
	private static void Copy(int vertexcount, Vector2[] src, Vector2[] dst, ref int offset)
	{
		for (int i = 0; i < src.Length; i++)
		{
			dst[i + offset] = src[i];
		}
		offset += vertexcount;
	}

	// Token: 0x06000054 RID: 84 RVA: 0x00006178 File Offset: 0x00004378
	private static void CopyColors(int vertexcount, Color[] src, Color[] dst, ref int offset)
	{
		for (int i = 0; i < src.Length; i++)
		{
			dst[i + offset] = src[i];
		}
		offset += vertexcount;
	}

	// Token: 0x06000055 RID: 85 RVA: 0x000061AC File Offset: 0x000043AC
	private static void CopyTangents(int vertexcount, Vector4[] src, Vector4[] dst, ref int offset, Matrix4x4 transform)
	{
		for (int i = 0; i < src.Length; i++)
		{
			Vector4 vector = src[i];
			Vector3 normalized = new Vector3(vector.x, vector.y, vector.z);
			normalized = transform.MultiplyVector(normalized).normalized;
			dst[i + offset] = new Vector4(normalized.x, normalized.y, normalized.z, vector.w);
		}
		offset += vertexcount;
	}

	// Token: 0x02000011 RID: 17
	public struct MeshInstance
	{
		// Token: 0x0400007C RID: 124
		public Mesh mesh;

		// Token: 0x0400007D RID: 125
		public int subMeshIndex;

		// Token: 0x0400007E RID: 126
		public Matrix4x4 transform;
	}
}
