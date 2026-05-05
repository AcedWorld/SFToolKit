using System;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.ComponentControls.Effects
{
	// Token: 0x02000420 RID: 1056
	[ExecuteInEditMode]
	[RequireComponent(typeof(RectTransform))]
	[DisallowMultipleComponent]
	[AddComponentMenu("Rewired/Touch Controls/Effects/Touch Joystick Radial Indicator")]
	public sealed class TouchJoystickRadialIndicator : MonoBehaviour, IRegistrar<TouchJoystickAngleIndicator>
	{
		// Token: 0x17000A01 RID: 2561
		// (get) Token: 0x06002A87 RID: 10887 RVA: 0x00020995 File Offset: 0x0001EB95
		// (set) Token: 0x06002A88 RID: 10888 RVA: 0x0002099D File Offset: 0x0001EB9D
		public bool scale
		{
			get
			{
				return this._scale;
			}
			set
			{
				if (this._scale == value)
				{
					return;
				}
				this._scale = value;
				this.IlQzmOxRnGSERFSkQjpdUPnDZcJo();
			}
		}

		// Token: 0x17000A02 RID: 2562
		// (get) Token: 0x06002A89 RID: 10889 RVA: 0x000209B6 File Offset: 0x0001EBB6
		// (set) Token: 0x06002A8A RID: 10890 RVA: 0x000209BE File Offset: 0x0001EBBE
		public bool preserveSpriteAspectRatio
		{
			get
			{
				return this._preserveSpriteAspectRatio;
			}
			set
			{
				if (this._preserveSpriteAspectRatio == value)
				{
					return;
				}
				this._preserveSpriteAspectRatio = value;
				this.IlQzmOxRnGSERFSkQjpdUPnDZcJo();
			}
		}

		// Token: 0x17000A03 RID: 2563
		// (get) Token: 0x06002A8B RID: 10891 RVA: 0x000209D7 File Offset: 0x0001EBD7
		// (set) Token: 0x06002A8C RID: 10892 RVA: 0x000209DF File Offset: 0x0001EBDF
		public float scaleRatio
		{
			get
			{
				return this._scaleRatio;
			}
			set
			{
				value = MathTools.Clamp(value, 0.01f, 1f);
				if (this._scaleRatio == value)
				{
					return;
				}
				this._scaleRatio = value;
				this.IlQzmOxRnGSERFSkQjpdUPnDZcJo();
			}
		}

		// Token: 0x17000A04 RID: 2564
		// (get) Token: 0x06002A8D RID: 10893 RVA: 0x00020A0A File Offset: 0x0001EC0A
		// (set) Token: 0x06002A8E RID: 10894 RVA: 0x00020A12 File Offset: 0x0001EC12
		public float aspectRatioX
		{
			get
			{
				return this._aspectRatioX;
			}
			set
			{
				value = MathTools.Clamp(value, 0.01f, 10f);
				if (this._aspectRatioX == value)
				{
					return;
				}
				this._aspectRatioX = value;
				this.IlQzmOxRnGSERFSkQjpdUPnDZcJo();
			}
		}

		// Token: 0x17000A05 RID: 2565
		// (get) Token: 0x06002A8F RID: 10895 RVA: 0x00020A3D File Offset: 0x0001EC3D
		// (set) Token: 0x06002A90 RID: 10896 RVA: 0x00020A45 File Offset: 0x0001EC45
		public float aspectRatioY
		{
			get
			{
				return this._aspectRatioY;
			}
			set
			{
				value = MathTools.Clamp(value, 0.01f, 10f);
				if (this._aspectRatioY == value)
				{
					return;
				}
				this._aspectRatioY = value;
				this.IlQzmOxRnGSERFSkQjpdUPnDZcJo();
			}
		}

		// Token: 0x17000A06 RID: 2566
		// (get) Token: 0x06002A91 RID: 10897 RVA: 0x00020A70 File Offset: 0x0001EC70
		// (set) Token: 0x06002A92 RID: 10898 RVA: 0x00020A78 File Offset: 0x0001EC78
		public float offset
		{
			get
			{
				return this._offset;
			}
			set
			{
				if (this._offset == value)
				{
					return;
				}
				this._offset = value;
				this.IlQzmOxRnGSERFSkQjpdUPnDZcJo();
			}
		}

		// Token: 0x17000A07 RID: 2567
		// (get) Token: 0x06002A93 RID: 10899 RVA: 0x0009B530 File Offset: 0x00099730
		private RectTransform tFCHsUfOwqaIiAOafvhyIFsQQbllA
		{
			get
			{
				RectTransform result;
				if ((result = this.hZrFMBjATuULHzjtpbxpFazNnITO) == null)
				{
					result = (this.hZrFMBjATuULHzjtpbxpFazNnITO = base.GetComponent<RectTransform>());
				}
				return result;
			}
		}

		// Token: 0x06002A94 RID: 10900 RVA: 0x00020A91 File Offset: 0x0001EC91
		void IRegistrar<TouchJoystickAngleIndicator>.Register(TouchJoystickAngleIndicator registrant)
		{
			if (registrant == null)
			{
				return;
			}
			if (ListTools.AddIfUnique<TouchJoystickAngleIndicator>(this.qgSTgejyjipoeyeheuydtkXAqwMH, registrant))
			{
				if (!base.enabled)
				{
					return;
				}
				this.woKFIGIWHjLoZtHmwVTaPfPWlCGgb(registrant);
			}
		}

		// Token: 0x06002A95 RID: 10901 RVA: 0x00020ABB File Offset: 0x0001ECBB
		void IRegistrar<TouchJoystickAngleIndicator>.Deregister(TouchJoystickAngleIndicator registrant)
		{
			if (registrant == null)
			{
				return;
			}
			this.qgSTgejyjipoeyeheuydtkXAqwMH.Remove(registrant);
		}

		// Token: 0x06002A96 RID: 10902 RVA: 0x00020AD4 File Offset: 0x0001ECD4
		[CustomObfuscation(rename = false)]
		private void Update()
		{
			this.IDOqlniInMeZmfqhtxmylYbLFstGb();
		}

		// Token: 0x06002A97 RID: 10903 RVA: 0x00020ADC File Offset: 0x0001ECDC
		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			if (!base.enabled)
			{
				return;
			}
			this.OedGIDIXtZePlsvxKnaqgUFGUTHrA();
			this.IDOqlniInMeZmfqhtxmylYbLFstGb();
		}

		// Token: 0x06002A98 RID: 10904 RVA: 0x00020AD4 File Offset: 0x0001ECD4
		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			this.IDOqlniInMeZmfqhtxmylYbLFstGb();
		}

		// Token: 0x06002A99 RID: 10905 RVA: 0x00020AF3 File Offset: 0x0001ECF3
		[CustomObfuscation(rename = false)]
		private void OnDestroy()
		{
			this.qgSTgejyjipoeyeheuydtkXAqwMH.Clear();
		}

		// Token: 0x06002A9A RID: 10906 RVA: 0x0009B558 File Offset: 0x00099758
		private void IDOqlniInMeZmfqhtxmylYbLFstGb()
		{
			for (int i = this.qgSTgejyjipoeyeheuydtkXAqwMH.Count - 1; i >= 0; i--)
			{
				TouchJoystickAngleIndicator touchJoystickAngleIndicator = this.qgSTgejyjipoeyeheuydtkXAqwMH[i];
				if (touchJoystickAngleIndicator.GUtkfcFBRIudIzaNfOQKAkrfhsoA.IsNullOrDestroyed())
				{
					this.qgSTgejyjipoeyeheuydtkXAqwMH.RemoveAt(i);
				}
				else
				{
					this.woKFIGIWHjLoZtHmwVTaPfPWlCGgb(touchJoystickAngleIndicator);
				}
			}
		}

		// Token: 0x06002A9B RID: 10907 RVA: 0x0009B5AC File Offset: 0x000997AC
		private void woKFIGIWHjLoZtHmwVTaPfPWlCGgb(TouchJoystickAngleIndicator A_1)
		{
			if (!UnityTools.IsActiveAndEnabled(A_1.GUtkfcFBRIudIzaNfOQKAkrfhsoA))
			{
				return;
			}
			RectTransform rectTransform = A_1.qvGzxcxWKImaURkjVKIncGitfmUU;
			if (rectTransform == this.tFCHsUfOwqaIiAOafvhyIFsQQbllA)
			{
				return;
			}
			if (rectTransform == null)
			{
				return;
			}
			Rect rect = this.tFCHsUfOwqaIiAOafvhyIFsQQbllA.rect;
			if (this._scale)
			{
				float num = this._aspectRatioX / this._aspectRatioY;
				Vector2 vector;
				if (this._preserveSpriteAspectRatio && A_1.VbTkuYvLoFylXcHzmnWavMPCDOmg(out vector))
				{
					num = vector.x / vector.y;
				}
				Vector2 sizeDelta = new Vector2(rect.height * this._scaleRatio * num, rect.height * this._scaleRatio);
				rectTransform.sizeDelta = sizeDelta;
			}
			float num2 = (rect.height / 2f / rectTransform.rect.height - 1f) * -1f;
			if (rectTransform.anchorMin != TouchJoystickRadialIndicator.HIMuuOPtrhncpMpIJLtQgYPIGohi)
			{
				rectTransform.anchorMin = TouchJoystickRadialIndicator.HIMuuOPtrhncpMpIJLtQgYPIGohi;
			}
			if (rectTransform.anchorMax != TouchJoystickRadialIndicator.HIMuuOPtrhncpMpIJLtQgYPIGohi)
			{
				rectTransform.anchorMax = TouchJoystickRadialIndicator.HIMuuOPtrhncpMpIJLtQgYPIGohi;
			}
			Vector2 pivot = rectTransform.pivot;
			pivot.x = 0.5f;
			pivot.y = num2 + this._offset * -1f;
			rectTransform.pivot = pivot;
		}

		// Token: 0x06002A9C RID: 10908 RVA: 0x00020AD4 File Offset: 0x0001ECD4
		private void IlQzmOxRnGSERFSkQjpdUPnDZcJo()
		{
			this.IDOqlniInMeZmfqhtxmylYbLFstGb();
		}

		// Token: 0x06002A9D RID: 10909 RVA: 0x0009B6F4 File Offset: 0x000998F4
		private void OedGIDIXtZePlsvxKnaqgUFGUTHrA()
		{
			Transform transform = base.transform;
			this.qgSTgejyjipoeyeheuydtkXAqwMH.Clear();
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				TouchJoystickAngleIndicator component = transform.GetChild(i).GetComponent<TouchJoystickAngleIndicator>();
				if (component != null)
				{
					this.qgSTgejyjipoeyeheuydtkXAqwMH.Add(component);
				}
			}
		}

		// Token: 0x0400186B RID: 6251
		[Tooltip("If enabled, the indicators will be scaled based on the size of the RectTransform.")]
		public bool _scale = true;

		// Token: 0x0400186C RID: 6252
		[Tooltip("If enabled, the aspect ratio will be determined from the Sprite's texture.")]
		public bool _preserveSpriteAspectRatio;

		// Token: 0x0400186D RID: 6253
		[Tooltip("The scale ratio of the indicators to the current RectTransform's height. A ratio of 0.1 means the indicator will be 0.1 times the size of the RectTransform's height. This is useful if you need to be able to scale the transform and have the indicators also scale with it.")]
		[Range(0.01f, 1f)]
		public float _scaleRatio = 0.1f;

		// Token: 0x0400186E RID: 6254
		[Tooltip("The horizontal component of the desired aspect ratio of the indicator.")]
		[Range(0.01f, 10f)]
		public float _aspectRatioX = 1f;

		// Token: 0x0400186F RID: 6255
		[Tooltip("The vertical component of the desired aspect ratio of the indicator.")]
		[Range(0.01f, 10f)]
		public float _aspectRatioY = 1f;

		// Token: 0x04001870 RID: 6256
		[Tooltip("Offsets the indicator position up by this proportion of its height. 1.0 = 1 unit high offset.")]
		public float _offset;

		// Token: 0x04001871 RID: 6257
		private static readonly Vector2 HIMuuOPtrhncpMpIJLtQgYPIGohi = new Vector2(0.5f, 0.5f);

		// Token: 0x04001872 RID: 6258
		private RectTransform hZrFMBjATuULHzjtpbxpFazNnITO;

		// Token: 0x04001873 RID: 6259
		private List<TouchJoystickAngleIndicator> qgSTgejyjipoeyeheuydtkXAqwMH = new List<TouchJoystickAngleIndicator>(8);
	}
}
