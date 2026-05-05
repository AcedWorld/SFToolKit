using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Interfaces;
using Rewired.Internal.Glyphs;
using Rewired.Internal.Localization;
using UnityEngine;

namespace Rewired
{
	// Token: 0x02000117 RID: 279
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[Serializable]
	public sealed class ControllerElementIdentifier : IControllerElementIdentifierCommon_Internal, djBPDCJyutcYSKkwfSFUMNGNGZXU, lcAibZuWMerLyEDicYNSneVLTvsj, fjbgpVwttnDrmmsUrHYXoyGuYHCH, VHSvqsZIGaGVcFIeminrliAGzvFf, dTljyMAPERKafkOoLqFGgRwgjxLO, oLkCONlJZKYzXoJthulbVunIVBjF
	{
		// Token: 0x170002FE RID: 766
		// (get) Token: 0x06000A4A RID: 2634 RVA: 0x0000A45A File Offset: 0x0000865A
		public int id
		{
			get
			{
				return this._id;
			}
		}

		// Token: 0x170002FF RID: 767
		// (get) Token: 0x06000A4B RID: 2635 RVA: 0x0000A462 File Offset: 0x00008662
		// (set) Token: 0x06000A4C RID: 2636 RVA: 0x0000A48C File Offset: 0x0000868C
		public string name
		{
			get
			{
				if (!ReInput.isReady || this.WBfdboaRxMcibcKUBAtEFVqMilEAb == null || !LocalizationManager.isEnabled)
				{
					return this._name;
				}
				return this.WBfdboaRxMcibcKUBAtEFVqMilEAb.QGZglKMnBTLJKJKOPknbgTZKPbAO;
			}
			internal set
			{
				this.nonLocalizedName = value;
			}
		}

		// Token: 0x17000300 RID: 768
		// (get) Token: 0x06000A4D RID: 2637 RVA: 0x0000A495 File Offset: 0x00008695
		// (set) Token: 0x06000A4E RID: 2638 RVA: 0x0000A4BF File Offset: 0x000086BF
		public string positiveName
		{
			get
			{
				if (!ReInput.isReady || this.WBfdboaRxMcibcKUBAtEFVqMilEAb == null || !LocalizationManager.isEnabled)
				{
					return this._positiveName;
				}
				return this.WBfdboaRxMcibcKUBAtEFVqMilEAb.ouKRfZfTiXAAdpWYEfuBzPMgociw;
			}
			internal set
			{
				this.nonLocalizedPositiveName = value;
			}
		}

		// Token: 0x17000301 RID: 769
		// (get) Token: 0x06000A4F RID: 2639 RVA: 0x0000A4C8 File Offset: 0x000086C8
		// (set) Token: 0x06000A50 RID: 2640 RVA: 0x0000A4F2 File Offset: 0x000086F2
		public string negativeName
		{
			get
			{
				if (!ReInput.isReady || this.WBfdboaRxMcibcKUBAtEFVqMilEAb == null || !LocalizationManager.isEnabled)
				{
					return this._negativeName;
				}
				return this.WBfdboaRxMcibcKUBAtEFVqMilEAb.AHaXPYUQTomysBARqTqPHTZSHXpe;
			}
			internal set
			{
				this.nonLocalizedNegativeName = value;
			}
		}

		// Token: 0x06000A51 RID: 2641 RVA: 0x0000A4FB File Offset: 0x000086FB
		internal string GetCompoundElementSpecialName(int index)
		{
			if (!ReInput.isReady || !LocalizationManager.isEnabled || this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe == null || this.ETNCixCtOOkeYgWbZVOkFpanTjrR == null)
			{
				return string.Empty;
			}
			return this.ETNCixCtOOkeYgWbZVOkFpanTjrR.KVPPiJXooHbsQHcHvBzittZRUWnE(index);
		}

		// Token: 0x17000302 RID: 770
		// (get) Token: 0x06000A52 RID: 2642 RVA: 0x0000A52D File Offset: 0x0000872D
		public ControllerElementType elementType
		{
			get
			{
				return this._elementType;
			}
		}

		// Token: 0x17000303 RID: 771
		// (get) Token: 0x06000A53 RID: 2643 RVA: 0x0000A535 File Offset: 0x00008735
		public CompoundControllerElementType compoundElementType
		{
			get
			{
				return this._compoundElementType;
			}
		}

		// Token: 0x17000304 RID: 772
		// (get) Token: 0x06000A54 RID: 2644 RVA: 0x0000A53D File Offset: 0x0000873D
		public object glyph
		{
			get
			{
				if (!ReInput.isReady || this.PHDoSpUdZleuUqnxcjhCjrigCRKCA == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return this.PHDoSpUdZleuUqnxcjhCjrigCRKCA.RrcQSnGZhLUWaACyTfIVqhfeHwoH;
			}
		}

		// Token: 0x17000305 RID: 773
		// (get) Token: 0x06000A55 RID: 2645 RVA: 0x0000A562 File Offset: 0x00008762
		public object positiveGlyph
		{
			get
			{
				if (!ReInput.isReady || this.PHDoSpUdZleuUqnxcjhCjrigCRKCA == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return this.PHDoSpUdZleuUqnxcjhCjrigCRKCA.aTSgNbktJUnntkjgYbPIRiEjCQVm;
			}
		}

		// Token: 0x17000306 RID: 774
		// (get) Token: 0x06000A56 RID: 2646 RVA: 0x0000A587 File Offset: 0x00008787
		public object negativeGlyph
		{
			get
			{
				if (!ReInput.isReady || this.PHDoSpUdZleuUqnxcjhCjrigCRKCA == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return this.PHDoSpUdZleuUqnxcjhCjrigCRKCA.ajimpxGOjebSamduDdhWkLKRfGwIA;
			}
		}

