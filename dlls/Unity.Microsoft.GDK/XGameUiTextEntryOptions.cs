using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000146 RID: 326
	public class XGameUiTextEntryOptions
	{
		// Token: 0x060007F0 RID: 2032 RVA: 0x0000D645 File Offset: 0x0000B845
		internal XGameUiTextEntryOptions(XGameUiTextEntryOptions interop)
		{
			this.data = interop;
		}

		// Token: 0x060007F1 RID: 2033 RVA: 0x0000D654 File Offset: 0x0000B854
		public XGameUiTextEntryOptions()
		{
			this.data = default(XGameUiTextEntryOptions);
		}

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x060007F2 RID: 2034 RVA: 0x0000D668 File Offset: 0x0000B868
		// (set) Token: 0x060007F3 RID: 2035 RVA: 0x0000D675 File Offset: 0x0000B875
		public XGameUiTextEntryInputScope InputScope
		{
			get
			{
				return this.data.inputScope;
			}
			set
			{
				this.data.inputScope = value;
			}
		}

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x060007F4 RID: 2036 RVA: 0x0000D683 File Offset: 0x0000B883
		// (set) Token: 0x060007F5 RID: 2037 RVA: 0x0000D690 File Offset: 0x0000B890
		public XGameUiTextEntryPositionHint PositionHint
		{
			get
			{
				return this.data.positionHint;
			}
			set
			{
				this.data.positionHint = value;
			}
		}

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x060007F6 RID: 2038 RVA: 0x0000D69E File Offset: 0x0000B89E
		// (set) Token: 0x060007F7 RID: 2039 RVA: 0x0000D6AB File Offset: 0x0000B8AB
		public XGameUiTextEntryVisibilityFlags VisibilityFlags
		{
			get
			{
				return this.data.visibilityFlags;
			}
			set
			{
				this.data.visibilityFlags = value;
			}
		}

		// Token: 0x040004D4 RID: 1236
		internal XGameUiTextEntryOptions data;
	}
}
