using System;
using UnityEngine;

// Token: 0x02000042 RID: 66
public class vDebugUtils : MonoBehaviour
{
	// Token: 0x060000F9 RID: 249 RVA: 0x00008EF2 File Offset: 0x000070F2
	private void Start()
	{
		this.currentFixedDeltaTime = Time.fixedDeltaTime;
	}

	// Token: 0x060000FA RID: 250 RVA: 0x00008F00 File Offset: 0x00007100
	private void Update()
	{
		if (Input.GetKeyDown(this.timeScaleDown))
		{
			Time.timeScale = Mathf.Clamp(Time.timeScale - this.timeScaleChangeValue, 0f, 1f);
			if (this.affectFixedDeltaTime)
			{
				Time.fixedDeltaTime = Time.timeScale * this.currentFixedDeltaTime;
				return;
			}
		}
		else if (Input.GetKeyDown(this.timeScaleUp))
		{
			Time.timeScale = Mathf.Clamp(Time.timeScale + this.timeScaleChangeValue, 0f, 1f);
			if (this.affectFixedDeltaTime)
			{
				Time.fixedDeltaTime = Time.timeScale * this.currentFixedDeltaTime;
			}
		}
	}

	// Token: 0x060000FB RID: 251 RVA: 0x00008F9C File Offset: 0x0000719C
	private void OnGUI()
	{
		GUILayout.Label("TimeScale:" + Time.timeScale.ToString(), Array.Empty<GUILayoutOption>());
	}

	// Token: 0x04000128 RID: 296
	public KeyCode timeScaleDown = KeyCode.KeypadMinus;

	// Token: 0x04000129 RID: 297
	public KeyCode timeScaleUp = KeyCode.KeypadPlus;

	// Token: 0x0400012A RID: 298
	public float timeScaleChangeValue = 0.1f;

	// Token: 0x0400012B RID: 299
	public bool affectFixedDeltaTime = true;

	// Token: 0x0400012C RID: 300
	private float currentFixedDeltaTime;
}
