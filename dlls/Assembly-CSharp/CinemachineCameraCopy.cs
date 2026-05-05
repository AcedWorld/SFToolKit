using System;
using Cinemachine;
using Invector.vCharacterController;
using UnityEngine;

// Token: 0x0200012A RID: 298
public class CinemachineCameraCopy : MonoBehaviour
{
	// Token: 0x060004D6 RID: 1238 RVA: 0x0002198A File Offset: 0x0001FB8A
	public void Update()
	{
		if (this.PuppetMaster.activeSelf && !this.cameraSwitched)
		{
			this.CopyAndSetNewTarget();
		}
	}

	// Token: 0x060004D7 RID: 1239 RVA: 0x000219A8 File Offset: 0x0001FBA8
	public void FixedUpdate()
	{
		if (this.Camera1.activeSelf || this.Camera2.activeSelf || this.Camera3.activeSelf)
		{
			if (!this.RagdollCameraHolder.activeSelf)
			{
				this.RagdollCameraHolder.SetActive(true);
			}
			if (this.vThirdPersonInput.firstpersoncontrols)
			{
				this.vThirdPersonInput.firstpersoncontrols = false;
				return;
			}
		}
		else
		{
			if (this.RagdollCameraHolder.activeSelf)
			{
				this.RagdollCameraHolder.SetActive(false);
				this.TransitionBackToOriginal();
				this.cameraSwitched = false;
			}
			if (!this.vThirdPersonInput.firstpersoncontrols)
			{
				this.vThirdPersonInput.firstpersoncontrols = true;
			}
		}
	}

	// Token: 0x060004D8 RID: 1240 RVA: 0x00021A4E File Offset: 0x0001FC4E
	public void CopyAndSetNewTarget()
	{
		if (!this.ragdollCamera.gameObject.activeSelf)
		{
			this.cameraBrain.SwitchOnRagdollCamera();
			this.cameraSwitched = true;
		}
	}

	// Token: 0x060004D9 RID: 1241 RVA: 0x00021A74 File Offset: 0x0001FC74
	public void TransitionBackToOriginal()
	{
		if (this.ragdollCamera.gameObject.activeSelf)
		{
			this.cameraBrain.SwitchOffRagdollCamera();
		}
	}

	// Token: 0x0400077B RID: 1915
	public CinemachineFreeLook ragdollCamera;

	// Token: 0x0400077C RID: 1916
	public GameObject PuppetMaster;

	// Token: 0x0400077D RID: 1917
	public CameraBrain cameraBrain;

	// Token: 0x0400077E RID: 1918
	public GameObject Camera1;

	// Token: 0x0400077F RID: 1919
	public GameObject Camera2;

	// Token: 0x04000780 RID: 1920
	public GameObject Camera3;

	// Token: 0x04000781 RID: 1921
	public GameObject RagdollCameraHolder;

	// Token: 0x04000782 RID: 1922
	public vThirdPersonInput vThirdPersonInput;

	// Token: 0x04000783 RID: 1923
	public bool cameraSwitched;
}
