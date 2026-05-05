using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000017 RID: 23
	[MovedFrom("Unity.GameCore")]
	public class XClosedCaptionProperties
	{
		// Token: 0x06000246 RID: 582 RVA: 0x000086E8 File Offset: 0x000068E8
		internal XClosedCaptionProperties(XClosedCaptionProperties interop)
		{
			this.BackgroundColor = new XColor(interop.BackgroundColor);
			this.FontColor = new XColor(interop.FontColor);
			this.WindowColor = new XColor(interop.WindowColor);
			this._interop = interop;
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00008735 File Offset: 0x00006935
		public XClosedCaptionProperties()
		{
			this._interop = default(XClosedCaptionProperties);
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000248 RID: 584 RVA: 0x0000874C File Offset: 0x0000694C
		internal XClosedCaptionProperties interop
		{
			get
			{
				this._interop.BackgroundColor = this._backgroundColor.interop;
				this._interop.FontColor = this._fontColor.interop;
				this._interop.WindowColor = this._windowColor.interop;
				return this._interop;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000249 RID: 585 RVA: 0x000087A1 File Offset: 0x000069A1
		// (set) Token: 0x0600024A RID: 586 RVA: 0x000087A9 File Offset: 0x000069A9
		public XColor BackgroundColor
		{
			get
			{
				return this._backgroundColor;
			}
			set
			{
				this._backgroundColor = value;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600024B RID: 587 RVA: 0x000087B2 File Offset: 0x000069B2
		// (set) Token: 0x0600024C RID: 588 RVA: 0x000087BA File Offset: 0x000069BA
		public XColor FontColor
		{
			get
			{
				return this._fontColor;
			}
			set
			{
				this._fontColor = value;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600024D RID: 589 RVA: 0x000087C3 File Offset: 0x000069C3
		// (set) Token: 0x0600024E RID: 590 RVA: 0x000087CB File Offset: 0x000069CB
		public XColor WindowColor
		{
			get
			{
				return this._windowColor;
			}
			set
			{
				this._windowColor = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600024F RID: 591 RVA: 0x000087D4 File Offset: 0x000069D4
		// (set) Token: 0x06000250 RID: 592 RVA: 0x000087E1 File Offset: 0x000069E1
		public XClosedCaptionFontEdgeAttribute FontEdgeAttribute
		{
			get
			{
				return this._interop.FontEdgeAttribute;
			}
			set
			{
				this._interop.FontEdgeAttribute = value;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000251 RID: 593 RVA: 0x000087EF File Offset: 0x000069EF
		// (set) Token: 0x06000252 RID: 594 RVA: 0x000087FC File Offset: 0x000069FC
		public XClosedCaptionFontStyle FontStyle
		{
			get
			{
				return this._interop.FontStyle;
			}
			set
			{
				this._interop.FontStyle = value;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000253 RID: 595 RVA: 0x0000880A File Offset: 0x00006A0A
		// (set) Token: 0x06000254 RID: 596 RVA: 0x00008817 File Offset: 0x00006A17
		public float FontScale
		{
			get
			{
				return this._interop.FontScale;
			}
			set
			{
				this._interop.FontScale = value;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000255 RID: 597 RVA: 0x00008825 File Offset: 0x00006A25
		// (set) Token: 0x06000256 RID: 598 RVA: 0x00008832 File Offset: 0x00006A32
		public bool Enabled
		{
			get
			{
				return this._interop.Enabled;
			}
			set
			{
				this._interop.Enabled = value;
			}
		}

		// Token: 0x0400009D RID: 157
		internal XClosedCaptionProperties _interop;

		// Token: 0x0400009E RID: 158
		internal XColor _backgroundColor;

		// Token: 0x0400009F RID: 159
		internal XColor _fontColor;

		// Token: 0x040000A0 RID: 160
		internal XColor _windowColor;
	}
}
