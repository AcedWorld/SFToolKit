using System;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x0200004A RID: 74
	internal class ServerSslConfiguration
	{
		// Token: 0x060004D8 RID: 1240 RVA: 0x000161E9 File Offset: 0x000143E9
		public ServerSslConfiguration()
		{
			this._enabledSslProtocols = SslProtocols.None;
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x000161F8 File Offset: 0x000143F8
		public ServerSslConfiguration(ServerSslConfiguration configuration)
		{
			if (configuration == null)
			{
				throw new ArgumentNullException("configuration");
			}
			this._checkCertRevocation = configuration._checkCertRevocation;
			this._clientCertRequired = configuration._clientCertRequired;
			this._clientCertValidationCallback = configuration._clientCertValidationCallback;
			this._enabledSslProtocols = configuration._enabledSslProtocols;
			this._serverCert = configuration._serverCert;
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x060004DA RID: 1242 RVA: 0x00016255 File Offset: 0x00014455
		// (set) Token: 0x060004DB RID: 1243 RVA: 0x0001625D File Offset: 0x0001445D
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

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x060004DC RID: 1244 RVA: 0x00016266 File Offset: 0x00014466
		// (set) Token: 0x060004DD RID: 1245 RVA: 0x0001626E File Offset: 0x0001446E
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

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x060004DE RID: 1246 RVA: 0x00016277 File Offset: 0x00014477
		// (set) Token: 0x060004DF RID: 1247 RVA: 0x00016299 File Offset: 0x00014499
		public RemoteCertificateValidationCallback ClientCertificateValidationCallback
		{
			get
			{
				if (this._clientCertValidationCallback == null)
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

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x060004E0 RID: 1248 RVA: 0x000162A2 File Offset: 0x000144A2
		// (set) Token: 0x060004E1 RID: 1249 RVA: 0x000162AA File Offset: 0x000144AA
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

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x060004E2 RID: 1250 RVA: 0x000162B3 File Offset: 0x000144B3
		// (set) Token: 0x060004E3 RID: 1251 RVA: 0x000162BB File Offset: 0x000144BB
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

		// Token: 0x060004E4 RID: 1252 RVA: 0x000162C4 File Offset: 0x000144C4
		private static bool defaultValidateClientCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			return true;
		}

		// Token: 0x04000255 RID: 597
		private bool _checkCertRevocation;

		// Token: 0x04000256 RID: 598
		private bool _clientCertRequired;

		// Token: 0x04000257 RID: 599
		private RemoteCertificateValidationCallback _clientCertValidationCallback;

		// Token: 0x04000258 RID: 600
		private SslProtocols _enabledSslProtocols;

		// Token: 0x04000259 RID: 601
		private X509Certificate2 _serverCert;
	}
}
