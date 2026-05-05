using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

namespace Unity.Collections
{
	// Token: 0x0200008D RID: 141
	[NativeContainer]
	[DebuggerDisplay("Length = {Length}, IsCreated = {IsCreated}")]
	[BurstCompatible]
	public struct NativeBitArray : INativeDisposable, IDisposable
	{
		// Token: 0x060005F3 RID: 1523 RVA: 0x00014A2A File Offset: 0x00012C2A
		public NativeBitArray(int numBits, AllocatorManager.AllocatorHandle allocator, NativeArrayOptions options = NativeArrayOptions.ClearMemory)
		{
			this = new NativeBitArray(numBits, allocator, options, 2);
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x00014A36 File Offset: 0x00012C36
		private NativeBitArray(int numBits, AllocatorManager.AllocatorHandle allocator, NativeArrayOptions options, int disposeSentinelStackDepth)
		{
			this.m_BitArray = new UnsafeBitArray(numBits, allocator, options);
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060005F5 RID: 1525 RVA: 0x00014A46 File Offset: 0x00012C46
		public bool IsCreated
		{
			get
			{
				return this.m_BitArray.IsCreated;
			}
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x00014A53 File Offset: 0x00012C53
		public void Dispose()
		{
			this.m_BitArray.Dispose();
		}

		// Token: 0x060005F7 RID: 1527 RVA: 0x00014A60 File Offset: 0x00012C60
		[NotBurstCompatible]
		public JobHandle Dispose(JobHandle inputDeps)
		{
			return this.m_BitArray.Dispose(inputDeps);
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060005F8 RID: 1528 RVA: 0x00014A6E File Offset: 0x00012C6E
		public int Length
		{
			get
			{
				return CollectionHelper.AssumePositive(this.m_BitArray.Length);
			}
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x00014A80 File Offset: 0x00012C80
		public void Clear()
		{
			this.m_BitArray.Clear();
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x00014A90 File Offset: 0x00012C90
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public unsafe NativeArray<T> AsNativeArray<[IsUnmanaged] T>() where T : struct, ValueType
		{
			int num = UnsafeUtility.SizeOf<T>() * 8;
			int length = this.m_BitArray.Length / num;
			return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<T>((void*)this.m_BitArray.Ptr, length, Allocator.None);
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x00014AC5 File Offset: 0x00012CC5
		public void Set(int pos, bool value)
		{
			this.m_BitArray.Set(pos, value);
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x00014AD4 File Offset: 0x00012CD4
		public void SetBits(int pos, bool value, int numBits)
		{
			this.m_BitArray.SetBits(pos, value, numBits);
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x00014AE4 File Offset: 0x00012CE4
		public void SetBits(int pos, ulong value, int numBits = 1)
		{
			this.m_BitArray.SetBits(pos, value, numBits);
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x00014AF4 File Offset: 0x00012CF4
		public ulong GetBits(int pos, int numBits = 1)
		{
			return this.m_BitArray.GetBits(pos, numBits);
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x00014B03 File Offset: 0x00012D03
		public bool IsSet(int pos)
		{
			return this.m_BitArray.IsSet(pos);
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x00014B11 File Offset: 0x00012D11
		public void Copy(int dstPos, int srcPos, int numBits)
		{
			this.m_BitArray.Copy(dstPos, srcPos, numBits);
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x00014B21 File Offset: 0x00012D21
		public void Copy(int dstPos, ref NativeBitArray srcBitArray, int srcPos, int numBits)
		{
			this.m_BitArray.Copy(dstPos, ref srcBitArray.m_BitArray, srcPos, numBits);
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x00014B38 File Offset: 0x00012D38
		public int Find(int pos, int numBits)
		{
			return this.m_BitArray.Find(pos, numBits);
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x00014B47 File Offset: 0x00012D47
		public int Find(int pos, int count, int numBits)
		{
			return this.m_BitArray.Find(pos, count, numBits);
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x00014B57 File Offset: 0x00012D57
		public bool TestNone(int pos, int numBits = 1)
		{
			return this.m_BitArray.TestNone(pos, numBits);
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x00014B66 File Offset: 0x00012D66
		public bool TestAny(int pos, int numBits = 1)
		{
			return this.m_BitArray.TestAny(pos, numBits);
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x00014B75 File Offset: 0x00012D75
		public bool TestAll(int pos, int numBits = 1)
		{
			return this.m_BitArray.TestAll(pos, numBits);
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x00014B84 File Offset: 0x00012D84
		public int CountBits(int pos, int numBits = 1)
		{
			return this.m_BitArray.CountBits(pos, numBits);
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x000024A3 File Offset: 0x000006A3
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckRead()
		{
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x00014B94 File Offset: 0x00012D94
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckReadBounds<[IsUnmanaged] T>() where T : struct, ValueType
		{
			int num = UnsafeUtility.SizeOf<T>() * 8;
			int num2 = this.m_BitArray.Length / num;
			if (num2 == 0)
			{
				throw new InvalidOperationException(string.Format("Number of bits in the NativeBitArray {0} is not sufficient to cast to NativeArray<T> {1}.", this.m_BitArray.Length, UnsafeUtility.SizeOf<T>() * 8));
			}
			if (this.m_BitArray.Length != num * num2)
			{
				throw new InvalidOperationException(string.Format("Number of bits in the NativeBitArray {0} couldn't hold multiple of T {1}. Output array would be truncated.", this.m_BitArray.Length, UnsafeUtility.SizeOf<T>()));
			}
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x000024A3 File Offset: 0x000006A3
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckWrite()
		{
		}

		// Token: 0x04000268 RID: 616
		[NativeDisableUnsafePtrRestriction]
		internal UnsafeBitArray m_BitArray;
	}
}
