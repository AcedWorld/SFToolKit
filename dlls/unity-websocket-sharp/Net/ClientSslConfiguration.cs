using System;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x02000029 RID: 41
	internal class ClientSslConfiguration
	{
		// Token: 0x060002D8 RID: 728 RVA: 0x0000DC52 File Offset: 0x0000BE52
		public ClientSslConfiguration(string targetHost)
		{
			if (targetHost == null)
			{
				throw new ArgumentNullException("targetHost");
			}
			if (targetHost.Length == 0)
			{
				throw new ArgumentException("An empty string.", "targetHost");
			}
			this._targetHost = targetHost;
			this._enabledSslProtocols = SslProtocols.None;
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0000DC90 File Offset: 0x0000BE90
		public ClientSslConfiguration(ClientSslConfiguration configuration)
		{
			if (configuration == null)
			{
				throw new ArgumentNullException("configuration");
			}
			this._checkCertRevocation = configuration._checkCertRevocation;
			this._clientCertSelectionCallback = configuration._clientCertSelectionCallback;
			this._clientCerts = configuration._clientCerts;
			this._enabledSslProtocols = configuration._enabledSslProtocols;
			this._serverCertValidationCallback = configuration._serverCertValidationCallback;
			this._targetHost = configuration._targetHost;
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x060002DA RID: 730 RVA: 0x0000DCF9 File Offset: 0x0000BEF9
		// (set) Token: 0x060002DB RID: 731 RVA: 0x0000DD01 File Offset: 0x0000BF01
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

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x060002DC RID: 732 RVA: 0x0000DD0A File Offset: 0x0000BF0A
		// (set) Token: 0x060002DD RID: 733 RVA: 0x0000DD12 File Offset: 0x0000BF12
		public X509CertificateCollection ClientCertificates
		{
			get
			{
				return this._clientCerts;
			}
			set
			{
				this._clientCerts = value;
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x060002DE RID: 734 RVA: 0x0000DD1B File Offset: 0x0000BF1B
		// (set) Token: 0x060002DF RID: 735 RVA: 0x0000DD3D File Offset: 0x0000BF3D
		public LocalCertificateSelectionCallback ClientCertificateSelectionCallback
		{
			get
			{
				if (this._clientCertSelectionCallback == null)
				{
					this._clientCertSelectionCallback = new LocalCertificateSelectionCallback(ClientSslConfiguration.defaultSelectClientCertificate);
				}
				return this._clientCertSelectionCallback;
			}
			set
			{
				this._clientCertSelectionCallback = value;
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x0000DD46 File Offset: 0x0000BF46
		// (set) Token: 0x060002E1 RID: 737 RVA: 0x0000DD4E File Offset: 0x0000BF4E
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

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x060002E2 RID: 738 RVA: 0x0000DD57 File Offset: 0x0000BF57
		// (set) Token: 0x060002E3 RID: 739 RVA: 0x0000DD79 File Offset: 0x0000BF79
		public RemoteCertificateValidationCallback ServerCertificateValidationCallback
		{
			get
			{
				if (this._serverCertValidationCallback == null)
				{
					this._serverCertValidationCallback = new RemoteCertificateValidationCallback(ClientSslConfiguration.defaultValidateServerCertificate);
				}
				return this._serverCertValidationCallback;
			}
			set
			{
				this._serverCertValidationCallback = value;
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x060002E4 RID: 740 RVA: 0x0000DD82 File Offset: 0x0000BF82
		// (set) Token: 0x060002E5 RID: 741 RVA: 0x0000DD8A File Offset: 0x0000BF8A
		public string TargetHost
		{
			get
			{
				return this._targetHost;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (value.Length == 0)
				{
					throw new ArgumentException("An empty string.", "value");
				}
				this._targetHost = value;
			}
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x0000DDB9 File Offset: 0x0000BFB9
		private static X509Certificate defaultSelectClientCertificate(object sender, string targetHost, X509CertificateCollection clientCertificates, X509Certificate serverCertificate, string[] acceptableIssuers)
		{
			return null;
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x0000DDBC File Offset: 0x0000BFBC
		private static bool defaultValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			return true;
		}

		// Token: 0x04000104 RID: 260
		private bool _checkCertRevocation;

		// Token: 0x04000105 RID: 261
		private LocalCertificateSelectionCallback _clientCertSelectionCallback;

		// Token: 0x04000106 RID: 262
		private X509CertificateCollection _clientCerts;

		// Token: 0x04000107 RID: 263
		private SslProtocols _enabledSslProtocols;

		// Token: 0x04000108 RID: 264
		private RemoteCertificateValidationCallback _serverCertValidationCallback;

		// Token: 0x04000109 RID: 265
		private string _targetHost;
	}
}
