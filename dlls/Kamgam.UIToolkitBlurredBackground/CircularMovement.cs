using System;
using UnityEngine;

namespace Kamgam.UGUIBlurredBackground
{
	// Token: 0x02000003 RID: 3
	public class CircularMovement : MonoBehaviour
	{
		// Token: 0x06000003 RID: 3 RVA: 0x000020C0 File Offset: 0x000002C0
		public void Start()
		{
			this._startPos = base.transform.localPosition;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020D4 File Offset: 0x000002D4
		public void Update()
		{
			this._progress += Time.deltaTime * this.Speed;
			float x = Mathf.Sin(this._progress) * this.Radius;
			float z = Mathf.Cos(this._progress) * this.Radius;
			Vector3 localPosition = this._startPos - this.CenterOffset * this.Radius + new Vector3(x, 0f, z);
			base.transform.localPosition = localPosition;
		}

		// Token: 0x04000001 RID: 1
		public float Speed = 2f;

		// Token: 0x04000002 RID: 2
		public float Radius = 10f;

		// Token: 0x04000003 RID: 3
		public Vector3 CenterOffset = new Vector3(0f, 0f, 0f);

		// Token: 0x04000004 RID: 4
		protected Vector3 _startPos;

		// Token: 0x04000005 RID: 5
		protected float _progress;
	}
}
