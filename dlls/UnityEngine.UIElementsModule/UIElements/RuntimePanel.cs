using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000254 RID: 596
	internal class RuntimePanel : BaseRuntimePanel, IRuntimePanel
	{
		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x06001115 RID: 4373 RVA: 0x0003DAA8 File Offset: 0x0003BCA8
		public PanelSettings panelSettings
		{
			get
			{
				return this.m_PanelSettings;
			}
		}

		// Token: 0x06001116 RID: 4374 RVA: 0x0003DAB0 File Offset: 0x0003BCB0
		public static RuntimePanel Create(ScriptableObject ownerObject)
		{
			return new RuntimePanel(ownerObject);
		}

		// Token: 0x06001117 RID: 4375 RVA: 0x0003DAC8 File Offset: 0x0003BCC8
		private RuntimePanel(ScriptableObject ownerObject) : base(ownerObject, RuntimePanel.s_EventDispatcher)
		{
			this.focusController = new FocusController(new NavigateFocusRing(this.visualTree));
			this.m_PanelSettings = (ownerObject as PanelSettings);
			base.name = ((this.m_PanelSettings != null) ? this.m_PanelSettings.name : "RuntimePanel");
			this.visualTree.RegisterCallback<FocusEvent, RuntimePanel>(delegate(FocusEvent e, RuntimePanel p)
			{
				p.OnElementFocus(e);
			}, this, TrickleDown.TrickleDown);
		}

		// Token: 0x06001118 RID: 4376 RVA: 0x0003DB5C File Offset: 0x0003BD5C
		public override void Update()
		{
			bool flag = this.m_PanelSettings != null;
			if (flag)
			{
				this.m_PanelSettings.ApplyPanelSettings();
			}
			base.Update();
		}

		// Token: 0x06001119 RID: 4377 RVA: 0x0003DB8D File Offset: 0x0003BD8D
		private void OnElementFocus(FocusEvent evt)
		{
			UIElementsRuntimeUtility.defaultEventSystem.OnFocusEvent(this, evt);
		}

		// Token: 0x0400078B RID: 1931
		internal static readonly EventDispatcher s_EventDispatcher = RuntimeEventDispatcher.Create();

		// Token: 0x0400078C RID: 1932
		private readonly PanelSettings m_PanelSettings;
	}
}
