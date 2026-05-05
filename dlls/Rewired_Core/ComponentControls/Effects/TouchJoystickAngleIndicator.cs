using System;
using Rewired.UI;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.ComponentControls.Effects
{
	// Token: 0x0200041F RID: 1055
	[ExecuteInEditMode]
	[RequireComponent(typeof(RectTransform))]
	[RequireComponent(typeof(Image))]
	[DisallowMultipleComponent]
	[AddComponentMenu("Rewired/Touch Controls/Effects/Touch Joystick Angle Indicator")]
	public sealed class TouchJoystickAngleIndicator : MonoBehaviour, IVisibilityChangedHandler, TouchJoystick.IStickPositionChangedHandler
	{
		// Token: 0x170009F6 RID: 2550
		// (get) Token: 0x06002A63 RID: 10851 RVA: 0x0002074B File Offset: 0x0001E94B
		// (set) Token: 0x06002A64 RID: 10852 RVA: 0x00020753 File Offset: 0x0001E953
		public bool visible
		{
			get
			{
				return this._visible;
			}
			set
			{
				if (this.visible == value)
				{
					return;
				}
				this.XZpdhKGewDFKADCqPHxClHvWzDav(value, false);
				this.LSuqmXpgEYdPGzwzOawHAXvsTNsq();
			}
		}

		// Token: 0x170009F7 RID: 2551
		// (get) Token: 0x06002A65 RID: 10853 RVA: 0x0002076D File Offset: 0x0001E96D
		// (set) Token: 0x06002A66 RID: 10854 RVA: 0x00020775 File Offset: 0x0001E975
		public bool targetAngleFromRotation
		{
			get
			{
				return this._targetAngleFromRotation;
			}
			set
			{
				if (this._targetAngleFromRotation == value)
				{
					return;
				}
				this._targetAngleFromRotation = value;
				this.LSuqmXpgEYdPGzwzOawHAXvsTNsq();
			}
		}

		// Token: 0x170009F8 RID: 2552
		// (get) Token: 0x06002A67 RID: 10855 RVA: 0x0002078E File Offset: 0x0001E98E
		// (set) Token: 0x06002A68 RID: 10856 RVA: 0x000207AF File Offset: 0x0001E9AF
		public float targetAngle
		{
			get
			{
				if (!this._targetAngleFromRotation)
				{
					return this._targetAngle;
				}
				return base.transform.localEulerAngles.z;
			}
			set
			{
				if (this._targetAngle == value)
				{
					return;
				}
				this._targetAngle = value;
				this.LSuqmXpgEYdPGzwzOawHAXvsTNsq();
			}
		}

		// Token: 0x170009F9 RID: 2553
		// (get) Token: 0x06002A69 RID: 10857 RVA: 0x000207C8 File Offset: 0x0001E9C8
		// (set) Token: 0x06002A6A RID: 10858 RVA: 0x000207D0 File Offset: 0x0001E9D0
		public bool fadeWithValue
		{
			get
			{
				return this._fadeWithValue;
			}
			set
			{
				if (this._fadeWithValue == value)
				{
					return;
				}
				this._fadeWithValue = value;
				this.LSuqmXpgEYdPGzwzOawHAXvsTNsq();
			}
		}

		// Token: 0x170009FA RID: 2554
		// (get) Token: 0x06002A6B RID: 10859 RVA: 0x000207E9 File Offset: 0x0001E9E9
		// (set) Token: 0x06002A6C RID: 10860 RVA: 0x000207F1 File Offset: 0x0001E9F1
		public bool fadeWithAngle
		{
			get
			{
				return this._fadeWithAngle;
			}
			set
			{
				if (this._fadeWithAngle == value)
				{
					return;
				}
				this._fadeWithAngle = value;
				this.LSuqmXpgEYdPGzwzOawHAXvsTNsq();
			}
		}

		// Token: 0x170009FB RID: 2555
		// (get) Token: 0x06002A6D RID: 10861 RVA: 0x0002080A File Offset: 0x0001EA0A
		// (set) Token: 0x06002A6E RID: 10862 RVA: 0x00020812 File Offset: 0x0001EA12
		public float fadeRange
		{
			get
			{
				return this._fadeRange;
			}
			set
			{
				if (this._fadeRange == value)
				{
					return;
				}
				this._fadeRange = value;
				this.LSuqmXpgEYdPGzwzOawHAXvsTNsq();
			}
		}

		// Token: 0x170009FC RID: 2556
		// (get) Token: 0x06002A6F RID: 10863 RVA: 0x0002082B File Offset: 0x0001EA2B
		// (set) Token: 0x06002A70 RID: 10864 RVA: 0x00020833 File Offset: 0x0001EA33
		public Color activeColor
		{
			get
			{
				return this._activeColor;
			}
			set
			{
				this._activeColor = value;
				this.LSuqmXpgEYdPGzwzOawHAXvsTNsq();
			}
		}

		// Token: 0x170009FD RID: 2557
		// (get) Token: 0x06002A71 RID: 10865 RVA: 0x00020842 File Offset: 0x0001EA42
		// (set) Token: 0x06002A72 RID: 10866 RVA: 0x0002084A File Offset: 0x0001EA4A
		public Color normalColor
		{
			get
			{
				return this._normalColor;
			}
			set
			{
				this._normalColor = value;
				this.LSuqmXpgEYdPGzwzOawHAXvsTNsq();
			}
		}

		// Token: 0x170009FE RID: 2558
		// (get) Token: 0x06002A73 RID: 10867 RVA: 0x0009B1F4 File Offset: 0x000993F4
		internal Image GUtkfcFBRIudIzaNfOQKAkrfhsoA
		{
			get
			{
				Image result;
				if ((result = this.mTDZhETbYpPOsEpeZCnWpOMyxunK) == null)
				{
					result = (this.mTDZhETbYpPOsEpeZCnWpOMyxunK = base.GetComponent<Image>());
				}
				return result;
			}
		}

		// Token: 0x170009FF RID: 2559
		// (get) Token: 0x06002A74 RID: 10868 RVA: 0x00020859 File Offset: 0x0001EA59
		internal Sprite MNknnTrQORPxQudgrarZFtmqaEzbA
		{
			get
			{
				if (this.GUtkfcFBRIudIzaNfOQKAkrfhsoA == null)
				{
					return null;
				}
				if (this.mTDZhETbYpPOsEpeZCnWpOMyxunK.overrideSprite != null)
				{
					return this.mTDZhETbYpPOsEpeZCnWpOMyxunK.overrideSprite;
				}
				return this.mTDZhETbYpPOsEpeZCnWpOMyxunK.sprite;
			}
		}

		// Token: 0x17000A00 RID: 2560
		// (get) Token: 0x06002A75 RID: 10869 RVA: 0x0009B21C File Offset: 0x0009941C
		internal RectTransform qvGzxcxWKImaURkjVKIncGitfmUU
		{
			get
			{
				RectTransform result;
				if ((result = this.pbhhNPhUbkRcDSWOvotolYljKFox) == null)
				{
					result = (this.pbhhNPhUbkRcDSWOvotolYljKFox = base.GetComponent<RectTransform>());
				}
				return result;
			}
		}

		// Token: 0x06002A76 RID: 10870 RVA: 0x0009B244 File Offset: 0x00099444
		[CustomObfuscation(rename = false)]
		private TouchJoystickAngleIndicator()
		{
		}

		// Token: 0x06002A77 RID: 10871 RVA: 0x0009B2BC File Offset: 0x000994BC
		internal bool VbTkuYvLoFylXcHzmnWavMPCDOmg(out Vector2 A_1)
		{
			A_1 = Vector2.zero;
			if (this.GUtkfcFBRIudIzaNfOQKAkrfhsoA == null)
			{
				return false;
			}
			Sprite sprite = this.mTDZhETbYpPOsEpeZCnWpOMyxunK.overrideSprite ?? this.mTDZhETbYpPOsEpeZCnWpOMyxunK.sprite;
			if (sprite == null)
			{
				return false;
			}
			Rect textureRect = sprite.textureRect;
			A_1.x = textureRect.width;
			A_1.y = textureRect.height;
			return true;
		}

		// Token: 0x06002A78 RID: 10872 RVA: 0x00020895 File Offset: 0x0001EA95
		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			this.OnTouchJoystickStickPositionChanged(Vector2.zero);
			this.qzeFcURLJFQqfkrAfQwIutJMyQl();
		}

		// Token: 0x06002A79 RID: 10873 RVA: 0x000208A8 File Offset: 0x0001EAA8
		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			if (!Application.isPlaying)
			{
				this.qzeFcURLJFQqfkrAfQwIutJMyQl();
				this.IIyZpSbHGyDGoikJzvsGrCqZRumR();
			}
			this.EUWBuAQGRMgYINPGUgOqiZvnMAsfA(this.fIMAYpoDVKcFWbWbakaDSOpkcDAM);
		}

		// Token: 0x06002A7A RID: 10874 RVA: 0x000208C9 File Offset: 0x0001EAC9
		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			this.jtCDlGmlIkVuqrRrAJrhXVnDmwaD();
		}

		// Token: 0x06002A7B RID: 10875 RVA: 0x000208D1 File Offset: 0x0001EAD1
		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			this.nTDBptskkEclNESnudzPPuLyHgoZ();
			this.EUWBuAQGRMgYINPGUgOqiZvnMAsfA(this.fIMAYpoDVKcFWbWbakaDSOpkcDAM);
		}

		// Token: 0x06002A7C RID: 10876 RVA: 0x000208E5 File Offset: 0x0001EAE5
		[CustomObfuscation(rename = false)]
		private void OnTransformParentChanged()
		{
			this.IIyZpSbHGyDGoikJzvsGrCqZRumR();
		}

		// Token: 0x06002A7D RID: 10877 RVA: 0x0009B32C File Offset: 0x0009952C
		private void XZpdhKGewDFKADCqPHxClHvWzDav(bool A_1, bool A_2)
		{
			if (this._visible == A_1 && !A_2)
			{
				return;
			}
			this._visible = A_1;
			if (!A_1)
			{
				Color normalColor = this._normalColor;
				normalColor.a = 0f;
				this.GUtkfcFBRIudIzaNfOQKAkrfhsoA.CrossFadeColor(normalColor, 0f, true, true);
				return;
			}
			this.EUWBuAQGRMgYINPGUgOqiZvnMAsfA(this.fIMAYpoDVKcFWbWbakaDSOpkcDAM);
		}

		// Token: 0x06002A7E RID: 10878 RVA: 0x0009B384 File Offset: 0x00099584
		private void EUWBuAQGRMgYINPGUgOqiZvnMAsfA(Vector2 A_1)
		{
			if (!this._visible)
			{
				Color normalColor = this._normalColor;
				normalColor.a = 0f;
				this.GUtkfcFBRIudIzaNfOQKAkrfhsoA.CrossFadeColor(normalColor, 0f, true, true);
				return;
			}
			if (!MathTools.ApproximatelyZero(A_1.sqrMagnitude))
			{
				float magnitude = A_1.magnitude;
				float num = Vector2.Angle(Vector2.up, A_1);
				float num2 = (this._targetAngleFromRotation ? base.transform.localEulerAngles.z : this._targetAngle) * -1f;
				float num3 = (A_1.x < 0f) ? (360f - num) : num;
				Color targetColor;
				if (this._fadeWithAngle || this._fadeWithValue)
				{
					float num4 = 1f;
					if (this._fadeWithValue)
					{
						num4 *= magnitude;
					}
					if (this._fadeWithAngle)
					{
						float num5 = Mathf.Abs(MathTools.DeltaAngle(num3, num2));
						float num6 = (this._fadeRange != 0f) ? MathTools.Clamp01(1f - num5 / this._fadeRange) : 1f;
						num4 *= num6;
					}
					targetColor = Color.Lerp(this._normalColor, this._activeColor, num4);
				}
				else
				{
					targetColor = (MathTools.AngleIsNear(num3, num2, this._fadeRange) ? this._activeColor : this._normalColor);
				}
				this.GUtkfcFBRIudIzaNfOQKAkrfhsoA.CrossFadeColor(targetColor, 0f, true, true);
				return;
			}
			this.GUtkfcFBRIudIzaNfOQKAkrfhsoA.CrossFadeColor(this._normalColor, 0f, true, true);
		}

		// Token: 0x06002A7F RID: 10879 RVA: 0x000208ED File Offset: 0x0001EAED
		private void qzeFcURLJFQqfkrAfQwIutJMyQl()
		{
			this.KfujdPAYawXHPdgJNRoUdMgrEDbQA = this._visible;
		}

		// Token: 0x06002A80 RID: 10880 RVA: 0x000208FB File Offset: 0x0001EAFB
		private void nTDBptskkEclNESnudzPPuLyHgoZ()
		{
			if (this.KfujdPAYawXHPdgJNRoUdMgrEDbQA != this._visible)
			{
				this.KfujdPAYawXHPdgJNRoUdMgrEDbQA = this._visible;
				this.XZpdhKGewDFKADCqPHxClHvWzDav(this._visible, true);
			}
		}

		// Token: 0x06002A81 RID: 10881 RVA: 0x00002FF9 File Offset: 0x000011F9
		private void LSuqmXpgEYdPGzwzOawHAXvsTNsq()
		{
		}

		// Token: 0x06002A82 RID: 10882 RVA: 0x0009B4F8 File Offset: 0x000996F8
		private void IIyZpSbHGyDGoikJzvsGrCqZRumR()
		{
			this.jtCDlGmlIkVuqrRrAJrhXVnDmwaD();
			IRegistrar<TouchJoystickAngleIndicator> componentInSelfOrParents = UnityTools.GetComponentInSelfOrParents<IRegistrar<TouchJoystickAngleIndicator>>(base.transform);
			if (componentInSelfOrParents.IsNullOrDestroyed())
			{
				return;
			}
			componentInSelfOrParents.Register(this);
			this.bndWjBFkKXnocxWfWLPupXxaKFUw = componentInSelfOrParents;
		}

		// Token: 0x06002A83 RID: 10883 RVA: 0x00020924 File Offset: 0x0001EB24
		private void jtCDlGmlIkVuqrRrAJrhXVnDmwaD()
		{
			if (this.bndWjBFkKXnocxWfWLPupXxaKFUw.IsNullOrDestroyed())
			{
				if (this.bndWjBFkKXnocxWfWLPupXxaKFUw != null)
				{
					this.bndWjBFkKXnocxWfWLPupXxaKFUw = null;
				}
				return;
			}
			this.bndWjBFkKXnocxWfWLPupXxaKFUw.Deregister(this);
			this.bndWjBFkKXnocxWfWLPupXxaKFUw = null;
		}

		// Token: 0x06002A84 RID: 10884 RVA: 0x00020956 File Offset: 0x0001EB56
		public void OnVisibilityChanged(bool state)
		{
			this.XZpdhKGewDFKADCqPHxClHvWzDav(state, false);
		}

		// Token: 0x06002A85 RID: 10885 RVA: 0x00020960 File Offset: 0x0001EB60
		public void OnTouchJoystickStickPositionChanged(Vector2 value)
		{
			if (this == null)
			{
				return;
			}
			this.fIMAYpoDVKcFWbWbakaDSOpkcDAM = value;
			if (!UnityTools.IsActiveAndEnabled(this))
			{
				return;
			}
			if (!this._visible)
			{
				return;
			}
			this.EUWBuAQGRMgYINPGUgOqiZvnMAsfA(value);
		}

		// Token: 0x06002A86 RID: 10886 RVA: 0x0002098C File Offset: 0x0001EB8C
		void TouchJoystick.IStickPositionChangedHandler.OnStickPositionChanged(Vector2 value)
		{
			this.OnTouchJoystickStickPositionChanged(value);
		}

		// Token: 0x0400185E RID: 6238
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Toggles visibility.")]
		private bool _visible = true;

		// Token: 0x0400185F RID: 6239
		[Tooltip("If enabled, the target angle will be determined by the transform's Local Rotation Z. Otherwise, the activation angle must be manually set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _targetAngleFromRotation = true;

		// Token: 0x04001860 RID: 6240
		[Tooltip("The joystick angle at which this object should be considered fully active.\n0 = up with negative values increase rotating clockwise. Example: -45 degrees = up-right.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, -360f)]
		private float _targetAngle;

		// Token: 0x04001861 RID: 6241
		[Tooltip("If enabled, the color will fade in and out based on the current joystick value.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _fadeWithValue = true;

		// Token: 0x04001862 RID: 6242
		[Tooltip("If enabled, the color will fade in and out based on the current joystick angle. As the angle approaches the Target Angle, the color will become more intense.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _fadeWithAngle = true;

		// Token: 0x04001863 RID: 6243
		[Tooltip("The angle of rotation away from the Target Angle where the color fully fades out. If Fade with Angle is enabled, this is used to determine when the color will fully fade out when the joystick angle rotates away from the the Target Angle. This should be set to 1/2 of the complete rotation arc. Example: A value of 45 degrees would make the color fully fade out when the joystick angle is 45 degrees away from the Target Angle on either side, giving a complete arc of 90 degrees.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 360f)]
		private float _fadeRange = 45f;

		// Token: 0x04001864 RID: 6244
		[Tooltip("The color when fully active.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Color _activeColor = new Color(1f, 1f, 1f, 1f);

		// Token: 0x04001865 RID: 6245
		[Tooltip("The color when not active.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Color _normalColor = new Color(1f, 1f, 1f, 0.3f);

		// Token: 0x04001866 RID: 6246
		private Image mTDZhETbYpPOsEpeZCnWpOMyxunK;

		// Token: 0x04001867 RID: 6247
		private RectTransform pbhhNPhUbkRcDSWOvotolYljKFox;

		// Token: 0x04001868 RID: 6248
		private Vector2 fIMAYpoDVKcFWbWbakaDSOpkcDAM;

		// Token: 0x04001869 RID: 6249
		private bool KfujdPAYawXHPdgJNRoUdMgrEDbQA;

		// Token: 0x0400186A RID: 6250
		private IRegistrar<TouchJoystickAngleIndicator> bndWjBFkKXnocxWfWLPupXxaKFUw;
	}
}
