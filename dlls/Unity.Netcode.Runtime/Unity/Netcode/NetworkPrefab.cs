using System;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x0200000B RID: 11
	[Serializable]
	public class NetworkPrefab
	{
		// Token: 0x06000012 RID: 18 RVA: 0x000027B8 File Offset: 0x000009B8
		public bool Equals(NetworkPrefab other)
		{
			return this.Override == other.Override && this.Prefab == other.Prefab && this.SourcePrefabToOverride == other.SourcePrefabToOverride && this.SourceHashToOverride == other.SourceHashToOverride && this.OverridingTargetPrefab == other.OverridingTargetPrefab;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000013 RID: 19 RVA: 0x0000281C File Offset: 0x00000A1C
		public uint SourcePrefabGlobalObjectIdHash
		{
			get
			{
				switch (this.Override)
				{
				case NetworkPrefabOverride.None:
				{
					NetworkObject networkObject;
					if (this.Prefab != null && this.Prefab.TryGetComponent<NetworkObject>(out networkObject))
					{
						return networkObject.GlobalObjectIdHash;
					}
					throw new InvalidOperationException("Prefab field is not set or is not a NetworkObject");
				}
				case NetworkPrefabOverride.Prefab:
				{
					NetworkObject networkObject2;
					if (this.SourcePrefabToOverride != null && this.SourcePrefabToOverride.TryGetComponent<NetworkObject>(out networkObject2))
					{
						return networkObject2.GlobalObjectIdHash;
					}
					throw new InvalidOperationException("Source Prefab field is not set or is not a NetworkObject");
				}
				case NetworkPrefabOverride.Hash:
					return this.SourceHashToOverride;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000014 RID: 20 RVA: 0x000028B0 File Offset: 0x00000AB0
		public uint TargetPrefabGlobalObjectIdHash
		{
			get
			{
				NetworkPrefabOverride @override = this.Override;
				if (@override == NetworkPrefabOverride.None)
				{
					return 0U;
				}
				if (@override - NetworkPrefabOverride.Prefab > 1)
				{
					throw new ArgumentOutOfRangeException();
				}
				NetworkObject networkObject;
				if (this.OverridingTargetPrefab != null && this.OverridingTargetPrefab.TryGetComponent<NetworkObject>(out networkObject))
				{
					return networkObject.GlobalObjectIdHash;
				}
				throw new InvalidOperationException("Target Prefab field is not set or is not a NetworkObject");
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002908 File Offset: 0x00000B08
		public bool Validate(int index = -1)
		{
			if (this.Override == NetworkPrefabOverride.None)
			{
				if (this.Prefab == null)
				{
					NetworkLog.LogWarning(string.Format("{0} cannot be null ({1} at index: {2})", "NetworkPrefab", "NetworkPrefab", index));
					return false;
				}
				NetworkObject component = this.Prefab.GetComponent<NetworkObject>();
				if (component == null)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
					{
						NetworkLog.LogWarning(NetworkPrefabHandler.PrefabDebugHelper(this) + " is missing a NetworkObject component (entry will be ignored).");
					}
					return false;
				}
				return true;
			}
			else
			{
				NetworkPrefabOverride @override = this.Override;
				if (@override != NetworkPrefabOverride.Prefab)
				{
					if (@override == NetworkPrefabOverride.Hash && this.SourceHashToOverride == 0U)
					{
						if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
						{
							NetworkLog.LogWarning("NetworkPrefab SourceHashToOverride is zero (entry will be ignored).");
						}
						return false;
					}
				}
				else
				{
					if (this.SourcePrefabToOverride == null)
					{
						if (this.Prefab != null)
						{
							this.SourcePrefabToOverride = this.Prefab;
						}
						else if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
						{
							NetworkLog.LogWarning("NetworkPrefab SourcePrefabToOverride is null (entry will be ignored).");
							return false;
						}
					}
					NetworkObject component;
					if (!this.SourcePrefabToOverride.TryGetComponent<NetworkObject>(out component))
					{
						if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
						{
							NetworkLog.LogWarning("NetworkPrefab (" + this.SourcePrefabToOverride.name + ") is missing a NetworkObject component (entry will be ignored).");
						}
						return false;
					}
				}
				if (this.OverridingTargetPrefab == null)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
					{
						NetworkLog.LogWarning("NetworkPrefab OverridingTargetPrefab is null!");
					}
					@override = this.Override;
					if (@override != NetworkPrefabOverride.Prefab)
					{
						if (@override == NetworkPrefabOverride.Hash)
						{
							Debug.LogWarning(string.Format("{0} override entry {1} will be removed and ignored.", "NetworkPrefab", this.SourceHashToOverride));
						}
					}
					else
					{
						Debug.LogWarning("NetworkPrefab override entry (" + this.SourcePrefabToOverride.name + ") will be removed and ignored.");
					}
					return false;
				}
				return true;
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002A9B File Offset: 0x00000C9B
		public override string ToString()
		{
			return string.Format("{{SourceHash: {0}, TargetHash: {1}}}", this.SourceHashToOverride, this.TargetPrefabGlobalObjectIdHash);
		}

		// Token: 0x04000028 RID: 40
		public NetworkPrefabOverride Override;

		// Token: 0x04000029 RID: 41
		public GameObject Prefab;

		// Token: 0x0400002A RID: 42
		public GameObject SourcePrefabToOverride;

		// Token: 0x0400002B RID: 43
		public uint SourceHashToOverride;

		// Token: 0x0400002C RID: 44
		public GameObject OverridingTargetPrefab;
	}
}
