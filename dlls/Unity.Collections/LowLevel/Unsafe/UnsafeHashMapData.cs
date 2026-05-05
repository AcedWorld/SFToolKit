using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x020000F5 RID: 245
	[BurstCompatible]
	[StructLayout(LayoutKind.Explicit)]
	internal struct UnsafeHashMapData
	{
		// Token: 0x0600098E RID: 2446 RVA: 0x0001E44F File Offset: 0x0001C64F
		internal static int GetBucketSize(int capacity)
		{
			return capacity * 2;
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x0001E454 File Offset: 0x0001C654
		internal static int GrowCapacity(int capacity)
		{
			if (capacity == 0)
			{
				return 1;
			}
			return capacity * 2;
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x0001E460 File Offset: 0x0001C660
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		internal unsafe static void AllocateHashMap<TKey, TValue>(int length, int bucketLength, AllocatorManager.AllocatorHandle label, out UnsafeHashMapData* outBuf) where TKey : struct where TValue : struct
		{
			UnsafeHashMapData* ptr = (UnsafeHashMapData*)Memory.Unmanaged.Allocate((long)sizeof(UnsafeHashMapData), UnsafeUtility.AlignOf<UnsafeHashMapData>(), label);
			bucketLength = math.ceilpow2(bucketLength);
			ptr->keyCapacity = length;
			ptr->bucketCapacityMask = bucketLength - 1;
			int num2;
			int num3;
			int num4;
			int num = UnsafeHashMapData.CalculateDataSize<TKey, TValue>(length, bucketLength, out num2, out num3, out num4);
			ptr->values = (byte*)Memory.Unmanaged.Allocate((long)num, 64, label);
			ptr->keys = ptr->values + num2;
			ptr->next = ptr->values + num3;
			ptr->buckets = ptr->values + num4;
			outBuf = ptr;
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x0001E4E8 File Offset: 0x0001C6E8
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		internal unsafe static void ReallocateHashMap<TKey, TValue>(UnsafeHashMapData* data, int newCapacity, int newBucketCapacity, AllocatorManager.AllocatorHandle label) where TKey : struct where TValue : struct
		{
			newBucketCapacity = math.ceilpow2(newBucketCapacity);
			if (data->keyCapacity == newCapacity && data->bucketCapacityMask + 1 == newBucketCapacity)
			{
				return;
			}
			int num;
			int num2;
			int num3;
			byte* ptr = (byte*)Memory.Unmanaged.Allocate((long)UnsafeHashMapData.CalculateDataSize<TKey, TValue>(newCapacity, newBucketCapacity, out num, out num2, out num3), 64, label);
			byte* destination = ptr + num;
			byte* ptr2 = ptr + num2;
			byte* ptr3 = ptr + num3;
			UnsafeUtility.MemCpy((void*)ptr, (void*)data->values, (long)(data->keyCapacity * UnsafeUtility.SizeOf<TValue>()));
			UnsafeUtility.MemCpy((void*)destination, (void*)data->keys, (long)(data->keyCapacity * UnsafeUtility.SizeOf<TKey>()));
			UnsafeUtility.MemCpy((void*)ptr2, (void*)data->next, (long)(data->keyCapacity * UnsafeUtility.SizeOf<int>()));
			for (int i = data->keyCapacity; i < newCapacity; i++)
			{
				*(int*)(ptr2 + (IntPtr)i * 4) = -1;
			}
			for (int j = 0; j < newBucketCapacity; j++)
			{
				*(int*)(ptr3 + (IntPtr)j * 4) = -1;
			}
			for (int k = 0; k <= data->bucketCapacityMask; k++)
			{
				int* ptr4 = (int*)data->buckets;
				int* ptr5 = (int*)ptr2;
				while (ptr4[k] >= 0)
				{
					int num4 = ptr4[k];
					ptr4[k] = ptr5[num4];
					TKey tkey = UnsafeUtility.ReadArrayElement<TKey>((void*)data->keys, num4);
					int num5 = tkey.GetHashCode() & newBucketCapacity - 1;
					ptr5[num4] = *(int*)(ptr3 + (IntPtr)num5 * 4);
					*(int*)(ptr3 + (IntPtr)num5 * 4) = num4;
				}
			}
			Memory.Unmanaged.Free<byte>(data->values, label);
			if (data->allocatedIndexLength > data->keyCapacity)
			{
				data->allocatedIndexLength = data->keyCapacity;
			}
			data->values = ptr;
			data->keys = destination;
			data->next = ptr2;
			data->buckets = ptr3;
			data->keyCapacity = newCapacity;
			data->bucketCapacityMask = newBucketCapacity - 1;
		}

		// Token: 0x06000992 RID: 2450 RVA: 0x0001E6A1 File Offset: 0x0001C8A1
		internal unsafe static void DeallocateHashMap(UnsafeHashMapData* data, AllocatorManager.AllocatorHandle allocator)
		{
			Memory.Unmanaged.Free<byte>(data->values, allocator);
			Memory.Unmanaged.Free<UnsafeHashMapData>(data, allocator);
		}

		// Token: 0x06000993 RID: 2451 RVA: 0x0001E6B8 File Offset: 0x0001C8B8
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		internal static int CalculateDataSize<TKey, TValue>(int length, int bucketLength, out int keyOffset, out int nextOffset, out int bucketOffset) where TKey : struct where TValue : struct
		{
			int num = UnsafeUtility.SizeOf<TValue>();
			int num2 = UnsafeUtility.SizeOf<TKey>();
			int num3 = UnsafeUtility.SizeOf<int>();
			int num4 = CollectionHelper.Align(num * length, 64);
			int num5 = CollectionHelper.Align(num2 * length, 64);
			int num6 = CollectionHelper.Align(num3 * length, 64);
			int num7 = CollectionHelper.Align(num3 * bucketLength, 64);
			int result = num4 + num5 + num6 + num7;
			keyOffset = num4;
			nextOffset = keyOffset + num5;
			bucketOffset = nextOffset + num6;
			return result;
		}

		// Token: 0x06000994 RID: 2452 RVA: 0x0001E720 File Offset: 0x0001C920
		internal unsafe static bool IsEmpty(UnsafeHashMapData* data)
		{
			if (data->allocatedIndexLength <= 0)
			{
				return true;
			}
			int* ptr = (int*)data->buckets;
			int* ptr2 = (int*)data->next;
			int num = data->bucketCapacityMask;
			for (int i = 0; i <= num; i++)
			{
				if (ptr[i] != -1)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x0001E768 File Offset: 0x0001C968
		internal unsafe static int GetCount(UnsafeHashMapData* data)
		{
			if (data->allocatedIndexLength <= 0)
			{
				return 0;
			}
			int* ptr = (int*)data->next;
			int num = 0;
			for (int i = 0; i < 128; i++)
			{
				for (int j = *(ref data->firstFreeTLS.FixedElementField + (IntPtr)(i * 16) * 4); j >= 0; j = ptr[j])
				{
					num++;
				}
			}
			return math.min(data->keyCapacity, data->allocatedIndexLength) - num;
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x0001E7D4 File Offset: 0x0001C9D4
		internal unsafe static bool MoveNext(UnsafeHashMapData* data, ref int bucketIndex, ref int nextIndex, out int index)
		{
			int* ptr = (int*)data->buckets;
			int* ptr2 = (int*)data->next;
			int num = data->bucketCapacityMask;
			if (nextIndex != -1)
			{
				index = nextIndex;
				nextIndex = ptr2[nextIndex];
				return true;
			}
			for (int i = bucketIndex; i <= num; i++)
			{
				int num2 = ptr[i];
				if (num2 != -1)
				{
					index = num2;
					bucketIndex = i + 1;
					nextIndex = ptr2[num2];
					return true;
				}
			}
			index = -1;
			bucketIndex = num + 1;
			nextIndex = -1;
			return false;
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x0001E848 File Offset: 0x0001CA48
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		internal unsafe static void GetKeyArray<TKey>(UnsafeHashMapData* data, NativeArray<TKey> result) where TKey : struct
		{
			int* ptr = (int*)data->buckets;
			int* ptr2 = (int*)data->next;
			int num = 0;
			int num2 = 0;
			int length = result.Length;
			while (num <= data->bucketCapacityMask && num2 < length)
			{
				for (int num3 = ptr[num]; num3 != -1; num3 = ptr2[num3])
				{
					result[num2++] = UnsafeUtility.ReadArrayElement<TKey>((void*)data->keys, num3);
				}
				num++;
			}
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x0001E8B8 File Offset: 0x0001CAB8
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		internal unsafe static void GetValueArray<TValue>(UnsafeHashMapData* data, NativeArray<TValue> result) where TValue : struct
		{
			int* ptr = (int*)data->buckets;
			int* ptr2 = (int*)data->next;
			int num = 0;
			int num2 = 0;
			int length = result.Length;
			int num3 = data->bucketCapacityMask;
			while (num <= num3 && num2 < length)
			{
				for (int num4 = ptr[num]; num4 != -1; num4 = ptr2[num4])
				{
					result[num2++] = UnsafeUtility.ReadArrayElement<TValue>((void*)data->values, num4);
				}
				num++;
			}
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x0001E92C File Offset: 0x0001CB2C
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int),
			typeof(int)
		})]
		internal unsafe static void GetKeyValueArrays<TKey, TValue>(UnsafeHashMapData* data, NativeKeyValueArrays<TKey, TValue> result) where TKey : struct where TValue : struct
		{
			int* ptr = (int*)data->buckets;
			int* ptr2 = (int*)data->next;
			int num = 0;
			int num2 = 0;
			int length = result.Length;
			int num3 = data->bucketCapacityMask;
			while (num <= num3 && num2 < length)
			{
				for (int num4 = ptr[num]; num4 != -1; num4 = ptr2[num4])
				{
					result.Keys[num2] = UnsafeUtility.ReadArrayElement<TKey>((void*)data->keys, num4);
					result.Values[num2] = UnsafeUtility.ReadArrayElement<TValue>((void*)data->values, num4);
					num2++;
				}
				num++;
			}
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x0001E9BE File Offset: 0x0001CBBE
		internal UnsafeHashMapBucketData GetBucketData()
		{
			return new UnsafeHashMapBucketData(this.values, this.keys, this.next, this.buckets, this.bucketCapacityMask);
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x0001E9E3 File Offset: 0x0001CBE3
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private unsafe static void CheckHashMapReallocateDoesNotShrink(UnsafeHashMapData* data, int newCapacity)
		{
			if (data->keyCapacity > newCapacity)
			{
				throw new Exception("Shrinking a hash map is not supported");
			}
		}

		// Token: 0x04000353 RID: 851
		[FieldOffset(0)]
		internal unsafe byte* values;

		// Token: 0x04000354 RID: 852
		[FieldOffset(8)]
		internal unsafe byte* keys;

		// Token: 0x04000355 RID: 853
		[FieldOffset(16)]
		internal unsafe byte* next;

		// Token: 0x04000356 RID: 854
		[FieldOffset(24)]
		internal unsafe byte* buckets;

		// Token: 0x04000357 RID: 855
		[FieldOffset(32)]
		internal int keyCapacity;

		// Token: 0x04000358 RID: 856
		[FieldOffset(36)]
		internal int bucketCapacityMask;

		// Token: 0x04000359 RID: 857
		[FieldOffset(40)]
		internal int allocatedIndexLength;

		// Token: 0x0400035A RID: 858
		[FixedBuffer(typeof(int), 2048)]
		[FieldOffset(64)]
		internal UnsafeHashMapData.<firstFreeTLS>e__FixedBuffer firstFreeTLS;

		// Token: 0x0400035B RID: 859
		internal const int IntsPerCacheLine = 16;

		// Token: 0x020000F6 RID: 246
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 8192)]
		public struct <firstFreeTLS>e__FixedBuffer
		{
			// Token: 0x0400035C RID: 860
			public int FixedElementField;
		}
	}
}
