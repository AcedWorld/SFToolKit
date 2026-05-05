using System;

namespace UnityEngine
{
	// Token: 0x0200024B RID: 587
	[AttributeUsage(AttributeTargets.Enum)]
	public sealed class InspectorOrderAttribute : PropertyAttribute
	{
		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x06001921 RID: 6433 RVA: 0x0002A033 File Offset: 0x00028233
		// (set) Token: 0x06001922 RID: 6434 RVA: 0x0002A03B File Offset: 0x0002823B
		internal InspectorSort m_inspectorSort { get; private set; }

		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x06001923 RID: 6435 RVA: 0x0002A044 File Offset: 0x00028244
		// (set) Token: 0x06001924 RID: 6436 RVA: 0x0002A04C File Offset: 0x0002824C
		internal InspectorSortDirection m_sortDirection { get; private set; }

		// Token: 0x06001925 RID: 6437 RVA: 0x0002A055 File Offset: 0x00028255
		public InspectorOrderAttribute(InspectorSort inspectorSort = InspectorSort.ByName, InspectorSortDirection sortDirection = InspectorSortDirection.Ascending)
		{
			this.m_inspectorSort = inspectorSort;
			this.m_sortDirection = sortDirection;
		}
	}
}
