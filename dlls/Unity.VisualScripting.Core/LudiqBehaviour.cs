using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000147 RID: 327
	public abstract class LudiqBehaviour : MonoBehaviour, ISerializationCallbackReceiver
	{
		// Token: 0x060008C0 RID: 2240 RVA: 0x000265D4 File Offset: 0x000247D4
		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			if (Serialization.isCustomSerializing)
			{
				return;
			}
			Serialization.isUnitySerializing = true;
			try
			{
				this.OnBeforeSerialize();
				this._data = this.Serialize(true);
				this.OnAfterSerialize();
			}
			catch (Exception arg)
			{
				Debug.LogError(string.Format("Failed to serialize behaviour.\n{0}", arg), this);
			}
			Serialization.isUnitySerializing = false;
		}

		// Token: 0x060008C1 RID: 2241 RVA: 0x00026634 File Offset: 0x00024834
		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			if (Serialization.isCustomSerializing)
			{
				return;
			}
			Serialization.isUnitySerializing = true;
			try
			{
				object obj = this;
				this.OnBeforeDeserialize();
				this._data.DeserializeInto(ref obj, true);
				this.OnAfterDeserialize();
				this._data.Clear();
			}
			catch (Exception arg)
			{
				Debug.LogError(string.Format("Failed to deserialize behaviour.\n{0}", arg), this);
			}
			Serialization.isUnitySerializing = false;
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x000266A4 File Offset: 0x000248A4
		protected virtual void OnBeforeSerialize()
		{
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x000266A6 File Offset: 0x000248A6
		protected virtual void OnAfterSerialize()
		{
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x000266A8 File Offset: 0x000248A8
		protected virtual void OnBeforeDeserialize()
		{
		}

		// Token: 0x060008C5 RID: 2245 RVA: 0x000266AA File Offset: 0x000248AA
		protected virtual void OnAfterDeserialize()
		{
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x000266AC File Offset: 0x000248AC
		protected virtual void ShowData()
		{
			SerializationData serializationData = this.Serialize(true);
			serializationData.ShowString(this.ToString());
			serializationData.Clear();
		}

		// Token: 0x060008C7 RID: 2247 RVA: 0x000266D5 File Offset: 0x000248D5
		public override string ToString()
		{
			return this.ToSafeString();
		}

		// Token: 0x04000218 RID: 536
		[SerializeField]
		[DoNotSerialize]
		protected SerializationData _data;
	}
}
