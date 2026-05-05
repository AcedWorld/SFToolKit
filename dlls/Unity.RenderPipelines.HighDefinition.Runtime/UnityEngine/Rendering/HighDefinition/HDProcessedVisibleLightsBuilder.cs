using System;
using System.Threading;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200007D RID: 125
	internal class HDProcessedVisibleLightsBuilder
	{
		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x060006F5 RID: 1781 RVA: 0x000464DF File Offset: 0x000446DF
		public int sortedLightCounts
		{
			get
			{
				return this.m_ProcessVisibleLightCounts[0];
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x060006F6 RID: 1782 RVA: 0x000464ED File Offset: 0x000446ED
		public int sortedDirectionalLightCounts
		{
			get
			{
				return this.m_ProcessVisibleLightCounts[1];
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x060006F7 RID: 1783 RVA: 0x000464FB File Offset: 0x000446FB
		public int sortedNonDirectionalLightCounts
		{
			get
			{
				return this.sortedLightCounts - this.sortedDirectionalLightCounts;
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x060006F8 RID: 1784 RVA: 0x0004650A File Offset: 0x0004470A
		public int bakedShadowsCount
		{
			get
			{
				return this.m_ProcessVisibleLightCounts[5];
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x060006F9 RID: 1785 RVA: 0x00046518 File Offset: 0x00044718
		public NativeArray<LightBakingOutput> visibleLightBakingOutput
		{
			get
			{
				return this.m_VisibleLightBakingOutput;
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x060006FA RID: 1786 RVA: 0x00046520 File Offset: 0x00044720
		public NativeArray<LightShadowCasterMode> visibleLightShadowCasterMode
		{
			get
			{
				return this.m_VisibleLightShadowCasterMode;
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x060006FB RID: 1787 RVA: 0x00046528 File Offset: 0x00044728
		public NativeArray<int> visibleLightEntityDataIndices
		{
			get
			{
				return this.m_VisibleLightEntityDataIndices;
			}
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x060006FC RID: 1788 RVA: 0x00046530 File Offset: 0x00044730
		public NativeArray<LightVolumeType> processedLightVolumeType
		{
			get
			{
				return this.m_ProcessedLightVolumeType;
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x060006FD RID: 1789 RVA: 0x00046538 File Offset: 0x00044738
		public NativeArray<HDProcessedVisibleLight> processedEntities
		{
			get
			{
				return this.m_ProcessedEntities;
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x060006FE RID: 1790 RVA: 0x00046540 File Offset: 0x00044740
		public NativeArray<uint> sortKeys
		{
			get
			{
				return this.m_SortKeys;
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x060006FF RID: 1791 RVA: 0x00046548 File Offset: 0x00044748
		public NativeArray<uint> sortSupportArray
		{
			get
			{
				return this.m_SortSupportArray;
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000700 RID: 1792 RVA: 0x00046550 File Offset: 0x00044750
		public NativeArray<int> shadowLightsDataIndices
		{
			get
			{
				return this.m_ShadowLightsDataIndices;
			}
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x00046558 File Offset: 0x00044758
		public void Reset()
		{
			this.m_Size = 0;
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x00046564 File Offset: 0x00044764
		public void Build(HDCamera hdCamera, in CullingResults cullingResult, bool rayTracingState, HDShadowManager shadowManager, in HDShadowInitParameters inShadowInitParameters, in AOVRequestData aovRequestData, in GlobalLightLoopSettings lightLoopSettings, DebugDisplaySettings debugDisplaySettings)
		{
			this.BuildVisibleLightEntities(cullingResult);
			if (this.m_Size == 0)
			{
				return;
			}
			this.FilterVisibleLightsByAOV(aovRequestData);
			CullingResults cullingResults = cullingResult;
			this.StartProcessVisibleLightJob(hdCamera, rayTracingState, cullingResults.visibleLights, lightLoopSettings, debugDisplaySettings);
			this.CompleteProcessVisibleLightJob();
			this.SortLightKeys();
			this.ProcessShadows(hdCamera, shadowManager, inShadowInitParameters, cullingResult);
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x000465C0 File Offset: 0x000447C0
		private void ResizeArrays(int newCapacity)
		{
			this.m_Capacity = Math.Max(Math.Max(newCapacity, 32), this.m_Capacity * 2);
			ref this.m_VisibleLightEntityDataIndices.ResizeArray(this.m_Capacity);
			ref this.m_VisibleLightBakingOutput.ResizeArray(this.m_Capacity);
			ref this.m_VisibleLightShadowCasterMode.ResizeArray(this.m_Capacity);
			ref this.m_VisibleLightShadows.ResizeArray(this.m_Capacity);
			ref this.m_ProcessedLightVolumeType.ResizeArray(this.m_Capacity);
			ref this.m_ProcessedEntities.ResizeArray(this.m_Capacity);
			ref this.m_SortKeys.ResizeArray(this.m_Capacity);
			ref this.m_ShadowLightsDataIndices.ResizeArray(this.m_Capacity);
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x00046670 File Offset: 0x00044870
		public void Cleanup()
		{
			if (this.m_SortSupportArray.IsCreated)
			{
				this.m_SortSupportArray.Dispose();
			}
			if (this.m_Capacity == 0)
			{
				return;
			}
			this.m_ProcessVisibleLightCounts.Dispose();
			this.m_VisibleLightEntityDataIndices.Dispose();
			this.m_VisibleLightBakingOutput.Dispose();
			this.m_VisibleLightShadowCasterMode.Dispose();
			this.m_VisibleLightShadows.Dispose();
			this.m_ProcessedLightVolumeType.Dispose();
			this.m_ProcessedEntities.Dispose();
			this.m_SortKeys.Dispose();
			this.m_ShadowLightsDataIndices.Dispose();
			this.m_Capacity = 0;
			this.m_Size = 0;
		}

		// Token: 0x06000705 RID: 1797 RVA: 0x00046710 File Offset: 0x00044910
		public void StartProcessVisibleLightJob(HDCamera hdCamera, bool rayTracingState, NativeArray<VisibleLight> visibleLights, in GlobalLightLoopSettings lightLoopSettings, DebugDisplaySettings debugDisplaySettings)
		{
			if (this.m_Size == 0)
			{
				return;
			}
			HDLightRenderDatabase instance = HDLightRenderDatabase.instance;
			HDProcessedVisibleLightsBuilder.ProcessVisibleLightJob jobData = new HDProcessedVisibleLightsBuilder.ProcessVisibleLightJob
			{
				totalLightCounts = instance.lightCount,
				cameraPosition = hdCamera.camera.transform.position,
				pixelCount = hdCamera.actualWidth * hdCamera.actualHeight,
				enableAreaLights = (ShaderConfig.s_AreaLights != 0),
				enableRayTracing = (hdCamera.frameSettings.IsEnabled(FrameSettingsField.RayTracing) && rayTracingState),
				showDirectionalLight = debugDisplaySettings.data.lightingDebugSettings.showDirectionalLight,
				showPunctualLight = debugDisplaySettings.data.lightingDebugSettings.showPunctualLight,
				showAreaLight = debugDisplaySettings.data.lightingDebugSettings.showAreaLight,
				enableShadowMaps = hdCamera.frameSettings.IsEnabled(FrameSettingsField.ShadowMaps),
				enableScreenSpaceShadows = hdCamera.frameSettings.IsEnabled(FrameSettingsField.ScreenSpaceShadows),
				maxDirectionalLightsOnScreen = lightLoopSettings.maxDirectionalLightsOnScreen,
				maxPunctualLightsOnScreen = lightLoopSettings.maxPunctualLightsOnScreen,
				maxAreaLightsOnScreen = lightLoopSettings.maxAreaLightsOnScreen,
				debugFilterMode = debugDisplaySettings.GetDebugLightFilterMode(),
				lightData = instance.lightData,
				visibleLights = visibleLights,
				visibleLightEntityDataIndices = this.m_VisibleLightEntityDataIndices,
				visibleLightBakingOutput = this.m_VisibleLightBakingOutput,
				visibleLightShadows = this.m_VisibleLightShadows,
				processedVisibleLightCountsPtr = this.m_ProcessVisibleLightCounts,
				processedLightVolumeType = this.m_ProcessedLightVolumeType,
				processedEntities = this.m_ProcessedEntities,
				sortKeys = this.m_SortKeys,
				shadowLightsDataIndices = this.m_ShadowLightsDataIndices
			};
			this.m_ProcessVisibleLightJobHandle = jobData.Schedule(this.m_Size, 32, default(JobHandle));
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x000468E4 File Offset: 0x00044AE4
		public void CompleteProcessVisibleLightJob()
		{
			if (this.m_Size == 0)
			{
				return;
			}
			this.m_ProcessVisibleLightJobHandle.Complete();
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x000468FC File Offset: 0x00044AFC
		private void SortLightKeys()
		{
			using (new ProfilingScope(null, ProfilingSampler.Get<HDProfileId>(HDProfileId.SortVisibleLights)))
			{
				int sortedLightCounts = this.sortedLightCounts;
				if (sortedLightCounts <= 32)
				{
					CoreUnsafeUtils.InsertionSort(this.m_SortKeys, sortedLightCounts);
				}
				else if (this.m_Size <= 200)
				{
					CoreUnsafeUtils.MergeSort(this.m_SortKeys, sortedLightCounts, ref this.m_SortSupportArray);
				}
				else
				{
					CoreUnsafeUtils.RadixSort(this.m_SortKeys, sortedLightCounts, ref this.m_SortSupportArray, 8);
				}
			}
		}

		// Token: 0x06000708 RID: 1800 RVA: 0x0004698C File Offset: 0x00044B8C
		private void BuildVisibleLightEntities(in CullingResults cullResults)
		{
			this.m_Size = 0;
			if (!this.m_ProcessVisibleLightCounts.IsCreated)
			{
				int length = Enum.GetValues(typeof(HDProcessedVisibleLightsBuilder.ProcessLightsCountSlots)).Length;
				ref this.m_ProcessVisibleLightCounts.ResizeArray(length);
			}
			for (int i = 0; i < this.m_ProcessVisibleLightCounts.Length; i++)
			{
				this.m_ProcessVisibleLightCounts[i] = 0;
			}
			using (new ProfilingScope(null, ProfilingSampler.Get<HDProfileId>(HDProfileId.BuildVisibleLightEntities)))
			{
				CullingResults cullingResults = cullResults;
				if (cullingResults.visibleLights.Length != 0 && HDLightRenderDatabase.instance != null)
				{
					cullingResults = cullResults;
					if (cullingResults.visibleLights.Length > this.m_Capacity)
					{
						cullingResults = cullResults;
						this.ResizeArrays(cullingResults.visibleLights.Length);
					}
					cullingResults = cullResults;
					this.m_Size = cullingResults.visibleLights.Length;
					int num = 0;
					for (;;)
					{
						int num2 = num;
						cullingResults = cullResults;
						if (num2 >= cullingResults.visibleLights.Length)
						{
							break;
						}
						cullingResults = cullResults;
						Light light = cullingResults.visibleLights[num].light;
						int num3 = HDLightRenderDatabase.instance.FindEntityDataIndex(light);
						if (num3 == HDLightRenderDatabase.InvalidDataIndex)
						{
							HDAdditionalLightData hdadditionalLightData;
							if (light.TryGetComponent<HDAdditionalLightData>(out hdadditionalLightData))
							{
								if (!hdadditionalLightData.lightEntity.valid)
								{
									hdadditionalLightData.CreateHDLightRenderEntity(true);
								}
							}
							else
							{
								HDAdditionalLightData hdadditionalLightData2 = light.gameObject.AddComponent<HDAdditionalLightData>();
								if (hdadditionalLightData2)
								{
									HDAdditionalLightData.InitDefaultHDAdditionalLightData(hdadditionalLightData2);
								}
								if (!hdadditionalLightData2.lightEntity.valid)
								{
									hdadditionalLightData2.CreateHDLightRenderEntity(true);
								}
								num3 = HDLightRenderDatabase.instance.GetEntityDataIndex(hdadditionalLightData2.lightEntity);
							}
						}
						this.m_VisibleLightEntityDataIndices[num] = num3;
						this.m_VisibleLightBakingOutput[num] = light.bakingOutput;
						this.m_VisibleLightShadowCasterMode[num] = light.lightShadowCasterMode;
						this.m_VisibleLightShadows[num] = light.shadows;
						num++;
					}
				}
			}
		}

		// Token: 0x06000709 RID: 1801 RVA: 0x00046BCC File Offset: 0x00044DCC
		private unsafe void ProcessShadows(HDCamera hdCamera, HDShadowManager shadowManager, in HDShadowInitParameters inShadowInitParameters, in CullingResults cullResults)
		{
			int num = this.m_ProcessVisibleLightCounts[4];
			if (num == 0)
			{
				return;
			}
			using (new ProfilingScope(null, ProfilingSampler.Get<HDProfileId>(HDProfileId.ProcessShadows)))
			{
				CullingResults cullingResults = cullResults;
				NativeArray<VisibleLight> visibleLights = cullingResults.visibleLights;
				HDShadowSettings component = hdCamera.volumeStack.GetComponent<HDShadowSettings>();
				HDLightRenderEntity defaultLightEntity = HDLightRenderDatabase.instance.GetDefaultLightEntity();
				int entityDataIndex = HDLightRenderDatabase.instance.GetEntityDataIndex(defaultLightEntity);
				HDProcessedVisibleLight* unsafePtr = (HDProcessedVisibleLight*)this.m_ProcessedEntities.GetUnsafePtr<HDProcessedVisibleLight>();
				for (int i = 0; i < num; i++)
				{
					int num2 = this.m_ShadowLightsDataIndices[i];
					HDProcessedVisibleLight* ptr = unsafePtr + num2;
					cullingResults = cullResults;
					Bounds bounds;
					if (!cullingResults.GetShadowCasterBounds(num2, out bounds) || entityDataIndex == ptr->dataIndex)
					{
						ptr->shadowMapFlags = HDProcessedVisibleLightsBuilder.ShadowMapFlags.None;
					}
					else
					{
						HDAdditionalLightData hdadditionalLightData = *HDLightRenderDatabase.instance.hdAdditionalLightData[ptr->dataIndex];
						if (!(hdadditionalLightData == null))
						{
							VisibleLight visibleLight = visibleLights[num2];
							hdadditionalLightData.ReserveShadowMap(hdCamera.camera, shadowManager, component, inShadowInitParameters, visibleLight, ptr->lightType);
						}
					}
				}
			}
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x00046D08 File Offset: 0x00044F08
		private unsafe void FilterVisibleLightsByAOV(AOVRequestData aovRequest)
		{
			if (!aovRequest.hasLightFilter)
			{
				return;
			}
			for (int i = 0; i < this.m_Size; i++)
			{
				int num = this.m_VisibleLightEntityDataIndices[i];
				if (num != HDLightRenderDatabase.InvalidDataIndex)
				{
					GameObject gameObject = *HDLightRenderDatabase.instance.aovGameObjects[num];
					if (!(gameObject == null) && !aovRequest.IsLightEnabled(gameObject))
					{
						this.m_VisibleLightEntityDataIndices[i] = HDLightRenderDatabase.InvalidDataIndex;
					}
				}
			}
		}

		// Token: 0x040005F9 RID: 1529
		private const int ArrayCapacity = 32;

		// Token: 0x040005FA RID: 1530
		private NativeArray<int> m_ProcessVisibleLightCounts;

		// Token: 0x040005FB RID: 1531
		private NativeArray<int> m_VisibleLightEntityDataIndices;

		// Token: 0x040005FC RID: 1532
		private NativeArray<LightBakingOutput> m_VisibleLightBakingOutput;

		// Token: 0x040005FD RID: 1533
		private NativeArray<LightShadowCasterMode> m_VisibleLightShadowCasterMode;

		// Token: 0x040005FE RID: 1534
		private NativeArray<LightShadows> m_VisibleLightShadows;

		// Token: 0x040005FF RID: 1535
		private NativeArray<LightVolumeType> m_ProcessedLightVolumeType;

		// Token: 0x04000600 RID: 1536
		private NativeArray<HDProcessedVisibleLight> m_ProcessedEntities;

		// Token: 0x04000601 RID: 1537
		private int m_Capacity;

		// Token: 0x04000602 RID: 1538
		private int m_Size;

		// Token: 0x04000603 RID: 1539
		private NativeArray<uint> m_SortKeys;

		// Token: 0x04000604 RID: 1540
		private NativeArray<uint> m_SortSupportArray;

		// Token: 0x04000605 RID: 1541
		private NativeArray<int> m_ShadowLightsDataIndices;

		// Token: 0x04000606 RID: 1542
		private JobHandle m_ProcessVisibleLightJobHandle;

		// Token: 0x0200032D RID: 813
		[Flags]
		internal enum ShadowMapFlags
		{
			// Token: 0x040022DF RID: 8927
			None = 0,
			// Token: 0x040022E0 RID: 8928
			WillRenderShadowMap = 1,
			// Token: 0x040022E1 RID: 8929
			WillRenderScreenSpaceShadow = 2,
			// Token: 0x040022E2 RID: 8930
			WillRenderRayTracedShadow = 4
		}

		// Token: 0x0200032E RID: 814
		private enum ProcessLightsCountSlots
		{
			// Token: 0x040022E4 RID: 8932
			ProcessedLights,
			// Token: 0x040022E5 RID: 8933
			DirectionalLights,
			// Token: 0x040022E6 RID: 8934
			PunctualLights,
			// Token: 0x040022E7 RID: 8935
			AreaLightCounts,
			// Token: 0x040022E8 RID: 8936
			ShadowLights,
			// Token: 0x040022E9 RID: 8937
			BakedShadows
		}

		// Token: 0x0200032F RID: 815
		[BurstCompile]
		private struct ProcessVisibleLightJob : IJobParallelFor
		{
			// Token: 0x0600128C RID: 4748 RVA: 0x0008EB08 File Offset: 0x0008CD08
			private bool TrivialRejectLight(in VisibleLight light, int dataIndex)
			{
				if (dataIndex < 0)
				{
					return true;
				}
				VisibleLight visibleLight = light;
				float height = visibleLight.screenRect.height;
				visibleLight = light;
				return height * visibleLight.screenRect.width * (float)this.pixelCount < 1f;
			}

			// Token: 0x0600128D RID: 4749 RVA: 0x0008EB5A File Offset: 0x0008CD5A
			private unsafe int IncrementCounter(HDProcessedVisibleLightsBuilder.ProcessLightsCountSlots counterSlot)
			{
				return Interlocked.Increment(UnsafeUtility.AsRef<int>((void*)((byte*)this.processedVisibleLightCountsPtr.GetUnsafePtr<int>() + (IntPtr)counterSlot * 4)));
			}

			// Token: 0x0600128E RID: 4750 RVA: 0x0008EB76 File Offset: 0x0008CD76
			private unsafe int DecrementCounter(HDProcessedVisibleLightsBuilder.ProcessLightsCountSlots counterSlot)
			{
				return Interlocked.Decrement(UnsafeUtility.AsRef<int>((void*)((byte*)this.processedVisibleLightCountsPtr.GetUnsafePtr<int>() + (IntPtr)counterSlot * 4)));
			}

			// Token: 0x0600128F RID: 4751 RVA: 0x0008EB92 File Offset: 0x0008CD92
			private int NextOutputIndex()
			{
				return this.IncrementCounter(HDProcessedVisibleLightsBuilder.ProcessLightsCountSlots.ProcessedLights) - 1;
			}

			// Token: 0x06001290 RID: 4752 RVA: 0x0008EBA0 File Offset: 0x0008CDA0
			private bool IncrementLightCounterAndTestLimit(LightCategory lightCategory, GPULightType gpuLightType)
			{
				if (lightCategory != LightCategory.Punctual)
				{
					if (lightCategory == LightCategory.Area)
					{
						int num = this.IncrementCounter(HDProcessedVisibleLightsBuilder.ProcessLightsCountSlots.AreaLightCounts) - 1;
						if (!this.showAreaLight || num >= this.maxAreaLightsOnScreen)
						{
							this.DecrementCounter(HDProcessedVisibleLightsBuilder.ProcessLightsCountSlots.AreaLightCounts);
							return false;
						}
					}
				}
				else if (gpuLightType == GPULightType.Directional)
				{
					int num2 = this.IncrementCounter(HDProcessedVisibleLightsBuilder.ProcessLightsCountSlots.DirectionalLights) - 1;
					if (!this.showDirectionalLight || num2 >= this.maxDirectionalLightsOnScreen)
					{
						this.DecrementCounter(HDProcessedVisibleLightsBuilder.ProcessLightsCountSlots.DirectionalLights);
						return false;
					}
				}
				else
				{
					int num3 = this.IncrementCounter(HDProcessedVisibleLightsBuilder.ProcessLightsCountSlots.PunctualLights) - 1;
					if (!this.showPunctualLight || num3 >= this.maxPunctualLightsOnScreen)
					{
						this.DecrementCounter(HDProcessedVisibleLightsBuilder.ProcessLightsCountSlots.PunctualLights);
						return false;
					}
				}
				return true;
			}

			// Token: 0x06001291 RID: 4753 RVA: 0x0008EC2C File Offset: 0x0008CE2C
			private HDProcessedVisibleLightsBuilder.ShadowMapFlags EvaluateShadowState(LightShadows shadows, HDLightType lightType, GPULightType gpuLightType, AreaLightShape areaLightShape, bool useScreenSpaceShadowsVal, bool useRayTracingShadowsVal, float shadowDimmerVal, float shadowFadeDistanceVal, float distanceToCamera, LightVolumeType lightVolumeType)
			{
				HDProcessedVisibleLightsBuilder.ShadowMapFlags shadowMapFlags = HDProcessedVisibleLightsBuilder.ShadowMapFlags.None;
				if (shadows == LightShadows.None || !this.enableShadowMaps)
				{
					return shadowMapFlags;
				}
				if (shadowDimmerVal <= 0f)
				{
					return shadowMapFlags;
				}
				if (lightType != HDLightType.Directional && distanceToCamera >= shadowFadeDistanceVal)
				{
					return shadowMapFlags;
				}
				if (lightType == HDLightType.Area && areaLightShape != AreaLightShape.Rectangle)
				{
					return shadowMapFlags;
				}
				shadowMapFlags |= HDProcessedVisibleLightsBuilder.ShadowMapFlags.WillRenderShadowMap;
				if (!this.enableScreenSpaceShadows)
				{
					return shadowMapFlags;
				}
				if (this.enableRayTracing && useRayTracingShadowsVal)
				{
					bool flag = false;
					if (gpuLightType == GPULightType.Point || gpuLightType == GPULightType.Rectangle || (gpuLightType == GPULightType.Spot && lightVolumeType == LightVolumeType.Cone))
					{
						flag = true;
					}
					if (flag)
					{
						shadowMapFlags |= (HDProcessedVisibleLightsBuilder.ShadowMapFlags.WillRenderScreenSpaceShadow | HDProcessedVisibleLightsBuilder.ShadowMapFlags.WillRenderRayTracedShadow);
					}
				}
				if (useScreenSpaceShadowsVal && gpuLightType == GPULightType.Directional)
				{
					shadowMapFlags |= HDProcessedVisibleLightsBuilder.ShadowMapFlags.WillRenderScreenSpaceShadow;
					if (this.enableRayTracing && useRayTracingShadowsVal)
					{
						shadowMapFlags |= HDProcessedVisibleLightsBuilder.ShadowMapFlags.WillRenderRayTracedShadow;
					}
				}
				return shadowMapFlags;
			}

			// Token: 0x06001292 RID: 4754 RVA: 0x0008ECC0 File Offset: 0x0008CEC0
			private unsafe ref HDLightRenderData GetLightData(int dataIndex)
			{
				return UnsafeUtility.AsRef<HDLightRenderData>((void*)((byte*)this.lightData.GetUnsafePtr<HDLightRenderData>() + (IntPtr)dataIndex * (IntPtr)sizeof(HDLightRenderData)));
			}

			// Token: 0x06001293 RID: 4755 RVA: 0x0008ECDC File Offset: 0x0008CEDC
			public void Execute(int index)
			{
				VisibleLight value = this.visibleLights[index];
				int dataIndex = this.visibleLightEntityDataIndices[index];
				LightBakingOutput lightBakingOutput = this.visibleLightBakingOutput[index];
				LightShadows shadows = this.visibleLightShadows[index];
				if (this.TrivialRejectLight(value, dataIndex))
				{
					return;
				}
				ref HDLightRenderData ptr = ref this.GetLightData(dataIndex);
				if (this.enableRayTracing && !ptr.includeForRayTracing)
				{
					return;
				}
				float3 y = value.GetPosition();
				float distanceToCamera = math.distance(this.cameraPosition, y);
				HDLightType hdlightType = HDAdditionalLightData.TranslateLightType(value.lightType, ptr.pointLightType);
				LightCategory lightCategory = LightCategory.Count;
				GPULightType gpulightType = GPULightType.Point;
				AreaLightShape areaLightShape = ptr.areaLightShape;
				if (!this.enableAreaLights && hdlightType == HDLightType.Area && (areaLightShape == AreaLightShape.Rectangle || areaLightShape == AreaLightShape.Tube))
				{
					return;
				}
				SpotLightShape spotLightShape = ptr.spotLightShape;
				LightVolumeType lightVolumeType = LightVolumeType.Count;
				bool flag = lightBakingOutput.lightmapBakeType == LightmapBakeType.Mixed && lightBakingOutput.mixedLightingMode == MixedLightingMode.Shadowmask && lightBakingOutput.occlusionMaskChannel != -1;
				HDRenderPipeline.EvaluateGPULightType(hdlightType, spotLightShape, areaLightShape, ref lightCategory, ref gpulightType, ref lightVolumeType);
				if (this.debugFilterMode != DebugLightFilterMode.None && this.debugFilterMode.IsEnabledFor(gpulightType, spotLightShape))
				{
					return;
				}
				float num = (gpulightType == GPULightType.Directional) ? 1f : HDUtils.ComputeLinearDistanceFade(distanceToCamera, ptr.fadeDistance);
				float lightVolumetricDistanceFade = (gpulightType == GPULightType.Directional) ? 1f : HDUtils.ComputeLinearDistanceFade(distanceToCamera, ptr.volumetricFadeDistance);
				bool flag2 = ((ptr.lightDimmer > 0f && (ptr.affectDiffuse || ptr.affectSpecular)) || (ptr.affectVolumetric ? ptr.volumetricDimmer : 0f) > 0f) && num > 0f;
				HDProcessedVisibleLightsBuilder.ShadowMapFlags shadowMapFlags = this.EvaluateShadowState(shadows, hdlightType, gpulightType, areaLightShape, ptr.useScreenSpaceShadows, ptr.useRayTracedShadows, ptr.shadowDimmer, ptr.shadowFadeDistance, distanceToCamera, lightVolumeType);
				if (!flag2)
				{
					return;
				}
				if (!this.IncrementLightCounterAndTestLimit(lightCategory, gpulightType))
				{
					return;
				}
				int index2 = this.NextOutputIndex();
				this.sortKeys[index2] = HDGpuLightsBuilder.PackLightSortKey(lightCategory, gpulightType, lightVolumeType, index);
				this.processedLightVolumeType[index] = lightVolumeType;
				this.processedEntities[index] = new HDProcessedVisibleLight
				{
					dataIndex = dataIndex,
					gpuLightType = gpulightType,
					lightType = hdlightType,
					lightDistanceFade = num,
					lightVolumetricDistanceFade = lightVolumetricDistanceFade,
					distanceToCamera = distanceToCamera,
					shadowMapFlags = shadowMapFlags,
					isBakedShadowMask = flag
				};
				if (flag)
				{
					this.IncrementCounter(HDProcessedVisibleLightsBuilder.ProcessLightsCountSlots.BakedShadows);
				}
				if ((shadowMapFlags & HDProcessedVisibleLightsBuilder.ShadowMapFlags.WillRenderShadowMap) != HDProcessedVisibleLightsBuilder.ShadowMapFlags.None)
				{
					int index3 = this.IncrementCounter(HDProcessedVisibleLightsBuilder.ProcessLightsCountSlots.ShadowLights) - 1;
					this.shadowLightsDataIndices[index3] = index;
				}
			}

			// Token: 0x040022EA RID: 8938
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<HDLightRenderData> lightData;

			// Token: 0x040022EB RID: 8939
			[ReadOnly]
			public NativeArray<VisibleLight> visibleLights;

			// Token: 0x040022EC RID: 8940
			[ReadOnly]
			public NativeArray<int> visibleLightEntityDataIndices;

			// Token: 0x040022ED RID: 8941
			[ReadOnly]
			public NativeArray<LightBakingOutput> visibleLightBakingOutput;

			// Token: 0x040022EE RID: 8942
			[ReadOnly]
			public NativeArray<LightShadows> visibleLightShadows;

			// Token: 0x040022EF RID: 8943
			[ReadOnly]
			public int totalLightCounts;

			// Token: 0x040022F0 RID: 8944
			[ReadOnly]
			public float3 cameraPosition;

			// Token: 0x040022F1 RID: 8945
			[ReadOnly]
			public int pixelCount;

			// Token: 0x040022F2 RID: 8946
			[ReadOnly]
			public bool enableAreaLights;

			// Token: 0x040022F3 RID: 8947
			[ReadOnly]
			public bool enableRayTracing;

			// Token: 0x040022F4 RID: 8948
			[ReadOnly]
			public bool showDirectionalLight;

			// Token: 0x040022F5 RID: 8949
			[ReadOnly]
			public bool showPunctualLight;

			// Token: 0x040022F6 RID: 8950
			[ReadOnly]
			public bool showAreaLight;

			// Token: 0x040022F7 RID: 8951
			[ReadOnly]
			public bool enableShadowMaps;

			// Token: 0x040022F8 RID: 8952
			[ReadOnly]
			public bool enableScreenSpaceShadows;

			// Token: 0x040022F9 RID: 8953
			[ReadOnly]
			public int maxDirectionalLightsOnScreen;

			// Token: 0x040022FA RID: 8954
			[ReadOnly]
			public int maxPunctualLightsOnScreen;

			// Token: 0x040022FB RID: 8955
			[ReadOnly]
			public int maxAreaLightsOnScreen;

			// Token: 0x040022FC RID: 8956
			[ReadOnly]
			public DebugLightFilterMode debugFilterMode;

			// Token: 0x040022FD RID: 8957
			[WriteOnly]
			public NativeArray<int> processedVisibleLightCountsPtr;

			// Token: 0x040022FE RID: 8958
			[WriteOnly]
			public NativeArray<LightVolumeType> processedLightVolumeType;

			// Token: 0x040022FF RID: 8959
			[WriteOnly]
			public NativeArray<HDProcessedVisibleLight> processedEntities;

			// Token: 0x04002300 RID: 8960
			[WriteOnly]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<uint> sortKeys;

			// Token: 0x04002301 RID: 8961
			[WriteOnly]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<int> shadowLightsDataIndices;
		}
	}
}
