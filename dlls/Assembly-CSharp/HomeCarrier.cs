using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000049 RID: 73
public class HomeCarrier : MonoBehaviour
{
	// Token: 0x0600010A RID: 266 RVA: 0x00009206 File Offset: 0x00007406
	public void Start()
	{
		SceneManager.LoadScene("NewMenu", LoadSceneMode.Single);
	}
}
