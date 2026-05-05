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
	// Token: 0x02000079 RID: 121
	[BurstCompatible]
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Size = 512)]
	public struct FixedString512Bytes : INativeList<byte>, IIndexable<byte>, IUTF8Bytes, IComparable<string>, IEquatable<string>, IComparable<FixedString32Bytes>, IEquatable<FixedString32Bytes>, IComparable<FixedString64Bytes>, IEquatable<FixedString64Bytes>, IComparable<FixedString128Bytes>, IEquatable<FixedString128Bytes>, IComparable<FixedString512Bytes>, IEquatable<FixedString512Bytes>, IComparable<FixedString4096Bytes>, IEquatable<FixedString4096Bytes>
	{
		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000380 RID: 896 RVA: 0x00009B31 File Offset: 0x00007D31
		public static int UTF8MaxLengthInBytes
		{
			get
			{
				return 509;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000381 RID: 897 RVA: 0x00009B38 File Offset: 0x00007D38
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

		// Token: 0x06000382 RID: 898 RVA: 0x00009B46 File Offset: 0x00007D46
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe byte* GetUnsafePtr()
		{
			return (byte*)UnsafeUtility.AddressOf<FixedBytes510>(ref this.bytes);
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000383 RID: 899 RVA: 0x00009B53 File Offset: 0x00007D53
		// (set) Token: 0x06000384 RID: 900 RVA: 0x00009B5B File Offset: 0x00007D5B
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

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000385 RID: 901 RVA: 0x00009B31 File Offset: 0x00007D31
		// (set) Token: 0x06000386 RID: 902 RVA: 0x000024A3 File Offset: 0x000006A3
		public int Capacity
		{
			get
			{
				return 509;
			}
			set
			{
			}
		}

		// Token: 0x06000387 RID: 903 RVA: 0x00009B74 File Offset: 0x00007D74
		public unsafe bool TryResize(int newLength, NativeArrayOptions clearOptions = NativeArrayOptions.ClearMemory)
		{
			if (newLength < 0 || newLength > 509)
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

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000388 RID: 904 RVA: 0x00009BF2 File Offset: 0x00007DF2
		public bool IsEmpty
		{
			get
			{
				return this.utf8LengthInBytes == 0;
			}
		}

		// Token: 0x17000086 RID: 134
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

		// Token: 0x0600038B RID: 907 RVA: 0x00009C14 File Offset: 0x00007E14
		public unsafe ref byte ElementAt(int index)
		{
			return ref this.GetUnsafePtr()[index];
		}

		// Token: 0x0600038C RID: 908 RVA: 0x00009C1E File Offset: 0x00007E1E
		public void Clear()
		{
			this.Length = 0;
		}

		// Token: 0x0600038D RID: 909 RVA: 0x00009C28 File Offset: 0x00007E28
		public void Add(in byte value)
		{
			int length = this.Length;
			this.Length = length + 1;
			this[length] = value;
		}

		// Token: 0x0600038E RID: 910 RVA: 0x00009C4E File Offset: 0x00007E4E
		public FixedString512Bytes.Enumerator GetEnumerator()
		{
			return new FixedString512Bytes.Enumerator(this);
		}

		// Token: 0x0600038F RID: 911 RVA: 0x00009C5B File Offset: 0x00007E5B
		[NotBurstCompatible]
		public int CompareTo(string other)
		{
			return this.ToString().CompareTo(other);
		}

		// Token: 0x06000390 RID: 912 RVA: 0x00009C70 File Offset: 0x00007E70
		[NotBurstCompatible]
		public unsafe bool Equals(string other)
		{
			int num = (int)this.utf8LengthInBytes;
			int length = other.Length;
			byte* utf8Buffer = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes510>(this.bytes);
			char* ptr = other;
			if (ptr != null)
			{
				ptr += RuntimeHelpers.OffsetToStringData / 2;
			}
			return UTF8ArrayUnsafeUtility.StrCmp(utf8Buffer, num, ptr, length) == 0;
		}

		// Token: 0x06000391 RID: 913 RVA: 0x00009CB5 File Offset: 0x00007EB5
		public ref FixedList512Bytes<byte> AsFixedList()
		{
			return UnsafeUtility.AsRef<FixedList512Bytes<byte>>(UnsafeUtility.AddressOf<FixedString512Bytes>(ref this));
		}

		// Token: 0x06000392 RID: 914 RVA: 0x00009CC2 File Offset: 0x00007EC2
		[NotBurstCompatible]
		public FixedString512Bytes(string source)
		{
			this = default(FixedString512Bytes);
			this.Initialize(source);
		}

		// Token: 0x06000393 RID: 915 RVA: 0x00009CD4 File Offset: 0x00007ED4
		[NotBurstCompatible]
		internal unsafe int Initialize(string source)
		{
			this.bytes = default(FixedBytes510);
			this.utf8LengthInBytes = 0;
			fixed (string text = source)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				CopyError copyError = UTF8ArrayUnsafeUtility.Copy(this.GetUnsafePtr(), out this.utf8LengthInBytes, 509, ptr, source.Length);
				if (copyError != CopyError.None)
				{
					return (int)copyError;
				}
				this.Length = (int)this.utf8LengthInBytes;
			}
			return 0;
		}

		// Token: 0x06000394 RID: 916 RVA: 0x00009D36 File Offset: 0x00007F36
		public FixedString512Bytes(Unicode.Rune rune, int count = 1)
		{
			this = default(FixedString512Bytes);
			this.Initialize(rune, count);
		}

		// Token: 0x06000395 RID: 917 RVA: 0x00009D48 File Offset: 0x00007F48
		internal int Initialize(Unicode.Rune rune, int count = 1)
		{
			this = default(FixedString512Bytes);
			return (int)ref this.Append(rune, count);
		}

		// Token: 0x06000396 RID: 918 RVA: 0x00009D59 File Offset: 0x00007F59
		public int CompareTo(FixedString32Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x06000397 RID: 919 RVA: 0x00009D63 File Offset: 0x00007F63
		public FixedString512Bytes(in FixedString32Bytes other)
		{
			this = default(FixedString512Bytes);
			this.Initialize(other);
		}

		// Token: 0x06000398 RID: 920 RVA: 0x00009D74 File Offset: 0x00007F74
		internal unsafe int Initialize(in FixedString32Bytes other)
		{
			this.bytes = default(FixedBytes510);
			this.utf8LengthInBytes = 0;
			int length = 0;
			byte* unsafePtr = this.GetUnsafePtr();
			byte* src = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes30>(other.bytes);
			ushort srcLength = other.utf8LengthInBytes;
			FormatError formatError = UTF8ArrayUnsafeUtility.AppendUTF8Bytes(unsafePtr, ref length, 509, src, (int)srcLength);
			if (formatError != FormatError.None)
			{
				return (int)formatError;
			}
			this.Length = length;
			return 0;
		}

		// Token: 0x06000399 RID: 921 RVA: 0x00009DCC File Offset: 0x00007FCC
		public unsafe static bool operator ==(in FixedString512Bytes a, in FixedString32Bytes b)
		{
			int aLength = (int)a.utf8LengthInBytes;
			int bLength = (int)b.utf8LengthInBytes;
			byte* aBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes510>(a.bytes);
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes30>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(aBytes, aLength, bBytes, bLength);
		}

		// Token: 0x0600039A RID: 922 RVA: 0x00009E08 File Offset: 0x00008008
		public static bool operator !=(in FixedString512Bytes a, in FixedString32Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x0600039B RID: 923 RVA: 0x00009E14 File Offset: 0x00008014
		public bool Equals(FixedString32Bytes other)
		{
			return this == other;
		}

		// Token: 0x0600039C RID: 924 RVA: 0x00009E1E File Offset: 0x0000801E
		public int CompareTo(FixedString64Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x0600039D RID: 925 RVA: 0x00009E28 File Offset: 0x00008028
		public FixedString512Bytes(in FixedString64Bytes other)
		{
			this = default(FixedString512Bytes);
			this.Initialize(other);
		}

		// Token: 0x0600039E RID: 926 RVA: 0x00009E3C File Offset: 0x0000803C
		internal unsafe int Initialize(in FixedString64Bytes other)
		{
			this.bytes = default(FixedBytes510);
			this.utf8LengthInBytes = 0;
			int length = 0;
			byte* unsafePtr = this.GetUnsafePtr();
			byte* src = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes62>(other.bytes);
			ushort srcLength = other.utf8LengthInBytes;
			FormatError formatError = UTF8ArrayUnsafeUtility.AppendUTF8Bytes(unsafePtr, ref length, 509, src, (int)srcLength);
			if (formatError != FormatError.None)
			{
				return (int)formatError;
			}
			this.Length = length;
			return 0;
		}

		// Token: 0x0600039F RID: 927 RVA: 0x00009E94 File Offset: 0x00008094
		public unsafe static bool operator ==(in FixedString512Bytes a, in FixedString64Bytes b)
		{
			int aLength = (int)a.utf8LengthInBytes;
			int bLength = (int)b.utf8LengthInBytes;
			byte* aBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes510>(a.bytes);
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes62>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(aBytes, aLength, bBytes, bLength);
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x00009ED0 File Offset: 0x000080D0
		public static bool operator !=(in FixedString512Bytes a, in FixedString64Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x00009EDC File Offset: 0x000080DC
		public bool Equals(FixedString64Bytes other)
		{
			return this == other;
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x00009EE6 File Offset: 0x000080E6
		public int CompareTo(FixedString128Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x00009EF0 File Offset: 0x000080F0
		public FixedString512Bytes(in FixedString128Bytes other)
		{
			this = default(FixedString512Bytes);
			this.Initialize(other);
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x00009F04 File Offset: 0x00008104
		internal unsafe int Initialize(in FixedString128Bytes other)
		{
			this.bytes = default(FixedBytes510);
			this.utf8LengthInBytes = 0;
			int length = 0;
			byte* unsafePtr = this.GetUnsafePtr();
			byte* src = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes126>(other.bytes);
			ushort srcLength = other.utf8LengthInBytes;
			FormatError formatError = UTF8ArrayUnsafeUtility.AppendUTF8Bytes(unsafePtr, ref length, 509, src, (int)srcLength);
			if (formatError != FormatError.None)
			{
				return (int)formatError;
			}
			this.Length = length;
			return 0;
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x00009F5C File Offset: 0x0000815C
		public unsafe static bool operator ==(in FixedString512Bytes a, in FixedString128Bytes b)
		{
			int aLength = (int)a.utf8LengthInBytes;
			int bLength = (int)b.utf8LengthInBytes;
			byte* aBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes510>(a.bytes);
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes126>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(aBytes, aLength, bBytes, bLength);
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x00009F98 File Offset: 0x00008198
		public static bool operator !=(in FixedString512Bytes a, in FixedString128Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x00009FA4 File Offset: 0x000081A4
		public bool Equals(FixedString128Bytes other)
		{
			return this == other;
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x00009FAE File Offset: 0x000081AE
		public int CompareTo(FixedString512Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x00009FB8 File Offset: 0x000081B8
		public FixedString512Bytes(in FixedString512Bytes other)
		{
			this = default(FixedString512Bytes);
			this.Initialize(other);
		}

		// Token: 0x060003AA RID: 938 RVA: 0x00009FCC File Offset: 0x000081CC
		internal unsafe int Initialize(in FixedString512Bytes other)
		{
			this.bytes = default(FixedBytes510);
			this.utf8LengthInBytes = 0;
			int length = 0;
			byte* unsafePtr = this.GetUnsafePtr();
			byte* src = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes510>(other.bytes);
			ushort srcLength = other.utf8LengthInBytes;
			FormatError formatError = UTF8ArrayUnsafeUtility.AppendUTF8Bytes(unsafePtr, ref length, 509, src, (int)srcLength);
			if (formatError != FormatError.None)
			{
				return (int)formatError;
			}
			this.Length = length;
			return 0;
		}

		// Token: 0x060003AB RID: 939 RVA: 0x0000A024 File Offset: 0x00008224
		public unsafe static bool operator ==(in FixedString512Bytes a, in FixedString512Bytes b)
		{
			int aLength = (int)a.utf8LengthInBytes;
			int bLength = (int)b.utf8LengthInBytes;
			byte* aBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes510>(a.bytes);
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes510>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(aBytes, aLength, bBytes, bLength);
		}

		// Token: 0x060003AC RID: 940 RVA: 0x0000A060 File Offset: 0x00008260
		public static bool operator !=(in FixedString512Bytes a, in FixedString512Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x060003AD RID: 941 RVA: 0x0000A06C File Offset: 0x0000826C
		public bool Equals(FixedString512Bytes other)
		{
			return this == other;
		}

		// Token: 0x060003AE RID: 942 RVA: 0x0000A076 File Offset: 0x00008276
		public int CompareTo(FixedString4096Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x060003AF RID: 943 RVA: 0x0000A080 File Offset: 0x00008280
		public FixedString512Bytes(in FixedString4096Bytes other)
		{
			this = default(FixedString512Bytes);
			this.Initialize(other);
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x0000A094 File Offset: 0x00008294
		internal unsafe int Initialize(in FixedString4096Bytes other)
		{
			this.bytes = default(FixedBytes510);
			this.utf8LengthInBytes = 0;
			int length = 0;
			byte* unsafePtr = this.GetUnsafePtr();
			byte* src = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes4094>(other.bytes);
			ushort srcLength = other.utf8LengthInBytes;
			FormatError formatError = UTF8ArrayUnsafeUtility.AppendUTF8Bytes(unsafePtr, ref length, 509, src, (int)srcLength);
			if (formatError != FormatError.None)
			{
				return (int)formatError;
			}
			this.Length = length;
			return 0;
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x0000A0EC File Offset: 0x000082EC
		public unsafe static bool operator ==(in FixedString512Bytes a, in FixedString4096Bytes b)
		{
			int aLength = (int)a.utf8LengthInBytes;
			int bLength = (int)b.utf8LengthInBytes;
			byte* aBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes510>(a.bytes);
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes4094>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(aBytes, aLength, bBytes, bLength);
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x0000A128 File Offset: 0x00008328
		public static bool operator !=(in FixedString512Bytes a, in FixedString4096Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x0000A134 File Offset: 0x00008334
		public bool Equals(FixedString4096Bytes other)
		{
			return this == other;
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x0000A13E File Offset: 0x0000833E
		public static implicit operator FixedString4096Bytes(in FixedString512Bytes fs)
		{
			return new FixedString4096Bytes(ref fs);
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x0000A146 File Offset: 0x00008346
		[NotBurstCompatible]
		public static implicit operator FixedString512Bytes(string b)
		{
			return new FixedString512Bytes(b);
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x0000A14E File Offset: 0x0000834E
		[NotBurstCompatible]
		public override string ToString()
		{
			return ref this.ConvertToString<FixedString512Bytes>();
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x0000A156 File Offset: 0x00008356
		public override int GetHashCode()
		{
			return ref this.ComputeHashCode<FixedString512Bytes>();
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x0000A160 File Offset: 0x00008360
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

		// Token: 0x060003B9 RID: 953 RVA: 0x0000A1FC File Offset: 0x000083FC
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckIndexInRange(int index)
		{
			if (index < 0)
			{
				throw new IndexOutOfRangeException(string.Format("Index {0} must be positive.", index));
			}
			if (index >= (int)this.utf8LengthInBytes)
			{
				throw new IndexOutOfRangeException(string.Format("Index {0} is out of range in FixedString512Bytes of '{1}' Length.", index, this.utf8LengthInBytes));
			}
		}

		// Token: 0x060003BA RID: 954 RVA: 0x0000A250 File Offset: 0x00008450
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckLengthInRange(int length)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException(string.Format("Length {0} must be positive.", length));
			}
			if (length > 509)
			{
				throw new ArgumentOutOfRangeException(string.Format("Length {0} is out of range in FixedString512Bytes of '{1}' Capacity.", length, 509));
			}
		}

		// Token: 0x060003BB RID: 955 RVA: 0x0000A29F File Offset: 0x0000849F
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckCapacityInRange(int capacity)
		{
			if (capacity > 509)
			{
				throw new ArgumentOutOfRangeException(string.Format("Capacity {0} must be lower than {1}.", capacity, 509));
			}
		}

		// Token: 0x060003BC RID: 956 RVA: 0x0000A2C9 File Offset: 0x000084C9
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckCopyError(CopyError error, string source)
		{
			if (error != CopyError.None)
			{
				throw new ArgumentException(string.Format("FixedString512Bytes: {0} while copying \"{1}\"", error, source));
			}
		}

		// Token: 0x060003BD RID: 957 RVA: 0x00008A73 File Offset: 0x00006C73
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckFormatError(FormatError error)
		{
			if (error != FormatError.None)
			{
				throw new ArgumentException("Source is too long to fit into fixed string of this size");
			}
		}

		// Token: 0x04000147 RID: 327
		internal const ushort utf8MaxLengthInBytes = 509;

		// Token: 0x04000148 RID: 328
		[SerializeField]
		internal ushort utf8LengthInBytes;

		// Token: 0x04000149 RID: 329
		[SerializeField]
		internal FixedBytes510 bytes;

		// Token: 0x0200007A RID: 122
		public struct Enumerator : IEnumerator
		{
			// Token: 0x060003BE RID: 958 RVA: 0x0000A2E5 File Offset: 0x000084E5
			public Enumerator(FixedString512Bytes other)
			{
				this.target = other;
				this.offset = 0;
				this.current = default(Unicode.Rune);
			}

			// Token: 0x060003BF RID: 959 RVA: 0x000024A3 File Offset: 0x000006A3
			public void Dispose()
			{
			}

			// Token: 0x060003C0 RID: 960 RVA: 0x0000A301 File Offset: 0x00008501
			public bool MoveNext()
			{
				if (this.offset >= this.target.Length)
				{
					return false;
				}
				Unicode.Utf8ToUcs(out this.current, this.target.GetUnsafePtr(), ref this.offset, this.target.Length);
				return true;
			}

			// Token: 0x060003C1 RID: 961 RVA: 0x0000A341 File Offset: 0x00008541
			public void Reset()
			{
				this.offset = 0;
				this.current = default(Unicode.Rune);
			}

			// Token: 0x17000087 RID: 135
			// (get) Token: 0x060003C2 RID: 962 RVA: 0x0000A356 File Offset: 0x00008556
			public Unicode.Rune Current
			{
				get
				{
					return this.current;
				}
			}

			// Token: 0x17000088 RID: 136
			// (get) Token: 0x060003C3 RID: 963 RVA: 0x0000A35E File Offset: 0x0000855E
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x0400014A RID: 330
			private FixedString512Bytes target;

			// Token: 0x0400014B RID: 331
			private int offset;

			// Token: 0x0400014C RID: 332
			private Unicode.Rune current;
		}
	}
}
