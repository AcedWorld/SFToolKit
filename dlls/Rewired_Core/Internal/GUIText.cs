using System;
using System.ComponentModel;
using Rewired.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.Internal
{
	// Token: 0x0200042A RID: 1066
	[AddComponentMenu("")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GUIText : MonoBehaviour
	{
		// Token: 0x17000A23 RID: 2595
		// (get) Token: 0x06002ADE RID: 10974 RVA: 0x00020ECF File Offset: 0x0001F0CF
		// (set) Token: 0x06002ADF RID: 10975 RVA: 0x00020ED7 File Offset: 0x0001F0D7
		public string text
		{
			get
			{
				return this.XcHWUXwWrDPuvYLgyjSKUJgkBxfb;
			}
			set
			{
				this.XcHWUXwWrDPuvYLgyjSKUJgkBxfb = value;
			}
		}

		// Token: 0x17000A24 RID: 2596
		// (get) Token: 0x06002AE0 RID: 10976 RVA: 0x00020EE0 File Offset: 0x0001F0E0
		// (set) Token: 0x06002AE1 RID: 10977 RVA: 0x00020EE8 File Offset: 0x0001F0E8
		public TextAnchor anchor
		{
			get
			{
				return this.biJvhsmxCKhqTgEsFbIxsgiXwwSs;
			}
			set
			{
				this.biJvhsmxCKhqTgEsFbIxsgiXwwSs = value;
				this.KuApWuJjLKuzIpSokGJDHmqFCjOn = true;
				if (this.UDmMzhGIpSQanuezJumzLMmAFkNfA == null)
				{
					return;
				}
				this.UDmMzhGIpSQanuezJumzLMmAFkNfA.alignment = value;
			}
		}

		// Token: 0x17000A25 RID: 2597
		// (get) Token: 0x06002AE2 RID: 10978 RVA: 0x00020F0D File Offset: 0x0001F10D
		// (set) Token: 0x06002AE3 RID: 10979 RVA: 0x00020F15 File Offset: 0x0001F115
		public TextAlignment alignment
		{
			get
			{
				return this.gzlSKlvbcMfLAktBzLifjRHmBxrt;
			}
			set
			{
				this.gzlSKlvbcMfLAktBzLifjRHmBxrt = value;
				this.qzynosmeelELsirxPWHVODHcOmt = true;
			}
		}

		// Token: 0x17000A26 RID: 2598
		// (get) Token: 0x06002AE4 RID: 10980 RVA: 0x00020F25 File Offset: 0x0001F125
		// (set) Token: 0x06002AE5 RID: 10981 RVA: 0x00020F2D File Offset: 0x0001F12D
		public float lineSpacing
		{
			get
			{
				return this.GQuLtojknQcCmfCTiEWDsciqGOjfb;
			}
			set
			{
				this.GQuLtojknQcCmfCTiEWDsciqGOjfb = value;
				this.UxZHeoIbpqcZofkavOHDUbnMHMUK = true;
				GUIStyle udmMzhGIpSQanuezJumzLMmAFkNfA = this.UDmMzhGIpSQanuezJumzLMmAFkNfA;
			}
		}

		// Token: 0x17000A27 RID: 2599
		// (get) Token: 0x06002AE6 RID: 10982 RVA: 0x00020F44 File Offset: 0x0001F144
		// (set) Token: 0x06002AE7 RID: 10983 RVA: 0x00020F4C File Offset: 0x0001F14C
		public Font font
		{
			get
			{
				return this.amFVThxBRaikndAzqvLmDtqFfeth;
			}
			set
			{
				this.ZASITLyaDgjAqmitxSppppBagcM = true;
				this.amFVThxBRaikndAzqvLmDtqFfeth = value;
				if (this.UDmMzhGIpSQanuezJumzLMmAFkNfA == null)
				{
					return;
				}
				this.UDmMzhGIpSQanuezJumzLMmAFkNfA.font = value;
			}
		}

		// Token: 0x17000A28 RID: 2600
		// (get) Token: 0x06002AE8 RID: 10984 RVA: 0x00020F71 File Offset: 0x0001F171
		// (set) Token: 0x06002AE9 RID: 10985 RVA: 0x00020F79 File Offset: 0x0001F179
		public int fontSize
		{
			get
			{
				return this.ZvZtKILDAGusbyLVxUiQIfyDhziD;
			}
			set
			{
				this.ZvZtKILDAGusbyLVxUiQIfyDhziD = value;
				this.pzHUcYnjfPGLMgCdchEgGyRqiZhe = true;
				if (this.UDmMzhGIpSQanuezJumzLMmAFkNfA == null)
				{
					return;
				}
				this.UDmMzhGIpSQanuezJumzLMmAFkNfA.fontSize = value;
			}
		}

		// Token: 0x17000A29 RID: 2601
		// (get) Token: 0x06002AEA RID: 10986 RVA: 0x00020F9E File Offset: 0x0001F19E
		// (set) Token: 0x06002AEB RID: 10987 RVA: 0x00020FA6 File Offset: 0x0001F1A6
		public FontStyle fontStyle
		{
			get
			{
				return this.RSEyTIyYSwJCosqoyWwWRXOIQveF;
			}
			set
			{
				this.RSEyTIyYSwJCosqoyWwWRXOIQveF = value;
				this.fGiOqLLIVkpesThrpRTtDNITIoDE = true;
				if (this.UDmMzhGIpSQanuezJumzLMmAFkNfA == null)
				{
					return;
				}
				this.UDmMzhGIpSQanuezJumzLMmAFkNfA.fontStyle = value;
			}
		}

		// Token: 0x17000A2A RID: 2602
		// (get) Token: 0x06002AEC RID: 10988 RVA: 0x00020FCB File Offset: 0x0001F1CB
		// (set) Token: 0x06002AED RID: 10989 RVA: 0x00020FD3 File Offset: 0x0001F1D3
		public Color color
		{
			get
			{
				return this.IvExJIRTGBcHsLZNtgWvnCOyGyuV;
			}
			set
			{
				this.IvExJIRTGBcHsLZNtgWvnCOyGyuV = value;
				this.ybFzAXMvZvJUraDlavcXRJEohZNk = true;
				if (this.UDmMzhGIpSQanuezJumzLMmAFkNfA == null)
				{
					return;
				}
				this.UDmMzhGIpSQanuezJumzLMmAFkNfA.normal.textColor = value;
			}
		}

		// Token: 0x17000A2B RID: 2603
		// (get) Token: 0x06002AEE RID: 10990 RVA: 0x00020FFD File Offset: 0x0001F1FD
		// (set) Token: 0x06002AEF RID: 10991 RVA: 0x00021005 File Offset: 0x0001F205
		public Vector2 pixelOffset
		{
			get
			{
				return this._pixelOffset;
			}
			set
			{
				this._pixelOffset = value;
			}
		}

		// Token: 0x17000A2C RID: 2604
		// (get) Token: 0x06002AF0 RID: 10992 RVA: 0x0002100E File Offset: 0x0001F20E
		// (set) Token: 0x06002AF1 RID: 10993 RVA: 0x00021016 File Offset: 0x0001F216
		public bool useUnityUI
		{
			get
			{
				return this._useUnityUI;
			}
			set
			{
				if (this._useUnityUI == value)
				{
					return;
				}
				this._useUnityUI = value;
				this.ZgiEeLAiRXOlIDWdKViymTDzzLGF = value;
				if (value)
				{
					this.npyfNViNnHXhDEUgaegHvuzDdNuCb();
					return;
				}
				this.oLgiSfWlvAFwjanswCtdnJwxwrkJA();
			}
		}

		// Token: 0x06002AF2 RID: 10994 RVA: 0x00021040 File Offset: 0x0001F240
		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			this.jrXmrSsAAGrzAEdtUzKkAFPjDnAB = true;
		}

		// Token: 0x06002AF3 RID: 10995 RVA: 0x00021049 File Offset: 0x0001F249
		[CustomObfuscation(rename = false)]
		private void Start()
		{
			this.ZgiEeLAiRXOlIDWdKViymTDzzLGF = this._useUnityUI;
			if (this._useUnityUI)
			{
				this.npyfNViNnHXhDEUgaegHvuzDdNuCb();
			}
		}

		// Token: 0x06002AF4 RID: 10996 RVA: 0x0009BBB4 File Offset: 0x00099DB4
		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			if (this._useUnityUI)
			{
				return;
			}
			if (this.UDmMzhGIpSQanuezJumzLMmAFkNfA == null)
			{
				this.hKAQsErmrWvnnAHFjdzYJqxWgnlT();
			}
			if (!string.IsNullOrEmpty(this.XcHWUXwWrDPuvYLgyjSKUJgkBxfb))
			{
				Vector2 vector = base.transform.localPosition;
				GUI.Label(new Rect(vector.x * (float)Screen.width + this._pixelOffset.x, vector.y * (float)Screen.height + this._pixelOffset.y, MathTools.Clamp((float)Screen.width - vector.x * (float)Screen.width, 0f, float.MaxValue), MathTools.Clamp((float)Screen.height - vector.y * (float)Screen.height, 0f, float.MaxValue)), this.XcHWUXwWrDPuvYLgyjSKUJgkBxfb, this.UDmMzhGIpSQanuezJumzLMmAFkNfA);
			}
		}

		// Token: 0x06002AF5 RID: 10997 RVA: 0x0009BC88 File Offset: 0x00099E88
		[CustomObfuscation(rename = false)]
		private void Update()
		{
			if (!this._useUnityUI)
			{
				return;
			}
			if (this.LAQreHundYOntUEoeIbmNVjmcomHA == null)
			{
				Logger.LogError("Text component has been deleted.");
				return;
			}
			RectTransform component = this.LAQreHundYOntUEoeIbmNVjmcomHA.GetComponent<RectTransform>();
			if (component.anchoredPosition != this._pixelOffset)
			{
				component.anchoredPosition = this._pixelOffset;
			}
			this.LAQreHundYOntUEoeIbmNVjmcomHA.text = this.XcHWUXwWrDPuvYLgyjSKUJgkBxfb;
		}

		// Token: 0x06002AF6 RID: 10998 RVA: 0x00021065 File Offset: 0x0001F265
		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			if (!this.jrXmrSsAAGrzAEdtUzKkAFPjDnAB)
			{
				return;
			}
			if (this._useUnityUI != this.ZgiEeLAiRXOlIDWdKViymTDzzLGF)
			{
				this.ZgiEeLAiRXOlIDWdKViymTDzzLGF = this._useUnityUI;
				if (this._useUnityUI)
				{
					this.npyfNViNnHXhDEUgaegHvuzDdNuCb();
					return;
				}
				this.oLgiSfWlvAFwjanswCtdnJwxwrkJA();
			}
		}

		// Token: 0x06002AF7 RID: 10999 RVA: 0x0009BCF4 File Offset: 0x00099EF4
		private void npyfNViNnHXhDEUgaegHvuzDdNuCb()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			if (UnityTools.GetComponentInSelfOrParents<Canvas>(base.transform) == null)
			{
				GameObject gameObject;
				if (base.transform.root == base.transform)
				{
					gameObject = new GameObject("Canvas");
					base.transform.SetParent(gameObject.transform, true);
				}
				else
				{
					gameObject = base.transform.root.gameObject;
				}
				gameObject.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
				if (!(gameObject.GetComponent<CanvasScaler>() != null))
				{
					gameObject.AddComponent<CanvasScaler>();
				}
				else
				{
					gameObject.GetComponent<CanvasScaler>();
				}
			}
			this.LAQreHundYOntUEoeIbmNVjmcomHA = base.GetComponent<Text>();
			if (this.LAQreHundYOntUEoeIbmNVjmcomHA == null)
			{
				RectTransform rectTransform = base.gameObject.AddComponent<RectTransform>();
				rectTransform.anchorMax = new Vector2(1f, 1f);
				rectTransform.anchorMin = new Vector2(0f, 0f);
				rectTransform.localPosition = Vector2.zero;
				rectTransform.anchoredPosition = Vector2.zero;
				rectTransform.sizeDelta = Vector3.zero;
				this.LAQreHundYOntUEoeIbmNVjmcomHA = base.gameObject.AddComponent<Text>();
				this.LAQreHundYOntUEoeIbmNVjmcomHA.color = Color.white;
				if (this._useUnityUI)
				{
					try
					{
						this.LAQreHundYOntUEoeIbmNVjmcomHA.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
					}
					catch
					{
						try
						{
							this.LAQreHundYOntUEoeIbmNVjmcomHA.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
						}
						catch
						{
							Logger.LogError("No default font found for GUIText.");
						}
					}
				}
				this.LAQreHundYOntUEoeIbmNVjmcomHA.fontSize = 13;
				if (this.KuApWuJjLKuzIpSokGJDHmqFCjOn)
				{
					this.LAQreHundYOntUEoeIbmNVjmcomHA.alignment = this.biJvhsmxCKhqTgEsFbIxsgiXwwSs;
				}
				else
				{
					this.biJvhsmxCKhqTgEsFbIxsgiXwwSs = this.LAQreHundYOntUEoeIbmNVjmcomHA.alignment;
				}
				if (this.ZASITLyaDgjAqmitxSppppBagcM)
				{
					this.LAQreHundYOntUEoeIbmNVjmcomHA.font = this.amFVThxBRaikndAzqvLmDtqFfeth;
				}
				else
				{
					this.amFVThxBRaikndAzqvLmDtqFfeth = this.LAQreHundYOntUEoeIbmNVjmcomHA.font;
				}
				if (this.pzHUcYnjfPGLMgCdchEgGyRqiZhe)
				{
					this.LAQreHundYOntUEoeIbmNVjmcomHA.fontSize = this.ZvZtKILDAGusbyLVxUiQIfyDhziD;
				}
				else
				{
					this.ZvZtKILDAGusbyLVxUiQIfyDhziD = this.LAQreHundYOntUEoeIbmNVjmcomHA.fontSize;
				}
				if (this.fGiOqLLIVkpesThrpRTtDNITIoDE)
				{
					this.LAQreHundYOntUEoeIbmNVjmcomHA.fontStyle = this.RSEyTIyYSwJCosqoyWwWRXOIQveF;
				}
				else
				{
					this.RSEyTIyYSwJCosqoyWwWRXOIQveF = this.LAQreHundYOntUEoeIbmNVjmcomHA.fontStyle;
				}
				if (this.ybFzAXMvZvJUraDlavcXRJEohZNk)
				{
					this.LAQreHundYOntUEoeIbmNVjmcomHA.color = this.IvExJIRTGBcHsLZNtgWvnCOyGyuV;
					return;
				}
				this.IvExJIRTGBcHsLZNtgWvnCOyGyuV = this.LAQreHundYOntUEoeIbmNVjmcomHA.color;
			}
		}

		// Token: 0x06002AF8 RID: 11000 RVA: 0x0002109F File Offset: 0x0001F29F
		private void oLgiSfWlvAFwjanswCtdnJwxwrkJA()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			if (this.LAQreHundYOntUEoeIbmNVjmcomHA != null)
			{
				this.LAQreHundYOntUEoeIbmNVjmcomHA.text = string.Empty;
			}
			this.LAQreHundYOntUEoeIbmNVjmcomHA = null;
		}

		// Token: 0x06002AF9 RID: 11001 RVA: 0x0009BF78 File Offset: 0x0009A178
		private void hKAQsErmrWvnnAHFjdzYJqxWgnlT()
		{
			this.UDmMzhGIpSQanuezJumzLMmAFkNfA = new GUIStyle(GUI.skin.label);
			if (this.KuApWuJjLKuzIpSokGJDHmqFCjOn)
			{
				this.UDmMzhGIpSQanuezJumzLMmAFkNfA.alignment = this.biJvhsmxCKhqTgEsFbIxsgiXwwSs;
			}
			else
			{
				this.biJvhsmxCKhqTgEsFbIxsgiXwwSs = this.UDmMzhGIpSQanuezJumzLMmAFkNfA.alignment;
			}
			if (this.ZASITLyaDgjAqmitxSppppBagcM)
			{
				this.UDmMzhGIpSQanuezJumzLMmAFkNfA.font = this.amFVThxBRaikndAzqvLmDtqFfeth;
			}
			else
			{
				this.amFVThxBRaikndAzqvLmDtqFfeth = this.UDmMzhGIpSQanuezJumzLMmAFkNfA.font;
			}
			if (this.pzHUcYnjfPGLMgCdchEgGyRqiZhe)
			{
				this.UDmMzhGIpSQanuezJumzLMmAFkNfA.fontSize = this.ZvZtKILDAGusbyLVxUiQIfyDhziD;
			}
			else
			{
				this.ZvZtKILDAGusbyLVxUiQIfyDhziD = this.UDmMzhGIpSQanuezJumzLMmAFkNfA.fontSize;
			}
			if (this.fGiOqLLIVkpesThrpRTtDNITIoDE)
			{
				this.UDmMzhGIpSQanuezJumzLMmAFkNfA.fontStyle = this.RSEyTIyYSwJCosqoyWwWRXOIQveF;
			}
			else
			{
				this.RSEyTIyYSwJCosqoyWwWRXOIQveF = this.UDmMzhGIpSQanuezJumzLMmAFkNfA.fontStyle;
			}
			if (this.ybFzAXMvZvJUraDlavcXRJEohZNk)
			{
				this.UDmMzhGIpSQanuezJumzLMmAFkNfA.normal.textColor = this.IvExJIRTGBcHsLZNtgWvnCOyGyuV;
				return;
			}
			this.IvExJIRTGBcHsLZNtgWvnCOyGyuV = this.UDmMzhGIpSQanuezJumzLMmAFkNfA.normal.textColor;
		}

		// Token: 0x06002AFA RID: 11002 RVA: 0x0009C080 File Offset: 0x0009A280
		[CustomObfuscation(rename = false)]
		internal static GUIText GetOrAddComponent(GameObject gameObject)
		{
			if (gameObject == null)
			{
				return null;
			}
			GUIText guitext = gameObject.GetComponent<GUIText>();
			if (guitext == null)
			{
				guitext = gameObject.AddComponent<GUIText>();
			}
			return guitext;
		}

		// Token: 0x06002AFB RID: 11003 RVA: 0x000210CE File Offset: 0x0001F2CE
		[CustomObfuscation(rename = false)]
		internal static GUIText CreateLogger(GameObject gameObject)
		{
			if (gameObject == null)
			{
				return null;
			}
			GUIText orAddComponent = GUIText.GetOrAddComponent(gameObject);
			orAddComponent.anchor = TextAnchor.LowerLeft;
			return orAddComponent;
		}

		// Token: 0x04001896 RID: 6294
		private string XcHWUXwWrDPuvYLgyjSKUJgkBxfb;

		// Token: 0x04001897 RID: 6295
		private GUIStyle UDmMzhGIpSQanuezJumzLMmAFkNfA;

		// Token: 0x04001898 RID: 6296
		private TextAnchor biJvhsmxCKhqTgEsFbIxsgiXwwSs;

		// Token: 0x04001899 RID: 6297
		private TextAlignment gzlSKlvbcMfLAktBzLifjRHmBxrt;

		// Token: 0x0400189A RID: 6298
		private float GQuLtojknQcCmfCTiEWDsciqGOjfb;

		// Token: 0x0400189B RID: 6299
		private Font amFVThxBRaikndAzqvLmDtqFfeth;

		// Token: 0x0400189C RID: 6300
		private int ZvZtKILDAGusbyLVxUiQIfyDhziD = -1;

		// Token: 0x0400189D RID: 6301
		private FontStyle RSEyTIyYSwJCosqoyWwWRXOIQveF;

		// Token: 0x0400189E RID: 6302
		private Color IvExJIRTGBcHsLZNtgWvnCOyGyuV = Color.white;

		// Token: 0x0400189F RID: 6303
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Vector2 _pixelOffset;

		// Token: 0x040018A0 RID: 6304
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useUnityUI;

		// Token: 0x040018A1 RID: 6305
		private bool KuApWuJjLKuzIpSokGJDHmqFCjOn;

		// Token: 0x040018A2 RID: 6306
		private bool qzynosmeelELsirxPWHVODHcOmt;

		// Token: 0x040018A3 RID: 6307
		private bool UxZHeoIbpqcZofkavOHDUbnMHMUK;

		// Token: 0x040018A4 RID: 6308
		private bool ZASITLyaDgjAqmitxSppppBagcM;

		// Token: 0x040018A5 RID: 6309
		private bool pzHUcYnjfPGLMgCdchEgGyRqiZhe;

		// Token: 0x040018A6 RID: 6310
		private bool fGiOqLLIVkpesThrpRTtDNITIoDE;

		// Token: 0x040018A7 RID: 6311
		private bool ybFzAXMvZvJUraDlavcXRJEohZNk;

		// Token: 0x040018A8 RID: 6312
		private Text LAQreHundYOntUEoeIbmNVjmcomHA;

		// Token: 0x040018A9 RID: 6313
		private bool ZgiEeLAiRXOlIDWdKViymTDzzLGF;

		// Token: 0x040018AA RID: 6314
		private bool jrXmrSsAAGrzAEdtUzKkAFPjDnAB;
	}
}
