using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200046E RID: 1134
	public struct ScopedSubPass : IDisposable
	{
		// Token: 0x0600263E RID: 9790 RVA: 0x00041B1C File Offset: 0x0003FD1C
		internal ScopedSubPass(ScriptableRenderContext context)
		{
			this.m_Context = context;
		}

		// Token: 0x0600263F RID: 9791 RVA: 0x00041B28 File Offset: 0x0003FD28
		public void Dispose()
		{
			try
			{
				this.m_Context.EndSubPass();
			}
			catch (Exception innerException)
			{
				throw new InvalidOperationException("The ScopedSubPass instance is not valid. This can happen if it was constructed using the default constructor.", innerException);
			}
		}

		// Token: 0x04000E8A RID: 3722
		private ScriptableRenderContext m_Context;
	}
}
