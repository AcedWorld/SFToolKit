using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200019A RID: 410
	[EventCategory(EventCategory.Command)]
	public abstract class CommandEventBase<T> : EventBase<T>, ICommandEvent where T : CommandEventBase<T>, new()
	{
		// Token: 0x17000282 RID: 642
		// (get) Token: 0x06000C8D RID: 3213 RVA: 0x00031D3C File Offset: 0x0002FF3C
		// (set) Token: 0x06000C8E RID: 3214 RVA: 0x00031D7B File Offset: 0x0002FF7B
		public string commandName
		{
			get
			{
				bool flag = this.m_CommandName == null && base.imguiEvent != null;
				string commandName;
				if (flag)
				{
					commandName = base.imguiEvent.commandName;
				}
				else
				{
					commandName = this.m_CommandName;
				}
				return commandName;
			}
			protected set
			{
				this.m_CommandName = value;
			}
		}

		// Token: 0x06000C8F RID: 3215 RVA: 0x00031D85 File Offset: 0x0002FF85
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06000C90 RID: 3216 RVA: 0x00031D96 File Offset: 0x0002FF96
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.Bubbles | EventBase.EventPropagation.TricklesDown | EventBase.EventPropagation.Cancellable);
			this.commandName = null;
		}

		// Token: 0x06000C91 RID: 3217 RVA: 0x00031DAC File Offset: 0x0002FFAC
		public static T GetPooled(Event systemEvent)
		{
			T pooled = EventBase<T>.GetPooled();
			pooled.imguiEvent = systemEvent;
			return pooled;
		}

		// Token: 0x06000C92 RID: 3218 RVA: 0x00031DD4 File Offset: 0x0002FFD4
		public static T GetPooled(string commandName)
		{
			T pooled = EventBase<T>.GetPooled();
			pooled.commandName = commandName;
			return pooled;
		}

		// Token: 0x06000C93 RID: 3219 RVA: 0x00031DFA File Offset: 0x0002FFFA
		protected CommandEventBase()
		{
			this.LocalInit();
		}

		// Token: 0x040005F7 RID: 1527
		private string m_CommandName;
	}
}
