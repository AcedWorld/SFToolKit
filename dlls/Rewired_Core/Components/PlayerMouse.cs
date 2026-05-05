using System;
using System.Collections.Generic;
using Rewired.UI;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;
using UnityEngine.Events;

namespace Rewired.Components
{
	// Token: 0x020003D7 RID: 983
	[AddComponentMenu("Rewired/Player Controllers/Player Mouse")]
	[Serializable]
	public sealed class PlayerMouse : PlayerController, IPlayerMouse, IPlayerController, IMouseInputSource
	{
		// Token: 0x17000934 RID: 2356
		// (get) Token: 0x0600272B RID: 10027 RVA: 0x0001D350 File Offset: 0x0001B550
		private PlayerMouse UJPVMgwbGBJvyplNKHGrhFAlOsogA
		{
			get
			{
				return base.source as PlayerMouse;
			}
		}

		// Token: 0x17000935 RID: 2357
		// (get) Token: 0x0600272C RID: 10028 RVA: 0x0001D35D File Offset: 0x0001B55D
		// (set) Token: 0x0600272D RID: 10029 RVA: 0x0001D379 File Offset: 0x0001B579
		public bool defaultToCenter
		{
			get
			{
				if (!base.initialized)
				{
					return this._defaultToCenter;
				}
				return this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.defaultToCenter;
			}
			set
			{
				if (this.UJPVMgwbGBJvyplNKHGrhFAlOsogA == null)
				{
					this._defaultToCenter = value;
					return;
				}
				this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.defaultToCenter = value;
				this._defaultToCenter = this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.defaultToCenter;
			}
		}

		// Token: 0x17000936 RID: 2358
		// (get) Token: 0x0600272E RID: 10030 RVA: 0x0001D3A8 File Offset: 0x0001B5A8
		// (set) Token: 0x0600272F RID: 10031 RVA: 0x0001D3C4 File Offset: 0x0001B5C4
		public bool clampToMovementArea
		{
			get
			{
				if (!base.initialized)
				{
					return this._clampToMovementArea;
				}
				return this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.clampToMovementArea;
			}
			set
			{
				if (this.UJPVMgwbGBJvyplNKHGrhFAlOsogA == null)
				{
					this._clampToMovementArea = value;
					return;
				}
				this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.clampToMovementArea = value;
				this._clampToMovementArea = this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.clampToMovementArea;
			}
		}

		// Token: 0x17000937 RID: 2359
		// (get) Token: 0x06002730 RID: 10032 RVA: 0x000952E4 File Offset: 0x000934E4
		// (set) Token: 0x06002731 RID: 10033 RVA: 0x00095338 File Offset: 0x00093538
		public ScreenRect movementArea
		{
			get
			{
				if (!base.initialized)
				{
					return new ScreenRect(this._movementArea.xMin, this._movementArea.yMin, this._movementArea.width, this._movementArea.height);
				}
				return this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.movementArea;
			}
			set
			{
				if (this.UJPVMgwbGBJvyplNKHGrhFAlOsogA == null)
				{
					this._movementArea = new Rect(value.xMin, value.yMin, value.width, value.height);
					return;
				}
				this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.movementArea = value;
				this._movementArea = new Rect(this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.movementArea.xMin, this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.movementArea.yMin, this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.movementArea.width, this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.movementArea.height);
			}
		}

		// Token: 0x17000938 RID: 2360
		// (get) Token: 0x06002732 RID: 10034 RVA: 0x0001D3F3 File Offset: 0x0001B5F3
		// (set) Token: 0x06002733 RID: 10035 RVA: 0x0001D40F File Offset: 0x0001B60F
		public PlayerMouse.MovementAreaUnit movementAreaUnit
		{
			get
			{
				if (!base.initialized)
				{
					return this._movementAreaUnit;
				}
				return this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.movementAreaUnit;
			}
			set
			{
				if (this.UJPVMgwbGBJvyplNKHGrhFAlOsogA == null)
				{
					this._movementAreaUnit = value;
					return;
				}
				this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.movementAreaUnit = value;
				this._movementAreaUnit = this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.movementAreaUnit;
			}
		}

