using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine.Pool;

namespace UnityEngine.UIElements.Internal
{
	// Token: 0x020004C9 RID: 1225
	internal class MultiColumnCollectionHeader : VisualElement, IDisposable
	{
		// Token: 0x170008A8 RID: 2216
		// (get) Token: 0x06002659 RID: 9817 RVA: 0x000A0936 File Offset: 0x0009EB36
		internal bool isApplyingViewState
		{
			get
			{
				return this.m_ApplyingViewState;
			}
		}

		// Token: 0x170008A9 RID: 2217
		// (get) Token: 0x0600265A RID: 9818 RVA: 0x000A093E File Offset: 0x0009EB3E
		public Dictionary<Column, MultiColumnCollectionHeader.ColumnData> columnDataMap { get; } = new Dictionary<Column, MultiColumnCollectionHeader.ColumnData>();

		// Token: 0x170008AA RID: 2218
		// (get) Token: 0x0600265B RID: 9819 RVA: 0x000A0946 File Offset: 0x0009EB46
		public ColumnLayout columnLayout { get; }

		// Token: 0x170008AB RID: 2219
		// (get) Token: 0x0600265C RID: 9820 RVA: 0x000A094E File Offset: 0x0009EB4E
		public VisualElement columnContainer { get; }

		// Token: 0x170008AC RID: 2220
		// (get) Token: 0x0600265D RID: 9821 RVA: 0x000A0956 File Offset: 0x0009EB56
		public VisualElement resizeHandleContainer { get; }

		// Token: 0x170008AD RID: 2221
		// (get) Token: 0x0600265E RID: 9822 RVA: 0x000A095E File Offset: 0x0009EB5E
		public IEnumerable<SortColumnDescription> sortedColumns
		{
			get
			{
				return this.m_SortedColumns;
			}
		}

		// Token: 0x170008AE RID: 2222
		// (get) Token: 0x0600265F RID: 9823 RVA: 0x000A0966 File Offset: 0x0009EB66
		// (set) Token: 0x06002660 RID: 9824 RVA: 0x000A096E File Offset: 0x0009EB6E
		public SortColumnDescriptions sortDescriptions
		{
			get
			{
				return this.m_SortDescriptions;
			}
			protected internal set
			{
				this.m_SortDescriptions = value;
				this.m_SortDescriptions.changed += this.UpdateSortedColumns;
				this.UpdateSortedColumns();
			}
		}

		// Token: 0x170008AF RID: 2223
		// (get) Token: 0x06002661 RID: 9825 RVA: 0x000A0997 File Offset: 0x0009EB97
		public Columns columns { get; }

		// Token: 0x170008B0 RID: 2224
		// (get) Token: 0x06002662 RID: 9826 RVA: 0x000A099F File Offset: 0x0009EB9F
		// (set) Token: 0x06002663 RID: 9827 RVA: 0x000A09A8 File Offset: 0x0009EBA8
		public bool sortingEnabled
		{
			get
			{
				return this.m_SortingEnabled;
			}
			set
			{
				bool flag = this.m_SortingEnabled == value;
				if (!flag)
				{
					this.m_SortingEnabled = value;
					this.UpdateSortingStatus();
					this.UpdateSortedColumns();
				}
			}
		}

		// Token: 0x1400004B RID: 75
		// (add) Token: 0x06002664 RID: 9828 RVA: 0x000A09DC File Offset: 0x0009EBDC
		// (remove) Token: 0x06002665 RID: 9829 RVA: 0x000A0A14 File Offset: 0x0009EC14
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event Action<int, float> columnResized;

		// Token: 0x1400004C RID: 76
		// (add) Token: 0x06002666 RID: 9830 RVA: 0x000A0A4C File Offset: 0x0009EC4C
		// (remove) Token: 0x06002667 RID: 9831 RVA: 0x000A0A84 File Offset: 0x0009EC84
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event Action columnSortingChanged;

		// Token: 0x1400004D RID: 77
		// (add) Token: 0x06002668 RID: 9832 RVA: 0x000A0ABC File Offset: 0x0009ECBC
		// (remove) Token: 0x06002669 RID: 9833 RVA: 0x000A0AF4 File Offset: 0x0009ECF4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event Action<ContextualMenuPopulateEvent, Column> contextMenuPopulateEvent;

		// Token: 0x1400004E RID: 78
		// (add) Token: 0x0600266A RID: 9834 RVA: 0x000A0B2C File Offset: 0x0009ED2C
		// (remove) Token: 0x0600266B RID: 9835 RVA: 0x000A0B64 File Offset: 0x0009ED64
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal event Action viewDataRestored;

