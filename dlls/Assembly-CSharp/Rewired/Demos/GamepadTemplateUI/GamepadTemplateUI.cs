using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Demos.GamepadTemplateUI
{
	// Token: 0x020002CC RID: 716
	public class GamepadTemplateUI : MonoBehaviour
	{
		// Token: 0x1700030A RID: 778
		// (get) Token: 0x06000F27 RID: 3879 RVA: 0x00051346 File Offset: 0x0004F546
		private Player player
		{
			get
			{
				return ReInput.players.GetPlayer(this.playerId);
			}
		}

		// Token: 0x06000F28 RID: 3880 RVA: 0x00051358 File Offset: 0x0004F558
		private void Awake()
		{
			this._uiElementsArray = new GamepadTemplateUI.UIElement[]
			{
				new GamepadTemplateUI.UIElement(0, this.leftStickX),
				new GamepadTemplateUI.UIElement(1, this.leftStickY),
				new GamepadTemplateUI.UIElement(17, this.leftStickButton),
				new GamepadTemplateUI.UIElement(2, this.rightStickX),
				new GamepadTemplateUI.UIElement(3, this.rightStickY),
				new GamepadTemplateUI.UIElement(18, this.rightStickButton),
				new GamepadTemplateUI.UIElement(4, this.actionBottomRow1),
				new GamepadTemplateUI.UIElement(5, this.actionBottomRow2),
				new GamepadTemplateUI.UIElement(6, this.actionBottomRow3),
				new GamepadTemplateUI.UIElement(7, this.actionTopRow1),
				new GamepadTemplateUI.UIElement(8, this.actionTopRow2),
				new GamepadTemplateUI.UIElement(9, this.actionTopRow3),
				new GamepadTemplateUI.UIElement(14, this.center1),
				new GamepadTemplateUI.UIElement(15, this.center2),
				new GamepadTemplateUI.UIElement(16, this.center3),
				new GamepadTemplateUI.UIElement(19, this.dPadUp),
				new GamepadTemplateUI.UIElement(20, this.dPadRight),
				new GamepadTemplateUI.UIElement(21, this.dPadDown),
				new GamepadTemplateUI.UIElement(22, this.dPadLeft),
				new GamepadTemplateUI.UIElement(10, this.leftShoulder),
				new GamepadTemplateUI.UIElement(11, this.leftTrigger),
				new GamepadTemplateUI.UIElement(12, this.rightShoulder),
				new GamepadTemplateUI.UIElement(13, this.rightTrigger)
			};
			for (int i = 0; i < this._uiElementsArray.Length; i++)
			{
				this._uiElements.Add(this._uiElementsArray[i].id, this._uiElementsArray[i].element);
			}
			this._sticks = new GamepadTemplateUI.Stick[]
			{
				new GamepadTemplateUI.Stick(this.leftStick, 0, 1),
				new GamepadTemplateUI.Stick(this.rightStick, 2, 3)
			};
			ReInput.ControllerConnectedEvent += this.OnControllerConnected;
			ReInput.ControllerDisconnectedEvent += this.OnControllerDisconnected;
		}

		// Token: 0x06000F29 RID: 3881 RVA: 0x0005156D File Offset: 0x0004F76D
		private void Start()
		{
			if (!ReInput.isReady)
			{
				return;
			}
			this.DrawLabels();
		}

		// Token: 0x06000F2A RID: 3882 RVA: 0x0005157D File Offset: 0x0004F77D
		private void OnDestroy()
		{
			ReInput.ControllerConnectedEvent -= this.OnControllerConnected;
			ReInput.ControllerDisconnectedEvent -= this.OnControllerDisconnected;
		}

		// Token: 0x06000F2B RID: 3883 RVA: 0x000515A1 File Offset: 0x0004F7A1
		private void Update()
		{
			if (!ReInput.isReady)
			{
				return;
			}
			this.DrawActiveElements();
		}

		// Token: 0x06000F2C RID: 3884 RVA: 0x000515B4 File Offset: 0x0004F7B4
		private void DrawActiveElements()
		{
			for (int i = 0; i < this._uiElementsArray.Length; i++)
			{
				this._uiElementsArray[i].element.Deactivate();
			}
			for (int j = 0; j < this._sticks.Length; j++)
			{
				this._sticks[j].Reset();
			}
			IList<InputAction> actions = ReInput.mapping.Actions;
			for (int k = 0; k < actions.Count; k++)
			{
				this.ActivateElements(this.player, actions[k].id);
			}
		}

		// Token: 0x06000F2D RID: 3885 RVA: 0x0005163C File Offset: 0x0004F83C
		private void ActivateElements(Player player, int actionId)
		{
			float axis = player.GetAxis(actionId);
			if (axis == 0f)
			{
				return;
			}
			IList<InputActionSourceData> currentInputSources = player.GetCurrentInputSources(actionId);
			for (int i = 0; i < currentInputSources.Count; i++)
			{
				InputActionSourceData inputActionSourceData = currentInputSources[i];
				IGamepadTemplate template = inputActionSourceData.controller.GetTemplate<IGamepadTemplate>();
				if (template != null)
				{
					template.GetElementTargets(inputActionSourceData.actionElementMap, this._tempTargetList);
					for (int j = 0; j < this._tempTargetList.Count; j++)
					{
						ControllerTemplateElementTarget controllerTemplateElementTarget = this._tempTargetList[j];
						int id = controllerTemplateElementTarget.element.id;
						ControllerUIElement controllerUIElement = this._uiElements[id];
						if (controllerTemplateElementTarget.elementType == ControllerTemplateElementType.Axis)
						{
							controllerUIElement.Activate(axis);
						}
						else if (controllerTemplateElementTarget.elementType == ControllerTemplateElementType.Button && (player.GetButton(actionId) || player.GetNegativeButton(actionId)))
						{
							controllerUIElement.Activate(1f);
						}
						GamepadTemplateUI.Stick stick = this.GetStick(id);
						if (stick != null)
						{
							stick.SetAxisPosition(id, axis * 20f);
						}
					}
				}
			}
		}

		// Token: 0x06000F2E RID: 3886 RVA: 0x00051758 File Offset: 0x0004F958
		private void DrawLabels()
		{
			for (int i = 0; i < this._uiElementsArray.Length; i++)
			{
				this._uiElementsArray[i].element.ClearLabels();
			}
			IList<InputAction> actions = ReInput.mapping.Actions;
			for (int j = 0; j < actions.Count; j++)
			{
				this.DrawLabels(this.player, actions[j]);
			}
		}

		// Token: 0x06000F2F RID: 3887 RVA: 0x000517BC File Offset: 0x0004F9BC
		private void DrawLabels(Player player, InputAction action)
		{
			Controller firstControllerWithTemplate = player.controllers.GetFirstControllerWithTemplate<IGamepadTemplate>();
			if (firstControllerWithTemplate == null)
			{
				return;
			}
			IGamepadTemplate template = firstControllerWithTemplate.GetTemplate<IGamepadTemplate>();
			ControllerMap map = player.controllers.maps.GetMap(firstControllerWithTemplate, "Default", "Default");
			if (map == null)
			{
				return;
			}
			for (int i = 0; i < this._uiElementsArray.Length; i++)
			{
				ControllerUIElement element = this._uiElementsArray[i].element;
				int id = this._uiElementsArray[i].id;
				IControllerTemplateElement element2 = template.GetElement(id);
				this.DrawLabel(element, action, map, template, element2);
			}
		}

		// Token: 0x06000F30 RID: 3888 RVA: 0x00051848 File Offset: 0x0004FA48
		private void DrawLabel(ControllerUIElement uiElement, InputAction action, ControllerMap controllerMap, IControllerTemplate template, IControllerTemplateElement element)
		{
			if (element.source == null)
			{
				return;
			}
			if (element.source.type == ControllerTemplateElementSourceType.Axis)
			{
				IControllerTemplateAxisSource controllerTemplateAxisSource = element.source as IControllerTemplateAxisSource;
				if (controllerTemplateAxisSource.splitAxis)
				{
					ActionElementMap firstElementMapWithElementTarget = controllerMap.GetFirstElementMapWithElementTarget(controllerTemplateAxisSource.positiveTarget, action.id, true);
					if (firstElementMapWithElementTarget != null)
					{
						uiElement.SetLabel(firstElementMapWithElementTarget.actionDescriptiveName, AxisRange.Positive);
					}
					firstElementMapWithElementTarget = controllerMap.GetFirstElementMapWithElementTarget(controllerTemplateAxisSource.negativeTarget, action.id, true);
					if (firstElementMapWithElementTarget != null)
					{
						uiElement.SetLabel(firstElementMapWithElementTarget.actionDescriptiveName, AxisRange.Negative);
						return;
					}
				}
				else
				{
					ActionElementMap firstElementMapWithElementTarget = controllerMap.GetFirstElementMapWithElementTarget(controllerTemplateAxisSource.fullTarget, action.id, true);
					if (firstElementMapWithElementTarget != null)
					{
						uiElement.SetLabel(firstElementMapWithElementTarget.actionDescriptiveName, AxisRange.Full);
						return;
					}
					ControllerElementTarget elementTarget = new ControllerElementTarget(controllerTemplateAxisSource.fullTarget)
					{
						axisRange = AxisRange.Positive
					};
					firstElementMapWithElementTarget = controllerMap.GetFirstElementMapWithElementTarget(elementTarget, action.id, true);
					if (firstElementMapWithElementTarget != null)
					{
						uiElement.SetLabel(firstElementMapWithElementTarget.actionDescriptiveName, AxisRange.Positive);
					}
					elementTarget = new ControllerElementTarget(controllerTemplateAxisSource.fullTarget)
					{
						axisRange = AxisRange.Negative
					};
					firstElementMapWithElementTarget = controllerMap.GetFirstElementMapWithElementTarget(elementTarget, action.id, true);
					if (firstElementMapWithElementTarget != null)
					{
						uiElement.SetLabel(firstElementMapWithElementTarget.actionDescriptiveName, AxisRange.Negative);
						return;
					}
				}
			}
			else if (element.source.type == ControllerTemplateElementSourceType.Button)
			{
				IControllerTemplateButtonSource controllerTemplateButtonSource = element.source as IControllerTemplateButtonSource;
				ActionElementMap firstElementMapWithElementTarget = controllerMap.GetFirstElementMapWithElementTarget(controllerTemplateButtonSource.target, action.id, true);
				if (firstElementMapWithElementTarget != null)
				{
					uiElement.SetLabel(firstElementMapWithElementTarget.actionDescriptiveName, AxisRange.Full);
				}
			}
		}

		// Token: 0x06000F31 RID: 3889 RVA: 0x000519A0 File Offset: 0x0004FBA0
		private GamepadTemplateUI.Stick GetStick(int elementId)
		{
			for (int i = 0; i < this._sticks.Length; i++)
			{
				if (this._sticks[i].ContainsElement(elementId))
				{
					return this._sticks[i];
				}
			}
			return null;
		}

		// Token: 0x06000F32 RID: 3890 RVA: 0x000519DA File Offset: 0x0004FBDA
		private void OnControllerConnected(ControllerStatusChangedEventArgs args)
		{
			this.DrawLabels();
		}

		// Token: 0x06000F33 RID: 3891 RVA: 0x000519DA File Offset: 0x0004FBDA
		private void OnControllerDisconnected(ControllerStatusChangedEventArgs args)
		{
			this.DrawLabels();
		}

		// Token: 0x040013C9 RID: 5065
		private const float stickRadius = 20f;

		// Token: 0x040013CA RID: 5066
		public int playerId;

		// Token: 0x040013CB RID: 5067
		[SerializeField]
		private RectTransform leftStick;

		// Token: 0x040013CC RID: 5068
		[SerializeField]
		private RectTransform rightStick;

		// Token: 0x040013CD RID: 5069
		[SerializeField]
		private ControllerUIElement leftStickX;

		// Token: 0x040013CE RID: 5070
		[SerializeField]
		private ControllerUIElement leftStickY;

		// Token: 0x040013CF RID: 5071
		[SerializeField]
		private ControllerUIElement leftStickButton;

		// Token: 0x040013D0 RID: 5072
		[SerializeField]
		private ControllerUIElement rightStickX;

		// Token: 0x040013D1 RID: 5073
		[SerializeField]
		private ControllerUIElement rightStickY;

		// Token: 0x040013D2 RID: 5074
		[SerializeField]
		private ControllerUIElement rightStickButton;

		// Token: 0x040013D3 RID: 5075
		[SerializeField]
		private ControllerUIElement actionBottomRow1;

		// Token: 0x040013D4 RID: 5076
		[SerializeField]
		private ControllerUIElement actionBottomRow2;

		// Token: 0x040013D5 RID: 5077
		[SerializeField]
		private ControllerUIElement actionBottomRow3;

		// Token: 0x040013D6 RID: 5078
		[SerializeField]
		private ControllerUIElement actionTopRow1;

		// Token: 0x040013D7 RID: 5079
		[SerializeField]
		private ControllerUIElement actionTopRow2;

		// Token: 0x040013D8 RID: 5080
		[SerializeField]
		private ControllerUIElement actionTopRow3;

		// Token: 0x040013D9 RID: 5081
		[SerializeField]
		private ControllerUIElement leftShoulder;

		// Token: 0x040013DA RID: 5082
		[SerializeField]
		private ControllerUIElement leftTrigger;

		// Token: 0x040013DB RID: 5083
		[SerializeField]
		private ControllerUIElement rightShoulder;

		// Token: 0x040013DC RID: 5084
		[SerializeField]
		private ControllerUIElement rightTrigger;

		// Token: 0x040013DD RID: 5085
		[SerializeField]
		private ControllerUIElement center1;

		// Token: 0x040013DE RID: 5086
		[SerializeField]
		private ControllerUIElement center2;

		// Token: 0x040013DF RID: 5087
		[SerializeField]
		private ControllerUIElement center3;

		// Token: 0x040013E0 RID: 5088
		[SerializeField]
		private ControllerUIElement dPadUp;

		// Token: 0x040013E1 RID: 5089
		[SerializeField]
		private ControllerUIElement dPadRight;

		// Token: 0x040013E2 RID: 5090
		[SerializeField]
		private ControllerUIElement dPadDown;

		// Token: 0x040013E3 RID: 5091
		[SerializeField]
		private ControllerUIElement dPadLeft;

		// Token: 0x040013E4 RID: 5092
		private GamepadTemplateUI.UIElement[] _uiElementsArray;

		// Token: 0x040013E5 RID: 5093
		private Dictionary<int, ControllerUIElement> _uiElements = new Dictionary<int, ControllerUIElement>();

		// Token: 0x040013E6 RID: 5094
		private IList<ControllerTemplateElementTarget> _tempTargetList = new List<ControllerTemplateElementTarget>(2);

		// Token: 0x040013E7 RID: 5095
		private GamepadTemplateUI.Stick[] _sticks;

		// Token: 0x020002CD RID: 717
		private class Stick
		{
			// Token: 0x1700030B RID: 779
			// (get) Token: 0x06000F35 RID: 3893 RVA: 0x00051A01 File Offset: 0x0004FC01
			// (set) Token: 0x06000F36 RID: 3894 RVA: 0x00051A2D File Offset: 0x0004FC2D
			public Vector2 position
			{
				get
				{
					if (!(this._transform != null))
					{
						return Vector2.zero;
					}
					return this._transform.anchoredPosition - this._origPosition;
				}
				set
				{
					if (this._transform == null)
					{
						return;
					}
					this._transform.anchoredPosition = this._origPosition + value;
				}
			}

			// Token: 0x06000F37 RID: 3895 RVA: 0x00051A58 File Offset: 0x0004FC58
			public Stick(RectTransform transform, int xAxisElementId, int yAxisElementId)
			{
				if (transform == null)
				{
					return;
				}
				this._transform = transform;
				this._origPosition = this._transform.anchoredPosition;
				this._xAxisElementId = xAxisElementId;
				this._yAxisElementId = yAxisElementId;
			}

			// Token: 0x06000F38 RID: 3896 RVA: 0x00051AA9 File Offset: 0x0004FCA9
			public void Reset()
			{
				if (this._transform == null)
				{
					return;
				}
				this._transform.anchoredPosition = this._origPosition;
			}

			// Token: 0x06000F39 RID: 3897 RVA: 0x00051ACB File Offset: 0x0004FCCB
			public bool ContainsElement(int elementId)
			{
				return !(this._transform == null) && (elementId == this._xAxisElementId || elementId == this._yAxisElementId);
			}

			// Token: 0x06000F3A RID: 3898 RVA: 0x00051AF4 File Offset: 0x0004FCF4
			public void SetAxisPosition(int elementId, float value)
			{
				if (this._transform == null)
				{
					return;
				}
				Vector2 position = this.position;
				if (elementId == this._xAxisElementId)
				{
					position.x = value;
				}
				else if (elementId == this._yAxisElementId)
				{
					position.y = value;
				}
				this.position = position;
			}

			// Token: 0x040013E8 RID: 5096
			private RectTransform _transform;

			// Token: 0x040013E9 RID: 5097
			private Vector2 _origPosition;

			// Token: 0x040013EA RID: 5098
			private int _xAxisElementId = -1;

			// Token: 0x040013EB RID: 5099
			private int _yAxisElementId = -1;
		}

		// Token: 0x020002CE RID: 718
		private class UIElement
		{
			// Token: 0x06000F3B RID: 3899 RVA: 0x00051B42 File Offset: 0x0004FD42
			public UIElement(int id, ControllerUIElement element)
			{
				this.id = id;
				this.element = element;
			}

			// Token: 0x040013EC RID: 5100
			public int id;

			// Token: 0x040013ED RID: 5101
			public ControllerUIElement element;
		}
	}
}
