using System;
using Michsky.UI.ModernUIPack;
using UnityEngine;

// Token: 0x02000216 RID: 534
public class TestNotif : MonoBehaviour
{
	// Token: 0x06000870 RID: 2160 RVA: 0x000020BE File Offset: 0x000002BE
	private void Start()
	{
	}

	// Token: 0x06000871 RID: 2161 RVA: 0x0003B4FF File Offset: 0x000396FF
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			this.notificationManager.OpenNotification();
		}
	}

	// Token: 0x04000EA7 RID: 3751
	public NotificationManager notificationManager;
}
