using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000145 RID: 325
	[MovedFrom("Unity.GameCore")]
	public class XGameUiWebAuthenticationResultData
	{
		// Token: 0x060007E2 RID: 2018 RVA: 0x0000D580 File Offset: 0x0000B780
		internal XGameUiWebAuthenticationResultData(XGameUiWebAuthenticationResultData interop)
		{
			this.data = interop;
		}

		// Token: 0x060007E3 RID: 2019 RVA: 0x0000D58F File Offset: 0x0000B78F
		public XGameUiWebAuthenticationResultData()
		{
			this.data = default(XGameUiWebAuthenticationResultData);
		}

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x060007E4 RID: 2020 RVA: 0x0000D5A3 File Offset: 0x0000B7A3
		// (set) Token: 0x060007E5 RID: 2021 RVA: 0x0000D5B0 File Offset: 0x0000B7B0
		public uint ResponseStatus
		{
			get
			{
				return this.data.responseStatus;
			}
			set
			{
				this.data.responseStatus = value;
			}
		}

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x060007E6 RID: 2022 RVA: 0x0000D5BE File Offset: 0x0000B7BE
		// (set) Token: 0x060007E7 RID: 2023 RVA: 0x0000D5CB File Offset: 0x0000B7CB
		public ulong ResponseCompletionUriSize
		{
			get
			{
				return this.data.responseCompletionUriSize;
			}
			set
			{
				this.data.responseCompletionUriSize = value;
			}
		}

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x060007E8 RID: 2024 RVA: 0x0000D5D9 File Offset: 0x0000B7D9
		// (set) Token: 0x060007E9 RID: 2025 RVA: 0x0000D5E6 File Offset: 0x0000B7E6
		public string ResponseCompletionUri
		{
			get
			{
				return this.data.responseCompletionUri;
			}
			set
			{
				this.data.responseCompletionUri = value;
			}
		}

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x060007EA RID: 2026 RVA: 0x0000D5F4 File Offset: 0x0000B7F4
		// (set) Token: 0x060007EB RID: 2027 RVA: 0x0000D601 File Offset: 0x0000B801
		[Obsolete("Please use ResponseStatus instead, (UnityUpgradable) -> ResponseStatus", true)]
		public uint responseStatus
		{
			get
			{
				return this.data.responseStatus;
			}
			set
			{
				this.data.responseStatus = value;
			}
		}

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x060007EC RID: 2028 RVA: 0x0000D60F File Offset: 0x0000B80F
		// (set) Token: 0x060007ED RID: 2029 RVA: 0x0000D61C File Offset: 0x0000B81C
		[Obsolete("Please use ResponseCompletionUriSize instead, (UnityUpgradable) -> ResponseCompletionUriSize", true)]
		public ulong responseCompletionUriSize
		{
			get
			{
				return this.data.responseCompletionUriSize;
			}
			set
			{
				this.data.responseCompletionUriSize = value;
			}
		}

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x060007EE RID: 2030 RVA: 0x0000D62A File Offset: 0x0000B82A
		// (set) Token: 0x060007EF RID: 2031 RVA: 0x0000D637 File Offset: 0x0000B837
		[Obsolete("Please use ResponseCompletionUri instead, (UnityUpgradable) -> ResponseCompletionUri", true)]
		public string responseCompletionUri
		{
			get
			{
				return this.data.responseCompletionUri;
			}
			set
			{
				this.data.responseCompletionUri = value;
			}
		}

		// Token: 0x040004D3 RID: 1235
		internal XGameUiWebAuthenticationResultData data;
	}
}
