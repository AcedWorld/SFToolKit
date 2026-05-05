using System;
using System.Collections.Generic;

namespace Unity.Services.Core
{
	// Token: 0x02000006 RID: 6
	public class InitializationOptions
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000D RID: 13 RVA: 0x00002188 File Offset: 0x00000388
		internal IDictionary<string, object> Values { get; }

		// Token: 0x0600000E RID: 14 RVA: 0x00002190 File Offset: 0x00000390
		public InitializationOptions() : this(new Dictionary<string, object>())
		{
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000219D File Offset: 0x0000039D
		internal InitializationOptions(IDictionary<string, object> values)
		{
			this.Values = values;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000021AC File Offset: 0x000003AC
		internal InitializationOptions(InitializationOptions source) : this(new Dictionary<string, object>(source.Values))
		{
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000021BF File Offset: 0x000003BF
		public bool TryGetOption(string key, out bool option)
		{
			return this.TryGetOption<bool>(key, out option);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000021C9 File Offset: 0x000003C9
		public bool TryGetOption(string key, out int option)
		{
			return this.TryGetOption<int>(key, out option);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000021D3 File Offset: 0x000003D3
		public bool TryGetOption(string key, out float option)
		{
			return this.TryGetOption<float>(key, out option);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000021DD File Offset: 0x000003DD
		public bool TryGetOption(string key, out string option)
		{
			return this.TryGetOption<string>(key, out option);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000021E8 File Offset: 0x000003E8
		private bool TryGetOption<T>(string key, out T option)
		{
			option = default(T);
			object obj;
			if (this.Values.TryGetValue(key, out obj) && obj is T)
			{
				T t = (T)((object)obj);
				option = t;
				return true;
			}
			return false;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002225 File Offset: 0x00000425
		public InitializationOptions SetOption(string key, bool value)
		{
			this.Values[key] = value;
			return this;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x0000223A File Offset: 0x0000043A
		public InitializationOptions SetOption(string key, int value)
		{
			this.Values[key] = value;
			return this;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000224F File Offset: 0x0000044F
		public InitializationOptions SetOption(string key, float value)
		{
			this.Values[key] = value;
			return this;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002264 File Offset: 0x00000464
		public InitializationOptions SetOption(string key, string value)
		{
			this.Values[key] = value;
			return this;
		}
	}
}
