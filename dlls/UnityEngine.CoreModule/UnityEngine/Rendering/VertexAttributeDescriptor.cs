using System;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering
{
	// Token: 0x02000407 RID: 1031
	[UsedByNativeCode]
	public struct VertexAttributeDescriptor : IEquatable<VertexAttributeDescriptor>
	{
		// Token: 0x1700065F RID: 1631
		// (get) Token: 0x060021B9 RID: 8633 RVA: 0x0003812C File Offset: 0x0003632C
		// (set) Token: 0x060021BA RID: 8634 RVA: 0x00038134 File Offset: 0x00036334
		public VertexAttribute attribute { readonly get; set; }

		// Token: 0x17000660 RID: 1632
		// (get) Token: 0x060021BB RID: 8635 RVA: 0x0003813D File Offset: 0x0003633D
		// (set) Token: 0x060021BC RID: 8636 RVA: 0x00038145 File Offset: 0x00036345
		public VertexAttributeFormat format { readonly get; set; }

		// Token: 0x17000661 RID: 1633
		// (get) Token: 0x060021BD RID: 8637 RVA: 0x0003814E File Offset: 0x0003634E
		// (set) Token: 0x060021BE RID: 8638 RVA: 0x00038156 File Offset: 0x00036356
		public int dimension { readonly get; set; }

		// Token: 0x17000662 RID: 1634
		// (get) Token: 0x060021BF RID: 8639 RVA: 0x0003815F File Offset: 0x0003635F
		// (set) Token: 0x060021C0 RID: 8640 RVA: 0x00038167 File Offset: 0x00036367
		public int stream { readonly get; set; }

		// Token: 0x060021C1 RID: 8641 RVA: 0x00038170 File Offset: 0x00036370
		public VertexAttributeDescriptor(VertexAttribute attribute = VertexAttribute.Position, VertexAttributeFormat format = VertexAttributeFormat.Float32, int dimension = 3, int stream = 0)
		{
			this.attribute = attribute;
			this.format = format;
			this.dimension = dimension;
			this.stream = stream;
		}

		// Token: 0x060021C2 RID: 8642 RVA: 0x00038194 File Offset: 0x00036394
		public override string ToString()
		{
			return string.Format("(attr={0} fmt={1} dim={2} stream={3})", new object[]
			{
				this.attribute,
				this.format,
				this.dimension,
				this.stream
			});
		}

		// Token: 0x060021C3 RID: 8643 RVA: 0x000381F0 File Offset: 0x000363F0
		public override int GetHashCode()
		{
			int num = 17;
			num = (int)(num * 23 + this.attribute);
			num = (int)(num * 23 + this.format);
			num = num * 23 + this.dimension;
			return num * 23 + this.stream;
		}

		// Token: 0x060021C4 RID: 8644 RVA: 0x00038238 File Offset: 0x00036438
		public override bool Equals(object other)
		{
			bool flag = !(other is VertexAttributeDescriptor);
			return !flag && this.Equals((VertexAttributeDescriptor)other);
		}

		// Token: 0x060021C5 RID: 8645 RVA: 0x0003826C File Offset: 0x0003646C
		public bool Equals(VertexAttributeDescriptor other)
		{
			return this.attribute == other.attribute && this.format == other.format && this.dimension == other.dimension && this.stream == other.stream;
		}

		// Token: 0x060021C6 RID: 8646 RVA: 0x000382C0 File Offset: 0x000364C0
		public static bool operator ==(VertexAttributeDescriptor lhs, VertexAttributeDescriptor rhs)
		{
			return lhs.Equals(rhs);
		}

		// Token: 0x060021C7 RID: 8647 RVA: 0x000382DC File Offset: 0x000364DC
		public static bool operator !=(VertexAttributeDescriptor lhs, VertexAttributeDescriptor rhs)
		{
			return !lhs.Equals(rhs);
		}
	}
}
