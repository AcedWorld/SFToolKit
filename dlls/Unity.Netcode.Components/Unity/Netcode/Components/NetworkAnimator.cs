using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Unity.Netcode.Components
{
	// Token: 0x02000014 RID: 20
	[AddComponentMenu("Netcode/Network Animator")]
	public class NetworkAnimator : NetworkBehaviour, ISerializationCallbackReceiver
	{
		// Token: 0x06000060 RID: 96 RVA: 0x000039E0 File Offset: 0x00001BE0
		private void BuildDestinationToTransitionInfoTable()
		{
			foreach (NetworkAnimator.TransitionStateinfo transitionStateinfo in this.TransitionStateInfoList)
			{
				if (!this.m_DestinationStateToTransitioninfo.ContainsKey(transitionStateinfo.Layer))
				{
					this.m_DestinationStateToTransitioninfo.Add(transitionStateinfo.Layer, new Dictionary<int, NetworkAnimator.TransitionStateinfo>());
				}
				Dictionary<int, NetworkAnimator.TransitionStateinfo> dictionary = this.m_DestinationStateToTransitioninfo[transitionStateinfo.Layer];
				if (!dictionary.ContainsKey(transitionStateinfo.DestinationState))
				{
					dictionary.Add(transitionStateinfo.DestinationState, transitionStateinfo);
				}
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00003322 File Offset: 0x00001522
		private void BuildTransitionStateInfoList()
		{
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00003A84 File Offset: 0x00001C84
		public void OnAfterDeserialize()
		{
			this.BuildDestinationToTransitionInfoTable();
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00003A8C File Offset: 0x00001C8C
		public void OnBeforeSerialize()
		{
			this.BuildTransitionStateInfoList();
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000064 RID: 100 RVA: 0x00003A94 File Offset: 0x00001C94
		// (set) Token: 0x06000065 RID: 101 RVA: 0x00003A9C File Offset: 0x00001C9C
		public Animator Animator
		{
			get
			{
				return this.m_Animator;
			}
			set
			{
				this.m_Animator = value;
			}
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00003AA5 File Offset: 0x00001CA5
		internal bool IsServerAuthoritative()
		{
			return this.OnIsServerAuthoritative();
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00003AAD File Offset: 0x00001CAD
		protected virtual bool OnIsServerAuthoritative()
		{
			return true;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00003AB0 File Offset: 0x00001CB0
		private void SpawnCleanup()
		{
			if (this.m_NetworkAnimatorStateChangeHandler != null)
			{
				this.m_NetworkAnimatorStateChangeHandler.DeregisterUpdate();
				this.m_NetworkAnimatorStateChangeHandler = null;
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00003ACC File Offset: 0x00001CCC
		public override void OnDestroy()
		{
			this.SpawnCleanup();
			NativeArray<NetworkAnimator.AnimatorParamCache> cachedAnimatorParameters = this.m_CachedAnimatorParameters;
			if (this.m_CachedAnimatorParameters.IsCreated)
			{
				this.m_CachedAnimatorParameters.Dispose();
			}
			if (this.m_ParameterWriter.IsInitialized)
			{
				this.m_ParameterWriter.Dispose();
			}
			base.OnDestroy();
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00003B1C File Offset: 0x00001D1C
		private unsafe void Awake()
		{
			if (!this.m_Animator)
			{
				Debug.LogError("NetworkAnimator " + base.name + " does not have an Animator assigned to it. The NetworkAnimator will not initialize properly.");
				return;
			}
			int layerCount = this.m_Animator.layerCount;
			this.m_TransitionHash = new int[layerCount];
			this.m_AnimationHash = new int[layerCount];
			this.m_LayerWeights = new float[layerCount];
			this.m_AnimationMessage = new NetworkAnimator.AnimationMessage
			{
				AnimationStates = new List<NetworkAnimator.AnimationState>()
			};
			for (int i = 0; i < this.m_Animator.layerCount; i++)
			{
				this.m_AnimationMessage.AnimationStates.Add(default(NetworkAnimator.AnimationState));
				float layerWeight = this.m_Animator.GetLayerWeight(i);
				if (layerWeight != this.m_LayerWeights[i])
				{
					this.m_LayerWeights[i] = layerWeight;
				}
			}
			int num = 4;
			AnimatorControllerParameter[] parameters = this.m_Animator.parameters;
			this.m_CachedAnimatorParameters = new NativeArray<NetworkAnimator.AnimatorParamCache>(parameters.Length, Allocator.Persistent, NativeArrayOptions.ClearMemory);
			this.m_ParametersToUpdate = new List<int>(parameters.Length);
			int j = 0;
			while (j < parameters.Length)
			{
				AnimatorControllerParameter animatorControllerParameter = parameters[j];
				NetworkAnimator.AnimatorParamCache animatorParamCache = new NetworkAnimator.AnimatorParamCache
				{
					Type = UnsafeUtility.EnumToInt<AnimatorControllerParameterType>(animatorControllerParameter.type),
					Hash = animatorControllerParameter.nameHash
				};
				switch (animatorControllerParameter.type)
				{
				case AnimatorControllerParameterType.Float:
				{
					float @float = this.m_Animator.GetFloat(animatorParamCache.Hash);
					UnsafeUtility.WriteArrayElement<float>((void*)(&animatorParamCache.Value.FixedElementField), 0, @float);
					break;
				}
				case AnimatorControllerParameterType.Int:
				{
					int integer = this.m_Animator.GetInteger(animatorParamCache.Hash);
					UnsafeUtility.WriteArrayElement<int>((void*)(&animatorParamCache.Value.FixedElementField), 0, integer);
					break;
				}
				case AnimatorControllerParameterType.Bool:
				{
					bool @bool = this.m_Animator.GetBool(animatorParamCache.Hash);
					UnsafeUtility.WriteArrayElement<bool>((void*)(&animatorParamCache.Value.FixedElementField), 0, @bool);
					break;
				}
				}
				this.m_CachedAnimatorParameters[j] = animatorParamCache;
				AnimatorControllerParameterType type = animatorControllerParameter.type;
				switch (type)
				{
				case AnimatorControllerParameterType.Float:
					num += 8;
					break;
				case (AnimatorControllerParameterType)2:
					break;
				case AnimatorControllerParameterType.Int:
					num += 8;
					break;
				case AnimatorControllerParameterType.Bool:
					goto IL_217;
				default:
					if (type == AnimatorControllerParameterType.Trigger)
					{
						goto IL_217;
					}
					break;
				}
				IL_221:
				j++;
				continue;
				IL_217:
				num += 5;
				goto IL_221;
			}
			if (this.m_ParameterWriter.IsInitialized)
			{
				this.m_ParameterWriter.Dispose();
			}
			this.m_ParameterWriter = new FastBufferWriter(num, Allocator.Persistent, -1);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00003D80 File Offset: 0x00001F80
		internal NetworkAnimator.AnimationMessage GetAnimationMessage()
		{
			return this.m_AnimationMessage;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00003D88 File Offset: 0x00001F88
		public override void OnNetworkSpawn()
		{
			if (this.m_Animator == null)
			{
				NetworkLog.LogWarningServer("[" + base.gameObject.name + "][NetworkAnimator] Animator is not assigned! Animation synchronization will not work for this instance!");
			}
			if (base.IsServer)
			{
				this.m_ClientSendList = new List<ulong>(128);
				this.m_ClientRpcParams = new ClientRpcParams
				{
					Send = new ClientRpcSendParams
					{
						TargetClientIds = this.m_ClientSendList
					}
				};
			}
			this.m_NetworkAnimatorStateChangeHandler = new NetworkAnimatorStateChangeHandler(this);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00003E12 File Offset: 0x00002012
		public override void OnNetworkDespawn()
		{
			this.SpawnCleanup();
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00003E1C File Offset: 0x0000201C
		private void WriteSynchronizationData<T>(ref BufferSerializer<T> serializer) where T : IReaderWriter
		{
			this.m_ParametersToUpdate.Clear();
			for (int i = 0; i < this.m_CachedAnimatorParameters.Length; i++)
			{
				this.m_ParametersToUpdate.Add(i);
			}
			this.WriteParameters(ref this.m_ParameterWriter);
			NetworkAnimator.ParametersUpdateMessage parametersUpdateMessage = new NetworkAnimator.ParametersUpdateMessage
			{
				Parameters = this.m_ParameterWriter.ToArray()
			};
			serializer.SerializeValue<NetworkAnimator.ParametersUpdateMessage>(ref parametersUpdateMessage, default(FastBufferWriter.ForNetworkSerializable));
			this.m_AnimationMessage.IsDirtyCount = 0;
			for (int j = 0; j < this.m_Animator.layerCount; j++)
			{
				AnimatorStateInfo currentAnimatorStateInfo = this.m_Animator.GetCurrentAnimatorStateInfo(j);
				List<AnimatorStateInfo> synchronizationStateInfo = this.SynchronizationStateInfo;
				if (synchronizationStateInfo != null)
				{
					synchronizationStateInfo.Add(currentAnimatorStateInfo);
				}
				int stateHash = currentAnimatorStateInfo.fullPathHash;
				float normalizedTime = currentAnimatorStateInfo.normalizedTime;
				bool flag = this.m_Animator.IsInTransition(j);
				NetworkAnimator.AnimationState value = this.m_AnimationMessage.AnimationStates[j];
				if (flag)
				{
					AnimatorTransitionInfo animatorTransitionInfo = this.m_Animator.GetAnimatorTransitionInfo(j);
					AnimatorStateInfo nextAnimatorStateInfo = this.m_Animator.GetNextAnimatorStateInfo(j);
					if (nextAnimatorStateInfo.length > 0f)
					{
						float num = nextAnimatorStateInfo.speed * nextAnimatorStateInfo.speedMultiplier;
						float num2 = nextAnimatorStateInfo.length * num;
						float num3 = Mathf.Min(animatorTransitionInfo.duration, animatorTransitionInfo.duration * animatorTransitionInfo.normalizedTime) * 0.5f;
						normalizedTime = Mathf.Min(1f, (num3 > 0f) ? (num3 / num2) : 0f);
					}
					else
					{
						normalizedTime = 0f;
					}
					stateHash = nextAnimatorStateInfo.fullPathHash;
					if (this.m_DestinationStateToTransitioninfo.ContainsKey(j) && this.m_DestinationStateToTransitioninfo[j].ContainsKey(nextAnimatorStateInfo.shortNameHash))
					{
						NetworkAnimator.TransitionStateinfo transitionStateinfo = this.m_DestinationStateToTransitioninfo[j][nextAnimatorStateInfo.shortNameHash];
						stateHash = transitionStateinfo.OriginatingState;
						value.DestinationStateHash = transitionStateinfo.DestinationState;
					}
				}
				value.Transition = flag;
				value.StateHash = stateHash;
				value.NormalizedTime = normalizedTime;
				value.Layer = j;
				value.Weight = this.m_LayerWeights[j];
				this.m_AnimationMessage.AnimationStates[j] = value;
			}
			this.m_AnimationMessage.IsDirtyCount = this.m_Animator.layerCount;
			this.m_AnimationMessage.NetworkSerialize<T>(serializer);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00004084 File Offset: 0x00002284
		protected override void OnSynchronize<T>(ref BufferSerializer<T> serializer)
		{
			if (serializer.IsWriter)
			{
				this.WriteSynchronizationData<T>(ref serializer);
				return;
			}
			NetworkAnimator.ParametersUpdateMessage parametersUpdateMessage = default(NetworkAnimator.ParametersUpdateMessage);
			NetworkAnimator.AnimationMessage animationMessage = default(NetworkAnimator.AnimationMessage);
			serializer.SerializeValue<NetworkAnimator.ParametersUpdateMessage>(ref parametersUpdateMessage, default(FastBufferWriter.ForNetworkSerializable));
			this.UpdateParameters(ref parametersUpdateMessage);
			serializer.SerializeValue<NetworkAnimator.AnimationMessage>(ref animationMessage, default(FastBufferWriter.ForNetworkSerializable));
			foreach (NetworkAnimator.AnimationState animationState in animationMessage.AnimationStates)
			{
				this.UpdateAnimationState(animationState);
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00004124 File Offset: 0x00002324
		private void CheckForStateChange(int layer)
		{
			bool flag = false;
			NetworkAnimator.AnimationState value = this.m_AnimationMessage.AnimationStates[this.m_AnimationMessage.IsDirtyCount];
			float layerWeight = this.m_Animator.GetLayerWeight(layer);
			value.CrossFade = false;
			value.Transition = false;
			value.NormalizedTime = 0f;
			value.Layer = layer;
			value.Duration = 0f;
			value.Weight = this.m_LayerWeights[layer];
			value.DestinationStateHash = 0;
			if (layerWeight != this.m_LayerWeights[layer])
			{
				this.m_LayerWeights[layer] = layerWeight;
				flag = true;
				value.Weight = layerWeight;
			}
			AnimatorStateInfo currentAnimatorStateInfo = this.m_Animator.GetCurrentAnimatorStateInfo(layer);
			if (this.m_Animator.IsInTransition(layer))
			{
				AnimatorTransitionInfo animatorTransitionInfo = this.m_Animator.GetAnimatorTransitionInfo(layer);
				AnimatorStateInfo nextAnimatorStateInfo = this.m_Animator.GetNextAnimatorStateInfo(layer);
				if (animatorTransitionInfo.anyState && animatorTransitionInfo.fullPathHash == 0 && this.m_TransitionHash[layer] != nextAnimatorStateInfo.fullPathHash)
				{
					this.m_TransitionHash[layer] = nextAnimatorStateInfo.fullPathHash;
					this.m_AnimationHash[layer] = 0;
					value.DestinationStateHash = nextAnimatorStateInfo.fullPathHash;
					value.CrossFade = true;
					value.Transition = true;
					value.Duration = animatorTransitionInfo.duration;
					value.NormalizedTime = animatorTransitionInfo.normalizedTime;
					flag = true;
				}
				else if (!animatorTransitionInfo.anyState && animatorTransitionInfo.fullPathHash != this.m_TransitionHash[layer] && (!this.m_DestinationStateToTransitioninfo.ContainsKey(layer) || (this.m_DestinationStateToTransitioninfo.ContainsKey(layer) && this.m_DestinationStateToTransitioninfo[layer].ContainsKey(nextAnimatorStateInfo.fullPathHash))))
				{
					this.m_TransitionHash[layer] = animatorTransitionInfo.fullPathHash;
					this.m_AnimationHash[layer] = 0;
					value.StateHash = animatorTransitionInfo.fullPathHash;
					value.CrossFade = false;
					value.Transition = true;
					value.NormalizedTime = animatorTransitionInfo.normalizedTime;
					if (this.m_DestinationStateToTransitioninfo.ContainsKey(layer) && this.m_DestinationStateToTransitioninfo[layer].ContainsKey(nextAnimatorStateInfo.fullPathHash))
					{
						value.DestinationStateHash = nextAnimatorStateInfo.fullPathHash;
					}
					flag = true;
				}
			}
			else if (currentAnimatorStateInfo.fullPathHash != this.m_AnimationHash[layer])
			{
				this.m_TransitionHash[layer] = 0;
				this.m_AnimationHash[layer] = currentAnimatorStateInfo.fullPathHash;
				if (this.m_AnimationHash[layer] != 0)
				{
					value.StateHash = currentAnimatorStateInfo.fullPathHash;
					value.NormalizedTime = currentAnimatorStateInfo.normalizedTime;
				}
				flag = true;
			}
			if (flag)
			{
				this.m_AnimationMessage.AnimationStates[this.m_AnimationMessage.IsDirtyCount] = value;
				this.m_AnimationMessage.IsDirtyCount = this.m_AnimationMessage.IsDirtyCount + 1;
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x000043D4 File Offset: 0x000025D4
		internal void CheckForAnimatorChanges()
		{
			if (this.CheckParametersChanged())
			{
				this.SendParametersUpdate(default(ClientRpcParams), false);
			}
			if (this.m_Animator.runtimeAnimatorController == null)
			{
				if (base.NetworkManager.LogLevel == LogLevel.Developer)
				{
					Debug.LogError("[" + base.GetType().Name + "] Could not find an assigned RuntimeAnimatorController! Cannot check Animator for changes in state!");
				}
				return;
			}
			this.m_AnimationMessage.IsDirtyCount = 0;
			for (int i = 0; i < this.m_Animator.layerCount; i++)
			{
				AnimatorStateInfo currentAnimatorStateInfo = this.m_Animator.GetCurrentAnimatorStateInfo(i);
				float num = currentAnimatorStateInfo.speed * currentAnimatorStateInfo.speedMultiplier;
				if (num > 0f)
				{
					float num2 = 1f / num;
				}
				this.CheckForStateChange(i);
			}
			if (this.m_AnimationMessage.IsDirtyCount > 0)
			{
				if (!base.IsServer && base.IsOwner)
				{
					this.SendAnimStateServerRpc(this.m_AnimationMessage, default(ServerRpcParams));
					return;
				}
				this.m_ClientSendList.Clear();
				foreach (ulong num3 in base.NetworkManager.ConnectedClientsIds)
				{
					if (num3 != base.NetworkManager.LocalClientId && base.NetworkObject.Observers.Contains(num3))
					{
						this.m_ClientSendList.Add(num3);
					}
				}
				this.m_ClientRpcParams.Send.TargetClientIds = this.m_ClientSendList;
				this.SendAnimStateClientRpc(this.m_AnimationMessage, this.m_ClientRpcParams);
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00004570 File Offset: 0x00002770
		private void SendParametersUpdate(ClientRpcParams clientRpcParams = default(ClientRpcParams), bool sendDirect = false)
		{
			this.WriteParameters(ref this.m_ParameterWriter);
			NetworkAnimator.ParametersUpdateMessage parametersUpdateMessage = new NetworkAnimator.ParametersUpdateMessage
			{
				Parameters = this.m_ParameterWriter.ToArray()
			};
			if (!base.IsServer)
			{
				this.SendParametersUpdateServerRpc(parametersUpdateMessage, default(ServerRpcParams));
				return;
			}
			if (sendDirect)
			{
				this.SendParametersUpdateClientRpc(parametersUpdateMessage, clientRpcParams);
				return;
			}
			this.m_NetworkAnimatorStateChangeHandler.SendParameterUpdate(parametersUpdateMessage, clientRpcParams);
		}

		// Token: 0x06000073 RID: 115 RVA: 0x000045D8 File Offset: 0x000027D8
		private unsafe T GetValue<T>(ref NetworkAnimator.AnimatorParamCache animatorParamCache)
		{
			T result;
			fixed (byte* ptr = &animatorParamCache.Value.FixedElementField)
			{
				void* source = (void*)ptr;
				result = UnsafeUtility.ReadArrayElement<T>(source, 0);
			}
			return result;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00004600 File Offset: 0x00002800
		private bool CheckParametersChanged()
		{
			this.m_ParametersToUpdate.Clear();
			for (int i = 0; i < this.m_CachedAnimatorParameters.Length; i++)
			{
				ref NetworkAnimator.AnimatorParamCache ptr = ref UnsafeUtility.ArrayElementAsRef<NetworkAnimator.AnimatorParamCache>(this.m_CachedAnimatorParameters.GetUnsafePtr<NetworkAnimator.AnimatorParamCache>(), i);
				if (!this.m_Animator.IsParameterControlledByCurve(ptr.Hash))
				{
					int hash = ptr.Hash;
					if (ptr.Type == NetworkAnimator.AnimationParamEnumWrapper.AnimatorControllerParameterInt)
					{
						int integer = this.m_Animator.GetInteger(hash);
						if (this.GetValue<int>(ref ptr) != integer)
						{
							this.m_ParametersToUpdate.Add(i);
						}
					}
					else if (ptr.Type == NetworkAnimator.AnimationParamEnumWrapper.AnimatorControllerParameterBool)
					{
						bool @bool = this.m_Animator.GetBool(hash);
						if (this.GetValue<bool>(ref ptr) != @bool)
						{
							this.m_ParametersToUpdate.Add(i);
						}
					}
					else if (ptr.Type == NetworkAnimator.AnimationParamEnumWrapper.AnimatorControllerParameterFloat)
					{
						float @float = this.m_Animator.GetFloat(hash);
						if (this.GetValue<float>(ref ptr) != @float)
						{
							this.m_ParametersToUpdate.Add(i);
						}
					}
				}
			}
			return this.m_ParametersToUpdate.Count > 0;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x0000470C File Offset: 0x0000290C
		private unsafe void WriteParameters(ref FastBufferWriter writer)
		{
			writer.Seek(0);
			writer.Truncate(-1);
			BytePacker.WriteValuePacked(writer, (uint)this.m_ParametersToUpdate.Count);
			foreach (int num in this.m_ParametersToUpdate)
			{
				ref NetworkAnimator.AnimatorParamCache ptr = ref UnsafeUtility.ArrayElementAsRef<NetworkAnimator.AnimatorParamCache>(this.m_CachedAnimatorParameters.GetUnsafePtr<NetworkAnimator.AnimatorParamCache>(), num);
				int hash = ptr.Hash;
				BytePacker.WriteValuePacked(writer, (uint)num);
				if (ptr.Type == NetworkAnimator.AnimationParamEnumWrapper.AnimatorControllerParameterInt)
				{
					int integer = this.m_Animator.GetInteger(hash);
					try
					{
						fixed (byte* ptr2 = &ptr.Value.FixedElementField)
						{
							void* destination = (void*)ptr2;
							UnsafeUtility.WriteArrayElement<int>(destination, 0, integer);
							BytePacker.WriteValuePacked(writer, (uint)integer);
							continue;
						}
					}
					finally
					{
						byte* ptr2 = null;
					}
				}
				if (ptr.Type == NetworkAnimator.AnimationParamEnumWrapper.AnimatorControllerParameterBool)
				{
					bool @bool = this.m_Animator.GetBool(hash);
					try
					{
						fixed (byte* ptr2 = &ptr.Value.FixedElementField)
						{
							void* destination2 = (void*)ptr2;
							UnsafeUtility.WriteArrayElement<bool>(destination2, 0, @bool);
							BytePacker.WriteValuePacked(writer, @bool);
							continue;
						}
					}
					finally
					{
						byte* ptr2 = null;
					}
				}
				if (ptr.Type == NetworkAnimator.AnimationParamEnumWrapper.AnimatorControllerParameterFloat)
				{
					float @float = this.m_Animator.GetFloat(hash);
					try
					{
						fixed (byte* ptr2 = &ptr.Value.FixedElementField)
						{
							void* destination3 = (void*)ptr2;
							UnsafeUtility.WriteArrayElement<float>(destination3, 0, @float);
							BytePacker.WriteValuePacked(writer, @float);
						}
					}
					finally
					{
						byte* ptr2 = null;
					}
				}
			}
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000048E0 File Offset: 0x00002AE0
		private unsafe void ReadParameters(FastBufferReader reader)
		{
			uint num;
			ByteUnpacker.ReadValuePacked(reader, out num);
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				uint index;
				ByteUnpacker.ReadValuePacked(reader, out index);
				ref NetworkAnimator.AnimatorParamCache ptr = ref UnsafeUtility.ArrayElementAsRef<NetworkAnimator.AnimatorParamCache>(this.m_CachedAnimatorParameters.GetUnsafePtr<NetworkAnimator.AnimatorParamCache>(), (int)index);
				int hash = ptr.Hash;
				if (ptr.Type == NetworkAnimator.AnimationParamEnumWrapper.AnimatorControllerParameterInt)
				{
					uint value;
					ByteUnpacker.ReadValuePacked(reader, out value);
					this.m_Animator.SetInteger(hash, (int)value);
					fixed (byte* ptr2 = &ptr.Value.FixedElementField)
					{
						void* destination = (void*)ptr2;
						UnsafeUtility.WriteArrayElement<uint>(destination, 0, value);
					}
				}
				else if (ptr.Type == NetworkAnimator.AnimationParamEnumWrapper.AnimatorControllerParameterBool)
				{
					bool value2;
					ByteUnpacker.ReadValuePacked(reader, out value2);
					this.m_Animator.SetBool(hash, value2);
					fixed (byte* ptr2 = &ptr.Value.FixedElementField)
					{
						void* destination2 = (void*)ptr2;
						UnsafeUtility.WriteArrayElement<bool>(destination2, 0, value2);
					}
				}
				else if (ptr.Type == NetworkAnimator.AnimationParamEnumWrapper.AnimatorControllerParameterFloat)
				{
					float value3;
					ByteUnpacker.ReadValuePacked(reader, out value3);
					this.m_Animator.SetFloat(hash, value3);
					fixed (byte* ptr2 = &ptr.Value.FixedElementField)
					{
						void* destination3 = (void*)ptr2;
						UnsafeUtility.WriteArrayElement<float>(destination3, 0, value3);
					}
				}
				num2++;
			}
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00004A00 File Offset: 0x00002C00
		internal unsafe void UpdateParameters(ref NetworkAnimator.ParametersUpdateMessage parametersUpdate)
		{
			if (parametersUpdate.Parameters != null && parametersUpdate.Parameters.Length != 0)
			{
				byte[] array;
				byte* buffer;
				if ((array = parametersUpdate.Parameters) == null || array.Length == 0)
				{
					buffer = null;
				}
				else
				{
					buffer = &array[0];
				}
				FastBufferReader reader = new FastBufferReader(buffer, Allocator.None, parametersUpdate.Parameters.Length, 0, Allocator.Temp);
				this.ReadParameters(reader);
				array = null;
			}
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00004A58 File Offset: 0x00002C58
		internal void UpdateAnimationState(NetworkAnimator.AnimationState animationState)
		{
			if (animationState.Layer < this.m_LayerWeights.Length && this.m_LayerWeights[animationState.Layer] != animationState.Weight)
			{
				this.m_Animator.SetLayerWeight(animationState.Layer, animationState.Weight);
				this.m_LayerWeights[animationState.Layer] = animationState.Weight;
			}
			if (animationState.StateHash == 0 && !animationState.Transition)
			{
				return;
			}
			AnimatorStateInfo currentAnimatorStateInfo = this.m_Animator.GetCurrentAnimatorStateInfo(animationState.Layer);
			if (animationState.Transition && !animationState.CrossFade)
			{
				if (this.m_DestinationStateToTransitioninfo.ContainsKey(animationState.Layer))
				{
					if (this.m_DestinationStateToTransitioninfo[animationState.Layer].ContainsKey(animationState.DestinationStateHash))
					{
						if (currentAnimatorStateInfo.shortNameHash == animationState.StateHash)
						{
							NetworkAnimator.TransitionStateinfo transitionStateinfo = this.m_DestinationStateToTransitioninfo[animationState.Layer][animationState.DestinationStateHash];
							this.m_Animator.CrossFade(transitionStateinfo.DestinationState, transitionStateinfo.TransitionDuration, transitionStateinfo.Layer, 0f, animationState.NormalizedTime);
							return;
						}
						if (base.NetworkManager.LogLevel == LogLevel.Developer)
						{
							NetworkLog.LogWarning(string.Format("Current State Hash ({0}) != AnimationState.StateHash ({1})", currentAnimatorStateInfo.fullPathHash, animationState.StateHash));
							return;
						}
					}
					else if (base.NetworkManager.LogLevel == LogLevel.Developer)
					{
						NetworkLog.LogError(string.Format("[DestinationState To Transition Info] Layer ({0}) sub-table does not contain destination state ({1})!", animationState.Layer, animationState.DestinationStateHash));
						return;
					}
				}
				else if (base.NetworkManager.LogLevel == LogLevel.Developer)
				{
					NetworkLog.LogError(string.Format("[DestinationState To Transition Info] Layer ({0}) does not exist!", animationState.Layer));
					return;
				}
			}
			else
			{
				if (animationState.Transition && animationState.CrossFade)
				{
					this.m_Animator.CrossFade(animationState.DestinationStateHash, animationState.Duration, animationState.Layer, animationState.NormalizedTime);
					return;
				}
				if (currentAnimatorStateInfo.fullPathHash != animationState.StateHash && this.m_Animator.HasState(animationState.Layer, animationState.StateHash))
				{
					this.m_Animator.Play(animationState.StateHash, animationState.Layer, animationState.NormalizedTime);
				}
			}
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00004C8C File Offset: 0x00002E8C
		[ServerRpc]
		private void SendParametersUpdateServerRpc(NetworkAnimator.ParametersUpdateMessage parametersUpdate, ServerRpcParams serverRpcParams = default(ServerRpcParams))
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
				FastBufferWriter fastBufferWriter = base.__beginSendServerRpc(1665640498U, serverRpcParams, RpcDelivery.Reliable);
				fastBufferWriter.WriteValueSafe<NetworkAnimator.ParametersUpdateMessage>(parametersUpdate, default(FastBufferWriter.ForNetworkSerializable));
				base.__endSendServerRpc(ref fastBufferWriter, 1665640498U, serverRpcParams, RpcDelivery.Reliable);
			}
			if (this.__rpc_exec_stage != NetworkBehaviour.__RpcExecStage.Execute || (!networkManager.IsServer && !networkManager.IsHost))
			{
				return;
			}
			this.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
			if (this.IsServerAuthoritative())
			{
				this.m_NetworkAnimatorStateChangeHandler.SendParameterUpdate(parametersUpdate, default(ClientRpcParams));
				return;
			}
			if (serverRpcParams.Receive.SenderClientId != base.OwnerClientId)
			{
				return;
			}
			this.UpdateParameters(ref parametersUpdate);
			if (base.NetworkManager.ConnectedClientsIds.Count > (base.IsHost ? 2 : 1))
			{
				this.m_ClientSendList.Clear();
				foreach (ulong num in base.NetworkManager.ConnectedClientsIds)
				{
					if (num != serverRpcParams.Receive.SenderClientId && num != 0UL && base.NetworkObject.Observers.Contains(num))
					{
						this.m_ClientSendList.Add(num);
					}
				}
				this.m_ClientRpcParams.Send.TargetClientIds = this.m_ClientSendList;
				this.m_NetworkAnimatorStateChangeHandler.SendParameterUpdate(parametersUpdate, this.m_ClientRpcParams);
			}
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00004EBC File Offset: 0x000030BC
		[ClientRpc]
		internal void SendParametersUpdateClientRpc(NetworkAnimator.ParametersUpdateMessage parametersUpdate, ClientRpcParams clientRpcParams = default(ClientRpcParams))
		{
			NetworkManager networkManager = base.NetworkManager;
			if (networkManager == null || !networkManager.IsListening)
			{
				return;
			}
			if (this.__rpc_exec_stage != NetworkBehaviour.__RpcExecStage.Execute && (networkManager.IsServer || networkManager.IsHost))
			{
				FastBufferWriter fastBufferWriter = base.__beginSendClientRpc(1189168715U, clientRpcParams, RpcDelivery.Reliable);
				fastBufferWriter.WriteValueSafe<NetworkAnimator.ParametersUpdateMessage>(parametersUpdate, default(FastBufferWriter.ForNetworkSerializable));
				base.__endSendClientRpc(ref fastBufferWriter, 1189168715U, clientRpcParams, RpcDelivery.Reliable);
			}
			if (this.__rpc_exec_stage != NetworkBehaviour.__RpcExecStage.Execute || (!networkManager.IsClient && !networkManager.IsHost))
			{
				return;
			}
			this.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
			bool flag = this.IsServerAuthoritative();
			if ((!flag && !base.IsOwner) || flag)
			{
				this.m_NetworkAnimatorStateChangeHandler.ProcessParameterUpdate(parametersUpdate);
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00004FD0 File Offset: 0x000031D0
		[ServerRpc]
		private void SendAnimStateServerRpc(NetworkAnimator.AnimationMessage animationMessage, ServerRpcParams serverRpcParams = default(ServerRpcParams))
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
				FastBufferWriter fastBufferWriter = base.__beginSendServerRpc(4140764492U, serverRpcParams, RpcDelivery.Reliable);
				fastBufferWriter.WriteValueSafe<NetworkAnimator.AnimationMessage>(animationMessage, default(FastBufferWriter.ForNetworkSerializable));
				base.__endSendServerRpc(ref fastBufferWriter, 4140764492U, serverRpcParams, RpcDelivery.Reliable);
			}
			if (this.__rpc_exec_stage != NetworkBehaviour.__RpcExecStage.Execute || (!networkManager.IsServer && !networkManager.IsHost))
			{
				return;
			}
			this.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
			if (this.IsServerAuthoritative())
			{
				this.m_NetworkAnimatorStateChangeHandler.SendAnimationUpdate(animationMessage, default(ClientRpcParams));
				return;
			}
			if (serverRpcParams.Receive.SenderClientId != base.OwnerClientId)
			{
				return;
			}
			foreach (NetworkAnimator.AnimationState animationState in animationMessage.AnimationStates)
			{
				this.UpdateAnimationState(animationState);
			}
			if (base.NetworkManager.ConnectedClientsIds.Count > (base.IsHost ? 2 : 1))
			{
				this.m_ClientSendList.Clear();
				foreach (ulong num in base.NetworkManager.ConnectedClientsIds)
				{
					if (num != serverRpcParams.Receive.SenderClientId && num != 0UL && base.NetworkObject.Observers.Contains(num))
					{
						this.m_ClientSendList.Add(num);
					}
				}
				this.m_ClientRpcParams.Send.TargetClientIds = this.m_ClientSendList;
				this.m_NetworkAnimatorStateChangeHandler.SendAnimationUpdate(animationMessage, this.m_ClientRpcParams);
			}
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00005240 File Offset: 0x00003440
		[ClientRpc]
		internal void SendAnimStateClientRpc(NetworkAnimator.AnimationMessage animationMessage, ClientRpcParams clientRpcParams = default(ClientRpcParams))
		{
			NetworkManager networkManager = base.NetworkManager;
			if (networkManager == null || !networkManager.IsListening)
			{
				return;
			}
			if (this.__rpc_exec_stage != NetworkBehaviour.__RpcExecStage.Execute && (networkManager.IsServer || networkManager.IsHost))
			{
				FastBufferWriter fastBufferWriter = base.__beginSendClientRpc(1069363937U, clientRpcParams, RpcDelivery.Reliable);
				fastBufferWriter.WriteValueSafe<NetworkAnimator.AnimationMessage>(animationMessage, default(FastBufferWriter.ForNetworkSerializable));
				base.__endSendClientRpc(ref fastBufferWriter, 1069363937U, clientRpcParams, RpcDelivery.Reliable);
			}
			if (this.__rpc_exec_stage != NetworkBehaviour.__RpcExecStage.Execute || (!networkManager.IsClient && !networkManager.IsHost))
			{
				return;
			}
			this.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
			if (base.IsHost)
			{
				if (base.NetworkManager.LogLevel == LogLevel.Developer)
				{
					NetworkLog.LogWarning("Detected the Host is sending itself animation updates! Please report this issue.");
				}
				return;
			}
			foreach (NetworkAnimator.AnimationState animationState in animationMessage.AnimationStates)
			{
				this.UpdateAnimationState(animationState);
			}
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00005394 File Offset: 0x00003594
		[ServerRpc]
		internal void SendAnimTriggerServerRpc(NetworkAnimator.AnimationTriggerMessage animationTriggerMessage, ServerRpcParams serverRpcParams = default(ServerRpcParams))
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
				FastBufferWriter fastBufferWriter = base.__beginSendServerRpc(817791944U, serverRpcParams, RpcDelivery.Reliable);
				fastBufferWriter.WriteValueSafe<NetworkAnimator.AnimationTriggerMessage>(animationTriggerMessage, default(FastBufferWriter.ForNetworkSerializable));
				base.__endSendServerRpc(ref fastBufferWriter, 817791944U, serverRpcParams, RpcDelivery.Reliable);
			}
			if (this.__rpc_exec_stage != NetworkBehaviour.__RpcExecStage.Execute || (!networkManager.IsServer && !networkManager.IsHost))
			{
				return;
			}
			this.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
			if (serverRpcParams.Receive.SenderClientId != base.OwnerClientId)
			{
				if (base.NetworkManager.LogLevel == LogLevel.Developer)
				{
					NetworkLog.LogWarning("[Owner Authoritative] Detected the a non-authoritative client is sending the server animation trigger updates. If you recently changed ownership of the " + base.name + " object, then this could be the reason.");
				}
				return;
			}
			this.InternalSetTrigger(animationTriggerMessage.Hash, animationTriggerMessage.IsTriggerSet);
			this.m_ClientSendList.Clear();
			foreach (ulong num in base.NetworkManager.ConnectedClientsIds)
			{
				if (num != 0UL && base.NetworkObject.Observers.Contains(num))
				{
					this.m_ClientSendList.Add(num);
				}
			}
			if (this.IsServerAuthoritative())
			{
				this.m_NetworkAnimatorStateChangeHandler.QueueTriggerUpdateToClient(animationTriggerMessage, this.m_ClientRpcParams);
				return;
			}
			if (base.NetworkManager.ConnectedClientsIds.Count > (base.IsHost ? 2 : 1))
			{
				this.m_ClientSendList.Remove(serverRpcParams.Receive.SenderClientId);
				this.m_NetworkAnimatorStateChangeHandler.QueueTriggerUpdateToClient(animationTriggerMessage, this.m_ClientRpcParams);
			}
		}

		// Token: 0x0600007E RID: 126 RVA: 0x000055E4 File Offset: 0x000037E4
		private void InternalSetTrigger(int hash, bool isSet = true)
		{
			this.m_Animator.SetBool(hash, isSet);
		}

		// Token: 0x0600007F RID: 127 RVA: 0x000055F4 File Offset: 0x000037F4
		[ClientRpc]
		internal void SendAnimTriggerClientRpc(NetworkAnimator.AnimationTriggerMessage animationTriggerMessage, ClientRpcParams clientRpcParams = default(ClientRpcParams))
		{
			NetworkManager networkManager = base.NetworkManager;
			if (networkManager == null || !networkManager.IsListening)
			{
				return;
			}
			if (this.__rpc_exec_stage != NetworkBehaviour.__RpcExecStage.Execute && (networkManager.IsServer || networkManager.IsHost))
			{
				FastBufferWriter fastBufferWriter = base.__beginSendClientRpc(2230447564U, clientRpcParams, RpcDelivery.Reliable);
				fastBufferWriter.WriteValueSafe<NetworkAnimator.AnimationTriggerMessage>(animationTriggerMessage, default(FastBufferWriter.ForNetworkSerializable));
				base.__endSendClientRpc(ref fastBufferWriter, 2230447564U, clientRpcParams, RpcDelivery.Reliable);
			}
			if (this.__rpc_exec_stage != NetworkBehaviour.__RpcExecStage.Execute || (!networkManager.IsClient && !networkManager.IsHost))
			{
				return;
			}
			this.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
			this.InternalSetTrigger(animationTriggerMessage.Hash, animationTriggerMessage.IsTriggerSet);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000056F4 File Offset: 0x000038F4
		public void SetTrigger(string triggerName)
		{
			this.SetTrigger(Animator.StringToHash(triggerName), true);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00005704 File Offset: 0x00003904
		public void SetTrigger(int hash, bool setTrigger = true)
		{
			if (base.IsOwner || base.IsServer)
			{
				NetworkAnimator.AnimationTriggerMessage animationTriggerMessage = new NetworkAnimator.AnimationTriggerMessage
				{
					Hash = hash,
					IsTriggerSet = setTrigger
				};
				if (base.IsServer)
				{
					this.m_NetworkAnimatorStateChangeHandler.QueueTriggerUpdateToClient(animationTriggerMessage, default(ClientRpcParams));
					if (!base.IsHost)
					{
						this.InternalSetTrigger(hash, setTrigger);
						return;
					}
				}
				else
				{
					this.m_NetworkAnimatorStateChangeHandler.QueueTriggerUpdateToServer(animationTriggerMessage);
					if (!this.IsServerAuthoritative())
					{
						this.InternalSetTrigger(hash, setTrigger);
					}
				}
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00005785 File Offset: 0x00003985
		public void ResetTrigger(string triggerName)
		{
			this.ResetTrigger(Animator.StringToHash(triggerName));
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00005793 File Offset: 0x00003993
		public void ResetTrigger(int hash)
		{
			this.SetTrigger(hash, false);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x000057C0 File Offset: 0x000039C0
		protected override void __initializeVariables()
		{
			base.__initializeVariables();
		}

		// Token: 0x06000087 RID: 135 RVA: 0x000057D8 File Offset: 0x000039D8
		protected override void __initializeRpcs()
		{
			base.__registerRpc(1665640498U, new NetworkBehaviour.RpcReceiveHandler(NetworkAnimator.__rpc_handler_1665640498), "SendParametersUpdateServerRpc");
			base.__registerRpc(1189168715U, new NetworkBehaviour.RpcReceiveHandler(NetworkAnimator.__rpc_handler_1189168715), "SendParametersUpdateClientRpc");
			base.__registerRpc(4140764492U, new NetworkBehaviour.RpcReceiveHandler(NetworkAnimator.__rpc_handler_4140764492), "SendAnimStateServerRpc");
			base.__registerRpc(1069363937U, new NetworkBehaviour.RpcReceiveHandler(NetworkAnimator.__rpc_handler_1069363937), "SendAnimStateClientRpc");
			base.__registerRpc(817791944U, new NetworkBehaviour.RpcReceiveHandler(NetworkAnimator.__rpc_handler_817791944), "SendAnimTriggerServerRpc");
			base.__registerRpc(2230447564U, new NetworkBehaviour.RpcReceiveHandler(NetworkAnimator.__rpc_handler_2230447564), "SendAnimTriggerClientRpc");
			base.__initializeRpcs();
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00005898 File Offset: 0x00003A98
		private static void __rpc_handler_1665640498(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
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
			NetworkAnimator.ParametersUpdateMessage parametersUpdate;
			reader.ReadValueSafe<NetworkAnimator.ParametersUpdateMessage>(out parametersUpdate, default(FastBufferWriter.ForNetworkSerializable));
			ServerRpcParams server = rpcParams.Server;
			target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Execute;
			((NetworkAnimator)target).SendParametersUpdateServerRpc(parametersUpdate, server);
			target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00005964 File Offset: 0x00003B64
		private static void __rpc_handler_1189168715(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
			NetworkManager networkManager = target.NetworkManager;
			if (networkManager == null || !networkManager.IsListening)
			{
				return;
			}
			NetworkAnimator.ParametersUpdateMessage parametersUpdate;
			reader.ReadValueSafe<NetworkAnimator.ParametersUpdateMessage>(out parametersUpdate, default(FastBufferWriter.ForNetworkSerializable));
			ClientRpcParams client = rpcParams.Client;
			target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Execute;
			((NetworkAnimator)target).SendParametersUpdateClientRpc(parametersUpdate, client);
			target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000059E4 File Offset: 0x00003BE4
		private static void __rpc_handler_4140764492(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
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
			NetworkAnimator.AnimationMessage animationMessage;
			reader.ReadValueSafe<NetworkAnimator.AnimationMessage>(out animationMessage, default(FastBufferWriter.ForNetworkSerializable));
			ServerRpcParams server = rpcParams.Server;
			target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Execute;
			((NetworkAnimator)target).SendAnimStateServerRpc(animationMessage, server);
			target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00005AB0 File Offset: 0x00003CB0
		private static void __rpc_handler_1069363937(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
			NetworkManager networkManager = target.NetworkManager;
			if (networkManager == null || !networkManager.IsListening)
			{
				return;
			}
			NetworkAnimator.AnimationMessage animationMessage;
			reader.ReadValueSafe<NetworkAnimator.AnimationMessage>(out animationMessage, default(FastBufferWriter.ForNetworkSerializable));
			ClientRpcParams client = rpcParams.Client;
			target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Execute;
			((NetworkAnimator)target).SendAnimStateClientRpc(animationMessage, client);
			target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00005B30 File Offset: 0x00003D30
		private static void __rpc_handler_817791944(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
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
			NetworkAnimator.AnimationTriggerMessage animationTriggerMessage;
			reader.ReadValueSafe<NetworkAnimator.AnimationTriggerMessage>(out animationTriggerMessage, default(FastBufferWriter.ForNetworkSerializable));
			ServerRpcParams server = rpcParams.Server;
			target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Execute;
			((NetworkAnimator)target).SendAnimTriggerServerRpc(animationTriggerMessage, server);
			target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00005BFC File Offset: 0x00003DFC
		private static void __rpc_handler_2230447564(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
			NetworkManager networkManager = target.NetworkManager;
			if (networkManager == null || !networkManager.IsListening)
			{
				return;
			}
			NetworkAnimator.AnimationTriggerMessage animationTriggerMessage;
			reader.ReadValueSafe<NetworkAnimator.AnimationTriggerMessage>(out animationTriggerMessage, default(FastBufferWriter.ForNetworkSerializable));
			ClientRpcParams client = rpcParams.Client;
			target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Execute;
			((NetworkAnimator)target).SendAnimTriggerClientRpc(animationTriggerMessage, client);
			target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00005C7A File Offset: 0x00003E7A
		protected internal override string __getTypeName()
		{
			return "NetworkAnimator";
		}

		// Token: 0x04000049 RID: 73
		[HideInInspector]
		[SerializeField]
		internal List<NetworkAnimator.TransitionStateinfo> TransitionStateInfoList;

		// Token: 0x0400004A RID: 74
		private Dictionary<int, Dictionary<int, NetworkAnimator.TransitionStateinfo>> m_DestinationStateToTransitioninfo = new Dictionary<int, Dictionary<int, NetworkAnimator.TransitionStateinfo>>();

		// Token: 0x0400004B RID: 75
		[SerializeField]
		private Animator m_Animator;

		// Token: 0x0400004C RID: 76
		private int[] m_TransitionHash;

		// Token: 0x0400004D RID: 77
		private int[] m_AnimationHash;

		// Token: 0x0400004E RID: 78
		private float[] m_LayerWeights;

		// Token: 0x0400004F RID: 79
		private static byte[] s_EmptyArray = new byte[0];

		// Token: 0x04000050 RID: 80
		private List<int> m_ParametersToUpdate;

		// Token: 0x04000051 RID: 81
		private List<ulong> m_ClientSendList;

		// Token: 0x04000052 RID: 82
		private ClientRpcParams m_ClientRpcParams;

		// Token: 0x04000053 RID: 83
		private NetworkAnimator.AnimationMessage m_AnimationMessage;

		// Token: 0x04000054 RID: 84
		private NetworkAnimatorStateChangeHandler m_NetworkAnimatorStateChangeHandler;

		// Token: 0x04000055 RID: 85
		internal List<AnimatorStateInfo> SynchronizationStateInfo;

		// Token: 0x04000056 RID: 86
		private FastBufferWriter m_ParameterWriter;

		// Token: 0x04000057 RID: 87
		private NativeArray<NetworkAnimator.AnimatorParamCache> m_CachedAnimatorParameters;

		// Token: 0x02000015 RID: 21
		[Serializable]
		internal class TransitionStateinfo
		{
			// Token: 0x04000058 RID: 88
			public bool IsCrossFadeExit;

			// Token: 0x04000059 RID: 89
			public int Layer;

			// Token: 0x0400005A RID: 90
			public int OriginatingState;

			// Token: 0x0400005B RID: 91
			public int DestinationState;

			// Token: 0x0400005C RID: 92
			public float TransitionDuration;

			// Token: 0x0400005D RID: 93
			public int TriggerNameHash;

			// Token: 0x0400005E RID: 94
			public int TransitionIndex;
		}

		// Token: 0x02000016 RID: 22
		internal struct AnimationState : INetworkSerializable
		{
			// Token: 0x06000090 RID: 144 RVA: 0x00005C84 File Offset: 0x00003E84
			public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
			{
				if (serializer.IsWriter)
				{
					FastBufferWriter fastBufferWriter = serializer.GetFastBufferWriter();
					this.m_StateFlags = 0;
					if (this.Transition)
					{
						this.m_StateFlags |= 1;
					}
					if (this.CrossFade)
					{
						this.m_StateFlags |= 2;
					}
					serializer.SerializeValue(ref this.m_StateFlags);
					BytePacker.WriteValuePacked(fastBufferWriter, this.StateHash);
					BytePacker.WriteValuePacked(fastBufferWriter, this.Layer);
					if (this.Transition)
					{
						BytePacker.WriteValuePacked(fastBufferWriter, this.DestinationStateHash);
					}
				}
				else
				{
					FastBufferReader fastBufferReader = serializer.GetFastBufferReader();
					serializer.SerializeValue(ref this.m_StateFlags);
					this.Transition = ((this.m_StateFlags & 1) == 1);
					this.CrossFade = ((this.m_StateFlags & 2) == 2);
					ByteUnpacker.ReadValuePacked(fastBufferReader, out this.StateHash);
					ByteUnpacker.ReadValuePacked(fastBufferReader, out this.Layer);
					if (this.Transition)
					{
						ByteUnpacker.ReadValuePacked(fastBufferReader, out this.DestinationStateHash);
					}
				}
				serializer.SerializeValue<float>(ref this.NormalizedTime, default(FastBufferWriter.ForPrimitives));
				serializer.SerializeValue<float>(ref this.Weight, default(FastBufferWriter.ForPrimitives));
				if (this.CrossFade)
				{
					serializer.SerializeValue<float>(ref this.Duration, default(FastBufferWriter.ForPrimitives));
				}
			}

			// Token: 0x0400005F RID: 95
			internal bool HasBeenProcessed;

			// Token: 0x04000060 RID: 96
			internal int StateHash;

			// Token: 0x04000061 RID: 97
			internal float NormalizedTime;

			// Token: 0x04000062 RID: 98
			internal int Layer;

			// Token: 0x04000063 RID: 99
			internal float Weight;

			// Token: 0x04000064 RID: 100
			internal float Duration;

			// Token: 0x04000065 RID: 101
			internal bool Transition;

			// Token: 0x04000066 RID: 102
			internal bool CrossFade;

			// Token: 0x04000067 RID: 103
			private const byte k_IsTransition = 1;

			// Token: 0x04000068 RID: 104
			private const byte k_IsCrossFade = 2;

			// Token: 0x04000069 RID: 105
			private byte m_StateFlags;

			// Token: 0x0400006A RID: 106
			internal int DestinationStateHash;
		}

		// Token: 0x02000017 RID: 23
		internal struct AnimationMessage : INetworkSerializable
		{
			// Token: 0x06000091 RID: 145 RVA: 0x00005DC0 File Offset: 0x00003FC0
			public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
			{
				NetworkAnimator.AnimationState item = default(NetworkAnimator.AnimationState);
				if (serializer.IsReader)
				{
					this.AnimationStates = new List<NetworkAnimator.AnimationState>();
					serializer.SerializeValue<int>(ref this.IsDirtyCount, default(FastBufferWriter.ForPrimitives));
					for (int i = 0; i < this.IsDirtyCount; i++)
					{
						item = default(NetworkAnimator.AnimationState);
						serializer.SerializeValue<NetworkAnimator.AnimationState>(ref item, default(FastBufferWriter.ForNetworkSerializable));
						this.AnimationStates.Add(item);
					}
					return;
				}
				serializer.SerializeValue<int>(ref this.IsDirtyCount, default(FastBufferWriter.ForPrimitives));
				for (int j = 0; j < this.IsDirtyCount; j++)
				{
					item = this.AnimationStates[j];
					serializer.SerializeNetworkSerializable<NetworkAnimator.AnimationState>(ref item);
				}
			}

			// Token: 0x0400006B RID: 107
			internal bool HasBeenProcessed;

			// Token: 0x0400006C RID: 108
			internal List<NetworkAnimator.AnimationState> AnimationStates;

			// Token: 0x0400006D RID: 109
			internal int IsDirtyCount;
		}

		// Token: 0x02000018 RID: 24
		internal struct ParametersUpdateMessage : INetworkSerializable
		{
			// Token: 0x06000092 RID: 146 RVA: 0x00005E7C File Offset: 0x0000407C
			public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
			{
				serializer.SerializeValue<byte>(ref this.Parameters, default(FastBufferWriter.ForPrimitives));
			}

			// Token: 0x0400006E RID: 110
			internal byte[] Parameters;
		}

		// Token: 0x02000019 RID: 25
		internal struct AnimationTriggerMessage : INetworkSerializable
		{
			// Token: 0x06000093 RID: 147 RVA: 0x00005EA0 File Offset: 0x000040A0
			public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
			{
				serializer.SerializeValue<int>(ref this.Hash, default(FastBufferWriter.ForPrimitives));
				serializer.SerializeValue<bool>(ref this.IsTriggerSet, default(FastBufferWriter.ForPrimitives));
			}

			// Token: 0x0400006F RID: 111
			internal int Hash;

			// Token: 0x04000070 RID: 112
			internal bool IsTriggerSet;
		}

		// Token: 0x0200001A RID: 26
		private struct AnimatorParamCache
		{
			// Token: 0x04000071 RID: 113
			internal int Hash;

			// Token: 0x04000072 RID: 114
			internal int Type;

			// Token: 0x04000073 RID: 115
			[FixedBuffer(typeof(byte), 4)]
			internal NetworkAnimator.AnimatorParamCache.<Value>e__FixedBuffer Value;

			// Token: 0x0200001B RID: 27
			[CompilerGenerated]
			[UnsafeValueType]
			[StructLayout(LayoutKind.Sequential, Size = 4)]
			public struct <Value>e__FixedBuffer
			{
				// Token: 0x04000074 RID: 116
				public byte FixedElementField;
			}
		}

		// Token: 0x0200001C RID: 28
		private struct AnimationParamEnumWrapper
		{
			// Token: 0x04000075 RID: 117
			internal static readonly int AnimatorControllerParameterInt = UnsafeUtility.EnumToInt<AnimatorControllerParameterType>(AnimatorControllerParameterType.Int);

			// Token: 0x04000076 RID: 118
			internal static readonly int AnimatorControllerParameterFloat = UnsafeUtility.EnumToInt<AnimatorControllerParameterType>(AnimatorControllerParameterType.Float);

			// Token: 0x04000077 RID: 119
			internal static readonly int AnimatorControllerParameterBool = UnsafeUtility.EnumToInt<AnimatorControllerParameterType>(AnimatorControllerParameterType.Bool);

			// Token: 0x04000078 RID: 120
			internal static readonly int AnimatorControllerParameterTriggerBool = UnsafeUtility.EnumToInt<AnimatorControllerParameterType>(AnimatorControllerParameterType.Trigger);
		}
	}
}
