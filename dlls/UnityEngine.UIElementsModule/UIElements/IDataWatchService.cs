using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200025E RID: 606
	[Obsolete("IDataWatchService is no longer supported and will be removed soon", true)]
	internal interface IDataWatchService
	{
		// Token: 0x06001154 RID: 4436
		IDataWatchHandle AddWatch(Object watched, Action<Object> onDataChanged);

		// Token: 0x06001155 RID: 4437
		void RemoveWatch(IDataWatchHandle handle);

		// Token: 0x06001156 RID: 4438
		void ForceDirtyNextPoll(Object obj);
	}
}
