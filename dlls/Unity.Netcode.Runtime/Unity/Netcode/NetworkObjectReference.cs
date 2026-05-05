using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x02000111 RID: 273
	public struct NetworkObjectReference : INetworkSerializable, IEquatable<NetworkObjectReference>
	{
		// Token: 0x170000AC RID: 172
		// (get) Token: 0x0600088F RID: 2191 RVA: 0x00020028 File Offset: 0x0001E228
		// (set) Token: 0x06000890 RID: 2192 RVA: 0x00020030 File Offset: 0x0001E230
		public ulong NetworkObjectId
		{
			get
			{
				return this.m_NetworkObjectId;
			}
			internal set
			{
				this.m_NetworkObjectId = value;
			}
		}

		// Token: 0x06000891 RID: 2193 RVA: 0x00020039 File Offset: 0x0001E239
		public NetworkObjectReference(NetworkObject networkObject)
		{
			if (networkObject == null)
			{
				this.m_NetworkObjectId = NetworkObjectReference.s_NullId;
				return;
			}
			if (!networkObject.IsSpawned)
			{
				throw new ArgumentException("NetworkObjectReference can only be created from spawned NetworkObjects.");
			}
			this.m_NetworkObjectId = networkObject.NetworkObjectId;
		}

		// Token: 0x06000892 RID: 2194 RVA: 0x00020070 File Offset: 0x0001E270
		public NetworkObjectReference(GameObject gameObject)
		{
			if (gameObject == null)
			{
				this.m_NetworkObjectId = NetworkObjectReference.s_NullId;
				return;
			}
			NetworkObject component = gameObject.GetComponent<NetworkObject>();
			if (!component)
			{
				throw new ArgumentException("Cannot create NetworkObjectReference from GameObject without a NetworkObject component.");
			}
			if (!component.IsSpawned)
			{
				throw new ArgumentException("NetworkObjectReference can only be created from spawned NetworkObjects.");
			}
			this.m_NetworkObjectId = component.NetworkObjectId;
		}

		// Token: 0x06000893 RID: 2195 RVA: 0x000200CB File Offset: 0x0001E2CB
		public bool TryGet(out NetworkObject networkObject, NetworkManager networkManager = null)
		{
			networkObject = NetworkObjectReference.Resolve(this, networkManager);
			return networkObject != null;
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x000200E4 File Offset: 0x0001E2E4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static NetworkObject Resolve(NetworkObjectReference networkObjectRef, NetworkManager networkManager = null)
		{
			if (networkObjectRef.m_NetworkObjectId == NetworkObjectReference.s_NullId)
			{
				return null;
			}
			networkManager = (networkManager ?? NetworkManager.Singleton);
			NetworkObject result;
			networkManager.SpawnManager.SpawnedObjects.TryGetValue(networkObjectRef.m_NetworkObjectId, out result);
			return result;
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x00020126 File Offset: 0x0001E326
		public bool Equals(NetworkObjectReference other)
		{
			return this.m_NetworkObjectId == other.m_NetworkObjectId;
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x00020138 File Offset: 0x0001E338
		public override bool Equals(object obj)
		{
			if (obj is NetworkObjectReference)
			{
				NetworkObjectReference other = (NetworkObjectReference)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x0002015D File Offset: 0x0001E35D
		public override int GetHashCode()
		{
			return this.m_NetworkObjectId.GetHashCode();
		}

		// Token: 0x06000898 RID: 2200 RVA: 0x0002016C File Offset: 0x0001E36C
		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
			serializer.SerializeValue<ulong>(ref this.m_NetworkObjectId, default(FastBufferWriter.ForPrimitives));
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x0002018F File Offset: 0x0001E38F
		public static implicit operator NetworkObject(NetworkObjectReference networkObjectRef)
		{
			return NetworkObjectReference.Resolve(networkObjectRef, null);
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x00020198 File Offset: 0x0001E398
		public static implicit operator NetworkObjectReference(NetworkObject networkObject)
		{
			return new NetworkObjectReference(networkObject);
		}

		// Token: 0x0600089B RID: 2203 RVA: 0x000201A0 File Offset: 0x0001E3A0
		public static implicit operator GameObject(NetworkObjectReference networkObjectRef)
		{
			NetworkObject networkObject = NetworkObjectReference.Resolve(networkObjectRef, null);
			if (networkObject != null)
			{
				return networkObject.gameObject;
			}
			return null;
		}

		// Token: 0x0600089C RID: 2204 RVA: 0x000201C6 File Offset: 0x0001E3C6
		public static implicit operator NetworkObjectReference(GameObject gameObject)
		{
			return new NetworkObjectReference(gameObject);
		}

		// Token: 0x04000331 RID: 817
		private ulong m_NetworkObjectId;

		// Token: 0x04000332 RID: 818
		private static ulong s_NullId = ulong.MaxValue;
	}
}
