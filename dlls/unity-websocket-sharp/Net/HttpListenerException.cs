using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x02000037 RID: 55
	[Serializable]
	internal class HttpListenerException : Win32Exception
	{
		// Token: 0x060003DC RID: 988 RVA: 0x00011A68 File Offset: 0x0000FC68
		protected HttpListenerException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
		{
		}

		// Token: 0x060003DD RID: 989 RVA: 0x00011A72 File Offset: 0x0000FC72
		public HttpListenerException()
		{
		}

		// Token: 0x060003DE RID: 990 RVA: 0x00011A7A File Offset: 0x0000FC7A
		public HttpListenerException(int errorCode) : base(errorCode)
		{
		}

		// Token: 0x060003DF RID: 991 RVA: 0x00011A83 File Offset: 0x0000FC83
		public HttpListenerException(int errorCode, string message) : base(errorCode, message)
		{
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x060003E0 RID: 992 RVA: 0x00011A8D File Offset: 0x0000FC8D
		public override int ErrorCode
		{
			get
			{
				return base.NativeErrorCode;
			}
		}
	}
}
