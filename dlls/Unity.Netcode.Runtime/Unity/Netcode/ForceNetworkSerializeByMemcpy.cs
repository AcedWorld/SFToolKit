using System;
using System.Runtime.CompilerServices;

namespace Unity.Netcode
{
	// Token: 0x0200010A RID: 266
	public struct ForceNetworkSerializeByMemcpy<[IsUnmanaged] T> : INetworkSerializeByMemcpy, IEquatable<ForceNetworkSerializeByMemcpy<T>> where T : struct, ValueType, IEquatable<T>
	{
		// Token: 0x06000836 RID: 2102 RVA: 0x0001FD91 File Offset: 0x0001DF91
		public ForceNetworkSerializeByMemcpy(T value)
		{
			this.Value = value;
		}

		// Token: 0x06000837 RID: 2103 RVA: 0x0001FD9A File Offset: 0x0001DF9A
		public static implicit operator T(ForceNetworkSerializeByMemcpy<T> container)
		{
			return container.Value;
		}

		// Token: 0x06000838 RID: 2104 RVA: 0x0001FDA4 File Offset: 0x0001DFA4
		public static implicit operator ForceNetworkSerializeByMemcpy<T>(T underlyingValue)
		{
			return new ForceNetworkSerializeByMemcpy<T>
			{
				Value = underlyingValue
			};
		}

		// Token: 0x06000839 RID: 2105 RVA: 0x0001FDC2 File Offset: 0x0001DFC2
		public bool Equals(ForceNetworkSerializeByMemcpy<T> other)
		{
			return this.Value.Equals(other.Value);
		}

		// Token: 0x0600083A RID: 2106 RVA: 0x0001FDDC File Offset: 0x0001DFDC
		public override bool Equals(object obj)
		{
			if (obj is ForceNetworkSerializeByMemcpy<T>)
			{
				ForceNetworkSerializeByMemcpy<T> other = (ForceNetworkSerializeByMemcpy<T>)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0600083B RID: 2107 RVA: 0x0001FE01 File Offset: 0x0001E001
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x04000327 RID: 807
		public T Value;
	}
}
