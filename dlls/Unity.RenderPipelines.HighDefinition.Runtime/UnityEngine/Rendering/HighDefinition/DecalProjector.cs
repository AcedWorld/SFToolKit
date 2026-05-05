using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000F9 RID: 249
	[ExecuteAlways]
	[AddComponentMenu("Rendering/HDRP Decal Projector")]
	public class DecalProjector : MonoBehaviour, IVersionable<DecalProjector.Version>
	{
		// Token: 0x1700015B RID: 347
		// (get) Token: 0x06000992 RID: 2450 RVA: 0x00054262 File Offset: 0x00052462
		// (set) Token: 0x06000993 RID: 2451 RVA: 0x0005426A File Offset: 0x0005246A
		public Material material
		{
			get
			{
				return this.m_Material;
			}
			set
			{
				this.m_Material = value;
				this.OnValidate();
			}
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x06000994 RID: 2452 RVA: 0x00054279 File Offset: 0x00052479
		// (set) Token: 0x06000995 RID: 2453 RVA: 0x00054281 File Offset: 0x00052481
		public float drawDistance
		{
			get
			{
				return this.m_DrawDistance;
			}
			set
			{
				this.m_DrawDistance = Mathf.Max(0f, value);
				this.OnValidate();
			}
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x06000996 RID: 2454 RVA: 0x0005429A File Offset: 0x0005249A
		// (set) Token: 0x06000997 RID: 2455 RVA: 0x000542A2 File Offset: 0x000524A2
		public float fadeScale
		{
			get
			{
				return this.m_FadeScale;
			}
			set
			{
				this.m_FadeScale = Mathf.Clamp01(value);
				this.OnValidate();
			}
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06000998 RID: 2456 RVA: 0x000542B6 File Offset: 0x000524B6
		// (set) Token: 0x06000999 RID: 2457 RVA: 0x000542BE File Offset: 0x000524BE
		public float startAngleFade
		{
			get
			{
				return this.m_StartAngleFade;
			}
			set
			{
				this.m_StartAngleFade = Mathf.Clamp(value, 0f, 180f);
				this.OnValidate();
			}
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x0600099A RID: 2458 RVA: 0x000542DC File Offset: 0x000524DC
		// (set) Token: 0x0600099B RID: 2459 RVA: 0x000542E4 File Offset: 0x000524E4
		public float endAngleFade
		{
			get
			{
				return this.m_EndAngleFade;
			}
			set
			{
				this.m_EndAngleFade = Mathf.Clamp(value, this.m_StartAngleFade, 180f);
				this.OnValidate();
			}
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x0600099C RID: 2460 RVA: 0x00054303 File Offset: 0x00052503
		// (set) Token: 0x0600099D RID: 2461 RVA: 0x0005430B File Offset: 0x0005250B
		public Vector2 uvScale
		{
			get
			{
				return this.m_UVScale;
			}
			set
			{
				this.m_UVScale = value;
				this.OnValidate();
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x0600099E RID: 2462 RVA: 0x0005431A File Offset: 0x0005251A
		// (set) Token: 0x0600099F RID: 2463 RVA: 0x00054322 File Offset: 0x00052522
		public Vector2 uvBias
		{
			get
			{
				return this.m_UVBias;
			}
			set
			{
				this.m_UVBias = value;
				this.OnValidate();
			}
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x060009A0 RID: 2464 RVA: 0x00054331 File Offset: 0x00052531
		// (set) Token: 0x060009A1 RID: 2465 RVA: 0x00054339 File Offset: 0x00052539
		public bool affectsTransparency
		{
			get
			{
				return this.m_AffectsTransparency;
			}
			set
			{
				this.m_AffectsTransparency = value;
				this.OnValidate();
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x060009A2 RID: 2466 RVA: 0x00054348 File Offset: 0x00052548
		// (set) Token: 0x060009A3 RID: 2467 RVA: 0x00054350 File Offset: 0x00052550
		public DecalLayerEnum decalLayerMask
		{
			get
			{
				return this.m_DecalLayerMask;
			}
			set
			{
				this.m_DecalLayerMask = value;
			}
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x060009A4 RID: 2468 RVA: 0x00054359 File Offset: 0x00052559
		// (set) Token: 0x060009A5 RID: 2469 RVA: 0x00054361 File Offset: 0x00052561
		public DecalScaleMode scaleMode
		{
			get
			{
				return this.m_ScaleMode;
			}
			set
			{
				this.m_ScaleMode = value;
				this.OnValidate();
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x060009A6 RID: 2470 RVA: 0x00054370 File Offset: 0x00052570
		// (set) Token: 0x060009A7 RID: 2471 RVA: 0x00054378 File Offset: 0x00052578
		public Vector3 pivot
		{
			get
			{
				return this.m_Offset;
			}
			set
			{
				this.m_Offset = value;
				this.OnValidate();
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x060009A8 RID: 2472 RVA: 0x00054387 File Offset: 0x00052587
		// (set) Token: 0x060009A9 RID: 2473 RVA: 0x0005438F File Offset: 0x0005258F
		public Vector3 size
		{
			get
			{
				return this.m_Size;
			}
			set
			{
				this.m_Size = value;
				this.OnValidate();
			}
		}

		// Token: 0x060009AA RID: 2474 RVA: 0x000543A0 File Offset: 0x000525A0
		public void ResizeAroundPivot(Vector3 newSize)
		{
			for (int i = 0; i < 3; i++)
			{
				if (this.m_Size[i] > Mathf.Epsilon)
				{
					ref Vector3 ptr = ref this.m_Offset;
					int index = i;
					ptr[index] *= newSize[i] / this.m_Size[i];
				}
			}
			this.size = newSize;
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x060009AB RID: 2475 RVA: 0x00054400 File Offset: 0x00052600
		// (set) Token: 0x060009AC RID: 2476 RVA: 0x00054408 File Offset: 0x00052608
		public float fadeFactor
		{
			get
			{
				return this.m_FadeFactor;
			}
			set
			{
				this.m_FadeFactor = Mathf.Clamp01(value);
				this.OnValidate();
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x060009AD RID: 2477 RVA: 0x0005441C File Offset: 0x0005261C
		internal Vector3 effectiveScale
		{
			get
			{
				if (this.m_ScaleMode != DecalScaleMode.InheritFromHierarchy)
				{
					return Vector3.one;
				}
				return base.transform.lossyScale;
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x060009AE RID: 2478 RVA: 0x00054438 File Offset: 0x00052638
		internal Vector3 position
		{
			get
			{
				return base.transform.position;
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x060009AF RID: 2479 RVA: 0x00054445 File Offset: 0x00052645
		internal Vector4 uvScaleBias
		{
			get
			{
				return new Vector4(this.m_UVScale.x, this.m_UVScale.y, this.m_UVBias.x, this.m_UVBias.y);
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x060009B0 RID: 2480 RVA: 0x00054478 File Offset: 0x00052678
		// (set) Token: 0x060009B1 RID: 2481 RVA: 0x00054480 File Offset: 0x00052680
		internal DecalSystem.DecalHandle Handle
		{
			get
			{
				return this.m_Handle;
			}
			set
			{
				this.m_Handle = value;
			}
		}

		// Token: 0x060009B2 RID: 2482 RVA: 0x0005448C File Offset: 0x0005268C
		internal DecalProjector.CachedDecalData GetCachedDecalData()
		{
			return new DecalProjector.CachedDecalData
			{
				drawDistance = this.m_DrawDistance,
				fadeScale = this.m_FadeScale,
				startAngleFade = this.m_StartAngleFade,
				endAngleFade = this.m_EndAngleFade,
				uvScaleBias = this.uvScaleBias,
				affectsTransparency = this.m_AffectsTransparency,
				layerMask = base.gameObject.layer,
				sceneLayerMask = base.gameObject.sceneCullingMask,
				fadeFactor = this.m_FadeFactor,
				decalLayerMask = this.decalLayerMask
			};
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x0005452E File Offset: 0x0005272E
		private void InitMaterial()
		{
			if (this.m_Material == null)
			{
				this.m_Material = null;
			}
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x00054545 File Offset: 0x00052745
		private void Reset()
		{
			this.InitMaterial();
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x00054550 File Offset: 0x00052750
		private void OnEnable()
		{
			this.InitMaterial();
			if (this.m_Handle != null)
			{
				DecalSystem.instance.RemoveDecal(this.m_Handle);
				this.m_Handle = null;
			}
			this.m_Handle = DecalSystem.instance.AddDecal(this);
			this.m_OldMaterial = this.m_Material;
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x0005459F File Offset: 0x0005279F
		private void OnDisable()
		{
			if (this.m_Handle != null)
			{
				DecalSystem.instance.RemoveDecal(this.m_Handle);
				this.m_Handle = null;
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x060009B7 RID: 2487 RVA: 0x000545C0 File Offset: 0x000527C0
		// (remove) Token: 0x060009B8 RID: 2488 RVA: 0x000545F8 File Offset: 0x000527F8
		public event Action OnMaterialChange;

		// Token: 0x060009B9 RID: 2489 RVA: 0x00054630 File Offset: 0x00052830
		internal void OnValidate()
		{
			if (this.m_Handle != null)
			{
				if (this.m_Material == null)
				{
					DecalSystem.instance.RemoveDecal(this.m_Handle);
				}
				if (this.m_OldMaterial != this.m_Material)
				{
					DecalSystem.instance.RemoveDecal(this.m_Handle);
					if (this.m_Material != null)
					{
						this.m_Handle = DecalSystem.instance.AddDecal(this);
						if (!DecalSystem.IsHDRenderPipelineDecal(this.m_Material.shader))
						{
							this.m_AffectsTransparency = false;
						}
					}
					if (this.OnMaterialChange != null)
					{
						this.OnMaterialChange();
					}
					this.m_OldMaterial = this.m_Material;
					return;
				}
				DecalSystem.instance.UpdateCachedData(this.m_Handle, this);
			}
		}

		// Token: 0x060009BA RID: 2490 RVA: 0x000546F2 File Offset: 0x000528F2
		public bool IsValid()
		{
			return !(this.m_Material == null);
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x060009BB RID: 2491 RVA: 0x00054705 File Offset: 0x00052905
		// (set) Token: 0x060009BC RID: 2492 RVA: 0x0005470D File Offset: 0x0005290D
		DecalProjector.Version IVersionable<DecalProjector.Version>.version
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

		// Token: 0x060009BD RID: 2493 RVA: 0x00054718 File Offset: 0x00052918
		private void Awake()
		{
			DecalProjector.k_Migration.Migrate(this);
		}

		// Token: 0x04000A78 RID: 2680
		[SerializeField]
		private Material m_Material;

		// Token: 0x04000A79 RID: 2681
		[SerializeField]
		private float m_DrawDistance = 1000f;

		// Token: 0x04000A7A RID: 2682
		[SerializeField]
		[Range(0f, 1f)]
		private float m_FadeScale = 0.9f;

		// Token: 0x04000A7B RID: 2683
		[SerializeField]
		[Range(0f, 180f)]
		private float m_StartAngleFade = 180f;

		// Token: 0x04000A7C RID: 2684
		[SerializeField]
		[Range(0f, 180f)]
		private float m_EndAngleFade = 180f;

		// Token: 0x04000A7D RID: 2685
		[SerializeField]
		private Vector2 m_UVScale = new Vector2(1f, 1f);

		// Token: 0x04000A7E RID: 2686
		[SerializeField]
		private Vector2 m_UVBias = new Vector2(0f, 0f);

		// Token: 0x04000A7F RID: 2687
		[SerializeField]
		private bool m_AffectsTransparency;

		// Token: 0x04000A80 RID: 2688
		[SerializeField]
		private DecalLayerEnum m_DecalLayerMask = DecalLayerEnum.DecalLayerDefault;

		// Token: 0x04000A81 RID: 2689
		[SerializeField]
		private DecalScaleMode m_ScaleMode;

		// Token: 0x04000A82 RID: 2690
		[SerializeField]
		internal Vector3 m_Offset = new Vector3(0f, 0f, 0f);

		// Token: 0x04000A83 RID: 2691
		[SerializeField]
		internal Vector3 m_Size = new Vector3(1f, 1f, 1f);

		// Token: 0x04000A84 RID: 2692
		[SerializeField]
		[Range(0f, 1f)]
		private float m_FadeFactor = 1f;

		// Token: 0x04000A85 RID: 2693
		private Material m_OldMaterial;

		// Token: 0x04000A86 RID: 2694
		private DecalSystem.DecalHandle m_Handle;

		// Token: 0x04000A88 RID: 2696
		private static readonly MigrationDescription<DecalProjector.Version, DecalProjector> k_Migration = MigrationDescription.New<DecalProjector.Version, DecalProjector>(new MigrationStep<DecalProjector.Version, DecalProjector>[]
		{
			MigrationStep.New<DecalProjector.Version, DecalProjector>(DecalProjector.Version.UseZProjectionAxisAndScaleIndependance, delegate(DecalProjector decal)
			{
				decal.m_Size.Scale(decal.transform.lossyScale);
				decal.transform.RotateAround(decal.transform.position, decal.transform.right, 90f);
				foreach (object obj in decal.transform)
				{
					((Transform)obj).RotateAround(decal.transform.position, decal.transform.right, -90f);
				}
				float z = decal.m_Size.y;
				decal.m_Size.y = decal.m_Size.z;
				decal.m_Size.z = z;
				z = -decal.m_Offset.y * decal.transform.lossyScale.y;
				decal.m_Offset.y = decal.m_Offset.z * decal.transform.lossyScale.z;
				decal.m_Offset.z = z;
				decal.m_Offset.x = decal.m_Offset.x * decal.transform.lossyScale.x;
				if (decal.m_Handle != null)
				{
					DecalSystem.instance.RemoveDecal(decal.m_Handle);
				}
				decal.m_Handle = DecalSystem.instance.AddDecal(decal);
			}),
			MigrationStep.New<DecalProjector.Version, DecalProjector>(DecalProjector.Version.FixPivotPosition, delegate(DecalProjector decal)
			{
				Vector3 vector = decal.m_Offset - new Vector3(0f, 0f, decal.m_Size.z * 0.5f);
				decal.transform.Translate(vector);
				decal.m_Offset.x = 0f;
				decal.m_Offset.y = 0f;
				decal.m_Offset.z = decal.m_Size.z * 0.5f;
				Transform parent = decal.transform.parent;
				if (parent != null)
				{
					vector.x *= parent.transform.lossyScale.x;
					vector.y *= parent.transform.lossyScale.y;
					vector.z *= parent.transform.lossyScale.z;
					vector = decal.transform.rotation * -vector;
				}
				foreach (object obj in decal.transform)
				{
					((Transform)obj).Translate(vector, Space.World);
				}
				if (decal.m_Handle != null)
				{
					DecalSystem.instance.RemoveDecal(decal.m_Handle);
				}
				decal.m_Handle = DecalSystem.instance.AddDecal(decal);
			})
		});

		// Token: 0x04000A89 RID: 2697
		[SerializeField]
		private DecalProjector.Version m_Version = MigrationDescription.LastVersion<DecalProjector.Version>();

		// Token: 0x02000378 RID: 888
		internal struct CachedDecalData
		{
			// Token: 0x0400241B RID: 9243
			public float drawDistance;

			// Token: 0x0400241C RID: 9244
			public float fadeScale;

			// Token: 0x0400241D RID: 9245
			public float startAngleFade;

			// Token: 0x0400241E RID: 9246
			public float endAngleFade;

			// Token: 0x0400241F RID: 9247
			public Vector4 uvScaleBias;

			// Token: 0x04002420 RID: 9248
			public bool affectsTransparency;

			// Token: 0x04002421 RID: 9249
			public int layerMask;

			// Token: 0x04002422 RID: 9250
			public ulong sceneLayerMask;

			// Token: 0x04002423 RID: 9251
			public float fadeFactor;

			// Token: 0x04002424 RID: 9252
			public DecalLayerEnum decalLayerMask;
		}

		// Token: 0x02000379 RID: 889
		private enum Version
		{
			// Token: 0x04002426 RID: 9254
			Initial,
			// Token: 0x04002427 RID: 9255
			UseZProjectionAxisAndScaleIndependance,
			// Token: 0x04002428 RID: 9256
			FixPivotPosition
		}
	}
}
