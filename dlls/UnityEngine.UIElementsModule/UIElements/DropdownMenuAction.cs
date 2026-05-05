using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200017C RID: 380
	public class DropdownMenuAction : DropdownMenuItem
	{
		// Token: 0x17000273 RID: 627
		// (get) Token: 0x06000C23 RID: 3107 RVA: 0x00030B6C File Offset: 0x0002ED6C
		public string name { get; }

		// Token: 0x17000274 RID: 628
		// (get) Token: 0x06000C24 RID: 3108 RVA: 0x00030B74 File Offset: 0x0002ED74
		// (set) Token: 0x06000C25 RID: 3109 RVA: 0x00030B7C File Offset: 0x0002ED7C
		public DropdownMenuAction.Status status { get; private set; }

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x06000C26 RID: 3110 RVA: 0x00030B85 File Offset: 0x0002ED85
		// (set) Token: 0x06000C27 RID: 3111 RVA: 0x00030B8D File Offset: 0x0002ED8D
		public DropdownMenuEventInfo eventInfo { get; private set; }

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x06000C28 RID: 3112 RVA: 0x00030B96 File Offset: 0x0002ED96
		// (set) Token: 0x06000C29 RID: 3113 RVA: 0x00030B9E File Offset: 0x0002ED9E
		public object userData { get; private set; }

		// Token: 0x06000C2A RID: 3114 RVA: 0x00030BA8 File Offset: 0x0002EDA8
		public static DropdownMenuAction.Status AlwaysEnabled(DropdownMenuAction a)
		{
			return DropdownMenuAction.Status.Normal;
		}

		// Token: 0x06000C2B RID: 3115 RVA: 0x00030BBC File Offset: 0x0002EDBC
		public static DropdownMenuAction.Status AlwaysDisabled(DropdownMenuAction a)
		{
			return DropdownMenuAction.Status.Disabled;
		}

		// Token: 0x06000C2C RID: 3116 RVA: 0x00030BCF File Offset: 0x0002EDCF
		public DropdownMenuAction(string actionName, Action<DropdownMenuAction> actionCallback, Func<DropdownMenuAction, DropdownMenuAction.Status> actionStatusCallback, object userData = null)
		{
			this.name = actionName;
			this.actionCallback = actionCallback;
			this.actionStatusCallback = actionStatusCallback;
			this.userData = userData;
		}

		// Token: 0x06000C2D RID: 3117 RVA: 0x00030BF7 File Offset: 0x0002EDF7
		public void UpdateActionStatus(DropdownMenuEventInfo eventInfo)
		{
			this.eventInfo = eventInfo;
			Func<DropdownMenuAction, DropdownMenuAction.Status> func = this.actionStatusCallback;
			this.status = ((func != null) ? func(this) : DropdownMenuAction.Status.Hidden);
		}

		// Token: 0x06000C2E RID: 3118 RVA: 0x00030C1C File Offset: 0x0002EE1C
		public void Execute()
		{
			Action<DropdownMenuAction> action = this.actionCallback;
			if (action != null)
			{
				action(this);
			}
		}

		// Token: 0x040005C7 RID: 1479
		private readonly Action<DropdownMenuAction> actionCallback;

		// Token: 0x040005C8 RID: 1480
		private readonly Func<DropdownMenuAction, DropdownMenuAction.Status> actionStatusCallback;

		// Token: 0x0200017D RID: 381
		[Flags]
		public enum Status
		{
			// Token: 0x040005CA RID: 1482
			None = 0,
			// Token: 0x040005CB RID: 1483
			Normal = 1,
			// Token: 0x040005CC RID: 1484
			Disabled = 2,
			// Token: 0x040005CD RID: 1485
			Checked = 4,
			// Token: 0x040005CE RID: 1486
			Hidden = 8
		}
	}
}