		// Token: 0x17000307 RID: 775
		// (get) Token: 0x06000A57 RID: 2647 RVA: 0x0000A5AC File Offset: 0x000087AC
		private string finalGlyphKey
		{
			get
			{
				if (!ReInput.isReady || this.PHDoSpUdZleuUqnxcjhCjrigCRKCA == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return this.PHDoSpUdZleuUqnxcjhCjrigCRKCA.IbkdqazTmRJXXakoWTyynULrgVYm;
			}
		}

		// Token: 0x17000308 RID: 776
		// (get) Token: 0x06000A58 RID: 2648 RVA: 0x0000A5D1 File Offset: 0x000087D1
		private string finalPositiveGlyphKey
		{
			get
			{
				if (!ReInput.isReady || this.PHDoSpUdZleuUqnxcjhCjrigCRKCA == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return this.PHDoSpUdZleuUqnxcjhCjrigCRKCA.COhBviegEUiqjtNqOyGqtwxdHdwn;
			}
		}

		// Token: 0x17000309 RID: 777
		// (get) Token: 0x06000A59 RID: 2649 RVA: 0x0000A5F6 File Offset: 0x000087F6
		private string finalNegativeGlyphKey
		{
			get
			{
				if (!ReInput.isReady || this.PHDoSpUdZleuUqnxcjhCjrigCRKCA == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return this.PHDoSpUdZleuUqnxcjhCjrigCRKCA.FvxfyRckRinNtummBgbbdgdivvrmb;
			}
		}

		// Token: 0x06000A5A RID: 2650 RVA: 0x0000A61B File Offset: 0x0000881B
		internal object GetCompoundElementSpecialGlyph(int index)
		{
			if (!ReInput.isReady || !GlyphManager.isEnabled || this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe == null || this.ydWCklPPQXkDyJwpwOGUalzIlTQn == null)
			{
				return null;
			}
			return this.ydWCklPPQXkDyJwpwOGUalzIlTQn.PRLSSyeXdESxIftyzmIwLlPhNBRd(index);
		}

		// Token: 0x06000A5B RID: 2651 RVA: 0x0000A649 File Offset: 0x00008849
		internal string GetCompoundElementSpecialFinalGlyphKey(int index)
		{
			if (!ReInput.isReady || !GlyphManager.isEnabled || this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe == null || this.ydWCklPPQXkDyJwpwOGUalzIlTQn == null)
			{
				return null;
			}
			return this.ydWCklPPQXkDyJwpwOGUalzIlTQn.PCsRLWEutmOvWjqRtcZFZyoVbAON(index);
		}

		// Token: 0x1700030A RID: 778
		// (get) Token: 0x06000A5C RID: 2652 RVA: 0x0000A677 File Offset: 0x00008877
		// (set) Token: 0x06000A5D RID: 2653 RVA: 0x0000A67F File Offset: 0x0000887F
		internal string nonLocalizedName
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
				if (!ReInput.isReady)
				{
					return;
				}
				this.fqrtEHWIGccszFEUCjgSFeyPTvxH();
				if (this.WBfdboaRxMcibcKUBAtEFVqMilEAb != null)
				{
					this.WBfdboaRxMcibcKUBAtEFVqMilEAb.OlcAFIbuEHvUomQdyRvLXKoljCWJ();
				}
			}
		}

		// Token: 0x1700030B RID: 779
		// (get) Token: 0x06000A5E RID: 2654 RVA: 0x0000A6A9 File Offset: 0x000088A9
		// (set) Token: 0x06000A5F RID: 2655 RVA: 0x0000A6B1 File Offset: 0x000088B1
		internal string nonLocalizedPositiveName
		{
			get
			{
				return this._positiveName;
			}
			set
			{
				this._positiveName = value;
				if (!ReInput.isReady)
				{
					return;
				}
				this.fqrtEHWIGccszFEUCjgSFeyPTvxH();
				if (this.WBfdboaRxMcibcKUBAtEFVqMilEAb != null)
				{
					this.WBfdboaRxMcibcKUBAtEFVqMilEAb.hEFzpZMEhaJYzHkMYgtFIevqGShY();
				}
			}
		}

		// Token: 0x1700030C RID: 780
		// (get) Token: 0x06000A60 RID: 2656 RVA: 0x0000A6DB File Offset: 0x000088DB
		// (set) Token: 0x06000A61 RID: 2657 RVA: 0x0000A6E3 File Offset: 0x000088E3
		internal string nonLocalizedNegativeName
		{
			get
			{
				return this._negativeName;
			}
			set
			{
				this._negativeName = value;
				if (!ReInput.isReady)
				{
					return;
				}
				this.fqrtEHWIGccszFEUCjgSFeyPTvxH();
				if (this.WBfdboaRxMcibcKUBAtEFVqMilEAb != null)
				{
					this.WBfdboaRxMcibcKUBAtEFVqMilEAb.UhCcgieCihFlYvAACQRSZOqugFYbb();
				}
			}
		}

		// Token: 0x1700030D RID: 781
		// (get) Token: 0x06000A62 RID: 2658 RVA: 0x0000A70D File Offset: 0x0000890D
		public string key
		{
			get
			{
				return this._key;
			}
		}

		// Token: 0x1700030E RID: 782
		// (get) Token: 0x06000A63 RID: 2659 RVA: 0x0000A715 File Offset: 0x00008915
		public string positiveKey
		{
			get
			{
				return this._positiveKey;
			}
		}

		// Token: 0x1700030F RID: 783
		// (get) Token: 0x06000A64 RID: 2660 RVA: 0x0000A71D File Offset: 0x0000891D
		public string negativeKey
		{
			get
			{
				return this._negativeKey;
			}
		}

		// Token: 0x17000310 RID: 784
		// (get) Token: 0x06000A65 RID: 2661 RVA: 0x0000A725 File Offset: 0x00008925
		internal bool isCompoundElement
		{
			get
			{
				return this._elementType == ControllerElementType.CompoundElement;
			}
		}

		// Token: 0x17000311 RID: 785
		// (get) Token: 0x06000A66 RID: 2662 RVA: 0x0000A731 File Offset: 0x00008931
		string IControllerElementIdentifierCommon_Internal.nonLocalizedName
		{
			get
			{
				return this.nonLocalizedName;
			}
		}

		// Token: 0x17000312 RID: 786
		// (get) Token: 0x06000A67 RID: 2663 RVA: 0x0000A739 File Offset: 0x00008939
		string IControllerElementIdentifierCommon_Internal.nonLocalizedPositiveName
		{
			get
			{
				return this.nonLocalizedPositiveName;
			}
		}

		// Token: 0x17000313 RID: 787
		// (get) Token: 0x06000A68 RID: 2664 RVA: 0x0000A741 File Offset: 0x00008941
		string IControllerElementIdentifierCommon_Internal.nonLocalizedNegativeName
		{
			get
			{
				return this.nonLocalizedNegativeName;
			}
		}

		// Token: 0x06000A69 RID: 2665 RVA: 0x0000A749 File Offset: 0x00008949
		string IControllerElementIdentifierCommon_Internal.GetSpecialElementNonLocalizedName(int index)
		{
			if (this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe == null || index >= this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe.Count)
			{
				return null;
			}
			return this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe[index].FTVwzGuwFTfxcGYBzWzYwJPQpzdf;
		}

		// Token: 0x17000314 RID: 788
		// (get) Token: 0x06000A6A RID: 2666 RVA: 0x0000A774 File Offset: 0x00008974
		bool IControllerElementIdentifierCommon_Internal.isNonLocalizedPositiveNameAutoGenerated
		{
			get
			{
				return (this.IVozUpKFDxlFzTMzryndMevdLcyh & 2) != 0;
			}
		}

		// Token: 0x17000315 RID: 789
		// (get) Token: 0x06000A6B RID: 2667 RVA: 0x0000A781 File Offset: 0x00008981
		bool IControllerElementIdentifierCommon_Internal.isNonLocalizedNegativeNameAutoGenerated
		{
			get
			{
				return (this.IVozUpKFDxlFzTMzryndMevdLcyh & 4) != 0;
			}
		}

		// Token: 0x17000316 RID: 790
		// (get) Token: 0x06000A6C RID: 2668 RVA: 0x0000A78E File Offset: 0x0000898E
		bool IControllerElementIdentifierCommon_Internal.isPositiveKeyAutoGenerated
		{
			get
			{
				return (this.IVozUpKFDxlFzTMzryndMevdLcyh & 8) != 0;
			}
		}

		// Token: 0x17000317 RID: 791
		// (get) Token: 0x06000A6D RID: 2669 RVA: 0x0000A79B File Offset: 0x0000899B
		bool IControllerElementIdentifierCommon_Internal.isNegativeKeyAutoGenerated
		{
			get
			{
				return (this.IVozUpKFDxlFzTMzryndMevdLcyh & 16) != 0;
			}
		}

		// Token: 0x17000318 RID: 792
		// (get) Token: 0x06000A6E RID: 2670 RVA: 0x0000A70D File Offset: 0x0000890D
		string IControllerElementIdentifierCommon_Internal.key
		{
			get
			{
				return this._key;
			}
		}

		// Token: 0x17000319 RID: 793
		// (get) Token: 0x06000A6F RID: 2671 RVA: 0x0000A715 File Offset: 0x00008915
		string IControllerElementIdentifierCommon_Internal.positiveKey
		{
			get
			{
				return this._positiveKey;
			}
		}

		// Token: 0x1700031A RID: 794
		// (get) Token: 0x06000A70 RID: 2672 RVA: 0x0000A71D File Offset: 0x0000891D
		string IControllerElementIdentifierCommon_Internal.negativeKey
		{
			get
			{
				return this._negativeKey;
			}
		}

		// Token: 0x06000A71 RID: 2673 RVA: 0x0000A7A9 File Offset: 0x000089A9
		string IControllerElementIdentifierCommon_Internal.GetSpecialElementKey(int index)
		{
			if (this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe == null || index >= this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe.Count)
			{
				return null;
			}
			return this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe[index].RkRHcNeBAtkZAwVpJEIVvEQjrJNs;
		}

		// Token: 0x1700031B RID: 795
		// (get) Token: 0x06000A72 RID: 2674 RVA: 0x0000A7D4 File Offset: 0x000089D4
		DeviceLocalizationInfo IControllerElementIdentifierCommon_Internal.deviceLocalizationInfo
		{
			get
			{
				return this.vlbFvwLeDngusTjukCVVbhoYCdui;
			}
		}

		// Token: 0x06000A73 RID: 2675 RVA: 0x000033F4 File Offset: 0x000015F4
		public ControllerElementIdentifier()
		{
		}

		// Token: 0x06000A74 RID: 2676 RVA: 0x00047EE8 File Offset: 0x000460E8
		public ControllerElementIdentifier(ControllerElementIdentifier A_1)
		{
			this._id = A_1._id;
			this._name = A_1._name;
			this._positiveName = A_1._positiveName;
			this._negativeName = A_1._negativeName;
			this._key = A_1._key;
			this._positiveKey = A_1._positiveKey;
			this._negativeKey = A_1._negativeKey;
			this._elementType = A_1._elementType;
			this._compoundElementType = A_1._compoundElementType;
			if (A_1.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe != null)
			{
				int count = A_1.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe.Count;
				this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe = new List<ControllerElementIdentifier.wZEgKEJSRBVkIHlLhliLcQEYydwU>(count);
				for (int i = 0; i < count; i++)
				{
					if (A_1.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe[i] != null)
					{
						this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe.Add(new ControllerElementIdentifier.wZEgKEJSRBVkIHlLhliLcQEYydwU(A_1.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe[i]));
					}
				}
			}
			this.IVozUpKFDxlFzTMzryndMevdLcyh = A_1.IVozUpKFDxlFzTMzryndMevdLcyh;
			this.ypisbKfXXFjntrbZRtOPeATsKUAK = A_1.ypisbKfXXFjntrbZRtOPeATsKUAK;
		}

		// Token: 0x06000A75 RID: 2677 RVA: 0x00047FD8 File Offset: 0x000461D8
		internal ControllerElementIdentifier(ControllerElementIdentifier.vNIqbrYzBBGsknBKgoQEcoARaWps A_1)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("initOptions");
			}
			this._id = A_1.id;
			this._name = A_1.name;
			this._positiveName = A_1.positiveName;
			this._negativeName = A_1.negativeName;
			this._key = A_1.key;
			this._positiveKey = A_1.positiveKey;
			this._negativeKey = A_1.negativeKey;
			this._elementType = A_1.elementType;
			this._compoundElementType = A_1.compoundElementType;
		}

