using System;
using System.Runtime.CompilerServices;
using Rewired;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.HighDefinition;

// Token: 0x0200015B RID: 347
public class GameplaySettings : MonoBehaviour
{
	// Token: 0x0600057F RID: 1407 RVA: 0x00025908 File Offset: 0x00023B08
	private void Start()
	{
		this.player = ReInput.players.GetPlayer(this.playerId);
		this.clickTrigger = EventSystem.current.currentSelectedGameObject;
		this.LoadPlayerSettingsData();
		if (this.cameraData == null)
		{
			this.cameraData = base.GetComponent<HDAdditionalCameraData>();
		}
		this.UpdateAntiAliasingQuality(QualitySettings.GetQualityLevel());
	}

	// Token: 0x06000580 RID: 1408 RVA: 0x00025968 File Offset: 0x00023B68
	private void Update()
	{
		float axis = this.player.GetAxis("LeftStickX");
		if (EventSystem.current.currentSelectedGameObject == this.MainButtons.Volume)
		{
			if (this.player.GetButton("D-PadLeft") || axis < -0.5f)
			{
				this.MenuSelectors.Volume.mainSlider.value -= 50f * Time.unscaledDeltaTime;
				this.UpdateVolumeLevel();
			}
			if (this.player.GetButton("D-PadRight") || axis > 0.5f)
			{
				this.MenuSelectors.Volume.mainSlider.value += 50f * Time.unscaledDeltaTime;
				this.UpdateVolumeLevel();
			}
		}
		if (EventSystem.current.currentSelectedGameObject == this.MainButtons.QualityLevel)
		{
			if (this.player.GetButtonDown("D-PadLeft") || (axis < -0.5f && this.<Update>g__CanUseStick|14_0()))
			{
				this.MenuSelectors.QualityLevel.PreviousClick();
				this.UpdateSettingsValues();
				this.lastJoystickInputTime = Time.unscaledTime;
			}
			if (this.player.GetButtonDown("D-PadRight") || (axis > 0.5f && this.<Update>g__CanUseStick|14_0()))
			{
				this.MenuSelectors.QualityLevel.ForwardClick();
				this.UpdateSettingsValues();
				this.lastJoystickInputTime = Time.unscaledTime;
			}
		}
		if (EventSystem.current.currentSelectedGameObject == this.MainButtons.Resolution)
		{
			if (this.player.GetButtonDown("D-PadLeft") || (axis < -0.5f && this.<Update>g__CanUseStick|14_0()))
			{
				this.MenuSelectors.Resolution.PreviousClick();
				this.UpdateSettingsValues();
				this.lastJoystickInputTime = Time.unscaledTime;
			}
			if (this.player.GetButtonDown("D-PadRight") || (axis > 0.5f && this.<Update>g__CanUseStick|14_0()))
			{
				this.MenuSelectors.Resolution.ForwardClick();
				this.UpdateSettingsValues();
				this.lastJoystickInputTime = Time.unscaledTime;
			}
		}
		if (EventSystem.current.currentSelectedGameObject == this.MainButtons.DisplayMode)
		{
			if (this.player.GetButtonDown("D-PadLeft") || (axis < -0.5f && this.<Update>g__CanUseStick|14_0()))
			{
				this.MenuSelectors.DisplayMode.PreviousClick();
				this.UpdateSettingsValues();
				this.lastJoystickInputTime = Time.unscaledTime;
			}
			if (this.player.GetButtonDown("D-PadRight") || (axis > 0.5f && this.<Update>g__CanUseStick|14_0()))
			{
				this.MenuSelectors.DisplayMode.ForwardClick();
				this.UpdateSettingsValues();
				this.lastJoystickInputTime = Time.unscaledTime;
			}
		}
		if (EventSystem.current.currentSelectedGameObject == this.MainButtons.VSync)
		{
			if (this.player.GetButtonDown("D-PadLeft") || (axis < -0.5f && this.<Update>g__CanUseStick|14_0()))
			{
				this.MenuSelectors.VSync.PreviousClick();
				this.UpdateSettingsValues();
				this.lastJoystickInputTime = Time.unscaledTime;
			}
			if (this.player.GetButtonDown("D-PadRight") || (axis > 0.5f && this.<Update>g__CanUseStick|14_0()))
			{
				this.MenuSelectors.VSync.ForwardClick();
				this.UpdateSettingsValues();
				this.lastJoystickInputTime = Time.unscaledTime;
			}
		}
		if (EventSystem.current.currentSelectedGameObject == this.MainButtons.RampAssist)
		{
			if (this.player.GetButtonDown("D-PadLeft") || (axis < -0.5f && this.<Update>g__CanUseStick|14_0()))
			{
				this.MenuSelectors.RampAssist.PreviousClick();
				this.UpdateSettingsValues();
				this.lastJoystickInputTime = Time.unscaledTime;
			}
			if (this.player.GetButtonDown("D-PadRight") || (axis > 0.5f && this.<Update>g__CanUseStick|14_0()))
			{
				this.MenuSelectors.RampAssist.ForwardClick();
				this.UpdateSettingsValues();
				this.lastJoystickInputTime = Time.unscaledTime;
			}
		}
		if (this.clickTrigger != EventSystem.current.currentSelectedGameObject)
		{
			this.mainMenuSounds.mainClick.Play();
			this.clickTrigger = EventSystem.current.currentSelectedGameObject;
		}
	}

