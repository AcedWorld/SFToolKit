using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000044 RID: 68
	[UnitCategory("Control")]
	[UnitOrder(13)]
	public sealed class Sequence : Unit
	{
		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x06000297 RID: 663 RVA: 0x00007737 File Offset: 0x00005937
		// (set) Token: 0x06000298 RID: 664 RVA: 0x0000773F File Offset: 0x0000593F
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput enter { get; private set; }

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000299 RID: 665 RVA: 0x00007748 File Offset: 0x00005948
		// (set) Token: 0x0600029A RID: 666 RVA: 0x00007750 File Offset: 0x00005950
		[DoNotSerialize]
		[Inspectable]
		[InspectorLabel("Steps")]
		[UnitHeaderInspectable("Steps")]
		public int outputCount
		{
			get
			{
				return this._outputCount;
			}
			set
			{
				this._outputCount = Mathf.Clamp(value, 1, 10);
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x0600029B RID: 667 RVA: 0x00007761 File Offset: 0x00005961
		// (set) Token: 0x0600029C RID: 668 RVA: 0x00007769 File Offset: 0x00005969
		[DoNotSerialize]
		public ReadOnlyCollection<ControlOutput> multiOutputs { get; private set; }

		// Token: 0x0600029D RID: 669 RVA: 0x00007774 File Offset: 0x00005974
		protected override void Definition()
		{
			this.enter = base.ControlInputCoroutine("enter", new Func<Flow, ControlOutput>(this.Enter), new Func<Flow, IEnumerator>(this.EnterCoroutine));
			List<ControlOutput> list = new List<ControlOutput>();
			this.multiOutputs = list.AsReadOnly();
			for (int i = 0; i < this.outputCount; i++)
			{
				ControlOutput controlOutput = base.ControlOutput(i.ToString());
				base.Succession(this.enter, controlOutput);
				list.Add(controlOutput);
			}
		}

		// Token: 0x0600029E RID: 670 RVA: 0x000077F0 File Offset: 0x000059F0
		private ControlOutput Enter(Flow flow)
		{
			GraphStack stack = flow.PreserveStack();
			foreach (ControlOutput output in this.multiOutputs)
			{
				flow.Invoke(output);
				flow.RestoreStack(stack);
			}
			flow.DisposePreservedStack(stack);
			return null;
		}

		// Token: 0x0600029F RID: 671 RVA: 0x00007854 File Offset: 0x00005A54
		private IEnumerator EnterCoroutine(Flow flow)
		{
			GraphStack stack = flow.PreserveStack();
			foreach (ControlOutput controlOutput in this.multiOutputs)
			{
				yield return controlOutput;
				flow.RestoreStack(stack);
			}
			IEnumerator<ControlOutput> enumerator = null;
			flow.DisposePreservedStack(stack);
			yield break;
			yield break;
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x0000786A File Offset: 0x00005A6A
		public void CopyFrom(Sequence source)
		{
			base.CopyFrom(source);
			this.outputCount = source.outputCount;
		}

		// Token: 0x040000C5 RID: 197
		[SerializeAs("outputCount")]
		private int _outputCount = 2;
	}
}
