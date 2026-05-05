using System;
using RootMotion.Dynamics;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001B3 RID: 435
	public class Respawning : MonoBehaviour
	{
		// Token: 0x1700014E RID: 334
		// (get) Token: 0x06000BC5 RID: 3013 RVA: 0x00048F2B File Offset: 0x0004712B
		private bool isPooled
		{
			get
			{
				return this.puppet.transform.root == this.pool;
			}
		}

		// Token: 0x06000BC6 RID: 3014 RVA: 0x00048F48 File Offset: 0x00047148
		private void Start()
		{
			this.puppetRoot = this.puppet.transform.root;
			this.pool.gameObject.SetActive(false);
		}

		// Token: 0x06000BC7 RID: 3015 RVA: 0x00048F74 File Offset: 0x00047174
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				this.puppet.puppetMaster.state = PuppetMaster.State.Alive;
			}
			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				this.puppet.puppetMaster.state = PuppetMaster.State.Dead;
			}
			if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				this.puppet.puppetMaster.state = PuppetMaster.State.Frozen;
			}
			if (Input.GetKeyDown(KeyCode.P) && !this.isPooled)
			{
				this.Pool();
			}
			if (Input.GetKeyDown(KeyCode.R))
			{
				Vector2 vector = Random.insideUnitCircle * 2f;
				this.Respawn(new Vector3(vector.x, 0f, vector.y), Quaternion.LookRotation(new Vector3(-vector.x, 0f, -vector.y)));
			}
		}

		// Token: 0x06000BC8 RID: 3016 RVA: 0x00049038 File Offset: 0x00047238
		private void Pool()
		{
			this.puppetRoot.parent = this.pool;
		}

		// Token: 0x06000BC9 RID: 3017 RVA: 0x0004904C File Offset: 0x0004724C
		private void Respawn(Vector3 position, Quaternion rotation)
		{
			this.puppet.puppetMaster.state = PuppetMaster.State.Alive;
			if (this.puppet.puppetMaster.targetAnimator.gameObject.activeInHierarchy)
			{
				this.puppet.puppetMaster.targetAnimator.Play(this.idleAnimation, 0, 0f);
			}
			this.puppet.SetState(BehaviourPuppet.State.Puppet);
			this.puppet.puppetMaster.Teleport(position, rotation, true);
			this.puppetRoot.parent = null;
		}

		// Token: 0x04000BD7 RID: 3031
		[Tooltip("Pooled characters will be parented to this deactivated GameObject.")]
		public Transform pool;

		// Token: 0x04000BD8 RID: 3032
		[Tooltip("Reference to the BehaviourPuppet component of the character you wish to respawn.")]
		public BehaviourPuppet puppet;

		// Token: 0x04000BD9 RID: 3033
		[Tooltip("The animation to play on respawn.")]
		public string idleAnimation;

		// Token: 0x04000BDA RID: 3034
		private Transform puppetRoot;
	}
}
