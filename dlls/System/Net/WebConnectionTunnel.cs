using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net
{
	// Token: 0x020006C4 RID: 1732
	internal class WebConnectionTunnel
	{
		// Token: 0x17000BA3 RID: 2979
		// (get) Token: 0x060037B4 RID: 14260 RVA: 0x000C3CE6 File Offset: 0x000C1EE6
		public HttpWebRequest Request { get; }

		// Token: 0x17000BA4 RID: 2980
		// (get) Token: 0x060037B5 RID: 14261 RVA: 0x000C3CEE File Offset: 0x000C1EEE
		public Uri ConnectUri { get; }

		// Token: 0x060037B6 RID: 14262 RVA: 0x000C3CF6 File Offset: 0x000C1EF6
		public WebConnectionTunnel(HttpWebRequest request, Uri connectUri)
		{
			this.Request = request;
			this.ConnectUri = connectUri;
		}

		// Token: 0x17000BA5 RID: 2981
		// (get) Token: 0x060037B7 RID: 14263 RVA: 0x000C3D0C File Offset: 0x000C1F0C
		// (set) Token: 0x060037B8 RID: 14264 RVA: 0x000C3D14 File Offset: 0x000C1F14
		public bool Success { get; private set; }

		// Token: 0x17000BA6 RID: 2982
		// (get) Token: 0x060037B9 RID: 14265 RVA: 0x000C3D1D File Offset: 0x000C1F1D
		// (set) Token: 0x060037BA RID: 14266 RVA: 0x000C3D25 File Offset: 0x000C1F25
		public bool CloseConnection { get; private set; }

		// Token: 0x17000BA7 RID: 2983
		// (get) Token: 0x060037BB RID: 14267 RVA: 0x000C3D2E File Offset: 0x000C1F2E
		// (set) Token: 0x060037BC RID: 14268 RVA: 0x000C3D36 File Offset: 0x000C1F36
		public int StatusCode { get; private set; }

		// Token: 0x17000BA8 RID: 2984
		// (get) Token: 0x060037BD RID: 14269 RVA: 0x000C3D3F File Offset: 0x000C1F3F
		// (set) Token: 0x060037BE RID: 14270 RVA: 0x000C3D47 File Offset: 0x000C1F47
		public string StatusDescription { get; private set; }

		// Token: 0x17000BA9 RID: 2985
		// (get) Token: 0x060037BF RID: 14271 RVA: 0x000C3D50 File Offset: 0x000C1F50
		// (set) Token: 0x060037C0 RID: 14272 RVA: 0x000C3D58 File Offset: 0x000C1F58
		public string[] Challenge { get; private set; }

		// Token: 0x17000BAA RID: 2986
		// (get) Token: 0x060037C1 RID: 14273 RVA: 0x000C3D61 File Offset: 0x000C1F61
		// (set) Token: 0x060037C2 RID: 14274 RVA: 0x000C3D69 File Offset: 0x000C1F69
		public WebHeaderCollection Headers { get; private set; }

		// Token: 0x17000BAB RID: 2987
		// (get) Token: 0x060037C3 RID: 14275 RVA: 0x000C3D72 File Offset: 0x000C1F72
		// (set) Token: 0x060037C4 RID: 14276 RVA: 0x000C3D7A File Offset: 0x000C1F7A
		public Version ProxyVersion { get; private set; }

		// Token: 0x17000BAC RID: 2988
		// (get) Token: 0x060037C5 RID: 14277 RVA: 0x000C3D83 File Offset: 0x000C1F83
		// (set) Token: 0x060037C6 RID: 14278 RVA: 0x000C3D8B File Offset: 0x000C1F8B
		public byte[] Data { get; private set; }

		// Token: 0x060037C7 RID: 14279 RVA: 0x000C3D94 File Offset: 0x000C1F94
		internal Task Initialize(Stream stream, CancellationToken cancellationToken)
		{
			WebConnectionTunnel.<Initialize>d__42 <Initialize>d__;
			<Initialize>d__.<>4__this = this;
			<Initialize>d__.stream = stream;
			<Initialize>d__.cancellationToken = cancellationToken;
			<Initialize>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<Initialize>d__.<>1__state = -1;
			<Initialize>d__.<>t__builder.Start<WebConnectionTunnel.<Initialize>d__42>(ref <Initialize>d__);
			return <Initialize>d__.<>t__builder.Task;
		}

		// Token: 0x060037C8 RID: 14280 RVA: 0x000C3DE8 File Offset: 0x000C1FE8
		private Task<ValueTuple<WebHeaderCollection, byte[], int>> ReadHeaders(Stream stream, CancellationToken cancellationToken)
		{
			WebConnectionTunnel.<ReadHeaders>d__43 <ReadHeaders>d__;
			<ReadHeaders>d__.<>4__this = this;
			<ReadHeaders>d__.stream = stream;
			<ReadHeaders>d__.cancellationToken = cancellationToken;
			<ReadHeaders>d__.<>t__builder = AsyncTaskMethodBuilder<ValueTuple<WebHeaderCollection, byte[], int>>.Create();
			<ReadHeaders>d__.<>1__state = -1;
			<ReadHeaders>d__.<>t__builder.Start<WebConnectionTunnel.<ReadHeaders>d__43>(ref <ReadHeaders>d__);
			return <ReadHeaders>d__.<>t__builder.Task;
		}

		// Token: 0x060037C9 RID: 14281 RVA: 0x000C3E3C File Offset: 0x000C203C
		private void FlushContents(Stream stream, int contentLength)
		{
			while (contentLength > 0)
			{
				byte[] buffer = new byte[contentLength];
				int num = stream.Read(buffer, 0, contentLength);
				if (num <= 0)
				{
					break;
				}
				contentLength -= num;
			}
		}

		// Token: 0x04002085 RID: 8325
		private HttpWebRequest connectRequest;

		// Token: 0x04002086 RID: 8326
		private WebConnectionTunnel.NtlmAuthState ntlmAuthState;

		// Token: 0x020006C5 RID: 1733
		private enum NtlmAuthState
		{
			// Token: 0x04002090 RID: 8336
			None,
			// Token: 0x04002091 RID: 8337
			Challenge,
			// Token: 0x04002092 RID: 8338
			Response
		}
	}
}
