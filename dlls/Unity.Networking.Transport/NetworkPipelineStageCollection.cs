using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.Networking.Transport
{
	// Token: 0x02000051 RID: 81
	public static class NetworkPipelineStageCollection
	{
		// Token: 0x06000195 RID: 405 RVA: 0x00008AC8 File Offset: 0x00006CC8
		static NetworkPipelineStageCollection()
		{
			NetworkPipelineStageCollection.RegisterPipelineStage(default(NullPipelineStage));
			NetworkPipelineStageCollection.RegisterPipelineStage(default(FragmentationPipelineStage));
			NetworkPipelineStageCollection.RegisterPipelineStage(default(ReliableSequencedPipelineStage));
			NetworkPipelineStageCollection.RegisterPipelineStage(default(UnreliableSequencedPipelineStage));
			NetworkPipelineStageCollection.RegisterPipelineStage(default(SimulatorPipelineStage));
			NetworkPipelineStageCollection.RegisterPipelineStage(default(SimulatorPipelineStageInSend));
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00008B54 File Offset: 0x00006D54
		public static void RegisterPipelineStage(INetworkPipelineStage stage)
		{
			for (int i = 0; i < NetworkPipelineStageCollection.m_stages.Count; i++)
			{
				if (NetworkPipelineStageCollection.m_stages[i].GetType() == stage.GetType())
				{
					NetworkPipelineStageCollection.m_stages[i] = stage;
					return;
				}
			}
			NetworkPipelineStageCollection.m_stages.Add(stage);
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00008BAC File Offset: 0x00006DAC
		public static NetworkPipelineStageId GetStageId(Type stageType)
		{
			for (int i = 0; i < NetworkPipelineStageCollection.m_stages.Count; i++)
			{
				if (stageType == NetworkPipelineStageCollection.m_stages[i].GetType())
				{
					return new NetworkPipelineStageId
					{
						Index = i,
						IsValid = 1
					};
				}
			}
			Debug.LogError(string.Format("Pipeline stage {0} is not registered", stageType));
			return default(NetworkPipelineStageId);
		}

		// Token: 0x04000114 RID: 276
		internal static List<INetworkPipelineStage> m_stages = new List<INetworkPipelineStage>();
	}
}
