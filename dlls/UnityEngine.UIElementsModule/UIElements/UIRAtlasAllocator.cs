using System;
using Unity.Profiling;
using UnityEngine.Assertions;

namespace UnityEngine.UIElements
{
	// Token: 0x020002A2 RID: 674
	internal class UIRAtlasAllocator : IDisposable
	{
		// Token: 0x1700040B RID: 1035
		// (get) Token: 0x06001345 RID: 4933 RVA: 0x000433AE File Offset: 0x000415AE
		public int maxAtlasSize { get; }

		// Token: 0x1700040C RID: 1036
		// (get) Token: 0x06001346 RID: 4934 RVA: 0x000433B6 File Offset: 0x000415B6
		public int maxImageWidth { get; }

		// Token: 0x1700040D RID: 1037
		// (get) Token: 0x06001347 RID: 4935 RVA: 0x000433BE File Offset: 0x000415BE
		public int maxImageHeight { get; }

		// Token: 0x1700040E RID: 1038
		// (get) Token: 0x06001348 RID: 4936 RVA: 0x000433C6 File Offset: 0x000415C6
		// (set) Token: 0x06001349 RID: 4937 RVA: 0x000433CE File Offset: 0x000415CE
		public int virtualWidth { get; private set; }

		// Token: 0x1700040F RID: 1039
		// (get) Token: 0x0600134A RID: 4938 RVA: 0x000433D7 File Offset: 0x000415D7
		// (set) Token: 0x0600134B RID: 4939 RVA: 0x000433DF File Offset: 0x000415DF
		public int virtualHeight { get; private set; }

		// Token: 0x17000410 RID: 1040
		// (get) Token: 0x0600134C RID: 4940 RVA: 0x000433E8 File Offset: 0x000415E8
		// (set) Token: 0x0600134D RID: 4941 RVA: 0x000433F0 File Offset: 0x000415F0
		public int physicalWidth { get; private set; }

		// Token: 0x17000411 RID: 1041
		// (get) Token: 0x0600134E RID: 4942 RVA: 0x000433F9 File Offset: 0x000415F9
		// (set) Token: 0x0600134F RID: 4943 RVA: 0x00043401 File Offset: 0x00041601
		public int physicalHeight { get; private set; }

		// Token: 0x17000412 RID: 1042
		// (get) Token: 0x06001350 RID: 4944 RVA: 0x0004340A File Offset: 0x0004160A
		// (set) Token: 0x06001351 RID: 4945 RVA: 0x00043412 File Offset: 0x00041612
		private protected bool disposed { protected get; private set; }

		// Token: 0x06001352 RID: 4946 RVA: 0x0004341B File Offset: 0x0004161B
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06001353 RID: 4947 RVA: 0x00043430 File Offset: 0x00041630
		protected virtual void Dispose(bool disposing)
		{
			bool disposed = this.disposed;
			if (!disposed)
			{
				if (disposing)
				{
					for (int i = 0; i < this.m_OpenRows.Length; i++)
					{
						UIRAtlasAllocator.Row row = this.m_OpenRows[i];
						bool flag = row != null;
						if (flag)
						{
							row.Release();
						}
					}
					this.m_OpenRows = null;
					UIRAtlasAllocator.AreaNode next;
					for (UIRAtlasAllocator.AreaNode areaNode = this.m_FirstUnpartitionedArea; areaNode != null; areaNode = next)
					{
						next = areaNode.next;
						areaNode.Release();
					}
					this.m_FirstUnpartitionedArea = null;
				}
				this.disposed = true;
			}
		}

		// Token: 0x06001354 RID: 4948 RVA: 0x000434C8 File Offset: 0x000416C8
		private static int GetLog2OfNextPower(int n)
		{
			float f = (float)Mathf.NextPowerOfTwo(n);
			float f2 = Mathf.Log(f, 2f);
			return Mathf.RoundToInt(f2);
		}

		// Token: 0x06001355 RID: 4949 RVA: 0x000434F4 File Offset: 0x000416F4
		public UIRAtlasAllocator(int initialAtlasSize, int maxAtlasSize, int sidePadding = 1)
		{
			Assert.IsTrue(initialAtlasSize > 0 && initialAtlasSize <= maxAtlasSize);
			Assert.IsTrue(initialAtlasSize == Mathf.NextPowerOfTwo(initialAtlasSize));
			Assert.IsTrue(maxAtlasSize == Mathf.NextPowerOfTwo(maxAtlasSize));
			this.m_1SidePadding = sidePadding;
			this.m_2SidePadding = sidePadding << 1;
			this.maxAtlasSize = maxAtlasSize;
			this.maxImageWidth = maxAtlasSize;
			this.maxImageHeight = ((initialAtlasSize == maxAtlasSize) ? (maxAtlasSize / 2 + this.m_2SidePadding) : (maxAtlasSize / 4 + this.m_2SidePadding));
			this.virtualWidth = initialAtlasSize;
			this.virtualHeight = initialAtlasSize;
			int num = UIRAtlasAllocator.GetLog2OfNextPower(maxAtlasSize) + 1;
			this.m_OpenRows = new UIRAtlasAllocator.Row[num];
			RectInt rect = new RectInt(0, 0, initialAtlasSize, initialAtlasSize);
			this.m_FirstUnpartitionedArea = UIRAtlasAllocator.AreaNode.Acquire(rect);
			this.BuildAreas();
		}

