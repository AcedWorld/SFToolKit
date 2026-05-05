using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000165 RID: 357
public class LoadScene : MonoBehaviour
{
	// Token: 0x060005CD RID: 1485 RVA: 0x00029ABE File Offset: 0x00027CBE
	public void LoadSceneName()
	{
		SceneManager.LoadSceneAsync(this.sceneName);
	}

	// Token: 0x04000966 RID: 2406
	public string sceneName;
}
