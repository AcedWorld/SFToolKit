using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Profiling;
using UnityEngine.UIElements.UIR;

namespace UnityEngine.UIElements
{
	// Token: 0x020002B2 RID: 690
	public class Painter2D : IDisposable
	{
		// Token: 0x1700042A RID: 1066
		// (get) Token: 0x060013CB RID: 5067 RVA: 0x0004641A File Offset: 0x0004461A
		internal bool isDetached
		{
			get
			{
				return this.m_DetachedAllocator != null;
			}
		}

		// Token: 0x060013CC RID: 5068 RVA: 0x00046425 File Offset: 0x00044625
		internal Painter2D(MeshGenerationContext ctx)
		{
			this.m_Handle = new SafeHandleAccess(UIPainter2D.Create(false));
			this.m_Ctx = ctx;
			this.Reset();
		}

		// Token: 0x060013CD RID: 5069 RVA: 0x0004644E File Offset: 0x0004464E
		public Painter2D()
		{
			this.m_Handle = new SafeHandleAccess(UIPainter2D.Create(true));
			this.m_DetachedAllocator = new DetachedAllocator();
			Painter2D.isPainterActive = true;
			this.Reset();
		}

		// Token: 0x060013CE RID: 5070 RVA: 0x00046482 File Offset: 0x00044682
		internal void Reset()
		{
			UIPainter2D.Reset(this.m_Handle);
		}

		// Token: 0x060013CF RID: 5071 RVA: 0x00046498 File Offset: 0x00044698
		internal MeshWriteData Allocate(int vertexCount, int indexCount)
		{
			bool isDetached = this.isDetached;
			MeshWriteData result;
			if (isDetached)
			{
				result = this.m_DetachedAllocator.Alloc(vertexCount, indexCount);
			}
			else
			{
				result = this.m_Ctx.Allocate(vertexCount, indexCount, null);
			}
			return result;
		}

		// Token: 0x060013D0 RID: 5072 RVA: 0x000464D4 File Offset: 0x000446D4
		public void Clear()
		{
			bool flag = !this.isDetached;
			if (flag)
			{
				Debug.LogError("Clear() cannot be called on a Painter2D associated with a MeshGenerationContext. You should create your own instance of Painter2D instead.");
			}
			else
			{
				this.m_DetachedAllocator.Clear();
				this.Reset();
			}
		}

		// Token: 0x060013D1 RID: 5073 RVA: 0x00046510 File Offset: 0x00044710
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060013D2 RID: 5074 RVA: 0x00046524 File Offset: 0x00044724
		private void Dispose(bool disposing)
		{
			bool disposed = this.m_Disposed;
			if (!disposed)
			{
				if (disposing)
				{
					bool flag = !this.m_Handle.IsNull();
					if (flag)
					{
						UIPainter2D.Destroy(this.m_Handle);
						this.m_Handle = new SafeHandleAccess(IntPtr.Zero);
					}
					bool flag2 = this.m_DetachedAllocator != null;
					if (flag2)
					{
						this.m_DetachedAllocator.Dispose();
					}
				}
				this.m_Disposed = true;
			}
		}

		// Token: 0x1700042B RID: 1067
		// (get) Token: 0x060013D3 RID: 5075 RVA: 0x0004659C File Offset: 0x0004479C
		// (set) Token: 0x060013D4 RID: 5076 RVA: 0x000465AE File Offset: 0x000447AE
		public float lineWidth
		{
			get
			{
				return UIPainter2D.GetLineWidth(this.m_Handle);
			}
			set
			{
				UIPainter2D.SetLineWidth(this.m_Handle, value);
			}
		}

		// Token: 0x1700042C RID: 1068
		// (get) Token: 0x060013D5 RID: 5077 RVA: 0x000465C2 File Offset: 0x000447C2
		// (set) Token: 0x060013D6 RID: 5078 RVA: 0x000465D4 File Offset: 0x000447D4
		public Color strokeColor
		{
			get
			{
				return UIPainter2D.GetStrokeColor(this.m_Handle);
			}
			set
			{
				UIPainter2D.SetStrokeColor(this.m_Handle, value);
			}
		}

