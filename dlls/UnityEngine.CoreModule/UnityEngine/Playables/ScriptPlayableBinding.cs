using System;

namespace UnityEngine.Playables
{
	// Token: 0x020004AA RID: 1194
	public static class ScriptPlayableBinding
	{
		// Token: 0x060029C4 RID: 10692 RVA: 0x00046D5C File Offset: 0x00044F5C
		public static PlayableBinding Create(string name, Object key, Type type)
		{
			return PlayableBinding.CreateInternal(name, key, type, new PlayableBinding.CreateOutputMethod(ScriptPlayableBinding.CreateScriptOutput));
		}

		// Token: 0x060029C5 RID: 10693 RVA: 0x00046D84 File Offset: 0x00044F84
		private static PlayableOutput CreateScriptOutput(PlayableGraph graph, string name)
		{
			return ScriptPlayableOutput.Create(graph, name);
		}
	}
}
