using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

// Token: 0x0200006D RID: 109
public class MultiTransformSyncLiteCleaned : NetworkBehaviour
{
	// Token: 0x060001B3 RID: 435 RVA: 0x0000DF74 File Offset: 0x0000C174
	public override void OnNetworkSpawn()
	{
		MultiTransformSyncLiteCleaned.objectMap[base.OwnerClientId] = this;
		int num = this.objectsToSync.Length;
		this.stateBuffers = new Queue<MultiTransformSyncLiteCleaned.TransformState>[num];
		this.remoteTimeOffsets = new float[num];
		for (int i = 0; i < num; i++)
		{
			this.stateBuffers[i] = new Queue<MultiTransformSyncLiteCleaned.TransformState>(240);
			this.remoteTimeOffsets[i] = float.MinValue;
		}
		this.lastPlayTimestamps = new float[this.oneShotSounds.Length];
		for (int j = 0; j < this.lastPlayTimestamps.Length; j++)
		{
			this.lastPlayTimestamps[j] = -1f;
		}
	}

	// Token: 0x060001B4 RID: 436 RVA: 0x0000E011 File Offset: 0x0000C211
	public override void OnNetworkDespawn()
	{
		MultiTransformSyncLiteCleaned.objectMap.Remove(base.OwnerClientId);
	}

