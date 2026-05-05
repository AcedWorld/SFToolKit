using System;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using UnityEngine;

namespace Rewired.ComponentControls.Data
{
	// Token: 0x02000429 RID: 1065
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[Serializable]
	public sealed class CustomControllerSelector
	{
		// Token: 0x17000A1D RID: 2589
		// (get) Token: 0x06002ACF RID: 10959 RVA: 0x00020DEC File Offset: 0x0001EFEC
		// (set) Token: 0x06002AD0 RID: 10960 RVA: 0x00020DF4 File Offset: 0x0001EFF4
		public bool findUsingSourceId
		{
			get
			{
				return this._findUsingSourceId;
			}
			set
			{
				if (this._findUsingSourceId == value)
				{
					return;
				}
				this._findUsingSourceId = value;
				this.ZtJKJtxROsbILVhdQBTMzFQSlQqM();
			}
		}

		// Token: 0x17000A1E RID: 2590
		// (get) Token: 0x06002AD1 RID: 10961 RVA: 0x00020E0D File Offset: 0x0001F00D
		// (set) Token: 0x06002AD2 RID: 10962 RVA: 0x00020E15 File Offset: 0x0001F015
		public int sourceId
		{
			get
			{
				return this._sourceId;
			}
			set
			{
				value = MathTools.Max(0, value);
				if (this._sourceId == value)
				{
					return;
				}
				this._sourceId = value;
				this.ZtJKJtxROsbILVhdQBTMzFQSlQqM();
			}
		}

		// Token: 0x17000A1F RID: 2591
		// (get) Token: 0x06002AD3 RID: 10963 RVA: 0x00020E37 File Offset: 0x0001F037
		// (set) Token: 0x06002AD4 RID: 10964 RVA: 0x00020E3F File Offset: 0x0001F03F
		public bool findUsingTag
		{
			get
			{
				return this._findUsingTag;
			}
			set
			{
				if (this._findUsingTag == value)
				{
					return;
				}
				this._findUsingTag = value;
				this.ZtJKJtxROsbILVhdQBTMzFQSlQqM();
			}
		}

		// Token: 0x17000A20 RID: 2592
		// (get) Token: 0x06002AD5 RID: 10965 RVA: 0x00020E58 File Offset: 0x0001F058
		// (set) Token: 0x06002AD6 RID: 10966 RVA: 0x00020E60 File Offset: 0x0001F060
		public string tag
		{
			get
			{
				return this._tag;
			}
			set
			{
				if (this._tag == value)
				{
					return;
				}
				this._tag = value;
				this.ZtJKJtxROsbILVhdQBTMzFQSlQqM();
			}
		}

		// Token: 0x17000A21 RID: 2593
		// (get) Token: 0x06002AD7 RID: 10967 RVA: 0x00020E7E File Offset: 0x0001F07E
		// (set) Token: 0x06002AD8 RID: 10968 RVA: 0x00020E86 File Offset: 0x0001F086
		public bool findInPlayer
		{
			get
			{
				return this._findInPlayer;
			}
			set
			{
				if (this._findInPlayer == value)
				{
					return;
				}
				this._findInPlayer = value;
				this.ZtJKJtxROsbILVhdQBTMzFQSlQqM();
			}
		}

		// Token: 0x17000A22 RID: 2594
		// (get) Token: 0x06002AD9 RID: 10969 RVA: 0x00020E9F File Offset: 0x0001F09F
		// (set) Token: 0x06002ADA RID: 10970 RVA: 0x00020EA7 File Offset: 0x0001F0A7
		public int playerId
		{
			get
			{
				return this._playerId;
			}
			set
			{
				if (this._playerId == value)
				{
					return;
				}
				this._playerId = value;
				this.ZtJKJtxROsbILVhdQBTMzFQSlQqM();
			}
		}

		// Token: 0x06002ADB RID: 10971 RVA: 0x0009BAE4 File Offset: 0x00099CE4
		internal CustomController GetCustomController()
		{
			if (!ReInput.isReady)
			{
				return null;
			}
			if (this.findInPlayer && ReInput.players.GetPlayer(this.playerId) == null)
			{
				Logger.LogError("Invalid playerId " + this.playerId.ToString());
				return null;
			}
			for (int i = 0; i < ReInput.controllers.customControllerCount; i++)
			{
				CustomController customController = ReInput.controllers.CustomControllers[i];
				if ((!this.findUsingSourceId || customController.sourceControllerId == this.sourceId) && (!this.findUsingTag || !(customController.tag != this.tag)) && (!this.findInPlayer || ReInput.controllers.IsControllerAssignedToPlayer(customController.type, customController.id, this.playerId)))
				{
					return customController;
				}
			}
			return null;
		}

		// Token: 0x06002ADC RID: 10972 RVA: 0x00002FF9 File Offset: 0x000011F9
		private void ZtJKJtxROsbILVhdQBTMzFQSlQqM()
		{
		}

		// Token: 0x04001890 RID: 6288
		[Tooltip("If true, the Custom Controller will be searched for by its source controller id. This can be used with Find in Player and/or Find Using Tag to further refine the search parameters.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _findUsingSourceId = true;

		// Token: 0x04001891 RID: 6289
		[Tooltip("The source id of the Custom Controller. This is used to find the Custom Controller if Find Using Source Id is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0, 2147483647)]
		private int _sourceId;

		// Token: 0x04001892 RID: 6290
		[Tooltip("If true, the Custom Controller will be found using the tag specified here. This can be used with Find in Player and/or Find Using Source Id to further refine the search parameters.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _findUsingTag;

		// Token: 0x04001893 RID: 6291
		[Tooltip("The tag on the Custom Controller you wish to use. This is used to find the Custom Controller.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _tag;

		// Token: 0x04001894 RID: 6292
		[Tooltip("If true, the Custom Controller will be searched for in the Player specified in the Player Id field. This can be used with Find Using Source Id and/or Find Using Tag to further refine the search parameters.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _findInPlayer;

		// Token: 0x04001895 RID: 6293
		[Tooltip("The Player Id of the Player that owns the Custom Controller.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _playerId;
	}
}
