using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

// Token: 0x0200020D RID: 525
public class ScreenshotHandler : MonoBehaviour
{
	// Token: 0x0600083C RID: 2108 RVA: 0x0003AE2D File Offset: 0x0003902D
	private void Start()
	{
		this.folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ScooterFlow", "CustomScooterPhotos");
		if (!Directory.Exists(this.folderPath))
		{
			Directory.CreateDirectory(this.folderPath);
		}
	}

	// Token: 0x0600083D RID: 2109 RVA: 0x0003AE63 File Offset: 0x00039063
	public void SendCustomScooterToDiscord()
	{
		if (!this.antiRepeat && this.mainMenu.references.customizeMenu)
		{
			base.StartCoroutine(this.CaptureScreenshot());
			this.antiRepeat = true;
		}
	}

	// Token: 0x0600083E RID: 2110 RVA: 0x0003AE93 File Offset: 0x00039093
	private IEnumerator CaptureScreenshot()
	{
		yield return new WaitForEndOfFrame();
		int width = this.resolution;
		int height = this.resolution;
		this.screenshotPath = Path.Combine(this.folderPath, "Screenshot_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png");
		this.CaptureCameraScreenshot(this.targetCamera, this.screenshotPath, width, height);
		yield return new WaitUntil(() => File.Exists(this.screenshotPath));
		base.StartCoroutine(this.UploadToDiscord(this.screenshotPath, ""));
		yield break;
	}

	// Token: 0x0600083F RID: 2111 RVA: 0x0003AEA4 File Offset: 0x000390A4
	private void CaptureCameraScreenshot(Camera camera, string path, int width, int height)
	{
		RenderTexture renderTexture = new RenderTexture(width, height, 32);
		renderTexture.antiAliasing = 4;
		camera.targetTexture = renderTexture;
		Texture2D texture2D = new Texture2D(width, height, TextureFormat.ARGB32, false);
		camera.Render();
		RenderTexture.active = renderTexture;
		texture2D.ReadPixels(new Rect(0f, 0f, (float)width, (float)height), 0, 0);
		camera.targetTexture = null;
		RenderTexture.active = null;
		Object.Destroy(renderTexture);
		byte[] bytes = texture2D.EncodeToPNG();
		File.WriteAllBytes(path, bytes);
		Object.Destroy(texture2D);
	}

	// Token: 0x06000840 RID: 2112 RVA: 0x0003AF22 File Offset: 0x00039122
	private IEnumerator UploadToDiscord(string filePath, string message)
	{
		byte[] contents = File.ReadAllBytes(filePath);
		WWWForm wwwform = new WWWForm();
		wwwform.AddField("content", message);
		wwwform.AddBinaryData("file", contents, Path.GetFileName(filePath), "image/png");
		using (UnityWebRequest www = UnityWebRequest.Post(this.discordWebhookURL, wwwform))
		{
			yield return www.SendWebRequest();
			if (www.result != UnityWebRequest.Result.Success)
			{
				Debug.LogError("Error uploading: " + www.error);
			}
			else
			{
				Debug.Log("Upload complete!");
			}
		}
		UnityWebRequest www = null;
		yield break;
		yield break;
	}

	// Token: 0x04000E7D RID: 3709
	public MainMenuLogic mainMenu;

	// Token: 0x04000E7E RID: 3710
	public string discordWebhookURL;

	// Token: 0x04000E7F RID: 3711
	public Camera targetCamera;

	// Token: 0x04000E80 RID: 3712
	private string screenshotPath;

	// Token: 0x04000E81 RID: 3713
	private string folderPath;

	// Token: 0x04000E82 RID: 3714
	public int resolution;

	// Token: 0x04000E83 RID: 3715
	private bool antiRepeat;
}
