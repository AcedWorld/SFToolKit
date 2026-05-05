using System;
using System.Collections.Generic;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x02000195 RID: 405
	public sealed class fsContext
	{
		// Token: 0x06000AA6 RID: 2726 RVA: 0x0002CEAC File Offset: 0x0002B0AC
		public void Reset()
		{
			this._contextObjects.Clear();
		}

		// Token: 0x06000AA7 RID: 2727 RVA: 0x0002CEB9 File Offset: 0x0002B0B9
		public void Set<T>(T obj)
		{
			this._contextObjects[typeof(T)] = obj;
		}

		// Token: 0x06000AA8 RID: 2728 RVA: 0x0002CED6 File Offset: 0x0002B0D6
		public bool Has<T>()
		{
			return this._contextObjects.ContainsKey(typeof(T));
		}

		// Token: 0x06000AA9 RID: 2729 RVA: 0x0002CEF0 File Offset: 0x0002B0F0
		public T Get<T>()
		{
			object obj;
			if (this._contextObjects.TryGetValue(typeof(T), out obj))
			{
				return (T)((object)obj);
			}
			string str = "There is no context object of type ";
			Type typeFromHandle = typeof(T);
			throw new InvalidOperationException(str + ((typeFromHandle != null) ? typeFromHandle.ToString() : null));
		}

		// Token: 0x0400027A RID: 634
		private readonly Dictionary<Type, object> _contextObjects = new Dictionary<Type, object>();
	}
}
