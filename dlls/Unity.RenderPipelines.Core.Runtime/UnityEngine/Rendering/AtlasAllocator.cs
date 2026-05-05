using System;

namespace UnityEngine.Rendering
{
	// Token: 0x020000BF RID: 191
	internal class AtlasAllocator
	{
		// Token: 0x060005D8 RID: 1496 RVA: 0x0001DA10 File Offset: 0x0001BC10
		public AtlasAllocator(int width, int height, bool potPadding)
		{
			this.m_Root = new AtlasAllocator.AtlasNode();
			this.m_Root.m_Rect.Set((float)width, (float)height, 0f, 0f);
			this.m_Width = width;
			this.m_Height = height;
			this.powerOfTwoPadding = potPadding;
			this.m_NodePool = new ObjectPool<AtlasAllocator.AtlasNode>(delegate(AtlasAllocator.AtlasNode _)
			{
			}, delegate(AtlasAllocator.AtlasNode _)
			{
			}, true);
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x0001DAAC File Offset: 0x0001BCAC
		public bool Allocate(ref Vector4 result, int width, int height)
		{
			AtlasAllocator.AtlasNode atlasNode = this.m_Root.Allocate(ref this.m_NodePool, width, height, this.powerOfTwoPadding);
			if (atlasNode != null)
			{
				result = atlasNode.m_Rect;
				return true;
			}
			result = Vector4.zero;
			return false;
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x0001DAF0 File Offset: 0x0001BCF0
		public void Reset()
		{
			this.m_Root.Release(ref this.m_NodePool);
			this.m_Root.m_Rect.Set((float)this.m_Width, (float)this.m_Height, 0f, 0f);
		}

		// Token: 0x04000428 RID: 1064
		private AtlasAllocator.AtlasNode m_Root;

		// Token: 0x04000429 RID: 1065
		private int m_Width;

		// Token: 0x0400042A RID: 1066
		private int m_Height;

		// Token: 0x0400042B RID: 1067
		private bool powerOfTwoPadding;

		// Token: 0x0400042C RID: 1068
		private ObjectPool<AtlasAllocator.AtlasNode> m_NodePool;

		// Token: 0x020001C2 RID: 450
		private class AtlasNode
		{
			// Token: 0x06000B3E RID: 2878 RVA: 0x0002EF34 File Offset: 0x0002D134
			public AtlasAllocator.AtlasNode Allocate(ref ObjectPool<AtlasAllocator.AtlasNode> pool, int width, int height, bool powerOfTwoPadding)
			{
				if (this.m_RightChild != null)
				{
					AtlasAllocator.AtlasNode atlasNode = this.m_RightChild.Allocate(ref pool, width, height, powerOfTwoPadding);
					if (atlasNode == null)
					{
						atlasNode = this.m_BottomChild.Allocate(ref pool, width, height, powerOfTwoPadding);
					}
					return atlasNode;
				}
				int num = 0;
				int num2 = 0;
				if (powerOfTwoPadding)
				{
					num = (int)this.m_Rect.x % width;
					num2 = (int)this.m_Rect.y % height;
				}
				if ((float)width <= this.m_Rect.x - (float)num && (float)height <= this.m_Rect.y - (float)num2)
				{
					this.m_RightChild = pool.Get();
					this.m_BottomChild = pool.Get();
					this.m_Rect.z = this.m_Rect.z + (float)num;
					this.m_Rect.w = this.m_Rect.w + (float)num2;
					this.m_Rect.x = this.m_Rect.x - (float)num;
					this.m_Rect.y = this.m_Rect.y - (float)num2;
					if (width > height)
					{
						this.m_RightChild.m_Rect.z = this.m_Rect.z + (float)width;
						this.m_RightChild.m_Rect.w = this.m_Rect.w;
						this.m_RightChild.m_Rect.x = this.m_Rect.x - (float)width;
						this.m_RightChild.m_Rect.y = (float)height;
						this.m_BottomChild.m_Rect.z = this.m_Rect.z;
						this.m_BottomChild.m_Rect.w = this.m_Rect.w + (float)height;
						this.m_BottomChild.m_Rect.x = this.m_Rect.x;
						this.m_BottomChild.m_Rect.y = this.m_Rect.y - (float)height;
					}
					else
					{
						this.m_RightChild.m_Rect.z = this.m_Rect.z + (float)width;
						this.m_RightChild.m_Rect.w = this.m_Rect.w;
						this.m_RightChild.m_Rect.x = this.m_Rect.x - (float)width;
						this.m_RightChild.m_Rect.y = this.m_Rect.y;
						this.m_BottomChild.m_Rect.z = this.m_Rect.z;
						this.m_BottomChild.m_Rect.w = this.m_Rect.w + (float)height;
						this.m_BottomChild.m_Rect.x = (float)width;
						this.m_BottomChild.m_Rect.y = this.m_Rect.y - (float)height;
					}
					this.m_Rect.x = (float)width;
					this.m_Rect.y = (float)height;
					return this;
				}
				return null;
			}

			// Token: 0x06000B3F RID: 2879 RVA: 0x0002F200 File Offset: 0x0002D400
			public void Release(ref ObjectPool<AtlasAllocator.AtlasNode> pool)
			{
				if (this.m_RightChild != null)
				{
					this.m_RightChild.Release(ref pool);
					this.m_BottomChild.Release(ref pool);
					pool.Release(this.m_RightChild);
					pool.Release(this.m_BottomChild);
				}
				this.m_RightChild = null;
				this.m_BottomChild = null;
				this.m_Rect = Vector4.zero;
			}

			// Token: 0x04000748 RID: 1864
			public AtlasAllocator.AtlasNode m_RightChild;

			// Token: 0x04000749 RID: 1865
			public AtlasAllocator.AtlasNode m_BottomChild;

			// Token: 0x0400074A RID: 1866
			public Vector4 m_Rect = new Vector4(0f, 0f, 0f, 0f);
		}
	}
}
