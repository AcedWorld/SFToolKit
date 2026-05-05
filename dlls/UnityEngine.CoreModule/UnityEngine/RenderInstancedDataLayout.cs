using System;
using System.Runtime.InteropServices;

namespace UnityEngine
{
	// Token: 0x02000159 RID: 345
	internal readonly struct RenderInstancedDataLayout
	{
		// Token: 0x06000AFE RID: 2814 RVA: 0x00011B24 File Offset: 0x0000FD24
		public RenderInstancedDataLayout(Type t)
		{
			this.size = Marshal.SizeOf(t);
			this.offsetObjectToWorld = ((t == typeof(Matrix4x4)) ? 0 : Marshal.OffsetOf(t, "objectToWorld").ToInt32());
			try
			{
				this.offsetPrevObjectToWorld = Marshal.OffsetOf(t, "prevObjectToWorld").ToInt32();
			}
			catch (ArgumentException)
			{
				this.offsetPrevObjectToWorld = -1;
			}
			try
			{
				this.offsetRenderingLayerMask = Marshal.OffsetOf(t, "renderingLayerMask").ToInt32();
			}
			catch (ArgumentException)
			{
				this.offsetRenderingLayerMask = -1;
			}
		}

		// Token: 0x17000240 RID: 576
		// (get) Token: 0x06000AFF RID: 2815 RVA: 0x00011BDC File Offset: 0x0000FDDC
		public int size { get; }

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x06000B00 RID: 2816 RVA: 0x00011BE4 File Offset: 0x0000FDE4
		public int offsetObjectToWorld { get; }

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x06000B01 RID: 2817 RVA: 0x00011BEC File Offset: 0x0000FDEC
		public int offsetPrevObjectToWorld { get; }

		// Token: 0x17000243 RID: 579
		// (get) Token: 0x06000B02 RID: 2818 RVA: 0x00011BF4 File Offset: 0x0000FDF4
		public int offsetRenderingLayerMask { get; }
	}
}
