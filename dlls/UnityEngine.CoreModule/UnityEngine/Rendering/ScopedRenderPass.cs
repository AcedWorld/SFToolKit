using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200046D RID: 1133
	public struct ScopedRenderPass : IDisposable
	{
		// Token: 0x0600263C RID: 9788 RVA: 0x00041AD5 File Offset: 0x0003FCD5
		internal ScopedRenderPass(ScriptableRenderContext context)
		{
			this.m_Context = context;
		}

		// Token: 0x0600263D RID: 9789 RVA: 0x00041AE0 File Offset: 0x0003FCE0
		public void Dispose()
		{
			try
			{
				this.m_Context.EndRenderPass();
			}
			catch (Exception innerException)
			{
				throw new InvalidOperationException("The ScopedRenderPass instance is not valid. This can happen if it was constructed using the default constructor.", innerException);
			}
		}

		// Token: 0x04000E89 RID: 3721
		private ScriptableRenderContext m_Context;
	}
}
