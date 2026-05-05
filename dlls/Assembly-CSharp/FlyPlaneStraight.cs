using System;
using UnityEngine;

// Token: 0x02000004 RID: 4
public class FlyPlaneStraight : MonoBehaviour
{
	// Token: 0x0600000D RID: 13 RVA: 0x00002210 File Offset: 0x00000410
	private void Start()
	{
		if (this.startPoint != null && this.endPoint != null)
		{
			this.currentStart = this.startPoint.position;
			this.currentEnd = this.endPoint.position;
			base.transform.position = this.currentStart;
			this.flying = true;
			return;
		}
		Debug.LogError("StartPoint or EndPoint not assigned.");
	}

	// Token: 0x0600000E RID: 14 RVA: 0x00002280 File Offset: 0x00000480
	private void Update()
	{
		if (this.flying)
		{
			base.transform.position = Vector3.MoveTowards(base.transform.position, this.currentEnd, this.speed * Time.deltaTime);
			if (Vector3.Distance(base.transform.position, this.currentEnd) < 0.01f)
			{
				this.flying = false;
				if (this.loop)
				{
					this.resetTimer = this.resetDelay;
					return;
				}
			}
		}
		else if (this.loop)
		{
			this.resetTimer -= Time.deltaTime;
			if (this.resetTimer <= 0f)
			{
				base.transform.position = this.currentStart;
				this.flying = true;
			}
		}
	}

	// Token: 0x04000009 RID: 9
	[Header("Flight Path")]
	public Transform startPoint;

	// Token: 0x0400000A RID: 10
	public Transform endPoint;

	// Token: 0x0400000B RID: 11
	[Header("Flight Settings")]
	public float speed = 5f;

	// Token: 0x0400000C RID: 12
	public bool loop;

	// Token: 0x0400000D RID: 13
	public float resetDelay = 1f;

	// Token: 0x0400000E RID: 14
	private Vector3 currentStart;

	// Token: 0x0400000F RID: 15
	private Vector3 currentEnd;

	// Token: 0x04000010 RID: 16
	private bool flying;

	// Token: 0x04000011 RID: 17
	private float resetTimer;
}
