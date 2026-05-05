using System;
using Michsky.UI.ModernUIPack;
using UnityEngine;

// Token: 0x020001FE RID: 510
public class VolumeSettings : MonoBehaviour
{
	// Token: 0x06000808 RID: 2056 RVA: 0x00039B38 File Offset: 0x00037D38
	private void Start()
	{
		if (!PlayerPrefs.HasKey(this.volumeSlider.sliderTag + "MUIPSliderValue"))
		{
			this.savedVolume = this.volumeSlider.mainSlider.value;
		}
		else
		{
			this.savedVolume = PlayerPrefs.GetFloat(this.volumeSlider.sliderTag + "MUIPSliderValue");
		}
		this.whatsTheVolume = AudioListener.volume;
		AudioListener.volume = this.savedVolume / 50f;
	}

	// Token: 0x06000809 RID: 2057 RVA: 0x00039BB5 File Offset: 0x00037DB5
	public void onValueEdit()
	{
		AudioListener.volume = this.volumeSlider.mainSlider.value / 50f;
	}

	// Token: 0x04000E01 RID: 3585
	public SliderManager volumeSlider;

	// Token: 0x04000E02 RID: 3586
	private float savedVolume;

	// Token: 0x04000E03 RID: 3587
	public float whatsTheVolume;
}
