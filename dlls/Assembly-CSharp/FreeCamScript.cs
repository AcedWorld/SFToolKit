using System;
using Cinemachine;
using Rewired;
using UnityEngine;

// Token: 0x02000203 RID: 515
public class FreeCamScript : MonoBehaviour
{
	// Token: 0x06000818 RID: 2072 RVA: 0x0003A4A7 File Offset: 0x000386A7
	private void Start()
	{
		this.player = ReInput.players.GetPlayer(this.playerId);
		this.targetPosition = base.transform.position;
		this.targetRotation = base.transform.rotation;
	}

	// Token: 0x06000819 RID: 2073 RVA: 0x0003A4E4 File Offset: 0x000386E4
	private void Update()
	{
		if (this.cinemachineBrain.isActiveAndEnabled)
		{
			this.freeCamEnabled = true;
		}
		else
		{
			this.freeCamEnabled = false;
			this.ControlCamera();
		}
		if (this.player.GetButtonDown("R1"))
		{
			this.mainCamera.fieldOfView = Mathf.Min(this.mainCamera.fieldOfView + this.fovChangeSpeed, this.maxFov);
		}
		if (this.player.GetButtonDown("L1"))
		{
			this.mainCamera.fieldOfView = Mathf.Max(this.mainCamera.fieldOfView - this.fovChangeSpeed, this.minFov);
		}
		if (this.player.GetButton("R2"))
		{
			this.PanCamera(Vector3.right);
		}
		if (this.player.GetButton("L2"))
		{
			this.PanCamera(Vector3.left);
		}
		base.transform.position = Vector3.Lerp(base.transform.position, this.targetPosition, this.positionDampening * Time.deltaTime);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, this.rotationDampening * Time.deltaTime);
	}

	// Token: 0x0600081A RID: 2074 RVA: 0x0003A61C File Offset: 0x0003881C
	private void ControlCamera()
	{
		this.RightStickY = this.player.GetAxis("RightStickY");
		this.RightStickX = this.player.GetAxis("RightStickX");
		this.LeftStickY = this.player.GetAxis("LeftStickY");
		this.LeftStickX = this.player.GetAxis("LeftStickX");
		this.rotationX += this.RightStickX * this.cameraSensitivity * Time.deltaTime;
		this.rotationY -= this.RightStickY * this.cameraSensitivity * Time.deltaTime;
		this.rotationY = Mathf.Clamp(this.rotationY, this.minY, this.maxY);
		this.targetRotation = Quaternion.Euler(this.rotationY, this.rotationX, 0f);
		Vector3 vector = new Vector3(this.LeftStickX, 0f, this.LeftStickY);
		vector = base.transform.TransformDirection(vector);
		this.targetPosition += vector * this.moveSpeed * Time.deltaTime;
	}

	// Token: 0x0600081B RID: 2075 RVA: 0x0003A746 File Offset: 0x00038946
	private void PanCamera(Vector3 direction)
	{
		this.targetPosition += base.transform.TransformDirection(direction) * this.panSpeed * Time.deltaTime;
	}

	// Token: 0x04000E31 RID: 3633
	public Camera mainCamera;

	// Token: 0x04000E32 RID: 3634
	public CinemachineBrain cinemachineBrain;

	// Token: 0x04000E33 RID: 3635
	public bool freeCamEnabled;

	// Token: 0x04000E34 RID: 3636
	private int playerId;

	// Token: 0x04000E35 RID: 3637
	private Player player;

	// Token: 0x04000E36 RID: 3638
	public float RightStickY;

	// Token: 0x04000E37 RID: 3639
	public float RightStickX;

	// Token: 0x04000E38 RID: 3640
	public float LeftStickY;

	// Token: 0x04000E39 RID: 3641
	public float LeftStickX;

	// Token: 0x04000E3A RID: 3642
	public float cameraSensitivity = 100f;

	// Token: 0x04000E3B RID: 3643
	public float moveSpeed = 10f;

	// Token: 0x04000E3C RID: 3644
	public float panSpeed = 5f;

	// Token: 0x04000E3D RID: 3645
	public float minY = -60f;

	// Token: 0x04000E3E RID: 3646
	public float maxY = 60f;

	// Token: 0x04000E3F RID: 3647
	private float rotationY;

	// Token: 0x04000E40 RID: 3648
	private float rotationX;

	// Token: 0x04000E41 RID: 3649
	public float fovChangeSpeed = 10f;

	// Token: 0x04000E42 RID: 3650
	public float minFov = 40f;

	// Token: 0x04000E43 RID: 3651
	public float maxFov = 80f;

	// Token: 0x04000E44 RID: 3652
	private Vector3 targetPosition;

	// Token: 0x04000E45 RID: 3653
	private Quaternion targetRotation;

	// Token: 0x04000E46 RID: 3654
	public float positionDampening = 5f;

	// Token: 0x04000E47 RID: 3655
	public float rotationDampening = 5f;
}
