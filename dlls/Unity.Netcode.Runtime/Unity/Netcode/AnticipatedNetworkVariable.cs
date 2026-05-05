using System;
using Unity.Mathematics;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x020000AC RID: 172
	[GenerateSerializationForGenericParameter(0)]
	[Serializable]
	public class AnticipatedNetworkVariable<T> : NetworkVariableBase
	{
		// Token: 0x14000012 RID: 18
		// (add) Token: 0x060003D5 RID: 981 RVA: 0x000120AA File Offset: 0x000102AA
		// (remove) Token: 0x060003D6 RID: 982 RVA: 0x000120C8 File Offset: 0x000102C8
		public event NetworkVariable<T>.CheckExceedsDirtinessThresholdDelegate CheckExceedsDirtinessThreshold
		{
			add
			{
				NetworkVariable<T> authoritativeValue = this.m_AuthoritativeValue;
				authoritativeValue.CheckExceedsDirtinessThreshold = (NetworkVariable<T>.CheckExceedsDirtinessThresholdDelegate)Delegate.Combine(authoritativeValue.CheckExceedsDirtinessThreshold, value);
			}
			remove
			{
				NetworkVariable<T> authoritativeValue = this.m_AuthoritativeValue;
				authoritativeValue.CheckExceedsDirtinessThreshold = (NetworkVariable<T>.CheckExceedsDirtinessThresholdDelegate)Delegate.Remove(authoritativeValue.CheckExceedsDirtinessThreshold, value);
			}
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x000120E8 File Offset: 0x000102E8
		public override void OnInitialize()
		{
			this.m_AuthoritativeValue.Initialize(this.m_NetworkBehaviour);
			T value = this.m_AuthoritativeValue.Value;
			NetworkVariableSerialization<T>.Duplicate(value, ref this.m_AnticipatedValue);
			NetworkVariableSerialization<T>.Duplicate(this.m_AnticipatedValue, ref this.m_PreviousAnticipatedValue);
			if (this.m_NetworkBehaviour != null && this.m_NetworkBehaviour.NetworkManager != null && this.m_NetworkBehaviour.NetworkManager.AnticipationSystem != null)
			{
				this.m_AnticipatedObject = new AnticipatedNetworkVariable<T>.AnticipatedObject
				{
					Variable = this
				};
				this.m_NetworkBehaviour.NetworkManager.AnticipationSystem.AllAnticipatedObjects.Add(this.m_AnticipatedObject);
			}
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x00012196 File Offset: 0x00010396
		public override bool ExceedsDirtinessThreshold()
		{
			return this.m_AuthoritativeValue.ExceedsDirtinessThreshold();
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060003D9 RID: 985 RVA: 0x000121A3 File Offset: 0x000103A3
		public T Value
		{
			get
			{
				return this.m_AnticipatedValue;
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060003DA RID: 986 RVA: 0x000121AB File Offset: 0x000103AB
		// (set) Token: 0x060003DB RID: 987 RVA: 0x000121B3 File Offset: 0x000103B3
		public bool ShouldReanticipate { get; private set; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060003DC RID: 988 RVA: 0x000121BC File Offset: 0x000103BC
		public T PreviousAnticipatedValue
		{
			get
			{
				return this.m_PreviousAnticipatedValue;
			}
		}

		// Token: 0x060003DD RID: 989 RVA: 0x000121C4 File Offset: 0x000103C4
		public void Anticipate(T value)
		{
			if (this.m_NetworkBehaviour.NetworkManager.ShutdownInProgress || !this.m_NetworkBehaviour.NetworkManager.IsListening)
			{
				return;
			}
			this.m_SmoothDuration = 0f;
			this.m_CurrentSmoothTime = 0f;
			this.m_LastAnticipationCounter = this.m_NetworkBehaviour.NetworkManager.AnticipationSystem.AnticipationCounter;
			this.m_AnticipatedValue = value;
			NetworkVariableSerialization<T>.Duplicate(this.m_AnticipatedValue, ref this.m_PreviousAnticipatedValue);
			if (base.CanClientWrite(this.m_NetworkBehaviour.NetworkManager.LocalClientId))
			{
				this.AuthoritativeValue = value;
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060003DE RID: 990 RVA: 0x0001225E File Offset: 0x0001045E
		// (set) Token: 0x060003DF RID: 991 RVA: 0x0001226C File Offset: 0x0001046C
		public T AuthoritativeValue
		{
			get
			{
				return this.m_AuthoritativeValue.Value;
			}
			set
			{
				this.m_SettingAuthoritativeValue = true;
				try
				{
					this.m_AuthoritativeValue.Value = value;
					this.m_AnticipatedValue = value;
					NetworkVariableSerialization<T>.Duplicate(this.m_AnticipatedValue, ref this.m_PreviousAnticipatedValue);
				}
				finally
				{
					this.m_SettingAuthoritativeValue = false;
				}
			}
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x000122C0 File Offset: 0x000104C0
		public AnticipatedNetworkVariable(T value = default(T), StaleDataHandling staleDataHandling = StaleDataHandling.Ignore) : base(NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server)
		{
			this.StaleDataHandling = staleDataHandling;
			this.m_AuthoritativeValue = new NetworkVariable<T>(value, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server)
			{
				OnValueChanged = new NetworkVariable<T>.OnValueChangedDelegate(this.OnValueChangedInternal)
			};
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x000122F4 File Offset: 0x000104F4
		public void Update()
		{
			if (this.m_CurrentSmoothTime < this.m_SmoothDuration)
			{
				this.m_CurrentSmoothTime += this.m_NetworkBehaviour.NetworkManager.RealTimeProvider.DeltaTime;
				float amount = math.min(this.m_CurrentSmoothTime / this.m_SmoothDuration, 1f);
				this.m_AnticipatedValue = this.m_SmoothDelegate(this.m_SmoothFrom, this.m_SmoothTo, amount);
				NetworkVariableSerialization<T>.Duplicate(this.m_AnticipatedValue, ref this.m_PreviousAnticipatedValue);
			}
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x00012378 File Offset: 0x00010578
		public override void Dispose()
		{
			if (this.m_IsDisposed)
			{
				return;
			}
			if (this.m_NetworkBehaviour != null && this.m_NetworkBehaviour.NetworkManager != null && this.m_NetworkBehaviour.NetworkManager.AnticipationSystem != null && this.m_AnticipatedObject != null)
			{
				this.m_NetworkBehaviour.NetworkManager.AnticipationSystem.AllAnticipatedObjects.Remove(this.m_AnticipatedObject);
				this.m_NetworkBehaviour.NetworkManager.AnticipationSystem.ObjectsToReanticipate.Remove(this.m_AnticipatedObject);
				this.m_AnticipatedObject = null;
			}
			this.m_IsDisposed = true;
			this.m_AuthoritativeValue.Dispose();
			IDisposable disposable = this.m_AnticipatedValue as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
			this.m_AnticipatedValue = default(T);
			IDisposable disposable2 = this.m_PreviousAnticipatedValue as IDisposable;
			if (disposable2 != null)
			{
				disposable2.Dispose();
				this.m_PreviousAnticipatedValue = default(T);
			}
			if (this.m_HasSmoothValues)
			{
				IDisposable disposable3 = this.m_SmoothFrom as IDisposable;
				if (disposable3 != null)
				{
					disposable3.Dispose();
					this.m_SmoothFrom = default(T);
				}
				IDisposable disposable4 = this.m_SmoothTo as IDisposable;
				if (disposable4 != null)
				{
					disposable4.Dispose();
					this.m_SmoothTo = default(T);
				}
				this.m_HasSmoothValues = false;
			}
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x000124CC File Offset: 0x000106CC
		~AnticipatedNetworkVariable()
		{
			this.Dispose();
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x000124F8 File Offset: 0x000106F8
		private void OnValueChangedInternal(T previousValue, T newValue)
		{
			if (!this.m_SettingAuthoritativeValue)
			{
				this.m_LastAuthorityUpdateCounter = this.m_NetworkBehaviour.NetworkManager.AnticipationSystem.LastAnticipationAck;
				if (this.StaleDataHandling == StaleDataHandling.Ignore && this.m_LastAnticipationCounter > this.m_LastAuthorityUpdateCounter)
				{
					return;
				}
				this.ShouldReanticipate = true;
				this.m_NetworkBehaviour.NetworkManager.AnticipationSystem.ObjectsToReanticipate.Add(this.m_AnticipatedObject);
			}
			T authoritativeValue = this.AuthoritativeValue;
			NetworkVariableSerialization<T>.Duplicate(authoritativeValue, ref this.m_AnticipatedValue);
			this.m_SmoothDuration = 0f;
			this.m_CurrentSmoothTime = 0f;
			AnticipatedNetworkVariable<T>.OnAuthoritativeValueChangedDelegate onAuthoritativeValueChanged = this.OnAuthoritativeValueChanged;
			if (onAuthoritativeValueChanged == null)
			{
				return;
			}
			onAuthoritativeValueChanged(this, previousValue, newValue);
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x000125A8 File Offset: 0x000107A8
		public void Smooth(in T from, in T to, float durationSeconds, AnticipatedNetworkVariable<T>.SmoothDelegate how)
		{
			if (durationSeconds <= 0f)
			{
				NetworkVariableSerialization<T>.Duplicate(to, ref this.m_AnticipatedValue);
				this.m_SmoothDuration = 0f;
				this.m_CurrentSmoothTime = 0f;
				this.m_SmoothDelegate = null;
				return;
			}
			NetworkVariableSerialization<T>.Duplicate(from, ref this.m_AnticipatedValue);
			NetworkVariableSerialization<T>.Duplicate(from, ref this.m_SmoothFrom);
			NetworkVariableSerialization<T>.Duplicate(to, ref this.m_SmoothTo);
			this.m_SmoothDuration = durationSeconds;
			this.m_CurrentSmoothTime = 0f;
			this.m_SmoothDelegate = how;
			this.m_HasSmoothValues = true;
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x0001262C File Offset: 0x0001082C
		public override bool IsDirty()
		{
			return this.m_AuthoritativeValue.IsDirty();
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x00012639 File Offset: 0x00010839
		public override void ResetDirty()
		{
			this.m_AuthoritativeValue.ResetDirty();
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x00012646 File Offset: 0x00010846
		public override void WriteDelta(FastBufferWriter writer)
		{
			this.m_AuthoritativeValue.WriteDelta(writer);
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x00012654 File Offset: 0x00010854
		public override void WriteField(FastBufferWriter writer)
		{
			this.m_AuthoritativeValue.WriteField(writer);
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00012664 File Offset: 0x00010864
		public override void ReadField(FastBufferReader reader)
		{
			this.m_AuthoritativeValue.ReadField(reader);
			T value = this.m_AuthoritativeValue.Value;
			NetworkVariableSerialization<T>.Duplicate(value, ref this.m_AnticipatedValue);
			NetworkVariableSerialization<T>.Duplicate(this.m_AnticipatedValue, ref this.m_PreviousAnticipatedValue);
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x000126A7 File Offset: 0x000108A7
		public override void ReadDelta(FastBufferReader reader, bool keepDirtyDelta)
		{
			this.m_AuthoritativeValue.ReadDelta(reader, keepDirtyDelta);
		}

		// Token: 0x04000226 RID: 550
		[SerializeField]
		private NetworkVariable<T> m_AuthoritativeValue;

		// Token: 0x04000227 RID: 551
		private T m_AnticipatedValue;

		// Token: 0x04000228 RID: 552
		private T m_PreviousAnticipatedValue;

		// Token: 0x04000229 RID: 553
		private ulong m_LastAuthorityUpdateCounter;

		// Token: 0x0400022A RID: 554
		private ulong m_LastAnticipationCounter;

		// Token: 0x0400022B RID: 555
		private bool m_IsDisposed;

		// Token: 0x0400022C RID: 556
		private bool m_SettingAuthoritativeValue;

		// Token: 0x0400022D RID: 557
		private T m_SmoothFrom;

		// Token: 0x0400022E RID: 558
		private T m_SmoothTo;

		// Token: 0x0400022F RID: 559
		private float m_SmoothDuration;

		// Token: 0x04000230 RID: 560
		private float m_CurrentSmoothTime;

		// Token: 0x04000231 RID: 561
		private bool m_HasSmoothValues;

		// Token: 0x04000232 RID: 562
		public StaleDataHandling StaleDataHandling;

		// Token: 0x04000233 RID: 563
		public AnticipatedNetworkVariable<T>.OnAuthoritativeValueChangedDelegate OnAuthoritativeValueChanged;

		// Token: 0x04000234 RID: 564
		private AnticipatedNetworkVariable<T>.AnticipatedObject m_AnticipatedObject;

		// Token: 0x04000236 RID: 566
		private AnticipatedNetworkVariable<T>.SmoothDelegate m_SmoothDelegate;

		// Token: 0x020000AD RID: 173
		// (Invoke) Token: 0x060003ED RID: 1005
		public delegate void OnAuthoritativeValueChangedDelegate(AnticipatedNetworkVariable<T> variable, in T previousValue, in T newValue);

		// Token: 0x020000AE RID: 174
		private class AnticipatedObject : IAnticipatedObject
		{
			// Token: 0x060003F0 RID: 1008 RVA: 0x000126B6 File Offset: 0x000108B6
			public void Update()
			{
				this.Variable.Update();
			}

			// Token: 0x060003F1 RID: 1009 RVA: 0x000126C3 File Offset: 0x000108C3
			public void ResetAnticipation()
			{
				this.Variable.ShouldReanticipate = false;
			}

			// Token: 0x17000086 RID: 134
			// (get) Token: 0x060003F2 RID: 1010 RVA: 0x000126D1 File Offset: 0x000108D1
			public NetworkObject OwnerObject
			{
				get
				{
					return this.Variable.m_NetworkBehaviour.NetworkObject;
				}
			}

			// Token: 0x04000237 RID: 567
			public AnticipatedNetworkVariable<T> Variable;
		}

		// Token: 0x020000AF RID: 175
		// (Invoke) Token: 0x060003F5 RID: 1013
		public delegate T SmoothDelegate(T authoritativeValue, T anticipatedValue, float amount);
	}
}
