using System;
using System.Collections;
using UnityEngine;

namespace Invector
{
	// Token: 0x0200036E RID: 878
	public class vPendulum : MonoBehaviour
	{
		// Token: 0x060011CB RID: 4555 RVA: 0x0005EE1D File Offset: 0x0005D01D
		private IEnumerator Start()
		{
			this.qStart = this.PendulumRotation(this.angle);
			this.qEnd = this.PendulumRotation(-this.angle);
			yield return new WaitForSeconds(this.startDelay);
			this.work = true;
			yield break;
		}

		// Token: 0x060011CC RID: 4556 RVA: 0x0005EE2C File Offset: 0x0005D02C
		private void FixedUpdate()
		{
			if (this.work)
			{
				if (!this.working)
				{
					base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, this.qEnd, this.speed);
					if (Vector3.Distance(base.transform.rotation.eulerAngles, this.qEnd.eulerAngles) < 0.1f)
					{
						this.working = true;
						return;
					}
				}
				else
				{
					this.startTime += Time.deltaTime;
					base.transform.rotation = Quaternion.Lerp(this.qStart, this.qEnd, (Mathf.Sin(this.startTime * this.speed + 1.5707964f) + 1f) / 2f);
				}
			}
		}

		// Token: 0x060011CD RID: 4557 RVA: 0x0005EEF7 File Offset: 0x0005D0F7
		private void resetTimer()
		{
			this.startTime = 0f;
		}

		// Token: 0x060011CE RID: 4558 RVA: 0x0005EF04 File Offset: 0x0005D104
		private Quaternion PendulumRotation(float _angle)
		{
			Quaternion rotation = base.transform.rotation;
			float num = rotation.eulerAngles.z + _angle;
			if (num > 180f)
			{
				num -= 360f;
			}
			else if (num < -180f)
			{
				num += 360f;
			}
			rotation.eulerAngles = new Vector3(rotation.eulerAngles.x, rotation.eulerAngles.y, num);
			return rotation;
		}

		// Token: 0x040017A4 RID: 6052
		[Range(0f, 360f)]
		public float angle = 90f;

		// Token: 0x040017A5 RID: 6053
		[Range(0f, 4f)]
		public float speed = 1.5f;

		// Token: 0x040017A6 RID: 6054
		public float startDelay;

		// Token: 0x040017A7 RID: 6055
		private Quaternion qStart;

		// Token: 0x040017A8 RID: 6056
		private Quaternion qEnd;

		// Token: 0x040017A9 RID: 6057
		private float startTime;

		// Token: 0x040017AA RID: 6058
		private bool work;

		// Token: 0x040017AB RID: 6059
		private bool working;
	}
}
