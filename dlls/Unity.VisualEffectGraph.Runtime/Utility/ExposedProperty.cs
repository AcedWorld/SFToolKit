using System;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x02000027 RID: 39
	[Serializable]
	public class ExposedProperty
	{
		// Token: 0x060000D1 RID: 209 RVA: 0x00006D32 File Offset: 0x00004F32
		public static implicit operator ExposedProperty(string name)
		{
			return new ExposedProperty(name);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00006D3A File Offset: 0x00004F3A
		public static explicit operator string(ExposedProperty parameter)
		{
			return parameter.m_Name;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00006D44 File Offset: 0x00004F44
		public static implicit operator int(ExposedProperty parameter)
		{
			if (parameter.m_Id == 0 && !string.IsNullOrEmpty(parameter.m_Name))
			{
				throw new InvalidOperationException("Unexpected constructor has been called");
			}
			if (parameter.m_Id == -1)
			{
				parameter.m_Id = Shader.PropertyToID(parameter.m_Name);
			}
			return parameter.m_Id;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00006D91 File Offset: 0x00004F91
		public static ExposedProperty operator +(ExposedProperty self, ExposedProperty other)
		{
			return new ExposedProperty(self.m_Name + other.m_Name);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00006DA9 File Offset: 0x00004FA9
		public ExposedProperty()
		{
			this.m_Id = -1;
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00006DB8 File Offset: 0x00004FB8
		private ExposedProperty(string name)
		{
			this.m_Name = name;
			this.m_Id = -1;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00006DCE File Offset: 0x00004FCE
		public override string ToString()
		{
			return this.m_Name;
		}

		// Token: 0x04000096 RID: 150
		[SerializeField]
		private string m_Name;

		// Token: 0x04000097 RID: 151
		private int m_Id;
	}
}
