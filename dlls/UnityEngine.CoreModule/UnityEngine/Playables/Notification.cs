using System;

namespace UnityEngine.Playables
{
	// Token: 0x02000497 RID: 1175
	public class Notification : INotification
	{
		// Token: 0x06002867 RID: 10343 RVA: 0x000453C9 File Offset: 0x000435C9
		public Notification(string name)
		{
			this.id = new PropertyName(name);
		}

		// Token: 0x17000796 RID: 1942
		// (get) Token: 0x06002868 RID: 10344 RVA: 0x000453DF File Offset: 0x000435DF
		public PropertyName id { get; }
	}
}
