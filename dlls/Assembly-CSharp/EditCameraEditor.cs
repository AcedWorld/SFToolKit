using System;
using Cinemachine;
using UnityEngine;

// Token: 0x02000009 RID: 9
public class EditCameraEditor : MonoBehaviour
{
	// Token: 0x0600001B RID: 27 RVA: 0x00002570 File Offset: 0x00000770
	private void Start()
	{
		if (this.cinemachineFreeLook != null)
		{
			this.defaultHeight = this.cinemachineFreeLook.m_Orbits[1].m_Height;
			this.defaultRadius = this.cinemachineFreeLook.m_Orbits[1].m_Radius;
		}
		if (this.moveCam != null)
		{
			this.moveCamWasEnabled = this.moveCam.enabled;
		}
		if (this.moveCamTarget != null)
		{
			this.moveCamTargetWasEnabled = this.moveCamTarget.enabled;
		}
	}

	// Token: 0x0600001C RID: 28 RVA: 0x00002604 File Offset: 0x00000804
	private void Update()
	{
		if (this.cinemachineFreeLook == null)
		{
			return;
		}
		CinemachineFreeLook.Orbit orbit = this.cinemachineFreeLook.m_Orbits[1];
		bool flag = false;
		if (Input.GetKeyDown(KeyCode.Keypad8))
		{
			orbit.m_Height += this.stepSize;
			flag = true;
		}
		else if (Input.GetKeyDown(KeyCode.Keypad2))
		{
			orbit.m_Height -= this.stepSize;
			flag = true;
		}
		if (Input.GetKeyDown(KeyCode.Keypad6))
		{
			orbit.m_Radius += this.stepSize;
			flag = true;
		}
		else if (Input.GetKeyDown(KeyCode.Keypad4))
		{
			orbit.m_Radius -= this.stepSize;
			flag = true;
		}
		if (flag)
		{
			this.cinemachineFreeLook.m_Orbits[1] = orbit;
			if (!this.settingsChanged)
			{
				if (this.moveCam != null && this.moveCam.enabled)
				{
					this.moveCamWasEnabled = true;
					this.moveCam.enabled = false;
				}
				if (this.moveCamTarget != null && this.moveCamTarget.enabled)
				{
					this.moveCamTargetWasEnabled = true;
					this.moveCamTarget.enabled = false;
				}
				this.settingsChanged = true;
			}
		}
		if (Input.GetKeyDown(KeyCode.Keypad0))
		{
			orbit.m_Height = this.defaultHeight;
			orbit.m_Radius = this.defaultRadius;
			this.cinemachineFreeLook.m_Orbits[1] = orbit;
			if (this.settingsChanged)
			{
				if (this.moveCam != null && this.moveCamWasEnabled)
				{
					this.moveCam.enabled = true;
				}
				if (this.moveCamTarget != null && this.moveCamTargetWasEnabled)
				{
					this.moveCamTarget.enabled = true;
				}
				this.settingsChanged = false;
			}
		}
	}

	// Token: 0x04000023 RID: 35
	public CinemachineFreeLook cinemachineFreeLook;

	// Token: 0x04000024 RID: 36
	public MoveCam moveCam;

	// Token: 0x04000025 RID: 37
	public MoveCamTarget moveCamTarget;

	// Token: 0x04000026 RID: 38
	private float defaultHeight;

	// Token: 0x04000027 RID: 39
	private float defaultRadius;

	// Token: 0x04000028 RID: 40
	public float stepSize = 0.1f;

	// Token: 0x04000029 RID: 41
	private bool moveCamWasEnabled;

	// Token: 0x0400002A RID: 42
	private bool moveCamTargetWasEnabled;

	// Token: 0x0400002B RID: 43
	private bool settingsChanged;
}