		// Token: 0x06000A76 RID: 2678 RVA: 0x00048068 File Offset: 0x00046268
		[Obsolete("Used by plugins for mouse controllers. Left for plugin compatibility. Do not use.", false)]
		internal ControllerElementIdentifier(int A_1, string A_2, string A_3, string A_4, ControllerElementType A_5, CompoundControllerElementType A_6, bool A_7)
		{
			this._id = A_1;
			this._name = A_2;
			this._positiveName = A_3;
			this._negativeName = A_4;
			if (A_1 < Consts.commonMouseElementIdentifierInitOptions.Length && string.Equals(Consts.commonMouseElementIdentifierInitOptions[A_1].name, A_2, StringComparison.Ordinal))
			{
				this._key = Consts.commonMouseElementIdentifierInitOptions[A_1].key;
				this._positiveKey = Consts.commonMouseElementIdentifierInitOptions[A_1].key;
				this._negativeKey = Consts.commonMouseElementIdentifierInitOptions[A_1].key;
			}
			this._elementType = A_5;
			this._compoundElementType = A_6;
		}

		// Token: 0x06000A77 RID: 2679 RVA: 0x00048100 File Offset: 0x00046300
		[Obsolete("Used by UnifiedKeyboardSource. Left for plugin compatibility. Do not use.", false)]
		internal ControllerElementIdentifier(int A_1, string A_2, string A_3, string A_4, ControllerElementType A_5, bool A_6)
		{
			this._id = A_1;
			this._name = A_2;
			this._positiveName = A_3;
			this._negativeName = A_4;
			if (A_5 == ControllerElementType.Button && A_1 < Consts.keyboardKeyNames.Count && string.Equals(Consts.keyboardKeyNames[A_1], A_2, StringComparison.Ordinal))
			{
				this._key = Consts.keyboardKeyKeys[A_1];
			}
			this._elementType = A_5;
			this._compoundElementType = CompoundControllerElementType.Axis2D;
		}

		// Token: 0x06000A78 RID: 2680 RVA: 0x0000A7DC File Offset: 0x000089DC
		internal ControllerElementIdentifier(ControllerElementIdentifier A_1, bool A_2, ControllerElementType A_3) : this(A_1)
		{
			this._elementType = A_3;
		}

