using System;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x02000032 RID: 50
	internal class HttpHeaderInfo
	{
		// Token: 0x06000385 RID: 901 RVA: 0x00010AC1 File Offset: 0x0000ECC1
		internal HttpHeaderInfo(string headerName, HttpHeaderType headerType)
		{
			this._headerName = headerName;
			this._headerType = headerType;
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000386 RID: 902 RVA: 0x00010AD7 File Offset: 0x0000ECD7
		internal bool IsMultiValueInRequest
		{
			get
			{
				return (this._headerType & HttpHeaderType.MultiValueInRequest) == HttpHeaderType.MultiValueInRequest;
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000387 RID: 903 RVA: 0x00010AE6 File Offset: 0x0000ECE6
		internal bool IsMultiValueInResponse
		{
			get
			{
				return (this._headerType & HttpHeaderType.MultiValueInResponse) == HttpHeaderType.MultiValueInResponse;
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x06000388 RID: 904 RVA: 0x00010AF5 File Offset: 0x0000ECF5
		public string HeaderName
		{
			get
			{
				return this._headerName;
			}
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x06000389 RID: 905 RVA: 0x00010AFD File Offset: 0x0000ECFD
		public HttpHeaderType HeaderType
		{
			get
			{
				return this._headerType;
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x0600038A RID: 906 RVA: 0x00010B05 File Offset: 0x0000ED05
		public bool IsRequest
		{
			get
			{
				return (this._headerType & HttpHeaderType.Request) == HttpHeaderType.Request;
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x0600038B RID: 907 RVA: 0x00010B12 File Offset: 0x0000ED12
		public bool IsResponse
		{
			get
			{
				return (this._headerType & HttpHeaderType.Response) == HttpHeaderType.Response;
			}
		}

		// Token: 0x0600038C RID: 908 RVA: 0x00010B1F File Offset: 0x0000ED1F
		public bool IsMultiValue(bool response)
		{
			if ((this._headerType & HttpHeaderType.MultiValue) != HttpHeaderType.MultiValue)
			{
				if (!response)
				{
					return this.IsMultiValueInRequest;
				}
				return this.IsMultiValueInResponse;
			}
			else
			{
				if (!response)
				{
					return this.IsRequest;
				}
				return this.IsResponse;
			}
		}

		// Token: 0x0600038D RID: 909 RVA: 0x00010B4D File Offset: 0x0000ED4D
		public bool IsRestricted(bool response)
		{
			if ((this._headerType & HttpHeaderType.Restricted) != HttpHeaderType.Restricted)
			{
				return false;
			}
			if (!response)
			{
				return this.IsRequest;
			}
			return this.IsResponse;
		}

		// Token: 0x04000142 RID: 322
		private string _headerName;

		// Token: 0x04000143 RID: 323
		private HttpHeaderType _headerType;
	}
}
