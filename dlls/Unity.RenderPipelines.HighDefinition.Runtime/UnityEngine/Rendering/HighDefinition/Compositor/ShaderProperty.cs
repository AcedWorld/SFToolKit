using System;

namespace UnityEngine.Rendering.HighDefinition.Compositor
{
	// Token: 0x02000245 RID: 581
	[Serializable]
	internal class ShaderProperty
	{
		// Token: 0x0600109D RID: 4253 RVA: 0x0007FA9C File Offset: 0x0007DC9C
		public static ShaderProperty Create(Shader shader, Material material, int index)
		{
			ShaderProperty shaderProperty = new ShaderProperty();
			shaderProperty.propertyName = shader.GetPropertyName(index);
			shaderProperty.propertyType = shader.GetPropertyType(index);
			shaderProperty.flags = shader.GetPropertyFlags(index);
			shaderProperty.value = Vector4.zero;
			shaderProperty.canBeUsedAsRT = false;
			if (shaderProperty.propertyType == ShaderPropertyType.Texture)
			{
				string text;
				int num;
				shader.FindTextureStack(index, out text, out num);
				shaderProperty.canBeUsedAsRT = (text.Length == 0);
				shaderProperty.canBeUsedAsRT &= (shader.GetPropertyTextureDimension(index) == TextureDimension.Tex2D);
			}
			if (shaderProperty.propertyType == ShaderPropertyType.Range)
			{
				shaderProperty.rangeLimits = shader.GetPropertyRangeLimits(index);
				shaderProperty.value = new Vector4(material.GetFloat(Shader.PropertyToID(shader.GetPropertyName(index))), 0f, 0f, 0f);
			}
			else if (shaderProperty.propertyType == ShaderPropertyType.Color)
			{
				shaderProperty.value = material.GetColor(Shader.PropertyToID(shader.GetPropertyName(index)));
			}
			else if (shaderProperty.propertyType == ShaderPropertyType.Vector)
			{
				shaderProperty.value = material.GetVector(Shader.PropertyToID(shader.GetPropertyName(index)));
			}
			return shaderProperty;
		}

		// Token: 0x040019BF RID: 6591
		public string propertyName;

		// Token: 0x040019C0 RID: 6592
		public ShaderPropertyType propertyType;

		// Token: 0x040019C1 RID: 6593
		public Vector4 value;

		// Token: 0x040019C2 RID: 6594
		public Vector2 rangeLimits;

		// Token: 0x040019C3 RID: 6595
		public ShaderPropertyFlags flags;

		// Token: 0x040019C4 RID: 6596
		public bool canBeUsedAsRT;
	}
}
