using System;
using System.Runtime.CompilerServices;
using System.Text;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Interfaces;

namespace Rewired.Internal.Glyphs
{
	// Token: 0x0200046F RID: 1135
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal static class GlyphManager
	{
		// Token: 0x06002D2A RID: 11562 RVA: 0x00022BCF File Offset: 0x00020DCF
		public static void Initialize()
		{
			if (GlyphManager.yExpaTGVCDbSbLWkyIzngrFtTTJt != null)
			{
				throw new Exception("Already initialized");
			}
			GlyphManager.yExpaTGVCDbSbLWkyIzngrFtTTJt = new GlyphManager.OCaqFboDGMaBrqxTujAHYGkXAFao();
		}

		// Token: 0x06002D2B RID: 11563 RVA: 0x00022BED File Offset: 0x00020DED
		public static void Deinitialize()
		{
			if (GlyphManager.yExpaTGVCDbSbLWkyIzngrFtTTJt != null)
			{
				GlyphManager.yExpaTGVCDbSbLWkyIzngrFtTTJt = null;
			}
		}

		// Token: 0x17000AB7 RID: 2743
		// (get) Token: 0x06002D2C RID: 11564 RVA: 0x00022BFC File Offset: 0x00020DFC
		public static bool isEnabled
		{
			get
			{
				return GlyphManager.yExpaTGVCDbSbLWkyIzngrFtTTJt != null && GlyphManager.yExpaTGVCDbSbLWkyIzngrFtTTJt.HDEzwrbGfuZYYyANMaLrSKJZhkED != null;
			}
		}

		// Token: 0x17000AB8 RID: 2744
		// (get) Token: 0x06002D2D RID: 11565 RVA: 0x00022C14 File Offset: 0x00020E14
		public static uint version
		{
			get
			{
				GlyphManager.eyJysNMTAZhRsqzKCcIwlKUVtjBr();
				return GlyphManager.yExpaTGVCDbSbLWkyIzngrFtTTJt.hVvPvThtzvCaQpuluVMqawgzEkCn;
			}
		}

		// Token: 0x17000AB9 RID: 2745
		// (get) Token: 0x06002D2E RID: 11566 RVA: 0x00022C25 File Offset: 0x00020E25
		// (set) Token: 0x06002D2F RID: 11567 RVA: 0x00022C36 File Offset: 0x00020E36
		public static IGlyphProvider glyphProvider
		{
			get
			{
				GlyphManager.eyJysNMTAZhRsqzKCcIwlKUVtjBr();
				return GlyphManager.yExpaTGVCDbSbLWkyIzngrFtTTJt.HDEzwrbGfuZYYyANMaLrSKJZhkED;
			}
			set
			{
				GlyphManager.eyJysNMTAZhRsqzKCcIwlKUVtjBr();
				GlyphManager.yExpaTGVCDbSbLWkyIzngrFtTTJt.kFnGnXWPLYlptiDVPcsJjIZvEYZL(value);
			}
		}

		// Token: 0x17000ABA RID: 2746
		// (get) Token: 0x06002D30 RID: 11568 RVA: 0x00022C48 File Offset: 0x00020E48
		// (set) Token: 0x06002D31 RID: 11569 RVA: 0x00022C59 File Offset: 0x00020E59
		public static bool autoPrefetch
		{
			get
			{
				GlyphManager.eyJysNMTAZhRsqzKCcIwlKUVtjBr();
				return GlyphManager.yExpaTGVCDbSbLWkyIzngrFtTTJt.cNVeLpkhYhrwPITfssXOhcSeBDzgb;
			}
			set
			{
				GlyphManager.eyJysNMTAZhRsqzKCcIwlKUVtjBr();
				GlyphManager.yExpaTGVCDbSbLWkyIzngrFtTTJt.JdzMBbFXzbklGiNgFmuwouNNiPZv(value);
			}
		}

		// Token: 0x06002D32 RID: 11570 RVA: 0x00022C6B File Offset: 0x00020E6B
		public static void Add(IPrefetch obj, ref Id id)
		{
			GlyphManager.eyJysNMTAZhRsqzKCcIwlKUVtjBr();
			id = GlyphManager.yExpaTGVCDbSbLWkyIzngrFtTTJt.vIjbHOeJdFoxsFTfXKFhhhPhOGOoB(obj);
		}

		// Token: 0x06002D33 RID: 11571 RVA: 0x00022C88 File Offset: 0x00020E88
		public static bool Remove(ref Id id)
		{
			GlyphManager.eyJysNMTAZhRsqzKCcIwlKUVtjBr();
			bool result = GlyphManager.yExpaTGVCDbSbLWkyIzngrFtTTJt.rVDhNzuKhfirRQZXrVQWSvpxwuqg(id);
			id = 0U;
			return result;
		}

		// Token: 0x06002D34 RID: 11572 RVA: 0x00022CB0 File Offset: 0x00020EB0
		public static void Prefetch()
		{
			GlyphManager.eyJysNMTAZhRsqzKCcIwlKUVtjBr();
			GlyphManager.yExpaTGVCDbSbLWkyIzngrFtTTJt.bLofEOsUXFyleVyQVpprJqzMWKoc();
		}

		// Token: 0x06002D35 RID: 11573 RVA: 0x00022CC1 File Offset: 0x00020EC1
		public static void Reload()
		{
			GlyphManager.eyJysNMTAZhRsqzKCcIwlKUVtjBr();
			GlyphManager.yExpaTGVCDbSbLWkyIzngrFtTTJt.suZidRHwGeTseTSYCMxzdNnUvlmv();
		}

		// Token: 0x06002D36 RID: 11574 RVA: 0x00022CD2 File Offset: 0x00020ED2
		private static void eyJysNMTAZhRsqzKCcIwlKUVtjBr()
		{
			if (GlyphManager.yExpaTGVCDbSbLWkyIzngrFtTTJt == null)
			{
				throw new Exception(typeof(GlyphManager).Name + " is not initialized.");
			}
		}

		// Token: 0x06002D37 RID: 11575 RVA: 0x00022CFA File Offset: 0x00020EFA
		public static bool TryGetCachedGlyph(KeyedGlyph keyedGlyph, uint glyphProviderVersion, uint dependenciesVersion, out bool glyphProviderVersionChanged, out object result)
		{
			if (GlyphManager.yExpaTGVCDbSbLWkyIzngrFtTTJt.HDEzwrbGfuZYYyANMaLrSKJZhkED != null)
			{
				return keyedGlyph.TryGetValue(null, GlyphManager.yExpaTGVCDbSbLWkyIzngrFtTTJt.HDEzwrbGfuZYYyANMaLrSKJZhkED, GlyphManager.yExpaTGVCDbSbLWkyIzngrFtTTJt.hVvPvThtzvCaQpuluVMqawgzEkCn, dependenciesVersion, out glyphProviderVersionChanged, out result);
			}
			result = null;
			glyphProviderVersionChanged = false;
			return false;
		}

		// Token: 0x06002D38 RID: 11576 RVA: 0x0009FA40 File Offset: 0x0009DC40
		public static bool TryGetGlyph(KeyedGlyph keyedGlyph, string key, uint glyphProviderVersion, uint dependenciesVersion, out object result)
		{
			if (GlyphManager.yExpaTGVCDbSbLWkyIzngrFtTTJt.HDEzwrbGfuZYYyANMaLrSKJZhkED != null)
			{
				keyedGlyph.Clear();
				bool flag;
				return keyedGlyph.TryGetValue(key, GlyphManager.yExpaTGVCDbSbLWkyIzngrFtTTJt.HDEzwrbGfuZYYyANMaLrSKJZhkED, GlyphManager.yExpaTGVCDbSbLWkyIzngrFtTTJt.hVvPvThtzvCaQpuluVMqawgzEkCn, dependenciesVersion, out flag, out result);
			}
			result = null;
			return false;
		}

		// Token: 0x06002D39 RID: 11577 RVA: 0x0009FA88 File Offset: 0x0009DC88
		public static GlyphManager.GetAndUpdateGlyphResultFlags GetAndUpdateGlyph(KeyedGlyph keyedGlyph, IReadOnlyList<string> parentKeys, string keyCategory, out object result)
		{
			if (GlyphManager.yExpaTGVCDbSbLWkyIzngrFtTTJt.HDEzwrbGfuZYYyANMaLrSKJZhkED == null)
			{
				result = null;
				return GlyphManager.GetAndUpdateGlyphResultFlags.Failed;
			}
			bool flag;
			GlyphManager.GetAndUpdateGlyphResultFlags getAndUpdateGlyphResultFlags;
			if (GlyphManager.TryGetCachedGlyph(keyedGlyph, GlyphManager.yExpaTGVCDbSbLWkyIzngrFtTTJt.hVvPvThtzvCaQpuluVMqawgzEkCn, 0U, out flag, out result))
			{
				getAndUpdateGlyphResultFlags = GlyphManager.GetAndUpdateGlyphResultFlags.IsCachedValue;
			}
			else
			{
				getAndUpdateGlyphResultFlags = GlyphManager.GetAndUpdateGlyphResultFlags.Failed;
			}
			if (!keyedGlyph.hasCachedValue || flag)
			{
				getAndUpdateGlyphResultFlags |= GlyphManager.GetAndUpdateGlyphResultFlags.Changed;
				if (GlyphManager.TNLkNQNLkqjsCDgQkbOAMDLyCONu(keyedGlyph, parentKeys, keyCategory, out result))
				{
					getAndUpdateGlyphResultFlags |= GlyphManager.GetAndUpdateGlyphResultFlags.JustGot;
					getAndUpdateGlyphResultFlags &= (GlyphManager.GetAndUpdateGlyphResultFlags)(-2);
				}
				else
				{
					getAndUpdateGlyphResultFlags |= GlyphManager.GetAndUpdateGlyphResultFlags.Failed;
				}
			}
			return getAndUpdateGlyphResultFlags;
		}

		// Token: 0x06002D3A RID: 11578 RVA: 0x0009FAF0 File Offset: 0x0009DCF0
		public static GlyphManager.GetAndUpdateGlyphResultFlags GetAndUpdateGlyph(KeyedGlyph keyedGlyph, string key, string keyCategory, IReadOnlyList<string> parentKeys, out object result)
		{
			if (GlyphManager.yExpaTGVCDbSbLWkyIzngrFtTTJt.HDEzwrbGfuZYYyANMaLrSKJZhkED == null)
			{
				result = null;
				return GlyphManager.GetAndUpdateGlyphResultFlags.Failed;
			}
			bool flag;
			GlyphManager.GetAndUpdateGlyphResultFlags getAndUpdateGlyphResultFlags;
			if (GlyphManager.TryGetCachedGlyph(keyedGlyph, GlyphManager.yExpaTGVCDbSbLWkyIzngrFtTTJt.hVvPvThtzvCaQpuluVMqawgzEkCn, 0U, out flag, out result))
			{
				getAndUpdateGlyphResultFlags = GlyphManager.GetAndUpdateGlyphResultFlags.IsCachedValue;
			}
			else
			{
				getAndUpdateGlyphResultFlags = GlyphManager.GetAndUpdateGlyphResultFlags.Failed;
			}
			if (!keyedGlyph.hasCachedValue || flag)
			{
				getAndUpdateGlyphResultFlags |= GlyphManager.GetAndUpdateGlyphResultFlags.Changed;
				if (GlyphManager.rRJtXaHlXTLVbqdofapIrljTogWu(keyedGlyph, key, keyCategory, parentKeys, out result))
				{
					getAndUpdateGlyphResultFlags |= GlyphManager.GetAndUpdateGlyphResultFlags.JustGot;
					getAndUpdateGlyphResultFlags &= (GlyphManager.GetAndUpdateGlyphResultFlags)(-2);
				}
				else
				{
					getAndUpdateGlyphResultFlags |= GlyphManager.GetAndUpdateGlyphResultFlags.Failed;
				}
			}
			return getAndUpdateGlyphResultFlags;
		}

		// Token: 0x06002D3B RID: 11579 RVA: 0x0009FB5C File Offset: 0x0009DD5C
		private static bool TNLkNQNLkqjsCDgQkbOAMDLyCONu(KeyedGlyph A_0, IReadOnlyList<string> A_1, string A_2, out object A_3)
		{
			if (A_1 == null)
			{
				A_3 = null;
				return false;
			}
			bool result = false;
			bool flag = !string.IsNullOrEmpty(A_2);
			StringBuilder sharedStringBuilder = GlyphManager.GetSharedStringBuilder();
			for (int i = 0; i < A_1.Count; i++)
			{
				if (!string.IsNullOrEmpty(A_1[i]))
				{
					sharedStringBuilder.Length = 0;
					if (flag)
					{
						sharedStringBuilder.Append(A_2);
					}
					LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, A_1[i]);
					if (GlyphManager.TryGetGlyph(A_0, sharedStringBuilder.ToString(), GlyphManager.yExpaTGVCDbSbLWkyIzngrFtTTJt.hVvPvThtzvCaQpuluVMqawgzEkCn, 0U, out A_3))
					{
						result = true;
						IL_7A:
						A_0.cachedValue = A_3;
						return result;
					}
				}
			}
			A_3 = null;
			goto IL_7A;
		}

