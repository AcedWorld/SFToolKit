using System;
using System.Collections.Generic;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	// Token: 0x020003C7 RID: 967
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class SteamControllerExtension : Controller.Extension
	{
		// Token: 0x1700091E RID: 2334
		// (get) Token: 0x060026AD RID: 9901 RVA: 0x00014B29 File Offset: 0x00012D29
		private Joystick joystick
		{
			get
			{
				return base.GetController<Joystick>();
			}
		}

		// Token: 0x1700091F RID: 2335
		// (get) Token: 0x060026AE RID: 9902 RVA: 0x0001C9D7 File Offset: 0x0001ABD7
		internal ISteamControllerInternal internalController
		{
			get
			{
				return this.bvdrmyLTFEQSXwVRbOhGBdgkZeMP.XnOCvUgqOaNwsXkUdacnIULdPtKpb;
			}
		}

		// Token: 0x060026AF RID: 9903 RVA: 0x0001C9E4 File Offset: 0x0001ABE4
		internal SteamControllerExtension(ISteamControllerInternal A_1) : base(new SteamControllerExtension.LMSGWAfYLaUnCbVWqnujgXbcTqdKc(A_1))
		{
			this.KlPWxxAGtdmINIrwYNotIOYXeLeEA();
		}

		// Token: 0x060026B0 RID: 9904 RVA: 0x0001C9F8 File Offset: 0x0001ABF8
		private SteamControllerExtension(SteamControllerExtension A_1) : base(A_1)
		{
			this.KlPWxxAGtdmINIrwYNotIOYXeLeEA();
		}

		// Token: 0x060026B1 RID: 9905 RVA: 0x0001CA07 File Offset: 0x0001AC07
		public ulong GetActionSetHandle(string actionSetName)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return 0UL;
			}
			return this.bvdrmyLTFEQSXwVRbOhGBdgkZeMP.XnOCvUgqOaNwsXkUdacnIULdPtKpb.GetActionSetHandle(ref actionSetName);
		}

		// Token: 0x060026B2 RID: 9906 RVA: 0x0001CA37 File Offset: 0x0001AC37
		public ulong GetAnalogActionHandle(string actionName)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return 0UL;
			}
			return this.bvdrmyLTFEQSXwVRbOhGBdgkZeMP.XnOCvUgqOaNwsXkUdacnIULdPtKpb.GetAnalogActionHandle(ref actionName);
		}

		// Token: 0x060026B3 RID: 9907 RVA: 0x0001CA67 File Offset: 0x0001AC67
		public ulong GetDigitalActionHandle(string actionName)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return 0UL;
			}
			return this.bvdrmyLTFEQSXwVRbOhGBdgkZeMP.XnOCvUgqOaNwsXkUdacnIULdPtKpb.GetDigitalActionHandle(ref actionName);
		}

		// Token: 0x060026B4 RID: 9908 RVA: 0x0001CA97 File Offset: 0x0001AC97
		public string GetActionSetName(ulong actionSetHandle)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return string.Empty;
			}
			return this.bvdrmyLTFEQSXwVRbOhGBdgkZeMP.XnOCvUgqOaNwsXkUdacnIULdPtKpb.GetActionSetName(actionSetHandle);
		}

		// Token: 0x060026B5 RID: 9909 RVA: 0x0001CAC9 File Offset: 0x0001ACC9
		public string GetAnalogActionName(ulong actionHandle)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return string.Empty;
			}
			return this.bvdrmyLTFEQSXwVRbOhGBdgkZeMP.XnOCvUgqOaNwsXkUdacnIULdPtKpb.GetAnalogActionName(actionHandle);
		}

		// Token: 0x060026B6 RID: 9910 RVA: 0x0001CAFB File Offset: 0x0001ACFB
		public string GetDigitalActionName(ulong actionHandle)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return string.Empty;
			}
			return this.bvdrmyLTFEQSXwVRbOhGBdgkZeMP.XnOCvUgqOaNwsXkUdacnIULdPtKpb.GetDigitalActionName(actionHandle);
		}

		// Token: 0x060026B7 RID: 9911 RVA: 0x0001CB2D File Offset: 0x0001AD2D
		public Vector2 GetAnalogActionValue(string actionName)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return Vector2.zero;
			}
			return this.bvdrmyLTFEQSXwVRbOhGBdgkZeMP.XnOCvUgqOaNwsXkUdacnIULdPtKpb.GetAnalogActionValue(ref actionName);
		}

		// Token: 0x060026B8 RID: 9912 RVA: 0x0001CB60 File Offset: 0x0001AD60
		public Vector2 GetAnalogActionValue(ulong actionHandle)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return Vector2.zero;
			}
			return this.bvdrmyLTFEQSXwVRbOhGBdgkZeMP.XnOCvUgqOaNwsXkUdacnIULdPtKpb.GetAnalogActionValue(actionHandle);
		}

		// Token: 0x060026B9 RID: 9913 RVA: 0x0001CB92 File Offset: 0x0001AD92
		public bool GetDigitalActionValue(string actionName)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return false;
			}
			return this.bvdrmyLTFEQSXwVRbOhGBdgkZeMP.XnOCvUgqOaNwsXkUdacnIULdPtKpb.GetDigitalActionValue(ref actionName);
		}

		// Token: 0x060026BA RID: 9914 RVA: 0x0001CBC1 File Offset: 0x0001ADC1
		public bool GetDigitalActionValue(ulong actionHandle)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return false;
			}
			return this.bvdrmyLTFEQSXwVRbOhGBdgkZeMP.XnOCvUgqOaNwsXkUdacnIULdPtKpb.GetDigitalActionValue(actionHandle);
		}

		// Token: 0x060026BB RID: 9915 RVA: 0x0001CBEF File Offset: 0x0001ADEF
		public bool SetActiveActionSet(ulong actionSetHandle)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return false;
			}
			return this.bvdrmyLTFEQSXwVRbOhGBdgkZeMP.XnOCvUgqOaNwsXkUdacnIULdPtKpb.SetActiveActionSet(actionSetHandle);
		}

		// Token: 0x060026BC RID: 9916 RVA: 0x0001CC1D File Offset: 0x0001AE1D
		public bool SetActiveActionSet(string actionSetName)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return false;
			}
			return this.bvdrmyLTFEQSXwVRbOhGBdgkZeMP.XnOCvUgqOaNwsXkUdacnIULdPtKpb.SetActiveActionSet(ref actionSetName);
		}

		// Token: 0x060026BD RID: 9917 RVA: 0x0001CC4C File Offset: 0x0001AE4C
		public ulong GetActiveActionSetHandle()
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return 0UL;
			}
			return this.bvdrmyLTFEQSXwVRbOhGBdgkZeMP.XnOCvUgqOaNwsXkUdacnIULdPtKpb.GetActiveActionSetHandle();
		}

		// Token: 0x060026BE RID: 9918 RVA: 0x0001CC7A File Offset: 0x0001AE7A
		public string GetActiveActionSetName()
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return string.Empty;
			}
			return this.bvdrmyLTFEQSXwVRbOhGBdgkZeMP.XnOCvUgqOaNwsXkUdacnIULdPtKpb.GetActiveActionSetName();
		}

		// Token: 0x060026BF RID: 9919 RVA: 0x0001CCAB File Offset: 0x0001AEAB
		public void ShowBindingPanel()
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			this.bvdrmyLTFEQSXwVRbOhGBdgkZeMP.XnOCvUgqOaNwsXkUdacnIULdPtKpb.ShowBindingPanel();
		}

		// Token: 0x060026C0 RID: 9920 RVA: 0x0001CCD7 File Offset: 0x0001AED7
		public void SetHapticPulse(SteamControllerPadType targePad, float durationSeconds)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			this.bvdrmyLTFEQSXwVRbOhGBdgkZeMP.XnOCvUgqOaNwsXkUdacnIULdPtKpb.SetHapticPulse(targePad, durationSeconds);
		}

		// Token: 0x060026C1 RID: 9921 RVA: 0x0001CD05 File Offset: 0x0001AF05
		public void SetHapticPulse(SteamControllerPadType targePad, ushort durationMicroSeconds)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			this.bvdrmyLTFEQSXwVRbOhGBdgkZeMP.XnOCvUgqOaNwsXkUdacnIULdPtKpb.SetHapticPulse(targePad, durationMicroSeconds);
		}

		// Token: 0x060026C2 RID: 9922 RVA: 0x0001CD33 File Offset: 0x0001AF33
		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return this.bvdrmyLTFEQSXwVRbOhGBdgkZeMP.XnOCvUgqOaNwsXkUdacnIULdPtKpb.GetDigitalActionOrigins(ref actionSetName, ref actionName);
		}

		// Token: 0x060026C3 RID: 9923 RVA: 0x0001CD68 File Offset: 0x0001AF68
		public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return this.bvdrmyLTFEQSXwVRbOhGBdgkZeMP.XnOCvUgqOaNwsXkUdacnIULdPtKpb.GetDigitalActionOrigins(actionSetHandle, actionHandle);
		}

		// Token: 0x060026C4 RID: 9924 RVA: 0x0001CD9B File Offset: 0x0001AF9B
		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(string actionSetName, string actionName)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return this.bvdrmyLTFEQSXwVRbOhGBdgkZeMP.XnOCvUgqOaNwsXkUdacnIULdPtKpb.GetAnalogActionOrigins(ref actionSetName, ref actionName);
		}

		// Token: 0x060026C5 RID: 9925 RVA: 0x0001CDD0 File Offset: 0x0001AFD0
		public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
			}
			return this.bvdrmyLTFEQSXwVRbOhGBdgkZeMP.XnOCvUgqOaNwsXkUdacnIULdPtKpb.GetAnalogActionOrigins(actionSetHandle, actionHandle);
		}

		// Token: 0x060026C6 RID: 9926 RVA: 0x00002FF9 File Offset: 0x000011F9
		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		// Token: 0x060026C7 RID: 9927 RVA: 0x0001CE03 File Offset: 0x0001B003
		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			this.bvdrmyLTFEQSXwVRbOhGBdgkZeMP = (source as SteamControllerExtension.LMSGWAfYLaUnCbVWqnujgXbcTqdKc);
		}

		// Token: 0x060026C8 RID: 9928 RVA: 0x0001CE11 File Offset: 0x0001B011
		internal override Controller.Extension Clone()
		{
			return new SteamControllerExtension(this);
		}

		// Token: 0x060026C9 RID: 9929 RVA: 0x00002FF9 File Offset: 0x000011F9
		private void KlPWxxAGtdmINIrwYNotIOYXeLeEA()
		{
		}

		// Token: 0x040016BB RID: 5819
		private SteamControllerExtension.LMSGWAfYLaUnCbVWqnujgXbcTqdKc bvdrmyLTFEQSXwVRbOhGBdgkZeMP;

		// Token: 0x020003C8 RID: 968
		private class LMSGWAfYLaUnCbVWqnujgXbcTqdKc : IControllerExtensionSource
		{
			// Token: 0x060026CA RID: 9930 RVA: 0x0001CE19 File Offset: 0x0001B019
			public LMSGWAfYLaUnCbVWqnujgXbcTqdKc(ISteamControllerInternal A_1)
			{
				this.XnOCvUgqOaNwsXkUdacnIULdPtKpb = A_1;
			}

			// Token: 0x040016BC RID: 5820
			public readonly ISteamControllerInternal XnOCvUgqOaNwsXkUdacnIULdPtKpb;
		}
	}
}
