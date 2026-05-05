using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001D2 RID: 466
	public class InputEvent : EventBase<InputEvent>
	{
		// Token: 0x06000E17 RID: 3607 RVA: 0x000366D5 File Offset: 0x000348D5
		static InputEvent()
		{
			EventBase<InputEvent>.SetCreateFunction(() => new InputEvent());
		}

		// Token: 0x170002E2 RID: 738
		// (get) Token: 0x06000E18 RID: 3608 RVA: 0x000366EE File Offset: 0x000348EE
		// (set) Token: 0x06000E19 RID: 3609 RVA: 0x000366F6 File Offset: 0x000348F6
		public string previousData { get; protected set; }

		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x06000E1A RID: 3610 RVA: 0x000366FF File Offset: 0x000348FF
		// (set) Token: 0x06000E1B RID: 3611 RVA: 0x00036707 File Offset: 0x00034907
		public string newData { get; protected set; }

		// Token: 0x06000E1C RID: 3612 RVA: 0x00036710 File Offset: 0x00034910
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06000E1D RID: 3613 RVA: 0x00036721 File Offset: 0x00034921
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.Bubbles | EventBase.EventPropagation.TricklesDown);
			this.previousData = null;
			this.newData = null;
		}

		// Token: 0x06000E1E RID: 3614 RVA: 0x0003673C File Offset: 0x0003493C
		public static InputEvent GetPooled(string previousData, string newData)
		{
			InputEvent pooled = EventBase<InputEvent>.GetPooled();
			pooled.previousData = previousData;
			pooled.newData = newData;
			return pooled;
		}

		// Token: 0x06000E1F RID: 3615 RVA: 0x00036765 File Offset: 0x00034965
		public InputEvent()
		{
			this.LocalInit();
		}
	}
}
