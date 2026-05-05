using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Glyphs;
using Rewired.Internal.Localization;
using UnityEngine;

namespace Rewired
{
	// Token: 0x0200011C RID: 284
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[Serializable]
	public class ControllerTemplateElementIdentifier : IControllerElementIdentifierCommon_Internal, IControllerTemplateElementIdentifier, djBPDCJyutcYSKkwfSFUMNGNGZXU, lcAibZuWMerLyEDicYNSneVLTvsj, fjbgpVwttnDrmmsUrHYXoyGuYHCH, VHSvqsZIGaGVcFIeminrliAGzvFf, dTljyMAPERKafkOoLqFGgRwgjxLO, oLkCONlJZKYzXoJthulbVunIVBjF
	{
		// Token: 0x17000331 RID: 817
		// (get) Token: 0x06000AB5 RID: 2741 RVA: 0x0000AAA9 File Offset: 0x00008CA9
		public int id
		{
			get
			{
				return this._id;
			}
		}

		// Token: 0x17000332 RID: 818
		// (get) Token: 0x06000AB6 RID: 2742 RVA: 0x0000AAB1 File Offset: 0x00008CB1
		// (set) Token: 0x06000AB7 RID: 2743 RVA: 0x0000AADB File Offset: 0x00008CDB
		public string name
		{
			get
			{
				if (!ReInput.isReady || this.OMEQSicSgvgakwpqpVAXhlCDbjtgA == null || !LocalizationManager.isEnabled)
				{
					return this._name;
				}
				return this.OMEQSicSgvgakwpqpVAXhlCDbjtgA.QGZglKMnBTLJKJKOPknbgTZKPbAO;
			}
			internal set
			{
				this.nonLocalizedName = value;
			}
		}

		// Token: 0x17000333 RID: 819
		// (get) Token: 0x06000AB8 RID: 2744 RVA: 0x0000AAE4 File Offset: 0x00008CE4
		// (set) Token: 0x06000AB9 RID: 2745 RVA: 0x0000AB0E File Offset: 0x00008D0E
		public string positiveName
		{
			get
			{
				if (!ReInput.isReady || this.OMEQSicSgvgakwpqpVAXhlCDbjtgA == null || !LocalizationManager.isEnabled)
				{
					return this._positiveName;
				}
				return this.OMEQSicSgvgakwpqpVAXhlCDbjtgA.ouKRfZfTiXAAdpWYEfuBzPMgociw;
			}
			internal set
			{
				this.nonLocalizedPositiveName = value;
			}
		}

		// Token: 0x17000334 RID: 820
		// (get) Token: 0x06000ABA RID: 2746 RVA: 0x0000AB17 File Offset: 0x00008D17
		// (set) Token: 0x06000ABB RID: 2747 RVA: 0x0000AB41 File Offset: 0x00008D41
		public string negativeName
		{
			get
			{
				if (!ReInput.isReady || this.OMEQSicSgvgakwpqpVAXhlCDbjtgA == null || !LocalizationManager.isEnabled)
				{
					return this._negativeName;
				}
				return this.OMEQSicSgvgakwpqpVAXhlCDbjtgA.AHaXPYUQTomysBARqTqPHTZSHXpe;
			}
			internal set
			{
				this.nonLocalizedNegativeName = value;
			}
		}

		// Token: 0x06000ABC RID: 2748 RVA: 0x0000AB4A File Offset: 0x00008D4A
		internal string GetCompoundElementSpecialName(int index)
		{
			if (!ReInput.isReady || !LocalizationManager.isEnabled || this.SnjDgclkgepjNxyMjTbcMzZqNrhy == null || this.UMKnHMfrFlmFGsgIhBSRZTKGeOrm == null)
			{
				return string.Empty;
			}
			return this.UMKnHMfrFlmFGsgIhBSRZTKGeOrm.KVPPiJXooHbsQHcHvBzittZRUWnE(index);
		}

		// Token: 0x17000335 RID: 821
		// (get) Token: 0x06000ABD RID: 2749 RVA: 0x0000AB7C File Offset: 0x00008D7C
		public ControllerTemplateElementType elementType
		{
			get
			{
				return this._elementType;
			}
		}

		// Token: 0x17000336 RID: 822
		// (get) Token: 0x06000ABE RID: 2750 RVA: 0x00003E2B File Offset: 0x0000202B
		internal virtual bool useEditorElementTypeOverride
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000337 RID: 823
		// (get) Token: 0x06000ABF RID: 2751 RVA: 0x000039F5 File Offset: 0x00001BF5
		internal virtual ControllerElementType editorElementTypeOverride
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000338 RID: 824
		// (get) Token: 0x06000AC0 RID: 2752 RVA: 0x0000AB84 File Offset: 0x00008D84
		public object glyph
		{
			get
			{
				if (!ReInput.isReady || this.GJrVShIIjWJLwChTqlDreXJpCZzA == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return this.GJrVShIIjWJLwChTqlDreXJpCZzA.RrcQSnGZhLUWaACyTfIVqhfeHwoH;
			}
		}

		// Token: 0x17000339 RID: 825
		// (get) Token: 0x06000AC1 RID: 2753 RVA: 0x0000ABA9 File Offset: 0x00008DA9
		public object positiveGlyph
		{
			get
			{
				if (!ReInput.isReady || this.GJrVShIIjWJLwChTqlDreXJpCZzA == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return this.GJrVShIIjWJLwChTqlDreXJpCZzA.aTSgNbktJUnntkjgYbPIRiEjCQVm;
			}
		}

		// Token: 0x1700033A RID: 826
		// (get) Token: 0x06000AC2 RID: 2754 RVA: 0x0000ABCE File Offset: 0x00008DCE
		public object negativeGlyph
		{
			get
			{
				if (!ReInput.isReady || this.GJrVShIIjWJLwChTqlDreXJpCZzA == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return this.GJrVShIIjWJLwChTqlDreXJpCZzA.ajimpxGOjebSamduDdhWkLKRfGwIA;
			}
		}

