using System;

namespace Unity.Networking.Transport.Utilities
{
	// Token: 0x020000C0 RID: 192
	public static class SimulatorStageParameterExtensions
	{
		// Token: 0x060002E4 RID: 740 RVA: 0x00010794 File Offset: 0x0000E994
		public static ref NetworkSettings WithSimulatorStageParameters(this NetworkSettings settings, int maxPacketCount, int maxPacketSize, int packetDelayMs = 0, int packetJitterMs = 0, int packetDropInterval = 0, int packetDropPercentage = 0, int fuzzFactor = 0, int fuzzOffset = 0, uint randomSeed = 0U)
		{
			SimulatorUtility.Parameters parameters = new SimulatorUtility.Parameters
			{
				MaxPacketCount = maxPacketCount,
				MaxPacketSize = maxPacketSize,
				PacketDelayMs = packetDelayMs,
				PacketJitterMs = packetJitterMs,
				PacketDropInterval = packetDropInterval,
				PacketDropPercentage = packetDropPercentage,
				FuzzFactor = fuzzFactor,
				FuzzOffset = fuzzOffset,
				RandomSeed = randomSeed
			};
			settings.AddRawParameterStruct<SimulatorUtility.Parameters>(ref parameters);
			return ref settings;
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x00010804 File Offset: 0x0000EA04
		public static SimulatorUtility.Parameters GetSimulatorStageParameters(this NetworkSettings settings)
		{
			SimulatorUtility.Parameters result;
			settings.TryGet<SimulatorUtility.Parameters>(out result);
			return result;
		}
	}
}
