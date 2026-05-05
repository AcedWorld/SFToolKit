using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;

namespace WebSocketSharp.Net
{
	// Token: 0x0200002A RID: 42
	[ComVisible(true)]
	[Serializable]
	public class WebHeaderCollection : NameValueCollection, ISerializable
	{
		// Token: 0x06000347 RID: 839 RVA: 0x00015E26 File Offset: 0x00014026
		internal WebHeaderCollection(HttpHeaderType state, bool internallyUsed)
		{
			this._state = state;
			this._internallyUsed = internallyUsed;
		}

		// Token: 0x06000348 RID: 840 RVA: 0x00015E40 File Offset: 0x00014040
		protected WebHeaderCollection(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
			bool flag = serializationInfo == null;
			if (flag)
			{
				throw new ArgumentNullException("serializationInfo");
			}
			try
			{
				this._internallyUsed = serializationInfo.GetBoolean("InternallyUsed");
				this._state = (HttpHeaderType)serializationInfo.GetInt32("State");
				int @int = serializationInfo.GetInt32("Count");
				for (int i = 0; i < @int; i++)
				{
					base.Add(serializationInfo.GetString(i.ToString()), serializationInfo.GetString((@int + i).ToString()));
				}
			}
			catch (SerializationException ex)
			{
				throw new ArgumentException(ex.Message, "serializationInfo", ex);
			}
		}

