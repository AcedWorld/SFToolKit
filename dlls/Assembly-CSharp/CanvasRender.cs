using System;
using System.IO;
using Steamworks;
using UnityEngine;

// Token: 0x020001CC RID: 460
public class CanvasRender : MonoBehaviour
{
	// Token: 0x0600072C RID: 1836 RVA: 0x000364EC File Offset: 0x000346EC
	private void Start()
	{
		if (SteamManager.Initialized)
		{
			string personaName = SteamFriends.GetPersonaName();
			this._canvasAlpha = personaName;
		}
		this.Onload();
	}

	// Token: 0x0600072D RID: 1837 RVA: 0x00036513 File Offset: 0x00034713
	private void Onload()
	{
		if (!(this._canvasAlpha == ""))
		{
			this.DisplayCanvas();
		}
	}

	// Token: 0x0600072E RID: 1838 RVA: 0x0001A692 File Offset: 0x00018892
	public void CloseApp()
	{
		Application.Quit();
	}

	// Token: 0x0600072F RID: 1839 RVA: 0x00036530 File Offset: 0x00034730
	private void DisplayCanvas()
	{
		this.path1 = Application.dataPath;
		this.path2 = this.path1.Replace("/ScooterFlow_Data", "");
		this.path3 = this.path2 + "/steam_appid.txt";
		if (File.Exists(this.path3))
		{
			this.path4 = File.ReadAllText(this.path3);
			if (this.path4 != this.CanvasNumber)
			{
				Application.Quit();
				return;
			}
			this.applySettingsOnStart._loadScene = true;
		}
	}

	// Token: 0x04000CC8 RID: 3272
	public string _canvasAlpha;

	// Token: 0x04000CC9 RID: 3273
	public ApplySettingsOnStart applySettingsOnStart;

	// Token: 0x04000CCA RID: 3274
	public string CanvasNumber;

	// Token: 0x04000CCB RID: 3275
	private string path1;

	// Token: 0x04000CCC RID: 3276
	private string path2;

	// Token: 0x04000CCD RID: 3277
	private string path3;

	// Token: 0x04000CCE RID: 3278
	private string path4;
}
