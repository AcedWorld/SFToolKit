using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Invector.Utils
{
	// Token: 0x020003B6 RID: 950
	[vClassHeader("Events With Delay", true, "icon_v2", false, "")]
	public class vEventWithDelay : vMonoBehaviour
	{
		// Token: 0x060012F5 RID: 4853 RVA: 0x00064461 File Offset: 0x00062661
		private void OnEnable()
		{
			if (this.triggerOnEnable)
			{
				if (this.all)
				{
					this.DoEvents();
					return;
				}
				this.DoEvent(this.eventIndex);
			}
		}

		// Token: 0x060012F6 RID: 4854 RVA: 0x00064486 File Offset: 0x00062686
		private void Start()
		{
			if (this.triggerOnStart)
			{
				if (this.all)
				{
					this.DoEvents();
					return;
				}
				this.DoEvent(this.eventIndex);
			}
		}

		// Token: 0x060012F7 RID: 4855 RVA: 0x000644AB File Offset: 0x000626AB
		private void OnDisable()
		{
			base.StopAllCoroutines();
		}

		// Token: 0x060012F8 RID: 4856 RVA: 0x000644B4 File Offset: 0x000626B4
		public void DoEvents()
		{
			for (int i = 0; i < this.events.Length; i++)
			{
				base.StartCoroutine(this.DoEventWithDelay(this.events[i]));
			}
		}

		// Token: 0x060012F9 RID: 4857 RVA: 0x000644E9 File Offset: 0x000626E9
		public void DoEvent(int index)
		{
			if (index < this.events.Length && this.events.Length != 0)
			{
				base.StartCoroutine(this.DoEventWithDelay(this.events[index]));
			}
		}

		// Token: 0x060012FA RID: 4858 RVA: 0x00064514 File Offset: 0x00062714
		public void DoEvent(string name)
		{
			vEventWithDelay.vEventWithDelayObject vEventWithDelayObject = Array.Find<vEventWithDelay.vEventWithDelayObject>(this.events, (vEventWithDelay.vEventWithDelayObject e) => e.name.Equals(name));
			if (vEventWithDelayObject != null)
			{
				base.StartCoroutine(this.DoEventWithDelay(vEventWithDelayObject));
			}
		}

		// Token: 0x060012FB RID: 4859 RVA: 0x00064557 File Offset: 0x00062757
		private IEnumerator DoEventWithDelay(vEventWithDelay.vEventWithDelayObject _event)
		{
			yield return new WaitForSeconds(_event.delay);
			_event.onDoEvent.Invoke();
			yield break;
		}

		// Token: 0x040018C2 RID: 6338
		public bool triggerOnStart;

		// Token: 0x040018C3 RID: 6339
		public bool triggerOnEnable;

		// Token: 0x040018C4 RID: 6340
		[vHideInInspector("triggerOnStart", false)]
		public bool all;

		// Token: 0x040018C5 RID: 6341
		[vHideInInspector("triggerOnStart", false)]
		public int eventIndex;

		// Token: 0x040018C6 RID: 6342
		[SerializeField]
		private vEventWithDelay.vEventWithDelayObject[] events = new vEventWithDelay.vEventWithDelayObject[0];

		// Token: 0x020003B7 RID: 951
		[Serializable]
		public class vEventWithDelayObject
		{
			// Token: 0x040018C7 RID: 6343
			public string name = "EventName";

			// Token: 0x040018C8 RID: 6344
			public float delay;

			// Token: 0x040018C9 RID: 6345
			public UnityEvent onDoEvent;
		}
	}
}
