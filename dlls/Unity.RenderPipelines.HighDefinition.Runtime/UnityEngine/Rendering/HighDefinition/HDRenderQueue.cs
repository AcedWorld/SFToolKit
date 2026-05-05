using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000168 RID: 360
	internal static class HDRenderQueue
	{
		// Token: 0x06000C17 RID: 3095 RVA: 0x00060CD4 File Offset: 0x0005EED4
		internal static HDRenderQueue.RenderQueueType MigrateRenderQueueToHDRP10(HDRenderQueue.RenderQueueType renderQueue)
		{
			switch (renderQueue)
			{
			case HDRenderQueue.RenderQueueType.Background:
				return HDRenderQueue.RenderQueueType.Background;
			case HDRenderQueue.RenderQueueType.Opaque:
				return HDRenderQueue.RenderQueueType.Opaque;
			case HDRenderQueue.RenderQueueType.AfterPostProcessOpaque:
				return HDRenderQueue.RenderQueueType.AfterPostProcessOpaque;
			case HDRenderQueue.RenderQueueType.PreRefraction:
				return HDRenderQueue.RenderQueueType.Opaque;
			case HDRenderQueue.RenderQueueType.Transparent:
				return HDRenderQueue.RenderQueueType.PreRefraction;
			case HDRenderQueue.RenderQueueType.LowTransparent:
				return HDRenderQueue.RenderQueueType.Transparent;
			case HDRenderQueue.RenderQueueType.AfterPostprocessTransparent:
				return HDRenderQueue.RenderQueueType.LowTransparent;
			case HDRenderQueue.RenderQueueType.Overlay:
				return HDRenderQueue.RenderQueueType.AfterPostprocessTransparent;
			case HDRenderQueue.RenderQueueType.Unknown:
				return HDRenderQueue.RenderQueueType.Transparent;
			case (HDRenderQueue.RenderQueueType)9:
				return HDRenderQueue.RenderQueueType.Overlay;
			}
			return HDRenderQueue.RenderQueueType.Unknown;
		}

		// Token: 0x06000C18 RID: 3096 RVA: 0x00060D2C File Offset: 0x0005EF2C
		public static bool Contains(this RenderQueueRange range, int value)
		{
			return range.lowerBound <= value && value <= range.upperBound;
		}

		// Token: 0x06000C19 RID: 3097 RVA: 0x00060D47 File Offset: 0x0005EF47
		public static int Clamps(this RenderQueueRange range, int value)
		{
			return Math.Max(range.lowerBound, Math.Min(value, range.upperBound));
		}

		// Token: 0x06000C1A RID: 3098 RVA: 0x00060D62 File Offset: 0x0005EF62
		public static int ClampsTransparentRangePriority(int value)
		{
			return Math.Max(-50, Math.Min(value, 50));
		}

		// Token: 0x06000C1B RID: 3099 RVA: 0x00060D74 File Offset: 0x0005EF74
		public static HDRenderQueue.RenderQueueType GetTypeByRenderQueueValue(int renderQueue)
		{
			if (renderQueue == 1000)
			{
				return HDRenderQueue.RenderQueueType.Background;
			}
			if (HDRenderQueue.k_RenderQueue_AllOpaque.Contains(renderQueue))
			{
				return HDRenderQueue.RenderQueueType.Opaque;
			}
			if (HDRenderQueue.k_RenderQueue_AfterPostProcessOpaque.Contains(renderQueue))
			{
				return HDRenderQueue.RenderQueueType.AfterPostProcessOpaque;
			}
			if (HDRenderQueue.k_RenderQueue_PreRefraction.Contains(renderQueue))
			{
				return HDRenderQueue.RenderQueueType.PreRefraction;
			}
			if (HDRenderQueue.k_RenderQueue_Transparent.Contains(renderQueue))
			{
				return HDRenderQueue.RenderQueueType.Transparent;
			}
			if (HDRenderQueue.k_RenderQueue_LowTransparent.Contains(renderQueue))
			{
				return HDRenderQueue.RenderQueueType.LowTransparent;
			}
			if (HDRenderQueue.k_RenderQueue_AfterPostProcessTransparent.Contains(renderQueue))
			{
				return HDRenderQueue.RenderQueueType.AfterPostprocessTransparent;
			}
			if (renderQueue == 4000)
			{
				return HDRenderQueue.RenderQueueType.Overlay;
			}
			return HDRenderQueue.RenderQueueType.Unknown;
		}

		// Token: 0x06000C1C RID: 3100 RVA: 0x00060DF0 File Offset: 0x0005EFF0
		public static int ChangeType(HDRenderQueue.RenderQueueType targetType, int offset = 0, bool alphaTest = false, bool receiveDecal = false)
		{
			switch (targetType)
			{
			case HDRenderQueue.RenderQueueType.Background:
				return 1000;
			case HDRenderQueue.RenderQueueType.Opaque:
				if (!alphaTest)
				{
					if (!receiveDecal)
					{
						return 2000;
					}
					return 2225;
				}
				else
				{
					if (!receiveDecal)
					{
						return 2450;
					}
					return 2475;
				}
				break;
			case HDRenderQueue.RenderQueueType.AfterPostProcessOpaque:
				if (!alphaTest)
				{
					return 2501;
				}
				return 2510;
			case HDRenderQueue.RenderQueueType.PreRefraction:
				return 2750 + offset;
			case HDRenderQueue.RenderQueueType.Transparent:
				return 3000 + offset;
			case HDRenderQueue.RenderQueueType.LowTransparent:
				return 3400 + offset;
			case HDRenderQueue.RenderQueueType.AfterPostprocessTransparent:
				return 3700 + offset;
			case HDRenderQueue.RenderQueueType.Overlay:
				return 4000;
			default:
				throw new ArgumentException("Unknown RenderQueueType, was " + targetType.ToString());
			}
		}

		// Token: 0x06000C1D RID: 3101 RVA: 0x00060E9D File Offset: 0x0005F09D
		public static HDRenderQueue.RenderQueueType GetTransparentEquivalent(HDRenderQueue.RenderQueueType type)
		{
			switch (type)
			{
			case HDRenderQueue.RenderQueueType.Background:
				break;
			case HDRenderQueue.RenderQueueType.Opaque:
				return HDRenderQueue.RenderQueueType.Transparent;
			case HDRenderQueue.RenderQueueType.AfterPostProcessOpaque:
				return HDRenderQueue.RenderQueueType.AfterPostprocessTransparent;
			default:
				if (type != HDRenderQueue.RenderQueueType.Overlay)
				{
					return type;
				}
				break;
			}
			throw new ArgumentException("Unknown RenderQueueType conversion to transparent equivalent, was " + type.ToString());
		}

		// Token: 0x06000C1E RID: 3102 RVA: 0x00060EDC File Offset: 0x0005F0DC
		public static HDRenderQueue.RenderQueueType GetOpaqueEquivalent(HDRenderQueue.RenderQueueType type)
		{
			switch (type)
			{
			case HDRenderQueue.RenderQueueType.Background:
			case HDRenderQueue.RenderQueueType.Overlay:
				throw new ArgumentException("Unknown RenderQueueType conversion to opaque equivalent, was " + type.ToString());
			case HDRenderQueue.RenderQueueType.PreRefraction:
			case HDRenderQueue.RenderQueueType.Transparent:
			case HDRenderQueue.RenderQueueType.LowTransparent:
				return HDRenderQueue.RenderQueueType.Opaque;
			case HDRenderQueue.RenderQueueType.AfterPostprocessTransparent:
				return HDRenderQueue.RenderQueueType.AfterPostProcessOpaque;
			}
			return type;
		}

		// Token: 0x06000C1F RID: 3103 RVA: 0x00060F33 File Offset: 0x0005F133
		public static HDRenderQueue.OpaqueRenderQueue ConvertToOpaqueRenderQueue(HDRenderQueue.RenderQueueType renderQueue)
		{
			if (renderQueue == HDRenderQueue.RenderQueueType.Opaque)
			{
				return HDRenderQueue.OpaqueRenderQueue.Default;
			}
			if (renderQueue != HDRenderQueue.RenderQueueType.AfterPostProcessOpaque)
			{
				throw new ArgumentException("Cannot map to OpaqueRenderQueue, was " + renderQueue.ToString());
			}
			return HDRenderQueue.OpaqueRenderQueue.AfterPostProcessing;
		}

		// Token: 0x06000C20 RID: 3104 RVA: 0x00060F5F File Offset: 0x0005F15F
		public static HDRenderQueue.RenderQueueType ConvertFromOpaqueRenderQueue(HDRenderQueue.OpaqueRenderQueue opaqueRenderQueue)
		{
			if (opaqueRenderQueue == HDRenderQueue.OpaqueRenderQueue.Default)
			{
				return HDRenderQueue.RenderQueueType.Opaque;
			}
			if (opaqueRenderQueue != HDRenderQueue.OpaqueRenderQueue.AfterPostProcessing)
			{
				throw new ArgumentException("Unknown OpaqueRenderQueue, was " + opaqueRenderQueue.ToString());
			}
			return HDRenderQueue.RenderQueueType.AfterPostProcessOpaque;
		}

		// Token: 0x06000C21 RID: 3105 RVA: 0x00060F8A File Offset: 0x0005F18A
		public static HDRenderQueue.TransparentRenderQueue ConvertToTransparentRenderQueue(HDRenderQueue.RenderQueueType renderQueue)
		{
			switch (renderQueue)
			{
			case HDRenderQueue.RenderQueueType.PreRefraction:
				return HDRenderQueue.TransparentRenderQueue.BeforeRefraction;
			case HDRenderQueue.RenderQueueType.Transparent:
				return HDRenderQueue.TransparentRenderQueue.Default;
			case HDRenderQueue.RenderQueueType.LowTransparent:
				return HDRenderQueue.TransparentRenderQueue.LowResolution;
			case HDRenderQueue.RenderQueueType.AfterPostprocessTransparent:
				return HDRenderQueue.TransparentRenderQueue.AfterPostProcessing;
			default:
				throw new ArgumentException("Cannot map to TransparentRenderQueue, was " + renderQueue.ToString());
			}
		}

		// Token: 0x06000C22 RID: 3106 RVA: 0x00060FCA File Offset: 0x0005F1CA
		public static HDRenderQueue.RenderQueueType ConvertFromTransparentRenderQueue(HDRenderQueue.TransparentRenderQueue transparentRenderqueue)
		{
			switch (transparentRenderqueue)
			{
			case HDRenderQueue.TransparentRenderQueue.BeforeRefraction:
				return HDRenderQueue.RenderQueueType.PreRefraction;
			case HDRenderQueue.TransparentRenderQueue.Default:
				return HDRenderQueue.RenderQueueType.Transparent;
			case HDRenderQueue.TransparentRenderQueue.LowResolution:
				return HDRenderQueue.RenderQueueType.LowTransparent;
			case HDRenderQueue.TransparentRenderQueue.AfterPostProcessing:
				return HDRenderQueue.RenderQueueType.AfterPostprocessTransparent;
			default:
				throw new ArgumentException("Unknown TransparentRenderQueue, was " + transparentRenderqueue.ToString());
			}
		}

		// Token: 0x06000C23 RID: 3107 RVA: 0x00061008 File Offset: 0x0005F208
		public static string GetShaderTagValue(int index)
		{
			if (HDRenderQueue.k_RenderQueue_AllTransparent.Contains(index) || HDRenderQueue.k_RenderQueue_AfterPostProcessTransparent.Contains(index) || HDRenderQueue.k_RenderQueue_LowTransparent.Contains(index))
			{
				int num = index - 3000;
				return "Transparent" + ((num < 0) ? "" : "+") + num.ToString();
			}
			if (index >= 4000)
			{
				return "Overlay+" + (index - 4000).ToString();
			}
			if (index >= 2450)
			{
				return "AlphaTest+" + (index - 2450).ToString();
			}
			if (index >= 2000)
			{
				return "Geometry+" + (index - 2000).ToString();
			}
			int num2 = index - 1000;
			return "Background" + ((num2 < 0) ? "" : "+") + num2.ToString();
		}

		// Token: 0x04000E86 RID: 3718
		private const int k_TransparentPriorityQueueRangeStep = 100;

		// Token: 0x04000E87 RID: 3719
		public static readonly RenderQueueRange k_RenderQueue_OpaqueNoAlphaTest = new RenderQueueRange
		{
			lowerBound = 1000,
			upperBound = 2449
		};

		// Token: 0x04000E88 RID: 3720
		public static readonly RenderQueueRange k_RenderQueue_OpaqueAlphaTest = new RenderQueueRange
		{
			lowerBound = 2450,
			upperBound = 2500
		};

		// Token: 0x04000E89 RID: 3721
		public static readonly RenderQueueRange k_RenderQueue_OpaqueDecalAndAlphaTest = new RenderQueueRange
		{
			lowerBound = 2225,
			upperBound = 2500
		};

		// Token: 0x04000E8A RID: 3722
		public static readonly RenderQueueRange k_RenderQueue_AllOpaque = new RenderQueueRange
		{
			lowerBound = 1000,
			upperBound = 2500
		};

		// Token: 0x04000E8B RID: 3723
		public static readonly RenderQueueRange k_RenderQueue_AfterPostProcessOpaque = new RenderQueueRange
		{
			lowerBound = 2501,
			upperBound = 2510
		};

		// Token: 0x04000E8C RID: 3724
		public static readonly RenderQueueRange k_RenderQueue_PreRefraction = new RenderQueueRange
		{
			lowerBound = 2650,
			upperBound = 2850
		};

		// Token: 0x04000E8D RID: 3725
		public static readonly RenderQueueRange k_RenderQueue_Transparent = new RenderQueueRange
		{
			lowerBound = 2900,
			upperBound = 3100
		};

		// Token: 0x04000E8E RID: 3726
		public static readonly RenderQueueRange k_RenderQueue_TransparentWithLowRes = new RenderQueueRange
		{
			lowerBound = 2900,
			upperBound = 3500
		};

		// Token: 0x04000E8F RID: 3727
		public static readonly RenderQueueRange k_RenderQueue_LowTransparent = new RenderQueueRange
		{
			lowerBound = 3300,
			upperBound = 3500
		};

		// Token: 0x04000E90 RID: 3728
		public static readonly RenderQueueRange k_RenderQueue_AllTransparent = new RenderQueueRange
		{
			lowerBound = 2650,
			upperBound = 3100
		};

		// Token: 0x04000E91 RID: 3729
		public static readonly RenderQueueRange k_RenderQueue_AllTransparentWithLowRes = new RenderQueueRange
		{
			lowerBound = 2650,
			upperBound = 3500
		};

		// Token: 0x04000E92 RID: 3730
		public static readonly RenderQueueRange k_RenderQueue_AfterPostProcessTransparent = new RenderQueueRange
		{
			lowerBound = 3600,
			upperBound = 3800
		};

		// Token: 0x04000E93 RID: 3731
		public static readonly RenderQueueRange k_RenderQueue_Overlay = new RenderQueueRange
		{
			lowerBound = 4000,
			upperBound = 5000
		};

		// Token: 0x04000E94 RID: 3732
		public static readonly RenderQueueRange k_RenderQueue_All = new RenderQueueRange
		{
			lowerBound = 0,
			upperBound = 5000
		};

		// Token: 0x04000E95 RID: 3733
		public const int sortingPriorityRange = 50;

		// Token: 0x04000E96 RID: 3734
		public const int meshDecalPriorityRange = 50;

		// Token: 0x020003C6 RID: 966
		public enum Priority
		{
			// Token: 0x04002748 RID: 10056
			Background = 1000,
			// Token: 0x04002749 RID: 10057
			Opaque = 2000,
			// Token: 0x0400274A RID: 10058
			OpaqueDecal = 2225,
			// Token: 0x0400274B RID: 10059
			OpaqueAlphaTest = 2450,
			// Token: 0x0400274C RID: 10060
			OpaqueDecalAlphaTest = 2475,
			// Token: 0x0400274D RID: 10061
			OpaqueLast = 2500,
			// Token: 0x0400274E RID: 10062
			AfterPostprocessOpaque,
			// Token: 0x0400274F RID: 10063
			AfterPostprocessOpaqueAlphaTest = 2510,
			// Token: 0x04002750 RID: 10064
			PreRefractionFirst = 2650,
			// Token: 0x04002751 RID: 10065
			PreRefraction = 2750,
			// Token: 0x04002752 RID: 10066
			PreRefractionLast = 2850,
			// Token: 0x04002753 RID: 10067
			TransparentFirst = 2900,
			// Token: 0x04002754 RID: 10068
			Transparent = 3000,
			// Token: 0x04002755 RID: 10069
			TransparentLast = 3100,
			// Token: 0x04002756 RID: 10070
			LowTransparentFirst = 3300,
			// Token: 0x04002757 RID: 10071
			LowTransparent = 3400,
			// Token: 0x04002758 RID: 10072
			LowTransparentLast = 3500,
			// Token: 0x04002759 RID: 10073
			AfterPostprocessTransparentFirst = 3600,
			// Token: 0x0400275A RID: 10074
			AfterPostprocessTransparent = 3700,
			// Token: 0x0400275B RID: 10075
			AfterPostprocessTransparentLast = 3800,
			// Token: 0x0400275C RID: 10076
			Overlay = 4000
		}

		// Token: 0x020003C7 RID: 967
		public enum RenderQueueType
		{
			// Token: 0x0400275E RID: 10078
			Background,
			// Token: 0x0400275F RID: 10079
			Opaque,
			// Token: 0x04002760 RID: 10080
			AfterPostProcessOpaque,
			// Token: 0x04002761 RID: 10081
			PreRefraction,
			// Token: 0x04002762 RID: 10082
			Transparent,
			// Token: 0x04002763 RID: 10083
			LowTransparent,
			// Token: 0x04002764 RID: 10084
			AfterPostprocessTransparent,
			// Token: 0x04002765 RID: 10085
			Overlay,
			// Token: 0x04002766 RID: 10086
			Unknown
		}

		// Token: 0x020003C8 RID: 968
		public enum OpaqueRenderQueue
		{
			// Token: 0x04002768 RID: 10088
			Default,
			// Token: 0x04002769 RID: 10089
			AfterPostProcessing
		}

		// Token: 0x020003C9 RID: 969
		public enum TransparentRenderQueue
		{
			// Token: 0x0400276B RID: 10091
			BeforeRefraction,
			// Token: 0x0400276C RID: 10092
			Default,
			// Token: 0x0400276D RID: 10093
			LowResolution,
			// Token: 0x0400276E RID: 10094
			AfterPostProcessing
		}
	}
}
