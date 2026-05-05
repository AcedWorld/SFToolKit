using System;
using Rewired.Interfaces;

namespace Rewired.Internal.Glyphs
{
	// Token: 0x0200045D RID: 1117
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class KeyedGlyph
	{
		// Token: 0x17000A88 RID: 2696
		// (get) Token: 0x06002C7F RID: 11391 RVA: 0x000223A0 File Offset: 0x000205A0
		public bool hasCachedValue
		{
			get
			{
				return this.ioxoltcIUiAqcDdnNsaOSxJVAFtTA;
			}
		}

		// Token: 0x17000A89 RID: 2697
		// (get) Token: 0x06002C80 RID: 11392 RVA: 0x000223A8 File Offset: 0x000205A8
		// (set) Token: 0x06002C81 RID: 11393 RVA: 0x000223B0 File Offset: 0x000205B0
		public object cachedValue
		{
			get
			{
				return this.sRAEcEEAfqjZYBJydFRhbVPZfKEJ;
			}
			set
			{
				this.ioxoltcIUiAqcDdnNsaOSxJVAFtTA = true;
				this.sRAEcEEAfqjZYBJydFRhbVPZfKEJ = value;
				if (value == null)
				{
					this.AKjUXQXJRANgZvJMBysQzELDNVdT = null;
				}
			}
		}

		// Token: 0x17000A8A RID: 2698
		// (get) Token: 0x06002C82 RID: 11394 RVA: 0x000223CA File Offset: 0x000205CA
		public string cachedKey
		{
			get
			{
				return this.AKjUXQXJRANgZvJMBysQzELDNVdT;
			}
		}

		// Token: 0x06002C83 RID: 11395 RVA: 0x000223D2 File Offset: 0x000205D2
		public KeyedGlyph()
		{
			this.MmBbqCFlRIhgyHkgKFiAjbPJBjyXb = 0U;
			this.wQhNtiiLlcuIZxAQUYpuZusNejdw = 0U;
		}

		// Token: 0x06002C84 RID: 11396 RVA: 0x0009E960 File Offset: 0x0009CB60
		public KeyedGlyph(KeyedGlyph A_1)
		{
			this.MmBbqCFlRIhgyHkgKFiAjbPJBjyXb = A_1.MmBbqCFlRIhgyHkgKFiAjbPJBjyXb;
			this.wQhNtiiLlcuIZxAQUYpuZusNejdw = A_1.wQhNtiiLlcuIZxAQUYpuZusNejdw;
			this.sRAEcEEAfqjZYBJydFRhbVPZfKEJ = A_1.sRAEcEEAfqjZYBJydFRhbVPZfKEJ;
			this.ioxoltcIUiAqcDdnNsaOSxJVAFtTA = A_1.ioxoltcIUiAqcDdnNsaOSxJVAFtTA;
			this.AKjUXQXJRANgZvJMBysQzELDNVdT = A_1.AKjUXQXJRANgZvJMBysQzELDNVdT;
		}

		// Token: 0x06002C85 RID: 11397 RVA: 0x000223E8 File Offset: 0x000205E8
		public void Clear()
		{
			this.MmBbqCFlRIhgyHkgKFiAjbPJBjyXb = 0U;
			this.wQhNtiiLlcuIZxAQUYpuZusNejdw = 0U;
			this.sRAEcEEAfqjZYBJydFRhbVPZfKEJ = null;
			this.ioxoltcIUiAqcDdnNsaOSxJVAFtTA = false;
			this.AKjUXQXJRANgZvJMBysQzELDNVdT = null;
		}

		// Token: 0x06002C86 RID: 11398 RVA: 0x0009E9B0 File Offset: 0x0009CBB0
		public bool TryGetValue(string key, IGlyphProvider glyphProvider, uint glyphProviderVersion, uint userVersion, out bool versionChanged, out object result)
		{
			versionChanged = (this.MmBbqCFlRIhgyHkgKFiAjbPJBjyXb != ((glyphProvider != null) ? glyphProviderVersion : 0U) || userVersion != this.wQhNtiiLlcuIZxAQUYpuZusNejdw);
			if (versionChanged)
			{
				this.Clear();
				this.MmBbqCFlRIhgyHkgKFiAjbPJBjyXb = glyphProviderVersion;
				this.wQhNtiiLlcuIZxAQUYpuZusNejdw = userVersion;
			}
			if (!versionChanged || glyphProvider == null)
			{
				result = (this.ioxoltcIUiAqcDdnNsaOSxJVAFtTA ? this.sRAEcEEAfqjZYBJydFRhbVPZfKEJ : null);
				return this.ioxoltcIUiAqcDdnNsaOSxJVAFtTA;
			}
			if (string.IsNullOrEmpty(key))
			{
				result = null;
				return false;
			}
			try
			{
				this.ioxoltcIUiAqcDdnNsaOSxJVAFtTA = (glyphProvider.TryGetGlyph(key, out this.sRAEcEEAfqjZYBJydFRhbVPZfKEJ) && this.sRAEcEEAfqjZYBJydFRhbVPZfKEJ != null);
				if (this.ioxoltcIUiAqcDdnNsaOSxJVAFtTA)
				{
					this.AKjUXQXJRANgZvJMBysQzELDNVdT = key;
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleExternalInterfaceException(typeof(IGlyphProvider).Name + ".TryGetGlyph", exception);
			}
			result = (this.ioxoltcIUiAqcDdnNsaOSxJVAFtTA ? this.sRAEcEEAfqjZYBJydFRhbVPZfKEJ : null);
			return this.ioxoltcIUiAqcDdnNsaOSxJVAFtTA;
		}

		// Token: 0x0400194C RID: 6476
		public const uint INVALID_VERSION = 0U;

		// Token: 0x0400194D RID: 6477
		private uint MmBbqCFlRIhgyHkgKFiAjbPJBjyXb;

		// Token: 0x0400194E RID: 6478
		private uint wQhNtiiLlcuIZxAQUYpuZusNejdw;

		// Token: 0x0400194F RID: 6479
		private object sRAEcEEAfqjZYBJydFRhbVPZfKEJ;

		// Token: 0x04001950 RID: 6480
		private bool ioxoltcIUiAqcDdnNsaOSxJVAFtTA;

		// Token: 0x04001951 RID: 6481
		private string AKjUXQXJRANgZvJMBysQzELDNVdT;
	}
}
