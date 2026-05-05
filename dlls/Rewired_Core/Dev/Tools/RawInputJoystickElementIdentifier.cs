using System;
using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	// Token: 0x0200054A RID: 1354
	[AddComponentMenu("")]
	[RequireComponent(typeof(GUIText))]
	public sealed class RawInputJoystickElementIdentifier : MonoBehaviour
	{
		// Token: 0x060036C6 RID: 14022 RVA: 0x000BB484 File Offset: 0x000B9684
		public void Awake()
		{
			if (!this.kICZNySdvWLjOWXrzVxQHIQUiXr())
			{
				return;
			}
			if (base.transform.position != Vector3.zero)
			{
				base.transform.position = Vector3.zero;
			}
			this.kaSlXlSJhVQLojcrbgnhqENMdkWq = (sDhSoBMwkZfQWoCQcGBWjPdebVsz.fNreHNkrELAoNGLLGKLBvHBsUsBN("Rewired_Windows", "RawInput") as IElementIdentifierTool);
			if (this.kaSlXlSJhVQLojcrbgnhqENMdkWq == null)
			{
				Logger.LogError("RawInput Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
				return;
			}
			this.kaSlXlSJhVQLojcrbgnhqENMdkWq.Initialize(GUIText.CreateLogger(base.gameObject));
		}

		// Token: 0x060036C7 RID: 14023 RVA: 0x0002AB43 File Offset: 0x00028D43
		public void Start()
		{
			if (this.kaSlXlSJhVQLojcrbgnhqENMdkWq != null)
			{
				this.kaSlXlSJhVQLojcrbgnhqENMdkWq.Start();
			}
		}

		// Token: 0x060036C8 RID: 14024 RVA: 0x0002AB58 File Offset: 0x00028D58
		public void Update()
		{
			if (this.kaSlXlSJhVQLojcrbgnhqENMdkWq != null)
			{
				this.kaSlXlSJhVQLojcrbgnhqENMdkWq.Update();
			}
		}

		// Token: 0x060036C9 RID: 14025 RVA: 0x0002AB6D File Offset: 0x00028D6D
		public void OnDestroy()
		{
			if (this.kaSlXlSJhVQLojcrbgnhqENMdkWq != null)
			{
				this.kaSlXlSJhVQLojcrbgnhqENMdkWq.OnDestroy();
			}
			this.kaSlXlSJhVQLojcrbgnhqENMdkWq = null;
		}

		// Token: 0x060036CA RID: 14026 RVA: 0x000BB1A0 File Offset: 0x000B93A0
		private bool kICZNySdvWLjOWXrzVxQHIQUiXr()
		{
			InputManager_Base[] array = (InputManager_Base[])Object.FindObjectsOfType(typeof(InputManager_Base));
			if (array == null || array.Length == 0)
			{
				Logger.LogError("No active Rewired Input Manager was found in the scene! You must create a Rewired Input Manager for the tool to function.");
				return false;
			}
			return true;
		}

		// Token: 0x04001CB2 RID: 7346
		private IElementIdentifierTool kaSlXlSJhVQLojcrbgnhqENMdkWq;
	}
}
