using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001D6 RID: 470
	[EventCategory(EventCategory.Keyboard)]
	public abstract class KeyboardEventBase<T> : EventBase<T>, IKeyboardEvent where T : KeyboardEventBase<T>, new()
	{
		// Token: 0x170002EC RID: 748
		// (get) Token: 0x06000E2E RID: 3630 RVA: 0x00036871 File Offset: 0x00034A71
		// (set) Token: 0x06000E2F RID: 3631 RVA: 0x00036879 File Offset: 0x00034A79
		public EventModifiers modifiers { get; protected set; }

		// Token: 0x170002ED RID: 749
		// (get) Token: 0x06000E30 RID: 3632 RVA: 0x00036882 File Offset: 0x00034A82
		// (set) Token: 0x06000E31 RID: 3633 RVA: 0x0003688A File Offset: 0x00034A8A
		public char character { get; protected set; }

		// Token: 0x170002EE RID: 750
		// (get) Token: 0x06000E32 RID: 3634 RVA: 0x00036893 File Offset: 0x00034A93
		// (set) Token: 0x06000E33 RID: 3635 RVA: 0x0003689B File Offset: 0x00034A9B
		public KeyCode keyCode { get; protected set; }

		// Token: 0x170002EF RID: 751
		// (get) Token: 0x06000E34 RID: 3636 RVA: 0x000368A4 File Offset: 0x00034AA4
		public bool shiftKey
		{
			get
			{
				return (this.modifiers & EventModifiers.Shift) > EventModifiers.None;
			}
		}

		// Token: 0x170002F0 RID: 752
		// (get) Token: 0x06000E35 RID: 3637 RVA: 0x000368C4 File Offset: 0x00034AC4
		public bool ctrlKey
		{
			get
			{
				return (this.modifiers & EventModifiers.Control) > EventModifiers.None;
			}
		}

		// Token: 0x170002F1 RID: 753
		// (get) Token: 0x06000E36 RID: 3638 RVA: 0x000368E4 File Offset: 0x00034AE4
		public bool commandKey
		{
			get
			{
				return (this.modifiers & EventModifiers.Command) > EventModifiers.None;
			}
		}

		// Token: 0x170002F2 RID: 754
		// (get) Token: 0x06000E37 RID: 3639 RVA: 0x00036904 File Offset: 0x00034B04
		public bool altKey
		{
			get
			{
				return (this.modifiers & EventModifiers.Alt) > EventModifiers.None;
			}
		}

		// Token: 0x170002F3 RID: 755
		// (get) Token: 0x06000E38 RID: 3640 RVA: 0x00036924 File Offset: 0x00034B24
		internal bool functionKey
		{
			get
			{
				return (this.modifiers & EventModifiers.FunctionKey) > EventModifiers.None;
			}
		}

		// Token: 0x170002F4 RID: 756
		// (get) Token: 0x06000E39 RID: 3641 RVA: 0x00036944 File Offset: 0x00034B44
		public bool actionKey
		{
			get
			{
				bool flag = Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer;
				bool result;
				if (flag)
				{
					result = this.commandKey;
				}
				else
				{
					result = this.ctrlKey;
				}
				return result;
			}
		}

		// Token: 0x06000E3A RID: 3642 RVA: 0x0003697D File Offset: 0x00034B7D
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06000E3B RID: 3643 RVA: 0x0003698E File Offset: 0x00034B8E
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.Bubbles | EventBase.EventPropagation.TricklesDown | EventBase.EventPropagation.Cancellable | EventBase.EventPropagation.SkipDisabledElements);
			this.modifiers = EventModifiers.None;
			this.character = '\0';
			this.keyCode = KeyCode.None;
		}

		// Token: 0x06000E3C RID: 3644 RVA: 0x000369B4 File Offset: 0x00034BB4
		public static T GetPooled(char c, KeyCode keyCode, EventModifiers modifiers)
		{
			T pooled = EventBase<T>.GetPooled();
			pooled.modifiers = modifiers;
			pooled.character = c;
			pooled.keyCode = keyCode;
			return pooled;
		}

		// Token: 0x06000E3D RID: 3645 RVA: 0x000369F4 File Offset: 0x00034BF4
		public static T GetPooled(Event systemEvent)
		{
			T pooled = EventBase<T>.GetPooled();
			pooled.imguiEvent = systemEvent;
			bool flag = systemEvent != null;
			if (flag)
			{
				pooled.modifiers = systemEvent.modifiers;
				pooled.character = systemEvent.character;
				pooled.keyCode = systemEvent.keyCode;
			}
			return pooled;
		}

		// Token: 0x06000E3E RID: 3646 RVA: 0x00036A5A File Offset: 0x00034C5A
		protected KeyboardEventBase()
		{
			this.LocalInit();
		}
	}
}
