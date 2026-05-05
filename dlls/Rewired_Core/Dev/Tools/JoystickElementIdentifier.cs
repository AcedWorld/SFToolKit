using System;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	// Token: 0x02000548 RID: 1352
	[AddComponentMenu("")]
	[RequireComponent(typeof(GUIText))]
	public sealed class JoystickElementIdentifier : MonoBehaviour
	{
		// Token: 0x060036BA RID: 14010 RVA: 0x000BB1D8 File Offset: 0x000B93D8
		public void Awake()
		{
			if (!this.jThooamEHydGhimpptznalyKCGVaA())
			{
				return;
			}
			if (base.transform.position != Vector3.zero)
			{
				base.transform.position = Vector3.zero;
			}
			if (ReInput.UserData.ConfigVars.alwaysUseUnityInput || ReInput.usingUnityInput)
			{
				this.VrHYnAAvrdcupUyAMvWABBvSEEagA = new rpjCwFVejnUNhmtoFIjprRMLBUAH();
			}
			else
			{
				Platform platform = UnityTools.platform;
				if (UnityTools.isEditor)
				{
					switch (UnityTools.editorPlatform)
					{
					case EditorPlatform.OSX:
						platform = Platform.OSX;
						break;
					case EditorPlatform.Windows:
						platform = Platform.Windows;
						break;
					case EditorPlatform.Linux:
						platform = Platform.Linux;
						break;
					}
				}
				InputSource inputSourceType = ReInput.primaryInputManager.inputSourceType;
				if (inputSourceType == InputSource.Fallback || inputSourceType == InputSource.Fallback_PreConfigured)
				{
					this.VrHYnAAvrdcupUyAMvWABBvSEEagA = new rpjCwFVejnUNhmtoFIjprRMLBUAH();
				}
				if (this.VrHYnAAvrdcupUyAMvWABBvSEEagA == null)
				{
					if (platform <= Platform.WebGL)
					{
						switch (platform)
						{
						case Platform.Windows:
							inputSourceType = ReInput.primaryInputManager.inputSourceType;
							if (inputSourceType != InputSource.DirectInput)
							{
								if (inputSourceType == InputSource.RawInput)
								{
									this.VrHYnAAvrdcupUyAMvWABBvSEEagA = (sDhSoBMwkZfQWoCQcGBWjPdebVsz.fNreHNkrELAoNGLLGKLBvHBsUsBN("Rewired_Windows", "RawInput") as IElementIdentifierTool);
								}
							}
							else
							{
								this.VrHYnAAvrdcupUyAMvWABBvSEEagA = (sDhSoBMwkZfQWoCQcGBWjPdebVsz.fNreHNkrELAoNGLLGKLBvHBsUsBN("Rewired_Windows", "DirectInput") as IElementIdentifierTool);
							}
							break;
						case Platform.WindowsAppStore:
							this.VrHYnAAvrdcupUyAMvWABBvSEEagA = new rpjCwFVejnUNhmtoFIjprRMLBUAH();
							break;
						case Platform.WindowsPhone8:
						case Platform.iOS:
							break;
						case Platform.OSX:
							this.VrHYnAAvrdcupUyAMvWABBvSEEagA = (sDhSoBMwkZfQWoCQcGBWjPdebVsz.fNreHNkrELAoNGLLGKLBvHBsUsBN("Rewired_OSX", "OSX") as IElementIdentifierTool);
							break;
						case Platform.Linux:
							this.VrHYnAAvrdcupUyAMvWABBvSEEagA = (sDhSoBMwkZfQWoCQcGBWjPdebVsz.fNreHNkrELAoNGLLGKLBvHBsUsBN("Rewired_Linux", "Linux") as IElementIdentifierTool);
							break;
						default:
							if (platform == Platform.WebGL)
							{
								this.VrHYnAAvrdcupUyAMvWABBvSEEagA = (sDhSoBMwkZfQWoCQcGBWjPdebVsz.fNreHNkrELAoNGLLGKLBvHBsUsBN("Rewired_WebGL", "WebGL") as IElementIdentifierTool);
							}
							break;
						}
					}
					else if (platform != Platform.WindowsUWP)
					{
						if (platform - Platform.GameCoreXboxOne <= 1)
						{
							this.VrHYnAAvrdcupUyAMvWABBvSEEagA = (sDhSoBMwkZfQWoCQcGBWjPdebVsz.fNreHNkrELAoNGLLGKLBvHBsUsBN("Rewired_GameCore", "GameCore") as IElementIdentifierTool);
						}
					}
					else
					{
						this.VrHYnAAvrdcupUyAMvWABBvSEEagA = (sDhSoBMwkZfQWoCQcGBWjPdebVsz.fNreHNkrELAoNGLLGKLBvHBsUsBN("", "WindowsUWP") as IElementIdentifierTool);
					}
				}
			}
			if (this.VrHYnAAvrdcupUyAMvWABBvSEEagA == null)
			{
				Logger.LogWarning("There was an error initializing the platform tool for the current platform and input source. Unity input will be shown instead.");
				this.VrHYnAAvrdcupUyAMvWABBvSEEagA = new rpjCwFVejnUNhmtoFIjprRMLBUAH();
			}
			this.VrHYnAAvrdcupUyAMvWABBvSEEagA.Initialize(GUIText.CreateLogger(base.gameObject));
		}

		// Token: 0x060036BB RID: 14011 RVA: 0x0002AAA1 File Offset: 0x00028CA1
		public void Start()
		{
			if (this.VrHYnAAvrdcupUyAMvWABBvSEEagA != null)
			{
				this.VrHYnAAvrdcupUyAMvWABBvSEEagA.Start();
			}
		}

		// Token: 0x060036BC RID: 14012 RVA: 0x0002AAB6 File Offset: 0x00028CB6
		public void Update()
		{
			if (this.VrHYnAAvrdcupUyAMvWABBvSEEagA != null)
			{
				this.VrHYnAAvrdcupUyAMvWABBvSEEagA.Update();
			}
		}

		// Token: 0x060036BD RID: 14013 RVA: 0x0002AACB File Offset: 0x00028CCB
		public void OnDestroy()
		{
			if (this.VrHYnAAvrdcupUyAMvWABBvSEEagA != null)
			{
				this.VrHYnAAvrdcupUyAMvWABBvSEEagA.OnDestroy();
			}
			this.VrHYnAAvrdcupUyAMvWABBvSEEagA = null;
		}

		// Token: 0x060036BE RID: 14014 RVA: 0x0002AAE7 File Offset: 0x00028CE7
		private bool jThooamEHydGhimpptznalyKCGVaA()
		{
			if (!ReInput.isReady)
			{
				Logger.LogError("No active Rewired Input Manager was found in the scene! You must create a Rewired Input Manager for the tool to function.");
				return false;
			}
			return true;
		}

		// Token: 0x04001CB0 RID: 7344
		private IElementIdentifierTool VrHYnAAvrdcupUyAMvWABBvSEEagA;
	}
}
