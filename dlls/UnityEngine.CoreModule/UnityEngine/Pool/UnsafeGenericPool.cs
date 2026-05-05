using System;

namespace UnityEngine.Pool
{
	// Token: 0x020003C8 RID: 968
	public static class UnsafeGenericPool<T> where T : class, new()
	{
		// Token: 0x06002108 RID: 8456 RVA: 0x00036DFF File Offset: 0x00034FFF
		public static T Get()
		{
			return UnsafeGenericPool<T>.s_Pool.Get();
		}

		// Token: 0x06002109 RID: 8457 RVA: 0x00036E0B File Offset: 0x0003500B
		public static PooledObject<T> Get(out T value)
		{
			return UnsafeGenericPool<T>.s_Pool.Get(out value);
		}

		// Token: 0x0600210A RID: 8458 RVA: 0x00036E18 File Offset: 0x00035018
		public static void Release(T toRelease)
		{
			UnsafeGenericPool<T>.s_Pool.Release(toRelease);
		}

		// Token: 0x04000AED RID: 2797
		internal static readonly ObjectPool<T> s_Pool = new ObjectPool<T>(() => Activator.CreateInstance<T>(), null, null, null, false, 10, 10000);
	}
}
