using System;

namespace UnityEngine.UIElements.Internal
{
	// Token: 0x020004D2 RID: 1234
	internal class MultiColumnHeaderColumn : VisualElement
	{
		// Token: 0x170008B5 RID: 2229
		// (get) Token: 0x060026A2 RID: 9890 RVA: 0x000A2450 File Offset: 0x000A0650
		// (set) Token: 0x060026A3 RID: 9891 RVA: 0x000A2458 File Offset: 0x000A0658
		public Clickable clickable { get; private set; }

		// Token: 0x170008B6 RID: 2230
		// (get) Token: 0x060026A4 RID: 9892 RVA: 0x000A2461 File Offset: 0x000A0661
		// (set) Token: 0x060026A5 RID: 9893 RVA: 0x000A2469 File Offset: 0x000A0669
		public ColumnMover mover { get; private set; }

		// Token: 0x170008B7 RID: 2231
		// (get) Token: 0x060026A6 RID: 9894 RVA: 0x000A2472 File Offset: 0x000A0672
		// (set) Token: 0x060026A7 RID: 9895 RVA: 0x000A247F File Offset: 0x000A067F
		public string sortOrderLabel
		{
			get
			{
				return this.m_SortIndicatorContainer.sortOrderLabel;
			}
			set
			{
				this.m_SortIndicatorContainer.sortOrderLabel = value;
			}
		}

		// Token: 0x170008B8 RID: 2232
		// (get) Token: 0x060026A8 RID: 9896 RVA: 0x000A248E File Offset: 0x000A068E
		// (set) Token: 0x060026A9 RID: 9897 RVA: 0x000A2496 File Offset: 0x000A0696
		public Column column { get; private set; }

		// Token: 0x170008B9 RID: 2233
		// (get) Token: 0x060026AA RID: 9898 RVA: 0x000A249F File Offset: 0x000A069F
		internal Label title
		{
			get
			{
				VisualElement content = this.content;
				return (content != null) ? content.Q(MultiColumnHeaderColumn.titleElementName, null) : null;
			}
		}

		// Token: 0x170008BA RID: 2234
		// (get) Token: 0x060026AB RID: 9899 RVA: 0x000A24B9 File Offset: 0x000A06B9
		// (set) Token: 0x060026AC RID: 9900 RVA: 0x000A24C4 File Offset: 0x000A06C4
		public VisualElement content
		{
			get
			{
				return this.m_Content;
			}
			set
			{
				bool flag = this.m_Content != null;
				if (flag)
				{
					bool flag2 = this.m_Content.parent == this.m_ContentContainer;
					if (flag2)
					{
						this.m_Content.RemoveFromHierarchy();
					}
					this.DestroyHeaderContent();
					this.m_Content = null;
				}
				this.m_Content = value;
				bool flag3 = this.m_Content != null;
				if (flag3)
				{
					this.m_Content.AddToClassList(MultiColumnHeaderColumn.contentUssClassName);
					this.m_ContentContainer.Add(this.m_Content);
				}
			}
		}

		// Token: 0x170008BB RID: 2235
		// (get) Token: 0x060026AD RID: 9901 RVA: 0x000A254D File Offset: 0x000A074D
		// (set) Token: 0x060026AE RID: 9902 RVA: 0x000A2574 File Offset: 0x000A0774
		private bool isContentBound
		{
			get
			{
				return this.m_Content != null && (bool)this.m_Content.GetProperty(MultiColumnHeaderColumn.s_BoundVEPropertyName);
			}
			set
			{
				VisualElement content = this.m_Content;
				if (content != null)
				{
					content.SetProperty(MultiColumnHeaderColumn.s_BoundVEPropertyName, value);
				}
			}
		}

		// Token: 0x060026AF RID: 9903 RVA: 0x000A2598 File Offset: 0x000A0798
		public MultiColumnHeaderColumn() : this(new Column())
		{
		}

