using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Collections
{
	// Token: 0x0200008B RID: 139
	[BurstCompatible]
	public static class NativeArrayExtensions
	{
		// Token: 0x060005E4 RID: 1508 RVA: 0x000147B2 File Offset: 0x000129B2
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public static bool Contains<T, U>(this NativeArray<T> array, U value) where T : struct, IEquatable<U>
		{
			return NativeArrayExtensions.IndexOf<T, U>(array.GetUnsafeReadOnlyPtr<T>(), array.Length, value) != -1;
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x000147CD File Offset: 0x000129CD
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public static int IndexOf<T, U>(this NativeArray<T> array, U value) where T : struct, IEquatable<U>
		{
			return NativeArrayExtensions.IndexOf<T, U>(array.GetUnsafeReadOnlyPtr<T>(), array.Length, value);
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x000147E2 File Offset: 0x000129E2
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public static bool Contains<T, U>(this NativeArray<T>.ReadOnly array, U value) where T : struct, IEquatable<U>
		{
			return NativeArrayExtensions.IndexOf<T, U>(array.m_Buffer, array.m_Length, value) != -1;
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x000147FC File Offset: 0x000129FC
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public static int IndexOf<T, U>(this NativeArray<T>.ReadOnly array, U value) where T : struct, IEquatable<U>
		{
			return NativeArrayExtensions.IndexOf<T, U>(array.m_Buffer, array.m_Length, value);
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x00014810 File Offset: 0x00012A10
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public static bool Contains<[IsUnmanaged] T, U>(this NativeList<T> list, U value) where T : struct, ValueType, IEquatable<U>
		{
			return NativeArrayExtensions.IndexOf<T, U>(list.GetUnsafeReadOnlyPtr<T>(), list.Length, value) != -1;
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x0001482B File Offset: 0x00012A2B
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public static int IndexOf<[IsUnmanaged] T, U>(this NativeList<T> list, U value) where T : struct, ValueType, IEquatable<U>
		{
			return NativeArrayExtensions.IndexOf<T, U>(list.GetUnsafeReadOnlyPtr<T>(), list.Length, value);
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x00014840 File Offset: 0x00012A40
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public unsafe static bool Contains<T, U>(void* ptr, int length, U value) where T : struct, IEquatable<U>
		{
			return NativeArrayExtensions.IndexOf<T, U>(ptr, length, value) != -1;
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x00014850 File Offset: 0x00012A50
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public unsafe static int IndexOf<T, U>(void* ptr, int length, U value) where T : struct, IEquatable<U>
		{
			for (int num = 0; num != length; num++)
			{
				T t = UnsafeUtility.ReadArrayElement<T>(ptr, num);
				if (t.Equals(value))
				{
					return num;
				}
			}
			return -1;
		}

		// Token: 0x060005EC RID: 1516 RVA: 0x00014884 File Offset: 0x00012A84
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		public static NativeArray<U> Reinterpret<T, U>(this NativeArray<T> array) where T : struct where U : struct
		{
			int num = UnsafeUtility.SizeOf<T>();
			int num2 = UnsafeUtility.SizeOf<U>();
			long num3 = (long)array.Length * (long)num / (long)num2;
			return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<U>(NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks<T>(array), (int)num3, Allocator.None);
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x000148BC File Offset: 0x00012ABC
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public static bool ArraysEqual<T>(this NativeArray<T> array, NativeArray<T> other) where T : struct, IEquatable<T>
		{
			if (array.Length != other.Length)
			{
				return false;
			}
			for (int num = 0; num != array.Length; num++)
			{
				T t = array[num];
				if (!t.Equals(other[num]))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060005EE RID: 1518 RVA: 0x00014910 File Offset: 0x00012B10
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public static bool ArraysEqual<[IsUnmanaged] T>(this NativeList<T> array, NativeArray<T> other) where T : struct, ValueType, IEquatable<T>
		{
			return array.AsArray().ArraysEqual(other);
		}

		// Token: 0x060005EF RID: 1519 RVA: 0x00014920 File Offset: 0x00012B20
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckReinterpretSize<T, U>(ref NativeArray<T> array) where T : struct where U : struct
		{
			int num = UnsafeUtility.SizeOf<T>();
			int num2 = UnsafeUtility.SizeOf<U>();
			long num3 = (long)array.Length * (long)num;
			if (num3 / (long)num2 * (long)num2 != num3)
			{
				throw new InvalidOperationException(string.Format("Types {0} (array length {1}) and {2} cannot be aliased due to size constraints. The size of the types and lengths involved must line up.", typeof(T), array.Length, typeof(U)));
			}
		}

		// Token: 0x060005F0 RID: 1520 RVA: 0x00014980 File Offset: 0x00012B80
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		internal static void Initialize<T>(this NativeArray<T> array, int length, AllocatorManager.AllocatorHandle allocator, NativeArrayOptions options = NativeArrayOptions.UninitializedMemory) where T : struct
		{
			AllocatorManager.AllocatorHandle allocatorHandle = allocator;
			array.m_Buffer = ref allocatorHandle.AllocateStruct(default(T), length);
			array.m_Length = length;
			array.m_AllocatorLabel = Allocator.None;
			if (options == NativeArrayOptions.ClearMemory)
			{
				UnsafeUtility.MemClear(array.m_Buffer, (long)(array.m_Length * UnsafeUtility.SizeOf<T>()));
			}
		}

		// Token: 0x060005F1 RID: 1521 RVA: 0x000149D0 File Offset: 0x00012BD0
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(AllocatorManager.AllocatorHandle)
		})]
		internal static void Initialize<T, [IsUnmanaged] U>(this NativeArray<T> array, int length, ref U allocator, NativeArrayOptions options = NativeArrayOptions.ClearMemory) where T : struct where U : struct, ValueType, AllocatorManager.IAllocator
		{
			array.m_Buffer = ref allocator.AllocateStruct(default(T), length);
			array.m_Length = length;
			array.m_AllocatorLabel = Allocator.None;
			if (options == NativeArrayOptions.ClearMemory)
			{
				UnsafeUtility.MemClear(array.m_Buffer, (long)(array.m_Length * UnsafeUtility.SizeOf<T>()));
			}
		}

		// Token: 0x0200008C RID: 140
		public struct NativeArrayStaticId<T> where T : struct
		{
			// Token: 0x04000267 RID: 615
			internal static readonly SharedStatic<int> s_staticSafetyId = SharedStatic<int>.GetOrCreate<NativeArray<T>>(0U);
		}
	}
}
