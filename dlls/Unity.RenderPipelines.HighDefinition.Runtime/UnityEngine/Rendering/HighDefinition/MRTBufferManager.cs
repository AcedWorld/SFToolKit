using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200016E RID: 366
	internal abstract class MRTBufferManager
	{
		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06000C27 RID: 3111 RVA: 0x0006484F File Offset: 0x00062A4F
		public int bufferCount
		{
			get
			{
				return this.m_BufferCount;
			}
		}

		// Token: 0x06000C28 RID: 3112 RVA: 0x00064857 File Offset: 0x00062A57
		public MRTBufferManager(int maxBufferCount)
		{
			this.m_BufferCount = maxBufferCount;
			this.m_RTIDs = new RenderTargetIdentifier[maxBufferCount];
			this.m_RTs = new RTHandle[maxBufferCount];
			this.m_TextureShaderIDs = new int[maxBufferCount];
		}

		// Token: 0x06000C29 RID: 3113 RVA: 0x0006488C File Offset: 0x00062A8C
		public RenderTargetIdentifier[] GetBuffersRTI()
		{
			for (int i = 0; i < this.m_BufferCount; i++)
			{
				this.m_RTIDs[i] = this.m_RTs[i].nameID;
			}
			return this.m_RTIDs;
		}

		// Token: 0x06000C2A RID: 3114 RVA: 0x000648C9 File Offset: 0x00062AC9
		public RTHandle[] GetBuffers()
		{
			return this.m_RTs;
		}

		// Token: 0x06000C2B RID: 3115 RVA: 0x000648D1 File Offset: 0x00062AD1
		public RTHandle GetBuffer(int index)
		{
			return this.m_RTs[index];
		}

		// Token: 0x06000C2C RID: 3116
		public abstract void CreateBuffers();

		// Token: 0x06000C2D RID: 3117 RVA: 0x000648DC File Offset: 0x00062ADC
		public virtual void BindBufferAsTextures(CommandBuffer cmd)
		{
			for (int i = 0; i < this.m_BufferCount; i++)
			{
				cmd.SetGlobalTexture(this.m_TextureShaderIDs[i], this.m_RTs[i]);
			}
		}

		// Token: 0x06000C2E RID: 3118 RVA: 0x00064918 File Offset: 0x00062B18
		public virtual void DestroyBuffers()
		{
			for (int i = 0; i < this.m_BufferCount; i++)
			{
				RTHandles.Release(this.m_RTs[i]);
				this.m_RTs[i] = null;
			}
		}

		// Token: 0x040012BA RID: 4794
		protected int m_BufferCount;

		// Token: 0x040012BB RID: 4795
		protected RenderTargetIdentifier[] m_RTIDs;

		// Token: 0x040012BC RID: 4796
		protected RTHandle[] m_RTs;

		// Token: 0x040012BD RID: 4797
		protected int[] m_TextureShaderIDs;
	}
}
