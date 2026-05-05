using System;

namespace UnityEngine.Pool
{
	// Token: 0x020003C1 RID: 961
	public class GenericPool<T> where T : class, new()
	{
		// Token: 0x060020E6 RID: 8422 RVA: 0x000368B6 File Offset: 0x00034AB6
		public static T Get()
		{
			return GenericPool<T>.s_Pool.Get();
		}

		// Token: 0x060020E7 RID: 8423 RVA: 0x000368C2 File Offset: 0x00034AC2
		public static PooledObject<T> Get(out T value)
		{
			return GenericPool<T>.s_Pool.Get(out value);
		}

		// Token: 0x060020E8 RID: 8424 RVA: 0x000368CF File Offset: 0x00034ACF
		public static void Release(T toRelease)
		{
			GenericPool<T>.s_Pool.Release(toRelease);
		}

		// Token: 0x04000AD6 RID: 2774
		internal static readonly ObjectPool<T> s_Pool = new ObjectPool<T>(() => Activator.CreateInstance<T>(), null, null, null, true, 10, 10000);
	}
}
