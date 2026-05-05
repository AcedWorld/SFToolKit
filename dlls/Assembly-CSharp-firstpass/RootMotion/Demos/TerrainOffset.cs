using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x0200014C RID: 332
	public class TerrainOffset : MonoBehaviour
	{
		// Token: 0x06000A34 RID: 2612 RVA: 0x0004081C File Offset: 0x0003EA1C
		private void LateUpdate()
		{
			Vector3 vector = base.transform.rotation * this.raycastOffset;
			Vector3 groundHeightOffset = this.GetGroundHeightOffset(base.transform.position + vector);
			this.offset = Vector3.Lerp(this.offset, groundHeightOffset, Time.deltaTime * this.lerpSpeed);
			Vector3 vector2 = base.transform.position + new Vector3(vector.x, 0f, vector.z);
			this.aimIK.solver.transform.LookAt(vector2);
			this.aimIK.solver.IKPosition = vector2 + this.offset;
		}

		// Token: 0x06000A35 RID: 2613 RVA: 0x000408D0 File Offset: 0x0003EAD0
		private Vector3 GetGroundHeightOffset(Vector3 worldPosition)
		{
			Debug.DrawRay(worldPosition, Vector3.down * this.raycastOffset.y * 2f, Color.green);
			if (Physics.Raycast(worldPosition, Vector3.down, out this.hit, this.raycastOffset.y * 2f))
			{
				return Mathf.Clamp(this.hit.point.y - base.transform.position.y, this.min, this.max) * Vector3.up;
			}
			return Vector3.zero;
		}

		// Token: 0x04000996 RID: 2454
		public AimIK aimIK;

		// Token: 0x04000997 RID: 2455
		public Vector3 raycastOffset = new Vector3(0f, 2f, 1.5f);

		// Token: 0x04000998 RID: 2456
		public LayerMask raycastLayers;

		// Token: 0x04000999 RID: 2457
		public float min = -2f;

		// Token: 0x0400099A RID: 2458
		public float max = 2f;

		// Token: 0x0400099B RID: 2459
		public float lerpSpeed = 10f;

		// Token: 0x0400099C RID: 2460
		private RaycastHit hit;

		// Token: 0x0400099D RID: 2461
		private Vector3 offset;
	}
}
