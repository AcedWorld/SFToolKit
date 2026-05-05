using System;
using System.Collections.Generic;
using UnityEngine;

namespace Invector
{
	// Token: 0x02000340 RID: 832
	[Serializable]
	public abstract class vFootStepBase : MonoBehaviour
	{
		// Token: 0x06001119 RID: 4377 RVA: 0x0005CD5C File Offset: 0x0005AF5C
		public virtual void SpawnSurfaceEffect(FootStepObject footStepObject)
		{
			if (footStepObject != null)
			{
				for (int i = 0; i < this.customSurfaces.Count; i++)
				{
					if (this.customSurfaces[i] != null && this.ContainsTexture(footStepObject.name, this.customSurfaces[i]))
					{
						this.customSurfaces[i].SpawnSurfaceEffect(footStepObject);
						return;
					}
				}
			}
			if (this.defaultSurface != null)
			{
				this.defaultSurface.SpawnSurfaceEffect(footStepObject);
			}
		}

		// Token: 0x0600111A RID: 4378 RVA: 0x0005CDE0 File Offset: 0x0005AFE0
		protected virtual bool ContainsTexture(string name, vAudioSurface surface)
		{
			for (int i = 0; i < surface.TextureOrMaterialNames.Count; i++)
			{
				if (name.Contains(surface.TextureOrMaterialNames[i]))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600111B RID: 4379
		public abstract void StepOnTerrain(FootStepObject footStepObject);

		// Token: 0x0600111C RID: 4380
		public abstract void StepOnMesh(FootStepObject footStepObject);

		// Token: 0x0600111D RID: 4381
		public abstract void PlayFootStepEffect();

		// Token: 0x0600111E RID: 4382 RVA: 0x000020BE File Offset: 0x000002BE
		public virtual void PlayFootStep(AnimationEvent evt)
		{
		}

		// Token: 0x0600111F RID: 4383 RVA: 0x000020BE File Offset: 0x000002BE
		public virtual void PlayFootStepLeft(AnimationEvent evt)
		{
		}

		// Token: 0x06001120 RID: 4384 RVA: 0x000020BE File Offset: 0x000002BE
		public virtual void PlayFootStepRight(AnimationEvent evt)
		{
		}

		// Token: 0x040016FB RID: 5883
		public vAudioSurface defaultSurface;

		// Token: 0x040016FC RID: 5884
		public List<vAudioSurface> customSurfaces;
	}
}
