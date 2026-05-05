using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering.HighDefinition.Compositor
{
	// Token: 0x02000242 RID: 578
	internal class CompositionProfile : ScriptableObject
	{
		// Token: 0x0600108E RID: 4238 RVA: 0x0007F314 File Offset: 0x0007D514
		public void AddPropertiesFromShaderAndMaterial(CompositionManager compositor, Shader shader, Material material)
		{
			CompositionProfile.<>c__DisplayClass1_0 CS$<>8__locals1 = new CompositionProfile.<>c__DisplayClass1_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.compositor = compositor;
			List<string> list = new List<string>();
			int propertyCount = shader.GetPropertyCount();
			for (int i = 0; i < propertyCount; i++)
			{
				ShaderProperty shaderProperty = ShaderProperty.Create(shader, material, i);
				this.AddShaderProperty(CS$<>8__locals1.compositor, shaderProperty);
				list.Add(shaderProperty.propertyName);
			}
			int l;
			int k;
			for (l = this.m_ShaderProperties.Count - 1; l >= 0; l = k)
			{
				if (list.FindIndex((string x) => x == CS$<>8__locals1.<>4__this.m_ShaderProperties[l].propertyName) < 0)
				{
					this.m_ShaderProperties.RemoveAt(l);
				}
				k = l - 1;
			}
			int j;
			for (j = CS$<>8__locals1.compositor.layers.Count - 1; j >= 0; j = k)
			{
				if (CS$<>8__locals1.compositor.layers[j].outputTarget != CompositorLayer.OutputTarget.CameraStack && list.FindIndex((string x) => x == CS$<>8__locals1.compositor.layers[j].name) < 0)
				{
					CS$<>8__locals1.compositor.RemoveLayerAtIndex(j);
				}
				k = j - 1;
			}
		}

		// Token: 0x0600108F RID: 4239 RVA: 0x0007F480 File Offset: 0x0007D680
		public void AddShaderProperty(CompositionManager compositor, ShaderProperty sp)
		{
			bool flag = (sp.flags & ShaderPropertyFlags.NonModifiableTextureData) != ShaderPropertyFlags.None || (sp.flags & ShaderPropertyFlags.HideInInspector) > ShaderPropertyFlags.None;
			if (!flag && this.m_ShaderProperties.FindIndex((ShaderProperty s) => s.propertyName == sp.propertyName) < 0)
			{
				this.m_ShaderProperties.Add(sp);
			}
			if (sp.propertyType == ShaderPropertyType.Texture && sp.canBeUsedAsRT)
			{
				int num = compositor.layers.FindIndex((CompositorLayer s) => s.name == sp.propertyName);
				if (num < 0 && !flag)
				{
					CompositorLayer item = CompositorLayer.CreateOutputLayer(sp.propertyName);
					compositor.layers.Add(item);
					return;
				}
				if (num >= 0 && flag)
				{
					compositor.RemoveLayerAtIndex(num);
				}
			}
		}

		// Token: 0x06001090 RID: 4240 RVA: 0x0007F558 File Offset: 0x0007D758
		public void CopyPropertiesToMaterial(Material material)
		{
			foreach (ShaderProperty shaderProperty in this.m_ShaderProperties)
			{
				if (shaderProperty.propertyType == ShaderPropertyType.Float)
				{
					material.SetFloat(shaderProperty.propertyName, shaderProperty.value.x);
				}
				else if (shaderProperty.propertyType == ShaderPropertyType.Vector)
				{
					material.SetVector(shaderProperty.propertyName, shaderProperty.value);
				}
				else if (shaderProperty.propertyType == ShaderPropertyType.Range)
				{
					material.SetFloat(shaderProperty.propertyName, shaderProperty.value.x);
				}
				else if (shaderProperty.propertyType == ShaderPropertyType.Color)
				{
					material.SetColor(shaderProperty.propertyName, shaderProperty.value);
				}
			}
		}

		// Token: 0x040019BB RID: 6587
		[SerializeField]
		private List<ShaderProperty> m_ShaderProperties = new List<ShaderProperty>();
	}
}
