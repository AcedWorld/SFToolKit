using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Invector.vCharacterController
{
	// Token: 0x020003FF RID: 1023
	public class vFindSpawnPoint : MonoBehaviour
	{
		// Token: 0x060014E9 RID: 5353 RVA: 0x0006CDD9 File Offset: 0x0006AFD9
		public void AlighObjetToSpawnPoint(GameObject target, string spawnPointName)
		{
			this.target = target;
			this.spawnPointName = spawnPointName;
			SceneManager.sceneLoaded += this.OnLevelFinishedLoading;
			Object.DontDestroyOnLoad(base.gameObject);
		}

		// Token: 0x060014EA RID: 5354 RVA: 0x0006CE08 File Offset: 0x0006B008
		private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
		{
			GameObject gameObject = GameObject.Find(this.spawnPointName);
			if (gameObject && this.target)
			{
				this.target.transform.position = gameObject.transform.position;
				this.target.transform.rotation = gameObject.transform.rotation;
				return;
			}
			try
			{
				Object.Destroy(base.gameObject);
			}
			catch
			{
			}
		}

		// Token: 0x04001AA8 RID: 6824
		public Transform spawnPoint;

		// Token: 0x04001AA9 RID: 6825
		public string spawnPointName;

		// Token: 0x04001AAA RID: 6826
		public GameObject target;
	}
}
