using System;
using Rewired.Internal.Localization;
using UnityEngine;

namespace Rewired
{
	// Token: 0x02000147 RID: 327
	[Serializable]
	public sealed class InputAction : djBPDCJyutcYSKkwfSFUMNGNGZXU, lcAibZuWMerLyEDicYNSneVLTvsj
	{
		// Token: 0x170003D6 RID: 982
		// (get) Token: 0x06000DC3 RID: 3523 RVA: 0x0000CCD3 File Offset: 0x0000AED3
		// (set) Token: 0x06000DC4 RID: 3524 RVA: 0x0000CCDB File Offset: 0x0000AEDB
		public int id
		{
			get
			{
				return this._id;
			}
			internal set
			{
				this._id = value;
			}
		}

		// Token: 0x170003D7 RID: 983
		// (get) Token: 0x06000DC5 RID: 3525 RVA: 0x0000CCE4 File Offset: 0x0000AEE4
		// (set) Token: 0x06000DC6 RID: 3526 RVA: 0x0000CCEC File Offset: 0x0000AEEC
		public string name
		{
			get
			{
				return this._name;
			}
			internal set
			{
				this._name = value;
				if (!ReInput.isReady || this.VDhYGecMamZfTsKeLRZiGaeWihUn == null)
				{
					return;
				}
				this.VDhYGecMamZfTsKeLRZiGaeWihUn.arHuKiMTAYIZtlKcEernIkmXCLMl();
			}
		}

		// Token: 0x170003D8 RID: 984
		// (get) Token: 0x06000DC7 RID: 3527 RVA: 0x0000CD10 File Offset: 0x0000AF10
		// (set) Token: 0x06000DC8 RID: 3528 RVA: 0x0000CD18 File Offset: 0x0000AF18
		public InputActionType type
		{
			get
			{
				return this._type;
			}
			internal set
			{
				this._type = value;
				if (!ReInput.isReady || this.VDhYGecMamZfTsKeLRZiGaeWihUn == null)
				{
					return;
				}
				this.VDhYGecMamZfTsKeLRZiGaeWihUn.rlsCoIxDSmwPYIuMOtuAjrdvhgSiA = InputAction.qBKgwOyJGhcDndYBWgNRZAxyyINFA(this._type);
			}
		}

		// Token: 0x170003D9 RID: 985
		// (get) Token: 0x06000DC9 RID: 3529 RVA: 0x0000CD47 File Offset: 0x0000AF47
		// (set) Token: 0x06000DCA RID: 3530 RVA: 0x0000CD71 File Offset: 0x0000AF71
		public string descriptiveName
		{
			get
			{
				if (!ReInput.isReady || !LocalizationManager.isEnabled || this.VDhYGecMamZfTsKeLRZiGaeWihUn == null)
				{
					return this._descriptiveName;
				}
				return this.VDhYGecMamZfTsKeLRZiGaeWihUn.QGZglKMnBTLJKJKOPknbgTZKPbAO;
			}
			internal set
			{
				this.nonLocalizedDescriptiveName = value;
			}
		}

		// Token: 0x170003DA RID: 986
		// (get) Token: 0x06000DCB RID: 3531 RVA: 0x0000CD7A File Offset: 0x0000AF7A
		// (set) Token: 0x06000DCC RID: 3532 RVA: 0x0000CDA4 File Offset: 0x0000AFA4
		public string positiveDescriptiveName
		{
			get
			{
				if (!ReInput.isReady || !LocalizationManager.isEnabled || this.VDhYGecMamZfTsKeLRZiGaeWihUn == null)
				{
					return this._positiveDescriptiveName;
				}
				return this.VDhYGecMamZfTsKeLRZiGaeWihUn.ouKRfZfTiXAAdpWYEfuBzPMgociw;
			}
			internal set
			{
				this.nonLocalizedPositiveDescriptiveName = value;
			}
		}