		// Token: 0x0600266C RID: 9836 RVA: 0x000A0B99 File Offset: 0x0009ED99
		public MultiColumnCollectionHeader() : this(new Columns(), new SortColumnDescriptions(), new List<SortColumnDescription>())
		{
		}

		// Token: 0x0600266D RID: 9837 RVA: 0x000A0BB4 File Offset: 0x0009EDB4
		public MultiColumnCollectionHeader(Columns columns, SortColumnDescriptions sortDescriptions, List<SortColumnDescription> sortedColumns)
		{
			base.AddToClassList(MultiColumnCollectionHeader.ussClassName);
			this.columns = columns;
			this.m_SortedColumns = sortedColumns;
			this.sortDescriptions = sortDescriptions;
			this.columnContainer = new VisualElement
			{
				pickingMode = PickingMode.Ignore
			};
			this.columnContainer.AddToClassList(MultiColumnCollectionHeader.columnContainerUssClassName);
			base.Add(this.columnContainer);
			this.resizeHandleContainer = new VisualElement
			{
				pickingMode = PickingMode.Ignore
			};
			this.resizeHandleContainer.AddToClassList(MultiColumnCollectionHeader.handleContainerUssClassName);
			this.resizeHandleContainer.StretchToParentSize();
			base.Add(this.resizeHandleContainer);
			this.columnLayout = new ColumnLayout(columns);
			this.columnLayout.layoutRequested += this.ScheduleDoLayout;
			foreach (Column column in columns.visibleList)
			{
				this.OnColumnAdded(column);
			}
			this.columns.columnAdded += this.OnColumnAdded;
			this.columns.columnRemoved += this.OnColumnRemoved;
			this.columns.columnChanged += this.OnColumnChanged;
			this.columns.columnReordered += this.OnColumnReordered;
			this.columns.columnResized += this.OnColumnResized;
			this.AddManipulator(new ContextualMenuManipulator(new Action<ContextualMenuPopulateEvent>(this.OnContextualMenuManipulator)));
			base.RegisterCallback<GeometryChangedEvent>(new EventCallback<GeometryChangedEvent>(this.OnGeometryChanged), TrickleDown.NoTrickleDown);
		}

		// Token: 0x0600266E RID: 9838 RVA: 0x000A0D7C File Offset: 0x0009EF7C
		private void ScheduleDoLayout()
		{
			bool doLayoutScheduled = this.m_DoLayoutScheduled;
			if (!doLayoutScheduled)
			{
				base.schedule.Execute(new Action(this.DoLayout));
				this.m_DoLayoutScheduled = true;
			}
		}

		// Token: 0x0600266F RID: 9839 RVA: 0x000A0DB8 File Offset: 0x0009EFB8
		private void ResizeToFit()
		{
			this.columnLayout.ResizeToFit(base.layout.width);
		}

		// Token: 0x06002670 RID: 9840 RVA: 0x000A0DE0 File Offset: 0x0009EFE0
		private void UpdateSortedColumns()
		{
			bool sortingUpdatesTemporarilyDisabled = this.m_SortingUpdatesTemporarilyDisabled;
			if (!sortingUpdatesTemporarilyDisabled)
			{
				List<MultiColumnCollectionHeader.SortedColumnState> list;
				using (CollectionPool<List<MultiColumnCollectionHeader.SortedColumnState>, MultiColumnCollectionHeader.SortedColumnState>.Get(out list))
				{
					bool sortingEnabled = this.sortingEnabled;
					if (sortingEnabled)
					{
						foreach (SortColumnDescription sortColumnDescription in this.sortDescriptions)
						{
							Column column = null;
							bool flag = sortColumnDescription.columnIndex != -1;
							if (flag)
							{
								column = this.columns[sortColumnDescription.columnIndex];
							}
							else
							{
								bool flag2 = !string.IsNullOrEmpty(sortColumnDescription.columnName);
								if (flag2)
								{
									column = this.columns[sortColumnDescription.columnName];
								}
							}
							bool flag3 = column != null && column.sortable;
							if (flag3)
							{
								sortColumnDescription.column = column;
								list.Add(new MultiColumnCollectionHeader.SortedColumnState(sortColumnDescription, sortColumnDescription.direction));
							}
							else
							{
								sortColumnDescription.column = null;
							}
						}
					}
					bool flag4 = this.m_OldSortedColumnStates.SequenceEqual(list);
					if (flag4)
					{
						return;
					}
					this.m_SortedColumns.Clear();
					foreach (MultiColumnCollectionHeader.SortedColumnState sortedColumnState in list)
					{
						this.m_SortedColumns.Add(sortedColumnState.columnDesc);
					}
					this.m_OldSortedColumnStates.CopyFrom(list);
				}
				this.SaveViewState();
				this.RaiseColumnSortingChanged();
			}
		}

