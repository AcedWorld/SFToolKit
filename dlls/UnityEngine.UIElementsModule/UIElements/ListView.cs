using System;
using System.Collections;

namespace UnityEngine.UIElements
{
	// Token: 0x020000E1 RID: 225
	public class ListView : BaseListView
	{
		// Token: 0x17000161 RID: 353
		// (get) Token: 0x060007AD RID: 1965 RVA: 0x0001D639 File Offset: 0x0001B839
		// (set) Token: 0x060007AE RID: 1966 RVA: 0x0001D644 File Offset: 0x0001B844
		public new Func<VisualElement> makeItem
		{
			get
			{
				return this.m_MakeItem;
			}
			set
			{
				bool flag = value != this.m_MakeItem;
				if (flag)
				{
					this.m_MakeItem = value;
					base.Rebuild();
				}
			}
		}

		// Token: 0x060007AF RID: 1967 RVA: 0x0001D672 File Offset: 0x0001B872
		internal void SetMakeItemWithoutNotify(Func<VisualElement> func)
		{
			this.m_MakeItem = func;
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x060007B0 RID: 1968 RVA: 0x0001D67C File Offset: 0x0001B87C
		// (set) Token: 0x060007B1 RID: 1969 RVA: 0x0001D684 File Offset: 0x0001B884
		public new Action<VisualElement, int> bindItem
		{
			get
			{
				return this.m_BindItem;
			}
			set
			{
				bool flag = value != this.m_BindItem;
				if (flag)
				{
					this.m_BindItem = value;
					base.RefreshItems();
				}
			}
		}

		// Token: 0x060007B2 RID: 1970 RVA: 0x0001D6B2 File Offset: 0x0001B8B2
		internal void SetBindItemWithoutNotify(Action<VisualElement, int> callback)
		{
			this.m_BindItem = callback;
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x060007B3 RID: 1971 RVA: 0x0001D6BC File Offset: 0x0001B8BC
		// (set) Token: 0x060007B4 RID: 1972 RVA: 0x0001D6C4 File Offset: 0x0001B8C4
		public new Action<VisualElement, int> unbindItem { get; set; }

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x060007B5 RID: 1973 RVA: 0x0001D6CD File Offset: 0x0001B8CD
		// (set) Token: 0x060007B6 RID: 1974 RVA: 0x0001D6D5 File Offset: 0x0001B8D5
		public new Action<VisualElement> destroyItem { get; set; }

		// Token: 0x060007B7 RID: 1975 RVA: 0x0001D6E0 File Offset: 0x0001B8E0
		internal override bool HasValidDataAndBindings()
		{
			return base.HasValidDataAndBindings() && this.makeItem != null == (this.bindItem != null);
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x0001D711 File Offset: 0x0001B911
		protected override CollectionViewController CreateViewController()
		{
			return new ListViewController();
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x0001D718 File Offset: 0x0001B918
		public ListView()
		{
			base.AddToClassList(BaseListView.ussClassName);
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x0001D72E File Offset: 0x0001B92E
		public ListView(IList itemsSource, float itemHeight = -1f, Func<VisualElement> makeItem = null, Action<VisualElement, int> bindItem = null) : base(itemsSource, itemHeight)
		{
			base.AddToClassList(BaseListView.ussClassName);
			this.makeItem = makeItem;
			this.bindItem = bindItem;
		}

		// Token: 0x0400034F RID: 847
		private Func<VisualElement> m_MakeItem;

		// Token: 0x04000350 RID: 848
		private Action<VisualElement, int> m_BindItem;

		// Token: 0x020000E2 RID: 226
		public new class UxmlFactory : UxmlFactory<ListView, ListView.UxmlTraits>
		{
		}

		// Token: 0x020000E3 RID: 227
		public new class UxmlTraits : BaseListView.UxmlTraits
		{
		}
	}
}
