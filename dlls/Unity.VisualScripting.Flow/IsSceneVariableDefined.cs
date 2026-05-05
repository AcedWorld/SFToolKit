using System;
using UnityEngine.SceneManagement;

namespace Unity.VisualScripting
{
	// Token: 0x0200014A RID: 330
	[UnitSurtitle("Scene")]
	public sealed class IsSceneVariableDefined : IsVariableDefinedUnit, ISceneVariableUnit, IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x06000891 RID: 2193 RVA: 0x0000FE27 File Offset: 0x0000E027
		public IsSceneVariableDefined()
		{
		}

		// Token: 0x06000892 RID: 2194 RVA: 0x0000FE2F File Offset: 0x0000E02F
		public IsSceneVariableDefined(string defaultName) : base(defaultName)
		{
		}

		// Token: 0x06000893 RID: 2195 RVA: 0x0000FE38 File Offset: 0x0000E038
		protected override VariableDeclarations GetDeclarations(Flow flow)
		{
			Scene? scene = flow.stack.scene;
			if (scene == null)
			{
				return null;
			}
			return Variables.Scene(new Scene?(scene.Value));
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x0000FE6D File Offset: 0x0000E06D
		FlowGraph IUnit.get_graph()
		{
			return base.graph;
		}
	}
}