		// Token: 0x06000A79 RID: 2681 RVA: 0x0000A7EC File Offset: 0x000089EC
		public ControllerElementIdentifier Clone()
		{
			return new ControllerElementIdentifier(this);
		}

		// Token: 0x06000A7A RID: 2682 RVA: 0x00048178 File Offset: 0x00046378
		public string GetDisplayName(ControllerElementType actualElementType, AxisRange axisRange)
		{
			if (actualElementType != ControllerElementType.Axis)
			{
				if (actualElementType == ControllerElementType.Button)
				{
					return this.name;
				}
				if (actualElementType != ControllerElementType.CompoundElement)
				{
					throw new NotImplementedException();
				}
				return this.name;
			}
			else
			{
				switch (axisRange)
				{
				case AxisRange.Full:
					return this.name;
				case AxisRange.Positive:
					return this.positiveName;
				case AxisRange.Negative:
					return this.negativeName;
				default:
					throw new NotImplementedException();
				}
			}
		}

		// Token: 0x06000A7B RID: 2683 RVA: 0x0000A7F4 File Offset: 0x000089F4
		public string GetDisplayName(AxisRange axisRange)
		{
			return this.GetDisplayName(this._elementType, axisRange);
		}

		// Token: 0x06000A7C RID: 2684 RVA: 0x000481D8 File Offset: 0x000463D8
		public object GetGlyph(ControllerElementType actualElementType, AxisRange axisRange)
		{
			if (actualElementType != ControllerElementType.Axis)
			{
				if (actualElementType == ControllerElementType.Button)
				{
					return this.glyph;
				}
				if (actualElementType != ControllerElementType.CompoundElement)
				{
					throw new NotImplementedException();
				}
				return this.glyph;
			}
			else
			{
				switch (axisRange)
				{
				case AxisRange.Full:
					return this.glyph;
				case AxisRange.Positive:
					return this.positiveGlyph;
				case AxisRange.Negative:
					return this.negativeGlyph;
				default:
					throw new NotImplementedException();
				}
			}
		}

		// Token: 0x06000A7D RID: 2685 RVA: 0x0000A803 File Offset: 0x00008A03
		public object GetGlyph(AxisRange axisRange)
		{
			return this.GetGlyph(this._elementType, axisRange);
		}

		// Token: 0x06000A7E RID: 2686 RVA: 0x00048238 File Offset: 0x00046438
		public string GetFinalGlyphKey(ControllerElementType actualElementType, AxisRange axisRange)
		{
			if (actualElementType != ControllerElementType.Axis)
			{
				if (actualElementType == ControllerElementType.Button)
				{
					return this.finalGlyphKey;
				}
				if (actualElementType != ControllerElementType.CompoundElement)
				{
					throw new NotImplementedException();
				}
				return this.finalGlyphKey;
			}
			else
			{
				switch (axisRange)
				{
				case AxisRange.Full:
					return this.finalGlyphKey;
				case AxisRange.Positive:
					return this.finalPositiveGlyphKey;
				case AxisRange.Negative:
					return this.finalNegativeGlyphKey;
				default:
					throw new NotImplementedException();
				}
			}
		}

		// Token: 0x06000A7F RID: 2687 RVA: 0x0000A812 File Offset: 0x00008A12
		public string GetFinalGlyphKey(AxisRange axisRange)
		{
			return this.GetFinalGlyphKey(this._elementType, axisRange);
		}

		// Token: 0x1700031C RID: 796
		// (get) Token: 0x06000A80 RID: 2688 RVA: 0x0000A821 File Offset: 0x00008A21
		object IControllerElementIdentifierCommon_Internal.elementType
		{
			get
			{
				return this._elementType;
			}
		}

		// Token: 0x1700031D RID: 797
		// (get) Token: 0x06000A81 RID: 2689 RVA: 0x00003E2B File Offset: 0x0000202B
		bool IControllerElementIdentifierCommon_Internal.useEditorElementTypeOverride
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700031E RID: 798
		// (get) Token: 0x06000A82 RID: 2690 RVA: 0x0000A52D File Offset: 0x0000872D
		ControllerElementType IControllerElementIdentifierCommon_Internal.editorElementTypeOverride
		{
			get
			{
				return this._elementType;
			}
		}

		// Token: 0x06000A83 RID: 2691 RVA: 0x0000A82E File Offset: 0x00008A2E
		private void fqrtEHWIGccszFEUCjgSFeyPTvxH()
		{
			if (this.QvzTGIDiQzstCBcPAzRLomfECKRIA)
			{
				throw new Exception("The object is marked readonly and you are trying to modify its values.");
			}
		}

		// Token: 0x06000A84 RID: 2692 RVA: 0x00048298 File Offset: 0x00046498
		internal void FinishRuntimeSetup(DeviceLocalizationInfo deviceLocalizationInfo, ControllerType controllerType)
		{
			this.ypisbKfXXFjntrbZRtOPeATsKUAK = controllerType;
			VhrRjYDSXtDmPGPepEmutTeotlnr.wBVDEckclaCUdHrHdLHuTDoxJWNc wBVDEckclaCUdHrHdLHuTDoxJWNc;
			VhrRjYDSXtDmPGPepEmutTeotlnr.ZqaUXWpANFaPfdXDRaVZzDjduZzZ zqaUXWpANFaPfdXDRaVZzDjduZzZ;
			ControllerElementIdentifier.ToElementNameLocalizerTypes(this._elementType, this._compoundElementType, out wBVDEckclaCUdHrHdLHuTDoxJWNc, out zqaUXWpANFaPfdXDRaVZzDjduZzZ);
			int num = VhrRjYDSXtDmPGPepEmutTeotlnr.TdchWUliZEyAPBEjbXHfPlHoLBTd(wBVDEckclaCUdHrHdLHuTDoxJWNc, zqaUXWpANFaPfdXDRaVZzDjduZzZ);
			if (num > 0)
			{
				this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe = new List<ControllerElementIdentifier.wZEgKEJSRBVkIHlLhliLcQEYydwU>(num);
				for (int i = 0; i < num; i++)
				{
					this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe.Add(new ControllerElementIdentifier.wZEgKEJSRBVkIHlLhliLcQEYydwU());
				}
			}
			this.vlbFvwLeDngusTjukCVVbhoYCdui = deviceLocalizationInfo;
			this.WBfdboaRxMcibcKUBAtEFVqMilEAb = hCXDpuHRLUFuvmVifjlUHPdRgCdY.mUttHISaqnMztGpFXTVIpEwUMqoj(this, aIgzybSrpFHIbiUgoNExgtkiaahP.OdziduRxdrBAnKCQEaAHjFHZSGBeb(controllerType), wBVDEckclaCUdHrHdLHuTDoxJWNc, zqaUXWpANFaPfdXDRaVZzDjduZzZ, this._id, deviceLocalizationInfo);
			this.PHDoSpUdZleuUqnxcjhCjrigCRKCA = QcieCxwEzKhTJEpEnbzfGmQUosAm.AIkzYBavzyNjeDRpoImVzGiVjwVP(this, aIgzybSrpFHIbiUgoNExgtkiaahP.OdziduRxdrBAnKCQEaAHjFHZSGBeb(controllerType), wBVDEckclaCUdHrHdLHuTDoxJWNc, zqaUXWpANFaPfdXDRaVZzDjduZzZ, this._id, deviceLocalizationInfo);
			if (this._elementType == ControllerElementType.CompoundElement)
			{
				this.ETNCixCtOOkeYgWbZVOkFpanTjrR = USiPXXLGXPFEcgQzLFiSdGGeGdfT.vpDtqeluwXqOQxMslepLcWCygNMi(this, aIgzybSrpFHIbiUgoNExgtkiaahP.OdziduRxdrBAnKCQEaAHjFHZSGBeb(controllerType), wBVDEckclaCUdHrHdLHuTDoxJWNc, zqaUXWpANFaPfdXDRaVZzDjduZzZ, this._id, deviceLocalizationInfo);
				this.ydWCklPPQXkDyJwpwOGUalzIlTQn = OloYVEiPyubyINOXSBORFBRAgOFC.OrolycsynFfPbblUXYFenyCQWkim(this, aIgzybSrpFHIbiUgoNExgtkiaahP.OdziduRxdrBAnKCQEaAHjFHZSGBeb(controllerType), wBVDEckclaCUdHrHdLHuTDoxJWNc, zqaUXWpANFaPfdXDRaVZzDjduZzZ, this._id, deviceLocalizationInfo);
			}
		}

