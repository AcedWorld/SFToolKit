using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Invector.Utils
{
	// Token: 0x020003BA RID: 954
	[vClassHeader("Fade Canvas", true, "icon_v2", false, "")]
	public class vFadeCanvas : vMonoBehaviour
	{
		// Token: 0x06001306 RID: 4870 RVA: 0x00064613 File Offset: 0x00062813
		private void Awake()
		{
			if (!this.group)
			{
				this.group = base.GetComponent<CanvasGroup>();
			}
		}

		// Token: 0x06001307 RID: 4871 RVA: 0x0006462E File Offset: 0x0006282E
		private void Start()
		{
			this.InitilizeFadeEffect();
		}

		// Token: 0x06001308 RID: 4872 RVA: 0x0006462E File Offset: 0x0006282E
		private void OnEnable()
		{
			this.InitilizeFadeEffect();
		}

		// Token: 0x06001309 RID: 4873 RVA: 0x00064636 File Offset: 0x00062836
		private void InitilizeFadeEffect()
		{
			if (this.fadeInStart)
			{
				this.FadeIn();
			}
			if (this.fadeOutStart)
			{
				this.FadeOut();
			}
			if (this.startWithAlphaZero)
			{
				this.AlphaZero();
			}
			if (this.startWithAlphaFull)
			{
				this.AlphaFull();
			}
		}

		// Token: 0x0600130A RID: 4874 RVA: 0x00064670 File Offset: 0x00062870
		public void AlphaZero()
		{
			if (this.group)
			{
				this.group.alpha = 0f;
			}
		}

		// Token: 0x0600130B RID: 4875 RVA: 0x0006468F File Offset: 0x0006288F
		public void AlphaFull()
		{
			if (this.group)
			{
				this.group.alpha = 1f;
			}
		}

		// Token: 0x0600130C RID: 4876 RVA: 0x000646AE File Offset: 0x000628AE
		public void FadeIn()
		{
			base.StartCoroutine(this.Fade(1f));
		}

		// Token: 0x0600130D RID: 4877 RVA: 0x000646C2 File Offset: 0x000628C2
		public void FadeOut()
		{
			base.StartCoroutine(this.Fade(0f));
		}

		// Token: 0x0600130E RID: 4878 RVA: 0x000646D6 File Offset: 0x000628D6
		private IEnumerator Fade(float targetValue)
		{
			if (targetValue == 1f)
			{
				this.onStartFadeIn.Invoke();
				if (this.autoControlCanvasGroup && this.group)
				{
					this.group.interactable = false;
					this.group.blocksRaycasts = true;
				}
			}
			else
			{
				if (this.autoControlCanvasGroup && this.group)
				{
					this.group.interactable = false;
					this.group.blocksRaycasts = true;
				}
				this.onStartFadeOut.Invoke();
			}
			this.inFade = false;
			yield return new WaitForEndOfFrame();
			this.inFade = true;
			if (this.group)
			{
				this.currentValue = this.group.alpha;
			}
			while (((targetValue == 1f) ? (this.currentValue < 1f) : (this.currentValue > 0f)) && this.inFade)
			{
				yield return null;
				this.currentValue = ((targetValue == 1f) ? (this.currentValue + Time.unscaledDeltaTime * this.fadeSpeed) : (this.currentValue - Time.unscaledDeltaTime * this.fadeSpeed));
				if (this.group)
				{
					this.group.alpha = this.currentValue;
				}
				this.OnChangeValue.Invoke(this.currentValue);
			}
			if (targetValue == 1f)
			{
				this.onFinishFadeIn.Invoke();
				if (this.autoControlCanvasGroup && this.group)
				{
					this.group.interactable = true;
					this.group.blocksRaycasts = true;
				}
			}
			else
			{
				if (this.autoControlCanvasGroup && this.group)
				{
					this.group.interactable = false;
					this.group.blocksRaycasts = false;
				}
				this.onFinishFadeOut.Invoke();
			}
			yield break;
		}

		// Token: 0x040018CE RID: 6350
		public CanvasGroup group;

		// Token: 0x040018CF RID: 6351
		public float fadeSpeed = 2f;

		// Token: 0x040018D0 RID: 6352
		public UnityEvent onStartFadeIn;

		// Token: 0x040018D1 RID: 6353
		public UnityEvent onFinishFadeIn;

		// Token: 0x040018D2 RID: 6354
		public UnityEvent onStartFadeOut;

		// Token: 0x040018D3 RID: 6355
		public UnityEvent onFinishFadeOut;

		// Token: 0x040018D4 RID: 6356
		public Slider.SliderEvent OnChangeValue;

		// Token: 0x040018D5 RID: 6357
		public bool autoControlCanvasGroup;

		// Token: 0x040018D6 RID: 6358
		public bool fadeInStart;

		// Token: 0x040018D7 RID: 6359
		public bool fadeOutStart;

		// Token: 0x040018D8 RID: 6360
		public bool startWithAlphaZero = true;

		// Token: 0x040018D9 RID: 6361
		public bool startWithAlphaFull;

		// Token: 0x040018DA RID: 6362
		private float currentValue;

		// Token: 0x040018DB RID: 6363
		private bool inFade;
	}
}
