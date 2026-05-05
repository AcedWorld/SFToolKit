using System;
using System.Collections.Generic;
using System.ComponentModel;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Data
{
	// Token: 0x02000258 RID: 600
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	public sealed class Player_Editor
	{
		// Token: 0x1700066F RID: 1647
		// (get) Token: 0x06001B4A RID: 6986 RVA: 0x0001605E File Offset: 0x0001425E
		// (set) Token: 0x06001B4B RID: 6987 RVA: 0x00016066 File Offset: 0x00014266
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

		// Token: 0x17000670 RID: 1648
		// (get) Token: 0x06001B4C RID: 6988 RVA: 0x0001606F File Offset: 0x0001426F
		// (set) Token: 0x06001B4D RID: 6989 RVA: 0x00016077 File Offset: 0x00014277
		public string name
		{
			get
			{
				return this._name;
			}
			internal set
			{
				this._name = value;
			}
		}

		// Token: 0x17000671 RID: 1649
		// (get) Token: 0x06001B4E RID: 6990 RVA: 0x00016080 File Offset: 0x00014280
		// (set) Token: 0x06001B4F RID: 6991 RVA: 0x00016088 File Offset: 0x00014288
		public string descriptiveName
		{
			get
			{
				return this._descriptiveName;
			}
			internal set
			{
				this._descriptiveName = value;
			}
		}

		// Token: 0x17000672 RID: 1650
		// (get) Token: 0x06001B50 RID: 6992 RVA: 0x00016091 File Offset: 0x00014291
		// (set) Token: 0x06001B51 RID: 6993 RVA: 0x00016099 File Offset: 0x00014299
		public string key
		{
			get
			{
				return this._key;
			}
			internal set
			{
				this._key = value;
			}
		}

		// Token: 0x17000673 RID: 1651
		// (get) Token: 0x06001B52 RID: 6994 RVA: 0x000160A2 File Offset: 0x000142A2
		// (set) Token: 0x06001B53 RID: 6995 RVA: 0x000160AA File Offset: 0x000142AA
		public bool startPlaying
		{
			get
			{
				return this._startPlaying;
			}
			internal set
			{
				this._startPlaying = value;
			}
		}

		// Token: 0x17000674 RID: 1652
		// (get) Token: 0x06001B54 RID: 6996 RVA: 0x000160B3 File Offset: 0x000142B3
		// (set) Token: 0x06001B55 RID: 6997 RVA: 0x000160BB File Offset: 0x000142BB
		public List<Player_Editor.Mapping> defaultJoystickMaps
		{
			get
			{
				return this._defaultJoystickMaps;
			}
			internal set
			{
				this._defaultJoystickMaps = value;
			}
		}

		// Token: 0x17000675 RID: 1653
		// (get) Token: 0x06001B56 RID: 6998 RVA: 0x000160C4 File Offset: 0x000142C4
		// (set) Token: 0x06001B57 RID: 6999 RVA: 0x000160CC File Offset: 0x000142CC
		public List<Player_Editor.Mapping> defaultMouseMaps
		{
			get
			{
				return this._defaultMouseMaps;
			}
			internal set
			{
				this._defaultMouseMaps = value;
			}
		}

		// Token: 0x17000676 RID: 1654
		// (get) Token: 0x06001B58 RID: 7000 RVA: 0x000160D5 File Offset: 0x000142D5
		// (set) Token: 0x06001B59 RID: 7001 RVA: 0x000160DD File Offset: 0x000142DD
		public List<Player_Editor.Mapping> defaultKeyboardMaps
		{
			get
			{
				return this._defaultKeyboardMaps;
			}
			internal set
			{
				this._defaultKeyboardMaps = value;
			}
		}

		// Token: 0x17000677 RID: 1655
		// (get) Token: 0x06001B5A RID: 7002 RVA: 0x000160E6 File Offset: 0x000142E6
		// (set) Token: 0x06001B5B RID: 7003 RVA: 0x000160EE File Offset: 0x000142EE
		public List<Player_Editor.Mapping> defaultCustomControllerMaps
		{
			get
			{
				return this._defaultCustomControllerMaps;
			}
			internal set
			{
				this._defaultCustomControllerMaps = value;
			}
		}

		// Token: 0x17000678 RID: 1656
		// (get) Token: 0x06001B5C RID: 7004 RVA: 0x000160F7 File Offset: 0x000142F7
		// (set) Token: 0x06001B5D RID: 7005 RVA: 0x000160FF File Offset: 0x000142FF
		public List<Player_Editor.CreateControllerInfo> startingCustomControllers
		{
			get
			{
				return this._startingCustomControllers;
			}
			internal set
			{
				this._startingCustomControllers = value;
			}
		}

		// Token: 0x17000679 RID: 1657
		// (get) Token: 0x06001B5E RID: 7006 RVA: 0x00016108 File Offset: 0x00014308
		// (set) Token: 0x06001B5F RID: 7007 RVA: 0x00016110 File Offset: 0x00014310
		public bool assignMouseOnStart
		{
			get
			{
				return this._assignMouseOnStart;
			}
			internal set
			{
				this._assignMouseOnStart = value;
			}
		}

		// Token: 0x1700067A RID: 1658
		// (get) Token: 0x06001B60 RID: 7008 RVA: 0x00016119 File Offset: 0x00014319
		// (set) Token: 0x06001B61 RID: 7009 RVA: 0x00016121 File Offset: 0x00014321
		public bool assignKeyboardOnStart
		{
			get
			{
				return this._assignKeyboardOnStart;
			}
			internal set
			{
				this._assignKeyboardOnStart = value;
			}
		}

		// Token: 0x1700067B RID: 1659
		// (get) Token: 0x06001B62 RID: 7010 RVA: 0x0001612A File Offset: 0x0001432A
		// (set) Token: 0x06001B63 RID: 7011 RVA: 0x00016132 File Offset: 0x00014332
		public bool excludeFromControllerAutoAssignment
		{
			get
			{
				return this._excludeFromControllerAutoAssignment;
			}
			internal set
			{
				this._excludeFromControllerAutoAssignment = value;
			}
		}

		// Token: 0x1700067C RID: 1660
		// (get) Token: 0x06001B64 RID: 7012 RVA: 0x0001613B File Offset: 0x0001433B
		// (set) Token: 0x06001B65 RID: 7013 RVA: 0x00016143 File Offset: 0x00014343
		public Player_Editor.ControllerMapLayoutManagerSettings controllerMapLayoutManagerSettings
		{
			get
			{
				return this._controllerMapLayoutManagerSettings;
			}
			set
			{
				this._controllerMapLayoutManagerSettings = value;
			}
		}

		// Token: 0x1700067D RID: 1661
		// (get) Token: 0x06001B66 RID: 7014 RVA: 0x0001614C File Offset: 0x0001434C
		// (set) Token: 0x06001B67 RID: 7015 RVA: 0x00016154 File Offset: 0x00014354
		public Player_Editor.ControllerMapEnablerSettings controllerMapEnablerSettings
		{
			get
			{
				return this._controllerMapEnablerSettings;
			}
			set
			{
				this._controllerMapEnablerSettings = value;
			}
		}

		// Token: 0x06001B68 RID: 7016 RVA: 0x000758A4 File Offset: 0x00073AA4
		public Player_Editor()
		{
			this._defaultKeyboardMaps = new List<Player_Editor.Mapping>();
			this._defaultJoystickMaps = new List<Player_Editor.Mapping>();
			this._defaultMouseMaps = new List<Player_Editor.Mapping>();
			this._defaultCustomControllerMaps = new List<Player_Editor.Mapping>();
			this._startingCustomControllers = new List<Player_Editor.CreateControllerInfo>();
			this._excludeFromControllerAutoAssignment = false;
			this._controllerMapLayoutManagerSettings = new Player_Editor.ControllerMapLayoutManagerSettings();
			this._controllerMapEnablerSettings = new Player_Editor.ControllerMapEnablerSettings();
		}

		// Token: 0x06001B69 RID: 7017 RVA: 0x00075914 File Offset: 0x00073B14
		public Player_Editor(Player_Editor A_1)
		{
			this._id = A_1._id;
			this._name = A_1._name;
			this._descriptiveName = A_1._descriptiveName;
			this._key = A_1._key;
			this._startPlaying = A_1._startPlaying;
			this._defaultJoystickMaps = new List<Player_Editor.Mapping>();
			if (A_1._defaultJoystickMaps != null)
			{
				for (int i = 0; i < A_1._defaultJoystickMaps.Count; i++)
				{
					this._defaultJoystickMaps.Add(A_1._defaultJoystickMaps[i].Clone());
				}
			}
			this._defaultKeyboardMaps = new List<Player_Editor.Mapping>();
			if (A_1._defaultKeyboardMaps != null)
			{
				for (int j = 0; j < A_1._defaultKeyboardMaps.Count; j++)
				{
					this._defaultKeyboardMaps.Add(A_1._defaultKeyboardMaps[j].Clone());
				}
			}
			this._defaultMouseMaps = new List<Player_Editor.Mapping>();
			if (A_1._defaultMouseMaps != null)
			{
				for (int k = 0; k < A_1._defaultMouseMaps.Count; k++)
				{
					this._defaultMouseMaps.Add(A_1._defaultMouseMaps[k].Clone());
				}
			}
			this._defaultCustomControllerMaps = new List<Player_Editor.Mapping>();
			if (A_1._defaultCustomControllerMaps != null)
			{
				for (int l = 0; l < A_1._defaultCustomControllerMaps.Count; l++)
				{
					this._defaultCustomControllerMaps.Add(A_1._defaultCustomControllerMaps[l].Clone());
				}
			}
			this._startingCustomControllers = new List<Player_Editor.CreateControllerInfo>();
			if (A_1._startingCustomControllers != null)
			{
				for (int m = 0; m < A_1._startingCustomControllers.Count; m++)
				{
					this._startingCustomControllers.Add(new Player_Editor.CreateControllerInfo(A_1._startingCustomControllers[m]));
				}
			}
			this._controllerMapLayoutManagerSettings = (MiscTools.DeepClone<Player_Editor.ControllerMapLayoutManagerSettings>(A_1._controllerMapLayoutManagerSettings) ?? new Player_Editor.ControllerMapLayoutManagerSettings());
			this._controllerMapEnablerSettings = (MiscTools.DeepClone<Player_Editor.ControllerMapEnablerSettings>(A_1._controllerMapEnablerSettings) ?? new Player_Editor.ControllerMapEnablerSettings());
			this._assignMouseOnStart = A_1._assignMouseOnStart;
			this._assignKeyboardOnStart = A_1._assignKeyboardOnStart;
			this._excludeFromControllerAutoAssignment = A_1._excludeFromControllerAutoAssignment;
		}

		// Token: 0x06001B6A RID: 7018 RVA: 0x0001615D File Offset: 0x0001435D
		public Player_Editor Clone()
		{
			return new Player_Editor(this);
		}

		// Token: 0x06001B6B RID: 7019 RVA: 0x00075B20 File Offset: 0x00073D20
		internal OdwwNwDVsLLbukoEpkWRZpETNEYi eAGuRMxClukjwqFIajUiWCwxmMrr()
		{
			UkACnUMHYxhtrputCZbaeXOybpyB[] array = null;
			if (this._defaultJoystickMaps != null)
			{
				array = new UkACnUMHYxhtrputCZbaeXOybpyB[this._defaultJoystickMaps.Count];
				for (int i = 0; i < this._defaultJoystickMaps.Count; i++)
				{
					array[i] = this._defaultJoystickMaps[i].jjgQAEFuolwVQTyZzoAWNRPPeFNQ();
				}
			}
			UkACnUMHYxhtrputCZbaeXOybpyB[] array2 = null;
			if (this._defaultKeyboardMaps != null)
			{
				array2 = new UkACnUMHYxhtrputCZbaeXOybpyB[this._defaultKeyboardMaps.Count];
				for (int j = 0; j < this._defaultKeyboardMaps.Count; j++)
				{
					array2[j] = this._defaultKeyboardMaps[j].jjgQAEFuolwVQTyZzoAWNRPPeFNQ();
				}
			}
			UkACnUMHYxhtrputCZbaeXOybpyB[] array3 = null;
			if (this._defaultMouseMaps != null)
			{
				array3 = new UkACnUMHYxhtrputCZbaeXOybpyB[this._defaultMouseMaps.Count];
				for (int k = 0; k < this._defaultMouseMaps.Count; k++)
				{
					array3[k] = this._defaultMouseMaps[k].jjgQAEFuolwVQTyZzoAWNRPPeFNQ();
				}
			}
			UkACnUMHYxhtrputCZbaeXOybpyB[] array4 = null;
			if (this._defaultCustomControllerMaps != null)
			{
				array4 = new UkACnUMHYxhtrputCZbaeXOybpyB[this._defaultCustomControllerMaps.Count];
				for (int l = 0; l < this._defaultCustomControllerMaps.Count; l++)
				{
					array4[l] = this._defaultCustomControllerMaps[l].jjgQAEFuolwVQTyZzoAWNRPPeFNQ();
				}
			}
			return new OdwwNwDVsLLbukoEpkWRZpETNEYi(array, array2, array3, array4);
		}

		// Token: 0x04000FA1 RID: 4001
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _id;

		// Token: 0x04000FA2 RID: 4002
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _name;

		// Token: 0x04000FA3 RID: 4003
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _descriptiveName;

		// Token: 0x04000FA4 RID: 4004
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _key;

		// Token: 0x04000FA5 RID: 4005
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _startPlaying;

		// Token: 0x04000FA6 RID: 4006
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<Player_Editor.Mapping> _defaultJoystickMaps;

		// Token: 0x04000FA7 RID: 4007
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<Player_Editor.Mapping> _defaultMouseMaps;

		// Token: 0x04000FA8 RID: 4008
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<Player_Editor.Mapping> _defaultKeyboardMaps;

		// Token: 0x04000FA9 RID: 4009
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<Player_Editor.Mapping> _defaultCustomControllerMaps;

		// Token: 0x04000FAA RID: 4010
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<Player_Editor.CreateControllerInfo> _startingCustomControllers;

		// Token: 0x04000FAB RID: 4011
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _assignMouseOnStart;

		// Token: 0x04000FAC RID: 4012
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _assignKeyboardOnStart = true;

		// Token: 0x04000FAD RID: 4013
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _excludeFromControllerAutoAssignment;

		// Token: 0x04000FAE RID: 4014
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Player_Editor.ControllerMapLayoutManagerSettings _controllerMapLayoutManagerSettings;

		// Token: 0x04000FAF RID: 4015
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Player_Editor.ControllerMapEnablerSettings _controllerMapEnablerSettings;

		// Token: 0x02000259 RID: 601
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Serializable]
		public sealed class Mapping
		{
			// Token: 0x1700067E RID: 1662
			// (get) Token: 0x06001B6C RID: 7020 RVA: 0x00016165 File Offset: 0x00014365
			// (set) Token: 0x06001B6D RID: 7021 RVA: 0x0001616D File Offset: 0x0001436D
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

			// Token: 0x1700067F RID: 1663
			// (get) Token: 0x06001B6E RID: 7022 RVA: 0x00016176 File Offset: 0x00014376
			// (set) Token: 0x06001B6F RID: 7023 RVA: 0x0001617E File Offset: 0x0001437E
			public int layoutId
			{
				get
				{
					return this._layoutId;
				}
				internal set
				{
					this._layoutId = value;
				}
			}

			// Token: 0x17000680 RID: 1664
			// (get) Token: 0x06001B70 RID: 7024 RVA: 0x00016187 File Offset: 0x00014387
			// (set) Token: 0x06001B71 RID: 7025 RVA: 0x0001618F File Offset: 0x0001438F
			public bool enabled
			{
				get
				{
					return this._enabled;
				}
				internal set
				{
					this._enabled = value;
				}
			}

			// Token: 0x06001B72 RID: 7026 RVA: 0x00016198 File Offset: 0x00014398
			public Mapping()
			{
				this.Clear();
			}

			// Token: 0x06001B73 RID: 7027 RVA: 0x000161A6 File Offset: 0x000143A6
			public Mapping(bool A_1, int A_2, int A_3)
			{
				this._enabled = A_1;
				this._categoryId = A_2;
				this._layoutId = A_3;
			}

			// Token: 0x06001B74 RID: 7028 RVA: 0x000161C3 File Offset: 0x000143C3
			public void Clear()
			{
				this._categoryId = 0;
				this._layoutId = 0;
				this._enabled = true;
			}

			// Token: 0x06001B75 RID: 7029 RVA: 0x000161DA File Offset: 0x000143DA
			public Player_Editor.Mapping Clone()
			{
				return new Player_Editor.Mapping(this._enabled, this._categoryId, this._layoutId);
			}

			// Token: 0x06001B76 RID: 7030 RVA: 0x000161F3 File Offset: 0x000143F3
			internal UkACnUMHYxhtrputCZbaeXOybpyB jjgQAEFuolwVQTyZzoAWNRPPeFNQ()
			{
				return new UkACnUMHYxhtrputCZbaeXOybpyB(this._categoryId, this._layoutId, this._enabled);
			}

			// Token: 0x04000FB0 RID: 4016
			[SerializeField]
			[CustomObfuscation(rename = false)]
			private bool _enabled;

			// Token: 0x04000FB1 RID: 4017
			[SerializeField]
			[CustomObfuscation(rename = false)]
			private int _categoryId;

			// Token: 0x04000FB2 RID: 4018
			[SerializeField]
			[CustomObfuscation(rename = false)]
			private int _layoutId;
		}

		// Token: 0x0200025A RID: 602
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Serializable]
		public sealed class ControllerMapLayoutManagerSettings : IDeepCloneable
		{
			// Token: 0x17000681 RID: 1665
			// (get) Token: 0x06001B77 RID: 7031 RVA: 0x0001620C File Offset: 0x0001440C
			// (set) Token: 0x06001B78 RID: 7032 RVA: 0x00016214 File Offset: 0x00014414
			public bool enabled
			{
				get
				{
					return this._enabled;
				}
				set
				{
					this._enabled = value;
				}
			}

			// Token: 0x17000682 RID: 1666
			// (get) Token: 0x06001B79 RID: 7033 RVA: 0x0001621D File Offset: 0x0001441D
			// (set) Token: 0x06001B7A RID: 7034 RVA: 0x00016225 File Offset: 0x00014425
			public bool loadFromUserDataStore
			{
				get
				{
					return this._loadFromUserDataStore;
				}
				set
				{
					this._loadFromUserDataStore = value;
				}
			}

			// Token: 0x17000683 RID: 1667
			// (get) Token: 0x06001B7B RID: 7035 RVA: 0x0001622E File Offset: 0x0001442E
			// (set) Token: 0x06001B7C RID: 7036 RVA: 0x00075C64 File Offset: 0x00073E64
			public List<Player_Editor.RuleSetMapping> ruleSets
			{
				get
				{
					return this._ruleSets;
				}
				set
				{
					this._ruleSets = (value ?? (this._ruleSets = new List<Player_Editor.RuleSetMapping>()));
				}
			}

			// Token: 0x06001B7D RID: 7037 RVA: 0x00016236 File Offset: 0x00014436
			public ControllerMapLayoutManagerSettings()
			{
				this._ruleSets = new List<Player_Editor.RuleSetMapping>();
				this._enabled = true;
				this._loadFromUserDataStore = true;
			}

			// Token: 0x06001B7E RID: 7038 RVA: 0x00075C8C File Offset: 0x00073E8C
			public ControllerMapLayoutManagerSettings(Player_Editor.ControllerMapLayoutManagerSettings A_1)
			{
				if (A_1 == null)
				{
					throw new ArgumentNullException("source");
				}
				this._enabled = A_1._enabled;
				this._loadFromUserDataStore = A_1._loadFromUserDataStore;
				this._ruleSets = (MiscTools.DeepClone<Player_Editor.RuleSetMapping>(A_1._ruleSets) ?? new List<Player_Editor.RuleSetMapping>());
			}

			// Token: 0x06001B7F RID: 7039 RVA: 0x00016265 File Offset: 0x00014465
			internal ControllerMapLayoutManager.YuRWKBhEFGtHaIyXShqNamLdASyj MffSkaAdYbkTCWPcYqvQvoYPYQEM()
			{
				return new ControllerMapLayoutManager.YuRWKBhEFGtHaIyXShqNamLdASyj(this._enabled, this._loadFromUserDataStore, this.qTXquWUaBFgJNCOQBfQYGcrKlAIe());
			}

			// Token: 0x06001B80 RID: 7040 RVA: 0x00075CF0 File Offset: 0x00073EF0
			private JjxttxsSyopWvkcsgVXYLeVlEgvS[] qTXquWUaBFgJNCOQBfQYGcrKlAIe()
			{
				List<JjxttxsSyopWvkcsgVXYLeVlEgvS> list = new List<JjxttxsSyopWvkcsgVXYLeVlEgvS>();
				int num = (this._ruleSets != null) ? this._ruleSets.Count : 0;
				for (int i = 0; i < num; i++)
				{
					if (this._ruleSets[i] != null)
					{
						list.Add(this._ruleSets[i].lpSdWOgQJBetjyiZoVcPWcQjhVIAb());
					}
				}
				return list.ToArray();
			}

			// Token: 0x06001B81 RID: 7041 RVA: 0x0001627E File Offset: 0x0001447E
			object IDeepCloneable.DeepClone()
			{
				return new Player_Editor.ControllerMapLayoutManagerSettings(this);
			}

			// Token: 0x04000FB3 RID: 4019
			[SerializeField]
			[CustomObfuscation(rename = false)]
			private bool _enabled = true;

			// Token: 0x04000FB4 RID: 4020
			[SerializeField]
			[CustomObfuscation(rename = false)]
			private bool _loadFromUserDataStore = true;

			// Token: 0x04000FB5 RID: 4021
			[SerializeField]
			[CustomObfuscation(rename = false)]
			private List<Player_Editor.RuleSetMapping> _ruleSets;
		}

		// Token: 0x0200025B RID: 603
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Serializable]
		public sealed class ControllerMapEnablerSettings : IDeepCloneable
		{
			// Token: 0x17000684 RID: 1668
			// (get) Token: 0x06001B82 RID: 7042 RVA: 0x00016286 File Offset: 0x00014486
			// (set) Token: 0x06001B83 RID: 7043 RVA: 0x0001628E File Offset: 0x0001448E
			public bool enabled
			{
				get
				{
					return this._enabled;
				}
				set
				{
					this._enabled = value;
				}
			}

			// Token: 0x17000685 RID: 1669
			// (get) Token: 0x06001B84 RID: 7044 RVA: 0x00016297 File Offset: 0x00014497
			// (set) Token: 0x06001B85 RID: 7045 RVA: 0x00075D54 File Offset: 0x00073F54
			public List<Player_Editor.RuleSetMapping> ruleSets
			{
				get
				{
					return this._ruleSets;
				}
				set
				{
					this._ruleSets = (value ?? (this._ruleSets = new List<Player_Editor.RuleSetMapping>()));
				}
			}

			// Token: 0x06001B86 RID: 7046 RVA: 0x0001629F File Offset: 0x0001449F
			public ControllerMapEnablerSettings()
			{
				this._ruleSets = new List<Player_Editor.RuleSetMapping>();
				this._enabled = true;
			}

			// Token: 0x06001B87 RID: 7047 RVA: 0x00075D7C File Offset: 0x00073F7C
			public ControllerMapEnablerSettings(Player_Editor.ControllerMapEnablerSettings A_1)
			{
				if (A_1 == null)
				{
					throw new ArgumentNullException("source");
				}
				this._enabled = A_1._enabled;
				this._ruleSets = (MiscTools.DeepClone<Player_Editor.RuleSetMapping>(A_1._ruleSets) ?? new List<Player_Editor.RuleSetMapping>());
			}

			// Token: 0x06001B88 RID: 7048 RVA: 0x000162C0 File Offset: 0x000144C0
			internal ControllerMapEnabler.YqpaJJElEihfpIGutrHkMZgMkOuC UwSBwFEfWdPEWLuRzfwLiSlyNNkXA()
			{
				return new ControllerMapEnabler.YqpaJJElEihfpIGutrHkMZgMkOuC(this._enabled, this.fFgpRtNVHsvQudpkZvCDtGpDaQfM());
			}

			// Token: 0x06001B89 RID: 7049 RVA: 0x00075DCC File Offset: 0x00073FCC
			private JjxttxsSyopWvkcsgVXYLeVlEgvS[] fFgpRtNVHsvQudpkZvCDtGpDaQfM()
			{
				List<JjxttxsSyopWvkcsgVXYLeVlEgvS> list = new List<JjxttxsSyopWvkcsgVXYLeVlEgvS>();
				int num = (this._ruleSets != null) ? this._ruleSets.Count : 0;
				for (int i = 0; i < num; i++)
				{
					if (this._ruleSets[i] != null)
					{
						list.Add(this._ruleSets[i].lpSdWOgQJBetjyiZoVcPWcQjhVIAb());
					}
				}
				return list.ToArray();
			}

			// Token: 0x06001B8A RID: 7050 RVA: 0x000162D3 File Offset: 0x000144D3
			object IDeepCloneable.DeepClone()
			{
				return new Player_Editor.ControllerMapEnablerSettings(this);
			}

			// Token: 0x04000FB6 RID: 4022
			[SerializeField]
			[CustomObfuscation(rename = false)]
			private bool _enabled = true;

			// Token: 0x04000FB7 RID: 4023
			[SerializeField]
			[CustomObfuscation(rename = false)]
			private List<Player_Editor.RuleSetMapping> _ruleSets;
		}

		// Token: 0x0200025C RID: 604
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Serializable]
		public sealed class RuleSetMapping : IDeepCloneable
		{
			// Token: 0x17000686 RID: 1670
			// (get) Token: 0x06001B8B RID: 7051 RVA: 0x000162DB File Offset: 0x000144DB
			// (set) Token: 0x06001B8C RID: 7052 RVA: 0x000162E3 File Offset: 0x000144E3
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

			// Token: 0x17000687 RID: 1671
			// (get) Token: 0x06001B8D RID: 7053 RVA: 0x000162EC File Offset: 0x000144EC
			// (set) Token: 0x06001B8E RID: 7054 RVA: 0x000162F4 File Offset: 0x000144F4
			public bool enabled
			{
				get
				{
					return this._enabled;
				}
				internal set
				{
					this._enabled = value;
				}
			}

			// Token: 0x06001B8F RID: 7055 RVA: 0x000162FD File Offset: 0x000144FD
			public RuleSetMapping()
			{
				this.Clear();
			}

			// Token: 0x06001B90 RID: 7056 RVA: 0x0001630B File Offset: 0x0001450B
			public RuleSetMapping(Player_Editor.RuleSetMapping A_1) : this()
			{
				if (A_1 == null)
				{
					throw new ArgumentNullException("source");
				}
				this._enabled = A_1._enabled;
				this._id = A_1._id;
			}

			// Token: 0x06001B91 RID: 7057 RVA: 0x00016339 File Offset: 0x00014539
			public RuleSetMapping(bool A_1, int A_2)
			{
				this._enabled = A_1;
				this._id = A_2;
			}

			// Token: 0x06001B92 RID: 7058 RVA: 0x0001634F File Offset: 0x0001454F
			public void Clear()
			{
				this._id = 0;
				this._enabled = true;
			}

			// Token: 0x06001B93 RID: 7059 RVA: 0x0001635F File Offset: 0x0001455F
			public Player_Editor.RuleSetMapping Clone()
			{
				return new Player_Editor.RuleSetMapping(this._enabled, this._id);
			}

			// Token: 0x06001B94 RID: 7060 RVA: 0x00016372 File Offset: 0x00014572
			internal JjxttxsSyopWvkcsgVXYLeVlEgvS lpSdWOgQJBetjyiZoVcPWcQjhVIAb()
			{
				return new JjxttxsSyopWvkcsgVXYLeVlEgvS(this._id, this._enabled);
			}

			// Token: 0x06001B95 RID: 7061 RVA: 0x00016385 File Offset: 0x00014585
			object IDeepCloneable.DeepClone()
			{
				return new Player_Editor.RuleSetMapping(this);
			}

			// Token: 0x04000FB8 RID: 4024
			[SerializeField]
			[CustomObfuscation(rename = false)]
			private bool _enabled;

			// Token: 0x04000FB9 RID: 4025
			[SerializeField]
			[CustomObfuscation(rename = false)]
			private int _id;
		}

		// Token: 0x0200025D RID: 605
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Serializable]
		public sealed class CreateControllerInfo
		{
			// Token: 0x17000688 RID: 1672
			// (get) Token: 0x06001B96 RID: 7062 RVA: 0x0001638D File Offset: 0x0001458D
			// (set) Token: 0x06001B97 RID: 7063 RVA: 0x00016395 File Offset: 0x00014595
			public int sourceId
			{
				get
				{
					return this._sourceId;
				}
				internal set
				{
					this._sourceId = value;
				}
			}

			// Token: 0x17000689 RID: 1673
			// (get) Token: 0x06001B98 RID: 7064 RVA: 0x0001639E File Offset: 0x0001459E
			// (set) Token: 0x06001B99 RID: 7065 RVA: 0x000163A6 File Offset: 0x000145A6
			public string tag
			{
				get
				{
					return this._tag;
				}
				internal set
				{
					this._tag = value;
				}
			}

			// Token: 0x06001B9A RID: 7066 RVA: 0x000033F4 File Offset: 0x000015F4
			public CreateControllerInfo()
			{
			}

			// Token: 0x06001B9B RID: 7067 RVA: 0x000163AF File Offset: 0x000145AF
			public CreateControllerInfo(int A_1, string A_2)
			{
				this._sourceId = A_1;
				this._tag = A_2;
			}

			// Token: 0x06001B9C RID: 7068 RVA: 0x000163C5 File Offset: 0x000145C5
			public CreateControllerInfo(Player_Editor.CreateControllerInfo A_1)
			{
				this._sourceId = A_1._sourceId;
				this._tag = A_1._tag;
			}

			// Token: 0x04000FBA RID: 4026
			[SerializeField]
			[CustomObfuscation(rename = false)]
			private int _sourceId;

			// Token: 0x04000FBB RID: 4027
			[SerializeField]
			[CustomObfuscation(rename = false)]
			private string _tag;
		}
	}
}
