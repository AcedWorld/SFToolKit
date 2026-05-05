using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired.Data
{
	// Token: 0x0200027C RID: 636
	public abstract class UserDataStore_KeyValue : UserDataStore
	{
		// Token: 0x17000289 RID: 649
		// (get) Token: 0x06000C32 RID: 3122 RVA: 0x00044595 File Offset: 0x00042795
		// (set) Token: 0x06000C33 RID: 3123 RVA: 0x0004459D File Offset: 0x0004279D
		public bool isEnabled
		{
			get
			{
				return this._isEnabled;
			}
			set
			{
				this._isEnabled = value;
			}
		}

		// Token: 0x1700028A RID: 650
		// (get) Token: 0x06000C34 RID: 3124 RVA: 0x000445A6 File Offset: 0x000427A6
		// (set) Token: 0x06000C35 RID: 3125 RVA: 0x000445AE File Offset: 0x000427AE
		public bool loadDataOnStart
		{
			get
			{
				return this._loadDataOnStart;
			}
			set
			{
				this._loadDataOnStart = value;
			}
		}

		// Token: 0x1700028B RID: 651
		// (get) Token: 0x06000C36 RID: 3126 RVA: 0x000445B7 File Offset: 0x000427B7
		// (set) Token: 0x06000C37 RID: 3127 RVA: 0x000445BF File Offset: 0x000427BF
		public bool loadJoystickAssignments
		{
			get
			{
				return this._loadJoystickAssignments;
			}
			set
			{
				this._loadJoystickAssignments = value;
			}
		}

		// Token: 0x1700028C RID: 652
		// (get) Token: 0x06000C38 RID: 3128 RVA: 0x000445C8 File Offset: 0x000427C8
		// (set) Token: 0x06000C39 RID: 3129 RVA: 0x000445D0 File Offset: 0x000427D0
		public bool loadKeyboardAssignments
		{
			get
			{
				return this._loadKeyboardAssignments;
			}
			set
			{
				this._loadKeyboardAssignments = value;
			}
		}

		// Token: 0x1700028D RID: 653
		// (get) Token: 0x06000C3A RID: 3130 RVA: 0x000445D9 File Offset: 0x000427D9
		// (set) Token: 0x06000C3B RID: 3131 RVA: 0x000445E1 File Offset: 0x000427E1
		public bool loadMouseAssignments
		{
			get
			{
				return this._loadMouseAssignments;
			}
			set
			{
				this._loadMouseAssignments = value;
			}
		}

		// Token: 0x1700028E RID: 654
		// (get) Token: 0x06000C3C RID: 3132
		protected abstract UserDataStore_KeyValue.IDataStore dataStore { get; }

		// Token: 0x1700028F RID: 655
		// (get) Token: 0x06000C3D RID: 3133 RVA: 0x000445EA File Offset: 0x000427EA
		private bool loadControllerAssignments
		{
			get
			{
				return this._loadKeyboardAssignments || this._loadMouseAssignments || this._loadJoystickAssignments;
			}
		}

		// Token: 0x17000290 RID: 656
		// (get) Token: 0x06000C3E RID: 3134 RVA: 0x00044604 File Offset: 0x00042804
		private List<int> allActionIds
		{
			get
			{
				if (this.__allActionIds != null)
				{
					return this.__allActionIds;
				}
				List<int> list = new List<int>();
				IList<InputAction> actions = ReInput.mapping.Actions;
				for (int i = 0; i < actions.Count; i++)
				{
					list.Add(actions[i].id);
				}
				this.__allActionIds = list;
				return list;
			}
		}

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x06000C3F RID: 3135 RVA: 0x0004465C File Offset: 0x0004285C
		private string allActionIdsString
		{
			get
			{
				if (!string.IsNullOrEmpty(this.__allActionIdsString))
				{
					return this.__allActionIdsString;
				}
				StringBuilder stringBuilder = new StringBuilder();
				List<int> allActionIds = this.allActionIds;
				for (int i = 0; i < allActionIds.Count; i++)
				{
					if (i > 0)
					{
						stringBuilder.Append(",");
					}
					stringBuilder.Append(allActionIds[i]);
				}
				this.__allActionIdsString = stringBuilder.ToString();
				return this.__allActionIdsString;
			}
		}

		// Token: 0x06000C40 RID: 3136 RVA: 0x000446CB File Offset: 0x000428CB
		public override void Save()
		{
			if (!this._isEnabled)
			{
				Debug.LogWarning("Rewired: " + UserDataStore_KeyValue.thisScriptName + " is disabled and will not save any data.", this);
				return;
			}
			this.SaveAll();
		}

		// Token: 0x06000C41 RID: 3137 RVA: 0x000446F6 File Offset: 0x000428F6
		public override void SaveControllerData(int playerId, ControllerType controllerType, int controllerId)
		{
			if (!this._isEnabled)
			{
				Debug.LogWarning("Rewired: " + UserDataStore_KeyValue.thisScriptName + " is disabled and will not save any data.", this);
				return;
			}
			this.SaveControllerDataNow(playerId, controllerType, controllerId);
		}

		// Token: 0x06000C42 RID: 3138 RVA: 0x00044724 File Offset: 0x00042924
		public override void SaveControllerData(ControllerType controllerType, int controllerId)
		{
			if (!this._isEnabled)
			{
				Debug.LogWarning("Rewired: " + UserDataStore_KeyValue.thisScriptName + " is disabled and will not save any data.", this);
				return;
			}
			this.SaveControllerDataNow(controllerType, controllerId);
		}

		// Token: 0x06000C43 RID: 3139 RVA: 0x00044751 File Offset: 0x00042951
		public override void SavePlayerData(int playerId)
		{
			if (!this._isEnabled)
			{
				Debug.LogWarning("Rewired: " + UserDataStore_KeyValue.thisScriptName + " is disabled and will not save any data.", this);
				return;
			}
			this.SavePlayerDataNow(playerId);
		}

		// Token: 0x06000C44 RID: 3140 RVA: 0x0004477D File Offset: 0x0004297D
		public override void SaveInputBehavior(int playerId, int behaviorId)
		{
			if (!this._isEnabled)
			{
				Debug.LogWarning("Rewired: " + UserDataStore_KeyValue.thisScriptName + " is disabled and will not save any data.", this);
				return;
			}
			this.SaveInputBehaviorNow(playerId, behaviorId);
		}

		// Token: 0x06000C45 RID: 3141 RVA: 0x000447AA File Offset: 0x000429AA
		public override void Load()
		{
			if (!this._isEnabled)
			{
				Debug.LogWarning("Rewired: " + UserDataStore_KeyValue.thisScriptName + " is disabled and will not load any data.", this);
				return;
			}
			this.LoadAll();
		}

		// Token: 0x06000C46 RID: 3142 RVA: 0x000447D6 File Offset: 0x000429D6
		public override void LoadControllerData(int playerId, ControllerType controllerType, int controllerId)
		{
			if (!this._isEnabled)
			{
				Debug.LogWarning("Rewired: " + UserDataStore_KeyValue.thisScriptName + " is disabled and will not load any data.", this);
				return;
			}
			this.LoadControllerDataNow(playerId, controllerType, controllerId);
		}

		// Token: 0x06000C47 RID: 3143 RVA: 0x00044805 File Offset: 0x00042A05
		public override void LoadControllerData(ControllerType controllerType, int controllerId)
		{
			if (!this._isEnabled)
			{
				Debug.LogWarning("Rewired: " + UserDataStore_KeyValue.thisScriptName + " is disabled and will not load any data.", this);
				return;
			}
			this.LoadControllerDataNow(controllerType, controllerId);
		}

		// Token: 0x06000C48 RID: 3144 RVA: 0x00044833 File Offset: 0x00042A33
		public override void LoadPlayerData(int playerId)
		{
			if (!this._isEnabled)
			{
				Debug.LogWarning("Rewired: " + UserDataStore_KeyValue.thisScriptName + " is disabled and will not load any data.", this);
				return;
			}
			this.LoadPlayerDataNow(playerId);
		}

		// Token: 0x06000C49 RID: 3145 RVA: 0x00044860 File Offset: 0x00042A60
		public override void LoadInputBehavior(int playerId, int behaviorId)
		{
			if (!this._isEnabled)
			{
				Debug.LogWarning("Rewired: " + UserDataStore_KeyValue.thisScriptName + " is disabled and will not load any data.", this);
				return;
			}
			this.LoadInputBehaviorNow(playerId, behaviorId);
		}

		// Token: 0x06000C4A RID: 3146 RVA: 0x0004488E File Offset: 0x00042A8E
		protected override void OnInitialize()
		{
			if (this._loadDataOnStart)
			{
				this.Load();
				if (this.loadControllerAssignments && ReInput.controllers.joystickCount > 0)
				{
					this._wasJoystickEverDetected = true;
					this.SaveControllerAssignments();
				}
			}
		}

		// Token: 0x06000C4B RID: 3147 RVA: 0x000448C4 File Offset: 0x00042AC4
		protected override void OnControllerConnected(ControllerStatusChangedEventArgs args)
		{
			if (!this._isEnabled)
			{
				return;
			}
			if (args.controllerType == ControllerType.Joystick)
			{
				this.LoadJoystickData(args.controllerId);
				if (this._loadDataOnStart && this._loadJoystickAssignments && !this._wasJoystickEverDetected)
				{
					base.StartCoroutine(this.LoadJoystickAssignmentsDeferred());
				}
				if (this._loadJoystickAssignments && !this._deferredJoystickAssignmentLoadPending)
				{
					this.SaveControllerAssignments();
				}
				this._wasJoystickEverDetected = true;
			}
		}

		// Token: 0x06000C4C RID: 3148 RVA: 0x00044933 File Offset: 0x00042B33
		protected override void OnControllerPreDisconnect(ControllerStatusChangedEventArgs args)
		{
			if (!this._isEnabled)
			{
				return;
			}
			if (args.controllerType == ControllerType.Joystick)
			{
				this.SaveJoystickData(args.controllerId);
			}
		}

		// Token: 0x06000C4D RID: 3149 RVA: 0x00044953 File Offset: 0x00042B53
		protected override void OnControllerDisconnected(ControllerStatusChangedEventArgs args)
		{
			if (!this._isEnabled)
			{
				return;
			}
			if (this.loadControllerAssignments)
			{
				this.SaveControllerAssignments();
			}
		}

		// Token: 0x06000C4E RID: 3150 RVA: 0x00044970 File Offset: 0x00042B70
		public override void SaveControllerMap(int playerId, ControllerMap controllerMap)
		{
			if (controllerMap == null)
			{
				return;
			}
			Player player = ReInput.players.GetPlayer(playerId);
			if (player == null)
			{
				return;
			}
			this.SaveControllerMap(player, controllerMap);
			this.dataStore.Save();
		}

		// Token: 0x06000C4F RID: 3151 RVA: 0x000449A8 File Offset: 0x00042BA8
		public override ControllerMap LoadControllerMap(int playerId, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId)
		{
			Player player = ReInput.players.GetPlayer(playerId);
			if (player == null)
			{
				return null;
			}
			return this.LoadControllerMap(player, controllerIdentifier, categoryId, layoutId);
		}

		// Token: 0x06000C50 RID: 3152 RVA: 0x000449D1 File Offset: 0x00042BD1
		public virtual void ClearSaveData()
		{
			this.dataStore.Clear();
		}

		// Token: 0x06000C51 RID: 3153 RVA: 0x000449E0 File Offset: 0x00042BE0
		private int LoadAll()
		{
			int num = 0;
			if (this.loadControllerAssignments && this.LoadControllerAssignmentsNow())
			{
				num++;
			}
			IList<Player> allPlayers = ReInput.players.AllPlayers;
			for (int i = 0; i < allPlayers.Count; i++)
			{
				num += this.LoadPlayerDataNow(allPlayers[i]);
			}
			return num + this.LoadAllJoystickCalibrationData();
		}

		// Token: 0x06000C52 RID: 3154 RVA: 0x00044A39 File Offset: 0x00042C39
		private int LoadPlayerDataNow(int playerId)
		{
			return this.LoadPlayerDataNow(ReInput.players.GetPlayer(playerId));
		}

		// Token: 0x06000C53 RID: 3155 RVA: 0x00044A4C File Offset: 0x00042C4C
		private int LoadPlayerDataNow(Player player)
		{
			if (player == null)
			{
				return 0;
			}
			int num = 0;
			num += this.LoadInputBehaviors(player.id);
			num += this.LoadControllerMaps(player.id, ControllerType.Keyboard, 0);
			num += this.LoadControllerMaps(player.id, ControllerType.Mouse, 0);
			foreach (Joystick joystick in player.controllers.Joysticks)
			{
				num += this.LoadControllerMaps(player.id, ControllerType.Joystick, joystick.id);
			}
			this.RefreshLayoutManager(player.id);
			return num;
		}

		// Token: 0x06000C54 RID: 3156 RVA: 0x00044AF4 File Offset: 0x00042CF4
		private int LoadAllJoystickCalibrationData()
		{
			int num = 0;
			IList<Joystick> joysticks = ReInput.controllers.Joysticks;
			for (int i = 0; i < joysticks.Count; i++)
			{
				num += this.LoadJoystickCalibrationData(joysticks[i]);
			}
			return num;
		}

		// Token: 0x06000C55 RID: 3157 RVA: 0x00044B30 File Offset: 0x00042D30
		private int LoadJoystickCalibrationData(Joystick joystick)
		{
			if (joystick == null)
			{
				return 0;
			}
			if (!joystick.ImportCalibrationMapFromJsonString(this.GetJoystickCalibrationMapJson(joystick)))
			{
				return 0;
			}
			return 1;
		}

		// Token: 0x06000C56 RID: 3158 RVA: 0x00044B49 File Offset: 0x00042D49
		private int LoadJoystickCalibrationData(int joystickId)
		{
			return this.LoadJoystickCalibrationData(ReInput.controllers.GetJoystick(joystickId));
		}

		// Token: 0x06000C57 RID: 3159 RVA: 0x00044B5C File Offset: 0x00042D5C
		private int LoadJoystickData(int joystickId)
		{
			int num = 0;
			IList<Player> allPlayers = ReInput.players.AllPlayers;
			for (int i = 0; i < allPlayers.Count; i++)
			{
				Player player = allPlayers[i];
				if (player.controllers.ContainsController(ControllerType.Joystick, joystickId))
				{
					num += this.LoadControllerMaps(player.id, ControllerType.Joystick, joystickId);
					this.RefreshLayoutManager(player.id);
				}
			}
			return num + this.LoadJoystickCalibrationData(joystickId);
		}

		// Token: 0x06000C58 RID: 3160 RVA: 0x00044BC6 File Offset: 0x00042DC6
		private int LoadControllerDataNow(int playerId, ControllerType controllerType, int controllerId)
		{
			int num = 0 + this.LoadControllerMaps(playerId, controllerType, controllerId);
			this.RefreshLayoutManager(playerId);
			return num + this.LoadControllerDataNow(controllerType, controllerId);
		}

		// Token: 0x06000C59 RID: 3161 RVA: 0x00044BE4 File Offset: 0x00042DE4
		private int LoadControllerDataNow(ControllerType controllerType, int controllerId)
		{
			int num = 0;
			if (controllerType == ControllerType.Joystick)
			{
				num += this.LoadJoystickCalibrationData(controllerId);
			}
			return num;
		}

		// Token: 0x06000C5A RID: 3162 RVA: 0x00044C04 File Offset: 0x00042E04
		private int LoadControllerMaps(int playerId, ControllerType controllerType, int controllerId)
		{
			int num = 0;
			Player player = ReInput.players.GetPlayer(playerId);
			if (player == null)
			{
				return num;
			}
			Controller controller = ReInput.controllers.GetController(controllerType, controllerId);
			if (controller == null)
			{
				return num;
			}
			IList<InputMapCategory> mapCategories = ReInput.mapping.MapCategories;
			for (int i = 0; i < mapCategories.Count; i++)
			{
				InputMapCategory inputMapCategory = mapCategories[i];
				if (inputMapCategory.userAssignable)
				{
					IList<InputLayout> list = ReInput.mapping.MapLayouts(controller.type);
					for (int j = 0; j < list.Count; j++)
					{
						InputLayout inputLayout = list[j];
						ControllerMap controllerMap = this.LoadControllerMap(player, controller.identifier, inputMapCategory.id, inputLayout.id);
						if (controllerMap != null)
						{
							player.controllers.maps.AddMap(controller, controllerMap);
							num++;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x06000C5B RID: 3163 RVA: 0x00044CDC File Offset: 0x00042EDC
		private ControllerMap LoadControllerMap(Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId)
		{
			if (player == null)
			{
				return null;
			}
			string controllerMapJson = this.GetControllerMapJson(player, controllerIdentifier, categoryId, layoutId);
			if (string.IsNullOrEmpty(controllerMapJson))
			{
				return null;
			}
			ControllerMap controllerMap = ControllerMap.CreateFromJson(controllerIdentifier.controllerType, controllerMapJson);
			if (controllerMap == null)
			{
				return null;
			}
			List<int> controllerMapKnownActionIds = this.GetControllerMapKnownActionIds(player, controllerIdentifier, categoryId, layoutId);
			this.AddDefaultMappingsForNewActions(controllerIdentifier, controllerMap, controllerMapKnownActionIds);
			return controllerMap;
		}

		// Token: 0x06000C5C RID: 3164 RVA: 0x00044D30 File Offset: 0x00042F30
		private int LoadInputBehaviors(int playerId)
		{
			Player player = ReInput.players.GetPlayer(playerId);
			if (player == null)
			{
				return 0;
			}
			int num = 0;
			IList<InputBehavior> inputBehaviors = ReInput.mapping.GetInputBehaviors(player.id);
			for (int i = 0; i < inputBehaviors.Count; i++)
			{
				num += this.LoadInputBehaviorNow(player, inputBehaviors[i]);
			}
			return num;
		}

		// Token: 0x06000C5D RID: 3165 RVA: 0x00044D84 File Offset: 0x00042F84
		private int LoadInputBehaviorNow(int playerId, int behaviorId)
		{
			Player player = ReInput.players.GetPlayer(playerId);
			if (player == null)
			{
				return 0;
			}
			InputBehavior inputBehavior = ReInput.mapping.GetInputBehavior(playerId, behaviorId);
			if (inputBehavior == null)
			{
				return 0;
			}
			return this.LoadInputBehaviorNow(player, inputBehavior);
		}

		// Token: 0x06000C5E RID: 3166 RVA: 0x00044DBC File Offset: 0x00042FBC
		private int LoadInputBehaviorNow(Player player, InputBehavior inputBehavior)
		{
			if (player == null || inputBehavior == null)
			{
				return 0;
			}
			string inputBehaviorJson = this.GetInputBehaviorJson(player, inputBehavior.id);
			if (inputBehaviorJson == null || inputBehaviorJson == string.Empty)
			{
				return 0;
			}
			if (!inputBehavior.ImportJsonString(inputBehaviorJson))
			{
				return 0;
			}
			return 1;
		}

		// Token: 0x06000C5F RID: 3167 RVA: 0x00044E00 File Offset: 0x00043000
		private bool LoadControllerAssignmentsNow()
		{
			try
			{
				UserDataStore_KeyValue.ControllerAssignmentSaveInfo controllerAssignmentSaveInfo = this.LoadControllerAssignmentData();
				if (controllerAssignmentSaveInfo == null)
				{
					return false;
				}
				if (this._loadKeyboardAssignments || this._loadMouseAssignments)
				{
					this.LoadKeyboardAndMouseAssignmentsNow(controllerAssignmentSaveInfo);
				}
				if (this._loadJoystickAssignments)
				{
					this.LoadJoystickAssignmentsNow(controllerAssignmentSaveInfo);
				}
			}
			catch
			{
			}
			return true;
		}

		// Token: 0x06000C60 RID: 3168 RVA: 0x00044E5C File Offset: 0x0004305C
		private bool LoadKeyboardAndMouseAssignmentsNow(UserDataStore_KeyValue.ControllerAssignmentSaveInfo data)
		{
			try
			{
				if (data == null && (data = this.LoadControllerAssignmentData()) == null)
				{
					return false;
				}
				foreach (Player player in ReInput.players.AllPlayers)
				{
					if (data.ContainsPlayer(player.id))
					{
						UserDataStore_KeyValue.ControllerAssignmentSaveInfo.PlayerInfo playerInfo = data.players[data.IndexOfPlayer(player.id)];
						if (this._loadKeyboardAssignments)
						{
							player.controllers.hasKeyboard = playerInfo.hasKeyboard;
						}
						if (this._loadMouseAssignments)
						{
							player.controllers.hasMouse = playerInfo.hasMouse;
						}
					}
				}
			}
			catch
			{
			}
			return true;
		}

		// Token: 0x06000C61 RID: 3169 RVA: 0x00044F24 File Offset: 0x00043124
		private bool LoadJoystickAssignmentsNow(UserDataStore_KeyValue.ControllerAssignmentSaveInfo data)
		{
			try
			{
				if (ReInput.controllers.joystickCount == 0)
				{
					return false;
				}
				if (data == null && (data = this.LoadControllerAssignmentData()) == null)
				{
					return false;
				}
				foreach (Player player in ReInput.players.AllPlayers)
				{
					player.controllers.ClearControllersOfType(ControllerType.Joystick);
				}
				List<UserDataStore_KeyValue.JoystickAssignmentHistoryInfo> list = this._loadJoystickAssignments ? new List<UserDataStore_KeyValue.JoystickAssignmentHistoryInfo>() : null;
				foreach (Player player2 in ReInput.players.AllPlayers)
				{
					if (data.ContainsPlayer(player2.id))
					{
						UserDataStore_KeyValue.ControllerAssignmentSaveInfo.PlayerInfo playerInfo = data.players[data.IndexOfPlayer(player2.id)];
						for (int i = 0; i < playerInfo.joystickCount; i++)
						{
							UserDataStore_KeyValue.ControllerAssignmentSaveInfo.JoystickInfo joystickInfo2 = playerInfo.joysticks[i];
							if (joystickInfo2 != null)
							{
								Joystick joystick = this.FindJoystickPrecise(joystickInfo2);
								if (joystick != null)
								{
									if (list.Find((UserDataStore_KeyValue.JoystickAssignmentHistoryInfo x) => x.joystick == joystick) == null)
									{
										list.Add(new UserDataStore_KeyValue.JoystickAssignmentHistoryInfo(joystick, joystickInfo2.id));
									}
									player2.controllers.AddController(joystick, false);
								}
							}
						}
					}
				}
				if (this._allowImpreciseJoystickAssignmentMatching)
				{
					foreach (Player player3 in ReInput.players.AllPlayers)
					{
						if (data.ContainsPlayer(player3.id))
						{
							UserDataStore_KeyValue.ControllerAssignmentSaveInfo.PlayerInfo playerInfo2 = data.players[data.IndexOfPlayer(player3.id)];
							for (int j = 0; j < playerInfo2.joystickCount; j++)
							{
								UserDataStore_KeyValue.ControllerAssignmentSaveInfo.JoystickInfo joystickInfo = playerInfo2.joysticks[j];
								if (joystickInfo != null)
								{
									Joystick joystick2 = null;
									int num = list.FindIndex((UserDataStore_KeyValue.JoystickAssignmentHistoryInfo x) => x.oldJoystickId == joystickInfo.id);
									if (num >= 0)
									{
										joystick2 = list[num].joystick;
									}
									else
									{
										List<Joystick> list2;
										if (!this.TryFindJoysticksImprecise(joystickInfo, out list2))
										{
											goto IL_298;
										}
										using (List<Joystick>.Enumerator enumerator2 = list2.GetEnumerator())
										{
											while (enumerator2.MoveNext())
											{
												Joystick match = enumerator2.Current;
												if (list.Find((UserDataStore_KeyValue.JoystickAssignmentHistoryInfo x) => x.joystick == match) == null)
												{
													joystick2 = match;
													break;
												}
											}
										}
										if (joystick2 == null)
										{
											goto IL_298;
										}
										list.Add(new UserDataStore_KeyValue.JoystickAssignmentHistoryInfo(joystick2, joystickInfo.id));
									}
									player3.controllers.AddController(joystick2, false);
								}
								IL_298:;
							}
						}
					}
				}
			}
			catch
			{
			}
			if (ReInput.configuration.autoAssignJoysticks)
			{
				ReInput.controllers.AutoAssignJoysticks();
			}
			return true;
		}

		// Token: 0x06000C62 RID: 3170 RVA: 0x00045290 File Offset: 0x00043490
		private UserDataStore_KeyValue.ControllerAssignmentSaveInfo LoadControllerAssignmentData()
		{
			UserDataStore_KeyValue.ControllerAssignmentSaveInfo result;
			try
			{
				string text;
				if (!UserDataStore_KeyValue.TryGetString(this.dataStore, "ControllerAssignments", out text))
				{
					result = null;
				}
				else if (string.IsNullOrEmpty(text))
				{
					result = null;
				}
				else
				{
					UserDataStore_KeyValue.ControllerAssignmentSaveInfo controllerAssignmentSaveInfo = JsonParser.FromJson<UserDataStore_KeyValue.ControllerAssignmentSaveInfo>(text);
					if (controllerAssignmentSaveInfo == null || controllerAssignmentSaveInfo.playerCount == 0)
					{
						result = null;
					}
					else
					{
						result = controllerAssignmentSaveInfo;
					}
				}
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000C63 RID: 3171 RVA: 0x000452F4 File Offset: 0x000434F4
		private IEnumerator LoadJoystickAssignmentsDeferred()
		{
			this._deferredJoystickAssignmentLoadPending = true;
			yield return new WaitForEndOfFrame();
			if (!ReInput.isReady)
			{
				yield break;
			}
			this.LoadJoystickAssignmentsNow(null);
			this.SaveControllerAssignments();
			this._deferredJoystickAssignmentLoadPending = false;
			yield break;
		}

		// Token: 0x06000C64 RID: 3172 RVA: 0x00045304 File Offset: 0x00043504
		private void SaveAll()
		{
			IList<Player> allPlayers = ReInput.players.AllPlayers;
			for (int i = 0; i < allPlayers.Count; i++)
			{
				this.SavePlayerDataNow(allPlayers[i]);
			}
			this.SaveAllJoystickCalibrationData();
			if (this.loadControllerAssignments)
			{
				this.SaveControllerAssignments();
			}
			this.dataStore.Save();
		}

		// Token: 0x06000C65 RID: 3173 RVA: 0x0004535B File Offset: 0x0004355B
		private void SavePlayerDataNow(int playerId)
		{
			this.SavePlayerDataNow(ReInput.players.GetPlayer(playerId));
			this.dataStore.Save();
		}

		// Token: 0x06000C66 RID: 3174 RVA: 0x0004537C File Offset: 0x0004357C
		private void SavePlayerDataNow(Player player)
		{
			if (player == null)
			{
				return;
			}
			PlayerSaveData saveData = player.GetSaveData(true);
			this.SaveInputBehaviors(player, saveData);
			this.SaveControllerMaps(player, saveData);
		}

		// Token: 0x06000C67 RID: 3175 RVA: 0x000453A8 File Offset: 0x000435A8
		private void SaveAllJoystickCalibrationData()
		{
			IList<Joystick> joysticks = ReInput.controllers.Joysticks;
			for (int i = 0; i < joysticks.Count; i++)
			{
				this.SaveJoystickCalibrationData(joysticks[i]);
			}
		}

		// Token: 0x06000C68 RID: 3176 RVA: 0x000453DE File Offset: 0x000435DE
		private void SaveJoystickCalibrationData(int joystickId)
		{
			this.SaveJoystickCalibrationData(ReInput.controllers.GetJoystick(joystickId));
		}

		// Token: 0x06000C69 RID: 3177 RVA: 0x000453F4 File Offset: 0x000435F4
		private void SaveJoystickCalibrationData(Joystick joystick)
		{
			if (joystick == null)
			{
				return;
			}
			JoystickCalibrationMapSaveData calibrationMapSaveData = joystick.GetCalibrationMapSaveData();
			string joystickCalibrationMapKey = this.GetJoystickCalibrationMapKey(joystick);
			this.dataStore.SetValue(joystickCalibrationMapKey, calibrationMapSaveData.map.ToJsonString());
		}

		// Token: 0x06000C6A RID: 3178 RVA: 0x0004542C File Offset: 0x0004362C
		private void SaveJoystickData(int joystickId)
		{
			IList<Player> allPlayers = ReInput.players.AllPlayers;
			for (int i = 0; i < allPlayers.Count; i++)
			{
				Player player = allPlayers[i];
				if (player.controllers.ContainsController(ControllerType.Joystick, joystickId))
				{
					this.SaveControllerMaps(player.id, ControllerType.Joystick, joystickId);
				}
			}
			this.SaveJoystickCalibrationData(joystickId);
		}

		// Token: 0x06000C6B RID: 3179 RVA: 0x00045481 File Offset: 0x00043681
		private void SaveControllerDataNow(int playerId, ControllerType controllerType, int controllerId)
		{
			this.SaveControllerMaps(playerId, controllerType, controllerId);
			this.SaveControllerData(controllerType, controllerId);
		}

		// Token: 0x06000C6C RID: 3180 RVA: 0x00045494 File Offset: 0x00043694
		private void SaveControllerDataNow(ControllerType controllerType, int controllerId)
		{
			if (controllerType == ControllerType.Joystick)
			{
				this.SaveJoystickCalibrationData(controllerId);
			}
		}

		// Token: 0x06000C6D RID: 3181 RVA: 0x000454A4 File Offset: 0x000436A4
		private void SaveControllerMaps(Player player, PlayerSaveData playerSaveData)
		{
			foreach (ControllerMapSaveData controllerMapSaveData in playerSaveData.AllControllerMapSaveData)
			{
				this.SaveControllerMap(player, controllerMapSaveData.map);
			}
		}

		// Token: 0x06000C6E RID: 3182 RVA: 0x000454F8 File Offset: 0x000436F8
		private void SaveControllerMaps(int playerId, ControllerType controllerType, int controllerId)
		{
			Player player = ReInput.players.GetPlayer(playerId);
			if (player == null)
			{
				return;
			}
			if (!player.controllers.ContainsController(controllerType, controllerId))
			{
				return;
			}
			ControllerMapSaveData[] mapSaveData = player.controllers.maps.GetMapSaveData(controllerType, controllerId, true);
			if (mapSaveData == null)
			{
				return;
			}
			for (int i = 0; i < mapSaveData.Length; i++)
			{
				this.SaveControllerMap(player, mapSaveData[i].map);
			}
		}

		// Token: 0x06000C6F RID: 3183 RVA: 0x0004555C File Offset: 0x0004375C
		private void SaveControllerMap(Player player, ControllerMap controllerMap)
		{
			string key = this.GetControllerMapKey(player, controllerMap.controller.identifier, controllerMap.categoryId, controllerMap.layoutId, 0);
			this.dataStore.SetValue(key, controllerMap.ToJsonString());
			key = this.GetControllerMapKnownActionIdsKey(player, controllerMap.controller.identifier, controllerMap.categoryId, controllerMap.layoutId, 0);
			this.dataStore.SetValue(key, this.allActionIdsString);
		}

		// Token: 0x06000C70 RID: 3184 RVA: 0x000455D0 File Offset: 0x000437D0
		private void SaveInputBehaviors(Player player, PlayerSaveData playerSaveData)
		{
			if (player == null)
			{
				return;
			}
			InputBehavior[] inputBehaviors = playerSaveData.inputBehaviors;
			for (int i = 0; i < inputBehaviors.Length; i++)
			{
				this.SaveInputBehaviorNow(player, inputBehaviors[i]);
			}
		}

		// Token: 0x06000C71 RID: 3185 RVA: 0x00045604 File Offset: 0x00043804
		private void SaveInputBehaviorNow(int playerId, int behaviorId)
		{
			Player player = ReInput.players.GetPlayer(playerId);
			if (player == null)
			{
				return;
			}
			InputBehavior inputBehavior = ReInput.mapping.GetInputBehavior(playerId, behaviorId);
			if (inputBehavior == null)
			{
				return;
			}
			this.SaveInputBehaviorNow(player, inputBehavior);
			this.dataStore.Save();
		}

		// Token: 0x06000C72 RID: 3186 RVA: 0x00045648 File Offset: 0x00043848
		private void SaveInputBehaviorNow(Player player, InputBehavior inputBehavior)
		{
			if (player == null || inputBehavior == null)
			{
				return;
			}
			string inputBehaviorKey = this.GetInputBehaviorKey(player, inputBehavior.id);
			this.dataStore.SetValue(inputBehaviorKey, inputBehavior.ToJsonString());
		}

		// Token: 0x06000C73 RID: 3187 RVA: 0x00045680 File Offset: 0x00043880
		private bool SaveControllerAssignments()
		{
			try
			{
				UserDataStore_KeyValue.ControllerAssignmentSaveInfo controllerAssignmentSaveInfo = new UserDataStore_KeyValue.ControllerAssignmentSaveInfo(ReInput.players.allPlayerCount);
				for (int i = 0; i < ReInput.players.allPlayerCount; i++)
				{
					Player player = ReInput.players.AllPlayers[i];
					UserDataStore_KeyValue.ControllerAssignmentSaveInfo.PlayerInfo playerInfo = new UserDataStore_KeyValue.ControllerAssignmentSaveInfo.PlayerInfo();
					controllerAssignmentSaveInfo.players[i] = playerInfo;
					playerInfo.id = player.id;
					playerInfo.hasKeyboard = player.controllers.hasKeyboard;
					playerInfo.hasMouse = player.controllers.hasMouse;
					UserDataStore_KeyValue.ControllerAssignmentSaveInfo.JoystickInfo[] array = new UserDataStore_KeyValue.ControllerAssignmentSaveInfo.JoystickInfo[player.controllers.joystickCount];
					playerInfo.joysticks = array;
					for (int j = 0; j < player.controllers.joystickCount; j++)
					{
						Joystick joystick = player.controllers.Joysticks[j];
						array[j] = new UserDataStore_KeyValue.ControllerAssignmentSaveInfo.JoystickInfo
						{
							instanceGuid = joystick.deviceInstanceGuid,
							id = joystick.id,
							hardwareIdentifier = joystick.hardwareIdentifier
						};
					}
				}
				this.dataStore.SetValue("ControllerAssignments", JsonWriter.ToJson(controllerAssignmentSaveInfo));
				this.dataStore.Save();
			}
			catch
			{
			}
			return true;
		}

		// Token: 0x06000C74 RID: 3188 RVA: 0x000457CC File Offset: 0x000439CC
		private static void AppendBaseKey(StringBuilder sb, Player player)
		{
			sb.Append("playerId=");
			sb.Append(player.id);
		}

		// Token: 0x06000C75 RID: 3189 RVA: 0x000457E8 File Offset: 0x000439E8
		private string GetControllerMapKey(Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId, int ppKeyVersion)
		{
			this._sb.Length = 0;
			UserDataStore_KeyValue.AppendBaseKey(this._sb, player);
			this._sb.Append("|dataType=ControllerMap");
			UserDataStore_KeyValue.AppendControllerMapKeyCommonSuffix(this._sb, player, controllerIdentifier, categoryId, layoutId, ppKeyVersion);
			return this._sb.ToString();
		}

		// Token: 0x06000C76 RID: 3190 RVA: 0x0004583C File Offset: 0x00043A3C
		private string GetControllerMapKnownActionIdsKey(Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId, int ppKeyVersion)
		{
			this._sb.Length = 0;
			UserDataStore_KeyValue.AppendBaseKey(this._sb, player);
			this._sb.Append("|dataType=ControllerMap_KnownActionIds");
			UserDataStore_KeyValue.AppendControllerMapKeyCommonSuffix(this._sb, player, controllerIdentifier, categoryId, layoutId, ppKeyVersion);
			return this._sb.ToString();
		}

		// Token: 0x06000C77 RID: 3191 RVA: 0x00045890 File Offset: 0x00043A90
		private static void AppendControllerMapKeyCommonSuffix(StringBuilder sb, Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId, int keyVersion)
		{
			sb.Append("|kv=");
			sb.Append(keyVersion);
			sb.Append("|controllerMapType=");
			sb.Append((int)controllerIdentifier.controllerType);
			sb.Append("|categoryId=");
			sb.Append(categoryId);
			sb.Append("|");
			sb.Append("layoutId=");
			sb.Append(layoutId);
			sb.Append("|hardwareGuid=");
			sb.Append(controllerIdentifier.hardwareTypeGuid);
			if (controllerIdentifier.hardwareTypeGuid == Guid.Empty)
			{
				sb.Append("|hardwareIdentifier=");
				sb.Append(controllerIdentifier.hardwareIdentifier);
			}
			if (controllerIdentifier.controllerType == ControllerType.Joystick)
			{
				sb.Append("|duplicate=");
				sb.Append(UserDataStore_KeyValue.GetDuplicateIndex(player, controllerIdentifier).ToString());
			}
		}

		// Token: 0x06000C78 RID: 3192 RVA: 0x0004597C File Offset: 0x00043B7C
		private string GetJoystickCalibrationMapKey(Joystick joystick)
		{
			this._sb.Length = 0;
			this._sb.Append("dataType=CalibrationMap");
			this._sb.Append("|controllerType=");
			this._sb.Append((int)joystick.type);
			this._sb.Append("|hardwareIdentifier=");
			this._sb.Append(joystick.hardwareIdentifier);
			this._sb.Append("|hardwareGuid=");
			this._sb.Append(joystick.hardwareTypeGuid.ToString());
			return this._sb.ToString();
		}

		// Token: 0x06000C79 RID: 3193 RVA: 0x00045A28 File Offset: 0x00043C28
		private string GetInputBehaviorKey(Player player, int inputBehaviorId)
		{
			this._sb.Length = 0;
			UserDataStore_KeyValue.AppendBaseKey(this._sb, player);
			this._sb.Append("|dataType=InputBehavior");
			this._sb.Append("|id=");
			this._sb.Append(inputBehaviorId);
			return this._sb.ToString();
		}

		// Token: 0x06000C7A RID: 3194 RVA: 0x00045A88 File Offset: 0x00043C88
		private string GetControllerMapJson(Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId)
		{
			for (int i = 0; i >= 0; i--)
			{
				string controllerMapKey = this.GetControllerMapKey(player, controllerIdentifier, categoryId, layoutId, i);
				string text;
				if (UserDataStore_KeyValue.TryGetString(this.dataStore, controllerMapKey, out text) && !string.IsNullOrEmpty(text))
				{
					return text;
				}
			}
			return null;
		}

		// Token: 0x06000C7B RID: 3195 RVA: 0x00045ACC File Offset: 0x00043CCC
		private List<int> GetControllerMapKnownActionIds(Player player, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId)
		{
			List<int> list = new List<int>();
			string text = null;
			bool flag = false;
			for (int i = 0; i >= 0; i--)
			{
				string controllerMapKnownActionIdsKey = this.GetControllerMapKnownActionIdsKey(player, controllerIdentifier, categoryId, layoutId, i);
				if (UserDataStore_KeyValue.TryGetString(this.dataStore, controllerMapKnownActionIdsKey, out text))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return list;
			}
			if (string.IsNullOrEmpty(text))
			{
				return list;
			}
			string[] array = text.Split(',', StringSplitOptions.None);
			for (int j = 0; j < array.Length; j++)
			{
				int item;
				if (!string.IsNullOrEmpty(array[j]) && int.TryParse(array[j], out item))
				{
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x06000C7C RID: 3196 RVA: 0x00045B68 File Offset: 0x00043D68
		private string GetJoystickCalibrationMapJson(Joystick joystick)
		{
			string joystickCalibrationMapKey = this.GetJoystickCalibrationMapKey(joystick);
			string result;
			UserDataStore_KeyValue.TryGetString(this.dataStore, joystickCalibrationMapKey, out result);
			return result;
		}

		// Token: 0x06000C7D RID: 3197 RVA: 0x00045B90 File Offset: 0x00043D90
		private string GetInputBehaviorJson(Player player, int id)
		{
			string inputBehaviorKey = this.GetInputBehaviorKey(player, id);
			string result;
			UserDataStore_KeyValue.TryGetString(this.dataStore, inputBehaviorKey, out result);
			return result;
		}

		// Token: 0x06000C7E RID: 3198 RVA: 0x00045BB8 File Offset: 0x00043DB8
		private void AddDefaultMappingsForNewActions(ControllerIdentifier controllerIdentifier, ControllerMap controllerMap, List<int> knownActionIds)
		{
			if (controllerMap == null || knownActionIds == null)
			{
				return;
			}
			if (knownActionIds == null || knownActionIds.Count == 0)
			{
				return;
			}
			ControllerMap controllerMapInstance = ReInput.mapping.GetControllerMapInstance(controllerIdentifier, controllerMap.categoryId, controllerMap.layoutId);
			if (controllerMapInstance == null)
			{
				return;
			}
			List<int> list = new List<int>();
			foreach (int item in this.allActionIds)
			{
				if (!knownActionIds.Contains(item))
				{
					list.Add(item);
				}
			}
			if (list.Count == 0)
			{
				return;
			}
			foreach (ActionElementMap actionElementMap in controllerMapInstance.AllMaps)
			{
				if (list.Contains(actionElementMap.actionId) && !controllerMap.DoesElementAssignmentConflict(actionElementMap))
				{
					ElementAssignment elementAssignment = new ElementAssignment(controllerMap.controllerType, actionElementMap.elementType, actionElementMap.elementIdentifierId, actionElementMap.axisRange, actionElementMap.keyCode, actionElementMap.modifierKeyFlags, actionElementMap.actionId, actionElementMap.axisContribution, actionElementMap.invert);
					controllerMap.CreateElementMap(elementAssignment);
				}
			}
		}

		// Token: 0x06000C7F RID: 3199 RVA: 0x00045CF4 File Offset: 0x00043EF4
		private Joystick FindJoystickPrecise(UserDataStore_KeyValue.ControllerAssignmentSaveInfo.JoystickInfo joystickInfo)
		{
			if (joystickInfo == null)
			{
				return null;
			}
			if (joystickInfo.instanceGuid == Guid.Empty)
			{
				return null;
			}
			IList<Joystick> joysticks = ReInput.controllers.Joysticks;
			for (int i = 0; i < joysticks.Count; i++)
			{
				if (joysticks[i].deviceInstanceGuid == joystickInfo.instanceGuid)
				{
					return joysticks[i];
				}
			}
			return null;
		}

		// Token: 0x06000C80 RID: 3200 RVA: 0x00045D58 File Offset: 0x00043F58
		private bool TryFindJoysticksImprecise(UserDataStore_KeyValue.ControllerAssignmentSaveInfo.JoystickInfo joystickInfo, out List<Joystick> matches)
		{
			matches = null;
			if (joystickInfo == null)
			{
				return false;
			}
			if (string.IsNullOrEmpty(joystickInfo.hardwareIdentifier))
			{
				return false;
			}
			IList<Joystick> joysticks = ReInput.controllers.Joysticks;
			for (int i = 0; i < joysticks.Count; i++)
			{
				if (string.Equals(joysticks[i].hardwareIdentifier, joystickInfo.hardwareIdentifier, StringComparison.OrdinalIgnoreCase))
				{
					if (matches == null)
					{
						matches = new List<Joystick>();
					}
					matches.Add(joysticks[i]);
				}
			}
			return matches != null;
		}

		// Token: 0x06000C81 RID: 3201 RVA: 0x00045DD0 File Offset: 0x00043FD0
		private void RefreshLayoutManager(int playerId)
		{
			Player player = ReInput.players.GetPlayer(playerId);
			if (player == null)
			{
				return;
			}
			player.controllers.maps.layoutManager.Apply();
		}

		// Token: 0x06000C82 RID: 3202 RVA: 0x00045E04 File Offset: 0x00044004
		private static int GetDuplicateIndex(Player player, ControllerIdentifier controllerIdentifier)
		{
			Controller controller = ReInput.controllers.GetController(controllerIdentifier);
			if (controller == null)
			{
				return 0;
			}
			int num = 0;
			foreach (Controller controller2 in player.controllers.Controllers)
			{
				if (controller2.type == controller.type)
				{
					bool flag = false;
					if (controller.type == ControllerType.Joystick)
					{
						if ((controller2 as Joystick).hardwareTypeGuid != controller.hardwareTypeGuid)
						{
							continue;
						}
						if (controller.hardwareTypeGuid != Guid.Empty)
						{
							flag = true;
						}
					}
					if (flag || !(controller2.hardwareIdentifier != controller.hardwareIdentifier))
					{
						if (controller2 == controller)
						{
							return num;
						}
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x06000C83 RID: 3203 RVA: 0x00045ED4 File Offset: 0x000440D4
		private static bool TryGetString(UserDataStore_KeyValue.IDataStore store, string key, out string result)
		{
			if (store == null || string.IsNullOrEmpty(key))
			{
				result = null;
				return false;
			}
			object obj;
			if (!store.TryGetValue(key, out obj))
			{
				result = null;
				return false;
			}
			result = (obj as string);
			return obj is string;
		}

		// Token: 0x04001223 RID: 4643
		private static readonly string thisScriptName = typeof(UserDataStore_KeyValue).Name;

		// Token: 0x04001224 RID: 4644
		private const string logPrefix = "Rewired: ";

		// Token: 0x04001225 RID: 4645
		private const string key_controllerAssignments = "ControllerAssignments";

		// Token: 0x04001226 RID: 4646
		private const int controllerMapKeyVersion = 0;

		// Token: 0x04001227 RID: 4647
		[Tooltip("Should this script be used? If disabled, nothing will be saved or loaded.")]
		[SerializeField]
		private bool _isEnabled = true;

		// Token: 0x04001228 RID: 4648
		[Tooltip("Should saved data be loaded on start?")]
		[SerializeField]
		private bool _loadDataOnStart = true;

		// Token: 0x04001229 RID: 4649
		[Tooltip("Should Player Joystick assignments be saved and loaded? This is not totally reliable for all Joysticks on all platforms. Some platforms/input sources do not provide enough information to reliably save assignments from session to session and reboot to reboot.")]
		[SerializeField]
		private bool _loadJoystickAssignments = true;

		// Token: 0x0400122A RID: 4650
		[Tooltip("Should Player Keyboard assignments be saved and loaded?")]
		[SerializeField]
		private bool _loadKeyboardAssignments = true;

		// Token: 0x0400122B RID: 4651
		[Tooltip("Should Player Mouse assignments be saved and loaded?")]
		[SerializeField]
		private bool _loadMouseAssignments = true;

		// Token: 0x0400122C RID: 4652
		[NonSerialized]
		private bool _allowImpreciseJoystickAssignmentMatching = true;

		// Token: 0x0400122D RID: 4653
		[NonSerialized]
		private bool _deferredJoystickAssignmentLoadPending;

		// Token: 0x0400122E RID: 4654
		[NonSerialized]
		private bool _wasJoystickEverDetected;

		// Token: 0x0400122F RID: 4655
		[NonSerialized]
		private List<int> __allActionIds;

		// Token: 0x04001230 RID: 4656
		[NonSerialized]
		private string __allActionIdsString;

		// Token: 0x04001231 RID: 4657
		[NonSerialized]
		private readonly StringBuilder _sb = new StringBuilder();

		// Token: 0x0200027D RID: 637
		private class ControllerAssignmentSaveInfo
		{
			// Token: 0x17000292 RID: 658
			// (get) Token: 0x06000C86 RID: 3206 RVA: 0x00045F65 File Offset: 0x00044165
			public int playerCount
			{
				get
				{
					if (this.players == null)
					{
						return 0;
					}
					return this.players.Length;
				}
			}

			// Token: 0x06000C87 RID: 3207 RVA: 0x00002392 File Offset: 0x00000592
			public ControllerAssignmentSaveInfo()
			{
			}

			// Token: 0x06000C88 RID: 3208 RVA: 0x00045F7C File Offset: 0x0004417C
			public ControllerAssignmentSaveInfo(int playerCount)
			{
				this.players = new UserDataStore_KeyValue.ControllerAssignmentSaveInfo.PlayerInfo[playerCount];
				for (int i = 0; i < playerCount; i++)
				{
					this.players[i] = new UserDataStore_KeyValue.ControllerAssignmentSaveInfo.PlayerInfo();
				}
			}

			// Token: 0x06000C89 RID: 3209 RVA: 0x00045FB4 File Offset: 0x000441B4
			public int IndexOfPlayer(int playerId)
			{
				for (int i = 0; i < this.playerCount; i++)
				{
					if (this.players[i] != null && this.players[i].id == playerId)
					{
						return i;
					}
				}
				return -1;
			}

			// Token: 0x06000C8A RID: 3210 RVA: 0x00045FEF File Offset: 0x000441EF
			public bool ContainsPlayer(int playerId)
			{
				return this.IndexOfPlayer(playerId) >= 0;
			}

			// Token: 0x04001232 RID: 4658
			public UserDataStore_KeyValue.ControllerAssignmentSaveInfo.PlayerInfo[] players;

			// Token: 0x0200027E RID: 638
			public class PlayerInfo
			{
				// Token: 0x17000293 RID: 659
				// (get) Token: 0x06000C8B RID: 3211 RVA: 0x00045FFE File Offset: 0x000441FE
				public int joystickCount
				{
					get
					{
						if (this.joysticks == null)
						{
							return 0;
						}
						return this.joysticks.Length;
					}
				}

				// Token: 0x06000C8C RID: 3212 RVA: 0x00046014 File Offset: 0x00044214
				public int IndexOfJoystick(int joystickId)
				{
					for (int i = 0; i < this.joystickCount; i++)
					{
						if (this.joysticks[i] != null && this.joysticks[i].id == joystickId)
						{
							return i;
						}
					}
					return -1;
				}

				// Token: 0x06000C8D RID: 3213 RVA: 0x0004604F File Offset: 0x0004424F
				public bool ContainsJoystick(int joystickId)
				{
					return this.IndexOfJoystick(joystickId) >= 0;
				}

				// Token: 0x04001233 RID: 4659
				public int id;

				// Token: 0x04001234 RID: 4660
				public bool hasKeyboard;

				// Token: 0x04001235 RID: 4661
				public bool hasMouse;

				// Token: 0x04001236 RID: 4662
				public UserDataStore_KeyValue.ControllerAssignmentSaveInfo.JoystickInfo[] joysticks;
			}

			// Token: 0x0200027F RID: 639
			public class JoystickInfo
			{
				// Token: 0x04001237 RID: 4663
				public Guid instanceGuid;

				// Token: 0x04001238 RID: 4664
				public string hardwareIdentifier;

				// Token: 0x04001239 RID: 4665
				public int id;
			}
		}

		// Token: 0x02000280 RID: 640
		private class JoystickAssignmentHistoryInfo
		{
			// Token: 0x06000C90 RID: 3216 RVA: 0x0004605E File Offset: 0x0004425E
			public JoystickAssignmentHistoryInfo(Joystick joystick, int oldJoystickId)
			{
				if (joystick == null)
				{
					throw new ArgumentNullException("joystick");
				}
				this.joystick = joystick;
				this.oldJoystickId = oldJoystickId;
			}

			// Token: 0x0400123A RID: 4666
			public readonly Joystick joystick;

			// Token: 0x0400123B RID: 4667
			public readonly int oldJoystickId;
		}

		// Token: 0x02000281 RID: 641
		protected interface IDataStore
		{
			// Token: 0x06000C91 RID: 3217
			bool Save();

			// Token: 0x06000C92 RID: 3218
			bool Load();

			// Token: 0x06000C93 RID: 3219
			bool Clear();

			// Token: 0x06000C94 RID: 3220
			bool TryGetValue(string key, out object result);

			// Token: 0x06000C95 RID: 3221
			bool SetValue(string key, object value);
		}
	}
}
