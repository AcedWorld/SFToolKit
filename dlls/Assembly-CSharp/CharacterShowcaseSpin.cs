using System;
using UnityEngine;

// Token: 0x02000005 RID: 5
public class CharacterShowcaseSpin : MonoBehaviour
{
	// Token: 0x06000010 RID: 16 RVA: 0x00002358 File Offset: 0x00000558
	private void Update()
	{
		base.transform.Rotate(Vector3.up * this.rotationSpeed * Time.deltaTime);
	}

	// Token: 0x04000012 RID: 18
	public float rotationSpeed = 10f;
}
