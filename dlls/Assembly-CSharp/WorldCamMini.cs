using System;
using Cinemachine;
using UnityEngine;

// Token: 0x020001EC RID: 492
public class WorldCamMini : MonoBehaviour
{
	// Token: 0x060007AB RID: 1963 RVA: 0x000382F0 File Offset: 0x000364F0
	private void Start()
	{
		this.cheatCode = new string[]
		{
			"b",
			"i",
			"r",
			"d",
			"s",
			"e",
			"y",
			"e"
		};
		this.index = 0;
		this.cinemachineCollider = this.cinemachineFreeLook.gameObject.GetComponent<CinemachineCollider>();
		this.playerTarget = GameObject.Find("CameraTarget_Parent");
	}

	// Token: 0x060007AC RID: 1964 RVA: 0x00038378 File Offset: 0x00036578
	private void Update()
	{
		if (Input.anyKeyDown)
		{
			if (Input.GetKeyDown(this.cheatCode[this.index]))
			{
				this.index++;
			}
			else
			{
				this.index = 0;
			}
		}
		if (this.index == this.cheatCode.Length)
		{
			this.LoadCheat();
			this.index = 0;
		}
		if (this.isUse)
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, this.playerTarget.transform.position.z - 3f);
		}
	}

	// Token: 0x060007AD RID: 1965 RVA: 0x00038427 File Offset: 0x00036627
	private void LoadCheat()
	{
		this.cinemachineFreeLook.m_Follow = base.transform;
		this.cinemachineFreeLook.m_Lens.FieldOfView = 30f;
		Object.Destroy(this.cinemachineCollider);
	}

	// Token: 0x04000D62 RID: 3426
	private int count;

	// Token: 0x04000D63 RID: 3427
	private int index;

	// Token: 0x04000D64 RID: 3428
	private string[] cheatCode;

	// Token: 0x04000D65 RID: 3429
	public CinemachineFreeLook cinemachineFreeLook;

	// Token: 0x04000D66 RID: 3430
	private CinemachineCollider cinemachineCollider;

	// Token: 0x04000D67 RID: 3431
	public GameObject playerTarget;

	// Token: 0x04000D68 RID: 3432
	public bool isUse;
}
