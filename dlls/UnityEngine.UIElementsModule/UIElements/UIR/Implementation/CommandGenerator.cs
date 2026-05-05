using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Profiling;

namespace UnityEngine.UIElements.UIR.Implementation
{
	// Token: 0x0200047A RID: 1146
	internal static class CommandGenerator
	{
		// Token: 0x0600237C RID: 9084 RVA: 0x0008A7C0 File Offset: 0x000889C0
		private static void GetVerticesTransformInfo(VisualElement ve, out Matrix4x4 transform)
		{
			bool flag = RenderChainVEData.AllocatesID(ve.renderChainData.transformID) || (ve.renderHints & RenderHints.GroupTransform) > RenderHints.None;
			if (flag)
			{
				transform = Matrix4x4.identity;
			}
			else
			{
				bool flag2 = ve.renderChainData.boneTransformAncestor != null;
				if (flag2)
				{
					bool worldTransformScaleZero = ve.renderChainData.boneTransformAncestor.renderChainData.worldTransformScaleZero;
					if (worldTransformScaleZero)
					{
						CommandGenerator.ComputeTransformMatrix(ve, ve.renderChainData.boneTransformAncestor, out transform);
					}
					else
					{
						VisualElement.MultiplyMatrix34(ve.renderChainData.boneTransformAncestor.worldTransformInverse, ve.worldTransformRef, out transform);
					}
				}
				else
				{
					bool flag3 = ve.renderChainData.groupTransformAncestor != null;
					if (flag3)
					{
						bool worldTransformScaleZero2 = ve.renderChainData.groupTransformAncestor.renderChainData.worldTransformScaleZero;
						if (worldTransformScaleZero2)
						{
							CommandGenerator.ComputeTransformMatrix(ve, ve.renderChainData.groupTransformAncestor, out transform);
						}
						else
						{
							VisualElement.MultiplyMatrix34(ve.renderChainData.groupTransformAncestor.worldTransformInverse, ve.worldTransformRef, out transform);
						}
					}
					else
					{
						transform = ve.worldTransform;
					}
				}
			}
			transform.m22 = 1f;
		}

		// Token: 0x0600237D RID: 9085 RVA: 0x0008A8E4 File Offset: 0x00088AE4
		internal static void ComputeTransformMatrix(VisualElement ve, VisualElement ancestor, out Matrix4x4 result)
		{
			ve.GetPivotedMatrixWithLayout(out result);
			VisualElement parent = ve.hierarchy.parent;
			bool flag = parent == null || ancestor == parent;
			if (!flag)
			{
				Matrix4x4 matrix4x = default(Matrix4x4);
				bool flag2 = true;
				do
				{
					Matrix4x4 matrix4x2;
					parent.GetPivotedMatrixWithLayout(out matrix4x2);
					bool flag3 = flag2;
					if (flag3)
					{
						VisualElement.MultiplyMatrix34(ref matrix4x2, ref result, out matrix4x);
					}
					else
					{
						VisualElement.MultiplyMatrix34(ref matrix4x2, ref matrix4x, out result);
					}
					parent = parent.hierarchy.parent;
					flag2 = !flag2;
				}
				while (parent != null && ancestor != parent);
				bool flag4 = !flag2;
				if (flag4)
				{
					result = matrix4x;
				}
			}
		}

		// Token: 0x0600237E RID: 9086 RVA: 0x0008A988 File Offset: 0x00088B88
		private static bool IsParentOrAncestorOf(this VisualElement ve, VisualElement child)
		{
			while (child.hierarchy.parent != null)
			{
				bool flag = child.hierarchy.parent == ve;
				if (flag)
				{
					return true;
				}
				child = child.hierarchy.parent;
			}
			return false;
		}

