using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine.Pool;

namespace UnityEngine.UIElements
{
	// Token: 0x020000F2 RID: 242
	internal class ColumnLayout
	{
		// Token: 0x1700018A RID: 394
		// (get) Token: 0x06000837 RID: 2103 RVA: 0x0001F5A2 File Offset: 0x0001D7A2
		public Columns columns
		{
			get
			{
				return this.m_Columns;
			}
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x06000838 RID: 2104 RVA: 0x0001F5AA File Offset: 0x0001D7AA
		public bool isDirty
		{
			get
			{
				return this.m_IsDirty;
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x06000839 RID: 2105 RVA: 0x0001F5B4 File Offset: 0x0001D7B4
		public float columnsWidth
		{
			get
			{
				bool columnsWidthDirty = this.m_ColumnsWidthDirty;
				if (columnsWidthDirty)
				{
					this.m_ColumnsWidth = 0f;
					foreach (Column column in this.m_Columns.visibleList)
					{
						this.m_ColumnsWidth += column.desiredWidth;
					}
					this.m_ColumnsWidthDirty = false;
				}
				return this.m_ColumnsWidth;
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x0600083A RID: 2106 RVA: 0x0001F640 File Offset: 0x0001D840
		public float layoutWidth
		{
			get
			{
				return this.m_LayoutWidth;
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x0600083B RID: 2107 RVA: 0x0001F648 File Offset: 0x0001D848
		public float minColumnsWidth
		{
			get
			{
				return this.m_MinColumnsWidth;
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x0600083C RID: 2108 RVA: 0x0001F650 File Offset: 0x0001D850
		public float maxColumnsWidth
		{
			get
			{
				return this.m_MaxColumnsWidth;
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x0600083D RID: 2109 RVA: 0x0001F658 File Offset: 0x0001D858
		public bool hasStretchableColumns
		{
			get
			{
				return this.m_StretchableColumns.Count > 0;
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x0600083E RID: 2110 RVA: 0x0001F668 File Offset: 0x0001D868
		public bool hasRelativeWidthColumns
		{
			get
			{
				return this.m_RelativeWidthColumns.Count > 0 || this.m_MixedWidthColumns.Count > 0;
			}
		}

		// Token: 0x14000025 RID: 37
		// (add) Token: 0x0600083F RID: 2111 RVA: 0x0001F68C File Offset: 0x0001D88C
		// (remove) Token: 0x06000840 RID: 2112 RVA: 0x0001F6C4 File Offset: 0x0001D8C4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event Action layoutRequested;

		// Token: 0x06000841 RID: 2113 RVA: 0x0001F6FC File Offset: 0x0001D8FC
		public ColumnLayout(Columns columns)
		{
			this.m_Columns = columns;
			for (int i = 0; i < columns.Count; i++)
			{
				this.OnColumnAdded(columns[i], i);
			}
			columns.columnAdded += this.OnColumnAdded;
			columns.columnRemoved += this.OnColumnRemoved;
			columns.columnReordered += this.OnColumnReordered;
		}

		// Token: 0x06000842 RID: 2114 RVA: 0x0001F810 File Offset: 0x0001DA10
		public void Dirty()
		{
			bool isDirty = this.m_IsDirty;
			if (!isDirty)
			{
				this.m_IsDirty = true;
				this.ClearCache();
				Action action = this.layoutRequested;
				if (action != null)
				{
					action();
				}
			}
		}

		// Token: 0x06000843 RID: 2115 RVA: 0x0001F84A File Offset: 0x0001DA4A
		private void OnColumnAdded(Column column, int index)
		{
			column.changed += this.OnColumnChanged;
			column.resized += this.OnColumnResized;
			this.Dirty();
		}

		// Token: 0x06000844 RID: 2116 RVA: 0x0001F87A File Offset: 0x0001DA7A
		private void OnColumnRemoved(Column column)
		{
			column.changed -= this.OnColumnChanged;
			column.resized -= this.OnColumnResized;
			this.Dirty();
		}

		// Token: 0x06000845 RID: 2117 RVA: 0x0001F8AA File Offset: 0x0001DAAA
		private void OnColumnReordered(Column column, int from, int to)
		{
			this.Dirty();
		}

		// Token: 0x06000846 RID: 2118 RVA: 0x0001F8B4 File Offset: 0x0001DAB4
		private bool RequiresLayoutUpdate(ColumnDataType type)
		{
			return type - ColumnDataType.Visibility <= 4 || type - ColumnDataType.HeaderTemplate <= 1;
		}

		// Token: 0x06000847 RID: 2119 RVA: 0x0001F8E0 File Offset: 0x0001DAE0
		private void OnColumnChanged(Column column, ColumnDataType type)
		{
			bool flag = this.m_DragResizing || !this.RequiresLayoutUpdate(type);
			if (!flag)
			{
				this.Dirty();
			}
		}

		// Token: 0x06000848 RID: 2120 RVA: 0x0001F910 File Offset: 0x0001DB10
		private void OnColumnResized(Column column)
		{
			this.m_ColumnsWidthDirty = true;
		}

		// Token: 0x06000849 RID: 2121 RVA: 0x0001F91C File Offset: 0x0001DB1C
		private static bool IsClamped(float value, float min, float max)
		{
			return value >= min && value <= max;
		}

		// Token: 0x0600084A RID: 2122 RVA: 0x0001F93C File Offset: 0x0001DB3C
		public void DoLayout(float width)
		{
			this.m_LayoutWidth = width;
			bool isDirty = this.m_IsDirty;
			if (isDirty)
			{
				this.UpdateCache();
			}
			bool hasRelativeWidthColumns = this.hasRelativeWidthColumns;
			if (hasRelativeWidthColumns)
			{
				this.UpdateMinAndMaxColumnsWidth();
			}
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			List<Column> list = new List<Column>();
			List<Column> list2 = new List<Column>();
			foreach (Column column in this.m_Columns)
			{
				bool flag = !column.visible;
				if (!flag)
				{
					float minWidth = column.GetMinWidth(this.m_LayoutWidth);
					float maxWidth = column.GetMaxWidth(this.m_LayoutWidth);
					float width2 = column.GetWidth(this.m_LayoutWidth);
					bool flag2 = float.IsNaN(column.desiredWidth);
					if (flag2)
					{
						bool flag3 = this.m_Columns.stretchMode == Columns.StretchMode.GrowAndFill && column.stretchable;
						if (flag3)
						{
							list.Add(column);
							continue;
						}
						column.desiredWidth = Mathf.Clamp(width2, minWidth, maxWidth);
					}
					else
					{
						bool flag4 = this.m_Columns.stretchMode == Columns.StretchMode.GrowAndFill && column.stretchable;
						if (flag4)
						{
							list2.Add(column);
							num3 += this.GetDesiredWidth(column);
						}
						bool flag5 = !ColumnLayout.IsClamped(column.desiredWidth, minWidth, maxWidth);
						if (flag5)
						{
							column.desiredWidth = Mathf.Clamp(width2, minWidth, maxWidth);
						}
						bool flag6 = this.columns.stretchMode == Columns.StretchMode.Grow && column.width.unit == LengthUnit.Percent;
						if (flag6)
						{
							column.desiredWidth = Mathf.Clamp(width2, minWidth, maxWidth);
						}
					}
					bool flag7 = !column.stretchable;
					if (flag7)
					{
						num2 += column.desiredWidth;
					}
					num += column.desiredWidth;
				}
			}
			bool flag8 = list.Count > 0;
			if (flag8)
			{
				float num4 = Math.Max(0f, width - num2);
				int num5 = this.m_StretchableColumns.Count;
				list.Sort((Column c1, Column c2) => c1.GetMaxWidth(this.m_LayoutWidth).CompareTo(c2.GetMaxWidth(this.m_LayoutWidth)));
				foreach (Column column2 in list)
				{
					float value = num4 / (float)num5;
					column2.desiredWidth = Mathf.Clamp(value, column2.GetMinWidth(this.m_LayoutWidth), column2.GetMaxWidth(this.m_LayoutWidth));
					num4 = Math.Max(0f, num4 - column2.desiredWidth);
					num5--;
				}
				list2.Sort((Column c1, Column c2) => c1.GetMaxWidth(this.m_LayoutWidth).CompareTo(c2.GetMaxWidth(this.m_LayoutWidth)));
				foreach (Column column3 in list2)
				{
					float desiredWidth = this.GetDesiredWidth(column3);
					float num6 = desiredWidth / num3;
					float value2 = num4 * num6;
					column3.desiredWidth = Mathf.Clamp(value2, column3.GetMinWidth(this.m_LayoutWidth), column3.GetMaxWidth(this.m_LayoutWidth));
					num4 = Math.Max(0f, num4 - column3.desiredWidth);
					num3 -= desiredWidth;
					num5--;
				}
			}
			bool flag9 = this.hasStretchableColumns || (this.hasRelativeWidthColumns && this.m_Columns.stretchMode == Columns.StretchMode.GrowAndFill);
			if (flag9)
			{
				float num7 = 0f;
				bool flag10 = this.m_Columns.stretchMode == Columns.StretchMode.Grow;
				if (flag10)
				{
					bool flag11 = !float.IsNaN(this.m_PreviousWidth);
					if (flag11)
					{
						num7 = this.m_PreviousWidth - width;
					}
				}
				else
				{
					num7 = this.columnsWidth - Mathf.Clamp(width, this.minColumnsWidth, this.maxColumnsWidth);
				}
				bool flag12 = num7 != 0f;
				if (flag12)
				{
					List<Column> list3;
					using (CollectionPool<List<Column>, Column>.Get(out list3))
					{
						List<Column> list4;
						using (CollectionPool<List<Column>, Column>.Get(out list4))
						{
							List<Column> list5;
							using (CollectionPool<List<Column>, Column>.Get(out list5))
							{
								list3.AddRange(this.m_StretchableColumns);
								list4.AddRange(this.m_FixedColumns);
								list5.AddRange(this.m_RelativeWidthColumns);
								this.StretchResizeColumns(list3, list4, list5, ref num7, false, false);
							}
						}
					}
				}
			}
			this.m_PreviousWidth = width;
			this.m_IsDirty = false;
		}

		// Token: 0x0600084B RID: 2123 RVA: 0x0001FE60 File Offset: 0x0001E060
		public void StretchResizeColumns(List<Column> stretchableColumns, List<Column> fixedColumns, List<Column> relativeWidthColumns, ref float delta, bool resizeToFit, bool dragResize)
		{
			bool flag = stretchableColumns.Count == 0 && relativeWidthColumns.Count == 0 && fixedColumns.Count == 0;
			if (!flag)
			{
				bool flag2 = delta > 0f;
				if (flag2)
				{
					this.DistributeOverflow(stretchableColumns, fixedColumns, relativeWidthColumns, ref delta, resizeToFit, dragResize);
				}
				else
				{
					this.DistributeExcess(stretchableColumns, fixedColumns, relativeWidthColumns, ref delta, resizeToFit, dragResize);
				}
			}
		}

		// Token: 0x0600084C RID: 2124 RVA: 0x0001FEC4 File Offset: 0x0001E0C4
		private void DistributeOverflow(List<Column> stretchableColumns, List<Column> fixedColumns, List<Column> relativeWidthColumns, ref float delta, bool resizeToFit, bool dragResize)
		{
			float num = Math.Abs(delta);
			bool flag = !resizeToFit && !dragResize;
			if (flag)
			{
				num = this.RecomputeToDesiredWidth(fixedColumns, num, true, true);
				num = this.RecomputeToDesiredWidth(relativeWidthColumns, num, true, true);
			}
			num = this.RecomputeToMinWidthProportionally(stretchableColumns, num, !resizeToFit && !dragResize);
			if (resizeToFit)
			{
				num = this.RecomputeToMinWidthProportionally(relativeWidthColumns, num, false);
				num = this.RecomputeToMinWidthProportionally(fixedColumns, num, false);
				num = this.RecomputeToMinWidth(relativeWidthColumns, num, false);
				num = this.RecomputeToMinWidth(fixedColumns, num, false);
			}
			else if (dragResize)
			{
				num = this.RecomputeToMinWidth(relativeWidthColumns, num, true);
				num = this.RecomputeToMinWidth(fixedColumns, num, true);
			}
			else
			{
				bool flag2 = num > 0f;
				if (flag2)
				{
					num = this.RecomputeToMinWidth(relativeWidthColumns, num, true);
					num = this.RecomputeToMinWidth(fixedColumns, num, true);
				}
			}
			delta = Math.Max(0f, delta - num);
		}

		// Token: 0x0600084D RID: 2125 RVA: 0x0001FF9C File Offset: 0x0001E19C
		private void DistributeExcess(List<Column> stretchableColumns, List<Column> fixedColumns, List<Column> relativeWidthColumns, ref float delta, bool resizeToFit, bool dragResize)
		{
			float num = Math.Abs(delta);
			bool flag = !resizeToFit && !dragResize;
			if (flag)
			{
				num = this.RecomputeToDesiredWidth(fixedColumns, num, true, false);
				num = this.RecomputeToDesiredWidth(relativeWidthColumns, num, true, false);
			}
			if (dragResize)
			{
				num = this.RecomputeToDesiredWidth(fixedColumns, num, true, false);
				num = this.RecomputeToDesiredWidth(relativeWidthColumns, num, true, false);
			}
			num = this.RecomputeToMaxWidthProportionally(stretchableColumns, num, !resizeToFit && !dragResize);
			if (resizeToFit)
			{
				num = this.RecomputeToMaxWidthProportionally(relativeWidthColumns, num, false);
				num = this.RecomputeToMaxWidthProportionally(fixedColumns, num, false);
				num = this.RecomputeToMaxWidth(relativeWidthColumns, num, false);
				num = this.RecomputeToMaxWidth(fixedColumns, num, false);
			}
			delta += num;
		}

		// Token: 0x0600084E RID: 2126 RVA: 0x00020044 File Offset: 0x0001E244
		private float RecomputeToMaxWidthProportionally(List<Column> columns, float distributedDelta, bool setDesiredWidthOnly = false)
		{
			bool flag = distributedDelta > 0f;
			if (flag)
			{
				columns.Sort((Column c1, Column c2) => c1.GetMaxWidth(this.m_LayoutWidth).CompareTo(c2.GetMaxWidth(this.m_LayoutWidth)));
				float totalColumnWidth = 0f;
				columns.ForEach(delegate(Column c)
				{
					totalColumnWidth += this.GetDesiredWidth(c);
				});
				for (int i = 0; i < columns.Count; i++)
				{
					Column column = columns[i];
					float desiredWidth = this.GetDesiredWidth(column);
					float num = this.GetDesiredWidth(column) / totalColumnWidth;
					float val = distributedDelta * num;
					float num2 = 0f;
					float maxWidth = column.GetMaxWidth(this.m_LayoutWidth);
					bool flag2 = this.GetDesiredWidth(column) < maxWidth;
					if (flag2)
					{
						num2 = Math.Min(val, maxWidth - this.GetDesiredWidth(column));
					}
					bool flag3 = num2 > 0f;
					if (flag3)
					{
						this.ResizeColumn(column, this.GetDesiredWidth(column) + num2, setDesiredWidthOnly);
					}
					totalColumnWidth -= desiredWidth;
					distributedDelta -= num2;
					bool flag4 = distributedDelta <= 0f;
					if (flag4)
					{
						break;
					}
				}
			}
			return distributedDelta;
		}

		// Token: 0x0600084F RID: 2127 RVA: 0x00020174 File Offset: 0x0001E374
		private float RecomputeToMinWidthProportionally(List<Column> columns, float distributedDelta, bool setDesiredWidthOnly = false)
		{
			bool flag = distributedDelta > 0f;
			if (flag)
			{
				columns.Sort((Column c1, Column c2) => c2.GetMinWidth(this.m_LayoutWidth).CompareTo(c1.GetMinWidth(this.m_LayoutWidth)));
				float totalColumnsWidth = 0f;
				columns.ForEach(delegate(Column c)
				{
					totalColumnsWidth += this.GetDesiredWidth(c);
				});
				for (int i = 0; i < columns.Count; i++)
				{
					Column column = columns[i];
					float desiredWidth = this.GetDesiredWidth(column);
					float num = this.GetDesiredWidth(column) / totalColumnsWidth;
					float val = distributedDelta * num;
					float num2 = 0f;
					bool flag2 = this.GetDesiredWidth(column) > column.GetMinWidth(this.m_LayoutWidth);
					if (flag2)
					{
						num2 = Math.Min(val, this.GetDesiredWidth(column) - column.GetMinWidth(this.m_LayoutWidth));
					}
					bool flag3 = num2 > 0f;
					if (flag3)
					{
						this.ResizeColumn(column, this.GetDesiredWidth(column) - num2, setDesiredWidthOnly);
					}
					totalColumnsWidth -= desiredWidth;
					distributedDelta -= num2;
					bool flag4 = distributedDelta <= 0f;
					if (flag4)
					{
						break;
					}
				}
			}
			return distributedDelta;
		}

		// Token: 0x06000850 RID: 2128 RVA: 0x000202A8 File Offset: 0x0001E4A8
		private float RecomputeToDesiredWidth(List<Column> columns, float distributedDelta, bool setDesiredWidthOnly, bool distributeOverflow)
		{
			if (distributeOverflow)
			{
				for (int i = columns.Count - 1; i >= 0; i--)
				{
					distributedDelta = this.RecomputeToDesiredWidth(columns[i], distributedDelta, setDesiredWidthOnly, true);
					bool flag = distributedDelta <= 0f;
					if (flag)
					{
						break;
					}
				}
			}
			else
			{
				for (int j = 0; j < columns.Count; j++)
				{
					distributedDelta = this.RecomputeToDesiredWidth(columns[j], distributedDelta, setDesiredWidthOnly, false);
					bool flag2 = distributedDelta <= 0f;
					if (flag2)
					{
						break;
					}
				}
			}
			return distributedDelta;
		}

		// Token: 0x06000851 RID: 2129 RVA: 0x0002034C File Offset: 0x0001E54C
		private float RecomputeToDesiredWidth(Column column, float distributedDelta, bool setDesiredWidthOnly, bool distributeOverflow)
		{
			float num = 0f;
			float num2 = Mathf.Clamp(column.GetWidth(this.m_LayoutWidth), column.GetMinWidth(this.m_LayoutWidth), column.GetMaxWidth(this.m_LayoutWidth));
			bool flag = this.GetDesiredWidth(column) > num2 && distributeOverflow;
			if (flag)
			{
				num = Math.Min(distributedDelta, Math.Abs(this.GetDesiredWidth(column) - num2));
			}
			bool flag2 = this.GetDesiredWidth(column) < num2 && !distributeOverflow;
			if (flag2)
			{
				num = Math.Min(distributedDelta, Math.Abs(num2 - this.GetDesiredWidth(column)));
			}
			float width = distributeOverflow ? (this.GetDesiredWidth(column) - num) : (this.GetDesiredWidth(column) + num);
			bool flag3 = num > 0f;
			if (flag3)
			{
				this.ResizeColumn(column, width, setDesiredWidthOnly);
			}
			distributedDelta -= num;
			return distributedDelta;
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x0002041C File Offset: 0x0001E61C
		private float RecomputeToMinWidth(List<Column> columns, float distributedDelta, bool setDesiredWidthOnly = false)
		{
			bool flag = distributedDelta > 0f;
			if (flag)
			{
				for (int i = columns.Count - 1; i >= 0; i--)
				{
					Column column = columns[i];
					float num = 0f;
					bool flag2 = this.GetDesiredWidth(column) > column.GetMinWidth(this.m_LayoutWidth);
					if (flag2)
					{
						num = Math.Min(distributedDelta, this.GetDesiredWidth(column) - column.GetMinWidth(this.m_LayoutWidth));
					}
					bool flag3 = num > 0f;
					if (flag3)
					{
						this.ResizeColumn(column, this.GetDesiredWidth(column) - num, setDesiredWidthOnly);
					}
					distributedDelta -= num;
					bool flag4 = distributedDelta <= 0f;
					if (flag4)
					{
						break;
					}
				}
			}
			return distributedDelta;
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x000204E4 File Offset: 0x0001E6E4
		private float RecomputeToMaxWidth(List<Column> columns, float distributedDelta, bool setDesiredWidthOnly = false)
		{
			bool flag = distributedDelta > 0f;
			if (flag)
			{
				for (int i = 0; i < columns.Count; i++)
				{
					Column column = columns[i];
					float num = 0f;
					bool flag2 = this.GetDesiredWidth(column) < column.GetMaxWidth(this.m_LayoutWidth);
					if (flag2)
					{
						num = Math.Min(distributedDelta, Math.Abs(column.GetMaxWidth(this.m_LayoutWidth) - this.GetDesiredWidth(column)));
					}
					bool flag3 = num > 0f;
					if (flag3)
					{
						this.ResizeColumn(column, this.GetDesiredWidth(column) + num, setDesiredWidthOnly);
					}
					distributedDelta -= num;
					bool flag4 = distributedDelta <= 0f;
					if (flag4)
					{
						break;
					}
				}
			}
			return distributedDelta;
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x000205AC File Offset: 0x0001E7AC
		public void ResizeToFit(float width)
		{
			float num = this.columnsWidth - Mathf.Clamp(width, this.minColumnsWidth, this.maxColumnsWidth);
			List<Column> list;
			using (CollectionPool<List<Column>, Column>.Get(out list))
			{
				List<Column> list2;
				using (CollectionPool<List<Column>, Column>.Get(out list2))
				{
					List<Column> list3;
					using (CollectionPool<List<Column>, Column>.Get(out list3))
					{
						list.AddRange(this.m_StretchableColumns);
						list2.AddRange(this.m_FixedColumns);
						list3.AddRange(this.m_RelativeWidthColumns);
						this.StretchResizeColumns(list, list2, list3, ref num, true, false);
						bool isDirty = this.m_IsDirty;
						if (isDirty)
						{
							this.UpdateCache();
						}
					}
				}
			}
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x00020690 File Offset: 0x0001E890
		private void ResizeColumn(Column column, float width, bool setDesiredWidthOnly = false)
		{
			Length length = new Length(width / this.layoutWidth * 100f, LengthUnit.Percent);
			bool dragResizeInPreviewMode = this.m_DragResizeInPreviewMode;
			if (dragResizeInPreviewMode)
			{
				this.m_PreviewDesiredWidths[column] = width;
			}
			else
			{
				bool flag = !setDesiredWidthOnly;
				if (flag)
				{
					column.width = ((column.width.unit == LengthUnit.Percent) ? length : width);
				}
				column.desiredWidth = width;
			}
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x00020708 File Offset: 0x0001E908
		internal void BeginDragResize(Column column, float pos, bool previewMode)
		{
			bool isDirty = this.m_IsDirty;
			if (isDirty)
			{
				throw new Exception("Cannot begin resizing columns because the layout needs to be updated");
			}
			this.m_DragResizeInPreviewMode = previewMode;
			this.m_DragResizing = true;
			int visibleIndex = column.visibleIndex;
			this.m_DragStartPos = pos;
			this.m_DragLastPos = pos;
			this.m_DragInitialColumnWidth = column.desiredWidth;
			this.m_DragStretchableColumns.Clear();
			this.m_DragFixedColumns.Clear();
			this.m_DragRelativeColumns.Clear();
			bool dragResizeInPreviewMode = this.m_DragResizeInPreviewMode;
			if (dragResizeInPreviewMode)
			{
				bool flag = this.m_PreviewDesiredWidths == null;
				if (flag)
				{
					this.m_PreviewDesiredWidths = new Dictionary<Column, float>();
				}
				this.m_PreviewDesiredWidths[column] = column.desiredWidth;
			}
			for (int i = visibleIndex + 1; i < this.m_Columns.visibleList.Count<Column>(); i++)
			{
				Column column2 = this.m_Columns.visibleList.ElementAt(i);
				bool flag2 = !column2.visible;
				if (!flag2)
				{
					bool stretchable = column2.stretchable;
					if (stretchable)
					{
						this.m_DragStretchableColumns.Add(column2);
					}
					else
					{
						bool flag3 = column2.width.unit == LengthUnit.Percent;
						if (flag3)
						{
							this.m_DragRelativeColumns.Add(column2);
						}
						else
						{
							this.m_DragFixedColumns.Add(column2);
						}
					}
					bool dragResizeInPreviewMode2 = this.m_DragResizeInPreviewMode;
					if (dragResizeInPreviewMode2)
					{
						this.m_PreviewDesiredWidths[column2] = column2.desiredWidth;
					}
				}
			}
		}

		// Token: 0x06000857 RID: 2135 RVA: 0x00020888 File Offset: 0x0001EA88
		public float GetDesiredPosition(Column column)
		{
			bool flag = !column.visible;
			float result;
			if (flag)
			{
				result = float.NaN;
			}
			else
			{
				float num = 0f;
				for (int i = 0; i < column.visibleIndex; i++)
				{
					Column c = this.m_Columns.visibleList.ElementAt(i);
					float desiredWidth = this.GetDesiredWidth(c);
					bool flag2 = float.IsNaN(desiredWidth);
					if (!flag2)
					{
						num += desiredWidth;
					}
				}
				result = num;
			}
			return result;
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x00020900 File Offset: 0x0001EB00
		public float GetDesiredWidth(Column c)
		{
			bool flag = this.m_DragResizeInPreviewMode && this.m_PreviewDesiredWidths.ContainsKey(c);
			float result;
			if (flag)
			{
				result = this.m_PreviewDesiredWidths[c];
			}
			else
			{
				result = c.desiredWidth;
			}
			return result;
		}

		// Token: 0x06000859 RID: 2137 RVA: 0x00020944 File Offset: 0x0001EB44
		public void DragResize(Column column, float pos)
		{
			float minWidth = column.GetMinWidth(this.m_LayoutWidth);
			float maxWidth = column.GetMaxWidth(this.m_LayoutWidth);
			bool flag = this.m_Columns.stretchMode == Columns.StretchMode.GrowAndFill;
			if (flag)
			{
				float num = pos - this.m_DragLastPos;
				float num2 = Mathf.Clamp(this.GetDesiredWidth(column) + num, minWidth, maxWidth);
				num = num2 - this.GetDesiredWidth(column);
				bool flag2 = this.m_DragStretchableColumns.Count == 0 && num < 0f;
				if (flag2)
				{
					this.StretchResizeColumns(this.m_DragStretchableColumns, this.m_DragFixedColumns, this.m_DragRelativeColumns, ref num, false, true);
					num2 = Mathf.Clamp(this.GetDesiredWidth(column) + num2 - this.GetDesiredWidth(column), minWidth, maxWidth);
				}
				else
				{
					bool flag3 = num > 0f && this.columnsWidth + num < this.m_LayoutWidth;
					if (flag3)
					{
						float num3 = (num < this.m_LayoutWidth - this.columnsWidth) ? 0f : (num - (this.m_LayoutWidth - this.columnsWidth));
						this.StretchResizeColumns(this.m_DragStretchableColumns, this.m_DragFixedColumns, this.m_DragRelativeColumns, ref num3, false, true);
						num2 = Mathf.Clamp(this.GetDesiredWidth(column) + num - num3, minWidth, maxWidth);
					}
					else
					{
						this.StretchResizeColumns(this.m_DragStretchableColumns, this.m_DragFixedColumns, this.m_DragRelativeColumns, ref num, false, true);
						num2 = Mathf.Clamp(this.GetDesiredWidth(column) + num, minWidth, maxWidth);
					}
				}
				this.ResizeColumn(column, num2, false);
			}
			else
			{
				float num4 = pos - this.m_DragStartPos;
				float width = Math.Max(minWidth, Math.Min(maxWidth, this.m_DragInitialColumnWidth + num4));
				this.ResizeColumn(column, width, false);
			}
			this.m_DragLastPos = pos;
		}

		// Token: 0x0600085A RID: 2138 RVA: 0x00020AFC File Offset: 0x0001ECFC
		internal void EndDragResize(Column column, bool cancelled)
		{
			bool dragResizeInPreviewMode = this.m_DragResizeInPreviewMode;
			if (dragResizeInPreviewMode)
			{
				this.m_DragResizeInPreviewMode = false;
				bool flag = !cancelled;
				if (flag)
				{
					foreach (KeyValuePair<Column, float> keyValuePair in this.m_PreviewDesiredWidths)
					{
						this.ResizeColumn(keyValuePair.Key, keyValuePair.Value, keyValuePair.Key != column);
					}
				}
				this.m_PreviewDesiredWidths.Clear();
			}
			this.m_DragResizing = false;
			this.m_DragStretchableColumns.Clear();
			this.m_DragFixedColumns.Clear();
			this.m_DragRelativeColumns.Clear();
		}

		// Token: 0x0600085B RID: 2139 RVA: 0x00020BC4 File Offset: 0x0001EDC4
		private void UpdateCache()
		{
			this.ClearCache();
			foreach (Column column in this.m_Columns.visibleList)
			{
				bool flag = column.stretchable && this.columns.stretchMode == Columns.StretchMode.GrowAndFill;
				if (flag)
				{
					this.m_StretchableColumns.Add(column);
				}
				else
				{
					bool flag2 = column.width.unit == LengthUnit.Pixel;
					if (flag2)
					{
						this.m_FixedColumns.Add(column);
					}
				}
				bool flag3 = column.width.unit == LengthUnit.Percent;
				if (flag3)
				{
					this.m_RelativeWidthColumns.Add(column);
				}
				bool flag4 = column.width.unit == LengthUnit.Pixel && (column.minWidth.unit == LengthUnit.Percent || column.maxWidth.unit == LengthUnit.Percent);
				if (flag4)
				{
					this.m_MixedWidthColumns.Add(column);
				}
				this.m_MaxColumnsWidth += column.GetMaxWidth(this.m_LayoutWidth);
				this.m_MinColumnsWidth += column.GetMinWidth(this.m_LayoutWidth);
			}
		}

		// Token: 0x0600085C RID: 2140 RVA: 0x00020D24 File Offset: 0x0001EF24
		private void UpdateMinAndMaxColumnsWidth()
		{
			this.m_MaxColumnsWidth = 0f;
			this.m_MinColumnsWidth = 0f;
			foreach (Column column in this.m_Columns.visibleList)
			{
				this.m_MaxColumnsWidth += column.GetMaxWidth(this.m_LayoutWidth);
				this.m_MinColumnsWidth += column.GetMinWidth(this.m_LayoutWidth);
			}
		}

		// Token: 0x0600085D RID: 2141 RVA: 0x00020DBC File Offset: 0x0001EFBC
		private void ClearCache()
		{
			this.m_StretchableColumns.Clear();
			this.m_RelativeWidthColumns.Clear();
			this.m_FixedColumns.Clear();
			this.m_MaxColumnsWidth = 0f;
			this.m_MinColumnsWidth = 0f;
			this.m_ColumnsWidthDirty = true;
		}

		// Token: 0x040003A9 RID: 937
		private List<Column> m_StretchableColumns = new List<Column>();

		// Token: 0x040003AA RID: 938
		private List<Column> m_FixedColumns = new List<Column>();

		// Token: 0x040003AB RID: 939
		private List<Column> m_RelativeWidthColumns = new List<Column>();

		// Token: 0x040003AC RID: 940
		private List<Column> m_MixedWidthColumns = new List<Column>();

		// Token: 0x040003AD RID: 941
		private Columns m_Columns;

		// Token: 0x040003AE RID: 942
		private float m_ColumnsWidth = 0f;

		// Token: 0x040003AF RID: 943
		private bool m_ColumnsWidthDirty = true;

		// Token: 0x040003B0 RID: 944
		private float m_MaxColumnsWidth = 0f;

		// Token: 0x040003B1 RID: 945
		private float m_MinColumnsWidth = 0f;

		// Token: 0x040003B2 RID: 946
		private bool m_IsDirty = false;

		// Token: 0x040003B3 RID: 947
		private float m_PreviousWidth = float.NaN;

		// Token: 0x040003B4 RID: 948
		private float m_LayoutWidth = float.NaN;

		// Token: 0x040003B5 RID: 949
		private bool m_DragResizeInPreviewMode;

		// Token: 0x040003B6 RID: 950
		private bool m_DragResizing = false;

		// Token: 0x040003B7 RID: 951
		private float m_DragStartPos;

		// Token: 0x040003B8 RID: 952
		private float m_DragLastPos;

		// Token: 0x040003B9 RID: 953
		private float m_DragInitialColumnWidth;

		// Token: 0x040003BA RID: 954
		private List<Column> m_DragStretchableColumns = new List<Column>();

		// Token: 0x040003BB RID: 955
		private List<Column> m_DragRelativeColumns = new List<Column>();

		// Token: 0x040003BC RID: 956
		private List<Column> m_DragFixedColumns = new List<Column>();

		// Token: 0x040003BD RID: 957
		private Dictionary<Column, float> m_PreviewDesiredWidths;
	}
}
