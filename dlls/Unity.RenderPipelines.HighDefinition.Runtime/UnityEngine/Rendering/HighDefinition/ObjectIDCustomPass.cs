using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001A5 RID: 421
	[Serializable]
	public class ObjectIDCustomPass : DrawRenderersCustomPass
	{
		// Token: 0x06000D3A RID: 3386 RVA: 0x0006C658 File Offset: 0x0006A858
		protected override void Setup(ScriptableRenderContext renderContext, CommandBuffer cmd)
		{
			base.Setup(renderContext, cmd);
			this.AssignObjectIDs();
			this.overrideMaterial = CoreUtils.CreateEngineMaterial(HDRenderPipelineGlobalSettings.instance.renderPipelineResources.shaderGraphs.objectIDPS);
			this.overrideMaterialPassName = "ForwardOnly";
		}

		// Token: 0x06000D3B RID: 3387 RVA: 0x0006C694 File Offset: 0x0006A894
		public virtual void AssignObjectIDs()
		{
			int sceneCount = SceneManager.sceneCount;
			List<Renderer> list = new List<Renderer>();
			for (int i = 0; i < sceneCount; i++)
			{
				Scene sceneAt = SceneManager.GetSceneAt(i);
				if (sceneAt.IsValid() && sceneAt.isLoaded)
				{
					foreach (GameObject gameObject in sceneAt.GetRootGameObjects())
					{
						list.AddRange(gameObject.GetComponentsInChildren<Renderer>());
					}
				}
			}
			int count = list.Count;
			for (int k = 0; k < count; k++)
			{
				Renderer renderer = list[k];
				MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
				float h = (float)(k * 3 % count) / (float)count;
				materialPropertyBlock.SetColor(ObjectIDCustomPass.k_ObjectColor, Color.HSVToRGB(h, 0.7f, 1f));
				renderer.SetPropertyBlock(materialPropertyBlock);
			}
		}

		// Token: 0x04001442 RID: 5186
		private static readonly int k_ObjectColor = Shader.PropertyToID("ObjectColor");
	}
}
