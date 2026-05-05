using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Models
{
	// Token: 0x02000042 RID: 66
	[Preserve]
	[DataContract(Name = "QuickJoinRequest")]
	public class QuickJoinRequest
	{
		// Token: 0x060001EB RID: 491 RVA: 0x00007D00 File Offset: 0x00005F00
		[Preserve]
		public QuickJoinRequest(List<QueryFilter> filter = null, Player player = null)
		{
			this.Filter = filter;
			this.Player = player;
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060001EC RID: 492 RVA: 0x00007D16 File Offset: 0x00005F16
		[Preserve]
		[DataMember(Name = "filter", EmitDefaultValue = false)]
		public List<QueryFilter> Filter { get; }

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060001ED RID: 493 RVA: 0x00007D1E File Offset: 0x00005F1E
		[Preserve]
		[DataMember(Name = "player", EmitDefaultValue = false)]
		public Player Player { get; }

		// Token: 0x060001EE RID: 494 RVA: 0x00007D28 File Offset: 0x00005F28
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.Filter != null)
			{
				text = text + "filter," + this.Filter.ToString() + ",";
			}
			if (this.Player != null)
			{
				text = text + "player," + this.Player.ToString();
			}
			return text;
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00007D7F File Offset: 0x00005F7F
		internal Dictionary<string, string> GetAsQueryParam()
		{
			return new Dictionary<string, string>();
		}
	}
}