	// Token: 0x060001B5 RID: 437 RVA: 0x0000E024 File Offset: 0x0000C224
	private void Update()
	{
		if (base.IsOwner)
		{
			this.sendTimer += Time.deltaTime;
			if (this.sendTimer >= 1f / this.sendRate)
			{
				this.sendTimer = 0f;
				Vector3[] array = new Vector3[this.objectsToSync.Length];
				Quaternion[] array2 = new Quaternion[this.objectsToSync.Length];
				for (int i = 0; i < this.objectsToSync.Length; i++)
				{
					MultiTransformSyncLiteCleaned.SyncTarget syncTarget = this.objectsToSync[i];
					array[i] = (syncTarget.syncPosition ? (syncTarget.useLocal ? syncTarget.target.localPosition : syncTarget.target.position) : Vector3.zero);
					array2[i] = (syncTarget.syncRotation ? (syncTarget.useLocal ? syncTarget.target.localRotation : syncTarget.target.rotation) : Quaternion.identity);
				}
				bool[] array3 = new bool[this.oneShotSounds.Length];
				for (int j = 0; j < this.oneShotSounds.Length; j++)
				{
					if (this.oneShotSounds[j] != null && this.oneShotSounds[j].isPlaying && !this.prevOneShotPlaying)
					{
						array3[j] = true;
					}
				}
				float realtimeSinceStartup = Time.realtimeSinceStartup;
				AudioSource audioSource = this.rollingSound;
				float rollingVolume = (audioSource != null) ? audioSource.volume : 0f;
				AudioSource audioSource2 = this.rollingSound;
				float rollingPitch = (audioSource2 != null) ? audioSource2.pitch : 1f;
				AudioSource audioSource3 = this.grindSound;
				float grindVolume = (audioSource3 != null) ? audioSource3.volume : 0f;
				AudioSource audioSource4 = this.grindSound;
				float grindPitch = (audioSource4 != null) ? audioSource4.pitch : 1f;
				AudioSource scooterCrashSlide = this.ScooterCrashSlide;
				float scooterCrashVolume = (scooterCrashSlide != null) ? scooterCrashSlide.volume : 0f;
				AudioSource characterCrashSlide = this.CharacterCrashSlide;
				float characterCrashVolume = (characterCrashSlide != null) ? characterCrashSlide.volume : 0f;
				this.SendStateServerRpc(array, array2, realtimeSinceStartup, rollingVolume, rollingPitch, grindVolume, grindPitch, scooterCrashVolume, characterCrashVolume, array3, default(ServerRpcParams));
				this.prevOneShotPlaying = false;
				foreach (AudioSource audioSource5 in this.oneShotSounds)
				{
					if (audioSource5 != null && audioSource5.isPlaying)
					{
						this.prevOneShotPlaying = true;
						return;
					}
				}
				return;
			}
		}
		else
		{
			this.snapTimer += Time.deltaTime;
			if (this.snapTimer >= this.snapInterval)
			{
				this.SnapToLatest();
				this.snapTimer = 0f;
			}
			float num = Time.realtimeSinceStartup - this.interpolationBackTime;
			for (int l = 0; l < this.objectsToSync.Length; l++)
			{
				MultiTransformSyncLiteCleaned.SyncTarget syncTarget2 = this.objectsToSync[l];
				Queue<MultiTransformSyncLiteCleaned.TransformState> queue = this.stateBuffers[l];
				if (!(syncTarget2.target == null) && queue.Count >= 2)
				{
					MultiTransformSyncLiteCleaned.TransformState[] array5 = queue.ToArray();
					for (int m = 0; m < array5.Length - 1; m++)
					{
						if (array5[m].timestamp <= num && num <= array5[m + 1].timestamp)
						{
							float t = Mathf.InverseLerp(array5[m].timestamp, array5[m + 1].timestamp, num);
							Vector3 p = Vector3.Lerp(array5[m].position, array5[m + 1].position, t);
							Quaternion r = Quaternion.Slerp(array5[m].rotation, array5[m + 1].rotation, t);
							this.ApplyInterpolated(syncTarget2, p, r);
							break;
						}
					}
				}
			}
			if (this.soundBuffer.Count >= 2)
			{
				MultiTransformSyncLiteCleaned.TransformState[] array6 = this.soundBuffer.ToArray();
				int n = 0;
				while (n < array6.Length - 1)
				{
					if (array6[n].timestamp <= num && num <= array6[n + 1].timestamp)
					{
						float t2 = Mathf.InverseLerp(array6[n].timestamp, array6[n + 1].timestamp, num);
						if (this.rollingSound != null)
						{
							this.rollingSound.volume = Mathf.Lerp(array6[n].rollingVolume, array6[n + 1].rollingVolume, t2);
							this.rollingSound.pitch = Mathf.Lerp(array6[n].rollingPitch, array6[n + 1].rollingPitch, t2);
						}
						if (this.grindSound != null)
						{
							this.grindSound.volume = Mathf.Lerp(array6[n].grindVolume, array6[n + 1].grindVolume, t2);
							this.grindSound.pitch = Mathf.Lerp(array6[n].grindPitch, array6[n + 1].grindPitch, t2);
						}
						if (this.ScooterCrashSlide != null)
						{
							this.ScooterCrashSlide.volume = Mathf.Lerp(array6[n].scooterCrashVolume, array6[n + 1].scooterCrashVolume, t2);
						}
						if (this.CharacterCrashSlide != null)
						{
							this.CharacterCrashSlide.volume = Mathf.Lerp(array6[n].characterCrashVolume, array6[n + 1].characterCrashVolume, t2);
							break;
						}
						break;
					}
					else
					{
						n++;
					}
				}
				foreach (MultiTransformSyncLiteCleaned.TransformState transformState in array6)
				{
					if (transformState.playOneShots != null)
					{
						int num2 = 0;
						while (num2 < transformState.playOneShots.Length && num2 < this.oneShotSounds.Length)
						{
							if (transformState.playOneShots[num2] && transformState.timestamp > this.lastPlayTimestamps[num2] && transformState.timestamp <= num && this.oneShotSounds[num2] != null)
							{
								this.oneShotSounds[num2].Stop();
								this.oneShotSounds[num2].Play();
								this.lastPlayTimestamps[num2] = transformState.timestamp;
							}
							num2++;
						}
					}
				}
			}
		}
	}

