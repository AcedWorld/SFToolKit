using System;
using Michsky.UI.ModernUIPack;
using UnityEngine;

// Token: 0x0200020C RID: 524
public class ScooterFlowNotificationManager : MonoBehaviour
{
	// Token: 0x06000838 RID: 2104 RVA: 0x0003AD4E File Offset: 0x00038F4E
	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.Space))
		{
			this.SendNotification(this.type, "Testing");
		}
	}

	// Token: 0x06000839 RID: 2105 RVA: 0x0003AD6C File Offset: 0x00038F6C
	private string FormatNotificationType(NotificationType notificationType)
	{
		string text = notificationType.ToString();
		for (int i = 1; i < text.Length; i++)
		{
			if (char.IsUpper(text[i]))
			{
				text = text.Insert(i, " ");
				i++;
			}
		}
		return text;
	}

	// Token: 0x0600083A RID: 2106 RVA: 0x0003ADB8 File Offset: 0x00038FB8
	public void SendNotification(NotificationType notificationType, string message)
	{
		foreach (NotificationReferences notificationReferences in this.notifications)
		{
			if (notificationReferences.title == notificationType)
			{
				this.notificationManager.icon = notificationReferences.icon;
				this.notificationManager.title = this.FormatNotificationType(notificationType);
				this.notificationManager.description = message;
				this.notificationManager.UpdateUI();
				this.notificationManager.OpenNotification();
				return;
			}
		}
	}

	// Token: 0x04000E7A RID: 3706
	public NotificationManager notificationManager;

	// Token: 0x04000E7B RID: 3707
	public NotificationReferences[] notifications;

	// Token: 0x04000E7C RID: 3708
	public NotificationType type;
}
