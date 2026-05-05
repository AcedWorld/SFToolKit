using System;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x02000130 RID: 304
public class CheatCode : MonoBehaviour
{
	// Token: 0x060004EA RID: 1258 RVA: 0x000221AD File Offset: 0x000203AD
	private void Start()
	{
		this.index = 0;
	}

	// Token: 0x060004EB RID: 1259 RVA: 0x000221B8 File Offset: 0x000203B8
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
			this.CheatActivated();
			this.index = 0;
		}
	}

	// Token: 0x060004EC RID: 1260 RVA: 0x00022214 File Offset: 0x00020414
	private void CheatActivated()
	{
		this.onCheatActivated.Invoke();
		Debug.Log("Cheat Code Activated");
	}

	// Token: 0x040007BA RID: 1978
	[SerializeField]
	private string[] cheatCode;

	// Token: 0x040007BB RID: 1979
	[SerializeField]
	private UnityEvent onCheatActivated;

	// Token: 0x040007BC RID: 1980
	private int index;
}
