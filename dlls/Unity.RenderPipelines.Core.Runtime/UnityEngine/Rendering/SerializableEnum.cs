using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000056 RID: 86
	[Serializable]
	public class SerializableEnum
	{
		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060002C9 RID: 713 RVA: 0x0000C67C File Offset: 0x0000A87C
		// (set) Token: 0x060002CA RID: 714 RVA: 0x0000C6B8 File Offset: 0x0000A8B8
		public Enum value
		{
			get
			{
				object obj;
				if (string.IsNullOrEmpty(this.m_EnumTypeAsString) || !Enum.TryParse(Type.GetType(this.m_EnumTypeAsString), this.m_EnumValueAsString, out obj))
				{
					return null;
				}
				return (Enum)obj;
			}
			set
			{
				this.m_EnumValueAsString = value.ToString();
			}
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0000C6C6 File Offset: 0x0000A8C6
		public SerializableEnum(Type enumType)
		{
			this.m_EnumTypeAsString = enumType.AssemblyQualifiedName;
			this.m_EnumValueAsString = Enum.GetNames(enumType)[0];
		}

		// Token: 0x040001A3 RID: 419
		[SerializeField]
		private string m_EnumValueAsString;

		// Token: 0x040001A4 RID: 420
		[SerializeField]
		private string m_EnumTypeAsString;
	}
}
