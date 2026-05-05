using System;
using Invector.vCharacterController;
using UnityEngine;

namespace Invector.Utils
{
	// Token: 0x020003AF RID: 943
	[vClassHeader("Load Level", true, "icon_v2", false, "", openClose = false)]
	public class vLoadLevel : vMonoBehaviour
	{
		// Token: 0x060012E1 RID: 4833 RVA: 0x0006413C File Offset: 0x0006233C
		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				vThirdPersonInput component = other.transform.gameObject.GetComponent<vThirdPersonInput>();
				LoadLevelHelper.LoadScene(this.levelToLoad, this.spawnPointName, component);
			}
		}

		// Token: 0x040018B9 RID: 6329
		[Tooltip("Write the name of the level you want to load")]
		public string levelToLoad;

		// Token: 0x040018BA RID: 6330
		[Tooltip("Assign here the spawnPoint name of the scene that you will load")]
		public string spawnPointName;
	}
}
