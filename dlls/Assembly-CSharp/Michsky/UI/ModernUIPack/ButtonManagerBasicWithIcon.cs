using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x020002EA RID: 746
	[RequireComponent(typeof(Button))]
	public class ButtonManagerBasicWithIcon : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler
	{
		// Token: 0x06000FB8 RID: 4024 RVA: 0x00053694 File Offset: 0x00051894
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

		// Token: 0x06000FB9 RID: 4025 RVA: 0x0005375A File Offset: 0x0005195A
		public void UpdateUI()
		{
			this.normalImage.sprite = this.buttonIcon;
			this.normalText.text = this.buttonText;
		}

		// Token: 0x06000FBA RID: 4026 RVA: 0x00053780 File Offset: 0x00051980
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

		// Token: 0x06000FBB RID: 4027 RVA: 0x00053898 File Offset: 0x00051A98
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

		// Token: 0x06000FBC RID: 4028 RVA: 0x000538CC File Offset: 0x00051ACC
		public void OnPointerEnter(PointerEventData eventData)
		{
			if (this.enableButtonSounds && this.useHoverSound && this.buttonVar.interactable)
			{
				this.soundSource.PlayOneShot(this.hoverSound);
			}
			this.hoverEvent.Invoke();
			this.isPointerOn = true;
		}

		// Token: 0x06000FBD RID: 4029 RVA: 0x00053919 File Offset: 0x00051B19
		public void OnPointerExit(PointerEventData eventData)
		{
			this.isPointerOn = false;
		}

		// Token: 0x04001472 RID: 5234
		public Sprite buttonIcon;

		// Token: 0x04001473 RID: 5235
		public string buttonText = "Button";

		// Token: 0x04001474 RID: 5236
		public UnityEvent clickEvent;

		// Token: 0x04001475 RID: 5237
		public UnityEvent hoverEvent;

		// Token: 0x04001476 RID: 5238
		public AudioClip hoverSound;

		// Token: 0x04001477 RID: 5239
		public AudioClip clickSound;

		// Token: 0x04001478 RID: 5240
		public Button buttonVar;

		// Token: 0x04001479 RID: 5241
		public Image normalImage;

		// Token: 0x0400147A RID: 5242
		public TextMeshProUGUI normalText;

		// Token: 0x0400147B RID: 5243
		public AudioSource soundSource;

		// Token: 0x0400147C RID: 5244
		public GameObject rippleParent;

		// Token: 0x0400147D RID: 5245
		public bool useCustomContent;

		// Token: 0x0400147E RID: 5246
		public bool enableButtonSounds;

		// Token: 0x0400147F RID: 5247
		public bool useHoverSound = true;

		// Token: 0x04001480 RID: 5248
		public bool useClickSound = true;

		// Token: 0x04001481 RID: 5249
		public bool useRipple = true;

		// Token: 0x04001482 RID: 5250
		public Sprite rippleShape;

		// Token: 0x04001483 RID: 5251
		[Range(0.1f, 5f)]
		public float speed = 1f;

		// Token: 0x04001484 RID: 5252
		[Range(0.5f, 25f)]
		public float maxSize = 4f;

		// Token: 0x04001485 RID: 5253
		public Color startColor = new Color(1f, 1f, 1f, 1f);

		// Token: 0x04001486 RID: 5254
		public Color transitionColor = new Color(1f, 1f, 1f, 1f);

		// Token: 0x04001487 RID: 5255
		public bool renderOnTop;

		// Token: 0x04001488 RID: 5256
		public bool centered;

		// Token: 0x04001489 RID: 5257
		private bool isPointerOn;
	}
}
