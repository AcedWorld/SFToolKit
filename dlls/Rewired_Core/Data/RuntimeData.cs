using System;
using System.Collections.Generic;
using Rewired.Platforms;
using UnityEngine;

namespace Rewired.Data
{
	// Token: 0x02000255 RID: 597
	public class RuntimeData : ScriptableObject
	{
		// Token: 0x06001B44 RID: 6980 RVA: 0x0001602F File Offset: 0x0001422F
		public void SetPlatform(Platform platform, WebplayerPlatform webplayerPlatform, EditorPlatform editorPlatform, List<TextAsset> libraries)
		{
			this.libraries = libraries;
			this.platform = platform;
			this.webplayerPlatform = webplayerPlatform;
			this.editorPlatform = editorPlatform;
		}

		// Token: 0x04000F96 RID: 3990
		[CustomObfuscation(rename = false)]
		public Platform platform;

		// Token: 0x04000F97 RID: 3991
		[CustomObfuscation(rename = false)]
		public WebplayerPlatform webplayerPlatform;

		// Token: 0x04000F98 RID: 3992
		[CustomObfuscation(rename = false)]
		public EditorPlatform editorPlatform;

		// Token: 0x04000F99 RID: 3993
		[CustomObfuscation(rename = false)]
		public List<TextAsset> libraries;
	}
}