		// Token: 0x1700031F RID: 799
		// (get) Token: 0x06000A85 RID: 2693 RVA: 0x0000A843 File Offset: 0x00008A43
		internal static ControllerElementIdentifier BlankReadOnly
		{
			get
			{
				if (ControllerElementIdentifier.tbnmFVZSCHBqLWWcIuavTRzAorWD == null)
				{
					ControllerElementIdentifier controllerElementIdentifier = new ControllerElementIdentifier();
					controllerElementIdentifier._id = -1;
					controllerElementIdentifier.QvzTGIDiQzstCBcPAzRLomfECKRIA = true;
					ControllerElementIdentifier.tbnmFVZSCHBqLWWcIuavTRzAorWD = controllerElementIdentifier;
					return controllerElementIdentifier;
				}
				return ControllerElementIdentifier.tbnmFVZSCHBqLWWcIuavTRzAorWD;
			}
		}

		// Token: 0x06000A86 RID: 2694 RVA: 0x00048374 File Offset: 0x00046574
		internal static void ToElementNameLocalizerTypes(ControllerElementType type, CompoundControllerElementType compoundType, out VhrRjYDSXtDmPGPepEmutTeotlnr.wBVDEckclaCUdHrHdLHuTDoxJWNc resultElementType, out VhrRjYDSXtDmPGPepEmutTeotlnr.ZqaUXWpANFaPfdXDRaVZzDjduZzZ resultCompoundElementType)
		{
			resultCompoundElementType = VhrRjYDSXtDmPGPepEmutTeotlnr.ZqaUXWpANFaPfdXDRaVZzDjduZzZ.None;
			if (type == ControllerElementType.Axis)
			{
				resultElementType = VhrRjYDSXtDmPGPepEmutTeotlnr.wBVDEckclaCUdHrHdLHuTDoxJWNc.Axis;
				return;
			}
			if (type == ControllerElementType.Button)
			{
				resultElementType = VhrRjYDSXtDmPGPepEmutTeotlnr.wBVDEckclaCUdHrHdLHuTDoxJWNc.Button;
				return;
			}
			if (type != ControllerElementType.CompoundElement)
			{
				resultElementType = VhrRjYDSXtDmPGPepEmutTeotlnr.wBVDEckclaCUdHrHdLHuTDoxJWNc.Unknown;
				return;
			}
			resultElementType = VhrRjYDSXtDmPGPepEmutTeotlnr.wBVDEckclaCUdHrHdLHuTDoxJWNc.CompoundElement;
			if (compoundType == CompoundControllerElementType.Axis2D)
			{
				resultCompoundElementType = VhrRjYDSXtDmPGPepEmutTeotlnr.ZqaUXWpANFaPfdXDRaVZzDjduZzZ.Axis2D;
				return;
			}
			if (compoundType == CompoundControllerElementType.DPad)
			{
				resultCompoundElementType = VhrRjYDSXtDmPGPepEmutTeotlnr.ZqaUXWpANFaPfdXDRaVZzDjduZzZ.DPad;
				return;
			}
			if (compoundType != CompoundControllerElementType.Hat)
			{
				resultElementType = VhrRjYDSXtDmPGPepEmutTeotlnr.wBVDEckclaCUdHrHdLHuTDoxJWNc.Unknown;
				return;
			}
			resultCompoundElementType = VhrRjYDSXtDmPGPepEmutTeotlnr.ZqaUXWpANFaPfdXDRaVZzDjduZzZ.Hat;
		}

		// Token: 0x17000320 RID: 800
		// (get) Token: 0x06000A87 RID: 2695 RVA: 0x00006557 File Offset: 0x00004757
		string lcAibZuWMerLyEDicYNSneVLTvsj.keyCategory
		{
			get
			{
				return "controller/template";
			}
		}

		// Token: 0x17000321 RID: 801
		// (get) Token: 0x06000A88 RID: 2696 RVA: 0x0000A677 File Offset: 0x00008877
		string lcAibZuWMerLyEDicYNSneVLTvsj.scriptingName
		{
			get
			{
				return this._name;
			}
		}

		// Token: 0x17000322 RID: 802
		// (get) Token: 0x06000A89 RID: 2697 RVA: 0x0000A677 File Offset: 0x00008877
		// (set) Token: 0x06000A8A RID: 2698 RVA: 0x0000A86B File Offset: 0x00008A6B
		string lcAibZuWMerLyEDicYNSneVLTvsj.nonLocalizedDescriptiveName
		{
			get
			{
				return this._name;
			}
			set
			{
				this.fqrtEHWIGccszFEUCjgSFeyPTvxH();
				this._name = value;
			}
		}

		// Token: 0x17000323 RID: 803
		// (get) Token: 0x06000A8B RID: 2699 RVA: 0x0000A6A9 File Offset: 0x000088A9
		// (set) Token: 0x06000A8C RID: 2700 RVA: 0x0000A87A File Offset: 0x00008A7A
		string djBPDCJyutcYSKkwfSFUMNGNGZXU.nonLocalizedPositiveDescriptiveName
		{
			get
			{
				return this._positiveName;
			}
			set
			{
				this.fqrtEHWIGccszFEUCjgSFeyPTvxH();
				this._positiveName = value;
			}
		}

