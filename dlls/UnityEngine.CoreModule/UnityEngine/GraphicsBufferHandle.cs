using System;
using UnityEngine.Bindings;

namespace UnityEngine
{
	// Token: 0x0200016A RID: 362
	[NativeHeader("Runtime/GfxDevice/GfxDeviceTypes.h")]
	[NativeClass("GfxBufferID")]
	public readonly struct GraphicsBufferHandle : IEquatable<GraphicsBufferHandle>
	{
		// Token: 0x06000F10 RID: 3856 RVA: 0x0001516C File Offset: 0x0001336C
		public override int GetHashCode()
		{
			return this.value.GetHashCode();
		}

		// Token: 0x06000F11 RID: 3857 RVA: 0x0001518C File Offset: 0x0001338C
		public override bool Equals(object obj)
		{
			bool flag = obj is GraphicsBufferHandle;
			return flag && this.Equals((GraphicsBufferHandle)obj);
		}

		// Token: 0x06000F12 RID: 3858 RVA: 0x000151BC File Offset: 0x000133BC
		public bool Equals(GraphicsBufferHandle other)
		{
			return this.value == other.value;
		}

		// Token: 0x06000F13 RID: 3859 RVA: 0x000151DC File Offset: 0x000133DC
		public int CompareTo(GraphicsBufferHandle other)
		{
			return this.value.CompareTo(other.value);
		}

		// Token: 0x06000F14 RID: 3860 RVA: 0x00015200 File Offset: 0x00013400
		public static bool operator ==(GraphicsBufferHandle a, GraphicsBufferHandle b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000F15 RID: 3861 RVA: 0x0001521C File Offset: 0x0001341C
		public static bool operator !=(GraphicsBufferHandle a, GraphicsBufferHandle b)
		{
			return !a.Equals(b);
		}

		// Token: 0x0400047A RID: 1146
		public readonly uint value;
	}
}
