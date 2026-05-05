using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x020002F7 RID: 759
	[AddComponentMenu("Modern UI Pack/Context Menu/Context Menu Content")]
	public class ContextMenuContent : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		// Token: 0x06001002 RID: 4098 RVA: 0x00054DD4 File Offset: 0x00052FD4
		private void Start()
		{
			if (this.contextManager == null)
			{
				try
				{
					this.contextManager = GameObject.Find("Context Menu").GetComponent<ContextMenuManager>();
					this.contextAnimator = this.contextManager.contextAnimator;
					this.itemParent = this.contextManager.transform.Find("Content/Item List").transform;
				}
				catch
				{
					Debug.Log("Context Menu - No variable attached to Context Manager.", this);
				}
			}
			foreach (object obj in this.itemParent)
			{
				Object.Destroy(((Transform)obj).gameObject);
			}
		}

		// Token: 0x06001003 RID: 4099 RVA: 0x00054EA0 File Offset: 0x000530A0
		public void OnPointerClick(PointerEventData eventData)
		{
			if (this.contextManager.isContextMenuOn)
			{
				this.contextAnimator.Play("Menu Out");
				this.contextManager.isContextMenuOn = false;
				return;
			}
			if (eventData.button == PointerEventData.InputButton.Right && !this.contextManager.isContextMenuOn)
			{
				foreach (object obj in this.itemParent)
				{
					Object.Destroy(((Transform)obj).gameObject);
				}
				for (int i = 0; i < this.contexItems.Count; i++)
				{
					if (this.contexItems[i].contextItemType == ContextMenuContent.ContextItemType.BUTTON)
					{
						this.selectedItem = this.contextManager.contextButton;
					}
					GameObject gameObject = Object.Instantiate<GameObject>(this.selectedItem, new Vector3(0f, 0f, 0f), Quaternion.identity);
					gameObject.transform.SetParent(this.itemParent, false);
					this.setItemText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
					this.textHelper = this.contexItems[i].itemText;
					this.setItemText.text = this.textHelper;
					Transform transform = gameObject.gameObject.transform.Find("Icon");
					this.setItemImage = transform.GetComponent<Image>();
					this.imageHelper = this.contexItems[i].itemIcon;
					this.setItemImage.sprite = this.imageHelper;
					Button component = gameObject.GetComponent<Button>();
					component.onClick.AddListener(new UnityAction(this.contexItems[i].onClickEvents.Invoke));
					component.onClick.AddListener(new UnityAction(this.CloseOnClick));
					base.StartCoroutine(this.ExecuteAfterTime(0.01f));
				}
				this.contextManager.SetContextMenuPosition();
				this.contextAnimator.Play("Menu In");
				this.contextManager.isContextMenuOn = true;
				this.contextManager.SetContextMenuPosition();
			}
		}

		// Token: 0x06001004 RID: 4100 RVA: 0x000550C0 File Offset: 0x000532C0
		private IEnumerator ExecuteAfterTime(float time)
		{
			yield return new WaitForSeconds(time);
			this.itemParent.gameObject.SetActive(false);
			this.itemParent.gameObject.SetActive(true);
			base.StopCoroutine(this.ExecuteAfterTime(0.01f));
			base.StopCoroutine("ExecuteAfterTime");
			yield break;
		}

		// Token: 0x06001005 RID: 4101 RVA: 0x000550D6 File Offset: 0x000532D6
		public void CloseOnClick()
		{
			this.contextAnimator.Play("Menu Out");
			this.contextManager.isContextMenuOn = false;
		}

		// Token: 0x040014EC RID: 5356
		[Header("RESOURCES")]
		public ContextMenuManager contextManager;

		// Token: 0x040014ED RID: 5357
		public Transform itemParent;

		// Token: 0x040014EE RID: 5358
		[Header("ITEMS")]
		public List<ContextMenuContent.ContextItem> contexItems = new List<ContextMenuContent.ContextItem>();

		// Token: 0x040014EF RID: 5359
		private Animator contextAnimator;

		// Token: 0x040014F0 RID: 5360
		private GameObject selectedItem;

		// Token: 0x040014F1 RID: 5361
		private Image setItemImage;

		// Token: 0x040014F2 RID: 5362
		private TextMeshProUGUI setItemText;

		// Token: 0x040014F3 RID: 5363
		private Sprite imageHelper;

		// Token: 0x040014F4 RID: 5364
		private string textHelper;

		// Token: 0x020002F8 RID: 760
		[Serializable]
		public class ContextItem
		{
			// Token: 0x040014F5 RID: 5365
			public string itemText;

			// Token: 0x040014F6 RID: 5366
			public Sprite itemIcon;

			// Token: 0x040014F7 RID: 5367
			public ContextMenuContent.ContextItemType contextItemType;

			// Token: 0x040014F8 RID: 5368
			public UnityEvent onClickEvents;
		}

		// Token: 0x020002F9 RID: 761
		public enum ContextItemType
		{
			// Token: 0x040014FA RID: 5370
			BUTTON
		}
	}
}