		// Token: 0x17000324 RID: 804
		// (get) Token: 0x06000A8D RID: 2701 RVA: 0x0000A6DB File Offset: 0x000088DB
		// (set) Token: 0x06000A8E RID: 2702 RVA: 0x0000A889 File Offset: 0x00008A89
		string djBPDCJyutcYSKkwfSFUMNGNGZXU.nonLocalizedNegativeDescriptiveName
		{
			get
			{
				return this._negativeName;
			}
			set
			{
				this.fqrtEHWIGccszFEUCjgSFeyPTvxH();
				this._negativeName = value;
			}
		}

		// Token: 0x17000325 RID: 805
		// (get) Token: 0x06000A8F RID: 2703 RVA: 0x0000A70D File Offset: 0x0000890D
		string lcAibZuWMerLyEDicYNSneVLTvsj.key
		{
			get
			{
				return this._key;
			}
		}

		// Token: 0x17000326 RID: 806
		// (get) Token: 0x06000A90 RID: 2704 RVA: 0x0000A715 File Offset: 0x00008915
		// (set) Token: 0x06000A91 RID: 2705 RVA: 0x0000A898 File Offset: 0x00008A98
		string djBPDCJyutcYSKkwfSFUMNGNGZXU.positiveKey
		{
			get
			{
				return this._positiveKey;
			}
			set
			{
				this.fqrtEHWIGccszFEUCjgSFeyPTvxH();
				this._positiveKey = value;
			}
		}

		// Token: 0x17000327 RID: 807
		// (get) Token: 0x06000A92 RID: 2706 RVA: 0x0000A71D File Offset: 0x0000891D
		// (set) Token: 0x06000A93 RID: 2707 RVA: 0x0000A8A7 File Offset: 0x00008AA7
		string djBPDCJyutcYSKkwfSFUMNGNGZXU.negativeKey
		{
			get
			{
				return this._negativeKey;
			}
			set
			{
				this.fqrtEHWIGccszFEUCjgSFeyPTvxH();
				this._negativeKey = value;
			}
		}

		// Token: 0x17000328 RID: 808
		// (get) Token: 0x06000A94 RID: 2708 RVA: 0x0000A8B6 File Offset: 0x00008AB6
		// (set) Token: 0x06000A95 RID: 2709 RVA: 0x0000A8BE File Offset: 0x00008ABE
		int lcAibZuWMerLyEDicYNSneVLTvsj.autoGeneratedValueFlags
		{
			get
			{
				return this.IVozUpKFDxlFzTMzryndMevdLcyh;
			}
			set
			{
				this.IVozUpKFDxlFzTMzryndMevdLcyh = value;
			}
		}

		// Token: 0x06000A96 RID: 2710 RVA: 0x0000A8C7 File Offset: 0x00008AC7
		string dTljyMAPERKafkOoLqFGgRwgjxLO.GetSpecialElementNonLocalizedDescriptiveName(int index)
		{
			if (this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe == null || index >= this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe.Count)
			{
				return null;
			}
			return this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe[index].FTVwzGuwFTfxcGYBzWzYwJPQpzdf;
		}

		// Token: 0x06000A97 RID: 2711 RVA: 0x0000A8F2 File Offset: 0x00008AF2
		void dTljyMAPERKafkOoLqFGgRwgjxLO.SetSpecialElementNonLocalizedDescriptiveName(int index, string value)
		{
			if (this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe == null || index >= this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe.Count)
			{
				return;
			}
			this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe[index].FTVwzGuwFTfxcGYBzWzYwJPQpzdf = value;
		}

		// Token: 0x06000A98 RID: 2712 RVA: 0x0000A91D File Offset: 0x00008B1D
		string dTljyMAPERKafkOoLqFGgRwgjxLO.GetSpecialElementKey(int index)
		{
			if (this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe == null || index >= this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe.Count)
			{
				return null;
			}
			return this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe[index].RkRHcNeBAtkZAwVpJEIVvEQjrJNs;
		}

		// Token: 0x06000A99 RID: 2713 RVA: 0x0000A948 File Offset: 0x00008B48
		void dTljyMAPERKafkOoLqFGgRwgjxLO.SetSpecialElementKey(int index, string value)
		{
			if (this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe == null || index >= this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe.Count)
			{
				return;
			}
			this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe[index].RkRHcNeBAtkZAwVpJEIVvEQjrJNs = value;
		}

		// Token: 0x17000329 RID: 809
		// (get) Token: 0x06000A9A RID: 2714 RVA: 0x0000A973 File Offset: 0x00008B73
		string VHSvqsZIGaGVcFIeminrliAGzvFf.keyCategory
		{
			get
			{
				return pIxAfPCGFQRFBOwQPqPHNpZroQXw.JFMSjqZqDaHCEDpMBlJfyqpAuSbBA(this.ypisbKfXXFjntrbZRtOPeATsKUAK);
			}
		}

		// Token: 0x1700032A RID: 810
		// (get) Token: 0x06000A9B RID: 2715 RVA: 0x0000A70D File Offset: 0x0000890D
		string VHSvqsZIGaGVcFIeminrliAGzvFf.key
		{
			get
			{
				return this._key;
			}
		}

		// Token: 0x1700032B RID: 811
		// (get) Token: 0x06000A9C RID: 2716 RVA: 0x0000A8B6 File Offset: 0x00008AB6
		// (set) Token: 0x06000A9D RID: 2717 RVA: 0x0000A8BE File Offset: 0x00008ABE
		int VHSvqsZIGaGVcFIeminrliAGzvFf.autoGeneratedValueFlags
		{
			get
			{
				return this.IVozUpKFDxlFzTMzryndMevdLcyh;
			}
			set
			{
				this.IVozUpKFDxlFzTMzryndMevdLcyh = value;
			}
		}

		// Token: 0x1700032C RID: 812
		// (get) Token: 0x06000A9E RID: 2718 RVA: 0x0000A715 File Offset: 0x00008915
		// (set) Token: 0x06000A9F RID: 2719 RVA: 0x0000A898 File Offset: 0x00008A98
		string fjbgpVwttnDrmmsUrHYXoyGuYHCH.positiveKey
		{
			get
			{
				return this._positiveKey;
			}
			set
			{
				this.fqrtEHWIGccszFEUCjgSFeyPTvxH();
				this._positiveKey = value;
			}
		}

		// Token: 0x1700032D RID: 813
		// (get) Token: 0x06000AA0 RID: 2720 RVA: 0x0000A71D File Offset: 0x0000891D
		// (set) Token: 0x06000AA1 RID: 2721 RVA: 0x0000A8A7 File Offset: 0x00008AA7
		string fjbgpVwttnDrmmsUrHYXoyGuYHCH.negativeKey
		{
			get
			{
				return this._negativeKey;
			}
			set
			{
				this.fqrtEHWIGccszFEUCjgSFeyPTvxH();
				this._negativeKey = value;
			}
		}