	// Token: 0x06000581 RID: 1409 RVA: 0x00025DA4 File Offset: 0x00023FA4
	public void UpdateSettingsValues()
	{
		if (this.MenuSelectors.Resolution.index == 0)
		{
			this.settingsValues.screenWidth = 1280;
			this.settingsValues.screenHeight = 720;
		}
		if (this.MenuSelectors.Resolution.index == 1)
		{
			this.settingsValues.screenWidth = 1920;
			this.settingsValues.screenHeight = 1080;
		}
		if (this.MenuSelectors.Resolution.index == 2)
		{
			this.settingsValues.screenWidth = 2560;
			this.settingsValues.screenHeight = 1440;
		}
		if (this.MenuSelectors.Resolution.index == 3)
		{
			this.settingsValues.screenWidth = 3840;
			this.settingsValues.screenHeight = 2160;
		}
		if (this.MenuSelectors.QualityLevel.index == 0)
		{
			this.settingsValues.qualityLevel = 0;
		}
		if (this.MenuSelectors.QualityLevel.index == 1)
		{
			this.settingsValues.qualityLevel = 1;
		}
		if (this.MenuSelectors.QualityLevel.index == 2)
		{
			this.settingsValues.qualityLevel = 2;
		}
		if (this.MenuSelectors.DisplayMode.index == 0)
		{
			this.settingsValues.fullscreen = 0;
			this.settingsValues.fullScreenBool = false;
		}
		if (this.MenuSelectors.DisplayMode.index == 1)
		{
			this.settingsValues.fullscreen = 1;
			this.settingsValues.fullScreenBool = true;
		}
		if (this.MenuSelectors.RampAssist.index == 0)
		{
			this.settingsValues.rampAssist = 0;
		}
		if (this.MenuSelectors.RampAssist.index == 1)
		{
			this.settingsValues.rampAssist = 1;
		}
		if (this.MenuSelectors.VSync.index == 0)
		{
			this.settingsValues.vSync = 0;
		}
		if (this.MenuSelectors.VSync.index == 1)
		{
			this.settingsValues.vSync = 1;
		}
		if (this.MenuSelectors.VSync.index == 2)
		{
			this.settingsValues.vSync = 2;
		}
		if (this.MenuSelectors.VSync.index == 3)
		{
			this.settingsValues.vSync = 3;
		}
		this.settingsChanged = true;
		this.MainButtons.applyButton.interactable = true;
		this.UpdateVolumeLevel();
	}

	// Token: 0x06000582 RID: 1410 RVA: 0x00026004 File Offset: 0x00024204
	public void UpdateVolumeLevel()
	{
		this.settingsValues.mainVolume = this.MenuSelectors.Volume.mainSlider.value;
		if (!this.settingsChanged)
		{
			this.settingsChanged = true;
			this.MainButtons.applyButton.interactable = true;
		}
	}

	// Token: 0x06000583 RID: 1411 RVA: 0x00026054 File Offset: 0x00024254
	public void ApplySettings()
	{
		Screen.SetResolution(this.settingsValues.screenWidth, this.settingsValues.screenHeight, this.settingsValues.fullScreenBool);
		AudioListener.volume = this.settingsValues.mainVolume / 100f;
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
		if (this.settingsValues.qualityLevel == 0)
		{
			QualitySettings.SetQualityLevel(0, true);
		}
		if (this.settingsValues.qualityLevel == 1)
		{
			QualitySettings.SetQualityLevel(1, true);
		}
		if (this.settingsValues.qualityLevel == 2)
		{
			QualitySettings.SetQualityLevel(2, true);
		}
		if (this.settingsValues.rampAssist == 0)
		{
			this.rampDirection.autoAir = true;
		}
		if (this.settingsValues.rampAssist == 1)
		{
			this.rampDirection.autoAir = false;
		}
		if (this.settingsChanged)
		{
			this.settingsApplied();
			this.settingsChanged = false;
		}
	}

	// Token: 0x06000584 RID: 1412 RVA: 0x00026186 File Offset: 0x00024386
	private void settingsApplied()
	{
		EventSystem.current.SetSelectedGameObject(this.MainButtons.QualityLevel);
		this.MainButtons.applyButton.interactable = false;
		this.SavePlayerSettingsData();
		this.UpdateAntiAliasingQuality(QualitySettings.GetQualityLevel());
	}