		// Token: 0x17000939 RID: 2361
		// (get) Token: 0x06002734 RID: 10036 RVA: 0x0001D43E File Offset: 0x0001B63E
		// (set) Token: 0x06002735 RID: 10037 RVA: 0x0001D459 File Offset: 0x0001B659
		public Vector2 screenPosition
		{
			get
			{
				if (!base.initialized)
				{
					return Vector2.zero;
				}
				return this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.screenPosition;
			}
			set
			{
				if (this.UJPVMgwbGBJvyplNKHGrhFAlOsogA == null)
				{
					return;
				}
				this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.screenPosition = value;
			}
		}

		// Token: 0x1700093A RID: 2362
		// (get) Token: 0x06002736 RID: 10038 RVA: 0x0001D470 File Offset: 0x0001B670
		public Vector2 screenPositionPrev
		{
			get
			{
				if (!base.initialized)
				{
					return Vector2.zero;
				}
				return this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.screenPositionPrev;
			}
		}

		// Token: 0x1700093B RID: 2363
		// (get) Token: 0x06002737 RID: 10039 RVA: 0x0001D48B File Offset: 0x0001B68B
		public Vector2 screenPositionDelta
		{
			get
			{
				if (!base.initialized)
				{
					return Vector2.zero;
				}
				return this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.screenPositionDelta;
			}
		}

		// Token: 0x1700093C RID: 2364
		// (get) Token: 0x06002738 RID: 10040 RVA: 0x0001D4A6 File Offset: 0x0001B6A6
		public PlayerController.MouseAxis xAxis
		{
			get
			{
				if (!base.initialized)
				{
					return null;
				}
				return this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.xAxis;
			}
		}

		// Token: 0x1700093D RID: 2365
		// (get) Token: 0x06002739 RID: 10041 RVA: 0x0001D4BD File Offset: 0x0001B6BD
		public PlayerController.MouseAxis yAxis
		{
			get
			{
				if (!base.initialized)
				{
					return null;
				}
				return this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.yAxis;
			}
		}

		// Token: 0x1700093E RID: 2366
		// (get) Token: 0x0600273A RID: 10042 RVA: 0x0001D4D4 File Offset: 0x0001B6D4
		public PlayerController.MouseWheel wheel
		{
			get
			{
				if (!base.initialized)
				{
					return null;
				}
				return this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.wheel;
			}
		}

		// Token: 0x1700093F RID: 2367
		// (get) Token: 0x0600273B RID: 10043 RVA: 0x0001D4EB File Offset: 0x0001B6EB
		public PlayerController.Button leftButton
		{
			get
			{
				if (!base.initialized)
				{
					return null;
				}
				return this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.leftButton;
			}
		}

		// Token: 0x17000940 RID: 2368
		// (get) Token: 0x0600273C RID: 10044 RVA: 0x0001D502 File Offset: 0x0001B702
		public PlayerController.Button rightButton
		{
			get
			{
				if (!base.initialized)
				{
					return null;
				}
				return this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.rightButton;
			}
		}

		// Token: 0x17000941 RID: 2369
		// (get) Token: 0x0600273D RID: 10045 RVA: 0x0001D519 File Offset: 0x0001B719
		public PlayerController.Button middleButton
		{
			get
			{
				if (!base.initialized)
				{
					return null;
				}
				return this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.middleButton;
			}
		}

		// Token: 0x17000942 RID: 2370
		// (get) Token: 0x0600273E RID: 10046 RVA: 0x0001D530 File Offset: 0x0001B730
		// (set) Token: 0x0600273F RID: 10047 RVA: 0x0001D54C File Offset: 0x0001B74C
		public float pointerSpeed
		{
			get
			{
				if (!base.initialized)
				{
					return this._pointerSpeed;
				}
				return this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.pointerSpeed;
			}
			set
			{
				if (value < 0f)
				{
					value = 0f;
				}
				this._pointerSpeed = value;
				if (base.initialized)
				{
					this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.pointerSpeed = value;
					this._pointerSpeed = this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.pointerSpeed;
				}
			}
		}

		// Token: 0x17000943 RID: 2371
		// (get) Token: 0x06002740 RID: 10048 RVA: 0x0001D589 File Offset: 0x0001B789
		// (set) Token: 0x06002741 RID: 10049 RVA: 0x0001D5A5 File Offset: 0x0001B7A5
		public bool useHardwarePointerPosition
		{
			get
			{
				if (!base.initialized)
				{
					return this._useHardwarePointerPosition;
				}
				return this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.useHardwarePointerPosition;
			}
			set
			{
				this._useHardwarePointerPosition = value;
				if (base.initialized)
				{
					this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.useHardwarePointerPosition = value;
				}
			}
		}

