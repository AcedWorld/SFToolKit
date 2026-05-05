using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x02000129 RID: 297
public class CameraBrain : MonoBehaviour
{
	// Token: 0x060004CB RID: 1227 RVA: 0x000213DB File Offset: 0x0001F5DB
	public void ChangeCamera()
	{
		if (!this.disableCameraChange)
		{
			this.cameras.cameraSelected++;
			this.selectCamera();
			if (this.OnCameraChange != null)
			{
				this.OnCameraChange.Invoke();
			}
		}
	}

	// Token: 0x060004CC RID: 1228 RVA: 0x00021411 File Offset: 0x0001F611
	private void OnEnable()
	{
		if (PlayerPrefs.HasKey("PlayerCameraOption"))
		{
			this.cameras.cameraSelected = PlayerPrefs.GetInt("PlayerCameraOption");
		}
		this.selectCamera();
		this.cameras.cinemachineBrain.GetComponent<CinemachineBrain>().enabled = true;
	}

	// Token: 0x060004CD RID: 1229 RVA: 0x00021450 File Offset: 0x0001F650
	private void Start()
	{
		if (PlayerPrefs.HasKey("PlayerCameraOption"))
		{
			this.cameras.cameraSelected = PlayerPrefs.GetInt("PlayerCameraOption");
			this.selectCamera();
		}
	}

	// Token: 0x060004CE RID: 1230 RVA: 0x0002147C File Offset: 0x0001F67C
	public void selectCamera()
	{
		if (this.cameras.cameraSelected == 1)
		{
			this.cameras.gameCameras[0].gameObject.SetActive(true);
			this.cameras.gameCameras[1].gameObject.SetActive(false);
			this.cameras.gameCameras[2].gameObject.SetActive(false);
			this.cameras.cinemachineBrain.transform.parent = this.cameraLocations.PlayerComponents.transform;
		}
		if (this.cameras.cameraSelected == 2)
		{
			this.cameras.gameCameras[0].gameObject.SetActive(false);
			this.cameras.gameCameras[1].gameObject.SetActive(true);
			this.cameras.gameCameras[2].gameObject.SetActive(false);
			this.cameras.cinemachineBrain.transform.parent = this.cameraLocations.PlayerComponents.transform;
		}
		if (this.cameras.cameraSelected == 3)
		{
			this.cameras.gameCameras[0].gameObject.SetActive(false);
			this.cameras.gameCameras[1].gameObject.SetActive(false);
			this.cameras.gameCameras[2].gameObject.SetActive(true);
			this.cameras.cinemachineBrain.transform.parent = this.cameraLocations.PlayerComponents.transform;
		}
		if (this.cameras.cameraSelected == 4)
		{
			this.cameras.gameCameras[0].gameObject.SetActive(false);
			this.cameras.gameCameras[1].gameObject.SetActive(false);
			this.cameras.gameCameras[2].gameObject.SetActive(false);
			this.cameras.ragdollCam.gameObject.SetActive(false);
			this.cameras.cinemachineBrain.transform.position = this.cameraLocations.FirstPersonTarget.position;
			this.cameras.cinemachineBrain.transform.rotation = this.cameraLocations.FirstPersonTarget.rotation;
			this.cameras.cinemachineBrain.transform.parent = this.cameraLocations.FirstPersonTarget;
			this.cameras.cinemachineBrain.transform.localPosition = Vector3.zero;
			this.cameras.cinemachineBrain.transform.localRotation = Quaternion.identity;
			this.cameras.mainCam.fieldOfView = this.firstPersonCameraSettings.FOV;
			this.cameras.mainCam.nearClipPlane = this.firstPersonCameraSettings.NearPlane;
			this.cameras.mainCam.farClipPlane = this.firstPersonCameraSettings.FarPlane;
		}
		if (this.cameras.cameraSelected == 5)
		{
			this.cameras.cameraSelected = 1;
			this.selectCamera();
		}
	}

	// Token: 0x060004CF RID: 1231 RVA: 0x00021778 File Offset: 0x0001F978
	public void SwitchOnRagdollCamera()
	{
		this.cameras.ragdollCam.ForceCameraPosition(this.cameraLocations.CinamachineBrainTransform.position, this.cameraLocations.CinamachineBrainTransform.rotation);
		this.cameras.ragdollCam.gameObject.SetActive(true);
	}

	// Token: 0x060004D0 RID: 1232 RVA: 0x000217CC File Offset: 0x0001F9CC
	public void SwitchOffRagdollCamera()
	{
		this.cameras.gameCameras[0].ForceCameraPosition(this.cameraLocations.ragdollCamera.position, this.cameraLocations.Camera1Target.rotation);
		this.cameras.gameCameras[1].ForceCameraPosition(this.cameraLocations.ragdollCamera.position, this.cameraLocations.Camera2Target.rotation);
		this.cameras.gameCameras[2].ForceCameraPosition(this.cameraLocations.ragdollCamera.position, this.cameraLocations.Camera3Target.rotation);
		if (this.characterStates.currentState != CharacterState.Ragdolling)
		{
			this.cameras.ragdollCam.gameObject.SetActive(false);
		}
	}

	// Token: 0x060004D1 RID: 1233 RVA: 0x00021893 File Offset: 0x0001FA93
	public void ResetCameras()
	{
		if (this.characterStates.currentState != CharacterState.Ragdolling)
		{
			this.cameras.ragdollCam.gameObject.SetActive(false);
		}
		this.selectCamera();
		this.RelocateCameras();
	}

	// Token: 0x060004D2 RID: 1234 RVA: 0x000218C8 File Offset: 0x0001FAC8
	public void RelocateCameras()
	{
		this.cameras.gameCameras[0].ForceCameraPosition(this.cameraLocations.Camera1Target.position, this.cameraLocations.Camera1Target.rotation);
		this.cameras.gameCameras[1].ForceCameraPosition(this.cameraLocations.Camera2Target.position, this.cameraLocations.Camera2Target.rotation);
		this.cameras.gameCameras[2].ForceCameraPosition(this.cameraLocations.Camera3Target.position, this.cameraLocations.Camera3Target.rotation);
	}

	// Token: 0x060004D3 RID: 1235 RVA: 0x0002196B File Offset: 0x0001FB6B
	private void OnApplicationQuit()
	{
		this.saveCameraState();
	}

	// Token: 0x060004D4 RID: 1236 RVA: 0x00021973 File Offset: 0x0001FB73
	public void saveCameraState()
	{
		PlayerPrefs.SetInt("PlayerCameraOption", this.cameras.cameraSelected);
	}

	// Token: 0x04000774 RID: 1908
	public bool disableCameraChange;

	// Token: 0x04000775 RID: 1909
	public FirstPersonCameraSettings firstPersonCameraSettings;

	// Token: 0x04000776 RID: 1910
	public Cameras cameras;

	// Token: 0x04000777 RID: 1911
	public CameraLocations cameraLocations;

	// Token: 0x04000778 RID: 1912
	public RagdollControl ragdollControl;

	// Token: 0x04000779 RID: 1913
	public CharacterStates characterStates;

	// Token: 0x0400077A RID: 1914
	public UnityEvent OnCameraChange;
}
