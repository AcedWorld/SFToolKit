using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.Rendering
{
	// Token: 0x02000482 RID: 1154
	[NativeHeader("Runtime/Shaders/Keywords/KeywordSpaceScriptBindings.h")]
	public readonly struct LocalKeywordSpace : IEquatable<LocalKeywordSpace>
	{
		// Token: 0x060027B2 RID: 10162 RVA: 0x000443CF File Offset: 0x000425CF
		[FreeFunction("keywords::GetKeywords", HasExplicitThis = true)]
		private LocalKeyword[] GetKeywords()
		{
			return LocalKeywordSpace.GetKeywords_Injected(ref this);
		}

		// Token: 0x060027B3 RID: 10163 RVA: 0x000443D7 File Offset: 0x000425D7
		[FreeFunction("keywords::GetKeywordNames", HasExplicitThis = true)]
		private string[] GetKeywordNames()
		{
			return LocalKeywordSpace.GetKeywordNames_Injected(ref this);
		}

		// Token: 0x060027B4 RID: 10164 RVA: 0x000443DF File Offset: 0x000425DF
		[FreeFunction("keywords::GetKeywordCount", HasExplicitThis = true)]
		private uint GetKeywordCount()
		{
			return LocalKeywordSpace.GetKeywordCount_Injected(ref this);
		}

		// Token: 0x060027B5 RID: 10165 RVA: 0x000443E8 File Offset: 0x000425E8
		[FreeFunction("keywords::GetKeyword", HasExplicitThis = true)]
		private LocalKeyword GetKeyword(string name)
		{
			LocalKeyword result;
			LocalKeywordSpace.GetKeyword_Injected(ref this, name, out result);
			return result;
		}

		// Token: 0x17000766 RID: 1894
		// (get) Token: 0x060027B6 RID: 10166 RVA: 0x00044400 File Offset: 0x00042600
		public LocalKeyword[] keywords
		{
			get
			{
				return this.GetKeywords();
			}
		}

		// Token: 0x17000767 RID: 1895
		// (get) Token: 0x060027B7 RID: 10167 RVA: 0x00044418 File Offset: 0x00042618
		public string[] keywordNames
		{
			get
			{
				return this.GetKeywordNames();
			}
		}

		// Token: 0x17000768 RID: 1896
		// (get) Token: 0x060027B8 RID: 10168 RVA: 0x00044430 File Offset: 0x00042630
		public uint keywordCount
		{
			get
			{
				return this.GetKeywordCount();
			}
		}

		// Token: 0x060027B9 RID: 10169 RVA: 0x00044448 File Offset: 0x00042648
		public LocalKeyword FindKeyword(string name)
		{
			return this.GetKeyword(name);
		}

		// Token: 0x060027BA RID: 10170 RVA: 0x00044464 File Offset: 0x00042664
		public override bool Equals(object o)
		{
			bool result;
			if (o is LocalKeywordSpace)
			{
				LocalKeywordSpace rhs = (LocalKeywordSpace)o;
				result = this.Equals(rhs);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060027BB RID: 10171 RVA: 0x00044490 File Offset: 0x00042690
		public bool Equals(LocalKeywordSpace rhs)
		{
			return this.m_KeywordSpace == rhs.m_KeywordSpace;
		}

		// Token: 0x060027BC RID: 10172 RVA: 0x000444B4 File Offset: 0x000426B4
		public static bool operator ==(LocalKeywordSpace lhs, LocalKeywordSpace rhs)
		{
			return lhs.Equals(rhs);
		}

		// Token: 0x060027BD RID: 10173 RVA: 0x000444D0 File Offset: 0x000426D0
		public static bool operator !=(LocalKeywordSpace lhs, LocalKeywordSpace rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x060027BE RID: 10174 RVA: 0x000444EC File Offset: 0x000426EC
		public override int GetHashCode()
		{
			return this.m_KeywordSpace.GetHashCode();
		}

		// Token: 0x060027BF RID: 10175
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern LocalKeyword[] GetKeywords_Injected(ref LocalKeywordSpace _unity_self);

		// Token: 0x060027C0 RID: 10176
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string[] GetKeywordNames_Injected(ref LocalKeywordSpace _unity_self);

		// Token: 0x060027C1 RID: 10177
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint GetKeywordCount_Injected(ref LocalKeywordSpace _unity_self);

		// Token: 0x060027C2 RID: 10178
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetKeyword_Injected(ref LocalKeywordSpace _unity_self, string name, out LocalKeyword ret);

		// Token: 0x04000F04 RID: 3844
		private readonly IntPtr m_KeywordSpace;
	}
}