		// Token: 0x1400003B RID: 59
		// (add) Token: 0x06002742 RID: 10050 RVA: 0x0001D5C2 File Offset: 0x0001B7C2
		// (remove) Token: 0x06002743 RID: 10051 RVA: 0x0001D5D9 File Offset: 0x0001B7D9
		public event Action<Vector2> ScreenPositionChangedEvent
		{
			add
			{
				if (!base.initialized)
				{
					return;
				}
				this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.ScreenPositionChangedEvent += value;
			}
			remove
			{
				if (!base.initialized)
				{
					return;
				}
				this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.ScreenPositionChangedEvent -= value;
			}
		}

		// Token: 0x06002744 RID: 10052 RVA: 0x000953C8 File Offset: 0x000935C8
		protected override void OnValidated()
		{
			base.OnValidated();
			this.defaultToCenter = this._defaultToCenter;
			this.clampToMovementArea = this._clampToMovementArea;
			this.movementArea = new ScreenRect(this._movementArea.xMin, this._movementArea.yMin, this._movementArea.width, this._movementArea.height);
			this.movementAreaUnit = this._movementAreaUnit;
			this.pointerSpeed = this._pointerSpeed;
			this.useHardwarePointerPosition = this._useHardwarePointerPosition;
		}

		// Token: 0x06002745 RID: 10053 RVA: 0x00095450 File Offset: 0x00093650
		protected override void OnReset()
		{
			base.OnReset();
			this._clampToMovementArea = true;
			this._defaultToCenter = true;
			this._pointerSpeed = 1f;
			this._useHardwarePointerPosition = true;
			this._movementArea = new Rect(0f, 0f, 1f, 1f);
			this._movementAreaUnit = PlayerMouse.MovementAreaUnit.Screen;
			this._onScreenPositionChanged = new PlayerMouse.ScreenPositionChangedHandler();
		}

		// Token: 0x06002746 RID: 10054 RVA: 0x000954B4 File Offset: 0x000936B4
		protected override PlayerController CreateSource(object args)
		{
			IList<PlayerController.ElementInfo> list = args as IList<PlayerController.ElementInfo>;
			if (list == null || list.Count == 0)
			{
				Logger.LogWarning("Invalid element information. Did you configure elements in the inspector? Using defaults.");
				list = this.sTvASyFgRApCVUjziioirnomHUnjA();
			}
			List<PlayerController.Element.Definition> list2 = new List<PlayerController.Element.Definition>(list.Count);
			foreach (PlayerController.ElementInfo elementInfo in list)
			{
				list2.Add(elementInfo.ToDefinition());
			}
			return PlayerMouse.Factory.Create(new PlayerMouse.Definition
			{
				playerId = base.playerId,
				elements = list2,
				defaultToCenter = this._defaultToCenter,
				clampToMovementArea = this._clampToMovementArea,
				movementArea = new ScreenRect(this._movementArea.xMin, this._movementArea.yMin, this._movementArea.width, this._movementArea.height),
				movementAreaUnit = this._movementAreaUnit,
				pointerSpeed = this._pointerSpeed,
				useHardwarePointerPosition = this._useHardwarePointerPosition
			});
		}

		// Token: 0x06002747 RID: 10055 RVA: 0x0001D5F0 File Offset: 0x0001B7F0
		protected override void Deinitialize()
		{
			base.Deinitialize();
		}

		// Token: 0x06002748 RID: 10056 RVA: 0x0001D5F8 File Offset: 0x0001B7F8
		protected override void Subscribe()
		{
			base.Subscribe();
			if (this.UJPVMgwbGBJvyplNKHGrhFAlOsogA != null)
			{
				this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.ScreenPositionChangedEvent += this.GYyykBnHdBiVAzabukRzaNJSJbGl;
			}
		}

		// Token: 0x06002749 RID: 10057 RVA: 0x0001D61F File Offset: 0x0001B81F
		protected override void Unsubscribe()
		{
			base.Unsubscribe();
			if (this.UJPVMgwbGBJvyplNKHGrhFAlOsogA != null)
			{
				this.UJPVMgwbGBJvyplNKHGrhFAlOsogA.ScreenPositionChangedEvent -= this.GYyykBnHdBiVAzabukRzaNJSJbGl;
			}
		}

