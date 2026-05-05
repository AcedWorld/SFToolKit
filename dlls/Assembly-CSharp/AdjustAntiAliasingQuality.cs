using System;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

// Token: 0x02000115 RID: 277
public class AdjustAntiAliasingQuality : MonoBehaviour
{
	// Token: 0x0600047C RID: 1148 RVA: 0x0001EC42 File Offset: 0x0001CE42
	private void Start()
	{
		if (this.cameraData == null)
		{
			this.cameraData = base.GetComponent<HDAdditionalCameraData>();
		}
		this.UpdateAntiAliasingQuality(QualitySettings.GetQualityLevel());
	}

	// Token: 0x0600047D RID: 1149 RVA: 0x0001EC69 File Offset: 0x0001CE69
	public void OnQualityChange(int qualityLevel)
	{
		this.UpdateAntiAliasingQuality(qualityLevel);
	}

	// Token: 0x0600047E RID: 1150 RVA: 0x0001EC74 File Offset: 0x0001CE74
	private void UpdateAntiAliasingQuality(int qualityLevel)
	{
		switch (qualityLevel)
		{
		case 0:
			this.cameraData.antialiasing = HDAdditionalCameraData.AntialiasingMode.None;
			return;
		case 1:
			this.cameraData.antialiasing = HDAdditionalCameraData.AntialiasingMode.SubpixelMorphologicalAntiAliasing;
			this.cameraData.SMAAQuality = HDAdditionalCameraData.SMAAQualityLevel.Medium;
			return;
		case 2:
			this.cameraData.antialiasing = HDAdditionalCameraData.AntialiasingMode.SubpixelMorphologicalAntiAliasing;
			this.cameraData.SMAAQuality = HDAdditionalCameraData.SMAAQualityLevel.High;
			return;
		default:
			this.cameraData.antialiasing = HDAdditionalCameraData.AntialiasingMode.None;
			return;
		}
	}

	// Token: 0x040006BB RID: 1723
	public HDAdditionalCameraData cameraData;
}
