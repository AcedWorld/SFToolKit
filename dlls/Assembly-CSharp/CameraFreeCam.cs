using System;
using Cinemachine;
using Rewired;
using UnityEngine;

// Token: 0x0200012C RID: 300
public class CameraFreeCam : MonoBehaviour
{
	// Token: 0x060004DD RID: 1245 RVA: 0x00021B22 File Offset: 0x0001FD22
	private void Start()
	{
		this.player = ReInput.players.GetPlayer(this.playerId);
		this.camRB = base.GetComponent<Rigidbody>();
	}

	// Token: 0x060004DE RID: 1246 RVA: 0x00021B48 File Offset: 0x0001FD48
	private void FixedUpdate()
	{
		this.hinput = this.player.GetAxis("LeftStickX");
		this.vinput = this.player.GetAxis("LeftStickY");
		this.rhinput = this.player.GetAxis("RightStickY");
		this.rvinput = this.player.GetAxis("RightStickX");
		float d;
		Vector3 vector;
		Quaternion.FromToRotation(this.camRB.transform.up, Vector3.up).ToAngleAxis(out d, out vector);
		this.camRB.AddTorque(-this.camRB.angularVelocity * this.dampenFactor, ForceMode.Acceleration);
		this.camRB.AddTorque(vector.normalized * d * this.adjustFactor, ForceMode.Acceleration);
		this.camRB.AddRelativeForce(this.hinput * this.SideSpeed * this.globalSpeedModifier * this.globalSpeedModifier, this.rhinput * this.verticalMoveSpeed * this.globalSpeedModifier, this.vinput * this.ForwardSpeed * this.globalSpeedModifier);
		float num = 0f;
		if (this.player.GetButton("R1"))
		{
			num += 1f;
		}
		if (this.player.GetButton("L1"))
		{
			num -= 1f;
		}
		float num2 = this.hinput + num * this.shoulderMoveMultiplier;
		this.camRB.AddRelativeForce(num2 * this.SideSpeed * this.globalSpeedModifier, 0f, 0f);
		this.camRB.AddRelativeTorque(0f, this.rvinput * this.rotationSpeed * this.globalSpeedModifier, 0f);
	}

	// Token: 0x060004DF RID: 1247 RVA: 0x00021D05 File Offset: 0x0001FF05
	private void Update()
	{
		if (!this.menuLogic.pauseMenu)
		{
			this.CameraControls();
		}
	}

	// Token: 0x060004E0 RID: 1248 RVA: 0x00021D1C File Offset: 0x0001FF1C
	private void CameraControls()
	{
		if (this.player.GetButton("D-PadRight"))
		{
			CinemachineVirtualCamera cinemachineVirtualCamera = this.virtualCamera;
			cinemachineVirtualCamera.m_Lens.FieldOfView = cinemachineVirtualCamera.m_Lens.FieldOfView - this.fovStep * Time.deltaTime;
		}
		if (this.player.GetButton("D-PadLeft"))
		{
			CinemachineVirtualCamera cinemachineVirtualCamera2 = this.virtualCamera;
			cinemachineVirtualCamera2.m_Lens.FieldOfView = cinemachineVirtualCamera2.m_Lens.FieldOfView + this.fovStep * Time.deltaTime;
		}
		this.virtualCamera.m_Lens.FieldOfView = Mathf.Clamp(this.virtualCamera.m_Lens.FieldOfView, this.minFOV, this.maxFOV);
		if (this.player.GetButton("D-PadUp"))
		{
			this.virtualCamera.transform.Rotate(Vector3.right, -this.tiltIncrement * Time.deltaTime, Space.Self);
		}
		if (this.player.GetButton("D-PadDown"))
		{
			this.virtualCamera.transform.Rotate(Vector3.right, this.tiltIncrement * Time.deltaTime, Space.Self);
		}
	}

	// Token: 0x04000789 RID: 1929
	private int playerId;

	// Token: 0x0400078A RID: 1930
	private Player player;

	// Token: 0x0400078B RID: 1931
	private Rigidbody camRB;

	// Token: 0x0400078C RID: 1932
	public CinemachineVirtualCamera virtualCamera;

	// Token: 0x0400078D RID: 1933
	public MenuLogic menuLogic;

	// Token: 0x0400078E RID: 1934
	public float globalSpeedModifier = 0.5f;

	// Token: 0x0400078F RID: 1935
	public float ForwardSpeed = 800f;

	// Token: 0x04000790 RID: 1936
	public float SideSpeed = 600f;

	// Token: 0x04000791 RID: 1937
	public float verticalMoveSpeed = 600f;

	// Token: 0x04000792 RID: 1938
	public float rotationSpeed = 20f;

	// Token: 0x04000793 RID: 1939
	public float adjustFactor = 1f;

	// Token: 0x04000794 RID: 1940
	public float dampenFactor = 10f;

	// Token: 0x04000795 RID: 1941
	public float fovStep = 20f;

	// Token: 0x04000796 RID: 1942
	public float minFOV = 30f;

	// Token: 0x04000797 RID: 1943
	public float maxFOV = 100f;

	// Token: 0x04000798 RID: 1944
	public float shoulderMoveMultiplier = 0.2f;

	// Token: 0x04000799 RID: 1945
	public float tiltIncrement = 30f;

	// Token: 0x0400079A RID: 1946
	private float hinput;

	// Token: 0x0400079B RID: 1947
	private float vinput;

	// Token: 0x0400079C RID: 1948
	private float rhinput;

	// Token: 0x0400079D RID: 1949
	private float rvinput;
}
