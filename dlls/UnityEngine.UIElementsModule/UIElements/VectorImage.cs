using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020003ED RID: 1005
	[Serializable]
	public class VectorImage : ScriptableObject
	{
		// Token: 0x1700079E RID: 1950
		// (get) Token: 0x060020B8 RID: 8376 RVA: 0x0007BE25 File Offset: 0x0007A025
		public float width
		{
			get
			{
				return this.size.x;
			}
		}

		// Token: 0x1700079F RID: 1951
		// (get) Token: 0x060020B9 RID: 8377 RVA: 0x0007BE32 File Offset: 0x0007A032
		public float height
		{
			get
			{
				return this.size.y;
			}
		}

		// Token: 0x04000D9B RID: 3483
		[SerializeField]
		internal int version = 0;

		// Token: 0x04000D9C RID: 3484
		[SerializeField]
		internal Texture2D atlas = null;

		// Token: 0x04000D9D RID: 3485
		[SerializeField]
		internal VectorImageVertex[] vertices = null;

		// Token: 0x04000D9E RID: 3486
		[SerializeField]
		internal ushort[] indices = null;

		// Token: 0x04000D9F RID: 3487
		[SerializeField]
		internal GradientSettings[] settings = null;

		// Token: 0x04000DA0 RID: 3488
		[SerializeField]
		internal Vector2 size = Vector2.zero;
	}
}