		// Token: 0x06002671 RID: 9841 RVA: 0x000A0FC4 File Offset: 0x0009F1C4
		private void UpdateColumnControls()
		{
			bool flag = false;
			Column key = null;
			foreach (Column column in this.columns.visibleList)
			{
				flag |= column.stretchable;
				MultiColumnCollectionHeader.ColumnData columnData = null;
				bool flag2 = this.columnDataMap.TryGetValue(column, out columnData);
				if (flag2)
				{
					columnData.control.style.minWidth = column.minWidth;
					columnData.control.style.maxWidth = column.maxWidth;
					columnData.resizeHandle.style.display = ((this.columns.resizable && column.resizable) ? DisplayStyle.Flex : DisplayStyle.None);
				}
				key = column;
			}
			bool flag3 = flag;
			if (flag3)
			{
				this.columnContainer.style.flexGrow = 1f;
				MultiColumnCollectionHeader.ColumnData columnData2;
				bool flag4 = this.columns.stretchMode == Columns.StretchMode.GrowAndFill && this.columnDataMap.TryGetValue(key, out columnData2);
				if (flag4)
				{
					columnData2.resizeHandle.style.display = DisplayStyle.None;
				}
			}
			else
			{
				this.columnContainer.style.flexGrow = 0f;
			}
			this.UpdateSortingStatus();
		}

		// Token: 0x06002672 RID: 9842 RVA: 0x000A1138 File Offset: 0x0009F338
		private void OnColumnAdded(Column column, int index)
		{
			this.OnColumnAdded(column);
		}

		// Token: 0x06002673 RID: 9843 RVA: 0x000A1144 File Offset: 0x0009F344
		private void OnColumnAdded(Column column)
		{
			bool flag = this.columnDataMap.ContainsKey(column);
			if (!flag)
			{
				MultiColumnHeaderColumn multiColumnHeaderColumn = new MultiColumnHeaderColumn(column);
				MultiColumnHeaderColumnResizeHandle multiColumnHeaderColumnResizeHandle = new MultiColumnHeaderColumnResizeHandle();
				multiColumnHeaderColumn.RegisterCallback<GeometryChangedEvent>(new EventCallback<GeometryChangedEvent>(this.OnColumnControlGeometryChanged), TrickleDown.NoTrickleDown);
				multiColumnHeaderColumn.clickable.clickedWithEventInfo += this.OnColumnClicked;
				multiColumnHeaderColumn.mover.activeChanged += this.OnMoveManipulatorActivated;
				multiColumnHeaderColumnResizeHandle.dragArea.AddManipulator(new ColumnResizer(column));
				this.columnDataMap[column] = new MultiColumnCollectionHeader.ColumnData
				{
					control = multiColumnHeaderColumn,
					resizeHandle = multiColumnHeaderColumnResizeHandle
				};
				bool visible = column.visible;
				if (visible)
				{
					this.columnContainer.Insert(column.visibleIndex, multiColumnHeaderColumn);
					this.resizeHandleContainer.Insert(column.visibleIndex, multiColumnHeaderColumnResizeHandle);
				}
				else
				{
					this.OnColumnRemoved(column);
				}
				this.UpdateColumnControls();
				this.SaveViewState();
			}
		}

		// Token: 0x06002674 RID: 9844 RVA: 0x000A1238 File Offset: 0x0009F438
		private void OnColumnRemoved(Column column)
		{
			MultiColumnCollectionHeader.ColumnData data;
			bool flag = !this.columnDataMap.TryGetValue(column, out data);
			if (!flag)
			{
				this.CleanupColumnData(data);
				this.columnDataMap.Remove(column);
				this.UpdateColumnControls();
				this.SaveViewState();
			}
		}

