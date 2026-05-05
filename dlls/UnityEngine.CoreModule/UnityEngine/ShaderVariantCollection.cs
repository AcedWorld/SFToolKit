using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Rendering;

namespace UnityEngine
{
	// Token: 0x0200027F RID: 639
	public sealed class ShaderVariantCollection : Object
	{
		// Token: 0x170004EF RID: 1263
		// (get) Token: 0x06001AAA RID: 6826
		public extern int shaderCount { [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170004F0 RID: 1264
		// (get) Token: 0x06001AAB RID: 6827
		public extern int variantCount { [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170004F1 RID: 1265
		// (get) Token: 0x06001AAC RID: 6828
		public extern int warmedUpVariantCount { [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170004F2 RID: 1266
		// (get) Token: 0x06001AAD RID: 6829
		public extern bool isWarmedUp { [NativeName("IsWarmedUp")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06001AAE RID: 6830
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool AddVariant(Shader shader, PassType passType, [Unmarshalled] string[] keywords);

		// Token: 0x06001AAF RID: 6831
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool RemoveVariant(Shader shader, PassType passType, [Unmarshalled] string[] keywords);

		// Token: 0x06001AB0 RID: 6832
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool ContainsVariant(Shader shader, PassType passType, [Unmarshalled] string[] keywords);

		// Token: 0x06001AB1 RID: 6833
		[NativeName("ClearVariants")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void Clear();

		// Token: 0x06001AB2 RID: 6834
		[NativeName("WarmupShaders")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void WarmUp();

		// Token: 0x06001AB3 RID: 6835
		[NativeName("WarmupShadersProgressively")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern bool WarmUpProgressively(int variantCount);

		// Token: 0x06001AB4 RID: 6836
		[NativeName("CreateFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_Create([Writable] ShaderVariantCollection svc);

		// Token: 0x06001AB5 RID: 6837 RVA: 0x0002CDA2 File Offset: 0x0002AFA2
		public ShaderVariantCollection()
		{
			ShaderVariantCollection.Internal_Create(this);
		}

		// Token: 0x06001AB6 RID: 6838 RVA: 0x0002CDB4 File Offset: 0x0002AFB4
		public bool Add(ShaderVariantCollection.ShaderVariant variant)
		{
			return this.AddVariant(variant.shader, variant.passType, variant.keywords);
		}

		// Token: 0x06001AB7 RID: 6839 RVA: 0x0002CDE0 File Offset: 0x0002AFE0
		public bool Remove(ShaderVariantCollection.ShaderVariant variant)
		{
			return this.RemoveVariant(variant.shader, variant.passType, variant.keywords);
		}

		// Token: 0x06001AB8 RID: 6840 RVA: 0x0002CE0C File Offset: 0x0002B00C
		public bool Contains(ShaderVariantCollection.ShaderVariant variant)
		{
			return this.ContainsVariant(variant.shader, variant.passType, variant.keywords);
		}

		// Token: 0x02000280 RID: 640
		public struct ShaderVariant
		{
			// Token: 0x06001AB9 RID: 6841
			[FreeFunction]
			[NativeConditional("UNITY_EDITOR")]
			[MethodImpl(MethodImplOptions.InternalCall)]
			private static extern string CheckShaderVariant(Shader shader, PassType passType, string[] keywords);

			// Token: 0x06001ABA RID: 6842 RVA: 0x0002CE36 File Offset: 0x0002B036
			public ShaderVariant(Shader shader, PassType passType, params string[] keywords)
			{
				this.shader = shader;
				this.passType = passType;
				this.keywords = keywords;
			}

			// Token: 0x0400091C RID: 2332
			public Shader shader;

			// Token: 0x0400091D RID: 2333
			public PassType passType;

			// Token: 0x0400091E RID: 2334
			public string[] keywords;
		}
	}
}
