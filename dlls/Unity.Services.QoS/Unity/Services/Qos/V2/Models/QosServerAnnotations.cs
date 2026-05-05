using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace Unity.Services.Qos.V2.Models
{
	// Token: 0x02000027 RID: 39
	[Preserve]
	[DataContract(Name = "QosServerAnnotations")]
	public class QosServerAnnotations
	{
		// Token: 0x0600009D RID: 157 RVA: 0x00004430 File Offset: 0x00002630
		[Preserve]
		public QosServerAnnotations(List<string> projectId = null, List<string> environmentId = null, List<string> relayRegionId = null, List<string> multiplayRegionId = null, List<string> multiplayFleetId = null, List<string> matchmakerQueueName = null, List<string> matchmakerPoolId = null)
		{
			this.ProjectId = projectId;
			this.EnvironmentId = environmentId;
			this.RelayRegionId = relayRegionId;
			this.MultiplayRegionId = multiplayRegionId;
			this.MultiplayFleetId = multiplayFleetId;
			this.MatchmakerQueueName = matchmakerQueueName;
			this.MatchmakerPoolId = matchmakerPoolId;
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x0600009E RID: 158 RVA: 0x0000446D File Offset: 0x0000266D
		[Preserve]
		[DataMember(Name = "projectId", EmitDefaultValue = false)]
		public List<string> ProjectId { get; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600009F RID: 159 RVA: 0x00004475 File Offset: 0x00002675
		[Preserve]
		[DataMember(Name = "environmentId", EmitDefaultValue = false)]
		public List<string> EnvironmentId { get; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x0000447D File Offset: 0x0000267D
		[Preserve]
		[DataMember(Name = "relayRegionId", EmitDefaultValue = false)]
		public List<string> RelayRegionId { get; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x00004485 File Offset: 0x00002685
		[Preserve]
		[DataMember(Name = "multiplayRegionId", EmitDefaultValue = false)]
		public List<string> MultiplayRegionId { get; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x0000448D File Offset: 0x0000268D
		[Preserve]
		[DataMember(Name = "multiplayFleetId", EmitDefaultValue = false)]
		public List<string> MultiplayFleetId { get; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x00004495 File Offset: 0x00002695
		[Preserve]
		[DataMember(Name = "matchmakerQueueName", EmitDefaultValue = false)]
		public List<string> MatchmakerQueueName { get; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x0000449D File Offset: 0x0000269D
		[Preserve]
		[DataMember(Name = "matchmakerPoolId", EmitDefaultValue = false)]
		public List<string> MatchmakerPoolId { get; }

		// Token: 0x060000A5 RID: 165 RVA: 0x000044A8 File Offset: 0x000026A8
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.ProjectId != null)
			{
				text = text + "projectId," + this.ProjectId.ToString() + ",";
			}
			if (this.EnvironmentId != null)
			{
				text = text + "environmentId," + this.EnvironmentId.ToString() + ",";
			}
			if (this.RelayRegionId != null)
			{
				text = text + "relayRegionId," + this.RelayRegionId.ToString() + ",";
			}
			if (this.MultiplayRegionId != null)
			{
				text = text + "multiplayRegionId," + this.MultiplayRegionId.ToString() + ",";
			}
			if (this.MultiplayFleetId != null)
			{
				text = text + "multiplayFleetId," + this.MultiplayFleetId.ToString() + ",";
			}
			if (this.MatchmakerQueueName != null)
			{
				text = text + "matchmakerQueueName," + this.MatchmakerQueueName.ToString() + ",";
			}
			if (this.MatchmakerPoolId != null)
			{
				text = text + "matchmakerPoolId," + this.MatchmakerPoolId.ToString();
			}
			return text;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x000045B4 File Offset: 0x000027B4
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (this.ProjectId != null)
			{
				string value = this.ProjectId.ToString();
				dictionary.Add("projectId", value);
			}
			if (this.EnvironmentId != null)
			{
				string value2 = this.EnvironmentId.ToString();
				dictionary.Add("environmentId", value2);
			}
			if (this.RelayRegionId != null)
			{
				string value3 = this.RelayRegionId.ToString();
				dictionary.Add("relayRegionId", value3);
			}
			if (this.MultiplayRegionId != null)
			{
				string value4 = this.MultiplayRegionId.ToString();
				dictionary.Add("multiplayRegionId", value4);
			}
			if (this.MultiplayFleetId != null)
			{
				string value5 = this.MultiplayFleetId.ToString();
				dictionary.Add("multiplayFleetId", value5);
			}
			if (this.MatchmakerQueueName != null)
			{
				string value6 = this.MatchmakerQueueName.ToString();
				dictionary.Add("matchmakerQueueName", value6);
			}
			if (this.MatchmakerPoolId != null)
			{
				string value7 = this.MatchmakerPoolId.ToString();
				dictionary.Add("matchmakerPoolId", value7);
			}
			return dictionary;
		}
	}
}
