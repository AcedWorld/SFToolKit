using System;

namespace UnityEngine.Experimental.Rendering
{
	// Token: 0x020004D3 RID: 1235
	public abstract class ScriptableRuntimeReflectionSystem : IScriptableRuntimeReflectionSystem, IDisposable
	{
		// Token: 0x06002B22 RID: 11042 RVA: 0x000490E0 File Offset: 0x000472E0
		public virtual bool TickRealtimeProbes()
		{
			return false;
		}

		// Token: 0x06002B23 RID: 11043 RVA: 0x00002669 File Offset: 0x00000869
		protected virtual void Dispose(bool disposing)
		{
		}

		// Token: 0x06002B24 RID: 11044 RVA: 0x000490F3 File Offset: 0x000472F3
		void IDisposable.Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
