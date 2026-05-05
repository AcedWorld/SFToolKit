using System;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	// Token: 0x020003B5 RID: 949
	public interface IDualShock4Extension : IControllerVibrator
	{
		// Token: 0x0600260B RID: 9739
		Vector3 GetAccelerometerValue();

		// Token: 0x0600260C RID: 9740
		Vector3 GetAccelerometerValueRaw();

		// Token: 0x0600260D RID: 9741
		Vector3 GetGyroscopeValueRaw();

		// Token: 0x0600260E RID: 9742
		Vector3 GetGyroscopeValue();

		// Token: 0x0600260F RID: 9743
		Quaternion GetOrientation();

		// Token: 0x06002610 RID: 9744
		void ResetOrientation();

		// Token: 0x06002611 RID: 9745
		void SetLightColor(Color color);

		// Token: 0x06002612 RID: 9746
		void SetLightColor(float red, float green, float blue);

		// Token: 0x06002613 RID: 9747
		void SetLightColor(float red, float green, float blue, float intensity);

		// Token: 0x170008ED RID: 2285
		// (get) Token: 0x06002614 RID: 9748
		int maxTouches { get; }

		// Token: 0x170008EE RID: 2286
		// (get) Token: 0x06002615 RID: 9749
		int touchCount { get; }

		// Token: 0x06002616 RID: 9750
		int GetTouchId(int index);

		// Token: 0x06002617 RID: 9751
		bool GetTouchPosition(int index, out Vector2 position);

		// Token: 0x06002618 RID: 9752
		bool GetTouchPositionByTouchId(int touchId, out Vector2 position);

		// Token: 0x06002619 RID: 9753
		bool IsTouching(int index);

		// Token: 0x0600261A RID: 9754
		bool IsTouchingByTouchId(int touchId);

		// Token: 0x0600261B RID: 9755
		void SetVibration(float leftMotorLevel, float rightMotorLevel);

		// Token: 0x0600261C RID: 9756
		void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftMotorDuration, float rightMotorDuration);
	}
}
