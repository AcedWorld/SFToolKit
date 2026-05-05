using System;
using UnityEngine.Scripting;

namespace UnityEngine.Serialization
{
	// Token: 0x0200030B RID: 779
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
	[RequiredByNativeCode]
	public class FormerlySerializedAsAttribute : Attribute
	{
		// Token: 0x06002008 RID: 8200 RVA: 0x000354D8 File Offset: 0x000336D8
		public FormerlySerializedAsAttribute(string oldName)
		{
			this.m_oldName = oldName;
		}

		// Token: 0x17000621 RID: 1569
		// (get) Token: 0x06002009 RID: 8201 RVA: 0x000354EC File Offset: 0x000336EC
		public string oldName
		{
			get
			{
				return this.m_oldName;
			}
		}

		// Token: 0x04000A7F RID: 2687
		private string m_oldName;
	}
}
