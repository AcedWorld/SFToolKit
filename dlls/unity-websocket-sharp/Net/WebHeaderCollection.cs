using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x0200004B RID: 75
	[ComVisible(true)]
	[Serializable]
	internal class WebHeaderCollection : NameValueCollection, ISerializable
	{
		// Token: 0x060004E6 RID: 1254 RVA: 0x00016829 File Offset: 0x00014A29
		internal WebHeaderCollection(HttpHeaderType state, bool internallyUsed)
		{
			this._state = state;
			this._internallyUsed = internallyUsed;
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x00016840 File Offset: 0x00014A40
		protected WebHeaderCollection(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
			if (serializationInfo == null)
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

		// Token: 0x060004E8 RID: 1256 RVA: 0x000168E8 File Offset: 0x00014AE8
		public WebHeaderCollection()
		{
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x060004E9 RID: 1257 RVA: 0x000168F0 File Offset: 0x00014AF0
		internal HttpHeaderType State
		{
			get
			{
				return this._state;
			}
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x060004EA RID: 1258 RVA: 0x000168F8 File Offset: 0x00014AF8
		public override string[] AllKeys
		{
			get
			{
				return base.AllKeys;
			}
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x060004EB RID: 1259 RVA: 0x00016900 File Offset: 0x00014B00
		public override int Count
		{
			get
			{
				return base.Count;
			}
		}

		// Token: 0x1700017A RID: 378
		public string this[HttpRequestHeader header]
		{
			get
			{
				string headerName = WebHeaderCollection.getHeaderName(header.ToString());
				return this.Get(headerName);
			}
			set
			{
				this.Add(header, value);
			}
		}

		// Token: 0x1700017B RID: 379
		public string this[HttpResponseHeader header]
		{
			get
			{
				string headerName = WebHeaderCollection.getHeaderName(header.ToString());
				return this.Get(headerName);
			}
			set
			{
				this.Add(header, value);
			}
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x060004F0 RID: 1264 RVA: 0x0001696D File Offset: 0x00014B6D
		public override NameObjectCollectionBase.KeysCollection Keys
		{
			get
			{
				return base.Keys;
			}
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x00016975 File Offset: 0x00014B75
		private void add(string name, string value, HttpHeaderType headerType)
		{
			base.Add(name, value);
			if (this._state != HttpHeaderType.Unspecified)
			{
				return;
			}
			if (headerType == HttpHeaderType.Unspecified)
			{
				return;
			}
			this._state = headerType;
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x00016993 File Offset: 0x00014B93
		private void checkAllowed(HttpHeaderType headerType)
		{
			if (this._state == HttpHeaderType.Unspecified)
			{
				return;
			}
			if (headerType == HttpHeaderType.Unspecified)
			{
				return;
			}
			if (headerType != this._state)
			{
				throw new InvalidOperationException("This instance does not allow the header.");
			}
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x000169B8 File Offset: 0x00014BB8
		private static string checkName(string name, string paramName)
		{
			if (name == null)
			{
				string message = "The name is null.";
				throw new ArgumentNullException(paramName, message);
			}
			if (name.Length == 0)
			{
				throw new ArgumentException("The name is an empty string.", paramName);
			}
			name = name.Trim();
			if (name.Length == 0)
			{
				throw new ArgumentException("The name is a string of spaces.", paramName);
			}
			if (!name.IsToken())
			{
				throw new ArgumentException("The name contains an invalid character.", paramName);
			}
			return name;
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x00016A1C File Offset: 0x00014C1C
		private void checkRestricted(string name, HttpHeaderType headerType)
		{
			if (this._internallyUsed)
			{
				return;
			}
			bool response = headerType == HttpHeaderType.Response;
			if (WebHeaderCollection.isRestricted(name, response))
			{
				throw new ArgumentException("The header is a restricted header.");
			}
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x00016A4C File Offset: 0x00014C4C
		private static string checkValue(string value, string paramName)
		{
			if (value == null)
			{
				return string.Empty;
			}
			value = value.Trim();
			int length = value.Length;
			if (length == 0)
			{
				return value;
			}
			if (length > 65535)
			{
				string message = "The length of the value is greater than 65,535 characters.";
				throw new ArgumentOutOfRangeException(paramName, message);
			}
			if (!value.IsText())
			{
				throw new ArgumentException("The value contains an invalid character.", paramName);
			}
			return value;
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x00016AA4 File Offset: 0x00014CA4
		private static HttpHeaderInfo getHeaderInfo(string name)
		{
			StringComparison comparisonType = StringComparison.InvariantCultureIgnoreCase;
			foreach (HttpHeaderInfo httpHeaderInfo in WebHeaderCollection._headers.Values)
			{
				if (httpHeaderInfo.HeaderName.Equals(name, comparisonType))
				{
					return httpHeaderInfo;
				}
			}
			return null;
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x00016B0C File Offset: 0x00014D0C
		private static string getHeaderName(string key)
		{
			HttpHeaderInfo httpHeaderInfo;
			if (!WebHeaderCollection._headers.TryGetValue(key, out httpHeaderInfo))
			{
				return null;
			}
			return httpHeaderInfo.HeaderName;
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x00016B30 File Offset: 0x00014D30
		private static HttpHeaderType getHeaderType(string name)
		{
			HttpHeaderInfo headerInfo = WebHeaderCollection.getHeaderInfo(name);
			if (headerInfo == null)
			{
				return HttpHeaderType.Unspecified;
			}
			if (headerInfo.IsRequest)
			{
				if (headerInfo.IsResponse)
				{
					return HttpHeaderType.Unspecified;
				}
				return HttpHeaderType.Request;
			}
			else
			{
				if (!headerInfo.IsResponse)
				{
					return HttpHeaderType.Unspecified;
				}
				return HttpHeaderType.Response;
			}
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x00016B68 File Offset: 0x00014D68
		private static bool isMultiValue(string name, bool response)
		{
			HttpHeaderInfo headerInfo = WebHeaderCollection.getHeaderInfo(name);
			return headerInfo != null && headerInfo.IsMultiValue(response);
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x00016B88 File Offset: 0x00014D88
		private static bool isRestricted(string name, bool response)
		{
			HttpHeaderInfo headerInfo = WebHeaderCollection.getHeaderInfo(name);
			return headerInfo != null && headerInfo.IsRestricted(response);
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x00016BA8 File Offset: 0x00014DA8
		private void set(string name, string value, HttpHeaderType headerType)
		{
			base.Set(name, value);
			if (this._state != HttpHeaderType.Unspecified)
			{
				return;
			}
			if (headerType == HttpHeaderType.Unspecified)
			{
				return;
			}
			this._state = headerType;
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x00016BC6 File Offset: 0x00014DC6
		internal void InternalRemove(string name)
		{
			base.Remove(name);
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x00016BD0 File Offset: 0x00014DD0
		internal void InternalSet(string header, bool response)
		{
			int num = header.IndexOf(':');
			if (num == -1)
			{
				throw new ArgumentException("It does not contain a colon character.", "header");
			}
			string name = header.Substring(0, num);
			string value = (num < header.Length - 1) ? header.Substring(num + 1) : string.Empty;
			name = WebHeaderCollection.checkName(name, "header");
			value = WebHeaderCollection.checkValue(value, "header");
			if (WebHeaderCollection.isMultiValue(name, response))
			{
				base.Add(name, value);
				return;
			}
			base.Set(name, value);
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x00016C51 File Offset: 0x00014E51
		internal void InternalSet(string name, string value, bool response)
		{
			value = WebHeaderCollection.checkValue(value, "value");
			if (WebHeaderCollection.isMultiValue(name, response))
			{
				base.Add(name, value);
				return;
			}
			base.Set(name, value);
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x00016C7C File Offset: 0x00014E7C
		internal string ToStringMultiValue(bool response)
		{
			int count = this.Count;
			if (count == 0)
			{
				return "\r\n";
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < count; i++)
			{
				string key = this.GetKey(i);
				if (WebHeaderCollection.isMultiValue(key, response))
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
			return stringBuilder.ToString();
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x00016D18 File Offset: 0x00014F18
		protected void AddWithoutValidate(string headerName, string headerValue)
		{
			headerName = WebHeaderCollection.checkName(headerName, "headerName");
			headerValue = WebHeaderCollection.checkValue(headerValue, "headerValue");
			HttpHeaderType headerType = WebHeaderCollection.getHeaderType(headerName);
			this.checkAllowed(headerType);
			this.add(headerName, headerValue, headerType);
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x00016D58 File Offset: 0x00014F58
		public void Add(string header)
		{
			if (header == null)
			{
				throw new ArgumentNullException("header");
			}
			int length = header.Length;
			if (length == 0)
			{
				throw new ArgumentException("An empty string.", "header");
			}
			int num = header.IndexOf(':');
			if (num == -1)
			{
				throw new ArgumentException("It does not contain a colon character.", "header");
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

		// Token: 0x06000502 RID: 1282 RVA: 0x00016E08 File Offset: 0x00015008
		public void Add(HttpRequestHeader header, string value)
		{
			value = WebHeaderCollection.checkValue(value, "value");
			string headerName = WebHeaderCollection.getHeaderName(header.ToString());
			this.checkRestricted(headerName, HttpHeaderType.Request);
			this.checkAllowed(HttpHeaderType.Request);
			this.add(headerName, value, HttpHeaderType.Request);
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x00016E50 File Offset: 0x00015050
		public void Add(HttpResponseHeader header, string value)
		{
			value = WebHeaderCollection.checkValue(value, "value");
			string headerName = WebHeaderCollection.getHeaderName(header.ToString());
			this.checkRestricted(headerName, HttpHeaderType.Response);
			this.checkAllowed(HttpHeaderType.Response);
			this.add(headerName, value, HttpHeaderType.Response);
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x00016E98 File Offset: 0x00015098
		public override void Add(string name, string value)
		{
			name = WebHeaderCollection.checkName(name, "name");
			value = WebHeaderCollection.checkValue(value, "value");
			HttpHeaderType headerType = WebHeaderCollection.getHeaderType(name);
			this.checkRestricted(name, headerType);
			this.checkAllowed(headerType);
			this.add(name, value, headerType);
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x00016EDE File Offset: 0x000150DE
		public override void Clear()
		{
			base.Clear();
			this._state = HttpHeaderType.Unspecified;
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x00016EED File Offset: 0x000150ED
		public override string Get(int index)
		{
			return base.Get(index);
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x00016EF6 File Offset: 0x000150F6
		public override string Get(string name)
		{
			return base.Get(name);
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x00016EFF File Offset: 0x000150FF
		public override IEnumerator GetEnumerator()
		{
			return base.GetEnumerator();
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x00016F07 File Offset: 0x00015107
		public override string GetKey(int index)
		{
			return base.GetKey(index);
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x00016F10 File Offset: 0x00015110
		public override string[] GetValues(int index)
		{
			string[] values = base.GetValues(index);
			if (values == null || values.Length == 0)
			{
				return null;
			}
			return values;
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x00016F30 File Offset: 0x00015130
		public override string[] GetValues(string name)
		{
			string[] values = base.GetValues(name);
			if (values == null || values.Length == 0)
			{
				return null;
			}
			return values;
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x00016F50 File Offset: 0x00015150
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
		public override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
			if (serializationInfo == null)
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

		// Token: 0x0600050D RID: 1293 RVA: 0x00016FD8 File Offset: 0x000151D8
		public static bool IsRestricted(string headerName)
		{
			return WebHeaderCollection.IsRestricted(headerName, false);
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x00016FE1 File Offset: 0x000151E1
		public static bool IsRestricted(string headerName, bool response)
		{
			headerName = WebHeaderCollection.checkName(headerName, "headerName");
			return WebHeaderCollection.isRestricted(headerName, response);
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x00016FF7 File Offset: 0x000151F7
		public override void OnDeserialization(object sender)
		{
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x00016FFC File Offset: 0x000151FC
		public void Remove(HttpRequestHeader header)
		{
			string headerName = WebHeaderCollection.getHeaderName(header.ToString());
			this.checkRestricted(headerName, HttpHeaderType.Request);
			this.checkAllowed(HttpHeaderType.Request);
			base.Remove(headerName);
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x00017034 File Offset: 0x00015234
		public void Remove(HttpResponseHeader header)
		{
			string headerName = WebHeaderCollection.getHeaderName(header.ToString());
			this.checkRestricted(headerName, HttpHeaderType.Response);
			this.checkAllowed(HttpHeaderType.Response);
			base.Remove(headerName);
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x0001706C File Offset: 0x0001526C
		public override void Remove(string name)
		{
			name = WebHeaderCollection.checkName(name, "name");
			HttpHeaderType headerType = WebHeaderCollection.getHeaderType(name);
			this.checkRestricted(name, headerType);
			this.checkAllowed(headerType);
			base.Remove(name);
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x000170A4 File Offset: 0x000152A4
		public void Set(HttpRequestHeader header, string value)
		{
			value = WebHeaderCollection.checkValue(value, "value");
			string headerName = WebHeaderCollection.getHeaderName(header.ToString());
			this.checkRestricted(headerName, HttpHeaderType.Request);
			this.checkAllowed(HttpHeaderType.Request);
			this.set(headerName, value, HttpHeaderType.Request);
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x000170EC File Offset: 0x000152EC
		public void Set(HttpResponseHeader header, string value)
		{
			value = WebHeaderCollection.checkValue(value, "value");
			string headerName = WebHeaderCollection.getHeaderName(header.ToString());
			this.checkRestricted(headerName, HttpHeaderType.Response);
			this.checkAllowed(HttpHeaderType.Response);
			this.set(headerName, value, HttpHeaderType.Response);
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x00017134 File Offset: 0x00015334
		public override void Set(string name, string value)
		{
			name = WebHeaderCollection.checkName(name, "name");
			value = WebHeaderCollection.checkValue(value, "value");
			HttpHeaderType headerType = WebHeaderCollection.getHeaderType(name);
			this.checkRestricted(name, headerType);
			this.checkAllowed(headerType);
			this.set(name, value, headerType);
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x0001717A File Offset: 0x0001537A
		public byte[] ToByteArray()
		{
			return Encoding.UTF8.GetBytes(this.ToString());
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x0001718C File Offset: 0x0001538C
		public override string ToString()
		{
			int count = this.Count;
			if (count == 0)
			{
				return "\r\n";
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < count; i++)
			{
				stringBuilder.AppendFormat("{0}: {1}\r\n", this.GetKey(i), this.Get(i));
			}
			stringBuilder.Append("\r\n");
			return stringBuilder.ToString();
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x000171E7 File Offset: 0x000153E7
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter, SerializationFormatter = true)]
		void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
			this.GetObjectData(serializationInfo, streamingContext);
		}

		// Token: 0x0400025A RID: 602
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

		// Token: 0x0400025B RID: 603
		private bool _internallyUsed;

		// Token: 0x0400025C RID: 604
		private HttpHeaderType _state;
	}
}
