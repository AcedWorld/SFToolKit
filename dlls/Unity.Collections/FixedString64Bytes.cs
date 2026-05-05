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
	// Token: 0x02000071 RID: 113
	[BurstCompatible]
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Size = 64)]
	public struct FixedString64Bytes : INativeList<byte>, IIndexable<byte>, IUTF8Bytes, IComparable<string>, IEquatable<string>, IComparable<FixedString32Bytes>, IEquatable<FixedString32Bytes>, IComparable<FixedString64Bytes>, IEquatable<FixedString64Bytes>, IComparable<FixedString128Bytes>, IEquatable<FixedString128Bytes>, IComparable<FixedString512Bytes>, IEquatable<FixedString512Bytes>, IComparable<FixedString4096Bytes>, IEquatable<FixedString4096Bytes>
	{
		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060002F5 RID: 757 RVA: 0x00008B09 File Offset: 0x00006D09
		public static int UTF8MaxLengthInBytes
		{
			get
			{
				return 61;
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060002F6 RID: 758 RVA: 0x00008B0D File Offset: 0x00006D0D
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

		// Token: 0x060002F7 RID: 759 RVA: 0x00008B1B File Offset: 0x00006D1B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe byte* GetUnsafePtr()
		{
			return (byte*)UnsafeUtility.AddressOf<FixedBytes62>(ref this.bytes);
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060002F8 RID: 760 RVA: 0x00008B28 File Offset: 0x00006D28
		// (set) Token: 0x060002F9 RID: 761 RVA: 0x00008B30 File Offset: 0x00006D30
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

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060002FA RID: 762 RVA: 0x00008B09 File Offset: 0x00006D09
		// (set) Token: 0x060002FB RID: 763 RVA: 0x000024A3 File Offset: 0x000006A3
		public int Capacity
		{
			get
			{
				return 61;
			}
			set
			{
			}
		}

		// Token: 0x060002FC RID: 764 RVA: 0x00008B4C File Offset: 0x00006D4C
		public unsafe bool TryResize(int newLength, NativeArrayOptions clearOptions = NativeArrayOptions.ClearMemory)
		{
			if (newLength < 0 || newLength > 61)
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

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060002FD RID: 765 RVA: 0x00008BC7 File Offset: 0x00006DC7
		public bool IsEmpty
		{
			get
			{
				return this.utf8LengthInBytes == 0;
			}
		}

		// Token: 0x17000076 RID: 118
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

		// Token: 0x06000300 RID: 768 RVA: 0x00008BE9 File Offset: 0x00006DE9
		public unsafe ref byte ElementAt(int index)
		{
			return ref this.GetUnsafePtr()[index];
		}

		// Token: 0x06000301 RID: 769 RVA: 0x00008BF3 File Offset: 0x00006DF3
		public void Clear()
		{
			this.Length = 0;
		}

		// Token: 0x06000302 RID: 770 RVA: 0x00008BFC File Offset: 0x00006DFC
		public void Add(in byte value)
		{
			int length = this.Length;
			this.Length = length + 1;
			this[length] = value;
		}

		// Token: 0x06000303 RID: 771 RVA: 0x00008C22 File Offset: 0x00006E22
		public FixedString64Bytes.Enumerator GetEnumerator()
		{
			return new FixedString64Bytes.Enumerator(this);
		}

		// Token: 0x06000304 RID: 772 RVA: 0x00008C2F File Offset: 0x00006E2F
		[NotBurstCompatible]
		public int CompareTo(string other)
		{
			return this.ToString().CompareTo(other);
		}

		// Token: 0x06000305 RID: 773 RVA: 0x00008C44 File Offset: 0x00006E44
		[NotBurstCompatible]
		public unsafe bool Equals(string other)
		{
			int num = (int)this.utf8LengthInBytes;
			int length = other.Length;
			byte* utf8Buffer = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes62>(this.bytes);
			char* ptr = other;
			if (ptr != null)
			{
				ptr += RuntimeHelpers.OffsetToStringData / 2;
			}
			return UTF8ArrayUnsafeUtility.StrCmp(utf8Buffer, num, ptr, length) == 0;
		}

		// Token: 0x06000306 RID: 774 RVA: 0x00008C89 File Offset: 0x00006E89
		public ref FixedList64Bytes<byte> AsFixedList()
		{
			return UnsafeUtility.AsRef<FixedList64Bytes<byte>>(UnsafeUtility.AddressOf<FixedString64Bytes>(ref this));
		}

		// Token: 0x06000307 RID: 775 RVA: 0x00008C96 File Offset: 0x00006E96
		[NotBurstCompatible]
		public FixedString64Bytes(string source)
		{
			this = default(FixedString64Bytes);
			this.Initialize(source);
		}

		// Token: 0x06000308 RID: 776 RVA: 0x00008CA8 File Offset: 0x00006EA8
		[NotBurstCompatible]
		internal unsafe int Initialize(string source)
		{
			this.bytes = default(FixedBytes62);
			this.utf8LengthInBytes = 0;
			fixed (string text = source)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				CopyError copyError = UTF8ArrayUnsafeUtility.Copy(this.GetUnsafePtr(), out this.utf8LengthInBytes, 61, ptr, source.Length);
				if (copyError != CopyError.None)
				{
					return (int)copyError;
				}
				this.Length = (int)this.utf8LengthInBytes;
			}
			return 0;
		}

		// Token: 0x06000309 RID: 777 RVA: 0x00008D07 File Offset: 0x00006F07
		public FixedString64Bytes(Unicode.Rune rune, int count = 1)
		{
			this = default(FixedString64Bytes);
			this.Initialize(rune, count);
		}

		// Token: 0x0600030A RID: 778 RVA: 0x00008D19 File Offset: 0x00006F19
		internal int Initialize(Unicode.Rune rune, int count = 1)
		{
			this = default(FixedString64Bytes);
			return (int)ref this.Append(rune, count);
		}

		// Token: 0x0600030B RID: 779 RVA: 0x00008D2A File Offset: 0x00006F2A
		public int CompareTo(FixedString32Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x0600030C RID: 780 RVA: 0x00008D34 File Offset: 0x00006F34
		public FixedString64Bytes(in FixedString32Bytes other)
		{
			this = default(FixedString64Bytes);
			this.Initialize(other);
		}

		// Token: 0x0600030D RID: 781 RVA: 0x00008D48 File Offset: 0x00006F48
		internal unsafe int Initialize(in FixedString32Bytes other)
		{
			this.bytes = default(FixedBytes62);
			this.utf8LengthInBytes = 0;
			int length = 0;
			byte* unsafePtr = this.GetUnsafePtr();
			byte* src = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes30>(other.bytes);
			ushort srcLength = other.utf8LengthInBytes;
			FormatError formatError = UTF8ArrayUnsafeUtility.AppendUTF8Bytes(unsafePtr, ref length, 61, src, (int)srcLength);
			if (formatError != FormatError.None)
			{
				return (int)formatError;
			}
			this.Length = length;
			return 0;
		}

		// Token: 0x0600030E RID: 782 RVA: 0x00008D9C File Offset: 0x00006F9C
		public unsafe static bool operator ==(in FixedString64Bytes a, in FixedString32Bytes b)
		{
			int aLength = (int)a.utf8LengthInBytes;
			int bLength = (int)b.utf8LengthInBytes;
			byte* aBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes62>(a.bytes);
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes30>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(aBytes, aLength, bBytes, bLength);
		}

		// Token: 0x0600030F RID: 783 RVA: 0x00008DD8 File Offset: 0x00006FD8
		public static bool operator !=(in FixedString64Bytes a, in FixedString32Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x06000310 RID: 784 RVA: 0x00008DE4 File Offset: 0x00006FE4
		public bool Equals(FixedString32Bytes other)
		{
			return this == other;
		}

		// Token: 0x06000311 RID: 785 RVA: 0x00008DEE File Offset: 0x00006FEE
		public int CompareTo(FixedString64Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x06000312 RID: 786 RVA: 0x00008DF8 File Offset: 0x00006FF8
		public FixedString64Bytes(in FixedString64Bytes other)
		{
			this = default(FixedString64Bytes);
			this.Initialize(other);
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00008E0C File Offset: 0x0000700C
		internal unsafe int Initialize(in FixedString64Bytes other)
		{
			this.bytes = default(FixedBytes62);
			this.utf8LengthInBytes = 0;
			int length = 0;
			byte* unsafePtr = this.GetUnsafePtr();
			byte* src = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes62>(other.bytes);
			ushort srcLength = other.utf8LengthInBytes;
			FormatError formatError = UTF8ArrayUnsafeUtility.AppendUTF8Bytes(unsafePtr, ref length, 61, src, (int)srcLength);
			if (formatError != FormatError.None)
			{
				return (int)formatError;
			}
			this.Length = length;
			return 0;
		}

		// Token: 0x06000314 RID: 788 RVA: 0x00008E60 File Offset: 0x00007060
		public unsafe static bool operator ==(in FixedString64Bytes a, in FixedString64Bytes b)
		{
			int aLength = (int)a.utf8LengthInBytes;
			int bLength = (int)b.utf8LengthInBytes;
			byte* aBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes62>(a.bytes);
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes62>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(aBytes, aLength, bBytes, bLength);
		}

		// Token: 0x06000315 RID: 789 RVA: 0x00008E9C File Offset: 0x0000709C
		public static bool operator !=(in FixedString64Bytes a, in FixedString64Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x06000316 RID: 790 RVA: 0x00008EA8 File Offset: 0x000070A8
		public bool Equals(FixedString64Bytes other)
		{
			return this == other;
		}

		// Token: 0x06000317 RID: 791 RVA: 0x00008EB2 File Offset: 0x000070B2
		public int CompareTo(FixedString128Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x06000318 RID: 792 RVA: 0x00008EBC File Offset: 0x000070BC
		public FixedString64Bytes(in FixedString128Bytes other)
		{
			this = default(FixedString64Bytes);
			this.Initialize(other);
		}

		// Token: 0x06000319 RID: 793 RVA: 0x00008ED0 File Offset: 0x000070D0
		internal unsafe int Initialize(in FixedString128Bytes other)
		{
			this.bytes = default(FixedBytes62);
			this.utf8LengthInBytes = 0;
			int length = 0;
			byte* unsafePtr = this.GetUnsafePtr();
			byte* src = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes126>(other.bytes);
			ushort srcLength = other.utf8LengthInBytes;
			FormatError formatError = UTF8ArrayUnsafeUtility.AppendUTF8Bytes(unsafePtr, ref length, 61, src, (int)srcLength);
			if (formatError != FormatError.None)
			{
				return (int)formatError;
			}
			this.Length = length;
			return 0;
		}

		// Token: 0x0600031A RID: 794 RVA: 0x00008F24 File Offset: 0x00007124
		public unsafe static bool operator ==(in FixedString64Bytes a, in FixedString128Bytes b)
		{
			int aLength = (int)a.utf8LengthInBytes;
			int bLength = (int)b.utf8LengthInBytes;
			byte* aBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes62>(a.bytes);
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes126>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(aBytes, aLength, bBytes, bLength);
		}

		// Token: 0x0600031B RID: 795 RVA: 0x00008F60 File Offset: 0x00007160
		public static bool operator !=(in FixedString64Bytes a, in FixedString128Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x0600031C RID: 796 RVA: 0x00008F6C File Offset: 0x0000716C
		public bool Equals(FixedString128Bytes other)
		{
			return this == other;
		}

		// Token: 0x0600031D RID: 797 RVA: 0x00008F76 File Offset: 0x00007176
		public static implicit operator FixedString128Bytes(in FixedString64Bytes fs)
		{
			return new FixedString128Bytes(ref fs);
		}

		// Token: 0x0600031E RID: 798 RVA: 0x00008F7E File Offset: 0x0000717E
		public int CompareTo(FixedString512Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x0600031F RID: 799 RVA: 0x00008F88 File Offset: 0x00007188
		public FixedString64Bytes(in FixedString512Bytes other)
		{
			this = default(FixedString64Bytes);
			this.Initialize(other);
		}

		// Token: 0x06000320 RID: 800 RVA: 0x00008F9C File Offset: 0x0000719C
		internal unsafe int Initialize(in FixedString512Bytes other)
		{
			this.bytes = default(FixedBytes62);
			this.utf8LengthInBytes = 0;
			int length = 0;
			byte* unsafePtr = this.GetUnsafePtr();
			byte* src = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes510>(other.bytes);
			ushort srcLength = other.utf8LengthInBytes;
			FormatError formatError = UTF8ArrayUnsafeUtility.AppendUTF8Bytes(unsafePtr, ref length, 61, src, (int)srcLength);
			if (formatError != FormatError.None)
			{
				return (int)formatError;
			}
			this.Length = length;
			return 0;
		}

		// Token: 0x06000321 RID: 801 RVA: 0x00008FF0 File Offset: 0x000071F0
		public unsafe static bool operator ==(in FixedString64Bytes a, in FixedString512Bytes b)
		{
			int aLength = (int)a.utf8LengthInBytes;
			int bLength = (int)b.utf8LengthInBytes;
			byte* aBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes62>(a.bytes);
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes510>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(aBytes, aLength, bBytes, bLength);
		}

		// Token: 0x06000322 RID: 802 RVA: 0x0000902C File Offset: 0x0000722C
		public static bool operator !=(in FixedString64Bytes a, in FixedString512Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x06000323 RID: 803 RVA: 0x00009038 File Offset: 0x00007238
		public bool Equals(FixedString512Bytes other)
		{
			return this == other;
		}

		// Token: 0x06000324 RID: 804 RVA: 0x00009042 File Offset: 0x00007242
		public static implicit operator FixedString512Bytes(in FixedString64Bytes fs)
		{
			return new FixedString512Bytes(ref fs);
		}

		// Token: 0x06000325 RID: 805 RVA: 0x0000904A File Offset: 0x0000724A
		public int CompareTo(FixedString4096Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x06000326 RID: 806 RVA: 0x00009054 File Offset: 0x00007254
		public FixedString64Bytes(in FixedString4096Bytes other)
		{
			this = default(FixedString64Bytes);
			this.Initialize(other);
		}

		// Token: 0x06000327 RID: 807 RVA: 0x00009068 File Offset: 0x00007268
		internal unsafe int Initialize(in FixedString4096Bytes other)
		{
			this.bytes = default(FixedBytes62);
			this.utf8LengthInBytes = 0;
			int length = 0;
			byte* unsafePtr = this.GetUnsafePtr();
			byte* src = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes4094>(other.bytes);
			ushort srcLength = other.utf8LengthInBytes;
			FormatError formatError = UTF8ArrayUnsafeUtility.AppendUTF8Bytes(unsafePtr, ref length, 61, src, (int)srcLength);
			if (formatError != FormatError.None)
			{
				return (int)formatError;
			}
			this.Length = length;
			return 0;
		}

		// Token: 0x06000328 RID: 808 RVA: 0x000090BC File Offset: 0x000072BC
		public unsafe static bool operator ==(in FixedString64Bytes a, in FixedString4096Bytes b)
		{
			int aLength = (int)a.utf8LengthInBytes;
			int bLength = (int)b.utf8LengthInBytes;
			byte* aBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes62>(a.bytes);
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes4094>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(aBytes, aLength, bBytes, bLength);
		}

		// Token: 0x06000329 RID: 809 RVA: 0x000090F8 File Offset: 0x000072F8
		public static bool operator !=(in FixedString64Bytes a, in FixedString4096Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x0600032A RID: 810 RVA: 0x00009104 File Offset: 0x00007304
		public bool Equals(FixedString4096Bytes other)
		{
			return this == other;
		}

		// Token: 0x0600032B RID: 811 RVA: 0x0000910E File Offset: 0x0000730E
		public static implicit operator FixedString4096Bytes(in FixedString64Bytes fs)
		{
			return new FixedString4096Bytes(ref fs);
		}

		// Token: 0x0600032C RID: 812 RVA: 0x00009116 File Offset: 0x00007316
		[NotBurstCompatible]
		public static implicit operator FixedString64Bytes(string b)
		{
			return new FixedString64Bytes(b);
		}

		// Token: 0x0600032D RID: 813 RVA: 0x0000911E File Offset: 0x0000731E
		[NotBurstCompatible]
		public override string ToString()
		{
			return ref this.ConvertToString<FixedString64Bytes>();
		}

		// Token: 0x0600032E RID: 814 RVA: 0x00009126 File Offset: 0x00007326
		public override int GetHashCode()
		{
			return ref this.ComputeHashCode<FixedString64Bytes>();
		}

		// Token: 0x0600032F RID: 815 RVA: 0x00009130 File Offset: 0x00007330
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

		// Token: 0x06000330 RID: 816 RVA: 0x000091CC File Offset: 0x000073CC
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckIndexInRange(int index)
		{
			if (index < 0)
			{
				throw new IndexOutOfRangeException(string.Format("Index {0} must be positive.", index));
			}
			if (index >= (int)this.utf8LengthInBytes)
			{
				throw new IndexOutOfRangeException(string.Format("Index {0} is out of range in FixedString64Bytes of '{1}' Length.", index, this.utf8LengthInBytes));
			}
		}

		// Token: 0x06000331 RID: 817 RVA: 0x0000921D File Offset: 0x0000741D
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckLengthInRange(int length)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException(string.Format("Length {0} must be positive.", length));
			}
			if (length > 61)
			{
				throw new ArgumentOutOfRangeException(string.Format("Length {0} is out of range in FixedString64Bytes of '{1}' Capacity.", length, 61));
			}
		}

		// Token: 0x06000332 RID: 818 RVA: 0x0000925B File Offset: 0x0000745B
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckCapacityInRange(int capacity)
		{
			if (capacity > 61)
			{
				throw new ArgumentOutOfRangeException(string.Format("Capacity {0} must be lower than {1}.", capacity, 61));
			}
		}

		// Token: 0x06000333 RID: 819 RVA: 0x0000927F File Offset: 0x0000747F
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckCopyError(CopyError error, string source)
		{
			if (error != CopyError.None)
			{
				throw new ArgumentException(string.Format("FixedString64Bytes: {0} while copying \"{1}\"", error, source));
			}
		}

		// Token: 0x06000334 RID: 820 RVA: 0x00008A73 File Offset: 0x00006C73
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckFormatError(FormatError error)
		{
			if (error != FormatError.None)
			{
				throw new ArgumentException("Source is too long to fit into fixed string of this size");
			}
		}

		// Token: 0x040000F9 RID: 249
		internal const ushort utf8MaxLengthInBytes = 61;

		// Token: 0x040000FA RID: 250
		[SerializeField]
		internal ushort utf8LengthInBytes;

		// Token: 0x040000FB RID: 251
		[SerializeField]
		internal FixedBytes62 bytes;

		// Token: 0x02000072 RID: 114
		public struct Enumerator : IEnumerator
		{
			// Token: 0x06000335 RID: 821 RVA: 0x0000929B File Offset: 0x0000749B
			public Enumerator(FixedString64Bytes other)
			{
				this.target = other;
				this.offset = 0;
				this.current = default(Unicode.Rune);
			}

			// Token: 0x06000336 RID: 822 RVA: 0x000024A3 File Offset: 0x000006A3
			public void Dispose()
			{
			}

			// Token: 0x06000337 RID: 823 RVA: 0x000092B7 File Offset: 0x000074B7
			public bool MoveNext()
			{
				if (this.offset >= this.target.Length)
				{
					return false;
				}
				Unicode.Utf8ToUcs(out this.current, this.target.GetUnsafePtr(), ref this.offset, this.target.Length);
				return true;
			}

			// Token: 0x06000338 RID: 824 RVA: 0x000092F7 File Offset: 0x000074F7
			public void Reset()
			{
				this.offset = 0;
				this.current = default(Unicode.Rune);
			}

			// Token: 0x17000077 RID: 119
			// (get) Token: 0x06000339 RID: 825 RVA: 0x0000930C File Offset: 0x0000750C
			public Unicode.Rune Current
			{
				get
				{
					return this.current;
				}
			}

			// Token: 0x17000078 RID: 120
			// (get) Token: 0x0600033A RID: 826 RVA: 0x00009314 File Offset: 0x00007514
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x040000FC RID: 252
			private FixedString64Bytes target;

			// Token: 0x040000FD RID: 253
			private int offset;

			// Token: 0x040000FE RID: 254
			private Unicode.Rune current;
		}
	}
}
