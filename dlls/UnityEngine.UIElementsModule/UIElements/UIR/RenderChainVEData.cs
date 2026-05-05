using System;
using System.Runtime.CompilerServices;
using UnityEngine.UIElements.UIR.Implementation;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x0200045D RID: 1117
	internal struct RenderChainVEData
	{
		// Token: 0x170007EE RID: 2030
		// (get) Token: 0x060022ED RID: 8941 RVA: 0x000877B0 File Offset: 0x000859B0
		internal RenderChainCommand lastClosingOrLastCommand
		{
			get
			{
				return this.lastClosingCommand ?? this.lastCommand;
			}
		}

		// Token: 0x060022EE RID: 8942 RVA: 0x000877D4 File Offset: 0x000859D4
		internal static bool AllocatesID(BMPAlloc alloc)
		{
			return alloc.ownedState == OwnedState.Owned && alloc.IsValid();
		}

		// Token: 0x060022EF RID: 8943 RVA: 0x000877FC File Offset: 0x000859FC
		internal static bool InheritsID(BMPAlloc alloc)
		{
			return alloc.ownedState == OwnedState.Inherited && alloc.IsValid();
		}

		// Token: 0x170007EF RID: 2031
		// (get) Token: 0x060022F0 RID: 8944 RVA: 0x00087820 File Offset: 0x00085A20
		public bool isIgnoringDynamicColorHint
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return (this.flags & RenderDataFlags.IsIgnoringDynamicColorHint) == RenderDataFlags.IsIgnoringDynamicColorHint;
			}
		}

		// Token: 0x04000FEA RID: 4074
		internal VisualElement prev;

		// Token: 0x04000FEB RID: 4075
		internal VisualElement next;

		// Token: 0x04000FEC RID: 4076
		internal VisualElement groupTransformAncestor;

		// Token: 0x04000FED RID: 4077
		internal VisualElement boneTransformAncestor;

		// Token: 0x04000FEE RID: 4078
		internal VisualElement prevDirty;

		// Token: 0x04000FEF RID: 4079
		internal VisualElement nextDirty;

		// Token: 0x04000FF0 RID: 4080
		internal RenderDataFlags flags;

		// Token: 0x04000FF1 RID: 4081
		internal int hierarchyDepth;

		// Token: 0x04000FF2 RID: 4082
		internal RenderDataDirtyTypes dirtiedValues;

		// Token: 0x04000FF3 RID: 4083
		internal uint dirtyID;

		// Token: 0x04000FF4 RID: 4084
		internal RenderChainCommand firstCommand;

		// Token: 0x04000FF5 RID: 4085
		internal RenderChainCommand lastCommand;

		// Token: 0x04000FF6 RID: 4086
		internal RenderChainCommand firstClosingCommand;

		// Token: 0x04000FF7 RID: 4087
		internal RenderChainCommand lastClosingCommand;

		// Token: 0x04000FF8 RID: 4088
		internal bool isInChain;

		// Token: 0x04000FF9 RID: 4089
		internal bool isHierarchyHidden;

		// Token: 0x04000FFA RID: 4090
		internal bool localFlipsWinding;

		// Token: 0x04000FFB RID: 4091
		internal bool localTransformScaleZero;

		// Token: 0x04000FFC RID: 4092
		internal bool worldFlipsWinding;

		// Token: 0x04000FFD RID: 4093
		public bool worldTransformScaleZero;

		// Token: 0x04000FFE RID: 4094
		internal ClipMethod clipMethod;

		// Token: 0x04000FFF RID: 4095
		internal int childrenStencilRef;

		// Token: 0x04001000 RID: 4096
		internal int childrenMaskDepth;

		// Token: 0x04001001 RID: 4097
		internal bool disableNudging;

		// Token: 0x04001002 RID: 4098
		internal MeshHandle data;

		// Token: 0x04001003 RID: 4099
		internal MeshHandle closingData;

		// Token: 0x04001004 RID: 4100
		internal Matrix4x4 verticesSpace;

		// Token: 0x04001005 RID: 4101
		internal int displacementUVStart;

		// Token: 0x04001006 RID: 4102
		internal int displacementUVEnd;

		// Token: 0x04001007 RID: 4103
		internal BMPAlloc transformID;

		// Token: 0x04001008 RID: 4104
		internal BMPAlloc clipRectID;

		// Token: 0x04001009 RID: 4105
		internal BMPAlloc opacityID;

		// Token: 0x0400100A RID: 4106
		internal BMPAlloc textCoreSettingsID;

		// Token: 0x0400100B RID: 4107
		internal BMPAlloc colorID;

		// Token: 0x0400100C RID: 4108
		internal BMPAlloc backgroundColorID;

		// Token: 0x0400100D RID: 4109
		internal BMPAlloc borderLeftColorID;

		// Token: 0x0400100E RID: 4110
		internal BMPAlloc borderTopColorID;

		// Token: 0x0400100F RID: 4111
		internal BMPAlloc borderRightColorID;

		// Token: 0x04001010 RID: 4112
		internal BMPAlloc borderBottomColorID;

		// Token: 0x04001011 RID: 4113
		internal BMPAlloc tintColorID;

		// Token: 0x04001012 RID: 4114
		internal float compositeOpacity;

		// Token: 0x04001013 RID: 4115
		internal Color backgroundColor;

		// Token: 0x04001014 RID: 4116
		internal BasicNode<TextureEntry> textures;
	}
}
