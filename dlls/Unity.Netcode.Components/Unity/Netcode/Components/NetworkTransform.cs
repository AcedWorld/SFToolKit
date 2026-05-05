using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

namespace Unity.Netcode.Components
{
	// Token: 0x02000020 RID: 32
	[DisallowMultipleComponent]
	[AddComponentMenu("Netcode/Network Transform")]
	[DefaultExecutionOrder(100000)]
	public class NetworkTransform : NetworkBehaviour
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x000064CD File Offset: 0x000046CD
		private bool SynchronizePosition
		{
			get
			{
				return this.SyncPositionX || this.SyncPositionY || this.SyncPositionZ;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x000064E7 File Offset: 0x000046E7
		private bool SynchronizeRotation
		{
			get
			{
				return this.SyncRotAngleX || this.SyncRotAngleY || this.SyncRotAngleZ;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x00006501 File Offset: 0x00004701
		private bool SynchronizeScale
		{
			get
			{
				return this.SyncScaleX || this.SyncScaleY || this.SyncScaleZ;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060000BA RID: 186 RVA: 0x0000651B File Offset: 0x0000471B
		// (set) Token: 0x060000BB RID: 187 RVA: 0x00006523 File Offset: 0x00004723
		public bool CanCommitToTransform { get; protected set; }

		// Token: 0x060000BC RID: 188 RVA: 0x0000652C File Offset: 0x0000472C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3 GetSpaceRelativePosition(bool getCurrentState = false)
		{
			if (!getCurrentState || this.CanCommitToTransform)
			{
				if (!this.InLocalSpace)
				{
					return base.transform.position;
				}
				return base.transform.localPosition;
			}
			else
			{
				if (this.UseHalfFloatPrecision)
				{
					return this.m_HalfPositionState.GetFullPosition();
				}
				return this.m_CurrentPosition;
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000657E File Offset: 0x0000477E
		public Quaternion GetSpaceRelativeRotation(bool getCurrentState = false)
		{
			if (getCurrentState && !this.CanCommitToTransform)
			{
				return this.m_CurrentRotation;
			}
			if (!this.InLocalSpace)
			{
				return base.transform.rotation;
			}
			return base.transform.localRotation;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x000065B1 File Offset: 0x000047B1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3 GetScale(bool getCurrentState = false)
		{
			if (!getCurrentState || this.CanCommitToTransform)
			{
				return base.transform.localScale;
			}
			return this.m_CurrentScale;
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060000BF RID: 191 RVA: 0x000065D0 File Offset: 0x000047D0
		// (set) Token: 0x060000C0 RID: 192 RVA: 0x000065D8 File Offset: 0x000047D8
		internal NetworkTransform.NetworkTransformState LocalAuthoritativeNetworkState
		{
			get
			{
				return this.m_LocalAuthoritativeNetworkState;
			}
			set
			{
				this.m_LocalAuthoritativeNetworkState = value;
			}
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x000065E1 File Offset: 0x000047E1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void UpdatePositionInterpolator(Vector3 position, double time, bool resetInterpolator = false)
		{
			if (!this.CanCommitToTransform)
			{
				if (resetInterpolator)
				{
					this.m_PositionInterpolator.ResetTo(position, time);
					return;
				}
				this.m_PositionInterpolator.AddMeasurement(position, time);
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00003322 File Offset: 0x00001522
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void AddLogEntry(ref NetworkTransform.NetworkTransformState networkTransformState, ulong targetClient, bool preUpdate = false)
		{
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00006609 File Offset: 0x00004809
		internal void UpdatePositionSlerp()
		{
			if (this.m_PositionInterpolator != null)
			{
				this.m_PositionInterpolator.IsSlerp = this.SlerpPosition;
			}
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00006624 File Offset: 0x00004824
		private bool ShouldSynchronizeHalfFloat(ulong targetClientId)
		{
			return this.IsServerAuthoritative() || base.NetworkObject.OwnerClientId != targetClientId || base.NetworkObject.IsOwnedByServer;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000664C File Offset: 0x0000484C
		protected override void OnSynchronize<T>(ref BufferSerializer<T> serializer)
		{
			this.m_CachedNetworkManager = base.NetworkManager;
			ulong targetIdBeingSynchronized = base.m_TargetIdBeingSynchronized;
			NetworkTransform.NetworkTransformState networkTransformState = new NetworkTransform.NetworkTransformState
			{
				HalfEulerRotation = default(HalfVector3),
				HalfVectorRotation = default(HalfVector4),
				HalfVectorScale = default(HalfVector3),
				NetworkDeltaPosition = default(NetworkDeltaPosition)
			};
			if (serializer.IsWriter)
			{
				networkTransformState.IsTeleportingNextFrame = true;
				Transform transform = base.transform;
				this.ApplyTransformToNetworkStateWithInfo(ref networkTransformState, ref transform, true, targetIdBeingSynchronized);
				networkTransformState.NetworkSerialize<T>(serializer);
				this.SynchronizeState = networkTransformState;
				return;
			}
			networkTransformState.NetworkSerialize<T>(serializer);
			this.InLocalSpace = networkTransformState.InLocalSpace;
			this.Interpolate = networkTransformState.UseInterpolation;
			this.UseQuaternionSynchronization = networkTransformState.QuaternionSync;
			this.UseHalfFloatPrecision = networkTransformState.UseHalfFloatPrecision;
			this.UseQuaternionCompression = networkTransformState.QuaternionCompression;
			this.SlerpPosition = networkTransformState.UsePositionSlerp;
			this.UpdatePositionSlerp();
			this.ApplyTeleportingState(networkTransformState);
			this.SynchronizeState = networkTransformState;
			this.m_LocalAuthoritativeNetworkState = networkTransformState;
			this.m_LocalAuthoritativeNetworkState.IsTeleportingNextFrame = false;
			this.m_LocalAuthoritativeNetworkState.IsSynchronizing = false;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00006774 File Offset: 0x00004974
		protected void TryCommitTransformToServer(Transform transformToCommit, double dirtyTime)
		{
			if (!base.IsSpawned)
			{
				NetworkLog.LogError("Cannot commit transform when not spawned!");
				return;
			}
			if (!base.IsServer && !base.IsOwner)
			{
				NetworkLog.LogError((base.gameObject != base.NetworkObject.gameObject) ? string.Concat(new string[]
				{
					"Non-authority instance of ",
					base.NetworkObject.gameObject.name,
					" is trying to commit a transform on ",
					base.gameObject.name,
					"!"
				}) : ("Non-authority instance of " + base.NetworkObject.gameObject.name + " is trying to commit a transform!"));
				return;
			}
			if (this.CanCommitToTransform)
			{
				this.OnUpdateAuthoritativeState(ref transformToCommit);
				return;
			}
			Vector3 pos = this.InLocalSpace ? transformToCommit.localPosition : transformToCommit.position;
			Quaternion rot = this.InLocalSpace ? transformToCommit.localRotation : transformToCommit.rotation;
			if (!base.IsServer)
			{
				this.SetStateServerRpc(pos, rot, transformToCommit.localScale, false);
				return;
			}
			this.SetStateClientRpc(pos, rot, transformToCommit.localScale, false, default(ClientRpcParams));
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00003322 File Offset: 0x00001522
		protected virtual void OnAuthorityPushTransformState(ref NetworkTransform.NetworkTransformState networkTransformState)
		{
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000689C File Offset: 0x00004A9C
		private void TryCommitTransform(ref Transform transformToCommit, bool synchronize = false, bool settingState = false)
		{
			if (!base.IsServer && !base.IsOwner)
			{
				NetworkLog.LogError("[" + base.name + "] is trying to commit the transform without authority!");
				return;
			}
			if (this.m_LocalAuthoritativeNetworkState.ExplicitSet || this.ApplyTransformToNetworkStateWithInfo(ref this.m_LocalAuthoritativeNetworkState, ref transformToCommit, synchronize, 0UL))
			{
				this.m_LocalAuthoritativeNetworkState.LastSerializedSize = this.m_OldState.LastSerializedSize;
				if (this.m_LocalAuthoritativeNetworkState.ExplicitSet)
				{
					this.m_LocalAuthoritativeNetworkState.NetworkTick = this.m_CachedNetworkManager.NetworkTickSystem.ServerTime.Tick;
				}
				this.UpdateTransformState();
				this.m_OldState = this.m_LocalAuthoritativeNetworkState;
				this.m_LocalAuthoritativeNetworkState.IsTeleportingNextFrame = false;
				this.m_LocalAuthoritativeNetworkState.ExplicitSet = false;
				try
				{
					this.OnAuthorityPushTransformState(ref this.m_LocalAuthoritativeNetworkState);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
				if (this.UseUnreliableDeltas && !this.m_LocalAuthoritativeNetworkState.UnreliableFrameSync && !synchronize)
				{
					this.m_DeltaSynch = true;
				}
			}
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x000069AC File Offset: 0x00004BAC
		private void ResetInterpolatedStateToCurrentAuthoritativeState()
		{
			double time = base.NetworkManager.ServerTime.Time;
			this.UpdatePositionInterpolator(this.GetSpaceRelativePosition(false), time, true);
			this.UpdatePositionSlerp();
			this.m_ScaleInterpolator.ResetTo(base.transform.localScale, time);
			this.m_RotationInterpolator.ResetTo(this.GetSpaceRelativeRotation(false), time);
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00006A0C File Offset: 0x00004C0C
		internal NetworkTransform.NetworkTransformState ApplyLocalNetworkState(Transform transform)
		{
			this.m_LocalAuthoritativeNetworkState.ClearBitSetForNextTick();
			this.ApplyTransformToNetworkStateWithInfo(ref this.m_LocalAuthoritativeNetworkState, ref transform, false, 0UL);
			return this.m_LocalAuthoritativeNetworkState;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00006A34 File Offset: 0x00004C34
		internal bool ApplyTransformToNetworkState(ref NetworkTransform.NetworkTransformState networkState, double dirtyTime, Transform transformToUse)
		{
			this.m_CachedNetworkManager = base.NetworkManager;
			networkState.UseInterpolation = this.Interpolate;
			networkState.QuaternionSync = this.UseQuaternionSynchronization;
			networkState.UseHalfFloatPrecision = this.UseHalfFloatPrecision;
			networkState.QuaternionCompression = this.UseQuaternionCompression;
			networkState.UseUnreliableDeltas = this.UseUnreliableDeltas;
			this.m_HalfPositionState = new NetworkDeltaPosition(Vector3.zero, 0, math.bool3(this.SyncPositionX, this.SyncPositionY, this.SyncPositionZ));
			return this.ApplyTransformToNetworkStateWithInfo(ref networkState, ref transformToUse, false, 0UL);
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00006AC0 File Offset: 0x00004CC0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool ApplyTransformToNetworkStateWithInfo(ref NetworkTransform.NetworkTransformState networkState, ref Transform transformToUse, bool isSynchronization = false, ulong targetClientId = 0UL)
		{
			bool flag = false;
			if (this.UseUnreliableDeltas && !isSynchronization && this.m_DeltaSynch && this.m_NextTickSync <= this.m_CachedNetworkManager.NetworkTickSystem.ServerTime.Tick)
			{
				this.m_NextTickSync += (int)this.m_CachedNetworkManager.NetworkConfig.TickRate;
				flag = !networkState.IsTeleportingNextFrame;
				this.m_DeltaSynch = false;
			}
			networkState.UnreliableFrameSync = flag;
			object obj = networkState.IsTeleportingNextFrame && !isSynchronization;
			bool flag2 = false;
			object obj2 = obj;
			bool flag3 = obj2 != null && networkState.HasPositionChange;
			bool flag4 = obj2 != null && networkState.HasRotAngleChange;
			bool flag5 = obj2 != null && networkState.HasScaleChange;
			Vector3 vector = this.InLocalSpace ? transformToUse.localPosition : transformToUse.position;
			Vector3 vector2 = this.InLocalSpace ? transformToUse.localEulerAngles : transformToUse.eulerAngles;
			Vector3 localScale = transformToUse.localScale;
			networkState.IsSynchronizing = isSynchronization;
			if (this.InLocalSpace != networkState.InLocalSpace)
			{
				networkState.InLocalSpace = this.InLocalSpace;
				flag2 = true;
				networkState.IsTeleportingNextFrame = true;
			}
			if (isSynchronization || networkState.IsTeleportingNextFrame)
			{
				bool isParented = false;
				NetworkObject networkObject = null;
				if (base.NetworkObject.transform.parent != null)
				{
					networkObject = base.NetworkObject.transform.parent.GetComponent<NetworkObject>();
					if (networkObject == null)
					{
						bool? isSceneObject = base.NetworkObject.IsSceneObject;
						bool flag6 = false;
						if (!(isSceneObject.GetValueOrDefault() == flag6 & isSceneObject != null))
						{
							isParented = true;
							goto IL_18B;
						}
					}
					isParented = (networkObject != null);
				}
				IL_18B:
				networkState.IsParented = isParented;
				if (isSynchronization && networkState.IsParented)
				{
					bool flag7 = base.NetworkObject.transform.parent != null && !networkObject && base.NetworkObject.IsSceneObject.Value;
					if (base.NetworkObject.WorldPositionStays() && (!flag7 || (flag7 && !base.NetworkObject.AutoObjectParentSync && !this.InLocalSpace)))
					{
						vector = transformToUse.position;
						networkState.InLocalSpace = false;
					}
					else
					{
						vector = transformToUse.localPosition;
						networkState.InLocalSpace = true;
					}
				}
			}
			if (this.Interpolate != networkState.UseInterpolation)
			{
				networkState.UseInterpolation = this.Interpolate;
				flag2 = true;
				networkState.IsTeleportingNextFrame = true;
			}
			if (this.UseQuaternionSynchronization != networkState.QuaternionSync)
			{
				networkState.QuaternionSync = this.UseQuaternionSynchronization;
				flag2 = true;
				networkState.IsTeleportingNextFrame = true;
			}
			if (this.UseQuaternionCompression != networkState.QuaternionCompression)
			{
				networkState.QuaternionCompression = this.UseQuaternionCompression;
				flag2 = true;
				networkState.IsTeleportingNextFrame = true;
			}
			if (this.UseHalfFloatPrecision != networkState.UseHalfFloatPrecision)
			{
				networkState.UseHalfFloatPrecision = this.UseHalfFloatPrecision;
				flag2 = true;
				networkState.IsTeleportingNextFrame = true;
			}
			if (this.SlerpPosition != networkState.UsePositionSlerp)
			{
				networkState.UsePositionSlerp = this.SlerpPosition;
				flag2 = true;
				networkState.IsTeleportingNextFrame = true;
			}
			if (this.UseUnreliableDeltas != networkState.UseUnreliableDeltas)
			{
				networkState.UseUnreliableDeltas = this.UseUnreliableDeltas;
				flag2 = true;
				networkState.IsTeleportingNextFrame = true;
			}
			if (!this.UseHalfFloatPrecision)
			{
				if (this.SyncPositionX && (Mathf.Abs(networkState.PositionX - vector.x) >= this.PositionThreshold || networkState.IsTeleportingNextFrame || flag))
				{
					networkState.PositionX = vector.x;
					networkState.HasPositionX = true;
					flag3 = true;
				}
				if (this.SyncPositionY && (Mathf.Abs(networkState.PositionY - vector.y) >= this.PositionThreshold || networkState.IsTeleportingNextFrame || flag))
				{
					networkState.PositionY = vector.y;
					networkState.HasPositionY = true;
					flag3 = true;
				}
				if (this.SyncPositionZ && (Mathf.Abs(networkState.PositionZ - vector.z) >= this.PositionThreshold || networkState.IsTeleportingNextFrame || flag))
				{
					networkState.PositionZ = vector.z;
					networkState.HasPositionZ = true;
					flag3 = true;
				}
			}
			else if (this.SynchronizePosition)
			{
				flag3 = (networkState.IsTeleportingNextFrame || flag);
				if (this.m_HalfFloatTargetTickOwnership > this.m_CachedNetworkManager.ServerTime.Tick)
				{
					flag3 = true;
				}
				if (!flag3)
				{
					for (int i = 0; i < 3; i++)
					{
						if (Math.Abs(vector[i] - this.m_HalfPositionState.PreviousPosition[i]) >= this.PositionThreshold)
						{
							flag3 = ((i == 0) ? this.SyncPositionX : ((i == 1) ? this.SyncPositionY : this.SyncPositionZ));
							if (flag3)
							{
								break;
							}
						}
					}
				}
				if (flag3)
				{
					if (!isSynchronization)
					{
						if (networkState.IsTeleportingNextFrame)
						{
							this.m_HalfPositionState = new NetworkDeltaPosition(vector, networkState.NetworkTick, math.bool3(this.SyncPositionX, this.SyncPositionY, this.SyncPositionZ));
							networkState.CurrentPosition = vector;
						}
						else
						{
							this.m_HalfPositionState.HalfVector3.AxisToSynchronize = math.bool3(this.SyncPositionX, this.SyncPositionY, this.SyncPositionZ);
							this.m_HalfPositionState.UpdateFrom(ref vector, networkState.NetworkTick);
						}
						networkState.NetworkDeltaPosition = this.m_HalfPositionState;
						if ((this.m_HalfFloatTargetTickOwnership > this.m_CachedNetworkManager.ServerTime.Tick || flag) && !networkState.IsTeleportingNextFrame)
						{
							networkState.SynchronizeBaseHalfFloat = true;
						}
						else
						{
							networkState.SynchronizeBaseHalfFloat = (this.UseUnreliableDeltas && this.m_HalfPositionState.CollapsedDeltaIntoBase);
						}
					}
					else
					{
						if (this.ShouldSynchronizeHalfFloat(targetClientId))
						{
							if (this.m_HalfPositionState.NetworkTick > 0)
							{
								networkState.CurrentPosition = this.m_HalfPositionState.CurrentBasePosition;
								networkState.NetworkDeltaPosition = this.m_HalfPositionState;
								if (base.NetworkObject.IsOwnedByServer || this.IsServerAuthoritative())
								{
									networkState.DeltaPosition = this.m_HalfPositionState.HalfDeltaConvertedBack;
								}
								else
								{
									networkState.DeltaPosition = this.m_HalfPositionState.DeltaPosition;
								}
							}
							else
							{
								networkState.NetworkDeltaPosition = new NetworkDeltaPosition(Vector3.zero, 0, math.bool3(this.SyncPositionX, this.SyncPositionY, this.SyncPositionZ));
								networkState.DeltaPosition = Vector3.zero;
								networkState.CurrentPosition = vector;
							}
						}
						else
						{
							networkState.NetworkDeltaPosition = new NetworkDeltaPosition(Vector3.zero, 0, math.bool3(this.SyncPositionX, this.SyncPositionY, this.SyncPositionZ));
							networkState.CurrentPosition = vector;
						}
						this.AddLogEntry(ref networkState, targetClientId, true);
					}
					networkState.HasPositionX = this.SyncPositionX;
					networkState.HasPositionY = this.SyncPositionY;
					networkState.HasPositionZ = this.SyncPositionZ;
				}
			}
			if (!this.UseQuaternionSynchronization)
			{
				if (this.SyncRotAngleX && (Mathf.Abs(Mathf.DeltaAngle(networkState.RotAngleX, vector2.x)) >= this.RotAngleThreshold || networkState.IsTeleportingNextFrame || flag))
				{
					networkState.RotAngleX = vector2.x;
					networkState.HasRotAngleX = true;
					flag4 = true;
				}
				if (this.SyncRotAngleY && (Mathf.Abs(Mathf.DeltaAngle(networkState.RotAngleY, vector2.y)) >= this.RotAngleThreshold || networkState.IsTeleportingNextFrame || flag))
				{
					networkState.RotAngleY = vector2.y;
					networkState.HasRotAngleY = true;
					flag4 = true;
				}
				if (this.SyncRotAngleZ && (Mathf.Abs(Mathf.DeltaAngle(networkState.RotAngleZ, vector2.z)) >= this.RotAngleThreshold || networkState.IsTeleportingNextFrame || flag))
				{
					networkState.RotAngleZ = vector2.z;
					networkState.HasRotAngleZ = true;
					flag4 = true;
				}
			}
			else if (this.SynchronizeRotation)
			{
				flag4 = (networkState.IsTeleportingNextFrame || flag);
				if (!flag4)
				{
					Vector3 eulerAngles = networkState.Rotation.eulerAngles;
					for (int j = 0; j < 3; j++)
					{
						if (Mathf.Abs(Mathf.DeltaAngle(eulerAngles[j], vector2[j])) >= this.RotAngleThreshold)
						{
							flag4 = true;
							break;
						}
					}
				}
				if (flag4)
				{
					networkState.Rotation = (this.InLocalSpace ? transformToUse.localRotation : transformToUse.rotation);
					networkState.HasRotAngleX = true;
					networkState.HasRotAngleY = true;
					networkState.HasRotAngleZ = true;
				}
			}
			if ((isSynchronization || networkState.IsTeleportingNextFrame) && networkState.IsParented)
			{
				networkState.LossyScale = base.transform.lossyScale;
			}
			if (!isSynchronization)
			{
				if (!this.UseHalfFloatPrecision)
				{
					if (this.SyncScaleX && (Mathf.Abs(networkState.ScaleX - localScale.x) >= this.ScaleThreshold || networkState.IsTeleportingNextFrame || flag))
					{
						networkState.ScaleX = localScale.x;
						networkState.HasScaleX = true;
						flag5 = true;
					}
					if (this.SyncScaleY && (Mathf.Abs(networkState.ScaleY - localScale.y) >= this.ScaleThreshold || networkState.IsTeleportingNextFrame || flag))
					{
						networkState.ScaleY = localScale.y;
						networkState.HasScaleY = true;
						flag5 = true;
					}
					if (this.SyncScaleZ && (Mathf.Abs(networkState.ScaleZ - localScale.z) >= this.ScaleThreshold || networkState.IsTeleportingNextFrame || flag))
					{
						networkState.ScaleZ = localScale.z;
						networkState.HasScaleZ = true;
						flag5 = true;
					}
				}
				else if (this.SynchronizeScale)
				{
					Vector3 scale = networkState.Scale;
					for (int k = 0; k < 3; k++)
					{
						if (Mathf.Abs(localScale[k] - scale[k]) >= this.ScaleThreshold || networkState.IsTeleportingNextFrame || flag)
						{
							flag5 = true;
							networkState.Scale[k] = localScale[k];
							networkState.SetHasScale(k, (k == 0) ? this.SyncScaleX : ((k == 1) ? this.SyncScaleY : this.SyncScaleZ));
						}
					}
				}
			}
			else if (this.SynchronizeScale)
			{
				if (!this.UseHalfFloatPrecision)
				{
					networkState.ScaleX = base.transform.localScale.x;
					networkState.ScaleY = base.transform.localScale.y;
					networkState.ScaleZ = base.transform.localScale.z;
				}
				else
				{
					networkState.Scale = base.transform.localScale;
				}
				networkState.HasScaleX = true;
				networkState.HasScaleY = true;
				networkState.HasScaleZ = true;
				flag5 = true;
			}
			flag2 |= (flag3 || flag4 || flag5);
			if (flag2 && base.enabled)
			{
				networkState.NetworkTick = this.m_CachedNetworkManager.NetworkTickSystem.ServerTime.Tick;
			}
			networkState.IsDirty = (networkState.IsDirty || flag2);
			return flag2;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00003322 File Offset: 0x00001522
		protected virtual void OnTransformUpdated()
		{
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00007524 File Offset: 0x00005724
		protected internal void ApplyAuthoritativeState()
		{
			NetworkTransform.NetworkTransformState localAuthoritativeNetworkState = this.m_LocalAuthoritativeNetworkState;
			Vector3 currentPosition = this.m_CurrentPosition;
			Quaternion currentRotation = this.m_CurrentRotation;
			Vector3 eulerAngles = currentRotation.eulerAngles;
			Vector3 currentScale = this.m_CurrentScale;
			this.InLocalSpace = localAuthoritativeNetworkState.InLocalSpace;
			this.Interpolate = localAuthoritativeNetworkState.UseInterpolation;
			this.UseHalfFloatPrecision = localAuthoritativeNetworkState.UseHalfFloatPrecision;
			this.UseQuaternionSynchronization = localAuthoritativeNetworkState.QuaternionSync;
			this.UseQuaternionCompression = localAuthoritativeNetworkState.QuaternionCompression;
			this.UseUnreliableDeltas = localAuthoritativeNetworkState.UseUnreliableDeltas;
			if (this.SlerpPosition != localAuthoritativeNetworkState.UsePositionSlerp)
			{
				this.SlerpPosition = localAuthoritativeNetworkState.UsePositionSlerp;
				this.UpdatePositionSlerp();
			}
			if (this.Interpolate)
			{
				if (this.SynchronizePosition)
				{
					Vector3 interpolatedValue = this.m_PositionInterpolator.GetInterpolatedValue();
					if (this.UseHalfFloatPrecision)
					{
						currentPosition = interpolatedValue;
					}
					else
					{
						if (this.SyncPositionX)
						{
							currentPosition.x = interpolatedValue.x;
						}
						if (this.SyncPositionY)
						{
							currentPosition.y = interpolatedValue.y;
						}
						if (this.SyncPositionZ)
						{
							currentPosition.z = interpolatedValue.z;
						}
					}
				}
				if (this.SynchronizeScale)
				{
					if (this.UseHalfFloatPrecision)
					{
						currentScale = this.m_ScaleInterpolator.GetInterpolatedValue();
					}
					else
					{
						Vector3 interpolatedValue2 = this.m_ScaleInterpolator.GetInterpolatedValue();
						if (this.SyncScaleX)
						{
							currentScale.x = interpolatedValue2.x;
						}
						if (this.SyncScaleY)
						{
							currentScale.y = interpolatedValue2.y;
						}
						if (this.SyncScaleZ)
						{
							currentScale.z = interpolatedValue2.z;
						}
					}
				}
				if (this.SynchronizeRotation)
				{
					Quaternion interpolatedValue3 = this.m_RotationInterpolator.GetInterpolatedValue();
					if (this.UseQuaternionSynchronization)
					{
						currentRotation = interpolatedValue3;
					}
					else
					{
						Vector3 eulerAngles2 = interpolatedValue3.eulerAngles;
						if (this.SyncRotAngleX)
						{
							eulerAngles.x = eulerAngles2.x;
						}
						if (this.SyncRotAngleY)
						{
							eulerAngles.y = eulerAngles2.y;
						}
						if (this.SyncRotAngleZ)
						{
							eulerAngles.z = eulerAngles2.z;
						}
						currentRotation.eulerAngles = eulerAngles;
					}
				}
			}
			else
			{
				if (this.UseHalfFloatPrecision)
				{
					if (localAuthoritativeNetworkState.HasPositionChange && this.SynchronizePosition)
					{
						currentPosition = this.m_TargetPosition;
					}
					if (localAuthoritativeNetworkState.HasScaleChange && this.SynchronizeScale)
					{
						for (int i = 0; i < 3; i++)
						{
							if (this.m_LocalAuthoritativeNetworkState.HasScale(i))
							{
								currentScale[i] = this.m_LocalAuthoritativeNetworkState.Scale[i];
							}
						}
					}
				}
				else
				{
					if (localAuthoritativeNetworkState.HasPositionX)
					{
						currentPosition.x = localAuthoritativeNetworkState.PositionX;
					}
					if (localAuthoritativeNetworkState.HasPositionY)
					{
						currentPosition.y = localAuthoritativeNetworkState.PositionY;
					}
					if (localAuthoritativeNetworkState.HasPositionZ)
					{
						currentPosition.z = localAuthoritativeNetworkState.PositionZ;
					}
					if (localAuthoritativeNetworkState.HasScaleX)
					{
						currentScale.x = localAuthoritativeNetworkState.ScaleX;
					}
					if (localAuthoritativeNetworkState.HasScaleY)
					{
						currentScale.y = localAuthoritativeNetworkState.ScaleY;
					}
					if (localAuthoritativeNetworkState.HasScaleZ)
					{
						currentScale.z = localAuthoritativeNetworkState.ScaleZ;
					}
				}
				if (this.SynchronizeRotation)
				{
					if (localAuthoritativeNetworkState.QuaternionSync && localAuthoritativeNetworkState.HasRotAngleChange)
					{
						currentRotation = localAuthoritativeNetworkState.Rotation;
					}
					else
					{
						if (localAuthoritativeNetworkState.HasRotAngleX)
						{
							eulerAngles.x = localAuthoritativeNetworkState.RotAngleX;
						}
						if (localAuthoritativeNetworkState.HasRotAngleY)
						{
							eulerAngles.y = localAuthoritativeNetworkState.RotAngleY;
						}
						if (localAuthoritativeNetworkState.HasRotAngleZ)
						{
							eulerAngles.z = localAuthoritativeNetworkState.RotAngleZ;
						}
						currentRotation.eulerAngles = eulerAngles;
					}
				}
			}
			if (this.SynchronizePosition)
			{
				if (localAuthoritativeNetworkState.HasPositionChange || this.Interpolate)
				{
					this.m_CurrentPosition = currentPosition;
				}
				if (this.InLocalSpace)
				{
					base.transform.localPosition = this.m_CurrentPosition;
				}
				else
				{
					base.transform.position = this.m_CurrentPosition;
				}
			}
			if (this.SynchronizeRotation)
			{
				if (localAuthoritativeNetworkState.HasRotAngleChange || this.Interpolate)
				{
					this.m_CurrentRotation = currentRotation;
				}
				if (this.InLocalSpace)
				{
					base.transform.localRotation = this.m_CurrentRotation;
				}
				else
				{
					base.transform.rotation = this.m_CurrentRotation;
				}
			}
			if (this.SynchronizeScale)
			{
				if (localAuthoritativeNetworkState.HasScaleChange || this.Interpolate)
				{
					this.m_CurrentScale = currentScale;
				}
				base.transform.localScale = this.m_CurrentScale;
			}
			this.OnTransformUpdated();
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000795C File Offset: 0x00005B5C
		private void ApplyTeleportingState(NetworkTransform.NetworkTransformState newState)
		{
			if (!newState.IsTeleportingNextFrame)
			{
				return;
			}
			double sentTime = newState.SentTime;
			Vector3 vector = this.GetSpaceRelativePosition(false);
			Quaternion quaternion = this.GetSpaceRelativeRotation(false);
			Vector3 eulerAngles = quaternion.eulerAngles;
			Vector3 vector2 = base.transform.localScale;
			bool isSynchronizing = newState.IsSynchronizing;
			this.m_ScaleInterpolator.Clear();
			this.m_PositionInterpolator.Clear();
			this.m_RotationInterpolator.Clear();
			if (newState.HasPositionChange)
			{
				if (!this.UseHalfFloatPrecision)
				{
					if (newState.HasPositionX)
					{
						vector.x = newState.PositionX;
					}
					if (newState.HasPositionY)
					{
						vector.y = newState.PositionY;
					}
					if (newState.HasPositionZ)
					{
						vector.z = newState.PositionZ;
					}
				}
				else
				{
					this.m_HalfPositionState = new NetworkDeltaPosition(newState.CurrentPosition, newState.NetworkTick, math.bool3(this.SyncPositionX, this.SyncPositionY, this.SyncPositionZ));
					if (isSynchronizing)
					{
						if (this.ShouldSynchronizeHalfFloat(base.NetworkManager.LocalClientId))
						{
							this.m_HalfPositionState.HalfVector3.Axis = newState.NetworkDeltaPosition.HalfVector3.Axis;
							this.m_HalfPositionState.DeltaPosition = newState.DeltaPosition;
							vector = this.m_HalfPositionState.ToVector3(newState.NetworkTick);
						}
						else
						{
							vector = newState.CurrentPosition;
						}
						this.AddLogEntry(ref newState, base.NetworkObject.OwnerClientId, true);
					}
					else
					{
						vector = newState.CurrentPosition;
					}
				}
				this.m_CurrentPosition = vector;
				this.m_TargetPosition = vector;
				if (newState.InLocalSpace)
				{
					base.transform.localPosition = vector;
				}
				else
				{
					base.transform.position = vector;
				}
				if (this.Interpolate)
				{
					this.UpdatePositionInterpolator(vector, sentTime, true);
				}
			}
			if (newState.HasScaleChange)
			{
				bool flag = false;
				if (newState.IsParented)
				{
					if (base.transform.parent == null)
					{
						flag = base.NetworkObject.WorldPositionStays();
					}
					else
					{
						flag = !base.NetworkObject.WorldPositionStays();
					}
				}
				if (this.UseHalfFloatPrecision)
				{
					vector2 = (flag ? newState.LossyScale : newState.Scale);
				}
				else
				{
					if (newState.HasScaleX)
					{
						vector2.x = (flag ? newState.LossyScale.x : newState.ScaleX);
					}
					if (newState.HasScaleY)
					{
						vector2.y = (flag ? newState.LossyScale.y : newState.ScaleY);
					}
					if (newState.HasScaleZ)
					{
						vector2.z = (flag ? newState.LossyScale.z : newState.ScaleZ);
					}
				}
				this.m_CurrentScale = vector2;
				this.m_TargetScale = vector2;
				base.transform.localScale = vector2;
				if (this.Interpolate)
				{
					this.m_ScaleInterpolator.ResetTo(vector2, sentTime);
				}
			}
			if (newState.HasRotAngleChange)
			{
				if (newState.QuaternionSync)
				{
					quaternion = newState.Rotation;
				}
				else
				{
					if (newState.HasRotAngleX)
					{
						eulerAngles.x = newState.RotAngleX;
					}
					if (newState.HasRotAngleY)
					{
						eulerAngles.y = newState.RotAngleY;
					}
					if (newState.HasRotAngleZ)
					{
						eulerAngles.z = newState.RotAngleZ;
					}
					quaternion.eulerAngles = eulerAngles;
				}
				this.m_CurrentRotation = quaternion;
				this.m_TargetRotation = quaternion.eulerAngles;
				if (this.InLocalSpace)
				{
					base.transform.localRotation = quaternion;
				}
				else
				{
					base.transform.rotation = quaternion;
				}
				if (this.Interpolate)
				{
					this.m_RotationInterpolator.ResetTo(quaternion, sentTime);
				}
			}
			if (isSynchronizing)
			{
				this.AddLogEntry(ref newState, base.NetworkObject.OwnerClientId, false);
			}
			this.OnTransformUpdated();
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00007CF8 File Offset: 0x00005EF8
		private void ApplyUpdatedState(NetworkTransform.NetworkTransformState newState)
		{
			this.InLocalSpace = newState.InLocalSpace;
			this.Interpolate = newState.UseInterpolation;
			this.UseQuaternionSynchronization = newState.QuaternionSync;
			this.UseQuaternionCompression = newState.QuaternionCompression;
			this.UseHalfFloatPrecision = newState.UseHalfFloatPrecision;
			this.UseUnreliableDeltas = newState.UseUnreliableDeltas;
			if (this.SlerpPosition != newState.UsePositionSlerp)
			{
				this.SlerpPosition = newState.UsePositionSlerp;
				this.UpdatePositionSlerp();
			}
			this.m_LocalAuthoritativeNetworkState = newState;
			if (this.m_LocalAuthoritativeNetworkState.IsTeleportingNextFrame)
			{
				this.ApplyTeleportingState(this.m_LocalAuthoritativeNetworkState);
				return;
			}
			double sentTime = newState.SentTime;
			Quaternion newMeasurement = this.GetSpaceRelativeRotation(false);
			Vector3 vector = newMeasurement.eulerAngles;
			if (this.UseHalfFloatPrecision && this.m_LocalAuthoritativeNetworkState.HasPositionChange)
			{
				if (this.m_LocalAuthoritativeNetworkState.SynchronizeBaseHalfFloat)
				{
					this.m_HalfPositionState = this.m_LocalAuthoritativeNetworkState.NetworkDeltaPosition;
				}
				else
				{
					this.m_HalfPositionState.HalfVector3.Axis = this.m_LocalAuthoritativeNetworkState.NetworkDeltaPosition.HalfVector3.Axis;
					this.m_LocalAuthoritativeNetworkState.NetworkDeltaPosition.CurrentBasePosition = this.m_HalfPositionState.CurrentBasePosition;
					this.m_LocalAuthoritativeNetworkState.NetworkDeltaPosition.ToVector3(0);
				}
				this.m_TargetPosition = this.m_HalfPositionState.ToVector3(newState.NetworkTick);
				this.m_LocalAuthoritativeNetworkState.CurrentPosition = this.m_TargetPosition;
			}
			if (!this.Interpolate)
			{
				return;
			}
			if (this.m_LocalAuthoritativeNetworkState.HasPositionChange)
			{
				if (!this.m_LocalAuthoritativeNetworkState.UseHalfFloatPrecision)
				{
					Vector3 targetPosition = this.m_TargetPosition;
					if (this.m_LocalAuthoritativeNetworkState.HasPositionX)
					{
						targetPosition.x = this.m_LocalAuthoritativeNetworkState.PositionX;
					}
					if (this.m_LocalAuthoritativeNetworkState.HasPositionY)
					{
						targetPosition.y = this.m_LocalAuthoritativeNetworkState.PositionY;
					}
					if (this.m_LocalAuthoritativeNetworkState.HasPositionZ)
					{
						targetPosition.z = this.m_LocalAuthoritativeNetworkState.PositionZ;
					}
					this.m_TargetPosition = targetPosition;
				}
				this.UpdatePositionInterpolator(this.m_TargetPosition, sentTime, false);
			}
			if (this.m_LocalAuthoritativeNetworkState.HasScaleChange)
			{
				Vector3 targetScale = this.m_TargetScale;
				if (this.UseHalfFloatPrecision)
				{
					for (int i = 0; i < 3; i++)
					{
						if (this.m_LocalAuthoritativeNetworkState.HasScale(i))
						{
							targetScale[i] = this.m_LocalAuthoritativeNetworkState.Scale[i];
						}
					}
				}
				else
				{
					if (this.m_LocalAuthoritativeNetworkState.HasScaleX)
					{
						targetScale.x = this.m_LocalAuthoritativeNetworkState.ScaleX;
					}
					if (this.m_LocalAuthoritativeNetworkState.HasScaleY)
					{
						targetScale.y = this.m_LocalAuthoritativeNetworkState.ScaleY;
					}
					if (this.m_LocalAuthoritativeNetworkState.HasScaleZ)
					{
						targetScale.z = this.m_LocalAuthoritativeNetworkState.ScaleZ;
					}
				}
				this.m_TargetScale = targetScale;
				this.m_ScaleInterpolator.AddMeasurement(targetScale, sentTime);
			}
			if (this.m_LocalAuthoritativeNetworkState.HasRotAngleChange)
			{
				if (this.m_LocalAuthoritativeNetworkState.QuaternionSync)
				{
					newMeasurement = this.m_LocalAuthoritativeNetworkState.Rotation;
				}
				else
				{
					vector = this.m_TargetRotation;
					if (this.m_LocalAuthoritativeNetworkState.HasRotAngleX)
					{
						vector.x = this.m_LocalAuthoritativeNetworkState.RotAngleX;
					}
					if (this.m_LocalAuthoritativeNetworkState.HasRotAngleY)
					{
						vector.y = this.m_LocalAuthoritativeNetworkState.RotAngleY;
					}
					if (this.m_LocalAuthoritativeNetworkState.HasRotAngleZ)
					{
						vector.z = this.m_LocalAuthoritativeNetworkState.RotAngleZ;
					}
					this.m_TargetRotation = vector;
					newMeasurement.eulerAngles = vector;
				}
				this.m_RotationInterpolator.AddMeasurement(newMeasurement, sentTime);
			}
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00003322 File Offset: 0x00001522
		protected virtual void OnNetworkTransformStateUpdated(ref NetworkTransform.NetworkTransformState oldState, ref NetworkTransform.NetworkTransformState newState)
		{
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00003322 File Offset: 0x00001522
		protected virtual void OnBeforeUpdateTransformState()
		{
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000807C File Offset: 0x0000627C
		private void OnNetworkStateChanged(NetworkTransform.NetworkTransformState oldState, NetworkTransform.NetworkTransformState newState)
		{
			if (!base.NetworkObject.IsSpawned || this.CanCommitToTransform)
			{
				return;
			}
			if (this.UseUnreliableDeltas && oldState.NetworkTick > newState.NetworkTick && !newState.IsTeleportingNextFrame && !newState.UnreliableFrameSync)
			{
				return;
			}
			newState.SentTime = new NetworkTime(this.m_CachedNetworkManager.NetworkConfig.TickRate, newState.NetworkTick, 0.0).Time;
			this.OnBeforeUpdateTransformState();
			this.ApplyUpdatedState(newState);
			this.OnNetworkTransformStateUpdated(ref oldState, ref this.m_LocalAuthoritativeNetworkState);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00008116 File Offset: 0x00006316
		public void SetMaxInterpolationBound(float maxInterpolationBound)
		{
			this.m_RotationInterpolator.MaxInterpolationBound = maxInterpolationBound;
			this.m_PositionInterpolator.MaxInterpolationBound = maxInterpolationBound;
			this.m_ScaleInterpolator.MaxInterpolationBound = maxInterpolationBound;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000813C File Offset: 0x0000633C
		protected virtual void Awake()
		{
			this.m_RotationInterpolator = new BufferedLinearInterpolatorQuaternion();
			this.m_PositionInterpolator = new BufferedLinearInterpolatorVector3();
			this.m_ScaleInterpolator = new BufferedLinearInterpolatorVector3();
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00008160 File Offset: 0x00006360
		private void AxisChangedDeltaPositionCheck()
		{
			if (this.UseHalfFloatPrecision && this.SynchronizePosition)
			{
				bool3 axisToSynchronize = this.m_HalfPositionState.HalfVector3.AxisToSynchronize;
				if (this.SyncPositionX != axisToSynchronize.x || this.SyncPositionY != axisToSynchronize.y || this.SyncPositionZ != axisToSynchronize.z)
				{
					Vector3 fullPosition = this.m_HalfPositionState.GetFullPosition();
					Vector3 spaceRelativePosition = this.GetSpaceRelativePosition(false);
					bool isTeleportingNextFrame = false;
					if (this.SyncPositionX && this.SyncPositionX != axisToSynchronize.x)
					{
						isTeleportingNextFrame = (Mathf.Abs(spaceRelativePosition.x - fullPosition.x) >= 64f);
					}
					if (this.SyncPositionY && this.SyncPositionY != axisToSynchronize.y)
					{
						isTeleportingNextFrame = (Mathf.Abs(spaceRelativePosition.y - fullPosition.y) >= 64f);
					}
					if (this.SyncPositionZ && this.SyncPositionZ != axisToSynchronize.z)
					{
						isTeleportingNextFrame = (Mathf.Abs(spaceRelativePosition.z - fullPosition.z) >= 64f);
					}
					this.m_LocalAuthoritativeNetworkState.IsTeleportingNextFrame = isTeleportingNextFrame;
				}
			}
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000827C File Offset: 0x0000647C
		internal void OnUpdateAuthoritativeState(ref Transform transformSource)
		{
			if (!this.m_LocalAuthoritativeNetworkState.ExplicitSet && this.m_LocalAuthoritativeNetworkState.IsDirty && !this.m_LocalAuthoritativeNetworkState.IsTeleportingNextFrame)
			{
				this.m_LocalAuthoritativeNetworkState.ClearBitSetForNextTick();
				if (NetworkTransform.TrackByStateId)
				{
					this.m_LocalAuthoritativeNetworkState.TrackByStateId = true;
					this.m_LocalAuthoritativeNetworkState.StateId = this.m_LocalAuthoritativeNetworkState.StateId + 1;
				}
				else
				{
					this.m_LocalAuthoritativeNetworkState.TrackByStateId = false;
				}
			}
			this.AxisChangedDeltaPositionCheck();
			this.TryCommitTransform(ref transformSource, false, false);
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x000082FC File Offset: 0x000064FC
		private void NetworkTickSystem_Tick()
		{
			if (this.CanCommitToTransform)
			{
				Transform transform = base.transform;
				this.OnUpdateAuthoritativeState(ref transform);
				this.m_CurrentPosition = this.GetSpaceRelativePosition(false);
				this.m_TargetPosition = this.GetSpaceRelativePosition(false);
				return;
			}
			if (base.NetworkManager != null && base.NetworkManager.NetworkTickSystem != null)
			{
				base.NetworkManager.NetworkTickSystem.Tick -= this.NetworkTickSystem_Tick;
			}
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00008374 File Offset: 0x00006574
		public override void OnNetworkSpawn()
		{
			this.m_CachedIsServer = base.IsServer;
			this.m_CachedNetworkManager = base.NetworkManager;
			this.Initialize();
			if (this.CanCommitToTransform && this.UseHalfFloatPrecision)
			{
				this.SetState(new Vector3?(this.GetSpaceRelativePosition(false)), new Quaternion?(this.GetSpaceRelativeRotation(false)), new Vector3?(this.GetScale(false)), false);
			}
		}

		// Token: 0x060000DA RID: 218 RVA: 0x000083DC File Offset: 0x000065DC
		public override void OnNetworkDespawn()
		{
			NetworkTransform.DeregisterForTickUpdate(this);
			this.CanCommitToTransform = false;
			if (base.NetworkManager != null && base.NetworkManager.NetworkTickSystem != null)
			{
				base.NetworkManager.NetworkTickSystem.Tick -= this.NetworkTickSystem_Tick;
			}
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00008430 File Offset: 0x00006630
		public override void OnDestroy()
		{
			if (base.NetworkManager != null && base.NetworkManager.NetworkTickSystem != null)
			{
				base.NetworkManager.NetworkTickSystem.Tick -= this.NetworkTickSystem_Tick;
			}
			this.CanCommitToTransform = false;
			base.OnDestroy();
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00008481 File Offset: 0x00006681
		public override void OnLostOwnership()
		{
			base.OnLostOwnership();
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00008489 File Offset: 0x00006689
		public override void OnGainedOwnership()
		{
			base.OnGainedOwnership();
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00008491 File Offset: 0x00006691
		protected override void OnOwnershipChanged(ulong previous, ulong current)
		{
			if (current == this.m_CachedNetworkManager.LocalClientId || previous == this.m_CachedNetworkManager.LocalClientId)
			{
				this.InternalInitialization(true);
			}
			base.OnOwnershipChanged(previous, current);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00003322 File Offset: 0x00001522
		protected virtual void OnInitialize(ref NetworkTransform.NetworkTransformState replicatedState)
		{
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00003322 File Offset: 0x00001522
		protected virtual void OnInitialize(ref NetworkVariable<NetworkTransform.NetworkTransformState> replicatedState)
		{
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x000084C0 File Offset: 0x000066C0
		private void InternalInitialization(bool isOwnershipChange = false)
		{
			if (!base.IsSpawned)
			{
				return;
			}
			this.CanCommitToTransform = (this.IsServerAuthoritative() ? base.IsServer : base.IsOwner);
			Vector3 spaceRelativePosition = this.GetSpaceRelativePosition(false);
			Quaternion spaceRelativeRotation = this.GetSpaceRelativeRotation(false);
			if (this.CanCommitToTransform)
			{
				if (this.UseHalfFloatPrecision)
				{
					this.m_HalfPositionState = new NetworkDeltaPosition(spaceRelativePosition, this.m_CachedNetworkManager.ServerTime.Tick, math.bool3(this.SyncPositionX, this.SyncPositionY, this.SyncPositionZ));
				}
				this.m_CurrentPosition = spaceRelativePosition;
				this.m_TargetPosition = spaceRelativePosition;
				NetworkTransform.RegisterForTickUpdate(this);
				this.m_LocalAuthoritativeNetworkState.SynchronizeBaseHalfFloat = false;
				if (this.UseHalfFloatPrecision && isOwnershipChange && !this.IsServerAuthoritative() && this.Interpolate)
				{
					this.m_HalfFloatTargetTickOwnership = this.m_CachedNetworkManager.ServerTime.Tick;
				}
			}
			else
			{
				NetworkTransform.DeregisterForTickUpdate(this);
				this.ResetInterpolatedStateToCurrentAuthoritativeState();
				this.m_LocalAuthoritativeNetworkState.SynchronizeBaseHalfFloat = false;
				this.m_CurrentPosition = spaceRelativePosition;
				this.m_TargetPosition = spaceRelativePosition;
				this.m_CurrentScale = base.transform.localScale;
				this.m_TargetScale = base.transform.localScale;
				this.m_CurrentRotation = spaceRelativeRotation;
				this.m_TargetRotation = spaceRelativeRotation.eulerAngles;
			}
			this.OnInitialize(ref this.m_LocalAuthoritativeNetworkState);
			if (base.IsOwner)
			{
				this.m_InternalStatNetVar.Value = this.m_LocalAuthoritativeNetworkState;
				this.OnInitialize(ref this.m_InternalStatNetVar);
			}
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00008630 File Offset: 0x00006830
		protected void Initialize()
		{
			this.InternalInitialization(false);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0000863C File Offset: 0x0000683C
		public override void OnNetworkObjectParentChanged(NetworkObject parentNetworkObject)
		{
			if (!this.CanCommitToTransform)
			{
				this.m_TargetPosition = (this.m_CurrentPosition = this.GetSpaceRelativePosition(false));
				this.m_CurrentRotation = this.GetSpaceRelativeRotation(false);
				this.m_TargetRotation = this.m_CurrentRotation.eulerAngles;
				this.m_TargetScale = (this.m_CurrentScale = this.GetScale(false));
				if (this.Interpolate)
				{
					this.m_ScaleInterpolator.Clear();
					this.m_PositionInterpolator.Clear();
					this.m_RotationInterpolator.Clear();
					double time = new NetworkTime(base.NetworkManager.NetworkConfig.TickRate, base.NetworkManager.ServerTime.Tick, 0.0).Time;
					this.UpdatePositionInterpolator(this.m_CurrentPosition, time, true);
					this.m_ScaleInterpolator.ResetTo(this.m_CurrentScale, time);
					this.m_RotationInterpolator.ResetTo(this.m_CurrentRotation, time);
				}
			}
			base.OnNetworkObjectParentChanged(parentNetworkObject);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00008740 File Offset: 0x00006940
		public void SetState(Vector3? posIn = null, Quaternion? rotIn = null, Vector3? scaleIn = null, bool teleportDisabled = true)
		{
			if (!base.IsSpawned)
			{
				NetworkLog.LogError("Cannot commit transform when not spawned!");
				return;
			}
			if (!base.IsServer && !base.IsOwner)
			{
				NetworkLog.LogError((base.gameObject != base.NetworkObject.gameObject) ? string.Concat(new string[]
				{
					"Non-authority instance of ",
					base.NetworkObject.gameObject.name,
					" is trying to commit a transform on ",
					base.gameObject.name,
					"!"
				}) : ("Non-authority instance of " + base.NetworkObject.gameObject.name + " is trying to commit a transform!"));
				return;
			}
			Vector3 pos = (posIn == null) ? this.GetSpaceRelativePosition(false) : posIn.Value;
			Quaternion rot = (rotIn == null) ? this.GetSpaceRelativeRotation(false) : rotIn.Value;
			Vector3 scale = (scaleIn == null) ? base.transform.localScale : scaleIn.Value;
			if (this.CanCommitToTransform)
			{
				this.SetStateInternal(pos, rot, scale, !teleportDisabled);
				return;
			}
			if (base.IsServer)
			{
				this.m_ClientIds[0] = base.OwnerClientId;
				this.m_ClientRpcParams.Send.TargetClientIds = this.m_ClientIds;
				this.SetStateClientRpc(pos, rot, scale, !teleportDisabled, this.m_ClientRpcParams);
				return;
			}
			this.SetStateServerRpc(pos, rot, scale, !teleportDisabled);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x000088B8 File Offset: 0x00006AB8
		private void SetStateInternal(Vector3 pos, Quaternion rot, Vector3 scale, bool shouldTeleport)
		{
			if (this.InLocalSpace)
			{
				base.transform.localPosition = pos;
				base.transform.localRotation = rot;
			}
			else
			{
				base.transform.SetPositionAndRotation(pos, rot);
			}
			base.transform.localScale = scale;
			this.m_LocalAuthoritativeNetworkState.IsTeleportingNextFrame = shouldTeleport;
			Transform transform = base.transform;
			bool isDirty = this.m_LocalAuthoritativeNetworkState.IsDirty;
			bool explicitSet = this.m_LocalAuthoritativeNetworkState.ExplicitSet;
			bool flag = this.ApplyTransformToNetworkStateWithInfo(ref this.m_LocalAuthoritativeNetworkState, ref transform, false, 0UL);
			this.m_LocalAuthoritativeNetworkState.ExplicitSet = ((isDirty && explicitSet) || flag);
			this.m_LocalAuthoritativeNetworkState.IsDirty = this.m_LocalAuthoritativeNetworkState.ExplicitSet;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00008964 File Offset: 0x00006B64
		[ClientRpc]
		private void SetStateClientRpc(Vector3 pos, Quaternion rot, Vector3 scale, bool shouldTeleport, ClientRpcParams clientRpcParams = default(ClientRpcParams))
		{
			NetworkManager networkManager = base.NetworkManager;
			if (networkManager == null || !networkManager.IsListening)
			{
				return;
			}
			if (this.__rpc_exec_stage != NetworkBehaviour.__RpcExecStage.Execute && (networkManager.IsServer || networkManager.IsHost))
			{
				FastBufferWriter fastBufferWriter = base.__beginSendClientRpc(1724438000U, clientRpcParams, RpcDelivery.Reliable);
				fastBufferWriter.WriteValueSafe(pos);
				fastBufferWriter.WriteValueSafe(rot);
				fastBufferWriter.WriteValueSafe(scale);
				fastBufferWriter.WriteValueSafe<bool>(shouldTeleport, default(FastBufferWriter.ForPrimitives));
				base.__endSendClientRpc(ref fastBufferWriter, 1724438000U, clientRpcParams, RpcDelivery.Reliable);
			}
			if (this.__rpc_exec_stage != NetworkBehaviour.__RpcExecStage.Execute || (!networkManager.IsClient && !networkManager.IsHost))
			{
				return;
			}
			this.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
			this.SetStateInternal(pos, rot, scale, shouldTeleport);
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00008A84 File Offset: 0x00006C84
		[ServerRpc]
		private void SetStateServerRpc(Vector3 pos, Quaternion rot, Vector3 scale, bool shouldTeleport)
		{
			NetworkManager networkManager = base.NetworkManager;
			if (networkManager == null || !networkManager.IsListening)
			{
				return;
			}
			if (this.__rpc_exec_stage != NetworkBehaviour.__RpcExecStage.Execute && (networkManager.IsClient || networkManager.IsHost))
			{
				if (base.OwnerClientId != networkManager.LocalClientId)
				{
					if (networkManager.LogLevel <= LogLevel.Normal)
					{
						Debug.LogError("Only the owner can invoke a ServerRpc that requires ownership!");
					}
					return;
				}
				ServerRpcParams serverRpcParams;
				FastBufferWriter fastBufferWriter = base.__beginSendServerRpc(640767722U, serverRpcParams, RpcDelivery.Reliable);
				fastBufferWriter.WriteValueSafe(pos);
				fastBufferWriter.WriteValueSafe(rot);
				fastBufferWriter.WriteValueSafe(scale);
				fastBufferWriter.WriteValueSafe<bool>(shouldTeleport, default(FastBufferWriter.ForPrimitives));
				base.__endSendServerRpc(ref fastBufferWriter, 640767722U, serverRpcParams, RpcDelivery.Reliable);
			}
			if (this.__rpc_exec_stage != NetworkBehaviour.__RpcExecStage.Execute || (!networkManager.IsServer && !networkManager.IsHost))
			{
				return;
			}
			this.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
			if (this.OnClientRequestChange != null)
			{
				ValueTuple<Vector3, Quaternion, Vector3> valueTuple = this.OnClientRequestChange(pos, rot, scale);
				pos = valueTuple.Item1;
				rot = valueTuple.Item2;
				scale = valueTuple.Item3;
			}
			this.SetStateInternal(pos, rot, scale, shouldTeleport);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00008C18 File Offset: 0x00006E18
		private void UpdateInterpolation()
		{
			if (this.Interpolate)
			{
				NetworkTime serverTime = this.m_CachedNetworkManager.ServerTime;
				float deltaTime = this.m_CachedNetworkManager.RealTimeProvider.DeltaTime;
				double time = serverTime.Time;
				int ticks = (!this.IsServerAuthoritative() && !base.IsServer) ? 2 : 1;
				double time2 = serverTime.TimeTicksAgo(ticks).Time;
				if (this.SynchronizePosition)
				{
					this.m_PositionInterpolator.Update(deltaTime, time2, time);
				}
				if (this.SynchronizeRotation)
				{
					this.m_RotationInterpolator.IsSlerp = !this.UseHalfFloatPrecision;
					this.m_RotationInterpolator.Update(deltaTime, time2, time);
				}
				if (this.SynchronizeScale)
				{
					this.m_ScaleInterpolator.Update(deltaTime, time2, time);
				}
			}
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00008CD9 File Offset: 0x00006ED9
		protected virtual void Update()
		{
			if (!base.IsSpawned || this.CanCommitToTransform)
			{
				return;
			}
			this.UpdateInterpolation();
			this.ApplyAuthoritativeState();
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00008CF8 File Offset: 0x00006EF8
		public void Teleport(Vector3 newPosition, Quaternion newRotation, Vector3 newScale)
		{
			if (!this.CanCommitToTransform)
			{
				throw new Exception("Teleporting on non-authoritative side is not allowed!");
			}
			this.SetStateInternal(newPosition, newRotation, newScale, true);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00003AAD File Offset: 0x00001CAD
		protected virtual bool OnIsServerAuthoritative()
		{
			return true;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00008D17 File Offset: 0x00006F17
		public bool IsServerAuthoritative()
		{
			return this.OnIsServerAuthoritative();
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00008D1F File Offset: 0x00006F1F
		internal void TransformStateUpdate(ref NetworkTransform.NetworkTransformState networkTransformState)
		{
			this.m_OldState = this.m_LocalAuthoritativeNetworkState;
			this.m_LocalAuthoritativeNetworkState = networkTransformState;
			this.OnNetworkStateChanged(this.m_OldState, this.m_LocalAuthoritativeNetworkState);
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00008D4C File Offset: 0x00006F4C
		private void UpdateTransformState()
		{
			if (this.m_CachedNetworkManager.ShutdownInProgress)
			{
				return;
			}
			bool flag = this.OnIsServerAuthoritative();
			if (flag && !base.IsServer)
			{
				Debug.LogError("Server authoritative NetworkTransform can only be updated by the server!");
			}
			else if (!flag && !base.IsServer && !base.IsOwner)
			{
				Debug.LogError("Owner authoritative NetworkTransform can only be updated by the owner!");
			}
			CustomMessagingManager customMessagingManager = this.m_CachedNetworkManager.CustomMessagingManager;
			NetworkTransformMessage networkTransformMessage = new NetworkTransformMessage
			{
				NetworkObjectId = base.NetworkObjectId,
				NetworkBehaviourId = (int)base.NetworkBehaviourId,
				State = this.m_LocalAuthoritativeNetworkState
			};
			NetworkDelivery delivery = (!this.UseUnreliableDeltas | this.m_LocalAuthoritativeNetworkState.IsTeleportingNextFrame | this.m_LocalAuthoritativeNetworkState.IsSynchronizing | this.m_LocalAuthoritativeNetworkState.UnreliableFrameSync | this.m_LocalAuthoritativeNetworkState.SynchronizeBaseHalfFloat) ? NetworkDelivery.ReliableSequenced : NetworkDelivery.UnreliableSequenced;
			if (base.IsServer)
			{
				int count = this.m_CachedNetworkManager.ConnectionManager.ConnectedClientsList.Count;
				for (int i = 0; i < count; i++)
				{
					ulong clientId = this.m_CachedNetworkManager.ConnectionManager.ConnectedClientsList[i].ClientId;
					if (clientId != 0UL && base.NetworkObject.Observers.Contains(clientId))
					{
						base.NetworkManager.MessageManager.SendMessage<NetworkTransformMessage>(ref networkTransformMessage, delivery, clientId);
					}
				}
				return;
			}
			base.NetworkManager.MessageManager.SendMessage<NetworkTransformMessage>(ref networkTransformMessage, delivery, 0UL);
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00008EB2 File Offset: 0x000070B2
		private static void RemoveTickUpdate(NetworkManager networkManager)
		{
			NetworkTransform.s_NetworkTickRegistration.Remove(networkManager);
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00008EC0 File Offset: 0x000070C0
		internal void RegisterForTickSynchronization()
		{
			NetworkTransform.s_TickSynchPosition++;
			this.m_NextTickSync = base.NetworkManager.ServerTime.Tick + NetworkTransform.s_TickSynchPosition % (int)base.NetworkManager.NetworkConfig.TickRate;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00008F0C File Offset: 0x0000710C
		private static void RegisterForTickUpdate(NetworkTransform networkTransform)
		{
			if (!NetworkTransform.s_NetworkTickRegistration.ContainsKey(networkTransform.NetworkManager))
			{
				NetworkTransform.s_NetworkTickRegistration.Add(networkTransform.NetworkManager, new NetworkTransform.NetworkTransformTickRegistration(networkTransform.NetworkManager));
			}
			networkTransform.RegisterForTickSynchronization();
			NetworkTransform.s_NetworkTickRegistration[networkTransform.NetworkManager].NetworkTransforms.Add(networkTransform);
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00008F68 File Offset: 0x00007168
		private static void DeregisterForTickUpdate(NetworkTransform networkTransform)
		{
			if (NetworkTransform.s_NetworkTickRegistration.ContainsKey(networkTransform.NetworkManager))
			{
				NetworkTransform.s_NetworkTickRegistration[networkTransform.NetworkManager].NetworkTransforms.Remove(networkTransform);
				if (NetworkTransform.s_NetworkTickRegistration[networkTransform.NetworkManager].NetworkTransforms.Count == 0)
				{
					NetworkTransform.s_NetworkTickRegistration[networkTransform.NetworkManager].Remove();
				}
			}
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x000090B0 File Offset: 0x000072B0
		protected override void __initializeVariables()
		{
			bool flag = this.m_InternalStatNetVar == null;
			if (flag)
			{
				throw new Exception("NetworkTransform.m_InternalStatNetVar cannot be null. All NetworkVariableBase instances must be initialized.");
			}
			this.m_InternalStatNetVar.Initialize(this);
			base.__nameNetworkVariable(this.m_InternalStatNetVar, "m_InternalStatNetVar");
			this.NetworkVariableFields.Add(this.m_InternalStatNetVar);
			base.__initializeVariables();
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00009114 File Offset: 0x00007314
		protected override void __initializeRpcs()
		{
			base.__registerRpc(1724438000U, new NetworkBehaviour.RpcReceiveHandler(NetworkTransform.__rpc_handler_1724438000), "SetStateClientRpc");
			base.__registerRpc(640767722U, new NetworkBehaviour.RpcReceiveHandler(NetworkTransform.__rpc_handler_640767722), "SetStateServerRpc");
			base.__initializeRpcs();
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00009164 File Offset: 0x00007364
		private static void __rpc_handler_1724438000(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
			NetworkManager networkManager = target.NetworkManager;
			if (networkManager == null || !networkManager.IsListening)
			{
				return;
			}
			Vector3 pos;
			reader.ReadValueSafe(out pos);
			Quaternion rot;
			reader.ReadValueSafe(out rot);
			Vector3 scale;
			reader.ReadValueSafe(out scale);
			bool shouldTeleport;
			reader.ReadValueSafe<bool>(out shouldTeleport, default(FastBufferWriter.ForPrimitives));
			ClientRpcParams client = rpcParams.Client;
			target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Execute;
			((NetworkTransform)target).SetStateClientRpc(pos, rot, scale, shouldTeleport, client);
			target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00009218 File Offset: 0x00007418
		private static void __rpc_handler_640767722(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
			NetworkManager networkManager = target.NetworkManager;
			if (networkManager == null || !networkManager.IsListening)
			{
				return;
			}
			if (rpcParams.Server.Receive.SenderClientId != target.OwnerClientId)
			{
				if (networkManager.LogLevel <= LogLevel.Normal)
				{
					Debug.LogError("Only the owner can invoke a ServerRpc that requires ownership!");
				}
				return;
			}
			Vector3 pos;
			reader.ReadValueSafe(out pos);
			Quaternion rot;
			reader.ReadValueSafe(out rot);
			Vector3 scale;
			reader.ReadValueSafe(out scale);
			bool shouldTeleport;
			reader.ReadValueSafe<bool>(out shouldTeleport, default(FastBufferWriter.ForPrimitives));
			target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Execute;
			((NetworkTransform)target).SetStateServerRpc(pos, rot, scale, shouldTeleport);
			target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00009308 File Offset: 0x00007508
		protected internal override string __getTypeName()
		{
			return "NetworkTransform";
		}

		// Token: 0x0400008D RID: 141
		public const float PositionThresholdDefault = 0.001f;

		// Token: 0x0400008E RID: 142
		public const float RotAngleThresholdDefault = 0.01f;

		// Token: 0x0400008F RID: 143
		public const float ScaleThresholdDefault = 0.01f;

		// Token: 0x04000090 RID: 144
		public NetworkTransform.OnClientRequestChangeDelegate OnClientRequestChange;

		// Token: 0x04000091 RID: 145
		internal static bool TrackByStateId;

		// Token: 0x04000092 RID: 146
		[Tooltip("When set, NetworkTransform will send common state updates using unreliable network delivery to provide a higher tolerance to poor network conditions (especially packet loss). When disabled, all state updates are sent using reliable fragmented sequenced network delivery.")]
		public bool UseUnreliableDeltas;

		// Token: 0x04000093 RID: 147
		public bool SyncPositionX = true;

		// Token: 0x04000094 RID: 148
		public bool SyncPositionY = true;

		// Token: 0x04000095 RID: 149
		public bool SyncPositionZ = true;

		// Token: 0x04000096 RID: 150
		public bool SyncRotAngleX = true;

		// Token: 0x04000097 RID: 151
		public bool SyncRotAngleY = true;

		// Token: 0x04000098 RID: 152
		public bool SyncRotAngleZ = true;

		// Token: 0x04000099 RID: 153
		public bool SyncScaleX = true;

		// Token: 0x0400009A RID: 154
		public bool SyncScaleY = true;

		// Token: 0x0400009B RID: 155
		public bool SyncScaleZ = true;

		// Token: 0x0400009C RID: 156
		public float PositionThreshold = 0.001f;

		// Token: 0x0400009D RID: 157
		[Range(1E-05f, 360f)]
		public float RotAngleThreshold = 0.01f;

		// Token: 0x0400009E RID: 158
		public float ScaleThreshold = 0.01f;

		// Token: 0x0400009F RID: 159
		[Tooltip("When enabled, this will synchronize the full Quaternion (i.e. all Euler rotation axis are updated if one axis has a delta)")]
		public bool UseQuaternionSynchronization;

		// Token: 0x040000A0 RID: 160
		[Tooltip("When enabled, this uses a smallest three implementation that reduces full Quaternion updates down to the size of an unsigned integer (ignores half float precision settings).")]
		public bool UseQuaternionCompression;

		// Token: 0x040000A1 RID: 161
		[Tooltip("When enabled, this will use half float precision values for position (uses delta position updating), rotation (except when Quaternion compression is enabled), and scale.")]
		public bool UseHalfFloatPrecision;

		// Token: 0x040000A2 RID: 162
		[Tooltip("Sets whether this transform should sync in local space or in world space")]
		public bool InLocalSpace;

		// Token: 0x040000A3 RID: 163
		public bool Interpolate = true;

		// Token: 0x040000A4 RID: 164
		[Tooltip("When enabled the position interpolator will Slerp towards its current target position.")]
		public bool SlerpPosition;

		// Token: 0x040000A6 RID: 166
		protected bool m_CachedIsServer;

		// Token: 0x040000A7 RID: 167
		protected NetworkManager m_CachedNetworkManager;

		// Token: 0x040000A8 RID: 168
		private NetworkTransform.NetworkTransformState m_LocalAuthoritativeNetworkState;

		// Token: 0x040000A9 RID: 169
		private ClientRpcParams m_ClientRpcParams = new ClientRpcParams
		{
			Send = default(ClientRpcSendParams)
		};

		// Token: 0x040000AA RID: 170
		private List<ulong> m_ClientIds = new List<ulong>
		{
			0UL
		};

		// Token: 0x040000AB RID: 171
		private BufferedLinearInterpolatorVector3 m_PositionInterpolator;

		// Token: 0x040000AC RID: 172
		private BufferedLinearInterpolatorVector3 m_ScaleInterpolator;

		// Token: 0x040000AD RID: 173
		private BufferedLinearInterpolatorQuaternion m_RotationInterpolator;

		// Token: 0x040000AE RID: 174
		private Vector3 m_CurrentPosition;

		// Token: 0x040000AF RID: 175
		private Vector3 m_TargetPosition;

		// Token: 0x040000B0 RID: 176
		private Vector3 m_CurrentScale;

		// Token: 0x040000B1 RID: 177
		private Vector3 m_TargetScale;

		// Token: 0x040000B2 RID: 178
		private Quaternion m_CurrentRotation;

		// Token: 0x040000B3 RID: 179
		private Vector3 m_TargetRotation;

		// Token: 0x040000B4 RID: 180
		private NetworkDeltaPosition m_HalfPositionState = new NetworkDeltaPosition(Vector3.zero, 0);

		// Token: 0x040000B5 RID: 181
		internal NetworkTransform.NetworkTransformState SynchronizeState;

		// Token: 0x040000B6 RID: 182
		private bool m_DeltaSynch;

		// Token: 0x040000B7 RID: 183
		private NetworkTransform.NetworkTransformState m_OldState;

		// Token: 0x040000B8 RID: 184
		private NetworkVariable<NetworkTransform.NetworkTransformState> m_InternalStatNetVar = new NetworkVariable<NetworkTransform.NetworkTransformState>(default(NetworkTransform.NetworkTransformState), NetworkVariableReadPermission.Owner, NetworkVariableWritePermission.Owner);

		// Token: 0x040000B9 RID: 185
		private int m_HalfFloatTargetTickOwnership;

		// Token: 0x040000BA RID: 186
		private static Dictionary<NetworkManager, NetworkTransform.NetworkTransformTickRegistration> s_NetworkTickRegistration = new Dictionary<NetworkManager, NetworkTransform.NetworkTransformTickRegistration>();

		// Token: 0x040000BB RID: 187
		private static int s_TickSynchPosition;

		// Token: 0x040000BC RID: 188
		private int m_NextTickSync;

		// Token: 0x02000021 RID: 33
		// (Invoke) Token: 0x060000FB RID: 251
		[return: TupleElementNames(new string[]
		{
			"pos",
			"rotOut",
			"scale"
		})]
		public delegate ValueTuple<Vector3, Quaternion, Vector3> OnClientRequestChangeDelegate(Vector3 pos, Quaternion rot, Vector3 scale);

		// Token: 0x02000022 RID: 34
		public struct NetworkTransformState : INetworkSerializable
		{
			// Token: 0x17000015 RID: 21
			// (get) Token: 0x060000FE RID: 254 RVA: 0x0000930F File Offset: 0x0000750F
			// (set) Token: 0x060000FF RID: 255 RVA: 0x00009317 File Offset: 0x00007517
			internal uint BitSet
			{
				get
				{
					return this.m_Bitset;
				}
				set
				{
					this.m_Bitset = value;
				}
			}

			// Token: 0x17000016 RID: 22
			// (get) Token: 0x06000100 RID: 256 RVA: 0x00009320 File Offset: 0x00007520
			// (set) Token: 0x06000101 RID: 257 RVA: 0x00009328 File Offset: 0x00007528
			internal bool IsDirty { readonly get; set; }

			// Token: 0x17000017 RID: 23
			// (get) Token: 0x06000102 RID: 258 RVA: 0x00009331 File Offset: 0x00007531
			// (set) Token: 0x06000103 RID: 259 RVA: 0x00009339 File Offset: 0x00007539
			public int LastSerializedSize { readonly get; internal set; }

			// Token: 0x17000018 RID: 24
			// (get) Token: 0x06000104 RID: 260 RVA: 0x00009342 File Offset: 0x00007542
			// (set) Token: 0x06000105 RID: 261 RVA: 0x0000934B File Offset: 0x0000754B
			public bool InLocalSpace
			{
				get
				{
					return this.GetFlag(1);
				}
				internal set
				{
					this.SetFlag(value, 1);
				}
			}

			// Token: 0x17000019 RID: 25
			// (get) Token: 0x06000106 RID: 262 RVA: 0x00009355 File Offset: 0x00007555
			// (set) Token: 0x06000107 RID: 263 RVA: 0x0000935E File Offset: 0x0000755E
			public bool HasPositionX
			{
				get
				{
					return this.GetFlag(2);
				}
				internal set
				{
					this.SetFlag(value, 2);
				}
			}

			// Token: 0x1700001A RID: 26
			// (get) Token: 0x06000108 RID: 264 RVA: 0x00009368 File Offset: 0x00007568
			// (set) Token: 0x06000109 RID: 265 RVA: 0x00009371 File Offset: 0x00007571
			public bool HasPositionY
			{
				get
				{
					return this.GetFlag(4);
				}
				internal set
				{
					this.SetFlag(value, 4);
				}
			}

			// Token: 0x1700001B RID: 27
			// (get) Token: 0x0600010A RID: 266 RVA: 0x0000937B File Offset: 0x0000757B
			// (set) Token: 0x0600010B RID: 267 RVA: 0x00009384 File Offset: 0x00007584
			public bool HasPositionZ
			{
				get
				{
					return this.GetFlag(8);
				}
				internal set
				{
					this.SetFlag(value, 8);
				}
			}

			// Token: 0x1700001C RID: 28
			// (get) Token: 0x0600010C RID: 268 RVA: 0x0000938E File Offset: 0x0000758E
			public bool HasPositionChange
			{
				get
				{
					return this.HasPositionX | this.HasPositionY | this.HasPositionZ;
				}
			}

			// Token: 0x1700001D RID: 29
			// (get) Token: 0x0600010D RID: 269 RVA: 0x000093A4 File Offset: 0x000075A4
			// (set) Token: 0x0600010E RID: 270 RVA: 0x000093AE File Offset: 0x000075AE
			public bool HasRotAngleX
			{
				get
				{
					return this.GetFlag(16);
				}
				internal set
				{
					this.SetFlag(value, 16);
				}
			}

			// Token: 0x1700001E RID: 30
			// (get) Token: 0x0600010F RID: 271 RVA: 0x000093B9 File Offset: 0x000075B9
			// (set) Token: 0x06000110 RID: 272 RVA: 0x000093C3 File Offset: 0x000075C3
			public bool HasRotAngleY
			{
				get
				{
					return this.GetFlag(32);
				}
				internal set
				{
					this.SetFlag(value, 32);
				}
			}

			// Token: 0x1700001F RID: 31
			// (get) Token: 0x06000111 RID: 273 RVA: 0x000093CE File Offset: 0x000075CE
			// (set) Token: 0x06000112 RID: 274 RVA: 0x000093D8 File Offset: 0x000075D8
			public bool HasRotAngleZ
			{
				get
				{
					return this.GetFlag(64);
				}
				internal set
				{
					this.SetFlag(value, 64);
				}
			}

			// Token: 0x17000020 RID: 32
			// (get) Token: 0x06000113 RID: 275 RVA: 0x000093E3 File Offset: 0x000075E3
			public bool HasRotAngleChange
			{
				get
				{
					return this.HasRotAngleX | this.HasRotAngleY | this.HasRotAngleZ;
				}
			}

			// Token: 0x06000114 RID: 276 RVA: 0x000093F9 File Offset: 0x000075F9
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal bool HasScale(int axisIndex)
			{
				return this.GetFlag(128 << axisIndex);
			}

			// Token: 0x06000115 RID: 277 RVA: 0x0000940B File Offset: 0x0000760B
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void SetHasScale(int axisIndex, bool isSet)
			{
				this.SetFlag(isSet, 128 << axisIndex);
			}

			// Token: 0x17000021 RID: 33
			// (get) Token: 0x06000116 RID: 278 RVA: 0x0000941E File Offset: 0x0000761E
			// (set) Token: 0x06000117 RID: 279 RVA: 0x0000942B File Offset: 0x0000762B
			public bool HasScaleX
			{
				get
				{
					return this.GetFlag(128);
				}
				internal set
				{
					this.SetFlag(value, 128);
				}
			}

			// Token: 0x17000022 RID: 34
			// (get) Token: 0x06000118 RID: 280 RVA: 0x00009439 File Offset: 0x00007639
			// (set) Token: 0x06000119 RID: 281 RVA: 0x00009446 File Offset: 0x00007646
			public bool HasScaleY
			{
				get
				{
					return this.GetFlag(256);
				}
				internal set
				{
					this.SetFlag(value, 256);
				}
			}

			// Token: 0x17000023 RID: 35
			// (get) Token: 0x0600011A RID: 282 RVA: 0x00009454 File Offset: 0x00007654
			// (set) Token: 0x0600011B RID: 283 RVA: 0x00009461 File Offset: 0x00007661
			public bool HasScaleZ
			{
				get
				{
					return this.GetFlag(512);
				}
				internal set
				{
					this.SetFlag(value, 512);
				}
			}

			// Token: 0x17000024 RID: 36
			// (get) Token: 0x0600011C RID: 284 RVA: 0x0000946F File Offset: 0x0000766F
			public bool HasScaleChange
			{
				get
				{
					return this.HasScaleX | this.HasScaleY | this.HasScaleZ;
				}
			}

			// Token: 0x17000025 RID: 37
			// (get) Token: 0x0600011D RID: 285 RVA: 0x00009485 File Offset: 0x00007685
			// (set) Token: 0x0600011E RID: 286 RVA: 0x00009492 File Offset: 0x00007692
			public bool IsTeleportingNextFrame
			{
				get
				{
					return this.GetFlag(1024);
				}
				internal set
				{
					this.SetFlag(value, 1024);
				}
			}

			// Token: 0x17000026 RID: 38
			// (get) Token: 0x0600011F RID: 287 RVA: 0x000094A0 File Offset: 0x000076A0
			// (set) Token: 0x06000120 RID: 288 RVA: 0x000094AD File Offset: 0x000076AD
			public bool UseInterpolation
			{
				get
				{
					return this.GetFlag(2048);
				}
				internal set
				{
					this.SetFlag(value, 2048);
				}
			}

			// Token: 0x17000027 RID: 39
			// (get) Token: 0x06000121 RID: 289 RVA: 0x000094BB File Offset: 0x000076BB
			// (set) Token: 0x06000122 RID: 290 RVA: 0x000094C8 File Offset: 0x000076C8
			public bool QuaternionSync
			{
				get
				{
					return this.GetFlag(4096);
				}
				internal set
				{
					this.SetFlag(value, 4096);
				}
			}

			// Token: 0x17000028 RID: 40
			// (get) Token: 0x06000123 RID: 291 RVA: 0x000094D6 File Offset: 0x000076D6
			// (set) Token: 0x06000124 RID: 292 RVA: 0x000094E3 File Offset: 0x000076E3
			public bool QuaternionCompression
			{
				get
				{
					return this.GetFlag(8192);
				}
				internal set
				{
					this.SetFlag(value, 8192);
				}
			}

			// Token: 0x17000029 RID: 41
			// (get) Token: 0x06000125 RID: 293 RVA: 0x000094F1 File Offset: 0x000076F1
			// (set) Token: 0x06000126 RID: 294 RVA: 0x000094FE File Offset: 0x000076FE
			public bool UseHalfFloatPrecision
			{
				get
				{
					return this.GetFlag(16384);
				}
				internal set
				{
					this.SetFlag(value, 16384);
				}
			}

			// Token: 0x1700002A RID: 42
			// (get) Token: 0x06000127 RID: 295 RVA: 0x0000950C File Offset: 0x0000770C
			// (set) Token: 0x06000128 RID: 296 RVA: 0x00009519 File Offset: 0x00007719
			public bool IsSynchronizing
			{
				get
				{
					return this.GetFlag(32768);
				}
				internal set
				{
					this.SetFlag(value, 32768);
				}
			}

			// Token: 0x1700002B RID: 43
			// (get) Token: 0x06000129 RID: 297 RVA: 0x00009527 File Offset: 0x00007727
			// (set) Token: 0x0600012A RID: 298 RVA: 0x00009534 File Offset: 0x00007734
			public bool UsePositionSlerp
			{
				get
				{
					return this.GetFlag(65536);
				}
				internal set
				{
					this.SetFlag(value, 65536);
				}
			}

			// Token: 0x0600012B RID: 299 RVA: 0x00009542 File Offset: 0x00007742
			public bool IsUnreliableFrameSync()
			{
				return this.UnreliableFrameSync;
			}

			// Token: 0x0600012C RID: 300 RVA: 0x0000954A File Offset: 0x0000774A
			public bool IsReliableStateUpdate()
			{
				return this.ReliableSequenced;
			}

			// Token: 0x1700002C RID: 44
			// (get) Token: 0x0600012D RID: 301 RVA: 0x00009552 File Offset: 0x00007752
			// (set) Token: 0x0600012E RID: 302 RVA: 0x0000955F File Offset: 0x0000775F
			internal bool IsParented
			{
				get
				{
					return this.GetFlag(131072);
				}
				set
				{
					this.SetFlag(value, 131072);
				}
			}

			// Token: 0x1700002D RID: 45
			// (get) Token: 0x0600012F RID: 303 RVA: 0x0000956D File Offset: 0x0000776D
			// (set) Token: 0x06000130 RID: 304 RVA: 0x0000957A File Offset: 0x0000777A
			internal bool SynchronizeBaseHalfFloat
			{
				get
				{
					return this.GetFlag(262144);
				}
				set
				{
					this.SetFlag(value, 262144);
				}
			}

			// Token: 0x1700002E RID: 46
			// (get) Token: 0x06000131 RID: 305 RVA: 0x00009588 File Offset: 0x00007788
			// (set) Token: 0x06000132 RID: 306 RVA: 0x00009595 File Offset: 0x00007795
			internal bool ReliableSequenced
			{
				get
				{
					return this.GetFlag(524288);
				}
				set
				{
					this.SetFlag(value, 524288);
				}
			}

			// Token: 0x1700002F RID: 47
			// (get) Token: 0x06000133 RID: 307 RVA: 0x000095A3 File Offset: 0x000077A3
			// (set) Token: 0x06000134 RID: 308 RVA: 0x000095B0 File Offset: 0x000077B0
			internal bool UseUnreliableDeltas
			{
				get
				{
					return this.GetFlag(1048576);
				}
				set
				{
					this.SetFlag(value, 1048576);
				}
			}

			// Token: 0x17000030 RID: 48
			// (get) Token: 0x06000135 RID: 309 RVA: 0x000095BE File Offset: 0x000077BE
			// (set) Token: 0x06000136 RID: 310 RVA: 0x000095CB File Offset: 0x000077CB
			internal bool UnreliableFrameSync
			{
				get
				{
					return this.GetFlag(2097152);
				}
				set
				{
					this.SetFlag(value, 2097152);
				}
			}

			// Token: 0x17000031 RID: 49
			// (get) Token: 0x06000137 RID: 311 RVA: 0x000095D9 File Offset: 0x000077D9
			// (set) Token: 0x06000138 RID: 312 RVA: 0x000095E6 File Offset: 0x000077E6
			internal bool TrackByStateId
			{
				get
				{
					return this.GetFlag(268435456);
				}
				set
				{
					this.SetFlag(value, 268435456);
				}
			}

			// Token: 0x06000139 RID: 313 RVA: 0x000095F4 File Offset: 0x000077F4
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private bool GetFlag(int flag)
			{
				return ((ulong)this.m_Bitset & (ulong)((long)flag)) > 0UL;
			}

			// Token: 0x0600013A RID: 314 RVA: 0x00009604 File Offset: 0x00007804
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void SetFlag(bool set, int flag)
			{
				if (set)
				{
					this.m_Bitset |= (uint)flag;
					return;
				}
				this.m_Bitset &= (uint)(~(uint)flag);
			}

			// Token: 0x0600013B RID: 315 RVA: 0x00009627 File Offset: 0x00007827
			internal void ClearBitSetForNextTick()
			{
				this.m_Bitset &= 1144833U;
				this.IsDirty = false;
			}

			// Token: 0x0600013C RID: 316 RVA: 0x00009642 File Offset: 0x00007842
			public Quaternion GetRotation()
			{
				if (!this.HasRotAngleChange)
				{
					return Quaternion.identity;
				}
				if (this.QuaternionSync)
				{
					return this.Rotation;
				}
				return Quaternion.Euler(this.RotAngleX, this.RotAngleY, this.RotAngleZ);
			}

			// Token: 0x0600013D RID: 317 RVA: 0x00009678 File Offset: 0x00007878
			public Vector3 GetPosition()
			{
				if (!this.HasPositionChange)
				{
					return Vector3.zero;
				}
				if (!this.UseHalfFloatPrecision)
				{
					return new Vector3(this.PositionX, this.PositionY, this.PositionZ);
				}
				if (this.IsTeleportingNextFrame)
				{
					return this.CurrentPosition;
				}
				return this.NetworkDeltaPosition.GetFullPosition();
			}

			// Token: 0x0600013E RID: 318 RVA: 0x000096D0 File Offset: 0x000078D0
			public Vector3 GetScale()
			{
				if (!this.HasScaleChange)
				{
					return Vector3.zero;
				}
				if (!this.UseHalfFloatPrecision)
				{
					return new Vector3(this.ScaleX, this.ScaleY, this.ScaleZ);
				}
				if (this.IsTeleportingNextFrame)
				{
					return this.Scale;
				}
				return this.HalfVectorScale.ToVector3();
			}

			// Token: 0x0600013F RID: 319 RVA: 0x00009725 File Offset: 0x00007925
			public int GetNetworkTick()
			{
				return this.NetworkTick;
			}

			// Token: 0x06000140 RID: 320 RVA: 0x00009730 File Offset: 0x00007930
			public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
			{
				bool isWriter = serializer.IsWriter;
				int position;
				if (isWriter)
				{
					this.m_Writer = serializer.GetFastBufferWriter();
					position = this.m_Writer.Position;
				}
				else
				{
					this.m_Reader = serializer.GetFastBufferReader();
					position = this.m_Reader.Position;
				}
				if (isWriter)
				{
					if (this.UseUnreliableDeltas)
					{
						if (this.IsTeleportingNextFrame || this.IsSynchronizing || this.UnreliableFrameSync || (this.UseHalfFloatPrecision && this.NetworkDeltaPosition.CollapsedDeltaIntoBase))
						{
							this.ReliableSequenced = true;
						}
						else
						{
							this.ReliableSequenced = false;
						}
					}
					else
					{
						this.ReliableSequenced = true;
					}
					BytePacker.WriteValueBitPacked(this.m_Writer, this.m_Bitset);
					BytePacker.WriteValueBitPacked(this.m_Writer, this.NetworkTick);
				}
				else
				{
					ByteUnpacker.ReadValueBitPacked(this.m_Reader, out this.m_Bitset);
					ByteUnpacker.ReadValueBitPacked(this.m_Reader, out this.NetworkTick);
				}
				if (this.TrackByStateId)
				{
					serializer.SerializeValue<int>(ref this.StateId, default(FastBufferWriter.ForPrimitives));
				}
				if (this.HasPositionChange)
				{
					if (this.UseHalfFloatPrecision)
					{
						this.NetworkDeltaPosition.SynchronizeBase = this.SynchronizeBaseHalfFloat;
						this.NetworkDeltaPosition.HalfVector3.AxisToSynchronize[0] = this.HasPositionX;
						this.NetworkDeltaPosition.HalfVector3.AxisToSynchronize[1] = this.HasPositionY;
						this.NetworkDeltaPosition.HalfVector3.AxisToSynchronize[2] = this.HasPositionZ;
						if (this.IsTeleportingNextFrame)
						{
							serializer.SerializeValue(ref this.CurrentPosition);
							if (this.IsSynchronizing)
							{
								serializer.SerializeValue(ref this.DeltaPosition);
								if (!isWriter)
								{
									this.NetworkDeltaPosition.NetworkTick = this.NetworkTick;
									this.NetworkDeltaPosition.NetworkSerialize<T>(serializer);
								}
								else
								{
									serializer.SerializeNetworkSerializable<NetworkDeltaPosition>(ref this.NetworkDeltaPosition);
								}
							}
						}
						else if (!isWriter)
						{
							this.NetworkDeltaPosition.NetworkTick = this.NetworkTick;
							this.NetworkDeltaPosition.NetworkSerialize<T>(serializer);
						}
						else
						{
							serializer.SerializeNetworkSerializable<NetworkDeltaPosition>(ref this.NetworkDeltaPosition);
						}
					}
					else
					{
						if (this.HasPositionX)
						{
							serializer.SerializeValue<float>(ref this.PositionX, default(FastBufferWriter.ForPrimitives));
						}
						if (this.HasPositionY)
						{
							serializer.SerializeValue<float>(ref this.PositionY, default(FastBufferWriter.ForPrimitives));
						}
						if (this.HasPositionZ)
						{
							serializer.SerializeValue<float>(ref this.PositionZ, default(FastBufferWriter.ForPrimitives));
						}
					}
				}
				if (this.HasRotAngleChange)
				{
					if (this.QuaternionSync)
					{
						if (this.IsTeleportingNextFrame)
						{
							serializer.SerializeValue(ref this.Rotation);
						}
						else if (this.QuaternionCompression)
						{
							if (isWriter)
							{
								this.QuaternionCompressed = QuaternionCompressor.CompressQuaternion(ref this.Rotation);
							}
							serializer.SerializeValue<uint>(ref this.QuaternionCompressed, default(FastBufferWriter.ForPrimitives));
							if (!isWriter)
							{
								QuaternionCompressor.DecompressQuaternion(ref this.Rotation, this.QuaternionCompressed);
							}
						}
						else if (this.UseHalfFloatPrecision)
						{
							if (isWriter)
							{
								this.HalfVectorRotation.UpdateFrom(ref this.Rotation);
							}
							serializer.SerializeNetworkSerializable<HalfVector4>(ref this.HalfVectorRotation);
							if (!isWriter)
							{
								this.Rotation = this.HalfVectorRotation.ToQuaternion();
							}
						}
						else
						{
							serializer.SerializeValue(ref this.Rotation);
						}
					}
					else if (this.UseHalfFloatPrecision && !this.IsTeleportingNextFrame)
					{
						if (this.HasRotAngleChange)
						{
							this.HalfEulerRotation.AxisToSynchronize[0] = this.HasRotAngleX;
							this.HalfEulerRotation.AxisToSynchronize[1] = this.HasRotAngleY;
							this.HalfEulerRotation.AxisToSynchronize[2] = this.HasRotAngleZ;
							if (isWriter)
							{
								this.HalfEulerRotation.Set(this.RotAngleX, this.RotAngleY, this.RotAngleZ);
							}
							serializer.SerializeValue<HalfVector3>(ref this.HalfEulerRotation, default(FastBufferWriter.ForNetworkSerializable));
							if (!isWriter)
							{
								Vector3 vector = this.HalfEulerRotation.ToVector3();
								if (this.HasRotAngleX)
								{
									this.RotAngleX = vector.x;
								}
								if (this.HasRotAngleY)
								{
									this.RotAngleY = vector.y;
								}
								if (this.HasRotAngleZ)
								{
									this.RotAngleZ = vector.z;
								}
							}
						}
					}
					else
					{
						if (this.HasRotAngleX)
						{
							serializer.SerializeValue<float>(ref this.RotAngleX, default(FastBufferWriter.ForPrimitives));
						}
						if (this.HasRotAngleY)
						{
							serializer.SerializeValue<float>(ref this.RotAngleY, default(FastBufferWriter.ForPrimitives));
						}
						if (this.HasRotAngleZ)
						{
							serializer.SerializeValue<float>(ref this.RotAngleZ, default(FastBufferWriter.ForPrimitives));
						}
					}
				}
				if (this.HasScaleChange)
				{
					if (this.IsTeleportingNextFrame && this.IsParented)
					{
						serializer.SerializeValue(ref this.LossyScale);
					}
					if (this.UseHalfFloatPrecision)
					{
						if (this.IsTeleportingNextFrame)
						{
							serializer.SerializeValue(ref this.Scale);
						}
						else
						{
							this.HalfVectorScale.AxisToSynchronize[0] = this.HasScaleX;
							this.HalfVectorScale.AxisToSynchronize[1] = this.HasScaleY;
							this.HalfVectorScale.AxisToSynchronize[2] = this.HasScaleZ;
							if (isWriter)
							{
								this.HalfVectorScale.Set(this.Scale[0], this.Scale[1], this.Scale[2]);
							}
							serializer.SerializeValue<HalfVector3>(ref this.HalfVectorScale, default(FastBufferWriter.ForNetworkSerializable));
							if (!isWriter)
							{
								this.Scale = this.HalfVectorScale.ToVector3();
								if (this.HasScaleX)
								{
									this.ScaleX = this.Scale.x;
								}
								if (this.HasScaleY)
								{
									this.ScaleY = this.Scale.y;
								}
								if (this.HasScaleZ)
								{
									this.ScaleZ = this.Scale.x;
								}
							}
						}
					}
					else
					{
						if (this.HasScaleX)
						{
							serializer.SerializeValue<float>(ref this.ScaleX, default(FastBufferWriter.ForPrimitives));
						}
						if (this.HasScaleY)
						{
							serializer.SerializeValue<float>(ref this.ScaleY, default(FastBufferWriter.ForPrimitives));
						}
						if (this.HasScaleZ)
						{
							serializer.SerializeValue<float>(ref this.ScaleZ, default(FastBufferWriter.ForPrimitives));
						}
					}
				}
				if (!isWriter)
				{
					this.IsDirty = (this.HasPositionChange || this.HasRotAngleChange || this.HasScaleChange);
					this.LastSerializedSize = this.m_Reader.Position - position;
					return;
				}
				this.LastSerializedSize = this.m_Writer.Position - position;
			}

			// Token: 0x040000BD RID: 189
			private const int k_InLocalSpaceBit = 1;

			// Token: 0x040000BE RID: 190
			private const int k_PositionXBit = 2;

			// Token: 0x040000BF RID: 191
			private const int k_PositionYBit = 4;

			// Token: 0x040000C0 RID: 192
			private const int k_PositionZBit = 8;

			// Token: 0x040000C1 RID: 193
			private const int k_RotAngleXBit = 16;

			// Token: 0x040000C2 RID: 194
			private const int k_RotAngleYBit = 32;

			// Token: 0x040000C3 RID: 195
			private const int k_RotAngleZBit = 64;

			// Token: 0x040000C4 RID: 196
			private const int k_ScaleXBit = 128;

			// Token: 0x040000C5 RID: 197
			private const int k_ScaleYBit = 256;

			// Token: 0x040000C6 RID: 198
			private const int k_ScaleZBit = 512;

			// Token: 0x040000C7 RID: 199
			private const int k_TeleportingBit = 1024;

			// Token: 0x040000C8 RID: 200
			private const int k_Interpolate = 2048;

			// Token: 0x040000C9 RID: 201
			private const int k_QuaternionSync = 4096;

			// Token: 0x040000CA RID: 202
			private const int k_QuaternionCompress = 8192;

			// Token: 0x040000CB RID: 203
			private const int k_UseHalfFloats = 16384;

			// Token: 0x040000CC RID: 204
			private const int k_Synchronization = 32768;

			// Token: 0x040000CD RID: 205
			private const int k_PositionSlerp = 65536;

			// Token: 0x040000CE RID: 206
			private const int k_IsParented = 131072;

			// Token: 0x040000CF RID: 207
			private const int k_SynchBaseHalfFloat = 262144;

			// Token: 0x040000D0 RID: 208
			private const int k_ReliableSequenced = 524288;

			// Token: 0x040000D1 RID: 209
			private const int k_UseUnreliableDeltas = 1048576;

			// Token: 0x040000D2 RID: 210
			private const int k_UnreliableFrameSync = 2097152;

			// Token: 0x040000D3 RID: 211
			private const int k_TrackStateId = 268435456;

			// Token: 0x040000D4 RID: 212
			private uint m_Bitset;

			// Token: 0x040000D5 RID: 213
			internal double SentTime;

			// Token: 0x040000D6 RID: 214
			internal float PositionX;

			// Token: 0x040000D7 RID: 215
			internal float PositionY;

			// Token: 0x040000D8 RID: 216
			internal float PositionZ;

			// Token: 0x040000D9 RID: 217
			internal float RotAngleX;

			// Token: 0x040000DA RID: 218
			internal float RotAngleY;

			// Token: 0x040000DB RID: 219
			internal float RotAngleZ;

			// Token: 0x040000DC RID: 220
			internal Quaternion Rotation;

			// Token: 0x040000DD RID: 221
			internal float ScaleX;

			// Token: 0x040000DE RID: 222
			internal float ScaleY;

			// Token: 0x040000DF RID: 223
			internal float ScaleZ;

			// Token: 0x040000E0 RID: 224
			internal Vector3 CurrentPosition;

			// Token: 0x040000E1 RID: 225
			internal Vector3 DeltaPosition;

			// Token: 0x040000E2 RID: 226
			internal NetworkDeltaPosition NetworkDeltaPosition;

			// Token: 0x040000E3 RID: 227
			internal HalfVector3 HalfVectorScale;

			// Token: 0x040000E4 RID: 228
			internal Vector3 Scale;

			// Token: 0x040000E5 RID: 229
			internal Vector3 LossyScale;

			// Token: 0x040000E6 RID: 230
			internal HalfVector4 HalfVectorRotation;

			// Token: 0x040000E7 RID: 231
			internal uint QuaternionCompressed;

			// Token: 0x040000EA RID: 234
			internal int NetworkTick;

			// Token: 0x040000EB RID: 235
			internal int StateId;

			// Token: 0x040000EC RID: 236
			internal bool ExplicitSet;

			// Token: 0x040000ED RID: 237
			private FastBufferReader m_Reader;

			// Token: 0x040000EE RID: 238
			private FastBufferWriter m_Writer;

			// Token: 0x040000EF RID: 239
			internal HalfVector3 HalfEulerRotation;
		}

		// Token: 0x02000023 RID: 35
		private class NetworkTransformTickRegistration
		{
			// Token: 0x06000141 RID: 321 RVA: 0x00009D9D File Offset: 0x00007F9D
			private void OnNetworkManagerStopped(bool value)
			{
				this.Remove();
			}

			// Token: 0x06000142 RID: 322 RVA: 0x00009DA5 File Offset: 0x00007FA5
			public void Remove()
			{
				this.m_NetworkManager.NetworkTickSystem.Tick -= this.m_NetworkTickUpdate;
				this.m_NetworkTickUpdate = null;
				this.NetworkTransforms.Clear();
				NetworkTransform.RemoveTickUpdate(this.m_NetworkManager);
			}

			// Token: 0x06000143 RID: 323 RVA: 0x00009DDC File Offset: 0x00007FDC
			private void TickUpdate()
			{
				if (this.m_NetworkManager.ServerTime.Tick <= this.m_LastTick)
				{
					return;
				}
				foreach (NetworkTransform networkTransform in this.NetworkTransforms)
				{
					if (networkTransform.IsSpawned)
					{
						networkTransform.NetworkTickSystem_Tick();
					}
				}
				this.m_LastTick = this.m_NetworkManager.ServerTime.Tick;
			}

			// Token: 0x06000144 RID: 324 RVA: 0x00009E6C File Offset: 0x0000806C
			public NetworkTransformTickRegistration(NetworkManager networkManager)
			{
				this.m_NetworkManager = networkManager;
				this.m_NetworkTickUpdate = new Action(this.TickUpdate);
				networkManager.NetworkTickSystem.Tick += this.m_NetworkTickUpdate;
				if (networkManager.IsServer)
				{
					networkManager.OnServerStopped += this.OnNetworkManagerStopped;
					return;
				}
				networkManager.OnClientStopped += this.OnNetworkManagerStopped;
			}

			// Token: 0x040000F0 RID: 240
			private Action m_NetworkTickUpdate;

			// Token: 0x040000F1 RID: 241
			private NetworkManager m_NetworkManager;

			// Token: 0x040000F2 RID: 242
			public HashSet<NetworkTransform> NetworkTransforms = new HashSet<NetworkTransform>();

			// Token: 0x040000F3 RID: 243
			private int m_LastTick;
		}
	}
}
