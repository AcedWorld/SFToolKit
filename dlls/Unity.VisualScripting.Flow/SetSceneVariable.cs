using System;
using UnityEngine.SceneManagement;

namespace Unity.VisualScripting
{
	// Token: 0x02000151 RID: 337
	[UnitSurtitle("Scene")]
	public sealed class SetSceneVariable : SetVariableUnit, ISceneVariableUnit, IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x060008AF RID: 2223 RVA: 0x0000FFCB File Offset: 0x0000E1CB
		public SetSceneVariable()
		{
		}

		// Token: 0x060008B0 RID: 2224 RVA: 0x0000FFD3 File Offset: 0x0000E1D3
		public SetSceneVariable(string defaultName) : base(defaultName)
		{
		}

		// Token: 0x060008B1 RID: 2225 RVA: 0x0000FFDC File Offset: 0x0000E1DC
		protected override VariableDeclarations GetDeclarations(Flow flow)
		{
			Scene? scene = flow.stack.scene;
			if (scene == null)
			{
				return null;
			}
			return Variables.Scene(new Scene?(scene.Value));
		}

		// Token: 0x060008B2 RID: 2226 RVA: 0x00010011 File Offset: 0x0000E211
		FlowGraph IUnit.get_graph()
		{
			return base.graph;
		}
	}
}