		// Token: 0x0600274A RID: 10058 RVA: 0x000955C0 File Offset: 0x000937C0
		internal List<PlayerController.ElementInfo> BckhiDDXKBrqbTGjMtZZkoDWTDNtA()
		{
			return new List<PlayerController.ElementInfo>
			{
				new PlayerController.ElementInfo
				{
					name = "Movement",
					elementType = PlayerController.Element.Type.MouseAxis2D,
					elements = new PlayerController.ElementWithSourceInfo[]
					{
						new PlayerController.ElementWithSourceInfo
						{
							name = "Horizontal",
							elementType = PlayerController.Element.TypeWithSource.MouseAxis,
							coordinateMode = AxisCoordinateMode.Relative,
							absoluteSourceSensitivity = 600f
						},
						new PlayerController.ElementWithSourceInfo
						{
							name = "Vertical",
							elementType = PlayerController.Element.TypeWithSource.MouseAxis,
							coordinateMode = AxisCoordinateMode.Relative,
							absoluteSourceSensitivity = 600f
						}
					}
				},
				new PlayerController.ElementInfo
				{
					name = "Wheel",
					elementType = PlayerController.Element.Type.MouseWheel,
					elements = new PlayerController.ElementWithSourceInfo[]
					{
						new PlayerController.ElementWithSourceInfo
						{
							name = "Wheel Horizontal",
							elementType = PlayerController.Element.TypeWithSource.MouseWheelAxis,
							coordinateMode = AxisCoordinateMode.Relative
						},
						new PlayerController.ElementWithSourceInfo
						{
							name = "Wheel Vertical",
							elementType = PlayerController.Element.TypeWithSource.MouseWheelAxis,
							coordinateMode = AxisCoordinateMode.Relative
						}
					}
				},
				new PlayerController.ElementInfo
				{
					elements = new PlayerController.ElementWithSourceInfo[]
					{
						new PlayerController.ElementWithSourceInfo
						{
							name = "Left Button",
							elementType = PlayerController.Element.TypeWithSource.Button
						}
					}
				},
				new PlayerController.ElementInfo
				{
					elements = new PlayerController.ElementWithSourceInfo[]
					{
						new PlayerController.ElementWithSourceInfo
						{
							name = "Right Button",
							elementType = PlayerController.Element.TypeWithSource.Button
						}
					}
				},
				new PlayerController.ElementInfo
				{
					elements = new PlayerController.ElementWithSourceInfo[]
					{
						new PlayerController.ElementWithSourceInfo
						{
							name = "Middle Button",
							elementType = PlayerController.Element.TypeWithSource.Button
						}
					}
				}
			};
		}

		// Token: 0x0600274B RID: 10059 RVA: 0x00095760 File Offset: 0x00093960
		private void GYyykBnHdBiVAzabukRzaNJSJbGl(Vector2 A_1)
		{
			if (!UnityTools.IsActiveAndEnabled(this))
			{
				return;
			}
			try
			{
				if (this._onScreenPositionChanged != null)
				{
					this._onScreenPositionChanged.Invoke(A_1);
				}
			}
			catch (Exception ex)
			{
				string str = "An exception occurred in a listener of ScreenPositionChangedEvent. This means an exception was thrown by your code.\n";
				Exception ex2 = ex;
				Logger.LogError(str + ((ex2 != null) ? ex2.ToString() : null));
			}
		}

		// Token: 0x17000944 RID: 2372
		// (get) Token: 0x0600274C RID: 10060 RVA: 0x0001D646 File Offset: 0x0001B846
		bool IMouseInputSource.enabled
		{
			get
			{
				return base.initialized && ((IMouseInputSource)this.UJPVMgwbGBJvyplNKHGrhFAlOsogA).enabled;
			}
		}

		// Token: 0x0600274D RID: 10061 RVA: 0x0001D65D File Offset: 0x0001B85D
		bool IMouseInputSource.GetButtonDown(int button)
		{
			return base.initialized && ((IMouseInputSource)this.UJPVMgwbGBJvyplNKHGrhFAlOsogA).GetButtonDown(button);
		}

		// Token: 0x0600274E RID: 10062 RVA: 0x0001D675 File Offset: 0x0001B875
		bool IMouseInputSource.GetButtonUp(int button)
		{
			return base.initialized && ((IMouseInputSource)this.UJPVMgwbGBJvyplNKHGrhFAlOsogA).GetButtonUp(button);
		}