		// Token: 0x0600237F RID: 9087 RVA: 0x0008A9E0 File Offset: 0x00088BE0
		public static UIRStylePainter.ClosingInfo PaintElement(RenderChain renderChain, VisualElement ve, ref ChainBuilderStats stats)
		{
			UIRenderDevice device = renderChain.device;
			bool flag = ve.renderChainData.clipMethod == ClipMethod.Stencil;
			bool flag2 = ve.renderChainData.clipMethod == ClipMethod.Scissor;
			bool flag3 = (ve.renderHints & RenderHints.GroupTransform) > RenderHints.None;
			bool flag4 = (UIRUtility.IsElementSelfHidden(ve) && !flag && !flag2 && !flag3) || ve.renderChainData.isHierarchyHidden;
			UIRStylePainter.ClosingInfo result;
			if (flag4)
			{
				bool flag5 = ve.renderChainData.data != null;
				if (flag5)
				{
					device.Free(ve.renderChainData.data);
					ve.renderChainData.data = null;
				}
				bool flag6 = ve.renderChainData.firstCommand != null;
				if (flag6)
				{
					CommandGenerator.ResetCommands(renderChain, ve);
				}
				renderChain.ResetTextures(ve);
				UIRStylePainter.ClosingInfo closingInfo = default(UIRStylePainter.ClosingInfo);
				result = closingInfo;
			}
			else
			{
				RenderChainCommand firstCommand = ve.renderChainData.firstCommand;
				RenderChainCommand renderChainCommand = (firstCommand != null) ? firstCommand.prev : null;
				RenderChainCommand lastCommand = ve.renderChainData.lastCommand;
				RenderChainCommand renderChainCommand2 = (lastCommand != null) ? lastCommand.next : null;
				bool flag7 = ve.renderChainData.firstClosingCommand != null && renderChainCommand2 == ve.renderChainData.firstClosingCommand;
				bool flag8 = flag7;
				RenderChainCommand renderChainCommand4;
				RenderChainCommand renderChainCommand3;
				if (flag8)
				{
					renderChainCommand2 = ve.renderChainData.lastClosingCommand.next;
					renderChainCommand3 = (renderChainCommand4 = null);
				}
				else
				{
					RenderChainCommand firstClosingCommand = ve.renderChainData.firstClosingCommand;
					renderChainCommand4 = ((firstClosingCommand != null) ? firstClosingCommand.prev : null);
					RenderChainCommand lastClosingCommand = ve.renderChainData.lastClosingCommand;
					renderChainCommand3 = ((lastClosingCommand != null) ? lastClosingCommand.next : null);
				}
				Debug.Assert(((renderChainCommand != null) ? renderChainCommand.owner : null) != ve);
				Debug.Assert(((renderChainCommand2 != null) ? renderChainCommand2.owner : null) != ve);
				Debug.Assert(((renderChainCommand4 != null) ? renderChainCommand4.owner : null) != ve);
				Debug.Assert(((renderChainCommand3 != null) ? renderChainCommand3.owner : null) != ve);
				CommandGenerator.ResetCommands(renderChain, ve);
				renderChain.ResetTextures(ve);
				UIRStylePainter painter = renderChain.painter;
				painter.Begin(ve);
				bool visible = ve.visible;
				if (visible)
				{
					painter.DrawVisualElementBackground();
					painter.DrawVisualElementBorder();
					painter.ApplyVisualElementClipping();
					CommandGenerator.InvokeGenerateVisualContent(ve, painter.meshGenerationContext);
				}
				else
				{
					bool flag9 = flag2 || flag;
					if (flag9)
					{
						painter.ApplyVisualElementClipping();
					}
				}
				MeshHandle meshHandle = ve.renderChainData.data;
				bool flag10 = (long)painter.totalVertices > (long)((ulong)device.maxVerticesPerPage);
				if (flag10)
				{
					Debug.LogError(string.Format("A {0} must not allocate more than {1} vertices.", "VisualElement", device.maxVerticesPerPage));
					bool flag11 = meshHandle != null;
					if (flag11)
					{
						device.Free(meshHandle);
						meshHandle = null;
					}
					renderChain.ResetTextures(ve);
					painter.Reset();
					painter.Begin(ve);
				}
				List<UIRStylePainter.Entry> entries = painter.entries;
				bool flag12 = entries.Count > 0;
				if (flag12)
				{
					NativeSlice<Vertex> nativeSlice = default(NativeSlice<Vertex>);
					NativeSlice<ushort> thisSlice = default(NativeSlice<ushort>);
					ushort num = 0;
					bool flag13 = painter.totalVertices > 0;
					if (flag13)
					{
						CommandGenerator.UpdateOrAllocate(ref meshHandle, painter.totalVertices, painter.totalIndices, device, out nativeSlice, out thisSlice, out num, ref stats);
					}
					int num2 = 0;
					int num3 = 0;
					RenderChainCommand renderChainCommand5 = renderChainCommand;
					RenderChainCommand renderChainCommand6 = renderChainCommand2;
					bool flag14 = renderChainCommand == null && renderChainCommand2 == null;
					if (flag14)
					{
						CommandGenerator.FindCommandInsertionPoint(ve, out renderChainCommand5, out renderChainCommand6);
					}
					bool flag15 = false;
					Matrix4x4 identity = Matrix4x4.identity;
					Color32 xformClipPages = new Color32(0, 0, 0, 0);
					Color32 ids = new Color32(0, 0, 0, 0);
					Color32 addFlags = new Color32(0, 0, 0, 0);
					Color32 opacityPage = new Color32(0, 0, 0, 0);
					Color32 textCoreSettingsPage = new Color32(0, 0, 0, 0);
					int num4 = -1;
					int num5 = -1;
					foreach (UIRStylePainter.Entry entry in painter.entries)
					{
						NativeSlice<Vertex> vertices = entry.vertices;
						bool flag16;
						if (vertices.Length > 0)
						{
							NativeSlice<ushort> indices = entry.indices;
							flag16 = (indices.Length > 0);
						}
						else
						{
							flag16 = false;
						}
						bool flag17 = flag16;
						if (flag17)
						{
							bool flag18 = !flag15;
							if (flag18)
							{
								flag15 = true;
								CommandGenerator.GetVerticesTransformInfo(ve, out identity);
								ve.renderChainData.verticesSpace = identity;
							}
							Color32 color = renderChain.shaderInfoAllocator.TransformAllocToVertexData(ve.renderChainData.transformID);
							Color32 color2 = renderChain.shaderInfoAllocator.OpacityAllocToVertexData(ve.renderChainData.opacityID);
							Color32 color3 = renderChain.shaderInfoAllocator.TextCoreSettingsToVertexData(ve.renderChainData.textCoreSettingsID);
							xformClipPages.r = color.r;
							xformClipPages.g = color.g;
							ids.r = color.b;
							opacityPage.r = color2.r;
							opacityPage.g = color2.g;
							ids.b = color2.b;
							bool isTextEntry = entry.isTextEntry;
							if (isTextEntry)
							{
								textCoreSettingsPage.r = color3.r;
								textCoreSettingsPage.g = color3.g;
								ids.a = color3.b;
							}
							Color32 color4 = renderChain.shaderInfoAllocator.ClipRectAllocToVertexData(entry.clipRectID);
							xformClipPages.b = color4.r;
							xformClipPages.a = color4.g;
							ids.g = color4.b;
							addFlags.r = (byte)entry.addFlags;
							TextureId texture = entry.texture;
							float textureId = texture.ConvertToGpu();
							NativeSlice<Vertex> thisSlice2 = nativeSlice;
							int start = num2;
							vertices = entry.vertices;
							NativeSlice<Vertex> nativeSlice2 = thisSlice2.Slice(start, vertices.Length);
							bool uvIsDisplacement = entry.uvIsDisplacement;
							if (uvIsDisplacement)
							{
								bool flag19 = num4 < 0;
								if (flag19)
								{
									num4 = num2;
									int num6 = num2;
									vertices = entry.vertices;
									num5 = num6 + vertices.Length;
								}
								else
								{
									bool flag20 = num5 == num2;
									if (flag20)
									{
										int num7 = num5;
										vertices = entry.vertices;
										num5 = num7 + vertices.Length;
									}
									else
									{
										ve.renderChainData.disableNudging = true;
									}
								}
							}
							NativeSlice<ushort> indices = entry.indices;
							int length = indices.Length;
							int indexOffset = num2 + (int)num;
							NativeSlice<ushort> nativeSlice3 = thisSlice.Slice(num3, length);
							bool flag21 = UIRUtility.ShapeWindingIsClockwise(entry.maskDepth, entry.stencilRef);
							bool worldFlipsWinding = ve.renderChainData.worldFlipsWinding;
							ConvertMeshJobData convertMeshJobData = new ConvertMeshJobData
							{
								vertSrc = (IntPtr)entry.vertices.GetUnsafePtr<Vertex>(),
								vertDst = (IntPtr)nativeSlice2.GetUnsafePtr<Vertex>(),
								vertCount = nativeSlice2.Length,
								transform = identity,
								transformUVs = (entry.uvIsDisplacement ? 1 : 0),
								xformClipPages = xformClipPages,
								ids = ids,
								addFlags = addFlags,
								opacityPage = opacityPage,
								textCoreSettingsPage = textCoreSettingsPage,
								isText = (entry.isTextEntry ? 1 : 0),
								textureId = textureId,
								indexSrc = (IntPtr)entry.indices.GetUnsafePtr<ushort>(),
								indexDst = (IntPtr)nativeSlice3.GetUnsafePtr<ushort>(),
								indexCount = nativeSlice3.Length,
								indexOffset = indexOffset,
								flipIndices = ((flag21 == worldFlipsWinding) ? 1 : 0)
							};
							renderChain.jobManager.Add(ref convertMeshJobData);
							bool isClipRegisterEntry = entry.isClipRegisterEntry;
							if (isClipRegisterEntry)
							{
								painter.LandClipRegisterMesh(nativeSlice2, nativeSlice3, indexOffset);
							}
							RenderChainCommand renderChainCommand7 = CommandGenerator.InjectMeshDrawCommand(renderChain, ve, ref renderChainCommand5, ref renderChainCommand6, meshHandle, length, num3, entry.material, entry.texture, entry.stencilRef);
							bool isTextEntry2 = entry.isTextEntry;
							if (isTextEntry2)
							{
								renderChainCommand7.state.sdfScale = entry.fontTexSDFScale;
							}
							int num8 = num2;
							vertices = entry.vertices;
							num2 = num8 + vertices.Length;
							num3 += length;
						}
						else
						{
							bool flag22 = entry.customCommand != null;
							if (flag22)
							{
								CommandGenerator.InjectCommandInBetween(renderChain, entry.customCommand, ref renderChainCommand5, ref renderChainCommand6);
							}
							else
							{
								Debug.Assert(false);
							}
						}
					}
					bool flag23 = !ve.renderChainData.disableNudging && num4 >= 0;
					if (flag23)
					{
						ve.renderChainData.displacementUVStart = num4;
						ve.renderChainData.displacementUVEnd = num5;
					}
				}
				else
				{
					bool flag24 = meshHandle != null;
					if (flag24)
					{
						device.Free(meshHandle);
						meshHandle = null;
					}
				}
				ve.renderChainData.data = meshHandle;
				UIRStylePainter.ClosingInfo closingInfo = painter.closingInfo;
				bool flag25 = closingInfo.clipperRegisterIndices.Length == 0 && ve.renderChainData.closingData != null;
				if (flag25)
				{
					device.Free(ve.renderChainData.closingData);
					ve.renderChainData.closingData = null;
				}
				bool needsClosing = painter.closingInfo.needsClosing;
				if (needsClosing)
				{
					RenderChainCommand renderChainCommand8 = renderChainCommand4;
					RenderChainCommand renderChainCommand9 = renderChainCommand3;
					bool flag26 = flag7;
					if (flag26)
					{
						renderChainCommand8 = ve.renderChainData.lastCommand;
						renderChainCommand9 = renderChainCommand8.next;
					}
					else
					{
						bool flag27 = renderChainCommand8 == null && renderChainCommand9 == null;
						if (flag27)
						{
							CommandGenerator.FindClosingCommandInsertionPoint(ve, out renderChainCommand8, out renderChainCommand9);
						}
					}
					bool popDefaultMaterial = painter.closingInfo.PopDefaultMaterial;
					if (popDefaultMaterial)
					{
						RenderChainCommand renderChainCommand10 = renderChain.AllocCommand();
						renderChainCommand10.type = CommandType.PopDefaultMaterial;
						renderChainCommand10.closing = true;
						renderChainCommand10.owner = ve;
						CommandGenerator.InjectClosingCommandInBetween(renderChain, renderChainCommand10, ref renderChainCommand8, ref renderChainCommand9);
					}
					bool blitAndPopRenderTexture = painter.closingInfo.blitAndPopRenderTexture;
					if (blitAndPopRenderTexture)
					{
						RenderChainCommand renderChainCommand11 = renderChain.AllocCommand();
						renderChainCommand11.type = CommandType.BlitToPreviousRT;
						renderChainCommand11.closing = true;
						renderChainCommand11.owner = ve;
						renderChainCommand11.state.material = CommandGenerator.GetBlitMaterial(ve.subRenderTargetMode);
						Debug.Assert(renderChainCommand11.state.material != null);
						CommandGenerator.InjectClosingCommandInBetween(renderChain, renderChainCommand11, ref renderChainCommand8, ref renderChainCommand9);
						RenderChainCommand renderChainCommand12 = renderChain.AllocCommand();
						renderChainCommand12.type = CommandType.PopRenderTexture;
						renderChainCommand12.closing = true;
						renderChainCommand12.owner = ve;
						CommandGenerator.InjectClosingCommandInBetween(renderChain, renderChainCommand12, ref renderChainCommand8, ref renderChainCommand9);
					}
					closingInfo = painter.closingInfo;
					bool flag28 = closingInfo.clipperRegisterIndices.Length > 0;
					if (flag28)
					{
						RenderChainCommand cmd = CommandGenerator.InjectClosingMeshDrawCommand(renderChain, ve, ref renderChainCommand8, ref renderChainCommand9, null, 0, 0, null, TextureId.invalid, painter.closingInfo.maskStencilRef);
						painter.LandClipUnregisterMeshDrawCommand(cmd);
					}
					bool popViewMatrix = painter.closingInfo.popViewMatrix;
					if (popViewMatrix)
					{
						RenderChainCommand renderChainCommand13 = renderChain.AllocCommand();
						renderChainCommand13.type = CommandType.PopView;
						renderChainCommand13.closing = true;
						renderChainCommand13.owner = ve;
						CommandGenerator.InjectClosingCommandInBetween(renderChain, renderChainCommand13, ref renderChainCommand8, ref renderChainCommand9);
					}
					bool popScissorClip = painter.closingInfo.popScissorClip;
					if (popScissorClip)
					{
						RenderChainCommand renderChainCommand14 = renderChain.AllocCommand();
						renderChainCommand14.type = CommandType.PopScissor;
						renderChainCommand14.closing = true;
						renderChainCommand14.owner = ve;
						CommandGenerator.InjectClosingCommandInBetween(renderChain, renderChainCommand14, ref renderChainCommand8, ref renderChainCommand9);
					}
				}
				Debug.Assert(ve.renderChainData.closingData == null || ve.renderChainData.data != null);
				UIRStylePainter.ClosingInfo closingInfo2 = painter.closingInfo;
				painter.Reset();
				result = closingInfo2;
			}
			return result;
		}