		// Token: 0x06001356 RID: 4950 RVA: 0x000435BC File Offset: 0x000417BC
		public bool TryAllocate(int width, int height, out RectInt location)
		{
			bool result;
			using (UIRAtlasAllocator.s_MarkerTryAllocate.Auto())
			{
				location = default(RectInt);
				bool disposed = this.disposed;
				if (disposed)
				{
					result = false;
				}
				else
				{
					bool flag = width < 1 || height < 1;
					if (flag)
					{
						result = false;
					}
					else
					{
						bool flag2 = width > this.maxImageWidth || height > this.maxImageHeight;
						if (flag2)
						{
							result = false;
						}
						else
						{
							int log2OfNextPower = UIRAtlasAllocator.GetLog2OfNextPower(Mathf.Max(height - this.m_2SidePadding, 1));
							int rowHeight = (1 << log2OfNextPower) + this.m_2SidePadding;
							UIRAtlasAllocator.Row row = this.m_OpenRows[log2OfNextPower];
							bool flag3 = row != null && row.width - row.Cursor < width;
							if (flag3)
							{
								row = null;
							}
							bool flag4 = row == null;
							if (flag4)
							{
								for (UIRAtlasAllocator.AreaNode areaNode = this.m_FirstUnpartitionedArea; areaNode != null; areaNode = areaNode.next)
								{
									bool flag5 = this.TryPartitionArea(areaNode, log2OfNextPower, rowHeight, width);
									if (flag5)
									{
										row = this.m_OpenRows[log2OfNextPower];
										break;
									}
								}
								bool flag6 = row == null;
								if (flag6)
								{
									return false;
								}
							}
							location = new RectInt(row.offsetX + row.Cursor, row.offsetY, width, height);
							row.Cursor += width;
							Assert.IsTrue(row.Cursor <= row.width);
							this.physicalWidth = Mathf.NextPowerOfTwo(Mathf.Max(this.physicalWidth, location.xMax));
							this.physicalHeight = Mathf.NextPowerOfTwo(Mathf.Max(this.physicalHeight, location.yMax));
							result = true;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06001357 RID: 4951 RVA: 0x00043784 File Offset: 0x00041984
		private bool TryPartitionArea(UIRAtlasAllocator.AreaNode areaNode, int rowIndex, int rowHeight, int minWidth)
		{
			RectInt rect = areaNode.rect;
			bool flag = rect.height < rowHeight || rect.width < minWidth;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				UIRAtlasAllocator.Row row = this.m_OpenRows[rowIndex];
				bool flag2 = row != null;
				if (flag2)
				{
					row.Release();
				}
				row = UIRAtlasAllocator.Row.Acquire(rect.x, rect.y, rect.width, rowHeight);
				this.m_OpenRows[rowIndex] = row;
				rect.y += rowHeight;
				rect.height -= rowHeight;
				bool flag3 = rect.height == 0;
				if (flag3)
				{
					bool flag4 = areaNode == this.m_FirstUnpartitionedArea;
					if (flag4)
					{
						this.m_FirstUnpartitionedArea = areaNode.next;
					}
					areaNode.RemoveFromChain();
					areaNode.Release();
				}
				else
				{
					areaNode.rect = rect;
				}
				result = true;
			}
			return result;
		}

		// Token: 0x06001358 RID: 4952 RVA: 0x00043864 File Offset: 0x00041A64
		private void BuildAreas()
		{
			UIRAtlasAllocator.AreaNode previous = this.m_FirstUnpartitionedArea;
			while (this.virtualWidth < this.maxAtlasSize || this.virtualHeight < this.maxAtlasSize)
			{
				bool flag = this.virtualWidth > this.virtualHeight;
				RectInt rect;
				if (flag)
				{
					rect = new RectInt(0, this.virtualHeight, this.virtualWidth, this.virtualHeight);
					this.virtualHeight *= 2;
				}
				else
				{
					rect = new RectInt(this.virtualWidth, 0, this.virtualWidth, this.virtualHeight);
					this.virtualWidth *= 2;
				}
				UIRAtlasAllocator.AreaNode areaNode = UIRAtlasAllocator.AreaNode.Acquire(rect);
				areaNode.AddAfter(previous);
				previous = areaNode;
			}
		}

		// Token: 0x040008C1 RID: 2241
		private UIRAtlasAllocator.AreaNode m_FirstUnpartitionedArea;

		// Token: 0x040008C2 RID: 2242
		private UIRAtlasAllocator.Row[] m_OpenRows;

		// Token: 0x040008C3 RID: 2243
		private int m_1SidePadding;

		// Token: 0x040008C4 RID: 2244
		private int m_2SidePadding;

		// Token: 0x040008C5 RID: 2245
		private static ProfilerMarker s_MarkerTryAllocate = new ProfilerMarker("UIRAtlasAllocator.TryAllocate");

		// Token: 0x020002A3 RID: 675
		private class Row
		{
			// Token: 0x17000413 RID: 1043
			// (get) Token: 0x0600135A RID: 4954 RVA: 0x00043931 File Offset: 0x00041B31
			// (set) Token: 0x0600135B RID: 4955 RVA: 0x00043939 File Offset: 0x00041B39
			public int offsetX { get; private set; }

			// Token: 0x17000414 RID: 1044
			// (get) Token: 0x0600135C RID: 4956 RVA: 0x00043942 File Offset: 0x00041B42
			// (set) Token: 0x0600135D RID: 4957 RVA: 0x0004394A File Offset: 0x00041B4A
			public int offsetY { get; private set; }

			// Token: 0x17000415 RID: 1045
			// (get) Token: 0x0600135E RID: 4958 RVA: 0x00043953 File Offset: 0x00041B53
			// (set) Token: 0x0600135F RID: 4959 RVA: 0x0004395B File Offset: 0x00041B5B
			public int width { get; private set; }

			// Token: 0x17000416 RID: 1046
			// (get) Token: 0x06001360 RID: 4960 RVA: 0x00043964 File Offset: 0x00041B64
			// (set) Token: 0x06001361 RID: 4961 RVA: 0x0004396C File Offset: 0x00041B6C
			public int height { get; private set; }

			// Token: 0x06001362 RID: 4962 RVA: 0x00043978 File Offset: 0x00041B78
			public static UIRAtlasAllocator.Row Acquire(int offsetX, int offsetY, int width, int height)
			{
				UIRAtlasAllocator.Row row = UIRAtlasAllocator.Row.s_Pool.Get();
				row.offsetX = offsetX;
				row.offsetY = offsetY;
				row.width = width;
				row.height = height;
				row.Cursor = 0;
				return row;
			}

			// Token: 0x06001363 RID: 4963 RVA: 0x000439BD File Offset: 0x00041BBD
			public void Release()
			{
				UIRAtlasAllocator.Row.s_Pool.Release(this);
				this.offsetX = -1;
				this.offsetY = -1;
				this.width = -1;
				this.height = -1;
				this.Cursor = -1;
			}

			// Token: 0x040008C7 RID: 2247
			private static ObjectPool<UIRAtlasAllocator.Row> s_Pool = new ObjectPool<UIRAtlasAllocator.Row>(() => new UIRAtlasAllocator.Row(), 100);

			// Token: 0x040008CC RID: 2252
			public int Cursor;
		}

		// Token: 0x020002A5 RID: 677
		private class AreaNode
		{
			// Token: 0x06001369 RID: 4969 RVA: 0x00043A24 File Offset: 0x00041C24
			public static UIRAtlasAllocator.AreaNode Acquire(RectInt rect)
			{
				UIRAtlasAllocator.AreaNode areaNode = UIRAtlasAllocator.AreaNode.s_Pool.Get();
				areaNode.rect = rect;
				areaNode.previous = null;
				areaNode.next = null;
				return areaNode;
			}

			// Token: 0x0600136A RID: 4970 RVA: 0x00043A57 File Offset: 0x00041C57
			public void Release()
			{
				UIRAtlasAllocator.AreaNode.s_Pool.Release(this);
			}

			// Token: 0x0600136B RID: 4971 RVA: 0x00043A68 File Offset: 0x00041C68
			public void RemoveFromChain()
			{
				bool flag = this.previous != null;
				if (flag)
				{
					this.previous.next = this.next;
				}
				bool flag2 = this.next != null;
				if (flag2)
				{
					this.next.previous = this.previous;
				}
				this.previous = null;
				this.next = null;
			}

			// Token: 0x0600136C RID: 4972 RVA: 0x00043AC0 File Offset: 0x00041CC0
			public void AddAfter(UIRAtlasAllocator.AreaNode previous)
			{
				Assert.IsNull<UIRAtlasAllocator.AreaNode>(this.previous);
				Assert.IsNull<UIRAtlasAllocator.AreaNode>(this.next);
				this.previous = previous;
				bool flag = previous != null;
				if (flag)
				{
					this.next = previous.next;
					previous.next = this;
				}
				bool flag2 = this.next != null;
				if (flag2)
				{
					this.next.previous = this;
				}
			}

			// Token: 0x040008CE RID: 2254
			private static ObjectPool<UIRAtlasAllocator.AreaNode> s_Pool = new ObjectPool<UIRAtlasAllocator.AreaNode>(() => new UIRAtlasAllocator.AreaNode(), 100);

			// Token: 0x040008CF RID: 2255
			public RectInt rect;

			// Token: 0x040008D0 RID: 2256
			public UIRAtlasAllocator.AreaNode previous;

			// Token: 0x040008D1 RID: 2257
			public UIRAtlasAllocator.AreaNode next;
		}
	}
}
