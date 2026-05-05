using System;

namespace UnityEngine.Search
{
	// Token: 0x02000310 RID: 784
	[Flags]
	public enum SearchViewFlags
	{
		// Token: 0x04000A84 RID: 2692
		None = 0,
		// Token: 0x04000A85 RID: 2693
		Debug = 16,
		// Token: 0x04000A86 RID: 2694
		NoIndexing = 32,
		// Token: 0x04000A87 RID: 2695
		Packages = 256,
		// Token: 0x04000A88 RID: 2696
		OpenLeftSidePanel = 2048,
		// Token: 0x04000A89 RID: 2697
		OpenInspectorPreview = 4096,
		// Token: 0x04000A8A RID: 2698
		Centered = 8192,
		// Token: 0x04000A8B RID: 2699
		HideSearchBar = 16384,
		// Token: 0x04000A8C RID: 2700
		CompactView = 32768,
		// Token: 0x04000A8D RID: 2701
		ListView = 65536,
		// Token: 0x04000A8E RID: 2702
		GridView = 131072,
		// Token: 0x04000A8F RID: 2703
		TableView = 262144,
		// Token: 0x04000A90 RID: 2704
		EnableSearchQuery = 524288,
		// Token: 0x04000A91 RID: 2705
		DisableInspectorPreview = 1048576,
		// Token: 0x04000A92 RID: 2706
		DisableSavedSearchQuery = 2097152,
		// Token: 0x04000A93 RID: 2707
		OpenInBuilderMode = 4194304,
		// Token: 0x04000A94 RID: 2708
		OpenInTextMode = 8388608,
		// Token: 0x04000A95 RID: 2709
		DisableBuilderModeToggle = 16777216,
		// Token: 0x04000A96 RID: 2710
		Borderless = 33554432,
		// Token: 0x04000A97 RID: 2711
		DisableQueryHelpers = 67108864,
		// Token: 0x04000A98 RID: 2712
		DisableNoResultTips = 134217728,
		// Token: 0x04000A99 RID: 2713
		IgnoreSavedSearches = 268435456,
		// Token: 0x04000A9A RID: 2714
		ObjectPicker = 536870912,
		// Token: 0x04000A9B RID: 2715
		ObjectPickerAdvancedUI = 1073741824,
		// Token: 0x04000A9C RID: 2716
		ContextSwitchPreservedMask = 33560576
	}
}
