using System;

namespace WebSocketSharp.Net
{
	// Token: 0x0200002E RID: 46
	internal class HttpHeaderInfo
	{
		// Token: 0x0600037C RID: 892 RVA: 0x00016AB5 File Offset: 0x00014CB5
		internal HttpHeaderInfo(string headerName, HttpHeaderType headerType)
		{
			this._headerName = headerName;
			this._headerType = headerType;
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x0600037D RID: 893 RVA: 0x00016AD0 File Offset: 0x00014CD0
		internal bool IsMultiValueInRequest
		{
			get
			{
				HttpHeaderType httpHeaderType = this._headerType & HttpHeaderType.MultiValueInRequest;
				return httpHeaderType == HttpHeaderType.MultiValueInRequest;
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x0600037E RID: 894 RVA: 0x00016AF4 File Offset: 0x00014CF4
		internal bool IsMultiValueInResponse
		{
			get
			{
				HttpHeaderType httpHeaderType = this._headerType & HttpHeaderType.MultiValueInResponse;
				return httpHeaderType == HttpHeaderType.MultiValueInResponse;
			}
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x0600037F RID: 895 RVA: 0x00016B18 File Offset: 0x00014D18
		public string HeaderName
		{
			get
			{
				return this._headerName;
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000380 RID: 896 RVA: 0x00016B30 File Offset: 0x00014D30
		public HttpHeaderType HeaderType
		{
			get
			{
				return this._headerType;
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06000381 RID: 897 RVA: 0x00016B48 File Offset: 0x00014D48
		public bool IsRequest
		{
			get
			{
				HttpHeaderType httpHeaderType = this._headerType & HttpHeaderType.Request;
				return httpHeaderType == HttpHeaderType.Request;
			}
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x06000382 RID: 898 RVA: 0x00016B68 File Offset: 0x00014D68
		public bool IsResponse
		{
			get
			{
				HttpHeaderType httpHeaderType = this._headerType & HttpHeaderType.Response;
				return httpHeaderType == HttpHeaderType.Response;
			}
		}

		// Token: 0x06000383 RID: 899 RVA: 0x00016B88 File Offset: 0x00014D88
		public bool IsMultiValue(bool response)
		{
			HttpHeaderType httpHeaderType = this._headerType & HttpHeaderType.MultiValue;
			bool flag = httpHeaderType != HttpHeaderType.MultiValue;
			bool result;
			if (flag)
			{
				result = (response ? this.IsMultiValueInResponse : this.IsMultiValueInRequest);
			}
			else
			{
				result = (response ? this.IsResponse : this.IsRequest);
			}
			return result;
		}

		// Token: 0x06000384 RID: 900 RVA: 0x00016BD4 File Offset: 0x00014DD4
		public bool IsRestricted(bool response)
		{
			HttpHeaderType httpHeaderType = this._headerType & HttpHeaderType.Restricted;
			bool flag = httpHeaderType != HttpHeaderType.Restricted;
			return !flag && (response ? this.IsResponse : this.IsRequest);
		}

		// Token: 0x04000173 RID: 371
		private string _headerName;

		// Token: 0x04000174 RID: 372
		private HttpHeaderType _headerType;
	}
}
