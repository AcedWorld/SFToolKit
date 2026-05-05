using System;
using System.Collections.Generic;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x0200007E RID: 126
	[AddComponentMenu("Scripts/RootMotion.Dynamics/PuppetMaster/PuppetMaster Settings")]
	public class PuppetMasterSettings : Singleton<PuppetMasterSettings>
	{
		// Token: 0x17000077 RID: 119
		// (get) Token: 0x0600040C RID: 1036 RVA: 0x00018253 File Offset: 0x00016453
		// (set) Token: 0x0600040D RID: 1037 RVA: 0x0001825B File Offset: 0x0001645B
		public int currentlyActivePuppets { get; private set; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x0600040E RID: 1038 RVA: 0x00018264 File Offset: 0x00016464
		// (set) Token: 0x0600040F RID: 1039 RVA: 0x0001826C File Offset: 0x0001646C
		public int currentlyKinematicPuppets { get; private set; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000410 RID: 1040 RVA: 0x00018275 File Offset: 0x00016475
		// (set) Token: 0x06000411 RID: 1041 RVA: 0x0001827D File Offset: 0x0001647D
		public int currentlyDisabledPuppets { get; private set; }

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000412 RID: 1042 RVA: 0x00018286 File Offset: 0x00016486
		public List<PuppetMaster> puppets
		{
			get
			{
				return this._puppets;
			}
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x0001828E File Offset: 0x0001648E
		public void Register(PuppetMaster puppetMaster)
		{
			if (this._puppets.Contains(puppetMaster))
			{
				return;
			}
			this._puppets.Add(puppetMaster);
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x000182AB File Offset: 0x000164AB
		public void Unregister(PuppetMaster puppetMaster)
		{
			this._puppets.Remove(puppetMaster);
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x000182BA File Offset: 0x000164BA
		public bool UpdateMoveToTarget(PuppetMaster puppetMaster)
		{
			return this.kinematicCollidersUpdateLimit.Update(this._puppets, puppetMaster);
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x000182CE File Offset: 0x000164CE
		public bool UpdateFree(PuppetMaster puppetMaster)
		{
			return this.freeUpdateLimit.Update(this._puppets, puppetMaster);
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x000182E2 File Offset: 0x000164E2
		public bool UpdateFixed(PuppetMaster puppetMaster)
		{
			return this.fixedUpdateLimit.Update(this._puppets, puppetMaster);
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x000182F8 File Offset: 0x000164F8
		private void Update()
		{
			this.currentlyActivePuppets = 0;
			this.currentlyKinematicPuppets = 0;
			this.currentlyDisabledPuppets = 0;
			foreach (PuppetMaster puppetMaster in this._puppets)
			{
				if (puppetMaster.isActive && puppetMaster.isActiveAndEnabled)
				{
					int num = this.currentlyActivePuppets;
					this.currentlyActivePuppets = num + 1;
				}
				if (puppetMaster.mode == PuppetMaster.Mode.Kinematic)
				{
					int num = this.currentlyKinematicPuppets;
					this.currentlyKinematicPuppets = num + 1;
				}
				if ((puppetMaster.mode == PuppetMaster.Mode.Disabled && !puppetMaster.isActive) || !puppetMaster.isActiveAndEnabled)
				{
					int num = this.currentlyDisabledPuppets;
					this.currentlyDisabledPuppets = num + 1;
				}
			}
			this.freeUpdateLimit.Step(this._puppets.Count);
			this.kinematicCollidersUpdateLimit.Step(this._puppets.Count);
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x000183E8 File Offset: 0x000165E8
		private void FixedUpdate()
		{
			this.fixedUpdateLimit.Step(this._puppets.Count);
		}

		// Token: 0x040003A1 RID: 929
		[Header("Optimizations")]
		public PuppetMasterSettings.PuppetUpdateLimit kinematicCollidersUpdateLimit = new PuppetMasterSettings.PuppetUpdateLimit();

		// Token: 0x040003A2 RID: 930
		public PuppetMasterSettings.PuppetUpdateLimit freeUpdateLimit = new PuppetMasterSettings.PuppetUpdateLimit();

		// Token: 0x040003A3 RID: 931
		public PuppetMasterSettings.PuppetUpdateLimit fixedUpdateLimit = new PuppetMasterSettings.PuppetUpdateLimit();

		// Token: 0x040003A4 RID: 932
		public bool collisionStayMessages = true;

		// Token: 0x040003A5 RID: 933
		public bool collisionExitMessages = true;

		// Token: 0x040003A6 RID: 934
		public float activePuppetCollisionThresholdMlp;

		// Token: 0x040003AA RID: 938
		private List<PuppetMaster> _puppets = new List<PuppetMaster>();

		// Token: 0x0200007F RID: 127
		[Serializable]
		public class PuppetUpdateLimit
		{
			// Token: 0x0600041B RID: 1051 RVA: 0x0001844D File Offset: 0x0001664D
			public PuppetUpdateLimit()
			{
				this.puppetsPerFrame = 100;
			}

			// Token: 0x0600041C RID: 1052 RVA: 0x0001845D File Offset: 0x0001665D
			public void Step(int puppetCount)
			{
				this.index += this.puppetsPerFrame;
				if (this.index >= puppetCount)
				{
					this.index -= puppetCount;
				}
			}

			// Token: 0x0600041D RID: 1053 RVA: 0x0001848C File Offset: 0x0001668C
			public bool Update(List<PuppetMaster> puppets, PuppetMaster puppetMaster)
			{
				if (this.puppetsPerFrame >= puppets.Count)
				{
					return true;
				}
				if (this.index >= puppets.Count)
				{
					return false;
				}
				for (int i = 0; i < this.puppetsPerFrame; i++)
				{
					int num = this.index + i;
					if (num >= puppets.Count)
					{
						num -= puppets.Count;
					}
					if (puppets[num] == puppetMaster)
					{
						return true;
					}
				}
				return false;
			}

			// Token: 0x040003AB RID: 939
			[Range(1f, 100f)]
			public int puppetsPerFrame;

			// Token: 0x040003AC RID: 940
			private int index;
		}
	}
}
