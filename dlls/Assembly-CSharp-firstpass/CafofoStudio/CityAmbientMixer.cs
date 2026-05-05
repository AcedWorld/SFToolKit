using System;
using System.Collections.Generic;
using UnityEngine;

namespace CafofoStudio
{
	// Token: 0x020001CA RID: 458
	public class CityAmbientMixer : AmbienceMixer<CityAmbientPreset>
	{
		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06000C30 RID: 3120 RVA: 0x0004BC99 File Offset: 0x00049E99
		// (set) Token: 0x06000C31 RID: 3121 RVA: 0x0004BCA1 File Offset: 0x00049EA1
		public SoundElement Traffic
		{
			get
			{
				return this._traffic;
			}
			private set
			{
				this._traffic = this.Traffic;
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06000C32 RID: 3122 RVA: 0x0004BCAF File Offset: 0x00049EAF
		// (set) Token: 0x06000C33 RID: 3123 RVA: 0x0004BCB7 File Offset: 0x00049EB7
		public SoundElement Vehicles
		{
			get
			{
				return this._vehicles;
			}
			private set
			{
				this._vehicles = this.Vehicles;
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x06000C34 RID: 3124 RVA: 0x0004BCC5 File Offset: 0x00049EC5
		// (set) Token: 0x06000C35 RID: 3125 RVA: 0x0004BCCD File Offset: 0x00049ECD
		public SoundElement Crowd
		{
			get
			{
				return this._crowd;
			}
			private set
			{
				this._crowd = this.Crowd;
			}
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x06000C36 RID: 3126 RVA: 0x0004BCDB File Offset: 0x00049EDB
		// (set) Token: 0x06000C37 RID: 3127 RVA: 0x0004BCE3 File Offset: 0x00049EE3
		public SoundElement Construction
		{
			get
			{
				return this._construction;
			}
			private set
			{
				this._construction = this.Construction;
			}
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x06000C38 RID: 3128 RVA: 0x0004BCF1 File Offset: 0x00049EF1
		// (set) Token: 0x06000C39 RID: 3129 RVA: 0x0004BCF9 File Offset: 0x00049EF9
		public SoundElement Birds
		{
			get
			{
				return this._birds;
			}
			private set
			{
				this._birds = this.Birds;
			}
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06000C3A RID: 3130 RVA: 0x0004BD07 File Offset: 0x00049F07
		// (set) Token: 0x06000C3B RID: 3131 RVA: 0x0004BD0F File Offset: 0x00049F0F
		public SoundElement Rain
		{
			get
			{
				return this._rain;
			}
			private set
			{
				this._rain = this.Rain;
			}
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06000C3C RID: 3132 RVA: 0x0004BD20 File Offset: 0x00049F20
		protected override List<SoundElement> elements
		{
			get
			{
				return new List<SoundElement>
				{
					this._traffic,
					this._vehicles,
					this._crowd,
					this._construction,
					this._birds,
					this._rain
				};
			}
		}

		// Token: 0x06000C3D RID: 3133 RVA: 0x0004BD7C File Offset: 0x00049F7C
		public override void ApplyPreset(CityAmbientPreset selectedPreset)
		{
			this._traffic.SetIntensity(selectedPreset.trafficIntensity);
			this._traffic.SetVolumeMultiplier(selectedPreset.trafficVolumeMultiplier);
			this._vehicles.SetIntensity(selectedPreset.vehicleIntensity);
			this._vehicles.SetVolumeMultiplier(selectedPreset.vehicleVolumeMultiplier);
			this._crowd.SetIntensity(selectedPreset.crowdIntensity);
			this._crowd.SetVolumeMultiplier(selectedPreset.crowdVolumeMultiplier);
			this._construction.SetIntensity(selectedPreset.constructionIntensity);
			this._construction.SetVolumeMultiplier(selectedPreset.constructionVolumeMultiplier);
			this._birds.SetIntensity(selectedPreset.birdsIntensity);
			this._birds.SetVolumeMultiplier(selectedPreset.birdsVolumeMultiplier);
			this._rain.SetIntensity(selectedPreset.rainIntensity);
			this._rain.SetVolumeMultiplier(selectedPreset.rainVolumeMultiplier);
		}

		// Token: 0x04000C96 RID: 3222
		[SerializeField]
		private SoundElement _traffic;

		// Token: 0x04000C97 RID: 3223
		[SerializeField]
		private SoundElement _vehicles;

		// Token: 0x04000C98 RID: 3224
		[SerializeField]
		private SoundElement _crowd;

		// Token: 0x04000C99 RID: 3225
		[SerializeField]
		private SoundElement _construction;

		// Token: 0x04000C9A RID: 3226
		[SerializeField]
		private SoundElement _birds;

		// Token: 0x04000C9B RID: 3227
		[SerializeField]
		private SoundElement _rain;
	}
}
