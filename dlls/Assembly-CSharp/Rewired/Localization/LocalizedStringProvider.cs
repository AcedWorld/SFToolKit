using System;
using System.Collections.Generic;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired.Localization
{
	// Token: 0x0200029E RID: 670
	[AddComponentMenu("Rewired/Localization/Localized String Provider")]
	public class LocalizedStringProvider : LocalizedStringProviderBase
	{
		// Token: 0x170002DC RID: 732
		// (get) Token: 0x06000DD0 RID: 3536 RVA: 0x0004ACAB File Offset: 0x00048EAB
		// (set) Token: 0x06000DD1 RID: 3537 RVA: 0x0004ACB3 File Offset: 0x00048EB3
		protected virtual Dictionary<string, string> dictionary
		{
			get
			{
				return this._dictionary;
			}
			set
			{
				this._dictionary = value;
			}
		}

		// Token: 0x170002DD RID: 733
		// (get) Token: 0x06000DD2 RID: 3538 RVA: 0x0004ACBC File Offset: 0x00048EBC
		// (set) Token: 0x06000DD3 RID: 3539 RVA: 0x0004ACC4 File Offset: 0x00048EC4
		public virtual TextAsset localizedStringsFile
		{
			get
			{
				return this._localizedStringsFile;
			}
			set
			{
				this._localizedStringsFile = value;
				this.Reload();
			}
		}

		// Token: 0x170002DE RID: 734
		// (get) Token: 0x06000DD4 RID: 3540 RVA: 0x0004ACD3 File Offset: 0x00048ED3
		protected override bool initialized
		{
			get
			{
				return this._initialized;
			}
		}

		// Token: 0x06000DD5 RID: 3541 RVA: 0x0004ACDB File Offset: 0x00048EDB
		protected override bool Initialize()
		{
			this._initialized = this.TryLoadLocalizedStringData();
			return this._initialized;
		}

		// Token: 0x06000DD6 RID: 3542 RVA: 0x0004ACF0 File Offset: 0x00048EF0
		protected virtual bool TryLoadLocalizedStringData()
		{
			this._dictionary.Clear();
			if (this._localizedStringsFile != null)
			{
				try
				{
					this._dictionary = JsonParser.FromJson<Dictionary<string, string>>(this._localizedStringsFile.text);
				}
				catch (Exception message)
				{
					Debug.LogError(message);
				}
			}
			return this._dictionary.Count > 0;
		}

		// Token: 0x06000DD7 RID: 3543 RVA: 0x0004AD54 File Offset: 0x00048F54
		protected override bool TryGetLocalizedString(string key, out string result)
		{
			if (!this._initialized)
			{
				result = null;
				return false;
			}
			return this._dictionary.TryGetValue(key, out result);
		}

		// Token: 0x040012BD RID: 4797
		[SerializeField]
		[Tooltip("A JSON file containing localizied string key value pairs.")]
		private TextAsset _localizedStringsFile;

		// Token: 0x040012BE RID: 4798
		[NonSerialized]
		private Dictionary<string, string> _dictionary = new Dictionary<string, string>();

		// Token: 0x040012BF RID: 4799
		[NonSerialized]
		private bool _initialized;
	}
}
