using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000C2 RID: 194
	internal class HDCachedShadowAtlas : HDShadowAtlas
	{
		// Token: 0x06000883 RID: 2179 RVA: 0x0004C4C4 File Offset: 0x0004A6C4
		public HDCachedShadowAtlas(ShadowMapType type)
		{
			this.m_PlacedShadows = new Dictionary<int, HDCachedShadowAtlas.CachedShadowRecord>(HDCachedShadowAtlas.s_InitialCapacity);
			this.m_ShadowsPendingRendering = new Dictionary<int, HDCachedShadowAtlas.CachedShadowRecord>(HDCachedShadowAtlas.s_InitialCapacity);
			this.m_ShadowsWithValidData = new Dictionary<int, int>(HDCachedShadowAtlas.s_InitialCapacity);
			this.m_TempListForPlacement = new List<HDCachedShadowAtlas.CachedShadowRecord>(HDCachedShadowAtlas.s_InitialCapacity);
			this.m_RegisteredLightDataPendingPlacement = new Dictionary<int, HDAdditionalLightData>(HDCachedShadowAtlas.s_InitialCapacity);
			this.m_RecordsPendingPlacement = new Dictionary<int, HDCachedShadowAtlas.CachedShadowRecord>(HDCachedShadowAtlas.s_InitialCapacity);
			this.m_TransformCaches = new Dictionary<int, HDCachedShadowAtlas.CachedTransform>(HDCachedShadowAtlas.s_InitialCapacity / 2);
			this.m_ShadowType = type;
		}

		// Token: 0x06000884 RID: 2180 RVA: 0x0004C558 File Offset: 0x0004A758
		public override void InitAtlas(HDShadowAtlas.HDShadowAtlasInitParameters atlasInitParams)
		{
			base.InitAtlas(atlasInitParams);
			this.m_IsACacheForShadows = true;
			this.m_AtlasResolutionInSlots = HDUtils.DivRoundUp(base.width, 64);
			this.m_AtlasSlots = new List<HDCachedShadowAtlas.SlotValue>(this.m_AtlasResolutionInSlots * this.m_AtlasResolutionInSlots);
			for (int i = 0; i < this.m_AtlasResolutionInSlots * this.m_AtlasResolutionInSlots; i++)
			{
				this.m_AtlasSlots.Add(HDCachedShadowAtlas.SlotValue.Free);
			}
			this.DefragmentAtlasAndReRender(atlasInitParams.initParams);
			this.m_CanTryPlacement = true;
			this.m_NeedOptimalPacking = true;
		}

		// Token: 0x06000885 RID: 2181 RVA: 0x0004C5DC File Offset: 0x0004A7DC
		private bool IsEntryEmpty(int x, int y)
		{
			return this.m_AtlasSlots[y * this.m_AtlasResolutionInSlots + x] == HDCachedShadowAtlas.SlotValue.Free;
		}

		// Token: 0x06000886 RID: 2182 RVA: 0x0004C5F6 File Offset: 0x0004A7F6
		private bool IsEntryFull(int x, int y)
		{
			return this.m_AtlasSlots[y * this.m_AtlasResolutionInSlots + x] > HDCachedShadowAtlas.SlotValue.Free;
		}

		// Token: 0x06000887 RID: 2183 RVA: 0x0004C610 File Offset: 0x0004A810
		private bool IsEntryTempOccupied(int x, int y)
		{
			return this.m_AtlasSlots[y * this.m_AtlasResolutionInSlots + x] == HDCachedShadowAtlas.SlotValue.TempOccupied;
		}

		// Token: 0x06000888 RID: 2184 RVA: 0x0004C62A File Offset: 0x0004A82A
		private void FillEntries(int x, int y, int numEntries)
		{
			this.MarkEntries(x, y, numEntries, HDCachedShadowAtlas.SlotValue.Occupied);
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x0004C638 File Offset: 0x0004A838
		private void MarkEntries(int x, int y, int numEntries, HDCachedShadowAtlas.SlotValue value)
		{
			for (int i = y; i < y + numEntries; i++)
			{
				for (int j = x; j < x + numEntries; j++)
				{
					this.m_AtlasSlots[i * this.m_AtlasResolutionInSlots + j] = value;
				}
			}
		}

		// Token: 0x0600088A RID: 2186 RVA: 0x0004C678 File Offset: 0x0004A878
		private bool CheckSlotAvailability(int x, int y, int numEntries)
		{
			for (int i = y; i < y + numEntries; i++)
			{
				for (int j = x; j < x + numEntries; j++)
				{
					if (j >= this.m_AtlasResolutionInSlots || i >= this.m_AtlasResolutionInSlots || this.IsEntryFull(j, i))
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x0600088B RID: 2187 RVA: 0x0004C6C0 File Offset: 0x0004A8C0
		internal bool FindSlotInAtlas(int resolution, bool tempFill, out int x, out int y)
		{
			int numEntries = HDUtils.DivRoundUp(resolution, 64);
			for (int i = 0; i < this.m_AtlasResolutionInSlots; i++)
			{
				for (int j = 0; j < this.m_AtlasResolutionInSlots; j++)
				{
					if (this.CheckSlotAvailability(j, i, numEntries))
					{
						x = j;
						y = i;
						if (tempFill)
						{
							this.MarkEntries(x, y, numEntries, HDCachedShadowAtlas.SlotValue.TempOccupied);
						}
						return true;
					}
				}
			}
			x = 0;
			y = 0;
			return false;
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x0004C724 File Offset: 0x0004A924
		internal void FreeTempFilled(int x, int y, int resolution)
		{
			int num = HDUtils.DivRoundUp(resolution, 64);
			for (int i = y; i < y + num; i++)
			{
				for (int j = x; j < x + num; j++)
				{
					if (this.m_AtlasSlots[i * this.m_AtlasResolutionInSlots + j] == HDCachedShadowAtlas.SlotValue.TempOccupied)
					{
						this.m_AtlasSlots[i * this.m_AtlasResolutionInSlots + j] = HDCachedShadowAtlas.SlotValue.Free;
					}
				}
			}
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x0004C784 File Offset: 0x0004A984
		internal bool FindSlotInAtlas(int resolution, out int x, out int y)
		{
			return this.FindSlotInAtlas(resolution, false, out x, out y);
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x0004C790 File Offset: 0x0004A990
		internal bool GetSlotInAtlas(int resolution, out int x, out int y)
		{
			if (this.FindSlotInAtlas(resolution, out x, out y))
			{
				int numEntries = HDUtils.DivRoundUp(resolution, 64);
				this.FillEntries(x, y, numEntries);
				return true;
			}
			return false;
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x0004C7BF File Offset: 0x0004A9BF
		internal int GetNextLightIdentifier()
		{
			int nextLightID = this.m_NextLightID;
			this.m_NextLightID += 6;
			return nextLightID;
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x0004C7D8 File Offset: 0x0004A9D8
		internal void RegisterLight(HDAdditionalLightData lightData)
		{
			if (lightData.lightIdxForCachedShadows >= 0 && this.m_PlacedShadows.ContainsKey(lightData.lightIdxForCachedShadows))
			{
				return;
			}
			if (!this.m_RegisteredLightDataPendingPlacement.ContainsKey(lightData.lightIdxForCachedShadows) && lightData.isActiveAndEnabled)
			{
				lightData.legacyLight.useViewFrustumForShadowCasterCull = false;
				lightData.lightIdxForCachedShadows = this.GetNextLightIdentifier();
				this.RegisterTransformCacheSlot(lightData);
				this.m_RegisteredLightDataPendingPlacement.Add(lightData.lightIdxForCachedShadows, lightData);
				this.m_CanTryPlacement = true;
			}
		}

		// Token: 0x06000891 RID: 2193 RVA: 0x0004C858 File Offset: 0x0004AA58
		internal void EvictLight(HDAdditionalLightData lightData)
		{
			this.m_RegisteredLightDataPendingPlacement.Remove(lightData.lightIdxForCachedShadows);
			this.RemoveTransformFromCache(lightData);
			int num = (lightData.type == HDLightType.Point) ? 6 : 1;
			int lightIdxForCachedShadows = lightData.lightIdxForCachedShadows;
			lightData.lightIdxForCachedShadows = -1;
			for (int i = 0; i < num; i++)
			{
				int key = lightIdxForCachedShadows + i;
				this.m_RecordsPendingPlacement.Remove(key);
				HDCachedShadowAtlas.CachedShadowRecord cachedShadowRecord;
				if (this.m_PlacedShadows.TryGetValue(key, out cachedShadowRecord))
				{
					lightData.legacyLight.useViewFrustumForShadowCasterCull = true;
					this.m_PlacedShadows.Remove(key);
					this.m_ShadowsPendingRendering.Remove(key);
					this.m_ShadowsWithValidData.Remove(key);
					this.MarkEntries((int)cachedShadowRecord.offsetInAtlas.z, (int)cachedShadowRecord.offsetInAtlas.w, HDUtils.DivRoundUp(cachedShadowRecord.viewportSize, 64), HDCachedShadowAtlas.SlotValue.Free);
					this.m_CanTryPlacement = true;
				}
			}
		}

		// Token: 0x06000892 RID: 2194 RVA: 0x0004C938 File Offset: 0x0004AB38
		internal void RegisterTransformCacheSlot(HDAdditionalLightData lightData)
		{
			if (lightData.lightIdxForCachedShadows >= 0 && lightData.updateUponLightMovement && !this.m_TransformCaches.ContainsKey(lightData.lightIdxForCachedShadows))
			{
				HDCachedShadowAtlas.CachedTransform value;
				value.position = lightData.transform.position;
				value.angles = lightData.transform.eulerAngles;
				this.m_TransformCaches.Add(lightData.lightIdxForCachedShadows, value);
			}
		}

		// Token: 0x06000893 RID: 2195 RVA: 0x0004C99F File Offset: 0x0004AB9F
		internal void RemoveTransformFromCache(HDAdditionalLightData lightData)
		{
			this.m_TransformCaches.Remove(lightData.lightIdxForCachedShadows);
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x0004C9B4 File Offset: 0x0004ABB4
		private void InsertionSort(ref List<HDCachedShadowAtlas.CachedShadowRecord> list, int startIndex, int lastIndex)
		{
			for (int i = startIndex; i < lastIndex; i++)
			{
				HDCachedShadowAtlas.CachedShadowRecord cachedShadowRecord = list[i];
				int num = i - 1;
				while (num >= 0 && cachedShadowRecord.viewportSize > list[num].viewportSize)
				{
					list[num + 1] = list[num];
					num--;
				}
				list[num + 1] = cachedShadowRecord;
			}
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x0004CA18 File Offset: 0x0004AC18
		private void AddLightListToRecordList(Dictionary<int, HDAdditionalLightData> lightList, HDShadowInitParameters initParams, ref List<HDCachedShadowAtlas.CachedShadowRecord> recordList)
		{
			foreach (HDAdditionalLightData hdadditionalLightData in lightList.Values)
			{
				int resolutionFromSettings = hdadditionalLightData.GetResolutionFromSettings(this.m_ShadowType, initParams);
				int num = (hdadditionalLightData.type == HDLightType.Point) ? 6 : 1;
				for (int i = 0; i < num; i++)
				{
					HDCachedShadowAtlas.CachedShadowRecord item;
					item.shadowIndex = hdadditionalLightData.lightIdxForCachedShadows + i;
					item.viewportSize = resolutionFromSettings;
					item.offsetInAtlas = new Vector4(-1f, -1f, -1f, -1f);
					item.rendersOnPlacement = (hdadditionalLightData.shadowUpdateMode != ShadowUpdateMode.OnDemand || hdadditionalLightData.forceRenderOnPlacement || hdadditionalLightData.onDemandShadowRenderOnPlacement);
					hdadditionalLightData.forceRenderOnPlacement = false;
					recordList.Add(item);
				}
			}
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x0004CB04 File Offset: 0x0004AD04
		private bool PlaceMultipleShadows(int startIdx, int numberOfShadows)
		{
			HDCachedShadowAtlas.CachedShadowRecord cachedShadowRecord = this.m_TempListForPlacement[startIdx];
			Vector2Int[] array = new Vector2Int[6];
			int num = 0;
			for (int i = 0; i < numberOfShadows; i++)
			{
				HDCachedShadowAtlas.CachedShadowRecord cachedShadowRecord2 = this.m_TempListForPlacement[startIdx + i];
				int x;
				int y;
				if (!this.GetSlotInAtlas(cachedShadowRecord2.viewportSize, out x, out y))
				{
					break;
				}
				num++;
				array[i] = new Vector2Int(x, y);
			}
			if (num == numberOfShadows)
			{
				for (int j = 0; j < numberOfShadows; j++)
				{
					HDCachedShadowAtlas.CachedShadowRecord cachedShadowRecord3 = this.m_TempListForPlacement[startIdx + j];
					cachedShadowRecord3.offsetInAtlas = new Vector4((float)(array[j].x * 64), (float)(array[j].y * 64), (float)array[j].x, (float)array[j].y);
					if (cachedShadowRecord3.rendersOnPlacement)
					{
						this.m_ShadowsPendingRendering.Add(cachedShadowRecord3.shadowIndex, cachedShadowRecord3);
					}
					this.m_PlacedShadows.Add(cachedShadowRecord3.shadowIndex, cachedShadowRecord3);
				}
				return true;
			}
			if (num > 0)
			{
				int numEntries = HDUtils.DivRoundUp(this.m_TempListForPlacement[startIdx].viewportSize, 64);
				for (int k = 0; k < num; k++)
				{
					this.MarkEntries(array[k].x, array[k].y, numEntries, HDCachedShadowAtlas.SlotValue.Free);
				}
			}
			return false;
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x0004CC68 File Offset: 0x0004AE68
		private void PerformPlacement()
		{
			int i = 0;
			while (i < this.m_TempListForPlacement.Count)
			{
				HDCachedShadowAtlas.CachedShadowRecord cachedShadowRecord = this.m_TempListForPlacement[i];
				if (cachedShadowRecord.shadowIndex % 6 == 0 && i + 1 < this.m_TempListForPlacement.Count && this.m_TempListForPlacement[i + 1].shadowIndex % 6 != 0)
				{
					if (this.PlaceMultipleShadows(i, 6))
					{
						this.m_RegisteredLightDataPendingPlacement.Remove(cachedShadowRecord.shadowIndex);
						for (int j = 0; j < 6; j++)
						{
							this.m_RecordsPendingPlacement.Remove(cachedShadowRecord.shadowIndex + j);
						}
					}
					i += 6;
				}
				else
				{
					int num;
					int num2;
					if (this.GetSlotInAtlas(cachedShadowRecord.viewportSize, out num, out num2))
					{
						cachedShadowRecord.offsetInAtlas = new Vector4((float)(num * 64), (float)(num2 * 64), (float)num, (float)num2);
						if (cachedShadowRecord.rendersOnPlacement)
						{
							this.m_ShadowsPendingRendering.Add(cachedShadowRecord.shadowIndex, cachedShadowRecord);
						}
						this.m_PlacedShadows.Add(cachedShadowRecord.shadowIndex, cachedShadowRecord);
						this.m_RegisteredLightDataPendingPlacement.Remove(cachedShadowRecord.shadowIndex);
						this.m_RecordsPendingPlacement.Remove(cachedShadowRecord.shadowIndex);
					}
					i++;
				}
			}
		}

		// Token: 0x06000898 RID: 2200 RVA: 0x0004CD9C File Offset: 0x0004AF9C
		internal void AssignOffsetsInAtlas(HDShadowInitParameters initParameters)
		{
			if (this.m_RegisteredLightDataPendingPlacement.Count > 0 && this.m_CanTryPlacement)
			{
				this.m_TempListForPlacement.Clear();
				this.m_TempListForPlacement.AddRange(this.m_RecordsPendingPlacement.Values);
				this.AddLightListToRecordList(this.m_RegisteredLightDataPendingPlacement, initParameters, ref this.m_TempListForPlacement);
				if (this.m_NeedOptimalPacking)
				{
					this.InsertionSort(ref this.m_TempListForPlacement, 0, this.m_TempListForPlacement.Count);
					this.m_NeedOptimalPacking = false;
				}
				this.PerformPlacement();
				this.m_CanTryPlacement = false;
			}
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x0004CE28 File Offset: 0x0004B028
		internal void DefragmentAtlasAndReRender(HDShadowInitParameters initParams)
		{
			this.m_TempListForPlacement.Clear();
			this.m_TempListForPlacement.AddRange(this.m_PlacedShadows.Values);
			this.m_TempListForPlacement.AddRange(this.m_RecordsPendingPlacement.Values);
			this.AddLightListToRecordList(this.m_RegisteredLightDataPendingPlacement, initParams, ref this.m_TempListForPlacement);
			for (int i = 0; i < this.m_AtlasResolutionInSlots * this.m_AtlasResolutionInSlots; i++)
			{
				this.m_AtlasSlots[i] = HDCachedShadowAtlas.SlotValue.Free;
			}
			this.m_PlacedShadows.Clear();
			this.m_ShadowsPendingRendering.Clear();
			this.m_ShadowsWithValidData.Clear();
			this.m_RecordsPendingPlacement.Clear();
			this.InsertionSort(ref this.m_TempListForPlacement, 0, this.m_TempListForPlacement.Count);
			this.PerformPlacement();
			foreach (HDCachedShadowAtlas.CachedShadowRecord cachedShadowRecord in this.m_TempListForPlacement)
			{
				if (!this.m_PlacedShadows.ContainsKey(cachedShadowRecord.shadowIndex))
				{
					int key = cachedShadowRecord.shadowIndex - cachedShadowRecord.shadowIndex % 6;
					if (!this.m_RegisteredLightDataPendingPlacement.ContainsKey(key) && !this.m_RecordsPendingPlacement.ContainsKey(cachedShadowRecord.shadowIndex))
					{
						this.m_RecordsPendingPlacement.Add(cachedShadowRecord.shadowIndex, cachedShadowRecord);
					}
				}
			}
			this.m_CanTryPlacement = false;
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x0004CF8C File Offset: 0x0004B18C
		internal bool LightIsPendingPlacement(HDAdditionalLightData lightData)
		{
			return this.m_RegisteredLightDataPendingPlacement.ContainsKey(lightData.lightIdxForCachedShadows) || this.m_RecordsPendingPlacement.ContainsKey(lightData.lightIdxForCachedShadows);
		}

		// Token: 0x0600089B RID: 2203 RVA: 0x0004CFB4 File Offset: 0x0004B1B4
		internal bool ShadowIsPendingRendering(int shadowIdx)
		{
			return this.m_ShadowsPendingRendering.ContainsKey(shadowIdx);
		}

		// Token: 0x0600089C RID: 2204 RVA: 0x0004CFC2 File Offset: 0x0004B1C2
		internal bool ShadowHasRenderedAtLeastOnce(int shadowIdx)
		{
			return this.m_ShadowsWithValidData.ContainsKey(shadowIdx);
		}

		// Token: 0x0600089D RID: 2205 RVA: 0x0004CFD0 File Offset: 0x0004B1D0
		internal bool FullLightShadowHasRenderedAtLeastOnce(HDAdditionalLightData lightData)
		{
			int lightIdxForCachedShadows = lightData.lightIdxForCachedShadows;
			if (lightData.type == HDLightType.Point)
			{
				bool flag = true;
				for (int i = 0; i < 6; i++)
				{
					flag = (flag && this.m_ShadowsWithValidData.ContainsKey(lightIdxForCachedShadows + i));
				}
				return flag;
			}
			return this.m_ShadowsWithValidData.ContainsKey(lightIdxForCachedShadows);
		}

		// Token: 0x0600089E RID: 2206 RVA: 0x0004D020 File Offset: 0x0004B220
		internal bool LightIsPlaced(HDAdditionalLightData lightData)
		{
			int lightIdxForCachedShadows = lightData.lightIdxForCachedShadows;
			return lightIdxForCachedShadows >= 0 && this.m_PlacedShadows.ContainsKey(lightIdxForCachedShadows);
		}

		// Token: 0x0600089F RID: 2207 RVA: 0x0004D048 File Offset: 0x0004B248
		internal void ScheduleShadowUpdate(HDAdditionalLightData lightData)
		{
			if (!lightData.isActiveAndEnabled)
			{
				return;
			}
			int lightIdxForCachedShadows = lightData.lightIdxForCachedShadows;
			if (this.m_PlacedShadows.ContainsKey(lightIdxForCachedShadows))
			{
				int num = (lightData.type == HDLightType.Point) ? 6 : 1;
				for (int i = 0; i < num; i++)
				{
					int shadowIdx = lightIdxForCachedShadows + i;
					this.ScheduleShadowUpdate(shadowIdx);
				}
				return;
			}
			if (this.m_RegisteredLightDataPendingPlacement.ContainsKey(lightIdxForCachedShadows))
			{
				return;
			}
			lightData.forceRenderOnPlacement = true;
			this.RegisterLight(lightData);
		}

		// Token: 0x060008A0 RID: 2208 RVA: 0x0004D0B8 File Offset: 0x0004B2B8
		internal void ScheduleShadowUpdate(int shadowIdx)
		{
			HDCachedShadowAtlas.CachedShadowRecord value;
			if (!this.m_PlacedShadows.TryGetValue(shadowIdx, out value))
			{
				return;
			}
			if (this.m_ShadowsPendingRendering.ContainsKey(shadowIdx))
			{
				return;
			}
			this.m_ShadowsPendingRendering.Add(shadowIdx, value);
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x0004D0F2 File Offset: 0x0004B2F2
		internal void MarkAsRendered(int shadowIdx)
		{
			if (this.m_ShadowsPendingRendering.ContainsKey(shadowIdx))
			{
				this.m_ShadowsPendingRendering.Remove(shadowIdx);
				if (!this.m_ShadowsWithValidData.ContainsKey(shadowIdx))
				{
					this.m_ShadowsWithValidData.Add(shadowIdx, shadowIdx);
				}
			}
		}

		// Token: 0x060008A2 RID: 2210 RVA: 0x0004D12C File Offset: 0x0004B32C
		internal void UpdateResolutionRequest(ref HDShadowResolutionRequest request, int shadowIdx)
		{
			HDCachedShadowAtlas.CachedShadowRecord cachedShadowRecord;
			if (!this.m_PlacedShadows.TryGetValue(shadowIdx, out cachedShadowRecord))
			{
				Debug.LogWarning("Trying to render a cached shadow map that doesn't have a slot in the atlas yet.");
			}
			request.cachedAtlasViewport = new Rect(cachedShadowRecord.offsetInAtlas.x, cachedShadowRecord.offsetInAtlas.y, (float)cachedShadowRecord.viewportSize, (float)cachedShadowRecord.viewportSize);
			request.resolution = new Vector2((float)cachedShadowRecord.viewportSize, (float)cachedShadowRecord.viewportSize);
		}

		// Token: 0x060008A3 RID: 2211 RVA: 0x0004D1A0 File Offset: 0x0004B3A0
		internal bool NeedRenderingDueToTransformChange(HDAdditionalLightData lightData, HDLightType lightType)
		{
			bool flag = false;
			HDCachedShadowAtlas.CachedTransform cachedTransform;
			if (this.m_TransformCaches.TryGetValue(lightData.lightIdxForCachedShadows, out cachedTransform))
			{
				float cachedShadowTranslationUpdateThreshold = lightData.cachedShadowTranslationUpdateThreshold;
				Vector3 vector = cachedTransform.position - lightData.transform.position;
				if (Vector3.Dot(vector, vector) > cachedShadowTranslationUpdateThreshold * cachedShadowTranslationUpdateThreshold)
				{
					flag = true;
				}
				if (lightType != HDLightType.Point)
				{
					float cachedShadowAngleUpdateThreshold = lightData.cachedShadowAngleUpdateThreshold;
					Vector3 vector2 = cachedTransform.angles - lightData.transform.eulerAngles;
					if (Mathf.Abs(vector2.x) > cachedShadowAngleUpdateThreshold || Mathf.Abs(vector2.y) > cachedShadowAngleUpdateThreshold || Mathf.Abs(vector2.z) > cachedShadowAngleUpdateThreshold)
					{
						flag = true;
					}
				}
				if (flag)
				{
					this.m_TransformCaches.Remove(lightData.lightIdxForCachedShadows);
					cachedTransform.position = lightData.transform.position;
					cachedTransform.angles = lightData.transform.eulerAngles;
					this.m_TransformCaches.Add(lightData.lightIdxForCachedShadows, cachedTransform);
				}
			}
			return flag;
		}

		// Token: 0x04000863 RID: 2147
		private static int s_InitialCapacity = 256;

		// Token: 0x04000864 RID: 2148
		private const int m_MaxShadowsPerLight = 6;

		// Token: 0x04000865 RID: 2149
		private int m_NextLightID;

		// Token: 0x04000866 RID: 2150
		private bool m_CanTryPlacement;

		// Token: 0x04000867 RID: 2151
		private int m_AtlasResolutionInSlots;

		// Token: 0x04000868 RID: 2152
		private bool m_NeedOptimalPacking = true;

		// Token: 0x04000869 RID: 2153
		private List<HDCachedShadowAtlas.SlotValue> m_AtlasSlots;

		// Token: 0x0400086A RID: 2154
		private Dictionary<int, HDCachedShadowAtlas.CachedShadowRecord> m_PlacedShadows;

		// Token: 0x0400086B RID: 2155
		private Dictionary<int, HDCachedShadowAtlas.CachedShadowRecord> m_ShadowsPendingRendering;

		// Token: 0x0400086C RID: 2156
		private Dictionary<int, int> m_ShadowsWithValidData;

		// Token: 0x0400086D RID: 2157
		private Dictionary<int, HDAdditionalLightData> m_RegisteredLightDataPendingPlacement;

		// Token: 0x0400086E RID: 2158
		private Dictionary<int, HDCachedShadowAtlas.CachedShadowRecord> m_RecordsPendingPlacement;

		// Token: 0x0400086F RID: 2159
		private Dictionary<int, HDCachedShadowAtlas.CachedTransform> m_TransformCaches;

		// Token: 0x04000870 RID: 2160
		private List<HDCachedShadowAtlas.CachedShadowRecord> m_TempListForPlacement;

		// Token: 0x04000871 RID: 2161
		private ShadowMapType m_ShadowType;

		// Token: 0x0200034C RID: 844
		private struct CachedShadowRecord
		{
			// Token: 0x0400234D RID: 9037
			internal int shadowIndex;

			// Token: 0x0400234E RID: 9038
			internal int viewportSize;

			// Token: 0x0400234F RID: 9039
			internal Vector4 offsetInAtlas;

			// Token: 0x04002350 RID: 9040
			internal bool rendersOnPlacement;
		}

		// Token: 0x0200034D RID: 845
		private struct CachedTransform
		{
			// Token: 0x04002351 RID: 9041
			internal Vector3 position;

			// Token: 0x04002352 RID: 9042
			internal Vector3 angles;
		}

		// Token: 0x0200034E RID: 846
		private enum SlotValue : byte
		{
			// Token: 0x04002354 RID: 9044
			Free,
			// Token: 0x04002355 RID: 9045
			Occupied,
			// Token: 0x04002356 RID: 9046
			TempOccupied
		}
	}
}