		// Token: 0x06002380 RID: 9088 RVA: 0x0008B4E4 File Offset: 0x000896E4
		private static void InvokeGenerateVisualContent(VisualElement ve, MeshGenerationContext ctx)
		{
			Painter2D.isPainterActive = true;
			ve.InvokeGenerateVisualContent(ctx);
			Painter2D.isPainterActive = false;
		}

		// Token: 0x06002381 RID: 9089 RVA: 0x0008B500 File Offset: 0x00089700
		private static Material CreateBlitShader(float colorConversion)
		{
			bool flag = CommandGenerator.s_blitShader == null;
			if (flag)
			{
				CommandGenerator.s_blitShader = Shader.Find(Shaders.k_ColorConversionBlit);
			}
			Debug.Assert(CommandGenerator.s_blitShader != null, "UI Tollkit Render Event: Shader Not found");
			Material material = new Material(CommandGenerator.s_blitShader);
			material.hideFlags |= HideFlags.DontSaveInEditor;
			material.SetFloat("_ColorConversion", colorConversion);
			return material;
		}

		// Token: 0x06002382 RID: 9090 RVA: 0x0008B570 File Offset: 0x00089770
		private static Material GetBlitMaterial(VisualElement.RenderTargetMode mode)
		{
			Material result;
			switch (mode)
			{
			case VisualElement.RenderTargetMode.NoColorConversion:
			{
				bool flag = CommandGenerator.s_blitMaterial_NoChange == null;
				if (flag)
				{
					CommandGenerator.s_blitMaterial_NoChange = CommandGenerator.CreateBlitShader(0f);
				}
				result = CommandGenerator.s_blitMaterial_NoChange;
				break;
			}
			case VisualElement.RenderTargetMode.LinearToGamma:
			{
				bool flag2 = CommandGenerator.s_blitMaterial_LinearToGamma == null;
				if (flag2)
				{
					CommandGenerator.s_blitMaterial_LinearToGamma = CommandGenerator.CreateBlitShader(1f);
				}
				result = CommandGenerator.s_blitMaterial_LinearToGamma;
				break;
			}
			case VisualElement.RenderTargetMode.GammaToLinear:
			{
				bool flag3 = CommandGenerator.s_blitMaterial_GammaToLinear == null;
				if (flag3)
				{
					CommandGenerator.s_blitMaterial_GammaToLinear = CommandGenerator.CreateBlitShader(-1f);
				}
				result = CommandGenerator.s_blitMaterial_GammaToLinear;
				break;
			}
			default:
				Debug.LogError(string.Format("No Shader for Unsupported RenderTargetMode: {0}", mode));
				result = null;
				break;
			}
			return result;
		}

