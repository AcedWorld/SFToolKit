using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x020000FC RID: 252
	internal struct BufferSerializerWriter : IReaderWriter
	{
		// Token: 0x060006CC RID: 1740 RVA: 0x0001CF86 File Offset: 0x0001B186
		public BufferSerializerWriter(FastBufferWriter writer)
		{
			this.m_Writer = writer;
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060006CD RID: 1741 RVA: 0x0000BEB4 File Offset: 0x0000A0B4
		public bool IsReader
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060006CE RID: 1742 RVA: 0x0000C36D File Offset: 0x0000A56D
		public bool IsWriter
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x0001CF8F File Offset: 0x0001B18F
		public FastBufferReader GetFastBufferReader()
		{
			throw new InvalidOperationException("Cannot retrieve a FastBufferReader from a serializer where IsReader = false");
		}

		// Token: 0x060006D0 RID: 1744 RVA: 0x0001CF9B File Offset: 0x0001B19B
		public FastBufferWriter GetFastBufferWriter()
		{
			return this.m_Writer;
		}

		// Token: 0x060006D1 RID: 1745 RVA: 0x0001CFA3 File Offset: 0x0001B1A3
		public void SerializeValue(ref string s, bool oneByteChars = false)
		{
			this.m_Writer.WriteValueSafe(s, oneByteChars);
		}

		// Token: 0x060006D2 RID: 1746 RVA: 0x0001CFB3 File Offset: 0x0001B1B3
		public void SerializeValue(ref byte value)
		{
			this.m_Writer.WriteByteSafe(value);
		}

		// Token: 0x060006D3 RID: 1747 RVA: 0x0001CFC4 File Offset: 0x0001B1C4
		public void SerializeValue<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForPrimitives unused = default(FastBufferWriter.ForPrimitives)) where T : struct, ValueType, IComparable, IConvertible, IComparable<T>, IEquatable<T>
		{
			this.m_Writer.WriteValueSafe<T>(value, default(FastBufferWriter.ForPrimitives));
		}

		// Token: 0x060006D4 RID: 1748 RVA: 0x0001CFE8 File Offset: 0x0001B1E8
		public void SerializeValue<[IsUnmanaged] T>(ref T[] value, FastBufferWriter.ForPrimitives unused = default(FastBufferWriter.ForPrimitives)) where T : struct, ValueType, IComparable, IConvertible, IComparable<T>, IEquatable<T>
		{
			this.m_Writer.WriteValueSafe<T>(value, default(FastBufferWriter.ForPrimitives));
		}

		// Token: 0x060006D5 RID: 1749 RVA: 0x0001D00C File Offset: 0x0001B20C
		public void SerializeValue<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForEnums unused = default(FastBufferWriter.ForEnums)) where T : struct, ValueType, Enum
		{
			this.m_Writer.WriteValueSafe<T>(value, default(FastBufferWriter.ForEnums));
		}

		// Token: 0x060006D6 RID: 1750 RVA: 0x0001D030 File Offset: 0x0001B230
		public void SerializeValue<[IsUnmanaged] T>(ref T[] value, FastBufferWriter.ForEnums unused = default(FastBufferWriter.ForEnums)) where T : struct, ValueType, Enum
		{
			this.m_Writer.WriteValueSafe<T>(value, default(FastBufferWriter.ForEnums));
		}

		// Token: 0x060006D7 RID: 1751 RVA: 0x0001D054 File Offset: 0x0001B254
		public void SerializeValue<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForStructs unused = default(FastBufferWriter.ForStructs)) where T : struct, ValueType, INetworkSerializeByMemcpy
		{
			this.m_Writer.WriteValueSafe<T>(value, default(FastBufferWriter.ForStructs));
		}

		// Token: 0x060006D8 RID: 1752 RVA: 0x0001D078 File Offset: 0x0001B278
		public void SerializeValue<[IsUnmanaged] T>(ref T[] value, FastBufferWriter.ForStructs unused = default(FastBufferWriter.ForStructs)) where T : struct, ValueType, INetworkSerializeByMemcpy
		{
			this.m_Writer.WriteValueSafe<T>(value, default(FastBufferWriter.ForStructs));
		}

		// Token: 0x060006D9 RID: 1753 RVA: 0x0001D09C File Offset: 0x0001B29C
		public void SerializeValue<[IsUnmanaged] T>(ref NativeArray<T> value, Allocator allocator, FastBufferWriter.ForGeneric unused = default(FastBufferWriter.ForGeneric)) where T : struct, ValueType
		{
			this.m_Writer.WriteValueSafe<T>(value, default(FastBufferWriter.ForGeneric));
		}

		// Token: 0x060006DA RID: 1754 RVA: 0x0001D0C4 File Offset: 0x0001B2C4
		public void SerializeValue<T>(ref T value, FastBufferWriter.ForNetworkSerializable unused = default(FastBufferWriter.ForNetworkSerializable)) where T : INetworkSerializable, new()
		{
			this.m_Writer.WriteValue<T>(value, default(FastBufferWriter.ForNetworkSerializable));
		}

		// Token: 0x060006DB RID: 1755 RVA: 0x0001D0E8 File Offset: 0x0001B2E8
		public void SerializeValue<T>(ref T[] value, FastBufferWriter.ForNetworkSerializable unused = default(FastBufferWriter.ForNetworkSerializable)) where T : INetworkSerializable, new()
		{
			this.m_Writer.WriteValue<T>(value, default(FastBufferWriter.ForNetworkSerializable));
		}

		// Token: 0x060006DC RID: 1756 RVA: 0x0001D10C File Offset: 0x0001B30C
		public void SerializeValue<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForFixedStrings unused = default(FastBufferWriter.ForFixedStrings)) where T : struct, ValueType, INativeList<byte>, IUTF8Bytes
		{
			this.m_Writer.WriteValueSafe<T>(value, default(FastBufferWriter.ForFixedStrings));
		}

		// Token: 0x060006DD RID: 1757 RVA: 0x0001D12E File Offset: 0x0001B32E
		public void SerializeValue<[IsUnmanaged] T>(ref NativeArray<T> value, Allocator allocator) where T : struct, ValueType, INativeList<byte>, IUTF8Bytes
		{
			this.m_Writer.WriteValueSafe<T>(value);
		}

		// Token: 0x060006DE RID: 1758 RVA: 0x0001D13C File Offset: 0x0001B33C
		public void SerializeValue(ref Vector2 value)
		{
			this.m_Writer.WriteValueSafe(value);
		}

		// Token: 0x060006DF RID: 1759 RVA: 0x0001D14A File Offset: 0x0001B34A
		public void SerializeValue(ref Vector2[] value)
		{
			this.m_Writer.WriteValueSafe(value);
		}

		// Token: 0x060006E0 RID: 1760 RVA: 0x0001D159 File Offset: 0x0001B359
		public void SerializeValue(ref Vector3 value)
		{
			this.m_Writer.WriteValueSafe(value);
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x0001D167 File Offset: 0x0001B367
		public void SerializeValue(ref Vector3[] value)
		{
			this.m_Writer.WriteValueSafe(value);
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x0001D176 File Offset: 0x0001B376
		public void SerializeValue(ref Vector2Int value)
		{
			this.m_Writer.WriteValueSafe(value);
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x0001D184 File Offset: 0x0001B384
		public void SerializeValue(ref Vector2Int[] value)
		{
			this.m_Writer.WriteValueSafe(value);
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x0001D193 File Offset: 0x0001B393
		public void SerializeValue(ref Vector3Int value)
		{
			this.m_Writer.WriteValueSafe(value);
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x0001D1A1 File Offset: 0x0001B3A1
		public void SerializeValue(ref Vector3Int[] value)
		{
			this.m_Writer.WriteValueSafe(value);
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x0001D1B0 File Offset: 0x0001B3B0
		public void SerializeValue(ref Vector4 value)
		{
			this.m_Writer.WriteValueSafe(value);
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x0001D1BE File Offset: 0x0001B3BE
		public void SerializeValue(ref Vector4[] value)
		{
			this.m_Writer.WriteValueSafe(value);
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x0001D1CD File Offset: 0x0001B3CD
		public void SerializeValue(ref Quaternion value)
		{
			this.m_Writer.WriteValueSafe(value);
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x0001D1DB File Offset: 0x0001B3DB
		public void SerializeValue(ref Quaternion[] value)
		{
			this.m_Writer.WriteValueSafe(value);
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x0001D1EA File Offset: 0x0001B3EA
		public void SerializeValue(ref Color value)
		{
			this.m_Writer.WriteValueSafe(value);
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x0001D1F8 File Offset: 0x0001B3F8
		public void SerializeValue(ref Color[] value)
		{
			this.m_Writer.WriteValueSafe(value);
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x0001D207 File Offset: 0x0001B407
		public void SerializeValue(ref Color32 value)
		{
			this.m_Writer.WriteValueSafe(value);
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x0001D215 File Offset: 0x0001B415
		public void SerializeValue(ref Color32[] value)
		{
			this.m_Writer.WriteValueSafe(value);
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x0001D224 File Offset: 0x0001B424
		public void SerializeValue(ref Ray value)
		{
			this.m_Writer.WriteValueSafe(value);
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x0001D232 File Offset: 0x0001B432
		public void SerializeValue(ref Ray[] value)
		{
			this.m_Writer.WriteValueSafe(value);
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x0001D241 File Offset: 0x0001B441
		public void SerializeValue(ref Ray2D value)
		{
			this.m_Writer.WriteValueSafe(value);
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x0001D24F File Offset: 0x0001B44F
		public void SerializeValue(ref Ray2D[] value)
		{
			this.m_Writer.WriteValueSafe(value);
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x0001D25E File Offset: 0x0001B45E
		public void SerializeNetworkSerializable<T>(ref T value) where T : INetworkSerializable, new()
		{
			this.m_Writer.WriteNetworkSerializable<T>(value);
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x0001D26C File Offset: 0x0001B46C
		public bool PreCheck(int amount)
		{
			return this.m_Writer.TryBeginWrite(amount);
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x0001D27A File Offset: 0x0001B47A
		public void SerializeValuePreChecked(ref string s, bool oneByteChars = false)
		{
			this.m_Writer.WriteValue(s, oneByteChars);
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x0001D28A File Offset: 0x0001B48A
		public void SerializeValuePreChecked(ref byte value)
		{
			this.m_Writer.WriteByte(value);
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x0001D29C File Offset: 0x0001B49C
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForPrimitives unused = default(FastBufferWriter.ForPrimitives)) where T : struct, ValueType, IComparable, IConvertible, IComparable<T>, IEquatable<T>
		{
			this.m_Writer.WriteValue<T>(value, default(FastBufferWriter.ForPrimitives));
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x0001D2C0 File Offset: 0x0001B4C0
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref T[] value, FastBufferWriter.ForPrimitives unused = default(FastBufferWriter.ForPrimitives)) where T : struct, ValueType, IComparable, IConvertible, IComparable<T>, IEquatable<T>
		{
			this.m_Writer.WriteValue<T>(value, default(FastBufferWriter.ForPrimitives));
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x0001D2E4 File Offset: 0x0001B4E4
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForEnums unused = default(FastBufferWriter.ForEnums)) where T : struct, ValueType, Enum
		{
			this.m_Writer.WriteValue<T>(value, default(FastBufferWriter.ForEnums));
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x0001D308 File Offset: 0x0001B508
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref T[] value, FastBufferWriter.ForEnums unused = default(FastBufferWriter.ForEnums)) where T : struct, ValueType, Enum
		{
			this.m_Writer.WriteValue<T>(value, default(FastBufferWriter.ForEnums));
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x0001D32C File Offset: 0x0001B52C
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForStructs unused = default(FastBufferWriter.ForStructs)) where T : struct, ValueType, INetworkSerializeByMemcpy
		{
			this.m_Writer.WriteValue<T>(value, default(FastBufferWriter.ForStructs));
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x0001D350 File Offset: 0x0001B550
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref T[] value, FastBufferWriter.ForStructs unused = default(FastBufferWriter.ForStructs)) where T : struct, ValueType, INetworkSerializeByMemcpy
		{
			this.m_Writer.WriteValue<T>(value, default(FastBufferWriter.ForStructs));
		}

		// Token: 0x060006FC RID: 1788 RVA: 0x0001D374 File Offset: 0x0001B574
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref NativeArray<T> value, Allocator allocator, FastBufferWriter.ForGeneric unused = default(FastBufferWriter.ForGeneric)) where T : struct, ValueType
		{
			this.m_Writer.WriteValue<T>(value, default(FastBufferWriter.ForGeneric));
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x0001D39C File Offset: 0x0001B59C
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForFixedStrings unused = default(FastBufferWriter.ForFixedStrings)) where T : struct, ValueType, INativeList<byte>, IUTF8Bytes
		{
			this.m_Writer.WriteValue<T>(value, default(FastBufferWriter.ForFixedStrings));
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x0001D3BE File Offset: 0x0001B5BE
		public void SerializeValuePreChecked(ref Vector2 value)
		{
			this.m_Writer.WriteValue(value);
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x0001D3CC File Offset: 0x0001B5CC
		public void SerializeValuePreChecked(ref Vector2[] value)
		{
			this.m_Writer.WriteValue(value);
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x0001D3DB File Offset: 0x0001B5DB
		public void SerializeValuePreChecked(ref Vector3 value)
		{
			this.m_Writer.WriteValue(value);
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x0001D3E9 File Offset: 0x0001B5E9
		public void SerializeValuePreChecked(ref Vector3[] value)
		{
			this.m_Writer.WriteValue(value);
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x0001D3F8 File Offset: 0x0001B5F8
		public void SerializeValuePreChecked(ref Vector2Int value)
		{
			this.m_Writer.WriteValue(value);
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x0001D406 File Offset: 0x0001B606
		public void SerializeValuePreChecked(ref Vector2Int[] value)
		{
			this.m_Writer.WriteValue(value);
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x0001D415 File Offset: 0x0001B615
		public void SerializeValuePreChecked(ref Vector3Int value)
		{
			this.m_Writer.WriteValue(value);
		}

		// Token: 0x06000705 RID: 1797 RVA: 0x0001D423 File Offset: 0x0001B623
		public void SerializeValuePreChecked(ref Vector3Int[] value)
		{
			this.m_Writer.WriteValue(value);
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x0001D432 File Offset: 0x0001B632
		public void SerializeValuePreChecked(ref Vector4 value)
		{
			this.m_Writer.WriteValue(value);
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x0001D440 File Offset: 0x0001B640
		public void SerializeValuePreChecked(ref Vector4[] value)
		{
			this.m_Writer.WriteValue(value);
		}

		// Token: 0x06000708 RID: 1800 RVA: 0x0001D44F File Offset: 0x0001B64F
		public void SerializeValuePreChecked(ref Quaternion value)
		{
			this.m_Writer.WriteValue(value);
		}

		// Token: 0x06000709 RID: 1801 RVA: 0x0001D45D File Offset: 0x0001B65D
		public void SerializeValuePreChecked(ref Quaternion[] value)
		{
			this.m_Writer.WriteValue(value);
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x0001D46C File Offset: 0x0001B66C
		public void SerializeValuePreChecked(ref Color value)
		{
			this.m_Writer.WriteValue(value);
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x0001D47A File Offset: 0x0001B67A
		public void SerializeValuePreChecked(ref Color[] value)
		{
			this.m_Writer.WriteValue(value);
		}

		// Token: 0x0600070C RID: 1804 RVA: 0x0001D489 File Offset: 0x0001B689
		public void SerializeValuePreChecked(ref Color32 value)
		{
			this.m_Writer.WriteValue(value);
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x0001D497 File Offset: 0x0001B697
		public void SerializeValuePreChecked(ref Color32[] value)
		{
			this.m_Writer.WriteValue(value);
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x0001D4A6 File Offset: 0x0001B6A6
		public void SerializeValuePreChecked(ref Ray value)
		{
			this.m_Writer.WriteValue(value);
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x0001D4B4 File Offset: 0x0001B6B4
		public void SerializeValuePreChecked(ref Ray[] value)
		{
			this.m_Writer.WriteValue(value);
		}

		// Token: 0x06000710 RID: 1808 RVA: 0x0001D4C3 File Offset: 0x0001B6C3
		public void SerializeValuePreChecked(ref Ray2D value)
		{
			this.m_Writer.WriteValue(value);
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x0001D4D1 File Offset: 0x0001B6D1
		public void SerializeValuePreChecked(ref Ray2D[] value)
		{
			this.m_Writer.WriteValue(value);
		}

		// Token: 0x0400030F RID: 783
		private FastBufferWriter m_Writer;
	}
}
