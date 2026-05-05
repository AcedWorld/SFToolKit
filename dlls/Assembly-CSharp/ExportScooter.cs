using System;
using System.IO;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x02000202 RID: 514
public class ExportScooter : MonoBehaviour
{
	// Token: 0x06000812 RID: 2066 RVA: 0x00039FB8 File Offset: 0x000381B8
	private void Start()
	{
		this.cheatCode = new string[]
		{
			"e",
			"x",
			"p",
			"o",
			"r",
			"t"
		};
		this.index = 0;
		string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ScooterFlow", "CustomScooters");
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}
	}

	// Token: 0x06000813 RID: 2067 RVA: 0x0003A030 File Offset: 0x00038230
	private void Update()
	{
		if (Input.anyKeyDown)
		{
			if (Input.GetKeyDown(this.cheatCode[this.index]))
			{
				this.index++;
			}
			else
			{
				this.index = 0;
			}
		}
		if (this.index == this.cheatCode.Length)
		{
			this.ShowExportPanel();
			Debug.Log("Exported Scooter");
			this.index = 0;
		}
		if (EventSystem.current == this.ExportScooterInputField)
		{
			Debug.Log("Worked");
			if (Input.GetKeyDown(KeyCode.KeypadEnter))
			{
				this.customScooterName = this.inputField.inputText.text;
				this.ExportCustomScooter();
			}
		}
	}

	// Token: 0x06000814 RID: 2068 RVA: 0x0003A0DA File Offset: 0x000382DA
	public void ShowExportPanel()
	{
		this.ExportScooterPanel.alpha = 1f;
		this.ExportScooterPanel.interactable = true;
		EventSystem.current.SetSelectedGameObject(this.ExportScooterInputField);
	}

	// Token: 0x06000815 RID: 2069 RVA: 0x0003A108 File Offset: 0x00038308
	public void ExportCustomScooter()
	{
		this.exportableScooter.DeckName = this.scooterBuilderBrain.customScooter1.DeckName;
		this.exportableScooter.BarsName = this.scooterBuilderBrain.customScooter1.BarsName;
		this.exportableScooter.ForksName = this.scooterBuilderBrain.customScooter1.ForksName;
		this.exportableScooter.ClampName = this.scooterBuilderBrain.customScooter1.ClampName;
		this.exportableScooter.FrontWheelName = this.scooterBuilderBrain.customScooter1.FrontWheelName;
		this.exportableScooter.RearWheelName = this.scooterBuilderBrain.customScooter1.RearWheelName;
		this.exportableScooter.GripsName = this.scooterBuilderBrain.customScooter1.GripsName;
		this.exportableScooter.BarEndsName = this.scooterBuilderBrain.customScooter1.BarEndsName;
		this.exportableScooter.GripTapeName = this.scooterBuilderBrain.customScooter1.GripTapeName;
		this.exportableScooter.PegsName = this.scooterBuilderBrain.customScooter1.PegsName;
		this.exportableScooter.HeadsetName = this.scooterBuilderBrain.customScooter1.HeadsetName;
		this.exportableScooter.pegOption = this.scooterBuilderBrain.customScooter1.pegOption;
		string text = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ScooterFlow", "CustomScooters"), this.customScooterName);
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		using (StreamWriter streamWriter = new StreamWriter(Path.Combine(text, "CustomScooter.txt")))
		{
			streamWriter.WriteLine("DeckName=" + this.exportableScooter.DeckName);
			streamWriter.WriteLine("BarsName=" + this.exportableScooter.BarsName);
			streamWriter.WriteLine("ForksName=" + this.exportableScooter.ForksName);
			streamWriter.WriteLine("ClampName=" + this.exportableScooter.ClampName);
			streamWriter.WriteLine("FrontWheelName=" + this.exportableScooter.FrontWheelName);
			streamWriter.WriteLine("RearWheelName=" + this.exportableScooter.RearWheelName);
			streamWriter.WriteLine("GripsName=" + this.exportableScooter.GripsName);
			streamWriter.WriteLine("BarEndsName=" + this.exportableScooter.BarEndsName);
			streamWriter.WriteLine("GripTapeName=" + this.exportableScooter.GripTapeName);
			streamWriter.WriteLine("PegsName=" + this.exportableScooter.PegsName);
			streamWriter.WriteLine("HeadsetName=" + this.exportableScooter.HeadsetName);
			streamWriter.WriteLine("pegOption=" + this.exportableScooter.pegOption.ToString());
			string path = Path.Combine(text, "CustomScooter.png");
			this.CaptureCameraScreenshot(this.scooterScreenshotCamera, path, 1000, 1000);
		}
	}

	// Token: 0x06000816 RID: 2070 RVA: 0x0003A430 File Offset: 0x00038630
	private void CaptureCameraScreenshot(Camera camera, string path, int width, int height)
	{
		RenderTexture renderTexture = new RenderTexture(width, height, 24);
		camera.targetTexture = renderTexture;
		Texture2D texture2D = new Texture2D(width, height, TextureFormat.RGB24, false);
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

	// Token: 0x04000E27 RID: 3623
	public string customScooterName;

	// Token: 0x04000E28 RID: 3624
	public Camera scooterScreenshotCamera;

	// Token: 0x04000E29 RID: 3625
	public ScooterBuilderBrain scooterBuilderBrain;

	// Token: 0x04000E2A RID: 3626
	public ExportableScooter exportableScooter;

	// Token: 0x04000E2B RID: 3627
	public CanvasGroup ExportScooterPanel;

	// Token: 0x04000E2C RID: 3628
	public GameObject ExportScooterInputField;

	// Token: 0x04000E2D RID: 3629
	public CustomInputField inputField;

	// Token: 0x04000E2E RID: 3630
	private int index;

	// Token: 0x04000E2F RID: 3631
	private string[] cheatCode;

	// Token: 0x04000E30 RID: 3632
	private const string parentFolderName = "CustomScooters";
}
