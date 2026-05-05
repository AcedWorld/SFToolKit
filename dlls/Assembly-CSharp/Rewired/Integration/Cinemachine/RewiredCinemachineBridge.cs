using System;
using System.Collections.Generic;
using Cinemachine;
using Rewired.Utils.Attributes;
using UnityEngine;

namespace Rewired.Integration.Cinemachine
{
	// Token: 0x0200029A RID: 666
	[ExecuteInEditMode]
	public sealed class RewiredCinemachineBridge : MonoBehaviour
	{
		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x06000DBE RID: 3518 RVA: 0x0004A7D8 File Offset: 0x000489D8
		// (set) Token: 0x06000DBF RID: 3519 RVA: 0x0004A7E0 File Offset: 0x000489E0
		public InputManager_Base rewiredInputManager
		{
			get
			{
				return this._rewiredInputManager;
			}
			set
			{
				this._rewiredInputManager = value;
			}
		}

		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x06000DC0 RID: 3520 RVA: 0x0004A7E9 File Offset: 0x000489E9
		// (set) Token: 0x06000DC1 RID: 3521 RVA: 0x0004A7F1 File Offset: 0x000489F1
		public float absoluteAxisSensitivity
		{
			get
			{
				return this._absoluteAxisSensitivity;
			}
			set
			{
				if (value < 0f)
				{
					value = 0f;
				}
				this._absoluteAxisSensitivity = value;
			}
		}

		// Token: 0x170002DA RID: 730
		// (get) Token: 0x06000DC2 RID: 3522 RVA: 0x0004A809 File Offset: 0x00048A09
		// (set) Token: 0x06000DC3 RID: 3523 RVA: 0x0004A811 File Offset: 0x00048A11
		public bool scaleAbsoluteAxesToScreen
		{
			get
			{
				return this._scaleAbsoluteAxesToScreen;
			}
			set
			{
				this._scaleAbsoluteAxesToScreen = value;
			}
		}

		// Token: 0x170002DB RID: 731
		// (get) Token: 0x06000DC4 RID: 3524 RVA: 0x0004A81A File Offset: 0x00048A1A
		// (set) Token: 0x06000DC5 RID: 3525 RVA: 0x0004A822 File Offset: 0x00048A22
		public bool runInEditMode
		{
			get
			{
				return this._runInEditMode;
			}
			set
			{
				if (this._runInEditMode == value)
				{
					return;
				}
				this._runInEditMode = value;
				if (!Application.isPlaying)
				{
					if (value)
					{
						this.Initialize();
						return;
					}
					this.Deinitialize();
				}
			}
		}

		// Token: 0x06000DC6 RID: 3526 RVA: 0x0004A84C File Offset: 0x00048A4C
		private void OnEnable()
		{
			if (!Application.isPlaying && !this._runInEditMode)
			{
				return;
			}
			this.Initialize();
		}

		// Token: 0x06000DC7 RID: 3527 RVA: 0x0004A864 File Offset: 0x00048A64
		private void OnDisable()
		{
			this.Deinitialize();
		}

