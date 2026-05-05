using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000094 RID: 148
	internal static class VisibleLightExtensionMethods
	{
		// Token: 0x06000728 RID: 1832 RVA: 0x00047CA8 File Offset: 0x00045EA8
		public static Vector3 GetPosition(this VisibleLight value)
		{
			return value.localToWorldMatrix.GetColumn(3);
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x00047CCC File Offset: 0x00045ECC
		public static Vector3 GetForward(this VisibleLight value)
		{
			return value.localToWorldMatrix.GetColumn(2);
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x00047CF0 File Offset: 0x00045EF0
		public static Vector3 GetUp(this VisibleLight value)
		{
			return value.localToWorldMatrix.GetColumn(1);
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x00047D14 File Offset: 0x00045F14
		public static Vector3 GetRight(this VisibleLight value)
		{
			return value.localToWorldMatrix.GetColumn(0);
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x00047D38 File Offset: 0x00045F38
		public static VisibleLightExtensionMethods.VisibleLightAxisAndPosition GetAxisAndPosition(this VisibleLight value)
		{
			Matrix4x4 localToWorldMatrix = value.localToWorldMatrix;
			VisibleLightExtensionMethods.VisibleLightAxisAndPosition result;
			result.Position = localToWorldMatrix.GetColumn(3);
			result.Forward = localToWorldMatrix.GetColumn(2);
			result.Up = localToWorldMatrix.GetColumn(1);
			result.Right = localToWorldMatrix.GetColumn(0);
			return result;
		}

		// Token: 0x02000336 RID: 822
		public struct VisibleLightAxisAndPosition
		{
			// Token: 0x04002308 RID: 8968
			public Vector3 Position;

			// Token: 0x04002309 RID: 8969
			public Vector3 Forward;

			// Token: 0x0400230A RID: 8970
			public Vector3 Up;

			// Token: 0x0400230B RID: 8971
			public Vector3 Right;
		}
	}
}