		// Token: 0x06002675 RID: 9845 RVA: 0x000A1280 File Offset: 0x0009F480
		private void OnColumnChanged(Column column, ColumnDataType type)
		{
			bool flag = type == ColumnDataType.Visibility;
			if (flag)
			{
				bool visible = column.visible;
				if (visible)
				{
					this.OnColumnAdded(column);
				}
				else
				{
					this.OnColumnRemoved(column);
				}
				this.ApplyColumnSorting();
			}
			this.UpdateColumnControls();
			bool flag2 = type == ColumnDataType.Visibility;
			if (flag2)
			{
				this.SaveViewState();
			}
		}

		// Token: 0x06002676 RID: 9846 RVA: 0x000A12D4 File Offset: 0x0009F4D4
		private void OnColumnReordered(Column column, int from, int to)
		{
			bool flag = !column.visible || from == to;
			if (!flag)
			{
				MultiColumnCollectionHeader.ColumnData columnData;
				bool flag2 = this.columnDataMap.TryGetValue(column, out columnData);
				if (flag2)
				{
					int num = column.visibleIndex;
					bool flag3 = num == this.columns.visibleList.Count<Column>() - 1;
					if (flag3)
					{
						columnData.control.BringToFront();
					}
					else
					{
						bool flag4 = to > from;
						if (flag4)
						{
							num++;
						}
						columnData.control.PlaceBehind(this.columnContainer[num]);
						columnData.resizeHandle.PlaceBehind(this.resizeHandleContainer[num]);
					}
				}
				this.UpdateColumnControls();
				this.SaveViewState();
			}
		}

		// Token: 0x06002677 RID: 9847 RVA: 0x000A138E File Offset: 0x0009F58E
		private void OnColumnResized(Column column)
		{
			this.SaveViewState();
		}

		// Token: 0x06002678 RID: 9848 RVA: 0x000A1398 File Offset: 0x0009F598
		private void OnContextualMenuManipulator(ContextualMenuPopulateEvent evt)
		{
			Column column3 = null;
			bool flag = this.columns.visibleList.Count<Column>() > 0;
			foreach (Column column2 in this.columns.visibleList)
			{
				bool flag2 = this.columns.stretchMode == Columns.StretchMode.GrowAndFill && flag && column2.stretchable;
				if (flag2)
				{
					flag = false;
				}
				bool flag3 = column3 == null;
				if (flag3)
				{
					MultiColumnCollectionHeader.ColumnData columnData;
					bool flag4 = this.columnDataMap.TryGetValue(column2, out columnData);
					if (flag4)
					{
						bool flag5 = columnData.control.layout.Contains(evt.localMousePosition);
						if (flag5)
						{
							column3 = column2;
						}
					}
				}
			}
			evt.menu.AppendAction("Resize To Fit", delegate(DropdownMenuAction a)
			{
				this.ResizeToFit();
			}, flag ? DropdownMenuAction.Status.Normal : DropdownMenuAction.Status.Disabled);
			evt.menu.AppendSeparator(null);
			using (IEnumerator<Column> enumerator2 = this.columns.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					Column column = enumerator2.Current;
					string text = column.title;
					bool flag6 = string.IsNullOrEmpty(text);
					if (flag6)
					{
						text = column.name;
					}
					bool flag7 = string.IsNullOrEmpty(text);
					if (flag7)
					{
						text = "Unnamed Column_" + column.index.ToString();
					}
					evt.menu.AppendAction(text, delegate(DropdownMenuAction a)
					{
						column.visible = !column.visible;
					}, delegate(DropdownMenuAction a)
					{
						bool flag8 = !string.IsNullOrEmpty(column.name) && this.columns.primaryColumnName == column.name;
						DropdownMenuAction.Status result;
						if (flag8)
						{
							result = DropdownMenuAction.Status.Disabled;
						}
						else
						{
							bool flag9 = !column.optional;
							if (flag9)
							{
								result = DropdownMenuAction.Status.Disabled;
							}
							else
							{
								bool visible = column.visible;
								if (visible)
								{
									result = DropdownMenuAction.Status.Checked;
								}
								else
								{
									result = DropdownMenuAction.Status.Normal;
								}
							}
						}
						return result;
					}, null);
				}
			}
			Action<ContextualMenuPopulateEvent, Column> action = this.contextMenuPopulateEvent;
			if (action != null)
			{
				action(evt, column3);
			}
		}

		// Token: 0x06002679 RID: 9849 RVA: 0x000A1588 File Offset: 0x0009F788
		private void OnMoveManipulatorActivated(ColumnMover mover)
		{
			this.resizeHandleContainer.style.display = (mover.active ? DisplayStyle.None : DisplayStyle.Flex);
		}

