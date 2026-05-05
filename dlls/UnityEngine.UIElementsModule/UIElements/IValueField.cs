using System;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.UIElements
{
	// Token: 0x02000131 RID: 305
	[MovedFrom(true, "UnityEditor.UIElements", "UnityEditor.UIElementsModule", null)]
	public interface IValueField<T>
	{
		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x06000A12 RID: 2578
		// (set) Token: 0x06000A13 RID: 2579
		T value { get; set; }

		// Token: 0x06000A14 RID: 2580
		void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, T startValue);

		// Token: 0x06000A15 RID: 2581
		void StartDragging();

		// Token: 0x06000A16 RID: 2582
		void StopDragging();
	}
}
