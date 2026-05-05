using System;
using Rewired.Platforms.Custom;
using UnityEngine;

namespace Rewired.Demos.CustomPlatform
{
	// Token: 0x020002DE RID: 734
	public class MyPlatformUnifiedMouseSource : CustomPlatformUnifiedMouseSource
	{
		// Token: 0x17000310 RID: 784
		// (get) Token: 0x06000F70 RID: 3952 RVA: 0x00052207 File Offset: 0x00050407
		public override Vector2 mousePosition
		{
			get
			{
				return Input.mousePosition;
			}
		}

		// Token: 0x06000F71 RID: 3953 RVA: 0x00052214 File Offset: 0x00050414
		protected override void Update()
		{
			base.SetAxisValue(0, Input.GetAxis("MouseAxis1"));
			base.SetAxisValue(1, Input.GetAxis("MouseAxis2"));
			base.SetAxisValue(2, Input.GetAxis("MouseAxis3"));
			base.SetButtonValue(0, Input.GetButton("MouseButton0"));
			base.SetButtonValue(1, Input.GetButton("MouseButton1"));
			base.SetButtonValue(2, Input.GetButton("MouseButton2"));
			base.SetButtonValue(3, Input.GetButton("MouseButton3"));
			base.SetButtonValue(4, Input.GetButton("MouseButton4"));
			base.SetButtonValue(5, Input.GetButton("MouseButton5"));
			base.SetButtonValue(6, Input.GetButton("MouseButton6"));
		}
	}
}
