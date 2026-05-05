using System;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.U2D
{
	// Token: 0x020002B3 RID: 691
	[MovedFrom("UnityEngine.Experimental.U2D")]
	[RequiredByNativeCode]
	[NativeType(CodegenOptions.Custom, "ScriptingSpriteBone")]
	[NativeHeader("Runtime/2D/Common/SpriteDataAccess.h")]
	[NativeHeader("Runtime/2D/Common/SpriteDataMarshalling.h")]
	[Serializable]
	public struct SpriteBone
	{
		// Token: 0x170005D0 RID: 1488
		// (get) Token: 0x06001D69 RID: 7529 RVA: 0x00030870 File Offset: 0x0002EA70
		// (set) Token: 0x06001D6A RID: 7530 RVA: 0x00030888 File Offset: 0x0002EA88
		public string name
		{
			get
			{
				return this.m_Name;
			}
			set
			{
				this.m_Name = value;
			}
		}

		// Token: 0x170005D1 RID: 1489
		// (get) Token: 0x06001D6B RID: 7531 RVA: 0x00030894 File Offset: 0x0002EA94
		// (set) Token: 0x06001D6C RID: 7532 RVA: 0x000308AC File Offset: 0x0002EAAC
		public string guid
		{
			get
			{
				return this.m_Guid;
			}
			set
			{
				this.m_Guid = value;
			}
		}

		// Token: 0x170005D2 RID: 1490
		// (get) Token: 0x06001D6D RID: 7533 RVA: 0x000308B8 File Offset: 0x0002EAB8
		// (set) Token: 0x06001D6E RID: 7534 RVA: 0x000308D0 File Offset: 0x0002EAD0
		public Vector3 position
		{
			get
			{
				return this.m_Position;
			}
			set
			{
				this.m_Position = value;
			}
		}

		// Token: 0x170005D3 RID: 1491
		// (get) Token: 0x06001D6F RID: 7535 RVA: 0x000308DC File Offset: 0x0002EADC
		// (set) Token: 0x06001D70 RID: 7536 RVA: 0x000308F4 File Offset: 0x0002EAF4
		public Quaternion rotation
		{
			get
			{
				return this.m_Rotation;
			}
			set
			{
				this.m_Rotation = value;
			}
		}

		// Token: 0x170005D4 RID: 1492
		// (get) Token: 0x06001D71 RID: 7537 RVA: 0x00030900 File Offset: 0x0002EB00
		// (set) Token: 0x06001D72 RID: 7538 RVA: 0x00030918 File Offset: 0x0002EB18
		public float length
		{
			get
			{
				return this.m_Length;
			}
			set
			{
				this.m_Length = value;
			}
		}

		// Token: 0x170005D5 RID: 1493
		// (get) Token: 0x06001D73 RID: 7539 RVA: 0x00030924 File Offset: 0x0002EB24
		// (set) Token: 0x06001D74 RID: 7540 RVA: 0x0003093C File Offset: 0x0002EB3C
		public int parentId
		{
			get
			{
				return this.m_ParentId;
			}
			set
			{
				this.m_ParentId = value;
			}
		}

		// Token: 0x170005D6 RID: 1494
		// (get) Token: 0x06001D75 RID: 7541 RVA: 0x00030948 File Offset: 0x0002EB48
		// (set) Token: 0x06001D76 RID: 7542 RVA: 0x00030960 File Offset: 0x0002EB60
		public Color32 color
		{
			get
			{
				return this.m_Color;
			}
			set
			{
				this.m_Color = value;
			}
		}

		// Token: 0x040009C9 RID: 2505
		[NativeName("name")]
		[SerializeField]
		private string m_Name;

		// Token: 0x040009CA RID: 2506
		[SerializeField]
		[NativeName("guid")]
		private string m_Guid;

		// Token: 0x040009CB RID: 2507
		[NativeName("position")]
		[SerializeField]
		private Vector3 m_Position;

		// Token: 0x040009CC RID: 2508
		[SerializeField]
		[NativeName("rotation")]
		private Quaternion m_Rotation;

		// Token: 0x040009CD RID: 2509
		[NativeName("length")]
		[SerializeField]
		private float m_Length;

		// Token: 0x040009CE RID: 2510
		[NativeName("parentId")]
		[SerializeField]
		private int m_ParentId;

		// Token: 0x040009CF RID: 2511
		[NativeName("color")]
		[SerializeField]
		private Color32 m_Color;
	}
}
