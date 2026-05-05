using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Utils.Interfaces
{
	// Token: 0x02000527 RID: 1319
	public interface IExternalTools
	{
		// Token: 0x17000C19 RID: 3097
		// (get) Token: 0x0600362B RID: 13867
		bool isEditorPaused { get; }

		// Token: 0x14000071 RID: 113
		// (add) Token: 0x0600362C RID: 13868
		// (remove) Token: 0x0600362D RID: 13869
		event Action<bool> EditorPausedStateChangedEvent;

		// Token: 0x0600362E RID: 13870
		void Destroy();

		// Token: 0x0600362F RID: 13871
		object GetPlatformInitializer();

		// Token: 0x06003630 RID: 13872
		string GetFocusedEditorWindowTitle();

		// Token: 0x06003631 RID: 13873
		bool IsEditorSceneViewFocused();

		// Token: 0x06003632 RID: 13874
		bool LinuxInput_IsJoystickPreconfigured(string name);

		// Token: 0x06003633 RID: 13875
		int XboxOneInput_GetUserIdForGamepad(uint id);

		// Token: 0x06003634 RID: 13876
		ulong XboxOneInput_GetControllerId(uint unityJoystickId);

		// Token: 0x14000072 RID: 114
		// (add) Token: 0x06003635 RID: 13877
		// (remove) Token: 0x06003636 RID: 13878
		event Action<uint, bool> XboxOneInput_OnGamepadStateChange;

		// Token: 0x06003637 RID: 13879
		bool XboxOneInput_IsGamepadActive(uint unityJoystickId);

		// Token: 0x06003638 RID: 13880
		string XboxOneInput_GetControllerType(ulong xboxControllerId);

		// Token: 0x06003639 RID: 13881
		uint XboxOneInput_GetJoystickId(ulong xboxControllerId);

		// Token: 0x0600363A RID: 13882
		void XboxOne_Gamepad_UpdatePlugin();

		// Token: 0x0600363B RID: 13883
		bool XboxOne_Gamepad_SetGamepadVibration(ulong xboxOneJoystickId, float leftMotor, float rightMotor, float leftTriggerLevel, float rightTriggerLevel);

		// Token: 0x0600363C RID: 13884
		void XboxOne_Gamepad_PulseVibrateMotor(ulong xboxOneJoystickId, int motor, float startLevel, float endLevel, ulong durationMS);

		// Token: 0x0600363D RID: 13885
		void GetDeviceVIDPIDs(out List<int> vids, out List<int> pids);

		// Token: 0x0600363E RID: 13886
		int GetAndroidAPILevel();

		// Token: 0x0600363F RID: 13887
		void WindowsStandalone_ForwardRawInput(IntPtr rawInputHeaderIndices, IntPtr rawInputDataIndices, uint indicesCount, IntPtr rawInputData, uint rawInputDataSize);

		// Token: 0x06003640 RID: 13888
		bool UnityUI_Graphic_GetRaycastTarget(object graphic);

		// Token: 0x06003641 RID: 13889
		void UnityUI_Graphic_SetRaycastTarget(object graphic, bool value);

		// Token: 0x17000C1A RID: 3098
		// (get) Token: 0x06003642 RID: 13890
		bool UnityInput_IsTouchPressureSupported { get; }

		// Token: 0x06003643 RID: 13891
		float UnityInput_GetTouchPressure(ref Touch touch);

		// Token: 0x06003644 RID: 13892
		float UnityInput_GetTouchMaximumPossiblePressure(ref Touch touch);

		// Token: 0x06003645 RID: 13893
		IControllerTemplate CreateControllerTemplate(Guid typeGuid, object payload);

		// Token: 0x06003646 RID: 13894
		Type[] GetControllerTemplateTypes();

		// Token: 0x06003647 RID: 13895
		Type[] GetControllerTemplateInterfaceTypes();
	}
}
