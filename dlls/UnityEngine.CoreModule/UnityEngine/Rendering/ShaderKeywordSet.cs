using System;
using System.Runtime.CompilerServices;
using UnityEngine.Assertions;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering
{
	// Token: 0x02000487 RID: 1159
	[UsedByNativeCode]
	[NativeHeader("Editor/Src/Graphics/ShaderCompilerData.h")]
	public struct ShaderKeywordSet
	{
		// Token: 0x060027EA RID: 10218 RVA: 0x000448F8 File Offset: 0x00042AF8
		[FreeFunction("keywords::IsKeywordEnabled")]
		private static bool IsGlobalKeywordEnabled(ShaderKeywordSet state, uint index)
		{
			return ShaderKeywordSet.IsGlobalKeywordEnabled_Injected(ref state, index);
		}

		// Token: 0x060027EB RID: 10219 RVA: 0x00044902 File Offset: 0x00042B02
		[FreeFunction("keywords::IsKeywordEnabled")]
		private static bool IsKeywordEnabled(ShaderKeywordSet state, LocalKeywordSpace keywordSpace, uint index)
		{
			return ShaderKeywordSet.IsKeywordEnabled_Injected(ref state, ref keywordSpace, index);
		}

		// Token: 0x060027EC RID: 10220 RVA: 0x0004490E File Offset: 0x00042B0E
		[FreeFunction("keywords::IsKeywordEnabled")]
		private static bool IsKeywordNameEnabled(ShaderKeywordSet state, string name)
		{
			return ShaderKeywordSet.IsKeywordNameEnabled_Injected(ref state, name);
		}

		// Token: 0x060027ED RID: 10221 RVA: 0x00044918 File Offset: 0x00042B18
		[FreeFunction("keywords::EnableKeyword")]
		private static void EnableGlobalKeyword(ShaderKeywordSet state, uint index)
		{
			ShaderKeywordSet.EnableGlobalKeyword_Injected(ref state, index);
		}

		// Token: 0x060027EE RID: 10222 RVA: 0x00044922 File Offset: 0x00042B22
		[FreeFunction("keywords::EnableKeyword")]
		private static void EnableKeywordName(ShaderKeywordSet state, string name)
		{
			ShaderKeywordSet.EnableKeywordName_Injected(ref state, name);
		}

		// Token: 0x060027EF RID: 10223 RVA: 0x0004492C File Offset: 0x00042B2C
		[FreeFunction("keywords::DisableKeyword")]
		private static void DisableGlobalKeyword(ShaderKeywordSet state, uint index)
		{
			ShaderKeywordSet.DisableGlobalKeyword_Injected(ref state, index);
		}

		// Token: 0x060027F0 RID: 10224 RVA: 0x00044936 File Offset: 0x00042B36
		[FreeFunction("keywords::DisableKeyword")]
		private static void DisableKeywordName(ShaderKeywordSet state, string name)
		{
			ShaderKeywordSet.DisableKeywordName_Injected(ref state, name);
		}

		// Token: 0x060027F1 RID: 10225 RVA: 0x00044940 File Offset: 0x00042B40
		[FreeFunction("keywords::GetEnabledKeywords")]
		private static ShaderKeyword[] GetEnabledKeywords(ShaderKeywordSet state)
		{
			return ShaderKeywordSet.GetEnabledKeywords_Injected(ref state);
		}

		// Token: 0x060027F2 RID: 10226 RVA: 0x0004494C File Offset: 0x00042B4C
		private void CheckKeywordCompatible(ShaderKeyword keyword)
		{
			bool isLocal = keyword.m_IsLocal;
			if (isLocal)
			{
				bool flag = this.m_Shader != IntPtr.Zero;
				if (flag)
				{
					Assert.IsTrue(!keyword.m_IsCompute, "Trying to use a keyword that comes from a different shader.");
				}
				else
				{
					Assert.IsTrue(keyword.m_IsCompute, "Trying to use a keyword that comes from a different shader.");
				}
			}
		}

		// Token: 0x060027F3 RID: 10227 RVA: 0x000449A4 File Offset: 0x00042BA4
		public bool IsEnabled(ShaderKeyword keyword)
		{
			this.CheckKeywordCompatible(keyword);
			return ShaderKeywordSet.IsKeywordNameEnabled(this, keyword.m_Name);
		}

		// Token: 0x060027F4 RID: 10228 RVA: 0x000449D0 File Offset: 0x00042BD0
		public bool IsEnabled(GlobalKeyword keyword)
		{
			return ShaderKeywordSet.IsGlobalKeywordEnabled(this, keyword.m_Index);
		}

		// Token: 0x060027F5 RID: 10229 RVA: 0x000449F4 File Offset: 0x00042BF4
		public bool IsEnabled(LocalKeyword keyword)
		{
			return ShaderKeywordSet.IsKeywordEnabled(this, keyword.m_SpaceInfo, keyword.m_Index);
		}

		// Token: 0x060027F6 RID: 10230 RVA: 0x00044A20 File Offset: 0x00042C20
		public void Enable(ShaderKeyword keyword)
		{
			this.CheckKeywordCompatible(keyword);
			bool flag = keyword.m_IsLocal || !keyword.IsValid();
			if (flag)
			{
				ShaderKeywordSet.EnableKeywordName(this, keyword.m_Name);
			}
			else
			{
				ShaderKeywordSet.EnableGlobalKeyword(this, keyword.m_Index);
			}
		}

		// Token: 0x060027F7 RID: 10231 RVA: 0x00044A78 File Offset: 0x00042C78
		public void Disable(ShaderKeyword keyword)
		{
			bool flag = keyword.m_IsLocal || !keyword.IsValid();
			if (flag)
			{
				ShaderKeywordSet.DisableKeywordName(this, keyword.m_Name);
			}
			else
			{
				ShaderKeywordSet.DisableGlobalKeyword(this, keyword.m_Index);
			}
		}

		// Token: 0x060027F8 RID: 10232 RVA: 0x00044AC8 File Offset: 0x00042CC8
		public ShaderKeyword[] GetShaderKeywords()
		{
			return ShaderKeywordSet.GetEnabledKeywords(this);
		}

		// Token: 0x060027F9 RID: 10233
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsGlobalKeywordEnabled_Injected(ref ShaderKeywordSet state, uint index);

		// Token: 0x060027FA RID: 10234
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsKeywordEnabled_Injected(ref ShaderKeywordSet state, ref LocalKeywordSpace keywordSpace, uint index);

		// Token: 0x060027FB RID: 10235
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsKeywordNameEnabled_Injected(ref ShaderKeywordSet state, string name);

		// Token: 0x060027FC RID: 10236
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void EnableGlobalKeyword_Injected(ref ShaderKeywordSet state, uint index);

		// Token: 0x060027FD RID: 10237
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void EnableKeywordName_Injected(ref ShaderKeywordSet state, string name);

		// Token: 0x060027FE RID: 10238
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void DisableGlobalKeyword_Injected(ref ShaderKeywordSet state, uint index);

		// Token: 0x060027FF RID: 10239
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void DisableKeywordName_Injected(ref ShaderKeywordSet state, string name);

		// Token: 0x06002800 RID: 10240
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ShaderKeyword[] GetEnabledKeywords_Injected(ref ShaderKeywordSet state);

		// Token: 0x04000F15 RID: 3861
		private IntPtr m_KeywordState;

		// Token: 0x04000F16 RID: 3862
		private IntPtr m_Shader;

		// Token: 0x04000F17 RID: 3863
		private IntPtr m_ComputeShader;

		// Token: 0x04000F18 RID: 3864
		private ulong m_StateIndex;
	}
}
