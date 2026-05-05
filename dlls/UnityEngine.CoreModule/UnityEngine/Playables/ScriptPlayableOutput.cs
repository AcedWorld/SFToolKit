using System;
using UnityEngine.Scripting;

namespace UnityEngine.Playables
{
	// Token: 0x020004AB RID: 1195
	[RequiredByNativeCode]
	public struct ScriptPlayableOutput : IPlayableOutput
	{
		// Token: 0x060029C6 RID: 10694 RVA: 0x00046DA4 File Offset: 0x00044FA4
		public static ScriptPlayableOutput Create(PlayableGraph graph, string name)
		{
			PlayableOutputHandle handle;
			bool flag = !graph.CreateScriptOutputInternal(name, out handle);
			ScriptPlayableOutput result;
			if (flag)
			{
				result = ScriptPlayableOutput.Null;
			}
			else
			{
				result = new ScriptPlayableOutput(handle);
			}
			return result;
		}

		// Token: 0x060029C7 RID: 10695 RVA: 0x00046DD8 File Offset: 0x00044FD8
		internal ScriptPlayableOutput(PlayableOutputHandle handle)
		{
			bool flag = handle.IsValid();
			if (flag)
			{
				bool flag2 = !handle.IsPlayableOutputOfType<ScriptPlayableOutput>();
				if (flag2)
				{
					throw new InvalidCastException("Can't set handle: the playable is not a ScriptPlayableOutput.");
				}
			}
			this.m_Handle = handle;
		}

		// Token: 0x170007A5 RID: 1957
		// (get) Token: 0x060029C8 RID: 10696 RVA: 0x00046E14 File Offset: 0x00045014
		public static ScriptPlayableOutput Null
		{
			get
			{
				return new ScriptPlayableOutput(PlayableOutputHandle.Null);
			}
		}

		// Token: 0x060029C9 RID: 10697 RVA: 0x00046E30 File Offset: 0x00045030
		public PlayableOutputHandle GetHandle()
		{
			return this.m_Handle;
		}

		// Token: 0x060029CA RID: 10698 RVA: 0x00046E48 File Offset: 0x00045048
		public static implicit operator PlayableOutput(ScriptPlayableOutput output)
		{
			return new PlayableOutput(output.GetHandle());
		}

		// Token: 0x060029CB RID: 10699 RVA: 0x00046E68 File Offset: 0x00045068
		public static explicit operator ScriptPlayableOutput(PlayableOutput output)
		{
			return new ScriptPlayableOutput(output.GetHandle());
		}

		// Token: 0x04000F84 RID: 3972
		private PlayableOutputHandle m_Handle;
	}
}