		// Token: 0x06000DC8 RID: 3528 RVA: 0x0004A86C File Offset: 0x00048A6C
		private void Initialize()
		{
			this.Deinitialize();
			if (!ReInput.isReady)
			{
				Debug.LogError("You must have an enabled Rewired Input Manager in the scene to use the Cinemachine bridge.");
				return;
			}
			if (RewiredCinemachineBridge.s_instance != null)
			{
				Debug.LogError("You cannot have multiple Rewired Cinemachine Bridges enabled in the scene.");
				return;
			}
			RewiredCinemachineBridge.s_instance = this;
			if (this._rewiredInputManager == null)
			{
				this._rewiredInputManager = base.GetComponent<InputManager_Base>();
			}
			foreach (RewiredCinemachineBridge.PlayerMapping playerMapping in this._playerMappings)
			{
				if (ReInput.players.GetPlayer(playerMapping._playerId) == null)
				{
					Debug.LogError("No Player exists for id " + playerMapping._playerId.ToString() + ".");
				}
				else
				{
					foreach (RewiredCinemachineBridge.ActionMapping actionMapping in playerMapping._actionMappings)
					{
						if (!string.IsNullOrEmpty(actionMapping._cinemachineAxis))
						{
							InputAction action;
							if (this._rewiredInputManager != null)
							{
								if (actionMapping._rewiredActionId < 0)
								{
									continue;
								}
								action = ReInput.mapping.GetAction(actionMapping._rewiredActionId);
							}
							else
							{
								if (string.IsNullOrEmpty(actionMapping._rewiredActionName))
								{
									continue;
								}
								action = ReInput.mapping.GetAction(actionMapping._rewiredActionName);
							}
							if (action == null)
							{
								Debug.LogWarning("The Action " + ((this._rewiredInputManager != null) ? ("Id " + actionMapping._rewiredActionId.ToString()) : ("\"" + actionMapping._rewiredActionName + "\"")) + " does not exist in the Rewired Input Manager.");
							}
							else if (this._mappings.ContainsKey(actionMapping._cinemachineAxis))
							{
								Debug.LogError("Duplicate Unity Axis found \"" + actionMapping._cinemachineAxis + "\". This is not allowed. All Unity Axes must be unique.");
							}
							else
							{
								this._mappings.Add(actionMapping._cinemachineAxis, new RewiredCinemachineBridge.PlayerActionMapping
								{
									playerId = playerMapping._playerId,
									actionId = action.id
								});
							}
						}
					}
				}
			}
			this._origAxisInputDelegate = CinemachineCore.GetInputAxis;
			CinemachineCore.GetInputAxis = RewiredCinemachineBridge.s_axisInputDelegate;
			this._initialized = true;
		}

		// Token: 0x06000DC9 RID: 3529 RVA: 0x0004AACC File Offset: 0x00048CCC
		private void Deinitialize()
		{
			if (RewiredCinemachineBridge.s_instance == this)
			{
				RewiredCinemachineBridge.s_instance = null;
			}
			if (this._mappings != null)
			{
				this._mappings.Clear();
			}
			if (CinemachineCore.GetInputAxis == RewiredCinemachineBridge.s_axisInputDelegate)
			{
				CinemachineCore.GetInputAxis = this._origAxisInputDelegate;
			}
			this._initialized = false;
		}

		// Token: 0x06000DCA RID: 3530 RVA: 0x0004AB24 File Offset: 0x00048D24
		private static float GetAxis(string name)
		{
			if (!ReInput.isReady || RewiredCinemachineBridge.s_instance == null || !RewiredCinemachineBridge.s_instance._initialized)
			{
				return 0f;
			}
			RewiredCinemachineBridge.PlayerActionMapping playerActionMapping;
			if (!RewiredCinemachineBridge.s_instance._mappings.TryGetValue(name, out playerActionMapping))
			{
				return 0f;
			}
			Player player = ReInput.players.GetPlayer(playerActionMapping.playerId);
			if (player == null)
			{
				return 0f;
			}
			float num = player.GetAxis(playerActionMapping.actionId);
			if (num != 0f && player.GetAxisCoordinateMode(playerActionMapping.actionId) == AxisCoordinateMode.Absolute)
			{
				num *= RewiredCinemachineBridge.s_instance._absoluteAxisSensitivity * Time.unscaledDeltaTime;
				if (RewiredCinemachineBridge.s_instance._scaleAbsoluteAxesToScreen)
				{
					num *= (float)Screen.currentResolution.width / 1920f;
				}
			}
			return num;
		}

		// Token: 0x040012AB RID: 4779
		private const float defaultabsoluteAxisSensitivity = 30f;

