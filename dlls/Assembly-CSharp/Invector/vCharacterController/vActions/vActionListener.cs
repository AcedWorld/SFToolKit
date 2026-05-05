using System;
using UnityEngine;
using UnityEngine.Events;

namespace Invector.vCharacterController.vActions
{
	// Token: 0x02000413 RID: 1043
	public abstract class vActionListener : vMonoBehaviour, IActionListener, IActionEnterListener, IActionController, IActionExitListener, IActionStayListener
	{
		// Token: 0x170003CD RID: 973
		// (get) Token: 0x06001577 RID: 5495 RVA: 0x0006FF4E File Offset: 0x0006E14E
		// (set) Token: 0x06001578 RID: 5496 RVA: 0x0006FF56 File Offset: 0x0006E156
		public bool actionEnter { get; set; }

		// Token: 0x170003CE RID: 974
		// (get) Token: 0x06001579 RID: 5497 RVA: 0x0006FF5F File Offset: 0x0006E15F
		// (set) Token: 0x0600157A RID: 5498 RVA: 0x0006FF67 File Offset: 0x0006E167
		public bool actionExit { get; set; }

		// Token: 0x170003CF RID: 975
		// (get) Token: 0x0600157B RID: 5499 RVA: 0x0006FF70 File Offset: 0x0006E170
		// (set) Token: 0x0600157C RID: 5500 RVA: 0x0006FF78 File Offset: 0x0006E178
		public bool actionStay { get; set; }

		// Token: 0x170003D0 RID: 976
		// (get) Token: 0x0600157D RID: 5501 RVA: 0x0006FF81 File Offset: 0x0006E181
		// (set) Token: 0x0600157E RID: 5502 RVA: 0x0006FF89 File Offset: 0x0006E189
		public bool doingAction { get; set; }

		// Token: 0x0600157F RID: 5503 RVA: 0x0006FF92 File Offset: 0x0006E192
		protected virtual void Awake()
		{
			this.SetUpListener();
		}

		// Token: 0x06001580 RID: 5504 RVA: 0x0006FF9A File Offset: 0x0006E19A
		protected virtual void SetUpListener()
		{
			this.actionEnter = true;
			this.actionExit = true;
			this.actionStay = true;
		}

		// Token: 0x06001581 RID: 5505 RVA: 0x0006FFB4 File Offset: 0x0006E1B4
		protected virtual void Start()
		{
			IActionReceiver[] components = base.GetComponents<IActionReceiver>();
			for (int i = 0; i < components.Length; i++)
			{
				this.OnDoAction.AddListener(new UnityAction<vTriggerGenericAction>(components[i].OnReceiveAction));
			}
		}

		// Token: 0x06001582 RID: 5506 RVA: 0x000020BE File Offset: 0x000002BE
		public virtual void OnActionEnter(Collider other)
		{
		}

		// Token: 0x06001583 RID: 5507 RVA: 0x000020BE File Offset: 0x000002BE
		public virtual void OnActionStay(Collider other)
		{
		}

		// Token: 0x06001584 RID: 5508 RVA: 0x000020BE File Offset: 0x000002BE
		public virtual void OnActionExit(Collider other)
		{
		}

		// Token: 0x06001586 RID: 5510 RVA: 0x00069920 File Offset: 0x00067B20
		bool IActionController.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x06001587 RID: 5511 RVA: 0x00069928 File Offset: 0x00067B28
		void IActionController.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x06001588 RID: 5512 RVA: 0x0005EB26 File Offset: 0x0005CD26
		GameObject IActionController.get_gameObject()
		{
			return base.gameObject;
		}

		// Token: 0x06001589 RID: 5513 RVA: 0x0005B662 File Offset: 0x00059862
		Transform IActionController.get_transform()
		{
			return base.transform;
		}

		// Token: 0x0600158A RID: 5514 RVA: 0x00070003 File Offset: 0x0006E203
		string IActionController.get_name()
		{
			return base.name;
		}

		// Token: 0x0600158B RID: 5515 RVA: 0x0007000B File Offset: 0x0006E20B
		Type IActionController.GetType()
		{
			return base.GetType();
		}

		// Token: 0x04001B4D RID: 6989
		[vEditorToolbar("Events", false, "", false, false, order = 10)]
		public vOnActionHandle OnDoAction = new vOnActionHandle();
	}
}
