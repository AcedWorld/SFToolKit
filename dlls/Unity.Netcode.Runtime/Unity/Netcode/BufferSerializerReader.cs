using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x020000FB RID: 251
	internal struct BufferSerializerReader : IReaderWriter
	{
		// Token: 0x06000686 RID: 1670 RVA: 0x0001CA60 File Offset: 0x0001AC60
		public BufferSerializerReader(FastBufferReader reader)
		{
			this.m_Reader = reader;
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000687 RID: 1671 RVA: 0x0000C36D File Offset: 0x0000A56D
		public bool IsReader
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000688 RID: 1672 RVA: 0x0000BEB4 File Offset: 0x0000A0B4
		public bool IsWriter
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x0001CA69 File Offset: 0x0001AC69
		public FastBufferReader GetFastBufferReader()
		{
			return this.m_Reader;
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x0001CA71 File Offset: 0x0001AC71
		public FastBufferWriter GetFastBufferWriter()
		{
			throw new InvalidOperationException("Cannot retrieve a FastBufferWriter from a serializer where IsWriter = false");
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x0001CA7D File Offset: 0x0001AC7D
		public void SerializeValue(ref string s, bool oneByteChars = false)
		{
			this.m_Reader.ReadValueSafe(out s, oneByteChars);
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x0001CA8C File Offset: 0x0001AC8C
		public void SerializeValue(ref byte value)
		{
			this.m_Reader.ReadByteSafe(out value);
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x0001CA9C File Offset: 0x0001AC9C
		public void SerializeValue<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForPrimitives unused = default(FastBufferWriter.ForPrimitives)) where T : struct, ValueType, IComparable, IConvertible, IComparable<T>, IEquatable<T>
		{
			this.m_Reader.ReadValueSafe<T>(out value, default(FastBufferWriter.ForPrimitives));
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x0001CAC0 File Offset: 0x0001ACC0
		public void SerializeValue<[IsUnmanaged] T>(ref T[] value, FastBufferWriter.ForPrimitives unused = default(FastBufferWriter.ForPrimitives)) where T : struct, ValueType, IComparable, IConvertible, IComparable<T>, IEquatable<T>
		{
			this.m_Reader.ReadValueSafe<T>(out value, default(FastBufferWriter.ForPrimitives));
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x0001CAE4 File Offset: 0x0001ACE4
		public void SerializeValue<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForEnums unused = default(FastBufferWriter.ForEnums)) where T : struct, ValueType, Enum
		{
			this.m_Reader.ReadValueSafe<T>(out value, default(FastBufferWriter.ForEnums));
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x0001CB08 File Offset: 0x0001AD08
		public void SerializeValue<[IsUnmanaged] T>(ref T[] value, FastBufferWriter.ForEnums unused = default(FastBufferWriter.ForEnums)) where T : struct, ValueType, Enum
		{
			this.m_Reader.ReadValueSafe<T>(out value, default(FastBufferWriter.ForEnums));
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x0001CB2C File Offset: 0x0001AD2C
		public void SerializeValue<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForStructs unused = default(FastBufferWriter.ForStructs)) where T : struct, ValueType, INetworkSerializeByMemcpy
		{
			this.m_Reader.ReadValueSafe<T>(out value, default(FastBufferWriter.ForStructs));
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x0001CB50 File Offset: 0x0001AD50
		public void SerializeValue<[IsUnmanaged] T>(ref T[] value, FastBufferWriter.ForStructs unused = default(FastBufferWriter.ForStructs)) where T : struct, ValueType, INetworkSerializeByMemcpy
		{
			this.m_Reader.ReadValueSafe<T>(out value, default(FastBufferWriter.ForStructs));
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x0001CB74 File Offset: 0x0001AD74
		public void SerializeValue<[IsUnmanaged] T>(ref NativeArray<T> value, Allocator allocator, FastBufferWriter.ForGeneric unused = default(FastBufferWriter.ForGeneric)) where T : struct, ValueType
		{
			this.m_Reader.ReadValueSafe<T>(out value, allocator, default(FastBufferWriter.ForGeneric));
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x0001CB97 File Offset: 0x0001AD97
		public void SerializeValue<T>(ref T value, FastBufferWriter.ForNetworkSerializable unused = default(FastBufferWriter.ForNetworkSerializable)) where T : INetworkSerializable, new()
		{
			this.m_Reader.ReadNetworkSerializableInPlace<T>(ref value);
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x0001CBA8 File Offset: 0x0001ADA8
		public void SerializeValue<T>(ref T[] value, FastBufferWriter.ForNetworkSerializable unused = default(FastBufferWriter.ForNetworkSerializable)) where T : INetworkSerializable, new()
		{
			this.m_Reader.ReadValue<T>(out value, default(FastBufferWriter.ForNetworkSerializable));
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x0001CBCC File Offset: 0x0001ADCC
		public void SerializeValue<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForFixedStrings unused = default(FastBufferWriter.ForFixedStrings)) where T : struct, ValueType, INativeList<byte>, IUTF8Bytes
		{
			this.m_Reader.ReadValueSafe<T>(out value, default(FastBufferWriter.ForFixedStrings));
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x0001CBEE File Offset: 0x0001ADEE
		public void SerializeValue<[IsUnmanaged] T>(ref NativeArray<T> value, Allocator allocator) where T : struct, ValueType, INativeList<byte>, IUTF8Bytes
		{
			this.m_Reader.ReadValueSafe<T>(out value, allocator);
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x0001CBFD File Offset: 0x0001ADFD
		public void SerializeValue(ref Vector2 value)
		{
			this.m_Reader.ReadValueSafe(out value);
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x0001CC0B File Offset: 0x0001AE0B
		public void SerializeValue(ref Vector2[] value)
		{
			this.m_Reader.ReadValueSafe(out value);
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x0001CC19 File Offset: 0x0001AE19
		public void SerializeValue(ref Vector3 value)
		{
			this.m_Reader.ReadValueSafe(out value);
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x0001CC27 File Offset: 0x0001AE27
		public void SerializeValue(ref Vector3[] value)
		{
			this.m_Reader.ReadValueSafe(out value);
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x0001CC35 File Offset: 0x0001AE35
		public void SerializeValue(ref Vector2Int value)
		{
			this.m_Reader.ReadValueSafe(out value);
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x0001CC43 File Offset: 0x0001AE43
		public void SerializeValue(ref Vector2Int[] value)
		{
			this.m_Reader.ReadValueSafe(out value);
		}

		// Token: 0x0600069E RID: 1694 RVA: 0x0001CC51 File Offset: 0x0001AE51
		public void SerializeValue(ref Vector3Int value)
		{
			this.m_Reader.ReadValueSafe(out value);
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x0001CC5F File Offset: 0x0001AE5F
		public void SerializeValue(ref Vector3Int[] value)
		{
			this.m_Reader.ReadValueSafe(out value);
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x0001CC6D File Offset: 0x0001AE6D
		public void SerializeValue(ref Vector4 value)
		{
			this.m_Reader.ReadValueSafe(out value);
		}

		// Token: 0x060006A1 RID: 1697 RVA: 0x0001CC7B File Offset: 0x0001AE7B
		public void SerializeValue(ref Vector4[] value)
		{
			this.m_Reader.ReadValueSafe(out value);
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x0001CC89 File Offset: 0x0001AE89
		public void SerializeValue(ref Quaternion value)
		{
			this.m_Reader.ReadValueSafe(out value);
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x0001CC97 File Offset: 0x0001AE97
		public void SerializeValue(ref Quaternion[] value)
		{
			this.m_Reader.ReadValueSafe(out value);
		}

		// Token: 0x060006A4 RID: 1700 RVA: 0x0001CCA5 File Offset: 0x0001AEA5
		public void SerializeValue(ref Color value)
		{
			this.m_Reader.ReadValueSafe(out value);
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x0001CCB3 File Offset: 0x0001AEB3
		public void SerializeValue(ref Color[] value)
		{
			this.m_Reader.ReadValueSafe(out value);
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x0001CCC1 File Offset: 0x0001AEC1
		public void SerializeValue(ref Color32 value)
		{
			this.m_Reader.ReadValueSafe(out value);
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x0001CCCF File Offset: 0x0001AECF
		public void SerializeValue(ref Color32[] value)
		{
			this.m_Reader.ReadValueSafe(out value);
		}

		// Token: 0x060006A8 RID: 1704 RVA: 0x0001CCDD File Offset: 0x0001AEDD
		public void SerializeValue(ref Ray value)
		{
			this.m_Reader.ReadValueSafe(out value);
		}

		// Token: 0x060006A9 RID: 1705 RVA: 0x0001CCEB File Offset: 0x0001AEEB
		public void SerializeValue(ref Ray[] value)
		{
			this.m_Reader.ReadValueSafe(out value);
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x0001CCF9 File Offset: 0x0001AEF9
		public void SerializeValue(ref Ray2D value)
		{
			this.m_Reader.ReadValueSafe(out value);
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x0001CD07 File Offset: 0x0001AF07
		public void SerializeValue(ref Ray2D[] value)
		{
			this.m_Reader.ReadValueSafe(out value);
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x0001CD15 File Offset: 0x0001AF15
		public void SerializeNetworkSerializable<T>(ref T value) where T : INetworkSerializable, new()
		{
			this.m_Reader.ReadNetworkSerializable<T>(out value);
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x0001CD23 File Offset: 0x0001AF23
		public bool PreCheck(int amount)
		{
			return this.m_Reader.TryBeginRead(amount);
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x0001CD31 File Offset: 0x0001AF31
		public void SerializeValuePreChecked(ref string s, bool oneByteChars = false)
		{
			this.m_Reader.ReadValue(out s, oneByteChars);
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x0001CD40 File Offset: 0x0001AF40
		public void SerializeValuePreChecked(ref byte value)
		{
			this.m_Reader.ReadByte(out value);
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x0001CD50 File Offset: 0x0001AF50
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForPrimitives unused = default(FastBufferWriter.ForPrimitives)) where T : struct, ValueType, IComparable, IConvertible, IComparable<T>, IEquatable<T>
		{
			this.m_Reader.ReadValue<T>(out value, default(FastBufferWriter.ForPrimitives));
		}

		// Token: 0x060006B1 RID: 1713 RVA: 0x0001CD74 File Offset: 0x0001AF74
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref T[] value, FastBufferWriter.ForPrimitives unused = default(FastBufferWriter.ForPrimitives)) where T : struct, ValueType, IComparable, IConvertible, IComparable<T>, IEquatable<T>
		{
			this.m_Reader.ReadValue<T>(out value, default(FastBufferWriter.ForPrimitives));
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x0001CD98 File Offset: 0x0001AF98
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForEnums unused = default(FastBufferWriter.ForEnums)) where T : struct, ValueType, Enum
		{
			this.m_Reader.ReadValue<T>(out value, default(FastBufferWriter.ForEnums));
		}

		// Token: 0x060006B3 RID: 1715 RVA: 0x0001CDBC File Offset: 0x0001AFBC
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref T[] value, FastBufferWriter.ForEnums unused = default(FastBufferWriter.ForEnums)) where T : struct, ValueType, Enum
		{
			this.m_Reader.ReadValue<T>(out value, default(FastBufferWriter.ForEnums));
		}

		// Token: 0x060006B4 RID: 1716 RVA: 0x0001CDE0 File Offset: 0x0001AFE0
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForStructs unused = default(FastBufferWriter.ForStructs)) where T : struct, ValueType, INetworkSerializeByMemcpy
		{
			this.m_Reader.ReadValue<T>(out value, default(FastBufferWriter.ForStructs));
		}

		// Token: 0x060006B5 RID: 1717 RVA: 0x0001CE04 File Offset: 0x0001B004
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref T[] value, FastBufferWriter.ForStructs unused = default(FastBufferWriter.ForStructs)) where T : struct, ValueType, INetworkSerializeByMemcpy
		{
			this.m_Reader.ReadValue<T>(out value, default(FastBufferWriter.ForStructs));
		}

		// Token: 0x060006B6 RID: 1718 RVA: 0x0001CE28 File Offset: 0x0001B028
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref NativeArray<T> value, Allocator allocator, FastBufferWriter.ForGeneric unused = default(FastBufferWriter.ForGeneric)) where T : struct, ValueType
		{
			this.m_Reader.ReadValue<T>(out value, allocator, default(FastBufferWriter.ForGeneric));
		}

		// Token: 0x060006B7 RID: 1719 RVA: 0x0001CE4C File Offset: 0x0001B04C
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForFixedStrings unused = default(FastBufferWriter.ForFixedStrings)) where T : struct, ValueType, INativeList<byte>, IUTF8Bytes
		{
			this.m_Reader.ReadValue<T>(out value, default(FastBufferWriter.ForFixedStrings));
		}

		// Token: 0x060006B8 RID: 1720 RVA: 0x0001CE6E File Offset: 0x0001B06E
		public void SerializeValuePreChecked(ref Vector2 value)
		{
			this.m_Reader.ReadValue(out value);
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x0001CE7C File Offset: 0x0001B07C
		public void SerializeValuePreChecked(ref Vector2[] value)
		{
			this.m_Reader.ReadValue(out value);
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x0001CE8A File Offset: 0x0001B08A
		public void SerializeValuePreChecked(ref Vector3 value)
		{
			this.m_Reader.ReadValue(out value);
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x0001CE98 File Offset: 0x0001B098
		public void SerializeValuePreChecked(ref Vector3[] value)
		{
			this.m_Reader.ReadValue(out value);
		}

		// Token: 0x060006BC RID: 1724 RVA: 0x0001CEA6 File Offset: 0x0001B0A6
		public void SerializeValuePreChecked(ref Vector2Int value)
		{
			this.m_Reader.ReadValue(out value);
		}

		// Token: 0x060006BD RID: 1725 RVA: 0x0001CEB4 File Offset: 0x0001B0B4
		public void SerializeValuePreChecked(ref Vector2Int[] value)
		{
			this.m_Reader.ReadValue(out value);
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x0001CEC2 File Offset: 0x0001B0C2
		public void SerializeValuePreChecked(ref Vector3Int value)
		{
			this.m_Reader.ReadValue(out value);
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x0001CED0 File Offset: 0x0001B0D0
		public void SerializeValuePreChecked(ref Vector3Int[] value)
		{
			this.m_Reader.ReadValue(out value);
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x0001CEDE File Offset: 0x0001B0DE
		public void SerializeValuePreChecked(ref Vector4 value)
		{
			this.m_Reader.ReadValue(out value);
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x0001CEEC File Offset: 0x0001B0EC
		public void SerializeValuePreChecked(ref Vector4[] value)
		{
			this.m_Reader.ReadValue(out value);
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x0001CEFA File Offset: 0x0001B0FA
		public void SerializeValuePreChecked(ref Quaternion value)
		{
			this.m_Reader.ReadValue(out value);
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x0001CF08 File Offset: 0x0001B108
		public void SerializeValuePreChecked(ref Quaternion[] value)
		{
			this.m_Reader.ReadValue(out value);
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x0001CF16 File Offset: 0x0001B116
		public void SerializeValuePreChecked(ref Color value)
		{
			this.m_Reader.ReadValue(out value);
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x0001CF24 File Offset: 0x0001B124
		public void SerializeValuePreChecked(ref Color[] value)
		{
			this.m_Reader.ReadValue(out value);
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x0001CF32 File Offset: 0x0001B132
		public void SerializeValuePreChecked(ref Color32 value)
		{
			this.m_Reader.ReadValue(out value);
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x0001CF40 File Offset: 0x0001B140
		public void SerializeValuePreChecked(ref Color32[] value)
		{
			this.m_Reader.ReadValue(out value);
		}

		// Token: 0x060006C8 RID: 1736 RVA: 0x0001CF4E File Offset: 0x0001B14E
		public void SerializeValuePreChecked(ref Ray value)
		{
			this.m_Reader.ReadValue(out value);
		}

		// Token: 0x060006C9 RID: 1737 RVA: 0x0001CF5C File Offset: 0x0001B15C
		public void SerializeValuePreChecked(ref Ray[] value)
		{
			this.m_Reader.ReadValue(out value);
		}

		// Token: 0x060006CA RID: 1738 RVA: 0x0001CF6A File Offset: 0x0001B16A
		public void SerializeValuePreChecked(ref Ray2D value)
		{
			this.m_Reader.ReadValue(out value);
		}

		// Token: 0x060006CB RID: 1739 RVA: 0x0001CF78 File Offset: 0x0001B178
		public void SerializeValuePreChecked(ref Ray2D[] value)
		{
			this.m_Reader.ReadValue(out value);
		}

		// Token: 0x0400030E RID: 782
		private FastBufferReader m_Reader;
	}
}
