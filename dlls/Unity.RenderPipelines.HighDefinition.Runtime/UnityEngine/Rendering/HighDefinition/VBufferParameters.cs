using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000E4 RID: 228
	internal struct VBufferParameters
	{
		// Token: 0x06000953 RID: 2387 RVA: 0x00052008 File Offset: 0x00050208
		public VBufferParameters(Vector3Int viewportSize, float depthExtent, float camNear, float camFar, float camVFoV, float sliceDistributionUniformity, float voxelSize)
		{
			this.viewportSize = viewportSize;
			this.voxelSize = voxelSize;
			float num = (float)viewportSize.x / (float)viewportSize.y;
			float num2 = 2f * Mathf.Tan(0.5f * camVFoV) * camFar;
			float num3 = Mathf.Max(num2 * num, num2);
			float val = Mathf.Sqrt(camFar * camFar + 0.25f * num3 * num3);
			float farPlane = Math.Min(camNear + depthExtent, val);
			float num4 = 2f - 2f * sliceDistributionUniformity;
			num4 = Mathf.Max(num4, 0.001f);
			this.depthEncodingParams = VBufferParameters.ComputeLogarithmicDepthEncodingParams(camNear, farPlane, num4);
			this.depthDecodingParams = VBufferParameters.ComputeLogarithmicDepthDecodingParams(camNear, farPlane, num4);
		}

		// Token: 0x06000954 RID: 2388 RVA: 0x000520BC File Offset: 0x000502BC
		internal Vector3 ComputeViewportScale(Vector3Int bufferSize)
		{
			return new Vector3(HDUtils.ComputeViewportScale(this.viewportSize.x, bufferSize.x), HDUtils.ComputeViewportScale(this.viewportSize.y, bufferSize.y), HDUtils.ComputeViewportScale(this.viewportSize.z, bufferSize.z));
		}

		// Token: 0x06000955 RID: 2389 RVA: 0x00052114 File Offset: 0x00050314
		internal Vector3 ComputeViewportLimit(Vector3Int bufferSize)
		{
			return new Vector3(HDUtils.ComputeViewportLimit(this.viewportSize.x, bufferSize.x), HDUtils.ComputeViewportLimit(this.viewportSize.y, bufferSize.y), HDUtils.ComputeViewportLimit(this.viewportSize.z, bufferSize.z));
		}

		// Token: 0x06000956 RID: 2390 RVA: 0x0005216C File Offset: 0x0005036C
		internal float ComputeLastSliceDistance(uint sliceCount)
		{
			float num = 1f - 0.5f / sliceCount;
			float num2 = 0.6931472f;
			return this.depthDecodingParams.x * Mathf.Exp(num2 * num * this.depthDecodingParams.y) + this.depthDecodingParams.z;
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x000521BB File Offset: 0x000503BB
		private float EncodeLogarithmicDepthGeneralized(float z, Vector4 encodingParams)
		{
			return encodingParams.x + encodingParams.y * Mathf.Log(Mathf.Max(0f, z - encodingParams.z), 2f);
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x000521E7 File Offset: 0x000503E7
		private float DecodeLogarithmicDepthGeneralized(float d, Vector4 decodingParams)
		{
			return decodingParams.x * Mathf.Pow(2f, d * decodingParams.y) + decodingParams.z;
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x0005220C File Offset: 0x0005040C
		internal int ComputeSliceIndexFromDistance(float distance, int maxSliceCount)
		{
			distance = Mathf.Clamp(distance, 0f, this.ComputeLastSliceDistance((uint)maxSliceCount));
			float num = this.DecodeLogarithmicDepthGeneralized(0f, this.depthDecodingParams);
			float z = distance + num;
			float num2 = this.EncodeLogarithmicDepthGeneralized(z, this.depthEncodingParams);
			float num3 = 1f / (float)maxSliceCount;
			return (int)((num2 - num3) / num3);
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x00052260 File Offset: 0x00050460
		private static Vector4 ComputeLogarithmicDepthEncodingParams(float nearPlane, float farPlane, float c)
		{
			Vector4 vector = default(Vector4);
			vector.y = 1f / Mathf.Log(c * (farPlane - nearPlane) + 1f, 2f);
			vector.x = Mathf.Log(c, 2f) * vector.y;
			vector.z = nearPlane - 1f / c;
			vector.w = 0f;
			return vector;
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x000522D4 File Offset: 0x000504D4
		private static Vector4 ComputeLogarithmicDepthDecodingParams(float nearPlane, float farPlane, float c)
		{
			return new Vector4
			{
				x = 1f / c,
				y = Mathf.Log(c * (farPlane - nearPlane) + 1f, 2f),
				z = nearPlane - 1f / c,
				w = 0f
			};
		}

		// Token: 0x0400098D RID: 2445
		public Vector3Int viewportSize;

		// Token: 0x0400098E RID: 2446
		public float voxelSize;

		// Token: 0x0400098F RID: 2447
		public Vector4 depthEncodingParams;

		// Token: 0x04000990 RID: 2448
		public Vector4 depthDecodingParams;
	}
}
