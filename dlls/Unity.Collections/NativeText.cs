using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

namespace Unity.Collections
{
	// Token: 0x020000BF RID: 191
	[NativeContainer]
	[DebuggerDisplay("Length = {Length}")]
	[BurstCompatible]
	public struct NativeText : INativeList<byte>, IIndexable<byte>, INativeDisposable, IDisposable, IUTF8Bytes, IComparable<string>, IEquatable<string>, IComparable<NativeText>, IEquatable<NativeText>, IComparable<FixedString32Bytes>, IEquatable<FixedString32Bytes>, IComparable<FixedString64Bytes>, IEquatable<FixedString64Bytes>, IComparable<FixedString128Bytes>, IEquatable<FixedString128Bytes>, IComparable<FixedString512Bytes>, IEquatable<FixedString512Bytes>, IComparable<FixedString4096Bytes>, IEquatable<FixedString4096Bytes>
	{
		// Token: 0x0600078A RID: 1930 RVA: 0x00018370 File Offset: 0x00016570
		[NotBurstCompatible]
		public NativeText(string source, Allocator allocator)
		{
			this = new NativeText(source, allocator);
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x00018380 File Offset: 0x00016580
		[NotBurstCompatible]
		public unsafe NativeText(string source, AllocatorManager.AllocatorHandle allocator)
		{
			this = new NativeText(source.Length * 2, allocator);
			this.Length = source.Length * 2;
			fixed (string text = source)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				int length;
				if (UTF8ArrayUnsafeUtility.Copy(this.GetUnsafePtr(), out length, this.Capacity, ptr, source.Length) != CopyError.None)
				{
					this.m_Data->Dispose();
					void* data = ref allocator.Allocate(sizeof(UnsafeText), 16, 1);
					this.m_Data = (UnsafeText*)data;
					*this.m_Data = default(UnsafeText);
				}
				this.Length = length;
			}
		}

		// Token: 0x0600078C RID: 1932 RVA: 0x00018410 File Offset: 0x00016610
		private unsafe NativeText(int capacity, AllocatorManager.AllocatorHandle allocator, int disposeSentinelStackDepth)
		{
			this = default(NativeText);
			void* data = ref allocator.Allocate(sizeof(UnsafeText), 16, 1);
			this.m_Data = (UnsafeText*)data;
			*this.m_Data = new UnsafeText(capacity, allocator);
		}

		// Token: 0x0600078D RID: 1933 RVA: 0x0001844E File Offset: 0x0001664E
		public NativeText(int capacity, Allocator allocator)
		{
			this = new NativeText(capacity, allocator);
		}