		// Token: 0x06000AA2 RID: 2722 RVA: 0x0000A91D File Offset: 0x00008B1D
		string oLkCONlJZKYzXoJthulbVunIVBjF.GetSpecialElementKey(int index)
		{
			if (this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe == null || index >= this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe.Count)
			{
				return null;
			}
			return this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe[index].RkRHcNeBAtkZAwVpJEIVvEQjrJNs;
		}

		// Token: 0x06000AA3 RID: 2723 RVA: 0x0000A948 File Offset: 0x00008B48
		void oLkCONlJZKYzXoJthulbVunIVBjF.SetSpecialElementKey(int index, string value)
		{
			if (this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe == null || index >= this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe.Count)
			{
				return;
			}
			this.LtWeWIgjLJGMeGOvfFBdoOeHbbCXe[index].RkRHcNeBAtkZAwVpJEIVvEQjrJNs = value;
		}

		// Token: 0x0400076F RID: 1903
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _id;

		// Token: 0x04000770 RID: 1904
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _name;

		// Token: 0x04000771 RID: 1905
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _positiveName;

		// Token: 0x04000772 RID: 1906
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _negativeName;

		// Token: 0x04000773 RID: 1907
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _key;

		// Token: 0x04000774 RID: 1908
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _positiveKey;

		// Token: 0x04000775 RID: 1909
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _negativeKey;

		// Token: 0x04000776 RID: 1910
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ControllerElementType _elementType;

		// Token: 0x04000777 RID: 1911
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CompoundControllerElementType _compoundElementType;

		// Token: 0x04000778 RID: 1912
		[NonSerialized]
		private bool QvzTGIDiQzstCBcPAzRLomfECKRIA;

		// Token: 0x04000779 RID: 1913
		[NonSerialized]
		private hCXDpuHRLUFuvmVifjlUHPdRgCdY WBfdboaRxMcibcKUBAtEFVqMilEAb;

		// Token: 0x0400077A RID: 1914
		[NonSerialized]
		private USiPXXLGXPFEcgQzLFiSdGGeGdfT ETNCixCtOOkeYgWbZVOkFpanTjrR;

		// Token: 0x0400077B RID: 1915
		[NonSerialized]
		private QcieCxwEzKhTJEpEnbzfGmQUosAm PHDoSpUdZleuUqnxcjhCjrigCRKCA;

		// Token: 0x0400077C RID: 1916
		[NonSerialized]
		private OloYVEiPyubyINOXSBORFBRAgOFC ydWCklPPQXkDyJwpwOGUalzIlTQn;

		// Token: 0x0400077D RID: 1917
		[NonSerialized]
		private DeviceLocalizationInfo vlbFvwLeDngusTjukCVVbhoYCdui;

		// Token: 0x0400077E RID: 1918
		[NonSerialized]
		private int IVozUpKFDxlFzTMzryndMevdLcyh;

		// Token: 0x0400077F RID: 1919
		[NonSerialized]
		private List<ControllerElementIdentifier.wZEgKEJSRBVkIHlLhliLcQEYydwU> LtWeWIgjLJGMeGOvfFBdoOeHbbCXe;

		// Token: 0x04000780 RID: 1920
		[NonSerialized]
		private ControllerType ypisbKfXXFjntrbZRtOPeATsKUAK;

		// Token: 0x04000781 RID: 1921
		private static ControllerElementIdentifier tbnmFVZSCHBqLWWcIuavTRzAorWD;

		// Token: 0x02000118 RID: 280
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		internal class vNIqbrYzBBGsknBKgoQEcoARaWps
		{
			// Token: 0x04000782 RID: 1922
			public int id;

			// Token: 0x04000783 RID: 1923
			public string name;

			// Token: 0x04000784 RID: 1924
			public string positiveName;

			// Token: 0x04000785 RID: 1925
			public string negativeName;

			// Token: 0x04000786 RID: 1926
			public string key;

			// Token: 0x04000787 RID: 1927
			public string positiveKey;

			// Token: 0x04000788 RID: 1928
			public string negativeKey;

			// Token: 0x04000789 RID: 1929
			public ControllerElementType elementType;

			// Token: 0x0400078A RID: 1930
			public CompoundControllerElementType compoundElementType;
		}

		// Token: 0x02000119 RID: 281
		internal sealed class iAgfGjIvtOoRCYZuUkaRbTfLJqhyA
		{
			// Token: 0x1700032E RID: 814
			// (get) Token: 0x06000AA5 RID: 2725 RVA: 0x0000A980 File Offset: 0x00008B80
			private static ControllerElementIdentifier.iAgfGjIvtOoRCYZuUkaRbTfLJqhyA YgIBnbeCexumUJpPvubvPKrDvqicA
			{
				get
				{
					if (ControllerElementIdentifier.iAgfGjIvtOoRCYZuUkaRbTfLJqhyA.JKxEGLwfyfsYjrOxtqSToCTiOQCb != null)
					{
						return ControllerElementIdentifier.iAgfGjIvtOoRCYZuUkaRbTfLJqhyA.JKxEGLwfyfsYjrOxtqSToCTiOQCb;
					}
					ControllerElementIdentifier.iAgfGjIvtOoRCYZuUkaRbTfLJqhyA.JKxEGLwfyfsYjrOxtqSToCTiOQCb = new ControllerElementIdentifier.iAgfGjIvtOoRCYZuUkaRbTfLJqhyA();
					ControllerElementIdentifier.iAgfGjIvtOoRCYZuUkaRbTfLJqhyA.JKxEGLwfyfsYjrOxtqSToCTiOQCb.ohAcmHTcLXFiTiPPbTzqGGBnZzWY();
					return ControllerElementIdentifier.iAgfGjIvtOoRCYZuUkaRbTfLJqhyA.JKxEGLwfyfsYjrOxtqSToCTiOQCb;
				}
			}

			// Token: 0x06000AA6 RID: 2726 RVA: 0x0000A9A8 File Offset: 0x00008BA8
			private iAgfGjIvtOoRCYZuUkaRbTfLJqhyA()
			{
				this.naxjkrddtCPHlFgZqUKgDDeKJydbb = new HXLdpwfLmMygEUgGPgREFmOgqVGBA<ControllerElementIdentifier>(new Func<ControllerElementIdentifier, ControllerElementIdentifier, bool>(ControllerElementIdentifier.iAgfGjIvtOoRCYZuUkaRbTfLJqhyA.mUnJbhXbTFVchDZgTHNaMkpqXeNT.<>9.BqXFchIKpdnKgBXjfIsSIWJBvEAsA));
			}

			// Token: 0x06000AA7 RID: 2727 RVA: 0x0000A9DA File Offset: 0x00008BDA
			private void ohAcmHTcLXFiTiPPbTzqGGBnZzWY()
			{
				ReInput.ShutDownEvent += ControllerElementIdentifier.iAgfGjIvtOoRCYZuUkaRbTfLJqhyA.JKxEGLwfyfsYjrOxtqSToCTiOQCb.NLaPbWaCsjCYAeznkLvOLbaWwRxGA;
			}

