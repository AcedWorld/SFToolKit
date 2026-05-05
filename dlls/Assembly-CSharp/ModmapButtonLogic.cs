using System;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000101 RID: 257
public class ModmapButtonLogic : MonoBehaviour
{
	// Token: 0x06000449 RID: 1097 RVA: 0x0001DF1C File Offset: 0x0001C11C
	private void Start()
	{
		this.path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ScooterFlow/ModMaps/Thumbnails/";
		this._modmapBrain = GameObject.Find("ModMap_Brain");
		this.modmapBrain = this._modmapBrain.GetComponent<ModmapBrain>();
		this.button = base.GetComponent<Button>();
		this.button.onClick.AddListener(new UnityAction(this.LoadModMap));
		this.buttonTitle.text = base.gameObject.name;
		this.FindThumbnailImage();
	}

	// Token: 0x0600044A RID: 1098 RVA: 0x0001DFA4 File Offset: 0x0001C1A4
	public void LoadModMap()
	{
		this.modmapBrain.modMapSelected = base.gameObject.name;
		this.modmapBrain.LoadModMap();
	}

	// Token: 0x0600044B RID: 1099 RVA: 0x0001DFC8 File Offset: 0x0001C1C8
	public void FindThumbnailImage()
	{
		if (File.Exists(this.path + base.gameObject.name + ".png"))
		{
			this.ApplyThumbnail();
			this.previewText.SetActive(false);
			this.thumbnailImage.color = Color.white;
		}
	}

	// Token: 0x0600044C RID: 1100 RVA: 0x0001E019 File Offset: 0x0001C219
	public void ApplyThumbnail()
	{
		this.thumbnailImage.sprite = this.LoadSprite(this.path + base.gameObject.name + ".png");
	}

	// Token: 0x0600044D RID: 1101 RVA: 0x0001E048 File Offset: 0x0001C248
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

	// Token: 0x0400063F RID: 1599
	private GameObject _modmapBrain;

	// Token: 0x04000640 RID: 1600
	private ModmapBrain modmapBrain;

	// Token: 0x04000641 RID: 1601
	private Button button;

	// Token: 0x04000642 RID: 1602
	private string path;

	// Token: 0x04000643 RID: 1603
	public TMP_Text buttonTitle;

	// Token: 0x04000644 RID: 1604
	public GameObject previewText;

	// Token: 0x04000645 RID: 1605
	public Image thumbnailImage;
}
