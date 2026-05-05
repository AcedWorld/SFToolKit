using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Rewired.Config;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.InputManagers;
using Rewired.Interfaces;
using Rewired.Internal.Glyphs;
using Rewired.Internal.Localization;
using Rewired.Platforms;
using Rewired.Platforms.Custom;
using Rewired.Platforms.XboxOne;
using Rewired.Utils;
using Rewired.Utils.Classes;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired
{
	// Token: 0x020001A7 RID: 423
	public static class ReInput
	{
		// Token: 0x06001454 RID: 5204 RVA: 0x000672B4 File Offset: 0x000654B4
		static ReInput()
		{
			SafeDelegate.S_ExceptionHandler = new Action<Exception>(ReInput.UiIeThpXEYmSxJzvHrkDCWwYfiuq.<>9.afAasMQfiCGiRvGPtDrDmbIdLXTQ);
		}

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x06001455 RID: 5205 RVA: 0x0001165B File Offset: 0x0000F85B
		private static ykQBbCYXhmFNZdFinwXsPZYFmYFE BlhzLLIoHKNAbUKGAUpQxQgixmXk
		{
			get
			{
				ykQBbCYXhmFNZdFinwXsPZYFmYFE result;
				if ((result = ReInput.wIVMmklqRlJFLVoFwVUpyBHUGnFf) == null)
				{
					result = (ReInput.wIVMmklqRlJFLVoFwVUpyBHUGnFf = new ykQBbCYXhmFNZdFinwXsPZYFmYFE(ReInput.SoNJmklvaubvNUQEVJTopavpXlMC.updateLoop));
				}
				return result;
			}
		}

		// Token: 0x1400001C RID: 28
		// (add) Token: 0x06001456 RID: 5206 RVA: 0x0001167B File Offset: 0x0000F87B
		// (remove) Token: 0x06001457 RID: 5207 RVA: 0x0001168D File Offset: 0x0000F88D
		public static event Action<ControllerStatusChangedEventArgs> ControllerConnectedEvent
		{
			add
			{
				ReInput.UEFYKTaOUSSTqBbviFjsxmENJYBc += value;
			}
			remove
			{
				ReInput.UEFYKTaOUSSTqBbviFjsxmENJYBc -= value;
			}
		}

		// Token: 0x1400001D RID: 29
		// (add) Token: 0x06001458 RID: 5208 RVA: 0x0001169F File Offset: 0x0000F89F
		// (remove) Token: 0x06001459 RID: 5209 RVA: 0x000116B1 File Offset: 0x0000F8B1
		public static event Action<ControllerStatusChangedEventArgs> ControllerPreDisconnectEvent
		{
			add
			{
				ReInput.zfIKshnBBvAXDAiCCLdHCtlvsQjB += value;
			}
			remove
			{
				ReInput.zfIKshnBBvAXDAiCCLdHCtlvsQjB -= value;
			}
		}

		// Token: 0x1400001E RID: 30
		// (add) Token: 0x0600145A RID: 5210 RVA: 0x000116C3 File Offset: 0x0000F8C3
		// (remove) Token: 0x0600145B RID: 5211 RVA: 0x000116D5 File Offset: 0x0000F8D5
		public static event Action<ControllerStatusChangedEventArgs> ControllerDisconnectedEvent
		{
			add
			{
				ReInput.UUfjdHbAElCbsJpQiClpEvhUJbfbA += value;
			}
			remove
			{
				ReInput.UUfjdHbAElCbsJpQiClpEvhUJbfbA -= value;
			}
		}

		// Token: 0x1400001F RID: 31
		// (add) Token: 0x0600145C RID: 5212 RVA: 0x000116E7 File Offset: 0x0000F8E7
		// (remove) Token: 0x0600145D RID: 5213 RVA: 0x000116F9 File Offset: 0x0000F8F9
		public static event Action InputSourceUpdateEvent
		{
			add
			{
				ReInput.LVjqYCpNsZAXwAnqIcFhOFCwcUlW += value;
			}
			remove
			{
				ReInput.LVjqYCpNsZAXwAnqIcFhOFCwcUlW -= value;
			}
		}

		// Token: 0x14000020 RID: 32
		// (add) Token: 0x0600145E RID: 5214 RVA: 0x0001170B File Offset: 0x0000F90B
		// (remove) Token: 0x0600145F RID: 5215 RVA: 0x0001171D File Offset: 0x0000F91D
		public static event Action EditorRecompileEvent
		{
			add
			{
				ReInput.fZajzRVhDEGhvytHDdFhqmbPWsDb += value;
			}
			remove
			{
				ReInput.fZajzRVhDEGhvytHDdFhqmbPWsDb -= value;
			}
		}

		// Token: 0x14000021 RID: 33
		// (add) Token: 0x06001460 RID: 5216 RVA: 0x0001172F File Offset: 0x0000F92F
		// (remove) Token: 0x06001461 RID: 5217 RVA: 0x00011741 File Offset: 0x0000F941
		public static event Action PreShutDownEvent
		{
			add
			{
				ReInput.pMhcTAFlcJqmTpaHlLZPdxDHRDDNA += value;
			}
			remove
			{
				ReInput.pMhcTAFlcJqmTpaHlLZPdxDHRDDNA -= value;
			}
		}

		// Token: 0x14000022 RID: 34
		// (add) Token: 0x06001462 RID: 5218 RVA: 0x00011753 File Offset: 0x0000F953
		// (remove) Token: 0x06001463 RID: 5219 RVA: 0x00011765 File Offset: 0x0000F965
		public static event Action ShutDownEvent
		{
			add
			{
				ReInput.pjpHdphDZijFqFNmXwtKlGxDrtvr += value;
			}
			remove
			{
				ReInput.pjpHdphDZijFqFNmXwtKlGxDrtvr -= value;
			}
		}

		// Token: 0x14000023 RID: 35
		// (add) Token: 0x06001464 RID: 5220 RVA: 0x00011777 File Offset: 0x0000F977
		// (remove) Token: 0x06001465 RID: 5221 RVA: 0x00011789 File Offset: 0x0000F989
		public static event Action InitializedEvent
		{
			add
			{
				ReInput.jKDzEiwUQFWZuVavFxOqwDVYJDlH += value;
			}
			remove
			{
				ReInput.jKDzEiwUQFWZuVavFxOqwDVYJDlH -= value;
			}
		}

		// Token: 0x14000024 RID: 36
		// (add) Token: 0x06001466 RID: 5222 RVA: 0x0001179B File Offset: 0x0000F99B
		// (remove) Token: 0x06001467 RID: 5223 RVA: 0x000117B2 File Offset: 0x0000F9B2
		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationFocusChangedEvent
		{
			add
			{
				ReInput._ApplicationFocusChangedEvent = (Action<bool>)Delegate.Combine(ReInput._ApplicationFocusChangedEvent, value);
			}
			remove
			{
				ReInput._ApplicationFocusChangedEvent = (Action<bool>)Delegate.Remove(ReInput._ApplicationFocusChangedEvent, value);
			}
		}

		// Token: 0x14000025 RID: 37
		// (add) Token: 0x06001468 RID: 5224 RVA: 0x000117C9 File Offset: 0x0000F9C9
		// (remove) Token: 0x06001469 RID: 5225 RVA: 0x000117E0 File Offset: 0x0000F9E0
		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationPauseChangedEvent
		{
			add
			{
				ReInput._ApplicationPauseChangedEvent = (Action<bool>)Delegate.Combine(ReInput._ApplicationPauseChangedEvent, value);
			}
			remove
			{
				ReInput._ApplicationPauseChangedEvent = (Action<bool>)Delegate.Remove(ReInput._ApplicationPauseChangedEvent, value);
			}
		}

		// Token: 0x14000026 RID: 38
		// (add) Token: 0x0600146A RID: 5226 RVA: 0x000117F7 File Offset: 0x0000F9F7
		// (remove) Token: 0x0600146B RID: 5227 RVA: 0x0001180E File Offset: 0x0000FA0E
		[CustomObfuscation(rename = false)]
		internal static event Action EarlyUpdateEvent
		{
			add
			{
				ReInput.xLWAJzJccOGCvFYeBwmUXBWvHVXd = (Action)Delegate.Combine(ReInput.xLWAJzJccOGCvFYeBwmUXBWvHVXd, value);
			}
			remove
			{
				ReInput.xLWAJzJccOGCvFYeBwmUXBWvHVXd = (Action)Delegate.Remove(ReInput.xLWAJzJccOGCvFYeBwmUXBWvHVXd, value);
			}
		}

		// Token: 0x14000027 RID: 39
		// (add) Token: 0x0600146C RID: 5228 RVA: 0x00011825 File Offset: 0x0000FA25
		// (remove) Token: 0x0600146D RID: 5229 RVA: 0x0001183C File Offset: 0x0000FA3C
		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> BeforeTimeManagerUpdateEvent
		{
			add
			{
				ReInput.nrVnSODkTzGKxbQKscgdIPWdTPCj = (Action<UpdateLoopType>)Delegate.Combine(ReInput.nrVnSODkTzGKxbQKscgdIPWdTPCj, value);
			}
			remove
			{
				ReInput.nrVnSODkTzGKxbQKscgdIPWdTPCj = (Action<UpdateLoopType>)Delegate.Remove(ReInput.nrVnSODkTzGKxbQKscgdIPWdTPCj, value);
			}
		}

		// Token: 0x14000028 RID: 40
		// (add) Token: 0x0600146E RID: 5230 RVA: 0x00011853 File Offset: 0x0000FA53
		// (remove) Token: 0x0600146F RID: 5231 RVA: 0x0001186A File Offset: 0x0000FA6A
		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateStartedEvent
		{
			add
			{
				ReInput.PuQGzkZlCPpQpEoVZkrvOjMiMuny = (Action<UpdateLoopType>)Delegate.Combine(ReInput.PuQGzkZlCPpQpEoVZkrvOjMiMuny, value);
			}
			remove
			{
				ReInput.PuQGzkZlCPpQpEoVZkrvOjMiMuny = (Action<UpdateLoopType>)Delegate.Remove(ReInput.PuQGzkZlCPpQpEoVZkrvOjMiMuny, value);
			}
		}

		// Token: 0x14000029 RID: 41
		// (add) Token: 0x06001470 RID: 5232 RVA: 0x00011881 File Offset: 0x0000FA81
		// (remove) Token: 0x06001471 RID: 5233 RVA: 0x00011898 File Offset: 0x0000FA98
		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateEndedEvent
		{
			add
			{
				ReInput.gELAMhcZqpKghQLfsIpYglpczIKGb = (Action<UpdateLoopType>)Delegate.Combine(ReInput.gELAMhcZqpKghQLfsIpYglpczIKGb, value);
			}
			remove
			{
				ReInput.gELAMhcZqpKghQLfsIpYglpczIKGb = (Action<UpdateLoopType>)Delegate.Remove(ReInput.gELAMhcZqpKghQLfsIpYglpczIKGb, value);
			}
		}

		// Token: 0x1400002A RID: 42
		// (add) Token: 0x06001472 RID: 5234 RVA: 0x000118AF File Offset: 0x0000FAAF
		// (remove) Token: 0x06001473 RID: 5235 RVA: 0x000118C6 File Offset: 0x0000FAC6
		[CustomObfuscation(rename = false)]
		internal static event Action LateUpdateEvent
		{
			add
			{
				ReInput.LOrHsxecguMdqinqBqxuHnfUvZbC = (Action)Delegate.Combine(ReInput.LOrHsxecguMdqinqBqxuHnfUvZbC, value);
			}
			remove
			{
				ReInput.LOrHsxecguMdqinqBqxuHnfUvZbC = (Action)Delegate.Remove(ReInput.LOrHsxecguMdqinqBqxuHnfUvZbC, value);
			}
		}

		// Token: 0x1400002B RID: 43
		// (add) Token: 0x06001474 RID: 5236 RVA: 0x000118DD File Offset: 0x0000FADD
		// (remove) Token: 0x06001475 RID: 5237 RVA: 0x000118F4 File Offset: 0x0000FAF4
		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationIsFullScreenChangedEvent
		{
			add
			{
				ReInput.LLFgTpfdbygzgBYpKYAixPcVfGWPA = (Action<bool>)Delegate.Combine(ReInput.LLFgTpfdbygzgBYpKYAixPcVfGWPA, value);
			}
			remove
			{
				ReInput.LLFgTpfdbygzgBYpKYAixPcVfGWPA = (Action<bool>)Delegate.Remove(ReInput.LLFgTpfdbygzgBYpKYAixPcVfGWPA, value);
			}
		}

		// Token: 0x1400002C RID: 44
		// (add) Token: 0x06001476 RID: 5238 RVA: 0x0001190B File Offset: 0x0000FB0B
		// (remove) Token: 0x06001477 RID: 5239 RVA: 0x00011922 File Offset: 0x0000FB22
		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationRunInBackgroundChangedEvent
		{
			add
			{
				ReInput.wqsGNskAhqmEMBbFOxiqPMJrycHB = (Action<bool>)Delegate.Combine(ReInput.wqsGNskAhqmEMBbFOxiqPMJrycHB, value);
			}
			remove
			{
				ReInput.wqsGNskAhqmEMBbFOxiqPMJrycHB = (Action<bool>)Delegate.Remove(ReInput.wqsGNskAhqmEMBbFOxiqPMJrycHB, value);
			}
		}

		// Token: 0x1400002D RID: 45
		// (add) Token: 0x06001478 RID: 5240 RVA: 0x00011939 File Offset: 0x0000FB39
		// (remove) Token: 0x06001479 RID: 5241 RVA: 0x00011950 File Offset: 0x0000FB50
		[CustomObfuscation(rename = false)]
		internal static event Action<bool> TimeScalePauseChangedEvent
		{
			add
			{
				ReInput.QQWawwrzcmBejonOKMpssNUXrEOd = (Action<bool>)Delegate.Combine(ReInput.QQWawwrzcmBejonOKMpssNUXrEOd, value);
			}
			remove
			{
				ReInput.QQWawwrzcmBejonOKMpssNUXrEOd = (Action<bool>)Delegate.Remove(ReInput.QQWawwrzcmBejonOKMpssNUXrEOd, value);
			}
		}

		// Token: 0x1400002E RID: 46
		// (add) Token: 0x0600147A RID: 5242 RVA: 0x00011967 File Offset: 0x0000FB67
		// (remove) Token: 0x0600147B RID: 5243 RVA: 0x0001197E File Offset: 0x0000FB7E
		[CustomObfuscation(rename = false)]
		internal static event Action<FullScreenMode> ApplicationFullScreenModeChangedEvent
		{
			add
			{
				ReInput.KBoRXrwTuYDuZHopkwTDxKJLGiGkA = (Action<FullScreenMode>)Delegate.Combine(ReInput.KBoRXrwTuYDuZHopkwTDxKJLGiGkA, value);
			}
			remove
			{
				ReInput.KBoRXrwTuYDuZHopkwTDxKJLGiGkA = (Action<FullScreenMode>)Delegate.Remove(ReInput.KBoRXrwTuYDuZHopkwTDxKJLGiGkA, value);
			}
		}

		// Token: 0x1400002F RID: 47
		// (add) Token: 0x0600147C RID: 5244 RVA: 0x00011995 File Offset: 0x0000FB95
		// (remove) Token: 0x0600147D RID: 5245 RVA: 0x000119AC File Offset: 0x0000FBAC
		[CustomObfuscation(rename = false)]
		internal static event Action SceneLoadedEvent
		{
			add
			{
				ReInput.ZWoXUiShIAZgqiIefJqzsBpgslLE = (Action)Delegate.Combine(ReInput.ZWoXUiShIAZgqiIefJqzsBpgslLE, value);
			}
			remove
			{
				ReInput.ZWoXUiShIAZgqiIefJqzsBpgslLE = (Action)Delegate.Remove(ReInput.ZWoXUiShIAZgqiIefJqzsBpgslLE, value);
			}
		}

		// Token: 0x14000030 RID: 48
		// (add) Token: 0x0600147E RID: 5246 RVA: 0x000119C3 File Offset: 0x0000FBC3
		// (remove) Token: 0x0600147F RID: 5247 RVA: 0x000119DA File Offset: 0x0000FBDA
		[CustomObfuscation(rename = false)]
		internal static event Action<bool> EditorPauseChangedEvent
		{
			add
			{
				ReInput.hlKLGuFZViiMwhOZYgOQilkPoQYkA = (Action<bool>)Delegate.Combine(ReInput.hlKLGuFZViiMwhOZYgOQilkPoQYkA, value);
			}
			remove
			{
				ReInput.hlKLGuFZViiMwhOZYgOQilkPoQYkA = (Action<bool>)Delegate.Remove(ReInput.hlKLGuFZViiMwhOZYgOQilkPoQYkA, value);
			}
		}

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x06001480 RID: 5248 RVA: 0x000119F1 File Offset: 0x0000FBF1
		public static ReInput.PlayerHelper players
		{
			get
			{
				if (!ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr)
				{
					ReInput.uSogAyPrddarzhIkhAlkgYkwrUqq();
					return null;
				}
				return ReInput.DyZlywrxvCftxCnMubZKePdxYCZw;
			}
		}

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x06001481 RID: 5249 RVA: 0x00011A06 File Offset: 0x0000FC06
		public static ReInput.ControllerHelper controllers
		{
			get
			{
				if (!ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr)
				{
					ReInput.uSogAyPrddarzhIkhAlkgYkwrUqq();
					return null;
				}
				return ReInput.iliqmShLhblOLYhCIGhxClgafyrPA;
			}
		}

		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x06001482 RID: 5250 RVA: 0x00011A1B File Offset: 0x0000FC1B
		public static ReInput.MappingHelper mapping
		{
			get
			{
				if (!ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr)
				{
					ReInput.uSogAyPrddarzhIkhAlkgYkwrUqq();
					return null;
				}
				return ReInput.JiKRQVFHGBzBTmqWMvyTKSqlQdGS;
			}
		}

		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x06001483 RID: 5251 RVA: 0x00011A30 File Offset: 0x0000FC30
		public static ReInput.UnityTouch touch
		{
			get
			{
				if (!ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr)
				{
					ReInput.uSogAyPrddarzhIkhAlkgYkwrUqq();
					return null;
				}
				return ReInput.OXcoNegktpaFFxFFyaUZHqHVNcXGA;
			}
		}

		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x06001484 RID: 5252 RVA: 0x00011A45 File Offset: 0x0000FC45
		public static ReInput.TimeHelper time
		{
			get
			{
				if (!ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr)
				{
					ReInput.uSogAyPrddarzhIkhAlkgYkwrUqq();
					return null;
				}
				return ReInput.VbrjeHoRYeDhCvqJTVrngNWnpXab;
			}
		}

		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x06001485 RID: 5253 RVA: 0x00011A5A File Offset: 0x0000FC5A
		public static IUserDataStore userDataStore
		{
			get
			{
				if (!ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr)
				{
					ReInput.uSogAyPrddarzhIkhAlkgYkwrUqq();
					return null;
				}
				return ReInput.WdvksUXhQSpBQcjqotpyebeIkYYo;
			}
		}

		// Token: 0x170004EB RID: 1259
		// (get) Token: 0x06001486 RID: 5254 RVA: 0x00011A6F File Offset: 0x0000FC6F
		public static ReInput.ConfigHelper configuration
		{
			get
			{
				if (!ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr)
				{
					ReInput.uSogAyPrddarzhIkhAlkgYkwrUqq();
					return null;
				}
				return ReInput.HUtHeWufhdeaXbdzWwoBbcALbloG;
			}
		}

		// Token: 0x170004EC RID: 1260
		// (get) Token: 0x06001487 RID: 5255 RVA: 0x00011A84 File Offset: 0x0000FC84
		public static ReInput.LocalizationHelper localization
		{
			get
			{
				if (!ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr)
				{
					ReInput.uSogAyPrddarzhIkhAlkgYkwrUqq();
					return null;
				}
				return ReInput.vLgMoSdsOEragzlVFcTXghEYbkzB;
			}
		}

		// Token: 0x170004ED RID: 1261
		// (get) Token: 0x06001488 RID: 5256 RVA: 0x00011A99 File Offset: 0x0000FC99
		public static ReInput.GlyphHelper glyphs
		{
			get
			{
				if (!ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr)
				{
					ReInput.uSogAyPrddarzhIkhAlkgYkwrUqq();
					return null;
				}
				return ReInput.uMqGrfIEEonQheSIdedIvQcwpner;
			}
		}

		// Token: 0x170004EE RID: 1262
		// (get) Token: 0x06001489 RID: 5257 RVA: 0x00067410 File Offset: 0x00065610
		public static string programVersion
		{
			get
			{
				return string.Concat(new string[]
				{
					1.ToString(),
					".",
					1.ToString(),
					".",
					58.ToString(),
					".",
					4.ToString(),
					".U2022"
				});
			}
		}

		// Token: 0x170004EF RID: 1263
		// (get) Token: 0x0600148A RID: 5258 RVA: 0x00011AAE File Offset: 0x0000FCAE
		public static bool usingUnityInput
		{
			get
			{
				return ReInput.QlUQYHZcxMVTJoGKPDmhRoCscfSt;
			}
		}

		// Token: 0x170004F0 RID: 1264
		// (get) Token: 0x0600148B RID: 5259 RVA: 0x00011AB5 File Offset: 0x0000FCB5
		public static bool unityJoystickIdentificationRequired
		{
			get
			{
				return ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr && (ReInput.isWindowsStandaloneWebplayerOrEditorPlatform && !UnityTools.windowsJoystickNamesReturnsEmptyStringsIfJoystickNull);
			}
		}

		// Token: 0x170004F1 RID: 1265
		// (get) Token: 0x0600148C RID: 5260 RVA: 0x00011AD1 File Offset: 0x0000FCD1
		public static bool isReady
		{
			get
			{
				return ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr;
			}
		}

		// Token: 0x0600148D RID: 5261 RVA: 0x00011AD8 File Offset: 0x0000FCD8
		public static void Update()
		{
			if (!ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr)
			{
				return;
			}
			if (ReInput.SoNJmklvaubvNUQEVJTopavpXlMC.updateMode != UpdateMode.Manual)
			{
				Logger.LogError("Rewired cannot be updated manually unless Update Mode is set to Manual.");
				return;
			}
			ReInput.ernshACoCJlADnBWudDRchCdqgHc.DoUpdate(UpdateLoopType.Update, UpdateLoopSetting.Update);
		}

		// Token: 0x0600148E RID: 5262 RVA: 0x00011B06 File Offset: 0x0000FD06
		public static void Reset()
		{
			if (!ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr)
			{
				return;
			}
			if (ReInput.ernshACoCJlADnBWudDRchCdqgHc == null)
			{
				return;
			}
			ReInput.ernshACoCJlADnBWudDRchCdqgHc.ResetAll();
		}

		// Token: 0x170004F2 RID: 1266
		// (get) Token: 0x0600148F RID: 5263 RVA: 0x00011B28 File Offset: 0x0000FD28
		[CustomObfuscation(rename = false)]
		internal static int id
		{
			get
			{
				return ReInput._id;
			}
		}

		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x06001490 RID: 5264 RVA: 0x00011AD1 File Offset: 0x0000FCD1
		[CustomObfuscation(rename = false)]
		internal static bool initialized
		{
			get
			{
				return ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr;
			}
		}

		// Token: 0x170004F4 RID: 1268
		// (get) Token: 0x06001491 RID: 5265 RVA: 0x00011B2F File Offset: 0x0000FD2F
		[CustomObfuscation(rename = false)]
		internal static UpdateLoopType currentUpdateLoop
		{
			get
			{
				return ReInput.rZZOHmulAahBDJfKujGQayvPctcs;
			}
		}

		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x06001492 RID: 5266 RVA: 0x00011B36 File Offset: 0x0000FD36
		[CustomObfuscation(rename = false)]
		internal static ConfigVars configVars
		{
			get
			{
				return ReInput.SoNJmklvaubvNUQEVJTopavpXlMC;
			}
		}

		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x06001493 RID: 5267 RVA: 0x00011B36 File Offset: 0x0000FD36
		[CustomObfuscation(rename = false)]
		internal static IConfigVars_Internal pluginConfigVars
		{
			get
			{
				return ReInput.SoNJmklvaubvNUQEVJTopavpXlMC;
			}
		}

		// Token: 0x170004F7 RID: 1271
		// (get) Token: 0x06001494 RID: 5268 RVA: 0x00011B3D File Offset: 0x0000FD3D
		[CustomObfuscation(rename = false)]
		internal static UserData UserData
		{
			get
			{
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb;
			}
		}

		// Token: 0x170004F8 RID: 1272
		// (get) Token: 0x06001495 RID: 5269 RVA: 0x00011B44 File Offset: 0x0000FD44
		[CustomObfuscation(rename = false)]
		internal static Platform currentPlatform
		{
			get
			{
				return ReInput.UNWPXAlZDFTHmNTPXTEOxtNFPpqL;
			}
		}

		// Token: 0x170004F9 RID: 1273
		// (get) Token: 0x06001496 RID: 5270 RVA: 0x00011B4B File Offset: 0x0000FD4B
		[CustomObfuscation(rename = false)]
		internal static WebplayerPlatform webplayerPlatform
		{
			get
			{
				return ReInput.fywzAMAeyvDqLeoMZlDlgEEMMZJT;
			}
		}

		// Token: 0x170004FA RID: 1274
		// (get) Token: 0x06001497 RID: 5271 RVA: 0x00011B52 File Offset: 0x0000FD52
		[CustomObfuscation(rename = false)]
		internal static EditorPlatform editorPlatform
		{
			get
			{
				return ReInput.XgVQfWiQHYFdfDmAnXoxHosiAHtP;
			}
		}

		// Token: 0x170004FB RID: 1275
		// (get) Token: 0x06001498 RID: 5272 RVA: 0x0006747C File Offset: 0x0006567C
		[CustomObfuscation(rename = false)]
		internal static bool checkNeverPressed
		{
			get
			{
				return (ReInput.UNWPXAlZDFTHmNTPXTEOxtNFPpqL == Platform.Linux && ReInput.QlUQYHZcxMVTJoGKPDmhRoCscfSt) || (ReInput.UNWPXAlZDFTHmNTPXTEOxtNFPpqL == Platform.OSX && (ReInput.QlUQYHZcxMVTJoGKPDmhRoCscfSt || ReInput.primaryInputManager.inputSourceType == InputSource.OSX)) || (UnityTools.isAndroidPlatform && ReInput.QlUQYHZcxMVTJoGKPDmhRoCscfSt) || (ReInput.UNWPXAlZDFTHmNTPXTEOxtNFPpqL == Platform.Webplayer && ReInput.fywzAMAeyvDqLeoMZlDlgEEMMZJT == WebplayerPlatform.OSX) || ReInput.UNWPXAlZDFTHmNTPXTEOxtNFPpqL == Platform.WebGL;
			}
		}

		// Token: 0x170004FC RID: 1276
		// (get) Token: 0x06001499 RID: 5273 RVA: 0x00011B59 File Offset: 0x0000FD59
		[CustomObfuscation(rename = false)]
		internal static bool isEditor
		{
			get
			{
				return ReInput.XgVQfWiQHYFdfDmAnXoxHosiAHtP > EditorPlatform.None;
			}
		}

		// Token: 0x170004FD RID: 1277
		// (get) Token: 0x0600149A RID: 5274 RVA: 0x00011B63 File Offset: 0x0000FD63
		[CustomObfuscation(rename = false)]
		internal static Guid defaultHardwareJoystickMapGuid
		{
			get
			{
				if (!ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr)
				{
					return Guid.Empty;
				}
				return ReInput.LtnwAoZuGNHrlfpnRahHEdzSRZguA.defaultHardwareJoystickMapGuid;
			}
		}

		// Token: 0x170004FE RID: 1278
		// (get) Token: 0x0600149B RID: 5275 RVA: 0x00011B7C File Offset: 0x0000FD7C
		[CustomObfuscation(rename = false)]
		internal static bool isRunningInEditMode
		{
			get
			{
				return ReInput.tabJZNZrPYWCGUvcwsLRnXNVDEnE;
			}
		}

		// Token: 0x170004FF RID: 1279
		// (get) Token: 0x0600149C RID: 5276 RVA: 0x00011B83 File Offset: 0x0000FD83
		[CustomObfuscation(rename = false)]
		internal static bool isEditorPaused
		{
			get
			{
				return UnityTools.externalTools.isEditorPaused;
			}
		}

		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x0600149D RID: 5277 RVA: 0x00011B8F File Offset: 0x0000FD8F
		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTime
		{
			get
			{
				return ReInput.vJBNxHpsKaeldWfiVmEFIJhTbUdaA.RwkTlKGligCMggvQuDLrLKflyolt;
			}
		}

		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x0600149E RID: 5278 RVA: 0x00011B9B File Offset: 0x0000FD9B
		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTimePrev
		{
			get
			{
				return ReInput.vJBNxHpsKaeldWfiVmEFIJhTbUdaA.SNQtjGGmzOrvQqJtUecPeaeZWsQoA;
			}
		}

		// Token: 0x17000502 RID: 1282
		// (get) Token: 0x0600149F RID: 5279 RVA: 0x00011BA7 File Offset: 0x0000FDA7
		[CustomObfuscation(rename = false)]
		internal static double realTime
		{
			get
			{
				if (!ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr)
				{
					return 0.0;
				}
				return ReInput.vJBNxHpsKaeldWfiVmEFIJhTbUdaA.VJlDoOpeEHAdgWbCyIlkcpJIpgOy;
			}
		}

		// Token: 0x17000503 RID: 1283
		// (get) Token: 0x060014A0 RID: 5280 RVA: 0x00011BC4 File Offset: 0x0000FDC4
		[CustomObfuscation(rename = false)]
		internal static int currentUnityFrame
		{
			get
			{
				if (!ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr)
				{
					return 0;
				}
				return ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.NQMLPuTdRROwdPJttQMneqPXRDPx;
			}
		}

		// Token: 0x17000504 RID: 1284
		// (get) Token: 0x060014A1 RID: 5281 RVA: 0x00011BD9 File Offset: 0x0000FDD9
		private static bool QaYkamXbSymqTWeEyMMQyVACMVyH
		{
			get
			{
				if (UnityTools.unityVersion >= UnityTools.UnityVersion.UNITY_5_1)
				{
					return ReInput.GdOWJqaIGqcwfSTEsiWfbyMecUsH == "Game";
				}
				return ReInput.GdOWJqaIGqcwfSTEsiWfbyMecUsH == "UnityEditor.GameView";
			}
		}

		// Token: 0x17000505 RID: 1285
		// (get) Token: 0x060014A2 RID: 5282 RVA: 0x00011C03 File Offset: 0x0000FE03
		[CustomObfuscation(rename = false)]
		internal static bool isAllowedEditorWindowFocused
		{
			get
			{
				return (ReInput.SoNJmklvaubvNUQEVJTopavpXlMC.allowInputInEditorSceneView && UnityTools.externalTools.IsEditorSceneViewFocused()) || ReInput.nDMYShWfGPGIuiUMgblXmqJTZwNQ || ReInput.QaYkamXbSymqTWeEyMMQyVACMVyH;
			}
		}

		// Token: 0x17000506 RID: 1286
		// (get) Token: 0x060014A3 RID: 5283 RVA: 0x000674E8 File Offset: 0x000656E8
		[CustomObfuscation(rename = false)]
		internal static bool isUnityEditorFocused
		{
			get
			{
				INativePlatformHelper nativePlatformHelper = ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA as INativePlatformHelper;
				if (nativePlatformHelper != null)
				{
					return nativePlatformHelper.isApplicationFocused;
				}
				return ReInput.nDMYShWfGPGIuiUMgblXmqJTZwNQ;
			}
		}

		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x060014A4 RID: 5284 RVA: 0x00011C2D File Offset: 0x0000FE2D
		[CustomObfuscation(rename = false)]
		internal static bool isWindowsStandaloneWebplayerOrEditorPlatform
		{
			get
			{
				return ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr && ReInput.QlUQYHZcxMVTJoGKPDmhRoCscfSt && (ReInput.UNWPXAlZDFTHmNTPXTEOxtNFPpqL == Platform.Windows || (ReInput.UNWPXAlZDFTHmNTPXTEOxtNFPpqL == Platform.Webplayer && ReInput.fywzAMAeyvDqLeoMZlDlgEEMMZJT == WebplayerPlatform.Windows) || ReInput.XgVQfWiQHYFdfDmAnXoxHosiAHtP == EditorPlatform.Windows);
			}
		}

		// Token: 0x17000508 RID: 1288
		// (get) Token: 0x060014A5 RID: 5285 RVA: 0x00067510 File Offset: 0x00065710
		private static bool ezGpYDFDCDYpzdUWIbATBLKyHqDs
		{
			get
			{
				if (!ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr)
				{
					return false;
				}
				if (!ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.rutBILBASpvjbeYJDZwPjebprXZE.value)
				{
					if (ReInput.qzoQxOyjNhaIlzSeGpSCcXJTguDr)
					{
						return false;
					}
					if ((!ReInput.isEditor || !ReInput.isUnityEditorFocused) && !ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.rvKQZFRPikQMpTaHPHQxcySywmJC.value)
					{
						return false;
					}
				}
				return true;
			}
		}

		// Token: 0x060014A6 RID: 5286 RVA: 0x00011C64 File Offset: 0x0000FE64
		[CustomObfuscation(rename = false)]
		internal static bool IsInputAllowed(ControllerType controllerType)
		{
			if (!ReInput.ezGpYDFDCDYpzdUWIbATBLKyHqDs)
			{
				return false;
			}
			if (ReInput.XgVQfWiQHYFdfDmAnXoxHosiAHtP != EditorPlatform.None && (controllerType == ControllerType.Keyboard || controllerType == ControllerType.Mouse))
			{
				if (ReInput.qzoQxOyjNhaIlzSeGpSCcXJTguDr)
				{
					if (!ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.rutBILBASpvjbeYJDZwPjebprXZE.value)
					{
						return false;
					}
				}
				else if (!ReInput.isAllowedEditorWindowFocused)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x060014A7 RID: 5287 RVA: 0x00011CA1 File Offset: 0x0000FEA1
		[CustomObfuscation(rename = false)]
		internal static bool applicationIsFocused
		{
			get
			{
				return ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr && ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.rutBILBASpvjbeYJDZwPjebprXZE.value;
			}
		}

		// Token: 0x1700050A RID: 1290
		// (get) Token: 0x060014A8 RID: 5288 RVA: 0x00011CBB File Offset: 0x0000FEBB
		[CustomObfuscation(rename = false)]
		internal static bool applicationIsPaused
		{
			get
			{
				return ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr && ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.vTNPtZUVycarxkTOqGBONWkQuALF.value;
			}
		}

		// Token: 0x1700050B RID: 1291
		// (get) Token: 0x060014A9 RID: 5289 RVA: 0x00011CD5 File Offset: 0x0000FED5
		[CustomObfuscation(rename = false)]
		internal static bool applicationIsFullScreen
		{
			get
			{
				return ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr && ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.XMNvTburyIayJJDEFBSXnOZvwCCR.value;
			}
		}

		// Token: 0x1700050C RID: 1292
		// (get) Token: 0x060014AA RID: 5290 RVA: 0x00011CEF File Offset: 0x0000FEEF
		[CustomObfuscation(rename = false)]
		internal static bool applicationRunInBackground
		{
			get
			{
				return ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr && ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.rvKQZFRPikQMpTaHPHQxcySywmJC.value;
			}
		}

		// Token: 0x1700050D RID: 1293
		// (get) Token: 0x060014AB RID: 5291 RVA: 0x00011D09 File Offset: 0x0000FF09
		[CustomObfuscation(rename = false)]
		internal static bool timeScaleIsPaused
		{
			get
			{
				return ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr && ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.LbTqjNISjELbhtYROrjuJOavnZue.value;
			}
		}

		// Token: 0x1700050E RID: 1294
		// (get) Token: 0x060014AC RID: 5292 RVA: 0x00011D23 File Offset: 0x0000FF23
		[CustomObfuscation(rename = false)]
		internal static InputManager_Base rewiredInputManager
		{
			get
			{
				return ReInput.ernshACoCJlADnBWudDRchCdqgHc;
			}
		}

		// Token: 0x1700050F RID: 1295
		// (get) Token: 0x060014AD RID: 5293 RVA: 0x00011D2A File Offset: 0x0000FF2A
		[CustomObfuscation(rename = false)]
		internal static PlatformInputManager primaryInputManager
		{
			get
			{
				if (!ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr)
				{
					ReInput.uSogAyPrddarzhIkhAlkgYkwrUqq();
					return null;
				}
				return ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA.primaryInputManager;
			}
		}

		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x060014AE RID: 5294 RVA: 0x00011D44 File Offset: 0x0000FF44
		// (set) Token: 0x060014AF RID: 5295 RVA: 0x00011D4B File Offset: 0x0000FF4B
		[CustomObfuscation(rename = false)]
		internal static IControllerAssigner controllerAssigner
		{
			get
			{
				return ReInput.LARxGpRiFQszeNcnBADOlhVZSQhQ;
			}
			set
			{
				ReInput.LARxGpRiFQszeNcnBADOlhVZSQhQ = value;
			}
		}

		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x060014B0 RID: 5296 RVA: 0x00011D53 File Offset: 0x0000FF53
		[CustomObfuscation(rename = false)]
		internal static RewiredVersion rewiredVersion
		{
			get
			{
				return new RewiredVersion(ReInput.programVersion);
			}
		}

		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x060014B1 RID: 5297 RVA: 0x00011D5F File Offset: 0x0000FF5F
		[CustomObfuscation(rename = false)]
		internal static int timeScalePauseChangedCount
		{
			get
			{
				return ReInput.hZvBixzwwUKJqOFHipjtxwrHZjuG;
			}
		}

		// Token: 0x060014B2 RID: 5298 RVA: 0x00011D66 File Offset: 0x0000FF66
		private static void NJNvjYmwiAVlEPAJeeONvolNPeOK()
		{
			ReInput.UNWPXAlZDFTHmNTPXTEOxtNFPpqL = UnityTools.platform;
			ReInput.fywzAMAeyvDqLeoMZlDlgEEMMZJT = UnityTools.webplayerPlatform;
			ReInput.XgVQfWiQHYFdfDmAnXoxHosiAHtP = UnityTools.editorPlatform;
		}

		// Token: 0x060014B3 RID: 5299 RVA: 0x00067564 File Offset: 0x00065764
		internal static void LrPfCUVWJCfAxiipijJsjVEdbrreb(InputManager_Base A_0, Func<ConfigVars, object> A_1, ConfigVars A_2, ControllerDataFiles A_3, UserData A_4, Func<UnityTools.YlequFlwSpDLySjTazqSoKcKCanv> A_5, Action<Platform> A_6, Action<InputManager_Base.kFIKoXCPTEfvCHTKZIiWTCvYMHssA> A_7)
		{
			try
			{
				ReInput._id = ReInput.MkigKUaelgsfJlPyhktacZZkdtgy;
				ReInput.MkigKUaelgsfJlPyhktacZZkdtgy++;
				ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr = true;
				ReInput.OBjFQCtfJihsHFePjAFGUBuBotYvA = true;
				ReInput.tabJZNZrPYWCGUvcwsLRnXNVDEnE = (UnityTools.isEditor && !Application.isPlaying);
				if (UnityTools.isEditor)
				{
					ReInput.CheckRewiredVersionCompatibility();
				}
				ReInput.ernshACoCJlADnBWudDRchCdqgHc = A_0;
				ReInput.SoNJmklvaubvNUQEVJTopavpXlMC = A_2;
				ReInput.NJNvjYmwiAVlEPAJeeONvolNPeOK();
				if (A_2.logToScreen)
				{
					Logger.logToScreen = true;
				}
				UnityTools.externalTools.EditorPausedStateChangedEvent += ReInput.LsghSFsPCIBEEPOYAQlXWjfRbXZP;
				ReInput.LtnwAoZuGNHrlfpnRahHEdzSRZguA = A_3;
				ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb = A_4;
				ReInput.maeusbshBQoGgXOttwkfOgRNUSUF = new TimerAbs(1.0);
				ReInput.vJBNxHpsKaeldWfiVmEFIJhTbUdaA = new ReInput.HfBpVCHKLggxhOZyzpKLDTEIVkEv();
				LocalizationManager.Initialize();
				GlyphManager.Initialize();
				A_4.yDABbxiARLBWAQcRokAdOcDrDbkT();
				ThreadSafeUnityInput.Initialize();
				ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE = new ReInput.sgWGAtCXhoXotFcNElUxqsMZoVwI();
				if (!UnityTools.isEditor)
				{
					ReInput.nDMYShWfGPGIuiUMgblXmqJTZwNQ = Application.isFocused;
				}
				ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.rutBILBASpvjbeYJDZwPjebprXZE.Set(ReInput.nDMYShWfGPGIuiUMgblXmqJTZwNQ);
				ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.rutBILBASpvjbeYJDZwPjebprXZE.Use();
				if (ReInput.XgVQfWiQHYFdfDmAnXoxHosiAHtP != EditorPlatform.None)
				{
					ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.rutBILBASpvjbeYJDZwPjebprXZE.getValueDelegate = new Func<bool>(ReInput.UiIeThpXEYmSxJzvHrkDCWwYfiuq.<>9.aTMiYFQOALWWAumxAdhQXAMazjIc);
					if (ReInput.tabJZNZrPYWCGUvcwsLRnXNVDEnE)
					{
						ReInput.nDMYShWfGPGIuiUMgblXmqJTZwNQ = ReInput.QaYkamXbSymqTWeEyMMQyVACMVyH;
					}
					ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.rutBILBASpvjbeYJDZwPjebprXZE.Set(ReInput.isUnityEditorFocused && ReInput.isAllowedEditorWindowFocused);
				}
				ReInput.TOGKoHWOEEWxAIFWvBtiHupSFzrwA();
				List<ICustomPlatformInitializer> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<ICustomPlatformInitializer>(A_0.gameObject);
				if (componentsInSelfAndChildren != null)
				{
					for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
					{
						Behaviour behaviour = componentsInSelfAndChildren[i] as Behaviour;
						if (!(behaviour == null) && behaviour.enabled && behaviour.gameObject.activeInHierarchy)
						{
							CustomPlatformInitOptions customPlatformInitOptions = componentsInSelfAndChildren[i].GetCustomPlatformInitOptions();
							if (customPlatformInitOptions != null)
							{
								xApfUAgfQcPgXcXdmaKvwTZGIoxYA.kidcqqMtTLidcqUHAhKRqNcdxuPm(customPlatformInitOptions);
								bool flag = ReInput.XgVQfWiQHYFdfDmAnXoxHosiAHtP > EditorPlatform.None;
								A_7(new InputManager_Base.kFIKoXCPTEfvCHTKZIiWTCvYMHssA
								{
									qWYCnTEYhFRanTPFQEGWdCtLqEaW = Platform.Custom,
									pKDaAWbSYGKYgeEmfJYZUkBdLHBLA = EditorPlatform.None,
									jFjBRbQMUmMEjGHcepRjdUnqYyqi = WebplayerPlatform.None
								});
								ReInput.NJNvjYmwiAVlEPAJeeONvolNPeOK();
								ReInput.vJBNxHpsKaeldWfiVmEFIJhTbUdaA = new ReInput.HfBpVCHKLggxhOZyzpKLDTEIVkEv();
								if (flag)
								{
									Logger.LogWarning("A custom platform is in use. All input will be managed by user-defined custom platform handling.");
									break;
								}
								break;
							}
						}
					}
				}
				ReInput.KzOztCZbrwBaImMWvqWmKtCdhRCS(A_1, A_5(), A_6);
				ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc = new FzUsTilBKKFkYXzvzcXjfuLKjXcd(A_4.GetActions_Copy());
				ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb = new HEnwyLWfnrHknWieEccXGXTAawGsA(A_2, ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA);
				ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA = new lNiLuHSggoLjokYLQforkkbXwySd(A_2);
				ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA.DeviceConnectedEvent += ReInput.ZCJSjwzVmfQzKJJkwxLoukyfGBlf;
				ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA.DeviceDisconnectedEvent += ReInput.GsjvDcgERraNPEwkRPfQElsfQFXU;
				ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA.UpdateControllerInfoEvent += ReInput.AZmfCqDkmqOWnxOBfptaKuEotTJG;
				ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.pDwLWQkBOFqFfqBGYCghPLcMsdAS += ReInput.AQKXwYfGBGqdaBffahyiENAmSZakA;
				ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.LtPhTCapaWOKhCGpZiSRAxvvkCdRA += ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.RrSZCqIrqRKxMlwstGHQNbGSLBhP;
				ThreadSafeUnityInput.PostInitialize();
				ReInput.MzDPmFJPONcvWqjSYVTftChLEMwHA();
				ThreadSafeUnityInput.PostInitialize2();
				ReInput.WdvksUXhQSpBQcjqotpyebeIkYYo = UnityTools.GetComponent<UserDataStore>(ReInput.ernshACoCJlADnBWudDRchCdqgHc);
				if (ReInput.WdvksUXhQSpBQcjqotpyebeIkYYo != null)
				{
					ReInput.WdvksUXhQSpBQcjqotpyebeIkYYo.Initialize();
				}
				ReInput.YCvyjwejYTlAsPEXmePIadOckRiYA();
				ReInput.OBjFQCtfJihsHFePjAFGUBuBotYvA = false;
				if (ReInput.tabJZNZrPYWCGUvcwsLRnXNVDEnE)
				{
					Logger.Log("Rewired is running in Edit mode.");
				}
				if (ReInput.jKDzEiwUQFWZuVavFxOqwDVYJDlH != null)
				{
					ReInput.jKDzEiwUQFWZuVavFxOqwDVYJDlH.Invoke();
				}
			}
			catch (Exception)
			{
				ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr = false;
				ReInput.OBjFQCtfJihsHFePjAFGUBuBotYvA = false;
				throw;
			}
		}

		// Token: 0x060014B4 RID: 5300 RVA: 0x000678D0 File Offset: 0x00065AD0
		internal static void RMwCHkpUbSjwbNFhSEelNdzYhyos()
		{
			if (ReInput.vJBNxHpsKaeldWfiVmEFIJhTbUdaA != null)
			{
				ReInput.vJBNxHpsKaeldWfiVmEFIJhTbUdaA.ycOVuRXlpIqefQIexjoTAwZPjfvT();
			}
			if (ReInput.configVars.deferControllerConnectedEventsOnStart)
			{
				for (int i = 0; i < ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.pkIsaLuBqwgPYsBLElovjkUtIZeo; i++)
				{
					Joystick joystick = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.pVKHDMxRDSNXQLeLUHNMTPLdCAPB[i];
					ReInput.UCzHfydlZWqaMsFkwOfFQFRhHGiEb(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		// Token: 0x060014B5 RID: 5301 RVA: 0x00011D86 File Offset: 0x0000FF86
		internal static void hRANSqleHeWEahqjEjemJLBiZksV(UpdateLoopType A_0)
		{
			if (!ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr)
			{
				return;
			}
			ReInput.FyEbNWhMrFDPMSJJdjVxQHxQPIVbA(A_0);
			if (A_0 <= UpdateLoopType.FixedUpdate)
			{
				ReInput.szypNRdzNscgiUUDXgIQlJfuYWcE();
			}
		}

		// Token: 0x060014B6 RID: 5302 RVA: 0x0006793C File Offset: 0x00065B3C
		private static void FyEbNWhMrFDPMSJJdjVxQHxQPIVbA(UpdateLoopType A_0)
		{
			if (ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE != null)
			{
				ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.lKLobxykkevAQKAIZRbvvsgUIncD();
			}
			Action<UpdateLoopType> action = ReInput.nrVnSODkTzGKxbQKscgdIPWdTPCj;
			if (action != null)
			{
				try
				{
					action(A_0);
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("ReInput.BeforeTimeManagerUpdateEvent", exception);
				}
			}
			ReInput.vJBNxHpsKaeldWfiVmEFIJhTbUdaA.bofmiForSQAXifqLAKxnzfIBdHGLA(A_0);
		}

		// Token: 0x060014B7 RID: 5303 RVA: 0x00067998 File Offset: 0x00065B98
		private static void szypNRdzNscgiUUDXgIQlJfuYWcE()
		{
			int frameCount = Time.frameCount;
			if (ReInput.mksqcRcNTwfZmJzotjelkJlXxOpS == frameCount)
			{
				return;
			}
			ReInput.mksqcRcNTwfZmJzotjelkJlXxOpS = frameCount;
			ThreadSafeUnityInput.Update();
			Action action = ReInput.xLWAJzJccOGCvFYeBwmUXBWvHVXd;
			if (action != null)
			{
				try
				{
					action();
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("ReInput.EarlyUpdateEvent", exception);
				}
			}
		}

		// Token: 0x060014B8 RID: 5304 RVA: 0x000679F0 File Offset: 0x00065BF0
		internal static void hRnHdeFgUwAFYALaqmMboOkfprTrA(UpdateLoopType A_0)
		{
			if (!ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr)
			{
				return;
			}
			if (ReInput.rZZOHmulAahBDJfKujGQayvPctcs != A_0)
			{
				ReInput.rZZOHmulAahBDJfKujGQayvPctcs = A_0;
			}
			if (ReInput.editorPlatform != EditorPlatform.None)
			{
				ReInput.GdOWJqaIGqcwfSTEsiWfbyMecUsH = ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.GecIUVAmgQPOFjYTdiCzxTvdfgAoA.value;
			}
			if (ReInput.LqprkmvlpjcpZESNgpndrDLrlbCZA)
			{
				if (ReInput.maeusbshBQoGgXOttwkfOgRNUSUF.Update())
				{
					ReInput.LqprkmvlpjcpZESNgpndrDLrlbCZA = false;
					ReInput.maeusbshBQoGgXOttwkfOgRNUSUF.Clear();
				}
				else
				{
					ReInput.BlhzLLIoHKNAbUKGAUpQxQgixmXk.xRUbGtxWtCLMAUQJLhLcCBLWIjrDA(A_0);
				}
			}
			ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.WrUceRNcWSFecHUojEtXGlKvcjqXA();
			Action<UpdateLoopType> puQGzkZlCPpQpEoVZkrvOjMiMuny = ReInput.PuQGzkZlCPpQpEoVZkrvOjMiMuny;
			if (puQGzkZlCPpQpEoVZkrvOjMiMuny != null)
			{
				try
				{
					puQGzkZlCPpQpEoVZkrvOjMiMuny(A_0);
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("ReInput.UpdateStartedEvent", exception);
				}
			}
			ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA.Update(A_0);
			if (ReInput.LVjqYCpNsZAXwAnqIcFhOFCwcUlW != null)
			{
				ReInput.LVjqYCpNsZAXwAnqIcFhOFCwcUlW.Invoke();
			}
			ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.YueHljkoyTNDfTFawXsQRxgAFJOH(A_0);
			Action<UpdateLoopType> action = ReInput.gELAMhcZqpKghQLfsIpYglpczIKGb;
			if (action != null)
			{
				try
				{
					action(A_0);
				}
				catch (Exception exception2)
				{
					ReInput.HandleCallbackException("ReInput.UpdateEndedEvent", exception2);
				}
			}
		}

		// Token: 0x060014B9 RID: 5305 RVA: 0x00067AEC File Offset: 0x00065CEC
		internal static void ZYyfjQuhMAOmwHcTKuUXdgutbQobA()
		{
			Action lorHsxecguMdqinqBqxuHnfUvZbC = ReInput.LOrHsxecguMdqinqBqxuHnfUvZbC;
			if (lorHsxecguMdqinqBqxuHnfUvZbC != null)
			{
				try
				{
					lorHsxecguMdqinqBqxuHnfUvZbC();
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("ReInput.LateUpdateEvent", exception);
				}
			}
		}

		// Token: 0x060014BA RID: 5306 RVA: 0x00011D9F File Offset: 0x0000FF9F
		[CustomObfuscation(rename = false)]
		internal static void EditorUpdate()
		{
			if (!ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr || !ReInput.tabJZNZrPYWCGUvcwsLRnXNVDEnE)
			{
				return;
			}
			ReInput.hRANSqleHeWEahqjEjemJLBiZksV(UpdateLoopType.Update);
			ReInput.hRnHdeFgUwAFYALaqmMboOkfprTrA(UpdateLoopType.Update);
			ReInput.ZYyfjQuhMAOmwHcTKuUXdgutbQobA();
		}

		// Token: 0x060014BB RID: 5307 RVA: 0x00011DC1 File Offset: 0x0000FFC1
		internal static void tMJbUxCypzEODHhfVhxcdReGBqwt()
		{
			if (ReInput.pMhcTAFlcJqmTpaHlLZPdxDHRDDNA != null)
			{
				ReInput.pMhcTAFlcJqmTpaHlLZPdxDHRDDNA.Invoke();
			}
			if (ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA != null)
			{
				ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA.OnDestroy();
			}
			ReInput.DUrCnuxyeTBevixWkUrkwmsJGIUJ();
			if (ReInput.pjpHdphDZijFqFNmXwtKlGxDrtvr != null)
			{
				ReInput.pjpHdphDZijFqFNmXwtKlGxDrtvr.Invoke();
				ReInput.pjpHdphDZijFqFNmXwtKlGxDrtvr = null;
			}
		}

		// Token: 0x060014BC RID: 5308 RVA: 0x00011E01 File Offset: 0x00010001
		internal static void DkmfHRmcTuUFQmKAifxmYQwHWrHh()
		{
			if (ReInput.fZajzRVhDEGhvytHDdFhqmbPWsDb == null)
			{
				return;
			}
			ReInput.fZajzRVhDEGhvytHDdFhqmbPWsDb.Invoke();
		}

		// Token: 0x060014BD RID: 5309 RVA: 0x00011E15 File Offset: 0x00010015
		internal static void sZHNYKxEmFyWVOXAFXBTSQkdnmuG(bool A_0)
		{
			ReInput.nDMYShWfGPGIuiUMgblXmqJTZwNQ = A_0;
			if (ReInput.XgVQfWiQHYFdfDmAnXoxHosiAHtP != EditorPlatform.None)
			{
				return;
			}
			if (!ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr)
			{
				return;
			}
			ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.rutBILBASpvjbeYJDZwPjebprXZE.Set(A_0);
			ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.rutBILBASpvjbeYJDZwPjebprXZE.TriggerEvent();
		}

		// Token: 0x060014BE RID: 5310 RVA: 0x00011E4E File Offset: 0x0001004E
		internal static void EDEGnlihHGIDPbxrrLhmNmibJTVDb(bool A_0)
		{
			if (!ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr)
			{
				return;
			}
			ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.vTNPtZUVycarxkTOqGBONWkQuALF.Set(A_0);
			ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.vTNPtZUVycarxkTOqGBONWkQuALF.TriggerEvent();
		}

		// Token: 0x060014BF RID: 5311 RVA: 0x00067B28 File Offset: 0x00065D28
		internal static void JIqejkCFJSXNogQeDZEPnNMCBeoUA()
		{
			if (!ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr)
			{
				return;
			}
			Action zwoXUiShIAZgqiIefJqzsBpgslLE = ReInput.ZWoXUiShIAZgqiIefJqzsBpgslLE;
			if (zwoXUiShIAZgqiIefJqzsBpgslLE != null)
			{
				try
				{
					zwoXUiShIAZgqiIefJqzsBpgslLE();
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("ReInput.SceneLoadedEvent", exception);
				}
			}
		}

		// Token: 0x060014C0 RID: 5312 RVA: 0x00011E79 File Offset: 0x00010079
		[CustomObfuscation(rename = false)]
		internal static HardwareJoystickMap_InputManager GetHardwareJoystickMap_InputManager(BridgedControllerHWInfo bridgedController)
		{
			return ReInput.LtnwAoZuGNHrlfpnRahHEdzSRZguA.bavNHeqJEpxWdAaJxQBUPtdrXCRD(bridgedController);
		}

		// Token: 0x060014C1 RID: 5313 RVA: 0x00011E86 File Offset: 0x00010086
		internal static HardwareJoystickMap uvbTXFnBIWdsaBbqTxQYWiewbGQW(Guid A_0)
		{
			return ReInput.LtnwAoZuGNHrlfpnRahHEdzSRZguA.GetHardwareJoystickMap(A_0);
		}

		// Token: 0x060014C2 RID: 5314 RVA: 0x00011E93 File Offset: 0x00010093
		internal static HardwareJoystickTemplateMap uRpaawDYhbeOcEvysNVmUlguJYt(Guid A_0)
		{
			return ReInput.LtnwAoZuGNHrlfpnRahHEdzSRZguA.GetJoystickTemplate(A_0);
		}

		// Token: 0x060014C3 RID: 5315 RVA: 0x00011EA0 File Offset: 0x000100A0
		internal static COootOIiwXGzUSdmLyqHaOKMeIvB jXQhCsUPqOUhARLDxEqlegquceWi(Guid A_0)
		{
			return ReInput.LtnwAoZuGNHrlfpnRahHEdzSRZguA.dTqQVwDISJZDemPvAbgXbTdrRlSM(A_0);
		}

		// Token: 0x060014C4 RID: 5316 RVA: 0x00011EAD File Offset: 0x000100AD
		internal static IHardwareControllerTemplateMap FZemvxaokuPsIvkWyhodRsdwixpT(Guid A_0)
		{
			return ReInput.LtnwAoZuGNHrlfpnRahHEdzSRZguA.GetControllerTemplate(A_0);
		}

		// Token: 0x060014C5 RID: 5317 RVA: 0x00011EBA File Offset: 0x000100BA
		internal static IHardwareControllerTemplateMap UKCRsGlOBNUIwmXiQxEalDQxdbAF(Guid A_0)
		{
			return ReInput.LtnwAoZuGNHrlfpnRahHEdzSRZguA.kxKktQsKYiLdrwjwHgKIXbZzEyzK(A_0);
		}

		// Token: 0x060014C6 RID: 5318 RVA: 0x00067B6C File Offset: 0x00065D6C
		internal static IList<COootOIiwXGzUSdmLyqHaOKMeIvB> FnIiSrUmuVbWfEIDNpGFxuuzlUPdA(Guid A_0)
		{
			HardwareJoystickMap hardwareJoystickMap = ReInput.LtnwAoZuGNHrlfpnRahHEdzSRZguA.GetHardwareJoystickMap(A_0);
			if (hardwareJoystickMap == null)
			{
				return EmptyObjects<COootOIiwXGzUSdmLyqHaOKMeIvB>.EmptyReadOnlyIListT;
			}
			string[] templateGuidsOrig = hardwareJoystickMap.GetTemplateGuidsOrig();
			if (templateGuidsOrig == null || templateGuidsOrig.Length == 0)
			{
				return EmptyObjects<COootOIiwXGzUSdmLyqHaOKMeIvB>.EmptyReadOnlyIListT;
			}
			List<COootOIiwXGzUSdmLyqHaOKMeIvB> list = null;
			int i = 0;
			while (i < templateGuidsOrig.Length)
			{
				Guid guid;
				try
				{
					guid = new Guid(templateGuidsOrig[i]);
				}
				catch
				{
					Logger.LogWarning("Controller Template GUID is invalid: " + templateGuidsOrig[i]);
					goto IL_94;
				}
				goto IL_57;
				IL_94:
				i++;
				continue;
				IL_57:
				COootOIiwXGzUSdmLyqHaOKMeIvB coootOIiwXGzUSdmLyqHaOKMeIvB = ReInput.jXQhCsUPqOUhARLDxEqlegquceWi(guid);
				if (coootOIiwXGzUSdmLyqHaOKMeIvB == null)
				{
					Logger.LogWarning("Controller Template was not found for GUID " + guid.ToString());
					goto IL_94;
				}
				if (list == null)
				{
					list = new List<COootOIiwXGzUSdmLyqHaOKMeIvB>();
				}
				ListTools.AddIfUnique<COootOIiwXGzUSdmLyqHaOKMeIvB>(list, coootOIiwXGzUSdmLyqHaOKMeIvB);
				goto IL_94;
			}
			if (list == null)
			{
				return EmptyObjects<COootOIiwXGzUSdmLyqHaOKMeIvB>.EmptyReadOnlyIListT;
			}
			return list;
		}

		// Token: 0x060014C7 RID: 5319 RVA: 0x00011EC7 File Offset: 0x000100C7
		[CustomObfuscation(rename = false)]
		internal static int GetNewJoystickId()
		{
			return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.UOrjphQQxuWXARuoHlDOpjFNKtDf();
		}

		// Token: 0x060014C8 RID: 5320 RVA: 0x00067C34 File Offset: 0x00065E34
		[CustomObfuscation(rename = false)]
		internal static void HandleCallbackException(string source, Exception exception)
		{
			string str = "An exception occurred inside an event handler or callback.\nSource: ";
			string str2 = "\n\nThis happens if your event handler/callback code throws an exception. This means the error is in your code, not Rewired. Read the exception message and the stack trace carefully to find the source of the exception being thrown by your code.\n\nThis can also happen if you forget to unsubscribe to an event in a MonoBehaviour class and that object gets destroyed. Make sure you unsubscribe to events in OnDisable or OnDestroy. Rewired will attempt to continue running.\n\nException:\n";
			Exception ex = (exception.InnerException != null) ? exception.InnerException : exception;
			string msg = str + source + str2 + ((ex != null) ? ex.ToString() : null);
			Logger.LogException((exception.InnerException != null) ? exception.InnerException : exception, msg, true);
		}

		// Token: 0x060014C9 RID: 5321 RVA: 0x00011ED3 File Offset: 0x000100D3
		[CustomObfuscation(rename = false)]
		internal static void HandleExternException(string source, Exception exception)
		{
			Logger.LogException((exception.InnerException != null) ? exception.InnerException : exception, string.Empty, true);
		}

		// Token: 0x060014CA RID: 5322 RVA: 0x00067C88 File Offset: 0x00065E88
		[CustomObfuscation(rename = false)]
		internal static void HandleExternalInterfaceException(string source, Exception exception)
		{
			string str = "An exception occurred inside an external function call.\nSource: ";
			string str2 = "\n\nThis happens if the external function throws an exception. This could indicate the error is in your code if Rewired is calling a function in an interface implementation you created. Read the exception message and the stack trace carefully to find the source of the exception being thrown.\n\nThis can also happen if you forget to unsubscribe to an event in a MonoBehaviour class and that object gets destroyed.\n\nException:\n";
			Exception ex = (exception.InnerException != null) ? exception.InnerException : exception;
			string msg = str + source + str2 + ((ex != null) ? ex.ToString() : null);
			Logger.LogException((exception.InnerException != null) ? exception.InnerException : exception, msg, true);
		}

		// Token: 0x060014CB RID: 5323 RVA: 0x00011EF1 File Offset: 0x000100F1
		internal static void iWZHUFNAlqcgLBBzMMpzDdzHFrCic()
		{
			if (!ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr)
			{
				return;
			}
			ReInput.YCvyjwejYTlAsPEXmePIadOckRiYA();
		}

		// Token: 0x060014CC RID: 5324 RVA: 0x00011F00 File Offset: 0x00010100
		[CustomObfuscation(rename = false)]
		internal static void CheckRewiredVersionCompatibility()
		{
			if (UnityTools.unityVersionObj != null && 2022 != UnityTools.unityVersionObj.major)
			{
				ReInput.EhVfDxJwvyQRqbuMLfnpjafVsmKIA();
			}
		}

		// Token: 0x060014CD RID: 5325 RVA: 0x00011F25 File Offset: 0x00010125
		internal static float kYZJtBVYMOMsclMCCcBfbCCUfZJXA()
		{
			return ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.OOxSVUylnEuKCUKdDAfvdTkvRofcA.value;
		}

		// Token: 0x060014CE RID: 5326 RVA: 0x00011F36 File Offset: 0x00010136
		[CustomObfuscation(rename = false)]
		internal static bool CheckInitialized()
		{
			if (!ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr)
			{
				Logger.LogError("Rewired is not initialized. You must have an active and enabled Rewired Input Manager in the scene before calling any part of the Rewired API.");
				return false;
			}
			return true;
		}

		// Token: 0x060014CF RID: 5327 RVA: 0x00011F4C File Offset: 0x0001014C
		[CustomObfuscation(rename = false)]
		internal static bool CheckInitialized(int reInputId)
		{
			if (!ReInput.CheckInitialized())
			{
				return false;
			}
			if (ReInput._id != reInputId)
			{
				Logger.LogError("You are attemping to access an object that was created by a previous session or different instance of Rewired and is no longer valid. When Rewired is reset or the Rewired Input Manager is disabled or destroyed, all old object references become invalid and can no longer be used. If you deinitialize Rewired, you cannot use locally stored Rewired objects obtained prior to deinitialization and you must get new objects from the Rewired API.");
				return false;
			}
			return true;
		}

		// Token: 0x060014D0 RID: 5328 RVA: 0x00011F6C File Offset: 0x0001016C
		private static void MzDPmFJPONcvWqjSYVTftChLEMwHA()
		{
			ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.nCqQXpERRSjcZexCfinOHERlXKhM();
			ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.okXfhEGQWJdcDOXIKcVCPRmxhajLA(ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA.GetInputDataUpdateDelegate(), ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetInputBehaviors_Copy());
			ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA.Initialize();
		}

		// Token: 0x060014D1 RID: 5329 RVA: 0x00067CDC File Offset: 0x00065EDC
		private static void DUrCnuxyeTBevixWkUrkwmsJGIUJ()
		{
			if (ReInput.ernshACoCJlADnBWudDRchCdqgHc != null)
			{
				List<IExternalInputManager> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(ReInput.ernshACoCJlADnBWudDRchCdqgHc);
				for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
				{
					componentsInSelfAndChildren[i].Deinitialize();
				}
			}
			ReInput.ernshACoCJlADnBWudDRchCdqgHc = null;
			ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA = null;
			ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc = null;
			if (ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb != null)
			{
				ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.Dispose();
			}
			ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb = null;
			ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA = null;
			ReInput.LtnwAoZuGNHrlfpnRahHEdzSRZguA = null;
			if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb != null)
			{
				ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.FIFEvFFnromSBQiDTiqGJpwLINNyA();
			}
			ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb = null;
			ReInput.LocalizationHelper.FRukKCSZUtuLNnxZfsjhGGCSzVtb();
			ReInput.GlyphHelper.pOFFfICGmFdfDdqKaTQlmkRKtSzjb();
			LocalizationManager.Deinitialize();
			GlyphManager.Deinitialize();
			ReInput.LARxGpRiFQszeNcnBADOlhVZSQhQ = null;
			ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr = false;
			ReInput.SoNJmklvaubvNUQEVJTopavpXlMC = null;
			ReInput.rZZOHmulAahBDJfKujGQayvPctcs = UpdateLoopType.Update;
			ReInput.QlUQYHZcxMVTJoGKPDmhRoCscfSt = false;
			ReInput.UNWPXAlZDFTHmNTPXTEOxtNFPpqL = Platform.Windows;
			ReInput.fywzAMAeyvDqLeoMZlDlgEEMMZJT = WebplayerPlatform.None;
			ReInput.XgVQfWiQHYFdfDmAnXoxHosiAHtP = EditorPlatform.None;
			ReInput.LqprkmvlpjcpZESNgpndrDLrlbCZA = false;
			ReInput.maeusbshBQoGgXOttwkfOgRNUSUF = null;
			ReInput.vJBNxHpsKaeldWfiVmEFIJhTbUdaA = null;
			ReInput.GdOWJqaIGqcwfSTEsiWfbyMecUsH = null;
			ReInput.qzoQxOyjNhaIlzSeGpSCcXJTguDr = false;
			ReInput.tabJZNZrPYWCGUvcwsLRnXNVDEnE = false;
			ReInput.nDMYShWfGPGIuiUMgblXmqJTZwNQ = true;
			ReInput.mksqcRcNTwfZmJzotjelkJlXxOpS = -1;
			ReInput._id = -1;
			ReInput.hZvBixzwwUKJqOFHipjtxwrHZjuG = 0;
			ReInput.unscaledDeltaTime = 0.0;
			ReInput.unscaledTime = 0.0;
			ReInput.unscaledTimePrev = 0.0;
			ReInput.currentFrame = 0U;
			ReInput.previousFrame = 0U;
			ReInput.absFrame = 0U;
			ReInput.UEFYKTaOUSSTqBbviFjsxmENJYBc.Clear();
			ReInput.zfIKshnBBvAXDAiCCLdHCtlvsQjB.Clear();
			ReInput.UUfjdHbAElCbsJpQiClpEvhUJbfbA.Clear();
			ReInput.LVjqYCpNsZAXwAnqIcFhOFCwcUlW.Clear();
			ReInput.fZajzRVhDEGhvytHDdFhqmbPWsDb.Clear();
			ReInput._ApplicationFocusChangedEvent = null;
			ReInput._ApplicationPauseChangedEvent = null;
			ReInput.LLFgTpfdbygzgBYpKYAixPcVfGWPA = null;
			ReInput.wqsGNskAhqmEMBbFOxiqPMJrycHB = null;
			ReInput.KBoRXrwTuYDuZHopkwTDxKJLGiGkA = null;
			ReInput.QQWawwrzcmBejonOKMpssNUXrEOd = null;
			ReInput.xLWAJzJccOGCvFYeBwmUXBWvHVXd = null;
			ReInput.PuQGzkZlCPpQpEoVZkrvOjMiMuny = null;
			ReInput.gELAMhcZqpKghQLfsIpYglpczIKGb = null;
			ReInput.LOrHsxecguMdqinqBqxuHnfUvZbC = null;
			ReInput.pMhcTAFlcJqmTpaHlLZPdxDHRDDNA = null;
			ReInput.ZWoXUiShIAZgqiIefJqzsBpgslLE = null;
			ReInput.hlKLGuFZViiMwhOZYgOQilkPoQYkA = null;
			ReInput.QDzhoheDkJpevJBEaZQchQApGpebA();
			ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE = null;
			ThreadSafeUnityInput.Deinitialize();
			if (UnityTools.externalTools != null)
			{
				UnityTools.externalTools.EditorPausedStateChangedEvent -= ReInput.LsghSFsPCIBEEPOYAQlXWjfRbXZP;
			}
			xApfUAgfQcPgXcXdmaKvwTZGIoxYA.reIfIRfdmmHnkEcFiuHGQPySJmtZb();
		}

		// Token: 0x060014D2 RID: 5330 RVA: 0x00067ED8 File Offset: 0x000660D8
		private static void RxrzplZzBeMKNoBVVEicFMDBobiBA(string A_0 = null)
		{
			string str;
			if (A_0 != null)
			{
				str = A_0;
			}
			else
			{
				str = "This function";
			}
			Logger.LogError(str + " can only be called in Play mode!");
		}

		// Token: 0x060014D3 RID: 5331 RVA: 0x00011FA0 File Offset: 0x000101A0
		private static void qjcZxkIfQReRjTLdZnHhzPbPWJYv()
		{
			if (!ReInput.LqprkmvlpjcpZESNgpndrDLrlbCZA)
			{
				ReInput.LqprkmvlpjcpZESNgpndrDLrlbCZA = true;
				ReInput.BlhzLLIoHKNAbUKGAUpQxQgixmXk.xYATigZDSCcJRqAZZXbuklDMbkks();
				ReInput.BlhzLLIoHKNAbUKGAUpQxQgixmXk.TCxEDFffruDjuxBbtWejNWEaJnnWA();
			}
			ReInput.maeusbshBQoGgXOttwkfOgRNUSUF.Start();
		}

		// Token: 0x060014D4 RID: 5332 RVA: 0x00011FCD File Offset: 0x000101CD
		private static void uSogAyPrddarzhIkhAlkgYkwrUqq()
		{
			Logger.LogError("Rewired is not initialized. Do you have a Rewired Input Manager in the scene and enabled?");
		}

		// Token: 0x060014D5 RID: 5333 RVA: 0x00067F04 File Offset: 0x00066104
		private static void ZCJSjwzVmfQzKJJkwxLoukyfGBlf(BridgedController A_0)
		{
			if (A_0.sourceJoystick == null)
			{
				return;
			}
			ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.aVioCFgQATfLSKSkCmWndqXWTaIU(A_0);
			Joystick joystick = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.oyUTQmcDwKIecWNjUFSrDrvyaWIt(A_0.sourceJoystick.rewiredId, false);
			if (joystick == null)
			{
				return;
			}
			ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.JWTHzoGqaqFNnEnQRNBarHDNkbPM(joystick);
			if (ReInput.configVars.deferControllerConnectedEventsOnStart && ReInput.OBjFQCtfJihsHFePjAFGUBuBotYvA)
			{
				return;
			}
			ReInput.UCzHfydlZWqaMsFkwOfFQFRhHGiEb(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
		}

		// Token: 0x060014D6 RID: 5334 RVA: 0x00067F7C File Offset: 0x0006617C
		private static void GsjvDcgERraNPEwkRPfQElsfQFXU(ControllerDisconnectedEventArgs A_0)
		{
			if (A_0 == null)
			{
				return;
			}
			Joystick joystick = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.oyUTQmcDwKIecWNjUFSrDrvyaWIt(A_0.rewiredId, false);
			if (joystick == null)
			{
				return;
			}
			ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.bVMrllFgpwASiaOczVElCvZULZhQ(A_0.rewiredId);
			ReInput.nrTNXGWiPqUVOoYUhAlPRcohgWabA(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
		}

		// Token: 0x060014D7 RID: 5335 RVA: 0x00011FD9 File Offset: 0x000101D9
		private static void UCzHfydlZWqaMsFkwOfFQFRhHGiEb(ControllerStatusChangedEventArgs A_0)
		{
			if (ReInput.UEFYKTaOUSSTqBbviFjsxmENJYBc != null)
			{
				ReInput.UEFYKTaOUSSTqBbviFjsxmENJYBc.Invoke(A_0);
			}
		}

		// Token: 0x060014D8 RID: 5336 RVA: 0x00011FED File Offset: 0x000101ED
		private static void AQKXwYfGBGqdaBffahyiENAmSZakA(ControllerStatusChangedEventArgs A_0)
		{
			if (ReInput.zfIKshnBBvAXDAiCCLdHCtlvsQjB != null)
			{
				ReInput.zfIKshnBBvAXDAiCCLdHCtlvsQjB.Invoke(A_0);
			}
		}

		// Token: 0x060014D9 RID: 5337 RVA: 0x00012001 File Offset: 0x00010201
		private static void nrTNXGWiPqUVOoYUhAlPRcohgWabA(ControllerStatusChangedEventArgs A_0)
		{
			if (ReInput.UUfjdHbAElCbsJpQiClpEvhUJbfbA != null)
			{
				ReInput.UUfjdHbAElCbsJpQiClpEvhUJbfbA.Invoke(A_0);
			}
		}

		// Token: 0x060014DA RID: 5338 RVA: 0x00012015 File Offset: 0x00010215
		private static void AZmfCqDkmqOWnxOBfptaKuEotTJG(UpdateControllerInfoEventArgs A_0)
		{
			ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.EIdqjxTbBjDdvrJvmaWRQaGtrdPs(A_0);
		}

		// Token: 0x060014DB RID: 5339 RVA: 0x00067FD0 File Offset: 0x000661D0
		private static void RzkKMwTqOWxuhHiruGKqSHJxnEGM(bool A_0)
		{
			if (!ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr)
			{
				return;
			}
			Action<bool> applicationFocusChangedEvent = ReInput._ApplicationFocusChangedEvent;
			if (applicationFocusChangedEvent != null)
			{
				try
				{
					applicationFocusChangedEvent(A_0);
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("ReInput.ApplicationFocusChangedEvent", exception);
				}
			}
		}

		// Token: 0x060014DC RID: 5340 RVA: 0x00068018 File Offset: 0x00066218
		private static void HvygiTflvvNWaTmYLglzUrkLOxcbA(bool A_0)
		{
			if (!ReInput.weOLiakCdgKMUfGsyDRVZjQkBTxr)
			{
				return;
			}
			Action<bool> applicationPauseChangedEvent = ReInput._ApplicationPauseChangedEvent;
			if (applicationPauseChangedEvent != null)
			{
				try
				{
					applicationPauseChangedEvent(A_0);
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("ReInput.ApplicationPauseChangedEvent", exception);
				}
			}
		}

		// Token: 0x060014DD RID: 5341 RVA: 0x00068060 File Offset: 0x00066260
		private static void HhYHhcBcgygBjeSiQVdtQnZNBWkdA(bool A_0)
		{
			Action<bool> llfgTpfdbygzgBYpKYAixPcVfGWPA = ReInput.LLFgTpfdbygzgBYpKYAixPcVfGWPA;
			if (llfgTpfdbygzgBYpKYAixPcVfGWPA != null)
			{
				try
				{
					llfgTpfdbygzgBYpKYAixPcVfGWPA(A_0);
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("ReInput.ApplicationIsFullScreenChangedEvent", exception);
				}
			}
		}

		// Token: 0x060014DE RID: 5342 RVA: 0x000680A0 File Offset: 0x000662A0
		private static void IztzRMJqjVXMoljhLkEmXvqmmHou(int A_0)
		{
			if (ReInput.KBoRXrwTuYDuZHopkwTDxKJLGiGkA != null)
			{
				try
				{
					ReInput.KBoRXrwTuYDuZHopkwTDxKJLGiGkA((FullScreenMode)A_0);
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("ReInput.ApplicationFullScreenModeChangedEvent", exception);
				}
			}
		}

		// Token: 0x060014DF RID: 5343 RVA: 0x000680E0 File Offset: 0x000662E0
		private static void dbAatyRVNXSHSFHRQLblcEhrHzMO(bool A_0)
		{
			Action<bool> action = ReInput.wqsGNskAhqmEMBbFOxiqPMJrycHB;
			if (action != null)
			{
				try
				{
					action(A_0);
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("ReInput.ApplicationRunInBackgroundChangedEvent", exception);
				}
			}
		}

		// Token: 0x060014E0 RID: 5344 RVA: 0x00068120 File Offset: 0x00066320
		private static void njiInNDnUPCqNyecYxFWGoNFxzIt(bool A_0)
		{
			ReInput.hZvBixzwwUKJqOFHipjtxwrHZjuG++;
			Action<bool> qqwawwrzcmBejonOKMpssNUXrEOd = ReInput.QQWawwrzcmBejonOKMpssNUXrEOd;
			if (qqwawwrzcmBejonOKMpssNUXrEOd != null)
			{
				try
				{
					qqwawwrzcmBejonOKMpssNUXrEOd(A_0);
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("ReInput.TimeScalePauseChangedEvent", exception);
				}
			}
		}

		// Token: 0x060014E1 RID: 5345 RVA: 0x0006816C File Offset: 0x0006636C
		private static void TOGKoHWOEEWxAIFWvBtiHupSFzrwA()
		{
			if (ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE == null)
			{
				return;
			}
			ReInput.QDzhoheDkJpevJBEaZQchQApGpebA();
			ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.rutBILBASpvjbeYJDZwPjebprXZE.ChangedEvent += ReInput.RzkKMwTqOWxuhHiruGKqSHJxnEGM;
			ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.vTNPtZUVycarxkTOqGBONWkQuALF.ChangedEvent += ReInput.HvygiTflvvNWaTmYLglzUrkLOxcbA;
			ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.XMNvTburyIayJJDEFBSXnOZvwCCR.ChangedEvent += ReInput.HhYHhcBcgygBjeSiQVdtQnZNBWkdA;
			ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.rvKQZFRPikQMpTaHPHQxcySywmJC.ChangedEvent += ReInput.dbAatyRVNXSHSFHRQLblcEhrHzMO;
			ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.zxMyfjLPdWwzBTXGaTCHwkcVloKu.ChangedEvent += ReInput.IztzRMJqjVXMoljhLkEmXvqmmHou;
			ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.LbTqjNISjELbhtYROrjuJOavnZue.ChangedEvent += ReInput.njiInNDnUPCqNyecYxFWGoNFxzIt;
		}

		// Token: 0x060014E2 RID: 5346 RVA: 0x00068228 File Offset: 0x00066428
		private static void QDzhoheDkJpevJBEaZQchQApGpebA()
		{
			if (ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE == null)
			{
				return;
			}
			ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.rutBILBASpvjbeYJDZwPjebprXZE.ChangedEvent -= ReInput.RzkKMwTqOWxuhHiruGKqSHJxnEGM;
			ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.vTNPtZUVycarxkTOqGBONWkQuALF.ChangedEvent -= ReInput.HvygiTflvvNWaTmYLglzUrkLOxcbA;
			ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.XMNvTburyIayJJDEFBSXnOZvwCCR.ChangedEvent -= ReInput.HhYHhcBcgygBjeSiQVdtQnZNBWkdA;
			ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.rvKQZFRPikQMpTaHPHQxcySywmJC.ChangedEvent -= ReInput.dbAatyRVNXSHSFHRQLblcEhrHzMO;
			ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.zxMyfjLPdWwzBTXGaTCHwkcVloKu.ChangedEvent -= ReInput.IztzRMJqjVXMoljhLkEmXvqmmHou;
			ReInput.YSnkwlMizJgJyPRFvRWlfEFzEzFE.LbTqjNISjELbhtYROrjuJOavnZue.ChangedEvent -= ReInput.njiInNDnUPCqNyecYxFWGoNFxzIt;
		}

		// Token: 0x060014E3 RID: 5347 RVA: 0x000682E0 File Offset: 0x000664E0
		private static void LsghSFsPCIBEEPOYAQlXWjfRbXZP(bool A_0)
		{
			Action<bool> action = ReInput.hlKLGuFZViiMwhOZYgOQilkPoQYkA;
			if (action != null)
			{
				try
				{
					action(A_0);
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("ReInput.EditorPauseChangedEvent", exception);
				}
			}
		}

		// Token: 0x060014E4 RID: 5348 RVA: 0x00068320 File Offset: 0x00066520
		private static void KzOztCZbrwBaImMWvqWmKtCdhRCS(Func<ConfigVars, object> A_0, UnityTools.YlequFlwSpDLySjTazqSoKcKCanv A_1, Action<Platform> A_2)
		{
			bool flag = false;
			if (A_1.PUBMBpURbtrqwjMzKnkdubHBAasQ != A_1.bOIbQlcqVEmVTpWLmZRfnqguPHenA)
			{
				UnityTools.YlequFlwSpDLySjTazqSoKcKCanv ylequFlwSpDLySjTazqSoKcKCanv = A_1;
				ylequFlwSpDLySjTazqSoKcKCanv.PUBMBpURbtrqwjMzKnkdubHBAasQ = A_1.bOIbQlcqVEmVTpWLmZRfnqguPHenA;
				UnityTools.lrutRDBRTqRQPWEynTmVnBSYKYnJ(ylequFlwSpDLySjTazqSoKcKCanv);
				A_2(ylequFlwSpDLySjTazqSoKcKCanv.bOIbQlcqVEmVTpWLmZRfnqguPHenA);
				ReInput.NJNvjYmwiAVlEPAJeeONvolNPeOK();
				flag = true;
			}
			if (!ReInput.configVars.DoesPlatformUseFallback(A_1.bOIbQlcqVEmVTpWLmZRfnqguPHenA, A_1.kzWArcCGSwWIHywpausYDnllCKan, ReInput.isEditor) && !ReInput.configVars.DoesPlatformUseFallback(A_1.PUBMBpURbtrqwjMzKnkdubHBAasQ, A_1.kzWArcCGSwWIHywpausYDnllCKan, ReInput.isEditor))
			{
				List<IExternalInputManager> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(ReInput.ernshACoCJlADnBWudDRchCdqgHc);
				for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
				{
					PlatformInputManager platformInputManager = componentsInSelfAndChildren[i].Initialize(A_1.bOIbQlcqVEmVTpWLmZRfnqguPHenA, ReInput.SoNJmklvaubvNUQEVJTopavpXlMC) as PlatformInputManager;
					if (platformInputManager != null)
					{
						ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA = platformInputManager;
						return;
					}
				}
			}
			if (flag)
			{
				UnityTools.lrutRDBRTqRQPWEynTmVnBSYKYnJ(A_1);
				A_2(A_1.bOIbQlcqVEmVTpWLmZRfnqguPHenA);
				ReInput.NJNvjYmwiAVlEPAJeeONvolNPeOK();
			}
			if (ReInput.configVars.DoesPlatformUseFallback(ReInput.UNWPXAlZDFTHmNTPXTEOxtNFPpqL, ReInput.fywzAMAeyvDqLeoMZlDlgEEMMZJT, ReInput.isEditor))
			{
				ReInput.QlUQYHZcxMVTJoGKPDmhRoCscfSt = true;
				ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA = new fFtwXUyOtDAzCuDcEEFLaeTsVAeqA(ReInput.SoNJmklvaubvNUQEVJTopavpXlMC.updateLoop);
			}
			else if (ReInput.UNWPXAlZDFTHmNTPXTEOxtNFPpqL == Platform.Windows || ReInput.UNWPXAlZDFTHmNTPXTEOxtNFPpqL == Platform.WindowsAppStore || ReInput.UNWPXAlZDFTHmNTPXTEOxtNFPpqL == Platform.WindowsUWP || ReInput.UNWPXAlZDFTHmNTPXTEOxtNFPpqL == Platform.OSX || ReInput.UNWPXAlZDFTHmNTPXTEOxtNFPpqL == Platform.Linux)
			{
				ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA = (A_0(ReInput.SoNJmklvaubvNUQEVJTopavpXlMC) as PlatformInputManager);
			}
			else
			{
				if (ReInput.UNWPXAlZDFTHmNTPXTEOxtNFPpqL == Platform.WebGL && !ReInput.isEditor)
				{
					try
					{
						ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA = (A_0(ReInput.SoNJmklvaubvNUQEVJTopavpXlMC) as PlatformInputManager);
						if (ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA == null)
						{
							throw new Exception();
						}
						goto IL_3E7;
					}
					catch
					{
						Logger.LogError("WebGL platform could not be initialized! Is the Rewired WebGL library installed? See the documentation for more information.");
						ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA = null;
						goto IL_3E7;
					}
				}
				if (ReInput.UNWPXAlZDFTHmNTPXTEOxtNFPpqL == Platform.XboxOne && !ReInput.isEditor)
				{
					try
					{
						ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA = new CustomInputManager(new XboxOneInputSource(), ReInput.SoNJmklvaubvNUQEVJTopavpXlMC.updateLoop, new Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager>(ReInput.GetHardwareJoystickMap_InputManager), new Func<int>(ReInput.GetNewJoystickId));
						if (ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA == null)
						{
							throw new Exception();
						}
						goto IL_3E7;
					}
					catch
					{
						Logger.LogError("Xbox One platform could not be initialized! Is the Rewired Xbox One library installed? See the documentation for more information.");
						ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA = null;
						goto IL_3E7;
					}
				}
				if (ReInput.UNWPXAlZDFTHmNTPXTEOxtNFPpqL == Platform.PS4 && !ReInput.isEditor)
				{
					try
					{
						ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA = (A_0(ReInput.SoNJmklvaubvNUQEVJTopavpXlMC) as PlatformInputManager);
						if (ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA == null)
						{
							throw new Exception("Input Manager was null.");
						}
						goto IL_3E7;
					}
					catch (Exception msg)
					{
						Logger.LogError("PS4 platform could not be initialized! Is the Rewired PS4 plugin installed? See the documentation for more information.");
						Logger.LogError(msg);
						ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA = null;
						goto IL_3E7;
					}
				}
				if (ReInput.UNWPXAlZDFTHmNTPXTEOxtNFPpqL == Platform.PS5 && !ReInput.isEditor)
				{
					try
					{
						ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA = (A_0(ReInput.SoNJmklvaubvNUQEVJTopavpXlMC) as PlatformInputManager);
						if (ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA == null)
						{
							throw new Exception("Input Manager was null.");
						}
						goto IL_3E7;
					}
					catch (Exception msg2)
					{
						Logger.LogError("PS5 platform could not be initialized! Is the Rewired PS5 plugin installed? See the documentation for more information.");
						Logger.LogError(msg2);
						ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA = null;
						goto IL_3E7;
					}
				}
				if ((ReInput.UNWPXAlZDFTHmNTPXTEOxtNFPpqL == Platform.GameCoreXboxOne || ReInput.UNWPXAlZDFTHmNTPXTEOxtNFPpqL == Platform.GameCoreScarlett) && !ReInput.isEditor)
				{
					try
					{
						ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA = (A_0(ReInput.SoNJmklvaubvNUQEVJTopavpXlMC) as PlatformInputManager);
						if (ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA == null)
						{
							throw new Exception("Input Manager was null.");
						}
						goto IL_3E7;
					}
					catch (Exception msg3)
					{
						string text = (ReInput.UNWPXAlZDFTHmNTPXTEOxtNFPpqL == Platform.GameCoreXboxOne) ? "Xbox One" : "Xbox Series X";
						Logger.LogError(text + " platform could not be initialized! Is the Rewired " + text + " library installed? See the documentation for more information.");
						Logger.LogError(msg3);
						ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA = null;
						goto IL_3E7;
					}
				}
				if (ReInput.UNWPXAlZDFTHmNTPXTEOxtNFPpqL == Platform.Ouya && !ReInput.isEditor)
				{
					Logger.LogError("Ouya is no longer supported.");
					ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA = null;
				}
				else
				{
					if (UnityTools.isAndroidPlatform && !ReInput.isEditor)
					{
						try
						{
							UnityTools.lRGJvbHYYtwJWseuIXpNcoFOvLDL = (A_0(ReInput.SoNJmklvaubvNUQEVJTopavpXlMC) as IAndroidFallbackPlatformHelper);
							goto IL_3E7;
						}
						catch (Exception msg4)
						{
							Logger.LogError(msg4);
							goto IL_3E7;
						}
					}
					if (ReInput.UNWPXAlZDFTHmNTPXTEOxtNFPpqL == Platform.Custom)
					{
						try
						{
							ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA = new CustomInputManager(xApfUAgfQcPgXcXdmaKvwTZGIoxYA.GUFXNCLOdUWYIEOzaHcfTTHLdKNp(), ReInput.SoNJmklvaubvNUQEVJTopavpXlMC.updateLoop, new Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager>(ReInput.GetHardwareJoystickMap_InputManager), new Func<int>(ReInput.GetNewJoystickId));
							if (ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA == null)
							{
								throw new Exception();
							}
						}
						catch
						{
							Logger.LogError("Custom platform could not be initialized due to an exception!");
							ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA = null;
							throw;
						}
					}
				}
			}
			IL_3E7:
			if (ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA == null)
			{
				ReInput.QlUQYHZcxMVTJoGKPDmhRoCscfSt = true;
				ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA = new fFtwXUyOtDAzCuDcEEFLaeTsVAeqA(ReInput.SoNJmklvaubvNUQEVJTopavpXlMC.updateLoop);
			}
		}

		// Token: 0x060014E5 RID: 5349 RVA: 0x00012022 File Offset: 0x00010222
		private static void YCvyjwejYTlAsPEXmePIadOckRiYA()
		{
			if (ReInput.qzoQxOyjNhaIlzSeGpSCcXJTguDr != ReInput.SoNJmklvaubvNUQEVJTopavpXlMC.GetPlatformVar_ignoreInputWhenAppNotInFocus())
			{
				ReInput.qzoQxOyjNhaIlzSeGpSCcXJTguDr = !ReInput.qzoQxOyjNhaIlzSeGpSCcXJTguDr;
			}
		}

		// Token: 0x060014E6 RID: 5350 RVA: 0x00068790 File Offset: 0x00066990
		private static void EhVfDxJwvyQRqbuMLfnpjafVsmKIA()
		{
			if (UnityTools.unityVersionObj == null)
			{
				return;
			}
			Logger.LogWarning(string.Concat(new string[]
			{
				"The version of Rewired installed (",
				ReInput.programVersion,
				") was not designed for Unity ",
				UnityTools.unityVersionObj.major.ToString(),
				". Please install Rewired for Unity ",
				UnityTools.unityVersionObj.major.ToString(),
				".\n\nThis warning does not mean that Rewired will not function, but it may not function optimally.\n\nSome different major versions of Unity download Asset Store assets to the same folder location on disk, so if you download an asset in one version of the Unity editor, then open another version of the Unity editor and install the asset without re-downloading it, the wrong asset version will be installed. To fix this, manually re-download Rewired in the Unity Asset Store panel in this version of the Unity Editor, then install it.\n\nIf you are using a beta version of a new major version of Unity, you will have to wait until the release of the final version before a compatible version of Rewired can be uploaded to the Asset Store. When the new version is ready, it will be available through the Unity Asset Store for download as usual."
			}));
		}

		// Token: 0x04000BBE RID: 3006
		[CustomObfuscation(rename = false)]
		internal const int programVersion1 = 1;

		// Token: 0x04000BBF RID: 3007
		[CustomObfuscation(rename = false)]
		internal const int programVersion2 = 1;

		// Token: 0x04000BC0 RID: 3008
		[CustomObfuscation(rename = false)]
		internal const int programVersion3 = 58;

		// Token: 0x04000BC1 RID: 3009
		[CustomObfuscation(rename = false)]
		internal const int programVersion4 = 4;

		// Token: 0x04000BC2 RID: 3010
		[CustomObfuscation(rename = false)]
		internal const int dataVersion = 1;

		// Token: 0x04000BC3 RID: 3011
		[CustomObfuscation(rename = false)]
		internal const bool isTrial = false;

		// Token: 0x04000BC4 RID: 3012
		[CustomObfuscation(rename = false)]
		internal const string majorBranch = "U2022";

		// Token: 0x04000BC5 RID: 3013
		private static InputManager_Base ernshACoCJlADnBWudDRchCdqgHc;

		// Token: 0x04000BC6 RID: 3014
		private static PlatformInputManager nuiZFKxPKWFhKhmsnHjOwuBdhlfvA;

		// Token: 0x04000BC7 RID: 3015
		internal static FzUsTilBKKFkYXzvzcXjfuLKjXcd qvonQHVNxGPvrzuISSMkVECyMEGc;

		// Token: 0x04000BC8 RID: 3016
		internal static HEnwyLWfnrHknWieEccXGXTAawGsA JVYgltGRcvVxyHxDFcTYdYskrSmBb;

		// Token: 0x04000BC9 RID: 3017
		internal static lNiLuHSggoLjokYLQforkkbXwySd UPtFMqdgwQOSKZUNRJVvcmXsLnZIA;

		// Token: 0x04000BCA RID: 3018
		private static ControllerDataFiles LtnwAoZuGNHrlfpnRahHEdzSRZguA;

		// Token: 0x04000BCB RID: 3019
		private static UserData ybQGfQSHOeALSXVGSAhZJuxEoBieb;

		// Token: 0x04000BCC RID: 3020
		private static bool weOLiakCdgKMUfGsyDRVZjQkBTxr;

		// Token: 0x04000BCD RID: 3021
		private static ConfigVars SoNJmklvaubvNUQEVJTopavpXlMC;

		// Token: 0x04000BCE RID: 3022
		private static UpdateLoopType rZZOHmulAahBDJfKujGQayvPctcs;

		// Token: 0x04000BCF RID: 3023
		private static bool QlUQYHZcxMVTJoGKPDmhRoCscfSt;

		// Token: 0x04000BD0 RID: 3024
		private static Platform UNWPXAlZDFTHmNTPXTEOxtNFPpqL;

		// Token: 0x04000BD1 RID: 3025
		private static WebplayerPlatform fywzAMAeyvDqLeoMZlDlgEEMMZJT;

		// Token: 0x04000BD2 RID: 3026
		private static EditorPlatform XgVQfWiQHYFdfDmAnXoxHosiAHtP;

		// Token: 0x04000BD3 RID: 3027
		private static bool LqprkmvlpjcpZESNgpndrDLrlbCZA;

		// Token: 0x04000BD4 RID: 3028
		private static TimerAbs maeusbshBQoGgXOttwkfOgRNUSUF;

		// Token: 0x04000BD5 RID: 3029
		private static ReInput.HfBpVCHKLggxhOZyzpKLDTEIVkEv vJBNxHpsKaeldWfiVmEFIJhTbUdaA;

		// Token: 0x04000BD6 RID: 3030
		private static string GdOWJqaIGqcwfSTEsiWfbyMecUsH;

		// Token: 0x04000BD7 RID: 3031
		private static bool OBjFQCtfJihsHFePjAFGUBuBotYvA;

		// Token: 0x04000BD8 RID: 3032
		private static bool tabJZNZrPYWCGUvcwsLRnXNVDEnE;

		// Token: 0x04000BD9 RID: 3033
		private static bool nDMYShWfGPGIuiUMgblXmqJTZwNQ = true;

		// Token: 0x04000BDA RID: 3034
		private static int mksqcRcNTwfZmJzotjelkJlXxOpS = -1;

		// Token: 0x04000BDB RID: 3035
		[CustomObfuscation(rename = false)]
		internal static int _id = -1;

		// Token: 0x04000BDC RID: 3036
		private static int MkigKUaelgsfJlPyhktacZZkdtgy = 0;

		// Token: 0x04000BDD RID: 3037
		private static int hZvBixzwwUKJqOFHipjtxwrHZjuG;

		// Token: 0x04000BDE RID: 3038
		private static bool qzoQxOyjNhaIlzSeGpSCcXJTguDr;

		// Token: 0x04000BDF RID: 3039
		private static readonly ReInput.UnityTouch OXcoNegktpaFFxFFyaUZHqHVNcXGA = ReInput.UnityTouch.NNleDJGyuMaXIAwKhzRwvsipSKWjb;

		// Token: 0x04000BE0 RID: 3040
		private static readonly ReInput.PlayerHelper DyZlywrxvCftxCnMubZKePdxYCZw = ReInput.PlayerHelper.jXLSWTzGLhuXyrdrWcCAkXagQezDA;

		// Token: 0x04000BE1 RID: 3041
		private static readonly ReInput.ControllerHelper iliqmShLhblOLYhCIGhxClgafyrPA = ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL;

		// Token: 0x04000BE2 RID: 3042
		private static readonly ReInput.MappingHelper JiKRQVFHGBzBTmqWMvyTKSqlQdGS = ReInput.MappingHelper.OPFbinUedlVplwFfYOgOwPPXWQpg;

		// Token: 0x04000BE3 RID: 3043
		private static readonly ReInput.TimeHelper VbrjeHoRYeDhCvqJTVrngNWnpXab = ReInput.TimeHelper.iWVfgACIvTBUdUThmFyVCAaKfeqUb;

		// Token: 0x04000BE4 RID: 3044
		private static readonly ReInput.ConfigHelper HUtHeWufhdeaXbdzWwoBbcALbloG = ReInput.ConfigHelper.zmiXWbqbdogmqyBfoMyOPVGLTgBG;

		// Token: 0x04000BE5 RID: 3045
		private static readonly ReInput.LocalizationHelper vLgMoSdsOEragzlVFcTXghEYbkzB = ReInput.LocalizationHelper.nqfPHgRAZHanvRvZGfYJaEaAStyTA;

		// Token: 0x04000BE6 RID: 3046
		private static readonly ReInput.GlyphHelper uMqGrfIEEonQheSIdedIvQcwpner = ReInput.GlyphHelper.xZlzkhOXBWtOubvFzRecJjlSHFxG;

		// Token: 0x04000BE7 RID: 3047
		private static ykQBbCYXhmFNZdFinwXsPZYFmYFE wIVMmklqRlJFLVoFwVUpyBHUGnFf;

		// Token: 0x04000BE8 RID: 3048
		private static UserDataStore WdvksUXhQSpBQcjqotpyebeIkYYo;

		// Token: 0x04000BE9 RID: 3049
		private static IControllerAssigner LARxGpRiFQszeNcnBADOlhVZSQhQ;

		// Token: 0x04000BEA RID: 3050
		private static ReInput.sgWGAtCXhoXotFcNElUxqsMZoVwI YSnkwlMizJgJyPRFvRWlfEFzEzFE;

		// Token: 0x04000BEB RID: 3051
		private static SafeAction<ControllerStatusChangedEventArgs> UEFYKTaOUSSTqBbviFjsxmENJYBc = new SafeAction<ControllerStatusChangedEventArgs>(new Action<Exception>(ReInput.UiIeThpXEYmSxJzvHrkDCWwYfiuq.<>9.csniZEXEDVbRIbMUbWGLfajajmrP));

		// Token: 0x04000BEC RID: 3052
		private static SafeAction<ControllerStatusChangedEventArgs> zfIKshnBBvAXDAiCCLdHCtlvsQjB = new SafeAction<ControllerStatusChangedEventArgs>(new Action<Exception>(ReInput.UiIeThpXEYmSxJzvHrkDCWwYfiuq.<>9.FqHDGPjkRZeWFPKTDHFMXvUvjbUb));

		// Token: 0x04000BED RID: 3053
		private static SafeAction<ControllerStatusChangedEventArgs> UUfjdHbAElCbsJpQiClpEvhUJbfbA = new SafeAction<ControllerStatusChangedEventArgs>(new Action<Exception>(ReInput.UiIeThpXEYmSxJzvHrkDCWwYfiuq.<>9.zWtcbPlrXTBZQCTMMvPOCcnATZks));

		// Token: 0x04000BEE RID: 3054
		private static SafeAction LVjqYCpNsZAXwAnqIcFhOFCwcUlW = new SafeAction(new Action<Exception>(ReInput.UiIeThpXEYmSxJzvHrkDCWwYfiuq.<>9.EyFSxPjqpbabUxCecbiwEJysWtTx));

		// Token: 0x04000BEF RID: 3055
		private static SafeAction fZajzRVhDEGhvytHDdFhqmbPWsDb = new SafeAction(new Action<Exception>(ReInput.UiIeThpXEYmSxJzvHrkDCWwYfiuq.<>9.yOpvGEvBnwOKiFlhPGYtBEPkrGvZ));

		// Token: 0x04000BF0 RID: 3056
		private static SafeAction pMhcTAFlcJqmTpaHlLZPdxDHRDDNA = new SafeAction(new Action<Exception>(ReInput.UiIeThpXEYmSxJzvHrkDCWwYfiuq.<>9.PrIJKEGLsqREWqYdtEagxbIiNKVy));

		// Token: 0x04000BF1 RID: 3057
		private static SafeAction pjpHdphDZijFqFNmXwtKlGxDrtvr = new SafeAction(new Action<Exception>(ReInput.UiIeThpXEYmSxJzvHrkDCWwYfiuq.<>9.HORgxMuqPZvjcpJtkvHfABjCZEkf));

		// Token: 0x04000BF2 RID: 3058
		private static SafeAction jKDzEiwUQFWZuVavFxOqwDVYJDlH = new SafeAction(new Action<Exception>(ReInput.UiIeThpXEYmSxJzvHrkDCWwYfiuq.<>9.fjbsYiCBVvOSFXgjetMDcewcSkxp));

		// Token: 0x04000BF3 RID: 3059
		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationFocusChangedEvent;

		// Token: 0x04000BF4 RID: 3060
		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationPauseChangedEvent;

		// Token: 0x04000BF5 RID: 3061
		private static Action xLWAJzJccOGCvFYeBwmUXBWvHVXd;

		// Token: 0x04000BF6 RID: 3062
		private static Action<UpdateLoopType> nrVnSODkTzGKxbQKscgdIPWdTPCj;

		// Token: 0x04000BF7 RID: 3063
		private static Action<UpdateLoopType> PuQGzkZlCPpQpEoVZkrvOjMiMuny;

		// Token: 0x04000BF8 RID: 3064
		private static Action<UpdateLoopType> gELAMhcZqpKghQLfsIpYglpczIKGb;

		// Token: 0x04000BF9 RID: 3065
		private static Action LOrHsxecguMdqinqBqxuHnfUvZbC;

		// Token: 0x04000BFA RID: 3066
		private static Action<bool> LLFgTpfdbygzgBYpKYAixPcVfGWPA;

		// Token: 0x04000BFB RID: 3067
		private static Action<bool> wqsGNskAhqmEMBbFOxiqPMJrycHB;

		// Token: 0x04000BFC RID: 3068
		private static Action<bool> QQWawwrzcmBejonOKMpssNUXrEOd;

		// Token: 0x04000BFD RID: 3069
		private static Action<FullScreenMode> KBoRXrwTuYDuZHopkwTDxKJLGiGkA;

		// Token: 0x04000BFE RID: 3070
		private static Action ZWoXUiShIAZgqiIefJqzsBpgslLE;

		// Token: 0x04000BFF RID: 3071
		private static Action<bool> hlKLGuFZViiMwhOZYgOQilkPoQYkA;

		// Token: 0x04000C00 RID: 3072
		[CustomObfuscation(rename = false)]
		internal static double unscaledDeltaTime;

		// Token: 0x04000C01 RID: 3073
		[CustomObfuscation(rename = false)]
		internal static double unscaledTime;

		// Token: 0x04000C02 RID: 3074
		[CustomObfuscation(rename = false)]
		internal static double unscaledTimePrev;

		// Token: 0x04000C03 RID: 3075
		[CustomObfuscation(rename = false)]
		internal static uint currentFrame;

		// Token: 0x04000C04 RID: 3076
		[CustomObfuscation(rename = false)]
		internal static uint previousFrame;

		// Token: 0x04000C05 RID: 3077
		[CustomObfuscation(rename = false)]
		internal static uint absFrame;

		// Token: 0x020001A8 RID: 424
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class LocalizationHelper : CodeHelper
		{
			// Token: 0x17000513 RID: 1299
			// (get) Token: 0x060014E7 RID: 5351 RVA: 0x00012042 File Offset: 0x00010242
			internal static ReInput.LocalizationHelper nqfPHgRAZHanvRvZGfYJaEaAStyTA
			{
				get
				{
					ReInput.LocalizationHelper result;
					if ((result = ReInput.LocalizationHelper.YLEPfasvgNtuoExVtHNfeboAqjAI) == null)
					{
						result = (ReInput.LocalizationHelper.YLEPfasvgNtuoExVtHNfeboAqjAI = new ReInput.LocalizationHelper());
					}
					return result;
				}
			}

			// Token: 0x060014E8 RID: 5352 RVA: 0x00012058 File Offset: 0x00010258
			private LocalizationHelper()
			{
			}

			// Token: 0x060014E9 RID: 5353 RVA: 0x00012060 File Offset: 0x00010260
			internal static void FRukKCSZUtuLNnxZfsjhGGCSzVtb()
			{
				ReInput.LocalizationHelper.YLEPfasvgNtuoExVtHNfeboAqjAI = null;
			}

			// Token: 0x17000514 RID: 1300
			// (get) Token: 0x060014EA RID: 5354 RVA: 0x00012068 File Offset: 0x00010268
			// (set) Token: 0x060014EB RID: 5355 RVA: 0x00012078 File Offset: 0x00010278
			public ILocalizedStringProvider localizedStringProvider
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return null;
					}
					return LocalizationManager.localizedStringProvider;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					LocalizationManager.localizedStringProvider = value;
				}
			}

			// Token: 0x17000515 RID: 1301
			// (get) Token: 0x060014EC RID: 5356 RVA: 0x00012088 File Offset: 0x00010288
			// (set) Token: 0x060014ED RID: 5357 RVA: 0x00012098 File Offset: 0x00010298
			public bool prefetch
			{
				get
				{
					return ReInput.CheckInitialized() && LocalizationManager.autoPrefetch;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					LocalizationManager.autoPrefetch = value;
				}
			}

			// Token: 0x060014EE RID: 5358 RVA: 0x000120A8 File Offset: 0x000102A8
			public void Reload()
			{
				if (!ReInput.CheckInitialized())
				{
					return;
				}
				LocalizationManager.Reload();
			}

			// Token: 0x04000C06 RID: 3078
			private static ReInput.LocalizationHelper YLEPfasvgNtuoExVtHNfeboAqjAI;
		}

		// Token: 0x020001A9 RID: 425
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class GlyphHelper : CodeHelper
		{
			// Token: 0x17000516 RID: 1302
			// (get) Token: 0x060014EF RID: 5359 RVA: 0x000120B7 File Offset: 0x000102B7
			internal static ReInput.GlyphHelper xZlzkhOXBWtOubvFzRecJjlSHFxG
			{
				get
				{
					ReInput.GlyphHelper result;
					if ((result = ReInput.GlyphHelper.AMCtprrnuDDiEifHUADAmeEenffMA) == null)
					{
						result = (ReInput.GlyphHelper.AMCtprrnuDDiEifHUADAmeEenffMA = new ReInput.GlyphHelper());
					}
					return result;
				}
			}

			// Token: 0x060014F0 RID: 5360 RVA: 0x00012058 File Offset: 0x00010258
			private GlyphHelper()
			{
			}

			// Token: 0x060014F1 RID: 5361 RVA: 0x000120CD File Offset: 0x000102CD
			internal static void pOFFfICGmFdfDdqKaTQlmkRKtSzjb()
			{
				ReInput.GlyphHelper.AMCtprrnuDDiEifHUADAmeEenffMA = null;
			}

			// Token: 0x17000517 RID: 1303
			// (get) Token: 0x060014F2 RID: 5362 RVA: 0x000120D5 File Offset: 0x000102D5
			// (set) Token: 0x060014F3 RID: 5363 RVA: 0x000120E5 File Offset: 0x000102E5
			public IGlyphProvider glyphProvider
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return null;
					}
					return GlyphManager.glyphProvider;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					GlyphManager.glyphProvider = value;
				}
			}

			// Token: 0x17000518 RID: 1304
			// (get) Token: 0x060014F4 RID: 5364 RVA: 0x000120F5 File Offset: 0x000102F5
			// (set) Token: 0x060014F5 RID: 5365 RVA: 0x00012105 File Offset: 0x00010305
			public bool prefetch
			{
				get
				{
					return ReInput.CheckInitialized() && GlyphManager.autoPrefetch;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					GlyphManager.autoPrefetch = value;
				}
			}

			// Token: 0x060014F6 RID: 5366 RVA: 0x00012115 File Offset: 0x00010315
			public void Reload()
			{
				if (!ReInput.CheckInitialized())
				{
					return;
				}
				GlyphManager.Reload();
			}

			// Token: 0x04000C07 RID: 3079
			private static ReInput.GlyphHelper AMCtprrnuDDiEifHUADAmeEenffMA;
		}

		// Token: 0x020001AA RID: 426
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class ConfigHelper : CodeHelper
		{
			// Token: 0x17000519 RID: 1305
			// (get) Token: 0x060014F7 RID: 5367 RVA: 0x00012124 File Offset: 0x00010324
			internal static ReInput.ConfigHelper zmiXWbqbdogmqyBfoMyOPVGLTgBG
			{
				get
				{
					ReInput.ConfigHelper result;
					if ((result = ReInput.ConfigHelper.OliGIOjgVFROHOKPqTvIgYWesFcjA) == null)
					{
						result = (ReInput.ConfigHelper.OliGIOjgVFROHOKPqTvIgYWesFcjA = new ReInput.ConfigHelper());
					}
					return result;
				}
			}

			// Token: 0x060014F8 RID: 5368 RVA: 0x0001213A File Offset: 0x0001033A
			private ConfigHelper()
			{
			}

			// Token: 0x1700051A RID: 1306
			// (get) Token: 0x060014F9 RID: 5369 RVA: 0x00068810 File Offset: 0x00066A10
			// (set) Token: 0x060014FA RID: 5370 RVA: 0x00068864 File Offset: 0x00066A64
			public bool useXInput
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return false;
					}
					if (UnityTools.effectivePlatform == Platform.Windows && ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
					{
						return true;
					}
					if (UnityTools.effectivePlatform == Platform.WindowsUWP)
					{
						return this.windowsUWPSupportGamepads;
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.useXInput;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (UnityTools.effectivePlatform == Platform.WindowsUWP)
					{
						this.windowsUWPSupportGamepads = value;
						return;
					}
					if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.useXInput == value)
					{
						return;
					}
					if (value)
					{
						if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
						{
							return;
						}
						if (UnityTools.effectivePlatform == Platform.Windows && ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.RawInput && ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.DirectInput && ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.WindowsGamingInput)
						{
							Logger.LogWarning("XInput cannot be enabled with the current primary input source: " + ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.windowsStandalonePrimaryInputSource.ToString());
							return;
						}
					}
					else if (UnityTools.effectivePlatform == Platform.Windows && ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
					{
						ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
						Logger.LogWarning("XInput cannot be used with the current primary input source. The primary input source has been changed to Raw Input.");
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.useXInput = value;
					if (ReInput.ernshACoCJlADnBWudDRchCdqgHc != null)
					{
						ReInput.ernshACoCJlADnBWudDRchCdqgHc.ResetAll();
					}
				}
			}

			// Token: 0x1700051B RID: 1307
			// (get) Token: 0x060014FB RID: 5371 RVA: 0x00068980 File Offset: 0x00066B80
			// (set) Token: 0x060014FC RID: 5372 RVA: 0x000689D4 File Offset: 0x00066BD4
			public bool useWindowsGamingInput
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return false;
					}
					if (UnityTools.effectivePlatform == Platform.Windows && ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
					{
						return true;
					}
					if (UnityTools.effectivePlatform == Platform.WindowsUWP)
					{
						return this.windowsUWPSupportGamepads;
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.GetPlatformVar_useWindowsGamingInput();
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (UnityTools.effectivePlatform == Platform.WindowsUWP)
					{
						this.windowsUWPSupportGamepads = value;
						return;
					}
					if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.GetPlatformVar_useWindowsGamingInput() == value)
					{
						return;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.SetPlatformVar_useWindowsGamingInput(value);
					if (value)
					{
						if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
						{
							return;
						}
						if (UnityTools.effectivePlatform == Platform.Windows && ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.RawInput && ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.DirectInput)
						{
							Logger.LogWarning("Windows Gaming Input cannot be enabled with the current primary input source: " + ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.windowsStandalonePrimaryInputSource.ToString());
							return;
						}
					}
					else if (UnityTools.effectivePlatform == Platform.Windows && ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
					{
						ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
						Logger.LogWarning("Windows Gaming Input cannot be used with the current primary input source. The primary input source has been changed to Raw Input.");
					}
					if (ReInput.ernshACoCJlADnBWudDRchCdqgHc != null)
					{
						ReInput.ernshACoCJlADnBWudDRchCdqgHc.ResetAll();
					}
				}
			}

			// Token: 0x1700051C RID: 1308
			// (get) Token: 0x060014FD RID: 5373 RVA: 0x00012158 File Offset: 0x00010358
			// (set) Token: 0x060014FE RID: 5374 RVA: 0x00068AD8 File Offset: 0x00066CD8
			public UpdateMode updateMode
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return UpdateMode.Automatic;
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.updateMode;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (value == ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.updateMode)
					{
						return;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.updateMode = value;
					if (ReInput.ernshACoCJlADnBWudDRchCdqgHc != null)
					{
						ReInput.ernshACoCJlADnBWudDRchCdqgHc.ResetAll();
					}
				}
			}

			// Token: 0x1700051D RID: 1309
			// (get) Token: 0x060014FF RID: 5375 RVA: 0x00012172 File Offset: 0x00010372
			// (set) Token: 0x06001500 RID: 5376 RVA: 0x00068B28 File Offset: 0x00066D28
			public UpdateLoopSetting updateLoop
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return UpdateLoopSetting.Update;
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.updateLoop;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (value == ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.updateLoop)
					{
						return;
					}
					if ((value & UpdateLoopSetting.Update) == UpdateLoopSetting.None)
					{
						value |= UpdateLoopSetting.Update;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.updateLoop = value;
					if (ReInput.ernshACoCJlADnBWudDRchCdqgHc != null)
					{
						ReInput.ernshACoCJlADnBWudDRchCdqgHc.ResetAll();
					}
				}
			}

			// Token: 0x1700051E RID: 1310
			// (get) Token: 0x06001501 RID: 5377 RVA: 0x0001218C File Offset: 0x0001038C
			// (set) Token: 0x06001502 RID: 5378 RVA: 0x00068B84 File Offset: 0x00066D84
			public WindowsStandalonePrimaryInputSource windowsStandalonePrimaryInputSource
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return WindowsStandalonePrimaryInputSource.RawInput;
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.windowsStandalonePrimaryInputSource;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.windowsStandalonePrimaryInputSource == value)
					{
						return;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.windowsStandalonePrimaryInputSource = value;
					if (UnityTools.effectivePlatform == Platform.Windows && value == WindowsStandalonePrimaryInputSource.XInput)
					{
						ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.useXInput = true;
					}
					if (ReInput.ernshACoCJlADnBWudDRchCdqgHc != null)
					{
						ReInput.ernshACoCJlADnBWudDRchCdqgHc.ResetAll();
					}
				}
			}

			// Token: 0x1700051F RID: 1311
			// (get) Token: 0x06001503 RID: 5379 RVA: 0x000121A6 File Offset: 0x000103A6
			// (set) Token: 0x06001504 RID: 5380 RVA: 0x00068BF0 File Offset: 0x00066DF0
			public OSXStandalonePrimaryInputSource osxStandalonePrimaryInputSource
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return OSXStandalonePrimaryInputSource.Native;
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.osx_primaryInputSource;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.osx_primaryInputSource == value)
					{
						return;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.osx_primaryInputSource = value;
					if (ReInput.ernshACoCJlADnBWudDRchCdqgHc != null)
					{
						ReInput.ernshACoCJlADnBWudDRchCdqgHc.ResetAll();
					}
				}
			}

			// Token: 0x17000520 RID: 1312
			// (get) Token: 0x06001505 RID: 5381 RVA: 0x000121C0 File Offset: 0x000103C0
			// (set) Token: 0x06001506 RID: 5382 RVA: 0x00068C40 File Offset: 0x00066E40
			public LinuxStandalonePrimaryInputSource linuxStandalonePrimaryInputSource
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return LinuxStandalonePrimaryInputSource.Native;
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.linux_primaryInputSource;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.linux_primaryInputSource == value)
					{
						return;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.linux_primaryInputSource = value;
					if (ReInput.ernshACoCJlADnBWudDRchCdqgHc != null)
					{
						ReInput.ernshACoCJlADnBWudDRchCdqgHc.ResetAll();
					}
				}
			}

			// Token: 0x17000521 RID: 1313
			// (get) Token: 0x06001507 RID: 5383 RVA: 0x000121DA File Offset: 0x000103DA
			// (set) Token: 0x06001508 RID: 5384 RVA: 0x00068C90 File Offset: 0x00066E90
			public WindowsUWPPrimaryInputSource windowsUWPPrimaryInputSource
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return WindowsUWPPrimaryInputSource.Native;
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.windowsUWP_primaryInputSource;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.windowsUWP_primaryInputSource == value)
					{
						return;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.windowsUWP_primaryInputSource = value;
					if (ReInput.ernshACoCJlADnBWudDRchCdqgHc != null)
					{
						ReInput.ernshACoCJlADnBWudDRchCdqgHc.ResetAll();
					}
				}
			}

			// Token: 0x17000522 RID: 1314
			// (get) Token: 0x06001509 RID: 5385 RVA: 0x000121F4 File Offset: 0x000103F4
			// (set) Token: 0x0600150A RID: 5386 RVA: 0x00068CE0 File Offset: 0x00066EE0
			public bool windowsUWPSupportHIDDevices
			{
				get
				{
					return ReInput.CheckInitialized() && (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP).useHIDAPI;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
					if (platformVars_WindowsUWP.useHIDAPI == value)
					{
						return;
					}
					platformVars_WindowsUWP.useHIDAPI = value;
					if (ReInput.ernshACoCJlADnBWudDRchCdqgHc != null)
					{
						ReInput.ernshACoCJlADnBWudDRchCdqgHc.ResetAll();
					}
				}
			}

			// Token: 0x17000523 RID: 1315
			// (get) Token: 0x0600150B RID: 5387 RVA: 0x0001221A File Offset: 0x0001041A
			// (set) Token: 0x0600150C RID: 5388 RVA: 0x00068D34 File Offset: 0x00066F34
			public bool windowsUWPSupportGamepads
			{
				get
				{
					return ReInput.CheckInitialized() && (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP).useGamepadAPI;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
					if (platformVars_WindowsUWP.useGamepadAPI == value)
					{
						return;
					}
					platformVars_WindowsUWP.useGamepadAPI = value;
					if (ReInput.ernshACoCJlADnBWudDRchCdqgHc != null)
					{
						ReInput.ernshACoCJlADnBWudDRchCdqgHc.ResetAll();
					}
				}
			}

			// Token: 0x17000524 RID: 1316
			// (get) Token: 0x0600150D RID: 5389 RVA: 0x00012240 File Offset: 0x00010440
			// (set) Token: 0x0600150E RID: 5390 RVA: 0x00068D88 File Offset: 0x00066F88
			public bool useAppleGameControllerFramework
			{
				get
				{
					return ReInput.CheckInitialized() && ((UnityTools.effectivePlatform == Platform.OSX && ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.osx_primaryInputSource == OSXStandalonePrimaryInputSource.GameController) || ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.GetPlatformVar_useAppleGameController());
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.GetPlatformVar_useAppleGameController() == value)
					{
						return;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.SetPlatformVar_useAppleGameController(value);
					if (ReInput.ernshACoCJlADnBWudDRchCdqgHc != null)
					{
						ReInput.ernshACoCJlADnBWudDRchCdqgHc.ResetAll();
					}
				}
			}

			// Token: 0x17000525 RID: 1317
			// (get) Token: 0x0600150F RID: 5391 RVA: 0x00012276 File Offset: 0x00010476
			// (set) Token: 0x06001510 RID: 5392 RVA: 0x00068DD8 File Offset: 0x00066FD8
			public XboxOnePrimaryInputSource xboxOnePrimaryInputSource
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return XboxOnePrimaryInputSource.Native;
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.xboxOne_primaryInputSource;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.xboxOne_primaryInputSource == value)
					{
						return;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.xboxOne_primaryInputSource = value;
					if (ReInput.ernshACoCJlADnBWudDRchCdqgHc != null)
					{
						ReInput.ernshACoCJlADnBWudDRchCdqgHc.ResetAll();
					}
				}
			}

			// Token: 0x17000526 RID: 1318
			// (get) Token: 0x06001511 RID: 5393 RVA: 0x00012290 File Offset: 0x00010490
			// (set) Token: 0x06001512 RID: 5394 RVA: 0x00068E28 File Offset: 0x00067028
			public PS4PrimaryInputSource ps4PrimaryInputSource
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return PS4PrimaryInputSource.PS4Input;
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.ps4_primaryInputSource;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.ps4_primaryInputSource == value)
					{
						return;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.ps4_primaryInputSource = value;
					if (ReInput.ernshACoCJlADnBWudDRchCdqgHc != null)
					{
						ReInput.ernshACoCJlADnBWudDRchCdqgHc.ResetAll();
					}
				}
			}

			// Token: 0x17000527 RID: 1319
			// (get) Token: 0x06001513 RID: 5395 RVA: 0x000122AA File Offset: 0x000104AA
			// (set) Token: 0x06001514 RID: 5396 RVA: 0x00068E78 File Offset: 0x00067078
			public WebGLPrimaryInputSource webGLPrimaryInputSource
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return WebGLPrimaryInputSource.Native;
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.webGL_primaryInputSource;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.webGL_primaryInputSource == value)
					{
						return;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.webGL_primaryInputSource = value;
					if (ReInput.ernshACoCJlADnBWudDRchCdqgHc != null)
					{
						ReInput.ernshACoCJlADnBWudDRchCdqgHc.ResetAll();
					}
				}
			}

			// Token: 0x17000528 RID: 1320
			// (get) Token: 0x06001515 RID: 5397 RVA: 0x000122C4 File Offset: 0x000104C4
			// (set) Token: 0x06001516 RID: 5398 RVA: 0x00068EC8 File Offset: 0x000670C8
			public bool alwaysUseUnityInput
			{
				get
				{
					return ReInput.CheckInitialized() && ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.alwaysUseUnityInput;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.alwaysUseUnityInput == value)
					{
						return;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.alwaysUseUnityInput = value;
					if (ReInput.ernshACoCJlADnBWudDRchCdqgHc != null)
					{
						ReInput.ernshACoCJlADnBWudDRchCdqgHc.ResetAll();
					}
				}
			}

			// Token: 0x17000529 RID: 1321
			// (get) Token: 0x06001517 RID: 5399 RVA: 0x000122DE File Offset: 0x000104DE
			// (set) Token: 0x06001518 RID: 5400 RVA: 0x000122E6 File Offset: 0x000104E6
			public bool disableNativeInput
			{
				get
				{
					return this.alwaysUseUnityInput;
				}
				set
				{
					this.alwaysUseUnityInput = value;
				}
			}

			// Token: 0x1700052A RID: 1322
			// (get) Token: 0x06001519 RID: 5401 RVA: 0x000122EF File Offset: 0x000104EF
			// (set) Token: 0x0600151A RID: 5402 RVA: 0x00012309 File Offset: 0x00010509
			public bool nativeMouseSupport
			{
				get
				{
					return ReInput.CheckInitialized() && ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.GetPlatformVar_useNativeMouse();
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (!ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.SetPlatformVar_useNativeMouse(value))
					{
						return;
					}
					if (ReInput.ernshACoCJlADnBWudDRchCdqgHc != null)
					{
						ReInput.ernshACoCJlADnBWudDRchCdqgHc.ResetAll();
					}
				}
			}

			// Token: 0x1700052B RID: 1323
			// (get) Token: 0x0600151B RID: 5403 RVA: 0x0001233D File Offset: 0x0001053D
			// (set) Token: 0x0600151C RID: 5404 RVA: 0x00012357 File Offset: 0x00010557
			public bool nativeKeyboardSupport
			{
				get
				{
					return ReInput.CheckInitialized() && ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.GetPlatformVar_useNativeKeyboard();
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (!ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.SetPlatformVar_useNativeKeyboard(value))
					{
						return;
					}
					if (ReInput.ernshACoCJlADnBWudDRchCdqgHc != null)
					{
						ReInput.ernshACoCJlADnBWudDRchCdqgHc.ResetAll();
					}
				}
			}

			// Token: 0x1700052C RID: 1324
			// (get) Token: 0x0600151D RID: 5405 RVA: 0x0001238B File Offset: 0x0001058B
			// (set) Token: 0x0600151E RID: 5406 RVA: 0x000123A5 File Offset: 0x000105A5
			public bool enhancedDeviceSupport
			{
				get
				{
					return ReInput.CheckInitialized() && ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.GetPlatformVar_useEnhancedDeviceSupport();
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (!ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.SetPlatformVar_useEnhancedDeviceSupport(value))
					{
						return;
					}
					if (ReInput.ernshACoCJlADnBWudDRchCdqgHc != null)
					{
						ReInput.ernshACoCJlADnBWudDRchCdqgHc.ResetAll();
					}
				}
			}

			// Token: 0x1700052D RID: 1325
			// (get) Token: 0x0600151F RID: 5407 RVA: 0x000123D9 File Offset: 0x000105D9
			// (set) Token: 0x06001520 RID: 5408 RVA: 0x000123F3 File Offset: 0x000105F3
			public int joystickRefreshRate
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return 0;
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.GetPlatformVar_joystickRefreshRate();
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					value = MathTools.Clamp(value, 0, 2000);
					if (value == 0)
					{
						value = 240;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.SetPlatformVar_joystickRefreshRate(value);
				}
			}

			// Token: 0x1700052E RID: 1326
			// (get) Token: 0x06001521 RID: 5409 RVA: 0x00012426 File Offset: 0x00010626
			// (set) Token: 0x06001522 RID: 5410 RVA: 0x00012440 File Offset: 0x00010640
			public bool ignoreInputWhenAppNotInFocus
			{
				get
				{
					return ReInput.CheckInitialized() && ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.GetPlatformVar_ignoreInputWhenAppNotInFocus();
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (!ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.SetPlatformVar_ignoreInputWhenAppNotInFocus(value))
					{
						return;
					}
					ReInput.iWZHUFNAlqcgLBBzMMpzDdzHFrCic();
				}
			}

			// Token: 0x1700052F RID: 1327
			// (get) Token: 0x06001523 RID: 5411 RVA: 0x00012462 File Offset: 0x00010662
			// (set) Token: 0x06001524 RID: 5412 RVA: 0x00068F18 File Offset: 0x00067118
			public bool android_supportUnknownGamepads
			{
				get
				{
					return ReInput.CheckInitialized() && ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.android_supportUnknownGamepads;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.android_supportUnknownGamepads == value)
					{
						return;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.android_supportUnknownGamepads = value;
					if (ReInput.ernshACoCJlADnBWudDRchCdqgHc != null)
					{
						ReInput.ernshACoCJlADnBWudDRchCdqgHc.ResetAll();
					}
				}
			}

			// Token: 0x17000530 RID: 1328
			// (get) Token: 0x06001525 RID: 5413 RVA: 0x0001247C File Offset: 0x0001067C
			// (set) Token: 0x06001526 RID: 5414 RVA: 0x00012496 File Offset: 0x00010696
			public DeadZone2DType defaultJoystickAxis2DDeadZoneType
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return DeadZone2DType.Radial;
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.defaultJoystickAxis2DDeadZoneType;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.defaultJoystickAxis2DDeadZoneType == value)
					{
						return;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.defaultJoystickAxis2DDeadZoneType = value;
				}
			}

			// Token: 0x17000531 RID: 1329
			// (get) Token: 0x06001527 RID: 5415 RVA: 0x000124C3 File Offset: 0x000106C3
			// (set) Token: 0x06001528 RID: 5416 RVA: 0x000124DD File Offset: 0x000106DD
			public AxisSensitivity2DType defaultJoystickAxis2DSensitivityType
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return AxisSensitivity2DType.Radial;
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.defaultJoystickAxis2DSensitivityType;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.defaultJoystickAxis2DSensitivityType == value)
					{
						return;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.defaultJoystickAxis2DSensitivityType = value;
				}
			}

			// Token: 0x17000532 RID: 1330
			// (get) Token: 0x06001529 RID: 5417 RVA: 0x0001250A File Offset: 0x0001070A
			// (set) Token: 0x0600152A RID: 5418 RVA: 0x00012524 File Offset: 0x00010724
			public AxisSensitivityType defaultAxisSensitivityType
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return AxisSensitivityType.Multiplier;
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.defaultAxisSensitivityType;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.defaultAxisSensitivityType == value)
					{
						return;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.defaultAxisSensitivityType = value;
				}
			}

			// Token: 0x17000533 RID: 1331
			// (get) Token: 0x0600152B RID: 5419 RVA: 0x00012551 File Offset: 0x00010751
			// (set) Token: 0x0600152C RID: 5420 RVA: 0x0001256B File Offset: 0x0001076B
			public bool force4WayHats
			{
				get
				{
					return ReInput.CheckInitialized() && ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.force4WayHats;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.force4WayHats == value)
					{
						return;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.force4WayHats = value;
				}
			}

			// Token: 0x17000534 RID: 1332
			// (get) Token: 0x0600152D RID: 5421 RVA: 0x00012598 File Offset: 0x00010798
			// (set) Token: 0x0600152E RID: 5422 RVA: 0x000125AD File Offset: 0x000107AD
			public float defaultAbsoluteAxisPollingDeadZone
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return 0.7f;
					}
					return this.nMdAOcHeeRgohAQzsmlieHTHMkAMB;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (value < 0f)
					{
						value = 0f;
					}
					if (this.nMdAOcHeeRgohAQzsmlieHTHMkAMB == value)
					{
						return;
					}
					this.nMdAOcHeeRgohAQzsmlieHTHMkAMB = value;
				}
			}

			// Token: 0x17000535 RID: 1333
			// (get) Token: 0x0600152F RID: 5423 RVA: 0x000125D7 File Offset: 0x000107D7
			// (set) Token: 0x06001530 RID: 5424 RVA: 0x000125EC File Offset: 0x000107EC
			public float defaultRelativeAxisPollingDeadZone
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return 100f;
					}
					return this.fORxBFjJufindgaePnCXavuZBxLL;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (value < 0f)
					{
						value = 0f;
					}
					if (this.fORxBFjJufindgaePnCXavuZBxLL == value)
					{
						return;
					}
					this.fORxBFjJufindgaePnCXavuZBxLL = value;
				}
			}

			// Token: 0x17000536 RID: 1334
			// (get) Token: 0x06001531 RID: 5425 RVA: 0x00012616 File Offset: 0x00010816
			// (set) Token: 0x06001532 RID: 5426 RVA: 0x00012630 File Offset: 0x00010830
			public bool activateActionButtonsOnNegativeValue
			{
				get
				{
					return ReInput.CheckInitialized() && ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.activateActionButtonsOnNegativeValue;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.activateActionButtonsOnNegativeValue == value)
					{
						return;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.activateActionButtonsOnNegativeValue = value;
				}
			}

			// Token: 0x17000537 RID: 1335
			// (get) Token: 0x06001533 RID: 5427 RVA: 0x0001265D File Offset: 0x0001085D
			// (set) Token: 0x06001534 RID: 5428 RVA: 0x00012677 File Offset: 0x00010877
			public ThrottleCalibrationMode throttleCalibrationMode
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return ThrottleCalibrationMode.ZeroToOne;
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.throttleCalibrationMode;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.throttleCalibrationMode == value)
					{
						return;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.throttleCalibrationMode = value;
					ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.rqoljScvYHDAsqjHNKsoyVkIaMop(value);
				}
			}

			// Token: 0x17000538 RID: 1336
			// (get) Token: 0x06001535 RID: 5429 RVA: 0x000126AF File Offset: 0x000108AF
			// (set) Token: 0x06001536 RID: 5430 RVA: 0x000126C9 File Offset: 0x000108C9
			public bool deferControllerConnectedEventsOnStart
			{
				get
				{
					return ReInput.CheckInitialized() && ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.deferControllerConnectedEventsOnStart;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.deferControllerConnectedEventsOnStart == value)
					{
						return;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.deferControllerConnectedEventsOnStart = value;
				}
			}

			// Token: 0x17000539 RID: 1337
			// (get) Token: 0x06001537 RID: 5431 RVA: 0x000126F6 File Offset: 0x000108F6
			// (set) Token: 0x06001538 RID: 5432 RVA: 0x00012710 File Offset: 0x00010910
			public KeyCombinationOverrideMode keyCombinationOverrideMode
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return KeyCombinationOverrideMode.Cancel;
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.keyCombinationOverrideMode;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.keyCombinationOverrideMode == value)
					{
						return;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.keyCombinationOverrideMode = value;
				}
			}

			// Token: 0x1700053A RID: 1338
			// (get) Token: 0x06001539 RID: 5433 RVA: 0x0001273D File Offset: 0x0001093D
			// (set) Token: 0x0600153A RID: 5434 RVA: 0x00012757 File Offset: 0x00010957
			public bool generateKeyEventsOnKeyCombinationOverride
			{
				get
				{
					return !ReInput.CheckInitialized() || ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.generateKeyEventsOnKeyCombinationOverride;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.generateKeyEventsOnKeyCombinationOverride == value)
					{
						return;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.generateKeyEventsOnKeyCombinationOverride = value;
				}
			}

			// Token: 0x1700053B RID: 1339
			// (get) Token: 0x0600153B RID: 5435 RVA: 0x00012784 File Offset: 0x00010984
			// (set) Token: 0x0600153C RID: 5436 RVA: 0x0001279E File Offset: 0x0001099E
			public bool autoAssignJoysticks
			{
				get
				{
					return ReInput.CheckInitialized() && ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.autoAssignJoysticks;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.autoAssignJoysticks == value)
					{
						return;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.autoAssignJoysticks = value;
				}
			}

			// Token: 0x1700053C RID: 1340
			// (get) Token: 0x0600153D RID: 5437 RVA: 0x000127CB File Offset: 0x000109CB
			// (set) Token: 0x0600153E RID: 5438 RVA: 0x000127E5 File Offset: 0x000109E5
			public int maxJoysticksPerPlayer
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return 0;
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.maxJoysticksPerPlayer;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (value < 1)
					{
						value = 1;
					}
					if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.maxJoysticksPerPlayer == value)
					{
						return;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.maxJoysticksPerPlayer = value;
				}
			}

			// Token: 0x1700053D RID: 1341
			// (get) Token: 0x0600153F RID: 5439 RVA: 0x00012819 File Offset: 0x00010A19
			// (set) Token: 0x06001540 RID: 5440 RVA: 0x00012833 File Offset: 0x00010A33
			public bool distributeJoysticksEvenly
			{
				get
				{
					return ReInput.CheckInitialized() && ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.distributeJoysticksEvenly;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.distributeJoysticksEvenly == value)
					{
						return;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.distributeJoysticksEvenly = value;
				}
			}

			// Token: 0x1700053E RID: 1342
			// (get) Token: 0x06001541 RID: 5441 RVA: 0x00012860 File Offset: 0x00010A60
			// (set) Token: 0x06001542 RID: 5442 RVA: 0x0001287A File Offset: 0x00010A7A
			public bool assignJoysticksToPlayingPlayersOnly
			{
				get
				{
					return ReInput.CheckInitialized() && ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.assignJoysticksToPlayingPlayersOnly;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.assignJoysticksToPlayingPlayersOnly == value)
					{
						return;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.assignJoysticksToPlayingPlayersOnly = value;
				}
			}

			// Token: 0x1700053F RID: 1343
			// (get) Token: 0x06001543 RID: 5443 RVA: 0x000128A7 File Offset: 0x00010AA7
			// (set) Token: 0x06001544 RID: 5444 RVA: 0x000128C1 File Offset: 0x00010AC1
			public bool reassignJoystickToPreviousOwnerOnReconnect
			{
				get
				{
					return ReInput.CheckInitialized() && ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect == value)
					{
						return;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect = value;
				}
			}

			// Token: 0x17000540 RID: 1344
			// (get) Token: 0x06001545 RID: 5445 RVA: 0x000128EE File Offset: 0x00010AEE
			// (set) Token: 0x06001546 RID: 5446 RVA: 0x00012908 File Offset: 0x00010B08
			public LogLevelFlags logLevel
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return LogLevelFlags.Off;
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.logLevel;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					if (ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.logLevel == value)
					{
						return;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.logLevel = value;
				}
			}

			// Token: 0x17000541 RID: 1345
			// (get) Token: 0x06001547 RID: 5447 RVA: 0x00012935 File Offset: 0x00010B35
			// (set) Token: 0x06001548 RID: 5448 RVA: 0x00012958 File Offset: 0x00010B58
			public List<EnhancedDeviceSupportDeviceType> enhancedDeviceSupportExcludedDeviceTypes
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return new List<EnhancedDeviceSupportDeviceType>();
					}
					return new List<EnhancedDeviceSupportDeviceType>(ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.GetPlatformVar_enhancedDeviceSupportExcludedDeviceTypes());
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.ConfigVars.SetPlatformVar_enhancedDeviceSupportExcludedDeviceTypes(value);
					if (ReInput.ernshACoCJlADnBWudDRchCdqgHc != null)
					{
						ReInput.ernshACoCJlADnBWudDRchCdqgHc.ResetAll();
					}
				}
			}

			// Token: 0x04000C08 RID: 3080
			private static ReInput.ConfigHelper OliGIOjgVFROHOKPqTvIgYWesFcjA;

			// Token: 0x04000C09 RID: 3081
			private float nMdAOcHeeRgohAQzsmlieHTHMkAMB = 0.7f;

			// Token: 0x04000C0A RID: 3082
			private float fORxBFjJufindgaePnCXavuZBxLL = 100f;
		}

		// Token: 0x020001AB RID: 427
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class ControllerHelper : CodeHelper
		{
			// Token: 0x17000542 RID: 1346
			// (get) Token: 0x06001549 RID: 5449 RVA: 0x0001298A File Offset: 0x00010B8A
			internal static ReInput.ControllerHelper DUvmiJbQfpwlOqAmhAelyneQZaNL
			{
				get
				{
					ReInput.ControllerHelper result;
					if ((result = ReInput.ControllerHelper.zgqblqCHHlgzLGstHGqbaefHlIFEC) == null)
					{
						result = (ReInput.ControllerHelper.zgqblqCHHlgzLGstHGqbaefHlIFEC = new ReInput.ControllerHelper());
					}
					return result;
				}
			}

			// Token: 0x0600154A RID: 5450 RVA: 0x000129A0 File Offset: 0x00010BA0
			private ControllerHelper()
			{
			}

			// Token: 0x0600154B RID: 5451 RVA: 0x00068F68 File Offset: 0x00067168
			public T GetController<T>(int controllerId) where T : Controller
			{
				if (!ReInput.CheckInitialized())
				{
					return default(T);
				}
				if (controllerId < 0)
				{
					return default(T);
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					return this.GetJoystick(controllerId) as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.TaTrTHwUgSOiWrsYvUpTqAIgrPne as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					return this.GetCustomController(controllerId) as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.XNgqEHDojgJjHnQkfggodEGufgWj as T;
				}
				throw new NotImplementedException();
			}

			// Token: 0x0600154C RID: 5452 RVA: 0x000129BE File Offset: 0x00010BBE
			public int GetControllerCount(ControllerType controllerType)
			{
				if (!ReInput.CheckInitialized())
				{
					return 0;
				}
				switch (controllerType)
				{
				case ControllerType.Keyboard:
					return 1;
				case ControllerType.Mouse:
					return 1;
				case ControllerType.Joystick:
					return this.joystickCount;
				default:
					if (controllerType != ControllerType.Custom)
					{
						throw new NotImplementedException();
					}
					return this.customControllerCount;
				}
			}

			// Token: 0x17000543 RID: 1347
			// (get) Token: 0x0600154D RID: 5453 RVA: 0x000129F9 File Offset: 0x00010BF9
			public int controllerCount
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return 0;
					}
					return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.idDeJRYPRYBhwNhBGaLmQNoVmrev;
				}
			}

			// Token: 0x17000544 RID: 1348
			// (get) Token: 0x0600154E RID: 5454 RVA: 0x00012A0E File Offset: 0x00010C0E
			public IList<Controller> Controllers
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return EmptyObjects<Controller>.EmptyReadOnlyIListT;
					}
					return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.wqkFZhZtKTLgLqQSMELHGRiyilJQ;
				}
			}

			// Token: 0x0600154F RID: 5455 RVA: 0x00012A27 File Offset: 0x00010C27
			public Controller GetController(ControllerType controllerType, int controllerId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.YCdAacShUnGEqBEtkCPIWZicyHmg(controllerType, controllerId, false);
			}

			// Token: 0x06001550 RID: 5456 RVA: 0x00012A3F File Offset: 0x00010C3F
			public Controller GetController(ControllerIdentifier controllerIdentifier)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.GjbnKwfEMhCIAztPvPYKgnLKAipL(controllerIdentifier, false);
			}

			// Token: 0x06001551 RID: 5457 RVA: 0x00012A56 File Offset: 0x00010C56
			public Controller[] GetControllers(ControllerType controllerType)
			{
				if (!ReInput.CheckInitialized())
				{
					return EmptyObjects<Controller>.array;
				}
				return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.bYOYutLrOOZASZuCWCqcJTuqJnoh(controllerType);
			}

			// Token: 0x06001552 RID: 5458 RVA: 0x00012A70 File Offset: 0x00010C70
			public string[] GetControllerNames(ControllerType controllerType)
			{
				if (!ReInput.CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.lGzUuGUXGNMDDbWKiZEwjLHOjzt(controllerType);
			}

			// Token: 0x06001553 RID: 5459 RVA: 0x00012A8A File Offset: 0x00010C8A
			public bool IsControllerAssigned(ControllerType controllerType, Controller controller)
			{
				return ReInput.CheckInitialized() && ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.aYJyshoOZFtbwWFeZFUfIDZULnHs(controller);
			}

			// Token: 0x06001554 RID: 5460 RVA: 0x00012AA0 File Offset: 0x00010CA0
			public bool IsControllerAssigned(ControllerType controllerType, int controllerId)
			{
				return ReInput.CheckInitialized() && ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.DpFQGzmABmUazBuBIipaVjNmMoth(controllerType, controllerId);
			}

			// Token: 0x06001555 RID: 5461 RVA: 0x00012AB7 File Offset: 0x00010CB7
			public bool IsControllerAssignedToPlayer(ControllerType controllerType, int controllerId, int playerId)
			{
				return ReInput.CheckInitialized() && ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.IfifcUKcfcMLWhZCYyHubkLJSindA(controllerType, controllerId, playerId);
			}

			// Token: 0x06001556 RID: 5462 RVA: 0x00012ACF File Offset: 0x00010CCF
			public void RemoveControllerFromAllPlayers(Controller controller, bool includeSystemPlayer = true)
			{
				if (!ReInput.CheckInitialized())
				{
					return;
				}
				ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.RsHCABcOGkNIxblqccIENfEGykei(controller, includeSystemPlayer);
			}

			// Token: 0x06001557 RID: 5463 RVA: 0x00012AE5 File Offset: 0x00010CE5
			public void RemoveControllerFromAllPlayers(ControllerType controllerType, int controllerId, bool includeSystemPlayer = true)
			{
				if (!ReInput.CheckInitialized())
				{
					return;
				}
				ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.LeVLiaSHvzNHfQZcaIDuTAZmmAHn(controllerType, controllerId, includeSystemPlayer);
			}

			// Token: 0x17000545 RID: 1349
			// (get) Token: 0x06001558 RID: 5464 RVA: 0x00012AFC File Offset: 0x00010CFC
			public Mouse Mouse
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return null;
					}
					return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.XNgqEHDojgJjHnQkfggodEGufgWj;
				}
			}

			// Token: 0x17000546 RID: 1350
			// (get) Token: 0x06001559 RID: 5465 RVA: 0x00012B11 File Offset: 0x00010D11
			public Keyboard Keyboard
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return null;
					}
					return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.TaTrTHwUgSOiWrsYvUpTqAIgrPne;
				}
			}

			// Token: 0x17000547 RID: 1351
			// (get) Token: 0x0600155A RID: 5466 RVA: 0x00012B26 File Offset: 0x00010D26
			// (set) Token: 0x0600155B RID: 5467 RVA: 0x00012B3C File Offset: 0x00010D3C
			[Obsolete("Deprecated: Use Controller.enabled instead. For example, to disable keyboard input: ReInput.controllers.Keyboard.enabled = false.")]
			public bool keyboardEnabled
			{
				get
				{
					return ReInput.CheckInitialized() && this.Keyboard.enabled;
				}
				set
				{
					if (!ReInput.CheckInitialized())
					{
						return;
					}
					this.Keyboard.enabled = value;
				}
			}

			// Token: 0x17000548 RID: 1352
			// (get) Token: 0x0600155C RID: 5468 RVA: 0x00012B52 File Offset: 0x00010D52
			public int joystickCount
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return 0;
					}
					return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.pkIsaLuBqwgPYsBLElovjkUtIZeo;
				}
			}

			// Token: 0x17000549 RID: 1353
			// (get) Token: 0x0600155D RID: 5469 RVA: 0x00012B67 File Offset: 0x00010D67
			public IList<Joystick> Joysticks
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return EmptyObjects<Joystick>.EmptyReadOnlyIListT;
					}
					return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.pVKHDMxRDSNXQLeLUHNMTPLdCAPB;
				}
			}

			// Token: 0x0600155E RID: 5470 RVA: 0x00012B80 File Offset: 0x00010D80
			public Joystick GetJoystick(int joystickId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.oyUTQmcDwKIecWNjUFSrDrvyaWIt(joystickId, false);
			}

			// Token: 0x0600155F RID: 5471 RVA: 0x00012B97 File Offset: 0x00010D97
			public Joystick[] GetJoysticks()
			{
				return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.yLbSGGoPvwCuldbCkgQpouEcpNpAb();
			}

			// Token: 0x06001560 RID: 5472 RVA: 0x00012BA3 File Offset: 0x00010DA3
			public string[] GetJoystickNames()
			{
				if (!ReInput.CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.lWPGwIAhPvlPfCpbNiDcjgnnmDUi();
			}

			// Token: 0x06001561 RID: 5473 RVA: 0x00012BBC File Offset: 0x00010DBC
			public bool IsJoystickAssigned(Joystick joystick)
			{
				return ReInput.CheckInitialized() && ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.yzLgeXRxlRJhmFZBssllRFLyTOVk(joystick);
			}

			// Token: 0x06001562 RID: 5474 RVA: 0x00012BD2 File Offset: 0x00010DD2
			public bool IsJoystickAssigned(int joystickId)
			{
				return ReInput.CheckInitialized() && ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.ISPgKPbyYPzszapriHefSnimqxWB(joystickId);
			}

			// Token: 0x06001563 RID: 5475 RVA: 0x00012BE8 File Offset: 0x00010DE8
			public bool IsJoystickAssignedToPlayer(int joystickId, int playerId)
			{
				return ReInput.CheckInitialized() && ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.XcfhDOlkHOoqAxJGQxQwkfCaghRD(joystickId, playerId);
			}

			// Token: 0x06001564 RID: 5476 RVA: 0x00012BFF File Offset: 0x00010DFF
			public void RemoveJoystickFromAllPlayers(Joystick joystick, bool includeSystemPlayer = true)
			{
				if (!ReInput.CheckInitialized())
				{
					return;
				}
				ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.QjgbpCWadEQsCfQbSSyOniOuodpO(joystick, includeSystemPlayer);
			}

			// Token: 0x06001565 RID: 5477 RVA: 0x00012C15 File Offset: 0x00010E15
			public void RemoveJoystickFromAllPlayers(int joystickId, bool includeSystemPlayer = true)
			{
				if (!ReInput.CheckInitialized())
				{
					return;
				}
				ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.IlzvgtmlLiIVKgCNyYHeocyqmZFdA(joystickId, includeSystemPlayer);
			}

			// Token: 0x06001566 RID: 5478 RVA: 0x0006903C File Offset: 0x0006723C
			public int GetUnityJoystickIdFromAnyButtonPress()
			{
				if (!ReInput.CheckInitialized())
				{
					return -1;
				}
				if (!ReInput.QlUQYHZcxMVTJoGKPDmhRoCscfSt)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return -1;
				}
				ReInput.qjcZxkIfQReRjTLdZnHhzPbPWJYv();
				for (int i = 0; i < 16; i++)
				{
					for (int j = 0; j < 20; j++)
					{
						if (ReInput.BlhzLLIoHKNAbUKGAUpQxQgixmXk.ucOCSFGVELRdIplAMsPcelpIcQGDB(i, j))
						{
							return i + 1;
						}
					}
				}
				return -1;
			}

			// Token: 0x06001567 RID: 5479 RVA: 0x00069098 File Offset: 0x00067298
			public int GetUnityJoystickIdFromAnyButtonOrAxisPress(float axisThreshold, bool positiveAxesOnly)
			{
				if (!ReInput.CheckInitialized())
				{
					return -1;
				}
				if (!ReInput.QlUQYHZcxMVTJoGKPDmhRoCscfSt)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return -1;
				}
				ReInput.qjcZxkIfQReRjTLdZnHhzPbPWJYv();
				for (int i = 0; i < 16; i++)
				{
					for (int j = 0; j < 20; j++)
					{
						if (ReInput.BlhzLLIoHKNAbUKGAUpQxQgixmXk.ucOCSFGVELRdIplAMsPcelpIcQGDB(i, j))
						{
							return i + 1;
						}
					}
					for (int k = 0; k < 29; k++)
					{
						if (ReInput.BlhzLLIoHKNAbUKGAUpQxQgixmXk.IcpjEEVpyxGTYRsuoVqBnaVmCgXBA(i, k, positiveAxesOnly))
						{
							return i + 1;
						}
					}
				}
				return -1;
			}

			// Token: 0x06001568 RID: 5480 RVA: 0x00012C2B File Offset: 0x00010E2B
			public void SetUnityJoystickId(int joystickId, int unityJoystickId)
			{
				if (!ReInput.CheckInitialized())
				{
					return;
				}
				if (!ReInput.QlUQYHZcxMVTJoGKPDmhRoCscfSt)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return;
				}
				ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA.SetUnityJoystickId(joystickId, unityJoystickId);
			}

			// Token: 0x06001569 RID: 5481 RVA: 0x00069114 File Offset: 0x00067314
			public bool SetUnityJoystickIdFromAnyButtonPress(int joystickId)
			{
				if (!ReInput.CheckInitialized())
				{
					return false;
				}
				int unityJoystickIdFromAnyButtonPress = this.GetUnityJoystickIdFromAnyButtonPress();
				if (unityJoystickIdFromAnyButtonPress < 1)
				{
					return false;
				}
				this.SetUnityJoystickId(joystickId, unityJoystickIdFromAnyButtonPress);
				return true;
			}

			// Token: 0x0600156A RID: 5482 RVA: 0x00069140 File Offset: 0x00067340
			public bool SetUnityJoystickIdFromAnyButtonOrAxisPress(int joystickId, float axisThreshold, bool positiveAxesOnly)
			{
				if (!ReInput.CheckInitialized())
				{
					return false;
				}
				int unityJoystickIdFromAnyButtonOrAxisPress = this.GetUnityJoystickIdFromAnyButtonOrAxisPress(axisThreshold, positiveAxesOnly);
				if (unityJoystickIdFromAnyButtonOrAxisPress < 1)
				{
					return false;
				}
				this.SetUnityJoystickId(joystickId, unityJoystickIdFromAnyButtonOrAxisPress);
				return true;
			}

			// Token: 0x1700054A RID: 1354
			// (get) Token: 0x0600156B RID: 5483 RVA: 0x00012C53 File Offset: 0x00010E53
			public int customControllerCount
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return 0;
					}
					return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.EwaeQdbfxfQyCoKtMMZzrkzzXzav;
				}
			}

			// Token: 0x1700054B RID: 1355
			// (get) Token: 0x0600156C RID: 5484 RVA: 0x00012C68 File Offset: 0x00010E68
			public IList<CustomController> CustomControllers
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
					}
					return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.ZdOnxkFcYHFlRBGFPcjfEWrunVkab;
				}
			}

			// Token: 0x0600156D RID: 5485 RVA: 0x00012C81 File Offset: 0x00010E81
			public CustomController GetCustomController(int customControllerId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.CGFeZCblefkjIqYPzeUZrCOWCLtIA(customControllerId);
			}

			// Token: 0x0600156E RID: 5486 RVA: 0x00012C97 File Offset: 0x00010E97
			public CustomController[] GetCustomControllers()
			{
				if (!ReInput.CheckInitialized())
				{
					return EmptyObjects<CustomController>.array;
				}
				return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.BYLibMWgPJjjYfhcNFYVLPrpULQe();
			}

			// Token: 0x0600156F RID: 5487 RVA: 0x00012CB0 File Offset: 0x00010EB0
			public string[] GetCustomControllerNames()
			{
				if (!ReInput.CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.oYWYwumVaYkisWvtAOnkYcmcPdyN();
			}

			// Token: 0x06001570 RID: 5488 RVA: 0x00012CC9 File Offset: 0x00010EC9
			public bool IsCustomControllerAssigned(CustomController customController)
			{
				return ReInput.CheckInitialized() && ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.kAvoSCzfCsNLdTqqEnCDNdkRUODo(customController);
			}

			// Token: 0x06001571 RID: 5489 RVA: 0x00012CDF File Offset: 0x00010EDF
			public bool IsCustomControllerAssigned(int customControllerId)
			{
				return ReInput.CheckInitialized() && ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.aKgtusqiGreqehokPmuAaMwfuhwyB(customControllerId);
			}

			// Token: 0x06001572 RID: 5490 RVA: 0x00012CF5 File Offset: 0x00010EF5
			public bool IsCustomControllerAssignedToPlayer(int customControllerId, int playerId)
			{
				return ReInput.CheckInitialized() && ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.qMfksFffzlWSrLZQwqVBOVUVmMIr(customControllerId, playerId);
			}

			// Token: 0x06001573 RID: 5491 RVA: 0x00012D0C File Offset: 0x00010F0C
			public void RemoveCustomControllerFromAllPlayers(CustomController customController, bool includeSystemPlayer = true)
			{
				if (!ReInput.CheckInitialized())
				{
					return;
				}
				ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.bbgcubmRRibMMbayJOioQEvhIKHUA(customController, includeSystemPlayer);
			}

			// Token: 0x06001574 RID: 5492 RVA: 0x00012D22 File Offset: 0x00010F22
			public void RemoveCustomControllerFromAllPlayers(int customControllerId, bool includeSystemPlayer = true)
			{
				if (!ReInput.CheckInitialized())
				{
					return;
				}
				ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.doizVeJvUuDmRiPKpCrPADfyEFaeb(customControllerId, includeSystemPlayer);
			}

			// Token: 0x06001575 RID: 5493 RVA: 0x00012D38 File Offset: 0x00010F38
			public CustomController CreateCustomController(int sourceControllerId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.GtyAkWaziVlXmbaLqdOfAXlIROxMA(sourceControllerId);
			}

			// Token: 0x06001576 RID: 5494 RVA: 0x00069170 File Offset: 0x00067370
			public CustomController CreateCustomController(int sourceControllerId, string tag)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				CustomController customController = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.GtyAkWaziVlXmbaLqdOfAXlIROxMA(sourceControllerId);
				if (customController == null)
				{
					return null;
				}
				customController.tag = tag;
				return customController;
			}

			// Token: 0x06001577 RID: 5495 RVA: 0x00012D4E File Offset: 0x00010F4E
			public bool DestroyCustomController(CustomController customController)
			{
				if (!ReInput.CheckInitialized())
				{
					return false;
				}
				if (customController == null)
				{
					return false;
				}
				this.RemoveCustomControllerFromAllPlayers(customController, true);
				return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.bKGqngQuVXuCHtSngfDCwbrgHwFU(customController);
			}

			// Token: 0x06001578 RID: 5496 RVA: 0x00012D71 File Offset: 0x00010F71
			public CustomController GetFirstCustomControllerWithSourceId(int sourceId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.xbSeuEzjzKWIfvLmTlQMeaaBueGX(sourceId);
			}

			// Token: 0x06001579 RID: 5497 RVA: 0x00012D87 File Offset: 0x00010F87
			public CustomController GetFirstCustomControllerWithTag(string tag)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.YJMzGtLfMvrehGccWRPVUKZwjSFX(tag);
			}

			// Token: 0x0600157A RID: 5498 RVA: 0x00012D9D File Offset: 0x00010F9D
			public IEnumerable<CustomController> CustomControllersWithSourceId(int sourceId)
			{
				if (!ReInput.CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.mpDdGICtDtaisRbOrJVeQjCytZwDA(sourceId);
			}

			// Token: 0x0600157B RID: 5499 RVA: 0x00012DB7 File Offset: 0x00010FB7
			public IEnumerable<CustomController> CustomControllersWithTag(string tag)
			{
				if (!ReInput.CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.tSioixiCRqEaynCegcRpxfHUajOjA(tag);
			}

			// Token: 0x0600157C RID: 5500 RVA: 0x00012DD1 File Offset: 0x00010FD1
			public IList<TInterface> GetControllerTemplates<TInterface>() where TInterface : IControllerTemplate
			{
				if (!ReInput.CheckInitialized())
				{
					return EmptyObjects<TInterface>.EmptyReadOnlyIListT;
				}
				return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.ERmWOdiERTUJxFGZRPEEocZABjPB<TInterface>();
			}

			// Token: 0x0600157D RID: 5501 RVA: 0x00012DEA File Offset: 0x00010FEA
			public Controller GetLastActiveController()
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.AsGNwYheTIbQQBmkStCdrvgLMFkdb();
			}

			// Token: 0x0600157E RID: 5502 RVA: 0x00012DFF File Offset: 0x00010FFF
			public Controller GetLastActiveController(ControllerType controllerType)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.gbaAjLiHNYSJBiYjkmpSqUcXvmjoA(controllerType);
			}

			// Token: 0x0600157F RID: 5503 RVA: 0x000691A0 File Offset: 0x000673A0
			public T GetLastActiveController<T>() where T : Controller
			{
				if (!ReInput.CheckInitialized())
				{
					return default(T);
				}
				return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.AsGNwYheTIbQQBmkStCdrvgLMFkdb<T>();
			}

			// Token: 0x06001580 RID: 5504 RVA: 0x00012E15 File Offset: 0x00011015
			public ControllerType GetLastActiveControllerType()
			{
				if (!ReInput.CheckInitialized())
				{
					return ControllerType.Keyboard;
				}
				return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.svIelaGFeMDuMeedqyuOJLQvGGppA();
			}

			// Token: 0x06001581 RID: 5505 RVA: 0x00012E2A File Offset: 0x0001102A
			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (!ReInput.CheckInitialized())
				{
					return;
				}
				ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.owMHCzymuFPqadYOjuEBSbwfmAYW(callback);
			}

			// Token: 0x06001582 RID: 5506 RVA: 0x00012E3F File Offset: 0x0001103F
			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (!ReInput.CheckInitialized())
				{
					return;
				}
				ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.CVboItgwVLLNnOpxxWpJlXqugVAE(callback, controllerType);
			}

			// Token: 0x06001583 RID: 5507 RVA: 0x00012E55 File Offset: 0x00011055
			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (!ReInput.CheckInitialized())
				{
					return;
				}
				ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.BitpXAiHuRQTUmaHbgbymVGpvvDR(callback);
			}

			// Token: 0x06001584 RID: 5508 RVA: 0x00012E6A File Offset: 0x0001106A
			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (!ReInput.CheckInitialized())
				{
					return;
				}
				ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.QZPAFYyTpwOkRoQLEbHWDuXeEqzw(callback, controllerType);
			}

			// Token: 0x06001585 RID: 5509 RVA: 0x00012E80 File Offset: 0x00011080
			public void ClearLastActiveControllerChangedDelegates()
			{
				if (!ReInput.CheckInitialized())
				{
					return;
				}
				ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.sKQpoaYDpnkkyOHHttqtDHZWIhBp();
			}

			// Token: 0x06001586 RID: 5510 RVA: 0x00012E94 File Offset: 0x00011094
			public bool GetAnyButton()
			{
				return ReInput.CheckInitialized() && ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.FRBdsaSKhNDXuArVlzZPneOlYcZh();
			}

			// Token: 0x06001587 RID: 5511 RVA: 0x00012EA9 File Offset: 0x000110A9
			public bool GetAnyButton(ControllerType controllerType)
			{
				return ReInput.CheckInitialized() && ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.qYwhdRZzdLdSmcczraAAHoRuyactA(controllerType);
			}

			// Token: 0x06001588 RID: 5512 RVA: 0x00012EBF File Offset: 0x000110BF
			public bool GetAnyButtonDown()
			{
				return ReInput.CheckInitialized() && ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.czGjZJoPxfbWBlRobbsAcfNJiScgA();
			}

			// Token: 0x06001589 RID: 5513 RVA: 0x00012ED4 File Offset: 0x000110D4
			public bool GetAnyButtonDown(ControllerType controllerType)
			{
				return ReInput.CheckInitialized() && ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.xshsiejjTvwsxBGfhwNdPLmvquoe(controllerType);
			}

			// Token: 0x0600158A RID: 5514 RVA: 0x00012EEA File Offset: 0x000110EA
			public bool GetAnyButtonUp()
			{
				return ReInput.CheckInitialized() && ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.VpcexcbzIPgusgIEdKgsNgUTiMvz();
			}

			// Token: 0x0600158B RID: 5515 RVA: 0x00012EFF File Offset: 0x000110FF
			public bool GetAnyButtonUp(ControllerType controllerType)
			{
				return ReInput.CheckInitialized() && ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.jZXzpDfTbdEPBrSTLcMkvOMZcsNj(controllerType);
			}

			// Token: 0x0600158C RID: 5516 RVA: 0x00012F15 File Offset: 0x00011115
			public bool GetAnyButtonChanged()
			{
				return ReInput.CheckInitialized() && ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.QhSRvxrkIaSPKbLARYPCczCjWzFV();
			}

			// Token: 0x0600158D RID: 5517 RVA: 0x00012F2A File Offset: 0x0001112A
			public bool GetAnyButtonChanged(ControllerType controllerType)
			{
				return ReInput.CheckInitialized() && ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.RHeuRhgfztjNLOUNZcHLNniDiLHAA(controllerType);
			}

			// Token: 0x0600158E RID: 5518 RVA: 0x00012F40 File Offset: 0x00011140
			public bool GetAnyButtonPrev()
			{
				return ReInput.CheckInitialized() && ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.jEinJXlMkoARTkYzYAmcDRiLtyif();
			}

			// Token: 0x0600158F RID: 5519 RVA: 0x00012F55 File Offset: 0x00011155
			public bool GetAnyButtonPrev(ControllerType controllerType)
			{
				return ReInput.CheckInitialized() && ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.ivSlJMctRyKtWMyKNXtsYqiJMZcd(controllerType);
			}

			// Token: 0x06001590 RID: 5520 RVA: 0x00012F6B File Offset: 0x0001116B
			public bool AutoAssignJoystick(Joystick joystick)
			{
				if (!ReInput.CheckInitialized())
				{
					return false;
				}
				if (joystick == null)
				{
					return false;
				}
				if (this.IsJoystickAssigned(joystick))
				{
					return true;
				}
				ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.qabCvhFfRVAbFBXdoWaKxrEYQhcCb(joystick);
				return this.IsJoystickAssigned(joystick);
			}

			// Token: 0x06001591 RID: 5521 RVA: 0x000691C8 File Offset: 0x000673C8
			public void AutoAssignJoysticks()
			{
				if (!ReInput.CheckInitialized())
				{
					return;
				}
				int joystickCount = this.joystickCount;
				IList<Joystick> joysticks = this.Joysticks;
				for (int i = 0; i < joystickCount; i++)
				{
					this.AutoAssignJoystick(joysticks[i]);
				}
			}

			// Token: 0x04000C0B RID: 3083
			private static ReInput.ControllerHelper zgqblqCHHlgzLGstHGqbaefHlIFEC;

			// Token: 0x04000C0C RID: 3084
			public readonly ReInput.ControllerHelper.PollingHelper polling = ReInput.ControllerHelper.PollingHelper.qoLjbRboohsHFPCovdCnIbaFrECP;

			// Token: 0x04000C0D RID: 3085
			public readonly ReInput.ControllerHelper.ConflictCheckingHelper conflictChecking = ReInput.ControllerHelper.ConflictCheckingHelper.IYCgJEbNDoVEFNSdLdJyHXJZRHyO;

			// Token: 0x020001AC RID: 428
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class PollingHelper : CodeHelper
			{
				// Token: 0x1700054C RID: 1356
				// (get) Token: 0x06001592 RID: 5522 RVA: 0x00012F98 File Offset: 0x00011198
				internal static ReInput.ControllerHelper.PollingHelper qoLjbRboohsHFPCovdCnIbaFrECP
				{
					get
					{
						ReInput.ControllerHelper.PollingHelper result;
						if ((result = ReInput.ControllerHelper.PollingHelper.lWjjiTwbjcMSEzjhvUrbppQIWEYt) == null)
						{
							result = (ReInput.ControllerHelper.PollingHelper.lWjjiTwbjcMSEzjhvUrbppQIWEYt = new ReInput.ControllerHelper.PollingHelper());
						}
						return result;
					}
				}

				// Token: 0x06001593 RID: 5523 RVA: 0x00012058 File Offset: 0x00010258
				private PollingHelper()
				{
				}

				// Token: 0x06001594 RID: 5524 RVA: 0x00069208 File Offset: 0x00067408
				public ControllerPollingInfo PollAllControllersForFirstElement()
				{
					if (!ReInput.CheckInitialized())
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					ControllerPollingInfo result = this.OZbmeUHsMNhdRNSptBDBpJQWirlf();
					if (result.success)
					{
						return result;
					}
					result = this.cBHiYdRJjofJFCTjbTduLdEpguiiA();
					if (result.success)
					{
						return result;
					}
					result = this.eSqdGQrSzLKnYxZIdrcHchNmozWh();
					if (result.success)
					{
						return result;
					}
					result = this.hhGUwXPXFLtVYKKoGclEdTmZTQnK();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
				}

				// Token: 0x06001595 RID: 5525 RVA: 0x00069270 File Offset: 0x00067470
				public ControllerPollingInfo PollAllControllersForFirstElementDown()
				{
					if (!ReInput.CheckInitialized())
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					ControllerPollingInfo result = this.mwcfGFcdEpfWJMeNynJoHCqzpySj();
					if (result.success)
					{
						return result;
					}
					result = this.YJWuFPefJFeYMAkMEXnRfOpzIGZWA();
					if (result.success)
					{
						return result;
					}
					result = this.adoGeAhmTCpkfJHpBmapuETOrSWy();
					if (result.success)
					{
						return result;
					}
					result = this.vKqEGlilTgfgFARFUAvmxhPsmiEN();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
				}

				// Token: 0x06001596 RID: 5526 RVA: 0x000692D8 File Offset: 0x000674D8
				public ControllerPollingInfo PollAllControllersForFirstButton()
				{
					if (!ReInput.CheckInitialized())
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					ControllerPollingInfo result = this.BibHgvRWtPUEmoVYCLOlxByguUpJ();
					if (result.success)
					{
						return result;
					}
					result = this.cBHiYdRJjofJFCTjbTduLdEpguiiA();
					if (result.success)
					{
						return result;
					}
					result = this.PHaTkSFbIPNbYPPHalXUsxKTFeGN();
					if (result.success)
					{
						return result;
					}
					result = this.mVCtlKbnKSyloxZDXOFZFQBMAOZCA();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
				}

				// Token: 0x06001597 RID: 5527 RVA: 0x00069340 File Offset: 0x00067540
				public ControllerPollingInfo PollAllControllersForFirstButtonDown()
				{
					if (!ReInput.CheckInitialized())
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					ControllerPollingInfo result = this.mRoFMslwiDFataRTseQVHoSUdeaoA();
					if (result.success)
					{
						return result;
					}
					result = this.YJWuFPefJFeYMAkMEXnRfOpzIGZWA();
					if (result.success)
					{
						return result;
					}
					result = this.kLnwNqosfEsSNNfVHsSTZEVxJnAG();
					if (result.success)
					{
						return result;
					}
					result = this.KPpgCbYQgnnSgGJpWeJwCQNipmup();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
				}

				// Token: 0x06001598 RID: 5528 RVA: 0x000693A8 File Offset: 0x000675A8
				public ControllerPollingInfo PollAllControllersForFirstAxis()
				{
					if (!ReInput.CheckInitialized())
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					ControllerPollingInfo result = this.pqaHRSHwOVfxivczpegQoZLNiucQ();
					if (result.success)
					{
						return result;
					}
					result = ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					if (result.success)
					{
						return result;
					}
					result = this.QEvPqmYOzFnqdpkPnFUldntaidHhb();
					if (result.success)
					{
						return result;
					}
					result = this.ykCDSmAubSNqNqcVcZSeLgHGhstEb();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
				}

				// Token: 0x06001599 RID: 5529 RVA: 0x00069410 File Offset: 0x00067610
				public ControllerPollingInfo PollAllControllersOfTypeForFirstElement(ControllerType controllerType)
				{
					if (!ReInput.CheckInitialized())
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return this.cBHiYdRJjofJFCTjbTduLdEpguiiA();
					case ControllerType.Mouse:
						return this.eSqdGQrSzLKnYxZIdrcHchNmozWh();
					case ControllerType.Joystick:
						return this.OZbmeUHsMNhdRNSptBDBpJQWirlf();
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.hhGUwXPXFLtVYKKoGclEdTmZTQnK();
					}
				}

				// Token: 0x0600159A RID: 5530 RVA: 0x00069464 File Offset: 0x00067664
				public ControllerPollingInfo PollAllControllersOfTypeForFirstElementDown(ControllerType controllerType)
				{
					if (!ReInput.CheckInitialized())
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return this.YJWuFPefJFeYMAkMEXnRfOpzIGZWA();
					case ControllerType.Mouse:
						return this.adoGeAhmTCpkfJHpBmapuETOrSWy();
					case ControllerType.Joystick:
						return this.mwcfGFcdEpfWJMeNynJoHCqzpySj();
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.vKqEGlilTgfgFARFUAvmxhPsmiEN();
					}
				}

				// Token: 0x0600159B RID: 5531 RVA: 0x000694B8 File Offset: 0x000676B8
				public ControllerPollingInfo PollAllControllersOfTypeForFirstButton(ControllerType controllerType)
				{
					if (!ReInput.CheckInitialized())
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return this.cBHiYdRJjofJFCTjbTduLdEpguiiA();
					case ControllerType.Mouse:
						return this.PHaTkSFbIPNbYPPHalXUsxKTFeGN();
					case ControllerType.Joystick:
						return this.BibHgvRWtPUEmoVYCLOlxByguUpJ();
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.mVCtlKbnKSyloxZDXOFZFQBMAOZCA();
					}
				}

				// Token: 0x0600159C RID: 5532 RVA: 0x0006950C File Offset: 0x0006770C
				public ControllerPollingInfo PollAllControllersOfTypeForFirstButtonDown(ControllerType controllerType)
				{
					if (!ReInput.CheckInitialized())
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return this.YJWuFPefJFeYMAkMEXnRfOpzIGZWA();
					case ControllerType.Mouse:
						return this.kLnwNqosfEsSNNfVHsSTZEVxJnAG();
					case ControllerType.Joystick:
						return this.mRoFMslwiDFataRTseQVHoSUdeaoA();
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.KPpgCbYQgnnSgGJpWeJwCQNipmup();
					}
				}

				// Token: 0x0600159D RID: 5533 RVA: 0x00069560 File Offset: 0x00067760
				public ControllerPollingInfo PollAllControllersOfTypeForFirstAxis(ControllerType controllerType)
				{
					if (!ReInput.CheckInitialized())
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					case ControllerType.Mouse:
						return this.QEvPqmYOzFnqdpkPnFUldntaidHhb();
					case ControllerType.Joystick:
						return this.pqaHRSHwOVfxivczpegQoZLNiucQ();
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.ykCDSmAubSNqNqcVcZSeLgHGhstEb();
					}
				}

				// Token: 0x0600159E RID: 5534 RVA: 0x000695B4 File Offset: 0x000677B4
				public ControllerPollingInfo PollControllerForFirstElement(ControllerType controllerType, int controllerId)
				{
					if (!ReInput.CheckInitialized())
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return this.cBHiYdRJjofJFCTjbTduLdEpguiiA();
					case ControllerType.Mouse:
						return this.eSqdGQrSzLKnYxZIdrcHchNmozWh();
					case ControllerType.Joystick:
						return this.QLEaSWcKDBvzRKTgdcpmssMrLvGcA(controllerId);
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.lAKcDfppOmaJFdjwrDsRiTjJJKqFA(controllerId);
					}
				}

				// Token: 0x0600159F RID: 5535 RVA: 0x0006960C File Offset: 0x0006780C
				public ControllerPollingInfo PollControllerForFirstElementDown(ControllerType controllerType, int controllerId)
				{
					if (!ReInput.CheckInitialized())
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return this.YJWuFPefJFeYMAkMEXnRfOpzIGZWA();
					case ControllerType.Mouse:
						return this.adoGeAhmTCpkfJHpBmapuETOrSWy();
					case ControllerType.Joystick:
						return this.HuTcmUfAGwqSauLOYHlADlAWXmhXA(controllerId);
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.zsmcbPvxlrBtREdzuIONfShAjNGPA(controllerId);
					}
				}

				// Token: 0x060015A0 RID: 5536 RVA: 0x00069664 File Offset: 0x00067864
				public ControllerPollingInfo PollControllerForFirstButton(ControllerType controllerType, int controllerId)
				{
					if (!ReInput.CheckInitialized())
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return this.cBHiYdRJjofJFCTjbTduLdEpguiiA();
					case ControllerType.Mouse:
						return this.PHaTkSFbIPNbYPPHalXUsxKTFeGN();
					case ControllerType.Joystick:
						return this.uNkzTlItfvijfpvEMQnxuUWgGSPu(controllerId);
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.NPsZXHjFLioRcJgbNfIMrRzZAwGh(controllerId);
					}
				}

				// Token: 0x060015A1 RID: 5537 RVA: 0x000696BC File Offset: 0x000678BC
				public ControllerPollingInfo PollControllerForFirstButtonDown(ControllerType controllerType, int controllerId)
				{
					if (!ReInput.CheckInitialized())
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return this.YJWuFPefJFeYMAkMEXnRfOpzIGZWA();
					case ControllerType.Mouse:
						return this.kLnwNqosfEsSNNfVHsSTZEVxJnAG();
					case ControllerType.Joystick:
						return this.ISkjhIgzJlOobwfPGQctnHDRceEhA(controllerId);
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.NOxufYEFwomSCFmbpwoltvePcQcM(controllerId);
					}
				}

				// Token: 0x060015A2 RID: 5538 RVA: 0x00069714 File Offset: 0x00067914
				public ControllerPollingInfo PollControllerForFirstAxis(ControllerType controllerType, int controllerId)
				{
					if (!ReInput.CheckInitialized())
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					case ControllerType.Mouse:
						return this.QEvPqmYOzFnqdpkPnFUldntaidHhb();
					case ControllerType.Joystick:
						return this.UigDpAGJQoVFnwirIxDmqPxjxqUpA(controllerId);
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.WvNKEJjpynbChHDeyBOwZyBBbyxr(controllerId);
					}
				}

				// Token: 0x060015A3 RID: 5539 RVA: 0x00012FAE File Offset: 0x000111AE
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElements()
				{
					if (!ReInput.CheckInitialized())
					{
						yield break;
					}
					foreach (ControllerPollingInfo controllerPollingInfo in this.qSIWXqmkjkGyFINGcFjgrqEaHBMx())
					{
						yield return controllerPollingInfo;
					}
					IEnumerator<ControllerPollingInfo> enumerator = null;
					foreach (ControllerPollingInfo controllerPollingInfo2 in this.OyUbtxfsIZLZqjVEeHWTBJJKfrjWA())
					{
						yield return controllerPollingInfo2;
					}
					enumerator = null;
					foreach (ControllerPollingInfo controllerPollingInfo3 in this.EbMdGOEWsLfvJOmBWoBmdEEtoDFg())
					{
						yield return controllerPollingInfo3;
					}
					enumerator = null;
					foreach (ControllerPollingInfo controllerPollingInfo4 in this.GfijYsiCKTylaZlFNeHXPUmyBTAb())
					{
						yield return controllerPollingInfo4;
					}
					enumerator = null;
					yield break;
					yield break;
				}

				// Token: 0x060015A4 RID: 5540 RVA: 0x00012FBE File Offset: 0x000111BE
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElementsDown()
				{
					if (!ReInput.CheckInitialized())
					{
						yield break;
					}
					foreach (ControllerPollingInfo controllerPollingInfo in this.qEayElVSTGUNUUMdFCMWDMxPkexdA())
					{
						yield return controllerPollingInfo;
					}
					IEnumerator<ControllerPollingInfo> enumerator = null;
					foreach (ControllerPollingInfo controllerPollingInfo2 in this.ztmrhyemHrNypWpcMVzeFNsqSPh())
					{
						yield return controllerPollingInfo2;
					}
					enumerator = null;
					foreach (ControllerPollingInfo controllerPollingInfo3 in this.GROSBPmgeviTWIMWxocJMTHqMYqpA())
					{
						yield return controllerPollingInfo3;
					}
					enumerator = null;
					foreach (ControllerPollingInfo controllerPollingInfo4 in this.SblYzACzHVKkwjANDVRuZcJaDNsfA())
					{
						yield return controllerPollingInfo4;
					}
					enumerator = null;
					yield break;
					yield break;
				}

				// Token: 0x060015A5 RID: 5541 RVA: 0x00012FCE File Offset: 0x000111CE
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtons()
				{
					if (!ReInput.CheckInitialized())
					{
						yield break;
					}
					foreach (ControllerPollingInfo controllerPollingInfo in this.lIvEcEuutkFlrtLCBcEAIvepjkrE())
					{
						yield return controllerPollingInfo;
					}
					IEnumerator<ControllerPollingInfo> enumerator = null;
					foreach (ControllerPollingInfo controllerPollingInfo2 in this.OyUbtxfsIZLZqjVEeHWTBJJKfrjWA())
					{
						yield return controllerPollingInfo2;
					}
					enumerator = null;
					foreach (ControllerPollingInfo controllerPollingInfo3 in this.mMSQjInWcNGtRLzbeFzmirCkHtXK())
					{
						yield return controllerPollingInfo3;
					}
					enumerator = null;
					foreach (ControllerPollingInfo controllerPollingInfo4 in this.tPOSYIuddeAanKoliMUpcUlsaCzwA())
					{
						yield return controllerPollingInfo4;
					}
					enumerator = null;
					yield break;
					yield break;
				}

				// Token: 0x060015A6 RID: 5542 RVA: 0x00012FDE File Offset: 0x000111DE
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtonsDown()
				{
					if (!ReInput.CheckInitialized())
					{
						yield break;
					}
					foreach (ControllerPollingInfo controllerPollingInfo in this.mhFwMCcjubQXVpzKKTpeftjzwuqq())
					{
						yield return controllerPollingInfo;
					}
					IEnumerator<ControllerPollingInfo> enumerator = null;
					foreach (ControllerPollingInfo controllerPollingInfo2 in this.ztmrhyemHrNypWpcMVzeFNsqSPh())
					{
						yield return controllerPollingInfo2;
					}
					enumerator = null;
					foreach (ControllerPollingInfo controllerPollingInfo3 in this.AjTRAjwqHSlnIXAAyvYWxWloZVAh())
					{
						yield return controllerPollingInfo3;
					}
					enumerator = null;
					foreach (ControllerPollingInfo controllerPollingInfo4 in this.lNegjDFryAvFYhQOYJeUmNRTTGcuA())
					{
						yield return controllerPollingInfo4;
					}
					enumerator = null;
					yield break;
					yield break;
				}

				// Token: 0x060015A7 RID: 5543 RVA: 0x00012FEE File Offset: 0x000111EE
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllAxes()
				{
					if (!ReInput.CheckInitialized())
					{
						yield break;
					}
					foreach (ControllerPollingInfo controllerPollingInfo in this.VJqAfwHKHhMQTLhoFjixCmBtVgcHA())
					{
						yield return controllerPollingInfo;
					}
					IEnumerator<ControllerPollingInfo> enumerator = null;
					foreach (ControllerPollingInfo controllerPollingInfo2 in this.DanBBIwFCZkrveZWikGIBJWJJecd())
					{
						yield return controllerPollingInfo2;
					}
					enumerator = null;
					foreach (ControllerPollingInfo controllerPollingInfo3 in this.ZVPWBfskCPlYGgMcRXZEFamSOSbe())
					{
						yield return controllerPollingInfo3;
					}
					enumerator = null;
					yield break;
					yield break;
				}

				// Token: 0x060015A8 RID: 5544 RVA: 0x0006976C File Offset: 0x0006796C
				public IEnumerable<ControllerPollingInfo> PollControllerForAllElements(ControllerType controllerType, int controllerId)
				{
					if (!ReInput.CheckInitialized())
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return this.OyUbtxfsIZLZqjVEeHWTBJJKfrjWA();
					case ControllerType.Mouse:
						return this.EbMdGOEWsLfvJOmBWoBmdEEtoDFg();
					case ControllerType.Joystick:
						return this.MFHnDEeEHobZKMJNQQrYXZXCVEWH(controllerId);
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.aNoksVxAthANgavXxldtiwLDDJbjB(controllerId);
					}
				}

				// Token: 0x060015A9 RID: 5545 RVA: 0x000697C4 File Offset: 0x000679C4
				public IEnumerable<ControllerPollingInfo> PollControllerForAllElementsDown(ControllerType controllerType, int controllerId)
				{
					if (!ReInput.CheckInitialized())
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return this.ztmrhyemHrNypWpcMVzeFNsqSPh();
					case ControllerType.Mouse:
						return this.GROSBPmgeviTWIMWxocJMTHqMYqpA();
					case ControllerType.Joystick:
						return this.urmGzIeCWCWZlfVcQHosdTYGHett(controllerId);
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.FRmTFBXlMqRRhGoryvOHShlNgOzCA(controllerId);
					}
				}

				// Token: 0x060015AA RID: 5546 RVA: 0x0006981C File Offset: 0x00067A1C
				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtons(ControllerType controllerType, int controllerId)
				{
					if (!ReInput.CheckInitialized())
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return this.OyUbtxfsIZLZqjVEeHWTBJJKfrjWA();
					case ControllerType.Mouse:
						return this.mMSQjInWcNGtRLzbeFzmirCkHtXK();
					case ControllerType.Joystick:
						return this.OJXiVdqhQnmMlFAnBfZxdpjRWjkHA(controllerId);
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.UhGVMGHMnVyoNRPboeZcpIhZHxYJ(controllerId);
					}
				}

				// Token: 0x060015AB RID: 5547 RVA: 0x00069874 File Offset: 0x00067A74
				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtonsDown(ControllerType controllerType, int controllerId)
				{
					if (!ReInput.CheckInitialized())
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return this.ztmrhyemHrNypWpcMVzeFNsqSPh();
					case ControllerType.Mouse:
						return this.AjTRAjwqHSlnIXAAyvYWxWloZVAh();
					case ControllerType.Joystick:
						return this.WMGRspDKesBQTktgDclaCeqFtMAX(controllerId);
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.OwXbzoisFsPbLCavksZcToIsDTCWB(controllerId);
					}
				}

				// Token: 0x060015AC RID: 5548 RVA: 0x000698CC File Offset: 0x00067ACC
				public IEnumerable<ControllerPollingInfo> PollControllerForAllAxes(ControllerType controllerType, int controllerId)
				{
					if (!ReInput.CheckInitialized())
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return new List<ControllerPollingInfo>();
					case ControllerType.Mouse:
						return this.DanBBIwFCZkrveZWikGIBJWJJecd();
					case ControllerType.Joystick:
						return this.WBMjmNJyMywrwpnXJdeJmMyUKAjn(controllerId);
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.HWEpeBbuRUWRVtvLMVepZixIBmAg(controllerId);
					}
				}

				// Token: 0x060015AD RID: 5549 RVA: 0x00069924 File Offset: 0x00067B24
				private ControllerPollingInfo OZbmeUHsMNhdRNSptBDBpJQWirlf()
				{
					IList<Joystick> list = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.pVKHDMxRDSNXQLeLUHNMTPLdCAPB;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
				}

				// Token: 0x060015AE RID: 5550 RVA: 0x0006996C File Offset: 0x00067B6C
				private ControllerPollingInfo mwcfGFcdEpfWJMeNynJoHCqzpySj()
				{
					IList<Joystick> list = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.pVKHDMxRDSNXQLeLUHNMTPLdCAPB;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
				}

				// Token: 0x060015AF RID: 5551 RVA: 0x000699B4 File Offset: 0x00067BB4
				private ControllerPollingInfo BibHgvRWtPUEmoVYCLOlxByguUpJ()
				{
					IList<Joystick> list = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.pVKHDMxRDSNXQLeLUHNMTPLdCAPB;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
				}

				// Token: 0x060015B0 RID: 5552 RVA: 0x000699FC File Offset: 0x00067BFC
				private ControllerPollingInfo mRoFMslwiDFataRTseQVHoSUdeaoA()
				{
					IList<Joystick> list = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.pVKHDMxRDSNXQLeLUHNMTPLdCAPB;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
				}

				// Token: 0x060015B1 RID: 5553 RVA: 0x00069A44 File Offset: 0x00067C44
				private ControllerPollingInfo pqaHRSHwOVfxivczpegQoZLNiucQ()
				{
					IList<Joystick> list = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.pVKHDMxRDSNXQLeLUHNMTPLdCAPB;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
				}

				// Token: 0x060015B2 RID: 5554 RVA: 0x00069A8C File Offset: 0x00067C8C
				private ControllerPollingInfo QLEaSWcKDBvzRKTgdcpmssMrLvGcA(int A_1)
				{
					Joystick joystick = ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.GetJoystick(A_1);
					if (joystick == null)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					return joystick.PollForFirstElement();
				}

				// Token: 0x060015B3 RID: 5555 RVA: 0x00069AB4 File Offset: 0x00067CB4
				private ControllerPollingInfo HuTcmUfAGwqSauLOYHlADlAWXmhXA(int A_1)
				{
					Joystick joystick = ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.GetJoystick(A_1);
					if (joystick == null)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					return joystick.PollForFirstElementDown();
				}

				// Token: 0x060015B4 RID: 5556 RVA: 0x00069ADC File Offset: 0x00067CDC
				private ControllerPollingInfo uNkzTlItfvijfpvEMQnxuUWgGSPu(int A_1)
				{
					Joystick joystick = ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.GetJoystick(A_1);
					if (joystick == null)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					return joystick.PollForFirstButton();
				}

				// Token: 0x060015B5 RID: 5557 RVA: 0x00069B04 File Offset: 0x00067D04
				private ControllerPollingInfo ISkjhIgzJlOobwfPGQctnHDRceEhA(int A_1)
				{
					Joystick joystick = ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.GetJoystick(A_1);
					if (joystick == null)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					return joystick.PollForFirstButtonDown();
				}

				// Token: 0x060015B6 RID: 5558 RVA: 0x00069B2C File Offset: 0x00067D2C
				private ControllerPollingInfo UigDpAGJQoVFnwirIxDmqPxjxqUpA(int A_1)
				{
					Joystick joystick = ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.GetJoystick(A_1);
					if (joystick == null)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					return joystick.PollForFirstAxis();
				}

				// Token: 0x060015B7 RID: 5559 RVA: 0x00012FFE File Offset: 0x000111FE
				private ControllerPollingInfo cBHiYdRJjofJFCTjbTduLdEpguiiA()
				{
					return ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.Keyboard.PollForFirstKey();
				}

				// Token: 0x060015B8 RID: 5560 RVA: 0x0001300F File Offset: 0x0001120F
				private ControllerPollingInfo YJWuFPefJFeYMAkMEXnRfOpzIGZWA()
				{
					return ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.Keyboard.PollForFirstKeyDown();
				}

				// Token: 0x060015B9 RID: 5561 RVA: 0x00013020 File Offset: 0x00011220
				private ControllerPollingInfo eSqdGQrSzLKnYxZIdrcHchNmozWh()
				{
					return ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.Mouse.PollForFirstElement();
				}

				// Token: 0x060015BA RID: 5562 RVA: 0x00013031 File Offset: 0x00011231
				private ControllerPollingInfo adoGeAhmTCpkfJHpBmapuETOrSWy()
				{
					return ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.Mouse.PollForFirstElementDown();
				}

				// Token: 0x060015BB RID: 5563 RVA: 0x00013042 File Offset: 0x00011242
				private ControllerPollingInfo PHaTkSFbIPNbYPPHalXUsxKTFeGN()
				{
					return ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.Mouse.PollForFirstButton();
				}

				// Token: 0x060015BC RID: 5564 RVA: 0x00013053 File Offset: 0x00011253
				private ControllerPollingInfo kLnwNqosfEsSNNfVHsSTZEVxJnAG()
				{
					return ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.Mouse.PollForFirstButtonDown();
				}

				// Token: 0x060015BD RID: 5565 RVA: 0x00013064 File Offset: 0x00011264
				private ControllerPollingInfo QEvPqmYOzFnqdpkPnFUldntaidHhb()
				{
					return ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.Mouse.PollForFirstAxis();
				}

				// Token: 0x060015BE RID: 5566 RVA: 0x00069B54 File Offset: 0x00067D54
				private ControllerPollingInfo hhGUwXPXFLtVYKKoGclEdTmZTQnK()
				{
					IList<CustomController> list = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.ZdOnxkFcYHFlRBGFPcjfEWrunVkab;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
				}

				// Token: 0x060015BF RID: 5567 RVA: 0x00069B9C File Offset: 0x00067D9C
				private ControllerPollingInfo vKqEGlilTgfgFARFUAvmxhPsmiEN()
				{
					IList<CustomController> list = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.ZdOnxkFcYHFlRBGFPcjfEWrunVkab;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
				}

				// Token: 0x060015C0 RID: 5568 RVA: 0x00069BE4 File Offset: 0x00067DE4
				private ControllerPollingInfo mVCtlKbnKSyloxZDXOFZFQBMAOZCA()
				{
					IList<CustomController> list = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.ZdOnxkFcYHFlRBGFPcjfEWrunVkab;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
				}

				// Token: 0x060015C1 RID: 5569 RVA: 0x00069C2C File Offset: 0x00067E2C
				private ControllerPollingInfo KPpgCbYQgnnSgGJpWeJwCQNipmup()
				{
					IList<CustomController> list = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.ZdOnxkFcYHFlRBGFPcjfEWrunVkab;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
				}

				// Token: 0x060015C2 RID: 5570 RVA: 0x00069C74 File Offset: 0x00067E74
				private ControllerPollingInfo ykCDSmAubSNqNqcVcZSeLgHGhstEb()
				{
					IList<CustomController> list = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.ZdOnxkFcYHFlRBGFPcjfEWrunVkab;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
				}

				// Token: 0x060015C3 RID: 5571 RVA: 0x00069CBC File Offset: 0x00067EBC
				private ControllerPollingInfo lAKcDfppOmaJFdjwrDsRiTjJJKqFA(int A_1)
				{
					CustomController customController = ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.GetCustomController(A_1);
					if (customController == null)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					return customController.PollForFirstElement();
				}

				// Token: 0x060015C4 RID: 5572 RVA: 0x00069CE4 File Offset: 0x00067EE4
				private ControllerPollingInfo zsmcbPvxlrBtREdzuIONfShAjNGPA(int A_1)
				{
					CustomController customController = ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.GetCustomController(A_1);
					if (customController == null)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					return customController.PollForFirstElementDown();
				}

				// Token: 0x060015C5 RID: 5573 RVA: 0x00069D0C File Offset: 0x00067F0C
				private ControllerPollingInfo NPsZXHjFLioRcJgbNfIMrRzZAwGh(int A_1)
				{
					CustomController customController = ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.GetCustomController(A_1);
					if (customController == null)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					return customController.PollForFirstButton();
				}

				// Token: 0x060015C6 RID: 5574 RVA: 0x00069D34 File Offset: 0x00067F34
				private ControllerPollingInfo NOxufYEFwomSCFmbpwoltvePcQcM(int A_1)
				{
					CustomController customController = ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.GetCustomController(A_1);
					if (customController == null)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					return customController.PollForFirstButtonDown();
				}

				// Token: 0x060015C7 RID: 5575 RVA: 0x00069D5C File Offset: 0x00067F5C
				private ControllerPollingInfo WvNKEJjpynbChHDeyBOwZyBBbyxr(int A_1)
				{
					CustomController customController = ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.GetCustomController(A_1);
					if (customController == null)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					return customController.PollForFirstAxis();
				}

				// Token: 0x060015C8 RID: 5576 RVA: 0x00013075 File Offset: 0x00011275
				private IEnumerable<ControllerPollingInfo> qSIWXqmkjkGyFINGcFjgrqEaHBMx()
				{
					IList<Joystick> list = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.pVKHDMxRDSNXQLeLUHNMTPLdCAPB;
					int num;
					for (int i = 0; i < list.Count; i = num + 1)
					{
						foreach (ControllerPollingInfo controllerPollingInfo in list[i].PollForAllElements())
						{
							yield return controllerPollingInfo;
						}
						IEnumerator<ControllerPollingInfo> enumerator = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x060015C9 RID: 5577 RVA: 0x0001307E File Offset: 0x0001127E
				private IEnumerable<ControllerPollingInfo> qEayElVSTGUNUUMdFCMWDMxPkexdA()
				{
					IList<Joystick> list = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.pVKHDMxRDSNXQLeLUHNMTPLdCAPB;
					int num;
					for (int i = 0; i < list.Count; i = num + 1)
					{
						foreach (ControllerPollingInfo controllerPollingInfo in list[i].PollForAllElementsDown())
						{
							yield return controllerPollingInfo;
						}
						IEnumerator<ControllerPollingInfo> enumerator = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x060015CA RID: 5578 RVA: 0x00013087 File Offset: 0x00011287
				private IEnumerable<ControllerPollingInfo> lIvEcEuutkFlrtLCBcEAIvepjkrE()
				{
					IList<Joystick> list = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.pVKHDMxRDSNXQLeLUHNMTPLdCAPB;
					int num;
					for (int i = 0; i < list.Count; i = num + 1)
					{
						foreach (ControllerPollingInfo controllerPollingInfo in list[i].PollForAllButtons())
						{
							yield return controllerPollingInfo;
						}
						IEnumerator<ControllerPollingInfo> enumerator = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x060015CB RID: 5579 RVA: 0x00013090 File Offset: 0x00011290
				private IEnumerable<ControllerPollingInfo> mhFwMCcjubQXVpzKKTpeftjzwuqq()
				{
					IList<Joystick> list = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.pVKHDMxRDSNXQLeLUHNMTPLdCAPB;
					int num;
					for (int i = 0; i < list.Count; i = num + 1)
					{
						foreach (ControllerPollingInfo controllerPollingInfo in list[i].PollForAllButtonsDown())
						{
							yield return controllerPollingInfo;
						}
						IEnumerator<ControllerPollingInfo> enumerator = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x060015CC RID: 5580 RVA: 0x00013099 File Offset: 0x00011299
				private IEnumerable<ControllerPollingInfo> VJqAfwHKHhMQTLhoFjixCmBtVgcHA()
				{
					IList<Joystick> list = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.pVKHDMxRDSNXQLeLUHNMTPLdCAPB;
					int num;
					for (int i = 0; i < list.Count; i = num + 1)
					{
						foreach (ControllerPollingInfo controllerPollingInfo in list[i].PollForAllAxes())
						{
							yield return controllerPollingInfo;
						}
						IEnumerator<ControllerPollingInfo> enumerator = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x060015CD RID: 5581 RVA: 0x00069D84 File Offset: 0x00067F84
				private IEnumerable<ControllerPollingInfo> MFHnDEeEHobZKMJNQQrYXZXCVEWH(int A_1)
				{
					Joystick joystick = ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.GetJoystick(A_1);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElements();
				}

				// Token: 0x060015CE RID: 5582 RVA: 0x00069DAC File Offset: 0x00067FAC
				private IEnumerable<ControllerPollingInfo> urmGzIeCWCWZlfVcQHosdTYGHett(int A_1)
				{
					Joystick joystick = ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.GetJoystick(A_1);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElementsDown();
				}

				// Token: 0x060015CF RID: 5583 RVA: 0x00069DD4 File Offset: 0x00067FD4
				private IEnumerable<ControllerPollingInfo> OJXiVdqhQnmMlFAnBfZxdpjRWjkHA(int A_1)
				{
					Joystick joystick = ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.GetJoystick(A_1);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllButtons();
				}

				// Token: 0x060015D0 RID: 5584 RVA: 0x00069DFC File Offset: 0x00067FFC
				private IEnumerable<ControllerPollingInfo> WMGRspDKesBQTktgDclaCeqFtMAX(int A_1)
				{
					Joystick joystick = ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.GetJoystick(A_1);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllButtonsDown();
				}

				// Token: 0x060015D1 RID: 5585 RVA: 0x00069E24 File Offset: 0x00068024
				private IEnumerable<ControllerPollingInfo> WBMjmNJyMywrwpnXJdeJmMyUKAjn(int A_1)
				{
					Joystick joystick = ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.GetJoystick(A_1);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllAxes();
				}

				// Token: 0x060015D2 RID: 5586 RVA: 0x000130A2 File Offset: 0x000112A2
				private IEnumerable<ControllerPollingInfo> OyUbtxfsIZLZqjVEeHWTBJJKfrjWA()
				{
					return ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.Keyboard.PollForAllKeys();
				}

				// Token: 0x060015D3 RID: 5587 RVA: 0x000130B3 File Offset: 0x000112B3
				private IEnumerable<ControllerPollingInfo> ztmrhyemHrNypWpcMVzeFNsqSPh()
				{
					return ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.Keyboard.PollForAllKeysDown();
				}

				// Token: 0x060015D4 RID: 5588 RVA: 0x000130C4 File Offset: 0x000112C4
				private IEnumerable<ControllerPollingInfo> EbMdGOEWsLfvJOmBWoBmdEEtoDFg()
				{
					return ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.Mouse.PollForAllElements();
				}

				// Token: 0x060015D5 RID: 5589 RVA: 0x000130D5 File Offset: 0x000112D5
				private IEnumerable<ControllerPollingInfo> GROSBPmgeviTWIMWxocJMTHqMYqpA()
				{
					return ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.Mouse.PollForAllElementsDown();
				}

				// Token: 0x060015D6 RID: 5590 RVA: 0x000130E6 File Offset: 0x000112E6
				private IEnumerable<ControllerPollingInfo> mMSQjInWcNGtRLzbeFzmirCkHtXK()
				{
					return ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.Mouse.PollForAllButtons();
				}

				// Token: 0x060015D7 RID: 5591 RVA: 0x000130F7 File Offset: 0x000112F7
				private IEnumerable<ControllerPollingInfo> AjTRAjwqHSlnIXAAyvYWxWloZVAh()
				{
					return ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.Mouse.PollForAllButtonsDown();
				}

				// Token: 0x060015D8 RID: 5592 RVA: 0x00013108 File Offset: 0x00011308
				private IEnumerable<ControllerPollingInfo> DanBBIwFCZkrveZWikGIBJWJJecd()
				{
					return ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.Mouse.PollForAllAxes();
				}

				// Token: 0x060015D9 RID: 5593 RVA: 0x00013119 File Offset: 0x00011319
				private IEnumerable<ControllerPollingInfo> GfijYsiCKTylaZlFNeHXPUmyBTAb()
				{
					IList<CustomController> list = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.ZdOnxkFcYHFlRBGFPcjfEWrunVkab;
					int num;
					for (int i = 0; i < list.Count; i = num + 1)
					{
						foreach (ControllerPollingInfo controllerPollingInfo in list[i].PollForAllElements())
						{
							yield return controllerPollingInfo;
						}
						IEnumerator<ControllerPollingInfo> enumerator = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x060015DA RID: 5594 RVA: 0x00013122 File Offset: 0x00011322
				private IEnumerable<ControllerPollingInfo> SblYzACzHVKkwjANDVRuZcJaDNsfA()
				{
					IList<CustomController> list = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.ZdOnxkFcYHFlRBGFPcjfEWrunVkab;
					int num;
					for (int i = 0; i < list.Count; i = num + 1)
					{
						foreach (ControllerPollingInfo controllerPollingInfo in list[i].PollForAllElementsDown())
						{
							yield return controllerPollingInfo;
						}
						IEnumerator<ControllerPollingInfo> enumerator = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x060015DB RID: 5595 RVA: 0x0001312B File Offset: 0x0001132B
				private IEnumerable<ControllerPollingInfo> tPOSYIuddeAanKoliMUpcUlsaCzwA()
				{
					IList<CustomController> list = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.ZdOnxkFcYHFlRBGFPcjfEWrunVkab;
					int num;
					for (int i = 0; i < list.Count; i = num + 1)
					{
						foreach (ControllerPollingInfo controllerPollingInfo in list[i].PollForAllButtons())
						{
							yield return controllerPollingInfo;
						}
						IEnumerator<ControllerPollingInfo> enumerator = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x060015DC RID: 5596 RVA: 0x00013134 File Offset: 0x00011334
				private IEnumerable<ControllerPollingInfo> lNegjDFryAvFYhQOYJeUmNRTTGcuA()
				{
					IList<CustomController> list = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.ZdOnxkFcYHFlRBGFPcjfEWrunVkab;
					int num;
					for (int i = 0; i < list.Count; i = num + 1)
					{
						foreach (ControllerPollingInfo controllerPollingInfo in list[i].PollForAllButtonsDown())
						{
							yield return controllerPollingInfo;
						}
						IEnumerator<ControllerPollingInfo> enumerator = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x060015DD RID: 5597 RVA: 0x0001313D File Offset: 0x0001133D
				private IEnumerable<ControllerPollingInfo> ZVPWBfskCPlYGgMcRXZEFamSOSbe()
				{
					IList<CustomController> list = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.ZdOnxkFcYHFlRBGFPcjfEWrunVkab;
					int num;
					for (int i = 0; i < list.Count; i = num + 1)
					{
						foreach (ControllerPollingInfo controllerPollingInfo in list[i].PollForAllAxes())
						{
							yield return controllerPollingInfo;
						}
						IEnumerator<ControllerPollingInfo> enumerator = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x060015DE RID: 5598 RVA: 0x00069E4C File Offset: 0x0006804C
				private IEnumerable<ControllerPollingInfo> aNoksVxAthANgavXxldtiwLDDJbjB(int A_1)
				{
					CustomController customController = ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.GetCustomController(A_1);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllElements();
				}

				// Token: 0x060015DF RID: 5599 RVA: 0x00069E74 File Offset: 0x00068074
				private IEnumerable<ControllerPollingInfo> FRmTFBXlMqRRhGoryvOHShlNgOzCA(int A_1)
				{
					CustomController customController = ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.GetCustomController(A_1);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllElementsDown();
				}

				// Token: 0x060015E0 RID: 5600 RVA: 0x00069E9C File Offset: 0x0006809C
				private IEnumerable<ControllerPollingInfo> UhGVMGHMnVyoNRPboeZcpIhZHxYJ(int A_1)
				{
					CustomController customController = ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.GetCustomController(A_1);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllButtons();
				}

				// Token: 0x060015E1 RID: 5601 RVA: 0x00069EC4 File Offset: 0x000680C4
				private IEnumerable<ControllerPollingInfo> OwXbzoisFsPbLCavksZcToIsDTCWB(int A_1)
				{
					CustomController customController = ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.GetCustomController(A_1);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllButtonsDown();
				}

				// Token: 0x060015E2 RID: 5602 RVA: 0x00069EEC File Offset: 0x000680EC
				private IEnumerable<ControllerPollingInfo> HWEpeBbuRUWRVtvLMVepZixIBmAg(int A_1)
				{
					CustomController customController = ReInput.ControllerHelper.DUvmiJbQfpwlOqAmhAelyneQZaNL.GetCustomController(A_1);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllAxes();
				}

				// Token: 0x04000C0E RID: 3086
				private static ReInput.ControllerHelper.PollingHelper lWjjiTwbjcMSEzjhvUrbppQIWEYt;
			}

			// Token: 0x020001BC RID: 444
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class ConflictCheckingHelper : CodeHelper
			{
				// Token: 0x1700056B RID: 1387
				// (get) Token: 0x06001678 RID: 5752 RVA: 0x00013623 File Offset: 0x00011823
				internal static ReInput.ControllerHelper.ConflictCheckingHelper IYCgJEbNDoVEFNSdLdJyHXJZRHyO
				{
					get
					{
						ReInput.ControllerHelper.ConflictCheckingHelper result;
						if ((result = ReInput.ControllerHelper.ConflictCheckingHelper.YQejWFbxFAnWFGgbIGRrJuUolXmn) == null)
						{
							result = (ReInput.ControllerHelper.ConflictCheckingHelper.YQejWFbxFAnWFGgbIGRrJuUolXmn = new ReInput.ControllerHelper.ConflictCheckingHelper());
						}
						return result;
					}
				}

				// Token: 0x06001679 RID: 5753 RVA: 0x00012058 File Offset: 0x00010258
				private ConflictCheckingHelper()
				{
				}

				// Token: 0x0600167A RID: 5754 RVA: 0x00013639 File Offset: 0x00011839
				public bool DoesAnyElementAssignmentConflict()
				{
					return this.DoesAnyElementAssignmentConflict(false, false, true);
				}

				// Token: 0x0600167B RID: 5755 RVA: 0x00013644 File Offset: 0x00011844
				public bool DoesAnyElementAssignmentConflict(bool skipDisabledMaps)
				{
					return this.DoesAnyElementAssignmentConflict(skipDisabledMaps, false, true);
				}

				// Token: 0x0600167C RID: 5756 RVA: 0x0001364F File Offset: 0x0001184F
				public bool DoesAnyElementAssignmentConflict(bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return this.DoesAnyElementAssignmentConflict(skipDisabledMaps, forceCheckAllCategories, true);
				}

				// Token: 0x0600167D RID: 5757 RVA: 0x0006BAB0 File Offset: 0x00069CB0
				public bool DoesAnyElementAssignmentConflict(bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!ReInput.CheckInitialized())
					{
						return false;
					}
					IList<Player> list = includeSystemPlayer ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						Player player = list[i];
						int num = forceCheckAllCategories ? i : 0;
						IList<Joystick> joysticks = player.controllers.Joysticks;
						for (int j = 0; j < joysticks.Count; j++)
						{
							Joystick joystick = joysticks[j];
							IList<JoystickMap> maps = player.controllers.maps.GetMaps<JoystickMap>(joystick.id);
							if (maps != null)
							{
								int count2 = maps.Count;
								for (int k = num; k < count; k++)
								{
									Player player2 = list[k];
									for (int l = 0; l < count2; l++)
									{
										if (player2.controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Joystick, joystick.id, maps[l], skipDisabledMaps, forceCheckAllCategories))
										{
											return true;
										}
									}
								}
							}
						}
						IList<KeyboardMap> maps2 = player.controllers.maps.GetMaps<KeyboardMap>(0);
						for (int m = 0; m < maps2.Count; m++)
						{
							for (int n = num; n < count; n++)
							{
								if (list[n].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Keyboard, 0, maps2[m], skipDisabledMaps, forceCheckAllCategories))
								{
									return true;
								}
							}
						}
						IList<MouseMap> maps3 = player.controllers.maps.GetMaps<MouseMap>(0);
						for (int num2 = 0; num2 < maps3.Count; num2++)
						{
							for (int num3 = num; num3 < count; num3++)
							{
								if (list[num3].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Mouse, 0, maps3[num2], skipDisabledMaps, forceCheckAllCategories))
								{
									return true;
								}
							}
						}
						IList<CustomController> customControllers = player.controllers.CustomControllers;
						for (int num4 = 0; num4 < customControllers.Count; num4++)
						{
							CustomController customController = customControllers[num4];
							IList<CustomControllerMap> maps4 = player.controllers.maps.GetMaps<CustomControllerMap>(customController.id);
							if (maps4 != null)
							{
								int count3 = maps4.Count;
								for (int num5 = num; num5 < count; num5++)
								{
									Player player3 = list[num5];
									for (int num6 = 0; num6 < count3; num6++)
									{
										if (player3.controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Custom, customController.id, maps4[num6], skipDisabledMaps, forceCheckAllCategories))
										{
											return true;
										}
									}
								}
							}
						}
					}
					return false;
				}

				// Token: 0x0600167E RID: 5758 RVA: 0x0006BD2C File Offset: 0x00069F2C
				public bool DoesElementAssignmentConflict(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return this.DoesElementAssignmentConflict(playerId, controllerType, controllerId, controllerMap, elementMap, false, false, true);
				}

				// Token: 0x0600167F RID: 5759 RVA: 0x0006BD4C File Offset: 0x00069F4C
				public bool DoesElementAssignmentConflict(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return this.DoesElementAssignmentConflict(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, false, true);
				}

				// Token: 0x06001680 RID: 5760 RVA: 0x0006BD6C File Offset: 0x00069F6C
				public bool DoesElementAssignmentConflict(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return this.DoesElementAssignmentConflict(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, true);
				}

				// Token: 0x06001681 RID: 5761 RVA: 0x0006BD8C File Offset: 0x00069F8C
				public bool DoesElementAssignmentConflict(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!ReInput.CheckInitialized())
					{
						return false;
					}
					if (playerId < 0 || elementMap == null)
					{
						return false;
					}
					if (controllerType == ControllerType.Joystick)
					{
						return this.NxhpCbFDiHMlvtHLOehRFTatveOE(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (controllerType == ControllerType.Keyboard)
					{
						return this.LMksaWqrxRCStEKKmvnRiiJpbRdh(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (controllerType == ControllerType.Mouse)
					{
						return this.OAGCSZnsfEBVFBHSqFaLTIICCiIEA(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (controllerType == ControllerType.Custom)
					{
						return this.udZVYNLCETtUcxHKfKSdBcOnskyL(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				// Token: 0x06001682 RID: 5762 RVA: 0x0001365A File Offset: 0x0001185A
				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck)
				{
					return this.DoesElementAssignmentConflict(conflictCheck, false, false, true);
				}

				// Token: 0x06001683 RID: 5763 RVA: 0x00013666 File Offset: 0x00011866
				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return this.DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps, false, true);
				}

				// Token: 0x06001684 RID: 5764 RVA: 0x00013672 File Offset: 0x00011872
				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return this.DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps, forceCheckAllCategories, true);
				}

				// Token: 0x06001685 RID: 5765 RVA: 0x0006BE20 File Offset: 0x0006A020
				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!ReInput.CheckInitialized())
					{
						return false;
					}
					if (conflictCheck.playerId < 0)
					{
						return false;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return this.kqjfhNZhHLAHxcZctZqdMTuwDioT(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return this.BjKJGROoWWRzuBwvfXuvWgmXerAE(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return this.IynYMCwBbKYhlUzDApXPtblTvjtf(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return this.ADlJcyvWfMSKOBZjBVlyGouMrnPS(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				// Token: 0x06001686 RID: 5766 RVA: 0x0006BEA0 File Offset: 0x0006A0A0
				private bool NxhpCbFDiHMlvtHLOehRFTatveOE(int A_1, int A_2, JoystickMap A_3, ActionElementMap A_4, bool A_5 = false, bool A_6 = false, bool A_7 = true)
				{
					if (A_1 < 0 || A_4 == null)
					{
						return false;
					}
					IList<Player> list = A_7 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Joystick, A_2, A_3, A_4, A_5, A_6))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x06001687 RID: 5767 RVA: 0x0006BF08 File Offset: 0x0006A108
				private bool kqjfhNZhHLAHxcZctZqdMTuwDioT(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false, bool A_4 = true)
				{
					if (A_1.playerId < 0 || A_1.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = A_4 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(A_1, A_2, A_3))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x06001688 RID: 5768 RVA: 0x0006BF78 File Offset: 0x0006A178
				private bool LMksaWqrxRCStEKKmvnRiiJpbRdh(int A_1, KeyboardMap A_2, ActionElementMap A_3, bool A_4 = false, bool A_5 = false, bool A_6 = true)
				{
					if (A_1 < 0 || A_3 == null)
					{
						return false;
					}
					IList<Player> list = A_6 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Keyboard, 0, A_2, A_3, A_4, A_5))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x06001689 RID: 5769 RVA: 0x0006BFE0 File Offset: 0x0006A1E0
				private bool BjKJGROoWWRzuBwvfXuvWgmXerAE(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false, bool A_4 = true)
				{
					if (A_1.playerId < 0 || A_1.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = A_4 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(A_1, A_2, A_3))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x0600168A RID: 5770 RVA: 0x0006C050 File Offset: 0x0006A250
				private bool OAGCSZnsfEBVFBHSqFaLTIICCiIEA(int A_1, MouseMap A_2, ActionElementMap A_3, bool A_4 = false, bool A_5 = false, bool A_6 = true)
				{
					if (A_1 < 0 || A_3 == null)
					{
						return false;
					}
					IList<Player> list = A_6 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Mouse, 0, A_2, A_3, A_4, A_5))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x0600168B RID: 5771 RVA: 0x0006BF08 File Offset: 0x0006A108
				private bool IynYMCwBbKYhlUzDApXPtblTvjtf(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false, bool A_4 = true)
				{
					if (A_1.playerId < 0 || A_1.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = A_4 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(A_1, A_2, A_3))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x0600168C RID: 5772 RVA: 0x0006C0B8 File Offset: 0x0006A2B8
				private bool udZVYNLCETtUcxHKfKSdBcOnskyL(int A_1, int A_2, CustomControllerMap A_3, ActionElementMap A_4, bool A_5 = false, bool A_6 = false, bool A_7 = true)
				{
					if (A_1 < 0 || A_4 == null)
					{
						return false;
					}
					IList<Player> list = A_7 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Custom, A_2, A_3, A_4, A_5, A_6))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x0600168D RID: 5773 RVA: 0x0006BF08 File Offset: 0x0006A108
				private bool ADlJcyvWfMSKOBZjBVlyGouMrnPS(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false, bool A_4 = true)
				{
					if (A_1.playerId < 0 || A_1.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = A_4 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(A_1, A_2, A_3))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x0600168E RID: 5774 RVA: 0x0006C120 File Offset: 0x0006A320
				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return this.ElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, false, false, true);
				}

				// Token: 0x0600168F RID: 5775 RVA: 0x0006C140 File Offset: 0x0006A340
				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return this.ElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, false, true);
				}

				// Token: 0x06001690 RID: 5776 RVA: 0x0006C160 File Offset: 0x0006A360
				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return this.ElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, true);
				}

				// Token: 0x06001691 RID: 5777 RVA: 0x0006C180 File Offset: 0x0006A380
				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!ReInput.CheckInitialized())
					{
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (playerId < 0 || elementMap == null)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					if (controllerType == ControllerType.Joystick)
					{
						return this.efpbBlDdiGgJKSuNysGicLidGblr(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (controllerType == ControllerType.Keyboard)
					{
						return this.OuWjSeIDypUVvGeNTseeqiZtVRXd(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (controllerType == ControllerType.Mouse)
					{
						return this.wplqsZKZUVsICyWrcPIYrpcblwtN(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (controllerType == ControllerType.Custom)
					{
						return this.BBVgyIeHXLTUALBCPvWPJnvDTzZl(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				// Token: 0x06001692 RID: 5778 RVA: 0x0001367E File Offset: 0x0001187E
				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return this.ElementAssignmentConflicts(conflictCheck, false, false, true);
				}

				// Token: 0x06001693 RID: 5779 RVA: 0x0001368A File Offset: 0x0001188A
				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return this.ElementAssignmentConflicts(conflictCheck, skipDisabledMaps, false, true);
				}

				// Token: 0x06001694 RID: 5780 RVA: 0x00013696 File Offset: 0x00011896
				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return this.ElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories, true);
				}

				// Token: 0x06001695 RID: 5781 RVA: 0x0006C21C File Offset: 0x0006A41C
				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!ReInput.CheckInitialized())
					{
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (conflictCheck.playerId < 0)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return this.tRHxQjYFbZHjJKcfsHQPCxBiMCJl(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return this.BEWazSvuDAEqibEHGlqOojhkNOkS(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return this.IzNdgljNsPrUkFRFaWbLGGGJWNNd(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return this.GvgCVwFWFIxpiDhyQUYBcHjSpgvU(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				// Token: 0x06001696 RID: 5782 RVA: 0x000136A2 File Offset: 0x000118A2
				private IEnumerable<ElementAssignmentConflictInfo> efpbBlDdiGgJKSuNysGicLidGblr(int A_1, int A_2, JoystickMap A_3, ActionElementMap A_4, bool A_5 = false, bool A_6 = false, bool A_7 = true)
				{
					if (A_1 < 0 || A_4 == null)
					{
						yield break;
					}
					IList<Player> list = A_7 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					int num;
					for (int i = 0; i < list.Count; i = num + 1)
					{
						foreach (ElementAssignmentConflictInfo elementAssignmentConflictInfo in list[i].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Joystick, A_2, A_3, A_4, A_5, A_6))
						{
							yield return elementAssignmentConflictInfo;
						}
						IEnumerator<ElementAssignmentConflictInfo> enumerator = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x06001697 RID: 5783 RVA: 0x000136E0 File Offset: 0x000118E0
				private IEnumerable<ElementAssignmentConflictInfo> tRHxQjYFbZHjJKcfsHQPCxBiMCJl(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false, bool A_4 = true)
				{
					if (A_1.playerId < 0 || A_1.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						yield break;
					}
					IList<Player> list = A_4 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					int num;
					for (int i = 0; i < list.Count; i = num + 1)
					{
						foreach (ElementAssignmentConflictInfo elementAssignmentConflictInfo in list[i].controllers.conflictChecking.ElementAssignmentConflicts(A_1, A_2, A_3))
						{
							yield return elementAssignmentConflictInfo;
						}
						IEnumerator<ElementAssignmentConflictInfo> enumerator = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x06001698 RID: 5784 RVA: 0x00013706 File Offset: 0x00011906
				private IEnumerable<ElementAssignmentConflictInfo> OuWjSeIDypUVvGeNTseeqiZtVRXd(int A_1, KeyboardMap A_2, ActionElementMap A_3, bool A_4 = false, bool A_5 = false, bool A_6 = true)
				{
					if (A_1 < 0 || A_3 == null)
					{
						yield break;
					}
					IList<Player> list = A_6 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					int num;
					for (int i = 0; i < list.Count; i = num + 1)
					{
						foreach (ElementAssignmentConflictInfo elementAssignmentConflictInfo in list[i].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Keyboard, 0, A_2, A_3, A_4, A_5))
						{
							yield return elementAssignmentConflictInfo;
						}
						IEnumerator<ElementAssignmentConflictInfo> enumerator = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x06001699 RID: 5785 RVA: 0x0001373C File Offset: 0x0001193C
				private IEnumerable<ElementAssignmentConflictInfo> BEWazSvuDAEqibEHGlqOojhkNOkS(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false, bool A_4 = true)
				{
					if (A_1.playerId < 0 || A_1.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						yield break;
					}
					IList<Player> list = A_4 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					int num;
					for (int i = 0; i < list.Count; i = num + 1)
					{
						foreach (ElementAssignmentConflictInfo elementAssignmentConflictInfo in list[i].controllers.conflictChecking.ElementAssignmentConflicts(A_1, A_2, A_3))
						{
							yield return elementAssignmentConflictInfo;
						}
						IEnumerator<ElementAssignmentConflictInfo> enumerator = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x0600169A RID: 5786 RVA: 0x00013762 File Offset: 0x00011962
				private IEnumerable<ElementAssignmentConflictInfo> wplqsZKZUVsICyWrcPIYrpcblwtN(int A_1, MouseMap A_2, ActionElementMap A_3, bool A_4 = false, bool A_5 = false, bool A_6 = true)
				{
					if (A_1 < 0 || A_3 == null)
					{
						yield break;
					}
					IList<Player> list = A_6 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					int num;
					for (int i = 0; i < list.Count; i = num + 1)
					{
						foreach (ElementAssignmentConflictInfo elementAssignmentConflictInfo in list[i].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Mouse, 0, A_2, A_3, A_4, A_5))
						{
							yield return elementAssignmentConflictInfo;
						}
						IEnumerator<ElementAssignmentConflictInfo> enumerator = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x0600169B RID: 5787 RVA: 0x00013798 File Offset: 0x00011998
				private IEnumerable<ElementAssignmentConflictInfo> IzNdgljNsPrUkFRFaWbLGGGJWNNd(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false, bool A_4 = true)
				{
					if (A_1.playerId < 0 || A_1.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						yield break;
					}
					IList<Player> list = A_4 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					int num;
					for (int i = 0; i < list.Count; i = num + 1)
					{
						foreach (ElementAssignmentConflictInfo elementAssignmentConflictInfo in list[i].controllers.conflictChecking.ElementAssignmentConflicts(A_1, A_2, A_3))
						{
							yield return elementAssignmentConflictInfo;
						}
						IEnumerator<ElementAssignmentConflictInfo> enumerator = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x0600169C RID: 5788 RVA: 0x000137BE File Offset: 0x000119BE
				private IEnumerable<ElementAssignmentConflictInfo> BBVgyIeHXLTUALBCPvWPJnvDTzZl(int A_1, int A_2, CustomControllerMap A_3, ActionElementMap A_4, bool A_5 = false, bool A_6 = false, bool A_7 = true)
				{
					if (A_1 < 0 || A_4 == null)
					{
						yield break;
					}
					IList<Player> list = A_7 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					int num;
					for (int i = 0; i < list.Count; i = num + 1)
					{
						foreach (ElementAssignmentConflictInfo elementAssignmentConflictInfo in list[i].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Custom, A_2, A_3, A_4, A_5, A_6))
						{
							yield return elementAssignmentConflictInfo;
						}
						IEnumerator<ElementAssignmentConflictInfo> enumerator = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x0600169D RID: 5789 RVA: 0x000137FC File Offset: 0x000119FC
				private IEnumerable<ElementAssignmentConflictInfo> GvgCVwFWFIxpiDhyQUYBcHjSpgvU(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false, bool A_4 = true)
				{
					if (A_1.playerId < 0 || A_1.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						yield break;
					}
					IList<Player> list = A_4 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					int num;
					for (int i = 0; i < list.Count; i = num + 1)
					{
						foreach (ElementAssignmentConflictInfo elementAssignmentConflictInfo in list[i].controllers.conflictChecking.ElementAssignmentConflicts(A_1, A_2, A_3))
						{
							yield return elementAssignmentConflictInfo;
						}
						IEnumerator<ElementAssignmentConflictInfo> enumerator = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x0600169E RID: 5790 RVA: 0x0006C2A4 File Offset: 0x0006A4A4
				public int RemoveElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return this.RemoveElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, false, false, true);
				}

				// Token: 0x0600169F RID: 5791 RVA: 0x0006C2C4 File Offset: 0x0006A4C4
				public int RemoveElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return this.RemoveElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, false, true);
				}

				// Token: 0x060016A0 RID: 5792 RVA: 0x0006C2E4 File Offset: 0x0006A4E4
				public int RemoveElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return this.RemoveElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, true);
				}

				// Token: 0x060016A1 RID: 5793 RVA: 0x0006C304 File Offset: 0x0006A504
				public int RemoveElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!ReInput.CheckInitialized())
					{
						return 0;
					}
					if (playerId < 0 || elementMap == null)
					{
						return 0;
					}
					if (controllerType == ControllerType.Joystick)
					{
						return this.xVRftgJXGoeWeLocIVAJoreoIXFnA(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (controllerType == ControllerType.Keyboard)
					{
						return this.hQWSaqJLsjeilUwEHwmgDqGbzoyL(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (controllerType == ControllerType.Mouse)
					{
						return this.RptcicsEiZAzjAXnedoaugsaBbrKA(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (controllerType == ControllerType.Custom)
					{
						return this.SXStjciavdbFIkpVZrHHsmYUflFiA(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				// Token: 0x060016A2 RID: 5794 RVA: 0x00013822 File Offset: 0x00011A22
				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return this.RemoveElementAssignmentConflicts(conflictCheck, false, false, true);
				}

				// Token: 0x060016A3 RID: 5795 RVA: 0x0001382E File Offset: 0x00011A2E
				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return this.RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps, false, true);
				}

				// Token: 0x060016A4 RID: 5796 RVA: 0x0001383A File Offset: 0x00011A3A
				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return this.RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories, true);
				}

				// Token: 0x060016A5 RID: 5797 RVA: 0x0006C398 File Offset: 0x0006A598
				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!ReInput.CheckInitialized())
					{
						return 0;
					}
					if (conflictCheck.playerId < 0)
					{
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return this.KfziCzRyFpZdggjoLDSSLOYlaTlP(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return this.itIfNxuDwoYcXCGkAljrQmPVHAvN(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return this.dOaVZAyfBGlJVuLzzennzaTZbazGA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return this.xCpjfrOsFZkHqrtWRoVDBaFMkoNl(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				// Token: 0x060016A6 RID: 5798 RVA: 0x0006C418 File Offset: 0x0006A618
				private int xVRftgJXGoeWeLocIVAJoreoIXFnA(int A_1, int A_2, JoystickMap A_3, ActionElementMap A_4, bool A_5 = false, bool A_6 = false, bool A_7 = true)
				{
					if (A_1 < 0 || A_4 == null)
					{
						return 0;
					}
					IList<Player> list = A_7 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Joystick, A_2, A_3, A_4, A_5, A_6);
					}
					return num;
				}

				// Token: 0x060016A7 RID: 5799 RVA: 0x0006C480 File Offset: 0x0006A680
				private int KfziCzRyFpZdggjoLDSSLOYlaTlP(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false, bool A_4 = true)
				{
					if (A_1.playerId < 0 || A_1.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = A_4 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(A_1, A_2, A_3);
					}
					return num;
				}

				// Token: 0x060016A8 RID: 5800 RVA: 0x0006C4F0 File Offset: 0x0006A6F0
				private int hQWSaqJLsjeilUwEHwmgDqGbzoyL(int A_1, KeyboardMap A_2, ActionElementMap A_3, bool A_4 = false, bool A_5 = false, bool A_6 = true)
				{
					if (A_1 < 0 || A_3 == null)
					{
						return 0;
					}
					IList<Player> list = A_6 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Keyboard, 0, A_2, A_3, A_4, A_5);
					}
					return num;
				}

				// Token: 0x060016A9 RID: 5801 RVA: 0x0006C558 File Offset: 0x0006A758
				private int itIfNxuDwoYcXCGkAljrQmPVHAvN(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false, bool A_4 = true)
				{
					if (A_1.playerId < 0 || A_1.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = A_4 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(A_1, A_2, A_3);
					}
					return num;
				}

				// Token: 0x060016AA RID: 5802 RVA: 0x0006C5C8 File Offset: 0x0006A7C8
				private int RptcicsEiZAzjAXnedoaugsaBbrKA(int A_1, MouseMap A_2, ActionElementMap A_3, bool A_4 = false, bool A_5 = false, bool A_6 = true)
				{
					if (A_1 < 0 || A_3 == null)
					{
						return 0;
					}
					IList<Player> list = A_6 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Mouse, 0, A_2, A_3, A_4, A_5);
					}
					return num;
				}

				// Token: 0x060016AB RID: 5803 RVA: 0x0006C480 File Offset: 0x0006A680
				private int dOaVZAyfBGlJVuLzzennzaTZbazGA(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false, bool A_4 = true)
				{
					if (A_1.playerId < 0 || A_1.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = A_4 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(A_1, A_2, A_3);
					}
					return num;
				}

				// Token: 0x060016AC RID: 5804 RVA: 0x0006C630 File Offset: 0x0006A830
				private int SXStjciavdbFIkpVZrHHsmYUflFiA(int A_1, int A_2, CustomControllerMap A_3, ActionElementMap A_4, bool A_5 = false, bool A_6 = false, bool A_7 = true)
				{
					if (A_1 < 0 || A_4 == null)
					{
						return 0;
					}
					IList<Player> list = A_7 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Custom, A_2, A_3, A_4, A_5, A_6);
					}
					return num;
				}

				// Token: 0x060016AD RID: 5805 RVA: 0x0006C480 File Offset: 0x0006A680
				private int xCpjfrOsFZkHqrtWRoVDBaFMkoNl(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false, bool A_4 = true)
				{
					if (A_1.playerId < 0 || A_1.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = A_4 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(A_1, A_2, A_3);
					}
					return num;
				}

				// Token: 0x060016AE RID: 5806 RVA: 0x0006C69C File Offset: 0x0006A89C
				public int DisableElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return this.DisableElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, false, false, true);
				}

				// Token: 0x060016AF RID: 5807 RVA: 0x0006C6BC File Offset: 0x0006A8BC
				public int DisableElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return this.DisableElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, false, true);
				}

				// Token: 0x060016B0 RID: 5808 RVA: 0x0006C6DC File Offset: 0x0006A8DC
				public int DisableElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return this.DisableElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, true);
				}

				// Token: 0x060016B1 RID: 5809 RVA: 0x0006C6FC File Offset: 0x0006A8FC
				public int DisableElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!ReInput.CheckInitialized())
					{
						return 0;
					}
					if (playerId < 0 || elementMap == null)
					{
						return 0;
					}
					if (controllerType == ControllerType.Joystick)
					{
						return this.yIiDfdHrASDepFlLhNUKDbISnxmIB(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (controllerType == ControllerType.Keyboard)
					{
						return this.DGdnCgDTLYlYVFBzpHhNkcuuNBqp(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (controllerType == ControllerType.Mouse)
					{
						return this.tNbshLExRHTMVzPVQbTUqZPoElCL(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (controllerType == ControllerType.Custom)
					{
						return this.XWGnPKEFIRimyOWBowqSVTpRCQjL(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				// Token: 0x060016B2 RID: 5810 RVA: 0x00013846 File Offset: 0x00011A46
				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return this.DisableElementAssignmentConflicts(conflictCheck, false, false, true);
				}

				// Token: 0x060016B3 RID: 5811 RVA: 0x00013852 File Offset: 0x00011A52
				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return this.DisableElementAssignmentConflicts(conflictCheck, skipDisabledMaps, false, true);
				}

				// Token: 0x060016B4 RID: 5812 RVA: 0x0001385E File Offset: 0x00011A5E
				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return this.DisableElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories, true);
				}

				// Token: 0x060016B5 RID: 5813 RVA: 0x0006C790 File Offset: 0x0006A990
				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!ReInput.CheckInitialized())
					{
						return 0;
					}
					if (conflictCheck.playerId < 0)
					{
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return this.SXTzubqrwfQJcDfRtODsbTazBvng(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return this.dRVFnyMbbSGuMYeWrAJKZEQwBWhk(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return this.RlgoJIlpkXgKQndXQRDeWoNHkmSh(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return this.GaCyoyIArstQnsHtqdYVEbschuvr(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				// Token: 0x060016B6 RID: 5814 RVA: 0x0006C810 File Offset: 0x0006AA10
				private int yIiDfdHrASDepFlLhNUKDbISnxmIB(int A_1, int A_2, JoystickMap A_3, ActionElementMap A_4, bool A_5 = false, bool A_6 = false, bool A_7 = true)
				{
					if (A_1 < 0 || A_4 == null)
					{
						return 0;
					}
					IList<Player> list = A_7 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Joystick, A_2, A_3, A_4, A_5, A_6);
					}
					return num;
				}

				// Token: 0x060016B7 RID: 5815 RVA: 0x0006C878 File Offset: 0x0006AA78
				private int SXTzubqrwfQJcDfRtODsbTazBvng(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false, bool A_4 = true)
				{
					if (A_1.playerId < 0 || A_1.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = A_4 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(A_1, A_2, A_3);
					}
					return num;
				}

				// Token: 0x060016B8 RID: 5816 RVA: 0x0006C8E8 File Offset: 0x0006AAE8
				private int DGdnCgDTLYlYVFBzpHhNkcuuNBqp(int A_1, KeyboardMap A_2, ActionElementMap A_3, bool A_4 = false, bool A_5 = false, bool A_6 = true)
				{
					if (A_1 < 0 || A_3 == null)
					{
						return 0;
					}
					IList<Player> list = A_6 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Keyboard, 0, A_2, A_3, A_4, A_5);
					}
					return num;
				}

				// Token: 0x060016B9 RID: 5817 RVA: 0x0006C950 File Offset: 0x0006AB50
				private int dRVFnyMbbSGuMYeWrAJKZEQwBWhk(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false, bool A_4 = true)
				{
					if (A_1.playerId < 0 || A_1.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = A_4 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(A_1, A_2, A_3);
					}
					return num;
				}

				// Token: 0x060016BA RID: 5818 RVA: 0x0006C9C0 File Offset: 0x0006ABC0
				private int tNbshLExRHTMVzPVQbTUqZPoElCL(int A_1, MouseMap A_2, ActionElementMap A_3, bool A_4 = false, bool A_5 = false, bool A_6 = true)
				{
					if (A_1 < 0 || A_3 == null)
					{
						return 0;
					}
					IList<Player> list = A_6 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Mouse, 0, A_2, A_3, A_4, A_5);
					}
					return num;
				}

				// Token: 0x060016BB RID: 5819 RVA: 0x0006C878 File Offset: 0x0006AA78
				private int RlgoJIlpkXgKQndXQRDeWoNHkmSh(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false, bool A_4 = true)
				{
					if (A_1.playerId < 0 || A_1.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = A_4 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(A_1, A_2, A_3);
					}
					return num;
				}

				// Token: 0x060016BC RID: 5820 RVA: 0x0006CA28 File Offset: 0x0006AC28
				private int XWGnPKEFIRimyOWBowqSVTpRCQjL(int A_1, int A_2, CustomControllerMap A_3, ActionElementMap A_4, bool A_5 = false, bool A_6 = false, bool A_7 = true)
				{
					if (A_1 < 0 || A_4 == null)
					{
						return 0;
					}
					IList<Player> list = A_7 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Custom, A_2, A_3, A_4, A_5, A_6);
					}
					return num;
				}

				// Token: 0x060016BD RID: 5821 RVA: 0x0006C878 File Offset: 0x0006AA78
				private int GaCyoyIArstQnsHtqdYVEbschuvr(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false, bool A_4 = true)
				{
					if (A_1.playerId < 0 || A_1.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = A_4 ? ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc : ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(A_1, A_2, A_3);
					}
					return num;
				}

				// Token: 0x04000C64 RID: 3172
				private static ReInput.ControllerHelper.ConflictCheckingHelper YQejWFbxFAnWFGgbIGRrJuUolXmn;
			}
		}

		// Token: 0x020001C5 RID: 453
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class MappingHelper : CodeHelper
		{
			// Token: 0x1700057C RID: 1404
			// (get) Token: 0x06001706 RID: 5894 RVA: 0x00013B02 File Offset: 0x00011D02
			internal static ReInput.MappingHelper OPFbinUedlVplwFfYOgOwPPXWQpg
			{
				get
				{
					ReInput.MappingHelper result;
					if ((result = ReInput.MappingHelper.ZfqTOtxpSXTFoIaCOiPevzncTWrr) == null)
					{
						result = (ReInput.MappingHelper.ZfqTOtxpSXTFoIaCOiPevzncTWrr = new ReInput.MappingHelper());
					}
					return result;
				}
			}

			// Token: 0x06001707 RID: 5895 RVA: 0x00012058 File Offset: 0x00010258
			private MappingHelper()
			{
			}

			// Token: 0x1700057D RID: 1405
			// (get) Token: 0x06001708 RID: 5896 RVA: 0x00013B18 File Offset: 0x00011D18
			public IList<InputMapCategory> MapCategories
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.bxNZYrWGGMsIWHSTVpBBMkfCoErr;
				}
			}

			// Token: 0x06001709 RID: 5897 RVA: 0x00013B31 File Offset: 0x00011D31
			public InputMapCategory GetMapCategory(int mapCategoryId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetMapCategoryById(mapCategoryId);
			}

			// Token: 0x0600170A RID: 5898 RVA: 0x00013B47 File Offset: 0x00011D47
			public InputMapCategory GetMapCategory(string name)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetMapCategory(name);
			}

			// Token: 0x0600170B RID: 5899 RVA: 0x00013B5D File Offset: 0x00011D5D
			public int GetMapCategoryId(string name)
			{
				if (!ReInput.CheckInitialized())
				{
					return -1;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetMapCategoryId(name);
			}

			// Token: 0x0600170C RID: 5900 RVA: 0x00013B73 File Offset: 0x00011D73
			public IEnumerable<InputMapCategory> MapCategoriesWithTag(string tag)
			{
				if (!ReInput.CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.tOHeBYPLsQIOugrGVejLbnFqchgJA(tag);
			}

			// Token: 0x1700057E RID: 1406
			// (get) Token: 0x0600170D RID: 5901 RVA: 0x00013B8D File Offset: 0x00011D8D
			public IEnumerable<InputMapCategory> UserAssignableMapCategories
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.vrAAiyMsAeZaHZwDCkikiItHgxaX;
				}
			}

			// Token: 0x0600170E RID: 5902 RVA: 0x00013BA6 File Offset: 0x00011DA6
			public IEnumerable<InputMapCategory> UserAssignableMapCategoriesWithTag(string tag)
			{
				if (!ReInput.CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.yYRjcGVNtrTXEjSglhEamviSaNod(tag);
			}

			// Token: 0x0600170F RID: 5903 RVA: 0x0006DAB4 File Offset: 0x0006BCB4
			public bool IsMapCategoryUserAssignable(int mapCategoryId)
			{
				if (!ReInput.CheckInitialized())
				{
					return false;
				}
				InputCategory mapCategory = this.GetMapCategory(mapCategoryId);
				return mapCategory != null && mapCategory.userAssignable;
			}

			// Token: 0x06001710 RID: 5904 RVA: 0x00013BC0 File Offset: 0x00011DC0
			public InputCategory GetActionCategory(int mapCategoryId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetActionCategoryById(mapCategoryId);
			}

			// Token: 0x06001711 RID: 5905 RVA: 0x00013BD6 File Offset: 0x00011DD6
			public InputCategory GetActionCategory(string name)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetActionCategory(name);
			}

			// Token: 0x06001712 RID: 5906 RVA: 0x00013BEC File Offset: 0x00011DEC
			public int GetActionCategoryId(string name)
			{
				if (!ReInput.CheckInitialized())
				{
					return -1;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetActionCategoryId(name);
			}

			// Token: 0x1700057F RID: 1407
			// (get) Token: 0x06001713 RID: 5907 RVA: 0x00013C02 File Offset: 0x00011E02
			public IList<InputCategory> ActionCategories
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.OQXvniYgjUwHSWNCrZGsvanndody;
				}
			}

			// Token: 0x06001714 RID: 5908 RVA: 0x00013C1B File Offset: 0x00011E1B
			public IEnumerable<InputCategory> ActionCategoriesWithTag(string tag)
			{
				if (!ReInput.CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.UHzFRVcJCDjQquoOQDgEIeNZGdEhA(tag);
			}

			// Token: 0x17000580 RID: 1408
			// (get) Token: 0x06001715 RID: 5909 RVA: 0x00013C35 File Offset: 0x00011E35
			public IEnumerable<InputCategory> UserAssignableActionCategories
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.FEbUyWIbYykDcNCiQdqhBcVnveHrA;
				}
			}

			// Token: 0x06001716 RID: 5910 RVA: 0x00013C4E File Offset: 0x00011E4E
			public IEnumerable<InputCategory> UserAssignableActionCategoriesWithTag(string tag)
			{
				if (!ReInput.CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.mjKEQBGMeqFkNNUhoxxgfGoSaoJv(tag);
			}

			// Token: 0x06001717 RID: 5911 RVA: 0x0006DAE0 File Offset: 0x0006BCE0
			public bool IsActionCategoryUserAssignable(int mapCategoryId)
			{
				if (!ReInput.CheckInitialized())
				{
					return false;
				}
				InputCategory actionCategory = this.GetActionCategory(mapCategoryId);
				return actionCategory != null && actionCategory.userAssignable;
			}

			// Token: 0x06001718 RID: 5912 RVA: 0x0006DB0C File Offset: 0x0006BD0C
			public InputLayout GetLayout(ControllerType controllerType, int layoutId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				switch (controllerType)
				{
				case ControllerType.Keyboard:
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetKeyboardLayoutById(layoutId);
				case ControllerType.Mouse:
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetMouseLayoutById(layoutId);
				case ControllerType.Joystick:
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetJoystickLayoutById(layoutId);
				default:
					if (controllerType != ControllerType.Custom)
					{
						throw new NotImplementedException();
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetCustomControllerLayoutById(layoutId);
				}
			}

			// Token: 0x06001719 RID: 5913 RVA: 0x0006DB70 File Offset: 0x0006BD70
			public InputLayout GetLayout(ControllerType controllerType, string name)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				switch (controllerType)
				{
				case ControllerType.Keyboard:
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetKeyboardLayout(name);
				case ControllerType.Mouse:
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetMouseLayout(name);
				case ControllerType.Joystick:
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetJoystickLayout(name);
				default:
					if (controllerType != ControllerType.Custom)
					{
						throw new NotImplementedException();
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetCustomControllerLayout(name);
				}
			}

			// Token: 0x0600171A RID: 5914 RVA: 0x0006DBD4 File Offset: 0x0006BDD4
			public int GetLayoutId(ControllerType controllerType, string name)
			{
				if (!ReInput.CheckInitialized())
				{
					return -1;
				}
				switch (controllerType)
				{
				case ControllerType.Keyboard:
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetKeyboardLayoutId(name);
				case ControllerType.Mouse:
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetMouseLayoutId(name);
				case ControllerType.Joystick:
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetJoystickLayoutId(name);
				default:
					if (controllerType != ControllerType.Custom)
					{
						throw new NotImplementedException();
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetCustomControllerLayoutId(name);
				}
			}

			// Token: 0x0600171B RID: 5915 RVA: 0x00013C68 File Offset: 0x00011E68
			public InputLayout GetJoystickLayout(int layoutId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetJoystickLayoutById(layoutId);
			}

			// Token: 0x0600171C RID: 5916 RVA: 0x00013C7E File Offset: 0x00011E7E
			public InputLayout GetJoystickLayout(string name)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetJoystickLayout(name);
			}

			// Token: 0x0600171D RID: 5917 RVA: 0x00013C94 File Offset: 0x00011E94
			public int GetJoystickLayoutId(string name)
			{
				if (!ReInput.CheckInitialized())
				{
					return -1;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetJoystickLayoutId(name);
			}

			// Token: 0x0600171E RID: 5918 RVA: 0x00013CAA File Offset: 0x00011EAA
			public InputLayout GetKeyboardLayout(int layoutId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetKeyboardLayoutById(layoutId);
			}

			// Token: 0x0600171F RID: 5919 RVA: 0x00013CC0 File Offset: 0x00011EC0
			public InputLayout GetKeyboardLayout(string name)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetKeyboardLayout(name);
			}

			// Token: 0x06001720 RID: 5920 RVA: 0x00013CD6 File Offset: 0x00011ED6
			public int GetKeyboardLayoutId(string name)
			{
				if (!ReInput.CheckInitialized())
				{
					return -1;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetKeyboardLayoutId(name);
			}

			// Token: 0x06001721 RID: 5921 RVA: 0x00013CEC File Offset: 0x00011EEC
			public InputLayout GetMouseLayout(int layoutId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetMouseLayoutById(layoutId);
			}

			// Token: 0x06001722 RID: 5922 RVA: 0x00013D02 File Offset: 0x00011F02
			public InputLayout GetMouseLayout(string name)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetMouseLayout(name);
			}

			// Token: 0x06001723 RID: 5923 RVA: 0x00013D18 File Offset: 0x00011F18
			public int GetMouseLayoutId(string name)
			{
				if (!ReInput.CheckInitialized())
				{
					return -1;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetMouseLayoutId(name);
			}

			// Token: 0x06001724 RID: 5924 RVA: 0x00013D2E File Offset: 0x00011F2E
			public InputLayout GetCustomControllerLayout(int layoutId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetCustomControllerLayoutById(layoutId);
			}

			// Token: 0x06001725 RID: 5925 RVA: 0x00013D44 File Offset: 0x00011F44
			public InputLayout GetCustomControllerLayout(string name)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetCustomControllerLayout(name);
			}

			// Token: 0x06001726 RID: 5926 RVA: 0x00013D5A File Offset: 0x00011F5A
			public int GetCustomControllerLayoutId(string name)
			{
				if (!ReInput.CheckInitialized())
				{
					return -1;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetCustomControllerLayoutId(name);
			}

			// Token: 0x06001727 RID: 5927 RVA: 0x0006DC38 File Offset: 0x0006BE38
			public IList<InputLayout> MapLayouts(ControllerType controllerType)
			{
				if (!ReInput.CheckInitialized())
				{
					return EmptyObjects<InputLayout>.EmptyReadOnlyIListT;
				}
				switch (controllerType)
				{
				case ControllerType.Keyboard:
					return this.KeyboardLayouts;
				case ControllerType.Mouse:
					return this.MouseLayouts;
				case ControllerType.Joystick:
					return this.JoystickLayouts;
				default:
					if (controllerType != ControllerType.Custom)
					{
						throw new NotImplementedException();
					}
					return this.CustomControllerLayouts;
				}
			}

			// Token: 0x17000581 RID: 1409
			// (get) Token: 0x06001728 RID: 5928 RVA: 0x00013D70 File Offset: 0x00011F70
			public IList<InputLayout> JoystickLayouts
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return EmptyObjects<InputLayout>.EmptyReadOnlyIListT;
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.lSnlmZCSxIICafYigEGAImxRqCRR;
				}
			}

			// Token: 0x17000582 RID: 1410
			// (get) Token: 0x06001729 RID: 5929 RVA: 0x00013D89 File Offset: 0x00011F89
			public IList<InputLayout> KeyboardLayouts
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return EmptyObjects<InputLayout>.EmptyReadOnlyIListT;
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.BWSaWZIHkKTOXkZcdjAAcdnzEgaE;
				}
			}

			// Token: 0x17000583 RID: 1411
			// (get) Token: 0x0600172A RID: 5930 RVA: 0x00013DA2 File Offset: 0x00011FA2
			public IList<InputLayout> MouseLayouts
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return EmptyObjects<InputLayout>.EmptyReadOnlyIListT;
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.SdCANdbcefclZebIeWSLcZPhwnOsB;
				}
			}

			// Token: 0x17000584 RID: 1412
			// (get) Token: 0x0600172B RID: 5931 RVA: 0x00013DBB File Offset: 0x00011FBB
			public IList<InputLayout> CustomControllerLayouts
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return EmptyObjects<InputLayout>.EmptyReadOnlyIListT;
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.VxLXMOySfYDSDZxBhqiycXFHroCP;
				}
			}

			// Token: 0x17000585 RID: 1413
			// (get) Token: 0x0600172C RID: 5932 RVA: 0x00013DD4 File Offset: 0x00011FD4
			public IList<InputAction> Actions
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
					}
					return ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qHlLGZqAmOchfaxcwteLsvTnFDpEb;
				}
			}

			// Token: 0x0600172D RID: 5933 RVA: 0x00013DED File Offset: 0x00011FED
			public InputAction GetAction(int actionId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetActionById(actionId);
			}

			// Token: 0x0600172E RID: 5934 RVA: 0x00013E03 File Offset: 0x00012003
			public InputAction GetAction(string name)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetAction(name);
			}

			// Token: 0x0600172F RID: 5935 RVA: 0x00013E19 File Offset: 0x00012019
			public int GetActionId(string name)
			{
				if (!ReInput.CheckInitialized())
				{
					return -1;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetActionId(name);
			}

			// Token: 0x17000586 RID: 1414
			// (get) Token: 0x06001730 RID: 5936 RVA: 0x00013E2F File Offset: 0x0001202F
			public IEnumerable<InputAction> UserAssignableActions
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
					}
					return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.BwCEAOUxKXKnSthjaMhYrkbuomaN;
				}
			}

			// Token: 0x06001731 RID: 5937 RVA: 0x00013E48 File Offset: 0x00012048
			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName)
			{
				if (!ReInput.CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.WiAMprxKZFIuworMQwGSuEqpbbPy(mapCategoryName, false);
			}

			// Token: 0x06001732 RID: 5938 RVA: 0x00013E63 File Offset: 0x00012063
			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!ReInput.CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.WiAMprxKZFIuworMQwGSuEqpbbPy(mapCategoryName, sort);
			}

			// Token: 0x06001733 RID: 5939 RVA: 0x00013E7E File Offset: 0x0001207E
			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId)
			{
				if (!ReInput.CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.yNKgChHRbvKPpGmxINFphYfanaGpC(mapCategoryId, false);
			}

			// Token: 0x06001734 RID: 5940 RVA: 0x00013E99 File Offset: 0x00012099
			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!ReInput.CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.yNKgChHRbvKPpGmxINFphYfanaGpC(mapCategoryId, sort);
			}

			// Token: 0x06001735 RID: 5941 RVA: 0x00013EB4 File Offset: 0x000120B4
			public IEnumerable<InputAction> ActionsInCategoriesWithTag(string tag)
			{
				if (!ReInput.CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.zcaIJJsGDkRmmWLQfgIDcMOXsWHS(tag);
			}

			// Token: 0x06001736 RID: 5942 RVA: 0x00013ECE File Offset: 0x000120CE
			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId)
			{
				if (!ReInput.CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.FCuHWEkQzkIOZCdjdlCyfURdSIhP(mapCategoryId, false);
			}

			// Token: 0x06001737 RID: 5943 RVA: 0x00013EE9 File Offset: 0x000120E9
			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!ReInput.CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.FCuHWEkQzkIOZCdjdlCyfURdSIhP(mapCategoryId, sort);
			}

			// Token: 0x06001738 RID: 5944 RVA: 0x00013F04 File Offset: 0x00012104
			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName)
			{
				if (!ReInput.CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.kagRtqErSSSqGTCMjJCysLJVDNes(mapCategoryName, false);
			}

			// Token: 0x06001739 RID: 5945 RVA: 0x00013F1F File Offset: 0x0001211F
			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!ReInput.CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.kagRtqErSSSqGTCMjJCysLJVDNes(mapCategoryName, sort);
			}

			// Token: 0x0600173A RID: 5946 RVA: 0x00013F3A File Offset: 0x0001213A
			public IList<InputBehavior> GetInputBehaviors(int playerId)
			{
				if (!ReInput.CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.GQKrzCeHKYCGeeITLHuwkPHlAsjfA(playerId);
			}

			// Token: 0x0600173B RID: 5947 RVA: 0x00013F54 File Offset: 0x00012154
			public IList<InputBehavior> GetSystemPlayerInputBehaviors()
			{
				if (!ReInput.CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.GQKrzCeHKYCGeeITLHuwkPHlAsjfA(9999999);
			}

			// Token: 0x0600173C RID: 5948 RVA: 0x00013F72 File Offset: 0x00012172
			public InputBehavior GetInputBehavior(int playerId, int behaviorId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.EpjSylEaBjOfajGuxXTwARPJWJVB(playerId, behaviorId);
			}

			// Token: 0x0600173D RID: 5949 RVA: 0x00013F89 File Offset: 0x00012189
			public InputBehavior GetInputBehavior(int playerId, string behaviorName)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.FWPTsWMVwaoDtMaEHkKjEPcsctDH(playerId, behaviorName);
			}

			// Token: 0x0600173E RID: 5950 RVA: 0x00013FA0 File Offset: 0x000121A0
			public InputBehavior GetSystemPlayerInputBehavior(int behaviorId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return this.GetInputBehavior(9999999, behaviorId);
			}

			// Token: 0x0600173F RID: 5951 RVA: 0x00013FB7 File Offset: 0x000121B7
			public InputBehavior GetSystemPlayerInputBehavior(string behaviorName)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return this.GetInputBehavior(9999999, behaviorName);
			}

			// Token: 0x06001740 RID: 5952 RVA: 0x00013FCE File Offset: 0x000121CE
			public int GetInputBehaviorId(string behaviorName)
			{
				if (!ReInput.CheckInitialized())
				{
					return -1;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetInputBehaviorId(behaviorName);
			}

			// Token: 0x06001741 RID: 5953 RVA: 0x00013FE4 File Offset: 0x000121E4
			internal InputBehavior CgOzhEpnKagvLdqSMPNiejaceEgNA(int A_1)
			{
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetInputBehaviorById(A_1);
			}

			// Token: 0x06001742 RID: 5954 RVA: 0x00013FF1 File Offset: 0x000121F1
			internal InputBehavior HEVzSJAZAZwyYFjeLrsyzWkQIFIp(string A_1)
			{
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetInputBehavior(A_1);
			}

			// Token: 0x06001743 RID: 5955 RVA: 0x0006DC8C File Offset: 0x0006BE8C
			public ControllerMap GetControllerMap(int id)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				IList<Player> allPlayers = ReInput.players.AllPlayers;
				for (int i = 0; i < allPlayers.Count; i++)
				{
					ControllerMap map = allPlayers[i].controllers.maps.GetMap(id);
					if (map != null)
					{
						return map;
					}
				}
				return null;
			}

			// Token: 0x06001744 RID: 5956 RVA: 0x0006DCDC File Offset: 0x0006BEDC
			public ActionElementMap GetActionElementMap(int id)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				IList<Player> allPlayers = ReInput.players.AllPlayers;
				for (int i = 0; i < allPlayers.Count; i++)
				{
					foreach (ControllerMap controllerMap in allPlayers[i].controllers.maps.GetAllMaps())
					{
						if (controllerMap != null)
						{
							ActionElementMap elementMap = controllerMap.GetElementMap(id);
							if (elementMap != null)
							{
								return elementMap;
							}
						}
					}
				}
				return null;
			}

			// Token: 0x06001745 RID: 5957 RVA: 0x0006DD74 File Offset: 0x0006BF74
			public ControllerMap GetControllerMapInstance(Controller controller, int mapCategoryId, int layoutId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				if (controller == null)
				{
					return null;
				}
				ControllerType type = controller.type;
				switch (type)
				{
				case ControllerType.Keyboard:
					return this.GetKeyboardMapInstance(mapCategoryId, layoutId);
				case ControllerType.Mouse:
					return this.GetMouseMapInstance(mapCategoryId, layoutId);
				case ControllerType.Joystick:
					return this.GetJoystickMapInstance((Joystick)controller, mapCategoryId, layoutId);
				default:
					if (type != ControllerType.Custom)
					{
						throw new NotImplementedException();
					}
					return this.GetCustomControllerMapInstance((CustomController)controller, mapCategoryId, layoutId);
				}
			}

			// Token: 0x06001746 RID: 5958 RVA: 0x0006DDE4 File Offset: 0x0006BFE4
			public ControllerMap GetControllerMapInstance(Controller controller, string mapCategoryName, string layoutName)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				if (controller == null)
				{
					return null;
				}
				int mapCategoryId = this.GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = this.GetLayoutId(controller.type, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return this.GetControllerMapInstance(controller, mapCategoryId, layoutId);
			}

			// Token: 0x06001747 RID: 5959 RVA: 0x0006DE2C File Offset: 0x0006C02C
			public ControllerMap GetControllerMapInstance(ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = this.GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = this.GetLayoutId(controllerIdentifier.controllerType, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return this.GetControllerMapInstance(controllerIdentifier, mapCategoryId, layoutId);
			}

			// Token: 0x06001748 RID: 5960 RVA: 0x0006DE70 File Offset: 0x0006C070
			public ControllerMap GetControllerMapInstance(ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				Controller controller = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.GjbnKwfEMhCIAztPvPYKgnLKAipL(controllerIdentifier, false);
				if (controller != null)
				{
					return this.GetControllerMapInstance(controller, mapCategoryId, layoutId);
				}
				ControllerType controllerType = controllerIdentifier.controllerType;
				switch (controllerType)
				{
				case ControllerType.Keyboard:
					return this.GetKeyboardMapInstance(mapCategoryId, layoutId);
				case ControllerType.Mouse:
					return this.GetMouseMapInstance(mapCategoryId, layoutId);
				case ControllerType.Joystick:
					return this.GetJoystickMapInstance(controllerIdentifier, mapCategoryId, layoutId);
				default:
					if (controllerType != ControllerType.Custom)
					{
						throw new NotImplementedException();
					}
					return this.GetCustomControllerMapInstance(controllerIdentifier, mapCategoryId, layoutId);
				}
			}

			// Token: 0x06001749 RID: 5961 RVA: 0x0006DEEC File Offset: 0x0006C0EC
			public JoystickMap GetJoystickMapInstance(Joystick joystick, int mapCategoryId, int layoutId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				if (joystick == null)
				{
					return null;
				}
				JoystickMap joystickMap = ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.dCtulAuKluDweDSLBLXTmZcbbpEXA(joystick, mapCategoryId, layoutId);
				if (joystickMap != null)
				{
					joystick.VswFFcfRUHqPtFHydytpQrxVsYK(joystickMap);
				}
				return joystickMap;
			}

			// Token: 0x0600174A RID: 5962 RVA: 0x0006DF20 File Offset: 0x0006C120
			public JoystickMap GetJoystickMapInstance(Joystick joystick, string mapCategoryName, string layoutName)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = this.GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = this.GetLayoutId(ControllerType.Joystick, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return this.GetJoystickMapInstance(joystick, mapCategoryId, layoutId);
			}

			// Token: 0x0600174B RID: 5963 RVA: 0x0006DF5C File Offset: 0x0006C15C
			public JoystickMap GetJoystickMapInstance(Guid joystickTypeGuid, int mapCategoryId, int layoutId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				if (joystickTypeGuid == Guid.Empty)
				{
					return null;
				}
				InputSource inputSourceType = ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA.inputSourceType;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = ReInput.LtnwAoZuGNHrlfpnRahHEdzSRZguA.bYKGjlSTjPdeUuJkJiNnhxSonKVhA(joystickTypeGuid, inputSourceType);
				if (hardwareJoystickMap_InputManager == null)
				{
					Logger.LogError("No hardware map found.");
					return null;
				}
				JoystickMap joystickMap = ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.VsWfhIEJSHPwfybYTNgQATDBittLc(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
				if (joystickMap != null)
				{
					HardwareControllerMap_Game hardwareControllerMap_Game = hardwareJoystickMap_InputManager.ToGameHardwareControllerMap();
					foreach (ActionElementMap actionElementMap in joystickMap.AllMaps)
					{
						actionElementMap.ubBnNGFeqSMOJcQMgXczBUsQMzgN(joystickMap, hardwareControllerMap_Game);
					}
				}
				return joystickMap;
			}

			// Token: 0x0600174C RID: 5964 RVA: 0x0006E00C File Offset: 0x0006C20C
			public JoystickMap GetJoystickMapInstance(Guid joystickTypeGuid, string mapCategoryName, string layoutName)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				if (joystickTypeGuid == Guid.Empty)
				{
					return null;
				}
				int mapCategoryId = this.GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = this.GetLayoutId(ControllerType.Joystick, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return this.GetJoystickMapInstance(joystickTypeGuid, mapCategoryId, layoutId);
			}

			// Token: 0x0600174D RID: 5965 RVA: 0x0006E058 File Offset: 0x0006C258
			public JoystickMap GetJoystickMapInstance(ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				if (controllerIdentifier.controllerType != ControllerType.Joystick)
				{
					return null;
				}
				Joystick joystick = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.GjbnKwfEMhCIAztPvPYKgnLKAipL(controllerIdentifier, false) as Joystick;
				if (joystick != null)
				{
					return this.GetJoystickMapInstance(joystick, mapCategoryId, layoutId);
				}
				return this.GetJoystickMapInstance(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
			}

			// Token: 0x0600174E RID: 5966 RVA: 0x0006E0A8 File Offset: 0x0006C2A8
			public JoystickMap GetJoystickMapInstance(ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = this.GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = this.GetLayoutId(ControllerType.Joystick, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return this.GetJoystickMapInstance(controllerIdentifier, mapCategoryId, layoutId);
			}

			// Token: 0x0600174F RID: 5967 RVA: 0x0006E0E4 File Offset: 0x0006C2E4
			public KeyboardMap GetKeyboardMapInstance(int mapCategoryId, int layoutId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				KeyboardMap keyboardMap = ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.FindKeyboardMap_Game(ReInput.controllers.Keyboard, mapCategoryId, layoutId);
				if (keyboardMap != null)
				{
					ReInput.controllers.Keyboard.VswFFcfRUHqPtFHydytpQrxVsYK(keyboardMap);
				}
				return keyboardMap;
			}

			// Token: 0x06001750 RID: 5968 RVA: 0x0006E128 File Offset: 0x0006C328
			public KeyboardMap GetKeyboardMapInstance(string mapCategoryName, string layoutName)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = this.GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = this.GetLayoutId(ControllerType.Keyboard, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return this.GetKeyboardMapInstance(mapCategoryId, layoutId);
			}

			// Token: 0x06001751 RID: 5969 RVA: 0x0006E164 File Offset: 0x0006C364
			public MouseMap GetMouseMapInstance(int mapCategoryId, int layoutId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				MouseMap mouseMap = ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.FindMouseMap_Game(ReInput.controllers.Mouse, mapCategoryId, layoutId);
				if (mouseMap != null)
				{
					ReInput.controllers.Mouse.VswFFcfRUHqPtFHydytpQrxVsYK(mouseMap);
				}
				return mouseMap;
			}

			// Token: 0x06001752 RID: 5970 RVA: 0x0006E1A8 File Offset: 0x0006C3A8
			public MouseMap GetMouseMapInstance(string mapCategoryName, string layoutName)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = this.GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = this.GetLayoutId(ControllerType.Mouse, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return this.GetMouseMapInstance(mapCategoryId, layoutId);
			}

			// Token: 0x06001753 RID: 5971 RVA: 0x0006E1E4 File Offset: 0x0006C3E4
			public CustomControllerMap GetCustomControllerMapInstance(CustomController customController, int mapCategoryId, int layoutId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				CustomControllerMap customControllerMap = ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GIsOtUvWYIJylyqaDKWRZDnDCgTL(customController.sourceControllerId, mapCategoryId, layoutId);
				if (customControllerMap != null)
				{
					customController.VswFFcfRUHqPtFHydytpQrxVsYK(customControllerMap);
				}
				return customControllerMap;
			}

			// Token: 0x06001754 RID: 5972 RVA: 0x0006E218 File Offset: 0x0006C418
			public CustomControllerMap GetCustomControllerMapInstance(CustomController customController, string mapCategoryName, string layoutName)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = this.GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = this.GetLayoutId(ControllerType.Custom, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return this.GetCustomControllerMapInstance(customController, mapCategoryId, layoutId);
			}

			// Token: 0x06001755 RID: 5973 RVA: 0x0006E258 File Offset: 0x0006C458
			public CustomControllerMap GetCustomControllerMapInstance(ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				if (controllerIdentifier.controllerType != ControllerType.Custom)
				{
					return null;
				}
				CustomController customController = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.GjbnKwfEMhCIAztPvPYKgnLKAipL(controllerIdentifier, false) as CustomController;
				if (customController != null)
				{
					return this.GetCustomControllerMapInstance(customController, mapCategoryId, layoutId);
				}
				if (controllerIdentifier.hardwareTypeGuid == Guid.Empty)
				{
					return null;
				}
				CustomController_Editor customControllerByHardwareTypeGuid = ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
				if (customControllerByHardwareTypeGuid == null)
				{
					return null;
				}
				CustomControllerMap customControllerMap = ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.JufticZIQJGwKdCVMylEvhHUDPYb(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
				if (customControllerMap != null)
				{
					HardwareControllerMap_Game hardwareControllerMap_Game = customControllerByHardwareTypeGuid.CreateGameHardwareMap();
					if (hardwareControllerMap_Game == null)
					{
						Logger.LogError("No hardware map found.");
						return null;
					}
					foreach (ActionElementMap actionElementMap in customControllerMap.AllMaps)
					{
						actionElementMap.ubBnNGFeqSMOJcQMgXczBUsQMzgN(customControllerMap, hardwareControllerMap_Game);
					}
				}
				return customControllerMap;
			}

			// Token: 0x06001756 RID: 5974 RVA: 0x0006E338 File Offset: 0x0006C538
			public CustomControllerMap GetCustomControllerMapInstance(ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = this.GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = this.GetLayoutId(ControllerType.Custom, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return this.GetCustomControllerMapInstance(controllerIdentifier, mapCategoryId, layoutId);
			}

			// Token: 0x06001757 RID: 5975 RVA: 0x0006E378 File Offset: 0x0006C578
			public ControllerMap GetControllerMapInstanceSavedOrDefault(int playerId, Controller controller, int mapCategoryId, int layoutId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				if (controller == null)
				{
					return null;
				}
				ControllerMap controllerMap = null;
				IControllerMapStore controllerMapStore = ReInput.userDataStore as IControllerMapStore;
				if (controllerMapStore != null)
				{
					controllerMap = controllerMapStore.LoadControllerMap(playerId, controller.identifier, mapCategoryId, layoutId);
				}
				if (controllerMap == null)
				{
					controllerMap = ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.orpcuTByDKjWdCWGmwZhSNbviFRtA(controller, mapCategoryId, layoutId);
				}
				if (controllerMap != null)
				{
					Player player = ReInput.players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.XrTRlliMzhKfGEipwrhVgqehkfSw(controller, controllerMap);
					}
					else
					{
						controller.VswFFcfRUHqPtFHydytpQrxVsYK(controllerMap);
					}
				}
				return controllerMap;
			}

			// Token: 0x06001758 RID: 5976 RVA: 0x0006E3F4 File Offset: 0x0006C5F4
			public ControllerMap GetControllerMapInstanceSavedOrDefault(int playerId, Controller controller, string mapCategoryName, string layoutName)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				if (controller == null)
				{
					return null;
				}
				int mapCategoryId = this.GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = this.GetLayoutId(controller.type, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return this.GetControllerMapInstanceSavedOrDefault(playerId, controller, mapCategoryId, layoutId);
			}

			// Token: 0x06001759 RID: 5977 RVA: 0x0006E43C File Offset: 0x0006C63C
			public ControllerMap GetControllerMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				ControllerType controllerType = controllerIdentifier.controllerType;
				switch (controllerType)
				{
				case ControllerType.Keyboard:
					return this.GetKeyboardMapInstanceSavedOrDefault(playerId, mapCategoryId, layoutId);
				case ControllerType.Mouse:
					return this.GetMouseMapInstanceSavedOrDefault(playerId, mapCategoryId, layoutId);
				case ControllerType.Joystick:
					return this.GetJoystickMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId);
				default:
					if (controllerType != ControllerType.Custom)
					{
						throw new NotImplementedException();
					}
					return this.GetCustomControllerMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId);
				}
			}

			// Token: 0x0600175A RID: 5978 RVA: 0x0006E4A8 File Offset: 0x0006C6A8
			public ControllerMap GetControllerMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = this.GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = this.GetLayoutId(controllerIdentifier.controllerType, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return this.GetControllerMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId);
			}

			// Token: 0x0600175B RID: 5979 RVA: 0x00013FFE File Offset: 0x000121FE
			public JoystickMap GetJoystickMapInstanceSavedOrDefault(int playerId, Joystick joystick, int mapCategoryId, int layoutId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return this.GetControllerMapInstanceSavedOrDefault(playerId, joystick, mapCategoryId, layoutId) as JoystickMap;
			}

			// Token: 0x0600175C RID: 5980 RVA: 0x0006E4EC File Offset: 0x0006C6EC
			public JoystickMap GetJoystickMapInstanceSavedOrDefault(int playerId, Joystick joystick, string mapCategoryName, string layoutName)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = this.GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = this.GetLayoutId(ControllerType.Joystick, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return this.GetJoystickMapInstanceSavedOrDefault(playerId, joystick, mapCategoryId, layoutId);
			}

			// Token: 0x0600175D RID: 5981 RVA: 0x0006E52C File Offset: 0x0006C72C
			public JoystickMap GetJoystickMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				Joystick joystick = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.GjbnKwfEMhCIAztPvPYKgnLKAipL(controllerIdentifier, false) as Joystick;
				if (joystick != null)
				{
					return this.GetJoystickMapInstanceSavedOrDefault(playerId, joystick, mapCategoryId, layoutId);
				}
				InputSource inputSourceType = ReInput.nuiZFKxPKWFhKhmsnHjOwuBdhlfvA.inputSourceType;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = ReInput.LtnwAoZuGNHrlfpnRahHEdzSRZguA.bYKGjlSTjPdeUuJkJiNnhxSonKVhA(controllerIdentifier.hardwareTypeGuid, inputSourceType);
				if (hardwareJoystickMap_InputManager == null)
				{
					Logger.LogError("No hardware map found.");
					return null;
				}
				JoystickMap joystickMap = null;
				IControllerMapStore controllerMapStore = ReInput.userDataStore as IControllerMapStore;
				if (controllerMapStore != null)
				{
					joystickMap = (controllerMapStore.LoadControllerMap(playerId, controllerIdentifier, mapCategoryId, layoutId) as JoystickMap);
				}
				if (joystickMap == null)
				{
					joystickMap = ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.VsWfhIEJSHPwfybYTNgQATDBittLc(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
				}
				if (joystickMap != null)
				{
					if (ReInput.players.GetPlayer(playerId) != null)
					{
						joystickMap.playerId = playerId;
					}
					HardwareControllerMap_Game hardwareControllerMap_Game = hardwareJoystickMap_InputManager.ToGameHardwareControllerMap();
					foreach (ActionElementMap actionElementMap in joystickMap.AllMaps)
					{
						actionElementMap.ubBnNGFeqSMOJcQMgXczBUsQMzgN(joystickMap, hardwareControllerMap_Game);
					}
				}
				return joystickMap;
			}

			// Token: 0x0600175E RID: 5982 RVA: 0x0006E630 File Offset: 0x0006C830
			public JoystickMap GetJoystickMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = this.GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = this.GetLayoutId(ControllerType.Joystick, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return this.GetJoystickMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId);
			}

			// Token: 0x0600175F RID: 5983 RVA: 0x00014019 File Offset: 0x00012219
			public CustomControllerMap GetCustomControllerMapInstanceSavedOrDefault(int playerId, CustomController customController, int mapCategoryId, int layoutId)
			{
				return this.GetControllerMapInstanceSavedOrDefault(playerId, customController, mapCategoryId, layoutId) as CustomControllerMap;
			}

			// Token: 0x06001760 RID: 5984 RVA: 0x0006E670 File Offset: 0x0006C870
			public CustomControllerMap GetCustomControllerMapInstanceSavedOrDefault(int playerId, CustomController customController, string mapCategoryName, string layoutName)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = this.GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = this.GetLayoutId(ControllerType.Custom, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return this.GetCustomControllerMapInstanceSavedOrDefault(playerId, customController, mapCategoryId, layoutId);
			}

			// Token: 0x06001761 RID: 5985 RVA: 0x0006E6B0 File Offset: 0x0006C8B0
			public CustomControllerMap GetCustomControllerMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				CustomController customController = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.GjbnKwfEMhCIAztPvPYKgnLKAipL(controllerIdentifier, false) as CustomController;
				if (customController != null)
				{
					return this.GetCustomControllerMapInstanceSavedOrDefault(playerId, customController, mapCategoryId, layoutId);
				}
				CustomController_Editor customControllerByHardwareTypeGuid = ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
				if (customControllerByHardwareTypeGuid == null)
				{
					return null;
				}
				CustomControllerMap customControllerMap = null;
				IControllerMapStore controllerMapStore = ReInput.userDataStore as IControllerMapStore;
				if (controllerMapStore != null)
				{
					customControllerMap = (controllerMapStore.LoadControllerMap(playerId, controllerIdentifier, mapCategoryId, layoutId) as CustomControllerMap);
				}
				if (customControllerMap == null)
				{
					customControllerMap = ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.JufticZIQJGwKdCVMylEvhHUDPYb(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
				}
				if (customControllerMap != null)
				{
					HardwareControllerMap_Game hardwareControllerMap_Game = customControllerByHardwareTypeGuid.CreateGameHardwareMap();
					if (hardwareControllerMap_Game == null)
					{
						Logger.LogError("No hardware map found.");
						return null;
					}
					if (ReInput.players.GetPlayer(playerId) != null)
					{
						customControllerMap.playerId = playerId;
					}
					foreach (ActionElementMap actionElementMap in customControllerMap.AllMaps)
					{
						actionElementMap.ubBnNGFeqSMOJcQMgXczBUsQMzgN(customControllerMap, hardwareControllerMap_Game);
					}
				}
				return customControllerMap;
			}

			// Token: 0x06001762 RID: 5986 RVA: 0x0006E7AC File Offset: 0x0006C9AC
			public CustomControllerMap GetCustomControllerMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = this.GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = this.GetLayoutId(ControllerType.Custom, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return this.GetCustomControllerMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId);
			}

			// Token: 0x06001763 RID: 5987 RVA: 0x0006E7EC File Offset: 0x0006C9EC
			public KeyboardMap GetKeyboardMapInstanceSavedOrDefault(int playerId, int mapCategoryId, int layoutId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				Controller keyboard = ReInput.controllers.Keyboard;
				KeyboardMap keyboardMap = null;
				IControllerMapStore controllerMapStore = ReInput.userDataStore as IControllerMapStore;
				if (controllerMapStore != null)
				{
					keyboardMap = (controllerMapStore.LoadControllerMap(playerId, keyboard.identifier, mapCategoryId, layoutId) as KeyboardMap);
				}
				if (keyboardMap == null)
				{
					keyboardMap = ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.FindKeyboardMap_Game(ReInput.controllers.Keyboard, mapCategoryId, layoutId);
				}
				if (keyboardMap != null)
				{
					Player player = ReInput.players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.XrTRlliMzhKfGEipwrhVgqehkfSw(keyboard, keyboardMap);
					}
					else
					{
						keyboard.VswFFcfRUHqPtFHydytpQrxVsYK(keyboardMap);
					}
				}
				return keyboardMap;
			}

			// Token: 0x06001764 RID: 5988 RVA: 0x0006E87C File Offset: 0x0006CA7C
			public KeyboardMap GetKeyboardMapInstanceSavedOrDefault(int playerId, string mapCategoryName, string layoutName)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = this.GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = this.GetLayoutId(ControllerType.Keyboard, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return this.GetKeyboardMapInstanceSavedOrDefault(playerId, mapCategoryId, layoutId);
			}

			// Token: 0x06001765 RID: 5989 RVA: 0x0006E8B8 File Offset: 0x0006CAB8
			public MouseMap GetMouseMapInstanceSavedOrDefault(int playerId, int mapCategoryId, int layoutId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				Controller mouse = ReInput.controllers.Mouse;
				MouseMap mouseMap = null;
				IControllerMapStore controllerMapStore = ReInput.userDataStore as IControllerMapStore;
				if (controllerMapStore != null)
				{
					mouseMap = (controllerMapStore.LoadControllerMap(playerId, mouse.identifier, mapCategoryId, layoutId) as MouseMap);
				}
				if (mouseMap == null)
				{
					mouseMap = ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.FindMouseMap_Game(ReInput.controllers.Mouse, mapCategoryId, layoutId);
				}
				if (mouseMap != null)
				{
					Player player = ReInput.players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.XrTRlliMzhKfGEipwrhVgqehkfSw(mouse, mouseMap);
					}
					else
					{
						mouse.VswFFcfRUHqPtFHydytpQrxVsYK(mouseMap);
					}
				}
				return mouseMap;
			}

			// Token: 0x06001766 RID: 5990 RVA: 0x0006E948 File Offset: 0x0006CB48
			public MouseMap GetMouseMapInstanceSavedOrDefault(int playerId, string mapCategoryName, string layoutName)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = this.GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = this.GetLayoutId(ControllerType.Mouse, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return this.GetMouseMapInstanceSavedOrDefault(playerId, mapCategoryId, layoutId);
			}

			// Token: 0x06001767 RID: 5991 RVA: 0x0001402B File Offset: 0x0001222B
			[Obsolete("This method has been deprecated. Use the Controller Template system instead.", false)]
			public ControllerElementIdentifier GetFirstJoystickTemplateElementIdentifier(Joystick joystick, int joystickElementIdentifierId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				if (joystick == null)
				{
					return null;
				}
				return this.wUuRQbsIhnLBhSKhtuscaBlWxvIM(joystick.hardwareTypeGuid, joystickElementIdentifierId);
			}

			// Token: 0x06001768 RID: 5992 RVA: 0x0006E984 File Offset: 0x0006CB84
			private ControllerElementIdentifier wUuRQbsIhnLBhSKhtuscaBlWxvIM(Guid A_1, int A_2)
			{
				HardwareJoystickMap hardwareControllerMap;
				ControllerTemplateElementIdentifier controllerTemplateElementIdentifier = ReInput.LtnwAoZuGNHrlfpnRahHEdzSRZguA.pIiOPUSGnzaTfxuhQrhQfIoMHfEDA(A_1, A_2, out hardwareControllerMap);
				if (controllerTemplateElementIdentifier != null)
				{
					return controllerTemplateElementIdentifier.ToControllerElementIdentifier(hardwareControllerMap);
				}
				return null;
			}

			// Token: 0x06001769 RID: 5993 RVA: 0x00014048 File Offset: 0x00012248
			internal int OuotgntRrVAFpOsdsfOdexABAWGj(Guid A_1, Guid A_2, int A_3, List<HardwareControllerTemplateMap.vNUinRqnjfTkAskqXltQLMfPUMUv> A_4)
			{
				return ReInput.LtnwAoZuGNHrlfpnRahHEdzSRZguA.dRcvyAFHPsqCinGETODjfDxvMOPp(A_1, A_2, A_3, A_4);
			}

			// Token: 0x0600176A RID: 5994 RVA: 0x00014059 File Offset: 0x00012259
			public ControllerTemplateMap GetControllerTemplateMapInstance(Guid templateTypeGuid, int mapCategoryId, int layoutId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.PYBtkAKavdubFJuTfiYoFHIiPNpM(templateTypeGuid, mapCategoryId, layoutId);
			}

			// Token: 0x0600176B RID: 5995 RVA: 0x0006E9AC File Offset: 0x0006CBAC
			public ControllerTemplateMap GetControllerTemplateMapInstance(Guid templateTypeGuid, string mapCategoryName, string layoutName)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = this.GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = this.GetLayoutId(ControllerType.Custom, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return this.GetControllerTemplateMapInstance(templateTypeGuid, mapCategoryId, layoutId);
			}

			// Token: 0x0600176C RID: 5996 RVA: 0x0006E9EC File Offset: 0x0006CBEC
			public ControllerMapLayoutManager.RuleSet GetControllerMapLayoutManagerRuleSetInstance(int id)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManagerRuleSetById = ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetControllerMapLayoutManagerRuleSetById(id);
				if (controllerMapLayoutManagerRuleSetById == null)
				{
					return null;
				}
				return controllerMapLayoutManagerRuleSetById.ToRuntime();
			}

			// Token: 0x0600176D RID: 5997 RVA: 0x0006EA1C File Offset: 0x0006CC1C
			public ControllerMapLayoutManager.RuleSet GetControllerMapLayoutManagerRuleSetInstance(string name)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				int controllerMapLayoutManagerRuleSetId = ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetControllerMapLayoutManagerRuleSetId(name);
				if (controllerMapLayoutManagerRuleSetId < 0)
				{
					return null;
				}
				return this.GetControllerMapLayoutManagerRuleSetInstance(controllerMapLayoutManagerRuleSetId);
			}

			// Token: 0x0600176E RID: 5998 RVA: 0x0006EA4C File Offset: 0x0006CC4C
			public ControllerMapEnabler.RuleSet GetControllerMapEnablerRuleSetInstance(int id)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				ControllerMapEnabler_RuleSet_Editor controllerMapEnablerRuleSetById = ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetControllerMapEnablerRuleSetById(id);
				if (controllerMapEnablerRuleSetById == null)
				{
					return null;
				}
				return controllerMapEnablerRuleSetById.ToRuntime();
			}

			// Token: 0x0600176F RID: 5999 RVA: 0x0006EA7C File Offset: 0x0006CC7C
			public ControllerMapEnabler.RuleSet GetControllerMapEnablerRuleSetInstance(string name)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				int controllerMapEnablerRuleSetId = ReInput.ybQGfQSHOeALSXVGSAhZJuxEoBieb.GetControllerMapEnablerRuleSetId(name);
				if (controllerMapEnablerRuleSetId < 0)
				{
					return null;
				}
				return this.GetControllerMapEnablerRuleSetInstance(controllerMapEnablerRuleSetId);
			}

			// Token: 0x04000CE9 RID: 3305
			private static ReInput.MappingHelper ZfqTOtxpSXTFoIaCOiPevzncTWrr;
		}

		// Token: 0x020001C6 RID: 454
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class PlayerHelper : CodeHelper
		{
			// Token: 0x17000587 RID: 1415
			// (get) Token: 0x06001770 RID: 6000 RVA: 0x00014071 File Offset: 0x00012271
			internal static ReInput.PlayerHelper jXLSWTzGLhuXyrdrWcCAkXagQezDA
			{
				get
				{
					ReInput.PlayerHelper result;
					if ((result = ReInput.PlayerHelper.fZyklhLmJDJHdOToMXgvWFcCVdjF) == null)
					{
						result = (ReInput.PlayerHelper.fZyklhLmJDJHdOToMXgvWFcCVdjF = new ReInput.PlayerHelper());
					}
					return result;
				}
			}

			// Token: 0x06001771 RID: 6001 RVA: 0x00012058 File Offset: 0x00010258
			private PlayerHelper()
			{
			}

			// Token: 0x17000588 RID: 1416
			// (get) Token: 0x06001772 RID: 6002 RVA: 0x00014087 File Offset: 0x00012287
			public int playerCount
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return 0;
					}
					return ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.JZZMSdwQmzZLUZnhPHsPBtaOBmXm;
				}
			}

			// Token: 0x17000589 RID: 1417
			// (get) Token: 0x06001773 RID: 6003 RVA: 0x0001409C File Offset: 0x0001229C
			public int allPlayerCount
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return 0;
					}
					return ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.dqdghehbZcEXgcaPeDgBkdlIrogAd;
				}
			}

			// Token: 0x1700058A RID: 1418
			// (get) Token: 0x06001774 RID: 6004 RVA: 0x000140B1 File Offset: 0x000122B1
			public IList<Player> Players
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return EmptyObjects<Player>.EmptyReadOnlyIListT;
					}
					return ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
				}
			}

			// Token: 0x1700058B RID: 1419
			// (get) Token: 0x06001775 RID: 6005 RVA: 0x000140CA File Offset: 0x000122CA
			public IList<Player> AllPlayers
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return EmptyObjects<Player>.EmptyReadOnlyIListT;
					}
					return ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc;
				}
			}

			// Token: 0x1700058C RID: 1420
			// (get) Token: 0x06001776 RID: 6006 RVA: 0x000140E3 File Offset: 0x000122E3
			public Player SystemPlayer
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return null;
					}
					return ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CrofyrlIxqANhJbwPluHBcmsknBDA();
				}
			}

			// Token: 0x06001777 RID: 6007 RVA: 0x000140F8 File Offset: 0x000122F8
			public IList<Player> GetPlayers(bool includeSystemPlayer = false)
			{
				if (!ReInput.CheckInitialized())
				{
					return EmptyObjects<Player>.EmptyReadOnlyIListT;
				}
				if (!includeSystemPlayer)
				{
					return ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.rjzgupHwXIugYhKuZNNJGVDiXRWq;
				}
				return ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CutceaYHAGyESiiqFclOPlqrWKfc;
			}

			// Token: 0x06001778 RID: 6008 RVA: 0x0001411F File Offset: 0x0001231F
			public Player GetPlayer(int playerId)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.VtObDEzKPQDiJEMzgQRElYBEdxnC(playerId);
			}

			// Token: 0x06001779 RID: 6009 RVA: 0x00014135 File Offset: 0x00012335
			public Player GetPlayer(string name)
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.lRETGPFimkLNbkfSorwbdoMJsGyy(name);
			}

			// Token: 0x0600177A RID: 6010 RVA: 0x000140E3 File Offset: 0x000122E3
			public Player GetSystemPlayer()
			{
				if (!ReInput.CheckInitialized())
				{
					return null;
				}
				return ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.CrofyrlIxqANhJbwPluHBcmsknBDA();
			}

			// Token: 0x0600177B RID: 6011 RVA: 0x0001414B File Offset: 0x0001234B
			public int GetPlayerId(string playerName)
			{
				if (!ReInput.CheckInitialized())
				{
					return -1;
				}
				return ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.KXOOhBhWyaHEcTacjEIxgvFMxWUIA(playerName);
			}

			// Token: 0x0600177C RID: 6012 RVA: 0x00014161 File Offset: 0x00012361
			public string[] GetPlayerNames(bool includeSystemPlayer = false)
			{
				if (!ReInput.CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.ULWFuGgyUhfvuPexOLaZJTMXwgDR(includeSystemPlayer);
			}

			// Token: 0x0600177D RID: 6013 RVA: 0x0001417B File Offset: 0x0001237B
			public string[] GetPlayerDescriptiveNames(bool includeSystemPlayer = false)
			{
				if (!ReInput.CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.hVMWidhRlDUKCvWmiNWFthbpqmRQ(includeSystemPlayer);
			}

			// Token: 0x0600177E RID: 6014 RVA: 0x00014195 File Offset: 0x00012395
			public int[] GetPlayerIds(bool includeSystemPlayer = false)
			{
				if (!ReInput.CheckInitialized())
				{
					return EmptyObjects<int>.array;
				}
				return ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.DYxdsTjKBypkMwzFTuqBNpYAhDsyA(includeSystemPlayer);
			}

			// Token: 0x04000CEA RID: 3306
			private static ReInput.PlayerHelper fZyklhLmJDJHdOToMXgvWFcCVdjF;
		}

		// Token: 0x020001C7 RID: 455
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class TimeHelper : CodeHelper
		{
			// Token: 0x1700058D RID: 1421
			// (get) Token: 0x0600177F RID: 6015 RVA: 0x000141AF File Offset: 0x000123AF
			internal static ReInput.TimeHelper iWVfgACIvTBUdUThmFyVCAaKfeqUb
			{
				get
				{
					ReInput.TimeHelper result;
					if ((result = ReInput.TimeHelper.MffRenvUVjSjfjLQUFVSJPcWaERdA) == null)
					{
						result = (ReInput.TimeHelper.MffRenvUVjSjfjLQUFVSJPcWaERdA = new ReInput.TimeHelper());
					}
					return result;
				}
			}

			// Token: 0x06001780 RID: 6016 RVA: 0x00012058 File Offset: 0x00010258
			private TimeHelper()
			{
			}

			// Token: 0x1700058E RID: 1422
			// (get) Token: 0x06001781 RID: 6017 RVA: 0x000141C5 File Offset: 0x000123C5
			public float unscaledDeltaTime
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return 0f;
					}
					return (float)ReInput.vJBNxHpsKaeldWfiVmEFIJhTbUdaA.IxLfNCdKZMDqMctakXSYXpIghoJoA;
				}
			}

			// Token: 0x1700058F RID: 1423
			// (get) Token: 0x06001782 RID: 6018 RVA: 0x000141DF File Offset: 0x000123DF
			public double unscaledTime
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return 0.0;
					}
					return ReInput.vJBNxHpsKaeldWfiVmEFIJhTbUdaA.HuKEmfARZQoVZkghzKFoewxAtSMBA;
				}
			}

			// Token: 0x17000590 RID: 1424
			// (get) Token: 0x06001783 RID: 6019 RVA: 0x000141FC File Offset: 0x000123FC
			public uint currentFrame
			{
				get
				{
					if (!ReInput.CheckInitialized())
					{
						return 0U;
					}
					return ReInput.vJBNxHpsKaeldWfiVmEFIJhTbUdaA.EpBepseWVFSXgZPMPjciGnZBARgyA;
				}
			}

			// Token: 0x04000CEB RID: 3307
			private static ReInput.TimeHelper MffRenvUVjSjfjLQUFVSJPcWaERdA;
		}

		// Token: 0x020001C8 RID: 456
		private class HfBpVCHKLggxhOZyzpKLDTEIVkEv
		{
			// Token: 0x17000591 RID: 1425
			// (get) Token: 0x06001784 RID: 6020 RVA: 0x00014211 File Offset: 0x00012411
			public double HuKEmfARZQoVZkghzKFoewxAtSMBA
			{
				get
				{
					return this.REACXfhjOsgAsJLfYvVlRHYYZmal.ArfyPVfHIfAQHtQbPDKOkBltYSih;
				}
			}

			// Token: 0x17000592 RID: 1426
			// (get) Token: 0x06001785 RID: 6021 RVA: 0x0001421E File Offset: 0x0001241E
			public double VAaXzDcWQcMcmmSNzVghHgyOGJZV
			{
				get
				{
					return this.REACXfhjOsgAsJLfYvVlRHYYZmal.MoJfcllOAuveDPTEQMhvxMqCrbLM;
				}
			}

			// Token: 0x17000593 RID: 1427
			// (get) Token: 0x06001786 RID: 6022 RVA: 0x0001422B File Offset: 0x0001242B
			public double IxLfNCdKZMDqMctakXSYXpIghoJoA
			{
				get
				{
					return this.REACXfhjOsgAsJLfYvVlRHYYZmal.pNOhPkOEJVFxgETQooeOTRWqnKht;
				}
			}

			// Token: 0x17000594 RID: 1428
			// (get) Token: 0x06001787 RID: 6023 RVA: 0x00014238 File Offset: 0x00012438
			public float RwkTlKGligCMggvQuDLrLKflyolt
			{
				get
				{
					return this.REACXfhjOsgAsJLfYvVlRHYYZmal.kdgbcpgCYfzDEFpUPnbACyuPHeasA;
				}
			}

			// Token: 0x17000595 RID: 1429
			// (get) Token: 0x06001788 RID: 6024 RVA: 0x00014245 File Offset: 0x00012445
			public float SNQtjGGmzOrvQqJtUecPeaeZWsQoA
			{
				get
				{
					return this.REACXfhjOsgAsJLfYvVlRHYYZmal.YitaHhlwvOCTfIrfslGfEINaxxqcA;
				}
			}

			// Token: 0x17000596 RID: 1430
			// (get) Token: 0x06001789 RID: 6025 RVA: 0x00014252 File Offset: 0x00012452
			internal double VJlDoOpeEHAdgWbCyIlkcpJIpgOy
			{
				get
				{
					return this.PHRvbSoCezngLKVXpLuCzSEQuZaS.elapsedSeconds + this.nAzoxNqMwepfHTusfseUKBxHAXpGA;
				}
			}

			// Token: 0x17000597 RID: 1431
			// (get) Token: 0x0600178A RID: 6026 RVA: 0x00014266 File Offset: 0x00012466
			public uint EpBepseWVFSXgZPMPjciGnZBARgyA
			{
				get
				{
					return this.REACXfhjOsgAsJLfYvVlRHYYZmal.AkeyODhZpyfaAJiPKrKlnEHpTnTK;
				}
			}

			// Token: 0x17000598 RID: 1432
			// (get) Token: 0x0600178B RID: 6027 RVA: 0x00014273 File Offset: 0x00012473
			public uint IImLTINUdLYElazFupDqzsSSEWJF
			{
				get
				{
					return this.REACXfhjOsgAsJLfYvVlRHYYZmal.oVhNOmTaaYAjIKaeqeUUZLrYgXzT;
				}
			}

			// Token: 0x17000599 RID: 1433
			// (get) Token: 0x0600178C RID: 6028 RVA: 0x00014280 File Offset: 0x00012480
			public uint syfVciXZmYtrtWGfiMQkBolPsmIq
			{
				get
				{
					return this.WkUcxyBrEAzXAJWJBkHhjLutbBctA;
				}
			}

			// Token: 0x0600178D RID: 6029 RVA: 0x00014288 File Offset: 0x00012488
			public HfBpVCHKLggxhOZyzpKLDTEIVkEv()
			{
				this.PHRvbSoCezngLKVXpLuCzSEQuZaS = ReInput.HfBpVCHKLggxhOZyzpKLDTEIVkEv.nvXCUQCDsxagVHPABdztQqIOItpnc.bqNvyuMybbnsBrdXirgtLXGjxosB;
				this.hkYCrBIcCQfyrzVWUbikCRJCWylgb();
			}

			// Token: 0x0600178E RID: 6030 RVA: 0x000142A1 File Offset: 0x000124A1
			public void ycOVuRXlpIqefQIexjoTAwZPjfvT()
			{
				this.nAzoxNqMwepfHTusfseUKBxHAXpGA = (double)Time.realtimeSinceStartup;
			}

			// Token: 0x0600178F RID: 6031 RVA: 0x0006EAAC File Offset: 0x0006CCAC
			public void hkYCrBIcCQfyrzVWUbikCRJCWylgb()
			{
				this.REACXfhjOsgAsJLfYvVlRHYYZmal = null;
				this.mxJnCfHdTxGWZuUyWibxsfzkcDNEA = new ADictionary<int, ReInput.HfBpVCHKLggxhOZyzpKLDTEIVkEv.GfWfWXYQmvCoGDSojwBzrOWTwLQJ>();
				using (TempListPool.TList<UpdateLoopType> tlist = TempListPool.GetTList<UpdateLoopType>(3))
				{
					List<UpdateLoopType> list = tlist.list;
					EnumConverter.ToUpdateLoopTypes((UpdateLoopSetting)(-1), list);
					for (int i = 0; i < list.Count; i++)
					{
						ReInput.HfBpVCHKLggxhOZyzpKLDTEIVkEv.GfWfWXYQmvCoGDSojwBzrOWTwLQJ gfWfWXYQmvCoGDSojwBzrOWTwLQJ = new ReInput.HfBpVCHKLggxhOZyzpKLDTEIVkEv.GfWfWXYQmvCoGDSojwBzrOWTwLQJ(list[i]);
						this.mxJnCfHdTxGWZuUyWibxsfzkcDNEA.Add((int)list[i], gfWfWXYQmvCoGDSojwBzrOWTwLQJ);
						if (this.REACXfhjOsgAsJLfYvVlRHYYZmal == null)
						{
							this.REACXfhjOsgAsJLfYvVlRHYYZmal = gfWfWXYQmvCoGDSojwBzrOWTwLQJ;
						}
					}
				}
			}

			// Token: 0x06001790 RID: 6032 RVA: 0x0006EB40 File Offset: 0x0006CD40
			public void bofmiForSQAXifqLAKxnzfIBdHGLA(UpdateLoopType A_1)
			{
				if (this.REACXfhjOsgAsJLfYvVlRHYYZmal.HRldxqFEXtaCroNqxIHCVcgqnaDJ != A_1)
				{
					this.REACXfhjOsgAsJLfYvVlRHYYZmal = this.mxJnCfHdTxGWZuUyWibxsfzkcDNEA[(int)A_1];
				}
				if (A_1 == UpdateLoopType.OnGUI && Event.current.rawType != EventType.Layout)
				{
					return;
				}
				this.REACXfhjOsgAsJLfYvVlRHYYZmal.gFeYldRAXRgRLxDLWctoVAXrGcRDA();
				this.WkUcxyBrEAzXAJWJBkHhjLutbBctA = MiscTools.Tick(this.WkUcxyBrEAzXAJWJBkHhjLutbBctA);
				ReInput.absFrame = this.WkUcxyBrEAzXAJWJBkHhjLutbBctA;
			}

			// Token: 0x04000CEC RID: 3308
			private StopwatchBase PHRvbSoCezngLKVXpLuCzSEQuZaS;

			// Token: 0x04000CED RID: 3309
			private double nAzoxNqMwepfHTusfseUKBxHAXpGA;

			// Token: 0x04000CEE RID: 3310
			private ReInput.HfBpVCHKLggxhOZyzpKLDTEIVkEv.GfWfWXYQmvCoGDSojwBzrOWTwLQJ REACXfhjOsgAsJLfYvVlRHYYZmal;

			// Token: 0x04000CEF RID: 3311
			private ADictionary<int, ReInput.HfBpVCHKLggxhOZyzpKLDTEIVkEv.GfWfWXYQmvCoGDSojwBzrOWTwLQJ> mxJnCfHdTxGWZuUyWibxsfzkcDNEA;

			// Token: 0x04000CF0 RID: 3312
			private uint WkUcxyBrEAzXAJWJBkHhjLutbBctA;

			// Token: 0x020001C9 RID: 457
			private class GfWfWXYQmvCoGDSojwBzrOWTwLQJ
			{
				// Token: 0x1700059A RID: 1434
				// (get) Token: 0x06001791 RID: 6033 RVA: 0x000142AF File Offset: 0x000124AF
				public double ArfyPVfHIfAQHtQbPDKOkBltYSih
				{
					get
					{
						return this.SbcfMgJxrlYRgZvyyKXJEtHYBlvM;
					}
				}

				// Token: 0x1700059B RID: 1435
				// (get) Token: 0x06001792 RID: 6034 RVA: 0x000142B7 File Offset: 0x000124B7
				public double MoJfcllOAuveDPTEQMhvxMqCrbLM
				{
					get
					{
						return this.UAifgyOjGnAlojgaaCiAoGpDCReU;
					}
				}

				// Token: 0x1700059C RID: 1436
				// (get) Token: 0x06001793 RID: 6035 RVA: 0x000142BF File Offset: 0x000124BF
				public double pNOhPkOEJVFxgETQooeOTRWqnKht
				{
					get
					{
						return this.FjEgvnVcnCbOkRvRfhfjJlbpZWAN;
					}
				}

				// Token: 0x1700059D RID: 1437
				// (get) Token: 0x06001794 RID: 6036 RVA: 0x000142C7 File Offset: 0x000124C7
				public uint AkeyODhZpyfaAJiPKrKlnEHpTnTK
				{
					get
					{
						return this.CvJsPmSbnfyWXbZGZgELUagwGEOA;
					}
				}

				// Token: 0x1700059E RID: 1438
				// (get) Token: 0x06001795 RID: 6037 RVA: 0x000142CF File Offset: 0x000124CF
				public uint oVhNOmTaaYAjIKaeqeUUZLrYgXzT
				{
					get
					{
						return this.fbAZoJiIWZaVIOovQbgbkETJulSW;
					}
				}

				// Token: 0x1700059F RID: 1439
				// (get) Token: 0x06001796 RID: 6038 RVA: 0x000142D7 File Offset: 0x000124D7
				public float kdgbcpgCYfzDEFpUPnbACyuPHeasA
				{
					get
					{
						return this.svCnYdzVVxDiZXEWqRTZFElOhJFm;
					}
				}

				// Token: 0x170005A0 RID: 1440
				// (get) Token: 0x06001797 RID: 6039 RVA: 0x000142DF File Offset: 0x000124DF
				public float YitaHhlwvOCTfIrfslGfEINaxxqcA
				{
					get
					{
						return this.thrOgGyBgPFBIKDqrtmqtgljIBgL;
					}
				}

				// Token: 0x06001798 RID: 6040 RVA: 0x000142E7 File Offset: 0x000124E7
				public GfWfWXYQmvCoGDSojwBzrOWTwLQJ(UpdateLoopType A_1)
				{
					this.HRldxqFEXtaCroNqxIHCVcgqnaDJ = A_1;
					this.SmhLKNLkHzoUUupWRXpBRzHpOBjT = (double)Time.realtimeSinceStartup;
					this.CvJsPmSbnfyWXbZGZgELUagwGEOA = 0U;
				}

				// Token: 0x06001799 RID: 6041 RVA: 0x0006EBA8 File Offset: 0x0006CDA8
				public void gFeYldRAXRgRLxDLWctoVAXrGcRDA()
				{
					this.UAifgyOjGnAlojgaaCiAoGpDCReU = this.SbcfMgJxrlYRgZvyyKXJEtHYBlvM;
					this.SbcfMgJxrlYRgZvyyKXJEtHYBlvM = ReInput.realTime;
					if (this.SmhLKNLkHzoUUupWRXpBRzHpOBjT > this.SbcfMgJxrlYRgZvyyKXJEtHYBlvM)
					{
						this.SmhLKNLkHzoUUupWRXpBRzHpOBjT = 0.0;
					}
					this.FjEgvnVcnCbOkRvRfhfjJlbpZWAN = this.SbcfMgJxrlYRgZvyyKXJEtHYBlvM - this.SmhLKNLkHzoUUupWRXpBRzHpOBjT;
					this.SmhLKNLkHzoUUupWRXpBRzHpOBjT = this.SbcfMgJxrlYRgZvyyKXJEtHYBlvM;
					this.fbAZoJiIWZaVIOovQbgbkETJulSW = this.CvJsPmSbnfyWXbZGZgELUagwGEOA;
					this.CvJsPmSbnfyWXbZGZgELUagwGEOA = MiscTools.Tick(this.CvJsPmSbnfyWXbZGZgELUagwGEOA);
					this.thrOgGyBgPFBIKDqrtmqtgljIBgL = this.svCnYdzVVxDiZXEWqRTZFElOhJFm;
					this.svCnYdzVVxDiZXEWqRTZFElOhJFm = ReInput.kYZJtBVYMOMsclMCCcBfbCCUfZJXA();
					ReInput.previousFrame = this.fbAZoJiIWZaVIOovQbgbkETJulSW;
					ReInput.currentFrame = this.CvJsPmSbnfyWXbZGZgELUagwGEOA;
					ReInput.unscaledTime = this.SbcfMgJxrlYRgZvyyKXJEtHYBlvM;
					ReInput.unscaledTimePrev = this.UAifgyOjGnAlojgaaCiAoGpDCReU;
					ReInput.unscaledDeltaTime = this.FjEgvnVcnCbOkRvRfhfjJlbpZWAN;
				}

				// Token: 0x04000CF1 RID: 3313
				public readonly UpdateLoopType HRldxqFEXtaCroNqxIHCVcgqnaDJ;

				// Token: 0x04000CF2 RID: 3314
				private double SbcfMgJxrlYRgZvyyKXJEtHYBlvM;

				// Token: 0x04000CF3 RID: 3315
				private double UAifgyOjGnAlojgaaCiAoGpDCReU;

				// Token: 0x04000CF4 RID: 3316
				private double FjEgvnVcnCbOkRvRfhfjJlbpZWAN;

				// Token: 0x04000CF5 RID: 3317
				private double SmhLKNLkHzoUUupWRXpBRzHpOBjT;

				// Token: 0x04000CF6 RID: 3318
				private uint CvJsPmSbnfyWXbZGZgELUagwGEOA;

				// Token: 0x04000CF7 RID: 3319
				private uint fbAZoJiIWZaVIOovQbgbkETJulSW;

				// Token: 0x04000CF8 RID: 3320
				private float svCnYdzVVxDiZXEWqRTZFElOhJFm;

				// Token: 0x04000CF9 RID: 3321
				private float thrOgGyBgPFBIKDqrtmqtgljIBgL;
			}

			// Token: 0x020001CA RID: 458
			private static class nvXCUQCDsxagVHPABdztQqIOItpnc
			{
				// Token: 0x170005A1 RID: 1441
				// (get) Token: 0x0600179A RID: 6042 RVA: 0x00014309 File Offset: 0x00012509
				public static StopwatchBase bqNvyuMybbnsBrdXirgtLXGjxosB
				{
					get
					{
						if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
						{
							return UnityStopwatch.Global;
						}
						return Stopwatch.Global;
					}
				}

				// Token: 0x0600179B RID: 6043 RVA: 0x00014326 File Offset: 0x00012526
				public static StopwatchBase egwgbmvKPBbghLmXqMpornwculy()
				{
					if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
					{
						return new UnityStopwatch();
					}
					return new Stopwatch();
				}

				// Token: 0x0600179C RID: 6044 RVA: 0x00014343 File Offset: 0x00012543
				public static StopwatchBase bsZEXlrcWDyHRiEavHLRDWMwZERHA()
				{
					if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
					{
						return UnityStopwatch.StartNew();
					}
					return Stopwatch.StartNew();
				}
			}
		}

		// Token: 0x020001CB RID: 459
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class UnityTouch : CodeHelper
		{
			// Token: 0x170005A2 RID: 1442
			// (get) Token: 0x0600179D RID: 6045 RVA: 0x00014360 File Offset: 0x00012560
			internal static ReInput.UnityTouch NNleDJGyuMaXIAwKhzRwvsipSKWjb
			{
				get
				{
					ReInput.UnityTouch result;
					if ((result = ReInput.UnityTouch.luGRqneLqNGIWoDHiGZFBHSfZoic) == null)
					{
						result = (ReInput.UnityTouch.luGRqneLqNGIWoDHiGZFBHSfZoic = new ReInput.UnityTouch());
					}
					return result;
				}
			}

			// Token: 0x0600179E RID: 6046 RVA: 0x00012058 File Offset: 0x00010258
			private UnityTouch()
			{
			}

			// Token: 0x170005A3 RID: 1443
			// (get) Token: 0x0600179F RID: 6047 RVA: 0x00014376 File Offset: 0x00012576
			public int touchCount
			{
				get
				{
					return Input.touchCount;
				}
			}

			// Token: 0x170005A4 RID: 1444
			// (get) Token: 0x060017A0 RID: 6048 RVA: 0x0001437D File Offset: 0x0001257D
			public Touch[] touches
			{
				get
				{
					return Input.touches;
				}
			}

			// Token: 0x170005A5 RID: 1445
			// (get) Token: 0x060017A1 RID: 6049 RVA: 0x00014384 File Offset: 0x00012584
			// (set) Token: 0x060017A2 RID: 6050 RVA: 0x0001438B File Offset: 0x0001258B
			public bool simulateMouseWithTouches
			{
				get
				{
					return Input.simulateMouseWithTouches;
				}
				set
				{
					Input.simulateMouseWithTouches = value;
				}
			}

			// Token: 0x170005A6 RID: 1446
			// (get) Token: 0x060017A3 RID: 6051 RVA: 0x00014393 File Offset: 0x00012593
			// (set) Token: 0x060017A4 RID: 6052 RVA: 0x0001439A File Offset: 0x0001259A
			public bool multiTouchEnabled
			{
				get
				{
					return Input.multiTouchEnabled;
				}
				set
				{
					Input.multiTouchEnabled = value;
				}
			}

			// Token: 0x060017A5 RID: 6053 RVA: 0x000143A2 File Offset: 0x000125A2
			public Touch GetTouch(int index)
			{
				return Input.GetTouch(index);
			}

			// Token: 0x04000CFA RID: 3322
			private static ReInput.UnityTouch luGRqneLqNGIWoDHiGZFBHSfZoic;
		}

		// Token: 0x020001CC RID: 460
		internal class sgWGAtCXhoXotFcNElUxqsMZoVwI
		{
			// Token: 0x170005A7 RID: 1447
			// (get) Token: 0x060017A6 RID: 6054 RVA: 0x000143AA File Offset: 0x000125AA
			public int NQMLPuTdRROwdPJttQMneqPXRDPx
			{
				get
				{
					return this.qmBKdstolEHlfIaRYAWNDJbHlRmKB;
				}
			}

			// Token: 0x060017A7 RID: 6055 RVA: 0x0006EC74 File Offset: 0x0006CE74
			public sgWGAtCXhoXotFcNElUxqsMZoVwI()
			{
				bool flag = UnityTools.isEditor || Application.isFocused;
				List<ValueWatcher> list = new List<ValueWatcher>();
				list.Add(this.rutBILBASpvjbeYJDZwPjebprXZE = new ValueWatcher<bool>(flag, false));
				list.Add(this.vTNPtZUVycarxkTOqGBONWkQuALF = new ValueWatcher<bool>(false, false));
				list.Add(this.XMNvTburyIayJJDEFBSXnOZvwCCR = new ValueWatcher<bool>(Screen.fullScreen, new Func<bool>(ReInput.sgWGAtCXhoXotFcNElUxqsMZoVwI.bVKfFfgQkTdzaFAzvXdIAOjwmiURA.<>9.tSVCpLuRDfeQXTZQLOTLvnPJOQAF), false));
				list.Add(this.rvKQZFRPikQMpTaHPHQxcySywmJC = new ValueWatcher<bool>(Application.runInBackground, new Func<bool>(ReInput.sgWGAtCXhoXotFcNElUxqsMZoVwI.bVKfFfgQkTdzaFAzvXdIAOjwmiURA.<>9.MlwAlCGRAjKSuAAuCMsYnVowBiOCB), false));
				list.Add(this.zxMyfjLPdWwzBTXGaTCHwkcVloKu = new ValueWatcher<int>((int)Screen.fullScreenMode, new Func<int>(ReInput.sgWGAtCXhoXotFcNElUxqsMZoVwI.bVKfFfgQkTdzaFAzvXdIAOjwmiURA.<>9.peuShaqnCGrpnGuukxKgmdCZqSlA), false));
				list.Add(this.OOxSVUylnEuKCUKdDAfvdTkvRofcA = new ValueWatcher<float>(Time.unscaledDeltaTime, new Func<float>(ReInput.sgWGAtCXhoXotFcNElUxqsMZoVwI.bVKfFfgQkTdzaFAzvXdIAOjwmiURA.<>9.vNDpRiizldMbWhHYAFrwUFHuaUTk), false));
				list.Add(this.LbTqjNISjELbhtYROrjuJOavnZue = new ValueWatcher<bool>(MathTools.ApproximatelyZero(Time.timeScale), new Func<bool>(ReInput.sgWGAtCXhoXotFcNElUxqsMZoVwI.bVKfFfgQkTdzaFAzvXdIAOjwmiURA.<>9.koMOrhPkYggwjKesOKlWDVGhKcJy), MathTools.ApproximatelyZero(Time.timeScale)));
				List<ValueWatcher> list2 = list;
				if (ReInput.editorPlatform != EditorPlatform.None)
				{
					list2.Add(this.GecIUVAmgQPOFjYTdiCzxTvdfgAoA = new ValueWatcher<string>(UnityTools.externalTools.GetFocusedEditorWindowTitle(), new Func<string>(ReInput.sgWGAtCXhoXotFcNElUxqsMZoVwI.bVKfFfgQkTdzaFAzvXdIAOjwmiURA.<>9.ZVOuuNTlTPMFDQhyQCaCDbBcDhHQA), false));
				}
				this.FbGcFkNdMcblgammXXqplOkOvHih = list2.ToArray();
				this.lKLobxykkevAQKAIZRbvvsgUIncD();
			}

			// Token: 0x060017A8 RID: 6056 RVA: 0x0006EE50 File Offset: 0x0006D050
			public void lKLobxykkevAQKAIZRbvvsgUIncD()
			{
				for (int i = 0; i < this.FbGcFkNdMcblgammXXqplOkOvHih.Length; i++)
				{
					this.FbGcFkNdMcblgammXXqplOkOvHih[i].Update();
				}
				this.qmBKdstolEHlfIaRYAWNDJbHlRmKB = Time.frameCount;
			}

			// Token: 0x060017A9 RID: 6057 RVA: 0x0006EE8C File Offset: 0x0006D08C
			public void WrUceRNcWSFecHUojEtXGlKvcjqXA()
			{
				for (int i = 0; i < this.FbGcFkNdMcblgammXXqplOkOvHih.Length; i++)
				{
					this.FbGcFkNdMcblgammXXqplOkOvHih[i].TriggerEvent();
				}
			}

			// Token: 0x04000CFB RID: 3323
			public readonly ValueWatcher<bool> rutBILBASpvjbeYJDZwPjebprXZE;

			// Token: 0x04000CFC RID: 3324
			public readonly ValueWatcher<bool> vTNPtZUVycarxkTOqGBONWkQuALF;

			// Token: 0x04000CFD RID: 3325
			public readonly ValueWatcher<bool> XMNvTburyIayJJDEFBSXnOZvwCCR;

			// Token: 0x04000CFE RID: 3326
			public readonly ValueWatcher<bool> rvKQZFRPikQMpTaHPHQxcySywmJC;

			// Token: 0x04000CFF RID: 3327
			public readonly ValueWatcher<int> zxMyfjLPdWwzBTXGaTCHwkcVloKu;

			// Token: 0x04000D00 RID: 3328
			public readonly ValueWatcher<float> OOxSVUylnEuKCUKdDAfvdTkvRofcA;

			// Token: 0x04000D01 RID: 3329
			public readonly ValueWatcher<string> GecIUVAmgQPOFjYTdiCzxTvdfgAoA;

			// Token: 0x04000D02 RID: 3330
			public readonly ValueWatcher<bool> LbTqjNISjELbhtYROrjuJOavnZue;

			// Token: 0x04000D03 RID: 3331
			private int qmBKdstolEHlfIaRYAWNDJbHlRmKB;

			// Token: 0x04000D04 RID: 3332
			private readonly ValueWatcher[] FbGcFkNdMcblgammXXqplOkOvHih;

			// Token: 0x020001CD RID: 461
			[CompilerGenerated]
			[Serializable]
			private sealed class bVKfFfgQkTdzaFAzvXdIAOjwmiURA
			{
				// Token: 0x060017AC RID: 6060 RVA: 0x000143BE File Offset: 0x000125BE
				internal bool tSVCpLuRDfeQXTZQLOTLvnPJOQAF()
				{
					return Screen.fullScreen;
				}

				// Token: 0x060017AD RID: 6061 RVA: 0x000143C5 File Offset: 0x000125C5
				internal bool MlwAlCGRAjKSuAAuCMsYnVowBiOCB()
				{
					return Application.runInBackground;
				}

				// Token: 0x060017AE RID: 6062 RVA: 0x000143CC File Offset: 0x000125CC
				internal int peuShaqnCGrpnGuukxKgmdCZqSlA()
				{
					return (int)Screen.fullScreenMode;
				}

				// Token: 0x060017AF RID: 6063 RVA: 0x000143D3 File Offset: 0x000125D3
				internal float vNDpRiizldMbWhHYAFrwUFHuaUTk()
				{
					return Time.unscaledDeltaTime;
				}

				// Token: 0x060017B0 RID: 6064 RVA: 0x000143DA File Offset: 0x000125DA
				internal bool koMOrhPkYggwjKesOKlWDVGhKcJy()
				{
					return MathTools.ApproximatelyZero(Time.timeScale);
				}

				// Token: 0x060017B1 RID: 6065 RVA: 0x000143E6 File Offset: 0x000125E6
				internal string ZVOuuNTlTPMFDQhyQCaCDbBcDhHQA()
				{
					return UnityTools.externalTools.GetFocusedEditorWindowTitle();
				}

				// Token: 0x04000D05 RID: 3333
				public static readonly ReInput.sgWGAtCXhoXotFcNElUxqsMZoVwI.bVKfFfgQkTdzaFAzvXdIAOjwmiURA <>9 = new ReInput.sgWGAtCXhoXotFcNElUxqsMZoVwI.bVKfFfgQkTdzaFAzvXdIAOjwmiURA();

				// Token: 0x04000D06 RID: 3334
				public static Func<bool> <>9__12_1;

				// Token: 0x04000D07 RID: 3335
				public static Func<bool> <>9__12_2;

				// Token: 0x04000D08 RID: 3336
				public static Func<int> <>9__12_3;

				// Token: 0x04000D09 RID: 3337
				public static Func<float> <>9__12_4;

				// Token: 0x04000D0A RID: 3338
				public static Func<bool> <>9__12_5;

				// Token: 0x04000D0B RID: 3339
				public static Func<string> <>9__12_0;
			}
		}

		// Token: 0x020001CE RID: 462
		[CompilerGenerated]
		[Serializable]
		private sealed class UiIeThpXEYmSxJzvHrkDCWwYfiuq
		{
			// Token: 0x060017B4 RID: 6068 RVA: 0x000143FE File Offset: 0x000125FE
			internal void afAasMQfiCGiRvGPtDrDmbIdLXTQ(Exception A_1)
			{
				ReInput.HandleCallbackException("", A_1);
			}

			// Token: 0x060017B5 RID: 6069 RVA: 0x0001440B File Offset: 0x0001260B
			internal void csniZEXEDVbRIbMUbWGLfajajmrP(Exception A_1)
			{
				ReInput.HandleCallbackException("Rewired.ReInput.ControllerConnectedEvent", A_1);
			}

			// Token: 0x060017B6 RID: 6070 RVA: 0x00014418 File Offset: 0x00012618
			internal void FqHDGPjkRZeWFPKTDHFMXvUvjbUb(Exception A_1)
			{
				ReInput.HandleCallbackException("Rewired.ReInput.ControllerPreDisconnectEvent", A_1);
			}

			// Token: 0x060017B7 RID: 6071 RVA: 0x00014425 File Offset: 0x00012625
			internal void zWtcbPlrXTBZQCTMMvPOCcnATZks(Exception A_1)
			{
				ReInput.HandleCallbackException("Rewired.ReInput.ControllerDisconnectedEvent", A_1);
			}

			// Token: 0x060017B8 RID: 6072 RVA: 0x00014432 File Offset: 0x00012632
			internal void EyFSxPjqpbabUxCecbiwEJysWtTx(Exception A_1)
			{
				ReInput.HandleCallbackException("Rewired.ReInput.InputSourceUpdateEvent", A_1);
			}

			// Token: 0x060017B9 RID: 6073 RVA: 0x0001443F File Offset: 0x0001263F
			internal void yOpvGEvBnwOKiFlhPGYtBEPkrGvZ(Exception A_1)
			{
				ReInput.HandleCallbackException("Rewired.ReInput.EditorRecompileEvent", A_1);
			}

			// Token: 0x060017BA RID: 6074 RVA: 0x0001444C File Offset: 0x0001264C
			internal void PrIJKEGLsqREWqYdtEagxbIiNKVy(Exception A_1)
			{
				ReInput.HandleCallbackException("Rewired.ReInput.PreShutDownEvent", A_1);
			}

			// Token: 0x060017BB RID: 6075 RVA: 0x00014459 File Offset: 0x00012659
			internal void HORgxMuqPZvjcpJtkvHfABjCZEkf(Exception A_1)
			{
				ReInput.HandleCallbackException("Rewired.ReInput.ShutDownEvent", A_1);
			}

			// Token: 0x060017BC RID: 6076 RVA: 0x00014466 File Offset: 0x00012666
			internal void fjbsYiCBVvOSFXgjetMDcewcSkxp(Exception A_1)
			{
				ReInput.HandleCallbackException("Rewired.ReInput.InitializedEvent", A_1);
			}

			// Token: 0x060017BD RID: 6077 RVA: 0x00014473 File Offset: 0x00012673
			internal bool aTMiYFQOALWWAumxAdhQXAMazjIc()
			{
				return ReInput.isUnityEditorFocused && ReInput.isAllowedEditorWindowFocused;
			}

			// Token: 0x04000D0C RID: 3340
			public static readonly ReInput.UiIeThpXEYmSxJzvHrkDCWwYfiuq <>9 = new ReInput.UiIeThpXEYmSxJzvHrkDCWwYfiuq();

			// Token: 0x04000D0D RID: 3341
			public static Func<bool> <>9__235_0;
		}
	}
}
