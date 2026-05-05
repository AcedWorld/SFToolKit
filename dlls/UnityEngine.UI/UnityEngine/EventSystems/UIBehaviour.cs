using System;

namespace UnityEngine.EventSystems
{
	// Token: 0x02000074 RID: 116
	public abstract class UIBehaviour : MonoBehaviour
	{
		// Token: 0x0600068C RID: 1676 RVA: 0x0001BEB7 File Offset: 0x0001A0B7
		protected virtual void Awake()
		{
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x0001BEB9 File Offset: 0x0001A0B9
		protected virtual void OnEnable()
		{
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x0001BEBB File Offset: 0x0001A0BB
		protected virtual void Start()
		{
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x0001BEBD File Offset: 0x0001A0BD
		protected virtual void OnDisable()
		{
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x0001BEBF File Offset: 0x0001A0BF
		protected virtual void OnDestroy()
		{
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x0001BEC1 File Offset: 0x0001A0C1
		public virtual bool IsActive()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x0001BEC9 File Offset: 0x0001A0C9
		protected virtual void OnRectTransformDimensionsChange()
		{
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x0001BECB File Offset: 0x0001A0CB
		protected virtual void OnBeforeTransformParentChanged()
		{
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x0001BECD File Offset: 0x0001A0CD
		protected virtual void OnTransformParentChanged()
		{
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x0001BECF File Offset: 0x0001A0CF
		protected virtual void OnDidApplyAnimationProperties()
		{
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x0001BED1 File Offset: 0x0001A0D1
		protected virtual void OnCanvasGroupChanged()
		{
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x0001BED3 File Offset: 0x0001A0D3
		protected virtual void OnCanvasHierarchyChanged()
		{
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x0001BED5 File Offset: 0x0001A0D5
		public bool IsDestroyed()
		{
			return this == null;
		}
	}
}
