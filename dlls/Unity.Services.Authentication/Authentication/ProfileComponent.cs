using System;

namespace Unity.Services.Authentication
{
	// Token: 0x02000015 RID: 21
	internal class ProfileComponent : IProfile
	{
		// Token: 0x14000013 RID: 19
		// (add) Token: 0x0600012F RID: 303 RVA: 0x00004B38 File Offset: 0x00002D38
		// (remove) Token: 0x06000130 RID: 304 RVA: 0x00004B70 File Offset: 0x00002D70
		public event Action<ProfileEventArgs> ProfileChange;

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000131 RID: 305 RVA: 0x00004BA5 File Offset: 0x00002DA5
		// (set) Token: 0x06000132 RID: 306 RVA: 0x00004BAD File Offset: 0x00002DAD
		public string Current
		{
			get
			{
				return this._current;
			}
			set
			{
				this.SetProfile(value);
			}
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00004BB6 File Offset: 0x00002DB6
		internal ProfileComponent(string profile)
		{
			this.SetProfile(profile);
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00004BC8 File Offset: 0x00002DC8
		public void SetProfile(string profile)
		{
			this._current = profile;
			try
			{
				Action<ProfileEventArgs> profileChange = this.ProfileChange;
				if (profileChange != null)
				{
					profileChange(new ProfileEventArgs(this._current));
				}
			}
			catch (Exception exception)
			{
				Logger.LogException(exception);
			}
		}

		// Token: 0x04000054 RID: 84
		private string _current;
	}
}
