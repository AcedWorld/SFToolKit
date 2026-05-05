using System;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace WebSocketSharp.Net
{
	// Token: 0x0200003D RID: 61
	public class ClientSslConfiguration
	{
		// Token: 0x060003F0 RID: 1008 RVA: 0x0001885C File Offset: 0x00016A5C
		public ClientSslConfiguration(string targetHost)
		{
			bool flag = targetHost == null;
			if (flag)
			{
				throw new ArgumentNullException("targetHost");
			}
			bool flag2 = targetHost.Length == 0;
			if (flag2)
			{
				throw new ArgumentException("An empty string.", "targetHost");
			}
			this._targetHost = targetHost;
			this._enabledSslProtocols = SslProtocols.None;
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x000188B0 File Offset: 0x00016AB0
		public ClientSslConfiguration(ClientSslConfiguration configuration)
		{
			bool flag = configuration == null;
			if (flag)
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

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x060003F2 RID: 1010 RVA: 0x00018920 File Offset: 0x00016B20
		// (set) Token: 0x060003F3 RID: 1011 RVA: 0x00018938 File Offset: 0x00016B38
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

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x060003F4 RID: 1012 RVA: 0x00018944 File Offset: 0x00016B44
		// (set) Token: 0x060003F5 RID: 1013 RVA: 0x0001895C File Offset: 0x00016B5C
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

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x060003F6 RID: 1014 RVA: 0x00018968 File Offset: 0x00016B68
		// (set) Token: 0x060003F7 RID: 1015 RVA: 0x0001899F File Offset: 0x00016B9F
		public LocalCertificateSelectionCallback ClientCertificateSelectionCallback
		{
			get
			{
				bool flag = this._clientCertSelectionCallback == null;
				if (flag)
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

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x060003F8 RID: 1016 RVA: 0x000189AC File Offset: 0x00016BAC
		// (set) Token: 0x060003F9 RID: 1017 RVA: 0x000189C4 File Offset: 0x00016BC4
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

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x060003FA RID: 1018 RVA: 0x000189D0 File Offset: 0x00016BD0
		// (set) Token: 0x060003FB RID: 1019 RVA: 0x00018A07 File Offset: 0x00016C07
		public RemoteCertificateValidationCallback ServerCertificateValidationCallback
		{
			get
			{
				bool flag = this._serverCertValidationCallback == null;
				if (flag)
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

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x060003FC RID: 1020 RVA: 0x00018A14 File Offset: 0x00016C14
		// (set) Token: 0x060003FD RID: 1021 RVA: 0x00018A2C File Offset: 0x00016C2C
		public string TargetHost
		{
			get
			{
				return this._targetHost;
			}
			set
			{
				bool flag = value == null;
				if (flag)
				{
					throw new ArgumentNullException("value");
				}
				bool flag2 = value.Length == 0;
				if (flag2)
				{
					throw new ArgumentException("An empty string.", "value");
				}
				this._targetHost = value;
			}
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x00018A74 File Offset: 0x00016C74
		private static X509Certificate defaultSelectClientCertificate(object sender, string targetHost, X509CertificateCollection clientCertificates, X509Certificate serverCertificate, string[] acceptableIssuers)
		{
			return null;
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x00018A88 File Offset: 0x00016C88
		private static bool defaultValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			return true;
		}

		// Token: 0x0400019F RID: 415
		private bool _checkCertRevocation;

		// Token: 0x040001A0 RID: 416
		private LocalCertificateSelectionCallback _clientCertSelectionCallback;

		// Token: 0x040001A1 RID: 417
		private X509CertificateCollection _clientCerts;

		// Token: 0x040001A2 RID: 418
		private SslProtocols _enabledSslProtocols;

		// Token: 0x040001A3 RID: 419
		private RemoteCertificateValidationCallback _serverCertValidationCallback;

		// Token: 0x040001A4 RID: 420
		private string _targetHost;
	}
}
