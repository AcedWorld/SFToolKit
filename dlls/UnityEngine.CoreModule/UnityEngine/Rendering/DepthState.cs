using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000455 RID: 1109
	public struct DepthState : IEquatable<DepthState>
	{
		// Token: 0x170006BA RID: 1722
		// (get) Token: 0x0600253C RID: 9532 RVA: 0x0003F5B4 File Offset: 0x0003D7B4
		public static DepthState defaultValue
		{
			get
			{
				return new DepthState(true, CompareFunction.Less);
			}
		}

		// Token: 0x0600253D RID: 9533 RVA: 0x0003F5CD File Offset: 0x0003D7CD
		public DepthState(bool writeEnabled = true, CompareFunction compareFunction = CompareFunction.Less)
		{
			this.m_WriteEnabled = Convert.ToByte(writeEnabled);
			this.m_CompareFunction = (sbyte)compareFunction;
		}

		// Token: 0x170006BB RID: 1723
		// (get) Token: 0x0600253E RID: 9534 RVA: 0x0003F5E4 File Offset: 0x0003D7E4
		// (set) Token: 0x0600253F RID: 9535 RVA: 0x0003F601 File Offset: 0x0003D801
		public bool writeEnabled
		{
			get
			{
				return Convert.ToBoolean(this.m_WriteEnabled);
			}
			set
			{
				this.m_WriteEnabled = Convert.ToByte(value);
			}
		}

		// Token: 0x170006BC RID: 1724
		// (get) Token: 0x06002540 RID: 9536 RVA: 0x0003F610 File Offset: 0x0003D810
		// (set) Token: 0x06002541 RID: 9537 RVA: 0x0003F628 File Offset: 0x0003D828
		public CompareFunction compareFunction
		{
			get
			{
				return (CompareFunction)this.m_CompareFunction;
			}
			set
			{
				this.m_CompareFunction = (sbyte)value;
			}
		}

		// Token: 0x06002542 RID: 9538 RVA: 0x0003F634 File Offset: 0x0003D834
		public bool Equals(DepthState other)
		{
			return this.m_WriteEnabled == other.m_WriteEnabled && this.m_CompareFunction == other.m_CompareFunction;
		}

		// Token: 0x06002543 RID: 9539 RVA: 0x0003F668 File Offset: 0x0003D868
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return !flag && obj is DepthState && this.Equals((DepthState)obj);
		}

		// Token: 0x06002544 RID: 9540 RVA: 0x0003F6A0 File Offset: 0x0003D8A0
		public override int GetHashCode()
		{
			return this.m_WriteEnabled.GetHashCode() * 397 ^ this.m_CompareFunction.GetHashCode();
		}

		// Token: 0x06002545 RID: 9541 RVA: 0x0003F6D0 File Offset: 0x0003D8D0
		public static bool operator ==(DepthState left, DepthState right)
		{
			return left.Equals(right);
		}

		// Token: 0x06002546 RID: 9542 RVA: 0x0003F6EC File Offset: 0x0003D8EC
		public static bool operator !=(DepthState left, DepthState right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04000E07 RID: 3591
		private byte m_WriteEnabled;

		// Token: 0x04000E08 RID: 3592
		private sbyte m_CompareFunction;
	}
}
