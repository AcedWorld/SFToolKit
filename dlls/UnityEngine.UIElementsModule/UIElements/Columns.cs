using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace UnityEngine.UIElements
{
	// Token: 0x020000F6 RID: 246
	public class Columns : ICollection<Column>, IEnumerable<Column>, IEnumerable
	{
		// Token: 0x17000192 RID: 402
		// (get) Token: 0x06000866 RID: 2150 RVA: 0x00020EFF File Offset: 0x0001F0FF
		internal IList<Column> columns
		{
			get
			{
				return this.m_Columns;
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x06000867 RID: 2151 RVA: 0x00020F07 File Offset: 0x0001F107
		// (set) Token: 0x06000868 RID: 2152 RVA: 0x00020F10 File Offset: 0x0001F110
		public string primaryColumnName
		{
			get
			{
				return this.m_PrimaryColumnName;
			}
			set
			{
				bool flag = this.m_PrimaryColumnName == value;
				if (!flag)
				{
					this.m_PrimaryColumnName = value;
					this.NotifyChange(ColumnsDataType.PrimaryColumn);
				}
			}
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06000869 RID: 2153 RVA: 0x00020F3F File Offset: 0x0001F13F
		// (set) Token: 0x0600086A RID: 2154 RVA: 0x00020F48 File Offset: 0x0001F148
		public bool reorderable
		{
			get
			{
				return this.m_Reorderable;
			}
			set
			{
				bool flag = this.m_Reorderable == value;
				if (!flag)
				{
					this.m_Reorderable = value;
					this.NotifyChange(ColumnsDataType.Reorderable);
				}
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x0600086B RID: 2155 RVA: 0x00020F74 File Offset: 0x0001F174
		// (set) Token: 0x0600086C RID: 2156 RVA: 0x00020F7C File Offset: 0x0001F17C
		public bool resizable
		{
			get
			{
				return this.m_Resizable;
			}
			set
			{
				bool flag = this.m_Resizable == value;
				if (!flag)
				{
					this.m_Resizable = value;
					this.NotifyChange(ColumnsDataType.Resizable);
				}
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x0600086D RID: 2157 RVA: 0x00020FA8 File Offset: 0x0001F1A8
		// (set) Token: 0x0600086E RID: 2158 RVA: 0x00020FB0 File Offset: 0x0001F1B0
		public bool resizePreview
		{
			get
			{
				return this.m_ResizePreview;
			}
			set
			{
				bool flag = this.m_ResizePreview == value;
				if (!flag)
				{
					this.m_ResizePreview = value;
					this.NotifyChange(ColumnsDataType.ResizePreview);
				}
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x0600086F RID: 2159 RVA: 0x00020FDC File Offset: 0x0001F1DC
		internal IEnumerable<Column> displayList
		{
			get
			{
				this.InitOrderColumns();
				return this.m_DisplayColumns;
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x06000870 RID: 2160 RVA: 0x00020FFC File Offset: 0x0001F1FC
		internal IEnumerable<Column> visibleList
		{
			get
			{
				this.UpdateVisibleColumns();
				return this.m_VisibleColumns;
			}
		}

		// Token: 0x14000026 RID: 38
		// (add) Token: 0x06000871 RID: 2161 RVA: 0x0002101C File Offset: 0x0001F21C
		// (remove) Token: 0x06000872 RID: 2162 RVA: 0x00021054 File Offset: 0x0001F254
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal event Action<ColumnsDataType> changed;

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x06000873 RID: 2163 RVA: 0x00021089 File Offset: 0x0001F289
		// (set) Token: 0x06000874 RID: 2164 RVA: 0x00021094 File Offset: 0x0001F294
		public Columns.StretchMode stretchMode
		{
			get
			{
				return this.m_StretchMode;
			}
			set
			{
				bool flag = this.m_StretchMode == value;
				if (!flag)
				{
					this.m_StretchMode = value;
					this.NotifyChange(ColumnsDataType.StretchMode);
				}
			}
		}

		// Token: 0x14000027 RID: 39
		// (add) Token: 0x06000875 RID: 2165 RVA: 0x000210C0 File Offset: 0x0001F2C0
		// (remove) Token: 0x06000876 RID: 2166 RVA: 0x000210F8 File Offset: 0x0001F2F8
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal event Action<Column, int> columnAdded;

		// Token: 0x14000028 RID: 40
		// (add) Token: 0x06000877 RID: 2167 RVA: 0x00021130 File Offset: 0x0001F330
		// (remove) Token: 0x06000878 RID: 2168 RVA: 0x00021168 File Offset: 0x0001F368
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal event Action<Column> columnRemoved;

		// Token: 0x14000029 RID: 41
		// (add) Token: 0x06000879 RID: 2169 RVA: 0x000211A0 File Offset: 0x0001F3A0
		// (remove) Token: 0x0600087A RID: 2170 RVA: 0x000211D8 File Offset: 0x0001F3D8
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal event Action<Column, ColumnDataType> columnChanged;

		// Token: 0x1400002A RID: 42
		// (add) Token: 0x0600087B RID: 2171 RVA: 0x00021210 File Offset: 0x0001F410
		// (remove) Token: 0x0600087C RID: 2172 RVA: 0x00021248 File Offset: 0x0001F448
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal event Action<Column> columnResized;

		// Token: 0x1400002B RID: 43
		// (add) Token: 0x0600087D RID: 2173 RVA: 0x00021280 File Offset: 0x0001F480
		// (remove) Token: 0x0600087E RID: 2174 RVA: 0x000212B8 File Offset: 0x0001F4B8
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal event Action<Column, int, int> columnReordered;

		// Token: 0x0600087F RID: 2175 RVA: 0x000212F0 File Offset: 0x0001F4F0
		public bool IsPrimary(Column column)
		{
			return this.primaryColumnName == column.name || (string.IsNullOrEmpty(this.primaryColumnName) && column.visibleIndex == 0);
		}

		// Token: 0x06000880 RID: 2176 RVA: 0x00021334 File Offset: 0x0001F534
		public IEnumerator<Column> GetEnumerator()
		{
			return this.m_Columns.GetEnumerator();
		}

		// Token: 0x06000881 RID: 2177 RVA: 0x00021354 File Offset: 0x0001F554
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x0002136C File Offset: 0x0001F56C
		public void Add(Column item)
		{
			this.Insert(this.m_Columns.Count, item);
		}

		// Token: 0x06000883 RID: 2179 RVA: 0x00021384 File Offset: 0x0001F584
		public void Clear()
		{
			while (this.m_Columns.Count > 0)
			{
				this.Remove(this.m_Columns[this.m_Columns.Count - 1]);
			}
		}

		// Token: 0x06000884 RID: 2180 RVA: 0x000213C8 File Offset: 0x0001F5C8
		public bool Contains(Column item)
		{
			return this.m_Columns.Contains(item);
		}

		// Token: 0x06000885 RID: 2181 RVA: 0x000213E8 File Offset: 0x0001F5E8
		public bool Contains(string name)
		{
			foreach (Column column in this.m_Columns)
			{
				bool flag = column.name == name;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000886 RID: 2182 RVA: 0x0002144C File Offset: 0x0001F64C
		public void CopyTo(Column[] array, int arrayIndex)
		{
			this.m_Columns.CopyTo(array, arrayIndex);
		}

		// Token: 0x06000887 RID: 2183 RVA: 0x00021460 File Offset: 0x0001F660
		public bool Remove(Column column)
		{
			bool flag = column == null;
			if (flag)
			{
				throw new ArgumentException("Cannot remove null column");
			}
			bool flag2 = this.m_Columns.Remove(column);
			bool result;
			if (flag2)
			{
				List<Column> displayColumns = this.m_DisplayColumns;
				if (displayColumns != null)
				{
					displayColumns.Remove(column);
				}
				List<Column> visibleColumns = this.m_VisibleColumns;
				if (visibleColumns != null)
				{
					visibleColumns.Remove(column);
				}
				column.collection = null;
				column.changed -= this.OnColumnChanged;
				column.resized -= this.OnColumnResized;
				Action<Column> action = this.columnRemoved;
				if (action != null)
				{
					action(column);
				}
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000888 RID: 2184 RVA: 0x00021504 File Offset: 0x0001F704
		private void OnColumnChanged(Column column, ColumnDataType type)
		{
			bool flag = type == ColumnDataType.Visibility;
			if (flag)
			{
				this.DirtyVisibleColumns();
			}
			Action<Column, ColumnDataType> action = this.columnChanged;
			if (action != null)
			{
				action(column, type);
			}
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x00021535 File Offset: 0x0001F735
		private void OnColumnResized(Column column)
		{
			Action<Column> action = this.columnResized;
			if (action != null)
			{
				action(column);
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x0600088A RID: 2186 RVA: 0x0002154B File Offset: 0x0001F74B
		public int Count
		{
			get
			{
				return this.m_Columns.Count;
			}
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x0600088B RID: 2187 RVA: 0x00021558 File Offset: 0x0001F758
		public bool IsReadOnly
		{
			get
			{
				return this.m_Columns.IsReadOnly;
			}
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x00021568 File Offset: 0x0001F768
		public int IndexOf(Column column)
		{
			return this.m_Columns.IndexOf(column);
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x00021588 File Offset: 0x0001F788
		public void Insert(int index, Column column)
		{
			bool flag = column == null;
			if (flag)
			{
				throw new ArgumentException("Cannot insert null column");
			}
			bool flag2 = column.collection == this;
			if (flag2)
			{
				throw new ArgumentException("Already contains this column");
			}
			bool flag3 = column.collection != null;
			if (flag3)
			{
				column.collection.Remove(column);
			}
			this.m_Columns.Insert(index, column);
			bool flag4 = this.m_DisplayColumns != null;
			if (flag4)
			{
				this.m_DisplayColumns.Insert(index, column);
				this.DirtyVisibleColumns();
			}
			column.collection = this;
			column.changed += this.OnColumnChanged;
			column.resized += this.OnColumnResized;
			Action<Column, int> action = this.columnAdded;
			if (action != null)
			{
				action(column, index);
			}
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x0002164F File Offset: 0x0001F84F
		public void RemoveAt(int index)
		{
			this.Remove(this.m_Columns[index]);
		}

		// Token: 0x1700019C RID: 412
		public Column this[int index]
		{
			get
			{
				return this.m_Columns[index];
			}
		}

		// Token: 0x1700019D RID: 413
		public Column this[string name]
		{
			get
			{
				foreach (Column column in this.m_Columns)
				{
					bool flag = column.name == name;
					if (flag)
					{
						return column;
					}
				}
				return null;
			}
		}

		// Token: 0x06000891 RID: 2193 RVA: 0x000216EC File Offset: 0x0001F8EC
		public void ReorderDisplay(int from, int to)
		{
			this.InitOrderColumns();
			Column column = this.m_DisplayColumns[from];
			this.m_DisplayColumns.RemoveAt(from);
			this.m_DisplayColumns.Insert(to, column);
			this.DirtyVisibleColumns();
			Action<Column, int, int> action = this.columnReordered;
			if (action != null)
			{
				action(column, from, to);
			}
		}

		// Token: 0x06000892 RID: 2194 RVA: 0x00021748 File Offset: 0x0001F948
		private void InitOrderColumns()
		{
			bool flag = this.m_DisplayColumns == null;
			if (flag)
			{
				this.m_DisplayColumns = new List<Column>(this);
			}
		}

		// Token: 0x06000893 RID: 2195 RVA: 0x00021774 File Offset: 0x0001F974
		private void DirtyVisibleColumns()
		{
			this.m_VisibleColumnsDirty = true;
			bool flag = this.m_VisibleColumns != null;
			if (flag)
			{
				this.m_VisibleColumns.Clear();
			}
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x000217A4 File Offset: 0x0001F9A4
		private void UpdateVisibleColumns()
		{
			bool flag = !this.m_VisibleColumnsDirty;
			if (!flag)
			{
				this.InitOrderColumns();
				bool flag2 = this.m_VisibleColumns == null;
				if (flag2)
				{
					this.m_VisibleColumns = new List<Column>(this.m_Columns.Count);
				}
				this.m_VisibleColumns.AddRange(this.m_DisplayColumns.FindAll((Column c) => c.visible));
				this.m_VisibleColumnsDirty = false;
			}
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x0002182A File Offset: 0x0001FA2A
		private void NotifyChange(ColumnsDataType type)
		{
			Action<ColumnsDataType> action = this.changed;
			if (action != null)
			{
				action(type);
			}
		}

		// Token: 0x040003C9 RID: 969
		private IList<Column> m_Columns = new List<Column>();

		// Token: 0x040003CA RID: 970
		private List<Column> m_DisplayColumns;

		// Token: 0x040003CB RID: 971
		private List<Column> m_VisibleColumns;

		// Token: 0x040003CC RID: 972
		private bool m_VisibleColumnsDirty = true;

		// Token: 0x040003CD RID: 973
		private Columns.StretchMode m_StretchMode = Columns.StretchMode.GrowAndFill;

		// Token: 0x040003CE RID: 974
		private bool m_Reorderable = true;

		// Token: 0x040003CF RID: 975
		private bool m_Resizable = true;

		// Token: 0x040003D0 RID: 976
		private bool m_ResizePreview;

		// Token: 0x040003D1 RID: 977
		private string m_PrimaryColumnName;

		// Token: 0x020000F7 RID: 247
		public enum StretchMode
		{
			// Token: 0x040003D9 RID: 985
			Grow,
			// Token: 0x040003DA RID: 986
			GrowAndFill
		}

		// Token: 0x020000F8 RID: 248
		internal class UxmlObjectFactory<T> : UxmlObjectFactory<T, Columns.UxmlObjectTraits<T>> where T : Columns, new()
		{
		}

		// Token: 0x020000F9 RID: 249
		internal class UxmlObjectTraits<T> : UnityEngine.UIElements.UxmlObjectTraits<T> where T : Columns
		{
			// Token: 0x06000898 RID: 2200 RVA: 0x0002187C File Offset: 0x0001FA7C
			public override void Init(ref T obj, IUxmlAttributes bag, CreationContext cc)
			{
				base.Init(ref obj, bag, cc);
				obj.primaryColumnName = this.m_PrimaryColumnName.GetValueFromBag(bag, cc);
				obj.stretchMode = this.m_StretchMode.GetValueFromBag(bag, cc);
				obj.reorderable = this.m_Reorderable.GetValueFromBag(bag, cc);
				obj.resizable = this.m_Resizable.GetValueFromBag(bag, cc);
				obj.resizePreview = this.m_ResizePreview.GetValueFromBag(bag, cc);
				List<Column> valueFromBag = this.m_Columns.GetValueFromBag(bag, cc);
				bool flag = valueFromBag != null;
				if (flag)
				{
					foreach (Column item in valueFromBag)
					{
						obj.Add(item);
					}
				}
			}

			// Token: 0x040003DB RID: 987
			private readonly UxmlStringAttributeDescription m_PrimaryColumnName = new UxmlStringAttributeDescription
			{
				name = "primary-column-name"
			};

			// Token: 0x040003DC RID: 988
			private readonly UxmlEnumAttributeDescription<Columns.StretchMode> m_StretchMode = new UxmlEnumAttributeDescription<Columns.StretchMode>
			{
				name = "stretch-mode",
				defaultValue = Columns.StretchMode.GrowAndFill
			};

			// Token: 0x040003DD RID: 989
			private readonly UxmlBoolAttributeDescription m_Reorderable = new UxmlBoolAttributeDescription
			{
				name = "reorderable",
				defaultValue = true
			};

			// Token: 0x040003DE RID: 990
			private readonly UxmlBoolAttributeDescription m_Resizable = new UxmlBoolAttributeDescription
			{
				name = "resizable",
				defaultValue = true
			};

			// Token: 0x040003DF RID: 991
			private readonly UxmlBoolAttributeDescription m_ResizePreview = new UxmlBoolAttributeDescription
			{
				name = "resize-preview"
			};

			// Token: 0x040003E0 RID: 992
			private readonly UxmlObjectListAttributeDescription<Column> m_Columns = new UxmlObjectListAttributeDescription<Column>();
		}
	}
}