		// Token: 0x1700042D RID: 1069
		// (get) Token: 0x060013D7 RID: 5079 RVA: 0x000465E8 File Offset: 0x000447E8
		// (set) Token: 0x060013D8 RID: 5080 RVA: 0x000465FA File Offset: 0x000447FA
		public Gradient strokeGradient
		{
			get
			{
				return UIPainter2D.GetStrokeGradient(this.m_Handle);
			}
			set
			{
				UIPainter2D.SetStrokeGradient(this.m_Handle, value);
			}
		}

		// Token: 0x1700042E RID: 1070
		// (get) Token: 0x060013D9 RID: 5081 RVA: 0x0004660E File Offset: 0x0004480E
		// (set) Token: 0x060013DA RID: 5082 RVA: 0x00046620 File Offset: 0x00044820
		public Color fillColor
		{
			get
			{
				return UIPainter2D.GetFillColor(this.m_Handle);
			}
			set
			{
				UIPainter2D.SetFillColor(this.m_Handle, value);
			}
		}

		// Token: 0x1700042F RID: 1071
		// (get) Token: 0x060013DB RID: 5083 RVA: 0x00046634 File Offset: 0x00044834
		// (set) Token: 0x060013DC RID: 5084 RVA: 0x00046646 File Offset: 0x00044846
		public LineJoin lineJoin
		{
			get
			{
				return UIPainter2D.GetLineJoin(this.m_Handle);
			}
			set
			{
				UIPainter2D.SetLineJoin(this.m_Handle, value);
			}
		}

		// Token: 0x17000430 RID: 1072
		// (get) Token: 0x060013DD RID: 5085 RVA: 0x0004665A File Offset: 0x0004485A
		// (set) Token: 0x060013DE RID: 5086 RVA: 0x0004666C File Offset: 0x0004486C
		public LineCap lineCap
		{
			get
			{
				return UIPainter2D.GetLineCap(this.m_Handle);
			}
			set
			{
				UIPainter2D.SetLineCap(this.m_Handle, value);
			}
		}

		// Token: 0x17000431 RID: 1073
		// (get) Token: 0x060013DF RID: 5087 RVA: 0x00046680 File Offset: 0x00044880
		// (set) Token: 0x060013E0 RID: 5088 RVA: 0x00046692 File Offset: 0x00044892
		public float miterLimit
		{
			get
			{
				return UIPainter2D.GetMiterLimit(this.m_Handle);
			}
			set
			{
				UIPainter2D.SetMiterLimit(this.m_Handle, value);
			}
		}

		// Token: 0x17000432 RID: 1074
		// (get) Token: 0x060013E1 RID: 5089 RVA: 0x000466A6 File Offset: 0x000448A6
		// (set) Token: 0x060013E2 RID: 5090 RVA: 0x000466AD File Offset: 0x000448AD
		internal static bool isPainterActive { get; set; }

		// Token: 0x060013E3 RID: 5091 RVA: 0x000466B8 File Offset: 0x000448B8
		private bool ValidateState()
		{
			bool flag = this.isDetached || Painter2D.isPainterActive;
			bool flag2 = !flag;
			if (flag2)
			{
				Debug.LogError("Cannot issue vector graphics commands outside of generateVisualContent callback");
			}
			return flag;
		}

		// Token: 0x17000433 RID: 1075
		// (get) Token: 0x060013E4 RID: 5092 RVA: 0x000466F0 File Offset: 0x000448F0
		private static float maxArcRadius
		{
			get
			{
				bool flag = Painter2D.s_MaxArcRadius < 0f;
				if (flag)
				{
					bool flag2 = !UIRenderDevice.vertexTexturingIsAvailable;
					if (flag2)
					{
						Painter2D.s_MaxArcRadius = 1000f;
					}
					else
					{
						Painter2D.s_MaxArcRadius = 100000f;
					}
				}
				return Painter2D.s_MaxArcRadius;
			}
		}

