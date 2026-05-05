using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Demos
{
	// Token: 0x020002A0 RID: 672
	[AddComponentMenu("")]
	public class ControlRemappingDemo1 : MonoBehaviour
	{
		// Token: 0x06000DE5 RID: 3557 RVA: 0x0004AECA File Offset: 0x000490CA
		private void Awake()
		{
			this.inputMapper.options.timeout = 5f;
			this.inputMapper.options.ignoreMouseXAxis = true;
			this.inputMapper.options.ignoreMouseYAxis = true;
			this.Initialize();
		}

		// Token: 0x06000DE6 RID: 3558 RVA: 0x0004AF09 File Offset: 0x00049109
		private void OnEnable()
		{
			this.Subscribe();
		}

		// Token: 0x06000DE7 RID: 3559 RVA: 0x0004AF11 File Offset: 0x00049111
		private void OnDisable()
		{
			this.Unsubscribe();
		}

		// Token: 0x06000DE8 RID: 3560 RVA: 0x0004AF1C File Offset: 0x0004911C
		private void Initialize()
		{
			this.dialog = new ControlRemappingDemo1.DialogHelper();
			this.actionQueue = new Queue<ControlRemappingDemo1.QueueEntry>();
			this.selectedController = new ControlRemappingDemo1.ControllerSelection();
			ReInput.ControllerConnectedEvent += this.JoystickConnected;
			ReInput.ControllerPreDisconnectEvent += this.JoystickPreDisconnect;
			ReInput.ControllerDisconnectedEvent += this.JoystickDisconnected;
			this.ResetAll();
			this.initialized = true;
			ReInput.userDataStore.Load();
			if (ReInput.unityJoystickIdentificationRequired)
			{
				this.IdentifyAllJoysticks();
			}
		}

		// Token: 0x06000DE9 RID: 3561 RVA: 0x0004AFA4 File Offset: 0x000491A4
		private void Setup()
		{
			if (this.setupFinished)
			{
				return;
			}
			this.style_wordWrap = new GUIStyle(GUI.skin.label);
			this.style_wordWrap.wordWrap = true;
			this.style_centeredBox = new GUIStyle(GUI.skin.box);
			this.style_centeredBox.alignment = TextAnchor.MiddleCenter;
			this.setupFinished = true;
		}

		// Token: 0x06000DEA RID: 3562 RVA: 0x0004B003 File Offset: 0x00049203
		private void Subscribe()
		{
			this.Unsubscribe();
			this.inputMapper.ConflictFoundEvent += this.OnConflictFound;
			this.inputMapper.StoppedEvent += this.OnStopped;
		}

		// Token: 0x06000DEB RID: 3563 RVA: 0x0004B039 File Offset: 0x00049239
		private void Unsubscribe()
		{
			this.inputMapper.RemoveAllEventListeners();
		}

		// Token: 0x06000DEC RID: 3564 RVA: 0x0004B048 File Offset: 0x00049248
		public void OnGUI()
		{
			if (!this.initialized)
			{
				return;
			}
			this.Setup();
			this.HandleMenuControl();
			if (!this.showMenu)
			{
				this.DrawInitialScreen();
				return;
			}
			this.SetGUIStateStart();
			this.ProcessQueue();
			this.DrawPage();
			this.ShowDialog();
			this.SetGUIStateEnd();
			this.busy = false;
		}

		// Token: 0x06000DED RID: 3565 RVA: 0x0004B0A0 File Offset: 0x000492A0
		private void HandleMenuControl()
		{
			if (this.dialog.enabled)
			{
				return;
			}
			if (Event.current.type == EventType.Layout && ReInput.players.GetSystemPlayer().GetButtonDown("Menu"))
			{
				if (this.showMenu)
				{
					ReInput.userDataStore.Save();
					this.Close();
					return;
				}
				this.Open();
			}
		}

		// Token: 0x06000DEE RID: 3566 RVA: 0x0004B0FD File Offset: 0x000492FD
		private void Close()
		{
			this.ClearWorkingVars();
			this.showMenu = false;
		}

		// Token: 0x06000DEF RID: 3567 RVA: 0x0004B10C File Offset: 0x0004930C
		private void Open()
		{
			this.showMenu = true;
		}

		// Token: 0x06000DF0 RID: 3568 RVA: 0x0004B118 File Offset: 0x00049318
		private void DrawInitialScreen()
		{
			ActionElementMap firstElementMapWithAction = ReInput.players.GetSystemPlayer().controllers.maps.GetFirstElementMapWithAction("Menu", true);
			GUIContent content;
			if (firstElementMapWithAction != null)
			{
				content = new GUIContent("Press " + firstElementMapWithAction.elementIdentifierName + " to open the menu.");
			}
			else
			{
				content = new GUIContent("There is no element assigned to open the menu!");
			}
			GUILayout.BeginArea(this.GetScreenCenteredRect(300f, 50f));
			GUILayout.Box(content, this.style_centeredBox, new GUILayoutOption[]
			{
				GUILayout.ExpandHeight(true),
				GUILayout.ExpandWidth(true)
			});
			GUILayout.EndArea();
		}

		// Token: 0x06000DF1 RID: 3569 RVA: 0x0004B1B0 File Offset: 0x000493B0
		private void DrawPage()
		{
			if (GUI.enabled != this.pageGUIState)
			{
				GUI.enabled = this.pageGUIState;
			}
			GUILayout.BeginArea(new Rect(((float)Screen.width - (float)Screen.width * 0.9f) * 0.5f, ((float)Screen.height - (float)Screen.height * 0.9f) * 0.5f, (float)Screen.width * 0.9f, (float)Screen.height * 0.9f));
			this.DrawPlayerSelector();
			this.DrawJoystickSelector();
			this.DrawMouseAssignment();
			this.DrawControllerSelector();
			this.DrawCalibrateButton();
			this.DrawMapCategories();
			this.actionScrollPos = GUILayout.BeginScrollView(this.actionScrollPos, Array.Empty<GUILayoutOption>());
			this.DrawCategoryActions();
			GUILayout.EndScrollView();
			GUILayout.EndArea();
		}

		// Token: 0x06000DF2 RID: 3570 RVA: 0x0004B274 File Offset: 0x00049474
		private void DrawPlayerSelector()
		{
			if (ReInput.players.allPlayerCount == 0)
			{
				GUILayout.Label("There are no players.", Array.Empty<GUILayoutOption>());
				return;
			}
			GUILayout.Space(15f);
			GUILayout.Label("Players:", Array.Empty<GUILayoutOption>());
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			foreach (Player player in ReInput.players.GetPlayers(true))
			{
				if (this.selectedPlayer == null)
				{
					this.selectedPlayer = player;
				}
				bool flag = player == this.selectedPlayer;
				bool flag2 = GUILayout.Toggle(flag, (player.descriptiveName != string.Empty) ? player.descriptiveName : player.name, "Button", new GUILayoutOption[]
				{
					GUILayout.ExpandWidth(false)
				});
				if (flag2 != flag && flag2)
				{
					this.selectedPlayer = player;
					this.selectedController.Clear();
					this.selectedMapCategoryId = -1;
				}
			}
			GUILayout.EndHorizontal();
		}

		// Token: 0x06000DF3 RID: 3571 RVA: 0x0004B388 File Offset: 0x00049588
		private void DrawMouseAssignment()
		{
			bool enabled = GUI.enabled;
			if (this.selectedPlayer == null)
			{
				GUI.enabled = false;
			}
			GUILayout.Space(15f);
			GUILayout.Label("Assign Mouse:", Array.Empty<GUILayoutOption>());
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			bool flag = this.selectedPlayer != null && this.selectedPlayer.controllers.hasMouse;
			bool flag2 = GUILayout.Toggle(flag, "Assign Mouse", "Button", new GUILayoutOption[]
			{
				GUILayout.ExpandWidth(false)
			});
			if (flag2 != flag)
			{
				if (flag2)
				{
					this.selectedPlayer.controllers.hasMouse = true;
					using (IEnumerator<Player> enumerator = ReInput.players.Players.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							Player player = enumerator.Current;
							if (player != this.selectedPlayer)
							{
								player.controllers.hasMouse = false;
							}
						}
						goto IL_E9;
					}
				}
				this.selectedPlayer.controllers.hasMouse = false;
			}
			IL_E9:
			GUILayout.EndHorizontal();
			if (GUI.enabled != enabled)
			{
				GUI.enabled = enabled;
			}
		}

		// Token: 0x06000DF4 RID: 3572 RVA: 0x0004B4A4 File Offset: 0x000496A4
		private void DrawJoystickSelector()
		{
			bool enabled = GUI.enabled;
			if (this.selectedPlayer == null)
			{
				GUI.enabled = false;
			}
			GUILayout.Space(15f);
			GUILayout.Label("Assign Joysticks:", Array.Empty<GUILayoutOption>());
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			bool flag = this.selectedPlayer == null || this.selectedPlayer.controllers.joystickCount == 0;
			bool flag2 = GUILayout.Toggle(flag, "None", "Button", new GUILayoutOption[]
			{
				GUILayout.ExpandWidth(false)
			});
			if (flag2 != flag)
			{
				this.selectedPlayer.controllers.ClearControllersOfType(ControllerType.Joystick);
				this.ControllerSelectionChanged();
			}
			if (this.selectedPlayer != null)
			{
				foreach (Joystick joystick in ReInput.controllers.Joysticks)
				{
					flag = this.selectedPlayer.controllers.ContainsController(joystick);
					flag2 = GUILayout.Toggle(flag, joystick.name, "Button", new GUILayoutOption[]
					{
						GUILayout.ExpandWidth(false)
					});
					if (flag2 != flag)
					{
						this.EnqueueAction(new ControlRemappingDemo1.JoystickAssignmentChange(this.selectedPlayer.id, joystick.id, flag2));
					}
				}
			}
			GUILayout.EndHorizontal();
			if (GUI.enabled != enabled)
			{
				GUI.enabled = enabled;
			}
		}

		// Token: 0x06000DF5 RID: 3573 RVA: 0x0004B600 File Offset: 0x00049800
		private void DrawControllerSelector()
		{
			if (this.selectedPlayer == null)
			{
				return;
			}
			bool enabled = GUI.enabled;
			GUILayout.Space(15f);
			GUILayout.Label("Controller to Map:", Array.Empty<GUILayoutOption>());
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			if (!this.selectedController.hasSelection)
			{
				this.selectedController.Set(0, ControllerType.Keyboard);
				this.ControllerSelectionChanged();
			}
			bool flag = this.selectedController.type == ControllerType.Keyboard;
			if (GUILayout.Toggle(flag, ReInput.controllers.Keyboard.name, "Button", new GUILayoutOption[]
			{
				GUILayout.ExpandWidth(false)
			}) != flag)
			{
				this.selectedController.Set(0, ControllerType.Keyboard);
				this.ControllerSelectionChanged();
			}
			if (!this.selectedPlayer.controllers.hasMouse)
			{
				GUI.enabled = false;
			}
			flag = (this.selectedController.type == ControllerType.Mouse);
			if (GUILayout.Toggle(flag, ReInput.controllers.Mouse.name, "Button", new GUILayoutOption[]
			{
				GUILayout.ExpandWidth(false)
			}) != flag)
			{
				this.selectedController.Set(0, ControllerType.Mouse);
				this.ControllerSelectionChanged();
			}
			if (GUI.enabled != enabled)
			{
				GUI.enabled = enabled;
			}
			foreach (Joystick joystick in this.selectedPlayer.controllers.Joysticks)
			{
				flag = (this.selectedController.type == ControllerType.Joystick && this.selectedController.id == joystick.id);
				if (GUILayout.Toggle(flag, joystick.name, "Button", new GUILayoutOption[]
				{
					GUILayout.ExpandWidth(false)
				}) != flag)
				{
					this.selectedController.Set(joystick.id, ControllerType.Joystick);
					this.ControllerSelectionChanged();
				}
			}
			GUILayout.EndHorizontal();
			if (GUI.enabled != enabled)
			{
				GUI.enabled = enabled;
			}
		}

		// Token: 0x06000DF6 RID: 3574 RVA: 0x0004B7E8 File Offset: 0x000499E8
		private void DrawCalibrateButton()
		{
			if (this.selectedPlayer == null)
			{
				return;
			}
			bool enabled = GUI.enabled;
			GUILayout.Space(10f);
			Controller controller = this.selectedController.hasSelection ? this.selectedPlayer.controllers.GetController(this.selectedController.type, this.selectedController.id) : null;
			if (controller == null || this.selectedController.type != ControllerType.Joystick)
			{
				GUI.enabled = false;
				GUILayout.Button("Select a controller to calibrate", new GUILayoutOption[]
				{
					GUILayout.ExpandWidth(false)
				});
				if (GUI.enabled != enabled)
				{
					GUI.enabled = enabled;
				}
			}
			else if (GUILayout.Button("Calibrate " + controller.name, new GUILayoutOption[]
			{
				GUILayout.ExpandWidth(false)
			}))
			{
				Joystick joystick = controller as Joystick;
				if (joystick != null)
				{
					CalibrationMap calibrationMap = joystick.calibrationMap;
					if (calibrationMap != null)
					{
						this.EnqueueAction(new ControlRemappingDemo1.Calibration(this.selectedPlayer, joystick, calibrationMap));
					}
				}
			}
			if (GUI.enabled != enabled)
			{
				GUI.enabled = enabled;
			}
		}

		// Token: 0x06000DF7 RID: 3575 RVA: 0x0004B8E4 File Offset: 0x00049AE4
		private void DrawMapCategories()
		{
			if (this.selectedPlayer == null)
			{
				return;
			}
			if (!this.selectedController.hasSelection)
			{
				return;
			}
			bool enabled = GUI.enabled;
			GUILayout.Space(15f);
			GUILayout.Label("Categories:", Array.Empty<GUILayoutOption>());
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			foreach (InputMapCategory inputMapCategory in ReInput.mapping.UserAssignableMapCategories)
			{
				if (!this.selectedPlayer.controllers.maps.ContainsMapInCategory(this.selectedController.type, inputMapCategory.id))
				{
					GUI.enabled = false;
				}
				else if (this.selectedMapCategoryId < 0)
				{
					this.selectedMapCategoryId = inputMapCategory.id;
					this.selectedMap = this.selectedPlayer.controllers.maps.GetFirstMapInCategory(this.selectedController.type, this.selectedController.id, inputMapCategory.id);
				}
				bool flag = inputMapCategory.id == this.selectedMapCategoryId;
				if (GUILayout.Toggle(flag, (inputMapCategory.descriptiveName != string.Empty) ? inputMapCategory.descriptiveName : inputMapCategory.name, "Button", new GUILayoutOption[]
				{
					GUILayout.ExpandWidth(false)
				}) != flag)
				{
					this.selectedMapCategoryId = inputMapCategory.id;
					this.selectedMap = this.selectedPlayer.controllers.maps.GetFirstMapInCategory(this.selectedController.type, this.selectedController.id, inputMapCategory.id);
				}
				if (GUI.enabled != enabled)
				{
					GUI.enabled = enabled;
				}
			}
			GUILayout.EndHorizontal();
			if (GUI.enabled != enabled)
			{
				GUI.enabled = enabled;
			}
		}

		// Token: 0x06000DF8 RID: 3576 RVA: 0x0004BAB8 File Offset: 0x00049CB8
		private void DrawCategoryActions()
		{
			if (this.selectedPlayer == null)
			{
				return;
			}
			if (this.selectedMapCategoryId < 0)
			{
				return;
			}
			bool enabled = GUI.enabled;
			if (this.selectedMap == null)
			{
				return;
			}
			GUILayout.Space(15f);
			GUILayout.Label("Actions:", Array.Empty<GUILayoutOption>());
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(this.selectedMapCategoryId);
			if (mapCategory == null)
			{
				return;
			}
			InputCategory actionCategory = ReInput.mapping.GetActionCategory(mapCategory.name);
			if (actionCategory == null)
			{
				return;
			}
			float width = 150f;
			foreach (InputAction inputAction in ReInput.mapping.ActionsInCategory(actionCategory.id))
			{
				string text = (inputAction.descriptiveName != string.Empty) ? inputAction.descriptiveName : inputAction.name;
				if (inputAction.type == InputActionType.Button)
				{
					GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
					GUILayout.Label(text, new GUILayoutOption[]
					{
						GUILayout.Width(width)
					});
					this.DrawAddActionMapButton(this.selectedPlayer.id, inputAction, AxisRange.Positive, this.selectedController, this.selectedMap);
					foreach (ActionElementMap actionElementMap in this.selectedMap.AllMaps)
					{
						if (actionElementMap.actionId == inputAction.id)
						{
							this.DrawActionAssignmentButton(this.selectedPlayer.id, inputAction, AxisRange.Positive, this.selectedController, this.selectedMap, actionElementMap);
						}
					}
					GUILayout.EndHorizontal();
				}
				else if (inputAction.type == InputActionType.Axis)
				{
					if (this.selectedController.type != ControllerType.Keyboard)
					{
						GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
						GUILayout.Label(text, new GUILayoutOption[]
						{
							GUILayout.Width(width)
						});
						this.DrawAddActionMapButton(this.selectedPlayer.id, inputAction, AxisRange.Full, this.selectedController, this.selectedMap);
						foreach (ActionElementMap actionElementMap2 in this.selectedMap.AllMaps)
						{
							if (actionElementMap2.actionId == inputAction.id && actionElementMap2.elementType != ControllerElementType.Button && actionElementMap2.axisType != AxisType.Split)
							{
								this.DrawActionAssignmentButton(this.selectedPlayer.id, inputAction, AxisRange.Full, this.selectedController, this.selectedMap, actionElementMap2);
								this.DrawInvertButton(this.selectedPlayer.id, inputAction, Pole.Positive, this.selectedController, this.selectedMap, actionElementMap2);
							}
						}
						GUILayout.EndHorizontal();
					}
					string text2 = (inputAction.positiveDescriptiveName != string.Empty) ? inputAction.positiveDescriptiveName : (inputAction.descriptiveName + " +");
					GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
					GUILayout.Label(text2, new GUILayoutOption[]
					{
						GUILayout.Width(width)
					});
					this.DrawAddActionMapButton(this.selectedPlayer.id, inputAction, AxisRange.Positive, this.selectedController, this.selectedMap);
					foreach (ActionElementMap actionElementMap3 in this.selectedMap.AllMaps)
					{
						if (actionElementMap3.actionId == inputAction.id && actionElementMap3.axisContribution == Pole.Positive && actionElementMap3.axisType != AxisType.Normal)
						{
							this.DrawActionAssignmentButton(this.selectedPlayer.id, inputAction, AxisRange.Positive, this.selectedController, this.selectedMap, actionElementMap3);
						}
					}
					GUILayout.EndHorizontal();
					string text3 = (inputAction.negativeDescriptiveName != string.Empty) ? inputAction.negativeDescriptiveName : (inputAction.descriptiveName + " -");
					GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
					GUILayout.Label(text3, new GUILayoutOption[]
					{
						GUILayout.Width(width)
					});
					this.DrawAddActionMapButton(this.selectedPlayer.id, inputAction, AxisRange.Negative, this.selectedController, this.selectedMap);
					foreach (ActionElementMap actionElementMap4 in this.selectedMap.AllMaps)
					{
						if (actionElementMap4.actionId == inputAction.id && actionElementMap4.axisContribution == Pole.Negative && actionElementMap4.axisType != AxisType.Normal)
						{
							this.DrawActionAssignmentButton(this.selectedPlayer.id, inputAction, AxisRange.Negative, this.selectedController, this.selectedMap, actionElementMap4);
						}
					}
					GUILayout.EndHorizontal();
				}
			}
			if (GUI.enabled != enabled)
			{
				GUI.enabled = enabled;
			}
		}

		// Token: 0x06000DF9 RID: 3577 RVA: 0x0004BFAC File Offset: 0x0004A1AC
		private void DrawActionAssignmentButton(int playerId, InputAction action, AxisRange actionRange, ControlRemappingDemo1.ControllerSelection controller, ControllerMap controllerMap, ActionElementMap elementMap)
		{
			if (GUILayout.Button(elementMap.elementIdentifierName, new GUILayoutOption[]
			{
				GUILayout.ExpandWidth(false),
				GUILayout.MinWidth(30f)
			}))
			{
				InputMapper.Context context = new InputMapper.Context
				{
					actionId = action.id,
					actionRange = actionRange,
					controllerMap = controllerMap,
					actionElementMapToReplace = elementMap
				};
				this.EnqueueAction(new ControlRemappingDemo1.ElementAssignmentChange(ControlRemappingDemo1.ElementAssignmentChangeType.ReassignOrRemove, context));
				this.startListening = true;
			}
			GUILayout.Space(4f);
		}

		// Token: 0x06000DFA RID: 3578 RVA: 0x0004C02C File Offset: 0x0004A22C
		private void DrawInvertButton(int playerId, InputAction action, Pole actionAxisContribution, ControlRemappingDemo1.ControllerSelection controller, ControllerMap controllerMap, ActionElementMap elementMap)
		{
			bool invert = elementMap.invert;
			bool flag = GUILayout.Toggle(invert, "Invert", new GUILayoutOption[]
			{
				GUILayout.ExpandWidth(false)
			});
			if (flag != invert)
			{
				elementMap.invert = flag;
			}
			GUILayout.Space(10f);
		}

		// Token: 0x06000DFB RID: 3579 RVA: 0x0004C074 File Offset: 0x0004A274
		private void DrawAddActionMapButton(int playerId, InputAction action, AxisRange actionRange, ControlRemappingDemo1.ControllerSelection controller, ControllerMap controllerMap)
		{
			if (GUILayout.Button("Add...", new GUILayoutOption[]
			{
				GUILayout.ExpandWidth(false)
			}))
			{
				InputMapper.Context context = new InputMapper.Context
				{
					actionId = action.id,
					actionRange = actionRange,
					controllerMap = controllerMap
				};
				this.EnqueueAction(new ControlRemappingDemo1.ElementAssignmentChange(ControlRemappingDemo1.ElementAssignmentChangeType.Add, context));
				this.startListening = true;
			}
			GUILayout.Space(10f);
		}

		// Token: 0x06000DFC RID: 3580 RVA: 0x0004C0DB File Offset: 0x0004A2DB
		private void ShowDialog()
		{
			this.dialog.Update();
		}

		// Token: 0x06000DFD RID: 3581 RVA: 0x0004C0E8 File Offset: 0x0004A2E8
		private void DrawModalWindow(string title, string message)
		{
			if (!this.dialog.enabled)
			{
				return;
			}
			GUILayout.Space(5f);
			GUILayout.Label(message, this.style_wordWrap, Array.Empty<GUILayoutOption>());
			GUILayout.FlexibleSpace();
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			this.dialog.DrawConfirmButton("Okay");
			GUILayout.FlexibleSpace();
			this.dialog.DrawCancelButton();
			GUILayout.EndHorizontal();
		}

		// Token: 0x06000DFE RID: 3582 RVA: 0x0004C154 File Offset: 0x0004A354
		private void DrawModalWindow_OkayOnly(string title, string message)
		{
			if (!this.dialog.enabled)
			{
				return;
			}
			GUILayout.Space(5f);
			GUILayout.Label(message, this.style_wordWrap, Array.Empty<GUILayoutOption>());
			GUILayout.FlexibleSpace();
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			this.dialog.DrawConfirmButton("Okay");
			GUILayout.EndHorizontal();
		}

		// Token: 0x06000DFF RID: 3583 RVA: 0x0004C1B0 File Offset: 0x0004A3B0
		private void DrawElementAssignmentWindow(string title, string message)
		{
			if (!this.dialog.enabled)
			{
				return;
			}
			GUILayout.Space(5f);
			GUILayout.Label(message, this.style_wordWrap, Array.Empty<GUILayoutOption>());
			GUILayout.FlexibleSpace();
			ControlRemappingDemo1.ElementAssignmentChange elementAssignmentChange = this.actionQueue.Peek() as ControlRemappingDemo1.ElementAssignmentChange;
			if (elementAssignmentChange == null)
			{
				this.dialog.Cancel();
				return;
			}
			float num;
			if (!this.dialog.busy)
			{
				if (this.startListening && this.inputMapper.status == InputMapper.Status.Idle)
				{
					this.inputMapper.Start(elementAssignmentChange.context);
					this.startListening = false;
				}
				if (this.conflictFoundEventData != null)
				{
					this.dialog.Confirm();
					return;
				}
				num = this.inputMapper.timeRemaining;
				if (num == 0f)
				{
					this.dialog.Cancel();
					return;
				}
			}
			else
			{
				num = this.inputMapper.options.timeout;
			}
			GUILayout.Label("Assignment will be canceled in " + ((int)Mathf.Ceil(num)).ToString() + "...", this.style_wordWrap, Array.Empty<GUILayoutOption>());
		}

		// Token: 0x06000E00 RID: 3584 RVA: 0x0004C2BC File Offset: 0x0004A4BC
		private void DrawElementAssignmentProtectedConflictWindow(string title, string message)
		{
			if (!this.dialog.enabled)
			{
				return;
			}
			GUILayout.Space(5f);
			GUILayout.Label(message, this.style_wordWrap, Array.Empty<GUILayoutOption>());
			GUILayout.FlexibleSpace();
			if (!(this.actionQueue.Peek() is ControlRemappingDemo1.ElementAssignmentChange))
			{
				this.dialog.Cancel();
				return;
			}
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			this.dialog.DrawConfirmButton(ControlRemappingDemo1.UserResponse.Custom1, "Add");
			GUILayout.FlexibleSpace();
			this.dialog.DrawCancelButton();
			GUILayout.EndHorizontal();
		}

		// Token: 0x06000E01 RID: 3585 RVA: 0x0004C348 File Offset: 0x0004A548
		private void DrawElementAssignmentNormalConflictWindow(string title, string message)
		{
			if (!this.dialog.enabled)
			{
				return;
			}
			GUILayout.Space(5f);
			GUILayout.Label(message, this.style_wordWrap, Array.Empty<GUILayoutOption>());
			GUILayout.FlexibleSpace();
			if (!(this.actionQueue.Peek() is ControlRemappingDemo1.ElementAssignmentChange))
			{
				this.dialog.Cancel();
				return;
			}
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			this.dialog.DrawConfirmButton(ControlRemappingDemo1.UserResponse.Confirm, "Replace");
			GUILayout.FlexibleSpace();
			this.dialog.DrawConfirmButton(ControlRemappingDemo1.UserResponse.Custom1, "Add");
			GUILayout.FlexibleSpace();
			this.dialog.DrawCancelButton();
			GUILayout.EndHorizontal();
		}

		// Token: 0x06000E02 RID: 3586 RVA: 0x0004C3E8 File Offset: 0x0004A5E8
		private void DrawReassignOrRemoveElementAssignmentWindow(string title, string message)
		{
			if (!this.dialog.enabled)
			{
				return;
			}
			GUILayout.Space(5f);
			GUILayout.Label(message, this.style_wordWrap, Array.Empty<GUILayoutOption>());
			GUILayout.FlexibleSpace();
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			this.dialog.DrawConfirmButton("Reassign");
			GUILayout.FlexibleSpace();
			this.dialog.DrawCancelButton("Remove");
			GUILayout.EndHorizontal();
		}

		// Token: 0x06000E03 RID: 3587 RVA: 0x0004C458 File Offset: 0x0004A658
		private void DrawFallbackJoystickIdentificationWindow(string title, string message)
		{
			if (!this.dialog.enabled)
			{
				return;
			}
			ControlRemappingDemo1.FallbackJoystickIdentification fallbackJoystickIdentification = this.actionQueue.Peek() as ControlRemappingDemo1.FallbackJoystickIdentification;
			if (fallbackJoystickIdentification == null)
			{
				this.dialog.Cancel();
				return;
			}
			GUILayout.Space(5f);
			GUILayout.Label(message, this.style_wordWrap, Array.Empty<GUILayoutOption>());
			GUILayout.Label("Press any button or axis on \"" + fallbackJoystickIdentification.joystickName + "\" now.", this.style_wordWrap, Array.Empty<GUILayoutOption>());
			GUILayout.FlexibleSpace();
			if (GUILayout.Button("Skip", Array.Empty<GUILayoutOption>()))
			{
				this.dialog.Cancel();
				return;
			}
			if (this.dialog.busy)
			{
				return;
			}
			if (!ReInput.controllers.SetUnityJoystickIdFromAnyButtonOrAxisPress(fallbackJoystickIdentification.joystickId, 0.8f, false))
			{
				return;
			}
			this.dialog.Confirm();
		}

		// Token: 0x06000E04 RID: 3588 RVA: 0x0004C528 File Offset: 0x0004A728
		private void DrawCalibrationWindow(string title, string message)
		{
			if (!this.dialog.enabled)
			{
				return;
			}
			ControlRemappingDemo1.Calibration calibration = this.actionQueue.Peek() as ControlRemappingDemo1.Calibration;
			if (calibration == null)
			{
				this.dialog.Cancel();
				return;
			}
			GUILayout.Space(5f);
			GUILayout.Label(message, this.style_wordWrap, Array.Empty<GUILayoutOption>());
			GUILayout.Space(20f);
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			bool enabled = GUI.enabled;
			GUILayout.BeginVertical(new GUILayoutOption[]
			{
				GUILayout.Width(200f)
			});
			this.calibrateScrollPos = GUILayout.BeginScrollView(this.calibrateScrollPos, Array.Empty<GUILayoutOption>());
			if (calibration.recording)
			{
				GUI.enabled = false;
			}
			IList<ControllerElementIdentifier> axisElementIdentifiers = calibration.joystick.AxisElementIdentifiers;
			for (int i = 0; i < axisElementIdentifiers.Count; i++)
			{
				ControllerElementIdentifier controllerElementIdentifier = axisElementIdentifiers[i];
				bool flag = calibration.selectedElementIdentifierId == controllerElementIdentifier.id;
				bool flag2 = GUILayout.Toggle(flag, controllerElementIdentifier.name, "Button", new GUILayoutOption[]
				{
					GUILayout.ExpandWidth(false)
				});
				if (flag != flag2)
				{
					calibration.selectedElementIdentifierId = controllerElementIdentifier.id;
				}
			}
			if (GUI.enabled != enabled)
			{
				GUI.enabled = enabled;
			}
			GUILayout.EndScrollView();
			GUILayout.EndVertical();
			GUILayout.BeginVertical(new GUILayoutOption[]
			{
				GUILayout.Width(200f)
			});
			if (calibration.selectedElementIdentifierId >= 0)
			{
				float axisRawById = calibration.joystick.GetAxisRawById(calibration.selectedElementIdentifierId);
				GUILayout.Label("Raw Value: " + axisRawById.ToString(), Array.Empty<GUILayoutOption>());
				int axisIndexById = calibration.joystick.GetAxisIndexById(calibration.selectedElementIdentifierId);
				AxisCalibration axis = calibration.calibrationMap.GetAxis(axisIndexById);
				GUILayout.Label("Calibrated Value: " + calibration.joystick.GetAxisById(calibration.selectedElementIdentifierId).ToString(), Array.Empty<GUILayoutOption>());
				GUILayout.Label("Zero: " + axis.calibratedZero.ToString(), Array.Empty<GUILayoutOption>());
				GUILayout.Label("Min: " + axis.calibratedMin.ToString(), Array.Empty<GUILayoutOption>());
				GUILayout.Label("Max: " + axis.calibratedMax.ToString(), Array.Empty<GUILayoutOption>());
				GUILayout.Label("Dead Zone: " + axis.deadZone.ToString(), Array.Empty<GUILayoutOption>());
				GUILayout.Space(15f);
				bool flag3 = GUILayout.Toggle(axis.enabled, "Enabled", "Button", new GUILayoutOption[]
				{
					GUILayout.ExpandWidth(false)
				});
				if (axis.enabled != flag3)
				{
					axis.enabled = flag3;
				}
				GUILayout.Space(10f);
				bool flag4 = GUILayout.Toggle(calibration.recording, "Record Min/Max", "Button", new GUILayoutOption[]
				{
					GUILayout.ExpandWidth(false)
				});
				if (flag4 != calibration.recording)
				{
					if (flag4)
					{
						axis.calibratedMax = 0f;
						axis.calibratedMin = 0f;
					}
					calibration.recording = flag4;
				}
				if (calibration.recording)
				{
					axis.calibratedMin = Mathf.Min(new float[]
					{
						axis.calibratedMin,
						axisRawById,
						axis.calibratedMin
					});
					axis.calibratedMax = Mathf.Max(new float[]
					{
						axis.calibratedMax,
						axisRawById,
						axis.calibratedMax
					});
					GUI.enabled = false;
				}
				if (GUILayout.Button("Set Zero", new GUILayoutOption[]
				{
					GUILayout.ExpandWidth(false)
				}))
				{
					axis.calibratedZero = axisRawById;
				}
				if (GUILayout.Button("Set Dead Zone", new GUILayoutOption[]
				{
					GUILayout.ExpandWidth(false)
				}))
				{
					axis.deadZone = axisRawById;
				}
				bool flag5 = GUILayout.Toggle(axis.invert, "Invert", "Button", new GUILayoutOption[]
				{
					GUILayout.ExpandWidth(false)
				});
				if (axis.invert != flag5)
				{
					axis.invert = flag5;
				}
				GUILayout.Space(10f);
				if (GUILayout.Button("Reset", new GUILayoutOption[]
				{
					GUILayout.ExpandWidth(false)
				}))
				{
					axis.Reset();
				}
				if (GUI.enabled != enabled)
				{
					GUI.enabled = enabled;
				}
			}
			else
			{
				GUILayout.Label("Select an axis to begin.", Array.Empty<GUILayoutOption>());
			}
			GUILayout.EndVertical();
			GUILayout.EndHorizontal();
			GUILayout.FlexibleSpace();
			if (calibration.recording)
			{
				GUI.enabled = false;
			}
			if (GUILayout.Button("Close", Array.Empty<GUILayoutOption>()))
			{
				this.calibrateScrollPos = default(Vector2);
				this.dialog.Confirm();
			}
			if (GUI.enabled != enabled)
			{
				GUI.enabled = enabled;
			}
		}

		// Token: 0x06000E05 RID: 3589 RVA: 0x0004C9C8 File Offset: 0x0004ABC8
		private void DialogResultCallback(int queueActionId, ControlRemappingDemo1.UserResponse response)
		{
			foreach (ControlRemappingDemo1.QueueEntry queueEntry in this.actionQueue)
			{
				if (queueEntry.id == queueActionId)
				{
					if (response != ControlRemappingDemo1.UserResponse.Cancel)
					{
						queueEntry.Confirm(response);
						break;
					}
					queueEntry.Cancel();
					break;
				}
			}
		}

		// Token: 0x06000E06 RID: 3590 RVA: 0x0004CA34 File Offset: 0x0004AC34
		private Rect GetScreenCenteredRect(float width, float height)
		{
			return new Rect((float)Screen.width * 0.5f - width * 0.5f, (float)((double)Screen.height * 0.5 - (double)(height * 0.5f)), width, height);
		}

		// Token: 0x06000E07 RID: 3591 RVA: 0x0004CA6C File Offset: 0x0004AC6C
		private void EnqueueAction(ControlRemappingDemo1.QueueEntry entry)
		{
			if (entry == null)
			{
				return;
			}
			this.busy = true;
			GUI.enabled = false;
			this.actionQueue.Enqueue(entry);
		}

		// Token: 0x06000E08 RID: 3592 RVA: 0x0004CA8C File Offset: 0x0004AC8C
		private void ProcessQueue()
		{
			if (this.dialog.enabled)
			{
				return;
			}
			if (this.busy || this.actionQueue.Count == 0)
			{
				return;
			}
			while (this.actionQueue.Count > 0)
			{
				ControlRemappingDemo1.QueueEntry queueEntry = this.actionQueue.Peek();
				bool flag = false;
				switch (queueEntry.queueActionType)
				{
				case ControlRemappingDemo1.QueueActionType.JoystickAssignment:
					flag = this.ProcessJoystickAssignmentChange((ControlRemappingDemo1.JoystickAssignmentChange)queueEntry);
					break;
				case ControlRemappingDemo1.QueueActionType.ElementAssignment:
					flag = this.ProcessElementAssignmentChange((ControlRemappingDemo1.ElementAssignmentChange)queueEntry);
					break;
				case ControlRemappingDemo1.QueueActionType.FallbackJoystickIdentification:
					flag = this.ProcessFallbackJoystickIdentification((ControlRemappingDemo1.FallbackJoystickIdentification)queueEntry);
					break;
				case ControlRemappingDemo1.QueueActionType.Calibrate:
					flag = this.ProcessCalibration((ControlRemappingDemo1.Calibration)queueEntry);
					break;
				}
				if (!flag)
				{
					break;
				}
				this.actionQueue.Dequeue();
			}
		}

		// Token: 0x06000E09 RID: 3593 RVA: 0x0004CB48 File Offset: 0x0004AD48
		private bool ProcessJoystickAssignmentChange(ControlRemappingDemo1.JoystickAssignmentChange entry)
		{
			if (entry.state == ControlRemappingDemo1.QueueEntry.State.Canceled)
			{
				return true;
			}
			Player player = ReInput.players.GetPlayer(entry.playerId);
			if (player == null)
			{
				return true;
			}
			if (!entry.assign)
			{
				player.controllers.RemoveController(ControllerType.Joystick, entry.joystickId);
				this.ControllerSelectionChanged();
				return true;
			}
			if (player.controllers.ContainsController(ControllerType.Joystick, entry.joystickId))
			{
				return true;
			}
			if (!ReInput.controllers.IsJoystickAssigned(entry.joystickId) || entry.state == ControlRemappingDemo1.QueueEntry.State.Confirmed)
			{
				player.controllers.AddController(ControllerType.Joystick, entry.joystickId, true);
				this.ControllerSelectionChanged();
				return true;
			}
			this.dialog.StartModal(entry.id, ControlRemappingDemo1.DialogHelper.DialogType.JoystickConflict, new ControlRemappingDemo1.WindowProperties
			{
				title = "Joystick Reassignment",
				message = "This joystick is already assigned to another player. Do you want to reassign this joystick to " + player.descriptiveName + "?",
				rect = this.GetScreenCenteredRect(250f, 200f),
				windowDrawDelegate = new Action<string, string>(this.DrawModalWindow)
			}, new Action<int, ControlRemappingDemo1.UserResponse>(this.DialogResultCallback));
			return false;
		}

		// Token: 0x06000E0A RID: 3594 RVA: 0x0004CC60 File Offset: 0x0004AE60
		private bool ProcessElementAssignmentChange(ControlRemappingDemo1.ElementAssignmentChange entry)
		{
			switch (entry.changeType)
			{
			case ControlRemappingDemo1.ElementAssignmentChangeType.Add:
			case ControlRemappingDemo1.ElementAssignmentChangeType.Replace:
				return this.ProcessAddOrReplaceElementAssignment(entry);
			case ControlRemappingDemo1.ElementAssignmentChangeType.Remove:
				return this.ProcessRemoveElementAssignment(entry);
			case ControlRemappingDemo1.ElementAssignmentChangeType.ReassignOrRemove:
				return this.ProcessRemoveOrReassignElementAssignment(entry);
			case ControlRemappingDemo1.ElementAssignmentChangeType.ConflictCheck:
				return this.ProcessElementAssignmentConflictCheck(entry);
			default:
				throw new NotImplementedException();
			}
		}

		// Token: 0x06000E0B RID: 3595 RVA: 0x0004CCB8 File Offset: 0x0004AEB8
		private bool ProcessRemoveOrReassignElementAssignment(ControlRemappingDemo1.ElementAssignmentChange entry)
		{
			if (entry.context.controllerMap == null)
			{
				return true;
			}
			if (entry.state == ControlRemappingDemo1.QueueEntry.State.Canceled)
			{
				ControlRemappingDemo1.ElementAssignmentChange elementAssignmentChange = new ControlRemappingDemo1.ElementAssignmentChange(entry);
				elementAssignmentChange.changeType = ControlRemappingDemo1.ElementAssignmentChangeType.Remove;
				this.actionQueue.Enqueue(elementAssignmentChange);
				return true;
			}
			if (entry.state == ControlRemappingDemo1.QueueEntry.State.Confirmed)
			{
				ControlRemappingDemo1.ElementAssignmentChange elementAssignmentChange2 = new ControlRemappingDemo1.ElementAssignmentChange(entry);
				elementAssignmentChange2.changeType = ControlRemappingDemo1.ElementAssignmentChangeType.Replace;
				this.actionQueue.Enqueue(elementAssignmentChange2);
				return true;
			}
			this.dialog.StartModal(entry.id, ControlRemappingDemo1.DialogHelper.DialogType.AssignElement, new ControlRemappingDemo1.WindowProperties
			{
				title = "Reassign or Remove",
				message = "Do you want to reassign or remove this assignment?",
				rect = this.GetScreenCenteredRect(250f, 200f),
				windowDrawDelegate = new Action<string, string>(this.DrawReassignOrRemoveElementAssignmentWindow)
			}, new Action<int, ControlRemappingDemo1.UserResponse>(this.DialogResultCallback));
			return false;
		}

		// Token: 0x06000E0C RID: 3596 RVA: 0x0004CD8C File Offset: 0x0004AF8C
		private bool ProcessRemoveElementAssignment(ControlRemappingDemo1.ElementAssignmentChange entry)
		{
			if (entry.context.controllerMap == null)
			{
				return true;
			}
			if (entry.state == ControlRemappingDemo1.QueueEntry.State.Canceled)
			{
				return true;
			}
			if (entry.state == ControlRemappingDemo1.QueueEntry.State.Confirmed)
			{
				entry.context.controllerMap.DeleteElementMap(entry.context.actionElementMapToReplace.id);
				return true;
			}
			this.dialog.StartModal(entry.id, ControlRemappingDemo1.DialogHelper.DialogType.DeleteAssignmentConfirmation, new ControlRemappingDemo1.WindowProperties
			{
				title = "Remove Assignment",
				message = "Are you sure you want to remove this assignment?",
				rect = this.GetScreenCenteredRect(250f, 200f),
				windowDrawDelegate = new Action<string, string>(this.DrawModalWindow)
			}, new Action<int, ControlRemappingDemo1.UserResponse>(this.DialogResultCallback));
			return false;
		}

		// Token: 0x06000E0D RID: 3597 RVA: 0x0004CE4C File Offset: 0x0004B04C
		private bool ProcessAddOrReplaceElementAssignment(ControlRemappingDemo1.ElementAssignmentChange entry)
		{
			if (entry.state == ControlRemappingDemo1.QueueEntry.State.Canceled)
			{
				this.inputMapper.Stop();
				return true;
			}
			if (entry.state != ControlRemappingDemo1.QueueEntry.State.Confirmed)
			{
				string text;
				if (entry.context.controllerMap.controllerType == ControllerType.Keyboard)
				{
					if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer)
					{
						text = "Press any key to assign it to this action. You may also use the modifier keys Command, Control, Alt, and Shift. If you wish to assign a modifier key itself to this action, press and hold the key for 1 second.";
					}
					else
					{
						text = "Press any key to assign it to this action. You may also use the modifier keys Control, Alt, and Shift. If you wish to assign a modifier key itself to this action, press and hold the key for 1 second.";
					}
					if (Application.isEditor)
					{
						text += "\n\nNOTE: Some modifier key combinations will not work in the Unity Editor, but they will work in a game build.";
					}
				}
				else if (entry.context.controllerMap.controllerType == ControllerType.Mouse)
				{
					text = "Press any mouse button or axis to assign it to this action.\n\nTo assign mouse movement axes, move the mouse quickly in the direction you want mapped to the action. Slow movements will be ignored.";
				}
				else
				{
					text = "Press any button or axis to assign it to this action.";
				}
				this.dialog.StartModal(entry.id, ControlRemappingDemo1.DialogHelper.DialogType.AssignElement, new ControlRemappingDemo1.WindowProperties
				{
					title = "Assign",
					message = text,
					rect = this.GetScreenCenteredRect(250f, 200f),
					windowDrawDelegate = new Action<string, string>(this.DrawElementAssignmentWindow)
				}, new Action<int, ControlRemappingDemo1.UserResponse>(this.DialogResultCallback));
				return false;
			}
			if (Event.current.type != EventType.Layout)
			{
				return false;
			}
			if (this.conflictFoundEventData != null)
			{
				ControlRemappingDemo1.ElementAssignmentChange elementAssignmentChange = new ControlRemappingDemo1.ElementAssignmentChange(entry);
				elementAssignmentChange.changeType = ControlRemappingDemo1.ElementAssignmentChangeType.ConflictCheck;
				this.actionQueue.Enqueue(elementAssignmentChange);
			}
			return true;
		}

		// Token: 0x06000E0E RID: 3598 RVA: 0x0004CF7C File Offset: 0x0004B17C
		private bool ProcessElementAssignmentConflictCheck(ControlRemappingDemo1.ElementAssignmentChange entry)
		{
			if (entry.context.controllerMap == null)
			{
				return true;
			}
			if (entry.state == ControlRemappingDemo1.QueueEntry.State.Canceled)
			{
				this.inputMapper.Stop();
				return true;
			}
			if (this.conflictFoundEventData == null)
			{
				return true;
			}
			if (entry.state == ControlRemappingDemo1.QueueEntry.State.Confirmed)
			{
				if (entry.response == ControlRemappingDemo1.UserResponse.Confirm)
				{
					this.conflictFoundEventData.responseCallback(InputMapper.ConflictResponse.Replace);
				}
				else
				{
					if (entry.response != ControlRemappingDemo1.UserResponse.Custom1)
					{
						throw new NotImplementedException();
					}
					this.conflictFoundEventData.responseCallback(InputMapper.ConflictResponse.Add);
				}
				return true;
			}
			if (this.conflictFoundEventData.isProtected)
			{
				string message = this.conflictFoundEventData.assignment.elementDisplayName + " is already in use and is protected from reassignment. You cannot remove the protected assignment, but you can still assign the action to this element. If you do so, the element will trigger multiple actions when activated.";
				this.dialog.StartModal(entry.id, ControlRemappingDemo1.DialogHelper.DialogType.AssignElement, new ControlRemappingDemo1.WindowProperties
				{
					title = "Assignment Conflict",
					message = message,
					rect = this.GetScreenCenteredRect(250f, 200f),
					windowDrawDelegate = new Action<string, string>(this.DrawElementAssignmentProtectedConflictWindow)
				}, new Action<int, ControlRemappingDemo1.UserResponse>(this.DialogResultCallback));
			}
			else
			{
				string message2 = this.conflictFoundEventData.assignment.elementDisplayName + " is already in use. You may replace the other conflicting assignments, add this assignment anyway which will leave multiple actions assigned to this element, or cancel this assignment.";
				this.dialog.StartModal(entry.id, ControlRemappingDemo1.DialogHelper.DialogType.AssignElement, new ControlRemappingDemo1.WindowProperties
				{
					title = "Assignment Conflict",
					message = message2,
					rect = this.GetScreenCenteredRect(250f, 200f),
					windowDrawDelegate = new Action<string, string>(this.DrawElementAssignmentNormalConflictWindow)
				}, new Action<int, ControlRemappingDemo1.UserResponse>(this.DialogResultCallback));
			}
			return false;
		}

		// Token: 0x06000E0F RID: 3599 RVA: 0x0004D118 File Offset: 0x0004B318
		private bool ProcessFallbackJoystickIdentification(ControlRemappingDemo1.FallbackJoystickIdentification entry)
		{
			if (entry.state == ControlRemappingDemo1.QueueEntry.State.Canceled)
			{
				return true;
			}
			if (entry.state == ControlRemappingDemo1.QueueEntry.State.Confirmed)
			{
				return true;
			}
			this.dialog.StartModal(entry.id, ControlRemappingDemo1.DialogHelper.DialogType.JoystickConflict, new ControlRemappingDemo1.WindowProperties
			{
				title = "Joystick Identification Required",
				message = "A joystick has been attached or removed. You will need to identify each joystick by pressing a button on the controller listed below:",
				rect = this.GetScreenCenteredRect(250f, 200f),
				windowDrawDelegate = new Action<string, string>(this.DrawFallbackJoystickIdentificationWindow)
			}, new Action<int, ControlRemappingDemo1.UserResponse>(this.DialogResultCallback), 1f);
			return false;
		}

		// Token: 0x06000E10 RID: 3600 RVA: 0x0004D1AC File Offset: 0x0004B3AC
		private bool ProcessCalibration(ControlRemappingDemo1.Calibration entry)
		{
			if (entry.state == ControlRemappingDemo1.QueueEntry.State.Canceled)
			{
				return true;
			}
			if (entry.state == ControlRemappingDemo1.QueueEntry.State.Confirmed)
			{
				return true;
			}
			this.dialog.StartModal(entry.id, ControlRemappingDemo1.DialogHelper.DialogType.JoystickConflict, new ControlRemappingDemo1.WindowProperties
			{
				title = "Calibrate Controller",
				message = "Select an axis to calibrate on the " + entry.joystick.name + ".",
				rect = this.GetScreenCenteredRect(450f, 480f),
				windowDrawDelegate = new Action<string, string>(this.DrawCalibrationWindow)
			}, new Action<int, ControlRemappingDemo1.UserResponse>(this.DialogResultCallback));
			return false;
		}

		// Token: 0x06000E11 RID: 3601 RVA: 0x0004D24E File Offset: 0x0004B44E
		private void PlayerSelectionChanged()
		{
			this.ClearControllerSelection();
		}

		// Token: 0x06000E12 RID: 3602 RVA: 0x0004D256 File Offset: 0x0004B456
		private void ControllerSelectionChanged()
		{
			this.ClearMapSelection();
		}

		// Token: 0x06000E13 RID: 3603 RVA: 0x0004D25E File Offset: 0x0004B45E
		private void ClearControllerSelection()
		{
			this.selectedController.Clear();
			this.ClearMapSelection();
		}

		// Token: 0x06000E14 RID: 3604 RVA: 0x0004D271 File Offset: 0x0004B471
		private void ClearMapSelection()
		{
			this.selectedMapCategoryId = -1;
			this.selectedMap = null;
		}

		// Token: 0x06000E15 RID: 3605 RVA: 0x0004D281 File Offset: 0x0004B481
		private void ResetAll()
		{
			this.ClearWorkingVars();
			this.initialized = false;
			this.showMenu = false;
		}

		// Token: 0x06000E16 RID: 3606 RVA: 0x0004D298 File Offset: 0x0004B498
		private void ClearWorkingVars()
		{
			this.selectedPlayer = null;
			this.ClearMapSelection();
			this.selectedController.Clear();
			this.actionScrollPos = default(Vector2);
			this.dialog.FullReset();
			this.actionQueue.Clear();
			this.busy = false;
			this.startListening = false;
			this.conflictFoundEventData = null;
			this.inputMapper.Stop();
		}

		// Token: 0x06000E17 RID: 3607 RVA: 0x0004D300 File Offset: 0x0004B500
		private void SetGUIStateStart()
		{
			this.guiState = true;
			if (this.busy)
			{
				this.guiState = false;
			}
			this.pageGUIState = (this.guiState && !this.busy && !this.dialog.enabled && !this.dialog.busy);
			if (GUI.enabled != this.guiState)
			{
				GUI.enabled = this.guiState;
			}
		}

		// Token: 0x06000E18 RID: 3608 RVA: 0x0004D36F File Offset: 0x0004B56F
		private void SetGUIStateEnd()
		{
			this.guiState = true;
			if (!GUI.enabled)
			{
				GUI.enabled = this.guiState;
			}
		}

		// Token: 0x06000E19 RID: 3609 RVA: 0x0004D38C File Offset: 0x0004B58C
		private void JoystickConnected(ControllerStatusChangedEventArgs args)
		{
			if (ReInput.controllers.IsControllerAssigned(args.controllerType, args.controllerId))
			{
				using (IEnumerator<Player> enumerator = ReInput.players.AllPlayers.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Player player = enumerator.Current;
						if (player.controllers.ContainsController(args.controllerType, args.controllerId))
						{
							ReInput.userDataStore.LoadControllerData(player.id, args.controllerType, args.controllerId);
						}
					}
					goto IL_90;
				}
			}
			ReInput.userDataStore.LoadControllerData(args.controllerType, args.controllerId);
			IL_90:
			if (ReInput.unityJoystickIdentificationRequired)
			{
				this.IdentifyAllJoysticks();
			}
		}

		// Token: 0x06000E1A RID: 3610 RVA: 0x0004D448 File Offset: 0x0004B648
		private void JoystickPreDisconnect(ControllerStatusChangedEventArgs args)
		{
			if (this.selectedController.hasSelection && args.controllerType == this.selectedController.type && args.controllerId == this.selectedController.id)
			{
				this.ClearControllerSelection();
			}
			if (this.showMenu)
			{
				if (ReInput.controllers.IsControllerAssigned(args.controllerType, args.controllerId))
				{
					using (IEnumerator<Player> enumerator = ReInput.players.AllPlayers.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							Player player = enumerator.Current;
							if (player.controllers.ContainsController(args.controllerType, args.controllerId))
							{
								ReInput.userDataStore.SaveControllerData(player.id, args.controllerType, args.controllerId);
							}
						}
						return;
					}
				}
				ReInput.userDataStore.SaveControllerData(args.controllerType, args.controllerId);
			}
		}

		// Token: 0x06000E1B RID: 3611 RVA: 0x0004D53C File Offset: 0x0004B73C
		private void JoystickDisconnected(ControllerStatusChangedEventArgs args)
		{
			if (this.showMenu)
			{
				this.ClearWorkingVars();
			}
			if (ReInput.unityJoystickIdentificationRequired)
			{
				this.IdentifyAllJoysticks();
			}
		}

		// Token: 0x06000E1C RID: 3612 RVA: 0x0004D559 File Offset: 0x0004B759
		private void OnConflictFound(InputMapper.ConflictFoundEventData data)
		{
			this.conflictFoundEventData = data;
		}

		// Token: 0x06000E1D RID: 3613 RVA: 0x0004D562 File Offset: 0x0004B762
		private void OnStopped(InputMapper.StoppedEventData data)
		{
			this.conflictFoundEventData = null;
		}

		// Token: 0x06000E1E RID: 3614 RVA: 0x0004D56C File Offset: 0x0004B76C
		public void IdentifyAllJoysticks()
		{
			if (ReInput.controllers.joystickCount == 0)
			{
				return;
			}
			this.ClearWorkingVars();
			this.Open();
			foreach (Joystick joystick in ReInput.controllers.Joysticks)
			{
				this.actionQueue.Enqueue(new ControlRemappingDemo1.FallbackJoystickIdentification(joystick.id, joystick.name));
			}
		}

		// Token: 0x06000E1F RID: 3615 RVA: 0x000020BE File Offset: 0x000002BE
		protected void CheckRecompile()
		{
		}

		// Token: 0x06000E20 RID: 3616 RVA: 0x000020BE File Offset: 0x000002BE
		private void RecompileWindow(int windowId)
		{
		}

		// Token: 0x040012C1 RID: 4801
		private const float defaultModalWidth = 250f;

		// Token: 0x040012C2 RID: 4802
		private const float defaultModalHeight = 200f;

		// Token: 0x040012C3 RID: 4803
		private const float assignmentTimeout = 5f;

		// Token: 0x040012C4 RID: 4804
		private ControlRemappingDemo1.DialogHelper dialog;

		// Token: 0x040012C5 RID: 4805
		private InputMapper inputMapper = new InputMapper();

		// Token: 0x040012C6 RID: 4806
		private InputMapper.ConflictFoundEventData conflictFoundEventData;

		// Token: 0x040012C7 RID: 4807
		private bool guiState;

		// Token: 0x040012C8 RID: 4808
		private bool busy;

		// Token: 0x040012C9 RID: 4809
		private bool pageGUIState;

		// Token: 0x040012CA RID: 4810
		private Player selectedPlayer;

		// Token: 0x040012CB RID: 4811
		private int selectedMapCategoryId;

		// Token: 0x040012CC RID: 4812
		private ControlRemappingDemo1.ControllerSelection selectedController;

		// Token: 0x040012CD RID: 4813
		private ControllerMap selectedMap;

		// Token: 0x040012CE RID: 4814
		private bool showMenu;

		// Token: 0x040012CF RID: 4815
		private bool startListening;

		// Token: 0x040012D0 RID: 4816
		private Vector2 actionScrollPos;

		// Token: 0x040012D1 RID: 4817
		private Vector2 calibrateScrollPos;

		// Token: 0x040012D2 RID: 4818
		private Queue<ControlRemappingDemo1.QueueEntry> actionQueue;

		// Token: 0x040012D3 RID: 4819
		private bool setupFinished;

		// Token: 0x040012D4 RID: 4820
		[NonSerialized]
		private bool initialized;

		// Token: 0x040012D5 RID: 4821
		private bool isCompiling;

		// Token: 0x040012D6 RID: 4822
		private GUIStyle style_wordWrap;

		// Token: 0x040012D7 RID: 4823
		private GUIStyle style_centeredBox;

		// Token: 0x020002A1 RID: 673
		private class ControllerSelection
		{
			// Token: 0x06000E22 RID: 3618 RVA: 0x0004D5FF File Offset: 0x0004B7FF
			public ControllerSelection()
			{
				this.Clear();
			}

			// Token: 0x170002E1 RID: 737
			// (get) Token: 0x06000E23 RID: 3619 RVA: 0x0004D60D File Offset: 0x0004B80D
			// (set) Token: 0x06000E24 RID: 3620 RVA: 0x0004D615 File Offset: 0x0004B815
			public int id
			{
				get
				{
					return this._id;
				}
				set
				{
					this._idPrev = this._id;
					this._id = value;
				}
			}

			// Token: 0x170002E2 RID: 738
			// (get) Token: 0x06000E25 RID: 3621 RVA: 0x0004D62A File Offset: 0x0004B82A
			// (set) Token: 0x06000E26 RID: 3622 RVA: 0x0004D632 File Offset: 0x0004B832
			public ControllerType type
			{
				get
				{
					return this._type;
				}
				set
				{
					this._typePrev = this._type;
					this._type = value;
				}
			}

			// Token: 0x170002E3 RID: 739
			// (get) Token: 0x06000E27 RID: 3623 RVA: 0x0004D647 File Offset: 0x0004B847
			public int idPrev
			{
				get
				{
					return this._idPrev;
				}
			}

			// Token: 0x170002E4 RID: 740
			// (get) Token: 0x06000E28 RID: 3624 RVA: 0x0004D64F File Offset: 0x0004B84F
			public ControllerType typePrev
			{
				get
				{
					return this._typePrev;
				}
			}

			// Token: 0x170002E5 RID: 741
			// (get) Token: 0x06000E29 RID: 3625 RVA: 0x0004D657 File Offset: 0x0004B857
			public bool hasSelection
			{
				get
				{
					return this._id >= 0;
				}
			}

			// Token: 0x06000E2A RID: 3626 RVA: 0x0004D665 File Offset: 0x0004B865
			public void Set(int id, ControllerType type)
			{
				this.id = id;
				this.type = type;
			}

			// Token: 0x06000E2B RID: 3627 RVA: 0x0004D675 File Offset: 0x0004B875
			public void Clear()
			{
				this._id = -1;
				this._idPrev = -1;
				this._type = ControllerType.Joystick;
				this._typePrev = ControllerType.Joystick;
			}

			// Token: 0x040012D8 RID: 4824
			private int _id;

			// Token: 0x040012D9 RID: 4825
			private int _idPrev;

			// Token: 0x040012DA RID: 4826
			private ControllerType _type;

			// Token: 0x040012DB RID: 4827
			private ControllerType _typePrev;
		}

		// Token: 0x020002A2 RID: 674
		private class DialogHelper
		{
			// Token: 0x170002E6 RID: 742
			// (get) Token: 0x06000E2C RID: 3628 RVA: 0x0004D693 File Offset: 0x0004B893
			private float busyTimer
			{
				get
				{
					if (!this._busyTimerRunning)
					{
						return 0f;
					}
					return this._busyTime - Time.realtimeSinceStartup;
				}
			}

			// Token: 0x170002E7 RID: 743
			// (get) Token: 0x06000E2D RID: 3629 RVA: 0x0004D6AF File Offset: 0x0004B8AF
			// (set) Token: 0x06000E2E RID: 3630 RVA: 0x0004D6B7 File Offset: 0x0004B8B7
			public bool enabled
			{
				get
				{
					return this._enabled;
				}
				set
				{
					if (!value)
					{
						this._enabled = value;
						this._type = ControlRemappingDemo1.DialogHelper.DialogType.None;
						this.StateChanged(0.1f);
						return;
					}
					if (this._type == ControlRemappingDemo1.DialogHelper.DialogType.None)
					{
						return;
					}
					this.StateChanged(0.25f);
				}
			}

			// Token: 0x170002E8 RID: 744
			// (get) Token: 0x06000E2F RID: 3631 RVA: 0x0004D6EA File Offset: 0x0004B8EA
			// (set) Token: 0x06000E30 RID: 3632 RVA: 0x0004D6FC File Offset: 0x0004B8FC
			public ControlRemappingDemo1.DialogHelper.DialogType type
			{
				get
				{
					if (!this._enabled)
					{
						return ControlRemappingDemo1.DialogHelper.DialogType.None;
					}
					return this._type;
				}
				set
				{
					if (value == ControlRemappingDemo1.DialogHelper.DialogType.None)
					{
						this._enabled = false;
						this.StateChanged(0.1f);
					}
					else
					{
						this._enabled = true;
						this.StateChanged(0.25f);
					}
					this._type = value;
				}
			}

			// Token: 0x170002E9 RID: 745
			// (get) Token: 0x06000E31 RID: 3633 RVA: 0x0004D72E File Offset: 0x0004B92E
			public bool busy
			{
				get
				{
					return this._busyTimerRunning;
				}
			}

			// Token: 0x06000E32 RID: 3634 RVA: 0x0004D736 File Offset: 0x0004B936
			public DialogHelper()
			{
				this.drawWindowDelegate = new Action<int>(this.DrawWindow);
				this.drawWindowFunction = new GUI.WindowFunction(this.drawWindowDelegate.Invoke);
			}

			// Token: 0x06000E33 RID: 3635 RVA: 0x0004D767 File Offset: 0x0004B967
			public void StartModal(int queueActionId, ControlRemappingDemo1.DialogHelper.DialogType type, ControlRemappingDemo1.WindowProperties windowProperties, Action<int, ControlRemappingDemo1.UserResponse> resultCallback)
			{
				this.StartModal(queueActionId, type, windowProperties, resultCallback, -1f);
			}

			// Token: 0x06000E34 RID: 3636 RVA: 0x0004D779 File Offset: 0x0004B979
			public void StartModal(int queueActionId, ControlRemappingDemo1.DialogHelper.DialogType type, ControlRemappingDemo1.WindowProperties windowProperties, Action<int, ControlRemappingDemo1.UserResponse> resultCallback, float openBusyDelay)
			{
				this.currentActionId = queueActionId;
				this.windowProperties = windowProperties;
				this.type = type;
				this.resultCallback = resultCallback;
				if (openBusyDelay >= 0f)
				{
					this.StateChanged(openBusyDelay);
				}
			}

			// Token: 0x06000E35 RID: 3637 RVA: 0x0004D7A9 File Offset: 0x0004B9A9
			public void Update()
			{
				this.Draw();
				this.UpdateTimers();
			}

			// Token: 0x06000E36 RID: 3638 RVA: 0x0004D7B8 File Offset: 0x0004B9B8
			public void Draw()
			{
				if (!this._enabled)
				{
					return;
				}
				bool enabled = GUI.enabled;
				GUI.enabled = true;
				GUILayout.Window(this.windowProperties.windowId, this.windowProperties.rect, this.drawWindowFunction, this.windowProperties.title, Array.Empty<GUILayoutOption>());
				GUI.FocusWindow(this.windowProperties.windowId);
				if (GUI.enabled != enabled)
				{
					GUI.enabled = enabled;
				}
			}

			// Token: 0x06000E37 RID: 3639 RVA: 0x0004D82A File Offset: 0x0004BA2A
			public void DrawConfirmButton()
			{
				this.DrawConfirmButton("Confirm");
			}

			// Token: 0x06000E38 RID: 3640 RVA: 0x0004D838 File Offset: 0x0004BA38
			public void DrawConfirmButton(string title)
			{
				bool enabled = GUI.enabled;
				if (this.busy)
				{
					GUI.enabled = false;
				}
				if (GUILayout.Button(title, Array.Empty<GUILayoutOption>()))
				{
					this.Confirm(ControlRemappingDemo1.UserResponse.Confirm);
				}
				if (GUI.enabled != enabled)
				{
					GUI.enabled = enabled;
				}
			}

			// Token: 0x06000E39 RID: 3641 RVA: 0x0004D87B File Offset: 0x0004BA7B
			public void DrawConfirmButton(ControlRemappingDemo1.UserResponse response)
			{
				this.DrawConfirmButton(response, "Confirm");
			}

			// Token: 0x06000E3A RID: 3642 RVA: 0x0004D88C File Offset: 0x0004BA8C
			public void DrawConfirmButton(ControlRemappingDemo1.UserResponse response, string title)
			{
				bool enabled = GUI.enabled;
				if (this.busy)
				{
					GUI.enabled = false;
				}
				if (GUILayout.Button(title, Array.Empty<GUILayoutOption>()))
				{
					this.Confirm(response);
				}
				if (GUI.enabled != enabled)
				{
					GUI.enabled = enabled;
				}
			}

			// Token: 0x06000E3B RID: 3643 RVA: 0x0004D8CF File Offset: 0x0004BACF
			public void DrawCancelButton()
			{
				this.DrawCancelButton("Cancel");
			}

			// Token: 0x06000E3C RID: 3644 RVA: 0x0004D8DC File Offset: 0x0004BADC
			public void DrawCancelButton(string title)
			{
				bool enabled = GUI.enabled;
				if (this.busy)
				{
					GUI.enabled = false;
				}
				if (GUILayout.Button(title, Array.Empty<GUILayoutOption>()))
				{
					this.Cancel();
				}
				if (GUI.enabled != enabled)
				{
					GUI.enabled = enabled;
				}
			}

			// Token: 0x06000E3D RID: 3645 RVA: 0x0004D91E File Offset: 0x0004BB1E
			public void Confirm()
			{
				this.Confirm(ControlRemappingDemo1.UserResponse.Confirm);
			}

			// Token: 0x06000E3E RID: 3646 RVA: 0x0004D927 File Offset: 0x0004BB27
			public void Confirm(ControlRemappingDemo1.UserResponse response)
			{
				this.resultCallback(this.currentActionId, response);
				this.Close();
			}

			// Token: 0x06000E3F RID: 3647 RVA: 0x0004D941 File Offset: 0x0004BB41
			public void Cancel()
			{
				this.resultCallback(this.currentActionId, ControlRemappingDemo1.UserResponse.Cancel);
				this.Close();
			}

			// Token: 0x06000E40 RID: 3648 RVA: 0x0004D95B File Offset: 0x0004BB5B
			private void DrawWindow(int windowId)
			{
				this.windowProperties.windowDrawDelegate(this.windowProperties.title, this.windowProperties.message);
			}

			// Token: 0x06000E41 RID: 3649 RVA: 0x0004D983 File Offset: 0x0004BB83
			private void UpdateTimers()
			{
				if (this._busyTimerRunning && this.busyTimer <= 0f)
				{
					this._busyTimerRunning = false;
				}
			}

			// Token: 0x06000E42 RID: 3650 RVA: 0x0004D9A1 File Offset: 0x0004BBA1
			private void StartBusyTimer(float time)
			{
				this._busyTime = time + Time.realtimeSinceStartup;
				this._busyTimerRunning = true;
			}

			// Token: 0x06000E43 RID: 3651 RVA: 0x0004D9B7 File Offset: 0x0004BBB7
			private void Close()
			{
				this.Reset();
				this.StateChanged(0.1f);
			}

			// Token: 0x06000E44 RID: 3652 RVA: 0x0004D9CA File Offset: 0x0004BBCA
			private void StateChanged(float delay)
			{
				this.StartBusyTimer(delay);
			}

			// Token: 0x06000E45 RID: 3653 RVA: 0x0004D9D3 File Offset: 0x0004BBD3
			private void Reset()
			{
				this._enabled = false;
				this._type = ControlRemappingDemo1.DialogHelper.DialogType.None;
				this.currentActionId = -1;
				this.resultCallback = null;
			}

			// Token: 0x06000E46 RID: 3654 RVA: 0x0004D9F1 File Offset: 0x0004BBF1
			private void ResetTimers()
			{
				this._busyTimerRunning = false;
			}

			// Token: 0x06000E47 RID: 3655 RVA: 0x0004D9FA File Offset: 0x0004BBFA
			public void FullReset()
			{
				this.Reset();
				this.ResetTimers();
			}

			// Token: 0x040012DC RID: 4828
			private const float openBusyDelay = 0.25f;

			// Token: 0x040012DD RID: 4829
			private const float closeBusyDelay = 0.1f;

			// Token: 0x040012DE RID: 4830
			private ControlRemappingDemo1.DialogHelper.DialogType _type;

			// Token: 0x040012DF RID: 4831
			private bool _enabled;

			// Token: 0x040012E0 RID: 4832
			private float _busyTime;

			// Token: 0x040012E1 RID: 4833
			private bool _busyTimerRunning;

			// Token: 0x040012E2 RID: 4834
			private Action<int> drawWindowDelegate;

			// Token: 0x040012E3 RID: 4835
			private GUI.WindowFunction drawWindowFunction;

			// Token: 0x040012E4 RID: 4836
			private ControlRemappingDemo1.WindowProperties windowProperties;

			// Token: 0x040012E5 RID: 4837
			private int currentActionId;

			// Token: 0x040012E6 RID: 4838
			private Action<int, ControlRemappingDemo1.UserResponse> resultCallback;

			// Token: 0x020002A3 RID: 675
			public enum DialogType
			{
				// Token: 0x040012E8 RID: 4840
				None,
				// Token: 0x040012E9 RID: 4841
				JoystickConflict,
				// Token: 0x040012EA RID: 4842
				ElementConflict,
				// Token: 0x040012EB RID: 4843
				KeyConflict,
				// Token: 0x040012EC RID: 4844
				DeleteAssignmentConfirmation = 10,
				// Token: 0x040012ED RID: 4845
				AssignElement
			}
		}

		// Token: 0x020002A4 RID: 676
		private abstract class QueueEntry
		{
			// Token: 0x170002EA RID: 746
			// (get) Token: 0x06000E48 RID: 3656 RVA: 0x0004DA08 File Offset: 0x0004BC08
			// (set) Token: 0x06000E49 RID: 3657 RVA: 0x0004DA10 File Offset: 0x0004BC10
			public int id { get; protected set; }

			// Token: 0x170002EB RID: 747
			// (get) Token: 0x06000E4A RID: 3658 RVA: 0x0004DA19 File Offset: 0x0004BC19
			// (set) Token: 0x06000E4B RID: 3659 RVA: 0x0004DA21 File Offset: 0x0004BC21
			public ControlRemappingDemo1.QueueActionType queueActionType { get; protected set; }

			// Token: 0x170002EC RID: 748
			// (get) Token: 0x06000E4C RID: 3660 RVA: 0x0004DA2A File Offset: 0x0004BC2A
			// (set) Token: 0x06000E4D RID: 3661 RVA: 0x0004DA32 File Offset: 0x0004BC32
			public ControlRemappingDemo1.QueueEntry.State state { get; protected set; }

			// Token: 0x170002ED RID: 749
			// (get) Token: 0x06000E4E RID: 3662 RVA: 0x0004DA3B File Offset: 0x0004BC3B
			// (set) Token: 0x06000E4F RID: 3663 RVA: 0x0004DA43 File Offset: 0x0004BC43
			public ControlRemappingDemo1.UserResponse response { get; protected set; }

			// Token: 0x170002EE RID: 750
			// (get) Token: 0x06000E50 RID: 3664 RVA: 0x0004DA4C File Offset: 0x0004BC4C
			protected static int nextId
			{
				get
				{
					int result = ControlRemappingDemo1.QueueEntry.uidCounter;
					ControlRemappingDemo1.QueueEntry.uidCounter++;
					return result;
				}
			}

			// Token: 0x06000E51 RID: 3665 RVA: 0x0004DA5F File Offset: 0x0004BC5F
			public QueueEntry(ControlRemappingDemo1.QueueActionType queueActionType)
			{
				this.id = ControlRemappingDemo1.QueueEntry.nextId;
				this.queueActionType = queueActionType;
			}

			// Token: 0x06000E52 RID: 3666 RVA: 0x0004DA79 File Offset: 0x0004BC79
			public void Confirm(ControlRemappingDemo1.UserResponse response)
			{
				this.state = ControlRemappingDemo1.QueueEntry.State.Confirmed;
				this.response = response;
			}

			// Token: 0x06000E53 RID: 3667 RVA: 0x0004DA89 File Offset: 0x0004BC89
			public void Cancel()
			{
				this.state = ControlRemappingDemo1.QueueEntry.State.Canceled;
			}

			// Token: 0x040012F2 RID: 4850
			private static int uidCounter;

			// Token: 0x020002A5 RID: 677
			public enum State
			{
				// Token: 0x040012F4 RID: 4852
				Waiting,
				// Token: 0x040012F5 RID: 4853
				Confirmed,
				// Token: 0x040012F6 RID: 4854
				Canceled
			}
		}

		// Token: 0x020002A6 RID: 678
		private class JoystickAssignmentChange : ControlRemappingDemo1.QueueEntry
		{
			// Token: 0x170002EF RID: 751
			// (get) Token: 0x06000E54 RID: 3668 RVA: 0x0004DA92 File Offset: 0x0004BC92
			// (set) Token: 0x06000E55 RID: 3669 RVA: 0x0004DA9A File Offset: 0x0004BC9A
			public int playerId { get; private set; }

			// Token: 0x170002F0 RID: 752
			// (get) Token: 0x06000E56 RID: 3670 RVA: 0x0004DAA3 File Offset: 0x0004BCA3
			// (set) Token: 0x06000E57 RID: 3671 RVA: 0x0004DAAB File Offset: 0x0004BCAB
			public int joystickId { get; private set; }

			// Token: 0x170002F1 RID: 753
			// (get) Token: 0x06000E58 RID: 3672 RVA: 0x0004DAB4 File Offset: 0x0004BCB4
			// (set) Token: 0x06000E59 RID: 3673 RVA: 0x0004DABC File Offset: 0x0004BCBC
			public bool assign { get; private set; }

			// Token: 0x06000E5A RID: 3674 RVA: 0x0004DAC5 File Offset: 0x0004BCC5
			public JoystickAssignmentChange(int newPlayerId, int joystickId, bool assign) : base(ControlRemappingDemo1.QueueActionType.JoystickAssignment)
			{
				this.playerId = newPlayerId;
				this.joystickId = joystickId;
				this.assign = assign;
			}
		}

		// Token: 0x020002A7 RID: 679
		private class ElementAssignmentChange : ControlRemappingDemo1.QueueEntry
		{
			// Token: 0x170002F2 RID: 754
			// (get) Token: 0x06000E5B RID: 3675 RVA: 0x0004DAE3 File Offset: 0x0004BCE3
			// (set) Token: 0x06000E5C RID: 3676 RVA: 0x0004DAEB File Offset: 0x0004BCEB
			public ControlRemappingDemo1.ElementAssignmentChangeType changeType { get; set; }

			// Token: 0x170002F3 RID: 755
			// (get) Token: 0x06000E5D RID: 3677 RVA: 0x0004DAF4 File Offset: 0x0004BCF4
			// (set) Token: 0x06000E5E RID: 3678 RVA: 0x0004DAFC File Offset: 0x0004BCFC
			public InputMapper.Context context { get; private set; }

			// Token: 0x06000E5F RID: 3679 RVA: 0x0004DB05 File Offset: 0x0004BD05
			public ElementAssignmentChange(ControlRemappingDemo1.ElementAssignmentChangeType changeType, InputMapper.Context context) : base(ControlRemappingDemo1.QueueActionType.ElementAssignment)
			{
				this.changeType = changeType;
				this.context = context;
			}

			// Token: 0x06000E60 RID: 3680 RVA: 0x0004DB1C File Offset: 0x0004BD1C
			public ElementAssignmentChange(ControlRemappingDemo1.ElementAssignmentChange other) : this(other.changeType, other.context.Clone())
			{
			}
		}

		// Token: 0x020002A8 RID: 680
		private class FallbackJoystickIdentification : ControlRemappingDemo1.QueueEntry
		{
			// Token: 0x170002F4 RID: 756
			// (get) Token: 0x06000E61 RID: 3681 RVA: 0x0004DB35 File Offset: 0x0004BD35
			// (set) Token: 0x06000E62 RID: 3682 RVA: 0x0004DB3D File Offset: 0x0004BD3D
			public int joystickId { get; private set; }

			// Token: 0x170002F5 RID: 757
			// (get) Token: 0x06000E63 RID: 3683 RVA: 0x0004DB46 File Offset: 0x0004BD46
			// (set) Token: 0x06000E64 RID: 3684 RVA: 0x0004DB4E File Offset: 0x0004BD4E
			public string joystickName { get; private set; }

			// Token: 0x06000E65 RID: 3685 RVA: 0x0004DB57 File Offset: 0x0004BD57
			public FallbackJoystickIdentification(int joystickId, string joystickName) : base(ControlRemappingDemo1.QueueActionType.FallbackJoystickIdentification)
			{
				this.joystickId = joystickId;
				this.joystickName = joystickName;
			}
		}

		// Token: 0x020002A9 RID: 681
		private class Calibration : ControlRemappingDemo1.QueueEntry
		{
			// Token: 0x170002F6 RID: 758
			// (get) Token: 0x06000E66 RID: 3686 RVA: 0x0004DB6E File Offset: 0x0004BD6E
			// (set) Token: 0x06000E67 RID: 3687 RVA: 0x0004DB76 File Offset: 0x0004BD76
			public Player player { get; private set; }

			// Token: 0x170002F7 RID: 759
			// (get) Token: 0x06000E68 RID: 3688 RVA: 0x0004DB7F File Offset: 0x0004BD7F
			// (set) Token: 0x06000E69 RID: 3689 RVA: 0x0004DB87 File Offset: 0x0004BD87
			public ControllerType controllerType { get; private set; }

			// Token: 0x170002F8 RID: 760
			// (get) Token: 0x06000E6A RID: 3690 RVA: 0x0004DB90 File Offset: 0x0004BD90
			// (set) Token: 0x06000E6B RID: 3691 RVA: 0x0004DB98 File Offset: 0x0004BD98
			public Joystick joystick { get; private set; }

			// Token: 0x170002F9 RID: 761
			// (get) Token: 0x06000E6C RID: 3692 RVA: 0x0004DBA1 File Offset: 0x0004BDA1
			// (set) Token: 0x06000E6D RID: 3693 RVA: 0x0004DBA9 File Offset: 0x0004BDA9
			public CalibrationMap calibrationMap { get; private set; }

			// Token: 0x06000E6E RID: 3694 RVA: 0x0004DBB2 File Offset: 0x0004BDB2
			public Calibration(Player player, Joystick joystick, CalibrationMap calibrationMap) : base(ControlRemappingDemo1.QueueActionType.Calibrate)
			{
				this.player = player;
				this.joystick = joystick;
				this.calibrationMap = calibrationMap;
				this.selectedElementIdentifierId = -1;
			}

			// Token: 0x04001302 RID: 4866
			public int selectedElementIdentifierId;

			// Token: 0x04001303 RID: 4867
			public bool recording;
		}

		// Token: 0x020002AA RID: 682
		private struct WindowProperties
		{
			// Token: 0x04001304 RID: 4868
			public int windowId;

			// Token: 0x04001305 RID: 4869
			public Rect rect;

			// Token: 0x04001306 RID: 4870
			public Action<string, string> windowDrawDelegate;

			// Token: 0x04001307 RID: 4871
			public string title;

			// Token: 0x04001308 RID: 4872
			public string message;
		}

		// Token: 0x020002AB RID: 683
		private enum QueueActionType
		{
			// Token: 0x0400130A RID: 4874
			None,
			// Token: 0x0400130B RID: 4875
			JoystickAssignment,
			// Token: 0x0400130C RID: 4876
			ElementAssignment,
			// Token: 0x0400130D RID: 4877
			FallbackJoystickIdentification,
			// Token: 0x0400130E RID: 4878
			Calibrate
		}

		// Token: 0x020002AC RID: 684
		private enum ElementAssignmentChangeType
		{
			// Token: 0x04001310 RID: 4880
			Add,
			// Token: 0x04001311 RID: 4881
			Replace,
			// Token: 0x04001312 RID: 4882
			Remove,
			// Token: 0x04001313 RID: 4883
			ReassignOrRemove,
			// Token: 0x04001314 RID: 4884
			ConflictCheck
		}

		// Token: 0x020002AD RID: 685
		public enum UserResponse
		{
			// Token: 0x04001316 RID: 4886
			Confirm,
			// Token: 0x04001317 RID: 4887
			Cancel,
			// Token: 0x04001318 RID: 4888
			Custom1,
			// Token: 0x04001319 RID: 4889
			Custom2
		}
	}
}
