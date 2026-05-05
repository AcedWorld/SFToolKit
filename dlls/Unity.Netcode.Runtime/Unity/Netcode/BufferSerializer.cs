using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x020000FA RID: 250
	public ref struct BufferSerializer<TReaderWriter> where TReaderWriter : IReaderWriter
	{
		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000640 RID: 1600 RVA: 0x0001C37F File Offset: 0x0001A57F
		public bool IsReader
		{
			get
			{
				return this.m_Implementation.IsReader;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000641 RID: 1601 RVA: 0x0001C392 File Offset: 0x0001A592
		public bool IsWriter
		{
			get
			{
				return this.m_Implementation.IsWriter;
			}
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x0001C3A5 File Offset: 0x0001A5A5
		internal BufferSerializer(TReaderWriter implementation)
		{
			this.m_Implementation = implementation;
		}

		// Token: 0x06000643 RID: 1603 RVA: 0x0001C3AE File Offset: 0x0001A5AE
		public FastBufferReader GetFastBufferReader()
		{
			return this.m_Implementation.GetFastBufferReader();
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x0001C3C1 File Offset: 0x0001A5C1
		public FastBufferWriter GetFastBufferWriter()
		{
			return this.m_Implementation.GetFastBufferWriter();
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x0001C3D4 File Offset: 0x0001A5D4
		public void SerializeValue(ref string s, bool oneByteChars = false)
		{
			this.m_Implementation.SerializeValue(ref s, oneByteChars);
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x0001C3E9 File Offset: 0x0001A5E9
		public void SerializeValue(ref byte value)
		{
			this.m_Implementation.SerializeValue(ref value);
		}

		// Token: 0x06000647 RID: 1607 RVA: 0x0001C400 File Offset: 0x0001A600
		public void SerializeValue<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForPrimitives unused = default(FastBufferWriter.ForPrimitives)) where T : struct, ValueType, IComparable, IConvertible, IComparable<T>, IEquatable<T>
		{
			this.m_Implementation.SerializeValue<T>(ref value, default(FastBufferWriter.ForPrimitives));
		}

		// Token: 0x06000648 RID: 1608 RVA: 0x0001C428 File Offset: 0x0001A628
		public void SerializeValue<[IsUnmanaged] T>(ref T[] value, FastBufferWriter.ForPrimitives unused = default(FastBufferWriter.ForPrimitives)) where T : struct, ValueType, IComparable, IConvertible, IComparable<T>, IEquatable<T>
		{
			this.m_Implementation.SerializeValue<T>(ref value, default(FastBufferWriter.ForPrimitives));
		}

		// Token: 0x06000649 RID: 1609 RVA: 0x0001C450 File Offset: 0x0001A650
		public void SerializeValue<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForEnums unused = default(FastBufferWriter.ForEnums)) where T : struct, ValueType, Enum
		{
			this.m_Implementation.SerializeValue<T>(ref value, default(FastBufferWriter.ForEnums));
		}

		// Token: 0x0600064A RID: 1610 RVA: 0x0001C478 File Offset: 0x0001A678
		public void SerializeValue<[IsUnmanaged] T>(ref T[] value, FastBufferWriter.ForEnums unused = default(FastBufferWriter.ForEnums)) where T : struct, ValueType, Enum
		{
			this.m_Implementation.SerializeValue<T>(ref value, default(FastBufferWriter.ForEnums));
		}

		// Token: 0x0600064B RID: 1611 RVA: 0x0001C4A0 File Offset: 0x0001A6A0
		public void SerializeValue<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForStructs unused = default(FastBufferWriter.ForStructs)) where T : struct, ValueType, INetworkSerializeByMemcpy
		{
			this.m_Implementation.SerializeValue<T>(ref value, default(FastBufferWriter.ForStructs));
		}

		// Token: 0x0600064C RID: 1612 RVA: 0x0001C4C8 File Offset: 0x0001A6C8
		public void SerializeValue<[IsUnmanaged] T>(ref T[] value, FastBufferWriter.ForStructs unused = default(FastBufferWriter.ForStructs)) where T : struct, ValueType, INetworkSerializeByMemcpy
		{
			this.m_Implementation.SerializeValue<T>(ref value, default(FastBufferWriter.ForStructs));
		}

		// Token: 0x0600064D RID: 1613 RVA: 0x0001C4F0 File Offset: 0x0001A6F0
		public void SerializeValue<[IsUnmanaged] T>(ref NativeArray<T> value, Allocator allocator, FastBufferWriter.ForGeneric unused = default(FastBufferWriter.ForGeneric)) where T : struct, ValueType
		{
			this.m_Implementation.SerializeValue<T>(ref value, allocator, default(FastBufferWriter.ForGeneric));
		}

		// Token: 0x0600064E RID: 1614 RVA: 0x0001C51C File Offset: 0x0001A71C
		public void SerializeValue<T>(ref T value, FastBufferWriter.ForNetworkSerializable unused = default(FastBufferWriter.ForNetworkSerializable)) where T : INetworkSerializable, new()
		{
			this.m_Implementation.SerializeValue<T>(ref value, default(FastBufferWriter.ForNetworkSerializable));
		}

		// Token: 0x0600064F RID: 1615 RVA: 0x0001C544 File Offset: 0x0001A744
		public void SerializeValue<T>(ref T[] value, FastBufferWriter.ForNetworkSerializable unused = default(FastBufferWriter.ForNetworkSerializable)) where T : INetworkSerializable, new()
		{
			this.m_Implementation.SerializeValue<T>(ref value, default(FastBufferWriter.ForNetworkSerializable));
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x0001C56C File Offset: 0x0001A76C
		public void SerializeValue(ref Vector2 value)
		{
			this.m_Implementation.SerializeValue(ref value);
		}

		// Token: 0x06000651 RID: 1617 RVA: 0x0001C580 File Offset: 0x0001A780
		public void SerializeValue(ref Vector2[] value)
		{
			this.m_Implementation.SerializeValue(ref value);
		}

		// Token: 0x06000652 RID: 1618 RVA: 0x0001C594 File Offset: 0x0001A794
		public void SerializeValue(ref Vector3 value)
		{
			this.m_Implementation.SerializeValue(ref value);
		}

		// Token: 0x06000653 RID: 1619 RVA: 0x0001C5A8 File Offset: 0x0001A7A8
		public void SerializeValue(ref Vector3[] value)
		{
			this.m_Implementation.SerializeValue(ref value);
		}

		// Token: 0x06000654 RID: 1620 RVA: 0x0001C5BC File Offset: 0x0001A7BC
		public void SerializeValue(ref Vector2Int value)
		{
			this.m_Implementation.SerializeValue(ref value);
		}

		// Token: 0x06000655 RID: 1621 RVA: 0x0001C5D0 File Offset: 0x0001A7D0
		public void SerializeValue(ref Vector2Int[] value)
		{
			this.m_Implementation.SerializeValue(ref value);
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x0001C5E4 File Offset: 0x0001A7E4
		public void SerializeValue(ref Vector3Int value)
		{
			this.m_Implementation.SerializeValue(ref value);
		}

		// Token: 0x06000657 RID: 1623 RVA: 0x0001C5F8 File Offset: 0x0001A7F8
		public void SerializeValue(ref Vector3Int[] value)
		{
			this.m_Implementation.SerializeValue(ref value);
		}

		// Token: 0x06000658 RID: 1624 RVA: 0x0001C60C File Offset: 0x0001A80C
		public void SerializeValue(ref Vector4 value)
		{
			this.m_Implementation.SerializeValue(ref value);
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x0001C620 File Offset: 0x0001A820
		public void SerializeValue(ref Vector4[] value)
		{
			this.m_Implementation.SerializeValue(ref value);
		}

		// Token: 0x0600065A RID: 1626 RVA: 0x0001C634 File Offset: 0x0001A834
		public void SerializeValue(ref Quaternion value)
		{
			this.m_Implementation.SerializeValue(ref value);
		}

		// Token: 0x0600065B RID: 1627 RVA: 0x0001C648 File Offset: 0x0001A848
		public void SerializeValue(ref Quaternion[] value)
		{
			this.m_Implementation.SerializeValue(ref value);
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x0001C65C File Offset: 0x0001A85C
		public void SerializeValue(ref Color value)
		{
			this.m_Implementation.SerializeValue(ref value);
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x0001C670 File Offset: 0x0001A870
		public void SerializeValue(ref Color[] value)
		{
			this.m_Implementation.SerializeValue(ref value);
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x0001C684 File Offset: 0x0001A884
		public void SerializeValue(ref Color32 value)
		{
			this.m_Implementation.SerializeValue(ref value);
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x0001C698 File Offset: 0x0001A898
		public void SerializeValue(ref Color32[] value)
		{
			this.m_Implementation.SerializeValue(ref value);
		}

		// Token: 0x06000660 RID: 1632 RVA: 0x0001C6AC File Offset: 0x0001A8AC
		public void SerializeValue(ref Ray value)
		{
			this.m_Implementation.SerializeValue(ref value);
		}

		// Token: 0x06000661 RID: 1633 RVA: 0x0001C6C0 File Offset: 0x0001A8C0
		public void SerializeValue(ref Ray[] value)
		{
			this.m_Implementation.SerializeValue(ref value);
		}

		// Token: 0x06000662 RID: 1634 RVA: 0x0001C6D4 File Offset: 0x0001A8D4
		public void SerializeValue(ref Ray2D value)
		{
			this.m_Implementation.SerializeValue(ref value);
		}

		// Token: 0x06000663 RID: 1635 RVA: 0x0001C6E8 File Offset: 0x0001A8E8
		public void SerializeValue(ref Ray2D[] value)
		{
			this.m_Implementation.SerializeValue(ref value);
		}

		// Token: 0x06000664 RID: 1636 RVA: 0x0001C6FC File Offset: 0x0001A8FC
		public void SerializeValue<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForFixedStrings unused = default(FastBufferWriter.ForFixedStrings)) where T : struct, ValueType, INativeList<byte>, IUTF8Bytes
		{
			this.m_Implementation.SerializeValue<T>(ref value, default(FastBufferWriter.ForFixedStrings));
		}

		// Token: 0x06000665 RID: 1637 RVA: 0x0001C724 File Offset: 0x0001A924
		public void SerializeValue<[IsUnmanaged] T>(ref NativeArray<T> value, Allocator allocator) where T : struct, ValueType, INativeList<byte>, IUTF8Bytes
		{
			this.m_Implementation.SerializeValue<T>(ref value, allocator);
		}

		// Token: 0x06000666 RID: 1638 RVA: 0x0001C739 File Offset: 0x0001A939
		public void SerializeNetworkSerializable<T>(ref T value) where T : INetworkSerializable, new()
		{
			this.m_Implementation.SerializeNetworkSerializable<T>(ref value);
		}

		// Token: 0x06000667 RID: 1639 RVA: 0x0001C74D File Offset: 0x0001A94D
		public bool PreCheck(int amount)
		{
			return this.m_Implementation.PreCheck(amount);
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x0001C761 File Offset: 0x0001A961
		public void SerializeValuePreChecked(ref string s, bool oneByteChars = false)
		{
			this.m_Implementation.SerializeValuePreChecked(ref s, oneByteChars);
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x0001C776 File Offset: 0x0001A976
		public void SerializeValuePreChecked(ref byte value)
		{
			this.m_Implementation.SerializeValuePreChecked(ref value);
		}

		// Token: 0x0600066A RID: 1642 RVA: 0x0001C78C File Offset: 0x0001A98C
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForPrimitives unused = default(FastBufferWriter.ForPrimitives)) where T : struct, ValueType, IComparable, IConvertible, IComparable<T>, IEquatable<T>
		{
			this.m_Implementation.SerializeValuePreChecked<T>(ref value, default(FastBufferWriter.ForPrimitives));
		}

		// Token: 0x0600066B RID: 1643 RVA: 0x0001C7B4 File Offset: 0x0001A9B4
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref T[] value, FastBufferWriter.ForPrimitives unused = default(FastBufferWriter.ForPrimitives)) where T : struct, ValueType, IComparable, IConvertible, IComparable<T>, IEquatable<T>
		{
			this.m_Implementation.SerializeValuePreChecked<T>(ref value, default(FastBufferWriter.ForPrimitives));
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x0001C7DC File Offset: 0x0001A9DC
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForEnums unused = default(FastBufferWriter.ForEnums)) where T : struct, ValueType, Enum
		{
			this.m_Implementation.SerializeValuePreChecked<T>(ref value, default(FastBufferWriter.ForEnums));
		}

		// Token: 0x0600066D RID: 1645 RVA: 0x0001C804 File Offset: 0x0001AA04
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref T[] value, FastBufferWriter.ForEnums unused = default(FastBufferWriter.ForEnums)) where T : struct, ValueType, Enum
		{
			this.m_Implementation.SerializeValuePreChecked<T>(ref value, default(FastBufferWriter.ForEnums));
		}

		// Token: 0x0600066E RID: 1646 RVA: 0x0001C82C File Offset: 0x0001AA2C
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForStructs unused = default(FastBufferWriter.ForStructs)) where T : struct, ValueType, INetworkSerializeByMemcpy
		{
			this.m_Implementation.SerializeValuePreChecked<T>(ref value, default(FastBufferWriter.ForStructs));
		}

		// Token: 0x0600066F RID: 1647 RVA: 0x0001C854 File Offset: 0x0001AA54
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref T[] value, FastBufferWriter.ForStructs unused = default(FastBufferWriter.ForStructs)) where T : struct, ValueType, INetworkSerializeByMemcpy
		{
			this.m_Implementation.SerializeValuePreChecked<T>(ref value, default(FastBufferWriter.ForStructs));
		}

		// Token: 0x06000670 RID: 1648 RVA: 0x0001C87C File Offset: 0x0001AA7C
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref NativeArray<T> value, Allocator allocator, FastBufferWriter.ForGeneric unused = default(FastBufferWriter.ForGeneric)) where T : struct, ValueType
		{
			this.m_Implementation.SerializeValuePreChecked<T>(ref value, allocator, default(FastBufferWriter.ForGeneric));
		}

		// Token: 0x06000671 RID: 1649 RVA: 0x0001C8A5 File Offset: 0x0001AAA5
		public void SerializeValuePreChecked(ref Vector2 value)
		{
			this.m_Implementation.SerializeValuePreChecked(ref value);
		}

		// Token: 0x06000672 RID: 1650 RVA: 0x0001C8B9 File Offset: 0x0001AAB9
		public void SerializeValuePreChecked(ref Vector2[] value)
		{
			this.m_Implementation.SerializeValuePreChecked(ref value);
		}

		// Token: 0x06000673 RID: 1651 RVA: 0x0001C8CD File Offset: 0x0001AACD
		public void SerializeValuePreChecked(ref Vector3 value)
		{
			this.m_Implementation.SerializeValuePreChecked(ref value);
		}

		// Token: 0x06000674 RID: 1652 RVA: 0x0001C8E1 File Offset: 0x0001AAE1
		public void SerializeValuePreChecked(ref Vector3[] value)
		{
			this.m_Implementation.SerializeValuePreChecked(ref value);
		}

		// Token: 0x06000675 RID: 1653 RVA: 0x0001C8F5 File Offset: 0x0001AAF5
		public void SerializeValuePreChecked(ref Vector2Int value)
		{
			this.m_Implementation.SerializeValuePreChecked(ref value);
		}

		// Token: 0x06000676 RID: 1654 RVA: 0x0001C909 File Offset: 0x0001AB09
		public void SerializeValuePreChecked(ref Vector2Int[] value)
		{
			this.m_Implementation.SerializeValuePreChecked(ref value);
		}

		// Token: 0x06000677 RID: 1655 RVA: 0x0001C91D File Offset: 0x0001AB1D
		public void SerializeValuePreChecked(ref Vector3Int value)
		{
			this.m_Implementation.SerializeValuePreChecked(ref value);
		}

		// Token: 0x06000678 RID: 1656 RVA: 0x0001C931 File Offset: 0x0001AB31
		public void SerializeValuePreChecked(ref Vector3Int[] value)
		{
			this.m_Implementation.SerializeValuePreChecked(ref value);
		}

		// Token: 0x06000679 RID: 1657 RVA: 0x0001C945 File Offset: 0x0001AB45
		public void SerializeValuePreChecked(ref Vector4 value)
		{
			this.m_Implementation.SerializeValuePreChecked(ref value);
		}

		// Token: 0x0600067A RID: 1658 RVA: 0x0001C959 File Offset: 0x0001AB59
		public void SerializeValuePreChecked(ref Vector4[] value)
		{
			this.m_Implementation.SerializeValuePreChecked(ref value);
		}

		// Token: 0x0600067B RID: 1659 RVA: 0x0001C96D File Offset: 0x0001AB6D
		public void SerializeValuePreChecked(ref Quaternion value)
		{
			this.m_Implementation.SerializeValuePreChecked(ref value);
		}

		// Token: 0x0600067C RID: 1660 RVA: 0x0001C981 File Offset: 0x0001AB81
		public void SerializeValuePreChecked(ref Quaternion[] value)
		{
			this.m_Implementation.SerializeValuePreChecked(ref value);
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x0001C995 File Offset: 0x0001AB95
		public void SerializeValuePreChecked(ref Color value)
		{
			this.m_Implementation.SerializeValuePreChecked(ref value);
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x0001C9A9 File Offset: 0x0001ABA9
		public void SerializeValuePreChecked(ref Color[] value)
		{
			this.m_Implementation.SerializeValuePreChecked(ref value);
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x0001C9BD File Offset: 0x0001ABBD
		public void SerializeValuePreChecked(ref Color32 value)
		{
			this.m_Implementation.SerializeValuePreChecked(ref value);
		}

		// Token: 0x06000680 RID: 1664 RVA: 0x0001C9D1 File Offset: 0x0001ABD1
		public void SerializeValuePreChecked(ref Color32[] value)
		{
			this.m_Implementation.SerializeValuePreChecked(ref value);
		}

		// Token: 0x06000681 RID: 1665 RVA: 0x0001C9E5 File Offset: 0x0001ABE5
		public void SerializeValuePreChecked(ref Ray value)
		{
			this.m_Implementation.SerializeValuePreChecked(ref value);
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x0001C9F9 File Offset: 0x0001ABF9
		public void SerializeValuePreChecked(ref Ray[] value)
		{
			this.m_Implementation.SerializeValuePreChecked(ref value);
		}

		// Token: 0x06000683 RID: 1667 RVA: 0x0001CA0D File Offset: 0x0001AC0D
		public void SerializeValuePreChecked(ref Ray2D value)
		{
			this.m_Implementation.SerializeValuePreChecked(ref value);
		}

		// Token: 0x06000684 RID: 1668 RVA: 0x0001CA21 File Offset: 0x0001AC21
		public void SerializeValuePreChecked(ref Ray2D[] value)
		{
			this.m_Implementation.SerializeValuePreChecked(ref value);
		}

		// Token: 0x06000685 RID: 1669 RVA: 0x0001CA38 File Offset: 0x0001AC38
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForFixedStrings unused = default(FastBufferWriter.ForFixedStrings)) where T : struct, ValueType, INativeList<byte>, IUTF8Bytes
		{
			this.m_Implementation.SerializeValuePreChecked<T>(ref value, default(FastBufferWriter.ForFixedStrings));
		}

		// Token: 0x0400030D RID: 781
		private TReaderWriter m_Implementation;
	}
}