		// Token: 0x06002383 RID: 9091 RVA: 0x0008B62C File Offset: 0x0008982C
		public static void ClosePaintElement(VisualElement ve, UIRStylePainter.ClosingInfo closingInfo, RenderChain renderChain, ref ChainBuilderStats stats)
		{
			bool flag = closingInfo.clipperRegisterIndices.Length > 0;
			if (flag)
			{
				NativeSlice<Vertex> nativeSlice = default(NativeSlice<Vertex>);
				NativeSlice<ushort> nativeSlice2 = default(NativeSlice<ushort>);
				ushort num = 0;
				CommandGenerator.UpdateOrAllocate(ref ve.renderChainData.closingData, closingInfo.clipperRegisterVertices.Length, closingInfo.clipperRegisterIndices.Length, renderChain.device, out nativeSlice, out nativeSlice2, out num, ref stats);
				CopyClosingMeshJobData copyClosingMeshJobData = new CopyClosingMeshJobData
				{
					vertSrc = (IntPtr)closingInfo.clipperRegisterVertices.GetUnsafePtr<Vertex>(),
					vertDst = (IntPtr)nativeSlice.GetUnsafePtr<Vertex>(),
					vertCount = nativeSlice.Length,
					indexSrc = (IntPtr)closingInfo.clipperRegisterIndices.GetUnsafePtr<ushort>(),
					indexDst = (IntPtr)nativeSlice2.GetUnsafePtr<ushort>(),
					indexCount = nativeSlice2.Length,
					indexOffset = (int)num - closingInfo.clipperRegisterIndexOffset
				};
				renderChain.jobManager.Add(ref copyClosingMeshJobData);
				closingInfo.clipUnregisterDrawCommand.mesh = ve.renderChainData.closingData;
				closingInfo.clipUnregisterDrawCommand.indexCount = nativeSlice2.Length;
			}
		}

