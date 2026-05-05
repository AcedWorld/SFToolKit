using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200004E RID: 78
	public static class UnsafeGenericPool<T> where T : new()
	{
		// Token: 0x0600029B RID: 667 RVA: 0x0000C1ED File Offset: 0x0000A3ED
		public static T Get()
		{
			return UnsafeGenericPool<T>.s_Pool.Get();
		}

		// Token: 0x0600029C RID: 668 RVA: 0x0000C1F9 File Offset: 0x0000A3F9
		public static ObjectPool<T>.PooledObject Get(out T value)
		{
			return UnsafeGenericPool<T>.s_Pool.Get(out value);
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0000C206 File Offset: 0x0000A406
		public static void Release(T toRelease)
		{
			UnsafeGenericPool<T>.s_Pool.Release(toRelease);
		}

		// Token: 0x0400019A RID: 410
		private static readonly ObjectPool<T> s_Pool = new ObjectPool<T>(null, null, false);
	}
}
