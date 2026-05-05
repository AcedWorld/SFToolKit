using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x0200043C RID: 1084
	internal class Page : IDisposable
	{
		// Token: 0x06002235 RID: 8757 RVA: 0x00083132 File Offset: 0x00081332
		public Page(uint vertexMaxCount, uint indexMaxCount, uint maxQueuedFrameCount, bool mockPage)
		{
			vertexMaxCount = Math.Min(vertexMaxCount, 65536U);
			this.vertices = new Page.DataSet<Vertex>(Utility.GPUBufferType.Vertex, vertexMaxCount, maxQueuedFrameCount, 32U, mockPage);
			this.indices = new Page.DataSet<ushort>(Utility.GPUBufferType.Index, indexMaxCount, maxQueuedFrameCount, 32U, mockPage);
		}

		// Token: 0x170007D2 RID: 2002
		// (get) Token: 0x06002236 RID: 8758 RVA: 0x0008316D File Offset: 0x0008136D
		// (set) Token: 0x06002237 RID: 8759 RVA: 0x00083175 File Offset: 0x00081375
		private protected bool disposed { protected get; private set; }

		// Token: 0x06002238 RID: 8760 RVA: 0x0008317E File Offset: 0x0008137E
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06002239 RID: 8761 RVA: 0x00083190 File Offset: 0x00081390
		protected virtual void Dispose(bool disposing)
		{
			bool disposed = this.disposed;
			if (!disposed)
			{
				if (disposing)
				{
					this.indices.Dispose();
					this.vertices.Dispose();
				}
				this.disposed = true;
			}
		}

		// Token: 0x170007D3 RID: 2003
		// (get) Token: 0x0600223A RID: 8762 RVA: 0x000831D4 File Offset: 0x000813D4
		public bool isEmpty
		{
			get
			{
				return this.vertices.allocator.isEmpty && this.indices.allocator.isEmpty;
			}
		}

		// Token: 0x04000EEF RID: 3823
		public Page.DataSet<Vertex> vertices;

		// Token: 0x04000EF0 RID: 3824
		public Page.DataSet<ushort> indices;

		// Token: 0x04000EF1 RID: 3825
		public Page next;

		// Token: 0x04000EF2 RID: 3826
		public int framesEmpty;

		// Token: 0x0200043D RID: 1085
		public class DataSet<T> : IDisposable where T : struct
		{
			// Token: 0x0600223B RID: 8763 RVA: 0x0008320C File Offset: 0x0008140C
			public DataSet(Utility.GPUBufferType bufferType, uint totalCount, uint maxQueuedFrameCount, uint updateRangePoolSize, bool mockBuffer)
			{
				bool flag = !mockBuffer;
				if (flag)
				{
					this.gpuData = new Utility.GPUBuffer<T>((int)totalCount, bufferType);
				}
				this.cpuData = new NativeArray<T>((int)totalCount, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
				this.allocator = new GPUBufferAllocator(totalCount);
				bool flag2 = !mockBuffer;
				if (flag2)
				{
					this.m_ElemStride = (uint)this.gpuData.ElementStride;
				}
				this.m_UpdateRangePoolSize = updateRangePoolSize;
				uint length = this.m_UpdateRangePoolSize * maxQueuedFrameCount;
				this.updateRanges = new NativeArray<GfxUpdateBufferRange>((int)length, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
				this.m_UpdateRangeMin = uint.MaxValue;
				this.m_UpdateRangeMax = 0U;
				this.m_UpdateRangesEnqueued = 0U;
				this.m_UpdateRangesBatchStart = 0U;
			}

			// Token: 0x170007D4 RID: 2004
			// (get) Token: 0x0600223C RID: 8764 RVA: 0x000832A6 File Offset: 0x000814A6
			// (set) Token: 0x0600223D RID: 8765 RVA: 0x000832AE File Offset: 0x000814AE
			private protected bool disposed { protected get; private set; }

			// Token: 0x0600223E RID: 8766 RVA: 0x000832B7 File Offset: 0x000814B7
			public void Dispose()
			{
				this.Dispose(true);
				GC.SuppressFinalize(this);
			}

			// Token: 0x0600223F RID: 8767 RVA: 0x000832CC File Offset: 0x000814CC
			public void Dispose(bool disposing)
			{
				bool disposed = this.disposed;
				if (!disposed)
				{
					if (disposing)
					{
						Utility.GPUBuffer<T> gpubuffer = this.gpuData;
						if (gpubuffer != null)
						{
							gpubuffer.Dispose();
						}
						this.cpuData.Dispose();
						this.updateRanges.Dispose();
					}
					this.disposed = true;
				}
			}

			// Token: 0x06002240 RID: 8768 RVA: 0x00083324 File Offset: 0x00081524
			public void RegisterUpdate(uint start, uint size)
			{
				Debug.Assert((ulong)(start + size) <= (ulong)((long)this.cpuData.Length));
				int num = (int)(this.m_UpdateRangesBatchStart + this.m_UpdateRangesEnqueued);
				bool flag = this.m_UpdateRangesEnqueued > 0U;
				if (flag)
				{
					int index = num - 1;
					GfxUpdateBufferRange gfxUpdateBufferRange = this.updateRanges[index];
					uint num2 = start * this.m_ElemStride;
					bool flag2 = gfxUpdateBufferRange.offsetFromWriteStart + gfxUpdateBufferRange.size == num2;
					if (flag2)
					{
						this.updateRanges[index] = new GfxUpdateBufferRange
						{
							source = gfxUpdateBufferRange.source,
							offsetFromWriteStart = gfxUpdateBufferRange.offsetFromWriteStart,
							size = gfxUpdateBufferRange.size + size * this.m_ElemStride
						};
						this.m_UpdateRangeMax = Math.Max(this.m_UpdateRangeMax, start + size);
						return;
					}
				}
				this.m_UpdateRangeMin = Math.Min(this.m_UpdateRangeMin, start);
				this.m_UpdateRangeMax = Math.Max(this.m_UpdateRangeMax, start + size);
				bool flag3 = this.m_UpdateRangesEnqueued == this.m_UpdateRangePoolSize;
				if (flag3)
				{
					this.m_UpdateRangesSaturated = true;
				}
				else
				{
					UIntPtr source = new UIntPtr(this.cpuData.Slice((int)start, (int)size).GetUnsafeReadOnlyPtr<T>());
					this.updateRanges[num] = new GfxUpdateBufferRange
					{
						source = source,
						offsetFromWriteStart = start * this.m_ElemStride,
						size = size * this.m_ElemStride
					};
					this.m_UpdateRangesEnqueued += 1U;
				}
			}

			// Token: 0x06002241 RID: 8769 RVA: 0x000834B0 File Offset: 0x000816B0
			private bool HasMappedBufferRange()
			{
				return Utility.HasMappedBufferRange();
			}

			// Token: 0x06002242 RID: 8770 RVA: 0x000834C8 File Offset: 0x000816C8
			public void SendUpdates()
			{
				bool flag = this.HasMappedBufferRange();
				if (flag)
				{
					this.SendPartialRanges();
				}
				else
				{
					this.SendFullRange();
				}
			}

			// Token: 0x06002243 RID: 8771 RVA: 0x000834F0 File Offset: 0x000816F0
			public void SendFullRange()
			{
				uint num = (uint)((long)this.cpuData.Length * (long)((ulong)this.m_ElemStride));
				this.updateRanges[(int)this.m_UpdateRangesBatchStart] = new GfxUpdateBufferRange
				{
					source = new UIntPtr(this.cpuData.GetUnsafeReadOnlyPtr<T>()),
					offsetFromWriteStart = 0U,
					size = num
				};
				Utility.GPUBuffer<T> gpubuffer = this.gpuData;
				if (gpubuffer != null)
				{
					gpubuffer.UpdateRanges(this.updateRanges.Slice((int)this.m_UpdateRangesBatchStart, 1), 0, (int)num);
				}
				this.ResetUpdateState();
			}

			// Token: 0x06002244 RID: 8772 RVA: 0x00083584 File Offset: 0x00081784
			public void SendPartialRanges()
			{
				bool flag = this.m_UpdateRangesEnqueued == 0U;
				if (!flag)
				{
					bool updateRangesSaturated = this.m_UpdateRangesSaturated;
					if (updateRangesSaturated)
					{
						uint num = this.m_UpdateRangeMax - this.m_UpdateRangeMin;
						this.m_UpdateRangesEnqueued = 1U;
						this.updateRanges[(int)this.m_UpdateRangesBatchStart] = new GfxUpdateBufferRange
						{
							source = new UIntPtr(this.cpuData.Slice((int)this.m_UpdateRangeMin, (int)num).GetUnsafeReadOnlyPtr<T>()),
							offsetFromWriteStart = this.m_UpdateRangeMin * this.m_ElemStride,
							size = num * this.m_ElemStride
						};
					}
					uint num2 = this.m_UpdateRangeMin * this.m_ElemStride;
					uint rangesMax = this.m_UpdateRangeMax * this.m_ElemStride;
					bool flag2 = num2 > 0U;
					if (flag2)
					{
						for (uint num3 = 0U; num3 < this.m_UpdateRangesEnqueued; num3 += 1U)
						{
							int index = (int)(num3 + this.m_UpdateRangesBatchStart);
							this.updateRanges[index] = new GfxUpdateBufferRange
							{
								source = this.updateRanges[index].source,
								offsetFromWriteStart = this.updateRanges[index].offsetFromWriteStart - num2,
								size = this.updateRanges[index].size
							};
						}
					}
					Utility.GPUBuffer<T> gpubuffer = this.gpuData;
					if (gpubuffer != null)
					{
						gpubuffer.UpdateRanges(this.updateRanges.Slice((int)this.m_UpdateRangesBatchStart, (int)this.m_UpdateRangesEnqueued), (int)num2, (int)rangesMax);
					}
					this.ResetUpdateState();
				}
			}

			// Token: 0x06002245 RID: 8773 RVA: 0x00083718 File Offset: 0x00081918
			private void ResetUpdateState()
			{
				this.m_UpdateRangeMin = uint.MaxValue;
				this.m_UpdateRangeMax = 0U;
				this.m_UpdateRangesEnqueued = 0U;
				this.m_UpdateRangesBatchStart += this.m_UpdateRangePoolSize;
				bool flag = (ulong)this.m_UpdateRangesBatchStart >= (ulong)((long)this.updateRanges.Length);
				if (flag)
				{
					this.m_UpdateRangesBatchStart = 0U;
				}
				this.m_UpdateRangesSaturated = false;
			}

			// Token: 0x04000EF4 RID: 3828
			public Utility.GPUBuffer<T> gpuData;

			// Token: 0x04000EF5 RID: 3829
			public NativeArray<T> cpuData;

			// Token: 0x04000EF6 RID: 3830
			public NativeArray<GfxUpdateBufferRange> updateRanges;

			// Token: 0x04000EF7 RID: 3831
			public GPUBufferAllocator allocator;

			// Token: 0x04000EF8 RID: 3832
			private readonly uint m_UpdateRangePoolSize;

			// Token: 0x04000EF9 RID: 3833
			private uint m_ElemStride;

			// Token: 0x04000EFA RID: 3834
			private uint m_UpdateRangeMin;

			// Token: 0x04000EFB RID: 3835
			private uint m_UpdateRangeMax;

			// Token: 0x04000EFC RID: 3836
			private uint m_UpdateRangesEnqueued;

			// Token: 0x04000EFD RID: 3837
			private uint m_UpdateRangesBatchStart;

			// Token: 0x04000EFE RID: 3838
			private bool m_UpdateRangesSaturated;
		}
	}
}