		// Token: 0x06000349 RID: 841 RVA: 0x00015EFC File Offset: 0x000140FC
		public WebHeaderCollection()
		{
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x0600034A RID: 842 RVA: 0x00015F08 File Offset: 0x00014108
		internal HttpHeaderType State
		{
			get
			{
				return this._state;
			}
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x0600034B RID: 843 RVA: 0x00015F20 File Offset: 0x00014120
		public override string[] AllKeys
		{
			get
			{
				return base.AllKeys;
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x0600034C RID: 844 RVA: 0x00015F38 File Offset: 0x00014138
		public override int Count
		{
			get
			{
				return base.Count;
			}
		}

		// Token: 0x170000DA RID: 218
		public string this[HttpRequestHeader header]
		{
			get
			{
				string key = header.ToString();
				string headerName = WebHeaderCollection.getHeaderName(key);
				return this.Get(headerName);
			}
			set
			{
				this.Add(header, value);
			}
		}

		// Token: 0x170000DB RID: 219
		public string this[HttpResponseHeader header]
		{
			get
			{
				string key = header.ToString();
				string headerName = WebHeaderCollection.getHeaderName(key);
				return this.Get(headerName);
			}
			set
			{
				this.Add(header, value);
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000351 RID: 849 RVA: 0x00015FC8 File Offset: 0x000141C8
		public override NameObjectCollectionBase.KeysCollection Keys
		{
			get
			{
				return base.Keys;
			}
		}

		// Token: 0x06000352 RID: 850 RVA: 0x00015FE0 File Offset: 0x000141E0
		private void add(string name, string value, HttpHeaderType headerType)
		{
			base.Add(name, value);
			bool flag = this._state > HttpHeaderType.Unspecified;
			if (!flag)
			{
				bool flag2 = headerType == HttpHeaderType.Unspecified;
				if (!flag2)
				{
					this._state = headerType;
				}
			}
		}

		// Token: 0x06000353 RID: 851 RVA: 0x00016018 File Offset: 0x00014218
		private void checkAllowed(HttpHeaderType headerType)
		{
			bool flag = this._state == HttpHeaderType.Unspecified;
			if (!flag)
			{
				bool flag2 = headerType == HttpHeaderType.Unspecified;
				if (!flag2)
				{
					bool flag3 = headerType != this._state;
					if (flag3)
					{
						string message = "This instance does not allow the header.";
						throw new InvalidOperationException(message);
					}
				}
			}
		}

		// Token: 0x06000354 RID: 852 RVA: 0x00016060 File Offset: 0x00014260
		private static string checkName(string name, string paramName)
		{
			bool flag = name == null;
			if (flag)
			{
				string message = "The name is null.";
				throw new ArgumentNullException(paramName, message);
			}
			bool flag2 = name.Length == 0;
			if (flag2)
			{
				string message2 = "The name is an empty string.";
				throw new ArgumentException(message2, paramName);
			}
			name = name.Trim();
			bool flag3 = name.Length == 0;
			if (flag3)
			{
				string message3 = "The name is a string of spaces.";
				throw new ArgumentException(message3, paramName);
			}
			bool flag4 = !name.IsToken();
			if (flag4)
			{
				string message4 = "The name contains an invalid character.";
				throw new ArgumentException(message4, paramName);
			}
			return name;
		}

		// Token: 0x06000355 RID: 853 RVA: 0x000160F0 File Offset: 0x000142F0
		private void checkRestricted(string name, HttpHeaderType headerType)
		{
			bool internallyUsed = this._internallyUsed;
			if (!internallyUsed)
			{
				bool response = headerType == HttpHeaderType.Response;
				bool flag = WebHeaderCollection.isRestricted(name, response);
				if (flag)
				{
					string message = "The header is a restricted header.";
					throw new ArgumentException(message);
				}
			}
		}

		// Token: 0x06000356 RID: 854 RVA: 0x00016128 File Offset: 0x00014328
		private static string checkValue(string value, string paramName)
		{
			bool flag = value == null;
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				value = value.Trim();
				int length = value.Length;
				bool flag2 = length == 0;
				if (flag2)
				{
					result = value;
				}
				else
				{
					bool flag3 = length > 65535;
					if (flag3)
					{
						string message = "The length of the value is greater than 65,535 characters.";
						throw new ArgumentOutOfRangeException(paramName, message);
					}
					bool flag4 = !value.IsText();
					if (flag4)
					{
						string message2 = "The value contains an invalid character.";
						throw new ArgumentException(message2, paramName);
					}
					result = value;
				}
			}
			return result;
		}

		// Token: 0x06000357 RID: 855 RVA: 0x000161A8 File Offset: 0x000143A8
		private static HttpHeaderInfo getHeaderInfo(string name)
		{
			StringComparison comparisonType = StringComparison.InvariantCultureIgnoreCase;
			foreach (HttpHeaderInfo httpHeaderInfo in WebHeaderCollection._headers.Values)
			{
				bool flag = httpHeaderInfo.HeaderName.Equals(name, comparisonType);
				if (flag)
				{
					return httpHeaderInfo;
				}
			}
			return null;
		}

		// Token: 0x06000358 RID: 856 RVA: 0x0001621C File Offset: 0x0001441C
		private static string getHeaderName(string key)
		{
			HttpHeaderInfo httpHeaderInfo;
			return WebHeaderCollection._headers.TryGetValue(key, out httpHeaderInfo) ? httpHeaderInfo.HeaderName : null;
		}

		// Token: 0x06000359 RID: 857 RVA: 0x00016248 File Offset: 0x00014448
		private static HttpHeaderType getHeaderType(string name)
		{
			HttpHeaderInfo headerInfo = WebHeaderCollection.getHeaderInfo(name);
			bool flag = headerInfo == null;
			HttpHeaderType result;
			if (flag)
			{
				result = HttpHeaderType.Unspecified;
			}
			else
			{
				bool isRequest = headerInfo.IsRequest;
				if (isRequest)
				{
					result = ((!headerInfo.IsResponse) ? HttpHeaderType.Request : HttpHeaderType.Unspecified);
				}
				else
				{
					result = (headerInfo.IsResponse ? HttpHeaderType.Response : HttpHeaderType.Unspecified);
				}
			}
			return result;
		}

		// Token: 0x0600035A RID: 858 RVA: 0x00016294 File Offset: 0x00014494
		private static bool isMultiValue(string name, bool response)
		{
			HttpHeaderInfo headerInfo = WebHeaderCollection.getHeaderInfo(name);
			return headerInfo != null && headerInfo.IsMultiValue(response);
		}

		// Token: 0x0600035B RID: 859 RVA: 0x000162BC File Offset: 0x000144BC
		private static bool isRestricted(string name, bool response)
		{
			HttpHeaderInfo headerInfo = WebHeaderCollection.getHeaderInfo(name);
			return headerInfo != null && headerInfo.IsRestricted(response);
		}

		// Token: 0x0600035C RID: 860 RVA: 0x000162E4 File Offset: 0x000144E4
		private void set(string name, string value, HttpHeaderType headerType)
		{
			base.Set(name, value);
			bool flag = this._state > HttpHeaderType.Unspecified;
			if (!flag)
			{
				bool flag2 = headerType == HttpHeaderType.Unspecified;
				if (!flag2)
				{
					this._state = headerType;
				}
			}
		}

		// Token: 0x0600035D RID: 861 RVA: 0x0001631B File Offset: 0x0001451B
		internal void InternalRemove(string name)
		{
			base.Remove(name);
		}

		// Token: 0x0600035E RID: 862 RVA: 0x00016328 File Offset: 0x00014528
		internal void InternalSet(string header, bool response)
		{
			int num = header.IndexOf(':');
			bool flag = num == -1;
			if (flag)
			{
				string message = "It does not contain a colon character.";
				throw new ArgumentException(message, "header");
			}
			string name = header.Substring(0, num);
			string value = (num < header.Length - 1) ? header.Substring(num + 1) : string.Empty;
			name = WebHeaderCollection.checkName(name, "header");
			value = WebHeaderCollection.checkValue(value, "header");
			bool flag2 = WebHeaderCollection.isMultiValue(name, response);
			if (flag2)
			{
				base.Add(name, value);
			}
			else
			{
				base.Set(name, value);
			}
		}

		// Token: 0x0600035F RID: 863 RVA: 0x000163BC File Offset: 0x000145BC
		internal void InternalSet(string name, string value, bool response)
		{
			value = WebHeaderCollection.checkValue(value, "value");
			bool flag = WebHeaderCollection.isMultiValue(name, response);
			if (flag)
			{
				base.Add(name, value);
			}
			else
			{
				base.Set(name, value);
			}
		}

		// Token: 0x06000360 RID: 864 RVA: 0x000163F8 File Offset: 0x000145F8
		internal string ToStringMultiValue(bool response)
		{
			int count = this.Count;
			bool flag = count == 0;
			string result;
			if (flag)
			{
				result = "\r\n";
			}
			else
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < count; i++)
				{
					string key = this.GetKey(i);
					bool flag2 = WebHeaderCollection.isMultiValue(key, response);
					if (flag2)
					{
						foreach (string arg in this.GetValues(i))
						{
							stringBuilder.AppendFormat("{0}: {1}\r\n", key, arg);
						}
					}
					else
					{
						stringBuilder.AppendFormat("{0}: {1}\r\n", key, this.Get(i));
					}
				}
				stringBuilder.Append("\r\n");
				result = stringBuilder.ToString();
			}
			return result;
		}

		// Token: 0x06000361 RID: 865 RVA: 0x000164BC File Offset: 0x000146BC
		protected void AddWithoutValidate(string headerName, string headerValue)
		{
			headerName = WebHeaderCollection.checkName(headerName, "headerName");
			headerValue = WebHeaderCollection.checkValue(headerValue, "headerValue");
			HttpHeaderType headerType = WebHeaderCollection.getHeaderType(headerName);
			this.checkAllowed(headerType);
			this.add(headerName, headerValue, headerType);
		}

		// Token: 0x06000362 RID: 866 RVA: 0x00016500 File Offset: 0x00014700
		public void Add(string header)
		{
			bool flag = header == null;
			if (flag)
			{
				throw new ArgumentNullException("header");
			}
			int length = header.Length;
			bool flag2 = length == 0;
			if (flag2)
			{
				string message = "An empty string.";
				throw new ArgumentException(message, "header");
			}
			int num = header.IndexOf(':');
			bool flag3 = num == -1;
			if (flag3)
			{
				string message2 = "It does not contain a colon character.";
				throw new ArgumentException(message2, "header");
			}
			string name = header.Substring(0, num);
			string value = (num < length - 1) ? header.Substring(num + 1) : string.Empty;
			name = WebHeaderCollection.checkName(name, "header");
			value = WebHeaderCollection.checkValue(value, "header");
			HttpHeaderType headerType = WebHeaderCollection.getHeaderType(name);
			this.checkRestricted(name, headerType);
			this.checkAllowed(headerType);
			this.add(name, value, headerType);
		}

		// Token: 0x06000363 RID: 867 RVA: 0x000165D0 File Offset: 0x000147D0
		public void Add(HttpRequestHeader header, string value)
		{
			value = WebHeaderCollection.checkValue(value, "value");
			string key = header.ToString();
			string headerName = WebHeaderCollection.getHeaderName(key);
			this.checkRestricted(headerName, HttpHeaderType.Request);
			this.checkAllowed(HttpHeaderType.Request);
			this.add(headerName, value, HttpHeaderType.Request);
		}

		// Token: 0x06000364 RID: 868 RVA: 0x0001661C File Offset: 0x0001481C
		public void Add(HttpResponseHeader header, string value)
		{
			value = WebHeaderCollection.checkValue(value, "value");
			string key = header.ToString();
			string headerName = WebHeaderCollection.getHeaderName(key);
			this.checkRestricted(headerName, HttpHeaderType.Response);
			this.checkAllowed(HttpHeaderType.Response);
			this.add(headerName, value, HttpHeaderType.Response);
		}

		// Token: 0x06000365 RID: 869 RVA: 0x00016668 File Offset: 0x00014868
		public override void Add(string name, string value)
		{
			name = WebHeaderCollection.checkName(name, "name");
			value = WebHeaderCollection.checkValue(value, "value");
			HttpHeaderType headerType = WebHeaderCollection.getHeaderType(name);
			this.checkRestricted(name, headerType);
			this.checkAllowed(headerType);
			this.add(name, value, headerType);
		}

		// Token: 0x06000366 RID: 870 RVA: 0x000166B2 File Offset: 0x000148B2
		public override void Clear()
		{
			base.Clear();
			this._state = HttpHeaderType.Unspecified;
		}

		// Token: 0x06000367 RID: 871 RVA: 0x000166C4 File Offset: 0x000148C4
		public override string Get(int index)
		{
			return base.Get(index);
		}

		// Token: 0x06000368 RID: 872 RVA: 0x000166E0 File Offset: 0x000148E0
		public override string Get(string name)
		{
			return base.Get(name);
		}

		// Token: 0x06000369 RID: 873 RVA: 0x000166FC File Offset: 0x000148FC
		public override IEnumerator GetEnumerator()
		{
			return base.GetEnumerator();
		}

		// Token: 0x0600036A RID: 874 RVA: 0x00016714 File Offset: 0x00014914
		public override string GetKey(int index)
		{
			return base.GetKey(index);
		}

		// Token: 0x0600036B RID: 875 RVA: 0x00016730 File Offset: 0x00014930
		public override string[] GetValues(int index)
		{
			string[] values = base.GetValues(index);
			return (values != null && values.Length != 0) ? values : null;
		}

		// Token: 0x0600036C RID: 876 RVA: 0x00016758 File Offset: 0x00014958
		public override string[] GetValues(string name)
		{
			string[] values = base.GetValues(name);
			return (values != null && values.Length != 0) ? values : null;
		}

		// Token: 0x0600036D RID: 877 RVA: 0x00016780 File Offset: 0x00014980
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
		public override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
			bool flag = serializationInfo == null;
			if (flag)
			{
				throw new ArgumentNullException("serializationInfo");
			}
			serializationInfo.AddValue("InternallyUsed", this._internallyUsed);
			serializationInfo.AddValue("State", (int)this._state);
			int count = this.Count;
			serializationInfo.AddValue("Count", count);
			for (int i = 0; i < count; i++)
			{
				serializationInfo.AddValue(i.ToString(), this.GetKey(i));
				serializationInfo.AddValue((count + i).ToString(), this.Get(i));
			}
		}

		// Token: 0x0600036E RID: 878 RVA: 0x0001681C File Offset: 0x00014A1C
		public static bool IsRestricted(string headerName)
		{
			return WebHeaderCollection.IsRestricted(headerName, false);
		}

		// Token: 0x0600036F RID: 879 RVA: 0x00016838 File Offset: 0x00014A38
		public static bool IsRestricted(string headerName, bool response)
		{
			headerName = WebHeaderCollection.checkName(headerName, "headerName");
			return WebHeaderCollection.isRestricted(headerName, response);
		}

		// Token: 0x06000370 RID: 880 RVA: 0x000150FD File Offset: 0x000132FD
		public override void OnDeserialization(object sender)
		{
		}

		// Token: 0x06000371 RID: 881 RVA: 0x00016860 File Offset: 0x00014A60
		public void Remove(HttpRequestHeader header)
		{
			string key = header.ToString();
			string headerName = WebHeaderCollection.getHeaderName(key);
			this.checkRestricted(headerName, HttpHeaderType.Request);
			this.checkAllowed(HttpHeaderType.Request);
			base.Remove(headerName);
		}

		// Token: 0x06000372 RID: 882 RVA: 0x0001689C File Offset: 0x00014A9C
		public void Remove(HttpResponseHeader header)
		{
			string key = header.ToString();
			string headerName = WebHeaderCollection.getHeaderName(key);
			this.checkRestricted(headerName, HttpHeaderType.Response);
			this.checkAllowed(HttpHeaderType.Response);
			base.Remove(headerName);
		}

		// Token: 0x06000373 RID: 883 RVA: 0x000168D8 File Offset: 0x00014AD8
		public override void Remove(string name)
		{
			name = WebHeaderCollection.checkName(name, "name");
			HttpHeaderType headerType = WebHeaderCollection.getHeaderType(name);
			this.checkRestricted(name, headerType);
			this.checkAllowed(headerType);
			base.Remove(name);
		}

		// Token: 0x06000374 RID: 884 RVA: 0x00016914 File Offset: 0x00014B14
		public void Set(HttpRequestHeader header, string value)
		{
			value = WebHeaderCollection.checkValue(value, "value");
			string key = header.ToString();
			string headerName = WebHeaderCollection.getHeaderName(key);
			this.checkRestricted(headerName, HttpHeaderType.Request);
			this.checkAllowed(HttpHeaderType.Request);
			this.set(headerName, value, HttpHeaderType.Request);
		}

		// Token: 0x06000375 RID: 885 RVA: 0x00016960 File Offset: 0x00014B60
		public void Set(HttpResponseHeader header, string value)
		{
			value = WebHeaderCollection.checkValue(value, "value");
			string key = header.ToString();
			string headerName = WebHeaderCollection.getHeaderName(key);
			this.checkRestricted(headerName, HttpHeaderType.Response);
			this.checkAllowed(HttpHeaderType.Response);
			this.set(headerName, value, HttpHeaderType.Response);
		}

		// Token: 0x06000376 RID: 886 RVA: 0x000169AC File Offset: 0x00014BAC
		public override void Set(string name, string value)
		{
			name = WebHeaderCollection.checkName(name, "name");
			value = WebHeaderCollection.checkValue(value, "value");
			HttpHeaderType headerType = WebHeaderCollection.getHeaderType(name);
			this.checkRestricted(name, headerType);
			this.checkAllowed(headerType);
			this.set(name, value, headerType);
		}

		// Token: 0x06000377 RID: 887 RVA: 0x000169F8 File Offset: 0x00014BF8
		public byte[] ToByteArray()
		{
			return Encoding.UTF8.GetBytes(this.ToString());
		}

		// Token: 0x06000378 RID: 888 RVA: 0x00016A1C File Offset: 0x00014C1C
		public override string ToString()
		{
			int count = this.Count;
			bool flag = count == 0;
			string result;
			if (flag)
			{
				result = "\r\n";
			}
			else
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < count; i++)
				{
					stringBuilder.AppendFormat("{0}: {1}\r\n", this.GetKey(i), this.Get(i));
				}
				stringBuilder.Append("\r\n");
				result = stringBuilder.ToString();
			}
			return result;
		}

