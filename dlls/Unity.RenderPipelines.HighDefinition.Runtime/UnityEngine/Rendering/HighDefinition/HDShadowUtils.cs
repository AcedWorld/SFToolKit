using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000D7 RID: 215
	internal static class HDShadowUtils
	{
		// Token: 0x0600092E RID: 2350 RVA: 0x00050C8B File Offset: 0x0004EE8B
		public unsafe static float Asfloat(uint val)
		{
			return *(float*)(&val);
		}

		// Token: 0x0600092F RID: 2351 RVA: 0x00050C91 File Offset: 0x0004EE91
		public unsafe static float Asfloat(int val)
		{
			return *(float*)(&val);
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x00050C97 File Offset: 0x0004EE97
		public unsafe static int Asint(float val)
		{
			return *(int*)(&val);
		}

		// Token: 0x06000931 RID: 2353 RVA: 0x00050C9D File Offset: 0x0004EE9D
		public unsafe static uint Asuint(float val)
		{
			return *(uint*)(&val);
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x00050CA3 File Offset: 0x0004EEA3
		private static float GetPunctualFilterWidthInTexels(HDShadowFilteringQuality quality)
		{
			if (quality == HDShadowFilteringQuality.Low)
			{
				return 3f;
			}
			if (quality != HDShadowFilteringQuality.Medium)
			{
				return 1f;
			}
			return 5f;
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x00050CC0 File Offset: 0x0004EEC0
		public static void ExtractPointLightData(VisibleLight visibleLight, Vector2 viewportSize, float nearPlane, float normalBiasMax, uint faceIndex, HDShadowFilteringQuality filteringQuality, out Matrix4x4 view, out Matrix4x4 invViewProjection, out Matrix4x4 projection, out Matrix4x4 deviceProjection, out Matrix4x4 deviceProjectionYFlip, out ShadowSplitData splitData)
		{
			float guardAngle = HDShadowUtils.CalcGuardAnglePerspective(90f, viewportSize.x, HDShadowUtils.GetPunctualFilterWidthInTexels(filteringQuality), normalBiasMax, 79f);
			Vector4 vector;
			HDShadowUtils.ExtractPointLightMatrix(visibleLight, faceIndex, nearPlane, guardAngle, out view, out projection, out deviceProjection, out deviceProjectionYFlip, out invViewProjection, out vector, out splitData);
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x00050D04 File Offset: 0x0004EF04
		public static void ExtractSpotLightData(SpotLightShape shape, float spotAngle, float nearPlane, float aspectRatio, float shapeWidth, float shapeHeight, VisibleLight visibleLight, Vector2 viewportSize, float normalBiasMax, HDShadowFilteringQuality filteringQuality, out Matrix4x4 view, out Matrix4x4 invViewProjection, out Matrix4x4 projection, out Matrix4x4 deviceProjection, out Matrix4x4 deviceProjectionYFlip, out ShadowSplitData splitData)
		{
			if (shape != SpotLightShape.Pyramid)
			{
				aspectRatio = 1f;
			}
			if (shape != SpotLightShape.Box)
			{
				nearPlane = Mathf.Max(HDShadowUtils.k_MinShadowNearPlane, nearPlane);
			}
			float guardAngle = HDShadowUtils.CalcGuardAnglePerspective(spotAngle, viewportSize.x, HDShadowUtils.GetPunctualFilterWidthInTexels(filteringQuality), normalBiasMax, 180f - spotAngle);
			Vector4 vector;
			HDShadowUtils.ExtractSpotLightMatrix(visibleLight, 0f, spotAngle, nearPlane, guardAngle, aspectRatio, out view, out projection, out deviceProjection, out deviceProjectionYFlip, out invViewProjection, out vector, out splitData);
			if (shape == SpotLightShape.Box)
			{
				projection = HDShadowUtils.ExtractBoxLightProjectionMatrix(visibleLight.range, shapeWidth, shapeHeight, nearPlane);
				Matrix4x4 matrix4x;
				HDShadowUtils.InvertView(ref view, out matrix4x);
				Vector3 vector2 = matrix4x.GetColumn(0);
				Vector3 vector3 = matrix4x.GetColumn(1);
				Vector3 vector4 = -matrix4x.GetColumn(2);
				Vector3 a = matrix4x.GetColumn(3);
				splitData.cullingPlaneCount = 6;
				splitData.SetCullingPlane(0, new Plane(vector2, a - vector2 * (0.5f * shapeWidth)));
				splitData.SetCullingPlane(1, new Plane(-vector2, a + vector2 * (0.5f * shapeWidth)));
				splitData.SetCullingPlane(2, new Plane(vector3, a - vector3 * (0.5f * shapeHeight)));
				splitData.SetCullingPlane(3, new Plane(-vector3, a + vector3 * (0.5f * shapeHeight)));
				splitData.SetCullingPlane(4, new Plane(vector4, a + vector4 * nearPlane));
				splitData.SetCullingPlane(5, new Plane(-vector4, a + vector4 * visibleLight.range));
				deviceProjection = GL.GetGPUProjectionMatrix(projection, false);
				deviceProjectionYFlip = GL.GetGPUProjectionMatrix(projection, true);
				HDShadowUtils.InvertOrthographic(ref deviceProjectionYFlip, ref view, out invViewProjection);
				splitData.cullingMatrix = projection * view;
				splitData.cullingNearPlane = nearPlane;
			}
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x00050F10 File Offset: 0x0004F110
		public static void ExtractDirectionalLightData(VisibleLight visibleLight, Vector2 viewportSize, uint cascadeIndex, int cascadeCount, float[] cascadeRatios, float nearPlaneOffset, CullingResults cullResults, int lightIndex, out Matrix4x4 view, out Matrix4x4 invViewProjection, out Matrix4x4 projection, out Matrix4x4 deviceProjection, out Matrix4x4 deviceProjectionYFlip, out ShadowSplitData splitData)
		{
			splitData = default(ShadowSplitData);
			splitData.cullingSphere.Set(0f, 0f, 0f, float.NegativeInfinity);
			splitData.cullingPlaneCount = 0;
			splitData.shadowCascadeBlendCullingFactor = 0.6f;
			visibleLight.GetForward();
			Vector3 splitRatio = default(Vector3);
			int i = 0;
			int num = (cascadeRatios.Length < 3) ? cascadeRatios.Length : 3;
			while (i < num)
			{
				splitRatio[i] = cascadeRatios[i];
				i++;
			}
			cullResults.ComputeDirectionalShadowMatricesAndCullingPrimitives(lightIndex, (int)cascadeIndex, cascadeCount, splitRatio, (int)viewportSize.x, nearPlaneOffset, out view, out projection, out splitData);
			deviceProjection = GL.GetGPUProjectionMatrix(projection, false);
			deviceProjectionYFlip = GL.GetGPUProjectionMatrix(projection, true);
			HDShadowUtils.InvertOrthographic(ref deviceProjection, ref view, out invViewProjection);
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x00050FE8 File Offset: 0x0004F1E8
		public static void ExtractRectangleAreaLightData(VisibleLight visibleLight, float forwardOffset, float areaLightShadowCone, float shadowNearPlane, Vector2 shapeSize, Vector2 viewportSize, float normalBiasMax, HDAreaShadowFilteringQuality filteringQuality, out Matrix4x4 view, out Matrix4x4 invViewProjection, out Matrix4x4 projection, out Matrix4x4 deviceProjection, out Matrix4x4 deviceProjectionYFlip, out ShadowSplitData splitData)
		{
			float aspectRatio = shapeSize.x / shapeSize.y;
			visibleLight.spotAngle = areaLightShadowCone;
			float guardAngle = HDShadowUtils.CalcGuardAnglePerspective(visibleLight.spotAngle, viewportSize.x, 1f, normalBiasMax, 180f - visibleLight.spotAngle);
			Vector4 vector;
			HDShadowUtils.ExtractSpotLightMatrix(visibleLight, forwardOffset, visibleLight.spotAngle, shadowNearPlane, guardAngle, aspectRatio, out view, out projection, out deviceProjection, out deviceProjectionYFlip, out invViewProjection, out vector, out splitData);
		}

		// Token: 0x06000937 RID: 2359 RVA: 0x00051058 File Offset: 0x0004F258
		private static void InvertView(ref Matrix4x4 view, out Matrix4x4 invview)
		{
			invview = Matrix4x4.zero;
			invview.m00 = view.m00;
			invview.m01 = view.m10;
			invview.m02 = view.m20;
			invview.m10 = view.m01;
			invview.m11 = view.m11;
			invview.m12 = view.m21;
			invview.m20 = view.m02;
			invview.m21 = view.m12;
			invview.m22 = view.m22;
			invview.m33 = 1f;
			invview.m03 = -(invview.m00 * view.m03 + invview.m01 * view.m13 + invview.m02 * view.m23);
			invview.m13 = -(invview.m10 * view.m03 + invview.m11 * view.m13 + invview.m12 * view.m23);
			invview.m23 = -(invview.m20 * view.m03 + invview.m21 * view.m13 + invview.m22 * view.m23);
		}

		// Token: 0x06000938 RID: 2360 RVA: 0x00051178 File Offset: 0x0004F378
		private static void InvertOrthographic(ref Matrix4x4 proj, ref Matrix4x4 view, out Matrix4x4 vpinv)
		{
			Matrix4x4 lhs;
			HDShadowUtils.InvertView(ref view, out lhs);
			Matrix4x4 zero = Matrix4x4.zero;
			zero.m00 = 1f / proj.m00;
			zero.m11 = 1f / proj.m11;
			zero.m22 = 1f / proj.m22;
			zero.m33 = 1f;
			zero.m03 = proj.m03 * zero.m00;
			zero.m13 = proj.m13 * zero.m11;
			zero.m23 = -proj.m23 * zero.m22;
			vpinv = lhs * zero;
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x00051224 File Offset: 0x0004F424
		private static void InvertPerspective(ref Matrix4x4 proj, ref Matrix4x4 view, out Matrix4x4 vpinv)
		{
			Matrix4x4 matrix4x;
			HDShadowUtils.InvertView(ref view, out matrix4x);
			Matrix4x4 zero = Matrix4x4.zero;
			zero.m00 = 1f / proj.m00;
			zero.m03 = proj.m02 * zero.m00;
			zero.m11 = 1f / proj.m11;
			zero.m13 = proj.m12 * zero.m11;
			zero.m22 = 0f;
			zero.m23 = -1f;
			zero.m33 = proj.m22 / proj.m23;
			zero.m32 = zero.m33 / proj.m22;
			vpinv.m00 = matrix4x.m00 * zero.m00;
			vpinv.m01 = matrix4x.m01 * zero.m11;
			vpinv.m02 = matrix4x.m03 * zero.m32;
			vpinv.m03 = matrix4x.m00 * zero.m03 + matrix4x.m01 * zero.m13 - matrix4x.m02 + matrix4x.m03 * zero.m33;
			vpinv.m10 = matrix4x.m10 * zero.m00;
			vpinv.m11 = matrix4x.m11 * zero.m11;
			vpinv.m12 = matrix4x.m13 * zero.m32;
			vpinv.m13 = matrix4x.m10 * zero.m03 + matrix4x.m11 * zero.m13 - matrix4x.m12 + matrix4x.m13 * zero.m33;
			vpinv.m20 = matrix4x.m20 * zero.m00;
			vpinv.m21 = matrix4x.m21 * zero.m11;
			vpinv.m22 = matrix4x.m23 * zero.m32;
			vpinv.m23 = matrix4x.m20 * zero.m03 + matrix4x.m21 * zero.m13 - matrix4x.m22 + matrix4x.m23 * zero.m33;
			vpinv.m30 = 0f;
			vpinv.m31 = 0f;
			vpinv.m32 = zero.m32;
			vpinv.m33 = zero.m33;
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x00051448 File Offset: 0x0004F648
		public static Matrix4x4 ExtractSpotLightProjectionMatrix(float range, float spotAngle, float nearPlane, float aspectRatio, float guardAngle)
		{
			float num = spotAngle + guardAngle;
			float num2 = Mathf.Max(nearPlane, HDShadowUtils.k_MinShadowNearPlane);
			float num3 = 1f / Mathf.Tan(num / 180f * 3.1415927f / 2f);
			float num4 = num2;
			float num5 = num4 + range;
			Matrix4x4 result = default(Matrix4x4);
			if (aspectRatio < 1f)
			{
				result.m00 = num3;
				result.m11 = num3 * aspectRatio;
			}
			else
			{
				result.m00 = num3 / aspectRatio;
				result.m11 = num3;
			}
			result.m22 = -(num5 + num4) / (num5 - num4);
			result.m23 = -2f * num5 * num4 / (num5 - num4);
			result.m32 = -1f;
			return result;
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x000514F7 File Offset: 0x0004F6F7
		public static Matrix4x4 ExtractBoxLightProjectionMatrix(float range, float width, float height, float nearPlane)
		{
			return Matrix4x4.Ortho(-width / 2f, width / 2f, -height / 2f, height / 2f, nearPlane, range);
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x00051520 File Offset: 0x0004F720
		private static Matrix4x4 ExtractSpotLightMatrix(VisibleLight vl, float forwardOffset, float spotAngle, float nearPlane, float guardAngle, float aspectRatio, out Matrix4x4 view, out Matrix4x4 proj, out Matrix4x4 deviceProj, out Matrix4x4 deviceProjYFlip, out Matrix4x4 vpinverse, out Vector4 lightDir, out ShadowSplitData splitData)
		{
			splitData = default(ShadowSplitData);
			splitData.cullingSphere.Set(0f, 0f, 0f, float.NegativeInfinity);
			splitData.cullingPlaneCount = 0;
			lightDir = vl.GetForward();
			Matrix4x4 localToWorldMatrix = vl.localToWorldMatrix;
			CoreMatrixUtils.MatrixTimesTranslation(ref localToWorldMatrix, Vector3.forward * forwardOffset);
			view = localToWorldMatrix.inverse;
			view.m20 *= -1f;
			view.m21 *= -1f;
			view.m22 *= -1f;
			view.m23 *= -1f;
			proj = HDShadowUtils.ExtractSpotLightProjectionMatrix(vl.range - forwardOffset, spotAngle, nearPlane - forwardOffset, aspectRatio, guardAngle);
			deviceProj = GL.GetGPUProjectionMatrix(proj, false);
			deviceProjYFlip = GL.GetGPUProjectionMatrix(proj, true);
			HDShadowUtils.InvertPerspective(ref deviceProj, ref view, out vpinverse);
			Matrix4x4 matrix = CoreMatrixUtils.MultiplyPerspectiveMatrix(proj, view);
			HDShadowUtils.SetSplitDataCullingPlanesFromViewProjMatrix(ref splitData, matrix);
			Matrix4x4 matrix4x = CoreMatrixUtils.MultiplyPerspectiveMatrix(deviceProj, view);
			splitData.cullingMatrix = matrix4x;
			splitData.cullingNearPlane = nearPlane - forwardOffset;
			return matrix4x;
		}

		// Token: 0x0600093D RID: 2365 RVA: 0x00051670 File Offset: 0x0004F870
		private static Matrix4x4 ExtractPointLightMatrix(VisibleLight vl, uint faceIdx, float nearPlane, float guardAngle, out Matrix4x4 view, out Matrix4x4 proj, out Matrix4x4 deviceProj, out Matrix4x4 deviceProjYFlip, out Matrix4x4 vpinverse, out Vector4 lightDir, out ShadowSplitData splitData)
		{
			if (faceIdx > 5U)
			{
				Debug.LogError("Tried to extract cubemap face " + faceIdx.ToString() + ".");
			}
			splitData = default(ShadowSplitData);
			splitData.cullingSphere.Set(0f, 0f, 0f, float.NegativeInfinity);
			lightDir = vl.GetForward();
			Vector3 position = vl.GetPosition();
			view = HDShadowUtils.kCubemapFaces[(int)faceIdx];
			Vector3 vector = HDShadowUtils.kCubemapFaces[(int)faceIdx].MultiplyPoint(-position);
			view.SetColumn(3, new Vector4(vector.x, vector.y, vector.z, 1f));
			float num = Mathf.Max(nearPlane, HDShadowUtils.k_MinShadowNearPlane);
			proj = Matrix4x4.Perspective(90f + guardAngle, 1f, num, vl.range);
			deviceProj = GL.GetGPUProjectionMatrix(proj, false);
			deviceProjYFlip = GL.GetGPUProjectionMatrix(proj, true);
			HDShadowUtils.InvertPerspective(ref deviceProj, ref view, out vpinverse);
			Matrix4x4 matrix = CoreMatrixUtils.MultiplyPerspectiveMatrix(proj, view);
			HDShadowUtils.SetSplitDataCullingPlanesFromViewProjMatrix(ref splitData, matrix);
			Matrix4x4 matrix4x = CoreMatrixUtils.MultiplyPerspectiveMatrix(deviceProj, view);
			splitData.cullingMatrix = matrix4x;
			splitData.cullingNearPlane = num;
			return matrix4x;
		}

		// Token: 0x0600093E RID: 2366 RVA: 0x000517D4 File Offset: 0x0004F9D4
		private static float CalcGuardAnglePerspective(float angleInDeg, float resolution, float filterWidth, float normalBiasMax, float guardAngleMaxInDeg)
		{
			float num = angleInDeg * 0.5f * 0.017453292f;
			float num2 = 2f / resolution;
			float num3 = Mathf.Cos(num) * num2;
			float num4 = Mathf.Atan(normalBiasMax * num3 * 1.4142135f);
			num3 = Mathf.Tan(num + num4) * num2;
			num4 = Mathf.Atan((resolution + Mathf.Ceil(filterWidth)) * num3 * 0.5f) * 2f * 57.29578f - angleInDeg;
			num4 *= 2f;
			if (num4 >= guardAngleMaxInDeg)
			{
				return guardAngleMaxInDeg;
			}
			return num4;
		}

		// Token: 0x0600093F RID: 2367 RVA: 0x0005184D File Offset: 0x0004FA4D
		public static float GetSlopeBias(float baseBias, float normalizedSlopeBias)
		{
			return normalizedSlopeBias * baseBias;
		}

		// Token: 0x06000940 RID: 2368 RVA: 0x00051854 File Offset: 0x0004FA54
		private static void SetSplitDataCullingPlanesFromViewProjMatrix(ref ShadowSplitData splitData, Matrix4x4 matrix)
		{
			GeometryUtility.CalculateFrustumPlanes(matrix, HDShadowUtils.s_CachedPlanes);
			if (SystemInfo.usesReversedZBuffer)
			{
				Plane plane = HDShadowUtils.s_CachedPlanes[2];
				HDShadowUtils.s_CachedPlanes[2] = HDShadowUtils.s_CachedPlanes[3];
				HDShadowUtils.s_CachedPlanes[3] = plane;
			}
			splitData.cullingPlaneCount = 6;
			for (int i = 0; i < 6; i++)
			{
				splitData.SetCullingPlane(i, HDShadowUtils.s_CachedPlanes[i]);
			}
		}

		// Token: 0x04000937 RID: 2359
		public static readonly float k_MinShadowNearPlane = 0.01f;

		// Token: 0x04000938 RID: 2360
		public static readonly float k_MaxShadowNearPlane = 10f;

		// Token: 0x04000939 RID: 2361
		private static Plane[] s_CachedPlanes = new Plane[6];

		// Token: 0x0400093A RID: 2362
		public static readonly Matrix4x4[] kCubemapFaces = new Matrix4x4[]
		{
			new Matrix4x4(new Vector4(0f, 0f, -1f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(-1f, 0f, 0f, 0f), new Vector4(0f, 0f, 0f, 1f)),
			new Matrix4x4(new Vector4(0f, 0f, 1f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(1f, 0f, 0f, 0f), new Vector4(0f, 0f, 0f, 1f)),
			new Matrix4x4(new Vector4(1f, 0f, 0f, 0f), new Vector4(0f, 0f, -1f, 0f), new Vector4(0f, -1f, 0f, 0f), new Vector4(0f, 0f, 0f, 1f)),
			new Matrix4x4(new Vector4(1f, 0f, 0f, 0f), new Vector4(0f, 0f, 1f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0f, 0f, 0f, 1f)),
			new Matrix4x4(new Vector4(1f, 0f, 0f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0f, 0f, -1f, 0f), new Vector4(0f, 0f, 0f, 1f)),
			new Matrix4x4(new Vector4(-1f, 0f, 0f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0f, 0f, 1f, 0f), new Vector4(0f, 0f, 0f, 1f))
		};
	}
}
