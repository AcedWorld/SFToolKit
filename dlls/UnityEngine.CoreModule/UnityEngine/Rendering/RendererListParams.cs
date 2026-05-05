using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace UnityEngine.Rendering
{
	// Token: 0x02000463 RID: 1123
	public struct RendererListParams : IEquatable<RendererListParams>
	{
		// Token: 0x060025A7 RID: 9639 RVA: 0x00040418 File Offset: 0x0003E618
		public RendererListParams(CullingResults cullingResults, DrawingSettings drawSettings, FilteringSettings filteringSettings)
		{
			this.cullingResults = cullingResults;
			this.drawSettings = drawSettings;
			this.filteringSettings = filteringSettings;
			this.tagName = ShaderTagId.none;
			this.isPassTagName = false;
			this.tagValues = null;
			this.stateBlocks = null;
		}

		// Token: 0x170006DE RID: 1758
		// (get) Token: 0x060025A8 RID: 9640 RVA: 0x00040468 File Offset: 0x0003E668
		internal int numStateBlocks
		{
			get
			{
				bool flag = this.tagValues != null;
				int result;
				if (flag)
				{
					result = this.tagValues.Value.Length;
				}
				else
				{
					result = 0;
				}
				return result;
			}
		}

		// Token: 0x170006DF RID: 1759
		// (get) Token: 0x060025A9 RID: 9641 RVA: 0x000404A0 File Offset: 0x0003E6A0
		internal IntPtr stateBlocksPtr
		{
			get
			{
				bool flag = this.stateBlocks == null;
				IntPtr result;
				if (flag)
				{
					result = IntPtr.Zero;
				}
				else
				{
					result = (IntPtr)this.stateBlocks.Value.GetUnsafeReadOnlyPtr<RenderStateBlock>();
				}
				return result;
			}
		}

		// Token: 0x170006E0 RID: 1760
		// (get) Token: 0x060025AA RID: 9642 RVA: 0x000404E4 File Offset: 0x0003E6E4
		internal IntPtr tagsValuePtr
		{
			get
			{
				bool flag = this.tagValues == null;
				IntPtr result;
				if (flag)
				{
					result = IntPtr.Zero;
				}
				else
				{
					result = (IntPtr)this.tagValues.Value.GetUnsafeReadOnlyPtr<ShaderTagId>();
				}
				return result;
			}
		}

		// Token: 0x060025AB RID: 9643 RVA: 0x00040528 File Offset: 0x0003E728
		internal void Dispose()
		{
			bool flag = this.stateBlocks != null;
			if (flag)
			{
				this.stateBlocks.Value.Dispose();
				this.stateBlocks = null;
			}
			bool flag2 = this.tagValues != null;
			if (flag2)
			{
				this.tagValues.Value.Dispose();
				this.tagValues = null;
			}
		}

		// Token: 0x060025AC RID: 9644 RVA: 0x00040598 File Offset: 0x0003E798
		internal void Validate()
		{
			bool flag = this.tagValues != null && this.stateBlocks != null;
			if (flag)
			{
				bool flag2 = this.tagValues.Value.Length != this.stateBlocks.Value.Length;
				if (flag2)
				{
					throw new ArgumentException(string.Format("Arrays {0} and {1} should have same length, but {2} had length {3} while {4} had length {5}.", new object[]
					{
						"tagValues",
						"stateBlocks",
						"tagValues",
						this.tagValues.Value.Length,
						"stateBlocks",
						this.stateBlocks.Value.Length
					}));
				}
			}
			else
			{
				bool flag3 = (this.tagValues != null && this.stateBlocks == null) || (this.tagValues == null && this.stateBlocks != null);
				if (flag3)
				{
					throw new ArgumentException(string.Format("Arrays {0} and {1} should have same length, but one of them is null ({2} : {3}, {4} : {5}).", new object[]
					{
						"tagValues",
						"stateBlocks",
						"tagValues",
						this.tagValues != null,
						"stateBlocks",
						this.stateBlocks != null
					}));
				}
			}
		}

		// Token: 0x060025AD RID: 9645 RVA: 0x00040708 File Offset: 0x0003E908
		public bool Equals(RendererListParams other)
		{
			return this.cullingResults == other.cullingResults && this.drawSettings == other.drawSettings && this.filteringSettings == other.filteringSettings && this.tagName == other.tagName && this.isPassTagName == other.isPassTagName && this.tagValues == other.tagValues && this.stateBlocks == other.stateBlocks;
		}

		// Token: 0x060025AE RID: 9646 RVA: 0x0004080C File Offset: 0x0003EA0C
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return !flag && obj is RendererListParams && this.Equals((RendererListParams)obj);
		}

		// Token: 0x060025AF RID: 9647 RVA: 0x00040844 File Offset: 0x0003EA44
		public override int GetHashCode()
		{
			int num = this.cullingResults.GetHashCode();
			num = (num * 397 ^ this.drawSettings.GetHashCode());
			num = (num * 397 ^ this.filteringSettings.GetHashCode());
			num = (num * 397 ^ this.tagName.GetHashCode());
			num = (num * 397 ^ (this.isPassTagName ? 0 : 1));
			num = (num * 397 ^ this.tagValues.GetHashCode());
			return num * 397 ^ this.stateBlocks.GetHashCode();
		}

		// Token: 0x060025B0 RID: 9648 RVA: 0x00040904 File Offset: 0x0003EB04
		public static bool operator ==(RendererListParams left, RendererListParams right)
		{
			return left.Equals(right);
		}

		// Token: 0x060025B1 RID: 9649 RVA: 0x00040920 File Offset: 0x0003EB20
		public static bool operator !=(RendererListParams left, RendererListParams right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04000E52 RID: 3666
		public static readonly RendererListParams Invalid = default(RendererListParams);

		// Token: 0x04000E53 RID: 3667
		public CullingResults cullingResults;

		// Token: 0x04000E54 RID: 3668
		public DrawingSettings drawSettings;

		// Token: 0x04000E55 RID: 3669
		public FilteringSettings filteringSettings;

		// Token: 0x04000E56 RID: 3670
		public ShaderTagId tagName;

		// Token: 0x04000E57 RID: 3671
		public bool isPassTagName;

		// Token: 0x04000E58 RID: 3672
		public NativeArray<ShaderTagId>? tagValues;

		// Token: 0x04000E59 RID: 3673
		public NativeArray<RenderStateBlock>? stateBlocks;
	}
}