		// Token: 0x06002D3C RID: 11580 RVA: 0x0009FBEC File Offset: 0x0009DDEC
		private static bool rRJtXaHlXTLVbqdofapIrljTogWu(KeyedGlyph A_0, string A_1, string A_2, IReadOnlyList<string> A_3, out object A_4)
		{
			if (string.IsNullOrEmpty(A_1))
			{
				A_4 = null;
				return false;
			}
			bool result = false;
			uint dependenciesVersion = 0U;
			bool flag = !string.IsNullOrEmpty(A_2);
			StringBuilder sharedStringBuilder = GlyphManager.GetSharedStringBuilder();
			if (A_3 != null)
			{
				for (int i = 0; i < A_3.Count; i++)
				{
					if (!string.IsNullOrEmpty(A_3[i]))
					{
						sharedStringBuilder.Length = 0;
						if (flag)
						{
							sharedStringBuilder.Append(A_2);
						}
						LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, A_3[i]);
						LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, A_1);
						if (GlyphManager.TryGetGlyph(A_0, sharedStringBuilder.ToString(), GlyphManager.yExpaTGVCDbSbLWkyIzngrFtTTJt.hVvPvThtzvCaQpuluVMqawgzEkCn, dependenciesVersion, out A_4))
						{
							result = true;
							goto IL_D9;
						}
					}
				}
			}
			if (A_3 == null || A_3.Count == 0)
			{
				sharedStringBuilder.Length = 0;
				if (flag)
				{
					sharedStringBuilder.Append(A_2);
				}
				LocalizationManager.AppendToKeyAsPath(sharedStringBuilder, A_1);
				if (GlyphManager.TryGetGlyph(A_0, sharedStringBuilder.ToString(), GlyphManager.yExpaTGVCDbSbLWkyIzngrFtTTJt.hVvPvThtzvCaQpuluVMqawgzEkCn, dependenciesVersion, out A_4))
				{
					result = true;
					goto IL_D9;
				}
			}
			A_4 = null;
			IL_D9:
			A_0.cachedValue = A_4;
			return result;
		}

		// Token: 0x06002D3D RID: 11581 RVA: 0x00022D30 File Offset: 0x00020F30
		[CustomObfuscation(rename = false)]
		public static StringBuilder GetSharedStringBuilder()
		{
			if (GlyphManager.fWfHZpPInsTslnobrdsksPjCRFjN != null)
			{
				GlyphManager.fWfHZpPInsTslnobrdsksPjCRFjN.Length = 0;
				return GlyphManager.fWfHZpPInsTslnobrdsksPjCRFjN;
			}
			return GlyphManager.fWfHZpPInsTslnobrdsksPjCRFjN = new StringBuilder();
		}

		// Token: 0x04001970 RID: 6512
		private static GlyphManager.OCaqFboDGMaBrqxTujAHYGkXAFao yExpaTGVCDbSbLWkyIzngrFtTTJt;

		// Token: 0x04001971 RID: 6513
		private static StringBuilder fWfHZpPInsTslnobrdsksPjCRFjN;

		// Token: 0x02000470 RID: 1136
		private sealed class OCaqFboDGMaBrqxTujAHYGkXAFao
		{
			// Token: 0x06002D3E RID: 11582 RVA: 0x0009FCDC File Offset: 0x0009DEDC
			public OCaqFboDGMaBrqxTujAHYGkXAFao()
			{
				this.qjgBJtbSlqbzYGSbGlgNzHAicgNMB = new RvmIJGbAvRTGQGQgDEFpplYzZpWu<IPrefetch>(60f);
				this.hVvPvThtzvCaQpuluVMqawgzEkCn = 0U;
				this.MLRUUwpFpwHsaPERbleyUqtVJdTI = 1U;
			}

			// Token: 0x06002D3F RID: 11583 RVA: 0x00022D55 File Offset: 0x00020F55
			public void kFnGnXWPLYlptiDVPcsJjIZvEYZL(IGlyphProvider A_1)
			{
				this.HDEzwrbGfuZYYyANMaLrSKJZhkED = A_1;
				if (A_1 != null)
				{
					this.hVvPvThtzvCaQpuluVMqawgzEkCn = this.MLRUUwpFpwHsaPERbleyUqtVJdTI.id;
					this.MLRUUwpFpwHsaPERbleyUqtVJdTI.Increment();
				}
				else
				{
					this.hVvPvThtzvCaQpuluVMqawgzEkCn = 0U;
				}
				this.lCdfVuimvSvQYDcCBaquAIorpXMCA();
			}

			// Token: 0x06002D40 RID: 11584 RVA: 0x00022D8C File Offset: 0x00020F8C
			public void JdzMBbFXzbklGiNgFmuwouNNiPZv(bool A_1)
			{
				if (A_1 == this.cNVeLpkhYhrwPITfssXOhcSeBDzgb)
				{
					return;
				}
				this.cNVeLpkhYhrwPITfssXOhcSeBDzgb = A_1;
				if (A_1)
				{
					this.bLofEOsUXFyleVyQVpprJqzMWKoc();
				}
			}

			// Token: 0x06002D41 RID: 11585 RVA: 0x00022DA8 File Offset: 0x00020FA8
			public void bLofEOsUXFyleVyQVpprJqzMWKoc()
			{
				if (this.HDEzwrbGfuZYYyANMaLrSKJZhkED == null)
				{
					return;
				}
				this.qjgBJtbSlqbzYGSbGlgNzHAicgNMB.zAXkItAZChRgPbCJeFkkCtqIPkzMA(this.GcRBPUBicFRoXXwlxTmvlBJVMQtD);
			}

			// Token: 0x06002D42 RID: 11586 RVA: 0x00022DC4 File Offset: 0x00020FC4
			public void suZidRHwGeTseTSYCMxzdNnUvlmv()
			{
				if (this.HDEzwrbGfuZYYyANMaLrSKJZhkED == null)
				{
					return;
				}
				this.hVvPvThtzvCaQpuluVMqawgzEkCn = this.MLRUUwpFpwHsaPERbleyUqtVJdTI.id;
				this.MLRUUwpFpwHsaPERbleyUqtVJdTI.Increment();
				if (this.cNVeLpkhYhrwPITfssXOhcSeBDzgb)
				{
					this.bLofEOsUXFyleVyQVpprJqzMWKoc();
					return;
				}
				this.lCdfVuimvSvQYDcCBaquAIorpXMCA();
			}

			// Token: 0x06002D43 RID: 11587 RVA: 0x00022E00 File Offset: 0x00021000
			public uint vIjbHOeJdFoxsFTfXKFhhhPhOGOoB(IPrefetch A_1)
			{
				return this.qjgBJtbSlqbzYGSbGlgNzHAicgNMB.aMahfZqbBrbegzXkZEXwZfqhtBZj(A_1);
			}

			// Token: 0x06002D44 RID: 11588 RVA: 0x00022E0E File Offset: 0x0002100E
			public bool rVDhNzuKhfirRQZXrVQWSvpxwuqg(uint A_1)
			{
				return this.qjgBJtbSlqbzYGSbGlgNzHAicgNMB.rzTgCniDYAFMijOABRyLzSxcXWZjB(A_1);
			}

			// Token: 0x06002D45 RID: 11589 RVA: 0x00022E1C File Offset: 0x0002101C
			public void lCdfVuimvSvQYDcCBaquAIorpXMCA()
			{
				this.qjgBJtbSlqbzYGSbGlgNzHAicgNMB.JzGoTFqpGdYkTUxcryLnTUHbIotE();
			}

			// Token: 0x04001972 RID: 6514
			private const float tDIObNhoEOGThOLDUxMBnMceupfP = 60f;

			// Token: 0x04001973 RID: 6515
			private readonly RvmIJGbAvRTGQGQgDEFpplYzZpWu<IPrefetch> qjgBJtbSlqbzYGSbGlgNzHAicgNMB;

			// Token: 0x04001974 RID: 6516
			public bool cNVeLpkhYhrwPITfssXOhcSeBDzgb;

			// Token: 0x04001975 RID: 6517
			public IGlyphProvider HDEzwrbGfuZYYyANMaLrSKJZhkED;

			// Token: 0x04001976 RID: 6518
			public uint hVvPvThtzvCaQpuluVMqawgzEkCn;

			// Token: 0x04001977 RID: 6519
			private Action<IPrefetch> GcRBPUBicFRoXXwlxTmvlBJVMQtD = new Action<IPrefetch>(GlyphManager.OCaqFboDGMaBrqxTujAHYGkXAFao.axqOUoQjwHBcoQCNzgOcZSULibKT.<>9.iiqqBmMgbUtoeduXxPZzODzXfIUx);

			// Token: 0x04001978 RID: 6520
			private Id MLRUUwpFpwHsaPERbleyUqtVJdTI;

			// Token: 0x02000471 RID: 1137
			[CompilerGenerated]
			[Serializable]
			private sealed class axqOUoQjwHBcoQCNzgOcZSULibKT
			{
				// Token: 0x06002D48 RID: 11592 RVA: 0x00022E35 File Offset: 0x00021035
				internal void iiqqBmMgbUtoeduXxPZzODzXfIUx(IPrefetch A_1)
				{
					A_1.Prefetch();
				}

				// Token: 0x04001979 RID: 6521
				public static readonly GlyphManager.OCaqFboDGMaBrqxTujAHYGkXAFao.axqOUoQjwHBcoQCNzgOcZSULibKT <>9 = new GlyphManager.OCaqFboDGMaBrqxTujAHYGkXAFao.axqOUoQjwHBcoQCNzgOcZSULibKT();

				// Token: 0x0400197A RID: 6522
				public static Action<IPrefetch> <>9__7_0;
			}
		}

		// Token: 0x02000472 RID: 1138
		[CustomObfuscation(rename = false)]
		public enum GetAndUpdateGlyphResultFlags
		{
			// Token: 0x0400197C RID: 6524
			None,
			// Token: 0x0400197D RID: 6525
			Failed,
			// Token: 0x0400197E RID: 6526
			IsCachedValue,
			// Token: 0x0400197F RID: 6527
			Changed = 4,
			// Token: 0x04001980 RID: 6528
			JustGot = 8
		}
	}
}
