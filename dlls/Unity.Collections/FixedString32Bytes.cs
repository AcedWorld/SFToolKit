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
	// Token: 0x0200006D RID: 109
	[BurstCompatible]
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Size = 32)]
	public struct FixedString32Bytes : INativeList<byte>, IIndexable<byte>, IUTF8Bytes, IComparable<string>, IEquatable<string>, IComparable<FixedString32Bytes>, IEquatable<FixedString32Bytes>, IComparable<FixedString64Bytes>, IEquatable<FixedString64Bytes>, IComparable<FixedString128Bytes>, IEquatable<FixedString128Bytes>, IComparable<FixedString512Bytes>, IEquatable<FixedString512Bytes>, IComparable<FixedString4096Bytes>, IEquatable<FixedString4096Bytes>
	{
		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060002AE RID: 686 RVA: 0x000082D9 File Offset: 0x000064D9
		public static int UTF8MaxLengthInBytes
		{
			get
			{
				return 29;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060002AF RID: 687 RVA: 0x000082DD File Offset: 0x000064DD
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

		// Token: 0x060002B0 RID: 688 RVA: 0x000082EB File Offset: 0x000064EB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe byte* GetUnsafePtr()
		{
			return (byte*)UnsafeUtility.AddressOf<FixedBytes30>(ref this.bytes);
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060002B1 RID: 689 RVA: 0x000082F8 File Offset: 0x000064F8
		// (set) Token: 0x060002B2 RID: 690 RVA: 0x00008300 File Offset: 0x00006500
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

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060002B3 RID: 691 RVA: 0x000082D9 File Offset: 0x000064D9
		// (set) Token: 0x060002B4 RID: 692 RVA: 0x000024A3 File Offset: 0x000006A3
		public int Capacity
		{
			get
			{
				return 29;
			}
			set
			{
			}
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0000831C File Offset: 0x0000651C
		public unsafe bool TryResize(int newLength, NativeArrayOptions clearOptions = NativeArrayOptions.ClearMemory)
		{
			if (newLength < 0 || newLength > 29)
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

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060002B6 RID: 694 RVA: 0x00008397 File Offset: 0x00006597
		public bool IsEmpty
		{
			get
			{
				return this.utf8LengthInBytes == 0;
			}
		}

		// Token: 0x1700006E RID: 110
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

		// Token: 0x060002B9 RID: 697 RVA: 0x000083B9 File Offset: 0x000065B9
		public unsafe ref byte ElementAt(int index)
		{
			return ref this.GetUnsafePtr()[index];
		}

		// Token: 0x060002BA RID: 698 RVA: 0x000083C3 File Offset: 0x000065C3
		public void Clear()
		{
			this.Length = 0;
		}

		// Token: 0x060002BB RID: 699 RVA: 0x000083CC File Offset: 0x000065CC
		public void Add(in byte value)
		{
			int length = this.Length;
			this.Length = length + 1;
			this[length] = value;
		}

		// Token: 0x060002BC RID: 700 RVA: 0x000083F2 File Offset: 0x000065F2
		public FixedString32Bytes.Enumerator GetEnumerator()
		{
			return new FixedString32Bytes.Enumerator(this);
		}

		// Token: 0x060002BD RID: 701 RVA: 0x000083FF File Offset: 0x000065FF
		[NotBurstCompatible]
		public int CompareTo(string other)
		{
			return this.ToString().CompareTo(other);
		}

		// Token: 0x060002BE RID: 702 RVA: 0x00008414 File Offset: 0x00006614
		[NotBurstCompatible]
		public unsafe bool Equals(string other)
		{
			int num = (int)this.utf8LengthInBytes;
			int length = other.Length;
			byte* utf8Buffer = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes30>(this.bytes);
			char* ptr = other;
			if (ptr != null)
			{
				ptr += RuntimeHelpers.OffsetToStringData / 2;
			}
			return UTF8ArrayUnsafeUtility.StrCmp(utf8Buffer, num, ptr, length) == 0;
		}

		// Token: 0x060002BF RID: 703 RVA: 0x00008459 File Offset: 0x00006659
		public ref FixedList32Bytes<byte> AsFixedList()
		{
			return UnsafeUtility.AsRef<FixedList32Bytes<byte>>(UnsafeUtility.AddressOf<FixedString32Bytes>(ref this));
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x00008466 File Offset: 0x00006666
		[NotBurstCompatible]
		public FixedString32Bytes(string source)
		{
			this = default(FixedString32Bytes);
			this.Initialize(source);
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x00008478 File Offset: 0x00006678
		[NotBurstCompatible]
		internal unsafe int Initialize(string source)
		{
			this.bytes = default(FixedBytes30);
			this.utf8LengthInBytes = 0;
			fixed (string text = source)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				CopyError copyError = UTF8ArrayUnsafeUtility.Copy(this.GetUnsafePtr(), out this.utf8LengthInBytes, 29, ptr, source.Length);
				if (copyError != CopyError.None)
				{
					return (int)copyError;
				}
				this.Length = (int)this.utf8LengthInBytes;
			}
			return 0;
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x000084D7 File Offset: 0x000066D7
		public FixedString32Bytes(Unicode.Rune rune, int count = 1)
		{
			this = default(FixedString32Bytes);
			this.Initialize(rune, count);
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x000084E9 File Offset: 0x000066E9
		internal int Initialize(Unicode.Rune rune, int count = 1)
		{
			this = default(FixedString32Bytes);
			return (int)ref this.Append(rune, count);
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x000084FA File Offset: 0x000066FA
		public int CompareTo(FixedString32Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x00008504 File Offset: 0x00006704
		public FixedString32Bytes(in FixedString32Bytes other)
		{
			this = default(FixedString32Bytes);
			this.Initialize(other);
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x00008518 File Offset: 0x00006718
		internal unsafe int Initialize(in FixedString32Bytes other)
		{
			this.bytes = default(FixedBytes30);
			this.utf8LengthInBytes = 0;
			int length = 0;
			byte* unsafePtr = this.GetUnsafePtr();
			byte* src = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes30>(other.bytes);
			ushort srcLength = other.utf8LengthInBytes;
			FormatError formatError = UTF8ArrayUnsafeUtility.AppendUTF8Bytes(unsafePtr, ref length, 29, src, (int)srcLength);
			if (formatError != FormatError.None)
			{
				return (int)formatError;
			}
			this.Length = length;
			return 0;
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x0000856C File Offset: 0x0000676C
		public unsafe static bool operator ==(in FixedString32Bytes a, in FixedString32Bytes b)
		{
			int aLength = (int)a.utf8LengthInBytes;
			int bLength = (int)b.utf8LengthInBytes;
			byte* aBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes30>(a.bytes);
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes30>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(aBytes, aLength, bBytes, bLength);
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x000085A8 File Offset: 0x000067A8
		public static bool operator !=(in FixedString32Bytes a, in FixedString32Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x000085B4 File Offset: 0x000067B4
		public bool Equals(FixedString32Bytes other)
		{
			return this == other;
		}

		// Token: 0x060002CA RID: 714 RVA: 0x000085BE File Offset: 0x000067BE
		public int CompareTo(FixedString64Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x060002CB RID: 715 RVA: 0x000085C8 File Offset: 0x000067C8
		public FixedString32Bytes(in FixedString64Bytes other)
		{
			this = default(FixedString32Bytes);
			this.Initialize(other);
		}

		// Token: 0x060002CC RID: 716 RVA: 0x000085DC File Offset: 0x000067DC
		internal unsafe int Initialize(in FixedString64Bytes other)
		{
			this.bytes = default(FixedBytes30);
			this.utf8LengthInBytes = 0;
			int length = 0;
			byte* unsafePtr = this.GetUnsafePtr();
			byte* src = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes62>(other.bytes);
			ushort srcLength = other.utf8LengthInBytes;
			FormatError formatError = UTF8ArrayUnsafeUtility.AppendUTF8Bytes(unsafePtr, ref length, 29, src, (int)srcLength);
			if (formatError != FormatError.None)
			{
				return (int)formatError;
			}
			this.Length = length;
			return 0;
		}

		// Token: 0x060002CD RID: 717 RVA: 0x00008630 File Offset: 0x00006830
		public unsafe static bool operator ==(in FixedString32Bytes a, in FixedString64Bytes b)
		{
			int aLength = (int)a.utf8LengthInBytes;
			int bLength = (int)b.utf8LengthInBytes;
			byte* aBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes30>(a.bytes);
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes62>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(aBytes, aLength, bBytes, bLength);
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0000866C File Offset: 0x0000686C
		public static bool operator !=(in FixedString32Bytes a, in FixedString64Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x060002CF RID: 719 RVA: 0x00008678 File Offset: 0x00006878
		public bool Equals(FixedString64Bytes other)
		{
			return this == other;
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x00008682 File Offset: 0x00006882
		public static implicit operator FixedString64Bytes(in FixedString32Bytes fs)
		{
			return new FixedString64Bytes(ref fs);
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0000868A File Offset: 0x0000688A
		public int CompareTo(FixedString128Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x00008694 File Offset: 0x00006894
		public FixedString32Bytes(in FixedString128Bytes other)
		{
			this = default(FixedString32Bytes);
			this.Initialize(other);
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x000086A8 File Offset: 0x000068A8
		internal unsafe int Initialize(in FixedString128Bytes other)
		{
			this.bytes = default(FixedBytes30);
			this.utf8LengthInBytes = 0;
			int length = 0;
			byte* unsafePtr = this.GetUnsafePtr();
			byte* src = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes126>(other.bytes);
			ushort srcLength = other.utf8LengthInBytes;
			FormatError formatError = UTF8ArrayUnsafeUtility.AppendUTF8Bytes(unsafePtr, ref length, 29, src, (int)srcLength);
			if (formatError != FormatError.None)
			{
				return (int)formatError;
			}
			this.Length = length;
			return 0;
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x000086FC File Offset: 0x000068FC
		public unsafe static bool operator ==(in FixedString32Bytes a, in FixedString128Bytes b)
		{
			int aLength = (int)a.utf8LengthInBytes;
			int bLength = (int)b.utf8LengthInBytes;
			byte* aBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes30>(a.bytes);
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes126>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(aBytes, aLength, bBytes, bLength);
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x00008738 File Offset: 0x00006938
		public static bool operator !=(in FixedString32Bytes a, in FixedString128Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x00008744 File Offset: 0x00006944
		public bool Equals(FixedString128Bytes other)
		{
			return this == other;
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x0000874E File Offset: 0x0000694E
		public static implicit operator FixedString128Bytes(in FixedString32Bytes fs)
		{
			return new FixedString128Bytes(ref fs);
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x00008756 File Offset: 0x00006956
		public int CompareTo(FixedString512Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x00008760 File Offset: 0x00006960
		public FixedString32Bytes(in FixedString512Bytes other)
		{
			this = default(FixedString32Bytes);
			this.Initialize(other);
		}

		// Token: 0x060002DA RID: 730 RVA: 0x00008774 File Offset: 0x00006974
		internal unsafe int Initialize(in FixedString512Bytes other)
		{
			this.bytes = default(FixedBytes30);
			this.utf8LengthInBytes = 0;
			int length = 0;
			byte* unsafePtr = this.GetUnsafePtr();
			byte* src = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes510>(other.bytes);
			ushort srcLength = other.utf8LengthInBytes;
			FormatError formatError = UTF8ArrayUnsafeUtility.AppendUTF8Bytes(unsafePtr, ref length, 29, src, (int)srcLength);
			if (formatError != FormatError.None)
			{
				return (int)formatError;
			}
			this.Length = length;
			return 0;
		}

		// Token: 0x060002DB RID: 731 RVA: 0x000087C8 File Offset: 0x000069C8
		public unsafe static bool operator ==(in FixedString32Bytes a, in FixedString512Bytes b)
		{
			int aLength = (int)a.utf8LengthInBytes;
			int bLength = (int)b.utf8LengthInBytes;
			byte* aBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes30>(a.bytes);
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes510>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(aBytes, aLength, bBytes, bLength);
		}

		// Token: 0x060002DC RID: 732 RVA: 0x00008804 File Offset: 0x00006A04
		public static bool operator !=(in FixedString32Bytes a, in FixedString512Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x060002DD RID: 733 RVA: 0x00008810 File Offset: 0x00006A10
		public bool Equals(FixedString512Bytes other)
		{
			return this == other;
		}

		// Token: 0x060002DE RID: 734 RVA: 0x0000881A File Offset: 0x00006A1A
		public static implicit operator FixedString512Bytes(in FixedString32Bytes fs)
		{
			return new FixedString512Bytes(ref fs);
		}

		// Token: 0x060002DF RID: 735 RVA: 0x00008822 File Offset: 0x00006A22
		public int CompareTo(FixedString4096Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x0000882C File Offset: 0x00006A2C
		public FixedString32Bytes(in FixedString4096Bytes other)
		{
			this = default(FixedString32Bytes);
			this.Initialize(other);
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x00008840 File Offset: 0x00006A40
		internal unsafe int Initialize(in FixedString4096Bytes other)
		{
			this.bytes = default(FixedBytes30);
			this.utf8LengthInBytes = 0;
			int length = 0;
			byte* unsafePtr = this.GetUnsafePtr();
			byte* src = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes4094>(other.bytes);
			ushort srcLength = other.utf8LengthInBytes;
			FormatError formatError = UTF8ArrayUnsafeUtility.AppendUTF8Bytes(unsafePtr, ref length, 29, src, (int)srcLength);
			if (formatError != FormatError.None)
			{
				return (int)formatError;
			}
			this.Length = length;
			return 0;
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x00008894 File Offset: 0x00006A94
		public unsafe static bool operator ==(in FixedString32Bytes a, in FixedString4096Bytes b)
		{
			int aLength = (int)a.utf8LengthInBytes;
			int bLength = (int)b.utf8LengthInBytes;
			byte* aBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes30>(a.bytes);
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes4094>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(aBytes, aLength, bBytes, bLength);
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x000088D0 File Offset: 0x00006AD0
		public static bool operator !=(in FixedString32Bytes a, in FixedString4096Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x000088DC File Offset: 0x00006ADC
		public bool Equals(FixedString4096Bytes other)
		{
			return this == other;
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x000088E6 File Offset: 0x00006AE6
		public static implicit operator FixedString4096Bytes(in FixedString32Bytes fs)
		{
			return new FixedString4096Bytes(ref fs);
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x000088EE File Offset: 0x00006AEE
		[NotBurstCompatible]
		public static implicit operator FixedString32Bytes(string b)
		{
			return new FixedString32Bytes(b);
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x000088F6 File Offset: 0x00006AF6
		[NotBurstCompatible]
		public override string ToString()
		{
			return ref this.ConvertToString<FixedString32Bytes>();
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x000088FE File Offset: 0x00006AFE
		public override int GetHashCode()
		{
			return ref this.ComputeHashCode<FixedString32Bytes>();
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x00008908 File Offset: 0x00006B08
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

		// Token: 0x060002EA RID: 746 RVA: 0x000089A4 File Offset: 0x00006BA4
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckIndexInRange(int index)
		{
			if (index < 0)
			{
				throw new IndexOutOfRangeException(string.Format("Index {0} must be positive.", index));
			}
			if (index >= (int)this.utf8LengthInBytes)
			{
				throw new IndexOutOfRangeException(string.Format("Index {0} is out of range in FixedString32Bytes of '{1}' Length.", index, this.utf8LengthInBytes));
			}
		}

		// Token: 0x060002EB RID: 747 RVA: 0x000089F5 File Offset: 0x00006BF5
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckLengthInRange(int length)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException(string.Format("Length {0} must be positive.", length));
			}
			if (length > 29)
			{
				throw new ArgumentOutOfRangeException(string.Format("Length {0} is out of range in FixedString32Bytes of '{1}' Capacity.", length, 29));
			}
		}

		// Token: 0x060002EC RID: 748 RVA: 0x00008A33 File Offset: 0x00006C33
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckCapacityInRange(int capacity)
		{
			if (capacity > 29)
			{
				throw new ArgumentOutOfRangeException(string.Format("Capacity {0} must be lower than {1}.", capacity, 29));
			}
		}

		// Token: 0x060002ED RID: 749 RVA: 0x00008A57 File Offset: 0x00006C57
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckCopyError(CopyError error, string source)
		{
			if (error != CopyError.None)
			{
				throw new ArgumentException(string.Format("FixedString32Bytes: {0} while copying \"{1}\"", error, source));
			}
		}

		// Token: 0x060002EE RID: 750 RVA: 0x00008A73 File Offset: 0x00006C73
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckFormatError(FormatError error)
		{
			if (error != FormatError.None)
			{
				throw new ArgumentException("Source is too long to fit into fixed string of this size");
			}
		}

		// Token: 0x040000E2 RID: 226
		internal const ushort utf8MaxLengthInBytes = 29;

		// Token: 0x040000E3 RID: 227
		[SerializeField]
		internal ushort utf8LengthInBytes;

		// Token: 0x040000E4 RID: 228
		[SerializeField]
		internal FixedBytes30 bytes;

		// Token: 0x0200006E RID: 110
		public struct Enumerator : IEnumerator
		{
			// Token: 0x060002EF RID: 751 RVA: 0x00008A83 File Offset: 0x00006C83
			public Enumerator(FixedString32Bytes other)
			{
				this.target = other;
				this.offset = 0;
				this.current = default(Unicode.Rune);
			}

			// Token: 0x060002F0 RID: 752 RVA: 0x000024A3 File Offset: 0x000006A3
			public void Dispose()
			{
			}

			// Token: 0x060002F1 RID: 753 RVA: 0x00008A9F File Offset: 0x00006C9F
			public bool MoveNext()
			{
				if (this.offset >= this.target.Length)
				{
					return false;
				}
				Unicode.Utf8ToUcs(out this.current, this.target.GetUnsafePtr(), ref this.offset, this.target.Length);
				return true;
			}

			// Token: 0x060002F2 RID: 754 RVA: 0x00008ADF File Offset: 0x00006CDF
			public void Reset()
			{
				this.offset = 0;
				this.current = default(Unicode.Rune);
			}

			// Token: 0x1700006F RID: 111
			// (get) Token: 0x060002F3 RID: 755 RVA: 0x00008AF4 File Offset: 0x00006CF4
			public Unicode.Rune Current
			{
				get
				{
					return this.current;
				}
			}

			// Token: 0x17000070 RID: 112
			// (get) Token: 0x060002F4 RID: 756 RVA: 0x00008AFC File Offset: 0x00006CFC
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x040000E5 RID: 229
			private FixedString32Bytes target;

			// Token: 0x040000E6 RID: 230
			private int offset;

			// Token: 0x040000E7 RID: 231
			private Unicode.Rune current;
		}
	}
}
