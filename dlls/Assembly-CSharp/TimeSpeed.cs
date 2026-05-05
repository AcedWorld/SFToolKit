using System;
using Unity.Netcode;
using UnityEngine;

// Token: 0x020001D0 RID: 464
public class TimeSpeed : MonoBehaviour
{
	// Token: 0x06000740 RID: 1856 RVA: 0x000020BE File Offset: 0x000002BE
	private void Start()
	{
	}

	// Token: 0x06000741 RID: 1857 RVA: 0x000020BE File Offset: 0x000002BE
	private void Update()
	{
	}

	// Token: 0x06000742 RID: 1858 RVA: 0x000368E2 File Offset: 0x00034AE2
	public void NormalTime()
	{
		Time.timeScale = 1f;
		this._slomo = false;
		this.pauseTime = false;
	}

	// Token: 0x06000743 RID: 1859 RVA: 0x000368FC File Offset: 0x00034AFC
	public void PauseTime()
	{
		if (NetworkManager.Singleton.IsServer || NetworkManager.Singleton.IsClient)
		{
			if (this.allowEditorPause)
			{
				Time.timeScale = 0f;
				return;
			}
		}
		else
		{
			Time.timeScale = 0f;
		}
	}

	// Token: 0x06000744 RID: 1860 RVA: 0x00036933 File Offset: 0x00034B33
	public void SlowTime()
	{
		this._slomo = !this._slomo;
		if (this._slomo)
		{
			Time.timeScale = this.slowMotion;
		}
		if (!this._slomo)
		{
			this.NormalTime();
		}
	}

	// Token: 0x06000745 RID: 1861 RVA: 0x00036965 File Offset: 0x00034B65
	public void TogglePauseTime()
	{
		if (this.allowPauseTime)
		{
			this.pauseTime = !this.pauseTime;
			if (this.pauseTime)
			{
				this.PauseTime();
			}
			if (!this.pauseTime)
			{
				this.NormalTime();
			}
		}
	}

	// Token: 0x04000CD8 RID: 3288
	public float slowMotion;

	// Token: 0x04000CD9 RID: 3289
	private bool _slomo;

	// Token: 0x04000CDA RID: 3290
	private bool pauseTime;

	// Token: 0x04000CDB RID: 3291
	public bool allowPauseTime;

	// Token: 0x04000CDC RID: 3292
	public bool allowEditorPause;
}
