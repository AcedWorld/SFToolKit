using System;
using System.Collections.Generic;
using System.Reflection;

namespace UnityEngine.Rendering
{
	// Token: 0x0200005C RID: 92
	public abstract class DebugDisplaySettingsPanel : IDebugDisplaySettingsPanelDisposable, IDebugDisplaySettingsPanel, IDisposable
	{
		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060002EF RID: 751 RVA: 0x0000CB77 File Offset: 0x0000AD77
		public virtual string PanelName
		{
			get
			{
				DisplayInfoAttribute displayInfo = this.m_DisplayInfo;
				return ((displayInfo != null) ? displayInfo.name : null) ?? string.Empty;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060002F0 RID: 752 RVA: 0x0000CB94 File Offset: 0x0000AD94
		public virtual int Order
		{
			get
			{
				DisplayInfoAttribute displayInfo = this.m_DisplayInfo;
				if (displayInfo == null)
				{
					return 0;
				}
				return displayInfo.order;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060002F1 RID: 753 RVA: 0x0000CBA7 File Offset: 0x0000ADA7
		public DebugUI.Widget[] Widgets
		{
			get
			{
				return this.m_Widgets.ToArray();
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060002F2 RID: 754 RVA: 0x0000CBB4 File Offset: 0x0000ADB4
		public virtual DebugUI.Flags Flags
		{
			get
			{
				return DebugUI.Flags.None;
			}
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x0000CBB7 File Offset: 0x0000ADB7
		protected void AddWidget(DebugUI.Widget widget)
		{
			if (widget == null)
			{
				throw new ArgumentNullException("widget");
			}
			this.m_Widgets.Add(widget);
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x0000CBD3 File Offset: 0x0000ADD3
		protected void Clear()
		{
			this.m_Widgets.Clear();
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x0000CBE0 File Offset: 0x0000ADE0
		public void Dispose()
		{
			this.Clear();
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x0000CBE8 File Offset: 0x0000ADE8
		protected DebugDisplaySettingsPanel()
		{
			this.m_DisplayInfo = base.GetType().GetCustomAttribute<DisplayInfoAttribute>();
			if (this.m_DisplayInfo == null)
			{
				Debug.Log(string.Format("Type {0} should specify the attribute {1}", base.GetType(), "DisplayInfoAttribute"));
			}
		}

		// Token: 0x040001A9 RID: 425
		private readonly List<DebugUI.Widget> m_Widgets = new List<DebugUI.Widget>();

		// Token: 0x040001AA RID: 426
		private readonly DisplayInfoAttribute m_DisplayInfo;
	}
}
