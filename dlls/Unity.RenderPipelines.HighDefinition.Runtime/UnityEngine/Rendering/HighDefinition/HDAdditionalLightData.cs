using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200006C RID: 108
	[AddComponentMenu("")]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Light))]
	[ExecuteAlways]
	public class HDAdditionalLightData : MonoBehaviour, ISerializationCallbackReceiver, IAdditionalData, IVersionable<HDAdditionalLightData.Version>
	{
		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600058E RID: 1422 RVA: 0x0003FF9B File Offset: 0x0003E19B
		// (set) Token: 0x0600058F RID: 1423 RVA: 0x0003FFA3 File Offset: 0x0003E1A3
		public float intensity
		{
			get
			{
				return this.m_Intensity;
			}
			set
			{
				if (this.m_Intensity == value)
				{
					return;
				}
				this.m_Intensity = Mathf.Clamp(value, 0f, float.MaxValue);
				this.UpdateLightIntensity();
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000590 RID: 1424 RVA: 0x0003FFCB File Offset: 0x0003E1CB
		// (set) Token: 0x06000591 RID: 1425 RVA: 0x0003FFD3 File Offset: 0x0003E1D3
		public bool enableSpotReflector
		{
			get
			{
				return this.m_EnableSpotReflector;
			}
			set
			{
				if (this.m_EnableSpotReflector == value)
				{
					return;
				}
				this.m_EnableSpotReflector = value;
				this.UpdateLightIntensity();
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000592 RID: 1426 RVA: 0x0003FFEC File Offset: 0x0003E1EC
		// (set) Token: 0x06000593 RID: 1427 RVA: 0x0003FFF4 File Offset: 0x0003E1F4
		public float luxAtDistance
		{
			get
			{
				return this.m_LuxAtDistance;
			}
			set
			{
				if (this.m_LuxAtDistance == value)
				{
					return;
				}
				this.m_LuxAtDistance = Mathf.Clamp(value, 0f, float.MaxValue);
				this.UpdateLightIntensity();
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000594 RID: 1428 RVA: 0x0004001C File Offset: 0x0003E21C
		// (set) Token: 0x06000595 RID: 1429 RVA: 0x00040024 File Offset: 0x0003E224
		public float innerSpotPercent
		{
			get
			{
				return this.m_InnerSpotPercent;
			}
			set
			{
				if (this.m_InnerSpotPercent == value)
				{
					return;
				}
				this.m_InnerSpotPercent = Mathf.Clamp(value, 0f, 100f);
				this.UpdateLightIntensity();
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).innerSpotPercent = this.m_InnerSpotPercent;
				}
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000596 RID: 1430 RVA: 0x0004007F File Offset: 0x0003E27F
		public float innerSpotPercent01
		{
			get
			{
				return this.innerSpotPercent / 100f;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000597 RID: 1431 RVA: 0x0004008D File Offset: 0x0003E28D
		// (set) Token: 0x06000598 RID: 1432 RVA: 0x00040098 File Offset: 0x0003E298
		public float spotIESCutoffPercent
		{
			get
			{
				return this.m_SpotIESCutoffPercent;
			}
			set
			{
				if (this.m_SpotIESCutoffPercent == value)
				{
					return;
				}
				this.m_SpotIESCutoffPercent = Mathf.Clamp(value, 0f, 100f);
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).spotIESCutoffPercent = this.m_SpotIESCutoffPercent;
				}
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000599 RID: 1433 RVA: 0x000400ED File Offset: 0x0003E2ED
		public float spotIESCutoffPercent01
		{
			get
			{
				return this.spotIESCutoffPercent / 100f;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600059A RID: 1434 RVA: 0x000400FB File Offset: 0x0003E2FB
		// (set) Token: 0x0600059B RID: 1435 RVA: 0x00040104 File Offset: 0x0003E304
		public float lightDimmer
		{
			get
			{
				return this.m_LightDimmer;
			}
			set
			{
				if (this.m_LightDimmer == value)
				{
					return;
				}
				this.m_LightDimmer = Mathf.Clamp(value, 0f, 16f);
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).lightDimmer = this.m_LightDimmer;
				}
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x0600059C RID: 1436 RVA: 0x00040159 File Offset: 0x0003E359
		// (set) Token: 0x0600059D RID: 1437 RVA: 0x00040170 File Offset: 0x0003E370
		public float volumetricDimmer
		{
			get
			{
				if (!this.useVolumetric)
				{
					return 0f;
				}
				return this.m_VolumetricDimmer;
			}
			set
			{
				if (this.m_VolumetricDimmer == value)
				{
					return;
				}
				this.m_VolumetricDimmer = Mathf.Clamp(value, 0f, 16f);
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).volumetricDimmer = this.m_VolumetricDimmer;
				}
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x0600059E RID: 1438 RVA: 0x000401C5 File Offset: 0x0003E3C5
		// (set) Token: 0x0600059F RID: 1439 RVA: 0x000401D0 File Offset: 0x0003E3D0
		public LightUnit lightUnit
		{
			get
			{
				return this.m_LightUnit;
			}
			set
			{
				if (this.m_LightUnit == value)
				{
					return;
				}
				if (!HDAdditionalLightData.IsValidLightUnitForType(this.type, this.m_SpotLightShape, value))
				{
					string arg = string.Join<LightUnit>(", ", HDAdditionalLightData.GetSupportedLightUnits(this.type, this.m_SpotLightShape));
					Debug.LogError(string.Format("Set Light Unit '{0}' to a {1} is not allowed, only {2} are supported.", value, this.GetLightTypeName(), arg));
					return;
				}
				LightUtils.ConvertLightIntensity(this.m_LightUnit, value, this, this.legacyLight);
				this.m_LightUnit = value;
				this.UpdateLightIntensity();
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060005A0 RID: 1440 RVA: 0x00040254 File Offset: 0x0003E454
		// (set) Token: 0x060005A1 RID: 1441 RVA: 0x0004025C File Offset: 0x0003E45C
		public float fadeDistance
		{
			get
			{
				return this.m_FadeDistance;
			}
			set
			{
				if (this.m_FadeDistance == value)
				{
					return;
				}
				this.m_FadeDistance = Mathf.Clamp(value, 0f, float.MaxValue);
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).fadeDistance = this.m_FadeDistance;
				}
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060005A2 RID: 1442 RVA: 0x000402B1 File Offset: 0x0003E4B1
		// (set) Token: 0x060005A3 RID: 1443 RVA: 0x000402BC File Offset: 0x0003E4BC
		public float volumetricFadeDistance
		{
			get
			{
				return this.m_VolumetricFadeDistance;
			}
			set
			{
				if (this.m_VolumetricFadeDistance == value)
				{
					return;
				}
				this.m_VolumetricFadeDistance = Mathf.Clamp(value, 0f, float.MaxValue);
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).volumetricFadeDistance = this.m_VolumetricFadeDistance;
				}
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060005A4 RID: 1444 RVA: 0x00040311 File Offset: 0x0003E511
		// (set) Token: 0x060005A5 RID: 1445 RVA: 0x00040319 File Offset: 0x0003E519
		public bool affectDiffuse
		{
			get
			{
				return this.m_AffectDiffuse;
			}
			set
			{
				if (this.m_AffectDiffuse == value)
				{
					return;
				}
				this.m_AffectDiffuse = value;
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).affectDiffuse = this.m_AffectDiffuse;
				}
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060005A6 RID: 1446 RVA: 0x00040354 File Offset: 0x0003E554
		// (set) Token: 0x060005A7 RID: 1447 RVA: 0x0004035C File Offset: 0x0003E55C
		public bool affectSpecular
		{
			get
			{
				return this.m_AffectSpecular;
			}
			set
			{
				if (this.m_AffectSpecular == value)
				{
					return;
				}
				this.m_AffectSpecular = value;
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).affectSpecular = this.m_AffectSpecular;
				}
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060005A8 RID: 1448 RVA: 0x00040397 File Offset: 0x0003E597
		// (set) Token: 0x060005A9 RID: 1449 RVA: 0x000403A0 File Offset: 0x0003E5A0
		public bool nonLightmappedOnly
		{
			get
			{
				return this.m_NonLightmappedOnly;
			}
			set
			{
				if (this.m_NonLightmappedOnly == value)
				{
					return;
				}
				this.m_NonLightmappedOnly = value;
				this.legacyLight.lightShadowCasterMode = (value ? LightShadowCasterMode.NonLightmappedOnly : LightShadowCasterMode.Everything);
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).useRayTracedShadows = (this.m_UseRayTracedShadows && !this.m_NonLightmappedOnly);
				}
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060005AA RID: 1450 RVA: 0x00040406 File Offset: 0x0003E606
		// (set) Token: 0x060005AB RID: 1451 RVA: 0x00040410 File Offset: 0x0003E610
		public float shapeWidth
		{
			get
			{
				return this.m_ShapeWidth;
			}
			set
			{
				if (this.m_ShapeWidth == value)
				{
					return;
				}
				if (this.type == HDLightType.Area)
				{
					this.m_ShapeWidth = Mathf.Clamp(value, 0.01f, float.MaxValue);
				}
				else
				{
					this.m_ShapeWidth = Mathf.Clamp(value, 0f, float.MaxValue);
				}
				this.UpdateAllLightValues();
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).shapeWidth = this.m_ShapeWidth;
				}
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060005AC RID: 1452 RVA: 0x0004048C File Offset: 0x0003E68C
		// (set) Token: 0x060005AD RID: 1453 RVA: 0x00040494 File Offset: 0x0003E694
		public float shapeHeight
		{
			get
			{
				return this.m_ShapeHeight;
			}
			set
			{
				if (this.m_ShapeHeight == value)
				{
					return;
				}
				if (this.type == HDLightType.Area)
				{
					this.m_ShapeHeight = Mathf.Clamp(value, 0.01f, float.MaxValue);
				}
				else
				{
					this.m_ShapeHeight = Mathf.Clamp(value, 0f, float.MaxValue);
				}
				this.UpdateAllLightValues();
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).shapeHeight = this.m_ShapeHeight;
				}
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060005AE RID: 1454 RVA: 0x00040510 File Offset: 0x0003E710
		// (set) Token: 0x060005AF RID: 1455 RVA: 0x00040518 File Offset: 0x0003E718
		public float aspectRatio
		{
			get
			{
				return this.m_AspectRatio;
			}
			set
			{
				if (this.m_AspectRatio == value)
				{
					return;
				}
				this.m_AspectRatio = Mathf.Clamp(value, 0.05f, 20f);
				this.UpdateAllLightValues();
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).aspectRatio = this.m_AspectRatio;
				}
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060005B0 RID: 1456 RVA: 0x00040573 File Offset: 0x0003E773
		// (set) Token: 0x060005B1 RID: 1457 RVA: 0x0004057C File Offset: 0x0003E77C
		public float shapeRadius
		{
			get
			{
				return this.m_ShapeRadius;
			}
			set
			{
				if (this.m_ShapeRadius == value)
				{
					return;
				}
				this.m_ShapeRadius = Mathf.Clamp(value, 0f, float.MaxValue);
				this.UpdateAllLightValues();
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).shapeRadius = this.m_ShapeRadius;
				}
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060005B2 RID: 1458 RVA: 0x000405D7 File Offset: 0x0003E7D7
		// (set) Token: 0x060005B3 RID: 1459 RVA: 0x000405DF File Offset: 0x0003E7DF
		public float softnessScale
		{
			get
			{
				return this.m_SoftnessScale;
			}
			set
			{
				if (this.m_SoftnessScale == value)
				{
					return;
				}
				this.m_SoftnessScale = Mathf.Clamp(value, 0f, float.MaxValue);
				this.UpdateAllLightValues();
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060005B4 RID: 1460 RVA: 0x00040607 File Offset: 0x0003E807
		// (set) Token: 0x060005B5 RID: 1461 RVA: 0x0004060F File Offset: 0x0003E80F
		public bool useCustomSpotLightShadowCone
		{
			get
			{
				return this.m_UseCustomSpotLightShadowCone;
			}
			set
			{
				if (this.m_UseCustomSpotLightShadowCone == value)
				{
					return;
				}
				this.m_UseCustomSpotLightShadowCone = value;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060005B6 RID: 1462 RVA: 0x00040622 File Offset: 0x0003E822
		// (set) Token: 0x060005B7 RID: 1463 RVA: 0x0004062A File Offset: 0x0003E82A
		public float customSpotLightShadowCone
		{
			get
			{
				return this.m_CustomSpotLightShadowCone;
			}
			set
			{
				if (this.m_CustomSpotLightShadowCone == value)
				{
					return;
				}
				this.m_CustomSpotLightShadowCone = value;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060005B8 RID: 1464 RVA: 0x0004063D File Offset: 0x0003E83D
		// (set) Token: 0x060005B9 RID: 1465 RVA: 0x00040645 File Offset: 0x0003E845
		public float maxSmoothness
		{
			get
			{
				return this.m_MaxSmoothness;
			}
			set
			{
				if (this.m_MaxSmoothness == value)
				{
					return;
				}
				this.m_MaxSmoothness = Mathf.Clamp01(value);
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060005BA RID: 1466 RVA: 0x0004065D File Offset: 0x0003E85D
		// (set) Token: 0x060005BB RID: 1467 RVA: 0x00040668 File Offset: 0x0003E868
		public bool applyRangeAttenuation
		{
			get
			{
				return this.m_ApplyRangeAttenuation;
			}
			set
			{
				if (this.m_ApplyRangeAttenuation == value)
				{
					return;
				}
				this.m_ApplyRangeAttenuation = value;
				this.UpdateAllLightValues();
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).applyRangeAttenuation = this.m_ApplyRangeAttenuation;
				}
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060005BC RID: 1468 RVA: 0x000406B4 File Offset: 0x0003E8B4
		// (set) Token: 0x060005BD RID: 1469 RVA: 0x000406BC File Offset: 0x0003E8BC
		public bool displayAreaLightEmissiveMesh
		{
			get
			{
				return this.m_DisplayAreaLightEmissiveMesh;
			}
			set
			{
				if (this.m_DisplayAreaLightEmissiveMesh == value)
				{
					return;
				}
				this.m_DisplayAreaLightEmissiveMesh = value;
				this.UpdateAllLightValues();
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060005BE RID: 1470 RVA: 0x000406D5 File Offset: 0x0003E8D5
		// (set) Token: 0x060005BF RID: 1471 RVA: 0x000406DD File Offset: 0x0003E8DD
		public Texture areaLightCookie
		{
			get
			{
				return this.m_AreaLightCookie;
			}
			set
			{
				if (this.m_AreaLightCookie == value)
				{
					return;
				}
				this.m_AreaLightCookie = value;
				this.UpdateAllLightValues();
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060005C0 RID: 1472 RVA: 0x000406FB File Offset: 0x0003E8FB
		// (set) Token: 0x060005C1 RID: 1473 RVA: 0x00040704 File Offset: 0x0003E904
		internal Texture IESPoint
		{
			get
			{
				return this.m_IESPoint;
			}
			set
			{
				if (value.dimension == TextureDimension.Cube)
				{
					this.m_IESPoint = value;
					this.UpdateAllLightValues();
					return;
				}
				Debug.LogError("Texture dimension " + value.dimension.ToString() + " is not supported for point lights.");
				this.m_IESPoint = null;
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060005C2 RID: 1474 RVA: 0x00040757 File Offset: 0x0003E957
		// (set) Token: 0x060005C3 RID: 1475 RVA: 0x00040760 File Offset: 0x0003E960
		internal Texture IESSpot
		{
			get
			{
				return this.m_IESSpot;
			}
			set
			{
				if (value.dimension == TextureDimension.Tex2D && value.width == value.height)
				{
					this.m_IESSpot = value;
					this.UpdateAllLightValues();
					return;
				}
				Debug.LogError("Texture dimension " + value.dimension.ToString() + " is not supported for spot lights or rectangular light (only square images).");
				this.m_IESSpot = null;
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060005C4 RID: 1476 RVA: 0x000407C1 File Offset: 0x0003E9C1
		// (set) Token: 0x060005C5 RID: 1477 RVA: 0x000407F4 File Offset: 0x0003E9F4
		public Texture IESTexture
		{
			get
			{
				if (this.type == HDLightType.Point)
				{
					return this.IESPoint;
				}
				if (this.type == HDLightType.Spot || (this.type == HDLightType.Area && this.areaLightShape == AreaLightShape.Rectangle))
				{
					return this.IESSpot;
				}
				return null;
			}
			set
			{
				if (this.type == HDLightType.Point)
				{
					this.IESPoint = value;
					return;
				}
				if (this.type == HDLightType.Spot || (this.type == HDLightType.Area && this.areaLightShape == AreaLightShape.Rectangle))
				{
					this.IESSpot = value;
				}
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060005C6 RID: 1478 RVA: 0x00040827 File Offset: 0x0003EA27
		// (set) Token: 0x060005C7 RID: 1479 RVA: 0x00040830 File Offset: 0x0003EA30
		public bool includeForRayTracing
		{
			get
			{
				return this.m_IncludeForRayTracing;
			}
			set
			{
				if (this.m_IncludeForRayTracing == value)
				{
					return;
				}
				this.m_IncludeForRayTracing = value;
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).includeForRayTracing = this.m_IncludeForRayTracing;
				}
				this.UpdateAllLightValues();
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060005C8 RID: 1480 RVA: 0x0004087C File Offset: 0x0003EA7C
		// (set) Token: 0x060005C9 RID: 1481 RVA: 0x00040884 File Offset: 0x0003EA84
		public float areaLightShadowCone
		{
			get
			{
				return this.m_AreaLightShadowCone;
			}
			set
			{
				if (this.m_AreaLightShadowCone == value)
				{
					return;
				}
				this.m_AreaLightShadowCone = Mathf.Clamp(value, 10f, 179f);
				this.UpdateAllLightValues();
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060005CA RID: 1482 RVA: 0x000408AC File Offset: 0x0003EAAC
		// (set) Token: 0x060005CB RID: 1483 RVA: 0x000408B4 File Offset: 0x0003EAB4
		public bool useScreenSpaceShadows
		{
			get
			{
				return this.m_UseScreenSpaceShadows;
			}
			set
			{
				if (this.m_UseScreenSpaceShadows == value)
				{
					return;
				}
				this.m_UseScreenSpaceShadows = value;
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).useScreenSpaceShadows = this.m_UseScreenSpaceShadows;
				}
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060005CC RID: 1484 RVA: 0x000408EF File Offset: 0x0003EAEF
		// (set) Token: 0x060005CD RID: 1485 RVA: 0x00040909 File Offset: 0x0003EB09
		public bool interactsWithSky
		{
			get
			{
				return this.m_InteractsWithSky && this.legacyLight.type == LightType.Directional;
			}
			set
			{
				if (this.m_InteractsWithSky == value)
				{
					return;
				}
				this.m_InteractsWithSky = value;
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).interactsWithSky = this.m_InteractsWithSky;
				}
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060005CE RID: 1486 RVA: 0x00040944 File Offset: 0x0003EB44
		// (set) Token: 0x060005CF RID: 1487 RVA: 0x0004094C File Offset: 0x0003EB4C
		public float angularDiameter
		{
			get
			{
				return this.m_AngularDiameter;
			}
			set
			{
				if (this.m_AngularDiameter == value)
				{
					return;
				}
				this.m_AngularDiameter = value;
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).angularDiameter = this.m_AngularDiameter;
				}
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060005D0 RID: 1488 RVA: 0x00040987 File Offset: 0x0003EB87
		// (set) Token: 0x060005D1 RID: 1489 RVA: 0x0004098F File Offset: 0x0003EB8F
		public float flareSize
		{
			get
			{
				return this.m_FlareSize;
			}
			set
			{
				if (this.m_FlareSize == value)
				{
					return;
				}
				this.m_FlareSize = value;
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).flareSize = this.m_FlareSize;
				}
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060005D2 RID: 1490 RVA: 0x000409CA File Offset: 0x0003EBCA
		// (set) Token: 0x060005D3 RID: 1491 RVA: 0x000409D2 File Offset: 0x0003EBD2
		public Color flareTint
		{
			get
			{
				return this.m_FlareTint;
			}
			set
			{
				if (this.m_FlareTint == value)
				{
					return;
				}
				this.m_FlareTint = value;
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).flareTint = this.m_FlareTint;
				}
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060005D4 RID: 1492 RVA: 0x00040A12 File Offset: 0x0003EC12
		// (set) Token: 0x060005D5 RID: 1493 RVA: 0x00040A1A File Offset: 0x0003EC1A
		public float flareFalloff
		{
			get
			{
				return this.m_FlareFalloff;
			}
			set
			{
				if (this.m_FlareFalloff == value)
				{
					return;
				}
				this.m_FlareFalloff = value;
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).flareFalloff = this.m_FlareFalloff;
				}
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060005D6 RID: 1494 RVA: 0x00040A55 File Offset: 0x0003EC55
		// (set) Token: 0x060005D7 RID: 1495 RVA: 0x00040A5D File Offset: 0x0003EC5D
		public Texture2D surfaceTexture
		{
			get
			{
				return this.m_SurfaceTexture;
			}
			set
			{
				if (this.m_SurfaceTexture == value)
				{
					return;
				}
				this.m_SurfaceTexture = value;
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060005D8 RID: 1496 RVA: 0x00040A75 File Offset: 0x0003EC75
		// (set) Token: 0x060005D9 RID: 1497 RVA: 0x00040A7D File Offset: 0x0003EC7D
		public Color surfaceTint
		{
			get
			{
				return this.m_SurfaceTint;
			}
			set
			{
				if (this.m_SurfaceTint == value)
				{
					return;
				}
				this.m_SurfaceTint = value;
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).surfaceTint = this.m_SurfaceTint;
				}
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060005DA RID: 1498 RVA: 0x00040ABD File Offset: 0x0003ECBD
		// (set) Token: 0x060005DB RID: 1499 RVA: 0x00040AC5 File Offset: 0x0003ECC5
		public float distance
		{
			get
			{
				return this.m_Distance;
			}
			set
			{
				if (this.m_Distance == value)
				{
					return;
				}
				this.m_Distance = value;
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).distance = this.m_Distance;
				}
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060005DC RID: 1500 RVA: 0x00040B00 File Offset: 0x0003ED00
		// (set) Token: 0x060005DD RID: 1501 RVA: 0x00040B08 File Offset: 0x0003ED08
		public bool useRayTracedShadows
		{
			get
			{
				return this.m_UseRayTracedShadows;
			}
			set
			{
				if (this.m_UseRayTracedShadows == value)
				{
					return;
				}
				this.m_UseRayTracedShadows = value;
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).useRayTracedShadows = this.m_UseRayTracedShadows;
				}
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060005DE RID: 1502 RVA: 0x00040B43 File Offset: 0x0003ED43
		// (set) Token: 0x060005DF RID: 1503 RVA: 0x00040B4B File Offset: 0x0003ED4B
		public int numRayTracingSamples
		{
			get
			{
				return this.m_NumRayTracingSamples;
			}
			set
			{
				if (this.m_NumRayTracingSamples == value)
				{
					return;
				}
				this.m_NumRayTracingSamples = Mathf.Clamp(value, 1, 32);
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060005E0 RID: 1504 RVA: 0x00040B66 File Offset: 0x0003ED66
		// (set) Token: 0x060005E1 RID: 1505 RVA: 0x00040B6E File Offset: 0x0003ED6E
		public bool filterTracedShadow
		{
			get
			{
				return this.m_FilterTracedShadow;
			}
			set
			{
				if (this.m_FilterTracedShadow == value)
				{
					return;
				}
				this.m_FilterTracedShadow = value;
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060005E2 RID: 1506 RVA: 0x00040B81 File Offset: 0x0003ED81
		// (set) Token: 0x060005E3 RID: 1507 RVA: 0x00040B89 File Offset: 0x0003ED89
		public int filterSizeTraced
		{
			get
			{
				return this.m_FilterSizeTraced;
			}
			set
			{
				if (this.m_FilterSizeTraced == value)
				{
					return;
				}
				this.m_FilterSizeTraced = Mathf.Clamp(value, 1, 32);
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060005E4 RID: 1508 RVA: 0x00040BA4 File Offset: 0x0003EDA4
		// (set) Token: 0x060005E5 RID: 1509 RVA: 0x00040BAC File Offset: 0x0003EDAC
		public float sunLightConeAngle
		{
			get
			{
				return this.m_SunLightConeAngle;
			}
			set
			{
				if (this.m_SunLightConeAngle == value)
				{
					return;
				}
				this.m_SunLightConeAngle = Mathf.Clamp(value, 0f, 2f);
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060005E6 RID: 1510 RVA: 0x00040BCE File Offset: 0x0003EDCE
		// (set) Token: 0x060005E7 RID: 1511 RVA: 0x00040BD6 File Offset: 0x0003EDD6
		public float lightShadowRadius
		{
			get
			{
				return this.m_LightShadowRadius;
			}
			set
			{
				if (this.m_LightShadowRadius == value)
				{
					return;
				}
				this.m_LightShadowRadius = Mathf.Max(value, 0.001f);
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060005E8 RID: 1512 RVA: 0x00040BF3 File Offset: 0x0003EDF3
		// (set) Token: 0x060005E9 RID: 1513 RVA: 0x00040BFB File Offset: 0x0003EDFB
		public bool semiTransparentShadow
		{
			get
			{
				return this.m_SemiTransparentShadow;
			}
			set
			{
				if (this.m_SemiTransparentShadow == value)
				{
					return;
				}
				this.m_SemiTransparentShadow = value;
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060005EA RID: 1514 RVA: 0x00040C0E File Offset: 0x0003EE0E
		// (set) Token: 0x060005EB RID: 1515 RVA: 0x00040C16 File Offset: 0x0003EE16
		public bool colorShadow
		{
			get
			{
				return this.m_ColorShadow;
			}
			set
			{
				if (this.m_ColorShadow == value)
				{
					return;
				}
				this.m_ColorShadow = value;
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).colorShadow = this.m_ColorShadow;
				}
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060005EC RID: 1516 RVA: 0x00040C51 File Offset: 0x0003EE51
		// (set) Token: 0x060005ED RID: 1517 RVA: 0x00040C59 File Offset: 0x0003EE59
		internal bool distanceBasedFiltering
		{
			get
			{
				return this.m_DistanceBasedFiltering;
			}
			set
			{
				if (this.m_DistanceBasedFiltering == value)
				{
					return;
				}
				this.m_DistanceBasedFiltering = value;
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060005EE RID: 1518 RVA: 0x00040C6C File Offset: 0x0003EE6C
		// (set) Token: 0x060005EF RID: 1519 RVA: 0x00040C74 File Offset: 0x0003EE74
		public float evsmExponent
		{
			get
			{
				return this.m_EvsmExponent;
			}
			set
			{
				if (this.m_EvsmExponent == value)
				{
					return;
				}
				this.m_EvsmExponent = Mathf.Clamp(value, 5f, 42f);
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060005F0 RID: 1520 RVA: 0x00040C96 File Offset: 0x0003EE96
		// (set) Token: 0x060005F1 RID: 1521 RVA: 0x00040C9E File Offset: 0x0003EE9E
		public float evsmLightLeakBias
		{
			get
			{
				return this.m_EvsmLightLeakBias;
			}
			set
			{
				if (this.m_EvsmLightLeakBias == value)
				{
					return;
				}
				this.m_EvsmLightLeakBias = Mathf.Clamp(value, 0f, 1f);
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060005F2 RID: 1522 RVA: 0x00040CC0 File Offset: 0x0003EEC0
		// (set) Token: 0x060005F3 RID: 1523 RVA: 0x00040CC8 File Offset: 0x0003EEC8
		public float evsmVarianceBias
		{
			get
			{
				return this.m_EvsmVarianceBias;
			}
			set
			{
				if (this.m_EvsmVarianceBias == value)
				{
					return;
				}
				this.m_EvsmVarianceBias = Mathf.Clamp(value, 0f, 0.001f);
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060005F4 RID: 1524 RVA: 0x00040CEA File Offset: 0x0003EEEA
		// (set) Token: 0x060005F5 RID: 1525 RVA: 0x00040CF2 File Offset: 0x0003EEF2
		public int evsmBlurPasses
		{
			get
			{
				return this.m_EvsmBlurPasses;
			}
			set
			{
				if (this.m_EvsmBlurPasses == value)
				{
					return;
				}
				this.m_EvsmBlurPasses = Mathf.Clamp(value, 0, 8);
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060005F6 RID: 1526 RVA: 0x00040D0C File Offset: 0x0003EF0C
		// (set) Token: 0x060005F7 RID: 1527 RVA: 0x00040D30 File Offset: 0x0003EF30
		public LightLayerEnum lightlayersMask
		{
			get
			{
				if (!this.linkShadowLayers)
				{
					return this.m_LightlayersMask;
				}
				return (LightLayerEnum)HDAdditionalLightData.RenderingLayerMaskToLightLayer(this.legacyLight.renderingLayerMask);
			}
			set
			{
				this.m_LightlayersMask = value;
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).lightLayer = this.m_LightlayersMask;
				}
				if (this.linkShadowLayers)
				{
					this.legacyLight.renderingLayerMask = HDAdditionalLightData.LightLayerToRenderingLayerMask((int)this.m_LightlayersMask, this.legacyLight.renderingLayerMask);
				}
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060005F8 RID: 1528 RVA: 0x00040D95 File Offset: 0x0003EF95
		// (set) Token: 0x060005F9 RID: 1529 RVA: 0x00040D9D File Offset: 0x0003EF9D
		public bool linkShadowLayers
		{
			get
			{
				return this.m_LinkShadowLayers;
			}
			set
			{
				this.m_LinkShadowLayers = value;
			}
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x00040DA8 File Offset: 0x0003EFA8
		public uint GetLightLayers()
		{
			int lightlayersMask = (int)this.lightlayersMask;
			if (lightlayersMask >= 0)
			{
				return (uint)lightlayersMask;
			}
			return 255U;
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x00040DC8 File Offset: 0x0003EFC8
		public uint GetShadowLayers()
		{
			int num = HDAdditionalLightData.RenderingLayerMaskToLightLayer(this.legacyLight.renderingLayerMask);
			if (num >= 0)
			{
				return (uint)num;
			}
			return 255U;
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060005FC RID: 1532 RVA: 0x00040DF1 File Offset: 0x0003EFF1
		// (set) Token: 0x060005FD RID: 1533 RVA: 0x00040DF9 File Offset: 0x0003EFF9
		public float shadowNearPlane
		{
			get
			{
				return this.m_ShadowNearPlane;
			}
			set
			{
				if (this.m_ShadowNearPlane == value)
				{
					return;
				}
				this.m_ShadowNearPlane = Mathf.Clamp(value, 0f, HDShadowUtils.k_MaxShadowNearPlane);
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060005FE RID: 1534 RVA: 0x00040E1B File Offset: 0x0003F01B
		// (set) Token: 0x060005FF RID: 1535 RVA: 0x00040E23 File Offset: 0x0003F023
		public int blockerSampleCount
		{
			get
			{
				return this.m_BlockerSampleCount;
			}
			set
			{
				if (this.m_BlockerSampleCount == value)
				{
					return;
				}
				this.m_BlockerSampleCount = Mathf.Clamp(value, 1, 64);
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000600 RID: 1536 RVA: 0x00040E3E File Offset: 0x0003F03E
		// (set) Token: 0x06000601 RID: 1537 RVA: 0x00040E46 File Offset: 0x0003F046
		public int filterSampleCount
		{
			get
			{
				return this.m_FilterSampleCount;
			}
			set
			{
				if (this.m_FilterSampleCount == value)
				{
					return;
				}
				this.m_FilterSampleCount = Mathf.Clamp(value, 1, 64);
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000602 RID: 1538 RVA: 0x00040E61 File Offset: 0x0003F061
		// (set) Token: 0x06000603 RID: 1539 RVA: 0x00040E69 File Offset: 0x0003F069
		public float minFilterSize
		{
			get
			{
				return this.m_MinFilterSize;
			}
			set
			{
				if (this.m_MinFilterSize == value)
				{
					return;
				}
				this.m_MinFilterSize = Mathf.Clamp(value, 0f, 1f);
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000604 RID: 1540 RVA: 0x00040E8B File Offset: 0x0003F08B
		// (set) Token: 0x06000605 RID: 1541 RVA: 0x00040E93 File Offset: 0x0003F093
		public int kernelSize
		{
			get
			{
				return this.m_KernelSize;
			}
			set
			{
				if (this.m_KernelSize == value)
				{
					return;
				}
				this.m_KernelSize = Mathf.Clamp(value, 1, 32);
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000606 RID: 1542 RVA: 0x00040EAE File Offset: 0x0003F0AE
		// (set) Token: 0x06000607 RID: 1543 RVA: 0x00040EB6 File Offset: 0x0003F0B6
		public float lightAngle
		{
			get
			{
				return this.m_LightAngle;
			}
			set
			{
				if (this.m_LightAngle == value)
				{
					return;
				}
				this.m_LightAngle = Mathf.Clamp(value, 0f, 9f);
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000608 RID: 1544 RVA: 0x00040ED8 File Offset: 0x0003F0D8
		// (set) Token: 0x06000609 RID: 1545 RVA: 0x00040EE0 File Offset: 0x0003F0E0
		public float maxDepthBias
		{
			get
			{
				return this.m_MaxDepthBias;
			}
			set
			{
				if (this.m_MaxDepthBias == value)
				{
					return;
				}
				this.m_MaxDepthBias = Mathf.Clamp(value, 0.0001f, 0.01f);
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x0600060A RID: 1546 RVA: 0x00040F02 File Offset: 0x0003F102
		// (set) Token: 0x0600060B RID: 1547 RVA: 0x00040F0F File Offset: 0x0003F10F
		public float range
		{
			get
			{
				return this.legacyLight.range;
			}
			set
			{
				this.legacyLight.range = value;
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x0600060C RID: 1548 RVA: 0x00040F1D File Offset: 0x0003F11D
		// (set) Token: 0x0600060D RID: 1549 RVA: 0x00040F2A File Offset: 0x0003F12A
		public Color color
		{
			get
			{
				return this.legacyLight.color;
			}
			set
			{
				this.legacyLight.color = value;
				this.UpdateAreaLightEmissiveMesh(false);
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x0600060E RID: 1550 RVA: 0x00040F3F File Offset: 0x0003F13F
		public IntScalableSettingValue shadowResolution
		{
			get
			{
				return this.m_ShadowResolution;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x0600060F RID: 1551 RVA: 0x00040F47 File Offset: 0x0003F147
		// (set) Token: 0x06000610 RID: 1552 RVA: 0x00040F4F File Offset: 0x0003F14F
		public float shadowDimmer
		{
			get
			{
				return this.m_ShadowDimmer;
			}
			set
			{
				if (this.m_ShadowDimmer == value)
				{
					return;
				}
				this.m_ShadowDimmer = Mathf.Clamp01(value);
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).shadowDimmer = this.m_ShadowDimmer;
				}
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000611 RID: 1553 RVA: 0x00040F8F File Offset: 0x0003F18F
		// (set) Token: 0x06000612 RID: 1554 RVA: 0x00040FA5 File Offset: 0x0003F1A5
		public float volumetricShadowDimmer
		{
			get
			{
				if (!this.useVolumetric)
				{
					return 0f;
				}
				return this.m_VolumetricShadowDimmer;
			}
			set
			{
				if (this.m_VolumetricShadowDimmer == value)
				{
					return;
				}
				this.m_VolumetricShadowDimmer = Mathf.Clamp01(value);
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).volumetricShadowDimmer = this.m_VolumetricShadowDimmer;
				}
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000613 RID: 1555 RVA: 0x00040FE5 File Offset: 0x0003F1E5
		// (set) Token: 0x06000614 RID: 1556 RVA: 0x00040FF0 File Offset: 0x0003F1F0
		public float shadowFadeDistance
		{
			get
			{
				return this.m_ShadowFadeDistance;
			}
			set
			{
				if (this.m_ShadowFadeDistance == value)
				{
					return;
				}
				this.m_ShadowFadeDistance = Mathf.Clamp(value, 0f, float.MaxValue);
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).shadowFadeDistance = this.m_ShadowFadeDistance;
				}
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000615 RID: 1557 RVA: 0x00041045 File Offset: 0x0003F245
		public BoolScalableSettingValue useContactShadow
		{
			get
			{
				return this.m_UseContactShadow;
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000616 RID: 1558 RVA: 0x0004104D File Offset: 0x0003F24D
		// (set) Token: 0x06000617 RID: 1559 RVA: 0x00041055 File Offset: 0x0003F255
		public bool rayTraceContactShadow
		{
			get
			{
				return this.m_RayTracedContactShadow;
			}
			set
			{
				if (this.m_RayTracedContactShadow == value)
				{
					return;
				}
				this.m_RayTracedContactShadow = value;
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000618 RID: 1560 RVA: 0x00041068 File Offset: 0x0003F268
		// (set) Token: 0x06000619 RID: 1561 RVA: 0x00041070 File Offset: 0x0003F270
		public Color shadowTint
		{
			get
			{
				return this.m_ShadowTint;
			}
			set
			{
				if (this.m_ShadowTint == value)
				{
					return;
				}
				this.m_ShadowTint = value;
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).shadowTint = this.m_ShadowTint;
				}
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x0600061A RID: 1562 RVA: 0x000410B0 File Offset: 0x0003F2B0
		// (set) Token: 0x0600061B RID: 1563 RVA: 0x000410B8 File Offset: 0x0003F2B8
		public bool penumbraTint
		{
			get
			{
				return this.m_PenumbraTint;
			}
			set
			{
				if (this.m_PenumbraTint == value)
				{
					return;
				}
				this.m_PenumbraTint = value;
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).penumbraTint = this.m_PenumbraTint;
				}
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600061C RID: 1564 RVA: 0x000410F3 File Offset: 0x0003F2F3
		// (set) Token: 0x0600061D RID: 1565 RVA: 0x000410FB File Offset: 0x0003F2FB
		public float normalBias
		{
			get
			{
				return this.m_NormalBias;
			}
			set
			{
				if (this.m_NormalBias == value)
				{
					return;
				}
				this.m_NormalBias = value;
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600061E RID: 1566 RVA: 0x0004110E File Offset: 0x0003F30E
		// (set) Token: 0x0600061F RID: 1567 RVA: 0x00041116 File Offset: 0x0003F316
		public float slopeBias
		{
			get
			{
				return this.m_SlopeBias;
			}
			set
			{
				if (this.m_SlopeBias == value)
				{
					return;
				}
				this.m_SlopeBias = value;
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000620 RID: 1568 RVA: 0x00041129 File Offset: 0x0003F329
		// (set) Token: 0x06000621 RID: 1569 RVA: 0x00041134 File Offset: 0x0003F334
		public ShadowUpdateMode shadowUpdateMode
		{
			get
			{
				return this.m_ShadowUpdateMode;
			}
			set
			{
				if (this.m_ShadowUpdateMode == value)
				{
					return;
				}
				if (this.m_ShadowUpdateMode != ShadowUpdateMode.EveryFrame && value == ShadowUpdateMode.EveryFrame)
				{
					if (!this.preserveCachedShadow)
					{
						HDShadowManager.cachedShadowManager.EvictLight(this);
					}
				}
				else if (this.legacyLight.shadows != LightShadows.None && this.m_ShadowUpdateMode == ShadowUpdateMode.EveryFrame && value != ShadowUpdateMode.EveryFrame && (this.shadowUpdateMode != ShadowUpdateMode.OnDemand || this.onDemandShadowRenderOnPlacement))
				{
					HDShadowManager.cachedShadowManager.RegisterLight(this);
				}
				this.m_ShadowUpdateMode = value;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000622 RID: 1570 RVA: 0x000411A6 File Offset: 0x0003F3A6
		// (set) Token: 0x06000623 RID: 1571 RVA: 0x000411AE File Offset: 0x0003F3AE
		public bool alwaysDrawDynamicShadows
		{
			get
			{
				return this.m_AlwaysDrawDynamicShadows;
			}
			set
			{
				this.m_AlwaysDrawDynamicShadows = value;
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000624 RID: 1572 RVA: 0x000411B7 File Offset: 0x0003F3B7
		// (set) Token: 0x06000625 RID: 1573 RVA: 0x000411BF File Offset: 0x0003F3BF
		public bool updateUponLightMovement
		{
			get
			{
				return this.m_UpdateShadowOnLightMovement;
			}
			set
			{
				if (this.m_UpdateShadowOnLightMovement != value)
				{
					if (this.m_UpdateShadowOnLightMovement)
					{
						HDShadowManager.cachedShadowManager.RegisterTransformToCache(this);
					}
					else
					{
						HDShadowManager.cachedShadowManager.RegisterTransformToCache(this);
					}
					this.m_UpdateShadowOnLightMovement = value;
				}
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000626 RID: 1574 RVA: 0x000411F1 File Offset: 0x0003F3F1
		// (set) Token: 0x06000627 RID: 1575 RVA: 0x000411F9 File Offset: 0x0003F3F9
		public float cachedShadowTranslationUpdateThreshold
		{
			get
			{
				return this.m_CachedShadowTranslationThreshold;
			}
			set
			{
				if (this.m_CachedShadowTranslationThreshold == value)
				{
					return;
				}
				this.m_CachedShadowTranslationThreshold = value;
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000628 RID: 1576 RVA: 0x0004120C File Offset: 0x0003F40C
		// (set) Token: 0x06000629 RID: 1577 RVA: 0x00041214 File Offset: 0x0003F414
		public float cachedShadowAngleUpdateThreshold
		{
			get
			{
				return this.m_CachedShadowAngularThreshold;
			}
			set
			{
				if (this.m_CachedShadowAngularThreshold == value)
				{
					return;
				}
				this.m_CachedShadowAngularThreshold = value;
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x0600062A RID: 1578 RVA: 0x00041227 File Offset: 0x0003F427
		// (set) Token: 0x0600062B RID: 1579 RVA: 0x00041230 File Offset: 0x0003F430
		public float barnDoorAngle
		{
			get
			{
				return this.m_BarnDoorAngle;
			}
			set
			{
				if (this.m_BarnDoorAngle == value)
				{
					return;
				}
				this.m_BarnDoorAngle = Mathf.Clamp(value, 0f, 90f);
				this.UpdateAllLightValues();
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).barnDoorAngle = this.m_BarnDoorAngle;
				}
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x0600062C RID: 1580 RVA: 0x0004128B File Offset: 0x0003F48B
		// (set) Token: 0x0600062D RID: 1581 RVA: 0x00041294 File Offset: 0x0003F494
		public float barnDoorLength
		{
			get
			{
				return this.m_BarnDoorLength;
			}
			set
			{
				if (this.m_BarnDoorLength == value)
				{
					return;
				}
				this.m_BarnDoorLength = Mathf.Clamp(value, 0f, float.MaxValue);
				this.UpdateAllLightValues();
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).barnDoorLength = this.m_BarnDoorLength;
				}
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x0600062E RID: 1582 RVA: 0x000412EF File Offset: 0x0003F4EF
		// (set) Token: 0x0600062F RID: 1583 RVA: 0x000412F7 File Offset: 0x0003F4F7
		public bool preserveCachedShadow
		{
			get
			{
				return this.m_preserveCachedShadow;
			}
			set
			{
				if (this.m_preserveCachedShadow == value)
				{
					return;
				}
				this.m_preserveCachedShadow = value;
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000630 RID: 1584 RVA: 0x0004130A File Offset: 0x0003F50A
		// (set) Token: 0x06000631 RID: 1585 RVA: 0x00041312 File Offset: 0x0003F512
		public bool onDemandShadowRenderOnPlacement
		{
			get
			{
				return this.m_OnDemandShadowRenderOnPlacement;
			}
			set
			{
				if (this.m_OnDemandShadowRenderOnPlacement == value)
				{
					return;
				}
				this.m_OnDemandShadowRenderOnPlacement = value;
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000632 RID: 1586 RVA: 0x00041325 File Offset: 0x0003F525
		// (set) Token: 0x06000633 RID: 1587 RVA: 0x0004132D File Offset: 0x0003F52D
		public bool affectsVolumetric
		{
			get
			{
				return this.useVolumetric;
			}
			set
			{
				this.useVolumetric = value;
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).affectVolumetric = this.useVolumetric;
				}
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000634 RID: 1588 RVA: 0x0004135E File Offset: 0x0003F55E
		// (set) Token: 0x06000635 RID: 1589 RVA: 0x00041366 File Offset: 0x0003F566
		internal float[] shadowCascadeRatios
		{
			get
			{
				return this.m_ShadowCascadeRatios;
			}
			set
			{
				this.m_ShadowCascadeRatios = value;
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000636 RID: 1590 RVA: 0x0004136F File Offset: 0x0003F56F
		// (set) Token: 0x06000637 RID: 1591 RVA: 0x00041377 File Offset: 0x0003F577
		internal float[] shadowCascadeBorders
		{
			get
			{
				return this.m_ShadowCascadeBorders;
			}
			set
			{
				this.m_ShadowCascadeBorders = value;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000638 RID: 1592 RVA: 0x00041380 File Offset: 0x0003F580
		// (set) Token: 0x06000639 RID: 1593 RVA: 0x00041388 File Offset: 0x0003F588
		internal int shadowAlgorithm
		{
			get
			{
				return this.m_ShadowAlgorithm;
			}
			set
			{
				this.m_ShadowAlgorithm = value;
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x0600063A RID: 1594 RVA: 0x00041391 File Offset: 0x0003F591
		// (set) Token: 0x0600063B RID: 1595 RVA: 0x00041399 File Offset: 0x0003F599
		internal int shadowVariant
		{
			get
			{
				return this.m_ShadowVariant;
			}
			set
			{
				this.m_ShadowVariant = value;
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x0600063C RID: 1596 RVA: 0x000413A2 File Offset: 0x0003F5A2
		// (set) Token: 0x0600063D RID: 1597 RVA: 0x000413AA File Offset: 0x0003F5AA
		internal int shadowPrecision
		{
			get
			{
				return this.m_ShadowPrecision;
			}
			set
			{
				this.m_ShadowPrecision = value;
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x0600063E RID: 1598 RVA: 0x000413B3 File Offset: 0x0003F5B3
		internal Light legacyLight
		{
			get
			{
				if (this.m_Light == null)
				{
					base.TryGetComponent<Light>(out this.m_Light);
				}
				return this.m_Light;
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600063F RID: 1599 RVA: 0x000413D6 File Offset: 0x0003F5D6
		// (set) Token: 0x06000640 RID: 1600 RVA: 0x000413DE File Offset: 0x0003F5DE
		internal MeshRenderer emissiveMeshRenderer { get; private set; }

		// Token: 0x06000641 RID: 1601 RVA: 0x000413E8 File Offset: 0x0003F5E8
		private void CreateChildEmissiveMeshViewerIfNeeded()
		{
			bool flag = this.m_ChildEmissiveMeshViewer != null && !this.m_ChildEmissiveMeshViewer.Equals(null);
			if (!flag)
			{
				foreach (object obj in base.transform)
				{
					Transform transform = (Transform)obj;
					transform.GetComponents(typeof(Component));
					if (transform.name == "EmissiveMeshViewer" && transform.hideFlags == (HideFlags.DontSaveInEditor | HideFlags.NotEditable | HideFlags.DontSaveInBuild) && transform.GetComponents(typeof(MeshFilter)).Length == 1 && transform.GetComponents(typeof(MeshRenderer)).Length == 1 && transform.GetComponents(typeof(Component)).Length == 3)
					{
						this.m_ChildEmissiveMeshViewer = transform.gameObject;
						this.m_ChildEmissiveMeshViewer.transform.localPosition = Vector3.zero;
						this.m_ChildEmissiveMeshViewer.transform.localRotation = Quaternion.identity;
						this.m_ChildEmissiveMeshViewer.transform.localScale = Vector3.one;
						this.m_ChildEmissiveMeshViewer.layer = ((this.areaLightEmissiveMeshLayer == -1) ? base.gameObject.layer : this.areaLightEmissiveMeshLayer);
						this.m_EmissiveMeshFilter = this.m_ChildEmissiveMeshViewer.GetComponent<MeshFilter>();
						this.emissiveMeshRenderer = this.m_ChildEmissiveMeshViewer.GetComponent<MeshRenderer>();
						this.emissiveMeshRenderer.shadowCastingMode = this.m_AreaLightEmissiveMeshShadowCastingMode;
						this.emissiveMeshRenderer.motionVectorGenerationMode = this.m_AreaLightEmissiveMeshMotionVectorGenerationMode;
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				this.m_ChildEmissiveMeshViewer = new GameObject("EmissiveMeshViewer", new Type[]
				{
					typeof(MeshFilter),
					typeof(MeshRenderer)
				});
				this.m_ChildEmissiveMeshViewer.hideFlags = (HideFlags.DontSaveInEditor | HideFlags.NotEditable | HideFlags.DontSaveInBuild);
				this.m_ChildEmissiveMeshViewer.transform.SetParent(base.transform);
				this.m_ChildEmissiveMeshViewer.transform.localPosition = Vector3.zero;
				this.m_ChildEmissiveMeshViewer.transform.localRotation = Quaternion.identity;
				this.m_ChildEmissiveMeshViewer.transform.localScale = Vector3.one;
				this.m_ChildEmissiveMeshViewer.layer = ((this.areaLightEmissiveMeshLayer == -1) ? base.gameObject.layer : this.areaLightEmissiveMeshLayer);
				this.m_EmissiveMeshFilter = this.m_ChildEmissiveMeshViewer.GetComponent<MeshFilter>();
				this.emissiveMeshRenderer = this.m_ChildEmissiveMeshViewer.GetComponent<MeshRenderer>();
				this.emissiveMeshRenderer.shadowCastingMode = this.m_AreaLightEmissiveMeshShadowCastingMode;
				this.emissiveMeshRenderer.motionVectorGenerationMode = this.m_AreaLightEmissiveMeshMotionVectorGenerationMode;
			}
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x000416AC File Offset: 0x0003F8AC
		private void DestroyChildEmissiveMeshViewer()
		{
			this.m_EmissiveMeshFilter = null;
			this.emissiveMeshRenderer.enabled = false;
			this.emissiveMeshRenderer = null;
			CoreUtils.Destroy(this.m_ChildEmissiveMeshViewer);
			this.m_ChildEmissiveMeshViewer = null;
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000643 RID: 1603 RVA: 0x000416DA File Offset: 0x0003F8DA
		// (set) Token: 0x06000644 RID: 1604 RVA: 0x000416E2 File Offset: 0x0003F8E2
		public ShadowCastingMode areaLightEmissiveMeshShadowCastingMode
		{
			get
			{
				return this.m_AreaLightEmissiveMeshShadowCastingMode;
			}
			set
			{
				if (this.m_AreaLightEmissiveMeshShadowCastingMode == value)
				{
					return;
				}
				this.m_AreaLightEmissiveMeshShadowCastingMode = value;
				if (this.emissiveMeshRenderer != null && !this.emissiveMeshRenderer.Equals(null))
				{
					this.emissiveMeshRenderer.shadowCastingMode = this.m_AreaLightEmissiveMeshShadowCastingMode;
				}
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000645 RID: 1605 RVA: 0x00041722 File Offset: 0x0003F922
		// (set) Token: 0x06000646 RID: 1606 RVA: 0x0004172A File Offset: 0x0003F92A
		public MotionVectorGenerationMode areaLightEmissiveMeshMotionVectorGenerationMode
		{
			get
			{
				return this.m_AreaLightEmissiveMeshMotionVectorGenerationMode;
			}
			set
			{
				if (this.m_AreaLightEmissiveMeshMotionVectorGenerationMode == value)
				{
					return;
				}
				this.m_AreaLightEmissiveMeshMotionVectorGenerationMode = value;
				if (this.emissiveMeshRenderer != null && !this.emissiveMeshRenderer.Equals(null))
				{
					this.emissiveMeshRenderer.motionVectorGenerationMode = this.m_AreaLightEmissiveMeshMotionVectorGenerationMode;
				}
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000647 RID: 1607 RVA: 0x0004176A File Offset: 0x0003F96A
		// (set) Token: 0x06000648 RID: 1608 RVA: 0x00041774 File Offset: 0x0003F974
		public int areaLightEmissiveMeshLayer
		{
			get
			{
				return this.m_AreaLightEmissiveMeshLayer;
			}
			set
			{
				if (this.m_AreaLightEmissiveMeshLayer == value)
				{
					return;
				}
				this.m_AreaLightEmissiveMeshLayer = value;
				if (this.emissiveMeshRenderer != null && !this.emissiveMeshRenderer.Equals(null) && this.m_AreaLightEmissiveMeshLayer != -1)
				{
					this.emissiveMeshRenderer.gameObject.layer = this.m_AreaLightEmissiveMeshLayer;
				}
			}
		}

		// Token: 0x06000649 RID: 1609 RVA: 0x000417CD File Offset: 0x0003F9CD
		private void OnDestroy()
		{
			if (this.lightIdxForCachedShadows >= 0)
			{
				HDShadowManager.cachedShadowManager.EvictLight(this);
			}
			this.DestroyHDLightRenderEntity();
		}

		// Token: 0x0600064A RID: 1610 RVA: 0x000417E9 File Offset: 0x0003F9E9
		internal void DestroyHDLightRenderEntity()
		{
			if (!this.lightEntity.valid)
			{
				return;
			}
			HDLightRenderDatabase.instance.DestroyEntity(this.lightEntity);
			this.lightEntity = HDLightRenderEntity.Invalid;
		}

		// Token: 0x0600064B RID: 1611 RVA: 0x00041814 File Offset: 0x0003FA14
		private void OnDisable()
		{
			if (!this.preserveCachedShadow && this.lightIdxForCachedShadows >= 0)
			{
				HDShadowManager.cachedShadowManager.EvictLight(this);
			}
			this.SetEmissiveMeshRendererEnabled(false);
			HDAdditionalLightData.s_overlappingHDLights.Remove(this);
			this.DestroyHDLightRenderEntity();
		}

		// Token: 0x0600064C RID: 1612 RVA: 0x0004184B File Offset: 0x0003FA4B
		private void SetEmissiveMeshRendererEnabled(bool enabled)
		{
			if (this.displayAreaLightEmissiveMesh && this.emissiveMeshRenderer)
			{
				this.emissiveMeshRenderer.enabled = enabled;
			}
		}

		// Token: 0x0600064D RID: 1613 RVA: 0x0004186E File Offset: 0x0003FA6E
		private int GetShadowRequestCount(HDShadowSettings shadowSettings, HDLightType lightType)
		{
			if (lightType == HDLightType.Point)
			{
				return 6;
			}
			if (lightType != HDLightType.Directional)
			{
				return 1;
			}
			return shadowSettings.cascadeShadowSplitCount.value;
		}

		// Token: 0x0600064E RID: 1614 RVA: 0x00041887 File Offset: 0x0003FA87
		public void RequestShadowMapRendering()
		{
			if (this.shadowUpdateMode == ShadowUpdateMode.OnDemand)
			{
				HDShadowManager.cachedShadowManager.ScheduleShadowUpdate(this);
			}
		}

		// Token: 0x0600064F RID: 1615 RVA: 0x0004189D File Offset: 0x0003FA9D
		public void RequestSubShadowMapRendering(int shadowIndex)
		{
			if (this.shadowUpdateMode == ShadowUpdateMode.OnDemand)
			{
				HDShadowManager.cachedShadowManager.ScheduleShadowUpdate(this, shadowIndex);
			}
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x000418B4 File Offset: 0x0003FAB4
		internal bool ShadowIsUpdatedEveryFrame()
		{
			return this.shadowUpdateMode == ShadowUpdateMode.EveryFrame;
		}

		// Token: 0x06000651 RID: 1617 RVA: 0x000418BF File Offset: 0x0003FABF
		internal ShadowMapUpdateType GetShadowUpdateType(HDLightType lightType)
		{
			if (this.ShadowIsUpdatedEveryFrame())
			{
				return ShadowMapUpdateType.Dynamic;
			}
			if (this.m_AlwaysDrawDynamicShadows)
			{
				if (lightType != HDLightType.Directional)
				{
					return ShadowMapUpdateType.Mixed;
				}
				if (HDCachedShadowManager.instance.DirectionalHasCachedAtlas())
				{
					return ShadowMapUpdateType.Mixed;
				}
			}
			return ShadowMapUpdateType.Cached;
		}

		// Token: 0x06000652 RID: 1618 RVA: 0x000418E8 File Offset: 0x0003FAE8
		internal int GetResolutionFromSettings(ShadowMapType shadowMapType, HDShadowInitParameters initParameters)
		{
			switch (shadowMapType)
			{
			case ShadowMapType.CascadedDirectional:
				return Math.Min(this.m_ShadowResolution.Value(initParameters.shadowResolutionDirectional), initParameters.maxDirectionalShadowMapResolution);
			case ShadowMapType.PunctualAtlas:
				return Math.Min(this.m_ShadowResolution.Value(initParameters.shadowResolutionPunctual), initParameters.maxPunctualShadowMapResolution);
			case ShadowMapType.AreaLightAtlas:
				return Math.Min(this.m_ShadowResolution.Value(initParameters.shadowResolutionArea), initParameters.maxAreaShadowMapResolution);
			default:
				return 0;
			}
		}

		// Token: 0x06000653 RID: 1619 RVA: 0x00041961 File Offset: 0x0003FB61
		internal int GetResolutionFromSettings(HDLightType lightType, HDShadowInitParameters initParameters)
		{
			return this.GetResolutionFromSettings(this.GetShadowMapType(lightType), initParameters);
		}

		// Token: 0x06000654 RID: 1620 RVA: 0x00041974 File Offset: 0x0003FB74
		internal void ReserveShadowMap(Camera camera, HDShadowManager shadowManager, HDShadowSettings shadowSettings, in HDShadowInitParameters initParameters, in VisibleLight visibleLight, HDLightType lightType)
		{
			if (this.shadowRequests == null || this.m_ShadowRequestIndices == null || this.m_CachedViewPositions == null)
			{
				this.shadowRequests = new HDShadowRequest[6];
				this.m_ShadowRequestIndices = new int[6];
				this.m_CachedViewPositions = new Vector3[6];
				for (int i = 0; i < 6; i++)
				{
					this.shadowRequests[i] = new HDShadowRequest();
				}
			}
			ShadowMapType shadowMapType = this.GetShadowMapType(lightType);
			int resolutionFromSettings = this.GetResolutionFromSettings(shadowMapType, initParameters);
			Vector2 vector = new Vector2((float)resolutionFromSettings, (float)resolutionFromSettings);
			bool flag = false | (shadowMapType == ShadowMapType.PunctualAtlas && initParameters.punctualLightShadowAtlas.useDynamicViewportRescale) | (shadowMapType == ShadowMapType.AreaLightAtlas && initParameters.areaLightShadowAtlas.useDynamicViewportRescale);
			bool flag2 = !this.ShadowIsUpdatedEveryFrame();
			if (flag && !flag2)
			{
				float num = Mathf.Clamp01(Vector3.Distance(camera.transform.position, visibleLight.GetPosition()) / shadowSettings.maxShadowDistance.value);
				num = 1f - Mathf.Pow(num, 2f);
				VisibleLight visibleLight2 = visibleLight;
				float b = Mathf.Clamp01(visibleLight2.range / Vector3.Distance(camera.transform.position, visibleLight.GetPosition()));
				float num2 = Mathf.Max(num, b);
				num2 = (float)Mathf.RoundToInt(num2 * 64f) / 64f;
				vector = Vector2.Lerp(16f * Vector2.one, vector, num2);
			}
			vector = Vector2.Max(vector, new Vector2(16f, 16f));
			if (lightType == HDLightType.Directional)
			{
				shadowManager.UpdateDirectionalShadowResolution((int)vector.x, shadowSettings.cascadeShadowSplitCount.value);
			}
			int shadowRequestCount = this.GetShadowRequestCount(shadowSettings, lightType);
			ShadowMapUpdateType shadowUpdateType = this.GetShadowUpdateType(lightType);
			for (int j = 0; j < shadowRequestCount; j++)
			{
				this.m_ShadowRequestIndices[j] = shadowManager.ReserveShadowResolutions(flag2 ? new Vector2((float)resolutionFromSettings, (float)resolutionFromSettings) : vector, this.shadowMapType, base.GetInstanceID(), j, shadowUpdateType);
			}
		}

		// Token: 0x06000655 RID: 1621 RVA: 0x00041B74 File Offset: 0x0003FD74
		internal static float GetAreaLightOffsetForShadows(Vector2 shapeSize, float coneAngle)
		{
			float num = Mathf.Min(shapeSize.x, shapeSize.y) * 0.5f;
			float num2 = coneAngle * 0.5f;
			float num3 = 1f / Mathf.Tan(num2 * 0.017453292f);
			return -(num * num3);
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x00041BB8 File Offset: 0x0003FDB8
		private void UpdateDirectionalShadowRequest(HDShadowManager manager, HDShadowSettings shadowSettings, VisibleLight visibleLight, CullingResults cullResults, Vector2 viewportSize, int requestIndex, int lightIndex, Vector3 cameraPos, HDShadowRequest shadowRequest, out Matrix4x4 invViewProjection)
		{
			float shadowNearPlaneOffset = QualitySettings.shadowNearPlaneOffset;
			HDShadowUtils.ExtractDirectionalLightData(visibleLight, viewportSize, (uint)requestIndex, shadowSettings.cascadeShadowSplitCount.value, shadowSettings.cascadeShadowSplits, shadowNearPlaneOffset, cullResults, lightIndex, out shadowRequest.view, out invViewProjection, out shadowRequest.projection, out shadowRequest.deviceProjection, out shadowRequest.deviceProjectionYFlip, out shadowRequest.splitData);
			Vector4 cullingSphere = shadowRequest.splitData.cullingSphere;
			if (ShaderConfig.s_CameraRelativeRendering != 0)
			{
				cullingSphere.x -= cameraPos.x;
				cullingSphere.y -= cameraPos.y;
				cullingSphere.z -= cameraPos.z;
			}
			manager.UpdateCascade(requestIndex, cullingSphere, shadowSettings.cascadeShadowBorders[requestIndex]);
		}

		// Token: 0x06000657 RID: 1623 RVA: 0x00041C6C File Offset: 0x0003FE6C
		internal void UpdateShadowRequestData(HDCamera hdCamera, HDShadowManager manager, HDShadowSettings shadowSettings, VisibleLight visibleLight, CullingResults cullResults, int lightIndex, LightingDebugSettings lightingDebugSettings, HDShadowFilteringQuality filteringQuality, HDAreaShadowFilteringQuality areaFilteringQuality, Vector2 viewportSize, HDLightType lightType, int shadowIndex, ref HDShadowRequest shadowRequest)
		{
			Matrix4x4 identity = Matrix4x4.identity;
			Vector3 worldSpaceCameraPos = hdCamera.mainViewConstants.worldSpaceCameraPos;
			float forwardOffset = 0f;
			switch (lightType)
			{
			case HDLightType.Spot:
			{
				float spotAngle = this.useCustomSpotLightShadowCone ? Math.Min(this.customSpotLightShadowCone, visibleLight.light.spotAngle) : visibleLight.light.spotAngle;
				HDShadowUtils.ExtractSpotLightData(this.spotLightShape, spotAngle, this.shadowNearPlane, this.aspectRatio, this.shapeWidth, this.shapeHeight, visibleLight, viewportSize, this.normalBias, filteringQuality, out shadowRequest.view, out identity, out shadowRequest.projection, out shadowRequest.deviceProjection, out shadowRequest.deviceProjectionYFlip, out shadowRequest.splitData);
				shadowRequest.projectionType = ((this.spotLightShape == SpotLightShape.Box) ? BatchCullingProjectionType.Orthographic : BatchCullingProjectionType.Perspective);
				if (this.CustomViewCallbackEvent != null)
				{
					shadowRequest.view = this.CustomViewCallbackEvent(visibleLight.localToWorldMatrix);
				}
				break;
			}
			case HDLightType.Directional:
				this.UpdateDirectionalShadowRequest(manager, shadowSettings, visibleLight, cullResults, viewportSize, shadowIndex, lightIndex, worldSpaceCameraPos, shadowRequest, out identity);
				shadowRequest.projectionType = BatchCullingProjectionType.Orthographic;
				break;
			case HDLightType.Point:
				HDShadowUtils.ExtractPointLightData(visibleLight, viewportSize, this.shadowNearPlane, this.normalBias, (uint)shadowIndex, filteringQuality, out shadowRequest.view, out identity, out shadowRequest.projection, out shadowRequest.deviceProjection, out shadowRequest.deviceProjectionYFlip, out shadowRequest.splitData);
				shadowRequest.projectionType = BatchCullingProjectionType.Perspective;
				break;
			case HDLightType.Area:
			{
				AreaLightShape areaLightShape = this.areaLightShape;
				if (areaLightShape != AreaLightShape.Rectangle)
				{
					if (areaLightShape != AreaLightShape.Tube)
					{
					}
				}
				else
				{
					Vector2 shapeSize = new Vector2(this.shapeWidth, this.m_ShapeHeight);
					forwardOffset = HDAdditionalLightData.GetAreaLightOffsetForShadows(shapeSize, this.areaLightShadowCone);
					HDShadowUtils.ExtractRectangleAreaLightData(visibleLight, forwardOffset, this.areaLightShadowCone, this.shadowNearPlane, shapeSize, viewportSize, this.normalBias, areaFilteringQuality, out shadowRequest.view, out identity, out shadowRequest.projection, out shadowRequest.deviceProjection, out shadowRequest.deviceProjectionYFlip, out shadowRequest.splitData);
					shadowRequest.projectionType = BatchCullingProjectionType.Perspective;
				}
				break;
			}
			}
			this.SetCommonShadowRequestSettings(shadowRequest, visibleLight, forwardOffset, worldSpaceCameraPos, identity, viewportSize, lightIndex, lightType, filteringQuality, areaFilteringQuality);
		}

		// Token: 0x06000658 RID: 1624 RVA: 0x00041E8C File Offset: 0x0004008C
		internal int UpdateShadowRequest(HDCamera hdCamera, HDShadowManager manager, HDShadowSettings shadowSettings, VisibleLight visibleLight, CullingResults cullResults, int lightIndex, LightingDebugSettings lightingDebugSettings, HDShadowFilteringQuality filteringQuality, HDAreaShadowFilteringQuality areaFilteringQuality, out int shadowRequestCount)
		{
			int num = -1;
			Vector3 worldSpaceCameraPos = hdCamera.mainViewConstants.worldSpaceCameraPos;
			shadowRequestCount = 0;
			HDLightType type = this.type;
			int shadowRequestCount2 = this.GetShadowRequestCount(shadowSettings, type);
			ShadowMapUpdateType shadowUpdateType = this.GetShadowUpdateType(type);
			bool flag = !this.ShadowIsUpdatedEveryFrame();
			bool flag2 = shadowUpdateType == ShadowMapUpdateType.Cached;
			bool flag3 = false;
			bool flag4 = true;
			if (flag)
			{
				flag4 = (!HDShadowManager.cachedShadowManager.LightIsPendingPlacement(this, this.shadowMapType) && this.lightIdxForCachedShadows != -1);
				flag3 = HDShadowManager.cachedShadowManager.NeedRenderingDueToTransformChange(this, type);
			}
			for (int i = 0; i < shadowRequestCount2; i++)
			{
				HDShadowRequest hdshadowRequest = this.shadowRequests[i];
				Matrix4x4 identity = Matrix4x4.identity;
				int num2 = this.m_ShadowRequestIndices[i];
				HDShadowResolutionRequest resolutionRequest = manager.GetResolutionRequest(num2);
				if (resolutionRequest != null)
				{
					int shadowIdx = this.lightIdxForCachedShadows + i;
					bool flag5 = false;
					bool flag6 = !flag2;
					bool flag7 = false;
					if (flag && flag4)
					{
						flag5 = (flag3 || HDShadowManager.cachedShadowManager.ShadowIsPendingUpdate(shadowIdx, this.shadowMapType));
						HDShadowManager.cachedShadowManager.UpdateResolutionRequest(ref resolutionRequest, shadowIdx, this.shadowMapType);
					}
					hdshadowRequest.isInCachedAtlas = flag2;
					hdshadowRequest.isMixedCached = (shadowUpdateType == ShadowMapUpdateType.Mixed);
					hdshadowRequest.shouldUseCachedShadowData = false;
					Vector2 resolution = resolutionRequest.resolution;
					if (num2 != -1)
					{
						hdshadowRequest.dynamicAtlasViewport = resolutionRequest.dynamicAtlasViewport;
						hdshadowRequest.cachedAtlasViewport = resolutionRequest.cachedAtlasViewport;
						if (flag5)
						{
							this.m_CachedViewPositions[i] = worldSpaceCameraPos;
							hdshadowRequest.cachedShadowData.cacheTranslationDelta = new Vector3(0f, 0f, 0f);
							this.UpdateShadowRequestData(hdCamera, manager, shadowSettings, visibleLight, cullResults, lightIndex, lightingDebugSettings, filteringQuality, areaFilteringQuality, resolution, type, i, ref hdshadowRequest);
							flag7 = true;
							hdshadowRequest.shouldUseCachedShadowData = false;
							hdshadowRequest.shouldRenderCachedComponent = true;
						}
						else if (flag)
						{
							hdshadowRequest.cachedShadowData.cacheTranslationDelta = worldSpaceCameraPos - this.m_CachedViewPositions[i];
							hdshadowRequest.shouldUseCachedShadowData = true;
							hdshadowRequest.shouldRenderCachedComponent = false;
							if (type == HDLightType.Directional)
							{
								Matrix4x4 view = hdshadowRequest.view;
								Matrix4x4 deviceProjectionYFlip = hdshadowRequest.deviceProjectionYFlip;
								float slopeBias = hdshadowRequest.slopeBias;
								this.UpdateDirectionalShadowRequest(manager, shadowSettings, visibleLight, cullResults, resolution, i, lightIndex, worldSpaceCameraPos, hdshadowRequest, out identity);
								hdshadowRequest.view = view;
								hdshadowRequest.deviceProjectionYFlip = deviceProjectionYFlip;
							}
						}
						if ((type != HDLightType.Directional || !flag) && flag6 && !flag7)
						{
							hdshadowRequest.shouldUseCachedShadowData = false;
							hdshadowRequest.cachedShadowData.cacheTranslationDelta = new Vector3(0f, 0f, 0f);
							this.UpdateShadowRequestData(hdCamera, manager, shadowSettings, visibleLight, cullResults, lightIndex, lightingDebugSettings, filteringQuality, areaFilteringQuality, resolution, type, i, ref hdshadowRequest);
						}
						manager.UpdateShadowRequest(num2, hdshadowRequest, shadowUpdateType);
						if (flag5 && (type != HDLightType.Directional || hdCamera.camera.cameraType != CameraType.Reflection))
						{
							HDShadowManager.cachedShadowManager.MarkShadowAsRendered(shadowIdx, this.shadowMapType);
						}
						if (num == -1)
						{
							num = num2;
						}
						shadowRequestCount++;
					}
				}
			}
			if (!flag4)
			{
				return -1;
			}
			return num;
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x00042170 File Offset: 0x00040370
		private void SetCommonShadowRequestSettings(HDShadowRequest shadowRequest, VisibleLight visibleLight, float forwardOffset, Vector3 cameraPos, Matrix4x4 invViewProjection, Vector2 viewportSize, int lightIndex, HDLightType lightType, HDShadowFilteringQuality filteringQuality, HDAreaShadowFilteringQuality areaFilteringQuality)
		{
			float range = this.legacyLight.range;
			float num = (lightType == HDLightType.Area || (lightType == HDLightType.Spot && this.spotLightShape == SpotLightShape.Box)) ? this.shadowNearPlane : Mathf.Max(this.shadowNearPlane, HDShadowUtils.k_MinShadowNearPlane);
			shadowRequest.zBufferParam = new Vector4((range - num) / num, 1f, (range - num) / (num * range), 1f / range);
			shadowRequest.worldTexelSize = 2f / shadowRequest.deviceProjectionYFlip.m00 / viewportSize.x * Mathf.Sqrt(2f);
			shadowRequest.normalBias = this.normalBias;
			if (ShaderConfig.s_CameraRelativeRendering != 0)
			{
				CoreMatrixUtils.MatrixTimesTranslation(ref shadowRequest.view, cameraPos);
				CoreMatrixUtils.TranslationTimesMatrix(ref invViewProjection, -cameraPos);
			}
			bool orthoCentered = false;
			if (lightType == HDLightType.Directional || (lightType == HDLightType.Spot && this.spotLightShape == SpotLightShape.Box))
			{
				orthoCentered = true;
				shadowRequest.position = new Vector3(shadowRequest.view.m03, shadowRequest.view.m13, shadowRequest.view.m23);
			}
			else
			{
				VisibleLightExtensionMethods.VisibleLightAxisAndPosition axisAndPosition = visibleLight.GetAxisAndPosition();
				shadowRequest.position = axisAndPosition.Position + axisAndPosition.Forward * forwardOffset;
				if (ShaderConfig.s_CameraRelativeRendering != 0)
				{
					shadowRequest.position -= cameraPos;
				}
			}
			shadowRequest.shadowToWorld = invViewProjection.transpose;
			shadowRequest.zClip = (lightType != HDLightType.Directional);
			shadowRequest.lightIndex = lightIndex;
			if (lightType == HDLightType.Directional)
			{
				shadowRequest.shadowMapType = ShadowMapType.CascadedDirectional;
			}
			else if (lightType == HDLightType.Area && this.areaLightShape == AreaLightShape.Rectangle)
			{
				shadowRequest.shadowMapType = ShadowMapType.AreaLightAtlas;
			}
			else
			{
				shadowRequest.shadowMapType = ShadowMapType.PunctualAtlas;
			}
			GeometryUtility.CalculateFrustumPlanes(CoreMatrixUtils.MultiplyProjectionMatrix(shadowRequest.projection, shadowRequest.view, orthoCentered), this.m_ShadowFrustumPlanes);
			Vector4[] frustumPlanes = shadowRequest.frustumPlanes;
			if (frustumPlanes == null || frustumPlanes.Length != 6)
			{
				shadowRequest.frustumPlanes = new Vector4[6];
			}
			for (int i = 0; i < 6; i++)
			{
				shadowRequest.frustumPlanes[i] = new Vector4(this.m_ShadowFrustumPlanes[i].normal.x, this.m_ShadowFrustumPlanes[i].normal.y, this.m_ShadowFrustumPlanes[i].normal.z, this.m_ShadowFrustumPlanes[i].distance);
			}
			float num3;
			if (lightType == HDLightType.Directional)
			{
				Matrix4x4 deviceProjection = shadowRequest.deviceProjection;
				float num2 = Vector4.Dot(new Vector4(deviceProjection.m32, -deviceProjection.m32, -deviceProjection.m22, deviceProjection.m22), new Vector4(deviceProjection.m22, deviceProjection.m32, deviceProjection.m23, deviceProjection.m33)) / (deviceProjection.m22 * (deviceProjection.m22 - deviceProjection.m32));
				num3 = Mathf.Abs(Mathf.Tan(0.008726646f * (this.softnessScale * this.m_AngularDiameter) / 2f) * num2 / (2f * shadowRequest.splitData.cullingSphere.w));
				float x = Mathf.Abs(2f * (1f / deviceProjection.m22)) / 100f;
				shadowRequest.zBufferParam.x = x;
			}
			else
			{
				float num4 = this.m_ShapeRadius * this.softnessScale;
				float num5 = num4 * num4;
				num3 = 0.02403461f + 3.452916f * num4 - 1.362672f * num5 + 0.6700115f * num5 * num4 + 0.2159474f * num5 * num5;
				num3 /= 100f;
			}
			float num6 = shadowRequest.isInCachedAtlas ? shadowRequest.cachedAtlasViewport.width : shadowRequest.dynamicAtlasViewport.width;
			num3 *= num6 / 512f;
			float num7 = 5f;
			if (((lightType != HDLightType.Area && filteringQuality == HDShadowFilteringQuality.High) || (lightType == HDLightType.Area && areaFilteringQuality == HDAreaShadowFilteringQuality.High)) && num3 > 0.01f)
			{
				float b = 18f;
				num7 = Mathf.Lerp(num7, b, Mathf.Min(1f, num3 * 100f / 5f));
			}
			shadowRequest.slopeBias = HDShadowUtils.GetSlopeBias(num7, this.slopeBias);
			shadowRequest.shadowSoftness = num3;
			shadowRequest.blockerSampleCount = this.blockerSampleCount;
			shadowRequest.filterSampleCount = this.filterSampleCount;
			shadowRequest.minFilterSize = this.minFilterSize * 0.001f;
			shadowRequest.kernelSize = this.kernelSize;
			shadowRequest.lightAngle = this.lightAngle * 3.1415927f / 180f;
			shadowRequest.maxDepthBias = this.maxDepthBias;
			shadowRequest.evsmParams.x = this.evsmExponent * 1.442695f;
			shadowRequest.evsmParams.y = this.evsmLightLeakBias;
			shadowRequest.evsmParams.z = this.m_EvsmVarianceBias;
			shadowRequest.evsmParams.w = (float)this.evsmBlurPasses;
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x0600065A RID: 1626 RVA: 0x00042629 File Offset: 0x00040829
		// (set) Token: 0x0600065B RID: 1627 RVA: 0x00042636 File Offset: 0x00040836
		internal bool useColorTemperature
		{
			get
			{
				return this.legacyLight.useColorTemperature;
			}
			set
			{
				if (this.legacyLight.useColorTemperature == value)
				{
					return;
				}
				this.legacyLight.useColorTemperature = value;
			}
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x00042653 File Offset: 0x00040853
		private void Start()
		{
			this.m_Animated = (base.GetComponent<Animator>() != null);
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x00042668 File Offset: 0x00040868
		private void LateUpdate()
		{
			if (HDRenderPipeline.currentPipeline == null)
			{
				return;
			}
			if (!this.m_Animated)
			{
				return;
			}
			if (this.areaLightEmissiveMeshLayer == -1 && this.m_ChildEmissiveMeshViewer != null && !this.m_ChildEmissiveMeshViewer.Equals(null) && this.m_ChildEmissiveMeshViewer.gameObject.layer != base.gameObject.layer)
			{
				this.m_ChildEmissiveMeshViewer.gameObject.layer = base.gameObject.layer;
			}
			if (this.needRefreshEmissiveMeshesFromTimeLineUpdate)
			{
				this.needRefreshEmissiveMeshesFromTimeLineUpdate = false;
				this.UpdateAreaLightEmissiveMesh(false);
			}
			new Vector3(this.shapeWidth, this.m_ShapeHeight, this.shapeRadius);
			if (this.legacyLight.enabled != this.timelineWorkaround.lightEnabled)
			{
				this.SetEmissiveMeshRendererEnabled(this.legacyLight.enabled);
				this.timelineWorkaround.lightEnabled = this.legacyLight.enabled;
			}
			if (this.timelineWorkaround.oldLossyScale != base.transform.lossyScale || this.intensity != this.timelineWorkaround.oldIntensity || this.legacyLight.colorTemperature != this.timelineWorkaround.oldLightColorTemperature)
			{
				this.UpdateLightIntensity();
				this.UpdateAreaLightEmissiveMesh(false);
				this.timelineWorkaround.oldLossyScale = base.transform.lossyScale;
				this.timelineWorkaround.oldIntensity = this.intensity;
				this.timelineWorkaround.oldLightColorTemperature = this.legacyLight.colorTemperature;
			}
			if (this.type == HDLightType.Spot && this.timelineWorkaround.oldSpotAngle != this.legacyLight.spotAngle)
			{
				this.UpdateLightIntensity();
				this.timelineWorkaround.oldSpotAngle = this.legacyLight.spotAngle;
			}
			if (this.legacyLight.color != this.timelineWorkaround.oldLightColor || this.timelineWorkaround.oldLossyScale != base.transform.lossyScale || this.displayAreaLightEmissiveMesh != this.timelineWorkaround.oldDisplayAreaLightEmissiveMesh || this.legacyLight.colorTemperature != this.timelineWorkaround.oldLightColorTemperature)
			{
				this.UpdateAreaLightEmissiveMesh(false);
				this.timelineWorkaround.oldLightColor = this.legacyLight.color;
				this.timelineWorkaround.oldLossyScale = base.transform.lossyScale;
				this.timelineWorkaround.oldDisplayAreaLightEmissiveMesh = this.displayAreaLightEmissiveMesh;
				this.timelineWorkaround.oldLightColorTemperature = this.legacyLight.colorTemperature;
			}
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x000428DD File Offset: 0x00040ADD
		private void OnDidApplyAnimationProperties()
		{
			this.UpdateAllLightValues(true);
			this.UpdateRenderEntity();
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x000428EC File Offset: 0x00040AEC
		public void CopyTo(HDAdditionalLightData data)
		{
			data.m_Intensity = this.m_Intensity;
			data.m_EnableSpotReflector = this.m_EnableSpotReflector;
			data.m_LuxAtDistance = this.m_LuxAtDistance;
			data.m_InnerSpotPercent = this.m_InnerSpotPercent;
			data.m_SpotIESCutoffPercent = this.m_SpotIESCutoffPercent;
			data.m_LightDimmer = this.m_LightDimmer;
			data.m_VolumetricDimmer = this.m_VolumetricDimmer;
			data.m_LightUnit = this.m_LightUnit;
			data.m_FadeDistance = this.m_FadeDistance;
			data.m_VolumetricFadeDistance = this.m_VolumetricFadeDistance;
			data.m_AffectDiffuse = this.m_AffectDiffuse;
			data.m_AffectSpecular = this.m_AffectSpecular;
			data.m_NonLightmappedOnly = this.m_NonLightmappedOnly;
			data.m_PointlightHDType = this.m_PointlightHDType;
			data.m_SpotLightShape = this.m_SpotLightShape;
			data.m_AreaLightShape = this.m_AreaLightShape;
			data.m_ShapeWidth = this.m_ShapeWidth;
			data.m_ShapeHeight = this.m_ShapeHeight;
			data.m_AspectRatio = this.m_AspectRatio;
			data.m_ShapeRadius = this.m_ShapeRadius;
			data.m_SoftnessScale = this.m_SoftnessScale;
			data.m_UseCustomSpotLightShadowCone = this.m_UseCustomSpotLightShadowCone;
			data.m_CustomSpotLightShadowCone = this.m_CustomSpotLightShadowCone;
			data.m_MaxSmoothness = this.m_MaxSmoothness;
			data.m_ApplyRangeAttenuation = this.m_ApplyRangeAttenuation;
			data.m_DisplayAreaLightEmissiveMesh = this.m_DisplayAreaLightEmissiveMesh;
			data.m_AreaLightCookie = this.m_AreaLightCookie;
			data.m_IESPoint = this.m_IESPoint;
			data.m_IESSpot = this.m_IESSpot;
			data.m_IncludeForRayTracing = this.m_IncludeForRayTracing;
			data.m_AreaLightShadowCone = this.m_AreaLightShadowCone;
			data.m_UseScreenSpaceShadows = this.m_UseScreenSpaceShadows;
			data.m_InteractsWithSky = this.m_InteractsWithSky;
			data.m_AngularDiameter = this.m_AngularDiameter;
			data.m_FlareSize = this.m_FlareSize;
			data.m_FlareTint = this.m_FlareTint;
			data.m_FlareFalloff = this.m_FlareFalloff;
			data.m_SurfaceTexture = this.m_SurfaceTexture;
			data.m_SurfaceTint = this.m_SurfaceTint;
			data.m_Distance = this.m_Distance;
			data.m_UseRayTracedShadows = this.m_UseRayTracedShadows;
			data.m_NumRayTracingSamples = this.m_NumRayTracingSamples;
			data.m_FilterTracedShadow = this.m_FilterTracedShadow;
			data.m_FilterSizeTraced = this.m_FilterSizeTraced;
			data.m_SunLightConeAngle = this.m_SunLightConeAngle;
			data.m_LightShadowRadius = this.m_LightShadowRadius;
			data.m_SemiTransparentShadow = this.m_SemiTransparentShadow;
			data.m_ColorShadow = this.m_ColorShadow;
			data.m_DistanceBasedFiltering = this.m_DistanceBasedFiltering;
			data.m_EvsmExponent = this.m_EvsmExponent;
			data.m_EvsmLightLeakBias = this.m_EvsmLightLeakBias;
			data.m_EvsmVarianceBias = this.m_EvsmVarianceBias;
			data.m_EvsmBlurPasses = this.m_EvsmBlurPasses;
			data.m_LightlayersMask = this.m_LightlayersMask;
			data.m_LinkShadowLayers = this.m_LinkShadowLayers;
			data.m_ShadowNearPlane = this.m_ShadowNearPlane;
			data.m_BlockerSampleCount = this.m_BlockerSampleCount;
			data.m_FilterSampleCount = this.m_FilterSampleCount;
			data.m_MinFilterSize = this.m_MinFilterSize;
			data.m_KernelSize = this.m_KernelSize;
			data.m_LightAngle = this.m_LightAngle;
			data.m_MaxDepthBias = this.m_MaxDepthBias;
			this.m_ShadowResolution.CopyTo(data.m_ShadowResolution);
			data.m_ShadowDimmer = this.m_ShadowDimmer;
			data.m_VolumetricShadowDimmer = this.m_VolumetricShadowDimmer;
			data.m_ShadowFadeDistance = this.m_ShadowFadeDistance;
			this.m_UseContactShadow.CopyTo(data.m_UseContactShadow);
			data.m_RayTracedContactShadow = this.m_RayTracedContactShadow;
			data.m_ShadowTint = this.m_ShadowTint;
			data.m_PenumbraTint = this.m_PenumbraTint;
			data.m_NormalBias = this.m_NormalBias;
			data.m_SlopeBias = this.m_SlopeBias;
			data.m_ShadowUpdateMode = this.m_ShadowUpdateMode;
			data.m_AlwaysDrawDynamicShadows = this.m_AlwaysDrawDynamicShadows;
			data.m_UpdateShadowOnLightMovement = this.m_UpdateShadowOnLightMovement;
			data.m_CachedShadowTranslationThreshold = this.m_CachedShadowTranslationThreshold;
			data.m_CachedShadowAngularThreshold = this.m_CachedShadowAngularThreshold;
			data.m_BarnDoorLength = this.m_BarnDoorLength;
			data.m_BarnDoorAngle = this.m_BarnDoorAngle;
			data.m_preserveCachedShadow = this.m_preserveCachedShadow;
			data.m_OnDemandShadowRenderOnPlacement = this.m_OnDemandShadowRenderOnPlacement;
			data.forceRenderOnPlacement = this.forceRenderOnPlacement;
			data.m_ShadowCascadeRatios = new float[this.m_ShadowCascadeRatios.Length];
			this.m_ShadowCascadeRatios.CopyTo(data.m_ShadowCascadeRatios, 0);
			data.m_ShadowCascadeBorders = new float[this.m_ShadowCascadeBorders.Length];
			this.m_ShadowCascadeBorders.CopyTo(data.m_ShadowCascadeBorders, 0);
			data.m_ShadowAlgorithm = this.m_ShadowAlgorithm;
			data.m_ShadowVariant = this.m_ShadowVariant;
			data.m_ShadowPrecision = this.m_ShadowPrecision;
			data.useOldInspector = this.useOldInspector;
			data.useVolumetric = this.useVolumetric;
			data.featuresFoldout = this.featuresFoldout;
			data.m_AreaLightEmissiveMeshShadowCastingMode = this.m_AreaLightEmissiveMeshShadowCastingMode;
			data.m_AreaLightEmissiveMeshMotionVectorGenerationMode = this.m_AreaLightEmissiveMeshMotionVectorGenerationMode;
			data.m_AreaLightEmissiveMeshLayer = this.m_AreaLightEmissiveMeshLayer;
			data.UpdateAllLightValues();
			data.UpdateRenderEntity();
		}

		// Token: 0x06000660 RID: 1632 RVA: 0x00042DA0 File Offset: 0x00040FA0
		public static void InitDefaultHDAdditionalLightData(HDAdditionalLightData lightData)
		{
			Light component = lightData.gameObject.GetComponent<Light>();
			switch (lightData.type)
			{
			case HDLightType.Spot:
			case HDLightType.Point:
				lightData.lightUnit = LightUnit.Lumen;
				lightData.intensity = 600f;
				break;
			case HDLightType.Directional:
				lightData.lightUnit = LightUnit.Lux;
				lightData.intensity = 100000f;
				break;
			case HDLightType.Area:
			{
				AreaLightShape areaLightShape = lightData.areaLightShape;
				if (areaLightShape != AreaLightShape.Rectangle)
				{
					if (areaLightShape != AreaLightShape.Disc)
					{
					}
				}
				else
				{
					lightData.lightUnit = LightUnit.Lumen;
					lightData.intensity = 200f;
					lightData.shadowNearPlane = 0f;
					component.shadows = LightShadows.None;
				}
				break;
			}
			}
			component.lightShadowCasterMode = LightShadowCasterMode.Everything;
			lightData.normalBias = 0.75f;
			lightData.slopeBias = 0.5f;
			lightData.useColorTemperature = true;
		}

		// Token: 0x06000661 RID: 1633 RVA: 0x00042E58 File Offset: 0x00041058
		private void OnValidate()
		{
			this.UpdateBounds();
			this.RefreshCachedShadow();
			this.shapeWidth = Mathf.Max(this.shapeWidth, 0.01f);
			this.shapeHeight = Mathf.Max(this.shapeHeight, 0.01f);
			this.shapeRadius = Mathf.Max(this.shapeRadius, 0f);
		}

		// Token: 0x06000662 RID: 1634 RVA: 0x00042EB4 File Offset: 0x000410B4
		private void SetLightIntensityPunctual(float intensity)
		{
			switch (this.type)
			{
			case HDLightType.Spot:
				if (this.lightUnit == LightUnit.Candela)
				{
					this.legacyLight.intensity = intensity;
					return;
				}
				if (!this.enableSpotReflector)
				{
					this.legacyLight.intensity = LightUtils.ConvertPointLightLumenToCandela(intensity);
					return;
				}
				if (this.spotLightShape == SpotLightShape.Cone)
				{
					this.legacyLight.intensity = LightUtils.ConvertSpotLightLumenToCandela(intensity, this.legacyLight.spotAngle * 0.017453292f, true);
					return;
				}
				if (this.spotLightShape == SpotLightShape.Pyramid)
				{
					float angleA;
					float angleB;
					LightUtils.CalculateAnglesForPyramid(this.aspectRatio, this.legacyLight.spotAngle * 0.017453292f, out angleA, out angleB);
					this.legacyLight.intensity = LightUtils.ConvertFrustrumLightLumenToCandela(intensity, angleA, angleB);
					return;
				}
				this.legacyLight.intensity = LightUtils.ConvertPointLightLumenToCandela(intensity);
				return;
			case HDLightType.Directional:
				this.legacyLight.intensity = intensity;
				return;
			case HDLightType.Point:
				if (this.lightUnit == LightUnit.Candela)
				{
					this.legacyLight.intensity = intensity;
					return;
				}
				this.legacyLight.intensity = LightUtils.ConvertPointLightLumenToCandela(intensity);
				return;
			default:
				return;
			}
		}

		// Token: 0x06000663 RID: 1635 RVA: 0x00042FBC File Offset: 0x000411BC
		private void UpdateLightIntensity()
		{
			if (this.lightUnit == LightUnit.Lumen)
			{
				if (this.m_PointlightHDType == HDAdditionalLightData.PointLightHDType.Punctual)
				{
					this.SetLightIntensityPunctual(this.intensity);
					return;
				}
				this.legacyLight.intensity = LightUtils.ConvertAreaLightLumenToLuminance(this.areaLightShape, this.intensity, this.shapeWidth, this.m_ShapeHeight);
				return;
			}
			else
			{
				if (this.lightUnit == LightUnit.Ev100)
				{
					this.legacyLight.intensity = LightUtils.ConvertEvToLuminance(this.m_Intensity);
					return;
				}
				HDLightType type = this.type;
				if ((type != HDLightType.Spot && type != HDLightType.Point) || this.lightUnit != LightUnit.Lux)
				{
					this.legacyLight.intensity = this.m_Intensity;
					return;
				}
				if (type == HDLightType.Spot && this.spotLightShape == SpotLightShape.Box)
				{
					this.legacyLight.intensity = this.m_Intensity;
					return;
				}
				this.legacyLight.intensity = LightUtils.ConvertLuxToCandela(this.m_Intensity, this.luxAtDistance);
				return;
			}
		}

		// Token: 0x06000664 RID: 1636 RVA: 0x00043092 File Offset: 0x00041292
		private void Awake()
		{
			this.Migrate();
			this.UpdateAreaLightEmissiveMesh(false);
		}

		// Token: 0x06000665 RID: 1637 RVA: 0x000430A4 File Offset: 0x000412A4
		internal void UpdateAreaLightEmissiveMesh(bool fromTimeLine = false)
		{
			bool flag = this.type == HDLightType.Area;
			bool flag2 = flag && this.displayAreaLightEmissiveMesh;
			if (!flag || !flag2)
			{
				if (this.m_ChildEmissiveMeshViewer)
				{
					if (fromTimeLine)
					{
						this.emissiveMeshRenderer.enabled = false;
						this.needRefreshEmissiveMeshesFromTimeLineUpdate = true;
						return;
					}
					this.DestroyChildEmissiveMeshViewer();
				}
				return;
			}
			this.CreateChildEmissiveMeshViewerIfNeeded();
			AreaLightShape areaLightShape;
			if (HDRenderPipelineGlobalSettings.instance != null && !HDRenderPipelineGlobalSettings.instance.Equals(null))
			{
				areaLightShape = this.areaLightShape;
				if (areaLightShape != AreaLightShape.Rectangle && areaLightShape == AreaLightShape.Tube)
				{
					if (this.m_EmissiveMeshFilter.sharedMesh != HDRenderPipelineGlobalSettings.instance.renderPipelineResources.assets.emissiveCylinderMesh)
					{
						this.m_EmissiveMeshFilter.sharedMesh = HDRenderPipelineGlobalSettings.instance.renderPipelineResources.assets.emissiveCylinderMesh;
					}
				}
				else if (this.m_EmissiveMeshFilter.sharedMesh != HDRenderPipelineGlobalSettings.instance.renderPipelineResources.assets.emissiveQuadMesh)
				{
					this.m_EmissiveMeshFilter.sharedMesh = HDRenderPipelineGlobalSettings.instance.renderPipelineResources.assets.emissiveQuadMesh;
				}
			}
			Vector3 vector = new Vector3(this.m_ShapeWidth, this.m_ShapeHeight, 0f);
			if (this.areaLightShape == AreaLightShape.Tube)
			{
				vector.y = 0f;
			}
			vector = Vector3.Max(Vector3.one * 0.01f, vector);
			areaLightShape = this.areaLightShape;
			if (areaLightShape != AreaLightShape.Rectangle)
			{
				if (areaLightShape == AreaLightShape.Tube)
				{
					this.m_ShapeWidth = vector.x;
				}
			}
			else
			{
				this.m_ShapeWidth = vector.x;
				this.m_ShapeHeight = vector.y;
			}
			if (this.lightEntity.valid)
			{
				ref HDLightRenderData ptr = ref HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity);
				ptr.shapeWidth = this.m_ShapeWidth;
				ptr.shapeHeight = this.m_ShapeHeight;
			}
			Vector3 vector2 = this.emissiveMeshRenderer.transform.localRotation * base.transform.lossyScale;
			this.emissiveMeshRenderer.transform.localScale = new Vector3(vector.x / vector2.x, vector.y / vector2.y, 0.01f / vector2.z);
			if (this.emissiveMeshRenderer.sharedMaterial == null || this.emissiveMeshRenderer.sharedMaterial.name != base.gameObject.name)
			{
				this.emissiveMeshRenderer.sharedMaterial = new Material(Shader.Find("HDRP/Unlit"));
				this.emissiveMeshRenderer.sharedMaterial.SetFloat("_IncludeIndirectLighting", 0f);
				this.emissiveMeshRenderer.sharedMaterial.name = base.gameObject.name;
			}
			this.emissiveMeshRenderer.sharedMaterial.SetColor("_UnlitColor", Color.black);
			Color color = this.legacyLight.color.linear * this.legacyLight.intensity;
			color *= this.lightDimmer;
			this.emissiveMeshRenderer.sharedMaterial.SetColor("_EmissiveColor", color);
			bool state = false;
			if (flag2 && this.areaLightCookie != null && this.areaLightCookie != Texture2D.whiteTexture)
			{
				this.emissiveMeshRenderer.sharedMaterial.SetTexture("_EmissiveColorMap", this.areaLightCookie);
				state = true;
			}
			else if (flag2 && this.IESSpot != null && this.IESSpot != Texture2D.whiteTexture)
			{
				this.emissiveMeshRenderer.sharedMaterial.SetTexture("_EmissiveColorMap", this.IESSpot);
				state = true;
			}
			else
			{
				this.emissiveMeshRenderer.sharedMaterial.SetTexture("_EmissiveColorMap", Texture2D.whiteTexture);
			}
			CoreUtils.SetKeyword(this.emissiveMeshRenderer.sharedMaterial, "_EMISSIVE_COLOR_MAP", state);
			if (this.m_AreaLightEmissiveMeshLayer != -1)
			{
				this.emissiveMeshRenderer.gameObject.layer = this.m_AreaLightEmissiveMeshLayer;
			}
		}

		// Token: 0x06000666 RID: 1638 RVA: 0x00043488 File Offset: 0x00041688
		private void UpdateRectangleLightBounds()
		{
			this.legacyLight.useShadowMatrixOverride = false;
			this.legacyLight.useBoundingSphereOverride = true;
			float num = this.m_ShapeWidth * 0.5f;
			float num2 = this.m_ShapeHeight * 0.5f;
			float b = Mathf.Sqrt(num * num + num2 * num2);
			this.legacyLight.boundingSphereOverride = new Vector4(0f, 0f, 0f, Mathf.Max(this.range, b));
		}

		// Token: 0x06000667 RID: 1639 RVA: 0x00043500 File Offset: 0x00041700
		private void UpdateTubeLightBounds()
		{
			this.legacyLight.useShadowMatrixOverride = false;
			this.legacyLight.useBoundingSphereOverride = true;
			this.legacyLight.boundingSphereOverride = new Vector4(0f, 0f, 0f, Mathf.Max(this.range, this.m_ShapeWidth * 0.5f));
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x0004355C File Offset: 0x0004175C
		private void UpdateBoxLightBounds()
		{
			this.legacyLight.useShadowMatrixOverride = true;
			this.legacyLight.useBoundingSphereOverride = true;
			Matrix4x4 rhs = Matrix4x4.Scale(new Vector3(1f, 1f, -1f));
			this.legacyLight.shadowMatrixOverride = HDShadowUtils.ExtractBoxLightProjectionMatrix(this.legacyLight.range, this.shapeWidth, this.m_ShapeHeight, this.shadowNearPlane) * rhs;
			float magnitude = new Vector3(this.shapeWidth * 0.5f, this.m_ShapeHeight * 0.5f, this.legacyLight.range * 0.5f).magnitude;
			this.legacyLight.boundingSphereOverride = new Vector4(0f, 0f, this.legacyLight.range * 0.5f, magnitude);
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x00043634 File Offset: 0x00041834
		private void UpdatePyramidLightBounds()
		{
			this.legacyLight.useShadowMatrixOverride = true;
			this.legacyLight.useBoundingSphereOverride = true;
			Matrix4x4 rhs = Matrix4x4.Scale(new Vector3(1f, 1f, -1f));
			this.legacyLight.shadowMatrixOverride = HDShadowUtils.ExtractSpotLightProjectionMatrix(this.legacyLight.range, this.legacyLight.spotAngle, this.shadowNearPlane, this.aspectRatio, 0f) * rhs;
			this.legacyLight.boundingSphereOverride = new Vector4(0f, 0f, 0f, this.legacyLight.range);
		}

		// Token: 0x0600066A RID: 1642 RVA: 0x000436DC File Offset: 0x000418DC
		private void UpdateBounds()
		{
			HDLightType type = this.type;
			if (type != HDLightType.Spot)
			{
				if (type != HDLightType.Area)
				{
					this.legacyLight.useBoundingSphereOverride = false;
					this.legacyLight.useShadowMatrixOverride = false;
					return;
				}
				AreaLightShape areaLightShape = this.areaLightShape;
				if (areaLightShape == AreaLightShape.Rectangle)
				{
					this.UpdateRectangleLightBounds();
					return;
				}
				if (areaLightShape != AreaLightShape.Tube)
				{
					return;
				}
				this.UpdateTubeLightBounds();
				return;
			}
			else
			{
				SpotLightShape spotLightShape = this.spotLightShape;
				if (spotLightShape == SpotLightShape.Pyramid)
				{
					this.UpdatePyramidLightBounds();
					return;
				}
				if (spotLightShape == SpotLightShape.Box)
				{
					this.UpdateBoxLightBounds();
					return;
				}
				this.legacyLight.useBoundingSphereOverride = false;
				this.legacyLight.useShadowMatrixOverride = false;
				return;
			}
		}

		// Token: 0x0600066B RID: 1643 RVA: 0x00043764 File Offset: 0x00041964
		private void UpdateShapeSize()
		{
			this.shapeWidth = this.m_ShapeWidth;
			this.shapeHeight = this.m_ShapeHeight;
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x0004377E File Offset: 0x0004197E
		public void UpdateAllLightValues()
		{
			this.UpdateAllLightValues(false);
		}

		// Token: 0x0600066D RID: 1645 RVA: 0x00043787 File Offset: 0x00041987
		internal void UpdateAllLightValues(bool fromTimeLine)
		{
			this.UpdateShapeSize();
			this.UpdateLightIntensity();
			this.UpdateBounds();
			this.UpdateAreaLightEmissiveMesh(fromTimeLine);
		}

		// Token: 0x0600066E RID: 1646 RVA: 0x000437A4 File Offset: 0x000419A4
		internal void RefreshCachedShadow()
		{
			if (this.lightIdxForCachedShadows >= 0)
			{
				HDShadowManager.cachedShadowManager.EvictLight(this);
			}
			if (!this.ShadowIsUpdatedEveryFrame() && this.legacyLight.shadows != LightShadows.None && (this.shadowUpdateMode != ShadowUpdateMode.OnDemand || this.onDemandShadowRenderOnPlacement))
			{
				HDShadowManager.cachedShadowManager.RegisterLight(this);
			}
		}

		// Token: 0x0600066F RID: 1647 RVA: 0x000437FB File Offset: 0x000419FB
		public void SetColor(Color color, float colorTemperature = -1f)
		{
			if (colorTemperature != -1f)
			{
				this.legacyLight.colorTemperature = colorTemperature;
				this.useColorTemperature = true;
			}
			this.color = color;
		}

		// Token: 0x06000670 RID: 1648 RVA: 0x0004381F File Offset: 0x00041A1F
		public void EnableColorTemperature(bool enable)
		{
			this.useColorTemperature = enable;
		}

		// Token: 0x06000671 RID: 1649 RVA: 0x00043828 File Offset: 0x00041A28
		public void SetIntensity(float intensity)
		{
			this.intensity = intensity;
		}

		// Token: 0x06000672 RID: 1650 RVA: 0x00043831 File Offset: 0x00041A31
		public void SetIntensity(float intensity, LightUnit unit)
		{
			this.lightUnit = unit;
			this.intensity = intensity;
		}

		// Token: 0x06000673 RID: 1651 RVA: 0x00043841 File Offset: 0x00041A41
		public void SetSpotLightLuxAt(float luxIntensity, float distance)
		{
			this.lightUnit = LightUnit.Lux;
			this.luxAtDistance = distance;
			this.intensity = luxIntensity;
		}

		// Token: 0x06000674 RID: 1652 RVA: 0x00043858 File Offset: 0x00041A58
		public void SetCookie(Texture cookie, Vector2 directionalLightCookieSize)
		{
			HDLightType type = this.type;
			if (type == HDLightType.Area)
			{
				if (cookie.dimension != TextureDimension.Tex2D)
				{
					Debug.LogError("Texture dimension " + cookie.dimension.ToString() + " is not supported for area lights.");
					return;
				}
				this.areaLightCookie = cookie;
				return;
			}
			else
			{
				if (type == HDLightType.Point && cookie.dimension != TextureDimension.Cube)
				{
					Debug.LogError("Texture dimension " + cookie.dimension.ToString() + " is not supported for point lights.");
					return;
				}
				if ((type == HDLightType.Directional || type == HDLightType.Spot) && cookie.dimension != TextureDimension.Tex2D)
				{
					Debug.LogError("Texture dimension " + cookie.dimension.ToString() + " is not supported for Directional/Spot lights.");
					return;
				}
				if (type == HDLightType.Directional)
				{
					this.shapeWidth = directionalLightCookieSize.x;
					this.shapeHeight = directionalLightCookieSize.y;
				}
				this.legacyLight.cookie = cookie;
				return;
			}
		}

		// Token: 0x06000675 RID: 1653 RVA: 0x00043941 File Offset: 0x00041B41
		public void SetCookie(Texture cookie)
		{
			this.SetCookie(cookie, Vector2.zero);
		}

		// Token: 0x06000676 RID: 1654 RVA: 0x0004394F File Offset: 0x00041B4F
		public void SetSpotAngle(float angle, float innerSpotPercent = 0f)
		{
			this.legacyLight.spotAngle = angle;
			this.innerSpotPercent = innerSpotPercent;
		}

		// Token: 0x06000677 RID: 1655 RVA: 0x00043964 File Offset: 0x00041B64
		public void SetLightDimmer(float dimmer = 1f, float volumetricDimmer = 1f)
		{
			this.lightDimmer = dimmer;
			this.volumetricDimmer = volumetricDimmer;
		}

		// Token: 0x06000678 RID: 1656 RVA: 0x00043974 File Offset: 0x00041B74
		public void SetLightUnit(LightUnit unit)
		{
			this.lightUnit = unit;
		}

		// Token: 0x06000679 RID: 1657 RVA: 0x0004397D File Offset: 0x00041B7D
		public void EnableShadows(bool enabled)
		{
			this.legacyLight.shadows = (enabled ? LightShadows.Soft : LightShadows.None);
		}

		// Token: 0x0600067A RID: 1658 RVA: 0x00043991 File Offset: 0x00041B91
		internal bool ShadowsEnabled()
		{
			return this.legacyLight.shadows > LightShadows.None;
		}

		// Token: 0x0600067B RID: 1659 RVA: 0x000439A1 File Offset: 0x00041BA1
		public void SetShadowResolution(int resolution)
		{
			if (this.shadowResolution.@override != resolution)
			{
				this.shadowResolution.@override = resolution;
				this.RefreshCachedShadow();
			}
		}

		// Token: 0x0600067C RID: 1660 RVA: 0x000439C3 File Offset: 0x00041BC3
		public void SetShadowResolutionLevel(int level)
		{
			if (this.shadowResolution.level != level)
			{
				this.shadowResolution.level = level;
				this.RefreshCachedShadow();
			}
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x000439E5 File Offset: 0x00041BE5
		public void SetShadowResolutionOverride(bool useOverride)
		{
			if (this.shadowResolution.useOverride != useOverride)
			{
				this.shadowResolution.useOverride = useOverride;
				this.RefreshCachedShadow();
			}
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x00043A07 File Offset: 0x00041C07
		public void SetShadowNearPlane(float nearPlaneDistance)
		{
			this.shadowNearPlane = nearPlaneDistance;
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x00043A10 File Offset: 0x00041C10
		public void SetPCSSParams(int blockerSampleCount = 16, int filterSampleCount = 24, float minFilterSize = 0.01f, float radiusScaleForSoftness = 1f)
		{
			this.blockerSampleCount = blockerSampleCount;
			this.filterSampleCount = filterSampleCount;
			this.minFilterSize = minFilterSize;
			this.softnessScale = radiusScaleForSoftness;
		}

		// Token: 0x06000680 RID: 1664 RVA: 0x00043A2F File Offset: 0x00041C2F
		public void SetLightLayer(LightLayerEnum lightLayerMask, LightLayerEnum shadowLayerMask)
		{
			this.linkShadowLayers = false;
			this.legacyLight.renderingLayerMask = HDAdditionalLightData.LightLayerToRenderingLayerMask((int)shadowLayerMask, this.legacyLight.renderingLayerMask);
			this.lightlayersMask = lightLayerMask;
		}

		// Token: 0x06000681 RID: 1665 RVA: 0x00043A5B File Offset: 0x00041C5B
		public void SetShadowDimmer(float shadowDimmer = 1f, float volumetricShadowDimmer = 1f)
		{
			this.shadowDimmer = shadowDimmer;
			this.volumetricShadowDimmer = volumetricShadowDimmer;
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x00043A6B File Offset: 0x00041C6B
		public void SetShadowFadeDistance(float distance)
		{
			this.shadowFadeDistance = distance;
		}

		// Token: 0x06000683 RID: 1667 RVA: 0x00043A74 File Offset: 0x00041C74
		public void SetDirectionalShadowTint(Color tint)
		{
			this.shadowTint = tint;
		}

		// Token: 0x06000684 RID: 1668 RVA: 0x00043A7D File Offset: 0x00041C7D
		public void SetShadowUpdateMode(ShadowUpdateMode updateMode)
		{
			this.shadowUpdateMode = updateMode;
		}

		// Token: 0x06000685 RID: 1669 RVA: 0x00043A86 File Offset: 0x00041C86
		public void SetRange(float range)
		{
			this.legacyLight.range = range;
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x00043A94 File Offset: 0x00041C94
		public void SetShadowLightLayer(LightLayerEnum shadowLayerMask)
		{
			this.legacyLight.renderingLayerMask = HDAdditionalLightData.LightLayerToRenderingLayerMask((int)shadowLayerMask, this.legacyLight.renderingLayerMask);
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x00043AB2 File Offset: 0x00041CB2
		public void SetCullingMask(int cullingMask)
		{
			this.legacyLight.cullingMask = cullingMask;
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x00043AC0 File Offset: 0x00041CC0
		public float[] SetLayerShadowCullDistances(float[] layerShadowCullDistances)
		{
			this.legacyLight.layerShadowCullDistances = layerShadowCullDistances;
			return layerShadowCullDistances;
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x00043ADC File Offset: 0x00041CDC
		public LightUnit[] GetSupportedLightUnits()
		{
			return HDAdditionalLightData.GetSupportedLightUnits(this.type, this.m_SpotLightShape);
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x00043AF0 File Offset: 0x00041CF0
		public void SetAreaLightSize(Vector2 size)
		{
			if (this.type == HDLightType.Area)
			{
				this.m_ShapeWidth = size.x;
				this.m_ShapeHeight = size.y;
				if (this.lightEntity.valid)
				{
					ref HDLightRenderData ptr = ref HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity);
					ptr.shapeWidth = this.m_ShapeWidth;
					ptr.shapeHeight = this.m_ShapeHeight;
				}
				this.UpdateAllLightValues();
			}
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x00043B58 File Offset: 0x00041D58
		public void SetBoxSpotSize(Vector2 size)
		{
			if (this.type == HDLightType.Spot)
			{
				this.shapeWidth = size.x;
				this.shapeHeight = size.y;
			}
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x00043B7C File Offset: 0x00041D7C
		internal static int LightLayerToRenderingLayerMask(int lightLayer, int renderingLayerMask)
		{
			byte b = (byte)lightLayer;
			return (renderingLayerMask & -256) | (int)b;
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x00043B95 File Offset: 0x00041D95
		internal static int RenderingLayerMaskToLightLayer(int renderingLayerMask)
		{
			return (int)((byte)renderingLayerMask);
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x0600068E RID: 1678 RVA: 0x00043B99 File Offset: 0x00041D99
		private ShadowMapType shadowMapType
		{
			get
			{
				if (this.type == HDLightType.Area && this.areaLightShape == AreaLightShape.Rectangle)
				{
					return ShadowMapType.AreaLightAtlas;
				}
				if (this.type == HDLightType.Directional)
				{
					return ShadowMapType.CascadedDirectional;
				}
				return ShadowMapType.PunctualAtlas;
			}
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x00043BBC File Offset: 0x00041DBC
		internal void UpdateRenderEntity()
		{
			HDLightRenderDatabase instance = HDLightRenderDatabase.instance;
			if (!instance.IsValid(this.lightEntity))
			{
				return;
			}
			ref HDLightRenderData ptr = ref instance.EditLightDataAsRef(this.lightEntity);
			ptr.pointLightType = this.m_PointlightHDType;
			ptr.spotLightShape = this.m_SpotLightShape;
			ptr.areaLightShape = this.m_AreaLightShape;
			ptr.lightLayer = this.m_LightlayersMask;
			ptr.fadeDistance = this.m_FadeDistance;
			ptr.distance = this.m_Distance;
			ptr.angularDiameter = this.m_AngularDiameter;
			ptr.volumetricFadeDistance = this.m_VolumetricFadeDistance;
			ptr.includeForRayTracing = this.m_IncludeForRayTracing;
			ptr.useScreenSpaceShadows = this.m_UseScreenSpaceShadows;
			if (this.legacyLight.bakingOutput.lightmapBakeType == LightmapBakeType.Mixed)
			{
				ptr.useRayTracedShadows = (!this.m_NonLightmappedOnly && this.m_UseRayTracedShadows);
			}
			else
			{
				ptr.useRayTracedShadows = this.m_UseRayTracedShadows;
			}
			ptr.colorShadow = this.m_ColorShadow;
			ptr.lightDimmer = this.m_LightDimmer;
			ptr.volumetricDimmer = this.m_VolumetricDimmer;
			ptr.shadowDimmer = this.m_ShadowDimmer;
			ptr.shadowFadeDistance = this.m_ShadowFadeDistance;
			ptr.volumetricShadowDimmer = this.m_VolumetricShadowDimmer;
			ptr.shapeWidth = this.m_ShapeWidth;
			ptr.shapeHeight = this.m_ShapeHeight;
			ptr.flareSize = this.m_FlareSize;
			ptr.flareFalloff = this.m_FlareFalloff;
			ptr.aspectRatio = this.m_AspectRatio;
			ptr.innerSpotPercent = this.m_InnerSpotPercent;
			ptr.spotIESCutoffPercent = this.m_SpotIESCutoffPercent;
			ptr.shapeRadius = this.m_ShapeRadius;
			ptr.barnDoorLength = this.m_BarnDoorLength;
			ptr.affectVolumetric = this.useVolumetric;
			ptr.affectDiffuse = this.m_AffectDiffuse;
			ptr.affectSpecular = this.m_AffectSpecular;
			ptr.applyRangeAttenuation = this.m_ApplyRangeAttenuation;
			ptr.penumbraTint = this.m_PenumbraTint;
			ptr.interactsWithSky = this.m_InteractsWithSky;
			ptr.surfaceTint = this.m_SurfaceTint;
			ptr.shadowTint = this.m_ShadowTint;
			ptr.flareTint = this.m_FlareTint;
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x00043DBC File Offset: 0x00041FBC
		internal void CreateHDLightRenderEntity(bool autoDestroy = false)
		{
			if (!this.lightEntity.valid)
			{
				HDLightRenderDatabase instance = HDLightRenderDatabase.instance;
				this.lightEntity = instance.CreateEntity(autoDestroy);
				instance.AttachGameObjectData(this.lightEntity, this.legacyLight.GetInstanceID(), this, this.legacyLight.gameObject);
			}
			this.UpdateRenderEntity();
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x00043E14 File Offset: 0x00042014
		private void OnEnable()
		{
			if (!this.ShadowIsUpdatedEveryFrame() && this.legacyLight.shadows != LightShadows.None && (this.shadowUpdateMode != ShadowUpdateMode.OnDemand || this.onDemandShadowRenderOnPlacement))
			{
				HDShadowManager.cachedShadowManager.RegisterLight(this);
			}
			this.SetEmissiveMeshRendererEnabled(true);
			this.CreateHDLightRenderEntity(false);
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x00043E60 File Offset: 0x00042060
		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x00043E62 File Offset: 0x00042062
		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			if (this.m_Light == null || this.m_Light.Equals(null))
			{
				return;
			}
			this.UpdateBounds();
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x00043E87 File Offset: 0x00042087
		private void Reset()
		{
			this.UpdateBounds();
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x00043E8F File Offset: 0x0004208F
		internal ShadowMapType GetShadowMapType(HDLightType lightType)
		{
			if (lightType == HDLightType.Area && this.areaLightShape == AreaLightShape.Rectangle)
			{
				return ShadowMapType.AreaLightAtlas;
			}
			if (lightType == HDLightType.Directional)
			{
				return ShadowMapType.CascadedDirectional;
			}
			return ShadowMapType.PunctualAtlas;
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x00043EA8 File Offset: 0x000420A8
		internal bool IsOverlapping()
		{
			LightBakingOutput bakingOutput = base.GetComponent<Light>().bakingOutput;
			bool flag = bakingOutput.occlusionMaskChannel != -1;
			return (bakingOutput.mixedLightingMode == MixedLightingMode.Shadowmask || bakingOutput.mixedLightingMode == MixedLightingMode.Subtractive) && !flag;
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000697 RID: 1687 RVA: 0x00043EEB File Offset: 0x000420EB
		// (set) Token: 0x06000698 RID: 1688 RVA: 0x00043EF3 File Offset: 0x000420F3
		HDAdditionalLightData.Version IVersionable<HDAdditionalLightData.Version>.version
		{
			get
			{
				return this.m_Version;
			}
			set
			{
				this.m_Version = value;
			}
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x00043EFC File Offset: 0x000420FC
		private void Migrate()
		{
			HDAdditionalLightData.k_HDLightMigrationSteps.Migrate(this);
			this.OnValidate();
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x0600069A RID: 1690 RVA: 0x00043F1E File Offset: 0x0004211E
		// (set) Token: 0x0600069B RID: 1691 RVA: 0x00043F2C File Offset: 0x0004212C
		public HDLightType type
		{
			get
			{
				return this.ComputeLightType(this.legacyLight);
			}
			set
			{
				if (this.type != value)
				{
					if (this.m_ShadowUpdateMode != ShadowUpdateMode.EveryFrame)
					{
						HDShadowManager.cachedShadowManager.EvictLight(this);
					}
					switch (value)
					{
					case HDLightType.Spot:
						this.legacyLight.type = LightType.Spot;
						this.m_PointlightHDType = HDAdditionalLightData.PointLightHDType.Punctual;
						if (this.lightEntity.valid)
						{
							HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).pointLightType = this.m_PointlightHDType;
						}
						break;
					case HDLightType.Directional:
						this.legacyLight.type = LightType.Directional;
						this.m_PointlightHDType = HDAdditionalLightData.PointLightHDType.Punctual;
						if (this.lightEntity.valid)
						{
							HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).pointLightType = this.m_PointlightHDType;
						}
						break;
					case HDLightType.Point:
						this.legacyLight.type = LightType.Point;
						this.m_PointlightHDType = HDAdditionalLightData.PointLightHDType.Punctual;
						if (this.lightEntity.valid)
						{
							HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).pointLightType = this.m_PointlightHDType;
						}
						break;
					case HDLightType.Area:
						this.ResolveAreaShape();
						break;
					}
					if (this.legacyLight.shadows != LightShadows.None && this.m_ShadowUpdateMode != ShadowUpdateMode.EveryFrame)
					{
						HDShadowManager.cachedShadowManager.RegisterLight(this);
					}
					LightUnit[] supportedLightUnits = HDAdditionalLightData.GetSupportedLightUnits(value, this.m_SpotLightShape);
					if (!supportedLightUnits.Any((LightUnit u) => u == this.lightUnit))
					{
						this.lightUnit = supportedLightUnits.First<LightUnit>();
					}
					this.UpdateAllLightValues();
				}
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x0600069C RID: 1692 RVA: 0x00044089 File Offset: 0x00042289
		// (set) Token: 0x0600069D RID: 1693 RVA: 0x00044094 File Offset: 0x00042294
		public SpotLightShape spotLightShape
		{
			get
			{
				return this.m_SpotLightShape;
			}
			set
			{
				if (this.m_SpotLightShape == value)
				{
					return;
				}
				this.m_SpotLightShape = value;
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).spotLightShape = this.m_SpotLightShape;
				}
				LightUnit[] supportedLightUnits = HDAdditionalLightData.GetSupportedLightUnits(this.type, value);
				if (!supportedLightUnits.Any((LightUnit u) => u == this.lightUnit))
				{
					this.lightUnit = supportedLightUnits.First<LightUnit>();
				}
				this.UpdateAllLightValues();
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x0600069E RID: 1694 RVA: 0x0004410D File Offset: 0x0004230D
		// (set) Token: 0x0600069F RID: 1695 RVA: 0x00044118 File Offset: 0x00042318
		public AreaLightShape areaLightShape
		{
			get
			{
				return this.m_AreaLightShape;
			}
			set
			{
				if (this.m_AreaLightShape == value)
				{
					return;
				}
				this.m_AreaLightShape = value;
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).areaLightShape = this.m_AreaLightShape;
				}
				if (this.type == HDLightType.Area)
				{
					this.ResolveAreaShape();
				}
				this.UpdateAllLightValues();
			}
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x00044174 File Offset: 0x00042374
		private void ResolveAreaShape()
		{
			this.m_PointlightHDType = HDAdditionalLightData.PointLightHDType.Area;
			if (this.lightEntity.valid)
			{
				HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).pointLightType = this.m_PointlightHDType;
			}
			if (this.areaLightShape == AreaLightShape.Disc)
			{
				this.legacyLight.type = LightType.Disc;
				return;
			}
			if (this.areaLightShape != AreaLightShape.Tube)
			{
				this.legacyLight.type = LightType.Point;
			}
		}

		// Token: 0x060006A1 RID: 1697 RVA: 0x000441DC File Offset: 0x000423DC
		public void SetLightTypeAndShape(HDLightTypeAndShape typeAndShape)
		{
			switch (typeAndShape)
			{
			case HDLightTypeAndShape.Point:
				this.type = HDLightType.Point;
				return;
			case HDLightTypeAndShape.BoxSpot:
				this.type = HDLightType.Spot;
				this.spotLightShape = SpotLightShape.Box;
				return;
			case HDLightTypeAndShape.PyramidSpot:
				this.type = HDLightType.Spot;
				this.spotLightShape = SpotLightShape.Pyramid;
				return;
			case HDLightTypeAndShape.ConeSpot:
				this.type = HDLightType.Spot;
				this.spotLightShape = SpotLightShape.Cone;
				return;
			case HDLightTypeAndShape.Directional:
				this.type = HDLightType.Directional;
				return;
			case HDLightTypeAndShape.RectangleArea:
				this.type = HDLightType.Area;
				this.areaLightShape = AreaLightShape.Rectangle;
				return;
			case HDLightTypeAndShape.TubeArea:
				this.type = HDLightType.Area;
				this.areaLightShape = AreaLightShape.Tube;
				return;
			case HDLightTypeAndShape.DiscArea:
				this.type = HDLightType.Area;
				this.areaLightShape = AreaLightShape.Disc;
				return;
			default:
				return;
			}
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x0004427C File Offset: 0x0004247C
		public HDLightTypeAndShape GetLightTypeAndShape()
		{
			switch (this.type)
			{
			case HDLightType.Spot:
				switch (this.spotLightShape)
				{
				case SpotLightShape.Cone:
					return HDLightTypeAndShape.ConeSpot;
				case SpotLightShape.Pyramid:
					return HDLightTypeAndShape.PyramidSpot;
				case SpotLightShape.Box:
					return HDLightTypeAndShape.BoxSpot;
				default:
					throw new Exception(string.Format("Unknown {0}: {1}", typeof(SpotLightShape), this.spotLightShape));
				}
				break;
			case HDLightType.Directional:
				return HDLightTypeAndShape.Directional;
			case HDLightType.Point:
				return HDLightTypeAndShape.Point;
			case HDLightType.Area:
				switch (this.areaLightShape)
				{
				case AreaLightShape.Rectangle:
					return HDLightTypeAndShape.RectangleArea;
				case AreaLightShape.Tube:
					return HDLightTypeAndShape.TubeArea;
				case AreaLightShape.Disc:
					return HDLightTypeAndShape.DiscArea;
				default:
					throw new Exception(string.Format("Unknown {0}: {1}", typeof(AreaLightShape), this.areaLightShape));
				}
				break;
			default:
				throw new Exception(string.Format("Unknown {0}: {1}", typeof(HDLightType), this.type));
			}
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x00044360 File Offset: 0x00042560
		private string GetLightTypeName()
		{
			if (this.type == HDLightType.Area)
			{
				return string.Format("{0}AreaLight", this.areaLightShape);
			}
			if (this.legacyLight.type == LightType.Spot)
			{
				return string.Format("{0}SpotLight", this.spotLightShape);
			}
			return string.Format("{0}Light", this.legacyLight.type);
		}

		// Token: 0x060006A4 RID: 1700 RVA: 0x000443CC File Offset: 0x000425CC
		public static LightUnit[] GetSupportedLightUnits(HDLightType type, SpotLightShape spotLightShape)
		{
			int num = (int)(type & (HDLightType)255);
			num |= (int)((int)(spotLightShape & (SpotLightShape)255) << 8);
			LightUnit[] array;
			if (HDAdditionalLightData.supportedLightTypeCache.TryGetValue(num, out array))
			{
				return array;
			}
			if (type == HDLightType.Area)
			{
				array = Enum.GetValues(typeof(AreaLightUnit)).Cast<LightUnit>().ToArray<LightUnit>();
			}
			else if (type == HDLightType.Directional || (type == HDLightType.Spot && spotLightShape == SpotLightShape.Box))
			{
				array = Enum.GetValues(typeof(DirectionalLightUnit)).Cast<LightUnit>().ToArray<LightUnit>();
			}
			else
			{
				array = Enum.GetValues(typeof(PunctualLightUnit)).Cast<LightUnit>().ToArray<LightUnit>();
			}
			HDAdditionalLightData.supportedLightTypeCache[num] = array;
			return array;
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x0004446C File Offset: 0x0004266C
		public static bool IsValidLightUnitForType(HDLightType type, SpotLightShape spotLightShape, LightUnit unit)
		{
			return HDAdditionalLightData.GetSupportedLightUnits(type, spotLightShape).Any((LightUnit u) => u == unit);
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x0004449E File Offset: 0x0004269E
		internal static HDLightType TranslateLightType(LightType lightType, HDAdditionalLightData.PointLightHDType pointLightType)
		{
			switch (lightType)
			{
			case LightType.Spot:
				return HDLightType.Spot;
			case LightType.Directional:
				return HDLightType.Directional;
			case LightType.Point:
				if (pointLightType == HDAdditionalLightData.PointLightHDType.Punctual)
				{
					return HDLightType.Point;
				}
				if (pointLightType != HDAdditionalLightData.PointLightHDType.Area)
				{
					return HDLightType.Point;
				}
				return HDLightType.Area;
			case LightType.Area:
				return HDLightType.Area;
			case LightType.Disc:
				return HDLightType.Area;
			default:
				return HDLightType.Point;
			}
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x000444D4 File Offset: 0x000426D4
		internal HDLightType ComputeLightType(Light attachedLight)
		{
			if (attachedLight == null)
			{
				return HDLightType.Point;
			}
			HDLightType result = HDAdditionalLightData.TranslateLightType(attachedLight.type, this.m_PointlightHDType);
			if (attachedLight.type == LightType.Area && this != HDUtils.s_DefaultHDAdditionalLightData)
			{
				this.legacyLight.type = LightType.Point;
				this.m_PointlightHDType = HDAdditionalLightData.PointLightHDType.Area;
				if (this.lightEntity.valid)
				{
					HDLightRenderDatabase.instance.EditLightDataAsRef(this.lightEntity).pointLightType = this.m_PointlightHDType;
				}
				this.m_AreaLightShape = AreaLightShape.Rectangle;
			}
			return result;
		}

		// Token: 0x040004D9 RID: 1241
		internal const float k_MinLightSize = 0.01f;

		// Token: 0x040004DA RID: 1242
		public const float k_DefaultDirectionalLightIntensity = 3.1415927f;

		// Token: 0x040004DB RID: 1243
		public const float k_DefaultPunctualLightIntensity = 600f;

		// Token: 0x040004DC RID: 1244
		public const float k_DefaultAreaLightIntensity = 200f;

		// Token: 0x040004DD RID: 1245
		public const float k_MinSpotAngle = 1f;

		// Token: 0x040004DE RID: 1246
		public const float k_MaxSpotAngle = 179f;

		// Token: 0x040004DF RID: 1247
		public const float k_MinAspectRatio = 0.05f;

		// Token: 0x040004E0 RID: 1248
		public const float k_MaxAspectRatio = 20f;

		// Token: 0x040004E1 RID: 1249
		public const float k_MinViewBiasScale = 0f;

		// Token: 0x040004E2 RID: 1250
		public const float k_MaxViewBiasScale = 15f;

		// Token: 0x040004E3 RID: 1251
		public const float k_MinAreaWidth = 0.01f;

		// Token: 0x040004E4 RID: 1252
		public const int k_DefaultShadowResolution = 512;

		// Token: 0x040004E5 RID: 1253
		internal const float k_MinEvsmExponent = 5f;

		// Token: 0x040004E6 RID: 1254
		internal const float k_MaxEvsmExponent = 42f;

		// Token: 0x040004E7 RID: 1255
		internal const float k_MinEvsmLightLeakBias = 0f;

		// Token: 0x040004E8 RID: 1256
		internal const float k_MaxEvsmLightLeakBias = 1f;

		// Token: 0x040004E9 RID: 1257
		internal const float k_MinEvsmVarianceBias = 0f;

		// Token: 0x040004EA RID: 1258
		internal const float k_MaxEvsmVarianceBias = 0.001f;

		// Token: 0x040004EB RID: 1259
		internal const int k_MinEvsmBlurPasses = 0;

		// Token: 0x040004EC RID: 1260
		internal const int k_MaxEvsmBlurPasses = 8;

		// Token: 0x040004ED RID: 1261
		internal const float k_MinSpotInnerPercent = 0f;

		// Token: 0x040004EE RID: 1262
		internal const float k_MaxSpotInnerPercent = 100f;

		// Token: 0x040004EF RID: 1263
		internal const float k_MinAreaLightShadowCone = 10f;

		// Token: 0x040004F0 RID: 1264
		internal const float k_MaxAreaLightShadowCone = 179f;

		// Token: 0x040004F1 RID: 1265
		internal static HashSet<HDAdditionalLightData> s_overlappingHDLights = new HashSet<HDAdditionalLightData>();

		// Token: 0x040004F2 RID: 1266
		[ExcludeCopy]
		internal HDLightRenderEntity lightEntity = HDLightRenderEntity.Invalid;

		// Token: 0x040004F3 RID: 1267
		[SerializeField]
		[FormerlySerializedAs("displayLightIntensity")]
		private float m_Intensity;

		// Token: 0x040004F4 RID: 1268
		[SerializeField]
		[FormerlySerializedAs("enableSpotReflector")]
		private bool m_EnableSpotReflector = true;

		// Token: 0x040004F5 RID: 1269
		[SerializeField]
		[FormerlySerializedAs("luxAtDistance")]
		private float m_LuxAtDistance = 1f;

		// Token: 0x040004F6 RID: 1270
		[Range(0f, 100f)]
		[SerializeField]
		private float m_InnerSpotPercent;

		// Token: 0x040004F7 RID: 1271
		[Range(0f, 100f)]
		[SerializeField]
		private float m_SpotIESCutoffPercent = 100f;

		// Token: 0x040004F8 RID: 1272
		[Range(0f, 16f)]
		[SerializeField]
		[FormerlySerializedAs("lightDimmer")]
		private float m_LightDimmer = 1f;

		// Token: 0x040004F9 RID: 1273
		[Range(0f, 16f)]
		[SerializeField]
		[FormerlySerializedAs("volumetricDimmer")]
		private float m_VolumetricDimmer = 1f;

		// Token: 0x040004FA RID: 1274
		[SerializeField]
		[FormerlySerializedAs("lightUnit")]
		private LightUnit m_LightUnit;

		// Token: 0x040004FB RID: 1275
		[SerializeField]
		[FormerlySerializedAs("fadeDistance")]
		private float m_FadeDistance = 10000f;

		// Token: 0x040004FC RID: 1276
		[SerializeField]
		private float m_VolumetricFadeDistance = 10000f;

		// Token: 0x040004FD RID: 1277
		[SerializeField]
		[FormerlySerializedAs("affectDiffuse")]
		private bool m_AffectDiffuse = true;

		// Token: 0x040004FE RID: 1278
		[SerializeField]
		[FormerlySerializedAs("affectSpecular")]
		private bool m_AffectSpecular = true;

		// Token: 0x040004FF RID: 1279
		[SerializeField]
		[FormerlySerializedAs("nonLightmappedOnly")]
		private bool m_NonLightmappedOnly;

		// Token: 0x04000500 RID: 1280
		[SerializeField]
		[FormerlySerializedAs("shapeWidth")]
		private float m_ShapeWidth = 0.5f;

		// Token: 0x04000501 RID: 1281
		[SerializeField]
		[FormerlySerializedAs("shapeHeight")]
		private float m_ShapeHeight = 0.5f;

		// Token: 0x04000502 RID: 1282
		[SerializeField]
		[FormerlySerializedAs("aspectRatio")]
		private float m_AspectRatio = 1f;

		// Token: 0x04000503 RID: 1283
		[SerializeField]
		[FormerlySerializedAs("shapeRadius")]
		private float m_ShapeRadius = 0.025f;

		// Token: 0x04000504 RID: 1284
		[SerializeField]
		private float m_SoftnessScale = 1f;

		// Token: 0x04000505 RID: 1285
		[SerializeField]
		[FormerlySerializedAs("useCustomSpotLightShadowCone")]
		private bool m_UseCustomSpotLightShadowCone;

		// Token: 0x04000506 RID: 1286
		[SerializeField]
		[FormerlySerializedAs("customSpotLightShadowCone")]
		private float m_CustomSpotLightShadowCone = 30f;

		// Token: 0x04000507 RID: 1287
		[Range(0f, 1f)]
		[SerializeField]
		[FormerlySerializedAs("maxSmoothness")]
		private float m_MaxSmoothness = 0.99f;

		// Token: 0x04000508 RID: 1288
		[SerializeField]
		[FormerlySerializedAs("applyRangeAttenuation")]
		private bool m_ApplyRangeAttenuation = true;

		// Token: 0x04000509 RID: 1289
		[SerializeField]
		[FormerlySerializedAs("displayAreaLightEmissiveMesh")]
		private bool m_DisplayAreaLightEmissiveMesh;

		// Token: 0x0400050A RID: 1290
		[SerializeField]
		[FormerlySerializedAs("areaLightCookie")]
		private Texture m_AreaLightCookie;

		// Token: 0x0400050B RID: 1291
		[SerializeField]
		internal Texture m_IESPoint;

		// Token: 0x0400050C RID: 1292
		[SerializeField]
		internal Texture m_IESSpot;

		// Token: 0x0400050D RID: 1293
		[SerializeField]
		private bool m_IncludeForRayTracing = true;

		// Token: 0x0400050E RID: 1294
		[Range(10f, 179f)]
		[SerializeField]
		[FormerlySerializedAs("areaLightShadowCone")]
		private float m_AreaLightShadowCone = 120f;

		// Token: 0x0400050F RID: 1295
		[SerializeField]
		[FormerlySerializedAs("useScreenSpaceShadows")]
		private bool m_UseScreenSpaceShadows;

		// Token: 0x04000510 RID: 1296
		[SerializeField]
		[FormerlySerializedAs("interactsWithSky")]
		private bool m_InteractsWithSky = true;

		// Token: 0x04000511 RID: 1297
		[SerializeField]
		[FormerlySerializedAs("angularDiameter")]
		private float m_AngularDiameter = 0.5f;

		// Token: 0x04000512 RID: 1298
		[SerializeField]
		[FormerlySerializedAs("flareSize")]
		private float m_FlareSize = 2f;

		// Token: 0x04000513 RID: 1299
		[SerializeField]
		[FormerlySerializedAs("flareTint")]
		private Color m_FlareTint = Color.white;

		// Token: 0x04000514 RID: 1300
		[SerializeField]
		[FormerlySerializedAs("flareFalloff")]
		private float m_FlareFalloff = 4f;

		// Token: 0x04000515 RID: 1301
		[SerializeField]
		[FormerlySerializedAs("surfaceTexture")]
		private Texture2D m_SurfaceTexture;

		// Token: 0x04000516 RID: 1302
		[SerializeField]
		[FormerlySerializedAs("surfaceTint")]
		private Color m_SurfaceTint = Color.white;

		// Token: 0x04000517 RID: 1303
		[SerializeField]
		[FormerlySerializedAs("distance")]
		private float m_Distance = 1.5E+11f;

		// Token: 0x04000518 RID: 1304
		[SerializeField]
		[FormerlySerializedAs("useRayTracedShadows")]
		private bool m_UseRayTracedShadows;

		// Token: 0x04000519 RID: 1305
		[Range(1f, 32f)]
		[SerializeField]
		[FormerlySerializedAs("numRayTracingSamples")]
		private int m_NumRayTracingSamples = 4;

		// Token: 0x0400051A RID: 1306
		[SerializeField]
		[FormerlySerializedAs("filterTracedShadow")]
		private bool m_FilterTracedShadow = true;

		// Token: 0x0400051B RID: 1307
		[Range(1f, 32f)]
		[SerializeField]
		[FormerlySerializedAs("filterSizeTraced")]
		private int m_FilterSizeTraced = 16;

		// Token: 0x0400051C RID: 1308
		[Range(0f, 2f)]
		[SerializeField]
		[FormerlySerializedAs("sunLightConeAngle")]
		private float m_SunLightConeAngle = 0.5f;

		// Token: 0x0400051D RID: 1309
		[SerializeField]
		[FormerlySerializedAs("lightShadowRadius")]
		private float m_LightShadowRadius = 0.5f;

		// Token: 0x0400051E RID: 1310
		[SerializeField]
		private bool m_SemiTransparentShadow;

		// Token: 0x0400051F RID: 1311
		[SerializeField]
		private bool m_ColorShadow = true;

		// Token: 0x04000520 RID: 1312
		[SerializeField]
		private bool m_DistanceBasedFiltering;

		// Token: 0x04000521 RID: 1313
		[Range(5f, 42f)]
		[SerializeField]
		[FormerlySerializedAs("evsmExponent")]
		private float m_EvsmExponent = 15f;

		// Token: 0x04000522 RID: 1314
		[Range(0f, 1f)]
		[SerializeField]
		[FormerlySerializedAs("evsmLightLeakBias")]
		private float m_EvsmLightLeakBias;

		// Token: 0x04000523 RID: 1315
		[Range(0f, 0.001f)]
		[SerializeField]
		[FormerlySerializedAs("evsmVarianceBias")]
		private float m_EvsmVarianceBias = 1E-05f;

		// Token: 0x04000524 RID: 1316
		[Range(0f, 8f)]
		[SerializeField]
		[FormerlySerializedAs("evsmBlurPasses")]
		private int m_EvsmBlurPasses;

		// Token: 0x04000525 RID: 1317
		[SerializeField]
		[FormerlySerializedAs("lightlayersMask")]
		private LightLayerEnum m_LightlayersMask = LightLayerEnum.LightLayerDefault;

		// Token: 0x04000526 RID: 1318
		[SerializeField]
		[FormerlySerializedAs("linkShadowLayers")]
		private bool m_LinkShadowLayers = true;

		// Token: 0x04000527 RID: 1319
		[SerializeField]
		[FormerlySerializedAs("shadowNearPlane")]
		private float m_ShadowNearPlane = 0.1f;

		// Token: 0x04000528 RID: 1320
		[Range(1f, 64f)]
		[SerializeField]
		[FormerlySerializedAs("blockerSampleCount")]
		private int m_BlockerSampleCount = 24;

		// Token: 0x04000529 RID: 1321
		[Range(1f, 64f)]
		[SerializeField]
		[FormerlySerializedAs("filterSampleCount")]
		private int m_FilterSampleCount = 16;

		// Token: 0x0400052A RID: 1322
		[Range(0f, 1f)]
		[SerializeField]
		[FormerlySerializedAs("minFilterSize")]
		private float m_MinFilterSize = 0.1f;

		// Token: 0x0400052B RID: 1323
		[Range(1f, 32f)]
		[SerializeField]
		[FormerlySerializedAs("kernelSize")]
		private int m_KernelSize = 5;

		// Token: 0x0400052C RID: 1324
		[Range(0f, 9f)]
		[SerializeField]
		[FormerlySerializedAs("lightAngle")]
		private float m_LightAngle = 1f;

		// Token: 0x0400052D RID: 1325
		[Range(0.0001f, 0.01f)]
		[SerializeField]
		[FormerlySerializedAs("maxDepthBias")]
		private float m_MaxDepthBias = 0.001f;

		// Token: 0x0400052E RID: 1326
		[ValueCopy]
		[SerializeField]
		private IntScalableSettingValue m_ShadowResolution = new IntScalableSettingValue
		{
			@override = 512,
			useOverride = true
		};

		// Token: 0x0400052F RID: 1327
		[Range(0f, 1f)]
		[SerializeField]
		private float m_ShadowDimmer = 1f;

		// Token: 0x04000530 RID: 1328
		[Range(0f, 1f)]
		[SerializeField]
		private float m_VolumetricShadowDimmer = 1f;

		// Token: 0x04000531 RID: 1329
		[SerializeField]
		private float m_ShadowFadeDistance = 10000f;

		// Token: 0x04000532 RID: 1330
		[SerializeField]
		[ValueCopy]
		private BoolScalableSettingValue m_UseContactShadow = new BoolScalableSettingValue
		{
			useOverride = true
		};

		// Token: 0x04000533 RID: 1331
		[SerializeField]
		private bool m_RayTracedContactShadow;

		// Token: 0x04000534 RID: 1332
		[SerializeField]
		private Color m_ShadowTint = Color.black;

		// Token: 0x04000535 RID: 1333
		[SerializeField]
		private bool m_PenumbraTint;

		// Token: 0x04000536 RID: 1334
		[SerializeField]
		private float m_NormalBias = 0.75f;

		// Token: 0x04000537 RID: 1335
		[SerializeField]
		private float m_SlopeBias = 0.5f;

		// Token: 0x04000538 RID: 1336
		[SerializeField]
		private ShadowUpdateMode m_ShadowUpdateMode;

		// Token: 0x04000539 RID: 1337
		[SerializeField]
		private bool m_AlwaysDrawDynamicShadows;

		// Token: 0x0400053A RID: 1338
		[SerializeField]
		private bool m_UpdateShadowOnLightMovement;

		// Token: 0x0400053B RID: 1339
		[SerializeField]
		private float m_CachedShadowTranslationThreshold = 0.01f;

		// Token: 0x0400053C RID: 1340
		[SerializeField]
		private float m_CachedShadowAngularThreshold = 0.5f;

		// Token: 0x0400053D RID: 1341
		[Range(0f, 90f)]
		[SerializeField]
		private float m_BarnDoorAngle = 90f;

		// Token: 0x0400053E RID: 1342
		[SerializeField]
		private float m_BarnDoorLength = 0.05f;

		// Token: 0x0400053F RID: 1343
		[SerializeField]
		private bool m_preserveCachedShadow;

		// Token: 0x04000540 RID: 1344
		[SerializeField]
		private bool m_OnDemandShadowRenderOnPlacement = true;

		// Token: 0x04000541 RID: 1345
		internal bool forceRenderOnPlacement;

		// Token: 0x04000542 RID: 1346
		[SerializeField]
		[ValueCopy]
		private float[] m_ShadowCascadeRatios = new float[]
		{
			0.05f,
			0.2f,
			0.3f
		};

		// Token: 0x04000543 RID: 1347
		[SerializeField]
		[ValueCopy]
		private float[] m_ShadowCascadeBorders = new float[]
		{
			0.2f,
			0.2f,
			0.2f,
			0.2f
		};

		// Token: 0x04000544 RID: 1348
		[SerializeField]
		private int m_ShadowAlgorithm;

		// Token: 0x04000545 RID: 1349
		[SerializeField]
		private int m_ShadowVariant;

		// Token: 0x04000546 RID: 1350
		[SerializeField]
		private int m_ShadowPrecision;

		// Token: 0x04000547 RID: 1351
		[SerializeField]
		[FormerlySerializedAs("useOldInspector")]
		private bool useOldInspector;

		// Token: 0x04000548 RID: 1352
		[SerializeField]
		[FormerlySerializedAs("useVolumetric")]
		private bool useVolumetric = true;

		// Token: 0x04000549 RID: 1353
		[SerializeField]
		[FormerlySerializedAs("featuresFoldout")]
		private bool featuresFoldout = true;

		// Token: 0x0400054A RID: 1354
		[ExcludeCopy]
		private HDShadowRequest[] shadowRequests;

		// Token: 0x0400054B RID: 1355
		[ExcludeCopy]
		private int[] m_ShadowRequestIndices;

		// Token: 0x0400054C RID: 1356
		[ExcludeCopy]
		[NonSerialized]
		internal int lightIdxForCachedShadows = -1;

		// Token: 0x0400054D RID: 1357
		[ExcludeCopy]
		private Vector3[] m_CachedViewPositions;

		// Token: 0x0400054E RID: 1358
		[ExcludeCopy]
		[NonSerialized]
		private Plane[] m_ShadowFrustumPlanes = new Plane[6];

		// Token: 0x0400054F RID: 1359
		[ExcludeCopy]
		[NonSerialized]
		internal Matrix4x4 previousTransform = Matrix4x4.identity;

		// Token: 0x04000550 RID: 1360
		[ExcludeCopy]
		[NonSerialized]
		internal int shadowIndex = -1;

		// Token: 0x04000551 RID: 1361
		[ExcludeCopy]
		private Light m_Light;

		// Token: 0x04000552 RID: 1362
		private const string k_EmissiveMeshViewerName = "EmissiveMeshViewer";

		// Token: 0x04000553 RID: 1363
		[ExcludeCopy]
		private GameObject m_ChildEmissiveMeshViewer;

		// Token: 0x04000554 RID: 1364
		[ExcludeCopy]
		private MeshFilter m_EmissiveMeshFilter;

		// Token: 0x04000556 RID: 1366
		[ExcludeCopy]
		private bool needRefreshEmissiveMeshesFromTimeLineUpdate;

		// Token: 0x04000557 RID: 1367
		[SerializeField]
		private ShadowCastingMode m_AreaLightEmissiveMeshShadowCastingMode;

		// Token: 0x04000558 RID: 1368
		[SerializeField]
		private MotionVectorGenerationMode m_AreaLightEmissiveMeshMotionVectorGenerationMode;

		// Token: 0x04000559 RID: 1369
		[SerializeField]
		private int m_AreaLightEmissiveMeshLayer = -1;

		// Token: 0x0400055A RID: 1370
		public HDAdditionalLightData.CustomViewCallback CustomViewCallbackEvent;

		// Token: 0x0400055B RID: 1371
		[NonSerialized]
		private TimelineWorkaround timelineWorkaround;

		// Token: 0x0400055C RID: 1372
		[ExcludeCopy]
		[NonSerialized]
		private bool m_Animated;

		// Token: 0x0400055D RID: 1373
		[SerializeField]
		[ExcludeCopy]
		private HDAdditionalLightData.Version m_Version = MigrationDescription.LastVersion<HDAdditionalLightData.Version>();

		// Token: 0x0400055E RID: 1374
		private static readonly MigrationDescription<HDAdditionalLightData.Version, HDAdditionalLightData> k_HDLightMigrationSteps = MigrationDescription.New<HDAdditionalLightData.Version, HDAdditionalLightData>(new MigrationStep<HDAdditionalLightData.Version, HDAdditionalLightData>[]
		{
			MigrationStep.New<HDAdditionalLightData.Version, HDAdditionalLightData>(HDAdditionalLightData.Version.ShadowNearPlane, delegate(HDAdditionalLightData data)
			{
				data.shadowNearPlane = data.legacyLight.shadowNearPlane;
			}),
			MigrationStep.New<HDAdditionalLightData.Version, HDAdditionalLightData>(HDAdditionalLightData.Version.LightLayer, delegate(HDAdditionalLightData data)
			{
				data.legacyLight.renderingLayerMask = HDAdditionalLightData.LightLayerToRenderingLayerMask((int)data.m_LightLayers, data.legacyLight.renderingLayerMask);
			}),
			MigrationStep.New<HDAdditionalLightData.Version, HDAdditionalLightData>(HDAdditionalLightData.Version.ShadowLayer, delegate(HDAdditionalLightData data)
			{
				data.lightlayersMask = (LightLayerEnum)HDAdditionalLightData.RenderingLayerMaskToLightLayer(data.legacyLight.renderingLayerMask);
			}),
			MigrationStep.New<HDAdditionalLightData.Version, HDAdditionalLightData>(HDAdditionalLightData.Version.ShadowResolution, delegate(HDAdditionalLightData data)
			{
				AdditionalShadowData component = data.GetComponent<AdditionalShadowData>();
				if (component != null)
				{
					data.m_ObsoleteCustomShadowResolution = component.customResolution;
					data.m_ObsoleteContactShadows = component.contactShadows;
					data.shadowDimmer = component.shadowDimmer;
					data.volumetricShadowDimmer = component.volumetricShadowDimmer;
					data.shadowFadeDistance = component.shadowFadeDistance;
					data.shadowTint = component.shadowTint;
					data.normalBias = component.normalBias;
					data.shadowUpdateMode = component.shadowUpdateMode;
					data.shadowCascadeRatios = component.shadowCascadeRatios;
					data.shadowCascadeBorders = component.shadowCascadeBorders;
					data.shadowAlgorithm = component.shadowAlgorithm;
					data.shadowVariant = component.shadowVariant;
					data.shadowPrecision = component.shadowPrecision;
					CoreUtils.Destroy(component);
				}
				data.shadowResolution.@override = data.m_ObsoleteCustomShadowResolution;
				switch (data.m_ObsoleteShadowResolutionTier)
				{
				case HDAdditionalLightData.ShadowResolutionTier.Low:
					data.shadowResolution.level = 0;
					break;
				case HDAdditionalLightData.ShadowResolutionTier.Medium:
					data.shadowResolution.level = 1;
					break;
				case HDAdditionalLightData.ShadowResolutionTier.High:
					data.shadowResolution.level = 2;
					break;
				case HDAdditionalLightData.ShadowResolutionTier.VeryHigh:
					data.shadowResolution.level = 3;
					break;
				}
				data.shadowResolution.useOverride = !data.m_ObsoleteUseShadowQualitySettings;
				data.useContactShadow.@override = data.m_ObsoleteContactShadows;
			}),
			MigrationStep.New<HDAdditionalLightData.Version, HDAdditionalLightData>(HDAdditionalLightData.Version.RemoveAdditionalShadowData, delegate(HDAdditionalLightData data)
			{
				AdditionalShadowData component = data.GetComponent<AdditionalShadowData>();
				if (component != null)
				{
					CoreUtils.Destroy(component);
				}
			}),
			MigrationStep.New<HDAdditionalLightData.Version, HDAdditionalLightData>(HDAdditionalLightData.Version.AreaLightShapeTypeLogicIsolation, delegate(HDAdditionalLightData data)
			{
				switch (data.m_PointlightHDType)
				{
				case HDAdditionalLightData.PointLightHDType.Punctual:
					data.m_PointlightHDType = HDAdditionalLightData.PointLightHDType.Punctual;
					return;
				case HDAdditionalLightData.PointLightHDType.Area:
					data.m_PointlightHDType = HDAdditionalLightData.PointLightHDType.Area;
					data.m_AreaLightShape = AreaLightShape.Rectangle;
					return;
				case (HDAdditionalLightData.PointLightHDType)2:
					data.m_PointlightHDType = HDAdditionalLightData.PointLightHDType.Area;
					data.m_AreaLightShape = AreaLightShape.Tube;
					return;
				default:
					return;
				}
			}),
			MigrationStep.New<HDAdditionalLightData.Version, HDAdditionalLightData>(HDAdditionalLightData.Version.PCSSUIUpdate, delegate(HDAdditionalLightData data)
			{
				data.minFilterSize *= 1000f;
			}),
			MigrationStep.New<HDAdditionalLightData.Version, HDAdditionalLightData>(HDAdditionalLightData.Version.MoveEmissionMesh, delegate(HDAdditionalLightData data)
			{
				MeshRenderer component = data.GetComponent<MeshRenderer>();
				bool flag = component != null;
				ShadowCastingMode areaLightEmissiveMeshShadowCastingMode = ShadowCastingMode.Off;
				MotionVectorGenerationMode areaLightEmissiveMeshMotionVectorGenerationMode = MotionVectorGenerationMode.Camera;
				if (flag)
				{
					areaLightEmissiveMeshShadowCastingMode = component.shadowCastingMode;
					areaLightEmissiveMeshMotionVectorGenerationMode = component.motionVectorGenerationMode;
				}
				CoreUtils.Destroy(data.GetComponent<MeshFilter>());
				CoreUtils.Destroy(component);
				if (flag)
				{
					data.m_AreaLightEmissiveMeshShadowCastingMode = areaLightEmissiveMeshShadowCastingMode;
					data.m_AreaLightEmissiveMeshMotionVectorGenerationMode = areaLightEmissiveMeshMotionVectorGenerationMode;
				}
			}),
			MigrationStep.New<HDAdditionalLightData.Version, HDAdditionalLightData>(HDAdditionalLightData.Version.EnableApplyRangeAttenuationOnBoxLight, delegate(HDAdditionalLightData data)
			{
				if (data.type == HDLightType.Spot && data.spotLightShape == SpotLightShape.Box)
				{
					data.applyRangeAttenuation = false;
				}
			})
		});

		// Token: 0x0400055F RID: 1375
		[Obsolete("Use Light.renderingLayerMask instead")]
		[FormerlySerializedAs("lightLayers")]
		[ExcludeCopy]
		private LightLayerEnum m_LightLayers = LightLayerEnum.LightLayerDefault;

		// Token: 0x04000560 RID: 1376
		[Obsolete]
		[SerializeField]
		[FormerlySerializedAs("m_ShadowResolutionTier")]
		[ExcludeCopy]
		private HDAdditionalLightData.ShadowResolutionTier m_ObsoleteShadowResolutionTier = HDAdditionalLightData.ShadowResolutionTier.Medium;

		// Token: 0x04000561 RID: 1377
		[Obsolete]
		[SerializeField]
		[FormerlySerializedAs("m_UseShadowQualitySettings")]
		[ExcludeCopy]
		private bool m_ObsoleteUseShadowQualitySettings;

		// Token: 0x04000562 RID: 1378
		[FormerlySerializedAs("m_CustomShadowResolution")]
		[Obsolete]
		[SerializeField]
		[ExcludeCopy]
		private int m_ObsoleteCustomShadowResolution = 512;

		// Token: 0x04000563 RID: 1379
		[FormerlySerializedAs("m_ContactShadows")]
		[Obsolete]
		[SerializeField]
		[ExcludeCopy]
		private bool m_ObsoleteContactShadows;

		// Token: 0x04000564 RID: 1380
		[NonSerialized]
		private static Dictionary<int, LightUnit[]> supportedLightTypeCache = new Dictionary<int, LightUnit[]>();

		// Token: 0x04000565 RID: 1381
		[SerializeField]
		[FormerlySerializedAs("lightTypeExtent")]
		[FormerlySerializedAs("m_LightTypeExtent")]
		private HDAdditionalLightData.PointLightHDType m_PointlightHDType;

		// Token: 0x04000566 RID: 1382
		[SerializeField]
		[FormerlySerializedAs("spotLightShape")]
		private SpotLightShape m_SpotLightShape;

		// Token: 0x04000567 RID: 1383
		[SerializeField]
		private AreaLightShape m_AreaLightShape;

		// Token: 0x02000320 RID: 800
		internal static class ScalableSettings
		{
			// Token: 0x0600126B RID: 4715 RVA: 0x0008D2B5 File Offset: 0x0008B4B5
			public static IntScalableSetting ShadowResolutionArea(HDRenderPipelineAsset hdrp)
			{
				return hdrp.currentPlatformRenderPipelineSettings.hdShadowInitParams.shadowResolutionArea;
			}

			// Token: 0x0600126C RID: 4716 RVA: 0x0008D2C7 File Offset: 0x0008B4C7
			public static IntScalableSetting ShadowResolutionPunctual(HDRenderPipelineAsset hdrp)
			{
				return hdrp.currentPlatformRenderPipelineSettings.hdShadowInitParams.shadowResolutionPunctual;
			}

			// Token: 0x0600126D RID: 4717 RVA: 0x0008D2D9 File Offset: 0x0008B4D9
			public static IntScalableSetting ShadowResolutionDirectional(HDRenderPipelineAsset hdrp)
			{
				return hdrp.currentPlatformRenderPipelineSettings.hdShadowInitParams.shadowResolutionDirectional;
			}

			// Token: 0x0600126E RID: 4718 RVA: 0x0008D2EB File Offset: 0x0008B4EB
			public static BoolScalableSetting UseContactShadow(HDRenderPipelineAsset hdrp)
			{
				return hdrp.currentPlatformRenderPipelineSettings.lightSettings.useContactShadow;
			}
		}

		// Token: 0x02000321 RID: 801
		// (Invoke) Token: 0x06001270 RID: 4720
		public delegate Matrix4x4 CustomViewCallback(Matrix4x4 lightLocalToWorldMatrix);

		// Token: 0x02000322 RID: 802
		private enum Version
		{
			// Token: 0x04002297 RID: 8855
			_Unused00,
			// Token: 0x04002298 RID: 8856
			_Unused01,
			// Token: 0x04002299 RID: 8857
			ShadowNearPlane,
			// Token: 0x0400229A RID: 8858
			LightLayer,
			// Token: 0x0400229B RID: 8859
			ShadowLayer,
			// Token: 0x0400229C RID: 8860
			_Unused02,
			// Token: 0x0400229D RID: 8861
			ShadowResolution,
			// Token: 0x0400229E RID: 8862
			RemoveAdditionalShadowData,
			// Token: 0x0400229F RID: 8863
			AreaLightShapeTypeLogicIsolation,
			// Token: 0x040022A0 RID: 8864
			PCSSUIUpdate,
			// Token: 0x040022A1 RID: 8865
			MoveEmissionMesh,
			// Token: 0x040022A2 RID: 8866
			EnableApplyRangeAttenuationOnBoxLight
		}

		// Token: 0x02000323 RID: 803
		[Obsolete]
		private enum ShadowResolutionTier
		{
			// Token: 0x040022A4 RID: 8868
			Low,
			// Token: 0x040022A5 RID: 8869
			Medium,
			// Token: 0x040022A6 RID: 8870
			High,
			// Token: 0x040022A7 RID: 8871
			VeryHigh
		}

		// Token: 0x02000324 RID: 804
		[Obsolete]
		private enum LightTypeExtent
		{
			// Token: 0x040022A9 RID: 8873
			Punctual,
			// Token: 0x040022AA RID: 8874
			Rectangle,
			// Token: 0x040022AB RID: 8875
			Tube
		}

		// Token: 0x02000325 RID: 805
		internal enum PointLightHDType
		{
			// Token: 0x040022AD RID: 8877
			Punctual,
			// Token: 0x040022AE RID: 8878
			Area
		}
	}
}
