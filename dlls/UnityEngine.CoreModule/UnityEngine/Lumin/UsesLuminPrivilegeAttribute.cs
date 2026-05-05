using System;

namespace UnityEngine.Lumin
{
	// Token: 0x020003DA RID: 986
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	[Obsolete("Lumin is no longer supported in Unity 2022.2")]
	public sealed class UsesLuminPrivilegeAttribute : Attribute
	{
		// Token: 0x06002145 RID: 8517 RVA: 0x0003757C File Offset: 0x0003577C
		public UsesLuminPrivilegeAttribute(string privilege)
		{
			this.m_Privilege = privilege;
		}

		// Token: 0x1700064C RID: 1612
		// (get) Token: 0x06002146 RID: 8518 RVA: 0x00037590 File Offset: 0x00035790
		public string privilege
		{
			get
			{
				return this.m_Privilege;
			}
		}

		// Token: 0x04000B07 RID: 2823
		private readonly string m_Privilege;
	}
}
