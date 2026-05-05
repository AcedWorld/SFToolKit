using System;
using UnityEngine;

namespace Kamgam.UGUIBlurredBackground
{
	// Token: 0x02000005 RID: 5
	public class LinearMovement : MonoBehaviour
	{
		// Token: 0x06000008 RID: 8 RVA: 0x000021AF File Offset: 0x000003AF
		public void Start()
		{
			this._startPos = base.transform.localPosition;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000021C4 File Offset: 0x000003C4
		public void Update()
		{
			Vector3 vector = base.transform.localPosition;
			vector += this.Velocity * Time.deltaTime;
			if (Mathf.Abs(vector.x - this._startPos.x) > this.Limit)
			{
				this.Velocity.x = this.Velocity.x * -1f;
				vector.x = this._startPos.x - this.Limit * Mathf.Sign(this.Velocity.x);
			}
			if (Mathf.Abs(vector.y - this._startPos.y) > this.Limit)
			{
				this.Velocity.y = this.Velocity.y * -1f;
				vector.y = this._startPos.y - this.Limit * Mathf.Sign(this.Velocity.y);
			}
			if (Mathf.Abs(vector.z - this._startPos.z) > this.Limit)
			{
				this.Velocity.z = this.Velocity.z * -1f;
				vector.z = this._startPos.z - this.Limit * Mathf.Sign(this.Velocity.z);
			}
			vector += this.Velocity * Time.deltaTime * 0.1f;
			base.transform.localPosition = vector;
		}

		// Token: 0x04000007 RID: 7
		public Vector3 Velocity = new Vector3(15f, 0f, 0f);

		// Token: 0x04000008 RID: 8
		public float Limit = 20f;

		// Token: 0x04000009 RID: 9
		protected Vector3 _startPos;
	}
}
