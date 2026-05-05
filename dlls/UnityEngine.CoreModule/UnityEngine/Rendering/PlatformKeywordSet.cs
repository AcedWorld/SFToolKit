using System;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering
{
	// Token: 0x02000484 RID: 1156
	[UsedByNativeCode]
	public struct PlatformKeywordSet
	{
		// Token: 0x060027CB RID: 10187 RVA: 0x00044614 File Offset: 0x00042814
		private ulong ComputeKeywordMask(BuiltinShaderDefine define)
		{
			return (ulong)(1L << (int)(define % (BuiltinShaderDefine)64 & BuiltinShaderDefine.SHADER_API_GLES30));
		}

		// Token: 0x060027CC RID: 10188 RVA: 0x00044630 File Offset: 0x00042830
		public bool IsEnabled(BuiltinShaderDefine define)
		{
			return (this.m_Bits & this.ComputeKeywordMask(define)) > 0UL;
		}

		// Token: 0x060027CD RID: 10189 RVA: 0x00044654 File Offset: 0x00042854
		public void Enable(BuiltinShaderDefine define)
		{
			this.m_Bits |= this.ComputeKeywordMask(define);
		}

		// Token: 0x060027CE RID: 10190 RVA: 0x0004466B File Offset: 0x0004286B
		public void Disable(BuiltinShaderDefine define)
		{
			this.m_Bits &= ~this.ComputeKeywordMask(define);
		}

		// Token: 0x04000F07 RID: 3847
		private const int k_SizeInBits = 64;

		// Token: 0x04000F08 RID: 3848
		internal ulong m_Bits;
	}
}
