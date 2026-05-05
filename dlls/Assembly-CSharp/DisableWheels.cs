using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200014A RID: 330
public class DisableWheels : MonoBehaviour
{
	// Token: 0x06000543 RID: 1347 RVA: 0x00024337 File Offset: 0x00022537
	public void ResetWheelColliders()
	{
		this.frontWheel.SetActive(false);
		this.rearWheel.SetActive(false);
		base.StartCoroutine(this.Delay());
	}

	// Token: 0x06000544 RID: 1348 RVA: 0x0002435E File Offset: 0x0002255E
	private IEnumerator Delay()
	{
		yield return new WaitForSecondsRealtime(0.5f);
		this.EnableWheelColliders();
		yield break;
	}

	// Token: 0x06000545 RID: 1349 RVA: 0x0002436D File Offset: 0x0002256D
	private void EnableWheelColliders()
	{
		this.frontWheel.SetActive(true);
		this.rearWheel.SetActive(true);
	}

	// Token: 0x04000848 RID: 2120
	public GameObject frontWheel;

	// Token: 0x04000849 RID: 2121
	public GameObject rearWheel;
}
