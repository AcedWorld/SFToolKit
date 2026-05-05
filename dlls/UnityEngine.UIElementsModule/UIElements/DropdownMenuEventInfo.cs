using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000179 RID: 377
	public class DropdownMenuEventInfo
	{
		// Token: 0x1700026D RID: 621
		// (get) Token: 0x06000C1A RID: 3098 RVA: 0x00030A82 File Offset: 0x0002EC82
		public EventModifiers modifiers { get; }

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x06000C1B RID: 3099 RVA: 0x00030A8A File Offset: 0x0002EC8A
		public Vector2 mousePosition { get; }

		// Token: 0x1700026F RID: 623
		// (get) Token: 0x06000C1C RID: 3100 RVA: 0x00030A92 File Offset: 0x0002EC92
		public Vector2 localMousePosition { get; }

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x06000C1D RID: 3101 RVA: 0x00030A9A File Offset: 0x0002EC9A
		private char character { get; }

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x06000C1E RID: 3102 RVA: 0x00030AA2 File Offset: 0x0002ECA2
		private KeyCode keyCode { get; }

		// Token: 0x06000C1F RID: 3103 RVA: 0x00030AAC File Offset: 0x0002ECAC
		public DropdownMenuEventInfo(EventBase e)
		{
			IMouseEvent mouseEvent = e as IMouseEvent;
			bool flag = mouseEvent != null;
			if (flag)
			{
				this.mousePosition = mouseEvent.mousePosition;
				this.localMousePosition = mouseEvent.localMousePosition;
				this.modifiers = mouseEvent.modifiers;
				this.character = 0;
				this.keyCode = 0;
			}
			else
			{
				IKeyboardEvent keyboardEvent = e as IKeyboardEvent;
				bool flag2 = keyboardEvent != null;
				if (flag2)
				{
					this.character = keyboardEvent.character;
					this.keyCode = keyboardEvent.keyCode;
					this.modifiers = keyboardEvent.modifiers;
					this.mousePosition = Vector2.zero;
					this.localMousePosition = Vector2.zero;
				}
			}
		}
	}
}
