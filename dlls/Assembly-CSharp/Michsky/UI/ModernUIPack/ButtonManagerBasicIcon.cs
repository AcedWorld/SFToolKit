using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x020002E9 RID: 745
	[RequireComponent(typeof(Button))]
	public class ButtonManagerBasicIcon : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler
	{
		// Token: 0x06000FAF RID: 4015 RVA: 0x00053378 File Offset: 0x00051578
		private void Start()
		{
			if (this.buttonVar == null)
			{
				this.buttonVar = base.gameObject.GetComponent<Button>();
			}
			this.buttonVar.onClick.AddListener(delegate()
			{
				this.clickEvent.Invoke();
			});
			if (this.enableButtonSounds && this.useClickSound)
			{
				this.buttonVar.onClick.AddListener(delegate()
				{
					this.soundSource.PlayOneShot(this.clickSound);
				});
			}
			if (!this.useCustomContent)
			{
				this.UpdateUI();
			}
			if (this.useRipple && this.rippleParent != null)
			{
				this.rippleParent.SetActive(false);
				return;
			}
			if (!this.useRipple && this.rippleParent != null)
			{
				Object.Destroy(this.rippleParent);
			}
		}

		// Token: 0x06000FB0 RID: 4016 RVA: 0x0005343E File Offset: 0x0005163E
		public void UpdateUI()
		{
			this.normalIcon.sprite = this.buttonIcon;
		}

		// Token: 0x06000FB1 RID: 4017 RVA: 0x00053454 File Offset: 0x00051654
		public void CreateRipple(Vector2 pos)
		{
			if (this.rippleParent != null)
			{
				GameObject gameObject = new GameObject();
				gameObject.AddComponent<Ripple>();
				gameObject.AddComponent<Image>();
				gameObject.GetComponent<Image>().sprite = this.rippleShape;
				gameObject.name = "Ripple";
				this.rippleParent.SetActive(true);
				gameObject.transform.SetParent(this.rippleParent.transform);
				if (this.renderOnTop)
				{
					this.rippleParent.transform.SetAsLastSibling();
				}
				else
				{
					this.rippleParent.transform.SetAsFirstSibling();
				}
				if (this.centered)
				{
					gameObject.transform.localPosition = new Vector2(0f, 0f);
				}
				else
				{
					gameObject.transform.position = pos;
				}
				gameObject.GetComponent<Ripple>().speed = this.speed;
				gameObject.GetComponent<Ripple>().maxSize = this.maxSize;
				gameObject.GetComponent<Ripple>().startColor = this.startColor;
				gameObject.GetComponent<Ripple>().transitionColor = this.transitionColor;
			}
		}

		// Token: 0x06000FB2 RID: 4018 RVA: 0x0005356C File Offset: 0x0005176C
		public void OnPointerDown(PointerEventData eventData)
		{
			if (this.useRipple && this.isPointerOn)
			{
				this.CreateRipple(Input.mousePosition);
				return;
			}
			if (!this.useRipple)
			{
				base.enabled = false;
			}
		}

		// Token: 0x06000FB3 RID: 4019 RVA: 0x000535A0 File Offset: 0x000517A0
		public void OnPointerEnter(PointerEventData eventData)
		{
			if (this.enableButtonSounds && this.useHoverSound && this.buttonVar.interactable)
			{
				this.soundSource.PlayOneShot(this.hoverSound);
			}
			this.hoverEvent.Invoke();
			this.isPointerOn = true;
		}

		// Token: 0x06000FB4 RID: 4020 RVA: 0x000535ED File Offset: 0x000517ED
		public void OnPointerExit(PointerEventData eventData)
		{
			this.isPointerOn = false;
		}

		// Token: 0x0400145C RID: 5212
		public Sprite buttonIcon;

		// Token: 0x0400145D RID: 5213
		public UnityEvent clickEvent;

		// Token: 0x0400145E RID: 5214
		public UnityEvent hoverEvent;

		// Token: 0x0400145F RID: 5215
		public AudioClip hoverSound;

		// Token: 0x04001460 RID: 5216
		public AudioClip clickSound;

		// Token: 0x04001461 RID: 5217
		public Button buttonVar;

		// Token: 0x04001462 RID: 5218
		public Image normalIcon;

		// Token: 0x04001463 RID: 5219
		public AudioSource soundSource;

		// Token: 0x04001464 RID: 5220
		public GameObject rippleParent;

		// Token: 0x04001465 RID: 5221
		public bool useCustomContent;

		// Token: 0x04001466 RID: 5222
		public bool enableButtonSounds;

		// Token: 0x04001467 RID: 5223
		public bool useHoverSound = true;

		// Token: 0x04001468 RID: 5224
		public bool useClickSound = true;

		// Token: 0x04001469 RID: 5225
		public bool useRipple = true;

		// Token: 0x0400146A RID: 5226
		public Sprite rippleShape;

		// Token: 0x0400146B RID: 5227
		[Range(0.1f, 5f)]
		public float speed = 1f;

		// Token: 0x0400146C RID: 5228
		[Range(0.5f, 25f)]
		public float maxSize = 4f;

		// Token: 0x0400146D RID: 5229
		public Color startColor = new Color(1f, 1f, 1f, 1f);

		// Token: 0x0400146E RID: 5230
		public Color transitionColor = new Color(1f, 1f, 1f, 1f);

		// Token: 0x0400146F RID: 5231
		public bool renderOnTop;

		// Token: 0x04001470 RID: 5232
		public bool centered;

		// Token: 0x04001471 RID: 5233
		private bool isPointerOn;
	}
}
