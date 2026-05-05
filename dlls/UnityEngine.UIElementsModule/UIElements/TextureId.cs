using System;
using System.Runtime.CompilerServices;

namespace UnityEngine.UIElements
{
	// Token: 0x020002B4 RID: 692
	internal struct TextureId
	{
		// Token: 0x06001409 RID: 5129 RVA: 0x00047408 File Offset: 0x00045608
		public TextureId(int index)
		{
			this.m_Index = index + 1;
		}

		// Token: 0x17000438 RID: 1080
		// (get) Token: 0x0600140A RID: 5130 RVA: 0x00047414 File Offset: 0x00045614
		public int index
		{
			get
			{
				return this.m_Index - 1;
			}
		}

		// Token: 0x0600140B RID: 5131 RVA: 0x00047420 File Offset: 0x00045620
		public bool IsValid()
		{
			return this.m_Index > 0;
		}

		// Token: 0x0600140C RID: 5132 RVA: 0x0004743C File Offset: 0x0004563C
		public float ConvertToGpu()
		{
			return (float)this.index;
		}

		// Token: 0x0600140D RID: 5133 RVA: 0x00047458 File Offset: 0x00045658
		public override bool Equals(object obj)
		{
			bool flag = !(obj is TextureId);
			return !flag && (TextureId)obj == this;
		}

		// Token: 0x0600140E RID: 5134 RVA: 0x00047490 File Offset: 0x00045690
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(TextureId other)
		{
			return this.m_Index == other.m_Index;
		}

		// Token: 0x0600140F RID: 5135 RVA: 0x000474B0 File Offset: 0x000456B0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return this.m_Index.GetHashCode();
		}

		// Token: 0x06001410 RID: 5136 RVA: 0x000474D0 File Offset: 0x000456D0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(TextureId left, TextureId right)
		{
			return left.m_Index == right.m_Index;
		}

		// Token: 0x06001411 RID: 5137 RVA: 0x000474F0 File Offset: 0x000456F0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(TextureId left, TextureId right)
		{
			return !(left == right);
		}

		// Token: 0x0400094E RID: 2382
		private readonly int m_Index;

		// Token: 0x0400094F RID: 2383
		public static readonly TextureId invalid = new TextureId(-1);
	}
}
