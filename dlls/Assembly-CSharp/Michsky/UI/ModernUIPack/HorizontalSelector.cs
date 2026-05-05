using System;
using System.Collections.Generic;
using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x02000308 RID: 776
	public class HorizontalSelector : MonoBehaviour
	{
		// Token: 0x0600103B RID: 4155 RVA: 0x00056980 File Offset: 0x00054B80
		private void Start()
		{
			this.selectorAnimator = base.gameObject.GetComponent<Animator>();
			this.player = ReInput.players.GetPlayer(this.playerId);
			try
			{
				if (this.label == null)
				{
					this.label = base.transform.Find("Text").GetComponent<TextMeshProUGUI>();
				}
				if (this.labelHelper == null)
				{
					this.labelHelper = base.transform.Find("Text Helper").GetComponent<TextMeshProUGUI>();
				}
			}
			catch
			{
				Debug.LogError("Horizontal Selector - Cannot initalize the object due to missing resources.", this);
			}
			if (this.label != null && this.labelHelper != null)
			{
				this.SetupSelector();
			}
			if (this.invokeAtStart)
			{
				this.itemList[this.index].onValueChanged.Invoke();
				this.selectorEvent.Invoke(this.index);
			}
		}

		// Token: 0x0600103C RID: 4156 RVA: 0x000020BE File Offset: 0x000002BE
		public void Update()
		{
		}

		// Token: 0x0600103D RID: 4157 RVA: 0x00056A7C File Offset: 0x00054C7C
		public void SetupSelector()
		{
			if (this.itemList.Count != 0)
			{
				if (this.saveValue)
				{
					if (PlayerPrefs.HasKey(this.selectorTag + "HSelectorValue"))
					{
						this.defaultIndex = PlayerPrefs.GetInt(this.selectorTag + "HSelectorValue");
					}
					else
					{
						PlayerPrefs.SetInt(this.selectorTag + "HSelectorValue", this.defaultIndex);
					}
				}
				this.label.text = this.itemList[this.defaultIndex].itemTitle;
				this.labelHelper.text = this.label.text;
				this.index = this.defaultIndex;
				if (this.enableIndicators)
				{
					foreach (object obj in this.indicatorParent)
					{
						Object.Destroy(((Transform)obj).gameObject);
					}
					for (int i = 0; i < this.itemList.Count; i++)
					{
						GameObject gameObject = Object.Instantiate<GameObject>(this.indicatorObject, new Vector3(0f, 0f, 0f), Quaternion.identity);
						gameObject.transform.SetParent(this.indicatorParent, false);
						gameObject.name = this.itemList[i].itemTitle;
						Transform transform = gameObject.transform.Find("On");
						Transform transform2 = gameObject.transform.Find("Off");
						if (i == this.index)
						{
							transform.gameObject.SetActive(true);
							transform2.gameObject.SetActive(false);
						}
						else
						{
							transform.gameObject.SetActive(false);
							transform2.gameObject.SetActive(true);
						}
					}
					return;
				}
				Object.Destroy(this.indicatorParent.gameObject);
			}
		}

		// Token: 0x0600103E RID: 4158 RVA: 0x00056C68 File Offset: 0x00054E68
		public void PreviousClick()
		{
			if (!this.loopSelection)
			{
				if (this.index != 0)
				{
					this.labelHelper.text = this.label.text;
					if (this.index == 0)
					{
						this.index = this.itemList.Count - 1;
					}
					else
					{
						this.index--;
					}
					this.label.text = this.itemList[this.index].itemTitle;
					try
					{
						this.itemList[this.index].onValueChanged.Invoke();
					}
					catch
					{
					}
					this.selectorEvent.Invoke(this.index);
					this.selectorAnimator.Play(null);
					this.selectorAnimator.StopPlayback();
					if (this.invertAnimation)
					{
						this.selectorAnimator.Play("Forward");
					}
					else
					{
						this.selectorAnimator.Play("Previous");
					}
					if (this.saveValue)
					{
						PlayerPrefs.SetInt(this.selectorTag + "HSelectorValue", this.index);
					}
				}
			}
			else
			{
				this.labelHelper.text = this.label.text;
				if (this.index == 0)
				{
					this.index = this.itemList.Count - 1;
				}
				else
				{
					this.index--;
				}
				this.label.text = this.itemList[this.index].itemTitle;
				try
				{
					this.itemList[this.index].onValueChanged.Invoke();
				}
				catch
				{
				}
				this.selectorEvent.Invoke(this.index);
				this.selectorAnimator.Play(null);
				this.selectorAnimator.StopPlayback();
				if (this.invertAnimation)
				{
					this.selectorAnimator.Play("Forward");
				}
				else
				{
					this.selectorAnimator.Play("Previous");
				}
				if (this.saveValue)
				{
					PlayerPrefs.SetInt(this.selectorTag + "HSelectorValue", this.index);
				}
			}
			if (this.saveValue)
			{
				PlayerPrefs.SetInt(this.selectorTag + "HSelectorValue", this.index);
			}
			if (this.enableIndicators)
			{
				for (int i = 0; i < this.itemList.Count; i++)
				{
					GameObject gameObject = this.indicatorParent.GetChild(i).gameObject;
					Transform transform = gameObject.transform.Find("On");
					Transform transform2 = gameObject.transform.Find("Off");
					if (i == this.index)
					{
						transform.gameObject.SetActive(true);
						transform2.gameObject.SetActive(false);
					}
					else
					{
						transform.gameObject.SetActive(false);
						transform2.gameObject.SetActive(true);
					}
				}
			}
		}

		// Token: 0x0600103F RID: 4159 RVA: 0x00056F50 File Offset: 0x00055150
		public void ForwardClick()
		{
			if (!this.loopSelection)
			{
				if (this.index != this.itemList.Count - 1)
				{
					this.labelHelper.text = this.label.text;
					if (this.index + 1 >= this.itemList.Count)
					{
						this.index = 0;
					}
					else
					{
						this.index++;
					}
					this.label.text = this.itemList[this.index].itemTitle;
					try
					{
						this.itemList[this.index].onValueChanged.Invoke();
					}
					catch
					{
					}
					this.selectorEvent.Invoke(this.index);
					this.selectorAnimator.Play(null);
					this.selectorAnimator.StopPlayback();
					if (this.invertAnimation)
					{
						this.selectorAnimator.Play("Previous");
					}
					else
					{
						this.selectorAnimator.Play("Forward");
					}
					if (this.saveValue)
					{
						PlayerPrefs.SetInt(this.selectorTag + "HSelectorValue", this.index);
					}
				}
			}
			else
			{
				this.labelHelper.text = this.label.text;
				if (this.index + 1 >= this.itemList.Count)
				{
					this.index = 0;
				}
				else
				{
					this.index++;
				}
				this.label.text = this.itemList[this.index].itemTitle;
				try
				{
					this.itemList[this.index].onValueChanged.Invoke();
				}
				catch
				{
				}
				this.selectorEvent.Invoke(this.index);
				this.selectorAnimator.Play(null);
				this.selectorAnimator.StopPlayback();
				if (this.invertAnimation)
				{
					this.selectorAnimator.Play("Previous");
				}
				else
				{
					this.selectorAnimator.Play("Forward");
				}
				if (this.saveValue)
				{
					PlayerPrefs.SetInt(this.selectorTag + "HSelectorValue", this.index);
				}
			}
			if (this.saveValue)
			{
				PlayerPrefs.SetInt(this.selectorTag + "HSelectorValue", this.index);
			}
			if (this.enableIndicators)
			{
				for (int i = 0; i < this.itemList.Count; i++)
				{
					GameObject gameObject = this.indicatorParent.GetChild(i).gameObject;
					Transform transform = gameObject.transform.Find("On");
					Transform transform2 = gameObject.transform.Find("Off");
					if (i == this.index)
					{
						transform.gameObject.SetActive(true);
						transform2.gameObject.SetActive(false);
					}
					else
					{
						transform.gameObject.SetActive(false);
						transform2.gameObject.SetActive(true);
					}
				}
			}
		}

		// Token: 0x06001040 RID: 4160 RVA: 0x00057248 File Offset: 0x00055448
		public void CreateNewItem(string title)
		{
			HorizontalSelector.Item item = new HorizontalSelector.Item();
			this.newItemTitle = title;
			item.itemTitle = this.newItemTitle;
			this.itemList.Add(item);
		}

		// Token: 0x06001041 RID: 4161 RVA: 0x0005727C File Offset: 0x0005547C
		public void AddNewItem()
		{
			HorizontalSelector.Item item = new HorizontalSelector.Item();
			this.itemList.Add(item);
		}

		// Token: 0x06001042 RID: 4162 RVA: 0x0005729C File Offset: 0x0005549C
		public void UpdateUI()
		{
			this.label.text = this.itemList[this.index].itemTitle;
			if (this.enableIndicators)
			{
				foreach (object obj in this.indicatorParent)
				{
					Object.Destroy(((Transform)obj).gameObject);
				}
				for (int i = 0; i < this.itemList.Count; i++)
				{
					GameObject gameObject = Object.Instantiate<GameObject>(this.indicatorObject, new Vector3(0f, 0f, 0f), Quaternion.identity);
					gameObject.transform.SetParent(this.indicatorParent, false);
					gameObject.name = this.itemList[i].itemTitle;
					Transform transform = gameObject.transform.Find("On");
					Transform transform2 = gameObject.transform.Find("Off");
					if (i == this.index)
					{
						transform.gameObject.SetActive(true);
						transform2.gameObject.SetActive(false);
					}
					else
					{
						transform.gameObject.SetActive(false);
						transform2.gameObject.SetActive(true);
					}
				}
			}
		}

		// Token: 0x04001562 RID: 5474
		public TextMeshProUGUI label;

		// Token: 0x04001563 RID: 5475
		public TextMeshProUGUI labelHelper;

		// Token: 0x04001564 RID: 5476
		public Transform indicatorParent;

		// Token: 0x04001565 RID: 5477
		public GameObject indicatorObject;

		// Token: 0x04001566 RID: 5478
		private Animator selectorAnimator;

		// Token: 0x04001567 RID: 5479
		private string newItemTitle;

		// Token: 0x04001568 RID: 5480
		public bool saveValue;

		// Token: 0x04001569 RID: 5481
		public string selectorTag = "Tag Text";

		// Token: 0x0400156A RID: 5482
		public bool enableIndicators = true;

		// Token: 0x0400156B RID: 5483
		public bool invokeAtStart;

		// Token: 0x0400156C RID: 5484
		public bool invertAnimation;

		// Token: 0x0400156D RID: 5485
		public bool loopSelection;

		// Token: 0x0400156E RID: 5486
		public int defaultIndex;

		// Token: 0x0400156F RID: 5487
		public int playerId;

		// Token: 0x04001570 RID: 5488
		private Player player;

		// Token: 0x04001571 RID: 5489
		[HideInInspector]
		public int index;

		// Token: 0x04001572 RID: 5490
		public List<HorizontalSelector.Item> itemList = new List<HorizontalSelector.Item>();

		// Token: 0x04001573 RID: 5491
		[Space(8f)]
		public HorizontalSelector.SelectorEvent selectorEvent;

		// Token: 0x02000309 RID: 777
		[Serializable]
		public class SelectorEvent : UnityEvent<int>
		{
		}

		// Token: 0x0200030A RID: 778
		[Serializable]
		public class Item
		{
			// Token: 0x04001574 RID: 5492
			public string itemTitle = "Item Title";

			// Token: 0x04001575 RID: 5493
			public UnityEvent onValueChanged = new UnityEvent();
		}
	}
}
