using System;

namespace UnityEngine
{
	// Token: 0x02000007 RID: 7
	internal struct EventInterests
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000053 RID: 83 RVA: 0x00003752 File Offset: 0x00001952
		// (set) Token: 0x06000054 RID: 84 RVA: 0x0000375A File Offset: 0x0000195A
		public bool wantsMouseMove { readonly get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00003763 File Offset: 0x00001963
		// (set) Token: 0x06000056 RID: 86 RVA: 0x0000376B File Offset: 0x0000196B
		public bool wantsMouseEnterLeaveWindow { readonly get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00003774 File Offset: 0x00001974
		// (set) Token: 0x06000058 RID: 88 RVA: 0x0000377C File Offset: 0x0000197C
		public bool wantsLessLayoutEvents { readonly get; set; }

		// Token: 0x06000059 RID: 89 RVA: 0x00003788 File Offset: 0x00001988
		public bool WantsEvent(EventType type)
		{
			bool result;
			if (type != EventType.MouseMove)
			{
				result = (type - EventType.MouseEnterWindow > 1 || this.wantsMouseEnterLeaveWindow);
			}
			else
			{
				result = this.wantsMouseMove;
			}
			return result;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x000037C0 File Offset: 0x000019C0
		public bool WantsLayoutPass(EventType type)
		{
			bool flag = !this.wantsLessLayoutEvents;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				switch (type)
				{
				case EventType.MouseDown:
				case EventType.MouseUp:
					return this.wantsMouseMove;
				case EventType.MouseMove:
				case EventType.MouseDrag:
				case EventType.ScrollWheel:
					goto IL_6C;
				case EventType.KeyDown:
				case EventType.KeyUp:
					return GUIUtility.textFieldInput;
				case EventType.Repaint:
					break;
				default:
					if (type != EventType.ExecuteCommand)
					{
						if (type - EventType.MouseEnterWindow > 1)
						{
							goto IL_6C;
						}
						return this.wantsMouseEnterLeaveWindow;
					}
					break;
				}
				return true;
				IL_6C:
				result = false;
			}
			return result;
		}
	}
}
