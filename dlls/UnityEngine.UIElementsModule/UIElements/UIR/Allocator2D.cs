using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x02000426 RID: 1062
	internal class Allocator2D
	{
		// Token: 0x170007C2 RID: 1986
		// (get) Token: 0x060021D6 RID: 8662 RVA: 0x0007F5D3 File Offset: 0x0007D7D3
		public Vector2Int minSize
		{
			get
			{
				return this.m_MinSize;
			}
		}

		// Token: 0x170007C3 RID: 1987
		// (get) Token: 0x060021D7 RID: 8663 RVA: 0x0007F5DB File Offset: 0x0007D7DB
		public Vector2Int maxSize
		{
			get
			{
				return this.m_MaxSize;
			}
		}

		// Token: 0x170007C4 RID: 1988
		// (get) Token: 0x060021D8 RID: 8664 RVA: 0x0007F5E3 File Offset: 0x0007D7E3
		public Vector2Int maxAllocSize
		{
			get
			{
				return this.m_MaxAllocSize;
			}
		}

		// Token: 0x060021D9 RID: 8665 RVA: 0x0007F5EB File Offset: 0x0007D7EB
		public Allocator2D(int minSize, int maxSize, int rowHeightBias) : this(new Vector2Int(minSize, minSize), new Vector2Int(maxSize, maxSize), rowHeightBias)
		{
		}

		// Token: 0x060021DA RID: 8666 RVA: 0x0007F604 File Offset: 0x0007D804
		public Allocator2D(Vector2Int minSize, Vector2Int maxSize, int rowHeightBias)
		{
			Debug.Assert(minSize.x > 0 && minSize.x <= maxSize.x && minSize.y > 0 && minSize.y <= maxSize.y);
			Debug.Assert(minSize.x == UIRUtility.GetNextPow2(minSize.x) && minSize.y == UIRUtility.GetNextPow2(minSize.y) && maxSize.x == UIRUtility.GetNextPow2(maxSize.x) && maxSize.y == UIRUtility.GetNextPow2(maxSize.y));
			Debug.Assert(rowHeightBias >= 0);
			this.m_MinSize = minSize;
			this.m_MaxSize = maxSize;
			this.m_RowHeightBias = rowHeightBias;
			Allocator2D.BuildAreas(this.m_Areas, minSize, maxSize);
			this.m_MaxAllocSize = Allocator2D.ComputeMaxAllocSize(this.m_Areas, rowHeightBias);
			this.m_Rows = Allocator2D.BuildRowArray(this.m_MaxAllocSize.y, rowHeightBias);
		}

		// Token: 0x060021DB RID: 8667 RVA: 0x0007F71C File Offset: 0x0007D91C
		public bool TryAllocate(int width, int height, out Allocator2D.Alloc2D alloc2D)
		{
			bool flag = width < 1 || width > this.m_MaxAllocSize.x || height < 1 || height > this.m_MaxAllocSize.y;
			bool result;
			if (flag)
			{
				alloc2D = default(Allocator2D.Alloc2D);
				result = false;
			}
			else
			{
				int nextPow2Exp = UIRUtility.GetNextPow2Exp(Mathf.Max(height - this.m_RowHeightBias, 1));
				for (Allocator2D.Row row = this.m_Rows[nextPow2Exp]; row != null; row = row.next)
				{
					bool flag2 = row.rect.width >= width;
					if (flag2)
					{
						Alloc alloc = row.allocator.Allocate((uint)width);
						bool flag3 = alloc.size > 0U;
						if (flag3)
						{
							alloc2D = new Allocator2D.Alloc2D(row, alloc, width, height);
							return true;
						}
					}
				}
				int num = (1 << nextPow2Exp) + this.m_RowHeightBias;
				Debug.Assert(num >= height);
				for (int i = 0; i < this.m_Areas.Count; i++)
				{
					Allocator2D.Area area = this.m_Areas[i];
					bool flag4 = area.rect.height >= num && area.rect.width >= width;
					if (flag4)
					{
						Alloc alloc2 = area.allocator.Allocate((uint)num);
						bool flag5 = alloc2.size > 0U;
						if (flag5)
						{
							Allocator2D.Row row = Allocator2D.Row.pool.Get();
							row.alloc = alloc2;
							row.allocator = new BestFitAllocator((uint)area.rect.width);
							row.area = area;
							row.next = this.m_Rows[nextPow2Exp];
							row.rect = new RectInt(area.rect.xMin, area.rect.yMin + (int)alloc2.start, area.rect.width, num);
							this.m_Rows[nextPow2Exp] = row;
							Alloc alloc3 = row.allocator.Allocate((uint)width);
							Debug.Assert(alloc3.size > 0U);
							alloc2D = new Allocator2D.Alloc2D(row, alloc3, width, height);
							return true;
						}
					}
				}
				alloc2D = default(Allocator2D.Alloc2D);
				result = false;
			}
			return result;
		}

		// Token: 0x060021DC RID: 8668 RVA: 0x0007F958 File Offset: 0x0007DB58
		public void Free(Allocator2D.Alloc2D alloc2D)
		{
			bool flag = alloc2D.alloc.size == 0U;
			if (!flag)
			{
				Allocator2D.Row row = alloc2D.row;
				row.allocator.Free(alloc2D.alloc);
				bool flag2 = row.allocator.highWatermark == 0U;
				if (flag2)
				{
					row.area.allocator.Free(row.alloc);
					int nextPow2Exp = UIRUtility.GetNextPow2Exp(row.rect.height - this.m_RowHeightBias);
					Allocator2D.Row row2 = this.m_Rows[nextPow2Exp];
					bool flag3 = row2 == row;
					if (flag3)
					{
						this.m_Rows[nextPow2Exp] = row.next;
					}
					else
					{
						Allocator2D.Row row3 = row2;
						while (row3.next != row)
						{
							row3 = row3.next;
						}
						row3.next = row.next;
					}
					Allocator2D.Row.pool.Return(row);
				}
			}
		}

		// Token: 0x060021DD RID: 8669 RVA: 0x0007FA40 File Offset: 0x0007DC40
		private static void BuildAreas(List<Allocator2D.Area> areas, Vector2Int minSize, Vector2Int maxSize)
		{
			int num = Mathf.Min(minSize.x, minSize.y);
			int num2 = num;
			areas.Add(new Allocator2D.Area(new RectInt(0, 0, num, num2)));
			while (num < maxSize.x || num2 < maxSize.y)
			{
				bool flag = num < maxSize.x;
				if (flag)
				{
					areas.Add(new Allocator2D.Area(new RectInt(num, 0, num, num2)));
					num *= 2;
				}
				bool flag2 = num2 < maxSize.y;
				if (flag2)
				{
					areas.Add(new Allocator2D.Area(new RectInt(0, num2, num, num2)));
					num2 *= 2;
				}
			}
		}

		// Token: 0x060021DE RID: 8670 RVA: 0x0007FAEC File Offset: 0x0007DCEC
		private static Vector2Int ComputeMaxAllocSize(List<Allocator2D.Area> areas, int rowHeightBias)
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < areas.Count; i++)
			{
				Allocator2D.Area area = areas[i];
				num = Mathf.Max(area.rect.width, num);
				num2 = Mathf.Max(area.rect.height, num2);
			}
			return new Vector2Int(num, UIRUtility.GetPrevPow2(num2 - rowHeightBias) + rowHeightBias);
		}

		// Token: 0x060021DF RID: 8671 RVA: 0x0007FB5C File Offset: 0x0007DD5C
		private static Allocator2D.Row[] BuildRowArray(int maxRowHeight, int rowHeightBias)
		{
			int num = UIRUtility.GetNextPow2Exp(maxRowHeight - rowHeightBias) + 1;
			return new Allocator2D.Row[num];
		}

		// Token: 0x04000E63 RID: 3683
		private readonly Vector2Int m_MinSize;

		// Token: 0x04000E64 RID: 3684
		private readonly Vector2Int m_MaxSize;

		// Token: 0x04000E65 RID: 3685
		private readonly Vector2Int m_MaxAllocSize;

		// Token: 0x04000E66 RID: 3686
		private readonly int m_RowHeightBias;

		// Token: 0x04000E67 RID: 3687
		private readonly Allocator2D.Row[] m_Rows;

		// Token: 0x04000E68 RID: 3688
		private readonly List<Allocator2D.Area> m_Areas = new List<Allocator2D.Area>();

		// Token: 0x02000427 RID: 1063
		public class Area
		{
			// Token: 0x060021E0 RID: 8672 RVA: 0x0007FB7F File Offset: 0x0007DD7F
			public Area(RectInt rect)
			{
				this.rect = rect;
				this.allocator = new BestFitAllocator((uint)rect.height);
			}

			// Token: 0x04000E69 RID: 3689
			public RectInt rect;

			// Token: 0x04000E6A RID: 3690
			public BestFitAllocator allocator;
		}

		// Token: 0x02000428 RID: 1064
		public class Row : LinkedPoolItem<Allocator2D.Row>
		{
			// Token: 0x060021E1 RID: 8673 RVA: 0x0007FBA2 File Offset: 0x0007DDA2
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static Allocator2D.Row Create()
			{
				return new Allocator2D.Row();
			}

			// Token: 0x060021E2 RID: 8674 RVA: 0x0007FBA9 File Offset: 0x0007DDA9
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static void Reset(Allocator2D.Row row)
			{
				row.rect = default(RectInt);
				row.area = null;
				row.allocator = null;
				row.alloc = default(Alloc);
				row.next = null;
			}

			// Token: 0x04000E6B RID: 3691
			public RectInt rect;

			// Token: 0x04000E6C RID: 3692
			public Allocator2D.Area area;

			// Token: 0x04000E6D RID: 3693
			public BestFitAllocator allocator;

			// Token: 0x04000E6E RID: 3694
			public Alloc alloc;

			// Token: 0x04000E6F RID: 3695
			public Allocator2D.Row next;

			// Token: 0x04000E70 RID: 3696
			public static readonly LinkedPool<Allocator2D.Row> pool = new LinkedPool<Allocator2D.Row>(new Func<Allocator2D.Row>(Allocator2D.Row.Create), new Action<Allocator2D.Row>(Allocator2D.Row.Reset), 256);
		}

		// Token: 0x02000429 RID: 1065
		public struct Alloc2D
		{
			// Token: 0x060021E5 RID: 8677 RVA: 0x0007FC0B File Offset: 0x0007DE0B
			public Alloc2D(Allocator2D.Row row, Alloc alloc, int width, int height)
			{
				this.alloc = alloc;
				this.row = row;
				this.rect = new RectInt(row.rect.xMin + (int)alloc.start, row.rect.yMin, width, height);
			}

			// Token: 0x04000E71 RID: 3697
			public RectInt rect;

			// Token: 0x04000E72 RID: 3698
			public Allocator2D.Row row;

			// Token: 0x04000E73 RID: 3699
			public Alloc alloc;
		}
	}
}