		// Token: 0x1700033B RID: 827
		// (get) Token: 0x06000AC3 RID: 2755 RVA: 0x0000ABF3 File Offset: 0x00008DF3
		private string finalGlyphKey
		{
			get
			{
				if (!ReInput.isReady || this.GJrVShIIjWJLwChTqlDreXJpCZzA == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return this.GJrVShIIjWJLwChTqlDreXJpCZzA.IbkdqazTmRJXXakoWTyynULrgVYm;
			}
		}

		// Token: 0x1700033C RID: 828
		// (get) Token: 0x06000AC4 RID: 2756 RVA: 0x0000AC18 File Offset: 0x00008E18
		private string finalPositiveGlyphKey
		{
			get
			{
				if (!ReInput.isReady || this.GJrVShIIjWJLwChTqlDreXJpCZzA == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return this.GJrVShIIjWJLwChTqlDreXJpCZzA.COhBviegEUiqjtNqOyGqtwxdHdwn;
			}
		}

		// Token: 0x1700033D RID: 829
		// (get) Token: 0x06000AC5 RID: 2757 RVA: 0x0000AC3D File Offset: 0x00008E3D
		private string finalNegativeGlyphKey
		{
			get
			{
				if (!ReInput.isReady || this.GJrVShIIjWJLwChTqlDreXJpCZzA == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return this.GJrVShIIjWJLwChTqlDreXJpCZzA.FvxfyRckRinNtummBgbbdgdivvrmb;
			}
		}

		// Token: 0x06000AC6 RID: 2758 RVA: 0x0000AC62 File Offset: 0x00008E62
		internal object GetCompoundElementSpecialGlyph(int index)
		{
			if (!ReInput.isReady || !GlyphManager.isEnabled || this.SnjDgclkgepjNxyMjTbcMzZqNrhy == null || this.vLeBEjPEyOEueIsHQAVhCMLKPcsd == null)
			{
				return null;
			}
			return this.vLeBEjPEyOEueIsHQAVhCMLKPcsd.PRLSSyeXdESxIftyzmIwLlPhNBRd(index);
		}

		// Token: 0x1700033E RID: 830
		// (get) Token: 0x06000AC7 RID: 2759 RVA: 0x0000AC90 File Offset: 0x00008E90
		// (set) Token: 0x06000AC8 RID: 2760 RVA: 0x0000AC98 File Offset: 0x00008E98
		internal string nonLocalizedName
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
				if (!ReInput.isReady || this.OMEQSicSgvgakwpqpVAXhlCDbjtgA == null)
				{
					return;
				}
				this.OMEQSicSgvgakwpqpVAXhlCDbjtgA.OlcAFIbuEHvUomQdyRvLXKoljCWJ();
			}
		}

		// Token: 0x1700033F RID: 831
		// (get) Token: 0x06000AC9 RID: 2761 RVA: 0x0000ACBC File Offset: 0x00008EBC
		// (set) Token: 0x06000ACA RID: 2762 RVA: 0x0000ACC4 File Offset: 0x00008EC4
		internal string nonLocalizedPositiveName
		{
			get
			{
				return this._positiveName;
			}
			set
			{
				this._positiveName = value;
				if (!ReInput.isReady || this.OMEQSicSgvgakwpqpVAXhlCDbjtgA == null)
				{
					return;
				}
				this.OMEQSicSgvgakwpqpVAXhlCDbjtgA.hEFzpZMEhaJYzHkMYgtFIevqGShY();
			}
		}

		// Token: 0x17000340 RID: 832
		// (get) Token: 0x06000ACB RID: 2763 RVA: 0x0000ACE8 File Offset: 0x00008EE8
		// (set) Token: 0x06000ACC RID: 2764 RVA: 0x0000ACF0 File Offset: 0x00008EF0
		internal string nonLocalizedNegativeName
		{
			get
			{
				return this._negativeName;
			}
			set
			{
				this._negativeName = value;
				if (!ReInput.isReady || this.OMEQSicSgvgakwpqpVAXhlCDbjtgA == null)
				{
					return;
				}
				this.OMEQSicSgvgakwpqpVAXhlCDbjtgA.UhCcgieCihFlYvAACQRSZOqugFYbb();
			}
		}

		// Token: 0x17000341 RID: 833
		// (get) Token: 0x06000ACD RID: 2765 RVA: 0x0000AD14 File Offset: 0x00008F14
		public string key
		{
			get
			{
				return this._key;
			}
		}

		// Token: 0x17000342 RID: 834
		// (get) Token: 0x06000ACE RID: 2766 RVA: 0x0000AD1C File Offset: 0x00008F1C
		public string positiveKey
		{
			get
			{
				return this._positiveKey;
			}
		}

		// Token: 0x17000343 RID: 835
		// (get) Token: 0x06000ACF RID: 2767 RVA: 0x0000AD24 File Offset: 0x00008F24
		public string negativeKey
		{
			get
			{
				return this._negativeKey;
			}
		}

		// Token: 0x17000344 RID: 836
		// (get) Token: 0x06000AD0 RID: 2768 RVA: 0x0000AD2C File Offset: 0x00008F2C
		string IControllerElementIdentifierCommon_Internal.nonLocalizedName
		{
			get
			{
				return this.nonLocalizedName;
			}
		}

		// Token: 0x17000345 RID: 837
		// (get) Token: 0x06000AD1 RID: 2769 RVA: 0x0000AD34 File Offset: 0x00008F34
		string IControllerElementIdentifierCommon_Internal.nonLocalizedPositiveName
		{
			get
			{
				return this.nonLocalizedPositiveName;
			}
		}

		// Token: 0x17000346 RID: 838
		// (get) Token: 0x06000AD2 RID: 2770 RVA: 0x0000AD3C File Offset: 0x00008F3C
		string IControllerElementIdentifierCommon_Internal.nonLocalizedNegativeName
		{
			get
			{
				return this.nonLocalizedNegativeName;
			}
		}

		// Token: 0x06000AD3 RID: 2771 RVA: 0x0000AD44 File Offset: 0x00008F44
		string IControllerElementIdentifierCommon_Internal.GetSpecialElementNonLocalizedName(int index)
		{
			if (this.SnjDgclkgepjNxyMjTbcMzZqNrhy == null || index >= this.SnjDgclkgepjNxyMjTbcMzZqNrhy.Count)
			{
				return null;
			}
			return this.SnjDgclkgepjNxyMjTbcMzZqNrhy[index].BRcDblsVJHeTcdOBKAZwnhsglgThA;
		}

		// Token: 0x17000347 RID: 839
		// (get) Token: 0x06000AD4 RID: 2772 RVA: 0x0000AD6F File Offset: 0x00008F6F
		bool IControllerElementIdentifierCommon_Internal.isNonLocalizedPositiveNameAutoGenerated
		{
			get
			{
				return (this.vXJHDkCuFMVzeOuZSDMRqKgIQUDj & 2) != 0;
			}
		}

		// Token: 0x17000348 RID: 840
		// (get) Token: 0x06000AD5 RID: 2773 RVA: 0x0000AD7C File Offset: 0x00008F7C
		bool IControllerElementIdentifierCommon_Internal.isNonLocalizedNegativeNameAutoGenerated
		{
			get
			{
				return (this.vXJHDkCuFMVzeOuZSDMRqKgIQUDj & 4) != 0;
			}
		}

		// Token: 0x17000349 RID: 841
		// (get) Token: 0x06000AD6 RID: 2774 RVA: 0x0000AD89 File Offset: 0x00008F89
		bool IControllerElementIdentifierCommon_Internal.isPositiveKeyAutoGenerated
		{
			get
			{
				return (this.vXJHDkCuFMVzeOuZSDMRqKgIQUDj & 8) != 0;
			}
		}

		// Token: 0x1700034A RID: 842
		// (get) Token: 0x06000AD7 RID: 2775 RVA: 0x0000AD96 File Offset: 0x00008F96
		bool IControllerElementIdentifierCommon_Internal.isNegativeKeyAutoGenerated
		{
			get
			{
				return (this.vXJHDkCuFMVzeOuZSDMRqKgIQUDj & 16) != 0;
			}
		}

		// Token: 0x1700034B RID: 843
		// (get) Token: 0x06000AD8 RID: 2776 RVA: 0x0000AD14 File Offset: 0x00008F14
		string IControllerElementIdentifierCommon_Internal.key
		{
			get
			{
				return this._key;
			}
		}

		// Token: 0x1700034C RID: 844
		// (get) Token: 0x06000AD9 RID: 2777 RVA: 0x0000AD1C File Offset: 0x00008F1C
		string IControllerElementIdentifierCommon_Internal.positiveKey
		{
			get
			{
				return this._positiveKey;
			}
		}

		// Token: 0x1700034D RID: 845
		// (get) Token: 0x06000ADA RID: 2778 RVA: 0x0000AD24 File Offset: 0x00008F24
		string IControllerElementIdentifierCommon_Internal.negativeKey
		{
			get
			{
				return this._negativeKey;
			}
		}

		// Token: 0x06000ADB RID: 2779 RVA: 0x0000ADA4 File Offset: 0x00008FA4
		string IControllerElementIdentifierCommon_Internal.GetSpecialElementKey(int index)
		{
			if (this.SnjDgclkgepjNxyMjTbcMzZqNrhy == null || index >= this.SnjDgclkgepjNxyMjTbcMzZqNrhy.Count)
			{
				return null;
			}
			return this.SnjDgclkgepjNxyMjTbcMzZqNrhy[index].sDciFXSuqbieJhFarBLoQnWrCCST;
		}

		// Token: 0x1700034E RID: 846
		// (get) Token: 0x06000ADC RID: 2780 RVA: 0x0000ADCF File Offset: 0x00008FCF
		DeviceLocalizationInfo IControllerElementIdentifierCommon_Internal.deviceLocalizationInfo
		{
			get
			{
				return this.wazgirpMhJKlYEKNxtRKVVFaNRDo;
			}
		}

		// Token: 0x06000ADD RID: 2781 RVA: 0x000033F4 File Offset: 0x000015F4
		public ControllerTemplateElementIdentifier()
		{
		}

		// Token: 0x06000ADE RID: 2782 RVA: 0x00048424 File Offset: 0x00046624
		public ControllerTemplateElementIdentifier(ControllerTemplateElementIdentifier A_1)
		{
			this._id = A_1._id;
			this._name = A_1._name;
			this._positiveName = A_1._positiveName;
			this._negativeName = A_1._negativeName;
			this._key = A_1._key;
			this._positiveKey = A_1._positiveKey;
			this._negativeKey = A_1._negativeKey;
			this._elementType = A_1._elementType;
			if (A_1.SnjDgclkgepjNxyMjTbcMzZqNrhy != null)
			{
				int count = A_1.SnjDgclkgepjNxyMjTbcMzZqNrhy.Count;
				this.SnjDgclkgepjNxyMjTbcMzZqNrhy = new List<ControllerTemplateElementIdentifier.AwWWopCtyzshSEElkQGtPmOiJUIo>(count);
				for (int i = 0; i < count; i++)
				{
					if (A_1.SnjDgclkgepjNxyMjTbcMzZqNrhy[i] != null)
					{
						this.SnjDgclkgepjNxyMjTbcMzZqNrhy.Add(new ControllerTemplateElementIdentifier.AwWWopCtyzshSEElkQGtPmOiJUIo(A_1.SnjDgclkgepjNxyMjTbcMzZqNrhy[i]));
					}
				}
			}
			this.vXJHDkCuFMVzeOuZSDMRqKgIQUDj = A_1.vXJHDkCuFMVzeOuZSDMRqKgIQUDj;
		}

		// Token: 0x06000ADF RID: 2783 RVA: 0x000484FC File Offset: 0x000466FC
		internal ControllerTemplateElementIdentifier(ControllerTemplateElementIdentifier.ftBVjBGmwltSKoIhVlShRqVSZWYm A_1)
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
		}

