using System;
using System.Collections.Generic;
using Rewired.ControllerExtensions;
using UnityEngine;

namespace Rewired.Interfaces
{
	// Token: 0x020001F1 RID: 497
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal interface ISteamControllerInternal
	{
		// Token: 0x17000619 RID: 1561
		// (get) Token: 0x06001900 RID: 6400
		int MaxActionSourceCount { get; }

		// Token: 0x1700061A RID: 1562
		// (get) Token: 0x06001901 RID: 6401
		bool IsConnected { get; }

		// Token: 0x06001902 RID: 6402
		string GetActionSetName(ulong handle);

		// Token: 0x06001903 RID: 6403
		string GetDigitalActionName(ulong handle);

		// Token: 0x06001904 RID: 6404
		string GetAnalogActionName(ulong handle);

		// Token: 0x06001905 RID: 6405
		ulong GetActionSetHandle(ref string actionSetName);

		// Token: 0x06001906 RID: 6406
		ulong GetDigitalActionHandle(ref string actionName);

		// Token: 0x06001907 RID: 6407
		ulong GetAnalogActionHandle(ref string actionName);

		// Token: 0x06001908 RID: 6408
		bool GetDigitalActionValue(ulong actionHandle);

		// Token: 0x06001909 RID: 6409
		bool GetDigitalActionValue(ref string actionName);

		// Token: 0x0600190A RID: 6410
		Vector2 GetAnalogActionValue(ulong actionHandle);

		// Token: 0x0600190B RID: 6411
		Vector2 GetAnalogActionValue(ref string actionName);

		// Token: 0x0600190C RID: 6412
		bool SetActiveActionSet(ulong actionSetHandle);

		// Token: 0x0600190D RID: 6413
		bool SetActiveActionSet(ref string actionSetName);

		// Token: 0x0600190E RID: 6414
		ulong GetActiveActionSetHandle();

		// Token: 0x0600190F RID: 6415
		string GetActiveActionSetName();

		// Token: 0x06001910 RID: 6416
		void ShowBindingPanel();

		// Token: 0x06001911 RID: 6417
		void SetHapticPulse(SteamControllerPadType targetPad, float durationSeconds);

		// Token: 0x06001912 RID: 6418
		void SetHapticPulse(SteamControllerPadType targetPad, ushort durationMicroSeconds);

		// Token: 0x06001913 RID: 6419
		IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ref string actionSetName, ref string actionName);

		// Token: 0x06001914 RID: 6420
		IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle);

		// Token: 0x06001915 RID: 6421
		IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ref string actionSetName, ref string actionName);

		// Token: 0x06001916 RID: 6422
		IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle);
	}
}
