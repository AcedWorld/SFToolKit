using System;
using UnityEngine;

namespace Cinemachine
{
	// Token: 0x02000048 RID: 72
	[DocumentationSorting(DocumentationSortingAttribute.Level.UserRef)]
	[Serializable]
	public struct LensSettings
	{
		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000330 RID: 816 RVA: 0x00014386 File Offset: 0x00012586
		// (set) Token: 0x06000331 RID: 817 RVA: 0x000143A3 File Offset: 0x000125A3
		public bool Orthographic
		{
			get
			{
				return this.ModeOverride == LensSettings.OverrideModes.Orthographic || (this.ModeOverride == LensSettings.OverrideModes.None && this.m_OrthoFromCamera);
			}
			set
			{
				this.m_OrthoFromCamera = value;
				this.ModeOverride = (value ? LensSettings.OverrideModes.Orthographic : LensSettings.OverrideModes.Perspective);
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000332 RID: 818 RVA: 0x000143B9 File Offset: 0x000125B9
		// (set) Token: 0x06000333 RID: 819 RVA: 0x000143C1 File Offset: 0x000125C1
		public Vector2 SensorSize
		{
			get
			{
				return this.m_SensorSize;
			}
			set
			{
				this.m_SensorSize = value;
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000334 RID: 820 RVA: 0x000143CA File Offset: 0x000125CA
		public float Aspect
		{
			get
			{
				if (this.SensorSize.y != 0f)
				{
					return this.SensorSize.x / this.SensorSize.y;
				}
				return 1f;
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000335 RID: 821 RVA: 0x000143FB File Offset: 0x000125FB
		// (set) Token: 0x06000336 RID: 822 RVA: 0x00014418 File Offset: 0x00012618
		public bool IsPhysicalCamera
		{
			get
			{
				return this.ModeOverride == LensSettings.OverrideModes.Physical || (this.ModeOverride == LensSettings.OverrideModes.None && this.m_PhysicalFromCamera);
			}
			set
			{
				this.m_PhysicalFromCamera = value;
				this.ModeOverride = (value ? LensSettings.OverrideModes.Physical : LensSettings.OverrideModes.Perspective);
			}
		}

		// Token: 0x06000337 RID: 823 RVA: 0x00014430 File Offset: 0x00012630
		public static LensSettings FromCamera(Camera fromCamera)
		{
			LensSettings @default = LensSettings.Default;
			if (fromCamera != null)
			{
				@default.FieldOfView = fromCamera.fieldOfView;
				@default.OrthographicSize = fromCamera.orthographicSize;
				@default.NearClipPlane = fromCamera.nearClipPlane;
				@default.FarClipPlane = fromCamera.farClipPlane;
				@default.LensShift = fromCamera.lensShift;
				@default.GateFit = fromCamera.gateFit;
				@default.FocusDistance = fromCamera.focusDistance;
				@default.SnapshotCameraReadOnlyProperties(fromCamera);
				if (@default.IsPhysicalCamera)
				{
					@default.Iso = fromCamera.iso;
					@default.ShutterSpeed = fromCamera.shutterSpeed;
					@default.Aperture = fromCamera.aperture;
					@default.BladeCount = fromCamera.bladeCount;
					@default.Curvature = fromCamera.curvature;
					@default.BarrelClipping = fromCamera.barrelClipping;
					@default.Anamorphism = fromCamera.anamorphism;
				}
			}
			return @default;
		}

		// Token: 0x06000338 RID: 824 RVA: 0x00014518 File Offset: 0x00012718
		public void SnapshotCameraReadOnlyProperties(Camera camera)
		{
			this.m_OrthoFromCamera = false;
			this.m_PhysicalFromCamera = false;
			if (camera != null && this.ModeOverride == LensSettings.OverrideModes.None)
			{
				this.m_OrthoFromCamera = camera.orthographic;
				this.m_PhysicalFromCamera = camera.usePhysicalProperties;
				this.m_SensorSize = camera.sensorSize;
				this.GateFit = camera.gateFit;
			}
			if (this.IsPhysicalCamera)
			{
				if (camera != null && this.m_SensorSize == Vector2.zero)
				{
					this.m_SensorSize = camera.sensorSize;
					this.GateFit = camera.gateFit;
					return;
				}
			}
			else
			{
				if (camera != null)
				{
					this.m_SensorSize = new Vector2(camera.aspect, 1f);
				}
				this.LensShift = Vector2.zero;
			}
		}

		// Token: 0x06000339 RID: 825 RVA: 0x000145DC File Offset: 0x000127DC
		public void SnapshotCameraReadOnlyProperties(ref LensSettings lens)
		{
			if (this.ModeOverride == LensSettings.OverrideModes.None)
			{
				this.m_OrthoFromCamera = lens.Orthographic;
				this.m_SensorSize = lens.m_SensorSize;
				this.m_PhysicalFromCamera = lens.IsPhysicalCamera;
			}
			if (!this.IsPhysicalCamera)
			{
				this.LensShift = Vector2.zero;
			}
		}

		// Token: 0x0600033A RID: 826 RVA: 0x00014628 File Offset: 0x00012828
		public LensSettings(float verticalFOV, float orthographicSize, float nearClip, float farClip, float dutch)
		{
			this = default(LensSettings);
			this.FieldOfView = verticalFOV;
			this.OrthographicSize = orthographicSize;
			this.NearClipPlane = nearClip;
			this.FarClipPlane = farClip;
			this.Dutch = dutch;
			this.m_SensorSize = new Vector2(1f, 1f);
			this.GateFit = Camera.GateFitMode.Horizontal;
			this.FocusDistance = 10f;
			this.Iso = 200;
			this.ShutterSpeed = 0.005f;
			this.Aperture = 16f;
			this.BladeCount = 5;
			this.Curvature = new Vector2(2f, 11f);
			this.BarrelClipping = 0.25f;
			this.Anamorphism = 0f;
		}

		// Token: 0x0600033B RID: 827 RVA: 0x000146DC File Offset: 0x000128DC
		public static LensSettings Lerp(LensSettings lensA, LensSettings lensB, float t)
		{
			t = Mathf.Clamp01(t);
			LensSettings result = (t < 0.5f) ? lensA : lensB;
			result.FarClipPlane = Mathf.Lerp(lensA.FarClipPlane, lensB.FarClipPlane, t);
			result.NearClipPlane = Mathf.Lerp(lensA.NearClipPlane, lensB.NearClipPlane, t);
			result.FieldOfView = Mathf.Lerp(lensA.FieldOfView, lensB.FieldOfView, t);
			result.OrthographicSize = Mathf.Lerp(lensA.OrthographicSize, lensB.OrthographicSize, t);
			result.Dutch = Mathf.Lerp(lensA.Dutch, lensB.Dutch, t);
			result.m_SensorSize = Vector2.Lerp(lensA.m_SensorSize, lensB.m_SensorSize, t);
			result.LensShift = Vector2.Lerp(lensA.LensShift, lensB.LensShift, t);
			result.FocusDistance = Mathf.Lerp(lensA.FocusDistance, lensB.FocusDistance, t);
			result.Iso = Mathf.RoundToInt(Mathf.Lerp((float)lensA.Iso, (float)lensB.Iso, t));
			result.ShutterSpeed = Mathf.Lerp(lensA.ShutterSpeed, lensB.ShutterSpeed, t);
			result.Aperture = Mathf.Lerp(lensA.Aperture, lensB.Aperture, t);
			result.BladeCount = Mathf.RoundToInt(Mathf.Lerp((float)lensA.BladeCount, (float)lensB.BladeCount, t));
			result.Curvature = Vector2.Lerp(lensA.Curvature, lensB.Curvature, t);
			result.BarrelClipping = Mathf.Lerp(lensA.BarrelClipping, lensB.BarrelClipping, t);
			result.Anamorphism = Mathf.Lerp(lensA.Anamorphism, lensB.Anamorphism, t);
			return result;
		}

		// Token: 0x0600033C RID: 828 RVA: 0x00014884 File Offset: 0x00012A84
		public void Validate()
		{
			this.FarClipPlane = Mathf.Max(this.FarClipPlane, this.NearClipPlane + 0.001f);
			this.FieldOfView = Mathf.Clamp(this.FieldOfView, 0.01f, 179f);
			this.m_SensorSize.x = Mathf.Max(this.m_SensorSize.x, 0.1f);
			this.m_SensorSize.y = Mathf.Max(this.m_SensorSize.y, 0.1f);
			this.FocusDistance = Mathf.Max(this.FocusDistance, 0.01f);
			this.ShutterSpeed = Mathf.Max(0f, this.ShutterSpeed);
			this.Aperture = Mathf.Clamp(this.Aperture, 0.7f, 32f);
			this.BladeCount = Mathf.Clamp(this.BladeCount, 3, 11);
			this.BarrelClipping = Mathf.Clamp01(this.BarrelClipping);
			this.Curvature.x = Mathf.Clamp(this.Curvature.x, 0.7f, 32f);
			this.Curvature.y = Mathf.Clamp(this.Curvature.y, this.Curvature.x, 32f);
			this.Anamorphism = Mathf.Clamp(this.Anamorphism, -1f, 1f);
		}

		// Token: 0x0400021D RID: 541
		public static LensSettings Default = new LensSettings(40f, 10f, 0.1f, 5000f, 0f);

		// Token: 0x0400021E RID: 542
		[Range(1f, 179f)]
		[Tooltip("This is the camera view in degrees. Display will be in vertical degress, unless the associated camera has its FOV axis setting set to Horizontal, in which case display will be in horizontal degress.  Internally, it is always vertical degrees.  For cinematic people, a 50mm lens on a super-35mm sensor would equal a 19.6 degree FOV")]
		public float FieldOfView;

		// Token: 0x0400021F RID: 543
		[Tooltip("When using an orthographic camera, this defines the half-height, in world coordinates, of the camera view.")]
		public float OrthographicSize;

		// Token: 0x04000220 RID: 544
		[Tooltip("This defines the near region in the renderable range of the camera frustum. Raising this value will stop the game from drawing things near the camera, which can sometimes come in handy.  Larger values will also increase your shadow resolution.")]
		public float NearClipPlane;

		// Token: 0x04000221 RID: 545
		[Tooltip("This defines the far region of the renderable range of the camera frustum. Typically you want to set this value as low as possible without cutting off desired distant objects")]
		public float FarClipPlane;

		// Token: 0x04000222 RID: 546
		[Range(-180f, 180f)]
		[Tooltip("Camera Z roll, or tilt, in degrees.")]
		public float Dutch;

		// Token: 0x04000223 RID: 547
		[Tooltip("Allows you to select a different camera mode to apply to the Camera component when Cinemachine activates this Virtual Camera.  The changes applied to the Camera component through this setting will remain after the Virtual Camera deactivation.")]
		public LensSettings.OverrideModes ModeOverride;

		// Token: 0x04000224 RID: 548
		public Vector2 LensShift;

		// Token: 0x04000225 RID: 549
		public Camera.GateFitMode GateFit;

		// Token: 0x04000226 RID: 550
		public float FocusDistance;

		// Token: 0x04000227 RID: 551
		[SerializeField]
		private Vector2 m_SensorSize;

		// Token: 0x04000228 RID: 552
		private bool m_OrthoFromCamera;

		// Token: 0x04000229 RID: 553
		private bool m_PhysicalFromCamera;

		// Token: 0x0400022A RID: 554
		public int Iso;

		// Token: 0x0400022B RID: 555
		public float ShutterSpeed;

		// Token: 0x0400022C RID: 556
		[Range(0.7f, 32f)]
		public float Aperture;

		// Token: 0x0400022D RID: 557
		[Range(3f, 11f)]
		public int BladeCount;

		// Token: 0x0400022E RID: 558
		public Vector2 Curvature;

		// Token: 0x0400022F RID: 559
		[Range(0f, 1f)]
		public float BarrelClipping;

		// Token: 0x04000230 RID: 560
		[Range(-1f, 1f)]
		public float Anamorphism;

		// Token: 0x020000B9 RID: 185
		public enum OverrideModes
		{
			// Token: 0x040003B8 RID: 952
			None,
			// Token: 0x040003B9 RID: 953
			Orthographic,
			// Token: 0x040003BA RID: 954
			Perspective,
			// Token: 0x040003BB RID: 955
			Physical
		}
	}
}
