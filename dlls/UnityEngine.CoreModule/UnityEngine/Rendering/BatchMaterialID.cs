using System;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering
{
	// Token: 0x02000434 RID: 1076
	[NativeHeader("Runtime/Camera/BatchRendererGroup.h")]
	[RequiredByNativeCode(Optional = true, GenerateProxy = true)]
	[NativeClass("BatchMaterialID")]
	public struct BatchMaterialID : IEquatable<BatchMaterialID>
	{
		// Token: 0x06002443 RID: 9283 RVA: 0x0003CF04 File Offset: 0x0003B104
		public override int GetHashCode()
		{
			return this.value.GetHashCode();
		}

		// Token: 0x06002444 RID: 9284 RVA: 0x0003CF24 File Offset: 0x0003B124
		public override bool Equals(object obj)
		{
			bool flag = obj is BatchMaterialID;
			return flag && this.Equals((BatchMaterialID)obj);
		}

		// Token: 0x06002445 RID: 9285 RVA: 0x0003CF54 File Offset: 0x0003B154
		public bool Equals(BatchMaterialID other)
		{
			return this.value == other.value;
		}

		// Token: 0x06002446 RID: 9286 RVA: 0x0003CF74 File Offset: 0x0003B174
		public int CompareTo(BatchMaterialID other)
		{
			return this.value.CompareTo(other.value);
		}

		// Token: 0x06002447 RID: 9287 RVA: 0x0003CF98 File Offset: 0x0003B198
		public static bool operator ==(BatchMaterialID a, BatchMaterialID b)
		{
			return a.Equals(b);
		}

		// Token: 0x06002448 RID: 9288 RVA: 0x0003CFB4 File Offset: 0x0003B1B4
		public static bool operator !=(BatchMaterialID a, BatchMaterialID b)
		{
			return !a.Equals(b);
		}

		// Token: 0x04000D38 RID: 3384
		public static readonly BatchMaterialID Null = new BatchMaterialID
		{
			value = 0U
		};

		// Token: 0x04000D39 RID: 3385
		public uint value;
	}
}