		// Token: 0x06002384 RID: 9092 RVA: 0x0008B75C File Offset: 0x0008995C
		private static void UpdateOrAllocate(ref MeshHandle data, int vertexCount, int indexCount, UIRenderDevice device, out NativeSlice<Vertex> verts, out NativeSlice<ushort> indices, out ushort indexOffset, ref ChainBuilderStats stats)
		{
			bool flag = data != null;
			if (flag)
			{
				bool flag2 = (ulong)data.allocVerts.size >= (ulong)((long)vertexCount) && (ulong)data.allocIndices.size >= (ulong)((long)indexCount);
				if (flag2)
				{
					device.Update(data, (uint)vertexCount, (uint)indexCount, out verts, out indices, out indexOffset);
					stats.updatedMeshAllocations += 1U;
				}
				else
				{
					device.Free(data);
					data = device.Allocate((uint)vertexCount, (uint)indexCount, out verts, out indices, out indexOffset);
					stats.newMeshAllocations += 1U;
				}
			}
			else
			{
				data = device.Allocate((uint)vertexCount, (uint)indexCount, out verts, out indices, out indexOffset);
				stats.newMeshAllocations += 1U;
			}
		}

		// Token: 0x06002385 RID: 9093 RVA: 0x0008B80C File Offset: 0x00089A0C
		private static void CopyTriangleIndicesFlipWindingOrder(NativeSlice<ushort> source, NativeSlice<ushort> target, int indexOffset)
		{
			Debug.Assert(source != target);
			int length = source.Length;
			for (int i = 0; i < length; i += 3)
			{
				ushort value = (ushort)((int)source[i] + indexOffset);
				target[i] = (ushort)((int)source[i + 1] + indexOffset);
				target[i + 1] = value;
				target[i + 2] = (ushort)((int)source[i + 2] + indexOffset);
			}
		}

		// Token: 0x06002386 RID: 9094 RVA: 0x0008B888 File Offset: 0x00089A88
		private static void CopyTriangleIndices(NativeSlice<ushort> source, NativeSlice<ushort> target, int indexOffset)
		{
			int length = source.Length;
			for (int i = 0; i < length; i++)
			{
				target[i] = (ushort)((int)source[i] + indexOffset);
			}
		}

		// Token: 0x06002387 RID: 9095 RVA: 0x0008B8C4 File Offset: 0x00089AC4
		public static void UpdateOpacityId(VisualElement ve, RenderChain renderChain)
		{
			bool flag = ve.renderChainData.data != null;
			if (flag)
			{
				CommandGenerator.DoUpdateOpacityId(ve, renderChain, ve.renderChainData.data);
			}
			bool flag2 = ve.renderChainData.closingData != null;
			if (flag2)
			{
				CommandGenerator.DoUpdateOpacityId(ve, renderChain, ve.renderChainData.closingData);
			}
		}

