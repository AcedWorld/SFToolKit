using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000040 RID: 64
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
	public sealed class InspectorTextAreaAttribute : Attribute
	{
		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060001D9 RID: 473 RVA: 0x00004EC4 File Offset: 0x000030C4
		// (set) Token: 0x060001DA RID: 474 RVA: 0x00004ED1 File Offset: 0x000030D1
		public float minLines
		{
			get
			{
				return this._minLines.GetValueOrDefault();
			}
			set
			{
				this._minLines = new float?(value);
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060001DB RID: 475 RVA: 0x00004EDF File Offset: 0x000030DF
		public bool hasMinLines
		{
			get
			{
				return this._minLines != null;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060001DC RID: 476 RVA: 0x00004EEC File Offset: 0x000030EC
		// (set) Token: 0x060001DD RID: 477 RVA: 0x00004EF9 File Offset: 0x000030F9
		public float maxLines
		{
			get
			{
				return this._maxLines.GetValueOrDefault();
			}
			set
			{
				this._maxLines = new float?(value);
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060001DE RID: 478 RVA: 0x00004F07 File Offset: 0x00003107
		public bool hasMaxLines
		{
			get
			{
				return this._maxLines != null;
			}
		}

		// Token: 0x0400003B RID: 59
		private float? _minLines;

		// Token: 0x0400003C RID: 60
		private float? _maxLines;
	}
}
