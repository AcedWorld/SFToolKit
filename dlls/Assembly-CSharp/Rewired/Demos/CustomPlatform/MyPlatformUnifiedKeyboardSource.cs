using System;
using Rewired.Platforms.Custom;
using UnityEngine;

namespace Rewired.Demos.CustomPlatform
{
	// Token: 0x020002DD RID: 733
	public class MyPlatformUnifiedKeyboardSource : CustomPlatformUnifiedKeyboardSource
	{
		// Token: 0x06000F6C RID: 3948 RVA: 0x000520EC File Offset: 0x000502EC
		protected override void OnInitialize()
		{
			base.OnInitialize();
			CustomPlatformUnifiedKeyboardSource.KeyPropertyMap keyPropertyMap = new CustomPlatformUnifiedKeyboardSource.KeyPropertyMap();
			keyPropertyMap.Set(new CustomPlatformUnifiedKeyboardSource.KeyPropertyMap.Key
			{
				keyCode = KeyboardKeyCode.A,
				label = "[A]"
			});
			keyPropertyMap.Set(new CustomPlatformUnifiedKeyboardSource.KeyPropertyMap.Key[]
			{
				new CustomPlatformUnifiedKeyboardSource.KeyPropertyMap.Key
				{
					keyCode = KeyboardKeyCode.B,
					label = "[B]"
				},
				new CustomPlatformUnifiedKeyboardSource.KeyPropertyMap.Key
				{
					keyCode = KeyboardKeyCode.C,
					label = "[C]"
				},
				new CustomPlatformUnifiedKeyboardSource.KeyPropertyMap.Key
				{
					keyCode = KeyboardKeyCode.D,
					label = "[D]"
				}
			});
			base.keyPropertyMap = keyPropertyMap;
		}

		// Token: 0x06000F6D RID: 3949 RVA: 0x000521AC File Offset: 0x000503AC
		protected override void Update()
		{
			for (int i = 0; i < MyPlatformUnifiedKeyboardSource.keyCodes.Length; i++)
			{
				base.SetKeyValue(MyPlatformUnifiedKeyboardSource.keyCodes[i], Input.GetKey((KeyCode)MyPlatformUnifiedKeyboardSource.keyCodes[i]));
			}
		}

		// Token: 0x04001400 RID: 5120
		private static readonly KeyboardKeyCode[] keyCodes = (KeyboardKeyCode[])Enum.GetValues(typeof(KeyboardKeyCode));
	}
}
