using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000196 RID: 406
	[EventCategory(EventCategory.ChangeValue)]
	public class ChangeEvent<T> : EventBase<ChangeEvent<T>>, IChangeEvent
	{
		// Token: 0x06000C7D RID: 3197 RVA: 0x00031B45 File Offset: 0x0002FD45
		static ChangeEvent()
		{
			EventBase<ChangeEvent<T>>.SetCreateFunction(() => new ChangeEvent<T>());
		}

		// Token: 0x1700027F RID: 639
		// (get) Token: 0x06000C7E RID: 3198 RVA: 0x00031B5E File Offset: 0x0002FD5E
		// (set) Token: 0x06000C7F RID: 3199 RVA: 0x00031B66 File Offset: 0x0002FD66
		public T previousValue { get; protected set; }

		// Token: 0x17000280 RID: 640
		// (get) Token: 0x06000C80 RID: 3200 RVA: 0x00031B6F File Offset: 0x0002FD6F
		// (set) Token: 0x06000C81 RID: 3201 RVA: 0x00031B77 File Offset: 0x0002FD77
		public T newValue { get; protected set; }

		// Token: 0x06000C82 RID: 3202 RVA: 0x00031B80 File Offset: 0x0002FD80
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06000C83 RID: 3203 RVA: 0x00031B94 File Offset: 0x0002FD94
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.Bubbles | EventBase.EventPropagation.TricklesDown);
			this.previousValue = default(T);
			this.newValue = default(T);
		}

		// Token: 0x06000C84 RID: 3204 RVA: 0x00031BCC File Offset: 0x0002FDCC
		public static ChangeEvent<T> GetPooled(T previousValue, T newValue)
		{
			ChangeEvent<T> pooled = EventBase<ChangeEvent<T>>.GetPooled();
			pooled.previousValue = previousValue;
			pooled.newValue = newValue;
			return pooled;
		}

		// Token: 0x06000C85 RID: 3205 RVA: 0x00031BF5 File Offset: 0x0002FDF5
		public ChangeEvent()
		{
			this.LocalInit();
		}
	}
}
