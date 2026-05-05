using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using Unity.Services.Relay.Models;
using UnityEngine;

namespace Unity.Networking.Transport.Relay
{
	// Token: 0x020000A1 RID: 161
	public struct RelayServerData
	{
		// Token: 0x060002A4 RID: 676 RVA: 0x0000F398 File Offset: 0x0000D598
		private unsafe RelayServerData(byte[] allocationId, byte[] connectionData, byte[] hostConnectionData, byte[] key)
		{
			this.Nonce = 0;
			this.AllocationId = RelayAllocationId.FromByteArray(allocationId);
			this.ConnectionData = RelayConnectionData.FromByteArray(connectionData);
			this.HostConnectionData = RelayConnectionData.FromByteArray(hostConnectionData);
			this.HMACKey = RelayHMACKey.FromByteArray(key);
			this.Endpoint = default(NetworkEndPoint);
			this.IsSecure = 0;
			fixed (byte* ptr = &this.HMAC.FixedElementField)
			{
				RelayServerData.ComputeBindHMAC(ptr, this.Nonce, ref this.ConnectionData, ref this.HMACKey);
			}
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x0000F418 File Offset: 0x0000D618
		public RelayServerData(Allocation allocation, string connectionType)
		{
			this = new RelayServerData(allocation.AllocationIdBytes, allocation.ConnectionData, allocation.ConnectionData, allocation.Key);
			if (!new string[]
			{
				"udp",
				"dtls"
			}.Contains(connectionType))
			{
				throw new ArgumentException("Invalid connection type: " + connectionType + ". Must be udp or dtls.");
			}
			RelayServerEndpoint relayServerEndpoint = allocation.ServerEndpoints.First((RelayServerEndpoint ep) => ep.ConnectionType == connectionType);
			this.Endpoint = RelayServerData.HostToEndpoint(relayServerEndpoint.Host, (ushort)relayServerEndpoint.Port);
			this.IsSecure = (relayServerEndpoint.Secure ? 1 : 0);
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0000F4D0 File Offset: 0x0000D6D0
		public RelayServerData(JoinAllocation allocation, string connectionType)
		{
			this = new RelayServerData(allocation.AllocationIdBytes, allocation.ConnectionData, allocation.HostConnectionData, allocation.Key);
			if (!new string[]
			{
				"udp",
				"dtls"
			}.Contains(connectionType))
			{
				throw new ArgumentException("Invalid connection type: " + connectionType + ". Must be udp, or dtls.");
			}
			RelayServerEndpoint relayServerEndpoint = allocation.ServerEndpoints.First((RelayServerEndpoint ep) => ep.ConnectionType == connectionType);
			this.Endpoint = RelayServerData.HostToEndpoint(relayServerEndpoint.Host, (ushort)relayServerEndpoint.Port);
			this.IsSecure = (relayServerEndpoint.Secure ? 1 : 0);
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x0000F588 File Offset: 0x0000D788
		public RelayServerData(string host, ushort port, byte[] allocationId, byte[] connectionData, byte[] hostConnectionData, byte[] key, bool isSecure)
		{
			this = new RelayServerData(allocationId, connectionData, hostConnectionData, key);
			this.Endpoint = RelayServerData.HostToEndpoint(host, port);
			this.IsSecure = (isSecure ? 1 : 0);
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0000F5B4 File Offset: 0x0000D7B4
		[Obsolete("Will be removed in Unity Transport 2.0. Use the new constructor introduced in 1.3 instead.", false)]
		public unsafe RelayServerData(ref NetworkEndPoint endpoint, ushort nonce, RelayAllocationId allocationId, string connectionData, string hostConnectionData, string key, bool isSecure)
		{
			this.Endpoint = endpoint;
			this.AllocationId = allocationId;
			this.Nonce = nonce;
			this.IsSecure = (isSecure ? 1 : 0);
			fixed (byte* ptr = &this.ConnectionData.Value.FixedElementField)
			{
				byte* dest = ptr;
				fixed (byte* ptr2 = &this.HostConnectionData.Value.FixedElementField)
				{
					byte* dest2 = ptr2;
					fixed (byte* ptr3 = &this.HMACKey.Value.FixedElementField)
					{
						byte* dest3 = ptr3;
						Base64.FromBase64String(connectionData, dest, 255);
						Base64.FromBase64String(hostConnectionData, dest2, 255);
						Base64.FromBase64String(key, dest3, 64);
					}
				}
			}
			fixed (byte* ptr = &this.HMAC.FixedElementField)
			{
				RelayServerData.ComputeBindHMAC(ptr, this.Nonce, ref this.ConnectionData, ref this.HMACKey);
			}
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x0000F684 File Offset: 0x0000D884
		public unsafe RelayServerData(ref NetworkEndPoint endpoint, ushort nonce, ref RelayAllocationId allocationId, ref RelayConnectionData connectionData, ref RelayConnectionData hostConnectionData, ref RelayHMACKey key, bool isSecure)
		{
			this.Endpoint = endpoint;
			this.Nonce = nonce;
			this.AllocationId = allocationId;
			this.ConnectionData = connectionData;
			this.HostConnectionData = hostConnectionData;
			this.HMACKey = key;
			this.IsSecure = (isSecure ? 1 : 0);
			fixed (byte* ptr = &this.HMAC.FixedElementField)
			{
				RelayServerData.ComputeBindHMAC(ptr, this.Nonce, ref connectionData, ref key);
			}
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0000F708 File Offset: 0x0000D908
		[Obsolete("Will be removed in Unity Transport 2.0. There shouldn't be any need to call this method.")]
		public unsafe void ComputeNewNonce()
		{
			this.Nonce = (ushort)new Unity.Mathematics.Random((uint)Stopwatch.GetTimestamp()).NextUInt(1U, 61439U);
			fixed (byte* ptr = &this.HMAC.FixedElementField)
			{
				RelayServerData.ComputeBindHMAC(ptr, this.Nonce, ref this.ConnectionData, ref this.HMACKey);
			}
		}

		// Token: 0x060002AB RID: 683 RVA: 0x0000F760 File Offset: 0x0000D960
		private unsafe static void ComputeBindHMAC(byte* result, ushort nonce, ref RelayConnectionData connectionData, ref RelayHMACKey key)
		{
			byte[] array = new byte[64];
			fixed (byte* ptr = &key.Value.FixedElementField)
			{
				byte* ptr2 = ptr;
				fixed (byte* ptr3 = &array[0])
				{
					UnsafeUtility.MemCpy((void*)ptr3, (void*)ptr2, (long)array.Length);
				}
				byte* ptr4 = stackalloc byte[(UIntPtr)263];
				*ptr4 = 218;
				ptr4[1] = 114;
				ptr4[5] = (byte)nonce;
				ptr4[6] = (byte)(nonce >> 8);
				ptr4[7] = byte.MaxValue;
				fixed (byte* ptr3 = &connectionData.Value.FixedElementField)
				{
					byte* source = ptr3;
					UnsafeUtility.MemCpy((void*)(ptr4 + 8), (void*)source, 255L);
				}
				HMACSHA256.ComputeHash(ptr2, array.Length, ptr4, 263, result);
			}
		}

		// Token: 0x060002AC RID: 684 RVA: 0x0000F804 File Offset: 0x0000DA04
		private static NetworkEndPoint HostToEndpoint(string host, ushort port)
		{
			NetworkEndPoint result;
			if (NetworkEndPoint.TryParse(host, port, out result, NetworkFamily.Ipv4))
			{
				return result;
			}
			if (NetworkEndPoint.TryParse(host, port, out result, NetworkFamily.Ipv6))
			{
				return result;
			}
			Debug.LogError("Host " + host + " is not a valid IPv4 or IPv6 address.");
			return result;
		}

		// Token: 0x04000219 RID: 537
		public NetworkEndPoint Endpoint;

		// Token: 0x0400021A RID: 538
		public ushort Nonce;

		// Token: 0x0400021B RID: 539
		public RelayConnectionData ConnectionData;

		// Token: 0x0400021C RID: 540
		public RelayConnectionData HostConnectionData;

		// Token: 0x0400021D RID: 541
		public RelayAllocationId AllocationId;

		// Token: 0x0400021E RID: 542
		public RelayHMACKey HMACKey;

		// Token: 0x0400021F RID: 543
		[FixedBuffer(typeof(byte), 32)]
		public RelayServerData.<HMAC>e__FixedBuffer HMAC;

		// Token: 0x04000220 RID: 544
		public readonly byte IsSecure;

		// Token: 0x020000A4 RID: 164
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 32)]
		public struct <HMAC>e__FixedBuffer
		{
			// Token: 0x04000223 RID: 547
			public byte FixedElementField;
		}
	}
}
