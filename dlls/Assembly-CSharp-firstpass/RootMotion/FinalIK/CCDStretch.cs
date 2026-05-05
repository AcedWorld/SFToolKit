using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x0200011D RID: 285
	public class CCDStretch : MonoBehaviour
	{
		// Token: 0x06000962 RID: 2402 RVA: 0x0003B88C File Offset: 0x00039A8C
		private void Start()
		{
			this.defaultLocalPositions = new Vector3[this.ik.solver.bones.Length - 1];
			for (int i = 1; i < this.ik.solver.bones.Length; i++)
			{
				this.defaultLocalPositions[i - 1] = this.ik.solver.bones[i].transform.localPosition;
			}
		}

		// Token: 0x06000963 RID: 2403 RVA: 0x0003B900 File Offset: 0x00039B00
		private void LateUpdate()
		{
			for (int i = 1; i < this.ik.solver.bones.Length; i++)
			{
				this.ik.solver.bones[i].transform.localPosition = this.defaultLocalPositions[i - 1];
			}
			float num = Vector3.Magnitude(((this.ik.solver.target != null) ? this.ik.solver.target.position : this.ik.solver.IKPosition) - this.ik.solver.bones[0].transform.position);
			float num2 = 0f;
			for (int j = 1; j < this.ik.solver.bones.Length; j++)
			{
				num2 += Vector3.Magnitude(this.ik.solver.bones[j].transform.position - this.ik.solver.bones[j - 1].transform.position);
			}
			this.maxStretch = Mathf.Max(this.maxStretch, 1f);
			float d = Mathf.Clamp(num / num2, 1f - this.maxSquash, this.maxStretch);
			for (int k = 1; k < this.ik.solver.bones.Length; k++)
			{
				this.ik.solver.bones[k].transform.localPosition *= d;
			}
		}

		// Token: 0x040008A1 RID: 2209
		public CCDIK ik;

		// Token: 0x040008A2 RID: 2210
		[Range(0f, 0.999f)]
		public float maxSquash;

		// Token: 0x040008A3 RID: 2211
		public float maxStretch = 2f;

		// Token: 0x040008A4 RID: 2212
		private Vector3[] defaultLocalPositions = new Vector3[0];
	}
}