		// Token: 0x06000AE0 RID: 2784 RVA: 0x0000ADD7 File Offset: 0x00008FD7
		internal ControllerTemplateElementIdentifier(ControllerTemplateElementIdentifier A_1, ControllerTemplateElementType A_2, bool A_3) : this(A_1)
		{
			this._elementType = A_2;
		}

		// Token: 0x06000AE1 RID: 2785 RVA: 0x0000ADE7 File Offset: 0x00008FE7
		public virtual ControllerTemplateElementIdentifier Clone()
		{
			return new ControllerTemplateElementIdentifier(this);
		}

		// Token: 0x06000AE2 RID: 2786 RVA: 0x00048580 File Offset: 0x00046780
		public string GetDisplayName(AxisRange axisRange)
		{
			ControllerTemplateElementType elementType = this._elementType;
			if (elementType != ControllerTemplateElementType.Axis)
			{
				if (elementType != ControllerTemplateElementType.Button)
				{
				}
				return this.name;
			}
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

		// Token: 0x06000AE3 RID: 2787 RVA: 0x000485D4 File Offset: 0x000467D4
		public object GetGlyph(AxisRange axisRange)
		{
			ControllerTemplateElementType elementType = this._elementType;
			if (elementType != ControllerTemplateElementType.Axis)
			{
				if (elementType != ControllerTemplateElementType.Button)
				{
				}
				return this.glyph;
			}
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

		// Token: 0x06000AE4 RID: 2788 RVA: 0x00048628 File Offset: 0x00046828
		public string GetFinalGlyphKey(AxisRange axisRange)
		{
			ControllerTemplateElementType elementType = this._elementType;
			if (elementType != ControllerTemplateElementType.Axis)
			{
				if (elementType != ControllerTemplateElementType.Button)
				{
				}
				return this.finalGlyphKey;
			}
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

		// Token: 0x06000AE5 RID: 2789 RVA: 0x0004867C File Offset: 0x0004687C
		internal ControllerElementIdentifier ToControllerElementIdentifier(IHardwareControllerMap_Internal hardwareControllerMap)
		{
			ControllerElementIdentifier controllerElementIdentifier = new ControllerElementIdentifier(new ControllerElementIdentifier.vNIqbrYzBBGsknBKgoQEcoARaWps
			{
				id = this._id,
				name = this._name,
				positiveName = this._positiveName,
				negativeName = this._negativeName,
				key = this._key,
				positiveKey = this._positiveKey,
				negativeKey = this._negativeKey,
				elementType = gRvITEHjKMrWaeGYEmAHofbpCtEU.xDUDoLbiYOUQjsjnuftaWlowBoTm(this._elementType),
				compoundElementType = CompoundControllerElementType.Axis2D
			});
			if (ReInput.isReady && this.wazgirpMhJKlYEKNxtRKVVFaNRDo != null && hardwareControllerMap != null)
			{
				DeviceLocalizationInfo deviceLocalizationInfo = new DeviceLocalizationInfo(hardwareControllerMap.controllerType, false, hardwareControllerMap.typeGuid, new List<string>
				{
					hardwareControllerMap.typeKey
				}, null);
				deviceLocalizationInfo.FinishRuntimeSetup();
				controllerElementIdentifier.FinishRuntimeSetup(deviceLocalizationInfo, hardwareControllerMap.controllerType);
			}
			return controllerElementIdentifier;
		}

		// Token: 0x1700034F RID: 847
		// (get) Token: 0x06000AE6 RID: 2790 RVA: 0x0000ADEF File Offset: 0x00008FEF
		object IControllerElementIdentifierCommon_Internal.elementType
		{
			get
			{
				return this._elementType;
			}
		}

		// Token: 0x17000350 RID: 848
		// (get) Token: 0x06000AE7 RID: 2791 RVA: 0x0000ADFC File Offset: 0x00008FFC
		bool IControllerElementIdentifierCommon_Internal.useEditorElementTypeOverride
		{
			get
			{
				return this.useEditorElementTypeOverride;
			}
		}

		// Token: 0x17000351 RID: 849
		// (get) Token: 0x06000AE8 RID: 2792 RVA: 0x0000AE04 File Offset: 0x00009004
		ControllerElementType IControllerElementIdentifierCommon_Internal.editorElementTypeOverride
		{
			get
			{
				return this.editorElementTypeOverride;
			}
		}

		// Token: 0x06000AE9 RID: 2793 RVA: 0x0004874C File Offset: 0x0004694C
		internal void FinishRuntimeSetup(DeviceLocalizationInfo deviceLocalizationInfo)
		{
			VhrRjYDSXtDmPGPepEmutTeotlnr.wBVDEckclaCUdHrHdLHuTDoxJWNc wBVDEckclaCUdHrHdLHuTDoxJWNc;
			VhrRjYDSXtDmPGPepEmutTeotlnr.ZqaUXWpANFaPfdXDRaVZzDjduZzZ zqaUXWpANFaPfdXDRaVZzDjduZzZ;
			ControllerTemplateElementIdentifier.hAzIWgKkwevjzAvmngbuJMMSboEdA(this._elementType, out wBVDEckclaCUdHrHdLHuTDoxJWNc, out zqaUXWpANFaPfdXDRaVZzDjduZzZ);
			int num = VhrRjYDSXtDmPGPepEmutTeotlnr.TdchWUliZEyAPBEjbXHfPlHoLBTd(wBVDEckclaCUdHrHdLHuTDoxJWNc, zqaUXWpANFaPfdXDRaVZzDjduZzZ);
			if (num > 0)
			{
				this.SnjDgclkgepjNxyMjTbcMzZqNrhy = new List<ControllerTemplateElementIdentifier.AwWWopCtyzshSEElkQGtPmOiJUIo>(num);
				for (int i = 0; i < num; i++)
				{
					this.SnjDgclkgepjNxyMjTbcMzZqNrhy.Add(new ControllerTemplateElementIdentifier.AwWWopCtyzshSEElkQGtPmOiJUIo());
				}
			}
			this.wazgirpMhJKlYEKNxtRKVVFaNRDo = deviceLocalizationInfo;
			if (this.OMEQSicSgvgakwpqpVAXhlCDbjtgA == null)
			{
				this.OMEQSicSgvgakwpqpVAXhlCDbjtgA = hCXDpuHRLUFuvmVifjlUHPdRgCdY.mUttHISaqnMztGpFXTVIpEwUMqoj(this, qIdXPWaZDFjemNjbsLrswVoVIvUh.ControllerTemplate, wBVDEckclaCUdHrHdLHuTDoxJWNc, zqaUXWpANFaPfdXDRaVZzDjduZzZ, this._id, deviceLocalizationInfo);
			}
			if (this.GJrVShIIjWJLwChTqlDreXJpCZzA == null)
			{
				this.GJrVShIIjWJLwChTqlDreXJpCZzA = QcieCxwEzKhTJEpEnbzfGmQUosAm.AIkzYBavzyNjeDRpoImVzGiVjwVP(this, qIdXPWaZDFjemNjbsLrswVoVIvUh.ControllerTemplate, wBVDEckclaCUdHrHdLHuTDoxJWNc, zqaUXWpANFaPfdXDRaVZzDjduZzZ, this._id, deviceLocalizationInfo);
			}
			if (wBVDEckclaCUdHrHdLHuTDoxJWNc == VhrRjYDSXtDmPGPepEmutTeotlnr.wBVDEckclaCUdHrHdLHuTDoxJWNc.CompoundElement)
			{
				this.UMKnHMfrFlmFGsgIhBSRZTKGeOrm = USiPXXLGXPFEcgQzLFiSdGGeGdfT.vpDtqeluwXqOQxMslepLcWCygNMi(this, qIdXPWaZDFjemNjbsLrswVoVIvUh.ControllerTemplate, wBVDEckclaCUdHrHdLHuTDoxJWNc, zqaUXWpANFaPfdXDRaVZzDjduZzZ, this._id, deviceLocalizationInfo);
				this.vLeBEjPEyOEueIsHQAVhCMLKPcsd = OloYVEiPyubyINOXSBORFBRAgOFC.OrolycsynFfPbblUXYFenyCQWkim(this, qIdXPWaZDFjemNjbsLrswVoVIvUh.ControllerTemplate, wBVDEckclaCUdHrHdLHuTDoxJWNc, zqaUXWpANFaPfdXDRaVZzDjduZzZ, this._id, deviceLocalizationInfo);
			}
		}

		// Token: 0x17000352 RID: 850
		// (get) Token: 0x06000AEA RID: 2794 RVA: 0x00006557 File Offset: 0x00004757
		string lcAibZuWMerLyEDicYNSneVLTvsj.keyCategory
		{
			get
			{
				return "controller/template";
			}
		}

		// Token: 0x17000353 RID: 851
		// (get) Token: 0x06000AEB RID: 2795 RVA: 0x0000AC90 File Offset: 0x00008E90
		string lcAibZuWMerLyEDicYNSneVLTvsj.scriptingName
		{
			get
			{
				return this._name;
			}
		}

		// Token: 0x17000354 RID: 852
		// (get) Token: 0x06000AEC RID: 2796 RVA: 0x0000AC90 File Offset: 0x00008E90
		// (set) Token: 0x06000AED RID: 2797 RVA: 0x0000AE0C File Offset: 0x0000900C
		string lcAibZuWMerLyEDicYNSneVLTvsj.nonLocalizedDescriptiveName
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x17000355 RID: 853
		// (get) Token: 0x06000AEE RID: 2798 RVA: 0x0000ACBC File Offset: 0x00008EBC
		// (set) Token: 0x06000AEF RID: 2799 RVA: 0x0000AE15 File Offset: 0x00009015
		string djBPDCJyutcYSKkwfSFUMNGNGZXU.nonLocalizedPositiveDescriptiveName
		{
			get
			{
				return this._positiveName;
			}
			set
			{
				this._positiveName = value;
			}
		}

		// Token: 0x17000356 RID: 854
		// (get) Token: 0x06000AF0 RID: 2800 RVA: 0x0000ACE8 File Offset: 0x00008EE8
		// (set) Token: 0x06000AF1 RID: 2801 RVA: 0x0000AE1E File Offset: 0x0000901E
		string djBPDCJyutcYSKkwfSFUMNGNGZXU.nonLocalizedNegativeDescriptiveName
		{
			get
			{
				return this._negativeName;
			}
			set
			{
				this._negativeName = value;
			}
		}

		// Token: 0x17000357 RID: 855
		// (get) Token: 0x06000AF2 RID: 2802 RVA: 0x0000AD14 File Offset: 0x00008F14
		string lcAibZuWMerLyEDicYNSneVLTvsj.key
		{
			get
			{
				return this._key;
			}
		}

		// Token: 0x17000358 RID: 856
		// (get) Token: 0x06000AF3 RID: 2803 RVA: 0x0000AD1C File Offset: 0x00008F1C
		// (set) Token: 0x06000AF4 RID: 2804 RVA: 0x0000AE27 File Offset: 0x00009027
		string djBPDCJyutcYSKkwfSFUMNGNGZXU.positiveKey
		{
			get
			{
				return this._positiveKey;
			}
			set
			{
				this._positiveKey = value;
			}
		}

		// Token: 0x17000359 RID: 857
		// (get) Token: 0x06000AF5 RID: 2805 RVA: 0x0000AD24 File Offset: 0x00008F24
		// (set) Token: 0x06000AF6 RID: 2806 RVA: 0x0000AE30 File Offset: 0x00009030
		string djBPDCJyutcYSKkwfSFUMNGNGZXU.negativeKey
		{
			get
			{
				return this._negativeKey;
			}
			set
			{
				this._negativeKey = value;
			}
		}

		// Token: 0x1700035A RID: 858
		// (get) Token: 0x06000AF7 RID: 2807 RVA: 0x0000AE39 File Offset: 0x00009039
		// (set) Token: 0x06000AF8 RID: 2808 RVA: 0x0000AE41 File Offset: 0x00009041
		int lcAibZuWMerLyEDicYNSneVLTvsj.autoGeneratedValueFlags
		{
			get
			{
				return this.vXJHDkCuFMVzeOuZSDMRqKgIQUDj;
			}
			set
			{
				this.vXJHDkCuFMVzeOuZSDMRqKgIQUDj = value;
			}
		}

		// Token: 0x06000AF9 RID: 2809 RVA: 0x0000AE4A File Offset: 0x0000904A
		string dTljyMAPERKafkOoLqFGgRwgjxLO.GetSpecialElementNonLocalizedDescriptiveName(int index)
		{
			if (this.SnjDgclkgepjNxyMjTbcMzZqNrhy == null || index >= this.SnjDgclkgepjNxyMjTbcMzZqNrhy.Count)
			{
				return null;
			}
			return this.SnjDgclkgepjNxyMjTbcMzZqNrhy[index].BRcDblsVJHeTcdOBKAZwnhsglgThA;
		}

		// Token: 0x06000AFA RID: 2810 RVA: 0x0000AE75 File Offset: 0x00009075
		void dTljyMAPERKafkOoLqFGgRwgjxLO.SetSpecialElementNonLocalizedDescriptiveName(int index, string value)
		{
			if (this.SnjDgclkgepjNxyMjTbcMzZqNrhy == null || index >= this.SnjDgclkgepjNxyMjTbcMzZqNrhy.Count)
			{
				return;
			}
			this.SnjDgclkgepjNxyMjTbcMzZqNrhy[index].BRcDblsVJHeTcdOBKAZwnhsglgThA = value;
		}

		// Token: 0x06000AFB RID: 2811 RVA: 0x0000AEA0 File Offset: 0x000090A0
		string dTljyMAPERKafkOoLqFGgRwgjxLO.GetSpecialElementKey(int index)
		{
			if (this.SnjDgclkgepjNxyMjTbcMzZqNrhy == null || index >= this.SnjDgclkgepjNxyMjTbcMzZqNrhy.Count)
			{
				return null;
			}
			return this.SnjDgclkgepjNxyMjTbcMzZqNrhy[index].sDciFXSuqbieJhFarBLoQnWrCCST;
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x0000AECB File Offset: 0x000090CB
		void dTljyMAPERKafkOoLqFGgRwgjxLO.SetSpecialElementKey(int index, string value)
		{
			if (this.SnjDgclkgepjNxyMjTbcMzZqNrhy == null || index >= this.SnjDgclkgepjNxyMjTbcMzZqNrhy.Count)
			{
				return;
			}
			this.SnjDgclkgepjNxyMjTbcMzZqNrhy[index].sDciFXSuqbieJhFarBLoQnWrCCST = value;
		}

		// Token: 0x1700035B RID: 859
		// (get) Token: 0x06000AFD RID: 2813 RVA: 0x00006557 File Offset: 0x00004757
		string VHSvqsZIGaGVcFIeminrliAGzvFf.keyCategory
		{
			get
			{
				return "controller/template";
			}
		}

		// Token: 0x1700035C RID: 860
		// (get) Token: 0x06000AFE RID: 2814 RVA: 0x0000AD14 File Offset: 0x00008F14
		string VHSvqsZIGaGVcFIeminrliAGzvFf.key
		{
			get
			{
				return this._key;
			}
		}

		// Token: 0x1700035D RID: 861
		// (get) Token: 0x06000AFF RID: 2815 RVA: 0x0000AE39 File Offset: 0x00009039
		// (set) Token: 0x06000B00 RID: 2816 RVA: 0x0000AE41 File Offset: 0x00009041
		int VHSvqsZIGaGVcFIeminrliAGzvFf.autoGeneratedValueFlags
		{
			get
			{
				return this.vXJHDkCuFMVzeOuZSDMRqKgIQUDj;
			}
			set
			{
				this.vXJHDkCuFMVzeOuZSDMRqKgIQUDj = value;
			}
		}

		// Token: 0x1700035E RID: 862
		// (get) Token: 0x06000B01 RID: 2817 RVA: 0x0000AD1C File Offset: 0x00008F1C
		// (set) Token: 0x06000B02 RID: 2818 RVA: 0x0000AE27 File Offset: 0x00009027
		string fjbgpVwttnDrmmsUrHYXoyGuYHCH.positiveKey
		{
			get
			{
				return this._positiveKey;
			}
			set
			{
				this._positiveKey = value;
			}
		}

		// Token: 0x1700035F RID: 863
		// (get) Token: 0x06000B03 RID: 2819 RVA: 0x0000AD24 File Offset: 0x00008F24
		// (set) Token: 0x06000B04 RID: 2820 RVA: 0x0000AE30 File Offset: 0x00009030
		string fjbgpVwttnDrmmsUrHYXoyGuYHCH.negativeKey
		{
			get
			{
				return this._negativeKey;
			}
			set
			{
				this._negativeKey = value;
			}
		}

		// Token: 0x06000B05 RID: 2821 RVA: 0x0000AEA0 File Offset: 0x000090A0
		string oLkCONlJZKYzXoJthulbVunIVBjF.GetSpecialElementKey(int index)
		{
			if (this.SnjDgclkgepjNxyMjTbcMzZqNrhy == null || index >= this.SnjDgclkgepjNxyMjTbcMzZqNrhy.Count)
			{
				return null;
			}
			return this.SnjDgclkgepjNxyMjTbcMzZqNrhy[index].sDciFXSuqbieJhFarBLoQnWrCCST;
		}

		// Token: 0x06000B06 RID: 2822 RVA: 0x0000AECB File Offset: 0x000090CB
		void oLkCONlJZKYzXoJthulbVunIVBjF.SetSpecialElementKey(int index, string value)
		{
			if (this.SnjDgclkgepjNxyMjTbcMzZqNrhy == null || index >= this.SnjDgclkgepjNxyMjTbcMzZqNrhy.Count)
			{
				return;
			}
			this.SnjDgclkgepjNxyMjTbcMzZqNrhy[index].sDciFXSuqbieJhFarBLoQnWrCCST = value;
		}

		// Token: 0x06000B07 RID: 2823 RVA: 0x00048810 File Offset: 0x00046A10
		private static void hAzIWgKkwevjzAvmngbuJMMSboEdA(ControllerTemplateElementType A_0, out VhrRjYDSXtDmPGPepEmutTeotlnr.wBVDEckclaCUdHrHdLHuTDoxJWNc A_1, out VhrRjYDSXtDmPGPepEmutTeotlnr.ZqaUXWpANFaPfdXDRaVZzDjduZzZ A_2)
		{
			A_2 = VhrRjYDSXtDmPGPepEmutTeotlnr.ZqaUXWpANFaPfdXDRaVZzDjduZzZ.None;
			switch (A_0)
			{
			case ControllerTemplateElementType.Axis:
				A_1 = VhrRjYDSXtDmPGPepEmutTeotlnr.wBVDEckclaCUdHrHdLHuTDoxJWNc.Axis;
				return;
			case ControllerTemplateElementType.Button:
				A_1 = VhrRjYDSXtDmPGPepEmutTeotlnr.wBVDEckclaCUdHrHdLHuTDoxJWNc.Button;
				return;
			case ControllerTemplateElementType.ThumbStick:
				A_1 = VhrRjYDSXtDmPGPepEmutTeotlnr.wBVDEckclaCUdHrHdLHuTDoxJWNc.CompoundElement;
				return;
			case ControllerTemplateElementType.DPad:
				A_1 = VhrRjYDSXtDmPGPepEmutTeotlnr.wBVDEckclaCUdHrHdLHuTDoxJWNc.CompoundElement;
				A_2 = VhrRjYDSXtDmPGPepEmutTeotlnr.ZqaUXWpANFaPfdXDRaVZzDjduZzZ.DPad;
				return;
			case ControllerTemplateElementType.Stick:
				A_1 = VhrRjYDSXtDmPGPepEmutTeotlnr.wBVDEckclaCUdHrHdLHuTDoxJWNc.CompoundElement;
				A_2 = VhrRjYDSXtDmPGPepEmutTeotlnr.ZqaUXWpANFaPfdXDRaVZzDjduZzZ.Stick;
				return;
			case ControllerTemplateElementType.Throttle:
				A_1 = VhrRjYDSXtDmPGPepEmutTeotlnr.wBVDEckclaCUdHrHdLHuTDoxJWNc.Unknown;
				return;
			case ControllerTemplateElementType.Hat:
				A_1 = VhrRjYDSXtDmPGPepEmutTeotlnr.wBVDEckclaCUdHrHdLHuTDoxJWNc.CompoundElement;
				A_2 = VhrRjYDSXtDmPGPepEmutTeotlnr.ZqaUXWpANFaPfdXDRaVZzDjduZzZ.Hat;
				return;
			case ControllerTemplateElementType.Yoke:
				A_1 = VhrRjYDSXtDmPGPepEmutTeotlnr.wBVDEckclaCUdHrHdLHuTDoxJWNc.Unknown;
				return;
			case ControllerTemplateElementType.Stick6D:
				A_1 = VhrRjYDSXtDmPGPepEmutTeotlnr.wBVDEckclaCUdHrHdLHuTDoxJWNc.CompoundElement;
				A_2 = VhrRjYDSXtDmPGPepEmutTeotlnr.ZqaUXWpANFaPfdXDRaVZzDjduZzZ.Stick6D;
				return;
			}
			A_1 = VhrRjYDSXtDmPGPepEmutTeotlnr.wBVDEckclaCUdHrHdLHuTDoxJWNc.Unknown;
		}

		// Token: 0x04000791 RID: 1937
		private const string sXmOsLLpMgShrOrozCVyPxlzSqOA = "controller/template";

		// Token: 0x04000792 RID: 1938
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _id;

		// Token: 0x04000793 RID: 1939
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _name;

		// Token: 0x04000794 RID: 1940
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _positiveName;

		// Token: 0x04000795 RID: 1941
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _negativeName;

		// Token: 0x04000796 RID: 1942
		[SerializeField]
		[CustomObfuscation(rename = false)]
		public string _key;

		// Token: 0x04000797 RID: 1943
		[SerializeField]
		[CustomObfuscation(rename = false)]
		public string _positiveKey;

		// Token: 0x04000798 RID: 1944
		[SerializeField]
		[CustomObfuscation(rename = false)]
		public string _negativeKey;

		// Token: 0x04000799 RID: 1945
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ControllerTemplateElementType _elementType;

		// Token: 0x0400079A RID: 1946
		[NonSerialized]
		private hCXDpuHRLUFuvmVifjlUHPdRgCdY OMEQSicSgvgakwpqpVAXhlCDbjtgA;

		// Token: 0x0400079B RID: 1947
		[NonSerialized]
		private USiPXXLGXPFEcgQzLFiSdGGeGdfT UMKnHMfrFlmFGsgIhBSRZTKGeOrm;

		// Token: 0x0400079C RID: 1948
		[NonSerialized]
		private QcieCxwEzKhTJEpEnbzfGmQUosAm GJrVShIIjWJLwChTqlDreXJpCZzA;

		// Token: 0x0400079D RID: 1949
		[NonSerialized]
		private OloYVEiPyubyINOXSBORFBRAgOFC vLeBEjPEyOEueIsHQAVhCMLKPcsd;

		// Token: 0x0400079E RID: 1950
		[NonSerialized]
		private DeviceLocalizationInfo wazgirpMhJKlYEKNxtRKVVFaNRDo;

		// Token: 0x0400079F RID: 1951
		[NonSerialized]
		private int vXJHDkCuFMVzeOuZSDMRqKgIQUDj;

		// Token: 0x040007A0 RID: 1952
		[NonSerialized]
		private List<ControllerTemplateElementIdentifier.AwWWopCtyzshSEElkQGtPmOiJUIo> SnjDgclkgepjNxyMjTbcMzZqNrhy;

		// Token: 0x0200011D RID: 285
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		internal class ftBVjBGmwltSKoIhVlShRqVSZWYm
		{
			// Token: 0x040007A1 RID: 1953
			public int id;

			// Token: 0x040007A2 RID: 1954
			public string name;

			// Token: 0x040007A3 RID: 1955
			public string positiveName;

			// Token: 0x040007A4 RID: 1956
			public string negativeName;

			// Token: 0x040007A5 RID: 1957
			public string key;

			// Token: 0x040007A6 RID: 1958
			public string positiveKey;

			// Token: 0x040007A7 RID: 1959
			public string negativeKey;

			// Token: 0x040007A8 RID: 1960
			public ControllerTemplateElementType elementType;
		}

		// Token: 0x0200011E RID: 286
		internal sealed class EFocxzgwNJwOfUKDtxCHxkLgtHBm
		{
			// Token: 0x17000360 RID: 864
			// (get) Token: 0x06000B09 RID: 2825 RVA: 0x0000AEF6 File Offset: 0x000090F6
			private static ControllerTemplateElementIdentifier.EFocxzgwNJwOfUKDtxCHxkLgtHBm SdDXbbWRbbYAKkomFMGDFkBftdaG
			{
				get
				{
					if (ControllerTemplateElementIdentifier.EFocxzgwNJwOfUKDtxCHxkLgtHBm.FTVADFoXBUmENqvJARtGOHQxFSjk != null)
					{
						return ControllerTemplateElementIdentifier.EFocxzgwNJwOfUKDtxCHxkLgtHBm.FTVADFoXBUmENqvJARtGOHQxFSjk;
					}
					ControllerTemplateElementIdentifier.EFocxzgwNJwOfUKDtxCHxkLgtHBm.FTVADFoXBUmENqvJARtGOHQxFSjk = new ControllerTemplateElementIdentifier.EFocxzgwNJwOfUKDtxCHxkLgtHBm();
					ControllerTemplateElementIdentifier.EFocxzgwNJwOfUKDtxCHxkLgtHBm.FTVADFoXBUmENqvJARtGOHQxFSjk.GJJGlXJiHqcWAwgTUPxjZEOTHMJBA();
					return ControllerTemplateElementIdentifier.EFocxzgwNJwOfUKDtxCHxkLgtHBm.FTVADFoXBUmENqvJARtGOHQxFSjk;
				}
			}

			// Token: 0x06000B0A RID: 2826 RVA: 0x0000AF1E File Offset: 0x0000911E
			private EFocxzgwNJwOfUKDtxCHxkLgtHBm()
			{
				this.tDFFFusRKHGNXfoQEXOFYgfJpcfB = new HXLdpwfLmMygEUgGPgREFmOgqVGBA<ControllerTemplateElementIdentifier>(new Func<ControllerTemplateElementIdentifier, ControllerTemplateElementIdentifier, bool>(ControllerTemplateElementIdentifier.EFocxzgwNJwOfUKDtxCHxkLgtHBm.KjPLrInSXCrnJYGQOpFQyNjgYXiq.<>9.kHZWykhjVDHvtVsnlzhUUmdTKaRe));
			}

			// Token: 0x06000B0B RID: 2827 RVA: 0x0000AF50 File Offset: 0x00009150
			private void GJJGlXJiHqcWAwgTUPxjZEOTHMJBA()
			{
				ReInput.ShutDownEvent += ControllerTemplateElementIdentifier.EFocxzgwNJwOfUKDtxCHxkLgtHBm.FTVADFoXBUmENqvJARtGOHQxFSjk.KLTBsSFiwYXxBgFSiamoFPOSfimj;
			}

			// Token: 0x06000B0C RID: 2828 RVA: 0x0000AF67 File Offset: 0x00009167
			private void KLTBsSFiwYXxBgFSiamoFPOSfimj()
			{
				if (ControllerTemplateElementIdentifier.EFocxzgwNJwOfUKDtxCHxkLgtHBm.FTVADFoXBUmENqvJARtGOHQxFSjk == this)
				{
					ControllerTemplateElementIdentifier.EFocxzgwNJwOfUKDtxCHxkLgtHBm.FTVADFoXBUmENqvJARtGOHQxFSjk = null;
				}
				ReInput.ShutDownEvent -= this.KLTBsSFiwYXxBgFSiamoFPOSfimj;
			}

			// Token: 0x06000B0D RID: 2829 RVA: 0x0000AF88 File Offset: 0x00009188
			public static ControllerTemplateElementIdentifier SVHvDggBAtFWmgRPeAGOfmFAzRHBb(DeviceLocalizationInfo A_0, ControllerTemplateElementIdentifier A_1)
			{
				return ControllerTemplateElementIdentifier.EFocxzgwNJwOfUKDtxCHxkLgtHBm.SdDXbbWRbbYAKkomFMGDFkBftdaG.tDFFFusRKHGNXfoQEXOFYgfJpcfB.sisRxTizeCHHRjalSIxsvtVNWHCD(A_0.hash, A_1);
			}

			// Token: 0x06000B0E RID: 2830 RVA: 0x0000AFA0 File Offset: 0x000091A0
			public static bool jJSuKKsHyDrXgAXltdKcPNIDXwpG(DeviceLocalizationInfo A_0, ControllerTemplateElementIdentifier A_1, out ControllerTemplateElementIdentifier A_2)
			{
				return ControllerTemplateElementIdentifier.EFocxzgwNJwOfUKDtxCHxkLgtHBm.SdDXbbWRbbYAKkomFMGDFkBftdaG.tDFFFusRKHGNXfoQEXOFYgfJpcfB.AhbcNOVImFriqRufyBzueptQIzFU(A_0.hash, A_1, out A_2);
			}

			// Token: 0x06000B0F RID: 2831 RVA: 0x0000AFB9 File Offset: 0x000091B9
			public static void kiumPGWNpmulBHwmcQlavzxLOgmv(DeviceLocalizationInfo A_0, ControllerTemplateElementIdentifier A_1)
			{
				ControllerTemplateElementIdentifier.EFocxzgwNJwOfUKDtxCHxkLgtHBm.SdDXbbWRbbYAKkomFMGDFkBftdaG.tDFFFusRKHGNXfoQEXOFYgfJpcfB.xnbsxOCSckNIIyZiKiFycySIFrRr(A_0.hash, A_1);
			}

			// Token: 0x040007A9 RID: 1961
			private static ControllerTemplateElementIdentifier.EFocxzgwNJwOfUKDtxCHxkLgtHBm FTVADFoXBUmENqvJARtGOHQxFSjk;

			// Token: 0x040007AA RID: 1962
			private readonly HXLdpwfLmMygEUgGPgREFmOgqVGBA<ControllerTemplateElementIdentifier> tDFFFusRKHGNXfoQEXOFYgfJpcfB;

			// Token: 0x0200011F RID: 287
			[CompilerGenerated]
			[Serializable]
			private sealed class KjPLrInSXCrnJYGQOpFQyNjgYXiq
			{
				// Token: 0x06000B12 RID: 2834 RVA: 0x0000AFDD File Offset: 0x000091DD
				internal bool kHZWykhjVDHvtVsnlzhUUmdTKaRe(ControllerTemplateElementIdentifier A_1, ControllerTemplateElementIdentifier A_2)
				{
					return A_1 != null && A_2 != null && (A_1 != null && A_2 != null && A_1.id == A_2.id && A_1.elementType == A_2.elementType) && string.Equals(A_1.key, A_2.key, StringComparison.Ordinal);
				}

				// Token: 0x040007AB RID: 1963
				public static readonly ControllerTemplateElementIdentifier.EFocxzgwNJwOfUKDtxCHxkLgtHBm.KjPLrInSXCrnJYGQOpFQyNjgYXiq <>9 = new ControllerTemplateElementIdentifier.EFocxzgwNJwOfUKDtxCHxkLgtHBm.KjPLrInSXCrnJYGQOpFQyNjgYXiq();

				// Token: 0x040007AC RID: 1964
				public static Func<ControllerTemplateElementIdentifier, ControllerTemplateElementIdentifier, bool> <>9__4_0;
			}
		}

		// Token: 0x02000120 RID: 288
		private class AwWWopCtyzshSEElkQGtPmOiJUIo
		{
			// Token: 0x17000361 RID: 865
			// (get) Token: 0x06000B13 RID: 2835 RVA: 0x0000B01D File Offset: 0x0000921D
			// (set) Token: 0x06000B14 RID: 2836 RVA: 0x0000B025 File Offset: 0x00009225
			public string sDciFXSuqbieJhFarBLoQnWrCCST
			{
				get
				{
					return this.wrvqKJnvZNkJIFQFthdNtXAiMiox;
				}
				set
				{
					this.wrvqKJnvZNkJIFQFthdNtXAiMiox = value;
				}
			}

			// Token: 0x17000362 RID: 866
			// (get) Token: 0x06000B15 RID: 2837 RVA: 0x0000B02E File Offset: 0x0000922E
			// (set) Token: 0x06000B16 RID: 2838 RVA: 0x0000B036 File Offset: 0x00009236
			public string BRcDblsVJHeTcdOBKAZwnhsglgThA
			{
				get
				{
					return this.PWCEIKNUbaGcpOoAUHNlAKcHeqKf;
				}
				set
				{
					this.PWCEIKNUbaGcpOoAUHNlAKcHeqKf = value;
				}
			}

			// Token: 0x06000B17 RID: 2839 RVA: 0x000033F4 File Offset: 0x000015F4
			public AwWWopCtyzshSEElkQGtPmOiJUIo()
			{
			}

			// Token: 0x06000B18 RID: 2840 RVA: 0x0000B03F File Offset: 0x0000923F
			public AwWWopCtyzshSEElkQGtPmOiJUIo(ControllerTemplateElementIdentifier.AwWWopCtyzshSEElkQGtPmOiJUIo A_1)
			{
				this.wrvqKJnvZNkJIFQFthdNtXAiMiox = A_1.wrvqKJnvZNkJIFQFthdNtXAiMiox;
				this.PWCEIKNUbaGcpOoAUHNlAKcHeqKf = A_1.PWCEIKNUbaGcpOoAUHNlAKcHeqKf;
			}

			// Token: 0x040007AD RID: 1965
			[SerializeField]
			private string wrvqKJnvZNkJIFQFthdNtXAiMiox;

			// Token: 0x040007AE RID: 1966
			[SerializeField]
			private string PWCEIKNUbaGcpOoAUHNlAKcHeqKf;
		}
	}
}
