using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001CA RID: 458
	internal class Atlas3DAllocatorDynamic
	{
		// Token: 0x06000E3C RID: 3644 RVA: 0x00071678 File Offset: 0x0006F878
		public Atlas3DAllocatorDynamic(int width, int height, int depth, int capacityAllocations)
		{
			int num = capacityAllocations * 2;
			this.m_Pool = new Atlas3DAllocatorDynamic.Atlas3DNodePool((short)num);
			this.m_NodeFromID = new Dictionary<int, short>(capacityAllocations);
			short parent = -1;
			this.m_Root = this.m_Pool.Atlas3DNodeCreate(parent);
			this.m_Pool.m_Nodes[(int)this.m_Root].m_RectSize = new Vector3((float)width, (float)height, (float)depth);
			this.m_Pool.m_Nodes[(int)this.m_Root].m_RectOffset = Vector3.zero;
			this.m_Width = width;
			this.m_Height = height;
			this.m_Depth = depth;
		}

		// Token: 0x06000E3D RID: 3645 RVA: 0x0007171C File Offset: 0x0006F91C
		public bool Allocate(out Vector3 resultSize, out Vector3 resultOffset, int key, int width, int height, int depth)
		{
			short num = this.m_Pool.m_Nodes[(int)this.m_Root].Allocate(this.m_Pool, width, height, depth);
			if (num >= 0)
			{
				resultSize = this.m_Pool.m_Nodes[(int)num].m_RectSize;
				resultOffset = this.m_Pool.m_Nodes[(int)num].m_RectOffset;
				this.m_NodeFromID.Add(key, num);
				return true;
			}
			resultSize = Vector3.zero;
			resultOffset = Vector3.zero;
			return false;
		}

		// Token: 0x06000E3E RID: 3646 RVA: 0x000717B4 File Offset: 0x0006F9B4
		public void Release(int key)
		{
			short num;
			if (this.m_NodeFromID.TryGetValue(key, out num))
			{
				this.m_Pool.m_Nodes[(int)num].ReleaseAndMerge(this.m_Pool);
				this.m_NodeFromID.Remove(key);
				return;
			}
		}

		// Token: 0x06000E3F RID: 3647 RVA: 0x000717FC File Offset: 0x0006F9FC
		public void Release()
		{
			this.m_Pool.Clear();
			this.m_Root = this.m_Pool.Atlas3DNodeCreate(-1);
			this.m_Pool.m_Nodes[(int)this.m_Root].m_RectSize = new Vector3((float)this.m_Width, (float)this.m_Height, (float)this.m_Depth);
			this.m_Pool.m_Nodes[(int)this.m_Root].m_RectOffset = Vector3.zero;
			this.m_NodeFromID.Clear();
		}

		// Token: 0x06000E40 RID: 3648 RVA: 0x00071888 File Offset: 0x0006FA88
		public string DebugStringFromRoot(int depthMax = -1)
		{
			string result = "";
			this.DebugStringFromNode(ref result, this.m_Root, 0, depthMax);
			return result;
		}

		// Token: 0x06000E41 RID: 3649 RVA: 0x000718AC File Offset: 0x0006FAAC
		private void DebugStringFromNode(ref string res, short n, int depthCurrent = 0, int depthMax = -1)
		{
			res = string.Concat(new string[]
			{
				res,
				"{[",
				depthCurrent.ToString(),
				"], isOccupied = ",
				this.m_Pool.m_Nodes[(int)n].IsOccupied() ? "true" : "false",
				", self = ",
				this.m_Pool.m_Nodes[(int)n].m_Self.ToString(),
				", ",
				this.m_Pool.m_Nodes[(int)n].m_RectSize.x.ToString(),
				",",
				this.m_Pool.m_Nodes[(int)n].m_RectSize.y.ToString(),
				", ",
				this.m_Pool.m_Nodes[(int)n].m_RectSize.z.ToString(),
				", ",
				this.m_Pool.m_Nodes[(int)n].m_RectOffset.x.ToString(),
				", ",
				this.m_Pool.m_Nodes[(int)n].m_RectOffset.y.ToString(),
				", ",
				this.m_Pool.m_Nodes[(int)n].m_RectOffset.z.ToString(),
				"}\n"
			});
			if (depthMax == -1 || depthCurrent < depthMax)
			{
				if (this.m_Pool.m_Nodes[(int)n].m_LeftChild >= 0)
				{
					this.DebugStringFromNode(ref res, this.m_Pool.m_Nodes[(int)n].m_LeftChild, depthCurrent + 1, depthMax);
				}
				if (this.m_Pool.m_Nodes[(int)n].m_RightChild >= 0)
				{
					this.DebugStringFromNode(ref res, this.m_Pool.m_Nodes[(int)n].m_RightChild, depthCurrent + 1, depthMax);
				}
			}
		}

		// Token: 0x040015CE RID: 5582
		private int m_Width;

		// Token: 0x040015CF RID: 5583
		private int m_Height;

		// Token: 0x040015D0 RID: 5584
		private int m_Depth;

		// Token: 0x040015D1 RID: 5585
		private Atlas3DAllocatorDynamic.Atlas3DNodePool m_Pool;

		// Token: 0x040015D2 RID: 5586
		private short m_Root;

		// Token: 0x040015D3 RID: 5587
		private Dictionary<int, short> m_NodeFromID;

		// Token: 0x0200040E RID: 1038
		private class Atlas3DNodePool
		{
			// Token: 0x060013F8 RID: 5112 RVA: 0x0009722F File Offset: 0x0009542F
			public Atlas3DNodePool(short capacity)
			{
				this.m_Nodes = new Atlas3DAllocatorDynamic.Atlas3DNode[(int)capacity];
				this.m_Next = 0;
				this.m_FreelistHead = -1;
			}

			// Token: 0x060013F9 RID: 5113 RVA: 0x00097251 File Offset: 0x00095451
			public void Dispose()
			{
				this.Clear();
				this.m_Nodes = null;
			}

			// Token: 0x060013FA RID: 5114 RVA: 0x00097260 File Offset: 0x00095460
			public void Clear()
			{
				this.m_Next = 0;
				this.m_FreelistHead = -1;
			}

			// Token: 0x060013FB RID: 5115 RVA: 0x00097270 File Offset: 0x00095470
			public short Atlas3DNodeCreate(short parent)
			{
				if (this.m_FreelistHead != -1)
				{
					short freelistNext = this.m_Nodes[(int)this.m_FreelistHead].m_FreelistNext;
					this.m_Nodes[(int)this.m_FreelistHead] = new Atlas3DAllocatorDynamic.Atlas3DNode(this.m_FreelistHead, parent);
					short freelistHead = this.m_FreelistHead;
					this.m_FreelistHead = freelistNext;
					return freelistHead;
				}
				this.m_Nodes[(int)this.m_Next] = new Atlas3DAllocatorDynamic.Atlas3DNode(this.m_Next, parent);
				short next = this.m_Next;
				this.m_Next = next + 1;
				return next;
			}

			// Token: 0x060013FC RID: 5116 RVA: 0x000972F7 File Offset: 0x000954F7
			public void Atlas3DNodeFree(short index)
			{
				this.m_Nodes[(int)index].m_FreelistNext = this.m_FreelistHead;
				this.m_FreelistHead = index;
			}

			// Token: 0x040028DE RID: 10462
			public Atlas3DAllocatorDynamic.Atlas3DNode[] m_Nodes;

			// Token: 0x040028DF RID: 10463
			private short m_Next;

			// Token: 0x040028E0 RID: 10464
			private short m_FreelistHead;
		}

		// Token: 0x0200040F RID: 1039
		private struct Atlas3DNode
		{
			// Token: 0x060013FD RID: 5117 RVA: 0x00097318 File Offset: 0x00095518
			public Atlas3DNode(short self, short parent)
			{
				this.m_Self = self;
				this.m_Parent = parent;
				this.m_LeftChild = -1;
				this.m_RightChild = -1;
				this.m_Flags = 0;
				this.m_FreelistNext = -1;
				this.m_RectSize = Vector3.zero;
				this.m_RectOffset = Vector3.zero;
			}

			// Token: 0x060013FE RID: 5118 RVA: 0x00097365 File Offset: 0x00095565
			public bool IsOccupied()
			{
				return (this.m_Flags & 1) > 0;
			}

			// Token: 0x060013FF RID: 5119 RVA: 0x00097374 File Offset: 0x00095574
			public void SetIsOccupied()
			{
				ushort num = 1;
				this.m_Flags |= num;
			}

			// Token: 0x06001400 RID: 5120 RVA: 0x00097394 File Offset: 0x00095594
			public void ClearIsOccupied()
			{
				ushort num = 1;
				this.m_Flags &= ~num;
			}

			// Token: 0x06001401 RID: 5121 RVA: 0x000973B4 File Offset: 0x000955B4
			public bool IsLeafNode()
			{
				return this.m_LeftChild == -1;
			}

			// Token: 0x06001402 RID: 5122 RVA: 0x000973C0 File Offset: 0x000955C0
			public short Allocate(Atlas3DAllocatorDynamic.Atlas3DNodePool pool, int width, int height, int depth)
			{
				if (Mathf.Min(Mathf.Min(width, height), depth) < 1)
				{
					return -1;
				}
				if (!this.IsLeafNode())
				{
					short num = pool.m_Nodes[(int)this.m_LeftChild].Allocate(pool, width, height, depth);
					if (num == -1)
					{
						num = pool.m_Nodes[(int)this.m_RightChild].Allocate(pool, width, height, depth);
					}
					return num;
				}
				if (this.IsOccupied())
				{
					return -1;
				}
				if ((float)width > this.m_RectSize.x || (float)height > this.m_RectSize.y || (float)depth > this.m_RectSize.z)
				{
					return -1;
				}
				this.m_LeftChild = pool.Atlas3DNodeCreate(this.m_Self);
				this.m_RightChild = pool.Atlas3DNodeCreate(this.m_Self);
				float num2 = this.m_RectSize.x - (float)width;
				float num3 = this.m_RectSize.y - (float)height;
				float num4 = this.m_RectSize.z - (float)depth;
				if (num2 >= num3 && num2 >= num4)
				{
					pool.m_Nodes[(int)this.m_LeftChild].m_RectSize = new Vector3((float)width, this.m_RectSize.y, this.m_RectSize.z);
					pool.m_Nodes[(int)this.m_LeftChild].m_RectOffset = this.m_RectOffset;
					pool.m_Nodes[(int)this.m_RightChild].m_RectSize = new Vector3(num2, this.m_RectSize.y, this.m_RectSize.z);
					pool.m_Nodes[(int)this.m_RightChild].m_RectOffset = new Vector3(this.m_RectOffset.x + (float)width, this.m_RectOffset.y, this.m_RectOffset.z);
					if (Mathf.Max(num3, num4) < 1f)
					{
						pool.m_Nodes[(int)this.m_LeftChild].SetIsOccupied();
						return this.m_LeftChild;
					}
					short num5 = pool.m_Nodes[(int)this.m_LeftChild].Allocate(pool, width, height, depth);
					if (num5 >= 0)
					{
						pool.m_Nodes[(int)num5].SetIsOccupied();
					}
					return num5;
				}
				else if (num3 >= num2 && num3 >= num4)
				{
					pool.m_Nodes[(int)this.m_LeftChild].m_RectSize = new Vector3(this.m_RectSize.x, (float)height, this.m_RectSize.z);
					pool.m_Nodes[(int)this.m_LeftChild].m_RectOffset = this.m_RectOffset;
					pool.m_Nodes[(int)this.m_RightChild].m_RectSize = new Vector3(this.m_RectSize.x, num3, this.m_RectSize.z);
					pool.m_Nodes[(int)this.m_RightChild].m_RectOffset = new Vector3(this.m_RectOffset.x, this.m_RectOffset.y + (float)height, this.m_RectOffset.z);
					if (Math.Max(num2, num4) < 1f)
					{
						pool.m_Nodes[(int)this.m_LeftChild].SetIsOccupied();
						return this.m_LeftChild;
					}
					short num6 = pool.m_Nodes[(int)this.m_LeftChild].Allocate(pool, width, height, depth);
					if (num6 >= 0)
					{
						pool.m_Nodes[(int)num6].SetIsOccupied();
					}
					return num6;
				}
				else
				{
					pool.m_Nodes[(int)this.m_LeftChild].m_RectSize = new Vector3(this.m_RectSize.x, this.m_RectSize.y, (float)depth);
					pool.m_Nodes[(int)this.m_LeftChild].m_RectOffset = this.m_RectOffset;
					pool.m_Nodes[(int)this.m_RightChild].m_RectSize = new Vector3(this.m_RectSize.x, this.m_RectSize.y, num4);
					pool.m_Nodes[(int)this.m_RightChild].m_RectOffset = new Vector3(this.m_RectOffset.x, this.m_RectOffset.y, this.m_RectOffset.z + (float)depth);
					if (Math.Max(num2, num3) < 1f)
					{
						pool.m_Nodes[(int)this.m_LeftChild].SetIsOccupied();
						return this.m_LeftChild;
					}
					short num7 = pool.m_Nodes[(int)this.m_LeftChild].Allocate(pool, width, height, depth);
					if (num7 >= 0)
					{
						pool.m_Nodes[(int)num7].SetIsOccupied();
					}
					return num7;
				}
			}

			// Token: 0x06001403 RID: 5123 RVA: 0x00097838 File Offset: 0x00095A38
			public void ReleaseChildren(Atlas3DAllocatorDynamic.Atlas3DNodePool pool)
			{
				if (this.IsLeafNode())
				{
					return;
				}
				pool.m_Nodes[(int)this.m_LeftChild].ReleaseChildren(pool);
				pool.m_Nodes[(int)this.m_RightChild].ReleaseChildren(pool);
				pool.Atlas3DNodeFree(this.m_LeftChild);
				pool.Atlas3DNodeFree(this.m_RightChild);
				this.m_LeftChild = -1;
				this.m_RightChild = -1;
			}

			// Token: 0x06001404 RID: 5124 RVA: 0x000978A4 File Offset: 0x00095AA4
			public void ReleaseAndMerge(Atlas3DAllocatorDynamic.Atlas3DNodePool pool)
			{
				short num = this.m_Self;
				do
				{
					pool.m_Nodes[(int)num].ReleaseChildren(pool);
					pool.m_Nodes[(int)num].ClearIsOccupied();
					num = pool.m_Nodes[(int)num].m_Parent;
				}
				while (num >= 0 && pool.m_Nodes[(int)num].IsMergeNeeded(pool));
			}

			// Token: 0x06001405 RID: 5125 RVA: 0x00097908 File Offset: 0x00095B08
			public bool IsMergeNeeded(Atlas3DAllocatorDynamic.Atlas3DNodePool pool)
			{
				return pool.m_Nodes[(int)this.m_LeftChild].IsLeafNode() && !pool.m_Nodes[(int)this.m_LeftChild].IsOccupied() && pool.m_Nodes[(int)this.m_RightChild].IsLeafNode() && !pool.m_Nodes[(int)this.m_RightChild].IsOccupied();
			}

			// Token: 0x040028E1 RID: 10465
			public short m_Self;

			// Token: 0x040028E2 RID: 10466
			public short m_Parent;

			// Token: 0x040028E3 RID: 10467
			public short m_LeftChild;

			// Token: 0x040028E4 RID: 10468
			public short m_RightChild;

			// Token: 0x040028E5 RID: 10469
			public short m_FreelistNext;

			// Token: 0x040028E6 RID: 10470
			public ushort m_Flags;

			// Token: 0x040028E7 RID: 10471
			public Vector3 m_RectSize;

			// Token: 0x040028E8 RID: 10472
			public Vector3 m_RectOffset;

			// Token: 0x0200047A RID: 1146
			private enum Atlas3DNodeFlags : uint
			{
				// Token: 0x04002A16 RID: 10774
				IsOccupied = 1U
			}
		}
	}
}