	// Token: 0x060001B6 RID: 438 RVA: 0x0000E684 File Offset: 0x0000C884
	[ServerRpc(RequireOwnership = false)]
	private void SendStateServerRpc(Vector3[] positions, Quaternion[] rotations, float timestamp, float rollingVolume, float rollingPitch, float grindVolume, float grindPitch, float scooterCrashVolume, float characterCrashVolume, bool[] playOneShots, ServerRpcParams rpcParams = default(ServerRpcParams))
	{
		NetworkManager networkManager = base.NetworkManager;
		if (networkManager == null || !networkManager.IsListening)
		{
			return;
		}
		if (this.__rpc_exec_stage != NetworkBehaviour.__RpcExecStage.Execute && (networkManager.IsClient || networkManager.IsHost))
		{
			FastBufferWriter fastBufferWriter = base.__beginSendServerRpc(2909828867U, rpcParams, RpcDelivery.Reliable);
			bool flag = positions != null;
			fastBufferWriter.WriteValueSafe<bool>(flag, default(FastBufferWriter.ForPrimitives));
			if (flag)
			{
				fastBufferWriter.WriteValueSafe(positions);
			}
			bool flag2 = rotations != null;
			fastBufferWriter.WriteValueSafe<bool>(flag2, default(FastBufferWriter.ForPrimitives));
			if (flag2)
			{
				fastBufferWriter.WriteValueSafe(rotations);
			}
			fastBufferWriter.WriteValueSafe<float>(timestamp, default(FastBufferWriter.ForPrimitives));
			fastBufferWriter.WriteValueSafe<float>(rollingVolume, default(FastBufferWriter.ForPrimitives));
			fastBufferWriter.WriteValueSafe<float>(rollingPitch, default(FastBufferWriter.ForPrimitives));
			fastBufferWriter.WriteValueSafe<float>(grindVolume, default(FastBufferWriter.ForPrimitives));
			fastBufferWriter.WriteValueSafe<float>(grindPitch, default(FastBufferWriter.ForPrimitives));
			fastBufferWriter.WriteValueSafe<float>(scooterCrashVolume, default(FastBufferWriter.ForPrimitives));
			fastBufferWriter.WriteValueSafe<float>(characterCrashVolume, default(FastBufferWriter.ForPrimitives));
			bool flag3 = playOneShots != null;
			fastBufferWriter.WriteValueSafe<bool>(flag3, default(FastBufferWriter.ForPrimitives));
			if (flag3)
			{
				fastBufferWriter.WriteValueSafe<bool>(playOneShots, default(FastBufferWriter.ForPrimitives));
			}
			base.__endSendServerRpc(ref fastBufferWriter, 2909828867U, rpcParams, RpcDelivery.Reliable);
		}
		if (this.__rpc_exec_stage != NetworkBehaviour.__RpcExecStage.Execute || (!networkManager.IsServer && !networkManager.IsHost))
		{
			return;
		}
		this.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
		this.BroadcastStateClientRpc(rpcParams.Receive.SenderClientId, positions, rotations, timestamp, rollingVolume, rollingPitch, grindVolume, grindPitch, scooterCrashVolume, characterCrashVolume, playOneShots, default(ClientRpcParams));
	}

