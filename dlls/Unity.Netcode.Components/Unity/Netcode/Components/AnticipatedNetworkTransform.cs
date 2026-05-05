using System;
using Unity.Mathematics;
using UnityEngine;

namespace Unity.Netcode.Components
{
	// Token: 0x0200000B RID: 11
	[DisallowMultipleComponent]
	[AddComponentMenu("Netcode/Anticipated Network Transform")]
	[DefaultExecutionOrder(100000)]
	public class AnticipatedNetworkTransform : NetworkTransform
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000020 RID: 32 RVA: 0x000029B4 File Offset: 0x00000BB4
		public AnticipatedNetworkTransform.TransformState AuthoritativeState
		{
			get
			{
				return this.m_AuthoritativeTransform;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000021 RID: 33 RVA: 0x000029BC File Offset: 0x00000BBC
		public AnticipatedNetworkTransform.TransformState AnticipatedState
		{
			get
			{
				return this.m_AnticipatedTransform;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000022 RID: 34 RVA: 0x000029C4 File Offset: 0x00000BC4
		// (set) Token: 0x06000023 RID: 35 RVA: 0x000029CC File Offset: 0x00000BCC
		public bool ShouldReanticipate { get; private set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000024 RID: 36 RVA: 0x000029D5 File Offset: 0x00000BD5
		public AnticipatedNetworkTransform.TransformState PreviousAnticipatedState
		{
			get
			{
				return this.m_PreviousAnticipatedTransform;
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000029E0 File Offset: 0x00000BE0
		public void AnticipateMove(Vector3 newPosition)
		{
			if (base.NetworkManager.ShutdownInProgress || !base.NetworkManager.IsListening)
			{
				return;
			}
			base.transform.position = newPosition;
			this.m_AnticipatedTransform.Position = newPosition;
			if (base.CanCommitToTransform)
			{
				this.m_AuthoritativeTransform.Position = newPosition;
			}
			this.m_PreviousAnticipatedTransform = this.m_AnticipatedTransform;
			this.m_LastAnticipaionCounter = base.NetworkManager.AnticipationSystem.AnticipationCounter;
			this.m_LastAnticipationTime = base.NetworkManager.LocalTime.Time;
			this.m_SmoothDuration = 0f;
			this.m_CurrentSmoothTime = 0f;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002A88 File Offset: 0x00000C88
		public void AnticipateRotate(Quaternion newRotation)
		{
			if (base.NetworkManager.ShutdownInProgress || !base.NetworkManager.IsListening)
			{
				return;
			}
			base.transform.rotation = newRotation;
			this.m_AnticipatedTransform.Rotation = newRotation;
			if (base.CanCommitToTransform)
			{
				this.m_AuthoritativeTransform.Rotation = newRotation;
			}
			this.m_PreviousAnticipatedTransform = this.m_AnticipatedTransform;
			this.m_LastAnticipaionCounter = base.NetworkManager.AnticipationSystem.AnticipationCounter;
			this.m_LastAnticipationTime = base.NetworkManager.LocalTime.Time;
			this.m_SmoothDuration = 0f;
			this.m_CurrentSmoothTime = 0f;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002B30 File Offset: 0x00000D30
		public void AnticipateScale(Vector3 newScale)
		{
			if (base.NetworkManager.ShutdownInProgress || !base.NetworkManager.IsListening)
			{
				return;
			}
			base.transform.localScale = newScale;
			this.m_AnticipatedTransform.Scale = newScale;
			if (base.CanCommitToTransform)
			{
				this.m_AuthoritativeTransform.Scale = newScale;
			}
			this.m_PreviousAnticipatedTransform = this.m_AnticipatedTransform;
			this.m_LastAnticipaionCounter = base.NetworkManager.AnticipationSystem.AnticipationCounter;
			this.m_LastAnticipationTime = base.NetworkManager.LocalTime.Time;
			this.m_SmoothDuration = 0f;
			this.m_CurrentSmoothTime = 0f;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002BD8 File Offset: 0x00000DD8
		public void AnticipateState(AnticipatedNetworkTransform.TransformState newState)
		{
			if (base.NetworkManager.ShutdownInProgress || !base.NetworkManager.IsListening)
			{
				return;
			}
			Transform transform = base.transform;
			transform.position = newState.Position;
			transform.rotation = newState.Rotation;
			transform.localScale = newState.Scale;
			this.m_AnticipatedTransform = newState;
			if (base.CanCommitToTransform)
			{
				this.m_AuthoritativeTransform = newState;
			}
			this.m_PreviousAnticipatedTransform = this.m_AnticipatedTransform;
			this.m_LastAnticipaionCounter = base.NetworkManager.AnticipationSystem.AnticipationCounter;
			this.m_LastAnticipationTime = base.NetworkManager.LocalTime.Time;
			this.m_SmoothDuration = 0f;
			this.m_CurrentSmoothTime = 0f;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002C90 File Offset: 0x00000E90
		protected override void Update()
		{
			if (!base.IsSpawned)
			{
				return;
			}
			if (this.m_CurrentSmoothTime < this.m_SmoothDuration)
			{
				this.m_CurrentSmoothTime += base.NetworkManager.RealTimeProvider.DeltaTime;
				Transform transform = base.transform;
				float t = math.min(this.m_CurrentSmoothTime / this.m_SmoothDuration, 1f);
				this.m_AnticipatedTransform = new AnticipatedNetworkTransform.TransformState
				{
					Position = Vector3.Lerp(this.m_SmoothFrom.Position, this.m_SmoothTo.Position, t),
					Rotation = Quaternion.Slerp(this.m_SmoothFrom.Rotation, this.m_SmoothTo.Rotation, t),
					Scale = Vector3.Lerp(this.m_SmoothFrom.Scale, this.m_SmoothTo.Scale, t)
				};
				this.m_PreviousAnticipatedTransform = this.m_AnticipatedTransform;
				if (!base.CanCommitToTransform)
				{
					transform.position = this.m_AnticipatedTransform.Position;
					transform.localScale = this.m_AnticipatedTransform.Scale;
					transform.rotation = this.m_AnticipatedTransform.Rotation;
				}
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002DB4 File Offset: 0x00000FB4
		private void ResetAnticipatedState()
		{
			Transform transform = base.transform;
			this.m_AuthoritativeTransform = new AnticipatedNetworkTransform.TransformState
			{
				Position = transform.position,
				Rotation = transform.rotation,
				Scale = transform.localScale
			};
			this.m_AnticipatedTransform = this.m_AuthoritativeTransform;
			this.m_PreviousAnticipatedTransform = this.m_AnticipatedTransform;
			this.m_SmoothDuration = 0f;
			this.m_CurrentSmoothTime = 0f;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002E2C File Offset: 0x0000102C
		protected override void OnSynchronize<T>(ref BufferSerializer<T> serializer)
		{
			base.OnSynchronize<T>(ref serializer);
			if (!base.CanCommitToTransform)
			{
				this.m_OutstandingAuthorityChange = true;
				base.ApplyAuthoritativeState();
				this.ResetAnticipatedState();
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002E50 File Offset: 0x00001050
		public override void OnNetworkSpawn()
		{
			base.OnNetworkSpawn();
			this.m_OutstandingAuthorityChange = true;
			base.ApplyAuthoritativeState();
			this.ResetAnticipatedState();
			this.m_AnticipatedObject = new AnticipatedNetworkTransform.AnticipatedObject
			{
				Transform = this
			};
			base.NetworkManager.AnticipationSystem.RegisterForAnticipationEvents(this.m_AnticipatedObject);
			base.NetworkManager.AnticipationSystem.AllAnticipatedObjects.Add(this.m_AnticipatedObject);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002EBC File Offset: 0x000010BC
		public override void OnNetworkDespawn()
		{
			if (this.m_AnticipatedObject != null)
			{
				base.NetworkManager.AnticipationSystem.DeregisterForAnticipationEvents(this.m_AnticipatedObject);
				base.NetworkManager.AnticipationSystem.AllAnticipatedObjects.Remove(this.m_AnticipatedObject);
				base.NetworkManager.AnticipationSystem.ObjectsToReanticipate.Remove(this.m_AnticipatedObject);
				this.m_AnticipatedObject = null;
			}
			this.ResetAnticipatedState();
			base.OnNetworkDespawn();
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002F34 File Offset: 0x00001134
		public override void OnDestroy()
		{
			if (this.m_AnticipatedObject != null)
			{
				base.NetworkManager.AnticipationSystem.DeregisterForAnticipationEvents(this.m_AnticipatedObject);
				base.NetworkManager.AnticipationSystem.AllAnticipatedObjects.Remove(this.m_AnticipatedObject);
				base.NetworkManager.AnticipationSystem.ObjectsToReanticipate.Remove(this.m_AnticipatedObject);
				this.m_AnticipatedObject = null;
			}
			base.OnDestroy();
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002FA4 File Offset: 0x000011A4
		public void Smooth(AnticipatedNetworkTransform.TransformState from, AnticipatedNetworkTransform.TransformState to, float durationSeconds)
		{
			Transform transform = base.transform;
			if (durationSeconds <= 0f)
			{
				this.m_AnticipatedTransform = to;
				this.m_PreviousAnticipatedTransform = this.m_AnticipatedTransform;
				transform.position = to.Position;
				transform.rotation = to.Rotation;
				transform.localScale = to.Scale;
				this.m_SmoothDuration = 0f;
				this.m_CurrentSmoothTime = 0f;
				return;
			}
			this.m_AnticipatedTransform = from;
			this.m_PreviousAnticipatedTransform = this.m_AnticipatedTransform;
			if (!base.CanCommitToTransform)
			{
				transform.position = from.Position;
				transform.rotation = from.Rotation;
				transform.localScale = from.Scale;
			}
			this.m_SmoothFrom = from;
			this.m_SmoothTo = to;
			this.m_SmoothDuration = durationSeconds;
			this.m_CurrentSmoothTime = 0f;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x0000306D File Offset: 0x0000126D
		protected override void OnBeforeUpdateTransformState()
		{
			this.m_LastAuthorityUpdateCounter = base.NetworkManager.AnticipationSystem.LastAnticipationAck;
			this.m_OutstandingAuthorityChange = true;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x0000308C File Offset: 0x0000128C
		protected override void OnNetworkTransformStateUpdated(ref NetworkTransform.NetworkTransformState oldState, ref NetworkTransform.NetworkTransformState newState)
		{
			base.OnNetworkTransformStateUpdated(ref oldState, ref newState);
			base.ApplyAuthoritativeState();
		}

		// Token: 0x06000032 RID: 50 RVA: 0x0000309C File Offset: 0x0000129C
		protected override void OnTransformUpdated()
		{
			if (base.CanCommitToTransform || this.m_AnticipatedObject == null)
			{
				return;
			}
			Transform transform = base.transform;
			AnticipatedNetworkTransform.TransformState anticipatedTransform = this.m_AnticipatedTransform;
			this.m_AuthoritativeTransform.Position = transform.position;
			this.m_AuthoritativeTransform.Rotation = transform.rotation;
			this.m_AuthoritativeTransform.Scale = transform.localScale;
			if (!this.m_OutstandingAuthorityChange)
			{
				transform.position = anticipatedTransform.Position;
				transform.localScale = anticipatedTransform.Scale;
				transform.rotation = anticipatedTransform.Rotation;
				return;
			}
			if (this.StaleDataHandling == StaleDataHandling.Ignore && this.m_LastAnticipaionCounter > this.m_LastAuthorityUpdateCounter)
			{
				transform.position = anticipatedTransform.Position;
				transform.localScale = anticipatedTransform.Scale;
				transform.rotation = anticipatedTransform.Rotation;
				return;
			}
			this.m_SmoothDuration = 0f;
			this.m_CurrentSmoothTime = 0f;
			this.m_OutstandingAuthorityChange = false;
			this.m_AnticipatedTransform = this.m_AuthoritativeTransform;
			this.ShouldReanticipate = true;
			base.NetworkManager.AnticipationSystem.ObjectsToReanticipate.Add(this.m_AnticipatedObject);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000031C0 File Offset: 0x000013C0
		protected override void __initializeVariables()
		{
			base.__initializeVariables();
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000031D6 File Offset: 0x000013D6
		protected override void __initializeRpcs()
		{
			base.__initializeRpcs();
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000031E0 File Offset: 0x000013E0
		protected internal override string __getTypeName()
		{
			return "AnticipatedNetworkTransform";
		}

		// Token: 0x04000025 RID: 37
		private AnticipatedNetworkTransform.TransformState m_AuthoritativeTransform;

		// Token: 0x04000026 RID: 38
		private AnticipatedNetworkTransform.TransformState m_AnticipatedTransform;

		// Token: 0x04000027 RID: 39
		private AnticipatedNetworkTransform.TransformState m_PreviousAnticipatedTransform;

		// Token: 0x04000028 RID: 40
		private ulong m_LastAnticipaionCounter;

		// Token: 0x04000029 RID: 41
		private double m_LastAnticipationTime;

		// Token: 0x0400002A RID: 42
		private ulong m_LastAuthorityUpdateCounter;

		// Token: 0x0400002B RID: 43
		private AnticipatedNetworkTransform.TransformState m_SmoothFrom;

		// Token: 0x0400002C RID: 44
		private AnticipatedNetworkTransform.TransformState m_SmoothTo;

		// Token: 0x0400002D RID: 45
		private float m_SmoothDuration;

		// Token: 0x0400002E RID: 46
		private float m_CurrentSmoothTime;

		// Token: 0x0400002F RID: 47
		private bool m_OutstandingAuthorityChange;

		// Token: 0x04000030 RID: 48
		public StaleDataHandling StaleDataHandling = StaleDataHandling.Reanticipate;

		// Token: 0x04000032 RID: 50
		private AnticipatedNetworkTransform.AnticipatedObject m_AnticipatedObject;

		// Token: 0x0200000C RID: 12
		public struct TransformState
		{
			// Token: 0x04000033 RID: 51
			public Vector3 Position;

			// Token: 0x04000034 RID: 52
			public Quaternion Rotation;

			// Token: 0x04000035 RID: 53
			public Vector3 Scale;
		}

		// Token: 0x0200000D RID: 13
		internal class AnticipatedObject : IAnticipationEventReceiver, IAnticipatedObject
		{
			// Token: 0x06000037 RID: 55 RVA: 0x000031E8 File Offset: 0x000013E8
			public void SetupForRender()
			{
				if (this.Transform.CanCommitToTransform)
				{
					Transform transform = this.Transform.transform;
					this.Transform.m_AuthoritativeTransform = new AnticipatedNetworkTransform.TransformState
					{
						Position = transform.position,
						Rotation = transform.rotation,
						Scale = transform.localScale
					};
					if (this.Transform.m_CurrentSmoothTime >= this.Transform.m_SmoothDuration)
					{
						this.Transform.m_AnticipatedTransform = this.Transform.m_AuthoritativeTransform;
					}
					transform.position = this.Transform.m_AnticipatedTransform.Position;
					transform.rotation = this.Transform.m_AnticipatedTransform.Rotation;
					transform.localScale = this.Transform.m_AnticipatedTransform.Scale;
				}
			}

			// Token: 0x06000038 RID: 56 RVA: 0x000032BC File Offset: 0x000014BC
			public void SetupForUpdate()
			{
				if (this.Transform.CanCommitToTransform)
				{
					Transform transform = this.Transform.transform;
					transform.position = this.Transform.m_AuthoritativeTransform.Position;
					transform.rotation = this.Transform.m_AuthoritativeTransform.Rotation;
					transform.localScale = this.Transform.m_AuthoritativeTransform.Scale;
				}
			}

			// Token: 0x06000039 RID: 57 RVA: 0x00003322 File Offset: 0x00001522
			public void Update()
			{
			}

			// Token: 0x0600003A RID: 58 RVA: 0x00003324 File Offset: 0x00001524
			public void ResetAnticipation()
			{
				this.Transform.ShouldReanticipate = false;
			}

			// Token: 0x17000007 RID: 7
			// (get) Token: 0x0600003B RID: 59 RVA: 0x00003332 File Offset: 0x00001532
			public NetworkObject OwnerObject
			{
				get
				{
					return this.Transform.NetworkObject;
				}
			}

			// Token: 0x04000036 RID: 54
			public AnticipatedNetworkTransform Transform;
		}
	}
}
