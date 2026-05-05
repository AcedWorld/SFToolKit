using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x0200016D RID: 365
public class MapButtonLogic : MonoBehaviour
{
	// Token: 0x060005E4 RID: 1508 RVA: 0x0002B730 File Offset: 0x00029930
	private void Start()
	{
		this.button = base.GetComponent<Button>();
		this.button.onClick.AddListener(new UnityAction(this.loadPark));
	}

	// Token: 0x060005E5 RID: 1509 RVA: 0x0002B75A File Offset: 0x0002995A
	private void loadPark()
	{
		this.mapLoadBrain.MapTitle = this.mapTitle;
		this.mapLoadBrain.sceneName = this.sceneName;
		this.mapLoadBrain.buttonPressed();
	}

	// Token: 0x040009CA RID: 2506
	public MapLoadBrain mapLoadBrain;

	// Token: 0x040009CB RID: 2507
	public string sceneName;

	// Token: 0x040009CC RID: 2508
	public string mapTitle;

	// Token: 0x040009CD RID: 2509
	private Button button;
}