		// Token: 0x060026B0 RID: 9904 RVA: 0x000A25A8 File Offset: 0x000A07A8
		public MultiColumnHeaderColumn(Column column)
		{
			this.column = column;
			this.column.changed += this.OnColumnChanged;
			this.column.resized += this.OnColumnResized;
			base.AddToClassList(MultiColumnHeaderColumn.ussClassName);
			base.style.marginLeft = 0f;
			base.style.marginTop = 0f;
			base.style.marginRight = 0f;
			base.style.marginBottom = 0f;
			base.style.paddingLeft = 0f;
			base.style.paddingTop = 0f;
			base.style.paddingRight = 0f;
			base.style.paddingBottom = 0f;
			base.Add(this.m_SortIndicatorContainer = new MultiColumnHeaderColumnSortIndicator());
			this.m_ContentContainer = new VisualElement();
			this.m_ContentContainer.style.flexGrow = 1f;
			this.m_ContentContainer.style.flexShrink = 1f;
			this.m_ContentContainer.AddToClassList(MultiColumnHeaderColumn.contentContainerUssClassName);
			base.Add(this.m_ContentContainer);
			this.UpdateHeaderTemplate();
			this.UpdateGeometryFromColumn();
			this.InitManipulators();
		}

		// Token: 0x060026B1 RID: 9905 RVA: 0x000A273C File Offset: 0x000A093C
		private void OnColumnChanged(Column c, ColumnDataType role)
		{
			bool flag = this.column != c;
			if (!flag)
			{
				bool flag2 = role == ColumnDataType.HeaderTemplate;
				if (flag2)
				{
					IVisualElementScheduledItem scheduledHeaderTemplateUpdate = this.m_ScheduledHeaderTemplateUpdate;
					if (scheduledHeaderTemplateUpdate != null)
					{
						scheduledHeaderTemplateUpdate.Pause();
					}
					this.m_ScheduledHeaderTemplateUpdate = base.schedule.Execute(new Action(this.UpdateHeaderTemplate));
				}
				else
				{
					this.UpdateDataFromColumn();
				}
			}
		}

		// Token: 0x060026B2 RID: 9906 RVA: 0x000A27A1 File Offset: 0x000A09A1
		private void OnColumnResized(Column c)
		{
			this.UpdateGeometryFromColumn();
		}

		// Token: 0x060026B3 RID: 9907 RVA: 0x000A27AC File Offset: 0x000A09AC
		private void InitManipulators()
		{
			this.AddManipulator(this.mover = new ColumnMover());
			this.mover.movingChanged += this.OnMoverChanged;
			this.AddManipulator(this.clickable = new Clickable(null));
			this.clickable.activators.Add(new ManipulatorActivationFilter
			{
				button = MouseButton.LeftMouse,
				modifiers = EventModifiers.Shift
			});
			EventModifiers modifiers = EventModifiers.Control;
			RuntimePlatform platform = Application.platform;
			bool flag = platform == RuntimePlatform.OSXEditor || platform == RuntimePlatform.OSXPlayer;
			if (flag)
			{
				modifiers = EventModifiers.Command;
			}
			this.clickable.activators.Add(new ManipulatorActivationFilter
			{
				button = MouseButton.LeftMouse,
				modifiers = modifiers
			});
		}

		// Token: 0x060026B4 RID: 9908 RVA: 0x000A287C File Offset: 0x000A0A7C
		private void OnMoverChanged(ColumnMover mv)
		{
			bool moving = this.mover.moving;
			if (moving)
			{
				base.AddToClassList(MultiColumnHeaderColumn.movingUssClassName);
			}
			else
			{
				base.RemoveFromClassList(MultiColumnHeaderColumn.movingUssClassName);
			}
		}

		// Token: 0x060026B5 RID: 9909 RVA: 0x000A28B4 File Offset: 0x000A0AB4
		private void UpdateDataFromColumn()
		{
			bool flag = this.column == null;
			if (!flag)
			{
				base.name = this.column.name;
				this.UnbindHeaderContent();
				this.BindHeaderContent();
			}
		}

		// Token: 0x060026B6 RID: 9910 RVA: 0x000A28F4 File Offset: 0x000A0AF4
		private void BindHeaderContent()
		{
			bool flag = !this.isContentBound;
			if (flag)
			{
				Action<VisualElement> action = this.content.GetProperty(MultiColumnHeaderColumn.s_BindingCallbackVEPropertyName) as Action<VisualElement>;
				if (action != null)
				{
					action(this.content);
				}
				this.isContentBound = true;
			}
		}

		// Token: 0x060026B7 RID: 9911 RVA: 0x000A2948 File Offset: 0x000A0B48
		private void UnbindHeaderContent()
		{
			bool isContentBound = this.isContentBound;
			if (isContentBound)
			{
				Action<VisualElement> action = this.content.GetProperty(MultiColumnHeaderColumn.s_UnbindingCallbackVEPropertyName) as Action<VisualElement>;
				if (action != null)
				{
					action(this.content);
				}
				this.isContentBound = false;
			}
		}

