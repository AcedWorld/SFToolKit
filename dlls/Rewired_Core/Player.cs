using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Internal.Localization;
using Rewired.Utils;
using Rewired.Utils.Classes;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	// Token: 0x0200016A RID: 362
	public sealed class Player : lcAibZuWMerLyEDicYNSneVLTvsj
	{
		// Token: 0x06000F4E RID: 3918 RVA: 0x00055854 File Offset: 0x00053A54
		internal Player(bool A_1, int A_2, string A_3, string A_4, string A_5, OdwwNwDVsLLbukoEpkWRZpETNEYi A_6, ControllerMapLayoutManager.YuRWKBhEFGtHaIyXShqNamLdASyj A_7, ControllerMapEnabler.YqpaJJElEihfpIGutrHkMZgMkOuC A_8)
		{
			this.jqcyaWGplYbNtDHTCkvWGQXUOIJuA = A_1;
			this.slhAWVVynuDdrqbdGKDoRVmsCDYo = A_2;
			this.SdnlqSbbNvbzagDywDBTSdmWCkUc = A_3;
			this.xOGDdbhKTFOXIXjKDDaNUkmQsAOh = A_4;
			this.VyPgITeojqRJZAJiuFDbNYIUGAVO = A_5;
			this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO = ReInput.id;
			this.QiYHHuUhquTeLkjtuBVnGlFhUZoKA = wAaCrzUbQDdcHiRBVWRRKbzVqQGMA.IiaGHlgKOVmnRRwgItCgkNsRcnrF(this);
			this.controllers = new Player.ControllerHelper(this, A_6, A_7, A_8);
			this.LuhdSyQNGuuUqPpzFxduIHmdweOD = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb;
			this.CqkrkgcMXcGAaHZjaTDddtZyRmuoA();
		}

		// Token: 0x1700045B RID: 1115
		// (get) Token: 0x06000F4F RID: 3919 RVA: 0x0000DDC0 File Offset: 0x0000BFC0
		// (set) Token: 0x06000F50 RID: 3920 RVA: 0x0000DDE3 File Offset: 0x0000BFE3
		public int id
		{
			get
			{
				if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
				{
					ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
					return -1;
				}
				return this.slhAWVVynuDdrqbdGKDoRVmsCDYo;
			}
			internal set
			{
				this.slhAWVVynuDdrqbdGKDoRVmsCDYo = value;
			}
		}

		// Token: 0x1700045C RID: 1116
		// (get) Token: 0x06000F51 RID: 3921 RVA: 0x0000DDEC File Offset: 0x0000BFEC
		// (set) Token: 0x06000F52 RID: 3922 RVA: 0x0000DE13 File Offset: 0x0000C013
		public string name
		{
			get
			{
				if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
				{
					ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
					return string.Empty;
				}
				return this.SdnlqSbbNvbzagDywDBTSdmWCkUc;
			}
			internal set
			{
				this.SdnlqSbbNvbzagDywDBTSdmWCkUc = value;
			}
		}

		// Token: 0x1700045D RID: 1117
		// (get) Token: 0x06000F53 RID: 3923 RVA: 0x0000DE1C File Offset: 0x0000C01C
		// (set) Token: 0x06000F54 RID: 3924 RVA: 0x0000DE56 File Offset: 0x0000C056
		public string descriptiveName
		{
			get
			{
				if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
				{
					ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
					return string.Empty;
				}
				if (!LocalizationManager.isEnabled)
				{
					return this.xOGDdbhKTFOXIXjKDDaNUkmQsAOh;
				}
				return this.QiYHHuUhquTeLkjtuBVnGlFhUZoKA.QGZglKMnBTLJKJKOPknbgTZKPbAO;
			}
			internal set
			{
				this.nonLocalizedDescriptiveName = value;
			}
		}

		// Token: 0x1700045E RID: 1118
		// (get) Token: 0x06000F55 RID: 3925 RVA: 0x0000DE5F File Offset: 0x0000C05F
		// (set) Token: 0x06000F56 RID: 3926 RVA: 0x0000DE82 File Offset: 0x0000C082
		public bool isPlaying
		{
			get
			{
				if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
				{
					ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
					return false;
				}
				return this.LLxVKQorRjxduPjPCQMcpDvmXmDA;
			}
			set
			{
				this.LLxVKQorRjxduPjPCQMcpDvmXmDA = value;
			}
		}

		// Token: 0x1700045F RID: 1119
		// (get) Token: 0x06000F57 RID: 3927 RVA: 0x0000DE8B File Offset: 0x0000C08B
		// (set) Token: 0x06000F58 RID: 3928 RVA: 0x0000DE93 File Offset: 0x0000C093
		internal string nonLocalizedDescriptiveName
		{
			get
			{
				return this.xOGDdbhKTFOXIXjKDDaNUkmQsAOh;
			}
			set
			{
				this.xOGDdbhKTFOXIXjKDDaNUkmQsAOh = value;
				this.QiYHHuUhquTeLkjtuBVnGlFhUZoKA.OlcAFIbuEHvUomQdyRvLXKoljCWJ();
			}
		}

		// Token: 0x17000460 RID: 1120
		// (get) Token: 0x06000F59 RID: 3929 RVA: 0x0000DEA7 File Offset: 0x0000C0A7
		string lcAibZuWMerLyEDicYNSneVLTvsj.keyCategory
		{
			get
			{
				return "player";
			}
		}

		// Token: 0x17000461 RID: 1121
		// (get) Token: 0x06000F5A RID: 3930 RVA: 0x0000DEAE File Offset: 0x0000C0AE
		string lcAibZuWMerLyEDicYNSneVLTvsj.scriptingName
		{
			get
			{
				return this.SdnlqSbbNvbzagDywDBTSdmWCkUc;
			}
		}

		// Token: 0x17000462 RID: 1122
		// (get) Token: 0x06000F5B RID: 3931 RVA: 0x0000DE8B File Offset: 0x0000C08B
		// (set) Token: 0x06000F5C RID: 3932 RVA: 0x0000DEB6 File Offset: 0x0000C0B6
		string lcAibZuWMerLyEDicYNSneVLTvsj.nonLocalizedDescriptiveName
		{
			get
			{
				return this.xOGDdbhKTFOXIXjKDDaNUkmQsAOh;
			}
			set
			{
				this.xOGDdbhKTFOXIXjKDDaNUkmQsAOh = value;
			}
		}

		// Token: 0x17000463 RID: 1123
		// (get) Token: 0x06000F5D RID: 3933 RVA: 0x0000DEBF File Offset: 0x0000C0BF
		string lcAibZuWMerLyEDicYNSneVLTvsj.key
		{
			get
			{
				return this.VyPgITeojqRJZAJiuFDbNYIUGAVO;
			}
		}

		// Token: 0x17000464 RID: 1124
		// (get) Token: 0x06000F5E RID: 3934 RVA: 0x0000DEC7 File Offset: 0x0000C0C7
		// (set) Token: 0x06000F5F RID: 3935 RVA: 0x0000DECF File Offset: 0x0000C0CF
		int lcAibZuWMerLyEDicYNSneVLTvsj.autoGeneratedValueFlags
		{
			get
			{
				return this.LXmabZESfMqxbUmNTtDZjostIMydA;
			}
			set
			{
				this.LXmabZESfMqxbUmNTtDZjostIMydA = value;
			}
		}

		// Token: 0x06000F60 RID: 3936 RVA: 0x000558C8 File Offset: 0x00053AC8
		public PlayerSaveData GetSaveData(bool userAssignableMapsOnly)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return default(PlayerSaveData);
			}
			return new PlayerSaveData(this.controllers.maps.GetAllMapSaveData<JoystickMapSaveData>(userAssignableMapsOnly), this.controllers.maps.GetAllMapSaveData<KeyboardMapSaveData>(userAssignableMapsOnly), this.controllers.maps.GetAllMapSaveData<MouseMapSaveData>(userAssignableMapsOnly), this.controllers.maps.GetAllMapSaveData<CustomControllerMapSaveData>(userAssignableMapsOnly), ReInput.mapping.GetInputBehaviors(this.slhAWVVynuDdrqbdGKDoRVmsCDYo));
		}

		// Token: 0x06000F61 RID: 3937 RVA: 0x00055954 File Offset: 0x00053B54
		public bool GetButton(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.PLEzowLfRVYnmqUhFdELfVgtLRUU();
		}

		// Token: 0x06000F62 RID: 3938 RVA: 0x0005599C File Offset: 0x00053B9C
		public bool GetButton(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.PLEzowLfRVYnmqUhFdELfVgtLRUU();
		}

		// Token: 0x06000F63 RID: 3939 RVA: 0x000559E4 File Offset: 0x00053BE4
		public bool GetButtonDown(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.cgnNvIBXdjcArepYxqVhcluOaiAF();
		}

		// Token: 0x06000F64 RID: 3940 RVA: 0x00055A2C File Offset: 0x00053C2C
		public bool GetButtonDown(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.cgnNvIBXdjcArepYxqVhcluOaiAF();
		}

		// Token: 0x06000F65 RID: 3941 RVA: 0x00055A74 File Offset: 0x00053C74
		public bool GetButtonUp(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.iqpRhWPPruMPiSurJSIiJhNgoOiO();
		}

		// Token: 0x06000F66 RID: 3942 RVA: 0x00055ABC File Offset: 0x00053CBC
		public bool GetButtonUp(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.iqpRhWPPruMPiSurJSIiJhNgoOiO();
		}

		// Token: 0x06000F67 RID: 3943 RVA: 0x00055B04 File Offset: 0x00053D04
		public bool GetButtonPrev(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.oFwEbOzifvsGVUHSHODNgMNlGvzcA();
		}

		// Token: 0x06000F68 RID: 3944 RVA: 0x00055B4C File Offset: 0x00053D4C
		public bool GetButtonPrev(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.oFwEbOzifvsGVUHSHODNgMNlGvzcA();
		}

		// Token: 0x06000F69 RID: 3945 RVA: 0x00055B94 File Offset: 0x00053D94
		public bool GetButtonSinglePressHold(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.TtiHmMweSqotoAUWwlbDjsYVgpkcA();
		}

		// Token: 0x06000F6A RID: 3946 RVA: 0x00055BDC File Offset: 0x00053DDC
		public bool GetButtonSinglePressHold(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.TtiHmMweSqotoAUWwlbDjsYVgpkcA();
		}

		// Token: 0x06000F6B RID: 3947 RVA: 0x00055C24 File Offset: 0x00053E24
		public bool GetButtonSinglePressDown(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.LWbCfZDYbtngeYfwehddWnTHkZmL();
		}

		// Token: 0x06000F6C RID: 3948 RVA: 0x00055C6C File Offset: 0x00053E6C
		public bool GetButtonSinglePressDown(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.LWbCfZDYbtngeYfwehddWnTHkZmL();
		}

		// Token: 0x06000F6D RID: 3949 RVA: 0x00055CB4 File Offset: 0x00053EB4
		public bool GetButtonSinglePressUp(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.HfbBeghVKYofUBdMipStTLDWnePt();
		}

		// Token: 0x06000F6E RID: 3950 RVA: 0x00055CFC File Offset: 0x00053EFC
		public bool GetButtonSinglePressUp(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.HfbBeghVKYofUBdMipStTLDWnePt();
		}

		// Token: 0x06000F6F RID: 3951 RVA: 0x00055D44 File Offset: 0x00053F44
		public bool GetButtonDoublePressHold(string actionName, float speed)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.oZfcBbUtGNPizYqlKFKnHBYvkUFRA(speed);
		}

		// Token: 0x06000F70 RID: 3952 RVA: 0x00055D8C File Offset: 0x00053F8C
		public bool GetButtonDoublePressHold(int actionId, float speed)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.oZfcBbUtGNPizYqlKFKnHBYvkUFRA(speed);
		}

		// Token: 0x06000F71 RID: 3953 RVA: 0x0000DED8 File Offset: 0x0000C0D8
		public bool GetButtonDoublePressHold(string actionName)
		{
			return this.GetButtonDoublePressHold(actionName, 0f);
		}

		// Token: 0x06000F72 RID: 3954 RVA: 0x0000DEE6 File Offset: 0x0000C0E6
		public bool GetButtonDoublePressHold(int actionId)
		{
			return this.GetButtonDoublePressHold(actionId, 0f);
		}

		// Token: 0x06000F73 RID: 3955 RVA: 0x00055DD4 File Offset: 0x00053FD4
		public bool GetButtonDoublePressDown(string actionName, float speed)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.tVtvoroswQXEnbdAENmIGAElmIBc(speed);
		}

		// Token: 0x06000F74 RID: 3956 RVA: 0x00055E1C File Offset: 0x0005401C
		public bool GetButtonDoublePressDown(int actionId, float speed)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.tVtvoroswQXEnbdAENmIGAElmIBc(speed);
		}

		// Token: 0x06000F75 RID: 3957 RVA: 0x0000DEF4 File Offset: 0x0000C0F4
		public bool GetButtonDoublePressDown(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			return this.GetButtonDoublePressDown(actionName, 0f);
		}

		// Token: 0x06000F76 RID: 3958 RVA: 0x0000DF1D File Offset: 0x0000C11D
		public bool GetButtonDoublePressDown(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			return this.GetButtonDoublePressDown(actionId, 0f);
		}

		// Token: 0x06000F77 RID: 3959 RVA: 0x00055E64 File Offset: 0x00054064
		public bool GetButtonDoublePressUp(string actionName, float speed)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.JZbmLwFjMyOqchpEzbxnChuSPPgo(speed);
		}

		// Token: 0x06000F78 RID: 3960 RVA: 0x00055EAC File Offset: 0x000540AC
		public bool GetButtonDoublePressUp(int actionId, float speed)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.JZbmLwFjMyOqchpEzbxnChuSPPgo(speed);
		}

		// Token: 0x06000F79 RID: 3961 RVA: 0x0000DF46 File Offset: 0x0000C146
		public bool GetButtonDoublePressUp(string actionName)
		{
			return this.GetButtonDoublePressUp(actionName, 0f);
		}

		// Token: 0x06000F7A RID: 3962 RVA: 0x0000DF54 File Offset: 0x0000C154
		public bool GetButtonDoublePressUp(int actionId)
		{
			return this.GetButtonDoublePressUp(actionId, 0f);
		}

		// Token: 0x06000F7B RID: 3963 RVA: 0x00055EF4 File Offset: 0x000540F4
		public bool GetButtonTimedPress(string actionName, float time)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.zpvDECrzpTCpSrBbeXUUgieFKOlg(time, 0f);
		}

		// Token: 0x06000F7C RID: 3964 RVA: 0x00055F44 File Offset: 0x00054144
		public bool GetButtonTimedPress(int actionId, float time)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.zpvDECrzpTCpSrBbeXUUgieFKOlg(time, 0f);
		}

		// Token: 0x06000F7D RID: 3965 RVA: 0x00055F94 File Offset: 0x00054194
		public bool GetButtonTimedPress(string actionName, float time, float expireIn)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.zpvDECrzpTCpSrBbeXUUgieFKOlg(time, expireIn);
		}

		// Token: 0x06000F7E RID: 3966 RVA: 0x00055FE0 File Offset: 0x000541E0
		public bool GetButtonTimedPress(int actionId, float time, float expireIn)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.zpvDECrzpTCpSrBbeXUUgieFKOlg(time, expireIn);
		}

		// Token: 0x06000F7F RID: 3967 RVA: 0x0005602C File Offset: 0x0005422C
		public bool GetButtonTimedPressDown(string actionName, float time)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.aGvkASuRZjHXWXpVpTxDBOXESHpc(time);
		}

		// Token: 0x06000F80 RID: 3968 RVA: 0x00056074 File Offset: 0x00054274
		public bool GetButtonTimedPressDown(int actionId, float time)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.aGvkASuRZjHXWXpVpTxDBOXESHpc(time);
		}

		// Token: 0x06000F81 RID: 3969 RVA: 0x000560BC File Offset: 0x000542BC
		public bool GetButtonTimedPressUp(string actionName, float time)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.DHssSjYakDuhVUAVpnowwTPiMpSE(time, 0f);
		}

		// Token: 0x06000F82 RID: 3970 RVA: 0x0005610C File Offset: 0x0005430C
		public bool GetButtonTimedPressUp(int actionId, float time)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.DHssSjYakDuhVUAVpnowwTPiMpSE(time, 0f);
		}

		// Token: 0x06000F83 RID: 3971 RVA: 0x0005615C File Offset: 0x0005435C
		public bool GetButtonTimedPressUp(string actionName, float time, float expireIn)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.DHssSjYakDuhVUAVpnowwTPiMpSE(time, expireIn);
		}

		// Token: 0x06000F84 RID: 3972 RVA: 0x000561A8 File Offset: 0x000543A8
		public bool GetButtonTimedPressUp(int actionId, float time, float expireIn)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.DHssSjYakDuhVUAVpnowwTPiMpSE(time, expireIn);
		}

		// Token: 0x06000F85 RID: 3973 RVA: 0x000561F4 File Offset: 0x000543F4
		public bool GetButtonShortPress(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.DCYPHQBUQWTQyFmGGGYmeiAycAZR();
		}

		// Token: 0x06000F86 RID: 3974 RVA: 0x0005623C File Offset: 0x0005443C
		public bool GetButtonShortPress(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.DCYPHQBUQWTQyFmGGGYmeiAycAZR();
		}

		// Token: 0x06000F87 RID: 3975 RVA: 0x00056284 File Offset: 0x00054484
		public bool GetButtonShortPressDown(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.HPuKJdCWHuCwPrBFJVtqnvtpQLnn();
		}

		// Token: 0x06000F88 RID: 3976 RVA: 0x000562CC File Offset: 0x000544CC
		public bool GetButtonShortPressDown(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.HPuKJdCWHuCwPrBFJVtqnvtpQLnn();
		}

		// Token: 0x06000F89 RID: 3977 RVA: 0x00056314 File Offset: 0x00054514
		public bool GetButtonShortPressUp(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.zyIWmXRVRLmtfjUGqPWKrVhOpplL();
		}

		// Token: 0x06000F8A RID: 3978 RVA: 0x0005635C File Offset: 0x0005455C
		public bool GetButtonShortPressUp(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.zyIWmXRVRLmtfjUGqPWKrVhOpplL();
		}

		// Token: 0x06000F8B RID: 3979 RVA: 0x000563A4 File Offset: 0x000545A4
		public bool GetButtonLongPress(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.QXrrgbvJsTRiAGESJowgdvzQClRh();
		}

		// Token: 0x06000F8C RID: 3980 RVA: 0x000563EC File Offset: 0x000545EC
		public bool GetButtonLongPress(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.QXrrgbvJsTRiAGESJowgdvzQClRh();
		}

		// Token: 0x06000F8D RID: 3981 RVA: 0x00056434 File Offset: 0x00054634
		public bool GetButtonLongPressDown(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.qTObevNNKnAiasvGCHaKAchXpabA();
		}

		// Token: 0x06000F8E RID: 3982 RVA: 0x0005647C File Offset: 0x0005467C
		public bool GetButtonLongPressDown(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.qTObevNNKnAiasvGCHaKAchXpabA();
		}

		// Token: 0x06000F8F RID: 3983 RVA: 0x000564C4 File Offset: 0x000546C4
		public bool GetButtonLongPressUp(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.byeGARHXOEmjPxcQoTOUGzYnfkKu();
		}

		// Token: 0x06000F90 RID: 3984 RVA: 0x0005650C File Offset: 0x0005470C
		public bool GetButtonLongPressUp(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.byeGARHXOEmjPxcQoTOUGzYnfkKu();
		}

		// Token: 0x06000F91 RID: 3985 RVA: 0x00056554 File Offset: 0x00054754
		public bool GetButtonRepeating(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.bydTKFtJThpJiBleSRZzwDlRDOBL();
		}

		// Token: 0x06000F92 RID: 3986 RVA: 0x0005659C File Offset: 0x0005479C
		public bool GetButtonRepeating(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.bydTKFtJThpJiBleSRZzwDlRDOBL();
		}

		// Token: 0x06000F93 RID: 3987 RVA: 0x0000DF62 File Offset: 0x0000C162
		public bool GetAnyButton()
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			return this.LuhdSyQNGuuUqPpzFxduIHmdweOD.xggYPWOMwlNTEiiisWdhOrrivnfC(this.slhAWVVynuDdrqbdGKDoRVmsCDYo);
		}

		// Token: 0x06000F94 RID: 3988 RVA: 0x0000DF90 File Offset: 0x0000C190
		public bool GetAnyButtonDown()
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			return this.LuhdSyQNGuuUqPpzFxduIHmdweOD.dOltNIBvxPYKMWlPDYIPInIopgMA(this.slhAWVVynuDdrqbdGKDoRVmsCDYo);
		}

		// Token: 0x06000F95 RID: 3989 RVA: 0x0000DFBE File Offset: 0x0000C1BE
		public bool GetAnyButtonUp()
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			return this.LuhdSyQNGuuUqPpzFxduIHmdweOD.iHobkAoxVdbulWoOzszNZfmhHRQX(this.slhAWVVynuDdrqbdGKDoRVmsCDYo);
		}

		// Token: 0x06000F96 RID: 3990 RVA: 0x0000DFEC File Offset: 0x0000C1EC
		public bool GetAnyButtonPrev()
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			return this.LuhdSyQNGuuUqPpzFxduIHmdweOD.svsbnusNGPDJEwchqwzDgakkASfM(this.slhAWVVynuDdrqbdGKDoRVmsCDYo);
		}

		// Token: 0x06000F97 RID: 3991 RVA: 0x000565E4 File Offset: 0x000547E4
		public double GetButtonTimePressed(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return 0.0;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return 0.0;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.gNempBrAyTbRDWwSleIwOdtmpVtw();
		}

		// Token: 0x06000F98 RID: 3992 RVA: 0x0005663C File Offset: 0x0005483C
		public double GetButtonTimePressed(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return 0.0;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return 0.0;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.gNempBrAyTbRDWwSleIwOdtmpVtw();
		}

		// Token: 0x06000F99 RID: 3993 RVA: 0x00056694 File Offset: 0x00054894
		public double GetButtonTimeUnpressed(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return 0.0;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return 0.0;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.VYQDnrrCLsVEwPSOvFIDtcDnhPkB();
		}

		// Token: 0x06000F9A RID: 3994 RVA: 0x000566EC File Offset: 0x000548EC
		public double GetButtonTimeUnpressed(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return 0.0;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return 0.0;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.VYQDnrrCLsVEwPSOvFIDtcDnhPkB();
		}

		// Token: 0x06000F9B RID: 3995 RVA: 0x00056744 File Offset: 0x00054944
		public bool GetNegativeButton(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.HWGpqzxmCQzoZIFrUhOuHScOhfbr();
		}

		// Token: 0x06000F9C RID: 3996 RVA: 0x0005678C File Offset: 0x0005498C
		public bool GetNegativeButton(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.HWGpqzxmCQzoZIFrUhOuHScOhfbr();
		}

		// Token: 0x06000F9D RID: 3997 RVA: 0x000567D4 File Offset: 0x000549D4
		public bool GetNegativeButtonDown(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.DEqKIDythebfGxHycCDdFiTYHWfF();
		}

		// Token: 0x06000F9E RID: 3998 RVA: 0x0005681C File Offset: 0x00054A1C
		public bool GetNegativeButtonDown(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.DEqKIDythebfGxHycCDdFiTYHWfF();
		}

		// Token: 0x06000F9F RID: 3999 RVA: 0x00056864 File Offset: 0x00054A64
		public bool GetNegativeButtonUp(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.YJetLbybKqkFHlIxOBMORKTNchaY();
		}

		// Token: 0x06000FA0 RID: 4000 RVA: 0x000568AC File Offset: 0x00054AAC
		public bool GetNegativeButtonUp(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.YJetLbybKqkFHlIxOBMORKTNchaY();
		}

		// Token: 0x06000FA1 RID: 4001 RVA: 0x000568F4 File Offset: 0x00054AF4
		public bool GetNegativeButtonPrev(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.pJdNBJgzCniVonEUxixmJoDFVzqI();
		}

		// Token: 0x06000FA2 RID: 4002 RVA: 0x0005693C File Offset: 0x00054B3C
		public bool GetNegativeButtonPrev(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.pJdNBJgzCniVonEUxixmJoDFVzqI();
		}

		// Token: 0x06000FA3 RID: 4003 RVA: 0x00056984 File Offset: 0x00054B84
		public bool GetNegativeButtonSinglePressHold(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.gKhqNfBJWPQCWmZgQkjzVxTeghGO();
		}

		// Token: 0x06000FA4 RID: 4004 RVA: 0x000569CC File Offset: 0x00054BCC
		public bool GetNegativeButtonSinglePressHold(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.gKhqNfBJWPQCWmZgQkjzVxTeghGO();
		}

		// Token: 0x06000FA5 RID: 4005 RVA: 0x00056A14 File Offset: 0x00054C14
		public bool GetNegativeButtonSinglePressDown(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.UobencRdPOsVfpqTAcwrMWBOlucv();
		}

		// Token: 0x06000FA6 RID: 4006 RVA: 0x00056A5C File Offset: 0x00054C5C
		public bool GetNegativeButtonSinglePressDown(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.UobencRdPOsVfpqTAcwrMWBOlucv();
		}

		// Token: 0x06000FA7 RID: 4007 RVA: 0x00056AA4 File Offset: 0x00054CA4
		public bool GetNegativeButtonSinglePressUp(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.AaTsVPLVcybQrrgogrjJLSkxuclV();
		}

		// Token: 0x06000FA8 RID: 4008 RVA: 0x00056AEC File Offset: 0x00054CEC
		public bool GetNegativeButtonSinglePressUp(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.AaTsVPLVcybQrrgogrjJLSkxuclV();
		}

		// Token: 0x06000FA9 RID: 4009 RVA: 0x00056B34 File Offset: 0x00054D34
		public bool GetNegativeButtonDoublePressHold(string actionName, float speed)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.RTWkHLUpAmesTmkgELyVDjMemKUn(speed);
		}

		// Token: 0x06000FAA RID: 4010 RVA: 0x00056B7C File Offset: 0x00054D7C
		public bool GetNegativeButtonDoublePressHold(int actionId, float speed)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.RTWkHLUpAmesTmkgELyVDjMemKUn(speed);
		}

		// Token: 0x06000FAB RID: 4011 RVA: 0x0000E01A File Offset: 0x0000C21A
		public bool GetNegativeButtonDoublePressHold(string actionName)
		{
			return this.GetNegativeButtonDoublePressHold(actionName, 0f);
		}

		// Token: 0x06000FAC RID: 4012 RVA: 0x0000E028 File Offset: 0x0000C228
		public bool GetNegativeButtonDoublePressHold(int actionId)
		{
			return this.GetNegativeButtonDoublePressHold(actionId, 0f);
		}

		// Token: 0x06000FAD RID: 4013 RVA: 0x00056BC4 File Offset: 0x00054DC4
		public bool GetNegativeButtonDoublePressDown(string actionName, float speed)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.HiYmLLYxrhaYHiqeBOjtIGIuNpEQ(speed);
		}

		// Token: 0x06000FAE RID: 4014 RVA: 0x00056C0C File Offset: 0x00054E0C
		public bool GetNegativeButtonDoublePressDown(int actionId, float speed)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.HiYmLLYxrhaYHiqeBOjtIGIuNpEQ(speed);
		}

		// Token: 0x06000FAF RID: 4015 RVA: 0x0000E036 File Offset: 0x0000C236
		public bool GetNegativeButtonDoublePressDown(string actionName)
		{
			return this.GetNegativeButtonDoublePressDown(actionName, 0f);
		}

		// Token: 0x06000FB0 RID: 4016 RVA: 0x0000E044 File Offset: 0x0000C244
		public bool GetNegativeButtonDoublePressDown(int actionId)
		{
			return this.GetNegativeButtonDoublePressDown(actionId, 0f);
		}

		// Token: 0x06000FB1 RID: 4017 RVA: 0x00056C54 File Offset: 0x00054E54
		public bool GetNegativeButtonDoublePressUp(string actionName, float speed)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.hZDmLiEfhVfHuJFrpmbvWeZDliNEb(speed);
		}

		// Token: 0x06000FB2 RID: 4018 RVA: 0x00056C9C File Offset: 0x00054E9C
		public bool GetNegativeButtonDoublePressUp(int actionId, float speed)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.hZDmLiEfhVfHuJFrpmbvWeZDliNEb(speed);
		}

		// Token: 0x06000FB3 RID: 4019 RVA: 0x0000E052 File Offset: 0x0000C252
		public bool GetNegativeButtonDoublePressUp(string actionName)
		{
			return this.GetNegativeButtonDoublePressUp(actionName, 0f);
		}

		// Token: 0x06000FB4 RID: 4020 RVA: 0x0000E060 File Offset: 0x0000C260
		public bool GetNegativeButtonDoublePressUp(int actionId)
		{
			return this.GetNegativeButtonDoublePressUp(actionId, 0f);
		}

		// Token: 0x06000FB5 RID: 4021 RVA: 0x00056CE4 File Offset: 0x00054EE4
		public bool GetNegativeButtonTimedPress(string actionName, float time)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.HJcCPAAxaZKAkATvymNFuNUGeixn(time, 0f);
		}

		// Token: 0x06000FB6 RID: 4022 RVA: 0x00056D34 File Offset: 0x00054F34
		public bool GetNegativeButtonTimedPress(int actionId, float time)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.HJcCPAAxaZKAkATvymNFuNUGeixn(time, 0f);
		}

		// Token: 0x06000FB7 RID: 4023 RVA: 0x00056D84 File Offset: 0x00054F84
		public bool GetNegativeButtonTimedPress(string actionName, float time, float expireIn)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.HJcCPAAxaZKAkATvymNFuNUGeixn(time, expireIn);
		}

		// Token: 0x06000FB8 RID: 4024 RVA: 0x00056DD0 File Offset: 0x00054FD0
		public bool GetNegativeButtonTimedPress(int actionId, float time, float expireIn)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.HJcCPAAxaZKAkATvymNFuNUGeixn(time, expireIn);
		}

		// Token: 0x06000FB9 RID: 4025 RVA: 0x00056E1C File Offset: 0x0005501C
		public bool GetNegativeButtonTimedPressDown(string actionName, float time)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.kxPJKadwjgTEVvjOoxRmKCjcGMshA(time);
		}

		// Token: 0x06000FBA RID: 4026 RVA: 0x00056E64 File Offset: 0x00055064
		public bool GetNegativeButtonTimedPressDown(int actionId, float time)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.kxPJKadwjgTEVvjOoxRmKCjcGMshA(time);
		}

		// Token: 0x06000FBB RID: 4027 RVA: 0x00056EAC File Offset: 0x000550AC
		public bool GetNegativeButtonTimedPressUp(string actionName, float time)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.VNMQdEPgUWpZCUdysrrlMBNQfMpq(time, 0f);
		}

		// Token: 0x06000FBC RID: 4028 RVA: 0x00056EFC File Offset: 0x000550FC
		public bool GetNegativeButtonTimedPressUp(int actionId, float time)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.VNMQdEPgUWpZCUdysrrlMBNQfMpq(time, 0f);
		}

		// Token: 0x06000FBD RID: 4029 RVA: 0x00056F4C File Offset: 0x0005514C
		public bool GetNegativeButtonTimedPressUp(string actionName, float time, float expireIn)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.VNMQdEPgUWpZCUdysrrlMBNQfMpq(time, expireIn);
		}

		// Token: 0x06000FBE RID: 4030 RVA: 0x00056F98 File Offset: 0x00055198
		public bool GetNegativeButtonTimedPressUp(int actionId, float time, float expireIn)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.VNMQdEPgUWpZCUdysrrlMBNQfMpq(time, expireIn);
		}

		// Token: 0x06000FBF RID: 4031 RVA: 0x00056FE4 File Offset: 0x000551E4
		public bool GetNegativeButtonShortPress(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yekfXbpfvbVIhCPSOETpyFIXXvZI();
		}

		// Token: 0x06000FC0 RID: 4032 RVA: 0x0005702C File Offset: 0x0005522C
		public bool GetNegativeButtonShortPress(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yekfXbpfvbVIhCPSOETpyFIXXvZI();
		}

		// Token: 0x06000FC1 RID: 4033 RVA: 0x00057074 File Offset: 0x00055274
		public bool GetNegativeButtonShortPressDown(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.mlPISDGCNvaJJTDdHhtCJbYKKcQL();
		}

		// Token: 0x06000FC2 RID: 4034 RVA: 0x000570BC File Offset: 0x000552BC
		public bool GetNegativeButtonShortPressDown(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.mlPISDGCNvaJJTDdHhtCJbYKKcQL();
		}

		// Token: 0x06000FC3 RID: 4035 RVA: 0x00057104 File Offset: 0x00055304
		public bool GetNegativeButtonShortPressUp(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.JGiKRKJdtaebnxDHKwGTQnLkWoQE();
		}

		// Token: 0x06000FC4 RID: 4036 RVA: 0x0005714C File Offset: 0x0005534C
		public bool GetNegativeButtonShortPressUp(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.JGiKRKJdtaebnxDHKwGTQnLkWoQE();
		}

		// Token: 0x06000FC5 RID: 4037 RVA: 0x00057194 File Offset: 0x00055394
		public bool GetNegativeButtonLongPress(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.MOMLKtzwDEKbkXbSyroGZcZPmBrg();
		}

		// Token: 0x06000FC6 RID: 4038 RVA: 0x000571DC File Offset: 0x000553DC
		public bool GetNegativeButtonLongPress(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.MOMLKtzwDEKbkXbSyroGZcZPmBrg();
		}

		// Token: 0x06000FC7 RID: 4039 RVA: 0x00057224 File Offset: 0x00055424
		public bool GetNegativeButtonLongPressDown(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.gNKMpTVSjVbOBkSwBfMifjCrZDNH();
		}

		// Token: 0x06000FC8 RID: 4040 RVA: 0x0005726C File Offset: 0x0005546C
		public bool GetNegativeButtonLongPressDown(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.gNKMpTVSjVbOBkSwBfMifjCrZDNH();
		}

		// Token: 0x06000FC9 RID: 4041 RVA: 0x000572B4 File Offset: 0x000554B4
		public bool GetNegativeButtonLongPressUp(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.VhxSlbANjTXbiijCgfOaJwIAMgygA();
		}

		// Token: 0x06000FCA RID: 4042 RVA: 0x000572FC File Offset: 0x000554FC
		public bool GetNegativeButtonLongPressUp(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.VhxSlbANjTXbiijCgfOaJwIAMgygA();
		}

		// Token: 0x06000FCB RID: 4043 RVA: 0x00057344 File Offset: 0x00055544
		public bool GetNegativeButtonRepeating(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.aXIfnVraJSaGrMGfbgfHhEprqwOnA();
		}

		// Token: 0x06000FCC RID: 4044 RVA: 0x0005738C File Offset: 0x0005558C
		public bool GetNegativeButtonRepeating(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.aXIfnVraJSaGrMGfbgfHhEprqwOnA();
		}

		// Token: 0x06000FCD RID: 4045 RVA: 0x0000E06E File Offset: 0x0000C26E
		public bool GetAnyNegativeButton()
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			return this.LuhdSyQNGuuUqPpzFxduIHmdweOD.kuhkDAnKdcHRkjBNxLuLGcDAdtkS(this.slhAWVVynuDdrqbdGKDoRVmsCDYo);
		}

		// Token: 0x06000FCE RID: 4046 RVA: 0x0000E09C File Offset: 0x0000C29C
		public bool GetAnyNegativeButtonDown()
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			return this.LuhdSyQNGuuUqPpzFxduIHmdweOD.zEMPHBGiNgGXnWNQGHsQCOUnhJeC(this.slhAWVVynuDdrqbdGKDoRVmsCDYo);
		}

		// Token: 0x06000FCF RID: 4047 RVA: 0x0000E0CA File Offset: 0x0000C2CA
		public bool GetAnyNegativeButtonUp()
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			return this.LuhdSyQNGuuUqPpzFxduIHmdweOD.pNkCqTBJooMzzELsONmDFoOyeHRrA(this.slhAWVVynuDdrqbdGKDoRVmsCDYo);
		}

		// Token: 0x06000FD0 RID: 4048 RVA: 0x0000E0F8 File Offset: 0x0000C2F8
		public bool GetAnyNegativeButtonPrev()
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			return this.LuhdSyQNGuuUqPpzFxduIHmdweOD.EkxkKklKQKOJdyFjLBtpdDvvxFIC(this.slhAWVVynuDdrqbdGKDoRVmsCDYo);
		}

		// Token: 0x06000FD1 RID: 4049 RVA: 0x000573D4 File Offset: 0x000555D4
		public double GetNegativeButtonTimePressed(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return 0.0;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return 0.0;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.mqvWHEuwnomGVOyodRZPEbJsWeit();
		}

		// Token: 0x06000FD2 RID: 4050 RVA: 0x0005742C File Offset: 0x0005562C
		public double GetNegativeButtonTimePressed(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return 0.0;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return 0.0;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.mqvWHEuwnomGVOyodRZPEbJsWeit();
		}

		// Token: 0x06000FD3 RID: 4051 RVA: 0x00057484 File Offset: 0x00055684
		public double GetNegativeButtonTimeUnpressed(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return 0.0;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return 0.0;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.IgyWDwXEKwkniYMdFqRmkbavJkPO();
		}

		// Token: 0x06000FD4 RID: 4052 RVA: 0x000574DC File Offset: 0x000556DC
		public double GetNegativeButtonTimeUnpressed(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return 0.0;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return 0.0;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.IgyWDwXEKwkniYMdFqRmkbavJkPO();
		}

		// Token: 0x06000FD5 RID: 4053 RVA: 0x00057534 File Offset: 0x00055734
		public float GetAxis(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return 0f;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return 0f;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.ZPnnWnuioRHnHyXZXKWHKDyfDapAA();
		}

		// Token: 0x06000FD6 RID: 4054 RVA: 0x00057584 File Offset: 0x00055784
		public float GetAxis(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return 0f;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return 0f;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.ZPnnWnuioRHnHyXZXKWHKDyfDapAA();
		}

		// Token: 0x06000FD7 RID: 4055 RVA: 0x000575D4 File Offset: 0x000557D4
		public float GetAxisRaw(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return 0f;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return 0f;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.KBRilOANCOjinFxICUYpQZAcnxarB();
		}

		// Token: 0x06000FD8 RID: 4056 RVA: 0x00057624 File Offset: 0x00055824
		public float GetAxisRaw(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return 0f;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return 0f;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.KBRilOANCOjinFxICUYpQZAcnxarB();
		}

		// Token: 0x06000FD9 RID: 4057 RVA: 0x00057674 File Offset: 0x00055874
		public float GetAxisPrev(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return 0f;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return 0f;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.zeIvxBEyQDnSJZoRCukhvNlOQqPk();
		}

		// Token: 0x06000FDA RID: 4058 RVA: 0x000576C4 File Offset: 0x000558C4
		public float GetAxisPrev(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return 0f;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return 0f;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.zeIvxBEyQDnSJZoRCukhvNlOQqPk();
		}

		// Token: 0x06000FDB RID: 4059 RVA: 0x00057714 File Offset: 0x00055914
		public float GetAxisRawPrev(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return 0f;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return 0f;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.HkvMKqVfYwmAfauEGBultMpQzGWC();
		}

		// Token: 0x06000FDC RID: 4060 RVA: 0x00057764 File Offset: 0x00055964
		public float GetAxisRawPrev(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return 0f;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return 0f;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.HkvMKqVfYwmAfauEGBultMpQzGWC();
		}

		// Token: 0x06000FDD RID: 4061 RVA: 0x000577B4 File Offset: 0x000559B4
		public float GetAxisDelta(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return 0f;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return 0f;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.JcoMCwHbLcQrTzrfjEczXQEWhkKH();
		}

		// Token: 0x06000FDE RID: 4062 RVA: 0x00057804 File Offset: 0x00055A04
		public float GetAxisDelta(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return 0f;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return 0f;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.JcoMCwHbLcQrTzrfjEczXQEWhkKH();
		}

		// Token: 0x06000FDF RID: 4063 RVA: 0x00057854 File Offset: 0x00055A54
		public float GetAxisRawDelta(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return 0f;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return 0f;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.UGtpNRqVtWAMlxZxOBPFuiVrahSbA();
		}

		// Token: 0x06000FE0 RID: 4064 RVA: 0x000578A4 File Offset: 0x00055AA4
		public float GetAxisRawDelta(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return 0f;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return 0f;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.UGtpNRqVtWAMlxZxOBPFuiVrahSbA();
		}

		// Token: 0x06000FE1 RID: 4065 RVA: 0x000578F4 File Offset: 0x00055AF4
		public Vector2 GetAxis2D(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, xAxisActionName, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null)
			{
				result.x = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.ZPnnWnuioRHnHyXZXKWHKDyfDapAA();
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, yAxisActionName, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null)
			{
				result.y = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.ZPnnWnuioRHnHyXZXKWHKDyfDapAA();
			}
			return result;
		}

		// Token: 0x06000FE2 RID: 4066 RVA: 0x00057974 File Offset: 0x00055B74
		public Vector2 GetAxis2D(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, xAxisActionId, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null)
			{
				result.x = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.ZPnnWnuioRHnHyXZXKWHKDyfDapAA();
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, yAxisActionId, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null)
			{
				result.y = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.ZPnnWnuioRHnHyXZXKWHKDyfDapAA();
			}
			return result;
		}

		// Token: 0x06000FE3 RID: 4067 RVA: 0x000579F4 File Offset: 0x00055BF4
		public Vector2 GetAxis2DPrev(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, xAxisActionName, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null)
			{
				result.x = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.zeIvxBEyQDnSJZoRCukhvNlOQqPk();
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, yAxisActionName, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null)
			{
				result.y = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.zeIvxBEyQDnSJZoRCukhvNlOQqPk();
			}
			return result;
		}

		// Token: 0x06000FE4 RID: 4068 RVA: 0x00057A74 File Offset: 0x00055C74
		public Vector2 GetAxis2DPrev(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, xAxisActionId, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null)
			{
				result.x = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.zeIvxBEyQDnSJZoRCukhvNlOQqPk();
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, yAxisActionId, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null)
			{
				result.y = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.zeIvxBEyQDnSJZoRCukhvNlOQqPk();
			}
			return result;
		}

		// Token: 0x06000FE5 RID: 4069 RVA: 0x00057AF4 File Offset: 0x00055CF4
		public Vector2 GetAxis2DRaw(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, xAxisActionName, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null)
			{
				result.x = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.KBRilOANCOjinFxICUYpQZAcnxarB();
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, yAxisActionName, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null)
			{
				result.y = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.KBRilOANCOjinFxICUYpQZAcnxarB();
			}
			return result;
		}

		// Token: 0x06000FE6 RID: 4070 RVA: 0x00057B74 File Offset: 0x00055D74
		public Vector2 GetAxis2DRaw(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, xAxisActionId, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null)
			{
				result.x = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.KBRilOANCOjinFxICUYpQZAcnxarB();
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, yAxisActionId, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null)
			{
				result.y = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.KBRilOANCOjinFxICUYpQZAcnxarB();
			}
			return result;
		}

		// Token: 0x06000FE7 RID: 4071 RVA: 0x00057BF4 File Offset: 0x00055DF4
		public Vector2 GetAxis2DRawPrev(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, xAxisActionName, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null)
			{
				result.x = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.HkvMKqVfYwmAfauEGBultMpQzGWC();
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, yAxisActionName, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null)
			{
				result.y = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.HkvMKqVfYwmAfauEGBultMpQzGWC();
			}
			return result;
		}

		// Token: 0x06000FE8 RID: 4072 RVA: 0x00057C74 File Offset: 0x00055E74
		public Vector2 GetAxis2DRawPrev(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, xAxisActionId, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null)
			{
				result.x = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.HkvMKqVfYwmAfauEGBultMpQzGWC();
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, yAxisActionId, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null)
			{
				result.y = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.HkvMKqVfYwmAfauEGBultMpQzGWC();
			}
			return result;
		}

		// Token: 0x06000FE9 RID: 4073 RVA: 0x00057CF4 File Offset: 0x00055EF4
		public double GetAxisTimeActive(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return 0.0;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return 0.0;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.MmHkSwRdUQtZMocqRgPXgzuSUrfe();
		}

		// Token: 0x06000FEA RID: 4074 RVA: 0x00057D4C File Offset: 0x00055F4C
		public double GetAxisTimeActive(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return 0.0;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return 0.0;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.MmHkSwRdUQtZMocqRgPXgzuSUrfe();
		}

		// Token: 0x06000FEB RID: 4075 RVA: 0x00057DA4 File Offset: 0x00055FA4
		public double GetAxisTimeInactive(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return 0.0;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return 0.0;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.MyHSUivBytCndhknlCiBpZMblHfp();
		}

		// Token: 0x06000FEC RID: 4076 RVA: 0x00057DFC File Offset: 0x00055FFC
		public double GetAxisTimeInactive(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return 0.0;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return 0.0;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.MyHSUivBytCndhknlCiBpZMblHfp();
		}

		// Token: 0x06000FED RID: 4077 RVA: 0x00057E54 File Offset: 0x00056054
		public double GetAxisRawTimeActive(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return 0.0;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return 0.0;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.XcsRNAtPMzwEhwLaMacWaPEAmzFAA();
		}

		// Token: 0x06000FEE RID: 4078 RVA: 0x00057EAC File Offset: 0x000560AC
		public double GetAxisRawTimeActive(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return 0.0;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return 0.0;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.XcsRNAtPMzwEhwLaMacWaPEAmzFAA();
		}

		// Token: 0x06000FEF RID: 4079 RVA: 0x00057F04 File Offset: 0x00056104
		public double GetAxisRawTimeInactive(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return 0.0;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return 0.0;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yQYyLKQKnMfHmzMHuKICdnFYcLsf();
		}

		// Token: 0x06000FF0 RID: 4080 RVA: 0x00057F5C File Offset: 0x0005615C
		public double GetAxisRawTimeInactive(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return 0.0;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return 0.0;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yQYyLKQKnMfHmzMHuKICdnFYcLsf();
		}

		// Token: 0x06000FF1 RID: 4081 RVA: 0x00057FB4 File Offset: 0x000561B4
		public AxisCoordinateMode GetAxisCoordinateMode(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return AxisCoordinateMode.Absolute;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return AxisCoordinateMode.Absolute;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.WojBcNFKvgOvFnKvrgACEMevkdrI();
		}

		// Token: 0x06000FF2 RID: 4082 RVA: 0x00057FFC File Offset: 0x000561FC
		public AxisCoordinateMode GetAxisCoordinateMode(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return AxisCoordinateMode.Absolute;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return AxisCoordinateMode.Absolute;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.WojBcNFKvgOvFnKvrgACEMevkdrI();
		}

		// Token: 0x06000FF3 RID: 4083 RVA: 0x00058044 File Offset: 0x00056244
		public AxisCoordinateMode GetAxisRawCoordinateMode(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return AxisCoordinateMode.Absolute;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return AxisCoordinateMode.Absolute;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.igzeVXulKZrqUXFKfZkQvwwFHLSX();
		}

		// Token: 0x06000FF4 RID: 4084 RVA: 0x0005808C File Offset: 0x0005628C
		public AxisCoordinateMode GetAxisRawCoordinateMode(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return AxisCoordinateMode.Absolute;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return AxisCoordinateMode.Absolute;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.igzeVXulKZrqUXFKfZkQvwwFHLSX();
		}

		// Token: 0x06000FF5 RID: 4085 RVA: 0x000580D4 File Offset: 0x000562D4
		public AxisCoordinateMode GetAxisCoordinateModePrev(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return AxisCoordinateMode.Absolute;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return AxisCoordinateMode.Absolute;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.YXXRsKQIANjvEVswVdHbSLmqlDgX();
		}

		// Token: 0x06000FF6 RID: 4086 RVA: 0x0005811C File Offset: 0x0005631C
		public AxisCoordinateMode GetAxisCoordinateModePrev(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return AxisCoordinateMode.Absolute;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return AxisCoordinateMode.Absolute;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.YXXRsKQIANjvEVswVdHbSLmqlDgX();
		}

		// Token: 0x06000FF7 RID: 4087 RVA: 0x00058164 File Offset: 0x00056364
		public AxisCoordinateMode GetAxisRawCoordinateModePrev(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return AxisCoordinateMode.Absolute;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return AxisCoordinateMode.Absolute;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.gJqeezRfNRnzoFsyAoiEtwoAjOmu();
		}

		// Token: 0x06000FF8 RID: 4088 RVA: 0x000581AC File Offset: 0x000563AC
		public AxisCoordinateMode GetAxisRawCoordinateModePrev(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return AxisCoordinateMode.Absolute;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return AxisCoordinateMode.Absolute;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.gJqeezRfNRnzoFsyAoiEtwoAjOmu();
		}

		// Token: 0x06000FF9 RID: 4089 RVA: 0x000581F4 File Offset: 0x000563F4
		public IList<InputActionSourceData> GetCurrentInputSources(string actionName)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return EmptyObjects<InputActionSourceData>.EmptyReadOnlyIListT;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return null;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.hZiPskALAXsUtBLlSarWzvOmmtg();
		}

		// Token: 0x06000FFA RID: 4090 RVA: 0x00058240 File Offset: 0x00056440
		public IList<InputActionSourceData> GetCurrentInputSources(int actionId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return EmptyObjects<InputActionSourceData>.EmptyReadOnlyIListT;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return null;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.hZiPskALAXsUtBLlSarWzvOmmtg();
		}

		// Token: 0x06000FFB RID: 4091 RVA: 0x0005828C File Offset: 0x0005648C
		public bool IsCurrentInputSource(string actionName, ControllerType controllerType)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.adFzUOgTCBtNzHOwtlssTlcJhXZw(controllerType);
		}

		// Token: 0x06000FFC RID: 4092 RVA: 0x000582D4 File Offset: 0x000564D4
		public bool IsCurrentInputSource(int actionId, ControllerType controllerType)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.adFzUOgTCBtNzHOwtlssTlcJhXZw(controllerType);
		}

		// Token: 0x06000FFD RID: 4093 RVA: 0x0005831C File Offset: 0x0005651C
		public bool IsCurrentInputSource(string actionName, ControllerType controllerType, int controllerId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.onRntVgtimRSBUIRmCSKFoWcDZalA(controllerType, controllerId);
		}

		// Token: 0x06000FFE RID: 4094 RVA: 0x00058368 File Offset: 0x00056568
		public bool IsCurrentInputSource(int actionId, ControllerType controllerType, int controllerId)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.onRntVgtimRSBUIRmCSKFoWcDZalA(controllerType, controllerId);
		}

		// Token: 0x06000FFF RID: 4095 RVA: 0x000583B4 File Offset: 0x000565B4
		public bool IsCurrentInputSource(string actionName, Controller controller)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.fiLGJJdVcENVGgSJAtPxuPWNyVxq(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionName, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.fGcZYgmiFVldvaTpBCLSjlgpYnWm(controller);
		}

		// Token: 0x06001000 RID: 4096 RVA: 0x000583FC File Offset: 0x000565FC
		public bool IsCurrentInputSource(int actionId, Controller controller)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return false;
			}
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.LuhdSyQNGuuUqPpzFxduIHmdweOD.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.fGcZYgmiFVldvaTpBCLSjlgpYnWm(controller);
		}

		// Token: 0x06001001 RID: 4097 RVA: 0x0000E126 File Offset: 0x0000C326
		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return;
			}
			this.LuhdSyQNGuuUqPpzFxduIHmdweOD.vTnbusDrRofmNosKerOafyqkdkApA(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, callback, updateLoop);
		}

		// Token: 0x06001002 RID: 4098 RVA: 0x0000E15D File Offset: 0x0000C35D
		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, int actionId)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return;
			}
			this.LuhdSyQNGuuUqPpzFxduIHmdweOD.HcrCEzfnUdPbIymfGHEFHHdjKgvxA(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, callback, updateLoop, actionId);
		}

		// Token: 0x06001003 RID: 4099 RVA: 0x00058444 File Offset: 0x00056644
		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return;
			}
			int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
			if (num < 0)
			{
				return;
			}
			this.AddInputEventDelegate(callback, updateLoop, num);
		}

		// Token: 0x06001004 RID: 4100 RVA: 0x0000E195 File Offset: 0x0000C395
		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType)
		{
			this.AddInputEventDelegate(callback, updateLoop, eventType, null);
		}

		// Token: 0x06001005 RID: 4101 RVA: 0x0000E1A1 File Offset: 0x0000C3A1
		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId)
		{
			this.AddInputEventDelegate(callback, updateLoop, eventType, actionId, null);
		}

		// Token: 0x06001006 RID: 4102 RVA: 0x0000E1AF File Offset: 0x0000C3AF
		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName)
		{
			this.AddInputEventDelegate(callback, updateLoop, eventType, actionName, null);
		}

		// Token: 0x06001007 RID: 4103 RVA: 0x0000E1BD File Offset: 0x0000C3BD
		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, object[] arguments)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return;
			}
			this.LuhdSyQNGuuUqPpzFxduIHmdweOD.NGJWVZRCNKHNwXgxiGvYcKCOeKAW(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, callback, updateLoop, eventType, arguments);
		}

		// Token: 0x06001008 RID: 4104 RVA: 0x0000E1F7 File Offset: 0x0000C3F7
		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId, object[] arguments)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return;
			}
			this.LuhdSyQNGuuUqPpzFxduIHmdweOD.MfGHPrfwRvhfpRvBcAEVSURLbbpc(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, callback, updateLoop, eventType, actionId, arguments);
		}

		// Token: 0x06001009 RID: 4105 RVA: 0x00058490 File Offset: 0x00056690
		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName, object[] arguments)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return;
			}
			int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, true);
			if (num < 0)
			{
				return;
			}
			this.AddInputEventDelegate(callback, updateLoop, eventType, num, arguments);
		}

		// Token: 0x0600100A RID: 4106 RVA: 0x0000E233 File Offset: 0x0000C433
		public void RemoveInputEventDelegate(Action<InputActionEventData> callback)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return;
			}
			this.LuhdSyQNGuuUqPpzFxduIHmdweOD.BhKaSrCZQHKgxCsCjmQxCVSAaYFi(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, callback);
		}

		// Token: 0x0600100B RID: 4107 RVA: 0x0000E269 File Offset: 0x0000C469
		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, int actionId)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return;
			}
			this.LuhdSyQNGuuUqPpzFxduIHmdweOD.ZYghHiKYAMGgVAwEsmxTpYNEaHaQ(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, callback, actionId);
		}

		// Token: 0x0600100C RID: 4108 RVA: 0x000584E0 File Offset: 0x000566E0
		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return;
			}
			int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
			if (num < 0)
			{
				return;
			}
			this.RemoveInputEventDelegate(callback, num);
		}

		// Token: 0x0600100D RID: 4109 RVA: 0x0000E2A0 File Offset: 0x0000C4A0
		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return;
			}
			this.LuhdSyQNGuuUqPpzFxduIHmdweOD.zaLyovAUdvqWrEPMoEfyNOTEtdQA(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, callback, updateLoop);
		}

		// Token: 0x0600100E RID: 4110 RVA: 0x0000E2D7 File Offset: 0x0000C4D7
		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return;
			}
			this.LuhdSyQNGuuUqPpzFxduIHmdweOD.gWNOxxzpPutiFCdDdhQsKiFxmDeOA(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, callback, eventType);
		}

		// Token: 0x0600100F RID: 4111 RVA: 0x0000E30E File Offset: 0x0000C50E
		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, int actionId)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return;
			}
			this.LuhdSyQNGuuUqPpzFxduIHmdweOD.EyyHLKOFulGcGVGEOdWNcGKpjYrL(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, callback, updateLoop, actionId);
		}

		// Token: 0x06001010 RID: 4112 RVA: 0x0005852C File Offset: 0x0005672C
		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return;
			}
			int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
			if (num < 0)
			{
				return;
			}
			this.RemoveInputEventDelegate(callback, updateLoop, num);
		}

		// Token: 0x06001011 RID: 4113 RVA: 0x0000E346 File Offset: 0x0000C546
		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, int actionId)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return;
			}
			this.LuhdSyQNGuuUqPpzFxduIHmdweOD.kZPGIGDqNztslErkuJqpsdHjpyvN(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, callback, eventType, actionId);
		}

		// Token: 0x06001012 RID: 4114 RVA: 0x00058578 File Offset: 0x00056778
		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return;
			}
			int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
			if (num < 0)
			{
				return;
			}
			this.RemoveInputEventDelegate(callback, eventType, num);
		}

		// Token: 0x06001013 RID: 4115 RVA: 0x0000E37E File Offset: 0x0000C57E
		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return;
			}
			this.LuhdSyQNGuuUqPpzFxduIHmdweOD.yKepZpVEJCWdrmTcCxzrocEgCxXu(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, callback, updateLoop, eventType);
		}

		// Token: 0x06001014 RID: 4116 RVA: 0x0000E3B6 File Offset: 0x0000C5B6
		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return;
			}
			this.LuhdSyQNGuuUqPpzFxduIHmdweOD.mPviolknEDCXUoMTcFNZAZhtrDrtA(this.slhAWVVynuDdrqbdGKDoRVmsCDYo, callback, updateLoop, eventType, actionId);
		}

		// Token: 0x06001015 RID: 4117 RVA: 0x000585C4 File Offset: 0x000567C4
		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return;
			}
			int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
			if (num < 0)
			{
				return;
			}
			this.RemoveInputEventDelegate(callback, updateLoop, eventType, num);
		}

		// Token: 0x06001016 RID: 4118 RVA: 0x0000E3F0 File Offset: 0x0000C5F0
		public void ClearInputEventDelegates()
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return;
			}
			this.LuhdSyQNGuuUqPpzFxduIHmdweOD.KYmAypTqYCeCpNZfpglURgHIzmcw(this.slhAWVVynuDdrqbdGKDoRVmsCDYo);
		}

		// Token: 0x06001017 RID: 4119 RVA: 0x0000E425 File Offset: 0x0000C625
		public void SetVibration(int motorIndex, float motorLevel)
		{
			this.SetVibration(motorIndex, motorLevel, 0f, false);
		}

		// Token: 0x06001018 RID: 4120 RVA: 0x0000E435 File Offset: 0x0000C635
		public void SetVibration(int motorIndex, float motorLevel, float duration)
		{
			this.SetVibration(motorIndex, motorLevel, duration, false);
		}

		// Token: 0x06001019 RID: 4121 RVA: 0x0000E441 File Offset: 0x0000C641
		public void SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
		{
			this.SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors);
		}

		// Token: 0x0600101A RID: 4122 RVA: 0x00058610 File Offset: 0x00056810
		public void SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return;
			}
			IList<Joystick> joysticks = this.controllers.Joysticks;
			int count = joysticks.Count;
			for (int i = 0; i < count; i++)
			{
				Joystick joystick = joysticks[i];
				if (joystick.supportsVibration)
				{
					joystick.SetVibration(motorIndex, motorLevel, duration, stopOtherMotors);
				}
			}
		}

		// Token: 0x0600101B RID: 4123 RVA: 0x00058674 File Offset: 0x00056874
		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return 0f;
			}
			IList<Joystick> joysticks = this.controllers.Joysticks;
			int count = joysticks.Count;
			float num = 0f;
			for (int i = 0; i < count; i++)
			{
				Joystick joystick = joysticks[i];
				if (joystick.supportsVibration)
				{
					num = MathTools.Max(joystick.GetVibration(motorIndex), num);
				}
			}
			return num;
		}

		// Token: 0x0600101C RID: 4124 RVA: 0x000586E8 File Offset: 0x000568E8
		public void StopVibration()
		{
			if (ReInput._id != this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO)
			{
				ReInput.CheckInitialized(this.QjyfMtdnNpzWxEwbdFhMbtTIPCMO);
				return;
			}
			IList<Joystick> joysticks = this.controllers.Joysticks;
			int count = joysticks.Count;
			for (int i = 0; i < count; i++)
			{
				Joystick joystick = joysticks[i];
				if (joystick.supportsVibration)
				{
					joystick.StopVibration();
				}
			}
		}

		// Token: 0x0600101D RID: 4125 RVA: 0x0000E451 File Offset: 0x0000C651
		internal void ixrompnJlDynDDCuGroOxgEPNXdU()
		{
			this.CqkrkgcMXcGAaHZjaTDddtZyRmuoA();
		}

		// Token: 0x0600101E RID: 4126 RVA: 0x0000E459 File Offset: 0x0000C659
		private void CqkrkgcMXcGAaHZjaTDddtZyRmuoA()
		{
			this.controllers.EYUpqVTlEOXQBXHqvgqHaLWgmVll();
			this.LLxVKQorRjxduPjPCQMcpDvmXmDA = false;
		}

		// Token: 0x04000956 RID: 2390
		private const string shVavpymcPkBEnkjTicMfSPYAprj = "player";

		// Token: 0x04000957 RID: 2391
		private readonly HEnwyLWfnrHknWieEccXGXTAawGsA LuhdSyQNGuuUqPpzFxduIHmdweOD;

		// Token: 0x04000958 RID: 2392
		private bool jqcyaWGplYbNtDHTCkvWGQXUOIJuA;

		// Token: 0x04000959 RID: 2393
		private int slhAWVVynuDdrqbdGKDoRVmsCDYo;

		// Token: 0x0400095A RID: 2394
		private string SdnlqSbbNvbzagDywDBTSdmWCkUc;

		// Token: 0x0400095B RID: 2395
		private string xOGDdbhKTFOXIXjKDDaNUkmQsAOh;

		// Token: 0x0400095C RID: 2396
		private readonly string VyPgITeojqRJZAJiuFDbNYIUGAVO;

		// Token: 0x0400095D RID: 2397
		private bool LLxVKQorRjxduPjPCQMcpDvmXmDA;

		// Token: 0x0400095E RID: 2398
		private readonly int QjyfMtdnNpzWxEwbdFhMbtTIPCMO;

		// Token: 0x0400095F RID: 2399
		private readonly wAaCrzUbQDdcHiRBVWRRKbzVqQGMA QiYHHuUhquTeLkjtuBVnGlFhUZoKA;

		// Token: 0x04000960 RID: 2400
		private int LXmabZESfMqxbUmNTtDZjostIMydA;

		// Token: 0x04000961 RID: 2401
		public readonly Player.ControllerHelper controllers;

		// Token: 0x0200016B RID: 363
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class ControllerHelper
		{
			// Token: 0x17000465 RID: 1125
			// (get) Token: 0x0600101F RID: 4127 RVA: 0x0000E46D File Offset: 0x0000C66D
			private Player<Joystick, JoystickMap>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi BcBAdMCyMCZFOVEAbrSfSqwjRZYO
			{
				get
				{
					return (Player<Joystick, JoystickMap>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi)this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(ControllerType.Joystick);
				}
			}

			// Token: 0x17000466 RID: 1126
			// (get) Token: 0x06001020 RID: 4128 RVA: 0x0000E480 File Offset: 0x0000C680
			private VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<KeyboardMap> IBQRiBQwBQkksvMFoghSPVjYfKdq
			{
				get
				{
					return (VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<KeyboardMap>)this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(ControllerType.Keyboard).cLCIFSrSsIdpuGCXMXmeTmizjypZ(0).AxzIHFaeuZajYboPHuvsfCYAXoQwA;
				}
			}

			// Token: 0x17000467 RID: 1127
			// (get) Token: 0x06001021 RID: 4129 RVA: 0x0000E49E File Offset: 0x0000C69E
			private VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<MouseMap> boJfSzOZpBUMMRMJLlCAwvRKpwKC
			{
				get
				{
					return (VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<MouseMap>)this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(ControllerType.Mouse).cLCIFSrSsIdpuGCXMXmeTmizjypZ(0).AxzIHFaeuZajYboPHuvsfCYAXoQwA;
				}
			}

			// Token: 0x17000468 RID: 1128
			// (get) Token: 0x06001022 RID: 4130 RVA: 0x0000E4BC File Offset: 0x0000C6BC
			private Player<CustomController, CustomControllerMap>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi iTsNyOKxlQOyyWXaASlipXGJRPTN
			{
				get
				{
					return (Player<CustomController, CustomControllerMap>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi)this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(ControllerType.Custom);
				}
			}

			// Token: 0x06001023 RID: 4131 RVA: 0x00058744 File Offset: 0x00056944
			internal ControllerHelper(Player A_1, OdwwNwDVsLLbukoEpkWRZpETNEYi A_2, ControllerMapLayoutManager.YuRWKBhEFGtHaIyXShqNamLdASyj A_3, ControllerMapEnabler.YqpaJJElEihfpIGutrHkMZgMkOuC A_4)
			{
				this.MIPUxAHdABBOEwtyfTUSosHIROxn = ReInput.id;
				this.PssdVhgihfxSSsOlqFEigtLgkZFIb = A_1;
				this.maps = new Player.ControllerHelper.MapHelper(A_1, this, A_2, A_3, A_4);
				this.polling = new Player.ControllerHelper.PollingHelper(A_1, this);
				this.conflictChecking = new Player.ControllerHelper.ConflictCheckingHelper(A_1, this);
				this.ylCPpFWsrSbqhhneUtsQXRtlJEDi = new Player.ControllerHelper.rrwhAMAJavPyFelmoWqKjwiNpysP(4);
				this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.KkyiJfnnmfZsDyVJdMMuGYQxUveM(0, ControllerType.Joystick, new Player<Joystick, JoystickMap>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi());
				this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.KkyiJfnnmfZsDyVJdMMuGYQxUveM(1, ControllerType.Keyboard, new Player<Keyboard, KeyboardMap>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi());
				this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.KkyiJfnnmfZsDyVJdMMuGYQxUveM(2, ControllerType.Mouse, new Player<Mouse, MouseMap>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi());
				this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.KkyiJfnnmfZsDyVJdMMuGYQxUveM(3, ControllerType.Custom, new Player<CustomController, CustomControllerMap>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi());
				this.BhYmddYjQBpTYSjebSXDXGRpyVFj = new Player.ControllerHelper.qIXNxngxvPnyUKiwJbWeyVtlOaCm(A_1);
				this.eyxqhzrAGWgJpPTqGJLkcKwcLRcb = new RXwELUeslTkclmlgxEgZCHffugOj(UnityTools.externalTools.GetControllerTemplateTypes(), UnityTools.externalTools.GetControllerTemplateInterfaceTypes());
			}

			// Token: 0x1400001A RID: 26
			// (add) Token: 0x06001024 RID: 4132 RVA: 0x0000E4D0 File Offset: 0x0000C6D0
			// (remove) Token: 0x06001025 RID: 4133 RVA: 0x0000E4DE File Offset: 0x0000C6DE
			public event Action<ControllerAssignmentChangedEventArgs> ControllerAddedEvent
			{
				add
				{
					this.psXJPGhJHrnEtgaAhCUhBtZVmLssA.AddDelegate(value);
				}
				remove
				{
					this.psXJPGhJHrnEtgaAhCUhBtZVmLssA.RemoveDelegate(value);
				}
			}

			// Token: 0x1400001B RID: 27
			// (add) Token: 0x06001026 RID: 4134 RVA: 0x0000E4EC File Offset: 0x0000C6EC
			// (remove) Token: 0x06001027 RID: 4135 RVA: 0x0000E4FA File Offset: 0x0000C6FA
			public event Action<ControllerAssignmentChangedEventArgs> ControllerRemovedEvent
			{
				add
				{
					this.XANDlQbPZMPExfbfmwyntrCXdNgHA.AddDelegate(value);
				}
				remove
				{
					this.XANDlQbPZMPExfbfmwyntrCXdNgHA.RemoveDelegate(value);
				}
			}

			// Token: 0x17000469 RID: 1129
			// (get) Token: 0x06001028 RID: 4136 RVA: 0x0000E508 File Offset: 0x0000C708
			// (set) Token: 0x06001029 RID: 4137 RVA: 0x00058868 File Offset: 0x00056A68
			public bool hasMouse
			{
				get
				{
					if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
					{
						ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
						return false;
					}
					return this.XBolbQiDSdCaKCpMixItUgVeDfkAb;
				}
				set
				{
					if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
					{
						ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
						return;
					}
					if (this.XBolbQiDSdCaKCpMixItUgVeDfkAb == value)
					{
						return;
					}
					this.XBolbQiDSdCaKCpMixItUgVeDfkAb = value;
					if (value)
					{
						this.eyxqhzrAGWgJpPTqGJLkcKwcLRcb.zasBhsaAvoJpxZfKGoCjaYtFpigYB(this.Mouse);
					}
					else
					{
						this.eyxqhzrAGWgJpPTqGJLkcKwcLRcb.QvDjjGLIVKsQuJmOzAqldvnCtsBH(this.Mouse);
					}
					if (value)
					{
						this.maps.layoutManager.Apply();
						if (this.psXJPGhJHrnEtgaAhCUhBtZVmLssA.Count > 0)
						{
							this.psXJPGhJHrnEtgaAhCUhBtZVmLssA.Invoke(new ControllerAssignmentChangedEventArgs(this.PssdVhgihfxSSsOlqFEigtLgkZFIb.id, ReInput.controllers.Mouse.id, ControllerType.Mouse, value));
							return;
						}
					}
					else if (this.XANDlQbPZMPExfbfmwyntrCXdNgHA.Count > 0)
					{
						this.XANDlQbPZMPExfbfmwyntrCXdNgHA.Invoke(new ControllerAssignmentChangedEventArgs(this.PssdVhgihfxSSsOlqFEigtLgkZFIb.id, ReInput.controllers.Mouse.id, ControllerType.Mouse, value));
					}
				}
			}

			// Token: 0x1700046A RID: 1130
			// (get) Token: 0x0600102A RID: 4138 RVA: 0x0000E52B File Offset: 0x0000C72B
			// (set) Token: 0x0600102B RID: 4139 RVA: 0x00058950 File Offset: 0x00056B50
			public bool hasKeyboard
			{
				get
				{
					if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
					{
						ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
						return false;
					}
					return this.pfJEVdWSPRUAULafKDQwbutdUTgK;
				}
				set
				{
					if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
					{
						ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
						return;
					}
					if (this.pfJEVdWSPRUAULafKDQwbutdUTgK == value)
					{
						return;
					}
					this.pfJEVdWSPRUAULafKDQwbutdUTgK = value;
					if (value)
					{
						this.eyxqhzrAGWgJpPTqGJLkcKwcLRcb.zasBhsaAvoJpxZfKGoCjaYtFpigYB(this.Keyboard);
					}
					else
					{
						this.eyxqhzrAGWgJpPTqGJLkcKwcLRcb.QvDjjGLIVKsQuJmOzAqldvnCtsBH(this.Keyboard);
					}
					if (value)
					{
						this.maps.layoutManager.Apply();
						if (this.psXJPGhJHrnEtgaAhCUhBtZVmLssA.Count > 0)
						{
							this.psXJPGhJHrnEtgaAhCUhBtZVmLssA.Invoke(new ControllerAssignmentChangedEventArgs(this.PssdVhgihfxSSsOlqFEigtLgkZFIb.id, ReInput.controllers.Keyboard.id, ControllerType.Keyboard, value));
							return;
						}
					}
					else if (this.XANDlQbPZMPExfbfmwyntrCXdNgHA.Count > 0)
					{
						this.XANDlQbPZMPExfbfmwyntrCXdNgHA.Invoke(new ControllerAssignmentChangedEventArgs(this.PssdVhgihfxSSsOlqFEigtLgkZFIb.id, ReInput.controllers.Keyboard.id, ControllerType.Keyboard, value));
					}
				}
			}

			// Token: 0x1700046B RID: 1131
			// (get) Token: 0x0600102C RID: 4140 RVA: 0x0000E54E File Offset: 0x0000C74E
			// (set) Token: 0x0600102D RID: 4141 RVA: 0x0000E571 File Offset: 0x0000C771
			public bool excludeFromControllerAutoAssignment
			{
				get
				{
					if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
					{
						ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
						return false;
					}
					return this.PIEHPIgJuqWGSngsqmFTzHLntGRi;
				}
				set
				{
					if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
					{
						ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
						return;
					}
					this.PIEHPIgJuqWGSngsqmFTzHLntGRi = value;
				}
			}

			// Token: 0x1700046C RID: 1132
			// (get) Token: 0x0600102E RID: 4142 RVA: 0x0000E594 File Offset: 0x0000C794
			public Keyboard Keyboard
			{
				get
				{
					if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
					{
						ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
						return null;
					}
					return ReInput.controllers.Keyboard;
				}
			}

			// Token: 0x1700046D RID: 1133
			// (get) Token: 0x0600102F RID: 4143 RVA: 0x0000E5BB File Offset: 0x0000C7BB
			public Mouse Mouse
			{
				get
				{
					if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
					{
						ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
						return null;
					}
					return ReInput.controllers.Mouse;
				}
			}

			// Token: 0x1700046E RID: 1134
			// (get) Token: 0x06001030 RID: 4144 RVA: 0x0000E5E2 File Offset: 0x0000C7E2
			public int joystickCount
			{
				get
				{
					if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
					{
						ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
						return 0;
					}
					return this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(ControllerType.Joystick).hUvoPojtJZIUBnFkCGjslfijGbmL;
				}
			}

			// Token: 0x1700046F RID: 1135
			// (get) Token: 0x06001031 RID: 4145 RVA: 0x0000E610 File Offset: 0x0000C810
			public IList<Joystick> Joysticks
			{
				get
				{
					if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
					{
						ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
						return EmptyObjects<Joystick>.EmptyReadOnlyIListT;
					}
					return (this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(ControllerType.Joystick) as Player<Joystick, JoystickMap>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi).NxlJdafVlRhoHuADzQEVEdFdHwPV;
				}
			}

			// Token: 0x17000470 RID: 1136
			// (get) Token: 0x06001032 RID: 4146 RVA: 0x0000E647 File Offset: 0x0000C847
			public int customControllerCount
			{
				get
				{
					if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
					{
						ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
						return 0;
					}
					return this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(ControllerType.Custom).hUvoPojtJZIUBnFkCGjslfijGbmL;
				}
			}

			// Token: 0x17000471 RID: 1137
			// (get) Token: 0x06001033 RID: 4147 RVA: 0x0000E676 File Offset: 0x0000C876
			public IList<CustomController> CustomControllers
			{
				get
				{
					if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
					{
						ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
						return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
					}
					return (this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(ControllerType.Custom) as Player<CustomController, CustomControllerMap>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi).NxlJdafVlRhoHuADzQEVEdFdHwPV;
				}
			}

			// Token: 0x17000472 RID: 1138
			// (get) Token: 0x06001034 RID: 4148 RVA: 0x0000E6AE File Offset: 0x0000C8AE
			public IEnumerable<Controller> Controllers
			{
				get
				{
					if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
					{
						ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
						yield break;
					}
					if (this.XBolbQiDSdCaKCpMixItUgVeDfkAb)
					{
						yield return this.Mouse;
					}
					if (this.pfJEVdWSPRUAULafKDQwbutdUTgK)
					{
						yield return this.Keyboard;
					}
					int joystickCount = this.joystickCount;
					IList<Joystick> joysticks = this.Joysticks;
					int num;
					for (int i = 0; i < joystickCount; i = num + 1)
					{
						yield return joysticks[i];
						num = i;
					}
					int customControllerCount = this.customControllerCount;
					IList<CustomController> customControllers = this.CustomControllers;
					for (int i = 0; i < customControllerCount; i = num + 1)
					{
						yield return customControllers[i];
						num = i;
					}
					yield break;
				}
			}

			// Token: 0x06001035 RID: 4149 RVA: 0x00058A38 File Offset: 0x00056C38
			public T GetController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
				{
					ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
					return default(T);
				}
				return (T)((object)this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(gRvITEHjKMrWaeGYEmAHofbpCtEU.sdaTGzPrKPjPURvMxmwHNQmTiDRV<T>()).lmFqlCGyYlAWBPNeInDqnuyRDBxi(controllerId));
			}

			// Token: 0x06001036 RID: 4150 RVA: 0x0000E6BE File Offset: 0x0000C8BE
			public Controller GetController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
				{
					ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
					return null;
				}
				return this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controllerType).lmFqlCGyYlAWBPNeInDqnuyRDBxi(controllerId);
			}

			// Token: 0x06001037 RID: 4151 RVA: 0x00058A84 File Offset: 0x00056C84
			public T GetControllerWithTag<T>(string tag) where T : Controller
			{
				if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
				{
					ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
					return default(T);
				}
				return (T)((object)this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(gRvITEHjKMrWaeGYEmAHofbpCtEU.sdaTGzPrKPjPURvMxmwHNQmTiDRV<T>()).aOQBhrWxqyVDNyjiLDwicPaZxxRHA(tag));
			}

			// Token: 0x06001038 RID: 4152 RVA: 0x0000E6ED File Offset: 0x0000C8ED
			public Controller GetControllerWithTag(ControllerType controllerType, string tag)
			{
				if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
				{
					ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
					return null;
				}
				return this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controllerType).aOQBhrWxqyVDNyjiLDwicPaZxxRHA(tag);
			}

			// Token: 0x06001039 RID: 4153 RVA: 0x00058AD0 File Offset: 0x00056CD0
			public void AddController<T>(int controllerId, bool removeFromOtherPlayers) where T : Controller
			{
				if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
				{
					ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					this.FjhTSIfWwYBtprKveEXlTTCLtnOd(controllerId, removeFromOtherPlayers);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					this.AddController(ControllerType.Keyboard, controllerId, removeFromOtherPlayers);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					this.AddController(ControllerType.Mouse, controllerId, removeFromOtherPlayers);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					this.esIrlgcTMJDmfgTOEKgeMgYkMlzJ(controllerId, removeFromOtherPlayers);
					return;
				}
				throw new NotImplementedException();
			}

			// Token: 0x0600103A RID: 4154 RVA: 0x00058B78 File Offset: 0x00056D78
			public void AddController(Controller controller, bool removeFromOtherPlayers)
			{
				if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
				{
					ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
					return;
				}
				if (controller == null)
				{
					return;
				}
				ControllerType type = controller.type;
				switch (type)
				{
				case ControllerType.Keyboard:
					this.AddController(controller.type, controller.id, removeFromOtherPlayers);
					return;
				case ControllerType.Mouse:
					this.AddController(controller.type, controller.id, removeFromOtherPlayers);
					return;
				case ControllerType.Joystick:
					this.tDAgZZdWZkhWALHWlMkKACBYvIMxA(controller as Joystick, removeFromOtherPlayers);
					return;
				default:
					if (type != ControllerType.Custom)
					{
						throw new NotImplementedException();
					}
					this.kxwIeJTjxOkmVbqsvaSqCGtGUKAY(controller as CustomController, removeFromOtherPlayers);
					return;
				}
			}

			// Token: 0x0600103B RID: 4155 RVA: 0x00058C0C File Offset: 0x00056E0C
			public void AddController(ControllerType controllerType, int controllerId, bool removeFromOtherPlayers)
			{
				if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
				{
					ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Keyboard:
					if (removeFromOtherPlayers)
					{
						ReInput.controllers.RemoveControllerFromAllPlayers(controllerType, controllerId, true);
					}
					this.hasKeyboard = true;
					return;
				case ControllerType.Mouse:
					if (removeFromOtherPlayers)
					{
						ReInput.controllers.RemoveControllerFromAllPlayers(controllerType, controllerId, true);
					}
					this.hasMouse = true;
					return;
				case ControllerType.Joystick:
					this.tDAgZZdWZkhWALHWlMkKACBYvIMxA(ReInput.controllers.GetController(controllerType, controllerId) as Joystick, removeFromOtherPlayers);
					return;
				default:
					if (controllerType != ControllerType.Custom)
					{
						throw new NotImplementedException();
					}
					this.kxwIeJTjxOkmVbqsvaSqCGtGUKAY(ReInput.controllers.GetController(controllerType, controllerId) as CustomController, removeFromOtherPlayers);
					return;
				}
			}

			// Token: 0x0600103C RID: 4156 RVA: 0x00058CB4 File Offset: 0x00056EB4
			public void RemoveController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
				{
					ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					this.hDhwfOYWVKMQYXHiWylsHIBvDwRn(controllerId);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					this.RemoveController(ControllerType.Keyboard, 0);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					this.RemoveController(ControllerType.Mouse, 0);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					this.PzcBXrzCKvEvfPaLHxuIkAIqFiQq(controllerId);
					return;
				}
				throw new NotImplementedException();
			}

			// Token: 0x0600103D RID: 4157 RVA: 0x00058D58 File Offset: 0x00056F58
			public void RemoveController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
				{
					ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Keyboard:
					this.hasKeyboard = false;
					return;
				case ControllerType.Mouse:
					this.hasMouse = false;
					return;
				case ControllerType.Joystick:
					this.hDhwfOYWVKMQYXHiWylsHIBvDwRn(controllerId);
					return;
				default:
					if (controllerType != ControllerType.Custom)
					{
						throw new NotImplementedException();
					}
					this.PzcBXrzCKvEvfPaLHxuIkAIqFiQq(controllerId);
					return;
				}
			}

			// Token: 0x0600103E RID: 4158 RVA: 0x00058DC0 File Offset: 0x00056FC0
			public void RemoveController(Controller controller)
			{
				if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
				{
					ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
					return;
				}
				if (controller == null)
				{
					return;
				}
				ControllerType type = controller.type;
				switch (type)
				{
				case ControllerType.Keyboard:
					this.hasKeyboard = false;
					return;
				case ControllerType.Mouse:
					this.hasMouse = false;
					return;
				case ControllerType.Joystick:
					this.ARpcVSpEarBEKjFbBWSySbFNiYfM(controller as Joystick);
					return;
				default:
					if (type != ControllerType.Custom)
					{
						throw new NotImplementedException();
					}
					this.mrEeOPDTcljdFyiTyOYQbldchzEJB(controller as CustomController);
					return;
				}
			}

			// Token: 0x0600103F RID: 4159 RVA: 0x00058E3C File Offset: 0x0005703C
			public bool ContainsController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
				{
					ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
					return false;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					return this.ContainsController(ControllerType.Joystick, controllerId);
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					return this.pfJEVdWSPRUAULafKDQwbutdUTgK;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					return this.XBolbQiDSdCaKCpMixItUgVeDfkAb;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					return this.ContainsController(ControllerType.Custom, controllerId);
				}
				throw new NotImplementedException();
			}

			// Token: 0x06001040 RID: 4160 RVA: 0x00058EE0 File Offset: 0x000570E0
			public bool ContainsController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
				{
					ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
					return false;
				}
				switch (controllerType)
				{
				case ControllerType.Keyboard:
					return this.pfJEVdWSPRUAULafKDQwbutdUTgK;
				case ControllerType.Mouse:
					return this.XBolbQiDSdCaKCpMixItUgVeDfkAb;
				case ControllerType.Joystick:
					return this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(ControllerType.Joystick).MouplaShCfFxRczQNCMHkYFFsxzk(controllerId);
				default:
					if (controllerType != ControllerType.Custom)
					{
						throw new NotImplementedException();
					}
					return this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(ControllerType.Custom).MouplaShCfFxRczQNCMHkYFFsxzk(controllerId);
				}
			}

			// Token: 0x06001041 RID: 4161 RVA: 0x0000E71C File Offset: 0x0000C91C
			public bool ContainsController(Controller controller)
			{
				if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
				{
					ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
					return false;
				}
				return controller != null && this.ContainsController(controller.type, controller.id);
			}

			// Token: 0x06001042 RID: 4162 RVA: 0x00058F5C File Offset: 0x0005715C
			public void ClearControllersOfType<T>() where T : Controller
			{
				if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
				{
					ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					this.VvrUVIZrMSwcFDpCXdWTAzeEjVhKA();
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					this.hasKeyboard = false;
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					this.hasMouse = false;
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					this.uGjdhWePboDlOHwICvTwhPXXfvBLB();
					return;
				}
				if (typeFromHandle == typeof(Controller))
				{
					this.ClearAllControllers();
					return;
				}
				throw new NotImplementedException();
			}

			// Token: 0x06001043 RID: 4163 RVA: 0x00059010 File Offset: 0x00057210
			public void ClearControllersOfType(ControllerType controllerType)
			{
				if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
				{
					ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Keyboard:
					this.hasKeyboard = false;
					return;
				case ControllerType.Mouse:
					this.hasMouse = false;
					return;
				case ControllerType.Joystick:
					this.VvrUVIZrMSwcFDpCXdWTAzeEjVhKA();
					return;
				default:
					if (controllerType != ControllerType.Custom)
					{
						throw new NotImplementedException();
					}
					this.uGjdhWePboDlOHwICvTwhPXXfvBLB();
					return;
				}
			}

			// Token: 0x06001044 RID: 4164 RVA: 0x0000E750 File Offset: 0x0000C950
			public void ClearAllControllers()
			{
				if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
				{
					ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
					return;
				}
				this.VvrUVIZrMSwcFDpCXdWTAzeEjVhKA();
				this.uGjdhWePboDlOHwICvTwhPXXfvBLB();
				this.hasMouse = false;
				this.hasKeyboard = false;
			}

			// Token: 0x06001045 RID: 4165 RVA: 0x00059074 File Offset: 0x00057274
			public Controller GetLastActiveController()
			{
				if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
				{
					ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
					return null;
				}
				Controller result = null;
				double num = 0.0;
				this.jeyUVPVmyADwXuJyyJFKpINFfJiO(ControllerType.Joystick, ref result, ref num);
				if (this.XBolbQiDSdCaKCpMixItUgVeDfkAb && this.aXPkROCyXVClsoJGDtGgsQjzwefb > num)
				{
					result = this.Mouse;
					num = this.aXPkROCyXVClsoJGDtGgsQjzwefb;
				}
				if (this.pfJEVdWSPRUAULafKDQwbutdUTgK && this.aNGZibrTsnPalUSPlVaHoBlevpoT > num)
				{
					result = this.Keyboard;
					num = this.aNGZibrTsnPalUSPlVaHoBlevpoT;
				}
				this.jeyUVPVmyADwXuJyyJFKpINFfJiO(ControllerType.Custom, ref result, ref num);
				return result;
			}

			// Token: 0x06001046 RID: 4166 RVA: 0x00059100 File Offset: 0x00057300
			public Controller GetLastActiveController(ControllerType controllerType)
			{
				if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
				{
					ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
					return null;
				}
				Controller result = null;
				double num = 0.0;
				switch (controllerType)
				{
				case ControllerType.Keyboard:
					if (this.pfJEVdWSPRUAULafKDQwbutdUTgK && this.aNGZibrTsnPalUSPlVaHoBlevpoT > 0.0)
					{
						return this.Keyboard;
					}
					return result;
				case ControllerType.Mouse:
					if (this.XBolbQiDSdCaKCpMixItUgVeDfkAb && this.aXPkROCyXVClsoJGDtGgsQjzwefb > 0.0)
					{
						return this.Mouse;
					}
					return result;
				case ControllerType.Joystick:
					break;
				default:
					if (controllerType != ControllerType.Custom)
					{
						throw new NotImplementedException();
					}
					break;
				}
				this.jeyUVPVmyADwXuJyyJFKpINFfJiO(controllerType, ref result, ref num);
				return result;
			}

			// Token: 0x06001047 RID: 4167 RVA: 0x000591A4 File Offset: 0x000573A4
			private void jeyUVPVmyADwXuJyyJFKpINFfJiO(ControllerType A_1, ref Controller A_2, ref double A_3)
			{
				Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
				int num = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
				for (int i = 0; i < num; i++)
				{
					double num2 = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).SPyuFlXcCdXFNvHtLKsnEWxndtWR;
					if (num2 > A_3)
					{
						A_2 = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).PBJHfnhJKAlWfSVgUYDoQBOBahDP;
						A_3 = num2;
					}
				}
			}

			// Token: 0x06001048 RID: 4168 RVA: 0x0000E786 File Offset: 0x0000C986
			public Controller GetLastActiveController<T>() where T : Controller
			{
				return this.GetLastActiveController(gRvITEHjKMrWaeGYEmAHofbpCtEU.sdaTGzPrKPjPURvMxmwHNQmTiDRV<T>());
			}

			// Token: 0x06001049 RID: 4169 RVA: 0x0000E793 File Offset: 0x0000C993
			public void AddLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback)
			{
				if (!ReInput.isReady)
				{
					return;
				}
				if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
				{
					ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
					return;
				}
				this.PssdVhgihfxSSsOlqFEigtLgkZFIb.LuhdSyQNGuuUqPpzFxduIHmdweOD.WXDlgPzWNhwmyOycMStAzPJIpchm(this.PssdVhgihfxSSsOlqFEigtLgkZFIb.slhAWVVynuDdrqbdGKDoRVmsCDYo, callback);
			}

			// Token: 0x0600104A RID: 4170 RVA: 0x000591F4 File Offset: 0x000573F4
			public void AddLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (!ReInput.isReady)
				{
					return;
				}
				if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
				{
					ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
					return;
				}
				this.PssdVhgihfxSSsOlqFEigtLgkZFIb.LuhdSyQNGuuUqPpzFxduIHmdweOD.hSabLTULPhLufVUYuiWGZoxxaFxm(this.PssdVhgihfxSSsOlqFEigtLgkZFIb.slhAWVVynuDdrqbdGKDoRVmsCDYo, callback, controllerType);
			}

			// Token: 0x0600104B RID: 4171 RVA: 0x0000E7D3 File Offset: 0x0000C9D3
			public void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback)
			{
				if (!ReInput.isReady)
				{
					return;
				}
				if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
				{
					ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
					return;
				}
				this.PssdVhgihfxSSsOlqFEigtLgkZFIb.LuhdSyQNGuuUqPpzFxduIHmdweOD.TmEUhRTxWLbjlIzlQghfhnduHtCU(this.PssdVhgihfxSSsOlqFEigtLgkZFIb.slhAWVVynuDdrqbdGKDoRVmsCDYo, callback);
			}

			// Token: 0x0600104C RID: 4172 RVA: 0x00059240 File Offset: 0x00057440
			public void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (!ReInput.isReady)
				{
					return;
				}
				if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
				{
					ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
					return;
				}
				this.PssdVhgihfxSSsOlqFEigtLgkZFIb.LuhdSyQNGuuUqPpzFxduIHmdweOD.RRnqvcihuSGtfLtfSLytLxXpwcIA(this.PssdVhgihfxSSsOlqFEigtLgkZFIb.slhAWVVynuDdrqbdGKDoRVmsCDYo, callback, controllerType);
			}

			// Token: 0x0600104D RID: 4173 RVA: 0x0000E813 File Offset: 0x0000CA13
			public void ClearLastActiveControllerChangedDelegates()
			{
				if (!ReInput.isReady)
				{
					return;
				}
				if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
				{
					ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
					return;
				}
				this.PssdVhgihfxSSsOlqFEigtLgkZFIb.LuhdSyQNGuuUqPpzFxduIHmdweOD.YxMDeBOfdjgbTgaGqbbZQXjDZBbC(this.PssdVhgihfxSSsOlqFEigtLgkZFIb.slhAWVVynuDdrqbdGKDoRVmsCDYo);
			}

			// Token: 0x0600104E RID: 4174 RVA: 0x0005928C File Offset: 0x0005748C
			public Controller GetFirstControllerWithTemplate(Guid templateTypeGuid)
			{
				if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
				{
					ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
					return null;
				}
				int ePoqkUtmPVaqcSRQDEsmWDfPnprd = this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.ePoqkUtmPVaqcSRQDEsmWDfPnprd;
				for (int i = 0; i < ePoqkUtmPVaqcSRQDEsmWDfPnprd; i++)
				{
					Controller controller = this.njMATKPVWahGDwWqhUsrQqcpzClw<Guid>(this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.CtGoIeauMpKsCXqilTCeQCxqyY(i).YqJDvHgFHfvJYikSetxahzcXYAWHA, Controller.ZJwltezfazRoTpkEJonhGGDtHmYEA, templateTypeGuid);
					if (controller != null)
					{
						return controller;
					}
				}
				return null;
			}

			// Token: 0x0600104F RID: 4175 RVA: 0x000592F0 File Offset: 0x000574F0
			public Controller GetFirstControllerWithTemplate(Type templateType)
			{
				if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
				{
					ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
					return null;
				}
				int ePoqkUtmPVaqcSRQDEsmWDfPnprd = this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.ePoqkUtmPVaqcSRQDEsmWDfPnprd;
				for (int i = 0; i < ePoqkUtmPVaqcSRQDEsmWDfPnprd; i++)
				{
					Controller controller = this.njMATKPVWahGDwWqhUsrQqcpzClw<Type>(this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.CtGoIeauMpKsCXqilTCeQCxqyY(i).YqJDvHgFHfvJYikSetxahzcXYAWHA, Controller.aecobxgkEHTCBoBDiiBBgDDakTvJA, templateType);
					if (controller != null)
					{
						return controller;
					}
				}
				return null;
			}

			// Token: 0x06001050 RID: 4176 RVA: 0x0000E852 File Offset: 0x0000CA52
			public Controller GetFirstControllerWithTemplate<T>() where T : class
			{
				return this.GetFirstControllerWithTemplate(typeof(T));
			}

			// Token: 0x06001051 RID: 4177 RVA: 0x0000E864 File Offset: 0x0000CA64
			public IList<TInterface> GetControllerTemplates<TInterface>() where TInterface : IControllerTemplate
			{
				if (ReInput._id != this.MIPUxAHdABBOEwtyfTUSosHIROxn)
				{
					ReInput.CheckInitialized(this.MIPUxAHdABBOEwtyfTUSosHIROxn);
					return EmptyObjects<TInterface>.EmptyReadOnlyIListT;
				}
				return this.eyxqhzrAGWgJpPTqGJLkcKwcLRcb.FfJfewQUzyHPsLUFqdkzTuUdQThm<TInterface>();
			}

			// Token: 0x06001052 RID: 4178 RVA: 0x00059354 File Offset: 0x00057554
			private Controller njMATKPVWahGDwWqhUsrQqcpzClw<\u0001>(ControllerType A_1, Func<Controller, \u0001, bool> A_2, \u0001 A_3)
			{
				switch (A_1)
				{
				case ControllerType.Keyboard:
					if (this.pfJEVdWSPRUAULafKDQwbutdUTgK && A_2(this.Keyboard, A_3))
					{
						return this.Keyboard;
					}
					return null;
				case ControllerType.Mouse:
					if (this.XBolbQiDSdCaKCpMixItUgVeDfkAb && A_2(this.Mouse, A_3))
					{
						return this.Mouse;
					}
					return null;
				case ControllerType.Joystick:
				{
					int joystickCount = this.joystickCount;
					IList<Joystick> joysticks = this.Joysticks;
					for (int i = 0; i < joystickCount; i++)
					{
						if (A_2(joysticks[i], A_3))
						{
							return joysticks[i];
						}
					}
					return null;
				}
				default:
				{
					if (A_1 != ControllerType.Custom)
					{
						throw new NotImplementedException();
					}
					int customControllerCount = this.customControllerCount;
					IList<CustomController> customControllers = this.CustomControllers;
					for (int j = 0; j < customControllerCount; j++)
					{
						if (A_2(customControllers[j], A_3))
						{
							return customControllers[j];
						}
					}
					return null;
				}
				}
			}

			// Token: 0x06001053 RID: 4179 RVA: 0x00059434 File Offset: 0x00057634
			internal void EYUpqVTlEOXQBXHqvgqHaLWgmVll()
			{
				for (int i = 0; i < this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.ePoqkUtmPVaqcSRQDEsmWDfPnprd; i++)
				{
					this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.CtGoIeauMpKsCXqilTCeQCxqyY(i).izaQsiOxyWlYEixsJcHFbgGchzEA();
				}
				this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(ControllerType.Keyboard).IzYGrObDjVkjIdGRCklKKIDTLJItA(new Player<Keyboard, KeyboardMap>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi.gkFtqSotlvjTxqHWDAWBgsGdsVUL(ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.TaTrTHwUgSOiWrsYvUpTqAIgrPne, new VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<KeyboardMap>(0)));
				this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(ControllerType.Mouse).IzYGrObDjVkjIdGRCklKKIDTLJItA(new Player<Mouse, MouseMap>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi.gkFtqSotlvjTxqHWDAWBgsGdsVUL(ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.XNgqEHDojgJjHnQkfggodEGufgWj, new VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<MouseMap>(0)));
				this.BhYmddYjQBpTYSjebSXDXGRpyVFj.QxodsmJXvOGNjwtMOItjyZTjpPxaA();
				this.aNGZibrTsnPalUSPlVaHoBlevpoT = 0.0;
				this.aXPkROCyXVClsoJGDtGgsQjzwefb = 0.0;
				this.maps.XiKuVCsnqmDYXfPkWvRSrgnzyINFA();
			}

			// Token: 0x06001054 RID: 4180 RVA: 0x000594E8 File Offset: 0x000576E8
			internal double qxSrkVvSCvgYILRCONorjaDykjsj(int A_1)
			{
				Player.ControllerHelper.qIXNxngxvPnyUKiwJbWeyVtlOaCm.SBUTVOjkKRydKuamilavnmYyifhN sbutvojkKRydKuamilavnmYyifhN = this.BhYmddYjQBpTYSjebSXDXGRpyVFj.HSqSKFnVLMcRvAiAIrBvIaPWUIKw(A_1);
				if (sbutvojkKRydKuamilavnmYyifhN == null)
				{
					return -1.0;
				}
				return sbutvojkKRydKuamilavnmYyifhN.eihGLCkYTaYNHHQZjpkfODUzbLTCb;
			}

			// Token: 0x06001055 RID: 4181 RVA: 0x00059518 File Offset: 0x00057718
			internal void tDAgZZdWZkhWALHWlMkKACBYvIMxA(Joystick A_1, bool A_2)
			{
				if (A_1 == null)
				{
					return;
				}
				Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(ControllerType.Joystick);
				if (rrrUVbResWNdbXKvkkOIseeimvIu.MouplaShCfFxRczQNCMHkYFFsxzk(A_1.id))
				{
					return;
				}
				if (A_2)
				{
					ReInput.controllers.RemoveJoystickFromAllPlayers(A_1, true);
				}
				Player.ControllerHelper.qIXNxngxvPnyUKiwJbWeyVtlOaCm.SBUTVOjkKRydKuamilavnmYyifhN sbutvojkKRydKuamilavnmYyifhN = this.BhYmddYjQBpTYSjebSXDXGRpyVFj.HSqSKFnVLMcRvAiAIrBvIaPWUIKw(A_1.id);
				Player<Joystick, JoystickMap>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi.gkFtqSotlvjTxqHWDAWBgsGdsVUL gkFtqSotlvjTxqHWDAWBgsGdsVUL;
				if (sbutvojkKRydKuamilavnmYyifhN != null && sbutvojkKRydKuamilavnmYyifhN.XqDcLyUoffRXyNWIyZaySFVCatgy != null)
				{
					gkFtqSotlvjTxqHWDAWBgsGdsVUL = new Player<Joystick, JoystickMap>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi.gkFtqSotlvjTxqHWDAWBgsGdsVUL(A_1, sbutvojkKRydKuamilavnmYyifhN.XqDcLyUoffRXyNWIyZaySFVCatgy);
				}
				else
				{
					VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<JoystickMap> vgBeEuhSJyCTDoLCtPBvlHeZIRyMA = this.maps.ViyQaJeqNNxJlRiSfxlXBUJceWFw(A_1, true);
					if (vgBeEuhSJyCTDoLCtPBvlHeZIRyMA == null)
					{
						vgBeEuhSJyCTDoLCtPBvlHeZIRyMA = new VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<JoystickMap>(A_1.id);
					}
					gkFtqSotlvjTxqHWDAWBgsGdsVUL = new Player<Joystick, JoystickMap>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi.gkFtqSotlvjTxqHWDAWBgsGdsVUL(A_1, vgBeEuhSJyCTDoLCtPBvlHeZIRyMA);
				}
				rrrUVbResWNdbXKvkkOIseeimvIu.IzYGrObDjVkjIdGRCklKKIDTLJItA(gkFtqSotlvjTxqHWDAWBgsGdsVUL);
				this.BhYmddYjQBpTYSjebSXDXGRpyVFj.UMdBTMWAvxdMLLijvRbZwPbrsvr(gkFtqSotlvjTxqHWDAWBgsGdsVUL);
				this.eyxqhzrAGWgJpPTqGJLkcKwcLRcb.zasBhsaAvoJpxZfKGoCjaYtFpigYB(A_1);
				this.maps.layoutManager.Apply();
				if (this.psXJPGhJHrnEtgaAhCUhBtZVmLssA.Count > 0)
				{
					this.psXJPGhJHrnEtgaAhCUhBtZVmLssA.Invoke(new ControllerAssignmentChangedEventArgs(this.PssdVhgihfxSSsOlqFEigtLgkZFIb.id, A_1.id, ControllerType.Joystick, true));
				}
			}

			// Token: 0x06001056 RID: 4182 RVA: 0x00059608 File Offset: 0x00057808
			internal void FjhTSIfWwYBtprKveEXlTTCLtnOd(int A_1, bool A_2)
			{
				Joystick joystick = ReInput.controllers.GetJoystick(A_1);
				if (joystick == null)
				{
					return;
				}
				this.tDAgZZdWZkhWALHWlMkKACBYvIMxA(joystick, A_2);
			}

			// Token: 0x06001057 RID: 4183 RVA: 0x00059630 File Offset: 0x00057830
			internal void hDhwfOYWVKMQYXHiWylsHIBvDwRn(int A_1)
			{
				Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(ControllerType.Joystick);
				if (!rrrUVbResWNdbXKvkkOIseeimvIu.MouplaShCfFxRczQNCMHkYFFsxzk(A_1))
				{
					return;
				}
				Player<Joystick, JoystickMap>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi.gkFtqSotlvjTxqHWDAWBgsGdsVUL gkFtqSotlvjTxqHWDAWBgsGdsVUL = rrrUVbResWNdbXKvkkOIseeimvIu.cLCIFSrSsIdpuGCXMXmeTmizjypZ(A_1) as Player<Joystick, JoystickMap>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi.gkFtqSotlvjTxqHWDAWBgsGdsVUL;
				if (gkFtqSotlvjTxqHWDAWBgsGdsVUL != null)
				{
					this.BhYmddYjQBpTYSjebSXDXGRpyVFj.UMdBTMWAvxdMLLijvRbZwPbrsvr(gkFtqSotlvjTxqHWDAWBgsGdsVUL);
				}
				rrrUVbResWNdbXKvkkOIseeimvIu.zIQhlCMPSQSndGAHGFJypOxttTbY(A_1);
				Joystick joystick = ReInput.controllers.GetJoystick(A_1);
				this.eyxqhzrAGWgJpPTqGJLkcKwcLRcb.QvDjjGLIVKsQuJmOzAqldvnCtsBH(joystick);
				if (this.XANDlQbPZMPExfbfmwyntrCXdNgHA.Count > 0)
				{
					this.XANDlQbPZMPExfbfmwyntrCXdNgHA.Invoke(new ControllerAssignmentChangedEventArgs(this.PssdVhgihfxSSsOlqFEigtLgkZFIb.id, joystick.id, ControllerType.Joystick, false));
				}
			}

			// Token: 0x06001058 RID: 4184 RVA: 0x0000E890 File Offset: 0x0000CA90
			internal void ARpcVSpEarBEKjFbBWSySbFNiYfM(Joystick A_1)
			{
				if (A_1 == null)
				{
					return;
				}
				this.hDhwfOYWVKMQYXHiWylsHIBvDwRn(A_1.id);
			}

			// Token: 0x06001059 RID: 4185 RVA: 0x000596C0 File Offset: 0x000578C0
			internal void VvrUVIZrMSwcFDpCXdWTAzeEjVhKA()
			{
				Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(ControllerType.Joystick);
				for (int i = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL - 1; i >= 0; i--)
				{
					this.BhYmddYjQBpTYSjebSXDXGRpyVFj.UMdBTMWAvxdMLLijvRbZwPbrsvr(rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i) as Player<Joystick, JoystickMap>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi.gkFtqSotlvjTxqHWDAWBgsGdsVUL);
					this.eyxqhzrAGWgJpPTqGJLkcKwcLRcb.QvDjjGLIVKsQuJmOzAqldvnCtsBH(rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).PBJHfnhJKAlWfSVgUYDoQBOBahDP);
					int id = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).PBJHfnhJKAlWfSVgUYDoQBOBahDP.id;
					rrrUVbResWNdbXKvkkOIseeimvIu.ItkdmbguvOkrtbCyCIuXaTmsQPPYB(i);
					if (this.XANDlQbPZMPExfbfmwyntrCXdNgHA.Count > 0)
					{
						this.XANDlQbPZMPExfbfmwyntrCXdNgHA.Invoke(new ControllerAssignmentChangedEventArgs(this.PssdVhgihfxSSsOlqFEigtLgkZFIb.id, id, ControllerType.Joystick, false));
					}
				}
				rrrUVbResWNdbXKvkkOIseeimvIu.izaQsiOxyWlYEixsJcHFbgGchzEA();
			}

			// Token: 0x0600105A RID: 4186 RVA: 0x00059768 File Offset: 0x00057968
			internal void kxwIeJTjxOkmVbqsvaSqCGtGUKAY(CustomController A_1, bool A_2)
			{
				if (A_1 == null)
				{
					return;
				}
				Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(ControllerType.Custom);
				if (rrrUVbResWNdbXKvkkOIseeimvIu.MouplaShCfFxRczQNCMHkYFFsxzk(A_1.id))
				{
					return;
				}
				if (A_2)
				{
					ReInput.controllers.RemoveCustomControllerFromAllPlayers(A_1, true);
				}
				VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<CustomControllerMap> vgBeEuhSJyCTDoLCtPBvlHeZIRyMA = this.maps.qsVeTKZjyPunOJuJLmdGtXkPIAMM(A_1, true);
				if (vgBeEuhSJyCTDoLCtPBvlHeZIRyMA == null)
				{
					vgBeEuhSJyCTDoLCtPBvlHeZIRyMA = new VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<CustomControllerMap>(A_1.id);
				}
				Player<CustomController, CustomControllerMap>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi.gkFtqSotlvjTxqHWDAWBgsGdsVUL gkFtqSotlvjTxqHWDAWBgsGdsVUL = new Player<CustomController, CustomControllerMap>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi.gkFtqSotlvjTxqHWDAWBgsGdsVUL(A_1, vgBeEuhSJyCTDoLCtPBvlHeZIRyMA);
				rrrUVbResWNdbXKvkkOIseeimvIu.IzYGrObDjVkjIdGRCklKKIDTLJItA(gkFtqSotlvjTxqHWDAWBgsGdsVUL);
				this.eyxqhzrAGWgJpPTqGJLkcKwcLRcb.zasBhsaAvoJpxZfKGoCjaYtFpigYB(A_1);
				this.maps.layoutManager.Apply();
				if (this.psXJPGhJHrnEtgaAhCUhBtZVmLssA.Count > 0)
				{
					this.psXJPGhJHrnEtgaAhCUhBtZVmLssA.Invoke(new ControllerAssignmentChangedEventArgs(this.PssdVhgihfxSSsOlqFEigtLgkZFIb.id, A_1.id, ControllerType.Custom, true));
				}
			}

			// Token: 0x0600105B RID: 4187 RVA: 0x00059820 File Offset: 0x00057A20
			internal void esIrlgcTMJDmfgTOEKgeMgYkMlzJ(int A_1, bool A_2)
			{
				CustomController customController = ReInput.controllers.GetCustomController(A_1);
				if (customController == null)
				{
					return;
				}
				this.kxwIeJTjxOkmVbqsvaSqCGtGUKAY(customController, A_2);
			}

			// Token: 0x0600105C RID: 4188 RVA: 0x00059848 File Offset: 0x00057A48
			internal void PzcBXrzCKvEvfPaLHxuIkAIqFiQq(int A_1)
			{
				Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(ControllerType.Custom);
				if (!rrrUVbResWNdbXKvkkOIseeimvIu.MouplaShCfFxRczQNCMHkYFFsxzk(A_1))
				{
					return;
				}
				rrrUVbResWNdbXKvkkOIseeimvIu.cLCIFSrSsIdpuGCXMXmeTmizjypZ(A_1);
				rrrUVbResWNdbXKvkkOIseeimvIu.zIQhlCMPSQSndGAHGFJypOxttTbY(A_1);
				CustomController customController = ReInput.controllers.GetCustomController(A_1);
				this.eyxqhzrAGWgJpPTqGJLkcKwcLRcb.QvDjjGLIVKsQuJmOzAqldvnCtsBH(customController);
				if (this.XANDlQbPZMPExfbfmwyntrCXdNgHA.Count > 0)
				{
					this.XANDlQbPZMPExfbfmwyntrCXdNgHA.Invoke(new ControllerAssignmentChangedEventArgs(this.PssdVhgihfxSSsOlqFEigtLgkZFIb.id, customController.id, ControllerType.Custom, false));
				}
			}

			// Token: 0x0600105D RID: 4189 RVA: 0x0000E8A2 File Offset: 0x0000CAA2
			internal void mrEeOPDTcljdFyiTyOYQbldchzEJB(CustomController A_1)
			{
				if (A_1 == null)
				{
					return;
				}
				this.PzcBXrzCKvEvfPaLHxuIkAIqFiQq(A_1.id);
			}

			// Token: 0x0600105E RID: 4190 RVA: 0x000598C8 File Offset: 0x00057AC8
			internal void uGjdhWePboDlOHwICvTwhPXXfvBLB()
			{
				Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(ControllerType.Custom);
				for (int i = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL - 1; i >= 0; i--)
				{
					this.eyxqhzrAGWgJpPTqGJLkcKwcLRcb.QvDjjGLIVKsQuJmOzAqldvnCtsBH(rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).PBJHfnhJKAlWfSVgUYDoQBOBahDP);
					int id = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).PBJHfnhJKAlWfSVgUYDoQBOBahDP.id;
					rrrUVbResWNdbXKvkkOIseeimvIu.ItkdmbguvOkrtbCyCIuXaTmsQPPYB(i);
					if (this.XANDlQbPZMPExfbfmwyntrCXdNgHA.Count > 0)
					{
						this.XANDlQbPZMPExfbfmwyntrCXdNgHA.Invoke(new ControllerAssignmentChangedEventArgs(this.PssdVhgihfxSSsOlqFEigtLgkZFIb.id, id, ControllerType.Custom, false));
					}
				}
				rrrUVbResWNdbXKvkkOIseeimvIu.izaQsiOxyWlYEixsJcHFbgGchzEA();
			}

			// Token: 0x0600105F RID: 4191 RVA: 0x0005995C File Offset: 0x00057B5C
			internal CustomController kGajxjhOcpkeRoXoOfPNpDiQBScAA(int A_1)
			{
				CustomController customController = this.PssdVhgihfxSSsOlqFEigtLgkZFIb.LuhdSyQNGuuUqPpzFxduIHmdweOD.GtyAkWaziVlXmbaLqdOfAXlIROxMA(A_1);
				if (customController == null)
				{
					return null;
				}
				this.kxwIeJTjxOkmVbqsvaSqCGtGUKAY(customController, false);
				return customController;
			}

			// Token: 0x06001060 RID: 4192 RVA: 0x0000E8B4 File Offset: 0x0000CAB4
			internal void fcfYFvtvyNgMwmCuwTafAZghMTMA(Action<bool, int, int> A_1)
			{
				this.LwxKxMyPBshXakawITAsqViPFIvF<Joystick, JoystickMap>(ControllerType.Joystick, A_1);
			}

			// Token: 0x06001061 RID: 4193 RVA: 0x0005998C File Offset: 0x00057B8C
			internal void YlAbzLhIKpIkDaPbkjtLweTSwfkbc(Keyboard A_1, mEYbmhkubQXyWLdHdBzRRGwWDmxeb A_2, Action<bool, int, int> A_3)
			{
				if (!this.pfJEVdWSPRUAULafKDQwbutdUTgK || !A_1.enabled)
				{
					return;
				}
				JataafgUmrvbnTlMuiLhrcBTEPfd dgjVhstXQWqvCxiamNQKKHhbOocL = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.DgjVhstXQWqvCxiamNQKKHhbOocL;
				bool flag = false;
				dBWjOjXnFJmUROzCVhQpynliVgPI dBWjOjXnFJmUROzCVhQpynliVgPI = this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(ControllerType.Keyboard).cLCIFSrSsIdpuGCXMXmeTmizjypZ(0).AxzIHFaeuZajYboPHuvsfCYAXoQwA;
				int num = dBWjOjXnFJmUROzCVhQpynliVgPI.sSEkNHPvFzDptlNqDocRnDXFEYyY;
				KeyCombinationOverrideMode keyCombinationOverrideMode = ReInput.configVars.keyCombinationOverrideMode;
				bool flag2 = keyCombinationOverrideMode == KeyCombinationOverrideMode.None;
				mEYbmhkubQXyWLdHdBzRRGwWDmxeb.FOSlyratSZQvXdCFcHZgAztlltClA foslyratSZQvXdCFcHZgAztlltClA = (keyCombinationOverrideMode == KeyCombinationOverrideMode.Overlap) ? mEYbmhkubQXyWLdHdBzRRGwWDmxeb.FOSlyratSZQvXdCFcHZgAztlltClA.OverlapModifiers : mEYbmhkubQXyWLdHdBzRRGwWDmxeb.FOSlyratSZQvXdCFcHZgAztlltClA.Normal;
				IOidQPQHzktCEcGgopnxdsRDcvvq.yzyMVcieauXZKOhYryvnItUhAnYh yzyMVcieauXZKOhYryvnItUhAnYh = new IOidQPQHzktCEcGgopnxdsRDcvvq.yzyMVcieauXZKOhYryvnItUhAnYh
				{
					CXvafSaOEzRMTgVXHSbjnsZDNnriB = ReInput.configVars.generateKeyEventsOnKeyCombinationOverride
				};
				for (int i = 0; i < num; i++)
				{
					KeyboardMap keyboardMap = (KeyboardMap)dBWjOjXnFJmUROzCVhQpynliVgPI.kpSXGnRVLDEHUvJSffrGHSOpEAHGb(i);
					if (keyboardMap.enabled)
					{
						AList<ActionElementMap> alist = keyboardMap.DWkEfFJRIhxezCgjNNPhQPxZoAPO;
						int count = alist._count;
						for (int j = 0; j < count; j++)
						{
							ActionElementMap actionElementMap = alist._items[j];
							if (actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA)
							{
								int actionId = actionElementMap._actionId;
								KeyboardKeyCode keyboardKeyCode = actionElementMap._keyboardKeyCode;
								ModifierKeyFlags modifierKeyFlags = actionElementMap.modifierKeyFlags;
								bool flag3 = false;
								bool flag4 = false;
								ButtonStateFlags buttonStateFlags;
								bool flag5;
								if (modifierKeyFlags != ModifierKeyFlags.None)
								{
									buttonStateFlags = (A_1.dokynBuAaDKzLWczKTaNWvdpJtZF(keyboardKeyCode, modifierKeyFlags) ? ButtonStateFlags.On : ButtonStateFlags.Off);
									flag5 = (buttonStateFlags > ButtonStateFlags.Off);
									if (!flag5)
									{
										IOidQPQHzktCEcGgopnxdsRDcvvq oidQPQHzktCEcGgopnxdsRDcvvq = IOidQPQHzktCEcGgopnxdsRDcvvq.fBxxvWULGzkXnualagAPHOewqlZhb(actionElementMap.pGMbotKVdjNowDvSSfgThIWDmLSHB);
										if (oidQPQHzktCEcGgopnxdsRDcvvq != null && oidQPQHzktCEcGgopnxdsRDcvvq.haEHqwIqltOagmdIACNqFKZYJluu(true) != ButtonStateFlags.Off)
										{
											flag5 = true;
										}
									}
								}
								else
								{
									buttonStateFlags = A_1.tdcTLdcmxAGwPEpXWnaBGUvEHgCJb(actionElementMap.mRCBQDgzARDPVbNsvhiBadcDxEwTB);
									flag5 = (buttonStateFlags > ButtonStateFlags.Off);
								}
								if (flag5)
								{
									if (!flag2)
									{
										flag3 = A_2.IMTFqCcQBQVQylvrJbOpyhZVZXgJA(keyboardKeyCode, modifierKeyFlags, foslyratSZQvXdCFcHZgAztlltClA, out flag4);
									}
									if (flag4 || modifierKeyFlags != ModifierKeyFlags.None)
									{
										yzyMVcieauXZKOhYryvnItUhAnYh.TYrbguQiWwdHcaDzNPuepAANDGDLA = flag3;
										IOidQPQHzktCEcGgopnxdsRDcvvq oidQPQHzktCEcGgopnxdsRDcvvq = IOidQPQHzktCEcGgopnxdsRDcvvq.XibdfdZtlUwXUUgolpKbbUHaRmsf(actionElementMap.pGMbotKVdjNowDvSSfgThIWDmLSHB, yzyMVcieauXZKOhYryvnItUhAnYh);
										if (keyCombinationOverrideMode == KeyCombinationOverrideMode.Pause)
										{
											oidQPQHzktCEcGgopnxdsRDcvvq.uvxBnQeySDArbAXNXxLweTFzzOtz = flag3;
										}
										else if (flag3)
										{
											oidQPQHzktCEcGgopnxdsRDcvvq.uvxBnQeySDArbAXNXxLweTFzzOtz = true;
										}
										oidQPQHzktCEcGgopnxdsRDcvvq.FTlPMNbsUpmWiGYcvIEUTdXQbpDgA(ReInput.currentUpdateLoop, buttonStateFlags, true);
										buttonStateFlags = oidQPQHzktCEcGgopnxdsRDcvvq.haEHqwIqltOagmdIACNqFKZYJluu(true);
									}
								}
								if (buttonStateFlags != ButtonStateFlags.Off)
								{
									Player.ControllerHelper.VERgCuARBiKREeeYXNFsuIezKsFX(A_1, keyboardMap, actionElementMap, dgjVhstXQWqvCxiamNQKKHhbOocL, buttonStateFlags);
									A_3(true, this.PssdVhgihfxSSsOlqFEigtLgkZFIb.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId);
									flag = true;
								}
								else
								{
									if (dgjVhstXQWqvCxiamNQKKHhbOocL.utdxJIHkatoxBldAvWBbZTVbaFcl != 0f)
									{
										dgjVhstXQWqvCxiamNQKKHhbOocL.utdxJIHkatoxBldAvWBbZTVbaFcl = 0f;
									}
									if (dgjVhstXQWqvCxiamNQKKHhbOocL.eyvxnJpMZeEZcENTKtcvIFJLyWAO != ButtonStateFlags.Off)
									{
										dgjVhstXQWqvCxiamNQKKHhbOocL.eyvxnJpMZeEZcENTKtcvIFJLyWAO = ButtonStateFlags.Off;
									}
									A_3(false, this.PssdVhgihfxSSsOlqFEigtLgkZFIb.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId);
								}
							}
						}
					}
				}
				if (flag)
				{
					this.aNGZibrTsnPalUSPlVaHoBlevpoT = ReInput.unscaledTime;
				}
			}

			// Token: 0x06001062 RID: 4194 RVA: 0x00059BD8 File Offset: 0x00057DD8
			private static void VERgCuARBiKREeeYXNFsuIezKsFX(Keyboard A_0, ControllerMap A_1, ActionElementMap A_2, JataafgUmrvbnTlMuiLhrcBTEPfd A_3, ButtonStateFlags A_4)
			{
				float num = ((A_4 & ButtonStateFlags.On) != ButtonStateFlags.Off) ? 1f : 0f;
				if (num != 0f && A_2._axisContribution == Pole.Negative)
				{
					num *= -1f;
				}
				A_3.utdxJIHkatoxBldAvWBbZTVbaFcl = num;
				A_3.eyvxnJpMZeEZcENTKtcvIFJLyWAO = A_4;
				A_3.xadwTlbiqMnQJKpkbwcTSEJqFKyN = A_0;
				A_3.NgcWpJIBgJyvJEPNRloRpkQSpiZk = ControllerType.Keyboard;
				A_3.xqKIdHbHXOEZvhWKNQasyVhQmkIA = ControllerElementType.Button;
				A_3.jMEqHZPiCdPoKLgzvxltMnUhaoSH = A_2;
				A_3.wwVloXlzGdiPzMmaSrTJsEEKVkzC = A_1;
				if (A_3.rNmnzBBvEKYTVyjrVykrUlpZDyAc)
				{
					A_3.rNmnzBBvEKYTVyjrVykrUlpZDyAc = false;
				}
				if (A_3.ZAGAxVhJMnqlgFyZHfBZxpIAGWyn)
				{
					A_3.ZAGAxVhJMnqlgFyZHfBZxpIAGWyn = false;
				}
			}

			// Token: 0x06001063 RID: 4195 RVA: 0x00059C64 File Offset: 0x00057E64
			internal void UEyYnwOYSlFKXyqeDJDmUdNaPrf(Mouse A_1, Action<bool, int, int> A_2)
			{
				if (!this.XBolbQiDSdCaKCpMixItUgVeDfkAb || !A_1.enabled)
				{
					return;
				}
				dBWjOjXnFJmUROzCVhQpynliVgPI dBWjOjXnFJmUROzCVhQpynliVgPI = this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(ControllerType.Mouse).cLCIFSrSsIdpuGCXMXmeTmizjypZ(0).AxzIHFaeuZajYboPHuvsfCYAXoQwA;
				JataafgUmrvbnTlMuiLhrcBTEPfd dgjVhstXQWqvCxiamNQKKHhbOocL = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.DgjVhstXQWqvCxiamNQKKHhbOocL;
				bool flag = false;
				int num = dBWjOjXnFJmUROzCVhQpynliVgPI.sSEkNHPvFzDptlNqDocRnDXFEYyY;
				for (int i = 0; i < num; i++)
				{
					MouseMap mouseMap = (MouseMap)dBWjOjXnFJmUROzCVhQpynliVgPI.kpSXGnRVLDEHUvJSffrGHSOpEAHGb(i);
					if (mouseMap.enabled)
					{
						AList<ActionElementMap> alist = mouseMap.ltItJCWElJbkLlrjlhWQQWOGEYDq;
						if (alist != null)
						{
							int count = alist._count;
							for (int j = 0; j < count; j++)
							{
								ActionElementMap actionElementMap = alist._items[j];
								if (actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA && actionElementMap._elementType == ControllerElementType.Axis)
								{
									int actionId = actionElementMap._actionId;
									float num2;
									if (A_1.tsUovSoTtpHiriVRiTsSXWemlOhi(actionElementMap, actionId, true, false, out num2))
									{
										if (num2 == 0f)
										{
											float num3;
											A_1.tsUovSoTtpHiriVRiTsSXWemlOhi(actionElementMap, actionId, true, true, out num3);
											if (num3 == 0f)
											{
												A_2(false, this.PssdVhgihfxSSsOlqFEigtLgkZFIb.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId);
												goto IL_155;
											}
										}
										dgjVhstXQWqvCxiamNQKKHhbOocL.utdxJIHkatoxBldAvWBbZTVbaFcl = num2;
										dgjVhstXQWqvCxiamNQKKHhbOocL.xadwTlbiqMnQJKpkbwcTSEJqFKyN = A_1;
										dgjVhstXQWqvCxiamNQKKHhbOocL.NgcWpJIBgJyvJEPNRloRpkQSpiZk = ControllerType.Mouse;
										dgjVhstXQWqvCxiamNQKKHhbOocL.xqKIdHbHXOEZvhWKNQasyVhQmkIA = ControllerElementType.Axis;
										dgjVhstXQWqvCxiamNQKKHhbOocL.jMEqHZPiCdPoKLgzvxltMnUhaoSH = actionElementMap;
										dgjVhstXQWqvCxiamNQKKHhbOocL.wwVloXlzGdiPzMmaSrTJsEEKVkzC = mouseMap;
										if (dgjVhstXQWqvCxiamNQKKHhbOocL.ZAGAxVhJMnqlgFyZHfBZxpIAGWyn)
										{
											dgjVhstXQWqvCxiamNQKKHhbOocL.ZAGAxVhJMnqlgFyZHfBZxpIAGWyn = false;
										}
										if (dgjVhstXQWqvCxiamNQKKHhbOocL.nrfSpYJvAcmHkgaNAZuHtaMYillV != AxisCoordinateMode.Relative)
										{
											dgjVhstXQWqvCxiamNQKKHhbOocL.nrfSpYJvAcmHkgaNAZuHtaMYillV = AxisCoordinateMode.Relative;
										}
										A_2(true, this.PssdVhgihfxSSsOlqFEigtLgkZFIb.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId);
										flag = true;
									}
								}
								IL_155:;
							}
						}
						AList<ActionElementMap> alist2 = mouseMap.DWkEfFJRIhxezCgjNNPhQPxZoAPO;
						if (alist2 != null)
						{
							int count2 = alist2._count;
							for (int k = 0; k < count2; k++)
							{
								ActionElementMap actionElementMap2 = alist2._items[k];
								if (actionElementMap2.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA && actionElementMap2._elementType == ControllerElementType.Button)
								{
									int actionId2 = actionElementMap2._actionId;
									float utdxJIHkatoxBldAvWBbZTVbaFcl;
									if (A_1.DQVOuVYkGTobkZcfIdCHMiklaaiH(actionElementMap2, actionId2, out utdxJIHkatoxBldAvWBbZTVbaFcl, out dgjVhstXQWqvCxiamNQKKHhbOocL.rNmnzBBvEKYTVyjrVykrUlpZDyAc))
									{
										ButtonStateFlags buttonStateFlags = A_1.tdcTLdcmxAGwPEpXWnaBGUvEHgCJb(actionElementMap2.mRCBQDgzARDPVbNsvhiBadcDxEwTB);
										if (buttonStateFlags == ButtonStateFlags.Off)
										{
											A_2(false, this.PssdVhgihfxSSsOlqFEigtLgkZFIb.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId2);
										}
										else
										{
											dgjVhstXQWqvCxiamNQKKHhbOocL.utdxJIHkatoxBldAvWBbZTVbaFcl = utdxJIHkatoxBldAvWBbZTVbaFcl;
											dgjVhstXQWqvCxiamNQKKHhbOocL.eyvxnJpMZeEZcENTKtcvIFJLyWAO = buttonStateFlags;
											dgjVhstXQWqvCxiamNQKKHhbOocL.xadwTlbiqMnQJKpkbwcTSEJqFKyN = A_1;
											dgjVhstXQWqvCxiamNQKKHhbOocL.NgcWpJIBgJyvJEPNRloRpkQSpiZk = ControllerType.Mouse;
											dgjVhstXQWqvCxiamNQKKHhbOocL.xqKIdHbHXOEZvhWKNQasyVhQmkIA = ControllerElementType.Button;
											dgjVhstXQWqvCxiamNQKKHhbOocL.jMEqHZPiCdPoKLgzvxltMnUhaoSH = actionElementMap2;
											dgjVhstXQWqvCxiamNQKKHhbOocL.wwVloXlzGdiPzMmaSrTJsEEKVkzC = mouseMap;
											if (dgjVhstXQWqvCxiamNQKKHhbOocL.rNmnzBBvEKYTVyjrVykrUlpZDyAc)
											{
												dgjVhstXQWqvCxiamNQKKHhbOocL.rNmnzBBvEKYTVyjrVykrUlpZDyAc = false;
											}
											if (dgjVhstXQWqvCxiamNQKKHhbOocL.ZAGAxVhJMnqlgFyZHfBZxpIAGWyn)
											{
												dgjVhstXQWqvCxiamNQKKHhbOocL.ZAGAxVhJMnqlgFyZHfBZxpIAGWyn = false;
											}
											A_2(true, this.PssdVhgihfxSSsOlqFEigtLgkZFIb.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId2);
											flag = true;
										}
									}
								}
							}
						}
					}
				}
				if (flag)
				{
					this.aXPkROCyXVClsoJGDtGgsQjzwefb = ReInput.unscaledTime;
				}
			}

			// Token: 0x06001064 RID: 4196 RVA: 0x0000E8BE File Offset: 0x0000CABE
			internal void OEUZQdUOoJhHDSKzawvsJFgYeyrCA(Action<bool, int, int> A_1)
			{
				this.LwxKxMyPBshXakawITAsqViPFIvF<CustomController, CustomControllerMap>(ControllerType.Custom, A_1);
			}

			// Token: 0x06001065 RID: 4197 RVA: 0x00059EF8 File Offset: 0x000580F8
			private void LwxKxMyPBshXakawITAsqViPFIvF<\u0001, \u0002>(ControllerType A_1, Action<bool, int, int> A_2) where \u0001 : ControllerWithAxes where \u0002 : ControllerMapWithAxes
			{
				Player<\u0001, \u0002>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi njAlpuqmuMmkinJFduspVuiWfiHi = (Player<\u0001, \u0002>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi)this.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
				JataafgUmrvbnTlMuiLhrcBTEPfd dgjVhstXQWqvCxiamNQKKHhbOocL = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.DgjVhstXQWqvCxiamNQKKHhbOocL;
				int num = njAlpuqmuMmkinJFduspVuiWfiHi.hUvoPojtJZIUBnFkCGjslfijGbmL;
				for (int i = 0; i < num; i++)
				{
					Player<\u0001, \u0002>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi.gkFtqSotlvjTxqHWDAWBgsGdsVUL gkFtqSotlvjTxqHWDAWBgsGdsVUL = njAlpuqmuMmkinJFduspVuiWfiHi.qzZhSNqgFLaSMguabDuaPHoOFBwG(i);
					\u0001 vlnBmkNlWHuWGKNvpysrhMLAvwWA = gkFtqSotlvjTxqHWDAWBgsGdsVUL.VLnBmkNlWHuWGKNvpysrhMLAvwWA;
					if (vlnBmkNlWHuWGKNvpysrhMLAvwWA.enabled)
					{
						VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<\u0002> syeOZTgTBzpCRvaSMSDtNBsRaIdX = gkFtqSotlvjTxqHWDAWBgsGdsVUL.SYeOZTgTBzpCRvaSMSDtNBsRaIdX;
						bool flag = false;
						int num2 = syeOZTgTBzpCRvaSMSDtNBsRaIdX.sSEkNHPvFzDptlNqDocRnDXFEYyY;
						for (int j = 0; j < num2; j++)
						{
							\u0002 u = syeOZTgTBzpCRvaSMSDtNBsRaIdX.ZEabTYdmnsjYhGfIgxpgnyvGMRBRA(j);
							if (u.enabled)
							{
								AList<ActionElementMap> alist = u.ltItJCWElJbkLlrjlhWQQWOGEYDq;
								if (alist != null)
								{
									int count = alist._count;
									for (int k = 0; k < count; k++)
									{
										ActionElementMap actionElementMap = alist._items[k];
										if (actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA && actionElementMap._elementType == ControllerElementType.Axis)
										{
											int actionId = actionElementMap._actionId;
											float num3;
											if (vlnBmkNlWHuWGKNvpysrhMLAvwWA.tsUovSoTtpHiriVRiTsSXWemlOhi(actionElementMap, actionId, false, false, out num3))
											{
												if (num3 == 0f)
												{
													float num4;
													vlnBmkNlWHuWGKNvpysrhMLAvwWA.tsUovSoTtpHiriVRiTsSXWemlOhi(actionElementMap, actionId, false, true, out num4);
													if (num4 == 0f)
													{
														A_2(false, this.PssdVhgihfxSSsOlqFEigtLgkZFIb.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId);
														goto IL_1D8;
													}
												}
												dgjVhstXQWqvCxiamNQKKHhbOocL.utdxJIHkatoxBldAvWBbZTVbaFcl = num3;
												dgjVhstXQWqvCxiamNQKKHhbOocL.xadwTlbiqMnQJKpkbwcTSEJqFKyN = vlnBmkNlWHuWGKNvpysrhMLAvwWA;
												dgjVhstXQWqvCxiamNQKKHhbOocL.NgcWpJIBgJyvJEPNRloRpkQSpiZk = A_1;
												dgjVhstXQWqvCxiamNQKKHhbOocL.xqKIdHbHXOEZvhWKNQasyVhQmkIA = ControllerElementType.Axis;
												dgjVhstXQWqvCxiamNQKKHhbOocL.jMEqHZPiCdPoKLgzvxltMnUhaoSH = actionElementMap;
												dgjVhstXQWqvCxiamNQKKHhbOocL.wwVloXlzGdiPzMmaSrTJsEEKVkzC = u;
												dgjVhstXQWqvCxiamNQKKHhbOocL.ZAGAxVhJMnqlgFyZHfBZxpIAGWyn = vlnBmkNlWHuWGKNvpysrhMLAvwWA.calibrationMap.Axes[actionElementMap.mRCBQDgzARDPVbNsvhiBadcDxEwTB].applyRangeCalibration;
												HardwareAxisInfo fzzkLLIistIuAlLCPzLMFEPVKHOk = vlnBmkNlWHuWGKNvpysrhMLAvwWA.Axes[actionElementMap.elementIndex].fzzkLLIistIuAlLCPzLMFEPVKHOk;
												dgjVhstXQWqvCxiamNQKKHhbOocL.nrfSpYJvAcmHkgaNAZuHtaMYillV = ((fzzkLLIistIuAlLCPzLMFEPVKHOk != null) ? fzzkLLIistIuAlLCPzLMFEPVKHOk._dataFormat : AxisCoordinateMode.Absolute);
												A_2(true, this.PssdVhgihfxSSsOlqFEigtLgkZFIb.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId);
												flag = true;
											}
										}
										IL_1D8:;
									}
								}
								AList<ActionElementMap> alist2 = u.DWkEfFJRIhxezCgjNNPhQPxZoAPO;
								if (alist2 != null)
								{
									int count2 = alist2._count;
									for (int l = 0; l < count2; l++)
									{
										ActionElementMap actionElementMap2 = alist2._items[l];
										if (actionElementMap2.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA && actionElementMap2._elementType == ControllerElementType.Button)
										{
											int actionId2 = actionElementMap2._actionId;
											float utdxJIHkatoxBldAvWBbZTVbaFcl = 0f;
											int mRCBQDgzARDPVbNsvhiBadcDxEwTB = actionElementMap2.mRCBQDgzARDPVbNsvhiBadcDxEwTB;
											if (this.naRHvpBZKIyBsBnUdKegICYQcPKg<\u0002>(vlnBmkNlWHuWGKNvpysrhMLAvwWA, i, mRCBQDgzARDPVbNsvhiBadcDxEwTB, actionElementMap2, syeOZTgTBzpCRvaSMSDtNBsRaIdX, actionId2, ref utdxJIHkatoxBldAvWBbZTVbaFcl) || vlnBmkNlWHuWGKNvpysrhMLAvwWA.DQVOuVYkGTobkZcfIdCHMiklaaiH(actionElementMap2, actionId2, out utdxJIHkatoxBldAvWBbZTVbaFcl, out dgjVhstXQWqvCxiamNQKKHhbOocL.rNmnzBBvEKYTVyjrVykrUlpZDyAc))
											{
												ButtonStateFlags buttonStateFlags = vlnBmkNlWHuWGKNvpysrhMLAvwWA.tdcTLdcmxAGwPEpXWnaBGUvEHgCJb(actionElementMap2.mRCBQDgzARDPVbNsvhiBadcDxEwTB);
												if (buttonStateFlags == ButtonStateFlags.Off)
												{
													A_2(false, this.PssdVhgihfxSSsOlqFEigtLgkZFIb.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId2);
												}
												else
												{
													dgjVhstXQWqvCxiamNQKKHhbOocL.utdxJIHkatoxBldAvWBbZTVbaFcl = utdxJIHkatoxBldAvWBbZTVbaFcl;
													dgjVhstXQWqvCxiamNQKKHhbOocL.eyvxnJpMZeEZcENTKtcvIFJLyWAO = buttonStateFlags;
													dgjVhstXQWqvCxiamNQKKHhbOocL.xadwTlbiqMnQJKpkbwcTSEJqFKyN = vlnBmkNlWHuWGKNvpysrhMLAvwWA;
													dgjVhstXQWqvCxiamNQKKHhbOocL.NgcWpJIBgJyvJEPNRloRpkQSpiZk = A_1;
													dgjVhstXQWqvCxiamNQKKHhbOocL.xqKIdHbHXOEZvhWKNQasyVhQmkIA = ControllerElementType.Button;
													dgjVhstXQWqvCxiamNQKKHhbOocL.jMEqHZPiCdPoKLgzvxltMnUhaoSH = actionElementMap2;
													dgjVhstXQWqvCxiamNQKKHhbOocL.wwVloXlzGdiPzMmaSrTJsEEKVkzC = u;
													if (dgjVhstXQWqvCxiamNQKKHhbOocL.ZAGAxVhJMnqlgFyZHfBZxpIAGWyn)
													{
														dgjVhstXQWqvCxiamNQKKHhbOocL.ZAGAxVhJMnqlgFyZHfBZxpIAGWyn = false;
													}
													A_2(true, this.PssdVhgihfxSSsOlqFEigtLgkZFIb.slhAWVVynuDdrqbdGKDoRVmsCDYo, actionId2);
													flag = true;
												}
											}
										}
									}
								}
								if (flag)
								{
									gkFtqSotlvjTxqHWDAWBgsGdsVUL.uaEfQbAhtXZGrUkNFqyJhBwdFZRC();
								}
							}
						}
					}
				}
			}

			// Token: 0x06001066 RID: 4198 RVA: 0x0005A250 File Offset: 0x00058450
			private bool naRHvpBZKIyBsBnUdKegICYQcPKg<\u0001>(ControllerWithAxes A_1, int A_2, int A_3, ActionElementMap A_4, VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<\u0001> A_5, int A_6, ref float A_7) where \u0001 : ControllerMapWithAxes
			{
				if (!A_1.ydAtmTGPnVEBcanqXjmfnQCYnoGgb.IsUnknownHatCardinal(A_3))
				{
					return false;
				}
				UnknownControllerHat.HatButtons unknownHatButtons = A_1.ydAtmTGPnVEBcanqXjmfnQCYnoGgb.GetUnknownHatButtons(A_3);
				if (this.RmefpLPcnksxvjlrwBuWusClwQQ<\u0001>(unknownHatButtons, A_2, A_5))
				{
					int index;
					int index2;
					unknownHatButtons.GetNeighbors(A_3, out index, out index2);
					if (A_1.GetButton(index) || A_1.GetButton(index2))
					{
						return A_1.pApPLZRfIEWcsjbhcblnmbiJrXWT(A_4, A_6, true, out A_7);
					}
				}
				return false;
			}

			// Token: 0x06001067 RID: 4199 RVA: 0x0000E8C9 File Offset: 0x0000CAC9
			private bool RmefpLPcnksxvjlrwBuWusClwQQ<\u0001>(UnknownControllerHat.HatButtons A_1, int A_2, VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<\u0001> A_3) where \u0001 : ControllerMapWithAxes
			{
				return A_1 != null && (ReInput.configVars.force4WayHats || !this.vFdCUWCYHyZLVasojhLKpTJNOqzL<\u0001>(A_1, A_2, A_3));
			}

			// Token: 0x06001068 RID: 4200 RVA: 0x0005A2B8 File Offset: 0x000584B8
			private bool vFdCUWCYHyZLVasojhLKpTJNOqzL<\u0001>(UnknownControllerHat.HatButtons A_1, int A_2, VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<\u0001> A_3) where \u0001 : ControllerMapWithAxes
			{
				if (A_3 == null)
				{
					return false;
				}
				int num = A_3.sSEkNHPvFzDptlNqDocRnDXFEYyY;
				for (int i = 0; i < num; i++)
				{
					IList<ActionElementMap> buttonMaps = A_3.ZEabTYdmnsjYhGfIgxpgnyvGMRBRA(i).ButtonMaps;
					if (buttonMaps != null)
					{
						int count = buttonMaps.Count;
						for (int j = 0; j < count; j++)
						{
							int mRCBQDgzARDPVbNsvhiBadcDxEwTB = buttonMaps[j].mRCBQDgzARDPVbNsvhiBadcDxEwTB;
							if (buttonMaps[j]._actionId >= 0 && A_1.IsCorner(mRCBQDgzARDPVbNsvhiBadcDxEwTB))
							{
								return true;
							}
						}
					}
				}
				return false;
			}

			// Token: 0x04000962 RID: 2402
			private readonly Player.ControllerHelper.rrwhAMAJavPyFelmoWqKjwiNpysP ylCPpFWsrSbqhhneUtsQXRtlJEDi;

			// Token: 0x04000963 RID: 2403
			private bool XBolbQiDSdCaKCpMixItUgVeDfkAb;

			// Token: 0x04000964 RID: 2404
			private bool pfJEVdWSPRUAULafKDQwbutdUTgK;

			// Token: 0x04000965 RID: 2405
			private bool PIEHPIgJuqWGSngsqmFTzHLntGRi;

			// Token: 0x04000966 RID: 2406
			private double aXPkROCyXVClsoJGDtGgsQjzwefb;

			// Token: 0x04000967 RID: 2407
			private double aNGZibrTsnPalUSPlVaHoBlevpoT;

			// Token: 0x04000968 RID: 2408
			private SafeAction<ControllerAssignmentChangedEventArgs> psXJPGhJHrnEtgaAhCUhBtZVmLssA = new SafeAction<ControllerAssignmentChangedEventArgs>(new Action<Exception>(Player.ControllerHelper.kbpuOSNIlWMgpPzYDoyzVfgfIkrx.<>9.kfxekgKmcClLZiaIpehZJvsiuKcpA));

			// Token: 0x04000969 RID: 2409
			private SafeAction<ControllerAssignmentChangedEventArgs> XANDlQbPZMPExfbfmwyntrCXdNgHA = new SafeAction<ControllerAssignmentChangedEventArgs>(new Action<Exception>(Player.ControllerHelper.kbpuOSNIlWMgpPzYDoyzVfgfIkrx.<>9.egiBJKsiXvluFhszoPkPETZFDgPK));

			// Token: 0x0400096A RID: 2410
			private readonly Player.ControllerHelper.qIXNxngxvPnyUKiwJbWeyVtlOaCm BhYmddYjQBpTYSjebSXDXGRpyVFj;

			// Token: 0x0400096B RID: 2411
			private readonly Player PssdVhgihfxSSsOlqFEigtLgkZFIb;

			// Token: 0x0400096C RID: 2412
			private readonly RXwELUeslTkclmlgxEgZCHffugOj eyxqhzrAGWgJpPTqGJLkcKwcLRcb;

			// Token: 0x0400096D RID: 2413
			private readonly int MIPUxAHdABBOEwtyfTUSosHIROxn;

			// Token: 0x0400096E RID: 2414
			public readonly Player.ControllerHelper.MapHelper maps;

			// Token: 0x0400096F RID: 2415
			public readonly Player.ControllerHelper.ConflictCheckingHelper conflictChecking;

			// Token: 0x04000970 RID: 2416
			public readonly Player.ControllerHelper.PollingHelper polling;

			// Token: 0x0200016C RID: 364
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class ConflictCheckingHelper : CodeHelper
			{
				// Token: 0x06001069 RID: 4201 RVA: 0x0000E8EC File Offset: 0x0000CAEC
				internal ConflictCheckingHelper(Player A_1, Player.ControllerHelper A_2)
				{
					this.vxgeDuGozQdSzFaQikkskkPnenXQB = ReInput.id;
					this.vRUwEnQNNSatwHRdEGApkiuClUuhA = A_1;
					this.EpMVjtvWcdcxdtciBHAmGgFvYELq = A_2;
				}

				// Token: 0x0600106A RID: 4202 RVA: 0x0000E90D File Offset: 0x0000CB0D
				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap)
				{
					return this.DoesElementAssignmentConflict(controllerType, controllerId, controllerMap, false, false);
				}

				// Token: 0x0600106B RID: 4203 RVA: 0x0000E91A File Offset: 0x0000CB1A
				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps)
				{
					return this.DoesElementAssignmentConflict(controllerType, controllerId, controllerMap, skipDisabledMaps, false);
				}

				// Token: 0x0600106C RID: 4204 RVA: 0x0005A338 File Offset: 0x00058538
				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != this.vxgeDuGozQdSzFaQikkskkPnenXQB)
					{
						ReInput.CheckInitialized(this.vxgeDuGozQdSzFaQikkskkPnenXQB);
						return false;
					}
					if (controllerMap == null)
					{
						return false;
					}
					if (controllerType == ControllerType.Joystick)
					{
						return this.yPaoOTGBfVmekFRqnOKXRJEQBxos(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories);
					}
					if (controllerType == ControllerType.Keyboard)
					{
						return this.OhcEKbEjLrrWfZpGGHmVxyxOCpSR(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories);
					}
					if (controllerType == ControllerType.Mouse)
					{
						return this.GhFMEfiLMkEMShQLteLlsSOMzdGN(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories);
					}
					if (controllerType == ControllerType.Custom)
					{
						return this.lFQRHPOoVevufJJHwUKWiPfTObqf(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				// Token: 0x0600106D RID: 4205 RVA: 0x0000E928 File Offset: 0x0000CB28
				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return this.DoesElementAssignmentConflict(controllerType, controllerId, controllerMap, elementMap, false, false);
				}

				// Token: 0x0600106E RID: 4206 RVA: 0x0000E937 File Offset: 0x0000CB37
				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return this.DoesElementAssignmentConflict(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, false);
				}

				// Token: 0x0600106F RID: 4207 RVA: 0x0005A3C0 File Offset: 0x000585C0
				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != this.vxgeDuGozQdSzFaQikkskkPnenXQB)
					{
						ReInput.CheckInitialized(this.vxgeDuGozQdSzFaQikkskkPnenXQB);
						return false;
					}
					if (controllerMap == null || elementMap == null)
					{
						return false;
					}
					if (controllerType == ControllerType.Joystick)
					{
						return this.fzxNPENqgHjDUHCHnaTBJudoIcTX(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories);
					}
					if (controllerType == ControllerType.Keyboard)
					{
						return this.cezdmTKKJgPOZQRBwkOozAAlTfvNA(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories);
					}
					if (controllerType == ControllerType.Mouse)
					{
						return this.BlIidOuMlMwepKhdRGlWIaveKCSsA(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories);
					}
					if (controllerType == ControllerType.Custom)
					{
						return this.PcFiuEMVtyESozKpaEFrBjAzMPLq(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				// Token: 0x06001070 RID: 4208 RVA: 0x0000E947 File Offset: 0x0000CB47
				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck)
				{
					return this.DoesElementAssignmentConflict(conflictCheck, false, false);
				}

				// Token: 0x06001071 RID: 4209 RVA: 0x0000E952 File Offset: 0x0000CB52
				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return this.DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps, false);
				}

				// Token: 0x06001072 RID: 4210 RVA: 0x0005A454 File Offset: 0x00058654
				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != this.vxgeDuGozQdSzFaQikkskkPnenXQB)
					{
						ReInput.CheckInitialized(this.vxgeDuGozQdSzFaQikkskkPnenXQB);
						return false;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return this.UdyKpzZpWJOkwhjhJsEbSfqjRipf(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return this.yDpsDosfrsEzCIICzHoCAsWsWDOKA(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return this.QPDqCgZulSHoNTEhZeyFcWMiAUBQ(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return this.gpxPsHeyTcEbfnIGebSkBEOHgsiGb(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				// Token: 0x06001073 RID: 4211 RVA: 0x0000E95D File Offset: 0x0000CB5D
				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap)
				{
					return this.ElementAssignmentConflicts(controllerType, controllerId, controllerMap, false, false);
				}

				// Token: 0x06001074 RID: 4212 RVA: 0x0000E96A File Offset: 0x0000CB6A
				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps)
				{
					return this.ElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipDisabledMaps, false);
				}

				// Token: 0x06001075 RID: 4213 RVA: 0x0005A4D4 File Offset: 0x000586D4
				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != this.vxgeDuGozQdSzFaQikkskkPnenXQB)
					{
						ReInput.CheckInitialized(this.vxgeDuGozQdSzFaQikkskkPnenXQB);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (controllerMap == null)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					if (controllerType == ControllerType.Joystick)
					{
						return this.jFrCbvLtYCBZcCRhohsKIJssllrz(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories);
					}
					if (controllerType == ControllerType.Keyboard)
					{
						return this.xbBRSvkWwrMscqTluZTfNbaJIBIV(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories);
					}
					if (controllerType == ControllerType.Mouse)
					{
						return this.xhEeFMuHkYzAwOSIetvWQFnIrlUK(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories);
					}
					if (controllerType == ControllerType.Custom)
					{
						return this.uWUgRuFAfLdOpYZOJoOgbCXUeykI(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				// Token: 0x06001076 RID: 4214 RVA: 0x0000E978 File Offset: 0x0000CB78
				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return this.ElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, false, false);
				}

				// Token: 0x06001077 RID: 4215 RVA: 0x0000E987 File Offset: 0x0000CB87
				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return this.ElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, false);
				}

				// Token: 0x06001078 RID: 4216 RVA: 0x0005A564 File Offset: 0x00058764
				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != this.vxgeDuGozQdSzFaQikkskkPnenXQB)
					{
						ReInput.CheckInitialized(this.vxgeDuGozQdSzFaQikkskkPnenXQB);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (controllerMap == null || elementMap == null)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					if (controllerType == ControllerType.Joystick)
					{
						return this.UomTROsesVClDkCgkCZWZqzIpmZBA(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories);
					}
					if (controllerType == ControllerType.Keyboard)
					{
						return this.bguAdneBBPdzCAKJkXJKRXXOKaXrA(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories);
					}
					if (controllerType == ControllerType.Mouse)
					{
						return this.GONstHofJGoRSsatnrjbGYrHcfTl(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories);
					}
					if (controllerType == ControllerType.Custom)
					{
						return this.JpjgpHfyiAWjejOCabjQowNohLcUA(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				// Token: 0x06001079 RID: 4217 RVA: 0x0000E997 File Offset: 0x0000CB97
				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return this.ElementAssignmentConflicts(conflictCheck, false, false);
				}

				// Token: 0x0600107A RID: 4218 RVA: 0x0000E9A2 File Offset: 0x0000CBA2
				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return this.ElementAssignmentConflicts(conflictCheck, skipDisabledMaps, false);
				}

				// Token: 0x0600107B RID: 4219 RVA: 0x0005A600 File Offset: 0x00058800
				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != this.vxgeDuGozQdSzFaQikkskkPnenXQB)
					{
						ReInput.CheckInitialized(this.vxgeDuGozQdSzFaQikkskkPnenXQB);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return this.XxhjKfKWlLnnOYWUlSwyGRtrpkLe(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return this.NCGcDGpZelQgrHmpeGmoGmnQMdafb(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return this.iHOHDUNVAVdqHiCddIJbbHZLfDPcA(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return this.WHfwHUKnzpCMHfVGyNewshjQrIEX(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				// Token: 0x0600107C RID: 4220 RVA: 0x0000E9AD File Offset: 0x0000CBAD
				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap)
				{
					return this.RemoveElementAssignmentConflicts(controllerType, controllerId, controllerMap, false, false);
				}

				// Token: 0x0600107D RID: 4221 RVA: 0x0000E9BA File Offset: 0x0000CBBA
				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipRemovedMaps)
				{
					return this.RemoveElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipRemovedMaps, false);
				}

				// Token: 0x0600107E RID: 4222 RVA: 0x0005A684 File Offset: 0x00058884
				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipRemovedMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != this.vxgeDuGozQdSzFaQikkskkPnenXQB)
					{
						ReInput.CheckInitialized(this.vxgeDuGozQdSzFaQikkskkPnenXQB);
						return 0;
					}
					if (controllerMap == null)
					{
						return 0;
					}
					if (controllerType == ControllerType.Joystick)
					{
						return this.ELXoOOdTfMebZhBLMVkchFWOxqNj(controllerId, controllerMap as JoystickMap, skipRemovedMaps, forceCheckAllCategories);
					}
					if (controllerType == ControllerType.Keyboard)
					{
						return this.EimQJdDCtMfSyaihoMJPiEdleNyP(controllerMap as KeyboardMap, skipRemovedMaps, forceCheckAllCategories);
					}
					if (controllerType == ControllerType.Mouse)
					{
						return this.STgXVPXAIgqKvwfoYhlOMyEPcCbn(controllerMap as MouseMap, skipRemovedMaps, forceCheckAllCategories);
					}
					if (controllerType == ControllerType.Custom)
					{
						return this.vXyJdrtJdWWKCAngoaAWIRzNDWbN(controllerId, controllerMap as CustomControllerMap, skipRemovedMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				// Token: 0x0600107F RID: 4223 RVA: 0x0000E9C8 File Offset: 0x0000CBC8
				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return this.RemoveElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, false, false);
				}

				// Token: 0x06001080 RID: 4224 RVA: 0x0000E9D7 File Offset: 0x0000CBD7
				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipRemovedMaps)
				{
					return this.RemoveElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipRemovedMaps, false);
				}

				// Token: 0x06001081 RID: 4225 RVA: 0x0005A70C File Offset: 0x0005890C
				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipRemovedMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != this.vxgeDuGozQdSzFaQikkskkPnenXQB)
					{
						ReInput.CheckInitialized(this.vxgeDuGozQdSzFaQikkskkPnenXQB);
						return 0;
					}
					if (controllerMap == null || elementMap == null)
					{
						return 0;
					}
					if (controllerType == ControllerType.Joystick)
					{
						return this.CDDyFhyPzGNlodkWxrViGJsVgGwh(controllerId, controllerMap as JoystickMap, elementMap, skipRemovedMaps, forceCheckAllCategories);
					}
					if (controllerType == ControllerType.Keyboard)
					{
						return this.xQHCdLBjHqTtREZQVFWzkJmYjCLj(controllerMap as KeyboardMap, elementMap, skipRemovedMaps, forceCheckAllCategories);
					}
					if (controllerType == ControllerType.Mouse)
					{
						return this.lstOiUrqtoBMdwenWaIndnAvQsKh(controllerMap as MouseMap, elementMap, skipRemovedMaps, forceCheckAllCategories);
					}
					if (controllerType == ControllerType.Custom)
					{
						return this.MdLbmSlCCSmHSExCUuVohquoMKff(controllerId, controllerMap as CustomControllerMap, elementMap, skipRemovedMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				// Token: 0x06001082 RID: 4226 RVA: 0x0000E9E7 File Offset: 0x0000CBE7
				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return this.RemoveElementAssignmentConflicts(conflictCheck, false, false);
				}

				// Token: 0x06001083 RID: 4227 RVA: 0x0000E9F2 File Offset: 0x0000CBF2
				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipRemovedMaps)
				{
					return this.RemoveElementAssignmentConflicts(conflictCheck, skipRemovedMaps, false);
				}

				// Token: 0x06001084 RID: 4228 RVA: 0x0005A7A0 File Offset: 0x000589A0
				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipRemovedMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != this.vxgeDuGozQdSzFaQikkskkPnenXQB)
					{
						ReInput.CheckInitialized(this.vxgeDuGozQdSzFaQikkskkPnenXQB);
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return this.tLKszSPSSLnMFBGyCYjywShpKuCf(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return this.dSgAFCFVKhHjGbinlceJnutEPcfcA(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return this.cidzgxgabTLkxQfKrvrJnTBItzgf(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return this.AjbJDkLOgXZSubMAFWczisjwcTqS(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				// Token: 0x06001085 RID: 4229 RVA: 0x0000E9FD File Offset: 0x0000CBFD
				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap)
				{
					return this.DisableElementAssignmentConflicts(controllerType, controllerId, controllerMap, false, false);
				}

				// Token: 0x06001086 RID: 4230 RVA: 0x0000EA0A File Offset: 0x0000CC0A
				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps)
				{
					return this.DisableElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipDisabledMaps, false);
				}

				// Token: 0x06001087 RID: 4231 RVA: 0x0005A820 File Offset: 0x00058A20
				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != this.vxgeDuGozQdSzFaQikkskkPnenXQB)
					{
						ReInput.CheckInitialized(this.vxgeDuGozQdSzFaQikkskkPnenXQB);
						return 0;
					}
					if (controllerMap == null)
					{
						return 0;
					}
					if (controllerType == ControllerType.Joystick)
					{
						return this.oszDtasScLkGuvlYXEefPBKGftTIA(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories, null);
					}
					if (controllerType == ControllerType.Keyboard)
					{
						return this.uOZdnyRZIHHPKLnedSooKpXkoLxi(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories, null);
					}
					if (controllerType == ControllerType.Mouse)
					{
						return this.veIPdZKHkChQHbCjAQjlEEkcEbGfc(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories, null);
					}
					if (controllerType == ControllerType.Custom)
					{
						return this.KIEGXCBdOXjhRjsBgIJLxETLQdOQB(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories, null);
					}
					throw new NotImplementedException();
				}

				// Token: 0x06001088 RID: 4232 RVA: 0x0000EA18 File Offset: 0x0000CC18
				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return this.DisableElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, false, false);
				}

				// Token: 0x06001089 RID: 4233 RVA: 0x0000EA27 File Offset: 0x0000CC27
				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return this.DisableElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, false);
				}

				// Token: 0x0600108A RID: 4234 RVA: 0x0005A8AC File Offset: 0x00058AAC
				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != this.vxgeDuGozQdSzFaQikkskkPnenXQB)
					{
						ReInput.CheckInitialized(this.vxgeDuGozQdSzFaQikkskkPnenXQB);
						return 0;
					}
					if (controllerMap == null || elementMap == null)
					{
						return 0;
					}
					if (controllerType == ControllerType.Joystick)
					{
						return this.cwOCiqhAvbqpkTqLQNpmGrYLGyDl(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, null);
					}
					if (controllerType == ControllerType.Keyboard)
					{
						return this.bfmETebmuahyaxxgWsbsPnsXKwCFb(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, null);
					}
					if (controllerType == ControllerType.Mouse)
					{
						return this.LnMDfpIdtBuHbHMSpsEeIouqwQYs(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, null);
					}
					if (controllerType == ControllerType.Custom)
					{
						return this.feiXOLIIrmnvqknyEHjAirZhAHdp(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, null);
					}
					throw new NotImplementedException();
				}

				// Token: 0x0600108B RID: 4235 RVA: 0x0000EA37 File Offset: 0x0000CC37
				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return this.DisableElementAssignmentConflicts(conflictCheck, false, false);
				}

				// Token: 0x0600108C RID: 4236 RVA: 0x0000EA42 File Offset: 0x0000CC42
				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return this.DisableElementAssignmentConflicts(conflictCheck, skipDisabledMaps, false);
				}

				// Token: 0x0600108D RID: 4237 RVA: 0x0005A944 File Offset: 0x00058B44
				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != this.vxgeDuGozQdSzFaQikkskkPnenXQB)
					{
						ReInput.CheckInitialized(this.vxgeDuGozQdSzFaQikkskkPnenXQB);
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return this.KlWdMKkeLVcxUvxDOTPnNgnzlyPw(conflictCheck, skipDisabledMaps, forceCheckAllCategories, null);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return this.fEqyYoGKDNgaTenIDliERGhKBSSZ(conflictCheck, skipDisabledMaps, forceCheckAllCategories, null);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return this.HsnYVlcNPWWlGUXadDWGYVQaCgal(conflictCheck, skipDisabledMaps, forceCheckAllCategories, null);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return this.RVuGloKvzzwIwJkxVZAymXYpbQCe(conflictCheck, skipDisabledMaps, forceCheckAllCategories, null);
					}
					throw new NotImplementedException();
				}

				// Token: 0x0600108E RID: 4238 RVA: 0x0005A9C8 File Offset: 0x00058BC8
				private bool yPaoOTGBfVmekFRqnOKXRJEQBxos(int A_1, JoystickMap A_2, bool A_3 = false, bool A_4 = false)
				{
					if (A_1 < 0 || A_2 == null)
					{
						return false;
					}
					for (int i = 0; i < this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						if (this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).VLnBmkNlWHuWGKNvpysrhMLAvwWA.id == A_1 && this.QyxTFfQiNWOSbRGJCGcjcNihrTdI<JoystickMap>(ControllerType.Joystick, A_1, A_2, A_3, A_4, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).SYeOZTgTBzpCRvaSMSDtNBsRaIdX))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x0600108F RID: 4239 RVA: 0x0005AA40 File Offset: 0x00058C40
				private bool fzxNPENqgHjDUHCHnaTBJudoIcTX(int A_1, JoystickMap A_2, ActionElementMap A_3, bool A_4 = false, bool A_5 = false)
				{
					if (A_1 < 0 || A_3 == null)
					{
						return false;
					}
					for (int i = 0; i < this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						if (this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).VLnBmkNlWHuWGKNvpysrhMLAvwWA.id == A_1 && this.YFanebquYcdbUCFLpiPGigFhSRSTA<JoystickMap>(ControllerType.Joystick, A_1, A_2, A_3, A_4, A_5, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).SYeOZTgTBzpCRvaSMSDtNBsRaIdX))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x06001090 RID: 4240 RVA: 0x0005AAB8 File Offset: 0x00058CB8
				private bool UdyKpzZpWJOkwhjhJsEbSfqjRipf(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false)
				{
					if (A_1.controllerId < 0 || A_1.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					for (int i = 0; i < this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						if (this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).VLnBmkNlWHuWGKNvpysrhMLAvwWA.id == A_1.controllerId && this.jxEdlcATDmGFRwmCWDkAEXEGhdSuA<JoystickMap>(A_1, A_2, A_3, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).SYeOZTgTBzpCRvaSMSDtNBsRaIdX))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x06001091 RID: 4241 RVA: 0x0000EA4D File Offset: 0x0000CC4D
				private bool OhcEKbEjLrrWfZpGGHmVxyxOCpSR(KeyboardMap A_1, bool A_2 = false, bool A_3 = false)
				{
					return this.QyxTFfQiNWOSbRGJCGcjcNihrTdI<KeyboardMap>(ControllerType.Keyboard, 0, A_1, A_2, A_3, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.IBQRiBQwBQkksvMFoghSPVjYfKdq);
				}

				// Token: 0x06001092 RID: 4242 RVA: 0x0000EA65 File Offset: 0x0000CC65
				private bool cezdmTKKJgPOZQRBwkOozAAlTfvNA(KeyboardMap A_1, ActionElementMap A_2, bool A_3 = false, bool A_4 = false)
				{
					return this.YFanebquYcdbUCFLpiPGigFhSRSTA<KeyboardMap>(ControllerType.Keyboard, 0, A_1, A_2, A_3, A_4, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.IBQRiBQwBQkksvMFoghSPVjYfKdq);
				}

				// Token: 0x06001093 RID: 4243 RVA: 0x0000EA7F File Offset: 0x0000CC7F
				private bool yDpsDosfrsEzCIICzHoCAsWsWDOKA(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false)
				{
					return A_1.elementAssignmentType == ElementAssignmentType.KeyboardKey && this.jxEdlcATDmGFRwmCWDkAEXEGhdSuA<KeyboardMap>(A_1, A_2, A_3, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.IBQRiBQwBQkksvMFoghSPVjYfKdq);
				}

				// Token: 0x06001094 RID: 4244 RVA: 0x0000EAA1 File Offset: 0x0000CCA1
				private bool GhFMEfiLMkEMShQLteLlsSOMzdGN(MouseMap A_1, bool A_2 = false, bool A_3 = false)
				{
					return this.QyxTFfQiNWOSbRGJCGcjcNihrTdI<MouseMap>(ControllerType.Mouse, 0, A_1, A_2, A_3, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.boJfSzOZpBUMMRMJLlCAwvRKpwKC);
				}

				// Token: 0x06001095 RID: 4245 RVA: 0x0000EAB9 File Offset: 0x0000CCB9
				private bool BlIidOuMlMwepKhdRGlWIaveKCSsA(MouseMap A_1, ActionElementMap A_2, bool A_3 = false, bool A_4 = false)
				{
					return this.YFanebquYcdbUCFLpiPGigFhSRSTA<MouseMap>(ControllerType.Mouse, 0, A_1, A_2, A_3, A_4, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.boJfSzOZpBUMMRMJLlCAwvRKpwKC);
				}

				// Token: 0x06001096 RID: 4246 RVA: 0x0000EAD3 File Offset: 0x0000CCD3
				private bool QPDqCgZulSHoNTEhZeyFcWMiAUBQ(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false)
				{
					return A_1.elementAssignmentType != ElementAssignmentType.KeyboardKey && this.jxEdlcATDmGFRwmCWDkAEXEGhdSuA<MouseMap>(A_1, A_2, A_3, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.boJfSzOZpBUMMRMJLlCAwvRKpwKC);
				}

				// Token: 0x06001097 RID: 4247 RVA: 0x0005AB40 File Offset: 0x00058D40
				private bool lFQRHPOoVevufJJHwUKWiPfTObqf(int A_1, CustomControllerMap A_2, bool A_3 = false, bool A_4 = false)
				{
					if (A_1 < 0 || A_2 == null)
					{
						return false;
					}
					for (int i = 0; i < this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						if (this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).VLnBmkNlWHuWGKNvpysrhMLAvwWA.id == A_1 && this.QyxTFfQiNWOSbRGJCGcjcNihrTdI<CustomControllerMap>(ControllerType.Custom, A_1, A_2, A_3, A_4, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).SYeOZTgTBzpCRvaSMSDtNBsRaIdX))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x06001098 RID: 4248 RVA: 0x0005ABB8 File Offset: 0x00058DB8
				private bool PcFiuEMVtyESozKpaEFrBjAzMPLq(int A_1, CustomControllerMap A_2, ActionElementMap A_3, bool A_4 = false, bool A_5 = false)
				{
					if (A_1 < 0 || A_3 == null)
					{
						return false;
					}
					for (int i = 0; i < this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						if (this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).VLnBmkNlWHuWGKNvpysrhMLAvwWA.id == A_1 && this.YFanebquYcdbUCFLpiPGigFhSRSTA<CustomControllerMap>(ControllerType.Custom, A_1, A_2, A_3, A_4, A_5, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).SYeOZTgTBzpCRvaSMSDtNBsRaIdX))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x06001099 RID: 4249 RVA: 0x0005AC34 File Offset: 0x00058E34
				private bool gpxPsHeyTcEbfnIGebSkBEOHgsiGb(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false)
				{
					if (A_1.controllerId < 0 || A_1.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					for (int i = 0; i < this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						if (this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).VLnBmkNlWHuWGKNvpysrhMLAvwWA.id == A_1.controllerId && this.jxEdlcATDmGFRwmCWDkAEXEGhdSuA<CustomControllerMap>(A_1, A_2, A_3, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).SYeOZTgTBzpCRvaSMSDtNBsRaIdX))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x0600109A RID: 4250 RVA: 0x0000EAF5 File Offset: 0x0000CCF5
				private IEnumerable<ElementAssignmentConflictInfo> jFrCbvLtYCBZcCRhohsKIJssllrz(int A_1, JoystickMap A_2, bool A_3 = false, bool A_4 = false)
				{
					if (A_1 < 0 || A_2 == null)
					{
						yield break;
					}
					int num;
					for (int i = 0; i < this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.hUvoPojtJZIUBnFkCGjslfijGbmL; i = num + 1)
					{
						if (this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).VLnBmkNlWHuWGKNvpysrhMLAvwWA.id == A_1)
						{
							foreach (ElementAssignmentConflictInfo elementAssignmentConflictInfo in this.fvQkETtLPcJJShqXGewgxhHGbtjcA<JoystickMap>(ControllerType.Joystick, A_1, A_2, A_3, A_4, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).SYeOZTgTBzpCRvaSMSDtNBsRaIdX))
							{
								yield return elementAssignmentConflictInfo;
							}
							IEnumerator<ElementAssignmentConflictInfo> enumerator = null;
						}
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x0600109B RID: 4251 RVA: 0x0000EB22 File Offset: 0x0000CD22
				private IEnumerable<ElementAssignmentConflictInfo> UomTROsesVClDkCgkCZWZqzIpmZBA(int A_1, JoystickMap A_2, ActionElementMap A_3, bool A_4 = false, bool A_5 = false)
				{
					if (A_1 < 0 || A_3 == null)
					{
						yield break;
					}
					int num;
					for (int i = 0; i < this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.hUvoPojtJZIUBnFkCGjslfijGbmL; i = num + 1)
					{
						if (this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).VLnBmkNlWHuWGKNvpysrhMLAvwWA.id == A_1)
						{
							foreach (ElementAssignmentConflictInfo elementAssignmentConflictInfo in this.BbDqZDKyJRbCoOEDKdXdvDbSScvK<JoystickMap>(ControllerType.Joystick, A_1, A_2, A_3, A_4, A_5, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).SYeOZTgTBzpCRvaSMSDtNBsRaIdX))
							{
								yield return elementAssignmentConflictInfo;
							}
							IEnumerator<ElementAssignmentConflictInfo> enumerator = null;
						}
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x0600109C RID: 4252 RVA: 0x0000EB57 File Offset: 0x0000CD57
				private IEnumerable<ElementAssignmentConflictInfo> XxhjKfKWlLnnOYWUlSwyGRtrpkLe(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false)
				{
					if (A_1.controllerId < 0 || A_1.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						yield break;
					}
					int num;
					for (int i = 0; i < this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.hUvoPojtJZIUBnFkCGjslfijGbmL; i = num + 1)
					{
						if (this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).VLnBmkNlWHuWGKNvpysrhMLAvwWA.id == A_1.controllerId)
						{
							foreach (ElementAssignmentConflictInfo elementAssignmentConflictInfo in this.uutlECJfhoBKtKyYPUfUMaSZoZTsA<JoystickMap>(A_1, A_2, A_3, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).SYeOZTgTBzpCRvaSMSDtNBsRaIdX))
							{
								yield return elementAssignmentConflictInfo;
							}
							IEnumerator<ElementAssignmentConflictInfo> enumerator = null;
						}
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x0600109D RID: 4253 RVA: 0x0000EB7C File Offset: 0x0000CD7C
				private IEnumerable<ElementAssignmentConflictInfo> xbBRSvkWwrMscqTluZTfNbaJIBIV(KeyboardMap A_1, bool A_2 = false, bool A_3 = false)
				{
					return this.fvQkETtLPcJJShqXGewgxhHGbtjcA<KeyboardMap>(ControllerType.Keyboard, 0, A_1, A_2, A_3, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.IBQRiBQwBQkksvMFoghSPVjYfKdq);
				}

				// Token: 0x0600109E RID: 4254 RVA: 0x0000EB94 File Offset: 0x0000CD94
				private IEnumerable<ElementAssignmentConflictInfo> bguAdneBBPdzCAKJkXJKRXXOKaXrA(KeyboardMap A_1, ActionElementMap A_2, bool A_3 = false, bool A_4 = false)
				{
					return this.BbDqZDKyJRbCoOEDKdXdvDbSScvK<KeyboardMap>(ControllerType.Keyboard, 0, A_1, A_2, A_3, A_4, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.IBQRiBQwBQkksvMFoghSPVjYfKdq);
				}

				// Token: 0x0600109F RID: 4255 RVA: 0x0000EBAE File Offset: 0x0000CDAE
				private IEnumerable<ElementAssignmentConflictInfo> NCGcDGpZelQgrHmpeGmoGmnQMdafb(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false)
				{
					if (A_1.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return this.uutlECJfhoBKtKyYPUfUMaSZoZTsA<KeyboardMap>(A_1, A_2, A_3, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.IBQRiBQwBQkksvMFoghSPVjYfKdq);
				}

				// Token: 0x060010A0 RID: 4256 RVA: 0x0000EBD4 File Offset: 0x0000CDD4
				private IEnumerable<ElementAssignmentConflictInfo> xhEeFMuHkYzAwOSIetvWQFnIrlUK(MouseMap A_1, bool A_2 = false, bool A_3 = false)
				{
					return this.fvQkETtLPcJJShqXGewgxhHGbtjcA<MouseMap>(ControllerType.Mouse, 0, A_1, A_2, A_3, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.boJfSzOZpBUMMRMJLlCAwvRKpwKC);
				}

				// Token: 0x060010A1 RID: 4257 RVA: 0x0000EBEC File Offset: 0x0000CDEC
				private IEnumerable<ElementAssignmentConflictInfo> GONstHofJGoRSsatnrjbGYrHcfTl(MouseMap A_1, ActionElementMap A_2, bool A_3 = false, bool A_4 = false)
				{
					return this.BbDqZDKyJRbCoOEDKdXdvDbSScvK<MouseMap>(ControllerType.Mouse, 0, A_1, A_2, A_3, A_4, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.boJfSzOZpBUMMRMJLlCAwvRKpwKC);
				}

				// Token: 0x060010A2 RID: 4258 RVA: 0x0000EC06 File Offset: 0x0000CE06
				private IEnumerable<ElementAssignmentConflictInfo> iHOHDUNVAVdqHiCddIJbbHZLfDPcA(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false)
				{
					if (A_1.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return this.uutlECJfhoBKtKyYPUfUMaSZoZTsA<MouseMap>(A_1, A_2, A_3, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.boJfSzOZpBUMMRMJLlCAwvRKpwKC);
				}

				// Token: 0x060010A3 RID: 4259 RVA: 0x0000EC2C File Offset: 0x0000CE2C
				private IEnumerable<ElementAssignmentConflictInfo> uWUgRuFAfLdOpYZOJoOgbCXUeykI(int A_1, CustomControllerMap A_2, bool A_3 = false, bool A_4 = false)
				{
					if (A_1 < 0 || A_2 == null)
					{
						yield break;
					}
					int num;
					for (int i = 0; i < this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.hUvoPojtJZIUBnFkCGjslfijGbmL; i = num + 1)
					{
						if (this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).VLnBmkNlWHuWGKNvpysrhMLAvwWA.id == A_1)
						{
							foreach (ElementAssignmentConflictInfo elementAssignmentConflictInfo in this.fvQkETtLPcJJShqXGewgxhHGbtjcA<CustomControllerMap>(ControllerType.Custom, A_1, A_2, A_3, A_4, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).SYeOZTgTBzpCRvaSMSDtNBsRaIdX))
							{
								yield return elementAssignmentConflictInfo;
							}
							IEnumerator<ElementAssignmentConflictInfo> enumerator = null;
						}
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x060010A4 RID: 4260 RVA: 0x0000EC59 File Offset: 0x0000CE59
				private IEnumerable<ElementAssignmentConflictInfo> JpjgpHfyiAWjejOCabjQowNohLcUA(int A_1, CustomControllerMap A_2, ActionElementMap A_3, bool A_4 = false, bool A_5 = false)
				{
					if (A_1 < 0 || A_3 == null)
					{
						yield break;
					}
					int num;
					for (int i = 0; i < this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.hUvoPojtJZIUBnFkCGjslfijGbmL; i = num + 1)
					{
						if (this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).VLnBmkNlWHuWGKNvpysrhMLAvwWA.id == A_1)
						{
							foreach (ElementAssignmentConflictInfo elementAssignmentConflictInfo in this.BbDqZDKyJRbCoOEDKdXdvDbSScvK<CustomControllerMap>(ControllerType.Custom, A_1, A_2, A_3, A_4, A_5, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).SYeOZTgTBzpCRvaSMSDtNBsRaIdX))
							{
								yield return elementAssignmentConflictInfo;
							}
							IEnumerator<ElementAssignmentConflictInfo> enumerator = null;
						}
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x060010A5 RID: 4261 RVA: 0x0000EC8E File Offset: 0x0000CE8E
				private IEnumerable<ElementAssignmentConflictInfo> WHfwHUKnzpCMHfVGyNewshjQrIEX(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false)
				{
					if (A_1.controllerId < 0 || A_1.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						yield break;
					}
					int num;
					for (int i = 0; i < this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.hUvoPojtJZIUBnFkCGjslfijGbmL; i = num + 1)
					{
						if (this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).VLnBmkNlWHuWGKNvpysrhMLAvwWA.id == A_1.controllerId)
						{
							foreach (ElementAssignmentConflictInfo elementAssignmentConflictInfo in this.uutlECJfhoBKtKyYPUfUMaSZoZTsA<CustomControllerMap>(A_1, A_2, A_3, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).SYeOZTgTBzpCRvaSMSDtNBsRaIdX))
							{
								yield return elementAssignmentConflictInfo;
							}
							IEnumerator<ElementAssignmentConflictInfo> enumerator = null;
						}
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x060010A6 RID: 4262 RVA: 0x0005ACBC File Offset: 0x00058EBC
				private int ELXoOOdTfMebZhBLMVkchFWOxqNj(int A_1, JoystickMap A_2, bool A_3 = false, bool A_4 = false)
				{
					if (A_1 < 0 || A_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						if (this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).VLnBmkNlWHuWGKNvpysrhMLAvwWA.id == A_1)
						{
							num += this.KuNAUgcoSOgRMpZSYnGPEOzykFURA<JoystickMap>(ControllerType.Joystick, A_1, A_2, A_3, A_4, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).SYeOZTgTBzpCRvaSMSDtNBsRaIdX);
						}
					}
					return num;
				}

				// Token: 0x060010A7 RID: 4263 RVA: 0x0005AD34 File Offset: 0x00058F34
				private int CDDyFhyPzGNlodkWxrViGJsVgGwh(int A_1, JoystickMap A_2, ActionElementMap A_3, bool A_4 = false, bool A_5 = false)
				{
					if (A_1 < 0 || A_3 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						if (this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).VLnBmkNlWHuWGKNvpysrhMLAvwWA.id == A_1)
						{
							num += this.YFrRtRWAyFdWDQpSziTHTChnyerC<JoystickMap>(ControllerType.Joystick, A_1, A_2, A_3, A_4, A_5, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).SYeOZTgTBzpCRvaSMSDtNBsRaIdX);
						}
					}
					return num;
				}

				// Token: 0x060010A8 RID: 4264 RVA: 0x0005ADB0 File Offset: 0x00058FB0
				private int tLKszSPSSLnMFBGyCYjywShpKuCf(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false)
				{
					if (A_1.controllerId < 0 || A_1.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						if (this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).VLnBmkNlWHuWGKNvpysrhMLAvwWA.id == A_1.controllerId)
						{
							num += this.nKEaolEAUswugblKlKqhvfcSdROW<JoystickMap>(A_1, A_2, A_3, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).SYeOZTgTBzpCRvaSMSDtNBsRaIdX);
						}
					}
					return num;
				}

				// Token: 0x060010A9 RID: 4265 RVA: 0x0000ECB3 File Offset: 0x0000CEB3
				private int EimQJdDCtMfSyaihoMJPiEdleNyP(KeyboardMap A_1, bool A_2 = false, bool A_3 = false)
				{
					return this.KuNAUgcoSOgRMpZSYnGPEOzykFURA<KeyboardMap>(ControllerType.Keyboard, 0, A_1, A_2, A_3, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.IBQRiBQwBQkksvMFoghSPVjYfKdq);
				}

				// Token: 0x060010AA RID: 4266 RVA: 0x0000ECCB File Offset: 0x0000CECB
				private int xQHCdLBjHqTtREZQVFWzkJmYjCLj(KeyboardMap A_1, ActionElementMap A_2, bool A_3 = false, bool A_4 = false)
				{
					return this.YFrRtRWAyFdWDQpSziTHTChnyerC<KeyboardMap>(ControllerType.Keyboard, 0, A_1, A_2, A_3, A_4, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.IBQRiBQwBQkksvMFoghSPVjYfKdq);
				}

				// Token: 0x060010AB RID: 4267 RVA: 0x0000ECE5 File Offset: 0x0000CEE5
				private int dSgAFCFVKhHjGbinlceJnutEPcfcA(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false)
				{
					if (A_1.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return this.nKEaolEAUswugblKlKqhvfcSdROW<KeyboardMap>(A_1, A_2, A_3, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.IBQRiBQwBQkksvMFoghSPVjYfKdq);
				}

				// Token: 0x060010AC RID: 4268 RVA: 0x0000ED07 File Offset: 0x0000CF07
				private int STgXVPXAIgqKvwfoYhlOMyEPcCbn(MouseMap A_1, bool A_2 = false, bool A_3 = false)
				{
					return this.KuNAUgcoSOgRMpZSYnGPEOzykFURA<MouseMap>(ControllerType.Mouse, 0, A_1, A_2, A_3, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.boJfSzOZpBUMMRMJLlCAwvRKpwKC);
				}

				// Token: 0x060010AD RID: 4269 RVA: 0x0000ED1F File Offset: 0x0000CF1F
				private int lstOiUrqtoBMdwenWaIndnAvQsKh(MouseMap A_1, ActionElementMap A_2, bool A_3 = false, bool A_4 = false)
				{
					return this.YFrRtRWAyFdWDQpSziTHTChnyerC<MouseMap>(ControllerType.Mouse, 0, A_1, A_2, A_3, A_4, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.boJfSzOZpBUMMRMJLlCAwvRKpwKC);
				}

				// Token: 0x060010AE RID: 4270 RVA: 0x0000ED39 File Offset: 0x0000CF39
				private int cidzgxgabTLkxQfKrvrJnTBItzgf(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false)
				{
					if (A_1.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return this.nKEaolEAUswugblKlKqhvfcSdROW<MouseMap>(A_1, A_2, A_3, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.boJfSzOZpBUMMRMJLlCAwvRKpwKC);
				}

				// Token: 0x060010AF RID: 4271 RVA: 0x0005AE38 File Offset: 0x00059038
				private int vXyJdrtJdWWKCAngoaAWIRzNDWbN(int A_1, CustomControllerMap A_2, bool A_3 = false, bool A_4 = false)
				{
					if (A_1 < 0 || A_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						if (this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).VLnBmkNlWHuWGKNvpysrhMLAvwWA.id == A_1)
						{
							num += this.KuNAUgcoSOgRMpZSYnGPEOzykFURA<CustomControllerMap>(ControllerType.Custom, A_1, A_2, A_3, A_4, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).SYeOZTgTBzpCRvaSMSDtNBsRaIdX);
						}
					}
					return num;
				}

				// Token: 0x060010B0 RID: 4272 RVA: 0x0005AEB0 File Offset: 0x000590B0
				private int MdLbmSlCCSmHSExCUuVohquoMKff(int A_1, CustomControllerMap A_2, ActionElementMap A_3, bool A_4 = false, bool A_5 = false)
				{
					if (A_1 < 0 || A_3 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						if (this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).VLnBmkNlWHuWGKNvpysrhMLAvwWA.id == A_1)
						{
							num += this.YFrRtRWAyFdWDQpSziTHTChnyerC<CustomControllerMap>(ControllerType.Custom, A_1, A_2, A_3, A_4, A_5, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).SYeOZTgTBzpCRvaSMSDtNBsRaIdX);
						}
					}
					return num;
				}

				// Token: 0x060010B1 RID: 4273 RVA: 0x0005AF2C File Offset: 0x0005912C
				private int AjbJDkLOgXZSubMAFWczisjwcTqS(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false)
				{
					if (A_1.controllerId < 0 || A_1.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						if (this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).VLnBmkNlWHuWGKNvpysrhMLAvwWA.id == A_1.controllerId)
						{
							num += this.nKEaolEAUswugblKlKqhvfcSdROW<CustomControllerMap>(A_1, A_2, A_3, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).SYeOZTgTBzpCRvaSMSDtNBsRaIdX);
						}
					}
					return num;
				}

				// Token: 0x060010B2 RID: 4274 RVA: 0x0005AFB4 File Offset: 0x000591B4
				private int oszDtasScLkGuvlYXEefPBKGftTIA(int A_1, JoystickMap A_2, bool A_3 = false, bool A_4 = false, List<ActionElementMap> A_5 = null)
				{
					if (A_1 < 0 || A_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						if (this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).VLnBmkNlWHuWGKNvpysrhMLAvwWA.id == A_1)
						{
							num += this.yAwfPmeFVjHOpDZQVLiVAJpDhluBB<JoystickMap>(ControllerType.Joystick, A_1, A_2, A_3, A_4, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).SYeOZTgTBzpCRvaSMSDtNBsRaIdX, A_5);
						}
					}
					return num;
				}

				// Token: 0x060010B3 RID: 4275 RVA: 0x0005B030 File Offset: 0x00059230
				private int cwOCiqhAvbqpkTqLQNpmGrYLGyDl(int A_1, JoystickMap A_2, ActionElementMap A_3, bool A_4 = false, bool A_5 = false, List<ActionElementMap> A_6 = null)
				{
					if (A_1 < 0 || A_3 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						if (this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).VLnBmkNlWHuWGKNvpysrhMLAvwWA.id == A_1)
						{
							num += this.vPgNdtIhtEHWnwmHbeKyMBtXnkKw<JoystickMap>(ControllerType.Joystick, A_1, A_2, A_3, A_4, A_5, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).SYeOZTgTBzpCRvaSMSDtNBsRaIdX, A_6);
						}
					}
					return num;
				}

				// Token: 0x060010B4 RID: 4276 RVA: 0x0005B0AC File Offset: 0x000592AC
				private int KlWdMKkeLVcxUvxDOTPnNgnzlyPw(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false, List<ActionElementMap> A_4 = null)
				{
					if (A_1.controllerId < 0 || A_1.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						if (this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).VLnBmkNlWHuWGKNvpysrhMLAvwWA.id == A_1.controllerId)
						{
							num += this.XDsmkWsuWRuusDiDKGclOXTkggyC<JoystickMap>(A_1, A_2, A_3, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).SYeOZTgTBzpCRvaSMSDtNBsRaIdX, A_4);
						}
					}
					return num;
				}

				// Token: 0x060010B5 RID: 4277 RVA: 0x0000ED5B File Offset: 0x0000CF5B
				private int uOZdnyRZIHHPKLnedSooKpXkoLxi(KeyboardMap A_1, bool A_2 = false, bool A_3 = false, List<ActionElementMap> A_4 = null)
				{
					return this.yAwfPmeFVjHOpDZQVLiVAJpDhluBB<KeyboardMap>(ControllerType.Keyboard, 0, A_1, A_2, A_3, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.IBQRiBQwBQkksvMFoghSPVjYfKdq, A_4);
				}

				// Token: 0x060010B6 RID: 4278 RVA: 0x0005B138 File Offset: 0x00059338
				private int bfmETebmuahyaxxgWsbsPnsXKwCFb(KeyboardMap A_1, ActionElementMap A_2, bool A_3 = false, bool A_4 = false, List<ActionElementMap> A_5 = null)
				{
					return this.vPgNdtIhtEHWnwmHbeKyMBtXnkKw<KeyboardMap>(ControllerType.Keyboard, 0, A_1, A_2, A_3, A_4, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.IBQRiBQwBQkksvMFoghSPVjYfKdq, A_5);
				}

				// Token: 0x060010B7 RID: 4279 RVA: 0x0000ED75 File Offset: 0x0000CF75
				private int fEqyYoGKDNgaTenIDliERGhKBSSZ(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false, List<ActionElementMap> A_4 = null)
				{
					if (A_1.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return this.XDsmkWsuWRuusDiDKGclOXTkggyC<KeyboardMap>(A_1, A_2, A_3, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.IBQRiBQwBQkksvMFoghSPVjYfKdq, A_4);
				}

				// Token: 0x060010B8 RID: 4280 RVA: 0x0000ED99 File Offset: 0x0000CF99
				private int veIPdZKHkChQHbCjAQjlEEkcEbGfc(MouseMap A_1, bool A_2 = false, bool A_3 = false, List<ActionElementMap> A_4 = null)
				{
					return this.yAwfPmeFVjHOpDZQVLiVAJpDhluBB<MouseMap>(ControllerType.Mouse, 0, A_1, A_2, A_3, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.boJfSzOZpBUMMRMJLlCAwvRKpwKC, A_4);
				}

				// Token: 0x060010B9 RID: 4281 RVA: 0x0005B160 File Offset: 0x00059360
				private int LnMDfpIdtBuHbHMSpsEeIouqwQYs(MouseMap A_1, ActionElementMap A_2, bool A_3 = false, bool A_4 = false, List<ActionElementMap> A_5 = null)
				{
					return this.vPgNdtIhtEHWnwmHbeKyMBtXnkKw<MouseMap>(ControllerType.Mouse, 0, A_1, A_2, A_3, A_4, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.boJfSzOZpBUMMRMJLlCAwvRKpwKC, A_5);
				}

				// Token: 0x060010BA RID: 4282 RVA: 0x0000EDB3 File Offset: 0x0000CFB3
				private int HsnYVlcNPWWlGUXadDWGYVQaCgal(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false, List<ActionElementMap> A_4 = null)
				{
					if (A_1.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return this.XDsmkWsuWRuusDiDKGclOXTkggyC<MouseMap>(A_1, A_2, A_3, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.boJfSzOZpBUMMRMJLlCAwvRKpwKC, A_4);
				}

				// Token: 0x060010BB RID: 4283 RVA: 0x0005B188 File Offset: 0x00059388
				private int KIEGXCBdOXjhRjsBgIJLxETLQdOQB(int A_1, CustomControllerMap A_2, bool A_3 = false, bool A_4 = false, List<ActionElementMap> A_5 = null)
				{
					if (A_1 < 0 || A_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						if (this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).VLnBmkNlWHuWGKNvpysrhMLAvwWA.id == A_1)
						{
							num += this.yAwfPmeFVjHOpDZQVLiVAJpDhluBB<CustomControllerMap>(ControllerType.Custom, A_1, A_2, A_3, A_4, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).SYeOZTgTBzpCRvaSMSDtNBsRaIdX, A_5);
						}
					}
					return num;
				}

				// Token: 0x060010BC RID: 4284 RVA: 0x0005B204 File Offset: 0x00059404
				private int feiXOLIIrmnvqknyEHjAirZhAHdp(int A_1, CustomControllerMap A_2, ActionElementMap A_3, bool A_4 = false, bool A_5 = false, List<ActionElementMap> A_6 = null)
				{
					if (A_1 < 0 || A_3 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						if (this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).VLnBmkNlWHuWGKNvpysrhMLAvwWA.id == A_1)
						{
							num += this.vPgNdtIhtEHWnwmHbeKyMBtXnkKw<CustomControllerMap>(ControllerType.Custom, A_1, A_2, A_3, A_4, A_5, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).SYeOZTgTBzpCRvaSMSDtNBsRaIdX, A_6);
						}
					}
					return num;
				}

				// Token: 0x060010BD RID: 4285 RVA: 0x0005B280 File Offset: 0x00059480
				private int RVuGloKvzzwIwJkxVZAymXYpbQCe(ElementAssignmentConflictCheck A_1, bool A_2 = false, bool A_3 = false, List<ActionElementMap> A_4 = null)
				{
					if (A_1.controllerId < 0 || A_1.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						if (this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).VLnBmkNlWHuWGKNvpysrhMLAvwWA.id == A_1.controllerId)
						{
							num += this.XDsmkWsuWRuusDiDKGclOXTkggyC<CustomControllerMap>(A_1, A_2, A_3, this.EpMVjtvWcdcxdtciBHAmGgFvYELq.iTsNyOKxlQOyyWXaASlipXGJRPTN.qzZhSNqgFLaSMguabDuaPHoOFBwG(i).SYeOZTgTBzpCRvaSMSDtNBsRaIdX, A_4);
						}
					}
					return num;
				}

				// Token: 0x060010BE RID: 4286 RVA: 0x0005B30C File Offset: 0x0005950C
				private bool QyxTFfQiNWOSbRGJCGcjcNihrTdI<\u0001>(ControllerType A_1, int A_2, \u0001 A_3, bool A_4, bool A_5, VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<\u0001> A_6) where \u0001 : ControllerMap
				{
					if (A_6 == null || A_3 == null)
					{
						return false;
					}
					InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(A_3.categoryId);
					if (mapCategory == null)
					{
						return false;
					}
					for (int i = 0; i < A_6.sSEkNHPvFzDptlNqDocRnDXFEYyY; i++)
					{
						ControllerMap controllerMap = A_6.ZEabTYdmnsjYhGfIgxpgnyvGMRBRA(i);
						if ((!A_4 || controllerMap.enabled) && (A_5 || !this.ZeuZdBxFDWieyIaFwJYCiioMoBEp(mapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(A_3, A_4))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x060010BF RID: 4287 RVA: 0x0005B390 File Offset: 0x00059590
				private bool YFanebquYcdbUCFLpiPGigFhSRSTA<\u0001>(ControllerType A_1, int A_2, \u0001 A_3, ActionElementMap A_4, bool A_5, bool A_6, VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<\u0001> A_7) where \u0001 : ControllerMap
				{
					if (A_7 == null || A_4 == null)
					{
						return false;
					}
					InputMapCategory inputMapCategory = (A_3 != null) ? ReInput.mapping.GetMapCategory(A_3.categoryId) : null;
					for (int i = 0; i < A_7.sSEkNHPvFzDptlNqDocRnDXFEYyY; i++)
					{
						ControllerMap controllerMap = A_7.ZEabTYdmnsjYhGfIgxpgnyvGMRBRA(i);
						if ((!A_5 || controllerMap.enabled) && (A_6 || !this.ZeuZdBxFDWieyIaFwJYCiioMoBEp(inputMapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(A_4, A_5))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x060010C0 RID: 4288 RVA: 0x0005B414 File Offset: 0x00059614
				private bool jxEdlcATDmGFRwmCWDkAEXEGhdSuA<\u0001>(ElementAssignmentConflictCheck A_1, bool A_2, bool A_3, VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<\u0001> A_4) where \u0001 : ControllerMap
				{
					if (A_4 == null)
					{
						return false;
					}
					Player player = ReInput.players.GetPlayer(A_1.playerId);
					if (player == null)
					{
						return false;
					}
					ControllerMap map = player.controllers.maps.GetMap(A_1.controllerType, A_1.controllerId, A_1.controllerMapId);
					InputMapCategory inputMapCategory = (map != null) ? ReInput.mapping.GetMapCategory(map.categoryId) : ReInput.mapping.GetMapCategory(A_1.controllerMapCategoryId);
					if (inputMapCategory == null)
					{
						return false;
					}
					for (int i = 0; i < A_4.sSEkNHPvFzDptlNqDocRnDXFEYyY; i++)
					{
						ControllerMap controllerMap = A_4.ZEabTYdmnsjYhGfIgxpgnyvGMRBRA(i);
						if ((!A_2 || controllerMap.enabled) && (A_3 || !this.ZeuZdBxFDWieyIaFwJYCiioMoBEp(inputMapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(A_1, A_2))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x060010C1 RID: 4289 RVA: 0x0000EDD7 File Offset: 0x0000CFD7
				private IEnumerable<ElementAssignmentConflictInfo> fvQkETtLPcJJShqXGewgxhHGbtjcA<\u0001>(ControllerType A_1, int A_2, \u0001 A_3, bool A_4, bool A_5, VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<\u0001> A_6) where \u0001 : ControllerMap
				{
					if (A_6 == null || A_3 == null)
					{
						yield break;
					}
					InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(A_3.categoryId);
					if (mapCategory == null)
					{
						yield break;
					}
					int num;
					for (int i = 0; i < A_6.sSEkNHPvFzDptlNqDocRnDXFEYyY; i = num + 1)
					{
						ControllerMap controllerMap = A_6.ZEabTYdmnsjYhGfIgxpgnyvGMRBRA(i);
						if ((!A_4 || controllerMap.enabled) && (A_5 || !this.ZeuZdBxFDWieyIaFwJYCiioMoBEp(mapCategory, controllerMap)))
						{
							foreach (ElementAssignmentConflictInfo elementAssignmentConflictInfo in controllerMap.ElementAssignmentConflicts(A_3, A_4))
							{
								yield return new ElementAssignmentConflictInfo(elementAssignmentConflictInfo)
								{
									playerId = this.vRUwEnQNNSatwHRdEGApkiuClUuhA.slhAWVVynuDdrqbdGKDoRVmsCDYo,
									controllerType = A_1,
									controllerId = A_2
								};
							}
							IEnumerator<ElementAssignmentConflictInfo> enumerator = null;
						}
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x060010C2 RID: 4290 RVA: 0x0005B4DC File Offset: 0x000596DC
				private IEnumerable<ElementAssignmentConflictInfo> BbDqZDKyJRbCoOEDKdXdvDbSScvK<\u0001>(ControllerType A_1, int A_2, \u0001 A_3, ActionElementMap A_4, bool A_5, bool A_6, VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<\u0001> A_7) where \u0001 : ControllerMap
				{
					if (A_7 == null || A_4 == null)
					{
						yield break;
					}
					InputMapCategory inputMapCategory = (A_3 != null) ? ReInput.mapping.GetMapCategory(A_3.categoryId) : null;
					int num;
					for (int i = 0; i < A_7.sSEkNHPvFzDptlNqDocRnDXFEYyY; i = num + 1)
					{
						ControllerMap controllerMap = A_7.ZEabTYdmnsjYhGfIgxpgnyvGMRBRA(i);
						if ((!A_5 || controllerMap.enabled) && (A_6 || !this.ZeuZdBxFDWieyIaFwJYCiioMoBEp(inputMapCategory, controllerMap)))
						{
							foreach (ElementAssignmentConflictInfo elementAssignmentConflictInfo in controllerMap.ElementAssignmentConflicts(A_4, A_5))
							{
								yield return new ElementAssignmentConflictInfo(elementAssignmentConflictInfo)
								{
									playerId = this.vRUwEnQNNSatwHRdEGApkiuClUuhA.slhAWVVynuDdrqbdGKDoRVmsCDYo,
									controllerType = A_1,
									controllerId = A_2
								};
							}
							IEnumerator<ElementAssignmentConflictInfo> enumerator = null;
						}
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x060010C3 RID: 4291 RVA: 0x0000EE14 File Offset: 0x0000D014
				private IEnumerable<ElementAssignmentConflictInfo> uutlECJfhoBKtKyYPUfUMaSZoZTsA<\u0001>(ElementAssignmentConflictCheck A_1, bool A_2, bool A_3, VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<\u0001> A_4) where \u0001 : ControllerMap
				{
					if (A_4 == null)
					{
						yield break;
					}
					Player player = ReInput.players.GetPlayer(A_1.playerId);
					if (player == null)
					{
						yield break;
					}
					ControllerMap map = player.controllers.maps.GetMap(A_1.controllerType, A_1.controllerId, A_1.controllerMapId);
					InputMapCategory inputMapCategory = (map != null) ? ReInput.mapping.GetMapCategory(map.categoryId) : ReInput.mapping.GetMapCategory(A_1.controllerMapCategoryId);
					if (inputMapCategory == null)
					{
						yield break;
					}
					int num;
					for (int i = 0; i < A_4.sSEkNHPvFzDptlNqDocRnDXFEYyY; i = num + 1)
					{
						ControllerMap controllerMap = A_4.ZEabTYdmnsjYhGfIgxpgnyvGMRBRA(i);
						if ((!A_2 || controllerMap.enabled) && (A_3 || !this.ZeuZdBxFDWieyIaFwJYCiioMoBEp(inputMapCategory, controllerMap)))
						{
							foreach (ElementAssignmentConflictInfo elementAssignmentConflictInfo in controllerMap.ElementAssignmentConflicts(A_1, A_2))
							{
								yield return new ElementAssignmentConflictInfo(elementAssignmentConflictInfo)
								{
									playerId = this.vRUwEnQNNSatwHRdEGApkiuClUuhA.slhAWVVynuDdrqbdGKDoRVmsCDYo,
									controllerType = A_1.controllerType,
									controllerId = A_1.controllerId
								};
							}
							IEnumerator<ElementAssignmentConflictInfo> enumerator = null;
						}
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x060010C4 RID: 4292 RVA: 0x0005B52C File Offset: 0x0005972C
				private int KuNAUgcoSOgRMpZSYnGPEOzykFURA<\u0001>(ControllerType A_1, int A_2, \u0001 A_3, bool A_4, bool A_5, VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<\u0001> A_6) where \u0001 : ControllerMap
				{
					if (A_6 == null || A_3 == null)
					{
						return 0;
					}
					InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(A_3.categoryId);
					if (mapCategory == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < A_6.sSEkNHPvFzDptlNqDocRnDXFEYyY; i++)
					{
						ControllerMap controllerMap = A_6.ZEabTYdmnsjYhGfIgxpgnyvGMRBRA(i);
						if ((!A_4 || controllerMap.enabled) && (A_5 || !this.ZeuZdBxFDWieyIaFwJYCiioMoBEp(mapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(A_3, A_4);
						}
					}
					return num;
				}

				// Token: 0x060010C5 RID: 4293 RVA: 0x0005B5B0 File Offset: 0x000597B0
				private int YFrRtRWAyFdWDQpSziTHTChnyerC<\u0001>(ControllerType A_1, int A_2, \u0001 A_3, ActionElementMap A_4, bool A_5, bool A_6, VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<\u0001> A_7) where \u0001 : ControllerMap
				{
					if (A_7 == null || A_4 == null)
					{
						return 0;
					}
					InputMapCategory inputMapCategory = (A_3 != null) ? ReInput.mapping.GetMapCategory(A_3.categoryId) : null;
					int num = 0;
					for (int i = 0; i < A_7.sSEkNHPvFzDptlNqDocRnDXFEYyY; i++)
					{
						ControllerMap controllerMap = A_7.ZEabTYdmnsjYhGfIgxpgnyvGMRBRA(i);
						if ((!A_5 || controllerMap.enabled) && (A_6 || !this.ZeuZdBxFDWieyIaFwJYCiioMoBEp(inputMapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(A_4, A_5);
						}
					}
					return num;
				}

				// Token: 0x060010C6 RID: 4294 RVA: 0x0005B634 File Offset: 0x00059834
				private int nKEaolEAUswugblKlKqhvfcSdROW<\u0001>(ElementAssignmentConflictCheck A_1, bool A_2, bool A_3, VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<\u0001> A_4) where \u0001 : ControllerMap
				{
					if (A_4 == null)
					{
						return 0;
					}
					Player player = ReInput.players.GetPlayer(A_1.playerId);
					if (player == null)
					{
						return 0;
					}
					ControllerMap map = player.controllers.maps.GetMap(A_1.controllerType, A_1.controllerId, A_1.controllerMapId);
					InputMapCategory inputMapCategory = (map != null) ? ReInput.mapping.GetMapCategory(map.categoryId) : ReInput.mapping.GetMapCategory(A_1.controllerMapCategoryId);
					if (inputMapCategory == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < A_4.sSEkNHPvFzDptlNqDocRnDXFEYyY; i++)
					{
						ControllerMap controllerMap = A_4.ZEabTYdmnsjYhGfIgxpgnyvGMRBRA(i);
						if ((!A_2 || controllerMap.enabled) && (A_3 || !this.ZeuZdBxFDWieyIaFwJYCiioMoBEp(inputMapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(A_1, A_2);
						}
					}
					return num;
				}

				// Token: 0x060010C7 RID: 4295 RVA: 0x0005B700 File Offset: 0x00059900
				private int yAwfPmeFVjHOpDZQVLiVAJpDhluBB<\u0001>(ControllerType A_1, int A_2, \u0001 A_3, bool A_4, bool A_5, VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<\u0001> A_6, List<ActionElementMap> A_7 = null) where \u0001 : ControllerMap
				{
					if (A_7 != null)
					{
						A_7.Clear();
					}
					if (A_6 == null || A_3 == null)
					{
						return 0;
					}
					InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(A_3.categoryId);
					if (mapCategory == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < A_6.sSEkNHPvFzDptlNqDocRnDXFEYyY; i++)
					{
						ControllerMap controllerMap = A_6.ZEabTYdmnsjYhGfIgxpgnyvGMRBRA(i);
						if ((!A_4 || controllerMap.enabled) && (A_5 || !this.ZeuZdBxFDWieyIaFwJYCiioMoBEp(mapCategory, controllerMap)))
						{
							num += controllerMap.oYfeUUNDbOWfjygZOQmLKPGJhOMf(A_3, A_4, A_7, true);
						}
					}
					return num;
				}

				// Token: 0x060010C8 RID: 4296 RVA: 0x0005B794 File Offset: 0x00059994
				private int vPgNdtIhtEHWnwmHbeKyMBtXnkKw<\u0001>(ControllerType A_1, int A_2, \u0001 A_3, ActionElementMap A_4, bool A_5, bool A_6, VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<\u0001> A_7, List<ActionElementMap> A_8 = null) where \u0001 : ControllerMap
				{
					if (A_8 != null)
					{
						A_8.Clear();
					}
					if (A_7 == null || A_4 == null)
					{
						return 0;
					}
					InputMapCategory inputMapCategory = (A_3 != null) ? ReInput.mapping.GetMapCategory(A_3.categoryId) : null;
					int num = 0;
					for (int i = 0; i < A_7.sSEkNHPvFzDptlNqDocRnDXFEYyY; i++)
					{
						ControllerMap controllerMap = A_7.ZEabTYdmnsjYhGfIgxpgnyvGMRBRA(i);
						if ((!A_5 || controllerMap.enabled) && (A_6 || !this.ZeuZdBxFDWieyIaFwJYCiioMoBEp(inputMapCategory, controllerMap)))
						{
							num += controllerMap.iYObeNDzWBShOCtJrwtrYgvLbQKU(A_4, A_5, A_8, true);
						}
					}
					return num;
				}

				// Token: 0x060010C9 RID: 4297 RVA: 0x0005B824 File Offset: 0x00059A24
				private int XDsmkWsuWRuusDiDKGclOXTkggyC<\u0001>(ElementAssignmentConflictCheck A_1, bool A_2, bool A_3, VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<\u0001> A_4, List<ActionElementMap> A_5 = null) where \u0001 : ControllerMap
				{
					if (A_5 != null)
					{
						A_5.Clear();
					}
					if (A_4 == null)
					{
						return 0;
					}
					Player player = ReInput.players.GetPlayer(A_1.playerId);
					if (player == null)
					{
						return 0;
					}
					ControllerMap map = player.controllers.maps.GetMap(A_1.controllerType, A_1.controllerId, A_1.controllerMapId);
					InputMapCategory inputMapCategory = (map != null) ? ReInput.mapping.GetMapCategory(map.categoryId) : ReInput.mapping.GetMapCategory(A_1.controllerMapCategoryId);
					if (inputMapCategory == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < A_4.sSEkNHPvFzDptlNqDocRnDXFEYyY; i++)
					{
						ControllerMap controllerMap = A_4.ZEabTYdmnsjYhGfIgxpgnyvGMRBRA(i);
						if ((!A_2 || controllerMap.enabled) && (A_3 || !this.ZeuZdBxFDWieyIaFwJYCiioMoBEp(inputMapCategory, controllerMap)))
						{
							num += controllerMap.CgqGVjNDzTEOuNcIRWhWJMfOvNov(A_1, A_2, A_5, true);
						}
					}
					return num;
				}

				// Token: 0x060010CA RID: 4298 RVA: 0x0005B900 File Offset: 0x00059B00
				private bool ZeuZdBxFDWieyIaFwJYCiioMoBEp(InputMapCategory A_1, ControllerMap A_2)
				{
					if (A_1 == null || A_2 == null)
					{
						return false;
					}
					if (A_1.checkConflictsWithAllCategories)
					{
						return false;
					}
					IList<int> checkConflictsCategoryIds = A_1.checkConflictsCategoryIds;
					if (checkConflictsCategoryIds == null)
					{
						return true;
					}
					for (int i = 0; i < checkConflictsCategoryIds.Count; i++)
					{
						if (checkConflictsCategoryIds[i] == A_2.categoryId)
						{
							return false;
						}
					}
					return true;
				}

				// Token: 0x04000971 RID: 2417
				private readonly Player vRUwEnQNNSatwHRdEGApkiuClUuhA;

				// Token: 0x04000972 RID: 2418
				private readonly Player.ControllerHelper EpMVjtvWcdcxdtciBHAmGgFvYELq;

				// Token: 0x04000973 RID: 2419
				private readonly int vxgeDuGozQdSzFaQikkskkPnenXQB;
			}

			// Token: 0x02000176 RID: 374
			[DefaultMember("Item")]
			internal interface rrrUVbResWNdbXKvkkOIseeimvIu
			{
				// Token: 0x17000485 RID: 1157
				// (get) Token: 0x0600111C RID: 4380
				Player.ControllerHelper.aDTWAvwJDeCLlGzuGUJORYARFABdA gDtyZlobpqUEpDNZMOFSrRYLdArf { get; }

				// Token: 0x17000486 RID: 1158
				// (get) Token: 0x0600111D RID: 4381
				ControllerType YqJDvHgFHfvJYikSetxahzcXYAWHA { get; }

				// Token: 0x17000487 RID: 1159
				// (get) Token: 0x0600111E RID: 4382
				int hUvoPojtJZIUBnFkCGjslfijGbmL { get; }

				// Token: 0x0600111F RID: 4383
				bool EiqDOyVjTnCvkHCDGOuBpIfmEeYgA(Controller);

				// Token: 0x06001120 RID: 4384
				bool MouplaShCfFxRczQNCMHkYFFsxzk(int);

				// Token: 0x06001121 RID: 4385
				void zIQhlCMPSQSndGAHGFJypOxttTbY(int);

				// Token: 0x06001122 RID: 4386
				void gOApPGSYnBqNLIAiPBtyCjARLrhK(Controller);

				// Token: 0x06001123 RID: 4387
				void ItkdmbguvOkrtbCyCIuXaTmsQPPYB(int);

				// Token: 0x06001124 RID: 4388
				Controller lmFqlCGyYlAWBPNeInDqnuyRDBxi(int);

				// Token: 0x06001125 RID: 4389
				Controller aOQBhrWxqyVDNyjiLDwicPaZxxRHA(string);

				// Token: 0x06001126 RID: 4390
				int ShlWNHSdinxSkfVOEKODDDlVNPKt(Controller);

				// Token: 0x06001127 RID: 4391
				int jVtFwimrOgSFQQoYBDWYmPSvkaPH(int);

				// Token: 0x06001128 RID: 4392
				int VgpmOnOQEHdBzRMHtXckRGgEATgv(string);

				// Token: 0x06001129 RID: 4393
				void izaQsiOxyWlYEixsJcHFbgGchzEA();

				// Token: 0x0600112A RID: 4394
				Player.ControllerHelper.aDTWAvwJDeCLlGzuGUJORYARFABdA cLCIFSrSsIdpuGCXMXmeTmizjypZ(int);

				// Token: 0x0600112B RID: 4395
				Player.ControllerHelper.aDTWAvwJDeCLlGzuGUJORYARFABdA TxWLRNtHlXEVLNrlphQggYNzVEXPA(Controller);

				// Token: 0x0600112C RID: 4396
				void IzYGrObDjVkjIdGRCklKKIDTLJItA(Player.ControllerHelper.aDTWAvwJDeCLlGzuGUJORYARFABdA);
			}

			// Token: 0x02000177 RID: 375
			internal interface aDTWAvwJDeCLlGzuGUJORYARFABdA
			{
				// Token: 0x17000488 RID: 1160
				// (get) Token: 0x0600112D RID: 4397
				dBWjOjXnFJmUROzCVhQpynliVgPI AxzIHFaeuZajYboPHuvsfCYAXoQwA { get; }

				// Token: 0x17000489 RID: 1161
				// (get) Token: 0x0600112E RID: 4398
				Controller PBJHfnhJKAlWfSVgUYDoQBOBahDP { get; }

				// Token: 0x1700048A RID: 1162
				// (get) Token: 0x0600112F RID: 4399
				double SPyuFlXcCdXFNvHtLKsnEWxndtWR { get; }
			}

			// Token: 0x02000178 RID: 376
			[DefaultMember("Item")]
			internal sealed class njAlpuqmuMmkinJFduspVuiWfiHi<\u0001, \u0002> : Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu where \u0001 : Controller where \u0002 : ControllerMap
			{
				// Token: 0x1700048B RID: 1163
				// (get) Token: 0x06001130 RID: 4400 RVA: 0x0000F12C File Offset: 0x0000D32C
				public int hUvoPojtJZIUBnFkCGjslfijGbmL
				{
					get
					{
						return this.kwYmgxEpabiyIfHRPJmOngVINpRrA.Count;
					}
				}

				// Token: 0x1700048C RID: 1164
				// (get) Token: 0x06001131 RID: 4401 RVA: 0x0000F139 File Offset: 0x0000D339
				public IList<\u0001> NxlJdafVlRhoHuADzQEVEdFdHwPV
				{
					get
					{
						return this.IqlnlJeadKPcfgudMohDLbbaXTkT;
					}
				}

				// Token: 0x1700048D RID: 1165
				// (get) Token: 0x06001132 RID: 4402 RVA: 0x0000F141 File Offset: 0x0000D341
				public Player<\u0001, \u0002>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi.gkFtqSotlvjTxqHWDAWBgsGdsVUL nWaBagbaTjiPbBBUtjNJoSMeagjLA
				{
					get
					{
						return this.kwYmgxEpabiyIfHRPJmOngVINpRrA[A_1];
					}
				}

				// Token: 0x1700048E RID: 1166
				// (get) Token: 0x06001133 RID: 4403 RVA: 0x0000F14F File Offset: 0x0000D34F
				public ControllerType YqJDvHgFHfvJYikSetxahzcXYAWHA
				{
					get
					{
						return this.vlHyhnZAIFTBSijAfWCdwDGLAaEkA;
					}
				}

				// Token: 0x06001134 RID: 4404 RVA: 0x0005CDC4 File Offset: 0x0005AFC4
				public njAlpuqmuMmkinJFduspVuiWfiHi()
				{
					if (gRvITEHjKMrWaeGYEmAHofbpCtEU.EeMmiIkEapZUqdAqUEWYTsiNMKbx<\u0001>() != typeof(\u0002))
					{
						throw new Exception(typeof(\u0001).Name + " cannot be used with a map of type " + typeof(\u0002).Name);
					}
					this.vlHyhnZAIFTBSijAfWCdwDGLAaEkA = gRvITEHjKMrWaeGYEmAHofbpCtEU.FrCGQHeNlNaEnggvcvdFMaQdjVCLd(typeof(\u0001));
					this.kwYmgxEpabiyIfHRPJmOngVINpRrA = new List<Player<\u0001, \u0002>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi.gkFtqSotlvjTxqHWDAWBgsGdsVUL>();
					this.ApQuUIjXJkXmEXyHUMiphlUhPpDd = new List<\u0001>();
					this.IqlnlJeadKPcfgudMohDLbbaXTkT = new ReadOnlyCollection<\u0001>(this.ApQuUIjXJkXmEXyHUMiphlUhPpDd);
				}

				// Token: 0x06001135 RID: 4405 RVA: 0x0005CE54 File Offset: 0x0005B054
				public Player<\u0001, \u0002>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi.gkFtqSotlvjTxqHWDAWBgsGdsVUL nmVRgKcDQQmewqLHNdZkNGlknHkI(int A_1)
				{
					if (this.vlHyhnZAIFTBSijAfWCdwDGLAaEkA == ControllerType.Keyboard || this.vlHyhnZAIFTBSijAfWCdwDGLAaEkA == ControllerType.Mouse)
					{
						A_1 = 0;
					}
					int num = this.pzNgccllSigsHuFaEAUiEPolIPOm(A_1);
					if (num < 0)
					{
						return null;
					}
					return this.kwYmgxEpabiyIfHRPJmOngVINpRrA[num];
				}

				// Token: 0x06001136 RID: 4406 RVA: 0x0000F157 File Offset: 0x0000D357
				public Player<\u0001, \u0002>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi.gkFtqSotlvjTxqHWDAWBgsGdsVUL VABSyNpacULbDarjjKtUwKEqIEWfA(\u0001 A_1)
				{
					if (A_1 == null)
					{
						return null;
					}
					return this.nmVRgKcDQQmewqLHNdZkNGlknHkI(A_1.id);
				}

				// Token: 0x06001137 RID: 4407 RVA: 0x0000F174 File Offset: 0x0000D374
				public void VFtSeXykcMsAFrDgTtNHVqeOMggl(Player<\u0001, \u0002>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi.gkFtqSotlvjTxqHWDAWBgsGdsVUL A_1)
				{
					if (A_1 == null)
					{
						return;
					}
					this.kwYmgxEpabiyIfHRPJmOngVINpRrA.Add(A_1);
					this.ApQuUIjXJkXmEXyHUMiphlUhPpDd.Add(A_1.VLnBmkNlWHuWGKNvpysrhMLAvwWA);
				}

				// Token: 0x06001138 RID: 4408 RVA: 0x0005CE90 File Offset: 0x0005B090
				public void DnSaJUCfYvQnbinguilNAqVdmuTqB(int A_1)
				{
					if (this.vlHyhnZAIFTBSijAfWCdwDGLAaEkA == ControllerType.Keyboard || this.vlHyhnZAIFTBSijAfWCdwDGLAaEkA == ControllerType.Mouse)
					{
						A_1 = 0;
					}
					if (this.pzNgccllSigsHuFaEAUiEPolIPOm(A_1) < 0)
					{
						return;
					}
					for (int i = 0; i < this.kwYmgxEpabiyIfHRPJmOngVINpRrA.Count; i++)
					{
						if (this.kwYmgxEpabiyIfHRPJmOngVINpRrA[i].VLnBmkNlWHuWGKNvpysrhMLAvwWA.id == A_1)
						{
							this.yzosvZyRQKgYlbpMGgXcDOnZZToi(i);
							return;
						}
					}
				}

				// Token: 0x06001139 RID: 4409 RVA: 0x0000F197 File Offset: 0x0000D397
				public void EmpEijDTtzsqZDncPLhpTmXdlGHWA(\u0001 A_1)
				{
					if (A_1 == null)
					{
						return;
					}
					if (A_1.type != this.vlHyhnZAIFTBSijAfWCdwDGLAaEkA)
					{
						return;
					}
					this.DnSaJUCfYvQnbinguilNAqVdmuTqB(A_1.id);
				}

				// Token: 0x0600113A RID: 4410 RVA: 0x0000F1C7 File Offset: 0x0000D3C7
				public void yzosvZyRQKgYlbpMGgXcDOnZZToi(int A_1)
				{
					if (A_1 < 0 || A_1 >= this.kwYmgxEpabiyIfHRPJmOngVINpRrA.Count)
					{
						return;
					}
					this.kwYmgxEpabiyIfHRPJmOngVINpRrA.RemoveAt(A_1);
					this.ApQuUIjXJkXmEXyHUMiphlUhPpDd.RemoveAt(A_1);
				}

				// Token: 0x0600113B RID: 4411 RVA: 0x0005CEF8 File Offset: 0x0005B0F8
				public \u0001 gaDAGriDHrZfIMsSGiwEunPWgbeF(int A_1)
				{
					if (this.vlHyhnZAIFTBSijAfWCdwDGLAaEkA == ControllerType.Keyboard || this.vlHyhnZAIFTBSijAfWCdwDGLAaEkA == ControllerType.Mouse)
					{
						A_1 = 0;
					}
					int num = this.pzNgccllSigsHuFaEAUiEPolIPOm(A_1);
					if (num < 0)
					{
						return default(\u0001);
					}
					return this.kwYmgxEpabiyIfHRPJmOngVINpRrA[num].VLnBmkNlWHuWGKNvpysrhMLAvwWA;
				}

				// Token: 0x0600113C RID: 4412 RVA: 0x0005CF40 File Offset: 0x0005B140
				public bool ZowByQcofSJpegmBTzpofApghkSAb(int A_1)
				{
					if (this.vlHyhnZAIFTBSijAfWCdwDGLAaEkA == ControllerType.Keyboard || this.vlHyhnZAIFTBSijAfWCdwDGLAaEkA == ControllerType.Mouse)
					{
						A_1 = 0;
					}
					if (A_1 < 0)
					{
						return false;
					}
					for (int i = 0; i < this.kwYmgxEpabiyIfHRPJmOngVINpRrA.Count; i++)
					{
						if (this.kwYmgxEpabiyIfHRPJmOngVINpRrA[i].VLnBmkNlWHuWGKNvpysrhMLAvwWA.id == A_1)
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x0600113D RID: 4413 RVA: 0x0000F1F4 File Offset: 0x0000D3F4
				public bool dKBsIBzIMcOFMxrkokXqgLpfAaHG(\u0001 A_1)
				{
					return A_1 != null && A_1.type == this.vlHyhnZAIFTBSijAfWCdwDGLAaEkA && this.ZowByQcofSJpegmBTzpofApghkSAb(A_1.id);
				}

				// Token: 0x0600113E RID: 4414 RVA: 0x0005CFA0 File Offset: 0x0005B1A0
				public int pzNgccllSigsHuFaEAUiEPolIPOm(int A_1)
				{
					if (this.vlHyhnZAIFTBSijAfWCdwDGLAaEkA == ControllerType.Keyboard || this.vlHyhnZAIFTBSijAfWCdwDGLAaEkA == ControllerType.Mouse)
					{
						A_1 = 0;
					}
					if (A_1 < 0)
					{
						return -1;
					}
					for (int i = 0; i < this.kwYmgxEpabiyIfHRPJmOngVINpRrA.Count; i++)
					{
						if (this.kwYmgxEpabiyIfHRPJmOngVINpRrA[i].VLnBmkNlWHuWGKNvpysrhMLAvwWA.id == A_1)
						{
							return i;
						}
					}
					return -1;
				}

				// Token: 0x0600113F RID: 4415 RVA: 0x0000F226 File Offset: 0x0000D426
				public int XfgIIqgAjJqIiOIGPyuEPcMLqkSw(\u0001 A_1)
				{
					if (A_1 == null)
					{
						return -1;
					}
					if (A_1.type != this.vlHyhnZAIFTBSijAfWCdwDGLAaEkA)
					{
						return -1;
					}
					return this.pzNgccllSigsHuFaEAUiEPolIPOm(A_1.id);
				}

				// Token: 0x06001140 RID: 4416 RVA: 0x0005D000 File Offset: 0x0005B200
				public int SDOwRRMeHlRfYEikeInsEoUREgqkA(string A_1)
				{
					if (A_1 == null || A_1 == string.Empty)
					{
						return -1;
					}
					for (int i = 0; i < this.kwYmgxEpabiyIfHRPJmOngVINpRrA.Count; i++)
					{
						if (this.kwYmgxEpabiyIfHRPJmOngVINpRrA[i].VLnBmkNlWHuWGKNvpysrhMLAvwWA.tag.Equals(A_1, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				// Token: 0x06001141 RID: 4417 RVA: 0x0000F258 File Offset: 0x0000D458
				public void BFtFQuKJPvDmowVfZvDZUjthHpWgb()
				{
					this.kwYmgxEpabiyIfHRPJmOngVINpRrA.Clear();
					this.ApQuUIjXJkXmEXyHUMiphlUhPpDd.Clear();
				}

				// Token: 0x1700048F RID: 1167
				// (get) Token: 0x06001142 RID: 4418 RVA: 0x0000F141 File Offset: 0x0000D341
				Player.ControllerHelper.aDTWAvwJDeCLlGzuGUJORYARFABdA Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu.bOLqOKWLKGsDVLxNWvbKcccHbYpcA
				{
					get
					{
						return this.kwYmgxEpabiyIfHRPJmOngVINpRrA[index];
					}
				}

				// Token: 0x06001143 RID: 4419 RVA: 0x0000F270 File Offset: 0x0000D470
				Player.ControllerHelper.aDTWAvwJDeCLlGzuGUJORYARFABdA Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu.GetEntry(int controllerId)
				{
					return this.nmVRgKcDQQmewqLHNdZkNGlknHkI(controllerId);
				}

				// Token: 0x06001144 RID: 4420 RVA: 0x0000F279 File Offset: 0x0000D479
				Player.ControllerHelper.aDTWAvwJDeCLlGzuGUJORYARFABdA Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu.GetEntry(Controller controller)
				{
					if (!(controller is \u0001))
					{
						return null;
					}
					return this.VABSyNpacULbDarjjKtUwKEqIEWfA(controller as \u0001);
				}

				// Token: 0x06001145 RID: 4421 RVA: 0x0000F2A0 File Offset: 0x0000D4A0
				void Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu.AddEntry(Player.ControllerHelper.aDTWAvwJDeCLlGzuGUJORYARFABdA entry)
				{
					this.VFtSeXykcMsAFrDgTtNHVqeOMggl((Player<\u0001, \u0002>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi.gkFtqSotlvjTxqHWDAWBgsGdsVUL)entry);
				}

				// Token: 0x06001146 RID: 4422 RVA: 0x0000F2AE File Offset: 0x0000D4AE
				void Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu.RemoveController(Controller controller)
				{
					this.EmpEijDTtzsqZDncPLhpTmXdlGHWA(controller as \u0001);
				}

				// Token: 0x06001147 RID: 4423 RVA: 0x0000F2C1 File Offset: 0x0000D4C1
				Controller Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu.GetController(int controllerId)
				{
					return this.gaDAGriDHrZfIMsSGiwEunPWgbeF(controllerId);
				}

				// Token: 0x06001148 RID: 4424 RVA: 0x0000F2CF File Offset: 0x0000D4CF
				bool Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu.Contains(Controller controller)
				{
					return this.dKBsIBzIMcOFMxrkokXqgLpfAaHG(controller as \u0001);
				}

				// Token: 0x06001149 RID: 4425 RVA: 0x0000F2E2 File Offset: 0x0000D4E2
				int Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu.IndexOf(Controller controller)
				{
					return this.XfgIIqgAjJqIiOIGPyuEPcMLqkSw(controller as \u0001);
				}

				// Token: 0x0600114A RID: 4426 RVA: 0x0005D05C File Offset: 0x0005B25C
				Controller Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu.GetControllerWithTag(string tag)
				{
					int num = this.SDOwRRMeHlRfYEikeInsEoUREgqkA(tag);
					if (num < 0)
					{
						return null;
					}
					return this.kwYmgxEpabiyIfHRPJmOngVINpRrA[num].VLnBmkNlWHuWGKNvpysrhMLAvwWA;
				}

				// Token: 0x040009FF RID: 2559
				private List<Player<\u0001, \u0002>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi.gkFtqSotlvjTxqHWDAWBgsGdsVUL> kwYmgxEpabiyIfHRPJmOngVINpRrA;

				// Token: 0x04000A00 RID: 2560
				private List<\u0001> ApQuUIjXJkXmEXyHUMiphlUhPpDd;

				// Token: 0x04000A01 RID: 2561
				private ReadOnlyCollection<\u0001> IqlnlJeadKPcfgudMohDLbbaXTkT;

				// Token: 0x04000A02 RID: 2562
				private readonly ControllerType vlHyhnZAIFTBSijAfWCdwDGLAaEkA;

				// Token: 0x02000179 RID: 377
				public class gkFtqSotlvjTxqHWDAWBgsGdsVUL : Player.ControllerHelper.aDTWAvwJDeCLlGzuGUJORYARFABdA
				{
					// Token: 0x17000490 RID: 1168
					// (get) Token: 0x0600114B RID: 4427 RVA: 0x0000F2F5 File Offset: 0x0000D4F5
					Controller Player.ControllerHelper.aDTWAvwJDeCLlGzuGUJORYARFABdA.VWxgCHvpJAFQTYYLwlgWsSgGwOnc
					{
						get
						{
							return this.VLnBmkNlWHuWGKNvpysrhMLAvwWA;
						}
					}

					// Token: 0x17000491 RID: 1169
					// (get) Token: 0x0600114C RID: 4428 RVA: 0x0000F302 File Offset: 0x0000D502
					dBWjOjXnFJmUROzCVhQpynliVgPI Player.ControllerHelper.aDTWAvwJDeCLlGzuGUJORYARFABdA.YXmGMrpPlQbouGMgiYqJvTirWmtS
					{
						get
						{
							return this.SYeOZTgTBzpCRvaSMSDtNBsRaIdX;
						}
					}

					// Token: 0x17000492 RID: 1170
					// (get) Token: 0x0600114D RID: 4429 RVA: 0x0000F30A File Offset: 0x0000D50A
					double Player.ControllerHelper.aDTWAvwJDeCLlGzuGUJORYARFABdA.WMGDnDifvrhjDKTMNSFhUlGSLriDA
					{
						get
						{
							return this.LEfcjJVaLdryzDpqqgVgZLBikcmL;
						}
					}

					// Token: 0x0600114E RID: 4430 RVA: 0x0000F312 File Offset: 0x0000D512
					public gkFtqSotlvjTxqHWDAWBgsGdsVUL(\u0001 A_1, VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<\u0002> A_2)
					{
						this.VLnBmkNlWHuWGKNvpysrhMLAvwWA = A_1;
						this.SYeOZTgTBzpCRvaSMSDtNBsRaIdX = A_2;
					}

					// Token: 0x0600114F RID: 4431 RVA: 0x0000F328 File Offset: 0x0000D528
					public void uaEfQbAhtXZGrUkNFqyJhBwdFZRC()
					{
						this.LEfcjJVaLdryzDpqqgVgZLBikcmL = ReInput.unscaledTime;
					}

					// Token: 0x04000A03 RID: 2563
					public \u0001 VLnBmkNlWHuWGKNvpysrhMLAvwWA;

					// Token: 0x04000A04 RID: 2564
					public VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<\u0002> SYeOZTgTBzpCRvaSMSDtNBsRaIdX;

					// Token: 0x04000A05 RID: 2565
					public double LEfcjJVaLdryzDpqqgVgZLBikcmL;
				}
			}

			// Token: 0x0200017A RID: 378
			internal class rrwhAMAJavPyFelmoWqKjwiNpysP
			{
				// Token: 0x06001150 RID: 4432 RVA: 0x0000F335 File Offset: 0x0000D535
				public Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu CtGoIeauMpKsCXqilTCeQCxqyY(int A_1)
				{
					return this.DXJEspfjgLQGVVsTyhiwNZOHcVmSA[A_1];
				}

				// Token: 0x06001151 RID: 4433 RVA: 0x0000F33F File Offset: 0x0000D53F
				public ControllerType vZrGQvFMXtMVZgyvAVXhqFNCtgsMB(int A_1)
				{
					return this.MVuWBsxdaEVLjxMIJHxlACorHIBBb[A_1];
				}

				// Token: 0x06001152 RID: 4434 RVA: 0x0000F349 File Offset: 0x0000D549
				public rrwhAMAJavPyFelmoWqKjwiNpysP(int A_1)
				{
					this.ePoqkUtmPVaqcSRQDEsmWDfPnprd = MathTools.Max(0, A_1);
					this.MVuWBsxdaEVLjxMIJHxlACorHIBBb = new ControllerType[A_1];
					this.DXJEspfjgLQGVVsTyhiwNZOHcVmSA = new Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu[A_1];
				}

				// Token: 0x06001153 RID: 4435 RVA: 0x0005D090 File Offset: 0x0005B290
				public Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu kyfmYKkxmjPxLLdneuEkZIEuZdkx(ControllerType A_1)
				{
					for (int i = 0; i < this.ePoqkUtmPVaqcSRQDEsmWDfPnprd; i++)
					{
						if (A_1 == this.MVuWBsxdaEVLjxMIJHxlACorHIBBb[i])
						{
							return this.DXJEspfjgLQGVVsTyhiwNZOHcVmSA[i];
						}
					}
					throw new Exception("Value is not in the set.");
				}

				// Token: 0x06001154 RID: 4436 RVA: 0x0000F376 File Offset: 0x0000D576
				public void KkyiJfnnmfZsDyVJdMMuGYQxUveM(int A_1, ControllerType A_2, Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu A_3)
				{
					this.MVuWBsxdaEVLjxMIJHxlACorHIBBb[A_1] = A_2;
					this.DXJEspfjgLQGVVsTyhiwNZOHcVmSA[A_1] = A_3;
				}

				// Token: 0x04000A06 RID: 2566
				public readonly int ePoqkUtmPVaqcSRQDEsmWDfPnprd;

				// Token: 0x04000A07 RID: 2567
				private ControllerType[] MVuWBsxdaEVLjxMIJHxlACorHIBBb;

				// Token: 0x04000A08 RID: 2568
				private Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu[] DXJEspfjgLQGVVsTyhiwNZOHcVmSA;
			}

			// Token: 0x0200017B RID: 379
			private class qIXNxngxvPnyUKiwJbWeyVtlOaCm
			{
				// Token: 0x06001155 RID: 4437 RVA: 0x0000F38A File Offset: 0x0000D58A
				public qIXNxngxvPnyUKiwJbWeyVtlOaCm(Player A_1)
				{
					this.SwGMuQqfASiDTbGZTdKtoFgbmMGCA = A_1;
					this.ntgCyvWDCpanRSgrcrBiPnyAaWki = new List<Player.ControllerHelper.qIXNxngxvPnyUKiwJbWeyVtlOaCm.SBUTVOjkKRydKuamilavnmYyifhN>();
				}

				// Token: 0x06001156 RID: 4438 RVA: 0x0005D0CC File Offset: 0x0005B2CC
				public void OSpHixUgfVcOzstdFHaDJSJOYLpe(Joystick A_1, VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<JoystickMap> A_2)
				{
					for (int i = 0; i < this.ntgCyvWDCpanRSgrcrBiPnyAaWki.Count; i++)
					{
						Player.ControllerHelper.qIXNxngxvPnyUKiwJbWeyVtlOaCm.SBUTVOjkKRydKuamilavnmYyifhN sbutvojkKRydKuamilavnmYyifhN = this.ntgCyvWDCpanRSgrcrBiPnyAaWki[i];
						if (sbutvojkKRydKuamilavnmYyifhN.ipPeWzrJFFMxJFrgWTTebBRiaJSD == A_1.id)
						{
							sbutvojkKRydKuamilavnmYyifhN.XqDcLyUoffRXyNWIyZaySFVCatgy = A_2;
							sbutvojkKRydKuamilavnmYyifhN.eihGLCkYTaYNHHQZjpkfODUzbLTCb = ReInput.realTime;
							return;
						}
					}
					Player.ControllerHelper.qIXNxngxvPnyUKiwJbWeyVtlOaCm.SBUTVOjkKRydKuamilavnmYyifhN item = new Player.ControllerHelper.qIXNxngxvPnyUKiwJbWeyVtlOaCm.SBUTVOjkKRydKuamilavnmYyifhN(A_1.id, A_2, ReInput.realTime);
					this.ntgCyvWDCpanRSgrcrBiPnyAaWki.Add(item);
				}

				// Token: 0x06001157 RID: 4439 RVA: 0x0000F3A4 File Offset: 0x0000D5A4
				public void UMdBTMWAvxdMLLijvRbZwPbrsvr(Player<Joystick, JoystickMap>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi.gkFtqSotlvjTxqHWDAWBgsGdsVUL A_1)
				{
					this.OSpHixUgfVcOzstdFHaDJSJOYLpe(A_1.VLnBmkNlWHuWGKNvpysrhMLAvwWA, A_1.SYeOZTgTBzpCRvaSMSDtNBsRaIdX);
				}

				// Token: 0x06001158 RID: 4440 RVA: 0x0005D13C File Offset: 0x0005B33C
				public void APGgjpZuidgONTMskLIciYQxfnqw()
				{
					for (int i = 0; i < this.ntgCyvWDCpanRSgrcrBiPnyAaWki.Count; i++)
					{
						if (!this.SwGMuQqfASiDTbGZTdKtoFgbmMGCA.controllers.ContainsController(ControllerType.Joystick, this.ntgCyvWDCpanRSgrcrBiPnyAaWki[i].ipPeWzrJFFMxJFrgWTTebBRiaJSD))
						{
							this.ntgCyvWDCpanRSgrcrBiPnyAaWki[i].XqDcLyUoffRXyNWIyZaySFVCatgy = null;
						}
					}
				}

				// Token: 0x06001159 RID: 4441 RVA: 0x0005D198 File Offset: 0x0005B398
				public Player.ControllerHelper.qIXNxngxvPnyUKiwJbWeyVtlOaCm.SBUTVOjkKRydKuamilavnmYyifhN HSqSKFnVLMcRvAiAIrBvIaPWUIKw(int A_1)
				{
					int num = this.WWaJUjzqiUiTNJOFwGegTLzZSPlN(A_1);
					if (num < 0)
					{
						return null;
					}
					return this.ntgCyvWDCpanRSgrcrBiPnyAaWki[num];
				}

				// Token: 0x0600115A RID: 4442 RVA: 0x0005D1C0 File Offset: 0x0005B3C0
				public bool jXTpriuYnmBGYhSXzaEAtAOgFmfcA(int A_1)
				{
					for (int i = 0; i < this.ntgCyvWDCpanRSgrcrBiPnyAaWki.Count; i++)
					{
						if (this.ntgCyvWDCpanRSgrcrBiPnyAaWki[i].ipPeWzrJFFMxJFrgWTTebBRiaJSD == A_1)
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x0600115B RID: 4443 RVA: 0x0005D1FC File Offset: 0x0005B3FC
				public int WWaJUjzqiUiTNJOFwGegTLzZSPlN(int A_1)
				{
					for (int i = 0; i < this.ntgCyvWDCpanRSgrcrBiPnyAaWki.Count; i++)
					{
						if (this.ntgCyvWDCpanRSgrcrBiPnyAaWki[i].ipPeWzrJFFMxJFrgWTTebBRiaJSD == A_1)
						{
							return i;
						}
					}
					return -1;
				}

				// Token: 0x0600115C RID: 4444 RVA: 0x0000F3B8 File Offset: 0x0000D5B8
				public void QxodsmJXvOGNjwtMOItjyZTjpPxaA()
				{
					this.ntgCyvWDCpanRSgrcrBiPnyAaWki.Clear();
				}

				// Token: 0x04000A09 RID: 2569
				private readonly List<Player.ControllerHelper.qIXNxngxvPnyUKiwJbWeyVtlOaCm.SBUTVOjkKRydKuamilavnmYyifhN> ntgCyvWDCpanRSgrcrBiPnyAaWki;

				// Token: 0x04000A0A RID: 2570
				private readonly Player SwGMuQqfASiDTbGZTdKtoFgbmMGCA;

				// Token: 0x0200017C RID: 380
				public class SBUTVOjkKRydKuamilavnmYyifhN
				{
					// Token: 0x0600115D RID: 4445 RVA: 0x0000F3C5 File Offset: 0x0000D5C5
					public SBUTVOjkKRydKuamilavnmYyifhN(int A_1, VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<JoystickMap> A_2, double A_3)
					{
						this.ipPeWzrJFFMxJFrgWTTebBRiaJSD = A_1;
						this.XqDcLyUoffRXyNWIyZaySFVCatgy = A_2;
						this.eihGLCkYTaYNHHQZjpkfODUzbLTCb = A_3;
					}

					// Token: 0x04000A0B RID: 2571
					public int ipPeWzrJFFMxJFrgWTTebBRiaJSD;

					// Token: 0x04000A0C RID: 2572
					public VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<JoystickMap> XqDcLyUoffRXyNWIyZaySFVCatgy;

					// Token: 0x04000A0D RID: 2573
					public double eihGLCkYTaYNHHQZjpkfODUzbLTCb;
				}
			}

			// Token: 0x0200017D RID: 381
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class MapHelper : CodeHelper
			{
				// Token: 0x0600115E RID: 4446 RVA: 0x0005D238 File Offset: 0x0005B438
				internal MapHelper(Player A_1, Player.ControllerHelper A_2, OdwwNwDVsLLbukoEpkWRZpETNEYi A_3, ControllerMapLayoutManager.YuRWKBhEFGtHaIyXShqNamLdASyj A_4, ControllerMapEnabler.YqpaJJElEihfpIGutrHkMZgMkOuC A_5)
				{
					this.OQaPFYxSGgKObINRruqbxILdjVUO = ReInput.id;
					this.lawNLFQVYtOrvswGWUkKybfZHlLj = A_1;
					this.WQtQfVGCqewEYhTXSMYhGCZQawTm = A_2;
					this.rnFfambBUNgqcfQyoQGVXGnHKdbeA = A_3;
					this.PcMgoVlXoOYNqGgBwoSEwICaMdvB = new ControllerMapEnabler(A_1, A_5);
					this.ZZgzMQjqyDvJGNjcVqvujpABedsN = new ControllerMapLayoutManager(A_1, A_4);
					this.ZZgzMQjqyDvJGNjcVqvujpABedsN.gYghhSbDMOeCeEtDXeIDvARayRydA += this.PcMgoVlXoOYNqGgBwoSEwICaMdvB.Apply;
				}

				// Token: 0x17000493 RID: 1171
				// (get) Token: 0x0600115F RID: 4447 RVA: 0x0000F3E2 File Offset: 0x0000D5E2
				public ControllerMapLayoutManager layoutManager
				{
					get
					{
						return this.ZZgzMQjqyDvJGNjcVqvujpABedsN;
					}
				}

				// Token: 0x17000494 RID: 1172
				// (get) Token: 0x06001160 RID: 4448 RVA: 0x0000F3EA File Offset: 0x0000D5EA
				public ControllerMapEnabler mapEnabler
				{
					get
					{
						return this.PcMgoVlXoOYNqGgBwoSEwICaMdvB;
					}
				}

				// Token: 0x06001161 RID: 4449 RVA: 0x0000F3F2 File Offset: 0x0000D5F2
				public void LoadMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					this.xrvywNQAdWbQMlPfBRIcPyzsCDPI<T>(controllerId, categoryId, layoutId, BoolOption.Default);
				}

				// Token: 0x06001162 RID: 4450 RVA: 0x0000F3FE File Offset: 0x0000D5FE
				public void LoadMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					this.pDbqNcFGeMfaPEUBmHpLeMQYbXzg<T>(controllerId, categoryName, layoutName, BoolOption.Default);
				}

				// Token: 0x06001163 RID: 4451 RVA: 0x0000F40A File Offset: 0x0000D60A
				public void LoadMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					this.kCekeQpLXcghpAIEaRpnzSoooyYW(controllerType, controllerId, categoryId, layoutId, BoolOption.Default);
				}

				// Token: 0x06001164 RID: 4452 RVA: 0x0000F418 File Offset: 0x0000D618
				public void LoadMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					this.VvYpHjMUJFVycCinlAXqsCFBCdObA(controllerType, controllerId, categoryName, layoutName, BoolOption.Default);
				}

				// Token: 0x06001165 RID: 4453 RVA: 0x0000F426 File Offset: 0x0000D626
				public void LoadMap<T>(int controllerId, int categoryId, int layoutId, bool startEnabled) where T : ControllerMap
				{
					this.xrvywNQAdWbQMlPfBRIcPyzsCDPI<T>(controllerId, categoryId, layoutId, startEnabled ? BoolOption.True : BoolOption.False);
				}

				// Token: 0x06001166 RID: 4454 RVA: 0x0000F439 File Offset: 0x0000D639
				public void LoadMap<T>(int controllerId, string categoryName, string layoutName, bool startEnabled) where T : ControllerMap
				{
					this.pDbqNcFGeMfaPEUBmHpLeMQYbXzg<T>(controllerId, categoryName, layoutName, startEnabled ? BoolOption.True : BoolOption.False);
				}

				// Token: 0x06001167 RID: 4455 RVA: 0x0000F44C File Offset: 0x0000D64C
				public void LoadMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId, bool startEnabled)
				{
					this.kCekeQpLXcghpAIEaRpnzSoooyYW(controllerType, controllerId, categoryId, layoutId, startEnabled ? BoolOption.True : BoolOption.False);
				}

				// Token: 0x06001168 RID: 4456 RVA: 0x0000F461 File Offset: 0x0000D661
				public void LoadMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName, bool startEnabled)
				{
					this.VvYpHjMUJFVycCinlAXqsCFBCdObA(controllerType, controllerId, categoryName, layoutName, startEnabled ? BoolOption.True : BoolOption.False);
				}

				// Token: 0x06001169 RID: 4457 RVA: 0x0000F476 File Offset: 0x0000D676
				private void xrvywNQAdWbQMlPfBRIcPyzsCDPI<\u0001>(int A_1, int A_2, int A_3, BoolOption A_4) where \u0001 : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					this.IzGlQAFcBgrXnbfRzgYbxQZyqSuP(gRvITEHjKMrWaeGYEmAHofbpCtEU.DrVFpTBOVLehQeeOJikFfQUjqEZDc<\u0001>(), A_1, A_2, A_3, A_4);
				}

				// Token: 0x0600116A RID: 4458 RVA: 0x0000F4A2 File Offset: 0x0000D6A2
				private void pDbqNcFGeMfaPEUBmHpLeMQYbXzg<\u0001>(int A_1, string A_2, string A_3, BoolOption A_4) where \u0001 : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					this.BpLoiusdNsFMXiINNWcUohzesxTsA(gRvITEHjKMrWaeGYEmAHofbpCtEU.DrVFpTBOVLehQeeOJikFfQUjqEZDc<\u0001>(), A_1, A_2, A_3, A_4);
				}

				// Token: 0x0600116B RID: 4459 RVA: 0x0000F4CE File Offset: 0x0000D6CE
				private void kCekeQpLXcghpAIEaRpnzSoooyYW(ControllerType A_1, int A_2, int A_3, int A_4, BoolOption A_5)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					this.IzGlQAFcBgrXnbfRzgYbxQZyqSuP(A_1, A_2, A_3, A_4, A_5);
				}

				// Token: 0x0600116C RID: 4460 RVA: 0x0000F4F7 File Offset: 0x0000D6F7
				private void VvYpHjMUJFVycCinlAXqsCFBCdObA(ControllerType A_1, int A_2, string A_3, string A_4, BoolOption A_5)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					this.BpLoiusdNsFMXiINNWcUohzesxTsA(A_1, A_2, A_3, A_4, A_5);
				}

				// Token: 0x0600116D RID: 4461 RVA: 0x0000F520 File Offset: 0x0000D720
				public IEnumerable<ControllerMap> GetAllMaps()
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						yield break;
					}
					int ePoqkUtmPVaqcSRQDEsmWDfPnprd = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.ePoqkUtmPVaqcSRQDEsmWDfPnprd;
					int num3;
					for (int i = 0; i < ePoqkUtmPVaqcSRQDEsmWDfPnprd; i = num3 + 1)
					{
						Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.CtGoIeauMpKsCXqilTCeQCxqyY(i);
						int num = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
						for (int j = 0; j < num; j = num3 + 1)
						{
							dBWjOjXnFJmUROzCVhQpynliVgPI dBWjOjXnFJmUROzCVhQpynliVgPI = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(j).AxzIHFaeuZajYboPHuvsfCYAXoQwA;
							int num2 = dBWjOjXnFJmUROzCVhQpynliVgPI.sSEkNHPvFzDptlNqDocRnDXFEYyY;
							for (int k = 0; k < num2; k = num3 + 1)
							{
								yield return dBWjOjXnFJmUROzCVhQpynliVgPI.kpSXGnRVLDEHUvJSffrGHSOpEAHGb(k);
								num3 = k;
							}
							dBWjOjXnFJmUROzCVhQpynliVgPI = null;
							num3 = j;
						}
						rrrUVbResWNdbXKvkkOIseeimvIu = null;
						num3 = i;
					}
					yield break;
				}

				// Token: 0x0600116E RID: 4462 RVA: 0x0005D2A4 File Offset: 0x0005B4A4
				public int GetAllMaps(List<ControllerMap> results)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					int ePoqkUtmPVaqcSRQDEsmWDfPnprd = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.ePoqkUtmPVaqcSRQDEsmWDfPnprd;
					for (int i = 0; i < ePoqkUtmPVaqcSRQDEsmWDfPnprd; i++)
					{
						Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.CtGoIeauMpKsCXqilTCeQCxqyY(i);
						int num = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
						for (int j = 0; j < num; j++)
						{
							rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(j).AxzIHFaeuZajYboPHuvsfCYAXoQwA.dxilDVGnmfdQEitWTlEICrhfwQvYA(results, true);
						}
					}
					return results.Count;
				}

				// Token: 0x0600116F RID: 4463 RVA: 0x0000F530 File Offset: 0x0000D730
				public IEnumerable<T> GetAllMaps<T>() where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						yield break;
					}
					ControllerType controllerType;
					if (gRvITEHjKMrWaeGYEmAHofbpCtEU.AsHXrqqkjFxawzlQRepbDoBfHsw<\u0001>(out controllerType))
					{
						Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controllerType);
						int num = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
						int num3;
						for (int i = 0; i < num; i = num3 + 1)
						{
							dBWjOjXnFJmUROzCVhQpynliVgPI dBWjOjXnFJmUROzCVhQpynliVgPI = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA;
							int num2 = dBWjOjXnFJmUROzCVhQpynliVgPI.sSEkNHPvFzDptlNqDocRnDXFEYyY;
							for (int j = 0; j < num2; j = num3 + 1)
							{
								yield return (\u0001)((object)dBWjOjXnFJmUROzCVhQpynliVgPI.kpSXGnRVLDEHUvJSffrGHSOpEAHGb(j));
								num3 = j;
							}
							dBWjOjXnFJmUROzCVhQpynliVgPI = null;
							num3 = i;
						}
						rrrUVbResWNdbXKvkkOIseeimvIu = null;
					}
					else
					{
						int num = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.ePoqkUtmPVaqcSRQDEsmWDfPnprd;
						int num3;
						for (int i = 0; i < num; i = num3 + 1)
						{
							Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.CtGoIeauMpKsCXqilTCeQCxqyY(i);
							int num2 = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
							for (int j = 0; j < num2; j = num3 + 1)
							{
								dBWjOjXnFJmUROzCVhQpynliVgPI dBWjOjXnFJmUROzCVhQpynliVgPI = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(j).AxzIHFaeuZajYboPHuvsfCYAXoQwA;
								int num4 = dBWjOjXnFJmUROzCVhQpynliVgPI.sSEkNHPvFzDptlNqDocRnDXFEYyY;
								for (int k = 0; k < num4; k = num3 + 1)
								{
									\u0001 u = dBWjOjXnFJmUROzCVhQpynliVgPI.kpSXGnRVLDEHUvJSffrGHSOpEAHGb(k) as \u0001;
									if (u != null)
									{
										yield return u;
									}
									num3 = k;
								}
								dBWjOjXnFJmUROzCVhQpynliVgPI = null;
								num3 = j;
							}
							rrrUVbResWNdbXKvkkOIseeimvIu = null;
							num3 = i;
						}
					}
					yield break;
				}

				// Token: 0x06001170 RID: 4464 RVA: 0x0005D344 File Offset: 0x0005B544
				public int GetAllMaps<T>(List<T> results) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					ControllerType controllerType;
					if (gRvITEHjKMrWaeGYEmAHofbpCtEU.AsHXrqqkjFxawzlQRepbDoBfHsw<T>(out controllerType))
					{
						Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controllerType);
						int num = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
						for (int i = 0; i < num; i++)
						{
							rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA.cEyzzUmsvnPtEFKRsZaFhtcHSWLv<T>(results, true);
						}
					}
					else
					{
						int ePoqkUtmPVaqcSRQDEsmWDfPnprd = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.ePoqkUtmPVaqcSRQDEsmWDfPnprd;
						for (int j = 0; j < ePoqkUtmPVaqcSRQDEsmWDfPnprd; j++)
						{
							Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu2 = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.CtGoIeauMpKsCXqilTCeQCxqyY(j);
							int num2 = rrrUVbResWNdbXKvkkOIseeimvIu2.hUvoPojtJZIUBnFkCGjslfijGbmL;
							for (int k = 0; k < num2; k++)
							{
								rrrUVbResWNdbXKvkkOIseeimvIu2.UJAuNWFIjyrTyJDgUveqTrIhRNKT(k).AxzIHFaeuZajYboPHuvsfCYAXoQwA.cEyzzUmsvnPtEFKRsZaFhtcHSWLv<T>(results, true);
							}
						}
					}
					return results.Count;
				}

				// Token: 0x06001171 RID: 4465 RVA: 0x0000F540 File Offset: 0x0000D740
				public IEnumerable<ControllerMap> GetAllMaps(ControllerType controllerType)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						yield break;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controllerType);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
					int num3;
					for (int i = 0; i < num; i = num3 + 1)
					{
						dBWjOjXnFJmUROzCVhQpynliVgPI dBWjOjXnFJmUROzCVhQpynliVgPI = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA;
						int num2 = dBWjOjXnFJmUROzCVhQpynliVgPI.sSEkNHPvFzDptlNqDocRnDXFEYyY;
						for (int j = 0; j < num2; j = num3 + 1)
						{
							yield return dBWjOjXnFJmUROzCVhQpynliVgPI.kpSXGnRVLDEHUvJSffrGHSOpEAHGb(j);
							num3 = j;
						}
						dBWjOjXnFJmUROzCVhQpynliVgPI = null;
						num3 = i;
					}
					yield break;
				}

				// Token: 0x06001172 RID: 4466 RVA: 0x0005D434 File Offset: 0x0005B634
				public int GetAllMaps(ControllerType controllerType, List<ControllerMap> results)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controllerType);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
					for (int i = 0; i < num; i++)
					{
						rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA.dxilDVGnmfdQEitWTlEICrhfwQvYA(results, true);
					}
					return results.Count;
				}

				// Token: 0x06001173 RID: 4467 RVA: 0x0005D4B0 File Offset: 0x0005B6B0
				public IEnumerable<ControllerMap> GetAllMapsInCategory(string categoryName)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return new List<ControllerMap>();
					}
					return this.GetAllMapsInCategory(mapCategoryId);
				}

				// Token: 0x06001174 RID: 4468 RVA: 0x0000F557 File Offset: 0x0000D757
				public IEnumerable<ControllerMap> GetAllMapsInCategory(int categoryId)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						yield break;
					}
					int ePoqkUtmPVaqcSRQDEsmWDfPnprd = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.ePoqkUtmPVaqcSRQDEsmWDfPnprd;
					int num3;
					for (int i = 0; i < ePoqkUtmPVaqcSRQDEsmWDfPnprd; i = num3 + 1)
					{
						Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.CtGoIeauMpKsCXqilTCeQCxqyY(i);
						int num = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
						for (int j = 0; j < num; j = num3 + 1)
						{
							dBWjOjXnFJmUROzCVhQpynliVgPI dBWjOjXnFJmUROzCVhQpynliVgPI = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(j).AxzIHFaeuZajYboPHuvsfCYAXoQwA;
							int num2 = dBWjOjXnFJmUROzCVhQpynliVgPI.sSEkNHPvFzDptlNqDocRnDXFEYyY;
							for (int k = 0; k < num2; k = num3 + 1)
							{
								ControllerMap controllerMap = dBWjOjXnFJmUROzCVhQpynliVgPI.kpSXGnRVLDEHUvJSffrGHSOpEAHGb(k);
								if (controllerMap.categoryId == categoryId)
								{
									yield return controllerMap;
								}
								num3 = k;
							}
							dBWjOjXnFJmUROzCVhQpynliVgPI = null;
							num3 = j;
						}
						rrrUVbResWNdbXKvkkOIseeimvIu = null;
						num3 = i;
					}
					yield break;
				}

				// Token: 0x06001175 RID: 4469 RVA: 0x0005D4FC File Offset: 0x0005B6FC
				public IEnumerable<T> GetAllMapsInCategory<T>(string categoryName) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return this.GetAllMapsInCategory<T>(mapCategoryId);
				}

				// Token: 0x06001176 RID: 4470 RVA: 0x0000F56E File Offset: 0x0000D76E
				public IEnumerable<T> GetAllMapsInCategory<T>(int categoryId) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						yield break;
					}
					ControllerType controllerType;
					if (gRvITEHjKMrWaeGYEmAHofbpCtEU.AsHXrqqkjFxawzlQRepbDoBfHsw<\u0001>(out controllerType))
					{
						Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.NkhIolZrtfUygmkKcqXVlcPUHoraA<\u0001>();
						int num = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
						int num3;
						for (int i = 0; i < num; i = num3 + 1)
						{
							dBWjOjXnFJmUROzCVhQpynliVgPI dBWjOjXnFJmUROzCVhQpynliVgPI = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA;
							int num2 = dBWjOjXnFJmUROzCVhQpynliVgPI.sSEkNHPvFzDptlNqDocRnDXFEYyY;
							for (int j = 0; j < num2; j = num3 + 1)
							{
								ControllerMap controllerMap = dBWjOjXnFJmUROzCVhQpynliVgPI.kpSXGnRVLDEHUvJSffrGHSOpEAHGb(j);
								if (controllerMap.categoryId == categoryId)
								{
									yield return (\u0001)((object)controllerMap);
								}
								num3 = j;
							}
							dBWjOjXnFJmUROzCVhQpynliVgPI = null;
							num3 = i;
						}
						rrrUVbResWNdbXKvkkOIseeimvIu = null;
					}
					else
					{
						int num = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.ePoqkUtmPVaqcSRQDEsmWDfPnprd;
						int num3;
						for (int i = 0; i < num; i = num3 + 1)
						{
							Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.CtGoIeauMpKsCXqilTCeQCxqyY(i);
							int num2 = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
							for (int j = 0; j < num2; j = num3 + 1)
							{
								dBWjOjXnFJmUROzCVhQpynliVgPI dBWjOjXnFJmUROzCVhQpynliVgPI = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(j).AxzIHFaeuZajYboPHuvsfCYAXoQwA;
								int num4 = dBWjOjXnFJmUROzCVhQpynliVgPI.sSEkNHPvFzDptlNqDocRnDXFEYyY;
								for (int k = 0; k < num4; k = num3 + 1)
								{
									\u0001 u = dBWjOjXnFJmUROzCVhQpynliVgPI.kpSXGnRVLDEHUvJSffrGHSOpEAHGb(k) as \u0001;
									if (u != null && u.categoryId == categoryId)
									{
										yield return u;
									}
									num3 = k;
								}
								dBWjOjXnFJmUROzCVhQpynliVgPI = null;
								num3 = j;
							}
							rrrUVbResWNdbXKvkkOIseeimvIu = null;
							num3 = i;
						}
					}
					yield break;
				}

				// Token: 0x06001177 RID: 4471 RVA: 0x0005D548 File Offset: 0x0005B748
				public IEnumerable<ControllerMap> GetAllMapsInCategory(string categoryName, ControllerType controllerType)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return new List<ControllerMap>();
					}
					return this.GetAllMapsInCategory(mapCategoryId, controllerType);
				}

				// Token: 0x06001178 RID: 4472 RVA: 0x0000F585 File Offset: 0x0000D785
				public IEnumerable<ControllerMap> GetAllMapsInCategory(int categoryId, ControllerType controllerType)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						yield break;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controllerType);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
					int num3;
					for (int i = 0; i < num; i = num3 + 1)
					{
						dBWjOjXnFJmUROzCVhQpynliVgPI dBWjOjXnFJmUROzCVhQpynliVgPI = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA;
						int num2 = dBWjOjXnFJmUROzCVhQpynliVgPI.sSEkNHPvFzDptlNqDocRnDXFEYyY;
						for (int j = 0; j < num2; j = num3 + 1)
						{
							ControllerMap controllerMap = dBWjOjXnFJmUROzCVhQpynliVgPI.kpSXGnRVLDEHUvJSffrGHSOpEAHGb(j);
							if (controllerMap.categoryId == categoryId)
							{
								yield return controllerMap;
							}
							num3 = j;
						}
						dBWjOjXnFJmUROzCVhQpynliVgPI = null;
						num3 = i;
					}
					yield break;
				}

				// Token: 0x06001179 RID: 4473 RVA: 0x0005D594 File Offset: 0x0005B794
				public int GetAllMapsInCategory(string categoryName, List<ControllerMap> results)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return this.GetAllMapsInCategory(mapCategoryId, results);
				}

				// Token: 0x0600117A RID: 4474 RVA: 0x0005D5D8 File Offset: 0x0005B7D8
				public int GetAllMapsInCategory(int categoryId, List<ControllerMap> results)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return 0;
					}
					int ePoqkUtmPVaqcSRQDEsmWDfPnprd = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.ePoqkUtmPVaqcSRQDEsmWDfPnprd;
					for (int i = 0; i < ePoqkUtmPVaqcSRQDEsmWDfPnprd; i++)
					{
						Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.CtGoIeauMpKsCXqilTCeQCxqyY(i);
						int num = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
						for (int j = 0; j < num; j++)
						{
							rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(j).AxzIHFaeuZajYboPHuvsfCYAXoQwA.rDZPMaRoqmjfZWLmbTGHxMqkvbQr(categoryId, results, true);
						}
					}
					return results.Count;
				}

				// Token: 0x0600117B RID: 4475 RVA: 0x0005D688 File Offset: 0x0005B888
				public int GetAllMapsInCategory<T>(string categoryName, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return this.GetAllMapsInCategory<T>(mapCategoryId, results);
				}

				// Token: 0x0600117C RID: 4476 RVA: 0x0005D6CC File Offset: 0x0005B8CC
				public int GetAllMapsInCategory<T>(int categoryId, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return 0;
					}
					ControllerType controllerType;
					if (gRvITEHjKMrWaeGYEmAHofbpCtEU.AsHXrqqkjFxawzlQRepbDoBfHsw<T>(out controllerType))
					{
						Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controllerType);
						int num = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
						for (int i = 0; i < num; i++)
						{
							rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA.GBodkiSCDvZTycnDxKzemCacNvRw<T>(categoryId, results, true);
						}
					}
					else
					{
						int ePoqkUtmPVaqcSRQDEsmWDfPnprd = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.ePoqkUtmPVaqcSRQDEsmWDfPnprd;
						for (int j = 0; j < ePoqkUtmPVaqcSRQDEsmWDfPnprd; j++)
						{
							Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu2 = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.CtGoIeauMpKsCXqilTCeQCxqyY(j);
							int num2 = rrrUVbResWNdbXKvkkOIseeimvIu2.hUvoPojtJZIUBnFkCGjslfijGbmL;
							for (int k = 0; k < num2; k++)
							{
								rrrUVbResWNdbXKvkkOIseeimvIu2.UJAuNWFIjyrTyJDgUveqTrIhRNKT(k).AxzIHFaeuZajYboPHuvsfCYAXoQwA.GBodkiSCDvZTycnDxKzemCacNvRw<T>(categoryId, results, true);
							}
						}
					}
					return results.Count;
				}

				// Token: 0x0600117D RID: 4477 RVA: 0x0005D7CC File Offset: 0x0005B9CC
				public int GetAllMapsInCategory(string categoryName, ControllerType controllerType, List<ControllerMap> results)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return this.GetAllMapsInCategory(mapCategoryId, controllerType, results);
				}

				// Token: 0x0600117E RID: 4478 RVA: 0x0005D810 File Offset: 0x0005BA10
				public int GetAllMapsInCategory(int categoryId, ControllerType controllerType, List<ControllerMap> results)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return 0;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controllerType);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
					for (int i = 0; i < num; i++)
					{
						rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA.rDZPMaRoqmjfZWLmbTGHxMqkvbQr(categoryId, results, true);
					}
					return results.Count;
				}

				// Token: 0x0600117F RID: 4479 RVA: 0x0000F5A3 File Offset: 0x0000D7A3
				public IList<T> GetMaps<T>(int controllerId) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return this.jRQCFWqfCbjUYPRZOFryGNABtLcP<T>(controllerId);
				}

				// Token: 0x06001180 RID: 4480 RVA: 0x0000F5CB File Offset: 0x0000D7CB
				public IList<ControllerMap> GetMaps(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return this.DVbLRscGynDbpLPHjcNvTnaxkMjX(controllerType, controllerId);
				}

				// Token: 0x06001181 RID: 4481 RVA: 0x0000F5F4 File Offset: 0x0000D7F4
				public IList<ControllerMap> GetMaps(Controller controller)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return this.GetMaps(controller.type, controller.id);
				}

				// Token: 0x06001182 RID: 4482 RVA: 0x0005D89C File Offset: 0x0005BA9C
				public IEnumerable<ControllerMap> GetMapsInCategory(ControllerType controllerType, int controllerId, int categoryId)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					if (controllerId < 0 || categoryId < 0)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return this.ztWVZkYzMwXtOGZksOJWCmDkfabd(controllerType, controllerId, categoryId);
				}

				// Token: 0x06001183 RID: 4483 RVA: 0x0005D8F4 File Offset: 0x0005BAF4
				public IEnumerable<ControllerMap> GetMapsInCategory(ControllerType controllerType, int controllerId, string categoryName)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return this.GetMapsInCategory(controllerType, controllerId, mapCategoryId);
				}

				// Token: 0x06001184 RID: 4484 RVA: 0x0000F630 File Offset: 0x0000D830
				public IEnumerable<ControllerMap> GetMapsInCategory(Controller controller, int categoryId)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return this.GetMapsInCategory(controller.type, controller.id, categoryId);
				}

				// Token: 0x06001185 RID: 4485 RVA: 0x0005D940 File Offset: 0x0005BB40
				public IEnumerable<ControllerMap> GetMapsInCategory(Controller controller, string categoryName)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return this.GetMapsInCategory(controller.type, controller.id, mapCategoryId);
				}

				// Token: 0x06001186 RID: 4486 RVA: 0x0005D9A0 File Offset: 0x0005BBA0
				public int GetMapsInCategory(ControllerType controllerType, int controllerId, int categoryId, List<ControllerMap> results)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					ListTools.TryClear<ControllerMap>(results);
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					if (controllerId < 0 || categoryId < 0)
					{
						return 0;
					}
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return 0;
					}
					Player.ControllerHelper.aDTWAvwJDeCLlGzuGUJORYARFABdA aDTWAvwJDeCLlGzuGUJORYARFABdA = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controllerType).cLCIFSrSsIdpuGCXMXmeTmizjypZ(controllerId);
					if (aDTWAvwJDeCLlGzuGUJORYARFABdA == null)
					{
						return 0;
					}
					return aDTWAvwJDeCLlGzuGUJORYARFABdA.AxzIHFaeuZajYboPHuvsfCYAXoQwA.rDZPMaRoqmjfZWLmbTGHxMqkvbQr(categoryId, results, false);
				}

				// Token: 0x06001187 RID: 4487 RVA: 0x0005DA24 File Offset: 0x0005BC24
				public int GetMapsInCategory(ControllerType controllerType, int controllerId, string categoryName, List<ControllerMap> results)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					ListTools.TryClear<ControllerMap>(results);
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return this.GetMapsInCategory(controllerType, controllerId, mapCategoryId, results);
				}

				// Token: 0x06001188 RID: 4488 RVA: 0x0000F66D File Offset: 0x0000D86D
				public int GetMapsInCategory(Controller controller, int categoryId, List<ControllerMap> results)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					ListTools.TryClear<ControllerMap>(results);
					if (controller == null)
					{
						return 0;
					}
					return this.GetMapsInCategory(controller.type, controller.id, categoryId, results);
				}

				// Token: 0x06001189 RID: 4489 RVA: 0x0005DA70 File Offset: 0x0005BC70
				public int GetMapsInCategory(Controller controller, string categoryName, List<ControllerMap> results)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					ListTools.TryClear<ControllerMap>(results);
					if (controller == null)
					{
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return this.GetMapsInCategory(controller.type, controller.id, mapCategoryId, results);
				}

				// Token: 0x0600118A RID: 4490 RVA: 0x0000F6A9 File Offset: 0x0000D8A9
				public IEnumerable<T> GetMapsInCategory<T>(int controllerId, int categoryId) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return this.OcYFuTbGdkIdPZNUwfvgVqWLiTxzA<T>(controllerId, categoryId);
				}

				// Token: 0x0600118B RID: 4491 RVA: 0x0005DACC File Offset: 0x0005BCCC
				public IEnumerable<T> GetMapsInCategory<T>(int controllerId, string categoryName) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return this.GetMapsInCategory<T>(controllerId, mapCategoryId);
				}

				// Token: 0x0600118C RID: 4492 RVA: 0x0005DB18 File Offset: 0x0005BD18
				public int GetMapsInCategory<T>(int controllerId, int categoryId, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return 0;
					}
					Player.ControllerHelper.aDTWAvwJDeCLlGzuGUJORYARFABdA aDTWAvwJDeCLlGzuGUJORYARFABdA = this.NkhIolZrtfUygmkKcqXVlcPUHoraA<T>().cLCIFSrSsIdpuGCXMXmeTmizjypZ(controllerId);
					if (aDTWAvwJDeCLlGzuGUJORYARFABdA == null)
					{
						return 0;
					}
					aDTWAvwJDeCLlGzuGUJORYARFABdA.AxzIHFaeuZajYboPHuvsfCYAXoQwA.GBodkiSCDvZTycnDxKzemCacNvRw<T>(categoryId, results, true);
					return results.Count;
				}

				// Token: 0x0600118D RID: 4493 RVA: 0x0005DB8C File Offset: 0x0005BD8C
				public int GetMapsInCategory<T>(int controllerId, string categoryName, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					ListTools.TryClear<T>(results);
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return this.GetMapsInCategory<T>(controllerId, mapCategoryId, results);
				}

				// Token: 0x0600118E RID: 4494 RVA: 0x0005DBD8 File Offset: 0x0005BDD8
				public T GetMap<T>(int controllerId, int mapId) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return default(T);
					}
					if (mapId < 0)
					{
						return default(T);
					}
					return (T)((object)this.WeizxxjglrgxQMkfZWhCZxAGJWxE(gRvITEHjKMrWaeGYEmAHofbpCtEU.DrVFpTBOVLehQeeOJikFfQUjqEZDc<T>(), controllerId, mapId));
				}

				// Token: 0x0600118F RID: 4495 RVA: 0x0005DC28 File Offset: 0x0005BE28
				public T GetMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return default(T);
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return default(T);
					}
					return (T)((object)this.HyFqJaNGmHooWSOvghAymJyVDEKi(gRvITEHjKMrWaeGYEmAHofbpCtEU.DrVFpTBOVLehQeeOJikFfQUjqEZDc<T>(), controllerId, categoryId, layoutId));
				}

				// Token: 0x06001190 RID: 4496 RVA: 0x0005DC80 File Offset: 0x0005BE80
				public T GetMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return default(T);
					}
					return (T)((object)this.uBpxEZjpcxaFjdiWKpIeyzEvvEnl(gRvITEHjKMrWaeGYEmAHofbpCtEU.DrVFpTBOVLehQeeOJikFfQUjqEZDc<T>(), controllerId, categoryName, layoutName));
				}

				// Token: 0x06001191 RID: 4497 RVA: 0x0005DCC4 File Offset: 0x0005BEC4
				public ControllerMap GetMap(int mapId)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					int ePoqkUtmPVaqcSRQDEsmWDfPnprd = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.ePoqkUtmPVaqcSRQDEsmWDfPnprd;
					for (int i = 0; i < ePoqkUtmPVaqcSRQDEsmWDfPnprd; i++)
					{
						Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.CtGoIeauMpKsCXqilTCeQCxqyY(i);
						int num = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
						for (int j = 0; j < num; j++)
						{
							ControllerMap controllerMap = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(j).AxzIHFaeuZajYboPHuvsfCYAXoQwA.kokTzCgXytETCesILHvgRCorjGER(mapId);
							if (controllerMap != null)
							{
								return controllerMap;
							}
						}
					}
					return null;
				}

				// Token: 0x06001192 RID: 4498 RVA: 0x0000F6D2 File Offset: 0x0000D8D2
				public ControllerMap GetMap(ControllerType controllerType, int controllerId, int mapId)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					return this.WeizxxjglrgxQMkfZWhCZxAGJWxE(controllerType, controllerId, mapId);
				}

				// Token: 0x06001193 RID: 4499 RVA: 0x0000F6FE File Offset: 0x0000D8FE
				public ControllerMap GetMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return this.HyFqJaNGmHooWSOvghAymJyVDEKi(controllerType, controllerId, categoryId, layoutId);
				}

				// Token: 0x06001194 RID: 4500 RVA: 0x0000F731 File Offset: 0x0000D931
				public ControllerMap GetMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					return this.uBpxEZjpcxaFjdiWKpIeyzEvvEnl(controllerType, controllerId, categoryName, layoutName);
				}

				// Token: 0x06001195 RID: 4501 RVA: 0x0000F759 File Offset: 0x0000D959
				public ControllerMap GetMap(Controller controller, int mapId)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return this.GetMap(controller.type, controller.id, mapId);
				}

				// Token: 0x06001196 RID: 4502 RVA: 0x0000F78E File Offset: 0x0000D98E
				public ControllerMap GetMap(Controller controller, int categoryId, int layoutId)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return this.GetMap(controller.type, controller.id, categoryId, layoutId);
				}

				// Token: 0x06001197 RID: 4503 RVA: 0x0000F7C4 File Offset: 0x0000D9C4
				public ControllerMap GetMap(Controller controller, string categoryName, string layoutName)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return this.GetMap(controller.type, controller.id, categoryName, layoutName);
				}

				// Token: 0x06001198 RID: 4504 RVA: 0x0005DD58 File Offset: 0x0005BF58
				public T GetFirstMapInCategory<T>(int controllerId, string categoryName) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return default(T);
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return default(T);
					}
					return this.GetFirstMapInCategory<T>(controllerId, mapCategoryId);
				}

				// Token: 0x06001199 RID: 4505 RVA: 0x0005DDAC File Offset: 0x0005BFAC
				public T GetFirstMapInCategory<T>(int controllerId, int categoryId) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return default(T);
					}
					if (categoryId < 0)
					{
						return default(T);
					}
					return (T)((object)this.SXDcCUKyTmIGYkLcDifNvgDxclJP(gRvITEHjKMrWaeGYEmAHofbpCtEU.DrVFpTBOVLehQeeOJikFfQUjqEZDc<T>(), controllerId, categoryId));
				}

				// Token: 0x0600119A RID: 4506 RVA: 0x0005DDFC File Offset: 0x0005BFFC
				public ControllerMap GetFirstMapInCategory(ControllerType controllerType, int controllerId, string categoryName)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return null;
					}
					return this.GetFirstMapInCategory(controllerType, controllerId, mapCategoryId);
				}

				// Token: 0x0600119B RID: 4507 RVA: 0x0000F7FA File Offset: 0x0000D9FA
				public ControllerMap GetFirstMapInCategory(ControllerType controllerType, int controllerId, int categoryId)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					if (categoryId < 0)
					{
						return null;
					}
					return this.SXDcCUKyTmIGYkLcDifNvgDxclJP(controllerType, controllerId, categoryId);
				}

				// Token: 0x0600119C RID: 4508 RVA: 0x0000F826 File Offset: 0x0000DA26
				public ControllerMap GetFirstMapInCategory(Controller controller, string categoryName)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return this.GetFirstMapInCategory(controller.type, controller.id, categoryName);
				}

				// Token: 0x0600119D RID: 4509 RVA: 0x0000F85B File Offset: 0x0000DA5B
				public ControllerMap GetFirstMapInCategory(Controller controller, int categoryId)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return this.GetFirstMapInCategory(controller.type, controller.id, categoryId);
				}

				// Token: 0x0600119E RID: 4510 RVA: 0x0000F890 File Offset: 0x0000DA90
				public void AddMap<T>(int controllerId, ControllerMap map) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					this.IneFPGeuYcGLvxXmrConOANRhreo(gRvITEHjKMrWaeGYEmAHofbpCtEU.DrVFpTBOVLehQeeOJikFfQUjqEZDc<T>(), controllerId, map, BoolOption.Default);
				}

				// Token: 0x0600119F RID: 4511 RVA: 0x0000F8BA File Offset: 0x0000DABA
				public void AddMap(Controller controller, ControllerMap map)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					this.PjeHKsUTGAFLwoRrpDvQkEwhGycD(controller, map, BoolOption.Default);
				}

				// Token: 0x060011A0 RID: 4512 RVA: 0x0000F8DF File Offset: 0x0000DADF
				public void AddMap(ControllerType controllerType, int controllerId, ControllerMap map)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					this.IneFPGeuYcGLvxXmrConOANRhreo(controllerType, controllerId, map, BoolOption.Default);
				}

				// Token: 0x060011A1 RID: 4513 RVA: 0x0000F905 File Offset: 0x0000DB05
				public void AddMap<T>(int controllerId, ControllerMap map, bool startEnabled) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					this.IneFPGeuYcGLvxXmrConOANRhreo(gRvITEHjKMrWaeGYEmAHofbpCtEU.DrVFpTBOVLehQeeOJikFfQUjqEZDc<T>(), controllerId, map, startEnabled ? BoolOption.True : BoolOption.False);
				}

				// Token: 0x060011A2 RID: 4514 RVA: 0x0000F935 File Offset: 0x0000DB35
				public void AddMap(Controller controller, ControllerMap map, bool startEnabled)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					this.PjeHKsUTGAFLwoRrpDvQkEwhGycD(controller, map, startEnabled ? BoolOption.True : BoolOption.False);
				}

				// Token: 0x060011A3 RID: 4515 RVA: 0x0000F960 File Offset: 0x0000DB60
				public void AddMap(ControllerType controllerType, int controllerId, ControllerMap map, bool startEnabled)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					this.IneFPGeuYcGLvxXmrConOANRhreo(controllerType, controllerId, map, startEnabled ? BoolOption.True : BoolOption.False);
				}

				// Token: 0x060011A4 RID: 4516 RVA: 0x0000F98D File Offset: 0x0000DB8D
				public bool AddMapFromXml<T>(int controllerId, string xmlString) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return false;
					}
					return this.CfQrvqYpvwaQvRIvzfUisvlAoPIN(gRvITEHjKMrWaeGYEmAHofbpCtEU.DrVFpTBOVLehQeeOJikFfQUjqEZDc<T>(), controllerId, xmlString);
				}

				// Token: 0x060011A5 RID: 4517 RVA: 0x0000F9B7 File Offset: 0x0000DBB7
				public bool AddMapFromXml(ControllerType controllerType, int controllerId, string xmlString)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return false;
					}
					return this.CfQrvqYpvwaQvRIvzfUisvlAoPIN(controllerType, controllerId, xmlString);
				}

				// Token: 0x060011A6 RID: 4518 RVA: 0x0005DE40 File Offset: 0x0005C040
				public int AddMapsFromXml<T>(int controllerId, List<string> xmlStrings) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					if (xmlStrings == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < xmlStrings.Count; i++)
					{
						if (this.AddMapFromXml<T>(controllerId, xmlStrings[i]))
						{
							num++;
						}
					}
					return num;
				}

				// Token: 0x060011A7 RID: 4519 RVA: 0x0005DE98 File Offset: 0x0005C098
				public int AddMapsFromXml(ControllerType controllerType, int controllerId, List<string> xmlStrings)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					if (xmlStrings == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < xmlStrings.Count; i++)
					{
						if (this.AddMapFromXml(controllerType, controllerId, xmlStrings[i]))
						{
							num++;
						}
					}
					return num;
				}

				// Token: 0x060011A8 RID: 4520 RVA: 0x0000F9DD File Offset: 0x0000DBDD
				public bool AddMapFromJson<T>(int controllerId, string jsonString) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return false;
					}
					return this.XZCQcxPGjfcrIXedYelGJJBlZajL(gRvITEHjKMrWaeGYEmAHofbpCtEU.DrVFpTBOVLehQeeOJikFfQUjqEZDc<T>(), controllerId, jsonString);
				}

				// Token: 0x060011A9 RID: 4521 RVA: 0x0000FA07 File Offset: 0x0000DC07
				public bool AddMapFromJson(ControllerType controllerType, int controllerId, string jsonString)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return false;
					}
					return this.XZCQcxPGjfcrIXedYelGJJBlZajL(controllerType, controllerId, jsonString);
				}

				// Token: 0x060011AA RID: 4522 RVA: 0x0005DEF0 File Offset: 0x0005C0F0
				public int AddMapsFromJson<T>(int controllerId, List<string> jsonStrings) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					if (jsonStrings == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < jsonStrings.Count; i++)
					{
						if (this.AddMapFromJson<T>(controllerId, jsonStrings[i]))
						{
							num++;
						}
					}
					return num;
				}

				// Token: 0x060011AB RID: 4523 RVA: 0x0005DF48 File Offset: 0x0005C148
				public int AddMapsFromJson(ControllerType controllerType, int controllerId, List<string> jsonStrings)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					if (jsonStrings == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < jsonStrings.Count; i++)
					{
						if (this.AddMapFromJson(controllerType, controllerId, jsonStrings[i]))
						{
							num++;
						}
					}
					return num;
				}

				// Token: 0x060011AC RID: 4524 RVA: 0x0000FA2D File Offset: 0x0000DC2D
				public void AddEmptyMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					this.BdUHDlgWIEzncFvAvwezVQUdysmj(gRvITEHjKMrWaeGYEmAHofbpCtEU.DrVFpTBOVLehQeeOJikFfQUjqEZDc<T>(), controllerId, categoryId, layoutId);
				}

				// Token: 0x060011AD RID: 4525 RVA: 0x0000FA57 File Offset: 0x0000DC57
				public void AddEmptyMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					this.PHotXYsQkfduRdeDiwXOiNSpnjun(gRvITEHjKMrWaeGYEmAHofbpCtEU.DrVFpTBOVLehQeeOJikFfQUjqEZDc<T>(), controllerId, categoryName, layoutName);
				}

				// Token: 0x060011AE RID: 4526 RVA: 0x0000FA81 File Offset: 0x0000DC81
				public void AddEmptyMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					this.BdUHDlgWIEzncFvAvwezVQUdysmj(controllerType, controllerId, categoryId, layoutId);
				}

				// Token: 0x060011AF RID: 4527 RVA: 0x0005DFA0 File Offset: 0x0005C1A0
				public void AddEmptyMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
					if (mapCategoryId < 0 || layoutId < 0)
					{
						return;
					}
					this.AddEmptyMap(controllerType, controllerId, mapCategoryId, layoutId);
				}

				// Token: 0x060011B0 RID: 4528 RVA: 0x0000FAA8 File Offset: 0x0000DCA8
				public void RemoveMap<T>(int controllerId, int mapId) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					if (mapId < 0)
					{
						return;
					}
					this.mMMlOfoddLXPBbpvStdcnojnGfzgA(gRvITEHjKMrWaeGYEmAHofbpCtEU.DrVFpTBOVLehQeeOJikFfQUjqEZDc<T>(), controllerId, mapId);
				}

				// Token: 0x060011B1 RID: 4529 RVA: 0x0000FAD6 File Offset: 0x0000DCD6
				public void RemoveMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return;
					}
					this.yjchwXMNnFhIOHMvTpdhomrQABAU(gRvITEHjKMrWaeGYEmAHofbpCtEU.DrVFpTBOVLehQeeOJikFfQUjqEZDc<T>(), controllerId, categoryId, layoutId);
				}

				// Token: 0x060011B2 RID: 4530 RVA: 0x0000FB09 File Offset: 0x0000DD09
				public void RemoveMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					this.UfVgamseQifHZAAUhwmfmuIsMHet(gRvITEHjKMrWaeGYEmAHofbpCtEU.DrVFpTBOVLehQeeOJikFfQUjqEZDc<T>(), controllerId, categoryName, layoutName);
				}

				// Token: 0x060011B3 RID: 4531 RVA: 0x0000FB33 File Offset: 0x0000DD33
				public void RemoveMap(ControllerType controllerType, int controllerId, int mapId)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					if (mapId < 0)
					{
						return;
					}
					this.mMMlOfoddLXPBbpvStdcnojnGfzgA(controllerType, controllerId, mapId);
				}

				// Token: 0x060011B4 RID: 4532 RVA: 0x0000FB5D File Offset: 0x0000DD5D
				public void RemoveMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return;
					}
					this.yjchwXMNnFhIOHMvTpdhomrQABAU(controllerType, controllerId, categoryId, layoutId);
				}

				// Token: 0x060011B5 RID: 4533 RVA: 0x0000FB8E File Offset: 0x0000DD8E
				public void RemoveMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					this.UfVgamseQifHZAAUhwmfmuIsMHet(controllerType, controllerId, categoryName, layoutName);
				}

				// Token: 0x060011B6 RID: 4534 RVA: 0x0000FBB5 File Offset: 0x0000DDB5
				public void ClearMaps<T>(bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					this.ClearMaps(gRvITEHjKMrWaeGYEmAHofbpCtEU.DrVFpTBOVLehQeeOJikFfQUjqEZDc<T>(), userAssignableOnly);
				}

				// Token: 0x060011B7 RID: 4535 RVA: 0x0005DFF4 File Offset: 0x0005C1F4
				public void ClearMaps(ControllerType controllerType, bool userAssignableOnly)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controllerType);
					for (int i = 0; i < rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA.JbPLwrAbznxbaWUUYECUbidMmFaS(userAssignableOnly);
					}
				}

				// Token: 0x060011B8 RID: 4536 RVA: 0x0000FBDD File Offset: 0x0000DDDD
				public void ClearMapsInCategory<T>(int categoryId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					this.ClearMapsInCategory(gRvITEHjKMrWaeGYEmAHofbpCtEU.DrVFpTBOVLehQeeOJikFfQUjqEZDc<T>(), categoryId, userAssignableOnly);
				}

				// Token: 0x060011B9 RID: 4537 RVA: 0x0005E050 File Offset: 0x0005C250
				public void ClearMapsInCategory<T>(string categoryName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return;
					}
					this.ClearMapsInCategory<T>(mapCategoryId, userAssignableOnly);
				}

				// Token: 0x060011BA RID: 4538 RVA: 0x0000FC06 File Offset: 0x0000DE06
				public void ClearMapsInCategory<T>(int categoryId, int layoutId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					this.ClearMapsInCategory(gRvITEHjKMrWaeGYEmAHofbpCtEU.DrVFpTBOVLehQeeOJikFfQUjqEZDc<T>(), categoryId, layoutId, userAssignableOnly);
				}

				// Token: 0x060011BB RID: 4539 RVA: 0x0005E090 File Offset: 0x0005C290
				public void ClearMapsInCategory<T>(string categoryName, string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(gRvITEHjKMrWaeGYEmAHofbpCtEU.DrVFpTBOVLehQeeOJikFfQUjqEZDc<T>(), layoutName);
					if (layoutId < 0)
					{
						return;
					}
					this.ClearMapsInCategory<T>(mapCategoryId, layoutId, userAssignableOnly);
				}

				// Token: 0x060011BC RID: 4540 RVA: 0x0005E0E8 File Offset: 0x0005C2E8
				public void ClearMapsInCategory(int categoryId, bool userAssignableOnly)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					int ePoqkUtmPVaqcSRQDEsmWDfPnprd = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.ePoqkUtmPVaqcSRQDEsmWDfPnprd;
					for (int i = 0; i < ePoqkUtmPVaqcSRQDEsmWDfPnprd; i++)
					{
						Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.vZrGQvFMXtMVZgyvAVXhqFNCtgsMB(i));
						for (int j = 0; j < rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL; j++)
						{
							rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(j).AxzIHFaeuZajYboPHuvsfCYAXoQwA.EyRoCeMafAkntbwTMHcvOPBTGNrj(categoryId, userAssignableOnly);
						}
					}
				}

				// Token: 0x060011BD RID: 4541 RVA: 0x0005E174 File Offset: 0x0005C374
				public void ClearMapsInCategory(string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return;
					}
					this.ClearMapsInCategory(mapCategoryId, userAssignableOnly);
				}

				// Token: 0x060011BE RID: 4542 RVA: 0x0005E1B4 File Offset: 0x0005C3B4
				public void ClearMapsInCategory(ControllerType controllerType, int categoryId, bool userAssignableOnly)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controllerType);
					for (int i = 0; i < rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA.EyRoCeMafAkntbwTMHcvOPBTGNrj(categoryId, userAssignableOnly);
					}
				}

				// Token: 0x060011BF RID: 4543 RVA: 0x0005E214 File Offset: 0x0005C414
				public void ClearMapsInCategory(ControllerType controllerType, string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return;
					}
					this.ClearMapsInCategory(controllerType, mapCategoryId, userAssignableOnly);
				}

				// Token: 0x060011C0 RID: 4544 RVA: 0x0005E258 File Offset: 0x0005C458
				public void ClearMapsInCategory(ControllerType controllerType, int categoryId, int layoutId, bool userAssignableOnly)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					InputCategory mapCategory = ReInput.mapping.GetMapCategory(categoryId);
					if (mapCategory == null)
					{
						return;
					}
					if (userAssignableOnly && !mapCategory.userAssignable)
					{
						return;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controllerType);
					for (int i = 0; i < rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA.KfnMFXdMygcpedkRzNowoFWTTTdqA(categoryId, layoutId);
					}
				}

				// Token: 0x060011C1 RID: 4545 RVA: 0x0005E2D4 File Offset: 0x0005C4D4
				public void ClearMapsInCategory(ControllerType controllerType, string categoryName, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
					if (layoutId < 0)
					{
						return;
					}
					this.ClearMapsInCategory(controllerType, mapCategoryId, layoutId, userAssignableOnly);
				}

				// Token: 0x060011C2 RID: 4546 RVA: 0x0000FC30 File Offset: 0x0000DE30
				public void ClearMapsInLayout<T>(int layoutId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					this.ClearMapsInLayout(gRvITEHjKMrWaeGYEmAHofbpCtEU.DrVFpTBOVLehQeeOJikFfQUjqEZDc<T>(), layoutId, userAssignableOnly);
				}

				// Token: 0x060011C3 RID: 4547 RVA: 0x0005E32C File Offset: 0x0005C52C
				public void ClearMapsInLayout<T>(string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(gRvITEHjKMrWaeGYEmAHofbpCtEU.DrVFpTBOVLehQeeOJikFfQUjqEZDc<T>(), layoutName);
					if (layoutId < 0)
					{
						return;
					}
					this.ClearMapsInLayout<T>(layoutId, userAssignableOnly);
				}

				// Token: 0x060011C4 RID: 4548 RVA: 0x0005E374 File Offset: 0x0005C574
				public void ClearMapsInLayout(ControllerType controllerType, int layoutId, bool userAssignableOnly)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controllerType);
					for (int i = 0; i < rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA.lMxLxLTiQrWngrrrKVtcGEcVsdeY(layoutId, userAssignableOnly);
					}
				}

				// Token: 0x060011C5 RID: 4549 RVA: 0x0005E3D4 File Offset: 0x0005C5D4
				public void ClearMapsInLayout(ControllerType controllerType, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
					if (layoutId < 0)
					{
						return;
					}
					this.ClearMapsInLayout(controllerType, layoutId, userAssignableOnly);
				}

				// Token: 0x060011C6 RID: 4550 RVA: 0x0000FC59 File Offset: 0x0000DE59
				public void ClearMapsForController<T>(int controllerId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					this.ClearMapsForController(gRvITEHjKMrWaeGYEmAHofbpCtEU.DrVFpTBOVLehQeeOJikFfQUjqEZDc<T>(), controllerId, userAssignableOnly);
				}

				// Token: 0x060011C7 RID: 4551 RVA: 0x0000FC82 File Offset: 0x0000DE82
				public void ClearMapsForController<T>(int controllerId, int categoryId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					this.ClearMapsForController(gRvITEHjKMrWaeGYEmAHofbpCtEU.DrVFpTBOVLehQeeOJikFfQUjqEZDc<T>(), controllerId, categoryId, userAssignableOnly);
				}

				// Token: 0x060011C8 RID: 4552 RVA: 0x0005E418 File Offset: 0x0005C618
				public void ClearMapsForController<T>(int controllerId, string categoryName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return;
					}
					this.ClearMapsForController<T>(controllerId, mapCategoryId, userAssignableOnly);
				}

				// Token: 0x060011C9 RID: 4553 RVA: 0x0005E45C File Offset: 0x0005C65C
				public void ClearMapsForController(ControllerType controllerType, int controllerId, bool userAssignableOnly)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controllerType);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.jVtFwimrOgSFQQoYBDWYmPSvkaPH(controllerId);
					if (num < 0)
					{
						return;
					}
					rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).AxzIHFaeuZajYboPHuvsfCYAXoQwA.JbPLwrAbznxbaWUUYECUbidMmFaS(userAssignableOnly);
				}

				// Token: 0x060011CA RID: 4554 RVA: 0x0005E4B4 File Offset: 0x0005C6B4
				public void ClearMapsForController(ControllerType controllerType, int controllerId, int categoryId, bool userAssignableOnly)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controllerType);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.jVtFwimrOgSFQQoYBDWYmPSvkaPH(controllerId);
					if (num < 0)
					{
						return;
					}
					rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).AxzIHFaeuZajYboPHuvsfCYAXoQwA.EyRoCeMafAkntbwTMHcvOPBTGNrj(categoryId, userAssignableOnly);
				}

				// Token: 0x060011CB RID: 4555 RVA: 0x0005E510 File Offset: 0x0005C710
				public void ClearMapsForController(ControllerType controllerType, int controllerId, string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return;
					}
					this.ClearMapsForController(controllerType, controllerId, mapCategoryId, userAssignableOnly);
				}

				// Token: 0x060011CC RID: 4556 RVA: 0x0000FCAC File Offset: 0x0000DEAC
				public void ClearMapsForControllerInLayout<T>(int controllerId, int layoutId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					this.ClearMapsForControllerInLayout(gRvITEHjKMrWaeGYEmAHofbpCtEU.DrVFpTBOVLehQeeOJikFfQUjqEZDc<T>(), controllerId, layoutId, userAssignableOnly);
				}

				// Token: 0x060011CD RID: 4557 RVA: 0x0005E554 File Offset: 0x0005C754
				public void ClearMapsForControllerInLayout<T>(int controllerId, string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(gRvITEHjKMrWaeGYEmAHofbpCtEU.DrVFpTBOVLehQeeOJikFfQUjqEZDc<T>(), layoutName);
					if (layoutId < 0)
					{
						return;
					}
					this.ClearMapsForControllerInLayout<T>(controllerId, layoutId, userAssignableOnly);
				}

				// Token: 0x060011CE RID: 4558 RVA: 0x0005E59C File Offset: 0x0005C79C
				public void ClearMapsForControllerInLayout(ControllerType controllerType, int controllerId, int layoutId, bool userAssignableOnly)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controllerType);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.jVtFwimrOgSFQQoYBDWYmPSvkaPH(controllerId);
					if (num < 0)
					{
						return;
					}
					rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).AxzIHFaeuZajYboPHuvsfCYAXoQwA.lMxLxLTiQrWngrrrKVtcGEcVsdeY(layoutId, userAssignableOnly);
				}

				// Token: 0x060011CF RID: 4559 RVA: 0x0005E5F8 File Offset: 0x0005C7F8
				public void ClearMapsForControllerInLayout(ControllerType controllerType, int controllerId, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
					if (layoutId < 0)
					{
						return;
					}
					this.ClearMapsForControllerInLayout(controllerType, controllerId, layoutId, userAssignableOnly);
				}

				// Token: 0x060011D0 RID: 4560 RVA: 0x0005E63C File Offset: 0x0005C83C
				public void ClearAllMaps(bool userAssignableOnly)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					for (int i = 0; i < this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.ePoqkUtmPVaqcSRQDEsmWDfPnprd; i++)
					{
						this.ClearMaps(this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.vZrGQvFMXtMVZgyvAVXhqFNCtgsMB(i), userAssignableOnly);
					}
				}

				// Token: 0x060011D1 RID: 4561 RVA: 0x0000FCD6 File Offset: 0x0000DED6
				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return this.GetFirstButtonMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				// Token: 0x060011D2 RID: 4562 RVA: 0x0000FCED File Offset: 0x0000DEED
				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return this.GetFirstButtonMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				// Token: 0x060011D3 RID: 4563 RVA: 0x0000FD04 File Offset: 0x0000DF04
				public ActionElementMap GetFirstButtonMapWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return this.QgzZitrKMsYnjWTKPcAncDeqpilN(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				// Token: 0x060011D4 RID: 4564 RVA: 0x0005E698 File Offset: 0x0005C898
				public ActionElementMap GetFirstButtonMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.GetFirstButtonMapWithAction(controller, actionId, skipDisabledMaps);
				}

				// Token: 0x060011D5 RID: 4565 RVA: 0x0000FD3A File Offset: 0x0000DF3A
				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					return this.MHMKDCwcqmAHWbpAApSgEakknRuUb(controllerType, actionId, skipDisabledMaps);
				}

				// Token: 0x060011D6 RID: 4566 RVA: 0x0005E6D8 File Offset: 0x0005C8D8
				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.GetFirstButtonMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				// Token: 0x060011D7 RID: 4567 RVA: 0x0005E718 File Offset: 0x0005C918
				public ActionElementMap GetFirstButtonMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.ePoqkUtmPVaqcSRQDEsmWDfPnprd; i++)
					{
						ActionElementMap actionElementMap = this.MHMKDCwcqmAHWbpAApSgEakknRuUb(this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.vZrGQvFMXtMVZgyvAVXhqFNCtgsMB(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				// Token: 0x060011D8 RID: 4568 RVA: 0x0005E784 File Offset: 0x0005C984
				public ActionElementMap GetFirstButtonMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.GetFirstButtonMapWithAction(actionId, skipDisabledMaps);
				}

				// Token: 0x060011D9 RID: 4569 RVA: 0x0000FD60 File Offset: 0x0000DF60
				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return this.ButtonMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				// Token: 0x060011DA RID: 4570 RVA: 0x0000FD77 File Offset: 0x0000DF77
				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return this.ButtonMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				// Token: 0x060011DB RID: 4571 RVA: 0x0000FD8E File Offset: 0x0000DF8E
				public IEnumerable<ActionElementMap> ButtonMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return this.rlBtglSNvLmMMkVsGjefcJtTtesk(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				// Token: 0x060011DC RID: 4572 RVA: 0x0005E7C4 File Offset: 0x0005C9C4
				public IEnumerable<ActionElementMap> ButtonMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.ButtonMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				// Token: 0x060011DD RID: 4573 RVA: 0x0000FDCC File Offset: 0x0000DFCC
				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return this.ZvfTdUntJznnseKCgdyrfoARmmSd(controllerType, actionId, skipDisabledMaps);
				}

				// Token: 0x060011DE RID: 4574 RVA: 0x0005E808 File Offset: 0x0005CA08
				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.ButtonMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				// Token: 0x060011DF RID: 4575 RVA: 0x0000FDF6 File Offset: 0x0000DFF6
				public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						yield break;
					}
					if (actionId < 0)
					{
						yield break;
					}
					int ePoqkUtmPVaqcSRQDEsmWDfPnprd = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.ePoqkUtmPVaqcSRQDEsmWDfPnprd;
					int num3;
					for (int i = 0; i < ePoqkUtmPVaqcSRQDEsmWDfPnprd; i = num3 + 1)
					{
						Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.CtGoIeauMpKsCXqilTCeQCxqyY(i);
						int num = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
						for (int j = 0; j < num; j = num3 + 1)
						{
							dBWjOjXnFJmUROzCVhQpynliVgPI dBWjOjXnFJmUROzCVhQpynliVgPI = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(j).AxzIHFaeuZajYboPHuvsfCYAXoQwA;
							int num2 = dBWjOjXnFJmUROzCVhQpynliVgPI.sSEkNHPvFzDptlNqDocRnDXFEYyY;
							for (int k = 0; k < num2; k = num3 + 1)
							{
								ControllerMap controllerMap = dBWjOjXnFJmUROzCVhQpynliVgPI.kpSXGnRVLDEHUvJSffrGHSOpEAHGb(k);
								if ((!skipDisabledMaps || controllerMap.enabled) && controllerMap.ContainsAction(actionId))
								{
									foreach (ActionElementMap actionElementMap in controllerMap.ButtonMapsWithAction(actionId, skipDisabledMaps))
									{
										yield return actionElementMap;
									}
									IEnumerator<ActionElementMap> enumerator = null;
								}
								num3 = k;
							}
							dBWjOjXnFJmUROzCVhQpynliVgPI = null;
							num3 = j;
						}
						rrrUVbResWNdbXKvkkOIseeimvIu = null;
						num3 = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x060011E0 RID: 4576 RVA: 0x0005E84C File Offset: 0x0005CA4C
				public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.ButtonMapsWithAction(actionId, skipDisabledMaps);
				}

				// Token: 0x060011E1 RID: 4577 RVA: 0x0000FE14 File Offset: 0x0000E014
				public int GetButtonMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return this.GetButtonMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps, results);
				}

				// Token: 0x060011E2 RID: 4578 RVA: 0x0000FE2D File Offset: 0x0000E02D
				public int GetButtonMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return this.GetButtonMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps, results);
				}

				// Token: 0x060011E3 RID: 4579 RVA: 0x0005E890 File Offset: 0x0005CA90
				public int GetButtonMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					if (controller == null)
					{
						results.Clear();
						return 0;
					}
					return this.NYVBIsykLGZXTYnfpTFnptBBSHKm(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				// Token: 0x060011E4 RID: 4580 RVA: 0x0005E8EC File Offset: 0x0005CAEC
				public int GetButtonMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.GetButtonMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				// Token: 0x060011E5 RID: 4581 RVA: 0x0000FE46 File Offset: 0x0000E046
				public int GetButtonMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					return this.coeoeRATNJkIVPjzLQFbvWFLTbis(controllerType, actionId, skipDisabledMaps, results, false);
				}

				// Token: 0x060011E6 RID: 4582 RVA: 0x0005E92C File Offset: 0x0005CB2C
				public int GetButtonMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.GetButtonMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				// Token: 0x060011E7 RID: 4583 RVA: 0x0000FE6F File Offset: 0x0000E06F
				public int GetButtonMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return this.TLhyhBtIvalkJddZHvUhidvQEbpx(actionId, skipDisabledMaps, results, false);
				}

				// Token: 0x060011E8 RID: 4584 RVA: 0x0005E96C File Offset: 0x0005CB6C
				public int GetButtonMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.GetButtonMapsWithAction(actionId, skipDisabledMaps, results);
				}

				// Token: 0x060011E9 RID: 4585 RVA: 0x0000FE7B File Offset: 0x0000E07B
				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return this.GetFirstAxisMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				// Token: 0x060011EA RID: 4586 RVA: 0x0000FE92 File Offset: 0x0000E092
				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return this.GetFirstAxisMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				// Token: 0x060011EB RID: 4587 RVA: 0x0000FEA9 File Offset: 0x0000E0A9
				public ActionElementMap GetFirstAxisMapWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return this.irhBOZFlHeLgdBOMgwjLQclNcABzA(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				// Token: 0x060011EC RID: 4588 RVA: 0x0005E9AC File Offset: 0x0005CBAC
				public ActionElementMap GetFirstAxisMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.GetFirstAxisMapWithAction(controller, actionId, skipDisabledMaps);
				}

				// Token: 0x060011ED RID: 4589 RVA: 0x0000FEDF File Offset: 0x0000E0DF
				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					return this.aeyQjNaHnCkuehEfAjfkwqSanPP(controllerType, actionId, skipDisabledMaps);
				}

				// Token: 0x060011EE RID: 4590 RVA: 0x0005E9EC File Offset: 0x0005CBEC
				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.GetFirstAxisMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				// Token: 0x060011EF RID: 4591 RVA: 0x0005EA2C File Offset: 0x0005CC2C
				public ActionElementMap GetFirstAxisMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.ePoqkUtmPVaqcSRQDEsmWDfPnprd; i++)
					{
						ActionElementMap actionElementMap = this.aeyQjNaHnCkuehEfAjfkwqSanPP(this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.vZrGQvFMXtMVZgyvAVXhqFNCtgsMB(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				// Token: 0x060011F0 RID: 4592 RVA: 0x0005EA98 File Offset: 0x0005CC98
				public ActionElementMap GetFirstAxisMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.GetFirstAxisMapWithAction(actionId, skipDisabledMaps);
				}

				// Token: 0x060011F1 RID: 4593 RVA: 0x0000FF05 File Offset: 0x0000E105
				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return this.AxisMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				// Token: 0x060011F2 RID: 4594 RVA: 0x0000FF1C File Offset: 0x0000E11C
				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return this.AxisMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				// Token: 0x060011F3 RID: 4595 RVA: 0x0000FF33 File Offset: 0x0000E133
				public IEnumerable<ActionElementMap> AxisMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return this.dNHjMvaSTQinNiEbUPBFLuoIZSKm(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				// Token: 0x060011F4 RID: 4596 RVA: 0x0005EAD8 File Offset: 0x0005CCD8
				public IEnumerable<ActionElementMap> AxisMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.AxisMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				// Token: 0x060011F5 RID: 4597 RVA: 0x0000FF71 File Offset: 0x0000E171
				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return this.DCYoIxArJDAiVHkFlQdEFJbfLPmU(controllerType, actionId, skipDisabledMaps);
				}

				// Token: 0x060011F6 RID: 4598 RVA: 0x0005EB1C File Offset: 0x0005CD1C
				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.AxisMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				// Token: 0x060011F7 RID: 4599 RVA: 0x0000FF9B File Offset: 0x0000E19B
				public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						yield break;
					}
					if (actionId < 0)
					{
						yield break;
					}
					int ePoqkUtmPVaqcSRQDEsmWDfPnprd = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.ePoqkUtmPVaqcSRQDEsmWDfPnprd;
					int num3;
					for (int i = 0; i < ePoqkUtmPVaqcSRQDEsmWDfPnprd; i = num3 + 1)
					{
						Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.CtGoIeauMpKsCXqilTCeQCxqyY(i);
						int num = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
						for (int j = 0; j < num; j = num3 + 1)
						{
							dBWjOjXnFJmUROzCVhQpynliVgPI dBWjOjXnFJmUROzCVhQpynliVgPI = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(j).AxzIHFaeuZajYboPHuvsfCYAXoQwA;
							int num2 = dBWjOjXnFJmUROzCVhQpynliVgPI.sSEkNHPvFzDptlNqDocRnDXFEYyY;
							for (int k = 0; k < num2; k = num3 + 1)
							{
								ControllerMapWithAxes controllerMapWithAxes = dBWjOjXnFJmUROzCVhQpynliVgPI.kpSXGnRVLDEHUvJSffrGHSOpEAHGb(k) as ControllerMapWithAxes;
								if (controllerMapWithAxes != null && (!skipDisabledMaps || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(actionId))
								{
									foreach (ActionElementMap actionElementMap in controllerMapWithAxes.AxisMapsWithAction(actionId, skipDisabledMaps))
									{
										yield return actionElementMap;
									}
									IEnumerator<ActionElementMap> enumerator = null;
								}
								num3 = k;
							}
							dBWjOjXnFJmUROzCVhQpynliVgPI = null;
							num3 = j;
						}
						rrrUVbResWNdbXKvkkOIseeimvIu = null;
						num3 = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x060011F8 RID: 4600 RVA: 0x0005EB60 File Offset: 0x0005CD60
				public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.AxisMapsWithAction(actionId, skipDisabledMaps);
				}

				// Token: 0x060011F9 RID: 4601 RVA: 0x0000FFB9 File Offset: 0x0000E1B9
				public int GetAxisMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return this.GetAxisMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps, results);
				}

				// Token: 0x060011FA RID: 4602 RVA: 0x0000FFD2 File Offset: 0x0000E1D2
				public int GetAxisMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return this.GetAxisMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps, results);
				}

				// Token: 0x060011FB RID: 4603 RVA: 0x0000FFEB File Offset: 0x0000E1EB
				public int GetAxisMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					return this.dTrAdAIyxzfrtZZVWuArCzLWNKjH(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				// Token: 0x060011FC RID: 4604 RVA: 0x0005EBA4 File Offset: 0x0005CDA4
				public int GetAxisMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.GetAxisMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				// Token: 0x060011FD RID: 4605 RVA: 0x00010024 File Offset: 0x0000E224
				public int GetAxisMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					return this.UcAupJRCyOoJauHxkmNsyPZuCzFh(controllerType, actionId, skipDisabledMaps, results, false);
				}

				// Token: 0x060011FE RID: 4606 RVA: 0x0005EBE4 File Offset: 0x0005CDE4
				public int GetAxisMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.GetAxisMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				// Token: 0x060011FF RID: 4607 RVA: 0x0001005C File Offset: 0x0000E25C
				public int GetAxisMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return this.NIeSOBgxdrPquPQcWrKSNmurLHl(actionId, skipDisabledMaps, results, false);
				}

				// Token: 0x06001200 RID: 4608 RVA: 0x0005EC24 File Offset: 0x0005CE24
				public int GetAxisMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.GetAxisMapsWithAction(actionId, skipDisabledMaps, results);
				}

				// Token: 0x06001201 RID: 4609 RVA: 0x00010068 File Offset: 0x0000E268
				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return this.GetFirstElementMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				// Token: 0x06001202 RID: 4610 RVA: 0x0001007F File Offset: 0x0000E27F
				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return this.GetFirstElementMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				// Token: 0x06001203 RID: 4611 RVA: 0x00010096 File Offset: 0x0000E296
				public ActionElementMap GetFirstElementMapWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return this.OtgqfarNSXkZjELIeLASPtqPrKIu(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				// Token: 0x06001204 RID: 4612 RVA: 0x0005EC64 File Offset: 0x0005CE64
				public ActionElementMap GetFirstElementMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.GetFirstElementMapWithAction(controller, actionId, skipDisabledMaps);
				}

				// Token: 0x06001205 RID: 4613 RVA: 0x000100CC File Offset: 0x0000E2CC
				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					return this.MWOUhqMtHMofZaqibnLBktHwSugb(controllerType, actionId, skipDisabledMaps);
				}

				// Token: 0x06001206 RID: 4614 RVA: 0x0005ECA4 File Offset: 0x0005CEA4
				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.GetFirstElementMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				// Token: 0x06001207 RID: 4615 RVA: 0x0005ECE4 File Offset: 0x0005CEE4
				public ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.ePoqkUtmPVaqcSRQDEsmWDfPnprd; i++)
					{
						ActionElementMap actionElementMap = this.MWOUhqMtHMofZaqibnLBktHwSugb(this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.vZrGQvFMXtMVZgyvAVXhqFNCtgsMB(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				// Token: 0x06001208 RID: 4616 RVA: 0x0005ED50 File Offset: 0x0005CF50
				public ActionElementMap GetFirstElementMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.GetFirstElementMapWithAction(actionId, skipDisabledMaps);
				}

				// Token: 0x06001209 RID: 4617 RVA: 0x000100F2 File Offset: 0x0000E2F2
				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return this.ElementMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				// Token: 0x0600120A RID: 4618 RVA: 0x00010109 File Offset: 0x0000E309
				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return this.ElementMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				// Token: 0x0600120B RID: 4619 RVA: 0x00010120 File Offset: 0x0000E320
				public IEnumerable<ActionElementMap> ElementMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return this.fCJDNVVGBNvjwubUuqugjLGPdxpBA(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				// Token: 0x0600120C RID: 4620 RVA: 0x0005ED90 File Offset: 0x0005CF90
				public IEnumerable<ActionElementMap> ElementMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.ElementMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				// Token: 0x0600120D RID: 4621 RVA: 0x0001015E File Offset: 0x0000E35E
				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return this.rUUPwjleDpKlZHsmpjSEjbzJtFIb(controllerType, actionId, skipDisabledMaps);
				}

				// Token: 0x0600120E RID: 4622 RVA: 0x0005EDD4 File Offset: 0x0005CFD4
				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.ElementMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				// Token: 0x0600120F RID: 4623 RVA: 0x00010188 File Offset: 0x0000E388
				public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						yield break;
					}
					if (actionId < 0)
					{
						yield break;
					}
					int ePoqkUtmPVaqcSRQDEsmWDfPnprd = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.ePoqkUtmPVaqcSRQDEsmWDfPnprd;
					int num3;
					for (int i = 0; i < ePoqkUtmPVaqcSRQDEsmWDfPnprd; i = num3 + 1)
					{
						Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.CtGoIeauMpKsCXqilTCeQCxqyY(i);
						int num = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
						for (int j = 0; j < num; j = num3 + 1)
						{
							dBWjOjXnFJmUROzCVhQpynliVgPI dBWjOjXnFJmUROzCVhQpynliVgPI = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(j).AxzIHFaeuZajYboPHuvsfCYAXoQwA;
							int num2 = dBWjOjXnFJmUROzCVhQpynliVgPI.sSEkNHPvFzDptlNqDocRnDXFEYyY;
							for (int k = 0; k < num2; k = num3 + 1)
							{
								ControllerMap controllerMap = dBWjOjXnFJmUROzCVhQpynliVgPI.kpSXGnRVLDEHUvJSffrGHSOpEAHGb(k);
								if ((!skipDisabledMaps || controllerMap.enabled) && controllerMap.ContainsAction(actionId))
								{
									foreach (ActionElementMap actionElementMap in controllerMap.ElementMapsWithAction(actionId, skipDisabledMaps))
									{
										yield return actionElementMap;
									}
									IEnumerator<ActionElementMap> enumerator = null;
								}
								num3 = k;
							}
							dBWjOjXnFJmUROzCVhQpynliVgPI = null;
							num3 = j;
						}
						rrrUVbResWNdbXKvkkOIseeimvIu = null;
						num3 = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x06001210 RID: 4624 RVA: 0x0005EE18 File Offset: 0x0005D018
				public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.ElementMapsWithAction(actionId, skipDisabledMaps);
				}

				// Token: 0x06001211 RID: 4625 RVA: 0x000101A6 File Offset: 0x0000E3A6
				public int GetElementMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return this.GetElementMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps, results);
				}

				// Token: 0x06001212 RID: 4626 RVA: 0x000101BF File Offset: 0x0000E3BF
				public int GetElementMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return this.GetElementMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps, results);
				}

				// Token: 0x06001213 RID: 4627 RVA: 0x000101D8 File Offset: 0x0000E3D8
				public int GetElementMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					return this.dZtPZwJKsnLOBugeyfgacYNaenrxA(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				// Token: 0x06001214 RID: 4628 RVA: 0x0005EE5C File Offset: 0x0005D05C
				public int GetElementMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.GetElementMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				// Token: 0x06001215 RID: 4629 RVA: 0x00010211 File Offset: 0x0000E411
				public int GetElementMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					return this.CFnpOmKznRMQviliRQZkQOwDcLgS(controllerType, actionId, skipDisabledMaps, results, false);
				}

				// Token: 0x06001216 RID: 4630 RVA: 0x0005EE9C File Offset: 0x0005D09C
				public int GetElementMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.GetElementMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				// Token: 0x06001217 RID: 4631 RVA: 0x0001023A File Offset: 0x0000E43A
				public int GetElementMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return this.CQfYczEYoOollBKDaPkianGEzacc(actionId, skipDisabledMaps, results, false);
				}

				// Token: 0x06001218 RID: 4632 RVA: 0x0005EEDC File Offset: 0x0005D0DC
				public int GetElementMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.GetElementMapsWithAction(actionId, skipDisabledMaps, results);
				}

				// Token: 0x06001219 RID: 4633 RVA: 0x0005EF1C File Offset: 0x0005D11C
				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					CQMiAtCKCBeBxcvQtMWaEstcdgFPA cqmiAtCKCBeBxcvQtMWaEstcdgFPA = CQMiAtCKCBeBxcvQtMWaEstcdgFPA.awUDFAvrkgZegheEODIWTzvDUnFG(elementTarget);
					IEnumerable<ActionElementMap> result = this.ElementMapsWithElementTarget(cqmiAtCKCBeBxcvQtMWaEstcdgFPA, skipDisabledMaps);
					CQMiAtCKCBeBxcvQtMWaEstcdgFPA.nCRlKMWMlcpJInXrvtLslXZSGRhP(cqmiAtCKCBeBxcvQtMWaEstcdgFPA);
					return result;
				}

				// Token: 0x0600121A RID: 4634 RVA: 0x00010246 File Offset: 0x0000E446
				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					return this.lmYuFRzvdSaWEjFJdsfrfXwfrSaA(elementTarget, false, -1, skipDisabledMaps);
				}

				// Token: 0x0600121B RID: 4635 RVA: 0x0005EF60 File Offset: 0x0005D160
				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					CQMiAtCKCBeBxcvQtMWaEstcdgFPA cqmiAtCKCBeBxcvQtMWaEstcdgFPA = CQMiAtCKCBeBxcvQtMWaEstcdgFPA.awUDFAvrkgZegheEODIWTzvDUnFG(elementTarget);
					IEnumerable<ActionElementMap> result = this.ElementMapsWithElementTarget(cqmiAtCKCBeBxcvQtMWaEstcdgFPA, actionId, skipDisabledMaps);
					CQMiAtCKCBeBxcvQtMWaEstcdgFPA.nCRlKMWMlcpJInXrvtLslXZSGRhP(cqmiAtCKCBeBxcvQtMWaEstcdgFPA);
					return result;
				}

				// Token: 0x0600121C RID: 4636 RVA: 0x0005EFA4 File Offset: 0x0005D1A4
				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				// Token: 0x0600121D RID: 4637 RVA: 0x00010252 File Offset: 0x0000E452
				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					return this.lmYuFRzvdSaWEjFJdsfrfXwfrSaA(elementTarget, true, actionId, skipDisabledMaps);
				}

				// Token: 0x0600121E RID: 4638 RVA: 0x0005EFE8 File Offset: 0x0005D1E8
				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				// Token: 0x0600121F RID: 4639 RVA: 0x0005F00C File Offset: 0x0005D20C
				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					CQMiAtCKCBeBxcvQtMWaEstcdgFPA cqmiAtCKCBeBxcvQtMWaEstcdgFPA = CQMiAtCKCBeBxcvQtMWaEstcdgFPA.awUDFAvrkgZegheEODIWTzvDUnFG(elementTarget);
					ActionElementMap firstElementMapWithElementTarget = this.GetFirstElementMapWithElementTarget(cqmiAtCKCBeBxcvQtMWaEstcdgFPA, skipDisabledMaps);
					CQMiAtCKCBeBxcvQtMWaEstcdgFPA.nCRlKMWMlcpJInXrvtLslXZSGRhP(cqmiAtCKCBeBxcvQtMWaEstcdgFPA);
					return firstElementMapWithElementTarget;
				}

				// Token: 0x06001220 RID: 4640 RVA: 0x0001025E File Offset: 0x0000E45E
				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					return this.QtNoHqSOEXgeXbnAGcLBNtPrnHamA(elementTarget, false, -1, skipDisabledMaps);
				}

				// Token: 0x06001221 RID: 4641 RVA: 0x0005F04C File Offset: 0x0005D24C
				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					CQMiAtCKCBeBxcvQtMWaEstcdgFPA cqmiAtCKCBeBxcvQtMWaEstcdgFPA = CQMiAtCKCBeBxcvQtMWaEstcdgFPA.awUDFAvrkgZegheEODIWTzvDUnFG(elementTarget);
					ActionElementMap firstElementMapWithElementTarget = this.GetFirstElementMapWithElementTarget(cqmiAtCKCBeBxcvQtMWaEstcdgFPA, actionId, skipDisabledMaps);
					CQMiAtCKCBeBxcvQtMWaEstcdgFPA.nCRlKMWMlcpJInXrvtLslXZSGRhP(cqmiAtCKCBeBxcvQtMWaEstcdgFPA);
					return firstElementMapWithElementTarget;
				}

				// Token: 0x06001222 RID: 4642 RVA: 0x0005F08C File Offset: 0x0005D28C
				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				// Token: 0x06001223 RID: 4643 RVA: 0x0001026A File Offset: 0x0000E46A
				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					return this.QtNoHqSOEXgeXbnAGcLBNtPrnHamA(elementTarget, true, actionId, skipDisabledMaps);
				}

				// Token: 0x06001224 RID: 4644 RVA: 0x0005F0CC File Offset: 0x0005D2CC
				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				// Token: 0x06001225 RID: 4645 RVA: 0x0005F10C File Offset: 0x0005D30C
				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					CQMiAtCKCBeBxcvQtMWaEstcdgFPA cqmiAtCKCBeBxcvQtMWaEstcdgFPA = CQMiAtCKCBeBxcvQtMWaEstcdgFPA.awUDFAvrkgZegheEODIWTzvDUnFG(elementTarget);
					int elementMapsWithElementTarget = this.GetElementMapsWithElementTarget(cqmiAtCKCBeBxcvQtMWaEstcdgFPA, skipDisabledMaps, results);
					CQMiAtCKCBeBxcvQtMWaEstcdgFPA.nCRlKMWMlcpJInXrvtLslXZSGRhP(cqmiAtCKCBeBxcvQtMWaEstcdgFPA);
					return elementMapsWithElementTarget;
				}

				// Token: 0x06001226 RID: 4646 RVA: 0x00010276 File Offset: 0x0000E476
				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return this.uJnxVkMLoCiqyhOSKOsXGOrjOtqlB(elementTarget, false, -1, skipDisabledMaps, results, false);
				}

				// Token: 0x06001227 RID: 4647 RVA: 0x0005F14C File Offset: 0x0005D34C
				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					CQMiAtCKCBeBxcvQtMWaEstcdgFPA cqmiAtCKCBeBxcvQtMWaEstcdgFPA = CQMiAtCKCBeBxcvQtMWaEstcdgFPA.awUDFAvrkgZegheEODIWTzvDUnFG(elementTarget);
					int elementMapsWithElementTarget = this.GetElementMapsWithElementTarget(cqmiAtCKCBeBxcvQtMWaEstcdgFPA, actionId, skipDisabledMaps, results);
					CQMiAtCKCBeBxcvQtMWaEstcdgFPA.nCRlKMWMlcpJInXrvtLslXZSGRhP(cqmiAtCKCBeBxcvQtMWaEstcdgFPA);
					return elementMapsWithElementTarget;
				}

				// Token: 0x06001228 RID: 4648 RVA: 0x0005F18C File Offset: 0x0005D38C
				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
				}

				// Token: 0x06001229 RID: 4649 RVA: 0x00010284 File Offset: 0x0000E484
				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return this.uJnxVkMLoCiqyhOSKOsXGOrjOtqlB(elementTarget, true, actionId, skipDisabledMaps, results, false);
				}

				// Token: 0x0600122A RID: 4650 RVA: 0x0005F1CC File Offset: 0x0005D3CC
				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
					return this.GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
				}

				// Token: 0x0600122B RID: 4651 RVA: 0x00010293 File Offset: 0x0000E493
				public T[] GetMapSaveData<T>(int controllerId, bool userAssignableMapsOnly) where T : ControllerMapSaveData
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<T>.array;
					}
					return this.yVlDpxrtoeuvRvInIgNzSLeiokvk<T>(controllerId, userAssignableMapsOnly);
				}

				// Token: 0x0600122C RID: 4652 RVA: 0x000102BC File Offset: 0x0000E4BC
				public ControllerMapSaveData[] GetMapSaveData(ControllerType controllerType, int controllerId, bool userAssignableMapsOnly)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					return this.YKjYPpmcePnnCyVEuOOTCbSTILHD(controllerType, controllerId, userAssignableMapsOnly);
				}

				// Token: 0x0600122D RID: 4653 RVA: 0x000102E6 File Offset: 0x0000E4E6
				public T[] GetAllMapSaveData<T>(bool userAssignableMapsOnly) where T : ControllerMapSaveData
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<T>.array;
					}
					return this.nfAiTFHRzKYWyqLSpvFKbaSVhXsgb<T>(userAssignableMapsOnly);
				}

				// Token: 0x0600122E RID: 4654 RVA: 0x0001030E File Offset: 0x0000E50E
				public ControllerMapSaveData[] GetAllMapSaveData(ControllerType controllerType, bool userAssignableMapsOnly)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					return this.ZKDwtRsHZjxAxfUymmpMBNcDxOAC(controllerType, userAssignableMapsOnly);
				}

				// Token: 0x0600122F RID: 4655 RVA: 0x0005F20C File Offset: 0x0005D40C
				public ControllerMapSaveData[] GetAllMapSaveData(bool userAssignableMapsOnly)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					ControllerMapSaveData[] result = null;
					for (int i = 0; i < this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.ePoqkUtmPVaqcSRQDEsmWDfPnprd; i++)
					{
						ArrayTools.Combine<ControllerMapSaveData>(ref result, this.ZKDwtRsHZjxAxfUymmpMBNcDxOAC(this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.vZrGQvFMXtMVZgyvAVXhqFNCtgsMB(i), userAssignableMapsOnly));
					}
					return result;
				}

				// Token: 0x06001230 RID: 4656 RVA: 0x0005F278 File Offset: 0x0005D478
				public int SetAllMapsEnabled(bool state)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					int num = 0;
					int ePoqkUtmPVaqcSRQDEsmWDfPnprd = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.ePoqkUtmPVaqcSRQDEsmWDfPnprd;
					for (int i = 0; i < ePoqkUtmPVaqcSRQDEsmWDfPnprd; i++)
					{
						Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.CtGoIeauMpKsCXqilTCeQCxqyY(i);
						int num2 = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
						for (int j = 0; j < num2; j++)
						{
							num += rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(j).AxzIHFaeuZajYboPHuvsfCYAXoQwA.UNITdqxjVWCrMBOmTgrhrcmoDyPTA(state);
						}
					}
					return num;
				}

				// Token: 0x06001231 RID: 4657 RVA: 0x0005F304 File Offset: 0x0005D504
				public int SetAllMapsEnabled(bool state, ControllerType controllerType)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					int num = 0;
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controllerType);
					int num2 = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
					for (int i = 0; i < num2; i++)
					{
						num += rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA.UNITdqxjVWCrMBOmTgrhrcmoDyPTA(state);
					}
					return num;
				}

				// Token: 0x06001232 RID: 4658 RVA: 0x00010337 File Offset: 0x0000E537
				public int SetAllMapsEnabled(bool state, Controller controller)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					return this.SetAllMapsEnabled(state, controller.type, controller.id);
				}

				// Token: 0x06001233 RID: 4659 RVA: 0x0005F36C File Offset: 0x0005D56C
				public int SetAllMapsEnabled(bool state, ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					Player.ControllerHelper.aDTWAvwJDeCLlGzuGUJORYARFABdA aDTWAvwJDeCLlGzuGUJORYARFABdA = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controllerType).cLCIFSrSsIdpuGCXMXmeTmizjypZ(controllerId);
					if (aDTWAvwJDeCLlGzuGUJORYARFABdA == null)
					{
						return 0;
					}
					return aDTWAvwJDeCLlGzuGUJORYARFABdA.AxzIHFaeuZajYboPHuvsfCYAXoQwA.UNITdqxjVWCrMBOmTgrhrcmoDyPTA(state);
				}

				// Token: 0x06001234 RID: 4660 RVA: 0x0005F3C0 File Offset: 0x0005D5C0
				public int SetMapsEnabled(bool state, int categoryId)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					int num = 0;
					int ePoqkUtmPVaqcSRQDEsmWDfPnprd = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.ePoqkUtmPVaqcSRQDEsmWDfPnprd;
					for (int i = 0; i < ePoqkUtmPVaqcSRQDEsmWDfPnprd; i++)
					{
						Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.CtGoIeauMpKsCXqilTCeQCxqyY(i);
						int num2 = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
						for (int j = 0; j < num2; j++)
						{
							num += rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(j).AxzIHFaeuZajYboPHuvsfCYAXoQwA.sKMZetBhbyTaIpBVSotHtwwBKnxc(state, categoryId);
						}
					}
					return num;
				}

				// Token: 0x06001235 RID: 4661 RVA: 0x0005F450 File Offset: 0x0005D650
				public int SetMapsEnabled(bool state, string categoryName)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return this.SetMapsEnabled(state, mapCategoryId);
				}

				// Token: 0x06001236 RID: 4662 RVA: 0x0005F494 File Offset: 0x0005D694
				public int SetMapsEnabled(bool state, string categoryName, string layoutName)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					int num = 0;
					int ePoqkUtmPVaqcSRQDEsmWDfPnprd = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.ePoqkUtmPVaqcSRQDEsmWDfPnprd;
					for (int i = 0; i < ePoqkUtmPVaqcSRQDEsmWDfPnprd; i++)
					{
						ControllerType controllerType = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.vZrGQvFMXtMVZgyvAVXhqFNCtgsMB(i);
						int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
						if (layoutId >= 0)
						{
							num += this.SetMapsEnabled(state, controllerType, mapCategoryId, layoutId);
						}
					}
					return num;
				}

				// Token: 0x06001237 RID: 4663 RVA: 0x0005F524 File Offset: 0x0005D724
				public int SetMapsEnabled(bool state, ControllerType controllerType, int categoryId)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					int num = 0;
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controllerType);
					int num2 = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
					for (int i = 0; i < num2; i++)
					{
						num += rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA.sKMZetBhbyTaIpBVSotHtwwBKnxc(state, categoryId);
					}
					return num;
				}

				// Token: 0x06001238 RID: 4664 RVA: 0x0005F590 File Offset: 0x0005D790
				public int SetMapsEnabled(bool state, ControllerType controllerType, string categoryName)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return this.SetMapsEnabled(state, controllerType, mapCategoryId);
				}

				// Token: 0x06001239 RID: 4665 RVA: 0x0005F5D4 File Offset: 0x0005D7D4
				public int SetMapsEnabled(bool state, ControllerType controllerType, int categoryId, int layoutId)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return 0;
					}
					int num = 0;
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controllerType);
					int num2 = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
					for (int i = 0; i < num2; i++)
					{
						num += rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA.HUYkDNfplHJbKxpbWdFcQGSTgyzR(state, categoryId, layoutId);
					}
					return num;
				}

				// Token: 0x0600123A RID: 4666 RVA: 0x0005F648 File Offset: 0x0005D848
				public int SetMapsEnabled(bool state, ControllerType controllerType, string categoryName, string layoutName)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
					if (layoutId < 0)
					{
						return 0;
					}
					return this.SetMapsEnabled(state, controllerType, mapCategoryId, layoutId);
				}

				// Token: 0x0600123B RID: 4667 RVA: 0x0005F6A0 File Offset: 0x0005D8A0
				public int SetMapsEnabled(bool state, Controller controller, int categoryId)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					Player.ControllerHelper.aDTWAvwJDeCLlGzuGUJORYARFABdA aDTWAvwJDeCLlGzuGUJORYARFABdA = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controller.type).cLCIFSrSsIdpuGCXMXmeTmizjypZ(controller.id);
					if (aDTWAvwJDeCLlGzuGUJORYARFABdA == null)
					{
						return 0;
					}
					return aDTWAvwJDeCLlGzuGUJORYARFABdA.AxzIHFaeuZajYboPHuvsfCYAXoQwA.sKMZetBhbyTaIpBVSotHtwwBKnxc(state, categoryId);
				}

				// Token: 0x0600123C RID: 4668 RVA: 0x0005F708 File Offset: 0x0005D908
				public int SetMapsEnabled(bool state, Controller controller, int categoryId, int layoutId)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					if (layoutId < 0)
					{
						return 0;
					}
					Player.ControllerHelper.aDTWAvwJDeCLlGzuGUJORYARFABdA aDTWAvwJDeCLlGzuGUJORYARFABdA = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controller.type).cLCIFSrSsIdpuGCXMXmeTmizjypZ(controller.id);
					if (aDTWAvwJDeCLlGzuGUJORYARFABdA == null)
					{
						return 0;
					}
					return aDTWAvwJDeCLlGzuGUJORYARFABdA.AxzIHFaeuZajYboPHuvsfCYAXoQwA.HUYkDNfplHJbKxpbWdFcQGSTgyzR(state, categoryId, layoutId);
				}

				// Token: 0x0600123D RID: 4669 RVA: 0x0005F778 File Offset: 0x0005D978
				public int SetMapsEnabled(bool state, Controller controller, string categoryName)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return this.SetMapsEnabled(state, controller, mapCategoryId);
				}

				// Token: 0x0600123E RID: 4670 RVA: 0x0005F7C0 File Offset: 0x0005D9C0
				public int SetMapsEnabled(bool state, Controller controller, string categoryName, string layoutName)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					int layoutId = ReInput.mapping.GetLayoutId(controller.type, layoutName);
					if (layoutId < 0)
					{
						return 0;
					}
					return this.SetMapsEnabled(state, controller, mapCategoryId, layoutId);
				}

				// Token: 0x0600123F RID: 4671 RVA: 0x0005F824 File Offset: 0x0005DA24
				public void LoadDefaultMaps(ControllerType controllerType)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return;
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						this.OWbhytsFSgGBTJhNRHnpnYugjwSjA(false);
						return;
					case ControllerType.Mouse:
						this.YyYGTEVcuixmjnDUgDCagYJBERPJ(false);
						return;
					case ControllerType.Joystick:
						this.MuxdCzJQgiXaymJMFPBAyPsfqHlwA(false);
						return;
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						this.sOGTZHBDVkFPXgbNgxVNpAEaUiyFA(false);
						return;
					}
				}

				// Token: 0x06001240 RID: 4672 RVA: 0x0001036C File Offset: 0x0000E56C
				public bool ContainsMapInCategory(InputMapCategory category)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return false;
					}
					return category != null && this.ContainsMapInCategory(category.id);
				}

				// Token: 0x06001241 RID: 4673 RVA: 0x0005F88C File Offset: 0x0005DA8C
				public bool ContainsMapInCategory(int categoryId)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return false;
					}
					if (categoryId < 0)
					{
						return false;
					}
					int ePoqkUtmPVaqcSRQDEsmWDfPnprd = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.ePoqkUtmPVaqcSRQDEsmWDfPnprd;
					for (int i = 0; i < ePoqkUtmPVaqcSRQDEsmWDfPnprd; i++)
					{
						Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.CtGoIeauMpKsCXqilTCeQCxqyY(i);
						int num = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
						for (int j = 0; j < num; j++)
						{
							if (rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(j).AxzIHFaeuZajYboPHuvsfCYAXoQwA.XXLzFBBDgzbNQWNdTFFBjlZJmMlG(categoryId))
							{
								return true;
							}
						}
					}
					return false;
				}

				// Token: 0x06001242 RID: 4674 RVA: 0x0005F918 File Offset: 0x0005DB18
				public bool ContainsMapInCategory(string categoryName)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return false;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					return mapCategoryId >= 0 && this.ContainsMapInCategory(mapCategoryId);
				}

				// Token: 0x06001243 RID: 4675 RVA: 0x0005F95C File Offset: 0x0005DB5C
				public bool ContainsMapInCategory(ControllerType controllerType, int categoryId)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return false;
					}
					if (categoryId < 0)
					{
						return false;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controllerType);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
					for (int i = 0; i < num; i++)
					{
						if (rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA.XXLzFBBDgzbNQWNdTFFBjlZJmMlG(categoryId))
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x17000495 RID: 1173
				// (get) Token: 0x06001244 RID: 4676 RVA: 0x0001039A File Offset: 0x0000E59A
				public IList<InputBehavior> InputBehaviors
				{
					get
					{
						if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
						{
							ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
							return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
						}
						return this.lawNLFQVYtOrvswGWUkKybfZHlLj.LuhdSyQNGuuUqPpzFxduIHmdweOD.GQKrzCeHKYCGeeITLHuwkPHlAsjfA(this.lawNLFQVYtOrvswGWUkKybfZHlLj.slhAWVVynuDdrqbdGKDoRVmsCDYo);
					}
				}

				// Token: 0x06001245 RID: 4677 RVA: 0x000103D6 File Offset: 0x0000E5D6
				public InputBehavior GetInputBehavior(int behaviorId)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					return this.lawNLFQVYtOrvswGWUkKybfZHlLj.LuhdSyQNGuuUqPpzFxduIHmdweOD.EpjSylEaBjOfajGuxXTwARPJWJVB(this.lawNLFQVYtOrvswGWUkKybfZHlLj.slhAWVVynuDdrqbdGKDoRVmsCDYo, behaviorId);
				}

				// Token: 0x06001246 RID: 4678 RVA: 0x0001040F File Offset: 0x0000E60F
				public InputBehavior GetInputBehavior(string behaviorName)
				{
					if (ReInput._id != this.OQaPFYxSGgKObINRruqbxILdjVUO)
					{
						ReInput.CheckInitialized(this.OQaPFYxSGgKObINRruqbxILdjVUO);
						return null;
					}
					return this.lawNLFQVYtOrvswGWUkKybfZHlLj.LuhdSyQNGuuUqPpzFxduIHmdweOD.FWPTsWMVwaoDtMaEHkKjEPcsctDH(this.lawNLFQVYtOrvswGWUkKybfZHlLj.slhAWVVynuDdrqbdGKDoRVmsCDYo, behaviorName);
				}

				// Token: 0x06001247 RID: 4679 RVA: 0x00010448 File Offset: 0x0000E648
				internal void XiKuVCsnqmDYXfPkWvRSrgnzyINFA()
				{
					this.PcMgoVlXoOYNqGgBwoSEwICaMdvB.LoadDefaults();
					this.ZZgzMQjqyDvJGNjcVqvujpABedsN.LoadDefaults();
				}

				// Token: 0x06001248 RID: 4680 RVA: 0x0005F9C8 File Offset: 0x0005DBC8
				internal void MuxdCzJQgiXaymJMFPBAyPsfqHlwA(bool A_1)
				{
					if (this.rnFfambBUNgqcfQyoQGVXGnHKdbeA.ElsACWhefOftDpkPUwnxivhQAmgCA == null)
					{
						return;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(ControllerType.Joystick);
					this.WQtQfVGCqewEYhTXSMYhGCZQawTm.BhYmddYjQBpTYSjebSXDXGRpyVFj.APGgjpZuidgONTMskLIciYQxfnqw();
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
					for (int i = 0; i < num; i++)
					{
						Player<Joystick, JoystickMap>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi.gkFtqSotlvjTxqHWDAWBgsGdsVUL gkFtqSotlvjTxqHWDAWBgsGdsVUL = (Player<Joystick, JoystickMap>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi.gkFtqSotlvjTxqHWDAWBgsGdsVUL)rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i);
						bool[] array = null;
						if (!A_1)
						{
							int num2 = gkFtqSotlvjTxqHWDAWBgsGdsVUL.SYeOZTgTBzpCRvaSMSDtNBsRaIdX.sSEkNHPvFzDptlNqDocRnDXFEYyY;
							array = new bool[num2];
							for (int j = 0; j < num2; j++)
							{
								array[j] = gkFtqSotlvjTxqHWDAWBgsGdsVUL.SYeOZTgTBzpCRvaSMSDtNBsRaIdX.ZEabTYdmnsjYhGfIgxpgnyvGMRBRA(j).enabled;
							}
						}
						gkFtqSotlvjTxqHWDAWBgsGdsVUL.SYeOZTgTBzpCRvaSMSDtNBsRaIdX.tmBRdtPykIReQLInHLQFKwDnAwME(false);
						for (int k = 0; k < this.rnFfambBUNgqcfQyoQGVXGnHKdbeA.ElsACWhefOftDpkPUwnxivhQAmgCA.Length; k++)
						{
							this.zXKBDoeZNcYYESOKJGNibuFQyvTnA(gkFtqSotlvjTxqHWDAWBgsGdsVUL.VLnBmkNlWHuWGKNvpysrhMLAvwWA, gkFtqSotlvjTxqHWDAWBgsGdsVUL.SYeOZTgTBzpCRvaSMSDtNBsRaIdX, this.rnFfambBUNgqcfQyoQGVXGnHKdbeA.ElsACWhefOftDpkPUwnxivhQAmgCA[k], A_1);
						}
						if (!A_1)
						{
							int num3 = MathTools.Min(array.Length, gkFtqSotlvjTxqHWDAWBgsGdsVUL.SYeOZTgTBzpCRvaSMSDtNBsRaIdX.sSEkNHPvFzDptlNqDocRnDXFEYyY);
							for (int l = 0; l < num3; l++)
							{
								gkFtqSotlvjTxqHWDAWBgsGdsVUL.SYeOZTgTBzpCRvaSMSDtNBsRaIdX.ZEabTYdmnsjYhGfIgxpgnyvGMRBRA(l).enabled = array[l];
							}
						}
					}
					bool loadFromUserDataStore = this.ZZgzMQjqyDvJGNjcVqvujpABedsN.loadFromUserDataStore;
					this.ZZgzMQjqyDvJGNjcVqvujpABedsN.loadFromUserDataStore = false;
					this.ZZgzMQjqyDvJGNjcVqvujpABedsN.Apply();
					this.ZZgzMQjqyDvJGNjcVqvujpABedsN.loadFromUserDataStore = loadFromUserDataStore;
				}

				// Token: 0x06001249 RID: 4681 RVA: 0x0005FB2C File Offset: 0x0005DD2C
				internal void OWbhytsFSgGBTJhNRHnpnYugjwSjA(bool A_1)
				{
					if (this.rnFfambBUNgqcfQyoQGVXGnHKdbeA.EAscYrmemVhAgqNeUREdsprUXUQH == null)
					{
						return;
					}
					dBWjOjXnFJmUROzCVhQpynliVgPI dBWjOjXnFJmUROzCVhQpynliVgPI = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(ControllerType.Keyboard).cLCIFSrSsIdpuGCXMXmeTmizjypZ(0).AxzIHFaeuZajYboPHuvsfCYAXoQwA;
					bool[] array = null;
					if (!A_1)
					{
						int num = dBWjOjXnFJmUROzCVhQpynliVgPI.sSEkNHPvFzDptlNqDocRnDXFEYyY;
						array = new bool[num];
						for (int i = 0; i < num; i++)
						{
							array[i] = dBWjOjXnFJmUROzCVhQpynliVgPI.kpSXGnRVLDEHUvJSffrGHSOpEAHGb(i).enabled;
						}
					}
					dBWjOjXnFJmUROzCVhQpynliVgPI.JbPLwrAbznxbaWUUYECUbidMmFaS(false);
					for (int j = 0; j < this.rnFfambBUNgqcfQyoQGVXGnHKdbeA.EAscYrmemVhAgqNeUREdsprUXUQH.Length; j++)
					{
						UkACnUMHYxhtrputCZbaeXOybpyB ukACnUMHYxhtrputCZbaeXOybpyB = this.rnFfambBUNgqcfQyoQGVXGnHKdbeA.EAscYrmemVhAgqNeUREdsprUXUQH[j];
						if (ukACnUMHYxhtrputCZbaeXOybpyB.jZQdpALLgjCNvDcRkmXqCFEhdhkh >= 0 && ukACnUMHYxhtrputCZbaeXOybpyB.KwGLDvUPdGjXcMzYgfJjBnZIuPzt >= 0)
						{
							KeyboardMap keyboardMap = ReInput.UserData.FindKeyboardMap_Game(ReInput.controllers.Keyboard, ukACnUMHYxhtrputCZbaeXOybpyB.jZQdpALLgjCNvDcRkmXqCFEhdhkh, ukACnUMHYxhtrputCZbaeXOybpyB.KwGLDvUPdGjXcMzYgfJjBnZIuPzt);
							if (A_1)
							{
								keyboardMap.enabled = ukACnUMHYxhtrputCZbaeXOybpyB.JSNOHtFJDdbaEBVFzLkIiYOATlKIB;
							}
							this.IneFPGeuYcGLvxXmrConOANRhreo(ControllerType.Keyboard, 0, keyboardMap, BoolOption.Default);
						}
					}
					if (!A_1)
					{
						int num2 = MathTools.Min(array.Length, dBWjOjXnFJmUROzCVhQpynliVgPI.sSEkNHPvFzDptlNqDocRnDXFEYyY);
						for (int k = 0; k < num2; k++)
						{
							dBWjOjXnFJmUROzCVhQpynliVgPI.kpSXGnRVLDEHUvJSffrGHSOpEAHGb(k).enabled = array[k];
						}
					}
					bool loadFromUserDataStore = this.ZZgzMQjqyDvJGNjcVqvujpABedsN.loadFromUserDataStore;
					this.ZZgzMQjqyDvJGNjcVqvujpABedsN.loadFromUserDataStore = false;
					this.ZZgzMQjqyDvJGNjcVqvujpABedsN.Apply();
					this.ZZgzMQjqyDvJGNjcVqvujpABedsN.loadFromUserDataStore = loadFromUserDataStore;
				}

				// Token: 0x0600124A RID: 4682 RVA: 0x0005FC80 File Offset: 0x0005DE80
				internal void YyYGTEVcuixmjnDUgDCagYJBERPJ(bool A_1)
				{
					if (this.rnFfambBUNgqcfQyoQGVXGnHKdbeA.IBHuSNciQbBmaMNIJRZSjSjOISMW == null)
					{
						return;
					}
					dBWjOjXnFJmUROzCVhQpynliVgPI dBWjOjXnFJmUROzCVhQpynliVgPI = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(ControllerType.Mouse).cLCIFSrSsIdpuGCXMXmeTmizjypZ(0).AxzIHFaeuZajYboPHuvsfCYAXoQwA;
					bool[] array = null;
					if (!A_1)
					{
						int num = dBWjOjXnFJmUROzCVhQpynliVgPI.sSEkNHPvFzDptlNqDocRnDXFEYyY;
						array = new bool[num];
						for (int i = 0; i < num; i++)
						{
							array[i] = dBWjOjXnFJmUROzCVhQpynliVgPI.kpSXGnRVLDEHUvJSffrGHSOpEAHGb(i).enabled;
						}
					}
					dBWjOjXnFJmUROzCVhQpynliVgPI.JbPLwrAbznxbaWUUYECUbidMmFaS(false);
					for (int j = 0; j < this.rnFfambBUNgqcfQyoQGVXGnHKdbeA.IBHuSNciQbBmaMNIJRZSjSjOISMW.Length; j++)
					{
						UkACnUMHYxhtrputCZbaeXOybpyB ukACnUMHYxhtrputCZbaeXOybpyB = this.rnFfambBUNgqcfQyoQGVXGnHKdbeA.IBHuSNciQbBmaMNIJRZSjSjOISMW[j];
						if (ukACnUMHYxhtrputCZbaeXOybpyB.jZQdpALLgjCNvDcRkmXqCFEhdhkh >= 0 && ukACnUMHYxhtrputCZbaeXOybpyB.KwGLDvUPdGjXcMzYgfJjBnZIuPzt >= 0)
						{
							MouseMap mouseMap = ReInput.UserData.FindMouseMap_Game(ReInput.controllers.Mouse, ukACnUMHYxhtrputCZbaeXOybpyB.jZQdpALLgjCNvDcRkmXqCFEhdhkh, ukACnUMHYxhtrputCZbaeXOybpyB.KwGLDvUPdGjXcMzYgfJjBnZIuPzt);
							if (A_1)
							{
								mouseMap.enabled = ukACnUMHYxhtrputCZbaeXOybpyB.JSNOHtFJDdbaEBVFzLkIiYOATlKIB;
							}
							this.IneFPGeuYcGLvxXmrConOANRhreo(ControllerType.Mouse, 0, mouseMap, BoolOption.Default);
						}
					}
					if (!A_1)
					{
						int num2 = MathTools.Min(array.Length, dBWjOjXnFJmUROzCVhQpynliVgPI.sSEkNHPvFzDptlNqDocRnDXFEYyY);
						for (int k = 0; k < num2; k++)
						{
							dBWjOjXnFJmUROzCVhQpynliVgPI.kpSXGnRVLDEHUvJSffrGHSOpEAHGb(k).enabled = array[k];
						}
					}
					bool loadFromUserDataStore = this.ZZgzMQjqyDvJGNjcVqvujpABedsN.loadFromUserDataStore;
					this.ZZgzMQjqyDvJGNjcVqvujpABedsN.loadFromUserDataStore = false;
					this.ZZgzMQjqyDvJGNjcVqvujpABedsN.Apply();
					this.ZZgzMQjqyDvJGNjcVqvujpABedsN.loadFromUserDataStore = loadFromUserDataStore;
				}

				// Token: 0x0600124B RID: 4683 RVA: 0x0005FDD4 File Offset: 0x0005DFD4
				internal void sOGTZHBDVkFPXgbNgxVNpAEaUiyFA(bool A_1)
				{
					if (this.rnFfambBUNgqcfQyoQGVXGnHKdbeA.gbiBgdpEMjfwiiLEplXSZOrjAEObA == null)
					{
						return;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(ControllerType.Custom);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
					for (int i = 0; i < num; i++)
					{
						Player<CustomController, CustomControllerMap>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi.gkFtqSotlvjTxqHWDAWBgsGdsVUL gkFtqSotlvjTxqHWDAWBgsGdsVUL = (Player<CustomController, CustomControllerMap>.ControllerHelper.njAlpuqmuMmkinJFduspVuiWfiHi.gkFtqSotlvjTxqHWDAWBgsGdsVUL)rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i);
						bool[] array = null;
						if (!A_1)
						{
							int num2 = gkFtqSotlvjTxqHWDAWBgsGdsVUL.SYeOZTgTBzpCRvaSMSDtNBsRaIdX.sSEkNHPvFzDptlNqDocRnDXFEYyY;
							array = new bool[num2];
							for (int j = 0; j < num2; j++)
							{
								array[j] = gkFtqSotlvjTxqHWDAWBgsGdsVUL.SYeOZTgTBzpCRvaSMSDtNBsRaIdX.ZEabTYdmnsjYhGfIgxpgnyvGMRBRA(j).enabled;
							}
						}
						gkFtqSotlvjTxqHWDAWBgsGdsVUL.SYeOZTgTBzpCRvaSMSDtNBsRaIdX.tmBRdtPykIReQLInHLQFKwDnAwME(false);
						for (int k = 0; k < this.rnFfambBUNgqcfQyoQGVXGnHKdbeA.gbiBgdpEMjfwiiLEplXSZOrjAEObA.Length; k++)
						{
							this.EMuQcBsoYnbeJBPprugRyVUYlTZj(gkFtqSotlvjTxqHWDAWBgsGdsVUL.VLnBmkNlWHuWGKNvpysrhMLAvwWA, gkFtqSotlvjTxqHWDAWBgsGdsVUL.SYeOZTgTBzpCRvaSMSDtNBsRaIdX, this.rnFfambBUNgqcfQyoQGVXGnHKdbeA.gbiBgdpEMjfwiiLEplXSZOrjAEObA[k], A_1);
						}
						if (!A_1)
						{
							int num3 = MathTools.Min(array.Length, gkFtqSotlvjTxqHWDAWBgsGdsVUL.SYeOZTgTBzpCRvaSMSDtNBsRaIdX.sSEkNHPvFzDptlNqDocRnDXFEYyY);
							for (int l = 0; l < num3; l++)
							{
								gkFtqSotlvjTxqHWDAWBgsGdsVUL.SYeOZTgTBzpCRvaSMSDtNBsRaIdX.ZEabTYdmnsjYhGfIgxpgnyvGMRBRA(l).enabled = array[l];
							}
						}
					}
					bool loadFromUserDataStore = this.ZZgzMQjqyDvJGNjcVqvujpABedsN.loadFromUserDataStore;
					this.ZZgzMQjqyDvJGNjcVqvujpABedsN.loadFromUserDataStore = false;
					this.ZZgzMQjqyDvJGNjcVqvujpABedsN.Apply();
					this.ZZgzMQjqyDvJGNjcVqvujpABedsN.loadFromUserDataStore = loadFromUserDataStore;
				}

				// Token: 0x0600124C RID: 4684 RVA: 0x00010460 File Offset: 0x0000E660
				private Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu NkhIolZrtfUygmkKcqXVlcPUHoraA<\u0001>() where \u0001 : ControllerMap
				{
					return this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(gRvITEHjKMrWaeGYEmAHofbpCtEU.DrVFpTBOVLehQeeOJikFfQUjqEZDc<\u0001>());
				}

				// Token: 0x0600124D RID: 4685 RVA: 0x0005FF28 File Offset: 0x0005E128
				internal VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<JoystickMap> ViyQaJeqNNxJlRiSfxlXBUJceWFw(Joystick A_1, bool A_2)
				{
					if (A_1 == null || this.rnFfambBUNgqcfQyoQGVXGnHKdbeA.ElsACWhefOftDpkPUwnxivhQAmgCA == null)
					{
						return null;
					}
					VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<JoystickMap> vgBeEuhSJyCTDoLCtPBvlHeZIRyMA = new VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<JoystickMap>(A_1.id);
					for (int i = 0; i < this.rnFfambBUNgqcfQyoQGVXGnHKdbeA.ElsACWhefOftDpkPUwnxivhQAmgCA.Length; i++)
					{
						this.zXKBDoeZNcYYESOKJGNibuFQyvTnA(A_1, vgBeEuhSJyCTDoLCtPBvlHeZIRyMA, this.rnFfambBUNgqcfQyoQGVXGnHKdbeA.ElsACWhefOftDpkPUwnxivhQAmgCA[i], A_2);
					}
					if (vgBeEuhSJyCTDoLCtPBvlHeZIRyMA.sSEkNHPvFzDptlNqDocRnDXFEYyY == 0)
					{
						return null;
					}
					return vgBeEuhSJyCTDoLCtPBvlHeZIRyMA;
				}

				// Token: 0x0600124E RID: 4686 RVA: 0x0005FF8C File Offset: 0x0005E18C
				private void zXKBDoeZNcYYESOKJGNibuFQyvTnA(Joystick A_1, VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<JoystickMap> A_2, UkACnUMHYxhtrputCZbaeXOybpyB A_3, bool A_4)
				{
					if (A_1 == null || A_3 == null)
					{
						return;
					}
					if (A_3.jZQdpALLgjCNvDcRkmXqCFEhdhkh < 0 || A_3.KwGLDvUPdGjXcMzYgfJjBnZIuPzt < 0)
					{
						return;
					}
					JoystickMap joystickMap = ReInput.UserData.dCtulAuKluDweDSLBLXTmZcbbpEXA(A_1, A_3.jZQdpALLgjCNvDcRkmXqCFEhdhkh, A_3.KwGLDvUPdGjXcMzYgfJjBnZIuPzt);
					this.XrTRlliMzhKfGEipwrhVgqehkfSw(A_1, joystickMap);
					BoolOption boolOption = BoolOption.Default;
					if (A_4)
					{
						boolOption = (A_3.JSNOHtFJDdbaEBVFzLkIiYOATlKIB ? BoolOption.True : BoolOption.False);
					}
					A_2.wfwrNzIlaolziFcmVeutgrLdVwHs(joystickMap, boolOption);
				}

				// Token: 0x0600124F RID: 4687 RVA: 0x0005FFF0 File Offset: 0x0005E1F0
				internal VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<CustomControllerMap> qsVeTKZjyPunOJuJLmdGtXkPIAMM(CustomController A_1, bool A_2)
				{
					if (A_1 == null || this.rnFfambBUNgqcfQyoQGVXGnHKdbeA.gbiBgdpEMjfwiiLEplXSZOrjAEObA == null)
					{
						return null;
					}
					VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<CustomControllerMap> vgBeEuhSJyCTDoLCtPBvlHeZIRyMA = new VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<CustomControllerMap>(A_1.id);
					for (int i = 0; i < this.rnFfambBUNgqcfQyoQGVXGnHKdbeA.gbiBgdpEMjfwiiLEplXSZOrjAEObA.Length; i++)
					{
						this.EMuQcBsoYnbeJBPprugRyVUYlTZj(A_1, vgBeEuhSJyCTDoLCtPBvlHeZIRyMA, this.rnFfambBUNgqcfQyoQGVXGnHKdbeA.gbiBgdpEMjfwiiLEplXSZOrjAEObA[i], A_2);
					}
					if (vgBeEuhSJyCTDoLCtPBvlHeZIRyMA.sSEkNHPvFzDptlNqDocRnDXFEYyY == 0)
					{
						return null;
					}
					return vgBeEuhSJyCTDoLCtPBvlHeZIRyMA;
				}

				// Token: 0x06001250 RID: 4688 RVA: 0x00060054 File Offset: 0x0005E254
				private void EMuQcBsoYnbeJBPprugRyVUYlTZj(CustomController A_1, VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<CustomControllerMap> A_2, UkACnUMHYxhtrputCZbaeXOybpyB A_3, bool A_4)
				{
					if (A_1 == null || A_3 == null)
					{
						return;
					}
					if (A_3.jZQdpALLgjCNvDcRkmXqCFEhdhkh < 0 || A_3.KwGLDvUPdGjXcMzYgfJjBnZIuPzt < 0)
					{
						return;
					}
					CustomControllerMap customControllerMap = ReInput.UserData.GIsOtUvWYIJylyqaDKWRZDnDCgTL(A_3.jZQdpALLgjCNvDcRkmXqCFEhdhkh, A_1.sourceControllerId, A_3.KwGLDvUPdGjXcMzYgfJjBnZIuPzt);
					this.XrTRlliMzhKfGEipwrhVgqehkfSw(A_1, customControllerMap);
					BoolOption boolOption = BoolOption.Default;
					if (A_4)
					{
						boolOption = (A_3.JSNOHtFJDdbaEBVFzLkIiYOATlKIB ? BoolOption.True : BoolOption.False);
					}
					A_2.wfwrNzIlaolziFcmVeutgrLdVwHs(customControllerMap, boolOption);
				}

				// Token: 0x06001251 RID: 4689 RVA: 0x00010477 File Offset: 0x0000E677
				internal void XrTRlliMzhKfGEipwrhVgqehkfSw(Controller A_1, ControllerMap A_2)
				{
					if (A_1 == null || A_2 == null)
					{
						return;
					}
					A_2.playerId = this.lawNLFQVYtOrvswGWUkKybfZHlLj.slhAWVVynuDdrqbdGKDoRVmsCDYo;
					A_1.VswFFcfRUHqPtFHydytpQrxVsYK(A_2);
				}

				// Token: 0x06001252 RID: 4690 RVA: 0x000600BC File Offset: 0x0005E2BC
				private IList<\u0001> jRQCFWqfCbjUYPRZOFryGNABtLcP<\u0001>(int A_1) where \u0001 : ControllerMap
				{
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.NkhIolZrtfUygmkKcqXVlcPUHoraA<\u0001>();
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_1);
					if (num < 0)
					{
						return EmptyObjects<\u0001>.EmptyReadOnlyIListT;
					}
					return rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).AxzIHFaeuZajYboPHuvsfCYAXoQwA.BsVxMfPoUxUhalKaqBdEPKClWbPp<\u0001>();
				}

				// Token: 0x06001253 RID: 4691 RVA: 0x000600F4 File Offset: 0x0005E2F4
				private IList<\u0001> ZgJKfIucUaaQmzYMDIvwCPWTioMF<\u0001>(Controller A_1) where \u0001 : ControllerMap
				{
					Player.ControllerHelper.aDTWAvwJDeCLlGzuGUJORYARFABdA aDTWAvwJDeCLlGzuGUJORYARFABdA = this.NkhIolZrtfUygmkKcqXVlcPUHoraA<\u0001>().TxWLRNtHlXEVLNrlphQggYNzVEXPA(A_1);
					if (aDTWAvwJDeCLlGzuGUJORYARFABdA == null)
					{
						return null;
					}
					return aDTWAvwJDeCLlGzuGUJORYARFABdA.AxzIHFaeuZajYboPHuvsfCYAXoQwA.BsVxMfPoUxUhalKaqBdEPKClWbPp<\u0001>();
				}

				// Token: 0x06001254 RID: 4692 RVA: 0x00060120 File Offset: 0x0005E320
				private IList<ControllerMap> DVbLRscGynDbpLPHjcNvTnaxkMjX(ControllerType A_1, int A_2)
				{
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_2);
					if (num < 0)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).AxzIHFaeuZajYboPHuvsfCYAXoQwA.IRobIJiETvaITbHPpoekuVTtDgxHA;
				}

				// Token: 0x06001255 RID: 4693 RVA: 0x00010498 File Offset: 0x0000E698
				private IList<ControllerMap> ZgJKfIucUaaQmzYMDIvwCPWTioMF(Controller A_1)
				{
					return this.DVbLRscGynDbpLPHjcNvTnaxkMjX(A_1.type, A_1.id);
				}

				// Token: 0x06001256 RID: 4694 RVA: 0x000104AC File Offset: 0x0000E6AC
				private void QcCLebyaVyCdOlalrREHbnAOJOi(ControllerType A_1, int A_2, int A_3, int A_4)
				{
					this.IzGlQAFcBgrXnbfRzgYbxQZyqSuP(A_1, A_2, A_3, A_4, BoolOption.Default);
				}

				// Token: 0x06001257 RID: 4695 RVA: 0x000104BA File Offset: 0x0000E6BA
				private void pleSULtygVIvGxsqYclRLYLkCYjH(Controller A_1, int A_2, int A_3)
				{
					this.DAJQlqMybgqebIFiPDkScbSkdJqFb(A_1, A_2, A_3, BoolOption.Default);
				}

				// Token: 0x06001258 RID: 4696 RVA: 0x000104C6 File Offset: 0x0000E6C6
				private void jukcARGlZUgkLDrbNKLVQVSKSXBS(ControllerType A_1, int A_2, string A_3, string A_4)
				{
					this.BpLoiusdNsFMXiINNWcUohzesxTsA(A_1, A_2, A_3, A_4, BoolOption.Default);
				}

				// Token: 0x06001259 RID: 4697 RVA: 0x000104D4 File Offset: 0x0000E6D4
				private void DzvAkEzJkokxKrzSbRONNaQfQIEQ(Controller A_1, string A_2, string A_3)
				{
					this.ZZFRsxbyiypbQMtqvDvTdGVuSIfl(A_1, A_2, A_3, BoolOption.Default);
				}

				// Token: 0x0600125A RID: 4698 RVA: 0x00060164 File Offset: 0x0005E364
				private void IzGlQAFcBgrXnbfRzgYbxQZyqSuP(ControllerType A_1, int A_2, int A_3, int A_4, BoolOption A_5)
				{
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_2);
					if (num < 0)
					{
						return;
					}
					Controller controller = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).PBJHfnhJKAlWfSVgUYDoQBOBahDP;
					ControllerMap controllerMap = ReInput.UserData.orpcuTByDKjWdCWGmwZhSNbviFRtA(controller, A_3, A_4);
					this.IneFPGeuYcGLvxXmrConOANRhreo(controller.type, controller.id, controllerMap, A_5);
				}

				// Token: 0x0600125B RID: 4699 RVA: 0x000104E0 File Offset: 0x0000E6E0
				private void DAJQlqMybgqebIFiPDkScbSkdJqFb(Controller A_1, int A_2, int A_3, BoolOption A_4)
				{
					this.IzGlQAFcBgrXnbfRzgYbxQZyqSuP(A_1.type, A_1.id, A_2, A_3, A_4);
				}

				// Token: 0x0600125C RID: 4700 RVA: 0x000601C4 File Offset: 0x0005E3C4
				private void BpLoiusdNsFMXiINNWcUohzesxTsA(ControllerType A_1, int A_2, string A_3, string A_4, BoolOption A_5)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(A_3);
					int layoutId = ReInput.mapping.GetLayoutId(A_1, A_4);
					if (mapCategoryId < 0 || layoutId < 0)
					{
						return;
					}
					this.IzGlQAFcBgrXnbfRzgYbxQZyqSuP(A_1, A_2, mapCategoryId, layoutId, A_5);
				}

				// Token: 0x0600125D RID: 4701 RVA: 0x000104F8 File Offset: 0x0000E6F8
				private void ZZFRsxbyiypbQMtqvDvTdGVuSIfl(Controller A_1, string A_2, string A_3, BoolOption A_4)
				{
					this.BpLoiusdNsFMXiINNWcUohzesxTsA(A_1.type, A_1.id, A_2, A_3, A_4);
				}

				// Token: 0x0600125E RID: 4702 RVA: 0x00060200 File Offset: 0x0005E400
				private void PjeHKsUTGAFLwoRrpDvQkEwhGycD(Controller A_1, ControllerMap A_2, BoolOption A_3)
				{
					if (A_1 == null || A_2 == null)
					{
						return;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1.type);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_1.id);
					if (num < 0)
					{
						return;
					}
					this.XrTRlliMzhKfGEipwrhVgqehkfSw(A_1, A_2);
					rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).AxzIHFaeuZajYboPHuvsfCYAXoQwA.qXeMOtpwDiJrknOlkFHPftawIuXrA(A_2, A_3);
					this.PcMgoVlXoOYNqGgBwoSEwICaMdvB.Apply();
				}

				// Token: 0x0600125F RID: 4703 RVA: 0x00060264 File Offset: 0x0005E464
				private void IneFPGeuYcGLvxXmrConOANRhreo(ControllerType A_1, int A_2, ControllerMap A_3, BoolOption A_4)
				{
					Controller controller = ReInput.controllers.GetController(A_1, A_2);
					if (controller == null)
					{
						return;
					}
					this.PjeHKsUTGAFLwoRrpDvQkEwhGycD(controller, A_3, A_4);
				}

				// Token: 0x06001260 RID: 4704 RVA: 0x0006028C File Offset: 0x0005E48C
				private bool CfQrvqYpvwaQvRIvzfUisvlAoPIN(ControllerType A_1, int A_2, string A_3)
				{
					if (A_3 == null || A_3 == string.Empty)
					{
						return false;
					}
					if (this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1).jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_2) < 0)
					{
						return false;
					}
					ControllerMap controllerMap = ControllerMap.nPcWPeGGLvrSGPqQhGYxyqQuLzOb(A_1);
					if (!controllerMap.KvtgDkAlAaYjjVPiONOkrojxitzeb(A_3))
					{
						return false;
					}
					this.IneFPGeuYcGLvxXmrConOANRhreo(A_1, A_2, controllerMap, BoolOption.Default);
					return true;
				}

				// Token: 0x06001261 RID: 4705 RVA: 0x000602E4 File Offset: 0x0005E4E4
				private int scZHIMHheNEQLEmSAQzSEmTjViBIe(ControllerType A_1, int A_2, List<string> A_3)
				{
					if (A_3 == null || A_3.Count == 0)
					{
						return 0;
					}
					if (this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1).jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_2) < 0)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < A_3.Count; i++)
					{
						if (this.CfQrvqYpvwaQvRIvzfUisvlAoPIN(A_1, A_2, A_3[i]))
						{
							num++;
						}
					}
					return num;
				}

				// Token: 0x06001262 RID: 4706 RVA: 0x00060344 File Offset: 0x0005E544
				private bool XZCQcxPGjfcrIXedYelGJJBlZajL(ControllerType A_1, int A_2, string A_3)
				{
					if (A_3 == null || A_3 == string.Empty)
					{
						return false;
					}
					if (this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1).jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_2) < 0)
					{
						return false;
					}
					ControllerMap controllerMap = ControllerMap.nPcWPeGGLvrSGPqQhGYxyqQuLzOb(A_1);
					if (!controllerMap.jZwEmtegaFvFtfWXuyTJukYNVxec(A_3))
					{
						return false;
					}
					this.IneFPGeuYcGLvxXmrConOANRhreo(A_1, A_2, controllerMap, BoolOption.Default);
					return true;
				}

				// Token: 0x06001263 RID: 4707 RVA: 0x0006039C File Offset: 0x0005E59C
				private int kAFbjoSgDpyIiWuOjEibrQOTMYzP(ControllerType A_1, int A_2, List<string> A_3)
				{
					if (A_3 == null || A_3.Count == 0)
					{
						return 0;
					}
					if (this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1).jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_2) < 0)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < A_3.Count; i++)
					{
						if (this.XZCQcxPGjfcrIXedYelGJJBlZajL(A_1, A_2, A_3[i]))
						{
							num++;
						}
					}
					return num;
				}

				// Token: 0x06001264 RID: 4708 RVA: 0x000603FC File Offset: 0x0005E5FC
				private void BdUHDlgWIEzncFvAvwezVQUdysmj(ControllerType A_1, int A_2, int A_3, int A_4)
				{
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_2);
					if (num < 0)
					{
						return;
					}
					Controller controller = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).PBJHfnhJKAlWfSVgUYDoQBOBahDP;
					ControllerMap controllerMap = ControllerMap.IeRlDehStzAoxGIHlpokBYqZCmNA(controller, A_3, A_4);
					this.IneFPGeuYcGLvxXmrConOANRhreo(controller.type, controller.id, controllerMap, BoolOption.Default);
				}

				// Token: 0x06001265 RID: 4709 RVA: 0x00010510 File Offset: 0x0000E710
				private void nfEbUPUtruByOGmoSUuZFSfSgtdvA(Controller A_1, int A_2, int A_3)
				{
					this.BdUHDlgWIEzncFvAvwezVQUdysmj(A_1.type, A_1.id, A_2, A_3);
				}

				// Token: 0x06001266 RID: 4710 RVA: 0x00060454 File Offset: 0x0005E654
				private void PHotXYsQkfduRdeDiwXOiNSpnjun(ControllerType A_1, int A_2, string A_3, string A_4)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(A_3);
					int layoutId = ReInput.mapping.GetLayoutId(A_1, A_4);
					if (mapCategoryId < 0 || layoutId < 0)
					{
						return;
					}
					this.BdUHDlgWIEzncFvAvwezVQUdysmj(A_1, A_2, mapCategoryId, layoutId);
				}

				// Token: 0x06001267 RID: 4711 RVA: 0x00010526 File Offset: 0x0000E726
				private void LWRyUoWFzpqLsGrfKIzBHhNMFZR(Controller A_1, string A_2, string A_3)
				{
					this.PHotXYsQkfduRdeDiwXOiNSpnjun(A_1.type, A_1.id, A_2, A_3);
				}

				// Token: 0x06001268 RID: 4712 RVA: 0x00060490 File Offset: 0x0005E690
				private void mMMlOfoddLXPBbpvStdcnojnGfzgA(ControllerType A_1, int A_2, int A_3)
				{
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_2);
					if (num < 0)
					{
						return;
					}
					rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).AxzIHFaeuZajYboPHuvsfCYAXoQwA.TxVAuGuMOOsplNcpocJRccQXyxL(A_3);
				}

				// Token: 0x06001269 RID: 4713 RVA: 0x0001053C File Offset: 0x0000E73C
				private void IfLXiBaIiAiBfBlYQhtLIlHpcModb(Controller A_1, int A_2)
				{
					this.mMMlOfoddLXPBbpvStdcnojnGfzgA(A_1.type, A_1.id, A_2);
				}

				// Token: 0x0600126A RID: 4714 RVA: 0x000604D0 File Offset: 0x0005E6D0
				private void PVudNHEkMFvyfhgpGqJAQokmJIfy(ControllerType A_1, int A_2, ControllerMap A_3)
				{
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_2);
					if (num < 0)
					{
						return;
					}
					rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).AxzIHFaeuZajYboPHuvsfCYAXoQwA.DUMyVvamhCWeSqxGBkbpGxxcPtLH(A_3);
				}

				// Token: 0x0600126B RID: 4715 RVA: 0x00010551 File Offset: 0x0000E751
				private void pyAgCYjSPiVFoOrsqGvOVLNzgVrEA(Controller A_1, ControllerMap A_2)
				{
					this.mMMlOfoddLXPBbpvStdcnojnGfzgA(A_1.type, A_1.id, A_2.id);
				}

				// Token: 0x0600126C RID: 4716 RVA: 0x00060510 File Offset: 0x0005E710
				private void yjchwXMNnFhIOHMvTpdhomrQABAU(ControllerType A_1, int A_2, int A_3, int A_4)
				{
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_2);
					if (num < 0)
					{
						return;
					}
					rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).AxzIHFaeuZajYboPHuvsfCYAXoQwA.KfnMFXdMygcpedkRzNowoFWTTTdqA(A_3, A_4);
				}

				// Token: 0x0600126D RID: 4717 RVA: 0x0001056B File Offset: 0x0000E76B
				private void qmACIbBYuxrAxtDdlGKpDAPJdMqQA(Controller A_1, int A_2, int A_3)
				{
					this.yjchwXMNnFhIOHMvTpdhomrQABAU(A_1.type, A_1.id, A_2, A_3);
				}

				// Token: 0x0600126E RID: 4718 RVA: 0x00060550 File Offset: 0x0005E750
				private void UfVgamseQifHZAAUhwmfmuIsMHet(ControllerType A_1, int A_2, string A_3, string A_4)
				{
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_2);
					if (num < 0)
					{
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(A_3);
					int layoutId = ReInput.mapping.GetLayoutId(A_1, A_4);
					if (mapCategoryId < 0 || layoutId < 0)
					{
						return;
					}
					rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).AxzIHFaeuZajYboPHuvsfCYAXoQwA.KfnMFXdMygcpedkRzNowoFWTTTdqA(mapCategoryId, layoutId);
				}

				// Token: 0x0600126F RID: 4719 RVA: 0x00010581 File Offset: 0x0000E781
				private void wIirOiWXlOoMzxcRrQMCbdyQNmWh(Controller A_1, string A_2, string A_3)
				{
					this.UfVgamseQifHZAAUhwmfmuIsMHet(A_1.type, A_1.id, A_2, A_3);
				}

				// Token: 0x06001270 RID: 4720 RVA: 0x000605B4 File Offset: 0x0005E7B4
				private ControllerMap WeizxxjglrgxQMkfZWhCZxAGJWxE(ControllerType A_1, int A_2, int A_3)
				{
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_2);
					if (num < 0)
					{
						return null;
					}
					return rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).AxzIHFaeuZajYboPHuvsfCYAXoQwA.kokTzCgXytETCesILHvgRCorjGER(A_3);
				}

				// Token: 0x06001271 RID: 4721 RVA: 0x00010597 File Offset: 0x0000E797
				private ControllerMap fcoHVshMrpWtWNmRrpXrlTyGQOZW(Controller A_1, int A_2)
				{
					return this.WeizxxjglrgxQMkfZWhCZxAGJWxE(A_1.type, A_1.id, A_2);
				}

				// Token: 0x06001272 RID: 4722 RVA: 0x000605F4 File Offset: 0x0005E7F4
				private ControllerMap HyFqJaNGmHooWSOvghAymJyVDEKi(ControllerType A_1, int A_2, int A_3, int A_4)
				{
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_2);
					if (num < 0)
					{
						return null;
					}
					return rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).AxzIHFaeuZajYboPHuvsfCYAXoQwA.ceJejODDhJgGMvHNmPhYURUJVDNA(A_3, A_4);
				}

				// Token: 0x06001273 RID: 4723 RVA: 0x000105AC File Offset: 0x0000E7AC
				private ControllerMap IIcxDmvcBoLjNjHbjohbUJnualmN(Controller A_1, int A_2, int A_3)
				{
					return this.HyFqJaNGmHooWSOvghAymJyVDEKi(A_1.type, A_1.id, A_2, A_3);
				}

				// Token: 0x06001274 RID: 4724 RVA: 0x00060638 File Offset: 0x0005E838
				private ControllerMap uBpxEZjpcxaFjdiWKpIeyzEvvEnl(ControllerType A_1, int A_2, string A_3, string A_4)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(A_3);
					int layoutId = ReInput.mapping.GetLayoutId(A_1, A_4);
					if (mapCategoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return this.HyFqJaNGmHooWSOvghAymJyVDEKi(A_1, A_2, mapCategoryId, layoutId);
				}

				// Token: 0x06001275 RID: 4725 RVA: 0x000105C2 File Offset: 0x0000E7C2
				private ControllerMap REouVOKJQvGjGbljCSePVvArPWIvA(Controller A_1, string A_2, string A_3)
				{
					return this.uBpxEZjpcxaFjdiWKpIeyzEvvEnl(A_1.type, A_1.id, A_2, A_3);
				}

				// Token: 0x06001276 RID: 4726 RVA: 0x00060674 File Offset: 0x0005E874
				private ControllerMap SXDcCUKyTmIGYkLcDifNvgDxclJP(ControllerType A_1, int A_2, int A_3)
				{
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_2);
					if (num < 0)
					{
						return null;
					}
					return rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).AxzIHFaeuZajYboPHuvsfCYAXoQwA.tvKBUjjuYYIjlpYKyTHYxAPQkwdQ(A_3);
				}

				// Token: 0x06001277 RID: 4727 RVA: 0x000105D8 File Offset: 0x0000E7D8
				private ControllerMap ZexBPDdbRWcgnSyeUwXEpWodBiBJ(Controller A_1, int A_2)
				{
					return this.SXDcCUKyTmIGYkLcDifNvgDxclJP(A_1.type, A_1.id, A_2);
				}

				// Token: 0x06001278 RID: 4728 RVA: 0x000606B4 File Offset: 0x0005E8B4
				private ControllerMap cuXvnKUHrAfaPWhoDtJBHXerHfud(ControllerType A_1, int A_2, string A_3)
				{
					int mapCategoryId = ReInput.UserData.GetMapCategoryId(A_3);
					if (mapCategoryId < 0)
					{
						return null;
					}
					return this.SXDcCUKyTmIGYkLcDifNvgDxclJP(A_1, A_2, mapCategoryId);
				}

				// Token: 0x06001279 RID: 4729 RVA: 0x000105ED File Offset: 0x0000E7ED
				private ControllerMap lVdKZhwHtGrjMfJdcEkDjjdtEhXgA(Controller A_1, string A_2)
				{
					return this.cuXvnKUHrAfaPWhoDtJBHXerHfud(A_1.type, A_1.id, A_2);
				}

				// Token: 0x0600127A RID: 4730 RVA: 0x000606DC File Offset: 0x0005E8DC
				private ControllerMap[] ChidZxknPlOhuQNXskRDqLpLfZWt(ControllerType A_1)
				{
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					int num = 0;
					for (int i = 0; i < rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						num += rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA.sSEkNHPvFzDptlNqDocRnDXFEYyY;
					}
					ControllerMap[] array = new ControllerMap[num];
					num = 0;
					for (int j = 0; j < rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL; j++)
					{
						dBWjOjXnFJmUROzCVhQpynliVgPI dBWjOjXnFJmUROzCVhQpynliVgPI = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(j).AxzIHFaeuZajYboPHuvsfCYAXoQwA;
						for (int k = 0; k < dBWjOjXnFJmUROzCVhQpynliVgPI.sSEkNHPvFzDptlNqDocRnDXFEYyY; k++)
						{
							array[num] = dBWjOjXnFJmUROzCVhQpynliVgPI.kpSXGnRVLDEHUvJSffrGHSOpEAHGb(k);
							num++;
						}
					}
					return array;
				}

				// Token: 0x0600127B RID: 4731 RVA: 0x00060778 File Offset: 0x0005E978
				private ControllerMapSaveData[] YKjYPpmcePnnCyVEuOOTCbSTILHD(ControllerType A_1, int A_2, bool A_3)
				{
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_2);
					if (num < 0)
					{
						return null;
					}
					List<ControllerMapSaveData> list = new List<ControllerMapSaveData>();
					dBWjOjXnFJmUROzCVhQpynliVgPI dBWjOjXnFJmUROzCVhQpynliVgPI = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).AxzIHFaeuZajYboPHuvsfCYAXoQwA;
					int i = 0;
					while (i < dBWjOjXnFJmUROzCVhQpynliVgPI.sSEkNHPvFzDptlNqDocRnDXFEYyY)
					{
						ControllerMap controllerMap = dBWjOjXnFJmUROzCVhQpynliVgPI.kpSXGnRVLDEHUvJSffrGHSOpEAHGb(i);
						if (!A_3)
						{
							goto IL_65;
						}
						InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
						if (mapCategory == null || mapCategory.userAssignable)
						{
							goto IL_65;
						}
						IL_82:
						i++;
						continue;
						IL_65:
						Controller controller = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).PBJHfnhJKAlWfSVgUYDoQBOBahDP;
						list.Add(ControllerMapSaveData.ArIhRHdbhRfQWDsIiNGUGfYhCwKSb(controller, controllerMap));
						goto IL_82;
					}
					return list.ToArray();
				}

				// Token: 0x0600127C RID: 4732 RVA: 0x00060820 File Offset: 0x0005EA20
				private \u0001[] yVlDpxrtoeuvRvInIgNzSLeiokvk<\u0001>(int A_1, bool A_2) where \u0001 : ControllerMapSaveData
				{
					ControllerType controllerType = gRvITEHjKMrWaeGYEmAHofbpCtEU.pYJAxlSeDJMiKWGPKnMmTlnaovEM<\u0001>();
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controllerType);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_1);
					if (num < 0)
					{
						return null;
					}
					List<\u0001> list = new List<\u0001>();
					dBWjOjXnFJmUROzCVhQpynliVgPI dBWjOjXnFJmUROzCVhQpynliVgPI = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).AxzIHFaeuZajYboPHuvsfCYAXoQwA;
					int i = 0;
					while (i < dBWjOjXnFJmUROzCVhQpynliVgPI.sSEkNHPvFzDptlNqDocRnDXFEYyY)
					{
						ControllerMap controllerMap = dBWjOjXnFJmUROzCVhQpynliVgPI.kpSXGnRVLDEHUvJSffrGHSOpEAHGb(i);
						if (!A_2)
						{
							goto IL_6D;
						}
						InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
						if (mapCategory == null || mapCategory.userAssignable)
						{
							goto IL_6D;
						}
						IL_8A:
						i++;
						continue;
						IL_6D:
						Controller controller = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).PBJHfnhJKAlWfSVgUYDoQBOBahDP;
						list.Add(ControllerMapSaveData.ArIhRHdbhRfQWDsIiNGUGfYhCwKSb<\u0001>(controller, controllerMap));
						goto IL_8A;
					}
					return list.ToArray();
				}

				// Token: 0x0600127D RID: 4733 RVA: 0x000608D0 File Offset: 0x0005EAD0
				private ControllerMapSaveData[] ZKDwtRsHZjxAxfUymmpMBNcDxOAC(ControllerType A_1, bool A_2)
				{
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					List<ControllerMapSaveData> list = new List<ControllerMapSaveData>();
					for (int i = 0; i < rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						dBWjOjXnFJmUROzCVhQpynliVgPI dBWjOjXnFJmUROzCVhQpynliVgPI = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA;
						int j = 0;
						while (j < dBWjOjXnFJmUROzCVhQpynliVgPI.sSEkNHPvFzDptlNqDocRnDXFEYyY)
						{
							ControllerMap controllerMap = dBWjOjXnFJmUROzCVhQpynliVgPI.kpSXGnRVLDEHUvJSffrGHSOpEAHGb(j);
							if (!A_2)
							{
								goto IL_5B;
							}
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
							if (mapCategory == null || mapCategory.userAssignable)
							{
								goto IL_5B;
							}
							IL_78:
							j++;
							continue;
							IL_5B:
							Controller controller = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).PBJHfnhJKAlWfSVgUYDoQBOBahDP;
							list.Add(ControllerMapSaveData.ArIhRHdbhRfQWDsIiNGUGfYhCwKSb(controller, controllerMap));
							goto IL_78;
						}
					}
					return list.ToArray();
				}

				// Token: 0x0600127E RID: 4734 RVA: 0x00060978 File Offset: 0x0005EB78
				private \u0001[] nfAiTFHRzKYWyqLSpvFKbaSVhXsgb<\u0001>(bool A_1) where \u0001 : ControllerMapSaveData
				{
					ControllerType controllerType = gRvITEHjKMrWaeGYEmAHofbpCtEU.pYJAxlSeDJMiKWGPKnMmTlnaovEM<\u0001>();
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controllerType);
					List<\u0001> list = new List<\u0001>();
					for (int i = 0; i < rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						dBWjOjXnFJmUROzCVhQpynliVgPI dBWjOjXnFJmUROzCVhQpynliVgPI = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA;
						int j = 0;
						while (j < dBWjOjXnFJmUROzCVhQpynliVgPI.sSEkNHPvFzDptlNqDocRnDXFEYyY)
						{
							ControllerMap controllerMap = dBWjOjXnFJmUROzCVhQpynliVgPI.kpSXGnRVLDEHUvJSffrGHSOpEAHGb(j);
							if (!A_1)
							{
								goto IL_63;
							}
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
							if (mapCategory == null || mapCategory.userAssignable)
							{
								goto IL_63;
							}
							IL_80:
							j++;
							continue;
							IL_63:
							Controller controller = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).PBJHfnhJKAlWfSVgUYDoQBOBahDP;
							list.Add(ControllerMapSaveData.ArIhRHdbhRfQWDsIiNGUGfYhCwKSb<\u0001>(controller, controllerMap));
							goto IL_80;
						}
					}
					return list.ToArray();
				}

				// Token: 0x0600127F RID: 4735 RVA: 0x00060A2C File Offset: 0x0005EC2C
				private int eypXuixlLVqqESCNIckoKUilAmFtA(ControllerType A_1, int A_2, int A_3, List<ControllerMap> A_4)
				{
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_2);
					if (num < 0)
					{
						return 0;
					}
					return rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).AxzIHFaeuZajYboPHuvsfCYAXoQwA.rDZPMaRoqmjfZWLmbTGHxMqkvbQr(A_3, A_4, false);
				}

				// Token: 0x06001280 RID: 4736 RVA: 0x00010602 File Offset: 0x0000E802
				private int nCKFaAyiWFTHGtnlfegxvWLJttud(Controller A_1, int A_2, List<ControllerMap> A_3)
				{
					return this.eypXuixlLVqqESCNIckoKUilAmFtA(A_1.type, A_1.id, A_2, A_3);
				}

				// Token: 0x06001281 RID: 4737 RVA: 0x00060A70 File Offset: 0x0005EC70
				private int jIsVRijoAVaLNdmPxhfwsrruQDeg(ControllerType A_1, int A_2, string A_3, List<ControllerMap> A_4)
				{
					int mapCategoryId = ReInput.UserData.GetMapCategoryId(A_3);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return this.eypXuixlLVqqESCNIckoKUilAmFtA(A_1, A_2, mapCategoryId, A_4);
				}

				// Token: 0x06001282 RID: 4738 RVA: 0x00010618 File Offset: 0x0000E818
				private int WEnAcbiTZwVaYhIIBUqxHaetVZXmA(Controller A_1, string A_2, List<ControllerMap> A_3)
				{
					return this.jIsVRijoAVaLNdmPxhfwsrruQDeg(A_1.type, A_1.id, A_2, A_3);
				}

				// Token: 0x06001283 RID: 4739 RVA: 0x0001062E File Offset: 0x0000E82E
				private IEnumerable<ControllerMap> ztWVZkYzMwXtOGZksOJWCmDkfabd(ControllerType A_1, int A_2, int A_3)
				{
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_2);
					if (num < 0)
					{
						yield break;
					}
					IList<ControllerMap> list = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).AxzIHFaeuZajYboPHuvsfCYAXoQwA.IRobIJiETvaITbHPpoekuVTtDgxHA;
					int num2;
					for (int i = 0; i < list.Count; i = num2 + 1)
					{
						if (list[i].categoryId == A_3)
						{
							yield return list[i];
						}
						num2 = i;
					}
					yield break;
				}

				// Token: 0x06001284 RID: 4740 RVA: 0x00010653 File Offset: 0x0000E853
				private IEnumerable<\u0001> OcYFuTbGdkIdPZNUwfvgVqWLiTxzA<\u0001>(int A_1, int A_2) where \u0001 : ControllerMap
				{
					ControllerType controllerType = gRvITEHjKMrWaeGYEmAHofbpCtEU.DrVFpTBOVLehQeeOJikFfQUjqEZDc<\u0001>();
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controllerType);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_1);
					if (num < 0)
					{
						yield break;
					}
					IList<\u0001> list = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).AxzIHFaeuZajYboPHuvsfCYAXoQwA.BsVxMfPoUxUhalKaqBdEPKClWbPp<\u0001>();
					int num2;
					for (int i = 0; i < list.Count; i = num2 + 1)
					{
						if (list[i].categoryId == A_2)
						{
							yield return list[i];
						}
						num2 = i;
					}
					yield break;
				}

				// Token: 0x06001285 RID: 4741 RVA: 0x00060A9C File Offset: 0x0005EC9C
				private ActionElementMap MHMKDCwcqmAHWbpAApSgEakknRuUb(ControllerType A_1, int A_2, bool A_3)
				{
					if (A_2 < 0)
					{
						return null;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					for (int i = 0; i < rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						IList<ControllerMap> list = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA.IRobIJiETvaITbHPpoekuVTtDgxHA;
						for (int j = 0; j < list.Count; j++)
						{
							if ((!A_3 || list[j].enabled) && list[j].ContainsAction(A_2))
							{
								ActionElementMap firstButtonMapWithAction = list[j].GetFirstButtonMapWithAction(A_2, A_3);
								if (firstButtonMapWithAction != null)
								{
									return firstButtonMapWithAction;
								}
							}
						}
					}
					return null;
				}

				// Token: 0x06001286 RID: 4742 RVA: 0x00060B30 File Offset: 0x0005ED30
				private ActionElementMap rkCdugHwwBFOCsglSHrsOeFYQTlDb(ControllerType A_1, string A_2, bool A_3)
				{
					int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(A_2, false);
					return this.MHMKDCwcqmAHWbpAApSgEakknRuUb(A_1, num, A_3);
				}

				// Token: 0x06001287 RID: 4743 RVA: 0x00010671 File Offset: 0x0000E871
				private IEnumerable<ActionElementMap> ZvfTdUntJznnseKCgdyrfoARmmSd(ControllerType A_1, int A_2, bool A_3)
				{
					if (A_2 < 0)
					{
						yield break;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					int num;
					for (int i = 0; i < rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL; i = num + 1)
					{
						IList<ControllerMap> list = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA.IRobIJiETvaITbHPpoekuVTtDgxHA;
						for (int j = 0; j < list.Count; j = num + 1)
						{
							if ((!A_3 || list[j].enabled) && list[j].ContainsAction(A_2))
							{
								foreach (ActionElementMap actionElementMap in list[j].ButtonMapsWithAction(A_2, A_3))
								{
									yield return actionElementMap;
								}
								IEnumerator<ActionElementMap> enumerator = null;
							}
							num = j;
						}
						list = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x06001288 RID: 4744 RVA: 0x00060B54 File Offset: 0x0005ED54
				private IEnumerable<ActionElementMap> RJICvQByBQfGrCsQNUFBWilHGmdHb(ControllerType A_1, string A_2, bool A_3)
				{
					int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(A_2, false);
					return this.ZvfTdUntJznnseKCgdyrfoARmmSd(A_1, num, A_3);
				}

				// Token: 0x06001289 RID: 4745 RVA: 0x00060B78 File Offset: 0x0005ED78
				private ActionElementMap aeyQjNaHnCkuehEfAjfkwqSanPP(ControllerType A_1, int A_2, bool A_3)
				{
					if (A_2 < 0)
					{
						return null;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					for (int i = 0; i < rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						IList<ControllerMap> list = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA.IRobIJiETvaITbHPpoekuVTtDgxHA;
						for (int j = 0; j < list.Count; j++)
						{
							if (!(list[j] is ControllerMapWithAxes))
							{
								return null;
							}
							if ((!A_3 || list[j].enabled) && list[j].ContainsAction(A_2))
							{
								ActionElementMap firstAxisMapWithAction = (list[j] as ControllerMapWithAxes).GetFirstAxisMapWithAction(A_2, A_3);
								if (firstAxisMapWithAction != null)
								{
									return firstAxisMapWithAction;
								}
							}
						}
					}
					return null;
				}

				// Token: 0x0600128A RID: 4746 RVA: 0x00060C20 File Offset: 0x0005EE20
				private ActionElementMap HIgYOgXZwcsHRSdoRRalmTnZzYnb(ControllerType A_1, string A_2, bool A_3)
				{
					int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(A_2, false);
					return this.aeyQjNaHnCkuehEfAjfkwqSanPP(A_1, num, A_3);
				}

				// Token: 0x0600128B RID: 4747 RVA: 0x00010696 File Offset: 0x0000E896
				private IEnumerable<ActionElementMap> DCYoIxArJDAiVHkFlQdEFJbfLPmU(ControllerType A_1, int A_2, bool A_3)
				{
					if (A_2 < 0)
					{
						yield break;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					int num;
					for (int i = 0; i < rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL; i = num + 1)
					{
						IList<ControllerMap> list = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA.IRobIJiETvaITbHPpoekuVTtDgxHA;
						for (int j = 0; j < list.Count; j = num + 1)
						{
							if (!(list[j] is ControllerMapWithAxes))
							{
								yield break;
							}
							if ((!A_3 || list[j].enabled) && list[j].ContainsAction(A_2))
							{
								foreach (ActionElementMap actionElementMap in (list[j] as ControllerMapWithAxes).AxisMapsWithAction(A_2, A_3))
								{
									yield return actionElementMap;
								}
								IEnumerator<ActionElementMap> enumerator = null;
							}
							num = j;
						}
						list = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x0600128C RID: 4748 RVA: 0x00060C44 File Offset: 0x0005EE44
				private IEnumerable<ActionElementMap> NFwLOJSAneqZFzvVkfQsyECqfgkh(ControllerType A_1, string A_2, bool A_3)
				{
					int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(A_2, false);
					return this.DCYoIxArJDAiVHkFlQdEFJbfLPmU(A_1, num, A_3);
				}

				// Token: 0x0600128D RID: 4749 RVA: 0x00060C68 File Offset: 0x0005EE68
				private ActionElementMap MWOUhqMtHMofZaqibnLBktHwSugb(ControllerType A_1, int A_2, bool A_3)
				{
					if (A_2 < 0)
					{
						return null;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					for (int i = 0; i < rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						IList<ControllerMap> list = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA.IRobIJiETvaITbHPpoekuVTtDgxHA;
						for (int j = 0; j < list.Count; j++)
						{
							if ((!A_3 || list[j].enabled) && list[j].ContainsAction(A_2))
							{
								ActionElementMap firstElementMapWithAction = list[j].GetFirstElementMapWithAction(A_2, A_3);
								if (firstElementMapWithAction != null)
								{
									return firstElementMapWithAction;
								}
							}
						}
					}
					return null;
				}

				// Token: 0x0600128E RID: 4750 RVA: 0x00060CFC File Offset: 0x0005EEFC
				private ActionElementMap GIwzRcbzZzaKcOJcpekOifimguZWA(ControllerType A_1, string A_2, bool A_3)
				{
					int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(A_2, false);
					return this.MWOUhqMtHMofZaqibnLBktHwSugb(A_1, num, A_3);
				}

				// Token: 0x0600128F RID: 4751 RVA: 0x000106BB File Offset: 0x0000E8BB
				private IEnumerable<ActionElementMap> rUUPwjleDpKlZHsmpjSEjbzJtFIb(ControllerType A_1, int A_2, bool A_3)
				{
					if (A_2 < 0)
					{
						yield break;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					int num;
					for (int i = 0; i < rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL; i = num + 1)
					{
						IList<ControllerMap> list = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA.IRobIJiETvaITbHPpoekuVTtDgxHA;
						for (int j = 0; j < list.Count; j = num + 1)
						{
							if ((!A_3 || list[j].enabled) && list[j].ContainsAction(A_2))
							{
								foreach (ActionElementMap actionElementMap in list[j].ElementMapsWithAction(A_2, A_3))
								{
									yield return actionElementMap;
								}
								IEnumerator<ActionElementMap> enumerator = null;
							}
							num = j;
						}
						list = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x06001290 RID: 4752 RVA: 0x00060D20 File Offset: 0x0005EF20
				private IEnumerable<ActionElementMap> SnZjDUKfqwbtUjTgcHcccBoQVAIEA(ControllerType A_1, string A_2, bool A_3)
				{
					int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(A_2, false);
					return this.rUUPwjleDpKlZHsmpjSEjbzJtFIb(A_1, num, A_3);
				}

				// Token: 0x06001291 RID: 4753 RVA: 0x00060D44 File Offset: 0x0005EF44
				private int TLhyhBtIvalkJddZHvUhidvQEbpx(int A_1, bool A_2, List<ActionElementMap> A_3, bool A_4)
				{
					if (A_3 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!A_4)
					{
						A_3.Clear();
					}
					if (A_1 < 0)
					{
						return 0;
					}
					int num = 0;
					int ePoqkUtmPVaqcSRQDEsmWDfPnprd = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.ePoqkUtmPVaqcSRQDEsmWDfPnprd;
					for (int i = 0; i < ePoqkUtmPVaqcSRQDEsmWDfPnprd; i++)
					{
						Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.CtGoIeauMpKsCXqilTCeQCxqyY(i);
						int num2 = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
						for (int j = 0; j < num2; j++)
						{
							dBWjOjXnFJmUROzCVhQpynliVgPI dBWjOjXnFJmUROzCVhQpynliVgPI = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(j).AxzIHFaeuZajYboPHuvsfCYAXoQwA;
							int num3 = dBWjOjXnFJmUROzCVhQpynliVgPI.sSEkNHPvFzDptlNqDocRnDXFEYyY;
							for (int k = 0; k < num3; k++)
							{
								ControllerMap controllerMap = dBWjOjXnFJmUROzCVhQpynliVgPI.kpSXGnRVLDEHUvJSffrGHSOpEAHGb(k);
								if ((!A_2 || controllerMap.enabled) && controllerMap.ContainsAction(A_1))
								{
									num += controllerMap.mlEHJfCzMGYloowqdGhIZFCxCoCi(A_1, A_2, A_3, true);
								}
							}
						}
					}
					return num;
				}

				// Token: 0x06001292 RID: 4754 RVA: 0x00060E18 File Offset: 0x0005F018
				private int NIeSOBgxdrPquPQcWrKSNmurLHl(int A_1, bool A_2, List<ActionElementMap> A_3, bool A_4)
				{
					if (A_3 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!A_4)
					{
						A_3.Clear();
					}
					if (A_1 < 0)
					{
						return 0;
					}
					int num = 0;
					int ePoqkUtmPVaqcSRQDEsmWDfPnprd = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.ePoqkUtmPVaqcSRQDEsmWDfPnprd;
					for (int i = 0; i < ePoqkUtmPVaqcSRQDEsmWDfPnprd; i++)
					{
						Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.CtGoIeauMpKsCXqilTCeQCxqyY(i);
						int num2 = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
						for (int j = 0; j < num2; j++)
						{
							dBWjOjXnFJmUROzCVhQpynliVgPI dBWjOjXnFJmUROzCVhQpynliVgPI = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(j).AxzIHFaeuZajYboPHuvsfCYAXoQwA;
							int num3 = dBWjOjXnFJmUROzCVhQpynliVgPI.sSEkNHPvFzDptlNqDocRnDXFEYyY;
							for (int k = 0; k < num3; k++)
							{
								ControllerMapWithAxes controllerMapWithAxes = dBWjOjXnFJmUROzCVhQpynliVgPI.kpSXGnRVLDEHUvJSffrGHSOpEAHGb(k) as ControllerMapWithAxes;
								if (controllerMapWithAxes != null && (!A_2 || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(A_1))
								{
									num += controllerMapWithAxes.JRQagtmKBSJLHIKaMzysyjcOtXlI(A_1, A_2, A_3, true);
								}
							}
						}
					}
					return num;
				}

				// Token: 0x06001293 RID: 4755 RVA: 0x00060EF8 File Offset: 0x0005F0F8
				private int CQfYczEYoOollBKDaPkianGEzacc(int A_1, bool A_2, List<ActionElementMap> A_3, bool A_4)
				{
					if (A_3 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!A_4)
					{
						A_3.Clear();
					}
					if (A_1 < 0)
					{
						return 0;
					}
					int num = 0;
					int ePoqkUtmPVaqcSRQDEsmWDfPnprd = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.ePoqkUtmPVaqcSRQDEsmWDfPnprd;
					for (int i = 0; i < ePoqkUtmPVaqcSRQDEsmWDfPnprd; i++)
					{
						Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.CtGoIeauMpKsCXqilTCeQCxqyY(i);
						int num2 = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
						for (int j = 0; j < num2; j++)
						{
							dBWjOjXnFJmUROzCVhQpynliVgPI dBWjOjXnFJmUROzCVhQpynliVgPI = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(j).AxzIHFaeuZajYboPHuvsfCYAXoQwA;
							int num3 = dBWjOjXnFJmUROzCVhQpynliVgPI.sSEkNHPvFzDptlNqDocRnDXFEYyY;
							for (int k = 0; k < num3; k++)
							{
								ControllerMap controllerMap = dBWjOjXnFJmUROzCVhQpynliVgPI.kpSXGnRVLDEHUvJSffrGHSOpEAHGb(k);
								if ((!A_2 || controllerMap.enabled) && controllerMap.ContainsAction(A_1))
								{
									num += controllerMap.SKUXJwoIaunBEdjJKstnsFfqeDRj(A_1, A_2, A_3, true);
								}
							}
						}
					}
					return num;
				}

				// Token: 0x06001294 RID: 4756 RVA: 0x00060FCC File Offset: 0x0005F1CC
				private int coeoeRATNJkIVPjzLQFbvWFLTbis(ControllerType A_1, int A_2, bool A_3, List<ActionElementMap> A_4, bool A_5)
				{
					if (A_4 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!A_5)
					{
						A_4.Clear();
					}
					if (A_2 < 0)
					{
						return 0;
					}
					int num = 0;
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					for (int i = 0; i < rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						IList<ControllerMap> list = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA.IRobIJiETvaITbHPpoekuVTtDgxHA;
						for (int j = 0; j < list.Count; j++)
						{
							if ((!A_3 || list[j].enabled) && list[j].ContainsAction(A_2))
							{
								num += list[j].mlEHJfCzMGYloowqdGhIZFCxCoCi(A_2, A_3, A_4, true);
							}
						}
					}
					return num;
				}

				// Token: 0x06001295 RID: 4757 RVA: 0x00061080 File Offset: 0x0005F280
				private int IcvWvKgmVICkpIdgFCqoDTjnNefZA(ControllerType A_1, string A_2, bool A_3, List<ActionElementMap> A_4, bool A_5)
				{
					int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(A_2, false);
					return this.coeoeRATNJkIVPjzLQFbvWFLTbis(A_1, num, A_3, A_4, A_5);
				}

				// Token: 0x06001296 RID: 4758 RVA: 0x000610A8 File Offset: 0x0005F2A8
				private int UcAupJRCyOoJauHxkmNsyPZuCzFh(ControllerType A_1, int A_2, bool A_3, List<ActionElementMap> A_4, bool A_5)
				{
					if (A_4 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!A_5)
					{
						A_4.Clear();
					}
					if (A_2 < 0)
					{
						return 0;
					}
					int num = 0;
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					for (int i = 0; i < rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						IList<ControllerMap> list = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA.IRobIJiETvaITbHPpoekuVTtDgxHA;
						for (int j = 0; j < list.Count; j++)
						{
							if (!(list[j] is ControllerMapWithAxes))
							{
								return A_4.Count;
							}
							if ((!A_3 || list[j].enabled) && list[j].ContainsAction(A_2))
							{
								num += (list[j] as ControllerMapWithAxes).JRQagtmKBSJLHIKaMzysyjcOtXlI(A_2, A_3, A_4, true);
							}
						}
					}
					return num;
				}

				// Token: 0x06001297 RID: 4759 RVA: 0x00061178 File Offset: 0x0005F378
				private int WReGFeFfEnTxMkDQbYwcflYpjLMj(ControllerType A_1, string A_2, bool A_3, List<ActionElementMap> A_4, bool A_5)
				{
					int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(A_2, false);
					return this.UcAupJRCyOoJauHxkmNsyPZuCzFh(A_1, num, A_3, A_4, A_5);
				}

				// Token: 0x06001298 RID: 4760 RVA: 0x000611A0 File Offset: 0x0005F3A0
				private int CFnpOmKznRMQviliRQZkQOwDcLgS(ControllerType A_1, int A_2, bool A_3, List<ActionElementMap> A_4, bool A_5)
				{
					if (A_4 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!A_5)
					{
						A_4.Clear();
					}
					if (A_2 < 0)
					{
						return 0;
					}
					int num = 0;
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					for (int i = 0; i < rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL; i++)
					{
						IList<ControllerMap> list = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA.IRobIJiETvaITbHPpoekuVTtDgxHA;
						for (int j = 0; j < list.Count; j++)
						{
							if ((!A_3 || list[j].enabled) && list[j].ContainsAction(A_2))
							{
								num += list[j].SKUXJwoIaunBEdjJKstnsFfqeDRj(A_2, A_3, A_4, true);
							}
						}
					}
					return num;
				}

				// Token: 0x06001299 RID: 4761 RVA: 0x00061254 File Offset: 0x0005F454
				private int ObZGBRbbtpYgeBIXugbQeDDptYEjA(ControllerType A_1, string A_2, bool A_3, List<ActionElementMap> A_4, bool A_5)
				{
					int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(A_2, false);
					return this.CFnpOmKznRMQviliRQZkQOwDcLgS(A_1, num, A_3, A_4, A_5);
				}

				// Token: 0x0600129A RID: 4762 RVA: 0x0006127C File Offset: 0x0005F47C
				private ActionElementMap QgzZitrKMsYnjWTKPcAncDeqpilN(ControllerType A_1, int A_2, int A_3, bool A_4)
				{
					if (A_3 < 0)
					{
						return null;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_2);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> list = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).AxzIHFaeuZajYboPHuvsfCYAXoQwA.IRobIJiETvaITbHPpoekuVTtDgxHA;
					for (int i = 0; i < list.Count; i++)
					{
						if ((!A_4 || list[i].enabled) && list[i].ContainsAction(A_3))
						{
							ActionElementMap firstButtonMapWithAction = list[i].GetFirstButtonMapWithAction(A_3, A_4);
							if (firstButtonMapWithAction != null)
							{
								return firstButtonMapWithAction;
							}
						}
					}
					return null;
				}

				// Token: 0x0600129B RID: 4763 RVA: 0x0006130C File Offset: 0x0005F50C
				private ActionElementMap CHhSfkUIHAPLFOlNofExCOlFbbMr(ControllerType A_1, int A_2, string A_3, bool A_4)
				{
					int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(A_3, false);
					return this.QgzZitrKMsYnjWTKPcAncDeqpilN(A_1, A_2, num, A_4);
				}

				// Token: 0x0600129C RID: 4764 RVA: 0x000106E0 File Offset: 0x0000E8E0
				private IEnumerable<ActionElementMap> rlBtglSNvLmMMkVsGjefcJtTtesk(ControllerType A_1, int A_2, int A_3, bool A_4)
				{
					if (A_3 < 0)
					{
						yield break;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_2);
					if (num < 0)
					{
						yield break;
					}
					IList<ControllerMap> list = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).AxzIHFaeuZajYboPHuvsfCYAXoQwA.IRobIJiETvaITbHPpoekuVTtDgxHA;
					int num2;
					for (int i = 0; i < list.Count; i = num2 + 1)
					{
						if ((!A_4 || list[i].enabled) && list[i].ContainsAction(A_3))
						{
							foreach (ActionElementMap actionElementMap in list[i].ButtonMapsWithAction(A_3, A_4))
							{
								yield return actionElementMap;
							}
							IEnumerator<ActionElementMap> enumerator = null;
						}
						num2 = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x0600129D RID: 4765 RVA: 0x00061334 File Offset: 0x0005F534
				private IEnumerable<ActionElementMap> CHFHQBSQvTBAdLSOAFcEkSSBbXDV(ControllerType A_1, int A_2, string A_3, bool A_4)
				{
					int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(A_3, false);
					return this.rlBtglSNvLmMMkVsGjefcJtTtesk(A_1, A_2, num, A_4);
				}

				// Token: 0x0600129E RID: 4766 RVA: 0x0006135C File Offset: 0x0005F55C
				private ActionElementMap irhBOZFlHeLgdBOMgwjLQclNcABzA(ControllerType A_1, int A_2, int A_3, bool A_4)
				{
					if (A_3 < 0)
					{
						return null;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_2);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> list = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).AxzIHFaeuZajYboPHuvsfCYAXoQwA.IRobIJiETvaITbHPpoekuVTtDgxHA;
					for (int i = 0; i < list.Count; i++)
					{
						if (!(list[i] is ControllerMapWithAxes))
						{
							return null;
						}
						if ((!A_4 || list[i].enabled) && list[i].ContainsAction(A_3))
						{
							ActionElementMap firstAxisMapWithAction = (list[i] as ControllerMapWithAxes).GetFirstAxisMapWithAction(A_3, A_4);
							if (firstAxisMapWithAction != null)
							{
								return firstAxisMapWithAction;
							}
						}
					}
					return null;
				}

				// Token: 0x0600129F RID: 4767 RVA: 0x00061404 File Offset: 0x0005F604
				private ActionElementMap iDhbyPFhzPECtIgiBOTFOEfvoGkpc(ControllerType A_1, int A_2, string A_3, bool A_4)
				{
					int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(A_3, false);
					return this.irhBOZFlHeLgdBOMgwjLQclNcABzA(A_1, A_2, num, A_4);
				}

				// Token: 0x060012A0 RID: 4768 RVA: 0x0001070D File Offset: 0x0000E90D
				private IEnumerable<ActionElementMap> dNHjMvaSTQinNiEbUPBFLuoIZSKm(ControllerType A_1, int A_2, int A_3, bool A_4)
				{
					if (A_3 < 0)
					{
						yield break;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_2);
					if (num < 0)
					{
						yield break;
					}
					IList<ControllerMap> list = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).AxzIHFaeuZajYboPHuvsfCYAXoQwA.IRobIJiETvaITbHPpoekuVTtDgxHA;
					int num2;
					for (int i = 0; i < list.Count; i = num2 + 1)
					{
						if (!(list[i] is ControllerMapWithAxes))
						{
							yield break;
						}
						if ((!A_4 || list[i].enabled) && list[i].ContainsAction(A_3))
						{
							foreach (ActionElementMap actionElementMap in (list[i] as ControllerMapWithAxes).AxisMapsWithAction(A_3, A_4))
							{
								yield return actionElementMap;
							}
							IEnumerator<ActionElementMap> enumerator = null;
						}
						num2 = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x060012A1 RID: 4769 RVA: 0x0006142C File Offset: 0x0005F62C
				private IEnumerable<ActionElementMap> pAniPHcUhTBPcnPcuatSfcqCUbVgA(ControllerType A_1, int A_2, string A_3, bool A_4)
				{
					int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(A_3, false);
					return this.dNHjMvaSTQinNiEbUPBFLuoIZSKm(A_1, A_2, num, A_4);
				}

				// Token: 0x060012A2 RID: 4770 RVA: 0x00061454 File Offset: 0x0005F654
				private ActionElementMap OtgqfarNSXkZjELIeLASPtqPrKIu(ControllerType A_1, int A_2, int A_3, bool A_4)
				{
					if (A_3 < 0)
					{
						return null;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_2);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> list = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).AxzIHFaeuZajYboPHuvsfCYAXoQwA.IRobIJiETvaITbHPpoekuVTtDgxHA;
					for (int i = 0; i < list.Count; i++)
					{
						if ((!A_4 || list[i].enabled) && list[i].ContainsAction(A_3))
						{
							ActionElementMap firstElementMapWithAction = list[i].GetFirstElementMapWithAction(A_3, A_4);
							if (firstElementMapWithAction != null)
							{
								return firstElementMapWithAction;
							}
						}
					}
					return null;
				}

				// Token: 0x060012A3 RID: 4771 RVA: 0x000614E4 File Offset: 0x0005F6E4
				private ActionElementMap mebxibZMoyfnzhIFOCZfTmGwHyygb(ControllerType A_1, int A_2, string A_3, bool A_4)
				{
					int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(A_3, false);
					return this.OtgqfarNSXkZjELIeLASPtqPrKIu(A_1, A_2, num, A_4);
				}

				// Token: 0x060012A4 RID: 4772 RVA: 0x0001073A File Offset: 0x0000E93A
				private IEnumerable<ActionElementMap> fCJDNVVGBNvjwubUuqugjLGPdxpBA(ControllerType A_1, int A_2, int A_3, bool A_4)
				{
					if (A_3 < 0)
					{
						yield break;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_2);
					if (num < 0)
					{
						yield break;
					}
					IList<ControllerMap> list = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).AxzIHFaeuZajYboPHuvsfCYAXoQwA.IRobIJiETvaITbHPpoekuVTtDgxHA;
					int num2;
					for (int i = 0; i < list.Count; i = num2 + 1)
					{
						if ((!A_4 || list[i].enabled) && list[i].ContainsAction(A_3))
						{
							foreach (ActionElementMap actionElementMap in list[i].ElementMapsWithAction(A_3, A_4))
							{
								yield return actionElementMap;
							}
							IEnumerator<ActionElementMap> enumerator = null;
						}
						num2 = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x060012A5 RID: 4773 RVA: 0x0006150C File Offset: 0x0005F70C
				private IEnumerable<ActionElementMap> eiNUKafYCnvWRjFrfmCWKcctbhTH(ControllerType A_1, int A_2, string A_3, bool A_4)
				{
					int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(A_3, false);
					return this.fCJDNVVGBNvjwubUuqugjLGPdxpBA(A_1, A_2, num, A_4);
				}

				// Token: 0x060012A6 RID: 4774 RVA: 0x00061534 File Offset: 0x0005F734
				private int NYVBIsykLGZXTYnfpTFnptBBSHKm(ControllerType A_1, int A_2, int A_3, bool A_4, List<ActionElementMap> A_5, bool A_6)
				{
					if (A_5 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!A_6)
					{
						A_5.Clear();
					}
					if (A_3 < 0)
					{
						return 0;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_2);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> list = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).AxzIHFaeuZajYboPHuvsfCYAXoQwA.IRobIJiETvaITbHPpoekuVTtDgxHA;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerMap controllerMap = list[i];
						if ((!A_4 || controllerMap.enabled) && controllerMap.ContainsAction(A_3))
						{
							num2 += controllerMap.mlEHJfCzMGYloowqdGhIZFCxCoCi(A_3, A_4, A_5, true);
						}
					}
					return num2;
				}

				// Token: 0x060012A7 RID: 4775 RVA: 0x000615DC File Offset: 0x0005F7DC
				private int GbhyHDOoxlmdtpEFldMVqHSwMAsN(ControllerType A_1, int A_2, string A_3, bool A_4, List<ActionElementMap> A_5, bool A_6)
				{
					int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(A_3, false);
					return this.NYVBIsykLGZXTYnfpTFnptBBSHKm(A_1, A_2, num, A_4, A_5, A_6);
				}

				// Token: 0x060012A8 RID: 4776 RVA: 0x00061608 File Offset: 0x0005F808
				private int dTrAdAIyxzfrtZZVWuArCzLWNKjH(ControllerType A_1, int A_2, int A_3, bool A_4, List<ActionElementMap> A_5, bool A_6)
				{
					if (A_5 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!A_6)
					{
						A_5.Clear();
					}
					if (A_3 < 0)
					{
						return 0;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_2);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> list = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).AxzIHFaeuZajYboPHuvsfCYAXoQwA.IRobIJiETvaITbHPpoekuVTtDgxHA;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerMapWithAxes controllerMapWithAxes = list[i] as ControllerMapWithAxes;
						if (list == null)
						{
							return num2;
						}
						if ((!A_4 || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(A_3))
						{
							num2 += controllerMapWithAxes.JRQagtmKBSJLHIKaMzysyjcOtXlI(A_3, A_4, A_5, true);
						}
					}
					return num2;
				}

				// Token: 0x060012A9 RID: 4777 RVA: 0x000616BC File Offset: 0x0005F8BC
				private int bWAuvprnnkFsjEhPtUuHqIjWfsmx(ControllerType A_1, int A_2, string A_3, bool A_4, List<ActionElementMap> A_5, bool A_6)
				{
					int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(A_3, false);
					return this.dTrAdAIyxzfrtZZVWuArCzLWNKjH(A_1, A_2, num, A_4, A_5, A_6);
				}

				// Token: 0x060012AA RID: 4778 RVA: 0x000616E8 File Offset: 0x0005F8E8
				private int dZtPZwJKsnLOBugeyfgacYNaenrxA(ControllerType A_1, int A_2, int A_3, bool A_4, List<ActionElementMap> A_5, bool A_6)
				{
					if (A_5 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!A_6)
					{
						A_5.Clear();
					}
					if (A_3 < 0)
					{
						return 0;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(A_1);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.jVtFwimrOgSFQQoYBDWYmPSvkaPH(A_2);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> list = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(num).AxzIHFaeuZajYboPHuvsfCYAXoQwA.IRobIJiETvaITbHPpoekuVTtDgxHA;
					for (int i = 0; i < list.Count; i++)
					{
						if ((!A_4 || list[i].enabled) && list[i].ContainsAction(A_3))
						{
							num2 += list[i].SKUXJwoIaunBEdjJKstnsFfqeDRj(A_3, A_4, A_5, true);
						}
					}
					return num2;
				}

				// Token: 0x060012AB RID: 4779 RVA: 0x00061798 File Offset: 0x0005F998
				private int fjLmdNhjnAdanmkJUJdkAyPiIZYN(ControllerType A_1, int A_2, string A_3, bool A_4, List<ActionElementMap> A_5, bool A_6)
				{
					int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(A_3, false);
					return this.dZtPZwJKsnLOBugeyfgacYNaenrxA(A_1, A_2, num, A_4, A_5, A_6);
				}

				// Token: 0x060012AC RID: 4780 RVA: 0x000617C4 File Offset: 0x0005F9C4
				private ActionElementMap QtNoHqSOEXgeXbnAGcLBNtPrnHamA(IControllerElementTarget A_1, bool A_2, int A_3, bool A_4)
				{
					if (A_1 == null)
					{
						return null;
					}
					Controller controller = A_1.controller;
					if (controller == null)
					{
						return null;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controller.type);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
					for (int i = 0; i < num; i++)
					{
						dBWjOjXnFJmUROzCVhQpynliVgPI dBWjOjXnFJmUROzCVhQpynliVgPI = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA;
						dBWjOjXnFJmUROzCVhQpynliVgPI.sSEkNHPvFzDptlNqDocRnDXFEYyY;
						IList<ControllerMap> list = dBWjOjXnFJmUROzCVhQpynliVgPI.IRobIJiETvaITbHPpoekuVTtDgxHA;
						int count = list.Count;
						for (int j = 0; j < count; j++)
						{
							ControllerMap controllerMap = list[j];
							if (!A_4 || controllerMap.enabled)
							{
								bool flag;
								ActionElementMap actionElementMap = controllerMap.VWwHPcWBNEZnnVHhltRXgvEuUTBR(A_1, A_2, A_3, A_4, out flag);
								if (actionElementMap != null)
								{
									return actionElementMap;
								}
							}
						}
					}
					return null;
				}

				// Token: 0x060012AD RID: 4781 RVA: 0x00010767 File Offset: 0x0000E967
				private IEnumerable<ActionElementMap> lmYuFRzvdSaWEjFJdsfrfXwfrSaA(IControllerElementTarget A_1, bool A_2, int A_3, bool A_4)
				{
					if (A_1 == null)
					{
						yield break;
					}
					Controller controller = A_1.controller;
					if (controller == null)
					{
						yield break;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controller.type);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
					int num2;
					for (int i = 0; i < num; i = num2 + 1)
					{
						dBWjOjXnFJmUROzCVhQpynliVgPI dBWjOjXnFJmUROzCVhQpynliVgPI = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA;
						dBWjOjXnFJmUROzCVhQpynliVgPI.sSEkNHPvFzDptlNqDocRnDXFEYyY;
						IList<ControllerMap> list = dBWjOjXnFJmUROzCVhQpynliVgPI.IRobIJiETvaITbHPpoekuVTtDgxHA;
						int count = list.Count;
						for (int j = 0; j < count; j = num2 + 1)
						{
							ControllerMap controllerMap = list[j];
							if (!A_4 || controllerMap.enabled)
							{
								using (TempListPool.TList<ActionElementMap> tlist = TempListPool.GetTList<ActionElementMap>())
								{
									List<ActionElementMap> list2 = tlist.list;
									bool flag;
									controllerMap.qZOynvlardfOgSmhUcYADceZXgiK(A_1, A_2, A_3, A_4, list2, true, out flag);
									foreach (ActionElementMap actionElementMap in list2)
									{
										yield return actionElementMap;
									}
									List<ActionElementMap>.Enumerator enumerator = default(List<ActionElementMap>.Enumerator);
								}
								TempListPool.TList<ActionElementMap> tlist = null;
							}
							num2 = j;
						}
						list = null;
						num2 = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x060012AE RID: 4782 RVA: 0x00061870 File Offset: 0x0005FA70
				private int uJnxVkMLoCiqyhOSKOsXGOrjOtqlB(IControllerElementTarget A_1, bool A_2, int A_3, bool A_4, List<ActionElementMap> A_5, bool A_6)
				{
					if (A_5 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!A_6)
					{
						A_5.Clear();
					}
					if (A_1 == null)
					{
						return 0;
					}
					Controller controller = A_1.controller;
					if (controller == null)
					{
						return 0;
					}
					Player.ControllerHelper.rrrUVbResWNdbXKvkkOIseeimvIu rrrUVbResWNdbXKvkkOIseeimvIu = this.WQtQfVGCqewEYhTXSMYhGCZQawTm.ylCPpFWsrSbqhhneUtsQXRtlJEDi.kyfmYKkxmjPxLLdneuEkZIEuZdkx(controller.type);
					int num = rrrUVbResWNdbXKvkkOIseeimvIu.hUvoPojtJZIUBnFkCGjslfijGbmL;
					int num2 = 0;
					for (int i = 0; i < num; i++)
					{
						dBWjOjXnFJmUROzCVhQpynliVgPI dBWjOjXnFJmUROzCVhQpynliVgPI = rrrUVbResWNdbXKvkkOIseeimvIu.UJAuNWFIjyrTyJDgUveqTrIhRNKT(i).AxzIHFaeuZajYboPHuvsfCYAXoQwA;
						dBWjOjXnFJmUROzCVhQpynliVgPI.sSEkNHPvFzDptlNqDocRnDXFEYyY;
						IList<ControllerMap> list = dBWjOjXnFJmUROzCVhQpynliVgPI.IRobIJiETvaITbHPpoekuVTtDgxHA;
						int count = list.Count;
						for (int j = 0; j < count; j++)
						{
							ControllerMap controllerMap = list[j];
							if (!A_4 || controllerMap.enabled)
							{
								bool flag;
								num2 += controllerMap.qZOynvlardfOgSmhUcYADceZXgiK(A_1, A_2, A_3, A_4, A_5, A_6, out flag);
							}
						}
					}
					return num2;
				}

				// Token: 0x04000A0E RID: 2574
				private readonly OdwwNwDVsLLbukoEpkWRZpETNEYi rnFfambBUNgqcfQyoQGVXGnHKdbeA;

				// Token: 0x04000A0F RID: 2575
				private Player lawNLFQVYtOrvswGWUkKybfZHlLj;

				// Token: 0x04000A10 RID: 2576
				private Player.ControllerHelper WQtQfVGCqewEYhTXSMYhGCZQawTm;

				// Token: 0x04000A11 RID: 2577
				private readonly ControllerMapEnabler PcMgoVlXoOYNqGgBwoSEwICaMdvB;

				// Token: 0x04000A12 RID: 2578
				private readonly ControllerMapLayoutManager ZZgzMQjqyDvJGNjcVqvujpABedsN;

				// Token: 0x04000A13 RID: 2579
				private readonly int OQaPFYxSGgKObINRruqbxILdjVUO;
			}

			// Token: 0x02000190 RID: 400
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class PollingHelper : CodeHelper
			{
				// Token: 0x0600134A RID: 4938 RVA: 0x00010BE2 File Offset: 0x0000EDE2
				internal PollingHelper(Player A_1, Player.ControllerHelper A_2)
				{
					this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA = ReInput.id;
					this.CchIzwRsJJJbdcuqXfvcVQrXKNyd = A_1;
					this.EMrBmVBWSGWIQslUCxvXPZlRReTB = A_2;
				}

				// Token: 0x0600134B RID: 4939 RVA: 0x00064210 File Offset: 0x00062410
				public ControllerPollingInfo PollControllerForFirstElement(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA)
					{
						ReInput.CheckInitialized(this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA);
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return this.YyqHynGXEZuctllJNJuYBbpRdopY();
					case ControllerType.Mouse:
						return this.mOkFEoevEMkwXELzlSZlgYjDtathB();
					case ControllerType.Joystick:
						return this.yiHManzwHZApJXIKxGOnjkKDdhYz(controllerId);
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.SgYemhlNZbUkJUMtwfBksJPzfAxl(controllerId);
					}
				}

				// Token: 0x0600134C RID: 4940 RVA: 0x00064278 File Offset: 0x00062478
				public ControllerPollingInfo PollControllerForFirstElementDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA)
					{
						ReInput.CheckInitialized(this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA);
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return this.izabOCEbHnWBQSFewBmvBoRWParYA();
					case ControllerType.Mouse:
						return this.TjhkiMrKcbFioDpqhQIocmtpwvsCA();
					case ControllerType.Joystick:
						return this.owOdOFZbMIRVCElTxGbghqBPBqmB(controllerId);
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.AjDKzubivRcsmCquAeevxXiTcyRw(controllerId);
					}
				}

				// Token: 0x0600134D RID: 4941 RVA: 0x000642E0 File Offset: 0x000624E0
				public ControllerPollingInfo PollControllerForFirstButton(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA)
					{
						ReInput.CheckInitialized(this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA);
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return this.YyqHynGXEZuctllJNJuYBbpRdopY();
					case ControllerType.Mouse:
						return this.VSpTaidDMCHSIDVfjElAWhkpvUCY();
					case ControllerType.Joystick:
						return this.ytqszYYTJkxdNuFlYajOKdqDbDanA(controllerId);
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.ufHqsaAAaCfoGCqxlwbnZBZvasxg(controllerId);
					}
				}

				// Token: 0x0600134E RID: 4942 RVA: 0x00064348 File Offset: 0x00062548
				public ControllerPollingInfo PollControllerForFirstButtonDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA)
					{
						ReInput.CheckInitialized(this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA);
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return this.izabOCEbHnWBQSFewBmvBoRWParYA();
					case ControllerType.Mouse:
						return this.KImHirENeZMDgdiJSAzWUmMfqvLP();
					case ControllerType.Joystick:
						return this.mVGmrfynsrGBKkkaWKHUbFDdNAUdc(controllerId);
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.xcAVNjcDEVaHVchjuTQJPFvhiXfgb(controllerId);
					}
				}

				// Token: 0x0600134F RID: 4943 RVA: 0x000643B0 File Offset: 0x000625B0
				public ControllerPollingInfo PollControllerForFirstAxis(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA)
					{
						ReInput.CheckInitialized(this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA);
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					case ControllerType.Mouse:
						return this.IRsVRWhPPeyTBJmlRjVNByZNuQMvA();
					case ControllerType.Joystick:
						return this.GanQFgecYnFovRdZgAQOgirvSZwTA(controllerId);
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.XiPHmttzLpDAbGfrmYGtwEImxktc(controllerId);
					}
				}

				// Token: 0x06001350 RID: 4944 RVA: 0x00064418 File Offset: 0x00062618
				public IEnumerable<ControllerPollingInfo> PollControllerForAllElements(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA)
					{
						ReInput.CheckInitialized(this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return this.HMCEqgSPVwcwKLbOpQrSvCeLwNci();
					case ControllerType.Mouse:
						return this.SHrNuRMVnCCeVSTpeTBjZMisvGCG();
					case ControllerType.Joystick:
						return this.lYVJCtdRYKQIzmGjLSLqJaHCatXEA(controllerId);
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.CAKWyMmQFwPcqETYGaPVfJCJaoDKA(controllerId);
					}
				}

				// Token: 0x06001351 RID: 4945 RVA: 0x00064480 File Offset: 0x00062680
				public IEnumerable<ControllerPollingInfo> PollControllerForAllElementsDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA)
					{
						ReInput.CheckInitialized(this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return this.qiNiTuDrrafGSAfZpAToKqAEHKqL();
					case ControllerType.Mouse:
						return this.AlrhQpKDudJFHbKxsZkKfqgVsWdE();
					case ControllerType.Joystick:
						return this.JBDhWOkkaQQDvUwUCCVErDLvcsAFA(controllerId);
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.SbmAjSCCxUiFzdCsaOpdfYdgwgPgB(controllerId);
					}
				}

				// Token: 0x06001352 RID: 4946 RVA: 0x000644E8 File Offset: 0x000626E8
				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtons(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA)
					{
						ReInput.CheckInitialized(this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return this.HMCEqgSPVwcwKLbOpQrSvCeLwNci();
					case ControllerType.Mouse:
						return this.VMxJQtnvyaHIiVnlhvTFmcrrGcAdA();
					case ControllerType.Joystick:
						return this.QPUtvsiELIgNbWQFyxmAlrmHFQeM(controllerId);
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.VPdKqMUMVfBjsTNJGyhQOckpxmrE(controllerId);
					}
				}

				// Token: 0x06001353 RID: 4947 RVA: 0x00064550 File Offset: 0x00062750
				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtonsDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA)
					{
						ReInput.CheckInitialized(this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return this.qiNiTuDrrafGSAfZpAToKqAEHKqL();
					case ControllerType.Mouse:
						return this.iuVddGIcCbCtoEFAEhAsqAIrDQvz();
					case ControllerType.Joystick:
						return this.bmgbDXJSITDqXcmBbSwHrRrVjDkPc(controllerId);
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.KhSYZJbsqKZiJFzAlEFxHuiOQChk(controllerId);
					}
				}

				// Token: 0x06001354 RID: 4948 RVA: 0x000645B8 File Offset: 0x000627B8
				public IEnumerable<ControllerPollingInfo> PollControllerForAllAxes(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA)
					{
						ReInput.CheckInitialized(this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return new List<ControllerPollingInfo>();
					case ControllerType.Mouse:
						return this.jsTWFHNSMlPDUxbsHBdWUhDZBpFGA();
					case ControllerType.Joystick:
						return this.ZckquomERWIEvNtixHYllYAPuqYd(controllerId);
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.cjKyrglNlFhsHSgEsrEiHodOCrYL(controllerId);
					}
				}

				// Token: 0x06001355 RID: 4949 RVA: 0x00064620 File Offset: 0x00062820
				public ControllerPollingInfo PollAllControllersOfTypeForFirstElement(ControllerType controllerType)
				{
					if (ReInput._id != this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA)
					{
						ReInput.CheckInitialized(this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA);
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return this.YyqHynGXEZuctllJNJuYBbpRdopY();
					case ControllerType.Mouse:
						return this.mOkFEoevEMkwXELzlSZlgYjDtathB();
					case ControllerType.Joystick:
						return this.oVrBbDGhwVSZPIcilycrqoBewHdFA();
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.AekEyXqcDfXCkYGMTNsYoIkWkfsn();
					}
				}

				// Token: 0x06001356 RID: 4950 RVA: 0x00064688 File Offset: 0x00062888
				public ControllerPollingInfo PollAllControllersOfTypeForFirstButton(ControllerType controllerType)
				{
					if (ReInput._id != this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA)
					{
						ReInput.CheckInitialized(this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA);
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return this.YyqHynGXEZuctllJNJuYBbpRdopY();
					case ControllerType.Mouse:
						return this.VSpTaidDMCHSIDVfjElAWhkpvUCY();
					case ControllerType.Joystick:
						return this.kvAjxFkKOYJRFnHBwryATUcWSfoS();
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.hEsZXtjoQGaVcQiXaAFosIeammVL();
					}
				}

				// Token: 0x06001357 RID: 4951 RVA: 0x000646F0 File Offset: 0x000628F0
				public ControllerPollingInfo PollAllControllersOfTypeForFirstButtonDown(ControllerType controllerType)
				{
					if (ReInput._id != this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA)
					{
						ReInput.CheckInitialized(this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA);
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return this.izabOCEbHnWBQSFewBmvBoRWParYA();
					case ControllerType.Mouse:
						return this.KImHirENeZMDgdiJSAzWUmMfqvLP();
					case ControllerType.Joystick:
						return this.RrEjHXibBEnwNVQJCCXnJweTQIUR();
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.CcODhfMjQOCsBFUyCSVIFswjwsctA();
					}
				}

				// Token: 0x06001358 RID: 4952 RVA: 0x00064758 File Offset: 0x00062958
				public ControllerPollingInfo PollAllControllersOfTypeForFirstAxis(ControllerType controllerType)
				{
					if (ReInput._id != this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA)
					{
						ReInput.CheckInitialized(this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA);
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					case ControllerType.Mouse:
						return this.IRsVRWhPPeyTBJmlRjVNByZNuQMvA();
					case ControllerType.Joystick:
						return this.RdVAUyIHWhUsytjPoIkBFpNckbOf();
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.HXKaUAAldtCaopirbGbqaIDijjmGc();
					}
				}

				// Token: 0x06001359 RID: 4953 RVA: 0x000647C0 File Offset: 0x000629C0
				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllElements(ControllerType controllerType)
				{
					if (ReInput._id != this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA)
					{
						ReInput.CheckInitialized(this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return this.HMCEqgSPVwcwKLbOpQrSvCeLwNci();
					case ControllerType.Mouse:
						return this.SHrNuRMVnCCeVSTpeTBjZMisvGCG();
					case ControllerType.Joystick:
						return this.YorVxVDHWsWSADSjoQZvPhJTJer();
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.EsDvuTfkMTZzzYlNQynUSoBtpalB();
					}
				}

				// Token: 0x0600135A RID: 4954 RVA: 0x00064828 File Offset: 0x00062A28
				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllElementsDown(ControllerType controllerType)
				{
					if (ReInput._id != this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA)
					{
						ReInput.CheckInitialized(this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return this.qiNiTuDrrafGSAfZpAToKqAEHKqL();
					case ControllerType.Mouse:
						return this.AlrhQpKDudJFHbKxsZkKfqgVsWdE();
					case ControllerType.Joystick:
						return this.sECLJOrMnPAjuIrUEWIoAJbgQouAb();
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.KCmTUTWCcwIiRIOwZelkuSsgFyGab();
					}
				}

				// Token: 0x0600135B RID: 4955 RVA: 0x00064890 File Offset: 0x00062A90
				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllButtons(ControllerType controllerType)
				{
					if (ReInput._id != this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA)
					{
						ReInput.CheckInitialized(this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return this.HMCEqgSPVwcwKLbOpQrSvCeLwNci();
					case ControllerType.Mouse:
						return this.VMxJQtnvyaHIiVnlhvTFmcrrGcAdA();
					case ControllerType.Joystick:
						return this.INRJWnsUIOdgsHUpAjxEpXVHejAT();
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.jeOtLylEwUAlUhquTZJoyzpPhNqF();
					}
				}

				// Token: 0x0600135C RID: 4956 RVA: 0x000648F8 File Offset: 0x00062AF8
				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllButtonsDown(ControllerType controllerType)
				{
					if (ReInput._id != this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA)
					{
						ReInput.CheckInitialized(this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return this.qiNiTuDrrafGSAfZpAToKqAEHKqL();
					case ControllerType.Mouse:
						return this.iuVddGIcCbCtoEFAEhAsqAIrDQvz();
					case ControllerType.Joystick:
						return this.sLWxoJqwSRqWZSyWhgRjWrgPdlSg();
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.YayRxjHbcEZICnjZbwKwDJMNvBco();
					}
				}

				// Token: 0x0600135D RID: 4957 RVA: 0x00064960 File Offset: 0x00062B60
				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllAxes(ControllerType controllerType)
				{
					if (ReInput._id != this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA)
					{
						ReInput.CheckInitialized(this.JRxlPnbkXhlPpKrNxTHoRCSWAgOFA);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Keyboard:
						return new List<ControllerPollingInfo>();
					case ControllerType.Mouse:
						return this.jsTWFHNSMlPDUxbsHBdWUhDZBpFGA();
					case ControllerType.Joystick:
						return this.jRdLyDTccVcobccsqNxAHLzyWnsE();
					default:
						if (controllerType != ControllerType.Custom)
						{
							throw new NotImplementedException();
						}
						return this.SsDaUfgtKeOXqTUyhOiOyQlFuFmm();
					}
				}

				// Token: 0x0600135E RID: 4958 RVA: 0x000649C8 File Offset: 0x00062BC8
				private ControllerPollingInfo yiHManzwHZApJXIKxGOnjkKDdhYz(int A_1)
				{
					if (A_1 < 0)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					Joystick joystick = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.gaDAGriDHrZfIMsSGiwEunPWgbeF(A_1);
					if (joystick == null)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					ControllerPollingInfo result = joystick.PollForFirstElement();
					if (result.success)
					{
						result.playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo;
					}
					return result;
				}

				// Token: 0x0600135F RID: 4959 RVA: 0x00064A20 File Offset: 0x00062C20
				private ControllerPollingInfo owOdOFZbMIRVCElTxGbghqBPBqmB(int A_1)
				{
					if (A_1 < 0)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					Joystick joystick = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.gaDAGriDHrZfIMsSGiwEunPWgbeF(A_1);
					if (joystick == null)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					ControllerPollingInfo result = joystick.PollForFirstElementDown();
					if (result.success)
					{
						result.playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo;
					}
					return result;
				}

				// Token: 0x06001360 RID: 4960 RVA: 0x00064A78 File Offset: 0x00062C78
				private ControllerPollingInfo ytqszYYTJkxdNuFlYajOKdqDbDanA(int A_1)
				{
					if (A_1 < 0)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					Joystick joystick = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.gaDAGriDHrZfIMsSGiwEunPWgbeF(A_1);
					if (joystick == null)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					ControllerPollingInfo result = joystick.PollForFirstButton();
					if (result.success)
					{
						result.playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo;
					}
					return result;
				}

				// Token: 0x06001361 RID: 4961 RVA: 0x00064AD0 File Offset: 0x00062CD0
				private ControllerPollingInfo mVGmrfynsrGBKkkaWKHUbFDdNAUdc(int A_1)
				{
					if (A_1 < 0)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					Joystick joystick = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.gaDAGriDHrZfIMsSGiwEunPWgbeF(A_1);
					if (joystick == null)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					ControllerPollingInfo result = joystick.PollForFirstButtonDown();
					if (result.success)
					{
						result.playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo;
					}
					return result;
				}

				// Token: 0x06001362 RID: 4962 RVA: 0x00064B28 File Offset: 0x00062D28
				private ControllerPollingInfo GanQFgecYnFovRdZgAQOgirvSZwTA(int A_1)
				{
					if (A_1 < 0)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					Joystick joystick = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.gaDAGriDHrZfIMsSGiwEunPWgbeF(A_1);
					if (joystick == null)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					ControllerPollingInfo result = joystick.PollForFirstAxis();
					if (result.success)
					{
						result.playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo;
					}
					return result;
				}

				// Token: 0x06001363 RID: 4963 RVA: 0x00010C03 File Offset: 0x0000EE03
				private IEnumerable<ControllerPollingInfo> lYVJCtdRYKQIzmGjLSLqJaHCatXEA(int A_1)
				{
					if (A_1 < 0)
					{
						yield break;
					}
					Joystick joystick = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.gaDAGriDHrZfIMsSGiwEunPWgbeF(A_1);
					if (joystick == null)
					{
						yield break;
					}
					foreach (ControllerPollingInfo controllerPollingInfo in joystick.PollForAllElements())
					{
						yield return new ControllerPollingInfo(controllerPollingInfo)
						{
							playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo
						};
					}
					IEnumerator<ControllerPollingInfo> enumerator = null;
					yield break;
					yield break;
				}

				// Token: 0x06001364 RID: 4964 RVA: 0x00010C1A File Offset: 0x0000EE1A
				private IEnumerable<ControllerPollingInfo> JBDhWOkkaQQDvUwUCCVErDLvcsAFA(int A_1)
				{
					if (A_1 < 0)
					{
						yield break;
					}
					Joystick joystick = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.gaDAGriDHrZfIMsSGiwEunPWgbeF(A_1);
					if (joystick == null)
					{
						yield break;
					}
					foreach (ControllerPollingInfo controllerPollingInfo in joystick.PollForAllElementsDown())
					{
						yield return new ControllerPollingInfo(controllerPollingInfo)
						{
							playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo
						};
					}
					IEnumerator<ControllerPollingInfo> enumerator = null;
					yield break;
					yield break;
				}

				// Token: 0x06001365 RID: 4965 RVA: 0x00010C31 File Offset: 0x0000EE31
				private IEnumerable<ControllerPollingInfo> QPUtvsiELIgNbWQFyxmAlrmHFQeM(int A_1)
				{
					if (A_1 < 0)
					{
						yield break;
					}
					Joystick joystick = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.gaDAGriDHrZfIMsSGiwEunPWgbeF(A_1);
					if (joystick == null)
					{
						yield break;
					}
					foreach (ControllerPollingInfo controllerPollingInfo in joystick.PollForAllButtons())
					{
						yield return new ControllerPollingInfo(controllerPollingInfo)
						{
							playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo
						};
					}
					IEnumerator<ControllerPollingInfo> enumerator = null;
					yield break;
					yield break;
				}

				// Token: 0x06001366 RID: 4966 RVA: 0x00010C48 File Offset: 0x0000EE48
				private IEnumerable<ControllerPollingInfo> bmgbDXJSITDqXcmBbSwHrRrVjDkPc(int A_1)
				{
					if (A_1 < 0)
					{
						yield break;
					}
					Joystick joystick = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.gaDAGriDHrZfIMsSGiwEunPWgbeF(A_1);
					if (joystick == null)
					{
						yield break;
					}
					foreach (ControllerPollingInfo controllerPollingInfo in joystick.PollForAllButtonsDown())
					{
						yield return new ControllerPollingInfo(controllerPollingInfo)
						{
							playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo
						};
					}
					IEnumerator<ControllerPollingInfo> enumerator = null;
					yield break;
					yield break;
				}

				// Token: 0x06001367 RID: 4967 RVA: 0x00010C5F File Offset: 0x0000EE5F
				private IEnumerable<ControllerPollingInfo> ZckquomERWIEvNtixHYllYAPuqYd(int A_1)
				{
					if (A_1 < 0)
					{
						yield break;
					}
					Joystick joystick = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.gaDAGriDHrZfIMsSGiwEunPWgbeF(A_1);
					if (joystick == null)
					{
						yield break;
					}
					foreach (ControllerPollingInfo controllerPollingInfo in joystick.PollForAllAxes())
					{
						yield return new ControllerPollingInfo(controllerPollingInfo)
						{
							playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo
						};
					}
					IEnumerator<ControllerPollingInfo> enumerator = null;
					yield break;
					yield break;
				}

				// Token: 0x06001368 RID: 4968 RVA: 0x00064B80 File Offset: 0x00062D80
				private ControllerPollingInfo oVrBbDGhwVSZPIcilycrqoBewHdFA()
				{
					IList<Joystick> list = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.NxlJdafVlRhoHuADzQEVEdFdHwPV;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							result.playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo;
							return result;
						}
					}
					return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
				}

				// Token: 0x06001369 RID: 4969 RVA: 0x00064BE0 File Offset: 0x00062DE0
				private ControllerPollingInfo TwbeTEfTNBGFnbolgaXmHmBBRCXcb()
				{
					IList<Joystick> list = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.NxlJdafVlRhoHuADzQEVEdFdHwPV;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							result.playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo;
							return result;
						}
					}
					return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
				}

				// Token: 0x0600136A RID: 4970 RVA: 0x00064C40 File Offset: 0x00062E40
				private ControllerPollingInfo kvAjxFkKOYJRFnHBwryATUcWSfoS()
				{
					IList<Joystick> list = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.NxlJdafVlRhoHuADzQEVEdFdHwPV;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							result.playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo;
							return result;
						}
					}
					return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
				}

				// Token: 0x0600136B RID: 4971 RVA: 0x00064CA0 File Offset: 0x00062EA0
				private ControllerPollingInfo RrEjHXibBEnwNVQJCCXnJweTQIUR()
				{
					IList<Joystick> list = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.NxlJdafVlRhoHuADzQEVEdFdHwPV;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							result.playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo;
							return result;
						}
					}
					return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
				}

				// Token: 0x0600136C RID: 4972 RVA: 0x00064D00 File Offset: 0x00062F00
				private ControllerPollingInfo RdVAUyIHWhUsytjPoIkBFpNckbOf()
				{
					IList<Joystick> list = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.NxlJdafVlRhoHuADzQEVEdFdHwPV;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							result.playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo;
							return result;
						}
					}
					return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
				}

				// Token: 0x0600136D RID: 4973 RVA: 0x00010C76 File Offset: 0x0000EE76
				private IEnumerable<ControllerPollingInfo> YorVxVDHWsWSADSjoQZvPhJTJer()
				{
					IList<Joystick> list = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.NxlJdafVlRhoHuADzQEVEdFdHwPV;
					int count = list.Count;
					int num;
					for (int i = 0; i < count; i = num + 1)
					{
						foreach (ControllerPollingInfo controllerPollingInfo in list[i].PollForAllElements())
						{
							yield return new ControllerPollingInfo(controllerPollingInfo)
							{
								playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo
							};
						}
						IEnumerator<ControllerPollingInfo> enumerator = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x0600136E RID: 4974 RVA: 0x00010C86 File Offset: 0x0000EE86
				private IEnumerable<ControllerPollingInfo> sECLJOrMnPAjuIrUEWIoAJbgQouAb()
				{
					IList<Joystick> list = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.NxlJdafVlRhoHuADzQEVEdFdHwPV;
					int count = list.Count;
					int num;
					for (int i = 0; i < count; i = num + 1)
					{
						foreach (ControllerPollingInfo controllerPollingInfo in list[i].PollForAllElementsDown())
						{
							yield return new ControllerPollingInfo(controllerPollingInfo)
							{
								playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo
							};
						}
						IEnumerator<ControllerPollingInfo> enumerator = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x0600136F RID: 4975 RVA: 0x00010C96 File Offset: 0x0000EE96
				private IEnumerable<ControllerPollingInfo> INRJWnsUIOdgsHUpAjxEpXVHejAT()
				{
					IList<Joystick> list = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.NxlJdafVlRhoHuADzQEVEdFdHwPV;
					int count = list.Count;
					int num;
					for (int i = 0; i < count; i = num + 1)
					{
						foreach (ControllerPollingInfo controllerPollingInfo in list[i].PollForAllButtons())
						{
							yield return new ControllerPollingInfo(controllerPollingInfo)
							{
								playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo
							};
						}
						IEnumerator<ControllerPollingInfo> enumerator = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x06001370 RID: 4976 RVA: 0x00010CA6 File Offset: 0x0000EEA6
				private IEnumerable<ControllerPollingInfo> sLWxoJqwSRqWZSyWhgRjWrgPdlSg()
				{
					IList<Joystick> list = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.NxlJdafVlRhoHuADzQEVEdFdHwPV;
					int count = list.Count;
					int num;
					for (int i = 0; i < count; i = num + 1)
					{
						foreach (ControllerPollingInfo controllerPollingInfo in list[i].PollForAllButtonsDown())
						{
							yield return new ControllerPollingInfo(controllerPollingInfo)
							{
								playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo
							};
						}
						IEnumerator<ControllerPollingInfo> enumerator = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x06001371 RID: 4977 RVA: 0x00010CB6 File Offset: 0x0000EEB6
				private IEnumerable<ControllerPollingInfo> jRdLyDTccVcobccsqNxAHLzyWnsE()
				{
					IList<Joystick> list = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.BcBAdMCyMCZFOVEAbrSfSqwjRZYO.NxlJdafVlRhoHuADzQEVEdFdHwPV;
					int count = list.Count;
					int num;
					for (int i = 0; i < count; i = num + 1)
					{
						foreach (ControllerPollingInfo controllerPollingInfo in list[i].PollForAllAxes())
						{
							yield return new ControllerPollingInfo(controllerPollingInfo)
							{
								playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo
							};
						}
						IEnumerator<ControllerPollingInfo> enumerator = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x06001372 RID: 4978 RVA: 0x00010CC6 File Offset: 0x0000EEC6
				private ControllerPollingInfo YyqHynGXEZuctllJNJuYBbpRdopY()
				{
					if (!this.EMrBmVBWSGWIQslUCxvXPZlRReTB.pfJEVdWSPRUAULafKDQwbutdUTgK)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					return this.EMrBmVBWSGWIQslUCxvXPZlRReTB.Keyboard.PollForFirstKey();
				}

				// Token: 0x06001373 RID: 4979 RVA: 0x00010CEB File Offset: 0x0000EEEB
				private ControllerPollingInfo izabOCEbHnWBQSFewBmvBoRWParYA()
				{
					if (!this.EMrBmVBWSGWIQslUCxvXPZlRReTB.pfJEVdWSPRUAULafKDQwbutdUTgK)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					return this.EMrBmVBWSGWIQslUCxvXPZlRReTB.Keyboard.PollForFirstKeyDown();
				}

				// Token: 0x06001374 RID: 4980 RVA: 0x00010D10 File Offset: 0x0000EF10
				private IEnumerable<ControllerPollingInfo> HMCEqgSPVwcwKLbOpQrSvCeLwNci()
				{
					if (!this.EMrBmVBWSGWIQslUCxvXPZlRReTB.pfJEVdWSPRUAULafKDQwbutdUTgK)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return this.EMrBmVBWSGWIQslUCxvXPZlRReTB.Keyboard.PollForAllKeys();
				}

				// Token: 0x06001375 RID: 4981 RVA: 0x00010D35 File Offset: 0x0000EF35
				private IEnumerable<ControllerPollingInfo> qiNiTuDrrafGSAfZpAToKqAEHKqL()
				{
					if (!this.EMrBmVBWSGWIQslUCxvXPZlRReTB.pfJEVdWSPRUAULafKDQwbutdUTgK)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return this.EMrBmVBWSGWIQslUCxvXPZlRReTB.Keyboard.PollForAllKeysDown();
				}

				// Token: 0x06001376 RID: 4982 RVA: 0x00010D5A File Offset: 0x0000EF5A
				private ControllerPollingInfo mOkFEoevEMkwXELzlSZlgYjDtathB()
				{
					if (!this.EMrBmVBWSGWIQslUCxvXPZlRReTB.XBolbQiDSdCaKCpMixItUgVeDfkAb)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					return this.EMrBmVBWSGWIQslUCxvXPZlRReTB.Mouse.PollForFirstElement();
				}

				// Token: 0x06001377 RID: 4983 RVA: 0x00010D7F File Offset: 0x0000EF7F
				private ControllerPollingInfo TjhkiMrKcbFioDpqhQIocmtpwvsCA()
				{
					if (!this.EMrBmVBWSGWIQslUCxvXPZlRReTB.XBolbQiDSdCaKCpMixItUgVeDfkAb)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					return this.EMrBmVBWSGWIQslUCxvXPZlRReTB.Mouse.PollForFirstElementDown();
				}

				// Token: 0x06001378 RID: 4984 RVA: 0x00010DA4 File Offset: 0x0000EFA4
				private ControllerPollingInfo VSpTaidDMCHSIDVfjElAWhkpvUCY()
				{
					if (!this.EMrBmVBWSGWIQslUCxvXPZlRReTB.XBolbQiDSdCaKCpMixItUgVeDfkAb)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					return this.EMrBmVBWSGWIQslUCxvXPZlRReTB.Mouse.PollForFirstButton();
				}

				// Token: 0x06001379 RID: 4985 RVA: 0x00010DC9 File Offset: 0x0000EFC9
				private ControllerPollingInfo KImHirENeZMDgdiJSAzWUmMfqvLP()
				{
					if (!this.EMrBmVBWSGWIQslUCxvXPZlRReTB.XBolbQiDSdCaKCpMixItUgVeDfkAb)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					return this.EMrBmVBWSGWIQslUCxvXPZlRReTB.Mouse.PollForFirstButtonDown();
				}

				// Token: 0x0600137A RID: 4986 RVA: 0x00010DEE File Offset: 0x0000EFEE
				private ControllerPollingInfo IRsVRWhPPeyTBJmlRjVNByZNuQMvA()
				{
					if (!this.EMrBmVBWSGWIQslUCxvXPZlRReTB.XBolbQiDSdCaKCpMixItUgVeDfkAb)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					return this.EMrBmVBWSGWIQslUCxvXPZlRReTB.Mouse.PollForFirstAxis();
				}

				// Token: 0x0600137B RID: 4987 RVA: 0x00010E13 File Offset: 0x0000F013
				private IEnumerable<ControllerPollingInfo> SHrNuRMVnCCeVSTpeTBjZMisvGCG()
				{
					if (!this.EMrBmVBWSGWIQslUCxvXPZlRReTB.XBolbQiDSdCaKCpMixItUgVeDfkAb)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return this.EMrBmVBWSGWIQslUCxvXPZlRReTB.Mouse.PollForAllElements();
				}

				// Token: 0x0600137C RID: 4988 RVA: 0x00010E38 File Offset: 0x0000F038
				private IEnumerable<ControllerPollingInfo> AlrhQpKDudJFHbKxsZkKfqgVsWdE()
				{
					if (!this.EMrBmVBWSGWIQslUCxvXPZlRReTB.XBolbQiDSdCaKCpMixItUgVeDfkAb)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return this.EMrBmVBWSGWIQslUCxvXPZlRReTB.Mouse.PollForAllElementsDown();
				}

				// Token: 0x0600137D RID: 4989 RVA: 0x00010E5D File Offset: 0x0000F05D
				private IEnumerable<ControllerPollingInfo> VMxJQtnvyaHIiVnlhvTFmcrrGcAdA()
				{
					if (!this.EMrBmVBWSGWIQslUCxvXPZlRReTB.XBolbQiDSdCaKCpMixItUgVeDfkAb)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return this.EMrBmVBWSGWIQslUCxvXPZlRReTB.Mouse.PollForAllButtons();
				}

				// Token: 0x0600137E RID: 4990 RVA: 0x00010E82 File Offset: 0x0000F082
				private IEnumerable<ControllerPollingInfo> iuVddGIcCbCtoEFAEhAsqAIrDQvz()
				{
					if (!this.EMrBmVBWSGWIQslUCxvXPZlRReTB.XBolbQiDSdCaKCpMixItUgVeDfkAb)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return this.EMrBmVBWSGWIQslUCxvXPZlRReTB.Mouse.PollForAllButtonsDown();
				}

				// Token: 0x0600137F RID: 4991 RVA: 0x00010EA7 File Offset: 0x0000F0A7
				private IEnumerable<ControllerPollingInfo> jsTWFHNSMlPDUxbsHBdWUhDZBpFGA()
				{
					if (!this.EMrBmVBWSGWIQslUCxvXPZlRReTB.XBolbQiDSdCaKCpMixItUgVeDfkAb)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return this.EMrBmVBWSGWIQslUCxvXPZlRReTB.Mouse.PollForAllAxes();
				}

				// Token: 0x06001380 RID: 4992 RVA: 0x00064D60 File Offset: 0x00062F60
				private ControllerPollingInfo SgYemhlNZbUkJUMtwfBksJPzfAxl(int A_1)
				{
					if (A_1 < 0)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					CustomController customController = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.iTsNyOKxlQOyyWXaASlipXGJRPTN.gaDAGriDHrZfIMsSGiwEunPWgbeF(A_1);
					if (customController == null)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					ControllerPollingInfo result = customController.PollForFirstElement();
					if (result.success)
					{
						result.playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo;
					}
					return result;
				}

				// Token: 0x06001381 RID: 4993 RVA: 0x00064DB8 File Offset: 0x00062FB8
				private ControllerPollingInfo AjDKzubivRcsmCquAeevxXiTcyRw(int A_1)
				{
					if (A_1 < 0)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					CustomController customController = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.iTsNyOKxlQOyyWXaASlipXGJRPTN.gaDAGriDHrZfIMsSGiwEunPWgbeF(A_1);
					if (customController == null)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					ControllerPollingInfo result = customController.PollForFirstElementDown();
					if (result.success)
					{
						result.playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo;
					}
					return result;
				}

				// Token: 0x06001382 RID: 4994 RVA: 0x00064E10 File Offset: 0x00063010
				private ControllerPollingInfo ufHqsaAAaCfoGCqxlwbnZBZvasxg(int A_1)
				{
					if (A_1 < 0)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					CustomController customController = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.iTsNyOKxlQOyyWXaASlipXGJRPTN.gaDAGriDHrZfIMsSGiwEunPWgbeF(A_1);
					if (customController == null)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					ControllerPollingInfo result = customController.PollForFirstButton();
					if (result.success)
					{
						result.playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo;
					}
					return result;
				}

				// Token: 0x06001383 RID: 4995 RVA: 0x00064E68 File Offset: 0x00063068
				private ControllerPollingInfo xcAVNjcDEVaHVchjuTQJPFvhiXfgb(int A_1)
				{
					if (A_1 < 0)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					CustomController customController = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.iTsNyOKxlQOyyWXaASlipXGJRPTN.gaDAGriDHrZfIMsSGiwEunPWgbeF(A_1);
					if (customController == null)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					ControllerPollingInfo result = customController.PollForFirstButtonDown();
					if (result.success)
					{
						result.playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo;
					}
					return result;
				}

				// Token: 0x06001384 RID: 4996 RVA: 0x00064EC0 File Offset: 0x000630C0
				private ControllerPollingInfo XiPHmttzLpDAbGfrmYGtwEImxktc(int A_1)
				{
					if (A_1 < 0)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					CustomController customController = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.iTsNyOKxlQOyyWXaASlipXGJRPTN.gaDAGriDHrZfIMsSGiwEunPWgbeF(A_1);
					if (customController == null)
					{
						return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
					}
					ControllerPollingInfo result = customController.PollForFirstAxis();
					if (result.success)
					{
						result.playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo;
					}
					return result;
				}

				// Token: 0x06001385 RID: 4997 RVA: 0x00010ECC File Offset: 0x0000F0CC
				private IEnumerable<ControllerPollingInfo> CAKWyMmQFwPcqETYGaPVfJCJaoDKA(int A_1)
				{
					if (A_1 < 0)
					{
						yield break;
					}
					CustomController customController = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.iTsNyOKxlQOyyWXaASlipXGJRPTN.gaDAGriDHrZfIMsSGiwEunPWgbeF(A_1);
					if (customController == null)
					{
						yield break;
					}
					foreach (ControllerPollingInfo controllerPollingInfo in customController.PollForAllElements())
					{
						yield return new ControllerPollingInfo(controllerPollingInfo)
						{
							playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo
						};
					}
					IEnumerator<ControllerPollingInfo> enumerator = null;
					yield break;
					yield break;
				}

				// Token: 0x06001386 RID: 4998 RVA: 0x00010EE3 File Offset: 0x0000F0E3
				private IEnumerable<ControllerPollingInfo> SbmAjSCCxUiFzdCsaOpdfYdgwgPgB(int A_1)
				{
					if (A_1 < 0)
					{
						yield break;
					}
					CustomController customController = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.iTsNyOKxlQOyyWXaASlipXGJRPTN.gaDAGriDHrZfIMsSGiwEunPWgbeF(A_1);
					if (customController == null)
					{
						yield break;
					}
					foreach (ControllerPollingInfo controllerPollingInfo in customController.PollForAllElementsDown())
					{
						yield return new ControllerPollingInfo(controllerPollingInfo)
						{
							playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo
						};
					}
					IEnumerator<ControllerPollingInfo> enumerator = null;
					yield break;
					yield break;
				}

				// Token: 0x06001387 RID: 4999 RVA: 0x00010EFA File Offset: 0x0000F0FA
				private IEnumerable<ControllerPollingInfo> VPdKqMUMVfBjsTNJGyhQOckpxmrE(int A_1)
				{
					if (A_1 < 0)
					{
						yield break;
					}
					CustomController customController = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.iTsNyOKxlQOyyWXaASlipXGJRPTN.gaDAGriDHrZfIMsSGiwEunPWgbeF(A_1);
					if (customController == null)
					{
						yield break;
					}
					foreach (ControllerPollingInfo controllerPollingInfo in customController.PollForAllButtons())
					{
						yield return new ControllerPollingInfo(controllerPollingInfo)
						{
							playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo
						};
					}
					IEnumerator<ControllerPollingInfo> enumerator = null;
					yield break;
					yield break;
				}

				// Token: 0x06001388 RID: 5000 RVA: 0x00010F11 File Offset: 0x0000F111
				private IEnumerable<ControllerPollingInfo> KhSYZJbsqKZiJFzAlEFxHuiOQChk(int A_1)
				{
					if (A_1 < 0)
					{
						yield break;
					}
					CustomController customController = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.iTsNyOKxlQOyyWXaASlipXGJRPTN.gaDAGriDHrZfIMsSGiwEunPWgbeF(A_1);
					if (customController == null)
					{
						yield break;
					}
					foreach (ControllerPollingInfo controllerPollingInfo in customController.PollForAllButtonsDown())
					{
						yield return new ControllerPollingInfo(controllerPollingInfo)
						{
							playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo
						};
					}
					IEnumerator<ControllerPollingInfo> enumerator = null;
					yield break;
					yield break;
				}

				// Token: 0x06001389 RID: 5001 RVA: 0x00010F28 File Offset: 0x0000F128
				private IEnumerable<ControllerPollingInfo> cjKyrglNlFhsHSgEsrEiHodOCrYL(int A_1)
				{
					if (A_1 < 0)
					{
						yield break;
					}
					CustomController customController = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.iTsNyOKxlQOyyWXaASlipXGJRPTN.gaDAGriDHrZfIMsSGiwEunPWgbeF(A_1);
					if (customController == null)
					{
						yield break;
					}
					foreach (ControllerPollingInfo controllerPollingInfo in customController.PollForAllAxes())
					{
						yield return new ControllerPollingInfo(controllerPollingInfo)
						{
							playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo
						};
					}
					IEnumerator<ControllerPollingInfo> enumerator = null;
					yield break;
					yield break;
				}

				// Token: 0x0600138A RID: 5002 RVA: 0x00064F18 File Offset: 0x00063118
				private ControllerPollingInfo AekEyXqcDfXCkYGMTNsYoIkWkfsn()
				{
					IList<CustomController> list = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.iTsNyOKxlQOyyWXaASlipXGJRPTN.NxlJdafVlRhoHuADzQEVEdFdHwPV;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							result.playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo;
							return result;
						}
					}
					return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
				}

				// Token: 0x0600138B RID: 5003 RVA: 0x00064F78 File Offset: 0x00063178
				private ControllerPollingInfo aMHjFxUllKHYUREviCKkdEiRhRoeA()
				{
					IList<CustomController> list = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.iTsNyOKxlQOyyWXaASlipXGJRPTN.NxlJdafVlRhoHuADzQEVEdFdHwPV;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							result.playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo;
							return result;
						}
					}
					return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
				}

				// Token: 0x0600138C RID: 5004 RVA: 0x00064FD8 File Offset: 0x000631D8
				private ControllerPollingInfo hEsZXtjoQGaVcQiXaAFosIeammVL()
				{
					IList<CustomController> list = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.iTsNyOKxlQOyyWXaASlipXGJRPTN.NxlJdafVlRhoHuADzQEVEdFdHwPV;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							result.playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo;
							return result;
						}
					}
					return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
				}

				// Token: 0x0600138D RID: 5005 RVA: 0x00065038 File Offset: 0x00063238
				private ControllerPollingInfo CcODhfMjQOCsBFUyCSVIFswjwsctA()
				{
					IList<CustomController> list = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.iTsNyOKxlQOyyWXaASlipXGJRPTN.NxlJdafVlRhoHuADzQEVEdFdHwPV;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							result.playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo;
							return result;
						}
					}
					return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
				}

				// Token: 0x0600138E RID: 5006 RVA: 0x00065098 File Offset: 0x00063298
				private ControllerPollingInfo HXKaUAAldtCaopirbGbqaIDijjmGc()
				{
					IList<CustomController> list = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.iTsNyOKxlQOyyWXaASlipXGJRPTN.NxlJdafVlRhoHuADzQEVEdFdHwPV;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							result.playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo;
							return result;
						}
					}
					return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
				}

				// Token: 0x0600138F RID: 5007 RVA: 0x00010F3F File Offset: 0x0000F13F
				private IEnumerable<ControllerPollingInfo> EsDvuTfkMTZzzYlNQynUSoBtpalB()
				{
					IList<CustomController> list = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.iTsNyOKxlQOyyWXaASlipXGJRPTN.NxlJdafVlRhoHuADzQEVEdFdHwPV;
					int count = list.Count;
					int num;
					for (int i = 0; i < count; i = num + 1)
					{
						foreach (ControllerPollingInfo controllerPollingInfo in list[i].PollForAllElements())
						{
							yield return new ControllerPollingInfo(controllerPollingInfo)
							{
								playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo
							};
						}
						IEnumerator<ControllerPollingInfo> enumerator = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x06001390 RID: 5008 RVA: 0x00010F4F File Offset: 0x0000F14F
				private IEnumerable<ControllerPollingInfo> KCmTUTWCcwIiRIOwZelkuSsgFyGab()
				{
					IList<CustomController> list = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.iTsNyOKxlQOyyWXaASlipXGJRPTN.NxlJdafVlRhoHuADzQEVEdFdHwPV;
					int count = list.Count;
					int num;
					for (int i = 0; i < count; i = num + 1)
					{
						foreach (ControllerPollingInfo controllerPollingInfo in list[i].PollForAllElementsDown())
						{
							yield return new ControllerPollingInfo(controllerPollingInfo)
							{
								playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo
							};
						}
						IEnumerator<ControllerPollingInfo> enumerator = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x06001391 RID: 5009 RVA: 0x00010F5F File Offset: 0x0000F15F
				private IEnumerable<ControllerPollingInfo> jeOtLylEwUAlUhquTZJoyzpPhNqF()
				{
					IList<CustomController> list = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.iTsNyOKxlQOyyWXaASlipXGJRPTN.NxlJdafVlRhoHuADzQEVEdFdHwPV;
					int count = list.Count;
					int num;
					for (int i = 0; i < count; i = num + 1)
					{
						foreach (ControllerPollingInfo controllerPollingInfo in list[i].PollForAllButtons())
						{
							yield return new ControllerPollingInfo(controllerPollingInfo)
							{
								playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo
							};
						}
						IEnumerator<ControllerPollingInfo> enumerator = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x06001392 RID: 5010 RVA: 0x00010F6F File Offset: 0x0000F16F
				private IEnumerable<ControllerPollingInfo> YayRxjHbcEZICnjZbwKwDJMNvBco()
				{
					IList<CustomController> list = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.iTsNyOKxlQOyyWXaASlipXGJRPTN.NxlJdafVlRhoHuADzQEVEdFdHwPV;
					int count = list.Count;
					int num;
					for (int i = 0; i < count; i = num + 1)
					{
						foreach (ControllerPollingInfo controllerPollingInfo in list[i].PollForAllButtonsDown())
						{
							yield return new ControllerPollingInfo(controllerPollingInfo)
							{
								playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo
							};
						}
						IEnumerator<ControllerPollingInfo> enumerator = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x06001393 RID: 5011 RVA: 0x00010F7F File Offset: 0x0000F17F
				private IEnumerable<ControllerPollingInfo> SsDaUfgtKeOXqTUyhOiOyQlFuFmm()
				{
					IList<CustomController> list = this.EMrBmVBWSGWIQslUCxvXPZlRReTB.iTsNyOKxlQOyyWXaASlipXGJRPTN.NxlJdafVlRhoHuADzQEVEdFdHwPV;
					int count = list.Count;
					int num;
					for (int i = 0; i < count; i = num + 1)
					{
						foreach (ControllerPollingInfo controllerPollingInfo in list[i].PollForAllAxes())
						{
							yield return new ControllerPollingInfo(controllerPollingInfo)
							{
								playerId = this.CchIzwRsJJJbdcuqXfvcVQrXKNyd.slhAWVVynuDdrqbdGKDoRVmsCDYo
							};
						}
						IEnumerator<ControllerPollingInfo> enumerator = null;
						num = i;
					}
					yield break;
					yield break;
				}

				// Token: 0x04000B19 RID: 2841
				private readonly Player CchIzwRsJJJbdcuqXfvcVQrXKNyd;

				// Token: 0x04000B1A RID: 2842
				private readonly Player.ControllerHelper EMrBmVBWSGWIQslUCxvXPZlRReTB;

				// Token: 0x04000B1B RID: 2843
				private readonly int JRxlPnbkXhlPpKrNxTHoRCSWAgOFA;
			}

			// Token: 0x020001A5 RID: 421
			[CompilerGenerated]
			[Serializable]
			private sealed class kbpuOSNIlWMgpPzYDoyzVfgfIkrx
			{
				// Token: 0x0600144A RID: 5194 RVA: 0x00011617 File Offset: 0x0000F817
				internal void kfxekgKmcClLZiaIpehZJvsiuKcpA(Exception A_1)
				{
					ReInput.HandleCallbackException("Player.ControllerHelper.ControllerAddedEvent", A_1);
				}

				// Token: 0x0600144B RID: 5195 RVA: 0x00011624 File Offset: 0x0000F824
				internal void egiBJKsiXvluFhszoPkPETZFDgPK(Exception A_1)
				{
					ReInput.HandleCallbackException("Player.ControllerHelper.ControllerRemovedEvent", A_1);
				}

				// Token: 0x04000BB2 RID: 2994
				public static readonly Player.ControllerHelper.kbpuOSNIlWMgpPzYDoyzVfgfIkrx <>9 = new Player.ControllerHelper.kbpuOSNIlWMgpPzYDoyzVfgfIkrx();

				// Token: 0x04000BB3 RID: 2995
				public static Action<Exception> <>9__23_0;

				// Token: 0x04000BB4 RID: 2996
				public static Action<Exception> <>9__23_1;
			}
		}
	}
}
