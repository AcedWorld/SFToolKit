using System;
using UnityEngine.Scripting;

namespace UnityEngine.Playables
{
	// Token: 0x02000493 RID: 1171
	[RequiredByNativeCode]
	public interface INotificationReceiver
	{
		// Token: 0x0600285C RID: 10332
		[RequiredByNativeCode]
		void OnNotify(Playable origin, INotification notification, object context);
	}
}