	// Token: 0x060001B7 RID: 439 RVA: 0x0000E908 File Offset: 0x0000CB08
	[ClientRpc]
	private void BroadcastStateClientRpc(ulong senderClientId, Vector3[] positions, Quaternion[] rotations, float timestamp, float rollingVolume, float rollingPitch, float grindVolume, float grindPitch, float scooterCrashVolume, float characterCrashVolume, bool[] playOneShots, ClientRpcParams rpcParams = default(ClientRpcParams))
	{
		NetworkManager networkManager = base.NetworkManager;
		if (networkManager == null || !networkManager.IsListening)
		{
			return;
		}
		if (this.__rpc_exec_stage != NetworkBehaviour.__RpcExecStage.Execute && (networkManager.IsServer || networkManager.IsHost))
		{
			FastBufferWriter writer = base.__beginSendClientRpc(2016312021U, rpcParams, RpcDelivery.Reliable);
			BytePacker.WriteValueBitPacked(writer, senderClientId);
			bool flag = positions != null;
			writer.WriteValueSafe<bool>(flag, default(FastBufferWriter.ForPrimitives));
			if (flag)
			{
				writer.WriteValueSafe(positions);
			}
			bool flag2 = rotations != null;
			writer.WriteValueSafe<bool>(flag2, default(FastBufferWriter.ForPrimitives));
			if (flag2)
			{
				writer.WriteValueSafe(rotations);
			}
			writer.WriteValueSafe<float>(timestamp, default(FastBufferWriter.ForPrimitives));
			writer.WriteValueSafe<float>(rollingVolume, default(FastBufferWriter.ForPrimitives));
			writer.WriteValueSafe<float>(rollingPitch, default(FastBufferWriter.ForPrimitives));
			writer.WriteValueSafe<float>(grindVolume, default(FastBufferWriter.ForPrimitives));
			writer.WriteValueSafe<float>(grindPitch, default(FastBufferWriter.ForPrimitives));
			writer.WriteValueSafe<float>(scooterCrashVolume, default(FastBufferWriter.ForPrimitives));
			writer.WriteValueSafe<float>(characterCrashVolume, default(FastBufferWriter.ForPrimitives));
			bool flag3 = playOneShots != null;
			writer.WriteValueSafe<bool>(flag3, default(FastBufferWriter.ForPrimitives));
			if (flag3)
			{
				writer.WriteValueSafe<bool>(playOneShots, default(FastBufferWriter.ForPrimitives));
			}
			base.__endSendClientRpc(ref writer, 2016312021U, rpcParams, RpcDelivery.Reliable);
		}
		if (this.__rpc_exec_stage != NetworkBehaviour.__RpcExecStage.Execute || (!networkManager.IsClient && !networkManager.IsHost))
		{
			return;
		}
		this.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
		if (senderClientId == base.NetworkManager.LocalClientId)
		{
			return;
		}
		MultiTransformSyncLiteCleaned multiTransformSyncLiteCleaned;
		if (!MultiTransformSyncLiteCleaned.objectMap.TryGetValue(senderClientId, out multiTransformSyncLiteCleaned))
		{
			return;
		}
		int num = Mathf.Min(positions.Length, multiTransformSyncLiteCleaned.stateBuffers.Length);
		MultiTransformSyncLiteCleaned.TransformState transformState;
		for (int i = 0; i < num; i++)
		{
			if (multiTransformSyncLiteCleaned.remoteTimeOffsets[i] == -3.4028235E+38f)
			{
				multiTransformSyncLiteCleaned.remoteTimeOffsets[i] = Time.realtimeSinceStartup - timestamp;
			}
			float timestamp2 = timestamp + multiTransformSyncLiteCleaned.remoteTimeOffsets[i];
			transformState = new MultiTransformSyncLiteCleaned.TransformState
			{
				position = positions[i],
				rotation = rotations[i],
				timestamp = timestamp2,
				rollingVolume = 0f,
				rollingPitch = 0f,
				grindVolume = 0f,
				grindPitch = 0f,
				scooterCrashVolume = 0f,
				characterCrashVolume = 0f,
				playOneShots = null
			};
			MultiTransformSyncLiteCleaned.TransformState item = transformState;
			Queue<MultiTransformSyncLiteCleaned.TransformState> queue = multiTransformSyncLiteCleaned.stateBuffers[i];
			if (queue.Count >= 240)
			{
				queue.Dequeue();
			}
			queue.Enqueue(item);
		}
		transformState = new MultiTransformSyncLiteCleaned.TransformState
		{
			position = Vector3.zero,
			rotation = Quaternion.identity,
			timestamp = timestamp + ((multiTransformSyncLiteCleaned.remoteTimeOffsets.Length != 0) ? multiTransformSyncLiteCleaned.remoteTimeOffsets[0] : 0f),
			rollingVolume = rollingVolume,
			rollingPitch = rollingPitch,
			grindVolume = grindVolume,
			grindPitch = grindPitch,
			scooterCrashVolume = scooterCrashVolume,
			characterCrashVolume = characterCrashVolume,
			playOneShots = playOneShots
		};
		MultiTransformSyncLiteCleaned.TransformState item2 = transformState;
		multiTransformSyncLiteCleaned.soundBuffer.Enqueue(item2);
		if (multiTransformSyncLiteCleaned.soundBuffer.Count > 240)
		{
			multiTransformSyncLiteCleaned.soundBuffer.Dequeue();
		}
	}

