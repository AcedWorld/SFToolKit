using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Unity.VisualScripting
{
	// Token: 0x020000B7 RID: 183
	[AddComponentMenu("")]
	[Obsolete("UnityMessageListener is deprecated and has been replaced by separate message listeners for each event, eg. UnityOnCollisionEnterMessageListener or UnityOnButtonClickMessageListener.")]
	public sealed class UnityMessageListener : MessageListener, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IScrollHandler, ISelectHandler, IDeselectHandler, ISubmitHandler, ICancelHandler, IMoveHandler
	{
		// Token: 0x06000445 RID: 1093 RVA: 0x00009CEA File Offset: 0x00007EEA
		private void Start()
		{
			this.AddGUIListeners();
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x00009CF4 File Offset: 0x00007EF4
		public void AddGUIListeners()
		{
			Button component = base.GetComponent<Button>();
			if (component != null)
			{
				Button.ButtonClickedEvent onClick = component.onClick;
				if (onClick != null)
				{
					onClick.AddListener(delegate()
					{
						EventBus.Trigger("OnButtonClick", base.gameObject);
					});
				}
			}
			Toggle component2 = base.GetComponent<Toggle>();
			if (component2 != null)
			{
				Toggle.ToggleEvent onValueChanged = component2.onValueChanged;
				if (onValueChanged != null)
				{
					onValueChanged.AddListener(delegate(bool value)
					{
						EventBus.Trigger<bool>("OnToggleValueChanged", base.gameObject, value);
					});
				}
			}
			Slider component3 = base.GetComponent<Slider>();
			if (component3 != null)
			{
				Slider.SliderEvent onValueChanged2 = component3.onValueChanged;
				if (onValueChanged2 != null)
				{
					onValueChanged2.AddListener(delegate(float value)
					{
						EventBus.Trigger<float>("OnSliderValueChanged", base.gameObject, value);
					});
				}
			}
			Scrollbar component4 = base.GetComponent<Scrollbar>();
			if (component4 != null)
			{
				Scrollbar.ScrollEvent onValueChanged3 = component4.onValueChanged;
				if (onValueChanged3 != null)
				{
					onValueChanged3.AddListener(delegate(float value)
					{
						EventBus.Trigger<float>("OnScrollbarValueChanged", base.gameObject, value);
					});
				}
			}
			Dropdown component5 = base.GetComponent<Dropdown>();
			if (component5 != null)
			{
				Dropdown.DropdownEvent onValueChanged4 = component5.onValueChanged;
				if (onValueChanged4 != null)
				{
					onValueChanged4.AddListener(delegate(int value)
					{
						EventBus.Trigger<int>("OnDropdownValueChanged", base.gameObject, value);
					});
				}
			}
			InputField component6 = base.GetComponent<InputField>();
			if (component6 != null)
			{
				InputField.OnChangeEvent onValueChanged5 = component6.onValueChanged;
				if (onValueChanged5 != null)
				{
					onValueChanged5.AddListener(delegate(string value)
					{
						EventBus.Trigger<string>("OnInputFieldValueChanged", base.gameObject, value);
					});
				}
			}
			InputField component7 = base.GetComponent<InputField>();
			if (component7 != null)
			{
				InputField.EndEditEvent onEndEdit = component7.onEndEdit;
				if (onEndEdit != null)
				{
					onEndEdit.AddListener(delegate(string value)
					{
						EventBus.Trigger<string>("OnInputFieldEndEdit", base.gameObject, value);
					});
				}
			}
			ScrollRect component8 = base.GetComponent<ScrollRect>();
			if (component8 == null)
			{
				return;
			}
			ScrollRect.ScrollRectEvent onValueChanged6 = component8.onValueChanged;
			if (onValueChanged6 == null)
			{
				return;
			}
			onValueChanged6.AddListener(delegate(Vector2 value)
			{
				EventBus.Trigger<Vector2>("OnScrollRectValueChanged", base.gameObject, value);
			});
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x00009E3F File Offset: 0x0000803F
		public void OnPointerEnter(PointerEventData eventData)
		{
			EventBus.Trigger<PointerEventData>("OnPointerEnter", base.gameObject, eventData);
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x00009E52 File Offset: 0x00008052
		public void OnPointerExit(PointerEventData eventData)
		{
			EventBus.Trigger<PointerEventData>("OnPointerExit", base.gameObject, eventData);
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x00009E65 File Offset: 0x00008065
		public void OnPointerDown(PointerEventData eventData)
		{
			EventBus.Trigger<PointerEventData>("OnPointerDown", base.gameObject, eventData);
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x00009E78 File Offset: 0x00008078
		public void OnPointerUp(PointerEventData eventData)
		{
			EventBus.Trigger<PointerEventData>("OnPointerUp", base.gameObject, eventData);
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x00009E8B File Offset: 0x0000808B
		public void OnPointerClick(PointerEventData eventData)
		{
			EventBus.Trigger<PointerEventData>("OnPointerClick", base.gameObject, eventData);
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x00009E9E File Offset: 0x0000809E
		public void OnBeginDrag(PointerEventData eventData)
		{
			EventBus.Trigger<PointerEventData>("OnBeginDrag", base.gameObject, eventData);
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x00009EB1 File Offset: 0x000080B1
		public void OnDrag(PointerEventData eventData)
		{
			EventBus.Trigger<PointerEventData>("OnDrag", base.gameObject, eventData);
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x00009EC4 File Offset: 0x000080C4
		public void OnEndDrag(PointerEventData eventData)
		{
			EventBus.Trigger<PointerEventData>("OnEndDrag", base.gameObject, eventData);
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x00009ED7 File Offset: 0x000080D7
		public void OnDrop(PointerEventData eventData)
		{
			EventBus.Trigger<PointerEventData>("OnDrop", base.gameObject, eventData);
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x00009EEA File Offset: 0x000080EA
		public void OnScroll(PointerEventData eventData)
		{
			EventBus.Trigger<PointerEventData>("OnScroll", base.gameObject, eventData);
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x00009EFD File Offset: 0x000080FD
		public void OnSelect(BaseEventData eventData)
		{
			EventBus.Trigger<BaseEventData>("OnSelect", base.gameObject, eventData);
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x00009F10 File Offset: 0x00008110
		public void OnDeselect(BaseEventData eventData)
		{
			EventBus.Trigger<BaseEventData>("OnDeselect", base.gameObject, eventData);
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x00009F23 File Offset: 0x00008123
		public void OnSubmit(BaseEventData eventData)
		{
			EventBus.Trigger<BaseEventData>("OnSubmit", base.gameObject, eventData);
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x00009F36 File Offset: 0x00008136
		public void OnCancel(BaseEventData eventData)
		{
			EventBus.Trigger<BaseEventData>("OnCancel", base.gameObject, eventData);
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x00009F49 File Offset: 0x00008149
		public void OnMove(AxisEventData eventData)
		{
			EventBus.Trigger<AxisEventData>("OnMove", base.gameObject, eventData);
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x00009F5C File Offset: 0x0000815C
		private void OnBecameInvisible()
		{
			EventBus.Trigger("OnBecameInvisible", base.gameObject);
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x00009F6E File Offset: 0x0000816E
		private void OnBecameVisible()
		{
			EventBus.Trigger("OnBecameVisible", base.gameObject);
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x00009F80 File Offset: 0x00008180
		private void OnCollisionEnter(Collision collision)
		{
			EventBus.Trigger<Collision>("OnCollisionEnter", base.gameObject, collision);
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x00009F93 File Offset: 0x00008193
		private void OnCollisionExit(Collision collision)
		{
			EventBus.Trigger<Collision>("OnCollisionExit", base.gameObject, collision);
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x00009FA6 File Offset: 0x000081A6
		private void OnCollisionStay(Collision collision)
		{
			EventBus.Trigger<Collision>("OnCollisionStay", base.gameObject, collision);
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x00009FB9 File Offset: 0x000081B9
		private void OnCollisionEnter2D(Collision2D collision)
		{
			EventBus.Trigger<Collision2D>("OnCollisionEnter2D", base.gameObject, collision);
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x00009FCC File Offset: 0x000081CC
		private void OnCollisionExit2D(Collision2D collision)
		{
			EventBus.Trigger<Collision2D>("OnCollisionExit2D", base.gameObject, collision);
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x00009FDF File Offset: 0x000081DF
		private void OnCollisionStay2D(Collision2D collision)
		{
			EventBus.Trigger<Collision2D>("OnCollisionStay2D", base.gameObject, collision);
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x00009FF2 File Offset: 0x000081F2
		private void OnControllerColliderHit(ControllerColliderHit hit)
		{
			EventBus.Trigger<ControllerColliderHit>("OnControllerColliderHit", base.gameObject, hit);
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x0000A005 File Offset: 0x00008205
		private void OnJointBreak(float breakForce)
		{
			EventBus.Trigger<float>("OnJointBreak", base.gameObject, breakForce);
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x0000A018 File Offset: 0x00008218
		private void OnJointBreak2D(Joint2D brokenJoint)
		{
			EventBus.Trigger<Joint2D>("OnJointBreak2D", base.gameObject, brokenJoint);
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x0000A02B File Offset: 0x0000822B
		private void OnMouseDown()
		{
			EventBus.Trigger("OnMouseDown", base.gameObject);
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x0000A03D File Offset: 0x0000823D
		private void OnMouseDrag()
		{
			EventBus.Trigger("OnMouseDrag", base.gameObject);
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x0000A04F File Offset: 0x0000824F
		private void OnMouseEnter()
		{
			EventBus.Trigger("OnMouseEnter", base.gameObject);
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x0000A061 File Offset: 0x00008261
		private void OnMouseExit()
		{
			EventBus.Trigger("OnMouseExit", base.gameObject);
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x0000A073 File Offset: 0x00008273
		private void OnMouseOver()
		{
			EventBus.Trigger("OnMouseOver", base.gameObject);
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x0000A085 File Offset: 0x00008285
		private void OnMouseUp()
		{
			EventBus.Trigger("OnMouseUp", base.gameObject);
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x0000A097 File Offset: 0x00008297
		private void OnMouseUpAsButton()
		{
			EventBus.Trigger("OnMouseUpAsButton", base.gameObject);
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x0000A0A9 File Offset: 0x000082A9
		private void OnParticleCollision(GameObject other)
		{
			EventBus.Trigger<GameObject>("OnParticleCollision", base.gameObject, other);
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x0000A0BC File Offset: 0x000082BC
		private void OnTransformChildrenChanged()
		{
			EventBus.Trigger("OnTransformChildrenChanged", base.gameObject);
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x0000A0CE File Offset: 0x000082CE
		private void OnTransformParentChanged()
		{
			EventBus.Trigger("OnTransformParentChanged", base.gameObject);
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x0000A0E0 File Offset: 0x000082E0
		private void OnTriggerEnter(Collider other)
		{
			EventBus.Trigger<Collider>("OnTriggerEnter", base.gameObject, other);
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x0000A0F3 File Offset: 0x000082F3
		private void OnTriggerExit(Collider other)
		{
			EventBus.Trigger<Collider>("OnTriggerExit", base.gameObject, other);
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x0000A106 File Offset: 0x00008306
		private void OnTriggerStay(Collider other)
		{
			EventBus.Trigger<Collider>("OnTriggerStay", base.gameObject, other);
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x0000A119 File Offset: 0x00008319
		private void OnTriggerEnter2D(Collider2D other)
		{
			EventBus.Trigger<Collider2D>("OnTriggerEnter2D", base.gameObject, other);
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x0000A12C File Offset: 0x0000832C
		private void OnTriggerExit2D(Collider2D other)
		{
			EventBus.Trigger<Collider2D>("OnTriggerExit2D", base.gameObject, other);
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x0000A13F File Offset: 0x0000833F
		private void OnTriggerStay2D(Collider2D other)
		{
			EventBus.Trigger<Collider2D>("OnTriggerStay2D", base.gameObject, other);
		}
	}
}
