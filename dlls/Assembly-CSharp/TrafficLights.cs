using System;
using UnityEngine;

// Token: 0x02000017 RID: 23
public class TrafficLights : MonoBehaviour
{
	// Token: 0x06000068 RID: 104 RVA: 0x00006E4C File Offset: 0x0000504C
	private void Start()
	{
		this.countTime = 0f;
		this.step = 0;
		this.tState.status = ((Random.Range(1, 8) < 4) ? 13 : 31);
		this.EnabledObjects(this.tState.status);
		base.InvokeRepeating("Semaforo", (float)Random.Range(0, 4), 1f);
	}

	// Token: 0x06000069 RID: 105 RVA: 0x00006EB0 File Offset: 0x000050B0
	private void Semaforo()
	{
		this.countTime += 1f;
		if (this.step == 0)
		{
			if (this.countTime > 10f)
			{
				this.countTime = 0f;
				this.step = 1;
				if (this.tState.status == 13)
				{
					this.tState.status = 12;
				}
				else if (this.tState.status == 31)
				{
					this.tState.status = 21;
				}
				this.EnabledObjects(this.tState.status);
				return;
			}
		}
		else if (this.step == 1)
		{
			if (this.countTime >= 3f)
			{
				this.countTime = 0f;
				this.step = 2;
				if (this.tState.status == 12)
				{
					this.tState.status = 41;
				}
				else if (this.tState.status == 21)
				{
					this.tState.status = 14;
				}
				this.EnabledObjects(this.tState.status);
				return;
			}
		}
		else if (this.step == 2 && this.countTime >= 3f)
		{
			this.countTime = 0f;
			this.step = 0;
			if (this.tState.status == 14)
			{
				this.tState.status = 13;
			}
			else if (this.tState.status == 41)
			{
				this.tState.status = 31;
			}
			this.EnabledObjects(this.tState.status);
		}
	}

	// Token: 0x0600006A RID: 106 RVA: 0x00007030 File Offset: 0x00005230
	private void EnabledObjects(int habilita)
	{
		this.tState.t12.SetActive(habilita == 12);
		this.tState.t21.SetActive(habilita == 21);
		this.tState.t13.SetActive(habilita == 13);
		this.tState.t31.SetActive(habilita == 31);
		this.tState.t11.SetActive(habilita == 11 || habilita == 14 || habilita == 41);
		this.tState.stop13.SetActive(habilita != 31);
		this.tState.stop31.SetActive(habilita != 13);
	}

	// Token: 0x040000A8 RID: 168
	private float countTime;

	// Token: 0x040000A9 RID: 169
	private int step;

	// Token: 0x040000AA RID: 170
	public TrafficLights.TrafficLightState tState;

	// Token: 0x02000018 RID: 24
	[Serializable]
	public class TrafficLightState
	{
		// Token: 0x040000AB RID: 171
		public int status;

		// Token: 0x040000AC RID: 172
		public GameObject t31;

		// Token: 0x040000AD RID: 173
		public GameObject t13;

		// Token: 0x040000AE RID: 174
		public GameObject t21;

		// Token: 0x040000AF RID: 175
		public GameObject t12;

		// Token: 0x040000B0 RID: 176
		public GameObject t11;

		// Token: 0x040000B1 RID: 177
		public GameObject stop31;

		// Token: 0x040000B2 RID: 178
		public GameObject stop13;
	}
}
