using System;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Experimental.U2D
{
	// Token: 0x020004B6 RID: 1206
	[RequiredByNativeCode]
	[NativeHeader("Runtime/2D/Renderer/SpriteRendererGroup.h")]
	internal struct SpriteIntermediateRendererInfo
	{
		// Token: 0x04000F95 RID: 3989
		public int SpriteID;

		// Token: 0x04000F96 RID: 3990
		public int TextureID;

		// Token: 0x04000F97 RID: 3991
		public int MaterialID;

		// Token: 0x04000F98 RID: 3992
		public Color Color;

		// Token: 0x04000F99 RID: 3993
		public Matrix4x4 Transform;

		// Token: 0x04000F9A RID: 3994
		public Bounds Bounds;

		// Token: 0x04000F9B RID: 3995
		public int Layer;

		// Token: 0x04000F9C RID: 3996
		public int SortingLayer;

		// Token: 0x04000F9D RID: 3997
		public int SortingOrder;

		// Token: 0x04000F9E RID: 3998
		public ulong SceneCullingMask;

		// Token: 0x04000F9F RID: 3999
		public IntPtr IndexData;

		// Token: 0x04000FA0 RID: 4000
		public IntPtr VertexData;

		// Token: 0x04000FA1 RID: 4001
		public int IndexCount;

		// Token: 0x04000FA2 RID: 4002
		public int VertexCount;

		// Token: 0x04000FA3 RID: 4003
		public int ShaderChannelMask;
	}
}
