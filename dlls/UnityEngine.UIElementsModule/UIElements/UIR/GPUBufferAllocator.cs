using System;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x0200043B RID: 1083
	internal class GPUBufferAllocator
	{
		// Token: 0x0600222F RID: 8751 RVA: 0x00082E3C File Offset: 0x0008103C
		public GPUBufferAllocator(uint maxSize)
		{
			this.m_Low = new BestFitAllocator(maxSize);
			this.m_High = new BestFitAllocator(maxSize);
		}

		// Token: 0x06002230 RID: 8752 RVA: 0x00082E60 File Offset: 0x00081060
		public Alloc Allocate(uint size, bool shortLived)
		{
			bool flag = !shortLived;
			Alloc alloc;
			if (flag)
			{
				alloc = this.m_Low.Allocate(size);
			}
			else
			{
				alloc = this.m_High.Allocate(size);
				alloc.start = this.m_High.totalSize - alloc.start - alloc.size;
			}
			alloc.shortLived = shortLived;
			bool flag2 = this.HighLowCollide() && alloc.size > 0U;
			Alloc result;
			if (flag2)
			{
				this.Free(alloc);
				result = default(Alloc);
			}
			else
			{
				result = alloc;
			}
			return result;
		}

		// Token: 0x06002231 RID: 8753 RVA: 0x00082EF4 File Offset: 0x000810F4
		public void Free(Alloc alloc)
		{
			bool flag = !alloc.shortLived;
			if (flag)
			{
				this.m_Low.Free(alloc);
			}
			else
			{
				alloc.start = this.m_High.totalSize - alloc.start - alloc.size;
				this.m_High.Free(alloc);
			}
		}

		// Token: 0x170007D1 RID: 2001
		// (get) Token: 0x06002232 RID: 8754 RVA: 0x00082F50 File Offset: 0x00081150
		public bool isEmpty
		{
			get
			{
				return this.m_Low.highWatermark == 0U && this.m_High.highWatermark == 0U;
			}
		}

		// Token: 0x06002233 RID: 8755 RVA: 0x00082F80 File Offset: 0x00081180
		public HeapStatistics GatherStatistics()
		{
			HeapStatistics heapStatistics = default(HeapStatistics);
			heapStatistics.subAllocators = new HeapStatistics[]
			{
				this.m_Low.GatherStatistics(),
				this.m_High.GatherStatistics()
			};
			heapStatistics.largestAvailableBlock = uint.MaxValue;
			for (int i = 0; i < 2; i++)
			{
				heapStatistics.numAllocs += heapStatistics.subAllocators[i].numAllocs;
				heapStatistics.totalSize = Math.Max(heapStatistics.totalSize, heapStatistics.subAllocators[i].totalSize);
				heapStatistics.allocatedSize += heapStatistics.subAllocators[i].allocatedSize;
				heapStatistics.largestAvailableBlock = Math.Min(heapStatistics.largestAvailableBlock, heapStatistics.subAllocators[i].largestAvailableBlock);
				heapStatistics.availableBlocksCount += heapStatistics.subAllocators[i].availableBlocksCount;
				heapStatistics.blockCount += heapStatistics.subAllocators[i].blockCount;
				heapStatistics.highWatermark = Math.Max(heapStatistics.highWatermark, heapStatistics.subAllocators[i].highWatermark);
				heapStatistics.fragmentation = Math.Max(heapStatistics.fragmentation, heapStatistics.subAllocators[i].fragmentation);
			}
			heapStatistics.freeSize = heapStatistics.totalSize - heapStatistics.allocatedSize;
			return heapStatistics;
		}

		// Token: 0x06002234 RID: 8756 RVA: 0x000830FC File Offset: 0x000812FC
		private bool HighLowCollide()
		{
			return this.m_Low.highWatermark + this.m_High.highWatermark > this.m_Low.totalSize;
		}

		// Token: 0x04000EEC RID: 3820
		private BestFitAllocator m_Low;

		// Token: 0x04000EED RID: 3821
		private BestFitAllocator m_High;
	}
}
