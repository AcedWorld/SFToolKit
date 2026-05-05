using System;
using System.IO;
using UnityEngine;

namespace Unity.Netcode.Transports.UTP
{
	// Token: 0x02000128 RID: 296
	public class SecretsLoaderHelper : MonoBehaviour
	{
		// Token: 0x06000951 RID: 2385 RVA: 0x00023600 File Offset: 0x00021800
		private void Awake()
		{
			SecretsLoaderHelper.ServerSecrets serverSecrets = default(SecretsLoaderHelper.ServerSecrets);
			try
			{
				serverSecrets.ServerCertificate = this.ServerCertificate;
			}
			catch (Exception message)
			{
				Debug.Log(message);
			}
			try
			{
				serverSecrets.ServerPrivate = this.ServerPrivate;
			}
			catch (Exception message2)
			{
				Debug.Log(message2);
			}
			SecretsLoaderHelper.ClientSecrets clientSecrets = default(SecretsLoaderHelper.ClientSecrets);
			try
			{
				clientSecrets.ClientCertificate = this.ClientCA;
			}
			catch (Exception message3)
			{
				Debug.Log(message3);
			}
			try
			{
				clientSecrets.ServerCommonName = this.ServerCommonName;
			}
			catch (Exception message4)
			{
				Debug.Log(message4);
			}
			UnityTransport component = base.GetComponent<UnityTransport>();
			if (component == null)
			{
				Debug.LogError("You need to select the UnityTransport protocol, in the NetworkManager, in order for the SecretsLoaderHelper component to be useful.");
				return;
			}
			component.SetServerSecrets(serverSecrets.ServerCertificate, serverSecrets.ServerPrivate);
			component.SetClientSecrets(clientSecrets.ServerCommonName, clientSecrets.ClientCertificate);
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000952 RID: 2386 RVA: 0x000236EC File Offset: 0x000218EC
		// (set) Token: 0x06000953 RID: 2387 RVA: 0x000236F4 File Offset: 0x000218F4
		public string ServerCommonName
		{
			get
			{
				return this.m_ServerCommonName;
			}
			set
			{
				this.m_ServerCommonName = value;
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000954 RID: 2388 RVA: 0x000236FD File Offset: 0x000218FD
		// (set) Token: 0x06000955 RID: 2389 RVA: 0x00023705 File Offset: 0x00021905
		public string ClientCAFilePath
		{
			get
			{
				return this.m_ClientCAFilePath;
			}
			set
			{
				this.m_ClientCAFilePath = value;
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000956 RID: 2390 RVA: 0x0002370E File Offset: 0x0002190E
		// (set) Token: 0x06000957 RID: 2391 RVA: 0x00023716 File Offset: 0x00021916
		public string ClientCAOverride
		{
			get
			{
				return this.m_ClientCAOverride;
			}
			set
			{
				this.m_ClientCAOverride = value;
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000958 RID: 2392 RVA: 0x0002371F File Offset: 0x0002191F
		// (set) Token: 0x06000959 RID: 2393 RVA: 0x00023727 File Offset: 0x00021927
		public string ServerCertificateFilePath
		{
			get
			{
				return this.m_ServerCertificateFilePath;
			}
			set
			{
				this.m_ServerCertificateFilePath = value;
			}
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x0600095A RID: 2394 RVA: 0x00023730 File Offset: 0x00021930
		// (set) Token: 0x0600095B RID: 2395 RVA: 0x00023738 File Offset: 0x00021938
		public string ServerPrivateFilePath
		{
			get
			{
				return this.m_ServerPrivateFilePath;
			}
			set
			{
				this.m_ServerPrivate = value;
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x0600095C RID: 2396 RVA: 0x00023741 File Offset: 0x00021941
		// (set) Token: 0x0600095D RID: 2397 RVA: 0x0002376C File Offset: 0x0002196C
		public string ClientCA
		{
			get
			{
				if (this.m_ClientCAOverride != "")
				{
					return this.m_ClientCAOverride;
				}
				return SecretsLoaderHelper.ReadFile(this.m_ClientCAFilePath, "Client Certificate");
			}
			set
			{
				this.m_ClientCA = value;
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x0600095E RID: 2398 RVA: 0x00023775 File Offset: 0x00021975
		// (set) Token: 0x0600095F RID: 2399 RVA: 0x00023787 File Offset: 0x00021987
		public string ServerCertificate
		{
			get
			{
				return SecretsLoaderHelper.ReadFile(this.m_ServerCertificateFilePath, "Server Certificate");
			}
			set
			{
				this.m_ServerCertificate = value;
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000960 RID: 2400 RVA: 0x00023790 File Offset: 0x00021990
		// (set) Token: 0x06000961 RID: 2401 RVA: 0x00023738 File Offset: 0x00021938
		public string ServerPrivate
		{
			get
			{
				return SecretsLoaderHelper.ReadFile(this.m_ServerPrivateFilePath, "Server Key");
			}
			set
			{
				this.m_ServerPrivate = value;
			}
		}

		// Token: 0x06000962 RID: 2402 RVA: 0x000237A4 File Offset: 0x000219A4
		private static string ReadFile(string path, string label)
		{
			if (path == null || path == "")
			{
				return "";
			}
			string text = new StreamReader(path).ReadToEnd();
			Debug.Log((text.Length > 1) ? ("Successfully loaded " + text.Length.ToString() + " byte(s) from " + label) : ("Could not read " + label + " file"));
			return text;
		}

		// Token: 0x04000391 RID: 913
		[Tooltip("Hostname")]
		[SerializeField]
		private string m_ServerCommonName = "localhost";

		// Token: 0x04000392 RID: 914
		[Tooltip("Client CA filepath. Useful with self-signed certificates")]
		[SerializeField]
		private string m_ClientCAFilePath = "";

		// Token: 0x04000393 RID: 915
		[Tooltip("Client CA Override. Only useful for development with self-signed certificates. Certificate content, for platforms that lack file access (WebGL)")]
		[SerializeField]
		private string m_ClientCAOverride = "";

		// Token: 0x04000394 RID: 916
		[Tooltip("Server Certificate filepath")]
		[SerializeField]
		private string m_ServerCertificateFilePath = "";

		// Token: 0x04000395 RID: 917
		[Tooltip("Server Private Key filepath")]
		[SerializeField]
		private string m_ServerPrivateFilePath = "";

		// Token: 0x04000396 RID: 918
		private string m_ClientCA;

		// Token: 0x04000397 RID: 919
		private string m_ServerCertificate;

		// Token: 0x04000398 RID: 920
		private string m_ServerPrivate;

		// Token: 0x02000129 RID: 297
		internal struct ServerSecrets
		{
			// Token: 0x04000399 RID: 921
			public string ServerPrivate;

			// Token: 0x0400039A RID: 922
			public string ServerCertificate;
		}

		// Token: 0x0200012A RID: 298
		internal struct ClientSecrets
		{
			// Token: 0x0400039B RID: 923
			public string ServerCommonName;

			// Token: 0x0400039C RID: 924
			public string ClientCertificate;
		}
	}
}
