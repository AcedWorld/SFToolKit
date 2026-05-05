using System;
using Cinemachine;
using UnityEngine;

// Token: 0x020001D2 RID: 466
public class UpdateRagdollCamSettings : MonoBehaviour
{
	// Token: 0x0600074A RID: 1866 RVA: 0x0003699A File Offset: 0x00034B9A
	public void FixedUpdate()
	{
		this.activeCamera = this.FindActiveCinemachineCamera();
		if (this.activeCamera != null)
		{
			this.CopyCinemachineFreeLookSettings(this.activeCamera, this.RagdollCam);
		}
	}

	// Token: 0x0600074B RID: 1867 RVA: 0x000369C8 File Offset: 0x00034BC8
	private void CopyCinemachineFreeLookSettings(CinemachineFreeLook source, CinemachineFreeLook destination)
	{
		destination.m_CommonLens = source.m_CommonLens;
		destination.m_Lens = source.m_Lens;
		destination.m_Transitions = source.m_Transitions;
		destination.m_Orbits[0] = source.m_Orbits[0];
		destination.m_Orbits[1] = new CinemachineFreeLook.Orbit(destination.m_Orbits[1].m_Height, source.m_Orbits[1].m_Radius);
		destination.m_Orbits[2] = source.m_Orbits[2];
		destination.m_YAxis = source.m_YAxis;
		destination.m_XAxis = source.m_XAxis;
		destination.m_RecenterToTargetHeading = source.m_RecenterToTargetHeading;
		destination.m_BindingMode = source.m_BindingMode;
		destination.m_SplineCurvature = source.m_SplineCurvature;
	}

	// Token: 0x0600074C RID: 1868 RVA: 0x00036A98 File Offset: 0x00034C98
	private CinemachineFreeLook FindActiveCinemachineCamera()
	{
		foreach (CinemachineFreeLook cinemachineFreeLook in Object.FindObjectsOfType<CinemachineFreeLook>())
		{
			if (cinemachineFreeLook != this.RagdollCam && cinemachineFreeLook.gameObject.activeInHierarchy && cinemachineFreeLook.enabled)
			{
				return cinemachineFreeLook;
			}
		}
		return null;
	}

	// Token: 0x04000CDD RID: 3293
	public CinemachineFreeLook RagdollCam;

	// Token: 0x04000CDE RID: 3294
	private CinemachineFreeLook activeCamera;
}
