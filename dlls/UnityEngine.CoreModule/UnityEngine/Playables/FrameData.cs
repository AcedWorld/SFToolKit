using System;

namespace UnityEngine.Playables
{
	// Token: 0x0200048E RID: 1166
	public struct FrameData
	{
		// Token: 0x0600283A RID: 10298 RVA: 0x00044F94 File Offset: 0x00043194
		private bool HasFlags(FrameData.Flags flag)
		{
			return (this.m_Flags & flag) == flag;
		}

		// Token: 0x17000786 RID: 1926
		// (get) Token: 0x0600283B RID: 10299 RVA: 0x00044FB4 File Offset: 0x000431B4
		public ulong frameId
		{
			get
			{
				return this.m_FrameID;
			}
		}

		// Token: 0x17000787 RID: 1927
		// (get) Token: 0x0600283C RID: 10300 RVA: 0x00044FCC File Offset: 0x000431CC
		public float deltaTime
		{
			get
			{
				return (float)this.m_DeltaTime;
			}
		}

		// Token: 0x17000788 RID: 1928
		// (get) Token: 0x0600283D RID: 10301 RVA: 0x00044FE8 File Offset: 0x000431E8
		public float weight
		{
			get
			{
				return this.m_Weight;
			}
		}

		// Token: 0x17000789 RID: 1929
		// (get) Token: 0x0600283E RID: 10302 RVA: 0x00045000 File Offset: 0x00043200
		public float effectiveWeight
		{
			get
			{
				return this.m_EffectiveWeight;
			}
		}

		// Token: 0x1700078A RID: 1930
		// (get) Token: 0x0600283F RID: 10303 RVA: 0x00045018 File Offset: 0x00043218
		[Obsolete("effectiveParentDelay is obsolete; use a custom ScriptPlayable to implement this feature", false)]
		public double effectiveParentDelay
		{
			get
			{
				return this.m_EffectiveParentDelay;
			}
		}

		// Token: 0x1700078B RID: 1931
		// (get) Token: 0x06002840 RID: 10304 RVA: 0x00045030 File Offset: 0x00043230
		public float effectiveParentSpeed
		{
			get
			{
				return this.m_EffectiveParentSpeed;
			}
		}

		// Token: 0x1700078C RID: 1932
		// (get) Token: 0x06002841 RID: 10305 RVA: 0x00045048 File Offset: 0x00043248
		public float effectiveSpeed
		{
			get
			{
				return this.m_EffectiveSpeed;
			}
		}

		// Token: 0x1700078D RID: 1933
		// (get) Token: 0x06002842 RID: 10306 RVA: 0x00045060 File Offset: 0x00043260
		public FrameData.EvaluationType evaluationType
		{
			get
			{
				return this.HasFlags(FrameData.Flags.Evaluate) ? FrameData.EvaluationType.Evaluate : FrameData.EvaluationType.Playback;
			}
		}

		// Token: 0x1700078E RID: 1934
		// (get) Token: 0x06002843 RID: 10307 RVA: 0x00045080 File Offset: 0x00043280
		public bool seekOccurred
		{
			get
			{
				return this.HasFlags(FrameData.Flags.SeekOccured);
			}
		}

		// Token: 0x1700078F RID: 1935
		// (get) Token: 0x06002844 RID: 10308 RVA: 0x0004509C File Offset: 0x0004329C
		public bool timeLooped
		{
			get
			{
				return this.HasFlags(FrameData.Flags.Loop);
			}
		}

		// Token: 0x17000790 RID: 1936
		// (get) Token: 0x06002845 RID: 10309 RVA: 0x000450B8 File Offset: 0x000432B8
		public bool timeHeld
		{
			get
			{
				return this.HasFlags(FrameData.Flags.Hold);
			}
		}

		// Token: 0x17000791 RID: 1937
		// (get) Token: 0x06002846 RID: 10310 RVA: 0x000450D4 File Offset: 0x000432D4
		public PlayableOutput output
		{
			get
			{
				return this.m_Output;
			}
		}

		// Token: 0x17000792 RID: 1938
		// (get) Token: 0x06002847 RID: 10311 RVA: 0x000450EC File Offset: 0x000432EC
		public PlayState effectivePlayState
		{
			get
			{
				bool flag = this.HasFlags(FrameData.Flags.EffectivePlayStateDelayed);
				PlayState result;
				if (flag)
				{
					result = PlayState.Delayed;
				}
				else
				{
					bool flag2 = this.HasFlags(FrameData.Flags.EffectivePlayStatePlaying);
					if (flag2)
					{
						result = PlayState.Playing;
					}
					else
					{
						result = PlayState.Paused;
					}
				}
				return result;
			}
		}

		// Token: 0x04000F3E RID: 3902
		internal ulong m_FrameID;

		// Token: 0x04000F3F RID: 3903
		internal double m_DeltaTime;

		// Token: 0x04000F40 RID: 3904
		internal float m_Weight;

		// Token: 0x04000F41 RID: 3905
		internal float m_EffectiveWeight;

		// Token: 0x04000F42 RID: 3906
		internal double m_EffectiveParentDelay;

		// Token: 0x04000F43 RID: 3907
		internal float m_EffectiveParentSpeed;

		// Token: 0x04000F44 RID: 3908
		internal float m_EffectiveSpeed;

		// Token: 0x04000F45 RID: 3909
		internal FrameData.Flags m_Flags;

		// Token: 0x04000F46 RID: 3910
		internal PlayableOutput m_Output;

		// Token: 0x0200048F RID: 1167
		[Flags]
		internal enum Flags
		{
			// Token: 0x04000F48 RID: 3912
			Evaluate = 1,
			// Token: 0x04000F49 RID: 3913
			SeekOccured = 2,
			// Token: 0x04000F4A RID: 3914
			Loop = 4,
			// Token: 0x04000F4B RID: 3915
			Hold = 8,
			// Token: 0x04000F4C RID: 3916
			EffectivePlayStateDelayed = 16,
			// Token: 0x04000F4D RID: 3917
			EffectivePlayStatePlaying = 32
		}

		// Token: 0x02000490 RID: 1168
		public enum EvaluationType
		{
			// Token: 0x04000F4F RID: 3919
			Evaluate,
			// Token: 0x04000F50 RID: 3920
			Playback
		}
	}
}
