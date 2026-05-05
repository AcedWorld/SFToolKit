using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000200 RID: 512
	[Serializable]
	public struct CameraPositionSettings
	{
		// Token: 0x06000F65 RID: 3941 RVA: 0x0007801C File Offset: 0x0007621C
		public static CameraPositionSettings NewDefault()
		{
			return new CameraPositionSettings
			{
				mode = CameraPositionSettings.Mode.ComputeWorldToCameraMatrix,
				position = Vector3.zero,
				rotation = Quaternion.identity,
				worldToCameraMatrix = Matrix4x4.identity
			};
		}

		// Token: 0x06000F66 RID: 3942 RVA: 0x0007805E File Offset: 0x0007625E
		public Matrix4x4 ComputeWorldToCameraMatrix()
		{
			return GeometryUtils.CalculateWorldToCameraMatrixRHS(this.position, this.rotation);
		}

		// Token: 0x06000F67 RID: 3943 RVA: 0x00078074 File Offset: 0x00076274
		public Matrix4x4 GetUsedWorldToCameraMatrix()
		{
			CameraPositionSettings.Mode mode = this.mode;
			if (mode == CameraPositionSettings.Mode.ComputeWorldToCameraMatrix)
			{
				return this.ComputeWorldToCameraMatrix();
			}
			if (mode != CameraPositionSettings.Mode.UseWorldToCameraMatrixField)
			{
				throw new ArgumentException();
			}
			return this.worldToCameraMatrix;
		}

		// Token: 0x040017DC RID: 6108
		[Obsolete("Since 2019.3, use CameraPositionSettings.NewDefault() instead.")]
		public static readonly CameraPositionSettings @default;

		// Token: 0x040017DD RID: 6109
		public CameraPositionSettings.Mode mode;

		// Token: 0x040017DE RID: 6110
		public Vector3 position;

		// Token: 0x040017DF RID: 6111
		public Quaternion rotation;

		// Token: 0x040017E0 RID: 6112
		public Matrix4x4 worldToCameraMatrix;

		// Token: 0x02000439 RID: 1081
		public enum Mode
		{
			// Token: 0x04002968 RID: 10600
			ComputeWorldToCameraMatrix,
			// Token: 0x04002969 RID: 10601
			UseWorldToCameraMatrixField
		}
	}
}