		// Token: 0x06000379 RID: 889 RVA: 0x00016A8F File Offset: 0x00014C8F
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter, SerializationFormatter = true)]
		void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
			this.GetObjectData(serializationInfo, streamingContext);
		}

		// Token: 0x04000137 RID: 311
		private static readonly Dictionary<string, HttpHeaderInfo> _headers = new Dictionary<string, HttpHeaderInfo>(StringComparer.InvariantCultureIgnoreCase)
		{
			{
				"Accept",
				new HttpHeaderInfo("Accept", HttpHeaderType.Request | HttpHeaderType.Restricted | HttpHeaderType.MultiValue)
			},
			{
				"AcceptCharset",
				new HttpHeaderInfo("Accept-Charset", HttpHeaderType.Request | HttpHeaderType.MultiValue)
			},
			{
				"AcceptEncoding",
				new HttpHeaderInfo("Accept-Encoding", HttpHeaderType.Request | HttpHeaderType.MultiValue)
			},
			{
				"AcceptLanguage",
				new HttpHeaderInfo("Accept-Language", HttpHeaderType.Request | HttpHeaderType.MultiValue)
			},
			{
				"AcceptRanges",
				new HttpHeaderInfo("Accept-Ranges", HttpHeaderType.Response | HttpHeaderType.MultiValue)
			},
			{
				"Age",
				new HttpHeaderInfo("Age", HttpHeaderType.Response)
			},
			{
				"Allow",
				new HttpHeaderInfo("Allow", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.MultiValue)
			},
			{
				"Authorization",
				new HttpHeaderInfo("Authorization", HttpHeaderType.Request | HttpHeaderType.MultiValue)
			},
			{
				"CacheControl",
				new HttpHeaderInfo("Cache-Control", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.MultiValue)
			},
			{
				"Connection",
				new HttpHeaderInfo("Connection", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.Restricted | HttpHeaderType.MultiValue)
			},
			{
				"ContentEncoding",
				new HttpHeaderInfo("Content-Encoding", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.MultiValue)
			},
			{
				"ContentLanguage",
				new HttpHeaderInfo("Content-Language", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.MultiValue)
			},
			{
				"ContentLength",
				new HttpHeaderInfo("Content-Length", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.Restricted)
			},
			{
				"ContentLocation",
				new HttpHeaderInfo("Content-Location", HttpHeaderType.Request | HttpHeaderType.Response)
			},
			{
				"ContentMd5",
				new HttpHeaderInfo("Content-MD5", HttpHeaderType.Request | HttpHeaderType.Response)
			},
			{
				"ContentRange",
				new HttpHeaderInfo("Content-Range", HttpHeaderType.Request | HttpHeaderType.Response)
			},
			{
				"ContentType",
				new HttpHeaderInfo("Content-Type", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.Restricted)
			},
			{
				"Cookie",
				new HttpHeaderInfo("Cookie", HttpHeaderType.Request)
			},
			{
				"Cookie2",
				new HttpHeaderInfo("Cookie2", HttpHeaderType.Request)
			},
			{
				"Date",
				new HttpHeaderInfo("Date", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.Restricted)
			},
			{
				"Expect",
				new HttpHeaderInfo("Expect", HttpHeaderType.Request | HttpHeaderType.Restricted | HttpHeaderType.MultiValue)
			},
			{
				"Expires",
				new HttpHeaderInfo("Expires", HttpHeaderType.Request | HttpHeaderType.Response)
			},
			{
				"ETag",
				new HttpHeaderInfo("ETag", HttpHeaderType.Response)
			},
			{
				"From",
				new HttpHeaderInfo("From", HttpHeaderType.Request)
			},
			{
				"Host",
				new HttpHeaderInfo("Host", HttpHeaderType.Request | HttpHeaderType.Restricted)
			},
			{
				"IfMatch",
				new HttpHeaderInfo("If-Match", HttpHeaderType.Request | HttpHeaderType.MultiValue)
			},
			{
				"IfModifiedSince",
				new HttpHeaderInfo("If-Modified-Since", HttpHeaderType.Request | HttpHeaderType.Restricted)
			},
			{
				"IfNoneMatch",
				new HttpHeaderInfo("If-None-Match", HttpHeaderType.Request | HttpHeaderType.MultiValue)
			},
			{
				"IfRange",
				new HttpHeaderInfo("If-Range", HttpHeaderType.Request)
			},
			{
				"IfUnmodifiedSince",
				new HttpHeaderInfo("If-Unmodified-Since", HttpHeaderType.Request)
			},
			{
				"KeepAlive",
				new HttpHeaderInfo("Keep-Alive", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.MultiValue)
			},
			{
				"LastModified",
				new HttpHeaderInfo("Last-Modified", HttpHeaderType.Request | HttpHeaderType.Response)
			},
			{
				"Location",
				new HttpHeaderInfo("Location", HttpHeaderType.Response)
			},
			{
				"MaxForwards",
				new HttpHeaderInfo("Max-Forwards", HttpHeaderType.Request)
			},
			{
				"Pragma",
				new HttpHeaderInfo("Pragma", HttpHeaderType.Request | HttpHeaderType.Response)
			},
			{
				"ProxyAuthenticate",
				new HttpHeaderInfo("Proxy-Authenticate", HttpHeaderType.Response | HttpHeaderType.MultiValue)
			},
			{
				"ProxyAuthorization",
				new HttpHeaderInfo("Proxy-Authorization", HttpHeaderType.Request)
			},
			{
				"ProxyConnection",
				new HttpHeaderInfo("Proxy-Connection", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.Restricted)
			},
			{
				"Public",
				new HttpHeaderInfo("Public", HttpHeaderType.Response | HttpHeaderType.MultiValue)
			},
			{
				"Range",
				new HttpHeaderInfo("Range", HttpHeaderType.Request | HttpHeaderType.Restricted | HttpHeaderType.MultiValue)
			},
			{
				"Referer",
				new HttpHeaderInfo("Referer", HttpHeaderType.Request | HttpHeaderType.Restricted)
			},
			{
				"RetryAfter",
				new HttpHeaderInfo("Retry-After", HttpHeaderType.Response)
			},
			{
				"SecWebSocketAccept",
				new HttpHeaderInfo("Sec-WebSocket-Accept", HttpHeaderType.Response | HttpHeaderType.Restricted)
			},
			{
				"SecWebSocketExtensions",
				new HttpHeaderInfo("Sec-WebSocket-Extensions", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.Restricted | HttpHeaderType.MultiValueInRequest)
			},
			{
				"SecWebSocketKey",
				new HttpHeaderInfo("Sec-WebSocket-Key", HttpHeaderType.Request | HttpHeaderType.Restricted)
			},
			{
				"SecWebSocketProtocol",
				new HttpHeaderInfo("Sec-WebSocket-Protocol", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.MultiValueInRequest)
			},
			{
				"SecWebSocketVersion",
				new HttpHeaderInfo("Sec-WebSocket-Version", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.Restricted | HttpHeaderType.MultiValueInResponse)
			},
			{
				"Server",
				new HttpHeaderInfo("Server", HttpHeaderType.Response)
			},
			{
				"SetCookie",
				new HttpHeaderInfo("Set-Cookie", HttpHeaderType.Response | HttpHeaderType.MultiValue)
			},
			{
				"SetCookie2",
				new HttpHeaderInfo("Set-Cookie2", HttpHeaderType.Response | HttpHeaderType.MultiValue)
			},
			{
				"Te",
				new HttpHeaderInfo("TE", HttpHeaderType.Request)
			},
			{
				"Trailer",
				new HttpHeaderInfo("Trailer", HttpHeaderType.Request | HttpHeaderType.Response)
			},
			{
				"TransferEncoding",
				new HttpHeaderInfo("Transfer-Encoding", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.Restricted | HttpHeaderType.MultiValue)
			},
			{
				"Translate",
				new HttpHeaderInfo("Translate", HttpHeaderType.Request)
			},
			{
				"Upgrade",
				new HttpHeaderInfo("Upgrade", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.MultiValue)
			},
			{
				"UserAgent",
				new HttpHeaderInfo("User-Agent", HttpHeaderType.Request | HttpHeaderType.Restricted)
			},
			{
				"Vary",
				new HttpHeaderInfo("Vary", HttpHeaderType.Response | HttpHeaderType.MultiValue)
			},
			{
				"Via",
				new HttpHeaderInfo("Via", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.MultiValue)
			},
			{
				"Warning",
				new HttpHeaderInfo("Warning", HttpHeaderType.Request | HttpHeaderType.Response | HttpHeaderType.MultiValue)
			},
			{
				"WwwAuthenticate",
				new HttpHeaderInfo("WWW-Authenticate", HttpHeaderType.Response | HttpHeaderType.Restricted | HttpHeaderType.MultiValue)
			}
		};

		// Token: 0x04000138 RID: 312
		private bool _internallyUsed;

		// Token: 0x04000139 RID: 313
		private HttpHeaderType _state;
	}
}