		// Token: 0x06002388 RID: 9096 RVA: 0x0008B91C File Offset: 0x00089B1C
		private static void DoUpdateOpacityId(VisualElement ve, RenderChain renderChain, MeshHandle mesh)
		{
			int size = (int)mesh.allocVerts.size;
			NativeSlice<Vertex> oldVerts = mesh.allocPage.vertices.cpuData.Slice((int)mesh.allocVerts.start, size);
			NativeSlice<Vertex> newVerts;
			renderChain.device.Update(mesh, (uint)size, out newVerts);
			Color32 opacityData = renderChain.shaderInfoAllocator.OpacityAllocToVertexData(ve.renderChainData.opacityID);
			renderChain.opacityIdAccelerator.CreateJob(oldVerts, newVerts, opacityData, size);
		}

		// Token: 0x06002389 RID: 9097 RVA: 0x0008B990 File Offset: 0x00089B90
		public static bool NudgeVerticesToNewSpace(VisualElement ve, RenderChain renderChain, UIRenderDevice device)
		{
			Debug.Assert(!ve.renderChainData.disableNudging);
			Matrix4x4 matrix4x;
			CommandGenerator.GetVerticesTransformInfo(ve, out matrix4x);
			Matrix4x4 matrix4x2 = matrix4x * ve.renderChainData.verticesSpace.inverse;
			Matrix4x4 matrix4x3 = matrix4x2 * ve.renderChainData.verticesSpace;
			float num = Mathf.Abs(matrix4x.m00 - matrix4x3.m00);
			num += Mathf.Abs(matrix4x.m01 - matrix4x3.m01);
			num += Mathf.Abs(matrix4x.m02 - matrix4x3.m02);
			num += Mathf.Abs(matrix4x.m03 - matrix4x3.m03);
			num += Mathf.Abs(matrix4x.m10 - matrix4x3.m10);
			num += Mathf.Abs(matrix4x.m11 - matrix4x3.m11);
			num += Mathf.Abs(matrix4x.m12 - matrix4x3.m12);
			num += Mathf.Abs(matrix4x.m13 - matrix4x3.m13);
			num += Mathf.Abs(matrix4x.m20 - matrix4x3.m20);
			num += Mathf.Abs(matrix4x.m21 - matrix4x3.m21);
			num += Mathf.Abs(matrix4x.m22 - matrix4x3.m22);
			num += Mathf.Abs(matrix4x.m23 - matrix4x3.m23);
			bool flag = num > 0.0001f;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				ve.renderChainData.verticesSpace = matrix4x;
				NudgeJobData nudgeJobData = new NudgeJobData
				{
					vertsBeforeUVDisplacement = ve.renderChainData.displacementUVStart,
					vertsAfterUVDisplacement = ve.renderChainData.displacementUVEnd,
					transform = matrix4x2
				};
				CommandGenerator.PrepareNudgeVertices(ve, device, ve.renderChainData.data, out nudgeJobData.src, out nudgeJobData.dst, out nudgeJobData.count);
				bool flag2 = ve.renderChainData.closingData != null;
				if (flag2)
				{
					CommandGenerator.PrepareNudgeVertices(ve, device, ve.renderChainData.closingData, out nudgeJobData.closingSrc, out nudgeJobData.closingDst, out nudgeJobData.closingCount);
				}
				renderChain.jobManager.Add(ref nudgeJobData);
				result = true;
			}
			return result;
		}

		// Token: 0x0600238A RID: 9098 RVA: 0x0008BBB4 File Offset: 0x00089DB4
		private static void PrepareNudgeVertices(VisualElement ve, UIRenderDevice device, MeshHandle mesh, out IntPtr src, out IntPtr dst, out int count)
		{
			int size = (int)mesh.allocVerts.size;
			NativeSlice<Vertex> nativeSlice = mesh.allocPage.vertices.cpuData.Slice((int)mesh.allocVerts.start, size);
			NativeSlice<Vertex> nativeSlice2;
			device.Update(mesh, (uint)size, out nativeSlice2);
			src = (IntPtr)nativeSlice.GetUnsafePtr<Vertex>();
			dst = (IntPtr)nativeSlice2.GetUnsafePtr<Vertex>();
			count = size;
		}

		// Token: 0x0600238B RID: 9099 RVA: 0x0008BC1C File Offset: 0x00089E1C
		private static RenderChainCommand InjectMeshDrawCommand(RenderChain renderChain, VisualElement ve, ref RenderChainCommand cmdPrev, ref RenderChainCommand cmdNext, MeshHandle mesh, int indexCount, int indexOffset, Material material, TextureId texture, int stencilRef)
		{
			RenderChainCommand renderChainCommand = renderChain.AllocCommand();
			renderChainCommand.type = CommandType.Draw;
			renderChainCommand.state = new State
			{
				material = material,
				texture = texture,
				stencilRef = stencilRef
			};
			renderChainCommand.mesh = mesh;
			renderChainCommand.indexOffset = indexOffset;
			renderChainCommand.indexCount = indexCount;
			renderChainCommand.owner = ve;
			CommandGenerator.InjectCommandInBetween(renderChain, renderChainCommand, ref cmdPrev, ref cmdNext);
			return renderChainCommand;
		}

