using System;
using System.Runtime.CompilerServices;
using Rewired;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x0200016C RID: 364
public class MainMenuSettings : MonoBehaviour
{
	// Token: 0x060005D6 RID: 1494 RVA: 0x0002A710 File Offset: 0x00028910
	private void Start()
	{
		this.player = ReInput.players.GetPlayer(this.playerId);
		this.clickTrigger = EventSystem.current.currentSelectedGameObject;
		this.LoadPlayerSettingsData();
	}

	// Token: 0x060005D7 RID: 1495 RVA: 0x0002A740 File Offset: 0x00028940
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
		if (EventSystem.current.currentSelectedGameObject == this.MainButtons.trickInputSensitivity)
		{
			if (this.player.GetButton("D-PadLeft") || axis < -0.5f)
			{
				this.MenuSelectors.trickInputSensitivity.mainSlider.value -= 50f * Time.unscaledDeltaTime;
				this.UpdateTrickInputSensitivity();
			}
			if (this.player.GetButton("D-PadRight") || axis > 0.5f)
			{
				this.MenuSelectors.trickInputSensitivity.mainSlider.value += 50f * Time.unscaledDeltaTime;
				this.UpdateTrickInputSensitivity();
			}
		}
		if (EventSystem.current.currentSelectedGameObject == this.MainButtons.MenuVolume)
		{
			if (this.player.GetButton("D-PadLeft") || axis < -0.5f)
			{
				this.MenuSelectors.MenuVolume.mainSlider.value -= 50f * Time.unscaledDeltaTime;
				this.UpdateMenuVolumeLevel();
			}
			if (this.player.GetButton("D-PadRight") || axis > 0.5f)
			{
				this.MenuSelectors.MenuVolume.mainSlider.value += 50f * Time.unscaledDeltaTime;
				this.UpdateMenuVolumeLevel();
			}
		}
		if (EventSystem.current.currentSelectedGameObject == this.MainButtons.QualityLevel)
		{
			if (this.player.GetButtonDown("D-PadLeft") || (axis < -0.5f && this.<Update>g__CanUseStick|13_0()))
			{
				this.MenuSelectors.QualityLevel.PreviousClick();
				this.UpdateSettingsValues();
				this.lastJoystickInputTime = Time.unscaledTime;
			}
			if (this.player.GetButtonDown("D-PadRight") || (axis > 0.5f && this.<Update>g__CanUseStick|13_0()))
			{
				this.MenuSelectors.QualityLevel.ForwardClick();
				this.UpdateSettingsValues();
				this.lastJoystickInputTime = Time.unscaledTime;
			}
		}
		if (EventSystem.current.currentSelectedGameObject == this.MainButtons.Resolution)
		{
			if (this.player.GetButtonDown("D-PadLeft") || (axis < -0.5f && this.<Update>g__CanUseStick|13_0()))
			{
				this.MenuSelectors.Resolution.PreviousClick();
				this.UpdateSettingsValues();
				this.lastJoystickInputTime = Time.unscaledTime;
			}
			if (this.player.GetButtonDown("D-PadRight") || (axis > 0.5f && this.<Update>g__CanUseStick|13_0()))
			{
				this.MenuSelectors.Resolution.ForwardClick();
				this.UpdateSettingsValues();
				this.lastJoystickInputTime = Time.unscaledTime;
			}
		}
		if (EventSystem.current.currentSelectedGameObject == this.MainButtons.DisplayMode)
		{
			if (this.player.GetButtonDown("D-PadLeft") || (axis < -0.5f && this.<Update>g__CanUseStick|13_0()))
			{
				this.MenuSelectors.DisplayMode.PreviousClick();
				this.UpdateSettingsValues();
				this.lastJoystickInputTime = Time.unscaledTime;
			}
			if (this.player.GetButtonDown("D-PadRight") || (axis > 0.5f && this.<Update>g__CanUseStick|13_0()))
			{
				this.MenuSelectors.DisplayMode.ForwardClick();
				this.UpdateSettingsValues();
				this.lastJoystickInputTime = Time.unscaledTime;
			}
		}
		if (EventSystem.current.currentSelectedGameObject == this.MainButtons.Controller)
		{
			if (this.player.GetButtonDown("D-PadLeft") || (axis < -0.5f && this.<Update>g__CanUseStick|13_0()))
			{
				this.MenuSelectors.Controller.PreviousClick();
				this.UpdateSettingsValues();
				this.lastJoystickInputTime = Time.unscaledTime;
			}
			if (this.player.GetButtonDown("D-PadRight") || (axis > 0.5f && this.<Update>g__CanUseStick|13_0()))
			{
				this.MenuSelectors.Controller.ForwardClick();
				this.UpdateSettingsValues();
				this.lastJoystickInputTime = Time.unscaledTime;
			}
		}
		if (EventSystem.current.currentSelectedGameObject == this.MainButtons.Vibration)
		{
			if (this.player.GetButtonDown("D-PadLeft") || (axis < -0.5f && this.<Update>g__CanUseStick|13_0()))
			{
				this.MenuSelectors.Vibration.PreviousClick();
				this.UpdateSettingsValues();
				this.lastJoystickInputTime = Time.unscaledTime;
			}
			if (this.player.GetButtonDown("D-PadRight") || (axis > 0.5f && this.<Update>g__CanUseStick|13_0()))
			{
				this.MenuSelectors.Vibration.ForwardClick();
				this.UpdateSettingsValues();
				this.lastJoystickInputTime = Time.unscaledTime;
			}
		}
		if (EventSystem.current.currentSelectedGameObject == this.MainButtons.VSync)
		{
			if (this.player.GetButtonDown("D-PadLeft") || (axis < -0.5f && this.<Update>g__CanUseStick|13_0()))
			{
				this.MenuSelectors.VSync.PreviousClick();
				this.UpdateSettingsValues();
				this.lastJoystickInputTime = Time.unscaledTime;
			}
			if (this.player.GetButtonDown("D-PadRight") || (axis > 0.5f && this.<Update>g__CanUseStick|13_0()))
			{
				this.MenuSelectors.VSync.ForwardClick();
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

	// Token: 0x060005D8 RID: 1496 RVA: 0x0002AD7C File Offset: 0x00028F7C
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
		if (this.MenuSelectors.Vibration.index == 0)
		{
			this.settingsValues.vibration = 0;
		}
		if (this.MenuSelectors.Vibration.index == 1)
		{
			this.settingsValues.vibration = 1;
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
		if (this.MenuSelectors.Controller.index == 0)
		{
			this.settingsValues.controllerType = 0;
		}
		if (this.MenuSelectors.Controller.index == 1)
		{
			this.settingsValues.controllerType = 1;
		}
		this.settingsChanged = true;
		this.MainButtons.applyButton.interactable = true;
		this.UpdateVolumeLevel();
	}

	// Token: 0x060005D9 RID: 1497 RVA: 0x0002B018 File Offset: 0x00029218
	public void UpdateVolumeLevel()
	{
		this.settingsValues.mainVolume = this.MenuSelectors.Volume.mainSlider.value;
		if (!this.settingsChanged)
		{
			this.settingsChanged = true;
			this.MainButtons.applyButton.interactable = true;
		}
	}

	// Token: 0x060005DA RID: 1498 RVA: 0x0002B068 File Offset: 0x00029268
	public void UpdateTrickInputSensitivity()
	{
		this.settingsValues.trickInputSensitivity = this.MenuSelectors.trickInputSensitivity.mainSlider.value;
		if (!this.settingsChanged)
		{
			this.settingsChanged = true;
			this.MainButtons.applyButton.interactable = true;
		}
	}

	// Token: 0x060005DB RID: 1499 RVA: 0x0002B0B8 File Offset: 0x000292B8
	public void UpdateMenuVolumeLevel()
	{
		this.settingsValues.menuVolume = this.MenuSelectors.MenuVolume.mainSlider.value;
		if (!this.settingsChanged)
		{
			this.settingsChanged = true;
			this.MainButtons.applyButton.interactable = true;
		}
	}

	// Token: 0x060005DC RID: 1500 RVA: 0x0002B108 File Offset: 0x00029308
	public void ApplySettings()
	{
		Screen.SetResolution(this.settingsValues.screenWidth, this.settingsValues.screenHeight, this.settingsValues.fullScreenBool);
		AudioListener.volume = this.settingsValues.mainVolume / 100f;
		this.menuClick.volume = this.settingsValues.menuVolume / 2f / 100f;
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
		if (this.settingsValues.controllerType == 0)
		{
			this.controllerType.controllerType = 0;
			this.controllerType.ToggleControllerType();
		}
		if (this.settingsValues.controllerType == 1)
		{
			this.controllerType.controllerType = 1;
			this.controllerType.ToggleControllerType();
		}
		if (this.settingsChanged)
		{
			this.settingsApplied();
			this.settingsChanged = false;
		}
	}

	// Token: 0x060005DD RID: 1501 RVA: 0x0002B272 File Offset: 0x00029472
	private void settingsApplied()
	{
		EventSystem.current.SetSelectedGameObject(this.MainButtons.QualityLevel);
		this.MainButtons.applyButton.interactable = false;
		this.SavePlayerSettingsData();
	}

	// Token: 0x060005DE RID: 1502 RVA: 0x0002B2A0 File Offset: 0x000294A0
	public void SavePlayerSettingsData()
	{
		PlayerPrefs.SetInt("V0.5SaveSystem", 1);
		PlayerPrefs.SetInt("PlayerScreenWidth", this.settingsValues.screenWidth);
		PlayerPrefs.SetInt("PlayerScreenHeight", this.settingsValues.screenHeight);
		PlayerPrefs.SetInt("PlayerQualityLevel", this.settingsValues.qualityLevel);
		PlayerPrefs.SetInt("PlayerVSYNC", this.settingsValues.vSync);
		PlayerPrefs.SetInt("PlayerFullscreen", this.settingsValues.fullscreen);
		PlayerPrefs.SetInt("PlayerVibration", this.settingsValues.vibration);
		PlayerPrefs.SetInt("PlayerControllerType", this.settingsValues.controllerType);
		PlayerPrefs.SetFloat("PlayerMainVolume", this.settingsValues.mainVolume);
		PlayerPrefs.SetFloat("PlayerMenuVolume", this.settingsValues.menuVolume);
		PlayerPrefs.SetFloat("PlayerTrickInputSensitivity", this.settingsValues.trickInputSensitivity);
	}

	// Token: 0x060005DF RID: 1503 RVA: 0x0002B38C File Offset: 0x0002958C
	public void LoadPlayerSettingsData()
	{
		if (PlayerPrefs.HasKey("V0.5SaveSystem"))
		{
			this.settingsValues.screenWidth = PlayerPrefs.GetInt("PlayerScreenWidth");
			this.settingsValues.screenHeight = PlayerPrefs.GetInt("PlayerScreenHeight");
			this.settingsValues.qualityLevel = PlayerPrefs.GetInt("PlayerQualityLevel");
			this.settingsValues.vSync = PlayerPrefs.GetInt("PlayerVSYNC");
			this.settingsValues.fullscreen = PlayerPrefs.GetInt("PlayerFullscreen");
			this.settingsValues.controllerType = PlayerPrefs.GetInt("PlayerControllerType");
			this.settingsValues.vibration = PlayerPrefs.GetInt("PlayerVibration");
			this.settingsValues.mainVolume = PlayerPrefs.GetFloat("PlayerMainVolume");
			this.settingsValues.menuVolume = PlayerPrefs.GetFloat("PlayerMenuVolume");
			this.settingsValues.trickInputSensitivity = PlayerPrefs.GetFloat("PlayerTrickInputSensitivity");
			if (this.settingsValues.fullscreen == 0)
			{
				this.settingsValues.fullScreenBool = false;
			}
			if (this.settingsValues.fullscreen == 1)
			{
				this.settingsValues.fullScreenBool = true;
			}
			AudioListener.volume = this.settingsValues.mainVolume / 100f;
			this.menuClick.volume = this.settingsValues.menuVolume / 2f / 100f;
			this.UpdateUI();
			return;
		}
		this.DefaultSettings();
		AudioListener.volume = 0.5f;
		this.settingsValues.menuVolume = 100f;
	}

	// Token: 0x060005E0 RID: 1504 RVA: 0x000020BE File Offset: 0x000002BE
	public void DefaultSettings()
	{
	}

	// Token: 0x060005E1 RID: 1505 RVA: 0x0002B50C File Offset: 0x0002970C
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
		this.MenuSelectors.Controller.index = this.settingsValues.controllerType;
		this.MenuSelectors.Vibration.index = this.settingsValues.vibration;
		this.MenuSelectors.Volume.mainSlider.value = this.settingsValues.mainVolume;
		this.MenuSelectors.MenuVolume.mainSlider.value = this.settingsValues.menuVolume;
		this.MenuSelectors.trickInputSensitivity.mainSlider.value = this.settingsValues.trickInputSensitivity;
		this.MenuSelectors.Resolution.UpdateUI();
		this.MenuSelectors.QualityLevel.UpdateUI();
		this.MenuSelectors.DisplayMode.UpdateUI();
		this.MenuSelectors.VSync.UpdateUI();
		this.MenuSelectors.Controller.UpdateUI();
		this.MenuSelectors.Vibration.UpdateUI();
		this.MenuSelectors.trickInputSensitivity.UpdateUI();
	}

	// Token: 0x060005E3 RID: 1507 RVA: 0x0002B71A File Offset: 0x0002991A
	[CompilerGenerated]
	private bool <Update>g__CanUseStick|13_0()
	{
		return Time.unscaledTime - this.lastJoystickInputTime > this.joystickInputCooldown;
	}

	// Token: 0x040009BE RID: 2494
	public int playerId;

	// Token: 0x040009BF RID: 2495
	private Player player;

	// Token: 0x040009C0 RID: 2496
	public MenuSettingsButtons MainButtons;

	// Token: 0x040009C1 RID: 2497
	public MenuSettingsSelectors MenuSelectors;

	// Token: 0x040009C2 RID: 2498
	public MenuSettingsValues settingsValues;

	// Token: 0x040009C3 RID: 2499
	public MainMenuSounds mainMenuSounds;

	// Token: 0x040009C4 RID: 2500
	public global::ControllerType controllerType;

	// Token: 0x040009C5 RID: 2501
	public AudioSource menuClick;

	// Token: 0x040009C6 RID: 2502
	private bool settingsChanged;

	// Token: 0x040009C7 RID: 2503
	private GameObject clickTrigger;

	// Token: 0x040009C8 RID: 2504
	private float joystickInputCooldown = 0.5f;

	// Token: 0x040009C9 RID: 2505
	private float lastJoystickInputTime = -1f;
}
