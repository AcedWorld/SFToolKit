using System;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering
{
	// Token: 0x02000435 RID: 1077
	[NativeClass("BatchMeshID")]
	[NativeHeader("Runtime/Camera/BatchRendererGroup.h")]
	[RequiredByNativeCode(Optional = true, GenerateProxy = true)]
	public struct BatchMeshID : IEquatable<BatchMeshID>
	{
		// Token: 0x0600244A RID: 9290 RVA: 0x0003CFF8 File Offset: 0x0003B1F8
		public override int GetHashCode()
		{
			return this.value.GetHashCode();
		}

		// Token: 0x0600244B RID: 9291 RVA: 0x0003D018 File Offset: 0x0003B218
		public override bool Equals(object obj)
		{
			bool flag = obj is BatchMeshID;
			return flag && this.Equals((BatchMeshID)obj);
		}

		// Token: 0x0600244C RID: 9292 RVA: 0x0003D048 File Offset: 0x0003B248
		public bool Equals(BatchMeshID other)
		{
			return this.value == other.value;
		}

		// Token: 0x0600244D RID: 9293 RVA: 0x0003D068 File Offset: 0x0003B268
		public int CompareTo(BatchMeshID other)
		{
			return this.value.CompareTo(other.value);
		}

		// Token: 0x0600244E RID: 9294 RVA: 0x0003D08C File Offset: 0x0003B28C
		public static bool operator ==(BatchMeshID a, BatchMeshID b)
		{
			return a.Equals(b);
		}

		// Token: 0x0600244F RID: 9295 RVA: 0x0003D0A8 File Offset: 0x0003B2A8
		public static bool operator !=(BatchMeshID a, BatchMeshID b)
		{
			return !a.Equals(b);
		}

		// Token: 0x04000D3A RID: 3386
		public static readonly BatchMeshID Null = new BatchMeshID
		{
			value = 0U
		};

		// Token: 0x04000D3B RID: 3387
		public uint value;
	}
}
