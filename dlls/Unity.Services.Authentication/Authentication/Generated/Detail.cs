using System;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication.Generated
{
	// Token: 0x0200006B RID: 107
	[DataContract(Name = "Detail")]
	[Preserve]
	internal class Detail
	{
		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060002F4 RID: 756 RVA: 0x00007883 File Offset: 0x00005A83
		// (set) Token: 0x060002F5 RID: 757 RVA: 0x0000788B File Offset: 0x00005A8B
		[DataMember(Name = "errorType", IsRequired = true, EmitDefaultValue = true)]
		[Preserve]
		public string ErrorType { get; set; }

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060002F6 RID: 758 RVA: 0x00007894 File Offset: 0x00005A94
		// (set) Token: 0x060002F7 RID: 759 RVA: 0x0000789C File Offset: 0x00005A9C
		[DataMember(Name = "message", IsRequired = true, EmitDefaultValue = true)]
		[Preserve]
		public string Message { get; set; }

		// Token: 0x060002F8 RID: 760 RVA: 0x000078A5 File Offset: 0x00005AA5
		[Preserve]
		public Detail(string errorType = null, string message = null)
		{
			if (errorType == null)
			{
				throw new ArgumentNullException("errorType is a required property for Detail and cannot be null");
			}
			this.ErrorType = errorType;
			if (message == null)
			{
				throw new ArgumentNullException("message is a required property for Detail and cannot be null");
			}
			this.Message = message;
		}
	}
}