	// Token: 0x06000585 RID: 1413 RVA: 0x000261C0 File Offset: 0x000243C0
	public void SavePlayerSettingsData()
	{
		PlayerPrefs.SetInt("V0.5SaveSystem", 1);
		PlayerPrefs.SetInt("PlayerScreenWidth", this.settingsValues.screenWidth);
		PlayerPrefs.SetInt("PlayerScreenHeight", this.settingsValues.screenHeight);
		PlayerPrefs.SetInt("PlayerQualityLevel", this.settingsValues.qualityLevel);
		PlayerPrefs.SetInt("PlayerVSYNC", this.settingsValues.vSync);
		PlayerPrefs.SetInt("PlayerFullscreen", this.settingsValues.fullscreen);
		PlayerPrefs.SetFloat("PlayerMainVolume", this.settingsValues.mainVolume);
		PlayerPrefs.SetInt("PlayerRampAssist", this.settingsValues.rampAssist);
	}

	// Token: 0x06000586 RID: 1414 RVA: 0x0002626C File Offset: 0x0002446C
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
			this.settingsValues.menuVolume = PlayerPrefs.GetFloat("PlayerMenuVolume");
			this.settingsValues.vibration = PlayerPrefs.GetInt("PlayerVibration");
			this.settingsValues.rampAssist = PlayerPrefs.GetInt("PlayerRampAssist");
			if (this.settingsValues.fullscreen == 0)
			{
				this.settingsValues.fullScreenBool = false;
			}
			if (this.settingsValues.fullscreen == 1)
			{
				this.settingsValues.fullScreenBool = true;
			}
			this.mainMenuSounds.mainClick.volume = this.settingsValues.menuVolume / 2f / 100f;
			if (this.settingsValues.vibration == 0)
			{
				this.Vibration.allowVibration = false;
			}
			if (this.settingsValues.vibration == 1)
			{
				this.Vibration.allowVibration = true;
			}
			if (this.settingsValues.rampAssist == 0)
			{
				this.rampDirection.autoAir = true;
			}
			if (this.settingsValues.rampAssist == 1)
			{
				this.rampDirection.autoAir = false;
			}
		}
	}

	// Token: 0x06000587 RID: 1415 RVA: 0x00026408 File Offset: 0x00024608
	public void UpdateUI()
	{
		if (this.settingsValues.screenHeight == 720)
		{
			this.MenuSelectors.Resolution.index = 0;
		}
		if (this.settingsValues.screenHeight == 1080)
		{
			this.MenuSelectors.Resolution.index = 1;
		}
		if (this.settingsValues.screenHeight == 1440)
		{
			this.MenuSelectors.Resolution.index = 2;
		}
		if (this.settingsValues.screenHeight == 2160)
		{
			this.MenuSelectors.Resolution.index = 3;
		}
		this.MenuSelectors.QualityLevel.index = this.settingsValues.qualityLevel;
		this.MenuSelectors.DisplayMode.index = this.settingsValues.fullscreen;
		this.MenuSelectors.VSync.index = this.settingsValues.vSync;
		this.MenuSelectors.Volume.mainSlider.value = this.settingsValues.mainVolume;
		this.MenuSelectors.RampAssist.index = this.settingsValues.rampAssist;
		this.MenuSelectors.Resolution.UpdateUI();
		this.MenuSelectors.QualityLevel.UpdateUI();
		this.MenuSelectors.DisplayMode.UpdateUI();
		this.MenuSelectors.VSync.UpdateUI();
		this.MenuSelectors.RampAssist.UpdateUI();
	}

	// Token: 0x06000588 RID: 1416 RVA: 0x00026580 File Offset: 0x00024780
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

	// Token: 0x0600058A RID: 1418 RVA: 0x0002660A File Offset: 0x0002480A
	[CompilerGenerated]
	private bool <Update>g__CanUseStick|14_0()
	{
		return Time.unscaledTime - this.lastJoystickInputTime > this.joystickInputCooldown;
	}

	// Token: 0x040008D1 RID: 2257
	public int playerId;

	// Token: 0x040008D2 RID: 2258
	public HDAdditionalCameraData cameraData;

	// Token: 0x040008D3 RID: 2259
	private Player player;

	// Token: 0x040008D4 RID: 2260
	public GameSettingsButtons MainButtons;

	// Token: 0x040008D5 RID: 2261
	public GameSettingsSelectors MenuSelectors;

	// Token: 0x040008D6 RID: 2262
	public GameSettingsValues settingsValues;

	// Token: 0x040008D7 RID: 2263
	public GameMenuSounds mainMenuSounds;

	// Token: 0x040008D8 RID: 2264
	public Vibration Vibration;

	// Token: 0x040008D9 RID: 2265
	public RampDirection rampDirection;

	// Token: 0x040008DA RID: 2266
	private bool settingsChanged;

	// Token: 0x040008DB RID: 2267
	private GameObject clickTrigger;

	// Token: 0x040008DC RID: 2268
	private float joystickInputCooldown = 0.5f;

	// Token: 0x040008DD RID: 2269
	private float lastJoystickInputTime = -1f;
}
