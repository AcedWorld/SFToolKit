using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering
{
	// Token: 0x02000486 RID: 1158
	[NativeHeader("Runtime/Shaders/Keywords/KeywordSpaceScriptBindings.h")]
	[UsedByNativeCode]
	[NativeHeader("Runtime/Graphics/ShaderScriptBindings.h")]
	public struct ShaderKeyword
	{
		// Token: 0x060027CF RID: 10191
		[FreeFunction("ShaderScripting::GetGlobalKeywordCount")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern uint GetGlobalKeywordCount();

		// Token: 0x060027D0 RID: 10192
		[FreeFunction("ShaderScripting::GetGlobalKeywordIndex")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern uint GetGlobalKeywordIndex(string keyword);

		// Token: 0x060027D1 RID: 10193
		[FreeFunction("ShaderScripting::GetKeywordCount")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern uint GetKeywordCount(Shader shader);

		// Token: 0x060027D2 RID: 10194
		[FreeFunction("ShaderScripting::GetKeywordIndex")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern uint GetKeywordIndex(Shader shader, string keyword);

		// Token: 0x060027D3 RID: 10195
		[FreeFunction("ShaderScripting::GetKeywordCount")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern uint GetComputeShaderKeywordCount(ComputeShader shader);

		// Token: 0x060027D4 RID: 10196
		[FreeFunction("ShaderScripting::GetKeywordIndex")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern uint GetComputeShaderKeywordIndex(ComputeShader shader, string keyword);

		// Token: 0x060027D5 RID: 10197
		[FreeFunction("ShaderScripting::CreateGlobalKeyword")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void CreateGlobalKeyword(string keyword);

		// Token: 0x060027D6 RID: 10198
		[FreeFunction("ShaderScripting::GetKeywordType")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern ShaderKeywordType GetGlobalShaderKeywordType(uint keyword);

		// Token: 0x1700076B RID: 1899
		// (get) Token: 0x060027D7 RID: 10199 RVA: 0x00044684 File Offset: 0x00042884
		public string name
		{
			get
			{
				return this.m_Name;
			}
		}

		// Token: 0x060027D8 RID: 10200 RVA: 0x0004469C File Offset: 0x0004289C
		public static ShaderKeywordType GetGlobalKeywordType(ShaderKeyword index)
		{
			bool flag = index.IsValid();
			ShaderKeywordType result;
			if (flag)
			{
				result = ShaderKeyword.GetGlobalShaderKeywordType(index.m_Index);
			}
			else
			{
				result = ShaderKeywordType.UserDefined;
			}
			return result;
		}

		// Token: 0x060027D9 RID: 10201 RVA: 0x000446CC File Offset: 0x000428CC
		public ShaderKeyword(string keywordName)
		{
			this.m_Name = keywordName;
			this.m_Index = ShaderKeyword.GetGlobalKeywordIndex(keywordName);
			bool flag = this.m_Index >= ShaderKeyword.GetGlobalKeywordCount();
			if (flag)
			{
				ShaderKeyword.CreateGlobalKeyword(keywordName);
				this.m_Index = ShaderKeyword.GetGlobalKeywordIndex(keywordName);
			}
			this.m_IsValid = true;
			this.m_IsLocal = false;
			this.m_IsCompute = false;
		}

		// Token: 0x060027DA RID: 10202 RVA: 0x0004472B File Offset: 0x0004292B
		public ShaderKeyword(Shader shader, string keywordName)
		{
			this.m_Name = keywordName;
			this.m_Index = ShaderKeyword.GetKeywordIndex(shader, keywordName);
			this.m_IsValid = (this.m_Index < ShaderKeyword.GetKeywordCount(shader));
			this.m_IsLocal = true;
			this.m_IsCompute = false;
		}

		// Token: 0x060027DB RID: 10203 RVA: 0x00044764 File Offset: 0x00042964
		public ShaderKeyword(ComputeShader shader, string keywordName)
		{
			this.m_Name = keywordName;
			this.m_Index = ShaderKeyword.GetComputeShaderKeywordIndex(shader, keywordName);
			this.m_IsValid = (this.m_Index < ShaderKeyword.GetComputeShaderKeywordCount(shader));
			this.m_IsLocal = true;
			this.m_IsCompute = true;
		}

		// Token: 0x060027DC RID: 10204 RVA: 0x000447A0 File Offset: 0x000429A0
		public static bool IsKeywordLocal(ShaderKeyword keyword)
		{
			return keyword.m_IsLocal;
		}

		// Token: 0x060027DD RID: 10205 RVA: 0x000447B8 File Offset: 0x000429B8
		public bool IsValid()
		{
			return this.m_IsValid;
		}

		// Token: 0x060027DE RID: 10206 RVA: 0x000447D0 File Offset: 0x000429D0
		public bool IsValid(ComputeShader shader)
		{
			return this.m_IsValid;
		}

		// Token: 0x060027DF RID: 10207 RVA: 0x000447E8 File Offset: 0x000429E8
		public bool IsValid(Shader shader)
		{
			return this.m_IsValid;
		}

		// Token: 0x1700076C RID: 1900
		// (get) Token: 0x060027E0 RID: 10208 RVA: 0x00044800 File Offset: 0x00042A00
		public int index
		{
			get
			{
				return (int)this.m_Index;
			}
		}

		// Token: 0x060027E1 RID: 10209 RVA: 0x00044818 File Offset: 0x00042A18
		public override string ToString()
		{
			return this.m_Name;
		}

		// Token: 0x060027E2 RID: 10210 RVA: 0x00044830 File Offset: 0x00042A30
		[Obsolete("GetKeywordType is deprecated. Only global keywords can have a type. This method always returns ShaderKeywordType.UserDefined.")]
		public static ShaderKeywordType GetKeywordType(Shader shader, ShaderKeyword index)
		{
			return ShaderKeywordType.UserDefined;
		}

		// Token: 0x060027E3 RID: 10211 RVA: 0x00044844 File Offset: 0x00042A44
		[Obsolete("GetKeywordType is deprecated. Only global keywords can have a type. This method always returns ShaderKeywordType.UserDefined.")]
		public static ShaderKeywordType GetKeywordType(ComputeShader shader, ShaderKeyword index)
		{
			return ShaderKeywordType.UserDefined;
		}

		// Token: 0x060027E4 RID: 10212 RVA: 0x00044858 File Offset: 0x00042A58
		[Obsolete("GetGlobalKeywordName is deprecated. Use the ShaderKeyword.name property instead.")]
		public static string GetGlobalKeywordName(ShaderKeyword index)
		{
			return index.m_Name;
		}

		// Token: 0x060027E5 RID: 10213 RVA: 0x00044870 File Offset: 0x00042A70
		[Obsolete("GetKeywordName is deprecated. Use the ShaderKeyword.name property instead.")]
		public static string GetKeywordName(Shader shader, ShaderKeyword index)
		{
			return index.m_Name;
		}

		// Token: 0x060027E6 RID: 10214 RVA: 0x00044888 File Offset: 0x00042A88
		[Obsolete("GetKeywordName is deprecated. Use the ShaderKeyword.name property instead.")]
		public static string GetKeywordName(ComputeShader shader, ShaderKeyword index)
		{
			return index.m_Name;
		}

		// Token: 0x060027E7 RID: 10215 RVA: 0x000448A0 File Offset: 0x00042AA0
		[Obsolete("GetKeywordType is deprecated. Use ShaderKeyword.name instead.")]
		public ShaderKeywordType GetKeywordType()
		{
			return ShaderKeyword.GetGlobalKeywordType(this);
		}

		// Token: 0x060027E8 RID: 10216 RVA: 0x000448C0 File Offset: 0x00042AC0
		[Obsolete("GetKeywordName is deprecated. Use ShaderKeyword.name instead.")]
		public string GetKeywordName()
		{
			return ShaderKeyword.GetGlobalKeywordName(this);
		}

		// Token: 0x060027E9 RID: 10217 RVA: 0x000448E0 File Offset: 0x00042AE0
		[Obsolete("GetName() has been deprecated. Use ShaderKeyword.name instead.")]
		public string GetName()
		{
			return this.GetKeywordName();
		}

		// Token: 0x04000F10 RID: 3856
		internal string m_Name;

		// Token: 0x04000F11 RID: 3857
		internal uint m_Index;

		// Token: 0x04000F12 RID: 3858
		internal bool m_IsLocal;

		// Token: 0x04000F13 RID: 3859
		internal bool m_IsCompute;

		// Token: 0x04000F14 RID: 3860
		internal bool m_IsValid;
	}
}
