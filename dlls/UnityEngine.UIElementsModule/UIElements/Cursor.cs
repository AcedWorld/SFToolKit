using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x02000153 RID: 339
	public struct Cursor : IEquatable<Cursor>
	{
		// Token: 0x17000218 RID: 536
		// (get) Token: 0x06000AF2 RID: 2802 RVA: 0x0002C15B File Offset: 0x0002A35B
		// (set) Token: 0x06000AF3 RID: 2803 RVA: 0x0002C163 File Offset: 0x0002A363
		public Texture2D texture { readonly get; set; }

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x06000AF4 RID: 2804 RVA: 0x0002C16C File Offset: 0x0002A36C
		// (set) Token: 0x06000AF5 RID: 2805 RVA: 0x0002C174 File Offset: 0x0002A374
		public Vector2 hotspot { readonly get; set; }

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x06000AF6 RID: 2806 RVA: 0x0002C17D File Offset: 0x0002A37D
		// (set) Token: 0x06000AF7 RID: 2807 RVA: 0x0002C185 File Offset: 0x0002A385
		internal int defaultCursorId { readonly get; set; }

		// Token: 0x06000AF8 RID: 2808 RVA: 0x0002C190 File Offset: 0x0002A390
		public override bool Equals(object obj)
		{
			return obj is Cursor && this.Equals((Cursor)obj);
		}

		// Token: 0x06000AF9 RID: 2809 RVA: 0x0002C1BC File Offset: 0x0002A3BC
		public bool Equals(Cursor other)
		{
			return EqualityComparer<Texture2D>.Default.Equals(this.texture, other.texture) && this.hotspot.Equals(other.hotspot) && this.defaultCursorId == other.defaultCursorId;
		}

		// Token: 0x06000AFA RID: 2810 RVA: 0x0002C210 File Offset: 0x0002A410
		public override int GetHashCode()
		{
			int num = 1500536833;
			num = num * -1521134295 + EqualityComparer<Texture2D>.Default.GetHashCode(this.texture);
			num = num * -1521134295 + EqualityComparer<Vector2>.Default.GetHashCode(this.hotspot);
			return num * -1521134295 + this.defaultCursorId.GetHashCode();
		}

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x06000AFB RID: 2811 RVA: 0x0002C274 File Offset: 0x0002A474
		internal static IEnumerable<Type> allowedAssetTypes
		{
			get
			{
				yield return typeof(Texture2D);
				yield break;
			}
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x0002C28C File Offset: 0x0002A48C
		public static bool operator ==(Cursor style1, Cursor style2)
		{
			return style1.Equals(style2);
		}

		// Token: 0x06000AFD RID: 2813 RVA: 0x0002C2A8 File Offset: 0x0002A4A8
		public static bool operator !=(Cursor style1, Cursor style2)
		{
			return !(style1 == style2);
		}

		// Token: 0x06000AFE RID: 2814 RVA: 0x0002C2C4 File Offset: 0x0002A4C4
		public override string ToString()
		{
			return string.Format("texture={0}, hotspot={1}", this.texture, this.hotspot);
		}
	}
}
