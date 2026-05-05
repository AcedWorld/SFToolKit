using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Rewired
{
	// Token: 0x02000272 RID: 626
	[AddComponentMenu("Rewired/Input Manager")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class InputManager : InputManager_Base
	{
		// Token: 0x06000BE3 RID: 3043 RVA: 0x00043EC8 File Offset: 0x000420C8
		protected override void OnInitialized()
		{
			this.SubscribeEvents();
		}

		// Token: 0x06000BE4 RID: 3044 RVA: 0x00043ED0 File Offset: 0x000420D0
		protected override void OnDeinitialized()
		{
			this.UnsubscribeEvents();
		}

		// Token: 0x06000BE5 RID: 3045 RVA: 0x00043ED8 File Offset: 0x000420D8
		protected override void DetectPlatform()
		{
			this.scriptingBackend = ScriptingBackend.Mono;
			this.scriptingAPILevel = ScriptingAPILevel.Net20;
			this.editorPlatform = EditorPlatform.None;
			this.platform = Platform.Unknown;
			this.webplayerPlatform = WebplayerPlatform.None;
			this.isEditor = false;
			if (SystemInfo.deviceName == null)
			{
				string empty = string.Empty;
			}
			if (SystemInfo.deviceModel == null)
			{
				string empty2 = string.Empty;
			}
			this.platform = Platform.Windows;
			this.scriptingBackend = ScriptingBackend.Mono;
			this.scriptingAPILevel = ScriptingAPILevel.NetStandard20;
		}

		// Token: 0x06000BE6 RID: 3046 RVA: 0x000020BE File Offset: 0x000002BE
		protected override void CheckRecompile()
		{
		}

		// Token: 0x06000BE7 RID: 3047 RVA: 0x00043F3E File Offset: 0x0004213E
		protected override IExternalTools GetExternalTools()
		{
			return new ExternalTools();
		}

		// Token: 0x06000BE8 RID: 3048 RVA: 0x00043F45 File Offset: 0x00042145
		private bool CheckDeviceName(string searchPattern, string deviceName, string deviceModel)
		{
			return Regex.IsMatch(deviceName, searchPattern, RegexOptions.IgnoreCase) || Regex.IsMatch(deviceModel, searchPattern, RegexOptions.IgnoreCase);
		}

		// Token: 0x06000BE9 RID: 3049 RVA: 0x00043F5B File Offset: 0x0004215B
		private void SubscribeEvents()
		{
			this.UnsubscribeEvents();
			SceneManager.sceneLoaded += this.OnSceneLoaded;
		}

		// Token: 0x06000BEA RID: 3050 RVA: 0x00043F74 File Offset: 0x00042174
		private void UnsubscribeEvents()
		{
			SceneManager.sceneLoaded -= this.OnSceneLoaded;
		}

		// Token: 0x06000BEB RID: 3051 RVA: 0x00043F87 File Offset: 0x00042187
		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			base.OnSceneLoaded();
		}

		// Token: 0x0400120A RID: 4618
		private bool ignoreRecompile;
	}
}
