using System;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace WebSocketSharp.Net
{
	// Token: 0x0200003E RID: 62
	public class ServerSslConfiguration
	{
		// Token: 0x06000400 RID: 1024 RVA: 0x00018A9B File Offset: 0x00016C9B
		public ServerSslConfiguration()
		{
			this._enabledSslProtocols = SslProtocols.None;
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x00018AAC File Offset: 0x00016CAC
		public ServerSslConfiguration(ServerSslConfiguration configuration)
		{
			bool flag = configuration == null;
			if (flag)
			{
				throw new ArgumentNullException("configuration");
			}
			this._checkCertRevocation = configuration._checkCertRevocation;
			this._clientCertRequired = configuration._clientCertRequired;
			this._clientCertValidationCallback = configuration._clientCertValidationCallback;
			this._enabledSslProtocols = configuration._enabledSslProtocols;
			this._serverCert = configuration._serverCert;
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000402 RID: 1026 RVA: 0x00018B10 File Offset: 0x00016D10
		// (set) Token: 0x06000403 RID: 1027 RVA: 0x00018B28 File Offset: 0x00016D28
		public bool CheckCertificateRevocation
		{
			get
			{
				return this._checkCertRevocation;
			}
			set
			{
				this._checkCertRevocation = value;
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000404 RID: 1028 RVA: 0x00018B34 File Offset: 0x00016D34
		// (set) Token: 0x06000405 RID: 1029 RVA: 0x00018B4C File Offset: 0x00016D4C
		public bool ClientCertificateRequired
		{
			get
			{
				return this._clientCertRequired;
			}
			set
			{
				this._clientCertRequired = value;
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x06000406 RID: 1030 RVA: 0x00018B58 File Offset: 0x00016D58
		// (set) Token: 0x06000407 RID: 1031 RVA: 0x00018B8F File Offset: 0x00016D8F
		public RemoteCertificateValidationCallback ClientCertificateValidationCallback
		{
			get
			{
				bool flag = this._clientCertValidationCallback == null;
				if (flag)
				{
					this._clientCertValidationCallback = new RemoteCertificateValidationCallback(ServerSslConfiguration.defaultValidateClientCertificate);
				}
				return this._clientCertValidationCallback;
			}
			set
			{
				this._clientCertValidationCallback = value;
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x06000408 RID: 1032 RVA: 0x00018B9C File Offset: 0x00016D9C
		// (set) Token: 0x06000409 RID: 1033 RVA: 0x00018BB4 File Offset: 0x00016DB4
		public SslProtocols EnabledSslProtocols
		{
			get
			{
				return this._enabledSslProtocols;
			}
			set
			{
				this._enabledSslProtocols = value;
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x0600040A RID: 1034 RVA: 0x00018BC0 File Offset: 0x00016DC0
		// (set) Token: 0x0600040B RID: 1035 RVA: 0x00018BD8 File Offset: 0x00016DD8
		public X509Certificate2 ServerCertificate
		{
			get
			{
				return this._serverCert;
			}
			set
			{
				this._serverCert = value;
			}
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x00018BE4 File Offset: 0x00016DE4
		private static bool defaultValidateClientCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			return true;
		}

		// Token: 0x040001A5 RID: 421
		private bool _checkCertRevocation;

		// Token: 0x040001A6 RID: 422
		private bool _clientCertRequired;

		// Token: 0x040001A7 RID: 423
		private RemoteCertificateValidationCallback _clientCertValidationCallback;

		// Token: 0x040001A8 RID: 424
		private SslProtocols _enabledSslProtocols;

		// Token: 0x040001A9 RID: 425
		private X509Certificate2 _serverCert;
	}
}