		// Token: 0x170003DB RID: 987
		// (get) Token: 0x06000DCD RID: 3533 RVA: 0x0000CDAD File Offset: 0x0000AFAD
		// (set) Token: 0x06000DCE RID: 3534 RVA: 0x0000CDD7 File Offset: 0x0000AFD7
		public string negativeDescriptiveName
		{
			get
			{
				if (!ReInput.isReady || !LocalizationManager.isEnabled || this.VDhYGecMamZfTsKeLRZiGaeWihUn == null)
				{
					return this._negativeDescriptiveName;
				}
				return this.VDhYGecMamZfTsKeLRZiGaeWihUn.AHaXPYUQTomysBARqTqPHTZSHXpe;
			}
			internal set
			{
				this.nonLocalizedNegativeDescriptiveName = value;
			}
		}

		// Token: 0x170003DC RID: 988
		// (get) Token: 0x06000DCF RID: 3535 RVA: 0x0000CDE0 File Offset: 0x0000AFE0
		// (set) Token: 0x06000DD0 RID: 3536 RVA: 0x0000CDE8 File Offset: 0x0000AFE8
		public int behaviorId
		{
			get
			{
				return this._behaviorId;
			}
			internal set
			{
				this._behaviorId = value;
			}
		}

		// Token: 0x170003DD RID: 989
		// (get) Token: 0x06000DD1 RID: 3537 RVA: 0x0000CDF1 File Offset: 0x0000AFF1
		// (set) Token: 0x06000DD2 RID: 3538 RVA: 0x0000CDF9 File Offset: 0x0000AFF9
		public int categoryId
		{
			get
			{
				return this._categoryId;
			}
			internal set
			{
				this._categoryId = value;
			}
		}

		// Token: 0x170003DE RID: 990
		// (get) Token: 0x06000DD3 RID: 3539 RVA: 0x0000CE02 File Offset: 0x0000B002
		// (set) Token: 0x06000DD4 RID: 3540 RVA: 0x0000CE0A File Offset: 0x0000B00A
		public bool userAssignable
		{
			get
			{
				return this._userAssignable;
			}
			internal set
			{
				this._userAssignable = value;
			}
		}

		// Token: 0x06000DD5 RID: 3541 RVA: 0x000033F4 File Offset: 0x000015F4
		public InputAction()
		{
		}

		// Token: 0x06000DD6 RID: 3542 RVA: 0x0005265C File Offset: 0x0005085C
		public InputAction(InputAction A_1)
		{
			this._id = A_1._id;
			this._name = A_1._name;
			this._type = A_1._type;
			this._descriptiveName = A_1._descriptiveName;
			this._positiveDescriptiveName = A_1._positiveDescriptiveName;
			this._negativeDescriptiveName = A_1._negativeDescriptiveName;
			this._key = A_1._key;
			this._positiveKey = A_1._positiveKey;
			this._negativeKey = A_1._negativeKey;
			this._behaviorId = A_1._behaviorId;
			this._userAssignable = A_1._userAssignable;
			this._categoryId = A_1.categoryId;
			this.MUIPOkmXFsvVVYYKrRlNhpnBVUNl = A_1.MUIPOkmXFsvVVYYKrRlNhpnBVUNl;
		}

		// Token: 0x06000DD7 RID: 3543 RVA: 0x0000CE13 File Offset: 0x0000B013
		public InputAction Clone()
		{
			return new InputAction(this);
		}

		// Token: 0x06000DD8 RID: 3544 RVA: 0x0000CE1B File Offset: 0x0000B01B
		public string GetDisplayName(AxisRange axisRange)
		{
			switch (axisRange)
			{
			case AxisRange.Full:
				return this.descriptiveName;
			case AxisRange.Positive:
				return this.positiveDescriptiveName;
			case AxisRange.Negative:
				return this.negativeDescriptiveName;
			default:
				throw new NotImplementedException();
			}
		}

