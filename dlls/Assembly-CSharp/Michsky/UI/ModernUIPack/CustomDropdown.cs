using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x020002FE RID: 766
	public class CustomDropdown : MonoBehaviour, IPointerExitHandler, IEventSystemHandler, IPointerEnterHandler, IPointerClickHandler
	{
		// Token: 0x0600101A RID: 4122 RVA: 0x0005576C File Offset: 0x0005396C
		private void Start()
		{
			try
			{
				this.dropdownAnimator = base.gameObject.GetComponent<Animator>();
				this.itemList = this.itemParent.GetComponent<VerticalLayoutGroup>();
				if (this.dropdownItems.Count != 0)
				{
					this.SetupDropdown();
				}
				this.currentListParent = base.transform.parent;
				if (this.enableTrigger && this.triggerObject != null)
				{
					this.triggerButton = base.gameObject.GetComponent<Button>();
					this.triggerEvent = this.triggerObject.AddComponent<EventTrigger>();
					EventTrigger.Entry entry = new EventTrigger.Entry();
					entry.eventID = EventTriggerType.PointerClick;
					entry.callback.AddListener(delegate(BaseEventData eventData)
					{
						this.Animate();
					});
					this.triggerEvent.GetComponent<EventTrigger>().triggers.Add(entry);
				}
			}
			catch
			{
				Debug.LogError("Dropdown - Cannot initalize the object due to missing resources.", this);
			}
			if (this.enableScrollbar)
			{
				this.itemList.padding.right = 25;
			}
			else
			{
				this.itemList.padding.right = 8;
			}
			if (this.setHighPriorty)
			{
				base.transform.SetAsLastSibling();
			}
			if (this.saveSelected)
			{
				if (this.invokeAtStart)
				{
					this.dropdownItems[PlayerPrefs.GetInt(this.dropdownTag + "Dropdown")].OnItemSelection.Invoke();
					return;
				}
				this.ChangeDropdownInfo(PlayerPrefs.GetInt(this.dropdownTag + "Dropdown"));
			}
		}

		// Token: 0x0600101B RID: 4123 RVA: 0x000558E8 File Offset: 0x00053AE8
		public void SetupDropdown()
		{
			foreach (object obj in this.itemParent)
			{
				Object.Destroy(((Transform)obj).gameObject);
			}
			this.index = 0;
			for (int i = 0; i < this.dropdownItems.Count; i++)
			{
				GameObject go = Object.Instantiate<GameObject>(this.itemObject, new Vector3(0f, 0f, 0f), Quaternion.identity);
				go.transform.SetParent(this.itemParent, false);
				this.setItemText = go.GetComponentInChildren<TextMeshProUGUI>();
				this.textHelper = this.dropdownItems[i].itemName;
				this.setItemText.text = this.textHelper;
				Transform transform = go.gameObject.transform.Find("Icon");
				this.setItemImage = transform.GetComponent<Image>();
				this.imageHelper = this.dropdownItems[i].itemIcon;
				this.setItemImage.sprite = this.imageHelper;
				Button component = go.GetComponent<Button>();
				component.onClick.AddListener(new UnityAction(this.Animate));
				component.onClick.AddListener(delegate()
				{
					this.ChangeDropdownInfo(this.index = go.transform.GetSiblingIndex());
					this.dropdownEvent.Invoke(this.index = go.transform.GetSiblingIndex());
					if (this.saveSelected)
					{
						PlayerPrefs.SetInt(this.dropdownTag + "Dropdown", go.transform.GetSiblingIndex());
					}
				});
				if (this.dropdownItems[i].OnItemSelection != null)
				{
					component.onClick.AddListener(new UnityAction(this.dropdownItems[i].OnItemSelection.Invoke));
				}
				if (this.invokeAtStart)
				{
					this.dropdownItems[i].OnItemSelection.Invoke();
				}
			}
			try
			{
				this.selectedText.text = this.dropdownItems[this.selectedItemIndex].itemName;
				this.selectedImage.sprite = this.dropdownItems[this.selectedItemIndex].itemIcon;
				this.currentListParent = base.transform.parent;
			}
			catch
			{
				this.selectedText.text = this.dropdownTag;
				this.currentListParent = base.transform.parent;
				Debug.Log("Dropdown - There is no dropdown items in the list.", this);
			}
		}

		// Token: 0x0600101C RID: 4124 RVA: 0x00055B68 File Offset: 0x00053D68
		public void ChangeDropdownInfo(int itemIndex)
		{
			if (this.selectedImage != null)
			{
				this.selectedImage.sprite = this.dropdownItems[itemIndex].itemIcon;
			}
			if (this.selectedText != null)
			{
				this.selectedText.text = this.dropdownItems[itemIndex].itemName;
			}
			if (this.enableDropdownSounds && this.useClickSound)
			{
				this.soundSource.PlayOneShot(this.clickSound);
			}
			this.selectedItemIndex = itemIndex;
		}

		// Token: 0x0600101D RID: 4125 RVA: 0x00055BF4 File Offset: 0x00053DF4
		public void Animate()
		{
			if (!this.isOn && this.animationType == CustomDropdown.AnimationType.FADING)
			{
				this.dropdownAnimator.Play("Fading In");
				this.isOn = true;
				if (this.isListItem)
				{
					this.siblingIndex = base.transform.GetSiblingIndex();
					base.gameObject.transform.SetParent(this.listParent, true);
				}
			}
			else if (this.isOn && this.animationType == CustomDropdown.AnimationType.FADING)
			{
				this.dropdownAnimator.Play("Fading Out");
				this.isOn = false;
				if (this.isListItem)
				{
					base.gameObject.transform.SetParent(this.currentListParent, true);
					base.gameObject.transform.SetSiblingIndex(this.siblingIndex);
				}
			}
			else if (!this.isOn && this.animationType == CustomDropdown.AnimationType.SLIDING)
			{
				this.dropdownAnimator.Play("Sliding In");
				this.isOn = true;
				if (this.isListItem)
				{
					this.siblingIndex = base.transform.GetSiblingIndex();
					base.gameObject.transform.SetParent(this.listParent, true);
				}
			}
			else if (this.isOn && this.animationType == CustomDropdown.AnimationType.SLIDING)
			{
				this.dropdownAnimator.Play("Sliding Out");
				this.isOn = false;
				if (this.isListItem)
				{
					base.gameObject.transform.SetParent(this.currentListParent, true);
					base.gameObject.transform.SetSiblingIndex(this.siblingIndex);
				}
			}
			else if (!this.isOn && this.animationType == CustomDropdown.AnimationType.STYLISH)
			{
				this.dropdownAnimator.Play("Stylish In");
				this.isOn = true;
				if (this.isListItem)
				{
					this.siblingIndex = base.transform.GetSiblingIndex();
					base.gameObject.transform.SetParent(this.listParent, true);
				}
			}
			else if (this.isOn && this.animationType == CustomDropdown.AnimationType.STYLISH)
			{
				this.dropdownAnimator.Play("Stylish Out");
				this.isOn = false;
				if (this.isListItem)
				{
					base.gameObject.transform.SetParent(this.currentListParent, true);
					base.gameObject.transform.SetSiblingIndex(this.siblingIndex);
				}
			}
			if (this.setHighPriorty)
			{
				base.transform.SetAsLastSibling();
			}
			if (this.enableTrigger && !this.isOn)
			{
				this.triggerObject.SetActive(false);
				this.triggerButton.interactable = true;
			}
			else if (this.enableTrigger && this.isOn)
			{
				this.triggerObject.SetActive(true);
				this.triggerButton.interactable = false;
			}
			if (this.enableTrigger && this.outOnPointerExit)
			{
				this.triggerObject.SetActive(false);
				this.triggerButton.interactable = true;
			}
		}

		// Token: 0x0600101E RID: 4126 RVA: 0x00055ED0 File Offset: 0x000540D0
		public void GetSelectedDropdownName(TextMeshProUGUI tmpText)
		{
			if (tmpText != null)
			{
				tmpText.text = this.dropdownItems[this.selectedItemIndex].itemName;
				return;
			}
			Debug.Log("Dropdown - Selected item name: " + this.dropdownItems[this.selectedItemIndex].itemName);
		}

		// Token: 0x0600101F RID: 4127 RVA: 0x00055F28 File Offset: 0x00054128
		public void UpdateValues()
		{
			if (this.enableScrollbar)
			{
				this.itemList.padding.right = 25;
				this.scrollbar.SetActive(true);
			}
			else
			{
				this.itemList.padding.right = 8;
				this.scrollbar.SetActive(false);
			}
			if (!this.enableIcon)
			{
				this.selectedImage.gameObject.SetActive(false);
				return;
			}
			this.selectedImage.gameObject.SetActive(true);
		}

		// Token: 0x06001020 RID: 4128 RVA: 0x00055FA8 File Offset: 0x000541A8
		public void CreateNewItem(string title, Sprite icon)
		{
			CustomDropdown.Item item = new CustomDropdown.Item();
			item.itemName = title;
			item.itemIcon = icon;
			this.dropdownItems.Add(item);
			this.SetupDropdown();
		}

		// Token: 0x06001021 RID: 4129 RVA: 0x00055FDC File Offset: 0x000541DC
		public void CreateNewItemFast(string title, Sprite icon)
		{
			CustomDropdown.Item item = new CustomDropdown.Item();
			item.itemName = title;
			item.itemIcon = icon;
			this.dropdownItems.Add(item);
		}

		// Token: 0x06001022 RID: 4130 RVA: 0x0005600C File Offset: 0x0005420C
		public void AddNewItem()
		{
			CustomDropdown.Item item = new CustomDropdown.Item();
			this.dropdownItems.Add(item);
		}

		// Token: 0x06001023 RID: 4131 RVA: 0x0005602B File Offset: 0x0005422B
		public void OnPointerClick(PointerEventData eventData)
		{
			if (this.enableDropdownSounds && this.useClickSound)
			{
				this.soundSource.PlayOneShot(this.clickSound);
			}
		}

		// Token: 0x06001024 RID: 4132 RVA: 0x0005604E File Offset: 0x0005424E
		public void OnPointerEnter(PointerEventData eventData)
		{
			if (this.enableDropdownSounds && this.useHoverSound)
			{
				this.soundSource.PlayOneShot(this.hoverSound);
			}
		}

		// Token: 0x06001025 RID: 4133 RVA: 0x00056071 File Offset: 0x00054271
		public void OnPointerExit(PointerEventData eventData)
		{
			if (this.outOnPointerExit && this.isOn)
			{
				this.Animate();
				this.isOn = false;
				if (this.isListItem)
				{
					base.gameObject.transform.SetParent(this.currentListParent, true);
				}
			}
		}

		// Token: 0x04001512 RID: 5394
		public Animator dropdownAnimator;

		// Token: 0x04001513 RID: 5395
		public GameObject triggerObject;

		// Token: 0x04001514 RID: 5396
		public TextMeshProUGUI selectedText;

		// Token: 0x04001515 RID: 5397
		public Image selectedImage;

		// Token: 0x04001516 RID: 5398
		public Transform itemParent;

		// Token: 0x04001517 RID: 5399
		public GameObject itemObject;

		// Token: 0x04001518 RID: 5400
		public GameObject scrollbar;

		// Token: 0x04001519 RID: 5401
		public VerticalLayoutGroup itemList;

		// Token: 0x0400151A RID: 5402
		[HideInInspector]
		public Transform currentListParent;

		// Token: 0x0400151B RID: 5403
		public Transform listParent;

		// Token: 0x0400151C RID: 5404
		public AudioSource soundSource;

		// Token: 0x0400151D RID: 5405
		public bool enableIcon = true;

		// Token: 0x0400151E RID: 5406
		public bool enableTrigger = true;

		// Token: 0x0400151F RID: 5407
		public bool enableScrollbar = true;

		// Token: 0x04001520 RID: 5408
		public bool setHighPriorty = true;

		// Token: 0x04001521 RID: 5409
		public bool outOnPointerExit;

		// Token: 0x04001522 RID: 5410
		public bool isListItem;

		// Token: 0x04001523 RID: 5411
		public bool invokeAtStart;

		// Token: 0x04001524 RID: 5412
		public CustomDropdown.AnimationType animationType;

		// Token: 0x04001525 RID: 5413
		public int selectedItemIndex;

		// Token: 0x04001526 RID: 5414
		public bool enableDropdownSounds;

		// Token: 0x04001527 RID: 5415
		public bool useHoverSound = true;

		// Token: 0x04001528 RID: 5416
		public bool useClickSound = true;

		// Token: 0x04001529 RID: 5417
		public bool saveSelected;

		// Token: 0x0400152A RID: 5418
		public string dropdownTag = "Dropdown";

		// Token: 0x0400152B RID: 5419
		[SerializeField]
		public List<CustomDropdown.Item> dropdownItems = new List<CustomDropdown.Item>();

		// Token: 0x0400152C RID: 5420
		[Space(8f)]
		public CustomDropdown.DropdownEvent dropdownEvent;

		// Token: 0x0400152D RID: 5421
		public AudioClip hoverSound;

		// Token: 0x0400152E RID: 5422
		public AudioClip clickSound;

		// Token: 0x0400152F RID: 5423
		[HideInInspector]
		public bool isOn;

		// Token: 0x04001530 RID: 5424
		[HideInInspector]
		public int index;

		// Token: 0x04001531 RID: 5425
		[HideInInspector]
		public int siblingIndex;

		// Token: 0x04001532 RID: 5426
		[HideInInspector]
		public TextMeshProUGUI setItemText;

		// Token: 0x04001533 RID: 5427
		[HideInInspector]
		public Image setItemImage;

		// Token: 0x04001534 RID: 5428
		private Button triggerButton;

		// Token: 0x04001535 RID: 5429
		private EventTrigger triggerEvent;

		// Token: 0x04001536 RID: 5430
		private Sprite imageHelper;

		// Token: 0x04001537 RID: 5431
		private string textHelper;

		// Token: 0x020002FF RID: 767
		[Serializable]
		public class DropdownEvent : UnityEvent<int>
		{
		}

		// Token: 0x02000300 RID: 768
		public enum AnimationType
		{
			// Token: 0x04001539 RID: 5433
			FADING,
			// Token: 0x0400153A RID: 5434
			SLIDING,
			// Token: 0x0400153B RID: 5435
			STYLISH
		}

		// Token: 0x02000301 RID: 769
		[Serializable]
		public class Item
		{
			// Token: 0x0400153C RID: 5436
			public string itemName = "Dropdown Item";

			// Token: 0x0400153D RID: 5437
			public Sprite itemIcon;

			// Token: 0x0400153E RID: 5438
			public UnityEvent OnItemSelection = new UnityEvent();
		}
	}
}
