using System;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering
{
	// Token: 0x02000483 RID: 1155
	[NativeHeader("Runtime/Shaders/PassIdentifier.h")]
	[UsedByNativeCode]
	public readonly struct PassIdentifier : IEquatable<PassIdentifier>
	{
		// Token: 0x17000769 RID: 1897
		// (get) Token: 0x060027C3 RID: 10179 RVA: 0x0004450C File Offset: 0x0004270C
		public uint SubshaderIndex
		{
			get
			{
				return this.m_SubShaderIndex;
			}
		}

		// Token: 0x1700076A RID: 1898
		// (get) Token: 0x060027C4 RID: 10180 RVA: 0x00044524 File Offset: 0x00042724
		public uint PassIndex
		{
			get
			{
				return this.m_PassIndex;
			}
		}

		// Token: 0x060027C5 RID: 10181 RVA: 0x0004453C File Offset: 0x0004273C
		public PassIdentifier(uint subshaderIndex, uint passIndex)
		{
			this.m_SubShaderIndex = subshaderIndex;
			this.m_PassIndex = passIndex;
		}

		// Token: 0x060027C6 RID: 10182 RVA: 0x00044550 File Offset: 0x00042750
		public override bool Equals(object o)
		{
			bool result;
			if (o is PassIdentifier)
			{
				PassIdentifier rhs = (PassIdentifier)o;
				result = this.Equals(rhs);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060027C7 RID: 10183 RVA: 0x0004457C File Offset: 0x0004277C
		public bool Equals(PassIdentifier rhs)
		{
			return this.m_SubShaderIndex == rhs.m_SubShaderIndex && this.m_PassIndex == rhs.m_PassIndex;
		}

		// Token: 0x060027C8 RID: 10184 RVA: 0x000445B0 File Offset: 0x000427B0
		public static bool operator ==(PassIdentifier lhs, PassIdentifier rhs)
		{
			return lhs.Equals(rhs);
		}

		// Token: 0x060027C9 RID: 10185 RVA: 0x000445CC File Offset: 0x000427CC
		public static bool operator !=(PassIdentifier lhs, PassIdentifier rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x060027CA RID: 10186 RVA: 0x000445E8 File Offset: 0x000427E8
		public override int GetHashCode()
		{
			return this.m_SubShaderIndex.GetHashCode() ^ this.m_PassIndex.GetHashCode();
		}

		// Token: 0x04000F05 RID: 3845
		internal readonly uint m_SubShaderIndex;

		// Token: 0x04000F06 RID: 3846
		internal readonly uint m_PassIndex;
	}
}