		// Token: 0x170003DF RID: 991
		// (get) Token: 0x06000DD9 RID: 3545 RVA: 0x0000CE4B File Offset: 0x0000B04B
		// (set) Token: 0x06000DDA RID: 3546 RVA: 0x0000CE53 File Offset: 0x0000B053
		[CustomObfuscation(rename = false)]
		internal string key
		{
			get
			{
				return this._key;
			}
			set
			{
				this._key = value;
				if (!ReInput.isReady || this.VDhYGecMamZfTsKeLRZiGaeWihUn == null)
				{
					return;
				}
				this.VDhYGecMamZfTsKeLRZiGaeWihUn.humgPpaprOCTJdMoIVXMnKxZPobtb();
			}
		}

		// Token: 0x170003E0 RID: 992
		// (get) Token: 0x06000DDB RID: 3547 RVA: 0x0000CE77 File Offset: 0x0000B077
		// (set) Token: 0x06000DDC RID: 3548 RVA: 0x0000CE7F File Offset: 0x0000B07F
		[CustomObfuscation(rename = false)]
		internal string positiveKey
		{
			get
			{
				return this._positiveKey;
			}
			set
			{
				this._positiveKey = value;
				if (!ReInput.isReady || this.VDhYGecMamZfTsKeLRZiGaeWihUn == null)
				{
					return;
				}
				this.VDhYGecMamZfTsKeLRZiGaeWihUn.jgkwblaSHDTVBRqWjEqHhYTPmJQpA();
			}
		}

		// Token: 0x170003E1 RID: 993
		// (get) Token: 0x06000DDD RID: 3549 RVA: 0x0000CEA3 File Offset: 0x0000B0A3
		// (set) Token: 0x06000DDE RID: 3550 RVA: 0x0000CEAB File Offset: 0x0000B0AB
		[CustomObfuscation(rename = false)]
		internal string negativeKey
		{
			get
			{
				return this._negativeKey;
			}
			set
			{
				this._negativeKey = value;
				if (!ReInput.isReady || this.VDhYGecMamZfTsKeLRZiGaeWihUn == null)
				{
					return;
				}
				this.VDhYGecMamZfTsKeLRZiGaeWihUn.YqmyBgcFWQdMXgdaGWjStNNeppOyA();
			}
		}

		// Token: 0x170003E2 RID: 994
		// (get) Token: 0x06000DDF RID: 3551 RVA: 0x0000CECF File Offset: 0x0000B0CF
		// (set) Token: 0x06000DE0 RID: 3552 RVA: 0x0000CED7 File Offset: 0x0000B0D7
		[CustomObfuscation(rename = false)]
		internal string nonLocalizedDescriptiveName
		{
			get
			{
				return this._descriptiveName;
			}
			set
			{
				this._descriptiveName = value;
				if (!ReInput.isReady || this.VDhYGecMamZfTsKeLRZiGaeWihUn == null)
				{
					return;
				}
				this.VDhYGecMamZfTsKeLRZiGaeWihUn.OlcAFIbuEHvUomQdyRvLXKoljCWJ();
			}
		}

		// Token: 0x170003E3 RID: 995
		// (get) Token: 0x06000DE1 RID: 3553 RVA: 0x0000CEFB File Offset: 0x0000B0FB
		// (set) Token: 0x06000DE2 RID: 3554 RVA: 0x0000CF03 File Offset: 0x0000B103
		[CustomObfuscation(rename = false)]
		internal string nonLocalizedPositiveDescriptiveName
		{
			get
			{
				return this._positiveDescriptiveName;
			}
			set
			{
				this._positiveDescriptiveName = value;
				if (!ReInput.isReady || this.VDhYGecMamZfTsKeLRZiGaeWihUn == null)
				{
					return;
				}
				this.VDhYGecMamZfTsKeLRZiGaeWihUn.hEFzpZMEhaJYzHkMYgtFIevqGShY();
			}
		}

