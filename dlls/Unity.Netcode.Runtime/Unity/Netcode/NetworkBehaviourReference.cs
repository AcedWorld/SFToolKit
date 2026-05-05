using System;
using System.Runtime.CompilerServices;

namespace Unity.Netcode
{
	// Token: 0x02000110 RID: 272
	public struct NetworkBehaviourReference : INetworkSerializable, IEquatable<NetworkBehaviourReference>
	{
		// Token: 0x06000884 RID: 2180 RVA: 0x0001FE84 File Offset: 0x0001E084
		public NetworkBehaviourReference(NetworkBehaviour networkBehaviour)
		{
			if (networkBehaviour == null)
			{
				this.m_NetworkObjectReference = new NetworkObjectReference(null);
				this.m_NetworkBehaviourId = NetworkBehaviourReference.s_NullId;
				return;
			}
			if (networkBehaviour.NetworkObject == null)
			{
				throw new ArgumentException("Cannot create NetworkBehaviourReference from NetworkBehaviour without a NetworkObject.");
			}
			this.m_NetworkObjectReference = networkBehaviour.NetworkObject;
			this.m_NetworkBehaviourId = networkBehaviour.NetworkBehaviourId;
		}

		// Token: 0x06000885 RID: 2181 RVA: 0x0001FEE8 File Offset: 0x0001E0E8
		public bool TryGet(out NetworkBehaviour networkBehaviour, NetworkManager networkManager = null)
		{
			networkBehaviour = NetworkBehaviourReference.GetInternal(this, networkManager);
			return networkBehaviour != null;
		}

		// Token: 0x06000886 RID: 2182 RVA: 0x0001FF00 File Offset: 0x0001E100
		public bool TryGet<T>(out T networkBehaviour, NetworkManager networkManager = null) where T : NetworkBehaviour
		{
			networkBehaviour = (NetworkBehaviourReference.GetInternal(this, networkManager) as T);
			return networkBehaviour != null;
		}

		// Token: 0x06000887 RID: 2183 RVA: 0x0001FF30 File Offset: 0x0001E130
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static NetworkBehaviour GetInternal(NetworkBehaviourReference networkBehaviourRef, NetworkManager networkManager = null)
		{
			if (networkBehaviourRef.m_NetworkBehaviourId == NetworkBehaviourReference.s_NullId)
			{
				return null;
			}
			NetworkObject networkObject;
			if (networkBehaviourRef.m_NetworkObjectReference.TryGet(out networkObject, networkManager))
			{
				return networkObject.GetNetworkBehaviourAtOrderIndex(networkBehaviourRef.m_NetworkBehaviourId);
			}
			return null;
		}

		// Token: 0x06000888 RID: 2184 RVA: 0x0001FF6B File Offset: 0x0001E16B
		public bool Equals(NetworkBehaviourReference other)
		{
			return this.m_NetworkObjectReference.Equals(other.m_NetworkObjectReference) && this.m_NetworkBehaviourId == other.m_NetworkBehaviourId;
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x0001FF90 File Offset: 0x0001E190
		public override bool Equals(object obj)
		{
			if (obj is NetworkBehaviourReference)
			{
				NetworkBehaviourReference other = (NetworkBehaviourReference)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0600088A RID: 2186 RVA: 0x0001FFB5 File Offset: 0x0001E1B5
		public override int GetHashCode()
		{
			return this.m_NetworkObjectReference.GetHashCode() * 397 ^ this.m_NetworkBehaviourId.GetHashCode();
		}

		// Token: 0x0600088B RID: 2187 RVA: 0x0001FFDC File Offset: 0x0001E1DC
		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
			this.m_NetworkObjectReference.NetworkSerialize<T>(serializer);
			serializer.SerializeValue<ushort>(ref this.m_NetworkBehaviourId, default(FastBufferWriter.ForPrimitives));
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x0002000B File Offset: 0x0001E20B
		public static implicit operator NetworkBehaviour(NetworkBehaviourReference networkBehaviourRef)
		{
			return NetworkBehaviourReference.GetInternal(networkBehaviourRef, null);
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x00020014 File Offset: 0x0001E214
		public static implicit operator NetworkBehaviourReference(NetworkBehaviour networkBehaviour)
		{
			return new NetworkBehaviourReference(networkBehaviour);
		}

		// Token: 0x0400032E RID: 814
		private NetworkObjectReference m_NetworkObjectReference;

		// Token: 0x0400032F RID: 815
		private ushort m_NetworkBehaviourId;

		// Token: 0x04000330 RID: 816
		private static ushort s_NullId = ushort.MaxValue;
	}
}
