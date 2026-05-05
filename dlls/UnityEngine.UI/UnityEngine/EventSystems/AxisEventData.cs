using System;

namespace UnityEngine.EventSystems
{
	// Token: 0x0200004D RID: 77
	public class AxisEventData : BaseEventData
	{
		// Token: 0x1700015E RID: 350
		// (get) Token: 0x0600052E RID: 1326 RVA: 0x00018072 File Offset: 0x00016272
		// (set) Token: 0x0600052F RID: 1327 RVA: 0x0001807A File Offset: 0x0001627A
		public Vector2 moveVector { get; set; }

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06000530 RID: 1328 RVA: 0x00018083 File Offset: 0x00016283
		// (set) Token: 0x06000531 RID: 1329 RVA: 0x0001808B File Offset: 0x0001628B
		public MoveDirection moveDir { get; set; }

		// Token: 0x06000532 RID: 1330 RVA: 0x00018094 File Offset: 0x00016294
		public AxisEventData(EventSystem eventSystem) : base(eventSystem)
		{
			this.moveVector = Vector2.zero;
			this.moveDir = MoveDirection.None;
		}
	}
}
