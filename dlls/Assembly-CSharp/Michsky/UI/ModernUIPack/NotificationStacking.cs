using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x02000311 RID: 785
	[AddComponentMenu("Modern UI Pack/Notification/Notification Stacking")]
	public class NotificationStacking : MonoBehaviour
	{
		// Token: 0x06001067 RID: 4199 RVA: 0x00057A20 File Offset: 0x00055C20
		private void Update()
		{
			if (this.enableUpdating)
			{
				try
				{
					this.notifications[this.currentNotification].gameObject.SetActive(true);
					if (this.notifications[this.currentNotification].notificationAnimator.GetCurrentAnimatorStateInfo(0).IsName("Wait"))
					{
						this.notifications[this.currentNotification].OpenNotification();
						base.StartCoroutine("StartNotification");
						this.enableUpdating = false;
					}
					if (this.currentNotification >= this.notifications.Count)
					{
						this.enableUpdating = false;
						this.currentNotification = 0;
					}
				}
				catch
				{
					this.enableUpdating = false;
					this.currentNotification = 0;
					this.notifications.Clear();
				}
			}
		}

		// Token: 0x06001068 RID: 4200 RVA: 0x00057AF8 File Offset: 0x00055CF8
		private IEnumerator StartNotification()
		{
			yield return new WaitForSeconds(this.notifications[this.currentNotification].timer + this.delay);
			Object.Destroy(this.notifications[this.currentNotification].gameObject);
			this.enableUpdating = true;
			this.currentNotification++;
			base.StopCoroutine("StartNotification");
			yield break;
		}

		// Token: 0x0400159F RID: 5535
		public List<NotificationManager> notifications = new List<NotificationManager>();

		// Token: 0x040015A0 RID: 5536
		[HideInInspector]
		public bool enableUpdating;

		// Token: 0x040015A1 RID: 5537
		[Header("SETTINGS")]
		public float delay = 1f;

		// Token: 0x040015A2 RID: 5538
		private int currentNotification;
	}
}
