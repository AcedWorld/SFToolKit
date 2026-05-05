using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.UI;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Rewired.ComponentControls
{
	// Token: 0x020003F0 RID: 1008
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	[Serializable]
	public abstract class TouchInteractable : TouchControl, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		// Token: 0x14000041 RID: 65
		// (add) Token: 0x0600288F RID: 10383 RVA: 0x0001EA9B File Offset: 0x0001CC9B
		// (remove) Token: 0x06002890 RID: 10384 RVA: 0x0001EAA9 File Offset: 0x0001CCA9
		public event UnityAction<TouchInteractable.InteractionStateTransitionArgs> InteractionStateSetEvent
		{
			add
			{
				this._onInteractionStateTransition.AddListener(value);
			}
			remove
			{
				this._onInteractionStateTransition.RemoveListener(value);
			}
		}

		// Token: 0x14000042 RID: 66
		// (add) Token: 0x06002891 RID: 10385 RVA: 0x0001EAB7 File Offset: 0x0001CCB7
		// (remove) Token: 0x06002892 RID: 10386 RVA: 0x0001EAC5 File Offset: 0x0001CCC5
		public event UnityAction<bool> VisibilityChangedEvent
		{
			add
			{
				this._onVisibilityChanged.AddListener(value);
			}
			remove
			{
				this._onVisibilityChanged.RemoveListener(value);
			}
		}

		// Token: 0x14000043 RID: 67
		// (add) Token: 0x06002893 RID: 10387 RVA: 0x0001EAD3 File Offset: 0x0001CCD3
		// (remove) Token: 0x06002894 RID: 10388 RVA: 0x0001EAE1 File Offset: 0x0001CCE1
		public event UnityAction InteractionStateChangedToNormal
		{
			add
			{
				this._onInteractionStateChangedToNormal.AddListener(value);
			}
			remove
			{
				this._onInteractionStateChangedToNormal.RemoveListener(value);
			}
		}

		// Token: 0x14000044 RID: 68
		// (add) Token: 0x06002895 RID: 10389 RVA: 0x0001EAEF File Offset: 0x0001CCEF
		// (remove) Token: 0x06002896 RID: 10390 RVA: 0x0001EAFD File Offset: 0x0001CCFD
		public event UnityAction InteractionStateChangedToHighlighted
		{
			add
			{
				this._onInteractionStateChangedToHighlighted.AddListener(value);
			}
			remove
			{
				this._onInteractionStateChangedToHighlighted.RemoveListener(value);
			}
		}

		// Token: 0x14000045 RID: 69
		// (add) Token: 0x06002897 RID: 10391 RVA: 0x0001EB0B File Offset: 0x0001CD0B
		// (remove) Token: 0x06002898 RID: 10392 RVA: 0x0001EB19 File Offset: 0x0001CD19
		public event UnityAction InteractionStateChangedToPressed
		{
			add
			{
				this._onInteractionStateChangedToPressed.AddListener(value);
			}
			remove
			{
				this._onInteractionStateChangedToPressed.RemoveListener(value);
			}
		}

		// Token: 0x14000046 RID: 70
		// (add) Token: 0x06002899 RID: 10393 RVA: 0x0001EB27 File Offset: 0x0001CD27
		// (remove) Token: 0x0600289A RID: 10394 RVA: 0x0001EB35 File Offset: 0x0001CD35
		public event UnityAction InteractionStateChangedToDisabled
		{
			add
			{
				this._onInteractionStateChangedToDisabled.AddListener(value);
			}
			remove
			{
				this._onInteractionStateChangedToDisabled.RemoveListener(value);
			}
		}

		// Token: 0x1700098A RID: 2442
		// (get) Token: 0x0600289B RID: 10395 RVA: 0x0001EB43 File Offset: 0x0001CD43
		private XrIMSkNxqAoGxuGHleqpKZoRJxbk.HierarchyEventHelper<IVisibilityChangedHandler, bool> LmtAeCgcYDJgiELFUeKozetsVDcQ
		{
			get
			{
				if (this.__hierarchyVisibilityChangedHandlers == null)
				{
					this.__hierarchyVisibilityChangedHandlers = new XrIMSkNxqAoGxuGHleqpKZoRJxbk.HierarchyEventHelper<IVisibilityChangedHandler, bool>(nMxsjgnmIFBFpjQvAxyRNLyyJJtFA.AyDldaWdffdORFVFjjKhwqWhpxHA);
					this.__hierarchyVisibilityChangedHandlers.GetHandlers(base.transform);
				}
				return this.__hierarchyVisibilityChangedHandlers;
			}
		}

		// Token: 0x1700098B RID: 2443
		// (get) Token: 0x0600289C RID: 10396 RVA: 0x0001EB74 File Offset: 0x0001CD74
		private XrIMSkNxqAoGxuGHleqpKZoRJxbk.HierarchyEventHelper<TouchInteractable.IInteractionStateTransitionHandler, TouchInteractable.InteractionStateTransitionArgs> NqnuAruBqqrLZmwKqPGOsxfAeKSt
		{
			get
			{
				if (this.__hierarchyInteractionStateTransitionHandlers == null)
				{
					this.__hierarchyInteractionStateTransitionHandlers = new XrIMSkNxqAoGxuGHleqpKZoRJxbk.HierarchyEventHelper<TouchInteractable.IInteractionStateTransitionHandler, TouchInteractable.InteractionStateTransitionArgs>(TouchInteractable.xKahcyjajynmzqHFtMkvGTLCKLbG);
					this.__hierarchyInteractionStateTransitionHandlers.GetHandlers(base.transform);
				}
				return this.__hierarchyInteractionStateTransitionHandlers;
			}
		}

		// Token: 0x1700098C RID: 2444
		// (get) Token: 0x0600289D RID: 10397 RVA: 0x0001EBA5 File Offset: 0x0001CDA5
		// (set) Token: 0x0600289E RID: 10398 RVA: 0x0001EBAD File Offset: 0x0001CDAD
		public bool interactable
		{
			get
			{
				return this._interactable;
			}
			set
			{
				if (this._interactable == value)
				{
					return;
				}
				this._interactable = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x1700098D RID: 2445
		// (get) Token: 0x0600289F RID: 10399 RVA: 0x0001EBC6 File Offset: 0x0001CDC6
		// (set) Token: 0x060028A0 RID: 10400 RVA: 0x0001EBCE File Offset: 0x0001CDCE
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
				this.lQsxawsIPCjBwwhEiwcEakteSogg(value, false);
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x1700098E RID: 2446
		// (get) Token: 0x060028A1 RID: 10401 RVA: 0x0001EBE8 File Offset: 0x0001CDE8
		// (set) Token: 0x060028A2 RID: 10402 RVA: 0x0001EBF0 File Offset: 0x0001CDF0
		public bool hideWhenIdle
		{
			get
			{
				return this._hideWhenIdle;
			}
			set
			{
				if (this._hideWhenIdle == value)
				{
					return;
				}
				this._hideWhenIdle = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x1700098F RID: 2447
		// (get) Token: 0x060028A3 RID: 10403 RVA: 0x0001EC09 File Offset: 0x0001CE09
		// (set) Token: 0x060028A4 RID: 10404 RVA: 0x0001EC11 File Offset: 0x0001CE11
		public TouchInteractable.MouseButtonFlags allowedMouseButtons
		{
			get
			{
				return this._allowedMouseButtons;
			}
			set
			{
				if (this._allowedMouseButtons == value)
				{
					return;
				}
				this._allowedMouseButtons = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x17000990 RID: 2448
		// (get) Token: 0x060028A5 RID: 10405 RVA: 0x0001EC2A File Offset: 0x0001CE2A
		// (set) Token: 0x060028A6 RID: 10406 RVA: 0x0001EC32 File Offset: 0x0001CE32
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
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x17000991 RID: 2449
		// (get) Token: 0x060028A7 RID: 10407 RVA: 0x0001EC4B File Offset: 0x0001CE4B
		// (set) Token: 0x060028A8 RID: 10408 RVA: 0x0001EC53 File Offset: 0x0001CE53
		public ColorBlock transitionColorTint
		{
			get
			{
				return this._transitionColorTint;
			}
			set
			{
				this._transitionColorTint = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x17000992 RID: 2450
		// (get) Token: 0x060028A9 RID: 10409 RVA: 0x0001EC62 File Offset: 0x0001CE62
		// (set) Token: 0x060028AA RID: 10410 RVA: 0x0001EC6A File Offset: 0x0001CE6A
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
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x17000993 RID: 2451
		// (get) Token: 0x060028AB RID: 10411 RVA: 0x0001EC88 File Offset: 0x0001CE88
		// (set) Token: 0x060028AC RID: 10412 RVA: 0x0001EC90 File Offset: 0x0001CE90
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
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x17000994 RID: 2452
		// (get) Token: 0x060028AD RID: 10413 RVA: 0x0001ECA9 File Offset: 0x0001CEA9
		// (set) Token: 0x060028AE RID: 10414 RVA: 0x0001ECB1 File Offset: 0x0001CEB1
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
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x17000995 RID: 2453
		// (get) Token: 0x060028AF RID: 10415 RVA: 0x0001ECCF File Offset: 0x0001CECF
		// (set) Token: 0x060028B0 RID: 10416 RVA: 0x0001ECB1 File Offset: 0x0001CEB1
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
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x17000996 RID: 2454
		// (get) Token: 0x060028B1 RID: 10417 RVA: 0x0001ECDC File Offset: 0x0001CEDC
		public Animator animator
		{
			get
			{
				return base.gameObject.GetComponent<Animator>();
			}
		}

		// Token: 0x17000997 RID: 2455
		// (get) Token: 0x060028B2 RID: 10418 RVA: 0x0001ECE9 File Offset: 0x0001CEE9
		public TouchInteractable.InteractionState interactionState
		{
			get
			{
				return this._interactionState;
			}
		}

		// Token: 0x060028B3 RID: 10419 RVA: 0x000976A8 File Offset: 0x000958A8
		[CustomObfuscation(rename = false)]
		internal TouchInteractable()
		{
		}

		// Token: 0x060028B4 RID: 10420 RVA: 0x0001ECF1 File Offset: 0x0001CEF1
		[CustomObfuscation(rename = false)]
		internal override void Awake()
		{
			base.Awake();
			if (!Application.isPlaying)
			{
				return;
			}
			if (this._targetGraphic == null)
			{
				this._targetGraphic = base.gameObject.GetComponent<Graphic>();
			}
			this.fBBvAVIFNpUdfKnIvmIwJvUVACjl();
		}

		// Token: 0x060028B5 RID: 10421 RVA: 0x000977A4 File Offset: 0x000959A4
		[CustomObfuscation(rename = false)]
		internal override void OnCanvasGroupChanged()
		{
			base.OnCanvasGroupChanged();
			bool flag = true;
			Transform transform = base.transform;
			while (transform != null)
			{
				transform.GetComponents<CanvasGroup>(this._canvasGroupCache);
				bool flag2 = false;
				for (int i = 0; i < this._canvasGroupCache.Count; i++)
				{
					if (!this._canvasGroupCache[i].interactable)
					{
						flag = false;
						flag2 = true;
					}
					if (this._canvasGroupCache[i].ignoreParentGroups)
					{
						flag2 = true;
					}
				}
				if (flag2)
				{
					break;
				}
				transform = transform.parent;
			}
			if (flag != this._groupsAllowInteraction)
			{
				this._groupsAllowInteraction = flag;
				this.eohOfeFwLJUBqrDofMqWIjzKQhSm();
			}
		}

		// Token: 0x060028B6 RID: 10422 RVA: 0x0001ED26 File Offset: 0x0001CF26
		[CustomObfuscation(rename = false)]
		internal override void OnDidApplyAnimationProperties()
		{
			base.OnDidApplyAnimationProperties();
			this.eohOfeFwLJUBqrDofMqWIjzKQhSm();
		}

		// Token: 0x060028B7 RID: 10423 RVA: 0x0001ED34 File Offset: 0x0001CF34
		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			if (!Application.isPlaying)
			{
				this.fBBvAVIFNpUdfKnIvmIwJvUVACjl();
			}
			this.qMbZFSbidbhrGONpkiuHCnqRCEIzA(TouchInteractable.InteractionState.Normal);
			this.LmycLBykOjDIQbBzUnmMElUKHGENc(true);
		}

		// Token: 0x060028B8 RID: 10424 RVA: 0x0001ED58 File Offset: 0x0001CF58
		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			this.ZtJklQWiuIRsvBedKAyOLKwnaEIb();
			base.OnDisable();
		}

		// Token: 0x060028B9 RID: 10425 RVA: 0x0009783C File Offset: 0x00095A3C
		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			this._transitionColorTint.fadeDuration = Mathf.Max(this._transitionColorTint.fadeDuration, 0f);
			if (base.IUGIIGfBqvDUFgNIMGdfUHjibbKRA())
			{
				if (!this._interactable && EventSystem.current != null && EventSystem.current.currentSelectedGameObject == base.gameObject)
				{
					EventSystem.current.SetSelectedGameObject(null);
				}
				this.GdPgWiJnnGYoJlUdpAYWUEyKrDSO(null);
				this.LUMDRNpesPPmzfKokrolxNjMhihiA(Color.white, true);
				this.ywJpMpKAMkPpELIdxcaIAItRfbbz(this._transitionAnimationTriggers.normalTrigger);
				this.LmycLBykOjDIQbBzUnmMElUKHGENc(true);
			}
			this.kougABHOYpFVCFxQkmyEXYZbkYqW();
			this.eohOfeFwLJUBqrDofMqWIjzKQhSm();
		}

		// Token: 0x060028BA RID: 10426 RVA: 0x0001ED66 File Offset: 0x0001CF66
		[CustomObfuscation(rename = false)]
		internal override void Reset()
		{
			this._targetGraphic = base.gameObject.GetComponent<Graphic>();
			this._allowedMouseButtons = TouchInteractable.MouseButtonFlags.LeftButton;
			base.Reset();
		}

		// Token: 0x060028BB RID: 10427 RVA: 0x0001ED86 File Offset: 0x0001CF86
		internal virtual void DIrIjbritRrTvPOfPhRMJhhCMvxGA()
		{
			base.vkHJpqpomSVbcZPCwGcxJvuATlcw();
			this.eohOfeFwLJUBqrDofMqWIjzKQhSm();
		}

		// Token: 0x060028BC RID: 10428 RVA: 0x0001ED94 File Offset: 0x0001CF94
		internal virtual void MUlawrgchCgLWJWMYFjmPACJhbWPA()
		{
			base.aldYdGvaUUCtbFsCYThTJjIcModZ();
			this.kougABHOYpFVCFxQkmyEXYZbkYqW();
		}

		// Token: 0x060028BD RID: 10429 RVA: 0x000978E8 File Offset: 0x00095AE8
		private void ZtJklQWiuIRsvBedKAyOLKwnaEIb()
		{
			string normalTrigger = this._transitionAnimationTriggers.normalTrigger;
			this.qwXGlbuXbBcbHJWyaHIFgfokdMQx = false;
			this.uXNnqAsXzOVzfhkENkmbKOCZhDub = false;
			if ((this._transitionType & TouchInteractable.TransitionTypeFlags.ColorTint) != TouchInteractable.TransitionTypeFlags.None)
			{
				this.LUMDRNpesPPmzfKokrolxNjMhihiA(Color.white, true);
			}
			if ((this._transitionType & TouchInteractable.TransitionTypeFlags.SpriteSwap) != TouchInteractable.TransitionTypeFlags.None)
			{
				this.GdPgWiJnnGYoJlUdpAYWUEyKrDSO(null);
			}
			if ((this._transitionType & TouchInteractable.TransitionTypeFlags.Animation) != TouchInteractable.TransitionTypeFlags.None)
			{
				this.ywJpMpKAMkPpELIdxcaIAItRfbbz(normalTrigger);
			}
		}

		// Token: 0x060028BE RID: 10430 RVA: 0x00097948 File Offset: 0x00095B48
		private void OXSpkcUNupUyAdqQFmnTbhDFZIwd(TouchInteractable.InteractionState A_1, bool A_2)
		{
			Color color;
			Sprite sprite;
			string text;
			UnityEvent unityEvent;
			switch (A_1)
			{
			case TouchInteractable.InteractionState.Normal:
				color = this._transitionColorTint.normalColor;
				sprite = null;
				text = this._transitionAnimationTriggers.normalTrigger;
				unityEvent = this._onInteractionStateChangedToNormal;
				break;
			case TouchInteractable.InteractionState.Highlighted:
				color = this._transitionColorTint.highlightedColor;
				sprite = this._transitionSpriteState.highlightedSprite;
				text = this._transitionAnimationTriggers.highlightedTrigger;
				unityEvent = this._onInteractionStateChangedToHighlighted;
				break;
			case TouchInteractable.InteractionState.Pressed:
				color = this._transitionColorTint.pressedColor;
				sprite = this._transitionSpriteState.pressedSprite;
				text = this._transitionAnimationTriggers.pressedTrigger;
				unityEvent = this._onInteractionStateChangedToPressed;
				break;
			case TouchInteractable.InteractionState.Disabled:
				color = this._transitionColorTint.disabledColor;
				sprite = this._transitionSpriteState.disabledSprite;
				text = this._transitionAnimationTriggers.disabledTrigger;
				unityEvent = this._onInteractionStateChangedToDisabled;
				break;
			default:
				color = Color.black;
				sprite = null;
				text = string.Empty;
				unityEvent = null;
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
					this.LUMDRNpesPPmzfKokrolxNjMhihiA(color * this._transitionColorTint.colorMultiplier, A_2);
				}
				else
				{
					this.LUMDRNpesPPmzfKokrolxNjMhihiA(color, A_2);
				}
				if ((this._transitionType & TouchInteractable.TransitionTypeFlags.SpriteSwap) != TouchInteractable.TransitionTypeFlags.None)
				{
					this.GdPgWiJnnGYoJlUdpAYWUEyKrDSO(sprite);
				}
				if ((this._transitionType & TouchInteractable.TransitionTypeFlags.Animation) != TouchInteractable.TransitionTypeFlags.None)
				{
					this.ywJpMpKAMkPpELIdxcaIAItRfbbz(text);
				}
			}
			if (this._allowSendingEvents)
			{
				TouchInteractable._transitionArgs.pmhPoABMGUdwyuiFeYsafdBgsMIA(this, A_1, A_2 ? 0f : this._transitionColorTint.fadeDuration);
				this.NqnuAruBqqrLZmwKqPGOsxfAeKSt.ExecuteOnAll(TouchInteractable._transitionArgs);
				if (this._onInteractionStateTransition != null)
				{
					this._onInteractionStateTransition.Invoke(TouchInteractable._transitionArgs);
				}
				if (unityEvent != null)
				{
					unityEvent.Invoke();
				}
			}
		}

		// Token: 0x060028BF RID: 10431 RVA: 0x0001EDA2 File Offset: 0x0001CFA2
		private void LUMDRNpesPPmzfKokrolxNjMhihiA(Color A_1, bool A_2)
		{
			if (this._targetGraphic == null)
			{
				return;
			}
			this._targetGraphic.CrossFadeColor(A_1, A_2 ? 0f : this._transitionColorTint.fadeDuration, true, true);
		}

		// Token: 0x060028C0 RID: 10432 RVA: 0x0001EDD6 File Offset: 0x0001CFD6
		private void GdPgWiJnnGYoJlUdpAYWUEyKrDSO(Sprite A_1)
		{
			if (this.image == null)
			{
				return;
			}
			this.image.overrideSprite = A_1;
		}

		// Token: 0x060028C1 RID: 10433 RVA: 0x00097B08 File Offset: 0x00095D08
		private void ywJpMpKAMkPpELIdxcaIAItRfbbz(string A_1)
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

		// Token: 0x060028C2 RID: 10434 RVA: 0x00097BBC File Offset: 0x00095DBC
		private void LmycLBykOjDIQbBzUnmMElUKHGENc(bool A_1)
		{
			TouchInteractable.InteractionState interactionState = this._interactionState;
			if (base.IUGIIGfBqvDUFgNIMGdfUHjibbKRA() && !this.IsInteractable())
			{
				interactionState = TouchInteractable.InteractionState.Disabled;
			}
			this.OXSpkcUNupUyAdqQFmnTbhDFZIwd(interactionState, A_1);
		}

		// Token: 0x060028C3 RID: 10435 RVA: 0x0001EDF3 File Offset: 0x0001CFF3
		public bool IsInteractable()
		{
			return this._groupsAllowInteraction && this._interactable;
		}

		// Token: 0x060028C4 RID: 10436 RVA: 0x0001EE05 File Offset: 0x0001D005
		internal virtual bool SpawXIZuWpSSbwFZmQojLpALNFsO()
		{
			return base.IUGIIGfBqvDUFgNIMGdfUHjibbKRA() && this.qwXGlbuXbBcbHJWyaHIFgfokdMQx && this.uXNnqAsXzOVzfhkENkmbKOCZhDub;
		}

		// Token: 0x060028C5 RID: 10437 RVA: 0x00097BEC File Offset: 0x00095DEC
		internal void bQxfVwsHphtKQjTPHonPFeqrEVvE(BaseEventData A_1)
		{
			if (!base.IUGIIGfBqvDUFgNIMGdfUHjibbKRA() || !this.IsInteractable())
			{
				return;
			}
			TouchInteractable.InteractionState interactionState = this.XfgfAeYRddKkEMHlqzskMoXnsGOc(A_1);
			if (interactionState == this._interactionState)
			{
				return;
			}
			this.qMbZFSbidbhrGONpkiuHCnqRCEIzA(interactionState);
			this.LmycLBykOjDIQbBzUnmMElUKHGENc(false);
		}

		// Token: 0x060028C6 RID: 10438 RVA: 0x0001EE21 File Offset: 0x0001D021
		internal virtual bool azuQLFEAbDNvtgPVOdzszMzaxXqC(GameObject A_1)
		{
			return base.gameObject == A_1;
		}

		// Token: 0x060028C7 RID: 10439 RVA: 0x00097C2C File Offset: 0x00095E2C
		private bool jjXsTqAYmLbZEuwMQegyAlyNqQdk(BaseEventData A_1)
		{
			bool flag = A_1 is PointerEventData;
			return this.HAJBMZbwXPSctULMqciUAZmcDDrdA(flag, flag ? (A_1 as PointerEventData).pointerPress : null);
		}

		// Token: 0x060028C8 RID: 10440 RVA: 0x00097C5C File Offset: 0x00095E5C
		private bool HAJBMZbwXPSctULMqciUAZmcDDrdA(bool A_1, GameObject A_2)
		{
			if (!base.IUGIIGfBqvDUFgNIMGdfUHjibbKRA())
			{
				return false;
			}
			if (this.SpawXIZuWpSSbwFZmQojLpALNFsO())
			{
				return false;
			}
			bool flag = false;
			if (A_1)
			{
				flag |= ((this.uXNnqAsXzOVzfhkENkmbKOCZhDub && !this.qwXGlbuXbBcbHJWyaHIFgfokdMQx && this.azuQLFEAbDNvtgPVOdzszMzaxXqC(A_2)) || (!this.uXNnqAsXzOVzfhkENkmbKOCZhDub && this.qwXGlbuXbBcbHJWyaHIFgfokdMQx && this.azuQLFEAbDNvtgPVOdzszMzaxXqC(A_2)) || (!this.uXNnqAsXzOVzfhkENkmbKOCZhDub && this.qwXGlbuXbBcbHJWyaHIFgfokdMQx && A_2 == null));
			}
			else
			{
				flag |= this.qwXGlbuXbBcbHJWyaHIFgfokdMQx;
			}
			return flag;
		}

		// Token: 0x060028C9 RID: 10441 RVA: 0x0001EE2F File Offset: 0x0001D02F
		private TouchInteractable.InteractionState XfgfAeYRddKkEMHlqzskMoXnsGOc(BaseEventData A_1)
		{
			if (this.SpawXIZuWpSSbwFZmQojLpALNFsO())
			{
				return TouchInteractable.InteractionState.Pressed;
			}
			if (this.jjXsTqAYmLbZEuwMQegyAlyNqQdk(A_1))
			{
				return TouchInteractable.InteractionState.Highlighted;
			}
			return TouchInteractable.InteractionState.Normal;
		}

		// Token: 0x060028CA RID: 10442 RVA: 0x0001EE47 File Offset: 0x0001D047
		private bool qMbZFSbidbhrGONpkiuHCnqRCEIzA(TouchInteractable.InteractionState A_1)
		{
			if (this._interactionState == A_1)
			{
				return false;
			}
			this._interactionState = A_1;
			this.AOnRhHZcxMgdWZRoQbQGVUQKcTCcA();
			return true;
		}

		// Token: 0x060028CB RID: 10443 RVA: 0x0001EE62 File Offset: 0x0001D062
		private void AOnRhHZcxMgdWZRoQbQGVUQKcTCcA()
		{
			this.gquygMUfEHADdKhDVwjNLeeylGPjb();
		}

		// Token: 0x060028CC RID: 10444 RVA: 0x0001EE6A File Offset: 0x0001D06A
		private void gquygMUfEHADdKhDVwjNLeeylGPjb()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			if (!this._hideWhenIdle)
			{
				return;
			}
			this.lQsxawsIPCjBwwhEiwcEakteSogg(this._interactionState == TouchInteractable.InteractionState.Pressed, false);
		}

		// Token: 0x060028CD RID: 10445 RVA: 0x00097CE0 File Offset: 0x00095EE0
		private void lQsxawsIPCjBwwhEiwcEakteSogg(bool A_1, bool A_2)
		{
			if (this._visible == A_1 && !A_2)
			{
				return;
			}
			this._visible = A_1;
			this._varWatch_visible = A_1;
			if (this._allowSendingEvents)
			{
				this.LmtAeCgcYDJgiELFUeKozetsVDcQ.ExecuteOnAll(A_1);
				if (this._onVisibilityChanged != null)
				{
					this._onVisibilityChanged.Invoke(A_1);
				}
			}
		}

		// Token: 0x060028CE RID: 10446 RVA: 0x00097D30 File Offset: 0x00095F30
		private void fBBvAVIFNpUdfKnIvmIwJvUVACjl()
		{
			this._varWatch_visible = this._visible;
			this._varWatch_interactable = this.IsInteractable();
			using (new SetAndRestoreVar<bool>(this._allowSendingEvents, false, new Action<bool>(this.JIpQyjwJuqHRRgYnZFiOkCtEWWCj)))
			{
				this.lQsxawsIPCjBwwhEiwcEakteSogg(this._visible, true);
				this.gquygMUfEHADdKhDVwjNLeeylGPjb();
			}
			this.kougABHOYpFVCFxQkmyEXYZbkYqW();
			if (this._allowSendingEvents)
			{
				this.LmtAeCgcYDJgiELFUeKozetsVDcQ.ExecuteOnAll(this._visible);
				if (this._onVisibilityChanged != null)
				{
					this._onVisibilityChanged.Invoke(this._visible);
				}
			}
		}

		// Token: 0x060028CF RID: 10447 RVA: 0x00097DDC File Offset: 0x00095FDC
		private void ZeLfVGaqpDDLlzvgqQNvaRnttnerA()
		{
			if (this._varWatch_visible != this._visible)
			{
				this._varWatch_visible = this._visible;
				if (this._allowSendingEvents && this._onVisibilityChanged != null)
				{
					this.LmtAeCgcYDJgiELFUeKozetsVDcQ.ExecuteOnAll(this._visible);
					this._onVisibilityChanged.Invoke(this._visible);
				}
			}
		}

		// Token: 0x060028D0 RID: 10448 RVA: 0x0001EE8D File Offset: 0x0001D08D
		private void eohOfeFwLJUBqrDofMqWIjzKQhSm()
		{
			this.ZeLfVGaqpDDLlzvgqQNvaRnttnerA();
			this.gquygMUfEHADdKhDVwjNLeeylGPjb();
			if (!Application.isPlaying)
			{
				this.LmycLBykOjDIQbBzUnmMElUKHGENc(true);
				return;
			}
			this.LmycLBykOjDIQbBzUnmMElUKHGENc(false);
		}

		// Token: 0x060028D1 RID: 10449 RVA: 0x0001EEB1 File Offset: 0x0001D0B1
		private void kougABHOYpFVCFxQkmyEXYZbkYqW()
		{
			this.LmtAeCgcYDJgiELFUeKozetsVDcQ.GetHandlers(base.transform);
			this.NqnuAruBqqrLZmwKqPGOsxfAeKSt.GetHandlers(base.transform);
		}

		// Token: 0x060028D2 RID: 10450 RVA: 0x0001EED5 File Offset: 0x0001D0D5
		internal virtual void OnPointerDown(PointerEventData eventData)
		{
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(eventData.pointerId, this._allowedMouseButtons, EventTriggerType.PointerDown))
			{
				return;
			}
			this.uXNnqAsXzOVzfhkENkmbKOCZhDub = true;
			this.bQxfVwsHphtKQjTPHonPFeqrEVvE(eventData);
		}

		// Token: 0x060028D3 RID: 10451 RVA: 0x0001EEFA File Offset: 0x0001D0FA
		internal virtual void OnPointerUp(PointerEventData eventData)
		{
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(eventData.pointerId, this._allowedMouseButtons, EventTriggerType.PointerUp))
			{
				return;
			}
			this.uXNnqAsXzOVzfhkENkmbKOCZhDub = false;
			this.bQxfVwsHphtKQjTPHonPFeqrEVvE(eventData);
		}

		// Token: 0x060028D4 RID: 10452 RVA: 0x0001EF1F File Offset: 0x0001D11F
		internal virtual void OnPointerEnter(PointerEventData eventData)
		{
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(eventData.pointerId, this._allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				return;
			}
			this.qwXGlbuXbBcbHJWyaHIFgfokdMQx = true;
			this.bQxfVwsHphtKQjTPHonPFeqrEVvE(eventData);
		}

		// Token: 0x060028D5 RID: 10453 RVA: 0x0001EF44 File Offset: 0x0001D144
		internal virtual void OnPointerExit(PointerEventData eventData)
		{
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(eventData.pointerId, this._allowedMouseButtons, EventTriggerType.PointerExit))
			{
				return;
			}
			this.qwXGlbuXbBcbHJWyaHIFgfokdMQx = false;
			this.bQxfVwsHphtKQjTPHonPFeqrEVvE(eventData);
		}

		// Token: 0x060028D6 RID: 10454 RVA: 0x0001EF69 File Offset: 0x0001D169
		internal virtual void OnBeginDrag(PointerEventData eventData)
		{
			TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(eventData.pointerId, this._allowedMouseButtons, EventTriggerType.BeginDrag);
		}

		// Token: 0x060028D7 RID: 10455 RVA: 0x0001EF7F File Offset: 0x0001D17F
		internal virtual void OnDrag(PointerEventData eventData)
		{
			TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(eventData.pointerId, this._allowedMouseButtons, EventTriggerType.Drag);
		}

		// Token: 0x060028D8 RID: 10456 RVA: 0x0001EF94 File Offset: 0x0001D194
		internal virtual void OnEndDrag(PointerEventData eventData)
		{
			TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(eventData.pointerId, this._allowedMouseButtons, EventTriggerType.EndDrag);
		}

		// Token: 0x060028D9 RID: 10457 RVA: 0x0001EFAA File Offset: 0x0001D1AA
		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
			this.OnPointerDown(eventData);
		}

		// Token: 0x060028DA RID: 10458 RVA: 0x0001EFB3 File Offset: 0x0001D1B3
		void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
		{
			this.OnPointerUp(eventData);
		}

		// Token: 0x060028DB RID: 10459 RVA: 0x0001EFBC File Offset: 0x0001D1BC
		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
			this.OnPointerEnter(eventData);
		}

		// Token: 0x060028DC RID: 10460 RVA: 0x0001EFC5 File Offset: 0x0001D1C5
		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
			this.OnPointerExit(eventData);
		}

		// Token: 0x060028DD RID: 10461 RVA: 0x0001EFCE File Offset: 0x0001D1CE
		void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
		{
			this.OnBeginDrag(eventData);
		}

		// Token: 0x060028DE RID: 10462 RVA: 0x0001EFD7 File Offset: 0x0001D1D7
		void IDragHandler.OnDrag(PointerEventData eventData)
		{
			this.OnDrag(eventData);
		}

		// Token: 0x060028DF RID: 10463 RVA: 0x0001EFE0 File Offset: 0x0001D1E0
		void IEndDragHandler.OnEndDrag(PointerEventData eventData)
		{
			this.OnEndDrag(eventData);
		}

		// Token: 0x060028E0 RID: 10464 RVA: 0x00097E38 File Offset: 0x00096038
		internal static bool OgkzCYVKiHNqmJCTuwqSbQmVtDFx(int A_0)
		{
			if (A_0 == -2147483648)
			{
				return false;
			}
			if (!TouchInteractable.BPfCcONQMDTOcTiIMuueyAPpzvSi(A_0))
			{
				if (TouchInteractable.aaIbPrCaBllOFcEdgmfZmYUuTIqob(A_0) && Input.mousePresent)
				{
					int num = TouchInteractable.ScdAyxyfEiHKuvdsxVBmUCkuWAtr(A_0);
					if (num >= 0)
					{
						return Input.GetMouseButton(num);
					}
				}
				return false;
			}
			int num2 = TouchInteractable.HfuEnGKPHamdezpCyzmHNgOvrekQ(A_0);
			if (num2 < 0)
			{
				return false;
			}
			Touch touch = Input.GetTouch(num2);
			return touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled;
		}

		// Token: 0x060028E1 RID: 10465 RVA: 0x00097EA8 File Offset: 0x000960A8
		internal static Vector3 ZUnrIQphLGwhXswkmMnPlWvrfTLc(int A_0)
		{
			if (TouchInteractable.BPfCcONQMDTOcTiIMuueyAPpzvSi(A_0))
			{
				int num = TouchInteractable.HfuEnGKPHamdezpCyzmHNgOvrekQ(A_0);
				if (num >= 0 && Input.touchCount > num)
				{
					return Input.touches[num].position;
				}
			}
			else if (TouchInteractable.aaIbPrCaBllOFcEdgmfZmYUuTIqob(A_0) && Input.mousePresent)
			{
				return Input.mousePosition;
			}
			return Vector3.zero;
		}

		// Token: 0x060028E2 RID: 10466 RVA: 0x0001EFE9 File Offset: 0x0001D1E9
		internal static bool BPfCcONQMDTOcTiIMuueyAPpzvSi(int A_0)
		{
			return A_0 >= 0;
		}

		// Token: 0x060028E3 RID: 10467 RVA: 0x0001EFF2 File Offset: 0x0001D1F2
		internal static bool aaIbPrCaBllOFcEdgmfZmYUuTIqob(int A_0)
		{
			return A_0 == -1 || A_0 == -3 || A_0 == -2;
		}

		// Token: 0x060028E4 RID: 10468 RVA: 0x00097F00 File Offset: 0x00096100
		private static int HfuEnGKPHamdezpCyzmHNgOvrekQ(int A_0)
		{
			if (!TouchInteractable.BPfCcONQMDTOcTiIMuueyAPpzvSi(A_0))
			{
				return -1;
			}
			int touchCount = Input.touchCount;
			for (int i = 0; i < touchCount; i++)
			{
				if (Input.GetTouch(i).fingerId == A_0)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x060028E5 RID: 10469 RVA: 0x0001F004 File Offset: 0x0001D204
		internal static bool CWEkpinYrothrsNAtcEFABdaRmgG(TouchInteractable.MouseButtonFlags A_0, int A_1)
		{
			if (TouchInteractable.aaIbPrCaBllOFcEdgmfZmYUuTIqob(A_1))
			{
				if (!Cursor.visible)
				{
					return false;
				}
				if (!Input.mousePresent)
				{
					return false;
				}
			}
			return TouchInteractable.BPfCcONQMDTOcTiIMuueyAPpzvSi(A_1) || TouchInteractable.wnwQLgNCYnpzciBJzXbRWZlwinQx(A_0, A_1);
		}

		// Token: 0x060028E6 RID: 10470 RVA: 0x0001F036 File Offset: 0x0001D236
		private static bool wnwQLgNCYnpzciBJzXbRWZlwinQx(TouchInteractable.MouseButtonFlags A_0, int A_1)
		{
			switch (A_1)
			{
			case -3:
				return (A_0 & TouchInteractable.MouseButtonFlags.MiddleButton) > TouchInteractable.MouseButtonFlags.None;
			case -2:
				return (A_0 & TouchInteractable.MouseButtonFlags.RightButton) > TouchInteractable.MouseButtonFlags.None;
			case -1:
				return (A_0 & TouchInteractable.MouseButtonFlags.LeftButton) > TouchInteractable.MouseButtonFlags.None;
			default:
				return false;
			}
		}

		// Token: 0x060028E7 RID: 10471 RVA: 0x0001F065 File Offset: 0x0001D265
		private static int ScdAyxyfEiHKuvdsxVBmUCkuWAtr(int A_0)
		{
			if (!TouchInteractable.aaIbPrCaBllOFcEdgmfZmYUuTIqob(A_0))
			{
				return -1;
			}
			switch (A_0)
			{
			case -3:
				return 2;
			case -2:
				return 1;
			case -1:
				return 0;
			default:
				return -1;
			}
		}

		// Token: 0x060028E8 RID: 10472 RVA: 0x00097F40 File Offset: 0x00096140
		internal static bool fViPIDXJiFoyaUCiJDHKdMbSRRWeA(TouchInteractable.MouseButtonFlags A_0, out int A_1)
		{
			for (int i = 0; i < 3; i++)
			{
				if ((A_0 & (TouchInteractable.MouseButtonFlags)(1 << i)) != TouchInteractable.MouseButtonFlags.None && Input.GetMouseButton(i))
				{
					A_1 = (i + 1) * -1;
					return true;
				}
			}
			A_1 = int.MinValue;
			return false;
		}

		// Token: 0x060028E9 RID: 10473 RVA: 0x0001F08F File Offset: 0x0001D28F
		internal static bool GaWflnNdJmrlCTtfjBFaofbzwzaK(int A_0, TouchInteractable.MouseButtonFlags A_1, EventTriggerType A_2)
		{
			if (TouchInteractable.aaIbPrCaBllOFcEdgmfZmYUuTIqob(A_0) && (A_2 == EventTriggerType.PointerEnter || A_2 == EventTriggerType.PointerExit) && A_1 != TouchInteractable.MouseButtonFlags.None)
			{
				A_1 |= TouchInteractable.MouseButtonFlags.LeftButton;
			}
			return TouchInteractable.CWEkpinYrothrsNAtcEFABdaRmgG(A_1, A_0);
		}

		// Token: 0x060028EA RID: 10474 RVA: 0x00097F80 File Offset: 0x00096180
		internal static bool ygyrytQEEfuBWjVlJlbtaHrKeHYjA(TouchInteractable.MouseButtonFlags A_0)
		{
			int num;
			return TouchInteractable.fViPIDXJiFoyaUCiJDHKdMbSRRWeA(A_0, out num);
		}

		// Token: 0x17000998 RID: 2456
		// (get) Token: 0x060028EB RID: 10475 RVA: 0x0001F0AF File Offset: 0x0001D2AF
		internal static XrIMSkNxqAoGxuGHleqpKZoRJxbk.EventFunction<TouchInteractable.IInteractionStateTransitionHandler, TouchInteractable.InteractionStateTransitionArgs> xKahcyjajynmzqHFtMkvGTLCKLbG
		{
			get
			{
				if (TouchInteractable.__interactionStateTransitionHandlerDelegate == null)
				{
					TouchInteractable.__interactionStateTransitionHandlerDelegate = new XrIMSkNxqAoGxuGHleqpKZoRJxbk.EventFunction<TouchInteractable.IInteractionStateTransitionHandler, TouchInteractable.InteractionStateTransitionArgs>(TouchInteractable.YOWxvaSOnrIUccnlcxUMAUzDhTjC.<>9.sOdEmudUUgDjbKZfKvHzutOoRzdtA);
				}
				return TouchInteractable.__interactionStateTransitionHandlerDelegate;
			}
		}

		// Token: 0x060028ED RID: 10477 RVA: 0x0001F0ED File Offset: 0x0001D2ED
		[CompilerGenerated]
		private void JIpQyjwJuqHRRgYnZFiOkCtEWWCj(bool A_1)
		{
			this._allowSendingEvents = A_1;
		}

		// Token: 0x04001765 RID: 5989
		public const int POINTER_ID_NULL = -2147483648;

		// Token: 0x04001766 RID: 5990
		public const int POINTER_ID_MOUSE_LEFT_BUTTON = -1;

		// Token: 0x04001767 RID: 5991
		public const int POINTER_ID_MOUSE_RIGHT_BUTTON = -2;

		// Token: 0x04001768 RID: 5992
		public const int POINTER_ID_MOUSE_MIDDLE_BUTTON = -3;

		// Token: 0x04001769 RID: 5993
		internal const int MAX_MOUSE_BUTTONS = 3;

		// Token: 0x0400176A RID: 5994
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Toggles whether the control can be interacted with by the user.")]
		private bool _interactable = true;

		// Token: 0x0400176B RID: 5995
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Toggles visibility. An invisible control can still be interacted with. This property only has any effect when used with an Image Component.")]
		private bool _visible = true;

		// Token: 0x0400176C RID: 5996
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Sets visibility to False when the control is idle. When the control is no longer idle, visibility will be set to True again.")]
		private bool _hideWhenIdle;

		// Token: 0x0400176D RID: 5997
		[Tooltip("The mouse buttons that are allowed to interact with this control.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Bitmask(typeof(TouchInteractable.MouseButtonFlags))]
		private TouchInteractable.MouseButtonFlags _allowedMouseButtons = TouchInteractable.MouseButtonFlags.LeftButton;

		// Token: 0x0400176E RID: 5998
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The transition type(s) to be used when transitioning to various states. Multiple transition types can be used simultaneously.")]
		[Bitmask(typeof(TouchInteractable.TransitionTypeFlags))]
		private TouchInteractable.TransitionTypeFlags _transitionType;

		// Token: 0x0400176F RID: 5999
		[Tooltip("Settings using for Color Tint transitions.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ColorBlock _transitionColorTint = new ColorBlock
		{
			colorMultiplier = 1f,
			disabledColor = new Color(0.78125f, 0.78125f, 0.78125f, 0.5f),
			highlightedColor = Color.white,
			normalColor = Color.white,
			pressedColor = Color.white,
			fadeDuration = 0.1f
		};

		// Token: 0x04001770 RID: 6000
		[Tooltip("Settings using for Sprite State transitions.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private SpriteState _transitionSpriteState;

		// Token: 0x04001771 RID: 6001
		[Tooltip("Settings using for Animation Trigger transitions.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private AnimationTriggers _transitionAnimationTriggers = new AnimationTriggers();

		// Token: 0x04001772 RID: 6002
		[Tooltip("The target Graphic component for interaction state transitions. This should normally be set to an Image component on this GameObject.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Graphic _targetGraphic;

		// Token: 0x04001773 RID: 6003
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the Interaction State changes.")]
		private TouchInteractable.InteractionStateTransitionEventHandler _onInteractionStateTransition = new TouchInteractable.InteractionStateTransitionEventHandler();

		// Token: 0x04001774 RID: 6004
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when visibility changes.")]
		private TouchInteractable.VisibilityChangedEventHandler _onVisibilityChanged = new TouchInteractable.VisibilityChangedEventHandler();

		// Token: 0x04001775 RID: 6005
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when interaction state changes to Normal.")]
		private UnityEvent _onInteractionStateChangedToNormal = new UnityEvent();

		// Token: 0x04001776 RID: 6006
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when interaction state changes to Highlighted.")]
		private UnityEvent _onInteractionStateChangedToHighlighted = new UnityEvent();

		// Token: 0x04001777 RID: 6007
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when interaction state changes to Pressed.")]
		private UnityEvent _onInteractionStateChangedToPressed = new UnityEvent();

		// Token: 0x04001778 RID: 6008
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when interaction state changes to Disabled.")]
		private UnityEvent _onInteractionStateChangedToDisabled = new UnityEvent();

		// Token: 0x04001779 RID: 6009
		private readonly List<CanvasGroup> _canvasGroupCache = new List<CanvasGroup>();

		// Token: 0x0400177A RID: 6010
		private bool _groupsAllowInteraction = true;

		// Token: 0x0400177B RID: 6011
		private TouchInteractable.InteractionState _interactionState;

		// Token: 0x0400177C RID: 6012
		[NonSerialized]
		private bool qwXGlbuXbBcbHJWyaHIFgfokdMQx;

		// Token: 0x0400177D RID: 6013
		[NonSerialized]
		private bool uXNnqAsXzOVzfhkENkmbKOCZhDub;

		// Token: 0x0400177E RID: 6014
		private bool _varWatch_visible;

		// Token: 0x0400177F RID: 6015
		private bool _varWatch_interactable;

		// Token: 0x04001780 RID: 6016
		private bool _allowSendingEvents = true;

		// Token: 0x04001781 RID: 6017
		private static TouchInteractable.InteractionStateTransitionArgs _transitionArgs = new TouchInteractable.InteractionStateTransitionArgs();

		// Token: 0x04001782 RID: 6018
		private XrIMSkNxqAoGxuGHleqpKZoRJxbk.HierarchyEventHelper<IVisibilityChangedHandler, bool> __hierarchyVisibilityChangedHandlers;

		// Token: 0x04001783 RID: 6019
		private XrIMSkNxqAoGxuGHleqpKZoRJxbk.HierarchyEventHelper<TouchInteractable.IInteractionStateTransitionHandler, TouchInteractable.InteractionStateTransitionArgs> __hierarchyInteractionStateTransitionHandlers;

		// Token: 0x04001784 RID: 6020
		private static XrIMSkNxqAoGxuGHleqpKZoRJxbk.EventFunction<TouchInteractable.IInteractionStateTransitionHandler, TouchInteractable.InteractionStateTransitionArgs> __interactionStateTransitionHandlerDelegate;

		// Token: 0x020003F1 RID: 1009
		public enum InteractionState
		{
			// Token: 0x04001786 RID: 6022
			Normal,
			// Token: 0x04001787 RID: 6023
			Highlighted,
			// Token: 0x04001788 RID: 6024
			Pressed,
			// Token: 0x04001789 RID: 6025
			Disabled
		}

		// Token: 0x020003F2 RID: 1010
		[Flags]
		public enum TransitionTypeFlags
		{
			// Token: 0x0400178B RID: 6027
			None = 0,
			// Token: 0x0400178C RID: 6028
			ColorTint = 1,
			// Token: 0x0400178D RID: 6029
			SpriteSwap = 2,
			// Token: 0x0400178E RID: 6030
			Animation = 4
		}

		// Token: 0x020003F3 RID: 1011
		[Flags]
		public enum MouseButtonFlags
		{
			// Token: 0x04001790 RID: 6032
			None = 0,
			// Token: 0x04001791 RID: 6033
			LeftButton = 1,
			// Token: 0x04001792 RID: 6034
			RightButton = 2,
			// Token: 0x04001793 RID: 6035
			MiddleButton = 4,
			// Token: 0x04001794 RID: 6036
			AnyButton = -1
		}

		// Token: 0x020003F4 RID: 1012
		[Serializable]
		public class InteractionStateTransitionEventHandler : UnityEvent<TouchInteractable.InteractionStateTransitionArgs>
		{
		}

		// Token: 0x020003F5 RID: 1013
		[Serializable]
		public class VisibilityChangedEventHandler : UnityEvent<bool>
		{
		}

		// Token: 0x020003F6 RID: 1014
		public class InteractionStateTransitionArgs
		{
			// Token: 0x17000999 RID: 2457
			// (get) Token: 0x060028F0 RID: 10480 RVA: 0x0001F0FE File Offset: 0x0001D2FE
			public TouchInteractable sender
			{
				get
				{
					return this.SFPqMDFETZEQZCgYwucTmCitMBBTA;
				}
			}

			// Token: 0x1700099A RID: 2458
			// (get) Token: 0x060028F1 RID: 10481 RVA: 0x0001F106 File Offset: 0x0001D306
			public TouchInteractable.InteractionState state
			{
				get
				{
					return this.RJAroSjIXBTMHFgjGsoenljiveuS;
				}
			}

			// Token: 0x1700099B RID: 2459
			// (get) Token: 0x060028F2 RID: 10482 RVA: 0x0001F10E File Offset: 0x0001D30E
			public float duration
			{
				get
				{
					return this.MujwEuGfLVDxirJYlrArhyeMRUsh;
				}
			}

			// Token: 0x060028F3 RID: 10483 RVA: 0x000033F4 File Offset: 0x000015F4
			internal InteractionStateTransitionArgs()
			{
			}

			// Token: 0x060028F4 RID: 10484 RVA: 0x0001F116 File Offset: 0x0001D316
			internal void pmhPoABMGUdwyuiFeYsafdBgsMIA(TouchInteractable A_1, TouchInteractable.InteractionState A_2, float A_3)
			{
				this.SFPqMDFETZEQZCgYwucTmCitMBBTA = A_1;
				this.RJAroSjIXBTMHFgjGsoenljiveuS = A_2;
				this.MujwEuGfLVDxirJYlrArhyeMRUsh = A_3;
			}

			// Token: 0x04001795 RID: 6037
			private TouchInteractable SFPqMDFETZEQZCgYwucTmCitMBBTA;

			// Token: 0x04001796 RID: 6038
			private TouchInteractable.InteractionState RJAroSjIXBTMHFgjGsoenljiveuS;

			// Token: 0x04001797 RID: 6039
			private float MujwEuGfLVDxirJYlrArhyeMRUsh;
		}

		// Token: 0x020003F7 RID: 1015
		public interface IInteractionStateTransitionHandler
		{
			// Token: 0x060028F5 RID: 10485
			void OnInteractionStateTransition(TouchInteractable.InteractionStateTransitionArgs data);
		}

		// Token: 0x020003F8 RID: 1016
		[CompilerGenerated]
		[Serializable]
		private sealed class YOWxvaSOnrIUccnlcxUMAUzDhTjC
		{
			// Token: 0x060028F8 RID: 10488 RVA: 0x0001F139 File Offset: 0x0001D339
			internal void sOdEmudUUgDjbKZfKvHzutOoRzdtA(TouchInteractable.IInteractionStateTransitionHandler A_1, TouchInteractable.InteractionStateTransitionArgs A_2)
			{
				A_1.OnInteractionStateTransition(A_2);
			}

			// Token: 0x04001798 RID: 6040
			public static readonly TouchInteractable.YOWxvaSOnrIUccnlcxUMAUzDhTjC <>9 = new TouchInteractable.YOWxvaSOnrIUccnlcxUMAUzDhTjC();

			// Token: 0x04001799 RID: 6041
			public static XrIMSkNxqAoGxuGHleqpKZoRJxbk.EventFunction<TouchInteractable.IInteractionStateTransitionHandler, TouchInteractable.InteractionStateTransitionArgs> <>9__152_0;
		}
	}
}
