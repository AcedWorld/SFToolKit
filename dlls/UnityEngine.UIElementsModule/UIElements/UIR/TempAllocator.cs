using System;
using System.Collections.Generic;
using Unity.Collections;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x02000466 RID: 1126
	internal class TempAllocator<T> : IDisposable where T : struct
	{
		// Token: 0x0600230E RID: 8974 RVA: 0x00087DC8 File Offset: 0x00085FC8
		public TempAllocator(int poolCapacity, int excessMinCapacity, int excessMaxCapacity)
		{
			Debug.Assert(poolCapacity >= 1);
			Debug.Assert(excessMinCapacity >= 1);
			Debug.Assert(excessMinCapacity <= excessMaxCapacity);
			this.m_ExcessMinCapacity = excessMinCapacity;
			this.m_ExcessMaxCapacity = excessMaxCapacity;
			this.m_NextExcessSize = this.m_ExcessMinCapacity;
			this.m_Pool = default(TempAllocator<T>.Page);
			this.m_Pool.array = new NativeArray<T>(poolCapacity, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			this.m_Excess = new List<TempAllocator<T>.Page>(8);
		}

		// Token: 0x170007F3 RID: 2035
		// (get) Token: 0x0600230F RID: 8975 RVA: 0x00087E49 File Offset: 0x00086049
		// (set) Token: 0x06002310 RID: 8976 RVA: 0x00087E51 File Offset: 0x00086051
		private protected bool disposed { protected get; private set; }

		// Token: 0x06002311 RID: 8977 RVA: 0x00087E5A File Offset: 0x0008605A
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06002312 RID: 8978 RVA: 0x00087E6C File Offset: 0x0008606C
		protected void Dispose(bool disposing)
		{
			bool disposed = this.disposed;
			if (!disposed)
			{
				if (disposing)
				{
					this.ReleaseExcess();
					this.m_Pool.array.Dispose();
					this.m_Pool.used = 0;
				}
				this.disposed = true;
			}
		}

		// Token: 0x06002313 RID: 8979 RVA: 0x00087EBC File Offset: 0x000860BC
		public NativeSlice<T> Alloc(int count)
		{
			Debug.Assert(!this.disposed);
			int num = this.m_Pool.used + count;
			bool flag = num <= this.m_Pool.array.Length;
			NativeSlice<T> result;
			if (flag)
			{
				NativeSlice<T> nativeSlice = this.m_Pool.array.Slice(this.m_Pool.used, count);
				this.m_Pool.used = num;
				result = nativeSlice;
			}
			else
			{
				bool flag2 = count > this.m_ExcessMaxCapacity;
				if (flag2)
				{
					TempAllocator<T>.Page page = new TempAllocator<T>.Page
					{
						array = new NativeArray<T>(count, Allocator.Persistent, NativeArrayOptions.UninitializedMemory),
						used = count
					};
					this.m_Excess.Add(page);
					result = page.array.Slice(0, count);
				}
				else
				{
					for (int i = this.m_Excess.Count - 1; i >= 0; i--)
					{
						TempAllocator<T>.Page page2 = this.m_Excess[i];
						num = page2.used + count;
						bool flag3 = num <= page2.array.Length;
						if (flag3)
						{
							NativeSlice<T> result2 = page2.array.Slice(page2.used, count);
							page2.used = num;
							this.m_Excess[i] = page2;
							return result2;
						}
					}
					while (count > this.m_NextExcessSize)
					{
						this.m_NextExcessSize <<= 1;
					}
					TempAllocator<T>.Page page3 = new TempAllocator<T>.Page
					{
						array = new NativeArray<T>(this.m_NextExcessSize, Allocator.Persistent, NativeArrayOptions.UninitializedMemory),
						used = count
					};
					this.m_Excess.Add(page3);
					this.m_NextExcessSize = Mathf.Min(this.m_NextExcessSize << 1, this.m_ExcessMaxCapacity);
					result = page3.array.Slice(0, count);
				}
			}
			return result;
		}

		// Token: 0x06002314 RID: 8980 RVA: 0x00088097 File Offset: 0x00086297
		public void Reset()
		{
			this.ReleaseExcess();
			this.m_Pool.used = 0;
			this.m_NextExcessSize = this.m_ExcessMinCapacity;
		}

		// Token: 0x06002315 RID: 8981 RVA: 0x000880BC File Offset: 0x000862BC
		private void ReleaseExcess()
		{
			foreach (TempAllocator<T>.Page page in this.m_Excess)
			{
				NativeArray<T> array = page.array;
				array.Dispose();
			}
			this.m_Excess.Clear();
		}

		// Token: 0x06002316 RID: 8982 RVA: 0x00088128 File Offset: 0x00086328
		public TempAllocator<T>.Statistics GatherStatistics()
		{
			TempAllocator<T>.Statistics statistics = new TempAllocator<T>.Statistics
			{
				pool = new TempAllocator<T>.PageStatistics
				{
					size = this.m_Pool.array.Length,
					used = this.m_Pool.used
				},
				excess = new TempAllocator<T>.PageStatistics[this.m_Excess.Count]
			};
			for (int i = 0; i < this.m_Excess.Count; i++)
			{
				statistics.excess[i] = new TempAllocator<T>.PageStatistics
				{
					size = this.m_Excess[i].array.Length,
					used = this.m_Excess[i].used
				};
			}
			return statistics;
		}

		// Token: 0x0400102E RID: 4142
		private readonly int m_ExcessMinCapacity;

		// Token: 0x0400102F RID: 4143
		private readonly int m_ExcessMaxCapacity;

		// Token: 0x04001030 RID: 4144
		private TempAllocator<T>.Page m_Pool;

		// Token: 0x04001031 RID: 4145
		private List<TempAllocator<T>.Page> m_Excess;

		// Token: 0x04001032 RID: 4146
		private int m_NextExcessSize;

		// Token: 0x02000467 RID: 1127
		private struct Page
		{
			// Token: 0x04001034 RID: 4148
			public NativeArray<T> array;

			// Token: 0x04001035 RID: 4149
			public int used;
		}

		// Token: 0x02000468 RID: 1128
		public struct Statistics
		{
			// Token: 0x04001036 RID: 4150
			public TempAllocator<T>.PageStatistics pool;

			// Token: 0x04001037 RID: 4151
			public TempAllocator<T>.PageStatistics[] excess;
		}

		// Token: 0x02000469 RID: 1129
		public struct PageStatistics
		{
			// Token: 0x04001038 RID: 4152
			public int size;

			// Token: 0x04001039 RID: 4153
			public int used;
		}
	}
}
