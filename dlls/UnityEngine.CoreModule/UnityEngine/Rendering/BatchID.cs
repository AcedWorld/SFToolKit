using System;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering
{
	// Token: 0x02000433 RID: 1075
	[NativeHeader("Runtime/Camera/BatchRendererGroup.h")]
	[NativeClass("BatchID")]
	[RequiredByNativeCode(Optional = true, GenerateProxy = true)]
	public struct BatchID : IEquatable<BatchID>
	{
		// Token: 0x0600243C RID: 9276 RVA: 0x0003CE10 File Offset: 0x0003B010
		public override int GetHashCode()
		{
			return this.value.GetHashCode();
		}

		// Token: 0x0600243D RID: 9277 RVA: 0x0003CE30 File Offset: 0x0003B030
		public override bool Equals(object obj)
		{
			bool flag = obj is BatchID;
			return flag && this.Equals((BatchID)obj);
		}

		// Token: 0x0600243E RID: 9278 RVA: 0x0003CE60 File Offset: 0x0003B060
		public bool Equals(BatchID other)
		{
			return this.value == other.value;
		}

		// Token: 0x0600243F RID: 9279 RVA: 0x0003CE80 File Offset: 0x0003B080
		public int CompareTo(BatchID other)
		{
			return this.value.CompareTo(other.value);
		}

		// Token: 0x06002440 RID: 9280 RVA: 0x0003CEA4 File Offset: 0x0003B0A4
		public static bool operator ==(BatchID a, BatchID b)
		{
			return a.Equals(b);
		}

		// Token: 0x06002441 RID: 9281 RVA: 0x0003CEC0 File Offset: 0x0003B0C0
		public static bool operator !=(BatchID a, BatchID b)
		{
			return !a.Equals(b);
		}

		// Token: 0x04000D36 RID: 3382
		public static readonly BatchID Null = new BatchID
		{
			value = 0U
		};

		// Token: 0x04000D37 RID: 3383
		public uint value;
	}
}
