using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityModManagerNet.Injection;

namespace UnityEngine
{
	// Token: 0x02000009 RID: 9
	[NativeHeader("Modules/UI/UIStructs.h")]
	[NativeHeader("Modules/UI/Canvas.h")]
	[NativeHeader("Modules/UI/CanvasManager.h")]
	[NativeClass("UI::Canvas")]
	[RequireComponent(typeof(RectTransform))]
	public sealed class Canvas : Behaviour
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000055 RID: 85 RVA: 0x00002A50 File Offset: 0x00000C50
		// (remove) Token: 0x06000056 RID: 86 RVA: 0x00002A84 File Offset: 0x00000C84
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Canvas.WillRenderCanvases preWillRenderCanvases;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000057 RID: 87 RVA: 0x00002AB8 File Offset: 0x00000CB8
		// (remove) Token: 0x06000058 RID: 88 RVA: 0x00002AEC File Offset: 0x00000CEC
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Canvas.WillRenderCanvases willRenderCanvases;

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000059 RID: 89
		// (set) Token: 0x0600005A RID: 90
		public extern RenderMode renderMode { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600005B RID: 91
		public extern bool isRootCanvas { [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00002B20 File Offset: 0x00000D20
		public Rect pixelRect
		{
			get
			{
				Rect result;
				this.get_pixelRect_Injected(out result);
				return result;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600005D RID: 93
		// (set) Token: 0x0600005E RID: 94
		public extern float scaleFactor { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600005F RID: 95
		// (set) Token: 0x06000060 RID: 96
		public extern float referencePixelsPerUnit { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000061 RID: 97
		// (set) Token: 0x06000062 RID: 98
		public extern bool overridePixelPerfect { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000063 RID: 99
		// (set) Token: 0x06000064 RID: 100
		public extern bool vertexColorAlwaysGammaSpace { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000065 RID: 101
		// (set) Token: 0x06000066 RID: 102
		public extern bool pixelPerfect { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000067 RID: 103
		// (set) Token: 0x06000068 RID: 104
		public extern float planeDistance { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000069 RID: 105
		public extern int renderOrder { [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600006A RID: 106
		// (set) Token: 0x0600006B RID: 107
		public extern bool overrideSorting { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600006C RID: 108
		// (set) Token: 0x0600006D RID: 109
		public extern int sortingOrder { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600006E RID: 110
		// (set) Token: 0x0600006F RID: 111
		public extern int targetDisplay { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000070 RID: 112
		// (set) Token: 0x06000071 RID: 113
		public extern int sortingLayerID { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000072 RID: 114
		public extern int cachedSortingLayerValue { [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000073 RID: 115
		// (set) Token: 0x06000074 RID: 116
		public extern AdditionalCanvasShaderChannels additionalShaderChannels { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000075 RID: 117
		// (set) Token: 0x06000076 RID: 118
		public extern string sortingLayerName { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000077 RID: 119
		public extern Canvas rootCanvas { [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000078 RID: 120 RVA: 0x00002B38 File Offset: 0x00000D38
		public Vector2 renderingDisplaySize
		{
			get
			{
				Vector2 result;
				this.get_renderingDisplaySize_Injected(out result);
				return result;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000079 RID: 121
		// (set) Token: 0x0600007A RID: 122
		public extern StandaloneRenderResize updateRectTransformForStandalone { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600007B RID: 123 RVA: 0x000020F2 File Offset: 0x000002F2
		// (set) Token: 0x0600007C RID: 124 RVA: 0x000020F9 File Offset: 0x000002F9
		internal static Action<int> externBeginRenderOverlays { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600007D RID: 125 RVA: 0x00002101 File Offset: 0x00000301
		// (set) Token: 0x0600007E RID: 126 RVA: 0x00002108 File Offset: 0x00000308
		internal static Action<int, int> externRenderOverlaysBefore { get; set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600007F RID: 127 RVA: 0x00002110 File Offset: 0x00000310
		// (set) Token: 0x06000080 RID: 128 RVA: 0x00002117 File Offset: 0x00000317
		internal static Action<int> externEndRenderOverlays { get; set; }

		// Token: 0x06000081 RID: 129
		[FreeFunction("UI::CanvasManager::SetExternalCanvasEnabled")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void SetExternalCanvasEnabled(bool enabled);

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000082 RID: 130
		// (set) Token: 0x06000083 RID: 131
		[NativeProperty("Camera", false, TargetType.Function)]
		public extern Camera worldCamera { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000084 RID: 132
		// (set) Token: 0x06000085 RID: 133
		[NativeProperty("SortingBucketNormalizedSize", false, TargetType.Function)]
		public extern float normalizedSortingGridSize { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000086 RID: 134
		// (set) Token: 0x06000087 RID: 135
		[NativeProperty("SortingBucketNormalizedSize", false, TargetType.Function)]
		[Obsolete("Setting normalizedSize via a int is not supported. Please use normalizedSortingGridSize", false)]
		public extern int sortingGridNormalizedSize { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x06000088 RID: 136
		[FreeFunction("UI::GetDefaultUIMaterial")]
		[Obsolete("Shared default material now used for text and general UI elements, call Canvas.GetDefaultCanvasMaterial()", false)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern Material GetDefaultCanvasTextMaterial();

		// Token: 0x06000089 RID: 137
		[FreeFunction("UI::GetDefaultUIMaterial")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern Material GetDefaultCanvasMaterial();

		// Token: 0x0600008A RID: 138
		[FreeFunction("UI::GetETC1SupportedCanvasMaterial")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern Material GetETC1SupportedCanvasMaterial();

		// Token: 0x0600008B RID: 139
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern void UpdateCanvasRectTransform(bool alignWithCamera);

		// Token: 0x0600008C RID: 140 RVA: 0x0000211F File Offset: 0x0000031F
		public static void ForceUpdateCanvases()
		{
			Canvas.SendPreWillRenderCanvases();
			Canvas.SendWillRenderCanvases();
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000212E File Offset: 0x0000032E
		[RequiredByNativeCode]
		private static void SendPreWillRenderCanvases()
		{
			Canvas.WillRenderCanvases willRenderCanvases = Canvas.preWillRenderCanvases;
			if (willRenderCanvases != null)
			{
				willRenderCanvases();
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00002142 File Offset: 0x00000342
		[RequiredByNativeCode]
		private static void SendWillRenderCanvases()
		{
			Canvas.WillRenderCanvases willRenderCanvases = Canvas.willRenderCanvases;
			if (willRenderCanvases != null)
			{
				willRenderCanvases();
			}
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00002156 File Offset: 0x00000356
		[RequiredByNativeCode]
		private static void BeginRenderExtraOverlays(int displayIndex)
		{
			Action<int> externBeginRenderOverlays = Canvas.externBeginRenderOverlays;
			if (externBeginRenderOverlays != null)
			{
				externBeginRenderOverlays(displayIndex);
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0000216B File Offset: 0x0000036B
		[RequiredByNativeCode]
		private static void RenderExtraOverlaysBefore(int displayIndex, int sortingOrder)
		{
			Action<int, int> externRenderOverlaysBefore = Canvas.externRenderOverlaysBefore;
			if (externRenderOverlaysBefore != null)
			{
				externRenderOverlaysBefore(displayIndex, sortingOrder);
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00002181 File Offset: 0x00000381
		[RequiredByNativeCode]
		private static void EndRenderExtraOverlays(int displayIndex)
		{
			Action<int> externEndRenderOverlays = Canvas.externEndRenderOverlays;
			if (externEndRenderOverlays != null)
			{
				externEndRenderOverlays(displayIndex);
			}
		}

		// Token: 0x06000093 RID: 147
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void get_pixelRect_Injected(out Rect ret);

		// Token: 0x06000094 RID: 148
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void get_renderingDisplaySize_Injected(out Vector2 ret);

		// Token: 0x06000095 RID: 149 RVA: 0x00002196 File Offset: 0x00000396
		// Note: this type is marked as 'beforefieldinit'.
		static Canvas()
		{
			UnityModManagerStarter.Start();
		}

		// Token: 0x0200000A RID: 10
		// (Invoke) Token: 0x06000097 RID: 151
		public delegate void WillRenderCanvases();
	}
}
