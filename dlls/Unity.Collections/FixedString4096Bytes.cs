using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Unity.Collections
{
	// Token: 0x0200007D RID: 125
	[BurstCompatible]
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Size = 4096)]
	public struct FixedString4096Bytes : INativeList<byte>, IIndexable<byte>, IUTF8Bytes, IComparable<string>, IEquatable<string>, IComparable<FixedString32Bytes>, IEquatable<FixedString32Bytes>, IComparable<FixedString64Bytes>, IEquatable<FixedString64Bytes>, IComparable<FixedString128Bytes>, IEquatable<FixedString128Bytes>, IComparable<FixedString512Bytes>, IEquatable<FixedString512Bytes>, IComparable<FixedString4096Bytes>, IEquatable<FixedString4096Bytes>
	{
		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060003C4 RID: 964 RVA: 0x0000A36B File Offset: 0x0000856B
		public static int UTF8MaxLengthInBytes
		{
			get
			{
				return 4093;
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060003C5 RID: 965 RVA: 0x0000A372 File Offset: 0x00008572
		[CreateProperty]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[NotBurstCompatible]
		public string Value
		{
			get
			{
				return this.ToString();
			}
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x0000A380 File Offset: 0x00008580
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe byte* GetUnsafePtr()
		{
			return (byte*)UnsafeUtility.AddressOf<FixedBytes4094>(ref this.bytes);
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060003C7 RID: 967 RVA: 0x0000A38D File Offset: 0x0000858D
		// (set) Token: 0x060003C8 RID: 968 RVA: 0x0000A395 File Offset: 0x00008595
		public unsafe int Length
		{
			get
			{
				return (int)this.utf8LengthInBytes;
			}
			set
			{
				this.utf8LengthInBytes = (ushort)value;
				this.GetUnsafePtr()[this.utf8LengthInBytes] = 0;
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060003C9 RID: 969 RVA: 0x0000A36B File Offset: 0x0000856B
		// (set) Token: 0x060003CA RID: 970 RVA: 0x000024A3 File Offset: 0x000006A3
		public int Capacity
		{
			get
			{
				return 4093;
			}
			set
			{
			}
		}

		// Token: 0x060003CB RID: 971 RVA: 0x0000A3B0 File Offset: 0x000085B0
		public unsafe bool TryResize(int newLength, NativeArrayOptions clearOptions = NativeArrayOptions.ClearMemory)
		{
			if (newLength < 0 || newLength > 4093)
			{
				return false;
			}
			if (newLength == (int)this.utf8LengthInBytes)
			{
				return true;
			}
			if (clearOptions == NativeArrayOptions.ClearMemory)
			{
				if (newLength > (int)this.utf8LengthInBytes)
				{
					UnsafeUtility.MemClear((void*)(this.GetUnsafePtr() + this.utf8LengthInBytes), (long)(newLength - (int)this.utf8LengthInBytes));
				}
				else
				{
					UnsafeUtility.MemClear((void*)(this.GetUnsafePtr() + newLength), (long)((int)this.utf8LengthInBytes - newLength));
				}
			}
			this.utf8LengthInBytes = (ushort)newLength;
			this.GetUnsafePtr()[this.utf8LengthInBytes] = 0;
			return true;
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060003CC RID: 972 RVA: 0x0000A42E File Offset: 0x0000862E
		public bool IsEmpty
		{
			get
			{
				return this.utf8LengthInBytes == 0;
			}
		}

		// Token: 0x1700008E RID: 142
		public unsafe byte this[int index]
		{
			get
			{
				return this.GetUnsafePtr()[index];
			}
			set
			{
				this.GetUnsafePtr()[index] = value;
			}
		}

		// Token: 0x060003CF RID: 975 RVA: 0x0000A450 File Offset: 0x00008650
		public unsafe ref byte ElementAt(int index)
		{
			return ref this.GetUnsafePtr()[index];
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x0000A45A File Offset: 0x0000865A
		public void Clear()
		{
			this.Length = 0;
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x0000A464 File Offset: 0x00008664
		public void Add(in byte value)
		{
			int length = this.Length;
			this.Length = length + 1;
			this[length] = value;
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x0000A48A File Offset: 0x0000868A
		public FixedString4096Bytes.Enumerator GetEnumerator()
		{
			return new FixedString4096Bytes.Enumerator(this);
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x0000A497 File Offset: 0x00008697
		[NotBurstCompatible]
		public int CompareTo(string other)
		{
			return this.ToString().CompareTo(other);
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x0000A4AC File Offset: 0x000086AC
		[NotBurstCompatible]
		public unsafe bool Equals(string other)
		{
			int num = (int)this.utf8LengthInBytes;
			int length = other.Length;
			byte* utf8Buffer = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes4094>(this.bytes);
			char* ptr = other;
			if (ptr != null)
			{
				ptr += RuntimeHelpers.OffsetToStringData / 2;
			}
			return UTF8ArrayUnsafeUtility.StrCmp(utf8Buffer, num, ptr, length) == 0;
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x0000A4F1 File Offset: 0x000086F1
		public ref FixedList4096Bytes<byte> AsFixedList()
		{
			return UnsafeUtility.AsRef<FixedList4096Bytes<byte>>(UnsafeUtility.AddressOf<FixedString4096Bytes>(ref this));
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x0000A4FE File Offset: 0x000086FE
		[NotBurstCompatible]
		public FixedString4096Bytes(string source)
		{
			this = default(FixedString4096Bytes);
			this.Initialize(source);
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x0000A510 File Offset: 0x00008710
		[NotBurstCompatible]
		internal unsafe int Initialize(string source)
		{
			this.bytes = default(FixedBytes4094);
			this.utf8LengthInBytes = 0;
			fixed (string text = source)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				CopyError copyError = UTF8ArrayUnsafeUtility.Copy(this.GetUnsafePtr(), out this.utf8LengthInBytes, 4093, ptr, source.Length);
				if (copyError != CopyError.None)
				{
					return (int)copyError;
				}
				this.Length = (int)this.utf8LengthInBytes;
			}
			return 0;
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x0000A572 File Offset: 0x00008772
		public FixedString4096Bytes(Unicode.Rune rune, int count = 1)
		{
			this = default(FixedString4096Bytes);
			this.Initialize(rune, count);
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x0000A584 File Offset: 0x00008784
		internal int Initialize(Unicode.Rune rune, int count = 1)
		{
			this = default(FixedString4096Bytes);
			return (int)ref this.Append(rune, count);
		}

		// Token: 0x060003DA RID: 986 RVA: 0x0000A595 File Offset: 0x00008795
		public int CompareTo(FixedString32Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x060003DB RID: 987 RVA: 0x0000A59F File Offset: 0x0000879F
		public FixedString4096Bytes(in FixedString32Bytes other)
		{
			this = default(FixedString4096Bytes);
			this.Initialize(other);
		}

		// Token: 0x060003DC RID: 988 RVA: 0x0000A5B0 File Offset: 0x000087B0
		internal unsafe int Initialize(in FixedString32Bytes other)
		{
			this.bytes = default(FixedBytes4094);
			this.utf8LengthInBytes = 0;
			int length = 0;
			byte* unsafePtr = this.GetUnsafePtr();
			byte* src = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes30>(other.bytes);
			ushort srcLength = other.utf8LengthInBytes;
			FormatError formatError = UTF8ArrayUnsafeUtility.AppendUTF8Bytes(unsafePtr, ref length, 4093, src, (int)srcLength);
			if (formatError != FormatError.None)
			{
				return (int)formatError;
			}
			this.Length = length;
			return 0;
		}

		// Token: 0x060003DD RID: 989 RVA: 0x0000A608 File Offset: 0x00008808
		public unsafe static bool operator ==(in FixedString4096Bytes a, in FixedString32Bytes b)
		{
			int aLength = (int)a.utf8LengthInBytes;
			int bLength = (int)b.utf8LengthInBytes;
			byte* aBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes4094>(a.bytes);
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes30>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(aBytes, aLength, bBytes, bLength);
		}

		// Token: 0x060003DE RID: 990 RVA: 0x0000A644 File Offset: 0x00008844
		public static bool operator !=(in FixedString4096Bytes a, in FixedString32Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x060003DF RID: 991 RVA: 0x0000A650 File Offset: 0x00008850
		public bool Equals(FixedString32Bytes other)
		{
			return this == other;
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x0000A65A File Offset: 0x0000885A
		public int CompareTo(FixedString64Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x0000A664 File Offset: 0x00008864
		public FixedString4096Bytes(in FixedString64Bytes other)
		{
			this = default(FixedString4096Bytes);
			this.Initialize(other);
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x0000A678 File Offset: 0x00008878
		internal unsafe int Initialize(in FixedString64Bytes other)
		{
			this.bytes = default(FixedBytes4094);
			this.utf8LengthInBytes = 0;
			int length = 0;
			byte* unsafePtr = this.GetUnsafePtr();
			byte* src = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes62>(other.bytes);
			ushort srcLength = other.utf8LengthInBytes;
			FormatError formatError = UTF8ArrayUnsafeUtility.AppendUTF8Bytes(unsafePtr, ref length, 4093, src, (int)srcLength);
			if (formatError != FormatError.None)
			{
				return (int)formatError;
			}
			this.Length = length;
			return 0;
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x0000A6D0 File Offset: 0x000088D0
		public unsafe static bool operator ==(in FixedString4096Bytes a, in FixedString64Bytes b)
		{
			int aLength = (int)a.utf8LengthInBytes;
			int bLength = (int)b.utf8LengthInBytes;
			byte* aBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes4094>(a.bytes);
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes62>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(aBytes, aLength, bBytes, bLength);
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x0000A70C File Offset: 0x0000890C
		public static bool operator !=(in FixedString4096Bytes a, in FixedString64Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x0000A718 File Offset: 0x00008918
		public bool Equals(FixedString64Bytes other)
		{
			return this == other;
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x0000A722 File Offset: 0x00008922
		public int CompareTo(FixedString128Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x0000A72C File Offset: 0x0000892C
		public FixedString4096Bytes(in FixedString128Bytes other)
		{
			this = default(FixedString4096Bytes);
			this.Initialize(other);
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x0000A740 File Offset: 0x00008940
		internal unsafe int Initialize(in FixedString128Bytes other)
		{
			this.bytes = default(FixedBytes4094);
			this.utf8LengthInBytes = 0;
			int length = 0;
			byte* unsafePtr = this.GetUnsafePtr();
			byte* src = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes126>(other.bytes);
			ushort srcLength = other.utf8LengthInBytes;
			FormatError formatError = UTF8ArrayUnsafeUtility.AppendUTF8Bytes(unsafePtr, ref length, 4093, src, (int)srcLength);
			if (formatError != FormatError.None)
			{
				return (int)formatError;
			}
			this.Length = length;
			return 0;
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x0000A798 File Offset: 0x00008998
		public unsafe static bool operator ==(in FixedString4096Bytes a, in FixedString128Bytes b)
		{
			int aLength = (int)a.utf8LengthInBytes;
			int bLength = (int)b.utf8LengthInBytes;
			byte* aBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes4094>(a.bytes);
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes126>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(aBytes, aLength, bBytes, bLength);
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x0000A7D4 File Offset: 0x000089D4
		public static bool operator !=(in FixedString4096Bytes a, in FixedString128Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x0000A7E0 File Offset: 0x000089E0
		public bool Equals(FixedString128Bytes other)
		{
			return this == other;
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x0000A7EA File Offset: 0x000089EA
		public int CompareTo(FixedString512Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x0000A7F4 File Offset: 0x000089F4
		public FixedString4096Bytes(in FixedString512Bytes other)
		{
			this = default(FixedString4096Bytes);
			this.Initialize(other);
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x0000A808 File Offset: 0x00008A08
		internal unsafe int Initialize(in FixedString512Bytes other)
		{
			this.bytes = default(FixedBytes4094);
			this.utf8LengthInBytes = 0;
			int length = 0;
			byte* unsafePtr = this.GetUnsafePtr();
			byte* src = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes510>(other.bytes);
			ushort srcLength = other.utf8LengthInBytes;
			FormatError formatError = UTF8ArrayUnsafeUtility.AppendUTF8Bytes(unsafePtr, ref length, 4093, src, (int)srcLength);
			if (formatError != FormatError.None)
			{
				return (int)formatError;
			}
			this.Length = length;
			return 0;
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x0000A860 File Offset: 0x00008A60
		public unsafe static bool operator ==(in FixedString4096Bytes a, in FixedString512Bytes b)
		{
			int aLength = (int)a.utf8LengthInBytes;
			int bLength = (int)b.utf8LengthInBytes;
			byte* aBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes4094>(a.bytes);
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes510>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(aBytes, aLength, bBytes, bLength);
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x0000A89C File Offset: 0x00008A9C
		public static bool operator !=(in FixedString4096Bytes a, in FixedString512Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x0000A8A8 File Offset: 0x00008AA8
		public bool Equals(FixedString512Bytes other)
		{
			return this == other;
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x0000A8B2 File Offset: 0x00008AB2
		public int CompareTo(FixedString4096Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x0000A8BC File Offset: 0x00008ABC
		public FixedString4096Bytes(in FixedString4096Bytes other)
		{
			this = default(FixedString4096Bytes);
			this.Initialize(other);
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x0000A8D0 File Offset: 0x00008AD0
		internal unsafe int Initialize(in FixedString4096Bytes other)
		{
			this.bytes = default(FixedBytes4094);
			this.utf8LengthInBytes = 0;
			int length = 0;
			byte* unsafePtr = this.GetUnsafePtr();
			byte* src = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes4094>(other.bytes);
			ushort srcLength = other.utf8LengthInBytes;
			FormatError formatError = UTF8ArrayUnsafeUtility.AppendUTF8Bytes(unsafePtr, ref length, 4093, src, (int)srcLength);
			if (formatError != FormatError.None)
			{
				return (int)formatError;
			}
			this.Length = length;
			return 0;
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x0000A928 File Offset: 0x00008B28
		public unsafe static bool operator ==(in FixedString4096Bytes a, in FixedString4096Bytes b)
		{
			int aLength = (int)a.utf8LengthInBytes;
			int bLength = (int)b.utf8LengthInBytes;
			byte* aBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes4094>(a.bytes);
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes4094>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(aBytes, aLength, bBytes, bLength);
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x0000A964 File Offset: 0x00008B64
		public static bool operator !=(in FixedString4096Bytes a, in FixedString4096Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x0000A970 File Offset: 0x00008B70
		public bool Equals(FixedString4096Bytes other)
		{
			return this == other;
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x0000A97A File Offset: 0x00008B7A
		[NotBurstCompatible]
		public static implicit operator FixedString4096Bytes(string b)
		{
			return new FixedString4096Bytes(b);
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x0000A982 File Offset: 0x00008B82
		[NotBurstCompatible]
		public override string ToString()
		{
			return ref this.ConvertToString<FixedString4096Bytes>();
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x0000A98A File Offset: 0x00008B8A
		public override int GetHashCode()
		{
			return ref this.ComputeHashCode<FixedString4096Bytes>();
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x0000A994 File Offset: 0x00008B94
		[NotBurstCompatible]
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			string text = obj as string;
			if (text != null)
			{
				return this.Equals(text);
			}
			if (obj is FixedString32Bytes)
			{
				FixedString32Bytes other = (FixedString32Bytes)obj;
				return this.Equals(other);
			}
			if (obj is FixedString64Bytes)
			{
				FixedString64Bytes other2 = (FixedString64Bytes)obj;
				return this.Equals(other2);
			}
			if (obj is FixedString128Bytes)
			{
				FixedString128Bytes other3 = (FixedString128Bytes)obj;
				return this.Equals(other3);
			}
			if (obj is FixedString512Bytes)
			{
				FixedString512Bytes other4 = (FixedString512Bytes)obj;
				return this.Equals(other4);
			}
			if (obj is FixedString4096Bytes)
			{
				FixedString4096Bytes other5 = (FixedString4096Bytes)obj;
				return this.Equals(other5);
			}
			return false;
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x0000AA30 File Offset: 0x00008C30
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckIndexInRange(int index)
		{
			if (index < 0)
			{
				throw new IndexOutOfRangeException(string.Format("Index {0} must be positive.", index));
			}
			if (index >= (int)this.utf8LengthInBytes)
			{
				throw new IndexOutOfRangeException(string.Format("Index {0} is out of range in FixedString4096Bytes of '{1}' Length.", index, this.utf8LengthInBytes));
			}
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x0000AA84 File Offset: 0x00008C84
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckLengthInRange(int length)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException(string.Format("Length {0} must be positive.", length));
			}
			if (length > 4093)
			{
				throw new ArgumentOutOfRangeException(string.Format("Length {0} is out of range in FixedString4096Bytes of '{1}' Capacity.", length, 4093));
			}
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x0000AAD3 File Offset: 0x00008CD3
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckCapacityInRange(int capacity)
		{
			if (capacity > 4093)
			{
				throw new ArgumentOutOfRangeException(string.Format("Capacity {0} must be lower than {1}.", capacity, 4093));
			}
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x0000AAFD File Offset: 0x00008CFD
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckCopyError(CopyError error, string source)
		{
			if (error != CopyError.None)
			{
				throw new ArgumentException(string.Format("FixedString4096Bytes: {0} while copying \"{1}\"", error, source));
			}
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x00008A73 File Offset: 0x00006C73
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckFormatError(FormatError error)
		{
			if (error != FormatError.None)
			{
				throw new ArgumentException("Source is too long to fit into fixed string of this size");
			}
		}

		// Token: 0x0400025A RID: 602
		internal const ushort utf8MaxLengthInBytes = 4093;

		// Token: 0x0400025B RID: 603
		[SerializeField]
		internal ushort utf8LengthInBytes;

		// Token: 0x0400025C RID: 604
		[SerializeField]
		internal FixedBytes4094 bytes;

		// Token: 0x0200007E RID: 126
		public struct Enumerator : IEnumerator
		{
			// Token: 0x06000401 RID: 1025 RVA: 0x0000AB19 File Offset: 0x00008D19
			public Enumerator(FixedString4096Bytes other)
			{
				this.target = other;
				this.offset = 0;
				this.current = default(Unicode.Rune);
			}

			// Token: 0x06000402 RID: 1026 RVA: 0x000024A3 File Offset: 0x000006A3
			public void Dispose()
			{
			}

			// Token: 0x06000403 RID: 1027 RVA: 0x0000AB35 File Offset: 0x00008D35
			public bool MoveNext()
			{
				if (this.offset >= this.target.Length)
				{
					return false;
				}
				Unicode.Utf8ToUcs(out this.current, this.target.GetUnsafePtr(), ref this.offset, this.target.Length);
				return true;
			}

			// Token: 0x06000404 RID: 1028 RVA: 0x0000AB75 File Offset: 0x00008D75
			public void Reset()
			{
				this.offset = 0;
				this.current = default(Unicode.Rune);
			}

			// Token: 0x1700008F RID: 143
			// (get) Token: 0x06000405 RID: 1029 RVA: 0x0000AB8A File Offset: 0x00008D8A
			public Unicode.Rune Current
			{
				get
				{
					return this.current;
				}
			}

			// Token: 0x17000090 RID: 144
			// (get) Token: 0x06000406 RID: 1030 RVA: 0x0000AB92 File Offset: 0x00008D92
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x0400025D RID: 605
			private FixedString4096Bytes target;

			// Token: 0x0400025E RID: 606
			private int offset;

			// Token: 0x0400025F RID: 607
			private Unicode.Rune current;
		}
	}
}
