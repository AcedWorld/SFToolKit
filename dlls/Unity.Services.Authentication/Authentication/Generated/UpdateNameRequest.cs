using System;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication.Generated
{
	// Token: 0x0200006E RID: 110
	[DataContract(Name = "UpdateNameRequest")]
	[Preserve]
	internal class UpdateNameRequest
	{
		// Token: 0x170000AB RID: 171
		// (get) Token: 0x0600030B RID: 779 RVA: 0x000079DE File Offset: 0x00005BDE
		// (set) Token: 0x0600030C RID: 780 RVA: 0x000079E6 File Offset: 0x00005BE6
		[DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
		[Preserve]
		public string Name { get; set; }

		// Token: 0x0600030D RID: 781 RVA: 0x000079EF File Offset: 0x00005BEF
		[Preserve]
		public UpdateNameRequest(string name = null)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name is a required property for UpdateNameRequest and cannot be null");
			}
			this.Name = name;
		}
	}
}
