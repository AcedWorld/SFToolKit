using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Profiling;
using UnityEngine.UIElements.UIR.Implementation;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x02000455 RID: 1109
	internal class RenderChain : IDisposable
	{
		// Token: 0x170007DE RID: 2014
		// (get) Token: 0x0600229D RID: 8861 RVA: 0x00085438 File Offset: 0x00083638
		internal RenderChainCommand firstCommand
		{
			get
			{
				return this.m_FirstCommand;
			}
		}

		// Token: 0x170007DF RID: 2015
		// (get) Token: 0x0600229E RID: 8862 RVA: 0x00085450 File Offset: 0x00083650
		// (set) Token: 0x0600229F RID: 8863 RVA: 0x00085458 File Offset: 0x00083658
		public OpacityIdAccelerator opacityIdAccelerator { get; private set; }

		// Token: 0x060022A0 RID: 8864 RVA: 0x00085464 File Offset: 0x00083664
		static RenderChain()
		{
			Utility.RegisterIntermediateRenderers += RenderChain.OnRegisterIntermediateRenderers;
			Utility.RenderNodeExecute += RenderChain.OnRenderNodeExecute;
		}

		// Token: 0x060022A1 RID: 8865 RVA: 0x00085508 File Offset: 0x00083708
		public RenderChain(BaseVisualElementPanel panel)
		{
			this.Constructor(panel, new UIRenderDevice(0U, 0U), panel.atlas, new VectorImageManager(panel.atlas));
		}

		// Token: 0x060022A2 RID: 8866 RVA: 0x000855C4 File Offset: 0x000837C4
		protected RenderChain(BaseVisualElementPanel panel, UIRenderDevice device, AtlasBase atlas, VectorImageManager vectorImageManager)
		{
			this.Constructor(panel, device, atlas, vectorImageManager);
		}

		// Token: 0x060022A3 RID: 8867 RVA: 0x0008566C File Offset: 0x0008386C
		private void Constructor(BaseVisualElementPanel panelObj, UIRenderDevice deviceObj, AtlasBase atlas, VectorImageManager vectorImageMan)
		{
			bool disposed = this.disposed;
			if (disposed)
			{
				DisposeHelper.NotifyDisposedUsed(this);
			}
			this.m_DirtyTracker.heads = new List<VisualElement>(8);
			this.m_DirtyTracker.tails = new List<VisualElement>(8);
			this.m_DirtyTracker.minDepths = new int[5];
			this.m_DirtyTracker.maxDepths = new int[5];
			this.m_DirtyTracker.Reset();
			bool flag = this.m_RenderNodesData.Count < 1;
			if (flag)
			{
				this.m_RenderNodesData.Add(new RenderChain.RenderNodeData
				{
					matPropBlock = new MaterialPropertyBlock()
				});
			}
			this.panel = panelObj;
			this.device = deviceObj;
			this.atlas = atlas;
			this.vectorImageManager = vectorImageMan;
			this.vertsPool = new TempAllocator<Vertex>(8192, 2048, 65536);
			this.indicesPool = new TempAllocator<ushort>(16384, 4096, 131072);
			this.jobManager = new JobManager();
			this.shaderInfoAllocator.Construct();
			this.opacityIdAccelerator = new OpacityIdAccelerator();
			this.painter = new UIRStylePainter(this);
			BaseRuntimePanel baseRuntimePanel = this.panel as BaseRuntimePanel;
			bool flag2 = baseRuntimePanel != null && baseRuntimePanel.drawToCameras;
			if (flag2)
			{
				this.drawInCameras = true;
				this.m_StaticIndex = RenderChain.RenderChainStaticIndexAllocator.AllocateIndex(this);
			}
		}

		// Token: 0x060022A4 RID: 8868 RVA: 0x000857CC File Offset: 0x000839CC
		private void Destructor()
		{
			bool flag = this.m_StaticIndex >= 0;
			if (flag)
			{
				RenderChain.RenderChainStaticIndexAllocator.FreeIndex(this.m_StaticIndex);
			}
			this.m_StaticIndex = -1;
			RenderChainCommand firstCommand = this.m_FirstCommand;
			for (VisualElement visualElement = RenderChain.GetFirstElementInPanel((firstCommand != null) ? firstCommand.owner : null); visualElement != null; visualElement = visualElement.renderChainData.next)
			{
				this.ResetTextures(visualElement);
			}
			UIRUtility.Destroy(this.m_DefaultMat);
			UIRUtility.Destroy(this.m_DefaultWorldSpaceMat);
			this.m_DefaultMat = (this.m_DefaultWorldSpaceMat = null);
			this.vertsPool.Dispose();
			this.indicesPool.Dispose();
			this.jobManager.Dispose();
			VectorImageManager vectorImageManager = this.vectorImageManager;
			if (vectorImageManager != null)
			{
				vectorImageManager.Dispose();
			}
			this.shaderInfoAllocator.Dispose();
			UIRenderDevice device = this.device;
			if (device != null)
			{
				device.Dispose();
			}
			OpacityIdAccelerator opacityIdAccelerator = this.opacityIdAccelerator;
			if (opacityIdAccelerator != null)
			{
				opacityIdAccelerator.Dispose();
			}
			bool flag2 = this.painter != null;
			if (flag2)
			{
				bool hasPainter2D = this.painter.meshGenerationContext.hasPainter2D;
				if (hasPainter2D)
				{
					this.painter.meshGenerationContext.painter2D.Dispose();
				}
				this.painter = null;
			}
			this.atlas = null;
			this.shaderInfoAllocator = default(UIRVEShaderInfoAllocator);
			this.device = null;
			this.m_ActiveRenderNodes = 0;
			this.m_RenderNodesData.Clear();
		}

		// Token: 0x170007E0 RID: 2016
		// (get) Token: 0x060022A5 RID: 8869 RVA: 0x00085939 File Offset: 0x00083B39
		// (set) Token: 0x060022A6 RID: 8870 RVA: 0x00085941 File Offset: 0x00083B41
		private protected bool disposed { protected get; private set; }

		// Token: 0x060022A7 RID: 8871 RVA: 0x0008594A File Offset: 0x00083B4A
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060022A8 RID: 8872 RVA: 0x0008595C File Offset: 0x00083B5C
		protected void Dispose(bool disposing)
		{
			bool disposed = this.disposed;
			if (!disposed)
			{
				if (disposing)
				{
					this.Destructor();
				}
				this.disposed = true;
			}
		}

		// Token: 0x170007E1 RID: 2017
		// (get) Token: 0x060022A9 RID: 8873 RVA: 0x0008598C File Offset: 0x00083B8C
		internal ChainBuilderStats stats
		{
			get
			{
				return this.m_Stats;
			}
		}

		// Token: 0x060022AA RID: 8874 RVA: 0x000859A4 File Offset: 0x00083BA4
		public void ProcessChanges()
		{
			this.m_Stats = default(ChainBuilderStats);
			this.m_Stats.elementsAdded = this.m_Stats.elementsAdded + this.m_StatsElementsAdded;
			this.m_Stats.elementsRemoved = this.m_Stats.elementsRemoved + this.m_StatsElementsRemoved;
			this.m_StatsElementsAdded = (this.m_StatsElementsRemoved = 0U);
			this.m_DirtyTracker.dirtyID = this.m_DirtyTracker.dirtyID + 1U;
			int num = 0;
			RenderDataDirtyTypes renderDataDirtyTypes = RenderDataDirtyTypes.Clipping | RenderDataDirtyTypes.ClippingHierarchy;
			RenderDataDirtyTypes dirtyTypesInverse = ~renderDataDirtyTypes;
			for (int i = this.m_DirtyTracker.minDepths[num]; i <= this.m_DirtyTracker.maxDepths[num]; i++)
			{
				VisualElement visualElement = this.m_DirtyTracker.heads[i];
				while (visualElement != null)
				{
					VisualElement nextDirty = visualElement.renderChainData.nextDirty;
					bool flag = (visualElement.renderChainData.dirtiedValues & renderDataDirtyTypes) > RenderDataDirtyTypes.None;
					if (flag)
					{
						bool flag2 = visualElement.renderChainData.isInChain && visualElement.renderChainData.dirtyID != this.m_DirtyTracker.dirtyID;
						if (flag2)
						{
							RenderEvents.ProcessOnClippingChanged(this, visualElement, this.m_DirtyTracker.dirtyID, ref this.m_Stats);
						}
						this.m_DirtyTracker.ClearDirty(visualElement, dirtyTypesInverse);
					}
					visualElement = nextDirty;
					this.m_Stats.dirtyProcessed = this.m_Stats.dirtyProcessed + 1U;
				}
			}
			this.m_DirtyTracker.dirtyID = this.m_DirtyTracker.dirtyID + 1U;
			num = 1;
			renderDataDirtyTypes = (RenderDataDirtyTypes.Opacity | RenderDataDirtyTypes.OpacityHierarchy);
			dirtyTypesInverse = ~renderDataDirtyTypes;
			for (int j = this.m_DirtyTracker.minDepths[num]; j <= this.m_DirtyTracker.maxDepths[num]; j++)
			{
				VisualElement visualElement2 = this.m_DirtyTracker.heads[j];
				while (visualElement2 != null)
				{
					VisualElement nextDirty2 = visualElement2.renderChainData.nextDirty;
					bool flag3 = (visualElement2.renderChainData.dirtiedValues & renderDataDirtyTypes) > RenderDataDirtyTypes.None;
					if (flag3)
					{
						bool flag4 = visualElement2.renderChainData.isInChain && visualElement2.renderChainData.dirtyID != this.m_DirtyTracker.dirtyID;
						if (flag4)
						{
							RenderEvents.ProcessOnOpacityChanged(this, visualElement2, this.m_DirtyTracker.dirtyID, ref this.m_Stats);
						}
						this.m_DirtyTracker.ClearDirty(visualElement2, dirtyTypesInverse);
					}
					visualElement2 = nextDirty2;
					this.m_Stats.dirtyProcessed = this.m_Stats.dirtyProcessed + 1U;
				}
			}
			this.m_DirtyTracker.dirtyID = this.m_DirtyTracker.dirtyID + 1U;
			num = 2;
			renderDataDirtyTypes = RenderDataDirtyTypes.Color;
			dirtyTypesInverse = ~renderDataDirtyTypes;
			for (int k = this.m_DirtyTracker.minDepths[num]; k <= this.m_DirtyTracker.maxDepths[num]; k++)
			{
				VisualElement visualElement3 = this.m_DirtyTracker.heads[k];
				while (visualElement3 != null)
				{
					VisualElement nextDirty3 = visualElement3.renderChainData.nextDirty;
					bool flag5 = (visualElement3.renderChainData.dirtiedValues & renderDataDirtyTypes) > RenderDataDirtyTypes.None;
					if (flag5)
					{
						bool flag6 = visualElement3.renderChainData.isInChain && visualElement3.renderChainData.dirtyID != this.m_DirtyTracker.dirtyID;
						if (flag6)
						{
							RenderEvents.ProcessOnColorChanged(this, visualElement3, this.m_DirtyTracker.dirtyID, ref this.m_Stats);
						}
						this.m_DirtyTracker.ClearDirty(visualElement3, dirtyTypesInverse);
					}
					visualElement3 = nextDirty3;
					this.m_Stats.dirtyProcessed = this.m_Stats.dirtyProcessed + 1U;
				}
			}
			this.m_DirtyTracker.dirtyID = this.m_DirtyTracker.dirtyID + 1U;
			num = 3;
			renderDataDirtyTypes = (RenderDataDirtyTypes.Transform | RenderDataDirtyTypes.ClipRectSize);
			dirtyTypesInverse = ~renderDataDirtyTypes;
			for (int l = this.m_DirtyTracker.minDepths[num]; l <= this.m_DirtyTracker.maxDepths[num]; l++)
			{
				VisualElement visualElement4 = this.m_DirtyTracker.heads[l];
				while (visualElement4 != null)
				{
					VisualElement nextDirty4 = visualElement4.renderChainData.nextDirty;
					bool flag7 = (visualElement4.renderChainData.dirtiedValues & renderDataDirtyTypes) > RenderDataDirtyTypes.None;
					if (flag7)
					{
						bool flag8 = visualElement4.renderChainData.isInChain && visualElement4.renderChainData.dirtyID != this.m_DirtyTracker.dirtyID;
						if (flag8)
						{
							RenderEvents.ProcessOnTransformOrSizeChanged(this, visualElement4, this.m_DirtyTracker.dirtyID, ref this.m_Stats);
						}
						this.m_DirtyTracker.ClearDirty(visualElement4, dirtyTypesInverse);
					}
					visualElement4 = nextDirty4;
					this.m_Stats.dirtyProcessed = this.m_Stats.dirtyProcessed + 1U;
				}
			}
			this.jobManager.CompleteNudgeJobs();
			this.m_BlockDirtyRegistration = true;
			this.m_DirtyTracker.dirtyID = this.m_DirtyTracker.dirtyID + 1U;
			num = 4;
			renderDataDirtyTypes = RenderDataDirtyTypes.AllVisuals;
			dirtyTypesInverse = ~renderDataDirtyTypes;
			for (int m = this.m_DirtyTracker.minDepths[num]; m <= this.m_DirtyTracker.maxDepths[num]; m++)
			{
				VisualElement visualElement5 = this.m_DirtyTracker.heads[m];
				while (visualElement5 != null)
				{
					VisualElement nextDirty5 = visualElement5.renderChainData.nextDirty;
					bool flag9 = (visualElement5.renderChainData.dirtiedValues & renderDataDirtyTypes) > RenderDataDirtyTypes.None;
					if (flag9)
					{
						bool flag10 = visualElement5.renderChainData.isInChain && visualElement5.renderChainData.dirtyID != this.m_DirtyTracker.dirtyID;
						if (flag10)
						{
							RenderEvents.ProcessOnVisualsChanged(this, visualElement5, this.m_DirtyTracker.dirtyID, ref this.m_Stats);
						}
						this.m_DirtyTracker.ClearDirty(visualElement5, dirtyTypesInverse);
					}
					visualElement5 = nextDirty5;
					this.m_Stats.dirtyProcessed = this.m_Stats.dirtyProcessed + 1U;
				}
			}
			this.jobManager.CompleteConvertMeshJobs();
			this.jobManager.CompleteClosingMeshJobs();
			this.opacityIdAccelerator.CompleteJobs();
			this.m_BlockDirtyRegistration = false;
			this.vertsPool.Reset();
			this.indicesPool.Reset();
			this.m_DirtyTracker.Reset();
			AtlasBase atlas = this.atlas;
			if (atlas != null)
			{
				atlas.InvokeUpdateDynamicTextures(this.panel);
			}
			VectorImageManager vectorImageManager = this.vectorImageManager;
			if (vectorImageManager != null)
			{
				vectorImageManager.Commit();
			}
			this.shaderInfoAllocator.IssuePendingStorageChanges();
			UIRenderDevice device = this.device;
			if (device != null)
			{
				device.OnFrameRenderingBegin();
			}
		}

		// Token: 0x060022AB RID: 8875 RVA: 0x00085FFC File Offset: 0x000841FC
		public void Render()
		{
			Material standardMaterial = this.GetStandardMaterial();
			this.panel.InvokeUpdateMaterial(standardMaterial);
			Exception ex = null;
			bool flag = this.m_FirstCommand != null;
			if (flag)
			{
				bool flag2 = !this.drawInCameras;
				if (flag2)
				{
					Rect layout = this.panel.visualTree.layout;
					if (standardMaterial != null)
					{
						standardMaterial.SetPass(0);
					}
					Matrix4x4 mat = ProjectionUtils.Ortho(layout.xMin, layout.xMax, layout.yMax, layout.yMin, -0.001f, 1.001f);
					GL.LoadProjectionMatrix(mat);
					GL.modelview = Matrix4x4.identity;
					UIRenderDevice device = this.device;
					RenderChainCommand firstCommand = this.m_FirstCommand;
					Material initialMat = standardMaterial;
					Material defaultMat = standardMaterial;
					VectorImageManager vectorImageManager = this.vectorImageManager;
					device.EvaluateChain(firstCommand, initialMat, defaultMat, (vectorImageManager != null) ? vectorImageManager.atlas : null, this.shaderInfoAllocator.atlas, this.panel.scaledPixelsPerPoint, this.shaderInfoAllocator.transformConstants, this.shaderInfoAllocator.clipRectConstants, this.m_RenderNodesData[0].matPropBlock, true, ref ex);
				}
			}
			bool flag3 = ex != null;
			if (!flag3)
			{
				bool drawStats = this.drawStats;
				if (drawStats)
				{
					this.DrawStats();
				}
				return;
			}
			bool flag4 = GUIUtility.IsExitGUIException(ex);
			if (flag4)
			{
				throw ex;
			}
			throw new ImmediateModeException(ex);
		}

		// Token: 0x060022AC RID: 8876 RVA: 0x0008613C File Offset: 0x0008433C
		public void UIEOnChildAdded(VisualElement ve)
		{
			VisualElement parent = ve.hierarchy.parent;
			int index = (parent != null) ? parent.hierarchy.IndexOf(ve) : 0;
			bool blockDirtyRegistration = this.m_BlockDirtyRegistration;
			if (blockDirtyRegistration)
			{
				throw new InvalidOperationException("VisualElements cannot be added to an active visual tree during generateVisualContent callback execution nor during visual tree rendering");
			}
			bool flag = parent != null && !parent.renderChainData.isInChain;
			if (!flag)
			{
				uint num = RenderEvents.DepthFirstOnChildAdded(this, parent, ve, index, true);
				Debug.Assert(ve.renderChainData.isInChain);
				Debug.Assert(ve.panel == this.panel);
				this.UIEOnClippingChanged(ve, true);
				this.UIEOnOpacityChanged(ve, false);
				this.UIEOnVisualsChanged(ve, true);
				this.m_StatsElementsAdded += num;
			}
		}

		// Token: 0x060022AD RID: 8877 RVA: 0x000861FC File Offset: 0x000843FC
		public void UIEOnChildrenReordered(VisualElement ve)
		{
			bool blockDirtyRegistration = this.m_BlockDirtyRegistration;
			if (blockDirtyRegistration)
			{
				throw new InvalidOperationException("VisualElements cannot be moved under an active visual tree during generateVisualContent callback execution nor during visual tree rendering");
			}
			int childCount = ve.hierarchy.childCount;
			for (int i = 0; i < childCount; i++)
			{
				RenderEvents.DepthFirstOnChildRemoving(this, ve.hierarchy[i]);
			}
			for (int j = 0; j < childCount; j++)
			{
				RenderEvents.DepthFirstOnChildAdded(this, ve, ve.hierarchy[j], j, false);
			}
			this.UIEOnClippingChanged(ve, true);
			this.UIEOnOpacityChanged(ve, true);
			this.UIEOnVisualsChanged(ve, true);
		}

		// Token: 0x060022AE RID: 8878 RVA: 0x000862A4 File Offset: 0x000844A4
		public void UIEOnChildRemoving(VisualElement ve)
		{
			bool blockDirtyRegistration = this.m_BlockDirtyRegistration;
			if (blockDirtyRegistration)
			{
				throw new InvalidOperationException("VisualElements cannot be removed from an active visual tree during generateVisualContent callback execution nor during visual tree rendering");
			}
			this.m_StatsElementsRemoved += RenderEvents.DepthFirstOnChildRemoving(this, ve);
			Debug.Assert(!ve.renderChainData.isInChain);
		}

		// Token: 0x060022AF RID: 8879 RVA: 0x000862F0 File Offset: 0x000844F0
		public void UIEOnRenderHintsChanged(VisualElement ve)
		{
			bool isInChain = ve.renderChainData.isInChain;
			if (isInChain)
			{
				bool blockDirtyRegistration = this.m_BlockDirtyRegistration;
				if (blockDirtyRegistration)
				{
					throw new InvalidOperationException("Render Hints cannot change under an active visual tree during generateVisualContent callback execution nor during visual tree rendering");
				}
				bool flag = (ve.renderHints & RenderHints.DirtyAll) == RenderHints.DirtyDynamicColor;
				bool flag2 = flag;
				if (flag2)
				{
					this.UIEOnVisualsChanged(ve, false);
				}
				else
				{
					this.UIEOnChildRemoving(ve);
					this.UIEOnChildAdded(ve);
				}
				ve.MarkRenderHintsClean();
			}
		}

		// Token: 0x060022B0 RID: 8880 RVA: 0x00086364 File Offset: 0x00084564
		public void UIEOnClippingChanged(VisualElement ve, bool hierarchical)
		{
			bool isInChain = ve.renderChainData.isInChain;
			if (isInChain)
			{
				bool blockDirtyRegistration = this.m_BlockDirtyRegistration;
				if (blockDirtyRegistration)
				{
					throw new InvalidOperationException("VisualElements cannot change clipping state under an active visual tree during generateVisualContent callback execution nor during visual tree rendering");
				}
				this.m_DirtyTracker.RegisterDirty(ve, RenderDataDirtyTypes.Clipping | (hierarchical ? RenderDataDirtyTypes.ClippingHierarchy : RenderDataDirtyTypes.None), RenderDataDirtyTypeClasses.Clipping);
			}
		}

		// Token: 0x060022B1 RID: 8881 RVA: 0x000863B0 File Offset: 0x000845B0
		public void UIEOnOpacityChanged(VisualElement ve, bool hierarchical = false)
		{
			bool isInChain = ve.renderChainData.isInChain;
			if (isInChain)
			{
				bool blockDirtyRegistration = this.m_BlockDirtyRegistration;
				if (blockDirtyRegistration)
				{
					throw new InvalidOperationException("VisualElements cannot change opacity under an active visual tree during generateVisualContent callback execution nor during visual tree rendering");
				}
				this.m_DirtyTracker.RegisterDirty(ve, RenderDataDirtyTypes.Opacity | (hierarchical ? RenderDataDirtyTypes.OpacityHierarchy : RenderDataDirtyTypes.None), RenderDataDirtyTypeClasses.Opacity);
			}
		}

		// Token: 0x060022B2 RID: 8882 RVA: 0x00086404 File Offset: 0x00084604
		public void UIEOnColorChanged(VisualElement ve)
		{
			bool isInChain = ve.renderChainData.isInChain;
			if (isInChain)
			{
				bool blockDirtyRegistration = this.m_BlockDirtyRegistration;
				if (blockDirtyRegistration)
				{
					throw new InvalidOperationException("VisualElements cannot change background color under an active visual tree during generateVisualContent callback execution nor during visual tree rendering");
				}
				this.m_DirtyTracker.RegisterDirty(ve, RenderDataDirtyTypes.Color, RenderDataDirtyTypeClasses.Color);
			}
		}

		// Token: 0x060022B3 RID: 8883 RVA: 0x0008644C File Offset: 0x0008464C
		public void UIEOnTransformOrSizeChanged(VisualElement ve, bool transformChanged, bool clipRectSizeChanged)
		{
			bool isInChain = ve.renderChainData.isInChain;
			if (isInChain)
			{
				bool blockDirtyRegistration = this.m_BlockDirtyRegistration;
				if (blockDirtyRegistration)
				{
					throw new InvalidOperationException("VisualElements cannot change size or transform under an active visual tree during generateVisualContent callback execution nor during visual tree rendering");
				}
				RenderDataDirtyTypes dirtyTypes = (transformChanged ? RenderDataDirtyTypes.Transform : RenderDataDirtyTypes.None) | (clipRectSizeChanged ? RenderDataDirtyTypes.ClipRectSize : RenderDataDirtyTypes.None);
				this.m_DirtyTracker.RegisterDirty(ve, dirtyTypes, RenderDataDirtyTypeClasses.TransformSize);
			}
		}

		// Token: 0x060022B4 RID: 8884 RVA: 0x000864A0 File Offset: 0x000846A0
		public void UIEOnVisualsChanged(VisualElement ve, bool hierarchical)
		{
			bool isInChain = ve.renderChainData.isInChain;
			if (isInChain)
			{
				bool blockDirtyRegistration = this.m_BlockDirtyRegistration;
				if (blockDirtyRegistration)
				{
					throw new InvalidOperationException("VisualElements cannot be marked for dirty repaint under an active visual tree during generateVisualContent callback execution nor during visual tree rendering");
				}
				this.m_DirtyTracker.RegisterDirty(ve, RenderDataDirtyTypes.Visuals | (hierarchical ? RenderDataDirtyTypes.VisualsHierarchy : RenderDataDirtyTypes.None), RenderDataDirtyTypeClasses.Visuals);
			}
		}

		// Token: 0x060022B5 RID: 8885 RVA: 0x000864F0 File Offset: 0x000846F0
		public void UIEOnOpacityIdChanged(VisualElement ve)
		{
			bool isInChain = ve.renderChainData.isInChain;
			if (isInChain)
			{
				bool blockDirtyRegistration = this.m_BlockDirtyRegistration;
				if (blockDirtyRegistration)
				{
					throw new InvalidOperationException("VisualElements cannot for opacity id change under an active visual tree during generateVisualContent callback execution nor during visual tree rendering");
				}
				this.m_DirtyTracker.RegisterDirty(ve, RenderDataDirtyTypes.VisualsOpacityId, RenderDataDirtyTypeClasses.Visuals);
			}
		}

		// Token: 0x170007E2 RID: 2018
		// (get) Token: 0x060022B6 RID: 8886 RVA: 0x00086534 File Offset: 0x00084734
		// (set) Token: 0x060022B7 RID: 8887 RVA: 0x0008653C File Offset: 0x0008473C
		internal BaseVisualElementPanel panel { get; private set; }

		// Token: 0x170007E3 RID: 2019
		// (get) Token: 0x060022B8 RID: 8888 RVA: 0x00086545 File Offset: 0x00084745
		// (set) Token: 0x060022B9 RID: 8889 RVA: 0x0008654D File Offset: 0x0008474D
		internal UIRenderDevice device { get; private set; }

		// Token: 0x170007E4 RID: 2020
		// (get) Token: 0x060022BA RID: 8890 RVA: 0x00086556 File Offset: 0x00084756
		// (set) Token: 0x060022BB RID: 8891 RVA: 0x0008655E File Offset: 0x0008475E
		internal AtlasBase atlas { get; private set; }

		// Token: 0x170007E5 RID: 2021
		// (get) Token: 0x060022BC RID: 8892 RVA: 0x00086567 File Offset: 0x00084767
		// (set) Token: 0x060022BD RID: 8893 RVA: 0x0008656F File Offset: 0x0008476F
		internal VectorImageManager vectorImageManager { get; private set; }

		// Token: 0x170007E6 RID: 2022
		// (get) Token: 0x060022BE RID: 8894 RVA: 0x00086578 File Offset: 0x00084778
		// (set) Token: 0x060022BF RID: 8895 RVA: 0x00086580 File Offset: 0x00084780
		internal TempAllocator<Vertex> vertsPool { get; private set; }

		// Token: 0x170007E7 RID: 2023
		// (get) Token: 0x060022C0 RID: 8896 RVA: 0x00086589 File Offset: 0x00084789
		// (set) Token: 0x060022C1 RID: 8897 RVA: 0x00086591 File Offset: 0x00084791
		internal TempAllocator<ushort> indicesPool { get; private set; }

		// Token: 0x170007E8 RID: 2024
		// (get) Token: 0x060022C2 RID: 8898 RVA: 0x0008659A File Offset: 0x0008479A
		// (set) Token: 0x060022C3 RID: 8899 RVA: 0x000865A2 File Offset: 0x000847A2
		internal JobManager jobManager { get; private set; }

		// Token: 0x170007E9 RID: 2025
		// (get) Token: 0x060022C4 RID: 8900 RVA: 0x000865AB File Offset: 0x000847AB
		// (set) Token: 0x060022C5 RID: 8901 RVA: 0x000865B3 File Offset: 0x000847B3
		internal UIRStylePainter painter { get; private set; }

		// Token: 0x170007EA RID: 2026
		// (get) Token: 0x060022C6 RID: 8902 RVA: 0x000865BC File Offset: 0x000847BC
		// (set) Token: 0x060022C7 RID: 8903 RVA: 0x000865C4 File Offset: 0x000847C4
		internal bool drawStats { get; set; }

		// Token: 0x170007EB RID: 2027
		// (get) Token: 0x060022C8 RID: 8904 RVA: 0x000865CD File Offset: 0x000847CD
		// (set) Token: 0x060022C9 RID: 8905 RVA: 0x000865D5 File Offset: 0x000847D5
		internal bool drawInCameras { get; private set; }

		// Token: 0x170007EC RID: 2028
		// (get) Token: 0x060022CA RID: 8906 RVA: 0x000865E0 File Offset: 0x000847E0
		// (set) Token: 0x060022CB RID: 8907 RVA: 0x000865F8 File Offset: 0x000847F8
		internal Shader defaultShader
		{
			get
			{
				return this.m_DefaultShader;
			}
			set
			{
				bool flag = this.m_DefaultShader == value;
				if (!flag)
				{
					this.m_DefaultShader = value;
					UIRUtility.Destroy(this.m_DefaultMat);
					this.m_DefaultMat = null;
				}
			}
		}

		// Token: 0x170007ED RID: 2029
		// (get) Token: 0x060022CC RID: 8908 RVA: 0x00086634 File Offset: 0x00084834
		// (set) Token: 0x060022CD RID: 8909 RVA: 0x0008664C File Offset: 0x0008484C
		internal Shader defaultWorldSpaceShader
		{
			get
			{
				return this.m_DefaultWorldSpaceShader;
			}
			set
			{
				bool flag = this.m_DefaultWorldSpaceShader == value;
				if (!flag)
				{
					this.m_DefaultWorldSpaceShader = value;
					UIRUtility.Destroy(this.m_DefaultWorldSpaceMat);
					this.m_DefaultWorldSpaceMat = null;
				}
			}
		}

		// Token: 0x060022CE RID: 8910 RVA: 0x00086688 File Offset: 0x00084888
		internal Material GetStandardMaterial()
		{
			bool flag = this.m_DefaultMat == null && this.m_DefaultShader != null;
			if (flag)
			{
				this.m_DefaultMat = new Material(this.m_DefaultShader);
				this.m_DefaultMat.hideFlags |= HideFlags.DontSaveInEditor;
			}
			return this.m_DefaultMat;
		}

		// Token: 0x060022CF RID: 8911 RVA: 0x000866E8 File Offset: 0x000848E8
		internal Material GetStandardWorldSpaceMaterial()
		{
			bool flag = this.m_DefaultWorldSpaceMat == null && this.m_DefaultWorldSpaceShader != null;
			if (flag)
			{
				this.m_DefaultWorldSpaceMat = new Material(this.m_DefaultWorldSpaceShader);
				this.m_DefaultWorldSpaceMat.hideFlags |= HideFlags.DontSaveInEditor;
			}
			return this.m_DefaultWorldSpaceMat;
		}

		// Token: 0x060022D0 RID: 8912 RVA: 0x00086748 File Offset: 0x00084948
		internal void EnsureFitsDepth(int depth)
		{
			this.m_DirtyTracker.EnsureFits(depth);
		}

		// Token: 0x060022D1 RID: 8913 RVA: 0x00086758 File Offset: 0x00084958
		internal void ChildWillBeRemoved(VisualElement ve)
		{
			bool flag = ve.renderChainData.dirtiedValues > RenderDataDirtyTypes.None;
			if (flag)
			{
				this.m_DirtyTracker.ClearDirty(ve, ~ve.renderChainData.dirtiedValues);
			}
			Debug.Assert(ve.renderChainData.dirtiedValues == RenderDataDirtyTypes.None);
			Debug.Assert(ve.renderChainData.prevDirty == null);
			Debug.Assert(ve.renderChainData.nextDirty == null);
		}

		// Token: 0x060022D2 RID: 8914 RVA: 0x000867D0 File Offset: 0x000849D0
		internal RenderChainCommand AllocCommand()
		{
			RenderChainCommand renderChainCommand = this.m_CommandPool.Get();
			renderChainCommand.Reset();
			return renderChainCommand;
		}

		// Token: 0x060022D3 RID: 8915 RVA: 0x000867F8 File Offset: 0x000849F8
		internal void FreeCommand(RenderChainCommand cmd)
		{
			bool flag = cmd.state.material != null;
			if (flag)
			{
				this.m_CustomMaterialCommands--;
			}
			cmd.Reset();
			this.m_CommandPool.Return(cmd);
		}

		// Token: 0x060022D4 RID: 8916 RVA: 0x00086840 File Offset: 0x00084A40
		internal void OnRenderCommandAdded(RenderChainCommand command)
		{
			bool flag = command.prev == null;
			if (flag)
			{
				this.m_FirstCommand = command;
			}
			bool flag2 = command.state.material != null;
			if (flag2)
			{
				this.m_CustomMaterialCommands++;
			}
		}

		// Token: 0x060022D5 RID: 8917 RVA: 0x00086888 File Offset: 0x00084A88
		internal void OnRenderCommandsRemoved(RenderChainCommand firstCommand, RenderChainCommand lastCommand)
		{
			bool flag = firstCommand.prev == null;
			if (flag)
			{
				this.m_FirstCommand = lastCommand.next;
			}
		}

		// Token: 0x060022D6 RID: 8918 RVA: 0x000868B0 File Offset: 0x00084AB0
		private unsafe static RenderChain.RenderNodeData AccessRenderNodeData(IntPtr obj)
		{
			int* ptr = (int*)obj.ToPointer();
			RenderChain renderChain = RenderChain.RenderChainStaticIndexAllocator.AccessIndex(*ptr);
			return renderChain.m_RenderNodesData[ptr[1]];
		}

		// Token: 0x060022D7 RID: 8919 RVA: 0x000868E4 File Offset: 0x00084AE4
		private static void OnRenderNodeExecute(IntPtr obj)
		{
			RenderChain.RenderNodeData renderNodeData = RenderChain.AccessRenderNodeData(obj);
			Exception ex = null;
			renderNodeData.device.EvaluateChain(renderNodeData.firstCommand, renderNodeData.initialMaterial, renderNodeData.standardMaterial, renderNodeData.vectorAtlas, renderNodeData.shaderInfoAtlas, renderNodeData.dpiScale, renderNodeData.transformConstants, renderNodeData.clipRectConstants, renderNodeData.matPropBlock, false, ref ex);
		}

		// Token: 0x060022D8 RID: 8920 RVA: 0x00086940 File Offset: 0x00084B40
		private static void OnRegisterIntermediateRenderers(Camera camera)
		{
			int num = 0;
			Dictionary<int, Panel>.Enumerator panelsIterator = UIElementsUtility.GetPanelsIterator();
			while (panelsIterator.MoveNext())
			{
				KeyValuePair<int, Panel> keyValuePair = panelsIterator.Current;
				Panel value = keyValuePair.Value;
				UIRRepaintUpdater uirrepaintUpdater = value.GetUpdater(VisualTreeUpdatePhase.Repaint) as UIRRepaintUpdater;
				RenderChain renderChain = (uirrepaintUpdater != null) ? uirrepaintUpdater.renderChain : null;
				bool flag = renderChain == null || renderChain.m_StaticIndex < 0 || renderChain.m_FirstCommand == null;
				if (!flag)
				{
					BaseRuntimePanel baseRuntimePanel = (BaseRuntimePanel)value;
					Material standardWorldSpaceMaterial = renderChain.GetStandardWorldSpaceMaterial();
					RenderChain.RenderNodeData renderNodeData = default(RenderChain.RenderNodeData);
					renderNodeData.device = renderChain.device;
					renderNodeData.standardMaterial = standardWorldSpaceMaterial;
					VectorImageManager vectorImageManager = renderChain.vectorImageManager;
					renderNodeData.vectorAtlas = ((vectorImageManager != null) ? vectorImageManager.atlas : null);
					renderNodeData.shaderInfoAtlas = renderChain.shaderInfoAllocator.atlas;
					renderNodeData.dpiScale = baseRuntimePanel.scaledPixelsPerPoint;
					renderNodeData.transformConstants = renderChain.shaderInfoAllocator.transformConstants;
					renderNodeData.clipRectConstants = renderChain.shaderInfoAllocator.clipRectConstants;
					bool flag2 = renderChain.m_CustomMaterialCommands == 0;
					if (flag2)
					{
						renderNodeData.initialMaterial = standardWorldSpaceMaterial;
						renderNodeData.firstCommand = renderChain.m_FirstCommand;
						RenderChain.OnRegisterIntermediateRendererMat(baseRuntimePanel, renderChain, ref renderNodeData, camera, num++);
					}
					else
					{
						Material material = null;
						RenderChainCommand renderChainCommand = renderChain.m_FirstCommand;
						RenderChainCommand renderChainCommand2 = renderChainCommand;
						while (renderChainCommand != null)
						{
							bool flag3 = renderChainCommand.type > CommandType.Draw;
							if (flag3)
							{
								renderChainCommand = renderChainCommand.next;
							}
							else
							{
								Material material2 = (renderChainCommand.state.material == null) ? standardWorldSpaceMaterial : renderChainCommand.state.material;
								bool flag4 = material2 != material;
								if (flag4)
								{
									bool flag5 = material != null;
									if (flag5)
									{
										renderNodeData.initialMaterial = material;
										renderNodeData.firstCommand = renderChainCommand2;
										RenderChain.OnRegisterIntermediateRendererMat(baseRuntimePanel, renderChain, ref renderNodeData, camera, num++);
										renderChainCommand2 = renderChainCommand;
									}
									material = material2;
								}
								renderChainCommand = renderChainCommand.next;
							}
						}
						bool flag6 = renderChainCommand2 != null;
						if (flag6)
						{
							renderNodeData.initialMaterial = material;
							renderNodeData.firstCommand = renderChainCommand2;
							RenderChain.OnRegisterIntermediateRendererMat(baseRuntimePanel, renderChain, ref renderNodeData, camera, num++);
						}
					}
				}
			}
		}

		// Token: 0x060022D9 RID: 8921 RVA: 0x00086B6C File Offset: 0x00084D6C
		private unsafe static void OnRegisterIntermediateRendererMat(BaseRuntimePanel rtp, RenderChain renderChain, ref RenderChain.RenderNodeData rnd, Camera camera, int sameDistanceSortPriority)
		{
			int activeRenderNodes = renderChain.m_ActiveRenderNodes;
			renderChain.m_ActiveRenderNodes = activeRenderNodes + 1;
			int num = activeRenderNodes;
			bool flag = num < renderChain.m_RenderNodesData.Count;
			if (flag)
			{
				RenderChain.RenderNodeData renderNodeData = renderChain.m_RenderNodesData[num];
				rnd.matPropBlock = renderNodeData.matPropBlock;
				renderChain.m_RenderNodesData[num] = rnd;
			}
			else
			{
				rnd.matPropBlock = new MaterialPropertyBlock();
				num = renderChain.m_RenderNodesData.Count;
				renderChain.m_RenderNodesData.Add(rnd);
			}
			int* ptr = stackalloc int[(UIntPtr)8];
			*ptr = renderChain.m_StaticIndex;
			ptr[1] = num;
			Utility.RegisterIntermediateRenderer(camera, rnd.initialMaterial, rtp.panelToWorld, new Bounds(Vector3.zero, new Vector3(float.MaxValue, float.MaxValue, float.MaxValue)), 3, 0, false, sameDistanceSortPriority, (ulong)((long)camera.cullingMask), 2, new IntPtr((void*)ptr), 8);
		}

		// Token: 0x060022DA RID: 8922 RVA: 0x00086C54 File Offset: 0x00084E54
		internal void RepaintTexturedElements()
		{
			RenderChainCommand firstCommand = this.m_FirstCommand;
			for (VisualElement visualElement = RenderChain.GetFirstElementInPanel((firstCommand != null) ? firstCommand.owner : null); visualElement != null; visualElement = visualElement.renderChainData.next)
			{
				bool flag = visualElement.renderChainData.textures != null;
				if (flag)
				{
					this.UIEOnVisualsChanged(visualElement, false);
				}
			}
			this.UIEOnOpacityChanged(this.panel.visualTree, false);
		}

		// Token: 0x060022DB RID: 8923 RVA: 0x00086CC0 File Offset: 0x00084EC0
		public void InsertTexture(VisualElement ve, Texture src, TextureId id, bool isAtlas)
		{
			BasicNode<TextureEntry> basicNode = this.m_TexturePool.Get();
			basicNode.data.source = src;
			basicNode.data.actual = id;
			basicNode.data.replaced = isAtlas;
			basicNode.InsertFirst(ref ve.renderChainData.textures);
		}

		// Token: 0x060022DC RID: 8924 RVA: 0x00086D14 File Offset: 0x00084F14
		public void ResetTextures(VisualElement ve)
		{
			AtlasBase atlas = this.atlas;
			TextureRegistry textureRegistry = this.m_TextureRegistry;
			BasicNodePool<TextureEntry> texturePool = this.m_TexturePool;
			BasicNode<TextureEntry> basicNode = ve.renderChainData.textures;
			ve.renderChainData.textures = null;
			while (basicNode != null)
			{
				BasicNode<TextureEntry> next = basicNode.next;
				bool replaced = basicNode.data.replaced;
				if (replaced)
				{
					atlas.ReturnAtlas(ve, basicNode.data.source as Texture2D, basicNode.data.actual);
				}
				else
				{
					textureRegistry.Release(basicNode.data.actual);
				}
				texturePool.Return(basicNode);
				basicNode = next;
			}
		}

		// Token: 0x060022DD RID: 8925 RVA: 0x00086DB8 File Offset: 0x00084FB8
		private void DrawStats()
		{
			bool flag = this.device != null;
			float num = 12f;
			Rect position = new Rect(30f, 60f, 1000f, 100f);
			GUI.Box(new Rect(20f, 40f, 200f, (float)(flag ? 380 : 256)), "UI Toolkit Draw Stats");
			GUI.Label(position, "Elements added\t: " + this.m_Stats.elementsAdded.ToString());
			position.y += num;
			GUI.Label(position, "Elements removed\t: " + this.m_Stats.elementsRemoved.ToString());
			position.y += num;
			GUI.Label(position, "Mesh allocs allocated\t: " + this.m_Stats.newMeshAllocations.ToString());
			position.y += num;
			GUI.Label(position, "Mesh allocs updated\t: " + this.m_Stats.updatedMeshAllocations.ToString());
			position.y += num;
			GUI.Label(position, "Clip update roots\t: " + this.m_Stats.recursiveClipUpdates.ToString());
			position.y += num;
			GUI.Label(position, "Clip update total\t: " + this.m_Stats.recursiveClipUpdatesExpanded.ToString());
			position.y += num;
			GUI.Label(position, "Opacity update roots\t: " + this.m_Stats.recursiveOpacityUpdates.ToString());
			position.y += num;
			GUI.Label(position, "Opacity update total\t: " + this.m_Stats.recursiveOpacityUpdatesExpanded.ToString());
			position.y += num;
			GUI.Label(position, "Opacity ID update\t: " + this.m_Stats.opacityIdUpdates.ToString());
			position.y += num;
			GUI.Label(position, "Xform update roots\t: " + this.m_Stats.recursiveTransformUpdates.ToString());
			position.y += num;
			GUI.Label(position, "Xform update total\t: " + this.m_Stats.recursiveTransformUpdatesExpanded.ToString());
			position.y += num;
			GUI.Label(position, "Xformed by bone\t: " + this.m_Stats.boneTransformed.ToString());
			position.y += num;
			GUI.Label(position, "Xformed by skipping\t: " + this.m_Stats.skipTransformed.ToString());
			position.y += num;
			GUI.Label(position, "Xformed by nudging\t: " + this.m_Stats.nudgeTransformed.ToString());
			position.y += num;
			GUI.Label(position, "Xformed by repaint\t: " + this.m_Stats.visualUpdateTransformed.ToString());
			position.y += num;
			GUI.Label(position, "Visual update roots\t: " + this.m_Stats.recursiveVisualUpdates.ToString());
			position.y += num;
			GUI.Label(position, "Visual update total\t: " + this.m_Stats.recursiveVisualUpdatesExpanded.ToString());
			position.y += num;
			GUI.Label(position, "Visual update flats\t: " + this.m_Stats.nonRecursiveVisualUpdates.ToString());
			position.y += num;
			GUI.Label(position, "Dirty processed\t: " + this.m_Stats.dirtyProcessed.ToString());
			position.y += num;
			GUI.Label(position, "Group-xform updates\t: " + this.m_Stats.groupTransformElementsChanged.ToString());
			position.y += num;
			bool flag2 = !flag;
			if (!flag2)
			{
				position.y += num;
				UIRenderDevice.DrawStatistics drawStatistics = this.device.GatherDrawStatistics();
				GUI.Label(position, "Frame index\t: " + drawStatistics.currentFrameIndex.ToString());
				position.y += num;
				GUI.Label(position, "Command count\t: " + drawStatistics.commandCount.ToString());
				position.y += num;
				GUI.Label(position, "Draw commands\t: " + drawStatistics.drawCommandCount.ToString());
				position.y += num;
				GUI.Label(position, "Draw ranges\t: " + drawStatistics.drawRangeCount.ToString());
				position.y += num;
				GUI.Label(position, "Draw range calls\t: " + drawStatistics.drawRangeCallCount.ToString());
				position.y += num;
				GUI.Label(position, "Material sets\t: " + drawStatistics.materialSetCount.ToString());
				position.y += num;
				GUI.Label(position, "Stencil changes\t: " + drawStatistics.stencilRefChanges.ToString());
				position.y += num;
				GUI.Label(position, "Immediate draws\t: " + drawStatistics.immediateDraws.ToString());
				position.y += num;
				GUI.Label(position, "Total triangles\t: " + (drawStatistics.totalIndices / 3U).ToString());
				position.y += num;
			}
		}

		// Token: 0x060022DE RID: 8926 RVA: 0x000873BC File Offset: 0x000855BC
		private static VisualElement GetFirstElementInPanel(VisualElement ve)
		{
			for (;;)
			{
				bool flag;
				if (ve != null)
				{
					VisualElement prev = ve.renderChainData.prev;
					flag = (prev != null && prev.renderChainData.isInChain);
				}
				else
				{
					flag = false;
				}
				if (!flag)
				{
					break;
				}
				ve = ve.renderChainData.prev;
			}
			return ve;
		}

		// Token: 0x04000F99 RID: 3993
		private RenderChainCommand m_FirstCommand;

		// Token: 0x04000F9A RID: 3994
		private RenderChain.DepthOrderedDirtyTracking m_DirtyTracker;

		// Token: 0x04000F9B RID: 3995
		private LinkedPool<RenderChainCommand> m_CommandPool = new LinkedPool<RenderChainCommand>(() => new RenderChainCommand(), delegate(RenderChainCommand cmd)
		{
		}, 10000);

		// Token: 0x04000F9C RID: 3996
		private BasicNodePool<TextureEntry> m_TexturePool = new BasicNodePool<TextureEntry>();

		// Token: 0x04000F9D RID: 3997
		private List<RenderChain.RenderNodeData> m_RenderNodesData = new List<RenderChain.RenderNodeData>();

		// Token: 0x04000F9E RID: 3998
		private Shader m_DefaultShader;

		// Token: 0x04000F9F RID: 3999
		private Shader m_DefaultWorldSpaceShader;

		// Token: 0x04000FA0 RID: 4000
		private Material m_DefaultMat;

		// Token: 0x04000FA1 RID: 4001
		private Material m_DefaultWorldSpaceMat;

		// Token: 0x04000FA2 RID: 4002
		private bool m_BlockDirtyRegistration;

		// Token: 0x04000FA3 RID: 4003
		private int m_StaticIndex = -1;

		// Token: 0x04000FA4 RID: 4004
		private int m_ActiveRenderNodes = 0;

		// Token: 0x04000FA5 RID: 4005
		private int m_CustomMaterialCommands = 0;

		// Token: 0x04000FA6 RID: 4006
		private ChainBuilderStats m_Stats;

		// Token: 0x04000FA7 RID: 4007
		private uint m_StatsElementsAdded;

		// Token: 0x04000FA8 RID: 4008
		private uint m_StatsElementsRemoved;

		// Token: 0x04000FA9 RID: 4009
		private TextureRegistry m_TextureRegistry = TextureRegistry.instance;

		// Token: 0x04000FAB RID: 4011
		private static ProfilerMarker s_MarkerProcess = new ProfilerMarker("RenderChain.Process");

		// Token: 0x04000FAC RID: 4012
		private static ProfilerMarker s_MarkerClipProcessing = new ProfilerMarker("RenderChain.UpdateClips");

		// Token: 0x04000FAD RID: 4013
		private static ProfilerMarker s_MarkerOpacityProcessing = new ProfilerMarker("RenderChain.UpdateOpacity");

		// Token: 0x04000FAE RID: 4014
		private static ProfilerMarker s_MarkerColorsProcessing = new ProfilerMarker("RenderChain.UpdateColors");

		// Token: 0x04000FAF RID: 4015
		private static ProfilerMarker s_MarkerTransformProcessing = new ProfilerMarker("RenderChain.UpdateTransforms");

		// Token: 0x04000FB0 RID: 4016
		private static ProfilerMarker s_MarkerVisualsProcessing = new ProfilerMarker("RenderChain.UpdateVisuals");

		// Token: 0x04000FB1 RID: 4017
		private static ProfilerMarker s_MarkerTextRegen = new ProfilerMarker("RenderChain.RegenText");

		// Token: 0x04000FB3 RID: 4019
		internal static Action OnPreRender = null;

		// Token: 0x04000FBB RID: 4027
		internal UIRVEShaderInfoAllocator shaderInfoAllocator;

		// Token: 0x02000456 RID: 1110
		private struct DepthOrderedDirtyTracking
		{
			// Token: 0x060022DF RID: 8927 RVA: 0x00087404 File Offset: 0x00085604
			public void EnsureFits(int maxDepth)
			{
				while (this.heads.Count <= maxDepth)
				{
					this.heads.Add(null);
					this.tails.Add(null);
				}
			}

			// Token: 0x060022E0 RID: 8928 RVA: 0x00087448 File Offset: 0x00085648
			public void RegisterDirty(VisualElement ve, RenderDataDirtyTypes dirtyTypes, RenderDataDirtyTypeClasses dirtyTypeClass)
			{
				Debug.Assert(dirtyTypes > RenderDataDirtyTypes.None);
				int hierarchyDepth = ve.renderChainData.hierarchyDepth;
				this.minDepths[(int)dirtyTypeClass] = ((hierarchyDepth < this.minDepths[(int)dirtyTypeClass]) ? hierarchyDepth : this.minDepths[(int)dirtyTypeClass]);
				this.maxDepths[(int)dirtyTypeClass] = ((hierarchyDepth > this.maxDepths[(int)dirtyTypeClass]) ? hierarchyDepth : this.maxDepths[(int)dirtyTypeClass]);
				bool flag = ve.renderChainData.dirtiedValues > RenderDataDirtyTypes.None;
				if (flag)
				{
					ve.renderChainData.dirtiedValues = (ve.renderChainData.dirtiedValues | dirtyTypes);
				}
				else
				{
					ve.renderChainData.dirtiedValues = dirtyTypes;
					bool flag2 = this.tails[hierarchyDepth] != null;
					if (flag2)
					{
						this.tails[hierarchyDepth].renderChainData.nextDirty = ve;
						ve.renderChainData.prevDirty = this.tails[hierarchyDepth];
						this.tails[hierarchyDepth] = ve;
					}
					else
					{
						List<VisualElement> list = this.heads;
						int index = hierarchyDepth;
						this.tails[hierarchyDepth] = ve;
						list[index] = ve;
					}
				}
			}

			// Token: 0x060022E1 RID: 8929 RVA: 0x00087550 File Offset: 0x00085750
			public void ClearDirty(VisualElement ve, RenderDataDirtyTypes dirtyTypesInverse)
			{
				Debug.Assert(ve.renderChainData.dirtiedValues > RenderDataDirtyTypes.None);
				ve.renderChainData.dirtiedValues = (ve.renderChainData.dirtiedValues & dirtyTypesInverse);
				bool flag = ve.renderChainData.dirtiedValues == RenderDataDirtyTypes.None;
				if (flag)
				{
					bool flag2 = ve.renderChainData.prevDirty != null;
					if (flag2)
					{
						ve.renderChainData.prevDirty.renderChainData.nextDirty = ve.renderChainData.nextDirty;
					}
					bool flag3 = ve.renderChainData.nextDirty != null;
					if (flag3)
					{
						ve.renderChainData.nextDirty.renderChainData.prevDirty = ve.renderChainData.prevDirty;
					}
					bool flag4 = this.tails[ve.renderChainData.hierarchyDepth] == ve;
					if (flag4)
					{
						Debug.Assert(ve.renderChainData.nextDirty == null);
						this.tails[ve.renderChainData.hierarchyDepth] = ve.renderChainData.prevDirty;
					}
					bool flag5 = this.heads[ve.renderChainData.hierarchyDepth] == ve;
					if (flag5)
					{
						Debug.Assert(ve.renderChainData.prevDirty == null);
						this.heads[ve.renderChainData.hierarchyDepth] = ve.renderChainData.nextDirty;
					}
					ve.renderChainData.prevDirty = (ve.renderChainData.nextDirty = null);
				}
			}

			// Token: 0x060022E2 RID: 8930 RVA: 0x000876C8 File Offset: 0x000858C8
			public void Reset()
			{
				for (int i = 0; i < this.minDepths.Length; i++)
				{
					this.minDepths[i] = int.MaxValue;
					this.maxDepths[i] = int.MinValue;
				}
			}

			// Token: 0x04000FBF RID: 4031
			public List<VisualElement> heads;

			// Token: 0x04000FC0 RID: 4032
			public List<VisualElement> tails;

			// Token: 0x04000FC1 RID: 4033
			public int[] minDepths;

			// Token: 0x04000FC2 RID: 4034
			public int[] maxDepths;

			// Token: 0x04000FC3 RID: 4035
			public uint dirtyID;
		}

		// Token: 0x02000457 RID: 1111
		private struct RenderChainStaticIndexAllocator
		{
			// Token: 0x060022E3 RID: 8931 RVA: 0x0008770C File Offset: 0x0008590C
			public static int AllocateIndex(RenderChain renderChain)
			{
				int num = RenderChain.RenderChainStaticIndexAllocator.renderChains.IndexOf(null);
				bool flag = num >= 0;
				if (flag)
				{
					RenderChain.RenderChainStaticIndexAllocator.renderChains[num] = renderChain;
				}
				else
				{
					num = RenderChain.RenderChainStaticIndexAllocator.renderChains.Count;
					RenderChain.RenderChainStaticIndexAllocator.renderChains.Add(renderChain);
				}
				return num;
			}

			// Token: 0x060022E4 RID: 8932 RVA: 0x0008775E File Offset: 0x0008595E
			public static void FreeIndex(int index)
			{
				RenderChain.RenderChainStaticIndexAllocator.renderChains[index] = null;
			}

			// Token: 0x060022E5 RID: 8933 RVA: 0x00087770 File Offset: 0x00085970
			public static RenderChain AccessIndex(int index)
			{
				return RenderChain.RenderChainStaticIndexAllocator.renderChains[index];
			}

			// Token: 0x04000FC4 RID: 4036
			private static List<RenderChain> renderChains = new List<RenderChain>(4);
		}

		// Token: 0x02000458 RID: 1112
		private struct RenderNodeData
		{
			// Token: 0x04000FC5 RID: 4037
			public Material standardMaterial;

			// Token: 0x04000FC6 RID: 4038
			public Material initialMaterial;

			// Token: 0x04000FC7 RID: 4039
			public MaterialPropertyBlock matPropBlock;

			// Token: 0x04000FC8 RID: 4040
			public RenderChainCommand firstCommand;

			// Token: 0x04000FC9 RID: 4041
			public UIRenderDevice device;

			// Token: 0x04000FCA RID: 4042
			public Texture vectorAtlas;

			// Token: 0x04000FCB RID: 4043
			public Texture shaderInfoAtlas;

			// Token: 0x04000FCC RID: 4044
			public float dpiScale;

			// Token: 0x04000FCD RID: 4045
			public NativeSlice<Transform3x4> transformConstants;

			// Token: 0x04000FCE RID: 4046
			public NativeSlice<Vector4> clipRectConstants;
		}
	}
}
