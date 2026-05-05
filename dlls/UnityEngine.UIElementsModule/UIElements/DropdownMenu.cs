using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x0200017E RID: 382
	public class DropdownMenu
	{
		// Token: 0x06000C2F RID: 3119 RVA: 0x00030C34 File Offset: 0x0002EE34
		public List<DropdownMenuItem> MenuItems()
		{
			return this.m_MenuItems;
		}

		// Token: 0x06000C30 RID: 3120 RVA: 0x00030C4C File Offset: 0x0002EE4C
		public void AppendAction(string actionName, Action<DropdownMenuAction> action, Func<DropdownMenuAction, DropdownMenuAction.Status> actionStatusCallback, object userData = null)
		{
			DropdownMenuAction item = new DropdownMenuAction(actionName, action, actionStatusCallback, userData);
			this.m_MenuItems.Add(item);
		}

		// Token: 0x06000C31 RID: 3121 RVA: 0x00030C74 File Offset: 0x0002EE74
		public void AppendAction(string actionName, Action<DropdownMenuAction> action, DropdownMenuAction.Status status = DropdownMenuAction.Status.Normal)
		{
			bool flag = status == DropdownMenuAction.Status.Normal;
			if (flag)
			{
				this.AppendAction(actionName, action, new Func<DropdownMenuAction, DropdownMenuAction.Status>(DropdownMenuAction.AlwaysEnabled), null);
			}
			else
			{
				bool flag2 = status == DropdownMenuAction.Status.Disabled;
				if (flag2)
				{
					this.AppendAction(actionName, action, new Func<DropdownMenuAction, DropdownMenuAction.Status>(DropdownMenuAction.AlwaysDisabled), null);
				}
				else
				{
					this.AppendAction(actionName, action, (DropdownMenuAction e) => status, null);
				}
			}
		}

		// Token: 0x06000C32 RID: 3122 RVA: 0x00030CF8 File Offset: 0x0002EEF8
		public void InsertAction(int atIndex, string actionName, Action<DropdownMenuAction> action, Func<DropdownMenuAction, DropdownMenuAction.Status> actionStatusCallback, object userData = null)
		{
			DropdownMenuAction item = new DropdownMenuAction(actionName, action, actionStatusCallback, userData);
			this.m_MenuItems.Insert(atIndex, item);
		}

		// Token: 0x06000C33 RID: 3123 RVA: 0x00030D20 File Offset: 0x0002EF20
		public void InsertAction(int atIndex, string actionName, Action<DropdownMenuAction> action, DropdownMenuAction.Status status = DropdownMenuAction.Status.Normal)
		{
			bool flag = status == DropdownMenuAction.Status.Normal;
			if (flag)
			{
				this.InsertAction(atIndex, actionName, action, new Func<DropdownMenuAction, DropdownMenuAction.Status>(DropdownMenuAction.AlwaysEnabled), null);
			}
			else
			{
				bool flag2 = status == DropdownMenuAction.Status.Disabled;
				if (flag2)
				{
					this.InsertAction(atIndex, actionName, action, new Func<DropdownMenuAction, DropdownMenuAction.Status>(DropdownMenuAction.AlwaysDisabled), null);
				}
				else
				{
					this.InsertAction(atIndex, actionName, action, (DropdownMenuAction e) => status, null);
				}
			}
		}

		// Token: 0x06000C34 RID: 3124 RVA: 0x00030DA8 File Offset: 0x0002EFA8
		public void AppendSeparator(string subMenuPath = null)
		{
			bool flag = this.m_MenuItems.Count > 0 && !(this.m_MenuItems[this.m_MenuItems.Count - 1] is DropdownMenuSeparator);
			if (flag)
			{
				DropdownMenuSeparator item = new DropdownMenuSeparator(subMenuPath ?? string.Empty);
				this.m_MenuItems.Add(item);
			}
		}

		// Token: 0x06000C35 RID: 3125 RVA: 0x00030E10 File Offset: 0x0002F010
		public void InsertSeparator(string subMenuPath, int atIndex)
		{
			bool flag = atIndex > 0 && atIndex <= this.m_MenuItems.Count && !(this.m_MenuItems[atIndex - 1] is DropdownMenuSeparator);
			if (flag)
			{
				DropdownMenuSeparator item = new DropdownMenuSeparator(subMenuPath ?? string.Empty);
				this.m_MenuItems.Insert(atIndex, item);
			}
		}

		// Token: 0x06000C36 RID: 3126 RVA: 0x00030E70 File Offset: 0x0002F070
		public void RemoveItemAt(int index)
		{
			this.m_MenuItems.RemoveAt(index);
		}

		// Token: 0x06000C37 RID: 3127 RVA: 0x00030E80 File Offset: 0x0002F080
		public void ClearItems()
		{
			this.m_MenuItems.Clear();
		}

		// Token: 0x06000C38 RID: 3128 RVA: 0x00030E90 File Offset: 0x0002F090
		public void PrepareForDisplay(EventBase e)
		{
			this.m_DropdownMenuEventInfo = ((e != null) ? new DropdownMenuEventInfo(e) : null);
			bool flag = this.m_MenuItems.Count == 0;
			if (!flag)
			{
				foreach (DropdownMenuItem dropdownMenuItem in this.m_MenuItems)
				{
					DropdownMenuAction dropdownMenuAction = dropdownMenuItem as DropdownMenuAction;
					bool flag2 = dropdownMenuAction != null;
					if (flag2)
					{
						dropdownMenuAction.UpdateActionStatus(this.m_DropdownMenuEventInfo);
					}
				}
				bool flag3 = this.m_MenuItems[this.m_MenuItems.Count - 1] is DropdownMenuSeparator;
				if (flag3)
				{
					this.m_MenuItems.RemoveAt(this.m_MenuItems.Count - 1);
				}
			}
		}

		// Token: 0x040005CF RID: 1487
		private List<DropdownMenuItem> m_MenuItems = new List<DropdownMenuItem>();

		// Token: 0x040005D0 RID: 1488
		private DropdownMenuEventInfo m_DropdownMenuEventInfo;
	}
}
