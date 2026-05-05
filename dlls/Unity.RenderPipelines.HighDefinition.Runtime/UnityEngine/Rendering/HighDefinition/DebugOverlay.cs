using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200003A RID: 58
	public class DebugOverlay
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600020B RID: 523 RVA: 0x0000C1CC File Offset: 0x0000A3CC
		// (set) Token: 0x0600020C RID: 524 RVA: 0x0000C1D4 File Offset: 0x0000A3D4
		public int x { get; private set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600020D RID: 525 RVA: 0x0000C1DD File Offset: 0x0000A3DD
		// (set) Token: 0x0600020E RID: 526 RVA: 0x0000C1E5 File Offset: 0x0000A3E5
		public int y { get; private set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600020F RID: 527 RVA: 0x0000C1EE File Offset: 0x0000A3EE
		// (set) Token: 0x06000210 RID: 528 RVA: 0x0000C1F6 File Offset: 0x0000A3F6
		public int overlaySize { get; private set; }

		// Token: 0x06000211 RID: 529 RVA: 0x0000C1FF File Offset: 0x0000A3FF
		public void StartOverlay(int initialX, int initialY, int overlaySize, int screenWidth)
		{
			this.x = initialX;
			this.y = initialY;
			this.overlaySize = overlaySize;
			this.m_InitialPositionX = initialX;
			this.m_ScreenWidth = screenWidth;
		}

		// Token: 0x06000212 RID: 530 RVA: 0x0000C228 File Offset: 0x0000A428
		public Rect Next(float aspect = 1f)
		{
			int num = (int)((float)this.overlaySize * aspect);
			if (this.x + num > this.m_ScreenWidth && this.x > this.m_InitialPositionX)
			{
				this.x = this.m_InitialPositionX;
				this.y -= this.overlaySize;
			}
			Rect result = new Rect((float)this.x, (float)this.y, (float)num, (float)this.overlaySize);
			this.x += num;
			return result;
		}

		// Token: 0x06000213 RID: 531 RVA: 0x0000C2A7 File Offset: 0x0000A4A7
		public void SetViewport(CommandBuffer cmd)
		{
			cmd.SetViewport(new Rect((float)this.x, (float)this.y, (float)this.overlaySize, (float)this.overlaySize));
		}

		// Token: 0x04000170 RID: 368
		private int m_InitialPositionX;

		// Token: 0x04000171 RID: 369
		private int m_ScreenWidth;
	}
}
