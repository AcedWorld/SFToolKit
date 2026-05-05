using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200003D RID: 61
	internal class HDDebugDisplaySettings : DebugDisplaySettings<HDDebugDisplaySettings>
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000217 RID: 535 RVA: 0x0000C309 File Offset: 0x0000A509
		// (set) Token: 0x06000218 RID: 536 RVA: 0x0000C311 File Offset: 0x0000A511
		internal DebugDisplaySettingsVolume VolumeSettings { get; private set; }

		// Token: 0x0600021A RID: 538 RVA: 0x0000C322 File Offset: 0x0000A522
		public override void Reset()
		{
			base.Reset();
			this.VolumeSettings = base.Add<DebugDisplaySettingsVolume>(new DebugDisplaySettingsVolume(new HDVolumeDebugSettings()));
		}
	}
}
