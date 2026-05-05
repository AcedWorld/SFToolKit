using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000162 RID: 354
public class LoadPlayerScreenSettings : MonoBehaviour
{
	// Token: 0x060005BA RID: 1466 RVA: 0x0002981B File Offset: 0x00027A1B
	private void Start()
	{
		this.LoadPlayerSettingsData();
	}

	// Token: 0x060005BB RID: 1467 RVA: 0x00029824 File Offset: 0x00027A24
	public void LoadPlayerSettingsData()
	{
		if (PlayerPrefs.HasKey("V0.5SaveSystem"))
		{
			this.settingsValues.screenWidth = PlayerPrefs.GetInt("PlayerScreenWidth");
			this.settingsValues.screenHeight = PlayerPrefs.GetInt("PlayerScreenHeight");
			this.settingsValues.qualityLevel = PlayerPrefs.GetInt("PlayerQualityLevel");
			this.settingsValues.vSync = PlayerPrefs.GetInt("PlayerVSYNC");
			this.settingsValues.fullscreen = PlayerPrefs.GetInt("PlayerFullscreen");
			this.settingsValues.mainVolume = PlayerPrefs.GetFloat("PlayerMainVolume");
			if (this.settingsValues.fullscreen == 0)
			{
				this.settingsValues.fullScreenBool = false;
			}
			if (this.settingsValues.fullscreen == 1)
			{
				this.settingsValues.fullScreenBool = true;
			}
			base.StartCoroutine(this.delayToSettings());
			return;
		}
		this.DefaultSettings();
		base.StartCoroutine(this.delayToDefault());
	}

	// Token: 0x060005BC RID: 1468 RVA: 0x00029914 File Offset: 0x00027B14
	public void ApplySettingsOnLoad()
	{
		if (this.settingsValues.vSync == 0)
		{
			QualitySettings.vSyncCount = 0;
			Application.targetFrameRate = 30;
		}
		if (this.settingsValues.vSync == 1)
		{
			QualitySettings.vSyncCount = 0;
			Application.targetFrameRate = 60;
		}
		if (this.settingsValues.vSync == 2)
		{
			QualitySettings.vSyncCount = 1;
		}
		if (this.settingsValues.vSync == 3)
		{
			QualitySettings.vSyncCount = 0;
			Application.targetFrameRate = -1;
		}
		Screen.SetResolution(this.settingsValues.screenWidth, this.settingsValues.screenHeight, this.settingsValues.fullScreenBool);
	}

	// Token: 0x060005BD RID: 1469 RVA: 0x000299AA File Offset: 0x00027BAA
	public void DefaultSettings()
	{
		QualitySettings.SetQualityLevel(2);
		QualitySettings.vSyncCount = 1;
		Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
	}

	// Token: 0x060005BE RID: 1470 RVA: 0x000299C8 File Offset: 0x00027BC8
	private IEnumerator delayToSettings()
	{
		yield return new WaitForSecondsRealtime(0.1f);
		this.ApplySettingsOnLoad();
		yield break;
	}

	// Token: 0x060005BF RID: 1471 RVA: 0x000299D7 File Offset: 0x00027BD7
	private IEnumerator delayToDefault()
	{
		yield return new WaitForSecondsRealtime(0.1f);
		this.DefaultSettings();
		yield break;
	}

	// Token: 0x0400095F RID: 2399
	public GameSettingsValue settingsValues;
}
