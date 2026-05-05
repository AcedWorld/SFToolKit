using System;
using System.Collections;
using Invector.vCharacterController;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Invector
{
	// Token: 0x0200033A RID: 826
	[vClassHeader("Simple GameController Example", true, "icon_v2", false, "", openClose = false)]
	public class vGameController : vMonoBehaviour
	{
		// Token: 0x060010F8 RID: 4344 RVA: 0x0005BF74 File Offset: 0x0005A174
		protected virtual void Start()
		{
			if (vGameController.instance == null)
			{
				vGameController.instance = this;
				if (this.dontDestroyOnLoad)
				{
					Object.DontDestroyOnLoad(base.gameObject);
				}
				base.gameObject.name = base.gameObject.name + " Instance";
				SceneManager.sceneLoaded += this.OnLevelFinishedLoading;
				if (this.displayInfoInFadeText && vHUDController.instance)
				{
					vHUDController.instance.ShowText("Init Scene");
				}
				this.FindPlayer();
				return;
			}
			Object.Destroy(base.gameObject);
		}

		// Token: 0x060010F9 RID: 4345 RVA: 0x0005C010 File Offset: 0x0005A210
		public virtual void ShowCursor(bool value)
		{
			Cursor.visible = value;
		}

		// Token: 0x060010FA RID: 4346 RVA: 0x0005C018 File Offset: 0x0005A218
		public virtual void LockCursor(bool value)
		{
			if (value)
			{
				Cursor.lockState = CursorLockMode.Locked;
				return;
			}
			Cursor.lockState = CursorLockMode.None;
		}

		// Token: 0x060010FB RID: 4347 RVA: 0x0005C02C File Offset: 0x0005A22C
		protected virtual void OnCharacterDead(GameObject _gameObject)
		{
			this.oldPlayer = _gameObject;
			if (this.playerPrefab != null)
			{
				base.StartCoroutine(this.RespawnRoutine());
				return;
			}
			if (this.displayInfoInFadeText && vHUDController.instance)
			{
				vHUDController.instance.ShowText("Restarting Scene...");
			}
			base.Invoke("ResetScene", this.respawnTimer);
		}

		// Token: 0x060010FC RID: 4348 RVA: 0x0005C090 File Offset: 0x0005A290
		protected virtual IEnumerator RespawnRoutine()
		{
			yield return new WaitForSeconds(this.respawnTimer);
			if (this.playerPrefab != null && this.spawnPoint != null)
			{
				if (this.oldPlayer != null && this.destroyBodyAfterDead)
				{
					if (this.displayInfoInFadeText && vHUDController.instance)
					{
						vHUDController.instance.ShowText("Player destroyed: " + this.oldPlayer.name.Replace("(Clone)", "").Replace("Instance", ""));
					}
					Object.Destroy(this.oldPlayer);
				}
				else
				{
					if (this.displayInfoInFadeText && vHUDController.instance)
					{
						vHUDController.instance.ShowText("Remove Player Components: " + this.oldPlayer.name.Replace("(Clone)", "").Replace("Instance", ""));
					}
					this.DestroyPlayerComponents(this.oldPlayer);
				}
				yield return new WaitForEndOfFrame();
				this.currentPlayer = Object.Instantiate<GameObject>(this.playerPrefab, this.spawnPoint.position, this.spawnPoint.rotation);
				this.currentController = this.currentPlayer.GetComponent<vThirdPersonController>();
				this.currentController.onDead.AddListener(new UnityAction<GameObject>(this.OnCharacterDead));
				if (this.displayInfoInFadeText && vHUDController.instance)
				{
					vHUDController.instance.ShowText("Respawn player: " + this.currentPlayer.name.Replace("(Clone)", ""));
				}
				this.OnReloadGame.Invoke();
				this.onSpawn.Invoke();
			}
			yield break;
		}

		// Token: 0x060010FD RID: 4349 RVA: 0x0005C0A0 File Offset: 0x0005A2A0
		protected virtual void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
		{
			if (this.currentController == null)
			{
				return;
			}
			if (this.currentController.currentHealth > 0f)
			{
				if (this.displayInfoInFadeText && vHUDController.instance)
				{
					vHUDController.instance.ShowText("Load Scene: " + scene.name);
				}
				return;
			}
			if (this.displayInfoInFadeText && vHUDController.instance)
			{
				vHUDController.instance.ShowText("Reload Scene");
			}
			this.OnReloadGame.Invoke();
			this.FindPlayer();
		}

		// Token: 0x060010FE RID: 4350 RVA: 0x0005C134 File Offset: 0x0005A334
		protected virtual void FindPlayer()
		{
			vThirdPersonController vThirdPersonController = Object.FindObjectOfType<vThirdPersonController>();
			if (vThirdPersonController)
			{
				this.currentPlayer = vThirdPersonController.gameObject;
				this.currentController = vThirdPersonController;
				vThirdPersonController.onDead.AddListener(new UnityAction<GameObject>(this.OnCharacterDead));
				if (this.displayInfoInFadeText && vHUDController.instance)
				{
					vHUDController.instance.ShowText("Found player: " + this.currentPlayer.name.Replace("(Clone)", "").Replace("Instance", ""));
					return;
				}
			}
			else if (this.currentPlayer == null && this.playerPrefab != null && this.spawnPoint != null)
			{
				this.SpawnAtPoint(this.spawnPoint);
			}
		}

		// Token: 0x060010FF RID: 4351 RVA: 0x0005C208 File Offset: 0x0005A408
		protected virtual void DestroyPlayerComponents(GameObject target)
		{
			if (!target)
			{
				return;
			}
			MonoBehaviour[] componentsInChildren = target.GetComponentsInChildren<MonoBehaviour>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Object.Destroy(componentsInChildren[i]);
			}
			Collider component = target.GetComponent<Collider>();
			if (component != null)
			{
				Object.Destroy(component);
			}
			Rigidbody component2 = target.GetComponent<Rigidbody>();
			if (component2 != null)
			{
				Object.Destroy(component2);
			}
			Animator component3 = target.GetComponent<Animator>();
			if (component3 != null)
			{
				Object.Destroy(component3);
			}
		}

		// Token: 0x06001100 RID: 4352 RVA: 0x0005C282 File Offset: 0x0005A482
		public virtual void SetSpawnSpoint(Transform newSpawnPoint)
		{
			this.spawnPoint = newSpawnPoint;
		}

		// Token: 0x06001101 RID: 4353 RVA: 0x0005C28B File Offset: 0x0005A48B
		public void SetPlayerPrefab(GameObject prefab)
		{
			this.playerPrefab = prefab;
		}

		// Token: 0x06001102 RID: 4354 RVA: 0x0005C294 File Offset: 0x0005A494
		public virtual void SpawnAtPoint(Transform targetPoint)
		{
			if (this.playerPrefab != null)
			{
				if (this.oldPlayer != null && this.destroyBodyAfterDead)
				{
					if (this.displayInfoInFadeText && vHUDController.instance)
					{
						vHUDController.instance.ShowText("Player destroyed: " + this.oldPlayer.name.Replace("(Clone)", "").Replace("Instance", ""));
					}
					Object.Destroy(this.oldPlayer);
				}
				else if (this.oldPlayer != null)
				{
					if (this.displayInfoInFadeText && vHUDController.instance)
					{
						vHUDController.instance.ShowText("Remove Player Components: " + this.oldPlayer.name.Replace("(Clone)", "").Replace("Instance", ""));
					}
					this.DestroyPlayerComponents(this.oldPlayer);
				}
				this.currentPlayer = Object.Instantiate<GameObject>(this.playerPrefab, targetPoint.position, targetPoint.rotation);
				this.currentController = this.currentPlayer.GetComponent<vThirdPersonController>();
				this.currentController.onDead.AddListener(new UnityAction<GameObject>(this.OnCharacterDead));
				this.OnReloadGame.Invoke();
				if (this.displayInfoInFadeText && vHUDController.instance)
				{
					vHUDController.instance.ShowText("Spawn player: " + this.currentPlayer.name.Replace("(Clone)", ""));
				}
			}
		}

		// Token: 0x06001103 RID: 4355 RVA: 0x0005C42C File Offset: 0x0005A62C
		public virtual void SpawnPlayer(GameObject prefab)
		{
			if (prefab != null && this.spawnPoint != null)
			{
				Transform transform = this.spawnPoint;
				if (this.oldPlayer != null && this.destroyBodyAfterDead)
				{
					if (this.displayInfoInFadeText && vHUDController.instance)
					{
						vHUDController.instance.ShowText("Player destroyed: " + this.oldPlayer.name.Replace("(Clone)", "").Replace("Instance", ""));
					}
					Object.Destroy(this.oldPlayer);
				}
				else if (this.oldPlayer != null)
				{
					if (this.displayInfoInFadeText && vHUDController.instance)
					{
						vHUDController.instance.ShowText("Remove Player Components: " + this.oldPlayer.name.Replace("(Clone)", "").Replace("Instance", ""));
					}
					this.DestroyPlayerComponents(this.oldPlayer);
				}
				this.currentPlayer = Object.Instantiate<GameObject>(prefab, transform.position, transform.rotation);
				this.currentController = this.currentPlayer.GetComponent<vThirdPersonController>();
				this.currentController.onDead.AddListener(new UnityAction<GameObject>(this.OnCharacterDead));
				this.OnReloadGame.Invoke();
				if (this.displayInfoInFadeText && vHUDController.instance)
				{
					vHUDController.instance.ShowText("Spawn player: " + this.currentPlayer.name.Replace("(Clone)", ""));
				}
			}
		}

		// Token: 0x06001104 RID: 4356 RVA: 0x0005C5D0 File Offset: 0x0005A7D0
		public virtual void ResetScene()
		{
			if (this.oldPlayer)
			{
				this.DestroyPlayerComponents(this.oldPlayer);
			}
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			if (this.oldPlayer && this.destroyBodyAfterDead)
			{
				Object.Destroy(this.oldPlayer);
			}
		}

		// Token: 0x040016DD RID: 5853
		[vHelpBox("Assign your Character Prefab to be instantiate at the SpawnPoint, leave it unassigned to Restart the Scene instead", vHelpBoxAttribute.MessageType.None)]
		public GameObject playerPrefab;

		// Token: 0x040016DE RID: 5854
		[vHelpBox("Assign a empty transform to spawn the Player to a specific location", vHelpBoxAttribute.MessageType.None)]
		public Transform spawnPoint;

		// Token: 0x040016DF RID: 5855
		[vHelpBox("Time to wait until the scene restart or the player will be spawned again", vHelpBoxAttribute.MessageType.None)]
		public float respawnTimer = 4f;

		// Token: 0x040016E0 RID: 5856
		[vHelpBox("Check this if you want to destroy the dead body after the respawn", vHelpBoxAttribute.MessageType.None)]
		public bool destroyBodyAfterDead;

		// Token: 0x040016E1 RID: 5857
		[vHelpBox("Display a message using the FadeText UI", vHelpBoxAttribute.MessageType.None)]
		public bool displayInfoInFadeText = true;

		// Token: 0x040016E2 RID: 5858
		[HideInInspector]
		public vGameController.OnRealoadGame OnReloadGame = new vGameController.OnRealoadGame();

		// Token: 0x040016E3 RID: 5859
		[HideInInspector]
		public GameObject currentPlayer;

		// Token: 0x040016E4 RID: 5860
		private vThirdPersonController currentController;

		// Token: 0x040016E5 RID: 5861
		public static vGameController instance;

		// Token: 0x040016E6 RID: 5862
		private GameObject oldPlayer;

		// Token: 0x040016E7 RID: 5863
		public UnityEvent onSpawn;

		// Token: 0x040016E8 RID: 5864
		public bool dontDestroyOnLoad = true;

		// Token: 0x0200033B RID: 827
		[Serializable]
		public class OnRealoadGame : UnityEvent
		{
		}
	}
}
