using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x02000265 RID: 613
	internal interface ILiveReloadAssetTracker<T> where T : ScriptableObject
	{
		// Token: 0x06001166 RID: 4454
		int StartTrackingAsset(T asset);

		// Token: 0x06001167 RID: 4455
		void StopTrackingAsset(T asset);

		// Token: 0x06001168 RID: 4456
		bool IsTrackingAsset(T asset);

		// Token: 0x06001169 RID: 4457
		bool IsTrackingAssets();

		// Token: 0x0600116A RID: 4458
		bool CheckTrackedAssetsDirty();

		// Token: 0x0600116B RID: 4459
		void UpdateAssetTrackerCounts(T asset, int newDirtyCount, int newElementCount, int newInlinePropertiesCount, int newAttributePropertiesDirtyCount);

		// Token: 0x0600116C RID: 4460
		bool OnAssetsImported(HashSet<T> changedAssets, HashSet<string> deletedAssets);

		// Token: 0x0600116D RID: 4461
		void OnTrackedAssetChanged();
	}
}
