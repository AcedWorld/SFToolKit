using System;
using UnityEngine;

namespace Rewired.ComponentControls.Effects
{
	// Token: 0x0200041B RID: 1051
	[AddComponentMenu("Rewired/Touch Controls/Effects/Rotate Around Axis")]
	public class RotateAroundAxis : MonoBehaviour
	{
		// Token: 0x170009E6 RID: 2534
		// (get) Token: 0x06002A2B RID: 10795 RVA: 0x00020475 File Offset: 0x0001E675
		// (set) Token: 0x06002A2C RID: 10796 RVA: 0x0002047D File Offset: 0x0001E67D
		public RotateAroundAxis.Speed speed
		{
			get
			{
				return this._speed;
			}
			set
			{
				this._speed = value;
			}
		}

		// Token: 0x170009E7 RID: 2535
		// (get) Token: 0x06002A2D RID: 10797 RVA: 0x00020486 File Offset: 0x0001E686
		// (set) Token: 0x06002A2E RID: 10798 RVA: 0x0002048E File Offset: 0x0001E68E
		public float slowRotationSpeed
		{
			get
			{
				return this._slowRotationSpeed;
			}
			set
			{
				this._slowRotationSpeed = value;
			}
		}

		// Token: 0x170009E8 RID: 2536
		// (get) Token: 0x06002A2F RID: 10799 RVA: 0x00020497 File Offset: 0x0001E697
		// (set) Token: 0x06002A30 RID: 10800 RVA: 0x0002049F File Offset: 0x0001E69F
		public float fastRotationSpeed
		{
			get
			{
				return this._fastRotationSpeed;
			}
			set
			{
				this._fastRotationSpeed = value;
			}
		}

		// Token: 0x170009E9 RID: 2537
		// (get) Token: 0x06002A31 RID: 10801 RVA: 0x000204A8 File Offset: 0x0001E6A8
		// (set) Token: 0x06002A32 RID: 10802 RVA: 0x000204B0 File Offset: 0x0001E6B0
		public RotateAroundAxis.RotationAxis rotateAroundAxis
		{
			get
			{
				return this._rotateAroundAxis;
			}
			set
			{
				this._rotateAroundAxis = value;
			}
		}

		// Token: 0x170009EA RID: 2538
		// (get) Token: 0x06002A33 RID: 10803 RVA: 0x000204B9 File Offset: 0x0001E6B9
		// (set) Token: 0x06002A34 RID: 10804 RVA: 0x000204C1 File Offset: 0x0001E6C1
		public Space relativeTo
		{
			get
			{
				return this._relativeTo;
			}
			set
			{
				this._relativeTo = value;
			}
		}

		// Token: 0x170009EB RID: 2539
		// (get) Token: 0x06002A35 RID: 10805 RVA: 0x000204CA File Offset: 0x0001E6CA
		// (set) Token: 0x06002A36 RID: 10806 RVA: 0x000204D2 File Offset: 0x0001E6D2
		public bool reverse
		{
			get
			{
				return this._reverse;
			}
			set
			{
				this._reverse = value;
			}
		}

		// Token: 0x06002A37 RID: 10807 RVA: 0x0009AD54 File Offset: 0x00098F54
		[CustomObfuscation(rename = false)]
		private void Update()
		{
			if (this._speed == RotateAroundAxis.Speed.Stopped)
			{
				return;
			}
			float num = (this._speed == RotateAroundAxis.Speed.Fast) ? this._fastRotationSpeed : this._slowRotationSpeed;
			if (this._reverse)
			{
				num *= -1f;
			}
			base.transform.Rotate(RotateAroundAxis.rDXpPgaNBClzOBvjdkQMOMOrlGZU(this._rotateAroundAxis), num * Time.deltaTime, this._relativeTo);
		}

		// Token: 0x06002A38 RID: 10808 RVA: 0x0009ADB8 File Offset: 0x00098FB8
		private static Vector3 rDXpPgaNBClzOBvjdkQMOMOrlGZU(RotateAroundAxis.RotationAxis A_0)
		{
			switch (A_0)
			{
			case RotateAroundAxis.RotationAxis.X:
				return new Vector3(1f, 0f, 0f);
			case RotateAroundAxis.RotationAxis.Y:
				return new Vector3(0f, 1f, 0f);
			case RotateAroundAxis.RotationAxis.Z:
				return new Vector3(0f, 0f, 1f);
			default:
				throw new NotImplementedException();
			}
		}

		// Token: 0x06002A39 RID: 10809 RVA: 0x0002047D File Offset: 0x0001E67D
		public void SetSpeed(RotateAroundAxis.Speed speed)
		{
			this._speed = speed;
		}

		// Token: 0x06002A3A RID: 10810 RVA: 0x000204DB File Offset: 0x0001E6DB
		public void SetSpeed(int speed)
		{
			if (!Enum.IsDefined(typeof(RotateAroundAxis.Speed), speed))
			{
				return;
			}
			this._speed = (RotateAroundAxis.Speed)speed;
		}

		// Token: 0x04001847 RID: 6215
		[Tooltip("The current speed of rotation.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private RotateAroundAxis.Speed _speed;

		// Token: 0x04001848 RID: 6216
		[Tooltip("The speed of rotation when Speed is set to Slow. This measured in degrees per second.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _slowRotationSpeed = 5f;

		// Token: 0x04001849 RID: 6217
		[Tooltip("The speed of rotation when Speed is set to Fast. This measured in degrees per second.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _fastRotationSpeed = 20f;

		// Token: 0x0400184A RID: 6218
		[Tooltip("The axis around which rotation will occur.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private RotateAroundAxis.RotationAxis _rotateAroundAxis = RotateAroundAxis.RotationAxis.Z;

		// Token: 0x0400184B RID: 6219
		[Tooltip("The space in which rotation will occur.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Space _relativeTo = Space.Self;

		// Token: 0x0400184C RID: 6220
		[Tooltip("Reverses the rotation direction.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _reverse;

		// Token: 0x0200041C RID: 1052
		public enum Speed
		{
			// Token: 0x0400184E RID: 6222
			Stopped,
			// Token: 0x0400184F RID: 6223
			Slow,
			// Token: 0x04001850 RID: 6224
			Fast
		}

		// Token: 0x0200041D RID: 1053
		public enum RotationAxis
		{
			// Token: 0x04001852 RID: 6226
			X,
			// Token: 0x04001853 RID: 6227
			Y,
			// Token: 0x04001854 RID: 6228
			Z
		}
	}
}
