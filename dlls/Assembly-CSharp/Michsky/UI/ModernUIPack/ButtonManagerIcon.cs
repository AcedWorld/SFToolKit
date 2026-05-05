using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x020002EB RID: 747
	[RequireComponent(typeof(Button))]
	public class ButtonManagerIcon : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler
	{
		// Token: 0x06000FC1 RID: 4033 RVA: 0x000539CC File Offset: 0x00051BCC
		private void Start()
		{
			if (this.animationSolution == ButtonManagerIcon.AnimationSolution.SCRIPT)
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

		// Token: 0x06000FC2 RID: 4034 RVA: 0x00053ADC File Offset: 0x00051CDC
		public void UpdateUI()
		{
			this.normalIcon.sprite = this.buttonIcon;
			this.highlightedIcon.sprite = this.buttonIcon;
		}

		// Token: 0x06000FC3 RID: 4035 RVA: 0x00053B00 File Offset: 0x00051D00
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

		// Token: 0x06000FC4 RID: 4036 RVA: 0x00053C18 File Offset: 0x00051E18
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

		// Token: 0x06000FC5 RID: 4037 RVA: 0x00053C4C File Offset: 0x00051E4C
		public void OnPointerEnter(PointerEventData eventData)
		{
			if (this.enableButtonSounds && this.useHoverSound && this.buttonVar.interactable)
			{
				this.soundSource.PlayOneShot(this.hoverSound);
			}
			this.hoverEvent.Invoke();
			this.isPointerOn = true;
			if (this.animationSolution == ButtonManagerIcon.AnimationSolution.SCRIPT && this.buttonVar.interactable)
			{
				base.StartCoroutine("FadeIn");
			}
		}

		// Token: 0x06000FC6 RID: 4038 RVA: 0x00053CBB File Offset: 0x00051EBB
		public void OnPointerExit(PointerEventData eventData)
		{
			this.isPointerOn = false;
			if (this.animationSolution == ButtonManagerIcon.AnimationSolution.SCRIPT && this.buttonVar.interactable)
			{
				base.StartCoroutine("FadeOut");
			}
		}

		// Token: 0x06000FC7 RID: 4039 RVA: 0x00053CE6 File Offset: 0x00051EE6
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

		// Token: 0x06000FC8 RID: 4040 RVA: 0x00053CF5 File Offset: 0x00051EF5
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

		// Token: 0x0400148A RID: 5258
		public Sprite buttonIcon;

		// Token: 0x0400148B RID: 5259
		public UnityEvent clickEvent;

		// Token: 0x0400148C RID: 5260
		public UnityEvent hoverEvent;

		// Token: 0x0400148D RID: 5261
		public AudioClip hoverSound;

		// Token: 0x0400148E RID: 5262
		public AudioClip clickSound;

		// Token: 0x0400148F RID: 5263
		public Button buttonVar;

		// Token: 0x04001490 RID: 5264
		public Image normalIcon;

		// Token: 0x04001491 RID: 5265
		public Image highlightedIcon;

		// Token: 0x04001492 RID: 5266
		public AudioSource soundSource;

		// Token: 0x04001493 RID: 5267
		public GameObject rippleParent;

		// Token: 0x04001494 RID: 5268
		public ButtonManagerIcon.AnimationSolution animationSolution = ButtonManagerIcon.AnimationSolution.SCRIPT;

		// Token: 0x04001495 RID: 5269
		[Range(0.25f, 15f)]
		public float fadingMultiplier = 8f;

		// Token: 0x04001496 RID: 5270
		public bool useCustomContent;

		// Token: 0x04001497 RID: 5271
		public bool enableButtonSounds;

		// Token: 0x04001498 RID: 5272
		public bool useHoverSound = true;

		// Token: 0x04001499 RID: 5273
		public bool useClickSound = true;

		// Token: 0x0400149A RID: 5274
		public bool useRipple = true;

		// Token: 0x0400149B RID: 5275
		public Sprite rippleShape;

		// Token: 0x0400149C RID: 5276
		[Range(0.1f, 5f)]
		public float speed = 1f;

		// Token: 0x0400149D RID: 5277
		[Range(0.5f, 25f)]
		public float maxSize = 4f;

		// Token: 0x0400149E RID: 5278
		public Color startColor = new Color(1f, 1f, 1f, 1f);

		// Token: 0x0400149F RID: 5279
		public Color transitionColor = new Color(1f, 1f, 1f, 1f);

		// Token: 0x040014A0 RID: 5280
		public bool renderOnTop;

		// Token: 0x040014A1 RID: 5281
		public bool centered;

		// Token: 0x040014A2 RID: 5282
		private bool isPointerOn;

		// Token: 0x040014A3 RID: 5283
		private CanvasGroup normalCG;

		// Token: 0x040014A4 RID: 5284
		private CanvasGroup highlightedCG;

		// Token: 0x040014A5 RID: 5285
		private float currentNormalValue;

		// Token: 0x040014A6 RID: 5286
		private float currenthighlightedValue;

		// Token: 0x020002EC RID: 748
		public enum AnimationSolution
		{
			// Token: 0x040014A8 RID: 5288
			ANIMATOR,
			// Token: 0x040014A9 RID: 5289
			SCRIPT
		}
	}
}
