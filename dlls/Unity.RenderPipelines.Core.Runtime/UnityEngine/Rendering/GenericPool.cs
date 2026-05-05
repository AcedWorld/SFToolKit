using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200004D RID: 77
	public static class GenericPool<T> where T : new()
	{
		// Token: 0x06000297 RID: 663 RVA: 0x0000C1B8 File Offset: 0x0000A3B8
		public static T Get()
		{
			return GenericPool<T>.s_Pool.Get();
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0000C1C4 File Offset: 0x0000A3C4
		public static ObjectPool<T>.PooledObject Get(out T value)
		{
			return GenericPool<T>.s_Pool.Get(out value);
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0000C1D1 File Offset: 0x0000A3D1
		public static void Release(T toRelease)
		{
			GenericPool<T>.s_Pool.Release(toRelease);
		}

		// Token: 0x04000199 RID: 409
		private static readonly ObjectPool<T> s_Pool = new ObjectPool<T>(null, null, true);
	}
}
