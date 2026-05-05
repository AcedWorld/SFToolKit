using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x020000D5 RID: 213
	public static class NetworkVariableSerializationTypes
	{
		// Token: 0x060004FD RID: 1277 RVA: 0x0001555C File Offset: 0x0001375C
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		internal static void InitializeIntegerSerialization()
		{
			NetworkVariableSerialization<short>.Serializer = new ShortSerializer();
			NetworkVariableSerialization<short>.AreEqual = new NetworkVariableSerialization<short>.EqualsDelegate(NetworkVariableSerialization<short>.ValueEquals<short>);
			NetworkVariableSerialization<ushort>.Serializer = new UshortSerializer();
			NetworkVariableSerialization<ushort>.AreEqual = new NetworkVariableSerialization<ushort>.EqualsDelegate(NetworkVariableSerialization<ushort>.ValueEquals<ushort>);
			NetworkVariableSerialization<int>.Serializer = new IntSerializer();
			NetworkVariableSerialization<int>.AreEqual = new NetworkVariableSerialization<int>.EqualsDelegate(NetworkVariableSerialization<int>.ValueEquals<int>);
			NetworkVariableSerialization<uint>.Serializer = new UintSerializer();
			NetworkVariableSerialization<uint>.AreEqual = new NetworkVariableSerialization<uint>.EqualsDelegate(NetworkVariableSerialization<uint>.ValueEquals<uint>);
			NetworkVariableSerialization<long>.Serializer = new LongSerializer();
			NetworkVariableSerialization<long>.AreEqual = new NetworkVariableSerialization<long>.EqualsDelegate(NetworkVariableSerialization<long>.ValueEquals<long>);
			NetworkVariableSerialization<ulong>.Serializer = new UlongSerializer();
			NetworkVariableSerialization<ulong>.AreEqual = new NetworkVariableSerialization<ulong>.EqualsDelegate(NetworkVariableSerialization<ulong>.ValueEquals<ulong>);
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x0001560B File Offset: 0x0001380B
		public static void InitializeSerializer_UnmanagedByMemcpy<[IsUnmanaged] T>() where T : struct, ValueType
		{
			NetworkVariableSerialization<T>.Serializer = new UnmanagedTypeSerializer<T>();
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x00015617 File Offset: 0x00013817
		public static void InitializeSerializer_UnmanagedByMemcpyArray<[IsUnmanaged] T>() where T : struct, ValueType
		{
			NetworkVariableSerialization<NativeArray<T>>.Serializer = new UnmanagedArraySerializer<T>();
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x00015623 File Offset: 0x00013823
		public static void InitializeSerializer_List<T>()
		{
			NetworkVariableSerialization<List<T>>.Serializer = new ListSerializer<T>();
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x0001562F File Offset: 0x0001382F
		public static void InitializeSerializer_HashSet<T>() where T : IEquatable<T>
		{
			NetworkVariableSerialization<HashSet<T>>.Serializer = new HashSetSerializer<T>();
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x0001563B File Offset: 0x0001383B
		public static void InitializeSerializer_Dictionary<TKey, TVal>() where TKey : IEquatable<TKey>
		{
			NetworkVariableSerialization<Dictionary<TKey, TVal>>.Serializer = new DictionarySerializer<TKey, TVal>();
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x00015647 File Offset: 0x00013847
		public static void InitializeSerializer_UnmanagedINetworkSerializable<[IsUnmanaged] T>() where T : struct, ValueType, INetworkSerializable
		{
			NetworkVariableSerialization<T>.Serializer = new UnmanagedNetworkSerializableSerializer<T>();
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x00015653 File Offset: 0x00013853
		public static void InitializeSerializer_UnmanagedINetworkSerializableArray<[IsUnmanaged] T>() where T : struct, ValueType, INetworkSerializable
		{
			NetworkVariableSerialization<NativeArray<T>>.Serializer = new UnmanagedNetworkSerializableArraySerializer<T>();
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x0001565F File Offset: 0x0001385F
		public static void InitializeSerializer_ManagedINetworkSerializable<T>() where T : class, INetworkSerializable, new()
		{
			NetworkVariableSerialization<T>.Serializer = new ManagedNetworkSerializableSerializer<T>();
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x0001566B File Offset: 0x0001386B
		public static void InitializeSerializer_FixedString<[IsUnmanaged] T>() where T : struct, ValueType, INativeList<byte>, IUTF8Bytes
		{
			NetworkVariableSerialization<T>.Serializer = new FixedStringSerializer<T>();
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x00015677 File Offset: 0x00013877
		public static void InitializeSerializer_FixedStringArray<[IsUnmanaged] T>() where T : struct, ValueType, INativeList<byte>, IUTF8Bytes
		{
			NetworkVariableSerialization<NativeArray<T>>.Serializer = new FixedStringArraySerializer<T>();
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x00015683 File Offset: 0x00013883
		public static void InitializeEqualityChecker_ManagedIEquatable<T>() where T : class, IEquatable<T>
		{
			NetworkVariableSerialization<T>.AreEqual = new NetworkVariableSerialization<T>.EqualsDelegate(NetworkVariableSerialization<T>.EqualityEqualsObject<T>);
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x00015696 File Offset: 0x00013896
		public static void InitializeEqualityChecker_UnmanagedIEquatable<[IsUnmanaged] T>() where T : struct, ValueType, IEquatable<T>
		{
			NetworkVariableSerialization<T>.AreEqual = new NetworkVariableSerialization<T>.EqualsDelegate(NetworkVariableSerialization<T>.EqualityEquals<T>);
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x000156A9 File Offset: 0x000138A9
		public static void InitializeEqualityChecker_UnmanagedIEquatableArray<[IsUnmanaged] T>() where T : struct, ValueType, IEquatable<T>
		{
			NetworkVariableSerialization<NativeArray<T>>.AreEqual = new NetworkVariableSerialization<NativeArray<T>>.EqualsDelegate(NetworkVariableSerialization<T>.EqualityEqualsArray<T>);
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x000156BC File Offset: 0x000138BC
		public static void InitializeEqualityChecker_List<T>()
		{
			NetworkVariableSerialization<List<T>>.AreEqual = new NetworkVariableSerialization<List<T>>.EqualsDelegate(NetworkVariableSerialization<T>.EqualityEqualsList<T>);
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x000156CF File Offset: 0x000138CF
		public static void InitializeEqualityChecker_HashSet<T>() where T : IEquatable<T>
		{
			NetworkVariableSerialization<HashSet<T>>.AreEqual = new NetworkVariableSerialization<HashSet<T>>.EqualsDelegate(NetworkVariableSerialization<T>.EqualityEqualsHashSet<T>);
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x000156E2 File Offset: 0x000138E2
		public static void InitializeEqualityChecker_Dictionary<TKey, TVal>() where TKey : IEquatable<TKey>
		{
			NetworkVariableSerialization<Dictionary<TKey, TVal>>.AreEqual = new NetworkVariableSerialization<Dictionary<TKey, TVal>>.EqualsDelegate(NetworkVariableDictionarySerialization<TKey, TVal>.GenericEqualsDictionary);
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x000156F5 File Offset: 0x000138F5
		public static void InitializeEqualityChecker_UnmanagedValueEquals<[IsUnmanaged] T>() where T : struct, ValueType
		{
			NetworkVariableSerialization<T>.AreEqual = new NetworkVariableSerialization<T>.EqualsDelegate(NetworkVariableSerialization<T>.ValueEquals<T>);
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x00015708 File Offset: 0x00013908
		public static void InitializeEqualityChecker_UnmanagedValueEqualsArray<[IsUnmanaged] T>() where T : struct, ValueType
		{
			NetworkVariableSerialization<NativeArray<T>>.AreEqual = new NetworkVariableSerialization<NativeArray<T>>.EqualsDelegate(NetworkVariableSerialization<T>.ValueEqualsArray<T>);
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x0001571B File Offset: 0x0001391B
		public static void InitializeEqualityChecker_ManagedClassEquals<T>() where T : class
		{
			NetworkVariableSerialization<T>.AreEqual = new NetworkVariableSerialization<T>.EqualsDelegate(NetworkVariableSerialization<T>.ClassEquals<T>);
		}
	}
}
