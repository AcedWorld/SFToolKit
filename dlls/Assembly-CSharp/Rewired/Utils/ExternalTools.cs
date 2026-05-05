using System;
using System.Collections.Generic;
using System.ComponentModel;
using Rewired.Internal;
using Rewired.Utils.Interfaces;
using Rewired.Utils.Platforms.Windows;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

namespace Rewired.Utils
{
	// Token: 0x02000273 RID: 627
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ExternalTools : IExternalTools
	{
		// Token: 0x17000281 RID: 641
		// (get) Token: 0x06000BED RID: 3053 RVA: 0x00043F97 File Offset: 0x00042197
		// (set) Token: 0x06000BEE RID: 3054 RVA: 0x00043F9E File Offset: 0x0004219E
		public static Func<object> getPlatformInitializerDelegate
		{
			get
			{
				return ExternalTools._getPlatformInitializerDelegate;
			}
			set
			{
				ExternalTools._getPlatformInitializerDelegate = value;
			}
		}

		// Token: 0x06000BF0 RID: 3056 RVA: 0x000020BE File Offset: 0x000002BE
		public void Destroy()
		{
		}

		// Token: 0x17000282 RID: 642
		// (get) Token: 0x06000BF1 RID: 3057 RVA: 0x00043FA6 File Offset: 0x000421A6
		public bool isEditorPaused
		{
			get
			{
				return this._isEditorPaused;
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000BF2 RID: 3058 RVA: 0x00043FAE File Offset: 0x000421AE
		// (remove) Token: 0x06000BF3 RID: 3059 RVA: 0x00043FC7 File Offset: 0x000421C7
		public event Action<bool> EditorPausedStateChangedEvent
		{
			add
			{
				this._EditorPausedStateChangedEvent = (Action<bool>)Delegate.Combine(this._EditorPausedStateChangedEvent, value);
			}
			remove
			{
				this._EditorPausedStateChangedEvent = (Action<bool>)Delegate.Remove(this._EditorPausedStateChangedEvent, value);
			}
		}

		// Token: 0x06000BF4 RID: 3060 RVA: 0x00043FE0 File Offset: 0x000421E0
		public object GetPlatformInitializer()
		{
			return Main.GetPlatformInitializer();
		}

		// Token: 0x06000BF5 RID: 3061 RVA: 0x00043FE7 File Offset: 0x000421E7
		public string GetFocusedEditorWindowTitle()
		{
			return string.Empty;
		}

		// Token: 0x06000BF6 RID: 3062 RVA: 0x0000889E File Offset: 0x00006A9E
		public bool IsEditorSceneViewFocused()
		{
			return false;
		}

		// Token: 0x06000BF7 RID: 3063 RVA: 0x0000889E File Offset: 0x00006A9E
		public bool LinuxInput_IsJoystickPreconfigured(string name)
		{
			return false;
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000BF8 RID: 3064 RVA: 0x00043FF0 File Offset: 0x000421F0
		// (remove) Token: 0x06000BF9 RID: 3065 RVA: 0x00044028 File Offset: 0x00042228
		public event Action<uint, bool> XboxOneInput_OnGamepadStateChange;

		// Token: 0x06000BFA RID: 3066 RVA: 0x0000889E File Offset: 0x00006A9E
		public int XboxOneInput_GetUserIdForGamepad(uint id)
		{
			return 0;
		}

		// Token: 0x06000BFB RID: 3067 RVA: 0x0004405D File Offset: 0x0004225D
		public ulong XboxOneInput_GetControllerId(uint unityJoystickId)
		{
			return 0UL;
		}

		// Token: 0x06000BFC RID: 3068 RVA: 0x0000889E File Offset: 0x00006A9E
		public bool XboxOneInput_IsGamepadActive(uint unityJoystickId)
		{
			return false;
		}

		// Token: 0x06000BFD RID: 3069 RVA: 0x00043FE7 File Offset: 0x000421E7
		public string XboxOneInput_GetControllerType(ulong xboxControllerId)
		{
			return string.Empty;
		}

		// Token: 0x06000BFE RID: 3070 RVA: 0x0000889E File Offset: 0x00006A9E
		public uint XboxOneInput_GetJoystickId(ulong xboxControllerId)
		{
			return 0U;
		}

		// Token: 0x06000BFF RID: 3071 RVA: 0x000020BE File Offset: 0x000002BE
		public void XboxOne_Gamepad_UpdatePlugin()
		{
		}

		// Token: 0x06000C00 RID: 3072 RVA: 0x0000889E File Offset: 0x00006A9E
		public bool XboxOne_Gamepad_SetGamepadVibration(ulong xboxOneJoystickId, float leftMotor, float rightMotor, float leftTriggerLevel, float rightTriggerLevel)
		{
			return false;
		}

		// Token: 0x06000C01 RID: 3073 RVA: 0x000020BE File Offset: 0x000002BE
		public void XboxOne_Gamepad_PulseVibrateMotor(ulong xboxOneJoystickId, int motorInt, float startLevel, float endLevel, ulong durationMS)
		{
		}

		// Token: 0x06000C02 RID: 3074 RVA: 0x00044061 File Offset: 0x00042261
		public void GetDeviceVIDPIDs(out List<int> vids, out List<int> pids)
		{
			vids = new List<int>();
			pids = new List<int>();
		}

		// Token: 0x06000C03 RID: 3075 RVA: 0x00044071 File Offset: 0x00042271
		public int GetAndroidAPILevel()
		{
			return -1;
		}

		// Token: 0x06000C04 RID: 3076 RVA: 0x00044074 File Offset: 0x00042274
		public void WindowsStandalone_ForwardRawInput(IntPtr rawInputHeaderIndices, IntPtr rawInputDataIndices, uint indicesCount, IntPtr rawInputData, uint rawInputDataSize)
		{
			UnityEngine.Windows.Input.ForwardRawInput(rawInputHeaderIndices, rawInputDataIndices, indicesCount, rawInputData, rawInputDataSize);
		}

		// Token: 0x06000C05 RID: 3077 RVA: 0x00044082 File Offset: 0x00042282
		public bool UnityUI_Graphic_GetRaycastTarget(object graphic)
		{
			return !(graphic as Graphic == null) && (graphic as Graphic).raycastTarget;
		}

		// Token: 0x06000C06 RID: 3078 RVA: 0x0004409F File Offset: 0x0004229F
		public void UnityUI_Graphic_SetRaycastTarget(object graphic, bool value)
		{
			if (graphic as Graphic == null)
			{
				return;
			}
			(graphic as Graphic).raycastTarget = value;
		}

		// Token: 0x17000283 RID: 643
		// (get) Token: 0x06000C07 RID: 3079 RVA: 0x000440BC File Offset: 0x000422BC
		public bool UnityInput_IsTouchPressureSupported
		{
			get
			{
				return UnityEngine.Input.touchPressureSupported;
			}
		}

		// Token: 0x06000C08 RID: 3080 RVA: 0x000440C3 File Offset: 0x000422C3
		public float UnityInput_GetTouchPressure(ref Touch touch)
		{
			return touch.pressure;
		}

		// Token: 0x06000C09 RID: 3081 RVA: 0x000440CB File Offset: 0x000422CB
		public float UnityInput_GetTouchMaximumPossiblePressure(ref Touch touch)
		{
			return touch.maximumPossiblePressure;
		}

		// Token: 0x06000C0A RID: 3082 RVA: 0x000440D3 File Offset: 0x000422D3
		public IControllerTemplate CreateControllerTemplate(Guid typeGuid, object payload)
		{
			return ControllerTemplateFactory.Create(typeGuid, payload);
		}

		// Token: 0x06000C0B RID: 3083 RVA: 0x000440DC File Offset: 0x000422DC
		public Type[] GetControllerTemplateTypes()
		{
			return ControllerTemplateFactory.templateTypes;
		}

		// Token: 0x06000C0C RID: 3084 RVA: 0x000440E3 File Offset: 0x000422E3
		public Type[] GetControllerTemplateInterfaceTypes()
		{
			return ControllerTemplateFactory.templateInterfaceTypes;
		}

		// Token: 0x0400120B RID: 4619
		private static Func<object> _getPlatformInitializerDelegate;

		// Token: 0x0400120C RID: 4620
		private bool _isEditorPaused;

		// Token: 0x0400120D RID: 4621
		private Action<bool> _EditorPausedStateChangedEvent;
	}
}
