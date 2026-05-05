using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication
{
	// Token: 0x02000034 RID: 52
	[Serializable]
	internal class GetNotificationsResponse
	{
		// Token: 0x06000175 RID: 373 RVA: 0x000050E3 File Offset: 0x000032E3
		[Preserve]
		public GetNotificationsResponse()
		{
		}

		// Token: 0x06000176 RID: 374 RVA: 0x000050EC File Offset: 0x000032EC
		public List<Notification> ToNotificationList()
		{
			if (this.Notifications.Count < 1)
			{
				return null;
			}
			List<Notification> list = new List<Notification>();
			foreach (NotificationResponse notificationResponse in this.Notifications)
			{
				list.Add(new Notification
				{
					Id = notificationResponse.Id,
					CaseId = notificationResponse.CaseId,
					CreatedAt = notificationResponse.CreatedAt,
					Message = notificationResponse.Message,
					PlayerId = notificationResponse.PlayerId,
					ProjectId = notificationResponse.ProjectId,
					Type = notificationResponse.Type
				});
			}
			return list;
		}

		// Token: 0x04000098 RID: 152
		[JsonProperty("notifications")]
		public List<NotificationResponse> Notifications;
	}
}
