using System;
using System.Globalization;
using System.Text;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x0200002A RID: 42
	[Serializable]
	internal sealed class Cookie
	{
		// Token: 0x060002E9 RID: 745 RVA: 0x0000DDE1 File Offset: 0x0000BFE1
		internal Cookie()
		{
			this.init(string.Empty, string.Empty, string.Empty, string.Empty);
		}

		// Token: 0x060002EA RID: 746 RVA: 0x0000DE03 File Offset: 0x0000C003
		public Cookie(string name, string value) : this(name, value, string.Empty, string.Empty)
		{
		}

		// Token: 0x060002EB RID: 747 RVA: 0x0000DE17 File Offset: 0x0000C017
		public Cookie(string name, string value, string path) : this(name, value, path, string.Empty)
		{
		}

		// Token: 0x060002EC RID: 748 RVA: 0x0000DE28 File Offset: 0x0000C028
		public Cookie(string name, string value, string path, string domain)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (name.Length == 0)
			{
				throw new ArgumentException("An empty string.", "name");
			}
			if (name[0] == '$')
			{
				throw new ArgumentException("It starts with a dollar sign.", "name");
			}
			if (!name.IsToken())
			{
				throw new ArgumentException("It contains an invalid character.", "name");
			}
			if (value == null)
			{
				value = string.Empty;
			}
			if (value.Contains(Cookie._reservedCharsForValue) && !value.IsEnclosedIn('"'))
			{
				throw new ArgumentException("A string not enclosed in double quotes.", "value");
			}
			this.init(name, value, path ?? string.Empty, domain ?? string.Empty);
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x060002ED RID: 749 RVA: 0x0000DEE2 File Offset: 0x0000C0E2
		internal bool ExactDomain
		{
			get
			{
				return this._domain.Length == 0 || this._domain[0] != '.';
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x060002EE RID: 750 RVA: 0x0000DF08 File Offset: 0x0000C108
		// (set) Token: 0x060002EF RID: 751 RVA: 0x0000DF6C File Offset: 0x0000C16C
		internal int MaxAge
		{
			get
			{
				if (this._expires == DateTime.MinValue)
				{
					return 0;
				}
				TimeSpan t = ((this._expires.Kind != DateTimeKind.Local) ? this._expires.ToLocalTime() : this._expires) - DateTime.Now;
				if (!(t > TimeSpan.Zero))
				{
					return 0;
				}
				return (int)t.TotalSeconds;
			}
			set
			{
				this._expires = ((value > 0) ? DateTime.Now.AddSeconds((double)value) : DateTime.Now);
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x060002F0 RID: 752 RVA: 0x0000DF99 File Offset: 0x0000C199
		internal int[] Ports
		{
			get
			{
				return this._ports ?? Cookie._emptyPorts;
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x060002F1 RID: 753 RVA: 0x0000DFAA File Offset: 0x0000C1AA
		// (set) Token: 0x060002F2 RID: 754 RVA: 0x0000DFB2 File Offset: 0x0000C1B2
		internal string SameSite
		{
			get
			{
				return this._sameSite;
			}
			set
			{
				this._sameSite = value;
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x060002F3 RID: 755 RVA: 0x0000DFBB File Offset: 0x0000C1BB
		// (set) Token: 0x060002F4 RID: 756 RVA: 0x0000DFC3 File Offset: 0x0000C1C3
		public string Comment
		{
			get
			{
				return this._comment;
			}
			internal set
			{
				this._comment = value;
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x060002F5 RID: 757 RVA: 0x0000DFCC File Offset: 0x0000C1CC
		// (set) Token: 0x060002F6 RID: 758 RVA: 0x0000DFD4 File Offset: 0x0000C1D4
		public Uri CommentUri
		{
			get
			{
				return this._commentUri;
			}
			internal set
			{
				this._commentUri = value;
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x060002F7 RID: 759 RVA: 0x0000DFDD File Offset: 0x0000C1DD
		// (set) Token: 0x060002F8 RID: 760 RVA: 0x0000DFE5 File Offset: 0x0000C1E5
		public bool Discard
		{
			get
			{
				return this._discard;
			}
			internal set
			{
				this._discard = value;
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x060002F9 RID: 761 RVA: 0x0000DFEE File Offset: 0x0000C1EE
		// (set) Token: 0x060002FA RID: 762 RVA: 0x0000DFF6 File Offset: 0x0000C1F6
		public string Domain
		{
			get
			{
				return this._domain;
			}
			set
			{
				this._domain = (value ?? string.Empty);
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x060002FB RID: 763 RVA: 0x0000E008 File Offset: 0x0000C208
		// (set) Token: 0x060002FC RID: 764 RVA: 0x0000E02E File Offset: 0x0000C22E
		public bool Expired
		{
			get
			{
				return this._expires != DateTime.MinValue && this._expires <= DateTime.Now;
			}
			set
			{
				this._expires = (value ? DateTime.Now : DateTime.MinValue);
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x060002FD RID: 765 RVA: 0x0000E045 File Offset: 0x0000C245
		// (set) Token: 0x060002FE RID: 766 RVA: 0x0000E04D File Offset: 0x0000C24D
		public DateTime Expires
		{
			get
			{
				return this._expires;
			}
			set
			{
				this._expires = value;
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x060002FF RID: 767 RVA: 0x0000E056 File Offset: 0x0000C256
		// (set) Token: 0x06000300 RID: 768 RVA: 0x0000E05E File Offset: 0x0000C25E
		public bool HttpOnly
		{
			get
			{
				return this._httpOnly;
			}
			set
			{
				this._httpOnly = value;
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000301 RID: 769 RVA: 0x0000E067 File Offset: 0x0000C267
		// (set) Token: 0x06000302 RID: 770 RVA: 0x0000E070 File Offset: 0x0000C270
		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (value.Length == 0)
				{
					throw new ArgumentException("An empty string.", "value");
				}
				if (value[0] == '$')
				{
					throw new ArgumentException("It starts with a dollar sign.", "value");
				}
				if (!value.IsToken())
				{
					throw new ArgumentException("It contains an invalid character.", "value");
				}
				this._name = value;
			}
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000303 RID: 771 RVA: 0x0000E0DD File Offset: 0x0000C2DD
		// (set) Token: 0x06000304 RID: 772 RVA: 0x0000E0E5 File Offset: 0x0000C2E5
		public string Path
		{
			get
			{
				return this._path;
			}
			set
			{
				this._path = (value ?? string.Empty);
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000305 RID: 773 RVA: 0x0000E0F7 File Offset: 0x0000C2F7
		// (set) Token: 0x06000306 RID: 774 RVA: 0x0000E100 File Offset: 0x0000C300
		public string Port
		{
			get
			{
				return this._port;
			}
			internal set
			{
				int[] ports;
				if (!Cookie.tryCreatePorts(value, out ports))
				{
					return;
				}
				this._ports = ports;
				this._port = value;
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000307 RID: 775 RVA: 0x0000E126 File Offset: 0x0000C326
		// (set) Token: 0x06000308 RID: 776 RVA: 0x0000E12E File Offset: 0x0000C32E
		public bool Secure
		{
			get
			{
				return this._secure;
			}
			set
			{
				this._secure = value;
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000309 RID: 777 RVA: 0x0000E137 File Offset: 0x0000C337
		public DateTime TimeStamp
		{
			get
			{
				return this._timeStamp;
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x0600030A RID: 778 RVA: 0x0000E13F File Offset: 0x0000C33F
		// (set) Token: 0x0600030B RID: 779 RVA: 0x0000E147 File Offset: 0x0000C347
		public string Value
		{
			get
			{
				return this._value;
			}
			set
			{
				if (value == null)
				{
					value = string.Empty;
				}
				if (value.Contains(Cookie._reservedCharsForValue) && !value.IsEnclosedIn('"'))
				{
					throw new ArgumentException("A string not enclosed in double quotes.", "value");
				}
				this._value = value;
			}
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x0600030C RID: 780 RVA: 0x0000E181 File Offset: 0x0000C381
		// (set) Token: 0x0600030D RID: 781 RVA: 0x0000E189 File Offset: 0x0000C389
		public int Version
		{
			get
			{
				return this._version;
			}
			internal set
			{
				if (value < 0 || value > 1)
				{
					return;
				}
				this._version = value;
			}
		}

		// Token: 0x0600030E RID: 782 RVA: 0x0000E19B File Offset: 0x0000C39B
		private static int hash(int i, int j, int k, int l, int m)
		{
			return i ^ (j << 13 | j >> 19) ^ (k << 26 | k >> 6) ^ (l << 7 | l >> 25) ^ (m << 20 | m >> 12);
		}

		// Token: 0x0600030F RID: 783 RVA: 0x0000E1C6 File Offset: 0x0000C3C6
		private void init(string name, string value, string path, string domain)
		{
			this._name = name;
			this._value = value;
			this._path = path;
			this._domain = domain;
			this._expires = DateTime.MinValue;
			this._timeStamp = DateTime.Now;
		}

		// Token: 0x06000310 RID: 784 RVA: 0x0000E1FC File Offset: 0x0000C3FC
		private string toResponseStringVersion0()
		{
			StringBuilder stringBuilder = new StringBuilder(64);
			stringBuilder.AppendFormat("{0}={1}", this._name, this._value);
			if (this._expires != DateTime.MinValue)
			{
				string arg = this._expires.ToUniversalTime().ToString("ddd, dd'-'MMM'-'yyyy HH':'mm':'ss 'GMT'", CultureInfo.CreateSpecificCulture("en-US"));
				stringBuilder.AppendFormat("; Expires={0}", arg);
			}
			if (!this._path.IsNullOrEmpty())
			{
				stringBuilder.AppendFormat("; Path={0}", this._path);
			}
			if (!this._domain.IsNullOrEmpty())
			{
				stringBuilder.AppendFormat("; Domain={0}", this._domain);
			}
			if (!this._sameSite.IsNullOrEmpty())
			{
				stringBuilder.AppendFormat("; SameSite={0}", this._sameSite);
			}
			if (this._secure)
			{
				stringBuilder.Append("; Secure");
			}
			if (this._httpOnly)
			{
				stringBuilder.Append("; HttpOnly");
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000311 RID: 785 RVA: 0x0000E2F8 File Offset: 0x0000C4F8
		private string toResponseStringVersion1()
		{
			StringBuilder stringBuilder = new StringBuilder(64);
			stringBuilder.AppendFormat("{0}={1}; Version={2}", this._name, this._value, this._version);
			if (this._expires != DateTime.MinValue)
			{
				stringBuilder.AppendFormat("; Max-Age={0}", this.MaxAge);
			}
			if (!this._path.IsNullOrEmpty())
			{
				stringBuilder.AppendFormat("; Path={0}", this._path);
			}
			if (!this._domain.IsNullOrEmpty())
			{
				stringBuilder.AppendFormat("; Domain={0}", this._domain);
			}
			if (this._port != null)
			{
				if (this._port != "\"\"")
				{
					stringBuilder.AppendFormat("; Port={0}", this._port);
				}
				else
				{
					stringBuilder.Append("; Port");
				}
			}
			if (this._comment != null)
			{
				string arg = HttpUtility.UrlEncode(this._comment);
				stringBuilder.AppendFormat("; Comment={0}", arg);
			}
			if (this._commentUri != null)
			{
				string originalString = this._commentUri.OriginalString;
				stringBuilder.AppendFormat("; CommentURL={0}", (!originalString.IsToken()) ? originalString.Quote() : originalString);
			}
			if (this._discard)
			{
				stringBuilder.Append("; Discard");
			}
			if (this._secure)
			{
				stringBuilder.Append("; Secure");
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000312 RID: 786 RVA: 0x0000E458 File Offset: 0x0000C658
		private static bool tryCreatePorts(string value, out int[] result)
		{
			result = null;
			string[] array = value.Trim('"').Split(',', StringSplitOptions.None);
			int num = array.Length;
			int[] array2 = new int[num];
			for (int i = 0; i < num; i++)
			{
				string text = array[i].Trim();
				if (text.Length == 0)
				{
					array2[i] = int.MinValue;
				}
				else if (!int.TryParse(text, out array2[i]))
				{
					return false;
				}
			}
			result = array2;
			return true;
		}

		// Token: 0x06000313 RID: 787 RVA: 0x0000E4C4 File Offset: 0x0000C6C4
		internal bool EqualsWithoutValue(Cookie cookie)
		{
			StringComparison comparisonType = StringComparison.InvariantCulture;
			StringComparison comparisonType2 = StringComparison.InvariantCultureIgnoreCase;
			return this._name.Equals(cookie._name, comparisonType2) && this._path.Equals(cookie._path, comparisonType) && this._domain.Equals(cookie._domain, comparisonType2) && this._version == cookie._version;
		}

		// Token: 0x06000314 RID: 788 RVA: 0x0000E524 File Offset: 0x0000C724
		internal bool EqualsWithoutValueAndVersion(Cookie cookie)
		{
			StringComparison comparisonType = StringComparison.InvariantCulture;
			StringComparison comparisonType2 = StringComparison.InvariantCultureIgnoreCase;
			return this._name.Equals(cookie._name, comparisonType2) && this._path.Equals(cookie._path, comparisonType) && this._domain.Equals(cookie._domain, comparisonType2);
		}

		// Token: 0x06000315 RID: 789 RVA: 0x0000E574 File Offset: 0x0000C774
		internal string ToRequestString(Uri uri)
		{
			if (this._name.Length == 0)
			{
				return string.Empty;
			}
			if (this._version == 0)
			{
				return string.Format("{0}={1}", this._name, this._value);
			}
			StringBuilder stringBuilder = new StringBuilder(64);
			stringBuilder.AppendFormat("$Version={0}; {1}={2}", this._version, this._name, this._value);
			if (!this._path.IsNullOrEmpty())
			{
				stringBuilder.AppendFormat("; $Path={0}", this._path);
			}
			else if (uri != null)
			{
				stringBuilder.AppendFormat("; $Path={0}", uri.GetAbsolutePath());
			}
			else
			{
				stringBuilder.Append("; $Path=/");
			}
			if (!this._domain.IsNullOrEmpty() && (uri == null || uri.Host != this._domain))
			{
				stringBuilder.AppendFormat("; $Domain={0}", this._domain);
			}
			if (this._port != null)
			{
				if (this._port != "\"\"")
				{
					stringBuilder.AppendFormat("; $Port={0}", this._port);
				}
				else
				{
					stringBuilder.Append("; $Port");
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000316 RID: 790 RVA: 0x0000E6A3 File Offset: 0x0000C8A3
		internal string ToResponseString()
		{
			if (this._name.Length == 0)
			{
				return string.Empty;
			}
			if (this._version == 0)
			{
				return this.toResponseStringVersion0();
			}
			return this.toResponseStringVersion1();
		}

		// Token: 0x06000317 RID: 791 RVA: 0x0000E6D0 File Offset: 0x0000C8D0
		internal static bool TryCreate(string name, string value, out Cookie result)
		{
			result = null;
			try
			{
				result = new Cookie(name, value);
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x06000318 RID: 792 RVA: 0x0000E704 File Offset: 0x0000C904
		public override bool Equals(object comparand)
		{
			Cookie cookie = comparand as Cookie;
			if (cookie == null)
			{
				return false;
			}
			StringComparison comparisonType = StringComparison.InvariantCulture;
			StringComparison comparisonType2 = StringComparison.InvariantCultureIgnoreCase;
			return this._name.Equals(cookie._name, comparisonType2) && this._value.Equals(cookie._value, comparisonType) && this._path.Equals(cookie._path, comparisonType) && this._domain.Equals(cookie._domain, comparisonType2) && this._version == cookie._version;
		}

		// Token: 0x06000319 RID: 793 RVA: 0x0000E784 File Offset: 0x0000C984
		public override int GetHashCode()
		{
			int hashCode = StringComparer.InvariantCultureIgnoreCase.GetHashCode(this._name);
			int hashCode2 = this._value.GetHashCode();
			int hashCode3 = this._path.GetHashCode();
			int hashCode4 = StringComparer.InvariantCultureIgnoreCase.GetHashCode(this._domain);
			int version = this._version;
			return Cookie.hash(hashCode, hashCode2, hashCode3, hashCode4, version);
		}

		// Token: 0x0600031A RID: 794 RVA: 0x0000E7DA File Offset: 0x0000C9DA
		public override string ToString()
		{
			return this.ToRequestString(null);
		}

		// Token: 0x0400010A RID: 266
		private string _comment;

		// Token: 0x0400010B RID: 267
		private Uri _commentUri;

		// Token: 0x0400010C RID: 268
		private bool _discard;

		// Token: 0x0400010D RID: 269
		private string _domain;

		// Token: 0x0400010E RID: 270
		private static readonly int[] _emptyPorts = new int[0];

		// Token: 0x0400010F RID: 271
		private DateTime _expires;

		// Token: 0x04000110 RID: 272
		private bool _httpOnly;

		// Token: 0x04000111 RID: 273
		private string _name;

		// Token: 0x04000112 RID: 274
		private string _path;

		// Token: 0x04000113 RID: 275
		private string _port;

		// Token: 0x04000114 RID: 276
		private int[] _ports;

		// Token: 0x04000115 RID: 277
		private static readonly char[] _reservedCharsForValue = new char[]
		{
			';',
			','
		};

		// Token: 0x04000116 RID: 278
		private string _sameSite;

		// Token: 0x04000117 RID: 279
		private bool _secure;

		// Token: 0x04000118 RID: 280
		private DateTime _timeStamp;

		// Token: 0x04000119 RID: 281
		private string _value;

		// Token: 0x0400011A RID: 282
		private int _version;
	}
}
