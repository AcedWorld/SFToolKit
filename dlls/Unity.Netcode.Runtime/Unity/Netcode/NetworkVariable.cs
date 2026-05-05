using System;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x020000B6 RID: 182
	[GenerateSerializationForGenericParameter(0)]
	[Serializable]
	public class NetworkVariable<T> : NetworkVariableBase
	{
		// Token: 0x06000423 RID: 1059 RVA: 0x00013DAA File Offset: 0x00011FAA
		public override bool ExceedsDirtinessThreshold()
		{
			return this.CheckExceedsDirtinessThreshold == null || !this.m_HasPreviousValue || this.CheckExceedsDirtinessThreshold(this.m_PreviousValue, this.m_InternalValue);
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x00013DD5 File Offset: 0x00011FD5
		public override void OnInitialize()
		{
			base.OnInitialize();
			this.m_HasPreviousValue = true;
			NetworkVariableSerialization<T>.Duplicate(this.m_InternalValue, ref this.m_InternalOriginalValue);
			NetworkVariableSerialization<T>.Duplicate(this.m_InternalValue, ref this.m_PreviousValue);
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x00013E06 File Offset: 0x00012006
		public NetworkVariable(T value = default(T), NetworkVariableReadPermission readPerm = NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission writePerm = NetworkVariableWritePermission.Server) : base(readPerm, writePerm)
		{
			this.m_InternalValue = value;
			this.m_InternalOriginalValue = default(T);
			this.m_PreviousValue = default(T);
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x00013E30 File Offset: 0x00012030
		public void Reset(T value = default(T))
		{
			if (this.m_NetworkBehaviour == null || (this.m_NetworkBehaviour != null && !this.m_NetworkBehaviour.NetworkObject.IsSpawned))
			{
				this.m_InternalValue = value;
				NetworkVariableSerialization<T>.Duplicate(this.m_InternalValue, ref this.m_InternalOriginalValue);
				this.m_PreviousValue = default(T);
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000427 RID: 1063 RVA: 0x00013E8F File Offset: 0x0001208F
		// (set) Token: 0x06000428 RID: 1064 RVA: 0x00013E98 File Offset: 0x00012098
		public virtual T Value
		{
			get
			{
				return this.m_InternalValue;
			}
			set
			{
				if (base.m_NetworkManager && !base.CanClientWrite(base.m_NetworkManager.LocalClientId))
				{
					base.LogWritePermissionError();
					return;
				}
				if (!NetworkVariableSerialization<T>.AreEqual(ref this.m_InternalValue, ref value))
				{
					T internalValue = this.m_InternalValue;
					this.m_InternalValue = value;
					NetworkVariableSerialization<T>.Duplicate(this.m_InternalValue, ref this.m_InternalOriginalValue);
					this.SetDirty(true);
					this.m_IsDisposed = false;
					NetworkVariable<T>.OnValueChangedDelegate onValueChanged = this.OnValueChanged;
					if (onValueChanged == null)
					{
						return;
					}
					onValueChanged(internalValue, this.m_InternalValue);
				}
			}
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x00013F24 File Offset: 0x00012124
		public bool CheckDirtyState(bool forceCheck = false)
		{
			bool flag = base.IsDirty();
			if (base.m_NetworkManager && !base.CanClientWrite(base.m_NetworkManager.LocalClientId))
			{
				if (!NetworkVariableSerialization<T>.AreEqual(ref this.m_InternalValue, ref this.m_InternalOriginalValue))
				{
					NetworkVariableSerialization<T>.Duplicate(this.m_InternalOriginalValue, ref this.m_InternalValue);
				}
				return false;
			}
			if ((!flag || forceCheck) && !NetworkVariableSerialization<T>.AreEqual(ref this.m_PreviousValue, ref this.m_InternalValue))
			{
				this.SetDirty(true);
				NetworkVariable<T>.OnValueChangedDelegate onValueChanged = this.OnValueChanged;
				if (onValueChanged != null)
				{
					onValueChanged(this.m_PreviousValue, this.m_InternalValue);
				}
				this.m_IsDisposed = false;
				flag = true;
			}
			return flag;
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x00013FD1 File Offset: 0x000121D1
		internal ref T RefValue()
		{
			return ref this.m_InternalValue;
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x00013FDC File Offset: 0x000121DC
		public override void Dispose()
		{
			if (this.m_IsDisposed)
			{
				return;
			}
			this.m_IsDisposed = true;
			IDisposable disposable = this.m_InternalValue as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
			this.m_InternalValue = default(T);
			IDisposable disposable2 = this.m_InternalOriginalValue as IDisposable;
			if (disposable2 != null)
			{
				disposable2.Dispose();
			}
			this.m_InternalOriginalValue = default(T);
			if (this.m_HasPreviousValue)
			{
				IDisposable disposable3 = this.m_PreviousValue as IDisposable;
				if (disposable3 != null)
				{
					this.m_HasPreviousValue = false;
					disposable3.Dispose();
				}
			}
			this.m_PreviousValue = default(T);
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x0001407C File Offset: 0x0001227C
		~NetworkVariable()
		{
			this.Dispose();
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x000140A8 File Offset: 0x000122A8
		public override bool IsDirty()
		{
			if (!this.NetworkUpdaterCheck && base.m_NetworkManager && !base.CanClientWrite(base.m_NetworkManager.LocalClientId) && !NetworkVariableSerialization<T>.AreEqual(ref this.m_InternalValue, ref this.m_InternalOriginalValue))
			{
				NetworkVariableSerialization<T>.Duplicate(this.m_InternalOriginalValue, ref this.m_InternalValue);
				return true;
			}
			if (base.IsDirty())
			{
				return true;
			}
			bool flag = !NetworkVariableSerialization<T>.AreEqual(ref this.m_PreviousValue, ref this.m_InternalValue);
			this.SetDirty(flag);
			return flag;
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x00014134 File Offset: 0x00012334
		public override void ResetDirty()
		{
			if (this.IsDirty())
			{
				this.m_HasPreviousValue = true;
				NetworkVariableSerialization<T>.Duplicate(this.m_InternalValue, ref this.m_PreviousValue);
				NetworkVariableSerialization<T>.Duplicate(this.m_InternalValue, ref this.m_InternalOriginalValue);
			}
			base.ResetDirty();
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x0001416D File Offset: 0x0001236D
		private protected void Set(T value)
		{
			this.SetDirty(true);
			this.m_InternalValue = value;
			NetworkVariable<T>.OnValueChangedDelegate onValueChanged = this.OnValueChanged;
			if (onValueChanged == null)
			{
				return;
			}
			onValueChanged(this.m_PreviousValue, this.m_InternalValue);
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x00014199 File Offset: 0x00012399
		public override void WriteDelta(FastBufferWriter writer)
		{
			NetworkVariableSerialization<T>.WriteDelta(writer, ref this.m_InternalValue, ref this.m_PreviousValue);
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x000141B0 File Offset: 0x000123B0
		public override void ReadDelta(FastBufferReader reader, bool keepDirtyDelta)
		{
			if (base.m_NetworkManager && !base.CanClientWrite(base.m_NetworkManager.LocalClientId) && !NetworkVariableSerialization<T>.AreEqual(ref this.m_InternalOriginalValue, ref this.m_InternalValue))
			{
				NetworkVariableSerialization<T>.Duplicate(this.m_InternalOriginalValue, ref this.m_InternalValue);
			}
			NetworkVariableSerialization<T>.ReadDelta(reader, ref this.m_InternalValue);
			if (keepDirtyDelta)
			{
				this.SetDirty(true);
			}
			NetworkVariable<T>.OnValueChangedDelegate onValueChanged = this.OnValueChanged;
			if (onValueChanged == null)
			{
				return;
			}
			onValueChanged(this.m_PreviousValue, this.m_InternalValue);
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x00014238 File Offset: 0x00012438
		internal override void PostDeltaRead()
		{
			this.m_HasPreviousValue = true;
			NetworkVariableSerialization<T>.Duplicate(this.m_InternalValue, ref this.m_PreviousValue);
			NetworkVariableSerialization<T>.Duplicate(this.m_InternalValue, ref this.m_InternalOriginalValue);
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x00014264 File Offset: 0x00012464
		public override void ReadField(FastBufferReader reader)
		{
			if (base.m_NetworkManager && !base.CanClientWrite(base.m_NetworkManager.LocalClientId) && !NetworkVariableSerialization<T>.AreEqual(ref this.m_InternalOriginalValue, ref this.m_InternalValue))
			{
				NetworkVariableSerialization<T>.Duplicate(this.m_InternalOriginalValue, ref this.m_InternalValue);
			}
			NetworkVariableSerialization<T>.Read(reader, ref this.m_InternalValue);
			this.m_HasPreviousValue = true;
			NetworkVariableSerialization<T>.Duplicate(this.m_InternalValue, ref this.m_PreviousValue);
			NetworkVariableSerialization<T>.Duplicate(this.m_InternalValue, ref this.m_InternalOriginalValue);
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x000142EF File Offset: 0x000124EF
		public override void WriteField(FastBufferWriter writer)
		{
			NetworkVariableSerialization<T>.Write(writer, ref this.m_InternalValue);
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x000142FD File Offset: 0x000124FD
		internal override void WriteFieldSynchronization(FastBufferWriter writer)
		{
			if (base.IsDirty() && this.m_HasPreviousValue)
			{
				NetworkVariableSerialization<T>.Write(writer, ref this.m_PreviousValue);
				return;
			}
			base.WriteFieldSynchronization(writer);
		}

		// Token: 0x0400024A RID: 586
		public NetworkVariable<T>.OnValueChangedDelegate OnValueChanged;

		// Token: 0x0400024B RID: 587
		public NetworkVariable<T>.CheckExceedsDirtinessThresholdDelegate CheckExceedsDirtinessThreshold;

		// Token: 0x0400024C RID: 588
		[SerializeField]
		private protected T m_InternalValue;

		// Token: 0x0400024D RID: 589
		private protected T m_InternalOriginalValue;

		// Token: 0x0400024E RID: 590
		private protected T m_PreviousValue;

		// Token: 0x0400024F RID: 591
		private bool m_HasPreviousValue;

		// Token: 0x04000250 RID: 592
		private bool m_IsDisposed;

		// Token: 0x020000B7 RID: 183
		// (Invoke) Token: 0x06000437 RID: 1079
		public delegate void OnValueChangedDelegate(T previousValue, T newValue);

		// Token: 0x020000B8 RID: 184
		// (Invoke) Token: 0x0600043B RID: 1083
		public delegate bool CheckExceedsDirtinessThresholdDelegate(in T previousValue, in T newValue);
	}
}
