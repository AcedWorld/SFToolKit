using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020000C0 RID: 192
public class MainButtonLogic : MonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler
{
	// Token: 0x06000349 RID: 841 RVA: 0x00019EF1 File Offset: 0x000180F1
	private void Start()
	{
		this.animator = base.GetComponent<Animator>();
	}

	// Token: 0x0600034A RID: 842 RVA: 0x00019EFF File Offset: 0x000180FF
	public void OnSelect(BaseEventData eventData)
	{
		this.animator.SetTrigger("Selected");
	}

	// Token: 0x0600034B RID: 843 RVA: 0x00019F11 File Offset: 0x00018111
	public void OnDeselect(BaseEventData eventData)
	{
		this.animator.SetTrigger("Deselected");
	}

	// Token: 0x04000499 RID: 1177
	private Animator animator;
}
