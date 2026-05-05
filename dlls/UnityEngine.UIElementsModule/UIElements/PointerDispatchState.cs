using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200029E RID: 670
	internal class PointerDispatchState
	{
		// Token: 0x06001333 RID: 4915 RVA: 0x00042EFC File Offset: 0x000410FC
		public PointerDispatchState()
		{
			this.Reset();
		}

		// Token: 0x06001334 RID: 4916 RVA: 0x00042F48 File Offset: 0x00041148
		internal void Reset()
		{
			for (int i = 0; i < this.m_PointerCapture.Length; i++)
			{
				this.m_PendingPointerCapture[i] = null;
				this.m_PointerCapture[i] = null;
				this.m_ShouldSendCompatibilityMouseEvents[i] = true;
			}
		}

		// Token: 0x06001335 RID: 4917 RVA: 0x00042F8C File Offset: 0x0004118C
		public IEventHandler GetCapturingElement(int pointerId)
		{
			return this.m_PendingPointerCapture[pointerId];
		}

		// Token: 0x06001336 RID: 4918 RVA: 0x00042FA8 File Offset: 0x000411A8
		public bool HasPointerCapture(IEventHandler handler, int pointerId)
		{
			return this.m_PendingPointerCapture[pointerId] == handler;
		}

		// Token: 0x06001337 RID: 4919 RVA: 0x00042FC8 File Offset: 0x000411C8
		public void CapturePointer(IEventHandler handler, int pointerId)
		{
			bool flag = pointerId == PointerId.mousePointerId && this.m_PendingPointerCapture[pointerId] != handler && GUIUtility.hotControl != 0;
			if (flag)
			{
				GUIUtility.hotControl = 0;
			}
			this.m_PendingPointerCapture[pointerId] = handler;
		}

		// Token: 0x06001338 RID: 4920 RVA: 0x0004300A File Offset: 0x0004120A
		public void ReleasePointer(int pointerId)
		{
			this.m_PendingPointerCapture[pointerId] = null;
		}

		// Token: 0x06001339 RID: 4921 RVA: 0x00043018 File Offset: 0x00041218
		public void ReleasePointer(IEventHandler handler, int pointerId)
		{
			bool flag = handler == this.m_PendingPointerCapture[pointerId];
			if (flag)
			{
				this.m_PendingPointerCapture[pointerId] = null;
			}
		}

		// Token: 0x0600133A RID: 4922 RVA: 0x00043040 File Offset: 0x00041240
		public void ProcessPointerCapture(int pointerId)
		{
			bool flag = this.m_PointerCapture[pointerId] == this.m_PendingPointerCapture[pointerId];
			if (!flag)
			{
				bool flag2 = this.m_PointerCapture[pointerId] != null;
				if (flag2)
				{
					using (PointerCaptureOutEvent pooled = PointerCaptureEventBase<PointerCaptureOutEvent>.GetPooled(this.m_PointerCapture[pointerId], this.m_PendingPointerCapture[pointerId], pointerId))
					{
						this.m_PointerCapture[pointerId].SendEvent(pooled);
					}
					bool flag3 = pointerId == PointerId.mousePointerId;
					if (flag3)
					{
						using (MouseCaptureOutEvent pooled2 = PointerCaptureEventBase<MouseCaptureOutEvent>.GetPooled(this.m_PointerCapture[pointerId], this.m_PendingPointerCapture[pointerId], pointerId))
						{
							this.m_PointerCapture[pointerId].SendEvent(pooled2);
						}
					}
				}
				bool flag4 = this.m_PendingPointerCapture[pointerId] != null;
				if (flag4)
				{
					using (PointerCaptureEvent pooled3 = PointerCaptureEventBase<PointerCaptureEvent>.GetPooled(this.m_PendingPointerCapture[pointerId], this.m_PointerCapture[pointerId], pointerId))
					{
						this.m_PendingPointerCapture[pointerId].SendEvent(pooled3);
					}
					bool flag5 = pointerId == PointerId.mousePointerId;
					if (flag5)
					{
						using (MouseCaptureEvent pooled4 = PointerCaptureEventBase<MouseCaptureEvent>.GetPooled(this.m_PendingPointerCapture[pointerId], this.m_PointerCapture[pointerId], pointerId))
						{
							this.m_PendingPointerCapture[pointerId].SendEvent(pooled4);
						}
					}
				}
				this.m_PointerCapture[pointerId] = this.m_PendingPointerCapture[pointerId];
			}
		}

		// Token: 0x0600133B RID: 4923 RVA: 0x000431D4 File Offset: 0x000413D4
		public void ActivateCompatibilityMouseEvents(int pointerId)
		{
			this.m_ShouldSendCompatibilityMouseEvents[pointerId] = true;
		}

		// Token: 0x0600133C RID: 4924 RVA: 0x000431E0 File Offset: 0x000413E0
		public void PreventCompatibilityMouseEvents(int pointerId)
		{
			this.m_ShouldSendCompatibilityMouseEvents[pointerId] = false;
		}

		// Token: 0x0600133D RID: 4925 RVA: 0x000431EC File Offset: 0x000413EC
		public bool ShouldSendCompatibilityMouseEvents(IPointerEvent evt)
		{
			return evt.isPrimary && this.m_ShouldSendCompatibilityMouseEvents[evt.pointerId];
		}

		// Token: 0x040008B5 RID: 2229
		private IEventHandler[] m_PendingPointerCapture = new IEventHandler[PointerId.maxPointers];

		// Token: 0x040008B6 RID: 2230
		private IEventHandler[] m_PointerCapture = new IEventHandler[PointerId.maxPointers];

		// Token: 0x040008B7 RID: 2231
		private bool[] m_ShouldSendCompatibilityMouseEvents = new bool[PointerId.maxPointers];
	}
}
