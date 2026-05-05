using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
	// Token: 0x0200003B RID: 59
	[AddComponentMenu("UI/Toggle", 30)]
	[RequireComponent(typeof(RectTransform))]
	public class Toggle : Selectable, IPointerClickHandler, IEventSystemHandler, ISubmitHandler, ICanvasElement
	{
		// Token: 0x1700013B RID: 315
		// (get) Token: 0x0600046F RID: 1135 RVA: 0x000159D4 File Offset: 0x00013BD4
		// (set) Token: 0x06000470 RID: 1136 RVA: 0x000159DC File Offset: 0x00013BDC
		public ToggleGroup group
		{
			get
			{
				return this.m_Group;
			}
			set
			{
				this.SetToggleGroup(value, true);
				this.PlayEffect(true);
			}
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x000159ED File Offset: 0x00013BED
		protected Toggle()
		{
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x00015A07 File Offset: 0x00013C07
		public virtual void Rebuild(CanvasUpdate executing)
		{
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x00015A09 File Offset: 0x00013C09
		public virtual void LayoutComplete()
		{
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x00015A0B File Offset: 0x00013C0B
		public virtual void GraphicUpdateComplete()
		{
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x00015A0D File Offset: 0x00013C0D
		protected override void OnDestroy()
		{
			if (this.m_Group != null)
			{
				this.m_Group.EnsureValidState();
			}
			base.OnDestroy();
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x00015A2E File Offset: 0x00013C2E
		protected override void OnEnable()
		{
			base.OnEnable();
			this.SetToggleGroup(this.m_Group, false);
			this.PlayEffect(true);
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x00015A4A File Offset: 0x00013C4A
		protected override void OnDisable()
		{
			this.SetToggleGroup(null, false);
			base.OnDisable();
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x00015A5C File Offset: 0x00013C5C
		protected override void OnDidApplyAnimationProperties()
		{
			if (this.graphic != null)
			{
				bool flag = !Mathf.Approximately(this.graphic.canvasRenderer.GetColor().a, 0f);
				if (this.m_IsOn != flag)
				{
					this.m_IsOn = flag;
					this.Set(!flag, true);
				}
			}
			base.OnDidApplyAnimationProperties();
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x00015ABC File Offset: 0x00013CBC
		private void SetToggleGroup(ToggleGroup newGroup, bool setMemberValue)
		{
			if (this.m_Group != null)
			{
				this.m_Group.UnregisterToggle(this);
			}
			if (setMemberValue)
			{
				this.m_Group = newGroup;
			}
			if (newGroup != null && this.IsActive())
			{
				newGroup.RegisterToggle(this);
			}
			if (newGroup != null && this.isOn && this.IsActive())
			{
				newGroup.NotifyToggleOn(this, true);
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x0600047A RID: 1146 RVA: 0x00015B26 File Offset: 0x00013D26
		// (set) Token: 0x0600047B RID: 1147 RVA: 0x00015B2E File Offset: 0x00013D2E
		public bool isOn
		{
			get
			{
				return this.m_IsOn;
			}
			set
			{
				this.Set(value, true);
			}
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x00015B38 File Offset: 0x00013D38
		public void SetIsOnWithoutNotify(bool value)
		{
			this.Set(value, false);
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x00015B44 File Offset: 0x00013D44
		private void Set(bool value, bool sendCallback = true)
		{
			if (this.m_IsOn == value)
			{
				return;
			}
			this.m_IsOn = value;
			if (this.m_Group != null && this.m_Group.isActiveAndEnabled && this.IsActive() && (this.m_IsOn || (!this.m_Group.AnyTogglesOn() && !this.m_Group.allowSwitchOff)))
			{
				this.m_IsOn = true;
				this.m_Group.NotifyToggleOn(this, sendCallback);
			}
			this.PlayEffect(this.toggleTransition == Toggle.ToggleTransition.None);
			if (sendCallback)
			{
				UISystemProfilerApi.AddMarker("Toggle.value", this);
				this.onValueChanged.Invoke(this.m_IsOn);
			}
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x00015BE9 File Offset: 0x00013DE9
		private void PlayEffect(bool instant)
		{
			if (this.graphic == null)
			{
				return;
			}
			this.graphic.CrossFadeAlpha(this.m_IsOn ? 1f : 0f, instant ? 0f : 0.1f, true);
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x00015C29 File Offset: 0x00013E29
		protected override void Start()
		{
			this.PlayEffect(true);
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x00015C32 File Offset: 0x00013E32
		private void InternalToggle()
		{
			if (!this.IsActive() || !this.IsInteractable())
			{
				return;
			}
			this.isOn = !this.isOn;
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x00015C54 File Offset: 0x00013E54
		public virtual void OnPointerClick(PointerEventData eventData)
		{
			if (eventData.button != PointerEventData.InputButton.Left)
			{
				return;
			}
			this.InternalToggle();
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x00015C65 File Offset: 0x00013E65
		public virtual void OnSubmit(BaseEventData eventData)
		{
			this.InternalToggle();
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x00015C6D File Offset: 0x00013E6D
		Transform ICanvasElement.get_transform()
		{
			return base.transform;
		}

		// Token: 0x04000176 RID: 374
		public Toggle.ToggleTransition toggleTransition = Toggle.ToggleTransition.Fade;

		// Token: 0x04000177 RID: 375
		public Graphic graphic;

		// Token: 0x04000178 RID: 376
		[SerializeField]
		private ToggleGroup m_Group;

		// Token: 0x04000179 RID: 377
		public Toggle.ToggleEvent onValueChanged = new Toggle.ToggleEvent();

		// Token: 0x0400017A RID: 378
		[Tooltip("Is the toggle currently on or off?")]
		[SerializeField]
		private bool m_IsOn;

		// Token: 0x020000B1 RID: 177
		public enum ToggleTransition
		{
			// Token: 0x04000321 RID: 801
			None,
			// Token: 0x04000322 RID: 802
			Fade
		}

		// Token: 0x020000B2 RID: 178
		[Serializable]
		public class ToggleEvent : UnityEvent<bool>
		{
		}
	}
}
