using System;
using Rewired.UI;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.ComponentControls.Effects
{
	// Token: 0x0200041E RID: 1054
	[ExecuteInEditMode]
	[RequireComponent(typeof(RectTransform))]
	[DisallowMultipleComponent]
	[AddComponentMenu("Rewired/Touch Controls/Effects/Touch Interactable Transitioner")]
	public sealed class TouchInteractableTransitioner : MonoBehaviour, IVisibilityChangedHandler, TouchInteractable.IInteractionStateTransitionHandler
	{
		// Token: 0x170009EC RID: 2540
		// (get) Token: 0x06002A3C RID: 10812 RVA: 0x00020528 File Offset: 0x0001E728
		// (set) Token: 0x06002A3D RID: 10813 RVA: 0x00020530 File Offset: 0x0001E730
		public bool visible
		{
			get
			{
				return this._visible;
			}
			set
			{
				if (this.visible == value)
				{
					return;
				}
				this.kDtpMHNdInXlpiToMbhAlRKyyNsE(value, false);
				this.kVkGtShmkNIevYdutUpliZFCZPDi();
			}
		}

		// Token: 0x170009ED RID: 2541
		// (get) Token: 0x06002A3E RID: 10814 RVA: 0x0002054A File Offset: 0x0001E74A
		// (set) Token: 0x06002A3F RID: 10815 RVA: 0x00020552 File Offset: 0x0001E752
		public TouchInteractable.TransitionTypeFlags transitionType
		{
			get
			{
				return this._transitionType;
			}
			set
			{
				if (this._transitionType == value)
				{
					return;
				}
				this._transitionType = value;
				this.kVkGtShmkNIevYdutUpliZFCZPDi();
			}
		}

		// Token: 0x170009EE RID: 2542
		// (get) Token: 0x06002A40 RID: 10816 RVA: 0x0002056B File Offset: 0x0001E76B
		// (set) Token: 0x06002A41 RID: 10817 RVA: 0x00020573 File Offset: 0x0001E773
		public ColorBlock transitionColorTint
		{
			get
			{
				return this._transitionColorTint;
			}
			set
			{
				this._transitionColorTint = value;
				this.kVkGtShmkNIevYdutUpliZFCZPDi();
			}
		}

		// Token: 0x170009EF RID: 2543
		// (get) Token: 0x06002A42 RID: 10818 RVA: 0x00020582 File Offset: 0x0001E782
		// (set) Token: 0x06002A43 RID: 10819 RVA: 0x0002058A File Offset: 0x0001E78A
		public SpriteState transitionSpriteState
		{
			get
			{
				return this._transitionSpriteState;
			}
			set
			{
				if (this._transitionSpriteState.Equals(value))
				{
					return;
				}
				this._transitionSpriteState = value;
				this.kVkGtShmkNIevYdutUpliZFCZPDi();
			}
		}

		// Token: 0x170009F0 RID: 2544
		// (get) Token: 0x06002A44 RID: 10820 RVA: 0x000205A8 File Offset: 0x0001E7A8
		// (set) Token: 0x06002A45 RID: 10821 RVA: 0x000205B0 File Offset: 0x0001E7B0
		public AnimationTriggers transitionAnimationTriggers
		{
			get
			{
				return this._transitionAnimationTriggers;
			}
			set
			{
				if (this._transitionAnimationTriggers == value)
				{
					return;
				}
				this._transitionAnimationTriggers = value;
				this.kVkGtShmkNIevYdutUpliZFCZPDi();
			}
		}

		// Token: 0x170009F1 RID: 2545
		// (get) Token: 0x06002A46 RID: 10822 RVA: 0x000205C9 File Offset: 0x0001E7C9
		// (set) Token: 0x06002A47 RID: 10823 RVA: 0x000205D1 File Offset: 0x0001E7D1
		public Graphic targetGraphic
		{
			get
			{
				return this._targetGraphic;
			}
			set
			{
				if (this._targetGraphic == value)
				{
					return;
				}
				this._targetGraphic = value;
				this.kVkGtShmkNIevYdutUpliZFCZPDi();
			}
		}

		// Token: 0x170009F2 RID: 2546
		// (get) Token: 0x06002A48 RID: 10824 RVA: 0x000205EF File Offset: 0x0001E7EF
		// (set) Token: 0x06002A49 RID: 10825 RVA: 0x000205F7 File Offset: 0x0001E7F7
		public bool syncFadeDurationWithTransitionEvent
		{
			get
			{
				return this._syncFadeDurationWithTransitionEvent;
			}
			set
			{
				if (this._syncFadeDurationWithTransitionEvent == value)
				{
					return;
				}
				this._syncFadeDurationWithTransitionEvent = value;
				this.kVkGtShmkNIevYdutUpliZFCZPDi();
			}
		}

		// Token: 0x170009F3 RID: 2547
		// (get) Token: 0x06002A4A RID: 10826 RVA: 0x00020610 File Offset: 0x0001E810
		// (set) Token: 0x06002A4B RID: 10827 RVA: 0x00020618 File Offset: 0x0001E818
		public bool syncColorTintWithTransitionEvent
		{
			get
			{
				return this._syncColorTintWithTransitionEvent;
			}
			set
			{
				if (this._syncColorTintWithTransitionEvent == value)
				{
					return;
				}
				this._syncColorTintWithTransitionEvent = value;
				this.kVkGtShmkNIevYdutUpliZFCZPDi();
			}
		}

		// Token: 0x170009F4 RID: 2548
		// (get) Token: 0x06002A4C RID: 10828 RVA: 0x00020631 File Offset: 0x0001E831
		// (set) Token: 0x06002A4D RID: 10829 RVA: 0x000205D1 File Offset: 0x0001E7D1
		public Image image
		{
			get
			{
				return this._targetGraphic as Image;
			}
			set
			{
				if (this._targetGraphic == value)
				{
					return;
				}
				this._targetGraphic = value;
				this.kVkGtShmkNIevYdutUpliZFCZPDi();
			}
		}

		// Token: 0x170009F5 RID: 2549
		// (get) Token: 0x06002A4E RID: 10830 RVA: 0x0001ECDC File Offset: 0x0001CEDC
		public Animator animator
		{
			get
			{
				return base.gameObject.GetComponent<Animator>();
			}
		}

		// Token: 0x06002A4F RID: 10831 RVA: 0x0009AE20 File Offset: 0x00099020
		[CustomObfuscation(rename = false)]
		private TouchInteractableTransitioner()
		{
		}

		// Token: 0x06002A50 RID: 10832 RVA: 0x0002063E File Offset: 0x0001E83E
		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			if (this._targetGraphic == null)
			{
				this._targetGraphic = base.gameObject.GetComponent<Graphic>();
			}
			this.kDtpMHNdInXlpiToMbhAlRKyyNsE(this._visible, true);
		}

		// Token: 0x06002A51 RID: 10833 RVA: 0x00020674 File Offset: 0x0001E874
		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			if (!Application.isPlaying)
			{
				this.kDtpMHNdInXlpiToMbhAlRKyyNsE(this._visible, true);
			}
			this.RPZaFlksqMmmtItRARVImUWMwsxhB(true);
		}

		// Token: 0x06002A52 RID: 10834 RVA: 0x00020691 File Offset: 0x0001E891
		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			this.nfHamrcZynZGgOEhEadDojIYEJFKA();
		}

		// Token: 0x06002A53 RID: 10835 RVA: 0x0009AEB8 File Offset: 0x000990B8
		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			this._transitionColorTint.fadeDuration = Mathf.Max(this._transitionColorTint.fadeDuration, 0f);
			if (UnityTools.IsActiveAndEnabled(this))
			{
				this.FLPueFWhyElDWxJjlJiJORGnnnns(null);
				this.wtTDSycbigkeszlJmkTlLSkhesIRA(Color.white, true);
				this.eZHVyErDyXwrlRyuRBLCTnMuUiox(this._transitionAnimationTriggers.normalTrigger);
				this.RPZaFlksqMmmtItRARVImUWMwsxhB(true);
			}
			this.KKKYJogmTiKHjeTvNqrzXDqoGiub();
		}

		// Token: 0x06002A54 RID: 10836 RVA: 0x00020699 File Offset: 0x0001E899
		[CustomObfuscation(rename = false)]
		private void Reset()
		{
			this._targetGraphic = base.gameObject.GetComponent<Graphic>();
		}

		// Token: 0x06002A55 RID: 10837 RVA: 0x000206AC File Offset: 0x0001E8AC
		[CustomObfuscation(rename = false)]
		private void OnCanvasGroupWasChanged()
		{
			this.KKKYJogmTiKHjeTvNqrzXDqoGiub();
		}

		// Token: 0x06002A56 RID: 10838 RVA: 0x000206AC File Offset: 0x0001E8AC
		[CustomObfuscation(rename = false)]
		private void OnAnimationPropertiesWereApplied()
		{
			this.KKKYJogmTiKHjeTvNqrzXDqoGiub();
		}

		// Token: 0x06002A57 RID: 10839 RVA: 0x000206AC File Offset: 0x0001E8AC
		private void kVkGtShmkNIevYdutUpliZFCZPDi()
		{
			this.KKKYJogmTiKHjeTvNqrzXDqoGiub();
		}

		// Token: 0x06002A58 RID: 10840 RVA: 0x000206B4 File Offset: 0x0001E8B4
		private void KKKYJogmTiKHjeTvNqrzXDqoGiub()
		{
			if (!Application.isPlaying)
			{
				this.RPZaFlksqMmmtItRARVImUWMwsxhB(true);
				return;
			}
			this.RPZaFlksqMmmtItRARVImUWMwsxhB(false);
		}

		// Token: 0x06002A59 RID: 10841 RVA: 0x000206CC File Offset: 0x0001E8CC
		private void RPZaFlksqMmmtItRARVImUWMwsxhB(bool A_1)
		{
			this.OTnbBAagdpWbEhZnubaTVhdsZGlC(this.HbMdtTKOBaVkrkzFyGEeszFonLscA, A_1);
		}

		// Token: 0x06002A5A RID: 10842 RVA: 0x000206DB File Offset: 0x0001E8DB
		private void kDtpMHNdInXlpiToMbhAlRKyyNsE(bool A_1, bool A_2)
		{
			if (this._visible == A_1 && !A_2)
			{
				return;
			}
			this._visible = A_1;
		}

		// Token: 0x06002A5B RID: 10843 RVA: 0x0001D81B File Offset: 0x0001BA1B
		private bool sLzVZbGGrCdIZhUoXNciszQBZPHc()
		{
			return UnityTools.IsActiveAndEnabled(this);
		}

		// Token: 0x06002A5C RID: 10844 RVA: 0x0009AF20 File Offset: 0x00099120
		private void nfHamrcZynZGgOEhEadDojIYEJFKA()
		{
			string normalTrigger = this._transitionAnimationTriggers.normalTrigger;
			if ((this._transitionType & TouchInteractable.TransitionTypeFlags.ColorTint) != TouchInteractable.TransitionTypeFlags.None)
			{
				this.wtTDSycbigkeszlJmkTlLSkhesIRA(Color.white, true);
			}
			if ((this._transitionType & TouchInteractable.TransitionTypeFlags.SpriteSwap) != TouchInteractable.TransitionTypeFlags.None)
			{
				this.FLPueFWhyElDWxJjlJiJORGnnnns(null);
			}
			if ((this._transitionType & TouchInteractable.TransitionTypeFlags.Animation) != TouchInteractable.TransitionTypeFlags.None)
			{
				this.eZHVyErDyXwrlRyuRBLCTnMuUiox(normalTrigger);
			}
		}

		// Token: 0x06002A5D RID: 10845 RVA: 0x0009AF74 File Offset: 0x00099174
		private void OTnbBAagdpWbEhZnubaTVhdsZGlC(TouchInteractable.InteractionState A_1, bool A_2)
		{
			Color color;
			Sprite sprite;
			string text;
			switch (A_1)
			{
			case TouchInteractable.InteractionState.Normal:
				color = this._transitionColorTint.normalColor;
				sprite = null;
				text = this._transitionAnimationTriggers.normalTrigger;
				break;
			case TouchInteractable.InteractionState.Highlighted:
				color = this._transitionColorTint.highlightedColor;
				sprite = this._transitionSpriteState.highlightedSprite;
				text = this._transitionAnimationTriggers.highlightedTrigger;
				break;
			case TouchInteractable.InteractionState.Pressed:
				color = this._transitionColorTint.pressedColor;
				sprite = this._transitionSpriteState.pressedSprite;
				text = this._transitionAnimationTriggers.pressedTrigger;
				break;
			case TouchInteractable.InteractionState.Disabled:
				color = this._transitionColorTint.disabledColor;
				sprite = this._transitionSpriteState.disabledSprite;
				text = this._transitionAnimationTriggers.disabledTrigger;
				break;
			default:
				color = Color.black;
				sprite = null;
				text = string.Empty;
				break;
			}
			bool flag = (this._transitionType & TouchInteractable.TransitionTypeFlags.ColorTint) > TouchInteractable.TransitionTypeFlags.None;
			if (!flag)
			{
				color = Color.white;
			}
			if (!this._visible)
			{
				color.a = 0f;
			}
			if (base.gameObject.activeInHierarchy)
			{
				if (flag)
				{
					this.wtTDSycbigkeszlJmkTlLSkhesIRA(color * this._transitionColorTint.colorMultiplier, A_2);
				}
				else
				{
					this.wtTDSycbigkeszlJmkTlLSkhesIRA(color, A_2);
				}
				if ((this._transitionType & TouchInteractable.TransitionTypeFlags.SpriteSwap) != TouchInteractable.TransitionTypeFlags.None)
				{
					this.FLPueFWhyElDWxJjlJiJORGnnnns(sprite);
				}
				if ((this._transitionType & TouchInteractable.TransitionTypeFlags.Animation) != TouchInteractable.TransitionTypeFlags.None)
				{
					this.eZHVyErDyXwrlRyuRBLCTnMuUiox(text);
				}
			}
		}

		// Token: 0x06002A5E RID: 10846 RVA: 0x000206F1 File Offset: 0x0001E8F1
		private void wtTDSycbigkeszlJmkTlLSkhesIRA(Color A_1, bool A_2)
		{
			if (this._targetGraphic == null)
			{
				return;
			}
			this._targetGraphic.CrossFadeColor(A_1, A_2 ? 0f : this._transitionColorTint.fadeDuration, true, true);
		}

		// Token: 0x06002A5F RID: 10847 RVA: 0x00020725 File Offset: 0x0001E925
		private void FLPueFWhyElDWxJjlJiJORGnnnns(Sprite A_1)
		{
			if (this.image == null)
			{
				return;
			}
			this.image.overrideSprite = A_1;
		}

		// Token: 0x06002A60 RID: 10848 RVA: 0x0009B0B8 File Offset: 0x000992B8
		private void eZHVyErDyXwrlRyuRBLCTnMuUiox(string A_1)
		{
			if ((this._transitionType & TouchInteractable.TransitionTypeFlags.Animation) == TouchInteractable.TransitionTypeFlags.None || this.animator == null || !UnityTools.IsActiveAndEnabled(this.animator) || this.animator.runtimeAnimatorController == null || string.IsNullOrEmpty(A_1))
			{
				return;
			}
			this.animator.ResetTrigger(this._transitionAnimationTriggers.normalTrigger);
			this.animator.ResetTrigger(this._transitionAnimationTriggers.pressedTrigger);
			this.animator.ResetTrigger(this._transitionAnimationTriggers.highlightedTrigger);
			this.animator.ResetTrigger(this._transitionAnimationTriggers.disabledTrigger);
			this.animator.SetTrigger(A_1);
		}

		// Token: 0x06002A61 RID: 10849 RVA: 0x0009B16C File Offset: 0x0009936C
		public void OnInteractionStateTransition(TouchInteractable.InteractionStateTransitionArgs args)
		{
			this.HbMdtTKOBaVkrkzFyGEeszFonLscA = args.state;
			if (this._syncFadeDurationWithTransitionEvent)
			{
				this._transitionColorTint.fadeDuration = args.duration;
			}
			if (this._syncColorTintWithTransitionEvent)
			{
				if ((this._transitionType & TouchInteractable.TransitionTypeFlags.ColorTint) == TouchInteractable.TransitionTypeFlags.None)
				{
					this._transitionType |= TouchInteractable.TransitionTypeFlags.ColorTint;
				}
				if (args.sender != null)
				{
					this._transitionColorTint = args.sender.transitionColorTint;
				}
			}
			if (Application.isPlaying)
			{
				this.RPZaFlksqMmmtItRARVImUWMwsxhB(false);
				return;
			}
			this.OnValidate();
		}

		// Token: 0x06002A62 RID: 10850 RVA: 0x00020742 File Offset: 0x0001E942
		public void OnVisibilityChanged(bool state)
		{
			this.visible = state;
		}

		// Token: 0x04001855 RID: 6229
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Toggles visibility. An invisible control can still be interacted with. This property only has any effect when used with an Image Component.")]
		private bool _visible = true;

		// Token: 0x04001856 RID: 6230
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The transition type(s) to be used when transitioning to various states. Multiple transition types can be used simultaneously.")]
		[Bitmask(typeof(TouchInteractable.TransitionTypeFlags))]
		private TouchInteractable.TransitionTypeFlags _transitionType;

		// Token: 0x04001857 RID: 6231
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Settings using for Color Tint transitions.")]
		private ColorBlock _transitionColorTint = new ColorBlock
		{
			colorMultiplier = 1f,
			disabledColor = new Color(0.78125f, 0.78125f, 0.78125f, 0.5f),
			highlightedColor = Color.white,
			normalColor = Color.white,
			pressedColor = Color.white,
			fadeDuration = 0.1f
		};

		// Token: 0x04001858 RID: 6232
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Settings using for Sprite State transitions.")]
		private SpriteState _transitionSpriteState;

		// Token: 0x04001859 RID: 6233
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Settings using for Animation Trigger transitions.")]
		private AnimationTriggers _transitionAnimationTriggers = new AnimationTriggers();

		// Token: 0x0400185A RID: 6234
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The target Graphic component for interaction state transitions. This should normally be set to an Image component on this GameObject.")]
		private Graphic _targetGraphic;

		// Token: 0x0400185B RID: 6235
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Toggles whether the fade duration is set by incoming transition events. If enabled, the duration of fades for visibility and Color Tint transitions will be synchronized with the event sender.")]
		private bool _syncFadeDurationWithTransitionEvent = true;

		// Token: 0x0400185C RID: 6236
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Toggles whether the color tint is set by incoming transition events. If enabled, the color tint transition of the event sender will override any color tint setting here. This setting overrides Sync Fade Duration With Transition Event.")]
		private bool _syncColorTintWithTransitionEvent;

		// Token: 0x0400185D RID: 6237
		private TouchInteractable.InteractionState HbMdtTKOBaVkrkzFyGEeszFonLscA;
	}
}