		// Token: 0x0600267A RID: 9850 RVA: 0x000A15B0 File Offset: 0x0009F7B0
		private void OnGeometryChanged(GeometryChangedEvent e)
		{
			bool flag = float.IsNaN(e.newRect.width) || float.IsNaN(e.newRect.height);
			if (!flag)
			{
				this.columnLayout.Dirty();
				bool flag2 = e.layoutPass > 2;
				if (flag2)
				{
					this.ScheduleDoLayout();
				}
				else
				{
					this.DoLayout();
				}
			}
		}

		// Token: 0x0600267B RID: 9851 RVA: 0x000A161C File Offset: 0x0009F81C
		private void DoLayout()
		{
			this.columnLayout.DoLayout(base.layout.width);
			this.m_DoLayoutScheduled = false;
		}

		// Token: 0x0600267C RID: 9852 RVA: 0x000A164C File Offset: 0x0009F84C
		private void OnColumnControlGeometryChanged(GeometryChangedEvent evt)
		{
			MultiColumnHeaderColumn multiColumnHeaderColumn = evt.target as MultiColumnHeaderColumn;
			bool flag = multiColumnHeaderColumn == null;
			if (!flag)
			{
				MultiColumnCollectionHeader.ColumnData columnData = this.columnDataMap[multiColumnHeaderColumn.column];
				columnData.resizeHandle.style.left = multiColumnHeaderColumn.layout.xMax;
				bool flag2 = Math.Abs(evt.newRect.width - evt.oldRect.width) < float.Epsilon;
				if (!flag2)
				{
					this.RaiseColumnResized(this.columnContainer.IndexOf(evt.target as VisualElement));
				}
			}
		}

		// Token: 0x0600267D RID: 9853 RVA: 0x000A16FC File Offset: 0x0009F8FC
		private void OnColumnClicked(EventBase evt)
		{
			bool flag = !this.sortingEnabled;
			if (!flag)
			{
				MultiColumnHeaderColumn multiColumnHeaderColumn = evt.currentTarget as MultiColumnHeaderColumn;
				bool flag2 = multiColumnHeaderColumn == null || !multiColumnHeaderColumn.column.sortable;
				if (!flag2)
				{
					IPointerEvent pointerEvent = evt as IPointerEvent;
					bool flag3 = pointerEvent != null;
					EventModifiers modifiers;
					if (flag3)
					{
						modifiers = pointerEvent.modifiers;
					}
					else
					{
						IMouseEvent mouseEvent = evt as IMouseEvent;
						bool flag4 = mouseEvent != null;
						if (!flag4)
						{
							return;
						}
						modifiers = mouseEvent.modifiers;
					}
					this.m_SortingUpdatesTemporarilyDisabled = true;
					try
					{
						this.UpdateSortColumnDescriptionsOnClick(multiColumnHeaderColumn.column, modifiers);
					}
					finally
					{
						this.m_SortingUpdatesTemporarilyDisabled = false;
					}
					this.UpdateSortedColumns();
				}
			}
		}

		// Token: 0x0600267E RID: 9854 RVA: 0x000A17B8 File Offset: 0x0009F9B8
		private void UpdateSortColumnDescriptionsOnClick(Column column, EventModifiers modifiers)
		{
			SortColumnDescription sortColumnDescription = this.sortDescriptions.FirstOrDefault((SortColumnDescription d) => d.column == column || (!string.IsNullOrEmpty(column.name) && d.columnName == column.name) || d.columnIndex == column.index);
			bool flag = sortColumnDescription != null;
			if (flag)
			{
				bool flag2 = modifiers == EventModifiers.Shift;
				if (flag2)
				{
					this.sortDescriptions.Remove(sortColumnDescription);
					return;
				}
				sortColumnDescription.direction = ((sortColumnDescription.direction == SortDirection.Ascending) ? SortDirection.Descending : SortDirection.Ascending);
			}
			else
			{
				sortColumnDescription = (string.IsNullOrEmpty(column.name) ? new SortColumnDescription(column.index, SortDirection.Ascending) : new SortColumnDescription(column.name, SortDirection.Ascending));
			}
			EventModifiers eventModifiers = EventModifiers.Control;
			RuntimePlatform platform = Application.platform;
			bool flag3 = platform == RuntimePlatform.OSXEditor || platform == RuntimePlatform.OSXPlayer;
			if (flag3)
			{
				eventModifiers = EventModifiers.Command;
			}
			bool flag4 = modifiers != eventModifiers;
			if (flag4)
			{
				this.sortDescriptions.Clear();
			}
			bool flag5 = !this.sortDescriptions.Contains(sortColumnDescription);
			if (flag5)
			{
				this.sortDescriptions.Add(sortColumnDescription);
			}
		}

