using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace UnityEngine.Rendering
{
	// Token: 0x02000068 RID: 104
	public class DebugUI
	{
		// Token: 0x0200016D RID: 365
		public class Container : DebugUI.Widget, DebugUI.IContainer
		{
			// Token: 0x1700014E RID: 334
			// (get) Token: 0x06000A08 RID: 2568 RVA: 0x0002CB46 File Offset: 0x0002AD46
			internal bool hideDisplayName
			{
				get
				{
					return string.IsNullOrEmpty(base.displayName) || base.displayName.StartsWith("#");
				}
			}

			// Token: 0x1700014F RID: 335
			// (get) Token: 0x06000A09 RID: 2569 RVA: 0x0002CB67 File Offset: 0x0002AD67
			// (set) Token: 0x06000A0A RID: 2570 RVA: 0x0002CB6F File Offset: 0x0002AD6F
			public ObservableList<DebugUI.Widget> children { get; private set; }

			// Token: 0x17000150 RID: 336
			// (get) Token: 0x06000A0B RID: 2571 RVA: 0x0002CB78 File Offset: 0x0002AD78
			// (set) Token: 0x06000A0C RID: 2572 RVA: 0x0002CB80 File Offset: 0x0002AD80
			public override DebugUI.Panel panel
			{
				get
				{
					return this.m_Panel;
				}
				internal set
				{
					if (value != null && value.flags.HasFlag(DebugUI.Flags.FrequentlyUsed))
					{
						return;
					}
					this.m_Panel = value;
					int count = this.children.Count;
					for (int i = 0; i < count; i++)
					{
						this.children[i].panel = value;
					}
				}
			}

			// Token: 0x06000A0D RID: 2573 RVA: 0x0002CBDB File Offset: 0x0002ADDB
			public Container() : this(string.Empty, new ObservableList<DebugUI.Widget>())
			{
			}

			// Token: 0x06000A0E RID: 2574 RVA: 0x0002CBED File Offset: 0x0002ADED
			public Container(string id) : this("#" + id, new ObservableList<DebugUI.Widget>())
			{
			}

			// Token: 0x06000A0F RID: 2575 RVA: 0x0002CC08 File Offset: 0x0002AE08
			public Container(string displayName, ObservableList<DebugUI.Widget> children)
			{
				base.displayName = displayName;
				this.children = children;
				children.ItemAdded += this.OnItemAdded;
				children.ItemRemoved += this.OnItemRemoved;
				for (int i = 0; i < this.children.Count; i++)
				{
					this.OnItemAdded(this.children, new ListChangedEventArgs<DebugUI.Widget>(i, this.children[i]));
				}
			}

			// Token: 0x06000A10 RID: 2576 RVA: 0x0002CC84 File Offset: 0x0002AE84
			internal override void GenerateQueryPath()
			{
				base.GenerateQueryPath();
				int count = this.children.Count;
				for (int i = 0; i < count; i++)
				{
					this.children[i].GenerateQueryPath();
				}
			}

			// Token: 0x06000A11 RID: 2577 RVA: 0x0002CCC0 File Offset: 0x0002AEC0
			protected virtual void OnItemAdded(ObservableList<DebugUI.Widget> sender, ListChangedEventArgs<DebugUI.Widget> e)
			{
				if (e.item != null)
				{
					e.item.panel = this.m_Panel;
					e.item.parent = this;
				}
				if (this.m_Panel != null)
				{
					this.m_Panel.SetDirty();
				}
			}

			// Token: 0x06000A12 RID: 2578 RVA: 0x0002CCFA File Offset: 0x0002AEFA
			protected virtual void OnItemRemoved(ObservableList<DebugUI.Widget> sender, ListChangedEventArgs<DebugUI.Widget> e)
			{
				if (e.item != null)
				{
					e.item.panel = null;
					e.item.parent = null;
				}
				if (this.m_Panel != null)
				{
					this.m_Panel.SetDirty();
				}
			}

			// Token: 0x06000A13 RID: 2579 RVA: 0x0002CD30 File Offset: 0x0002AF30
			public override int GetHashCode()
			{
				int num = 17;
				num = num * 23 + base.queryPath.GetHashCode();
				num = num * 23 + base.isHidden.GetHashCode();
				int count = this.children.Count;
				for (int i = 0; i < count; i++)
				{
					num = num * 23 + this.children[i].GetHashCode();
				}
				return num;
			}

			// Token: 0x04000617 RID: 1559
			private const string k_IDToken = "#";
		}

		// Token: 0x0200016E RID: 366
		public class Foldout : DebugUI.Container, DebugUI.IValueField
		{
			// Token: 0x17000151 RID: 337
			// (get) Token: 0x06000A14 RID: 2580 RVA: 0x0002CD95 File Offset: 0x0002AF95
			public bool isReadOnly
			{
				get
				{
					return false;
				}
			}

			// Token: 0x17000152 RID: 338
			// (get) Token: 0x06000A15 RID: 2581 RVA: 0x0002CD98 File Offset: 0x0002AF98
			// (set) Token: 0x06000A16 RID: 2582 RVA: 0x0002CDA0 File Offset: 0x0002AFA0
			public string[] columnLabels { get; set; }

			// Token: 0x17000153 RID: 339
			// (get) Token: 0x06000A17 RID: 2583 RVA: 0x0002CDA9 File Offset: 0x0002AFA9
			// (set) Token: 0x06000A18 RID: 2584 RVA: 0x0002CDB1 File Offset: 0x0002AFB1
			public string[] columnTooltips { get; set; }

			// Token: 0x06000A19 RID: 2585 RVA: 0x0002CDBA File Offset: 0x0002AFBA
			public Foldout()
			{
			}

			// Token: 0x06000A1A RID: 2586 RVA: 0x0002CDC2 File Offset: 0x0002AFC2
			public Foldout(string displayName, ObservableList<DebugUI.Widget> children, string[] columnLabels = null, string[] columnTooltips = null) : base(displayName, children)
			{
				this.columnLabels = columnLabels;
				this.columnTooltips = columnTooltips;
			}

			// Token: 0x06000A1B RID: 2587 RVA: 0x0002CDDB File Offset: 0x0002AFDB
			public bool GetValue()
			{
				return this.opened;
			}

			// Token: 0x06000A1C RID: 2588 RVA: 0x0002CDE3 File Offset: 0x0002AFE3
			object DebugUI.IValueField.GetValue()
			{
				return this.GetValue();
			}

			// Token: 0x06000A1D RID: 2589 RVA: 0x0002CDF0 File Offset: 0x0002AFF0
			public void SetValue(object value)
			{
				this.SetValue((bool)value);
			}

			// Token: 0x06000A1E RID: 2590 RVA: 0x0002CDFE File Offset: 0x0002AFFE
			public object ValidateValue(object value)
			{
				return value;
			}

			// Token: 0x06000A1F RID: 2591 RVA: 0x0002CE01 File Offset: 0x0002B001
			public void SetValue(bool value)
			{
				this.opened = value;
			}

			// Token: 0x04000619 RID: 1561
			public bool opened;

			// Token: 0x0400061A RID: 1562
			public bool isHeader;

			// Token: 0x0400061B RID: 1563
			public List<DebugUI.Foldout.ContextMenuItem> contextMenuItems;

			// Token: 0x020001F7 RID: 503
			public struct ContextMenuItem
			{
				// Token: 0x040007E4 RID: 2020
				public string displayName;

				// Token: 0x040007E5 RID: 2021
				public Action action;
			}
		}

		// Token: 0x0200016F RID: 367
		public class HBox : DebugUI.Container
		{
			// Token: 0x06000A20 RID: 2592 RVA: 0x0002CE0A File Offset: 0x0002B00A
			public HBox()
			{
				base.displayName = "HBox";
			}
		}

		// Token: 0x02000170 RID: 368
		public class VBox : DebugUI.Container
		{
			// Token: 0x06000A21 RID: 2593 RVA: 0x0002CE1D File Offset: 0x0002B01D
			public VBox()
			{
				base.displayName = "VBox";
			}
		}

		// Token: 0x02000171 RID: 369
		public class Table : DebugUI.Container
		{
			// Token: 0x06000A22 RID: 2594 RVA: 0x0002CE30 File Offset: 0x0002B030
			public Table()
			{
				base.displayName = "Array";
			}

			// Token: 0x06000A23 RID: 2595 RVA: 0x0002CE44 File Offset: 0x0002B044
			public void SetColumnVisibility(int index, bool visible)
			{
				bool[] visibleColumns = this.VisibleColumns;
				if (index < 0 || index > visibleColumns.Length)
				{
					return;
				}
				visibleColumns[index] = visible;
			}

			// Token: 0x06000A24 RID: 2596 RVA: 0x0002CE68 File Offset: 0x0002B068
			public bool GetColumnVisibility(int index)
			{
				bool[] visibleColumns = this.VisibleColumns;
				return index >= 0 && index <= visibleColumns.Length && visibleColumns[index];
			}

			// Token: 0x17000154 RID: 340
			// (get) Token: 0x06000A25 RID: 2597 RVA: 0x0002CE8C File Offset: 0x0002B08C
			public bool[] VisibleColumns
			{
				get
				{
					if (this.m_Header != null)
					{
						return this.m_Header;
					}
					int num = 0;
					if (base.children.Count != 0)
					{
						num = ((DebugUI.Container)base.children[0]).children.Count;
						for (int i = 1; i < base.children.Count; i++)
						{
							if (((DebugUI.Container)base.children[i]).children.Count != num)
							{
								Debug.LogError("All rows must have the same number of children.");
								return null;
							}
						}
					}
					this.m_Header = new bool[num];
					for (int j = 0; j < num; j++)
					{
						this.m_Header[j] = true;
					}
					return this.m_Header;
				}
			}

			// Token: 0x06000A26 RID: 2598 RVA: 0x0002CF3A File Offset: 0x0002B13A
			protected override void OnItemAdded(ObservableList<DebugUI.Widget> sender, ListChangedEventArgs<DebugUI.Widget> e)
			{
				base.OnItemAdded(sender, e);
				this.m_Header = null;
			}

			// Token: 0x06000A27 RID: 2599 RVA: 0x0002CF4B File Offset: 0x0002B14B
			protected override void OnItemRemoved(ObservableList<DebugUI.Widget> sender, ListChangedEventArgs<DebugUI.Widget> e)
			{
				base.OnItemRemoved(sender, e);
				this.m_Header = null;
			}

			// Token: 0x0400061E RID: 1566
			public bool isReadOnly;

			// Token: 0x0400061F RID: 1567
			private bool[] m_Header;

			// Token: 0x020001F8 RID: 504
			public class Row : DebugUI.Foldout
			{
				// Token: 0x06000BBD RID: 3005 RVA: 0x00030645 File Offset: 0x0002E845
				public Row()
				{
					base.displayName = "Row";
				}
			}
		}

		// Token: 0x02000172 RID: 370
		[Flags]
		public enum Flags
		{
			// Token: 0x04000621 RID: 1569
			None = 0,
			// Token: 0x04000622 RID: 1570
			EditorOnly = 2,
			// Token: 0x04000623 RID: 1571
			RuntimeOnly = 4,
			// Token: 0x04000624 RID: 1572
			EditorForceUpdate = 8,
			// Token: 0x04000625 RID: 1573
			FrequentlyUsed = 16
		}

		// Token: 0x02000173 RID: 371
		public abstract class Widget
		{
			// Token: 0x17000155 RID: 341
			// (get) Token: 0x06000A28 RID: 2600 RVA: 0x0002CF5C File Offset: 0x0002B15C
			// (set) Token: 0x06000A29 RID: 2601 RVA: 0x0002CF64 File Offset: 0x0002B164
			public virtual DebugUI.Panel panel
			{
				get
				{
					return this.m_Panel;
				}
				internal set
				{
					this.m_Panel = value;
				}
			}

			// Token: 0x17000156 RID: 342
			// (get) Token: 0x06000A2A RID: 2602 RVA: 0x0002CF6D File Offset: 0x0002B16D
			// (set) Token: 0x06000A2B RID: 2603 RVA: 0x0002CF75 File Offset: 0x0002B175
			public virtual DebugUI.IContainer parent
			{
				get
				{
					return this.m_Parent;
				}
				internal set
				{
					this.m_Parent = value;
				}
			}

			// Token: 0x17000157 RID: 343
			// (get) Token: 0x06000A2C RID: 2604 RVA: 0x0002CF7E File Offset: 0x0002B17E
			// (set) Token: 0x06000A2D RID: 2605 RVA: 0x0002CF86 File Offset: 0x0002B186
			public DebugUI.Flags flags { get; set; }

			// Token: 0x17000158 RID: 344
			// (get) Token: 0x06000A2E RID: 2606 RVA: 0x0002CF8F File Offset: 0x0002B18F
			// (set) Token: 0x06000A2F RID: 2607 RVA: 0x0002CF97 File Offset: 0x0002B197
			public string displayName { get; set; }

			// Token: 0x17000159 RID: 345
			// (get) Token: 0x06000A30 RID: 2608 RVA: 0x0002CFA0 File Offset: 0x0002B1A0
			// (set) Token: 0x06000A31 RID: 2609 RVA: 0x0002CFA8 File Offset: 0x0002B1A8
			public string tooltip { get; set; }

			// Token: 0x1700015A RID: 346
			// (get) Token: 0x06000A32 RID: 2610 RVA: 0x0002CFB1 File Offset: 0x0002B1B1
			// (set) Token: 0x06000A33 RID: 2611 RVA: 0x0002CFB9 File Offset: 0x0002B1B9
			public string queryPath { get; private set; }

			// Token: 0x1700015B RID: 347
			// (get) Token: 0x06000A34 RID: 2612 RVA: 0x0002CFC2 File Offset: 0x0002B1C2
			public bool isEditorOnly
			{
				get
				{
					return this.flags.HasFlag(DebugUI.Flags.EditorOnly);
				}
			}

			// Token: 0x1700015C RID: 348
			// (get) Token: 0x06000A35 RID: 2613 RVA: 0x0002CFDA File Offset: 0x0002B1DA
			public bool isRuntimeOnly
			{
				get
				{
					return this.flags.HasFlag(DebugUI.Flags.RuntimeOnly);
				}
			}

			// Token: 0x1700015D RID: 349
			// (get) Token: 0x06000A36 RID: 2614 RVA: 0x0002CFF2 File Offset: 0x0002B1F2
			public bool isInactiveInEditor
			{
				get
				{
					return this.isRuntimeOnly && !Application.isPlaying;
				}
			}

			// Token: 0x1700015E RID: 350
			// (get) Token: 0x06000A37 RID: 2615 RVA: 0x0002D006 File Offset: 0x0002B206
			public bool isHidden
			{
				get
				{
					Func<bool> func = this.isHiddenCallback;
					return func != null && func();
				}
			}

			// Token: 0x06000A38 RID: 2616 RVA: 0x0002D019 File Offset: 0x0002B219
			internal virtual void GenerateQueryPath()
			{
				this.queryPath = this.displayName.Trim();
				if (this.m_Parent != null)
				{
					this.queryPath = this.m_Parent.queryPath + " -> " + this.queryPath;
				}
			}

			// Token: 0x06000A39 RID: 2617 RVA: 0x0002D058 File Offset: 0x0002B258
			public override int GetHashCode()
			{
				return this.queryPath.GetHashCode() ^ this.isHidden.GetHashCode();
			}

			// Token: 0x1700015F RID: 351
			// (set) Token: 0x06000A3A RID: 2618 RVA: 0x0002D07F File Offset: 0x0002B27F
			public DebugUI.Widget.NameAndTooltip nameAndTooltip
			{
				set
				{
					this.displayName = value.name;
					this.tooltip = value.tooltip;
				}
			}

			// Token: 0x04000626 RID: 1574
			protected DebugUI.Panel m_Panel;

			// Token: 0x04000627 RID: 1575
			protected DebugUI.IContainer m_Parent;

			// Token: 0x0400062C RID: 1580
			public Func<bool> isHiddenCallback;

			// Token: 0x020001F9 RID: 505
			public struct NameAndTooltip
			{
				// Token: 0x040007E6 RID: 2022
				public string name;

				// Token: 0x040007E7 RID: 2023
				public string tooltip;
			}
		}

		// Token: 0x02000174 RID: 372
		public interface IContainer
		{
			// Token: 0x17000160 RID: 352
			// (get) Token: 0x06000A3C RID: 2620
			ObservableList<DebugUI.Widget> children { get; }

			// Token: 0x17000161 RID: 353
			// (get) Token: 0x06000A3D RID: 2621
			// (set) Token: 0x06000A3E RID: 2622
			string displayName { get; set; }

			// Token: 0x17000162 RID: 354
			// (get) Token: 0x06000A3F RID: 2623
			string queryPath { get; }
		}

		// Token: 0x02000175 RID: 373
		public interface IValueField
		{
			// Token: 0x06000A40 RID: 2624
			object GetValue();

			// Token: 0x06000A41 RID: 2625
			void SetValue(object value);

			// Token: 0x06000A42 RID: 2626
			object ValidateValue(object value);
		}

		// Token: 0x02000176 RID: 374
		public class Button : DebugUI.Widget
		{
			// Token: 0x17000163 RID: 355
			// (get) Token: 0x06000A43 RID: 2627 RVA: 0x0002D0A1 File Offset: 0x0002B2A1
			// (set) Token: 0x06000A44 RID: 2628 RVA: 0x0002D0A9 File Offset: 0x0002B2A9
			public Action action { get; set; }
		}

		// Token: 0x02000177 RID: 375
		public class Value : DebugUI.Widget
		{
			// Token: 0x17000164 RID: 356
			// (get) Token: 0x06000A46 RID: 2630 RVA: 0x0002D0BA File Offset: 0x0002B2BA
			// (set) Token: 0x06000A47 RID: 2631 RVA: 0x0002D0C2 File Offset: 0x0002B2C2
			public Func<object> getter { get; set; }

			// Token: 0x06000A48 RID: 2632 RVA: 0x0002D0CB File Offset: 0x0002B2CB
			public Value()
			{
				base.displayName = "";
			}

			// Token: 0x06000A49 RID: 2633 RVA: 0x0002D0E9 File Offset: 0x0002B2E9
			public virtual object GetValue()
			{
				return this.getter();
			}

			// Token: 0x06000A4A RID: 2634 RVA: 0x0002D0F6 File Offset: 0x0002B2F6
			public virtual string FormatString(object value)
			{
				if (!string.IsNullOrEmpty(this.formatString))
				{
					return string.Format(this.formatString, value);
				}
				return string.Format("{0}", value);
			}

			// Token: 0x0400062F RID: 1583
			public float refreshRate = 0.1f;

			// Token: 0x04000630 RID: 1584
			public string formatString;
		}

		// Token: 0x02000178 RID: 376
		public class ProgressBarValue : DebugUI.Value
		{
			// Token: 0x06000A4B RID: 2635 RVA: 0x0002D120 File Offset: 0x0002B320
			public override string FormatString(object value)
			{
				float num = DebugUI.ProgressBarValue.<FormatString>g__Remap01|2_0(Mathf.Clamp((float)value, this.min, this.max), this.min, this.max);
				return string.Format("{0:P1}", num);
			}

			// Token: 0x06000A4D RID: 2637 RVA: 0x0002D179 File Offset: 0x0002B379
			[CompilerGenerated]
			internal static float <FormatString>g__Remap01|2_0(float v, float x0, float y0)
			{
				return (v - x0) / (y0 - x0);
			}

			// Token: 0x04000631 RID: 1585
			public float min;

			// Token: 0x04000632 RID: 1586
			public float max = 1f;
		}

		// Token: 0x02000179 RID: 377
		public class ValueTuple : DebugUI.Widget
		{
			// Token: 0x17000165 RID: 357
			// (get) Token: 0x06000A4E RID: 2638 RVA: 0x0002D182 File Offset: 0x0002B382
			public int numElements
			{
				get
				{
					return this.values.Length;
				}
			}

			// Token: 0x17000166 RID: 358
			// (get) Token: 0x06000A4F RID: 2639 RVA: 0x0002D18C File Offset: 0x0002B38C
			public float refreshRate
			{
				get
				{
					DebugUI.Value value = this.values.FirstOrDefault<DebugUI.Value>();
					if (value == null)
					{
						return 0.1f;
					}
					return value.refreshRate;
				}
			}

			// Token: 0x04000633 RID: 1587
			public DebugUI.Value[] values;

			// Token: 0x04000634 RID: 1588
			public int pinnedElementIndex = -1;
		}

		// Token: 0x0200017A RID: 378
		public abstract class Field<T> : DebugUI.Widget, DebugUI.IValueField
		{
			// Token: 0x17000167 RID: 359
			// (get) Token: 0x06000A51 RID: 2641 RVA: 0x0002D1B7 File Offset: 0x0002B3B7
			// (set) Token: 0x06000A52 RID: 2642 RVA: 0x0002D1BF File Offset: 0x0002B3BF
			public Func<T> getter { get; set; }

			// Token: 0x17000168 RID: 360
			// (get) Token: 0x06000A53 RID: 2643 RVA: 0x0002D1C8 File Offset: 0x0002B3C8
			// (set) Token: 0x06000A54 RID: 2644 RVA: 0x0002D1D0 File Offset: 0x0002B3D0
			public Action<T> setter { get; set; }

			// Token: 0x06000A55 RID: 2645 RVA: 0x0002D1D9 File Offset: 0x0002B3D9
			object DebugUI.IValueField.ValidateValue(object value)
			{
				return this.ValidateValue((T)((object)value));
			}

			// Token: 0x06000A56 RID: 2646 RVA: 0x0002D1EC File Offset: 0x0002B3EC
			public virtual T ValidateValue(T value)
			{
				return value;
			}

			// Token: 0x06000A57 RID: 2647 RVA: 0x0002D1EF File Offset: 0x0002B3EF
			object DebugUI.IValueField.GetValue()
			{
				return this.GetValue();
			}

			// Token: 0x06000A58 RID: 2648 RVA: 0x0002D1FC File Offset: 0x0002B3FC
			public T GetValue()
			{
				return this.getter();
			}

			// Token: 0x06000A59 RID: 2649 RVA: 0x0002D209 File Offset: 0x0002B409
			public void SetValue(object value)
			{
				this.SetValue((T)((object)value));
			}

			// Token: 0x06000A5A RID: 2650 RVA: 0x0002D218 File Offset: 0x0002B418
			public virtual void SetValue(T value)
			{
				T t = this.ValidateValue(value);
				if (t == null || !t.Equals(this.getter()))
				{
					this.setter(t);
					Action<DebugUI.Field<T>, T> action = this.onValueChanged;
					if (action == null)
					{
						return;
					}
					action(this, t);
				}
			}

			// Token: 0x04000637 RID: 1591
			public Action<DebugUI.Field<T>, T> onValueChanged;
		}

		// Token: 0x0200017B RID: 379
		public class BoolField : DebugUI.Field<bool>
		{
		}

		// Token: 0x0200017C RID: 380
		public class HistoryBoolField : DebugUI.BoolField
		{
			// Token: 0x17000169 RID: 361
			// (get) Token: 0x06000A5D RID: 2653 RVA: 0x0002D282 File Offset: 0x0002B482
			// (set) Token: 0x06000A5E RID: 2654 RVA: 0x0002D28A File Offset: 0x0002B48A
			public Func<bool>[] historyGetter { get; set; }

			// Token: 0x1700016A RID: 362
			// (get) Token: 0x06000A5F RID: 2655 RVA: 0x0002D293 File Offset: 0x0002B493
			public int historyDepth
			{
				get
				{
					Func<bool>[] historyGetter = this.historyGetter;
					if (historyGetter == null)
					{
						return 0;
					}
					return historyGetter.Length;
				}
			}

			// Token: 0x06000A60 RID: 2656 RVA: 0x0002D2A3 File Offset: 0x0002B4A3
			public bool GetHistoryValue(int historyIndex)
			{
				return this.historyGetter[historyIndex]();
			}
		}

		// Token: 0x0200017D RID: 381
		public class IntField : DebugUI.Field<int>
		{
			// Token: 0x06000A62 RID: 2658 RVA: 0x0002D2BA File Offset: 0x0002B4BA
			public override int ValidateValue(int value)
			{
				if (this.min != null)
				{
					value = Mathf.Max(value, this.min());
				}
				if (this.max != null)
				{
					value = Mathf.Min(value, this.max());
				}
				return value;
			}

			// Token: 0x04000639 RID: 1593
			public Func<int> min;

			// Token: 0x0400063A RID: 1594
			public Func<int> max;

			// Token: 0x0400063B RID: 1595
			public int incStep = 1;

			// Token: 0x0400063C RID: 1596
			public int intStepMult = 10;
		}

		// Token: 0x0200017E RID: 382
		public class UIntField : DebugUI.Field<uint>
		{
			// Token: 0x06000A64 RID: 2660 RVA: 0x0002D30A File Offset: 0x0002B50A
			public override uint ValidateValue(uint value)
			{
				if (this.min != null)
				{
					value = (uint)Mathf.Max((int)value, (int)this.min());
				}
				if (this.max != null)
				{
					value = (uint)Mathf.Min((int)value, (int)this.max());
				}
				return value;
			}

			// Token: 0x0400063D RID: 1597
			public Func<uint> min;

			// Token: 0x0400063E RID: 1598
			public Func<uint> max;

			// Token: 0x0400063F RID: 1599
			public uint incStep = 1U;

			// Token: 0x04000640 RID: 1600
			public uint intStepMult = 10U;
		}

		// Token: 0x0200017F RID: 383
		public class FloatField : DebugUI.Field<float>
		{
			// Token: 0x06000A66 RID: 2662 RVA: 0x0002D35A File Offset: 0x0002B55A
			public override float ValidateValue(float value)
			{
				if (this.min != null)
				{
					value = Mathf.Max(value, this.min());
				}
				if (this.max != null)
				{
					value = Mathf.Min(value, this.max());
				}
				return value;
			}

			// Token: 0x04000641 RID: 1601
			public Func<float> min;

			// Token: 0x04000642 RID: 1602
			public Func<float> max;

			// Token: 0x04000643 RID: 1603
			public float incStep = 0.1f;

			// Token: 0x04000644 RID: 1604
			public float incStepMult = 10f;

			// Token: 0x04000645 RID: 1605
			public int decimals = 3;
		}

		// Token: 0x02000180 RID: 384
		public abstract class EnumField<T> : DebugUI.Field<T>
		{
			// Token: 0x1700016B RID: 363
			// (get) Token: 0x06000A68 RID: 2664 RVA: 0x0002D3B8 File Offset: 0x0002B5B8
			// (set) Token: 0x06000A69 RID: 2665 RVA: 0x0002D3C0 File Offset: 0x0002B5C0
			public int[] enumValues
			{
				get
				{
					return this.m_EnumValues;
				}
				set
				{
					int? num = (value != null) ? new int?(value.Distinct<int>().Count<int>()) : null;
					int? num2 = (value != null) ? new int?(value.Count<int>()) : null;
					if (!(num.GetValueOrDefault() == num2.GetValueOrDefault() & num != null == (num2 != null)))
					{
						Debug.LogWarning(base.displayName + " - The values of the enum are duplicated, this might lead to a errors displaying the enum");
					}
					this.m_EnumValues = value;
				}
			}

			// Token: 0x06000A6A RID: 2666 RVA: 0x0002D448 File Offset: 0x0002B648
			protected void AutoFillFromType(Type enumType)
			{
				if (enumType == null || !enumType.IsEnum)
				{
					throw new ArgumentException("enumType must not be null and it must be an Enum type");
				}
				List<GUIContent> list;
				using (ListPool<GUIContent>.Get(out list))
				{
					List<int> list2;
					using (ListPool<int>.Get(out list2))
					{
						foreach (FieldInfo fieldInfo2 in from fieldInfo in enumType.GetFields(BindingFlags.Static | BindingFlags.Public)
						where !fieldInfo.IsDefined(typeof(ObsoleteAttribute)) && !fieldInfo.IsDefined(typeof(HideInInspector))
						select fieldInfo)
						{
							InspectorNameAttribute customAttribute = fieldInfo2.GetCustomAttribute<InspectorNameAttribute>();
							GUIContent item = new GUIContent((customAttribute == null) ? DebugUI.EnumField<T>.s_NicifyRegEx.Replace(fieldInfo2.Name, "$1 ") : customAttribute.displayName);
							list.Add(item);
							list2.Add((int)Enum.Parse(enumType, fieldInfo2.Name));
						}
						this.enumNames = list.ToArray();
						this.enumValues = list2.ToArray();
					}
				}
			}

			// Token: 0x04000646 RID: 1606
			public GUIContent[] enumNames;

			// Token: 0x04000647 RID: 1607
			private int[] m_EnumValues;

			// Token: 0x04000648 RID: 1608
			private static Regex s_NicifyRegEx = new Regex("([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", RegexOptions.Compiled);
		}

		// Token: 0x02000181 RID: 385
		public class EnumField : DebugUI.EnumField<int>
		{
			// Token: 0x1700016C RID: 364
			// (get) Token: 0x06000A6D RID: 2669 RVA: 0x0002D5A4 File Offset: 0x0002B7A4
			internal int[] indexes
			{
				get
				{
					int[] result;
					if ((result = this.m_Indexes) == null)
					{
						int start = 0;
						GUIContent[] enumNames = this.enumNames;
						result = (this.m_Indexes = Enumerable.Range(start, (enumNames != null) ? enumNames.Length : 0).ToArray<int>());
					}
					return result;
				}
			}

			// Token: 0x1700016D RID: 365
			// (get) Token: 0x06000A6E RID: 2670 RVA: 0x0002D5DE File Offset: 0x0002B7DE
			// (set) Token: 0x06000A6F RID: 2671 RVA: 0x0002D5E6 File Offset: 0x0002B7E6
			public Func<int> getIndex { get; set; }

			// Token: 0x1700016E RID: 366
			// (get) Token: 0x06000A70 RID: 2672 RVA: 0x0002D5EF File Offset: 0x0002B7EF
			// (set) Token: 0x06000A71 RID: 2673 RVA: 0x0002D5F7 File Offset: 0x0002B7F7
			public Action<int> setIndex { get; set; }

			// Token: 0x1700016F RID: 367
			// (get) Token: 0x06000A72 RID: 2674 RVA: 0x0002D600 File Offset: 0x0002B800
			// (set) Token: 0x06000A73 RID: 2675 RVA: 0x0002D60D File Offset: 0x0002B80D
			public int currentIndex
			{
				get
				{
					return this.getIndex();
				}
				set
				{
					this.setIndex(value);
				}
			}

			// Token: 0x17000170 RID: 368
			// (set) Token: 0x06000A74 RID: 2676 RVA: 0x0002D61B File Offset: 0x0002B81B
			public Type autoEnum
			{
				set
				{
					base.AutoFillFromType(value);
					this.InitQuickSeparators();
				}
			}

			// Token: 0x06000A75 RID: 2677 RVA: 0x0002D62C File Offset: 0x0002B82C
			internal void InitQuickSeparators()
			{
				IEnumerable<string> source = this.enumNames.Select(delegate(GUIContent x)
				{
					string[] array = x.text.Split('/', StringSplitOptions.None);
					if (array.Length == 1)
					{
						return "";
					}
					return array[0];
				});
				this.quickSeparators = new int[source.Distinct<string>().Count<string>()];
				string a = null;
				int i = 0;
				int num = 0;
				while (i < this.quickSeparators.Length)
				{
					string text = source.ElementAt(num);
					while (a == text)
					{
						text = source.ElementAt(++num);
					}
					a = text;
					this.quickSeparators[i] = num++;
					i++;
				}
			}

			// Token: 0x06000A76 RID: 2678 RVA: 0x0002D6C4 File Offset: 0x0002B8C4
			public override void SetValue(int value)
			{
				int num = this.ValidateValue(value);
				int num2 = Array.IndexOf<int>(base.enumValues, num);
				if (this.currentIndex != num2 && !num.Equals(base.getter()))
				{
					base.setter(num);
					Action<DebugUI.Field<int>, int> onValueChanged = this.onValueChanged;
					if (onValueChanged != null)
					{
						onValueChanged(this, num);
					}
					if (num2 > -1)
					{
						this.currentIndex = num2;
					}
				}
			}

			// Token: 0x04000649 RID: 1609
			internal int[] quickSeparators;

			// Token: 0x0400064A RID: 1610
			private int[] m_Indexes;
		}

		// Token: 0x02000182 RID: 386
		public class ObjectPopupField : DebugUI.Field<Object>
		{
			// Token: 0x17000171 RID: 369
			// (get) Token: 0x06000A78 RID: 2680 RVA: 0x0002D735 File Offset: 0x0002B935
			// (set) Token: 0x06000A79 RID: 2681 RVA: 0x0002D73D File Offset: 0x0002B93D
			public Func<IEnumerable<Object>> getObjects { get; set; }
		}

		// Token: 0x02000183 RID: 387
		public class HistoryEnumField : DebugUI.EnumField
		{
			// Token: 0x17000172 RID: 370
			// (get) Token: 0x06000A7B RID: 2683 RVA: 0x0002D74E File Offset: 0x0002B94E
			// (set) Token: 0x06000A7C RID: 2684 RVA: 0x0002D756 File Offset: 0x0002B956
			public Func<int>[] historyIndexGetter { get; set; }

			// Token: 0x17000173 RID: 371
			// (get) Token: 0x06000A7D RID: 2685 RVA: 0x0002D75F File Offset: 0x0002B95F
			public int historyDepth
			{
				get
				{
					Func<int>[] historyIndexGetter = this.historyIndexGetter;
					if (historyIndexGetter == null)
					{
						return 0;
					}
					return historyIndexGetter.Length;
				}
			}

			// Token: 0x06000A7E RID: 2686 RVA: 0x0002D76F File Offset: 0x0002B96F
			public int GetHistoryValue(int historyIndex)
			{
				return this.historyIndexGetter[historyIndex]();
			}
		}

		// Token: 0x02000184 RID: 388
		public class BitField : DebugUI.EnumField<Enum>
		{
			// Token: 0x17000174 RID: 372
			// (get) Token: 0x06000A80 RID: 2688 RVA: 0x0002D786 File Offset: 0x0002B986
			// (set) Token: 0x06000A81 RID: 2689 RVA: 0x0002D78E File Offset: 0x0002B98E
			public Type enumType
			{
				get
				{
					return this.m_EnumType;
				}
				set
				{
					this.m_EnumType = value;
					base.AutoFillFromType(value);
				}
			}

			// Token: 0x0400064F RID: 1615
			private Type m_EnumType;
		}

		// Token: 0x02000185 RID: 389
		public class ColorField : DebugUI.Field<Color>
		{
			// Token: 0x06000A83 RID: 2691 RVA: 0x0002D7A8 File Offset: 0x0002B9A8
			public override Color ValidateValue(Color value)
			{
				if (!this.hdr)
				{
					value.r = Mathf.Clamp01(value.r);
					value.g = Mathf.Clamp01(value.g);
					value.b = Mathf.Clamp01(value.b);
					value.a = Mathf.Clamp01(value.a);
				}
				return value;
			}

			// Token: 0x04000650 RID: 1616
			public bool hdr;

			// Token: 0x04000651 RID: 1617
			public bool showAlpha = true;

			// Token: 0x04000652 RID: 1618
			public bool showPicker = true;

			// Token: 0x04000653 RID: 1619
			public float incStep = 0.025f;

			// Token: 0x04000654 RID: 1620
			public float incStepMult = 5f;

			// Token: 0x04000655 RID: 1621
			public int decimals = 3;
		}

		// Token: 0x02000186 RID: 390
		public class Vector2Field : DebugUI.Field<Vector2>
		{
			// Token: 0x04000656 RID: 1622
			public float incStep = 0.025f;

			// Token: 0x04000657 RID: 1623
			public float incStepMult = 10f;

			// Token: 0x04000658 RID: 1624
			public int decimals = 3;
		}

		// Token: 0x02000187 RID: 391
		public class Vector3Field : DebugUI.Field<Vector3>
		{
			// Token: 0x04000659 RID: 1625
			public float incStep = 0.025f;

			// Token: 0x0400065A RID: 1626
			public float incStepMult = 10f;

			// Token: 0x0400065B RID: 1627
			public int decimals = 3;
		}

		// Token: 0x02000188 RID: 392
		public class Vector4Field : DebugUI.Field<Vector4>
		{
			// Token: 0x0400065C RID: 1628
			public float incStep = 0.025f;

			// Token: 0x0400065D RID: 1629
			public float incStepMult = 10f;

			// Token: 0x0400065E RID: 1630
			public int decimals = 3;
		}

		// Token: 0x02000189 RID: 393
		public class ObjectField : DebugUI.Field<Object>
		{
			// Token: 0x0400065F RID: 1631
			public Type type = typeof(Object);
		}

		// Token: 0x0200018A RID: 394
		public class ObjectListField : DebugUI.Field<Object[]>
		{
			// Token: 0x04000660 RID: 1632
			public Type type = typeof(Object);
		}

		// Token: 0x0200018B RID: 395
		public class MessageBox : DebugUI.Widget
		{
			// Token: 0x04000661 RID: 1633
			public DebugUI.MessageBox.Style style;

			// Token: 0x020001FC RID: 508
			public enum Style
			{
				// Token: 0x040007ED RID: 2029
				Info,
				// Token: 0x040007EE RID: 2030
				Warning,
				// Token: 0x040007EF RID: 2031
				Error
			}
		}

		// Token: 0x0200018C RID: 396
		public class Panel : DebugUI.IContainer, IComparable<DebugUI.Panel>
		{
			// Token: 0x17000175 RID: 373
			// (get) Token: 0x06000A8B RID: 2699 RVA: 0x0002D8E0 File Offset: 0x0002BAE0
			// (set) Token: 0x06000A8C RID: 2700 RVA: 0x0002D8E8 File Offset: 0x0002BAE8
			public DebugUI.Flags flags { get; set; }

			// Token: 0x17000176 RID: 374
			// (get) Token: 0x06000A8D RID: 2701 RVA: 0x0002D8F1 File Offset: 0x0002BAF1
			// (set) Token: 0x06000A8E RID: 2702 RVA: 0x0002D8F9 File Offset: 0x0002BAF9
			public string displayName { get; set; }

			// Token: 0x17000177 RID: 375
			// (get) Token: 0x06000A8F RID: 2703 RVA: 0x0002D902 File Offset: 0x0002BB02
			// (set) Token: 0x06000A90 RID: 2704 RVA: 0x0002D90A File Offset: 0x0002BB0A
			public int groupIndex { get; set; }

			// Token: 0x17000178 RID: 376
			// (get) Token: 0x06000A91 RID: 2705 RVA: 0x0002D913 File Offset: 0x0002BB13
			public string queryPath
			{
				get
				{
					return this.displayName;
				}
			}

			// Token: 0x17000179 RID: 377
			// (get) Token: 0x06000A92 RID: 2706 RVA: 0x0002D91B File Offset: 0x0002BB1B
			public bool isEditorOnly
			{
				get
				{
					return (this.flags & DebugUI.Flags.EditorOnly) > DebugUI.Flags.None;
				}
			}

			// Token: 0x1700017A RID: 378
			// (get) Token: 0x06000A93 RID: 2707 RVA: 0x0002D928 File Offset: 0x0002BB28
			public bool isRuntimeOnly
			{
				get
				{
					return (this.flags & DebugUI.Flags.RuntimeOnly) > DebugUI.Flags.None;
				}
			}

			// Token: 0x1700017B RID: 379
			// (get) Token: 0x06000A94 RID: 2708 RVA: 0x0002D935 File Offset: 0x0002BB35
			public bool isInactiveInEditor
			{
				get
				{
					return this.isRuntimeOnly && !Application.isPlaying;
				}
			}

			// Token: 0x1700017C RID: 380
			// (get) Token: 0x06000A95 RID: 2709 RVA: 0x0002D949 File Offset: 0x0002BB49
			public bool editorForceUpdate
			{
				get
				{
					return (this.flags & DebugUI.Flags.EditorForceUpdate) > DebugUI.Flags.None;
				}
			}

			// Token: 0x1700017D RID: 381
			// (get) Token: 0x06000A96 RID: 2710 RVA: 0x0002D956 File Offset: 0x0002BB56
			// (set) Token: 0x06000A97 RID: 2711 RVA: 0x0002D95E File Offset: 0x0002BB5E
			public ObservableList<DebugUI.Widget> children { get; private set; }

			// Token: 0x1400000B RID: 11
			// (add) Token: 0x06000A98 RID: 2712 RVA: 0x0002D968 File Offset: 0x0002BB68
			// (remove) Token: 0x06000A99 RID: 2713 RVA: 0x0002D9A0 File Offset: 0x0002BBA0
			public event Action<DebugUI.Panel> onSetDirty = delegate(DebugUI.Panel <p0>)
			{
			};

			// Token: 0x06000A9A RID: 2714 RVA: 0x0002D9D8 File Offset: 0x0002BBD8
			public Panel()
			{
				this.children = new ObservableList<DebugUI.Widget>();
				this.children.ItemAdded += this.OnItemAdded;
				this.children.ItemRemoved += this.OnItemRemoved;
			}

			// Token: 0x06000A9B RID: 2715 RVA: 0x0002DA4B File Offset: 0x0002BC4B
			protected virtual void OnItemAdded(ObservableList<DebugUI.Widget> sender, ListChangedEventArgs<DebugUI.Widget> e)
			{
				if (e.item != null)
				{
					e.item.panel = this;
					e.item.parent = this;
				}
				this.SetDirty();
			}

			// Token: 0x06000A9C RID: 2716 RVA: 0x0002DA73 File Offset: 0x0002BC73
			protected virtual void OnItemRemoved(ObservableList<DebugUI.Widget> sender, ListChangedEventArgs<DebugUI.Widget> e)
			{
				if (e.item != null)
				{
					e.item.panel = null;
					e.item.parent = null;
				}
				this.SetDirty();
			}

			// Token: 0x06000A9D RID: 2717 RVA: 0x0002DA9C File Offset: 0x0002BC9C
			public void SetDirty()
			{
				int count = this.children.Count;
				for (int i = 0; i < count; i++)
				{
					this.children[i].GenerateQueryPath();
				}
				this.onSetDirty(this);
			}

			// Token: 0x06000A9E RID: 2718 RVA: 0x0002DAE0 File Offset: 0x0002BCE0
			public override int GetHashCode()
			{
				int num = 17;
				num = num * 23 + this.displayName.GetHashCode();
				int count = this.children.Count;
				for (int i = 0; i < count; i++)
				{
					num = num * 23 + this.children[i].GetHashCode();
				}
				return num;
			}

			// Token: 0x06000A9F RID: 2719 RVA: 0x0002DB34 File Offset: 0x0002BD34
			int IComparable<DebugUI.Panel>.CompareTo(DebugUI.Panel other)
			{
				if (other != null)
				{
					return this.groupIndex.CompareTo(other.groupIndex);
				}
				return 1;
			}
		}
	}
}
