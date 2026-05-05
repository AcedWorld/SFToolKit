using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication.Generated
{
	// Token: 0x0200006C RID: 108
	[DataContract(Name = "ErrorStatus")]
	[Preserve]
	internal class ErrorStatus
	{
		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060002F9 RID: 761 RVA: 0x000078D7 File Offset: 0x00005AD7
		// (set) Token: 0x060002FA RID: 762 RVA: 0x000078DF File Offset: 0x00005ADF
		[DataMember(Name = "status", IsRequired = true, EmitDefaultValue = true)]
		[Preserve]
		public int Status { get; set; }

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060002FB RID: 763 RVA: 0x000078E8 File Offset: 0x00005AE8
		// (set) Token: 0x060002FC RID: 764 RVA: 0x000078F0 File Offset: 0x00005AF0
		[DataMember(Name = "title", IsRequired = true, EmitDefaultValue = true)]
		[Preserve]
		public string Title { get; set; }

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060002FD RID: 765 RVA: 0x000078F9 File Offset: 0x00005AF9
		// (set) Token: 0x060002FE RID: 766 RVA: 0x00007901 File Offset: 0x00005B01
		[DataMember(Name = "detail", IsRequired = true, EmitDefaultValue = true)]
		[Preserve]
		public string Detail { get; set; }

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060002FF RID: 767 RVA: 0x0000790A File Offset: 0x00005B0A
		// (set) Token: 0x06000300 RID: 768 RVA: 0x00007912 File Offset: 0x00005B12
		[DataMember(Name = "code", IsRequired = true, EmitDefaultValue = true)]
		[Preserve]
		public int Code { get; set; }

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000301 RID: 769 RVA: 0x0000791B File Offset: 0x00005B1B
		// (set) Token: 0x06000302 RID: 770 RVA: 0x00007923 File Offset: 0x00005B23
		[DataMember(Name = "details", EmitDefaultValue = false)]
		[Preserve]
		public List<Detail> Details { get; set; }

		// Token: 0x06000303 RID: 771 RVA: 0x0000792C File Offset: 0x00005B2C
		[Preserve]
		public ErrorStatus(int status = 0, string title = null, string detail = null, int code = 0, List<Detail> details = null)
		{
			this.Status = status;
			if (title == null)
			{
				throw new ArgumentNullException("title is a required property for ErrorStatus and cannot be null");
			}
			this.Title = title;
			if (detail == null)
			{
				throw new ArgumentNullException("detail is a required property for ErrorStatus and cannot be null");
			}
			this.Detail = detail;
			this.Code = code;
			this.Details = details;
		}
	}
}
