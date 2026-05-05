using System;
using UnityEngine.SceneManagement;

namespace Unity.VisualScripting
{
	// Token: 0x0200013F RID: 319
	[UnitSurtitle("Scene")]
	public sealed class GetSceneVariable : GetVariableUnit, ISceneVariableUnit, IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x06000873 RID: 2163 RVA: 0x0000FC32 File Offset: 0x0000DE32
		public GetSceneVariable()
		{
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x0000FC3A File Offset: 0x0000DE3A
		public GetSceneVariable(string defaultName) : base(defaultName)
		{
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x0000FC44 File Offset: 0x0000DE44
		protected override VariableDeclarations GetDeclarations(Flow flow)
		{
			Scene? scene = flow.stack.scene;
			if (scene == null)
			{
				return null;
			}
			return Variables.Scene(new Scene?(scene.Value));
		}

		// Token: 0x06000876 RID: 2166 RVA: 0x0000FC79 File Offset: 0x0000DE79
		FlowGraph IUnit.get_graph()
		{
			return base.graph;
		}
	}
}
