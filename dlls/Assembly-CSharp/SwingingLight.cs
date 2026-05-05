using System;
using System.Collections;
using UnityEngine;

// Token: 0x020001F5 RID: 501
public class SwingingLight : MonoBehaviour
{
	// Token: 0x060007D5 RID: 2005 RVA: 0x00038AD2 File Offset: 0x00036CD2
	private void Start()
	{
		this.initialRotation = base.transform.localEulerAngles;
		if (this.lightComponent == null)
		{
			this.lightComponent = base.GetComponentInChildren<Light>();
		}
	}

	// Token: 0x060007D6 RID: 2006 RVA: 0x00038B00 File Offset: 0x00036D00
	private void FixedUpdate()
	{
		float num = Mathf.Sin(Time.time * this.swingSpeed) * this.swingAngle;
		float num2 = Mathf.Cos(Time.time * this.swingSpeed) * this.swingAngle;
		base.transform.localEulerAngles = new Vector3(this.initialRotation.x + num, this.initialRotation.y, this.initialRotation.z + num2);
		this.FlickerLight();
	}

	// Token: 0x060007D7 RID: 2007 RVA: 0x00038B7C File Offset: 0x00036D7C
	private void FlickerLight()
	{
		this.flickerTimer += Time.deltaTime;
		if (this.flickerTimer >= this.flickerInterval)
		{
			if (this.lightComponent != null)
			{
				base.StartCoroutine(this.FlickerSequenceCoroutine());
			}
			this.flickerTimer = 0f;
		}
	}

	// Token: 0x060007D8 RID: 2008 RVA: 0x00038BCF File Offset: 0x00036DCF
	private IEnumerator FlickerSequenceCoroutine()
	{
		int num;
		for (int i = 0; i < this.flickerCount; i = num + 1)
		{
			this.lightComponent.enabled = false;
			yield return new WaitForSeconds(this.flickerDuration);
			this.lightComponent.enabled = true;
			yield return new WaitForSeconds(this.flickerDuration);
			num = i;
		}
		yield break;
	}

	// Token: 0x04000D94 RID: 3476
	public float swingSpeed = 1f;

	// Token: 0x04000D95 RID: 3477
	public float swingAngle = 5f;

	// Token: 0x04000D96 RID: 3478
	public Light lightComponent;

	// Token: 0x04000D97 RID: 3479
	public float flickerInterval = 2f;

	// Token: 0x04000D98 RID: 3480
	public float flickerDuration = 0.1f;

	// Token: 0x04000D99 RID: 3481
	public int flickerCount = 3;

	// Token: 0x04000D9A RID: 3482
	private Vector3 initialRotation;

	// Token: 0x04000D9B RID: 3483
	private float flickerTimer;
}
