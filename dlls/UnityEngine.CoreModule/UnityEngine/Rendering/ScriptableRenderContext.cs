using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Bindings;
using UnityEngine.Rendering.RendererUtils;

namespace UnityEngine.Rendering
{
	// Token: 0x0200046F RID: 1135
	[NativeHeader("Runtime/Export/RenderPipeline/ScriptableRenderPipeline.bindings.h")]
	[NativeHeader("Modules/UI/Canvas.h")]
	[NativeHeader("Modules/UI/CanvasManager.h")]
	[NativeType("Runtime/Graphics/ScriptableRenderLoop/ScriptableRenderContext.h")]
	[NativeHeader("Runtime/Export/RenderPipeline/ScriptableRenderContext.bindings.h")]
	[NativeHeader("Runtime/Graphics/ScriptableRenderLoop/ScriptableDrawRenderersUtility.h")]
	public struct ScriptableRenderContext : IEquatable<ScriptableRenderContext>
	{
		// Token: 0x06002640 RID: 9792
		[FreeFunction("ScriptableRenderContext::BeginRenderPass")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void BeginRenderPass_Internal(IntPtr self, int width, int height, int volumeDepth, int samples, IntPtr colors, int colorCount, int depthAttachmentIndex);

		// Token: 0x06002641 RID: 9793
		[FreeFunction("ScriptableRenderContext::BeginSubPass")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void BeginSubPass_Internal(IntPtr self, IntPtr colors, int colorCount, IntPtr inputs, int inputCount, bool isDepthReadOnly, bool isStencilReadOnly);

		// Token: 0x06002642 RID: 9794
		[FreeFunction("ScriptableRenderContext::EndSubPass")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void EndSubPass_Internal(IntPtr self);

		// Token: 0x06002643 RID: 9795
		[FreeFunction("ScriptableRenderContext::EndRenderPass")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void EndRenderPass_Internal(IntPtr self);

		// Token: 0x06002644 RID: 9796 RVA: 0x00041B64 File Offset: 0x0003FD64
		[FreeFunction("ScriptableRenderPipeline_Bindings::Internal_Cull")]
		private static void Internal_Cull(ref ScriptableCullingParameters parameters, ScriptableRenderContext renderLoop, IntPtr results)
		{
			ScriptableRenderContext.Internal_Cull_Injected(ref parameters, ref renderLoop, results);
		}

		// Token: 0x06002645 RID: 9797
		[FreeFunction("InitializeSortSettings")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void InitializeSortSettings(Camera camera, out SortingSettings sortingSettings);

		// Token: 0x06002646 RID: 9798 RVA: 0x00041B6F File Offset: 0x0003FD6F
		private void Submit_Internal()
		{
			ScriptableRenderContext.Submit_Internal_Injected(ref this);
		}

		// Token: 0x06002647 RID: 9799 RVA: 0x00041B77 File Offset: 0x0003FD77
		private bool SubmitForRenderPassValidation_Internal()
		{
			return ScriptableRenderContext.SubmitForRenderPassValidation_Internal_Injected(ref this);
		}

		// Token: 0x06002648 RID: 9800 RVA: 0x00041B7F File Offset: 0x0003FD7F
		private void GetCameras_Internal(Type listType, object resultList)
		{
			ScriptableRenderContext.GetCameras_Internal_Injected(ref this, listType, resultList);
		}

		// Token: 0x06002649 RID: 9801 RVA: 0x00041B8C File Offset: 0x0003FD8C
		private void DrawRenderers_Internal(IntPtr cullResults, ref DrawingSettings drawingSettings, ref FilteringSettings filteringSettings, ShaderTagId tagName, bool isPassTagName, IntPtr tagValues, IntPtr stateBlocks, int stateCount)
		{
			ScriptableRenderContext.DrawRenderers_Internal_Injected(ref this, cullResults, ref drawingSettings, ref filteringSettings, ref tagName, isPassTagName, tagValues, stateBlocks, stateCount);
		}

		// Token: 0x0600264A RID: 9802 RVA: 0x00041BAC File Offset: 0x0003FDAC
		private void DrawShadows_Internal(IntPtr shadowDrawingSettings)
		{
			ScriptableRenderContext.DrawShadows_Internal_Injected(ref this, shadowDrawingSettings);
		}

		// Token: 0x0600264B RID: 9803
		[FreeFunction("PlayerEmitCanvasGeometryForCamera")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void EmitGeometryForCamera(Camera camera);

		// Token: 0x0600264C RID: 9804 RVA: 0x00041BB5 File Offset: 0x0003FDB5
		[NativeThrows]
		private void ExecuteCommandBuffer_Internal(CommandBuffer commandBuffer)
		{
			ScriptableRenderContext.ExecuteCommandBuffer_Internal_Injected(ref this, commandBuffer);
		}

		// Token: 0x0600264D RID: 9805 RVA: 0x00041BBE File Offset: 0x0003FDBE
		[NativeThrows]
		private void ExecuteCommandBufferAsync_Internal(CommandBuffer commandBuffer, ComputeQueueType queueType)
		{
			ScriptableRenderContext.ExecuteCommandBufferAsync_Internal_Injected(ref this, commandBuffer, queueType);
		}

		// Token: 0x0600264E RID: 9806 RVA: 0x00041BC8 File Offset: 0x0003FDC8
		private void SetupCameraProperties_Internal([NotNull("NullExceptionObject")] Camera camera, bool stereoSetup, int eye)
		{
			ScriptableRenderContext.SetupCameraProperties_Internal_Injected(ref this, camera, stereoSetup, eye);
		}

		// Token: 0x0600264F RID: 9807 RVA: 0x00041BD3 File Offset: 0x0003FDD3
		private void StereoEndRender_Internal([NotNull("NullExceptionObject")] Camera camera, int eye, bool isFinalPass)
		{
			ScriptableRenderContext.StereoEndRender_Internal_Injected(ref this, camera, eye, isFinalPass);
		}

		// Token: 0x06002650 RID: 9808 RVA: 0x00041BDE File Offset: 0x0003FDDE
		private void StartMultiEye_Internal([NotNull("NullExceptionObject")] Camera camera, int eye)
		{
			ScriptableRenderContext.StartMultiEye_Internal_Injected(ref this, camera, eye);
		}

		// Token: 0x06002651 RID: 9809 RVA: 0x00041BE8 File Offset: 0x0003FDE8
		private void StopMultiEye_Internal([NotNull("NullExceptionObject")] Camera camera)
		{
			ScriptableRenderContext.StopMultiEye_Internal_Injected(ref this, camera);
		}

		// Token: 0x06002652 RID: 9810 RVA: 0x00041BF1 File Offset: 0x0003FDF1
		private void DrawSkybox_Internal([NotNull("NullExceptionObject")] Camera camera)
		{
			ScriptableRenderContext.DrawSkybox_Internal_Injected(ref this, camera);
		}

		// Token: 0x06002653 RID: 9811 RVA: 0x00041BFA File Offset: 0x0003FDFA
		private void InvokeOnRenderObjectCallback_Internal()
		{
			ScriptableRenderContext.InvokeOnRenderObjectCallback_Internal_Injected(ref this);
		}

		// Token: 0x06002654 RID: 9812 RVA: 0x00041C02 File Offset: 0x0003FE02
		private void DrawGizmos_Internal([NotNull("NullExceptionObject")] Camera camera, GizmoSubset gizmoSubset)
		{
			ScriptableRenderContext.DrawGizmos_Internal_Injected(ref this, camera, gizmoSubset);
		}

		// Token: 0x06002655 RID: 9813 RVA: 0x00041C0C File Offset: 0x0003FE0C
		private void DrawWireOverlay_Impl([NotNull("NullExceptionObject")] Camera camera)
		{
			ScriptableRenderContext.DrawWireOverlay_Impl_Injected(ref this, camera);
		}

		// Token: 0x06002656 RID: 9814 RVA: 0x00041C15 File Offset: 0x0003FE15
		private void DrawUIOverlay_Internal([NotNull("NullExceptionObject")] Camera camera)
		{
			ScriptableRenderContext.DrawUIOverlay_Internal_Injected(ref this, camera);
		}

		// Token: 0x06002657 RID: 9815 RVA: 0x00041C20 File Offset: 0x0003FE20
		internal IntPtr Internal_GetPtr()
		{
			return this.m_Ptr;
		}

		// Token: 0x06002658 RID: 9816 RVA: 0x00041C38 File Offset: 0x0003FE38
		private RendererList CreateRendererList_Internal(IntPtr cullResults, ref DrawingSettings drawingSettings, ref FilteringSettings filteringSettings, ShaderTagId tagName, bool isPassTagName, IntPtr tagValues, IntPtr stateBlocks, int stateCount)
		{
			RendererList result;
			ScriptableRenderContext.CreateRendererList_Internal_Injected(ref this, cullResults, ref drawingSettings, ref filteringSettings, ref tagName, isPassTagName, tagValues, stateBlocks, stateCount, out result);
			return result;
		}

		// Token: 0x06002659 RID: 9817 RVA: 0x00041C5C File Offset: 0x0003FE5C
		private RendererList CreateShadowRendererList_Internal(IntPtr shadowDrawinSettings)
		{
			RendererList result;
			ScriptableRenderContext.CreateShadowRendererList_Internal_Injected(ref this, shadowDrawinSettings, out result);
			return result;
		}

		// Token: 0x0600265A RID: 9818 RVA: 0x00041C74 File Offset: 0x0003FE74
		private RendererList CreateSkyboxRendererList_Internal([NotNull("NullExceptionObject")] Camera camera, int mode, Matrix4x4 proj, Matrix4x4 view, Matrix4x4 projR, Matrix4x4 viewR)
		{
			RendererList result;
			ScriptableRenderContext.CreateSkyboxRendererList_Internal_Injected(ref this, camera, mode, ref proj, ref view, ref projR, ref viewR, out result);
			return result;
		}

		// Token: 0x0600265B RID: 9819 RVA: 0x00041C94 File Offset: 0x0003FE94
		private void PrepareRendererListsAsync_Internal(object rendererLists)
		{
			ScriptableRenderContext.PrepareRendererListsAsync_Internal_Injected(ref this, rendererLists);
		}

		// Token: 0x0600265C RID: 9820 RVA: 0x00041C9D File Offset: 0x0003FE9D
		private RendererListStatus QueryRendererListStatus_Internal(RendererList handle)
		{
			return ScriptableRenderContext.QueryRendererListStatus_Internal_Injected(ref this, ref handle);
		}

		// Token: 0x0600265D RID: 9821 RVA: 0x00041CA7 File Offset: 0x0003FEA7
		internal ScriptableRenderContext(IntPtr ptr)
		{
			this.m_Ptr = ptr;
		}

		// Token: 0x0600265E RID: 9822 RVA: 0x00041CB1 File Offset: 0x0003FEB1
		public void BeginRenderPass(int width, int height, int volumeDepth, int samples, NativeArray<AttachmentDescriptor> attachments, int depthAttachmentIndex = -1)
		{
			ScriptableRenderContext.BeginRenderPass_Internal(this.m_Ptr, width, height, volumeDepth, samples, (IntPtr)attachments.GetUnsafeReadOnlyPtr<AttachmentDescriptor>(), attachments.Length, depthAttachmentIndex);
		}

		// Token: 0x0600265F RID: 9823 RVA: 0x00041CDA File Offset: 0x0003FEDA
		public void BeginRenderPass(int width, int height, int samples, NativeArray<AttachmentDescriptor> attachments, int depthAttachmentIndex = -1)
		{
			ScriptableRenderContext.BeginRenderPass_Internal(this.m_Ptr, width, height, 1, samples, (IntPtr)attachments.GetUnsafeReadOnlyPtr<AttachmentDescriptor>(), attachments.Length, depthAttachmentIndex);
		}

		// Token: 0x06002660 RID: 9824 RVA: 0x00041D04 File Offset: 0x0003FF04
		public ScopedRenderPass BeginScopedRenderPass(int width, int height, int samples, NativeArray<AttachmentDescriptor> attachments, int depthAttachmentIndex = -1)
		{
			this.BeginRenderPass(width, height, samples, attachments, depthAttachmentIndex);
			return new ScopedRenderPass(this);
		}

		// Token: 0x06002661 RID: 9825 RVA: 0x00041D2F File Offset: 0x0003FF2F
		public void BeginSubPass(NativeArray<int> colors, NativeArray<int> inputs, bool isDepthReadOnly, bool isStencilReadOnly)
		{
			ScriptableRenderContext.BeginSubPass_Internal(this.m_Ptr, (IntPtr)colors.GetUnsafeReadOnlyPtr<int>(), colors.Length, (IntPtr)inputs.GetUnsafeReadOnlyPtr<int>(), inputs.Length, isDepthReadOnly, isStencilReadOnly);
		}

		// Token: 0x06002662 RID: 9826 RVA: 0x00041D65 File Offset: 0x0003FF65
		public void BeginSubPass(NativeArray<int> colors, NativeArray<int> inputs, bool isDepthStencilReadOnly = false)
		{
			ScriptableRenderContext.BeginSubPass_Internal(this.m_Ptr, (IntPtr)colors.GetUnsafeReadOnlyPtr<int>(), colors.Length, (IntPtr)inputs.GetUnsafeReadOnlyPtr<int>(), inputs.Length, isDepthStencilReadOnly, isDepthStencilReadOnly);
		}

		// Token: 0x06002663 RID: 9827 RVA: 0x00041D9A File Offset: 0x0003FF9A
		public void BeginSubPass(NativeArray<int> colors, bool isDepthReadOnly, bool isStencilReadOnly)
		{
			ScriptableRenderContext.BeginSubPass_Internal(this.m_Ptr, (IntPtr)colors.GetUnsafeReadOnlyPtr<int>(), colors.Length, IntPtr.Zero, 0, isDepthReadOnly, isStencilReadOnly);
		}

		// Token: 0x06002664 RID: 9828 RVA: 0x00041DC3 File Offset: 0x0003FFC3
		public void BeginSubPass(NativeArray<int> colors, bool isDepthStencilReadOnly = false)
		{
			ScriptableRenderContext.BeginSubPass_Internal(this.m_Ptr, (IntPtr)colors.GetUnsafeReadOnlyPtr<int>(), colors.Length, IntPtr.Zero, 0, isDepthStencilReadOnly, isDepthStencilReadOnly);
		}

		// Token: 0x06002665 RID: 9829 RVA: 0x00041DEC File Offset: 0x0003FFEC
		public ScopedSubPass BeginScopedSubPass(NativeArray<int> colors, NativeArray<int> inputs, bool isDepthReadOnly, bool isStencilReadOnly)
		{
			this.BeginSubPass(colors, inputs, isDepthReadOnly, isStencilReadOnly);
			return new ScopedSubPass(this);
		}

		// Token: 0x06002666 RID: 9830 RVA: 0x00041E18 File Offset: 0x00040018
		public ScopedSubPass BeginScopedSubPass(NativeArray<int> colors, NativeArray<int> inputs, bool isDepthStencilReadOnly = false)
		{
			this.BeginSubPass(colors, inputs, isDepthStencilReadOnly);
			return new ScopedSubPass(this);
		}

		// Token: 0x06002667 RID: 9831 RVA: 0x00041E40 File Offset: 0x00040040
		public ScopedSubPass BeginScopedSubPass(NativeArray<int> colors, bool isDepthReadOnly, bool isStencilReadOnly)
		{
			this.BeginSubPass(colors, isDepthReadOnly, isStencilReadOnly);
			return new ScopedSubPass(this);
		}

		// Token: 0x06002668 RID: 9832 RVA: 0x00041E68 File Offset: 0x00040068
		public ScopedSubPass BeginScopedSubPass(NativeArray<int> colors, bool isDepthStencilReadOnly = false)
		{
			this.BeginSubPass(colors, isDepthStencilReadOnly);
			return new ScopedSubPass(this);
		}

		// Token: 0x06002669 RID: 9833 RVA: 0x00041E8E File Offset: 0x0004008E
		public void EndSubPass()
		{
			ScriptableRenderContext.EndSubPass_Internal(this.m_Ptr);
		}

		// Token: 0x0600266A RID: 9834 RVA: 0x00041E9D File Offset: 0x0004009D
		public void EndRenderPass()
		{
			ScriptableRenderContext.EndRenderPass_Internal(this.m_Ptr);
		}

		// Token: 0x0600266B RID: 9835 RVA: 0x00041EAC File Offset: 0x000400AC
		public void Submit()
		{
			this.Submit_Internal();
		}

		// Token: 0x0600266C RID: 9836 RVA: 0x00041EB8 File Offset: 0x000400B8
		public bool SubmitForRenderPassValidation()
		{
			return this.SubmitForRenderPassValidation_Internal();
		}

		// Token: 0x0600266D RID: 9837 RVA: 0x00041ED0 File Offset: 0x000400D0
		internal void GetCameras(List<Camera> results)
		{
			this.GetCameras_Internal(typeof(Camera), results);
		}

		// Token: 0x0600266E RID: 9838 RVA: 0x00041EE8 File Offset: 0x000400E8
		public void DrawRenderers(CullingResults cullingResults, ref DrawingSettings drawingSettings, ref FilteringSettings filteringSettings)
		{
			this.DrawRenderers_Internal(cullingResults.ptr, ref drawingSettings, ref filteringSettings, ShaderTagId.none, false, IntPtr.Zero, IntPtr.Zero, 0);
		}

		// Token: 0x0600266F RID: 9839 RVA: 0x00041F18 File Offset: 0x00040118
		public unsafe void DrawRenderers(CullingResults cullingResults, ref DrawingSettings drawingSettings, ref FilteringSettings filteringSettings, ref RenderStateBlock stateBlock)
		{
			ShaderTagId shaderTagId = default(ShaderTagId);
			fixed (RenderStateBlock* ptr = &stateBlock)
			{
				RenderStateBlock* value = ptr;
				this.DrawRenderers_Internal(cullingResults.ptr, ref drawingSettings, ref filteringSettings, ShaderTagId.none, false, (IntPtr)((void*)(&shaderTagId)), (IntPtr)((void*)value), 1);
			}
		}

		// Token: 0x06002670 RID: 9840 RVA: 0x00041F60 File Offset: 0x00040160
		public void DrawRenderers(CullingResults cullingResults, ref DrawingSettings drawingSettings, ref FilteringSettings filteringSettings, NativeArray<ShaderTagId> renderTypes, NativeArray<RenderStateBlock> stateBlocks)
		{
			bool flag = renderTypes.Length != stateBlocks.Length;
			if (flag)
			{
				throw new ArgumentException(string.Format("Arrays {0} and {1} should have same length, but {2} had length {3} while {4} had length {5}.", new object[]
				{
					"renderTypes",
					"stateBlocks",
					"renderTypes",
					renderTypes.Length,
					"stateBlocks",
					stateBlocks.Length
				}));
			}
			this.DrawRenderers_Internal(cullingResults.ptr, ref drawingSettings, ref filteringSettings, ScriptableRenderContext.kRenderTypeTag, false, (IntPtr)renderTypes.GetUnsafeReadOnlyPtr<ShaderTagId>(), (IntPtr)stateBlocks.GetUnsafeReadOnlyPtr<RenderStateBlock>(), renderTypes.Length);
		}

		// Token: 0x06002671 RID: 9841 RVA: 0x00042010 File Offset: 0x00040210
		public void DrawRenderers(CullingResults cullingResults, ref DrawingSettings drawingSettings, ref FilteringSettings filteringSettings, ShaderTagId tagName, bool isPassTagName, NativeArray<ShaderTagId> tagValues, NativeArray<RenderStateBlock> stateBlocks)
		{
			bool flag = tagValues.Length != stateBlocks.Length;
			if (flag)
			{
				throw new ArgumentException(string.Format("Arrays {0} and {1} should have same length, but {2} had length {3} while {4} had length {5}.", new object[]
				{
					"tagValues",
					"stateBlocks",
					"tagValues",
					tagValues.Length,
					"stateBlocks",
					stateBlocks.Length
				}));
			}
			this.DrawRenderers_Internal(cullingResults.ptr, ref drawingSettings, ref filteringSettings, tagName, isPassTagName, (IntPtr)tagValues.GetUnsafeReadOnlyPtr<ShaderTagId>(), (IntPtr)stateBlocks.GetUnsafeReadOnlyPtr<RenderStateBlock>(), tagValues.Length);
		}

		// Token: 0x06002672 RID: 9842 RVA: 0x000420BC File Offset: 0x000402BC
		public unsafe void DrawShadows(ref ShadowDrawingSettings settings)
		{
			fixed (ShadowDrawingSettings* ptr = &settings)
			{
				ShadowDrawingSettings* value = ptr;
				this.DrawShadows_Internal((IntPtr)((void*)value));
			}
		}

		// Token: 0x06002673 RID: 9843 RVA: 0x000420E4 File Offset: 0x000402E4
		public void ExecuteCommandBuffer(CommandBuffer commandBuffer)
		{
			bool flag = commandBuffer == null;
			if (flag)
			{
				throw new ArgumentNullException("commandBuffer");
			}
			bool flag2 = commandBuffer.m_Ptr == IntPtr.Zero;
			if (flag2)
			{
				throw new ObjectDisposedException("commandBuffer");
			}
			this.ExecuteCommandBuffer_Internal(commandBuffer);
		}

		// Token: 0x06002674 RID: 9844 RVA: 0x0004212C File Offset: 0x0004032C
		public void ExecuteCommandBufferAsync(CommandBuffer commandBuffer, ComputeQueueType queueType)
		{
			bool flag = commandBuffer == null;
			if (flag)
			{
				throw new ArgumentNullException("commandBuffer");
			}
			bool flag2 = commandBuffer.m_Ptr == IntPtr.Zero;
			if (flag2)
			{
				throw new ObjectDisposedException("commandBuffer");
			}
			this.ExecuteCommandBufferAsync_Internal(commandBuffer, queueType);
		}

		// Token: 0x06002675 RID: 9845 RVA: 0x00042175 File Offset: 0x00040375
		public void SetupCameraProperties(Camera camera, bool stereoSetup = false)
		{
			this.SetupCameraProperties(camera, stereoSetup, 0);
		}

		// Token: 0x06002676 RID: 9846 RVA: 0x00042182 File Offset: 0x00040382
		public void SetupCameraProperties(Camera camera, bool stereoSetup, int eye)
		{
			this.SetupCameraProperties_Internal(camera, stereoSetup, eye);
		}

		// Token: 0x06002677 RID: 9847 RVA: 0x0004218F File Offset: 0x0004038F
		public void StereoEndRender(Camera camera)
		{
			this.StereoEndRender(camera, 0, true);
		}

		// Token: 0x06002678 RID: 9848 RVA: 0x0004219C File Offset: 0x0004039C
		public void StereoEndRender(Camera camera, int eye)
		{
			this.StereoEndRender(camera, eye, true);
		}

		// Token: 0x06002679 RID: 9849 RVA: 0x000421A9 File Offset: 0x000403A9
		public void StereoEndRender(Camera camera, int eye, bool isFinalPass)
		{
			this.StereoEndRender_Internal(camera, eye, isFinalPass);
		}

		// Token: 0x0600267A RID: 9850 RVA: 0x000421B6 File Offset: 0x000403B6
		public void StartMultiEye(Camera camera)
		{
			this.StartMultiEye(camera, 0);
		}

		// Token: 0x0600267B RID: 9851 RVA: 0x000421C2 File Offset: 0x000403C2
		public void StartMultiEye(Camera camera, int eye)
		{
			this.StartMultiEye_Internal(camera, eye);
		}

		// Token: 0x0600267C RID: 9852 RVA: 0x000421CE File Offset: 0x000403CE
		public void StopMultiEye(Camera camera)
		{
			this.StopMultiEye_Internal(camera);
		}

		// Token: 0x0600267D RID: 9853 RVA: 0x000421D9 File Offset: 0x000403D9
		public void DrawSkybox(Camera camera)
		{
			this.DrawSkybox_Internal(camera);
		}

		// Token: 0x0600267E RID: 9854 RVA: 0x000421E4 File Offset: 0x000403E4
		public void InvokeOnRenderObjectCallback()
		{
			this.InvokeOnRenderObjectCallback_Internal();
		}

		// Token: 0x0600267F RID: 9855 RVA: 0x000421EE File Offset: 0x000403EE
		public void DrawGizmos(Camera camera, GizmoSubset gizmoSubset)
		{
			this.DrawGizmos_Internal(camera, gizmoSubset);
		}

		// Token: 0x06002680 RID: 9856 RVA: 0x000421FA File Offset: 0x000403FA
		public void DrawWireOverlay(Camera camera)
		{
			this.DrawWireOverlay_Impl(camera);
		}

		// Token: 0x06002681 RID: 9857 RVA: 0x00042205 File Offset: 0x00040405
		public void DrawUIOverlay(Camera camera)
		{
			this.DrawUIOverlay_Internal(camera);
		}

		// Token: 0x06002682 RID: 9858 RVA: 0x00042210 File Offset: 0x00040410
		public unsafe CullingResults Cull(ref ScriptableCullingParameters parameters)
		{
			CullingResults result = default(CullingResults);
			ScriptableRenderContext.Internal_Cull(ref parameters, this, (IntPtr)((void*)(&result)));
			return result;
		}

		// Token: 0x06002683 RID: 9859 RVA: 0x00002669 File Offset: 0x00000869
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		internal void Validate()
		{
		}

		// Token: 0x06002684 RID: 9860 RVA: 0x00042240 File Offset: 0x00040440
		public bool Equals(ScriptableRenderContext other)
		{
			return this.m_Ptr.Equals(other.m_Ptr);
		}

		// Token: 0x06002685 RID: 9861 RVA: 0x00042268 File Offset: 0x00040468
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return !flag && obj is ScriptableRenderContext && this.Equals((ScriptableRenderContext)obj);
		}

		// Token: 0x06002686 RID: 9862 RVA: 0x000422A0 File Offset: 0x000404A0
		public override int GetHashCode()
		{
			return this.m_Ptr.GetHashCode();
		}

		// Token: 0x06002687 RID: 9863 RVA: 0x000422C0 File Offset: 0x000404C0
		public static bool operator ==(ScriptableRenderContext left, ScriptableRenderContext right)
		{
			return left.Equals(right);
		}

		// Token: 0x06002688 RID: 9864 RVA: 0x000422DC File Offset: 0x000404DC
		public static bool operator !=(ScriptableRenderContext left, ScriptableRenderContext right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06002689 RID: 9865 RVA: 0x000422FC File Offset: 0x000404FC
		public RendererList CreateRendererList(RendererListDesc desc)
		{
			RendererListParams rendererListParams = RendererListDesc.ConvertToParameters(desc);
			RendererList result = this.CreateRendererList(ref rendererListParams);
			rendererListParams.Dispose();
			return result;
		}

		// Token: 0x0600268A RID: 9866 RVA: 0x00042328 File Offset: 0x00040528
		public RendererList CreateRendererList(ref RendererListParams param)
		{
			param.Validate();
			return this.CreateRendererList_Internal(param.cullingResults.ptr, ref param.drawSettings, ref param.filteringSettings, param.tagName, param.isPassTagName, param.tagsValuePtr, param.stateBlocksPtr, param.numStateBlocks);
		}

		// Token: 0x0600268B RID: 9867 RVA: 0x00042380 File Offset: 0x00040580
		public unsafe RendererList CreateShadowRendererList(ref ShadowDrawingSettings settings)
		{
			fixed (ShadowDrawingSettings* ptr = &settings)
			{
				ShadowDrawingSettings* value = ptr;
				return this.CreateShadowRendererList_Internal((IntPtr)((void*)value));
			}
		}

		// Token: 0x0600268C RID: 9868 RVA: 0x000423A4 File Offset: 0x000405A4
		public RendererList CreateSkyboxRendererList(Camera camera, Matrix4x4 projectionMatrixL, Matrix4x4 viewMatrixL, Matrix4x4 projectionMatrixR, Matrix4x4 viewMatrixR)
		{
			return this.CreateSkyboxRendererList_Internal(camera, 2, projectionMatrixL, viewMatrixL, projectionMatrixR, viewMatrixR);
		}

		// Token: 0x0600268D RID: 9869 RVA: 0x000423C4 File Offset: 0x000405C4
		public RendererList CreateSkyboxRendererList(Camera camera, Matrix4x4 projectionMatrix, Matrix4x4 viewMatrix)
		{
			return this.CreateSkyboxRendererList_Internal(camera, 1, projectionMatrix, viewMatrix, Matrix4x4.identity, Matrix4x4.identity);
		}

		// Token: 0x0600268E RID: 9870 RVA: 0x000423EC File Offset: 0x000405EC
		public RendererList CreateSkyboxRendererList(Camera camera)
		{
			return this.CreateSkyboxRendererList_Internal(camera, 0, Matrix4x4.identity, Matrix4x4.identity, Matrix4x4.identity, Matrix4x4.identity);
		}

		// Token: 0x0600268F RID: 9871 RVA: 0x0004241A File Offset: 0x0004061A
		public void PrepareRendererListsAsync(List<RendererList> rendererLists)
		{
			this.PrepareRendererListsAsync_Internal(rendererLists);
		}

		// Token: 0x06002690 RID: 9872 RVA: 0x00042428 File Offset: 0x00040628
		public RendererListStatus QueryRendererListStatus(RendererList rendererList)
		{
			return this.QueryRendererListStatus_Internal(rendererList);
		}

		// Token: 0x06002692 RID: 9874
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_Cull_Injected(ref ScriptableCullingParameters parameters, ref ScriptableRenderContext renderLoop, IntPtr results);

		// Token: 0x06002693 RID: 9875
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Submit_Internal_Injected(ref ScriptableRenderContext _unity_self);

		// Token: 0x06002694 RID: 9876
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool SubmitForRenderPassValidation_Internal_Injected(ref ScriptableRenderContext _unity_self);

		// Token: 0x06002695 RID: 9877
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetCameras_Internal_Injected(ref ScriptableRenderContext _unity_self, Type listType, object resultList);

		// Token: 0x06002696 RID: 9878
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void DrawRenderers_Internal_Injected(ref ScriptableRenderContext _unity_self, IntPtr cullResults, ref DrawingSettings drawingSettings, ref FilteringSettings filteringSettings, ref ShaderTagId tagName, bool isPassTagName, IntPtr tagValues, IntPtr stateBlocks, int stateCount);

		// Token: 0x06002697 RID: 9879
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void DrawShadows_Internal_Injected(ref ScriptableRenderContext _unity_self, IntPtr shadowDrawingSettings);

		// Token: 0x06002698 RID: 9880
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ExecuteCommandBuffer_Internal_Injected(ref ScriptableRenderContext _unity_self, CommandBuffer commandBuffer);

		// Token: 0x06002699 RID: 9881
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ExecuteCommandBufferAsync_Internal_Injected(ref ScriptableRenderContext _unity_self, CommandBuffer commandBuffer, ComputeQueueType queueType);

		// Token: 0x0600269A RID: 9882
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetupCameraProperties_Internal_Injected(ref ScriptableRenderContext _unity_self, Camera camera, bool stereoSetup, int eye);

		// Token: 0x0600269B RID: 9883
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void StereoEndRender_Internal_Injected(ref ScriptableRenderContext _unity_self, Camera camera, int eye, bool isFinalPass);

		// Token: 0x0600269C RID: 9884
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void StartMultiEye_Internal_Injected(ref ScriptableRenderContext _unity_self, Camera camera, int eye);

		// Token: 0x0600269D RID: 9885
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void StopMultiEye_Internal_Injected(ref ScriptableRenderContext _unity_self, Camera camera);

		// Token: 0x0600269E RID: 9886
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void DrawSkybox_Internal_Injected(ref ScriptableRenderContext _unity_self, Camera camera);

		// Token: 0x0600269F RID: 9887
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InvokeOnRenderObjectCallback_Internal_Injected(ref ScriptableRenderContext _unity_self);

		// Token: 0x060026A0 RID: 9888
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void DrawGizmos_Internal_Injected(ref ScriptableRenderContext _unity_self, Camera camera, GizmoSubset gizmoSubset);

		// Token: 0x060026A1 RID: 9889
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void DrawWireOverlay_Impl_Injected(ref ScriptableRenderContext _unity_self, Camera camera);

		// Token: 0x060026A2 RID: 9890
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void DrawUIOverlay_Internal_Injected(ref ScriptableRenderContext _unity_self, Camera camera);

		// Token: 0x060026A3 RID: 9891
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CreateRendererList_Internal_Injected(ref ScriptableRenderContext _unity_self, IntPtr cullResults, ref DrawingSettings drawingSettings, ref FilteringSettings filteringSettings, ref ShaderTagId tagName, bool isPassTagName, IntPtr tagValues, IntPtr stateBlocks, int stateCount, out RendererList ret);

		// Token: 0x060026A4 RID: 9892
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CreateShadowRendererList_Internal_Injected(ref ScriptableRenderContext _unity_self, IntPtr shadowDrawinSettings, out RendererList ret);

		// Token: 0x060026A5 RID: 9893
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CreateSkyboxRendererList_Internal_Injected(ref ScriptableRenderContext _unity_self, Camera camera, int mode, ref Matrix4x4 proj, ref Matrix4x4 view, ref Matrix4x4 projR, ref Matrix4x4 viewR, out RendererList ret);

		// Token: 0x060026A6 RID: 9894
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void PrepareRendererListsAsync_Internal_Injected(ref ScriptableRenderContext _unity_self, object rendererLists);

		// Token: 0x060026A7 RID: 9895
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern RendererListStatus QueryRendererListStatus_Internal_Injected(ref ScriptableRenderContext _unity_self, ref RendererList handle);

		// Token: 0x04000E8B RID: 3723
		private static readonly ShaderTagId kRenderTypeTag = new ShaderTagId("RenderType");

		// Token: 0x04000E8C RID: 3724
		private IntPtr m_Ptr;

		// Token: 0x02000470 RID: 1136
		internal enum SkyboxXRMode
		{
			// Token: 0x04000E8E RID: 3726
			Off,
			// Token: 0x04000E8F RID: 3727
			Enabled,
			// Token: 0x04000E90 RID: 3728
			LegacySinglePass
		}
	}
}
