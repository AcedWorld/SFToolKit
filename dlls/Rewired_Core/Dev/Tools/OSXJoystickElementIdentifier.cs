using System;
using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	// Token: 0x02000549 RID: 1353
	[AddComponentMenu("")]
	[RequireComponent(typeof(GUIText))]
	public sealed class OSXJoystickElementIdentifier : MonoBehaviour
	{
		// Token: 0x060036C0 RID: 14016 RVA: 0x000BB404 File Offset: 0x000B9604
		public void Awake()
		{
			if (!this.gWMCEjzXRwIscfgYPhbCRHBWopED())
			{
				return;
			}
			if (base.transform.position != Vector3.zero)
			{
				base.transform.position = Vector3.zero;
			}
			this.aBBCNDSvxBssGfUyFbtPATZGwWpI = (sDhSoBMwkZfQWoCQcGBWjPdebVsz.fNreHNkrELAoNGLLGKLBvHBsUsBN("Rewired_OSX", "OSX") as IElementIdentifierTool);
			if (this.aBBCNDSvxBssGfUyFbtPATZGwWpI == null)
			{
				Logger.LogError("OSX Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
				return;
			}
			this.aBBCNDSvxBssGfUyFbtPATZGwWpI.Initialize(GUIText.CreateLogger(base.gameObject));
		}

		// Token: 0x060036C1 RID: 14017 RVA: 0x0002AAFD File Offset: 0x00028CFD
		public void Start()
		{
			if (this.aBBCNDSvxBssGfUyFbtPATZGwWpI != null)
			{
				this.aBBCNDSvxBssGfUyFbtPATZGwWpI.Start();
			}
		}

		// Token: 0x060036C2 RID: 14018 RVA: 0x0002AB12 File Offset: 0x00028D12
		public void Update()
		{
			if (this.aBBCNDSvxBssGfUyFbtPATZGwWpI != null)
			{
				this.aBBCNDSvxBssGfUyFbtPATZGwWpI.Update();
			}
		}

		// Token: 0x060036C3 RID: 14019 RVA: 0x0002AB27 File Offset: 0x00028D27
		public void OnDestroy()
		{
			if (this.aBBCNDSvxBssGfUyFbtPATZGwWpI != null)
			{
				this.aBBCNDSvxBssGfUyFbtPATZGwWpI.OnDestroy();
			}
			this.aBBCNDSvxBssGfUyFbtPATZGwWpI = null;
		}

		// Token: 0x060036C4 RID: 14020 RVA: 0x000BB1A0 File Offset: 0x000B93A0
		private bool gWMCEjzXRwIscfgYPhbCRHBWopED()
		{
			InputManager_Base[] array = (InputManager_Base[])Object.FindObjectsOfType(typeof(InputManager_Base));
			if (array == null || array.Length == 0)
			{
				Logger.LogError("No active Rewired Input Manager was found in the scene! You must create a Rewired Input Manager for the tool to function.");
				return false;
			}
			return true;
		}

		// Token: 0x04001CB1 RID: 7345
		private IElementIdentifierTool aBBCNDSvxBssGfUyFbtPATZGwWpI;
	}
}
