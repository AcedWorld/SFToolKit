using System;
using System.Collections;
using System.Collections.Generic;

namespace WebSocketSharp.Net
{
	// Token: 0x02000023 RID: 35
	public class HttpListenerPrefixCollection : ICollection<string>, IEnumerable<string>, IEnumerable
	{
		// Token: 0x0600027B RID: 635 RVA: 0x000106B0 File Offset: 0x0000E8B0
		internal HttpListenerPrefixCollection(HttpListener listener)
		{
			this._listener = listener;
			this._prefixes = new List<string>();
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x0600027C RID: 636 RVA: 0x000106CC File Offset: 0x0000E8CC
		public int Count
		{
			get
			{
				return this._prefixes.Count;
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x0600027D RID: 637 RVA: 0x000106EC File Offset: 0x0000E8EC
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x0600027E RID: 638 RVA: 0x00010700 File Offset: 0x0000E900
		public bool IsSynchronized
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600027F RID: 639 RVA: 0x00010714 File Offset: 0x0000E914
		public void Add(string uriPrefix)
		{
			this._listener.CheckDisposed();
			HttpListenerPrefix.CheckPrefix(uriPrefix);
			bool flag = this._prefixes.Contains(uriPrefix);
			if (!flag)
			{
				bool isListening = this._listener.IsListening;
				if (isListening)
				{
					EndPointManager.AddPrefix(uriPrefix, this._listener);
				}
				this._prefixes.Add(uriPrefix);
			}
		}

		// Token: 0x06000280 RID: 640 RVA: 0x00010770 File Offset: 0x0000E970
		public void Clear()
		{
			this._listener.CheckDisposed();
			bool isListening = this._listener.IsListening;
			if (isListening)
			{
				EndPointManager.RemoveListener(this._listener);
			}
			this._prefixes.Clear();
		}

		// Token: 0x06000281 RID: 641 RVA: 0x000107B4 File Offset: 0x0000E9B4
		public bool Contains(string uriPrefix)
		{
			this._listener.CheckDisposed();
			bool flag = uriPrefix == null;
			if (flag)
			{
				throw new ArgumentNullException("uriPrefix");
			}
			return this._prefixes.Contains(uriPrefix);
		}

		// Token: 0x06000282 RID: 642 RVA: 0x000107F1 File Offset: 0x0000E9F1
		public void CopyTo(string[] array, int offset)
		{
			this._listener.CheckDisposed();
			this._prefixes.CopyTo(array, offset);
		}

		// Token: 0x06000283 RID: 643 RVA: 0x00010810 File Offset: 0x0000EA10
		public IEnumerator<string> GetEnumerator()
		{
			return this._prefixes.GetEnumerator();
		}

		// Token: 0x06000284 RID: 644 RVA: 0x00010834 File Offset: 0x0000EA34
		public bool Remove(string uriPrefix)
		{
			this._listener.CheckDisposed();
			bool flag = uriPrefix == null;
			if (flag)
			{
				throw new ArgumentNullException("uriPrefix");
			}
			bool flag2 = !this._prefixes.Contains(uriPrefix);
			bool result;
			if (flag2)
			{
				result = false;
			}
			else
			{
				bool isListening = this._listener.IsListening;
				if (isListening)
				{
					EndPointManager.RemovePrefix(uriPrefix, this._listener);
				}
				result = this._prefixes.Remove(uriPrefix);
			}
			return result;
		}

		// Token: 0x06000285 RID: 645 RVA: 0x000108A4 File Offset: 0x0000EAA4
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this._prefixes.GetEnumerator();
		}

		// Token: 0x040000F3 RID: 243
		private HttpListener _listener;

		// Token: 0x040000F4 RID: 244
		private List<string> _prefixes;
	}
}
