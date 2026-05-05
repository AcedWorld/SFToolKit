using System;
using TMPro;
using UnityEngine;

// Token: 0x0200014F RID: 335
public class FPSCounter : MonoBehaviour
{
	// Token: 0x0600055A RID: 1370 RVA: 0x00024DF4 File Offset: 0x00022FF4
	private void Start()
	{
		this.cheatCode = new string[]
		{
			"f",
			"p",
			"s"
		};
		this.index = 0;
	}

	// Token: 0x0600055B RID: 1371 RVA: 0x00024E24 File Offset: 0x00023024
	private void Update()
	{
		if (this.fpsCounter && Time.unscaledTime > this._timer)
		{
			int num = (int)(1f / Time.unscaledDeltaTime);
			this._fpsText.text = "FPS: " + num.ToString();
			this._timer = Time.unscaledTime + this._hudRefreshRate;
		}
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
			Debug.Log("Display FPS Toggled");
			this.fpsCounter = !this.fpsCounter;
			this._fpsText.text = "";
			this.index = 0;
		}
	}

	// Token: 0x04000873 RID: 2163
	public int index;

	// Token: 0x04000874 RID: 2164
	private string[] cheatCode;

	// Token: 0x04000875 RID: 2165
	public TMP_Text _fpsText;

	// Token: 0x04000876 RID: 2166
	[SerializeField]
	private float _hudRefreshRate = 0.5f;

	// Token: 0x04000877 RID: 2167
	public bool fpsCounter;

	// Token: 0x04000878 RID: 2168
	private float _timer;
}
