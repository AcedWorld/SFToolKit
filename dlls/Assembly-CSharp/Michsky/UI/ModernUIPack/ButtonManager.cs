using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x020002E4 RID: 740
	[RequireComponent(typeof(Button))]
	public class ButtonManager : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler
	{
		// Token: 0x06000F8F RID: 3983 RVA: 0x00052A3C File Offset: 0x00050C3C
		private void Start()
		{
			if (this.animationSolution == ButtonManager.AnimationSolution.SCRIPT)
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

		// Token: 0x06000F90 RID: 3984 RVA: 0x00052B4C File Offset: 0x00050D4C
		public void UpdateUI()
		{
			this.normalText.text = this.buttonText;
			this.highlightedText.text = this.buttonText;
		}

		// Token: 0x06000F91 RID: 3985 RVA: 0x00052B70 File Offset: 0x00050D70
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

		// Token: 0x06000F92 RID: 3986 RVA: 0x00052C88 File Offset: 0x00050E88
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

		// Token: 0x06000F93 RID: 3987 RVA: 0x00052CBC File Offset: 0x00050EBC
		public void OnPointerEnter(PointerEventData eventData)
		{
			if (this.enableButtonSounds && this.useHoverSound && this.buttonVar.interactable)
			{
				this.soundSource.PlayOneShot(this.hoverSound);
			}
			this.hoverEvent.Invoke();
			this.isPointerOn = true;
			if (this.animationSolution == ButtonManager.AnimationSolution.SCRIPT && this.buttonVar.interactable)
			{
				base.StartCoroutine("FadeIn");
			}
		}

		// Token: 0x06000F94 RID: 3988 RVA: 0x00052D2B File Offset: 0x00050F2B
		public void OnPointerExit(PointerEventData eventData)
		{
			this.isPointerOn = false;
			if (this.animationSolution == ButtonManager.AnimationSolution.SCRIPT && this.buttonVar.interactable)
			{
				base.StartCoroutine("FadeOut");
			}
		}

		// Token: 0x06000F95 RID: 3989 RVA: 0x00052D56 File Offset: 0x00050F56
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

		// Token: 0x06000F96 RID: 3990 RVA: 0x00052D65 File Offset: 0x00050F65
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

		// Token: 0x04001420 RID: 5152
		public string buttonText = "Button";

		// Token: 0x04001421 RID: 5153
		public UnityEvent clickEvent;

		// Token: 0x04001422 RID: 5154
		public UnityEvent hoverEvent;

		// Token: 0x04001423 RID: 5155
		public AudioClip hoverSound;

		// Token: 0x04001424 RID: 5156
		public AudioClip clickSound;

		// Token: 0x04001425 RID: 5157
		public Button buttonVar;

		// Token: 0x04001426 RID: 5158
		public TextMeshProUGUI normalText;

		// Token: 0x04001427 RID: 5159
		public TextMeshProUGUI highlightedText;

		// Token: 0x04001428 RID: 5160
		public AudioSource soundSource;

		// Token: 0x04001429 RID: 5161
		public GameObject rippleParent;

		// Token: 0x0400142A RID: 5162
		public ButtonManager.AnimationSolution animationSolution = ButtonManager.AnimationSolution.SCRIPT;

		// Token: 0x0400142B RID: 5163
		[Range(0.25f, 15f)]
		public float fadingMultiplier = 8f;

		// Token: 0x0400142C RID: 5164
		public bool useCustomContent;

		// Token: 0x0400142D RID: 5165
		public bool enableButtonSounds;

		// Token: 0x0400142E RID: 5166
		public bool useHoverSound = true;

		// Token: 0x0400142F RID: 5167
		public bool useClickSound = true;

		// Token: 0x04001430 RID: 5168
		public bool useRipple = true;

		// Token: 0x04001431 RID: 5169
		public Sprite rippleShape;

		// Token: 0x04001432 RID: 5170
		[Range(0.1f, 5f)]
		public float speed = 1f;

		// Token: 0x04001433 RID: 5171
		[Range(0.5f, 25f)]
		public float maxSize = 4f;

		// Token: 0x04001434 RID: 5172
		public Color startColor = new Color(1f, 1f, 1f, 1f);

		// Token: 0x04001435 RID: 5173
		public Color transitionColor = new Color(1f, 1f, 1f, 1f);

		// Token: 0x04001436 RID: 5174
		public bool renderOnTop;

		// Token: 0x04001437 RID: 5175
		public bool centered;

		// Token: 0x04001438 RID: 5176
		private bool isPointerOn;

		// Token: 0x04001439 RID: 5177
		private CanvasGroup normalCG;

		// Token: 0x0400143A RID: 5178
		private CanvasGroup highlightedCG;

		// Token: 0x0400143B RID: 5179
		private float currentNormalValue;

		// Token: 0x0400143C RID: 5180
		private float currenthighlightedValue;

		// Token: 0x020002E5 RID: 741
		public enum AnimationSolution
		{
			// Token: 0x0400143E RID: 5182
			ANIMATOR,
			// Token: 0x0400143F RID: 5183
			SCRIPT
		}
	}
}
