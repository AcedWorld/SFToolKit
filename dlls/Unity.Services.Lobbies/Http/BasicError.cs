using System;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Http
{
	// Token: 0x02000047 RID: 71
	[Preserve]
	internal class BasicError : IError
	{
		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000204 RID: 516 RVA: 0x000081AF File Offset: 0x000063AF
		[Preserve]
		public string Type { get; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000205 RID: 517 RVA: 0x000081B7 File Offset: 0x000063B7
		[Preserve]
		public string Title { get; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000206 RID: 518 RVA: 0x000081BF File Offset: 0x000063BF
		[Preserve]
		public int? Status { get; }

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000207 RID: 519 RVA: 0x000081C7 File Offset: 0x000063C7
		[Preserve]
		public int Code { get; }

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000208 RID: 520 RVA: 0x000081CF File Offset: 0x000063CF
		[Preserve]
		public string Detail { get; }

		// Token: 0x06000209 RID: 521 RVA: 0x000081D7 File Offset: 0x000063D7
		[Preserve]
		public BasicError(string type, string title, int? status, int code, string detail)
		{
			this.Type = type;
			this.Title = title;
			this.Status = status;
			this.Code = code;
			this.Detail = detail;
		}

		// Token: 0x0600020A RID: 522 RVA: 0x00008204 File Offset: 0x00006404
		public override string ToString()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}
