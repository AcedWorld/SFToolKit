using System;
using UnityEngine;

namespace TMPro
{
	// Token: 0x02000059 RID: 89
	[RequireComponent(typeof(MeshRenderer))]
	[ExecuteAlways]
	public class TMP_SubMesh : MonoBehaviour
	{
		// Token: 0x170000DC RID: 220
		// (get) Token: 0x060003DC RID: 988 RVA: 0x00026C15 File Offset: 0x00024E15
		// (set) Token: 0x060003DD RID: 989 RVA: 0x00026C1D File Offset: 0x00024E1D
		public TMP_FontAsset fontAsset
		{
			get
			{
				return this.m_fontAsset;
			}
			set
			{
				this.m_fontAsset = value;
			}
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060003DE RID: 990 RVA: 0x00026C26 File Offset: 0x00024E26
		// (set) Token: 0x060003DF RID: 991 RVA: 0x00026C2E File Offset: 0x00024E2E
		public TMP_SpriteAsset spriteAsset
		{
			get
			{
				return this.m_spriteAsset;
			}
			set
			{
				this.m_spriteAsset = value;
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x060003E0 RID: 992 RVA: 0x00026C37 File Offset: 0x00024E37
		// (set) Token: 0x060003E1 RID: 993 RVA: 0x00026C48 File Offset: 0x00024E48
		public Material material
		{
			get
			{
				return this.GetMaterial(this.m_sharedMaterial);
			}
			set
			{
				if (this.m_sharedMaterial.GetInstanceID() == value.GetInstanceID())
				{
					return;
				}
				this.m_material = value;
				this.m_sharedMaterial = value;
				this.m_padding = this.GetPaddingForMaterial();
				this.SetVerticesDirty();
				this.SetMaterialDirty();
			}
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x060003E2 RID: 994 RVA: 0x00026C91 File Offset: 0x00024E91
		// (set) Token: 0x060003E3 RID: 995 RVA: 0x00026C99 File Offset: 0x00024E99
		public Material sharedMaterial
		{
			get
			{
				return this.m_sharedMaterial;
			}
			set
			{
				this.SetSharedMaterial(value);
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x060003E4 RID: 996 RVA: 0x00026CA2 File Offset: 0x00024EA2
		// (set) Token: 0x060003E5 RID: 997 RVA: 0x00026CAC File Offset: 0x00024EAC
		public Material fallbackMaterial
		{
			get
			{
				return this.m_fallbackMaterial;
			}
			set
			{
				if (this.m_fallbackMaterial == value)
				{
					return;
				}
				if (this.m_fallbackMaterial != null && this.m_fallbackMaterial != value)
				{
					TMP_MaterialManager.ReleaseFallbackMaterial(this.m_fallbackMaterial);
				}
				this.m_fallbackMaterial = value;
				TMP_MaterialManager.AddFallbackMaterialReference(this.m_fallbackMaterial);
				this.SetSharedMaterial(this.m_fallbackMaterial);
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060003E6 RID: 998 RVA: 0x00026D0D File Offset: 0x00024F0D
		// (set) Token: 0x060003E7 RID: 999 RVA: 0x00026D15 File Offset: 0x00024F15
		public Material fallbackSourceMaterial
		{
			get
			{
				return this.m_fallbackSourceMaterial;
			}
			set
			{
				this.m_fallbackSourceMaterial = value;
			}
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060003E8 RID: 1000 RVA: 0x00026D1E File Offset: 0x00024F1E
		// (set) Token: 0x060003E9 RID: 1001 RVA: 0x00026D26 File Offset: 0x00024F26
		public bool isDefaultMaterial
		{
			get
			{
				return this.m_isDefaultMaterial;
			}
			set
			{
				this.m_isDefaultMaterial = value;
			}
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060003EA RID: 1002 RVA: 0x00026D2F File Offset: 0x00024F2F
		// (set) Token: 0x060003EB RID: 1003 RVA: 0x00026D37 File Offset: 0x00024F37
		public float padding
		{
			get
			{
				return this.m_padding;
			}
			set
			{
				this.m_padding = value;
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060003EC RID: 1004 RVA: 0x00026D40 File Offset: 0x00024F40
		public Renderer renderer
		{
			get
			{
				if (this.m_renderer == null)
				{
					this.m_renderer = base.GetComponent<Renderer>();
				}
				return this.m_renderer;
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060003ED RID: 1005 RVA: 0x00026D64 File Offset: 0x00024F64
		public MeshFilter meshFilter
		{
			get
			{
				if (this.m_meshFilter == null)
				{
					this.m_meshFilter = base.GetComponent<MeshFilter>();
					if (this.m_meshFilter == null)
					{
						this.m_meshFilter = base.gameObject.AddComponent<MeshFilter>();
						this.m_meshFilter.hideFlags = (HideFlags.HideInHierarchy | HideFlags.HideInInspector | HideFlags.DontSaveInEditor | HideFlags.NotEditable | HideFlags.DontSaveInBuild | HideFlags.DontUnloadUnusedAsset);
					}
				}
				return this.m_meshFilter;
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060003EE RID: 1006 RVA: 0x00026DBD File Offset: 0x00024FBD
		// (set) Token: 0x060003EF RID: 1007 RVA: 0x00026DEB File Offset: 0x00024FEB
		public Mesh mesh
		{
			get
			{
				if (this.m_mesh == null)
				{
					this.m_mesh = new Mesh();
					this.m_mesh.hideFlags = HideFlags.HideAndDontSave;
				}
				return this.m_mesh;
			}
			set
			{
				this.m_mesh = value;
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060003F0 RID: 1008 RVA: 0x00026DF4 File Offset: 0x00024FF4
		public TMP_Text textComponent
		{
			get
			{
				if (this.m_TextComponent == null)
				{
					this.m_TextComponent = base.GetComponentInParent<TextMeshPro>();
				}
				return this.m_TextComponent;
			}
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x00026E18 File Offset: 0x00025018
		public static TMP_SubMesh AddSubTextObject(TextMeshPro textComponent, MaterialReference materialReference)
		{
			GameObject gameObject = new GameObject("TMP SubMesh [" + materialReference.material.name + "]", new Type[]
			{
				typeof(TMP_SubMesh)
			});
			gameObject.hideFlags = HideFlags.DontSave;
			TMP_SubMesh component = gameObject.GetComponent<TMP_SubMesh>();
			gameObject.transform.SetParent(textComponent.transform, false);
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.transform.localScale = Vector3.one;
			gameObject.layer = textComponent.gameObject.layer;
			component.m_TextComponent = textComponent;
			component.m_fontAsset = materialReference.fontAsset;
			component.m_spriteAsset = materialReference.spriteAsset;
			component.m_isDefaultMaterial = materialReference.isDefaultMaterial;
			component.SetSharedMaterial(materialReference.material);
			component.renderer.sortingLayerID = textComponent.renderer.sortingLayerID;
			component.renderer.sortingOrder = textComponent.renderer.sortingOrder;
			return component;
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x00026F1C File Offset: 0x0002511C
		private void OnEnable()
		{
			if (!this.m_isRegisteredForEvents)
			{
				this.m_isRegisteredForEvents = true;
			}
			if (base.hideFlags != HideFlags.DontSave)
			{
				base.hideFlags = HideFlags.DontSave;
			}
			this.meshFilter.sharedMesh = this.mesh;
			if (this.m_sharedMaterial != null)
			{
				this.m_sharedMaterial.SetVector(ShaderUtilities.ID_ClipRect, new Vector4(-32767f, -32767f, 32767f, 32767f));
			}
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x00026F92 File Offset: 0x00025192
		private void OnDisable()
		{
			this.m_meshFilter.sharedMesh = null;
			if (this.m_fallbackMaterial != null)
			{
				TMP_MaterialManager.ReleaseFallbackMaterial(this.m_fallbackMaterial);
				this.m_fallbackMaterial = null;
			}
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x00026FC0 File Offset: 0x000251C0
		private void OnDestroy()
		{
			if (this.m_mesh != null)
			{
				Object.DestroyImmediate(this.m_mesh);
			}
			if (this.m_fallbackMaterial != null)
			{
				TMP_MaterialManager.ReleaseFallbackMaterial(this.m_fallbackMaterial);
				this.m_fallbackMaterial = null;
			}
			this.m_isRegisteredForEvents = false;
			if (this.m_TextComponent != null)
			{
				this.m_TextComponent.havePropertiesChanged = true;
				this.m_TextComponent.SetAllDirty();
			}
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x00027032 File Offset: 0x00025232
		public void DestroySelf()
		{
			Object.Destroy(base.gameObject, 1f);
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x00027044 File Offset: 0x00025244
		private Material GetMaterial(Material mat)
		{
			if (this.m_renderer == null)
			{
				this.m_renderer = base.GetComponent<Renderer>();
			}
			if (this.m_material == null || this.m_material.GetInstanceID() != mat.GetInstanceID())
			{
				this.m_material = this.CreateMaterialInstance(mat);
			}
			this.m_sharedMaterial = this.m_material;
			this.m_padding = this.GetPaddingForMaterial();
			this.SetVerticesDirty();
			this.SetMaterialDirty();
			return this.m_sharedMaterial;
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x000270C3 File Offset: 0x000252C3
		private Material CreateMaterialInstance(Material source)
		{
			Material material = new Material(source);
			material.shaderKeywords = source.shaderKeywords;
			material.name += " (Instance)";
			return material;
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x000270ED File Offset: 0x000252ED
		private Material GetSharedMaterial()
		{
			if (this.m_renderer == null)
			{
				this.m_renderer = base.GetComponent<Renderer>();
			}
			return this.m_renderer.sharedMaterial;
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x00027114 File Offset: 0x00025314
		private void SetSharedMaterial(Material mat)
		{
			this.m_sharedMaterial = mat;
			this.m_padding = this.GetPaddingForMaterial();
			this.SetMaterialDirty();
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x0002712F File Offset: 0x0002532F
		public float GetPaddingForMaterial()
		{
			return ShaderUtilities.GetPadding(this.m_sharedMaterial, this.m_TextComponent.extraPadding, this.m_TextComponent.isUsingBold);
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x00027152 File Offset: 0x00025352
		public void UpdateMeshPadding(bool isExtraPadding, bool isUsingBold)
		{
			this.m_padding = ShaderUtilities.GetPadding(this.m_sharedMaterial, isExtraPadding, isUsingBold);
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x00027167 File Offset: 0x00025367
		public void SetVerticesDirty()
		{
			if (!base.enabled)
			{
				return;
			}
			if (this.m_TextComponent != null)
			{
				this.m_TextComponent.havePropertiesChanged = true;
				this.m_TextComponent.SetVerticesDirty();
			}
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x00027197 File Offset: 0x00025397
		public void SetMaterialDirty()
		{
			this.UpdateMaterial();
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x000271A0 File Offset: 0x000253A0
		protected void UpdateMaterial()
		{
			if (this.renderer == null || this.m_sharedMaterial == null)
			{
				return;
			}
			this.m_renderer.sharedMaterial = this.m_sharedMaterial;
			if (this.m_sharedMaterial.HasProperty(ShaderUtilities.ShaderTag_CullMode))
			{
				float @float = this.textComponent.fontSharedMaterial.GetFloat(ShaderUtilities.ShaderTag_CullMode);
				this.m_sharedMaterial.SetFloat(ShaderUtilities.ShaderTag_CullMode, @float);
			}
		}

		// Token: 0x040003B5 RID: 949
		[SerializeField]
		private TMP_FontAsset m_fontAsset;

		// Token: 0x040003B6 RID: 950
		[SerializeField]
		private TMP_SpriteAsset m_spriteAsset;

		// Token: 0x040003B7 RID: 951
		[SerializeField]
		private Material m_material;

		// Token: 0x040003B8 RID: 952
		[SerializeField]
		private Material m_sharedMaterial;

		// Token: 0x040003B9 RID: 953
		private Material m_fallbackMaterial;

		// Token: 0x040003BA RID: 954
		private Material m_fallbackSourceMaterial;

		// Token: 0x040003BB RID: 955
		[SerializeField]
		private bool m_isDefaultMaterial;

		// Token: 0x040003BC RID: 956
		[SerializeField]
		private float m_padding;

		// Token: 0x040003BD RID: 957
		[SerializeField]
		private Renderer m_renderer;

		// Token: 0x040003BE RID: 958
		private MeshFilter m_meshFilter;

		// Token: 0x040003BF RID: 959
		private Mesh m_mesh;

		// Token: 0x040003C0 RID: 960
		[SerializeField]
		private TextMeshPro m_TextComponent;

		// Token: 0x040003C1 RID: 961
		[NonSerialized]
		private bool m_isRegisteredForEvents;
	}
}