		// Token: 0x040012AC RID: 4780
		[Tooltip("(Optional) Link the Rewired Input Manager here for easier access to Action ids, etc.")]
		[SerializeField]
		private InputManager_Base _rewiredInputManager;

		// Token: 0x040012AD RID: 4781
		[Tooltip("The absolute sensitivity multipler. This is only applied to absolute axis sources (joystick axes, keyboard keys, etc.).")]
		[SerializeField]
		[FieldRange(0f, 3.4028235E+38f)]
		private float _absoluteAxisSensitivity = 30f;

		// Token: 0x040012AE RID: 4782
		[Tooltip("If enabled, input values from absolute axis sources will be scaled based on the screen resolution. This makes joystick axes behave more consistently with mouse axes at different screen resolutions.")]
		[SerializeField]
		private bool _scaleAbsoluteAxesToScreen;

		// Token: 0x040012AF RID: 4783
		[Tooltip("If enabled, the Cinemachine Bridge runs in edit mode. The Rewired Input Manager must also be set to run in Edit Mode for this to have any effect.")]
		[SerializeField]
		private bool _runInEditMode;

		// Token: 0x040012B0 RID: 4784
		[Tooltip("Cinemachine to Rewired Player Action mappings. Use this to map Cinemachine input Axes to Rewired Actions on specific Players.")]
		[SerializeField]
		private List<RewiredCinemachineBridge.PlayerMapping> _playerMappings = new List<RewiredCinemachineBridge.PlayerMapping>
		{
			new RewiredCinemachineBridge.PlayerMapping
			{
				_playerId = 0,
				_actionMappings = new List<RewiredCinemachineBridge.ActionMapping>
				{
					new RewiredCinemachineBridge.ActionMapping
					{
						_cinemachineAxis = "Mouse X",
						_rewiredActionName = "Mouse X",
						_rewiredActionId = -1
					},
					new RewiredCinemachineBridge.ActionMapping
					{
						_cinemachineAxis = "Mouse Y",
						_rewiredActionName = "Mouse Y",
						_rewiredActionId = -1
					}
				}
			}
		};

		// Token: 0x040012B1 RID: 4785
		[NonSerialized]
		private readonly Dictionary<string, RewiredCinemachineBridge.PlayerActionMapping> _mappings = new Dictionary<string, RewiredCinemachineBridge.PlayerActionMapping>();

		// Token: 0x040012B2 RID: 4786
		[NonSerialized]
		private CinemachineCore.AxisInputDelegate _origAxisInputDelegate;

		// Token: 0x040012B3 RID: 4787
		[NonSerialized]
		private bool _initialized;

		// Token: 0x040012B4 RID: 4788
		private static RewiredCinemachineBridge s_instance;

		// Token: 0x040012B5 RID: 4789
		private static readonly CinemachineCore.AxisInputDelegate s_axisInputDelegate = new CinemachineCore.AxisInputDelegate(RewiredCinemachineBridge.GetAxis);

		// Token: 0x0200029B RID: 667
		[Serializable]
		private class PlayerMapping
		{
			// Token: 0x040012B6 RID: 4790
			[SerializeField]
			public int _playerId;

			// Token: 0x040012B7 RID: 4791
			[SerializeField]
			public List<RewiredCinemachineBridge.ActionMapping> _actionMappings;
		}

		// Token: 0x0200029C RID: 668
		[Serializable]
		private class ActionMapping
		{
			// Token: 0x040012B8 RID: 4792
			[SerializeField]
			public string _cinemachineAxis;

			// Token: 0x040012B9 RID: 4793
			[SerializeField]
			public string _rewiredActionName;

			// Token: 0x040012BA RID: 4794
			[SerializeField]
			public int _rewiredActionId = -1;
		}

		// Token: 0x0200029D RID: 669
		private class PlayerActionMapping
		{
			// Token: 0x040012BB RID: 4795
			public int playerId;

			// Token: 0x040012BC RID: 4796
			public int actionId;
		}
	}
}
