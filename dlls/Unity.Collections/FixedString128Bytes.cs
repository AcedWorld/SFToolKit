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
	// Token: 0x02000075 RID: 117
	[BurstCompatible]
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Size = 128)]
	public struct FixedString128Bytes : INativeList<byte>, IIndexable<byte>, IUTF8Bytes, IComparable<string>, IEquatable<string>, IComparable<FixedString32Bytes>, IEquatable<FixedString32Bytes>, IComparable<FixedString64Bytes>, IEquatable<FixedString64Bytes>, IComparable<FixedString128Bytes>, IEquatable<FixedString128Bytes>, IComparable<FixedString512Bytes>, IEquatable<FixedString512Bytes>, IComparable<FixedString4096Bytes>, IEquatable<FixedString4096Bytes>
	{
		// Token: 0x17000079 RID: 121
		// (get) Token: 0x0600033B RID: 827 RVA: 0x00009321 File Offset: 0x00007521
		public static int UTF8MaxLengthInBytes
		{
			get
			{
				return 125;
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x0600033C RID: 828 RVA: 0x00009325 File Offset: 0x00007525
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

		// Token: 0x0600033D RID: 829 RVA: 0x00009333 File Offset: 0x00007533
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe byte* GetUnsafePtr()
		{
			return (byte*)UnsafeUtility.AddressOf<FixedBytes126>(ref this.bytes);
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x0600033E RID: 830 RVA: 0x00009340 File Offset: 0x00007540
		// (set) Token: 0x0600033F RID: 831 RVA: 0x00009348 File Offset: 0x00007548
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

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000340 RID: 832 RVA: 0x00009321 File Offset: 0x00007521
		// (set) Token: 0x06000341 RID: 833 RVA: 0x000024A3 File Offset: 0x000006A3
		public int Capacity
		{
			get
			{
				return 125;
			}
			set
			{
			}
		}

		// Token: 0x06000342 RID: 834 RVA: 0x00009364 File Offset: 0x00007564
		public unsafe bool TryResize(int newLength, NativeArrayOptions clearOptions = NativeArrayOptions.ClearMemory)
		{
			if (newLength < 0 || newLength > 125)
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

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000343 RID: 835 RVA: 0x000093DF File Offset: 0x000075DF
		public bool IsEmpty
		{
			get
			{
				return this.utf8LengthInBytes == 0;
			}
		}

		// Token: 0x1700007E RID: 126
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

		// Token: 0x06000346 RID: 838 RVA: 0x00009401 File Offset: 0x00007601
		public unsafe ref byte ElementAt(int index)
		{
			return ref this.GetUnsafePtr()[index];
		}

		// Token: 0x06000347 RID: 839 RVA: 0x0000940B File Offset: 0x0000760B
		public void Clear()
		{
			this.Length = 0;
		}

		// Token: 0x06000348 RID: 840 RVA: 0x00009414 File Offset: 0x00007614
		public void Add(in byte value)
		{
			int length = this.Length;
			this.Length = length + 1;
			this[length] = value;
		}

		// Token: 0x06000349 RID: 841 RVA: 0x0000943A File Offset: 0x0000763A
		public FixedString128Bytes.Enumerator GetEnumerator()
		{
			return new FixedString128Bytes.Enumerator(this);
		}

		// Token: 0x0600034A RID: 842 RVA: 0x00009447 File Offset: 0x00007647
		[NotBurstCompatible]
		public int CompareTo(string other)
		{
			return this.ToString().CompareTo(other);
		}

		// Token: 0x0600034B RID: 843 RVA: 0x0000945C File Offset: 0x0000765C
		[NotBurstCompatible]
		public unsafe bool Equals(string other)
		{
			int num = (int)this.utf8LengthInBytes;
			int length = other.Length;
			byte* utf8Buffer = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes126>(this.bytes);
			char* ptr = other;
			if (ptr != null)
			{
				ptr += RuntimeHelpers.OffsetToStringData / 2;
			}
			return UTF8ArrayUnsafeUtility.StrCmp(utf8Buffer, num, ptr, length) == 0;
		}

		// Token: 0x0600034C RID: 844 RVA: 0x000094A1 File Offset: 0x000076A1
		public ref FixedList128Bytes<byte> AsFixedList()
		{
			return UnsafeUtility.AsRef<FixedList128Bytes<byte>>(UnsafeUtility.AddressOf<FixedString128Bytes>(ref this));
		}

		// Token: 0x0600034D RID: 845 RVA: 0x000094AE File Offset: 0x000076AE
		[NotBurstCompatible]
		public FixedString128Bytes(string source)
		{
			this = default(FixedString128Bytes);
			this.Initialize(source);
		}

		// Token: 0x0600034E RID: 846 RVA: 0x000094C0 File Offset: 0x000076C0
		[NotBurstCompatible]
		internal unsafe int Initialize(string source)
		{
			this.bytes = default(FixedBytes126);
			this.utf8LengthInBytes = 0;
			fixed (string text = source)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				CopyError copyError = UTF8ArrayUnsafeUtility.Copy(this.GetUnsafePtr(), out this.utf8LengthInBytes, 125, ptr, source.Length);
				if (copyError != CopyError.None)
				{
					return (int)copyError;
				}
				this.Length = (int)this.utf8LengthInBytes;
			}
			return 0;
		}

		// Token: 0x0600034F RID: 847 RVA: 0x0000951F File Offset: 0x0000771F
		public FixedString128Bytes(Unicode.Rune rune, int count = 1)
		{
			this = default(FixedString128Bytes);
			this.Initialize(rune, count);
		}

		// Token: 0x06000350 RID: 848 RVA: 0x00009531 File Offset: 0x00007731
		internal int Initialize(Unicode.Rune rune, int count = 1)
		{
			this = default(FixedString128Bytes);
			return (int)ref this.Append(rune, count);
		}

		// Token: 0x06000351 RID: 849 RVA: 0x00009542 File Offset: 0x00007742
		public int CompareTo(FixedString32Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x06000352 RID: 850 RVA: 0x0000954C File Offset: 0x0000774C
		public FixedString128Bytes(in FixedString32Bytes other)
		{
			this = default(FixedString128Bytes);
			this.Initialize(other);
		}

		// Token: 0x06000353 RID: 851 RVA: 0x00009560 File Offset: 0x00007760
		internal unsafe int Initialize(in FixedString32Bytes other)
		{
			this.bytes = default(FixedBytes126);
			this.utf8LengthInBytes = 0;
			int length = 0;
			byte* unsafePtr = this.GetUnsafePtr();
			byte* src = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes30>(other.bytes);
			ushort srcLength = other.utf8LengthInBytes;
			FormatError formatError = UTF8ArrayUnsafeUtility.AppendUTF8Bytes(unsafePtr, ref length, 125, src, (int)srcLength);
			if (formatError != FormatError.None)
			{
				return (int)formatError;
			}
			this.Length = length;
			return 0;
		}

		// Token: 0x06000354 RID: 852 RVA: 0x000095B4 File Offset: 0x000077B4
		public unsafe static bool operator ==(in FixedString128Bytes a, in FixedString32Bytes b)
		{
			int aLength = (int)a.utf8LengthInBytes;
			int bLength = (int)b.utf8LengthInBytes;
			byte* aBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes126>(a.bytes);
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes30>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(aBytes, aLength, bBytes, bLength);
		}

		// Token: 0x06000355 RID: 853 RVA: 0x000095F0 File Offset: 0x000077F0
		public static bool operator !=(in FixedString128Bytes a, in FixedString32Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x06000356 RID: 854 RVA: 0x000095FC File Offset: 0x000077FC
		public bool Equals(FixedString32Bytes other)
		{
			return this == other;
		}

		// Token: 0x06000357 RID: 855 RVA: 0x00009606 File Offset: 0x00007806
		public int CompareTo(FixedString64Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x06000358 RID: 856 RVA: 0x00009610 File Offset: 0x00007810
		public FixedString128Bytes(in FixedString64Bytes other)
		{
			this = default(FixedString128Bytes);
			this.Initialize(other);
		}

		// Token: 0x06000359 RID: 857 RVA: 0x00009624 File Offset: 0x00007824
		internal unsafe int Initialize(in FixedString64Bytes other)
		{
			this.bytes = default(FixedBytes126);
			this.utf8LengthInBytes = 0;
			int length = 0;
			byte* unsafePtr = this.GetUnsafePtr();
			byte* src = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes62>(other.bytes);
			ushort srcLength = other.utf8LengthInBytes;
			FormatError formatError = UTF8ArrayUnsafeUtility.AppendUTF8Bytes(unsafePtr, ref length, 125, src, (int)srcLength);
			if (formatError != FormatError.None)
			{
				return (int)formatError;
			}
			this.Length = length;
			return 0;
		}

		// Token: 0x0600035A RID: 858 RVA: 0x00009678 File Offset: 0x00007878
		public unsafe static bool operator ==(in FixedString128Bytes a, in FixedString64Bytes b)
		{
			int aLength = (int)a.utf8LengthInBytes;
			int bLength = (int)b.utf8LengthInBytes;
			byte* aBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes126>(a.bytes);
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes62>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(aBytes, aLength, bBytes, bLength);
		}

		// Token: 0x0600035B RID: 859 RVA: 0x000096B4 File Offset: 0x000078B4
		public static bool operator !=(in FixedString128Bytes a, in FixedString64Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x0600035C RID: 860 RVA: 0x000096C0 File Offset: 0x000078C0
		public bool Equals(FixedString64Bytes other)
		{
			return this == other;
		}

		// Token: 0x0600035D RID: 861 RVA: 0x000096CA File Offset: 0x000078CA
		public int CompareTo(FixedString128Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x0600035E RID: 862 RVA: 0x000096D4 File Offset: 0x000078D4
		public FixedString128Bytes(in FixedString128Bytes other)
		{
			this = default(FixedString128Bytes);
			this.Initialize(other);
		}

		// Token: 0x0600035F RID: 863 RVA: 0x000096E8 File Offset: 0x000078E8
		internal unsafe int Initialize(in FixedString128Bytes other)
		{
			this.bytes = default(FixedBytes126);
			this.utf8LengthInBytes = 0;
			int length = 0;
			byte* unsafePtr = this.GetUnsafePtr();
			byte* src = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes126>(other.bytes);
			ushort srcLength = other.utf8LengthInBytes;
			FormatError formatError = UTF8ArrayUnsafeUtility.AppendUTF8Bytes(unsafePtr, ref length, 125, src, (int)srcLength);
			if (formatError != FormatError.None)
			{
				return (int)formatError;
			}
			this.Length = length;
			return 0;
		}

		// Token: 0x06000360 RID: 864 RVA: 0x0000973C File Offset: 0x0000793C
		public unsafe static bool operator ==(in FixedString128Bytes a, in FixedString128Bytes b)
		{
			int aLength = (int)a.utf8LengthInBytes;
			int bLength = (int)b.utf8LengthInBytes;
			byte* aBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes126>(a.bytes);
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes126>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(aBytes, aLength, bBytes, bLength);
		}

		// Token: 0x06000361 RID: 865 RVA: 0x00009778 File Offset: 0x00007978
		public static bool operator !=(in FixedString128Bytes a, in FixedString128Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x06000362 RID: 866 RVA: 0x00009784 File Offset: 0x00007984
		public bool Equals(FixedString128Bytes other)
		{
			return this == other;
		}

		// Token: 0x06000363 RID: 867 RVA: 0x0000978E File Offset: 0x0000798E
		public int CompareTo(FixedString512Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x06000364 RID: 868 RVA: 0x00009798 File Offset: 0x00007998
		public FixedString128Bytes(in FixedString512Bytes other)
		{
			this = default(FixedString128Bytes);
			this.Initialize(other);
		}

		// Token: 0x06000365 RID: 869 RVA: 0x000097AC File Offset: 0x000079AC
		internal unsafe int Initialize(in FixedString512Bytes other)
		{
			this.bytes = default(FixedBytes126);
			this.utf8LengthInBytes = 0;
			int length = 0;
			byte* unsafePtr = this.GetUnsafePtr();
			byte* src = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes510>(other.bytes);
			ushort srcLength = other.utf8LengthInBytes;
			FormatError formatError = UTF8ArrayUnsafeUtility.AppendUTF8Bytes(unsafePtr, ref length, 125, src, (int)srcLength);
			if (formatError != FormatError.None)
			{
				return (int)formatError;
			}
			this.Length = length;
			return 0;
		}

		// Token: 0x06000366 RID: 870 RVA: 0x00009800 File Offset: 0x00007A00
		public unsafe static bool operator ==(in FixedString128Bytes a, in FixedString512Bytes b)
		{
			int aLength = (int)a.utf8LengthInBytes;
			int bLength = (int)b.utf8LengthInBytes;
			byte* aBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes126>(a.bytes);
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes510>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(aBytes, aLength, bBytes, bLength);
		}

		// Token: 0x06000367 RID: 871 RVA: 0x0000983C File Offset: 0x00007A3C
		public static bool operator !=(in FixedString128Bytes a, in FixedString512Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x06000368 RID: 872 RVA: 0x00009848 File Offset: 0x00007A48
		public bool Equals(FixedString512Bytes other)
		{
			return this == other;
		}

		// Token: 0x06000369 RID: 873 RVA: 0x00009852 File Offset: 0x00007A52
		public static implicit operator FixedString512Bytes(in FixedString128Bytes fs)
		{
			return new FixedString512Bytes(ref fs);
		}

		// Token: 0x0600036A RID: 874 RVA: 0x0000985A File Offset: 0x00007A5A
		public int CompareTo(FixedString4096Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x0600036B RID: 875 RVA: 0x00009864 File Offset: 0x00007A64
		public FixedString128Bytes(in FixedString4096Bytes other)
		{
			this = default(FixedString128Bytes);
			this.Initialize(other);
		}

		// Token: 0x0600036C RID: 876 RVA: 0x00009878 File Offset: 0x00007A78
		internal unsafe int Initialize(in FixedString4096Bytes other)
		{
			this.bytes = default(FixedBytes126);
			this.utf8LengthInBytes = 0;
			int length = 0;
			byte* unsafePtr = this.GetUnsafePtr();
			byte* src = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes4094>(other.bytes);
			ushort srcLength = other.utf8LengthInBytes;
			FormatError formatError = UTF8ArrayUnsafeUtility.AppendUTF8Bytes(unsafePtr, ref length, 125, src, (int)srcLength);
			if (formatError != FormatError.None)
			{
				return (int)formatError;
			}
			this.Length = length;
			return 0;
		}

		// Token: 0x0600036D RID: 877 RVA: 0x000098CC File Offset: 0x00007ACC
		public unsafe static bool operator ==(in FixedString128Bytes a, in FixedString4096Bytes b)
		{
			int aLength = (int)a.utf8LengthInBytes;
			int bLength = (int)b.utf8LengthInBytes;
			byte* aBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes126>(a.bytes);
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes4094>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(aBytes, aLength, bBytes, bLength);
		}

		// Token: 0x0600036E RID: 878 RVA: 0x00009908 File Offset: 0x00007B08
		public static bool operator !=(in FixedString128Bytes a, in FixedString4096Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x0600036F RID: 879 RVA: 0x00009914 File Offset: 0x00007B14
		public bool Equals(FixedString4096Bytes other)
		{
			return this == other;
		}

		// Token: 0x06000370 RID: 880 RVA: 0x0000991E File Offset: 0x00007B1E
		public static implicit operator FixedString4096Bytes(in FixedString128Bytes fs)
		{
			return new FixedString4096Bytes(ref fs);
		}

		// Token: 0x06000371 RID: 881 RVA: 0x00009926 File Offset: 0x00007B26
		[NotBurstCompatible]
		public static implicit operator FixedString128Bytes(string b)
		{
			return new FixedString128Bytes(b);
		}

		// Token: 0x06000372 RID: 882 RVA: 0x0000992E File Offset: 0x00007B2E
		[NotBurstCompatible]
		public override string ToString()
		{
			return ref this.ConvertToString<FixedString128Bytes>();
		}

		// Token: 0x06000373 RID: 883 RVA: 0x00009936 File Offset: 0x00007B36
		public override int GetHashCode()
		{
			return ref this.ComputeHashCode<FixedString128Bytes>();
		}

		// Token: 0x06000374 RID: 884 RVA: 0x00009940 File Offset: 0x00007B40
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

		// Token: 0x06000375 RID: 885 RVA: 0x000099DC File Offset: 0x00007BDC
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckIndexInRange(int index)
		{
			if (index < 0)
			{
				throw new IndexOutOfRangeException(string.Format("Index {0} must be positive.", index));
			}
			if (index >= (int)this.utf8LengthInBytes)
			{
				throw new IndexOutOfRangeException(string.Format("Index {0} is out of range in FixedString128Bytes of '{1}' Length.", index, this.utf8LengthInBytes));
			}
		}

		// Token: 0x06000376 RID: 886 RVA: 0x00009A2D File Offset: 0x00007C2D
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckLengthInRange(int length)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException(string.Format("Length {0} must be positive.", length));
			}
			if (length > 125)
			{
				throw new ArgumentOutOfRangeException(string.Format("Length {0} is out of range in FixedString128Bytes of '{1}' Capacity.", length, 125));
			}
		}

		// Token: 0x06000377 RID: 887 RVA: 0x00009A6B File Offset: 0x00007C6B
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckCapacityInRange(int capacity)
		{
			if (capacity > 125)
			{
				throw new ArgumentOutOfRangeException(string.Format("Capacity {0} must be lower than {1}.", capacity, 125));
			}
		}

		// Token: 0x06000378 RID: 888 RVA: 0x00009A8F File Offset: 0x00007C8F
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckCopyError(CopyError error, string source)
		{
			if (error != CopyError.None)
			{
				throw new ArgumentException(string.Format("FixedString128Bytes: {0} while copying \"{1}\"", error, source));
			}
		}

		// Token: 0x06000379 RID: 889 RVA: 0x00008A73 File Offset: 0x00006C73
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckFormatError(FormatError error)
		{
			if (error != FormatError.None)
			{
				throw new ArgumentException("Source is too long to fit into fixed string of this size");
			}
		}

		// Token: 0x04000114 RID: 276
		internal const ushort utf8MaxLengthInBytes = 125;

		// Token: 0x04000115 RID: 277
		[SerializeField]
		internal ushort utf8LengthInBytes;

		// Token: 0x04000116 RID: 278
		[SerializeField]
		internal FixedBytes126 bytes;

		// Token: 0x02000076 RID: 118
		public struct Enumerator : IEnumerator
		{
			// Token: 0x0600037A RID: 890 RVA: 0x00009AAB File Offset: 0x00007CAB
			public Enumerator(FixedString128Bytes other)
			{
				this.target = other;
				this.offset = 0;
				this.current = default(Unicode.Rune);
			}

			// Token: 0x0600037B RID: 891 RVA: 0x000024A3 File Offset: 0x000006A3
			public void Dispose()
			{
			}

			// Token: 0x0600037C RID: 892 RVA: 0x00009AC7 File Offset: 0x00007CC7
			public bool MoveNext()
			{
				if (this.offset >= this.target.Length)
				{
					return false;
				}
				Unicode.Utf8ToUcs(out this.current, this.target.GetUnsafePtr(), ref this.offset, this.target.Length);
				return true;
			}

			// Token: 0x0600037D RID: 893 RVA: 0x00009B07 File Offset: 0x00007D07
			public void Reset()
			{
				this.offset = 0;
				this.current = default(Unicode.Rune);
			}

			// Token: 0x1700007F RID: 127
			// (get) Token: 0x0600037E RID: 894 RVA: 0x00009B1C File Offset: 0x00007D1C
			public Unicode.Rune Current
			{
				get
				{
					return this.current;
				}
			}

			// Token: 0x17000080 RID: 128
			// (get) Token: 0x0600037F RID: 895 RVA: 0x00009B24 File Offset: 0x00007D24
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x04000117 RID: 279
			private FixedString128Bytes target;

			// Token: 0x04000118 RID: 280
			private int offset;

			// Token: 0x04000119 RID: 281
			private Unicode.Rune current;
		}
	}
}
