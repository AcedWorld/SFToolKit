using System;
using UnityEngine;

namespace Invector
{
	// Token: 0x02000346 RID: 838
	public class FootStepObject
	{
		// Token: 0x17000340 RID: 832
		// (get) Token: 0x0600113C RID: 4412 RVA: 0x0005D693 File Offset: 0x0005B893
		public bool isTerrain
		{
			get
			{
				return this.terrain != null;
			}
		}

		// Token: 0x0600113D RID: 4413 RVA: 0x0005D6A4 File Offset: 0x0005B8A4
		public FootStepObject(Transform sender, Collider ground)
		{
			this.name = "";
			this.sender = sender;
			this.ground = ground;
			this.terrain = ground.GetComponent<Terrain>();
			this.stepHandle = ground.GetComponent<vFootStepHandler>();
			this.renderer = ground.GetComponent<Renderer>();
			this.spawnSoundEffect = true;
			this.spawnStepMarkEffect = true;
			this.spawnParticleEffect = true;
			this.volume = 1f;
			if (this.renderer != null && this.renderer.material != null)
			{
				int num = 0;
				this.name = string.Empty;
				if (this.stepHandle != null && this.stepHandle.material_ID > 0)
				{
					num = this.stepHandle.material_ID;
				}
				if (this.stepHandle)
				{
					vFootStepHandler.StepHandleType stepHandleType = this.stepHandle.stepHandleType;
					if (stepHandleType == vFootStepHandler.StepHandleType.materialName)
					{
						this.name = this.renderer.materials[num].name;
						return;
					}
					if (stepHandleType != vFootStepHandler.StepHandleType.textureName)
					{
						return;
					}
					this.name = this.renderer.materials[num].mainTexture.name;
					return;
				}
				else
				{
					this.name = this.renderer.materials[num].name;
				}
			}
		}

		// Token: 0x0400171A RID: 5914
		public string name;

		// Token: 0x0400171B RID: 5915
		public Transform sender;

		// Token: 0x0400171C RID: 5916
		public Collider ground;

		// Token: 0x0400171D RID: 5917
		public Terrain terrain;

		// Token: 0x0400171E RID: 5918
		public vFootStepHandler stepHandle;

		// Token: 0x0400171F RID: 5919
		public Renderer renderer;

		// Token: 0x04001720 RID: 5920
		public bool spawnSoundEffect;

		// Token: 0x04001721 RID: 5921
		public bool spawnStepMarkEffect;

		// Token: 0x04001722 RID: 5922
		public bool spawnParticleEffect;

		// Token: 0x04001723 RID: 5923
		public float volume;
	}
}
