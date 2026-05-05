using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x02000321 RID: 801
	[RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(Button))]
	public class SwitchManager : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler
	{
		// Token: 0x060010BA RID: 4282 RVA: 0x000598D8 File Offset: 0x00057AD8
		private void Start()
		{
			if (this.switchAnimator == null)
			{
				this.switchAnimator = base.gameObject.GetComponent<Animator>();
			}
			if (this.switchButton == null)
			{
				this.switchButton = base.gameObject.GetComponent<Button>();
				this.switchButton.onClick.AddListener(new UnityAction(this.AnimateSwitch));
				if (this.enableSwitchSounds && this.useClickSound)
				{
					this.switchButton.onClick.AddListener(delegate()
					{
						this.soundSource.PlayOneShot(this.clickSound);
					});
				}
			}
			if (this.saveValue)
			{
				if (PlayerPrefs.GetString(this.switchTag + "Switch") == "")
				{
					if (this.isOn)
					{
						this.switchAnimator.Play("Switch On");
						this.isOn = true;
						PlayerPrefs.SetString(this.switchTag + "Switch", "true");
					}
					else
					{
						this.switchAnimator.Play("Switch Off");
						this.isOn = false;
						PlayerPrefs.SetString(this.switchTag + "Switch", "false");
					}
				}
				else if (PlayerPrefs.GetString(this.switchTag + "Switch") == "true")
				{
					this.switchAnimator.Play("Switch On");
					this.isOn = true;
				}
				else if (PlayerPrefs.GetString(this.switchTag + "Switch") == "false")
				{
					this.switchAnimator.Play("Switch Off");
					this.isOn = false;
				}
			}
			else if (this.isOn)
			{
				this.switchAnimator.Play("Switch On");
				this.isOn = true;
			}
			else
			{
				this.switchAnimator.Play("Switch Off");
				this.isOn = false;
			}
			if (this.invokeAtStart && this.isOn)
			{
				this.OnEvents.Invoke();
				return;
			}
			if (this.invokeAtStart && !this.isOn)
			{
				this.OffEvents.Invoke();
			}
		}

		// Token: 0x060010BB RID: 4283 RVA: 0x00059AF0 File Offset: 0x00057CF0
		private void OnEnable()
		{
			if (this.switchAnimator == null)
			{
				return;
			}
			if (this.saveValue)
			{
				if (PlayerPrefs.GetString(this.switchTag + "Switch") == "")
				{
					if (this.isOn)
					{
						this.switchAnimator.Play("Switch On");
						this.isOn = true;
						PlayerPrefs.SetString(this.switchTag + "Switch", "true");
						return;
					}
					this.switchAnimator.Play("Switch Off");
					this.isOn = false;
					PlayerPrefs.SetString(this.switchTag + "Switch", "false");
					return;
				}
				else
				{
					if (PlayerPrefs.GetString(this.switchTag + "Switch") == "true")
					{
						this.switchAnimator.Play("Switch On");
						this.isOn = true;
						return;
					}
					if (PlayerPrefs.GetString(this.switchTag + "Switch") == "false")
					{
						this.switchAnimator.Play("Switch Off");
						this.isOn = false;
						return;
					}
				}
			}
			else
			{
				if (this.isOn)
				{
					this.switchAnimator.Play("Switch On");
					this.isOn = true;
					return;
				}
				this.switchAnimator.Play("Switch Off");
				this.isOn = false;
			}
		}

		// Token: 0x060010BC RID: 4284 RVA: 0x00059C50 File Offset: 0x00057E50
		public void AnimateSwitch()
		{
			if (this.isOn)
			{
				this.switchAnimator.Play("Switch Off");
				this.isOn = false;
				this.OffEvents.Invoke();
				if (this.saveValue)
				{
					PlayerPrefs.SetString(this.switchTag + "Switch", "false");
					return;
				}
			}
			else
			{
				this.switchAnimator.Play("Switch On");
				this.isOn = true;
				this.OnEvents.Invoke();
				if (this.saveValue)
				{
					PlayerPrefs.SetString(this.switchTag + "Switch", "true");
				}
			}
		}

		// Token: 0x060010BD RID: 4285 RVA: 0x00059CF0 File Offset: 0x00057EF0
		public void UpdateUI()
		{
			if (this.isOn && this.switchAnimator != null && this.switchAnimator.gameObject.activeInHierarchy)
			{
				this.isOn = true;
				this.switchAnimator.Play("Switch On");
				return;
			}
			if (!this.isOn && this.switchAnimator != null && this.switchAnimator.gameObject.activeInHierarchy)
			{
				this.isOn = false;
				this.switchAnimator.Play("Switch Off");
			}
		}

		// Token: 0x060010BE RID: 4286 RVA: 0x00059D7C File Offset: 0x00057F7C
		public void OnPointerEnter(PointerEventData eventData)
		{
			if (this.enableSwitchSounds && this.useHoverSound && this.switchButton.interactable)
			{
				this.soundSource.PlayOneShot(this.hoverSound);
			}
		}

		// Token: 0x040015FE RID: 5630
		public UnityEvent OnEvents;

		// Token: 0x040015FF RID: 5631
		public UnityEvent OffEvents;

		// Token: 0x04001600 RID: 5632
		public bool saveValue = true;

		// Token: 0x04001601 RID: 5633
		public string switchTag = "Switch";

		// Token: 0x04001602 RID: 5634
		public bool isOn = true;

		// Token: 0x04001603 RID: 5635
		public bool invokeAtStart = true;

		// Token: 0x04001604 RID: 5636
		public bool enableSwitchSounds;

		// Token: 0x04001605 RID: 5637
		public bool useHoverSound = true;

		// Token: 0x04001606 RID: 5638
		public bool useClickSound = true;

		// Token: 0x04001607 RID: 5639
		public Animator switchAnimator;

		// Token: 0x04001608 RID: 5640
		public Button switchButton;

		// Token: 0x04001609 RID: 5641
		public AudioSource soundSource;

		// Token: 0x0400160A RID: 5642
		public AudioClip hoverSound;

		// Token: 0x0400160B RID: 5643
		public AudioClip clickSound;
	}
}
