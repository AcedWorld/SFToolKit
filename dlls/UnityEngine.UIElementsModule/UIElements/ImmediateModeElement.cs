using System;
using System.Collections.Generic;
using Unity.Profiling;

namespace UnityEngine.UIElements
{
	// Token: 0x0200026B RID: 619
	public abstract class ImmediateModeElement : VisualElement
	{
		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x060011A4 RID: 4516 RVA: 0x00040488 File Offset: 0x0003E688
		// (set) Token: 0x060011A5 RID: 4517 RVA: 0x000404A0 File Offset: 0x0003E6A0
		public bool cullingEnabled
		{
			get
			{
				return this.m_CullingEnabled;
			}
			set
			{
				this.m_CullingEnabled = value;
				base.IncrementVersion(VersionChangeType.Repaint);
			}
		}

		// Token: 0x060011A6 RID: 4518 RVA: 0x000404B8 File Offset: 0x0003E6B8
		public ImmediateModeElement()
		{
			base.generateVisualContent = (Action<MeshGenerationContext>)Delegate.Combine(base.generateVisualContent, new Action<MeshGenerationContext>(this.OnGenerateVisualContent));
			Type type = base.GetType();
			bool flag = !ImmediateModeElement.s_Markers.TryGetValue(type, out this.m_ImmediateRepaintMarker);
			if (flag)
			{
				this.m_ImmediateRepaintMarker = new ProfilerMarker(base.typeName + ".ImmediateRepaint");
				ImmediateModeElement.s_Markers[type] = this.m_ImmediateRepaintMarker;
			}
		}

		// Token: 0x060011A7 RID: 4519 RVA: 0x00040545 File Offset: 0x0003E745
		private void OnGenerateVisualContent(MeshGenerationContext mgc)
		{
			mgc.painter.DrawImmediate(new Action(this.CallImmediateRepaint), this.cullingEnabled);
		}

		// Token: 0x060011A8 RID: 4520 RVA: 0x00040568 File Offset: 0x0003E768
		private void CallImmediateRepaint()
		{
			using (this.m_ImmediateRepaintMarker.Auto())
			{
				this.ImmediateRepaint();
			}
		}

		// Token: 0x060011A9 RID: 4521
		protected abstract void ImmediateRepaint();

		// Token: 0x040007CB RID: 1995
		private static readonly Dictionary<Type, ProfilerMarker> s_Markers = new Dictionary<Type, ProfilerMarker>();

		// Token: 0x040007CC RID: 1996
		private readonly ProfilerMarker m_ImmediateRepaintMarker;

		// Token: 0x040007CD RID: 1997
		private bool m_CullingEnabled = false;
	}
}
