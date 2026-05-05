using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x02000303 RID: 771
	public class DropdownMultiSelect : MonoBehaviour
	{
		// Token: 0x0600102C RID: 4140 RVA: 0x000561D0 File Offset: 0x000543D0
		private void Start()
		{
			try
			{
				this.dropdownAnimator = base.GetComponent<Animator>();
				this.itemList = this.itemParent.GetComponent<VerticalLayoutGroup>();
				this.itemList = this.itemParent.GetComponent<VerticalLayoutGroup>();
				this.SetupDropdown();
				this.currentListParent = base.transform.parent;
			}
			catch
			{
				Debug.LogError("Dropdown - Cannot initalize the object due to missing resources.", this);
			}
			if (this.enableScrollbar)
			{
				this.itemList.padding.right = 25;
				this.scrollbar.SetActive(true);
			}
			else
			{
				this.itemList.padding.right = 8;
				Object.Destroy(this.scrollbar);
			}
			if (this.setHighPriorty)
			{
				base.transform.SetAsLastSibling();
			}
		}

		// Token: 0x0600102D RID: 4141 RVA: 0x0005629C File Offset: 0x0005449C
		public void SetupDropdown()
		{
			foreach (object obj in this.itemParent)
			{
				Object.Destroy(((Transform)obj).gameObject);
			}
			for (int i = 0; i < this.dropdownItems.Count; i++)
			{
				GameObject gameObject = Object.Instantiate<GameObject>(this.itemObject, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject.transform.SetParent(this.itemParent, false);
				this.setItemText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
				this.textHelper = this.dropdownItems[i].itemName;
				this.setItemText.text = this.textHelper;
				Toggle component = gameObject.GetComponent<Toggle>();
				this.iHelper = i;
				component.onValueChanged.AddListener(new UnityAction<bool>(this.UpdateToggle));
				if (this.dropdownItems[i].toggleEvents != null)
				{
					component.onValueChanged.AddListener(new UnityAction<bool>(this.dropdownItems[i].toggleEvents.Invoke));
				}
				if (this.saveSelected)
				{
					if (this.invokeAtStart)
					{
						if (PlayerPrefs.GetInt(this.toggleTag + "Toggle") == 1)
						{
							this.dropdownItems[i].toggleEvents.Invoke(true);
						}
						else
						{
							this.dropdownItems[i].toggleEvents.Invoke(false);
						}
					}
					else
					{
						component.onValueChanged.AddListener(new UnityAction<bool>(this.SaveToggle));
					}
				}
				else if (this.invokeAtStart)
				{
					if (this.dropdownItems[i].isOn)
					{
						this.dropdownItems[i].toggleEvents.Invoke(true);
					}
					else
					{
						this.dropdownItems[i].toggleEvents.Invoke(false);
					}
				}
				else if (this.dropdownItems[i].isOn)
				{
					component.isOn = true;
				}
				else
				{
					component.isOn = false;
				}
				if (this.invokeAtStart)
				{
					if (this.dropdownItems[i].isOn)
					{
						this.dropdownItems[i].toggleEvents.Invoke(true);
					}
					else
					{
						this.dropdownItems[i].toggleEvents.Invoke(false);
					}
				}
			}
			this.currentListParent = base.transform.parent;
		}

		// Token: 0x0600102E RID: 4142 RVA: 0x000020BE File Offset: 0x000002BE
		public void UpdateToggle(bool isOn)
		{
		}

		// Token: 0x0600102F RID: 4143 RVA: 0x00056528 File Offset: 0x00054728
		public void SaveToggle(bool isOn)
		{
			if (isOn)
			{
				PlayerPrefs.SetInt(this.toggleTag + "Toggle" + this.iHelper.ToString(), 1);
				return;
			}
			PlayerPrefs.SetInt(this.toggleTag + "Toggle" + this.iHelper.ToString(), 0);
		}

		// Token: 0x06001030 RID: 4144 RVA: 0x0005657C File Offset: 0x0005477C
		public void Animate()
		{
			if (!this.isOn && this.animationType == DropdownMultiSelect.AnimationType.FADING)
			{
				this.dropdownAnimator.Play("Fading In");
				this.isOn = true;
				if (this.isListItem)
				{
					this.siblingIndex = base.transform.GetSiblingIndex();
					base.gameObject.transform.SetParent(this.listParent, true);
				}
			}
			else if (this.isOn && this.animationType == DropdownMultiSelect.AnimationType.FADING)
			{
				this.dropdownAnimator.Play("Fading Out");
				this.isOn = false;
				if (this.isListItem)
				{
					base.gameObject.transform.SetParent(this.currentListParent, true);
					base.gameObject.transform.SetSiblingIndex(this.siblingIndex);
				}
			}
			else if (!this.isOn && this.animationType == DropdownMultiSelect.AnimationType.SLIDING)
			{
				this.dropdownAnimator.Play("Sliding In");
				this.isOn = true;
				if (this.isListItem)
				{
					this.siblingIndex = base.transform.GetSiblingIndex();
					base.gameObject.transform.SetParent(this.listParent, true);
				}
			}
			else if (this.isOn && this.animationType == DropdownMultiSelect.AnimationType.SLIDING)
			{
				this.dropdownAnimator.Play("Sliding Out");
				this.isOn = false;
				if (this.isListItem)
				{
					base.gameObject.transform.SetParent(this.currentListParent, true);
					base.gameObject.transform.SetSiblingIndex(this.siblingIndex);
				}
			}
			else if (!this.isOn && this.animationType == DropdownMultiSelect.AnimationType.STYLISH)
			{
				this.dropdownAnimator.Play("Stylish In");
				this.isOn = true;
				if (this.isListItem)
				{
					this.siblingIndex = base.transform.GetSiblingIndex();
					base.gameObject.transform.SetParent(this.listParent, true);
				}
			}
			else if (this.isOn && this.animationType == DropdownMultiSelect.AnimationType.STYLISH)
			{
				this.dropdownAnimator.Play("Stylish Out");
				this.isOn = false;
				if (this.isListItem)
				{
					base.gameObject.transform.SetParent(this.currentListParent, true);
					base.gameObject.transform.SetSiblingIndex(this.siblingIndex);
				}
			}
			if (this.enableTrigger && !this.isOn)
			{
				this.triggerObject.SetActive(false);
			}
			else if (this.enableTrigger && this.isOn)
			{
				this.triggerObject.SetActive(true);
			}
			if (this.outOnPointerExit)
			{
				this.triggerObject.SetActive(false);
			}
			if (this.setHighPriorty)
			{
				base.transform.SetAsLastSibling();
			}
		}

		// Token: 0x06001031 RID: 4145 RVA: 0x0005682C File Offset: 0x00054A2C
		public void OnPointerExit(PointerEventData eventData)
		{
			if (this.outOnPointerExit)
			{
				if (this.isOn)
				{
					this.Animate();
					this.isOn = false;
				}
				if (this.isListItem)
				{
					base.gameObject.transform.SetParent(this.currentListParent, true);
				}
			}
		}

		// Token: 0x06001032 RID: 4146 RVA: 0x0005686C File Offset: 0x00054A6C
		public void UpdateValues()
		{
			if (this.enableScrollbar)
			{
				this.itemList.padding.right = 25;
				this.scrollbar.SetActive(true);
				return;
			}
			this.itemList.padding.right = 8;
			this.scrollbar.SetActive(false);
		}

		// Token: 0x06001033 RID: 4147 RVA: 0x000568C0 File Offset: 0x00054AC0
		public void CreateNewItem()
		{
			DropdownMultiSelect.Item item = new DropdownMultiSelect.Item();
			item.itemName = this.newItemTitle;
			this.dropdownItems.Add(item);
			this.SetupDropdown();
		}

		// Token: 0x06001034 RID: 4148 RVA: 0x000568F1 File Offset: 0x00054AF1
		public void SetItemTitle(string title)
		{
			this.newItemTitle = title;
		}

		// Token: 0x06001035 RID: 4149 RVA: 0x000568FC File Offset: 0x00054AFC
		public void AddNewItem()
		{
			DropdownMultiSelect.Item item = new DropdownMultiSelect.Item();
			this.dropdownItems.Add(item);
		}

		// Token: 0x04001541 RID: 5441
		public GameObject triggerObject;

		// Token: 0x04001542 RID: 5442
		public Transform itemParent;

		// Token: 0x04001543 RID: 5443
		public GameObject itemObject;

		// Token: 0x04001544 RID: 5444
		public GameObject scrollbar;

		// Token: 0x04001545 RID: 5445
		private VerticalLayoutGroup itemList;

		// Token: 0x04001546 RID: 5446
		private Transform currentListParent;

		// Token: 0x04001547 RID: 5447
		public Transform listParent;

		// Token: 0x04001548 RID: 5448
		private Animator dropdownAnimator;

		// Token: 0x04001549 RID: 5449
		public TextMeshProUGUI setItemText;

		// Token: 0x0400154A RID: 5450
		public bool enableIcon = true;

		// Token: 0x0400154B RID: 5451
		public bool enableTrigger = true;

		// Token: 0x0400154C RID: 5452
		public bool enableScrollbar = true;

		// Token: 0x0400154D RID: 5453
		public bool setHighPriorty = true;

		// Token: 0x0400154E RID: 5454
		public bool outOnPointerExit;

		// Token: 0x0400154F RID: 5455
		public bool isListItem;

		// Token: 0x04001550 RID: 5456
		public DropdownMultiSelect.AnimationType animationType;

		// Token: 0x04001551 RID: 5457
		public bool saveSelected;

		// Token: 0x04001552 RID: 5458
		public bool invokeAtStart;

		// Token: 0x04001553 RID: 5459
		public string toggleTag = "Multi Dropdown";

		// Token: 0x04001554 RID: 5460
		[SerializeField]
		public List<DropdownMultiSelect.Item> dropdownItems = new List<DropdownMultiSelect.Item>();

		// Token: 0x04001555 RID: 5461
		private string textHelper;

		// Token: 0x04001556 RID: 5462
		private string newItemTitle;

		// Token: 0x04001557 RID: 5463
		private Sprite newItemIcon;

		// Token: 0x04001558 RID: 5464
		private bool isOn;

		// Token: 0x04001559 RID: 5465
		public int iHelper;

		// Token: 0x0400155A RID: 5466
		public int siblingIndex;

		// Token: 0x02000304 RID: 772
		[Serializable]
		public class ToggleEvent : UnityEvent<bool>
		{
		}

		// Token: 0x02000305 RID: 773
		public enum AnimationType
		{
			// Token: 0x0400155C RID: 5468
			FADING,
			// Token: 0x0400155D RID: 5469
			SLIDING,
			// Token: 0x0400155E RID: 5470
			STYLISH
		}

		// Token: 0x02000306 RID: 774
		[Serializable]
		public class Item
		{
			// Token: 0x0400155F RID: 5471
			public string itemName = "Dropdown Item";

			// Token: 0x04001560 RID: 5472
			public bool isOn;

			// Token: 0x04001561 RID: 5473
			[SerializeField]
			public DropdownMultiSelect.ToggleEvent toggleEvents;
		}
	}
}