			// Token: 0x06000AA8 RID: 2728 RVA: 0x0000A9F1 File Offset: 0x00008BF1
			private void NLaPbWaCsjCYAeznkLvOLbaWwRxGA()
			{
				if (ControllerElementIdentifier.iAgfGjIvtOoRCYZuUkaRbTfLJqhyA.JKxEGLwfyfsYjrOxtqSToCTiOQCb == this)
				{
					ControllerElementIdentifier.iAgfGjIvtOoRCYZuUkaRbTfLJqhyA.JKxEGLwfyfsYjrOxtqSToCTiOQCb = null;
				}
				ReInput.ShutDownEvent -= this.NLaPbWaCsjCYAeznkLvOLbaWwRxGA;
			}

			// Token: 0x06000AA9 RID: 2729 RVA: 0x0000AA12 File Offset: 0x00008C12
			public static ControllerElementIdentifier eNBeXSLDwzSWzekrEqClOEMBORXM(DeviceLocalizationInfo A_0, ControllerElementIdentifier A_1)
			{
				return ControllerElementIdentifier.iAgfGjIvtOoRCYZuUkaRbTfLJqhyA.YgIBnbeCexumUJpPvubvPKrDvqicA.naxjkrddtCPHlFgZqUKgDDeKJydbb.sisRxTizeCHHRjalSIxsvtVNWHCD(A_0.hash, A_1);
			}

			// Token: 0x06000AAA RID: 2730 RVA: 0x0000AA2A File Offset: 0x00008C2A
			public static bool AAnvbotNUfhOvbMtAftzlaSEOgdi(DeviceLocalizationInfo A_0, ControllerElementIdentifier A_1, out ControllerElementIdentifier A_2)
			{
				return ControllerElementIdentifier.iAgfGjIvtOoRCYZuUkaRbTfLJqhyA.YgIBnbeCexumUJpPvubvPKrDvqicA.naxjkrddtCPHlFgZqUKgDDeKJydbb.AhbcNOVImFriqRufyBzueptQIzFU(A_0.hash, A_1, out A_2);
			}

			// Token: 0x06000AAB RID: 2731 RVA: 0x0000AA43 File Offset: 0x00008C43
			public static void WeTjQiPEGeZSGwUzJoLXpXILycBJ(DeviceLocalizationInfo A_0, ControllerElementIdentifier A_1)
			{
				ControllerElementIdentifier.iAgfGjIvtOoRCYZuUkaRbTfLJqhyA.YgIBnbeCexumUJpPvubvPKrDvqicA.naxjkrddtCPHlFgZqUKgDDeKJydbb.xnbsxOCSckNIIyZiKiFycySIFrRr(A_0.hash, A_1);
			}

			// Token: 0x0400078B RID: 1931
			private static ControllerElementIdentifier.iAgfGjIvtOoRCYZuUkaRbTfLJqhyA JKxEGLwfyfsYjrOxtqSToCTiOQCb;

			// Token: 0x0400078C RID: 1932
			private readonly HXLdpwfLmMygEUgGPgREFmOgqVGBA<ControllerElementIdentifier> naxjkrddtCPHlFgZqUKgDDeKJydbb;

			// Token: 0x0200011A RID: 282
			[CompilerGenerated]
			[Serializable]
			private sealed class mUnJbhXbTFVchDZgTHNaMkpqXeNT
			{
				// Token: 0x06000AAE RID: 2734 RVA: 0x000483C8 File Offset: 0x000465C8
				internal bool BqXFchIKpdnKgBXjfIsSIWJBvEAsA(ControllerElementIdentifier A_1, ControllerElementIdentifier A_2)
				{
					return A_1 != null && A_2 != null && (A_1 != null && A_2 != null && A_1.id == A_2.id && A_1.elementType == A_2.elementType && A_1.compoundElementType == A_2.compoundElementType) && string.Equals(A_1.key, A_2.key, StringComparison.Ordinal);
				}

				// Token: 0x0400078D RID: 1933
				public static readonly ControllerElementIdentifier.iAgfGjIvtOoRCYZuUkaRbTfLJqhyA.mUnJbhXbTFVchDZgTHNaMkpqXeNT <>9 = new ControllerElementIdentifier.iAgfGjIvtOoRCYZuUkaRbTfLJqhyA.mUnJbhXbTFVchDZgTHNaMkpqXeNT();

				// Token: 0x0400078E RID: 1934
				public static Func<ControllerElementIdentifier, ControllerElementIdentifier, bool> <>9__4_0;
			}
		}

		// Token: 0x0200011B RID: 283
		private class wZEgKEJSRBVkIHlLhliLcQEYydwU
		{
			// Token: 0x1700032F RID: 815
			// (get) Token: 0x06000AAF RID: 2735 RVA: 0x0000AA67 File Offset: 0x00008C67
			// (set) Token: 0x06000AB0 RID: 2736 RVA: 0x0000AA6F File Offset: 0x00008C6F
			public string RkRHcNeBAtkZAwVpJEIVvEQjrJNs
			{
				get
				{
					return this.OAngmUojwCtoKOwvhLgEYWtIMBep;
				}
				set
				{
					this.OAngmUojwCtoKOwvhLgEYWtIMBep = value;
				}
			}

			// Token: 0x17000330 RID: 816
			// (get) Token: 0x06000AB1 RID: 2737 RVA: 0x0000AA78 File Offset: 0x00008C78
			// (set) Token: 0x06000AB2 RID: 2738 RVA: 0x0000AA80 File Offset: 0x00008C80
			public string FTVwzGuwFTfxcGYBzWzYwJPQpzdf
			{
				get
				{
					return this.QzdGStjNDsBaUXvwvpPVhfLaTLzpb;
				}
				set
				{
					this.QzdGStjNDsBaUXvwvpPVhfLaTLzpb = value;
				}
			}

			// Token: 0x06000AB3 RID: 2739 RVA: 0x000033F4 File Offset: 0x000015F4
			public wZEgKEJSRBVkIHlLhliLcQEYydwU()
			{
			}

			// Token: 0x06000AB4 RID: 2740 RVA: 0x0000AA89 File Offset: 0x00008C89
			public wZEgKEJSRBVkIHlLhliLcQEYydwU(ControllerElementIdentifier.wZEgKEJSRBVkIHlLhliLcQEYydwU A_1)
			{
				this.OAngmUojwCtoKOwvhLgEYWtIMBep = A_1.OAngmUojwCtoKOwvhLgEYWtIMBep;
				this.QzdGStjNDsBaUXvwvpPVhfLaTLzpb = A_1.QzdGStjNDsBaUXvwvpPVhfLaTLzpb;
			}

			// Token: 0x0400078F RID: 1935
			[SerializeField]
			private string OAngmUojwCtoKOwvhLgEYWtIMBep;

			// Token: 0x04000790 RID: 1936
			[SerializeField]
			private string QzdGStjNDsBaUXvwvpPVhfLaTLzpb;
		}
	}
}