		// Token: 0x0600267F RID: 9855 RVA: 0x000A18C4 File Offset: 0x0009FAC4
		public void ScrollHorizontally(float horizontalOffset)
		{
			base.transform.position = new Vector3(-horizontalOffset, base.transform.position.y, base.transform.position.z);
		}

		// Token: 0x06002680 RID: 9856 RVA: 0x000A18FA File Offset: 0x0009FAFA
		private void RaiseColumnResized(int columnIndex)
		{
			Action<int, float> action = this.columnResized;
			if (action != null)
			{
				action(columnIndex, this.columnContainer[columnIndex].resolvedStyle.width);
			}
		}

		// Token: 0x06002681 RID: 9857 RVA: 0x000A1928 File Offset: 0x0009FB28
		private void RaiseColumnSortingChanged()
		{
			this.ApplyColumnSorting();
			bool flag = !this.m_ApplyingViewState;
			if (flag)
			{
				Action action = this.columnSortingChanged;
				if (action != null)
				{
					action();
				}
			}
		}

		// Token: 0x06002682 RID: 9858 RVA: 0x000A195C File Offset: 0x0009FB5C
		private void ApplyColumnSorting()
		{
			foreach (Column key in this.columns.visibleList)
			{
				MultiColumnCollectionHeader.ColumnData columnData;
				bool flag = !this.columnDataMap.TryGetValue(key, out columnData);
				if (!flag)
				{
					columnData.control.sortOrderLabel = "";
					columnData.control.RemoveFromClassList(MultiColumnHeaderColumn.sortedAscendingUssClassName);
					columnData.control.RemoveFromClassList(MultiColumnHeaderColumn.sortedDescendingUssClassName);
				}
			}
			List<MultiColumnCollectionHeader.ColumnData> list = new List<MultiColumnCollectionHeader.ColumnData>();
			foreach (SortColumnDescription sortColumnDescription in this.sortedColumns)
			{
				MultiColumnCollectionHeader.ColumnData columnData2;
				bool flag2 = this.columnDataMap.TryGetValue(sortColumnDescription.column, out columnData2);
				if (flag2)
				{
					list.Add(columnData2);
					bool flag3 = sortColumnDescription.direction == SortDirection.Ascending;
					if (flag3)
					{
						columnData2.control.AddToClassList(MultiColumnHeaderColumn.sortedAscendingUssClassName);
					}
					else
					{
						columnData2.control.AddToClassList(MultiColumnHeaderColumn.sortedDescendingUssClassName);
					}
				}
			}
			bool flag4 = list.Count > 1;
			if (flag4)
			{
				for (int i = 0; i < list.Count; i++)
				{
					list[i].control.sortOrderLabel = (i + 1).ToString();
				}
			}
		}

		// Token: 0x06002683 RID: 9859 RVA: 0x000A1AE8 File Offset: 0x0009FCE8
		private void UpdateSortingStatus()
		{
			bool flag = false;
			foreach (Column column in this.columns.visibleList)
			{
				MultiColumnCollectionHeader.ColumnData columnData;
				bool flag2 = !this.columnDataMap.TryGetValue(column, out columnData);
				if (!flag2)
				{
					bool flag3 = this.sortingEnabled && column.sortable;
					if (flag3)
					{
						flag = true;
					}
				}
			}
			foreach (Column key in this.columns.visibleList)
			{
				MultiColumnCollectionHeader.ColumnData columnData2;
				bool flag4 = !this.columnDataMap.TryGetValue(key, out columnData2);
				if (!flag4)
				{
					bool flag5 = flag;
					if (flag5)
					{
						columnData2.control.AddToClassList(MultiColumnHeaderColumn.sortableUssClassName);
					}
					else
					{
						columnData2.control.RemoveFromClassList(MultiColumnHeaderColumn.sortableUssClassName);
					}
				}
			}
		}

		// Token: 0x06002684 RID: 9860 RVA: 0x000A1C00 File Offset: 0x0009FE00
		internal override void OnViewDataReady()
		{
			try
			{
				this.m_ApplyingViewState = true;
				base.OnViewDataReady();
				string fullHierarchicalViewDataKey = base.GetFullHierarchicalViewDataKey();
				this.m_ViewState = base.GetOrCreateViewData<MultiColumnCollectionHeader.ViewState>(this.m_ViewState, fullHierarchicalViewDataKey);
				this.m_ViewState.Apply(this);
				Action action = this.viewDataRestored;
				if (action != null)
				{
					action();
				}
			}
			finally
			{
				this.m_ApplyingViewState = false;
			}
		}

