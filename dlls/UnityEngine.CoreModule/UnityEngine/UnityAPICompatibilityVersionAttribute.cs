using System;

namespace UnityEngine
{
	// Token: 0x02000266 RID: 614
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
	public class UnityAPICompatibilityVersionAttribute : Attribute
	{
		// Token: 0x060019A8 RID: 6568 RVA: 0x0002B23A File Offset: 0x0002943A
		[Obsolete("This overload of the attribute has been deprecated. Use the constructor that takes the version and a boolean", true)]
		public UnityAPICompatibilityVersionAttribute(string version)
		{
			this._version = version;
		}

		// Token: 0x060019A9 RID: 6569 RVA: 0x0002B24C File Offset: 0x0002944C
		public UnityAPICompatibilityVersionAttribute(string version, bool checkOnlyUnityVersion)
		{
			bool flag = !checkOnlyUnityVersion;
			if (flag)
			{
				throw new ArgumentException("You must pass 'true' to checkOnlyUnityVersion parameter.");
			}
			this._version = version;
		}

		// Token: 0x060019AA RID: 6570 RVA: 0x0002B27B File Offset: 0x0002947B
		public UnityAPICompatibilityVersionAttribute(string version, string[] configurationAssembliesHashes)
		{
			this._version = version;
			this._configurationAssembliesHashes = configurationAssembliesHashes;
		}

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x060019AB RID: 6571 RVA: 0x0002B294 File Offset: 0x00029494
		public string version
		{
			get
			{
				return this._version;
			}
		}

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x060019AC RID: 6572 RVA: 0x0002B2AC File Offset: 0x000294AC
		internal string[] configurationAssembliesHashes
		{
			get
			{
				return this._configurationAssembliesHashes;
			}
		}

		// Token: 0x040008E9 RID: 2281
		private string _version;

		// Token: 0x040008EA RID: 2282
		private string[] _configurationAssembliesHashes;
	}
}
