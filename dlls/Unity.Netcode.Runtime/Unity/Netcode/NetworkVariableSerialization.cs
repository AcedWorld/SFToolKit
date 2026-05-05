using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Netcode
{
	// Token: 0x020000D6 RID: 214
	[Serializable]
	public static class NetworkVariableSerialization<T>
	{
		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000511 RID: 1297 RVA: 0x0001572E File Offset: 0x0001392E
		// (set) Token: 0x06000512 RID: 1298 RVA: 0x00015735 File Offset: 0x00013935
		public static NetworkVariableSerialization<T>.EqualsDelegate AreEqual { get; internal set; }

		// Token: 0x06000513 RID: 1299 RVA: 0x0001573D File Offset: 0x0001393D
		public static void Write(FastBufferWriter writer, ref T value)
		{
			NetworkVariableSerialization<T>.Serializer.Write(writer, ref value);
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x0001574B File Offset: 0x0001394B
		public static void Read(FastBufferReader reader, ref T value)
		{
			NetworkVariableSerialization<T>.Serializer.Read(reader, ref value);
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x00015759 File Offset: 0x00013959
		public static void WriteDelta(FastBufferWriter writer, ref T value, ref T previousValue)
		{
			NetworkVariableSerialization<T>.Serializer.WriteDelta(writer, ref value, ref previousValue);
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x00015768 File Offset: 0x00013968
		public static void ReadDelta(FastBufferReader reader, ref T value)
		{
			NetworkVariableSerialization<T>.Serializer.ReadDelta(reader, ref value);
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x00015776 File Offset: 0x00013976
		public static void Duplicate(in T value, ref T duplicatedValue)
		{
			NetworkVariableSerialization<T>.Serializer.Duplicate(value, ref duplicatedValue);
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x00015784 File Offset: 0x00013984
		internal unsafe static bool ValueEquals<[IsUnmanaged] TValueType>(ref TValueType a, ref TValueType b) where TValueType : struct, ValueType
		{
			void* ptr = UnsafeUtility.AddressOf<TValueType>(ref a);
			void* ptr2 = UnsafeUtility.AddressOf<TValueType>(ref b);
			return UnsafeUtility.MemCmp(ptr, ptr2, (long)sizeof(TValueType)) == 0;
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x000157B0 File Offset: 0x000139B0
		internal unsafe static bool ValueEqualsArray<[IsUnmanaged] TValueType>(ref NativeArray<TValueType> a, ref NativeArray<TValueType> b) where TValueType : struct, ValueType
		{
			if (a.IsCreated != b.IsCreated)
			{
				return false;
			}
			if (!a.IsCreated)
			{
				return true;
			}
			if (a.Length != b.Length)
			{
				return false;
			}
			TValueType* unsafePtr = (TValueType*)a.GetUnsafePtr<TValueType>();
			TValueType* unsafePtr2 = (TValueType*)b.GetUnsafePtr<TValueType>();
			return UnsafeUtility.MemCmp((void*)unsafePtr, (void*)unsafePtr2, (long)(sizeof(TValueType) * a.Length)) == 0;
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x00015817 File Offset: 0x00013A17
		internal static bool EqualityEqualsObject<TValueType>(ref TValueType a, ref TValueType b) where TValueType : class, IEquatable<TValueType>
		{
			if (a == null)
			{
				return b == null;
			}
			return b != null && a.Equals(b);
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x00015856 File Offset: 0x00013A56
		internal static bool EqualityEquals<[IsUnmanaged] TValueType>(ref TValueType a, ref TValueType b) where TValueType : struct, ValueType, IEquatable<TValueType>
		{
			return a.Equals(b);
		}

		// Token: 0x0600051C RID: 1308 RVA: 0x0001586C File Offset: 0x00013A6C
		internal static bool EqualityEqualsList<TValueType>(ref List<TValueType> a, ref List<TValueType> b)
		{
			if (a == null != (b == null))
			{
				return false;
			}
			if (a == null)
			{
				return true;
			}
			if (a.Count != b.Count)
			{
				return false;
			}
			for (int i = 0; i < a.Count; i++)
			{
				TValueType tvalueType = a[i];
				TValueType tvalueType2 = b[i];
				if (!NetworkVariableSerialization<TValueType>.AreEqual(ref tvalueType, ref tvalueType2))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x000158D8 File Offset: 0x00013AD8
		internal static bool EqualityEqualsHashSet<TValueType>(ref HashSet<TValueType> a, ref HashSet<TValueType> b) where TValueType : IEquatable<TValueType>
		{
			if (a == null != (b == null))
			{
				return false;
			}
			if (a == null)
			{
				return true;
			}
			if (a.Count != b.Count)
			{
				return false;
			}
			foreach (TValueType item in a)
			{
				if (!b.Contains(item))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x00015958 File Offset: 0x00013B58
		internal unsafe static bool EqualityEqualsArray<[IsUnmanaged] TValueType>(ref NativeArray<TValueType> a, ref NativeArray<TValueType> b) where TValueType : struct, ValueType, IEquatable<TValueType>
		{
			if (a.IsCreated != b.IsCreated)
			{
				return false;
			}
			if (!a.IsCreated)
			{
				return true;
			}
			if (a.Length != b.Length)
			{
				return false;
			}
			TValueType* unsafePtr = (TValueType*)a.GetUnsafePtr<TValueType>();
			TValueType* unsafePtr2 = (TValueType*)b.GetUnsafePtr<TValueType>();
			for (int i = 0; i < a.Length; i++)
			{
				if (!NetworkVariableSerialization<T>.EqualityEquals<TValueType>(ref unsafePtr[(IntPtr)i * (IntPtr)sizeof(TValueType) / (IntPtr)sizeof(TValueType)], ref unsafePtr2[(IntPtr)i * (IntPtr)sizeof(TValueType) / (IntPtr)sizeof(TValueType)]))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x000159D8 File Offset: 0x00013BD8
		internal static bool ClassEquals<TValueType>(ref TValueType a, ref TValueType b) where TValueType : class
		{
			return a == b;
		}

		// Token: 0x0400026A RID: 618
		internal static INetworkVariableSerializer<T> Serializer = new FallbackSerializer<T>();

		// Token: 0x020000D7 RID: 215
		// (Invoke) Token: 0x06000522 RID: 1314
		public delegate bool EqualsDelegate(ref T a, ref T b);
	}
}
