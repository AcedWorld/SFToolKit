using System;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x02000019 RID: 25
	[VFXBinder("HDRP/HDRP Camera")]
	public class HDRPCameraBinder : VFXBinderBase
	{
		// Token: 0x06000022 RID: 34 RVA: 0x00002FE0 File Offset: 0x000011E0
		public void SetCameraProperty(string name)
		{
			this.CameraProperty = name;
			this.UpdateSubProperties();
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002FF4 File Offset: 0x000011F4
		private void UpdateSubProperties()
		{
			if (this.AdditionalData != null)
			{
				this.m_Camera = this.AdditionalData.GetComponent<Camera>();
			}
			this.m_Position = this.CameraProperty + "_transform_position";
			this.m_Angles = this.CameraProperty + "_transform_angles";
			this.m_Scale = this.CameraProperty + "_transform_scale";
			this.m_Orthographic = this.CameraProperty + "_orthographic";
			this.m_FieldOfView = this.CameraProperty + "_fieldOfView";
			this.m_NearPlane = this.CameraProperty + "_nearPlane";
			this.m_FarPlane = this.CameraProperty + "_farPlane";
			this.m_OrthographicSize = this.CameraProperty + "_orthographicSize";
			this.m_AspectRatio = this.CameraProperty + "_aspectRatio";
			this.m_Dimensions = this.CameraProperty + "_pixelDimensions";
			this.m_LensShift = this.CameraProperty + "_lensShift";
			this.m_DepthBuffer = this.CameraProperty + "_depthBuffer";
			this.m_ColorBuffer = this.CameraProperty + "_colorBuffer";
			this.m_ScaledDimensions = this.CameraProperty + "_scaledPixelDimensions";
		}

		// Token: 0x06000024 RID: 36 RVA: 0x0000319A File Offset: 0x0000139A
		private void RequestHDRPBuffersAccess(ref HDAdditionalCameraData.BufferAccess access)
		{
			access.RequestAccess(HDAdditionalCameraData.BufferAccessType.Color);
			access.RequestAccess(HDAdditionalCameraData.BufferAccessType.Depth);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000031AA File Offset: 0x000013AA
		protected override void OnEnable()
		{
			base.OnEnable();
			if (this.AdditionalData != null)
			{
				this.AdditionalData.requestGraphicsBuffer += this.RequestHDRPBuffersAccess;
			}
			this.UpdateSubProperties();
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000031DD File Offset: 0x000013DD
		protected override void OnDisable()
		{
			base.OnDisable();
			if (this.AdditionalData != null)
			{
				this.AdditionalData.requestGraphicsBuffer -= this.RequestHDRPBuffersAccess;
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000320A File Offset: 0x0000140A
		private void OnValidate()
		{
			this.UpdateSubProperties();
			if (this.AdditionalData != null)
			{
				this.AdditionalData.requestGraphicsBuffer += this.RequestHDRPBuffersAccess;
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00003238 File Offset: 0x00001438
		public override bool IsValid(VisualEffect component)
		{
			return this.AdditionalData != null && this.m_Camera != null && component.HasVector3(this.m_Position) && component.HasVector3(this.m_Angles) && component.HasVector3(this.m_Scale) && component.HasBool(this.m_Orthographic) && component.HasFloat(this.m_FieldOfView) && component.HasFloat(this.m_NearPlane) && component.HasFloat(this.m_FarPlane) && component.HasFloat(this.m_OrthographicSize) && component.HasFloat(this.m_AspectRatio) && component.HasVector2(this.m_Dimensions) && component.HasVector2(this.m_LensShift) && component.HasTexture(this.m_DepthBuffer) && component.HasTexture(this.m_ColorBuffer) && component.HasVector2(this.m_ScaledDimensions);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00003388 File Offset: 0x00001588
		public override void UpdateBinding(VisualEffect component)
		{
			RTHandle graphicsBuffer = this.AdditionalData.GetGraphicsBuffer(HDAdditionalCameraData.BufferAccessType.Depth);
			RTHandle graphicsBuffer2 = this.AdditionalData.GetGraphicsBuffer(HDAdditionalCameraData.BufferAccessType.Color);
			if (graphicsBuffer == null && graphicsBuffer2 == null)
			{
				return;
			}
			component.SetVector3(this.m_Position, this.AdditionalData.transform.position);
			component.SetVector3(this.m_Angles, this.AdditionalData.transform.eulerAngles);
			component.SetVector3(this.m_Scale, this.AdditionalData.transform.lossyScale);
			component.SetBool(this.m_Orthographic, this.m_Camera.orthographic);
			component.SetFloat(this.m_OrthographicSize, this.m_Camera.orthographicSize);
			component.SetFloat(this.m_FieldOfView, 0.017453292f * this.m_Camera.fieldOfView);
			component.SetFloat(this.m_NearPlane, this.m_Camera.nearClipPlane);
			component.SetFloat(this.m_FarPlane, this.m_Camera.farClipPlane);
			component.SetVector2(this.m_LensShift, this.m_Camera.lensShift);
			component.SetFloat(this.m_AspectRatio, this.m_Camera.aspect);
			component.SetVector2(this.m_Dimensions, new Vector2((float)this.m_Camera.pixelWidth, (float)this.m_Camera.pixelHeight));
			DynamicResolutionHandler.UpdateAndUseCamera(this.m_Camera, null, null);
			Vector2 v = DynamicResolutionHandler.instance.GetScaledSize(new Vector2Int(this.m_Camera.pixelWidth, this.m_Camera.pixelHeight));
			DynamicResolutionHandler.ClearSelectedCamera();
			component.SetVector2(this.m_ScaledDimensions, v);
			if (graphicsBuffer != null)
			{
				component.SetTexture(this.m_DepthBuffer, graphicsBuffer.rt);
			}
			if (graphicsBuffer2 != null)
			{
				component.SetTexture(this.m_ColorBuffer, graphicsBuffer2.rt);
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x0000359C File Offset: 0x0000179C
		public override string ToString()
		{
			return string.Format(string.Format("HDRP Camera : '{0}' -> {1}", (this.AdditionalData == null) ? "null" : this.AdditionalData.gameObject.name, this.CameraProperty), Array.Empty<object>());
		}

		// Token: 0x04000061 RID: 97
		public HDAdditionalCameraData AdditionalData;

		// Token: 0x04000062 RID: 98
		private Camera m_Camera;

		// Token: 0x04000063 RID: 99
		[VFXPropertyBinding(new string[]
		{
			"UnityEditor.VFX.CameraType"
		})]
		[SerializeField]
		private ExposedProperty CameraProperty = "Camera";

		// Token: 0x04000064 RID: 100
		private RTHandle m_Texture;

		// Token: 0x04000065 RID: 101
		private ExposedProperty m_Position;

		// Token: 0x04000066 RID: 102
		private ExposedProperty m_Angles;

		// Token: 0x04000067 RID: 103
		private ExposedProperty m_Scale;

		// Token: 0x04000068 RID: 104
		private ExposedProperty m_FieldOfView;

		// Token: 0x04000069 RID: 105
		private ExposedProperty m_NearPlane;

		// Token: 0x0400006A RID: 106
		private ExposedProperty m_FarPlane;

		// Token: 0x0400006B RID: 107
		private ExposedProperty m_AspectRatio;

		// Token: 0x0400006C RID: 108
		private ExposedProperty m_Dimensions;

		// Token: 0x0400006D RID: 109
		private ExposedProperty m_ScaledDimensions;

		// Token: 0x0400006E RID: 110
		private ExposedProperty m_DepthBuffer;

		// Token: 0x0400006F RID: 111
		private ExposedProperty m_ColorBuffer;

		// Token: 0x04000070 RID: 112
		private ExposedProperty m_Orthographic;

		// Token: 0x04000071 RID: 113
		private ExposedProperty m_OrthographicSize;

		// Token: 0x04000072 RID: 114
		private ExposedProperty m_LensShift;
	}
}