		// Token: 0x0600238C RID: 9100 RVA: 0x0008BC90 File Offset: 0x00089E90
		private static RenderChainCommand InjectClosingMeshDrawCommand(RenderChain renderChain, VisualElement ve, ref RenderChainCommand cmdPrev, ref RenderChainCommand cmdNext, MeshHandle mesh, int indexCount, int indexOffset, Material material, TextureId texture, int stencilRef)
		{
			RenderChainCommand renderChainCommand = renderChain.AllocCommand();
			renderChainCommand.type = CommandType.Draw;
			renderChainCommand.closing = true;
			renderChainCommand.state = new State
			{
				material = material,
				texture = texture,
				stencilRef = stencilRef
			};
			renderChainCommand.mesh = mesh;
			renderChainCommand.indexOffset = indexOffset;
			renderChainCommand.indexCount = indexCount;
			renderChainCommand.owner = ve;
			CommandGenerator.InjectClosingCommandInBetween(renderChain, renderChainCommand, ref cmdPrev, ref cmdNext);
			return renderChainCommand;
		}

		// Token: 0x0600238D RID: 9101 RVA: 0x0008BD0C File Offset: 0x00089F0C
		private static void FindCommandInsertionPoint(VisualElement ve, out RenderChainCommand prev, out RenderChainCommand next)
		{
			VisualElement prev2 = ve.renderChainData.prev;
			while (prev2 != null && prev2.renderChainData.lastCommand == null)
			{
				prev2 = prev2.renderChainData.prev;
			}
			bool flag = prev2 != null && prev2.renderChainData.lastCommand != null;
			if (flag)
			{
				bool flag2 = prev2.hierarchy.parent == ve.hierarchy.parent;
				if (flag2)
				{
					prev = prev2.renderChainData.lastClosingOrLastCommand;
				}
				else
				{
					bool flag3 = prev2.IsParentOrAncestorOf(ve);
					if (flag3)
					{
						prev = prev2.renderChainData.lastCommand;
					}
					else
					{
						RenderChainCommand renderChainCommand = prev2.renderChainData.lastClosingOrLastCommand;
						bool flag5;
						do
						{
							prev = renderChainCommand;
							renderChainCommand = renderChainCommand.next;
							bool flag4 = renderChainCommand == null || renderChainCommand.owner == ve || !renderChainCommand.closing;
							if (flag4)
							{
								break;
							}
							flag5 = renderChainCommand.owner.IsParentOrAncestorOf(ve);
						}
						while (!flag5);
					}
				}
				next = prev.next;
			}
			else
			{
				VisualElement next2 = ve.renderChainData.next;
				while (next2 != null && next2.renderChainData.firstCommand == null)
				{
					next2 = next2.renderChainData.next;
				}
				next = ((next2 != null) ? next2.renderChainData.firstCommand : null);
				prev = null;
				Debug.Assert(next == null || next.prev == null);
			}
		}

		// Token: 0x0600238E RID: 9102 RVA: 0x0008BE88 File Offset: 0x0008A088
		private static void FindClosingCommandInsertionPoint(VisualElement ve, out RenderChainCommand prev, out RenderChainCommand next)
		{
			VisualElement visualElement = ve.renderChainData.next;
			while (visualElement != null && visualElement.renderChainData.firstCommand == null)
			{
				visualElement = visualElement.renderChainData.next;
			}
			bool flag = visualElement != null && visualElement.renderChainData.firstCommand != null;
			if (flag)
			{
				bool flag2 = visualElement.hierarchy.parent == ve.hierarchy.parent;
				if (flag2)
				{
					next = visualElement.renderChainData.firstCommand;
					prev = next.prev;
				}
				else
				{
					bool flag3 = ve.IsParentOrAncestorOf(visualElement);
					if (flag3)
					{
						bool flag4;
						do
						{
							prev = visualElement.renderChainData.lastClosingOrLastCommand;
							RenderChainCommand next2 = prev.next;
							visualElement = ((next2 != null) ? next2.owner : null);
							flag4 = (visualElement == null || !ve.IsParentOrAncestorOf(visualElement));
						}
						while (!flag4);
						next = prev.next;
					}
					else
					{
						prev = ve.renderChainData.lastCommand;
						next = prev.next;
					}
				}
			}
			else
			{
				prev = ve.renderChainData.lastCommand;
				next = prev.next;
			}
		}

		// Token: 0x0600238F RID: 9103 RVA: 0x0008BFB0 File Offset: 0x0008A1B0
		private static void InjectCommandInBetween(RenderChain renderChain, RenderChainCommand cmd, ref RenderChainCommand prev, ref RenderChainCommand next)
		{
			bool flag = prev != null;
			if (flag)
			{
				cmd.prev = prev;
				prev.next = cmd;
			}
			bool flag2 = next != null;
			if (flag2)
			{
				cmd.next = next;
				next.prev = cmd;
			}
			VisualElement owner = cmd.owner;
			owner.renderChainData.lastCommand = cmd;
			bool flag3 = owner.renderChainData.firstCommand == null;
			if (flag3)
			{
				owner.renderChainData.firstCommand = cmd;
			}
			renderChain.OnRenderCommandAdded(cmd);
			prev = cmd;
			next = cmd.next;
		}

