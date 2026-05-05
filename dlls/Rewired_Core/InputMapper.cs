using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	// Token: 0x0200014D RID: 333
	public sealed class InputMapper
	{
		// Token: 0x17000421 RID: 1057
		// (get) Token: 0x06000E6D RID: 3693 RVA: 0x0000D503 File Offset: 0x0000B703
		public static InputMapper Default
		{
			get
			{
				InputMapper result;
				if ((result = InputMapper.bDKywpaFBOHyTZuZPIaNUBKgFVtT) == null)
				{
					result = (InputMapper.bDKywpaFBOHyTZuZPIaNUBKgFVtT = new InputMapper(true));
				}
				return result;
			}
		}

		// Token: 0x06000E6E RID: 3694 RVA: 0x0000D51A File Offset: 0x0000B71A
		private static int yJONjqDhKjKOtfuLESCJkPRnacOq()
		{
			int hfAoDBlpHBJghBbIGidDiYxqZMyeA = InputMapper.HfAoDBlpHBJghBbIGidDiYxqZMyeA;
			if (InputMapper.HfAoDBlpHBJghBbIGidDiYxqZMyeA == 2147483647)
			{
				InputMapper.HfAoDBlpHBJghBbIGidDiYxqZMyeA = 0;
				return hfAoDBlpHBJghBbIGidDiYxqZMyeA;
			}
			InputMapper.HfAoDBlpHBJghBbIGidDiYxqZMyeA++;
			return hfAoDBlpHBJghBbIGidDiYxqZMyeA;
		}

		// Token: 0x17000422 RID: 1058
		// (get) Token: 0x06000E6F RID: 3695 RVA: 0x00052F20 File Offset: 0x00051120
		// (set) Token: 0x06000E70 RID: 3696 RVA: 0x0000D540 File Offset: 0x0000B740
		public InputMapper.Options options
		{
			get
			{
				InputMapper.Options result;
				if ((result = this.QeWsoglZPwbrqILPZcTmDCnfyxrGA) == null)
				{
					if (!this.oxtHFMPYtOkOMMjoQGilKBAtGFOib)
					{
						return this.QeWsoglZPwbrqILPZcTmDCnfyxrGA = InputMapper.Default.options.Clone();
					}
					result = (this.QeWsoglZPwbrqILPZcTmDCnfyxrGA = new InputMapper.Options());
				}
				return result;
			}
			set
			{
				this.QeWsoglZPwbrqILPZcTmDCnfyxrGA = value;
			}
		}

		// Token: 0x17000423 RID: 1059
		// (get) Token: 0x06000E71 RID: 3697 RVA: 0x0000D549 File Offset: 0x0000B749
		public InputMapper.Context mappingContext
		{
			get
			{
				return this.WLfBJnKYYgSBBWwjyivNzoBkYLkg.xCAiNDrJZHjCHsSsUSMbJeFpfWVy;
			}
		}

		// Token: 0x17000424 RID: 1060
		// (get) Token: 0x06000E72 RID: 3698 RVA: 0x0000D556 File Offset: 0x0000B756
		public InputMapper.Status status
		{
			get
			{
				return this.WLfBJnKYYgSBBWwjyivNzoBkYLkg.BCYjOqRvsopDTdCInAfqiFCrReXD;
			}
		}

		// Token: 0x17000425 RID: 1061
		// (get) Token: 0x06000E73 RID: 3699 RVA: 0x0000D563 File Offset: 0x0000B763
		public float timeRemaining
		{
			get
			{
				return this.WLfBJnKYYgSBBWwjyivNzoBkYLkg.KvGdKccQlfiEfbPVvHURuIexYCbpA;
			}
		}

		// Token: 0x17000426 RID: 1062
		// (get) Token: 0x06000E74 RID: 3700 RVA: 0x0000D570 File Offset: 0x0000B770
		internal int ZgpAZOgTcrxtvSARIaBvGAwMSBgZ
		{
			get
			{
				return this.yEDXcfFcdkCmZEQihFSFWxfGgQMbb;
			}
		}

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x06000E75 RID: 3701 RVA: 0x00052F68 File Offset: 0x00051168
		// (remove) Token: 0x06000E76 RID: 3702 RVA: 0x00052FA0 File Offset: 0x000511A0
		public event Action<InputMapper.InputMappedEventData> InputMappedEvent
		{
			add
			{
				if (value == null)
				{
					return;
				}
				InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb key = InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.InputMapped;
				this.pSatvzmYVJDaYqnRHfjuJWntcrfFA[key] = (SafeAction<InputMapper.InputMappedEventData>)this.pSatvzmYVJDaYqnRHfjuJWntcrfFA[key] + value;
			}
			remove
			{
				if (value == null)
				{
					return;
				}
				InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb key = InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.InputMapped;
				this.pSatvzmYVJDaYqnRHfjuJWntcrfFA[key] = (SafeAction<InputMapper.InputMappedEventData>)this.pSatvzmYVJDaYqnRHfjuJWntcrfFA[key] - value;
			}
		}

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x06000E77 RID: 3703 RVA: 0x00052FD8 File Offset: 0x000511D8
		// (remove) Token: 0x06000E78 RID: 3704 RVA: 0x00053010 File Offset: 0x00051210
		public event Action<InputMapper.ErrorEventData> ErrorEvent
		{
			add
			{
				if (value == null)
				{
					return;
				}
				InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb key = InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.Error;
				this.pSatvzmYVJDaYqnRHfjuJWntcrfFA[key] = (SafeAction<InputMapper.ErrorEventData>)this.pSatvzmYVJDaYqnRHfjuJWntcrfFA[key] + value;
			}
			remove
			{
				if (value == null)
				{
					return;
				}
				InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb key = InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.Error;
				this.pSatvzmYVJDaYqnRHfjuJWntcrfFA[key] = (SafeAction<InputMapper.ErrorEventData>)this.pSatvzmYVJDaYqnRHfjuJWntcrfFA[key] - value;
			}
		}

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x06000E79 RID: 3705 RVA: 0x00053048 File Offset: 0x00051248
		// (remove) Token: 0x06000E7A RID: 3706 RVA: 0x00053080 File Offset: 0x00051280
		public event Action<InputMapper.CanceledEventData> CanceledEvent
		{
			add
			{
				if (value == null)
				{
					return;
				}
				InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb key = InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.Canceled;
				this.pSatvzmYVJDaYqnRHfjuJWntcrfFA[key] = (SafeAction<InputMapper.CanceledEventData>)this.pSatvzmYVJDaYqnRHfjuJWntcrfFA[key] + value;
			}
			remove
			{
				if (value == null)
				{
					return;
				}
				InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb key = InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.Canceled;
				this.pSatvzmYVJDaYqnRHfjuJWntcrfFA[key] = (SafeAction<InputMapper.CanceledEventData>)this.pSatvzmYVJDaYqnRHfjuJWntcrfFA[key] - value;
			}
		}

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x06000E7B RID: 3707 RVA: 0x000530B8 File Offset: 0x000512B8
		// (remove) Token: 0x06000E7C RID: 3708 RVA: 0x000530F0 File Offset: 0x000512F0
		public event Action<InputMapper.TimedOutEventData> TimedOutEvent
		{
			add
			{
				if (value == null)
				{
					return;
				}
				InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb key = InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.TimedOut;
				this.pSatvzmYVJDaYqnRHfjuJWntcrfFA[key] = (SafeAction<InputMapper.TimedOutEventData>)this.pSatvzmYVJDaYqnRHfjuJWntcrfFA[key] + value;
			}
			remove
			{
				if (value == null)
				{
					return;
				}
				InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb key = InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.TimedOut;
				this.pSatvzmYVJDaYqnRHfjuJWntcrfFA[key] = (SafeAction<InputMapper.TimedOutEventData>)this.pSatvzmYVJDaYqnRHfjuJWntcrfFA[key] - value;
			}
		}

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x06000E7D RID: 3709 RVA: 0x00053128 File Offset: 0x00051328
		// (remove) Token: 0x06000E7E RID: 3710 RVA: 0x00053160 File Offset: 0x00051360
		public event Action<InputMapper.StartedEventData> StartedEvent
		{
			add
			{
				if (value == null)
				{
					return;
				}
				InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb key = InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.Started;
				this.pSatvzmYVJDaYqnRHfjuJWntcrfFA[key] = (SafeAction<InputMapper.StartedEventData>)this.pSatvzmYVJDaYqnRHfjuJWntcrfFA[key] + value;
			}
			remove
			{
				if (value == null)
				{
					return;
				}
				InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb key = InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.Started;
				this.pSatvzmYVJDaYqnRHfjuJWntcrfFA[key] = (SafeAction<InputMapper.StartedEventData>)this.pSatvzmYVJDaYqnRHfjuJWntcrfFA[key] - value;
			}
		}

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x06000E7F RID: 3711 RVA: 0x00053198 File Offset: 0x00051398
		// (remove) Token: 0x06000E80 RID: 3712 RVA: 0x000531D0 File Offset: 0x000513D0
		public event Action<InputMapper.StoppedEventData> StoppedEvent
		{
			add
			{
				if (value == null)
				{
					return;
				}
				InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb key = InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.Stopped;
				this.pSatvzmYVJDaYqnRHfjuJWntcrfFA[key] = (SafeAction<InputMapper.StoppedEventData>)this.pSatvzmYVJDaYqnRHfjuJWntcrfFA[key] + value;
			}
			remove
			{
				if (value == null)
				{
					return;
				}
				InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb key = InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.Stopped;
				this.pSatvzmYVJDaYqnRHfjuJWntcrfFA[key] = (SafeAction<InputMapper.StoppedEventData>)this.pSatvzmYVJDaYqnRHfjuJWntcrfFA[key] - value;
			}
		}

		// Token: 0x14000019 RID: 25
		// (add) Token: 0x06000E81 RID: 3713 RVA: 0x00053208 File Offset: 0x00051408
		// (remove) Token: 0x06000E82 RID: 3714 RVA: 0x00053240 File Offset: 0x00051440
		public event Action<InputMapper.ConflictFoundEventData> ConflictFoundEvent
		{
			add
			{
				if (value == null)
				{
					return;
				}
				InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb key = InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.ConflictsFound;
				this.pSatvzmYVJDaYqnRHfjuJWntcrfFA[key] = (SafeAction<InputMapper.ConflictFoundEventData>)this.pSatvzmYVJDaYqnRHfjuJWntcrfFA[key] + value;
			}
			remove
			{
				if (value == null)
				{
					return;
				}
				InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb key = InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.ConflictsFound;
				this.pSatvzmYVJDaYqnRHfjuJWntcrfFA[key] = (SafeAction<InputMapper.ConflictFoundEventData>)this.pSatvzmYVJDaYqnRHfjuJWntcrfFA[key] - value;
			}
		}

		// Token: 0x06000E83 RID: 3715 RVA: 0x0000D578 File Offset: 0x0000B778
		public InputMapper() : this(false)
		{
			this.yEDXcfFcdkCmZEQihFSFWxfGgQMbb = InputMapper.yJONjqDhKjKOtfuLESCJkPRnacOq();
		}

		// Token: 0x06000E84 RID: 3716 RVA: 0x00053278 File Offset: 0x00051478
		private InputMapper(bool A_1)
		{
			Dictionary<InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb, SafeDelegate> dictionary = new Dictionary<InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb, SafeDelegate>();
			dictionary.Add(InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.InputMapped, new SafeAction<InputMapper.InputMappedEventData>(new Action<Exception>(InputMapper.uyCPGFpLAKdtFtHEjpgAvZDQrpTU.<>9.UFGKKZLBRhpcpAEasfXkioDxaOir)));
			dictionary.Add(InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.Error, new SafeAction<InputMapper.ErrorEventData>(new Action<Exception>(InputMapper.uyCPGFpLAKdtFtHEjpgAvZDQrpTU.<>9.reSJALRKkFBRUkqMgxSdETELUinn)));
			dictionary.Add(InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.Canceled, new SafeAction<InputMapper.CanceledEventData>(new Action<Exception>(InputMapper.uyCPGFpLAKdtFtHEjpgAvZDQrpTU.<>9.XwPCxkdhyzAnFrXeOBeacvcCTQcTA)));
			dictionary.Add(InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.TimedOut, new SafeAction<InputMapper.TimedOutEventData>(new Action<Exception>(InputMapper.uyCPGFpLAKdtFtHEjpgAvZDQrpTU.<>9.uGNSOEThrElCxhOkjhLGpahxNenm)));
			dictionary.Add(InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.Started, new SafeAction<InputMapper.StartedEventData>(new Action<Exception>(InputMapper.uyCPGFpLAKdtFtHEjpgAvZDQrpTU.<>9.MtiATGSYjHlpiysYiMWfrACZxzaN)));
			dictionary.Add(InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.Stopped, new SafeAction<InputMapper.StoppedEventData>(new Action<Exception>(InputMapper.uyCPGFpLAKdtFtHEjpgAvZDQrpTU.<>9.PDtAMmfVqvYqMjFpeyfKoStcnwuUA)));
			dictionary.Add(InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.ConflictsFound, new SafeAction<InputMapper.ConflictFoundEventData>(new Action<Exception>(InputMapper.uyCPGFpLAKdtFtHEjpgAvZDQrpTU.<>9.sRvhxtdDEMtcWlXXxKYuaXtSfwAU)));
			this.pSatvzmYVJDaYqnRHfjuJWntcrfFA = dictionary;
			base..ctor();
			this.oxtHFMPYtOkOMMjoQGilKBAtGFOib = A_1;
			if (this.oxtHFMPYtOkOMMjoQGilKBAtGFOib)
			{
				this.QeWsoglZPwbrqILPZcTmDCnfyxrGA = new InputMapper.Options();
			}
			this.WLfBJnKYYgSBBWwjyivNzoBkYLkg = new InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB(this, this.pSatvzmYVJDaYqnRHfjuJWntcrfFA);
		}

		// Token: 0x06000E85 RID: 3717 RVA: 0x000533F0 File Offset: 0x000515F0
		public void RemoveEventListeners(object listenerOrParent)
		{
			if (listenerOrParent == null)
			{
				return;
			}
			foreach (KeyValuePair<InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb, SafeDelegate> keyValuePair in this.pSatvzmYVJDaYqnRHfjuJWntcrfFA)
			{
				keyValuePair.Value.RemoveDelegateOrAllDelegatesFromAnObject(listenerOrParent);
			}
		}

		// Token: 0x06000E86 RID: 3718 RVA: 0x00053450 File Offset: 0x00051650
		public void RemoveAllEventListeners()
		{
			foreach (KeyValuePair<InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb, SafeDelegate> keyValuePair in this.pSatvzmYVJDaYqnRHfjuJWntcrfFA)
			{
				keyValuePair.Value.Clear();
			}
		}

		// Token: 0x06000E87 RID: 3719 RVA: 0x0000D58C File Offset: 0x0000B78C
		internal void nMmzQiTFlzRHhjnfBorobLZmMMsk(object A_1)
		{
		}

		// Token: 0x06000E88 RID: 3720 RVA: 0x00002FF9 File Offset: 0x000011F9
		internal void cXTwZJRMphKlUTPFPeBwBFpjxXhm()
		{
		}

		// Token: 0x06000E89 RID: 3721 RVA: 0x0000D590 File Offset: 0x0000B790
		public bool Start(InputMapper.Context mappingContext)
		{
			return this.QBxGEJCASMjGijdmAsavhyTVytlfA(mappingContext, (this.QeWsoglZPwbrqILPZcTmDCnfyxrGA != null) ? this.QeWsoglZPwbrqILPZcTmDCnfyxrGA : InputMapper.Default.options);
		}

		// Token: 0x06000E8A RID: 3722 RVA: 0x0000D5B3 File Offset: 0x0000B7B3
		public void Stop()
		{
			this.WLfBJnKYYgSBBWwjyivNzoBkYLkg.IBHaSfuVZMsJsgxnSSKfHSgqFqve("User canceled.");
		}

		// Token: 0x06000E8B RID: 3723 RVA: 0x0000D5C5 File Offset: 0x0000B7C5
		public void Clear()
		{
			this.Stop();
			this.RemoveAllEventListeners();
			this.cXTwZJRMphKlUTPFPeBwBFpjxXhm();
			this.QeWsoglZPwbrqILPZcTmDCnfyxrGA = null;
		}

		// Token: 0x06000E8C RID: 3724 RVA: 0x000534A8 File Offset: 0x000516A8
		private bool QBxGEJCASMjGijdmAsavhyTVytlfA(InputMapper.Context A_1, InputMapper.Options A_2)
		{
			if (!ReInput.isReady)
			{
				return false;
			}
			if (A_1 == null)
			{
				Logger.LogError("The Context cannot be null.");
				return false;
			}
			if (A_1.controllerMap == null)
			{
				Logger.LogError("The Controller Map cannot be null.");
				return false;
			}
			if (A_1.actionElementMapToReplace != null && !A_1.controllerMap.ContainsElementMap(A_1.actionElementMapToReplace))
			{
				Logger.LogError("The Action Element Map must belong to the same Controller Map you are passing in.");
				return false;
			}
			bool result;
			try
			{
				this.WLfBJnKYYgSBBWwjyivNzoBkYLkg.tSLIgozvKhclRqqzCRncRnczanXl(A_1, A_2);
				result = true;
			}
			catch
			{
				this.WLfBJnKYYgSBBWwjyivNzoBkYLkg.IBHaSfuVZMsJsgxnSSKfHSgqFqve("Failed to start due to an exception.");
				result = false;
			}
			return result;
		}

		// Token: 0x040008DD RID: 2269
		private static InputMapper bDKywpaFBOHyTZuZPIaNUBKgFVtT;

		// Token: 0x040008DE RID: 2270
		private static int HfAoDBlpHBJghBbIGidDiYxqZMyeA;

		// Token: 0x040008DF RID: 2271
		private readonly int yEDXcfFcdkCmZEQihFSFWxfGgQMbb;

		// Token: 0x040008E0 RID: 2272
		private readonly bool oxtHFMPYtOkOMMjoQGilKBAtGFOib;

		// Token: 0x040008E1 RID: 2273
		private readonly InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB WLfBJnKYYgSBBWwjyivNzoBkYLkg;

		// Token: 0x040008E2 RID: 2274
		private InputMapper.Options QeWsoglZPwbrqILPZcTmDCnfyxrGA;

		// Token: 0x040008E3 RID: 2275
		private readonly Dictionary<InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb, SafeDelegate> pSatvzmYVJDaYqnRHfjuJWntcrfFA;

		// Token: 0x0200014E RID: 334
		public class Context
		{
			// Token: 0x17000427 RID: 1063
			// (get) Token: 0x06000E8D RID: 3725 RVA: 0x0000D5E0 File Offset: 0x0000B7E0
			// (set) Token: 0x06000E8E RID: 3726 RVA: 0x0000D5E8 File Offset: 0x0000B7E8
			public int actionId
			{
				get
				{
					return this.hhAAQmhwIYDgLCONbGxhZbyQlzzLc;
				}
				set
				{
					if (this.RxQRyVerKAMYkuLkLgSYRVuUhYfe())
					{
						return;
					}
					this.hhAAQmhwIYDgLCONbGxhZbyQlzzLc = value;
				}
			}

			// Token: 0x17000428 RID: 1064
			// (get) Token: 0x06000E8F RID: 3727 RVA: 0x00053540 File Offset: 0x00051740
			// (set) Token: 0x06000E90 RID: 3728 RVA: 0x00053570 File Offset: 0x00051770
			public string actionName
			{
				get
				{
					InputAction action = ReInput.mapping.GetAction(this.hhAAQmhwIYDgLCONbGxhZbyQlzzLc);
					if (action == null)
					{
						return string.Empty;
					}
					return action.name;
				}
				set
				{
					if (this.RxQRyVerKAMYkuLkLgSYRVuUhYfe())
					{
						return;
					}
					InputAction action = ReInput.mapping.GetAction(value);
					if (action == null)
					{
						this.hhAAQmhwIYDgLCONbGxhZbyQlzzLc = -1;
						Logger.LogError("The Action \"" + value + "\" is not a valid Action and cannot be used!");
						return;
					}
					this.hhAAQmhwIYDgLCONbGxhZbyQlzzLc = action.id;
				}
			}

			// Token: 0x17000429 RID: 1065
			// (get) Token: 0x06000E91 RID: 3729 RVA: 0x0000D5FA File Offset: 0x0000B7FA
			// (set) Token: 0x06000E92 RID: 3730 RVA: 0x0000D602 File Offset: 0x0000B802
			public ControllerMap controllerMap
			{
				get
				{
					return this.SUnJCgYZdmAgsAIyFcVXymuwMUGK;
				}
				set
				{
					if (this.RxQRyVerKAMYkuLkLgSYRVuUhYfe())
					{
						return;
					}
					this.SUnJCgYZdmAgsAIyFcVXymuwMUGK = value;
				}
			}

			// Token: 0x1700042A RID: 1066
			// (get) Token: 0x06000E93 RID: 3731 RVA: 0x0000D614 File Offset: 0x0000B814
			// (set) Token: 0x06000E94 RID: 3732 RVA: 0x0000D61C File Offset: 0x0000B81C
			public ActionElementMap actionElementMapToReplace
			{
				get
				{
					return this.YfkgDpdidbHkTfGHhvkOjhIhenJvB;
				}
				set
				{
					if (this.RxQRyVerKAMYkuLkLgSYRVuUhYfe())
					{
						return;
					}
					this.YfkgDpdidbHkTfGHhvkOjhIhenJvB = value;
				}
			}

			// Token: 0x1700042B RID: 1067
			// (get) Token: 0x06000E95 RID: 3733 RVA: 0x0000D62E File Offset: 0x0000B82E
			// (set) Token: 0x06000E96 RID: 3734 RVA: 0x0000D636 File Offset: 0x0000B836
			public AxisRange actionRange
			{
				get
				{
					return this.ADhlwykwlolKMDXfBKBRbexCljzl;
				}
				set
				{
					if (this.RxQRyVerKAMYkuLkLgSYRVuUhYfe())
					{
						return;
					}
					this.ADhlwykwlolKMDXfBKBRbexCljzl = value;
				}
			}

			// Token: 0x06000E97 RID: 3735 RVA: 0x0000D648 File Offset: 0x0000B848
			public Context()
			{
			}

			// Token: 0x06000E98 RID: 3736 RVA: 0x0000D65E File Offset: 0x0000B85E
			private Context(InputMapper.Context A_1) : this()
			{
				if (A_1 == null)
				{
					throw new ArgumentNullException("source");
				}
				InputMapper.Context.Copy(A_1, this);
			}

			// Token: 0x06000E99 RID: 3737 RVA: 0x0000D67B File Offset: 0x0000B87B
			public InputMapper.Context Clone()
			{
				return new InputMapper.Context(this);
			}

			// Token: 0x06000E9A RID: 3738 RVA: 0x0000D683 File Offset: 0x0000B883
			internal void dxOehzluRHRHnFUEopeNQWvykAUd()
			{
				this.HOUyPbVZNlvWMOOiwojnsMwPetTP = true;
			}

			// Token: 0x06000E9B RID: 3739 RVA: 0x0000D68C File Offset: 0x0000B88C
			private bool RxQRyVerKAMYkuLkLgSYRVuUhYfe()
			{
				if (this.HOUyPbVZNlvWMOOiwojnsMwPetTP)
				{
					Logger.LogError("Context is read-only and cannot be modified after Input Mapper has been started.");
					return true;
				}
				return false;
			}

			// Token: 0x06000E9C RID: 3740 RVA: 0x000535C0 File Offset: 0x000517C0
			public static void Copy(InputMapper.Context source, InputMapper.Context destination)
			{
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				if (destination == null)
				{
					throw new ArgumentNullException("destination");
				}
				destination.hhAAQmhwIYDgLCONbGxhZbyQlzzLc = source.hhAAQmhwIYDgLCONbGxhZbyQlzzLc;
				destination.SUnJCgYZdmAgsAIyFcVXymuwMUGK = source.SUnJCgYZdmAgsAIyFcVXymuwMUGK;
				destination.YfkgDpdidbHkTfGHhvkOjhIhenJvB = source.YfkgDpdidbHkTfGHhvkOjhIhenJvB;
				destination.ADhlwykwlolKMDXfBKBRbexCljzl = source.ADhlwykwlolKMDXfBKBRbexCljzl;
			}

			// Token: 0x040008E4 RID: 2276
			private int hhAAQmhwIYDgLCONbGxhZbyQlzzLc = -1;

			// Token: 0x040008E5 RID: 2277
			private ControllerMap SUnJCgYZdmAgsAIyFcVXymuwMUGK;

			// Token: 0x040008E6 RID: 2278
			private ActionElementMap YfkgDpdidbHkTfGHhvkOjhIhenJvB;

			// Token: 0x040008E7 RID: 2279
			private AxisRange ADhlwykwlolKMDXfBKBRbexCljzl = AxisRange.Positive;

			// Token: 0x040008E8 RID: 2280
			private bool HOUyPbVZNlvWMOOiwojnsMwPetTP;
		}

		// Token: 0x0200014F RID: 335
		public enum ConflictResponse
		{
			// Token: 0x040008EA RID: 2282
			Cancel,
			// Token: 0x040008EB RID: 2283
			Replace,
			// Token: 0x040008EC RID: 2284
			Add,
			// Token: 0x040008ED RID: 2285
			Ignore,
			// Token: 0x040008EE RID: 2286
			Swap
		}

		// Token: 0x02000150 RID: 336
		public abstract class EventData
		{
			// Token: 0x06000E9D RID: 3741 RVA: 0x0000D6A3 File Offset: 0x0000B8A3
			internal EventData(InputMapper A_1)
			{
				this.inputMapper = A_1;
			}

			// Token: 0x040008EF RID: 2287
			public readonly InputMapper inputMapper;
		}

		// Token: 0x02000151 RID: 337
		public class InputMappedEventData : InputMapper.EventData
		{
			// Token: 0x06000E9E RID: 3742 RVA: 0x0000D6B2 File Offset: 0x0000B8B2
			internal InputMappedEventData(InputMapper A_1, ActionElementMap A_2) : base(A_1)
			{
				this.actionElementMap = A_2;
			}

			// Token: 0x040008F0 RID: 2288
			public readonly ActionElementMap actionElementMap;
		}

		// Token: 0x02000152 RID: 338
		public class CanceledEventData : InputMapper.EventData
		{
			// Token: 0x06000E9F RID: 3743 RVA: 0x0000D6C2 File Offset: 0x0000B8C2
			internal CanceledEventData(InputMapper A_1, string A_2) : base(A_1)
			{
				this.message = A_2;
			}

			// Token: 0x040008F1 RID: 2289
			public readonly string message;
		}

		// Token: 0x02000153 RID: 339
		public class ErrorEventData : InputMapper.EventData
		{
			// Token: 0x06000EA0 RID: 3744 RVA: 0x0000D6D2 File Offset: 0x0000B8D2
			internal ErrorEventData(InputMapper A_1, string A_2) : base(A_1)
			{
				this.message = A_2;
			}

			// Token: 0x040008F2 RID: 2290
			public readonly string message;
		}

		// Token: 0x02000154 RID: 340
		public class TimedOutEventData : InputMapper.EventData
		{
			// Token: 0x06000EA1 RID: 3745 RVA: 0x0000D6E2 File Offset: 0x0000B8E2
			internal TimedOutEventData(InputMapper A_1) : base(A_1)
			{
			}
		}

		// Token: 0x02000155 RID: 341
		public class StartedEventData : InputMapper.EventData
		{
			// Token: 0x06000EA2 RID: 3746 RVA: 0x0000D6E2 File Offset: 0x0000B8E2
			internal StartedEventData(InputMapper A_1) : base(A_1)
			{
			}
		}

		// Token: 0x02000156 RID: 342
		public class StoppedEventData : InputMapper.EventData
		{
			// Token: 0x06000EA3 RID: 3747 RVA: 0x0000D6E2 File Offset: 0x0000B8E2
			internal StoppedEventData(InputMapper A_1) : base(A_1)
			{
			}
		}

		// Token: 0x02000157 RID: 343
		public class ConflictFoundEventData : InputMapper.EventData
		{
			// Token: 0x06000EA4 RID: 3748 RVA: 0x0000D6EB File Offset: 0x0000B8EB
			public bool IsSwapAllowed(int maxInputFieldCount)
			{
				return this.PrHQotkSuivqIoJUCimZLVZDcFoE != null && this.PrHQotkSuivqIoJUCimZLVZDcFoE(maxInputFieldCount);
			}

			// Token: 0x06000EA5 RID: 3749 RVA: 0x0000D703 File Offset: 0x0000B903
			internal ConflictFoundEventData(InputMapper A_1, Action<InputMapper.ConflictResponse> A_2, ElementAssignmentInfo A_3, IList<ElementAssignmentConflictInfo> A_4, bool A_5, Func<int, bool> A_6) : base(A_1)
			{
				this.responseCallback = A_2;
				this.assignment = A_3;
				this.conflicts = A_4;
				this.isProtected = A_5;
				this.PrHQotkSuivqIoJUCimZLVZDcFoE = A_6;
			}

			// Token: 0x040008F3 RID: 2291
			public readonly Action<InputMapper.ConflictResponse> responseCallback;

			// Token: 0x040008F4 RID: 2292
			public readonly ElementAssignmentInfo assignment;

			// Token: 0x040008F5 RID: 2293
			public readonly IList<ElementAssignmentConflictInfo> conflicts;

			// Token: 0x040008F6 RID: 2294
			public readonly bool isProtected;

			// Token: 0x040008F7 RID: 2295
			private readonly Func<int, bool> PrHQotkSuivqIoJUCimZLVZDcFoE;
		}

		// Token: 0x02000158 RID: 344
		private enum BcoBBVcwunVWzTXpVEJdLidJPTDcb
		{
			// Token: 0x040008F9 RID: 2297
			InputMapped,
			// Token: 0x040008FA RID: 2298
			Error,
			// Token: 0x040008FB RID: 2299
			Canceled,
			// Token: 0x040008FC RID: 2300
			TimedOut,
			// Token: 0x040008FD RID: 2301
			Started,
			// Token: 0x040008FE RID: 2302
			Stopped,
			// Token: 0x040008FF RID: 2303
			ConflictsFound
		}

		// Token: 0x02000159 RID: 345
		public enum Status
		{
			// Token: 0x04000901 RID: 2305
			Idle,
			// Token: 0x04000902 RID: 2306
			Listening,
			// Token: 0x04000903 RID: 2307
			AwaitingResponse
		}

		// Token: 0x0200015A RID: 346
		private class cBmFcYbmVxdegGSsjSAFLBSvQnyFB
		{
			// Token: 0x1700042C RID: 1068
			// (get) Token: 0x06000EA6 RID: 3750 RVA: 0x0000D732 File Offset: 0x0000B932
			public InputMapper.Status BCYjOqRvsopDTdCInAfqiFCrReXD
			{
				get
				{
					return this.onVCWmbLlclIgImvFuxYfrBkqsFjA;
				}
			}

			// Token: 0x1700042D RID: 1069
			// (get) Token: 0x06000EA7 RID: 3751 RVA: 0x0005361C File Offset: 0x0005181C
			public float KvGdKccQlfiEfbPVvHURuIexYCbpA
			{
				get
				{
					if (this.onVCWmbLlclIgImvFuxYfrBkqsFjA == InputMapper.Status.Idle)
					{
						return 0f;
					}
					if (this.TpcdhMDwkumbzdBVGaDgathjTzXJB.timeout <= 0f)
					{
						return 0f;
					}
					return (float)MathTools.Max(0.0, this.MaMtkpToCcSYtxePWcYzpDGbNxLN + (double)this.TpcdhMDwkumbzdBVGaDgathjTzXJB.timeout - ReInput.unscaledTime);
				}
			}

			// Token: 0x1700042E RID: 1070
			// (get) Token: 0x06000EA8 RID: 3752 RVA: 0x0000D73A File Offset: 0x0000B93A
			public InputMapper.Context xCAiNDrJZHjCHsSsUSMbJeFpfWVy
			{
				get
				{
					if (this.onVCWmbLlclIgImvFuxYfrBkqsFjA == InputMapper.Status.Idle)
					{
						return null;
					}
					return this.ytXAPNctMaiEQzgBOkfMTgwGNDNL.KkVcNjgGZlAknAMPqrCxuNMAITWgA;
				}
			}

			// Token: 0x1700042F RID: 1071
			// (get) Token: 0x06000EA9 RID: 3753 RVA: 0x0000D751 File Offset: 0x0000B951
			private bool YwPjDUEkbSkruCuREnXlvBrRbAJj
			{
				get
				{
					return !this.sVWPVrAEVckXEkEALCOXAlaTMUHq && this.TpcdhMDwkumbzdBVGaDgathjTzXJB.timeout > 0f;
				}
			}

			// Token: 0x06000EAA RID: 3754 RVA: 0x00053678 File Offset: 0x00051878
			public cBmFcYbmVxdegGSsjSAFLBSvQnyFB(InputMapper A_1, Dictionary<InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb, SafeDelegate> A_2)
			{
				if (A_1 == null)
				{
					throw new ArgumentNullException("parent");
				}
				if (A_2 == null)
				{
					throw new ArgumentNullException("events");
				}
				this.QxlBvVeAZkyVlFHqGtifCItIGJDtA = A_1;
				this.FjjxUPaNIBJOIgFZowttMtAwAQLdb = A_2;
				this.XVCCUdgIcyFbpWVYGclYIKcDitlb();
			}

			// Token: 0x06000EAB RID: 3755 RVA: 0x000536E8 File Offset: 0x000518E8
			protected virtual void OtugzNEbyvbSdwQjMebazVHNTLue()
			{
				try
				{
					this.CbtbaEsswgrGJdjmOXiyJghvDhnB();
				}
				finally
				{
					base.Finalize();
				}
			}

			// Token: 0x06000EAC RID: 3756 RVA: 0x00053714 File Offset: 0x00051914
			public void tSLIgozvKhclRqqzCRncRnczanXl(InputMapper.Context A_1, InputMapper.Options A_2)
			{
				if (this.onVCWmbLlclIgImvFuxYfrBkqsFjA != InputMapper.Status.Idle)
				{
					this.NnGqCtJOjvTHAMiZXrVtXNCHkJuv("User started a new listening session.");
				}
				if (A_1 == null)
				{
					throw new ArgumentNullException("context");
				}
				if (A_1.controllerMap == null)
				{
					throw new ArgumentNullException("controllerMap");
				}
				if (A_2 == null)
				{
					throw new ArgumentNullException("options");
				}
				A_1 = A_1.Clone();
				InputMapper.Options.Copy(A_2, this.TpcdhMDwkumbzdBVGaDgathjTzXJB);
				Player player = ReInput.players.GetPlayer(A_1.controllerMap.playerId);
				if (ReInput.mapping.GetAction(A_1.actionId) == null)
				{
					this.xpZzdUxIocFHYXaRBmRAGiyJUfNW("No Action found for actionId: " + A_1.actionId.ToString());
					return;
				}
				this.ytXAPNctMaiEQzgBOkfMTgwGNDNL.oYXuHsHNUQvWqGTUUuSCLXhJBsTr(player, A_1);
				this.onVCWmbLlclIgImvFuxYfrBkqsFjA = InputMapper.Status.Listening;
				this.ECgTExQozXrGlLRsJctgPsbaHMMe();
				this.oFcaCpfOrYwKIsPutOVxDLzhIgPnb();
				this.ICfceBIIHTrIRGUiufhDAnhmkorBA();
				this.LtWItKPHnQEsbPfALJOiiepUPkRs();
			}

			// Token: 0x06000EAD RID: 3757 RVA: 0x0000D772 File Offset: 0x0000B972
			public void IBHaSfuVZMsJsgxnSSKfHSgqFqve(string A_1)
			{
				if (this.onVCWmbLlclIgImvFuxYfrBkqsFjA == InputMapper.Status.Idle)
				{
					return;
				}
				this.NnGqCtJOjvTHAMiZXrVtXNCHkJuv(A_1);
			}

			// Token: 0x06000EAE RID: 3758 RVA: 0x000537EC File Offset: 0x000519EC
			private void oGHHxAKxqBkFPatapGzMJRNicYyU(UpdateLoopType A_1)
			{
				if (A_1 != UpdateLoopType.Update)
				{
					return;
				}
				if (this.onVCWmbLlclIgImvFuxYfrBkqsFjA != InputMapper.Status.Listening)
				{
					return;
				}
				if (this.YwPjDUEkbSkruCuREnXlvBrRbAJj && this.KvGdKccQlfiEfbPVvHURuIexYCbpA <= 0f)
				{
					this.mDFfHqwGgBjsBIUbPFXsFAqCUewf();
					return;
				}
				if (ReInput.controllers.GetController(this.ytXAPNctMaiEQzgBOkfMTgwGNDNL.lbdQTEChRkfKnndenTGlKujCDJWc, this.ytXAPNctMaiEQzgBOkfMTgwGNDNL.tHFKwDfNytnwEKuwSnyocJfPDPxq) == null)
				{
					this.xpZzdUxIocFHYXaRBmRAGiyJUfNW("Controller not found for type: " + this.ytXAPNctMaiEQzgBOkfMTgwGNDNL.lbdQTEChRkfKnndenTGlKujCDJWc.ToString() + " id: " + this.ytXAPNctMaiEQzgBOkfMTgwGNDNL.tHFKwDfNytnwEKuwSnyocJfPDPxq.ToString());
					return;
				}
				ElementAssignment elementAssignment;
				if (this.GmiSOZlLYcSDsSJfPEuTryhpRRl(out elementAssignment) == InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.fBCtYiGGvVkmeonytRPdiDjybAwM.Quit)
				{
					return;
				}
				if (this.OeBilbcVVSJAUkBRjRUAgjARlJCCb(elementAssignment) == InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.fBCtYiGGvVkmeonytRPdiDjybAwM.Quit)
				{
					return;
				}
				this.jCCZBWRHhxOtbgkfRxYnOmgEkahH(elementAssignment);
			}

			// Token: 0x06000EAF RID: 3759 RVA: 0x0000D784 File Offset: 0x0000B984
			private void PSEvUlDcFlbRpVkwlipjxulleapK()
			{
				if (this.onVCWmbLlclIgImvFuxYfrBkqsFjA == InputMapper.Status.Idle)
				{
					return;
				}
				this.XVCCUdgIcyFbpWVYGclYIKcDitlb();
				this.CbtbaEsswgrGJdjmOXiyJghvDhnB();
				this.znsGeBxLbPCqoyZJTkvjEGTsRwCA();
			}

			// Token: 0x06000EB0 RID: 3760 RVA: 0x000538A4 File Offset: 0x00051AA4
			private void XVCCUdgIcyFbpWVYGclYIKcDitlb()
			{
				this.onVCWmbLlclIgImvFuxYfrBkqsFjA = InputMapper.Status.Idle;
				this.MaMtkpToCcSYtxePWcYzpDGbNxLN = 0.0;
				this.TpcdhMDwkumbzdBVGaDgathjTzXJB.viqfqeGepcpleHWVSLWMZODqBHCAA();
				this.ytXAPNctMaiEQzgBOkfMTgwGNDNL.zkyNnQGSivucBksvbJLRZBRWJtZf();
				this.dSjiIDvzQsioCtRBmChzNBfgsejH = default(ElementAssignment);
				this.xWZQnmDWKFjmUFZdFHxNWgvKoRYx = InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.JZcanEHWCCbPXDsLAUzgLKxTSbeF.None;
				this.sVWPVrAEVckXEkEALCOXAlaTMUHq = false;
				this.kzuTjdMxFuyKEIWnRZpYdzZDpcUc.Clear();
			}

			// Token: 0x06000EB1 RID: 3761 RVA: 0x00053904 File Offset: 0x00051B04
			private InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.fBCtYiGGvVkmeonytRPdiDjybAwM GmiSOZlLYcSDsSJfPEuTryhpRRl(out ElementAssignment A_1)
			{
				IEnumerable<ControllerPollingInfo> enumerable;
				ModifierKeyFlags modifierKeyFlags;
				if (!this.LWZRoTXCwipmOntJMmQuVaNphKId(out enumerable, out modifierKeyFlags))
				{
					A_1 = default(ElementAssignment);
					return InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.fBCtYiGGvVkmeonytRPdiDjybAwM.Quit;
				}
				ControllerPollingInfo controllerPollingInfo = default(ControllerPollingInfo);
				foreach (ControllerPollingInfo controllerPollingInfo2 in enumerable)
				{
					if (controllerPollingInfo2.success && !InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.vAgwoYPUOgoLWGsEjKcKvWcAnjSu(controllerPollingInfo2, this.TpcdhMDwkumbzdBVGaDgathjTzXJB))
					{
						controllerPollingInfo = controllerPollingInfo2;
						break;
					}
				}
				if (!controllerPollingInfo.success)
				{
					A_1 = default(ElementAssignment);
					return InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.fBCtYiGGvVkmeonytRPdiDjybAwM.Quit;
				}
				if (!InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.ADQfCFlapyPWjHnruJEicXOWGtqG(this.ytXAPNctMaiEQzgBOkfMTgwGNDNL, controllerPollingInfo, this.TpcdhMDwkumbzdBVGaDgathjTzXJB))
				{
					A_1 = default(ElementAssignment);
					return InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.fBCtYiGGvVkmeonytRPdiDjybAwM.Quit;
				}
				A_1 = this.ytXAPNctMaiEQzgBOkfMTgwGNDNL.kLlllLqhqoBDseXLShWaALHGJjTu(controllerPollingInfo);
				A_1.modifierKeyFlags = modifierKeyFlags;
				return InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.fBCtYiGGvVkmeonytRPdiDjybAwM.Continue;
			}

			// Token: 0x06000EB2 RID: 3762 RVA: 0x000539CC File Offset: 0x00051BCC
			private bool LWZRoTXCwipmOntJMmQuVaNphKId(out IEnumerable<ControllerPollingInfo> A_1, out ModifierKeyFlags A_2)
			{
				A_2 = ModifierKeyFlags.None;
				ControllerType controllerType = this.ytXAPNctMaiEQzgBOkfMTgwGNDNL.lbdQTEChRkfKnndenTGlKujCDJWc;
				int controllerId = this.ytXAPNctMaiEQzgBOkfMTgwGNDNL.tHFKwDfNytnwEKuwSnyocJfPDPxq;
				if (controllerType == ControllerType.Keyboard)
				{
					A_1 = this.rUzZTLqNWoPKJIgSIJCheydUgZur(out A_2);
					return true;
				}
				if (this.TpcdhMDwkumbzdBVGaDgathjTzXJB.allowAxes)
				{
					if (this.TpcdhMDwkumbzdBVGaDgathjTzXJB.allowButtons)
					{
						if (this.ytXAPNctMaiEQzgBOkfMTgwGNDNL.esTslCJkvselTuFlauXWDIQrcYKP != null)
						{
							A_1 = this.ytXAPNctMaiEQzgBOkfMTgwGNDNL.esTslCJkvselTuFlauXWDIQrcYKP.controllers.polling.PollControllerForAllElementsDown(controllerType, controllerId);
						}
						else
						{
							A_1 = ReInput.controllers.polling.PollControllerForAllElementsDown(this.ytXAPNctMaiEQzgBOkfMTgwGNDNL.lbdQTEChRkfKnndenTGlKujCDJWc, this.ytXAPNctMaiEQzgBOkfMTgwGNDNL.tHFKwDfNytnwEKuwSnyocJfPDPxq);
						}
					}
					else if (this.ytXAPNctMaiEQzgBOkfMTgwGNDNL.esTslCJkvselTuFlauXWDIQrcYKP != null)
					{
						A_1 = this.ytXAPNctMaiEQzgBOkfMTgwGNDNL.esTslCJkvselTuFlauXWDIQrcYKP.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
					}
					else
					{
						A_1 = ReInput.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
					}
				}
				else
				{
					if (!this.TpcdhMDwkumbzdBVGaDgathjTzXJB.allowButtons)
					{
						this.xpZzdUxIocFHYXaRBmRAGiyJUfNW("You must enable listening for at least one element type.");
						A_1 = null;
						return false;
					}
					if (this.ytXAPNctMaiEQzgBOkfMTgwGNDNL.esTslCJkvselTuFlauXWDIQrcYKP != null)
					{
						A_1 = this.ytXAPNctMaiEQzgBOkfMTgwGNDNL.esTslCJkvselTuFlauXWDIQrcYKP.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
					}
					else
					{
						A_1 = ReInput.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
					}
				}
				return true;
			}

			// Token: 0x06000EB3 RID: 3763 RVA: 0x00053B20 File Offset: 0x00051D20
			private IEnumerable<ControllerPollingInfo> rUzZTLqNWoPKJIgSIJCheydUgZur(out ModifierKeyFlags A_1)
			{
				A_1 = ModifierKeyFlags.None;
				this.muxSRWVxIcNeCTvCahkbYbiUfseu.Clear();
				if (!this.TpcdhMDwkumbzdBVGaDgathjTzXJB.allowButtons)
				{
					return this.muxSRWVxIcNeCTvCahkbYbiUfseu;
				}
				this.muxSRWVxIcNeCTvCahkbYbiUfseu.Add(this.xeqWwXXduWcUOfDosVNmTewFFnvEA(this.TpcdhMDwkumbzdBVGaDgathjTzXJB, out A_1));
				return this.muxSRWVxIcNeCTvCahkbYbiUfseu;
			}

			// Token: 0x06000EB4 RID: 3764 RVA: 0x00053B70 File Offset: 0x00051D70
			private ControllerPollingInfo xeqWwXXduWcUOfDosVNmTewFFnvEA(InputMapper.Options A_1, out ModifierKeyFlags A_2)
			{
				bool flag;
				string text;
				ControllerPollingInfo result = InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.hMXwPUnEBZABLNhzAEvNvmiIlkwE(A_1, out flag, out A_2, out text);
				if (flag)
				{
					this.ECgTExQozXrGlLRsJctgPsbaHMMe();
				}
				return result;
			}

			// Token: 0x06000EB5 RID: 3765 RVA: 0x00053B94 File Offset: 0x00051D94
			private static ControllerPollingInfo hMXwPUnEBZABLNhzAEvNvmiIlkwE(InputMapper.Options A_0, out bool A_1, out ModifierKeyFlags A_2, out string A_3)
			{
				A_3 = string.Empty;
				A_1 = false;
				A_2 = ModifierKeyFlags.None;
				int num = 0;
				ControllerPollingInfo result = default(ControllerPollingInfo);
				ControllerPollingInfo result2 = default(ControllerPollingInfo);
				ModifierKeyFlags modifierKeyFlags = ModifierKeyFlags.None;
				foreach (ControllerPollingInfo controllerPollingInfo in ReInput.controllers.Keyboard.PollForAllKeys())
				{
					KeyCode keyboardKey = controllerPollingInfo.keyboardKey;
					if (keyboardKey != KeyCode.AltGr)
					{
						if (Keyboard.IsModifierKey(controllerPollingInfo.keyboardKey))
						{
							if (num == 0)
							{
								result2 = controllerPollingInfo;
							}
							modifierKeyFlags |= Keyboard.KeyCodeToModifierKeyFlags(keyboardKey);
							num++;
						}
						else if (result.keyboardKey == KeyCode.None)
						{
							result = controllerPollingInfo;
						}
					}
				}
				if (result.keyboardKey == KeyCode.None)
				{
					if (num > 0)
					{
						A_1 = true;
						if (num == 1)
						{
							if (A_0.allowKeyboardModifierKeyAsPrimary)
							{
								if (!A_0.allowKeyboardKeysWithModifiers || A_0.holdDurationToMapKeyboardModifierKeyAsPrimary <= 0f)
								{
									if (!ReInput.controllers.Keyboard.GetKeyDown(result2.keyboardKey))
									{
										return default(ControllerPollingInfo);
									}
									return result2;
								}
								else if (ReInput.controllers.Keyboard.GetKeyTimePressed(result2.keyboardKey) >= (double)A_0.holdDurationToMapKeyboardModifierKeyAsPrimary)
								{
									return result2;
								}
							}
							A_3 = Keyboard.GetKeyName(result2.keyboardKey);
						}
						else
						{
							A_3 = Keyboard.ModifierKeyFlagsToString(modifierKeyFlags, false);
						}
					}
					return default(ControllerPollingInfo);
				}
				if (!ReInput.controllers.Keyboard.GetKeyDown(result.keyboardKey))
				{
					return default(ControllerPollingInfo);
				}
				if (num == 0 || !A_0.allowKeyboardKeysWithModifiers)
				{
					return result;
				}
				A_2 = modifierKeyFlags;
				return result;
			}

			// Token: 0x06000EB6 RID: 3766 RVA: 0x00053D20 File Offset: 0x00051F20
			private static bool vAgwoYPUOgoLWGsEjKcKvWcAnjSu(ControllerPollingInfo A_0, InputMapper.Options A_1)
			{
				if (!A_1.allowAxes && A_0.elementType == ControllerElementType.Axis)
				{
					return false;
				}
				if (!A_1.allowButtons && A_0.elementType == ControllerElementType.Button)
				{
					return false;
				}
				if (A_0.controllerType == ControllerType.Mouse && A_0.elementType == ControllerElementType.Axis)
				{
					int elementIndex = A_0.elementIndex;
					if (elementIndex != 0)
					{
						if (elementIndex == 1)
						{
							if (A_1.ignoreMouseYAxis)
							{
								return true;
							}
						}
					}
					else if (A_1.ignoreMouseXAxis)
					{
						return true;
					}
				}
				SafePredicate<ControllerPollingInfo> safePredicate = A_1.yedXueUgOpURsqpkTGHbELCnmxBzA<SafePredicate<ControllerPollingInfo>>("isElementAllowed");
				return safePredicate != null && !safePredicate.Invoke(A_0);
			}

			// Token: 0x06000EB7 RID: 3767 RVA: 0x0000D7A1 File Offset: 0x0000B9A1
			private static bool ADQfCFlapyPWjHnruJEicXOWGtqG(InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.YPLcgdxYuAjZYleCGjemWVlrGbCA A_0, ControllerPollingInfo A_1, InputMapper.Options A_2)
			{
				return A_0 != null && (A_2 == null || A_0.GlKGUIzjxREHVWLTIZftujYHlHfw != AxisRange.Full || A_2.allowButtonsOnFullAxisAssignment || A_1.elementType != ControllerElementType.Button);
			}

			// Token: 0x06000EB8 RID: 3768 RVA: 0x00053DA8 File Offset: 0x00051FA8
			private void oFcaCpfOrYwKIsPutOVxDLzhIgPnb()
			{
				if (!this.TpcdhMDwkumbzdBVGaDgathjTzXJB.checkForConflicts)
				{
					return;
				}
				if (this.TpcdhMDwkumbzdBVGaDgathjTzXJB.checkForConflictsWithSelf && this.ytXAPNctMaiEQzgBOkfMTgwGNDNL.esTslCJkvselTuFlauXWDIQrcYKP != null)
				{
					ListTools.AddIfUnique<Player>(this.kzuTjdMxFuyKEIWnRZpYdzZDpcUc, this.ytXAPNctMaiEQzgBOkfMTgwGNDNL.esTslCJkvselTuFlauXWDIQrcYKP);
				}
				if (this.TpcdhMDwkumbzdBVGaDgathjTzXJB.checkForConflictsWithSystemPlayer)
				{
					ListTools.AddIfUnique<Player>(this.kzuTjdMxFuyKEIWnRZpYdzZDpcUc, ReInput.players.SystemPlayer);
				}
				if (this.TpcdhMDwkumbzdBVGaDgathjTzXJB.checkForConflictsWithAllPlayers)
				{
					IList<Player> players = ReInput.players.Players;
					for (int i = 0; i < players.Count; i++)
					{
						ListTools.AddIfUnique<Player>(this.kzuTjdMxFuyKEIWnRZpYdzZDpcUc, players[i]);
					}
					return;
				}
				if (this.TpcdhMDwkumbzdBVGaDgathjTzXJB.checkForConflictsWithPlayerIds != null)
				{
					IList<Player> allPlayers = ReInput.players.AllPlayers;
					int count = allPlayers.Count;
					for (int j = 0; j < count; j++)
					{
						if (ArrayTools.Contains<int>(this.TpcdhMDwkumbzdBVGaDgathjTzXJB.checkForConflictsWithPlayerIds, allPlayers[j].id))
						{
							ListTools.AddIfUnique<Player>(this.kzuTjdMxFuyKEIWnRZpYdzZDpcUc, allPlayers[j]);
						}
					}
				}
			}

			// Token: 0x06000EB9 RID: 3769 RVA: 0x0000D7CA File Offset: 0x0000B9CA
			private InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.fBCtYiGGvVkmeonytRPdiDjybAwM OeBilbcVVSJAUkBRjRUAgjARlJCCb(ElementAssignment A_1)
			{
				if (this.TpcdhMDwkumbzdBVGaDgathjTzXJB.checkForConflicts && this.ytXAPNctMaiEQzgBOkfMTgwGNDNL.esTslCJkvselTuFlauXWDIQrcYKP != null && InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.fPMdqqfSDjyIsOAbRhznynWJbtlDA(this.ytXAPNctMaiEQzgBOkfMTgwGNDNL, A_1, this.kzuTjdMxFuyKEIWnRZpYdzZDpcUc))
				{
					return this.EgTlKDZTHaUxNGrbAUHWTgfnBdwiA(A_1);
				}
				return InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.fBCtYiGGvVkmeonytRPdiDjybAwM.Continue;
			}

			// Token: 0x06000EBA RID: 3770 RVA: 0x00053EB8 File Offset: 0x000520B8
			private static bool fPMdqqfSDjyIsOAbRhznynWJbtlDA(InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.YPLcgdxYuAjZYleCGjemWVlrGbCA A_0, ElementAssignment A_1, List<Player> A_2)
			{
				if (A_0 == null || A_0.esTslCJkvselTuFlauXWDIQrcYKP == null)
				{
					return false;
				}
				if (A_2 == null || A_2.Count == 0)
				{
					return false;
				}
				ElementAssignmentConflictCheck conflictCheck;
				if (!InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.nCekkAfalhtWkptKAOIPdpfsacmQ(A_0, A_1, out conflictCheck))
				{
					return false;
				}
				for (int i = 0; i < A_2.Count; i++)
				{
					if (A_2[i].controllers.conflictChecking.DoesElementAssignmentConflict(conflictCheck))
					{
						return true;
					}
				}
				return false;
			}

			// Token: 0x06000EBB RID: 3771 RVA: 0x00053F1C File Offset: 0x0005211C
			private static bool GMFxPfaQeUBvMTrMmlVJKVMpUZFV(InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.YPLcgdxYuAjZYleCGjemWVlrGbCA A_0, ElementAssignment A_1, List<Player> A_2)
			{
				if (A_0 == null || A_0.esTslCJkvselTuFlauXWDIQrcYKP == null)
				{
					return false;
				}
				if (A_2 == null || A_2.Count == 0)
				{
					return false;
				}
				ElementAssignmentConflictCheck conflictCheck;
				if (!InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.nCekkAfalhtWkptKAOIPdpfsacmQ(A_0, A_1, out conflictCheck))
				{
					return false;
				}
				for (int i = 0; i < A_2.Count; i++)
				{
					foreach (ElementAssignmentConflictInfo elementAssignmentConflictInfo in A_2[i].controllers.conflictChecking.ElementAssignmentConflicts(conflictCheck))
					{
						if (!elementAssignmentConflictInfo.isUserAssignable)
						{
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x06000EBC RID: 3772 RVA: 0x00053FC0 File Offset: 0x000521C0
			private static IList<ElementAssignmentConflictInfo> mLAhCFJowlWybioDuKOHXTHOLWlpA(InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.YPLcgdxYuAjZYleCGjemWVlrGbCA A_0, ElementAssignment A_1, List<Player> A_2)
			{
				if (A_0 == null || A_0.esTslCJkvselTuFlauXWDIQrcYKP == null)
				{
					return null;
				}
				if (A_2 == null || A_2.Count == 0)
				{
					return null;
				}
				ElementAssignmentConflictCheck conflictCheck;
				if (!InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.nCekkAfalhtWkptKAOIPdpfsacmQ(A_0, A_1, out conflictCheck))
				{
					return null;
				}
				List<ElementAssignmentConflictInfo> list = new List<ElementAssignmentConflictInfo>();
				for (int i = 0; i < A_2.Count; i++)
				{
					foreach (ElementAssignmentConflictInfo item in A_2[i].controllers.conflictChecking.ElementAssignmentConflicts(conflictCheck))
					{
						list.Add(item);
					}
				}
				return list;
			}

			// Token: 0x06000EBD RID: 3773 RVA: 0x00054060 File Offset: 0x00052260
			private static bool nCekkAfalhtWkptKAOIPdpfsacmQ(InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.YPLcgdxYuAjZYleCGjemWVlrGbCA A_0, ElementAssignment A_1, out ElementAssignmentConflictCheck A_2)
			{
				Player player;
				if (A_0 == null || (player = A_0.esTslCJkvselTuFlauXWDIQrcYKP) == null)
				{
					A_2 = default(ElementAssignmentConflictCheck);
					return false;
				}
				A_2 = A_1.ToElementAssignmentConflictCheck();
				A_2.playerId = player.id;
				A_2.controllerType = A_0.lbdQTEChRkfKnndenTGlKujCDJWc;
				A_2.controllerId = A_0.tHFKwDfNytnwEKuwSnyocJfPDPxq;
				A_2.controllerMapId = A_0.KkVcNjgGZlAknAMPqrCxuNMAITWgA.controllerMap.id;
				A_2.controllerMapCategoryId = A_0.KkVcNjgGZlAknAMPqrCxuNMAITWgA.controllerMap.categoryId;
				if (A_0.KkVcNjgGZlAknAMPqrCxuNMAITWgA.actionElementMapToReplace != null)
				{
					A_2.elementMapId = A_0.KkVcNjgGZlAknAMPqrCxuNMAITWgA.actionElementMapToReplace.id;
				}
				return true;
			}

			// Token: 0x06000EBE RID: 3774 RVA: 0x00054104 File Offset: 0x00052304
			private static void tTPVfUHVBEXDrwCuZBOsneEBPFLj(InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.YPLcgdxYuAjZYleCGjemWVlrGbCA A_0, ElementAssignment A_1, List<Player> A_2)
			{
				if (A_0 == null || A_0.esTslCJkvselTuFlauXWDIQrcYKP == null)
				{
					return;
				}
				ElementAssignmentConflictCheck conflictCheck;
				if (!InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.nCekkAfalhtWkptKAOIPdpfsacmQ(A_0, A_1, out conflictCheck))
				{
					Logger.LogError("Error creating conflict check!");
					return;
				}
				for (int i = 0; i < A_2.Count; i++)
				{
					A_2[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(conflictCheck);
				}
			}

			// Token: 0x06000EBF RID: 3775 RVA: 0x0000D803 File Offset: 0x0000BA03
			private void ICfceBIIHTrIRGUiufhDAnhmkorBA()
			{
				ReInput.UpdateEndedEvent -= this.oGHHxAKxqBkFPatapGzMJRNicYyU;
				ReInput.UpdateEndedEvent += this.oGHHxAKxqBkFPatapGzMJRNicYyU;
			}

			// Token: 0x06000EC0 RID: 3776 RVA: 0x0000D827 File Offset: 0x0000BA27
			private void CbtbaEsswgrGJdjmOXiyJghvDhnB()
			{
				ReInput.UpdateEndedEvent -= this.oGHHxAKxqBkFPatapGzMJRNicYyU;
			}

			// Token: 0x06000EC1 RID: 3777 RVA: 0x0005415C File Offset: 0x0005235C
			private bool cgJTmwNOMzdOSWCCyAkUAATHqTPDb(InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb A_1)
			{
				SafeDelegate safeDelegate = this.FjjxUPaNIBJOIgFZowttMtAwAQLdb[A_1];
				return safeDelegate != null && safeDelegate.Count > 0;
			}

			// Token: 0x06000EC2 RID: 3778 RVA: 0x00054184 File Offset: 0x00052384
			private void NXlvAiXaNzAReJwwpIeRVjrViwADA<\u0001>(InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb A_1, \u0001 A_2)
			{
				SafeAction<\u0001> safeAction = (SafeAction<\u0001>)this.FjjxUPaNIBJOIgFZowttMtAwAQLdb[A_1];
				if (safeAction.Count == 0)
				{
					return;
				}
				safeAction.Invoke(A_2);
			}

			// Token: 0x06000EC3 RID: 3779 RVA: 0x0000D83A File Offset: 0x0000BA3A
			private void ECgTExQozXrGlLRsJctgPsbaHMMe()
			{
				this.MaMtkpToCcSYtxePWcYzpDGbNxLN = ReInput.unscaledTime;
			}

			// Token: 0x06000EC4 RID: 3780 RVA: 0x0000D847 File Offset: 0x0000BA47
			private void IpowiGvieDqLhpvrASRRiakWjzrE()
			{
				this.sVWPVrAEVckXEkEALCOXAlaTMUHq = true;
			}

			// Token: 0x06000EC5 RID: 3781 RVA: 0x000541B4 File Offset: 0x000523B4
			private bool EclrGuOgMohZFbsDNPStcAfBSdbzB(ElementAssignmentInfo A_1, IList<ElementAssignmentConflictInfo> A_2, bool A_3, int A_4)
			{
				if (A_4 < 0)
				{
					A_4 = 0;
				}
				if (A_1 == null || A_2 == null)
				{
					return false;
				}
				if (A_3)
				{
					return false;
				}
				ActionElementMap elementMap = A_1.elementMap;
				if (elementMap == null)
				{
					return false;
				}
				List<ElementAssignmentConflictInfo> list = new List<ElementAssignmentConflictInfo>();
				for (int i = 0; i < A_2.Count; i++)
				{
					if (A_2[i].playerId == A_1.player.id)
					{
						list.Add(A_2[i]);
					}
				}
				if (list.Count > 1)
				{
					return false;
				}
				ElementAssignmentConflictInfo elementAssignmentConflictInfo = list[0];
				if (elementAssignmentConflictInfo.elementMap == null)
				{
					return false;
				}
				if (!elementAssignmentConflictInfo.isConflict)
				{
					return false;
				}
				if (elementAssignmentConflictInfo.playerId != A_1.player.id)
				{
					return false;
				}
				int actionId = elementAssignmentConflictInfo.elementMap.actionId;
				Pole axisContribution = elementAssignmentConflictInfo.elementMap.axisContribution;
				AxisRange axisRange = elementMap.axisRange;
				ControllerElementType elementType = elementMap.elementType;
				if (elementType == elementAssignmentConflictInfo.elementMap.elementType && elementType == ControllerElementType.Axis)
				{
					if (axisRange != elementAssignmentConflictInfo.elementMap.axisRange)
					{
						if (axisRange == AxisRange.Full)
						{
							axisRange = AxisRange.Positive;
						}
						else if (elementAssignmentConflictInfo.elementMap.axisRange == AxisRange.Full)
						{
						}
					}
				}
				else if (elementType == ControllerElementType.Axis && (elementAssignmentConflictInfo.elementMap.elementType == ControllerElementType.Button || (elementAssignmentConflictInfo.elementMap.elementType == ControllerElementType.Axis && elementAssignmentConflictInfo.elementMap.axisRange != AxisRange.Full)) && axisRange == AxisRange.Full)
				{
					axisRange = AxisRange.Positive;
				}
				int num = 0;
				if (A_1.action.id == elementAssignmentConflictInfo.actionId && A_1.controllerMap == elementAssignmentConflictInfo.controllerMap)
				{
					Controller controller = ReInput.controllers.GetController(A_1.controllerType, A_1.controllerId);
					if (InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.YwIPpNRcvcYfZJENojKJEBFLKSRNA(elementType, axisRange, axisContribution, controller.GetElementById(A_1.elementIdentifier.id).type, A_1.axisRange, A_1.axisContribution))
					{
						num++;
					}
				}
				using (IEnumerator<ActionElementMap> enumerator = elementAssignmentConflictInfo.controllerMap.ElementMapsWithAction(actionId).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.txwPXmvcmabZafDzUTRPlZAFUwnh txwPXmvcmabZafDzUTRPlZAFUwnh = new InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.txwPXmvcmabZafDzUTRPlZAFUwnh();
						txwPXmvcmabZafDzUTRPlZAFUwnh.ZftaqwDRsofEUxZCzpMuoAteywhlA = enumerator.Current;
						if (txwPXmvcmabZafDzUTRPlZAFUwnh.ZftaqwDRsofEUxZCzpMuoAteywhlA.id != elementMap.id && ListTools.FindIndex<ElementAssignmentConflictInfo>(list, new Predicate<ElementAssignmentConflictInfo>(txwPXmvcmabZafDzUTRPlZAFUwnh.UGTdHPzlAMNfeHjVvVTLCCUPhvzD)) < 0 && InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.YwIPpNRcvcYfZJENojKJEBFLKSRNA(elementType, axisRange, axisContribution, txwPXmvcmabZafDzUTRPlZAFUwnh.ZftaqwDRsofEUxZCzpMuoAteywhlA.elementType, txwPXmvcmabZafDzUTRPlZAFUwnh.ZftaqwDRsofEUxZCzpMuoAteywhlA.axisRange, txwPXmvcmabZafDzUTRPlZAFUwnh.ZftaqwDRsofEUxZCzpMuoAteywhlA.axisContribution))
						{
							num++;
						}
					}
				}
				return num < A_4;
			}

			// Token: 0x06000EC6 RID: 3782 RVA: 0x00054434 File Offset: 0x00052634
			private bool wXbewSCDdeRiBvXjcqVrDzvknwlK(InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.YPLcgdxYuAjZYleCGjemWVlrGbCA A_1, ElementAssignment A_2, bool A_3, out string A_4)
			{
				if (A_1 == null)
				{
					A_4 = "Mapping is null reference.";
					return false;
				}
				List<Player> list = new List<Player>
				{
					A_1.esTslCJkvselTuFlauXWDIQrcYKP
				};
				IList<ElementAssignmentConflictInfo> list2 = InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.mLAhCFJowlWybioDuKOHXTHOLWlpA(A_1, A_2, list);
				int count = list2.Count;
				if (count == 0)
				{
					A_4 = "Swap was canceled because no conflicts were found.";
					return false;
				}
				if (count > 1)
				{
					A_4 = "Swap was canceled because more than one conflict was found.";
					return false;
				}
				if (A_3)
				{
					A_4 = "Swap was canceled due to a protected conflict that cannot be replaced.";
					return false;
				}
				if (A_1.KkVcNjgGZlAknAMPqrCxuNMAITWgA.actionElementMapToReplace == null)
				{
					A_4 = "Swap was canceled because this is not a replacement assignment.";
					return false;
				}
				ElementAssignmentConflictInfo elementAssignmentConflictInfo = list2[0];
				if (!elementAssignmentConflictInfo.isConflict)
				{
					A_4 = "Swap was canceled because conflict was invalid.";
					return false;
				}
				ActionElementMap actionElementMap = new ActionElementMap(elementAssignmentConflictInfo.elementMap);
				if (actionElementMap == null)
				{
					A_4 = "Swap was canceled because conflict ActionElementMap was null.";
					return false;
				}
				ActionElementMap actionElementMap2 = new ActionElementMap(A_1.KkVcNjgGZlAknAMPqrCxuNMAITWgA.actionElementMapToReplace);
				InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.tTPVfUHVBEXDrwCuZBOsneEBPFLj(A_1, A_2, list);
				int actionId = actionElementMap.actionId;
				Pole axisContribution = actionElementMap.axisContribution;
				bool invert = actionElementMap.invert;
				AxisRange axisRange = actionElementMap2.axisRange;
				ControllerElementType elementType = actionElementMap2.elementType;
				int elementIdentifierId = actionElementMap2.elementIdentifierId;
				KeyCode keyCode = actionElementMap2.keyCode;
				ModifierKeyFlags modifierKeyFlags = actionElementMap2.modifierKeyFlags;
				if (elementType == actionElementMap.elementType && elementType == ControllerElementType.Axis)
				{
					if (axisRange != actionElementMap.axisRange)
					{
						if (axisRange == AxisRange.Full)
						{
							axisRange = AxisRange.Positive;
						}
						else if (actionElementMap.axisRange == AxisRange.Full)
						{
						}
					}
				}
				else if (elementType == ControllerElementType.Axis && (actionElementMap.elementType == ControllerElementType.Button || (actionElementMap.elementType == ControllerElementType.Axis && actionElementMap.axisRange != AxisRange.Full)) && axisRange == AxisRange.Full)
				{
					axisRange = AxisRange.Positive;
				}
				if (elementType != ControllerElementType.Axis || axisRange != AxisRange.Full)
				{
					invert = false;
				}
				elementAssignmentConflictInfo.controllerMap.ReplaceOrCreateElementMap(ElementAssignment.CompleteAssignment(A_1.lbdQTEChRkfKnndenTGlKujCDJWc, elementType, elementIdentifierId, axisRange, keyCode, modifierKeyFlags, actionId, axisContribution, invert));
				A_4 = null;
				return true;
			}

			// Token: 0x06000EC7 RID: 3783 RVA: 0x0000D850 File Offset: 0x0000BA50
			private static bool YwIPpNRcvcYfZJENojKJEBFLKSRNA(ControllerElementType A_0, AxisRange A_1, Pole A_2, ControllerElementType A_3, AxisRange A_4, Pole A_5)
			{
				return ((A_0 == ControllerElementType.Button || (A_0 == ControllerElementType.Axis && A_1 != AxisRange.Full)) && (A_3 == ControllerElementType.Button || (A_3 == ControllerElementType.Axis && A_4 != AxisRange.Full)) && A_5 == A_2) || (A_0 == ControllerElementType.Axis && A_1 == AxisRange.Full && A_3 == ControllerElementType.Axis && A_4 == AxisRange.Full);
			}

			// Token: 0x06000EC8 RID: 3784 RVA: 0x0000D87E File Offset: 0x0000BA7E
			private void WPOdUfNfGJIxgOyhlgBOhZFcxPDv(ActionElementMap A_1)
			{
				this.wHGWWvOVvfaTVmoUvLhfiFrRepwBA(A_1);
				this.PSEvUlDcFlbRpVkwlipjxulleapK();
			}

			// Token: 0x06000EC9 RID: 3785 RVA: 0x0000D88D File Offset: 0x0000BA8D
			private void NnGqCtJOjvTHAMiZXrVtXNCHkJuv(string A_1)
			{
				this.JfvCORFuGVaypGxQgTzHmiwxTfnJA(A_1);
				this.PSEvUlDcFlbRpVkwlipjxulleapK();
			}

			// Token: 0x06000ECA RID: 3786 RVA: 0x000545D0 File Offset: 0x000527D0
			private InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.fBCtYiGGvVkmeonytRPdiDjybAwM EgTlKDZTHaUxNGrbAUHWTgfnBdwiA(ElementAssignment A_1)
			{
				if (this.cgJTmwNOMzdOSWCCyAkUAATHqTPDb(InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.ConflictsFound))
				{
					bool flag = InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.GMFxPfaQeUBvMTrMmlVJKVMpUZFV(this.ytXAPNctMaiEQzgBOkfMTgwGNDNL, A_1, this.kzuTjdMxFuyKEIWnRZpYdzZDpcUc);
					this.dSjiIDvzQsioCtRBmChzNBfgsejH = A_1;
					IList<ElementAssignmentConflictInfo> list = InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.mLAhCFJowlWybioDuKOHXTHOLWlpA(this.ytXAPNctMaiEQzgBOkfMTgwGNDNL, A_1, this.kzuTjdMxFuyKEIWnRZpYdzZDpcUc);
					this.xWZQnmDWKFjmUFZdFHxNWgvKoRYx = InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.JZcanEHWCCbPXDsLAUzgLKxTSbeF.ConflictChecking;
					this.RjILuQQOjfhSikedIYPpfiMDxoArA();
					this.aKFcKymNfEgHxDeHHFwwiyQpxfxFA(new ElementAssignmentInfo(this.ytXAPNctMaiEQzgBOkfMTgwGNDNL.KkVcNjgGZlAknAMPqrCxuNMAITWgA.controllerMap, A_1), list, flag);
					return InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.fBCtYiGGvVkmeonytRPdiDjybAwM.Quit;
				}
				return this.jAGfuzhqKRWrHALuAApSZgKfwNbm(this.TpcdhMDwkumbzdBVGaDgathjTzXJB.defaultActionWhenConflictFound, A_1);
			}

			// Token: 0x06000ECB RID: 3787 RVA: 0x0000D89C File Offset: 0x0000BA9C
			private InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.fBCtYiGGvVkmeonytRPdiDjybAwM jAGfuzhqKRWrHALuAApSZgKfwNbm(InputMapper.ConflictResponse A_1, ElementAssignment A_2)
			{
				return this.RoteOJtfOXjVrojuUKAYIgasFmOB(A_1, A_2, InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.GMFxPfaQeUBvMTrMmlVJKVMpUZFV(this.ytXAPNctMaiEQzgBOkfMTgwGNDNL, A_2, this.kzuTjdMxFuyKEIWnRZpYdzZDpcUc));
			}

			// Token: 0x06000ECC RID: 3788 RVA: 0x00054654 File Offset: 0x00052854
			private InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.fBCtYiGGvVkmeonytRPdiDjybAwM RoteOJtfOXjVrojuUKAYIgasFmOB(InputMapper.ConflictResponse A_1, ElementAssignment A_2, bool A_3)
			{
				switch (A_1)
				{
				case InputMapper.ConflictResponse.Cancel:
					this.NnGqCtJOjvTHAMiZXrVtXNCHkJuv("Mapping assignment was canceled due to a conflict.");
					return InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.fBCtYiGGvVkmeonytRPdiDjybAwM.Quit;
				case InputMapper.ConflictResponse.Replace:
					if (A_3)
					{
						this.NnGqCtJOjvTHAMiZXrVtXNCHkJuv("Mapping assignment was canceled due to a protected conflict that cannot be replaced.");
						return InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.fBCtYiGGvVkmeonytRPdiDjybAwM.Quit;
					}
					InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.tTPVfUHVBEXDrwCuZBOsneEBPFLj(this.ytXAPNctMaiEQzgBOkfMTgwGNDNL, A_2, this.kzuTjdMxFuyKEIWnRZpYdzZDpcUc);
					return InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.fBCtYiGGvVkmeonytRPdiDjybAwM.Continue;
				case InputMapper.ConflictResponse.Add:
					return InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.fBCtYiGGvVkmeonytRPdiDjybAwM.Continue;
				case InputMapper.ConflictResponse.Ignore:
					this.CDdbVnmCNliKkvQIgiNHBHVlWnVG();
					return InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.fBCtYiGGvVkmeonytRPdiDjybAwM.Quit;
				case InputMapper.ConflictResponse.Swap:
				{
					string text;
					if (!this.wXbewSCDdeRiBvXjcqVrDzvknwlK(this.ytXAPNctMaiEQzgBOkfMTgwGNDNL, A_2, A_3, out text))
					{
						this.NnGqCtJOjvTHAMiZXrVtXNCHkJuv(text);
						return InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.fBCtYiGGvVkmeonytRPdiDjybAwM.Quit;
					}
					return InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.fBCtYiGGvVkmeonytRPdiDjybAwM.Continue;
				}
				default:
					throw new NotImplementedException();
				}
			}

			// Token: 0x06000ECD RID: 3789 RVA: 0x0000D8B8 File Offset: 0x0000BAB8
			private void mDFfHqwGgBjsBIUbPFXsFAqCUewf()
			{
				this.vhnIourlGfoteombdkNhIlHuNHPe();
				this.PSEvUlDcFlbRpVkwlipjxulleapK();
			}

			// Token: 0x06000ECE RID: 3790 RVA: 0x0000D8C6 File Offset: 0x0000BAC6
			private void xpZzdUxIocFHYXaRBmRAGiyJUfNW(string A_1)
			{
				this.iZOraoJdTUqnBKeQpYcFjQLnygWq(A_1);
				this.PSEvUlDcFlbRpVkwlipjxulleapK();
			}

			// Token: 0x06000ECF RID: 3791 RVA: 0x0000D8D5 File Offset: 0x0000BAD5
			private void RjILuQQOjfhSikedIYPpfiMDxoArA()
			{
				this.IpowiGvieDqLhpvrASRRiakWjzrE();
				this.CbtbaEsswgrGJdjmOXiyJghvDhnB();
				this.onVCWmbLlclIgImvFuxYfrBkqsFjA = InputMapper.Status.AwaitingResponse;
			}

			// Token: 0x06000ED0 RID: 3792 RVA: 0x0000D8EA File Offset: 0x0000BAEA
			private void CDdbVnmCNliKkvQIgiNHBHVlWnVG()
			{
				this.onVCWmbLlclIgImvFuxYfrBkqsFjA = InputMapper.Status.Listening;
				this.xWZQnmDWKFjmUFZdFHxNWgvKoRYx = InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.JZcanEHWCCbPXDsLAUzgLKxTSbeF.None;
				this.ECgTExQozXrGlLRsJctgPsbaHMMe();
				this.ICfceBIIHTrIRGUiufhDAnhmkorBA();
			}

			// Token: 0x06000ED1 RID: 3793 RVA: 0x000546DC File Offset: 0x000528DC
			private void jCCZBWRHhxOtbgkfRxYnOmgEkahH(ElementAssignment A_1)
			{
				ActionElementMap actionElementMap;
				if (this.ytXAPNctMaiEQzgBOkfMTgwGNDNL.KkVcNjgGZlAknAMPqrCxuNMAITWgA.controllerMap.ReplaceOrCreateElementMap(A_1, out actionElementMap))
				{
					this.WPOdUfNfGJIxgOyhlgBOhZFcxPDv(actionElementMap);
					return;
				}
				this.xpZzdUxIocFHYXaRBmRAGiyJUfNW("Failed to create element assignment.");
			}

			// Token: 0x06000ED2 RID: 3794 RVA: 0x0000D906 File Offset: 0x0000BB06
			private void wHGWWvOVvfaTVmoUvLhfiFrRepwBA(ActionElementMap A_1)
			{
				if (!this.cgJTmwNOMzdOSWCCyAkUAATHqTPDb(InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.InputMapped))
				{
					return;
				}
				this.NXlvAiXaNzAReJwwpIeRVjrViwADA<InputMapper.InputMappedEventData>(InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.InputMapped, new InputMapper.InputMappedEventData(this.QxlBvVeAZkyVlFHqGtifCItIGJDtA, A_1));
			}

			// Token: 0x06000ED3 RID: 3795 RVA: 0x0000D925 File Offset: 0x0000BB25
			private void vhnIourlGfoteombdkNhIlHuNHPe()
			{
				if (!this.cgJTmwNOMzdOSWCCyAkUAATHqTPDb(InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.TimedOut))
				{
					return;
				}
				this.NXlvAiXaNzAReJwwpIeRVjrViwADA<InputMapper.TimedOutEventData>(InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.TimedOut, new InputMapper.TimedOutEventData(this.QxlBvVeAZkyVlFHqGtifCItIGJDtA));
			}

			// Token: 0x06000ED4 RID: 3796 RVA: 0x0000D943 File Offset: 0x0000BB43
			private void iZOraoJdTUqnBKeQpYcFjQLnygWq(string A_1)
			{
				if (!this.cgJTmwNOMzdOSWCCyAkUAATHqTPDb(InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.Error))
				{
					return;
				}
				this.NXlvAiXaNzAReJwwpIeRVjrViwADA<InputMapper.ErrorEventData>(InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.Error, new InputMapper.ErrorEventData(this.QxlBvVeAZkyVlFHqGtifCItIGJDtA, A_1));
			}

			// Token: 0x06000ED5 RID: 3797 RVA: 0x0000D962 File Offset: 0x0000BB62
			private void JfvCORFuGVaypGxQgTzHmiwxTfnJA(string A_1)
			{
				if (!this.cgJTmwNOMzdOSWCCyAkUAATHqTPDb(InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.Canceled))
				{
					return;
				}
				this.NXlvAiXaNzAReJwwpIeRVjrViwADA<InputMapper.CanceledEventData>(InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.Canceled, new InputMapper.CanceledEventData(this.QxlBvVeAZkyVlFHqGtifCItIGJDtA, A_1));
			}

			// Token: 0x06000ED6 RID: 3798 RVA: 0x00054718 File Offset: 0x00052918
			private void aKFcKymNfEgHxDeHHFwwiyQpxfxFA(ElementAssignmentInfo A_1, IList<ElementAssignmentConflictInfo> A_2, bool A_3)
			{
				InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.nKPGcMlUphBFCQTTrYfwzpjVJheK nKPGcMlUphBFCQTTrYfwzpjVJheK = new InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.nKPGcMlUphBFCQTTrYfwzpjVJheK();
				nKPGcMlUphBFCQTTrYfwzpjVJheK.rqsBczxBAeYMIFrnhuJVZpmdaexG = this;
				nKPGcMlUphBFCQTTrYfwzpjVJheK.hIoKidLKgJIqrfoJRhlMYLudsfGqA = A_1;
				nKPGcMlUphBFCQTTrYfwzpjVJheK.UyNaYPFRoYpsWVqIxLIkeMPchQSdc = A_2;
				nKPGcMlUphBFCQTTrYfwzpjVJheK.JuRRBjvKRgtpDdDOrDtLOtRzBZaw = A_3;
				if (!this.cgJTmwNOMzdOSWCCyAkUAATHqTPDb(InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.ConflictsFound))
				{
					return;
				}
				this.NXlvAiXaNzAReJwwpIeRVjrViwADA<InputMapper.ConflictFoundEventData>(InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.ConflictsFound, new InputMapper.ConflictFoundEventData(this.QxlBvVeAZkyVlFHqGtifCItIGJDtA, new Action<InputMapper.ConflictResponse>(this.JAzdWBLnXJfsflqdUKnLGyOOyzID), nKPGcMlUphBFCQTTrYfwzpjVJheK.hIoKidLKgJIqrfoJRhlMYLudsfGqA, nKPGcMlUphBFCQTTrYfwzpjVJheK.UyNaYPFRoYpsWVqIxLIkeMPchQSdc, nKPGcMlUphBFCQTTrYfwzpjVJheK.JuRRBjvKRgtpDdDOrDtLOtRzBZaw, new Func<int, bool>(nKPGcMlUphBFCQTTrYfwzpjVJheK.RXkCgDKBomAhiihJVUbJZHcfOUqfb)));
			}

			// Token: 0x06000ED7 RID: 3799 RVA: 0x0000D981 File Offset: 0x0000BB81
			private void LtWItKPHnQEsbPfALJOiiepUPkRs()
			{
				if (!this.cgJTmwNOMzdOSWCCyAkUAATHqTPDb(InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.Started))
				{
					return;
				}
				this.NXlvAiXaNzAReJwwpIeRVjrViwADA<InputMapper.StartedEventData>(InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.Started, new InputMapper.StartedEventData(this.QxlBvVeAZkyVlFHqGtifCItIGJDtA));
			}

			// Token: 0x06000ED8 RID: 3800 RVA: 0x0000D99F File Offset: 0x0000BB9F
			private void znsGeBxLbPCqoyZJTkvjEGTsRwCA()
			{
				if (!this.cgJTmwNOMzdOSWCCyAkUAATHqTPDb(InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.Stopped))
				{
					return;
				}
				this.NXlvAiXaNzAReJwwpIeRVjrViwADA<InputMapper.StoppedEventData>(InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb.Stopped, new InputMapper.StoppedEventData(this.QxlBvVeAZkyVlFHqGtifCItIGJDtA));
			}

			// Token: 0x06000ED9 RID: 3801 RVA: 0x00054790 File Offset: 0x00052990
			public void JAzdWBLnXJfsflqdUKnLGyOOyzID(InputMapper.ConflictResponse A_1)
			{
				if (this.onVCWmbLlclIgImvFuxYfrBkqsFjA != InputMapper.Status.AwaitingResponse || this.xWZQnmDWKFjmUFZdFHxNWgvKoRYx != InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.JZcanEHWCCbPXDsLAUzgLKxTSbeF.ConflictChecking)
				{
					Logger.LogWarning("The Mapping Listener was not waiting for a conflict checking response. The response will be ignored.");
					return;
				}
				try
				{
					if (this.jAGfuzhqKRWrHALuAApSZgKfwNbm(A_1, this.dSjiIDvzQsioCtRBmChzNBfgsejH) == InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.fBCtYiGGvVkmeonytRPdiDjybAwM.Continue)
					{
						this.jCCZBWRHhxOtbgkfRxYnOmgEkahH(this.dSjiIDvzQsioCtRBmChzNBfgsejH);
					}
				}
				catch (Exception ex)
				{
					string str = "An exception occurred in the conflict check user response callback.\n";
					Exception ex2 = ex;
					Logger.LogError(str + ((ex2 != null) ? ex2.ToString() : null));
				}
			}

			// Token: 0x04000904 RID: 2308
			private readonly InputMapper QxlBvVeAZkyVlFHqGtifCItIGJDtA;

			// Token: 0x04000905 RID: 2309
			private readonly InputMapper.Options TpcdhMDwkumbzdBVGaDgathjTzXJB = new InputMapper.Options();

			// Token: 0x04000906 RID: 2310
			private readonly InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.YPLcgdxYuAjZYleCGjemWVlrGbCA ytXAPNctMaiEQzgBOkfMTgwGNDNL = new InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.YPLcgdxYuAjZYleCGjemWVlrGbCA();

			// Token: 0x04000907 RID: 2311
			private readonly Dictionary<InputMapper.BcoBBVcwunVWzTXpVEJdLidJPTDcb, SafeDelegate> FjjxUPaNIBJOIgFZowttMtAwAQLdb;

			// Token: 0x04000908 RID: 2312
			private readonly Dictionary<string, SafeDelegate> VzuZtsghPcHbBiBRtqKzFxlFojTab;

			// Token: 0x04000909 RID: 2313
			private InputMapper.Status onVCWmbLlclIgImvFuxYfrBkqsFjA;

			// Token: 0x0400090A RID: 2314
			private InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB.JZcanEHWCCbPXDsLAUzgLKxTSbeF xWZQnmDWKFjmUFZdFHxNWgvKoRYx;

			// Token: 0x0400090B RID: 2315
			private double MaMtkpToCcSYtxePWcYzpDGbNxLN;

			// Token: 0x0400090C RID: 2316
			private bool sVWPVrAEVckXEkEALCOXAlaTMUHq;

			// Token: 0x0400090D RID: 2317
			private List<Player> kzuTjdMxFuyKEIWnRZpYdzZDpcUc = new List<Player>();

			// Token: 0x0400090E RID: 2318
			private readonly List<ControllerPollingInfo> muxSRWVxIcNeCTvCahkbYbiUfseu = new List<ControllerPollingInfo>();

			// Token: 0x0400090F RID: 2319
			private ElementAssignment dSjiIDvzQsioCtRBmChzNBfgsejH;

			// Token: 0x0200015B RID: 347
			private enum fBCtYiGGvVkmeonytRPdiDjybAwM
			{
				// Token: 0x04000911 RID: 2321
				Quit,
				// Token: 0x04000912 RID: 2322
				Continue
			}

			// Token: 0x0200015C RID: 348
			private enum JZcanEHWCCbPXDsLAUzgLKxTSbeF
			{
				// Token: 0x04000914 RID: 2324
				None,
				// Token: 0x04000915 RID: 2325
				ConflictChecking
			}

			// Token: 0x0200015D RID: 349
			private class YPLcgdxYuAjZYleCGjemWVlrGbCA
			{
				// Token: 0x17000430 RID: 1072
				// (get) Token: 0x06000EDA RID: 3802 RVA: 0x0000D9BD File Offset: 0x0000BBBD
				public Player esTslCJkvselTuFlauXWDIQrcYKP
				{
					get
					{
						return this.KOrEqcdMSGxBmEsgoepxDSEjNXLY;
					}
				}

				// Token: 0x17000431 RID: 1073
				// (get) Token: 0x06000EDB RID: 3803 RVA: 0x0000D9C5 File Offset: 0x0000BBC5
				public int NDkuBSbITBKHiKqdDDVYuhcNgtQEA
				{
					get
					{
						return this.fnfTHHkNFYeyPWCfJczgdidnRcQW;
					}
				}

				// Token: 0x17000432 RID: 1074
				// (get) Token: 0x06000EDC RID: 3804 RVA: 0x0000D9CD File Offset: 0x0000BBCD
				public InputMapper.Context KkVcNjgGZlAknAMPqrCxuNMAITWgA
				{
					get
					{
						return this.YlymUoXPUAdwKRIvGlFkwmNyXwaP;
					}
				}

				// Token: 0x17000433 RID: 1075
				// (get) Token: 0x06000EDD RID: 3805 RVA: 0x0000D9D5 File Offset: 0x0000BBD5
				public ControllerType lbdQTEChRkfKnndenTGlKujCDJWc
				{
					get
					{
						return this.qzNBioIYInxwoiibFFelUmglFQzqA;
					}
				}

				// Token: 0x17000434 RID: 1076
				// (get) Token: 0x06000EDE RID: 3806 RVA: 0x0000D9DD File Offset: 0x0000BBDD
				public int tHFKwDfNytnwEKuwSnyocJfPDPxq
				{
					get
					{
						return this.kWzEXbMqBmqfEUazGzDLURlQBUbM;
					}
				}

				// Token: 0x17000435 RID: 1077
				// (get) Token: 0x06000EDF RID: 3807 RVA: 0x0000D9E5 File Offset: 0x0000BBE5
				public ControllerPollingInfo VNnMNcCrOSprIIVZarCAaKKPAccy
				{
					get
					{
						return this.OADcJigAecKRNIQelUlRxPZwVqAv;
					}
				}

				// Token: 0x17000436 RID: 1078
				// (get) Token: 0x06000EE0 RID: 3808 RVA: 0x0000D9ED File Offset: 0x0000BBED
				public ModifierKeyFlags MOmFCMbUUbfNwrtOmdGqAdTSTNyfb
				{
					get
					{
						return this.BTOmjtTWkhaBbIVkKxHGBkesYWPc;
					}
				}

				// Token: 0x17000437 RID: 1079
				// (get) Token: 0x06000EE1 RID: 3809 RVA: 0x00054808 File Offset: 0x00052A08
				public AxisRange GlKGUIzjxREHVWLTIZftujYHlHfw
				{
					get
					{
						AxisRange result = AxisRange.Positive;
						if (this.VNnMNcCrOSprIIVZarCAaKKPAccy.elementType == ControllerElementType.Axis)
						{
							if (this.YlymUoXPUAdwKRIvGlFkwmNyXwaP.actionRange == AxisRange.Full)
							{
								result = AxisRange.Full;
							}
							else
							{
								result = ((this.VNnMNcCrOSprIIVZarCAaKKPAccy.axisPole == Pole.Positive) ? AxisRange.Positive : AxisRange.Negative);
							}
						}
						return result;
					}
				}

				// Token: 0x17000438 RID: 1080
				// (get) Token: 0x06000EE2 RID: 3810 RVA: 0x00054850 File Offset: 0x00052A50
				public string VvHKzZTbIxusbjRZIGvxHYsmrJgnA
				{
					get
					{
						if (this.lbdQTEChRkfKnndenTGlKujCDJWc == ControllerType.Keyboard && this.MOmFCMbUUbfNwrtOmdGqAdTSTNyfb != ModifierKeyFlags.None)
						{
							return string.Format("{0} + {1}", Keyboard.ModifierKeyFlagsToString(this.MOmFCMbUUbfNwrtOmdGqAdTSTNyfb), this.VNnMNcCrOSprIIVZarCAaKKPAccy.elementIdentifierName);
						}
						string text = this.VNnMNcCrOSprIIVZarCAaKKPAccy.elementIdentifierName;
						if (this.VNnMNcCrOSprIIVZarCAaKKPAccy.elementType == ControllerElementType.Axis)
						{
							if (this.GlKGUIzjxREHVWLTIZftujYHlHfw == AxisRange.Positive)
							{
								text += " +";
							}
							else if (this.GlKGUIzjxREHVWLTIZftujYHlHfw == AxisRange.Negative)
							{
								text += " -";
							}
						}
						return text;
					}
				}

				// Token: 0x06000EE4 RID: 3812 RVA: 0x000548E0 File Offset: 0x00052AE0
				public void oYXuHsHNUQvWqGTUUuSCLXhJBsTr(Player A_1, InputMapper.Context A_2)
				{
					if (A_2.controllerMap == null)
					{
						throw new ArgumentNullException("controllerMap");
					}
					this.zkyNnQGSivucBksvbJLRZBRWJtZf();
					this.KOrEqcdMSGxBmEsgoepxDSEjNXLY = A_1;
					this.fnfTHHkNFYeyPWCfJczgdidnRcQW = A_2.actionId;
					this.qzNBioIYInxwoiibFFelUmglFQzqA = A_2.controllerMap.controllerType;
					this.kWzEXbMqBmqfEUazGzDLURlQBUbM = A_2.controllerMap.controllerId;
					this.YlymUoXPUAdwKRIvGlFkwmNyXwaP = A_2;
					this.qzNBioIYInxwoiibFFelUmglFQzqA = A_2.controllerMap.controllerType;
					this.kWzEXbMqBmqfEUazGzDLURlQBUbM = A_2.controllerMap.controllerId;
					A_2.dxOehzluRHRHnFUEopeNQWvykAUd();
				}

				// Token: 0x06000EE5 RID: 3813 RVA: 0x0000D9F5 File Offset: 0x0000BBF5
				public void zkyNnQGSivucBksvbJLRZBRWJtZf()
				{
					this.KOrEqcdMSGxBmEsgoepxDSEjNXLY = null;
					this.fnfTHHkNFYeyPWCfJczgdidnRcQW = -1;
					this.YlymUoXPUAdwKRIvGlFkwmNyXwaP = null;
					this.qzNBioIYInxwoiibFFelUmglFQzqA = ControllerType.Keyboard;
					this.kWzEXbMqBmqfEUazGzDLURlQBUbM = -1;
					this.OADcJigAecKRNIQelUlRxPZwVqAv = default(ControllerPollingInfo);
					this.BTOmjtTWkhaBbIVkKxHGBkesYWPc = ModifierKeyFlags.None;
				}

				// Token: 0x06000EE6 RID: 3814 RVA: 0x0000DA2D File Offset: 0x0000BC2D
				public ElementAssignment kLlllLqhqoBDseXLShWaALHGJjTu(ControllerPollingInfo A_1)
				{
					this.OADcJigAecKRNIQelUlRxPZwVqAv = A_1;
					return this.pjsjyNCCBCTEneNtRqbvUWcBhVLh();
				}

				// Token: 0x06000EE7 RID: 3815 RVA: 0x0000DA3C File Offset: 0x0000BC3C
				public ElementAssignment GiuprvRphNtcAkiemsgVhLgKbCRs(ControllerPollingInfo A_1, ModifierKeyFlags A_2)
				{
					this.OADcJigAecKRNIQelUlRxPZwVqAv = A_1;
					this.BTOmjtTWkhaBbIVkKxHGBkesYWPc = A_2;
					return this.pjsjyNCCBCTEneNtRqbvUWcBhVLh();
				}

				// Token: 0x06000EE8 RID: 3816 RVA: 0x0005496C File Offset: 0x00052B6C
				public ElementAssignment pjsjyNCCBCTEneNtRqbvUWcBhVLh()
				{
					return new ElementAssignment(this.lbdQTEChRkfKnndenTGlKujCDJWc, this.OADcJigAecKRNIQelUlRxPZwVqAv.elementType, this.OADcJigAecKRNIQelUlRxPZwVqAv.elementIdentifierId, this.GlKGUIzjxREHVWLTIZftujYHlHfw, this.OADcJigAecKRNIQelUlRxPZwVqAv.keyboardKey, this.BTOmjtTWkhaBbIVkKxHGBkesYWPc, this.fnfTHHkNFYeyPWCfJczgdidnRcQW, (this.YlymUoXPUAdwKRIvGlFkwmNyXwaP.actionRange == AxisRange.Negative) ? Pole.Negative : Pole.Positive, false, (this.YlymUoXPUAdwKRIvGlFkwmNyXwaP.actionElementMapToReplace != null) ? this.YlymUoXPUAdwKRIvGlFkwmNyXwaP.actionElementMapToReplace.id : -1);
				}

				// Token: 0x04000916 RID: 2326
				private Player KOrEqcdMSGxBmEsgoepxDSEjNXLY;

				// Token: 0x04000917 RID: 2327
				private int fnfTHHkNFYeyPWCfJczgdidnRcQW;

				// Token: 0x04000918 RID: 2328
				private InputMapper.Context YlymUoXPUAdwKRIvGlFkwmNyXwaP;

				// Token: 0x04000919 RID: 2329
				private ControllerType qzNBioIYInxwoiibFFelUmglFQzqA;

				// Token: 0x0400091A RID: 2330
				private int kWzEXbMqBmqfEUazGzDLURlQBUbM;

				// Token: 0x0400091B RID: 2331
				private ControllerPollingInfo OADcJigAecKRNIQelUlRxPZwVqAv;

				// Token: 0x0400091C RID: 2332
				private ModifierKeyFlags BTOmjtTWkhaBbIVkKxHGBkesYWPc;
			}

			// Token: 0x0200015E RID: 350
			[CompilerGenerated]
			private sealed class txwPXmvcmabZafDzUTRPlZAFUwnh
			{
				// Token: 0x06000EEA RID: 3818 RVA: 0x0000DA52 File Offset: 0x0000BC52
				internal bool UGTdHPzlAMNfeHjVvVTLCCUPhvzD(ElementAssignmentConflictInfo A_1)
				{
					return A_1.elementMapId == this.ZftaqwDRsofEUxZCzpMuoAteywhlA.id;
				}

				// Token: 0x0400091D RID: 2333
				public ActionElementMap ZftaqwDRsofEUxZCzpMuoAteywhlA;
			}

			// Token: 0x0200015F RID: 351
			[CompilerGenerated]
			private sealed class nKPGcMlUphBFCQTTrYfwzpjVJheK
			{
				// Token: 0x06000EEC RID: 3820 RVA: 0x0000DA68 File Offset: 0x0000BC68
				internal bool RXkCgDKBomAhiihJVUbJZHcfOUqfb(int A_1)
				{
					return this.rqsBczxBAeYMIFrnhuJVZpmdaexG.EclrGuOgMohZFbsDNPStcAfBSdbzB(this.hIoKidLKgJIqrfoJRhlMYLudsfGqA, this.UyNaYPFRoYpsWVqIxLIkeMPchQSdc, this.JuRRBjvKRgtpDdDOrDtLOtRzBZaw, A_1);
				}

				// Token: 0x0400091E RID: 2334
				public InputMapper.cBmFcYbmVxdegGSsjSAFLBSvQnyFB rqsBczxBAeYMIFrnhuJVZpmdaexG;

				// Token: 0x0400091F RID: 2335
				public ElementAssignmentInfo hIoKidLKgJIqrfoJRhlMYLudsfGqA;

				// Token: 0x04000920 RID: 2336
				public IList<ElementAssignmentConflictInfo> UyNaYPFRoYpsWVqIxLIkeMPchQSdc;

				// Token: 0x04000921 RID: 2337
				public bool JuRRBjvKRgtpDdDOrDtLOtRzBZaw;
			}
		}

		// Token: 0x02000160 RID: 352
		public class Options
		{
			// Token: 0x17000439 RID: 1081
			// (get) Token: 0x06000EED RID: 3821 RVA: 0x0000DA88 File Offset: 0x0000BC88
			// (set) Token: 0x06000EEE RID: 3822 RVA: 0x0000DA90 File Offset: 0x0000BC90
			public bool allowAxes
			{
				get
				{
					return this.uFkdiYEhgKpfnNctjPhldVvzbgXbA;
				}
				set
				{
					this.uFkdiYEhgKpfnNctjPhldVvzbgXbA = value;
				}
			}

			// Token: 0x1700043A RID: 1082
			// (get) Token: 0x06000EEF RID: 3823 RVA: 0x0000DA99 File Offset: 0x0000BC99
			// (set) Token: 0x06000EF0 RID: 3824 RVA: 0x0000DAA1 File Offset: 0x0000BCA1
			public bool allowButtons
			{
				get
				{
					return this.tdrEwDFeZzYsZOvviJYEIxOLaMWmA;
				}
				set
				{
					this.tdrEwDFeZzYsZOvviJYEIxOLaMWmA = value;
				}
			}

			// Token: 0x1700043B RID: 1083
			// (get) Token: 0x06000EF1 RID: 3825 RVA: 0x0000DAAA File Offset: 0x0000BCAA
			// (set) Token: 0x06000EF2 RID: 3826 RVA: 0x0000DAB2 File Offset: 0x0000BCB2
			public bool allowButtonsOnFullAxisAssignment
			{
				get
				{
					return this.RzChLDveiWkPOyCPYAaPFOZndpWV;
				}
				set
				{
					this.RzChLDveiWkPOyCPYAaPFOZndpWV = value;
				}
			}

			// Token: 0x1700043C RID: 1084
			// (get) Token: 0x06000EF3 RID: 3827 RVA: 0x0000DABB File Offset: 0x0000BCBB
			// (set) Token: 0x06000EF4 RID: 3828 RVA: 0x0000DAC3 File Offset: 0x0000BCC3
			public float timeout
			{
				get
				{
					return this.oCNTzJxpUeGDZYDKltjVHeGEIagO;
				}
				set
				{
					this.oCNTzJxpUeGDZYDKltjVHeGEIagO = MathTools.Max(0f, value);
				}
			}

			// Token: 0x1700043D RID: 1085
			// (get) Token: 0x06000EF5 RID: 3829 RVA: 0x0000DAD6 File Offset: 0x0000BCD6
			// (set) Token: 0x06000EF6 RID: 3830 RVA: 0x0000DADE File Offset: 0x0000BCDE
			public bool checkForConflicts
			{
				get
				{
					return this.WSOYqbuXAlsRJlzaTCfYyXSkBJbY;
				}
				set
				{
					this.WSOYqbuXAlsRJlzaTCfYyXSkBJbY = value;
				}
			}

			// Token: 0x1700043E RID: 1086
			// (get) Token: 0x06000EF7 RID: 3831 RVA: 0x0000DAE7 File Offset: 0x0000BCE7
			// (set) Token: 0x06000EF8 RID: 3832 RVA: 0x0000DAEF File Offset: 0x0000BCEF
			public bool checkForConflictsWithAllPlayers
			{
				get
				{
					return this.KNziYTCDfwZUTLDKBfqYdIoRzKPJA;
				}
				set
				{
					this.KNziYTCDfwZUTLDKBfqYdIoRzKPJA = value;
				}
			}

			// Token: 0x1700043F RID: 1087
			// (get) Token: 0x06000EF9 RID: 3833 RVA: 0x0000DAF8 File Offset: 0x0000BCF8
			// (set) Token: 0x06000EFA RID: 3834 RVA: 0x0000DB00 File Offset: 0x0000BD00
			public bool checkForConflictsWithSelf
			{
				get
				{
					return this.BBgqcrhfsSqGInoNHyIoazwMbdtN;
				}
				set
				{
					this.BBgqcrhfsSqGInoNHyIoazwMbdtN = value;
				}
			}

			// Token: 0x17000440 RID: 1088
			// (get) Token: 0x06000EFB RID: 3835 RVA: 0x0000DB09 File Offset: 0x0000BD09
			// (set) Token: 0x06000EFC RID: 3836 RVA: 0x0000DB11 File Offset: 0x0000BD11
			public bool checkForConflictsWithSystemPlayer
			{
				get
				{
					return this.dojBjeDchFkuNbrQBqDmDmFvoWxF;
				}
				set
				{
					this.dojBjeDchFkuNbrQBqDmDmFvoWxF = value;
				}
			}

			// Token: 0x17000441 RID: 1089
			// (get) Token: 0x06000EFD RID: 3837 RVA: 0x0000DB1A File Offset: 0x0000BD1A
			// (set) Token: 0x06000EFE RID: 3838 RVA: 0x0000DB22 File Offset: 0x0000BD22
			public int[] checkForConflictsWithPlayerIds
			{
				get
				{
					return this.UNganguPjJZfrlhLafkOfIivpMqfb;
				}
				set
				{
					this.UNganguPjJZfrlhLafkOfIivpMqfb = value;
				}
			}

			// Token: 0x17000442 RID: 1090
			// (get) Token: 0x06000EFF RID: 3839 RVA: 0x0000DB2B File Offset: 0x0000BD2B
			// (set) Token: 0x06000F00 RID: 3840 RVA: 0x0000DB33 File Offset: 0x0000BD33
			public InputMapper.ConflictResponse defaultActionWhenConflictFound
			{
				get
				{
					return this.wfWNCMPOibQWbpkFSofCMzsWEQrH;
				}
				set
				{
					this.wfWNCMPOibQWbpkFSofCMzsWEQrH = value;
				}
			}

			// Token: 0x17000443 RID: 1091
			// (get) Token: 0x06000F01 RID: 3841 RVA: 0x0000DB3C File Offset: 0x0000BD3C
			// (set) Token: 0x06000F02 RID: 3842 RVA: 0x0000DB44 File Offset: 0x0000BD44
			public bool ignoreMouseXAxis
			{
				get
				{
					return this.ihdglgmdbNniBkCsigthiTBhVaXVA;
				}
				set
				{
					this.ihdglgmdbNniBkCsigthiTBhVaXVA = value;
				}
			}

			// Token: 0x17000444 RID: 1092
			// (get) Token: 0x06000F03 RID: 3843 RVA: 0x0000DB4D File Offset: 0x0000BD4D
			// (set) Token: 0x06000F04 RID: 3844 RVA: 0x0000DB55 File Offset: 0x0000BD55
			public bool ignoreMouseYAxis
			{
				get
				{
					return this.ykhwevqEjBNPZasOJCbGqfHwPwuj;
				}
				set
				{
					this.ykhwevqEjBNPZasOJCbGqfHwPwuj = value;
				}
			}

			// Token: 0x17000445 RID: 1093
			// (get) Token: 0x06000F05 RID: 3845 RVA: 0x0000DB5E File Offset: 0x0000BD5E
			// (set) Token: 0x06000F06 RID: 3846 RVA: 0x0000DB66 File Offset: 0x0000BD66
			public bool allowKeyboardKeysWithModifiers
			{
				get
				{
					return this.LXGEhNsMopGpKJKTlbPimKMlqPYEb;
				}
				set
				{
					this.LXGEhNsMopGpKJKTlbPimKMlqPYEb = value;
				}
			}

			// Token: 0x17000446 RID: 1094
			// (get) Token: 0x06000F07 RID: 3847 RVA: 0x0000DB6F File Offset: 0x0000BD6F
			// (set) Token: 0x06000F08 RID: 3848 RVA: 0x0000DB77 File Offset: 0x0000BD77
			public bool allowKeyboardModifierKeyAsPrimary
			{
				get
				{
					return this.IYBoDccLTBYhktzSBEYQcjntxSJg;
				}
				set
				{
					this.IYBoDccLTBYhktzSBEYQcjntxSJg = value;
				}
			}

			// Token: 0x17000447 RID: 1095
			// (get) Token: 0x06000F09 RID: 3849 RVA: 0x0000DB80 File Offset: 0x0000BD80
			// (set) Token: 0x06000F0A RID: 3850 RVA: 0x0000DB88 File Offset: 0x0000BD88
			public float holdDurationToMapKeyboardModifierKeyAsPrimary
			{
				get
				{
					return this.GemTpTkDdTZNRMIgrucgGjpkkmIA;
				}
				set
				{
					this.GemTpTkDdTZNRMIgrucgGjpkkmIA = MathTools.Max(0f, value);
				}
			}

			// Token: 0x17000448 RID: 1096
			// (get) Token: 0x06000F0B RID: 3851 RVA: 0x0000DB9B File Offset: 0x0000BD9B
			// (set) Token: 0x06000F0C RID: 3852 RVA: 0x000549EC File Offset: 0x00052BEC
			public Predicate<ControllerPollingInfo> isElementAllowedCallback
			{
				get
				{
					return (SafePredicate<ControllerPollingInfo>)this.JciVZjfYuYnkVJVJruZHWghDmKdI["isElementAllowed"];
				}
				set
				{
					SafePredicate<ControllerPollingInfo> safePredicate = value;
					if (safePredicate != null)
					{
						safePredicate.ExceptionHandler = new Action<Exception>(InputMapper.Options.oIarAWCHWgKaxKkZCgpbMkIQdmSl.<>9.gPRHvzmGsVwPUQnUWwyDFUIRRnDM);
					}
					this.JciVZjfYuYnkVJVJruZHWghDmKdI["isElementAllowed"] = safePredicate;
				}
			}

			// Token: 0x06000F0D RID: 3853 RVA: 0x00054A3C File Offset: 0x00052C3C
			internal \u0001 yedXueUgOpURsqpkTGHbELCnmxBzA<\u0001>(string A_1) where \u0001 : SafeDelegate
			{
				SafeDelegate safeDelegate;
				if (!this.JciVZjfYuYnkVJVJruZHWghDmKdI.TryGetValue(A_1, out safeDelegate))
				{
					return default(\u0001);
				}
				return safeDelegate as \u0001;
			}

			// Token: 0x06000F0E RID: 3854 RVA: 0x00054A70 File Offset: 0x00052C70
			public Options()
			{
				this.viqfqeGepcpleHWVSLWMZODqBHCAA();
			}

			// Token: 0x06000F0F RID: 3855 RVA: 0x00054AF4 File Offset: 0x00052CF4
			private Options(InputMapper.Options A_1)
			{
				if (A_1 == null)
				{
					throw new ArgumentNullException("source");
				}
				InputMapper.Options.Copy(A_1, this);
			}

			// Token: 0x06000F10 RID: 3856 RVA: 0x0000DBB7 File Offset: 0x0000BDB7
			public InputMapper.Options Clone()
			{
				return new InputMapper.Options(this);
			}

			// Token: 0x06000F11 RID: 3857 RVA: 0x00054B84 File Offset: 0x00052D84
			public override string ToString()
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("Options:\n");
				stringBuilder.Append("allowAxes = " + this.uFkdiYEhgKpfnNctjPhldVvzbgXbA.ToString() + "\n");
				stringBuilder.Append("allowButtons = " + this.tdrEwDFeZzYsZOvviJYEIxOLaMWmA.ToString() + "\n");
				stringBuilder.Append("allowButtonsOnFullAxisAssignment = " + this.RzChLDveiWkPOyCPYAaPFOZndpWV.ToString() + "\n");
				stringBuilder.Append("timeout = " + this.oCNTzJxpUeGDZYDKltjVHeGEIagO.ToString() + "\n");
				stringBuilder.Append("checkForConflicts = " + this.WSOYqbuXAlsRJlzaTCfYyXSkBJbY.ToString() + "\n");
				stringBuilder.Append("checkForConflictsWithAllPlayers = " + this.KNziYTCDfwZUTLDKBfqYdIoRzKPJA.ToString() + "\n");
				stringBuilder.Append("checkForConflictsWithSelf = " + this.BBgqcrhfsSqGInoNHyIoazwMbdtN.ToString() + "\n");
				stringBuilder.Append("checkForConflictsWithSystemPlayer = " + this.dojBjeDchFkuNbrQBqDmDmFvoWxF.ToString() + "\n");
				if (this.UNganguPjJZfrlhLafkOfIivpMqfb == null)
				{
					stringBuilder.Append("_checkForConflictsWithPlayerIds = null\n");
				}
				else
				{
					stringBuilder.Append("_checkForConflictsWithPlayerIds = " + StringTools.ToString(this.UNganguPjJZfrlhLafkOfIivpMqfb) + "\n");
				}
				stringBuilder.Append("defaultActionWhenConflictFound = " + this.wfWNCMPOibQWbpkFSofCMzsWEQrH.ToString() + "\n");
				stringBuilder.Append("ignoreMouseXAxis = " + this.ihdglgmdbNniBkCsigthiTBhVaXVA.ToString());
				stringBuilder.Append("ignoreMouseYAxis = " + this.ykhwevqEjBNPZasOJCbGqfHwPwuj.ToString());
				stringBuilder.Append("allowKeyboardKeysWithModifiers = " + this.LXGEhNsMopGpKJKTlbPimKMlqPYEb.ToString() + "\n");
				stringBuilder.Append("allowKeyboardModifierAsPrimary = " + this.IYBoDccLTBYhktzSBEYQcjntxSJg.ToString() + "\n");
				stringBuilder.Append("holdDurationToMapKeyboardModifierKeyAsPrimary = " + this.GemTpTkDdTZNRMIgrucgGjpkkmIA.ToString() + "\n");
				return stringBuilder.ToString();
			}

			// Token: 0x06000F12 RID: 3858 RVA: 0x00054DAC File Offset: 0x00052FAC
			internal void viqfqeGepcpleHWVSLWMZODqBHCAA()
			{
				this.uFkdiYEhgKpfnNctjPhldVvzbgXbA = true;
				this.tdrEwDFeZzYsZOvviJYEIxOLaMWmA = true;
				this.RzChLDveiWkPOyCPYAaPFOZndpWV = true;
				this.oCNTzJxpUeGDZYDKltjVHeGEIagO = 0f;
				this.WSOYqbuXAlsRJlzaTCfYyXSkBJbY = true;
				this.KNziYTCDfwZUTLDKBfqYdIoRzKPJA = true;
				this.BBgqcrhfsSqGInoNHyIoazwMbdtN = true;
				this.dojBjeDchFkuNbrQBqDmDmFvoWxF = true;
				this.UNganguPjJZfrlhLafkOfIivpMqfb = null;
				this.wfWNCMPOibQWbpkFSofCMzsWEQrH = InputMapper.ConflictResponse.Replace;
				this.ihdglgmdbNniBkCsigthiTBhVaXVA = false;
				this.ykhwevqEjBNPZasOJCbGqfHwPwuj = false;
				this.LXGEhNsMopGpKJKTlbPimKMlqPYEb = true;
				this.IYBoDccLTBYhktzSBEYQcjntxSJg = true;
				this.GemTpTkDdTZNRMIgrucgGjpkkmIA = 1f;
				foreach (string key in new List<string>(this.JciVZjfYuYnkVJVJruZHWghDmKdI.Keys))
				{
					this.JciVZjfYuYnkVJVJruZHWghDmKdI[key] = null;
				}
			}

			// Token: 0x06000F13 RID: 3859 RVA: 0x00054E80 File Offset: 0x00053080
			public static void Copy(InputMapper.Options source, InputMapper.Options destination)
			{
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				if (destination == null)
				{
					throw new ArgumentNullException("destination");
				}
				destination.uFkdiYEhgKpfnNctjPhldVvzbgXbA = source.uFkdiYEhgKpfnNctjPhldVvzbgXbA;
				destination.tdrEwDFeZzYsZOvviJYEIxOLaMWmA = source.tdrEwDFeZzYsZOvviJYEIxOLaMWmA;
				destination.RzChLDveiWkPOyCPYAaPFOZndpWV = source.RzChLDveiWkPOyCPYAaPFOZndpWV;
				destination.oCNTzJxpUeGDZYDKltjVHeGEIagO = source.oCNTzJxpUeGDZYDKltjVHeGEIagO;
				destination.WSOYqbuXAlsRJlzaTCfYyXSkBJbY = source.WSOYqbuXAlsRJlzaTCfYyXSkBJbY;
				destination.KNziYTCDfwZUTLDKBfqYdIoRzKPJA = source.KNziYTCDfwZUTLDKBfqYdIoRzKPJA;
				destination.BBgqcrhfsSqGInoNHyIoazwMbdtN = source.BBgqcrhfsSqGInoNHyIoazwMbdtN;
				destination.dojBjeDchFkuNbrQBqDmDmFvoWxF = source.dojBjeDchFkuNbrQBqDmDmFvoWxF;
				destination.UNganguPjJZfrlhLafkOfIivpMqfb = ArrayTools.ShallowCopy<int>(source.UNganguPjJZfrlhLafkOfIivpMqfb);
				destination.wfWNCMPOibQWbpkFSofCMzsWEQrH = source.wfWNCMPOibQWbpkFSofCMzsWEQrH;
				destination.ihdglgmdbNniBkCsigthiTBhVaXVA = source.ihdglgmdbNniBkCsigthiTBhVaXVA;
				destination.ykhwevqEjBNPZasOJCbGqfHwPwuj = source.ykhwevqEjBNPZasOJCbGqfHwPwuj;
				destination.LXGEhNsMopGpKJKTlbPimKMlqPYEb = source.LXGEhNsMopGpKJKTlbPimKMlqPYEb;
				destination.IYBoDccLTBYhktzSBEYQcjntxSJg = source.IYBoDccLTBYhktzSBEYQcjntxSJg;
				destination.GemTpTkDdTZNRMIgrucgGjpkkmIA = source.GemTpTkDdTZNRMIgrucgGjpkkmIA;
				foreach (KeyValuePair<string, SafeDelegate> keyValuePair in source.JciVZjfYuYnkVJVJruZHWghDmKdI)
				{
					destination.JciVZjfYuYnkVJVJruZHWghDmKdI[keyValuePair.Key] = MiscTools.Clone<SafeDelegate>(keyValuePair.Value);
				}
			}

			// Token: 0x04000922 RID: 2338
			private bool uFkdiYEhgKpfnNctjPhldVvzbgXbA = true;

			// Token: 0x04000923 RID: 2339
			private bool tdrEwDFeZzYsZOvviJYEIxOLaMWmA = true;

			// Token: 0x04000924 RID: 2340
			private bool RzChLDveiWkPOyCPYAaPFOZndpWV = true;

			// Token: 0x04000925 RID: 2341
			private float oCNTzJxpUeGDZYDKltjVHeGEIagO;

			// Token: 0x04000926 RID: 2342
			private bool WSOYqbuXAlsRJlzaTCfYyXSkBJbY = true;

			// Token: 0x04000927 RID: 2343
			private bool KNziYTCDfwZUTLDKBfqYdIoRzKPJA = true;

			// Token: 0x04000928 RID: 2344
			private bool BBgqcrhfsSqGInoNHyIoazwMbdtN = true;

			// Token: 0x04000929 RID: 2345
			private bool dojBjeDchFkuNbrQBqDmDmFvoWxF = true;

			// Token: 0x0400092A RID: 2346
			private int[] UNganguPjJZfrlhLafkOfIivpMqfb;

			// Token: 0x0400092B RID: 2347
			private InputMapper.ConflictResponse wfWNCMPOibQWbpkFSofCMzsWEQrH = InputMapper.ConflictResponse.Replace;

			// Token: 0x0400092C RID: 2348
			private bool ihdglgmdbNniBkCsigthiTBhVaXVA;

			// Token: 0x0400092D RID: 2349
			private bool ykhwevqEjBNPZasOJCbGqfHwPwuj;

			// Token: 0x0400092E RID: 2350
			private bool LXGEhNsMopGpKJKTlbPimKMlqPYEb = true;

			// Token: 0x0400092F RID: 2351
			private bool IYBoDccLTBYhktzSBEYQcjntxSJg = true;

			// Token: 0x04000930 RID: 2352
			private float GemTpTkDdTZNRMIgrucgGjpkkmIA = 1f;

			// Token: 0x04000931 RID: 2353
			internal const string VhPheVQLJbFpSECXzWJbIkrTvtzsA = "isElementAllowed";

			// Token: 0x04000932 RID: 2354
			private readonly Dictionary<string, SafeDelegate> JciVZjfYuYnkVJVJruZHWghDmKdI = new Dictionary<string, SafeDelegate>
			{
				{
					"isElementAllowed",
					null
				}
			};

			// Token: 0x02000161 RID: 353
			[CompilerGenerated]
			[Serializable]
			private sealed class oIarAWCHWgKaxKkZCgpbMkIQdmSl
			{
				// Token: 0x06000F16 RID: 3862 RVA: 0x0000DBCB File Offset: 0x0000BDCB
				internal void gPRHvzmGsVwPUQnUWwyDFUIRRnDM(Exception A_1)
				{
					ReInput.HandleCallbackException("InputMapper.Options.isElementAllowedCallback", A_1);
				}

				// Token: 0x04000933 RID: 2355
				public static readonly InputMapper.Options.oIarAWCHWgKaxKkZCgpbMkIQdmSl <>9 = new InputMapper.Options.oIarAWCHWgKaxKkZCgpbMkIQdmSl();

				// Token: 0x04000934 RID: 2356
				public static Action<Exception> <>9__64_0;
			}
		}

		// Token: 0x02000162 RID: 354
		[CompilerGenerated]
		[Serializable]
		private sealed class uyCPGFpLAKdtFtHEjpgAvZDQrpTU
		{
			// Token: 0x06000F19 RID: 3865 RVA: 0x0000DBE4 File Offset: 0x0000BDE4
			internal void UFGKKZLBRhpcpAEasfXkioDxaOir(Exception A_1)
			{
				ReInput.HandleCallbackException("InputMapper.AssignedEvent", A_1);
			}

			// Token: 0x06000F1A RID: 3866 RVA: 0x0000DBF1 File Offset: 0x0000BDF1
			internal void reSJALRKkFBRUkqMgxSdETELUinn(Exception A_1)
			{
				ReInput.HandleCallbackException("InputMapper.ErrorEvent", A_1);
			}

			// Token: 0x06000F1B RID: 3867 RVA: 0x0000DBFE File Offset: 0x0000BDFE
			internal void XwPCxkdhyzAnFrXeOBeacvcCTQcTA(Exception A_1)
			{
				ReInput.HandleCallbackException("InputMapper.CanceledEvent", A_1);
			}

			// Token: 0x06000F1C RID: 3868 RVA: 0x0000DC0B File Offset: 0x0000BE0B
			internal void uGNSOEThrElCxhOkjhLGpahxNenm(Exception A_1)
			{
				ReInput.HandleCallbackException("InputMapper.TimedOutEvent", A_1);
			}

			// Token: 0x06000F1D RID: 3869 RVA: 0x0000DC18 File Offset: 0x0000BE18
			internal void MtiATGSYjHlpiysYiMWfrACZxzaN(Exception A_1)
			{
				ReInput.HandleCallbackException("InputMapper.StartedEvent", A_1);
			}

			// Token: 0x06000F1E RID: 3870 RVA: 0x0000DC25 File Offset: 0x0000BE25
			internal void PDtAMmfVqvYqMjFpeyfKoStcnwuUA(Exception A_1)
			{
				ReInput.HandleCallbackException("InputMapper.StoppedEvent", A_1);
			}

			// Token: 0x06000F1F RID: 3871 RVA: 0x0000DC32 File Offset: 0x0000BE32
			internal void sRvhxtdDEMtcWlXXxKYuaXtSfwAU(Exception A_1)
			{
				ReInput.HandleCallbackException("InputMapper.ConflictFoundEvent", A_1);
			}

			// Token: 0x04000935 RID: 2357
			public static readonly InputMapper.uyCPGFpLAKdtFtHEjpgAvZDQrpTU <>9 = new InputMapper.uyCPGFpLAKdtFtHEjpgAvZDQrpTU();

			// Token: 0x04000936 RID: 2358
			public static Action<Exception> <>9__54_0;

			// Token: 0x04000937 RID: 2359
			public static Action<Exception> <>9__54_1;

			// Token: 0x04000938 RID: 2360
			public static Action<Exception> <>9__54_2;

			// Token: 0x04000939 RID: 2361
			public static Action<Exception> <>9__54_3;

			// Token: 0x0400093A RID: 2362
			public static Action<Exception> <>9__54_4;

			// Token: 0x0400093B RID: 2363
			public static Action<Exception> <>9__54_5;

			// Token: 0x0400093C RID: 2364
			public static Action<Exception> <>9__54_6;
		}
	}
}
