using System;
using System.Text;
using Unity.Baselib.LowLevel;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Networking.Transport.Utilities;
using UnityEngine;

namespace Unity.Networking.Transport
{
	// Token: 0x02000038 RID: 56
	public struct NetworkEndPoint
	{
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000141 RID: 321 RVA: 0x00007880 File Offset: 0x00005A80
		public int Length
		{
			get
			{
				NetworkFamily family = this.Family;
				if (family != NetworkFamily.Invalid)
				{
					if (family == NetworkFamily.Ipv4)
					{
						return 4;
					}
					if (family == NetworkFamily.Ipv6)
					{
						return 16;
					}
				}
				return 0;
			}
		}

		// Token: 0x06000142 RID: 322 RVA: 0x000078A8 File Offset: 0x00005AA8
		unsafe static NetworkEndPoint()
		{
			uint num = 1U;
			byte* ptr = (byte*)(&num);
			NetworkEndPoint.IsLittleEndian = (*ptr == 1);
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000143 RID: 323 RVA: 0x000078CB File Offset: 0x00005ACB
		// (set) Token: 0x06000144 RID: 324 RVA: 0x000078E7 File Offset: 0x00005AE7
		public ushort Port
		{
			get
			{
				return (ushort)((int)this.rawNetworkAddress.port1 | (int)this.rawNetworkAddress.port0 << 8);
			}
			set
			{
				this.rawNetworkAddress.port0 = (byte)(value >> 8 & 255);
				this.rawNetworkAddress.port1 = (byte)(value & 255);
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000145 RID: 325 RVA: 0x00007911 File Offset: 0x00005B11
		// (set) Token: 0x06000146 RID: 326 RVA: 0x00007923 File Offset: 0x00005B23
		public NetworkFamily Family
		{
			get
			{
				return NetworkEndPoint.FromBaselibFamily((Binding.Baselib_NetworkAddress_Family)this.rawNetworkAddress.family);
			}
			set
			{
				this.rawNetworkAddress.family = (byte)NetworkEndPoint.ToBaselibFamily(value);
			}
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00007937 File Offset: 0x00005B37
		public NativeArray<byte> GetRawAddressBytes()
		{
			NativeArray<byte> nativeArray = new NativeArray<byte>(this.Length, Allocator.Temp, NativeArrayOptions.ClearMemory);
			UnsafeUtility.MemCpy(nativeArray.GetUnsafePtr<byte>(), UnsafeUtility.AddressOf<Binding.Baselib_NetworkAddress>(ref this.rawNetworkAddress), (long)this.Length);
			return nativeArray;
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00007964 File Offset: 0x00005B64
		public void SetRawAddressBytes(NativeArray<byte> bytes, NetworkFamily family = NetworkFamily.Ipv4)
		{
			if ((family == NetworkFamily.Ipv4 && bytes.Length != 4) || (family == NetworkFamily.Ipv6 && bytes.Length != 16))
			{
				Debug.LogError("Bad input length for given address family.");
				return;
			}
			if (family == NetworkFamily.Ipv4)
			{
				UnsafeUtility.MemCpy(UnsafeUtility.AddressOf<Binding.Baselib_NetworkAddress>(ref this.rawNetworkAddress), bytes.GetUnsafeReadOnlyPtr<byte>(), 4L);
				this.Family = family;
				return;
			}
			if (family == NetworkFamily.Ipv6)
			{
				UnsafeUtility.MemCpy(UnsafeUtility.AddressOf<Binding.Baselib_NetworkAddress>(ref this.rawNetworkAddress), bytes.GetUnsafeReadOnlyPtr<byte>(), 16L);
				this.Family = family;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000149 RID: 329 RVA: 0x000079E4 File Offset: 0x00005BE4
		// (set) Token: 0x0600014A RID: 330 RVA: 0x00007A04 File Offset: 0x00005C04
		public unsafe ushort RawPort
		{
			get
			{
				ushort* ptr = (ushort*)((byte*)UnsafeUtility.AddressOf<Binding.Baselib_NetworkAddress>(ref this.rawNetworkAddress) + 16);
				return *ptr;
			}
			set
			{
				ushort* ptr = (ushort*)((byte*)UnsafeUtility.AddressOf<Binding.Baselib_NetworkAddress>(ref this.rawNetworkAddress) + 16);
				*ptr = value;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600014B RID: 331 RVA: 0x00007A23 File Offset: 0x00005C23
		public string Address
		{
			get
			{
				return this.AddressAsString();
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600014C RID: 332 RVA: 0x00007A2B File Offset: 0x00005C2B
		public bool IsValid
		{
			get
			{
				return this.Family > NetworkFamily.Invalid;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600014D RID: 333 RVA: 0x00007A36 File Offset: 0x00005C36
		public static NetworkEndPoint AnyIpv4
		{
			get
			{
				return NetworkEndPoint.CreateAddress(0, NetworkEndPoint.AddressType.Any, NetworkFamily.Ipv4);
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600014E RID: 334 RVA: 0x00007A40 File Offset: 0x00005C40
		public static NetworkEndPoint LoopbackIpv4
		{
			get
			{
				return NetworkEndPoint.CreateAddress(0, NetworkEndPoint.AddressType.Loopback, NetworkFamily.Ipv4);
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600014F RID: 335 RVA: 0x00007A4A File Offset: 0x00005C4A
		public static NetworkEndPoint AnyIpv6
		{
			get
			{
				return NetworkEndPoint.CreateAddress(0, NetworkEndPoint.AddressType.Any, NetworkFamily.Ipv6);
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000150 RID: 336 RVA: 0x00007A55 File Offset: 0x00005C55
		public static NetworkEndPoint LoopbackIpv6
		{
			get
			{
				return NetworkEndPoint.CreateAddress(0, NetworkEndPoint.AddressType.Loopback, NetworkFamily.Ipv6);
			}
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00007A60 File Offset: 0x00005C60
		public NetworkEndPoint WithPort(ushort port)
		{
			NetworkEndPoint result = this;
			result.Port = port;
			return result;
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000152 RID: 338 RVA: 0x00007A80 File Offset: 0x00005C80
		public bool IsLoopback
		{
			get
			{
				return this == NetworkEndPoint.LoopbackIpv4.WithPort(this.Port) || this == NetworkEndPoint.LoopbackIpv6.WithPort(this.Port);
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000153 RID: 339 RVA: 0x00007AD0 File Offset: 0x00005CD0
		public bool IsAny
		{
			get
			{
				return this == NetworkEndPoint.AnyIpv4.WithPort(this.Port) || this == NetworkEndPoint.AnyIpv6.WithPort(this.Port);
			}
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00007B20 File Offset: 0x00005D20
		public unsafe static bool TryParse(string address, ushort port, out NetworkEndPoint endpoint, NetworkFamily family = NetworkFamily.Ipv4)
		{
			UnsafeUtility.SizeOf<Binding.Baselib_NetworkAddress>();
			endpoint = default(NetworkEndPoint);
			char c = '\0';
			Binding.Baselib_ErrorState baselib_ErrorState = default(Binding.Baselib_ErrorState);
			byte[] array;
			byte* ip;
			if ((array = Encoding.UTF8.GetBytes(address + c.ToString())) == null || array.Length == 0)
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

		// Token: 0x06000155 RID: 341 RVA: 0x00007BA4 File Offset: 0x00005DA4
		public static NetworkEndPoint Parse(string address, ushort port, NetworkFamily family = NetworkFamily.Ipv4)
		{
			NetworkEndPoint result;
			if (NetworkEndPoint.TryParse(address, port, out result, family))
			{
				return result;
			}
			return default(NetworkEndPoint);
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00007BC8 File Offset: 0x00005DC8
		public static bool operator ==(NetworkEndPoint lhs, NetworkEndPoint rhs)
		{
			return lhs.Compare(rhs);
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00007BD2 File Offset: 0x00005DD2
		public static bool operator !=(NetworkEndPoint lhs, NetworkEndPoint rhs)
		{
			return !lhs.Compare(rhs);
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00007BDF File Offset: 0x00005DDF
		public override bool Equals(object other)
		{
			return this == (NetworkEndPoint)other;
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00007BF4 File Offset: 0x00005DF4
		public unsafe override int GetHashCode()
		{
			byte* ptr = (byte*)UnsafeUtility.AddressOf<Binding.Baselib_NetworkAddress>(ref this.rawNetworkAddress);
			int num = 0;
			for (int i = 0; i < 24; i++)
			{
				num = (num * 31 ^ (int)ptr[i]);
			}
			return num;
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00007C28 File Offset: 0x00005E28
		private unsafe bool Compare(NetworkEndPoint other)
		{
			byte* ptr = (byte*)UnsafeUtility.AddressOf<Binding.Baselib_NetworkAddress>(ref this.rawNetworkAddress);
			byte* ptr2 = (byte*)UnsafeUtility.AddressOf<Binding.Baselib_NetworkAddress>(ref other.rawNetworkAddress);
			return UnsafeUtility.MemCmp((void*)ptr, (void*)ptr2, 24L) == 0;
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00007C5C File Offset: 0x00005E5C
		internal static FixedString128Bytes AddressToString(ref Binding.Baselib_NetworkAddress rawNetworkAddress)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = ".";
			FixedString32Bytes fixedString32Bytes2 = ":";
			FixedString32Bytes fixedString32Bytes3 = "[";
			FixedString32Bytes fixedString32Bytes4 = "]";
			Binding.Baselib_NetworkAddress_Family family = (Binding.Baselib_NetworkAddress_Family)rawNetworkAddress.family;
			if (family != Binding.Baselib_NetworkAddress_Family.IPv4)
			{
				if (family == Binding.Baselib_NetworkAddress_Family.IPv6)
				{
					ref result.Append(fixedString32Bytes3);
					ref result.AppendHex((ushort)((int)rawNetworkAddress.data1 | (int)rawNetworkAddress.data0 << 8));
					ref result.Append(fixedString32Bytes2);
					ref result.AppendHex((ushort)((int)rawNetworkAddress.data3 | (int)rawNetworkAddress.data2 << 8));
					ref result.Append(fixedString32Bytes2);
					ref result.AppendHex((ushort)((int)rawNetworkAddress.data5 | (int)rawNetworkAddress.data4 << 8));
					ref result.Append(fixedString32Bytes2);
					ref result.AppendHex((ushort)((int)rawNetworkAddress.data7 | (int)rawNetworkAddress.data6 << 8));
					ref result.Append(fixedString32Bytes2);
					ref result.AppendHex((ushort)((int)rawNetworkAddress.data9 | (int)rawNetworkAddress.data8 << 8));
					ref result.Append(fixedString32Bytes2);
					ref result.AppendHex((ushort)((int)rawNetworkAddress.data11 | (int)rawNetworkAddress.data10 << 8));
					ref result.Append(fixedString32Bytes2);
					ref result.AppendHex((ushort)((int)rawNetworkAddress.data13 | (int)rawNetworkAddress.data12 << 8));
					ref result.Append(fixedString32Bytes2);
					ref result.AppendHex((ushort)((int)rawNetworkAddress.data15 | (int)rawNetworkAddress.data14 << 8));
					ref result.Append(fixedString32Bytes2);
					ref result.Append(fixedString32Bytes4);
					ref result.Append(fixedString32Bytes2);
					ref result.Append((int)((ushort)((int)rawNetworkAddress.port1 | (int)rawNetworkAddress.port0 << 8)));
				}
			}
			else
			{
				ref result.Append((int)rawNetworkAddress.data0);
				ref result.Append(fixedString32Bytes);
				ref result.Append((int)rawNetworkAddress.data1);
				ref result.Append(fixedString32Bytes);
				ref result.Append((int)rawNetworkAddress.data2);
				ref result.Append(fixedString32Bytes);
				ref result.Append((int)rawNetworkAddress.data3);
				ref result.Append(fixedString32Bytes2);
				ref result.Append((int)((ushort)((int)rawNetworkAddress.port1 | (int)rawNetworkAddress.port0 << 8)));
			}
			return result;
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00007E7C File Offset: 0x0000607C
		private string AddressAsString()
		{
			return NetworkEndPoint.AddressToString(ref this.rawNetworkAddress).ToString();
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00007EA4 File Offset: 0x000060A4
		public override string ToString()
		{
			return NetworkEndPoint.AddressToString(ref this.rawNetworkAddress).ToString();
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00007ECA File Offset: 0x000060CA
		private static ushort ByteSwap(ushort val)
		{
			return (ushort)((int)(val & 255) << 8 | val >> 8);
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00007EDA File Offset: 0x000060DA
		private static uint ByteSwap(uint val)
		{
			return (val & 255U) << 24 | (val & 65280U) << 8 | (val >> 8 & 65280U) | val >> 24;
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00007F00 File Offset: 0x00006100
		private unsafe static NetworkEndPoint CreateAddress(ushort port, NetworkEndPoint.AddressType type = NetworkEndPoint.AddressType.Any, NetworkFamily family = NetworkFamily.Ipv4)
		{
			if (family == NetworkFamily.Invalid)
			{
				return default(NetworkEndPoint);
			}
			uint num = 2130706433U;
			if (NetworkEndPoint.IsLittleEndian)
			{
				port = NetworkEndPoint.ByteSwap(port);
				num = NetworkEndPoint.ByteSwap(num);
			}
			NetworkEndPoint result = new NetworkEndPoint
			{
				Family = family,
				RawPort = port
			};
			if (type == NetworkEndPoint.AddressType.Loopback)
			{
				if (family == NetworkFamily.Ipv4)
				{
					*(int*)UnsafeUtility.AddressOf<Binding.Baselib_NetworkAddress>(ref result.rawNetworkAddress) = (int)num;
				}
				else if (family == NetworkFamily.Ipv6)
				{
					result.rawNetworkAddress.data15 = 1;
				}
			}
			return result;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00007F7B File Offset: 0x0000617B
		private static NetworkFamily FromBaselibFamily(Binding.Baselib_NetworkAddress_Family family)
		{
			if (family == Binding.Baselib_NetworkAddress_Family.IPv4)
			{
				return NetworkFamily.Ipv4;
			}
			if (family == Binding.Baselib_NetworkAddress_Family.IPv6)
			{
				return NetworkFamily.Ipv6;
			}
			return NetworkFamily.Invalid;
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00007F8B File Offset: 0x0000618B
		private static Binding.Baselib_NetworkAddress_Family ToBaselibFamily(NetworkFamily family)
		{
			if (family == NetworkFamily.Ipv4)
			{
				return Binding.Baselib_NetworkAddress_Family.IPv4;
			}
			if (family == NetworkFamily.Ipv6)
			{
				return Binding.Baselib_NetworkAddress_Family.IPv6;
			}
			return Binding.Baselib_NetworkAddress_Family.Invalid;
		}

		// Token: 0x040000BF RID: 191
		private const int rawIpv4Length = 4;

		// Token: 0x040000C0 RID: 192
		private const int rawIpv6Length = 16;

		// Token: 0x040000C1 RID: 193
		private const int rawDataLength = 16;

		// Token: 0x040000C2 RID: 194
		private const int rawLength = 24;

		// Token: 0x040000C3 RID: 195
		private static readonly bool IsLittleEndian = true;

		// Token: 0x040000C4 RID: 196
		internal Binding.Baselib_NetworkAddress rawNetworkAddress;

		// Token: 0x02000039 RID: 57
		private enum AddressType
		{
			// Token: 0x040000C6 RID: 198
			Any,
			// Token: 0x040000C7 RID: 199
			Loopback
		}
	}
}
