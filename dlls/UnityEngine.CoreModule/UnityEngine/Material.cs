using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x02000169 RID: 361
	[NativeHeader("Runtime/Shaders/Material.h")]
	[NativeHeader("Runtime/Graphics/ShaderScriptBindings.h")]
	public class Material : Object
	{
		// Token: 0x06000E25 RID: 3621 RVA: 0x000140F8 File Offset: 0x000122F8
		[Obsolete("Creating materials from shader source string will be removed in the future. Use Shader assets instead.", false)]
		public static Material Create(string scriptContents)
		{
			return new Material(scriptContents);
		}

		// Token: 0x06000E26 RID: 3622
		[FreeFunction("MaterialScripting::CreateWithShader")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CreateWithShader([Writable] Material self, [NotNull("ArgumentNullException")] Shader shader);

		// Token: 0x06000E27 RID: 3623
		[FreeFunction("MaterialScripting::CreateWithMaterial")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CreateWithMaterial([Writable] Material self, [NotNull("ArgumentNullException")] Material source);

		// Token: 0x06000E28 RID: 3624
		[FreeFunction("MaterialScripting::CreateWithString")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CreateWithString([Writable] Material self);

		// Token: 0x06000E29 RID: 3625 RVA: 0x00014110 File Offset: 0x00012310
		public Material(Shader shader)
		{
			Material.CreateWithShader(this, shader);
		}

		// Token: 0x06000E2A RID: 3626 RVA: 0x00014122 File Offset: 0x00012322
		[RequiredByNativeCode]
		public Material(Material source)
		{
			Material.CreateWithMaterial(this, source);
		}

		// Token: 0x06000E2B RID: 3627 RVA: 0x00014134 File Offset: 0x00012334
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Creating materials from shader source string is no longer supported. Use Shader assets instead.", false)]
		public Material(string contents)
		{
			Material.CreateWithString(this);
		}

		// Token: 0x06000E2C RID: 3628
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern Material GetDefaultMaterial();

		// Token: 0x06000E2D RID: 3629
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern Material GetDefaultParticleMaterial();

		// Token: 0x06000E2E RID: 3630
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern Material GetDefaultLineMaterial();

		// Token: 0x170002F3 RID: 755
		// (get) Token: 0x06000E2F RID: 3631
		// (set) Token: 0x06000E30 RID: 3632
		public extern Shader shader { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170002F4 RID: 756
		// (get) Token: 0x06000E31 RID: 3633 RVA: 0x00014148 File Offset: 0x00012348
		// (set) Token: 0x06000E32 RID: 3634 RVA: 0x00014188 File Offset: 0x00012388
		public Color color
		{
			get
			{
				int firstPropertyNameIdByAttribute = this.GetFirstPropertyNameIdByAttribute(ShaderPropertyFlags.MainColor);
				bool flag = firstPropertyNameIdByAttribute >= 0;
				Color color;
				if (flag)
				{
					color = this.GetColor(firstPropertyNameIdByAttribute);
				}
				else
				{
					color = this.GetColor("_Color");
				}
				return color;
			}
			set
			{
				int firstPropertyNameIdByAttribute = this.GetFirstPropertyNameIdByAttribute(ShaderPropertyFlags.MainColor);
				bool flag = firstPropertyNameIdByAttribute >= 0;
				if (flag)
				{
					this.SetColor(firstPropertyNameIdByAttribute, value);
				}
				else
				{
					this.SetColor("_Color", value);
				}
			}
		}

		// Token: 0x170002F5 RID: 757
		// (get) Token: 0x06000E33 RID: 3635 RVA: 0x000141C8 File Offset: 0x000123C8
		// (set) Token: 0x06000E34 RID: 3636 RVA: 0x00014208 File Offset: 0x00012408
		public Texture mainTexture
		{
			get
			{
				int firstPropertyNameIdByAttribute = this.GetFirstPropertyNameIdByAttribute(ShaderPropertyFlags.MainTexture);
				bool flag = firstPropertyNameIdByAttribute >= 0;
				Texture texture;
				if (flag)
				{
					texture = this.GetTexture(firstPropertyNameIdByAttribute);
				}
				else
				{
					texture = this.GetTexture("_MainTex");
				}
				return texture;
			}
			set
			{
				int firstPropertyNameIdByAttribute = this.GetFirstPropertyNameIdByAttribute(ShaderPropertyFlags.MainTexture);
				bool flag = firstPropertyNameIdByAttribute >= 0;
				if (flag)
				{
					this.SetTexture(firstPropertyNameIdByAttribute, value);
				}
				else
				{
					this.SetTexture("_MainTex", value);
				}
			}
		}

		// Token: 0x170002F6 RID: 758
		// (get) Token: 0x06000E35 RID: 3637 RVA: 0x00014248 File Offset: 0x00012448
		// (set) Token: 0x06000E36 RID: 3638 RVA: 0x00014288 File Offset: 0x00012488
		public Vector2 mainTextureOffset
		{
			get
			{
				int firstPropertyNameIdByAttribute = this.GetFirstPropertyNameIdByAttribute(ShaderPropertyFlags.MainTexture);
				bool flag = firstPropertyNameIdByAttribute >= 0;
				Vector2 textureOffset;
				if (flag)
				{
					textureOffset = this.GetTextureOffset(firstPropertyNameIdByAttribute);
				}
				else
				{
					textureOffset = this.GetTextureOffset("_MainTex");
				}
				return textureOffset;
			}
			set
			{
				int firstPropertyNameIdByAttribute = this.GetFirstPropertyNameIdByAttribute(ShaderPropertyFlags.MainTexture);
				bool flag = firstPropertyNameIdByAttribute >= 0;
				if (flag)
				{
					this.SetTextureOffset(firstPropertyNameIdByAttribute, value);
				}
				else
				{
					this.SetTextureOffset("_MainTex", value);
				}
			}
		}

		// Token: 0x170002F7 RID: 759
		// (get) Token: 0x06000E37 RID: 3639 RVA: 0x000142C8 File Offset: 0x000124C8
		// (set) Token: 0x06000E38 RID: 3640 RVA: 0x00014308 File Offset: 0x00012508
		public Vector2 mainTextureScale
		{
			get
			{
				int firstPropertyNameIdByAttribute = this.GetFirstPropertyNameIdByAttribute(ShaderPropertyFlags.MainTexture);
				bool flag = firstPropertyNameIdByAttribute >= 0;
				Vector2 textureScale;
				if (flag)
				{
					textureScale = this.GetTextureScale(firstPropertyNameIdByAttribute);
				}
				else
				{
					textureScale = this.GetTextureScale("_MainTex");
				}
				return textureScale;
			}
			set
			{
				int firstPropertyNameIdByAttribute = this.GetFirstPropertyNameIdByAttribute(ShaderPropertyFlags.MainTexture);
				bool flag = firstPropertyNameIdByAttribute >= 0;
				if (flag)
				{
					this.SetTextureScale(firstPropertyNameIdByAttribute, value);
				}
				else
				{
					this.SetTextureScale("_MainTex", value);
				}
			}
		}

		// Token: 0x06000E39 RID: 3641
		[NativeName("GetFirstPropertyNameIdByAttributeFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int GetFirstPropertyNameIdByAttribute(ShaderPropertyFlags attributeFlag);

		// Token: 0x06000E3A RID: 3642
		[NativeName("HasPropertyFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern bool HasProperty(int nameID);

		// Token: 0x06000E3B RID: 3643 RVA: 0x00014348 File Offset: 0x00012548
		public bool HasProperty(string name)
		{
			return this.HasProperty(Shader.PropertyToID(name));
		}

		// Token: 0x06000E3C RID: 3644
		[NativeName("HasFloatFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool HasFloatImpl(int name);

		// Token: 0x06000E3D RID: 3645 RVA: 0x00014368 File Offset: 0x00012568
		public bool HasFloat(string name)
		{
			return this.HasFloatImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000E3E RID: 3646 RVA: 0x00014388 File Offset: 0x00012588
		public bool HasFloat(int nameID)
		{
			return this.HasFloatImpl(nameID);
		}

		// Token: 0x06000E3F RID: 3647 RVA: 0x000143A4 File Offset: 0x000125A4
		public bool HasInt(string name)
		{
			return this.HasFloatImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000E40 RID: 3648 RVA: 0x000143C4 File Offset: 0x000125C4
		public bool HasInt(int nameID)
		{
			return this.HasFloatImpl(nameID);
		}

		// Token: 0x06000E41 RID: 3649
		[NativeName("HasIntegerFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool HasIntImpl(int name);

		// Token: 0x06000E42 RID: 3650 RVA: 0x000143E0 File Offset: 0x000125E0
		public bool HasInteger(string name)
		{
			return this.HasIntImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000E43 RID: 3651 RVA: 0x00014400 File Offset: 0x00012600
		public bool HasInteger(int nameID)
		{
			return this.HasIntImpl(nameID);
		}

		// Token: 0x06000E44 RID: 3652
		[NativeName("HasTextureFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool HasTextureImpl(int name);

		// Token: 0x06000E45 RID: 3653 RVA: 0x0001441C File Offset: 0x0001261C
		public bool HasTexture(string name)
		{
			return this.HasTextureImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000E46 RID: 3654 RVA: 0x0001443C File Offset: 0x0001263C
		public bool HasTexture(int nameID)
		{
			return this.HasTextureImpl(nameID);
		}

		// Token: 0x06000E47 RID: 3655
		[NativeName("HasMatrixFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool HasMatrixImpl(int name);

		// Token: 0x06000E48 RID: 3656 RVA: 0x00014458 File Offset: 0x00012658
		public bool HasMatrix(string name)
		{
			return this.HasMatrixImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000E49 RID: 3657 RVA: 0x00014478 File Offset: 0x00012678
		public bool HasMatrix(int nameID)
		{
			return this.HasMatrixImpl(nameID);
		}

		// Token: 0x06000E4A RID: 3658
		[NativeName("HasVectorFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool HasVectorImpl(int name);

		// Token: 0x06000E4B RID: 3659 RVA: 0x00014494 File Offset: 0x00012694
		public bool HasVector(string name)
		{
			return this.HasVectorImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000E4C RID: 3660 RVA: 0x000144B4 File Offset: 0x000126B4
		public bool HasVector(int nameID)
		{
			return this.HasVectorImpl(nameID);
		}

		// Token: 0x06000E4D RID: 3661 RVA: 0x000144D0 File Offset: 0x000126D0
		public bool HasColor(string name)
		{
			return this.HasVectorImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000E4E RID: 3662 RVA: 0x000144F0 File Offset: 0x000126F0
		public bool HasColor(int nameID)
		{
			return this.HasVectorImpl(nameID);
		}

		// Token: 0x06000E4F RID: 3663
		[NativeName("HasBufferFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool HasBufferImpl(int name);

		// Token: 0x06000E50 RID: 3664 RVA: 0x0001450C File Offset: 0x0001270C
		public bool HasBuffer(string name)
		{
			return this.HasBufferImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000E51 RID: 3665 RVA: 0x0001452C File Offset: 0x0001272C
		public bool HasBuffer(int nameID)
		{
			return this.HasBufferImpl(nameID);
		}

		// Token: 0x06000E52 RID: 3666
		[NativeName("HasConstantBufferFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool HasConstantBufferImpl(int name);

		// Token: 0x06000E53 RID: 3667 RVA: 0x00014548 File Offset: 0x00012748
		public bool HasConstantBuffer(string name)
		{
			return this.HasConstantBufferImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000E54 RID: 3668 RVA: 0x00014568 File Offset: 0x00012768
		public bool HasConstantBuffer(int nameID)
		{
			return this.HasConstantBufferImpl(nameID);
		}

		// Token: 0x170002F8 RID: 760
		// (get) Token: 0x06000E55 RID: 3669
		// (set) Token: 0x06000E56 RID: 3670
		public extern int renderQueue { [NativeName("GetActualRenderQueue")] [MethodImpl(MethodImplOptions.InternalCall)] get; [NativeName("SetCustomRenderQueue")] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170002F9 RID: 761
		// (get) Token: 0x06000E57 RID: 3671
		internal extern int rawRenderQueue { [NativeName("GetCustomRenderQueue")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06000E58 RID: 3672
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void EnableKeyword(string keyword);

		// Token: 0x06000E59 RID: 3673
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void DisableKeyword(string keyword);

		// Token: 0x06000E5A RID: 3674
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern bool IsKeywordEnabled(string keyword);

		// Token: 0x06000E5B RID: 3675 RVA: 0x00014581 File Offset: 0x00012781
		[FreeFunction("MaterialScripting::EnableKeyword", HasExplicitThis = true)]
		private void EnableLocalKeyword(LocalKeyword keyword)
		{
			this.EnableLocalKeyword_Injected(ref keyword);
		}

		// Token: 0x06000E5C RID: 3676 RVA: 0x0001458B File Offset: 0x0001278B
		[FreeFunction("MaterialScripting::DisableKeyword", HasExplicitThis = true)]
		private void DisableLocalKeyword(LocalKeyword keyword)
		{
			this.DisableLocalKeyword_Injected(ref keyword);
		}

		// Token: 0x06000E5D RID: 3677 RVA: 0x00014595 File Offset: 0x00012795
		[FreeFunction("MaterialScripting::SetKeyword", HasExplicitThis = true)]
		private void SetLocalKeyword(LocalKeyword keyword, bool value)
		{
			this.SetLocalKeyword_Injected(ref keyword, value);
		}

		// Token: 0x06000E5E RID: 3678 RVA: 0x000145A0 File Offset: 0x000127A0
		[FreeFunction("MaterialScripting::IsKeywordEnabled", HasExplicitThis = true)]
		private bool IsLocalKeywordEnabled(LocalKeyword keyword)
		{
			return this.IsLocalKeywordEnabled_Injected(ref keyword);
		}

		// Token: 0x06000E5F RID: 3679 RVA: 0x000145AA File Offset: 0x000127AA
		public void EnableKeyword(in LocalKeyword keyword)
		{
			this.EnableLocalKeyword(keyword);
		}

		// Token: 0x06000E60 RID: 3680 RVA: 0x000145BA File Offset: 0x000127BA
		public void DisableKeyword(in LocalKeyword keyword)
		{
			this.DisableLocalKeyword(keyword);
		}

		// Token: 0x06000E61 RID: 3681 RVA: 0x000145CA File Offset: 0x000127CA
		public void SetKeyword(in LocalKeyword keyword, bool value)
		{
			this.SetLocalKeyword(keyword, value);
		}

		// Token: 0x06000E62 RID: 3682 RVA: 0x000145DC File Offset: 0x000127DC
		public bool IsKeywordEnabled(in LocalKeyword keyword)
		{
			return this.IsLocalKeywordEnabled(keyword);
		}

		// Token: 0x06000E63 RID: 3683
		[FreeFunction("MaterialScripting::GetEnabledKeywords", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern LocalKeyword[] GetEnabledKeywords();

		// Token: 0x06000E64 RID: 3684
		[FreeFunction("MaterialScripting::SetEnabledKeywords", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetEnabledKeywords(LocalKeyword[] keywords);

		// Token: 0x170002FA RID: 762
		// (get) Token: 0x06000E65 RID: 3685 RVA: 0x000145FC File Offset: 0x000127FC
		// (set) Token: 0x06000E66 RID: 3686 RVA: 0x00014614 File Offset: 0x00012814
		public LocalKeyword[] enabledKeywords
		{
			get
			{
				return this.GetEnabledKeywords();
			}
			set
			{
				this.SetEnabledKeywords(value);
			}
		}

		// Token: 0x170002FB RID: 763
		// (get) Token: 0x06000E67 RID: 3687
		// (set) Token: 0x06000E68 RID: 3688
		public extern MaterialGlobalIlluminationFlags globalIlluminationFlags { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170002FC RID: 764
		// (get) Token: 0x06000E69 RID: 3689
		// (set) Token: 0x06000E6A RID: 3690
		public extern bool doubleSidedGI { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170002FD RID: 765
		// (get) Token: 0x06000E6B RID: 3691
		// (set) Token: 0x06000E6C RID: 3692
		[NativeProperty("EnableInstancingVariants")]
		public extern bool enableInstancing { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170002FE RID: 766
		// (get) Token: 0x06000E6D RID: 3693
		public extern int passCount { [NativeName("GetShader()->GetPassCount")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06000E6E RID: 3694
		[FreeFunction("MaterialScripting::SetShaderPassEnabled", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetShaderPassEnabled(string passName, bool enabled);

		// Token: 0x06000E6F RID: 3695
		[FreeFunction("MaterialScripting::GetShaderPassEnabled", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern bool GetShaderPassEnabled(string passName);

		// Token: 0x06000E70 RID: 3696
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern string GetPassName(int pass);

		// Token: 0x06000E71 RID: 3697
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern int FindPass(string passName);

		// Token: 0x06000E72 RID: 3698
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetOverrideTag(string tag, string val);

		// Token: 0x06000E73 RID: 3699
		[NativeName("GetTag")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern string GetTagImpl(string tag, bool currentSubShaderOnly, string defaultValue);

		// Token: 0x06000E74 RID: 3700 RVA: 0x00014620 File Offset: 0x00012820
		public string GetTag(string tag, bool searchFallbacks, string defaultValue)
		{
			return this.GetTagImpl(tag, !searchFallbacks, defaultValue);
		}

		// Token: 0x06000E75 RID: 3701 RVA: 0x00014640 File Offset: 0x00012840
		public string GetTag(string tag, bool searchFallbacks)
		{
			return this.GetTagImpl(tag, !searchFallbacks, "");
		}

		// Token: 0x06000E76 RID: 3702
		[NativeThrows]
		[FreeFunction("MaterialScripting::Lerp", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void Lerp(Material start, Material end, float t);

		// Token: 0x06000E77 RID: 3703
		[FreeFunction("MaterialScripting::SetPass", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern bool SetPass(int pass);

		// Token: 0x06000E78 RID: 3704
		[FreeFunction("MaterialScripting::CopyPropertiesFrom", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void CopyPropertiesFromMaterial(Material mat);

		// Token: 0x06000E79 RID: 3705
		[FreeFunction("MaterialScripting::CopyMatchingPropertiesFrom", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void CopyMatchingPropertiesFromMaterial(Material mat);

		// Token: 0x06000E7A RID: 3706
		[FreeFunction("MaterialScripting::GetShaderKeywords", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern string[] GetShaderKeywords();

		// Token: 0x06000E7B RID: 3707
		[FreeFunction("MaterialScripting::SetShaderKeywords", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetShaderKeywords(string[] names);

		// Token: 0x170002FF RID: 767
		// (get) Token: 0x06000E7C RID: 3708 RVA: 0x00014664 File Offset: 0x00012864
		// (set) Token: 0x06000E7D RID: 3709 RVA: 0x0001467C File Offset: 0x0001287C
		public string[] shaderKeywords
		{
			get
			{
				return this.GetShaderKeywords();
			}
			set
			{
				this.SetShaderKeywords(value);
			}
		}

		// Token: 0x06000E7E RID: 3710
		[FreeFunction("MaterialScripting::GetPropertyNames", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern string[] GetPropertyNamesImpl(int propertyType);

		// Token: 0x06000E7F RID: 3711
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern int ComputeCRC();

		// Token: 0x06000E80 RID: 3712
		[FreeFunction("MaterialScripting::GetTexturePropertyNames", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern string[] GetTexturePropertyNames();

		// Token: 0x06000E81 RID: 3713
		[FreeFunction("MaterialScripting::GetTexturePropertyNameIDs", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern int[] GetTexturePropertyNameIDs();

		// Token: 0x06000E82 RID: 3714
		[FreeFunction("MaterialScripting::GetTexturePropertyNamesInternal", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void GetTexturePropertyNamesInternal(object outNames);

		// Token: 0x06000E83 RID: 3715
		[FreeFunction("MaterialScripting::GetTexturePropertyNameIDsInternal", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void GetTexturePropertyNameIDsInternal(object outNames);

		// Token: 0x06000E84 RID: 3716 RVA: 0x00014688 File Offset: 0x00012888
		public void GetTexturePropertyNames(List<string> outNames)
		{
			bool flag = outNames == null;
			if (flag)
			{
				throw new ArgumentNullException("outNames");
			}
			this.GetTexturePropertyNamesInternal(outNames);
		}

		// Token: 0x06000E85 RID: 3717 RVA: 0x000146B4 File Offset: 0x000128B4
		public void GetTexturePropertyNameIDs(List<int> outNames)
		{
			bool flag = outNames == null;
			if (flag)
			{
				throw new ArgumentNullException("outNames");
			}
			this.GetTexturePropertyNameIDsInternal(outNames);
		}

		// Token: 0x06000E86 RID: 3718
		[NativeName("SetIntFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetIntImpl(int name, int value);

		// Token: 0x06000E87 RID: 3719
		[NativeName("SetFloatFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetFloatImpl(int name, float value);

		// Token: 0x06000E88 RID: 3720 RVA: 0x000146DE File Offset: 0x000128DE
		[NativeName("SetColorFromScript")]
		private void SetColorImpl(int name, Color value)
		{
			this.SetColorImpl_Injected(name, ref value);
		}

		// Token: 0x06000E89 RID: 3721 RVA: 0x000146E9 File Offset: 0x000128E9
		[NativeName("SetMatrixFromScript")]
		private void SetMatrixImpl(int name, Matrix4x4 value)
		{
			this.SetMatrixImpl_Injected(name, ref value);
		}

		// Token: 0x06000E8A RID: 3722
		[NativeName("SetTextureFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetTextureImpl(int name, Texture value);

		// Token: 0x06000E8B RID: 3723
		[NativeName("SetRenderTextureFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetRenderTextureImpl(int name, RenderTexture value, RenderTextureSubElement element);

		// Token: 0x06000E8C RID: 3724
		[NativeName("SetBufferFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetBufferImpl(int name, ComputeBuffer value);

		// Token: 0x06000E8D RID: 3725
		[NativeName("SetBufferFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetGraphicsBufferImpl(int name, GraphicsBuffer value);

		// Token: 0x06000E8E RID: 3726
		[NativeName("SetConstantBufferFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetConstantBufferImpl(int name, ComputeBuffer value, int offset, int size);

		// Token: 0x06000E8F RID: 3727
		[NativeName("SetConstantBufferFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetConstantGraphicsBufferImpl(int name, GraphicsBuffer value, int offset, int size);

		// Token: 0x06000E90 RID: 3728
		[NativeName("GetIntFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int GetIntImpl(int name);

		// Token: 0x06000E91 RID: 3729
		[NativeName("GetFloatFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern float GetFloatImpl(int name);

		// Token: 0x06000E92 RID: 3730 RVA: 0x000146F4 File Offset: 0x000128F4
		[NativeName("GetColorFromScript")]
		private Color GetColorImpl(int name)
		{
			Color result;
			this.GetColorImpl_Injected(name, out result);
			return result;
		}

		// Token: 0x06000E93 RID: 3731 RVA: 0x0001470C File Offset: 0x0001290C
		[NativeName("GetMatrixFromScript")]
		private Matrix4x4 GetMatrixImpl(int name)
		{
			Matrix4x4 result;
			this.GetMatrixImpl_Injected(name, out result);
			return result;
		}

		// Token: 0x06000E94 RID: 3732
		[NativeName("GetTextureFromScript")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern Texture GetTextureImpl(int name);

		// Token: 0x06000E95 RID: 3733 RVA: 0x00014724 File Offset: 0x00012924
		[NativeName("GetBufferFromScript")]
		private GraphicsBufferHandle GetBufferImpl(int name)
		{
			GraphicsBufferHandle result;
			this.GetBufferImpl_Injected(name, out result);
			return result;
		}

		// Token: 0x06000E96 RID: 3734 RVA: 0x0001473C File Offset: 0x0001293C
		[NativeName("GetConstantBufferFromScript")]
		private GraphicsBufferHandle GetConstantBufferImpl(int name)
		{
			GraphicsBufferHandle result;
			this.GetConstantBufferImpl_Injected(name, out result);
			return result;
		}

		// Token: 0x06000E97 RID: 3735
		[FreeFunction(Name = "MaterialScripting::SetFloatArray", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetFloatArrayImpl(int name, float[] values, int count);

		// Token: 0x06000E98 RID: 3736
		[FreeFunction(Name = "MaterialScripting::SetVectorArray", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetVectorArrayImpl(int name, Vector4[] values, int count);

		// Token: 0x06000E99 RID: 3737
		[FreeFunction(Name = "MaterialScripting::SetColorArray", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetColorArrayImpl(int name, Color[] values, int count);

		// Token: 0x06000E9A RID: 3738
		[FreeFunction(Name = "MaterialScripting::SetMatrixArray", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetMatrixArrayImpl(int name, Matrix4x4[] values, int count);

		// Token: 0x06000E9B RID: 3739
		[FreeFunction(Name = "MaterialScripting::GetFloatArray", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern float[] GetFloatArrayImpl(int name);

		// Token: 0x06000E9C RID: 3740
		[FreeFunction(Name = "MaterialScripting::GetVectorArray", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern Vector4[] GetVectorArrayImpl(int name);

		// Token: 0x06000E9D RID: 3741
		[FreeFunction(Name = "MaterialScripting::GetColorArray", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern Color[] GetColorArrayImpl(int name);

		// Token: 0x06000E9E RID: 3742
		[FreeFunction(Name = "MaterialScripting::GetMatrixArray", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern Matrix4x4[] GetMatrixArrayImpl(int name);

		// Token: 0x06000E9F RID: 3743
		[FreeFunction(Name = "MaterialScripting::GetFloatArrayCount", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int GetFloatArrayCountImpl(int name);

		// Token: 0x06000EA0 RID: 3744
		[FreeFunction(Name = "MaterialScripting::GetVectorArrayCount", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int GetVectorArrayCountImpl(int name);

		// Token: 0x06000EA1 RID: 3745
		[FreeFunction(Name = "MaterialScripting::GetColorArrayCount", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int GetColorArrayCountImpl(int name);

		// Token: 0x06000EA2 RID: 3746
		[FreeFunction(Name = "MaterialScripting::GetMatrixArrayCount", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int GetMatrixArrayCountImpl(int name);

		// Token: 0x06000EA3 RID: 3747
		[FreeFunction(Name = "MaterialScripting::ExtractFloatArray", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void ExtractFloatArrayImpl(int name, [Out] float[] val);

		// Token: 0x06000EA4 RID: 3748
		[FreeFunction(Name = "MaterialScripting::ExtractVectorArray", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void ExtractVectorArrayImpl(int name, [Out] Vector4[] val);

		// Token: 0x06000EA5 RID: 3749
		[FreeFunction(Name = "MaterialScripting::ExtractColorArray", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void ExtractColorArrayImpl(int name, [Out] Color[] val);

		// Token: 0x06000EA6 RID: 3750
		[FreeFunction(Name = "MaterialScripting::ExtractMatrixArray", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void ExtractMatrixArrayImpl(int name, [Out] Matrix4x4[] val);

		// Token: 0x06000EA7 RID: 3751 RVA: 0x00014754 File Offset: 0x00012954
		[NativeName("GetTextureScaleAndOffsetFromScript")]
		private Vector4 GetTextureScaleAndOffsetImpl(int name)
		{
			Vector4 result;
			this.GetTextureScaleAndOffsetImpl_Injected(name, out result);
			return result;
		}

		// Token: 0x06000EA8 RID: 3752 RVA: 0x0001476B File Offset: 0x0001296B
		[NativeName("SetTextureOffsetFromScript")]
		private void SetTextureOffsetImpl(int name, Vector2 offset)
		{
			this.SetTextureOffsetImpl_Injected(name, ref offset);
		}

		// Token: 0x06000EA9 RID: 3753 RVA: 0x00014776 File Offset: 0x00012976
		[NativeName("SetTextureScaleFromScript")]
		private void SetTextureScaleImpl(int name, Vector2 scale)
		{
			this.SetTextureScaleImpl_Injected(name, ref scale);
		}

		// Token: 0x06000EAA RID: 3754 RVA: 0x00014784 File Offset: 0x00012984
		private void SetFloatArray(int name, float[] values, int count)
		{
			bool flag = values == null;
			if (flag)
			{
				throw new ArgumentNullException("values");
			}
			bool flag2 = values.Length == 0;
			if (flag2)
			{
				throw new ArgumentException("Zero-sized array is not allowed.");
			}
			bool flag3 = values.Length < count;
			if (flag3)
			{
				throw new ArgumentException("array has less elements than passed count.");
			}
			this.SetFloatArrayImpl(name, values, count);
		}

		// Token: 0x06000EAB RID: 3755 RVA: 0x000147D8 File Offset: 0x000129D8
		private void SetVectorArray(int name, Vector4[] values, int count)
		{
			bool flag = values == null;
			if (flag)
			{
				throw new ArgumentNullException("values");
			}
			bool flag2 = values.Length == 0;
			if (flag2)
			{
				throw new ArgumentException("Zero-sized array is not allowed.");
			}
			bool flag3 = values.Length < count;
			if (flag3)
			{
				throw new ArgumentException("array has less elements than passed count.");
			}
			this.SetVectorArrayImpl(name, values, count);
		}

		// Token: 0x06000EAC RID: 3756 RVA: 0x0001482C File Offset: 0x00012A2C
		private void SetColorArray(int name, Color[] values, int count)
		{
			bool flag = values == null;
			if (flag)
			{
				throw new ArgumentNullException("values");
			}
			bool flag2 = values.Length == 0;
			if (flag2)
			{
				throw new ArgumentException("Zero-sized array is not allowed.");
			}
			bool flag3 = values.Length < count;
			if (flag3)
			{
				throw new ArgumentException("array has less elements than passed count.");
			}
			this.SetColorArrayImpl(name, values, count);
		}

		// Token: 0x06000EAD RID: 3757 RVA: 0x00014880 File Offset: 0x00012A80
		private void SetMatrixArray(int name, Matrix4x4[] values, int count)
		{
			bool flag = values == null;
			if (flag)
			{
				throw new ArgumentNullException("values");
			}
			bool flag2 = values.Length == 0;
			if (flag2)
			{
				throw new ArgumentException("Zero-sized array is not allowed.");
			}
			bool flag3 = values.Length < count;
			if (flag3)
			{
				throw new ArgumentException("array has less elements than passed count.");
			}
			this.SetMatrixArrayImpl(name, values, count);
		}

		// Token: 0x06000EAE RID: 3758 RVA: 0x000148D4 File Offset: 0x00012AD4
		private void ExtractFloatArray(int name, List<float> values)
		{
			bool flag = values == null;
			if (flag)
			{
				throw new ArgumentNullException("values");
			}
			values.Clear();
			int floatArrayCountImpl = this.GetFloatArrayCountImpl(name);
			bool flag2 = floatArrayCountImpl > 0;
			if (flag2)
			{
				NoAllocHelpers.EnsureListElemCount<float>(values, floatArrayCountImpl);
				this.ExtractFloatArrayImpl(name, (float[])NoAllocHelpers.ExtractArrayFromList(values));
			}
		}

		// Token: 0x06000EAF RID: 3759 RVA: 0x0001492C File Offset: 0x00012B2C
		private void ExtractVectorArray(int name, List<Vector4> values)
		{
			bool flag = values == null;
			if (flag)
			{
				throw new ArgumentNullException("values");
			}
			values.Clear();
			int vectorArrayCountImpl = this.GetVectorArrayCountImpl(name);
			bool flag2 = vectorArrayCountImpl > 0;
			if (flag2)
			{
				NoAllocHelpers.EnsureListElemCount<Vector4>(values, vectorArrayCountImpl);
				this.ExtractVectorArrayImpl(name, (Vector4[])NoAllocHelpers.ExtractArrayFromList(values));
			}
		}

		// Token: 0x06000EB0 RID: 3760 RVA: 0x00014984 File Offset: 0x00012B84
		private void ExtractColorArray(int name, List<Color> values)
		{
			bool flag = values == null;
			if (flag)
			{
				throw new ArgumentNullException("values");
			}
			values.Clear();
			int colorArrayCountImpl = this.GetColorArrayCountImpl(name);
			bool flag2 = colorArrayCountImpl > 0;
			if (flag2)
			{
				NoAllocHelpers.EnsureListElemCount<Color>(values, colorArrayCountImpl);
				this.ExtractColorArrayImpl(name, (Color[])NoAllocHelpers.ExtractArrayFromList(values));
			}
		}

		// Token: 0x06000EB1 RID: 3761 RVA: 0x000149DC File Offset: 0x00012BDC
		private void ExtractMatrixArray(int name, List<Matrix4x4> values)
		{
			bool flag = values == null;
			if (flag)
			{
				throw new ArgumentNullException("values");
			}
			values.Clear();
			int matrixArrayCountImpl = this.GetMatrixArrayCountImpl(name);
			bool flag2 = matrixArrayCountImpl > 0;
			if (flag2)
			{
				NoAllocHelpers.EnsureListElemCount<Matrix4x4>(values, matrixArrayCountImpl);
				this.ExtractMatrixArrayImpl(name, (Matrix4x4[])NoAllocHelpers.ExtractArrayFromList(values));
			}
		}

		// Token: 0x06000EB2 RID: 3762 RVA: 0x00014A31 File Offset: 0x00012C31
		public void SetInt(string name, int value)
		{
			this.SetFloatImpl(Shader.PropertyToID(name), (float)value);
		}

		// Token: 0x06000EB3 RID: 3763 RVA: 0x00014A43 File Offset: 0x00012C43
		public void SetInt(int nameID, int value)
		{
			this.SetFloatImpl(nameID, (float)value);
		}

		// Token: 0x06000EB4 RID: 3764 RVA: 0x00014A50 File Offset: 0x00012C50
		public void SetFloat(string name, float value)
		{
			this.SetFloatImpl(Shader.PropertyToID(name), value);
		}

		// Token: 0x06000EB5 RID: 3765 RVA: 0x00014A61 File Offset: 0x00012C61
		public void SetFloat(int nameID, float value)
		{
			this.SetFloatImpl(nameID, value);
		}

		// Token: 0x06000EB6 RID: 3766 RVA: 0x00014A6D File Offset: 0x00012C6D
		public void SetInteger(string name, int value)
		{
			this.SetIntImpl(Shader.PropertyToID(name), value);
		}

		// Token: 0x06000EB7 RID: 3767 RVA: 0x00014A7E File Offset: 0x00012C7E
		public void SetInteger(int nameID, int value)
		{
			this.SetIntImpl(nameID, value);
		}

		// Token: 0x06000EB8 RID: 3768 RVA: 0x00014A8A File Offset: 0x00012C8A
		public void SetColor(string name, Color value)
		{
			this.SetColorImpl(Shader.PropertyToID(name), value);
		}

		// Token: 0x06000EB9 RID: 3769 RVA: 0x00014A9B File Offset: 0x00012C9B
		public void SetColor(int nameID, Color value)
		{
			this.SetColorImpl(nameID, value);
		}

		// Token: 0x06000EBA RID: 3770 RVA: 0x00014AA7 File Offset: 0x00012CA7
		public void SetVector(string name, Vector4 value)
		{
			this.SetColorImpl(Shader.PropertyToID(name), value);
		}

		// Token: 0x06000EBB RID: 3771 RVA: 0x00014ABD File Offset: 0x00012CBD
		public void SetVector(int nameID, Vector4 value)
		{
			this.SetColorImpl(nameID, value);
		}

		// Token: 0x06000EBC RID: 3772 RVA: 0x00014ACE File Offset: 0x00012CCE
		public void SetMatrix(string name, Matrix4x4 value)
		{
			this.SetMatrixImpl(Shader.PropertyToID(name), value);
		}

		// Token: 0x06000EBD RID: 3773 RVA: 0x00014ADF File Offset: 0x00012CDF
		public void SetMatrix(int nameID, Matrix4x4 value)
		{
			this.SetMatrixImpl(nameID, value);
		}

		// Token: 0x06000EBE RID: 3774 RVA: 0x00014AEB File Offset: 0x00012CEB
		public void SetTexture(string name, Texture value)
		{
			this.SetTextureImpl(Shader.PropertyToID(name), value);
		}

		// Token: 0x06000EBF RID: 3775 RVA: 0x00014AFC File Offset: 0x00012CFC
		public void SetTexture(int nameID, Texture value)
		{
			this.SetTextureImpl(nameID, value);
		}

		// Token: 0x06000EC0 RID: 3776 RVA: 0x00014B08 File Offset: 0x00012D08
		public void SetTexture(string name, RenderTexture value, RenderTextureSubElement element)
		{
			this.SetRenderTextureImpl(Shader.PropertyToID(name), value, element);
		}

		// Token: 0x06000EC1 RID: 3777 RVA: 0x00014B1A File Offset: 0x00012D1A
		public void SetTexture(int nameID, RenderTexture value, RenderTextureSubElement element)
		{
			this.SetRenderTextureImpl(nameID, value, element);
		}

		// Token: 0x06000EC2 RID: 3778 RVA: 0x00014B27 File Offset: 0x00012D27
		public void SetBuffer(string name, ComputeBuffer value)
		{
			this.SetBufferImpl(Shader.PropertyToID(name), value);
		}

		// Token: 0x06000EC3 RID: 3779 RVA: 0x00014B38 File Offset: 0x00012D38
		public void SetBuffer(int nameID, ComputeBuffer value)
		{
			this.SetBufferImpl(nameID, value);
		}

		// Token: 0x06000EC4 RID: 3780 RVA: 0x00014B44 File Offset: 0x00012D44
		public void SetBuffer(string name, GraphicsBuffer value)
		{
			this.SetGraphicsBufferImpl(Shader.PropertyToID(name), value);
		}

		// Token: 0x06000EC5 RID: 3781 RVA: 0x00014B55 File Offset: 0x00012D55
		public void SetBuffer(int nameID, GraphicsBuffer value)
		{
			this.SetGraphicsBufferImpl(nameID, value);
		}

		// Token: 0x06000EC6 RID: 3782 RVA: 0x00014B61 File Offset: 0x00012D61
		public void SetConstantBuffer(string name, ComputeBuffer value, int offset, int size)
		{
			this.SetConstantBufferImpl(Shader.PropertyToID(name), value, offset, size);
		}

		// Token: 0x06000EC7 RID: 3783 RVA: 0x00014B75 File Offset: 0x00012D75
		public void SetConstantBuffer(int nameID, ComputeBuffer value, int offset, int size)
		{
			this.SetConstantBufferImpl(nameID, value, offset, size);
		}

		// Token: 0x06000EC8 RID: 3784 RVA: 0x00014B84 File Offset: 0x00012D84
		public void SetConstantBuffer(string name, GraphicsBuffer value, int offset, int size)
		{
			this.SetConstantGraphicsBufferImpl(Shader.PropertyToID(name), value, offset, size);
		}

		// Token: 0x06000EC9 RID: 3785 RVA: 0x00014B98 File Offset: 0x00012D98
		public void SetConstantBuffer(int nameID, GraphicsBuffer value, int offset, int size)
		{
			this.SetConstantGraphicsBufferImpl(nameID, value, offset, size);
		}

		// Token: 0x06000ECA RID: 3786 RVA: 0x00014BA7 File Offset: 0x00012DA7
		public void SetFloatArray(string name, List<float> values)
		{
			this.SetFloatArray(Shader.PropertyToID(name), NoAllocHelpers.ExtractArrayFromListT<float>(values), values.Count);
		}

		// Token: 0x06000ECB RID: 3787 RVA: 0x00014BC3 File Offset: 0x00012DC3
		public void SetFloatArray(int nameID, List<float> values)
		{
			this.SetFloatArray(nameID, NoAllocHelpers.ExtractArrayFromListT<float>(values), values.Count);
		}

		// Token: 0x06000ECC RID: 3788 RVA: 0x00014BDA File Offset: 0x00012DDA
		public void SetFloatArray(string name, float[] values)
		{
			this.SetFloatArray(Shader.PropertyToID(name), values, values.Length);
		}

		// Token: 0x06000ECD RID: 3789 RVA: 0x00014BEE File Offset: 0x00012DEE
		public void SetFloatArray(int nameID, float[] values)
		{
			this.SetFloatArray(nameID, values, values.Length);
		}

		// Token: 0x06000ECE RID: 3790 RVA: 0x00014BFD File Offset: 0x00012DFD
		public void SetColorArray(string name, List<Color> values)
		{
			this.SetColorArray(Shader.PropertyToID(name), NoAllocHelpers.ExtractArrayFromListT<Color>(values), values.Count);
		}

		// Token: 0x06000ECF RID: 3791 RVA: 0x00014C19 File Offset: 0x00012E19
		public void SetColorArray(int nameID, List<Color> values)
		{
			this.SetColorArray(nameID, NoAllocHelpers.ExtractArrayFromListT<Color>(values), values.Count);
		}

		// Token: 0x06000ED0 RID: 3792 RVA: 0x00014C30 File Offset: 0x00012E30
		public void SetColorArray(string name, Color[] values)
		{
			this.SetColorArray(Shader.PropertyToID(name), values, values.Length);
		}

		// Token: 0x06000ED1 RID: 3793 RVA: 0x00014C44 File Offset: 0x00012E44
		public void SetColorArray(int nameID, Color[] values)
		{
			this.SetColorArray(nameID, values, values.Length);
		}

		// Token: 0x06000ED2 RID: 3794 RVA: 0x00014C53 File Offset: 0x00012E53
		public void SetVectorArray(string name, List<Vector4> values)
		{
			this.SetVectorArray(Shader.PropertyToID(name), NoAllocHelpers.ExtractArrayFromListT<Vector4>(values), values.Count);
		}

		// Token: 0x06000ED3 RID: 3795 RVA: 0x00014C6F File Offset: 0x00012E6F
		public void SetVectorArray(int nameID, List<Vector4> values)
		{
			this.SetVectorArray(nameID, NoAllocHelpers.ExtractArrayFromListT<Vector4>(values), values.Count);
		}

		// Token: 0x06000ED4 RID: 3796 RVA: 0x00014C86 File Offset: 0x00012E86
		public void SetVectorArray(string name, Vector4[] values)
		{
			this.SetVectorArray(Shader.PropertyToID(name), values, values.Length);
		}

		// Token: 0x06000ED5 RID: 3797 RVA: 0x00014C9A File Offset: 0x00012E9A
		public void SetVectorArray(int nameID, Vector4[] values)
		{
			this.SetVectorArray(nameID, values, values.Length);
		}

		// Token: 0x06000ED6 RID: 3798 RVA: 0x00014CA9 File Offset: 0x00012EA9
		public void SetMatrixArray(string name, List<Matrix4x4> values)
		{
			this.SetMatrixArray(Shader.PropertyToID(name), NoAllocHelpers.ExtractArrayFromListT<Matrix4x4>(values), values.Count);
		}

		// Token: 0x06000ED7 RID: 3799 RVA: 0x00014CC5 File Offset: 0x00012EC5
		public void SetMatrixArray(int nameID, List<Matrix4x4> values)
		{
			this.SetMatrixArray(nameID, NoAllocHelpers.ExtractArrayFromListT<Matrix4x4>(values), values.Count);
		}

		// Token: 0x06000ED8 RID: 3800 RVA: 0x00014CDC File Offset: 0x00012EDC
		public void SetMatrixArray(string name, Matrix4x4[] values)
		{
			this.SetMatrixArray(Shader.PropertyToID(name), values, values.Length);
		}

		// Token: 0x06000ED9 RID: 3801 RVA: 0x00014CF0 File Offset: 0x00012EF0
		public void SetMatrixArray(int nameID, Matrix4x4[] values)
		{
			this.SetMatrixArray(nameID, values, values.Length);
		}

		// Token: 0x06000EDA RID: 3802 RVA: 0x00014D00 File Offset: 0x00012F00
		public int GetInt(string name)
		{
			return (int)this.GetFloatImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000EDB RID: 3803 RVA: 0x00014D20 File Offset: 0x00012F20
		public int GetInt(int nameID)
		{
			return (int)this.GetFloatImpl(nameID);
		}

		// Token: 0x06000EDC RID: 3804 RVA: 0x00014D3C File Offset: 0x00012F3C
		public float GetFloat(string name)
		{
			return this.GetFloatImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000EDD RID: 3805 RVA: 0x00014D5C File Offset: 0x00012F5C
		public float GetFloat(int nameID)
		{
			return this.GetFloatImpl(nameID);
		}

		// Token: 0x06000EDE RID: 3806 RVA: 0x00014D78 File Offset: 0x00012F78
		public int GetInteger(string name)
		{
			return this.GetIntImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000EDF RID: 3807 RVA: 0x00014D98 File Offset: 0x00012F98
		public int GetInteger(int nameID)
		{
			return this.GetIntImpl(nameID);
		}

		// Token: 0x06000EE0 RID: 3808 RVA: 0x00014DB4 File Offset: 0x00012FB4
		public Color GetColor(string name)
		{
			return this.GetColorImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000EE1 RID: 3809 RVA: 0x00014DD4 File Offset: 0x00012FD4
		public Color GetColor(int nameID)
		{
			return this.GetColorImpl(nameID);
		}

		// Token: 0x06000EE2 RID: 3810 RVA: 0x00014DF0 File Offset: 0x00012FF0
		public Vector4 GetVector(string name)
		{
			return this.GetColorImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000EE3 RID: 3811 RVA: 0x00014E14 File Offset: 0x00013014
		public Vector4 GetVector(int nameID)
		{
			return this.GetColorImpl(nameID);
		}

		// Token: 0x06000EE4 RID: 3812 RVA: 0x00014E34 File Offset: 0x00013034
		public Matrix4x4 GetMatrix(string name)
		{
			return this.GetMatrixImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000EE5 RID: 3813 RVA: 0x00014E54 File Offset: 0x00013054
		public Matrix4x4 GetMatrix(int nameID)
		{
			return this.GetMatrixImpl(nameID);
		}

		// Token: 0x06000EE6 RID: 3814 RVA: 0x00014E70 File Offset: 0x00013070
		public Texture GetTexture(string name)
		{
			return this.GetTextureImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000EE7 RID: 3815 RVA: 0x00014E90 File Offset: 0x00013090
		public Texture GetTexture(int nameID)
		{
			return this.GetTextureImpl(nameID);
		}

		// Token: 0x06000EE8 RID: 3816 RVA: 0x00014EAC File Offset: 0x000130AC
		public GraphicsBufferHandle GetBuffer(string name)
		{
			return this.GetBufferImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000EE9 RID: 3817 RVA: 0x00014ECC File Offset: 0x000130CC
		public GraphicsBufferHandle GetConstantBuffer(string name)
		{
			return this.GetConstantBufferImpl(Shader.PropertyToID(name));
		}

		// Token: 0x06000EEA RID: 3818 RVA: 0x00014EEC File Offset: 0x000130EC
		public float[] GetFloatArray(string name)
		{
			return this.GetFloatArray(Shader.PropertyToID(name));
		}

		// Token: 0x06000EEB RID: 3819 RVA: 0x00014F0C File Offset: 0x0001310C
		public float[] GetFloatArray(int nameID)
		{
			return (this.GetFloatArrayCountImpl(nameID) != 0) ? this.GetFloatArrayImpl(nameID) : null;
		}

		// Token: 0x06000EEC RID: 3820 RVA: 0x00014F34 File Offset: 0x00013134
		public Color[] GetColorArray(string name)
		{
			return this.GetColorArray(Shader.PropertyToID(name));
		}

		// Token: 0x06000EED RID: 3821 RVA: 0x00014F54 File Offset: 0x00013154
		public Color[] GetColorArray(int nameID)
		{
			return (this.GetColorArrayCountImpl(nameID) != 0) ? this.GetColorArrayImpl(nameID) : null;
		}

		// Token: 0x06000EEE RID: 3822 RVA: 0x00014F7C File Offset: 0x0001317C
		public Vector4[] GetVectorArray(string name)
		{
			return this.GetVectorArray(Shader.PropertyToID(name));
		}

		// Token: 0x06000EEF RID: 3823 RVA: 0x00014F9C File Offset: 0x0001319C
		public Vector4[] GetVectorArray(int nameID)
		{
			return (this.GetVectorArrayCountImpl(nameID) != 0) ? this.GetVectorArrayImpl(nameID) : null;
		}

		// Token: 0x06000EF0 RID: 3824 RVA: 0x00014FC4 File Offset: 0x000131C4
		public Matrix4x4[] GetMatrixArray(string name)
		{
			return this.GetMatrixArray(Shader.PropertyToID(name));
		}

		// Token: 0x06000EF1 RID: 3825 RVA: 0x00014FE4 File Offset: 0x000131E4
		public Matrix4x4[] GetMatrixArray(int nameID)
		{
			return (this.GetMatrixArrayCountImpl(nameID) != 0) ? this.GetMatrixArrayImpl(nameID) : null;
		}

		// Token: 0x06000EF2 RID: 3826 RVA: 0x00015009 File Offset: 0x00013209
		public void GetFloatArray(string name, List<float> values)
		{
			this.ExtractFloatArray(Shader.PropertyToID(name), values);
		}

		// Token: 0x06000EF3 RID: 3827 RVA: 0x0001501A File Offset: 0x0001321A
		public void GetFloatArray(int nameID, List<float> values)
		{
			this.ExtractFloatArray(nameID, values);
		}

		// Token: 0x06000EF4 RID: 3828 RVA: 0x00015026 File Offset: 0x00013226
		public void GetColorArray(string name, List<Color> values)
		{
			this.ExtractColorArray(Shader.PropertyToID(name), values);
		}

		// Token: 0x06000EF5 RID: 3829 RVA: 0x00015037 File Offset: 0x00013237
		public void GetColorArray(int nameID, List<Color> values)
		{
			this.ExtractColorArray(nameID, values);
		}

		// Token: 0x06000EF6 RID: 3830 RVA: 0x00015043 File Offset: 0x00013243
		public void GetVectorArray(string name, List<Vector4> values)
		{
			this.ExtractVectorArray(Shader.PropertyToID(name), values);
		}

		// Token: 0x06000EF7 RID: 3831 RVA: 0x00015054 File Offset: 0x00013254
		public void GetVectorArray(int nameID, List<Vector4> values)
		{
			this.ExtractVectorArray(nameID, values);
		}

		// Token: 0x06000EF8 RID: 3832 RVA: 0x00015060 File Offset: 0x00013260
		public void GetMatrixArray(string name, List<Matrix4x4> values)
		{
			this.ExtractMatrixArray(Shader.PropertyToID(name), values);
		}

		// Token: 0x06000EF9 RID: 3833 RVA: 0x00015071 File Offset: 0x00013271
		public void GetMatrixArray(int nameID, List<Matrix4x4> values)
		{
			this.ExtractMatrixArray(nameID, values);
		}

		// Token: 0x06000EFA RID: 3834 RVA: 0x0001507D File Offset: 0x0001327D
		public void SetTextureOffset(string name, Vector2 value)
		{
			this.SetTextureOffsetImpl(Shader.PropertyToID(name), value);
		}

		// Token: 0x06000EFB RID: 3835 RVA: 0x0001508E File Offset: 0x0001328E
		public void SetTextureOffset(int nameID, Vector2 value)
		{
			this.SetTextureOffsetImpl(nameID, value);
		}

		// Token: 0x06000EFC RID: 3836 RVA: 0x0001509A File Offset: 0x0001329A
		public void SetTextureScale(string name, Vector2 value)
		{
			this.SetTextureScaleImpl(Shader.PropertyToID(name), value);
		}

		// Token: 0x06000EFD RID: 3837 RVA: 0x000150AB File Offset: 0x000132AB
		public void SetTextureScale(int nameID, Vector2 value)
		{
			this.SetTextureScaleImpl(nameID, value);
		}

		// Token: 0x06000EFE RID: 3838 RVA: 0x000150B8 File Offset: 0x000132B8
		public Vector2 GetTextureOffset(string name)
		{
			return this.GetTextureOffset(Shader.PropertyToID(name));
		}

		// Token: 0x06000EFF RID: 3839 RVA: 0x000150D8 File Offset: 0x000132D8
		public Vector2 GetTextureOffset(int nameID)
		{
			Vector4 textureScaleAndOffsetImpl = this.GetTextureScaleAndOffsetImpl(nameID);
			return new Vector2(textureScaleAndOffsetImpl.z, textureScaleAndOffsetImpl.w);
		}

		// Token: 0x06000F00 RID: 3840 RVA: 0x00015104 File Offset: 0x00013304
		public Vector2 GetTextureScale(string name)
		{
			return this.GetTextureScale(Shader.PropertyToID(name));
		}

		// Token: 0x06000F01 RID: 3841 RVA: 0x00015124 File Offset: 0x00013324
		public Vector2 GetTextureScale(int nameID)
		{
			Vector4 textureScaleAndOffsetImpl = this.GetTextureScaleAndOffsetImpl(nameID);
			return new Vector2(textureScaleAndOffsetImpl.x, textureScaleAndOffsetImpl.y);
		}

		// Token: 0x06000F02 RID: 3842 RVA: 0x00015150 File Offset: 0x00013350
		public string[] GetPropertyNames(MaterialPropertyType type)
		{
			return this.GetPropertyNamesImpl((int)type);
		}

		// Token: 0x06000F03 RID: 3843
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void EnableLocalKeyword_Injected(ref LocalKeyword keyword);

		// Token: 0x06000F04 RID: 3844
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void DisableLocalKeyword_Injected(ref LocalKeyword keyword);

		// Token: 0x06000F05 RID: 3845
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetLocalKeyword_Injected(ref LocalKeyword keyword, bool value);

		// Token: 0x06000F06 RID: 3846
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool IsLocalKeywordEnabled_Injected(ref LocalKeyword keyword);

		// Token: 0x06000F07 RID: 3847
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetColorImpl_Injected(int name, ref Color value);

		// Token: 0x06000F08 RID: 3848
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetMatrixImpl_Injected(int name, ref Matrix4x4 value);

		// Token: 0x06000F09 RID: 3849
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void GetColorImpl_Injected(int name, out Color ret);

		// Token: 0x06000F0A RID: 3850
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void GetMatrixImpl_Injected(int name, out Matrix4x4 ret);

		// Token: 0x06000F0B RID: 3851
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void GetBufferImpl_Injected(int name, out GraphicsBufferHandle ret);

		// Token: 0x06000F0C RID: 3852
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void GetConstantBufferImpl_Injected(int name, out GraphicsBufferHandle ret);

		// Token: 0x06000F0D RID: 3853
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void GetTextureScaleAndOffsetImpl_Injected(int name, out Vector4 ret);

		// Token: 0x06000F0E RID: 3854
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetTextureOffsetImpl_Injected(int name, ref Vector2 offset);

		// Token: 0x06000F0F RID: 3855
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetTextureScaleImpl_Injected(int name, ref Vector2 scale);
	}
}
