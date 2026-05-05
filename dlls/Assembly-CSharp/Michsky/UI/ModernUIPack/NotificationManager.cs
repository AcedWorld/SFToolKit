using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x0200030D RID: 781
	public class NotificationManager : MonoBehaviour
	{
		// Token: 0x06001054 RID: 4180 RVA: 0x0005777C File Offset: 0x0005597C
		private void Start()
		{
			try
			{
				if (this.notificationAnimator == null)
				{
					this.notificationAnimator = base.gameObject.GetComponent<Animator>();
				}
				if (!this.useCustomContent)
				{
					this.iconObj.sprite = this.icon;
					this.titleObj.text = this.title;
					this.descriptionObj.text = this.description;
				}
			}
			catch
			{
				Debug.LogError("Notification - Cannot initalize the object due to missing components.", this);
			}
			if (this.useStacking)
			{
				try
				{
					NotificationStacking componentInParent = base.transform.GetComponentInParent<NotificationStacking>();
					componentInParent.notifications.Add(this);
					componentInParent.enableUpdating = true;
					base.gameObject.SetActive(false);
				}
				catch
				{
				}
			}
		}

		// Token: 0x06001055 RID: 4181 RVA: 0x00057848 File Offset: 0x00055A48
		private IEnumerator StartTimer()
		{
			yield return new WaitForSecondsRealtime(this.timer);
			this.CloseNotification();
			yield break;
		}

		// Token: 0x06001056 RID: 4182 RVA: 0x00057857 File Offset: 0x00055A57
		private IEnumerator DestroyNotification()
		{
			yield return new WaitForSeconds(1f);
			Object.Destroy(base.gameObject);
			yield break;
		}

		// Token: 0x06001057 RID: 4183 RVA: 0x00057866 File Offset: 0x00055A66
		public void OpenNotification()
		{
			this.notificationAnimator.Play("In");
			if (this.enableTimer)
			{
				base.StartCoroutine("StartTimer");
			}
		}

		// Token: 0x06001058 RID: 4184 RVA: 0x0005788C File Offset: 0x00055A8C
		public void CloseNotification()
		{
			this.notificationAnimator.Play("Out");
			if (this.destroyAfterPlaying)
			{
				base.StartCoroutine("DestroyNotification");
			}
		}

		// Token: 0x06001059 RID: 4185 RVA: 0x000578B4 File Offset: 0x00055AB4
		public void UpdateUI()
		{
			try
			{
				this.iconObj.sprite = this.icon;
				this.titleObj.text = this.title;
				this.descriptionObj.text = this.description;
			}
			catch
			{
				Debug.LogError("Notification - Cannot update the object due to missing components.", this);
			}
		}

		// Token: 0x04001588 RID: 5512
		public Sprite icon;

		// Token: 0x04001589 RID: 5513
		public string title = "Notification Title";

		// Token: 0x0400158A RID: 5514
		[TextArea]
		public string description = "Notification description";

		// Token: 0x0400158B RID: 5515
		public Animator notificationAnimator;

		// Token: 0x0400158C RID: 5516
		public Image iconObj;

		// Token: 0x0400158D RID: 5517
		public TextMeshProUGUI titleObj;

		// Token: 0x0400158E RID: 5518
		public TextMeshProUGUI descriptionObj;

		// Token: 0x0400158F RID: 5519
		public bool enableTimer = true;

		// Token: 0x04001590 RID: 5520
		public float timer = 3f;

		// Token: 0x04001591 RID: 5521
		public bool useCustomContent;

		// Token: 0x04001592 RID: 5522
		public bool useStacking;

		// Token: 0x04001593 RID: 5523
		public bool destroyAfterPlaying;

		// Token: 0x04001594 RID: 5524
		public NotificationManager.NotificationStyle notificationStyle;

		// Token: 0x0200030E RID: 782
		public enum NotificationStyle
		{
			// Token: 0x04001596 RID: 5526
			FADING,
			// Token: 0x04001597 RID: 5527
			POPUP,
			// Token: 0x04001598 RID: 5528
			SLIDING
		}
	}
}