		// Token: 0x06002685 RID: 9861 RVA: 0x000A1C74 File Offset: 0x0009FE74
		private void SaveViewState()
		{
			bool applyingViewState = this.m_ApplyingViewState;
			if (!applyingViewState)
			{
				MultiColumnCollectionHeader.ViewState viewState = this.m_ViewState;
				if (viewState != null)
				{
					viewState.Save(this);
				}
				base.SaveViewData();
			}
		}

		// Token: 0x06002686 RID: 9862 RVA: 0x000A1CA8 File Offset: 0x0009FEA8
		private void CleanupColumnData(MultiColumnCollectionHeader.ColumnData data)
		{
			data.control.UnregisterCallback<GeometryChangedEvent>(new EventCallback<GeometryChangedEvent>(this.OnColumnControlGeometryChanged), TrickleDown.NoTrickleDown);
			data.control.clickable.clickedWithEventInfo -= this.OnColumnClicked;
			data.control.mover.activeChanged -= this.OnMoveManipulatorActivated;
			data.control.RemoveFromHierarchy();
			data.control.Dispose();
			data.resizeHandle.RemoveFromHierarchy();
		}

		// Token: 0x06002687 RID: 9863 RVA: 0x000A1D30 File Offset: 0x0009FF30
		public void Dispose()
		{
			this.sortDescriptions.changed -= this.UpdateSortedColumns;
			this.columnLayout.layoutRequested -= this.ScheduleDoLayout;
			this.columns.columnAdded -= this.OnColumnAdded;
			this.columns.columnRemoved -= this.OnColumnRemoved;
			this.columns.columnChanged -= this.OnColumnChanged;
			this.columns.columnReordered -= this.OnColumnReordered;
			this.columns.columnResized -= this.OnColumnResized;
			foreach (MultiColumnCollectionHeader.ColumnData data in this.columnDataMap.Values)
			{
				this.CleanupColumnData(data);
			}
			this.columnDataMap.Clear();
		}

		// Token: 0x0400126C RID: 4716
		private const int kMaxStableLayoutPassCount = 2;

		// Token: 0x0400126D RID: 4717
		public static readonly string ussClassName = "unity-multi-column-header";

		// Token: 0x0400126E RID: 4718
		public static readonly string columnContainerUssClassName = MultiColumnCollectionHeader.ussClassName + "__column-container";

		// Token: 0x0400126F RID: 4719
		public static readonly string handleContainerUssClassName = MultiColumnCollectionHeader.ussClassName + "__resize-handle-container";

		// Token: 0x04001270 RID: 4720
		public static readonly string reorderableUssClassName = MultiColumnCollectionHeader.ussClassName + "__header";

		// Token: 0x04001271 RID: 4721
		private bool m_SortingEnabled;

		// Token: 0x04001272 RID: 4722
		private List<SortColumnDescription> m_SortedColumns;

		// Token: 0x04001273 RID: 4723
		private SortColumnDescriptions m_SortDescriptions;

		// Token: 0x04001274 RID: 4724
		private List<MultiColumnCollectionHeader.SortedColumnState> m_OldSortedColumnStates = new List<MultiColumnCollectionHeader.SortedColumnState>();

		// Token: 0x04001275 RID: 4725
		private bool m_SortingUpdatesTemporarilyDisabled;

		// Token: 0x04001276 RID: 4726
		private MultiColumnCollectionHeader.ViewState m_ViewState;

		// Token: 0x04001277 RID: 4727
		private bool m_ApplyingViewState;

		// Token: 0x04001278 RID: 4728
		private bool m_DoLayoutScheduled;

		// Token: 0x020004CA RID: 1226
		[Serializable]
		private class ViewState
		{
			// Token: 0x0600268A RID: 9866 RVA: 0x000A1EA0 File Offset: 0x000A00A0
			internal void Save(MultiColumnCollectionHeader header)
			{
				this.m_SortDescriptions.Clear();
				this.m_OrderedColumnStates.Clear();
				foreach (SortColumnDescription item in header.sortDescriptions)
				{
					this.m_SortDescriptions.Add(item);
				}
				foreach (Column column in header.columns.displayList)
				{
					MultiColumnCollectionHeader.ViewState.ColumnState item2 = new MultiColumnCollectionHeader.ViewState.ColumnState
					{
						index = column.index,
						name = column.name,
						actualWidth = column.desiredWidth,
						width = column.width,
						visible = column.visible
					};
					this.m_OrderedColumnStates.Add(item2);
				}
				this.m_HasPersistedData = true;
			}

