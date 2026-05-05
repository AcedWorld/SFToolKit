using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001C0 RID: 448
	[Serializable]
	public struct ScalableSettingSchemaId : IEquatable<ScalableSettingSchemaId>
	{
		// Token: 0x06000DB7 RID: 3511 RVA: 0x0006F0B4 File Offset: 0x0006D2B4
		internal ScalableSettingSchemaId(string id)
		{
			this.m_Id = id;
		}

		// Token: 0x06000DB8 RID: 3512 RVA: 0x0006F0BD File Offset: 0x0006D2BD
		public bool Equals(ScalableSettingSchemaId other)
		{
			return this.m_Id == other.m_Id;
		}

		// Token: 0x06000DB9 RID: 3513 RVA: 0x0006F0D0 File Offset: 0x0006D2D0
		public override bool Equals(object obj)
		{
			if (obj is ScalableSettingSchemaId)
			{
				ScalableSettingSchemaId scalableSettingSchemaId = (ScalableSettingSchemaId)obj;
				return scalableSettingSchemaId.m_Id == this.m_Id;
			}
			return false;
		}

		// Token: 0x06000DBA RID: 3514 RVA: 0x0006F0FF File Offset: 0x0006D2FF
		public override int GetHashCode()
		{
			string id = this.m_Id;
			if (id == null)
			{
				return 0;
			}
			return id.GetHashCode();
		}

		// Token: 0x06000DBB RID: 3515 RVA: 0x0006F112 File Offset: 0x0006D312
		public override string ToString()
		{
			return this.m_Id;
		}

		// Token: 0x04001594 RID: 5524
		public static readonly ScalableSettingSchemaId With3Levels = new ScalableSettingSchemaId("With3Levels");

		// Token: 0x04001595 RID: 5525
		public static readonly ScalableSettingSchemaId With4Levels = new ScalableSettingSchemaId("With4Levels");

		// Token: 0x04001596 RID: 5526
		[SerializeField]
		private string m_Id;
	}
}