		// Token: 0x170003E4 RID: 996
		// (get) Token: 0x06000DE3 RID: 3555 RVA: 0x0000CF27 File Offset: 0x0000B127
		// (set) Token: 0x06000DE4 RID: 3556 RVA: 0x0000CF2F File Offset: 0x0000B12F
		[CustomObfuscation(rename = false)]
		internal string nonLocalizedNegativeDescriptiveName
		{
			get
			{
				return this._negativeDescriptiveName;
			}
			set
			{
				this._negativeDescriptiveName = value;
				if (!ReInput.isReady || this.VDhYGecMamZfTsKeLRZiGaeWihUn == null)
				{
					return;
				}
				this.VDhYGecMamZfTsKeLRZiGaeWihUn.UhCcgieCihFlYvAACQRSZOqugFYbb();
			}
		}

		// Token: 0x06000DE5 RID: 3557 RVA: 0x0000CF53 File Offset: 0x0000B153
		internal void CuUuzvRCcKAFhTQQigkFvHPLJMWU()
		{
			if (this.VDhYGecMamZfTsKeLRZiGaeWihUn == null)
			{
				this.VDhYGecMamZfTsKeLRZiGaeWihUn = xNzZdgghQJgzvgvbTBsDoehKUYPOA.PbCdxLwLHiSxrZcoybXIJzxpAzgN(this, InputAction.qBKgwOyJGhcDndYBWgNRZAxyyINFA(this._type), VhrRjYDSXtDmPGPepEmutTeotlnr.ZqaUXWpANFaPfdXDRaVZzDjduZzZ.None);
			}
		}

		// Token: 0x06000DE6 RID: 3558 RVA: 0x0000CF75 File Offset: 0x0000B175
		internal void bKsApSvdbqUpgWhodCohplcAbcFeA()
		{
			if (this.VDhYGecMamZfTsKeLRZiGaeWihUn != null)
			{
				this.VDhYGecMamZfTsKeLRZiGaeWihUn = null;
			}
		}

		// Token: 0x06000DE7 RID: 3559 RVA: 0x00003E2E File Offset: 0x0000202E
		private static VhrRjYDSXtDmPGPepEmutTeotlnr.wBVDEckclaCUdHrHdLHuTDoxJWNc qBKgwOyJGhcDndYBWgNRZAxyyINFA(InputActionType A_0)
		{
			if (A_0 == InputActionType.Axis)
			{
				return VhrRjYDSXtDmPGPepEmutTeotlnr.wBVDEckclaCUdHrHdLHuTDoxJWNc.Axis;
			}
			if (A_0 != InputActionType.Button)
			{
				throw new NotImplementedException();
			}
			return VhrRjYDSXtDmPGPepEmutTeotlnr.wBVDEckclaCUdHrHdLHuTDoxJWNc.Button;
		}

		// Token: 0x170003E5 RID: 997
		// (get) Token: 0x06000DE8 RID: 3560 RVA: 0x0000CF86 File Offset: 0x0000B186
		string lcAibZuWMerLyEDicYNSneVLTvsj.keyCategory
		{
			get
			{
				return "action";
			}
		}

		// Token: 0x170003E6 RID: 998
		// (get) Token: 0x06000DE9 RID: 3561 RVA: 0x0000CCE4 File Offset: 0x0000AEE4
		string lcAibZuWMerLyEDicYNSneVLTvsj.scriptingName
		{
			get
			{
				return this._name;
			}
		}

		// Token: 0x170003E7 RID: 999
		// (get) Token: 0x06000DEA RID: 3562 RVA: 0x0000CECF File Offset: 0x0000B0CF
		// (set) Token: 0x06000DEB RID: 3563 RVA: 0x0000CF8D File Offset: 0x0000B18D
		string lcAibZuWMerLyEDicYNSneVLTvsj.nonLocalizedDescriptiveName
		{
			get
			{
				return this._descriptiveName;
			}
			set
			{
				this._descriptiveName = value;
			}
		}

