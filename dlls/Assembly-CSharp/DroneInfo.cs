using System;
using UnityEngine;

// Token: 0x020000A5 RID: 165
public class DroneInfo : MonoBehaviour
{
	// Token: 0x060002B9 RID: 697 RVA: 0x00015C3A File Offset: 0x00013E3A
	private void Start()
	{
		this.rb = base.GetComponent<Rigidbody>();
	}

	// Token: 0x060002BA RID: 698 RVA: 0x000020BE File Offset: 0x000002BE
	private void Update()
	{
	}

	// Token: 0x060002BB RID: 699 RVA: 0x00015C48 File Offset: 0x00013E48
	private void FixedUpdate()
	{
		if (Physics.Raycast(this.DroneBase.position, this.DroneBase.TransformDirection(Vector3.down), out this.hit, float.PositiveInfinity, this.layerMask))
		{
			Debug.DrawRay(this.DroneBase.position, base.transform.TransformDirection(Vector3.down) * this.hit.distance, Color.yellow);
			this.Height = Vector3.Distance(this.DroneBase.position, this.hit.point);
		}
		else
		{
			Debug.DrawRay(base.transform.position, base.transform.TransformDirection(Vector3.down) * 1000f, Color.white);
		}
		float num = Mathf.Round(this.rb.velocity.magnitude * 3.6f * 1f) / 1f;
		this.Altitude = this.DroneBase.position.y;
	}

	// Token: 0x04000354 RID: 852
	public float Height;

	// Token: 0x04000355 RID: 853
	public float Altitude;

	// Token: 0x04000356 RID: 854
	public Transform DroneBase;

	// Token: 0x04000357 RID: 855
	public LayerMask layerMask;

	// Token: 0x04000358 RID: 856
	public DroneUI onScreenDisplay;

	// Token: 0x04000359 RID: 857
	private Rigidbody rb;

	// Token: 0x0400035A RID: 858
	public RaycastHit hit;
}
