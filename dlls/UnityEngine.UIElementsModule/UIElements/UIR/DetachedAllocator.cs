using System;
using System.Collections.Generic;
using Unity.Collections;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x0200042A RID: 1066
	internal class DetachedAllocator : IDisposable
	{
		// Token: 0x170007C5 RID: 1989
		// (get) Token: 0x060021E6 RID: 8678 RVA: 0x0007FC47 File Offset: 0x0007DE47
		public List<MeshWriteData> meshes
		{
			get
			{
				return this.m_MeshWriteDataPool.GetRange(0, this.m_MeshWriteDataCount);
			}
		}

		// Token: 0x060021E7 RID: 8679 RVA: 0x0007FC5C File Offset: 0x0007DE5C
		public DetachedAllocator()
		{
			this.m_MeshWriteDataPool = new List<MeshWriteData>(16);
			this.m_MeshWriteDataCount = 0;
			this.m_VertsPool = new TempAllocator<Vertex>(8192, 2048, 65536);
			this.m_IndexPool = new TempAllocator<ushort>(16384, 4096, 131072);
		}

		// Token: 0x060021E8 RID: 8680 RVA: 0x0007FCB9 File Offset: 0x0007DEB9
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060021E9 RID: 8681 RVA: 0x0007FCCC File Offset: 0x0007DECC
		protected void Dispose(bool disposing)
		{
			bool disposed = this.m_Disposed;
			if (!disposed)
			{
				if (disposing)
				{
					this.m_VertsPool.Dispose();
					this.m_IndexPool.Dispose();
				}
				this.m_Disposed = true;
			}
		}

		// Token: 0x060021EA RID: 8682 RVA: 0x0007FD10 File Offset: 0x0007DF10
		public MeshWriteData Alloc(int vertexCount, int indexCount)
		{
			bool flag = this.m_MeshWriteDataCount < this.m_MeshWriteDataPool.Count;
			MeshWriteData meshWriteData;
			if (flag)
			{
				meshWriteData = this.m_MeshWriteDataPool[this.m_MeshWriteDataCount];
			}
			else
			{
				meshWriteData = new MeshWriteData();
				this.m_MeshWriteDataPool.Add(meshWriteData);
			}
			this.m_MeshWriteDataCount++;
			bool flag2 = vertexCount == 0 || indexCount == 0;
			MeshWriteData result;
			if (flag2)
			{
				meshWriteData.Reset(default(NativeSlice<Vertex>), default(NativeSlice<ushort>));
				result = meshWriteData;
			}
			else
			{
				meshWriteData.Reset(this.m_VertsPool.Alloc(vertexCount), this.m_IndexPool.Alloc(indexCount));
				result = meshWriteData;
			}
			return result;
		}

		// Token: 0x060021EB RID: 8683 RVA: 0x0007FDC2 File Offset: 0x0007DFC2
		public void Clear()
		{
			this.m_VertsPool.Reset();
			this.m_IndexPool.Reset();
			this.m_MeshWriteDataCount = 0;
		}

		// Token: 0x04000E74 RID: 3700
		private TempAllocator<Vertex> m_VertsPool;

		// Token: 0x04000E75 RID: 3701
		private TempAllocator<ushort> m_IndexPool;

		// Token: 0x04000E76 RID: 3702
		private List<MeshWriteData> m_MeshWriteDataPool;

		// Token: 0x04000E77 RID: 3703
		private int m_MeshWriteDataCount;

		// Token: 0x04000E78 RID: 3704
		private bool m_Disposed;
	}
}
