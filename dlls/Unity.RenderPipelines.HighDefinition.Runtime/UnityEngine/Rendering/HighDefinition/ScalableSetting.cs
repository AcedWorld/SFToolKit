using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001BA RID: 442
	[Serializable]
	public class ScalableSetting<T> : ISerializationCallbackReceiver
	{
		// Token: 0x06000DA7 RID: 3495 RVA: 0x0006EE65 File Offset: 0x0006D065
		public ScalableSetting(T[] values, ScalableSettingSchemaId schemaId)
		{
			this.m_Values = values;
			this.m_SchemaId = schemaId;
		}

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x06000DA8 RID: 3496 RVA: 0x0006EE7B File Offset: 0x0006D07B
		// (set) Token: 0x06000DA9 RID: 3497 RVA: 0x0006EE83 File Offset: 0x0006D083
		public ScalableSettingSchemaId schemaId
		{
			get
			{
				return this.m_SchemaId;
			}
			set
			{
				this.m_SchemaId = value;
			}
		}

		// Token: 0x17000231 RID: 561
		public T this[int index]
		{
			get
			{
				if (this.m_Values == null || index < 0 || index >= this.m_Values.Length)
				{
					return default(T);
				}
				return this.m_Values[index];
			}
		}

		// Token: 0x06000DAB RID: 3499 RVA: 0x0006EEC6 File Offset: 0x0006D0C6
		public bool TryGet(int index, out T value)
		{
			if (index >= 0 && index < this.m_Values.Length)
			{
				value = this.m_Values[index];
				return true;
			}
			value = default(T);
			return false;
		}

		// Token: 0x06000DAC RID: 3500 RVA: 0x0006EEF4 File Offset: 0x0006D0F4
		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			ScalableSettingSchema scalableSettingSchema;
			if (ScalableSettingSchema.Schemas.TryGetValue(this.m_SchemaId, out scalableSettingSchema))
			{
				Array.Resize<T>(ref this.m_Values, scalableSettingSchema.levelCount);
				return;
			}
			if (this.m_Values == null)
			{
				this.m_Values = new T[0];
			}
		}

		// Token: 0x06000DAD RID: 3501 RVA: 0x0006EF3C File Offset: 0x0006D13C
		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			ScalableSettingSchema scalableSettingSchema;
			if (ScalableSettingSchema.Schemas.TryGetValue(this.m_SchemaId, out scalableSettingSchema))
			{
				Array.Resize<T>(ref this.m_Values, scalableSettingSchema.levelCount);
				return;
			}
			if (this.m_Values == null)
			{
				this.m_Values = new T[0];
			}
		}

		// Token: 0x04001590 RID: 5520
		[SerializeField]
		private T[] m_Values;

		// Token: 0x04001591 RID: 5521
		[SerializeField]
		private ScalableSettingSchemaId m_SchemaId;
	}
}
