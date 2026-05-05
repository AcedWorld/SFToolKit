using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x020002E8 RID: 744
	[RequireComponent(typeof(Button))]
	public class ButtonManagerBasic : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler
	{
		// Token: 0x06000FA6 RID: 4006 RVA: 0x00053050 File Offset: 0x00051250
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

		// Token: 0x06000FA7 RID: 4007 RVA: 0x00053116 File Offset: 0x00051316
		public void UpdateUI()
		{
			this.normalText.text = this.buttonText;
		}

		// Token: 0x06000FA8 RID: 4008 RVA: 0x0005312C File Offset: 0x0005132C
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

		// Token: 0x06000FA9 RID: 4009 RVA: 0x00053244 File Offset: 0x00051444
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

		// Token: 0x06000FAA RID: 4010 RVA: 0x00053278 File Offset: 0x00051478
		public void OnPointerEnter(PointerEventData eventData)
		{
			if (this.enableButtonSounds && this.useHoverSound && this.buttonVar.interactable)
			{
				this.soundSource.PlayOneShot(this.hoverSound);
			}
			this.hoverEvent.Invoke();
			this.isPointerOn = true;
		}

		// Token: 0x06000FAB RID: 4011 RVA: 0x000532C5 File Offset: 0x000514C5
		public void OnPointerExit(PointerEventData eventData)
		{
			this.isPointerOn = false;
		}

		// Token: 0x04001446 RID: 5190
		public string buttonText = "Button";

		// Token: 0x04001447 RID: 5191
		public UnityEvent clickEvent;

		// Token: 0x04001448 RID: 5192
		public UnityEvent hoverEvent;

		// Token: 0x04001449 RID: 5193
		public AudioClip hoverSound;

		// Token: 0x0400144A RID: 5194
		public AudioClip clickSound;

		// Token: 0x0400144B RID: 5195
		public Button buttonVar;

		// Token: 0x0400144C RID: 5196
		public TextMeshProUGUI normalText;

		// Token: 0x0400144D RID: 5197
		public AudioSource soundSource;

		// Token: 0x0400144E RID: 5198
		public GameObject rippleParent;

		// Token: 0x0400144F RID: 5199
		public bool useCustomContent;

		// Token: 0x04001450 RID: 5200
		public bool enableButtonSounds;

		// Token: 0x04001451 RID: 5201
		public bool useHoverSound = true;

		// Token: 0x04001452 RID: 5202
		public bool useClickSound = true;

		// Token: 0x04001453 RID: 5203
		public bool useRipple = true;

		// Token: 0x04001454 RID: 5204
		public Sprite rippleShape;

		// Token: 0x04001455 RID: 5205
		[Range(0.1f, 5f)]
		public float speed = 1f;

		// Token: 0x04001456 RID: 5206
		[Range(0.5f, 25f)]
		public float maxSize = 4f;

		// Token: 0x04001457 RID: 5207
		public Color startColor = new Color(1f, 1f, 1f, 1f);

		// Token: 0x04001458 RID: 5208
		public Color transitionColor = new Color(1f, 1f, 1f, 0f);

		// Token: 0x04001459 RID: 5209
		public bool renderOnTop;

		// Token: 0x0400145A RID: 5210
		public bool centered;

		// Token: 0x0400145B RID: 5211
		private bool isPointerOn;
	}
}
