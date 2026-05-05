using System;

namespace UnityEngine.Pool
{
	// Token: 0x020003C7 RID: 967
	public struct PooledObject<T> : IDisposable where T : class
	{
		// Token: 0x06002106 RID: 8454 RVA: 0x00036DDA File Offset: 0x00034FDA
		public PooledObject(T value, IObjectPool<T> pool)
		{
			this.m_ToReturn = value;
			this.m_Pool = pool;
		}

		// Token: 0x06002107 RID: 8455 RVA: 0x00036DEB File Offset: 0x00034FEB
		void IDisposable.Dispose()
		{
			this.m_Pool.Release(this.m_ToReturn);
		}

		// Token: 0x04000AEB RID: 2795
		private readonly T m_ToReturn;

		// Token: 0x04000AEC RID: 2796
		private readonly IObjectPool<T> m_Pool;
	}
}