		// Token: 0x0600274F RID: 10063 RVA: 0x0001D68D File Offset: 0x0001B88D
		bool IMouseInputSource.GetButton(int button)
		{
			return base.initialized && ((IMouseInputSource)this.UJPVMgwbGBJvyplNKHGrhFAlOsogA).GetButton(button);
		}

		// Token: 0x17000945 RID: 2373
		// (get) Token: 0x06002750 RID: 10064 RVA: 0x0001D6A5 File Offset: 0x0001B8A5
		Vector2 IMouseInputSource.screenPosition
		{
			get
			{
				if (!base.initialized)
				{
					return Vector2.zero;
				}
				return ((IMouseInputSource)this.UJPVMgwbGBJvyplNKHGrhFAlOsogA).screenPosition;
			}
		}

		// Token: 0x17000946 RID: 2374
		// (get) Token: 0x06002751 RID: 10065 RVA: 0x0001D6C0 File Offset: 0x0001B8C0
		Vector2 IMouseInputSource.screenPositionDelta
		{
			get
			{
				if (!base.initialized)
				{
					return Vector2.zero;
				}
				return ((IMouseInputSource)this.UJPVMgwbGBJvyplNKHGrhFAlOsogA).screenPositionDelta;
			}
		}

		// Token: 0x17000947 RID: 2375
		// (get) Token: 0x06002752 RID: 10066 RVA: 0x0001D6DB File Offset: 0x0001B8DB
		Vector2 IMouseInputSource.wheelDelta
		{
			get
			{
				if (!base.initialized)
				{
					return Vector2.zero;
				}
				return ((IMouseInputSource)this.UJPVMgwbGBJvyplNKHGrhFAlOsogA).wheelDelta;
			}
		}

		// Token: 0x17000948 RID: 2376
		// (get) Token: 0x06002753 RID: 10067 RVA: 0x0001D6F6 File Offset: 0x0001B8F6
		bool IMouseInputSource.locked
		{
			get
			{
				return base.initialized && ((IMouseInputSource)this.UJPVMgwbGBJvyplNKHGrhFAlOsogA).locked;
			}
		}

		// Token: 0x06002755 RID: 10069 RVA: 0x0001D225 File Offset: 0x0001B425
		bool IPlayerController.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x06002756 RID: 10070 RVA: 0x0001D22D File Offset: 0x0001B42D
		void IPlayerController.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x040016F2 RID: 5874
		[Tooltip("If enabled, the screen position will default to the center of the allowed movement area. Otherwise, it will default to the lower-left corner of the allowed movement area.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _defaultToCenter = true;

		// Token: 0x040016F3 RID: 5875
		[Tooltip("The pointer speed. This does not affect the speed of input from the mouse x/y axes if useHardwarePointerPosition is enabled. It only affects the speed from input sources other than mouse x/y or if mouse x/y are mapped to Actions assigned to Axes. ")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _pointerSpeed = 1f;

		// Token: 0x040016F4 RID: 5876
		[Tooltip("If enabled, the hardware pointer position will be used for mouse input. Otherwise, the position of the pointer will be calculated only from the Axis Action values. The Player that owns this Player Mouse must have the physical mouse assigned to it in order for the hardware position to be used, ex: player.controllers.hasMouse == true.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useHardwarePointerPosition = true;

		// Token: 0x040016F5 RID: 5877
		[Tooltip("If enabled, movement will be clamped to the Movement Area.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _clampToMovementArea = true;

		// Token: 0x040016F6 RID: 5878
		[Tooltip("The allowed movement area for the mouse pointer. Set Movement Area Unit to determine the data format of this value. This rect is a screen-space rect with 0, 0 at the lower-left corner.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Rect _movementArea = new Rect(0f, 0f, 1f, 1f);

		// Token: 0x040016F7 RID: 5879
		[Tooltip("The unit format of the movement area. This is used to determine the data format of Movement Area.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private PlayerMouse.MovementAreaUnit _movementAreaUnit;

		// Token: 0x040016F8 RID: 5880
		[Tooltip("Triggered when the screen position changes. Link this to your pointer to drive its position.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private PlayerMouse.ScreenPositionChangedHandler _onScreenPositionChanged = new PlayerMouse.ScreenPositionChangedHandler();

		// Token: 0x020003D8 RID: 984
		[Serializable]
		public class ScreenPositionChangedHandler : UnityEvent<Vector2>
		{
		}
	}
}
