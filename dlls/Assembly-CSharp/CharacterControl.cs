using System;
using UnityEngine;

// Token: 0x0200000C RID: 12
public class CharacterControl : MonoBehaviour
{
	// Token: 0x06000026 RID: 38 RVA: 0x00003227 File Offset: 0x00001427
	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		this.charController = base.GetComponent<CharacterController>();
		this.cam = base.transform.Find("Camera");
	}

	// Token: 0x06000027 RID: 39 RVA: 0x00003254 File Offset: 0x00001454
	private void Update()
	{
		this.CameraMovement();
		Vector3 vector = base.transform.right * Input.GetAxis("Horizontal") + base.transform.forward * Input.GetAxis("Vertical");
		this.charController.SimpleMove(Vector3.ClampMagnitude(vector, 1f) * (Input.GetKey(KeyCode.LeftShift) ? (this.speed * 1.6f) : this.speed));
	}

	// Token: 0x06000028 RID: 40 RVA: 0x000032E0 File Offset: 0x000014E0
	private void CameraMovement()
	{
		Vector2 vector = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
		vector = Vector2.Scale(vector, new Vector2(this.sensitivity * Time.deltaTime, this.sensitivity * Time.deltaTime));
		this.xRotation -= vector.y;
		this.cam.localRotation = Quaternion.Euler(Mathf.Clamp(this.xRotation, -70f, 70f), 0f, 0f);
		base.transform.transform.Rotate(Vector3.up * vector.x);
	}

	// Token: 0x04000045 RID: 69
	public float speed = 10f;

	// Token: 0x04000046 RID: 70
	public float sensitivity = 100f;

	// Token: 0x04000047 RID: 71
	private float xRotation;

	// Token: 0x04000048 RID: 72
	private Transform cam;

	// Token: 0x04000049 RID: 73
	private CharacterController charController;
}
