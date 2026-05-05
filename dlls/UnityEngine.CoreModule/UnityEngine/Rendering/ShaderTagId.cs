using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000471 RID: 1137
	public struct ShaderTagId : IEquatable<ShaderTagId>
	{
		// Token: 0x060026A8 RID: 9896 RVA: 0x00042452 File Offset: 0x00040652
		public ShaderTagId(string name)
		{
			this.m_Id = Shader.TagToID(name);
		}

		// Token: 0x1700070D RID: 1805
		// (get) Token: 0x060026A9 RID: 9897 RVA: 0x00042464 File Offset: 0x00040664
		// (set) Token: 0x060026AA RID: 9898 RVA: 0x0004247C File Offset: 0x0004067C
		internal int id
		{
			get
			{
				return this.m_Id;
			}
			set
			{
				this.m_Id = value;
			}
		}

		// Token: 0x1700070E RID: 1806
		// (get) Token: 0x060026AB RID: 9899 RVA: 0x00042488 File Offset: 0x00040688
		public string name
		{
			get
			{
				return Shader.IDToTag(this.id);
			}
		}

		// Token: 0x060026AC RID: 9900 RVA: 0x000424A8 File Offset: 0x000406A8
		public override bool Equals(object obj)
		{
			return obj is ShaderTagId && this.Equals((ShaderTagId)obj);
		}

		// Token: 0x060026AD RID: 9901 RVA: 0x000424D4 File Offset: 0x000406D4
		public bool Equals(ShaderTagId other)
		{
			return this.m_Id == other.m_Id;
		}

		// Token: 0x060026AE RID: 9902 RVA: 0x000424F4 File Offset: 0x000406F4
		public override int GetHashCode()
		{
			int num = 2079669542;
			return num * -1521134295 + this.m_Id.GetHashCode();
		}

		// Token: 0x060026AF RID: 9903 RVA: 0x00042524 File Offset: 0x00040724
		public static bool operator ==(ShaderTagId tag1, ShaderTagId tag2)
		{
			return tag1.Equals(tag2);
		}

		// Token: 0x060026B0 RID: 9904 RVA: 0x00042540 File Offset: 0x00040740
		public static bool operator !=(ShaderTagId tag1, ShaderTagId tag2)
		{
			return !(tag1 == tag2);
		}

		// Token: 0x060026B1 RID: 9905 RVA: 0x0004255C File Offset: 0x0004075C
		public static explicit operator ShaderTagId(string name)
		{
			return new ShaderTagId(name);
		}

		// Token: 0x060026B2 RID: 9906 RVA: 0x00042574 File Offset: 0x00040774
		public static explicit operator string(ShaderTagId tagId)
		{
			return tagId.name;
		}

		// Token: 0x04000E91 RID: 3729
		public static readonly ShaderTagId none;

		// Token: 0x04000E92 RID: 3730
		private int m_Id;
	}
}
