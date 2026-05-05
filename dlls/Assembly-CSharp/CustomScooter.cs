using System;
using UnityEngine;

// Token: 0x02000107 RID: 263
[CreateAssetMenu(fileName = "New Custom Scooters", menuName = "ScooterFlow/Custom Scooters")]
public class CustomScooter : ScriptableObject
{
	// Token: 0x17000035 RID: 53
	// (get) Token: 0x06000469 RID: 1129 RVA: 0x0001E9F8 File Offset: 0x0001CBF8
	public CustomScooterData ActiveScooter
	{
		get
		{
			int num = Mathf.Clamp(this.activeSlot, 1, 3);
			if (num == 1)
			{
				return this.scooter1;
			}
			if (num != 2)
			{
				return this.scooter3;
			}
			return this.scooter2;
		}
	}

	// Token: 0x04000665 RID: 1637
	[Header("Selection")]
	[Range(1f, 3f)]
	public int activeSlot = 1;

	// Token: 0x04000666 RID: 1638
	[Header("Custom Scooter 1")]
	public CustomScooterData scooter1 = new CustomScooterData();

	// Token: 0x04000667 RID: 1639
	[Header("Custom Scooter 2")]
	public CustomScooterData scooter2 = new CustomScooterData();

	// Token: 0x04000668 RID: 1640
	[Header("Custom Scooter 3")]
	public CustomScooterData scooter3 = new CustomScooterData();
}
