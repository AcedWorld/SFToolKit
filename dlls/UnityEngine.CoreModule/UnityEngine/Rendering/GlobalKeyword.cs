using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering
{
	// Token: 0x02000480 RID: 1152
	[NativeHeader("Runtime/Shaders/Keywords/KeywordSpaceScriptBindings.h")]
	[NativeHeader("Runtime/Graphics/ShaderScriptBindings.h")]
	[UsedByNativeCode]
	public readonly struct GlobalKeyword
	{
		// Token: 0x06002792 RID: 10130
		[FreeFunction("ShaderScripting::GetGlobalKeywordCount")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint GetGlobalKeywordCount();

		// Token: 0x06002793 RID: 10131
		[FreeFunction("ShaderScripting::GetGlobalKeywordIndex")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint GetGlobalKeywordIndex(string keyword);

		// Token: 0x06002794 RID: 10132
		[FreeFunction("ShaderScripting::CreateGlobalKeyword")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CreateGlobalKeyword(string keyword);

		// Token: 0x17000760 RID: 1888
		// (get) Token: 0x06002795 RID: 10133 RVA: 0x000440A8 File Offset: 0x000422A8
		public string name
		{
			get
			{
				return this.m_Name;
			}
		}

		// Token: 0x06002796 RID: 10134 RVA: 0x000440C0 File Offset: 0x000422C0
		public static GlobalKeyword Create(string name)
		{
			GlobalKeyword.CreateGlobalKeyword(name);
			return new GlobalKeyword(name);
		}

		// Token: 0x06002797 RID: 10135 RVA: 0x000440E0 File Offset: 0x000422E0
		public GlobalKeyword(string name)
		{
			this.m_Name = name;
			this.m_Index = GlobalKeyword.GetGlobalKeywordIndex(name);
			bool flag = this.m_Index >= GlobalKeyword.GetGlobalKeywordCount();
			if (flag)
			{
				Debug.LogErrorFormat("Global keyword {0} doesn't exist.", new object[]
				{
					name
				});
			}
		}

		// Token: 0x06002798 RID: 10136 RVA: 0x0004412C File Offset: 0x0004232C
		public override string ToString()
		{
			return this.m_Name;
		}

		// Token: 0x04000EFF RID: 3839
		internal readonly string m_Name;

		// Token: 0x04000F00 RID: 3840
		internal readonly uint m_Index;
	}
}