		// Token: 0x060026B8 RID: 9912 RVA: 0x000A2998 File Offset: 0x000A0B98
		private void DestroyHeaderContent()
		{
			this.UnbindHeaderContent();
			Action<VisualElement> action = this.content.GetProperty(MultiColumnHeaderColumn.s_DestroyCallbackVEPropertyName) as Action<VisualElement>;
			this.content.SetProperty(MultiColumnHeaderColumn.s_BindingCallbackVEPropertyName, null);
			this.content.SetProperty(MultiColumnHeaderColumn.s_UnbindingCallbackVEPropertyName, null);
			this.content.SetProperty(MultiColumnHeaderColumn.s_DestroyCallbackVEPropertyName, null);
			this.content.SetProperty(MultiColumnHeaderColumn.s_BoundVEPropertyName, null);
			if (action != null)
			{
				action(this.content);
			}
		}

		// Token: 0x060026B9 RID: 9913 RVA: 0x000A2A38 File Offset: 0x000A0C38
		private VisualElement CreateDefaultHeaderContent()
		{
			VisualElement visualElement = new VisualElement
			{
				pickingMode = PickingMode.Ignore
			};
			visualElement.AddToClassList(MultiColumnHeaderColumn.defaultContentUssClassName);
			MultiColumnHeaderColumnIcon child = new MultiColumnHeaderColumnIcon
			{
				name = MultiColumnHeaderColumn.iconElementName,
				pickingMode = PickingMode.Ignore
			};
			Label label = new Label
			{
				name = MultiColumnHeaderColumn.titleElementName,
				pickingMode = PickingMode.Ignore
			};
			label.AddToClassList(MultiColumnHeaderColumn.titleUssClassName);
			visualElement.Add(child);
			visualElement.Add(label);
			return visualElement;
		}

		// Token: 0x060026BA RID: 9914 RVA: 0x000A2AB8 File Offset: 0x000A0CB8
		private void DefaultBindHeaderContent(VisualElement ve)
		{
			Label label = ve.Q(MultiColumnHeaderColumn.titleElementName, null);
			MultiColumnHeaderColumnIcon multiColumnHeaderColumnIcon = ve.Q(null, null);
			ve.RemoveFromClassList(MultiColumnHeaderColumn.hasTitleUssClassName);
			bool flag = label != null;
			if (flag)
			{
				label.text = this.column.title;
			}
			bool flag2 = !string.IsNullOrEmpty(this.column.title);
			if (flag2)
			{
				ve.AddToClassList(MultiColumnHeaderColumn.hasTitleUssClassName);
			}
			bool flag3 = multiColumnHeaderColumnIcon != null;
			if (flag3)
			{
				bool flag4 = this.column.icon.texture != null || this.column.icon.sprite != null || this.column.icon.vectorImage != null;
				if (flag4)
				{
					multiColumnHeaderColumnIcon.isImageInline = true;
					multiColumnHeaderColumnIcon.image = this.column.icon.texture;
					multiColumnHeaderColumnIcon.sprite = this.column.icon.sprite;
					multiColumnHeaderColumnIcon.vectorImage = this.column.icon.vectorImage;
				}
				else
				{
					bool isImageInline = multiColumnHeaderColumnIcon.isImageInline;
					if (isImageInline)
					{
						multiColumnHeaderColumnIcon.image = null;
						multiColumnHeaderColumnIcon.sprite = null;
						multiColumnHeaderColumnIcon.vectorImage = null;
					}
				}
				multiColumnHeaderColumnIcon.UpdateClassList();
			}
		}

		// Token: 0x060026BB RID: 9915 RVA: 0x000A2C1C File Offset: 0x000A0E1C
		private void UpdateHeaderTemplate()
		{
			bool flag = this.column == null;
			if (!flag)
			{
				Func<VisualElement> func = this.column.makeHeader;
				Action<VisualElement> value = this.column.bindHeader;
				Action<VisualElement> value2 = this.column.unbindHeader;
				Action<VisualElement> value3 = this.column.destroyHeader;
				bool flag2 = func == null;
				if (flag2)
				{
					func = new Func<VisualElement>(this.CreateDefaultHeaderContent);
					value = new Action<VisualElement>(this.DefaultBindHeaderContent);
					value2 = null;
					value3 = null;
				}
				this.content = func();
				this.content.SetProperty(MultiColumnHeaderColumn.s_BindingCallbackVEPropertyName, value);
				this.content.SetProperty(MultiColumnHeaderColumn.s_UnbindingCallbackVEPropertyName, value2);
				this.content.SetProperty(MultiColumnHeaderColumn.s_DestroyCallbackVEPropertyName, value3);
				this.isContentBound = false;
				this.m_ScheduledHeaderTemplateUpdate = null;
				this.UpdateDataFromColumn();
			}
		}

