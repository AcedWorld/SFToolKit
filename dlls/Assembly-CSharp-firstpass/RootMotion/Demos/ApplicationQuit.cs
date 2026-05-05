using System;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001C6 RID: 454
	public class ApplicationQuit : MonoBehaviour
	{
		// Token: 0x06000C1F RID: 3103 RVA: 0x0004B79B File Offset: 0x0004999B
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Escape))
			{
				Application.Quit();
			}
		}
	}
}
