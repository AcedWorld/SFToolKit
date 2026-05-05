using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x02000134 RID: 308
	[UsedByNativeCode]
	[NativeHeader("Modules/IMGUI/GUIStyle.h")]
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public class RectOffset : IFormattable
	{
		// Token: 0x06000836 RID: 2102 RVA: 0x0000D8E9 File Offset: 0x0000BAE9
		public RectOffset()
		{
			this.m_Ptr = RectOffset.InternalCreate();
		}

		// Token: 0x06000837 RID: 2103 RVA: 0x0000D8FE File Offset: 0x0000BAFE
		[VisibleToOtherModules(new string[]
		{
			"UnityEngine.IMGUIModule"
		})]
		internal RectOffset(object sourceStyle, IntPtr source)
		{
			this.m_SourceStyle = sourceStyle;
			this.m_Ptr = source;
		}

		// Token: 0x06000838 RID: 2104 RVA: 0x0000D918 File Offset: 0x0000BB18
		protected override void Finalize()
		{
			try
			{
				bool flag = this.m_SourceStyle == null;
				if (flag)
				{
					this.Destroy();
				}
			}
			finally
			{
				base.Finalize();
			}
		}

		// Token: 0x06000839 RID: 2105 RVA: 0x0000D958 File Offset: 0x0000BB58
		public RectOffset(int left, int right, int top, int bottom)
		{
			this.m_Ptr = RectOffset.InternalCreate();
			this.left = left;
			this.right = right;
			this.top = top;
			this.bottom = bottom;
		}

		// Token: 0x0600083A RID: 2106 RVA: 0x0000D990 File Offset: 0x0000BB90
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return this.ToString(null, null);
		}

		// Token: 0x0600083B RID: 2107 RVA: 0x0000D9AC File Offset: 0x0000BBAC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format)
		{
			return this.ToString(format, null);
		}

		// Token: 0x0600083C RID: 2108 RVA: 0x0000D9C8 File Offset: 0x0000BBC8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			bool flag = formatProvider == null;
			if (flag)
			{
				formatProvider = CultureInfo.InvariantCulture.NumberFormat;
			}
			return UnityString.Format("RectOffset (l:{0} r:{1} t:{2} b:{3})", new object[]
			{
				this.left.ToString(format, formatProvider),
				this.right.ToString(format, formatProvider),
				this.top.ToString(format, formatProvider),
				this.bottom.ToString(format, formatProvider)
			});
		}

		// Token: 0x0600083D RID: 2109 RVA: 0x0000DA4C File Offset: 0x0000BC4C
		private void Destroy()
		{
			bool flag = this.m_Ptr != IntPtr.Zero;
			if (flag)
			{
				RectOffset.InternalDestroy(this.m_Ptr);
				this.m_Ptr = IntPtr.Zero;
			}
		}

		// Token: 0x0600083E RID: 2110
		[ThreadAndSerializationSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr InternalCreate();

		// Token: 0x0600083F RID: 2111
		[ThreadAndSerializationSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalDestroy(IntPtr ptr);

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x06000840 RID: 2112
		// (set) Token: 0x06000841 RID: 2113
		[NativeProperty("left", false, TargetType.Field)]
		public extern int left { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x06000842 RID: 2114
		// (set) Token: 0x06000843 RID: 2115
		[NativeProperty("right", false, TargetType.Field)]
		public extern int right { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x06000844 RID: 2116
		// (set) Token: 0x06000845 RID: 2117
		[NativeProperty("top", false, TargetType.Field)]
		public extern int top { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x06000846 RID: 2118
		// (set) Token: 0x06000847 RID: 2119
		[NativeProperty("bottom", false, TargetType.Field)]
		public extern int bottom { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x06000848 RID: 2120
		public extern int horizontal { [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x06000849 RID: 2121
		public extern int vertical { [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x0600084A RID: 2122 RVA: 0x0000DA88 File Offset: 0x0000BC88
		public Rect Add(Rect rect)
		{
			Rect result;
			this.Add_Injected(ref rect, out result);
			return result;
		}

		// Token: 0x0600084B RID: 2123 RVA: 0x0000DAA0 File Offset: 0x0000BCA0
		public Rect Remove(Rect rect)
		{
			Rect result;
			this.Remove_Injected(ref rect, out result);
			return result;
		}

		// Token: 0x0600084C RID: 2124
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Add_Injected(ref Rect rect, out Rect ret);

		// Token: 0x0600084D RID: 2125
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Remove_Injected(ref Rect rect, out Rect ret);

		// Token: 0x040003F8 RID: 1016
		[VisibleToOtherModules(new string[]
		{
			"UnityEngine.IMGUIModule"
		})]
		[NonSerialized]
		internal IntPtr m_Ptr;

		// Token: 0x040003F9 RID: 1017
		private readonly object m_SourceStyle;
	}
}