	// Token: 0x060001B8 RID: 440 RVA: 0x0000ED30 File Offset: 0x0000CF30
	private void SnapToLatest()
	{
		foreach (KeyValuePair<ulong, MultiTransformSyncLiteCleaned> keyValuePair in MultiTransformSyncLiteCleaned.objectMap)
		{
			MultiTransformSyncLiteCleaned value = keyValuePair.Value;
			for (int i = 0; i < value.objectsToSync.Length; i++)
			{
				MultiTransformSyncLiteCleaned.SyncTarget syncTarget = value.objectsToSync[i];
				Queue<MultiTransformSyncLiteCleaned.TransformState> queue = value.stateBuffers[i];
				if (!(syncTarget.target == null) && queue.Count != 0)
				{
					MultiTransformSyncLiteCleaned.TransformState s = queue.Peek();
					this.ApplyState(syncTarget, s);
				}
			}
		}
	}

	// Token: 0x060001B9 RID: 441 RVA: 0x0000EDD8 File Offset: 0x0000CFD8
	private void ApplyState(MultiTransformSyncLiteCleaned.SyncTarget t, MultiTransformSyncLiteCleaned.TransformState s)
	{
		if (t.syncPosition)
		{
			if (t.useLocal)
			{
				t.target.localPosition = s.position;
			}
			else
			{
				t.target.position = s.position;
			}
		}
		if (t.syncRotation)
		{
			if (t.useLocal)
			{
				t.target.localRotation = s.rotation;
				return;
			}
			t.target.rotation = s.rotation;
		}
	}

	// Token: 0x060001BA RID: 442 RVA: 0x0000EE4C File Offset: 0x0000D04C
	private void ApplyInterpolated(MultiTransformSyncLiteCleaned.SyncTarget t, Vector3 p, Quaternion r)
	{
		if (t.syncPosition)
		{
			if (t.useLocal)
			{
				t.target.localPosition = p;
			}
			else
			{
				t.target.position = p;
			}
		}
		if (t.syncRotation)
		{
			if (t.useLocal)
			{
				t.target.localRotation = r;
				return;
			}
			t.target.rotation = r;
		}
	}

	// Token: 0x060001BD RID: 445 RVA: 0x0000EEEC File Offset: 0x0000D0EC
	protected override void __initializeVariables()
	{
		base.__initializeVariables();
	}

	// Token: 0x060001BE RID: 446 RVA: 0x0000EF04 File Offset: 0x0000D104
	protected override void __initializeRpcs()
	{
		base.__registerRpc(2909828867U, new NetworkBehaviour.RpcReceiveHandler(MultiTransformSyncLiteCleaned.__rpc_handler_2909828867), "SendStateServerRpc");
		base.__registerRpc(2016312021U, new NetworkBehaviour.RpcReceiveHandler(MultiTransformSyncLiteCleaned.__rpc_handler_2016312021), "BroadcastStateClientRpc");
		base.__initializeRpcs();
	}

