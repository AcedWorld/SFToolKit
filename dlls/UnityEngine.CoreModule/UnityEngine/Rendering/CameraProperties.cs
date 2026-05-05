using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering
{
	// Token: 0x0200044B RID: 1099
	[UsedByNativeCode]
	public struct CameraProperties : IEquatable<CameraProperties>
	{
		// Token: 0x060024DB RID: 9435 RVA: 0x0003DFF8 File Offset: 0x0003C1F8
		public unsafe Plane GetShadowCullingPlane(int index)
		{
			bool flag = index < 0 || index >= 6;
			if (flag)
			{
				throw new ArgumentOutOfRangeException(string.Format("{0} was {1}, but must be at least 0 and less than {2}", "index", index, 6));
			}
			fixed (byte* ptr = &this.m_ShadowCullPlanes.FixedElementField)
			{
				byte* ptr2 = ptr;
				Plane* ptr3 = (Plane*)ptr2;
				return ptr3[index];
			}
		}

		// Token: 0x060024DC RID: 9436 RVA: 0x0003E064 File Offset: 0x0003C264
		public unsafe void SetShadowCullingPlane(int index, Plane plane)
		{
			bool flag = index < 0 || index >= 6;
			if (flag)
			{
				throw new ArgumentOutOfRangeException(string.Format("{0} was {1}, but must be at least 0 and less than {2}", "index", index, 6));
			}
			fixed (byte* ptr = &this.m_ShadowCullPlanes.FixedElementField)
			{
				byte* ptr2 = ptr;
				Plane* ptr3 = (Plane*)ptr2;
				ptr3[index] = plane;
			}
		}

		// Token: 0x060024DD RID: 9437 RVA: 0x0003E0D0 File Offset: 0x0003C2D0
		public unsafe Plane GetCameraCullingPlane(int index)
		{
			bool flag = index < 0 || index >= 6;
			if (flag)
			{
				throw new ArgumentOutOfRangeException(string.Format("{0} was {1}, but must be at least 0 and less than {2}", "index", index, 6));
			}
			fixed (byte* ptr = &this.m_CameraCullPlanes.FixedElementField)
			{
				byte* ptr2 = ptr;
				Plane* ptr3 = (Plane*)ptr2;
				return ptr3[index];
			}
		}

		// Token: 0x060024DE RID: 9438 RVA: 0x0003E13C File Offset: 0x0003C33C
		public unsafe void SetCameraCullingPlane(int index, Plane plane)
		{
			bool flag = index < 0 || index >= 6;
			if (flag)
			{
				throw new ArgumentOutOfRangeException(string.Format("{0} was {1}, but must be at least 0 and less than {2}", "index", index, 6));
			}
			fixed (byte* ptr = &this.m_CameraCullPlanes.FixedElementField)
			{
				byte* ptr2 = ptr;
				Plane* ptr3 = (Plane*)ptr2;
				ptr3[index] = plane;
			}
		}

		// Token: 0x060024DF RID: 9439 RVA: 0x0003E1A8 File Offset: 0x0003C3A8
		public unsafe bool Equals(CameraProperties other)
		{
			for (int i = 0; i < 6; i++)
			{
				bool flag = !this.GetShadowCullingPlane(i).Equals(other.GetShadowCullingPlane(i));
				if (flag)
				{
					return false;
				}
			}
			for (int j = 0; j < 6; j++)
			{
				bool flag2 = !this.GetCameraCullingPlane(j).Equals(other.GetCameraCullingPlane(j));
				if (flag2)
				{
					return false;
				}
			}
			fixed (float* ptr = &this.layerCullDistances.FixedElementField)
			{
				float* ptr2 = ptr;
				for (int k = 0; k < 32; k++)
				{
					bool flag3 = ptr2[k] != *(ref other.layerCullDistances.FixedElementField + (IntPtr)k * 4);
					if (flag3)
					{
						return false;
					}
				}
			}
			return this.screenRect.Equals(other.screenRect) && this.viewDir.Equals(other.viewDir) && this.projectionNear.Equals(other.projectionNear) && this.projectionFar.Equals(other.projectionFar) && this.cameraNear.Equals(other.cameraNear) && this.cameraFar.Equals(other.cameraFar) && this.cameraAspect.Equals(other.cameraAspect) && this.cameraToWorld.Equals(other.cameraToWorld) && this.actualWorldToClip.Equals(other.actualWorldToClip) && this.cameraClipToWorld.Equals(other.cameraClipToWorld) && this.cameraWorldToClip.Equals(other.cameraWorldToClip) && this.implicitProjection.Equals(other.implicitProjection) && this.stereoWorldToClipLeft.Equals(other.stereoWorldToClipLeft) && this.stereoWorldToClipRight.Equals(other.stereoWorldToClipRight) && this.worldToCamera.Equals(other.worldToCamera) && this.up.Equals(other.up) && this.right.Equals(other.right) && this.transformDirection.Equals(other.transformDirection) && this.cameraEuler.Equals(other.cameraEuler) && this.velocity.Equals(other.velocity) && this.farPlaneWorldSpaceLength.Equals(other.farPlaneWorldSpaceLength) && this.rendererCount == other.rendererCount && this.baseFarDistance.Equals(other.baseFarDistance) && this.shadowCullCenter.Equals(other.shadowCullCenter) && this.layerCullSpherical == other.layerCullSpherical && this.coreCameraValues.Equals(other.coreCameraValues) && this.cameraType == other.cameraType && this.projectionIsOblique == other.projectionIsOblique && this.isImplicitProjectionMatrix == other.isImplicitProjectionMatrix;
		}

		// Token: 0x060024E0 RID: 9440 RVA: 0x0003E4FC File Offset: 0x0003C6FC
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return !flag && obj is CameraProperties && this.Equals((CameraProperties)obj);
		}

		// Token: 0x060024E1 RID: 9441 RVA: 0x0003E534 File Offset: 0x0003C734
		public unsafe override int GetHashCode()
		{
			int num = this.screenRect.GetHashCode();
			num = (num * 397 ^ this.viewDir.GetHashCode());
			num = (num * 397 ^ this.projectionNear.GetHashCode());
			num = (num * 397 ^ this.projectionFar.GetHashCode());
			num = (num * 397 ^ this.cameraNear.GetHashCode());
			num = (num * 397 ^ this.cameraFar.GetHashCode());
			num = (num * 397 ^ this.cameraAspect.GetHashCode());
			num = (num * 397 ^ this.cameraToWorld.GetHashCode());
			num = (num * 397 ^ this.actualWorldToClip.GetHashCode());
			num = (num * 397 ^ this.cameraClipToWorld.GetHashCode());
			num = (num * 397 ^ this.cameraWorldToClip.GetHashCode());
			num = (num * 397 ^ this.implicitProjection.GetHashCode());
			num = (num * 397 ^ this.stereoWorldToClipLeft.GetHashCode());
			num = (num * 397 ^ this.stereoWorldToClipRight.GetHashCode());
			num = (num * 397 ^ this.worldToCamera.GetHashCode());
			num = (num * 397 ^ this.up.GetHashCode());
			num = (num * 397 ^ this.right.GetHashCode());
			num = (num * 397 ^ this.transformDirection.GetHashCode());
			num = (num * 397 ^ this.cameraEuler.GetHashCode());
			num = (num * 397 ^ this.velocity.GetHashCode());
			num = (num * 397 ^ this.farPlaneWorldSpaceLength.GetHashCode());
			num = (num * 397 ^ (int)this.rendererCount);
			for (int i = 0; i < 6; i++)
			{
				num = (num * 397 ^ this.GetShadowCullingPlane(i).GetHashCode());
			}
			for (int j = 0; j < 6; j++)
			{
				num = (num * 397 ^ this.GetCameraCullingPlane(j).GetHashCode());
			}
			num = (num * 397 ^ this.baseFarDistance.GetHashCode());
			num = (num * 397 ^ this.shadowCullCenter.GetHashCode());
			fixed (float* ptr = &this.layerCullDistances.FixedElementField)
			{
				float* ptr2 = ptr;
				for (int k = 0; k < 32; k++)
				{
					num = (num * 397 ^ ptr2[k].GetHashCode());
				}
			}
			num = (num * 397 ^ this.layerCullSpherical);
			num = (num * 397 ^ this.coreCameraValues.GetHashCode());
			num = (num * 397 ^ (int)this.cameraType);
			num = (num * 397 ^ this.projectionIsOblique);
			return num * 397 ^ this.isImplicitProjectionMatrix;
		}

		// Token: 0x060024E2 RID: 9442 RVA: 0x0003E884 File Offset: 0x0003CA84
		public static bool operator ==(CameraProperties left, CameraProperties right)
		{
			return left.Equals(right);
		}

		// Token: 0x060024E3 RID: 9443 RVA: 0x0003E8A0 File Offset: 0x0003CAA0
		public static bool operator !=(CameraProperties left, CameraProperties right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04000DB1 RID: 3505
		private const int k_NumLayers = 32;

		// Token: 0x04000DB2 RID: 3506
		private Rect screenRect;

		// Token: 0x04000DB3 RID: 3507
		private Vector3 viewDir;

		// Token: 0x04000DB4 RID: 3508
		private float projectionNear;

		// Token: 0x04000DB5 RID: 3509
		private float projectionFar;

		// Token: 0x04000DB6 RID: 3510
		private float cameraNear;

		// Token: 0x04000DB7 RID: 3511
		private float cameraFar;

		// Token: 0x04000DB8 RID: 3512
		private float cameraAspect;

		// Token: 0x04000DB9 RID: 3513
		private Matrix4x4 cameraToWorld;

		// Token: 0x04000DBA RID: 3514
		private Matrix4x4 actualWorldToClip;

		// Token: 0x04000DBB RID: 3515
		private Matrix4x4 cameraClipToWorld;

		// Token: 0x04000DBC RID: 3516
		private Matrix4x4 cameraWorldToClip;

		// Token: 0x04000DBD RID: 3517
		private Matrix4x4 implicitProjection;

		// Token: 0x04000DBE RID: 3518
		private Matrix4x4 stereoWorldToClipLeft;

		// Token: 0x04000DBF RID: 3519
		private Matrix4x4 stereoWorldToClipRight;

		// Token: 0x04000DC0 RID: 3520
		private Matrix4x4 worldToCamera;

		// Token: 0x04000DC1 RID: 3521
		private Vector3 up;

		// Token: 0x04000DC2 RID: 3522
		private Vector3 right;

		// Token: 0x04000DC3 RID: 3523
		private Vector3 transformDirection;

		// Token: 0x04000DC4 RID: 3524
		private Vector3 cameraEuler;

		// Token: 0x04000DC5 RID: 3525
		private Vector3 velocity;

		// Token: 0x04000DC6 RID: 3526
		private float farPlaneWorldSpaceLength;

		// Token: 0x04000DC7 RID: 3527
		private uint rendererCount;

		// Token: 0x04000DC8 RID: 3528
		private const int k_PlaneCount = 6;

		// Token: 0x04000DC9 RID: 3529
		[FixedBuffer(typeof(byte), 96)]
		internal CameraProperties.<m_ShadowCullPlanes>e__FixedBuffer m_ShadowCullPlanes;

		// Token: 0x04000DCA RID: 3530
		[FixedBuffer(typeof(byte), 96)]
		internal CameraProperties.<m_CameraCullPlanes>e__FixedBuffer m_CameraCullPlanes;

		// Token: 0x04000DCB RID: 3531
		private float baseFarDistance;

		// Token: 0x04000DCC RID: 3532
		private Vector3 shadowCullCenter;

		// Token: 0x04000DCD RID: 3533
		[FixedBuffer(typeof(float), 32)]
		internal CameraProperties.<layerCullDistances>e__FixedBuffer layerCullDistances;

		// Token: 0x04000DCE RID: 3534
		private int layerCullSpherical;

		// Token: 0x04000DCF RID: 3535
		private CoreCameraValues coreCameraValues;

		// Token: 0x04000DD0 RID: 3536
		private uint cameraType;

		// Token: 0x04000DD1 RID: 3537
		private int projectionIsOblique;

		// Token: 0x04000DD2 RID: 3538
		private int isImplicitProjectionMatrix;

		// Token: 0x0200044C RID: 1100
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 128)]
		public struct <layerCullDistances>e__FixedBuffer
		{
			// Token: 0x04000DD3 RID: 3539
			public float FixedElementField;
		}

		// Token: 0x0200044D RID: 1101
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 96)]
		public struct <m_CameraCullPlanes>e__FixedBuffer
		{
			// Token: 0x04000DD4 RID: 3540
			public byte FixedElementField;
		}

		// Token: 0x0200044E RID: 1102
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 96)]
		public struct <m_ShadowCullPlanes>e__FixedBuffer
		{
			// Token: 0x04000DD5 RID: 3541
			public byte FixedElementField;
		}
	}
}
