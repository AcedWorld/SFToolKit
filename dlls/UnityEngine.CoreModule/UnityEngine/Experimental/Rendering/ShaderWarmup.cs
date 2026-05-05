using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.Experimental.Rendering
{
	// Token: 0x020004F0 RID: 1264
	[NativeHeader("Runtime/Graphics/ShaderScriptBindings.h")]
	public static class ShaderWarmup
	{
		// Token: 0x06002BD2 RID: 11218 RVA: 0x00049B43 File Offset: 0x00047D43
		[FreeFunction(Name = "ShaderWarmupScripting::WarmupShader")]
		public static void WarmupShader(Shader shader, ShaderWarmupSetup setup)
		{
			ShaderWarmup.WarmupShader_Injected(shader, ref setup);
		}

		// Token: 0x06002BD3 RID: 11219 RVA: 0x00049B4D File Offset: 0x00047D4D
		[FreeFunction(Name = "ShaderWarmupScripting::WarmupShaderFromCollection")]
		public static void WarmupShaderFromCollection(ShaderVariantCollection collection, Shader shader, ShaderWarmupSetup setup)
		{
			ShaderWarmup.WarmupShaderFromCollection_Injected(collection, shader, ref setup);
		}

		// Token: 0x06002BD4 RID: 11220
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void WarmupShader_Injected(Shader shader, ref ShaderWarmupSetup setup);

		// Token: 0x06002BD5 RID: 11221
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void WarmupShaderFromCollection_Injected(ShaderVariantCollection collection, Shader shader, ref ShaderWarmupSetup setup);
	}
}
