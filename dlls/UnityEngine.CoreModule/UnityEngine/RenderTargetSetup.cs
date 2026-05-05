using System;
using UnityEngine.Rendering;

namespace UnityEngine
{
	// Token: 0x02000157 RID: 343
	public struct RenderTargetSetup
	{
		// Token: 0x06000AD9 RID: 2777 RVA: 0x00011808 File Offset: 0x0000FA08
		public RenderTargetSetup(RenderBuffer[] color, RenderBuffer depth, int mip, CubemapFace face, RenderBufferLoadAction[] colorLoad, RenderBufferStoreAction[] colorStore, RenderBufferLoadAction depthLoad, RenderBufferStoreAction depthStore)
		{
			this.color = color;
			this.depth = depth;
			this.mipLevel = mip;
			this.cubemapFace = face;
			this.depthSlice = 0;
			this.colorLoad = colorLoad;
			this.colorStore = colorStore;
			this.depthLoad = depthLoad;
			this.depthStore = depthStore;
		}

		// Token: 0x06000ADA RID: 2778 RVA: 0x0001185C File Offset: 0x0000FA5C
		internal static RenderBufferLoadAction[] LoadActions(RenderBuffer[] buf)
		{
			RenderBufferLoadAction[] array = new RenderBufferLoadAction[buf.Length];
			for (int i = 0; i < buf.Length; i++)
			{
				array[i] = buf[i].loadAction;
				buf[i].loadAction = RenderBufferLoadAction.Load;
			}
			return array;
		}

		// Token: 0x06000ADB RID: 2779 RVA: 0x000118AC File Offset: 0x0000FAAC
		internal static RenderBufferStoreAction[] StoreActions(RenderBuffer[] buf)
		{
			RenderBufferStoreAction[] array = new RenderBufferStoreAction[buf.Length];
			for (int i = 0; i < buf.Length; i++)
			{
				array[i] = buf[i].storeAction;
				buf[i].storeAction = RenderBufferStoreAction.Store;
			}
			return array;
		}

		// Token: 0x06000ADC RID: 2780 RVA: 0x000118F9 File Offset: 0x0000FAF9
		public RenderTargetSetup(RenderBuffer color, RenderBuffer depth)
		{
			this = new RenderTargetSetup(new RenderBuffer[]
			{
				color
			}, depth);
		}

		// Token: 0x06000ADD RID: 2781 RVA: 0x00011912 File Offset: 0x0000FB12
		public RenderTargetSetup(RenderBuffer color, RenderBuffer depth, int mipLevel)
		{
			this = new RenderTargetSetup(new RenderBuffer[]
			{
				color
			}, depth, mipLevel);
		}

		// Token: 0x06000ADE RID: 2782 RVA: 0x0001192C File Offset: 0x0000FB2C
		public RenderTargetSetup(RenderBuffer color, RenderBuffer depth, int mipLevel, CubemapFace face)
		{
			this = new RenderTargetSetup(new RenderBuffer[]
			{
				color
			}, depth, mipLevel, face);
		}

		// Token: 0x06000ADF RID: 2783 RVA: 0x00011948 File Offset: 0x0000FB48
		public RenderTargetSetup(RenderBuffer color, RenderBuffer depth, int mipLevel, CubemapFace face, int depthSlice)
		{
			this = new RenderTargetSetup(new RenderBuffer[]
			{
				color
			}, depth, mipLevel, face);
			this.depthSlice = depthSlice;
		}

		// Token: 0x06000AE0 RID: 2784 RVA: 0x0001196C File Offset: 0x0000FB6C
		public RenderTargetSetup(RenderBuffer[] color, RenderBuffer depth)
		{
			this = new RenderTargetSetup(color, depth, 0, CubemapFace.Unknown);
		}

		// Token: 0x06000AE1 RID: 2785 RVA: 0x0001197A File Offset: 0x0000FB7A
		public RenderTargetSetup(RenderBuffer[] color, RenderBuffer depth, int mipLevel)
		{
			this = new RenderTargetSetup(color, depth, mipLevel, CubemapFace.Unknown);
		}

		// Token: 0x06000AE2 RID: 2786 RVA: 0x00011988 File Offset: 0x0000FB88
		public RenderTargetSetup(RenderBuffer[] color, RenderBuffer depth, int mip, CubemapFace face)
		{
			this = new RenderTargetSetup(color, depth, mip, face, RenderTargetSetup.LoadActions(color), RenderTargetSetup.StoreActions(color), depth.loadAction, depth.storeAction);
		}

		// Token: 0x04000449 RID: 1097
		public RenderBuffer[] color;

		// Token: 0x0400044A RID: 1098
		public RenderBuffer depth;

		// Token: 0x0400044B RID: 1099
		public int mipLevel;

		// Token: 0x0400044C RID: 1100
		public CubemapFace cubemapFace;

		// Token: 0x0400044D RID: 1101
		public int depthSlice;

		// Token: 0x0400044E RID: 1102
		public RenderBufferLoadAction[] colorLoad;

		// Token: 0x0400044F RID: 1103
		public RenderBufferStoreAction[] colorStore;

		// Token: 0x04000450 RID: 1104
		public RenderBufferLoadAction depthLoad;

		// Token: 0x04000451 RID: 1105
		public RenderBufferStoreAction depthStore;
	}
}