		// Token: 0x06002390 RID: 9104 RVA: 0x0008C038 File Offset: 0x0008A238
		private static void InjectClosingCommandInBetween(RenderChain renderChain, RenderChainCommand cmd, ref RenderChainCommand prev, ref RenderChainCommand next)
		{
			Debug.Assert(cmd.closing);
			bool flag = prev != null;
			if (flag)
			{
				cmd.prev = prev;
				prev.next = cmd;
			}
			bool flag2 = next != null;
			if (flag2)
			{
				cmd.next = next;
				next.prev = cmd;
			}
			VisualElement owner = cmd.owner;
			owner.renderChainData.lastClosingCommand = cmd;
			bool flag3 = owner.renderChainData.firstClosingCommand == null;
			if (flag3)
			{
				owner.renderChainData.firstClosingCommand = cmd;
			}
			renderChain.OnRenderCommandAdded(cmd);
			prev = cmd;
			next = cmd.next;
		}

		// Token: 0x06002391 RID: 9105 RVA: 0x0008C0CC File Offset: 0x0008A2CC
		public static void ResetCommands(RenderChain renderChain, VisualElement ve)
		{
			bool flag = ve.renderChainData.firstCommand != null;
			if (flag)
			{
				renderChain.OnRenderCommandsRemoved(ve.renderChainData.firstCommand, ve.renderChainData.lastCommand);
			}
			RenderChainCommand renderChainCommand = (ve.renderChainData.firstCommand != null) ? ve.renderChainData.firstCommand.prev : null;
			RenderChainCommand renderChainCommand2 = (ve.renderChainData.lastCommand != null) ? ve.renderChainData.lastCommand.next : null;
			Debug.Assert(renderChainCommand == null || renderChainCommand.owner != ve);
			Debug.Assert(renderChainCommand2 == null || renderChainCommand2 == ve.renderChainData.firstClosingCommand || renderChainCommand2.owner != ve);
			bool flag2 = renderChainCommand != null;
			if (flag2)
			{
				renderChainCommand.next = renderChainCommand2;
			}
			bool flag3 = renderChainCommand2 != null;
			if (flag3)
			{
				renderChainCommand2.prev = renderChainCommand;
			}
			bool flag4 = ve.renderChainData.firstCommand != null;
			if (flag4)
			{
				RenderChainCommand renderChainCommand3;
				RenderChainCommand next;
				for (renderChainCommand3 = ve.renderChainData.firstCommand; renderChainCommand3 != ve.renderChainData.lastCommand; renderChainCommand3 = next)
				{
					next = renderChainCommand3.next;
					renderChain.FreeCommand(renderChainCommand3);
				}
				renderChain.FreeCommand(renderChainCommand3);
			}
			ve.renderChainData.firstCommand = (ve.renderChainData.lastCommand = null);
			renderChainCommand = ((ve.renderChainData.firstClosingCommand != null) ? ve.renderChainData.firstClosingCommand.prev : null);
			renderChainCommand2 = ((ve.renderChainData.lastClosingCommand != null) ? ve.renderChainData.lastClosingCommand.next : null);
			Debug.Assert(renderChainCommand == null || renderChainCommand.owner != ve);
			Debug.Assert(renderChainCommand2 == null || renderChainCommand2.owner != ve);
			bool flag5 = renderChainCommand != null;
			if (flag5)
			{
				renderChainCommand.next = renderChainCommand2;
			}
			bool flag6 = renderChainCommand2 != null;
			if (flag6)
			{
				renderChainCommand2.prev = renderChainCommand;
			}
			bool flag7 = ve.renderChainData.firstClosingCommand != null;
			if (flag7)
			{
				renderChain.OnRenderCommandsRemoved(ve.renderChainData.firstClosingCommand, ve.renderChainData.lastClosingCommand);
				RenderChainCommand renderChainCommand4;
				RenderChainCommand next2;
				for (renderChainCommand4 = ve.renderChainData.firstClosingCommand; renderChainCommand4 != ve.renderChainData.lastClosingCommand; renderChainCommand4 = next2)
				{
					next2 = renderChainCommand4.next;
					renderChain.FreeCommand(renderChainCommand4);
				}
				renderChain.FreeCommand(renderChainCommand4);
			}
			ve.renderChainData.firstClosingCommand = (ve.renderChainData.lastClosingCommand = null);
		}

		// Token: 0x0400109F RID: 4255
		private static readonly ProfilerMarker k_GenerateEntries = new ProfilerMarker("UIR.GenerateEntries");

		// Token: 0x040010A0 RID: 4256
		private static readonly ProfilerMarker k_ConvertEntriesToCommandsMarker = new ProfilerMarker("UIR.ConvertEntriesToCommands");

		// Token: 0x040010A1 RID: 4257
		private static readonly ProfilerMarker k_GenerateClosingCommandsMarker = new ProfilerMarker("UIR.GenerateClosingCommands");

		// Token: 0x040010A2 RID: 4258
		private static readonly ProfilerMarker k_NudgeVerticesMarker = new ProfilerMarker("UIR.NudgeVertices");

		// Token: 0x040010A3 RID: 4259
		private static readonly ProfilerMarker k_UpdateOpacityIdMarker = new ProfilerMarker("UIR.UpdateOpacityId");

		// Token: 0x040010A4 RID: 4260
		private static readonly ProfilerMarker k_ComputeTransformMatrixMarker = new ProfilerMarker("UIR.ComputeTransformMatrix");

		// Token: 0x040010A5 RID: 4261
		private static Material s_blitMaterial_LinearToGamma;

		// Token: 0x040010A6 RID: 4262
		private static Material s_blitMaterial_GammaToLinear;

		// Token: 0x040010A7 RID: 4263
		private static Material s_blitMaterial_NoChange;

		// Token: 0x040010A8 RID: 4264
		private static Shader s_blitShader;
	}
}
