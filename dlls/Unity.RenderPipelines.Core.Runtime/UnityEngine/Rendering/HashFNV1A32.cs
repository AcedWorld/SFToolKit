using System;
using System.Runtime.CompilerServices;

namespace UnityEngine.Rendering
{
	// Token: 0x020000D9 RID: 217
	internal ref struct HashFNV1A32
	{
		// Token: 0x06000754 RID: 1876 RVA: 0x00023BA0 File Offset: 0x00021DA0
		public static HashFNV1A32 Create()
		{
			return new HashFNV1A32
			{
				m_Hash = 2166136261U
			};
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x00023BC2 File Offset: 0x00021DC2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Append(in int input)
		{
			this.m_Hash = (this.m_Hash ^ (uint)input) * 16777619U;
		}

		// Token: 0x06000756 RID: 1878 RVA: 0x00023BD9 File Offset: 0x00021DD9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Append(in uint input)
		{
			this.m_Hash = (this.m_Hash ^ input) * 16777619U;
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x00023BF0 File Offset: 0x00021DF0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Append(in bool input)
		{
			this.m_Hash = (this.m_Hash ^ (input ? 1U : 0U)) * 16777619U;
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x00023C0D File Offset: 0x00021E0D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Append(in float input)
		{
			this.m_Hash = (this.m_Hash ^ (uint)input.GetHashCode()) * 16777619U;
		}

		// Token: 0x06000759 RID: 1881 RVA: 0x00023C28 File Offset: 0x00021E28
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Append(in double input)
		{
			this.m_Hash = (this.m_Hash ^ (uint)input.GetHashCode()) * 16777619U;
		}

		// Token: 0x0600075A RID: 1882 RVA: 0x00023C44 File Offset: 0x00021E44
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Append(in Vector2 input)
		{
			uint hash = this.m_Hash;
			Vector2 vector = input;
			this.m_Hash = (hash ^ (uint)vector.GetHashCode()) * 16777619U;
		}

		// Token: 0x0600075B RID: 1883 RVA: 0x00023C78 File Offset: 0x00021E78
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Append(in Vector3 input)
		{
			uint hash = this.m_Hash;
			Vector3 vector = input;
			this.m_Hash = (hash ^ (uint)vector.GetHashCode()) * 16777619U;
		}

		// Token: 0x0600075C RID: 1884 RVA: 0x00023CAC File Offset: 0x00021EAC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Append(in Vector4 input)
		{
			uint hash = this.m_Hash;
			Vector4 vector = input;
			this.m_Hash = (hash ^ (uint)vector.GetHashCode()) * 16777619U;
		}

		// Token: 0x0600075D RID: 1885 RVA: 0x00023CE0 File Offset: 0x00021EE0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Append<T>(T input) where T : struct
		{
			this.m_Hash = (this.m_Hash ^ (uint)input.GetHashCode()) * 16777619U;
		}

		// Token: 0x0600075E RID: 1886 RVA: 0x00023D02 File Offset: 0x00021F02
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Append(Delegate del)
		{
			this.m_Hash = (this.m_Hash ^ (uint)HashFNV1A32.GetFuncHashCode(del)) * 16777619U;
		}

		// Token: 0x0600075F RID: 1887 RVA: 0x00023D1D File Offset: 0x00021F1D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static int GetFuncHashCode(Delegate del)
		{
			return del.Method.GetHashCode() ^ ((del.Target != null) ? RuntimeHelpers.GetHashCode(del.Target) : 0);
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000760 RID: 1888 RVA: 0x00023D41 File Offset: 0x00021F41
		public int value
		{
			get
			{
				return (int)this.m_Hash;
			}
		}

		// Token: 0x06000761 RID: 1889 RVA: 0x00023D49 File Offset: 0x00021F49
		public override int GetHashCode()
		{
			return this.value;
		}

		// Token: 0x040004A2 RID: 1186
		private const uint k_Prime = 16777619U;

		// Token: 0x040004A3 RID: 1187
		private const uint k_OffsetBasis = 2166136261U;

		// Token: 0x040004A4 RID: 1188
		private uint m_Hash;
	}
}
