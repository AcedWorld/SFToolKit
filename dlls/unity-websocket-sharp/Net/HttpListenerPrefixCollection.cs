using System;
using System.Collections;
using System.Collections.Generic;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x02000039 RID: 57
	internal class HttpListenerPrefixCollection : ICollection<string>, IEnumerable<string>, IEnumerable
	{
		// Token: 0x060003ED RID: 1005 RVA: 0x00011D3F File Offset: 0x0000FF3F
		internal HttpListenerPrefixCollection(HttpListener listener)
		{
			this._listener = listener;
			this._prefixes = new List<string>();
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x060003EE RID: 1006 RVA: 0x00011D59 File Offset: 0x0000FF59
		public int Count
		{
			get
			{
				return this._prefixes.Count;
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x060003EF RID: 1007 RVA: 0x00011D66 File Offset: 0x0000FF66
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x060003F0 RID: 1008 RVA: 0x00011D69 File Offset: 0x0000FF69
		public bool IsSynchronized
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x00011D6C File Offset: 0x0000FF6C
		public void Add(string uriPrefix)
		{
			this._listener.CheckDisposed();
			HttpListenerPrefix.CheckPrefix(uriPrefix);
			if (this._prefixes.Contains(uriPrefix))
			{
				return;
			}
			if (this._listener.IsListening)
			{
				EndPointManager.AddPrefix(uriPrefix, this._listener);
			}
			this._prefixes.Add(uriPrefix);
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x00011DBE File Offset: 0x0000FFBE
		public void Clear()
		{
			this._listener.CheckDisposed();
			if (this._listener.IsListening)
			{
				EndPointManager.RemoveListener(this._listener);
			}
			this._prefixes.Clear();
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x00011DEE File Offset: 0x0000FFEE
		public bool Contains(string uriPrefix)
		{
			this._listener.CheckDisposed();
			if (uriPrefix == null)
			{
				throw new ArgumentNullException("uriPrefix");
			}
			return this._prefixes.Contains(uriPrefix);
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x00011E15 File Offset: 0x00010015
		public void CopyTo(string[] array, int offset)
		{
			this._listener.CheckDisposed();
			this._prefixes.CopyTo(array, offset);
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x00011E2F File Offset: 0x0001002F
		public IEnumerator<string> GetEnumerator()
		{
			return this._prefixes.GetEnumerator();
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x00011E44 File Offset: 0x00010044
		public bool Remove(string uriPrefix)
		{
			this._listener.CheckDisposed();
			if (uriPrefix == null)
			{
				throw new ArgumentNullException("uriPrefix");
			}
			if (!this._prefixes.Contains(uriPrefix))
			{
				return false;
			}
			if (this._listener.IsListening)
			{
				EndPointManager.RemovePrefix(uriPrefix, this._listener);
			}
			return this._prefixes.Remove(uriPrefix);
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x00011E9F File Offset: 0x0001009F
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this._prefixes.GetEnumerator();
		}

		// Token: 0x04000177 RID: 375
		private HttpListener _listener;

		// Token: 0x04000178 RID: 376
		private List<string> _prefixes;
	}
}
