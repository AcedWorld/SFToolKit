using System;
using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	// Token: 0x02000547 RID: 1351
	[AddComponentMenu("")]
	[RequireComponent(typeof(GUIText))]
	public sealed class DirectInputJoystickElementIdentifier : MonoBehaviour
	{
		// Token: 0x060036B4 RID: 14004 RVA: 0x000BB120 File Offset: 0x000B9320
		public void Awake()
		{
			if (!this.yNsxHYftTMsQytarBbuuVDTDNsAf())
			{
				return;
			}
			if (base.transform.position != Vector3.zero)
			{
				base.transform.position = Vector3.zero;
			}
			this.gIiQVGwALfCnaLllScpPzvQHthwX = (sDhSoBMwkZfQWoCQcGBWjPdebVsz.fNreHNkrELAoNGLLGKLBvHBsUsBN("Rewired_Windows", "DirectInput") as IElementIdentifierTool);
			if (this.gIiQVGwALfCnaLllScpPzvQHthwX == null)
			{
				Logger.LogError("DirectInput Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
				return;
			}
			this.gIiQVGwALfCnaLllScpPzvQHthwX.Initialize(GUIText.CreateLogger(base.gameObject));
		}

		// Token: 0x060036B5 RID: 14005 RVA: 0x0002AA5B File Offset: 0x00028C5B
		public void Start()
		{
			if (this.gIiQVGwALfCnaLllScpPzvQHthwX != null)
			{
				this.gIiQVGwALfCnaLllScpPzvQHthwX.Start();
			}
		}

		// Token: 0x060036B6 RID: 14006 RVA: 0x0002AA70 File Offset: 0x00028C70
		public void Update()
		{
			if (this.gIiQVGwALfCnaLllScpPzvQHthwX != null)
			{
				this.gIiQVGwALfCnaLllScpPzvQHthwX.Update();
			}
		}

		// Token: 0x060036B7 RID: 14007 RVA: 0x0002AA85 File Offset: 0x00028C85
		public void OnDestroy()
		{
			if (this.gIiQVGwALfCnaLllScpPzvQHthwX != null)
			{
				this.gIiQVGwALfCnaLllScpPzvQHthwX.OnDestroy();
			}
			this.gIiQVGwALfCnaLllScpPzvQHthwX = null;
		}

		// Token: 0x060036B8 RID: 14008 RVA: 0x000BB1A0 File Offset: 0x000B93A0
		private bool yNsxHYftTMsQytarBbuuVDTDNsAf()
		{
			InputManager_Base[] array = (InputManager_Base[])Object.FindObjectsOfType(typeof(InputManager_Base));
			if (array == null || array.Length == 0)
			{
				Logger.LogError("No active Rewired Input Manager was found in the scene! You must create a Rewired Input Manager for the tool to function.");
				return false;
			}
			return true;
		}

		// Token: 0x04001CAF RID: 7343
		private IElementIdentifierTool gIiQVGwALfCnaLllScpPzvQHthwX;
	}
}
