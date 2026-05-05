using System;
using System.IO;
using UnityEngine;

// Token: 0x020001BF RID: 447
public class ScreenshotManager : MonoBehaviour
{
	// Token: 0x060006F1 RID: 1777 RVA: 0x00033DD1 File Offset: 0x00031FD1
	private void Start()
	{
		if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "/ScooterFlow"))
		{
			Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "/ScooterFlow");
		}
	}

	// Token: 0x060006F2 RID: 1778 RVA: 0x00033E04 File Offset: 0x00032004
	public void GameplayScreenshot()
	{
		ScreenCapture.CaptureScreenshot(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "/ScooterFlow/ScreenshotsGameplay " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".png");
	}

	// Token: 0x060006F3 RID: 1779 RVA: 0x00033E3E File Offset: 0x0003203E
	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.RightShift))
		{
			this.GameplayScreenshot();
			Debug.Log("Screenshot Saved");
			Debug.Log(base.gameObject.name);
		}
	}

	// Token: 0x04000C56 RID: 3158
	public bool FreeCam;
}