			// Token: 0x0600268B RID: 9867 RVA: 0x000A1FB0 File Offset: 0x000A01B0
			internal void Apply(MultiColumnCollectionHeader header)
			{
				bool flag = !this.m_HasPersistedData;
				if (!flag)
				{
					int num = Math.Min(this.m_OrderedColumnStates.Count, header.columns.Count);
					int num2 = 0;
					int num3 = 0;
					while (num3 < this.m_OrderedColumnStates.Count && num2 < num)
					{
						MultiColumnCollectionHeader.ViewState.ColumnState columnState = this.m_OrderedColumnStates[num3];
						Column column = null;
						bool flag2 = !string.IsNullOrEmpty(columnState.name);
						if (flag2)
						{
							bool flag3 = header.columns.Contains(columnState.name);
							if (flag3)
							{
								column = header.columns[columnState.name];
							}
							goto IL_E2;
						}
						bool flag4 = columnState.index > header.columns.Count - 1;
						if (!flag4)
						{
							column = header.columns[columnState.index];
							bool flag5 = !string.IsNullOrEmpty(column.name);
							if (flag5)
							{
								column = null;
							}
							goto IL_E2;
						}
						IL_135:
						num3++;
						continue;
						IL_E2:
						bool flag6 = column == null;
						if (flag6)
						{
							goto IL_135;
						}
						header.columns.ReorderDisplay(column.displayIndex, num2++);
						column.visible = columnState.visible;
						column.width = columnState.width;
						column.desiredWidth = columnState.actualWidth;
						goto IL_135;
					}
					header.sortDescriptions.Clear();
					foreach (SortColumnDescription item in this.m_SortDescriptions)
					{
						header.sortDescriptions.Add(item);
					}
				}
			}

			// Token: 0x04001282 RID: 4738
			[SerializeField]
			private bool m_HasPersistedData;

			// Token: 0x04001283 RID: 4739
			[SerializeField]
			private List<SortColumnDescription> m_SortDescriptions = new List<SortColumnDescription>();

			// Token: 0x04001284 RID: 4740
			[SerializeField]
			private List<MultiColumnCollectionHeader.ViewState.ColumnState> m_OrderedColumnStates = new List<MultiColumnCollectionHeader.ViewState.ColumnState>();

			// Token: 0x020004CB RID: 1227
			[Serializable]
			private struct ColumnState
			{
				// Token: 0x04001285 RID: 4741
				public int index;

				// Token: 0x04001286 RID: 4742
				public string name;

				// Token: 0x04001287 RID: 4743
				public float actualWidth;

				// Token: 0x04001288 RID: 4744
				public Length width;

				// Token: 0x04001289 RID: 4745
				public bool visible;
			}
		}

		// Token: 0x020004CC RID: 1228
		internal class ColumnData
		{
			// Token: 0x170008B1 RID: 2225
			// (get) Token: 0x0600268D RID: 9869 RVA: 0x000A2193 File Offset: 0x000A0393
			// (set) Token: 0x0600268E RID: 9870 RVA: 0x000A219B File Offset: 0x000A039B
			public MultiColumnHeaderColumn control { get; set; }

			// Token: 0x170008B2 RID: 2226
			// (get) Token: 0x0600268F RID: 9871 RVA: 0x000A21A4 File Offset: 0x000A03A4
			// (set) Token: 0x06002690 RID: 9872 RVA: 0x000A21AC File Offset: 0x000A03AC
			public MultiColumnHeaderColumnResizeHandle resizeHandle { get; set; }
		}

		// Token: 0x020004CD RID: 1229
		private struct SortedColumnState
		{
			// Token: 0x06002692 RID: 9874 RVA: 0x000A21B5 File Offset: 0x000A03B5
			public SortedColumnState(SortColumnDescription desc, SortDirection dir)
			{
				this.columnDesc = desc;
				this.direction = dir;
			}

			// Token: 0x0400128C RID: 4748
			public SortColumnDescription columnDesc;

			// Token: 0x0400128D RID: 4749
			public SortDirection direction;
		}
	}
}
