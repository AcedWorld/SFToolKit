using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Invector.Utils
{
	// Token: 0x020003C3 RID: 963
	public class vTimerCounter : MonoBehaviour
	{
		// Token: 0x06001333 RID: 4915 RVA: 0x00064C85 File Offset: 0x00062E85
		public void Start()
		{
			if (this.startTimerOnStart)
			{
				this.StartTimer();
			}
		}

		// Token: 0x06001334 RID: 4916 RVA: 0x00064C95 File Offset: 0x00062E95
		public virtual void StartTimer()
		{
			if (this.timerRoutine != null)
			{
				base.StopCoroutine(this.timerRoutine);
			}
			this.timerRoutine = base.StartCoroutine(this.TimerRoutiner());
		}

		// Token: 0x06001335 RID: 4917 RVA: 0x00064CBD File Offset: 0x00062EBD
		public void StopTimer()
		{
			this.PauseTimer();
			this.currentTime = 0f;
			this.onStop.Invoke();
			this.timerResult = 0f;
			this.onTimerUpdated.Invoke(0f);
		}

		// Token: 0x06001336 RID: 4918 RVA: 0x00064CF6 File Offset: 0x00062EF6
		public void PauseTimer()
		{
			if (this.timerRoutine != null)
			{
				base.StopCoroutine(this.timerRoutine);
			}
			this.timerRoutine = null;
			this.onPause.Invoke();
		}

		// Token: 0x06001337 RID: 4919 RVA: 0x00064D1E File Offset: 0x00062F1E
		private IEnumerator TimerRoutiner()
		{
			this.onStart.Invoke();
			while (this.currentTime < this.targetTime)
			{
				this.currentTime += Time.deltaTime;
				this.timerResult = (this.normalizeResult ? (this.currentTime / this.targetTime) : this.currentTime);
				this.onTimerUpdated.Invoke(this.timerResult);
				yield return null;
			}
			this.timerRoutine = null;
			this.timerResult = (this.normalizeResult ? 1f : this.targetTime);
			this.onTimerUpdated.Invoke(this.timerResult);
			this.onFinish.Invoke();
			yield break;
		}

		// Token: 0x040018F0 RID: 6384
		public float targetTime;

		// Token: 0x040018F1 RID: 6385
		public bool normalizeResult;

		// Token: 0x040018F2 RID: 6386
		[SerializeField]
		[vReadOnly(true)]
		protected float timerResult;

		// Token: 0x040018F3 RID: 6387
		public bool startTimerOnStart;

		// Token: 0x040018F4 RID: 6388
		public UnityEvent onStart;

		// Token: 0x040018F5 RID: 6389
		public UnityEvent onPause;

		// Token: 0x040018F6 RID: 6390
		public UnityEvent onStop;

		// Token: 0x040018F7 RID: 6391
		public UnityEvent onFinish;

		// Token: 0x040018F8 RID: 6392
		public Slider.SliderEvent onTimerUpdated;

		// Token: 0x040018F9 RID: 6393
		protected float currentTime;

		// Token: 0x040018FA RID: 6394
		protected Coroutine timerRoutine;
	}
}
