using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x0200010D RID: 269
	public interface IReaderWriter
	{
		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600083D RID: 2109
		bool IsReader { get; }

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x0600083E RID: 2110
		bool IsWriter { get; }

		// Token: 0x0600083F RID: 2111
		FastBufferReader GetFastBufferReader();

		// Token: 0x06000840 RID: 2112
		FastBufferWriter GetFastBufferWriter();

		// Token: 0x06000841 RID: 2113
		void SerializeValue(ref string s, bool oneByteChars = false);

		// Token: 0x06000842 RID: 2114
		void SerializeValue(ref byte value);

		// Token: 0x06000843 RID: 2115
		void SerializeValue<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForPrimitives unused = default(FastBufferWriter.ForPrimitives)) where T : struct, ValueType, IComparable, IConvertible, IComparable<T>, IEquatable<T>;

		// Token: 0x06000844 RID: 2116
		void SerializeValue<[IsUnmanaged] T>(ref T[] value, FastBufferWriter.ForPrimitives unused = default(FastBufferWriter.ForPrimitives)) where T : struct, ValueType, IComparable, IConvertible, IComparable<T>, IEquatable<T>;

		// Token: 0x06000845 RID: 2117
		void SerializeValue<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForEnums unused = default(FastBufferWriter.ForEnums)) where T : struct, ValueType, Enum;

		// Token: 0x06000846 RID: 2118
		void SerializeValue<[IsUnmanaged] T>(ref T[] value, FastBufferWriter.ForEnums unused = default(FastBufferWriter.ForEnums)) where T : struct, ValueType, Enum;

		// Token: 0x06000847 RID: 2119
		void SerializeValue<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForStructs unused = default(FastBufferWriter.ForStructs)) where T : struct, ValueType, INetworkSerializeByMemcpy;

		// Token: 0x06000848 RID: 2120
		void SerializeValue<[IsUnmanaged] T>(ref T[] value, FastBufferWriter.ForStructs unused = default(FastBufferWriter.ForStructs)) where T : struct, ValueType, INetworkSerializeByMemcpy;

		// Token: 0x06000849 RID: 2121
		void SerializeValue<[IsUnmanaged] T>(ref NativeArray<T> value, Allocator allocator, FastBufferWriter.ForGeneric unused = default(FastBufferWriter.ForGeneric)) where T : struct, ValueType;

		// Token: 0x0600084A RID: 2122
		void SerializeValue<T>(ref T value, FastBufferWriter.ForNetworkSerializable unused = default(FastBufferWriter.ForNetworkSerializable)) where T : INetworkSerializable, new();

		// Token: 0x0600084B RID: 2123
		void SerializeValue<T>(ref T[] value, FastBufferWriter.ForNetworkSerializable unused = default(FastBufferWriter.ForNetworkSerializable)) where T : INetworkSerializable, new();

		// Token: 0x0600084C RID: 2124
		void SerializeValue<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForFixedStrings unused = default(FastBufferWriter.ForFixedStrings)) where T : struct, ValueType, INativeList<byte>, IUTF8Bytes;

		// Token: 0x0600084D RID: 2125
		void SerializeValue<[IsUnmanaged] T>(ref NativeArray<T> value, Allocator allocator) where T : struct, ValueType, INativeList<byte>, IUTF8Bytes;

		// Token: 0x0600084E RID: 2126
		void SerializeValue(ref Vector2 value);

		// Token: 0x0600084F RID: 2127
		void SerializeValue(ref Vector2[] value);

		// Token: 0x06000850 RID: 2128
		void SerializeValue(ref Vector3 value);

		// Token: 0x06000851 RID: 2129
		void SerializeValue(ref Vector3[] value);

		// Token: 0x06000852 RID: 2130
		void SerializeValue(ref Vector2Int value);

		// Token: 0x06000853 RID: 2131
		void SerializeValue(ref Vector2Int[] value);

		// Token: 0x06000854 RID: 2132
		void SerializeValue(ref Vector3Int value);

		// Token: 0x06000855 RID: 2133
		void SerializeValue(ref Vector3Int[] value);

		// Token: 0x06000856 RID: 2134
		void SerializeValue(ref Vector4 value);

		// Token: 0x06000857 RID: 2135
		void SerializeValue(ref Vector4[] value);

		// Token: 0x06000858 RID: 2136
		void SerializeValue(ref Quaternion value);

		// Token: 0x06000859 RID: 2137
		void SerializeValue(ref Quaternion[] value);

		// Token: 0x0600085A RID: 2138
		void SerializeValue(ref Color value);

		// Token: 0x0600085B RID: 2139
		void SerializeValue(ref Color[] value);

		// Token: 0x0600085C RID: 2140
		void SerializeValue(ref Color32 value);

		// Token: 0x0600085D RID: 2141
		void SerializeValue(ref Color32[] value);

		// Token: 0x0600085E RID: 2142
		void SerializeValue(ref Ray value);

		// Token: 0x0600085F RID: 2143
		void SerializeValue(ref Ray[] value);

		// Token: 0x06000860 RID: 2144
		void SerializeValue(ref Ray2D value);

		// Token: 0x06000861 RID: 2145
		void SerializeValue(ref Ray2D[] value);

		// Token: 0x06000862 RID: 2146
		void SerializeNetworkSerializable<T>(ref T value) where T : INetworkSerializable, new();

		// Token: 0x06000863 RID: 2147
		bool PreCheck(int amount);

		// Token: 0x06000864 RID: 2148
		void SerializeValuePreChecked(ref string s, bool oneByteChars = false);

		// Token: 0x06000865 RID: 2149
		void SerializeValuePreChecked(ref byte value);

		// Token: 0x06000866 RID: 2150
		void SerializeValuePreChecked<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForPrimitives unused = default(FastBufferWriter.ForPrimitives)) where T : struct, ValueType, IComparable, IConvertible, IComparable<T>, IEquatable<T>;

		// Token: 0x06000867 RID: 2151
		void SerializeValuePreChecked<[IsUnmanaged] T>(ref T[] value, FastBufferWriter.ForPrimitives unused = default(FastBufferWriter.ForPrimitives)) where T : struct, ValueType, IComparable, IConvertible, IComparable<T>, IEquatable<T>;

		// Token: 0x06000868 RID: 2152
		void SerializeValuePreChecked<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForEnums unused = default(FastBufferWriter.ForEnums)) where T : struct, ValueType, Enum;

		// Token: 0x06000869 RID: 2153
		void SerializeValuePreChecked<[IsUnmanaged] T>(ref T[] value, FastBufferWriter.ForEnums unused = default(FastBufferWriter.ForEnums)) where T : struct, ValueType, Enum;

		// Token: 0x0600086A RID: 2154
		void SerializeValuePreChecked<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForStructs unused = default(FastBufferWriter.ForStructs)) where T : struct, ValueType, INetworkSerializeByMemcpy;

		// Token: 0x0600086B RID: 2155
		void SerializeValuePreChecked<[IsUnmanaged] T>(ref T[] value, FastBufferWriter.ForStructs unused = default(FastBufferWriter.ForStructs)) where T : struct, ValueType, INetworkSerializeByMemcpy;

		// Token: 0x0600086C RID: 2156
		void SerializeValuePreChecked<[IsUnmanaged] T>(ref NativeArray<T> value, Allocator allocator, FastBufferWriter.ForGeneric unused = default(FastBufferWriter.ForGeneric)) where T : struct, ValueType;

		// Token: 0x0600086D RID: 2157
		void SerializeValuePreChecked<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForFixedStrings unused = default(FastBufferWriter.ForFixedStrings)) where T : struct, ValueType, INativeList<byte>, IUTF8Bytes;

		// Token: 0x0600086E RID: 2158
		void SerializeValuePreChecked(ref Vector2 value);

		// Token: 0x0600086F RID: 2159
		void SerializeValuePreChecked(ref Vector2[] value);

		// Token: 0x06000870 RID: 2160
		void SerializeValuePreChecked(ref Vector3 value);

		// Token: 0x06000871 RID: 2161
		void SerializeValuePreChecked(ref Vector3[] value);

		// Token: 0x06000872 RID: 2162
		void SerializeValuePreChecked(ref Vector2Int value);

		// Token: 0x06000873 RID: 2163
		void SerializeValuePreChecked(ref Vector2Int[] value);

		// Token: 0x06000874 RID: 2164
		void SerializeValuePreChecked(ref Vector3Int value);

		// Token: 0x06000875 RID: 2165
		void SerializeValuePreChecked(ref Vector3Int[] value);

		// Token: 0x06000876 RID: 2166
		void SerializeValuePreChecked(ref Vector4 value);

		// Token: 0x06000877 RID: 2167
		void SerializeValuePreChecked(ref Vector4[] value);

		// Token: 0x06000878 RID: 2168
		void SerializeValuePreChecked(ref Quaternion value);

		// Token: 0x06000879 RID: 2169
		void SerializeValuePreChecked(ref Quaternion[] value);

		// Token: 0x0600087A RID: 2170
		void SerializeValuePreChecked(ref Color value);

		// Token: 0x0600087B RID: 2171
		void SerializeValuePreChecked(ref Color[] value);

		// Token: 0x0600087C RID: 2172
		void SerializeValuePreChecked(ref Color32 value);

		// Token: 0x0600087D RID: 2173
		void SerializeValuePreChecked(ref Color32[] value);

		// Token: 0x0600087E RID: 2174
		void SerializeValuePreChecked(ref Ray value);

		// Token: 0x0600087F RID: 2175
		void SerializeValuePreChecked(ref Ray[] value);

		// Token: 0x06000880 RID: 2176
		void SerializeValuePreChecked(ref Ray2D value);

		// Token: 0x06000881 RID: 2177
		void SerializeValuePreChecked(ref Ray2D[] value);
	}
}
