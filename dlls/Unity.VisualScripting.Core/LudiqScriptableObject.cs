using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000148 RID: 328
	public abstract class LudiqScriptableObject : ScriptableObject, ISerializationCallbackReceiver
	{
		// Token: 0x14000012 RID: 18
		// (add) Token: 0x060008C9 RID: 2249 RVA: 0x000266E8 File Offset: 0x000248E8
		// (remove) Token: 0x060008CA RID: 2250 RVA: 0x00026720 File Offset: 0x00024920
		internal event Action OnDestroyActions;

		// Token: 0x060008CB RID: 2251 RVA: 0x00026758 File Offset: 0x00024958
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
				Debug.LogError(string.Format("Failed to serialize scriptable object.\n{0}", arg), this);
			}
			Serialization.isUnitySerializing = false;
		}

		// Token: 0x060008CC RID: 2252 RVA: 0x000267B8 File Offset: 0x000249B8
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
				Debug.LogError(string.Format("Failed to deserialize scriptable object.\n{0}", arg), this);
			}
			Serialization.isUnitySerializing = false;
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x00026828 File Offset: 0x00024A28
		protected virtual void OnBeforeSerialize()
		{
		}

		// Token: 0x060008CE RID: 2254 RVA: 0x0002682A File Offset: 0x00024A2A
		protected virtual void OnAfterSerialize()
		{
		}

		// Token: 0x060008CF RID: 2255 RVA: 0x0002682C File Offset: 0x00024A2C
		protected virtual void OnBeforeDeserialize()
		{
		}

		// Token: 0x060008D0 RID: 2256 RVA: 0x0002682E File Offset: 0x00024A2E
		protected virtual void OnAfterDeserialize()
		{
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x00026830 File Offset: 0x00024A30
		protected virtual void OnPostDeserializeInEditor()
		{
		}

		// Token: 0x060008D2 RID: 2258 RVA: 0x00026832 File Offset: 0x00024A32
		private void OnDestroy()
		{
			Action onDestroyActions = this.OnDestroyActions;
			if (onDestroyActions == null)
			{
				return;
			}
			onDestroyActions();
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x00026844 File Offset: 0x00024A44
		protected virtual void ShowData()
		{
			SerializationData serializationData = this.Serialize(true);
			serializationData.ShowString(this.ToString());
			serializationData.Clear();
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x0002686D File Offset: 0x00024A6D
		public override string ToString()
		{
			return this.ToSafeString();
		}

		// Token: 0x04000219 RID: 537
		[SerializeField]
		[DoNotSerialize]
		protected SerializationData _data;
	}
}
