using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200040B RID: 1035
	internal class VisualElementPanelActivator
	{
		// Token: 0x170007AA RID: 1962
		// (get) Token: 0x0600210B RID: 8459 RVA: 0x0007CF5C File Offset: 0x0007B15C
		// (set) Token: 0x0600210C RID: 8460 RVA: 0x0007CF64 File Offset: 0x0007B164
		public bool isActive { get; private set; }

		// Token: 0x170007AB RID: 1963
		// (get) Token: 0x0600210D RID: 8461 RVA: 0x0007CF6D File Offset: 0x0007B16D
		// (set) Token: 0x0600210E RID: 8462 RVA: 0x0007CF75 File Offset: 0x0007B175
		public bool isDetaching { get; private set; }

		// Token: 0x0600210F RID: 8463 RVA: 0x0007CF7E File Offset: 0x0007B17E
		public VisualElementPanelActivator(IVisualElementPanelActivatable activatable)
		{
			this.m_Activatable = activatable;
			this.m_OnAttachToPanelCallback = new EventCallback<AttachToPanelEvent>(this.OnEnter);
			this.m_OnDetachFromPanelCallback = new EventCallback<DetachFromPanelEvent>(this.OnLeave);
		}

		// Token: 0x06002110 RID: 8464 RVA: 0x0007CFB4 File Offset: 0x0007B1B4
		public void SetActive(bool action)
		{
			bool flag = this.isActive != action;
			if (flag)
			{
				this.isActive = action;
				bool isActive = this.isActive;
				if (isActive)
				{
					this.m_Activatable.element.RegisterCallback<AttachToPanelEvent>(this.m_OnAttachToPanelCallback, TrickleDown.NoTrickleDown);
					this.m_Activatable.element.RegisterCallback<DetachFromPanelEvent>(this.m_OnDetachFromPanelCallback, TrickleDown.NoTrickleDown);
					this.SendActivation();
				}
				else
				{
					this.m_Activatable.element.UnregisterCallback<AttachToPanelEvent>(this.m_OnAttachToPanelCallback, TrickleDown.NoTrickleDown);
					this.m_Activatable.element.UnregisterCallback<DetachFromPanelEvent>(this.m_OnDetachFromPanelCallback, TrickleDown.NoTrickleDown);
					this.SendDeactivation();
				}
			}
		}

		// Token: 0x06002111 RID: 8465 RVA: 0x0007D060 File Offset: 0x0007B260
		public void SendActivation()
		{
			bool flag = this.m_Activatable.CanBeActivated();
			if (flag)
			{
				this.m_Activatable.OnPanelActivate();
			}
		}

		// Token: 0x06002112 RID: 8466 RVA: 0x0007D08C File Offset: 0x0007B28C
		public void SendDeactivation()
		{
			bool flag = this.m_Activatable.CanBeActivated();
			if (flag)
			{
				this.m_Activatable.OnPanelDeactivate();
			}
		}

		// Token: 0x06002113 RID: 8467 RVA: 0x0007D0B8 File Offset: 0x0007B2B8
		private void OnEnter(AttachToPanelEvent evt)
		{
			bool isActive = this.isActive;
			if (isActive)
			{
				this.SendActivation();
			}
		}

		// Token: 0x06002114 RID: 8468 RVA: 0x0007D0DC File Offset: 0x0007B2DC
		private void OnLeave(DetachFromPanelEvent evt)
		{
			bool isActive = this.isActive;
			if (isActive)
			{
				this.isDetaching = true;
				try
				{
					this.SendDeactivation();
				}
				finally
				{
					this.isDetaching = false;
				}
			}
		}

		// Token: 0x04000DF7 RID: 3575
		private IVisualElementPanelActivatable m_Activatable;

		// Token: 0x04000DFA RID: 3578
		private EventCallback<AttachToPanelEvent> m_OnAttachToPanelCallback;

		// Token: 0x04000DFB RID: 3579
		private EventCallback<DetachFromPanelEvent> m_OnDetachFromPanelCallback;
	}
}
