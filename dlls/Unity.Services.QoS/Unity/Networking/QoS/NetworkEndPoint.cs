using System;
using System.Text;
using Unity.Baselib.LowLevel;

namespace Unity.Networking.QoS
{
	// Token: 0x02000008 RID: 8
	internal struct NetworkEndPoint
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000018 RID: 24 RVA: 0x000029D4 File Offset: 0x00000BD4
		private ushort Port
		{
			get
			{
				return (ushort)((int)this.rawNetworkAddress.port1 | (int)this.rawNetworkAddress.port0 << 8);
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000019 RID: 25 RVA: 0x000029F0 File Offset: 0x00000BF0
		private NetworkFamily Family
		{
			get
			{
				return NetworkEndPoint.FromBaselibFamily((Binding.Baselib_NetworkAddress_Family)this.rawNetworkAddress.family);
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600001A RID: 26 RVA: 0x00002A02 File Offset: 0x00000C02
		internal string Address
		{
			get
			{
				return this.AddressAsString();
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600001B RID: 27 RVA: 0x00002A0A File Offset: 0x00000C0A
		private bool IsValid
		{
			get
			{
				return this.Family > NetworkFamily.Invalid;
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002A18 File Offset: 0x00000C18
		internal unsafe static bool TryParse(string address, ushort port, out NetworkEndPoint endpoint, NetworkFamily family = NetworkFamily.Ipv4)
		{
			endpoint = default(NetworkEndPoint);
			Binding.Baselib_ErrorState baselib_ErrorState = default(Binding.Baselib_ErrorState);
			byte[] array;
			byte* ip;
			if ((array = Encoding.UTF8.GetBytes(address + "\0")) == null || array.Length == 0)
			{
				ip = null;
			}
			else
			{
				ip = &array[0];
			}
			fixed (Binding.Baselib_NetworkAddress* ptr = &endpoint.rawNetworkAddress)
			{
				Binding.Baselib_NetworkAddress_Encode(ptr, NetworkEndPoint.ToBaselibFamily(family), ip, port, &baselib_ErrorState);
			}
			array = null;
			return baselib_ErrorState.code == Binding.Baselib_ErrorCode.Success && endpoint.IsValid;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002A90 File Offset: 0x00000C90
		private string AddressAsString()
		{
			NetworkFamily family = this.Family;
			if (family == NetworkFamily.Ipv4)
			{
				return string.Format("{0}.{1}.{2}.{3}:{4}", new object[]
				{
					this.rawNetworkAddress.data0,
					this.rawNetworkAddress.data1,
					this.rawNetworkAddress.data2,
					this.rawNetworkAddress.data3,
					this.Port
				});
			}
			if (family != NetworkFamily.Ipv6)
			{
				return string.Empty;
			}
			return string.Format("[{0:x}:{1:x}:{2:x}:{3:x}:{4:x}:{5:x}:{6:x}:{7:x}]:{8}", new object[]
			{
				(int)this.rawNetworkAddress.data1 | (int)this.rawNetworkAddress.data0 << 8,
				(int)this.rawNetworkAddress.data3 | (int)this.rawNetworkAddress.data2 << 8,
				(int)this.rawNetworkAddress.data5 | (int)this.rawNetworkAddress.data4 << 8,
				(int)this.rawNetworkAddress.data7 | (int)this.rawNetworkAddress.data6 << 8,
				(int)this.rawNetworkAddress.data9 | (int)this.rawNetworkAddress.data8 << 8,
				(int)this.rawNetworkAddress.data11 | (int)this.rawNetworkAddress.data10 << 8,
				(int)this.rawNetworkAddress.data13 | (int)this.rawNetworkAddress.data12 << 8,
				(int)this.rawNetworkAddress.data15 | (int)this.rawNetworkAddress.data14 << 8,
				this.Port
			});
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002C4C File Offset: 0x00000E4C
		private static NetworkFamily FromBaselibFamily(Binding.Baselib_NetworkAddress_Family family)
		{
			NetworkFamily result;
			if (family != Binding.Baselib_NetworkAddress_Family.IPv4)
			{
				if (family != Binding.Baselib_NetworkAddress_Family.IPv6)
				{
					result = NetworkFamily.Invalid;
				}
				else
				{
					result = NetworkFamily.Ipv6;
				}
			}
			else
			{
				result = NetworkFamily.Ipv4;
			}
			return result;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002C70 File Offset: 0x00000E70
		private static Binding.Baselib_NetworkAddress_Family ToBaselibFamily(NetworkFamily family)
		{
			Binding.Baselib_NetworkAddress_Family result;
			if (family != NetworkFamily.Ipv4)
			{
				if (family != NetworkFamily.Ipv6)
				{
					result = Binding.Baselib_NetworkAddress_Family.Invalid;
				}
				else
				{
					result = Binding.Baselib_NetworkAddress_Family.IPv6;
				}
			}
			else
			{
				result = Binding.Baselib_NetworkAddress_Family.IPv4;
			}
			return result;
		}

		// Token: 0x0400001D RID: 29
		internal Binding.Baselib_NetworkAddress rawNetworkAddress;
	}
}
