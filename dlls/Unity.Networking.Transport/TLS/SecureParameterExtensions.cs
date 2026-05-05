using System;
using Unity.Collections;

namespace Unity.Networking.Transport.TLS
{
	// Token: 0x02000088 RID: 136
	public static class SecureParameterExtensions
	{
		// Token: 0x06000261 RID: 609 RVA: 0x0000D4B8 File Offset: 0x0000B6B8
		public static ref NetworkSettings WithSecureClientParameters(this NetworkSettings settings, ref FixedString32Bytes serverName, uint readTimeout = 0U, uint handshakeTimeoutMax = 60000U, uint handshakeTimeoutMin = 1000U)
		{
			SecureNetworkProtocolParameter secureNetworkProtocolParameter = new SecureNetworkProtocolParameter
			{
				Pem = default(FixedString4096Bytes),
				Rsa = default(FixedString4096Bytes),
				RsaKey = default(FixedString4096Bytes),
				Hostname = serverName,
				Protocol = SecureTransportProtocol.DTLS,
				ClientAuthenticationPolicy = SecureClientAuthPolicy.None,
				SSLReadTimeoutMs = readTimeout,
				SSLHandshakeTimeoutMax = handshakeTimeoutMax,
				SSLHandshakeTimeoutMin = handshakeTimeoutMin
			};
			settings.AddRawParameterStruct<SecureNetworkProtocolParameter>(ref secureNetworkProtocolParameter);
			return ref settings;
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0000D538 File Offset: 0x0000B738
		public static ref NetworkSettings WithSecureClientParameters(this NetworkSettings settings, string serverName)
		{
			FixedString32Bytes fixedString32Bytes = new FixedString32Bytes(serverName);
			ref settings.WithSecureClientParameters(ref fixedString32Bytes, 0U, 60000U, 1000U);
			return ref settings;
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0000D564 File Offset: 0x0000B764
		public static ref NetworkSettings WithSecureClientParameters(this NetworkSettings settings, ref FixedString4096Bytes caCertificate, ref FixedString32Bytes serverName, uint readTimeout = 0U, uint handshakeTimeoutMax = 60000U, uint handshakeTimeoutMin = 1000U)
		{
			SecureNetworkProtocolParameter secureNetworkProtocolParameter = new SecureNetworkProtocolParameter
			{
				Pem = caCertificate,
				Rsa = default(FixedString4096Bytes),
				RsaKey = default(FixedString4096Bytes),
				Hostname = serverName,
				Protocol = SecureTransportProtocol.DTLS,
				ClientAuthenticationPolicy = SecureClientAuthPolicy.None,
				SSLReadTimeoutMs = readTimeout,
				SSLHandshakeTimeoutMax = handshakeTimeoutMax,
				SSLHandshakeTimeoutMin = handshakeTimeoutMin
			};
			settings.AddRawParameterStruct<SecureNetworkProtocolParameter>(ref secureNetworkProtocolParameter);
			return ref settings;
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0000D5E4 File Offset: 0x0000B7E4
		public static ref NetworkSettings WithSecureClientParameters(this NetworkSettings settings, string caCertificate, string serverName)
		{
			FixedString4096Bytes fixedString4096Bytes = new FixedString4096Bytes(caCertificate);
			FixedString32Bytes fixedString32Bytes = new FixedString32Bytes(serverName);
			ref settings.WithSecureClientParameters(ref fixedString4096Bytes, ref fixedString32Bytes, 0U, 60000U, 1000U);
			return ref settings;
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0000D618 File Offset: 0x0000B818
		public static ref NetworkSettings WithSecureClientParameters(this NetworkSettings settings, ref FixedString4096Bytes certificate, ref FixedString4096Bytes privateKey, ref FixedString4096Bytes caCertificate, ref FixedString32Bytes serverName, uint readTimeout = 0U, uint handshakeTimeoutMax = 60000U, uint handshakeTimeoutMin = 1000U)
		{
			SecureNetworkProtocolParameter secureNetworkProtocolParameter = new SecureNetworkProtocolParameter
			{
				Pem = caCertificate,
				Rsa = certificate,
				RsaKey = privateKey,
				Hostname = serverName,
				Protocol = SecureTransportProtocol.DTLS,
				ClientAuthenticationPolicy = SecureClientAuthPolicy.None,
				SSLReadTimeoutMs = readTimeout,
				SSLHandshakeTimeoutMax = handshakeTimeoutMax,
				SSLHandshakeTimeoutMin = handshakeTimeoutMin
			};
			settings.AddRawParameterStruct<SecureNetworkProtocolParameter>(ref secureNetworkProtocolParameter);
			return ref settings;
		}

		// Token: 0x06000266 RID: 614 RVA: 0x0000D698 File Offset: 0x0000B898
		public static ref NetworkSettings WithSecureClientParameters(this NetworkSettings settings, string certificate, string privateKey, string caCertificate, string serverName)
		{
			FixedString4096Bytes fixedString4096Bytes = new FixedString4096Bytes(certificate);
			FixedString4096Bytes fixedString4096Bytes2 = new FixedString4096Bytes(privateKey);
			FixedString4096Bytes fixedString4096Bytes3 = new FixedString4096Bytes(caCertificate);
			FixedString32Bytes fixedString32Bytes = new FixedString32Bytes(serverName);
			ref settings.WithSecureClientParameters(ref fixedString4096Bytes, ref fixedString4096Bytes2, ref fixedString4096Bytes3, ref fixedString32Bytes, 0U, 60000U, 1000U);
			return ref settings;
		}

		// Token: 0x06000267 RID: 615 RVA: 0x0000D6E4 File Offset: 0x0000B8E4
		public static ref NetworkSettings WithSecureServerParameters(this NetworkSettings settings, ref FixedString4096Bytes certificate, ref FixedString4096Bytes privateKey, uint readTimeout = 0U, uint handshakeTimeoutMax = 60000U, uint handshakeTimeoutMin = 1000U)
		{
			SecureNetworkProtocolParameter secureNetworkProtocolParameter = new SecureNetworkProtocolParameter
			{
				Pem = default(FixedString4096Bytes),
				Rsa = certificate,
				RsaKey = privateKey,
				Hostname = default(FixedString32Bytes),
				Protocol = SecureTransportProtocol.DTLS,
				ClientAuthenticationPolicy = SecureClientAuthPolicy.None,
				SSLReadTimeoutMs = readTimeout,
				SSLHandshakeTimeoutMax = handshakeTimeoutMax,
				SSLHandshakeTimeoutMin = handshakeTimeoutMin
			};
			settings.AddRawParameterStruct<SecureNetworkProtocolParameter>(ref secureNetworkProtocolParameter);
			return ref settings;
		}

		// Token: 0x06000268 RID: 616 RVA: 0x0000D764 File Offset: 0x0000B964
		public static ref NetworkSettings WithSecureServerParameters(this NetworkSettings settings, string certificate, string privateKey)
		{
			FixedString4096Bytes fixedString4096Bytes = new FixedString4096Bytes(certificate);
			FixedString4096Bytes fixedString4096Bytes2 = new FixedString4096Bytes(privateKey);
			ref settings.WithSecureServerParameters(ref fixedString4096Bytes, ref fixedString4096Bytes2, 0U, 60000U, 1000U);
			return ref settings;
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0000D798 File Offset: 0x0000B998
		public static ref NetworkSettings WithSecureServerParameters(this NetworkSettings settings, ref FixedString4096Bytes certificate, ref FixedString4096Bytes privateKey, ref FixedString4096Bytes caCertificate, ref FixedString32Bytes clientName, SecureClientAuthPolicy clientAuthenticationPolicy = SecureClientAuthPolicy.Required, uint readTimeout = 0U, uint handshakeTimeoutMax = 60000U, uint handshakeTimeoutMin = 1000U)
		{
			SecureNetworkProtocolParameter secureNetworkProtocolParameter = new SecureNetworkProtocolParameter
			{
				Pem = caCertificate,
				Rsa = certificate,
				RsaKey = privateKey,
				Hostname = clientName,
				Protocol = SecureTransportProtocol.DTLS,
				ClientAuthenticationPolicy = clientAuthenticationPolicy,
				SSLReadTimeoutMs = readTimeout,
				SSLHandshakeTimeoutMax = handshakeTimeoutMax,
				SSLHandshakeTimeoutMin = handshakeTimeoutMin
			};
			settings.AddRawParameterStruct<SecureNetworkProtocolParameter>(ref secureNetworkProtocolParameter);
			return ref settings;
		}

		// Token: 0x0600026A RID: 618 RVA: 0x0000D81C File Offset: 0x0000BA1C
		public static ref NetworkSettings WithSecureServerParameters(this NetworkSettings settings, string certificate, string privateKey, string caCertificate, string clientName, SecureClientAuthPolicy clientAuthenticationPolicy = SecureClientAuthPolicy.Required)
		{
			FixedString4096Bytes fixedString4096Bytes = new FixedString4096Bytes(certificate);
			FixedString4096Bytes fixedString4096Bytes2 = new FixedString4096Bytes(privateKey);
			FixedString4096Bytes fixedString4096Bytes3 = new FixedString4096Bytes(caCertificate);
			FixedString32Bytes fixedString32Bytes = new FixedString32Bytes(clientName);
			ref settings.WithSecureServerParameters(ref fixedString4096Bytes, ref fixedString4096Bytes2, ref fixedString4096Bytes3, ref fixedString32Bytes, clientAuthenticationPolicy, 0U, 60000U, 1000U);
			return ref settings;
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0000D868 File Offset: 0x0000BA68
		[Obsolete("Use WithSecureClientParameters or WithSecureServerParameters instead.")]
		public static ref NetworkSettings WithSecureParameters(this NetworkSettings settings, ref FixedString4096Bytes pem, ref FixedString32Bytes hostname, SecureTransportProtocol protocol = SecureTransportProtocol.DTLS, SecureClientAuthPolicy clientAuthenticationPolicy = SecureClientAuthPolicy.Optional, uint sslReadTimeoutMs = 0U, uint sslHandshakeTimeoutMax = 60000U, uint sslHandshakeTimeoutMin = 1000U)
		{
			SecureNetworkProtocolParameter secureNetworkProtocolParameter = new SecureNetworkProtocolParameter
			{
				Pem = pem,
				Rsa = default(FixedString4096Bytes),
				RsaKey = default(FixedString4096Bytes),
				Hostname = hostname,
				Protocol = protocol,
				ClientAuthenticationPolicy = clientAuthenticationPolicy,
				SSLReadTimeoutMs = sslReadTimeoutMs,
				SSLHandshakeTimeoutMax = sslHandshakeTimeoutMax,
				SSLHandshakeTimeoutMin = sslHandshakeTimeoutMin
			};
			settings.AddRawParameterStruct<SecureNetworkProtocolParameter>(ref secureNetworkProtocolParameter);
			return ref settings;
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0000D8E8 File Offset: 0x0000BAE8
		[Obsolete("Use WithSecureClientParameters or WithSecureServerParameters instead.")]
		public static ref NetworkSettings WithSecureParameters(this NetworkSettings settings, ref FixedString4096Bytes pem, ref FixedString4096Bytes rsa, ref FixedString4096Bytes rsaKey, ref FixedString32Bytes hostname, SecureTransportProtocol protocol = SecureTransportProtocol.DTLS, SecureClientAuthPolicy clientAuthenticationPolicy = SecureClientAuthPolicy.Optional, uint sslReadTimeoutMs = 0U, uint sslHandshakeTimeoutMax = 60000U, uint sslHandshakeTimeoutMin = 1000U)
		{
			SecureNetworkProtocolParameter secureNetworkProtocolParameter = new SecureNetworkProtocolParameter
			{
				Pem = pem,
				Rsa = rsa,
				RsaKey = rsaKey,
				Hostname = hostname,
				Protocol = protocol,
				ClientAuthenticationPolicy = clientAuthenticationPolicy,
				SSLReadTimeoutMs = sslReadTimeoutMs,
				SSLHandshakeTimeoutMax = sslHandshakeTimeoutMax,
				SSLHandshakeTimeoutMin = sslHandshakeTimeoutMin
			};
			settings.AddRawParameterStruct<SecureNetworkProtocolParameter>(ref secureNetworkProtocolParameter);
			return ref settings;
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000D96C File Offset: 0x0000BB6C
		public static SecureNetworkProtocolParameter GetSecureParameters(this NetworkSettings settings)
		{
			SecureNetworkProtocolParameter result;
			if (!settings.TryGet<SecureNetworkProtocolParameter>(out result))
			{
				throw new InvalidOperationException("Can't extract Secure parameters: SecureNetworkProtocolParameter must be provided to the NetworkSettings");
			}
			return result;
		}
	}
}
