using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Collections
{
	// Token: 0x02000084 RID: 132
	[BurstCompatible]
	[Obsolete("HeapString has been removed and replaced with NativeText (RemovedAfter 2021-07-21) (UnityUpgradable) -> NativeText", false)]
	public struct HeapString : INativeList<byte>, IIndexable<byte>, IDisposable, IUTF8Bytes, IComparable<string>, IEquatable<string>, IComparable<HeapString>, IEquatable<HeapString>, IComparable<FixedString32Bytes>, IEquatable<FixedString32Bytes>, IComparable<FixedString64Bytes>, IEquatable<FixedString64Bytes>, IComparable<FixedString128Bytes>, IEquatable<FixedString128Bytes>, IComparable<FixedString512Bytes>, IEquatable<FixedString512Bytes>, IComparable<FixedString4096Bytes>, IEquatable<FixedString4096Bytes>
	{
		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000596 RID: 1430 RVA: 0x00013D45 File Offset: 0x00011F45
		// (set) Token: 0x06000597 RID: 1431 RVA: 0x00013D54 File Offset: 0x00011F54
		public int Length
		{
			get
			{
				return this.m_Data.Length - 1;
			}
			set
			{
				this.m_Data.Resize(value + 1, NativeArrayOptions.UninitializedMemory);
				this.m_Data[value] = 0;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000598 RID: 1432 RVA: 0x00013D72 File Offset: 0x00011F72
		// (set) Token: 0x06000599 RID: 1433 RVA: 0x00013D81 File Offset: 0x00011F81
		public int Capacity
		{
			get
			{
				return this.m_Data.Capacity - 1;
			}
			set
			{
				this.m_Data.Capacity = value + 1;
			}
		}

		// Token: 0x0600059A RID: 1434 RVA: 0x00013D91 File Offset: 0x00011F91
		public bool TryResize(int newLength, NativeArrayOptions clearOptions = NativeArrayOptions.ClearMemory)
		{
			this.Length = newLength;
			return true;
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x0600059B RID: 1435 RVA: 0x00013D9B File Offset: 0x00011F9B
		public bool IsEmpty
		{
			get
			{
				return this.m_Data.Length == 1;
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x0600059C RID: 1436 RVA: 0x00013DAB File Offset: 0x00011FAB
		public bool IsCreated
		{
			get
			{
				return this.m_Data.IsCreated;
			}
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x00013DB8 File Offset: 0x00011FB8
		public unsafe byte* GetUnsafePtr()
		{
			return (byte*)this.m_Data.GetUnsafePtr<byte>();
		}

		// Token: 0x17000096 RID: 150
		public byte this[int index]
		{
			get
			{
				return this.m_Data[index];
			}
			set
			{
				this.m_Data[index] = value;
			}
		}

		// Token: 0x060005A0 RID: 1440 RVA: 0x00013DE2 File Offset: 0x00011FE2
		public ref byte ElementAt(int index)
		{
			return this.m_Data.ElementAt(index);
		}

		// Token: 0x060005A1 RID: 1441 RVA: 0x00013DF0 File Offset: 0x00011FF0
		public void Clear()
		{
			this.Length = 0;
		}

		// Token: 0x060005A2 RID: 1442 RVA: 0x00013DFC File Offset: 0x00011FFC
		public void Add(in byte value)
		{
			int length = this.Length;
			this.Length = length + 1;
			this[length] = value;
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x00013E22 File Offset: 0x00012022
		public int CompareTo(HeapString other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x00013E2C File Offset: 0x0001202C
		public bool Equals(HeapString other)
		{
			return ref this.Equals(other);
		}

		// Token: 0x060005A5 RID: 1445 RVA: 0x00013E36 File Offset: 0x00012036
		public void Dispose()
		{
			this.m_Data.Dispose();
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060005A6 RID: 1446 RVA: 0x00013E43 File Offset: 0x00012043
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

		// Token: 0x060005A7 RID: 1447 RVA: 0x00013E51 File Offset: 0x00012051
		public HeapString.Enumerator GetEnumerator()
		{
			return new HeapString.Enumerator(this);
		}

		// Token: 0x060005A8 RID: 1448 RVA: 0x00013E5E File Offset: 0x0001205E
		[NotBurstCompatible]
		public int CompareTo(string other)
		{
			return this.ToString().CompareTo(other);
		}

		// Token: 0x060005A9 RID: 1449 RVA: 0x00013E72 File Offset: 0x00012072
		[NotBurstCompatible]
		public bool Equals(string other)
		{
			return this.ToString().Equals(other);
		}

		// Token: 0x060005AA RID: 1450 RVA: 0x00013E88 File Offset: 0x00012088
		[NotBurstCompatible]
		public unsafe HeapString(string source, Allocator allocator)
		{
			this.m_Data = new NativeList<byte>(source.Length * 2 + 1, allocator);
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
					this.m_Data.Dispose();
					this.m_Data = default(NativeList<byte>);
				}
				this.Length = length;
			}
		}

		// Token: 0x060005AB RID: 1451 RVA: 0x00013F0A File Offset: 0x0001210A
		public HeapString(int capacity, Allocator allocator)
		{
			this.m_Data = new NativeList<byte>(capacity + 1, allocator);
			this.Length = 0;
		}

		// Token: 0x060005AC RID: 1452 RVA: 0x00013F27 File Offset: 0x00012127
		public HeapString(Allocator allocator)
		{
			this.m_Data = new NativeList<byte>(129, allocator);
			this.Length = 0;
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x00013F46 File Offset: 0x00012146
		public int CompareTo(FixedString32Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x00013F50 File Offset: 0x00012150
		public unsafe HeapString(in FixedString32Bytes source, Allocator allocator)
		{
			this.m_Data = new NativeList<byte>((int)(source.utf8LengthInBytes + 1), allocator);
			this.Length = (int)source.utf8LengthInBytes;
			byte* source2 = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes30>(source.bytes);
			byte* unsafePtr = (byte*)this.m_Data.GetUnsafePtr<byte>();
			UnsafeUtility.MemCpy((void*)unsafePtr, (void*)source2, (long)((ulong)source.utf8LengthInBytes));
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x00013FA8 File Offset: 0x000121A8
		public unsafe static bool operator ==(in HeapString a, in FixedString32Bytes b)
		{
			HeapString heapString = *UnsafeUtilityExtensions.AsRef<HeapString>(a);
			int length = heapString.Length;
			int utf8LengthInBytes = (int)b.utf8LengthInBytes;
			byte* unsafePtr = heapString.GetUnsafePtr();
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes30>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(unsafePtr, length, bBytes, utf8LengthInBytes);
		}

		// Token: 0x060005B0 RID: 1456 RVA: 0x00013FEB File Offset: 0x000121EB
		public static bool operator !=(in HeapString a, in FixedString32Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x00013FF7 File Offset: 0x000121F7
		public bool Equals(FixedString32Bytes other)
		{
			return this == other;
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x00014001 File Offset: 0x00012201
		public int CompareTo(FixedString64Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x0001400C File Offset: 0x0001220C
		public unsafe HeapString(in FixedString64Bytes source, Allocator allocator)
		{
			this.m_Data = new NativeList<byte>((int)(source.utf8LengthInBytes + 1), allocator);
			this.Length = (int)source.utf8LengthInBytes;
			byte* source2 = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes62>(source.bytes);
			byte* unsafePtr = (byte*)this.m_Data.GetUnsafePtr<byte>();
			UnsafeUtility.MemCpy((void*)unsafePtr, (void*)source2, (long)((ulong)source.utf8LengthInBytes));
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x00014064 File Offset: 0x00012264
		public unsafe static bool operator ==(in HeapString a, in FixedString64Bytes b)
		{
			HeapString heapString = *UnsafeUtilityExtensions.AsRef<HeapString>(a);
			int length = heapString.Length;
			int utf8LengthInBytes = (int)b.utf8LengthInBytes;
			byte* unsafePtr = heapString.GetUnsafePtr();
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes62>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(unsafePtr, length, bBytes, utf8LengthInBytes);
		}

		// Token: 0x060005B5 RID: 1461 RVA: 0x000140A7 File Offset: 0x000122A7
		public static bool operator !=(in HeapString a, in FixedString64Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x060005B6 RID: 1462 RVA: 0x000140B3 File Offset: 0x000122B3
		public bool Equals(FixedString64Bytes other)
		{
			return this == other;
		}

		// Token: 0x060005B7 RID: 1463 RVA: 0x000140BD File Offset: 0x000122BD
		public int CompareTo(FixedString128Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x060005B8 RID: 1464 RVA: 0x000140C8 File Offset: 0x000122C8
		public unsafe HeapString(in FixedString128Bytes source, Allocator allocator)
		{
			this.m_Data = new NativeList<byte>((int)(source.utf8LengthInBytes + 1), allocator);
			this.Length = (int)source.utf8LengthInBytes;
			byte* source2 = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes126>(source.bytes);
			byte* unsafePtr = (byte*)this.m_Data.GetUnsafePtr<byte>();
			UnsafeUtility.MemCpy((void*)unsafePtr, (void*)source2, (long)((ulong)source.utf8LengthInBytes));
		}

		// Token: 0x060005B9 RID: 1465 RVA: 0x00014120 File Offset: 0x00012320
		public unsafe static bool operator ==(in HeapString a, in FixedString128Bytes b)
		{
			HeapString heapString = *UnsafeUtilityExtensions.AsRef<HeapString>(a);
			int length = heapString.Length;
			int utf8LengthInBytes = (int)b.utf8LengthInBytes;
			byte* unsafePtr = heapString.GetUnsafePtr();
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes126>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(unsafePtr, length, bBytes, utf8LengthInBytes);
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x00014163 File Offset: 0x00012363
		public static bool operator !=(in HeapString a, in FixedString128Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x060005BB RID: 1467 RVA: 0x0001416F File Offset: 0x0001236F
		public bool Equals(FixedString128Bytes other)
		{
			return this == other;
		}

		// Token: 0x060005BC RID: 1468 RVA: 0x00014179 File Offset: 0x00012379
		public int CompareTo(FixedString512Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x060005BD RID: 1469 RVA: 0x00014184 File Offset: 0x00012384
		public unsafe HeapString(in FixedString512Bytes source, Allocator allocator)
		{
			this.m_Data = new NativeList<byte>((int)(source.utf8LengthInBytes + 1), allocator);
			this.Length = (int)source.utf8LengthInBytes;
			byte* source2 = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes510>(source.bytes);
			byte* unsafePtr = (byte*)this.m_Data.GetUnsafePtr<byte>();
			UnsafeUtility.MemCpy((void*)unsafePtr, (void*)source2, (long)((ulong)source.utf8LengthInBytes));
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x000141DC File Offset: 0x000123DC
		public unsafe static bool operator ==(in HeapString a, in FixedString512Bytes b)
		{
			HeapString heapString = *UnsafeUtilityExtensions.AsRef<HeapString>(a);
			int length = heapString.Length;
			int utf8LengthInBytes = (int)b.utf8LengthInBytes;
			byte* unsafePtr = heapString.GetUnsafePtr();
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes510>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(unsafePtr, length, bBytes, utf8LengthInBytes);
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x0001421F File Offset: 0x0001241F
		public static bool operator !=(in HeapString a, in FixedString512Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x0001422B File Offset: 0x0001242B
		public bool Equals(FixedString512Bytes other)
		{
			return this == other;
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x00014235 File Offset: 0x00012435
		public int CompareTo(FixedString4096Bytes other)
		{
			return ref this.CompareTo(other);
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x00014240 File Offset: 0x00012440
		public unsafe HeapString(in FixedString4096Bytes source, Allocator allocator)
		{
			this.m_Data = new NativeList<byte>((int)(source.utf8LengthInBytes + 1), allocator);
			this.Length = (int)source.utf8LengthInBytes;
			byte* source2 = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes4094>(source.bytes);
			byte* unsafePtr = (byte*)this.m_Data.GetUnsafePtr<byte>();
			UnsafeUtility.MemCpy((void*)unsafePtr, (void*)source2, (long)((ulong)source.utf8LengthInBytes));
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x00014298 File Offset: 0x00012498
		public unsafe static bool operator ==(in HeapString a, in FixedString4096Bytes b)
		{
			HeapString heapString = *UnsafeUtilityExtensions.AsRef<HeapString>(a);
			int length = heapString.Length;
			int utf8LengthInBytes = (int)b.utf8LengthInBytes;
			byte* unsafePtr = heapString.GetUnsafePtr();
			byte* bBytes = (byte*)UnsafeUtilityExtensions.AddressOf<FixedBytes4094>(b.bytes);
			return UTF8ArrayUnsafeUtility.EqualsUTF8Bytes(unsafePtr, length, bBytes, utf8LengthInBytes);
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x000142DB File Offset: 0x000124DB
		public static bool operator !=(in HeapString a, in FixedString4096Bytes b)
		{
			return !(a == b);
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x000142E7 File Offset: 0x000124E7
		public bool Equals(FixedString4096Bytes other)
		{
			return this == other;
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x000142F1 File Offset: 0x000124F1
		[NotBurstCompatible]
		public override string ToString()
		{
			if (!this.m_Data.IsCreated)
			{
				return "";
			}
			return ref this.ConvertToString<HeapString>();
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x0001430C File Offset: 0x0001250C
		public override int GetHashCode()
		{
			return ref this.ComputeHashCode<HeapString>();
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x00014314 File Offset: 0x00012514
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
			if (other is HeapString)
			{
				HeapString other2 = (HeapString)other;
				return this.Equals(other2);
			}
			if (other is FixedString32Bytes)
			{
				FixedString32Bytes other3 = (FixedString32Bytes)other;
				return this.Equals(other3);
			}
			if (other is FixedString64Bytes)
			{
				FixedString64Bytes other4 = (FixedString64Bytes)other;
				return this.Equals(other4);
			}
			if (other is FixedString128Bytes)
			{
				FixedString128Bytes other5 = (FixedString128Bytes)other;
				return this.Equals(other5);
			}
			if (other is FixedString512Bytes)
			{
				FixedString512Bytes other6 = (FixedString512Bytes)other;
				return this.Equals(other6);
			}
			if (other is FixedString4096Bytes)
			{
				FixedString4096Bytes other7 = (FixedString4096Bytes)other;
				return this.Equals(other7);
			}
			return false;
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x000143CC File Offset: 0x000125CC
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckIndexInRange(int index)
		{
			if (index < 0)
			{
				throw new IndexOutOfRangeException(string.Format("Index {0} must be positive.", index));
			}
			if (index >= this.Length)
			{
				throw new IndexOutOfRangeException(string.Format("Index {0} is out of range in HeapString of {1} length.", index, this.Length));
			}
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x0001441D File Offset: 0x0001261D
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void ThrowCopyError(CopyError error, string source)
		{
			throw new ArgumentException(string.Format("HeapString: {0} while copying \"{1}\"", error, source));
		}

		// Token: 0x04000262 RID: 610
		private NativeList<byte> m_Data;

		// Token: 0x02000085 RID: 133
		public struct Enumerator : IEnumerator<Unicode.Rune>, IEnumerator, IDisposable
		{
			// Token: 0x060005CB RID: 1483 RVA: 0x00014435 File Offset: 0x00012635
			public Enumerator(HeapString source)
			{
				this.target = source;
				this.offset = 0;
				this.current = default(Unicode.Rune);
			}

			// Token: 0x060005CC RID: 1484 RVA: 0x000024A3 File Offset: 0x000006A3
			public void Dispose()
			{
			}

			// Token: 0x060005CD RID: 1485 RVA: 0x00014451 File Offset: 0x00012651
			public bool MoveNext()
			{
				if (this.offset >= this.target.Length)
				{
					return false;
				}
				Unicode.Utf8ToUcs(out this.current, this.target.GetUnsafePtr(), ref this.offset, this.target.Length);
				return true;
			}

			// Token: 0x060005CE RID: 1486 RVA: 0x00014491 File Offset: 0x00012691
			public void Reset()
			{
				this.offset = 0;
				this.current = default(Unicode.Rune);
			}

			// Token: 0x17000098 RID: 152
			// (get) Token: 0x060005CF RID: 1487 RVA: 0x000144A6 File Offset: 0x000126A6
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x17000099 RID: 153
			// (get) Token: 0x060005D0 RID: 1488 RVA: 0x000144B3 File Offset: 0x000126B3
			public Unicode.Rune Current
			{
				get
				{
					return this.current;
				}
			}

			// Token: 0x04000263 RID: 611
			private HeapString target;

			// Token: 0x04000264 RID: 612
			private int offset;

			// Token: 0x04000265 RID: 613
			private Unicode.Rune current;
		}
	}
}
