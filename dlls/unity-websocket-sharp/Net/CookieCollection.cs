using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x0200002B RID: 43
	[Serializable]
	internal class CookieCollection : ICollection<Cookie>, IEnumerable<Cookie>, IEnumerable
	{
		// Token: 0x0600031B RID: 795 RVA: 0x0000E7E3 File Offset: 0x0000C9E3
		public CookieCollection()
		{
			this._list = new List<Cookie>();
			this._sync = ((ICollection)this._list).SyncRoot;
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x0600031C RID: 796 RVA: 0x0000E807 File Offset: 0x0000CA07
		internal IList<Cookie> List
		{
			get
			{
				return this._list;
			}
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x0600031D RID: 797 RVA: 0x0000E810 File Offset: 0x0000CA10
		internal IEnumerable<Cookie> Sorted
		{
			get
			{
				List<Cookie> list = new List<Cookie>(this._list);
				if (list.Count > 1)
				{
					list.Sort(new Comparison<Cookie>(CookieCollection.compareForSorted));
				}
				return list;
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x0600031E RID: 798 RVA: 0x0000E845 File Offset: 0x0000CA45
		public int Count
		{
			get
			{
				return this._list.Count;
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x0600031F RID: 799 RVA: 0x0000E852 File Offset: 0x0000CA52
		// (set) Token: 0x06000320 RID: 800 RVA: 0x0000E85A File Offset: 0x0000CA5A
		public bool IsReadOnly
		{
			get
			{
				return this._readOnly;
			}
			internal set
			{
				this._readOnly = value;
			}
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x06000321 RID: 801 RVA: 0x0000E863 File Offset: 0x0000CA63
		public bool IsSynchronized
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170000E3 RID: 227
		public Cookie this[int index]
		{
			get
			{
				if (index < 0 || index >= this._list.Count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return this._list[index];
			}
		}

		// Token: 0x170000E4 RID: 228
		public Cookie this[string name]
		{
			get
			{
				if (name == null)
				{
					throw new ArgumentNullException("name");
				}
				StringComparison comparisonType = StringComparison.InvariantCultureIgnoreCase;
				foreach (Cookie cookie in this.Sorted)
				{
					if (cookie.Name.Equals(name, comparisonType))
					{
						return cookie;
					}
				}
				return null;
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000324 RID: 804 RVA: 0x0000E900 File Offset: 0x0000CB00
		public object SyncRoot
		{
			get
			{
				return this._sync;
			}
		}

		// Token: 0x06000325 RID: 805 RVA: 0x0000E908 File Offset: 0x0000CB08
		private void add(Cookie cookie)
		{
			int num = this.search(cookie);
			if (num == -1)
			{
				this._list.Add(cookie);
				return;
			}
			this._list[num] = cookie;
		}

		// Token: 0x06000326 RID: 806 RVA: 0x0000E93B File Offset: 0x0000CB3B
		private static int compareForSort(Cookie x, Cookie y)
		{
			return x.Name.Length + x.Value.Length - (y.Name.Length + y.Value.Length);
		}

		// Token: 0x06000327 RID: 807 RVA: 0x0000E96C File Offset: 0x0000CB6C
		private static int compareForSorted(Cookie x, Cookie y)
		{
			int num = x.Version - y.Version;
			if (num != 0)
			{
				return num;
			}
			if ((num = x.Name.CompareTo(y.Name)) == 0)
			{
				return y.Path.Length - x.Path.Length;
			}
			return num;
		}

		// Token: 0x06000328 RID: 808 RVA: 0x0000E9BC File Offset: 0x0000CBBC
		private static CookieCollection parseRequest(string value)
		{
			CookieCollection cookieCollection = new CookieCollection();
			Cookie cookie = null;
			int num = 0;
			StringComparison comparisonType = StringComparison.InvariantCultureIgnoreCase;
			List<string> list = value.SplitHeaderValue(new char[]
			{
				',',
				';'
			}).ToList<string>();
			for (int i = 0; i < list.Count; i++)
			{
				string text = list[i].Trim();
				if (text.Length != 0)
				{
					int num2 = text.IndexOf('=');
					if (num2 == -1)
					{
						if (cookie != null && text.Equals("$port", comparisonType))
						{
							cookie.Port = "\"\"";
						}
					}
					else if (num2 == 0)
					{
						if (cookie != null)
						{
							cookieCollection.add(cookie);
							cookie = null;
						}
					}
					else
					{
						string text2 = text.Substring(0, num2).TrimEnd(' ');
						string text3 = (num2 < text.Length - 1) ? text.Substring(num2 + 1).TrimStart(' ') : string.Empty;
						if (text2.Equals("$version", comparisonType))
						{
							int num3;
							if (text3.Length != 0 && int.TryParse(text3.Unquote(), out num3))
							{
								num = num3;
							}
						}
						else if (text2.Equals("$path", comparisonType))
						{
							if (cookie != null && text3.Length != 0)
							{
								cookie.Path = text3;
							}
						}
						else if (text2.Equals("$domain", comparisonType))
						{
							if (cookie != null && text3.Length != 0)
							{
								cookie.Domain = text3;
							}
						}
						else if (text2.Equals("$port", comparisonType))
						{
							if (cookie != null && text3.Length != 0)
							{
								cookie.Port = text3;
							}
						}
						else
						{
							if (cookie != null)
							{
								cookieCollection.add(cookie);
							}
							if (Cookie.TryCreate(text2, text3, out cookie) && num != 0)
							{
								cookie.Version = num;
							}
						}
					}
				}
			}
			if (cookie != null)
			{
				cookieCollection.add(cookie);
			}
			return cookieCollection;
		}

		// Token: 0x06000329 RID: 809 RVA: 0x0000EB88 File Offset: 0x0000CD88
		private static CookieCollection parseResponse(string value)
		{
			CookieCollection cookieCollection = new CookieCollection();
			Cookie cookie = null;
			StringComparison comparisonType = StringComparison.InvariantCultureIgnoreCase;
			List<string> list = value.SplitHeaderValue(new char[]
			{
				',',
				';'
			}).ToList<string>();
			for (int i = 0; i < list.Count; i++)
			{
				string text = list[i].Trim();
				if (text.Length != 0)
				{
					int num = text.IndexOf('=');
					if (num == -1)
					{
						if (cookie != null)
						{
							if (text.Equals("port", comparisonType))
							{
								cookie.Port = "\"\"";
							}
							else if (text.Equals("discard", comparisonType))
							{
								cookie.Discard = true;
							}
							else if (text.Equals("secure", comparisonType))
							{
								cookie.Secure = true;
							}
							else if (text.Equals("httponly", comparisonType))
							{
								cookie.HttpOnly = true;
							}
						}
					}
					else if (num == 0)
					{
						if (cookie != null)
						{
							cookieCollection.add(cookie);
							cookie = null;
						}
					}
					else
					{
						string text2 = text.Substring(0, num).TrimEnd(' ');
						string text3 = (num < text.Length - 1) ? text.Substring(num + 1).TrimStart(' ') : string.Empty;
						if (text2.Equals("version", comparisonType))
						{
							int version;
							if (cookie != null && text3.Length != 0 && int.TryParse(text3.Unquote(), out version))
							{
								cookie.Version = version;
							}
						}
						else if (text2.Equals("expires", comparisonType))
						{
							if (text3.Length != 0)
							{
								if (i == list.Count - 1)
								{
									break;
								}
								i++;
								if (cookie != null && !(cookie.Expires != DateTime.MinValue))
								{
									StringBuilder stringBuilder = new StringBuilder(text3, 32);
									stringBuilder.AppendFormat(", {0}", list[i].Trim());
									DateTime dateTime;
									if (DateTime.TryParseExact(stringBuilder.ToString(), new string[]
									{
										"ddd, dd'-'MMM'-'yyyy HH':'mm':'ss 'GMT'",
										"r"
									}, CultureInfo.CreateSpecificCulture("en-US"), DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out dateTime))
									{
										cookie.Expires = dateTime.ToLocalTime();
									}
								}
							}
						}
						else if (text2.Equals("max-age", comparisonType))
						{
							int maxAge;
							if (cookie != null && text3.Length != 0 && int.TryParse(text3.Unquote(), out maxAge))
							{
								cookie.MaxAge = maxAge;
							}
						}
						else if (text2.Equals("path", comparisonType))
						{
							if (cookie != null && text3.Length != 0)
							{
								cookie.Path = text3;
							}
						}
						else if (text2.Equals("domain", comparisonType))
						{
							if (cookie != null && text3.Length != 0)
							{
								cookie.Domain = text3;
							}
						}
						else if (text2.Equals("port", comparisonType))
						{
							if (cookie != null && text3.Length != 0)
							{
								cookie.Port = text3;
							}
						}
						else if (text2.Equals("comment", comparisonType))
						{
							if (cookie != null && text3.Length != 0)
							{
								cookie.Comment = CookieCollection.urlDecode(text3, Encoding.UTF8);
							}
						}
						else if (text2.Equals("commenturl", comparisonType))
						{
							if (cookie != null && text3.Length != 0)
							{
								cookie.CommentUri = text3.Unquote().ToUri();
							}
						}
						else if (text2.Equals("samesite", comparisonType))
						{
							if (cookie != null && text3.Length != 0)
							{
								cookie.SameSite = text3.Unquote();
							}
						}
						else
						{
							if (cookie != null)
							{
								cookieCollection.add(cookie);
							}
							Cookie.TryCreate(text2, text3, out cookie);
						}
					}
				}
			}
			if (cookie != null)
			{
				cookieCollection.add(cookie);
			}
			return cookieCollection;
		}

		// Token: 0x0600032A RID: 810 RVA: 0x0000EF40 File Offset: 0x0000D140
		private int search(Cookie cookie)
		{
			for (int i = this._list.Count - 1; i >= 0; i--)
			{
				if (this._list[i].EqualsWithoutValue(cookie))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0600032B RID: 811 RVA: 0x0000EF7C File Offset: 0x0000D17C
		private static string urlDecode(string s, Encoding encoding)
		{
			if (s.IndexOfAny(new char[]
			{
				'%',
				'+'
			}) == -1)
			{
				return s;
			}
			string result;
			try
			{
				result = HttpUtility.UrlDecode(s, encoding);
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600032C RID: 812 RVA: 0x0000EFC8 File Offset: 0x0000D1C8
		internal static CookieCollection Parse(string value, bool response)
		{
			CookieCollection result;
			try
			{
				result = (response ? CookieCollection.parseResponse(value) : CookieCollection.parseRequest(value));
			}
			catch (Exception innerException)
			{
				throw new CookieException("It could not be parsed.", innerException);
			}
			return result;
		}

		// Token: 0x0600032D RID: 813 RVA: 0x0000F008 File Offset: 0x0000D208
		internal void SetOrRemove(Cookie cookie)
		{
			int num = this.search(cookie);
			if (num == -1)
			{
				if (cookie.Expired)
				{
					return;
				}
				this._list.Add(cookie);
				return;
			}
			else
			{
				if (cookie.Expired)
				{
					this._list.RemoveAt(num);
					return;
				}
				this._list[num] = cookie;
				return;
			}
		}

		// Token: 0x0600032E RID: 814 RVA: 0x0000F05C File Offset: 0x0000D25C
		internal void SetOrRemove(CookieCollection cookies)
		{
			foreach (Cookie orRemove in cookies._list)
			{
				this.SetOrRemove(orRemove);
			}
		}

		// Token: 0x0600032F RID: 815 RVA: 0x0000F0B0 File Offset: 0x0000D2B0
		internal void Sort()
		{
			if (this._list.Count > 1)
			{
				this._list.Sort(new Comparison<Cookie>(CookieCollection.compareForSort));
			}
		}

		// Token: 0x06000330 RID: 816 RVA: 0x0000F0D7 File Offset: 0x0000D2D7
		public void Add(Cookie cookie)
		{
			if (this._readOnly)
			{
				throw new InvalidOperationException("The collection is read-only.");
			}
			if (cookie == null)
			{
				throw new ArgumentNullException("cookie");
			}
			this.add(cookie);
		}

		// Token: 0x06000331 RID: 817 RVA: 0x0000F104 File Offset: 0x0000D304
		public void Add(CookieCollection cookies)
		{
			if (this._readOnly)
			{
				throw new InvalidOperationException("The collection is read-only.");
			}
			if (cookies == null)
			{
				throw new ArgumentNullException("cookies");
			}
			foreach (Cookie cookie in cookies._list)
			{
				this.add(cookie);
			}
		}

		// Token: 0x06000332 RID: 818 RVA: 0x0000F178 File Offset: 0x0000D378
		public void Clear()
		{
			if (this._readOnly)
			{
				throw new InvalidOperationException("The collection is read-only.");
			}
			this._list.Clear();
		}

		// Token: 0x06000333 RID: 819 RVA: 0x0000F198 File Offset: 0x0000D398
		public bool Contains(Cookie cookie)
		{
			if (cookie == null)
			{
				throw new ArgumentNullException("cookie");
			}
			return this.search(cookie) > -1;
		}

		// Token: 0x06000334 RID: 820 RVA: 0x0000F1B4 File Offset: 0x0000D3B4
		public void CopyTo(Cookie[] array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index", "Less than zero.");
			}
			if (array.Length - index < this._list.Count)
			{
				throw new ArgumentException("The available space of the array is not enough to copy to.");
			}
			this._list.CopyTo(array, index);
		}

		// Token: 0x06000335 RID: 821 RVA: 0x0000F20D File Offset: 0x0000D40D
		public IEnumerator<Cookie> GetEnumerator()
		{
			return this._list.GetEnumerator();
		}

		// Token: 0x06000336 RID: 822 RVA: 0x0000F220 File Offset: 0x0000D420
		public bool Remove(Cookie cookie)
		{
			if (this._readOnly)
			{
				throw new InvalidOperationException("The collection is read-only.");
			}
			if (cookie == null)
			{
				throw new ArgumentNullException("cookie");
			}
			int num = this.search(cookie);
			if (num == -1)
			{
				return false;
			}
			this._list.RemoveAt(num);
			return true;
		}

		// Token: 0x06000337 RID: 823 RVA: 0x0000F269 File Offset: 0x0000D469
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this._list.GetEnumerator();
		}

		// Token: 0x0400011B RID: 283
		private List<Cookie> _list;

		// Token: 0x0400011C RID: 284
		private bool _readOnly;

		// Token: 0x0400011D RID: 285
		private object _sync;
	}
}
