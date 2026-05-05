using System;
using System.Diagnostics;
using UnityEngine.UIElements.Experimental;

namespace UnityEngine.UIElements
{
	// Token: 0x0200004B RID: 75
	internal class ReusableCollectionItem
	{
		// Token: 0x17000093 RID: 147
		// (get) Token: 0x0600032A RID: 810 RVA: 0x0000BC2E File Offset: 0x00009E2E
		public virtual VisualElement rootElement
		{
			get
			{
				return this.bindableElement;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x0600032B RID: 811 RVA: 0x0000BC36 File Offset: 0x00009E36
		// (set) Token: 0x0600032C RID: 812 RVA: 0x0000BC3E File Offset: 0x00009E3E
		public VisualElement bindableElement { get; protected set; }

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x0600032D RID: 813 RVA: 0x0000BC47 File Offset: 0x00009E47
		// (set) Token: 0x0600032E RID: 814 RVA: 0x0000BC4F File Offset: 0x00009E4F
		public ValueAnimation<StyleValues> animator { get; set; }

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x0600032F RID: 815 RVA: 0x0000BC58 File Offset: 0x00009E58
		// (set) Token: 0x06000330 RID: 816 RVA: 0x0000BC60 File Offset: 0x00009E60
		public int index { get; set; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000331 RID: 817 RVA: 0x0000BC69 File Offset: 0x00009E69
		// (set) Token: 0x06000332 RID: 818 RVA: 0x0000BC71 File Offset: 0x00009E71
		public int id { get; set; }

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000333 RID: 819 RVA: 0x0000BC7A File Offset: 0x00009E7A
		// (set) Token: 0x06000334 RID: 820 RVA: 0x0000BC82 File Offset: 0x00009E82
		internal bool isDragGhost { get; private set; }

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06000335 RID: 821 RVA: 0x0000BC8C File Offset: 0x00009E8C
		// (remove) Token: 0x06000336 RID: 822 RVA: 0x0000BCC4 File Offset: 0x00009EC4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event Action<ReusableCollectionItem> onGeometryChanged;

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x06000337 RID: 823 RVA: 0x0000BCFC File Offset: 0x00009EFC
		// (remove) Token: 0x06000338 RID: 824 RVA: 0x0000BD34 File Offset: 0x00009F34
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal event Action<ReusableCollectionItem> onDestroy;

		// Token: 0x06000339 RID: 825 RVA: 0x0000BD6C File Offset: 0x00009F6C
		public ReusableCollectionItem()
		{
			this.index = (this.id = -1);
			this.m_GeometryChangedEventCallback = new EventCallback<GeometryChangedEvent>(this.OnGeometryChanged);
		}

		// Token: 0x0600033A RID: 826 RVA: 0x0000BDA5 File Offset: 0x00009FA5
		public virtual void Init(VisualElement item)
		{
			this.bindableElement = item;
		}

		// Token: 0x0600033B RID: 827 RVA: 0x0000BDB0 File Offset: 0x00009FB0
		public virtual void PreAttachElement()
		{
			this.rootElement.AddToClassList(BaseVerticalCollectionView.itemUssClassName);
			this.rootElement.RegisterCallback<GeometryChangedEvent>(this.m_GeometryChangedEventCallback, TrickleDown.NoTrickleDown);
		}

		// Token: 0x0600033C RID: 828 RVA: 0x0000BDD8 File Offset: 0x00009FD8
		public virtual void DetachElement()
		{
			this.rootElement.RemoveFromClassList(BaseVerticalCollectionView.itemUssClassName);
			this.rootElement.UnregisterCallback<GeometryChangedEvent>(this.m_GeometryChangedEventCallback, TrickleDown.NoTrickleDown);
			VisualElement rootElement = this.rootElement;
			if (rootElement != null)
			{
				rootElement.RemoveFromHierarchy();
			}
			this.SetSelected(false);
			this.SetDragGhost(false);
			this.index = (this.id = -1);
		}

		// Token: 0x0600033D RID: 829 RVA: 0x0000BE3E File Offset: 0x0000A03E
		public virtual void DestroyElement()
		{
			Action<ReusableCollectionItem> action = this.onDestroy;
			if (action != null)
			{
				action(this);
			}
		}

		// Token: 0x0600033E RID: 830 RVA: 0x0000BE54 File Offset: 0x0000A054
		public virtual void SetSelected(bool selected)
		{
			if (selected)
			{
				this.rootElement.AddToClassList(BaseVerticalCollectionView.itemSelectedVariantUssClassName);
				this.rootElement.pseudoStates |= PseudoStates.Checked;
			}
			else
			{
				this.rootElement.RemoveFromClassList(BaseVerticalCollectionView.itemSelectedVariantUssClassName);
				this.rootElement.pseudoStates &= ~PseudoStates.Checked;
			}
		}

		// Token: 0x0600033F RID: 831 RVA: 0x0000BEB8 File Offset: 0x0000A0B8
		public virtual void SetDragGhost(bool dragGhost)
		{
			this.isDragGhost = dragGhost;
			this.rootElement.style.maxHeight = (this.isDragGhost ? StyleKeyword.Undefined : StyleKeyword.Initial);
			this.bindableElement.style.display = (this.isDragGhost ? DisplayStyle.None : DisplayStyle.Flex);
		}

		// Token: 0x06000340 RID: 832 RVA: 0x0000BF12 File Offset: 0x0000A112
		protected void OnGeometryChanged(GeometryChangedEvent evt)
		{
			Action<ReusableCollectionItem> action = this.onGeometryChanged;
			if (action != null)
			{
				action(this);
			}
		}

		// Token: 0x040000EE RID: 238
		public const int UndefinedIndex = -1;

		// Token: 0x040000F5 RID: 245
		protected EventCallback<GeometryChangedEvent> m_GeometryChangedEventCallback;
	}
}
