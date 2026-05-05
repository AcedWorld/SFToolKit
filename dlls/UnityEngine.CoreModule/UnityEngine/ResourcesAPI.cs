using System;

namespace UnityEngine
{
	// Token: 0x02000222 RID: 546
	public class ResourcesAPI
	{
		// Token: 0x170004AC RID: 1196
		// (get) Token: 0x060017F0 RID: 6128 RVA: 0x00027B5E File Offset: 0x00025D5E
		internal static ResourcesAPI ActiveAPI
		{
			get
			{
				return ResourcesAPI.overrideAPI ?? ResourcesAPI.s_DefaultAPI;
			}
		}

		// Token: 0x170004AD RID: 1197
		// (get) Token: 0x060017F1 RID: 6129 RVA: 0x00027B6E File Offset: 0x00025D6E
		// (set) Token: 0x060017F2 RID: 6130 RVA: 0x00027B75 File Offset: 0x00025D75
		public static ResourcesAPI overrideAPI { get; set; }

		// Token: 0x060017F3 RID: 6131 RVA: 0x00009E2F File Offset: 0x0000802F
		protected internal ResourcesAPI()
		{
		}

		// Token: 0x060017F4 RID: 6132 RVA: 0x00027B7D File Offset: 0x00025D7D
		protected internal virtual Object[] FindObjectsOfTypeAll(Type systemTypeInstance)
		{
			return ResourcesAPIInternal.FindObjectsOfTypeAll(systemTypeInstance);
		}

		// Token: 0x060017F5 RID: 6133 RVA: 0x00027B85 File Offset: 0x00025D85
		protected internal virtual Shader FindShaderByName(string name)
		{
			return ResourcesAPIInternal.FindShaderByName(name);
		}

		// Token: 0x060017F6 RID: 6134 RVA: 0x00027B8D File Offset: 0x00025D8D
		protected internal virtual Object Load(string path, Type systemTypeInstance)
		{
			return ResourcesAPIInternal.Load(path, systemTypeInstance);
		}

		// Token: 0x060017F7 RID: 6135 RVA: 0x00027B96 File Offset: 0x00025D96
		protected internal virtual Object[] LoadAll(string path, Type systemTypeInstance)
		{
			return ResourcesAPIInternal.LoadAll(path, systemTypeInstance);
		}

		// Token: 0x060017F8 RID: 6136 RVA: 0x00027BA0 File Offset: 0x00025DA0
		protected internal virtual ResourceRequest LoadAsync(string path, Type systemTypeInstance)
		{
			ResourceRequest resourceRequest = ResourcesAPIInternal.LoadAsyncInternal(path, systemTypeInstance);
			resourceRequest.m_Path = path;
			resourceRequest.m_Type = systemTypeInstance;
			return resourceRequest;
		}

		// Token: 0x060017F9 RID: 6137 RVA: 0x00027BC9 File Offset: 0x00025DC9
		protected internal virtual void UnloadAsset(Object assetToUnload)
		{
			ResourcesAPIInternal.UnloadAsset(assetToUnload);
		}

		// Token: 0x04000885 RID: 2181
		private static ResourcesAPI s_DefaultAPI = new ResourcesAPI();
	}
}
