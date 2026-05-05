using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000273 RID: 627
	public struct ManipulatorActivationFilter : IEquatable<ManipulatorActivationFilter>
	{
		// Token: 0x170003BC RID: 956
		// (get) Token: 0x060011C3 RID: 4547 RVA: 0x0004081A File Offset: 0x0003EA1A
		// (set) Token: 0x060011C4 RID: 4548 RVA: 0x00040822 File Offset: 0x0003EA22
		public MouseButton button { readonly get; set; }

		// Token: 0x170003BD RID: 957
		// (get) Token: 0x060011C5 RID: 4549 RVA: 0x0004082B File Offset: 0x0003EA2B
		// (set) Token: 0x060011C6 RID: 4550 RVA: 0x00040833 File Offset: 0x0003EA33
		public EventModifiers modifiers { readonly get; set; }

		// Token: 0x170003BE RID: 958
		// (get) Token: 0x060011C7 RID: 4551 RVA: 0x0004083C File Offset: 0x0003EA3C
		// (set) Token: 0x060011C8 RID: 4552 RVA: 0x00040844 File Offset: 0x0003EA44
		public int clickCount { readonly get; set; }

		// Token: 0x060011C9 RID: 4553 RVA: 0x00040850 File Offset: 0x0003EA50
		public override bool Equals(object obj)
		{
			return obj is ManipulatorActivationFilter && this.Equals((ManipulatorActivationFilter)obj);
		}

		// Token: 0x060011CA RID: 4554 RVA: 0x0004087C File Offset: 0x0003EA7C
		public bool Equals(ManipulatorActivationFilter other)
		{
			return this.button == other.button && this.modifiers == other.modifiers && this.clickCount == other.clickCount;
		}

		// Token: 0x060011CB RID: 4555 RVA: 0x000408C0 File Offset: 0x0003EAC0
		public override int GetHashCode()
		{
			int num = 390957112;
			num = num * -1521134295 + this.button.GetHashCode();
			num = num * -1521134295 + this.modifiers.GetHashCode();
			return num * -1521134295 + this.clickCount.GetHashCode();
		}

		// Token: 0x060011CC RID: 4556 RVA: 0x0004092C File Offset: 0x0003EB2C
		public bool Matches(IMouseEvent e)
		{
			bool flag = e == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this.clickCount == 0 || e.clickCount >= this.clickCount;
				result = (this.button == (MouseButton)e.button && this.HasModifiers(e) && flag2);
			}
			return result;
		}

		// Token: 0x060011CD RID: 4557 RVA: 0x00040984 File Offset: 0x0003EB84
		private bool HasModifiers(IMouseEvent e)
		{
			bool flag = e == null;
			return !flag && this.MatchModifiers(e.altKey, e.ctrlKey, e.shiftKey, e.commandKey);
		}

		// Token: 0x060011CE RID: 4558 RVA: 0x000409C0 File Offset: 0x0003EBC0
		public bool Matches(IPointerEvent e)
		{
			bool flag = e == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this.clickCount == 0 || e.clickCount >= this.clickCount;
				result = (this.button == (MouseButton)e.button && this.HasModifiers(e) && flag2);
			}
			return result;
		}

		// Token: 0x060011CF RID: 4559 RVA: 0x00040A18 File Offset: 0x0003EC18
		private bool HasModifiers(IPointerEvent e)
		{
			bool flag = e == null;
			return !flag && this.MatchModifiers(e.altKey, e.ctrlKey, e.shiftKey, e.commandKey);
		}

		// Token: 0x060011D0 RID: 4560 RVA: 0x00040A54 File Offset: 0x0003EC54
		private bool MatchModifiers(bool alt, bool ctrl, bool shift, bool command)
		{
			bool flag = ((this.modifiers & EventModifiers.Alt) != EventModifiers.None && !alt) || ((this.modifiers & EventModifiers.Alt) == EventModifiers.None && alt);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = ((this.modifiers & EventModifiers.Control) != EventModifiers.None && !ctrl) || ((this.modifiers & EventModifiers.Control) == EventModifiers.None && ctrl);
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = ((this.modifiers & EventModifiers.Shift) != EventModifiers.None && !shift) || ((this.modifiers & EventModifiers.Shift) == EventModifiers.None && shift);
					result = (!flag3 && ((this.modifiers & EventModifiers.Command) == EventModifiers.None || command) && ((this.modifiers & EventModifiers.Command) != EventModifiers.None || !command));
				}
			}
			return result;
		}

		// Token: 0x060011D1 RID: 4561 RVA: 0x00040B00 File Offset: 0x0003ED00
		public static bool operator ==(ManipulatorActivationFilter filter1, ManipulatorActivationFilter filter2)
		{
			return filter1.Equals(filter2);
		}

		// Token: 0x060011D2 RID: 4562 RVA: 0x00040B1C File Offset: 0x0003ED1C
		public static bool operator !=(ManipulatorActivationFilter filter1, ManipulatorActivationFilter filter2)
		{
			return !(filter1 == filter2);
		}
	}
}
