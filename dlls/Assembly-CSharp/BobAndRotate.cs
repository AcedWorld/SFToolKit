using System;
using UnityEngine;

// Token: 0x020000AB RID: 171
public class BobAndRotate : MonoBehaviour
{
	// Token: 0x060002D5 RID: 725 RVA: 0x0001671A File Offset: 0x0001491A
	private void Start()
	{
		this.initialPosition = base.transform.position;
	}

	// Token: 0x060002D6 RID: 726 RVA: 0x00016730 File Offset: 0x00014930
	private void Update()
	{
		float num = Mathf.Sin(Time.time * this.bobSpeed) * this.bobAmplitude;
		base.transform.position = new Vector3(this.initialPosition.x, this.initialPosition.y + num, this.initialPosition.z);
		base.transform.Rotate(Vector3.up, this.rotationSpeed * Time.deltaTime, Space.World);
	}

	// Token: 0x04000390 RID: 912
	[Header("Bobbing Settings")]
	public float bobAmplitude = 0.1f;

	// Token: 0x04000391 RID: 913
	public float bobSpeed = 2f;

	// Token: 0x04000392 RID: 914
	[Header("Rotation Settings")]
	public float rotationSpeed = 45f;

	// Token: 0x04000393 RID: 915
	private Vector3 initialPosition;
}