		// Token: 0x060013E5 RID: 5093 RVA: 0x0004673C File Offset: 0x0004493C
		public void BeginPath()
		{
			bool flag = !this.ValidateState();
			if (!flag)
			{
				UIPainter2D.BeginPath(this.m_Handle);
			}
		}

		// Token: 0x060013E6 RID: 5094 RVA: 0x0004676C File Offset: 0x0004496C
		public void ClosePath()
		{
			bool flag = !this.ValidateState();
			if (!flag)
			{
				UIPainter2D.ClosePath(this.m_Handle);
			}
		}

		// Token: 0x060013E7 RID: 5095 RVA: 0x0004679C File Offset: 0x0004499C
		public void MoveTo(Vector2 pos)
		{
			bool flag = !this.ValidateState();
			if (!flag)
			{
				UIPainter2D.MoveTo(this.m_Handle, pos);
			}
		}

		// Token: 0x060013E8 RID: 5096 RVA: 0x000467CC File Offset: 0x000449CC
		public void LineTo(Vector2 pos)
		{
			bool flag = !this.ValidateState();
			if (!flag)
			{
				UIPainter2D.LineTo(this.m_Handle, pos);
			}
		}

		// Token: 0x060013E9 RID: 5097 RVA: 0x000467FC File Offset: 0x000449FC
		public void ArcTo(Vector2 p1, Vector2 p2, float radius)
		{
			bool flag = !this.ValidateState();
			if (!flag)
			{
				UIPainter2D.ArcTo(this.m_Handle, p1, p2, radius);
			}
		}

		// Token: 0x060013EA RID: 5098 RVA: 0x00046830 File Offset: 0x00044A30
		public void Arc(Vector2 center, float radius, Angle startAngle, Angle endAngle, ArcDirection direction = ArcDirection.Clockwise)
		{
			bool flag = !this.ValidateState();
			if (!flag)
			{
				UIPainter2D.Arc(this.m_Handle, center, radius, startAngle.ToRadians(), endAngle.ToRadians(), direction);
			}
		}

		// Token: 0x060013EB RID: 5099 RVA: 0x00046870 File Offset: 0x00044A70
		public void BezierCurveTo(Vector2 p1, Vector2 p2, Vector2 p3)
		{
			bool flag = !this.ValidateState();
			if (!flag)
			{
				UIPainter2D.BezierCurveTo(this.m_Handle, p1, p2, p3);
			}
		}

		// Token: 0x060013EC RID: 5100 RVA: 0x000468A4 File Offset: 0x00044AA4
		public void QuadraticCurveTo(Vector2 p1, Vector2 p2)
		{
			bool flag = !this.ValidateState();
			if (!flag)
			{
				UIPainter2D.QuadraticCurveTo(this.m_Handle, p1, p2);
			}
		}

		// Token: 0x060013ED RID: 5101 RVA: 0x000468D4 File Offset: 0x00044AD4
		public unsafe void Stroke()
		{
			using (Painter2D.s_StrokeMarker.Auto())
			{
				bool flag = !this.ValidateState();
				if (!flag)
				{
					MeshWriteDataInterface meshWriteDataInterface = UIPainter2D.Stroke(this.m_Handle);
					bool flag2 = meshWriteDataInterface.vertexCount == 0;
					if (!flag2)
					{
						MeshWriteData meshWriteData = this.Allocate(meshWriteDataInterface.vertexCount, meshWriteDataInterface.indexCount);
						NativeSlice<Vertex> allVertices = UIRenderDevice.PtrToSlice<Vertex>((void*)meshWriteDataInterface.vertices, meshWriteDataInterface.vertexCount);
						NativeSlice<ushort> allIndices = UIRenderDevice.PtrToSlice<ushort>((void*)meshWriteDataInterface.indices, meshWriteDataInterface.indexCount);
						meshWriteData.SetAllVertices(allVertices);
						meshWriteData.SetAllIndices(allIndices);
					}
				}
			}
		}

