using System;
using UnityEngine;

// Token: 0x0200019F RID: 415
public class WallDetectDisc : MonoBehaviour
{
	// Token: 0x06000682 RID: 1666 RVA: 0x0003184D File Offset: 0x0002FA4D
	private void Start()
	{
		this.layerMask = this.wallDetect.layerMask;
	}

	// Token: 0x06000683 RID: 1667 RVA: 0x00031860 File Offset: 0x0002FA60
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer == this.layerMask)
		{
			this.wallDetect.probablyNotWall = true;
			Debug.Log(other.gameObject.name);
		}
	}

	// Token: 0x06000684 RID: 1668 RVA: 0x00031896 File Offset: 0x0002FA96
	private void OnTriggerExit(Collider other)
	{
		this.wallDetect.probablyNotWall = false;
	}

	// Token: 0x06000685 RID: 1669 RVA: 0x000318A4 File Offset: 0x0002FAA4
	private void Update()
	{
		this.hit = default(RaycastHit);
		if (Physics.Raycast(base.transform.position, Vector3.down, out this.hit, float.PositiveInfinity, this.layerMask))
		{
			this.slopeBelowDisc = Vector3.Angle(this.hit.normal, Vector3.up);
		}
		if (this.slopeBelowDisc > this.minAngle && this.slopeBelowDisc < this.maxAngle && this.wallDetect.hit.distance < 0.6f)
		{
			this.wallDetect.probablyNotWall = true;
		}
	}

	// Token: 0x04000B5E RID: 2910
	public bool debug;

	// Token: 0x04000B5F RID: 2911
	public WallDetect wallDetect;

	// Token: 0x04000B60 RID: 2912
	private RaycastHit hit;

	// Token: 0x04000B61 RID: 2913
	private LayerMask layerMask;

	// Token: 0x04000B62 RID: 2914
	public float slopeBelowDisc;

	// Token: 0x04000B63 RID: 2915
	public float minAngle;

	// Token: 0x04000B64 RID: 2916
	public float maxAngle;
}
