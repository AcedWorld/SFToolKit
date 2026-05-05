using System;

namespace UnityEngine.EventSystems
{
	// Token: 0x02000069 RID: 105
	public class BaseInput : UIBehaviour
	{
		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x060005FF RID: 1535 RVA: 0x0001976B File Offset: 0x0001796B
		public virtual string compositionString
		{
			get
			{
				return Input.compositionString;
			}
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06000600 RID: 1536 RVA: 0x00019772 File Offset: 0x00017972
		// (set) Token: 0x06000601 RID: 1537 RVA: 0x00019779 File Offset: 0x00017979
		public virtual IMECompositionMode imeCompositionMode
		{
			get
			{
				return Input.imeCompositionMode;
			}
			set
			{
				Input.imeCompositionMode = value;
			}
		}

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06000602 RID: 1538 RVA: 0x00019781 File Offset: 0x00017981
		// (set) Token: 0x06000603 RID: 1539 RVA: 0x00019788 File Offset: 0x00017988
		public virtual Vector2 compositionCursorPos
		{
			get
			{
				return Input.compositionCursorPos;
			}
			set
			{
				Input.compositionCursorPos = value;
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06000604 RID: 1540 RVA: 0x00019790 File Offset: 0x00017990
		public virtual bool mousePresent
		{
			get
			{
				return Input.mousePresent;
			}
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x00019797 File Offset: 0x00017997
		public virtual bool GetMouseButtonDown(int button)
		{
			return Input.GetMouseButtonDown(button);
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x0001979F File Offset: 0x0001799F
		public virtual bool GetMouseButtonUp(int button)
		{
			return Input.GetMouseButtonUp(button);
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x000197A7 File Offset: 0x000179A7
		public virtual bool GetMouseButton(int button)
		{
			return Input.GetMouseButton(button);
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06000608 RID: 1544 RVA: 0x000197AF File Offset: 0x000179AF
		public virtual Vector2 mousePosition
		{
			get
			{
				return Input.mousePosition;
			}
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06000609 RID: 1545 RVA: 0x000197BB File Offset: 0x000179BB
		public virtual Vector2 mouseScrollDelta
		{
			get
			{
				return Input.mouseScrollDelta;
			}
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x0600060A RID: 1546 RVA: 0x000197C2 File Offset: 0x000179C2
		public virtual bool touchSupported
		{
			get
			{
				return Input.touchSupported;
			}
		}

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x0600060B RID: 1547 RVA: 0x000197C9 File Offset: 0x000179C9
		public virtual int touchCount
		{
			get
			{
				return Input.touchCount;
			}
		}

		// Token: 0x0600060C RID: 1548 RVA: 0x000197D0 File Offset: 0x000179D0
		public virtual Touch GetTouch(int index)
		{
			return Input.GetTouch(index);
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x000197D8 File Offset: 0x000179D8
		public virtual float GetAxisRaw(string axisName)
		{
			return Input.GetAxisRaw(axisName);
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x000197E0 File Offset: 0x000179E0
		public virtual bool GetButtonDown(string buttonName)
		{
			return Input.GetButtonDown(buttonName);
		}
	}
}