		// Token: 0x170003E8 RID: 1000
		// (get) Token: 0x06000DEC RID: 3564 RVA: 0x0000CEFB File Offset: 0x0000B0FB
		// (set) Token: 0x06000DED RID: 3565 RVA: 0x0000CF96 File Offset: 0x0000B196
		string djBPDCJyutcYSKkwfSFUMNGNGZXU.nonLocalizedPositiveDescriptiveName
		{
			get
			{
				return this._positiveDescriptiveName;
			}
			set
			{
				this._positiveDescriptiveName = value;
			}
		}

		// Token: 0x170003E9 RID: 1001
		// (get) Token: 0x06000DEE RID: 3566 RVA: 0x0000CF27 File Offset: 0x0000B127
		// (set) Token: 0x06000DEF RID: 3567 RVA: 0x0000CF9F File Offset: 0x0000B19F
		string djBPDCJyutcYSKkwfSFUMNGNGZXU.nonLocalizedNegativeDescriptiveName
		{
			get
			{
				return this._negativeDescriptiveName;
			}
			set
			{
				this._negativeDescriptiveName = value;
			}
		}

		// Token: 0x170003EA RID: 1002
		// (get) Token: 0x06000DF0 RID: 3568 RVA: 0x0000CE4B File Offset: 0x0000B04B
		string lcAibZuWMerLyEDicYNSneVLTvsj.key
		{
			get
			{
				return this._key;
			}
		}

		// Token: 0x170003EB RID: 1003
		// (get) Token: 0x06000DF1 RID: 3569 RVA: 0x0000CE77 File Offset: 0x0000B077
		// (set) Token: 0x06000DF2 RID: 3570 RVA: 0x0000CFA8 File Offset: 0x0000B1A8
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

		// Token: 0x170003EC RID: 1004
		// (get) Token: 0x06000DF3 RID: 3571 RVA: 0x0000CEA3 File Offset: 0x0000B0A3
		// (set) Token: 0x06000DF4 RID: 3572 RVA: 0x0000CFB1 File Offset: 0x0000B1B1
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

		// Token: 0x170003ED RID: 1005
		// (get) Token: 0x06000DF5 RID: 3573 RVA: 0x0000CFBA File Offset: 0x0000B1BA
		// (set) Token: 0x06000DF6 RID: 3574 RVA: 0x0000CFC2 File Offset: 0x0000B1C2
		int lcAibZuWMerLyEDicYNSneVLTvsj.autoGeneratedValueFlags
		{
			get
			{
				return this.MUIPOkmXFsvVVYYKrRlNhpnBVUNl;
			}
			set
			{
				this.MUIPOkmXFsvVVYYKrRlNhpnBVUNl = value;
			}
		}

		// Token: 0x040008A5 RID: 2213
		private const string keyCategory = "action";

		// Token: 0x040008A6 RID: 2214
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _id;

		// Token: 0x040008A7 RID: 2215
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _name;

		// Token: 0x040008A8 RID: 2216
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private InputActionType _type;

		// Token: 0x040008A9 RID: 2217
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _descriptiveName;

		// Token: 0x040008AA RID: 2218
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _positiveDescriptiveName;

		// Token: 0x040008AB RID: 2219
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _negativeDescriptiveName;

		// Token: 0x040008AC RID: 2220
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _key;

		// Token: 0x040008AD RID: 2221
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _positiveKey;

		// Token: 0x040008AE RID: 2222
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _negativeKey;

		// Token: 0x040008AF RID: 2223
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _behaviorId;

		// Token: 0x040008B0 RID: 2224
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _userAssignable;

		// Token: 0x040008B1 RID: 2225
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _categoryId;

		// Token: 0x040008B2 RID: 2226
		[NonSerialized]
		private xNzZdgghQJgzvgvbTBsDoehKUYPOA VDhYGecMamZfTsKeLRZiGaeWihUn;

		// Token: 0x040008B3 RID: 2227
		[NonSerialized]
		private int MUIPOkmXFsvVVYYKrRlNhpnBVUNl;
	}
}
