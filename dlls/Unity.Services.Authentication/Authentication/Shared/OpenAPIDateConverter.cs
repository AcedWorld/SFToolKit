using System;
using Newtonsoft.Json.Converters;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication.Shared
{
	// Token: 0x02000068 RID: 104
	internal class OpenAPIDateConverter : IsoDateTimeConverter
	{
		// Token: 0x060002EA RID: 746 RVA: 0x0000772C File Offset: 0x0000592C
		[Preserve]
		public OpenAPIDateConverter()
		{
			base.DateTimeFormat = "yyyy-MM-dd";
		}
	}
}
