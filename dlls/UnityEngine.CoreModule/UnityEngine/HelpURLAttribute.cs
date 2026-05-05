using System;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x02000232 RID: 562
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	[UsedByNativeCode]
	public class HelpURLAttribute : Attribute
	{
		// Token: 0x06001856 RID: 6230 RVA: 0x0002858F File Offset: 0x0002678F
		public HelpURLAttribute(string url)
		{
			this.m_Url = url;
			this.m_DispatchingFieldName = "";
			this.m_Dispatcher = false;
		}

		// Token: 0x06001857 RID: 6231 RVA: 0x000285B2 File Offset: 0x000267B2
		internal HelpURLAttribute(string defaultURL, string dispatchingFieldName)
		{
			this.m_Url = defaultURL;
			this.m_DispatchingFieldName = dispatchingFieldName;
			this.m_Dispatcher = !string.IsNullOrEmpty(dispatchingFieldName);
		}

		// Token: 0x170004BE RID: 1214
		// (get) Token: 0x06001858 RID: 6232 RVA: 0x000285D9 File Offset: 0x000267D9
		public string URL
		{
			get
			{
				return this.m_Url;
			}
		}

		// Token: 0x04000896 RID: 2198
		internal readonly string m_Url;

		// Token: 0x04000897 RID: 2199
		internal readonly bool m_Dispatcher;

		// Token: 0x04000898 RID: 2200
		internal readonly string m_DispatchingFieldName;
	}
}
