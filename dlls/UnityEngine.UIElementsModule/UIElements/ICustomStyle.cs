using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020002CC RID: 716
	public interface ICustomStyle
	{
		// Token: 0x06001556 RID: 5462
		bool TryGetValue(CustomStyleProperty<float> property, out float value);

		// Token: 0x06001557 RID: 5463
		bool TryGetValue(CustomStyleProperty<int> property, out int value);

		// Token: 0x06001558 RID: 5464
		bool TryGetValue(CustomStyleProperty<bool> property, out bool value);

		// Token: 0x06001559 RID: 5465
		bool TryGetValue(CustomStyleProperty<Color> property, out Color value);

		// Token: 0x0600155A RID: 5466
		bool TryGetValue(CustomStyleProperty<Texture2D> property, out Texture2D value);

		// Token: 0x0600155B RID: 5467
		bool TryGetValue(CustomStyleProperty<Sprite> property, out Sprite value);

		// Token: 0x0600155C RID: 5468
		bool TryGetValue(CustomStyleProperty<VectorImage> property, out VectorImage value);

		// Token: 0x0600155D RID: 5469
		bool TryGetValue<T>(CustomStyleProperty<T> property, out T value) where T : Object;

		// Token: 0x0600155E RID: 5470
		bool TryGetValue(CustomStyleProperty<string> property, out string value);
	}
}
