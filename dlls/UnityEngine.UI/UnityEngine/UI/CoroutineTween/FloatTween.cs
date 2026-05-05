using System;
using UnityEngine.Events;

namespace UnityEngine.UI.CoroutineTween
{
	// Token: 0x02000049 RID: 73
	internal struct FloatTween : ITweenValue
	{
		// Token: 0x17000150 RID: 336
		// (get) Token: 0x060004EC RID: 1260 RVA: 0x000173B9 File Offset: 0x000155B9
		// (set) Token: 0x060004ED RID: 1261 RVA: 0x000173C1 File Offset: 0x000155C1
		public float startValue
		{
			get
			{
				return this.m_StartValue;
			}
			set
			{
				this.m_StartValue = value;
			}
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x060004EE RID: 1262 RVA: 0x000173CA File Offset: 0x000155CA
		// (set) Token: 0x060004EF RID: 1263 RVA: 0x000173D2 File Offset: 0x000155D2
		public float targetValue
		{
			get
			{
				return this.m_TargetValue;
			}
			set
			{
				this.m_TargetValue = value;
			}
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x060004F0 RID: 1264 RVA: 0x000173DB File Offset: 0x000155DB
		// (set) Token: 0x060004F1 RID: 1265 RVA: 0x000173E3 File Offset: 0x000155E3
		public float duration
		{
			get
			{
				return this.m_Duration;
			}
			set
			{
				this.m_Duration = value;
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x060004F2 RID: 1266 RVA: 0x000173EC File Offset: 0x000155EC
		// (set) Token: 0x060004F3 RID: 1267 RVA: 0x000173F4 File Offset: 0x000155F4
		public bool ignoreTimeScale
		{
			get
			{
				return this.m_IgnoreTimeScale;
			}
			set
			{
				this.m_IgnoreTimeScale = value;
			}
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x00017400 File Offset: 0x00015600
		public void TweenValue(float floatPercentage)
		{
			if (!this.ValidTarget())
			{
				return;
			}
			float arg = Mathf.Lerp(this.m_StartValue, this.m_TargetValue, floatPercentage);
			this.m_Target.Invoke(arg);
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x00017435 File Offset: 0x00015635
		public void AddOnChangedCallback(UnityAction<float> callback)
		{
			if (this.m_Target == null)
			{
				this.m_Target = new FloatTween.FloatTweenCallback();
			}
			this.m_Target.AddListener(callback);
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x00017456 File Offset: 0x00015656
		public bool GetIgnoreTimescale()
		{
			return this.m_IgnoreTimeScale;
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x0001745E File Offset: 0x0001565E
		public float GetDuration()
		{
			return this.m_Duration;
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x00017466 File Offset: 0x00015666
		public bool ValidTarget()
		{
			return this.m_Target != null;
		}

		// Token: 0x0400019E RID: 414
		private FloatTween.FloatTweenCallback m_Target;

		// Token: 0x0400019F RID: 415
		private float m_StartValue;

		// Token: 0x040001A0 RID: 416
		private float m_TargetValue;

		// Token: 0x040001A1 RID: 417
		private float m_Duration;

		// Token: 0x040001A2 RID: 418
		private bool m_IgnoreTimeScale;

		// Token: 0x020000BC RID: 188
		public class FloatTweenCallback : UnityEvent<float>
		{
		}
	}
}
