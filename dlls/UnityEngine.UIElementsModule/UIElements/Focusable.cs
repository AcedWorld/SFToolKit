using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000245 RID: 581
	public abstract class Focusable : CallbackEventHandler
	{
		// Token: 0x0600107A RID: 4218 RVA: 0x0003BB3D File Offset: 0x00039D3D
		protected Focusable()
		{
			this.focusable = true;
			this.tabIndex = 0;
		}

		// Token: 0x17000373 RID: 883
		// (get) Token: 0x0600107B RID: 4219
		public abstract FocusController focusController { get; }

		// Token: 0x17000374 RID: 884
		// (get) Token: 0x0600107C RID: 4220 RVA: 0x0003BB57 File Offset: 0x00039D57
		// (set) Token: 0x0600107D RID: 4221 RVA: 0x0003BB5F File Offset: 0x00039D5F
		public bool focusable { get; set; }

		// Token: 0x17000375 RID: 885
		// (get) Token: 0x0600107E RID: 4222 RVA: 0x0003BB68 File Offset: 0x00039D68
		// (set) Token: 0x0600107F RID: 4223 RVA: 0x0003BB70 File Offset: 0x00039D70
		public int tabIndex { get; set; }

		// Token: 0x17000376 RID: 886
		// (get) Token: 0x06001080 RID: 4224 RVA: 0x0003BB7C File Offset: 0x00039D7C
		// (set) Token: 0x06001081 RID: 4225 RVA: 0x0003BB94 File Offset: 0x00039D94
		public bool delegatesFocus
		{
			get
			{
				return this.m_DelegatesFocus;
			}
			set
			{
				this.m_DelegatesFocus = value;
			}
		}

		// Token: 0x17000377 RID: 887
		// (get) Token: 0x06001082 RID: 4226 RVA: 0x0003BBA0 File Offset: 0x00039DA0
		// (set) Token: 0x06001083 RID: 4227 RVA: 0x0003BBB8 File Offset: 0x00039DB8
		internal bool excludeFromFocusRing
		{
			get
			{
				return this.m_ExcludeFromFocusRing;
			}
			set
			{
				bool flag = !((VisualElement)this).isCompositeRoot;
				if (flag)
				{
					throw new InvalidOperationException("excludeFromFocusRing should only be set on composite roots.");
				}
				this.m_ExcludeFromFocusRing = value;
			}
		}

		// Token: 0x17000378 RID: 888
		// (get) Token: 0x06001084 RID: 4228 RVA: 0x0003BBEB File Offset: 0x00039DEB
		public virtual bool canGrabFocus
		{
			get
			{
				return this.focusable;
			}
		}

		// Token: 0x06001085 RID: 4229 RVA: 0x0003BBF4 File Offset: 0x00039DF4
		public virtual void Focus()
		{
			bool flag = this.focusController != null;
			if (flag)
			{
				bool canGrabFocus = this.canGrabFocus;
				if (canGrabFocus)
				{
					Focusable focusDelegate = this.GetFocusDelegate();
					this.focusController.SwitchFocus(focusDelegate, this != focusDelegate, DispatchMode.Default);
				}
				else
				{
					this.focusController.SwitchFocus(null, false, DispatchMode.Default);
				}
			}
		}

		// Token: 0x06001086 RID: 4230 RVA: 0x0003BC4C File Offset: 0x00039E4C
		public virtual void Blur()
		{
			FocusController focusController = this.focusController;
			if (focusController != null)
			{
				focusController.Blur(this, false, DispatchMode.Default);
			}
		}

		// Token: 0x06001087 RID: 4231 RVA: 0x0003BC64 File Offset: 0x00039E64
		internal void BlurImmediately()
		{
			FocusController focusController = this.focusController;
			if (focusController != null)
			{
				focusController.Blur(this, false, DispatchMode.Immediate);
			}
		}

		// Token: 0x06001088 RID: 4232 RVA: 0x0003BC7C File Offset: 0x00039E7C
		private Focusable GetFocusDelegate()
		{
			Focusable focusable = this;
			while (focusable != null && focusable.delegatesFocus)
			{
				focusable = Focusable.GetFirstFocusableChild(focusable as VisualElement);
			}
			return focusable;
		}

		// Token: 0x06001089 RID: 4233 RVA: 0x0003BCB4 File Offset: 0x00039EB4
		private static Focusable GetFirstFocusableChild(VisualElement ve)
		{
			int childCount = ve.hierarchy.childCount;
			int i = 0;
			while (i < childCount)
			{
				VisualElement visualElement = ve.hierarchy[i];
				bool flag = visualElement.canGrabFocus && visualElement.tabIndex >= 0;
				if (!flag)
				{
					bool flag2 = visualElement.hierarchy.parent != null && visualElement == visualElement.hierarchy.parent.contentContainer;
					bool flag3 = !visualElement.isCompositeRoot && !flag2;
					if (flag3)
					{
						Focusable firstFocusableChild = Focusable.GetFirstFocusableChild(visualElement);
						bool flag4 = firstFocusableChild != null;
						if (flag4)
						{
							return firstFocusableChild;
						}
					}
					i++;
					continue;
				}
				return visualElement;
			}
			return null;
		}

		// Token: 0x0600108A RID: 4234 RVA: 0x0003BD82 File Offset: 0x00039F82
		[EventInterest(new Type[]
		{
			typeof(PointerDownEvent),
			typeof(NavigationMoveEvent)
		})]
		protected override void ExecuteDefaultAction(EventBase evt)
		{
			base.ExecuteDefaultAction(evt);
			this.ProcessEvent(evt);
		}

		// Token: 0x0600108B RID: 4235 RVA: 0x0003BD95 File Offset: 0x00039F95
		[EventInterest(new Type[]
		{
			typeof(PointerDownEvent),
			typeof(NavigationMoveEvent)
		})]
		internal override void ExecuteDefaultActionDisabled(EventBase evt)
		{
			base.ExecuteDefaultActionDisabled(evt);
			this.ProcessEvent(evt);
		}

		// Token: 0x0600108C RID: 4236 RVA: 0x0003BDA8 File Offset: 0x00039FA8
		private void ProcessEvent(EventBase evt)
		{
			bool flag = evt != null && evt.target == evt.leafTarget;
			if (flag)
			{
				FocusController focusController = this.focusController;
				if (focusController != null)
				{
					focusController.SwitchFocusOnEvent(evt);
				}
			}
		}

		// Token: 0x04000742 RID: 1858
		private bool m_DelegatesFocus;

		// Token: 0x04000743 RID: 1859
		private bool m_ExcludeFromFocusRing;
	}
}