		// Token: 0x060026BC RID: 9916 RVA: 0x000A2D00 File Offset: 0x000A0F00
		private void UpdateGeometryFromColumn()
		{
			bool flag = float.IsNaN(this.column.desiredWidth);
			if (!flag)
			{
				base.style.width = this.column.desiredWidth;
			}
		}

		// Token: 0x060026BD RID: 9917 RVA: 0x000A2D40 File Offset: 0x000A0F40
		public void Dispose()
		{
			this.mover.movingChanged -= this.OnMoverChanged;
			this.column.changed -= this.OnColumnChanged;
			this.column.resized -= this.OnColumnResized;
			this.RemoveManipulator(this.mover);
			this.RemoveManipulator(this.clickable);
			this.mover = null;
			this.column = null;
			this.content = null;
		}

		// Token: 0x04001297 RID: 4759
		public static readonly string ussClassName = MultiColumnCollectionHeader.ussClassName + "__column";

		// Token: 0x04001298 RID: 4760
		public static readonly string sortableUssClassName = MultiColumnHeaderColumn.ussClassName + "--sortable";

		// Token: 0x04001299 RID: 4761
		public static readonly string sortedAscendingUssClassName = MultiColumnHeaderColumn.ussClassName + "--sorted-ascending";

		// Token: 0x0400129A RID: 4762
		public static readonly string sortedDescendingUssClassName = MultiColumnHeaderColumn.ussClassName + "--sorted-descending";

		// Token: 0x0400129B RID: 4763
		public static readonly string movingUssClassName = MultiColumnHeaderColumn.ussClassName + "--moving";

		// Token: 0x0400129C RID: 4764
		public static readonly string contentContainerUssClassName = MultiColumnHeaderColumn.ussClassName + "__content-container";

		// Token: 0x0400129D RID: 4765
		public static readonly string contentUssClassName = MultiColumnHeaderColumn.ussClassName + "__content";

		// Token: 0x0400129E RID: 4766
		public static readonly string defaultContentUssClassName = MultiColumnHeaderColumn.ussClassName + "__default-content";

		// Token: 0x0400129F RID: 4767
		public static readonly string hasIconUssClassName = MultiColumnHeaderColumn.contentUssClassName + "--has-icon";

		// Token: 0x040012A0 RID: 4768
		public static readonly string hasTitleUssClassName = MultiColumnHeaderColumn.contentUssClassName + "--has-title";

		// Token: 0x040012A1 RID: 4769
		public static readonly string titleUssClassName = MultiColumnHeaderColumn.ussClassName + "__title";

		// Token: 0x040012A2 RID: 4770
		public static readonly string iconElementName = "unity-multi-column-header-column-icon";

		// Token: 0x040012A3 RID: 4771
		public static readonly string titleElementName = "unity-multi-column-header-column-title";

		// Token: 0x040012A4 RID: 4772
		private static readonly string s_BoundVEPropertyName = "__bound";

		// Token: 0x040012A5 RID: 4773
		private static readonly string s_BindingCallbackVEPropertyName = "__binding-callback";

		// Token: 0x040012A6 RID: 4774
		private static readonly string s_UnbindingCallbackVEPropertyName = "__unbinding-callback";

		// Token: 0x040012A7 RID: 4775
		private static readonly string s_DestroyCallbackVEPropertyName = "__destroy-callback";

		// Token: 0x040012A8 RID: 4776
		private VisualElement m_ContentContainer;

		// Token: 0x040012A9 RID: 4777
		private VisualElement m_Content;

		// Token: 0x040012AA RID: 4778
		private MultiColumnHeaderColumnSortIndicator m_SortIndicatorContainer;

		// Token: 0x040012AB RID: 4779
		private IVisualElementScheduledItem m_ScheduledHeaderTemplateUpdate;
	}
}
