using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000210 RID: 528
	public static class ProbeSettingsUtilities
	{
		// Token: 0x06000F9B RID: 3995 RVA: 0x000795A4 File Offset: 0x000777A4
		public static void ApplySettings(ref ProbeSettings settings, ref ProbeCapturePositionSettings probePosition, ref CameraSettings cameraSettings, ref CameraPositionSettings cameraPosition, float referenceFieldOfView = 90f, float referenceAspect = 1f)
		{
			cameraSettings = settings.cameraSettings;
			ProbeSettings.ProbeType type = settings.type;
			ProbeSettingsUtilities.PositionMode positionMode;
			bool flag;
			if (type != ProbeSettings.ProbeType.ReflectionProbe)
			{
				if (type != ProbeSettings.ProbeType.PlanarProbe)
				{
					throw new ArgumentOutOfRangeException();
				}
				positionMode = ProbeSettingsUtilities.PositionMode.MirrorReferenceTransformWithProbePlane;
				flag = true;
				ProbeSettingsUtilities.ApplyPlanarFrustumHandling(ref settings, ref probePosition, ref cameraSettings, ref cameraPosition, referenceFieldOfView, referenceAspect);
			}
			else
			{
				positionMode = ProbeSettingsUtilities.PositionMode.UseProbeTransform;
				flag = false;
				cameraSettings.frustum.mode = CameraSettings.Frustum.Mode.ComputeProjectionMatrix;
				cameraSettings.frustum.aspect = 1f;
				cameraSettings.frustum.fieldOfView = 90f;
			}
			if (positionMode != ProbeSettingsUtilities.PositionMode.UseProbeTransform)
			{
				if (positionMode == ProbeSettingsUtilities.PositionMode.MirrorReferenceTransformWithProbePlane)
				{
					cameraPosition.mode = CameraPositionSettings.Mode.UseWorldToCameraMatrixField;
					ProbeSettingsUtilities.ApplyMirroredReferenceTransform(ref settings, ref probePosition, ref cameraSettings, ref cameraPosition);
				}
			}
			else
			{
				cameraPosition.mode = CameraPositionSettings.Mode.ComputeWorldToCameraMatrix;
				Matrix4x4 matrix4x = Matrix4x4.TRS(probePosition.proxyPosition, probePosition.proxyRotation, Vector3.one);
				cameraPosition.position = matrix4x.MultiplyPoint(settings.proxySettings.capturePositionProxySpace);
				cameraPosition.rotation = matrix4x.rotation * settings.proxySettings.captureRotationProxySpace;
				if (settings.type == ProbeSettings.ProbeType.ReflectionProbe)
				{
					cameraPosition.rotation = Quaternion.identity;
				}
			}
			if (flag)
			{
				ProbeSettingsUtilities.ApplyObliqueNearClipPlane(ref settings, ref probePosition, ref cameraSettings, ref cameraPosition);
			}
			cameraSettings.probeRangeCompressionFactor = settings.lighting.rangeCompressionFactor;
			switch (settings.mode)
			{
			case ProbeSettings.Mode.Baked:
			case ProbeSettings.Mode.Custom:
				cameraSettings.defaultFrameSettings = FrameSettingsRenderType.CustomOrBakedReflection;
				return;
			default:
				cameraSettings.defaultFrameSettings = FrameSettingsRenderType.RealtimeReflection;
				return;
			}
		}

		// Token: 0x06000F9C RID: 3996 RVA: 0x000796E0 File Offset: 0x000778E0
		internal static void ApplyMirroredReferenceTransform(ref ProbeSettings settings, ref ProbeCapturePositionSettings probePosition, ref CameraSettings cameraSettings, ref CameraPositionSettings cameraPosition)
		{
			Matrix4x4 matrix4x = Matrix4x4.TRS(probePosition.proxyPosition, probePosition.proxyRotation, Vector3.one);
			Vector3 vector = matrix4x.MultiplyPoint(settings.proxySettings.mirrorPositionProxySpace);
			Vector3 vector2 = matrix4x.MultiplyVector(settings.proxySettings.mirrorRotationProxySpace * Vector3.forward);
			Matrix4x4 rhs = GeometryUtils.CalculateReflectionMatrix(vector, vector2);
			if (Vector3.Dot(vector2, probePosition.referencePosition - vector) < 0.0001f)
			{
				probePosition.referencePosition += 0.0001f * vector2;
			}
			Matrix4x4 lhs = GeometryUtils.CalculateWorldToCameraMatrixRHS(probePosition.referencePosition, probePosition.referenceRotation);
			cameraPosition.worldToCameraMatrix = lhs * rhs;
			cameraSettings.invertFaceCulling = true;
			cameraPosition.position = rhs.MultiplyPoint(probePosition.referencePosition);
			Vector3 forward = rhs.MultiplyVector(probePosition.referenceRotation * Vector3.forward);
			Vector3 upwards = rhs.MultiplyVector(probePosition.referenceRotation * Vector3.up);
			cameraPosition.rotation = Quaternion.LookRotation(forward, upwards);
		}

		// Token: 0x06000F9D RID: 3997 RVA: 0x000797F4 File Offset: 0x000779F4
		internal static void ApplyPlanarFrustumHandling(ref ProbeSettings settings, ref ProbeCapturePositionSettings probePosition, ref CameraSettings cameraSettings, ref CameraPositionSettings cameraPosition, float referenceFieldOfView, float referenceAspect)
		{
			Vector3 lookAtPositionWS = Matrix4x4.TRS(probePosition.proxyPosition, probePosition.proxyRotation, Vector3.one).MultiplyPoint(settings.proxySettings.mirrorPositionProxySpace);
			cameraSettings.frustum.aspect = referenceAspect;
			switch (settings.frustum.fieldOfViewMode)
			{
			case ProbeSettings.Frustum.FOVMode.Fixed:
				cameraSettings.frustum.fieldOfView = settings.frustum.fixedValue;
				return;
			case ProbeSettings.Frustum.FOVMode.Viewer:
				cameraSettings.frustum.fieldOfView = Mathf.Min(referenceFieldOfView * settings.frustum.viewerScale, 170f);
				return;
			case ProbeSettings.Frustum.FOVMode.Automatic:
				cameraSettings.frustum.fieldOfView = Mathf.Min(settings.influence.ComputeFOVAt(probePosition.referencePosition, lookAtPositionWS, probePosition.influenceToWorld) * settings.frustum.automaticScale, 170f);
				return;
			default:
				return;
			}
		}

		// Token: 0x06000F9E RID: 3998 RVA: 0x000798CC File Offset: 0x00077ACC
		internal static void ApplyObliqueNearClipPlane(ref ProbeSettings settings, ref ProbeCapturePositionSettings probePosition, ref CameraSettings cameraSettings, ref CameraPositionSettings cameraPosition)
		{
			Matrix4x4 matrix4x = Matrix4x4.TRS(probePosition.proxyPosition, probePosition.proxyRotation, Vector3.one);
			Vector3 positionWS = matrix4x.MultiplyPoint(settings.proxySettings.mirrorPositionProxySpace);
			Vector3 normalWS = matrix4x.MultiplyVector(settings.proxySettings.mirrorRotationProxySpace * Vector3.forward);
			Vector4 clipPlane = GeometryUtils.CameraSpacePlane(cameraPosition.worldToCameraMatrix, positionWS, normalWS, 1f, 0f);
			Matrix4x4 projectionMatrix = GeometryUtils.CalculateObliqueMatrix(Matrix4x4.Perspective(HDUtils.ClampFOV(cameraSettings.frustum.fieldOfView), cameraSettings.frustum.aspect, cameraSettings.frustum.nearClipPlane, cameraSettings.frustum.farClipPlane), clipPlane);
			cameraSettings.frustum.mode = CameraSettings.Frustum.Mode.UseProjectionMatrixField;
			cameraSettings.frustum.projectionMatrix = projectionMatrix;
		}

		// Token: 0x02000448 RID: 1096
		internal enum PositionMode
		{
			// Token: 0x040029A0 RID: 10656
			UseProbeTransform,
			// Token: 0x040029A1 RID: 10657
			MirrorReferenceTransformWithProbePlane
		}
	}
}
