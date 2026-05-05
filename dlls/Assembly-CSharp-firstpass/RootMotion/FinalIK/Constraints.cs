using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x02000099 RID: 153
	[Serializable]
	public class Constraints
	{
		// Token: 0x0600049D RID: 1181 RVA: 0x0001C42F File Offset: 0x0001A62F
		public bool IsValid()
		{
			return this.transform != null;
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x0001C43D File Offset: 0x0001A63D
		public void Initiate(Transform transform)
		{
			this.transform = transform;
			this.position = transform.position;
			this.rotation = transform.eulerAngles;
			this.defaultLocalPosition = transform.localPosition;
			this.defaultLocalRotation = transform.localRotation;
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x0001C476 File Offset: 0x0001A676
		public void FixTransforms()
		{
			this.transform.localPosition = this.defaultLocalPosition;
			this.transform.localRotation = this.defaultLocalRotation;
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x0001C49C File Offset: 0x0001A69C
		public void Update()
		{
			if (!this.IsValid())
			{
				return;
			}
			if (this.target != null)
			{
				this.position = this.target.position;
			}
			this.transform.position += this.positionOffset;
			if (this.positionWeight > 0f)
			{
				this.transform.position = Vector3.Lerp(this.transform.position, this.position, this.positionWeight);
			}
			if (this.target != null)
			{
				this.rotation = this.target.eulerAngles;
			}
			this.transform.rotation = Quaternion.Euler(this.rotationOffset) * this.transform.rotation;
			if (this.rotationWeight > 0f)
			{
				this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(this.rotation), this.rotationWeight);
			}
		}

		// Token: 0x04000418 RID: 1048
		public Transform transform;

		// Token: 0x04000419 RID: 1049
		public Transform target;

		// Token: 0x0400041A RID: 1050
		public Vector3 positionOffset;

		// Token: 0x0400041B RID: 1051
		public Vector3 position;

		// Token: 0x0400041C RID: 1052
		[Range(0f, 1f)]
		public float positionWeight;

		// Token: 0x0400041D RID: 1053
		public Vector3 rotationOffset;

		// Token: 0x0400041E RID: 1054
		public Vector3 rotation;

		// Token: 0x0400041F RID: 1055
		[Range(0f, 1f)]
		public float rotationWeight;

		// Token: 0x04000420 RID: 1056
		private Vector3 defaultLocalPosition;

		// Token: 0x04000421 RID: 1057
		private Quaternion defaultLocalRotation;
	}
}