		// Token: 0x0600078E RID: 1934 RVA: 0x0001845D File Offset: 0x0001665D
		public NativeText(int capacity, AllocatorManager.AllocatorHandle allocator)
		{
			this = new NativeText(capacity, allocator, 2);
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x00018468 File Offset: 0x00016668
		public NativeText(Allocator allocator)
		{
			this = new NativeText(allocator);
		}

		// Token: 0x06000790 RID: 1936 RVA: 0x00018476 File Offset: 0x00016676
		public NativeText(AllocatorManager.AllocatorHandle allocator)
		{
			this = new NativeText(512, allocator);
		}

		// Token: 0x06000791 RID: 1937 RVA: 0x00018484 File Offset: 0x00016684
		public unsafe NativeText(in FixedString32Bytes source, AllocatorManager.AllocatorHandle allocator)
		{
			this = new NativeText((int)source.utf8LengthInBytes, allocator);
			this.Length = (int)source.utf8LengthInBytes;
			byte* source2 = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes30>(source.bytes);
			UnsafeUtility.MemCpy((void*)this.m_Data->GetUnsafePtr(), (void*)source2, (long)((ulong)source.utf8LengthInBytes));
		}

		// Token: 0x06000792 RID: 1938 RVA: 0x000184CE File Offset: 0x000166CE
		public NativeText(in FixedString32Bytes source, Allocator allocator)
		{
			this = new NativeText(source, allocator);
		}

		// Token: 0x06000793 RID: 1939 RVA: 0x000184E0 File Offset: 0x000166E0
		public unsafe NativeText(in FixedString64Bytes source, AllocatorManager.AllocatorHandle allocator)
		{
			this = new NativeText((int)source.utf8LengthInBytes, allocator);
			this.Length = (int)source.utf8LengthInBytes;
			byte* source2 = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes62>(source.bytes);
			UnsafeUtility.MemCpy((void*)this.m_Data->GetUnsafePtr(), (void*)source2, (long)((ulong)source.utf8LengthInBytes));
		}

		// Token: 0x06000794 RID: 1940 RVA: 0x0001852A File Offset: 0x0001672A
		public NativeText(in FixedString64Bytes source, Allocator allocator)
		{
			this = new NativeText(source, allocator);
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x0001853C File Offset: 0x0001673C
		public unsafe NativeText(in FixedString128Bytes source, AllocatorManager.AllocatorHandle allocator)
		{
			this = new NativeText((int)source.utf8LengthInBytes, allocator);
			this.Length = (int)source.utf8LengthInBytes;
			byte* source2 = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes126>(source.bytes);
			UnsafeUtility.MemCpy((void*)this.m_Data->GetUnsafePtr(), (void*)source2, (long)((ulong)source.utf8LengthInBytes));
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x00018586 File Offset: 0x00016786
		public NativeText(in FixedString128Bytes source, Allocator allocator)
		{
			this = new NativeText(source, allocator);
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x00018598 File Offset: 0x00016798
		public unsafe NativeText(in FixedString512Bytes source, AllocatorManager.AllocatorHandle allocator)
		{
			this = new NativeText((int)source.utf8LengthInBytes, allocator);
			this.Length = (int)source.utf8LengthInBytes;
			byte* source2 = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes510>(source.bytes);
			UnsafeUtility.MemCpy((void*)this.m_Data->GetUnsafePtr(), (void*)source2, (long)((ulong)source.utf8LengthInBytes));
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x000185E2 File Offset: 0x000167E2
		public NativeText(in FixedString512Bytes source, Allocator allocator)
		{
			this = new NativeText(source, allocator);
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x000185F4 File Offset: 0x000167F4
		public unsafe NativeText(in FixedString4096Bytes source, AllocatorManager.AllocatorHandle allocator)
		{
			this = new NativeText((int)source.utf8LengthInBytes, allocator);
			this.Length = (int)source.utf8LengthInBytes;
			byte* source2 = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes4094>(source.bytes);
			UnsafeUtility.MemCpy((void*)this.m_Data->GetUnsafePtr(), (void*)source2, (long)((ulong)source.utf8LengthInBytes));
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x0001863E File Offset: 0x0001683E
		public NativeText(in FixedString4096Bytes source, Allocator allocator)
		{
			this = new NativeText(source, allocator);
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x0600079B RID: 1947 RVA: 0x0001864D File Offset: 0x0001684D
		// (set) Token: 0x0600079C RID: 1948 RVA: 0x0001865A File Offset: 0x0001685A
		public unsafe int Length
		{
			get
			{
				return this.m_Data->Length;
			}
			set
			{
				this.m_Data->Length = value;
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x0600079D RID: 1949 RVA: 0x00018668 File Offset: 0x00016868
		// (set) Token: 0x0600079E RID: 1950 RVA: 0x00018675 File Offset: 0x00016875
		public unsafe int Capacity
		{
			get
			{
				return this.m_Data->Capacity;
			}
			set
			{
				this.m_Data->Capacity = value;
			}
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x00018683 File Offset: 0x00016883
		public bool TryResize(int newLength, NativeArrayOptions clearOptions = NativeArrayOptions.ClearMemory)
		{
			this.Length = newLength;
			return true;
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x060007A0 RID: 1952 RVA: 0x0001868D File Offset: 0x0001688D
		public unsafe bool IsEmpty
		{
			get
			{
				return !this.IsCreated || this.m_Data->IsEmpty;
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x060007A1 RID: 1953 RVA: 0x000186A4 File Offset: 0x000168A4
		public bool IsCreated
		{
			get
			{
				return this.m_Data != null;
			}
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x000186B3 File Offset: 0x000168B3
		public unsafe byte* GetUnsafePtr()
		{
			return this.m_Data->GetUnsafePtr();
		}

		// Token: 0x170000D2 RID: 210
		public unsafe byte this[int index]
		{
			get
			{
				return *this.m_Data->ElementAt(index);
			}
			set
			{
				*this.m_Data->ElementAt(index) = value;
			}
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x000186DF File Offset: 0x000168DF
		public unsafe ref byte ElementAt(int index)
		{
			return this.m_Data->ElementAt(index);
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x000186ED File Offset: 0x000168ED
		public void Clear()
		{
			this.Length = 0;
		}

		// Token: 0x060007A7 RID: 1959 RVA: 0x000186F8 File Offset: 0x000168F8
		public void Add(in byte value)
		{
			int length = this.Length;
			this.Length = length + 1;
			this[length] = value;
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x0001871E File Offset: 0x0001691E
		public unsafe int CompareTo(NativeText other)
		{
			return ref this.CompareTo(*other.m_Data);
		}

		// Token: 0x060007A9 RID: 1961 RVA: 0x0001872C File Offset: 0x0001692C
		public unsafe bool Equals(NativeText other)
		{
			return ref this.Equals(*other.m_Data);
		}

		// Token: 0x060007AA RID: 1962 RVA: 0x0001873A File Offset: 0x0001693A
		public int CompareTo(NativeText.ReadOnly other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x060007AB RID: 1963 RVA: 0x00018744 File Offset: 0x00016944
		public unsafe bool Equals(NativeText.ReadOnly other)
		{
			return ref this.Equals(*other.m_Data);
		}

		// Token: 0x060007AC RID: 1964 RVA: 0x00018752 File Offset: 0x00016952
		public unsafe void Dispose()
		{
			AllocatorManager.AllocatorHandle allocator = this.m_Data->m_UntypedListData.Allocator;
			this.m_Data->Dispose();
			AllocatorManager.Free<UnsafeText>(allocator, this.m_Data, 1);
		}

		// Token: 0x060007AD RID: 1965 RVA: 0x0001877B File Offset: 0x0001697B
		[NotBurstCompatible]
		public unsafe JobHandle Dispose(JobHandle inputDeps)
		{
			return this.m_Data->Dispose(inputDeps);
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x060007AE RID: 1966 RVA: 0x00018789 File Offset: 0x00016989
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

		// Token: 0x060007AF RID: 1967 RVA: 0x00018797 File Offset: 0x00016997
		public NativeText.Enumerator GetEnumerator()
		{
			return new NativeText.Enumerator(this);
		}

		// Token: 0x060007B0 RID: 1968 RVA: 0x000187A4 File Offset: 0x000169A4
		[NotBurstCompatible]
		public int CompareTo(string other)
		{
			return this.ToString().CompareTo(other);
		}

		// Token: 0x060007B1 RID: 1969 RVA: 0x000187B8 File Offset: 0x000169B8
		[NotBurstCompatible]
		public bool Equals(string other)
		{
			return this.ToString().Equals(other);
		}

		// Token: 0x060007B2 RID: 1970 RVA: 0x000187CC File Offset: 0x000169CC
		public int CompareTo(FixedString32Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x060007B3 RID: 1971 RVA: 0x000187D8 File Offset: 0x000169D8
		public unsafe static bool operator ==(in NativeText a, in FixedString32Bytes b)
		{
			NativeText nativeText = *UnsafeUtilityExtensions.AsRef<NativeText>(a);
			int length = nativeText.Length;
			int utf8LengthInBytes = (int)b.utf8LengthInBytes;
			byte* unsafePtr = nativeText.GetUnsafePtr();
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes30>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(unsafePtr, length, bBytes, utf8LengthInBytes);
		}

		// Token: 0x060007B4 RID: 1972 RVA: 0x0001881B File Offset: 0x00016A1B
		public static bool operator !=(in NativeText a, in FixedString32Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x060007B5 RID: 1973 RVA: 0x00018827 File Offset: 0x00016A27
		public bool Equals(FixedString32Bytes other)
		{
			return this == other;
		}

		// Token: 0x060007B6 RID: 1974 RVA: 0x00018831 File Offset: 0x00016A31
		public int CompareTo(FixedString64Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x0001883C File Offset: 0x00016A3C
		public unsafe static bool operator ==(in NativeText a, in FixedString64Bytes b)
		{
			NativeText nativeText = *UnsafeUtilityExtensions.AsRef<NativeText>(a);
			int length = nativeText.Length;
			int utf8LengthInBytes = (int)b.utf8LengthInBytes;
			byte* unsafePtr = nativeText.GetUnsafePtr();
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes62>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(unsafePtr, length, bBytes, utf8LengthInBytes);
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x0001887F File Offset: 0x00016A7F
		public static bool operator !=(in NativeText a, in FixedString64Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x0001888B File Offset: 0x00016A8B
		public bool Equals(FixedString64Bytes other)
		{
			return this == other;
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x00018895 File Offset: 0x00016A95
		public int CompareTo(FixedString128Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x000188A0 File Offset: 0x00016AA0
		public unsafe static bool operator ==(in NativeText a, in FixedString128Bytes b)
		{
			NativeText nativeText = *UnsafeUtilityExtensions.AsRef<NativeText>(a);
			int length = nativeText.Length;
			int utf8LengthInBytes = (int)b.utf8LengthInBytes;
			byte* unsafePtr = nativeText.GetUnsafePtr();
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes126>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(unsafePtr, length, bBytes, utf8LengthInBytes);
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x000188E3 File Offset: 0x00016AE3
		public static bool operator !=(in NativeText a, in FixedString128Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x000188EF File Offset: 0x00016AEF
		public bool Equals(FixedString128Bytes other)
		{
			return this == other;
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x000188F9 File Offset: 0x00016AF9
		public int CompareTo(FixedString512Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x00018904 File Offset: 0x00016B04
		public unsafe static bool operator ==(in NativeText a, in FixedString512Bytes b)
		{
			NativeText nativeText = *UnsafeUtilityExtensions.AsRef<NativeText>(a);
			int length = nativeText.Length;
			int utf8LengthInBytes = (int)b.utf8LengthInBytes;
			byte* unsafePtr = nativeText.GetUnsafePtr();
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes510>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(unsafePtr, length, bBytes, utf8LengthInBytes);
		}

		// Token: 0x060007C0 RID: 1984 RVA: 0x00018947 File Offset: 0x00016B47
		public static bool operator !=(in NativeText a, in FixedString512Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x060007C1 RID: 1985 RVA: 0x00018953 File Offset: 0x00016B53
		public bool Equals(FixedString512Bytes other)
		{
			return this == other;
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x0001895D File Offset: 0x00016B5D
		public int CompareTo(FixedString4096Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x060007C3 RID: 1987 RVA: 0x00018968 File Offset: 0x00016B68
		public unsafe static bool operator ==(in NativeText a, in FixedString4096Bytes b)
		{
			NativeText nativeText = *UnsafeUtilityExtensions.AsRef<NativeText>(a);
			int length = nativeText.Length;
			int utf8LengthInBytes = (int)b.utf8LengthInBytes;
			byte* unsafePtr = nativeText.GetUnsafePtr();
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes4094>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(unsafePtr, length, bBytes, utf8LengthInBytes);
		}

		// Token: 0x060007C4 RID: 1988 RVA: 0x000189AB File Offset: 0x00016BAB
		public static bool operator !=(in NativeText a, in FixedString4096Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x000189B7 File Offset: 0x00016BB7
		public bool Equals(FixedString4096Bytes other)
		{
			return this == other;
		}

		// Token: 0x060007C6 RID: 1990 RVA: 0x000189C1 File Offset: 0x00016BC1
		[NotBurstCompatible]
		public override string ToString()
		{
			if (this.m_Data == null)
			{
				return "";
			}
			return ref this.ConvertToString<NativeText>();
		}

		// Token: 0x060007C7 RID: 1991 RVA: 0x000189D9 File Offset: 0x00016BD9
		public override int GetHashCode()
		{
			return ref this.ComputeHashCode<NativeText>();
		}

		// Token: 0x060007C8 RID: 1992 RVA: 0x000189E4 File Offset: 0x00016BE4
		[NotBurstCompatible]
		public override bool Equals(object other)
		{
			if (other == null)
			{
				return false;
			}
			string text = other as string;
			if (text != null)
			{
				return this.Equals(text);
			}
			if (other is NativeText)
			{
				NativeText other2 = (NativeText)other;
				return this.Equals(other2);
			}
			if (other is NativeText.ReadOnly)
			{
				NativeText.ReadOnly other3 = (NativeText.ReadOnly)other;
				return this.Equals(other3);
			}
			if (other is FixedString32Bytes)
			{
				FixedString32Bytes other4 = (FixedString32Bytes)other;
				return this.Equals(other4);
			}
			if (other is FixedString64Bytes)
			{
				FixedString64Bytes other5 = (FixedString64Bytes)other;
				return this.Equals(other5);
			}
			if (other is FixedString128Bytes)
			{
				FixedString128Bytes other6 = (FixedString128Bytes)other;
				return this.Equals(other6);
			}
			if (other is FixedString512Bytes)
			{
				FixedString512Bytes other7 = (FixedString512Bytes)other;
				return this.Equals(other7);
			}
			if (other is FixedString4096Bytes)
			{
				FixedString4096Bytes other8 = (FixedString4096Bytes)other;
				return this.Equals(other8);
			}
			return false;
		}

		// Token: 0x060007C9 RID: 1993 RVA: 0x00018AB2 File Offset: 0x00016CB2
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		internal unsafe static void CheckNull(void* dataPtr)
		{
			if (dataPtr == null)
			{
				throw new Exception("NativeText has yet to be created or has been destroyed!");
			}
		}

		// Token: 0x060007CA RID: 1994 RVA: 0x000024A3 File Offset: 0x000006A3
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckRead()
		{
		}

		// Token: 0x060007CB RID: 1995 RVA: 0x000024A3 File Offset: 0x000006A3
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckWrite()
		{
		}

		// Token: 0x060007CC RID: 1996 RVA: 0x000024A3 File Offset: 0x000006A3
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckWriteAndBumpSecondaryVersion()
		{
		}

		// Token: 0x060007CD RID: 1997 RVA: 0x00018AC4 File Offset: 0x00016CC4
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckIndexInRange(int index)
		{
			if (index < 0)
			{
				throw new IndexOutOfRangeException(string.Format("Index {0} must be positive.", index));
			}
			if (index >= this.Length)
			{
				throw new IndexOutOfRangeException(string.Format("Index {0} is out of range in NativeText of {1} length.", index, this.Length));
			}
		}

		// Token: 0x060007CE RID: 1998 RVA: 0x00018B15 File Offset: 0x00016D15
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void ThrowCopyError(CopyError error, string source)
		{
			throw new ArgumentException(string.Format("NativeText: {0} while copying \"{1}\"", error, source));
		}

		// Token: 0x060007CF RID: 1999 RVA: 0x00018B2D File Offset: 0x00016D2D
		public NativeText.ReadOnly AsReadOnly()
		{
			return new NativeText.ReadOnly(this.m_Data);
		}

		// Token: 0x040002BD RID: 701
		[NativeDisableUnsafePtrRestriction]
		private unsafe UnsafeText* m_Data;

		// Token: 0x020000C0 RID: 192
		public struct Enumerator : IEnumerator<Unicode.Rune>, IEnumerator, IDisposable
		{
			// Token: 0x060007D0 RID: 2000 RVA: 0x00018B3A File Offset: 0x00016D3A
			public Enumerator(NativeText source)
			{
				this.target = source.AsReadOnly();
				this.offset = 0;
				this.current = default(Unicode.Rune);
			}

			// Token: 0x060007D1 RID: 2001 RVA: 0x00018B5C File Offset: 0x00016D5C
			public Enumerator(NativeText.ReadOnly source)
			{
				this.target = source;
				this.offset = 0;
				this.current = default(Unicode.Rune);
			}

			// Token: 0x060007D2 RID: 2002 RVA: 0x000024A3 File Offset: 0x000006A3
			public void Dispose()
			{
			}

			// Token: 0x060007D3 RID: 2003 RVA: 0x00018B78 File Offset: 0x00016D78
			public bool MoveNext()
			{
				if (this.offset >= this.target.Length)
				{
					return false;
				}
				Unicode.Utf8ToUcs(out this.current, this.target.GetUnsafePtr(), ref this.offset, this.target.Length);
				return true;
			}

			// Token: 0x060007D4 RID: 2004 RVA: 0x00018BB8 File Offset: 0x00016DB8
			public void Reset()
			{
				this.offset = 0;
				this.current = default(Unicode.Rune);
			}

			// Token: 0x170000D4 RID: 212
			// (get) Token: 0x060007D5 RID: 2005 RVA: 0x00018BCD File Offset: 0x00016DCD
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x170000D5 RID: 213
			// (get) Token: 0x060007D6 RID: 2006 RVA: 0x00018BDA File Offset: 0x00016DDA
			public Unicode.Rune Current
			{
				get
				{
					return this.current;
				}
			}

			// Token: 0x040002BE RID: 702
			private NativeText.ReadOnly target;

			// Token: 0x040002BF RID: 703
			private int offset;

			// Token: 0x040002C0 RID: 704
			private Unicode.Rune current;
		}

		// Token: 0x020000C1 RID: 193
		[NativeContainer]
		[NativeContainerIsReadOnly]
		public struct ReadOnly : INativeList<byte>, IIndexable<byte>, IUTF8Bytes, IComparable<string>, IEquatable<string>, IComparable<NativeText>, IEquatable<NativeText>, IComparable<FixedString32Bytes>, IEquatable<FixedString32Bytes>, IComparable<FixedString64Bytes>, IEquatable<FixedString64Bytes>, IComparable<FixedString128Bytes>, IEquatable<FixedString128Bytes>, IComparable<FixedString512Bytes>, IEquatable<FixedString512Bytes>, IComparable<FixedString4096Bytes>, IEquatable<FixedString4096Bytes>
		{
			// Token: 0x060007D7 RID: 2007 RVA: 0x00018BE2 File Offset: 0x00016DE2
			internal unsafe ReadOnly(UnsafeText* text)
			{
				this.m_Data = text;
			}

			// Token: 0x170000D6 RID: 214
			// (get) Token: 0x060007D8 RID: 2008 RVA: 0x00018BEB File Offset: 0x00016DEB
			// (set) Token: 0x060007D9 RID: 2009 RVA: 0x000024A3 File Offset: 0x000006A3
			public unsafe int Capacity
			{
				get
				{
					return this.m_Data->Capacity;
				}
				set
				{
				}
			}

			// Token: 0x170000D7 RID: 215
			// (get) Token: 0x060007DA RID: 2010 RVA: 0x00018BF8 File Offset: 0x00016DF8
			// (set) Token: 0x060007DB RID: 2011 RVA: 0x000024A3 File Offset: 0x000006A3
			public unsafe bool IsEmpty
			{
				get
				{
					return this.m_Data == null || this.m_Data->IsEmpty;
				}
				set
				{
				}
			}

			// Token: 0x170000D8 RID: 216
			// (get) Token: 0x060007DC RID: 2012 RVA: 0x00018C11 File Offset: 0x00016E11
			// (set) Token: 0x060007DD RID: 2013 RVA: 0x000024A3 File Offset: 0x000006A3
			public unsafe int Length
			{
				get
				{
					return this.m_Data->Length;
				}
				set
				{
				}
			}

			// Token: 0x170000D9 RID: 217
			public unsafe byte this[int index]
			{
				get
				{
					return *this.m_Data->ElementAt(index);
				}
				set
				{
				}
			}

			// Token: 0x060007E0 RID: 2016 RVA: 0x000024A3 File Offset: 0x000006A3
			public void Clear()
			{
			}

			// Token: 0x060007E1 RID: 2017 RVA: 0x00018C2D File Offset: 0x00016E2D
			public ref byte ElementAt(int index)
			{
				throw new NotSupportedException("Trying to retrieve non-readonly ref to NativeText.ReadOnly data. This is not permitted.");
			}

			// Token: 0x060007E2 RID: 2018 RVA: 0x00018C39 File Offset: 0x00016E39
			public unsafe byte* GetUnsafePtr()
			{
				return this.m_Data->GetUnsafePtr();
			}

			// Token: 0x060007E3 RID: 2019 RVA: 0x00018C46 File Offset: 0x00016E46
			public bool TryResize(int newLength, NativeArrayOptions clearOptions = NativeArrayOptions.ClearMemory)
			{
				return false;
			}

			// Token: 0x060007E4 RID: 2020 RVA: 0x00018C49 File Offset: 0x00016E49
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			internal unsafe static void CheckNull(void* dataPtr)
			{
				if (dataPtr == null)
				{
					throw new Exception("NativeText.ReadOnly has yet to be created or has been destroyed!");
				}
			}

			// Token: 0x060007E5 RID: 2021 RVA: 0x000024A3 File Offset: 0x000006A3
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			private void CheckRead()
			{
			}

			// Token: 0x060007E6 RID: 2022 RVA: 0x000024A3 File Offset: 0x000006A3
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			private void ErrorWrite()
			{
			}

			// Token: 0x060007E7 RID: 2023 RVA: 0x00018C5B File Offset: 0x00016E5B
			[NotBurstCompatible]
			public unsafe int CompareTo(string other)
			{
				return this.m_Data->ToString().CompareTo(other);
			}

			// Token: 0x060007E8 RID: 2024 RVA: 0x00018C74 File Offset: 0x00016E74
			[NotBurstCompatible]
			public unsafe bool Equals(string other)
			{
				return this.m_Data->ToString().Equals(other);
			}

			// Token: 0x060007E9 RID: 2025 RVA: 0x00018C8D File Offset: 0x00016E8D
			public unsafe int CompareTo(NativeText.ReadOnly other)
			{
				return ref *this.m_Data.CompareTo(*other.m_Data);
			}

			// Token: 0x060007EA RID: 2026 RVA: 0x00018CA0 File Offset: 0x00016EA0
			public unsafe bool Equals(NativeText.ReadOnly other)
			{
				return ref *this.m_Data.Equals(*other.m_Data);
			}

			// Token: 0x060007EB RID: 2027 RVA: 0x00018CB3 File Offset: 0x00016EB3
			public unsafe int CompareTo(NativeText other)
			{
				return ref this.CompareTo(*other.m_Data);
			}

			// Token: 0x060007EC RID: 2028 RVA: 0x00018CC1 File Offset: 0x00016EC1
			public unsafe bool Equals(NativeText other)
			{
				return ref this.Equals(*other.m_Data);
			}

			// Token: 0x060007ED RID: 2029 RVA: 0x00018CCF File Offset: 0x00016ECF
			public int CompareTo(FixedString32Bytes other)
			{
				return ref this.CompareTo(other);
			}

			// Token: 0x060007EE RID: 2030 RVA: 0x00018CDC File Offset: 0x00016EDC
			public unsafe static bool operator ==(in NativeText.ReadOnly a, in FixedString32Bytes b)
			{
				UnsafeText unsafeText = *a.m_Data;
				int length = unsafeText.Length;
				int utf8LengthInBytes = (int)b.utf8LengthInBytes;
				byte* unsafePtr = unsafeText.GetUnsafePtr();
				byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes30>(b.bytes);
				return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(unsafePtr, length, bBytes, utf8LengthInBytes);
			}

			// Token: 0x060007EF RID: 2031 RVA: 0x00018D1F File Offset: 0x00016F1F
			public static bool operator !=(in NativeText.ReadOnly a, in FixedString32Bytes b)
			{
				return !(a == b);
			}

			// Token: 0x060007F0 RID: 2032 RVA: 0x00018D2B File Offset: 0x00016F2B
			public bool Equals(FixedString32Bytes other)
			{
				return this == other;
			}

			// Token: 0x060007F1 RID: 2033 RVA: 0x00018D35 File Offset: 0x00016F35
			public int CompareTo(FixedString64Bytes other)
			{
				return ref this.CompareTo(other);
			}

			// Token: 0x060007F2 RID: 2034 RVA: 0x00018D40 File Offset: 0x00016F40
			public unsafe static bool operator ==(in NativeText.ReadOnly a, in FixedString64Bytes b)
			{
				UnsafeText unsafeText = *a.m_Data;
				int length = unsafeText.Length;
				int utf8LengthInBytes = (int)b.utf8LengthInBytes;
				byte* unsafePtr = unsafeText.GetUnsafePtr();
				byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes62>(b.bytes);
				return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(unsafePtr, length, bBytes, utf8LengthInBytes);
			}

			// Token: 0x060007F3 RID: 2035 RVA: 0x00018D83 File Offset: 0x00016F83
			public static bool operator !=(in NativeText.ReadOnly a, in FixedString64Bytes b)
			{
				return !(a == b);
			}

			// Token: 0x060007F4 RID: 2036 RVA: 0x00018D8F File Offset: 0x00016F8F
			public bool Equals(FixedString64Bytes other)
			{
				return this == other;
			}

			// Token: 0x060007F5 RID: 2037 RVA: 0x00018D99 File Offset: 0x00016F99
			public int CompareTo(FixedString128Bytes other)
			{
				return ref this.CompareTo(other);
			}

			// Token: 0x060007F6 RID: 2038 RVA: 0x00018DA4 File Offset: 0x00016FA4
			public unsafe static bool operator ==(in NativeText.ReadOnly a, in FixedString128Bytes b)
			{
				UnsafeText unsafeText = *a.m_Data;
				int length = unsafeText.Length;
				int utf8LengthInBytes = (int)b.utf8LengthInBytes;
				byte* unsafePtr = unsafeText.GetUnsafePtr();
				byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes126>(b.bytes);
				return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(unsafePtr, length, bBytes, utf8LengthInBytes);
			}

			// Token: 0x060007F7 RID: 2039 RVA: 0x00018DE7 File Offset: 0x00016FE7
			public static bool operator !=(in NativeText.ReadOnly a, in FixedString128Bytes b)
			{
				return !(a == b);
			}

			// Token: 0x060007F8 RID: 2040 RVA: 0x00018DF3 File Offset: 0x00016FF3
			public bool Equals(FixedString128Bytes other)
			{
				return this == other;
			}

			// Token: 0x060007F9 RID: 2041 RVA: 0x00018DFD File Offset: 0x00016FFD
			public int CompareTo(FixedString512Bytes other)
			{
				return ref this.CompareTo(other);
			}

			// Token: 0x060007FA RID: 2042 RVA: 0x00018E08 File Offset: 0x00017008
			public unsafe static bool operator ==(in NativeText.ReadOnly a, in FixedString512Bytes b)
			{
				UnsafeText unsafeText = *a.m_Data;
				int length = unsafeText.Length;
				int utf8LengthInBytes = (int)b.utf8LengthInBytes;
				byte* unsafePtr = unsafeText.GetUnsafePtr();
				byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes510>(b.bytes);
				return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(unsafePtr, length, bBytes, utf8LengthInBytes);
			}

			// Token: 0x060007FB RID: 2043 RVA: 0x00018E4B File Offset: 0x0001704B
			public static bool operator !=(in NativeText.ReadOnly a, in FixedString512Bytes b)
			{
				return !(a == b);
			}

			// Token: 0x060007FC RID: 2044 RVA: 0x00018E57 File Offset: 0x00017057
			public bool Equals(FixedString512Bytes other)
			{
				return this == other;
			}

			// Token: 0x060007FD RID: 2045 RVA: 0x00018E61 File Offset: 0x00017061
			public int CompareTo(FixedString4096Bytes other)
			{
				return ref this.CompareTo(other);
			}

			// Token: 0x060007FE RID: 2046 RVA: 0x00018E6C File Offset: 0x0001706C
			public unsafe static bool operator ==(in NativeText.ReadOnly a, in FixedString4096Bytes b)
			{
				UnsafeText unsafeText = *a.m_Data;
				int length = unsafeText.Length;
				int utf8LengthInBytes = (int)b.utf8LengthInBytes;
				byte* unsafePtr = unsafeText.GetUnsafePtr();
				byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes4094>(b.bytes);
				return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(unsafePtr, length, bBytes, utf8LengthInBytes);
			}

			// Token: 0x060007FF RID: 2047 RVA: 0x00018EAF File Offset: 0x000170AF
			public static bool operator !=(in NativeText.ReadOnly a, in FixedString4096Bytes b)
			{
				return !(a == b);
			}

			// Token: 0x06000800 RID: 2048 RVA: 0x00018EBB File Offset: 0x000170BB
			public bool Equals(FixedString4096Bytes other)
			{
				return this == other;
			}

			// Token: 0x06000801 RID: 2049 RVA: 0x00018EC5 File Offset: 0x000170C5
			[NotBurstCompatible]
			public override string ToString()
			{
				if (this.m_Data == null)
				{
					return "";
				}
				return ref this.ConvertToString<NativeText.ReadOnly>();
			}

			// Token: 0x06000802 RID: 2050 RVA: 0x00018EDD File Offset: 0x000170DD
			public override int GetHashCode()
			{
				return ref this.ComputeHashCode<NativeText.ReadOnly>();
			}

			// Token: 0x06000803 RID: 2051 RVA: 0x00018EE8 File Offset: 0x000170E8
			[NotBurstCompatible]
			public override bool Equals(object other)
			{
				if (other == null)
				{
					return false;
				}
				string text = other as string;
				if (text != null)
				{
					return this.Equals(text);
				}
				if (other is NativeText)
				{
					NativeText other2 = (NativeText)other;
					return this.Equals(other2);
				}
				if (other is NativeText.ReadOnly)
				{
					NativeText.ReadOnly other3 = (NativeText.ReadOnly)other;
					return this.Equals(other3);
				}
				if (other is FixedString32Bytes)
				{
					FixedString32Bytes other4 = (FixedString32Bytes)other;
					return this.Equals(other4);
				}
				if (other is FixedString64Bytes)
				{
					FixedString64Bytes other5 = (FixedString64Bytes)other;
					return this.Equals(other5);
				}
				if (other is FixedString128Bytes)
				{
					FixedString128Bytes other6 = (FixedString128Bytes)other;
					return this.Equals(other6);
				}
				if (other is FixedString512Bytes)
				{
					FixedString512Bytes other7 = (FixedString512Bytes)other;
					return this.Equals(other7);
				}
				if (other is FixedString4096Bytes)
				{
					FixedString4096Bytes other8 = (FixedString4096Bytes)other;
					return this.Equals(other8);
				}
				return false;
			}

			// Token: 0x170000DA RID: 218
			// (get) Token: 0x06000804 RID: 2052 RVA: 0x00018FB6 File Offset: 0x000171B6
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

			// Token: 0x06000805 RID: 2053 RVA: 0x00018FC4 File Offset: 0x000171C4
			public NativeText.Enumerator GetEnumerator()
			{
				return new NativeText.Enumerator(this);
			}

			// Token: 0x040002C1 RID: 705
			[NativeDisableUnsafePtrRestriction]
			internal unsafe UnsafeText* m_Data;
		}
	}
}
