using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x020002EF RID: 751
	[RequireComponent(typeof(Button))]
	public class ButtonManagerWithIcon : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler
	{
		// Token: 0x06000FD8 RID: 4056 RVA: 0x00053FD8 File Offset: 0x000521D8
		private void Start()
		{
			if (this.animationSolution == ButtonManagerWithIcon.AnimationSolution.SCRIPT)
			{
				this.normalCG = base.transform.Find("Normal").GetComponent<CanvasGroup>();
				this.highlightedCG = base.transform.Find("Highlighted").GetComponent<CanvasGroup>();
				Object.Destroy(base.GetComponent<Animator>());
			}
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

		// Token: 0x06000FD9 RID: 4057 RVA: 0x000540E8 File Offset: 0x000522E8
		public void UpdateUI()
		{
			this.normalIcon.sprite = this.buttonIcon;
			this.highlightedIcon.sprite = this.buttonIcon;
			this.normalText.text = this.buttonText;
			this.highlightedText.text = this.buttonText;
		}

		// Token: 0x06000FDA RID: 4058 RVA: 0x0005413C File Offset: 0x0005233C
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

		// Token: 0x06000FDB RID: 4059 RVA: 0x00054254 File Offset: 0x00052454
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

		// Token: 0x06000FDC RID: 4060 RVA: 0x00054288 File Offset: 0x00052488
		public void OnPointerEnter(PointerEventData eventData)
		{
			if (this.enableButtonSounds && this.useHoverSound && this.buttonVar.interactable)
			{
				this.soundSource.PlayOneShot(this.hoverSound);
			}
			this.hoverEvent.Invoke();
			this.isPointerOn = true;
			if (this.animationSolution == ButtonManagerWithIcon.AnimationSolution.SCRIPT && this.buttonVar.interactable)
			{
				base.StartCoroutine("FadeIn");
			}
		}

		// Token: 0x06000FDD RID: 4061 RVA: 0x000542F7 File Offset: 0x000524F7
		public void OnPointerExit(PointerEventData eventData)
		{
			this.isPointerOn = false;
			if (this.animationSolution == ButtonManagerWithIcon.AnimationSolution.SCRIPT && this.buttonVar.interactable)
			{
				base.StartCoroutine("FadeOut");
			}
		}

		// Token: 0x06000FDE RID: 4062 RVA: 0x00054322 File Offset: 0x00052522
		private IEnumerator FadeIn()
		{
			base.StopCoroutine("FadeOut");
			this.currentNormalValue = this.normalCG.alpha;
			this.currenthighlightedValue = this.highlightedCG.alpha;
			while (this.currenthighlightedValue <= 1f)
			{
				this.currentNormalValue -= Time.deltaTime * this.fadingMultiplier;
				this.normalCG.alpha = this.currentNormalValue;
				this.currenthighlightedValue += Time.deltaTime * this.fadingMultiplier;
				this.highlightedCG.alpha = this.currenthighlightedValue;
				if (this.normalCG.alpha >= 1f)
				{
					base.StopCoroutine("FadeIn");
				}
				yield return null;
			}
			yield break;
		}

		// Token: 0x06000FDF RID: 4063 RVA: 0x00054331 File Offset: 0x00052531
		private IEnumerator FadeOut()
		{
			base.StopCoroutine("FadeIn");
			this.currentNormalValue = this.normalCG.alpha;
			this.currenthighlightedValue = this.highlightedCG.alpha;
			while (this.currentNormalValue >= 0f)
			{
				this.currentNormalValue += Time.deltaTime * this.fadingMultiplier;
				this.normalCG.alpha = this.currentNormalValue;
				this.currenthighlightedValue -= Time.deltaTime * this.fadingMultiplier;
				this.highlightedCG.alpha = this.currenthighlightedValue;
				if (this.highlightedCG.alpha <= 0f)
				{
					base.StopCoroutine("FadeOut");
				}
				yield return null;
			}
			yield break;
		}

		// Token: 0x040014B0 RID: 5296
		public Sprite buttonIcon;

		// Token: 0x040014B1 RID: 5297
		public string buttonText = "Button";

		// Token: 0x040014B2 RID: 5298
		public UnityEvent clickEvent;

		// Token: 0x040014B3 RID: 5299
		public UnityEvent hoverEvent;

		// Token: 0x040014B4 RID: 5300
		public AudioClip hoverSound;

		// Token: 0x040014B5 RID: 5301
		public AudioClip clickSound;

		// Token: 0x040014B6 RID: 5302
		public Button buttonVar;

		// Token: 0x040014B7 RID: 5303
		public Image normalIcon;

		// Token: 0x040014B8 RID: 5304
		public Image highlightedIcon;

		// Token: 0x040014B9 RID: 5305
		public TextMeshProUGUI normalText;

		// Token: 0x040014BA RID: 5306
		public TextMeshProUGUI highlightedText;

		// Token: 0x040014BB RID: 5307
		public AudioSource soundSource;

		// Token: 0x040014BC RID: 5308
		public GameObject rippleParent;

		// Token: 0x040014BD RID: 5309
		public ButtonManagerWithIcon.AnimationSolution animationSolution = ButtonManagerWithIcon.AnimationSolution.SCRIPT;

		// Token: 0x040014BE RID: 5310
		[Range(0.25f, 15f)]
		public float fadingMultiplier = 8f;

		// Token: 0x040014BF RID: 5311
		public bool useCustomContent;

		// Token: 0x040014C0 RID: 5312
		public bool enableButtonSounds;

		// Token: 0x040014C1 RID: 5313
		public bool useHoverSound = true;

		// Token: 0x040014C2 RID: 5314
		public bool useClickSound = true;

		// Token: 0x040014C3 RID: 5315
		public bool useRipple = true;

		// Token: 0x040014C4 RID: 5316
		public Sprite rippleShape;

		// Token: 0x040014C5 RID: 5317
		[Range(0.1f, 5f)]
		public float speed = 1f;

		// Token: 0x040014C6 RID: 5318
		[Range(0.5f, 25f)]
		public float maxSize = 4f;

		// Token: 0x040014C7 RID: 5319
		public Color startColor = new Color(1f, 1f, 1f, 1f);

		// Token: 0x040014C8 RID: 5320
		public Color transitionColor = new Color(1f, 1f, 1f, 1f);

		// Token: 0x040014C9 RID: 5321
		public bool renderOnTop;

		// Token: 0x040014CA RID: 5322
		public bool centered;

		// Token: 0x040014CB RID: 5323
		private bool isPointerOn;

		// Token: 0x040014CC RID: 5324
		private CanvasGroup normalCG;

		// Token: 0x040014CD RID: 5325
		private CanvasGroup highlightedCG;

		// Token: 0x040014CE RID: 5326
		private float currentNormalValue;

		// Token: 0x040014CF RID: 5327
		private float currenthighlightedValue;

		// Token: 0x020002F0 RID: 752
		public enum AnimationSolution
		{
			// Token: 0x040014D1 RID: 5329
			ANIMATOR,
			// Token: 0x040014D2 RID: 5330
			SCRIPT
		}
	}
}
