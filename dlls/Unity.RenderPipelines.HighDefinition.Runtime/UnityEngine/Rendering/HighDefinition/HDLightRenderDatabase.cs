using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200007B RID: 123
	internal class HDLightRenderDatabase
	{
		// Token: 0x170000CB RID: 203
		// (get) Token: 0x060006DA RID: 1754 RVA: 0x00045DFF File Offset: 0x00043FFF
		public int lightCount
		{
			get
			{
				return this.m_LightCount;
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x060006DB RID: 1755 RVA: 0x00045E07 File Offset: 0x00044007
		public NativeArray<HDLightRenderData> lightData
		{
			get
			{
				return this.m_LightData;
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x060006DC RID: 1756 RVA: 0x00045E0F File Offset: 0x0004400F
		public NativeArray<HDLightRenderEntity> lightEntities
		{
			get
			{
				return this.m_OwnerEntity;
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x060006DD RID: 1757 RVA: 0x00045E17 File Offset: 0x00044017
		public DynamicArray<HDAdditionalLightData> hdAdditionalLightData
		{
			get
			{
				return this.m_HDAdditionalLightData;
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x060006DE RID: 1758 RVA: 0x00045E1F File Offset: 0x0004401F
		public DynamicArray<GameObject> aovGameObjects
		{
			get
			{
				return this.m_AOVGameObjects;
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x060006DF RID: 1759 RVA: 0x00045E27 File Offset: 0x00044027
		public static HDLightRenderDatabase instance
		{
			get
			{
				if (HDLightRenderDatabase.s_Instance == null)
				{
					HDLightRenderDatabase.s_Instance = new HDLightRenderDatabase();
				}
				return HDLightRenderDatabase.s_Instance;
			}
		}

		// Token: 0x060006E0 RID: 1760 RVA: 0x00045E3F File Offset: 0x0004403F
		public ref HDLightRenderData GetLightDataAsRef(in HDLightRenderEntity entity)
		{
			return this.EditLightDataAsRef(entity);
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x00045E48 File Offset: 0x00044048
		public ref HDLightRenderData EditLightDataAsRef(in HDLightRenderEntity entity)
		{
			return this.EditLightDataAsRef(this.m_LightEntities[entity.entityIndex].dataIndex);
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x00045E66 File Offset: 0x00044066
		public ref HDLightRenderData GetLightDataAsRef(int dataIndex)
		{
			return this.EditLightDataAsRef(dataIndex);
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x00045E70 File Offset: 0x00044070
		public unsafe ref HDLightRenderData EditLightDataAsRef(int dataIndex)
		{
			if (dataIndex >= this.m_LightCount)
			{
				throw new Exception("Entity passed in is out of bounds. Index requested " + dataIndex.ToString() + " and maximum length is " + this.m_LightCount.ToString());
			}
			return UnsafeUtility.AsRef<HDLightRenderData>((void*)((byte*)this.m_LightData.GetUnsafePtr<HDLightRenderData>() + (IntPtr)dataIndex * (IntPtr)sizeof(HDLightRenderData)));
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x00045EC8 File Offset: 0x000440C8
		public HDLightRenderEntity CreateEntity(bool autoDestroy)
		{
			HDLightRenderDatabase.LightEntityInfo lightEntityInfo = this.AllocateEntityData();
			HDLightRenderEntity invalid = HDLightRenderEntity.Invalid;
			if (this.m_FreeIndices.Count == 0)
			{
				invalid.entityIndex = this.m_LightEntities.Count;
				this.m_LightEntities.Add(lightEntityInfo);
			}
			else
			{
				invalid.entityIndex = this.m_FreeIndices.Dequeue();
				this.m_LightEntities[invalid.entityIndex] = lightEntityInfo;
			}
			this.m_OwnerEntity[lightEntityInfo.dataIndex] = invalid;
			this.m_AutoDestroy[lightEntityInfo.dataIndex] = autoDestroy;
			return invalid;
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x00045F58 File Offset: 0x00044158
		public unsafe void AttachGameObjectData(HDLightRenderEntity entity, int instanceID, HDAdditionalLightData additionalLightData, GameObject aovGameObject)
		{
			if (!this.IsValid(entity))
			{
				return;
			}
			HDLightRenderDatabase.LightEntityInfo lightEntityInfo = this.m_LightEntities[entity.entityIndex];
			int dataIndex = lightEntityInfo.dataIndex;
			if (dataIndex == HDLightRenderDatabase.InvalidDataIndex)
			{
				return;
			}
			lightEntityInfo.lightInstanceID = instanceID;
			this.m_LightEntities[entity.entityIndex] = lightEntityInfo;
			this.m_LightsToEntityItem.Add(lightEntityInfo.lightInstanceID, lightEntityInfo);
			*this.m_HDAdditionalLightData[dataIndex] = additionalLightData;
			*this.m_AOVGameObjects[dataIndex] = aovGameObject;
			this.m_AttachedGameObjects++;
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x00045FE8 File Offset: 0x000441E8
		public unsafe void DestroyEntity(HDLightRenderEntity lightEntity)
		{
			this.m_FreeIndices.Enqueue(lightEntity.entityIndex);
			HDLightRenderDatabase.LightEntityInfo lightEntityInfo = this.m_LightEntities[lightEntity.entityIndex];
			this.m_LightsToEntityItem.Remove(lightEntityInfo.lightInstanceID);
			if (*this.m_HDAdditionalLightData[lightEntityInfo.dataIndex] != null)
			{
				this.m_AttachedGameObjects--;
			}
			this.RemoveAtSwapBackArrays(lightEntityInfo.dataIndex);
			if (this.m_LightCount == 0)
			{
				this.DeleteArrays();
				return;
			}
			HDLightRenderEntity hdlightRenderEntity = this.m_OwnerEntity[lightEntityInfo.dataIndex];
			HDLightRenderDatabase.LightEntityInfo lightEntityInfo2 = this.m_LightEntities[hdlightRenderEntity.entityIndex];
			lightEntityInfo2.dataIndex = lightEntityInfo.dataIndex;
			this.m_LightEntities[hdlightRenderEntity.entityIndex] = lightEntityInfo2;
			if (lightEntityInfo2.lightInstanceID != lightEntityInfo.lightInstanceID)
			{
				this.m_LightsToEntityItem[lightEntityInfo2.lightInstanceID] = lightEntityInfo2;
			}
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x000460D0 File Offset: 0x000442D0
		public unsafe void Cleanup()
		{
			this.m_DefaultLightEntity = HDLightRenderEntity.Invalid;
			HDUtils.s_DefaultHDAdditionalLightData.DestroyHDLightRenderEntity();
			List<HDAdditionalLightData> list = new List<HDAdditionalLightData>();
			for (int i = 0; i < this.m_LightCount; i++)
			{
				if (this.m_AutoDestroy[i] && *this.m_HDAdditionalLightData[i] != null)
				{
					list.Add(*this.m_HDAdditionalLightData[i]);
				}
			}
			foreach (HDAdditionalLightData hdadditionalLightData in list)
			{
				hdadditionalLightData.DestroyHDLightRenderEntity();
			}
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x00046180 File Offset: 0x00044380
		public HDLightRenderEntity GetDefaultLightEntity()
		{
			if (!this.IsValid(this.m_DefaultLightEntity))
			{
				HDUtils.s_DefaultHDAdditionalLightData.CreateHDLightRenderEntity(true);
				this.m_DefaultLightEntity = HDUtils.s_DefaultHDAdditionalLightData.lightEntity;
			}
			return this.m_DefaultLightEntity;
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x000461B1 File Offset: 0x000443B1
		public bool IsValid(HDLightRenderEntity entity)
		{
			return entity.valid && entity.entityIndex < this.m_LightEntities.Count;
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x000461D1 File Offset: 0x000443D1
		public int GetEntityDataIndex(HDLightRenderEntity entity)
		{
			return this.GetEntityData(entity).dataIndex;
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x000461E0 File Offset: 0x000443E0
		public int FindEntityDataIndex(in VisibleLight visibleLight)
		{
			VisibleLight visibleLight2 = visibleLight;
			Light light = visibleLight2.light;
			return this.FindEntityDataIndex(light);
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x00046204 File Offset: 0x00044404
		public int FindEntityDataIndex(in Light light)
		{
			HDLightRenderDatabase.LightEntityInfo lightEntityInfo;
			if (light != null && this.m_LightsToEntityItem.TryGetValue(light.GetInstanceID(), out lightEntityInfo))
			{
				return lightEntityInfo.dataIndex;
			}
			return -1;
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x0004623C File Offset: 0x0004443C
		private void ResizeArrays()
		{
			this.m_HDAdditionalLightData.Resize(this.m_Capacity, true);
			this.m_AOVGameObjects.Resize(this.m_Capacity, true);
			ref this.m_LightData.ResizeArray(this.m_Capacity);
			ref this.m_OwnerEntity.ResizeArray(this.m_Capacity);
			ref this.m_AutoDestroy.ResizeArray(this.m_Capacity);
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x000462A0 File Offset: 0x000444A0
		private unsafe void RemoveAtSwapBackArrays(int removeIndexAt)
		{
			int index = this.m_LightCount - 1;
			*this.m_HDAdditionalLightData[removeIndexAt] = *this.m_HDAdditionalLightData[index];
			*this.m_HDAdditionalLightData[index] = null;
			*this.m_AOVGameObjects[removeIndexAt] = *this.m_AOVGameObjects[index];
			*this.m_AOVGameObjects[index] = null;
			this.m_LightData[removeIndexAt] = this.m_LightData[index];
			this.m_OwnerEntity[removeIndexAt] = this.m_OwnerEntity[index];
			this.m_AutoDestroy[removeIndexAt] = this.m_AutoDestroy[index];
			this.m_LightCount--;
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x0004635C File Offset: 0x0004455C
		private void DeleteArrays()
		{
			if (this.m_Capacity == 0)
			{
				return;
			}
			this.m_HDAdditionalLightData.Clear();
			this.m_AOVGameObjects.Clear();
			this.m_LightData.Dispose();
			this.m_OwnerEntity.Dispose();
			this.m_AutoDestroy.Dispose();
			this.m_FreeIndices.Clear();
			this.m_LightEntities.Clear();
			this.m_Capacity = 0;
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x000463C6 File Offset: 0x000445C6
		private HDLightRenderDatabase.LightEntityInfo GetEntityData(HDLightRenderEntity entity)
		{
			return this.m_LightEntities[entity.entityIndex];
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x000463DC File Offset: 0x000445DC
		private HDLightRenderDatabase.LightEntityInfo AllocateEntityData()
		{
			if (this.m_Capacity == 0 || this.m_LightCount == this.m_Capacity)
			{
				this.m_Capacity = Math.Max(Math.Max(this.m_Capacity * 2, this.m_LightCount), 100);
				this.ResizeArrays();
			}
			int lightCount = this.m_LightCount;
			this.m_LightCount = lightCount + 1;
			int dataIndex = lightCount;
			return new HDLightRenderDatabase.LightEntityInfo
			{
				dataIndex = dataIndex,
				lightInstanceID = -1
			};
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x00046450 File Offset: 0x00044650
		~HDLightRenderDatabase()
		{
			this.DeleteArrays();
		}

		// Token: 0x040005E2 RID: 1506
		public static int InvalidDataIndex = -1;

		// Token: 0x040005E3 RID: 1507
		private const int ArrayCapacity = 100;

		// Token: 0x040005E4 RID: 1508
		private static HDLightRenderDatabase s_Instance = null;

		// Token: 0x040005E5 RID: 1509
		private int m_Capacity;

		// Token: 0x040005E6 RID: 1510
		private int m_LightCount;

		// Token: 0x040005E7 RID: 1511
		private int m_AttachedGameObjects;

		// Token: 0x040005E8 RID: 1512
		private HDLightRenderEntity m_DefaultLightEntity = HDLightRenderEntity.Invalid;

		// Token: 0x040005E9 RID: 1513
		private List<HDLightRenderDatabase.LightEntityInfo> m_LightEntities = new List<HDLightRenderDatabase.LightEntityInfo>();

		// Token: 0x040005EA RID: 1514
		private Queue<int> m_FreeIndices = new Queue<int>();

		// Token: 0x040005EB RID: 1515
		private Dictionary<int, HDLightRenderDatabase.LightEntityInfo> m_LightsToEntityItem = new Dictionary<int, HDLightRenderDatabase.LightEntityInfo>();

		// Token: 0x040005EC RID: 1516
		private NativeArray<HDLightRenderData> m_LightData;

		// Token: 0x040005ED RID: 1517
		private NativeArray<HDLightRenderEntity> m_OwnerEntity;

		// Token: 0x040005EE RID: 1518
		private NativeArray<bool> m_AutoDestroy;

		// Token: 0x040005EF RID: 1519
		private DynamicArray<GameObject> m_AOVGameObjects = new DynamicArray<GameObject>();

		// Token: 0x040005F0 RID: 1520
		private DynamicArray<HDAdditionalLightData> m_HDAdditionalLightData = new DynamicArray<HDAdditionalLightData>();

		// Token: 0x0200032C RID: 812
		private struct LightEntityInfo
		{
			// Token: 0x17000282 RID: 642
			// (get) Token: 0x0600128A RID: 4746 RVA: 0x0008EABF File Offset: 0x0008CCBF
			public bool valid
			{
				get
				{
					return this.dataIndex != -1 && this.lightInstanceID != -1;
				}
			}

			// Token: 0x040022DB RID: 8923
			public int dataIndex;

			// Token: 0x040022DC RID: 8924
			public int lightInstanceID;

			// Token: 0x040022DD RID: 8925
			public static readonly HDLightRenderDatabase.LightEntityInfo Invalid = new HDLightRenderDatabase.LightEntityInfo
			{
				dataIndex = HDLightRenderDatabase.InvalidDataIndex,
				lightInstanceID = -1
			};
		}
	}
}
