using System;
using UnityEngine;

// Token: 0x02000171 RID: 369
public class RotateObject : MonoBehaviour
{
	// Token: 0x060005FA RID: 1530 RVA: 0x0002B9C8 File Offset: 0x00029BC8
	private void Update()
	{
		this.Rotate();
	}

	// Token: 0x060005FB RID: 1531 RVA: 0x0002B9D0 File Offset: 0x00029BD0
	private void Rotate()
	{
		Vector3 a = Vector3.zero;
		switch (this.axisOfRotation)
		{
		case RotateObject.RotationAxis.X:
			a = Vector3.right;
			break;
		case RotateObject.RotationAxis.Y:
			a = Vector3.up;
			break;
		case RotateObject.RotationAxis.Z:
			a = Vector3.forward;
			break;
		}
		base.transform.Rotate(a * this.speed * Time.deltaTime);
	}

	// Token: 0x040009E0 RID: 2528
	public float speed = 100f;

	// Token: 0x040009E1 RID: 2529
	public RotateObject.RotationAxis axisOfRotation = RotateObject.RotationAxis.Y;

	// Token: 0x02000172 RID: 370
	public enum RotationAxis
	{
		// Token: 0x040009E3 RID: 2531
		X,
		// Token: 0x040009E4 RID: 2532
		Y,
		// Token: 0x040009E5 RID: 2533
		Z
	}
}
