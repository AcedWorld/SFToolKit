using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Invector.vCharacterController
{
	// Token: 0x020003E3 RID: 995
	public class vHUDController : MonoBehaviour
	{
		// Token: 0x1700037E RID: 894
		// (get) Token: 0x060013B8 RID: 5048 RVA: 0x000666DA File Offset: 0x000648DA
		public static vHUDController instance
		{
			get
			{
				if (vHUDController._instance == null)
				{
					vHUDController._instance = Object.FindObjectOfType<vHUDController>();
				}
				return vHUDController._instance;
			}
		}

		// Token: 0x060013B9 RID: 5049 RVA: 0x000666F8 File Offset: 0x000648F8
		private void Start()
		{
			this.InitFadeText();
			if (this.debugPanel != null)
			{
				this.debugText = this.debugPanel.GetComponentInChildren<Text>();
			}
		}

		// Token: 0x060013BA RID: 5050 RVA: 0x00066720 File Offset: 0x00064920
		public void Init(vThirdPersonController cc)
		{
			cc.onDead.AddListener(new UnityAction<GameObject>(this.OnDead));
			cc.onReceiveDamage.AddListener(new UnityAction<vDamage>(this.EnableDamageSprite));
			this.damageImage.color = new Color(0f, 0f, 0f, 0f);
			if ((float)cc.maxHealth != this.healthSlider.maxValue)
			{
				this.healthSlider.maxValue = (float)cc.maxHealth;
				this.healthSlider.onValueChanged.Invoke(this.healthSlider.value);
			}
			this.healthSlider.value = cc.currentHealth;
			if (cc.maxStamina != this.staminaSlider.maxValue)
			{
				this.staminaSlider.maxValue = cc.maxStamina;
				this.staminaSlider.onValueChanged.Invoke(this.staminaSlider.value);
			}
			this.staminaSlider.value = cc.currentStamina;
		}

		// Token: 0x060013BB RID: 5051 RVA: 0x00066821 File Offset: 0x00064A21
		private void OnDead(GameObject arg0)
		{
			this.ShowText("You are Dead!");
		}

		// Token: 0x060013BC RID: 5052 RVA: 0x0006682E File Offset: 0x00064A2E
		public virtual void UpdateHUD(vThirdPersonController cc)
		{
			this.UpdateDebugWindow(cc);
			this.UpdateSliders(cc);
			this.ChangeInputDisplay();
			this.ShowDamageSprite();
			this.FadeEffect();
		}

		// Token: 0x060013BD RID: 5053 RVA: 0x00066850 File Offset: 0x00064A50
		public void ShowText(string message, float textTime = 2f, float fadeTime = 0.5f)
		{
			if (this.fadeText != null && !this.fade)
			{
				this.fadeText.text = message;
				this.textDuration = textTime;
				this.fadeDuration = fadeTime;
				this.durationTimer = 0f;
				this.timer = 0f;
				this.fade = true;
				return;
			}
			if (this.fadeText != null)
			{
				Text text = this.fadeText;
				text.text = text.text + "\n" + message;
				this.textDuration = textTime;
				this.fadeDuration = fadeTime;
				this.durationTimer = 0f;
				this.timer = 0f;
			}
		}

		// Token: 0x060013BE RID: 5054 RVA: 0x000668FC File Offset: 0x00064AFC
		public void ShowText(string message)
		{
			if (this.fadeText != null && !this.fade)
			{
				this.fadeText.text = message;
				this.textDuration = 2f;
				this.fadeDuration = 0.5f;
				this.durationTimer = 0f;
				this.timer = 0f;
				this.fade = true;
				return;
			}
			if (this.fadeText != null)
			{
				Text text = this.fadeText;
				text.text = text.text + "\n" + message;
				this.textDuration = 2f;
				this.fadeDuration = 0.5f;
				this.durationTimer = 0f;
				this.timer = 0f;
			}
		}

		// Token: 0x060013BF RID: 5055 RVA: 0x000669B8 File Offset: 0x00064BB8
		private void UpdateSliders(vThirdPersonController cc)
		{
			if ((float)cc.maxHealth != this.healthSlider.maxValue)
			{
				this.healthSlider.maxValue = Mathf.Lerp(this.healthSlider.maxValue, (float)cc.maxHealth, 2f * Time.fixedDeltaTime);
				this.healthSlider.onValueChanged.Invoke(this.healthSlider.value);
			}
			this.healthSlider.value = Mathf.Lerp(this.healthSlider.value, cc.currentHealth, 2f * Time.fixedDeltaTime);
			if (cc.maxStamina != this.staminaSlider.maxValue)
			{
				this.staminaSlider.maxValue = Mathf.Lerp(this.staminaSlider.maxValue, cc.maxStamina, 2f * Time.fixedDeltaTime);
				this.staminaSlider.onValueChanged.Invoke(this.staminaSlider.value);
			}
			this.staminaSlider.value = cc.currentStamina;
		}

		// Token: 0x060013C0 RID: 5056 RVA: 0x00066AB8 File Offset: 0x00064CB8
		public void ShowDamageSprite()
		{
			if (this.damaged)
			{
				this.damaged = false;
				if (this.damageImage != null)
				{
					this.damageImage.color = this.flashColour;
					return;
				}
			}
			else if (this.damageImage != null)
			{
				this.damageImage.color = Color.Lerp(this.damageImage.color, Color.clear, this.flashSpeed * Time.deltaTime);
			}
		}

		// Token: 0x060013C1 RID: 5057 RVA: 0x00066B2E File Offset: 0x00064D2E
		public void EnableDamageSprite(vDamage damage)
		{
			if (this.damageImage != null)
			{
				this.damageImage.enabled = true;
			}
			this.damaged = true;
		}

		// Token: 0x060013C2 RID: 5058 RVA: 0x00066B54 File Offset: 0x00064D54
		private void UpdateDebugWindow(vThirdPersonController cc)
		{
			if (cc.debugWindow)
			{
				if (this.debugPanel != null && !this.debugPanel.activeSelf)
				{
					this.debugPanel.SetActive(true);
				}
				if (this.debugText)
				{
					this.debugText.text = cc.DebugInfo("");
					return;
				}
			}
			else if (this.debugPanel != null && this.debugPanel.activeSelf)
			{
				this.debugPanel.SetActive(false);
			}
		}

		// Token: 0x060013C3 RID: 5059 RVA: 0x00066BDB File Offset: 0x00064DDB
		private void ChangeInputDisplay()
		{
			if (this.displayControls == null)
			{
				return;
			}
			if (this.controllerInput)
			{
				this.displayControls.sprite = this.joystickControls;
				return;
			}
			this.displayControls.sprite = this.keyboardControls;
		}

		// Token: 0x060013C4 RID: 5060 RVA: 0x00066C18 File Offset: 0x00064E18
		private void InitFadeText()
		{
			if (this.fadeText != null)
			{
				this.fadeText.verticalOverflow = VerticalWrapMode.Overflow;
				this.startColor = this.fadeText.color;
				this.endColor.a = 0f;
				this.fadeText.color = this.endColor;
				return;
			}
			Debug.Log("Please assign a Text object on the field Fade Text");
		}

		// Token: 0x060013C5 RID: 5061 RVA: 0x00066C7C File Offset: 0x00064E7C
		private void FadeEffect()
		{
			if (this.fadeText != null)
			{
				if (this.fade)
				{
					this.fadeText.color = Color.Lerp(this.endColor, this.startColor, this.timer);
					if (this.timer < 1f)
					{
						this.timer += Time.deltaTime / this.fadeDuration;
					}
					if (this.fadeText.color.a >= 1f)
					{
						this.fade = false;
						this.timer = 0f;
						return;
					}
				}
				else
				{
					if (this.fadeText.color.a >= 1f)
					{
						this.durationTimer += Time.deltaTime;
					}
					if (this.durationTimer >= this.textDuration)
					{
						this.fadeText.color = Color.Lerp(this.startColor, this.endColor, this.timer);
						if (this.timer < 1f)
						{
							this.timer += Time.deltaTime / this.fadeDuration;
						}
					}
				}
			}
		}

		// Token: 0x0400195F RID: 6495
		[Header("Health/Stamina")]
		public Slider healthSlider;

		// Token: 0x04001960 RID: 6496
		public Slider staminaSlider;

		// Token: 0x04001961 RID: 6497
		[Header("DamageHUD")]
		public Image damageImage;

		// Token: 0x04001962 RID: 6498
		public float flashSpeed = 5f;

		// Token: 0x04001963 RID: 6499
		public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

		// Token: 0x04001964 RID: 6500
		[HideInInspector]
		public bool damaged;

		// Token: 0x04001965 RID: 6501
		[Header("Controls Display")]
		[HideInInspector]
		public bool controllerInput;

		// Token: 0x04001966 RID: 6502
		public Image displayControls;

		// Token: 0x04001967 RID: 6503
		public Sprite joystickControls;

		// Token: 0x04001968 RID: 6504
		public Sprite keyboardControls;

		// Token: 0x04001969 RID: 6505
		[Header("Debug Window")]
		public GameObject debugPanel;

		// Token: 0x0400196A RID: 6506
		[HideInInspector]
		public Text debugText;

		// Token: 0x0400196B RID: 6507
		[Header("Text with FadeIn/Out")]
		public Text fadeText;

		// Token: 0x0400196C RID: 6508
		private float textDuration;

		// Token: 0x0400196D RID: 6509
		private float fadeDuration;

		// Token: 0x0400196E RID: 6510
		private float durationTimer;

		// Token: 0x0400196F RID: 6511
		private float timer;

		// Token: 0x04001970 RID: 6512
		private Color startColor;

		// Token: 0x04001971 RID: 6513
		private Color endColor;

		// Token: 0x04001972 RID: 6514
		private bool fade;

		// Token: 0x04001973 RID: 6515
		private static vHUDController _instance;
	}
}