		// Token: 0x060013EE RID: 5102 RVA: 0x000469A0 File Offset: 0x00044BA0
		public unsafe void Fill(FillRule fillRule = FillRule.NonZero)
		{
			using (Painter2D.s_FillMarker.Auto())
			{
				bool flag = !this.ValidateState();
				if (!flag)
				{
					MeshWriteDataInterface meshWriteDataInterface = UIPainter2D.Fill(this.m_Handle, fillRule);
					bool flag2 = meshWriteDataInterface.vertexCount == 0;
					if (!flag2)
					{
						MeshWriteData meshWriteData = this.Allocate(meshWriteDataInterface.vertexCount, meshWriteDataInterface.indexCount);
						NativeSlice<Vertex> allVertices = UIRenderDevice.PtrToSlice<Vertex>((void*)meshWriteDataInterface.vertices, meshWriteDataInterface.vertexCount);
						NativeSlice<ushort> allIndices = UIRenderDevice.PtrToSlice<ushort>((void*)meshWriteDataInterface.indices, meshWriteDataInterface.indexCount);
						meshWriteData.SetAllVertices(allVertices);
						meshWriteData.SetAllIndices(allIndices);
					}
				}
			}
		}

		// Token: 0x060013EF RID: 5103 RVA: 0x00046A70 File Offset: 0x00044C70
		public bool SaveToVectorImage(VectorImage vectorImage)
		{
			bool flag = !this.isDetached;
			bool result;
			if (flag)
			{
				Debug.LogError("SaveToVectorImage cannot be called on a Painter2D associated with a MeshGenerationContext. You should create your own instance of Painter2D instead.");
				result = false;
			}
			else
			{
				bool flag2 = vectorImage == null;
				if (flag2)
				{
					throw new NullReferenceException("The provided vectorImage is null");
				}
				List<MeshWriteData> meshes = this.m_DetachedAllocator.meshes;
				int num = 0;
				int num2 = 0;
				foreach (MeshWriteData meshWriteData in meshes)
				{
					num += meshWriteData.m_Vertices.Length;
					num2 += meshWriteData.m_Indices.Length;
				}
				Rect bbox = UIPainter2D.GetBBox(this.m_Handle);
				VectorImageVertex[] array = new VectorImageVertex[num];
				ushort[] array2 = new ushort[num2];
				int num3 = 0;
				int num4 = 0;
				int num5 = 0;
				foreach (MeshWriteData meshWriteData2 in meshes)
				{
					NativeSlice<Vertex> vertices = meshWriteData2.m_Vertices;
					for (int i = 0; i < vertices.Length; i++)
					{
						Vertex vertex = vertices[i];
						Vector3 position = vertex.position;
						position.x -= bbox.x;
						position.y -= bbox.y;
						array[num3++] = new VectorImageVertex
						{
							position = new Vector3(position.x, position.y, Vertex.nearZ),
							tint = vertex.tint,
							uv = vertex.uv,
							flags = vertex.flags,
							circle = vertex.circle
						};
					}
					NativeSlice<ushort> indices = meshWriteData2.m_Indices;
					for (int j = 0; j < indices.Length; j++)
					{
						array2[num4++] = (ushort)((int)indices[j] + num5);
					}
					num5 += vertices.Length;
				}
				vectorImage.version = 0;
				vectorImage.vertices = array;
				vectorImage.indices = array2;
				vectorImage.size = bbox.size;
				result = true;
			}
			return result;
		}

		// Token: 0x0400093F RID: 2367
		private MeshGenerationContext m_Ctx;

		// Token: 0x04000940 RID: 2368
		internal DetachedAllocator m_DetachedAllocator;

		// Token: 0x04000941 RID: 2369
		internal SafeHandleAccess m_Handle;

		// Token: 0x04000942 RID: 2370
		private bool m_Disposed;

		// Token: 0x04000944 RID: 2372
		private static float s_MaxArcRadius = -1f;

		// Token: 0x04000945 RID: 2373
		private static readonly ProfilerMarker s_StrokeMarker = new ProfilerMarker("Painter2D.Stroke");

		// Token: 0x04000946 RID: 2374
		private static readonly ProfilerMarker s_FillMarker = new ProfilerMarker("Painter2D.Fill");
	}
}
