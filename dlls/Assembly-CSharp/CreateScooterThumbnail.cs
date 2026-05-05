using System;
using System.IO;
using UnityEngine;

// Token: 0x020000BE RID: 190
public class CreateScooterThumbnail : MonoBehaviour
{
	// Token: 0x0600033D RID: 829 RVA: 0x00019837 File Offset: 0x00017A37
	private void Start()
	{
		this.path = Path.Combine(Application.persistentDataPath, "ScooterFlow/MyCustomScooters/");
		if (!Directory.Exists(this.path))
		{
			Directory.CreateDirectory(this.path);
		}
		this.ApplyNewImageOnStart();
	}

	// Token: 0x0600033E RID: 830 RVA: 0x000020BE File Offset: 0x000002BE
	private void Awake()
	{
	}

	// Token: 0x0600033F RID: 831 RVA: 0x00019870 File Offset: 0x00017A70
	public void SaveNewImage()
	{
		if (this.scooterBuilderBrain.customScooterSelected == 1)
		{
			this.SaveCustomScooter1Preview();
			this.customScooters.customScooter1PreviewImage.sprite = this.LoadSprite(this.path + this.customScooters.customScooter1Name + ".png");
			this.customScooters.customScooter1PreviewImage.color = Color.white;
			this.customScooters.CS1Text.gameObject.SetActive(false);
		}
		if (this.scooterBuilderBrain.customScooterSelected == 2)
		{
			this.SaveCustomScooter2Preview();
			this.customScooters.customScooter2PreviewImage.sprite = this.LoadSprite(this.path + this.customScooters.customScooter2Name + ".png");
			this.customScooters.customScooter2PreviewImage.color = Color.white;
			this.customScooters.CS2Text.gameObject.SetActive(false);
		}
		if (this.scooterBuilderBrain.customScooterSelected == 3)
		{
			this.SaveCustomScooter3Preview();
			this.customScooters.customScooter3PreviewImage.sprite = this.LoadSprite(this.path + this.customScooters.customScooter3Name + ".png");
			this.customScooters.customScooter3PreviewImage.color = Color.white;
			this.customScooters.CS3Text.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000340 RID: 832 RVA: 0x000199D0 File Offset: 0x00017BD0
	public void ApplyNewImageOnStart()
	{
		if (PlayerPrefs.HasKey("CustomScooter1Saved") && File.Exists(this.path + this.customScooters.customScooter1Name + ".png"))
		{
			this.customScooters.customScooter1PreviewImage.sprite = this.LoadSprite(this.path + this.customScooters.customScooter1Name + ".png");
			this.customScooters.customScooter1PreviewImage.color = Color.white;
			this.customScooters.CS1Text.gameObject.SetActive(false);
		}
		if (PlayerPrefs.HasKey("CustomScooter2Saved") && File.Exists(this.path + this.customScooters.customScooter2Name + ".png"))
		{
			this.customScooters.customScooter2PreviewImage.sprite = this.LoadSprite(this.path + this.customScooters.customScooter2Name + ".png");
			this.customScooters.customScooter2PreviewImage.color = Color.white;
			this.customScooters.CS2Text.gameObject.SetActive(false);
		}
		if (PlayerPrefs.HasKey("CustomScooter3Saved") && File.Exists(this.path + this.customScooters.customScooter3Name + ".png"))
		{
			this.customScooters.customScooter3PreviewImage.sprite = this.LoadSprite(this.path + this.customScooters.customScooter3Name + ".png");
			this.customScooters.customScooter3PreviewImage.color = Color.white;
			this.customScooters.CS3Text.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000341 RID: 833 RVA: 0x00019B7C File Offset: 0x00017D7C
	private Sprite LoadSprite(string path)
	{
		if (string.IsNullOrEmpty(path))
		{
			return null;
		}
		if (File.Exists(path))
		{
			byte[] data = File.ReadAllBytes(path);
			Texture2D texture2D = new Texture2D(1, 1);
			texture2D.LoadImage(data);
			return Sprite.Create(texture2D, new Rect(0f, 0f, (float)texture2D.width, (float)texture2D.height), new Vector2(0.5f, 0.5f));
		}
		return null;
	}

	// Token: 0x06000342 RID: 834 RVA: 0x00019BE8 File Offset: 0x00017DE8
	private void SaveCustomScooter1Preview()
	{
		RenderTexture renderTexture = new RenderTexture(this.rt.width, this.rt.height, this.rt.depth, RenderTextureFormat.ARGB32, RenderTextureReadWrite.sRGB);
		renderTexture.antiAliasing = this.rt.antiAliasing;
		Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
		this.screenShotCam.targetTexture = renderTexture;
		this.screenShotCam.Render();
		RenderTexture.active = renderTexture;
		texture2D.ReadPixels(new Rect(0f, 0f, (float)renderTexture.width, (float)renderTexture.height), 0, 0);
		texture2D.Apply();
		File.WriteAllBytes(this.path + this.customScooters.customScooter1Name + ".png", texture2D.EncodeToPNG());
		Debug.Log("Saved file to: " + this.path + this.customScooters.customScooter1Name + ".png");
		Object.DestroyImmediate(texture2D);
	}

	// Token: 0x06000343 RID: 835 RVA: 0x00019CDC File Offset: 0x00017EDC
	private void SaveCustomScooter2Preview()
	{
		RenderTexture renderTexture = new RenderTexture(this.rt.width, this.rt.height, this.rt.depth, RenderTextureFormat.ARGB32, RenderTextureReadWrite.sRGB);
		renderTexture.antiAliasing = this.rt.antiAliasing;
		Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
		this.screenShotCam.targetTexture = renderTexture;
		this.screenShotCam.Render();
		RenderTexture.active = renderTexture;
		texture2D.ReadPixels(new Rect(0f, 0f, (float)renderTexture.width, (float)renderTexture.height), 0, 0);
		texture2D.Apply();
		File.WriteAllBytes(this.path + this.customScooters.customScooter2Name + ".png", texture2D.EncodeToPNG());
		Debug.Log("Saved file to: " + this.path + this.customScooters.customScooter2Name + ".png");
		Object.DestroyImmediate(texture2D);
	}

	// Token: 0x06000344 RID: 836 RVA: 0x00019DD0 File Offset: 0x00017FD0
	private void SaveCustomScooter3Preview()
	{
		RenderTexture renderTexture = new RenderTexture(this.rt.width, this.rt.height, this.rt.depth, RenderTextureFormat.ARGB32, RenderTextureReadWrite.sRGB);
		renderTexture.antiAliasing = this.rt.antiAliasing;
		Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
		this.screenShotCam.targetTexture = renderTexture;
		this.screenShotCam.Render();
		RenderTexture.active = renderTexture;
		texture2D.ReadPixels(new Rect(0f, 0f, (float)renderTexture.width, (float)renderTexture.height), 0, 0);
		texture2D.Apply();
		File.WriteAllBytes(this.path + this.customScooters.customScooter3Name + ".png", texture2D.EncodeToPNG());
		Debug.Log("Saved file to: " + this.path + this.customScooters.customScooter3Name + ".png");
		Object.DestroyImmediate(texture2D);
	}

	// Token: 0x04000493 RID: 1171
	public Camera screenShotCam;

	// Token: 0x04000494 RID: 1172
	public RenderTexture rt;

	// Token: 0x04000495 RID: 1173
	public ScooterBuilderBrain scooterBuilderBrain;

	// Token: 0x04000496 RID: 1174
	public CustomScooterImageDetails customScooters;

	// Token: 0x04000497 RID: 1175
	private string path;
}
