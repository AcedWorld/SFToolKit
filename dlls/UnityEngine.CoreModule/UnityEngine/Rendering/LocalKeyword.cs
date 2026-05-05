using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering
{
	// Token: 0x02000481 RID: 1153
	[NativeHeader("Runtime/Shaders/Keywords/KeywordSpaceScriptBindings.h")]
	[UsedByNativeCode]
	[NativeHeader("Runtime/Graphics/ShaderScriptBindings.h")]
	public readonly struct LocalKeyword : IEquatable<LocalKeyword>
	{
		// Token: 0x06002799 RID: 10137 RVA: 0x00044144 File Offset: 0x00042344
		[FreeFunction("keywords::IsKeywordDynamic")]
		private static bool IsDynamic(LocalKeyword kw)
		{
			return LocalKeyword.IsDynamic_Injected(ref kw);
		}

		// Token: 0x0600279A RID: 10138 RVA: 0x0004414D File Offset: 0x0004234D
		[FreeFunction("keywords::IsKeywordOverridable")]
		private static bool IsOverridable(LocalKeyword kw)
		{
			return LocalKeyword.IsOverridable_Injected(ref kw);
		}

		// Token: 0x0600279B RID: 10139
		[FreeFunction("ShaderScripting::GetKeywordCount")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint GetShaderKeywordCount(Shader shader);

		// Token: 0x0600279C RID: 10140
		[FreeFunction("ShaderScripting::GetKeywordIndex")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint GetShaderKeywordIndex(Shader shader, string keyword);

		// Token: 0x0600279D RID: 10141
		[FreeFunction("ShaderScripting::GetKeywordCount")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint GetComputeShaderKeywordCount(ComputeShader shader);

		// Token: 0x0600279E RID: 10142
		[FreeFunction("ShaderScripting::GetKeywordIndex")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint GetComputeShaderKeywordIndex(ComputeShader shader, string keyword);

		// Token: 0x0600279F RID: 10143 RVA: 0x00044156 File Offset: 0x00042356
		[FreeFunction("keywords::GetKeywordType")]
		private static ShaderKeywordType GetKeywordType(LocalKeywordSpace spaceInfo, uint keyword)
		{
			return LocalKeyword.GetKeywordType_Injected(ref spaceInfo, keyword);
		}

		// Token: 0x060027A0 RID: 10144 RVA: 0x00044160 File Offset: 0x00042360
		[FreeFunction("keywords::IsKeywordValid")]
		private static bool IsValid(LocalKeywordSpace spaceInfo, uint keyword)
		{
			return LocalKeyword.IsValid_Injected(ref spaceInfo, keyword);
		}

		// Token: 0x17000761 RID: 1889
		// (get) Token: 0x060027A1 RID: 10145 RVA: 0x0004416C File Offset: 0x0004236C
		public string name
		{
			get
			{
				return this.m_Name;
			}
		}

		// Token: 0x17000762 RID: 1890
		// (get) Token: 0x060027A2 RID: 10146 RVA: 0x00044184 File Offset: 0x00042384
		public bool isDynamic
		{
			get
			{
				return LocalKeyword.IsDynamic(this);
			}
		}

		// Token: 0x17000763 RID: 1891
		// (get) Token: 0x060027A3 RID: 10147 RVA: 0x000441A4 File Offset: 0x000423A4
		public bool isOverridable
		{
			get
			{
				return LocalKeyword.IsOverridable(this);
			}
		}

		// Token: 0x17000764 RID: 1892
		// (get) Token: 0x060027A4 RID: 10148 RVA: 0x000441C4 File Offset: 0x000423C4
		public bool isValid
		{
			get
			{
				return LocalKeyword.IsValid(this.m_SpaceInfo, this.m_Index);
			}
		}

		// Token: 0x17000765 RID: 1893
		// (get) Token: 0x060027A5 RID: 10149 RVA: 0x000441E8 File Offset: 0x000423E8
		public ShaderKeywordType type
		{
			get
			{
				return LocalKeyword.GetKeywordType(this.m_SpaceInfo, this.m_Index);
			}
		}

		// Token: 0x060027A6 RID: 10150 RVA: 0x0004420C File Offset: 0x0004240C
		public LocalKeyword(Shader shader, string name)
		{
			bool flag = shader == null;
			if (flag)
			{
				Debug.LogError("Cannot initialize a LocalKeyword with a null Shader.");
			}
			this.m_SpaceInfo = shader.keywordSpace;
			this.m_Name = name;
			this.m_Index = LocalKeyword.GetShaderKeywordIndex(shader, name);
			bool flag2 = this.m_Index >= LocalKeyword.GetShaderKeywordCount(shader);
			if (flag2)
			{
				Debug.LogErrorFormat("Local keyword {0} doesn't exist in the shader.", new object[]
				{
					name
				});
			}
		}

		// Token: 0x060027A7 RID: 10151 RVA: 0x0004427C File Offset: 0x0004247C
		public LocalKeyword(ComputeShader shader, string name)
		{
			bool flag = shader == null;
			if (flag)
			{
				Debug.LogError("Cannot initialize a LocalKeyword with a null ComputeShader.");
			}
			this.m_SpaceInfo = shader.keywordSpace;
			this.m_Name = name;
			this.m_Index = LocalKeyword.GetComputeShaderKeywordIndex(shader, name);
			bool flag2 = this.m_Index >= LocalKeyword.GetComputeShaderKeywordCount(shader);
			if (flag2)
			{
				Debug.LogErrorFormat("Local keyword {0} doesn't exist in the compute shader.", new object[]
				{
					name
				});
			}
		}

		// Token: 0x060027A8 RID: 10152 RVA: 0x000442EC File Offset: 0x000424EC
		public override string ToString()
		{
			return this.m_Name;
		}

		// Token: 0x060027A9 RID: 10153 RVA: 0x00044304 File Offset: 0x00042504
		public override bool Equals(object o)
		{
			bool result;
			if (o is LocalKeyword)
			{
				LocalKeyword rhs = (LocalKeyword)o;
				result = this.Equals(rhs);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060027AA RID: 10154 RVA: 0x00044330 File Offset: 0x00042530
		public bool Equals(LocalKeyword rhs)
		{
			return this.m_SpaceInfo == rhs.m_SpaceInfo && this.m_Index == rhs.m_Index;
		}

		// Token: 0x060027AB RID: 10155 RVA: 0x00044368 File Offset: 0x00042568
		public static bool operator ==(LocalKeyword lhs, LocalKeyword rhs)
		{
			return lhs.Equals(rhs);
		}

		// Token: 0x060027AC RID: 10156 RVA: 0x00044384 File Offset: 0x00042584
		public static bool operator !=(LocalKeyword lhs, LocalKeyword rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x060027AD RID: 10157 RVA: 0x000443A0 File Offset: 0x000425A0
		public override int GetHashCode()
		{
			return this.m_Index.GetHashCode() ^ this.m_SpaceInfo.GetHashCode();
		}

		// Token: 0x060027AE RID: 10158
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsDynamic_Injected(ref LocalKeyword kw);

		// Token: 0x060027AF RID: 10159
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsOverridable_Injected(ref LocalKeyword kw);

		// Token: 0x060027B0 RID: 10160
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ShaderKeywordType GetKeywordType_Injected(ref LocalKeywordSpace spaceInfo, uint keyword);

		// Token: 0x060027B1 RID: 10161
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsValid_Injected(ref LocalKeywordSpace spaceInfo, uint keyword);

		// Token: 0x04000F01 RID: 3841
		internal readonly LocalKeywordSpace m_SpaceInfo;

		// Token: 0x04000F02 RID: 3842
		internal readonly string m_Name;

		// Token: 0x04000F03 RID: 3843
		internal readonly uint m_Index;
	}
}