	// Token: 0x060001BF RID: 447 RVA: 0x0000EF54 File Offset: 0x0000D154
	private static void __rpc_handler_2909828867(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
	{
		NetworkManager networkManager = target.NetworkManager;
		if (networkManager == null || !networkManager.IsListening)
		{
			return;
		}
		bool flag;
		reader.ReadValueSafe<bool>(out flag, default(FastBufferWriter.ForPrimitives));
		Vector3[] positions = null;
		if (flag)
		{
			reader.ReadValueSafe(out positions);
		}
		bool flag2;
		reader.ReadValueSafe<bool>(out flag2, default(FastBufferWriter.ForPrimitives));
		Quaternion[] rotations = null;
		if (flag2)
		{
			reader.ReadValueSafe(out rotations);
		}
		float timestamp;
		reader.ReadValueSafe<float>(out timestamp, default(FastBufferWriter.ForPrimitives));
		float rollingVolume;
		reader.ReadValueSafe<float>(out rollingVolume, default(FastBufferWriter.ForPrimitives));
		float rollingPitch;
		reader.ReadValueSafe<float>(out rollingPitch, default(FastBufferWriter.ForPrimitives));
		float grindVolume;
		reader.ReadValueSafe<float>(out grindVolume, default(FastBufferWriter.ForPrimitives));
		float grindPitch;
		reader.ReadValueSafe<float>(out grindPitch, default(FastBufferWriter.ForPrimitives));
		float scooterCrashVolume;
		reader.ReadValueSafe<float>(out scooterCrashVolume, default(FastBufferWriter.ForPrimitives));
		float characterCrashVolume;
		reader.ReadValueSafe<float>(out characterCrashVolume, default(FastBufferWriter.ForPrimitives));
		bool flag3;
		reader.ReadValueSafe<bool>(out flag3, default(FastBufferWriter.ForPrimitives));
		bool[] playOneShots = null;
		if (flag3)
		{
			reader.ReadValueSafe<bool>(out playOneShots, default(FastBufferWriter.ForPrimitives));
		}
		ServerRpcParams server = rpcParams.Server;
		target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Execute;
		((MultiTransformSyncLiteCleaned)target).SendStateServerRpc(positions, rotations, timestamp, rollingVolume, rollingPitch, grindVolume, grindPitch, scooterCrashVolume, characterCrashVolume, playOneShots, server);
		target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
	}

	// Token: 0x060001C0 RID: 448 RVA: 0x0000F14C File Offset: 0x0000D34C
	private static void __rpc_handler_2016312021(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
	{
		NetworkManager networkManager = target.NetworkManager;
		if (networkManager == null || !networkManager.IsListening)
		{
			return;
		}
		ulong senderClientId;
		ByteUnpacker.ReadValueBitPacked(reader, out senderClientId);
		bool flag;
		reader.ReadValueSafe<bool>(out flag, default(FastBufferWriter.ForPrimitives));
		Vector3[] positions = null;
		if (flag)
		{
			reader.ReadValueSafe(out positions);
		}
		bool flag2;
		reader.ReadValueSafe<bool>(out flag2, default(FastBufferWriter.ForPrimitives));
		Quaternion[] rotations = null;
		if (flag2)
		{
			reader.ReadValueSafe(out rotations);
		}
		float timestamp;
		reader.ReadValueSafe<float>(out timestamp, default(FastBufferWriter.ForPrimitives));
		float rollingVolume;
		reader.ReadValueSafe<float>(out rollingVolume, default(FastBufferWriter.ForPrimitives));
		float rollingPitch;
		reader.ReadValueSafe<float>(out rollingPitch, default(FastBufferWriter.ForPrimitives));
		float grindVolume;
		reader.ReadValueSafe<float>(out grindVolume, default(FastBufferWriter.ForPrimitives));
		float grindPitch;
		reader.ReadValueSafe<float>(out grindPitch, default(FastBufferWriter.ForPrimitives));
		float scooterCrashVolume;
		reader.ReadValueSafe<float>(out scooterCrashVolume, default(FastBufferWriter.ForPrimitives));
		float characterCrashVolume;
		reader.ReadValueSafe<float>(out characterCrashVolume, default(FastBufferWriter.ForPrimitives));
		bool flag3;
		reader.ReadValueSafe<bool>(out flag3, default(FastBufferWriter.ForPrimitives));
		bool[] playOneShots = null;
		if (flag3)
		{
			reader.ReadValueSafe<bool>(out playOneShots, default(FastBufferWriter.ForPrimitives));
		}
		ClientRpcParams client = rpcParams.Client;
		target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Execute;
		((MultiTransformSyncLiteCleaned)target).BroadcastStateClientRpc(senderClientId, positions, rotations, timestamp, rollingVolume, rollingPitch, grindVolume, grindPitch, scooterCrashVolume, characterCrashVolume, playOneShots, client);
		target.__rpc_exec_stage = NetworkBehaviour.__RpcExecStage.Send;
	}

	// Token: 0x060001C1 RID: 449 RVA: 0x0000F354 File Offset: 0x0000D554
	protected internal override string __getTypeName()
	{
		return "MultiTransformSyncLiteCleaned";
	}

	// Token: 0x040001EF RID: 495
	public MultiTransformSyncLiteCleaned.SyncTarget[] objectsToSync;

	// Token: 0x040001F0 RID: 496
	public float sendRate = 30f;

	// Token: 0x040001F1 RID: 497
	public float interpolationBackTime = 0.1f;

	// Token: 0x040001F2 RID: 498
	public float snapInterval = 15f;

	// Token: 0x040001F3 RID: 499
	private float sendTimer;

	// Token: 0x040001F4 RID: 500
	private float snapTimer;

	// Token: 0x040001F5 RID: 501
	private Queue<MultiTransformSyncLiteCleaned.TransformState>[] stateBuffers;

	// Token: 0x040001F6 RID: 502
	private float[] remoteTimeOffsets;

	// Token: 0x040001F7 RID: 503
	private Queue<MultiTransformSyncLiteCleaned.TransformState> soundBuffer = new Queue<MultiTransformSyncLiteCleaned.TransformState>();

	// Token: 0x040001F8 RID: 504
	private static Dictionary<ulong, MultiTransformSyncLiteCleaned> objectMap = new Dictionary<ulong, MultiTransformSyncLiteCleaned>();

	// Token: 0x040001F9 RID: 505
	public AudioSource rollingSound;

	// Token: 0x040001FA RID: 506
	public AudioSource grindSound;

	// Token: 0x040001FB RID: 507
	public AudioSource ScooterCrashSlide;

	// Token: 0x040001FC RID: 508
	public AudioSource CharacterCrashSlide;

	// Token: 0x040001FD RID: 509
	public AudioSource[] oneShotSounds;

	// Token: 0x040001FE RID: 510
	private bool prevOneShotPlaying;

	// Token: 0x040001FF RID: 511
	private float[] lastPlayTimestamps;

	// Token: 0x0200006E RID: 110
	[Serializable]
	public class SyncTarget
	{
		// Token: 0x04000200 RID: 512
		public Transform target;

		// Token: 0x04000201 RID: 513
		public bool syncPosition = true;

		// Token: 0x04000202 RID: 514
		public bool syncRotation = true;

		// Token: 0x04000203 RID: 515
		public bool useLocal = true;
	}

	// Token: 0x0200006F RID: 111
	private struct TransformState
	{
		// Token: 0x04000204 RID: 516
		public Vector3 position;

		// Token: 0x04000205 RID: 517
		public Quaternion rotation;

		// Token: 0x04000206 RID: 518
		public float timestamp;

		// Token: 0x04000207 RID: 519
		public float rollingVolume;

		// Token: 0x04000208 RID: 520
		public float rollingPitch;

		// Token: 0x04000209 RID: 521
		public float grindVolume;

		// Token: 0x0400020A RID: 522
		public float grindPitch;

		// Token: 0x0400020B RID: 523
		public float scooterCrashVolume;

		// Token: 0x0400020C RID: 524
		public float characterCrashVolume;

		// Token: 0x0400020D RID: 525
		public bool[] playOneShots;
	}
}
